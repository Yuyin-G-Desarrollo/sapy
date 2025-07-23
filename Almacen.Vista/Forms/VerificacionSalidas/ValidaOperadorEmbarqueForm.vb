Imports System.ComponentModel
Imports Tools

Public Class ValidaOperadorEmbarqueForm

    Dim ObjBU As New Negocios.VerificacionSalidasBU
    Dim ColaboradorId As Integer = 0


    Private Function ValidaUsuario(ByVal CodigoLeido As String) As Boolean
        Dim Lectura As String = String.Empty
        Dim Resultado As Boolean = False

        Try
            Lectura = CodigoLeido
            Lectura = Lectura.Replace("EM", "")
            If IsNumeric(Lectura) = True Then
                ColaboradorId = ObjBU.ValidaUsuario(Lectura)
                If ColaboradorId > 0 Then
                    Resultado = True
                    Dim form As New LecturaParesSalidaForm
                    form.MdiParent = Me.MdiParent
                    form.ColaboradorId = ColaboradorId
                    form.Show()
                    Me.Close()
                Else
                    Resultado = False
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El colaborador no existe.")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El colaborador no existe.")
                Resultado = False
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

        Return Resultado
    End Function

    Private Sub ValidaOperadorEmbarqueForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Me.DialogResult <> DialogResult.OK Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            ValidaUsuario(txtUsuario.Text)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ValidaUsuario(txtUsuario.Text)
    End Sub

    Private Sub ValidaOperadorEmbarqueForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtUsuario.Select()
    End Sub
End Class