namespace DWord.View
{
    partial class ArchieLock
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Software = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboComPort = new System.Windows.Forms.NumericUpDown();
            this.btnEndSession = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cboComPort)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Đường dẫn file";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(76, 20);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(176, 20);
            this.txtServer.TabIndex = 16;
            this.txtServer.Text = ".\\sqlexpress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "DB Server";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(356, 86);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 23);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete Card";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(13, 87);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(283, 20);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "1. Chọn đường dẫn tới thư mục khóa từ";
            // 
            // btnInit
            // 
            this.btnInit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInit.Location = new System.Drawing.Point(356, 20);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(107, 23);
            this.btnInit.TabIndex = 22;
            this.btnInit.Text = "Start Session";
            this.btnInit.UseVisualStyleBackColor = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "SW";
            // 
            // Software
            // 
            this.Software.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Software.FormattingEnabled = true;
            this.Software.Items.AddRange(new object[] {
            "9600",
            "19200",
            "28800",
            "38400",
            "48000",
            "57600",
            "115200"});
            this.Software.Location = new System.Drawing.Point(76, 54);
            this.Software.Name = "Software";
            this.Software.Size = new System.Drawing.Size(100, 21);
            this.Software.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Port";
            // 
            // cboComPort
            // 
            this.cboComPort.Location = new System.Drawing.Point(257, 57);
            this.cboComPort.Margin = new System.Windows.Forms.Padding(2);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(86, 20);
            this.cboComPort.TabIndex = 27;
            // 
            // btnEndSession
            // 
            this.btnEndSession.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEndSession.Location = new System.Drawing.Point(356, 54);
            this.btnEndSession.Name = "btnEndSession";
            this.btnEndSession.Size = new System.Drawing.Size(107, 23);
            this.btnEndSession.TabIndex = 23;
            this.btnEndSession.Text = "End Session";
            this.btnEndSession.UseVisualStyleBackColor = false;
            // 
            // ArchieLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 138);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Software);
            this.Controls.Add(this.cboComPort);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEndSession);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ArchieLock";
            this.Text = "ArchieLock";
            ((System.ComponentModel.ISupportInitialize)(this.cboComPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Software;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cboComPort;
        private System.Windows.Forms.Button btnEndSession;
    }
}