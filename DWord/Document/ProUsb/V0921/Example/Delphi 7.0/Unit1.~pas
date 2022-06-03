unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls,StrUtils, Buttons, ExtCtrls;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Button1: TButton;
    GroupBox2: TGroupBox;
    Label13: TLabel;
    Label16: TLabel;
    edt_LockNo: TEdit;
    edt_Dai: TEdit;
    Label9: TLabel;
    DateTimePicker1: TDateTimePicker;
    DateTimePicker2: TDateTimePicker;
    GroupBox3: TGroupBox;
    Label2: TLabel;
    Label4: TLabel;
    Label20: TLabel;
    Label10: TLabel;
    edt_coID: TEdit;
    Button3: TButton;
    Label8: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    BitBtn4: TBitBtn;
    GroupBox4: TGroupBox;
    BitBtn1: TBitBtn;
    BitBtn3: TBitBtn;
    BitBtn2: TBitBtn;
    BitBtn5: TBitBtn;
    BitBtn6: TBitBtn;
    edt_CardData: TEdit;
    Label17: TLabel;
    Label1: TLabel;
    StatusBar1: TStatusBar;
    Label11: TLabel;
    edt_CardNo: TEdit;
    Label12: TLabel;
    cmdExit: TBitBtn;
    RadioButton3: TRadioButton;
    RadioButton4: TRadioButton;
    CheckBox1: TCheckBox;
    BitBtn7: TBitBtn;
    BitBtn8: TBitBtn;
    BitBtn9: TBitBtn;
    BitBtn10: TBitBtn;
    BitBtn11: TBitBtn;
    procedure cmdExitClick(Sender: TObject);
    procedure BitBtn6Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
    procedure BitBtn5Click(Sender: TObject);
    procedure BitBtn2Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure BitBtn4Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure BitBtn3Click(Sender: TObject);
    procedure RadioButton4Click(Sender: TObject);
    procedure RadioButton3Click(Sender: TObject);
    procedure BitBtn7Click(Sender: TObject);
    procedure BitBtn8Click(Sender: TObject);
    procedure BitBtn9Click(Sender: TObject);
    procedure BitBtn10Click(Sender: TObject);
    procedure BitBtn11Click(Sender: TObject);
  private
    { Private declarations }
    function rdCard: Boolean;
  public
    { Public declarations }
  end;

var
  Form1:        TForm1;
  flagUSB:      Integer;    //Reader Type,0--USB,1--proUSB
  st:           Integer;
  bufCard:      Array[0..128] of char;

