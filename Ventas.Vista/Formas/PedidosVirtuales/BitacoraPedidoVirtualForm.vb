Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class BitacoraPedidoVirtualForm

    Dim objDA As New Negocios.PedidosVirtualesBU
    Public EncabezadoPedido As PedidoVirtualForm

    Private Sub BitacoraPedidoVirtualForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        inicializarFormulario()
    End Sub

    Private Sub inicializarFormulario()
        Me.Size = New Size(720, 557)
        txtCliente.Enabled = False
        txtIdPedido.Enabled = False
        txtEstatus.Enabled = False
        txtTipoPedido.Enabled = False
        grdBitacora.DataSource = objDA.obtenerBitacora(CInt(txtIdPedido.Text))
        pintarGrid()
    End Sub

    Private Sub pintarGrid()
        grdBitacora.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        With grdBitacora.DisplayLayout.Bands(0)
            .Columns("Estatus de").CellActivation = Activation.NoEdit
            .Columns("Estatus a").CellActivation = Activation.NoEdit
            .Columns("Fecha Modificación").CellActivation = Activation.NoEdit
            .Columns("Usuario").CellActivation = Activation.NoEdit
            .Columns("Observaciones").CellActivation = Activation.NoEdit

            .Columns("Estatus de").Header.Caption = "Status de"
            .Columns("Estatus a").Header.Caption = "Status A"
            .Columns("Fecha Modificación").Header.Caption = "FMovimiento"

            .Columns("Fecha Modificación").Format = "dd/MM/yyyy hh:mm:ss tt"

            .Columns("Fecha Modificación").Width = 150
            .Columns("Observaciones").Width = 450
        End With
    End Sub

    Private Sub exportarExcel()
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        With fbdUbicacionArchivo
            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True
            Dim ret As DialogResult = .ShowDialog
            If ret = Windows.Forms.DialogResult.OK Then
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(Me.grdBitacora, .SelectedPath + "\Bitacora_PV_" + txtIdPedido.Text + "_" + fecha_hora + ".xlsx")
                Dim mensajeExito As New ExitoForm
                mensajeExito.mensaje = "Los datos se exportaron correctamente"
                mensajeExito.ShowDialog()
                .Dispose()
            End If
        End With
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        EncabezadoPedido.Enabled = True
        EncabezadoPedido.WindowState = FormWindowState.Maximized
    End Sub
End Class