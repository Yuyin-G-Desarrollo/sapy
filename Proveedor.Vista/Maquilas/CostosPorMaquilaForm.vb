Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Proveedores.BU
Imports Tools
Public Class CostosPorMaquilaForm
    Public Const REPORTE_POR_NAVE As Integer = 1
    Public Const REPORTE_POR_GRUPO As Integer = 2
    Public Const REPORTE_GENERAL As Integer = 3

    Dim tipoReporte As Integer

    Private Sub CostosPorMaquilaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tipoReporte = REPORTE_POR_NAVE

        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        Dim numeroSemanas As Int32 = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
        numeroSemanas = numeroSemanas - 1
        lblNumeroSemana.Text = numeroSemanas
        lblNumeroSemana.Visible = True
        nudAño.Value = DatePart(DateInterval.Year, Now)
        nudSemanaInicio.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1) - 1
        nudSemanaFinal.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1) - 1
        If rdoGeneral.Checked = True Then
            cmbAgrupaNaves.Visible = False
            lblNave.Visible = False
        End If
        LblTipoReporte.Visible = False
        'rdoGeneral.Checked = False
    End Sub

    Private Sub bntCerrar_Click(sender As Object, e As EventArgs) Handles bntCerrar.Click
        Me.Close()
    End Sub
    Private Sub CargarGruposCombobox()
        Dim lstNaves As New DataTable
        Dim strGrupo As String = String.Empty
        Dim objObtenerNaves As New ReporteCostosMaquilasGruposBU
        If rdoGeneral.Checked Then
            cmbAgrupaNaves.Text = Nothing
            cmbAgrupaNaves.DataSource = Nothing
        Else
            If rdoFVO.Checked Then
                strGrupo = "FVO"
            ElseIf rdoRVO.Checked Then
                strGrupo = "RVO"
            End If
            lstNaves = objObtenerNaves.ConsultaNavesPorGrupos(strGrupo)
            cmbAgrupaNaves.DataSource = lstNaves
            cmbAgrupaNaves.ValueMember = "naveid"
            cmbAgrupaNaves.DisplayMember = "nave"
            cmbAgrupaNaves.SelectedIndex = 0
        End If
    End Sub

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        Dim semana = If(CDate("31/12/" + Date.Now.Year.ToString).DayOfYear = 365, 52, 53) 'numero de semanas x año
        nudSemanaInicio.Maximum = semana
        'nudSemanaFinal.Maximum = semana
    End Sub

    Private Sub rdoRVO_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRVO.CheckedChanged, rdoFVO.CheckedChanged, rdoGeneral.CheckedChanged
        grdReporteCostosNaves.DataSource = Nothing
        bgvReportesMaquilasCostos.Columns.Clear()
        bgvReportesMaquilasCostos.Bands.Clear()
        LblTipoReporte.Text = Nothing
        LblTipoReporte.Visible = False
        If rdoFVO.Checked = True Or rdoRVO.Checked = True Then
            cmbAgrupaNaves.Visible = True
            lblNave.Visible = True
            CargarGruposCombobox()
        ElseIf rdoGeneral.Checked = True Then
            cmbAgrupaNaves.Text = Nothing
            cmbAgrupaNaves.Visible = False
            lblNave.Visible = False
        End If
    End Sub
    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
        Try
            Cursor = Cursors.WaitCursor
            grdReporteCostosNaves.DataSource = Nothing
            bgvReportesMaquilasCostos.Columns.Clear()
            bgvReportesMaquilasCostos.Bands.Clear()
            LblTipoReporte.Text = Nothing
            LblTipoReporte.Visible = False
            If cmbAgrupaNaves.Text.Contains("-TOTAL") Then
                tipoReporte = REPORTE_POR_GRUPO
            ElseIf rdoGeneral.Checked = True Then
                tipoReporte = REPORTE_GENERAL
            End If
            seguimientoReportes(tipoReporte)
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & ex.ToString)
        Finally
            Cursor = Cursors.Default
            lblFechaActualizacion.Text = Now
            lblFechaActualizacion.Visible = True
        End Try
    End Sub
    ''' <summary>
    ''' obtiene la naves dependiendo el grupo que el usuario seleccione ("RVO / FVO")
    ''' </summary>
    Private Sub ObtenerReportePorNaves()
        Dim DatosNaves As New Entidades.CostosPorMaquilaNavesGrupos
        Dim objReporteNave As New ReporteCostosMaquilasGruposBU
        Dim dtReporteNave As New DataTable
        DatosNaves.cpmanio = nudAño.Value
        DatosNaves.cpmsemanaInicio = nudSemanaInicio.Value
        DatosNaves.cpmsemanaFinal = nudSemanaFinal.Value
        DatosNaves.cpmIdNave = cmbAgrupaNaves.SelectedValue
        dtReporteNave = objReporteNave.ObtenerReportePorNave(DatosNaves)
        If dtReporteNave.Rows.Count = 0 Then
            Dim objadvertencias As New Tools.AdvertenciaForm
            objadvertencias.mensaje = "No existe información para mostrar."
            objadvertencias.ShowDialog()
            grdReporteCostosNaves.DataSource = Nothing
            bgvReportesMaquilasCostos.Columns.Clear()
            Dim band As New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Else
            grdReporteCostosNaves.DataSource = dtReporteNave
            diseñoGridReportePorNaves()
        End If
    End Sub

    Private Sub diseñoGridReportePorNaves()
        Dim contadorColor As Integer = 1
        Dim lstDatos As New List(Of Object)
        bgvReportesMaquilasCostos.Columns.Clear()
        bgvReportesMaquilasCostos.Bands.Clear()

        Dim bandaNave As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        bandaNave = bgvReportesMaquilasCostos.Bands.Add
        bandaNave.Caption = "PRODUCCIÓN PLANTA " & cmbAgrupaNaves.Text

        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        bgvReportesMaquilasCostos.Appearance.HeaderPanel.Options.UseBackColor = True

        band = bandaNave.Children.Add()
        band.Caption = Nothing
        bgvReportesMaquilasCostos.Columns.AddField("semana")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("semana").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("semana").Visible = True
        bgvReportesMaquilasCostos.Columns("semana").Width = 40
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("semana").Caption = "SEM"

        bgvReportesMaquilasCostos.Columns.AddField("paresProducidos")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("paresProducidos").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("paresProducidos").Visible = True
        bgvReportesMaquilasCostos.Columns("paresProducidos").Width = 105
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("paresProducidos").Caption = "PARES" + vbCrLf + "PRODUCIDOS"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("paresProducidos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("paresProducidos").DisplayFormat.FormatString = "{0:N0}"

        'bgvReportesMaquilasCostos.Bands.Add(band)       
        band = bandaNave.Children.Add()
        band.Caption = "IMPORTE"
        bgvReportesMaquilasCostos.Columns.AddField("compra")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("compra").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("compra").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("compra").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("compra").DisplayFormat.FormatString = "{0:N0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("compra").Caption = "COMPRA"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("compra").AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)

        bgvReportesMaquilasCostos.Columns.AddField("venta")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("venta").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("venta").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("venta").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("venta").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns("venta").Width = 95
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("venta").Caption = "VENTA"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("venta").AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)

        bgvReportesMaquilasCostos.Columns.AddField("precioventaporpar")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("precioventaporpar").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("precioventaporpar").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("precioventaporpar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("precioventaporpar").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("precioventaporpar").Caption = "POR PAR"
        bgvReportesMaquilasCostos.Columns("precioventaporpar").Width = 63
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("precioventaporpar").AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)

        ' bgvReportesMaquilasCostos.Bands.Add(band)

        band = bandaNave.Children.Add()
        band.Caption = "UTILIDAD BRUTA"
        bgvReportesMaquilasCostos.Columns.AddField("utilidadbrutatotal")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutatotal").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutatotal").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutatotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutatotal").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutatotal").Caption = "TOTAL"

        bgvReportesMaquilasCostos.Columns.AddField("utilidadbrutaporpar")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutaporpar").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutaporpar").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutaporpar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutaporpar").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadbrutaporpar").Caption = "POR PAR"
        bgvReportesMaquilasCostos.Columns("utilidadbrutaporpar").Width = 75

        bgvReportesMaquilasCostos.Columns.AddField("utilidadporporcentaje")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadporporcentaje").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadporporcentaje").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadporporcentaje").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadporporcentaje").DisplayFormat.FormatString = "{0:N0}%"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadporporcentaje").Caption = "%"
        bgvReportesMaquilasCostos.Columns("utilidadporporcentaje").Width = 40

        'bgvReportesMaquilasCostos.Bands.Add(band)        
        band = bandaNave.Children.Add()
        band.Caption = Nothing
        bgvReportesMaquilasCostos.Columns.AddField("isr")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("isr").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("isr").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("isr").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("isr").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("isr").Caption = "ISR" + vbCrLf
        bgvReportesMaquilasCostos.Columns("isr").Width = 80
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("isr").AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)

        bgvReportesMaquilasCostos.Columns.AddField("dd_herramental")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("dd_herramental").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("dd_herramental").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("dd_herramental").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("dd_herramental").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("dd_herramental").Caption = "D & D Y" + vbCrLf + "HERRAMENTAL"
        bgvReportesMaquilasCostos.Columns("dd_herramental").Width = 115
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("dd_herramental").AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)

        bgvReportesMaquilasCostos.Columns.AddField("financiamiento")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("financiamiento").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("financiamiento").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("financiamiento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("financiamiento").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("financiamiento").Caption = "FINANCIAMIENTO" + vbCrLf + "RIESGO"
        bgvReportesMaquilasCostos.Columns("financiamiento").Width = 150
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("financiamiento").AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)
        'bgvReportesMaquilasCostos.Bands.Add(band)

        band = bandaNave.Children.Add()
        band.Caption = "UTILIDAD NETA"
        bgvReportesMaquilasCostos.Columns.AddField("utilidadnetatotal")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetatotal").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetatotal").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetatotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetatotal").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetatotal").Caption = "TOTAL"

        bgvReportesMaquilasCostos.Columns.AddField("utilidadnetaporpar")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporpar").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporpar").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporpar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporpar").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporpar").Caption = "POR PAR"
        bgvReportesMaquilasCostos.Columns("utilidadnetaporpar").Width = 60

        bgvReportesMaquilasCostos.Columns.AddField("utilidadnetaporporcentaje")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporporcentaje").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporporcentaje").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporporcentaje").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporporcentaje").DisplayFormat.FormatString = "{0:N0}%"
        bgvReportesMaquilasCostos.Columns("utilidadnetaporporcentaje").Width = 60
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaporporcentaje").Caption = "%"

        bgvReportesMaquilasCostos.Columns.AddField("utilidadnetafabrica")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetafabrica").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetafabrica").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetafabrica").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetafabrica").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetafabrica").Caption = "FÁBRICA"

        bgvReportesMaquilasCostos.Columns.AddField("utilidadnetaadministracion")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaadministracion").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaadministracion").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaadministracion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaadministracion").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetaadministracion").Caption = "ADMON"

        bgvReportesMaquilasCostos.Columns.AddField("utilidadnetacomercial")
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetacomercial").OwnerBand = band
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetacomercial").Visible = True
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetacomercial").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetacomercial").DisplayFormat.FormatString = "{0:C0}"
        bgvReportesMaquilasCostos.Columns.ColumnByFieldName("utilidadnetacomercial").Caption = "COMERCIAL"

        'bgvReportesMaquilasCostos.Bands.Add(band)

        bgvReportesMaquilasCostos.OptionsView.AllowCellMerge = False
        bgvReportesMaquilasCostos.OptionsBehavior.Editable = False
        bgvReportesMaquilasCostos.OptionsView.ShowFooter = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvReportesMaquilasCostos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If Not col.FieldName.ToUpper.Contains("SEMANA") Then
                If Not col.FieldName.Contains("%") And col.FieldName <> "precioventaporpar" And
                    col.FieldName <> "utilidadbrutaporpar" And col.FieldName <> "utilidadporporcentaje" And
                    col.FieldName <> "utilidadnetaporpar" And col.FieldName <> "utilidadnetaporporcentaje" Then

                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")

                End If

                Select Case col.FieldName
                    Case "precioventaporpar", "utilidadbrutaporpar", "utilidadnetaporpar"
                        col.Summary.Add(DevExpress.Data.SummaryItemType.Custom, col.FieldName, "${0:C0}")
                    Case "utilidadporporcentaje", "utilidadnetaporporcentaje"
                        col.Summary.Add(DevExpress.Data.SummaryItemType.Custom, col.FieldName, "{0:N0}%")
                    Case Else
                        col.Summary.Add(DevExpress.Data.SummaryItemType.Custom, col.FieldName, "{0:N0}")
                End Select

            End If
        Next

        ''CENTRA LOS BANDS
        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReportesMaquilasCostos.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            gridband.OptionsBand.AllowMove = False
            For Each childrenBand In gridband.Children
                childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next
        Next

        'CENTRA LOS ENCABEZADOS DE LAS COLUMNAS
        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReportesMaquilasCostos.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next
        bgvReportesMaquilasCostos.IndicatorWidth = 30 ''TAMAÑO DEL INDICADOR        
    End Sub

    ''' <summary>
    ''' PerfomClick indica el evento click de cualquier boton
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbAgrupaNaves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAgrupaNaves.SelectedIndexChanged
        If IsNumeric(cmbAgrupaNaves.SelectedValue) Then
            tipoReporte = REPORTE_POR_NAVE
            BtnMostrar.PerformClick()
        End If
    End Sub
    Private Sub seguimientoReportes(ByVal tipoReporte As Integer)
        grdReporteCostosNaves.DataSource = Nothing
        If tipoReporte = REPORTE_POR_NAVE Then ''REPORTE X NAVES
            ObtenerReportePorNaves()
        ElseIf tipoReporte = REPORTE_POR_GRUPO Then 'reporte total x grupos (RVO, FVO)
            ObtenerReporteTotalPorGrupo()
        ElseIf tipoReporte = REPORTE_GENERAL Then ''reporte general
            obtenerReporteCostosGeneral()
        End If
    End Sub

    Private Sub ObtenerReporteTotalPorGrupo()
        Dim DatosGrupo As New Entidades.CostosPorMaquilaNavesGrupos
        Dim objReporteGrupos As New ReporteCostosMaquilasGruposBU
        Dim dtReporteGrupos As New DataTable
        Dim spid As Integer = 0
        DatosGrupo.cpmanio = nudAño.Value
        DatosGrupo.cpmsemanaInicio = nudSemanaInicio.Value
        DatosGrupo.cpmsemanaFinal = nudSemanaFinal.Value
        If cmbAgrupaNaves.Text = "FVO-TOTAL" Then
            DatosGrupo.cpmgrupo = "FVO"
        Else
            DatosGrupo.cpmgrupo = "RVO"
        End If
        dtReporteGrupos = objReporteGrupos.obtenerReporteTotalPorGrupos(DatosGrupo)

        If dtReporteGrupos.Rows.Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No existe información para mostrar.")
        Else
            grdReporteCostosNaves.DataSource = dtReporteGrupos
            spid = Integer.Parse(dtReporteGrupos.Rows(0).Item("spid").ToString())
            diseñoGridReporteTotalGrupos(DatosGrupo, spid)
        End If
    End Sub
    Private Sub diseñoGridReporteTotalGrupos(ByVal datosGrupo As Entidades.CostosPorMaquilaNavesGrupos, ByVal spid As Integer)
        Dim objBU As New ReporteCostosMaquilasGruposBU
        Dim listBandsEncabezados As New List(Of String)
        Dim lstColumnaPadre As New List(Of String)
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim listaBandHijos As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim NombreEncabezadoBandas As New List(Of String)
        Dim ObjEntidad As New Entidades.CostosPorMaquilaNavesGrupos
        Dim dtEncabezados As New System.Data.DataTable
        dtEncabezados = objBU.obtenerEncabezadosTablasReporteNaves(datosGrupo, tipoReporte, spid)
        bgvReportesMaquilasCostos.OptionsView.ColumnAutoWidth = False
        bgvReportesMaquilasCostos.Columns.Clear()
        bgvReportesMaquilasCostos.Bands.Clear()
        grdReporteCostosNaves.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporteCostosNaves.LookAndFeel.UseDefaultLookAndFeel = False


        Dim listaPrimerEncabezado = dtEncabezados.AsEnumerable().Where(Function(x) x.Item("columnaorigen") = "" Or x.Item("columnaorigen") = "SEMANA").OrderBy(Function(y) y.Item("ordencolumna"))
        Dim cadena As String = ""

        For Each EncabezadoItem As DataRow In listaPrimerEncabezado
            band = bgvReportesMaquilasCostos.Bands.Add
            cadena = EncabezadoItem.Item("titulo")
            band.Caption = cadena.Trim()

            NombreEncabezadoBandas.Add(cadena)

            listBands.Add(band)
            Dim ListaBandaHijo = dtEncabezados.AsEnumerable().Where(Function(x) x.Item("columnapadre") = cadena And x.Item("columnaorigen") <> "").OrderBy(Function(y) y.Item("ordencolumna"))
        Next

        Dim BandaAux As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        For Each row As DataRow In dtEncabezados.Rows
            '' PONE LA FIELDNAME EN LOS BANDS
            Dim columnas As String = row.Item("columnaorigen") '' columna para saber de donde viene el registro de origen 
            Dim columnaPadre As String = row.Item("columnapadre") '' columna que lleva el texto principal (subtemas)
            If columnas <> "" Then
                BandaAux = listBands.AsEnumerable().FirstOrDefault(Function(x) x.Caption = row.Item("columnapadre")) ''se quita bandparent xk solo cuenta con 2 niveles
                bgvReportesMaquilasCostos.Columns.AddField(row.Item("columnaorigen").ToString().ToUpper) ''TOUPPER HACE UNA COMPARACION A LAS MAYUSCULAS
                bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).OwnerBand = BandaAux
                bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).Visible = True
                bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).Caption = row.Item("titulo")
                bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:N0}"

                If row.Item("columnaorigen").ToString().ToUpper.Contains("PRS") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:N0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("UTB") Or row.Item("columnaorigen").ToString().ToUpper.Contains("UXP") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}" '' "{0:c0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("%") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:N0}%"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("DEDUCC") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("TOTAL") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("UTILIDAD NETA FABRICA") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("COMERCIAL") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                End If
            End If

            If lstColumnaPadre.Contains(columnaPadre) = False Then
                lstColumnaPadre.Add(columnaPadre)
            End If

            If lstColumnaPadre.Count Mod 2 = 0 Then
                If columnas <> "" Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)
                End If
            End If

        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReportesMaquilasCostos.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReportesMaquilasCostos.Columns
            If Col.FieldName = "SEMANA" Then
                Col.Width = 58
            End If
            If Col.FieldName = "UTILIDAD NETA %" Then
                Col.Width = 50
            End If
        Next
        LblTipoReporte.Text = "PRODUCCION " & " " & datosGrupo.cpmgrupo & " " & nudAño.Value
        LblTipoReporte.Visible = True
        bgvReportesMaquilasCostos.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        bgvReportesMaquilasCostos.Bands(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        ObjEntidad.cpmMsgResult = objBU.EliminarEncabezadosReportesGrupos(datosGrupo, tipoReporte, spid) ''ELIMINA LOS ENCABEZADOS DE LA TABLA
        totalizaciones()
    End Sub
    Private Sub totalizaciones()
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem

        For Each vColumna As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReportesMaquilasCostos.Columns
            If Not vColumna.FieldName.Contains("SEMANA") And Not vColumna.FieldName.Contains("%") And Not vColumna.FieldName.Contains("UXP") Then
                If vColumna.FieldName.Contains("PRS") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                Else
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:C0}")
                End If

            ElseIf vColumna.FieldName.Contains("%") Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N0}%")

            ElseIf vColumna.FieldName.Contains("UXP") Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "${0:C0}")

            End If

            item = New DevExpress.XtraGrid.GridGroupSummaryItem
            item.FieldName = vColumna.FieldName
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReportesMaquilasCostos.GroupSummary.Add(item)
            vColumna.OptionsFilter.AllowFilter = False
        Next
    End Sub
    ''' <summary>
    ''' se obtiene el reporte general de los costos grupos RVO, FVO para despues hacer el diseño y mostrarlos en grdiview los resultados
    ''' </summary>
    Private Sub obtenerReporteCostosGeneral()
        Dim DatosGrupo As New Entidades.CostosPorMaquilaNavesGrupos
        Dim objReporteGral As New ReporteCostosMaquilasGruposBU
        Dim dtReporteGral As New DataTable
        Dim spid As Integer = 0
        DatosGrupo.cpmanio = nudAño.Value
        DatosGrupo.cpmsemanaInicio = nudSemanaInicio.Value
        DatosGrupo.cpmsemanaFinal = nudSemanaFinal.Value
        dtReporteGral = objReporteGral.obtenerReporteGeneral(DatosGrupo)
        If dtReporteGral.Rows.Count > 0 Then
            spid = Integer.Parse(dtReporteGral.Rows(0).Item("spid").ToString())
            diseñoGridReporteGeneral(spid)
            grdReporteCostosNaves.DataSource = dtReporteGral
        End If
    End Sub
    ''' <summary>
    ''' diseño del gridview, para el reporte general de los costos 
    ''' </summary>
    Private Sub diseñoGridReporteGeneral(ByVal spid As Integer)
        Dim objBU As New ReporteCostosMaquilasGruposBU
        Dim listBandsEncabezados As New List(Of String)
        Dim bandaPrimerNivel As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim bandaSegundoNivel As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim listaBandHijos As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim NombreEncabezadoBandas As New List(Of String)
        Dim ObjEntidad As New Entidades.CostosPorMaquilaNavesGrupos
        Dim dtEncabezados As New System.Data.DataTable
        Dim datosGrupos As New Entidades.CostosPorMaquilaNavesGrupos

        datosGrupos.cpmgrupo = ""
        dtEncabezados = objBU.obtenerEncabezadosTablasReporteNaves(datosGrupos, tipoReporte, spid)
        'bgvReportesMaquilasCostos.OptionsView.AllowCellMerge = True
        bgvReportesMaquilasCostos.OptionsView.ColumnAutoWidth = False
        bgvReportesMaquilasCostos.Columns.Clear()
        bgvReportesMaquilasCostos.Bands.Clear()
        grdReporteCostosNaves.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporteCostosNaves.LookAndFeel.UseDefaultLookAndFeel = False

        Dim PrimerEncabezado = dtEncabezados.AsEnumerable().Where(Function(x) x.Item("ColumnaPrincipal") <> "").Select(Function(y) y.Item("ColumnaPrincipal")).Distinct
        Dim cadenaPrimerEncabezado As String = Nothing

        For Each tituloEncabezado As String In PrimerEncabezado
            cadenaPrimerEncabezado = tituloEncabezado & " " & nudAño.Value
            bandaPrimerNivel = bgvReportesMaquilasCostos.Bands.Add
            bandaPrimerNivel.Caption = cadenaPrimerEncabezado.Trim()
            listBands.Add(bandaPrimerNivel)

            Dim listaPrimerEncabezado = dtEncabezados.AsEnumerable().Where(Function(x) x.Item("columnaorigen") = "" Or x.Item("columnaorigen") = "SEMANA").OrderBy(Function(y) y.Item("ordencolumna"))
            Dim cadena As String = ""

            For Each EncabezadoItem As DataRow In listaPrimerEncabezado
                bandaSegundoNivel = bandaPrimerNivel.Children.Add
                cadena = EncabezadoItem.Item("titulo")
                bandaSegundoNivel.Caption = cadena.Trim()

                NombreEncabezadoBandas.Add(cadena)

                listBands.Add(bandaSegundoNivel)
            Next
        Next
        ''SE AGREGAN LOS VALORES A LOS ENCABEZADOS PRINCIPALES
        Dim BandaAux As DevExpress.XtraGrid.Views.BandedGrid.GridBand

        For Each row As DataRow In dtEncabezados.Rows
            Dim columnas As String = row.Item("columnaorigen") '' columna para saber de donde viene el registro de origen 
            Dim columnaPadre As String = row.Item("columnapadre") '' columna que lleva el texto principal (subtemas)

            If columnas <> "" Then
                BandaAux = listBands.AsEnumerable().FirstOrDefault(Function(x) x.Caption = row.Item("columnapadre")) ''se quita bandparent xk solo cuenta con 2 niveles
                bgvReportesMaquilasCostos.Columns.AddField(row.Item("columnaorigen").ToString().ToUpper) ''TOUPPER HACE UNA COMPARACION A LAS MAYUSCULAS
                bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).OwnerBand = BandaAux
                bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).Visible = True
                bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).Caption = row.Item("titulo")
                'bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "N0"

                If row.Item("columnaorigen").ToString().ToUpper.Contains("PRS") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "N0"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("UTB") Or row.Item("columnaorigen").ToString().ToUpper.Contains("UXP") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}" '' "{0:c0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("%") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:N0}%"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("DEDUCC") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("UTILIDAD NETA TOTAL") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("RVO") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("FVO") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("UTILIDAD NETA ADMON") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                ElseIf row.Item("columnaorigen").ToString().ToUpper.Contains("COMERCIAL") Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).DisplayFormat.FormatString = "{0:C0}"
                End If
            End If

            '' PINTA COLUMNAS
            If columnaPadre = "TOTAL GENERAL" Or columnaPadre = "TOTAL FVO" Then
                If columnas <> "" And columnas <> "SEMANA" Then
                    bgvReportesMaquilasCostos.Columns.ColumnByFieldName(row.Item("columnaorigen").ToString().ToUpper).AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)
                End If
            End If
        Next

        'bgvReportesMaquilasCostos.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left ''DEJA FIJA LA PRIMER COLUMNA

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReportesMaquilasCostos.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReportesMaquilasCostos.Columns
            If Col.FieldName = "SEMANA" Then
                Col.Width = 56
            End If
            If Col.FieldName = "UTILIDAD NETA %" Then
                Col.Width = 45
            End If
        Next
        LblTipoReporte.Text = "PRODUCCION GENERAL " & " " & nudAño.Value
        LblTipoReporte.Visible = True
        ObjEntidad.cpmMsgResult = objBU.EliminarEncabezadosReportesGrupos(datosGrupos, tipoReporte, spid) ''ELIMINA LOS ENCABEZADOS DE LA TABLA
        totalizaciones()
    End Sub

    ''' <summary>
    ''' INDICA EL NUMERO DE COLUMNAS QUE CONTIENE UN GRIDVIEW (1,2,3 ETC...)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub vwCostosPorMaquila_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs)
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub BtnConfigPorcentaje_Click(sender As Object, e As EventArgs) Handles BtnConfigPorcentaje.Click
        Dim configuracionCostosForm As New ConfiguracionPorcentajesMaquilaForm
        configuracionCostosForm.ShowDialog()
    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub
    ''' <summary>
    ''' hace la exportacion a una hoja de excel
    ''' </summary>
    Private Sub exportarExcel()
        Dim Texto As String
        Dim añoReporte As Integer
        If rdoGeneral.Checked = True Then
            añoReporte = nudAño.Value
        End If
        If bgvReportesMaquilasCostos.DataRowCount > 0 Then
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvReportesMaquilasCostos.Columns
                col.AppearanceHeader.BackColor = Color.LightSkyBlue
            Next
            If rdoGeneral.Checked = True Then
                Tools.Excel.ExportarExcel(bgvReportesMaquilasCostos, "Reporte General Costos Produccion")
            ElseIf rdoFVO.Checked = True Then
                Texto = cmbAgrupaNaves.Text
                Tools.Excel.ExportarExcel(bgvReportesMaquilasCostos, "Reporte de Costos de Produccion planta " + Texto)
            ElseIf rdoRVO.Checked = True Then
                Texto = cmbAgrupaNaves.Text
                Tools.Excel.ExportarExcel(bgvReportesMaquilasCostos, "Reporte de Costos de Produccion planta " + Texto)
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
        End If
    End Sub

    Private Sub bgvReportesMaquilasCostos_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles bgvReportesMaquilasCostos.CustomSummaryCalculate
        Dim view As GridView = sender
        Dim nombrecolumna As String = e.Item.FieldName

        If tipoReporte = REPORTE_GENERAL Or tipoReporte = REPORTE_POR_GRUPO Then
            If (e.SummaryProcess = CustomSummaryProcess.Finalize) Then
                If e.Item.FieldName.Contains("%") Then
                    e.TotalValue = CalcAverage(view, e.Item.FieldName)
                ElseIf e.Item.FieldName.Contains("UXP") Then
                    e.TotalValue = CalcularColumnas(nombrecolumna)
                End If
            End If
        ElseIf tipoReporte = REPORTE_POR_NAVE Then
            If nombrecolumna = "precioventaporpar" Or nombrecolumna = "utilidadbrutaporpar" Or nombrecolumna = "utilidadporporcentaje" Or nombrecolumna = "utilidadnetaporpar" Or nombrecolumna = "utilidadnetaporporcentaje" Then
                e.TotalValue = CalcularColumnas(nombrecolumna)
            Else
                e.TotalValue = CalcAverage(view, e.Item.FieldName)
            End If
        End If

    End Sub

    Private Function CalcAverage(view As GridView, nombrecolumna As String)
        Dim sum As Decimal = 0
        Dim count As Integer = 0
        For index = 0 To view.RowCount
            If Not IsDBNull(view.GetRowCellValue(index, nombrecolumna)) Then
                Dim value = CDec(view.GetRowCellValue(index, nombrecolumna))
                If Not value = 0 Then
                    count += 1
                    sum += value
                End If
            End If
        Next

        Dim resultado = 0
        If Not count = 0 Then
            resultado = sum / count
        End If

        Return resultado
    End Function

    Private Function CalcularColumnas(nombrecolumna As String)
        Dim resultado = ""
        Dim pares As Integer = 0
        Dim utilidadbruta As Decimal = 0

        If nombrecolumna.Contains("UXP") Or nombrecolumna = "precioventaporpar" Or nombrecolumna = "utilidadbrutaporpar" Or nombrecolumna = "utilidadporporcentaje" Or nombrecolumna = "utilidadnetaporpar" Or nombrecolumna = "utilidadnetaporporcentaje" Then
            Dim columnaPares As String = String.Empty
            Dim columnaUtilidadBruta As String = String.Empty

            If nombrecolumna.Contains("UXP") Then
                If nombrecolumna = "UTILIDAD NETA UXP" Then
                    columnaPares = "TOTAL_PRS"
                    columnaUtilidadBruta = "UTILIDAD NETA TOTAL"
                ElseIf nombrecolumna = "TOTAL_GENERAL_UXP" Then
                    columnaPares = "TOTAL_PRS"
                    columnaUtilidadBruta = nombrecolumna.Replace("UXP", "UTB")
                Else
                    columnaPares = nombrecolumna.Replace("UXP", "PRS")
                    columnaUtilidadBruta = nombrecolumna.Replace("UXP", "UTB")
                End If
            ElseIf nombrecolumna = "precioventaporpar" Then
                columnaPares = "paresProducidos"
                columnaUtilidadBruta = "venta"
            ElseIf nombrecolumna = "utilidadbrutaporpar" Then
                columnaPares = "paresProducidos"
                columnaUtilidadBruta = "utilidadbrutatotal"
            ElseIf nombrecolumna = "utilidadporporcentaje" Then
                columnaPares = "venta"
                columnaUtilidadBruta = "utilidadbrutatotal"
            ElseIf nombrecolumna = "utilidadnetaporpar" Then
                columnaPares = "paresProducidos"
                columnaUtilidadBruta = "utilidadnetatotal"
            ElseIf nombrecolumna = "utilidadnetaporporcentaje" Then
                columnaPares = "venta"
                columnaUtilidadBruta = "utilidadnetatotal"
            End If

            pares = CInt(bgvReportesMaquilasCostos.Columns.ColumnByFieldName(columnaPares).SummaryItem.SummaryValue)
            utilidadbruta = CDbl(bgvReportesMaquilasCostos.Columns.ColumnByFieldName(columnaUtilidadBruta).SummaryItem.SummaryValue)

            If pares > 0 Then

                resultado = CInt(utilidadbruta / pares)

                If nombrecolumna.Contains("porcentaje") Then
                    resultado = CInt((utilidadbruta / pares) * 100)
                End If

            End If

        End If

        Return resultado
    End Function




End Class