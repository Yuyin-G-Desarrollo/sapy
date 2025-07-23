Imports System.Security.Cryptography

Public Class UtileriaCadenas

	Public Function StringToMd5(StrPass As String) As String
		Dim PasConMd5 As String
		PasConMd5 = ""
		Dim md5 As New MD5CryptoServiceProvider
		Dim bytValue() As Byte
		Dim bytHash() As Byte
		Dim i As Integer

		bytValue = System.Text.Encoding.UTF8.GetBytes(StrPass)

		bytHash = md5.ComputeHash(bytValue)
		md5.Clear()

		For i = 0 To bytHash.Length - 1
			PasConMd5 &= bytHash(i).ToString("x").PadLeft(2, CChar("0"))
		Next

		'MsgBox(PasConMd5)

		Return PasConMd5
	End Function

End Class
