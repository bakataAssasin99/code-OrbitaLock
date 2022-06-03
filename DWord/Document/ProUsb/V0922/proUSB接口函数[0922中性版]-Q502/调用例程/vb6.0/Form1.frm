VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "USB感应锁接口函数演示程序"
   ClientHeight    =   8325
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   12180
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   8325
   ScaleWidth      =   12180
   StartUpPosition =   1  '所有者中心
   Begin VB.Frame Frame4 
      Caption         =   "最常用函数"
      Enabled         =   0   'False
      Height          =   4695
      Left            =   8280
      TabIndex        =   32
      Top             =   1560
      Width           =   3615
      Begin VB.CommandButton Command7 
         Caption         =   "读取客人离店时间[GetGuestETimeByCardDataStr]"
         Height          =   615
         Left            =   240
         TabIndex        =   40
         Top             =   3960
         Width           =   3135
      End
      Begin VB.CommandButton Command6 
         Caption         =   "读取客人卡锁号[GetGuestLockNoByCardDataStr]"
         Height          =   615
         Left            =   240
         TabIndex        =   39
         Top             =   3360
         Width           =   3135
      End
      Begin VB.CommandButton Command5 
         Caption         =   "读取卡片类型[GetCardTypeByCardDataStr]"
         Height          =   615
         Left            =   240
         TabIndex        =   38
         Top             =   2760
         Width           =   3135
      End
      Begin VB.CommandButton Command4 
         Caption         =   "挂失卡片[LimitCard]"
         Height          =   495
         Left            =   480
         TabIndex        =   37
         Top             =   2160
         Width           =   2655
      End
      Begin VB.CommandButton Command2 
         Caption         =   "注销卡片[CardErase]"
         Height          =   495
         Left            =   480
         TabIndex        =   36
         Top             =   1680
         Width           =   2655
      End
      Begin VB.CommandButton cmdbuzzer 
         Caption         =   "蜂鸣[Buzzer]"
         Height          =   495
         Left            =   480
         TabIndex        =   35
         Top             =   240
         Width           =   2655
      End
      Begin VB.CommandButton cmdwritecard 
         Caption         =   "制宾客卡[GuestCard]"
         Height          =   495
         Left            =   480
         TabIndex        =   34
         Top             =   1200
         Width           =   2655
      End
      Begin VB.CommandButton cmdreadcard 
         Caption         =   "读取卡数据[ReadCard]"
         Height          =   495
         Left            =   480
         TabIndex        =   33
         Top             =   720
         Width           =   2655
      End
   End
   Begin VB.TextBox txtStrHex 
      BackColor       =   &H8000000B&
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   120
      TabIndex        =   28
      Text            =   "txtStrHex"
      Top             =   5880
      Width           =   8055
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "退出"
      Height          =   495
      Left            =   8520
      TabIndex        =   25
      Top             =   840
      Width           =   3135
   End
   Begin VB.CommandButton cmdGetDllVer 
      Caption         =   "读DLL版本号[GetDllVersion]"
      Height          =   495
      Left            =   8520
      TabIndex        =   24
      Top             =   240
      Width           =   3135
   End
   Begin VB.Frame Frame3 
      Caption         =   "使用说明"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   1815
      Left            =   120
      TabIndex        =   15
      Top             =   6360
      Width           =   8055
      Begin VB.Label Label12 
         Caption         =   "4,读DLL版本为测试动态库，不涉及端口操作。"
         ForeColor       =   &H00008000&
         Height          =   255
         Left            =   360
         TabIndex        =   19
         Top             =   1440
         Width           =   6015
      End
      Begin VB.Label Label9 
         Caption         =   "3,客人代号，是实现后卡覆盖前卡功能的，一般默认为0即可；"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   360
         TabIndex        =   18
         Top             =   1080
         Width           =   5535
      End
      Begin VB.Label Label8 
         Caption         =   "2,按说明正确填写相应信息是能否发卡成功的关键步骤； "
         ForeColor       =   &H00008000&
         Height          =   255
         Left            =   360
         TabIndex        =   17
         Top             =   720
         Width           =   5535
      End
      Begin VB.Label Label7 
         Caption         =   "1,USB端口打开之后, 才能进行发卡读卡等操作;"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   360
         TabIndex        =   16
         Top             =   360
         Width           =   5895
      End
   End
   Begin VB.CommandButton Command1 
      Caption         =   "第一步: 打开端口[initializeUSB]"
      Height          =   735
      Left            =   4200
      TabIndex        =   3
      Top             =   480
      Width           =   3735
   End
   Begin VB.OptionButton Option2 
      Caption         =   "proUSB(即插即用,无须安装驱动程序)"
      Height          =   495
      Left            =   360
      TabIndex        =   2
      Top             =   840
      Value           =   -1  'True
      Width           =   3615
   End
   Begin VB.OptionButton Option1 
      Caption         =   "有驱发卡器(需要先安装驱动才能使用)"
      Height          =   495
      Left            =   360
      TabIndex        =   1
      Top             =   360
      Width           =   3615
   End
   Begin VB.Frame Frame1 
      Caption         =   "端口操作"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   1335
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   8055
   End
   Begin VB.Frame Frame2 
      Caption         =   "卡片操作"
      Enabled         =   0   'False
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   10.5
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   3855
      Left            =   120
      TabIndex        =   4
      Top             =   1560
      Width           =   8055
      Begin VB.OptionButton Option4 
         Caption         =   "可以开反锁"
         Height          =   255
         Left            =   1200
         TabIndex        =   31
         Top             =   3360
         Value           =   -1  'True
         Width           =   1935
      End
      Begin VB.OptionButton Option3 
         Caption         =   "不能开反锁"
         Height          =   300
         Left            =   3240
         TabIndex        =   30
         Top             =   3360
         Width           =   1935
      End
      Begin VB.CommandButton cmdreset 
         Caption         =   "恢复到默认值"
         Height          =   495
         Left            =   6360
         TabIndex        =   26
         Top             =   3240
         Width           =   1455
      End
      Begin VB.TextBox txtCoID 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   270
         Left            =   2280
         TabIndex        =   22
         Text            =   "txtCoID"
         Top             =   360
         Width           =   1575
      End
      Begin VB.CommandButton Command3 
         Caption         =   "从现有卡片读取酒店标识"
         Height          =   375
         Left            =   4080
         TabIndex        =   21
         Top             =   360
         Width           =   3735
      End
      Begin VB.TextBox txtDai 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   270
         Left            =   2280
         TabIndex        =   13
         Text            =   "txtDai"
         Top             =   2880
         Width           =   855
      End
      Begin VB.TextBox txtETime 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   2280
         TabIndex        =   11
         Text            =   "txtETime"
         Top             =   2280
         Width           =   3375
      End
      Begin VB.TextBox txtLockNo 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   270
         Left            =   2280
         TabIndex        =   9
         Text            =   "txtLockNo"
         Top             =   1440
         Width           =   1575
      End
      Begin VB.TextBox txtCardNo 
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   10.5
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   270
         Left            =   2280
         TabIndex        =   6
         Text            =   "txtCardNo"
         Top             =   960
         Width           =   1575
      End
      Begin VB.Label Label4 
         Caption         =   "( 01020399表示01栋02层03房 )"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   3960
         TabIndex        =   27
         Top             =   1440
         Width           =   3255
      End
      Begin VB.Label Label23 
         Alignment       =   1  'Right Justify
         Caption         =   "酒店标识[coID]："
         Height          =   255
         Left            =   360
         TabIndex        =   23
         Top             =   360
         Width           =   1695
      End
      Begin VB.Label Label28 
         Caption         =   "锁号组成：栋号2位,层号2位,房间编号2位,第二房间编号2位"
         ForeColor       =   &H000000FF&
         Height          =   375
         Left            =   840
         TabIndex        =   20
         Top             =   1800
         Width           =   6495
      End
      Begin VB.Label Label5 
         Caption         =   "（0-255循环）"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   3240
         TabIndex        =   14
         Top             =   2880
         Width           =   1575
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         Caption         =   "客人代[Dai]："
         Height          =   255
         Left            =   120
         TabIndex        =   12
         Top             =   2880
         Width           =   1935
      End
      Begin VB.Label Label29 
         Alignment       =   1  'Right Justify
         Caption         =   "预计退房时间[eTime]："
         Height          =   255
         Left            =   120
         TabIndex        =   10
         Top             =   2400
         Width           =   1935
      End
      Begin VB.Label Label27 
         Alignment       =   1  'Right Justify
         Caption         =   "锁号[LockNo]："
         Height          =   255
         Left            =   240
         TabIndex        =   8
         Top             =   1440
         Width           =   1815
      End
      Begin VB.Label Label2 
         Caption         =   "（0-15,一分钟之内最多发16张卡）"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   3960
         TabIndex        =   7
         Top             =   960
         Width           =   3855
      End
      Begin VB.Label Label22 
         Alignment       =   1  'Right Justify
         Caption         =   "卡号[CardNo]："
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   960
         Width           =   1815
      End
   End
   Begin VB.Label Label3 
      Caption         =   "卡数据[CardHexStr]："
      Height          =   255
      Left            =   120
      TabIndex        =   29
      Top             =   5520
      Width           =   2055
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'读取卡数据
Private Sub cmdreadcard_Click()
  If rdCard <> True Then Exit Sub            '先读卡
  txtStrHex.Text = bufCard
  MsgBox "卡ID号：" & Mid(bufCard, 25, 8), 64
