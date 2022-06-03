
namespace RFID_ReaderTest
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.btnWriteCardInfo = new System.Windows.Forms.Button();
            this.txtCardInfoToWrite = new System.Windows.Forms.TextBox();
            this.rfidTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtTerminal
            // 
            this.txtTerminal.Location = new System.Drawing.Point(589, 13);
            this.txtTerminal.Multiline = true;
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.Size = new System.Drawing.Size(606, 597);
            this.txtTerminal.TabIndex = 0;
            // 
            // btnWriteCardInfo
            // 
            this.btnWriteCardInfo.Location = new System.Drawing.Point(453, 570);
            this.btnWriteCardInfo.Name = "btnWriteCardInfo";
            this.btnWriteCardInfo.Size = new System.Drawing.Size(130, 40);
            this.btnWriteCardInfo.TabIndex = 1;
            this.btnWriteCardInfo.Text = "Write Card Info";
            this.btnWriteCardInfo.UseVisualStyleBackColor = true;
            this.btnWriteCardInfo.Click += new System.EventHandler(this.btnWriteCardInfo_Click);
            // 
            // txtCardInfoToWrite
            // 
            this.txtCardInfoToWrite.Location = new System.Drawing.Point(12, 13);
            this.txtCardInfoToWrite.Multiline = true;
            this.txtCardInfoToWrite.Name = "txtCardInfoToWrite";
            this.txtCardInfoToWrite.Size = new System.Drawing.Size(571, 551);
            this.txtCardInfoToWrite.TabIndex = 2;
            this.txtCardInfoToWrite.Text = resources.GetString("txtCardInfoToWrite.Text");
            // 
            // rfidTimer
            // 
            this.rfidTimer.Enabled = true;
            this.rfidTimer.Interval = 1000;
            this.rfidTimer.Tick += new System.EventHandler(this.rfidTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 622);
            this.Controls.Add(this.txtCardInfoToWrite);
            this.Controls.Add(this.btnWriteCardInfo);
            this.Controls.Add(this.txtTerminal);
            this.Name = "frmMain";
            this.Text = "Novatek RFID Reader test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTerminal;
        private System.Windows.Forms.Button btnWriteCardInfo;
        private System.Windows.Forms.TextBox txtCardInfoToWrite;
        private System.Windows.Forms.Timer rfidTimer;
    }
}

