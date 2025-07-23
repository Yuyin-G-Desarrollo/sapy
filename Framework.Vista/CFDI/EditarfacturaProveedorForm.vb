Imports Contabilidad.Vista
Imports Framework.Negocios

Public Class EditarfacturaProveedorForm
    Public ProveedorNombre As String = ""
    Public Folio As String = ""
    Public NaveID As Integer = 0
    Public FolioAnterior As String = ""
    Public ProveedorAnteriorID As Integer = 0
    Public NaveAnteriorID As Integer = 0
    Public Serie As String = ""

    Private Sub EditarfacturaProveedorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboNaves()
        txtFolioFactura.Text = Folio.ToString
        txtProveedorAnterior.Text = ProveedorNombre.ToString
        cmbNave.SelectedValue = NaveID
        txtProveedorAnterior.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New CFDIBU
        Dim dtCambioFactura As New DataTable
        Dim exito As New ExitoForm
        Dim advertencia As New AdvertenciaForm
        Dim confirmar As New ConfirmarForm

        Dim FolioNuevo As String = ""
        Dim FolioAnteriorP As String = ""
        Dim NaveID As Integer = 0
        Dim NaveAnteriorIDP As Integer = 0
        Dim ProveedorAnteriorIDP As Integer = 0
        Dim SerieP As String = ""

        FolioNuevo = txtFolioFactura.Text
        FolioAnteriorP = FolioAnterior
        NaveID = CInt(cmbNave.SelectedValue)
        ProveedorAnteriorIDP = ProveedorAnteriorID
        NaveAnteriorIDP = NaveAnteriorID
        SerieP = Serie

        confirmar.mensaje = "¿Está seguro de actualizar los datos?"
        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            dtCambioFactura = objBU.actualizarDatosFactura(NaveID, FolioNuevo, FolioAnterior, NaveAnteriorID, ProveedorAnteriorID, SerieP)
            exito.mensaje = "Se realizaron los cambios con éxito."
            exito.ShowDialog()
        Else
            advertencia.mensaje = "Se canceló el cambio en la factura"
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
        Me.Close()

    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Public Sub llenarComboNaves()
        Dim objBU As New CFDIBU
        Dim dtComboNave As New DataTable
        dtComboNave = objBU.llenarComboNaveSICY()
        dtComboNave.Rows.InsertAt(dtComboNave.NewRow, 0)
        cmbNave.DataSource = dtComboNave
        cmbNave.DisplayMember = "Nave"
        cmbNave.ValueMember = "NaveIDSICY"
    End Sub

End Class