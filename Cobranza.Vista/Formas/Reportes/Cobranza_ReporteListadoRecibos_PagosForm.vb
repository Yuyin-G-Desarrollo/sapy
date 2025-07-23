Imports System.Drawing
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Tools

Public Class Cobranza_ReporteListadoRecibos_PagosForm
    Dim advertencia As New AdvertenciaForm
    Dim listaInicial As New List(Of String)
    Dim listaInicialAgentes As New List(Of String)
    Dim listaInicialEmpresas As New List(Of String)
    Public FClientes As String = String.Empty
    Public FAgentes As String = String.Empty
    Public FEmpresas As String = String.Empty
    Dim formatoExcel As StiExcelExportSettings = New StiExcelExportSettings()
    Dim total As Double
    Dim totalCheques As Double
    Dim totalDepositos As Double
    Dim totalEfectivo As Double
    Dim promedioReal As Double
    Dim promedioCTE As Double
    Dim entradaDolares As Double
    Dim totalPesosDolares As Double
    Dim totalPesosDolaresCheques As Double
    Dim totalPesosDolaresDepositos As Double
    Dim totalPesosDolaresEfectivo As Double
    Dim totalDolares As Double
    Dim cambiomonetario As Double
    Dim granTotal As Double

    Private Sub Cobranza_ReporteListadoRecibos_PagosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdClientes.DataSource = listaInicial
        grdAgentes.DataSource = listaInicialAgentes
        grdEmpresas.DataSource = listaInicialEmpresas
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        dtpFechaFin.Value = Date.Now

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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New ConsultaDocumentosBU
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim dtObtieneInfoReportePagos As New DataTable

        Try

            If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
                advertencia.mensaje = "La fecha inicial no puede ser mayor a la fecha final."
                advertencia.ShowDialog()
                dtpFechaInicio.Focus()
            End If

            fechaInicio = CDate(dtpFechaInicio.Value.ToShortDateString)
            fechaFin = CDate(dtpFechaFin.Value.ToShortDateString)


            grdListadoPagos.DataSource = Nothing
            MVListadoPagos.Columns.Clear()
            FClientes = ObtenerFiltrosGrid(grdClientes)
            FAgentes = ObtenerFiltrosGrid(grdAgentes)
            FEmpresas = ObtenerFiltrosGrid(grdEmpresas)

            Cursor = Cursors.WaitCursor


            dtObtieneInfoReportePagos = objBU.ObtieneInformacionReportePagos(FClientes, FAgentes, FEmpresas, fechaInicio, fechaFin, 0)

            If dtObtieneInfoReportePagos.Rows.Count > 0 Then
                grdListadoPagos.DataSource = dtObtieneInfoReportePagos
                lblFechaUltimaActualización.Text = Date.Now
                lblNumFiltrados.Text = CDbl(MVListadoPagos.RowCount.ToString()).ToString("n0")
                calcularTotal()
                DiseñoGrid()
            Else
                advertencia.mensaje = "No hay información para mostrar."
                advertencia.ShowDialog()
            End If

        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub DiseñoGrid()
        MVListadoPagos.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVListadoPagos.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVListadoPagos.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVListadoPagos.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVListadoPagos.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVListadoPagos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        'MVListadoPagos.Columns.ColumnByFieldName("CuentaID").Visible = False

        MVListadoPagos.Columns.ColumnByFieldName("#").Width = 30
        MVListadoPagos.Columns.ColumnByFieldName("recibo").Width = 50
        MVListadoPagos.Columns.ColumnByFieldName("fechacaptura").Width = 150
        MVListadoPagos.Columns.ColumnByFieldName("razonsocial").Width = 150
        MVListadoPagos.Columns.ColumnByFieldName("idCliente").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("nombreC").Width = 200
        MVListadoPagos.Columns.ColumnByFieldName("razonsocialC").Width = 200
        MVListadoPagos.Columns.ColumnByFieldName("Cheques").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("Depositos").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("Efectivo").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("Ajuste").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("Total").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("plazo").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("plazoPago").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("estatus").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("fechaCancelacion").Width = 150
        MVListadoPagos.Columns.ColumnByFieldName("usuario").Width = 90
        MVListadoPagos.Columns.ColumnByFieldName("moneda").Visible = False
        MVListadoPagos.Columns.ColumnByFieldName("cambiomonetario").Visible = False
        MVListadoPagos.Columns.ColumnByFieldName("banderaCobroAFavor").Visible = False

        MVListadoPagos.Columns.ColumnByFieldName("recibo").Caption = "Recibo"
        MVListadoPagos.Columns.ColumnByFieldName("fechacaptura").Caption = "F. Captura"
        MVListadoPagos.Columns.ColumnByFieldName("razonsocial").Caption = "Empresa"
        MVListadoPagos.Columns.ColumnByFieldName("idCliente").Caption = "Id Cliente"
        MVListadoPagos.Columns.ColumnByFieldName("nombreC").Caption = "Cliente"
        MVListadoPagos.Columns.ColumnByFieldName("razonsocialC").Caption = "Razón Social"
        MVListadoPagos.Columns.ColumnByFieldName("Cheques").Caption = "Cheques"
        MVListadoPagos.Columns.ColumnByFieldName("Depositos").Caption = "Depositos"
        MVListadoPagos.Columns.ColumnByFieldName("Efectivo").Caption = "Efectivo"
        MVListadoPagos.Columns.ColumnByFieldName("Ajuste").Caption = "Ajuste"
        MVListadoPagos.Columns.ColumnByFieldName("Total").Caption = "Total"
        MVListadoPagos.Columns.ColumnByFieldName("plazo").Caption = "Plazo CTE."
        MVListadoPagos.Columns.ColumnByFieldName("plazoPago").Caption = "Plazo Real"
        MVListadoPagos.Columns.ColumnByFieldName("estatus").Caption = "Estatus"
        MVListadoPagos.Columns.ColumnByFieldName("fechaCancelacion").Caption = "F. Cancelación"
        MVListadoPagos.Columns.ColumnByFieldName("usuario").Caption = "Usuario"


        MVListadoPagos.Columns.ColumnByFieldName("Cheques").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoPagos.Columns.ColumnByFieldName("Depositos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoPagos.Columns.ColumnByFieldName("Efectivo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoPagos.Columns.ColumnByFieldName("Ajuste").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoPagos.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoPagos.Columns.ColumnByFieldName("plazo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoPagos.Columns.ColumnByFieldName("plazoPago").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        MVListadoPagos.Columns.ColumnByFieldName("Cheques").DisplayFormat.FormatString = "N2"
        MVListadoPagos.Columns.ColumnByFieldName("Depositos").DisplayFormat.FormatString = "N2"
        MVListadoPagos.Columns.ColumnByFieldName("Efectivo").DisplayFormat.FormatString = "N2"
        MVListadoPagos.Columns.ColumnByFieldName("Ajuste").DisplayFormat.FormatString = "N2"
        MVListadoPagos.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"

        MVListadoPagos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


    End Sub

    Private Sub MVListadoPagos_RowStyle(sender As Object, e As RowStyleEventArgs) Handles MVListadoPagos.RowStyle
        If e.RowHandle >= 0 Then
            If IsDBNull(MVListadoPagos.GetRowCellValue(e.RowHandle, "estatus")) = False Then
                If MVListadoPagos.GetRowCellValue(e.RowHandle, "estatus") = "CANCELADO" Then
                    e.Appearance.ForeColor = lblDiseñoCancelado.ForeColor
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVListadoPagos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdClientes.DataSource = Nothing
        grdListadoPagos.DataSource = Nothing
        grdListadoPagos.DataSource = Nothing
        lblFechaUltimaActualización.Text = "-"
        dtpFechaFin.Value = Date.Now.ToString
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        lblTotal.Text = ""
        lblNumFiltrados.Text = ""
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
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

    Private Sub btnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
        Dim listado As New ListadoParametrosProyeccionCobranza
        listado.tipo_busqueda = 4

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAgentes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdAgentes.DataSource = listado.listaParametros
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agentes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnEmpresa_Click(sender As Object, e As EventArgs) Handles btnEmpresa.Click
        Dim listado As New ListadoParametrosProyeccionCobranza
        listado.tipo_busqueda = 5

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdEmpresas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdEmpresas.DataSource = listado.listaParametros
        With grdEmpresas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Empresas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub
    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listaInicial
    End Sub

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listaInicial
    End Sub

    Private Sub btnLimpiarFiltroEmpresa_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroEmpresa.Click
        grdEmpresas.DataSource = listaInicial
    End Sub
    Private Sub grdClientes_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grdAgentes_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        grid_diseño(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agentes"
    End Sub

    Private Sub grdEmpresas_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdEmpresas.InitializeLayout
        grid_diseño(grdEmpresas)
        grdEmpresas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Empresas"
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 28
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 180
    End Sub

    Private Sub calcularTotal()
        Dim totalPlazoReal As Double
        Dim totalPlazoCTE As Double
        Dim registrosSinAjuste As Integer
        total = 0
        totalPesosDolares = 0
        totalPesosDolaresCheques = 0
        totalPesosDolaresDepositos = 0
        totalPesosDolaresEfectivo = 0
        totalDolares = 0

        For index As Integer = 0 To MVListadoPagos.DataRowCount Step 1
            If MVListadoPagos.GetRowCellValue(index, "estatus") <> "CANCELADO" And MVListadoPagos.GetRowCellValue(index, "moneda") = "1" Then
                total += MVListadoPagos.GetRowCellValue(index, "Total")
                totalCheques += MVListadoPagos.GetRowCellValue(index, "Cheques")
                totalDepositos += MVListadoPagos.GetRowCellValue(index, "Depositos")
                totalEfectivo += MVListadoPagos.GetRowCellValue(index, "Efectivo")
            End If
            If MVListadoPagos.GetRowCellValue(index, "estatus") <> "CANCELADO" And MVListadoPagos.GetRowCellValue(index, "moneda") = "2" Then
                Dim conversionPesosDolares As Double
                Dim conversionPesosDolaresCheques As Double
                Dim conversionPesosDolaresDepositos As Double
                Dim conversionPesosDolaresEfectivo As Double
                conversionPesosDolares = MVListadoPagos.GetRowCellValue(index, "Total") * MVListadoPagos.GetRowCellValue(index, "cambiomonetario")
                conversionPesosDolaresCheques = MVListadoPagos.GetRowCellValue(index, "Cheques") * MVListadoPagos.GetRowCellValue(index, "cambiomonetario")
                conversionPesosDolaresDepositos = MVListadoPagos.GetRowCellValue(index, "Depositos") * MVListadoPagos.GetRowCellValue(index, "cambiomonetario")
                conversionPesosDolaresEfectivo = MVListadoPagos.GetRowCellValue(index, "Efectivo") * MVListadoPagos.GetRowCellValue(index, "cambiomonetario")
                cambiomonetario = MVListadoPagos.GetRowCellValue(index, "cambiomonetario")
                totalPesosDolares += conversionPesosDolares
                totalPesosDolaresCheques += conversionPesosDolaresCheques
                totalPesosDolaresDepositos += conversionPesosDolaresDepositos
                totalPesosDolaresEfectivo += conversionPesosDolaresEfectivo
                totalDolares += MVListadoPagos.GetRowCellValue(index, "Total")
            End If
            If MVListadoPagos.GetRowCellValue(index, "Ajuste") = "0" Or MVListadoPagos.GetRowCellValue(index, "banderaCobroAFavor") = "0" Then
                totalPlazoReal += MVListadoPagos.GetRowCellValue(index, "plazoPago")
                totalPlazoCTE += MVListadoPagos.GetRowCellValue(index, "plazo")
                registrosSinAjuste += 1
            End If
        Next

        promedioCTE = totalPlazoCTE / registrosSinAjuste
        promedioReal = totalPlazoReal / registrosSinAjuste
        totalCheques = totalCheques + totalPesosDolaresCheques
        totalDepositos = totalDepositos + totalPesosDolaresDepositos
        totalEfectivo = totalEfectivo + totalPesosDolaresEfectivo
        granTotal = total + totalPesosDolares
        lblTotal.Text = granTotal.ToString("N2")

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        Dim objBU As New ConsultaDocumentosBU
        Dim RecibosdePago As New DataSet("RecibosdePago")
        Dim dtObtieneInfoReportePagos As New DataTable("ListadodeRecibos")
        Dim RutaMovimiento As String = String.Empty
        Dim fechaInicio As Date
        Dim fechaFin As Date

        Try
            Cursor = Cursors.WaitCursor

            fechaInicio = CDate(dtpFechaInicio.Value.ToShortDateString)
            fechaFin = CDate(dtpFechaFin.Value.ToShortDateString)
            RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments


            If MVListadoPagos.DataRowCount > 0 Then
                Dim objBUReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes

                dtObtieneInfoReportePagos = objBU.ObtieneInformacionReportePagos(FClientes, FAgentes, FEmpresas, fechaInicio, fechaFin, 0)

                RecibosdePago.Tables.Add(dtObtieneInfoReportePagos)

                EntidadReporte = objBUReporte.LeerReporteporClave("COBR_RECIBOS_PAGO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                Dim reporte As New StiReport()

                reporte.Load(archivo)
                reporte.Compile()
                reporte("RecibosdePago") = "RecibosdePago"
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("fecha") = FormatDateTime(Date.Now, vbLongDate).ToString()
                reporte("fechaInicio") = FormatDateTime(fechaInicio, vbShortDate).ToString()
                reporte("fechaFin") = FormatDateTime(fechaFin, vbShortDate).ToString()
                reporte("total") = total
                reporte("promedioCTE") = promedioCTE
                reporte("promedioReal") = promedioReal
                reporte("totalDolares") = totalDolares
                reporte("cambiomonetario") = cambiomonetario
                reporte("totalDolaresPesos") = totalPesosDolares
                reporte("totalPesosCheques") = totalCheques
                reporte("totalPesosDepositos") = totalDepositos
                reporte("totalPesosEfectivo") = totalEfectivo
                reporte("granTotal") = granTotal

                reporte.Dictionary.Clear()
                reporte.RegData(RecibosdePago)
                reporte.Dictionary.Synchronize()
                reporte.Render()
                formatoExcel.ExportObjectFormatting = True
                StiOptions.Export.Excel.ShowGridLines = False

                Dim FechaGeneracionExcel As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString
                reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Listado de Recibos de Pago " + FechaGeneracionExcel + ".xls")
                reporte.Dispose()

                show_message("Exito", "Los datos se exportaron correctamente: " + RutaMovimiento + "\Listado de Recibos de Pago " + FechaGeneracionExcel + ".xls")
            Else
                show_message("Advertencia", "No tienes recibos de pago filtrados")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim objBU As New ConsultaDocumentosBU
        Dim RecibosdePago As New DataSet("RecibosdePago")
        Dim dtObtieneInfoReportePagos As New DataTable("ListadodeRecibos")
        Dim RutaMovimiento As String = String.Empty
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim tipoReporte As Integer
        Try
            Cursor = Cursors.WaitCursor

            fechaInicio = CDate(dtpFechaInicio.Value.ToShortDateString)
            fechaFin = CDate(dtpFechaFin.Value.ToShortDateString)
            RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments


            If MVListadoPagos.DataRowCount > 0 Then
                Dim objBUReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                tipoReporte = 1

                dtObtieneInfoReportePagos = objBU.ObtieneInformacionReportePagos(FClientes, FAgentes, FEmpresas, fechaInicio, fechaFin, tipoReporte)

                RecibosdePago.Tables.Add(dtObtieneInfoReportePagos)

                EntidadReporte = objBUReporte.LeerReporteporClave("COBR_RECIBOS_PAGO_PDF")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                Dim reporte As New StiReport()


                reporte.Load(archivo)
                reporte.Compile()
                reporte("RecibosdePago") = "RecibosdePago"
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("fecha") = FormatDateTime(Date.Now, vbLongDate).ToString()
                reporte("fechaInicio") = FormatDateTime(fechaInicio, vbShortDate).ToString()
                reporte("fechaFin") = FormatDateTime(fechaFin, vbShortDate).ToString()
                reporte("total") = total
                reporte("promedioCTE") = promedioCTE
                reporte("promedioReal") = promedioReal
                reporte("totalDolares") = totalDolares
                reporte("cambiomonetario") = cambiomonetario
                reporte("totalDolaresPesos") = totalPesosDolares
                reporte("totalPesosCheques") = totalCheques
                reporte("totalPesosDepositos") = totalDepositos
                reporte("totalPesosEfectivo") = totalEfectivo
                reporte("granTotal") = granTotal

                'reporte("fechalarga") = Date.Now.ToLongDateString().ToString()

                reporte.Dictionary.Clear()
                reporte.RegData(RecibosdePago)
                reporte.Dictionary.Synchronize()
                reporte.Render()
                reporte.Show()
            Else
                show_message("Advertencia", "No tienes recibos de pago filtrados")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
