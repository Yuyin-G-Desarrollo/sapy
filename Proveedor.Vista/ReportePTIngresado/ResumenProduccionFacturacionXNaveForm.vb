Imports Tools
Imports Proveedores.BU
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.Data
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Infragistics.Win

Public Class ResumenProduccionFacturacionXNaveForm

    Dim numSemana As Integer
    Dim tabla As New DataTable
    Dim tablaCopia As DataTable

    Private Sub ResumenProduccionFacturacionXNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        'cbxNave = Tools.Controles.ComboNavesSegunUsuario(cbxNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If (Now.Year = 2021) Then
            numSemana = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
            numSemana = numSemana - 1
        Else
            numSemana = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
        End If
        lblNoSemana.Text = numSemana.ToString()
        nudSemanaInicio.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
        nudSemanaFin.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
        nudAnioInicio.Value = DatePart(DateInterval.Year, Now)
        nudAnioFin.Value = DatePart(DateInterval.Year, Now)
        grdVReporte.Columns("NaveIdSAY").Visible = False
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBu As New ResumenProduccionFacturacionNaveBU
        Try
            Cursor = Cursors.WaitCursor
            Dim naves = ObtenerFiltrosGrid(grdNave)
            tabla = objBu.MostrarReporte(nudSemanaInicio.Value, nudAnioInicio.Value, nudSemanaFin.Value, nudAnioFin.Value, naves)
            If tabla.Rows.Count > 0 Then
                tablaCopia = tabla.Copy()
                grdReporte.DataSource = tabla
                disenioGrid()
                calcularTotales()

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay información para mostrar.")
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "Error " + ex.Message)
        End Try
    End Sub

