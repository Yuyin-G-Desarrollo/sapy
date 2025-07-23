Imports Tools

Public Class frmSeleccionarFechaEntrega
    Public fechaEntrega As String
    Public colaborador As String
    Public fechaSoliditud As Date

    Public Function validarFechas() As Boolean
        If dttFechaEntrega.Value.Date < fechaSoliditud.ToShortDateString Then
            Return False
        End If
        Return True
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuarda_Click(sender As Object, e As EventArgs) Handles btnGuarda.Click
        If validarFechas() = True Then
            fechaEntrega = dttFechaEntrega.Value.ToShortDateString
            Me.Close()
        Else
            Dim objMAD As New AdvertenciaForm
            objMAD.mensaje = "La fecha de entrega no puede ser menor a la fecha de solicitud del finiquito (" + fechaSoliditud.ToShortDateString + ")"
            objMAD.ShowDialog()
        End If
    End Sub

    Private Sub frmSeleccionarFechaEntrega_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If fechaEntrega = "" Then
            Dim objConf As New Tools.ConfirmarForm
            objConf.mensaje = "Si no selecciona una fecha, no se actualizara el registro del finiquito. ¿Desea continuar?"
            If objConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                fechaEntrega = ""
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmSeleccionarFechaEntrega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNombreColaborador.Text = colaborador
    End Sub
End Class