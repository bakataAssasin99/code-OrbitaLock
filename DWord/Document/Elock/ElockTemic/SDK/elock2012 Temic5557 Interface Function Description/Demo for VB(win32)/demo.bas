Attribute VB_Name = "Module1"
Declare Function WriteCard Lib "cyrf32.dll" (ByVal HotelID As String, ByVal cardtype As String, ByVal cardid As String, ByVal changkai As String, ByVal roomcode As String, ByVal begindate As String, ByVal enddate As String) As Integer    'Ð´¿¨
Declare Function ReadCard Lib "cyrf32.dll" (ByVal HotelID As String, ByVal cardtype As String, ByVal cardid As String, ByVal changkai As String, ByVal roomcode As String, ByVal begindate As String, ByVal enddate As String) As Integer     '¶Á¿¨

