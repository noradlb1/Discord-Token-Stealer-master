Imports System
Imports System.Collections.Specialized
Imports System.Net

Public Class DcWebHook
	Implements IDisposable

		Private ReadOnly dWebClient As WebClient
		Private Shared discordValues As New NameValueCollection()
		Public Property WebHook() As String
		Public Property UserName() As String
		Public Property ProfilePicture() As String

		Public Sub New()
			dWebClient = New WebClient()
		End Sub


		Public Sub SendMessage(ByVal msgSend As String)
			discordValues.Add("username", UserName)
			discordValues.Add("avatar_url", ProfilePicture)
			discordValues.Add("content", msgSend)

			dWebClient.UploadValues(WebHook, discordValues)
		End Sub

		Public Sub Dispose() Implements IDisposable.Dispose
			dWebClient.Dispose()
		End Sub
End Class