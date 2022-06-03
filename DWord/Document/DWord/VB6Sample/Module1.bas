Attribute VB_Name = "Module1"
Declare Function StartSession Lib "LockDll.dll" (ByVal LockCard As Long, ByVal DBServer As String, ByVal LogUser As String, ByVal DBFlag As Long) As Long

Declare Function EndSession Lib "LockDll.dll" () As Long

Declare Function ChangeLogUser Lib "LockDll" (ByVal LogUser As String) As Long

Declare Function NewKey Lib "LockDll.dll" (ByVal Port As Long, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal Breakfast As Long, ByVal OverFlag As Long, ByRef CardNo As Long) As Long

Declare Function AddKey Lib "LockDll.dll" (ByVal Port As Long, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal Breakfast As Long, ByVal OverFlag As Long, ByRef CardNo As Long) As Long

Declare Function DupKey Lib "LockDll.dll" (ByVal Port As Long, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal Breakfast As Long, ByVal OverFlag As Long, ByRef CardNo As Long) As Long

Declare Function ReadKeyCard Lib "LockDll.dll" (ByVal Port As Long, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByRef CardNo As Long, ByRef CardStatus As Long, ByRef Breakfast As Long) As Long

Declare Function EraseKeyCard Lib "LockDll.dll" (ByVal Port As Long, ByVal CardNo As Long) As Long

Declare Function CheckOut Lib "LockDll.dll" (ByVal RoomNo As String, ByVal CardNo As Long) As Long


