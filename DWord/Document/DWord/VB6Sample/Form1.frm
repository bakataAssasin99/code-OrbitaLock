VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "VbSample"
   ClientHeight    =   6150
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   10350
   LinkTopic       =   "Form1"
   ScaleHeight     =   6150
   ScaleWidth      =   10350
   StartUpPosition =   3  '窗口缺省
   Begin VB.CheckBox CK_OVER 
      Caption         =   "Overwrite"
      Height          =   375
      Left            =   5760
      TabIndex        =   29
      Top             =   3600
      Width           =   1575
   End
   Begin VB.ComboBox CB_SOFT 
      Height          =   300
      ItemData        =   "Form1.frx":0000
      Left            =   1680
      List            =   "Form1.frx":000A
      Style           =   2  'Dropdown List
      TabIndex        =   28
      Top             =   840
      Width           =   1695
   End
   Begin VB.ComboBox Cb_DB 
      Height          =   300
      ItemData        =   "Form1.frx":0018
      Left            =   1680
      List            =   "Form1.frx":0022
      Style           =   2  'Dropdown List
      TabIndex        =   27
      Top             =   240
      Width           =   1575
   End
   Begin VB.CommandButton b_checkout 
      Caption         =   "CheckOut"
      Height          =   375
      Left            =   8040
      TabIndex        =   15
      Top             =   5400
      Width           =   975
   End
   Begin VB.CommandButton b_erase 
      Caption         =   "EraseKeyCard"
      Height          =   375
      Left            =   6720
      TabIndex        =   14
      Top             =   5400
      Width           =   1215
   End
   Begin VB.CommandButton b_read 
      Caption         =   "ReadKeyCard"
      Height          =   375
      Left            =   5400
      TabIndex        =   13
      Top             =   5400
      Width           =   1215
   End
   Begin VB.CommandButton b_dupkey 
      Caption         =   "DupKey"
      Height          =   375
      Left            =   4320
      TabIndex        =   12
      Top             =   5400
      Width           =   975
   End
   Begin VB.CommandButton b_newkey 
      Caption         =   "NewKey"
      Height          =   375
      Left            =   3120
      TabIndex        =   11
      Top             =   5400
      Width           =   1095
   End
   Begin VB.CommandButton b_end 
      Caption         =   "EndSession"
      Height          =   375
      Left            =   1920
      TabIndex        =   10
      Top             =   5400
      Width           =   1095
   End
   Begin VB.CommandButton b_start 
      Caption         =   "StartSession"
      Height          =   375
      Left            =   600
      TabIndex        =   9
      Top             =   5400
      Width           =   1215
   End
   Begin VB.TextBox Ed_CardID 
      Height          =   375
      Left            =   5760
      TabIndex        =   8
      Top             =   4440
      Width           =   2775
   End
   Begin VB.TextBox ED_RESULT 
      Height          =   375
      Left            =   1680
      TabIndex        =   7
      Top             =   4440
      Width           =   2655
   End
   Begin VB.TextBox ed_status 
      Height          =   375
      Left            =   5760
      TabIndex        =   6
      Top             =   3000
      Width           =   3015
   End
   Begin VB.TextBox ed_cardno 
      Height          =   375
      Left            =   1680
      TabIndex        =   5
      Top             =   3000
      Width           =   2655
   End
   Begin VB.TextBox ed_idno 
      Height          =   375
      Left            =   5760
      TabIndex        =   4
      Text            =   "012456789"
      Top             =   2400
      Width           =   3015
   End
   Begin VB.TextBox ED_HOLDER 
      Height          =   375
      Left            =   1680
      TabIndex        =   3
      Text            =   "Holder"
      Top             =   2400
      Width           =   2655
   End
   Begin VB.TextBox ED_TIME 
      Height          =   375
      Left            =   5760
      TabIndex        =   2
      Text            =   "200201011200200212311200"
      Top             =   1800
      Width           =   3255
   End
   Begin VB.TextBox ED_ROOMNO 
      Height          =   375
      Left            =   1680
      TabIndex        =   1
      Text            =   "0101"
      Top             =   1800
      Width           =   2655
   End
   Begin VB.TextBox ED_Server 
      Height          =   375
      Left            =   5760
      TabIndex        =   0
      Text            =   "(local)"
      Top             =   240
      Width           =   3255
   End
   Begin VB.Label Label13 
      Caption         =   "CardID"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4800
      TabIndex        =   26
      Top             =   4440
      Width           =   615
   End
   Begin VB.Label Label12 
      Caption         =   "Result"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   720
      TabIndex        =   25
      Top             =   4440
      Width           =   735
   End
   Begin VB.Label Label10 
      Caption         =   "Status"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4800
      TabIndex        =   24
      Top             =   3120
      Width           =   615
   End
   Begin VB.Label Label9 
      Caption         =   "Card No."
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   600
      TabIndex        =   23
      Top             =   3000
      Width           =   975
   End
   Begin VB.Label Label8 
      Caption         =   "ID No."
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   5040
      TabIndex        =   22
      Top             =   2520
      Width           =   255
   End
   Begin VB.Label Label7 
      Caption         =   "Holder"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   720
      TabIndex        =   21
      Top             =   2400
      Width           =   855
   End
   Begin VB.Label Label6 
      Caption         =   "Date"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4920
      TabIndex        =   20
      Top             =   1920
      Width           =   495
   End
   Begin VB.Label Label5 
      Caption         =   "Room No."
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   840
      TabIndex        =   19
      Top             =   1800
      Width           =   615
   End
   Begin VB.Label Label3 
      Caption         =   "Software"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   600
      TabIndex        =   18
      Top             =   840
      Width           =   855
   End
   Begin VB.Label Label2 
      Caption         =   "DB Location"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   4200
      TabIndex        =   17
      Top             =   360
      Width           =   1335
   End
   Begin VB.Label Label1 
      Caption         =   "DB"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1200
      TabIndex        =   16
      Top             =   240
      Width           =   255
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   9960
      Y1              =   5040
      Y2              =   5040
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub b_checkout_Click()
        Dim lStatus As Long
        Dim CardNo As Long
        Dim RoomNo As String

        If IsNumeric(ed_cardno.Text) Then
            CardNo = Val(ed_cardno.Text)
        Else
            CardNo = 0
        End If

        RoomNo = ED_ROOMNO.Text

        ED_RESULT.Text = "Executing..."

        lStatus = CheckOut(RoomNo, CardNo)

        ED_RESULT.Text = Hex(lStatus)

