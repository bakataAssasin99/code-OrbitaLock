VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "Demo"
   ClientHeight    =   5670
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   15195
   LinkTopic       =   "Form1"
   ScaleHeight     =   5670
   ScaleWidth      =   15195
   StartUpPosition =   3  '´°¿ÚÈ±Ê¡
   Begin VB.CheckBox ckbLift 
      Caption         =   "Lift Information"
      Height          =   255
      Left            =   8040
      TabIndex        =   76
      Top             =   2160
      Width           =   1815
   End
   Begin VB.CheckBox ckbPs 
      Caption         =   "PowerSwitch Content"
      Height          =   255
      Left            =   240
      TabIndex        =   75
      Top             =   2760
      Width           =   2055
   End
   Begin VB.CheckBox ckbData 
      Caption         =   "Data"
      Height          =   255
      Left            =   240
      TabIndex        =   74
      Top             =   4560
      Width           =   735
   End
   Begin VB.Frame Frame4 
      Caption         =   "Frame4"
      Height          =   975
      Left            =   120
      TabIndex        =   70
      Top             =   4560
      Width           =   7695
      Begin VB.TextBox txtData 
         Height          =   270
         Left            =   840
         TabIndex        =   72
         Top             =   360
         Width           =   6735
      End
      Begin VB.Label Label19 
         Caption         =   "Data:"
         Height          =   255
         Left            =   120
         TabIndex        =   71
         Top             =   360
         Width           =   855
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "Frame3"
      Height          =   1695
      Left            =   120
      TabIndex        =   57
      Top             =   2760
      Width           =   7695
      Begin VB.TextBox txtPWET 
         Height          =   270
         Left            =   5640
         MaxLength       =   12
         TabIndex        =   69
         Text            =   "100313120000"
         Top             =   1200
         Width           =   1935
      End
      Begin VB.TextBox txtGuestName 
         Height          =   270
         Left            =   5640
         TabIndex        =   68
         Text            =   "abcdefgh"
         Top             =   720
         Width           =   1935
      End
      Begin VB.TextBox txtPWLC 
         Height          =   270
         Left            =   5640
         TabIndex        =   67
         Text            =   "000001"
         Top             =   240
         Width           =   1935
      End
      Begin VB.TextBox txtPWBT 
         Height          =   270
         Left            =   1560
         TabIndex        =   66
         Text            =   "100312120000"
         Top             =   1200
         Width           =   1935
      End
      Begin VB.TextBox txtGuestSex 
         Height          =   270
         Left            =   1560
         TabIndex        =   65
         Text            =   "0"
         Top             =   720
         Width           =   1935
      End
      Begin VB.TextBox txtPWCN 
         Height          =   270
         Left            =   1560
         TabIndex        =   64
         Text            =   "1"
         Top             =   240
         Width           =   1935
      End
      Begin VB.Label Label18 
         Caption         =   "BeginTime:"
         Height          =   255
         Left            =   4200
         TabIndex        =   63
         Top             =   1200
         Width           =   975
      End
      Begin VB.Label Label17 
         Caption         =   "GuestName:"
         Height          =   255
         Left            =   4200
         TabIndex        =   62
         Top             =   720
         Width           =   855
      End
      Begin VB.Label Label16 
         Caption         =   "DoorID:"
         Height          =   255
         Left            =   4200
         TabIndex        =   61
         Top             =   240
         Width           =   975
      End
      Begin VB.Label Label15 
         Caption         =   "BeginTime:"
         Height          =   255
         Left            =   120
         TabIndex        =   60
         Top             =   1200
         Width           =   975
      End
      Begin VB.Label Label14 
         Caption         =   "GuestSex:"
         Height          =   255
         Left            =   120
         TabIndex        =   59
         Top             =   720
         Width           =   855
      End
      Begin VB.Label Label13 
         Caption         =   "CardNo:"
         Height          =   255
         Left            =   120
         TabIndex        =   58
         Top             =   360
         Width           =   615
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "Lift Information"
      Height          =   1935
      Left            =   7920
      TabIndex        =   32
      Top             =   2160
      Width           =   7095
      Begin VB.TextBox Text7 
         Height          =   270
         Left            =   4080
         MaxLength       =   4
         TabIndex        =   42
         Text            =   "97"
         Top             =   720
         Width           =   1575
      End
      Begin VB.TextBox Text6 
         Height          =   270
         Left            =   4080
         TabIndex        =   41
         Text            =   "97"
         Top             =   1080
         Width           =   1575
      End
      Begin VB.TextBox Text5 
         Height          =   270
         Left            =   1200
         MaxLength       =   8
         TabIndex        =   40
         Text            =   "96"
         Top             =   1080
         Width           =   1575
      End
      Begin VB.TextBox Text4 
         Height          =   270
         Left            =   1200
         TabIndex        =   39
         Text            =   "FFFF"
         Top             =   1440
         Width           =   4455
      End
      Begin VB.TextBox Text3 
         Height          =   270
         Left            =   1200
         TabIndex        =   35
         Text            =   "1"
         Top             =   360
         Width           =   1575
      End
      Begin VB.TextBox Text2 
         Height          =   270
         Left            =   1200
         MaxLength       =   10
         TabIndex        =   34
         Text            =   "0708181500"
         Top             =   720
         Width           =   1575
      End
      Begin VB.TextBox Text1 
         Height          =   270
         Left            =   4080
         MaxLength       =   10
         TabIndex        =   33
         Text            =   "0708191500"
         Top             =   360
         Width           =   1575
      End
      Begin VB.Label Label7 
         Caption         =   "MaxAddr:"
         Height          =   255
         Left            =   3000
         TabIndex        =   46
         Top             =   720
         Width           =   855
      End
      Begin VB.Label Label6 
         Caption         =   "EndAddr:"
         Height          =   255
         Left            =   3000
         TabIndex        =   45
         Top             =   1080
         Width           =   855
      End
      Begin VB.Label Label5 
         Caption         =   "BeginAddr:"
         Height          =   255
         Left            =   240
         TabIndex        =   44
         Top             =   1080
         Width           =   855
      End
      Begin VB.Label Label4 
         Caption         =   "Data:"
         Height          =   255
         Left            =   240
         TabIndex        =   43
         Top             =   1440
         Width           =   975
      End
      Begin VB.Label Label3 
         Caption         =   "CN:"
         Height          =   255
         Left            =   360
         TabIndex        =   38
         Top             =   360
         Width           =   495
      End
      Begin VB.Label Label2 
         Caption         =   "BT:"
         Height          =   255
         Left            =   360
         TabIndex        =   37
         Top             =   720
         Width           =   615
      End
      Begin VB.Label Label1 
         Caption         =   "ET:"
         Height          =   255
         Left            =   3000
         TabIndex        =   36
         Top             =   360
         Width           =   855
      End
   End
   Begin VB.TextBox txtRepeatTimes 
      Height          =   285
      Left            =   1800
      MaxLength       =   6
      TabIndex        =   31
      Text            =   "1"
      Top             =   2160
      Width           =   1695
   End
   Begin VB.CommandButton comExit 
      Caption         =   "Exit"
      Height          =   495
      Left            =   13680
      TabIndex        =   13
      Top             =   4560
      Width           =   1335
   End
   Begin VB.CommandButton comWrite 
      Caption         =   "Write"
      Height          =   495
      Left            =   12240
      TabIndex        =   12
      Top             =   4560
      Width           =   1215
   End
   Begin VB.CommandButton comRead 
      Caption         =   "Read"
      Height          =   495
      Left            =   10680
      TabIndex        =   11
      Top             =   4560
      Width           =   1335
   End
   Begin VB.Frame Frame1 
      Caption         =   "Card Information"
      Height          =   1935
      Left            =   7920
      TabIndex        =   10
      Top             =   120
      Width           =   7095
      Begin VB.TextBox txtET 
         Height          =   270
         Left            =   4200
         MaxLength       =   10
         TabIndex        =   29
         Text            =   "0708191500"
         Top             =   1440
         Width           =   1575
      End
      Begin VB.TextBox txtGN 
         Height          =   270
         Left            =   4200
         TabIndex        =   28
         Text            =   "1"
         Top             =   1080
         Width           =   1575
      End
      Begin VB.TextBox txtMC 
         Height          =   270
         Left            =   4200
         MaxLength       =   8
         TabIndex        =   27
         Text            =   "00000000"
         Top             =   720
         Width           =   1575
      End
      Begin VB.TextBox txtLC 
         Height          =   270
         Left            =   4200
         MaxLength       =   6
         TabIndex        =   26
         Text            =   "000001"
         Top             =   360
         Width           =   1575
      End
      Begin VB.TextBox txtBT 
         Height          =   270
         Left            =   1080
         MaxLength       =   10
         TabIndex        =   25
         Text            =   "0708181500"
         Top             =   1440
         Width           =   1575
      End
      Begin VB.TextBox txtGI 
         Height          =   270
         Left            =   1080
         TabIndex        =   24
         Text            =   "1"
         Top             =   1080
         Width           =   1575
      End
      Begin VB.TextBox txtNC 
         Height          =   270
         Left            =   1080
         MaxLength       =   4
         TabIndex        =   23
         Text            =   "0000"
         Top             =   720
         Width           =   1575
      End
      Begin VB.TextBox txtCN 
         Height          =   270
         Left            =   1080
         TabIndex        =   22
         Text            =   "1"
         Top             =   360
         Width           =   1575
      End
      Begin VB.Label lblET 
         Caption         =   "ET:"
         Height          =   255
         Left            =   3240
         TabIndex        =   21
         Top             =   1440
         Width           =   855
      End
      Begin VB.Label lblGN 
         Caption         =   "GN:"
         Height          =   255
         Left            =   3240
         TabIndex        =   20
         Top             =   1080
         Width           =   975
      End
      Begin VB.Label lblMC 
         Caption         =   "MC:"
         Height          =   255
         Left            =   3240
         TabIndex        =   19
         Top             =   720
         Width           =   855
      End
      Begin VB.Label lblLC 
         Caption         =   "LC:"
         Height          =   255
         Left            =   3240
         TabIndex        =   18
         Top             =   360
         Width           =   735
      End
      Begin VB.Label lblBT 
         Caption         =   "BT:"
         Height          =   255
         Left            =   360
         TabIndex        =   17
         Top             =   1440
         Width           =   615
      End
      Begin VB.Label lblGI 
         Caption         =   "GI:"
         Height          =   255
         Left            =   360
         TabIndex        =   16
         Top             =   1080
         Width           =   495
      End
      Begin VB.Label lblNC 
         Caption         =   "NC:"
         Height          =   255
         Left            =   360
         TabIndex        =   15
         Top             =   720
         Width           =   495
      End
      Begin VB.Label lblCN 
         Caption         =   "CN:"
         Height          =   255
         Left            =   360
         TabIndex        =   14
         Top             =   360
         Width           =   495
      End
   End
   Begin VB.Frame freSystemSetting 
      Caption         =   "System Setting"
      Height          =   2535
      Left            =   3720
      TabIndex        =   5
      Top             =   120
      Width           =   4095
      Begin VB.TextBox txtDataSectorNo 
         Height          =   270
         Left            =   2040
         TabIndex        =   56
         Text            =   "3"
         Top             =   2160
         Width           =   1935
      End
      Begin VB.TextBox txtDataPWD 
         Height          =   270
         Left            =   2040
         TabIndex        =   55
         Text            =   "FFFFFFFFFFFF"
         Top             =   1800
         Width           =   1935
      End
      Begin VB.TextBox txtPSSectorNo 
         Height          =   270
         Left            =   2040
         TabIndex        =   54
         Text            =   "15"
         Top             =   1440
         Width           =   1935
      End
      Begin VB.TextBox txtPSW 
         Height          =   270
         Left            =   2040
         TabIndex        =   53
         Text            =   "FFFFFFFFFFFF"
         Top             =   1080
         Width           =   1935
      End
      Begin VB.TextBox txtSectorNo 
         Height          =   285
         Left            =   2040
         MaxLength       =   2
         TabIndex        =   9
         Text            =   "0"
         Top             =   720
         Width           =   1935
      End
      Begin VB.TextBox txtSystemPassword 
         Height          =   285
         Left            =   2040
         MaxLength       =   6
         TabIndex        =   8
         Top             =   360
         Width           =   1935
      End
      Begin VB.Label Label12 
         Caption         =   "DataSectorNo:"
         Height          =   255
         Left            =   120
         TabIndex        =   52
         Top             =   2160
         Width           =   1215
      End
      Begin VB.Label Label11 
         Caption         =   "DataSectorPwd:"
         Height          =   255
         Left            =   120
         TabIndex        =   51
         Top             =   1800
         Width           =   1215
      End
      Begin VB.Label Label10 
         Caption         =   "PowerSwitchSectorNo:"
         Height          =   255
         Left            =   120
         TabIndex        =   50
         Top             =   1440
         Width           =   1815
      End
      Begin VB.Label Label9 
         Caption         =   "PowerSwitchPwd:"
         Height          =   255
         Left            =   120
         TabIndex        =   49
         Top             =   1080
         Width           =   1335
      End
      Begin VB.Label lblSectorNo 
         Caption         =   "Sector No:"
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   720
         Width           =   1095
      End
      Begin VB.Label lblsystemPwd 
         Caption         =   "System Password:"
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Top             =   360
         Width           =   1455
      End
   End
   Begin VB.Frame freconnection 
      Caption         =   "Connection Setting"
      Height          =   2535
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3495
      Begin VB.ComboBox cmbPM 
         Height          =   300
         ItemData        =   "frmMain.frx":0000
         Left            =   1680
         List            =   "frmMain.frx":000A
         TabIndex        =   48
         Text            =   "8602-1M-57BA"
         Top             =   1500
         Width           =   1695
      End
      Begin VB.ComboBox cmbDP 
         Height          =   300
         ItemData        =   "frmMain.frx":002A
         Left            =   1680
         List            =   "frmMain.frx":003A
         TabIndex        =   4
         Text            =   "COM1"
         Top             =   930
         Width           =   1695
      End
      Begin VB.ComboBox cmbDM 
         Height          =   300
         ItemData        =   "frmMain.frx":0056
         Left            =   1680
         List            =   "frmMain.frx":0069
         TabIndex        =   3
         Text            =   "RW-21"
         Top             =   360
         Width           =   1695
      End
      Begin VB.Label Label8 
         Caption         =   "PowerSwitchType:"
         Height          =   255
         Left            =   120
         TabIndex        =   47
         Top             =   1500
         Width           =   1455
      End
      Begin VB.Label lblRepeatTimes 
         Caption         =   "Repeat Times:"
         Height          =   255
         Left            =   120
         TabIndex        =   30
         Top             =   2040
         Width           =   1215
      End
      Begin VB.Label lblPortNo 
         Caption         =   "Port No:"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   930
         Width           =   735
      End
      Begin VB.Label lblReaderModel 
         Caption         =   "Reader Model:"
         Height          =   255
         Left            =   120
         TabIndex        =   1
         Top             =   360
         Width           =   1215
      End
   End
   Begin VB.Label lReturnValue 
      Height          =   255
      Left            =   8160
      TabIndex        =   73
      Top             =   4920
      Width           =   1335
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim strPWD As String * 6
Dim strPsPWD As String * 12
Dim strDataPWD As String * 12
Dim strBeginTime As String * 12
Dim strEndTime As String * 12
Dim strSuitDoor As String * 4
Dim strPubDoor As String * 8
Dim strGuestName As String * 8
Dim strLockID As String * 6
Dim strLiftData As String * 128
Dim strData As String * 32
Dim bPort, bReaderType, iSectorNo, bAlarmCount, bGuestSex, bPowerSwitchType As Byte
Dim iCardNo, iGuestSN, iBeginAddr, iEndAddr, iMaxAddr As Long
Dim result, iGuestIdx As Integer

