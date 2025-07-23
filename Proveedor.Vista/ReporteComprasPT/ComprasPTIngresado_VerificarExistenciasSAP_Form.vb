Imports Tools
Imports Infragistics.Documents.Excel
Imports DevExpress.XtraGrid
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraPrinting

Public Class ComprasPTIngresado_VerificarExistenciasSAP_Form
    Public dtArticulosFaltantesSap As New DataTable
    Public NombreArchivoExcel As String = String.Empty

    Private Sub ComprasPTIngresado_VerificarExistenciasSAP_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cargarComboEmpresas()
        limpiarTablaTemporal()
    End Sub

    Public Sub cargarComboEmpresas()
        Dim objBu As New Ventas.Negocios.CatalogoEmpresasBU
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
    End Sub

    Private Sub btnImportarInventario_Click(sender As Object, e As EventArgs) Handles btnImportarInventario.Click
        Cursor = Cursors.WaitCursor
        btnLimpiar.PerformClick()
        InsertarExcelImportado()
    End Sub

    Private Sub InsertarExcelImportado()
        Dim dtDatosMostarImportados As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim razonsocial As Int16 = 0
        Dim fechaFacturasInicio As Date = dtpFechaInicio.Value
        Dim fechaFacturasFin As Date = dtpfechaFin.Value
        Dim dtArticulosCantidadesSap As New DataTable

        Dim objBU As New Ventas.Negocios.RegistrarInventarioSAPBU

        dtDatosMostarImportados = ImportarExcel()
        If dtDatosMostarImportados.Rows.Count > 0 Then

            'For Each rowDetalle As DataRow In dtDatosMostarImportados.Rows
            '    Dim Id As String = rowDetalle("Id").ToString
            '    Dim existencias As String = rowDetalle("existencias").ToString
            '    objBU.RegistrarInventarioSAP(Id, existencias)
            'Next
            objBU.RegistrarInventarioSAP(dtDatosMostarImportados)
            razonsocial = cmbRazonSocial.SelectedValue
            dtArticulosFaltantesSap = objBU.ObtenerArticulosFaltantesSapEntradas(razonsocial, fechaFacturasInicio, fechaFacturasFin)
            'dtArticulosCantidadesSap = objBU.ObtenerArticulosCantidadesSAP(razonsocial, fechaFacturasInicio, fechaFacturasFin)

            If dtArticulosFaltantesSap.Rows.Count > 0 Then
                lblTotalArticulosFaltantesSAP.Text = dtArticulosFaltantesSap.Rows.Count.ToString
                grdArticulosCompra.DataSource = dtArticulosFaltantesSap
                DisenioGrid()
                lblUltimaActualizacion.Text = Date.Now.ToString
            Else
                lblTotalArticulosFaltantesSAP.Text = "0"
                advertencia.mensaje = "No hay artículos faltantes en SAP"
                advertencia.ShowDialog()
            End If

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DisenioGrid()
        vwReporte.BestFitColumns()
        'vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.IndicatorWidth = 30
        vwReporte.OptionsView.ShowIndicator = True
        vwReporte.OptionsView.RowAutoHeight = True
        vwReporte.OptionsView.ShowAutoFilterRow = True
        'vwReporte.Columns.ColumnByFieldName("Articulo").Caption = "Artículo"
        'vwReporte.Columns.ColumnByFieldName("Solicitados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporte.Columns.ColumnByFieldName("Disponible SAP").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporte.Columns.ColumnByFieldName("A Solicitar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporte.Columns.ColumnByFieldName("Solicitados").DisplayFormat.FormatString = "N0"
        'vwReporte.Columns.ColumnByFieldName("Disponible SAP").DisplayFormat.FormatString = "N0"
        'vwReporte.Columns.ColumnByFieldName("A Solicitar").DisplayFormat.FormatString = "N0"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            '   If col.FieldName.Contains("Solicitados") Or col.FieldName.Contains("Disponible SAP") Or col.FieldName.Contains("A Solicitar") Then
            '        If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Solicitados")) = True And col.FieldName = "Solicitados" Then
            '            col.Summary.Clear()
            '            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            '        End If
            '        If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Disponible SAP")) = True Or col.FieldName = "Disponible SAP" Then
            '            col.Summary.Clear()
            '            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            '        End If
            '        If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "A Solicitar")) = True And col.FieldName = "A Solicitar" Then
            '            col.Summary.Clear()
            '            col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            '        End If
            '    End If
        Next
    End Sub
    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs)
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Public Function ImportarExcel() As DataTable
        Dim advertencia As New AdvertenciaForm
        Dim datosExcel As New DataTable
        Dim NombreArchivo As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumRenglonDataTable As Integer = 0
        Dim NumColumna As Integer = 0
        Dim dtDatosMostarImportados As New DataTable
        Dim NombreColumna As String = ""
        Dim listColumnasEnteros As New List(Of String)

        Try
            Dim hoja As String = "Hoja1$"
            datosExcel = Tools.Excel.LlenarTablaExcelInventarioSAP(hoja, "", NombreArchivo)
            NombreArchivoExcel = NombreArchivo
            Cursor = Cursors.WaitCursor
            If IsNothing(datosExcel) = False Then
                If datosExcel.Rows.Count > 0 Then
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
            Else
                advertencia.mensaje = "No se seleccionó ningún archivo"
                advertencia.ShowDialog()
            End If
        Catch ex As Exception
            advertencia.mensaje = "El nombre del archivo a importar debe iniciar con: Id"
            advertencia.ShowDialog()
        End Try
        Cursor = Cursors.WaitCursor
        Return dtDatosMostarImportados
    End Function


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdArticulosCompra.DataSource = Nothing
        lblTotalArticulosFaltantesSAP.Text = "0"
        limpiarTablaTemporal()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        ExportarExcel_v2()
    End Sub
    Public Sub ExportarExcel_v2()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then

                nombreReporte = "ArticulosFaltantesSAP_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try

    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpfechaFin.Value < dtpFechaInicio.Value Then
            dtpfechaFin.Value = dtpFechaInicio.Value
        End If
        dtpfechaFin.MinDate = dtpFechaInicio.Value
    End Sub

End Class