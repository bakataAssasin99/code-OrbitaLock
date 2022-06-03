VERSION 5.00
Begin VB.Form Form1 
   Caption         =   " "
   ClientHeight    =   8640
   ClientLeft      =   150
   ClientTop       =   1905
   ClientWidth     =   10095
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   8640
   ScaleWidth      =   10095
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton Command5 
      Caption         =   "写卡"
      Height          =   615
      Left            =   360
      TabIndex        =   23
      Top             =   5760
      Width           =   1455
   End
   Begin VB.CommandButton Command3 
      Caption         =   "注销卡片"
      Height          =   615
      Left            =   3600
      TabIndex        =   22
      Top             =   5760
      Width           =   1455
   End
   Begin VB.CommandButton Command6 
      Caption         =   "读卡"
      Height          =   615
      Left            =   6960
      TabIndex        =   21
      Top             =   5760
      Width           =   1455
   End
   Begin VB.TextBox Text1 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2280
      TabIndex        =   20
      Text            =   "888888"
      Top             =   1320
      Width           =   2295
   End
   Begin VB.TextBox Text2 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2280
      TabIndex        =   19
      Text            =   "G"
      Top             =   1920
      Width           =   2295
   End
   Begin VB.TextBox Text3 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2280
      TabIndex        =   4
      Text            =   "800000"
      Top             =   2520
      Width           =   2295
   End
   Begin VB.TextBox Text6 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2280
      TabIndex        =   3
      Text            =   "1508082314"
      Top             =   4320
      Width           =   2295
   End
   Begin VB.TextBox Text7 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2280
      TabIndex        =   2
      Text            =   "1512311400"
      Top             =   4920
      Width           =   2295
   End
   Begin VB.TextBox Text5 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2280
      TabIndex        =   1
      Text            =   "010101002000"
      Top             =   3720
      Width           =   2295
   End
   Begin VB.TextBox Text4 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2280
      TabIndex        =   0
      Text            =   "Y"
      Top             =   3120
      Width           =   2295
   End
   Begin VB.Label Label14 
      Caption         =   "(G:宾客卡；Q:注销卡片)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   4680
      TabIndex        =   18
      Top             =   1920
      Width           =   4215
   End
   Begin VB.Label Label12 
      Caption         =   "(标识码可通过发卡软件查看，读卡写卡必须输入)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   4680
      TabIndex        =   17
      Top             =   1320
      Width           =   4215
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "卡序列号:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1200
      TabIndex        =   16
      Top             =   2520
      Width           =   975
   End
   Begin VB.Label Label3 
      Alignment       =   1  'Right Justify
      Caption         =   "开始时间:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1200
      TabIndex        =   15
      Top             =   4320
      Width           =   975
   End
   Begin VB.Label Label4 
      Alignment       =   1  'Right Justify
      Caption         =   "结束时间:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1200
      TabIndex        =   14
      Top             =   4920
      Width           =   975
   End
   Begin VB.Label Label5 
      Alignment       =   1  'Right Justify
      Caption         =   "房间物理:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1200
      TabIndex        =   13
      Top             =   3720
      Width           =   975
   End
   Begin VB.Label Label7 
      Alignment       =   1  'Right Justify
      Caption         =   "反锁标志:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1200
      TabIndex        =   12
      Top             =   3120
      Width           =   975
   End
   Begin VB.Label Label8 
      Caption         =   "(范围:7FFFFF-FFFFFF  16进制字符)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   4680
      TabIndex        =   11
      Top             =   2520
      Width           =   4215
   End
   Begin VB.Label Label9 
      Caption         =   "(格式为yymmddhhmm，为10位长)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   4680
      TabIndex        =   10
      Top             =   4320
      Width           =   4215
   End
   Begin VB.Label Label10 
      Caption         =   "(格式为yyyymmddhhmm，为10长)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   4680
      TabIndex        =   9
      Top             =   5040
      Width           =   4215
   End
   Begin VB.Label Label11 
      Caption         =   "(Y:反锁;N:不能开反锁)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   4680
      TabIndex        =   8
      Top             =   3120
      Width           =   3855
   End
   Begin VB.Label Label13 
      Caption         =   "(房间物理号通过房号生成器获得)"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   255
      Left            =   4680
      TabIndex        =   7
      Top             =   3840
      Width           =   4215
   End
   Begin VB.Label Label2 
      Alignment       =   1  'Right Justify
      Caption         =   "卡类别:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1200
      TabIndex        =   6
      Top             =   1920
      Width           =   975
   End
   Begin VB.Label Label6 
      Alignment       =   1  'Right Justify
      Caption         =   "标识码:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1200
      TabIndex        =   5
      Top             =   1320
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim com As Integer
Dim icdev As Long



Private Sub Command4_Click()

End Sub

