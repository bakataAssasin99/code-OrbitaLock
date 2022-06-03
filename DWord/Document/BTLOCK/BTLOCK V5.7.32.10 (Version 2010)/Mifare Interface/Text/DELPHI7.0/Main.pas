unit Main;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls;

type
  TfrmMain = class(TForm)
    gpbConnection: TGroupBox;
    cmbDM: TComboBox;
    stxText2: TStaticText;
    stxText3: TStaticText;
    cmbDP: TComboBox;
    gpbCardFields: TGroupBox;
    stxText9: TStaticText;
    btnRead: TButton;
    btnExit: TButton;
    edtCN: TEdit;
    stxText10: TStaticText;
    edtLC: TEdit;
    stxText11: TStaticText;
    edtSC: TEdit;
    stxText12: TStaticText;
    edtGC: TEdit;
    stxText13: TStaticText;
    stxText14: TStaticText;
    stxText16: TStaticText;
    edtPI: TEdit;
    edtPN: TEdit;
    edtET: TEdit;
    stbInfo: TStatusBar;
    btnWrite: TButton;
    gpbCardSetting: TGroupBox;
    edtSP: TEdit;
    stxText8: TStaticText;
    stxText17: TLabel;
    edtBT: TEdit;
    lblSectorNo: TLabel;
    edtSectorNo: TEdit;
    lblRepeatTimes: TLabel;
    edtRepeatTimes: TEdit;
    gpbLiftFields: TGroupBox;
    Edit1: TEdit;
    StaticText1: TStaticText;
    Label1: TLabel;
    Edit2: TEdit;
    StaticText2: TStaticText;
    Edit3: TEdit;
    Label2: TLabel;
    Edit4: TEdit;
    Label3: TLabel;
    Edit5: TEdit;
    Label4: TLabel;
    Edit6: TEdit;
    Label5: TLabel;
    Edit7: TEdit;
    GroupBox1: TGroupBox;
    Label6: TLabel;
    StaticText3: TStaticText;
    edtPWCN: TEdit;
    StaticText4: TStaticText;
    edtPWLC: TEdit;
    StaticText9: TStaticText;
    edtPWET: TEdit;
    edtPWBT: TEdit;
    StaticText5: TStaticText;
    edtPSW: TEdit;
    edtPSSectorNo: TEdit;
    Label7: TLabel;
    StaticText6: TStaticText;
    cmbPM: TComboBox;
    StaticText7: TStaticText;
    edtGuestSex: TEdit;
    StaticText8: TStaticText;
    edtGuestName: TEdit;
    procedure btnExitClick(Sender: TObject);
    procedure btnReadClick(Sender: TObject);
    procedure btnWriteClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
  //读宾客卡函数
  function Read_Guest_Card(Port, ReaderType, SectorNo: Byte; HotelPwd: PChar;
    var CardNo, GuestSN, GuestIdx: Integer; DoorID, SuitDoor, PubDoor, BeginTime,
    EndTime: PChar): Integer; stdcall; far; external 'btlock57L.dll';
  //写宾客卡函数
  function Write_Guest_Card (Port, ReaderType, SectorNo: Byte; HotelPwd: PChar;
    CardNo, GuestSN, GuestIdx: Integer; DoorID, SuitDoor, PubDoor, BeginTime,
    EndTime: PChar): Integer; stdcall; far; external 'btlock57L.dll';
  //读卡器蜂鸣
  function Reader_Alarm(Port, ReaderType, AlarmCount: Byte): Integer;
    stdcall; far; external 'btlock57L.dll';
  //写电梯控制信息
  function Write_Guest_Lift(Port, ReaderType, SectorNo: Byte; HotelPwd: PChar;
    CardNo, BeginAddr, EndAddr, MaxLiftAddr: Integer; BeginTime, EndTime,
    LiftData: PChar): Integer; stdcall; far; external 'btlock57L.dll';
  //读电梯控制信息
  function Read_Guest_Lift(Port, ReaderType, SectorNo: Byte; HotelPwd: PChar;
    BeginAddr, EndAddr: Integer; var CardNo: Integer; BeginTime, EndTime,
    LiftData: PChar): Integer; stdcall; far; external 'btlock57L.dll';
  //写取电开关函数
  function Write_Guest_PowerSwitch(Port, ReaderType, SectorNo: Byte; PowerSwitchPwd: PChar;
    CardNo, GuestSex: Integer; DoorID, GuestName, BeginTime, EndTime: PChar;
    PowerSwitchType: Byte): Integer; stdcall; far; external 'btlock57L.dll';
  //读取电开关函数
  function Read_Guest_PowerSwitch(Port, ReaderType, SectorNo: Byte; PowerSwitchPwd: PChar;
    var CardNo, GuestSex: Integer; DoorID, GuestName, BeginTime, EndTime: PChar;
    PowerSwitchType: Byte): Integer; stdcall; far; external 'btlock57L.dll';

