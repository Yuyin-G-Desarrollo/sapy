Imports DevExpress.Export
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win

Public Class ConsultaProspectaPorMarca

    Public objBU As New Negocios.ProspectaBU
    Public ProspectaID As Integer = -1
    Dim Marcas As String = ""

    Private Sub ConsultaProspectaPorMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarInformacionProspecta()
        LlenarComboMarcas()
        Me.WindowState = FormWindowState.Maximized
        CargarDatos()
    End Sub

    Public Sub CargarInformacionProspecta()
        Dim objProspecta As New Ventas.Negocios.ProspectaBU
        Dim obj As New Entidades.ProspectaInformacion

        obj = objProspecta.CargarInformacionProspecta(ProspectaID)

        If IsNothing(obj) = False Then
            nudNumSemana.Value = obj.NumeroSemana
            nudAño.Value = obj.Año
            dtmFechaInicio.Value = obj.FechaInicio
            dtmFechaFin.Value = obj.FechaFin
            txtStatusProspecta.Text = obj.EstatusProspecta
            nudNumSemana.Enabled = False
            nudAño.Enabled = False
        End If
    End Sub

    Public Sub LlenarComboMarcas()
        Dim dtMarcas As New DataTable
        dtMarcas = objBU.ConsultaMarcas()

        cmbUCMarcas.DataSource = dtMarcas
        cmbUCMarcas.DisplayMember = "Marca"
        cmbUCMarcas.ValueMember = "MarcaID"
    End Sub

    Public Sub SumarColumnas(columna As String, formato As String)
        If IsNothing(bgvProspectaPorMarca.Columns(columna).Summary.FirstOrDefault(Function(x) x.FieldName = columna)) = True Then
            bgvProspectaPorMarca.Columns(columna).Summary.Add(DevExpress.Data.SummaryItemType.Sum, columna, formato)

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = columna
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = formato
            bgvProspectaPorMarca.GroupSummary.Add(item)
        End If
    End Sub

    Public Function ObtenerFechaDia(DiasSumar As Int16)
        Dim fecha As Date = (dtmFechaInicio.Value).AddDays(DiasSumar)
        Dim titulo As String = ""
        If fecha.Month > 9 Then
            titulo = fecha.Day.ToString + "/" + fecha.Month.ToString()
        Else
            titulo = fecha.Day.ToString + "/0" + fecha.Month.ToString()
        End If
        Return titulo
    End Function

    Public Sub DiseñoGrid()
        Try
            'bgvProspectaPorMarca.OptionsView.ColumnAutoWidth = False

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvProspectaPorMarca.Columns
                If col.FieldName <> " " Then
                    col.OptionsColumn.AllowEdit = False
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                End If
            Next

            bgvProspectaPorMarca.Columns.ColumnByFieldName("IDProspecta").Visible = False

            bgvProspectaPorMarca.Columns.ColumnByFieldName("Lunes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Martes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Miércoles").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Jueves").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Viernes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Sábado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            bgvProspectaPorMarca.Columns.ColumnByFieldName("Lunes").DisplayFormat.FormatString = "N0"
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Martes").DisplayFormat.FormatString = "N0"
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Miércoles").DisplayFormat.FormatString = "N0"
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Jueves").DisplayFormat.FormatString = "N0"
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Viernes").DisplayFormat.FormatString = "N0"
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Sábado").DisplayFormat.FormatString = "N0"
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N0"


            bgvProspectaPorMarca.Columns.ColumnByFieldName("Lunes").Caption = "Lunes" + vbCrLf + ObtenerFechaDia(0)
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Martes").Caption = "Martes" + vbCrLf + ObtenerFechaDia(1)
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Miércoles").Caption = "Miércoles" + vbCrLf + ObtenerFechaDia(2)
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Jueves").Caption = "Jueves" + vbCrLf + ObtenerFechaDia(3)
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Viernes").Caption = "Viernes" + vbCrLf + ObtenerFechaDia(4)
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Sábado").Caption = "Sábado" + vbCrLf + ObtenerFechaDia(5)

            SumarColumnas("Lunes", "{0:N0}")
            SumarColumnas("Martes", "{0:N0}")
            SumarColumnas("Miércoles", "{0:N0}")
            SumarColumnas("Jueves", "{0:N0}")
            SumarColumnas("Viernes", "{0:N0}")
            SumarColumnas("Sábado", "{0:N0}")
            SumarColumnas("Total", "{0:N0}")

            bgvProspectaPorMarca.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Atn Clientes").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Concepto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            bgvProspectaPorMarca.IndicatorWidth = 40

            'bgvDocumentos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

            bgvProspectaPorMarca.BestFitColumns()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message.ToString)
        End Try
    End Sub

    Public Sub DiseñoGridTotales()
        Try
            'bgvProspectaPorMarca.OptionsView.ColumnAutoWidth = False

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvTotales.Columns
                If col.FieldName <> " " Then
                    col.OptionsColumn.AllowEdit = False
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                End If
            Next

            bgvTotales.Columns.ColumnByFieldName("ID").Visible = False
            bgvTotales.Columns.ColumnByFieldName("Concepto").Visible = False
            bgvTotales.Columns.ColumnByFieldName("Total Semana").Visible = False

            bgvTotales.Columns.ColumnByFieldName("Lunes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvTotales.Columns.ColumnByFieldName("Martes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvTotales.Columns.ColumnByFieldName("Miércoles").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvTotales.Columns.ColumnByFieldName("Jueves").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvTotales.Columns.ColumnByFieldName("Viernes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvTotales.Columns.ColumnByFieldName("Sábado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            bgvTotales.Columns.ColumnByFieldName("Lunes").DisplayFormat.FormatString = "N0"
            bgvTotales.Columns.ColumnByFieldName("Martes").DisplayFormat.FormatString = "N0"
            bgvTotales.Columns.ColumnByFieldName("Miércoles").DisplayFormat.FormatString = "N0"
            bgvTotales.Columns.ColumnByFieldName("Jueves").DisplayFormat.FormatString = "N0"
            bgvTotales.Columns.ColumnByFieldName("Viernes").DisplayFormat.FormatString = "N0"
            bgvTotales.Columns.ColumnByFieldName("Sábado").DisplayFormat.FormatString = "N0"


            bgvTotales.Columns.ColumnByFieldName("Lunes").Caption = "Lunes" + vbCrLf + ObtenerFechaDia(0)
            bgvTotales.Columns.ColumnByFieldName("Martes").Caption = "Martes" + vbCrLf + ObtenerFechaDia(1)
            bgvTotales.Columns.ColumnByFieldName("Miércoles").Caption = "Miércoles" + vbCrLf + ObtenerFechaDia(2)
            bgvTotales.Columns.ColumnByFieldName("Jueves").Caption = "Jueves" + vbCrLf + ObtenerFechaDia(3)
            bgvTotales.Columns.ColumnByFieldName("Viernes").Caption = "Viernes" + vbCrLf + ObtenerFechaDia(4)
            bgvTotales.Columns.ColumnByFieldName("Sábado").Caption = "Sábado" + vbCrLf + ObtenerFechaDia(5)

            bgvProspectaPorMarca.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Atn Clientes").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvProspectaPorMarca.Columns.ColumnByFieldName("Concepto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            'bgvDocumentos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

            bgvTotales.BestFitColumns()
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", "Error " + ex.Message.ToString)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub CargarDatos()
        Cursor = Cursors.WaitCursor
        grdTotales.DataSource = objBU.ConsultaTotalesMarcas(ProspectaID, Marcas)
        grdProspectaPorMarca.DataSource = objBU.ConsultaProspectaAlmacen_PorMarca(ProspectaID, Marcas)
        DiseñoGrid()
        DiseñoGridTotales()
        lblFechaUltimaActualizacion.Text = DateTime.Now()
        lblNumFiltrados.Text = bgvProspectaPorMarca.DataRowCount.ToString("N0")
        Cursor = Cursors.Default
    End Sub

    Private Sub cmbUCMarcas_ValueChanged(sender As Object, e As EventArgs) Handles cmbUCMarcas.ValueChanged
        Dim dtDatosFiltrados As New DataTable
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing

        datosCombo = Me.cmbUCMarcas.Value
        dtsCmbFiltro = Me.cmbUCMarcas.Items.ValueList

        If Not datosCombo Is Nothing Then
            Dim index As Int32 = -1
            Marcas = ""
            For Each value As Object In datosCombo
                If Marcas = "" Then
                    Marcas += value.ToString
                Else
                    Marcas += "," + value.ToString
                End If
            Next
        Else
            Marcas = String.Empty
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarDatos()
    End Sub

    Private Sub bgvProspectaPorMarca_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvProspectaPorMarca.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvProspectaPorMarca_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles bgvProspectaPorMarca.RowStyle
        Dim residuo As Int16 = e.RowHandle Mod 2
        If residuo = 0 Then
            e.Appearance.BackColor = Color.White
        Else
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Height = 24
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Height = 137
    End Sub

    Private Sub bgvProspectaPorMarca_ColumnFilterChanged(sender As Object, e As EventArgs) Handles bgvProspectaPorMarca.ColumnFilterChanged
        lblNumFiltrados.Text = bgvProspectaPorMarca.DataRowCount.ToString("N0")
    End Sub

    Private Sub bgvTotales_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles bgvTotales.RowStyle
        Dim residuo As Int16 = e.RowHandle Mod 2
        If residuo = 0 Then
            e.Appearance.BackColor = Color.White
        Else
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If bgvProspectaPorMarca.DataRowCount > 0 Then
            Dim fbdUbicacion As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty

            Try
                nombreReporte = "\ProspectaPorMarca"
                With fbdUbicacion
                    .Reset()
                    .Description = "Selecciona una carpeta"
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        Dim exportOptions As New XlsxExportOptionsEx()
                        exportOptions.ExportType = ExportType.DataAware
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                        grdProspectaPorMarca.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        Tools.Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        Process.Start(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If

                End With
            Catch ex As Exception
                Tools.Controles.Mensajes_Y_Alertas("ERROR", "Ocurrió un error: " + ex.Message.ToString)
            End Try
        Else
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No hay datos para exportar")
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As CustomizeCellEventArgs)
        Dim residuo As Int16 = e.RowHandle Mod 2
        If residuo = 0 Then
            e.Formatting.BackColor = Color.White
        Else
            e.Formatting.BackColor = Color.LightSteelBlue
        End If
    End Sub
End Class