End Sub

'制宾客卡
Private Sub cmdwritecard_Click()
  Dim llock As Byte         '反锁标志
  Dim pdoors As Byte        '公共门标志
  Dim dlsCoID As Long       '酒店标识
  Dim CardNo As Integer     '卡号(0-15)
  Dim dai As Integer        '客人代
  Dim BTime As String       '发卡时间,也就是电脑当前时间
  Dim ETime As String       '预计退房时间
  Dim LockNo As String      '锁号
  
  If rdCard <> True Then Exit Sub            '先读卡
  txtStrHex.Text = bufCard
  
  If Option4.Value = True Then               '反锁标志
    llock = 1
  Else
    llock = 0
  End If
  
  pdoors = 1                                   '公共门标志
  dlsCoID = CLng(txtCoID.Text)                 '酒店标识
  CardNo = CInt(txtCardNo.Text) Mod 16         '卡号(0-15)
  dai = CInt(txtDai.Text) Mod 256              '客人代
  BTime = Format(Now, "YYMMDDHHMM")            '发卡时间
  ETime = Format(txtETime.Text, "YYMMDDHHMM")  '预计退房时间
  LockNo = txtLockNo.Text
  
  st = GuestCard(flagUSB, dlsCoID, CardNo, dai, llock, pdoors, BTime, ETime, LockNo, bufHexStr)
  If flagUSB = 1 Then Buzzer flagUSB, 20     '写卡后鸣叫一声，因为GuestCard函数本身不会有响声
  txtStrHex.Text = bufHexStr
  If st <> 0 Then
    MsgBox "调用发卡函数失败, 错误代号为: " & CStr(st), 16
  Else
    MsgBox "调用发卡函数成功" & Chr(10) & Chr(10) & "注意: 并不代表数据已经写到卡里, 建议停顿一秒钟后调用ReadCard" & Chr(10) & "如果GuestCard与ReadCard的bufHexStr相同表示写卡成功", 64
  End If

