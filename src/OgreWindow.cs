using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mogre;
using System.IO;

namespace Mogre.Demo.MogreForm
{
    public enum Wardrobe : int
    {
        Face = 0,
        Boots = 1,
        Chest = 2,
        Gloves = 3,
        Helmet = 4,
        Shoulders = 5       
    };

    public class OgreWindow
    {
        public Root root;
        public SceneManager sceneMgr;
        public Camera camera;

        public SceneNode CameraNode;

        protected Viewport viewport;
        protected RenderWindow window;
        protected Point position;
        protected Size windowSize;
        protected IntPtr hWnd;

        const string MODEL_NODE = "modelView";

        public bool IsWardrobed { get; private set; }
        public string[] WardrobeTextures = null;

        public bool AutoRotateModel { get; set; }
        public float AutoRotateSpeed { get; set; }
        public bool Animate { get; set; }

        private SceneNode ModelSceneNode { get; set; }
        private Entity ModelEntity { get; set; }

        public Vector3 ModelCenterPosition { get; private set; }

        SceneNode mainGrid;

        private bool HasModelEntity
        {
            get
            {
                return (ModelEntity != null);
            }
        }

        private bool HasModelSceneNode
        {
            get
            {
                return (ModelSceneNode != null);
            }
        }

        public OgreWindow(Point origin, Size theWindowSize, IntPtr hWnd)
        {
            IsWardrobed = false;
            WardrobeTextures = new string[Enum.GetValues(typeof(Wardrobe)).Length];
            position = origin;
            windowSize = theWindowSize;
            this.hWnd = hWnd;

            AutoRotateSpeed = 2f;
        }

        public void InitMogre()
        {

            //----------------------------------------------------- 
            // 1 enter ogre 
            //----------------------------------------------------- 
            root = new Root();

            //----------------------------------------------------- 
            // 2 configure resource paths
            //----------------------------------------------------- 
            //----------------------------------------------------- 
            // 3 Configures the application and creates the window
            //----------------------------------------------------- 
#if DEBUG
            root.LoadPlugin("RenderSystem_Direct3D9_d");
#else
            root.LoadPlugin("RenderSystem_Direct3D9");
#endif

            bool foundit = false;
            foreach (RenderSystem rs in root.GetAvailableRenderers())
            {
                root.RenderSystem = rs;
                String rname = root.RenderSystem.Name;
                if (rname == "Direct3D9 Rendering Subsystem")
                {
                    foundit = true;
                    break;
                }
            }

            if (!foundit)
                return; //we didn't find it... Raise exception?

            //we found it, we might as well use it!
            root.RenderSystem.SetConfigOption("Full Screen", "No");
            root.RenderSystem.SetConfigOption("Video Mode",
                string.Format("{0} x {1} @ 32-bit colour", windowSize.Width, windowSize.Height));

            root.Initialise(false);

            // other plugins
#if DEBUG
            root.LoadPlugin("Plugin_CgProgramManager_d");
            root.LoadPlugin("Plugin_OctreeSceneManager_d");

#else
            root.LoadPlugin("Plugin_CgProgramManager");
            root.LoadPlugin("Plugin_OctreeSceneManager");
#endif

            NameValuePairList misc = new NameValuePairList();
            misc["externalWindowHandle"] = hWnd.ToString();
            window = root.CreateRenderWindow("Simple Mogre Form Window", 0, 0, false, misc);

            ResourceGroupManager.Singleton.InitialiseAllResourceGroups();

            //----------------------------------------------------- 
            // 4 Create the SceneManager
            // 
            //		ST_GENERIC = octree
            //		ST_EXTERIOR_CLOSE = simple terrain
            //		ST_EXTERIOR_FAR = nature terrain (depreciated)
            //		ST_EXTERIOR_REAL_FAR = paging landscape
            //		ST_INTERIOR = Quake3 BSP
            //----------------------------------------------------- 
            sceneMgr = root.CreateSceneManager(SceneType.ST_GENERIC, "SceneMgr");
            sceneMgr.AmbientLight = new ColourValue(0.5f, 0.5f, 0.5f);

            //----------------------------------------------------- 
            // 5 Create the camera 
            //----------------------------------------------------- 
            camera = sceneMgr.CreateCamera("SimpleCamera");
            camera.NearClipDistance = 0.1f;
            camera.AutoAspectRatio = true;



            viewport = window.AddViewport(camera);
            viewport.BackgroundColour = new ColourValue(0.25f, 0.25f, 0.25f, 1.0f);

            root.FrameStarted += new FrameListener.FrameStartedHandler(MogreFrameStarted);
        }

