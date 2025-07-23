Public Class DialogSeleccionarFormaDePagoForm
    Public idCaja As Int32
    Public caja As String
    Public formaPago As String
    Public idnave As Int32

    Private Sub DialogSeleccionarFormaDePagoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cmbCaja = Tools.Controles.ComboCajas(cmbCaja, idNave)
        'cmbCaja.SelectedIndex = 1
    End Sub

    Private Sub btnSolicitar_Click(sender As Object, e As EventArgs) Handles btnSolicitar.Click
        If cmbCaja.SelectedIndex > 0 Then
            idCaja = cmbCaja.SelectedValue
            caja = cmbCaja.Text
        Else
            idCaja = 0
            caja = ""
        End If

        If cmbFormaPago.SelectedIndex > 0 Then
            formaPago = cmbFormaPago.Text
        Else
            formaPago = ""
        End If

    End Sub
End Class