End Sub

'注销卡片
Private Sub Command2_Click()
  Dim dlsCoID As Long       '酒店标识
  
  If rdCard <> True Then Exit Sub            '先读卡
  txtStrHex.Text = bufCard
  
  dlsCoID = CLng(txtCoID.Text)               '酒店标识
  st = CardErase(flagUSB, dlsCoID, bufHexStr)
  If flagUSB = 1 Then Buzzer flagUSB, 20   '写卡后鸣叫一声，因为CardErase函数本身不会有响声
  txtStrHex.Text = bufHexStr
  If st <> 0 Then
    MsgBox "注销失败, 错误代号为: " & CStr(st), 16
  Else
    MsgBox "注销成功", 64
  End If
End Sub

'卡片挂失
Private Sub Command4_Click()
  Dim dlsCoID As Long         '酒店标识
  Dim limitNo As String * 4   '挂失卡号
  Dim dai As Integer          '代
    
  If rdCard <> True Then Exit Sub            '先读卡
  txtStrHex.Text = bufCard
  
  dlsCoID = CLng(txtCoID.Text)               '酒店标识
  CardNo = CInt(txtCardNo.Text) Mod 16       '卡号(0-15)
  dai = CInt(txtDai.Text) Mod 256            '客人代
  BTime = Format(Now, "YYMMDDHHMM")          '发卡时间
  limitNo = Chr(&H60) & Chr(&H12) & Chr(&HD2) & Chr(&H91)    '挂失卡号: 6012D291
  
  st = LimitCard(flagUSB, dlsCoID, CardNo, dai, BTime, limitNo, bufHexStr)
  If flagUSB = 1 Then Buzzer flagUSB, 20    '写卡后鸣叫一声，因为LimitCard函数本身不会有响声
  txtStrHex.Text = bufHexStr
  If st <> 0 Then
    MsgBox "挂失卡片失败, 错误代号为: " & CStr(st), 16
  Else
    MsgBox "调用挂失卡函数成功" & Chr(10) & "本例子挂失卡号为: 6012D291", 64
  End If