Private Sub Command3_Click()
'注销客人卡
  Dim status As Integer
 
  status = WriteCard(Text1.Text, "Q", "", "", "", "", "")
  Select Case status
        Case 0
            MsgBox "卡片注销成功！" & status, 0, "提示信息"
        Case 11
            MsgBox "未连接发卡器！" & status, 0, "提示信息"
        Case 12
            MsgBox "卡数据错误！" & status, 0, "提示信息"
        Case 13
            MsgBox "卡密码校验错误或未放置卡片！" & status, 0, "提示信息"
        Case 14
            MsgBox "写卡错误！" & status, 0, "提示信息"
        Case 15
            MsgBox "写入的数据长度超出范围！" & status, 0, "提示信息"
        Case 16
            MsgBox "读卡器无响应！" & status, 0, "提示信息"
        Case 17
            MsgBox "非法操作！" & status, 0, "提示信息"
        Case 18
            MsgBox "写入卡片数据校验错误！" & status, 0, "提示信息"
        Case 100
            MsgBox "注册错误！" & status, 0, "提示信息"
        Case 200
            MsgBox "注册已过期！" & status, 0, "提示信息"
        Case 300
            MsgBox "系统时间不正确！" & status, 0, "提示信息"
        Case 400
            MsgBox "发卡器错误！" & status, 0, "提示信息"
        Case 500
            MsgBox "授权错误！" & status, 0, "提示信息"
        Case 600
            MsgBox "发卡器初始化错误！" & status, 0, "提示信息"
        Case 700
            MsgBox "重复初始化！" & status, 0, "提示信息"
        Case 800
            MsgBox "注册文件写错误！" & status, 0, "提示信息"
  End Select
End Sub

Private Sub Command5_Click()
'写客人卡
  Dim status As Integer
 
  status = WriteCard(Text1.Text, Text2.Text, Text3.Text, Text4.Text, Text5.Text, Text6.Text, Text7.Text)
  Select Case status
        Case 0
            MsgBox "制卡成功！" & status, 0, "提示信息"
        Case 11
            MsgBox "未连接发卡器！" & status, 0, "提示信息"
        Case 12
            MsgBox "卡数据错误！" & status, 0, "提示信息"
        Case 13
            MsgBox "卡密码校验错误或未放置卡片！" & status, 0, "提示信息"
        Case 14
            MsgBox "写卡错误！" & status, 0, "提示信息"
        Case 15
            MsgBox "写入的数据长度超出范围！" & status, 0, "提示信息"
        Case 16
            MsgBox "读卡器无响应！" & status, 0, "提示信息"
        Case 17
            MsgBox "非法操作！" & status, 0, "提示信息"
        Case 18
            MsgBox "写入卡片数据校验错误！" & status, 0, "提示信息"
        Case 100
            MsgBox "注册错误！" & status, 0, "提示信息"
        Case 200
            MsgBox "注册已过期！" & status, 0, "提示信息"
        Case 300
            MsgBox "系统时间不正确！" & status, 0, "提示信息"
        Case 400
            MsgBox "发卡器错误！" & status, 0, "提示信息"
        Case 500
            MsgBox "授权错误！" & status, 0, "提示信息"
        Case 600
            MsgBox "发卡器初始化错误！" & status, 0, "提示信息"
        Case 700
            MsgBox "重复初始化！" & status, 0, "提示信息"
        Case 800
            MsgBox "注册文件写错误！" & status, 0, "提示信息"
  End Select
End Sub

Private Sub Command6_Click()
'读客人卡
  Dim status As Integer
  Dim cardtype As String * 1
  Dim cardid As String * 6
  Dim changkai As String * 1
  Dim roomcd As String * 12
  Dim begdate As String * 10
  Dim enddate As String * 10
  
  Text2.Text = ""
  Text3.Text = ""
  Text4.Text = ""
  Text5.Text = ""
  Text6.Text = ""
  Text7.Text = ""
  
  
  status = ReadCard(Text1.Text, cardtype, cardid, changkai, roomcd, begdate, enddate)
  Select Case status
        Case 0
            Text2.Text = cardtype
            Text3.Text = cardid
            Text4.Text = changkai
            Text5.Text = roomcd
            Text6.Text = begdate
            Text7.Text = enddate
            MsgBox "读卡成功！" & status, 0, "提示信息"
        Case 11
            MsgBox "未连接发卡器！" & status, 0, "提示信息"
        Case 12
            MsgBox "标识码错误！" & status, 0, "提示信息"
        Case 13
            MsgBox "卡密码校验错误或未放置卡片！" & status, 0, "提示信息"
        Case 14
            MsgBox "读卡错误！" & status, 0, "提示信息"
        Case 15
            MsgBox "读出的数据长度超出范围！" & status, 0, "提示信息"
        Case 16
            MsgBox "读卡器无响应！" & status, 0, "提示信息"
        Case 17
            MsgBox "非法操作！" & status, 0, "提示信息"
        Case 18
            MsgBox "非系统客人卡！" & status, 0, "提示信息"
        Case 19
            MsgBox "卡数据错误！" & status, 0, "提示信息"
        Case 100
            MsgBox "注册错误！" & status, 0, "提示信息"
        Case 200
            MsgBox "注册已过期！" & status, 0, "提示信息"
        Case 300
            MsgBox "系统时间不正确！" & status, 0, "提示信息"
        Case 400
            MsgBox "发卡器错误！" & status, 0, "提示信息"
        Case 500
            MsgBox "授权错误！" & status, 0, "提示信息"
        Case 600
            MsgBox "发卡器初始化错误！" & status, 0, "提示信息"
        Case 700
            MsgBox "重复初始化！" & status, 0, "提示信息"
        Case 800
            MsgBox "注册文件写错误！" & status, 0, "提示信息"
  End Select
  
  
  
  
  
  
  
  
  
  
  
End Sub

Private Sub Form_Load()
Dim strbegdate, strbegtime
Dim strenddate, strendtime


strbegdate = Format(Date, "yymmdd")
strbegtime = Format(Time, "hhmm")
strenddate = Format(DateAdd("d", 1, Date), "yymmdd")
Text6.Text = strbegdate & strbegtime
Text7.Text = strenddate & strbegtime

End Sub

Private Sub Frame3_DragDrop(Source As Control, X As Single, Y As Single)

End Sub

