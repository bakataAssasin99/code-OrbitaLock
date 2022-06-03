unit DLL_Header;

interface
  
const DLL_NAME = 'CardLock.DLL';
type
//下面都是定义了函数指针    ，在下面var 后面例化这些函数指针变量


TReadBlock= function(
                     Com :integer;
                     Encrypt :integer;
                     nBlock :integer;
                     CardPassword :pchar;
                     DataBank :pchar

                    ) : integer; stdcall ;//; external  DllName;



TWriteBlock= function(
                        Com :integer;
                        Encrypt :integer;
                        nBlock :integer;
                        CardPassword :pchar;
                        DataBank :pchar

                    ): integer; stdcall ;//; external  DllName;


TKeyCard= function(
                      Com :integer;
                      CardNo :integer;
                      nBlock :integer;
                      Encrypt :integer;
                      CardPass :pchar;
                      SystemCode :pchar;
                      HotelCode  :pchar;
                      Pass :pchar;
                      Address :pchar;
                      SDIn :pchar;
                      STIn :pchar;
                      SDOut :pchar;
                      STOut :pchar;
                      LEVEL_Pass :integer;
                      PassMode :integer;
                      AddressMode  :integer;
                      AddressQty  :integer;
                      TimeMode :integer;
                      V8  :integer;
                      V16  :integer;
                      V24 :integer;
                      AlwaysOpen :integer;
                      OpenBolt  :integer;
                      TerminateOld :integer;
                      ValidTimes :integer

                    ): integer; stdcall ;//; external  DllName;

 //EXTERN_API int WINAPI ReadMessage(int Com ,int nBlock,int Encrypt,int* DBCardno,int* DBCardtype,int* DBPassLevel,
//      char* CardPass,char* DBSystemcode,char* DBAddress, char* SDateTime);
 TReadMessage= function(
                      Com                  :integer;
                      nBlock               :integer;
                      Encrypt              :integer;
                      DBCardNo             :Pinteger;
                      DBCardtype           :Pinteger;
                      DBPassLevel          :Pinteger;
                      CardPass             :pchar;
                      DBSystemcode         :pchar;
                      DBAddress            :pchar;
                      SDateTime            :pchar

                    ): integer; stdcall ;//; external  DllName;

 var
 F_TKeyCard : TKeyCard;
 F_TReadMessage : TReadMessage;
 F_TReadBlock : TReadBlock;
 F_TWriteBlock : TWriteBlock;

implementation



end.