End Sub

'读取卡片类型
Private Sub Command5_Click()
  Dim s As String
  Dim CardType As String * 16

  If rdCard <> True Then Exit Sub            '先读卡
  txtStrHex.Text = bufCard
  
  st = GetCardTypeByCardDataStr(bufCard, CardType)
  If st <> 0 Then
    MsgBox "卡数据串无效, 错误代号为: " & CStr(st), 48
  Else
    s = Left(CardType, 1)
    If s = "0" Then
      MsgBox "授权卡"
    ElseIf s = "1" Then
      MsgBox "记录卡"
    ElseIf s = "2" Then
      MsgBox "房号设置卡"
    ElseIf s = "3" Then
      MsgBox "时间设置卡"
    ElseIf s = "4" Then
      MsgBox "限制卡[挂失卡]"
    ElseIf s = "5" Then
      MsgBox "组号设置卡"
    ElseIf s = "6" Then
      MsgBox "客人卡"
    ElseIf s = "7" Then
      MsgBox "退房卡"
    ElseIf s = "8" Then
      MsgBox "组控卡"
    ElseIf s = "9" Then
      MsgBox "未知卡[无此类型]"
    ElseIf s = "A" Then
      MsgBox "应急卡"
    ElseIf s = "B" Then
      MsgBox "总控卡"
    ElseIf s = "C" Then
      MsgBox "楼栋卡"
    ElseIf s = "D" Then
      MsgBox "楼层卡"
    ElseIf s = "E" Then
      MsgBox "未知卡[无此类型]"
    ElseIf s = "F" Then
      MsgBox "空白卡"
    End If
  End If
End Sub

