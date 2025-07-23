Imports Tools.modMensajes

Public Class AdministradorOT_ComplementosForm
    Dim CadenaOtsForm As String
    Public Property _CadenaOts As String
        Get
            Return CadenaOtsForm
        End Get
        Set(value As String)
            CadenaOtsForm = value
        End Set
    End Property
    Private Sub AdministradorOT_ComplementosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_OrdenTrabajo.Text = _CadenaOts
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Metodo actualizar
        Dim ObjBU As New Negocios.OrdenTrabajoBU
        Dim FormatearCadenaOts As String = String.Empty
        Cursor = Cursors.WaitCursor
        Try
            If txt_OrdenCompra.Text.Length > 0 And txt_PagoAdicional.Text.Length > 0 Then

                ObjBU.ActualizarOts_CambiarOrdenCompra_CargoAdicional(_CadenaOts, txt_OrdenCompra.Text, txt_PagoAdicional.Text)

                'Al terminar de actualizar los datos según las OT´s seleccionadas
                txt_OrdenCompra.Clear()
                txt_PagoAdicional.Text = String.Empty
                txt_OrdenTrabajo.Clear()
                Me.Close()
            Else
                Dim MensajeAdvertencia As New AdvertenciaForm
                MensajeAdvertencia.mensaje = "Debe agregar la Orden de compra y el cargo adicional."
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "" + ex.Message)
        End Try
        Cursor = Cursors.Default

    End Sub
End Class