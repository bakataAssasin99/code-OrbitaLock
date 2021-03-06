unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,DBTables,inifiles,FileCtrl,math,
  DLL_Header,  ExtCtrls, ComCtrls, Buttons;

type
  TForm1 = class(TForm)
    GuestCard: TButton;
    Label1: TLabel;
    DTPSDOut: TDateTimePicker;
    DTPSTOut: TDateTimePicker;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    EditCom: TEdit;
    EditValidTimes: TEdit;
    BReadCard: TButton;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label13: TLabel;
    Label14: TLabel;
    Label15: TLabel;
    EditCardNo: TEdit;
    EditTimeMode: TEdit;
    EditAddressQty: TEdit;
    EditnBlock: TEdit;
    EditEncrypt: TEdit;
    EditAddressMode: TEdit;
    EditCardPass: TEdit;
    EditSystemCode: TEdit;
    EditHotelCode: TEdit;
    EditPass: TEdit;
    EditAddress: TEdit;
    DTPSDIn: TDateTimePicker;
    DTPSTIn: TDateTimePicker;
    Label16: TLabel;
    Label17: TLabel;
    Label18: TLabel;
    Label19: TLabel;
    EditLevelPass: TEdit;
    EditPassMode: TEdit;
    Label20: TLabel;
    Label21: TLabel;
    EditV8: TEdit;
    Label22: TLabel;
    Label23: TLabel;
    EditV16: TEdit;
    EditV24: TEdit;
    EditAlwaysOpen: TEdit;
    Label24: TLabel;
    Label25: TLabel;
    EditOpenBolt: TEdit;
    CheckBoxTerminateOld: TCheckBox;
    ReadBlock: TButton;
    WriteBlock: TButton;
    Label6: TLabel;
    EditWriteBank: TEdit;
    Label26: TLabel;
    Edit1: TEdit;
    Label27: TLabel;
    Edit2: TEdit;
    Label28: TLabel;
    Edit3: TEdit;
    Label29: TLabel;
    Edit4: TEdit;
    Label30: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure GuestCardClick(Sender: TObject);

    procedure FormShow(Sender: TObject);
    procedure BReadCardClick(Sender: TObject);
    procedure ReadBlockClick(Sender: TObject);
    procedure WriteBlockClick(Sender: TObject);

  private

  public
    { Public declarations }
  end;

var
  Form1: TForm1;

  var
    g_dllhandle : THandle;    //DLL Handle

implementation