Private Sub comExit_Click()
  End
End Sub

Private Sub comRead_Click()
  bPort = cmbDP.ItemData(cmbDP.ListIndex)
  bReaderType = cmbDM.ItemData(cmbDM.ListIndex)
  bAlarmCount = txtRepeatTimes.Text
  strPWD = txtSystemPassword.Text
  iSectorNo = txtSectorNo.Text
  result = Read_Guest_Card(bPort, bReaderType, iSectorNo, strPWD, iCardNo, iGuestSN, iGuestIdx, strLockID, strSuitDoor, strPubDoor, strBeginTime, strEndTime)
  If result = 0 Then
    txtLC.Text = strLockID
    txtCN.Text = iCardNo
    txtGI.Text = iGuestSN
    txtGN.Text = iGuestIdx
    txtNC.Text = strSuitDoor
    txtMC.Text = strPubDoor
    txtBT.Text = strBeginTime
    txtET.Text = strEndTime
    
    If ckbLift.Value = 1 Then
        iBeginAddr = Text5.Text
        iEndAddr = Text6.Text
        result = Read_Guest_Lift(bPort, bReaderType, iSectorNo, strPWD, iBeginAddr, iEndAddr, iCardNo, strBeginTime, strEndTime, strLiftData)
        If result = 0 Then
            Text2.Text = strBeginTime
            Text1.Text = strEndTime
            Text3.Text = iCardNo
            Text4.Text = strLiftData
        End If
    End If
    
    If ckbPs.Value = 1 Then
        trPsPWD = txtPSW.Text
        iSectorNo = txtPSSectorNo.Text
        bPowerSwitchType = cmbPM.ItemData(cmbPM.ListIndex)
        result = Read_Guest_PowerSwitch(bPort, bReaderType, iSectorNo, strPsPWD, iCardNo, bGuestSex, strLockID, strGuestName, strBeginTime, strEndTime, bPowerSwitchType)
        If result = 0 Then
            txtPWCN.Text = iCardNo
            txtPWLC.Text = strLockID
            txtGuestSex.Text = bGuestSex
            txtGuestName.Text = strGuestName
            txtPWBT.Text = strBeginTime
            txtPWET.Text = strEndTime
        End If
    End If
                    
    If ckbData.Value = 1 Then
        strDataPWD = txtDataPWD.Text
        iSectorNo = txtDataSectorNo.Text
        result = Read_Data(bPort, bReaderType, iSectorNo, strDataPWD, strData)
        If result = 0 Then
            txtData.Text = strData
        End If
    End If
