using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DWord
{
    class LockSDK
    {
        private Int32 _handle;
        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint StartSession(int Software, string DBServer, string LogUser, int DBFlag);

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint EndSession();

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint ChangeLogUser(string LogUser);

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint NewKey(int Port, string RoomNo, string CommonDoor, string LiftFloor, string TimeStr, string Holder,
        string IDNo, int Breakfast, int overflag, ref int CardNo);

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint AddKey(int Port, string RoomNo, string CommonDoor, string LiftFloor, string TimeStr, string Holder,
            string IDNo, int Breakfast, int overflag, ref int CardNo);

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint DupKey(int Port, string RoomNo, string CommonDoor, string LiftFloor, string TimeStr, string Holder,
            string IDNo, int Breakfast, int overflag, ref int CardNo);

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint ReadKeyCard(int Port, StringBuilder RoomNo, StringBuilder CommonDoor, StringBuilder LiftFloor, StringBuilder TimeStr,
            StringBuilder Holder, StringBuilder IDNo, ref int CardNo, ref int CardStatus, ref int Breakfast);

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint EraseKeyCard(long Port, int CardNo);

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint CheckOut(string RoomNO, int CardNo);

        [DllImport("LockDll.dll", CharSet = CharSet.Ansi)]
        public static extern uint ReadCardID(int Port, int? CardNo);
         
    }
}