'读取客人卡锁号
Private Sub Command6_Click()
  Dim dlsCoID As Long         '酒店标识
  Dim LockNo As String * 16
  
  If rdCard <> True Then Exit Sub            '先读卡
  txtStrHex.Text = bufCard
  
  dlsCoID = CLng(txtCoID.Text)               '酒店标识
  st = GetGuestLockNoByCardDataStr(dlsCoID, bufCard, LockNo)
  If st = 0 Then
    MsgBox "锁号: " & LockNo, 64
  ElseIf st = 1 Then
    MsgBox "卡数据串无效" & Chr(10) & bufCard, 48
  ElseIf st = 2 Then
    MsgBox "非本酒店卡" & Chr(10) & bufCard, 48
  ElseIf st = 3 Then
    MsgBox "不是客人卡" & Chr(10) & bufCard, 48
  Else
    MsgBox "未知返回值: " & CStr(st) & Chr(10) & bufCard, 48
  End If
End Sub

'读取客人卡离店时间
Private Sub Command7_Click()
  Dim dlsCoID As Long         '酒店标识
  Dim ETime As String * 16
  
  If rdCard <> True Then Exit Sub            '先读卡
  txtStrHex.Text = bufCard
  
  dlsCoID = CLng(txtCoID.Text)               '酒店标识
  st = GetGuestETimeByCardDataStr(dlsCoID, bufCard, ETime)
  If st = 0 Then
    MsgBox "离店时间: " & ETime, 64
  ElseIf st = 1 Then
    MsgBox "卡数据串无效" & Chr(10) & bufCard, 48
  ElseIf st = 2 Then
    MsgBox "非本酒店卡" & Chr(10) & bufCard, 48
  ElseIf st = 3 Then
    MsgBox "不是客人卡" & Chr(10) & bufCard, 48
  Else
    MsgBox "未知返回值: " & CStr(st) & Chr(10) & bufCard, 48
  End If
End Sub

Private Sub Form_Load()
   flagUSB = 1   '默认为pro免驱
   txtCoID = "0"
   Cmdreset_Click
End Sub

Private Sub Option1_Click()
    flagUSB = 0    '有驱
End Sub

Private Sub Option2_Click()
    flagUSB = 1    'pro免驱
End Sub
'关闭程序
Private Sub cmdExit_Click()
    End
End Sub

'读取DLL版本信息
Private Sub cmdGetDllVer_Click()
    Dim s As String * 128
    st = GetDLLVersion(s)
    If st = 0 Then
        MsgBox "DLL版本号为：" & s, 64
    Else
        MsgBox "读DLL版本号错误, 错误代码为：" & CStr(st), 48
    End If
End Sub

'USB初始化
Private Sub Command1_Click()
    st = initializeUSB(flagUSB)
    If st <> 0 Then
        MsgBox "初始化USB端口失败, 错误代号为: " & CStr(st), 16
    Else
        MsgBox "初始化USB端口成功", 64
        Frame2.Enabled = True
        Frame4.Enabled = True
    End If
End Sub

'将输入框恢复到默认值
Private Sub Cmdreset_Click()
    txtCardNo = "1"
    txtLockNo = "01020399"
    txtETime = Format(Now + 1, "YYYY/MM/DD 14:00")
    txtDai = "0"
    txtStrHex = ""
    Option4.Value = True
End Sub

'蜂鸣器
Private Sub Cmdbuzzer_Click()
    Dim st As Integer
    st = Buzzer(flagUSB, 50)   '发卡器鸣叫50x10ms
    If st <> 0 Then
        MsgBox "蜂鸣失败, 错误代号为: " & CStr(st), 16
    End If
End Sub

'从现有卡片读取酒店标识
Private Sub Command3_Click()
  Dim i As Long
  Dim s As String
  
  If rdCard <> True Then Exit Sub            '先读卡
  txtStrHex.Text = bufCard
  
  If Mid(bufCard, 25, 8) = "FFFFFFFF" Then
    txtCoID.Text = ""
    MsgBox "此卡是空白卡，请换一张能开门的卡", 48
    Exit Sub
  End If
  s = Mid(bufCard, 11, 4)
  i = CLng("&H" + s) Mod 16384
  s = Mid(bufCard, 9, 2)
  i = i + (CLng("&H" + s) * 65536)
  txtCoID.Text = CStr(i)
End Sub

