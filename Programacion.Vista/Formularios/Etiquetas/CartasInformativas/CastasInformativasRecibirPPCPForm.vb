Imports Programacion.Negocios
Imports Tools

Public Class CastasInformativasRecibirPPCPForm
    Public pedidos As String = String.Empty
    Public Operacion As String = String.Empty
    Private Sub CastasInformativasRecibirPPCPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPedidos.Text = pedidos
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnRecibir_Click(sender As Object, e As EventArgs) Handles btnRecibir.Click
        Dim obj As New CartasInformativasBU
        obj.ActualizaEstatus(Operacion, pedidos, dtpFechaRecepcion.Value)
        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha recibido las etiquetas de los pedidos seleccionados.")
        Me.Close()
    End Sub
End Class