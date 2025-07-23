Public Class frmCaptcha
    Public mensaje As String
    Public Tamaño_Letra As Int16 = 0
    Public facturacion As Integer = 0 ' 0 = no, 1 = si
    Private Sub frmCaptcha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMensaje.Text = mensaje
        If facturacion = 1 Then
            lblMensajePrincipal.Visible = False
            lblMensajeFacturacion.Visible = True
        Else
            lblMensajePrincipal.Visible = True
            lblMensajeFacturacion.Visible = False
        End If
        generarRadom()
    End Sub

    Public Sub generarRadom()
        Dim randonNumerico As New Random()

        Dim caracteres As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim textoCaptcha As String = ""
        For i As Int32 = 0 To 4
            textoCaptcha = textoCaptcha + caracteres.Substring(randonNumerico.Next(0, 35), 1)
        Next
        lblCaptcha.Text = textoCaptcha

        If Tamaño_Letra > 0 Then
            lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", Tamaño_Letra)
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtCaptcha.Text.ToUpper <> lblCaptcha.Text Then
            MsgBox("EL TEXTO NO COINCIDE CON LA CADENA SOLICITADA.", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub txtCaptcha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCaptcha.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCaptcha.Text.ToUpper = lblCaptcha.Text Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MsgBox("EL TEXTO NO COINCIDE CON LA CADENA SOLICITADA.", MsgBoxStyle.Information, "")
            End If
        End If
    End Sub

    Private Sub txtCaptcha_TextChanged(sender As Object, e As EventArgs) Handles txtCaptcha.TextChanged
        If txtCaptcha.Text.ToUpper = lblCaptcha.Text Then
            btnOK.DialogResult = Windows.Forms.DialogResult.OK
        Else
            btnOK.DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub
End Class