        bool MogreFrameStarted(FrameEvent evt)
        {
            if (AutoRotateModel)
            {
                if (HasModelSceneNode)
                {
                    ModelSceneNode.Rotate(new Vector3(0f, 1f, 0f),
                        new Radian(AutoRotateSpeed * evt.timeSinceLastFrame));
                }
            }

            if (Animate) UpdateAnimation(evt.timeSinceLastFrame);

            return true;
        }

        public void Resize(int theWidht, int theHeight)
        {
            window.WindowMovedOrResized();
            window.Resize((uint)theWidht, (uint)theHeight);
            //window.Crea
            root.RenderSystem.SetConfigOption("Video Mode",
                string.Format("{0} x {1} @ 32-bit colour", theWidht, theHeight));
        }

        
        public void Reset()
        {
            if (HasModelSceneNode)
            {
                ModelSceneNode.ResetToInitialState();
                if (HasModelEntity)
                {
                    SetInitialCamera(ModelEntity, ModelSceneNode);
                }
            }
        }

        public void SetGrid()
        {
            mainGrid = sceneMgr.RootSceneNode.CreateChildSceneNode("mainGrid_node");
            mainGrid.SetPosition(0, -0.05f, 0);
            mainGrid.AttachObject(CreateGrid(sceneMgr, 30f, 1f, "main"));
        }

        public void SetWardrobeTexture(Wardrobe thePieceType, string theTexture)
        {
            if (string.Compare(theTexture, "none", true) == 0 ||
                string.IsNullOrEmpty(theTexture)) return;
            
            // gather information about wardrobe
            if (ModelEntity.GetMesh().NumSubMeshes > 0)
            {
                bool needsReload = false;
                foreach (var subMesh in ModelEntity.GetMesh().GetSubMeshIterator())
                {
                    var matPtr = (MaterialPtr)MaterialManager.Singleton.GetByName(subMesh.MaterialName);

                    string suitStr = thePieceType.ToString();
                    if (subMesh.MaterialName.IndexOf(suitStr, StringComparison.OrdinalIgnoreCase) >= 0)
                    {                    
                        foreach (var mtrPass in matPtr.GetTechnique(0).GetPassIterator())
                        {                            
                            mtrPass.RemoveAllTextureUnitStates();

                            TextureUnitState baseTex = null;
                            if (WardrobeTextures[(int)Wardrobe.Face] != null)
                            {
                                baseTex = new TextureUnitState(mtrPass, WardrobeTextures[(int)Wardrobe.Face]);
                            }
                            TextureUnitState wardTex = new TextureUnitState(mtrPass, theTexture);
                            wardTex.SetColourOperation(LayerBlendOperation.LBO_ALPHA_BLEND);
                            needsReload = true;
                            if (baseTex!=null) mtrPass.AddTextureUnitState(baseTex);
                            mtrPass.AddTextureUnitState(wardTex);
                          
                        }

                        WardrobeTextures[(int)thePieceType] = theTexture;
                        break;
                    }
                    if (needsReload) matPtr.Reload();
                }                
            }
        }

