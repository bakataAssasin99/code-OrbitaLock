unit FMAIN;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Buttons, Spin;

const PORT_USB=0;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    Label1: TLabel;
    Label3: TLabel;
    cb_port: TComboBox;
    Panel2: TPanel;
    Label5: TLabel;
    ED_ROOMNO: TEdit;
    Label6: TLabel;
    ED_TIME: TEdit;
    Label12: TLabel;
    ed_cardno: TEdit;
    Label13: TLabel;
    ED_HOLDER: TEdit;
    Label14: TLabel;
    ed_idno: TEdit;
    CK_OVER: TCheckBox;
    Label25: TLabel;
    cb_lock: TComboBox;
    Label11: TLabel;
    ed_status: TEdit;
    Panel3: TPanel;
    b_newkey: TBitBtn;
    b_dupkey: TBitBtn;
    b_read: TBitBtn;
    b_erase: TBitBtn;
    b_checkout: TBitBtn;
    Label2: TLabel;
    ED_RESULT: TEdit;
    b_start: TBitBtn;
    b_end: TBitBtn;
    Label7: TLabel;
    cb_breakfast: TComboBox;
    Label8: TLabel;
    ED_Server: TEdit;
    RadioGroup1: TRadioGroup;
    BitBtn1: TBitBtn;
    Label4: TLabel;
    Ed_CardID: TEdit;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure b_startClick(Sender: TObject);
    procedure b_endClick(Sender: TObject);
    procedure b_readClick(Sender: TObject);
    procedure b_eraseClick(Sender: TObject);
    procedure b_newkeyClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure b_dupkeyClick(Sender: TObject);
    procedure b_checkoutClick(Sender: TObject);
    procedure RadioGroup1Click(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
    procedure cb_lockChange(Sender: TObject);
  private
    { Private declarations }
    
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

    FUNCTION StartSession(LockCard:integer;DBServer,LogUser:pchar;DBFlag:integer):DWORD; STDCALL external 'LockDll.Dll';

//    FUNCTION StartSession_v2(LockCard,Version:integer;Server,LogUser:pchar):DWORD; STDCALL external 'LockDll.Dll';

    function EndSession():DWORD;stdcall external 'LockDll.Dll';
    FUNCTION ChangeLogUser(LogUser:pchar):DWORD; STDCALL external 'LockDll.Dll';

    FUNCTION NewKey(Port:Integer;RoomNo,CommonDoor,LiftFloor,TimeStr,Holder,IDNo:pchar;breakfast,overflag:integer;CardNo:PInteger):DWORD;STDCALL external 'LockDll.Dll';
    FUNCTION AddKey(Port:Integer;RoomNo,CommonDoor,LiftFloor,TimeStr,Holder,IDNo:pchar;breakfast,overflag:integer;CardNo:PInteger):DWORD;STDCALL external 'LockDll.Dll';
    FUNCTION DupKey(Port:Integer;RoomNo,CommonDoor,LiftFloor,TimeStr,Holder,IDNo:pchar;breakfast,overflag:integer;CardNo:PInteger):DWORD;STDCALL external 'LockDll.Dll';

    function ReadKeyCard(Port:Integer;RoomNo,CommonDoor,LiftFloor,TimeStr,Holder,IDNo:pchar;CardNo,CardStatus,breakfast:pinteger):DWORD;stdcall external 'LockDll.Dll';

    function EraseKeyCard(Port,cardno:integer):DWORD;stdcall external 'LockDll.Dll';

    FUNCTION CheckOut(RoomNo:pchar;CardNo:integer):DWORD;STDCALL external 'LockDll.Dll';
    Function ReadCardID(Port:Integer;dwCardId:PDWORD):DWORD; stdcall external 'LockDll.Dll';

implementation

{$R *.dfm}

procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
     endsession;
end;

procedure TForm1.b_startClick(Sender: TObject);
var
   s:string;
   lStatus:DWORD;
   software:integer;
begin
     s:=trim(ed_server.Text);

     software:=cb_lock.ItemIndex+1;

     ed_result.Text:='Executing...';

     Application.ProcessMessages;

     lStatus:=StartSession(software,pchar(s),'DllUser',RadioGroup1.ItemIndex);

     ed_result.Text:=inttohex(lStatus,8);
end;

procedure TForm1.b_endClick(Sender: TObject);
var
   lStatus:DWORD;
begin
     ed_result.Text:='Executing...';

     Application.ProcessMessages;

     lStatus:=EndSession();

     ed_result.Text:=inttohex(lStatus,8);
end;

procedure TForm1.b_readClick(Sender: TObject);
VAR
   lStatus:DWORD;
   ROOM,STIME,Holder,IDNo,CommonDoor,LiftFloor:ARRAY[0..127] OF CHAR;
   CARDNO,ST,port,breakfast:INTEGER;
begin
     port:=cb_port.ItemIndex;

     ed_result.Text:='Executing...';

     Application.ProcessMessages;

     lStatus:=ReadKeyCard(port,@ROOM[0],@CommonDoor[0],@LiftFloor[0],@STIME[0],@Holder[0],@IDNo[0],@CARDNO,@ST,@breakfast);

     ed_result.Text:=inttohex(lStatus,8);
     if lStatus=ERROR_SUCCESS then begin
        ed_roomno.TEXT:=TRIM(ROOM);
        ed_time.TEXT:=TRIM(STIME);
        ed_cardno.TEXT:=INTTOSTR(CARDNO);
        ed_holder.TEXT:=TRIM(Holder);
        ed_IDNo.TEXT:=TRIM(IDNo);
        ed_status.TEXT:=inttostr(ST);
        cb_breakfast.ItemIndex:=breakfast;
     end;
end;

procedure TForm1.b_eraseClick(Sender: TObject);
VAR
   lStatus:DWORD;
   CARDNO,port:INTEGER;
begin
     TRY
        CARDNO:=STRTOINT(ed_cardno.Text);
     EXCEPT
        CardNo:=0;
     END;

     port:=cb_port.ItemIndex;

     ed_result.Text:='Executing...';

     Application.ProcessMessages;

     lStatus:=EraseKeyCard(port,CARDNO);

     ed_result.Text:=inttohex(lStatus,8);
end;

procedure TForm1.b_newkeyClick(Sender: TObject);
VAR
   lStatus:DWORD;
   CARDNO,OVERFLAG,port,breakfase:INTEGER;
   ROOM,STIME,Holder,IDNo:STRING;
begin
     IF ck_over.Checked THEN
        OVERFLAG:=1
     ELSE
        OVERFLAG:=0;

     ROOM:=ed_roomno.TEXT;
     STIME:=ed_time.TEXT;
     Holder:=ed_holder.TEXT;
     IDNo:=ed_IDNo.Text;

     port:=cb_port.ItemIndex;

     breakfase:=cb_breakfast.ItemIndex;

     ed_result.Text:='Executing...';

     Application.ProcessMessages;

     lStatus:=NewKey(Port,PCHAR(ROOM),nil,nil,PCHAR(STIME),PCHAR(Holder),PCHAR(IDNo),breakfase,OVERFLAG,@CARDNO);

     if lStatus=ERROR_SUCCESS THEN
        ed_cardno.TEXT:=INTTOSTR(CARDNO);

     ed_result.Text:=inttohex(lStatus,8);
end;

procedure TForm1.FormShow(Sender: TObject);
begin
     ED_TIME.Text:=formatdatetime('yyyymmdd',date())+'1200'+
        formatdatetime('yyyymmdd',date()+1)+'1200';
end;

procedure TForm1.b_dupkeyClick(Sender: TObject);
VAR
   lStatus:DWORD;
   CARDNO,OVERFLAG,port,breakfase:INTEGER;
   ROOM,STIME,Holder,IDNo:STRING;
begin
     IF ck_over.Checked THEN
        OVERFLAG:=1
     ELSE
        OVERFLAG:=0;

     ROOM:=ed_roomno.TEXT;
     STIME:=ed_time.TEXT;
     Holder:=ed_holder.TEXT;
     IDNo:=ed_IDNo.Text;

     port:=cb_port.ItemIndex;

     breakfase:=cb_breakfast.ItemIndex;

     ed_result.Text:='Executing...';

     Application.ProcessMessages;

     lStatus:=DupKey(Port,PCHAR(ROOM),nil,nil,PCHAR(STIME),PCHAR(Holder),PCHAR(IDNo),breakfase,OVERFLAG,@CARDNO);

     if lStatus=ERROR_SUCCESS THEN
        ed_cardno.TEXT:=INTTOSTR(CARDNO);

     ed_result.Text:=inttohex(lStatus,8);
end;

procedure TForm1.b_checkoutClick(Sender: TObject);
VAR
   lStatus:DWORD;
   CARDNO:INTEGER;
   sroom:String;
begin
     TRY
        CARDNO:=STRTOINT(ed_cardno.Text);
     EXCEPT
        CardNo:=0;
     END;

     sroom:=ed_roomno.Text;

     ed_result.Text:='Executing...';

     Application.ProcessMessages;

     lStatus:=CheckOut(pchar(sroom),CARDNO);

     ed_result.Text:=inttohex(lStatus,8);
end;

procedure TForm1.RadioGroup1Click(Sender: TObject);
begin
  if RadioGroup1.ItemIndex=0 then
     if cb_lock.ItemIndex=0 then
        Ed_Server.Text:='C:\Program Files\HONGLG\MHA V8.0'
     else
        Ed_Server.Text:='C:\Program Files\HONGLG\THA V8.0'
  else
    Ed_Server.Text:='(local)';
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
VAR
   lStatus,cardid:DWORD;
   port:INTEGER;
begin
     port:=cb_port.ItemIndex;

     ed_result.Text:='Executing...';

     Application.ProcessMessages;

     lStatus:=ReadCardID(port,@cardid);

     ed_result.Text:=inttohex(lStatus,8);
     if lStatus=ERROR_SUCCESS then begin
        ed_CardID.Text:=inttohex(cardid,8);
     end;
end;

procedure TForm1.cb_lockChange(Sender: TObject);
begin
  if RadioGroup1.ItemIndex=0 then
    if cb_lock.ItemIndex=0 then
      ed_server.Text:='C:\Program Files\HONGLG\MHA V8.0'
    else
      ed_server.Text:='C:\Program Files\HONGLG\THA V8.0'
end;

end.
