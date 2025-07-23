Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class ReporteProyeccionDeProduccionForm
    Dim dtResultadoConsulta As New DataTable
    Dim dtResultadoConsultaCopia As New DataTable
    Dim lstSemanaInhabiles As New List(Of Integer)

    Private Sub ReporteProyeccionDeProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

        Dim vSemana As Integer
        vSemana = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        lblSemanaActual.Text = vSemana
        nudAño.Value = Now.Year


        cmbGrupo.SelectedIndex = 0

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        DiasNoHabiles()
        CargarDatos()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'CargarReporteParaExcel()
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "Proyeccion_de_Produccion_" + cmbGrupo.SelectedText
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        'show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
                'show_message("Advertencia", "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
            'show_message("Advertencia", "No se encontro el archivo")
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        If lstSemanaInhabiles.Contains(vwReporte.GetRowCellValue(e.RowHandle, "SEM_NUM")) Then
                e.Formatting.Font.Color = lblSemanaNoLaboral.ForeColor
            End If

            If (e.RowHandle Mod 2 > 0) Then
                e.Formatting.BackColor = Color.LightSteelBlue
            End If

        e.Handled = True

    End Sub

    Private Sub CargarDatos()
        Dim vTipo As String = cmbGrupo.Text
        Dim vAño As Integer = nudAño.Value
        Dim vSemanaInicio As Integer = nudSemanaInicio.Value
        Dim vSemanaFin As Integer = nudSemanaFinal.Value
        dtResultadoConsulta.Clear()
        dtResultadoConsulta.Columns.Clear()
        Dim objBU As New Programacion.Negocios.ProyeccionProduccionBU


        Select Case vTipo
            Case "FVO"
                dtResultadoConsulta = objBU.obtenerProyeccionProduccionFVO(vSemanaInicio, vSemanaFin, vAño)
            Case "RVO"
                dtResultadoConsulta = objBU.obtenerProyeccionProduccionRVO(vSemanaInicio, vSemanaFin, vAño)
        End Select


        If dtResultadoConsulta.Rows.Count > 0 Then

            grdReporte.DataSource = Nothing
            DiseñoGrid(vTipo)
            grdReporte.DataSource = dtResultadoConsulta

            dtResultadoConsultaCopia = dtResultadoConsulta.Copy()


            For Each renglon As DataRow In dtResultadoConsultaCopia.Rows
                For Each columna As DataColumn In dtResultadoConsultaCopia.Columns
                    If IsDBNull(renglon.Item(columna)) Then
                        renglon.Item(columna) = 0
                    End If
                Next
            Next

            reporteTotales()
            btnArriba_Click(Nothing, Nothing)

        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "No hay datos para mostrar"
            mensajeAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub DiseñoGrid(ByVal pTipoReporte As String)
        Dim objBu As New Programacion.Negocios.ProyeccionProduccionBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim lstBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim dtEncabezados As New System.Data.DataTable
        Dim BAND2 As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim vNombreColumna As String = String.Empty

        dtEncabezados = objBu.obtenerProyeccionProduccionEncabezados(pTipoReporte)
        vwReporte.Columns.Clear()
        vwReporte.Bands.Clear()
        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False
        vwReporte.Appearance.HeaderPanel.Options.UseBackColor = True
        vwReporte.OptionsView.AllowCellMerge = False

        For Each row As DataRow In dtEncabezados.Rows
            If listBandsTextos.Contains(row.Item("TITULO").ToString()) = False Then
                listBandsTextos.Add(row.Item("TITULO").ToString())
                band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                band.Caption = row.Item("TITULO").ToString()
                listBands.Add(band)
            End If
            For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
                If row("TITULO").ToString() = gridBand.Caption Then

                    If row.Item("SUBTITULO").ToString().ToUpper <> "" Then
                        If row.Item("SUBTITULO").ToString().ToUpper.Contains(gridBand.Caption) Then
                            vwReporte.Columns.AddField(row.Item("SUBTITULO").ToString().ToUpper)
                            vwReporte.Columns.ColumnByFieldName(row.Item("SUBTITULO").ToString().ToUpper).OwnerBand = gridBand
                            vwReporte.Columns.ColumnByFieldName(row.Item("SUBTITULO").ToString().ToUpper).Visible = True
                            vwReporte.Columns.ColumnByFieldName(row.Item("SUBTITULO").ToString().ToUpper).OptionsColumn.AllowEdit = False
                            vNombreColumna = Split(row.Item("SUBTITULO").ToString().ToUpper, "_")(1)
                            vwReporte.Columns.ColumnByFieldName(row.Item("SUBTITULO").ToString().ToUpper).Caption = vNombreColumna
                            vwReporte.Columns.ColumnByFieldName(row.Item("SUBTITULO").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            vwReporte.Columns.ColumnByFieldName(row.Item("SUBTITULO").ToString().ToUpper).DisplayFormat.FormatString = "N0"
                        End If
                    End If
                End If
            Next
        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwReporte.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            vwReporte.Bands.Add(gridBand)
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

    End Sub

    Private Sub reporteTotales()
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem
        For Each vColumna As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwReporte.Columns

            If vColumna.FieldName.Contains("SEM") = False And vColumna.FieldName.Contains("PROY") = False Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                vwReporte.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False
            End If

            If vColumna.FieldName.Contains("PROY") Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                item.DisplayFormat = "{0}"
                vwReporte.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False
            End If

            If vColumna.FieldName.Contains("PROD") Then

                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N0}%")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                item.DisplayFormat = "{0}"
                vwReporte.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False

            End If

            If vColumna.FieldName.Contains("PROG") Then

                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Custom, vColumna.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                item.DisplayFormat = "{0}"
                vwReporte.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False

            End If

        Next
    End Sub


    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 25
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 93
    End Sub

    Private Sub DiasNoHabiles()
        Dim objBU As New Negocios.Programacion_Reportes_EvaluacionNaves_BU
        Dim dtSemanasInhabiles As New DataTable

        lstSemanaInhabiles = New List(Of Integer)
        dtSemanasInhabiles = objBU.consultarSemanasInhabilesCompletas(nudAño.Value)

        For Each renglon As DataRow In dtSemanasInhabiles.Rows
            lstSemanaInhabiles.Add(renglon.Item("numSemana"))
        Next

    End Sub

    Private Sub vwReporte_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwReporte.RowStyle
        Dim view As GridView = sender

        If lstSemanaInhabiles.Contains(vwReporte.GetRowCellValue(e.RowHandle, "SEM_NUM")) Then
            e.Appearance.ForeColor = lblSemanaNoLaboral.ForeColor
        End If

        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        Dim nsemana As Integer
        nsemana = DateDiff(DateInterval.WeekOfYear, CDate("31/12/" + nudAño.Value.ToString()), New DateTime(nudAño.Value, 1, 1)) * -1
        nudSemanaInicio.Minimum = 1
        nudSemanaInicio.Maximum = nsemana
        nudSemanaFinal.Minimum = 1
        nudSemanaFinal.Maximum = nsemana
        nudSemanaFinal.Value = nsemana - 1
    End Sub

    Private Sub nudSemanaInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaInicio.ValueChanged
        nudSemanaFinal.Minimum = nudSemanaInicio.Value
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwReporte_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles vwReporte.CustomSummaryCalculate
        Dim vE As DevExpress.Data.CustomSummaryEventArgs = e
        Dim vProd As String
        Dim vProy As String
        Dim vSpid As Integer = 0
        Dim vNumDividir As Decimal = 0
        Dim vNumDividir2 As Decimal = 0
        Dim vTotal As Decimal = 0
        Dim NumeroFilas As Integer = 0
        Dim Semana As Integer = 0

        If dtResultadoConsultaCopia.Rows.Count > 0 Then
            vTotal = 0

            If e.Item.FieldName.Contains("PROY") Then
                NumeroFilas = vwReporte.DataRowCount
                If NumeroFilas > 0 Then
                    For index As Integer = 0 To NumeroFilas Step 1
                        Semana = vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), "SEM_NUM")
                        If Semana <= CInt(lblSemanaActual.Text) Then
                            If IsDBNull(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), e.Item.FieldName)) = False Then
                                vTotal += vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), e.Item.FieldName)
                            End If
                        End If
                    Next
                    e.TotalValue = vTotal
                End If
            End If

            If e.Item.FieldName.Contains("PROD") Then
                vProd = e.Item.FieldName
                vProy = e.Item.FieldName.Replace("PROD", "PROY")
                vNumDividir = (From x In dtResultadoConsultaCopia.AsEnumerable() Select x.Field(Of Integer)(vProd)).Sum()
                vNumDividir2 = (From x In dtResultadoConsultaCopia.AsEnumerable() Select x.Field(Of Integer)(vProy)).Sum()

                If vNumDividir = 0 Or vNumDividir2 = 0 Then
                    e.TotalValue = 0
                Else
                    vTotal = ((vNumDividir / vNumDividir2) * 100)
                    e.TotalValue = CInt(vTotal)

                End If
            End If

            If e.Item.FieldName.Contains("PROG") Then
                vTotal = 0
                vProd = e.Item.FieldName.Replace("PROG", "PROD")
                vProy = e.Item.FieldName.Replace("PROG", "PROY")
                vNumDividir = (From x In dtResultadoConsultaCopia.AsEnumerable() Select x.Field(Of Integer)(vProd)).Sum()
                vNumDividir2 = (From x In dtResultadoConsultaCopia.AsEnumerable() Select x.Field(Of Integer)(vProy)).Sum()

                If vNumDividir = 0 Or vNumDividir2 = 0 Then
                    e.TotalValue = 0
                Else
                    vTotal = vNumDividir - vNumDividir2
                    e.TotalValue = CInt(vTotal)

                End If
            End If
        End If
    End Sub


End Class