        public List<string> SetViewModel(string theModel)
        {
            string nameOnly = Path.GetFileNameWithoutExtension(theModel);
            string filename = Path.GetFileName(theModel);
            string modelDir = Path.GetDirectoryName(theModel);

            AddResourcesDirectory(nameOnly, modelDir);

            //Entity ent = null;
            if (sceneMgr.HasEntity(nameOnly))
            {
                sceneMgr.DestroyEntity(nameOnly);
            }
            ModelEntity = sceneMgr.CreateEntity(nameOnly, filename, nameOnly);

            //SceneNode node = null;
            if (sceneMgr.HasSceneNode(MODEL_NODE))
            {
                sceneMgr.DestroySceneNode(MODEL_NODE);
            }
            ModelSceneNode = sceneMgr.RootSceneNode.CreateChildSceneNode(MODEL_NODE);
            ModelSceneNode.SetInitialState();

            ModelSceneNode.DetachAllObjects();
            ModelSceneNode.AttachObject(ModelEntity);

            // check for material textures
            foreach (var subMesh in ModelEntity.GetMesh().GetSubMeshIterator())
            {
                bool needsReload = false;
                var matPtr = (MaterialPtr)MaterialManager.Singleton.GetByName(subMesh.MaterialName);
                if (matPtr != null)
                {
                    foreach (var mtrPass in matPtr.GetTechnique(0).GetPassIterator())
                    {
                        foreach (var mtrTex in mtrPass.GetTextureUnitStateIterator())
                        {
                            if (mtrTex.IsTextureLoadFailing)
                            {
                                mtrTex.SetTextureName(mtrTex.TextureName.Replace(".png", ".dds"));
                                needsReload = true;
                            }
                        }
                    }
                }
                if (needsReload) matPtr.Reload();
            }
                        
            // gather information about wardrobe
            IsWardrobed = false;
            WardrobeTextures = new string[Enum.GetValues(typeof(Wardrobe)).Length];

            if (ModelEntity.GetMesh().NumSubMeshes > 0)
            {
                foreach (var subMesh in ModelEntity.GetMesh().GetSubMeshIterator())
                {                    
                    var matPtr = (MaterialPtr)MaterialManager.Singleton.GetByName(subMesh.MaterialName);

                    foreach (Wardrobe suit in Enum.GetValues(typeof(Wardrobe)))
                    {
                        string suitStr = suit.ToString();
                        if (subMesh.MaterialName.IndexOf(suitStr, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            IsWardrobed = true;
                            string wardrobeTex = "none";
                            foreach (var mtrPass in matPtr.GetTechnique(0).GetPassIterator())
                            {
                                foreach (var mtrTex in mtrPass.GetTextureUnitStateIterator())
                                {
                                    if (!string.IsNullOrEmpty(mtrTex.TextureName))
                                    {
                                        wardrobeTex = mtrTex.TextureName;
                                    }
                                }
                            }

                            WardrobeTextures[(int)suit] = wardrobeTex;                            
                            break;
                        }
                    }                  
                }
            }
            
            //// 2nd pass
            //// check for material wardrobe textures
            //if (ModelEntity.GetMesh().NumSubMeshes > 0)
            //{
            //    foreach (var subMesh in ModelEntity.GetMesh().GetSubMeshIterator())
            //    {
            //        bool needsReload = false;
            //        var matPtr = (MaterialPtr)MaterialManager.Singleton.GetByName(subMesh.MaterialName);
            //        foreach (var mtrPass in matPtr.GetTechnique(0).GetPassIterator())
            //        {
            //            foreach (var mtrTex in mtrPass.GetTextureUnitStateIterator())
            //            {
            //                foreach (var wardrobe in allWadrobe)
            //                {
            //                    if (subMesh.MaterialName.IndexOf(wardrobe, StringComparison.OrdinalIgnoreCase) >= 0)
            //                    {
            //                        var fl = Directory.GetFiles(modelDir, string.Format("*{0}*", wardrobe));
            //                        // get the first that matches
            //                        if (fl.Length > 0)
            //                            mtrTex.SetTextureName(Path.GetFileName(fl[0]));
            //                        needsReload = true;
            //                    }
            //                }
            //            }
            //        }
            //        if (needsReload) matPtr.Reload();
            //    }
            //}
            // check for skeleton and animations
            if (ModelEntity.HasSkeleton)
            {
                foreach (string skltFiles in Directory.GetFiles(modelDir, "*.skeleton"))
                {
                    try
                    {
                        SkeletonPtr source = SkeletonManager.Singleton.Load(Path.GetFileName(skltFiles), "General");
                        Skeleton.BoneHandleMap boneHandleMap = new Skeleton.BoneHandleMap();
                        source._buildMapBoneByHandle(source, boneHandleMap);
                        ModelEntity.Skeleton._mergeSkeletonAnimations(source, boneHandleMap);
                        ModelEntity.Skeleton._refreshAnimationState(ModelEntity.AllAnimationStates);
                    }
                    catch
                    {
                    }
                }
            }

            SetInitialCamera(ModelEntity, ModelSceneNode);
            
            if (sceneMgr.HasLight("SimpleLight"))
            {
                sceneMgr.DestroyLight("SimpleLight");
            }
            Light light = sceneMgr.CreateLight("SimpleLight");
            sceneMgr.RootSceneNode.AttachObject(light);
            light.DiffuseColour = new ColourValue(1f, 1f, 1f);
            light.Position = this.camera.Position;
            light.Direction = this.camera.Direction;

            return GetAnimationNames(ModelEntity);
        }

        public List<string> GetAnimationNames(Entity theEntity)
        {
            List<string> list = new List<string>();
            if ((theEntity.HasSkeleton))
            {
                for (ushort i = 0; i < theEntity.Skeleton.NumAnimations; i = (ushort)(i + 1))
                {
                    list.Add(theEntity.Skeleton.GetAnimation(i).Name);
                }
            }
            return list;
        }

        public void SetActiveAnimation(string theName)
        {
            if ((HasModelEntity) && ModelEntity.Skeleton.HasAnimation(theName))
            {
                ModelEntity.Skeleton.Reset();
                foreach (var animState in ModelEntity.AllAnimationStates.GetAnimationStateIterator())
                {
                    if (string.Compare(animState.AnimationName, theName, true) == 0)
                    {
                        animState.Enabled = true;
                        animState.Weight = 1f;
                        animState.Loop = true;
                        animState.TimePosition = 0f;

                        SetActiveAnimationTimePos(0);
                    }
                    else
                    {
                        animState.Enabled = false;
                    }
                }
            }
        }

        public void SetActiveAnimationTimePos(float fTime)
        {
            if (HasModelEntity && ModelEntity.HasSkeleton)
            {
                ModelEntity.Skeleton.Reset();
                AnimationStateIterator animationStateIterator = ModelEntity.AllAnimationStates.GetAnimationStateIterator();
                do
                {
                    if ((animationStateIterator.Current != null) && animationStateIterator.Current.Enabled)
                    {
                        animationStateIterator.Current.TimePosition = fTime;
                    }
                }
                while (animationStateIterator.MoveNext());
            }
        }


        public void UpdateAnimation(float dt)
        {
            if (HasModelEntity && ModelEntity.HasSkeleton)
            {
                foreach (var anState in ModelEntity.AllAnimationStates.GetAnimationStateIterator())
                {
                    if ((anState != null) && anState.Enabled)
                    {
                        anState.TimePosition += dt;
                    }
                }
            }
        }

        public float GetActiveAnimationDuration()
        {
            if (HasModelEntity && ModelEntity.HasSkeleton)
            {
                ModelEntity.Skeleton.Reset();
                foreach (var anState in ModelEntity.AllAnimationStates.GetAnimationStateIterator())
                {
                    if ((anState != null) && anState.Enabled)
                    {
                        if (!float.IsNaN(anState.Length))
                        {
                            return anState.Length;
                        }
                        return 0f;
                    }
                }
            }
            return 0f;
        }

        public float GetActiveAnimationPos()
        {
            if (HasModelEntity && ModelEntity.HasSkeleton)
            {
                ModelEntity.Skeleton.Reset();
                foreach (var anState in ModelEntity.AllAnimationStates.GetAnimationStateIterator())
                {
                    if ((anState != null) && anState.Enabled)
                    {
                        if (!float.IsNaN(anState.TimePosition))
                        {
                            return anState.TimePosition;
                        }
                        return 0f;
                    }
                }
            }
            return 0f;
        }

        private void SetInitialCamera(Entity ent, SceneNode node)
        {
            var sphRad = ent.BoundingRadius;
            camera.Position = new Vector3(node.Position.x, node.Position.y + sphRad * 1.5f, node.Position.z + sphRad * 2.5f);
            camera.LookAt(node.Position.x, node.Position.y + sphRad / 2, node.Position.z);

            ModelCenterPosition = new Vector3(node.Position.x, node.Position.y + sphRad / 2, node.Position.z);
        }

        public void Paint()
        {
            root.RenderOneFrame();
        }

        public void Dispose()
        {
            if (root != null)
            {
                root.Dispose();
                root = null;
            }
        }

        public string TakeScreenshot(string theFolderPath)
        {
            if (HasModelEntity)
            {
                mainGrid.FlipVisibility();
                root.RenderOneFrame();
                //string fileToWrite = ModelEntity.Name + ".jpg";
                //string path = Path.Combine(theFolderPath, fileToWrite);
                viewport.Target.WriteContentsToFile(theFolderPath);
                mainGrid.FlipVisibility();
                return theFolderPath;
            }
            else
                return null;
        }

        void AddResourcesDirectory(string theTileSet, string thePath)
        {
            ResourceGroupManager.Singleton.AddResourceLocation(thePath, "FileSystem", theTileSet);

            if (ResourceGroupManager.Singleton.IsResourceGroupInitialised(theTileSet))
            {
                // reload
                ResourceGroupManager.Singleton.ClearResourceGroup(theTileSet);
                ResourceGroupManager.Singleton.InitialiseResourceGroup(theTileSet);
            }
            else
            {
                ResourceGroupManager.Singleton.InitialiseResourceGroup(theTileSet);
            }
        }

        ManualObject CreateGrid(SceneManager theSceneMng, float theWidth, float theStep, string theName)
        {
            float halfW = theWidth / 2f;

            // create material (colour)
            MaterialPtr moMaterial = MaterialManager.Singleton.Create("line_material", "General");
            moMaterial.ReceiveShadows = false;
            moMaterial.GetTechnique(0).SetLightingEnabled(true);
            moMaterial.GetTechnique(0).GetPass(0).SetDiffuse(0.1f, 0.1f, 0.1f, 0);
            moMaterial.GetTechnique(0).GetPass(0).SetAmbient(0.1f, 0.1f, 0.1f);
            moMaterial.GetTechnique(0).GetPass(0).SetSelfIllumination(0.1f, 0.1f, 0.1f);
            moMaterial.Dispose();  // dispose pointer, not the material

            // create line object
            ManualObject manOb = theSceneMng.CreateManualObject("line_" + theName);

            // X lines
            for (float x = -halfW; x <= halfW; x += theStep)
            {
                // draw line               
                manOb.Begin("line_material", RenderOperation.OperationTypes.OT_LINE_LIST);
                manOb.Position(x, 0, -halfW);
                manOb.Position(x, 0, halfW);
                manOb.End();
            }

            // Z lines
            for (float z = -halfW; z <= halfW; z += theStep)
            {
                // draw line                
                manOb.Begin("line_material", RenderOperation.OperationTypes.OT_LINE_LIST);
                manOb.Position(-halfW, 0, z);
                manOb.Position(halfW, 0, z);
                manOb.End();
            }

            return manOb;
        }

    }
}
