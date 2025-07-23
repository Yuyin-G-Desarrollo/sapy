Public Class FiltroImpresoraForm
    Dim objBU As New Negocios.AdministradorDocumentosBU
    Public listaParametroID As Integer
    Private Sub FiltroImpresoraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        CargarImpresoras()
    End Sub
    Private Sub CargarImpresoras()
        Dim DTImpresoras = objBU.ListaImpresoras()
        cmbImpresoras.DataSource = DTImpresoras
        cmbImpresoras.DisplayMember = "Nombre"
        cmbImpresoras.ValueMember = "IdImpresora"
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        listaParametroID = cmbImpresoras.SelectedValue
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub
End Class