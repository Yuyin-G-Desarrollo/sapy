Imports System.Drawing
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class Cobranza_ReporteProyeccionForm
    Dim listaInicial As New List(Of String)
    Dim objadvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim confirmar As New Tools.ConfirmarForm
    Public FClientes As String = String.Empty

    Private Sub grdProyeccionCobranza_Load(sender As Object, e As EventArgs) Handles grdProyeccionCobranza.Load
        WindowState = FormWindowState.Maximized
        grdClientes.DataSource = listaInicial
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        dtpFechaFin.Value = Date.Now
        grdDClientes.DataSource = listaInicial
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Negocios.ProyeccionCobranzaBU
        Dim dtProyeccionDatos As New DataTable



        Try
            If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
                objadvertencia.mensaje = "La fecha inicial no puede ser mayor a la fecha final."
                objadvertencia.ShowDialog()
                dtpFechaInicio.Focus()
            End If

            grdProyeccionCobranza.DataSource = Nothing
            grdDClientes.DataSource = Nothing
            MVDClientes.Columns.Clear()
            MVProyeccionCobranza.Columns.Clear()

            FClientes = ObtenerFiltrosGrid(grdClientes)

            Cursor = Cursors.WaitCursor
            poblarGridDescuentos()
            dtProyeccionDatos = objBU.ObtenerDatosProyeccionCobranza(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, FClientes)


            If dtProyeccionDatos.Rows.Count > 0 Then
                grdProyeccionCobranza.DataSource = dtProyeccionDatos
                disenoGrid()
                disenoGridDescuentos()
                lblFechaUltimaActualización.Text = Date.Now
                lblNumFiltrados.Text = CDbl(MVProyeccionCobranza.RowCount.ToString()).ToString("n0")
            Else
                objadvertencia.mensaje = "No existe información del Cliente."
                objadvertencia.ShowDialog()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub disenoGridDescuentos()
        MVDClientes.OptionsView.ColumnAutoWidth = False
        If IsNothing(MVDClientes.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVDClientes.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVDClientes.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVDClientes.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVDClientes.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

        MVDClientes.Columns.ColumnByFieldName("#").Caption = "#"


        MVDClientes.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        MVDClientes.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        MVDClientes.Columns.ColumnByFieldName("MotivoDescuento").OptionsColumn.AllowEdit = False
        MVDClientes.Columns.ColumnByFieldName("LugarDescuento").OptionsColumn.AllowEdit = False
        MVDClientes.Columns.ColumnByFieldName("Porcentaje").OptionsColumn.AllowEdit = False

        MVDClientes.Columns.ColumnByFieldName("#").Width = 10
        MVDClientes.Columns.ColumnByFieldName("Cliente").Width = 155
        MVDClientes.Columns.ColumnByFieldName("MotivoDescuento").Width = 80
        MVDClientes.Columns.ColumnByFieldName("LugarDescuento").Width = 75
        MVDClientes.Columns.ColumnByFieldName("Porcentaje").Width = 60

        MVDClientes.Columns.ColumnByFieldName("MotivoDescuento").Caption = "Motivo"
        MVDClientes.Columns.ColumnByFieldName("LugarDescuento").Caption = "Lugar"
        MVDClientes.Columns.ColumnByFieldName("Porcentaje").Caption = "%"

        MVDClientes.Columns.ColumnByFieldName("Porcentaje").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


    End Sub

    Private Sub disenoGrid()
        MVProyeccionCobranza.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVProyeccionCobranza.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVProyeccionCobranza.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVProyeccionCobranza.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVProyeccionCobranza.Columns.Item("#").VisibleIndex = 0
        End If


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVProyeccionCobranza.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

        MVProyeccionCobranza.Columns.ColumnByFieldName("#").Caption = "#"
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdCadena").Caption = "ClienteID"
        MVProyeccionCobranza.Columns.ColumnByFieldName("Cliente").Caption = "Cliente"
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdRemision").Caption = "Remisión"
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdFactura").Caption = "Factura"
        MVProyeccionCobranza.Columns.ColumnByFieldName("TipoDocto").Caption = "Tipo"
        MVProyeccionCobranza.Columns.ColumnByFieldName("EmpresaFactura").Caption = "Empresa"
        MVProyeccionCobranza.Columns.ColumnByFieldName("FechaVenta").Caption = "Fecha Docto"
        MVProyeccionCobranza.Columns.ColumnByFieldName("Fechavence").Caption = "Fecha Vence"
        MVProyeccionCobranza.Columns.ColumnByFieldName("plazo").Caption = "Plazo"
        MVProyeccionCobranza.Columns.ColumnByFieldName("PlazoPromedio").Caption = "Plazo Promedio"
        'MVProyeccionCobranza.Columns.ColumnByFieldName("DescuentoPP").Caption = "Descuento"
        'MVProyeccionCobranza.Columns.ColumnByFieldName("MotivoDescuento").Caption = "Motivo Descuento"
        MVProyeccionCobranza.Columns.ColumnByFieldName("Monto").Caption = "Total Docto"
        MVProyeccionCobranza.Columns.ColumnByFieldName("Saldo").Caption = "Saldo"
        MVProyeccionCobranza.Columns.ColumnByFieldName("Descuento").Caption = "Descuento %"

        MVProyeccionCobranza.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdCadena").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdRemision").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdFactura").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("TipoDocto").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("EmpresaFactura").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("FechaVenta").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("Fechavence").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("plazo").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("PlazoPromedio").OptionsColumn.AllowEdit = False
        'MVProyeccionCobranza.Columns.ColumnByFieldName("DescuentoPP").OptionsColumn.AllowEdit = False
        'MVProyeccionCobranza.Columns.ColumnByFieldName("MotivoDescuento").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("Monto").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("Saldo").OptionsColumn.AllowEdit = False
        MVProyeccionCobranza.Columns.ColumnByFieldName("Descuento").OptionsColumn.AllowEdit = False

        MVProyeccionCobranza.Columns.ColumnByFieldName("#").Width = 30
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdCadena").Width = 60
        MVProyeccionCobranza.Columns.ColumnByFieldName("Cliente").Width = 180
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdRemision").Width = 80
        MVProyeccionCobranza.Columns.ColumnByFieldName("IdFactura").Width = 80
        MVProyeccionCobranza.Columns.ColumnByFieldName("TipoDocto").Width = 30
        MVProyeccionCobranza.Columns.ColumnByFieldName("EmpresaFactura").Width = 200
        MVProyeccionCobranza.Columns.ColumnByFieldName("FechaVenta").Width = 100
        MVProyeccionCobranza.Columns.ColumnByFieldName("Fechavence").Width = 100
        MVProyeccionCobranza.Columns.ColumnByFieldName("plazo").Width = 60
        MVProyeccionCobranza.Columns.ColumnByFieldName("PlazoPromedio").Width = 80
        'MVProyeccionCobranza.Columns.ColumnByFieldName("DescuentoPP").Width = 60
        'MVProyeccionCobranza.Columns.ColumnByFieldName("MotivoDescuento").Width = 100
        MVProyeccionCobranza.Columns.ColumnByFieldName("Monto").Width = 100
        MVProyeccionCobranza.Columns.ColumnByFieldName("Saldo").Width = 100
        MVProyeccionCobranza.Columns.ColumnByFieldName("Descuento").Width = 100

        MVProyeccionCobranza.Columns.ColumnByFieldName("plazo").DisplayFormat.FormatType = DevExpress.Utils.HorzAlignment.Center


        MVProyeccionCobranza.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVProyeccionCobranza.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVProyeccionCobranza.Columns.ColumnByFieldName("PlazoPromedio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVProyeccionCobranza.Columns.ColumnByFieldName("Descuento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        MVProyeccionCobranza.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatString = "N2"
        MVProyeccionCobranza.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatString = "N2"
        MVProyeccionCobranza.Columns.ColumnByFieldName("plazo").DisplayFormat.FormatString = "N0"
        MVProyeccionCobranza.Columns.ColumnByFieldName("Descuento").DisplayFormat.FormatString = "N2"
        MVProyeccionCobranza.Columns.ColumnByFieldName("PlazoPromedio").DisplayFormat.FormatString = "N0"

        MVProyeccionCobranza.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(MVProyeccionCobranza.Columns("Saldo").Summary.FirstOrDefault(Function(x) x.FieldName = "Saldo")) = True Then
            MVProyeccionCobranza.Columns("Saldo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Saldo"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVProyeccionCobranza.GroupSummary.Add(item)
        End If

        If IsNothing(MVProyeccionCobranza.Columns("Monto").Summary.FirstOrDefault(Function(x) x.FieldName = "Monto")) = True Then
            MVProyeccionCobranza.Columns("Monto").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Monto", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Monto"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVProyeccionCobranza.GroupSummary.Add(item)
        End If


    End Sub

    Public Sub poblarGridDescuentos()
        Dim objBU As New ProyeccionCobranzaBU
        Dim dtDescuentosPPCliente As New DataTable

        dtDescuentosPPCliente = objBU.ObtieneDescuentoPPCliente(FClientes)
        grdDClientes.DataSource = dtDescuentosPPCliente

    End Sub



    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVProyeccionCobranza.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdClientes.DataSource = Nothing
        grdProyeccionCobranza.DataSource = Nothing
        grdDClientes.DataSource = Nothing
        lblFechaUltimaActualización.Text = "-"
        dtpFechaFin.Value = Date.Now.ToString
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If MVProyeccionCobranza.DataRowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim exportOptions = New XlsxExportOptionsEx()

            exportOptions.ExportType = DevExpress.Export.ExportType.DataAware

            Try

                nombreReporte = "\Cobranza_Proyección"
                nombreReporteParaExportacion = "Proyección Cobranza Detallado"
                exportOptions.SheetName = "Proyeccion_Cobranza"


                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If MVProyeccionCobranza.GroupCount > 0 Then

                            MVProyeccionCobranza.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            MVProyeccionCobranza.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Controles.Mensajes_Y_Alertas("ERROR", ex.Message.ToString())
            End Try
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar. " + vbCrLf + "Asegúrese de haber dado clic en el botón 'MOSTRAR' antes de exportar el reporte")

        End If

        exportarDescuentos()
    End Sub

    Public Sub exportarDescuentos()
        If MVDClientes.DataRowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim exportOptions = New XlsxExportOptionsEx()

            exportOptions.ExportType = DevExpress.Export.ExportType.DataAware

            Try

                nombreReporte = "\Cobranza_ProyecciónDescuentos"
                nombreReporteParaExportacion = "Proyección Cobranza DetalladoDescuentos"
                exportOptions.SheetName = "Proyeccion_CobranzaDescuentos"


                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If MVDClientes.GroupCount > 0 Then

                            MVDClientes.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            MVDClientes.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Controles.Mensajes_Y_Alertas("ERROR", ex.Message.ToString())
            End Try
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar. " + vbCrLf + "Asegúrese de haber dado clic en el botón 'MOSTRAR' antes de exportar el reporte")

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

    Private Sub btnCliente_Click_1(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosProyeccionCobranza
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listaParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listaInicial
    End Sub

    Private Sub grdClientes_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Try
            If e.RowHandle >= 0 Then
                If e.ColumnFieldName = "Monto" Then
                    e.Formatting.BackColor = Color.FromArgb(234, 232, 232)
                    e.Formatting.Font.Bold = True
                End If
            End If

            If e.RowHandle >= 0 Then
                If e.ColumnFieldName = "Saldo" Then
                    e.Formatting.BackColor = Color.FromArgb(234, 232, 232)
                    e.Formatting.Font.Bold = True
                End If
            End If

        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("Error", ex.Message.ToString())
        End Try
        e.Handled = True
    End Sub

End Class