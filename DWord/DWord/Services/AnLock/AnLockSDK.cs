using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text; 

namespace DWord.Services.AnLock
{
    class AnLockSDK
    {
        [DllImport("AnLock_2012.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern short OpenUsb([In][Out] int Optional);

        [DllImport("AnLock_2012.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern short DLL_Read([In][Out] char[] sRtn);

        [DllImport("AnLock_2012.dll", EntryPoint = "DLL_WriteCard", CharSet = CharSet.None, SetLastError = false)]
        public static extern int DLL_WriteCard(String sStr);
    }
}
