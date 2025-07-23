Imports Contabilidad.Vista
Imports Framework.Negocios

Public Class ActualizaProveedorCFDIForm
    Public Folio As String = ""
    Public ProveedorNombre As String = ""
    Public ProveedorAnteriorID As Integer = 0
    Public NaveID As Integer = 0
    Public Serie As String = ""


    Private Sub ActualizaProveedorCFDIForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFolioNave.Enabled = False
        txtFolioNave.Text = Folio.ToString
        txtProveedorAnteriorNave.Text = ProveedorNombre.ToString
        llenarComboProveedorNuevo()
    End Sub

    Public Sub llenarComboProveedorNuevo()
        Dim objBU As New CFDIBU
        Dim dtComboProveedor As New DataTable
        dtComboProveedor = objBU.llenarComboProveedorNuevo()
        dtComboProveedor.Rows.InsertAt(dtComboProveedor.NewRow, 0)
        cmbProveedorNuevoNave.DataSource = dtComboProveedor
        cmbProveedorNuevoNave.DisplayMember = "RazonSocial"
        cmbProveedorNuevoNave.ValueMember = "ProveedorID"
    End Sub

    Private Sub btnGuardarProveedorNave_Click(sender As Object, e As EventArgs) Handles btnGuardarProveedorNave.Click
        Dim objBU As New CFDIBU
        Dim dtCambioProveedor As New DataTable
        Dim exito As New ExitoForm
        Dim advertencia As New AdvertenciaForm
        Dim confirmar As New ConfirmarForm


        Dim Folio As String = ""
        Dim ProveedorID As Integer = 0
        Dim NaveIDP As Integer = 0
        Dim ProveedorAnteriorIDP As Integer = 0
        Dim SerieP As String = ""


        Folio = txtFolioNave.Text
        ProveedorID = CInt(cmbProveedorNuevoNave.SelectedValue)
        ProveedorAnteriorIDP = ProveedorAnteriorID
        NaveIDP = NaveID
        SerieP = Serie

        confirmar.mensaje = "¿Está seguro de actualizar los datos?"
        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            dtCambioProveedor = objBU.actualizarProveedorFactura(Folio, ProveedorAnteriorID, ProveedorID, SerieP, NaveID)
            exito.mensaje = "Cambios guardados correctamente."
            exito.ShowDialog()
        Else
            advertencia.mensaje = "Se canceló el cambio de Proveedor"
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub
End Class