var
  frmMain: TfrmMain;

implementation

{$R *.dfm}

procedure TfrmMain.btnExitClick(Sender: TObject);
begin
  Close;
end;

procedure TfrmMain.btnReadClick(Sender: TObject);
var
  tmpCardNo, tmpGuestSN, tmpGuestIdx, tmpGuestSex,
  rt: Integer;
  tmpDoorID, tmpSuitDoor, tmpPubDoor,
  tmpBeginTime, tmpEndTime, tmpLiftData, tmpGuestName: PChar;
begin
  edtLC.Text := '';
  edtSC.Text := '';
  edtGC.Text := '';
  edtET.Text := '';
  edtBT.Text := '';
  Edit1.Text := '';
  Edit2.Text := '';
  Edit3.Text := '';
  Edit4.Text := '';
  edtPWCN.Text := '';
  edtPWLC.Text := '';
  edtGuestSex.Text := '';
  edtGuestName.Text := '';
  edtPWBT.Text := '';
  edtPWET.Text := '';

  GetMem(tmpDoorID, 7);
  tmpDoorID[6] := #0;
  GetMem(tmpSuitDoor, 5);
  tmpSuitDoor[4] := #0;
  GetMem(tmpPubDoor, 9);
  tmpPubDoor[8] := #0;
  GetMem(tmpBeginTime, 13);
  tmpBeginTime[12] := #0;
  GetMem(tmpEndTime, 13);
  tmpEndTime[12] := #0;
  GetMem(tmpGuestName, 9);
  tmpGuestName[8] := #0;
  if StrToInt(Edit7.Text) - StrToInt(Edit6.Text) + 1 > 16 then
  begin
    GetMem(tmpLiftData, (StrToInt(Edit7.Text) - StrToInt(Edit6.Text) -15) * 2 + 1);
    tmpLiftData[(StrToInt(Edit7.Text) - StrToInt(Edit6.Text) -15) * 2] := #0;
  end else
  begin
    GetMem(tmpLiftData, (StrToInt(Edit7.Text) - StrToInt(Edit6.Text) + 1) * 2 + 1);
    tmpLiftData[(StrToInt(Edit7.Text) - StrToInt(Edit6.Text) + 1) * 2] := #0;
  end;

  rt := Read_Guest_Card(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtSectorNo.Text),
    PChar(edtSP.Text), tmpCardNo, tmpGuestSN, tmpGuestIdx, @tmpDoorID[0], @tmpSuitDoor[0],
    @tmpPubDoor[0], @tmpBeginTime[0], @tmpEndTime[0]);
  if rt = 0 then
  begin
    edtCN.Text := IntToStr(tmpCardNo);
    edtLC.Text := strPas(tmpDoorID);
    edtSC.Text := strPas(tmpSuitDoor);
    edtGC.Text := strPas(tmpPubDoor);
    edtPI.Text := IntToStr(tmpGuestSN);
    edtPN.Text := IntToStr(tmpGuestIdx);
    edtBT.Text := strPas(tmpBeginTime);
    edtET.Text := strPas(tmpEndTime);
    rt := Read_Guest_Lift(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtSectorNo.Text),
      PChar(edtSP.Text), StrToInt(Edit5.Text), StrToInt(Edit6.Text), tmpCardNo, @tmpBeginTime[0],
      @tmpEndTime[0], @tmpLiftData[0]);
    if rt = 0 then
    begin
      Edit1.Text := IntToStr(tmpCardNo);;
      Edit2.Text := strPas(tmpBeginTime);
      Edit3.Text := strPas(tmpEndTime);
      Edit4.Text := strPas(tmpLiftData);
      rt := Read_Guest_PowerSwitch(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtPSSectorNo.Text),
        PChar(edtPSW.Text), tmpCardNo, tmpGuestSex, @tmpDoorID[0], @tmpGuestName[0],
        @tmpBeginTime[0], @tmpEndTime[0], cmbPM.ItemIndex + 1);
      if rt = 0 then
      begin
        if cmbPM.ItemIndex = 0 then
        begin
          edtPWCN.Text := IntToStr(tmpCardNo);
          edtPWLC.Text := strPas(tmpDoorID);
          edtGuestSex.Text := IntToStr(tmpGuestSex);
          edtGuestName.Text := strPas(tmpGuestName);
          edtPWBT.Text := strPas(tmpBeginTime);
          edtPWET.Text := strPas(tmpEndTime);
        end else if cmbPM.ItemIndex = 1 then
        begin
          //edtPWCN.Text := IntToStr(tmpCardNo);
          edtPWLC.Text := strPas(tmpDoorID);
          //edtGuestSex.Text := IntToStr(tmpGuestSex);
          //edtGuestName.Text := strPas(tmpGuestName);
          //edtPWBT.Text := strPas(tmpBeginTime);
          edtPWET.Text := strPas(tmpEndTime);
        end;
        Reader_Alarm(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtRepeatTimes.Text));
      end; 
    end;
  end; 
  stbInfo.Panels[1].Text := IntToStr(rt);
  stbInfo.Refresh;
  FreeMem(tmpDoorID);
  FreeMem(tmpSuitDoor);
  FreeMem(tmpPubDoor);
  FreeMem(tmpEndTime);
  FreeMem(tmpBeginTime);
  FreeMem(tmpGuestName);
