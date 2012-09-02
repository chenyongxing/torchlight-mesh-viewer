namespace Mogre.Demo.MogreForm
{
    partial class Browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.treeViewBrowser = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeViewBrowser
            // 
            this.treeViewBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewBrowser.ImageIndex = 0;
            this.treeViewBrowser.ImageList = this.imageList1;
            this.treeViewBrowser.Location = new System.Drawing.Point(12, 12);
            this.treeViewBrowser.Name = "treeViewBrowser";
            this.treeViewBrowser.SelectedImageIndex = 0;
            this.treeViewBrowser.Size = new System.Drawing.Size(218, 353);
            this.treeViewBrowser.TabIndex = 0;
            this.treeViewBrowser.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBrowser_AfterCollapse);
            this.treeViewBrowser.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewBrowser_BeforeExpand);
            this.treeViewBrowser.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewBrowser_BeforeCollapse);
            this.treeViewBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBrowser_AfterSelect);
            this.treeViewBrowser.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewBrowser_NodeMouseClick);
            this.treeViewBrowser.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBrowser_AfterExpand);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder16.png");
            this.imageList1.Images.SetKeyName(1, "icon16.png");
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 377);
            this.Controls.Add(this.treeViewBrowser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Browser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Browser_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewBrowser;
        private System.Windows.Forms.ImageList imageList1;
    }
}