End If

lReturnValue.Caption = result
                    
If result = 0 Then
    result = Reader_Alarm(bPort, bReaderType, bAlarmCount)
    MsgBox ("Read Guest Card Success!")
Else
    MsgBox ("Read Guest Card Fail!")
End If
End Sub

Private Sub comWrite_Click()
  bPort = cmbDP.ItemData(cmbDP.ListIndex)
  bReaderType = cmbDM.ItemData(cmbDM.ListIndex)
  strPWD = txtSystemPassword.Text
  bAlarmCount = txtRepeatTimes.Text
  iSectorNo = txtSectorNo.Text
  strLockID = txtLC.Text
  iCardNo = txtCN.Text
  iGuestSN = txtGI.Text
  iGuestIdx = txtGN.Text
  strSuitDoor = txtNC.Text
  strPubDoor = txtMC.Text
  strBeginTime = txtBT.Text
  strEndTime = txtET.Text
  iBeginAddr = Text5.Text
  iEndAddr = Text6.Text
  iMaxAddr = Text7.Text
  strLiftData = Text4.Text
  result = Write_Guest_Card(bPort, bReaderType, iSectorNo, strPWD, iCardNo, iGuestSN, iGuestIdx, strLockID, strSuitDoor, strPubDoor, strBeginTime, strEndTime)
  
  If result = 0 And ckbLift.Value = 1 Then
    strBeginTime = Text2.Text
    strEndTime = Text1.Text
    iCardNo = Text3.Text
    result = Write_Guest_Lift(bPort, bReaderType, iSectorNo, strPWD, iCardNo, iBeginAddr, iEndAddr, iMaxAddr, strBeginTime, strEndTime, strLiftData)
  End If
  
  If result = 0 And ckbPs.Value = 1 Then
    strPsPWD = txtPSW.Text
    iSectorNo = txtPSSectorNo.Text
    bPowerSwitchType = cmbPM.ItemData(cmbPM.ListIndex)
    iCardNo = txtPWCN.Text
    strLockID = txtPWLC.Text
    bGuestSex = txtGuestSex.Text
    strGuestName = txtGuestName.Text
    strBeginTime = txtPWBT.Text
    strEndTime = txtPWET.Text
    result = Write_Guest_PowerSwitch(bPort, bReaderType, iSectorNo, strPsPWD, iCardNo, bGuestSex, strLockID, strGuestName, strBeginTime, strEndTime, bPowerSwitchType)
  End If
  
  If result = 0 And ckbData.Value = 1 Then
    strDataPWD = txtDataPWD.Text
    iSectorNo = txtDataSectorNo.Text
    strData = txtData.Text
    result = Write_Data(bPort, bReaderType, iSectorNo, strDataPWD, strData)
  End If
  
  lReturnValue.Caption = result
                    
  If result = 0 Then
    result = Reader_Alarm(bPort, bReaderType, bAlarmCount)
    MsgBox ("Write Guest Card Success!")
  Else
    MsgBox ("Write Guest Card Fail!")
  End If
End Sub

Private Sub Form_Initialize()
  cmbDM.ListIndex = 0
  cmbDP.ListIndex = 0
  cmbPM.ListIndex = 0
End Sub