#Region "DiseñiGrid"
    Private Sub disenioGrid()

        ''CREAR BANDA DE ENCABEZADO 1
        Dim band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        If grdVReporte.Bands.Count < 1 Then
            band.Caption = ""
            grdVReporte.Bands.Add(band)
            band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            band.Caption = "Prevendido"
            grdVReporte.Bands.Add(band)
            band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            band.Caption = "Coppel"
            grdVReporte.Bands.Add(band)
            band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            band.Caption = "Andrea"
            grdVReporte.Bands.Add(band)
            band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            band.Caption = "Stock"
            grdVReporte.Bands.Add(band)
            band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            band.Caption = "Facturación por Empresa"
            grdVReporte.Bands.Add(band)
            band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            band.Caption = "TOTAL"
            grdVReporte.Bands.Add(band)
        End If

        'AGREGAR CAMPO DE DATA SOURCE AL ENCABEZADO
        grdVReporte.Columns("NaveIdSAY").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("Nave").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("Tipo").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("Sem").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("Año").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("ParesRecibidos").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("%-Facturado").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("ParesFacturados").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("PrevendidoPares").OwnerBand = grdVReporte.Bands(1)
        grdVReporte.Columns("Prevendido-%").OwnerBand = grdVReporte.Bands(1)
        grdVReporte.Columns("Prevendido-Facturar").OwnerBand = grdVReporte.Bands(1)
        grdVReporte.Columns("Prevendido-Documentar").OwnerBand = grdVReporte.Bands(1)
        grdVReporte.Columns("Coppel-Pares").OwnerBand = grdVReporte.Bands(2)
        grdVReporte.Columns("Coppel-%").OwnerBand = grdVReporte.Bands(2)
        grdVReporte.Columns("Coppel-Facturar").OwnerBand = grdVReporte.Bands(2)
        grdVReporte.Columns("Coppel-Documentar").OwnerBand = grdVReporte.Bands(2)
        grdVReporte.Columns("Andrea-Pares").OwnerBand = grdVReporte.Bands(3)
        grdVReporte.Columns("Andrea-%").OwnerBand = grdVReporte.Bands(3)
        grdVReporte.Columns("Andrea-Facturar").OwnerBand = grdVReporte.Bands(3)
        grdVReporte.Columns("Andrea-Documentar").OwnerBand = grdVReporte.Bands(3)
        grdVReporte.Columns("Stock-Pares").OwnerBand = grdVReporte.Bands(4)
        grdVReporte.Columns("Stock-%").OwnerBand = grdVReporte.Bands(4)
        grdVReporte.Columns("Stock-Facturar").OwnerBand = grdVReporte.Bands(4)
        grdVReporte.Columns("Stock-Documentar").OwnerBand = grdVReporte.Bands(4)
        grdVReporte.Columns("FacturaciónporEmpresa-180Gramos").OwnerBand = grdVReporte.Bands(5)
        grdVReporte.Columns("FacturaciónporEmpresa-FreeLife").OwnerBand = grdVReporte.Bands(5)
        grdVReporte.Columns("FacturaciónporEmpresa-Reedition").OwnerBand = grdVReporte.Bands(5)
        grdVReporte.Columns("Facturado").OwnerBand = grdVReporte.Bands(6)
        grdVReporte.Columns("Replay").OwnerBand = grdVReporte.Bands(0)
        grdVReporte.Columns("%F").OwnerBand = grdVReporte.Bands(6)

        grdVReporte.IndicatorWidth = 40

        'If cbxNave.SelectedValue = 0 Then
        '    grdVReporte.Columns("Nave").Visible = True
        'Else
        '    grdVReporte.Columns("Nave").Visible = False
        'End If

        If nudAnioInicio.Value = nudAnioFin.Value Then
            grdVReporte.Columns("Año").Visible = False
        Else
            grdVReporte.Columns("Año").Visible = True
        End If

        grdVReporte.Columns("Nave").Width = 100
        grdVReporte.Columns("Tipo").Width = 80
        grdVReporte.Columns("Sem").Width = 40
        grdVReporte.Columns("Año").Width = 50
        grdVReporte.Columns("ParesRecibidos").Width = 100
        grdVReporte.Columns("%-Facturado").Width = 100
        grdVReporte.Columns("ParesFacturados").Width = 100
        grdVReporte.Columns("PrevendidoPares").Width = 80
        grdVReporte.Columns("Prevendido-%").Width = 80
        grdVReporte.Columns("Prevendido-Facturar").Width = 80
        grdVReporte.Columns("Prevendido-Documentar").Width = 80
        grdVReporte.Columns("Coppel-Pares").Width = 80
        grdVReporte.Columns("Coppel-%").Width = 80
        grdVReporte.Columns("Coppel-Facturar").Width = 80
        grdVReporte.Columns("Coppel-Documentar").Width = 80
        grdVReporte.Columns("Andrea-Pares").Width = 80
        grdVReporte.Columns("Andrea-%").Width = 80
        grdVReporte.Columns("Andrea-Facturar").Width = 80
        grdVReporte.Columns("Andrea-Documentar").Width = 80
        grdVReporte.Columns("Stock-Pares").Width = 80
        grdVReporte.Columns("Stock-%").Width = 80
        grdVReporte.Columns("Stock-Facturar").Width = 80
        grdVReporte.Columns("Stock-Documentar").Width = 80
        grdVReporte.Columns("FacturaciónporEmpresa-180Gramos").Width = 90
        grdVReporte.Columns("FacturaciónporEmpresa-FreeLife").Width = 90
        grdVReporte.Columns("FacturaciónporEmpresa-Reedition").Width = 90
        grdVReporte.Columns("Facturado").Width = 80
        grdVReporte.Columns("Replay").Width = 80
        grdVReporte.Columns("%F").Width = 80

        For Each banda As DevExpress.XtraGrid.Views.BandedGrid.GridBand In grdVReporte.Bands
            banda.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        Next


        For Each Col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If Col.FieldName.Contains("%") Then
                Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                Col.DisplayFormat.FormatString = "{0:f1} %"

            ElseIf Col.FieldName.ToString <> "Nave" And Col.FieldName.ToString <> "Sem" And Col.FieldName.ToString <> "Año" Then
                Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                Col.DisplayFormat.FormatString = "{0:N0}"
            End If
        Next

        grdVReporte.OptionsView.ShowFooter = True

    End Sub
#End Region

