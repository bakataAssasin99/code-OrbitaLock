VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Demo"
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
      Caption         =   "Normal Function"
      Enabled         =   0   'False
      Height          =   4695
      Left            =   8280
      TabIndex        =   31
      Top             =   1560
      Width           =   3615
      Begin VB.CommandButton Command7 
         Caption         =   "Check-Out Time [GetGuestETimeByCardDataStr]"
         Height          =   615
         Left            =   240
         TabIndex        =   39
         Top             =   3960
         Width           =   3135
      End
      Begin VB.CommandButton Command6 
         Caption         =   "[GetGuestLockNoByCardDataStr]"
         Height          =   615
         Left            =   240
         TabIndex        =   38
         Top             =   3360
         Width           =   3135
      End
      Begin VB.CommandButton Command5 
         Caption         =   "[GetCardTypeByCardDataStr]"
         Height          =   615
         Left            =   240
         TabIndex        =   37
         Top             =   2760
         Width           =   3135
      End
      Begin VB.CommandButton Command4 
         Caption         =   "Limit Card [LimitCard]"
         Height          =   495
         Left            =   480
         TabIndex        =   36
         Top             =   2160
         Width           =   2655
      End
      Begin VB.CommandButton Command2 
         Caption         =   " Erase Card [CardErase]"
         Height          =   495
         Left            =   480
         TabIndex        =   35
         Top             =   1680
         Width           =   2655
      End
      Begin VB.CommandButton cmdbuzzer 
         Caption         =   "Beep [Buzzer]"
         Height          =   495
         Left            =   480
         TabIndex        =   34
         Top             =   240
         Width           =   2655
      End
      Begin VB.CommandButton cmdwritecard 
         Caption         =   "Issue Guest Card [GuestCard]"
         Height          =   495
         Left            =   480
         TabIndex        =   33
         Top             =   1200
         Width           =   2655
      End
      Begin VB.CommandButton cmdreadcard 
         Caption         =   "Read Card Data [ReadCard]"
         Height          =   495
         Left            =   480
         TabIndex        =   32
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
      TabIndex        =   27
      Text            =   "txtStrHex"
      Top             =   5880
      Width           =   8055
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   495
      Left            =   8520
      TabIndex        =   24
      Top             =   840
      Width           =   3135
   End
   Begin VB.CommandButton cmdGetDllVer 
      Caption         =   "DLL Version[GetDllVersion]"
      Height          =   495
      Left            =   8520
      TabIndex        =   23
      Top             =   240
      Width           =   3135
   End
   Begin VB.Frame Frame3 
      Caption         =   "Note"
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
      Begin VB.Label Label9 
         Caption         =   "3, Function GetDLLVersion always can be called "
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   360
         TabIndex        =   18
         Top             =   1440
         Width           =   5535
      End
      Begin VB.Label Label8 
         Caption         =   $"Form1.frx":0000
         ForeColor       =   &H00008000&
         Height          =   615
         Left            =   360
         TabIndex        =   17
         Top             =   720
         Width           =   7575
      End
      Begin VB.Label Label7 
         Caption         =   "1, The USB Reader must be initialized before you operate it or cards"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   360
         TabIndex        =   16
         Top             =   360
         Width           =   7575
      End
   End
   Begin VB.CommandButton Command1 
      Caption         =   "1st Step: Open USB [initializeUSB]"
      Height          =   735
      Left            =   4200
      TabIndex        =   3
      Top             =   480
      Width           =   3735
   End
   Begin VB.OptionButton Option2 
      Caption         =   "proUSB(Plug-In and Play)"
      Height          =   495
      Left            =   360
      TabIndex        =   2
      Top             =   840
      Value           =   -1  'True
      Width           =   3615
   End
   Begin VB.OptionButton Option1 
      Caption         =   "USB Reader(Need install Driver)"
      Height          =   495
      Left            =   360
      TabIndex        =   1
      Top             =   360
      Width           =   3615
   End
   Begin VB.Frame Frame1 
      Caption         =   "Open USB Port"
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
      Caption         =   "Card Operation"
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
         Caption         =   "unlock deadbolt"
         Height          =   255
         Left            =   1200
         TabIndex        =   30
         Top             =   3360
         Value           =   -1  'True
         Width           =   1935
      End
      Begin VB.OptionButton Option3 
         Caption         =   "Can't Open deadbolt"
         Height          =   300
         Left            =   3240
         TabIndex        =   29
         Top             =   3360
         Width           =   3015
      End
      Begin VB.CommandButton cmdreset 
         Caption         =   "Default"
         Height          =   495
         Left            =   6360
         TabIndex        =   25
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
         TabIndex        =   21
         Text            =   "txtCoID"
         Top             =   360
         Width           =   1575
      End
      Begin VB.CommandButton Command3 
         Caption         =   "Read coID from card on reader"
         Height          =   375
         Left            =   4080
         TabIndex        =   20
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
         Caption         =   "( 01020399 Means Building 01,Floolr 02, Room ID 03 )"
         ForeColor       =   &H000000FF&
         Height          =   495
         Left            =   3960
         TabIndex        =   26
         Top             =   1320
         Width           =   3855
      End
      Begin VB.Label Label23 
         Alignment       =   1  'Right Justify
         Caption         =   "Hotel ID [coID]："
         Height          =   255
         Left            =   360
         TabIndex        =   22
         Top             =   360
         Width           =   1695
      End
      Begin VB.Label Label28 
         Caption         =   "You can get Lock No. in the Card Lock Management System"
         ForeColor       =   &H000000FF&
         Height          =   375
         Left            =   840
         TabIndex        =   19
         Top             =   1800
         Width           =   6495
      End
      Begin VB.Label Label5 
         Caption         =   "（0-255）"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   3240
         TabIndex        =   14
         Top             =   2880
         Width           =   1575
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         Caption         =   "Guest Dai[Dai]："
         Height          =   255
         Left            =   120
         TabIndex        =   12
         Top             =   2880
         Width           =   1935
      End
      Begin VB.Label Label29 
         Alignment       =   1  'Right Justify
         Caption         =   "Check Out[eTime]："
         Height          =   255
         Left            =   120
         TabIndex        =   10
         Top             =   2400
         Width           =   1935
      End
      Begin VB.Label Label27 
         Alignment       =   1  'Right Justify
         Caption         =   "Lock No.[LockNo]："
         Height          =   255
         Left            =   240
         TabIndex        =   8
         Top             =   1440
         Width           =   1815
      End
      Begin VB.Label Label2 
         Caption         =   "（0-15,most 16 cards in 1 minute）"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   3960
         TabIndex        =   7
         Top             =   960
         Width           =   3855
      End
      Begin VB.Label Label22 
         Alignment       =   1  'Right Justify
         Caption         =   "Card No.[CardNo]："
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   960
         Width           =   1815
      End
   End
   Begin VB.Label Label3 
      Caption         =   "Card Data[CardHexStr]："
      Height          =   255
      Left            =   120
      TabIndex        =   28
      Top             =   5520
      Width           =   7935
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Read Card Data
Private Sub cmdreadcard_Click()
  If rdCard <> True Then Exit Sub            'Read Card First
  txtStrHex.Text = bufCard
  MsgBox "Card ID：" & Mid(bufCard, 25, 8), 64
