namespace DWord.View
{
    partial class ProUsb
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
            this.btn_prousb_lock_folder = new System.Windows.Forms.Button();
            this.ProUsbServer = new System.Windows.Forms.TextBox();
            this.hotelCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_prousb_update_hotel_code = new System.Windows.Forms.Button();
            this.btn_prousb_delete_card = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textRoom = new System.Windows.Forms.TextBox();
            this.btn_prousb_read_card = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_prousb_lock_folder
            // 
            this.btn_prousb_lock_folder.Location = new System.Drawing.Point(332, 12);
            this.btn_prousb_lock_folder.Name = "btn_prousb_lock_folder";
            this.btn_prousb_lock_folder.Size = new System.Drawing.Size(162, 23);
            this.btn_prousb_lock_folder.TabIndex = 16;
            this.btn_prousb_lock_folder.Text = "Lock folder";
            this.btn_prousb_lock_folder.UseVisualStyleBackColor = true;
            this.btn_prousb_lock_folder.Click += new System.EventHandler(this.btn_prousb_lock_folder_Click);
            // 
            // ProUsbServer
            // 
            this.ProUsbServer.Location = new System.Drawing.Point(20, 12);
            this.ProUsbServer.Name = "ProUsbServer";
            this.ProUsbServer.Size = new System.Drawing.Size(295, 20);
            this.ProUsbServer.TabIndex = 15;
            this.ProUsbServer.Text = ".\\sqlexpress";
            // 
            // hotelCode
            // 
            this.hotelCode.AutoSize = true;
            this.hotelCode.Location = new System.Drawing.Point(85, 48);
            this.hotelCode.Name = "hotelCode";
            this.hotelCode.Size = new System.Drawing.Size(13, 13);
            this.hotelCode.TabIndex = 35;
            this.hotelCode.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "HotelCode:";
            // 
            // btn_prousb_update_hotel_code
            // 
            this.btn_prousb_update_hotel_code.Location = new System.Drawing.Point(332, 48);
            this.btn_prousb_update_hotel_code.Name = "btn_prousb_update_hotel_code";
            this.btn_prousb_update_hotel_code.Size = new System.Drawing.Size(162, 23);
            this.btn_prousb_update_hotel_code.TabIndex = 33;
            this.btn_prousb_update_hotel_code.Text = "Update Hotel Code";
            this.btn_prousb_update_hotel_code.UseVisualStyleBackColor = true;
            this.btn_prousb_update_hotel_code.Click += new System.EventHandler(this.btn_prousb_update_hotel_code_Click);
            // 
            // btn_prousb_delete_card
            // 
            this.btn_prousb_delete_card.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_prousb_delete_card.Location = new System.Drawing.Point(332, 109);
            this.btn_prousb_delete_card.Name = "btn_prousb_delete_card";
            this.btn_prousb_delete_card.Size = new System.Drawing.Size(162, 23);
            this.btn_prousb_delete_card.TabIndex = 39;
            this.btn_prousb_delete_card.Text = "Delete Card";
            this.btn_prousb_delete_card.UseVisualStyleBackColor = false;
            this.btn_prousb_delete_card.Visible = false;
            this.btn_prousb_delete_card.Click += new System.EventHandler(this.btn_prousb_delete_card_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(21, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(266, 20);
            this.lblStatus.TabIndex = 40;
            this.lblStatus.Text = "Chọn đường dẫn tới thư mục khóa từ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Room:";
            // 
            // textRoom
            // 
            this.textRoom.Location = new System.Drawing.Point(88, 80);
            this.textRoom.Name = "textRoom";
            this.textRoom.ReadOnly = true;
            this.textRoom.Size = new System.Drawing.Size(227, 20);
            this.textRoom.TabIndex = 37;
            // 
            // btn_prousb_read_card
            // 
            this.btn_prousb_read_card.Location = new System.Drawing.Point(332, 80);
            this.btn_prousb_read_card.Name = "btn_prousb_read_card";
            this.btn_prousb_read_card.Size = new System.Drawing.Size(162, 23);
            this.btn_prousb_read_card.TabIndex = 36;
            this.btn_prousb_read_card.Text = "Read Card";
            this.btn_prousb_read_card.UseVisualStyleBackColor = true;
            this.btn_prousb_read_card.Click += new System.EventHandler(this.btn_prousb_read_card_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(334, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Xóa thành công";
            this.label1.Visible = false;
            // 
            // ProUsb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 166);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btn_prousb_delete_card);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textRoom);
            this.Controls.Add(this.btn_prousb_read_card);
            this.Controls.Add(this.hotelCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_prousb_update_hotel_code);
            this.Controls.Add(this.btn_prousb_lock_folder);
            this.Controls.Add(this.ProUsbServer);
            this.Name = "ProUsb";
            this.Text = "ProUsb";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_prousb_lock_folder;
        private System.Windows.Forms.TextBox ProUsbServer;
        private System.Windows.Forms.Label hotelCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_prousb_update_hotel_code;
        private System.Windows.Forms.Button btn_prousb_delete_card;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textRoom;
        private System.Windows.Forms.Button btn_prousb_read_card;
        private System.Windows.Forms.Label label1;
    }
}