using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text; 

namespace DWord.Services.ProUsbNew
{
    class ProUsbNewSDK
    {
        //打开USB
        [DllImport("proRFL.dll", EntryPoint = "initializeUSB")]
        public static extern int initializeUSB(byte aType);
        //蜂鸣器
        [DllImport("proRFL.dll", EntryPoint = "Buzzer")]
        public static extern int Buzzer(byte flagusb, int sc);

        //读DLL版本号
        [DllImport("proRFL.dll", EntryPoint = "GetDLLVersion")]
        public static extern int GetDLLVersion(byte[] aType);
        //读卡数据
        [DllImport("proRFL.dll", EntryPoint = "ReadCard")]
        public static extern int ReadCard(byte flagusb, byte[] carddata);
        //注销卡片
        [DllImport("proRFL.dll", EntryPoint = "CardErase")]
        public static extern int CardErase(byte aType, int coid, byte[] carddata);
        //挂失卡
        //int __stdcall LimitCard(uchar d12,int dlsCoID,uchar CardNo,uchar dai,uchar BDate[10],uchar LCardNo[4],uchar *cardHexStr)

        [DllImport("proRFL.dll", EntryPoint = "LimitCard")]//挂失卡片
        public static extern int LimitCard(byte flagusb, int dlscoid, byte cardno, byte dai, char[] BDate, byte[] LcardNo, byte[] cardbuf);

        //客人卡
        //int __stdcall GuestCard(uchar fUSB,int dlsCoID,uchar CardNo,uchar dai,uchar LLock,uchar pdoors,uchar BDate[10],uchar EDate[10],uchar RoomNo[8],uchar *cardHexStr)
        [DllImport("proRFL.dll", EntryPoint = "GuestCard")]
        public static extern int GuestCard(byte flagusb, int dlscoid, byte cardno, byte dai, byte llock, byte pdoors, char[] BDate, char[] EDate, char[] RoomNo, byte[] cardhexstr);
        //读卡类型
        [DllImport("proRFL.dll", EntryPoint = "GetCardTypeByCardDataStr")]
        public static extern int GetCardTypeByCardDataStr(byte[] carddata, byte[] cardtype);
        //读取客人卡锁号
        //int __stdcall GetGuestLockNoByCardDataStr(int dlsCoID,unsigned char *CardDataStr,unsigned char *LockNo)
        [DllImport("proRFL.dll", EntryPoint = "GetGuestLockNoByCardDataStr")]
        public static extern int GetGuestLockNoByCardDataStr(int dlscoid, byte[] carddata, byte[] lockno);
        //读取客人离店时间
        //int __stdcall GetGuestETimeByCardDataStr(int dlsCoID,unsigned char *CardDataStr,unsigned char *LockNo)
        [DllImport("proRFL.dll", EntryPoint = "GetGuestETimeByCardDataStr")]
        public static extern int GetGuestETimeByCardDataStr(int dlscoid, byte[] carddata, byte[] ETime);
    }
}
