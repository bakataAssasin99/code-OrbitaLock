namespace DWord.View
{
    partial class Home
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
            this.LockSystem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.PannelHome = new System.Windows.Forms.Panel();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.PannelHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // LockSystem
            // 
            this.LockSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LockSystem.FormattingEnabled = true;
            this.LockSystem.Items.AddRange(new object[] {
            "DWord",
            "ProUsb",
            "ProUsbNew",
            "ArchieLock",
            "AnLock",
            "HuneLock09",
            "ElockTemic",
            "NovaLock",
            "ProUsb 2010",
            "BTLock",
            "OrbitaLock"});
            this.LockSystem.Location = new System.Drawing.Point(541, 17);
            this.LockSystem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LockSystem.Name = "LockSystem";
            this.LockSystem.Size = new System.Drawing.Size(128, 24);
            this.LockSystem.TabIndex = 1;
            this.LockSystem.SelectedIndexChanged += new System.EventHandler(this.Software_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please choose system lock";
            // 
            // panelChildForm
            // 
            this.panelChildForm.Controls.Add(this.logo);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(0, 0);
            this.panelChildForm.Margin = new System.Windows.Forms.Padding(0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(687, 290);
            this.panelChildForm.TabIndex = 3;
            // 
            // logo
            // 
            this.logo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logo.BackgroundImage = global::DWord.Properties.Resources.ezCloudhotel;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logo.Image = global::DWord.Properties.Resources.ezCloud3;
            this.logo.Location = new System.Drawing.Point(83, 15);
            this.logo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(529, 203);
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PannelHome
            // 
            this.PannelHome.BackColor = System.Drawing.SystemColors.Control;
            this.PannelHome.Controls.Add(this.LockSystem);
            this.PannelHome.Controls.Add(this.label1);
            this.PannelHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PannelHome.Location = new System.Drawing.Point(0, 237);
            this.PannelHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PannelHome.Name = "PannelHome";
            this.PannelHome.Size = new System.Drawing.Size(687, 53);
            this.PannelHome.TabIndex = 4;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(687, 290);
            this.Controls.Add(this.PannelHome);
            this.Controls.Add(this.panelChildForm);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Home";
            this.ShowIcon = false;
            this.Text = "ezCloudLock";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panelChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.PannelHome.ResumeLayout(false);
            this.PannelHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox LockSystem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel PannelHome;
        private System.Windows.Forms.PictureBox logo;
    }
}