{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  g_dllhandle := LoadLibrary('HNAccessG.DLL');

	if( g_dllhandle=0) then
         MessageBox(0,'Repatriate a dynamic library HNAccessGDLL Failed!','Error',MB_OK);
end;




function CompactCipherTime(DT:TDateTime):String;
var
  Scipher:string;
  Buffer:string;
   dw:DWORD;
   Year, Month, Day, Hour, Min, Sec, MSec:Word;
   i:integer;
begin
  DecodeDate(DT, Year, Month, Day);
  DecodeTime(DT, Hour, Min, Sec, MSec);
  dw:=(Min div 4)+(Hour shl 4)+(Day shl 9)+(Month shl 14)+((((Year-8) mod 1000) mod 63) shl 18);
  Buffer:=format('%x',[dw]);
  for i :=1  to 8 do
  begin
    Buffer[i]:=UpCase(Buffer[i]);
  end;
  Scipher:=Buffer;
  result:=(Scipher);
end;




procedure TForm1.GuestCardClick(Sender: TObject);
var
  RoomPass:string;
  Ret  :integer;
begin
  if (EditSystemCode.Text='')or(EditHotelCode.Text='') then
  begin
    showmessage('The information is incomplete!');
    exit;
  end;
  
    F_TKeyCard :=  TKeyCard( GetProcAddress(g_dllhandle,'KeyCard'));
    if assigned(F_TKeyCard) then
    begin

        if (CheckBoxTerminateOld.Checked)   then
         begin
          RoomPass:=CompactCipherTime(Now);  
          EditPass.Text:=RoomPass;
         end
        else
          RoomPass:=Trim(EditPass.Text);

       //  EXTERN_API int WINAPI KeyCard(int Com,int CardNo,int nBlock,int Encrypt,char* CardPass,char* SystemCode,
     // char* HotelCode, char* Pass, char* Address, char* SDIn,char* STIn, char* SDOut,char* STOut,
     // int LEVEL_Pass,int PassMode,int AddressMode,int AddressQty,int TimeMode,
     // int V8, int V16, int V24, int AlwaysOpen, int OpenBolt,int TerminateOld,
     // int ValidTimes);
       Ret:= F_TKeyCard(
             StrToInt(EditCom.Text),
             StrToInt(EditCardNo.Text),
             StrToInt(EditnBlock.Text),
             StrToInt(EditEncrypt.Text),
             pchar(EditCardPass.Text),
             pchar(EditSystemCode.Text),
             pchar(EditHotelCode.Text),
             pchar(RoomPass),
             pchar(EditAddress.Text),
             pchar(FormatDateTime('yy-MM-dd', DTPSDIn.Date)),    //"yy-mm-dd",cannot "yyyy-mm-dd"
             pchar(FormatDateTime('hh:nn:ss', DTPSTIn.Time)),    //"hh:nn:ss"
             pchar(FormatDateTime('yy-MM-dd', DTPSDOut.Date)),   //"yy-mm-dd",cannot "yyyy-mm-dd"
             pchar(FormatDateTime('hh:nn:ss', DTPSTOut.Time)),  // "hh:nn:ss"
             StrToInt(EditLevelPass.Text),                         //Default 3
             StrToInt(EditPassMode.Text),                          //Default 1
             StrToInt(EditAddressMode.Text),                       //Default 0
             StrToInt(EditAddressQty.Text),                        //Default 1
             StrToInt(EditTimeMode.Text),                          //Default 0
             StrToInt(EditV8.Text),                                //Default 255
             StrToInt(EditV16.Text),                               //Default 255
             StrToInt(EditV24.Text),                               //Default 255
             StrToInt(EditAlwaysOpen.Text),                        //Default 0
             StrToInt(EditOpenBolt.Text),                          //Default 0
             Integer(CheckBoxTerminateOld.Checked),
             StrToInt(EditValidTimes.Text)                         //Default 255           
         );

       if( Ret =0 ) then
         MessageBox(0,'Issue card successfully??','Successfully??',MB_OK)
       else
         MessageBox(0,pchar('Issue card failed??Error Code??'+IntToStr(Ret)),'Failed??',0+48);
    end

    else
     begin
      MessageBox(0,'Access port failed??','Failed??',0+48);
     end;
end;



procedure TForm1.FormShow(Sender: TObject);
var
  ini:tinifile;
begin

    DTPSDOut.DateTime:=now+10;
    DTPSTOut.DateTime:=now+10;

end;


procedure TForm1.BReadCardClick(Sender: TObject);
var
   Ret :Integer;
   CardNumber, CardType, PassLevel, Room, Door, yy, mm, dd,hh, nn, ss: Integer;
   charAddress   :   array   [1..64]   of   Char;
   charDateTime  :   array   [1..64]   of   Char;
   ptrAddress   :    PChar;
   ptrDateTime   :    PChar;
begin
    ptrAddress :=@charAddress;
    ptrDateTime :=@charDateTime;
    F_TReadMessage := TReadMessage( GetProcAddress(g_dllhandle,'ReadMessage'));
    if assigned(F_TReadMessage) then
      begin

        Ret:= F_TReadMessage(
             StrToInt(EditCom.Text),
             StrToInt(EditnBlock.Text),
             StrToInt(EditEncrypt.Text),
             @CardNumber              ,
             @CardType                ,
             @PassLevel               ,
             pchar(EditCardPass.Text),
             pchar(EditSystemCode.Text),
             ptrAddress,
             ptrDateTime

            );

            if Ret =0  then
              begin
                MessageBox(0,pchar('Read card successfully??CardNo??'+IntToStr(CardNumber) ),'Read Card Success',MB_OK)
              end
            else
               MessageBox(0,'Read card failed??','Failed??',0+48);

        end
    else
      begin
        MessageBox(0,'Access port failed??','Failed??',0+48)
      end;
end;

procedure TForm1.ReadBlockClick(Sender: TObject);
var
        Ret  :integer;
        SMessage :string;
        MessChar   :   array   [1..254]   of   Char;
        RDataBank :pchar;
begin
     RDataBank :=@MessChar;
     F_TReadBlock := TReadBlock( GetProcAddress(g_dllhandle,'ReadBlock'));
    if assigned(F_TReadBlock) then
        begin


                Ret:=F_TReadBlock(
                                StrToInt(Edit1.Text),
                                StrToInt(Edit3.Text),
                                StrToInt(Edit2.Text),
                                pchar(Edit4.Text),
                                @MessChar

                                );
                if Ret =0  then
                   begin
                        RDataBank:=  @MessChar;
                        SMessage:=strpas(RDataBank);
                        showmessage(UpperCase(SMessage));
                     end
                    else
                        MessageBox(0,'Read record failed??','Failed??',0+48);

        end
     else
      begin
        MessageBox(0,'Access port failed??','Failed??',0+48)
      end;
end;

procedure TForm1.WriteBlockClick(Sender: TObject);
var
        Ret,i  :integer;
        SMessage,STrim :string;
        MessChar   :   array   [1..254]   of   Char;
begin
        if (EditWriteBank.Text='') then
        begin
          showmessage('Please input information!');
          EditWriteBank.SetFocus;
          exit;
        end;
         SMessage:=EditWriteBank.Text ;

         for i:=1 to Length(SMessage) do
         begin
             MessChar[i]:=SMessage[i];
         end;

        F_TWriteBlock := TWriteBlock( GetProcAddress(g_dllhandle,'WriteBlock'));
    if assigned(F_TWriteBlock) then
        begin


                Ret:=F_TWriteBlock(
                                StrToInt(Edit1.Text),
                                StrToInt(Edit3.Text),
                                StrToInt(Edit2.Text),
                                pchar(Edit4.Text),
                                @MessChar

                                );
                if Ret =0  then
                   begin
                        showmessage(pchar('Write data successfully!')) ;
                     end
                    else
                        MessageBox(0,'Write data failed??','Failed??',0+48);

        end
     else
      begin 
        MessageBox(0,'Access port failed??','Failed??',0+48)
      end;
end;

end.