End Sub

'Issue a Guest Card
Private Sub cmdwritecard_Click()
  Dim llock As Byte         'Flag of Deadbolt
  Dim pdoors As Byte        'Flag of public door
  Dim dlsCoID As Long       'Hotel ID
  Dim CardNo As Integer     'Card No.(0-15)
  Dim dai As Integer        'Guest Dai
  Dim BTime As String       'Time of Issue card, Just the current time,now
  Dim ETime As String       'Check Out
  Dim LockNo As String      'Lock No.
  
  If rdCard <> True Then Exit Sub            'Read Card First
  txtStrHex.Text = bufCard
  
  If Option4.Value = True Then               'Flag of Deadbolt
    llock = 1
  Else
    llock = 0
  End If
  
  pdoors = 0                                   'Flag of public Door
  dlsCoID = CLng(txtCoID.Text)                 'Hotel ID
  CardNo = CInt(txtCardNo.Text) Mod 16         'Card No.(0-15)
  dai = CInt(txtDai.Text) Mod 256              'Guest Dai
  BTime = Format(Now, "YYMMDDHHMM")            'Time of Issue Card,Now
  ETime = Format(txtETime.Text, "YYMMDDHHMM")  'Check Out
  LockNo = txtLockNo.Text
  
  st = GuestCard(flagUSB, dlsCoID, CardNo, dai, llock, pdoors, BTime, ETime, LockNo, bufHexStr)
  If flagUSB = 1 Then Buzzer flagUSB, 20     'Beep
  txtStrHex.Text = bufHexStr
  If st <> 0 Then
    MsgBox "Call Function GuestCard Failure, The Error Code is : " & CStr(st), 16
  Else
    MsgBox "Call Function GuestCard Success" & Chr(10) & Chr(10) & "Note: It is maybe not write data to the card, Please Call Function ReadCard 1 second later." & Chr(10) & "if bufHexStr of GuestCard and ReadCard is same, means write card success", 64
  End If

