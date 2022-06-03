using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DWord.Services.ProUsb
{
    class Hune09LockSDK
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("hunerf.dll", SetLastError = true)]
        public static extern int ReadMessage(int Com, int nBlock, int Encrypt, int* DBCardNo, int* DBCardtype, int* DBPassLevel, string CardPass, string DBSystemcode, string DBAddress, string SDateTime);

        [DllImport("hunerf.dll", SetLastError = true)]
        public static extern int KeyCard(int Com, int CardNo, int nBlock, int Encrypt, string CardPass, string SystemCode, string HotelCode, string Pass, string Address, string SDIn,
           string STIn, string SDOut, string STOut, int LEVEL_Pass, int PassMode, int AddressMode, int AddressQty, int TimeMode, int V8, int V16, int V24, int AlwaysOpen, int OpenBolt, int TerminateOld, int ValidTimes);

        [DllImport("hunerf.dll", SetLastError = true)]//CharSet = CharSet.Auto
        public static extern int ReadCardSN(int Com, StringBuilder CardSN);
    }
}
