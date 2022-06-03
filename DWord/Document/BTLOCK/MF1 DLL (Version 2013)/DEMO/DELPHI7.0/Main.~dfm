object frmMain: TfrmMain
  Left = 202
  Top = 184
  Width = 1017
  Height = 485
  BorderIcons = [biSystemMenu]
  Caption = 'MF v5.7 Interface Demo'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnCreate = FormCreate
  DesignSize = (
    1009
    451)
  PixelsPerInch = 96
  TextHeight = 13
  object gpbConnection: TGroupBox
    Left = 8
    Top = 8
    Width = 248
    Height = 209
    Caption = 'Connection Setting'
    TabOrder = 0
    object lblRepeatTimes: TLabel
      Left = 8
      Top = 178
      Width = 57
      Height = 13
      Caption = 'AlarmCount:'
    end
    object cmbDM: TComboBox
      Left = 116
      Top = 24
      Width = 120
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      ItemIndex = 0
      TabOrder = 0
      Text = 'RW-21'
      Items.Strings = (
        'RW-21'
        'RW-33'
        'RW-26B'
        'RW-41')
    end
    object stxText2: TStaticText
      Left = 8
      Top = 28
      Width = 66
      Height = 17
      Caption = 'ReaderType:'
      ParentShowHint = False
      ShowHint = False
      TabOrder = 1
    end
    object stxText3: TStaticText
      Left = 8
      Top = 78
      Width = 26
      Height = 17
      Caption = 'Port:'
      TabOrder = 2
    end
    object cmbDP: TComboBox
      Left = 116
      Top = 74
      Width = 120
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      ItemIndex = 0
      TabOrder = 3
      Text = 'COM1'
      Items.Strings = (
        'COM1'
        'COM2'
        'COM3'
        'COM4')
    end
    object edtRepeatTimes: TEdit
      Left = 116
      Top = 174
      Width = 120
      Height = 21
      TabOrder = 4
      Text = '1'
    end
    object StaticText6: TStaticText
      Left = 8
      Top = 128
      Width = 93
      Height = 17
      Caption = 'PowerSwitchType:'
      ParentShowHint = False
      ShowHint = False
      TabOrder = 5
    end
    object cmbPM: TComboBox
      Left = 116
      Top = 124
      Width = 120
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      ItemIndex = 0
      TabOrder = 6
      Text = '8602-1M-57BA'
      Items.Strings = (
        '8602-1M-57BA'
        '8601-6M-57BA')
    end
  end
  object gpbCardFields: TGroupBox
    Left = 544
    Top = 8
    Width = 457
    Height = 150
    TabOrder = 1
    object stxText17: TLabel
      Left = 8
      Top = 118
      Width = 53
      Height = 13
      Caption = 'BeginTime:'
    end
    object stxText9: TStaticText
      Left = 8
      Top = 28
      Width = 43
      Height = 17
      Caption = 'CardNo:'
      TabOrder = 0
    end
    object edtCN: TEdit
      Left = 100
      Top = 24
      Width = 120
      Height = 21
      TabOrder = 1
      Text = '1'
    end
    object stxText10: TStaticText
      Left = 260
      Top = 28
      Width = 41
      Height = 17
      Caption = 'DoorID:'
      TabOrder = 2
    end
    object edtLC: TEdit
      Left = 328
      Top = 24
      Width = 120
      Height = 21
      MaxLength = 6
      TabOrder = 3
      Text = '000001'
    end
    object stxText11: TStaticText
      Left = 8
      Top = 58
      Width = 48
      Height = 17
      Caption = 'SuitDoor:'
      TabOrder = 4
    end
    object edtSC: TEdit
      Left = 100
      Top = 54
      Width = 120
      Height = 21
      MaxLength = 4
      TabOrder = 5
      Text = '0000'
    end
    object stxText12: TStaticText
      Left = 260
      Top = 58
      Width = 49
      Height = 17
      Caption = 'PubDoor:'
      TabOrder = 6
    end
    object edtGC: TEdit
      Left = 328
      Top = 54
      Width = 120
      Height = 21
      MaxLength = 8
      TabOrder = 7
      Text = '00000000'
    end
    object stxText13: TStaticText
      Left = 8
      Top = 88
      Width = 50
      Height = 17
      Caption = 'GuestSN:'
      TabOrder = 8
    end
    object stxText14: TStaticText
      Left = 260
      Top = 88
      Width = 49
      Height = 17
      Caption = 'GuestIdx:'
      TabOrder = 9
    end
    object stxText16: TStaticText
      Left = 260
      Top = 118
      Width = 49
      Height = 17
      Caption = 'EndTime:'
      TabOrder = 10
    end
    object edtPI: TEdit
      Left = 100
      Top = 84
      Width = 120
      Height = 21
      TabOrder = 11
      Text = '1'
    end
    object edtPN: TEdit
      Left = 328
      Top = 84
      Width = 120
      Height = 21
      TabOrder = 12
      Text = '1'
    end
    object edtET: TEdit
      Left = 328
      Top = 114
      Width = 120
      Height = 21
      MaxLength = 10
      TabOrder = 13
      Text = '1003131200'
    end
    object edtBT: TEdit
      Left = 100
      Top = 114
      Width = 120
      Height = 21
      MaxLength = 10
      TabOrder = 14
      Text = '1003121200'
    end
  end
  object btnRead: TButton
    Left = 760
    Top = 393
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = '&Read'
    TabOrder = 2
    OnClick = btnReadClick
  end
  object btnExit: TButton
    Left = 920
    Top = 393
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = '&Exit'
    TabOrder = 3
    OnClick = btnExitClick
  end
  object stbInfo: TStatusBar
    Left = 0
    Top = 431
    Width = 1009
    Height = 20
    Panels = <
      item
        Alignment = taCenter
        Text = 'Return Value'
        Width = 100
      end
      item
        Alignment = taCenter
        Width = 50
      end
      item
        Width = 50
      end>
  end
  object btnWrite: TButton
    Left = 840
    Top = 393
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = '&Write'
    TabOrder = 5
    OnClick = btnWriteClick
  end
  object gpbCardSetting: TGroupBox
    Left = 263
    Top = 8
    Width = 270
    Height = 209
    Caption = 'System Setting'
    TabOrder = 6
    object lblSectorNo: TLabel
      Left = 8
      Top = 58
      Width = 48
      Height = 13
      Caption = 'SectorNo:'
    end
    object Label7: TLabel
      Left = 8
      Top = 118
      Width = 110
      Height = 13
      Caption = 'PowerSwitchSectorNo:'
    end
    object Label8: TLabel
      Left = 8
      Top = 178
      Width = 71
      Height = 13
      Caption = 'DataSectorNo:'
    end
    object edtSP: TEdit
      Left = 136
      Top = 24
      Width = 120
      Height = 21
      MaxLength = 6
      TabOrder = 0
    end
    object stxText8: TStaticText
      Left = 8
      Top = 28
      Width = 53
      Height = 17
      Caption = 'HotelPwd:'
      TabOrder = 1
    end
    object edtSectorNo: TEdit
      Left = 136
      Top = 54
      Width = 120
      Height = 21
      MaxLength = 2
      TabOrder = 2
      Text = '0'
    end
    object StaticText5: TStaticText
      Left = 8
      Top = 88
      Width = 90
      Height = 17
      Caption = 'PowerSwitchPwd:'
      TabOrder = 3
    end
    object edtPSW: TEdit
      Left = 136
      Top = 84
      Width = 120
      Height = 21
      MaxLength = 12
      TabOrder = 4
      Text = 'FFFFFFFFFFFF'
    end
    object edtPSSectorNo: TEdit
      Left = 136
      Top = 114
      Width = 120
      Height = 21
      MaxLength = 2
      TabOrder = 5
      Text = '15'
    end
    object StaticText10: TStaticText
      Left = 8
      Top = 148
      Width = 82
      Height = 17
      Caption = 'DataSectorPwd:'
      TabOrder = 6
    end
    object edtDataSectorID: TEdit
      Left = 136
      Top = 144
      Width = 120
      Height = 21
      MaxLength = 12
      TabOrder = 7
    end
    object edtDataSectorNo: TEdit
      Left = 136
      Top = 172
      Width = 120
      Height = 21
      MaxLength = 2
      TabOrder = 8
      Text = '3'
    end
  end
  object gpbLiftFields: TGroupBox
    Left = 544
    Top = 165
    Width = 457
    Height = 150
    TabOrder = 7
    object Label1: TLabel
      Left = 260
      Top = 28
      Width = 53
      Height = 13
      Caption = 'BeginTime:'
    end
    object Label2: TLabel
      Left = 8
      Top = 118
      Width = 40
      Height = 13
      Caption = 'LiftData:'
    end
    object Label3: TLabel
      Left = 8
      Top = 88
      Width = 52
      Height = 13
      Caption = 'BeginAddr:'
    end
    object Label4: TLabel
      Left = 260
      Top = 88
      Width = 44
      Height = 13
      Caption = 'EndAddr:'
    end
    object Label5: TLabel
      Left = 260
      Top = 58
      Width = 59
      Height = 13
      Caption = 'MaxLiftAddr:'
    end
    object Edit1: TEdit
      Left = 100
      Top = 24
      Width = 120
      Height = 21
      TabOrder = 0
      Text = '1'
    end
    object StaticText1: TStaticText
      Left = 8
      Top = 28
      Width = 43
      Height = 17
      Caption = 'CardNo:'
      TabOrder = 1
    end
    object Edit2: TEdit
      Left = 328
      Top = 24
      Width = 120
      Height = 21
      MaxLength = 10
      TabOrder = 2
      Text = '0708141200'
    end
    object StaticText2: TStaticText
      Left = 8
      Top = 58
      Width = 49
      Height = 17
      Caption = 'EndTime:'
      TabOrder = 3
    end
    object Edit3: TEdit
      Left = 100
      Top = 54
      Width = 120
      Height = 21
      MaxLength = 10
      TabOrder = 4
      Text = '0708151200'
    end
    object Edit4: TEdit
      Left = 100
      Top = 114
      Width = 349
      Height = 21
      TabOrder = 5
      Text = 'FFFF'
    end
    object Edit5: TEdit
      Left = 100
      Top = 84
      Width = 120
      Height = 21
      TabOrder = 6
      Text = '96'
    end
    object Edit6: TEdit
      Left = 328
      Top = 84
      Width = 120
      Height = 21
      TabOrder = 7
      Text = '97'
    end
    object Edit7: TEdit
      Left = 328
      Top = 54
      Width = 120
      Height = 21
      TabOrder = 8
      Text = '97'
    end
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 229
    Width = 526
    Height = 148
    TabOrder = 8
    object Label6: TLabel
      Left = 8
      Top = 120
      Width = 53
      Height = 13
      Caption = 'BeginTime:'
    end
    object StaticText3: TStaticText
      Left = 8
      Top = 28
      Width = 43
      Height = 17
      Caption = 'CardNo:'
      TabOrder = 0
    end
    object edtPWCN: TEdit
      Left = 105
      Top = 24
      Width = 120
      Height = 21
      TabOrder = 1
      Text = '1'
    end
    object StaticText4: TStaticText
      Left = 265
      Top = 28
      Width = 41
      Height = 17
      Caption = 'DoorID:'
      TabOrder = 2
    end
    object edtPWLC: TEdit
      Left = 390
      Top = 24
      Width = 120
      Height = 21
      MaxLength = 6
      TabOrder = 3
      Text = '000001'
    end
    object StaticText9: TStaticText
      Left = 265
      Top = 120
      Width = 49
      Height = 17
      Caption = 'EndTime:'
      TabOrder = 4
    end
    object edtPWET: TEdit
      Left = 390
      Top = 116
      Width = 120
      Height = 21
      MaxLength = 12
      TabOrder = 5
      Text = '100313120000'
    end
    object edtPWBT: TEdit
      Left = 105
      Top = 116
      Width = 120
      Height = 21
      MaxLength = 12
      TabOrder = 6
      Text = '100312120000'
    end
    object StaticText7: TStaticText
      Left = 8
      Top = 74
      Width = 53
      Height = 17
      Caption = 'GuestSex:'
      TabOrder = 7
    end
    object edtGuestSex: TEdit
      Left = 105
      Top = 70
      Width = 120
      Height = 21
      MaxLength = 1
      TabOrder = 8
      Text = '0'
    end
    object StaticText8: TStaticText
      Left = 265
      Top = 74
      Width = 63
      Height = 17
      Caption = 'GuestName:'
      TabOrder = 9
    end
    object edtGuestName: TEdit
      Left = 390
      Top = 70
      Width = 120
      Height = 21
      MaxLength = 8
      TabOrder = 10
      Text = 'abcdefgh'
    end
  end
  object gpbData: TGroupBox
    Left = 544
    Top = 325
    Width = 457
    Height = 52
    TabOrder = 9
    object lblData: TLabel
      Left = 8
      Top = 22
      Width = 26
      Height = 13
      Caption = 'Data:'
    end
    object edtData: TEdit
      Left = 100
      Top = 18
      Width = 349
      Height = 21
      MaxLength = 32
      TabOrder = 0
    end
  end
  object ckbData: TCheckBox
    Left = 552
    Top = 322
    Width = 49
    Height = 17
    Caption = 'Data'
    TabOrder = 10
    OnClick = ckbDataClick
  end
  object ckbLiftContent: TCheckBox
    Left = 552
    Top = 162
    Width = 81
    Height = 17
    Caption = 'Lift Content'
    TabOrder = 11
    OnClick = ckbLiftContentClick
  end
  object ckbCardContent: TCheckBox
    Left = 552
    Top = 6
    Width = 89
    Height = 17
    Caption = 'Card Content'
    TabOrder = 12
    OnClick = ckbCardContentClick
  end
  object ckbPowerSwitchContent: TCheckBox
    Left = 16
    Top = 226
    Width = 129
    Height = 17
    Caption = 'PowerSwitch Content'
    TabOrder = 13
    OnClick = ckbPowerSwitchContentClick
  end
end
