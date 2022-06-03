using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text; 

namespace DWord.Services.BTLock
{
    class BTLockSDK
    {
        public static string ConnectionString { get; internal set; }

        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Write_Guest_Card(int Port, int ReaderType, int SectorNo, string HotelPwd,
            int CardNo, int GuestSN, int GuestIdx, StringBuilder DoorID, StringBuilder SuitDoor,
            StringBuilder PubDoor, StringBuilder BeginTime, StringBuilder EndTime);

        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Write_Guest_Lift(int Port, int ReaderType, int SectorNo, string HotelPwd,
            int CardNo, int BeginAddr, int EndAddr, int MaxAddr, StringBuilder BeginTime, StringBuilder EndTime,
            StringBuilder LiftData);

        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Guest_Card(int Port, int ReaderType, int SectorNo, string HotelPwd,
            ref int CardNo, ref int GuestSN, ref int GuestIdx, StringBuilder DoorID, StringBuilder SuitDoor,
            StringBuilder PubDoor, StringBuilder BeginTime, StringBuilder EndTime);


        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Guest_Lift(int Port, int ReaderType, int SectorNo, string HotelPwd,
            int BeginAddr, int EndAddr, ref int CardNo, StringBuilder BeginTime, StringBuilder EndTime,
            StringBuilder LiftData);

        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Write_Guest_PowerSwitch(int Port, int ReaderType, int SectorNo, string PowerSwitchPwd,
            int CardNo, int GuestSex, StringBuilder DoorID, StringBuilder GuestName, StringBuilder BeginTime,
            StringBuilder EndTime, int PowerSwitchType);

        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Read_Guest_PowerSwitch(int Port, int ReaderType, int SectorNo, string PowerSwitchPwd,
            ref int CardNo, ref int GuestSex, StringBuilder DoorID, StringBuilder GuestName,
            StringBuilder BeginTime, StringBuilder EndTime, int PowerSwitchType);

        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Reader_Alarm(int Port, int ReaderType, int AlarmCount);

        [DllImport("btLock57L.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SerialNo_FromNow();
    }
}
