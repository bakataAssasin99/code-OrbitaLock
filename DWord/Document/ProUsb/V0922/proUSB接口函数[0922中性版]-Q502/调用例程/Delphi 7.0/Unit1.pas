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
    Label5: TLabel;
    Label9: TLabel;
    DateTimePicker1: TDateTimePicker;
    DateTimePicker2: TDateTimePicker;
    GroupBox3: TGroupBox;
    Label2: TLabel;
    Label3: TLabel;
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
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
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
    BitBtn7: TBitBtn;
    BitBtn8: TBitBtn;
    BitBtn9: TBitBtn;
    BitBtn10: TBitBtn;
    BitBtn11: TBitBtn;
    BitBtn12: TBitBtn;
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
    procedure BitBtn12Click(Sender: TObject);
  private
    { Private declarations }
    function rdCard: Boolean;
  public
    { Public declarations }
  end;

var
  Form1:        TForm1;
  flagUSB:      Integer;    //发卡器类型,0--有驱USB发卡器,1--proUSB
  st:           Integer;
  bufCard:      Array[0..128] of char;

implementation

  //读DLL版本号
  function GetDLLVersion(sDllVer:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //打开USB
  function initializeUSB(fUSB: Byte): Integer; stdcall;
    external 'proRFL.DLL';
  //关闭proUSB
  procedure CloseUSB(fUSB: Byte); stdcall;
    external 'proRFL.DLL';
  //蜂鸣器
  function Buzzer(fUSB:Byte;t: Integer):Integer; stdcall;
    external 'proRFL.DLL';
  //读卡数据
  function ReadCard(fUSB:Byte;Buffer:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //读取57卡固有的ID号
  function ReadCardID_T5557(fUSB:Byte;Buffer:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //客人卡
  //int __stdcall GuestCard(uchar fUSB,int dlsCoID,uchar CardNo,uchar dai,uchar LLock,uchar pdoors,uchar BDate[10],uchar EDate[10],uchar RoomNo[8],uchar *cardHexStr)
  function GuestCard(fUSB:Byte;dlsCoID:Integer;CardNo,dai,llock,pdoors:Byte;BDate,EDate,RoomNo:Pchar;CardHexStr:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //挂失卡
  //int __stdcall LimitCard(uchar d12,int dlsCoID,uchar CardNo,uchar dai,uchar BDate[10],uchar LCardNo[4],uchar *cardHexStr)
  function LimitCard(fUSB:Byte;dlsCoID:Integer;CardNo,dai:Byte;BDate,LCardNo:Pchar;CardHexStr:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //注销卡片
  //int __stdcall CardErase(uchar fUSB,int dlsCoID,unsigned char *cardHexStr)
  function CardErase(fUSB:Byte;dlsCoID:Integer;cardHexStr:PChar):Integer; stdcall;
    external 'proRFL.DLL';
  //HEX-ASC
  //__int16 __stdcall hex_a(unsigned char *hex,unsigned char *a,__int16 len)
  function hex_a(hex,asc:PChar;hLen:Integer):Integer; stdcall;
    external 'proRFL.DLL';
  //ASC-HEX
  //__int16 __stdcall a_hex(unsigned char *a,unsigned char *hex,__int16 len)
  function a_hex(asc,hex:PChar;aLen:Integer):Integer; stdcall;
    external 'proRFL.DLL';

  //读取卡片类型
  //int __stdcall GetCardTypeByCardDataStr(unsigned char *CardDataStr,unsigned char *CardType)
  function GetCardTypeByCardDataStr(cardHexStr,CardType:PChar):Integer; stdcall;
    external 'proRFL.DLL';

  //读取客人卡锁号
  //int __stdcall GetGuestLockNoByCardDataStr(int dlsCoID,unsigned char *CardDataStr,unsigned char *LockNo)
  function GetGuestLockNoByCardDataStr(dlsCoID: Integer;cardHexStr,LockNo:PChar):Integer; stdcall;
    external 'proRFL.DLL';

  //读取客人离店时间
  //int __stdcall GetGuestETimeByCardDataStr(int dlsCoID,unsigned char *CardDataStr,unsigned char *eTime)
  function GetGuestETimeByCardDataStr(dlsCoID: Integer;cardHexStr,eTime:PChar):Integer; stdcall;
    external 'proRFL.DLL';

  //读取开门记录
  //int __stdcall ReadRecord(uchar d12,unsigned char *buffData)
  function ReadRecord(fUSB:Byte;bufData:PChar):Integer; stdcall;
    external 'proRFL.DLL';

  //根据记录仪数据解析开门记录
  //int __stdcall GetOpenRecordByDataStr(unsigned char *DataStr,unsigned char *sOpen)
  function GetOpenRecordByDataStr(DataStr,sOpen:PChar):Integer; stdcall;
    external 'proRFL.DLL';

{$R *.dfm}

//读卡,有错误提示
//同时返回当前卡的ID（卡类型、卡号、发卡时间）--copy(bufCard,25,8)
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
    Application.MessageBox(PCHAR('读卡失败'+#10+IntToStr(st)),'提示',MB_OK+MB_ICONERROR);
    goto Exit_rdCard;
  end;
  if copy(bufCard,5,2)<>'01' then begin       //不一定是551501
    Application.MessageBox(PCHAR('发卡器的感应区无卡'+#10+bufCard),'提示',MB_OK+MB_ICONWARNING);
    goto Exit_rdCard;
  end;
  Result:=True;
Exit_rdCard:
  Screen.Cursor:=crDefault;
end;

procedure TForm1.FormShow(Sender: TObject);
begin
  flagUSB:=1;   //默认proUSB
  DateTimePicker1.DateTime:=Now+1;
end;

procedure TForm1.cmdExitClick(Sender: TObject);
begin
  Close;
end;

//恢复到默认值
procedure TForm1.BitBtn4Click(Sender: TObject);
begin
  edt_CardNo.Text:='0';
  edt_LockNo.Text:='01020399';
  edt_Dai.Text:='0';
end;

//读DLL版本号
procedure TForm1.BitBtn6Click(Sender: TObject);
var
  st:     Integer;
  sa1:    Array[0..128] of char;
begin
  st:=GetDLLVersion(sa1);
  StatusBar1.Panels[0].Text:=IntToStr(st);
  StatusBar1.Panels[1].Text:=sa1;
  if st=0 then
    Application.MessageBox(Pchar('DLL版本号：'+StrPas(sa1)),'提示',MB_OK+MB_ICONINFORMATION);
end;

procedure TForm1.RadioButton3Click(Sender: TObject);
begin
  flagUSB:=0;   //有驱USB
end;

procedure TForm1.RadioButton4Click(Sender: TObject);
begin
  flagUSB:=1;   //proUSB
end;

//打开USB
procedure TForm1.Button1Click(Sender: TObject);
var
  st:   Integer;
begin
  st:=initializeUSB(flagUSB);       //0表示有驱USB, 1表示proUSB
  if st<>0 then
    Application.MessageBox(Pchar('打开USB失败'+#10+IntToStr(st)),'提示',MB_OK+MB_ICONWARNING)
  else begin
    Application.MessageBox('打开USB成功','提示',MB_OK+MB_ICONINFORMATION);
    Button3.Enabled:=True;
    GroupBox4.Enabled:=True;
  end;
end;

//蜂鸣器
procedure TForm1.BitBtn1Click(Sender: TObject);
begin
  Buzzer(flagUSB,50);   //发卡器鸣叫50x10毫秒
end;

//注销卡片
procedure TForm1.BitBtn5Click(Sender: TObject);
var
  st:     Integer;
  sa1:    Array[0..128] of char;
begin
  if not rdCard then Exit;   //先读卡
  st:=CardErase(flagUSB,StrToIntDef(edt_coID.Text,0),sa1);
  if flagUSB=1 then Buzzer(flagUSB,20);      //写卡后鸣叫一声，因为CardErase函数本身不会有响声
  edt_CardData.Text:=StrPas(sa1);
  if st<>0 then
    Application.MessageBox(Pchar('注销失败'+#10+IntToStr(st)),'提示',MB_OK+MB_ICONWARNING)
  else begin
    Application.MessageBox('注销成功','提示',MB_OK+MB_ICONINFORMATION);
  end;
end;

//卡片挂失
procedure TForm1.BitBtn10Click(Sender: TObject);
var
  st:       Integer;
  limitNo:  Array[0..3] of char;
  sa1:      Array[0..128] of char;
begin
  if not rdCard then Exit;   //先读卡
  //挂失卡号: 6012D291
  limitNo[0]:=chr($60);
  limitNo[1]:=chr($12);
  limitNo[2]:=chr($d2);
  limitNo[3]:=chr($91);
  st:=LimitCard(flagUSB,
                StrToIntDef(edt_coID.Text,0),    //dlsCoID
                StrToIntDef(edt_CardNo.Text,0),  //CardNo
                StrToIntDef(edt_Dai.Text,0),     //dai
                PCHAR(FormatDateTime('YYMMDDHHMM',Now)),
                limitNo,
                sa1);
  if flagUSB=1 then Buzzer(flagUSB,20);      //写卡后鸣叫一声，因为LimitCard函数本身不会有响声
  edt_CardData.Text:=StrPas(sa1);
  if st<>0 then
    Application.MessageBox(Pchar('调用挂失卡函数失败'+#10+IntToStr(st)),'提示',MB_OK+MB_ICONWARNING)
  else begin
    Application.MessageBox(Pchar('调用挂失卡函数成功'+#10+'本例子挂失卡号为: 6012D291'),'提示',MB_OK+MB_ICONINFORMATION);
  end;

end;

procedure TForm1.BitBtn2Click(Sender: TObject);
var
  st:            Integer;
  llock,pdoors:  Byte;
  sa1:           Array[0..128] of char;
begin
  if not rdCard then Exit;   //先读卡
  //反锁标志
  llock:=0;
  if RadioButton1.Checked then llock:=1;
  //公共门标志
  pdoors:=1;
  //退房时间
  DateTimePicker1.Time:=DateTimePicker2.Time;
  st:=GuestCard(flagUSB,
                StrToIntDef(edt_coID.Text,0),    //dlsCoID
                StrToIntDef(edt_CardNo.Text,0),  //CardNo
                StrToIntDef(edt_Dai.Text,0),     //dai
                llock,pdoors,
                PCHAR(FormatDateTime('YYMMDDHHMM',Now)),   //发卡时间
                PCHAR(FormatDateTime('YYMMDDHHMM',DateTimePicker1.DateTime)),  //退房时间
                PCHAR(edt_LockNo.Text),      //锁号
                sa1);                        //卡数据
  if flagUSB=1 then Buzzer(flagUSB,20);      //写卡后鸣叫一声，因为GuestCard函数本身不会有响声
  edt_CardData.Text:=StrPas(sa1);
  if st<>0 then
    Application.MessageBox(Pchar('调用发卡函数失败'+#10+IntToStr(st)),'提示',MB_OK+MB_ICONWARNING)
  else begin
    Application.MessageBox('调用发卡函数成功','提示',MB_OK+MB_ICONINFORMATION);
  end;

end;

//从现有卡片读取酒店标识
procedure TForm1.Button3Click(Sender: TObject);
var
  i:   Integer;
  s:   String;
begin
  if not rdCard then Exit;   //先读卡
  if copy(bufCard,25,8)='FFFFFFFF' then begin
    edt_coID.Text:='';
    Application.MessageBox('此卡是空白卡，请换一张能开门的卡','提示',MB_OK+MB_ICONWARNING);
    Exit;
  end;
  s:=copy(bufCard,11,4);
  i:=StrToInt('$'+s) mod 16384;
  s:=copy(bufCard,9,2);
  i:=i+(StrToInt('$'+s) * 65536);
  edt_coID.Text:=IntToStr(i);
end;

//读卡
procedure TForm1.BitBtn3Click(Sender: TObject);
begin
  if not rdCard then Exit;   //先读卡
  edt_CardData.Text:=StrPas(bufCard);
  Application.MessageBox(Pchar(('卡的流水号：'+copy(bufCard,25,8)+char(13)+'卡的固有ID号：'+copy(bufCard,57,8))),'提示',MB_OK+MB_ICONINFORMATION);
end;

procedure TForm1.BitBtn7Click(Sender: TObject);
var
  CardType:      Array[0..16] of char;
begin
  if not rdCard then Exit;   //先读卡
  edt_CardData.Text:=StrPas(bufCard);
  st:=GetCardTypeByCardDataStr(bufCard,CardType);
  if st<>0 then
    Application.MessageBox(Pchar(('卡数据串无效：'+IntToStr(st))),'提示',MB_OK+MB_ICONWARNING)
  else
    if CardType[0]='0' then
      Application.MessageBox('授权卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='1' then
      Application.MessageBox('记录卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='2' then
      Application.MessageBox('房号设置卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='3' then
      Application.MessageBox('时间设置卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='4' then
      Application.MessageBox('限制卡[挂失卡]','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='5' then
      Application.MessageBox('组号设置卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='6' then
      Application.MessageBox('客人卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='7' then
      Application.MessageBox('退房卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='8' then
      Application.MessageBox('组控卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='9' then
      Application.MessageBox('未知卡[无此类型]','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='A' then
      Application.MessageBox('应急卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='B' then
      Application.MessageBox('总控卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='C' then
      Application.MessageBox('楼栋卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='D' then
      Application.MessageBox('楼层卡','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='E' then
      Application.MessageBox('未知卡[无此类型]','提示',MB_OK+MB_ICONINFORMATION)
    else if CardType[0]='F' then
      Application.MessageBox('空白卡','提示',MB_OK+MB_ICONINFORMATION);
end;

procedure TForm1.BitBtn8Click(Sender: TObject);
var
  LockNo:      Array[0..16] of char;
begin
  if not rdCard then Exit;   //先读卡
  edt_CardData.Text:=StrPas(bufCard);
  st:=GetGuestLockNoByCardDataStr(StrToIntDef(edt_coID.Text,0),bufCard,LockNo);
  if st=0 then
    Application.MessageBox(PChar('锁号:'+#10+LockNo),'提示',MB_OK+MB_ICONINFORMATION)
  else if st=1 then
    Application.MessageBox(PChar('卡数据串无效'+#10+bufCard),'提示',MB_OK+MB_ICONWARNING)
  else if st=2 then
    Application.MessageBox(Pchar('非本酒店卡'+#10+bufCard),'提示',MB_OK+MB_ICONWARNING)
  else if st=3 then
    Application.MessageBox(Pchar('不是客人卡'+#10+bufCard),'提示',MB_OK+MB_ICONWARNING)
  else
    Application.MessageBox(Pchar('未知返回值'+#10+IntToStr(st)+#10+bufCard),'提示',MB_OK+MB_ICONWARNING);
end;

procedure TForm1.BitBtn9Click(Sender: TObject);
var
  ETime:      Array[0..16] of char;
begin
  if not rdCard then Exit;   //先读卡
  edt_CardData.Text:=StrPas(bufCard);
  st:=GetGuestETimeByCardDataStr(StrToIntDef(edt_coID.Text,0),bufCard,ETime);
  if st=0 then
    Application.MessageBox(PChar('离店时间:'+#10+ETime),'提示',MB_OK+MB_ICONINFORMATION)
  else if st=1 then
    Application.MessageBox(PChar('卡数据串无效'+#10+bufCard),'提示',MB_OK+MB_ICONWARNING)
  else if st=2 then
    Application.MessageBox(Pchar('非本酒店卡'+#10+bufCard),'提示',MB_OK+MB_ICONWARNING)
  else if st=3 then
    Application.MessageBox(Pchar('不是客人卡'+#10+bufCard),'提示',MB_OK+MB_ICONWARNING)
  else
    Application.MessageBox(Pchar('未知返回值'+#10+IntToStr(st)+#10+bufCard),'提示',MB_OK+MB_ICONWARNING);
end;

//读取并解析开门记录
procedure TForm1.BitBtn11Click(Sender: TObject);
var
  fiq:         Boolean;
  s,s1:        String;
  i,j,k:       Integer;
  sOpen:       Array[0..16] of char;
  bufRec:      Array[0..20000] of char;
begin
  Screen.Cursor:=crHourGlass;
  st:=ReadRecord(flagUSB,bufRec);
  Screen.Cursor:=crDefault;
  if st<>0 then begin
    if Application.MessageBox(PCHAR('读取开门记录失败，是否继续？'+#10+IntToStr(st)), '错误提示',
           MB_OKCANCEL+MB_ICONQUESTION+MB_DEFBUTTON2) = mrCancel then Exit;
  end;

  //每帧数据74个字符，前8帧是系统数据，每帧的前6位是552101，最后4位是帧号与校验
  //k:=(length(StrPas(bufRec)) div 74);   //数据帧数
  //k:=k*4;                               //每帧4条记录
  //for i:=0 to k-1 do begin
  for i:=0 to 223 do begin      //一般是224条记录
    j:=(i mod 4);
    if j=0 then begin
      s1:=copy(bufRec,(i div 4)*74+74*8+1,74);
    end;
    if st<>0 then
      s:='6B15458D15EA3941'    //客人卡，2010/05/29 08:57:02
    else
      s:=copy(s1,7+(i mod 4)*16,16);
    fiq:=InputQuery('解析开门记录',PCHAR('请输入原始数据（16个字符）'+#10+'默认第 '+IntToStr(j)+' 条记录'+#10),s);
    if not fiq then Exit;
    if GetOpenRecordByDataStr(PChar(s),sOpen)<>0 then
      Application.MessageBox('解析失败','提示',MB_OK+MB_ICONWARNING)
    else begin
      s:='具体意思为：';
      s:=s+#10+'卡类型：'+sOpen[0];
      s:=s+#10+'时间：20';
      s:=s+sOpen[1]+sOpen[2]+'/'+sOpen[3]+sOpen[4]+'/'+sOpen[5]+sOpen[6];
      s:=s+' '+sOpen[7]+sOpen[8]+':'+sOpen[9]+sOpen[10]+':'+sOpen[11]+sOpen[12];
      Application.MessageBox(PChar('解析出来的字符串：'+sOpen+#10+s),'提示',MB_OK+MB_ICONINFORMATION);
    end;
    if Application.MessageBox(PCHAR('是否继续显示下一条记录？'), '操作提示',
           MB_OKCANCEL+MB_ICONQUESTION+MB_DEFBUTTON2) = mrCancel then Exit;
  end;
end;

//关闭proUSB
procedure TForm1.BitBtn12Click(Sender: TObject);
begin
  CloseUSB(flagUSB);
  Application.MessageBox(PChar('USB端口已关闭，不能进行USB操作'+#10+'如果需要操作USB，请先打开USB'),'提示',MB_OK+MB_ICONINFORMATION);
end;


end.
