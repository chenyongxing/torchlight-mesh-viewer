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
    public partial class MogreForm : Form
    {
        protected OgreWindow mogreWin;
        CustomInputHandler inputHandler;

        string myCurrentModel;
        bool myIsPlaying = false;

        // Keep track of the message filter
        private RedirectMessageFilter myMessageFilterKeyUp = null;
        private RedirectMessageFilter myMessageFilterKeyDown = null;
        private RedirectMessageFilter myMessageFilterMouseWheel = null;

        public MogreForm(string theMesh)
        {
            InitializeComponent();
            this.Disposed += new EventHandler(MogreForm_Disposed);

            Directory.SetCurrentDirectory(Application.StartupPath);

            listBoxAnimations.Visible = false;
            buttonPlayStop.Visible = false;
            trackBarAnimPosition.Visible = false;

            trackBarRotateSpeed.Visible = false;
            trackBarRotateSpeed.Value = 20;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            mogreWin = new OgreWindow(
                new Point(100, 30),
                new Size(mogrePanel.Height, mogrePanel.Width),
                mogrePanel.Handle);
            mogreWin.InitMogre();

            timerRender.Start();

            inputHandler = new CustomInputHandler(mogrePanel, this, mogreWin.camera);

            AddMessageFilter(this.Handle);

            this.Text = string.Format("{0} v{1} ({2})", AsmInfo.Title, AsmInfo.Version, AsmInfo.CompanyName);
            //mogreWin.SetViewModel(@"D:\stuff\Torchlight_modding\Greg\MeshViewer\media\HuM_Nude_mesh.MESH");
            mogreWin.SetGrid();
            if (!string.IsNullOrEmpty(theMesh))
            {
                SetMeshModel(theMesh);
            }
        }

        // Add filter to redirect to control with handle hWnd
        private void AddMessageFilter(IntPtr hWnd)
        {
            myMessageFilterKeyUp = new RedirectMessageFilter(WindowsMessages.WM_KEYUP, hWnd);
            myMessageFilterKeyDown = new RedirectMessageFilter(WindowsMessages.WM_KEYDOWN, hWnd);
            myMessageFilterMouseWheel = new RedirectMessageFilter(WindowsMessages.WM_MOUSEWHEEL, hWnd);
            Application.AddMessageFilter(myMessageFilterKeyUp);
            Application.AddMessageFilter(myMessageFilterKeyDown);
            //Application.AddMessageFilter(myMessageFilterMouseWheel);
        }

        //public void Go()
        //{            
        //    base.Show();
        //    bool flag = true;
        //    while (flag && (mogreWin.root != null))
        //    {

        //        if ((DateTime.Now.Ticks - lastUpdate) > maxDelay)
        //        {
        //            lastUpdate = DateTime.Now.Ticks;

        //            float activeAnimationPos = mogreWin.GetActiveAnimationPos();
        //            int num2 = (int)System.Math.Max((float)(100f * activeAnimationPos), (float)0f);
        //            num2 = System.Math.Min(trackBarAnimPosition.Maximum, num2);
        //            trackBarAnimPosition.Value = num2;


        //            flag = mogreWin.root.RenderOneFrame();
        //            Application.DoEvents();
        //        }
                
        //    }
        //}

        private void MogreForm_Paint(object sender, PaintEventArgs e)
        {
            mogreWin.Paint();
        }

        void MogreForm_Disposed(object sender, EventArgs e)
        {
            mogreWin.Dispose();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a image.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Mesh file (*.mesh)|*.mesh|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a mesh";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            // Show the Dialog.            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SetMeshModel(openFileDialog1.FileName);                
            }
            this.Refresh();
        }

        private void SetMeshModel(string theMesh)
        {
            try
            {
                myCurrentModel = theMesh;
                var anims = mogreWin.SetViewModel(theMesh);
                inputHandler.ModelPosition = mogreWin.ModelCenterPosition;

                this.Text = string.Format("{0} {1} ({2})", AsmInfo.Title, AsmInfo.Version, theMesh);

                if (anims.Count > 0)
                {
                    listBoxAnimations.Visible = true;
                    buttonPlayStop.Visible = true;
                    trackBarAnimPosition.Visible = true;

                    listBoxAnimations.Items.Clear();
                    foreach (var an in anims)
                    {
                        listBoxAnimations.Items.Add(an);
                    }
                }
                
                ReloadWardrobe();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Exception: {0} \nCheck Ogre.log for details.", e.Message), "Error viewing model", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckWardrobe()
        {
                        
            foreach (Wardrobe suit in Enum.GetValues(typeof(Wardrobe)))
            {
                foreach (var it in wardrobeToolStripMenuItem.DropDownItems)
                {
                    string suitStr = suit.ToString();
                    var toolItem = (ToolStripItem)it;
                    if (toolItem.Text.IndexOf(suitStr, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        toolItem.Text = string.Format("{0}({1})...", suitStr,
                            Path.GetFileName(mogreWin.WardrobeTextures[(int)suit]));
                    }
                }
            }
            
        }
                
        private void MogreForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void MogreForm_DragDrop(object sender, DragEventArgs e)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                        
            if (fileList.Length > 0)
            {
                SetMeshModel(fileList[0]);
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutInfo().ShowDialog();
        }

        private void checkBoxRotate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRotate.Checked)
            {
                trackBarRotateSpeed.Visible = true;
                mogreWin.AutoRotateModel = true;
            }
            else
            {
                trackBarRotateSpeed.Visible = false;
                mogreWin.AutoRotateModel = false;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {            
            mogreWin.Reset();
        }

        private void buttonPlayStop_Click(object sender, EventArgs e)
        {
            if (myIsPlaying)
            {
                myIsPlaying = false;
                // stop
                buttonPlayStop.Text = "Play";
                mogreWin.Animate = false;
            }
            else
            {                
                if (listBoxAnimations.SelectedItem != null)
                {
                    myIsPlaying = true;

                    // playing
                    buttonPlayStop.Text = "Stop";

                    mogreWin.SetActiveAnimation((string)listBoxAnimations.SelectedItem);
                    mogreWin.Animate = true;
                }                                
            }
        }

        private void listBoxAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAnimations.SelectedItem != null)
            {
                mogreWin.SetActiveAnimation((string)listBoxAnimations.SelectedItem);

                trackBarAnimPosition.Maximum = (int)(mogreWin.GetActiveAnimationDuration() * 100f);
            }
        }

        private void trackBarRotateSpeed_ValueChanged(object sender, EventArgs e)
        {
            if(mogreWin!=null) mogreWin.AutoRotateSpeed = (float)trackBarRotateSpeed.Value / 10f;
        }

        private void listBoxAnimations_MouseEnter(object sender, EventArgs e)
        {
            Application.RemoveMessageFilter(myMessageFilterMouseWheel);
            myMessageFilterMouseWheel = new RedirectMessageFilter(WindowsMessages.WM_MOUSEWHEEL, listBoxAnimations.Handle);
            Application.AddMessageFilter(myMessageFilterMouseWheel);
        }

        private void listBoxAnimations_MouseLeave(object sender, EventArgs e)
        {
            Application.RemoveMessageFilter(myMessageFilterMouseWheel);            
            myMessageFilterMouseWheel = new RedirectMessageFilter(WindowsMessages.WM_MOUSEWHEEL, this.Handle);
            Application.AddMessageFilter(myMessageFilterMouseWheel);
        }

        private void trackBarAnimPosition_ValueChanged(object sender, EventArgs e)
        {
            if (mogreWin != null)
            {
                mogreWin.SetActiveAnimationTimePos(((float)this.trackBarAnimPosition.Value) / 100f);
                //this.textBoxFrame.Text = ((this.mogreWin.GetActiveAnimationPos() * this.mogreWin.GetActiveAnimationDuration()) * 30f).ToString("##.###");
            }
        }

        private void timerRender_Tick(object sender, EventArgs e)
        {
            //mogreWin.root.RenderOneFrame();
            mogreWin.Paint();

            float activeAnimationPos = mogreWin.GetActiveAnimationPos();
            int num2 = (int)System.Math.Max((float)(100f * activeAnimationPos), (float)0f);
            num2 = System.Math.Min(trackBarAnimPosition.Maximum, num2);
            trackBarAnimPosition.Value = num2;
        }

        private void MogreForm_Resize(object sender, EventArgs e)
        {
            if (mogreWin != null) mogreWin.Resize(mogrePanel.Width, mogrePanel.Height);
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(myCurrentModel))
            {
                var oldDir = mogreWin.camera.Direction;
                var oldPos = mogreWin.camera.Position;

                SetMeshModel(myCurrentModel);

                mogreWin.camera.Direction = oldDir;
                mogreWin.camera.Position = oldPos;
            }
        }

        private string GetTextureDialog()
        {
            // Displays an OpenFileDialog so the user can select a image.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Texture file (*.png)|*.png|Texture file (*.dds)|*.dds|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a texture";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = false;

            // Show the Dialog.            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            else return string.Empty;
        }

        private void faceBodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mogreWin.SetWardrobeTexture(Wardrobe.Face, GetTextureDialog());
            ReloadWardrobe(); // face, body is all the stuff that should be alphaed
        }

        private void bootsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mogreWin.SetWardrobeTexture(Wardrobe.Boots, GetTextureDialog());
            CheckWardrobe();
        }

        private void chestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mogreWin.SetWardrobeTexture(Wardrobe.Chest, GetTextureDialog());
            CheckWardrobe();
        }

        private void glovesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mogreWin.SetWardrobeTexture(Wardrobe.Gloves, GetTextureDialog());
            CheckWardrobe();
        }

        private void helmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mogreWin.SetWardrobeTexture(Wardrobe.Helmet, GetTextureDialog());
            CheckWardrobe();
        }

        private void shouldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mogreWin.SetWardrobeTexture(Wardrobe.Shoulders, GetTextureDialog());
            CheckWardrobe();
        }

        void ReloadWardrobe()
        {
            if (mogreWin.IsWardrobed)
            {
                wardrobeToolStripMenuItem.Enabled = true;

                mogreWin.SetWardrobeTexture(Wardrobe.Boots, mogreWin.WardrobeTextures[(int)Wardrobe.Boots]);
                mogreWin.SetWardrobeTexture(Wardrobe.Chest, mogreWin.WardrobeTextures[(int)Wardrobe.Chest]);
                mogreWin.SetWardrobeTexture(Wardrobe.Face, mogreWin.WardrobeTextures[(int)Wardrobe.Face]);
                mogreWin.SetWardrobeTexture(Wardrobe.Gloves, mogreWin.WardrobeTextures[(int)Wardrobe.Gloves]);
                mogreWin.SetWardrobeTexture(Wardrobe.Helmet, mogreWin.WardrobeTextures[(int)Wardrobe.Helmet]);
                mogreWin.SetWardrobeTexture(Wardrobe.Shoulders, mogreWin.WardrobeTextures[(int)Wardrobe.Shoulders]);

                CheckWardrobe();
            }            
            else
            {
                wardrobeToolStripMenuItem.Enabled = false;
            }
        }

        private void reloadAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadWardrobe();
        }          
    }
}


