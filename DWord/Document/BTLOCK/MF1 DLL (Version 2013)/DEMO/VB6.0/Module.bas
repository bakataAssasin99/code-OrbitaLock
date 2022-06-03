Attribute VB_Name = "Module1"
Declare Function Write_Guest_Card Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal SectorNo As Byte, ByVal HotelPwd As String, ByVal CardNo As Long, ByVal GuestSN As Long, ByVal GuestIdx As Integer, ByVal DoorID As String, ByVal SuitDoor As String, ByVal PubDoor As String, ByVal BeginTime As String, ByVal EndTime As String) As Integer
Declare Function Read_Guest_Card Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal SectorNo As Byte, ByVal HotelPwd As String, CardNo As Long, GuestSN As Long, GuestIdx As Integer, ByVal DoorID As String, ByVal SuitDoor As String, ByVal PubDoor As String, ByVal BeginTime As String, ByVal EndTime As String) As Integer
Declare Function Reader_Alarm Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal AlarmCount As Byte) As Integer
Declare Function Write_Guest_Lift Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal SectorNo As Byte, ByVal HotelPwd As String, ByVal CardNo As Long, ByVal BeginAddr As Long, ByVal EndAddr As Integer, ByVal MaxLiftAddr As Integer, ByVal BeginTime As String, ByVal EndTime As String, ByVal LiftData As String) As Integer
Declare Function Read_Guest_Lift Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal SectorNo As Byte, ByVal HotelPwd As String, ByVal BeginAddr As Long, ByVal EndAddr As Integer, CardNo As Long, ByVal BeginTime As String, ByVal EndTime As String, ByVal LiftData As String) As Integer

Declare Function Write_Guest_PowerSwitch Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal SectorNo As Byte, ByVal PowerSwitchPwd As String, ByVal CardNo As Long, ByVal GuestSex As Byte, ByVal DoorID As String, ByVal GuestName As String, ByVal BeginTime As String, ByVal EndTime As String, ByVal PowerSwitchType As Byte) As Integer
Declare Function Read_Guest_PowerSwitch Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal SectorNo As Byte, ByVal PowerSwitchPwd As String, CardNo As Long, GuestSex As Byte, ByVal DoorID As String, ByVal GuestName As String, ByVal BeginTime As String, ByVal EndTime As String, ByVal PowerSwitchType As Byte) As Integer

Declare Function Write_Data Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal SectorNo As Byte, ByVal SectorPwd As String, ByVal Data As String) As Integer
Declare Function Read_Data Lib "btlock57L.dll" (ByVal Port As Byte, ByVal ReaderType As Byte, ByVal SectorNo As Byte, ByVal SectorPwd As String, ByVal Data As String) As Integer

