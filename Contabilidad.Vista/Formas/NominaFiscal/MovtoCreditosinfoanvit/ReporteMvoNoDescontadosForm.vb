Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Infragistics.Win
Imports Stimulsoft.Report

Public Class ReporteMvoNoDescontadosForm

    Private Sub ReporteMvoNoDescontadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboEmpresa()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Height = 43
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Height = 114
    End Sub

    Private Sub chkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodo.CheckedChanged
        If chkPeriodo.Checked Then
            dtpFechaInicio.Enabled = True
            dtpFechaFin.Enabled = True
        Else
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub llenarComboEmpresa()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtEmpresas As New DataTable

        dtEmpresas = objBU.consultarPatronEmpresa()
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa.DataSource = dtEmpresas
                cmbEmpresa.ValueMember = "ID"
                cmbEmpresa.DisplayMember = "PATRON"
            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, lblMostrar.Click
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If validarFiltros() Then
                Dim objMensajeAdv As New Tools.AdvertenciaForm
                Dim objBU As New Negocios.CreditoInfonavitBU
                Dim dtListado As New DataTable

                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim nombre As String = txtNombre.Text
                Dim periodo As Boolean = chkPeriodo.Checked
                Dim fInicio As String = dtpFechaInicio.Value.ToShortDateString
                Dim fFin As String = dtpFechaFin.Value.ToShortDateString

                grdListadoMovimientos.DataSource = Nothing
                dtListado = objBU.consultarListaMovimientosNoDescontados(patronId, nombre, periodo, fInicio, fFin)
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        grdListadoMovimientos.DataSource = dtListado
                        disenioGrid()
                    Else
                        objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                        objMensajeAdv.ShowDialog()
                    End If
                Else
                    objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al obtener el listado de los movimientos de Crédito Infonavit no descontados."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If chkPeriodo.Checked Then
            Dim entFechaInicio As Integer = 0
            Dim entFechaFin As Integer = 0
            entFechaInicio = CInt(dtpFechaInicio.Value.ToString("yyyyMMdd"))
            entFechaFin = CInt(dtpFechaFin.Value.ToString("yyyyMMdd"))

            If entFechaFin < entFechaInicio Then
                objMensajeAdv.mensaje = "La fecha inicial no puede ser mayor a la fecha final del filtro por periodo."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Public Sub disenioGrid()
        With grdListadoMovimientos.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("ColaboradorId").Hidden = True

            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("A. Paterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("A. Materno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nombre(s)").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NSS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Movimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Núm. Crédito").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tipo Descuento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descuento Anterior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descuento Nuevo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Diferencia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Sem. Afectadas").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Fecha Movimiento").Format = "dd/MM/yyyy"
            .Columns("Descuento Anterior").Format = "$##,##0.00"
            .Columns("Descuento Nuevo").Format = "$##,##0.00"
            .Columns("Diferencia").Format = "$##,##0.00"
            .Columns("Total").Format = "$##,##0.00"

            .Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Descuento Anterior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Descuento Nuevo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Diferencia").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Sem. Afectadas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            grdListadoMovimientos.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            '.Columns("Selección").Width = 50

            .Columns("#").CharacterCasing = CharacterCasing.Upper
            .Columns("A. Paterno").CharacterCasing = CharacterCasing.Upper
            .Columns("A. Materno").CharacterCasing = CharacterCasing.Upper
            .Columns("Nombre(s)").CharacterCasing = CharacterCasing.Upper
            .Columns("NSS").CharacterCasing = CharacterCasing.Upper
            .Columns("Fecha Movimiento").CharacterCasing = CharacterCasing.Upper
            .Columns("Núm. Crédito").CharacterCasing = CharacterCasing.Upper
            .Columns("Tipo Descuento").CharacterCasing = CharacterCasing.Upper
            .Columns("Descuento Anterior").CharacterCasing = CharacterCasing.Upper
            .Columns("Descuento Nuevo").CharacterCasing = CharacterCasing.Upper
            .Columns("Diferencia").CharacterCasing = CharacterCasing.Upper
            .Columns("Sem. Afectadas").CharacterCasing = CharacterCasing.Upper
            .Columns("Total").CharacterCasing = CharacterCasing.Upper

            Dim clnSumDescuentoAnt As UltraGridColumn = .Columns("Descuento Anterior")
            Dim clnSumDescuentoNvo As UltraGridColumn = .Columns("Descuento Nuevo")
            Dim clnSumDiferencia As UltraGridColumn = .Columns("Diferencia")
            Dim clnSumSemAfectadas As UltraGridColumn = .Columns("Sem. Afectadas")
            Dim clnSumTotal As UltraGridColumn = .Columns("Total")

            Dim SumDescuentoAnt As SummarySettings = .Summaries.Add("Descuento Anterior", SummaryType.Sum, clnSumDescuentoAnt)
            SumDescuentoAnt.DisplayFormat = "${0:###,###,###,###0.00}"
            SumDescuentoAnt.Appearance.TextHAlign = HAlign.Right

            Dim SumDescuentoNvo As SummarySettings = .Summaries.Add("Descuento Nuevo", SummaryType.Sum, clnSumDescuentoNvo)
            SumDescuentoNvo.DisplayFormat = "${0:###,###,###,###0.00}"
            SumDescuentoNvo.Appearance.TextHAlign = HAlign.Right

            Dim SumDiferencia As SummarySettings = .Summaries.Add("Diferencia", SummaryType.Sum, clnSumDiferencia)
            SumDiferencia.DisplayFormat = "${0:###,###,###,###0.00}"
            SumDiferencia.Appearance.TextHAlign = HAlign.Right

            Dim SumSemAfectadas As SummarySettings = .Summaries.Add("Sem. Afectadas", SummaryType.Sum, clnSumSemAfectadas)
            SumSemAfectadas.DisplayFormat = "{0:###,###,###,###0}"
            SumSemAfectadas.Appearance.TextHAlign = HAlign.Right

            Dim SumTotal As SummarySettings = .Summaries.Add("Total", SummaryType.Sum, clnSumTotal)
            SumTotal.DisplayFormat = "${0:###,###,###,###0.00}"
            SumTotal.Appearance.TextHAlign = HAlign.Right

            .SummaryFooterCaption = "TOTALES"
        End With

        grdListadoMovimientos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListadoMovimientos.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListadoMovimientos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListadoMovimientos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click, lblLimpiar.Click
        limpiarFiltros()
    End Sub

    Private Sub limpiarFiltros()
        cmbEmpresa.SelectedIndex = 0
        txtNombre.Text = String.Empty
        dtpFechaInicio.Value = Now
        dtpFechaFin.Value = Now
        chkPeriodo.Checked = False
        grdListadoMovimientos.DataSource = Nothing
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm

        If grdListadoMovimientos.Rows.Count > 0 Then
            Try
                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                Dim reporte As New StiReport
                EntidadReporte = objReporte.LeerReporteporClave("DESC_NO_APLICADOS")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre & ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                reporte.Load(archivo)
                reporte.Compile()

                Dim dtListado = New DataTable("dtListadoMovimientos")
                With dtListado
                    .Columns.Add("Colaborador")
                    .Columns.Add("NSS")
                    .Columns.Add("FechaMovimiento")
                    .Columns.Add("NumCredito")
                    .Columns.Add("TipoDescuento")
                    .Columns.Add("DescuentoAnterior")
                    .Columns.Add("DescuentoNuevo")
                    .Columns.Add("Diferencia")
                    .Columns.Add("SemAfectadas")
                    .Columns.Add("Total")
                End With

                For Each item As UltraGridRow In grdListadoMovimientos.Rows
                    dtListado.Rows.Add( _
                    item.Cells("A. Paterno").Value.ToString() & " " & item.Cells("A. Materno").Value.ToString() & " " & item.Cells("Nombre(s)").Value.ToString(), _
                    item.Cells("NSS").Value.ToString(), _
                    item.Cells("Fecha Movimiento").Value.ToString(), _
                    item.Cells("Núm. Crédito").Value.ToString(), _
                    item.Cells("Tipo Descuento").Value.ToString(), _
                    item.Cells("Descuento Anterior").Value.ToString(), _
                    item.Cells("Descuento Nuevo").Value.ToString(), _
                    item.Cells("Diferencia").Value.ToString(), _
                    item.Cells("Sem. Afectadas").Value.ToString(), _
                    item.Cells("Total").Value.ToString() _
                    )
                Next

                'reporte("Logo") = credInfonavit.CILogoNave
                reporte("Empresa") = cmbEmpresa.Text
                reporte("UserName") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                If chkPeriodo.Checked Then
                    reporte("Periodo") = "DEL: " & CDate(dtpFechaInicio.Text).ToString("dd/MM/yyyy") & " AL: " & CDate(dtpFechaFin.Text).ToString("dd/MM/yyyy")
                Else
                    reporte("Periodo") = Date.Now.ToString("yyyy")
                End If

                reporte.RegData(dtListado)
                reporte.Show()
                'reporte.Render()
            Catch ex As Exception
                objMensajeError.mensaje = "Error al imprimir."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para imprimir."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click, lblExportar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdListadoMovimientos.Rows.Count > 0 Then
            Try
                Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                Dim archivo As String = String.Empty

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = Windows.Forms.DialogResult.OK Then
                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                        archivo = "Reporte_Movimiento_NoDescontados" & fecha_hora & ".xlsx"
                        gridExcelExporter.Export(Me.grdListadoMovimientos, .SelectedPath & "\" & archivo)
                    End If
                    objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                    objMensajeExito.ShowDialog()
                    .Dispose()
                End With
            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If
    End Sub
End Class