#Region "Validacines Fechas"

    Private Sub nudSemanaInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaInicio.ValueChanged
        If nudSemanaInicio.Value < 19 And nudAnioInicio.Value = 2020 Then
            nudSemanaInicio.Value = 19
        ElseIf (nudSemanaInicio.Value > nudSemanaFin.Value And nudAnioInicio.Value = nudAnioFin.Value) Then
            nudSemanaFin.Value = nudSemanaInicio.Value
        End If
    End Sub

    Private Sub nudSemanaFin_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaFin.ValueChanged
        If (nudSemanaInicio.Value > nudSemanaFin.Value And nudAnioInicio.Value = nudAnioFin.Value) Then
            nudSemanaInicio.Value = nudSemanaFin.Value
        End If
    End Sub

    Private Sub nudAnioInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudAnioInicio.ValueChanged
        If nudAnioInicio.Value > nudAnioFin.Value Then
            nudAnioFin.Value = nudAnioInicio.Value
        End If

        If (nudSemanaInicio.Value > nudSemanaFin.Value And nudAnioInicio.Value = nudAnioFin.Value) Then
            If nudSemanaInicio.Value <= nudSemanaFin.Maximum Then
                nudSemanaFin.Value = nudSemanaInicio.Value
            Else
                nudSemanaFin.Value = nudSemanaFin.Maximum
            End If
        End If

        If nudAnioInicio.Value = 2020 Then
            nudSemanaInicio.Value = 19
        End If
    End Sub

    Private Sub nudAnioFin_ValueChanged(sender As Object, e As EventArgs) Handles nudAnioFin.ValueChanged
        If nudAnioInicio.Value > nudAnioFin.Value Then
            nudAnioInicio.Value = nudAnioFin.Value
            If nudAnioInicio.Value = 2020 Then
                nudSemanaInicio.Value = 19
                nudSemanaFin.Value = 19
            End If
        End If

        If (nudSemanaInicio.Value > nudSemanaFin.Value And nudAnioInicio.Value = nudAnioFin.Value) Then
            If nudSemanaFin.Value <= nudSemanaInicio.Maximum Then
                nudSemanaInicio.Value = nudSemanaFin.Value
            Else
                nudSemanaInicio.Value = nudSemanaInicio.Maximum
            End If
        End If
    End Sub
    Private Sub grdVReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

#End Region

#Region "Clcular Totales Sumary"
    Private Sub calcularTotales()
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem


        If grdVReporte.GroupSummary.Count() = 0 Then
            For Each vColumna As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In grdVReporte.Columns

                vColumna.Summary.Remove(vColumna.SummaryItem)

                If vColumna.FieldName.Contains("ParesRecibidos") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                If vColumna.FieldName.Contains("ParesRecibidos") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                If vColumna.FieldName = "%-Facturado" Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Average, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Average
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                If vColumna.FieldName.Contains("ParesFacturados") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                'PREVENDIDO
                If vColumna.FieldName.Contains("PrevendidoPares") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                If vColumna.FieldName.Contains("Prevendido-%") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Average, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Average
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Prevendido-Facturar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Prevendido-Facturar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Prevendido-Documentar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Prevendido-Documentar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                'COPPEL
                If vColumna.FieldName.Contains("Coppel-Pares") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Coppel-%") Then
                    'vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Average, vColumna.FieldName, "{0:N1}%")
                    'item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    'item.FieldName = vColumna.FieldName
                    'item.SummaryType = DevExpress.Data.SummaryItemType.Average
                    'item.DisplayFormat = "{0}"
                    'grdVReporte.GroupSummary.Add(item)
                    'vColumna.OptionsFilter.AllowFilter = False

                    Dim prueba = grdVReporte.Columns(vColumna.FieldName).SummaryItem
                    prueba.FieldName = vColumna.FieldName
                    prueba.SummaryType = SummaryItemType.Custom
                    prueba.DisplayFormat = "{0:0.0}%"

                End If
                If vColumna.FieldName.Contains("Coppel-Facturar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Coppel-Facturar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Coppel-Documentar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Coppel-Documentar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                'ANDREA
                If vColumna.FieldName.Contains("Andrea-Pares") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Andrea-%") Then
                    'vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Average, vColumna.FieldName, "{0:N1}%")
                    'item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    'item.FieldName = vColumna.FieldName
                    'item.SummaryType = DevExpress.Data.SummaryItemType.Average
                    'item.DisplayFormat = "{0}"
                    'grdVReporte.GroupSummary.Add(item)
                    'vColumna.OptionsFilter.AllowFilter = False

                    Dim prueba = grdVReporte.Columns(vColumna.FieldName).SummaryItem
                    prueba.FieldName = vColumna.FieldName
                    prueba.SummaryType = SummaryItemType.Custom
                    prueba.DisplayFormat = "{0:0.0}%"
                End If
                If vColumna.FieldName.Contains("Andrea-Facturar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Andrea-Facturar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Andrea-Documentar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Andrea-Documentar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                'STROCK
                If vColumna.FieldName.Contains("Stock-Pares") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Stock-%") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Average, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Average
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Stock-Facturar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Stock-Facturar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Stock-Documentar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("Stock-Documentar") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N1}%")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                'FACTURACION POR EMPRESA
                If vColumna.FieldName.Contains("FacturaciónporEmpresa-180Gramos") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("FacturaciónporEmpresa-FreeLife") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If
                If vColumna.FieldName.Contains("FacturaciónporEmpresa-Reedition") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                'TOTAL
                If vColumna.FieldName = "Facturado" Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

                If vColumna.FieldName.Contains("Replay") Then
                    vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                    item = New DevExpress.XtraGrid.GridGroupSummaryItem
                    item.FieldName = vColumna.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0}"
                    grdVReporte.GroupSummary.Add(item)
                    vColumna.OptionsFilter.AllowFilter = False
                End If

            Next

        End If
    End Sub
