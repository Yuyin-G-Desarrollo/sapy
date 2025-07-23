Imports System.Drawing
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports Tools

Public Class CambioSemanaPagoForm
    Dim listaInicial As New List(Of String)
    Dim objadvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim confirmar As New Tools.ConfirmarForm

    Private Sub CambioSemanaPagoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdProveedor.DataSource = listaInicial
        lblTotalSeleccionados.Text = 0
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        Dim listado As New ListadoProveedorSemanaPago
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdProveedor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdProveedor.DataSource = listado.listaParametros
        With grdProveedor
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Proveedor"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub


    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next
        Return Resultado
    End Function

    Public Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBu As New CambioSemanaProveedorBU
        Dim FProveedor As String = String.Empty
        Dim dtConsultaDocumentosProveedor As New DataTable

        grdProveedoresDoctos.DataSource = Nothing
        MVProveedoresDoctos.Columns.Clear()

        FProveedor = ObtenerFiltrosGrid(grdProveedor)

        Try
            Cursor = Cursors.WaitCursor
            dtConsultaDocumentosProveedor = objBu.ObtenerDocumentosProveedor(FProveedor)

            If dtConsultaDocumentosProveedor.Rows.Count > 0 Then
                grdProveedoresDoctos.DataSource = dtConsultaDocumentosProveedor
                lblTotalSeleccionados.Text = "0"
                MVProveedoresDoctos.OptionsSelection.MultiSelect = True
                lblTotalSeleccionados.Text = CDbl(MVProveedoresDoctos.RowCount.ToString()).ToString("n0")
                disenoGrid()
                lblFechaUltimaActualización.Text = Date.Now
            Else
                objadvertencia.mensaje = "No hay documentos pendientes de pago"
                objadvertencia.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub disenoGrid()
        MVProveedoresDoctos.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVProveedoresDoctos.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVProveedoresDoctos.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVProveedoresDoctos.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVProveedoresDoctos.Columns.Item("#").VisibleIndex = 0
        End If


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVProveedoresDoctos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

        MVProveedoresDoctos.Columns.ColumnByFieldName("Docto").Caption = "Docto"
        MVProveedoresDoctos.Columns.ColumnByFieldName("Factura").Caption = "Factura"
        MVProveedoresDoctos.Columns.ColumnByFieldName("FDocto").Caption = "F.Docto"
        MVProveedoresDoctos.Columns.ColumnByFieldName("FVento").Caption = "F.Vencimiento"
        MVProveedoresDoctos.Columns.ColumnByFieldName("SemanaCompra").Caption = "SemCompra"
        MVProveedoresDoctos.Columns.ColumnByFieldName("SemanaPago").Caption = "SemPago"
        MVProveedoresDoctos.Columns.ColumnByFieldName("Cargo").Caption = "Importe"
        MVProveedoresDoctos.Columns.ColumnByFieldName("Saldo").Caption = "Saldo"
        MVProveedoresDoctos.Columns.ColumnByFieldName("Concepto").Caption = "Concepto"
        MVProveedoresDoctos.Columns.ColumnByFieldName("ModificadoSemana").Caption = "Modificado"

        MVProveedoresDoctos.Columns.ColumnByFieldName("ProveedorID").Visible = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("AnioActual").Visible = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("SemanaActual").Visible = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("SemanaCompraActual").Visible = False
        'MVProveedoresDoctos.Columns.ColumnByFieldName("ModificadoSemana").Visible = False


        MVProveedoresDoctos.Columns.ColumnByFieldName("Docto").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("Factura").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("FDocto").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("FVento").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("SemanaCompra").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("SemanaPago").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("Cargo").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("Saldo").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("Concepto").OptionsColumn.AllowEdit = False
        MVProveedoresDoctos.Columns.ColumnByFieldName("ModificadoSemana").OptionsColumn.AllowEdit = False

        MVProveedoresDoctos.Columns.ColumnByFieldName("#").Width = 20
        MVProveedoresDoctos.Columns.ColumnByFieldName("Seleccionar").Width = 70
        MVProveedoresDoctos.Columns.ColumnByFieldName("Docto").Width = 100
        MVProveedoresDoctos.Columns.ColumnByFieldName("Factura").Width = 100
        MVProveedoresDoctos.Columns.ColumnByFieldName("FDocto").Width = 130
        MVProveedoresDoctos.Columns.ColumnByFieldName("Nave").Width = 160
        MVProveedoresDoctos.Columns.ColumnByFieldName("FVento").Width = 130
        MVProveedoresDoctos.Columns.ColumnByFieldName("SemanaCompra").Width = 100
        MVProveedoresDoctos.Columns.ColumnByFieldName("SemanaPago").Width = 100
        MVProveedoresDoctos.Columns.ColumnByFieldName("Cargo").Width = 100
        MVProveedoresDoctos.Columns.ColumnByFieldName("Saldo").Width = 100
        MVProveedoresDoctos.Columns.ColumnByFieldName("Concepto").Width = 100
        MVProveedoresDoctos.Columns.ColumnByFieldName("ModificadoSemana").Width = 100

        MVProveedoresDoctos.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVProveedoresDoctos.Columns.ColumnByFieldName("Cargo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVProveedoresDoctos.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatString = "N2"
        MVProveedoresDoctos.Columns.ColumnByFieldName("Cargo").DisplayFormat.FormatString = "N2"


        MVProveedoresDoctos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(MVProveedoresDoctos.Columns("Saldo").Summary.FirstOrDefault(Function(x) x.FieldName = "Saldo")) = True Then
            MVProveedoresDoctos.Columns("Saldo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Saldo"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVProveedoresDoctos.GroupSummary.Add(item)
        End If

        If IsNothing(MVProveedoresDoctos.Columns("Cargo").Summary.FirstOrDefault(Function(x) x.FieldName = "Cargo")) = True Then
            MVProveedoresDoctos.Columns("Cargo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cargo", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Cargo"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVProveedoresDoctos.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVProveedoresDoctos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub


    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub btnLimpiarProveedor_Click(sender As Object, e As EventArgs) Handles btnLimpiarProveedor.Click
        grdProveedor.DataSource = listaInicial
    End Sub

    Private Sub grdProveedor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProveedor.InitializeLayout
        grid_diseño(grdProveedor)
        grdProveedor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Proveedores"
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdProveedor.DataSource = Nothing
        grdProveedoresDoctos.DataSource = Nothing
        lblFechaUltimaActualización.Text = "-"
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = MVProveedoresDoctos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                MVProveedoresDoctos.SetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "Seleccionar", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim form As New EditarSemanaPagoProveedorForm
        Dim NumeroFilas = MVProveedoresDoctos.DataRowCount
        Dim advertencia As New AdvertenciaForm
        Dim lstRenglonesEditados As New List(Of Entidades.EditarSemanaPagoProveedor)
        Dim lstProveedorId As New List(Of String)


        If MVProveedoresDoctos.DataRowCount > 0 Then
            Cursor = Cursors.WaitCursor

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(MVProveedoresDoctos.IsRowSelected(MVProveedoresDoctos.GetVisibleRowHandle(index))) = True Then
                    If lstProveedorId.Contains(MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "ProveedorID").ToString()) = False Then
                        lstProveedorId.Add(MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "ProveedorID").ToString())
                    End If
                End If
            Next

            Try

                If lstProveedorId.Count > 2 Then
                    advertencia.mensaje = "Seleccione Documentos de un solo Proveedor"
                    advertencia.ShowDialog()
                End If

                For index As Integer = 0 To NumeroFilas Step 1
                    Dim vEditarSemPago As New Entidades.EditarSemanaPagoProveedor
                    If CBool(MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                        vEditarSemPago.PDocto = MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "Docto")
                        vEditarSemPago.PFactura = MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "Factura")
                        vEditarSemPago.PSemanaActual = MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "SemanaActual")
                        vEditarSemPago.PImporte = MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "Cargo")
                        vEditarSemPago.PProveedorID = MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "ProveedorID")
                        vEditarSemPago.PAnioActual = MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "AnioActual")
                        vEditarSemPago.PSemanaCompraActual = MVProveedoresDoctos.GetRowCellValue(MVProveedoresDoctos.GetVisibleRowHandle(index), "SemanaCompraActual")
                        form.vLstDocumentoSemanaPago.Add(vEditarSemPago)
                    End If
                Next
                form.ShowDialog()
                btnMostrar_Click(Nothing, Nothing)
                Cursor = Cursors.Default

            Catch ex As Exception

            End Try

        Else
            advertencia.mensaje = "Debe seleccionar un documento."
            advertencia.ShowDialog()
        End If
    End Sub


    Private Sub MVProveedoresDoctos_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles MVProveedoresDoctos.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim ModificadoSemana As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'Id SAY
            ModificadoSemana = currentView.GetRowCellValue(e.RowHandle, "ModificadoSemana")

            If e.Column.FieldName = "ModificadoSemana" Then
                If e.CellValue = "S" Then
                    e.Appearance.BackColor = pnlActualizada.BackColor
                    e.Appearance.ForeColor = pnlActualizada.BackColor
                End If

            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            'show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        grbParametros.Height = 200
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        grbParametros.Height = 30
    End Sub

End Class