using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DWord.Services.ProUsb
{
    class  Hune09LockSDK
    {
        /*
        [DllImport("HUNERF.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("HUNERF.dll", CharSet = CharSet.Ansi)] 

        //public static extern int ReadMessage(int Com, int nBlock, int Encrypt, int* DBCardno, int* DBCardtype, int* DBPassLevel, char* CardPass, char* DBSystemcode, char* DBAddress, char* SDateTime);
        public static extern int ReadMessage(int Com, int nBlock, int Encrypt, [In, Out]  int[] DBCardNo, [In, Out]  int[] DBCardtype, [In, Out] int[] DBPassLevel, [In, Out] char[] CardPass, [In, Out] char[] DBSystemcode, [In, Out] char[] DBAddress, [In, Out] char[] SDateTime);

        [DllImport("HUNERF.dll", CharSet = CharSet.Ansi)]
        public static extern int KeyCard(int Com, int CardNo, int nBlock, int Encrypt, string CardPass, string SystemCode, string HotelCode, string Pass, string Address, string SDIn,
           string STIn, string SDOut, string STOut, int LEVEL_Pass, int PassMode, int AddressMode, int AddressQty, int TimeMode, int V8, int V16, int V24, int AlwaysOpen, int OpenBolt, int TerminateOld, int ValidTimes);

        [DllImport("HUNERF.dll", CharSet = CharSet.Ansi)]//CharSet = CharSet.Auto
        public static extern int ReadCardSN(int Com, StringBuilder CardSN);
        */

        [DllImport("HNAccessG.dll", SetLastError = true)]
        public static unsafe extern int ReadMessage(int Com, int nBlock, int Encrypt, int* DBCardNo, int* DBCardtype, int* DBPassLevel, StringBuilder CardPass, StringBuilder DBSystemcode, StringBuilder DBAddress, StringBuilder SDateTime);


        [DllImport("HNAccessG.dll", SetLastError = true)]
        public static extern int KeyCard(int Com, int CardNo, int nBlock, int Encrypt, StringBuilder CardPass, StringBuilder SystemCode, StringBuilder HotelCode, StringBuilder Pass, StringBuilder Address, StringBuilder SDIn,
           StringBuilder STIn, StringBuilder SDOut, StringBuilder STOut, int LEVEL_Pass, int PassMode, int AddressMode, int AddressQty, int TimeMode, int V8, int V16, int V24, int AlwaysOpen, int OpenBolt, int TerminateOld, int ValidTimes);
    }
}
