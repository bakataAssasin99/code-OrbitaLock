namespace DWord
{
    partial class DWordLock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DWordLock));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.cboComPort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Software = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnEndSession = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(7, 105);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(347, 25);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "1. Chọn đường dẫn tới thư mục khóa từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DB Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(91, 15);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(233, 22);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = ".\\sqlexpress";
            // 
            // cboComPort
            // 
            this.cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComPort.FormattingEnabled = true;
            this.cboComPort.Items.AddRange(new object[] {
            "USB",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.cboComPort.Location = new System.Drawing.Point(333, 57);
            this.cboComPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(113, 24);
            this.cboComPort.TabIndex = 0;
            this.cboComPort.SelectedIndexChanged += new System.EventHandler(this.cboComPort_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port";
            // 
            // Software
            // 
            this.Software.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Software.FormattingEnabled = true;
            this.Software.Items.AddRange(new object[] {
            "MHS",
            "THS"});
            this.Software.Location = new System.Drawing.Point(91, 52);
            this.Software.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Software.Name = "Software";
            this.Software.Size = new System.Drawing.Size(132, 24);
            this.Software.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "SW";
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInit.Location = new System.Drawing.Point(472, 16);
            this.btnInit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(143, 28);
            this.btnInit.TabIndex = 12;
            this.btnInit.Text = "Start Session";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnEndSession
            // 
            this.btnEndSession.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEndSession.Location = new System.Drawing.Point(472, 58);
            this.btnEndSession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEndSession.Name = "btnEndSession";
            this.btnEndSession.Size = new System.Drawing.Size(143, 28);
            this.btnEndSession.TabIndex = 13;
            this.btnEndSession.Text = "End Session";
            this.btnEndSession.UseVisualStyleBackColor = false;
            this.btnEndSession.Click += new System.EventHandler(this.btnEndSession_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Đường dẫn file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_SelectFolder);
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.ForeColor = System.Drawing.Color.Red;
            this.LabelStatus.Location = new System.Drawing.Point(7, 134);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(199, 25);
            this.LabelStatus.TabIndex = 15;
            this.LabelStatus.Text = "2. Click start Session ";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(472, 94);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(143, 28);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete Card";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DWordLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 170);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Software);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnEndSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.cboComPort);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1022, 286);
            this.Name = "DWordLock";
            this.Text = "Link";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.ComboBox cboComPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Software;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnEndSession;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Button btnDelete;
    }
}