End Sub

'Erase Card
Private Sub Command2_Click()
  Dim dlsCoID As Long       'Hotel ID
  
  If rdCard <> True Then Exit Sub            'Read Card First
  txtStrHex.Text = bufCard
  
  dlsCoID = CLng(txtCoID.Text)               'Hotel ID
  st = CardErase(flagUSB, dlsCoID, bufHexStr)
  If flagUSB = 1 Then Buzzer flagUSB, 20   'Beep
  txtStrHex.Text = bufHexStr
  If st <> 0 Then
    MsgBox "Call Function CardErase Failure, The Error Code is: " & CStr(st), 16
  Else
    MsgBox "This Card has been Erased", 64
  End If
End Sub

'Limit Card
Private Sub Command4_Click()
  Dim dlsCoID As Long         'Hotel ID
  Dim limitNo As String * 4   'Card ID which lost
  Dim dai As Integer          'Dai
    
  If rdCard <> True Then Exit Sub            'Read Card First
  txtStrHex.Text = bufCard
  
  dlsCoID = CLng(txtCoID.Text)               'Hotel ID
  CardNo = CInt(txtCardNo.Text) Mod 16       'Card No.(0-15)
  dai = CInt(txtDai.Text) Mod 256            'Dai
  BTime = Format(Now, "YYMMDDHHMM")          'Time of Issue card,now
  limitNo = Chr(&H60) & Chr(&H12) & Chr(&HD2) & Chr(&H91)    'Card ID which lost: 6012D291
  
  st = LimitCard(flagUSB, dlsCoID, CardNo, dai, BTime, limitNo, bufHexStr)
  If flagUSB = 1 Then Buzzer flagUSB, 20    'Beep
  txtStrHex.Text = bufHexStr
  If st <> 0 Then
    MsgBox "all Function LimitCard Failure, The Error Code is: " & CStr(st), 16
  Else
    MsgBox "Call Function LimitCard Success" & Chr(10) & "The Car ID of this Demo is: 6012D291", 64
  End If
End Sub

'Get Card Type
Private Sub Command5_Click()
  Dim s As String
  Dim CardType As String * 16

  If rdCard <> True Then Exit Sub            'Read Card First
  txtStrHex.Text = bufCard
  
  st = GetCardTypeByCardDataStr(bufCard, CardType)
  If st <> 0 Then
    MsgBox "Invalid Data String, Error Code is: " & CStr(st), 48
  Else
    s = Left(CardType, 1)
    If s = "0" Then
      MsgBox "System Card"
    ElseIf s = "1" Then
      MsgBox "Record Card"
    ElseIf s = "2" Then
      MsgBox "Room No. Setting Card"
    ElseIf s = "3" Then
      MsgBox "Time Setting Card"
    ElseIf s = "4" Then
      MsgBox "Limit Card"
    ElseIf s = "5" Then
      MsgBox "Group No. Setting Card"
    ElseIf s = "6" Then
      MsgBox "Guest Card"
    ElseIf s = "7" Then
      MsgBox "Check-Out Card"
    ElseIf s = "8" Then
      MsgBox "Group Card"
    ElseIf s = "9" Then
      MsgBox "Unknown Card Type"
    ElseIf s = "A" Then
      MsgBox "Emergency Card"
    ElseIf s = "B" Then
      MsgBox "Master Card"
    ElseIf s = "C" Then
      MsgBox "Building Card"
    ElseIf s = "D" Then
      MsgBox "Floor Card"
    ElseIf s = "E" Then
      MsgBox "Unknown Card Type"
    ElseIf s = "F" Then
      MsgBox "Blank Card"
    End If
  End If
