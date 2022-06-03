using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DWord.Services.OrbitaLock
{
    class OrbitaSDK
    {
        [DllImport("CLock.dll",
            CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 dv_connect(Int16 beep);
        [DllImport("CLock.dll",
            CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 dv_read_card([In, Out] char[] auth, [In, Out] char[] cardno, [In, Out] char[] building, [In, Out] char[] room, [In, Out] char[] commdoors, [In, Out] char[] arrival, [In, Out] char[] departure);
        [DllImport("CLock.dll",
           CharSet = CharSet.Ansi,
           CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 dv_get_auth_code([In, Out] char[] auth);
        [DllImport("CLock.dll",
            CharSet = CharSet.Ansi,
            CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 dv_write_card([In, Out] char[] auth, [In, Out] char[] building, [In, Out] char[] room, [In, Out] char[] commdoors, [In, Out] char[] arrival, [In, Out] char[] departure);

        [DllImport("CLock.dll",
           CharSet = CharSet.Ansi,
           CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 dv_delete_card([In, Out] char[] room);
    }
}
