using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mogre.Demo.MogreForm
{
    public partial class Browser : Form
    {
        FileExplorer fe = new FileExplorer();
        MogreForm ParentForm { get; set; }

        bool Expanding { get; set; }
        bool Collapsing { get; set; }

        public string SelectedModel { get; private set; }

        public Browser(MogreForm parent)
        {
            ParentForm = parent;
            SelectedModel = string.Empty;
            InitializeComponent();
        }

        public void SelectNodeForPath(string thePath)
        {
            // extract whole path
            var pathNodes = thePath.Split(Path.DirectorySeparatorChar);
            string fileNode = pathNodes[pathNodes.Length - 1];

            var treeNodes = treeViewBrowser.Nodes;
            TreeNode nodeParse=null;
            foreach(string pNode in pathNodes)
            {                
                nodeParse = GetNodeWithName(pNode, treeNodes);
                if (pNode == fileNode) break;

                var resNode = fe.EnumerateDirectory(nodeParse);
                treeNodes = resNode.Nodes;
            }

            treeViewBrowser.SelectedNode = nodeParse;
            //nodeParse.se
        }

        public TreeNode GetNodeWithName(string theName, TreeNodeCollection theNodes)
        {
            foreach (TreeNode node in theNodes)
            {
                if (node.Text.Trim(Path.DirectorySeparatorChar).CompareTo(theName) == 0)
                    return node;
            }

            return null;
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            // Create file tree            
            fe.CreateTree(this.treeViewBrowser);
        }

        private void treeViewBrowser_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Expanding = true;
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode node = fe.EnumerateDirectory(e.Node);
            }
        }

        private void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ParentForm.HideBrowser();
                e.Cancel = true; // this cancels the close event.
            }
        }

        private void treeViewBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.ToLower().EndsWith(".mesh"))
            {
                SelectedModel = (string)e.Node.Tag;
                ParentForm.SetMeshModel(SelectedModel, true);                
            }            
        }

        private void treeViewBrowser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!e.Node.Text.ToLower().EndsWith(".mesh") && Expanding == false && Collapsing == false)                
            {
                if (e.Node.IsExpanded)
                    e.Node.Collapse();
                else
                    e.Node.Expand();
            }
            Expanding = false;
            Collapsing = false;
        }

        private void treeViewBrowser_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //Expanding = false;
        }

        private void treeViewBrowser_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            Collapsing = true;
        }

        private void treeViewBrowser_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            //Collapsing = false;
        }
    }
}
