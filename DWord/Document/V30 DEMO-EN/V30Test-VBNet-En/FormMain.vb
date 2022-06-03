Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FormMain
	Inherits System.Windows.Forms.Form
    Private Declare Function ReadCardSN Lib "HNAccessG.dll" (ByVal Com As Integer, ByVal CardSN As String) As Integer

    Private Declare Function ReadMessage Lib "HNAccessG.dll" (ByVal Com As Integer, ByVal nBlock As Integer, ByVal Encrypt As Integer, ByRef CardNumber As Integer, ByRef CardType As Integer, ByRef PassLevel As Integer, ByVal CardPass As String, ByVal SystemCode As String, ByVal Address As String, ByVal SDateTime As String) As Short

    Private Declare Function KeyCard Lib "HNAccessG.dll" (ByVal Com As Integer, ByVal Cardno As Integer, ByVal nBlock As Integer, ByVal Encrypt As Integer, ByVal CardPass As String, ByVal SystemCode As String, ByVal HotelCode As String, ByVal RoomPass As String, ByVal Address As String, ByVal SDIn As String, ByVal STIn As String, ByVal SDOut As String, ByVal STOut As String, ByVal Level_Pass As Integer, ByVal PassMode As Integer, ByVal AddressMode As Integer, ByVal AddressQty As Integer, ByVal TimeMode As Integer, ByVal V8 As Integer, ByVal V16 As Integer, ByVal V24 As Integer, ByVal AlwaysOpen As Integer, ByVal OpenBolt As Integer, ByVal TerminateOld As Integer, ByVal ValidTimes As Integer) As Integer



    Public Function DEC_to_HEX(ByRef Dec As Integer) As String
		Dim a As String
		DEC_to_HEX = ""
		Do While Dec > 0
			a = CStr(Dec Mod 16)
			Select Case a
				Case "10" : a = "A"
				Case "11" : a = "B"
				Case "12" : a = "C"
				Case "13" : a = "D"
				Case "14" : a = "E"
				Case "15" : a = "F"
			End Select
			DEC_to_HEX = a & DEC_to_HEX
			Dec = Dec \ 16
		Loop 
	End Function
	
	Private Sub Com_GuestCard_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Com_GuestCard.Click

        Dim Ret As Integer
		Dim Com As Integer
		Dim Cardno As Integer
		Dim nBlock As Integer
		Dim Encrypt As Integer
		
		Dim CardPass As String
		Dim SystemCode As String
		Dim HotelCode As String
		Dim RoomPass As String ' Pass
		Dim Address As String
		Dim SDIn As String
		Dim STIn As String
        Dim SDOut As String
        Dim STOut As String

        Dim Level_Pass As Integer
		Dim PassMode As Integer
		Dim AddressMode As Integer
		Dim AddressQty As Integer
		Dim TimeMode As Integer
		Dim V8 As Integer
		Dim V16 As Integer
		Dim V24 As Integer
		Dim AlwaysOpen As Integer
        Dim OpenBolt As Integer
        Dim AlwaywsOpen As Integer
        Dim TerminateOld As Integer
		Dim ValidTimes As Integer
		
		Dim iYear As Integer
		Dim iMonth As Integer
		Dim iDay As Integer
		Dim iHour As Integer
		Dim iMinute As Integer
		Dim iTemp As Integer
		
		
		Com = Val(T_Com.Text)
		Cardno = Val(T_CardNo.Text)
		nBlock = Val(T_nBlock.Text)
		Encrypt = Val(T_Encrypt.Text)
		
		CardPass = T_CardPass.Text
		SystemCode = T_SystemCode.Text
		HotelCode = T_HotelCode.Text
		
		Address = T_Address.Text
		SDIn = T_SDIN.Text
		STIn = T_STIN.Text
        SDOut = T_SDOUT.Text
        STOut = T_STOUT.Text
		
		Level_Pass = Val(T_LevelPass.Text)
        PassMode = Val(T_PassMode.Text)
        AddressMode = Val(T_AddressMode.Text)
		AddressQty = Val(T_AddressQty.Text)
		TimeMode = Val(T_TimeMode.Text)
		V8 = Val(T_V8.Text)
		V16 = Val(T_V16.Text)
		V24 = Val(T_V24.Text)
        AlwaysOpen = Val(T_AlwaysOpen.Text)
        OpenBolt = Val(T_OpenBolt.Text)
		TerminateOld = Check_TerminateOld.CheckState
		ValidTimes = Val(T_ValidTimes.Text)
		
		
		
		PassMode = 1
		If TerminateOld > 0 Then PassMode = 2

        If TerminateOld > 0 Then
            iYear = Year(Now)
            iMonth = Month(Now)
            iDay = VB.Day(Now)
            iHour = Hour(Now)
            iMinute = Minute(Now)
            iTemp = (iMinute \ 4) + iHour * 2 ^ 4 + iDay * (2 ^ 9) + iMonth * (2 ^ 14) + (((iYear - 8) Mod 1000) Mod 63) * (2 ^ 18)
            RoomPass = DEC_to_HEX(iTemp)

            T_Pass.Text = RoomPass

        Else
            RoomPass = Trim(T_Pass.Text)
		End If

        ' KeyCard(int Com,int CardNo,int nBlock,int Encrypt,char* CardPass,char* SystemCode,
        '    char* HotelCode, char* Pass, char* Address, char* SDIn,char* STIn, char* SDOut,char* STOut,
        '    int LEVEL_Pass,int PassMode,int AddressMode,int AddressQty,int TimeMode,
        '    int V8, int V16, int V24, int AlwaysOpen, int OpenBolt,int TerminateOld,
        '    int ValidTimes);


        Ret = KeyCard(Com, Cardno, nBlock, Encrypt, CardPass, SystemCode, HotelCode, RoomPass, Address, SDIn, STIn, SDOut, STOut, Level_Pass, PassMode, AddressMode, AddressQty, TimeMode, V8, V16, V24, AlwaywsOpen, OpenBolt, TerminateOld, ValidTimes)
		
		
		If Ret = 0 Then
			MsgBox("Issue card successfully!")
		Else
			MsgBox("Issue card failed! Code:" & Ret)
		End If
		
		
		
	End Sub



    Private Sub Com_ReadCardSN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Ret As Integer
        Dim Com As Integer
        Dim CardSN As String
        CardSN = "123456789012345678901234567890"
        Com = Val(T_Com.Text)
        Ret = ReadCardSN(Com, CardSN)
        If Ret = 0 Then
            MsgBox("Read CardSN successfully! ReadCardSN:" & CardSN)
        Else
            MsgBox("Read CardSN failed! Code:" & Ret)
        End If
    End Sub

    Private Sub Com_ReadMessage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Com_ReadMessage.Click
		
		Dim Ret As Integer
		Dim Com As Integer
		Dim nBlock As Integer
		Dim Encrypt As Integer
		Dim DBCardno As Integer
		Dim DBCardType As Integer
		Dim DBPassLevel As Integer
		
		Dim CardPass As String
		Dim DBSystemCode As String
		Dim DBAddress As String
		Dim SDateTime As String
		
		
		
		Com = Val(T_Com.Text)
		nBlock = Val(T_nBlock.Text)
		Encrypt = Val(T_Encrypt.Text)
		
		
		CardPass = T_CardPass.Text
		DBSystemCode = T_SystemCode.Text
		DBAddress = "123456789012345678901234567890"
		SDateTime = "123456789012345678901234567890"
		
		
		Ret = ReadMessage(Com, nBlock, Encrypt, DBCardno, DBCardType, DBPassLevel, CardPass, DBSystemCode, DBAddress, SDateTime)
		
		If Ret = 0 Then
			MsgBox("Read card successfully! CardNo:" & DBCardno)
		Else
			MsgBox("Read card failed! Code:" & Ret)
		End If
		
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Me.Close()
	End Sub
End Class