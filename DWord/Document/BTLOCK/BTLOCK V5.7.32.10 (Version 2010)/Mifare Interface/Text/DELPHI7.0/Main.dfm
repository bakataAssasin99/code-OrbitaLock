object frmMain: TfrmMain
  Left = 334
  Top = 64
  Width = 602
  Height = 696
  BorderIcons = [biSystemMenu]
  Caption = 'MF v5.7 Interface Demo'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  DesignSize = (
    594
    662)
  PixelsPerInch = 96
  TextHeight = 13
  object gpbConnection: TGroupBox
    Left = 8
    Top = 8
    Width = 273
    Height = 150
    Caption = 'Connection Setting'
    TabOrder = 0
    object lblRepeatTimes: TLabel
      Left = 8
      Top = 118
      Width = 69
      Height = 13
      Caption = 'Repeat Times:'
    end
    object cmbDM: TComboBox
      Left = 116
      Top = 24
      Width = 145
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
      Width = 74
      Height = 17
      Caption = 'Reader Model:'
      ParentShowHint = False
      ShowHint = False
      TabOrder = 1
    end
    object stxText3: TStaticText
      Left = 8
      Top = 58
      Width = 43
      Height = 17
      Caption = 'Port No:'
      TabOrder = 2
    end
    object cmbDP: TComboBox
      Left = 116
      Top = 54
      Width = 145
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
      Top = 114
      Width = 145
      Height = 21
      TabOrder = 4
      Text = '1'
    end
    object StaticText6: TStaticText
      Left = 8
      Top = 88
      Width = 101
      Height = 17
      Caption = 'PowerSwitch Model:'
      ParentShowHint = False
      ShowHint = False
      TabOrder = 5
    end
    object cmbPM: TComboBox
      Left = 116
      Top = 84
      Width = 145
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      ItemIndex = 0
      TabOrder = 6
      Text = '8601-1M-57BA'
      Items.Strings = (
        '8601-1M-57BA'
        '8601-6M-57BA')
    end
  end
  object gpbCardFields: TGroupBox
    Left = 8
    Top = 165
    Width = 577
    Height = 150
    Caption = 'Card Content'
    TabOrder = 1
    object stxText17: TLabel
      Left = 8
      Top = 118
      Width = 17
      Height = 13
      Caption = 'BT:'
    end
    object stxText9: TStaticText
      Left = 8
      Top = 28
      Width = 22
      Height = 17
      Caption = 'CN:'
      TabOrder = 0
    end
    object edtCN: TEdit
      Left = 116
      Top = 24
      Width = 145
      Height = 21
      TabOrder = 1
      Text = '1'
    end
    object stxText10: TStaticText
      Left = 290
      Top = 28
      Width = 20
      Height = 17
      Caption = 'LC:'
      TabOrder = 2
    end
    object edtLC: TEdit
      Left = 416
      Top = 24
      Width = 145
      Height = 21
      MaxLength = 6
      TabOrder = 3
      Text = '000001'
    end
    object stxText11: TStaticText
      Left = 8
      Top = 58
      Width = 22
      Height = 17
      Caption = 'NC:'
      TabOrder = 4
    end
    object edtSC: TEdit
      Left = 116
      Top = 54
      Width = 145
      Height = 21
      MaxLength = 4
      TabOrder = 5
      Text = '0000'
    end
    object stxText12: TStaticText
      Left = 290
      Top = 58
      Width = 23
      Height = 17
      Caption = 'MC:'
      TabOrder = 6
    end
    object edtGC: TEdit
      Left = 416
      Top = 54
      Width = 145
      Height = 21
      MaxLength = 8
      TabOrder = 7
      Text = '00000000'
    end
    object stxText13: TStaticText
      Left = 8
      Top = 88
      Width = 18
      Height = 17
      Caption = 'GI:'
      TabOrder = 8
    end
    object stxText14: TStaticText
      Left = 290
      Top = 88
      Width = 23
      Height = 17
      Caption = 'GN:'
      TabOrder = 9
    end
    object stxText16: TStaticText
      Left = 290
      Top = 118
      Width = 21
      Height = 17
      Caption = 'ET:'
      TabOrder = 10
    end
    object edtPI: TEdit
      Left = 116
      Top = 84
      Width = 145
      Height = 21
      TabOrder = 11
      Text = '1'
    end
    object edtPN: TEdit
      Left = 416
      Top = 84
      Width = 145
      Height = 21
      TabOrder = 12
      Text = '1'
    end
    object edtET: TEdit
      Left = 416
      Top = 114
      Width = 145
      Height = 21
      MaxLength = 10
      TabOrder = 13
      Text = '1003131200'
    end
    object edtBT: TEdit
      Left = 116
      Top = 114
      Width = 145
      Height = 21
      MaxLength = 10
      TabOrder = 14
      Text = '1003121200'
    end
  end
  object btnRead: TButton
    Left = 353
    Top = 612
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = '&Read'
    TabOrder = 2
    OnClick = btnReadClick
  end
  object btnExit: TButton
    Left = 513
    Top = 612
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = '&Exit'
    TabOrder = 3
    OnClick = btnExitClick
  end
  object stbInfo: TStatusBar
    Left = 0
    Top = 642
    Width = 594
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
    Left = 433
    Top = 612
    Width = 75
    Height = 25
    Anchors = [akRight, akBottom]
    Caption = '&Write'
    TabOrder = 5
    OnClick = btnWriteClick
  end
  object gpbCardSetting: TGroupBox
    Left = 288
    Top = 8
    Width = 295
    Height = 150
    Caption = 'System Setting'
    TabOrder = 6
    object lblSectorNo: TLabel
      Left = 8
      Top = 58
      Width = 51
      Height = 13
      Caption = 'Sector No:'
    end
    object Label7: TLabel
      Left = 8
      Top = 118
      Width = 116
      Height = 13
      Caption = 'PowerSwitch Sector No:'
    end
    object edtSP: TEdit
      Left = 136
      Top = 24
      Width = 145
      Height = 21
      MaxLength = 6
      TabOrder = 0
    end
    object stxText8: TStaticText
      Left = 8
      Top = 28
      Width = 90
      Height = 17
      Caption = 'System Password:'
      TabOrder = 1
    end
    object edtSectorNo: TEdit
      Left = 136
      Top = 54
      Width = 145
      Height = 21
      MaxLength = 2
      TabOrder = 2
      Text = '0'
    end
    object StaticText5: TStaticText
      Left = 8
      Top = 88
      Width = 117
      Height = 17
      Caption = 'PowerSwitch Sector ID:'
      TabOrder = 3
    end
    object edtPSW: TEdit
      Left = 136
      Top = 84
      Width = 145
      Height = 21
      MaxLength = 12
      TabOrder = 4
      Text = 'FFFFFFFFFFFF'
    end
    object edtPSSectorNo: TEdit
      Left = 136
      Top = 114
      Width = 145
      Height = 21
      MaxLength = 2
      TabOrder = 5
      Text = '15'
    end
  end
  object gpbLiftFields: TGroupBox
    Left = 8
    Top = 325
    Width = 577
    Height = 150
    Caption = 'Lift Content'
    TabOrder = 7
    object Label1: TLabel
      Left = 290
      Top = 28
      Width = 17
      Height = 13
      Caption = 'BT:'
    end
    object Label2: TLabel
      Left = 8
      Top = 118
      Width = 26
      Height = 13
      Caption = 'Data:'
    end
    object Label3: TLabel
      Left = 8
      Top = 88
      Width = 52
      Height = 13
      Caption = 'BeginAddr:'
    end
    object Label4: TLabel
      Left = 290
      Top = 88
      Width = 44
      Height = 13
      Caption = 'EndAddr:'
    end
    object Label5: TLabel
      Left = 290
      Top = 58
      Width = 45
      Height = 13
      Caption = 'MaxAddr:'
    end
    object Edit1: TEdit
      Left = 116
      Top = 24
      Width = 145
      Height = 21
      TabOrder = 0
      Text = '1'
    end
    object StaticText1: TStaticText
      Left = 8
      Top = 28
      Width = 22
      Height = 17
      Caption = 'CN:'
      TabOrder = 1
    end
    object Edit2: TEdit
      Left = 416
      Top = 24
      Width = 145
      Height = 21
      MaxLength = 10
      TabOrder = 2
      Text = '0708141200'
    end
    object StaticText2: TStaticText
      Left = 8
      Top = 58
      Width = 21
      Height = 17
      Caption = 'ET:'
      TabOrder = 3
    end
    object Edit3: TEdit
      Left = 116
      Top = 54
      Width = 145
      Height = 21
      MaxLength = 10
      TabOrder = 4
      Text = '0708151200'
    end
    object Edit4: TEdit
      Left = 116
      Top = 114
      Width = 445
      Height = 21
      TabOrder = 5
      Text = 'FFFF'
    end
    object Edit5: TEdit
      Left = 116
      Top = 84
      Width = 145
      Height = 21
      TabOrder = 6
      Text = '96'
    end
    object Edit6: TEdit
      Left = 416
      Top = 84
      Width = 145
      Height = 21
      TabOrder = 7
      Text = '97'
    end
    object Edit7: TEdit
      Left = 416
      Top = 54
      Width = 145
      Height = 21
      TabOrder = 8
      Text = '97'
    end
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 485
    Width = 577
    Height = 116
    Caption = 'PowerSwitch Content'
    TabOrder = 8
    object Label6: TLabel
      Left = 8
      Top = 88
      Width = 17
      Height = 13
      Caption = 'BT:'
    end
    object StaticText3: TStaticText
      Left = 8
      Top = 28
      Width = 22
      Height = 17
      Caption = 'CN:'
      TabOrder = 0
    end
    object edtPWCN: TEdit
      Left = 116
      Top = 24
      Width = 145
      Height = 21
      TabOrder = 1
      Text = '1'
    end
    object StaticText4: TStaticText
      Left = 290
      Top = 28
      Width = 20
      Height = 17
      Caption = 'LC:'
      TabOrder = 2
    end
    object edtPWLC: TEdit
      Left = 416
      Top = 24
      Width = 145
      Height = 21
      MaxLength = 6
      TabOrder = 3
      Text = '000001'
    end
    object StaticText9: TStaticText
      Left = 290
      Top = 88
      Width = 21
      Height = 17
      Caption = 'ET:'
      TabOrder = 4
    end
    object edtPWET: TEdit
      Left = 416
      Top = 84
      Width = 145
      Height = 21
      MaxLength = 12
      TabOrder = 5
      Text = '100313120000'
    end
    object edtPWBT: TEdit
      Left = 116
      Top = 84
      Width = 145
      Height = 21
      MaxLength = 12
      TabOrder = 6
      Text = '100312120000'
    end
    object StaticText7: TStaticText
      Left = 8
      Top = 58
      Width = 22
      Height = 17
      Caption = 'GS:'
      TabOrder = 7
    end
    object edtGuestSex: TEdit
      Left = 116
      Top = 54
      Width = 145
      Height = 21
      MaxLength = 1
      TabOrder = 8
      Text = '0'
    end
    object StaticText8: TStaticText
      Left = 290
      Top = 58
      Width = 23
      Height = 17
      Caption = 'GN:'
      TabOrder = 9
    end
    object edtGuestName: TEdit
      Left = 416
      Top = 54
      Width = 145
      Height = 21
      MaxLength = 8
      TabOrder = 10
      Text = 'abcdefgh'
    end
  end
end
