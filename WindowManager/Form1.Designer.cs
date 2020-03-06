namespace WindowManager
{
    partial class Form1
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
            this.lsb_Windows = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_AddWnd = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.tmr_UserIdle = new System.Windows.Forms.Timer(this.components);
            this.lbl_Status = new System.Windows.Forms.Label();
            this.lbl_WndCnt = new System.Windows.Forms.Label();
            this.tmr_LateUpdate = new System.Windows.Forms.Timer(this.components);
            this.cbx_Auto = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsb_Windows
            // 
            this.lsb_Windows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsb_Windows.FormattingEnabled = true;
            this.lsb_Windows.Location = new System.Drawing.Point(12, 33);
            this.lsb_Windows.Name = "lsb_Windows";
            this.lsb_Windows.Size = new System.Drawing.Size(443, 264);
            this.lsb_Windows.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(467, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.mi_AddWnd});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // mi_AddWnd
            // 
            this.mi_AddWnd.Name = "mi_AddWnd";
            this.mi_AddWnd.Size = new System.Drawing.Size(143, 22);
            this.mi_AddWnd.Text = "Add Window";
            this.mi_AddWnd.Click += new System.EventHandler(this.mi_AddWnd_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Location = new System.Drawing.Point(379, 315);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Update.Location = new System.Drawing.Point(298, 314);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 23);
            this.btn_Update.TabIndex = 5;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // tmr_UserIdle
            // 
            this.tmr_UserIdle.Enabled = true;
            this.tmr_UserIdle.Interval = 1000;
            this.tmr_UserIdle.Tick += new System.EventHandler(this.tmr_UserIdle_Tick);
            // 
            // lbl_Status
            // 
            this.lbl_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Location = new System.Drawing.Point(16, 324);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(37, 13);
            this.lbl_Status.TabIndex = 6;
            this.lbl_Status.Text = "Status";
            // 
            // lbl_WndCnt
            // 
            this.lbl_WndCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_WndCnt.AutoSize = true;
            this.lbl_WndCnt.Location = new System.Drawing.Point(16, 304);
            this.lbl_WndCnt.Name = "lbl_WndCnt";
            this.lbl_WndCnt.Size = new System.Drawing.Size(77, 13);
            this.lbl_WndCnt.TabIndex = 7;
            this.lbl_WndCnt.Text = "Window Count";
            // 
            // tmr_LateUpdate
            // 
            this.tmr_LateUpdate.Interval = 15000;
            this.tmr_LateUpdate.Tick += new System.EventHandler(this.tmr_LateUpdate_Tick);
            // 
            // cbx_Auto
            // 
            this.cbx_Auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_Auto.AutoSize = true;
            this.cbx_Auto.Location = new System.Drawing.Point(161, 300);
            this.cbx_Auto.Name = "cbx_Auto";
            this.cbx_Auto.Size = new System.Drawing.Size(48, 17);
            this.cbx_Auto.TabIndex = 8;
            this.cbx_Auto.Text = "Auto";
            this.cbx_Auto.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 350);
            this.Controls.Add(this.cbx_Auto);
            this.Controls.Add(this.lbl_WndCnt);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lsb_Windows);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Window Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsb_Windows;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Timer tmr_UserIdle;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label lbl_WndCnt;
        private System.Windows.Forms.ToolStripMenuItem mi_AddWnd;
        private System.Windows.Forms.Timer tmr_LateUpdate;
        private System.Windows.Forms.CheckBox cbx_Auto;
    }
}