#End Region

#Region "Exportar Excel"

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim filename As String

        Try
            If grdVReporte.RowCount > 0 Then
                'Ask the user where to save the file to
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True
                If SaveFileDialog.ShowDialog() = DialogResult.OK Then

                    'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
                    grdVReporte.OptionsPrint.AutoWidth = True
                    grdVReporte.OptionsPrint.EnableAppearanceEvenRow = True
                    grdVReporte.OptionsPrint.PrintPreview = True

                    'Set the selected file as the filename
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    'Export the file via inbuild function
                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default

                    grdVReporte.ExportToXlsx(filename, exportOptions)

                    'If the file exists (i.e. export worked), then open it
                    If System.IO.File.Exists(filename) Then
                        Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If DialogResult = Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(filename)
                        End If
                    End If
                End If
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No existen registros para exportar")
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Totales Custom"

    Private Sub grdVReporte_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles grdVReporte.CustomSummaryCalculate
        Dim vE As DevExpress.Data.CustomSummaryEventArgs = e
        Dim ParesRecibidos As String
        Dim ParesFacturados As String
        Dim PrevendidoFacturar As String
        Dim PrevendidoPares As String
        Dim PrevendidoDocumentar As String
        Dim CoppelFacturar As String
        Dim CoppelPares As String
        Dim CoppelDocumentar As String
        Dim StockFacturar As String
        Dim StockPares As String
        Dim StockDocumentar As String
        Dim vNumDividir As Decimal = 0
        Dim vNumDividir2 As Decimal = 0
        Dim vTotal As Decimal = 0

        If e.Item.FieldName.Contains("ParesRecibidos") Then
            ParesRecibidos = e.Item.FieldName
            ParesFacturados = "ParesFacturados"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(ParesFacturados)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(ParesRecibidos)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)

            End If
        End If

        'PREVENDIDO
        If e.Item.FieldName.Contains("Prevendido-Facturar") Then
            PrevendidoFacturar = e.Item.FieldName
            PrevendidoPares = "PrevendidoPares"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(PrevendidoFacturar)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(PrevendidoPares)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)
            End If
        End If
        If e.Item.FieldName.Contains("Prevendido-Documentar") Then
            PrevendidoDocumentar = e.Item.FieldName
            PrevendidoPares = "PrevendidoPares"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(PrevendidoDocumentar)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(PrevendidoPares)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)
            End If
        End If

        'COPPEL
        If e.Item.FieldName.Contains("Coppel-%") Then
            Dim sumParesrecibidos As Decimal = 0
            Dim sumParesrecibidosCoppel As Decimal = 0
            Dim resultado As Decimal = 0
            Dim count As Integer = 0

            For index = 0 To grdVReporte.RowCount
                Dim value = CDec(grdVReporte.GetRowCellValue(index, "ParesRecibidos"))
                If Not value = 0 Then
                    count += 1
                    sumParesrecibidos += value
                End If
            Next

            For index = 0 To grdVReporte.RowCount
                Dim value = CDec(grdVReporte.GetRowCellValue(index, "Coppel-Pares"))
                If Not value = 0 Then
                    count += 1
                    sumParesrecibidosCoppel += value
                End If
            Next

            resultado = sumParesrecibidosCoppel * 100 / sumParesrecibidos
            e.TotalValue = CDbl(resultado)

        End If

        If e.Item.FieldName.Contains("Coppel-Facturar") Then
            CoppelFacturar = e.Item.FieldName
            CoppelPares = "Coppel-Pares"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(CoppelFacturar)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(CoppelPares)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)
            End If
        End If
        If e.Item.FieldName.Contains("Coppel-Documentar") Then
            CoppelDocumentar = e.Item.FieldName
            CoppelPares = "Coppel-Pares"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(CoppelDocumentar)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(CoppelPares)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)
            End If
        End If

        'ANDREA
        If e.Item.FieldName.Contains("Andrea-%") Then
            Dim sumParesrecibidos As Decimal = 0
            Dim sumParesrecibidosAndrea As Decimal = 0
            Dim resultado As Decimal = 0
            Dim count As Integer = 0
            Dim value = 0

            For index = 0 To grdVReporte.RowCount
                If grdVReporte.GetRowCellValue(index, "ParesRecibidos") <> Nothing Then
                    value = CDec(grdVReporte.GetRowCellValue(index, "ParesRecibidos"))
                Else
                    value = 0
                End If

                If Not value = 0 Then
                    count += 1
                    sumParesrecibidos += value
                End If
            Next

            value = 0

            For index = 0 To grdVReporte.RowCount
                If Not IsDBNull(grdVReporte.GetRowCellValue(index, "Andrea-Pares")) Then
                    value = CDec(grdVReporte.GetRowCellValue(index, "Andrea-Pares"))
                Else
                    value = 0
                End If

                If Not value = 0 Then
                    count += 1
                    sumParesrecibidosAndrea += value
                End If
            Next

            resultado = sumParesrecibidosAndrea * 100 / sumParesrecibidos
            e.TotalValue = If(resultado = Nothing, 0, DirectCast(CDbl(resultado), Object))

        End If

        If e.Item.FieldName.Contains("Andrea-Facturar") Then
            CoppelFacturar = e.Item.FieldName
            CoppelPares = "Andrea-Pares"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer?)(CoppelFacturar)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer?)(CoppelPares)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)
            End If
        End If
        If e.Item.FieldName.Contains("Andrea-Documentar") Then
            CoppelDocumentar = e.Item.FieldName
            CoppelPares = "Andrea-Pares"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer?)(CoppelDocumentar)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer?)(CoppelPares)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)
            End If
        End If

        'STOCK
        If e.Item.FieldName.Contains("Stock-Facturar") Then
            StockFacturar = e.Item.FieldName
            StockPares = "Stock-Pares"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(StockFacturar)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(StockPares)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)
            End If
        End If
        If e.Item.FieldName.Contains("Stock-Documentar") Then
            StockDocumentar = e.Item.FieldName
            StockPares = "Stock-Pares"
            vNumDividir = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(StockDocumentar)).Sum()
            vNumDividir2 = (From x In tablaCopia.AsEnumerable() Select x.Field(Of Integer)(StockPares)).Sum()
            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CDbl(vTotal)
            End If
        End If

    End Sub

