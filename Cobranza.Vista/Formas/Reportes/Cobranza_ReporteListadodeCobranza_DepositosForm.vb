Imports System.Drawing
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Tools

Public Class Cobranza_ReporteListadodeCobranza_DepositosForm
    Dim advertencia As New AdvertenciaForm
    Dim listaInicial As New List(Of String)
    Public FClientes As String = String.Empty

    Private Sub Cobranza_ReporteListadodeCobranza_DepositosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdClientes.DataSource = listaInicial
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
        Dim dtObtieneInfoReporte As New DataTable
        Dim fechaInicio As Date
        Dim fechaFin As Date

        Try

            If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
                advertencia.mensaje = "La fecha inicial no puede ser mayor a la fecha final."
                advertencia.ShowDialog()
                dtpFechaInicio.Focus()
            End If

            fechaInicio = CDate(dtpFechaInicio.Value.ToShortDateString)
            fechaFin = CDate(dtpFechaFin.Value.ToShortDateString)


            grdListadoCobranza.DataSource = Nothing
            MVListadoCobranza.Columns.Clear()
            FClientes = ObtenerFiltrosGrid(grdClientes)

            Cursor = Cursors.WaitCursor


            dtObtieneInfoReporte = objBU.ObtieneInformacionReporte(FClientes, fechaInicio, fechaFin)

            If dtObtieneInfoReporte.Rows.Count > 0 Then
                grdListadoCobranza.DataSource = dtObtieneInfoReporte
                lblFechaUltimaActualización.Text = Date.Now
                lblNumFiltrados.Text = CDbl(MVListadoCobranza.RowCount.ToString()).ToString("n0")
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
        MVListadoCobranza.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVListadoCobranza.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVListadoCobranza.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVListadoCobranza.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVListadoCobranza.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVListadoCobranza.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        MVListadoCobranza.Columns.ColumnByFieldName("CuentaID").Visible = False

        MVListadoCobranza.Columns.ColumnByFieldName("#").Width = 30
        MVListadoCobranza.Columns.ColumnByFieldName("TD").Width = 50
        MVListadoCobranza.Columns.ColumnByFieldName("cte").Width = 150
        MVListadoCobranza.Columns.ColumnByFieldName("clie_razonsocial").Width = 150
        MVListadoCobranza.Columns.ColumnByFieldName("plazo").Width = 40
        MVListadoCobranza.Columns.ColumnByFieldName("IdCadena").Width = 50
        MVListadoCobranza.Columns.ColumnByFieldName("iniciales").Width = 40
        MVListadoCobranza.Columns.ColumnByFieldName("razonsocial").Width = 200
        MVListadoCobranza.Columns.ColumnByFieldName("FechaAplicacion").Width = 90
        MVListadoCobranza.Columns.ColumnByFieldName("Folio").Width = 40
        MVListadoCobranza.Columns.ColumnByFieldName("MontoDeposito").Width = 90
        MVListadoCobranza.Columns.ColumnByFieldName("DetalleDeposito").Width = 250
        MVListadoCobranza.Columns.ColumnByFieldName("ImporteAplicado").Width = 90
        MVListadoCobranza.Columns.ColumnByFieldName("PRP").Width = 40
        MVListadoCobranza.Columns.ColumnByFieldName("Total").Width = 250

        MVListadoCobranza.Columns.ColumnByFieldName("fechaventa").Caption = "F Docto"
        MVListadoCobranza.Columns.ColumnByFieldName("cte").Caption = "Cliente"
        MVListadoCobranza.Columns.ColumnByFieldName("clie_razonsocial").Caption = "R.Social Cliente"
        MVListadoCobranza.Columns.ColumnByFieldName("plazo").Caption = "Plazo"
        MVListadoCobranza.Columns.ColumnByFieldName("IdCadena").Caption = "ID SICY"
        MVListadoCobranza.Columns.ColumnByFieldName("iniciales").Caption = "Agt"
        MVListadoCobranza.Columns.ColumnByFieldName("razonsocial").Caption = "Razón Social"
        MVListadoCobranza.Columns.ColumnByFieldName("FechaAplicacion").Caption = "F Aplicación"
        MVListadoCobranza.Columns.ColumnByFieldName("Folio").Caption = "Recibo"
        MVListadoCobranza.Columns.ColumnByFieldName("MontoDeposito").Caption = "Monto Depósito"
        MVListadoCobranza.Columns.ColumnByFieldName("DetalleDeposito").Caption = "Detalle Depósito"
        MVListadoCobranza.Columns.ColumnByFieldName("ImporteAplicado").Caption = "Monto Aplicado"


        MVListadoCobranza.Columns.ColumnByFieldName("plazo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoCobranza.Columns.ColumnByFieldName("MontoDeposito").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoCobranza.Columns.ColumnByFieldName("ImporteAplicado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVListadoCobranza.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


        MVListadoCobranza.Columns.ColumnByFieldName("MontoDeposito").DisplayFormat.FormatString = "N2"
        MVListadoCobranza.Columns.ColumnByFieldName("ImporteAplicado").DisplayFormat.FormatString = "N2"
        MVListadoCobranza.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"

        MVListadoCobranza.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(MVListadoCobranza.Columns("MontoDeposito").Summary.FirstOrDefault(Function(x) x.FieldName = "MontoDeposito")) = True Then
            MVListadoCobranza.Columns("MontoDeposito").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoDeposito", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "MontoDeposito"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVListadoCobranza.GroupSummary.Add(item)
        End If

        If IsNothing(MVListadoCobranza.Columns("ImporteAplicado").Summary.FirstOrDefault(Function(x) x.FieldName = "ImporteAplicado")) = True Then
            MVListadoCobranza.Columns("ImporteAplicado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ImporteAplicado", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "ImporteAplicado"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVListadoCobranza.GroupSummary.Add(item)
        End If

        If IsNothing(MVListadoCobranza.Columns("Total").Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True Then
            MVListadoCobranza.Columns("Total").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Total"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVListadoCobranza.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVListadoCobranza.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdClientes.DataSource = Nothing
        grdListadoCobranza.DataSource = Nothing
        grdListadoCobranza.DataSource = Nothing
        lblFechaUltimaActualización.Text = "-"
        dtpFechaFin.Value = Date.Now.ToString
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
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

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listaInicial
    End Sub

    Private Sub grdClientes_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If MVListadoCobranza.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = "Cobranza_ConsultaDocumentos_"
            Dim objBU As New Negocios.ConsultaDocumentosBU
            Dim exportOptions = New XlsxExportOptionsEx()

            Try
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta"
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If MVListadoCobranza.GroupCount > 0 Then
                            MVListadoCobranza.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            MVListadoCobranza.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                            'grdReporte.ExportToXlsx()

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If
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
        grbParametros.Height = 30
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 180
    End Sub
End Class