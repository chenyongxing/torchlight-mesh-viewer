# Viewing character wardrobe #

Shows how are character models and textures linked together and how to view wardrobe in viewer

## Introduction ##

With version 0.8.0.0 there is now possibility to view character's warbrobe. I assume you have TorchED installed, as it contains all the assets of TL in unpacked form.
Some general Torchlight knowledge:
  * all wardrobes (meshes, materials and textures) are stored in **...\TorchED\media\wardrobe\** folder
  * animations, base models and base texture is stored in **...\TorchED\media\models\** in folders **Vanquisher**, **warrior** (Destroyer) and **Alchemist**
  * items in TL are defined by **.dat** files (located in **...\TorchED\media\units\items\**
  * items you can wear are among these **.dat** files and contain entry for every character with link to wardrobe mesh and texture that should be used when item is equipped

## How to ##

As those links between wardrobes and meshes are done in TL **.dat** files, in viewer we have to manually assign what models and textures to view. Viewer searches for files inside the folder, and those files often contain link to other files, so it's best to copy relevant files into separate folder.
  * Say, we want to view buckled wardrobe for Vanquisher.
    1. First, create temporary folder (e.g. **D:\temp\vanq\_buckled\** - any folder will do, here I will use those for simplicity)
    1. Lets copy there all the relevant files. Go to folder **...\TorchED\media\wardrobe\** and to your temp folder copy files
      * **vanquisher\_buckled.material**
      * **vanquisher\_buckled.MESH**
      * **vanquisher\_buckled.SKELETON**
      * **vanquisher\_buckled\_helm.dds**
      * **vanquisher\_buckled\_shoulder.png**
      * **buckled\_boots.png**
      * **buckled\_chest.png**
      * **buckled\_gloves.png**
    1. Now go to folder **...\TorchED\media\models\** and copy file
      * **body.png**
    1. Now you can start TLMeshViewer and from your temp folder open file **vanquisher\_buckled.MESH** (you can associate .mesh files with viewer, or you can even drag&drop that file into viewer). You should see something like this:
      * ![http://www.dusho.net/_archiv/tl/meshviewer/wiki1sc1.jpg](http://www.dusho.net/_archiv/tl/meshviewer/wiki1sc1.jpg)
    1. Select to menu Wardrobe -> Face(none)... and now navigate to your temp folder and select **body.png**. Texture MUST be from same folder where it mesh is located. Your character will get a face
    1. Now choose Wardrobe -> Boots(none)... and select **buckled\_boots.png**
    1. Continue with Wardrobe -> Chest(none)... and select **buckled\_chest.png**
    1. And finally Gloves(none)... and select **buckled\_gloves.png**.
You now have your full wardrobe on character.
      * ![http://www.dusho.net/_archiv/tl/meshviewer/wiki1sc2.jpg](http://www.dusho.net/_archiv/tl/meshviewer/wiki1sc2.jpg)
Feel free to modify textures in your favorite graphic tool (Gimp, Paint.NET, Photoshop, ...) and use menu Wardrobe -> Reload all to immediately see changes on character