end;

procedure TfrmMain.btnWriteClick(Sender: TObject);
var
  rt: Integer;
begin
  rt := Write_Guest_Card(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtSectorNo.Text),
    PChar(edtSP.Text), StrToInt(edtCN.Text), StrToInt(edtPI.Text), StrToInt(edtPN.Text),
    PChar(edtLC.Text), PChar(edtSC.Text), PChar(edtGC.Text), PChar(edtBT.Text), PChar(edtET.Text));
  if rt = 0 then
  begin
    rt := Write_Guest_Lift(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtSectorNo.Text),
      PChar(edtSP.Text), StrToInt(Edit1.Text), StrToInt(Edit5.Text), StrToInt(Edit6.Text),
      StrToInt(Edit7.Text), PChar(Edit2.Text), PChar(Edit3.Text), PChar(Edit4.Text));
    if rt = 0 then
    begin
      if cmbPM.ItemIndex = 0 then
      begin
        rt := Write_Guest_PowerSwitch(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtPSSectorNo.Text),
          PChar(edtPSW.Text), StrToInt(edtPWCN.Text), StrToInt(edtGuestSex.Text), PChar(edtPWLC.Text),
          PChar(edtGuestName.Text), PChar(edtPWBT.Text), PChar(edtPWET.Text), cmbPM.ItemIndex + 1);
      end else if cmbPM.ItemIndex = 1 then
      begin
        rt := Write_Guest_PowerSwitch(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtPSSectorNo.Text),
          PChar(edtPSW.Text), 1, 0, PChar(edtPWLC.Text), 0, 0, PChar(edtPWET.Text),
          cmbPM.ItemIndex + 1);
      end;
    end;
  end;
  if rt = 0 then
    Reader_Alarm(cmbDP.ItemIndex + 1, cmbDM.ItemIndex + 1, StrToInt(edtRepeatTimes.Text));
  stbInfo.Panels[1].Text := IntToStr(rt);
  stbInfo.Refresh;
end;

end.
