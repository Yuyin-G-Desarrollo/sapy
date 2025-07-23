Public Class DescargarEMailsBU

    Public _server As String = ""
    Public _user As String = ""
    Public _password As String = ""
    Public _port As Integer = 955


    'Function getRutasXMLleerCorreoNoVistosPop3(ByVal rutaComprobantes As String) As List(Of String)
    '    Dim listatmp As New List(Of String)
    '    Dim lista As New List(Of String)
    '    Try
    '        Using pop As New Pop3
    '            pop.ConnectSSL(_server) ' Use overloads or ConnectSSL if you need to specify different port or SSL.
    '            pop.Login(_user, _password) ' You can also use: LoginPLAIN, LoginCRAM, LoginDIGEST, LoginOAUTH methods,
    '            'or use UseBestLogin method if you want Mail.dll to choose for you.
    '            'Imap.SelectInbox() ' You can select other folders, e.g. Sent folder: imap.Select("Sent")
    '            'Dim uids As List(Of Long) = Imap.Search(Flag.Unseen) 'Find all unseen messages.
    '            For Each uid As String In pop.GetAll
    '                Dim email As IMail = New MailBuilder() _
    '                    .CreateFromEml(pop.GetMessageByUID(uid)) ' Download and parse each message.
    '                listatmp = ProcessMessage(email, rutaComprobantes) ' Display email data, save attachments:
    '                pop.DeleteMessageByUID(uid)
    '                For Each ruta As String In listatmp
    '                    If ruta.Contains(".XML") Or ruta.Contains(".xml") Then
    '                        lista.Add(ruta)
    '                    End If
    '                Next
    '            Next
    '            pop.Close()
    '        End Using
    '    Catch ex As Exception
    '    End Try
    '    Return lista
    'End Function
    'Function getRutasXMLleerCorreoNoVistosImap() As List(Of String)
    '    Dim listatmp As New List(Of String)
    '    Dim lista As New List(Of String)
    '    Try
    '        Using imap As New Imap
    '            imap.ConnectSSL(_server) 'Use overloads or ConnectSSL if you need to specify different port or SSL.
    '            imap.Login(_user, _password) ' You can also use: LoginPLAIN, LoginCRAM, LoginDIGEST, LoginOAUTH methods,
    '            'or use UseBestLogin method if you want Mail.dll to choose for you.
    '            imap.SelectInbox() ' You can select other folders, e.g. Sent folder: imap.Select("Sent")
    '            Dim uids As List(Of Long) = imap.Search(Flag.Unseen) 'Find all unseen messages.
    '            For Each uid As Long In uids
    '                Dim email As IMail = New MailBuilder() _
    '                .CreateFromEml(imap.GetMessageByUID(uid)) 'Download and parse each message.
    '                listatmp = ProcessMessage(email, "") 'Display email data, save attachments:
    '                imap.DeleteMessageByUID(uid)
    '                For Each ruta As String In listatmp
    '                    If ruta.Contains(".XML") Or ruta.Contains(".xml") Then
    '                        lista.Add(ruta)
    '                    End If
    '                Next
    '            Next
    '            imap.Close()
    '        End Using
    '    Catch ex As Exception
    '    End Try
    '    Return lista
    'End Function
    'Function ProcessMessage(ByVal email As IMail, ByVal rutaComprobantes As String) As List(Of String)
    '    Dim lista As New List(Of String)
    '    For Each attachment As MimeData In email.Attachments
    '        If attachment.SafeFileName.ToUpper.Contains(".XML") Or attachment.SafeFileName.ToUpper.Contains(".PDF") Then
    '            Console.WriteLine(attachment.FileName)
    '            'rutaComprobantes="C:\Emails\Nuevos\"
    '            Try
    '                lista.Add(rutaComprobantes & attachment.SafeFileName)
    '                attachment.Save(rutaComprobantes & attachment.SafeFileName)
    '            Catch ex As Exception
    '            End Try  
    '        End If
    '    Next
    '    Return lista
    'End Function
End Class
