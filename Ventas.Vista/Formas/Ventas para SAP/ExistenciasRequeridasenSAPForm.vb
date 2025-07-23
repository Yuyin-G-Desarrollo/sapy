Imports Tools
Imports Infragistics.Documents.Excel
Imports DevExpress.XtraGrid
Imports Tools.modMensajes
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ExistenciasRequeridasenSAPForm

    Public dtArticulosFaltantesSap As New DataTable
    Public NombreArchivoExcel As String = String.Empty
    Dim dtDatosMostrarImportadosClientesSAP As New DataTable
    Dim dtCantidadClientesFaltantesSAP As New DataTable
    Dim dtClientesFaltantesSAP As New DataTable
    Dim FilasSeleccionadas As Integer = 0
    Dim lstFiltroFactura As New List(Of String)

    Private Sub ExistenciasRequeridasenSAPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cargarComboEmpresas()
        limpiarTablaTemporal()
        btnExportarExcel.Enabled = False
        lblExportar.Enabled = False
        btndetalles.Enabled = False
        lblverdetalles.Enabled = False
        AgregarPermsisosUsuarios()
        txtFiltroFactura.Enabled = False
    End Sub
    Private Sub AgregarPermsisosUsuarios()
        If PermisosUsuarioBU.ConsultarPermiso("VENTAS_SAP", "PT_SAP_COMPLEMENTOS_FACTURAR") Then
            btnFacturar.Visible = True
            lblFacturar.Visible = True
            btnFacturar.Enabled = False
            lblFacturar.Enabled = False
        Else
            btnFacturar.Visible = False
            lblFacturar.Visible = False
        End If
    End Sub
    Public Sub cargarComboEmpresas()
        Dim objBu As New Negocios.CatalogoEmpresasBU
        Dim dtEmpresa As New DataTable
        dtEmpresa = objBu.ConsultarEmpresas()
        If dtEmpresa.Rows.Count > 0 Then
            If dtEmpresa.Rows.Count = 1 Then
                Dim dtRow As DataRow = dtEmpresa.NewRow
                dtRow("ID") = 0
                dtRow("Nombre") = ""
                dtEmpresa.Rows.InsertAt(dtRow, 0)
                cmbRazonSocial.DataSource = dtEmpresa
                cmbRazonSocial.DisplayMember = "Nombre"
                cmbRazonSocial.ValueMember = "ID"
                cmbRazonSocial.SelectedIndex = 1
            Else
                cmbRazonSocial.DataSource = dtEmpresa
                cmbRazonSocial.DisplayMember = "Nombre"
                cmbRazonSocial.ValueMember = "ID"
                cmbRazonSocial.SelectedIndex = 1
            End If
        End If

    End Sub
    Private Sub limpiarTablaTemporal()
        Dim objBU As New Ventas.Negocios.RegistrarInventarioSAPBU
        objBU.LimpiarTablaTemporalSAP()
        objBU.LimpiarTablaTemporalClientesSAP()
    End Sub
    Private Sub btnImportarInventario_Click(sender As Object, e As EventArgs) Handles btnImportarInventario.Click
        Cursor = Cursors.WaitCursor
        dtDatosMostrarImportadosClientesSAP.Columns.Clear()
        dtDatosMostrarImportadosClientesSAP.Rows.Clear()
        grdArticulosCompra.DataSource = Nothing

        If rdoagregarfacturas.Checked = True And grdFactura.Rows.Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Faltan la factura(s) a importar en el inventario.")
            Cursor = Cursors.Default
            Exit Sub
        End If
        InsertarExcelImportado()
    End Sub
    Private Sub InsertarExcelImportado()
        Dim dtDatosMostarImportados As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim razonsocial As Int16 = 0
        Dim fechaFacturasInicio As Date = dtpFechaInicio.Value
        Dim fechaFacturasFin As Date = dtpfechaFin.Value
        Dim dtArticulosCantidadesSap As New DataTable
        Dim dtArticulosSapFacturados As New DataTable
        Dim facturasIds As String = String.Empty

        Dim objBU As New Ventas.Negocios.RegistrarInventarioSAPBU
        dtDatosMostarImportados = ImportarExcel()
        If dtDatosMostarImportados.Rows.Count > 0 Then
            objBU.RegistrarInventarioSAP(dtDatosMostarImportados)
            razonsocial = cmbRazonSocial.SelectedValue

            facturasIds = ObtenerFiltrosGrid(grdFactura)
            dtArticulosFaltantesSap = objBU.ObtenerArticulosFaltantesSAP(razonsocial, fechaFacturasInicio, fechaFacturasFin, facturasIds)
            dtArticulosCantidadesSap = objBU.ObtenerArticulosCantidadesSAP(razonsocial, fechaFacturasInicio, fechaFacturasFin, facturasIds)

            'If rdoagregarfacturas.Checked = False Then ''--> peticion de juana guerrero 01/08/2021
            'dtArticulosSapFacturados = objBU.ConsultarArticulosFacturados(razonsocial, fechaFacturasInicio, fechaFacturasFin) '' consulta los articulos que ya estan facturados
            'End If

            If dtArticulosFaltantesSap.Rows.Count > 0 Then
                lblArticulosFaltantesSAP.Visible = True
                lblTotalArticulosFaltantesSAP.Visible = True
                lblTotalArticulosFaltantesSAP.Text = dtArticulosFaltantesSap.Rows.Count.ToString
                btnExportarExcel.Enabled = True
                lblExportar.Enabled = True
                btndetalles.Enabled = True
                lblverdetalles.Enabled = True
            Else
                lblArticulosFaltantesSAP.Visible = False
                    lblTotalArticulosFaltantesSAP.Visible = False
                    lblTotalArticulosFaltantesSAP.Text = "0"
                End If
                lblTotalArticulos.Text = dtArticulosCantidadesSap.Rows.Count.ToString
                If dtArticulosCantidadesSap.Rows.Count > 0 Then
                    grdArticulosCompra.DataSource = dtArticulosCantidadesSap
                    DisenioGrid()
                    lblUltimaActualizacion.Text = Date.Now.ToString
                    btnExportarExcel.Enabled = True
                lblExportar.Enabled = True
                btndetalles.Enabled = True
                lblverdetalles.Enabled = True
                btnFacturar.Enabled = True
                lblFacturar.Enabled = True

                If dtArticulosSapFacturados.Rows.Count > 0 Then '' verifica informacion facturada, x dia
                    btnFacturar.Enabled = False
                    lblFacturar.Enabled = False
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ya existen artículos facturados en la fecha seleccionada.")
                Else
                    btnFacturar.Enabled = True
                        lblFacturar.Enabled = True
                    End If
                Else
                    advertencia.mensaje = "No se han generado ventas en la fecha selecionada."
                    advertencia.ShowDialog()
                End If
            End If
            ''clientes SAP

            If dtDatosMostrarImportadosClientesSAP.Rows.Count > 0 Then
            objBU.RegistrarInventarioClientesSAP(dtDatosMostrarImportadosClientesSAP)
            dtCantidadClientesFaltantesSAP = objBU.obtenerClientesFaltantesSAP(razonsocial, fechaFacturasInicio, fechaFacturasFin)
            If dtCantidadClientesFaltantesSAP.Rows.Count > 0 Then
                InventarioClientesFaltantesSAP()
            Else
                lblClientesFaltantesSAP.Visible = False
                lblcantidadClientesSAP.Visible = False
                lblcantidadClientesSAP.Text = "0"
            End If
        Else
            dtCantidadClientesFaltantesSAP.Columns.Clear()
            dtCantidadClientesFaltantesSAP.Rows.Clear()
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub InventarioClientesFaltantesSAP()
        lblcantidadClientesSAP.Visible = True
        lblClientesFaltantesSAP.Visible = True
        lblcantidadClientesSAP.Text = dtCantidadClientesFaltantesSAP.Rows.Count.ToString
    End Sub
    Private Sub DisenioGrid()
        Tools.DiseñoGrid.AlternarColorEnFilas(vwReporte) '' pone color a las filas del gridview
        vwReporte.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True
        vwReporte.Columns.ColumnByFieldName("Articulo").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ID").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("Nave").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("Razón Social").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("Clave Sat").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("Solicitados").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("Disponible SAP").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("A Solicitar").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("Origen").OptionsColumn.AllowEdit = False
        vwReporte.BestFitColumns()
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.IndicatorWidth = 30
        vwReporte.OptionsView.ShowIndicator = True
        vwReporte.OptionsView.RowAutoHeight = True
        vwReporte.OptionsView.ShowAutoFilterRow = True
        vwReporte.Columns.ColumnByFieldName("Articulo").Caption = "Artículo"
        vwReporte.Columns.ColumnByFieldName("Solicitados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("Disponible SAP").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("A Solicitar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("Solicitados").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("Disponible SAP").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("A Solicitar").DisplayFormat.FormatString = "N0"

        vwReporte.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        vwReporte.OptionsSelection.CheckBoxSelectorColumnWidth = 35

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("Solicitados") Or col.FieldName.Contains("Disponible SAP") Or col.FieldName.Contains("A Solicitar") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Solicitados")) = True And col.FieldName = "Solicitados" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Disponible SAP")) = True Or col.FieldName = "Disponible SAP" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "A Solicitar")) = True And col.FieldName = "A Solicitar" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
            End If
        Next
    End Sub
    Public Function ImportarExcel() As DataTable
        Dim advertencia As New AdvertenciaForm
        Dim datosExcel As New DataTable
        Dim datosClientesSAP As New DataTable
        Dim NombreArchivo As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumRenglonClientes As Integer = 0
        Dim dtDatosMostarImportados As New DataTable

        Try
            datosExcel = Tools.Excel.LlenarTablaExcelInventarioSAP("Hoja1$", "", NombreArchivo)
            datosClientesSAP = Tools.Excel.LlenarTablaExcelInventarioSAP("Hoja2$", NombreArchivo, NombreArchivo)
            NombreArchivoExcel = NombreArchivo
            Cursor = Cursors.WaitCursor
            If IsNothing(datosExcel) = False Then
                If datosExcel.Rows.Count > 0 Then ''articulos SAP
                    dtDatosMostarImportados.Columns.Add("Id")
                    dtDatosMostarImportados.Columns.Add("Existencias")
                    For Each row As DataRow In datosExcel.Rows
                        Dim id As String = LTrim(RTrim(row.Item(0).ToString()))
                        Dim existencia As String = LTrim(RTrim(row.Item(5).ToString()))
                        If existencia = "" Then
                            existencia = "0"
                        End If
                        dtDatosMostarImportados.Rows.Add()
                        dtDatosMostarImportados.Rows(NumRenglon)("Id") = row("Id")
                        dtDatosMostarImportados.Rows(NumRenglon)("Existencias") = existencia
                        NumRenglon += 1
                    Next
                End If
                If datosClientesSAP.Rows.Count > 0 Then ''Clientes SAP
                    dtDatosMostrarImportadosClientesSAP.Columns.Clear()
                    dtDatosMostrarImportadosClientesSAP.Columns.Add("idCliente")
                    dtDatosMostrarImportadosClientesSAP.Columns.Add("Cliente")
                    For Each row As DataRow In datosClientesSAP.Rows
                        Dim idCliente As String = LTrim(RTrim(row.Item(0).ToString()))
                        Dim Cliente As String = LTrim(RTrim(row.Item(1).ToString()))
                        dtDatosMostrarImportadosClientesSAP.Rows.Add()
                        dtDatosMostrarImportadosClientesSAP.Rows(NumRenglonClientes)("idCliente") = row.Item(0).ToString()
                        dtDatosMostrarImportadosClientesSAP.Rows(NumRenglonClientes)("Cliente") = row.Item(1).ToString()
                        NumRenglonClientes += 1
                    Next
                End If
            Else
                advertencia.mensaje = "No se seleccionó ningún archivo"
                advertencia.ShowDialog()
            End If
        Catch ex As Exception
            advertencia.mensaje = "El archivo no corresponde, favor de volver a revisar"
            advertencia.ShowDialog()
        End Try
        Cursor = Cursors.WaitCursor
        Return dtDatosMostarImportados
    End Function
    Private Sub lblTotalArticulosFaltantesSAP_Click(sender As Object, e As EventArgs) Handles lblTotalArticulosFaltantesSAP.Click
        Dim ArticulosFaltantes As New ArticulosFaltantesenSAPForm
        Dim dtFaltantesSAP As New DataTable

        dtFaltantesSAP = dtArticulosFaltantesSap
        ArticulosFaltantes.grdArticulosFaltantesenSAP.DataSource = dtFaltantesSAP
        ArticulosFaltantes.lblTotalArticulos.Text = dtFaltantesSAP.Rows.Count.ToString
        ArticulosFaltantes.ShowDialog(Me)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdArticulosCompra.DataSource = Nothing
        lblTotalArticulos.Text = "0"
        lblTotalArticulosFaltantesSAP.Text = "0"
        inhabilitarComponentes()
        limpiarTablaTemporal()
        lstFiltroFactura.Clear()
        grdFactura.DataSource = Nothing
    End Sub
    Private Sub inhabilitarComponentes()
        lblArticulosFaltantesSAP.Visible = False
        lblTotalArticulosFaltantesSAP.Visible = False
        btnExportarExcel.Enabled = False
        lblExportar.Enabled = False
        lblcantidadClientesSAP.Visible = False
        lblClientesFaltantesSAP.Visible = False
        btndetalles.Enabled = False
        lblverdetalles.Enabled = False
        btnFacturar.Enabled = False
        lblFacturar.Enabled = False
        rdoagregarfacturas.Checked = False
        txtFiltroFactura.Enabled = False
        grdFactura.Enabled = False
        dtpFechaInicio.Enabled = True
        btnImportarInventario.Enabled = True
        dtpFechaInicio.Visible = False
        rdoFecha.Checked = False
        rdoagregarfacturas.Checked = False
    End Sub
    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        ExportarExcel_v2()
    End Sub
    Public Sub ExportarExcel_v2()
        Dim ExisteArchivo As Boolean
        Dim valida As Boolean
        Dim confirmar As New Tools.ConfirmarForm

        If vwReporte.RowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog

            With fbdUbicacionArchivo
                .Reset()
                .Description = "Seleccione una carpeta "
                .ShowNewFolderButton = True

            End With
            Dim ret As DialogResult = fbdUbicacionArchivo.ShowDialog

            Dim nombreArchivo As String = String.Empty
            Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString

            nombreArchivo = fbdUbicacionArchivo.SelectedPath + "\" + "VENTAS PARA SAP_" + cmbRazonSocial.Text.ToString.Substring(0, 3) + "_" + fecha_hora + ".xls"

            If File.Exists(nombreArchivo) Then
                ExisteArchivo = True
            End If

            If ExisteArchivo = True Then
                confirmar.mensaje = "El archivo " & nombreArchivo & " ya existe ¿Desea reemplazarlo?"
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    valida = True
                Else
                    valida = False
                End If
            Else
                valida = True
            End If

            If ret = Windows.Forms.DialogResult.OK Then
                If valida = True Then
                    Try
                        Dim inicio As Integer = 0
                        Dim workbook As New Infragistics.Documents.Excel.Workbook

                        Dim worksheet As Infragistics.Documents.Excel.Worksheet
                        Dim nombreHoja As String = String.Empty
                        Dim longitud As Integer = Len(vwReporte.GetRowCellValue(0, vwReporte.Columns(10).FieldName.ToString()))


                        nombreHoja = vwReporte.GetRowCellValue(0, vwReporte.Columns(10).FieldName.ToString()).ToString.Substring(18, longitud - 18) + " " + dtpfechaFin.Value.Year.ToString + " " + cmbRazonSocial.Text.ToString.Substring(0, 10)

                        worksheet = workbook.Worksheets.Add(nombreHoja)
                        worksheet.Columns.Item(0).Width = 4700
                        worksheet.Columns.Item(1).Width = 17000
                        worksheet.Columns.Item(2).Width = 4700
                        worksheet.Columns.Item(3).Width = 17000
                        worksheet.Columns.Item(4).Width = 4500
                        worksheet.Columns.Item(5).Width = 2500
                        worksheet.Columns.Item(6).Width = 4500
                        worksheet.Columns.Item(7).Width = 3500
                        worksheet.Columns.Item(8).Width = 2500
                        worksheet.Columns.Item(9).Width = 9000

                        worksheet.Rows.Item(inicio).Cells.Item(0).Value = "Número de artículo"
                        worksheet.Rows.Item(inicio).Cells.Item(1).Value = "Descripción artículo/serv."
                        worksheet.Rows.Item(inicio).Cells.Item(2).Value = "Nave"
                        worksheet.Rows.Item(inicio).Cells.Item(3).Value = "Razón Social"
                        worksheet.Rows.Item(inicio).Cells.Item(4).Value = "Clave SAT"
                        worksheet.Rows.Item(inicio).Cells.Item(5).Value = "Precio"
                        worksheet.Rows.Item(inicio).Cells.Item(6).Value = "Suma de Cantidad"
                        worksheet.Rows.Item(inicio).Cells.Item(7).Value = "En stock"
                        worksheet.Rows.Item(inicio).Cells.Item(8).Value = "A PEDIR"
                        worksheet.Rows.Item(inicio).Cells.Item(9).Value = "ORIGEN"

                        For i As Int16 = inicio To inicio Step 1
                            For j As Int16 = 0 To 9 Step 1
                                worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightSteelBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Left
                                worksheet.Rows(i).Cells(j).CellFormat.Style.StyleFormat.Font.Bold = ExcelDefaultableBoolean.True
                            Next
                        Next

                        For r As Integer = 0 To vwReporte.RowCount - 1
                            For j As Int16 = 0 To 9
                                worksheet.Rows.Item(r + 1).Cells.Item(j).Value = vwReporte.GetRowCellValue(r, vwReporte.Columns(j + 1).FieldName.ToString())
                            Next
                        Next

                        If dtArticulosFaltantesSap.Rows.Count > 0 Then
                            inicio = 0
                            worksheet = workbook.Worksheets.Add("Artículos Faltantes SAP")
                            worksheet.Columns.Item(0).Width = 4700
                            worksheet.Columns.Item(1).Width = 17000
                            worksheet.Columns.Item(2).Width = 3700
                            worksheet.Columns.Item(3).Width = 3700
                            worksheet.Columns.Item(4).Width = 8700
                            worksheet.Columns.Item(5).Width = 2700
                            worksheet.Columns.Item(6).Width = 3200
                            worksheet.Columns.Item(7).Width = 2900
                            worksheet.Columns.Item(8).Width = 3000
                            worksheet.Columns.Item(9).Width = 5700
                            worksheet.Columns.Item(10).Width = 5700
                            worksheet.Columns.Item(11).Width = 2700
                            worksheet.Columns.Item(12).Width = 2700
                            worksheet.Columns.Item(13).Width = 10000
                            worksheet.Columns.Item(14).Width = 5000
                            worksheet.Columns.Item(15).Width = 5700
                            worksheet.Columns.Item(16).Width = 5700
                            worksheet.Columns.Item(17).Width = 5500
                            worksheet.Columns.Item(18).Width = 5700

                            worksheet.Rows.Item(inicio).Cells.Item(0).Value = "Número de artículo" 'dtArticulosFaltantesSap.Columns(0).ColumnName
                            worksheet.Rows.Item(inicio).Cells.Item(1).Value = "Descripción artículo/serv." 'dtArticulosFaltantesSap.Columns(1).ColumnName
                            worksheet.Rows.Item(inicio).Cells.Item(2).Value = "TipoCategoria"
                            worksheet.Rows.Item(inicio).Cells.Item(3).Value = "GroupName"
                            worksheet.Rows.Item(inicio).Cells.Item(4).Value = "Status"
                            worksheet.Rows.Item(inicio).Cells.Item(5).Value = "NaveId"
                            worksheet.Rows.Item(inicio).Cells.Item(6).Value = "NaveDesarrollo"
                            worksheet.Rows.Item(inicio).Cells.Item(7).Value = "MarcaSAYId"
                            worksheet.Rows.Item(inicio).Cells.Item(8).Value = "MarcaSAY"
                            worksheet.Rows.Item(inicio).Cells.Item(9).Value = "FamiliaProyección"
                            worksheet.Rows.Item(inicio).Cells.Item(10).Value = "ColeccionSAY"
                            worksheet.Rows.Item(inicio).Cells.Item(11).Value = "ModeloSAY"
                            worksheet.Rows.Item(inicio).Cells.Item(12).Value = "Corrida"
                            worksheet.Rows.Item(inicio).Cells.Item(13).Value = "PielColor"
                            worksheet.Rows.Item(inicio).Cells.Item(14).Value = "pres_clavesat_detallada"
                            worksheet.Rows.Item(inicio).Cells.Item(15).Value = "ClaveSatGeneral"
                            worksheet.Rows.Item(inicio).Cells.Item(16).Value = "pcsd_clavesat_general"
                            worksheet.Rows.Item(inicio).Cells.Item(17).Value = "FamiliaProyeccionId"
                            worksheet.Rows.Item(inicio).Cells.Item(18).Value = "FamiliaProyeccion"
                            inicio = 1
                            For Each row As DataRow In dtArticulosFaltantesSap.Rows
                                worksheet.Rows.Item(inicio).Cells(0).Value = row("Id")
                                worksheet.Rows.Item(inicio).Cells(1).Value = row("Articulo")
                                worksheet.Rows.Item(inicio).Cells(2).Value = row("TipoCategoria")
                                worksheet.Rows.Item(inicio).Cells(3).Value = row("GroupName")
                                worksheet.Rows.Item(inicio).Cells(4).Value = row("Status")
                                worksheet.Rows.Item(inicio).Cells(5).Value = row("NaveDesarrolloId")
                                worksheet.Rows.Item(inicio).Cells(6).Value = row("NaveDesarrollo")
                                worksheet.Rows.Item(inicio).Cells(7).Value = row("MarcaSAYId")
                                worksheet.Rows.Item(inicio).Cells(8).Value = row("MarcaSAY")
                                worksheet.Rows.Item(inicio).Cells(9).Value = row("FamiliaProyección")
                                worksheet.Rows.Item(inicio).Cells(10).Value = row("ColeccionSAY")
                                worksheet.Rows.Item(inicio).Cells(11).Value = row("ModeloSAY")
                                worksheet.Rows.Item(inicio).Cells(12).Value = row("CorridaAgrupamiento")
                                worksheet.Rows.Item(inicio).Cells(13).Value = row("PielColor")
                                worksheet.Rows.Item(inicio).Cells(14).Value = row("pres_clavesat_detallada")
                                worksheet.Rows.Item(inicio).Cells(15).Value = row("ClaveSatGeneral")
                                worksheet.Rows.Item(inicio).Cells(16).Value = row("pcsd_clavesat_general")
                                worksheet.Rows.Item(inicio).Cells(17).Value = row("FamiliaProyeccionId")
                                worksheet.Rows.Item(inicio).Cells(18).Value = row("FamiliaProyeccion")
                                inicio += 1
                            Next
                            For i As Int16 = inicio To inicio Step 1
                                For j As Int16 = 0 To 18 Step 1
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                    worksheet.Rows(0).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightSteelBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                Next
                            Next
                        End If

                        '' formato clientes faltantes SAP
                        If dtCantidadClientesFaltantesSAP.Rows.Count > 0 Then
                            inicio = 0
                            worksheet = workbook.Worksheets.Add("Clientes Faltantes SAP")
                            worksheet.Columns.Item(0).Width = 4000
                            worksheet.Columns.Item(1).Width = 4000
                            worksheet.Columns.Item(2).Width = 3000
                            worksheet.Columns.Item(3).Width = 9100
                            worksheet.Columns.Item(4).Width = 16800
                            worksheet.Columns.Item(5).Width = 3200
                            worksheet.Columns.Item(6).Width = 6200
                            worksheet.Columns.Item(7).Width = 6200
                            worksheet.Columns.Item(8).Width = 2900
                            worksheet.Columns.Item(9).Width = 10000

                            worksheet.Rows.Item(inicio).Cells.Item(0).Value = "Cliente SAY"
                            worksheet.Rows.Item(inicio).Cells.Item(1).Value = "Cliente SICY"
                            worksheet.Rows.Item(inicio).Cells.Item(2).Value = "Codigo"
                            worksheet.Rows.Item(inicio).Cells.Item(3).Value = "Razón Social"
                            worksheet.Rows.Item(inicio).Cells.Item(4).Value = "Dirección"
                            worksheet.Rows.Item(inicio).Cells.Item(5).Value = "Código Postal"
                            worksheet.Rows.Item(inicio).Cells.Item(6).Value = "Ciudad"
                            worksheet.Rows.Item(inicio).Cells.Item(7).Value = "Estado"
                            worksheet.Rows.Item(inicio).Cells.Item(8).Value = "Plazo"
                            worksheet.Rows.Item(inicio).Cells.Item(9).Value = "Cadena"
                            inicio = 1
                            For Each row As DataRow In dtCantidadClientesFaltantesSAP.Rows
                                worksheet.Rows.Item(inicio).Cells(0).Value = row("Cliente_SAY")
                                worksheet.Rows.Item(inicio).Cells(1).Value = row("Cliente_SICY")
                                worksheet.Rows.Item(inicio).Cells(2).Value = row("Código")
                                worksheet.Rows.Item(inicio).Cells(3).Value = row("Razón Social")
                                worksheet.Rows.Item(inicio).Cells(4).Value = row("Dirección")
                                worksheet.Rows.Item(inicio).Cells(5).Value = row("Código Postal")
                                worksheet.Rows.Item(inicio).Cells(6).Value = row("Ciudad")
                                worksheet.Rows.Item(inicio).Cells(7).Value = row("Estado")
                                worksheet.Rows.Item(inicio).Cells(8).Value = row("Plazo")
                                worksheet.Rows.Item(inicio).Cells(9).Value = row("Cadena")
                                inicio += 1
                            Next
                            For i As Int16 = inicio To inicio Step 1
                                For j As Int16 = 0 To 9 Step 1
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                    worksheet.Rows(0).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightSteelBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                Next
                            Next
                        End If
                        workbook.Save(nombreArchivo)

                        Dim objMensajeExito As New ExitoForm
                        objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                        objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicación " + nombreArchivo + "."
                        objMensajeExito.ShowDialog()
                        Process.Start(nombreArchivo)

                    Catch ex As Exception
                        Dim objMensajeError As New ErroresForm
                        objMensajeError.StartPosition = FormStartPosition.CenterScreen
                        objMensajeError.mensaje = ex.Message
                        objMensajeError.ShowDialog()
                    End Try

                Else
                    Controles.Mensajes_Y_Alertas("INFORMACION", "Archivo ya existe.")
                End If
            Else
                Controles.Mensajes_Y_Alertas("INFORMACION", "No se seleccionó ninguna ubicación.")
            End If
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar.")
        End If

    End Sub
    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        ' If dtpfechaFin.Value < dtpFechaInicio.Value Then
        dtpfechaFin.Value = dtpFechaInicio.Value
        ' End If
        'dtpfechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_VENTAS_PARA_SAP_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_VENTAS_PARA_SAP_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub lblcantidadClientesSAP_Click(sender As Object, e As EventArgs) Handles lblcantidadClientesSAP.Click
        Dim InventarioClientesFaltantes As New ClientesFaltantesSAPForm
        InventarioClientesFaltantes.grdReporteClientesFaltantesSAP.DataSource = dtCantidadClientesFaltantesSAP
        InventarioClientesFaltantes.lblTotalClientes.Text = dtCantidadClientesFaltantesSAP.Rows.Count.ToString
        InventarioClientesFaltantes.ShowDialog(Me)
    End Sub
    Private Sub btndetalles_Click(sender As Object, e As EventArgs) Handles btndetalles.Click
        ObtenerDetallesArticulosFaltantesSAP()
    End Sub
    Private Sub ObtenerDetallesArticulosFaltantesSAP()
        Dim DocumentoId As String = ""
        DocumentoId = DocumentosSeleccionadosFaltantesSAP()
        If FilasSeleccionadas = 0 Then
            Dim objMensajeExito As New ErroresForm
            objMensajeExito.StartPosition = FormStartPosition.CenterScreen
            objMensajeExito.mensaje = "Favor de seleccionar un documento, para ver sus detalles"
            objMensajeExito.ShowDialog()
        Else
            Dim DetallesDocumentosSAP As New DocumentosDetallesExistenciasSAPForm
            DetallesDocumentosSAP.Documentos = DocumentoId
            DetallesDocumentosSAP.FechaInicioSAP = dtpFechaInicio.Value
            DetallesDocumentosSAP.FechaFinalSAP = dtpfechaFin.Value
            DetallesDocumentosSAP.FacturasIdsSAP = ObtenerFiltrosGrid(grdFactura)
            DetallesDocumentosSAP.razonSocialSap = cmbRazonSocial.SelectedValue
            DetallesDocumentosSAP.ShowDialog()
        End If
    End Sub
    Private Function DocumentosSeleccionadosFaltantesSAP() As String
        Dim documentosSeleccionados As String = String.Empty
        Dim NumeroFilas As Integer
        FilasSeleccionadas = 0
        NumeroFilas = vwReporte.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), " ")) = True Then
                FilasSeleccionadas += 1

                If documentosSeleccionados = String.Empty Then
                    documentosSeleccionados = vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), "ID").ToString()
                Else
                    documentosSeleccionados = documentosSeleccionados & "," & vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), "ID").ToString()
                End If
            End If
        Next
        Cursor = Cursors.Default

        Return documentosSeleccionados

        Cursor = Cursors.WaitCursor
    End Function
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
    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub btnFacturar_Click(sender As Object, e As EventArgs) Handles btnFacturar.Click
        If ValidarPreciosArticulosSAP() Then
            FacturarComplementosPT_SAP()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Existen artículos sin precio, no es posible facturar.")
        End If
    End Sub
    Private Function ValidarPreciosArticulosSAP() As Boolean
        Dim validarPrecios As Boolean = True
        Dim i As Integer = 0

        For i = 0 To vwReporte.RowCount - 1
            If (vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(i), "Precio")).Equals(0) Or IsDBNull(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(i), "Precio")) Then
                validarPrecios = False
                Exit For
            End If
        Next

        Return validarPrecios

    End Function
    Private Sub FacturarComplementosPT_SAP()
        Dim objFormComplementos_SAP As New ResumenFacturasComplementoPTISAPForm
        objFormComplementos_SAP.RazonSocialId = cmbRazonSocial.SelectedValue
        objFormComplementos_SAP.FechaInicio = dtpFechaInicio.Value
        objFormComplementos_SAP.FechaFinal = dtpfechaFin.Value
        objFormComplementos_SAP.FacturasIdSap = ObtenerFiltrosGrid(grdFactura)
        objFormComplementos_SAP.ShowDialog()
    End Sub

    Private Sub rdoagregarfacturas_CheckedChanged(sender As Object, e As EventArgs) Handles rdoagregarfacturas.CheckedChanged
        If rdoagregarfacturas.Checked = True Then
            habilitarComponentes()
        End If
    End Sub
    Private Sub habilitarComponentes()
        dtpFechaInicio.Visible = False
        txtFiltroFactura.Enabled = True
        grdFactura.Enabled = True
        grdFactura.DataSource = Nothing
        txtFiltroFactura.Text = ""
    End Sub
    Private Sub txtFiltroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFactura.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
                If String.IsNullOrEmpty(txtFiltroFactura.Text) Then Return

                lstFiltroFactura.Add(txtFiltroFactura.Text)
                grdFactura.DataSource = Nothing
                grdFactura.DataSource = lstFiltroFactura

                txtFiltroFactura.Text = String.Empty
            End If
        End If
    End Sub
    Private Sub grdFactura_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFactura.InitializeLayout
        grid_diseño(grdFactura)
        grdFactura.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Factura"
    End Sub
    Private Sub grdFactura_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFactura.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20 ''---> tamaño selector ultragrid
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub
    Private Sub rdoFecha_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFecha.CheckedChanged
        If rdoFecha.Checked = True Then
            habilitarComponentesFecha()
        End If
    End Sub
    Private Sub habilitarComponentesFecha()
        dtpFechaInicio.Visible = True
        txtFiltroFactura.Enabled = False
        grdFactura.Enabled = False
    End Sub
End Class
