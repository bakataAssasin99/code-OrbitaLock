namespace LockDllSample
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_DB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_port = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_software = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ed_server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ed_result = new System.Windows.Forms.TextBox();
            this.ed_CardID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ck_over = new System.Windows.Forms.CheckBox();
            this.cb_breakfast = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ed_status = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ed_cardno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ed_idno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ed_holder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ed_date = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ed_room = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.b_checkout = new System.Windows.Forms.Button();
            this.b_erase = new System.Windows.Forms.Button();
            this.b_read = new System.Windows.Forms.Button();
            this.b_dupkey = new System.Windows.Forms.Button();
            this.b_newkey = new System.Windows.Forms.Button();
            this.b_end = new System.Windows.Forms.Button();
            this.b_start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_DB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_port);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_software);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ed_server);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // CB_DB
            // 
            this.CB_DB.DisplayMember = "0";
            this.CB_DB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DB.FormattingEnabled = true;
            this.CB_DB.Items.AddRange(new object[] {
            "ACCESS",
            "MSSQL"});
            this.CB_DB.Location = new System.Drawing.Point(70, 12);
            this.CB_DB.MaxDropDownItems = 20;
            this.CB_DB.Name = "CB_DB";
            this.CB_DB.Size = new System.Drawing.Size(93, 23);
            this.CB_DB.TabIndex = 9;
            this.CB_DB.SelectedIndexChanged += new System.EventHandler(this.CB_DB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "DB";
            // 
            // cb_port
            // 
            this.cb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_port.FormattingEnabled = true;
            this.cb_port.Items.AddRange(new object[] {
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
            this.cb_port.Location = new System.Drawing.Point(262, 40);
            this.cb_port.MaxDropDownItems = 20;
            this.cb_port.Name = "cb_port";
            this.cb_port.Size = new System.Drawing.Size(88, 23);
            this.cb_port.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Port";
            // 
            // cb_software
            // 
            this.cb_software.DisplayMember = "0";
            this.cb_software.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_software.FormattingEnabled = true;
            this.cb_software.Items.AddRange(new object[] {
            "MHS",
            "THS"});
            this.cb_software.Location = new System.Drawing.Point(70, 40);
            this.cb_software.MaxDropDownItems = 20;
            this.cb_software.Name = "cb_software";
            this.cb_software.Size = new System.Drawing.Size(93, 23);
            this.cb_software.TabIndex = 3;
            this.cb_software.SelectedIndexChanged += new System.EventHandler(this.cb_software_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Software";
            // 
            // ed_server
            // 
            this.ed_server.Location = new System.Drawing.Point(262, 13);
            this.ed_server.Name = "ed_server";
            this.ed_server.Size = new System.Drawing.Size(310, 21);
            this.ed_server.TabIndex = 1;
            this.ed_server.Text = "C:\\Program Files\\ADEC\\THA V8.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "DB Location";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ed_result);
            this.groupBox2.Controls.Add(this.ed_CardID);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.ck_over);
            this.groupBox2.Controls.Add(this.cb_breakfast);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.ed_status);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ed_cardno);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.ed_idno);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.ed_holder);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ed_date);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ed_room);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(0, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 256);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // ed_result
            // 
            this.ed_result.Location = new System.Drawing.Point(109, 225);
            this.ed_result.Name = "ed_result";
            this.ed_result.ReadOnly = true;
            this.ed_result.Size = new System.Drawing.Size(118, 21);
            this.ed_result.TabIndex = 16;
            // 
            // ed_CardID
            // 
            this.ed_CardID.Location = new System.Drawing.Point(309, 222);
            this.ed_CardID.Name = "ed_CardID";
            this.ed_CardID.ReadOnly = true;
            this.ed_CardID.Size = new System.Drawing.Size(118, 21);
            this.ed_CardID.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(251, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "CardID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(41, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "Result";
            // 
            // ck_over
            // 
            this.ck_over.AutoSize = true;
            this.ck_over.Location = new System.Drawing.Point(308, 174);
            this.ck_over.Name = "ck_over";
            this.ck_over.Size = new System.Drawing.Size(77, 19);
            this.ck_over.TabIndex = 14;
            this.ck_over.Text = "Overwrite";
            this.ck_over.UseVisualStyleBackColor = true;
            // 
            // cb_breakfast
            // 
            this.cb_breakfast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_breakfast.FormattingEnabled = true;
            this.cb_breakfast.Items.AddRange(new object[] {
            "None",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cb_breakfast.Location = new System.Drawing.Point(110, 170);
            this.cb_breakfast.MaxDropDownItems = 20;
            this.cb_breakfast.Name = "cb_breakfast";
            this.cb_breakfast.Size = new System.Drawing.Size(117, 23);
            this.cb_breakfast.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Breakfast";
            // 
            // ed_status
            // 
            this.ed_status.Location = new System.Drawing.Point(309, 113);
            this.ed_status.MaxLength = 20;
            this.ed_status.Name = "ed_status";
            this.ed_status.ReadOnly = true;
            this.ed_status.Size = new System.Drawing.Size(256, 21);
            this.ed_status.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Status";
            // 
            // ed_cardno
            // 
            this.ed_cardno.Location = new System.Drawing.Point(110, 113);
            this.ed_cardno.MaxLength = 20;
            this.ed_cardno.Name = "ed_cardno";
            this.ed_cardno.Size = new System.Drawing.Size(118, 21);
            this.ed_cardno.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Card No.";
            // 
            // ed_idno
            // 
            this.ed_idno.Location = new System.Drawing.Point(309, 62);
            this.ed_idno.MaxLength = 20;
            this.ed_idno.Name = "ed_idno";
            this.ed_idno.Size = new System.Drawing.Size(256, 21);
            this.ed_idno.TabIndex = 7;
            this.ed_idno.Text = "0123456789";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "ID No.";
            // 
            // ed_holder
            // 
            this.ed_holder.Location = new System.Drawing.Point(110, 62);
            this.ed_holder.MaxLength = 20;
            this.ed_holder.Name = "ed_holder";
            this.ed_holder.Size = new System.Drawing.Size(118, 21);
            this.ed_holder.TabIndex = 5;
            this.ed_holder.Text = "Holder";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Holder";
            // 
            // ed_date
            // 
            this.ed_date.Location = new System.Drawing.Point(308, 20);
            this.ed_date.MaxLength = 24;
            this.ed_date.Name = "ed_date";
            this.ed_date.Size = new System.Drawing.Size(256, 21);
            this.ed_date.TabIndex = 3;
            this.ed_date.Text = "200910011200200912311200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Date";
            // 
            // ed_room
            // 
            this.ed_room.Location = new System.Drawing.Point(109, 20);
            this.ed_room.MaxLength = 6;
            this.ed_room.Name = "ed_room";
            this.ed_room.Size = new System.Drawing.Size(118, 21);
            this.ed_room.TabIndex = 1;
            this.ed_room.Text = "0101";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Room No.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(612, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "ReadCardID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.b_checkout);
            this.groupBox3.Controls.Add(this.b_erase);
            this.groupBox3.Controls.Add(this.b_read);
            this.groupBox3.Controls.Add(this.b_dupkey);
            this.groupBox3.Controls.Add(this.b_newkey);
            this.groupBox3.Controls.Add(this.b_end);
            this.groupBox3.Controls.Add(this.b_start);
            this.groupBox3.Location = new System.Drawing.Point(2, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(718, 56);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // b_checkout
            // 
            this.b_checkout.Location = new System.Drawing.Point(528, 20);
            this.b_checkout.Name = "b_checkout";
            this.b_checkout.Size = new System.Drawing.Size(78, 23);
            this.b_checkout.TabIndex = 6;
            this.b_checkout.Text = "CheckOut";
            this.b_checkout.UseVisualStyleBackColor = true;
            this.b_checkout.Click += new System.EventHandler(this.b_checkout_Click);
            // 
            // b_erase
            // 
            this.b_erase.Location = new System.Drawing.Point(427, 20);
            this.b_erase.Name = "b_erase";
            this.b_erase.Size = new System.Drawing.Size(95, 23);
            this.b_erase.TabIndex = 5;
            this.b_erase.Text = "EraseKeyCard";
            this.b_erase.UseVisualStyleBackColor = true;
            this.b_erase.Click += new System.EventHandler(this.b_erase_Click);
            // 
            // b_read
            // 
            this.b_read.Location = new System.Drawing.Point(326, 20);
            this.b_read.Name = "b_read";
            this.b_read.Size = new System.Drawing.Size(95, 23);
            this.b_read.TabIndex = 4;
            this.b_read.Text = "ReadKeyCard";
            this.b_read.UseVisualStyleBackColor = true;
            this.b_read.Click += new System.EventHandler(this.b_read_Click);
            // 
            // b_dupkey
            // 
            this.b_dupkey.Location = new System.Drawing.Point(260, 20);
            this.b_dupkey.Name = "b_dupkey";
            this.b_dupkey.Size = new System.Drawing.Size(60, 23);
            this.b_dupkey.TabIndex = 3;
            this.b_dupkey.Text = "DupKey";
            this.b_dupkey.UseVisualStyleBackColor = true;
            this.b_dupkey.Click += new System.EventHandler(this.b_dupkey_Click);
            // 
            // b_newkey
            // 
            this.b_newkey.Location = new System.Drawing.Point(194, 20);
            this.b_newkey.Name = "b_newkey";
            this.b_newkey.Size = new System.Drawing.Size(60, 23);
            this.b_newkey.TabIndex = 2;
            this.b_newkey.Text = "NewKey";
            this.b_newkey.UseVisualStyleBackColor = true;
            this.b_newkey.Click += new System.EventHandler(this.b_newkey_Click);
            // 
            // b_end
            // 
            this.b_end.Location = new System.Drawing.Point(101, 20);
            this.b_end.Name = "b_end";
            this.b_end.Size = new System.Drawing.Size(87, 23);
            this.b_end.TabIndex = 1;
            this.b_end.Text = "EndSession";
            this.b_end.UseVisualStyleBackColor = true;
            this.b_end.Click += new System.EventHandler(this.button2_Click);
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(8, 20);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(87, 23);
            this.b_start.TabIndex = 0;
            this.b_start.Text = "StartSession";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 389);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C# Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_software;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ed_server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_port;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ed_room;
        private System.Windows.Forms.TextBox ed_date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ed_idno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ed_holder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ed_status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ed_cardno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_breakfast;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ed_result;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ck_over;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.Button b_checkout;
        private System.Windows.Forms.Button b_erase;
        private System.Windows.Forms.Button b_read;
        private System.Windows.Forms.Button b_dupkey;
        private System.Windows.Forms.Button b_newkey;
        private System.Windows.Forms.Button b_end;
        private System.Windows.Forms.ComboBox CB_DB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ed_CardID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
    }
}

