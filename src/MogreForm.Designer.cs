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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click);
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

    }
}