End Sub

'Get Lock No.
Private Sub Command6_Click()
  Dim dlsCoID As Long         'Hotel ID
  Dim LockNo As String * 16
  
  If rdCard <> True Then Exit Sub            'Read Card First
  txtStrHex.Text = bufCard
  
  dlsCoID = CLng(txtCoID.Text)               'Hotel ID
  st = GetGuestLockNoByCardDataStr(dlsCoID, bufCard, LockNo)
  If st = 0 Then
    MsgBox "Lock No.: " & LockNo, 64
  ElseIf st = 1 Then
    MsgBox "Invalid Data String" & Chr(10) & bufCard, 48
  ElseIf st = 2 Then
    MsgBox "Not a card in this system" & Chr(10) & bufCard, 48
  ElseIf st = 3 Then
    MsgBox "Not a Guest Card" & Chr(10) & bufCard, 48
  Else
    MsgBox "Unknown return: " & CStr(st) & Chr(10) & bufCard, 48
  End If
End Sub

'Get Card's Check Out Time
Private Sub Command7_Click()
  Dim dlsCoID As Long         'Hotel ID
  Dim ETime As String * 16
  
  If rdCard <> True Then Exit Sub            'Read Card First
  txtStrHex.Text = bufCard
  
  dlsCoID = CLng(txtCoID.Text)               'Hotel ID
  st = GetGuestETimeByCardDataStr(dlsCoID, bufCard, ETime)
  If st = 0 Then
    MsgBox "Check-Out: " & ETime, 64
  ElseIf st = 1 Then
    MsgBox "Invalid Data String" & Chr(10) & bufCard, 48
  ElseIf st = 2 Then
    MsgBox "Not a card in this system" & Chr(10) & bufCard, 48
  ElseIf st = 3 Then
    MsgBox "Not a Guest Card" & Chr(10) & bufCard, 48
  Else
    MsgBox "Unknown return: " & CStr(st) & Chr(10) & bufCard, 48
  End If
End Sub

Private Sub Form_Load()
   flagUSB = 1   'Default proUSB
   txtCoID = "0"
   Cmdreset_Click
End Sub

Private Sub Option1_Click()
    flagUSB = 0    'USB
End Sub

Private Sub Option2_Click()
    flagUSB = 1    'proUSB
End Sub
'Exit the Demo
Private Sub cmdExit_Click()
    End
End Sub

'Get the DLL version
Private Sub cmdGetDllVer_Click()
    Dim s As String * 128
    st = GetDLLVersion(s)
    If st = 0 Then
        MsgBox "DLL Version：" & s, 64
    Else
        MsgBox "Error Code is：" & CStr(st), 48
    End If
End Sub

'USB initialization
Private Sub Command1_Click()
    st = initializeUSB(flagUSB)
    If st <> 0 Then
        MsgBox "Initialize USB failure, Error Code is: " & CStr(st), 16
    Else
        MsgBox "Initialize USB Success", 64
        Frame2.Enabled = True
        Frame4.Enabled = True
    End If
End Sub

'Default
Private Sub Cmdreset_Click()
    txtCardNo = "1"
    txtLockNo = "01020399"
    txtETime = Format(Now + 1, "YYYY/MM/DD 14:00")
    txtDai = "0"
    txtStrHex = ""
    Option4.Value = True
End Sub

'Beep
Private Sub Cmdbuzzer_Click()
    Dim st As Integer
    st = Buzzer(flagUSB, 50)   'Beep 50x10ms
    If st <> 0 Then
        MsgBox "Beep Failure, Error Code is: " & CStr(st), 16
    End If
End Sub

'Get coID from card on Reader
Private Sub Command3_Click()
  Dim i As Long
  Dim s As String
  
  If rdCard <> True Then Exit Sub            'Read Card First
  txtStrHex.Text = bufCard
  
  If Mid(bufCard, 25, 8) = "FFFFFFFF" Then
    txtCoID.Text = ""
    MsgBox "This is a blank card, Please put a card which could open door on the reader", 48
    Exit Sub
  End If
  s = Mid(bufCard, 11, 4)
  i = CLng("&H" + s) Mod 16384
  s = Mid(bufCard, 9, 2)
  i = i + (CLng("&H" + s) * 65536)
  txtCoID.Text = CStr(i)
End Sub