#End Region

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        nudSemanaInicio.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
        nudSemanaFin.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
        nudAnioInicio.Value = DatePart(DateInterval.Year, Now)
        nudAnioFin.Value = DatePart(DateInterval.Year, Now)
        'cbxNave.Text = ""
        'cbxNave.SelectedValue = 0
        grdReporte.DataSource = Nothing

        If grdVReporte.GroupSummary.Count() = 0 Then
            For Each vColumna As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In grdVReporte.Columns
                vColumna.Summary.Clear()
            Next
        End If
        grdVReporte.OptionsView.ShowFooter = False
        grdVReporte.Bands.Clear()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub



    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim filtroReporte As New FiltrosReportesForm With {
            .TIPO_BUSQUEDA = 11
        }

        Dim lstIDFiltro As New List(Of String)
        For Each row As UltraGridRow In grdNave.Rows
            Dim parametro As String = row.Cells(0).Text
            lstIDFiltro.Add(parametro)
        Next

        filtroReporte.LST_ID_FILTRO = lstIDFiltro
        filtroReporte.ShowDialog(Me)

        If Not filtroReporte.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If filtroReporte.LST_PARAMETROS.Rows.Count = 0 Then Return

        grdNave.DataSource = filtroReporte.LST_PARAMETROS
        With grdNave
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroNave.Click
        grdNave.DataSource = Nothing
    End Sub

    Private Sub grdNave_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdNave.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        With grdNave.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
        grdNave.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += row.Cells(0).Text
            Else
                Resultado += "," + row.Cells(0).Text
            End If
        Next

        Return Resultado
    End Function
End Class
