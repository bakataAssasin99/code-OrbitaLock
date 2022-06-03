<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CB_Software = New System.Windows.Forms.ComboBox
        Me.CB_Port = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB_RoomNo = New System.Windows.Forms.TextBox
        Me.TB_Time = New System.Windows.Forms.TextBox
        Me.TB_Holder = New System.Windows.Forms.TextBox
        Me.TB_CardNo = New System.Windows.Forms.TextBox
        Me.TB_IDNo = New System.Windows.Forms.TextBox
        Me.TB_Status = New System.Windows.Forms.TextBox
        Me.CB_Breakfast = New System.Windows.Forms.ComboBox
        Me.TB_Result = New System.Windows.Forms.TextBox
        Me.B_Start = New System.Windows.Forms.Button
        Me.B_End = New System.Windows.Forms.Button
        Me.B_NewKey = New System.Windows.Forms.Button
        Me.B_DupKey = New System.Windows.Forms.Button
        Me.B_ReadKey = New System.Windows.Forms.Button
        Me.B_EraseKey = New System.Windows.Forms.Button
        Me.B_CheckOut = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.CK_Over = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tb_server = New System.Windows.Forms.TextBox
        Me.CB_DB = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'CB_Software
        '
        Me.CB_Software.FormattingEnabled = True
        Me.CB_Software.Items.AddRange(New Object() {"MHS", "THS"})
        Me.CB_Software.Location = New System.Drawing.Point(84, 65)
        Me.CB_Software.Name = "CB_Software"
        Me.CB_Software.Size = New System.Drawing.Size(78, 20)
        Me.CB_Software.TabIndex = 0
        '
        'CB_Port
        '
        Me.CB_Port.FormattingEnabled = True
        Me.CB_Port.Items.AddRange(New Object() {"USB", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9"})
        Me.CB_Port.Location = New System.Drawing.Point(369, 66)
        Me.CB_Port.Name = "CB_Port"
        Me.CB_Port.Size = New System.Drawing.Size(78, 20)
        Me.CB_Port.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(322, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "PORT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Software"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(60, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "DB"
        '
        'TB_RoomNo
        '
        Me.TB_RoomNo.Location = New System.Drawing.Point(83, 102)
        Me.TB_RoomNo.Name = "TB_RoomNo"
        Me.TB_RoomNo.Size = New System.Drawing.Size(100, 21)
        Me.TB_RoomNo.TabIndex = 8
        Me.TB_RoomNo.Text = "0101"
        '
        'TB_Time
        '
        Me.TB_Time.Location = New System.Drawing.Point(369, 102)
        Me.TB_Time.Name = "TB_Time"
        Me.TB_Time.Size = New System.Drawing.Size(286, 21)
        Me.TB_Time.TabIndex = 9
        Me.TB_Time.Text = "200201011200200212311200"
        '
        'TB_Holder
        '
        Me.TB_Holder.Location = New System.Drawing.Point(83, 151)
        Me.TB_Holder.Name = "TB_Holder"
        Me.TB_Holder.Size = New System.Drawing.Size(100, 21)
        Me.TB_Holder.TabIndex = 10
        Me.TB_Holder.Text = "Holder"
        '
        'TB_CardNo
        '
        Me.TB_CardNo.Location = New System.Drawing.Point(83, 200)
        Me.TB_CardNo.Name = "TB_CardNo"
        Me.TB_CardNo.Size = New System.Drawing.Size(100, 21)
        Me.TB_CardNo.TabIndex = 11
        '
        'TB_IDNo
        '
        Me.TB_IDNo.Location = New System.Drawing.Point(369, 151)
        Me.TB_IDNo.Name = "TB_IDNo"
        Me.TB_IDNo.Size = New System.Drawing.Size(286, 21)
        Me.TB_IDNo.TabIndex = 12
        Me.TB_IDNo.Text = "012456789"
        '
        'TB_Status
        '
        Me.TB_Status.Location = New System.Drawing.Point(369, 200)
        Me.TB_Status.Name = "TB_Status"
        Me.TB_Status.Size = New System.Drawing.Size(286, 21)
        Me.TB_Status.TabIndex = 13
        '
        'CB_Breakfast
        '
        Me.CB_Breakfast.FormattingEnabled = True
        Me.CB_Breakfast.Items.AddRange(New Object() {"None", "1", "2", "3", "4", "5"})
        Me.CB_Breakfast.Location = New System.Drawing.Point(83, 246)
        Me.CB_Breakfast.Name = "CB_Breakfast"
        Me.CB_Breakfast.Size = New System.Drawing.Size(78, 20)
        Me.CB_Breakfast.TabIndex = 14
        Me.CB_Breakfast.Text = "1"
        '
        'TB_Result
        '
        Me.TB_Result.Location = New System.Drawing.Point(83, 290)
        Me.TB_Result.Name = "TB_Result"
        Me.TB_Result.Size = New System.Drawing.Size(100, 21)
        Me.TB_Result.TabIndex = 15
        '
        'B_Start
        '
        Me.B_Start.Location = New System.Drawing.Point(26, 365)
        Me.B_Start.Name = "B_Start"
        Me.B_Start.Size = New System.Drawing.Size(97, 23)
        Me.B_Start.TabIndex = 16
        Me.B_Start.Text = "StartSession"
        Me.B_Start.UseVisualStyleBackColor = True
        '
        'B_End
        '
        Me.B_End.Location = New System.Drawing.Point(129, 365)
        Me.B_End.Name = "B_End"
        Me.B_End.Size = New System.Drawing.Size(75, 23)
        Me.B_End.TabIndex = 17
        Me.B_End.Text = "EndSession"
        Me.B_End.UseVisualStyleBackColor = True
        '
        'B_NewKey
        '
        Me.B_NewKey.Location = New System.Drawing.Point(210, 365)
        Me.B_NewKey.Name = "B_NewKey"
        Me.B_NewKey.Size = New System.Drawing.Size(75, 23)
        Me.B_NewKey.TabIndex = 18
        Me.B_NewKey.Text = "NewKey"
        Me.B_NewKey.UseVisualStyleBackColor = True
        '
        'B_DupKey
        '
        Me.B_DupKey.Location = New System.Drawing.Point(291, 365)
        Me.B_DupKey.Name = "B_DupKey"
        Me.B_DupKey.Size = New System.Drawing.Size(75, 23)
        Me.B_DupKey.TabIndex = 19
        Me.B_DupKey.Text = "DupKey"
        Me.B_DupKey.UseVisualStyleBackColor = True
        '
        'B_ReadKey
        '
        Me.B_ReadKey.Location = New System.Drawing.Point(372, 365)
        Me.B_ReadKey.Name = "B_ReadKey"
        Me.B_ReadKey.Size = New System.Drawing.Size(90, 23)
        Me.B_ReadKey.TabIndex = 20
        Me.B_ReadKey.Text = "ReadKeyCard"
        Me.B_ReadKey.UseVisualStyleBackColor = True
        '
        'B_EraseKey
        '
        Me.B_EraseKey.Location = New System.Drawing.Point(468, 365)
        Me.B_EraseKey.Name = "B_EraseKey"
        Me.B_EraseKey.Size = New System.Drawing.Size(88, 23)
        Me.B_EraseKey.TabIndex = 21
        Me.B_EraseKey.Text = "EraseKeyCard"
        Me.B_EraseKey.UseVisualStyleBackColor = True
        '
        'B_CheckOut
        '
        Me.B_CheckOut.Location = New System.Drawing.Point(562, 365)
        Me.B_CheckOut.Name = "B_CheckOut"
        Me.B_CheckOut.Size = New System.Drawing.Size(75, 23)
        Me.B_CheckOut.TabIndex = 22
        Me.B_CheckOut.Text = "CheckOut"
        Me.B_CheckOut.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Room No."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Holder"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Card No."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 249)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Breakfast"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 293)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Result"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(322, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(313, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 12)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "ID No."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(310, 203)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 12)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Status"
        '
        'CK_Over
        '
        Me.CK_Over.AutoSize = True
        Me.CK_Over.Location = New System.Drawing.Point(369, 250)
        Me.CK_Over.Name = "CK_Over"
        Me.CK_Over.Size = New System.Drawing.Size(78, 16)
        Me.CK_Over.TabIndex = 31
        Me.CK_Over.Text = "overwrite"
        Me.CK_Over.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(283, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "DB Location"
        '
        'tb_server
        '
        Me.tb_server.Location = New System.Drawing.Point(369, 21)
        Me.tb_server.Name = "tb_server"
        Me.tb_server.Size = New System.Drawing.Size(286, 21)
        Me.tb_server.TabIndex = 32
        Me.tb_server.Text = "C:\Program Files\HONGLG\MHA V8.0"
        '
        'CB_DB
        '
        Me.CB_DB.FormattingEnabled = True
        Me.CB_DB.Items.AddRange(New Object() {"ACCESS", "MSSQL"})
        Me.CB_DB.Location = New System.Drawing.Point(83, 22)
        Me.CB_DB.Name = "CB_DB"
        Me.CB_DB.Size = New System.Drawing.Size(78, 20)
        Me.CB_DB.TabIndex = 34
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 409)
        Me.Controls.Add(Me.CB_DB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_server)
        Me.Controls.Add(Me.CK_Over)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.B_CheckOut)
        Me.Controls.Add(Me.B_EraseKey)
        Me.Controls.Add(Me.B_ReadKey)
        Me.Controls.Add(Me.B_DupKey)
        Me.Controls.Add(Me.B_NewKey)
        Me.Controls.Add(Me.B_End)
        Me.Controls.Add(Me.B_Start)
        Me.Controls.Add(Me.TB_Result)
        Me.Controls.Add(Me.CB_Breakfast)
        Me.Controls.Add(Me.TB_Status)
        Me.Controls.Add(Me.TB_IDNo)
        Me.Controls.Add(Me.TB_CardNo)
        Me.Controls.Add(Me.TB_Holder)
        Me.Controls.Add(Me.TB_Time)
        Me.Controls.Add(Me.TB_RoomNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CB_Port)
        Me.Controls.Add(Me.CB_Software)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CB_Software As System.Windows.Forms.ComboBox
    Friend WithEvents CB_Port As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB_RoomNo As System.Windows.Forms.TextBox
    Friend WithEvents TB_Time As System.Windows.Forms.TextBox
    Friend WithEvents TB_Holder As System.Windows.Forms.TextBox
    Friend WithEvents TB_CardNo As System.Windows.Forms.TextBox
    Friend WithEvents TB_IDNo As System.Windows.Forms.TextBox
    Friend WithEvents TB_Status As System.Windows.Forms.TextBox
    Friend WithEvents CB_Breakfast As System.Windows.Forms.ComboBox
    Friend WithEvents TB_Result As System.Windows.Forms.TextBox
    Friend WithEvents B_Start As System.Windows.Forms.Button
    Friend WithEvents B_End As System.Windows.Forms.Button
    Friend WithEvents B_NewKey As System.Windows.Forms.Button
    Friend WithEvents B_DupKey As System.Windows.Forms.Button
    Friend WithEvents B_ReadKey As System.Windows.Forms.Button
    Friend WithEvents B_EraseKey As System.Windows.Forms.Button
    Friend WithEvents B_CheckOut As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CK_Over As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_server As System.Windows.Forms.TextBox
    Friend WithEvents CB_DB As System.Windows.Forms.ComboBox

End Class
