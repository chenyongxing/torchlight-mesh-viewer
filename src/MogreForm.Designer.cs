namespace Mogre.Demo.MogreForm
{
    partial class MogreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MogreForm));
            this.mogrePanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.browserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wardrobeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.faceBodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bootsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.glovesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shouldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unequipAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.toLeftHandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonReset = new System.Windows.Forms.Button();
            this.checkBoxRotate = new System.Windows.Forms.CheckBox();
            this.listBoxAnimations = new System.Windows.Forms.ListBox();
            this.buttonPlayStop = new System.Windows.Forms.Button();
            this.trackBarRotateSpeed = new System.Windows.Forms.TrackBar();
            this.trackBarAnimPosition = new System.Windows.Forms.TrackBar();
            this.timerRender = new System.Windows.Forms.Timer(this.components);
            this.buttonReload = new System.Windows.Forms.Button();
            this.toRightHandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toLeftArmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadAllEquipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotateSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // mogrePanel
            // 
            this.mogrePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mogrePanel.Location = new System.Drawing.Point(12, 29);
            this.mogrePanel.Name = "mogrePanel";
            this.mogrePanel.Size = new System.Drawing.Size(640, 480);
            this.mogrePanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.wardrobeToolStripMenuItem,
            this.equipToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveScreenshotToolStripMenuItem,
            this.toolStripMenuItem1,
            this.browserToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveScreenshotToolStripMenuItem
            // 
            this.saveScreenshotToolStripMenuItem.Name = "saveScreenshotToolStripMenuItem";
            this.saveScreenshotToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.saveScreenshotToolStripMenuItem.Text = "Save Screenshot";
            this.saveScreenshotToolStripMenuItem.Click += new System.EventHandler(this.saveScreenshotToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // browserToolStripMenuItem
            // 
            this.browserToolStripMenuItem.CheckOnClick = true;
            this.browserToolStripMenuItem.Name = "browserToolStripMenuItem";
            this.browserToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.browserToolStripMenuItem.Text = "Browser";
            this.browserToolStripMenuItem.CheckedChanged += new System.EventHandler(this.browserToolStripMenuItem_CheckedChanged);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // wardrobeToolStripMenuItem
            // 
            this.wardrobeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.faceBodyToolStripMenuItem,
            this.bootsToolStripMenuItem,
            this.chestToolStripMenuItem,
            this.glovesToolStripMenuItem,
            this.helmToolStripMenuItem,
            this.shouldersToolStripMenuItem});
            this.wardrobeToolStripMenuItem.Name = "wardrobeToolStripMenuItem";
            this.wardrobeToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.wardrobeToolStripMenuItem.Text = "Wardrobe";
            // 
            // reloadAllToolStripMenuItem
            // 
            this.reloadAllToolStripMenuItem.Name = "reloadAllToolStripMenuItem";
            this.reloadAllToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.reloadAllToolStripMenuItem.Text = "Reload all textures";
            this.reloadAllToolStripMenuItem.Click += new System.EventHandler(this.reloadAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // faceBodyToolStripMenuItem
            // 
            this.faceBodyToolStripMenuItem.Name = "faceBodyToolStripMenuItem";
            this.faceBodyToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.faceBodyToolStripMenuItem.Text = "Face/Body...";
            this.faceBodyToolStripMenuItem.Click += new System.EventHandler(this.faceBodyToolStripMenuItem_Click);
            // 
            // bootsToolStripMenuItem
            // 
            this.bootsToolStripMenuItem.Name = "bootsToolStripMenuItem";
            this.bootsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.bootsToolStripMenuItem.Text = "Boots...";
            this.bootsToolStripMenuItem.Click += new System.EventHandler(this.bootsToolStripMenuItem_Click);
            // 
            // chestToolStripMenuItem
            // 
            this.chestToolStripMenuItem.Name = "chestToolStripMenuItem";
            this.chestToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.chestToolStripMenuItem.Text = "Chest...";
            this.chestToolStripMenuItem.Click += new System.EventHandler(this.chestToolStripMenuItem_Click);
            // 
            // glovesToolStripMenuItem
            // 
            this.glovesToolStripMenuItem.Name = "glovesToolStripMenuItem";
            this.glovesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.glovesToolStripMenuItem.Text = "Gloves...";
            this.glovesToolStripMenuItem.Click += new System.EventHandler(this.glovesToolStripMenuItem_Click);
            // 
            // helmToolStripMenuItem
            // 
            this.helmToolStripMenuItem.Name = "helmToolStripMenuItem";
            this.helmToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.helmToolStripMenuItem.Text = "Helmet...";
            this.helmToolStripMenuItem.Click += new System.EventHandler(this.helmToolStripMenuItem_Click);
            // 
            // shouldersToolStripMenuItem
            // 
            this.shouldersToolStripMenuItem.Name = "shouldersToolStripMenuItem";
            this.shouldersToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.shouldersToolStripMenuItem.Text = "Shoulders...";
            this.shouldersToolStripMenuItem.Click += new System.EventHandler(this.shouldersToolStripMenuItem_Click);
            // 
            // equipToolStripMenuItem
            // 
            this.equipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadAllEquipsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.toLeftHandToolStripMenuItem,
            this.toRightHandToolStripMenuItem,
            this.toLeftArmToolStripMenuItem,
            this.toolStripMenuItem4,
            this.unequipAllToolStripMenuItem});
            this.equipToolStripMenuItem.Name = "equipToolStripMenuItem";
            this.equipToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.equipToolStripMenuItem.Text = "Equip";
            // 
            // unequipAllToolStripMenuItem
            // 
            this.unequipAllToolStripMenuItem.Name = "unequipAllToolStripMenuItem";
            this.unequipAllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.unequipAllToolStripMenuItem.Text = "Unequip all";
            this.unequipAllToolStripMenuItem.Click += new System.EventHandler(this.unequipAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(162, 6);
            // 
            // toLeftHandToolStripMenuItem
            // 
            this.toLeftHandToolStripMenuItem.Name = "toLeftHandToolStripMenuItem";
            this.toLeftHandToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.toLeftHandToolStripMenuItem.Text = "to Left Hand...";
            this.toLeftHandToolStripMenuItem.Click += new System.EventHandler(this.toLeftHandToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Location = new System.Drawing.Point(658, 29);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(140, 24);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset camera";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // checkBoxRotate
            // 
            this.checkBoxRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRotate.AutoSize = true;
            this.checkBoxRotate.Location = new System.Drawing.Point(674, 87);
            this.checkBoxRotate.Name = "checkBoxRotate";
            this.checkBoxRotate.Size = new System.Drawing.Size(108, 17);
            this.checkBoxRotate.TabIndex = 4;
            this.checkBoxRotate.Text = "auto rotate model";
            this.checkBoxRotate.UseVisualStyleBackColor = true;
            this.checkBoxRotate.CheckedChanged += new System.EventHandler(this.checkBoxRotate_CheckedChanged);
            // 
            // listBoxAnimations
            // 
            this.listBoxAnimations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAnimations.FormattingEnabled = true;
            this.listBoxAnimations.Location = new System.Drawing.Point(658, 134);
            this.listBoxAnimations.Name = "listBoxAnimations";
            this.listBoxAnimations.Size = new System.Drawing.Size(140, 303);
            this.listBoxAnimations.TabIndex = 5;
            this.listBoxAnimations.SelectedIndexChanged += new System.EventHandler(this.listBoxAnimations_SelectedIndexChanged);
            this.listBoxAnimations.MouseEnter += new System.EventHandler(this.listBoxAnimations_MouseEnter);
            this.listBoxAnimations.MouseLeave += new System.EventHandler(this.listBoxAnimations_MouseLeave);
            // 
            // buttonPlayStop
            // 
            this.buttonPlayStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlayStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayStop.Location = new System.Drawing.Point(658, 445);
            this.buttonPlayStop.Name = "buttonPlayStop";
            this.buttonPlayStop.Size = new System.Drawing.Size(140, 37);
            this.buttonPlayStop.TabIndex = 6;
            this.buttonPlayStop.Text = "Play";
            this.buttonPlayStop.UseVisualStyleBackColor = true;
            this.buttonPlayStop.Click += new System.EventHandler(this.buttonPlayStop_Click);
            // 
            // trackBarRotateSpeed
            // 
            this.trackBarRotateSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarRotateSpeed.AutoSize = false;
            this.trackBarRotateSpeed.Location = new System.Drawing.Point(658, 107);
            this.trackBarRotateSpeed.Maximum = 60;
            this.trackBarRotateSpeed.Name = "trackBarRotateSpeed";
            this.trackBarRotateSpeed.Size = new System.Drawing.Size(140, 26);
            this.trackBarRotateSpeed.TabIndex = 7;
            this.trackBarRotateSpeed.TickFrequency = 0;
            this.trackBarRotateSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRotateSpeed.ValueChanged += new System.EventHandler(this.trackBarRotateSpeed_ValueChanged);
            // 
            // trackBarAnimPosition
            // 
            this.trackBarAnimPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarAnimPosition.Location = new System.Drawing.Point(658, 488);
            this.trackBarAnimPosition.Maximum = 1000;
            this.trackBarAnimPosition.Name = "trackBarAnimPosition";
            this.trackBarAnimPosition.Size = new System.Drawing.Size(140, 45);
            this.trackBarAnimPosition.TabIndex = 8;
            this.trackBarAnimPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarAnimPosition.ValueChanged += new System.EventHandler(this.trackBarAnimPosition_ValueChanged);
            // 
            // timerRender
            // 
            this.timerRender.Enabled = true;
            this.timerRender.Interval = 20;
            this.timerRender.Tick += new System.EventHandler(this.timerRender_Tick);
            // 
            // buttonReload
            // 
            this.buttonReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReload.Location = new System.Drawing.Point(658, 58);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(140, 23);
            this.buttonReload.TabIndex = 9;
            this.buttonReload.Text = "Reload original";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // toRightHandToolStripMenuItem
            // 
            this.toRightHandToolStripMenuItem.Name = "toRightHandToolStripMenuItem";
            this.toRightHandToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.toRightHandToolStripMenuItem.Text = "to Right Hand...";
            this.toRightHandToolStripMenuItem.Click += new System.EventHandler(this.toRightHandToolStripMenuItem_Click);
            // 
            // toLeftArmToolStripMenuItem
            // 
            this.toLeftArmToolStripMenuItem.Name = "toLeftArmToolStripMenuItem";
            this.toLeftArmToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.toLeftArmToolStripMenuItem.Text = "to Left Arm...";
            this.toLeftArmToolStripMenuItem.Click += new System.EventHandler(this.toLeftArmToolStripMenuItem_Click);
            // 
            // reloadAllEquipsToolStripMenuItem
            // 
            this.reloadAllEquipsToolStripMenuItem.Name = "reloadAllEquipsToolStripMenuItem";
            this.reloadAllEquipsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.reloadAllEquipsToolStripMenuItem.Text = "Reload all equips";
            this.reloadAllEquipsToolStripMenuItem.Click += new System.EventHandler(this.reloadAllEquipsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(162, 6);
            // 
            // MogreForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 519);
            this.Controls.Add(this.buttonReload);
            this.Controls.Add(this.trackBarAnimPosition);
            this.Controls.Add(this.trackBarRotateSpeed);
            this.Controls.Add(this.buttonPlayStop);
            this.Controls.Add(this.listBoxAnimations);
            this.Controls.Add(this.checkBoxRotate);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.mogrePanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MogreForm";
            this.Text = "Torchlight Mesh Viewer";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MogreForm_Paint);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MogreForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MogreForm_DragEnter);
            this.Resize += new System.EventHandler(this.MogreForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotateSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mogrePanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.CheckBox checkBoxRotate;
        private System.Windows.Forms.ListBox listBoxAnimations;
        private System.Windows.Forms.Button buttonPlayStop;
        private System.Windows.Forms.TrackBar trackBarRotateSpeed;
        private System.Windows.Forms.TrackBar trackBarAnimPosition;
        private System.Windows.Forms.Timer timerRender;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.ToolStripMenuItem wardrobeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bootsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem glovesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shouldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faceBodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reloadAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveScreenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem equipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toLeftHandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unequipAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toRightHandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toLeftArmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadAllEquipsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;

    }
}