End Sub

Private Sub b_dupkey_Click()
        Dim lStatus As Long
        Dim Port As Long
        Dim CardNo As Long
        Dim OverFlag As Long
        Dim Breakfast As Long
        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String

        Port = 0

        If (CK_OVER.Value = Checked) Then
            OverFlag = 1
        Else
            OverFlag = 0
        End If

        Breakfast = 0

        RoomNo = ED_ROOMNO.Text
        Holder = ED_HOLDER.Text
        IDNo = ed_idno.Text
        TimeStr = ED_TIME.Text
        CardNo = 0

        ED_RESULT.Text = "Executing..."

        lStatus = DupKey(Port, RoomNo, "", "", TimeStr, Holder, IDNo, Breakfast, OverFlag, CardNo)

        ED_RESULT.Text = Hex(lStatus)

        If (lStatus = 0) Then
            ed_cardno.Text = CStr(CardNo)
        End If

End Sub

Private Sub b_end_Click()
        Dim lStatus As Long

        ED_RESULT.Text = "Executing..."

        lStatus = EndSession()

        ED_RESULT.Text = Hex(lStatus)

End Sub

Private Sub b_erase_Click()
        Dim lStatus As Long
        Dim Port As Long
        Dim CardNo As Long

        Port = 0

        If IsNumeric(ed_cardno.Text) Then
            CardNo = Val(ed_cardno.Text)
        Else
            CardNo = 0
        End If

        ED_RESULT.Text = "Executing..."

        lStatus = EraseKeyCard(Port, CardNo)

        ED_RESULT.Text = Hex(lStatus)

End Sub

Private Sub b_newkey_Click()
        Dim lStatus As Long
        Dim Port As Long
        Dim CardNo As Long
        Dim OverFlag As Long
        Dim Breakfast As Long
        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String

        Port = 0

        If (CK_OVER.Value = Checked) Then
            OverFlag = 1
        Else
            OverFlag = 0
        End If

        Breakfast = 0

        RoomNo = ED_ROOMNO.Text
        Holder = ED_HOLDER.Text
        IDNo = ed_idno.Text
        TimeStr = ED_TIME.Text
        CardNo = 0

        ED_RESULT.Text = "Executing..."

        lStatus = NewKey(Port, RoomNo, "", "", TimeStr, Holder, IDNo, Breakfast, OverFlag, CardNo)

        ED_RESULT.Text = Hex(lStatus)

        If (lStatus = 0) Then
            ed_cardno.Text = CStr(CardNo)
        End If

End Sub

Private Sub b_read_Click()
        Dim lStatus As Long
        Dim Port As Long
        Dim CardNo As Long
        Dim CardStatus As Long
        Dim Breakfast As Long

        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String
        Dim Door As String
        Dim lift As String

        RoomNo = String(64, Chr(0))
        Holder = String(64, Chr(0))
        IDNo = String(64, Chr(0))
        TimeStr = String(64, Chr(0))
        Door = String(128, Chr(0))
        lift = String(128, Chr(0))

        Port = 0

        CardNo = 0
        CardStatus = 0
        Breakfast = 0

        lStatus = ReadKeyCard(Port, RoomNo, Door, lift, TimeStr, Holder, IDNo, CardNo, CardStatus, Breakfast)
        
        ED_RESULT.Text = Hex(lStatus)

        If (lStatus = 0) Then
            ed_cardno.Text = CStr(CardNo)
            ed_status.Text = CStr(CardStatus)

            ED_ROOMNO.Text = RoomNo
            ED_HOLDER.Text = Holder
            ed_idno.Text = IDNo
            ED_TIME.Text = TimeStr
        End If
        

End Sub

Private Sub b_start_Click()
        Dim server As String
        Dim user As String
        Dim LockSoftware As Long
        Dim db_flag As Long
        Dim lStatus As Long

        server = ED_Server.Text
        user = "DllUser"
        LockSoftware = CB_SOFT.ListIndex + 1
        db_flag = Cb_DB.ListIndex
        
        ED_RESULT.Text = "Executing..."

        lStatus = StartSession(LockSoftware, server, user, db_flag)

        ED_RESULT.Text = Hex(lStatus)

End Sub

Private Sub Form_Load()
        Cb_DB.ListIndex = 0
        CB_SOFT.ListIndex = 0
End Sub
