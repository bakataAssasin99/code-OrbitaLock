Attribute VB_Name = "Module1"

'函数申明
'读DLL版本号
Declare Function GetDLLVersion Lib "proRFL.Dll" (ByVal sDllVer As String) As Integer
'初始化USB端口
Declare Function initializeUSB Lib "proRFL.Dll" (ByVal fUSB As Byte) As Integer
'发卡器叫一声
Declare Function Buzzer Lib "proRFL.Dll" (ByVal fUSB As Byte, ByVal t As Integer) As Integer
'读卡
Declare Function ReadCard Lib "proRFL.Dll" (ByVal fUSB As Byte, ByVal Buffer As String) As Integer
'客人卡
Declare Function GuestCard Lib "proRFL.Dll" (ByVal fUSB As Byte, ByVal dlsCoID As Long, ByVal CardNo As Integer, ByVal dai As Integer, ByVal llock As Integer, ByVal pdoors As Integer, ByVal BTime As String, ByVal ETime As String, ByVal LockNo As String, ByVal CardHexStr As String) As Integer
'注销卡片
Declare Function CardErase Lib "proRFL.Dll" (ByVal fUSB As Byte, ByVal dlsCoID As Long, ByVal CardHexStr As String) As Integer
'挂失卡片
Declare Function LimitCard Lib "proRFL.Dll" (ByVal fUSB As Byte, ByVal dlsCoID As Long, ByVal CardNo As Integer, ByVal dai As Integer, ByVal BTime As String, ByVal LCardNo As String, ByVal CardHexStr As String) As Integer
'HEX-ASC
Declare Function hex_a Lib "proRFL.Dll" (ByVal hex As String, ByVal a As String, ByVal length As Integer) As Integer
'ASC-HEX
Declare Function a_hex Lib "proRFL.Dll" (ByVal a As String, ByVal hex As String, ByVal length As Integer) As Integer
'读取卡片类型
Declare Function GetCardTypeByCardDataStr Lib "proRFL.Dll" (ByVal CardDataStr As String, ByVal CardType As String) As Integer
'读取客人卡锁号
Declare Function GetGuestLockNoByCardDataStr Lib "proRFL.Dll" (ByVal dlsCoID As Long, ByVal CardDataStr As String, ByVal LockNo As String) As Integer
'读取客人离店时间
Declare Function GetGuestETimeByCardDataStr Lib "proRFL.Dll" (ByVal dlsCoID As Long, ByVal CardDataStr As String, ByVal ETime As String) As Integer


'全局变量
Global st As Integer                     '函数返回状态值
Global flagUSB As Byte                   '发卡器标志---0表示有驱,1表示pro免驱
Global bufCard As String * 128           '卡片数据
Global bufHexStr As String * 128         '十六进制字符串


'读卡,有错误提示
'同时返回当前卡的ID(包含卡类型,卡号,发卡时间)---mid(bufCard,25,8)
Function rdCard() As Boolean
  rdCard = False
  bufCard = ""     '清空卡数据缓存
  st = ReadCard(flagUSB, bufCard)
  If st <> 0 Then
    MsgBox "读卡失败, 错误代号为: " & CStr(st), 16
    Exit Function
  End If
  If Left(bufCard, 6) <> "551501" Then
    MsgBox "发卡器的感应区无卡" & Chr(10) & bufCard, 48
    Exit Function
  End If
  rdCard = True
End Function
