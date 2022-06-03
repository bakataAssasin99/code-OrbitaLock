using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DWord.Services.Archie
{
    class ArchieLockSDK
    {
        [DllImport("MFCard.dll")]
        public static extern bool MF_OpenConnection(Int32 cport, Int32 cbaud);

        [DllImport("MFCard.dll")]
        public static extern Int32 MF_Rewrite_AutCode(Int32 isAdmin);

        [DllImport("MFCard.dll")]
        public static extern Int32 MF_W_CommonCard(ref Int32 InfoData, DateTime startTime, DateTime endTime);

        [DllImport("MFCard.dll")]
        public static extern Int32 MF_GetFlag(Int32 openBackLock, Int32 compareTime, Int32 loss, Int32 drive);

        [DllImport("MFCard.dll")]
        public static extern Int32 MF_GetSuite(ref byte s);

        [DllImport("MFCard.dll")]
        public static extern Int32 MF_R_CommonCard(ref Int32 InfoData, out DateTime startTime, out DateTime endTime);

        [DllImport("MFCard.dll")]
        public static extern void MF_SetFlag(Int32 flag, out Int32 openBackLock, out Int32 compareTime, out Int32 loss, out Int32 drive);

        [DllImport("MFCard.dll")]
        public static extern void MF_setSuite(Int32 suite, out byte s);
    }
}
