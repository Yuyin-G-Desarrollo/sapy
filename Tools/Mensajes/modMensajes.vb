Public Module modMensajes
    Public Enum Mensajes
        Warning = 1
        Notice = 2
        Confirm = 3
        Fault = 4
        Success = 5
    End Enum

    Public Sub MostrarEspere(ByVal form As Form)
        form.Cursor = Cursors.WaitCursor
    End Sub

    Public Sub TerminarEspere(ByVal form As Form)
        form.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' Envie el mensaje que aparecerá
    ''' </summary>
    ''' <param name="tipo">Tipo de mensaje</param>
    ''' <param name="mensaje">Cadena con el mensaje</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarMensaje(ByVal tipo As Mensajes, ByVal mensaje As String)
        Dim msjForm As Object

        Select Case tipo
            Case Mensajes.Warning
                msjForm = New AdvertenciaForm
                msjForm.mensaje = mensaje
                msjForm.ShowDialog()
            Case Mensajes.Notice
                msjForm = New AvisoForm
                msjForm.mensaje = mensaje
                msjForm.ShowDialog()
            Case Mensajes.Confirm
                msjForm = New ConfirmarForm
                msjForm.mensaje = mensaje
                msjForm.ShowDialog()
            Case Mensajes.Fault
                msjForm = New ErroresForm
                msjForm.mensaje = mensaje
                msjForm.ShowDialog()
            Case Mensajes.Success
                msjForm = New ExitoForm
                msjForm.mensaje = mensaje
                msjForm.ShowDialog()
        End Select
    End Function
End Module