implementation

  //Get DLL's Version
  function GetDLLVersion(sDllVer:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //Open USB
  function initializeUSB(fUSB: Byte): Integer; stdcall;
    external 'proRFL.DLL';
  //Close proUSB
  procedure CloseUSB(fUSB: Byte); stdcall;
    external 'proRFL.DLL';
  //Buzzer
  function Buzzer(fUSB:Byte;t: Integer):Integer; stdcall;
    external 'proRFL.DLL';
  //Read Card Data
  function ReadCard(fUSB:Byte;Buffer:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //Issue Guest Card
  //int __stdcall GuestCard(uchar fUSB,int dlsCoID,uchar CardNo,uchar dai,uchar LLock,uchar pdoors,uchar BDate[10],uchar EDate[10],uchar RoomNo[8],uchar *cardHexStr)
  function GuestCard(fUSB:Byte;dlsCoID:Integer;CardNo,dai,llock,pdoors:Byte;BDate,EDate,RoomNo:Pchar;CardHexStr:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //Card Erase
  //int __stdcall CardErase(uchar fUSB,int dlsCoID,unsigned char *cardHexStr)
  function CardErase(fUSB:Byte;dlsCoID:Integer;cardHexStr:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //Convert HEX to ASC
  //__int16 __stdcall hex_a(unsigned char *hex,unsigned char *a,__int16 len)
  function hex_a(hex,asc:PChar;hLen:Integer):Integer; stdcall;
    external 'proRFL.DLL';
  //Convert ASC to HEX
  //__int16 __stdcall a_hex(unsigned char *a,unsigned char *hex,__int16 len)
  function a_hex(asc,hex:PChar;aLen:Integer):Integer; stdcall;
    external 'proRFL.DLL';

  //Get Card Type By Card Data String
  //int __stdcall GetCardTypeByCardDataStr(unsigned char *CardDataStr,unsigned char *CardType)
  function GetCardTypeByCardDataStr(cardHexStr,CardType:PChar):Integer; stdcall;
    external 'proRFL.DLL';

  //Get Guest LockNo By Card Data String
  //int __stdcall GetGuestLockNoByCardDataStr(int dlsCoID,unsigned char *CardDataStr,unsigned char *LockNo)
  function GetGuestLockNoByCardDataStr(dlsCoID: Integer;cardHexStr,LockNo:PChar):Integer; stdcall;
    external 'proRFL.DLL';

  //Get Guest Expiry By Card Data String
  //int __stdcall GetGuestETimeByCardDataStr(int dlsCoID,unsigned char *CardDataStr,unsigned char *ETime)
  function GetGuestETimeByCardDataStr(dlsCoID: Integer;cardHexStr,ETime:PChar):Integer; stdcall;
    external 'proRFL.DLL';

  //Read Record
  //int __stdcall ReadRecord(uchar d12,unsigned char *buffData)
  function ReadRecord(fUSB:Byte;bufData:PChar):Integer; stdcall;
    external 'proRFL.DLL';

  //Get unlock Door Record
  //int __stdcall GetOpenRecordByDataStr(unsigned char *DataStr,unsigned char *sOpen)
  function GetOpenRecordByDataStr(DataStr,sOpen:PChar):Integer; stdcall;
    external 'proRFL.DLL';

{$R *.dfm}

//Read Card Data, It will Pop a Message box when error
//CardID--copy(bufCard,25,8)
function TForm1.rdCard: Boolean;
var
  st:  Integer;
Label
  Exit_rdCard;
begin
  Result:=False;
  Screen.Cursor:=crHourGlass;
  st:=ReadCard(flagUSB,bufCard);
  if st<>0 then begin
    Application.MessageBox(PCHAR('Read Card Failure'+#10+IntToStr(st)),'Note',MB_OK+MB_ICONERROR);
    goto Exit_rdCard;
  end;
  if copy(bufCard,5,2)<>'01' then begin
    Application.MessageBox(PCHAR('No Valid Card On Reader'+#10+bufCard),'Note',MB_OK+MB_ICONWARNING);
    goto Exit_rdCard;
  end;
  Result:=True;
Exit_rdCard:
  Screen.Cursor:=crDefault;
end;

procedure TForm1.FormShow(Sender: TObject);
begin
  flagUSB:=1;   //Default proUSB
  DateTimePicker1.DateTime:=Now+1;
end;

procedure TForm1.cmdExitClick(Sender: TObject);
begin
  Close;
end;

//Default
procedure TForm1.BitBtn4Click(Sender: TObject);
begin
  edt_CardNo.Text:='0';
  edt_LockNo.Text:='01020399';
  edt_Dai.Text:='0';
end;

//Get DLL's Version
procedure TForm1.BitBtn6Click(Sender: TObject);
var
  st:     Integer;
  sa1:    Array[0..128] of char;
begin
  st:=GetDLLVersion(sa1);
  StatusBar1.Panels[0].Text:=IntToStr(st);
  StatusBar1.Panels[1].Text:=sa1;
  if st=0 then
    Application.MessageBox(Pchar('DLL Version: '+StrPas(sa1)),'Note',MB_OK+MB_ICONINFORMATION);
end;

//Open USB
procedure TForm1.Button1Click(Sender: TObject);
var
  st:   Integer;
begin
  st:=initializeUSB(flagUSB);       //0--USB, 1--proUSB
  if st<>0 then
    Application.MessageBox(Pchar('Open USB Failure'+#10+IntToStr(st)),'Note',MB_OK+MB_ICONWARNING)
  else begin
    Application.MessageBox('Open USB Success','Note',MB_OK+MB_ICONINFORMATION);
    Button3.Enabled:=True;
    GroupBox4.Enabled:=True;
  end;
end;

//Buzzer
procedure TForm1.BitBtn1Click(Sender: TObject);
begin
  Buzzer(flagUSB,50);   //Duration 50*10 ms
end;

//Card Erase
procedure TForm1.BitBtn5Click(Sender: TObject);
var
  st:     Integer;
  sa1:    Array[0..128] of char;
begin
  if not rdCard then Exit;   //Read Card First
  st:=CardErase(flagUSB,StrToIntDef(edt_coID.Text,0),sa1);
  if flagUSB=1 then Buzzer(flagUSB,20);      //Buzzer
  edt_CardData.Text:=StrPas(sa1);
  if st<>0 then
    Application.MessageBox(Pchar('Erase Card Failure'+#10+IntToStr(st)),'Note',MB_OK+MB_ICONWARNING)
  else begin
    Application.MessageBox('Card Erased','Note',MB_OK+MB_ICONINFORMATION);
  end;
end;

procedure TForm1.BitBtn2Click(Sender: TObject);
var
  st:            Integer;
  llock,pdoors:  Byte;
  sa1:           Array[0..128] of char;
begin
  if not rdCard then Exit;   //Read Card First
  //DeadBolt
  llock:=0;
  if CheckBox1.Checked then llock:=1;
  //Public Door
  pdoors:=1;
  //Check Out
  DateTimePicker1.Time:=DateTimePicker2.Time;
  st:=GuestCard(flagUSB,
                StrToIntDef(edt_coID.Text,0),    //dlsCoID
                StrToIntDef(edt_CardNo.Text,0),  //CardNo
                StrToIntDef(edt_Dai.Text,0),     //dai
                llock,pdoors,
                PCHAR(FormatDateTime('YYMMDDHHMM',Now)),   //The Time of Issue Card
                PCHAR(FormatDateTime('YYMMDDHHMM',DateTimePicker1.DateTime)),  //Check Out
                PCHAR(edt_LockNo.Text),      //Lock No.
                sa1);                        //Card Data
  if flagUSB=1 then Buzzer(flagUSB,20);      //Buzzer
  edt_CardData.Text:=StrPas(sa1);
  if st<>0 then
    Application.MessageBox(Pchar('Call Function Failure'+#10+IntToStr(st)),'Note',MB_OK+MB_ICONWARNING)
  else begin
    Application.MessageBox('Call Function Success','Note',MB_OK+MB_ICONINFORMATION);
  end;

end;

//Get Hotel ID (coID) from card
procedure TForm1.Button3Click(Sender: TObject);
var
  i:   Integer;
  s:   String;
begin
  if not rdCard then Exit;   //Read Card first
  if copy(bufCard,25,8)='FFFFFFFF' then begin
    edt_coID.Text:='';
    Application.MessageBox('This is a blank card, put on a card which can unlock door lock','Note',MB_OK+MB_ICONWARNING);
    Exit;
  end;
  s:=copy(bufCard,11,4);
  i:=StrToInt('$'+s) mod 16384;
  s:=copy(bufCard,9,2);
  i:=i+(StrToInt('$'+s) * 65536);
  edt_coID.Text:=IntToStr(i);
end;

//Read Card Data
procedure TForm1.BitBtn3Click(Sender: TObject);
begin
  if not rdCard then Exit;   //Read Card
  edt_CardData.Text:=StrPas(bufCard);
  Application.MessageBox(Pchar(('Card ID£º'+copy(bufCard,25,8))),'Note',MB_OK+MB_ICONINFORMATION);
end;

procedure TForm1.RadioButton3Click(Sender: TObject);
begin
  flagUSB:=0;   //USB
end;

procedure TForm1.RadioButton4Click(Sender: TObject);
begin
  flagUSB:=1;   //proUSB
end;

//Get Card Type By Card Data String
procedure TForm1.BitBtn7Click(Sender: TObject);
var
  CardType:      Array[0..16] of char;
begin
  if not rdCard then Exit;   //Read Card First
  edt_CardData.Text:=StrPas(bufCard);
  st:=GetCardTypeByCardDataStr(bufCard,CardType);
  if st<>0 then
    Application.MessageBox(Pchar(('Read Card Failure:'+IntToStr(st))),'Note',MB_OK+MB_ICONWARNING)
  else
    if CardType[0]='0' then
      Application.MessageBox('Reset Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='1' then
      Application.MessageBox('Record Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='2' then
      Application.MessageBox('Lock No. Setting Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='3' then
      Application.MessageBox('Clock Setting Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='4' then
      Application.MessageBox('Lost Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='5' then
      Application.MessageBox('Group No. Setting Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='6' then
      Application.MessageBox('Guest Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='7' then
      Application.MessageBox('Terminate Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='8' then
      Application.MessageBox('Group Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='9' then
      Application.MessageBox('Unknown','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='A' then
      Application.MessageBox('Emergency Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='B' then
      Application.MessageBox('Master Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='C' then
      Application.MessageBox('Building Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='D' then
      Application.MessageBox('Floor Card','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='E' then
      Application.MessageBox('Unknown','Card Type',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='F' then
      Application.MessageBox('Blank Card','Card Type',MB_OK+MB_ICONINFORMATION);
end;

//Get Guest LockNo By Card Data String
procedure TForm1.BitBtn8Click(Sender: TObject);
var
  LockNo:      Array[0..16] of char;
begin
  if not rdCard then Exit;   //Read Card First
  edt_CardData.Text:=StrPas(bufCard);
  st:=GetGuestLockNoByCardDataStr(StrToIntDef(edt_coID.Text,0),bufCard,LockNo);
  if st=0 then
    Application.MessageBox(PChar('Lock No.: '+#10+LockNo),'Note',MB_OK+MB_ICONINFORMATION)
  else if st=1 then
    Application.MessageBox(PChar('CardDataStr Invalid'+#10+bufCard),'Warning',MB_OK+MB_ICONWARNING)
  else if st=2 then
    Application.MessageBox(Pchar('This is not a card in this hotel'+#10+bufCard),'Warning',MB_OK+MB_ICONWARNING)
  else if st=3 then
    Application.MessageBox(Pchar('This is not a Guest Card.'+#10+bufCard),'Warning',MB_OK+MB_ICONWARNING)
  else
    Application.MessageBox(Pchar('Unknown Result'+#10+IntToStr(st)+#10+bufCard),'Warning',MB_OK+MB_ICONWARNING);
end;

//Get Guest Expiry by Card Data String
procedure TForm1.BitBtn9Click(Sender: TObject);
var
  ETime:      Array[0..16] of char;
begin
  if not rdCard then Exit;   //Read First
  edt_CardData.Text:=StrPas(bufCard);
  st:=GetGuestETimeByCardDataStr(StrToIntDef(edt_coID.Text,0),bufCard,ETime);
  if st=0 then
    Application.MessageBox(PChar('Expiry[YYMMDDHHMM]:'+#10+ETime),'Note',MB_OK+MB_ICONINFORMATION)
  else if st=1 then
    Application.MessageBox(PChar('CardDataStr Invalid'+#10+bufCard),'Warning',MB_OK+MB_ICONWARNING)
  else if st=2 then
    Application.MessageBox(Pchar('This is not a card in this hotel'+#10+bufCard),'Warning',MB_OK+MB_ICONWARNING)
  else if st=3 then
    Application.MessageBox(Pchar('This is not a Guest Card.'+#10+bufCard),'Warning',MB_OK+MB_ICONWARNING)
  else
    Application.MessageBox(Pchar('Unknown Result'+#10+IntToStr(st)+#10+bufCard),'Warning',MB_OK+MB_ICONWARNING);
end;

//Close USB
procedure TForm1.BitBtn10Click(Sender: TObject);
begin
  CloseUSB(flagUSB);
  Application.MessageBox(PChar('USB has been closed, You can not operate USB any more.'+#10+'If you want to operate USB again, Please initialize USB once more.'),'Note',MB_OK+MB_ICONINFORMATION);
end;

//Get Unlock Door Record
procedure TForm1.BitBtn11Click(Sender: TObject);
var
  fiq:         Boolean;
  s,s1:        String;
  i,j,k:       Integer;
  sOpen:       Array[0..16] of char;
  bufRec:      Array[0..20000] of char;
begin
  Screen.Cursor:=crHourGlass;
  st:=ReadRecord(flagUSB,bufRec);    //Read record data first
  Screen.Cursor:=crDefault;
  if st<>0 then begin
    if Application.MessageBox(PCHAR('Read record failure, continue?'+#10+IntToStr(st)), 'Error Message',
           MB_OKCANCEL+MB_ICONQUESTION+MB_DEFBUTTON2) = mrCancel then Exit;
  end;

  //There has 74 characters per frame data, and the first 8 frames data are system data
  //Every frame data begin with 552101, and end with frame No.(2-char) and parity(2-char)
  //k:=(length(StrPas(bufRec)) div 74);   //frame number
  //k:=k*4;                               //4 records per frame
  //for i:=0 to k-1 do begin
  for i:=0 to 223 do begin      //Keep the last 224 records in one lock
    j:=(i mod 4);
    if j=0 then begin
      s1:=copy(bufRec,(i div 4)*74+74*8+1,74);
    end;
    if st<>0 then
      s:='6B15458D15EA3941'    //Guest Card, 2010/05/29 08:57:02
    else
      s:=copy(s1,7+(i mod 4)*16,16);
    fiq:=InputQuery('Analyze unlock door record',PCHAR('Please input 16 characters data'+#10+'Default Record No.: '+IntToStr(j)+#10),s);
    if not fiq then Exit;
    if GetOpenRecordByDataStr(PChar(s),sOpen)<>0 then
      Application.MessageBox('Analyzing Failure','Error Message',MB_OK+MB_ICONWARNING)
    else begin
      s:='The record is:';
      s:=s+#10+'Card Type: '+sOpen[0];
      s:=s+#10+'Time of unlock door[YYYY/MM/DD HH:MM:SS]: 20';
      s:=s+sOpen[1]+sOpen[2]+'/'+sOpen[3]+sOpen[4]+'/'+sOpen[5]+sOpen[6];
      s:=s+' '+sOpen[7]+sOpen[8]+':'+sOpen[9]+sOpen[10]+':'+sOpen[11]+sOpen[12];
      Application.MessageBox(PChar('String from analysis: '+sOpen+#10+s),'Note',MB_OK+MB_ICONINFORMATION);
    end;
    if Application.MessageBox(PCHAR('Continue?'), 'Note',
           MB_OKCANCEL+MB_ICONQUESTION+MB_DEFBUTTON2) = mrCancel then Exit;
  end;
end;

end.
