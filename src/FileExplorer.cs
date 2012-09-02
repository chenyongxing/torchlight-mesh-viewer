using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace Mogre.Demo.MogreForm
{
    class FileExplorer
    {
        const int ICON_FOLDER = 0;
        const int ICON_MESH = 1;

        public FileExplorer()
        {

        }

        /* Method :CreateTree
         * Author : Chandana Subasinghe
         * Date   : 10/03/2006
         * Discription : This is use to creat and build the tree
         *          
         */

        public bool CreateTree(TreeView treeView)
        {
            bool returnValue = false;

            try
            {
                // Create Desktop
                TreeNode desktop = new TreeNode();
                desktop.Text = "Desktop";
                desktop.Tag = "Desktop";
                desktop.Nodes.Add("");
                treeView.Nodes.Add(desktop);
                // Get driveInfo
                foreach (DriveInfo drv in DriveInfo.GetDrives())
                {

                    TreeNode fChild = new TreeNode();
                    if (drv.DriveType == DriveType.CDRom)
                    {
                        fChild.ImageIndex = ICON_FOLDER;
                        fChild.SelectedImageIndex = ICON_FOLDER;
                    }
                    else if (drv.DriveType == DriveType.Fixed)
                    {
                        fChild.ImageIndex = ICON_FOLDER;
                        fChild.SelectedImageIndex = ICON_FOLDER;
                    }
                    fChild.Text = drv.Name;
                    fChild.Nodes.Add("");
                    treeView.Nodes.Add(fChild);
                    returnValue = true;
                }

            }
            catch (Exception ex)
            {
                returnValue = false;
            }
            return returnValue;

        }

        /* Method :EnumerateDirectory
         * Author : Chandana Subasinghe
         * Date   : 10/03/2006
         * Discription : This is use to Enumerate directories and files
         *          
         */
        public TreeNode EnumerateDirectory(TreeNode parentNode)
        {

            try
            {
                DirectoryInfo rootDir;

                // To fill Desktop
                Char[] arr = { '\\' };
                string[] nameList = parentNode.FullPath.Split(arr);
                string path = "";

                if (nameList.GetValue(0).ToString() == "Desktop")
                {
                    path = SpecialDirectories.Desktop + "\\";

                    for (int i = 1; i < nameList.Length; i++)
                    {
                        path = path + nameList[i] + "\\";
                    }

                    rootDir = new DirectoryInfo(path);
                }
                // for other Directories
                else
                {

                    rootDir = new DirectoryInfo(parentNode.FullPath + "\\");
                }

                parentNode.Nodes[0].Remove();
                foreach (DirectoryInfo dir in rootDir.GetDirectories())
                {

                    TreeNode node = new TreeNode();
                    node.Text = dir.Name;
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }
                //Fill files
                foreach (FileInfo file in rootDir.GetFiles())
                {
                    // TODO: simple filtering for mesh
                    if (file.Name.ToLower().EndsWith(".mesh"))
                    {
                        TreeNode node = new TreeNode();
                        node.Text = file.Name;
                        node.Tag = file.FullName;
                        node.ImageIndex = ICON_MESH;
                        node.SelectedImageIndex = ICON_MESH;
                        parentNode.Nodes.Add(node);
                    }
                }

            }

            catch (Exception ex)
            {
                //TODO : 
            }

            return parentNode;
        }
    }

}
