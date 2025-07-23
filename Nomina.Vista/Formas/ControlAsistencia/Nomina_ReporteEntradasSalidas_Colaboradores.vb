Imports DevExpress.Data.XtraReports.Wizard
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Nomina.Negocios
Imports Tools

Public Class Nomina_ReporteEntradasSalidas_Colaboradores
    Dim listaInicial As New List(Of String)
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim dtObtieneReporteColaboradores As New DataTable
    Public inicio As Boolean = True
    Dim idNave As Integer = 43

    Private Sub Nomina_ReporteEntradasSalidas_Colaboradores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdColaboradores.DataSource = listaInicial
        lblTotalColaboradoresNumero.Text = 0

        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now

        dtpFechaInicio.MaxDate = Date.Now

        dtpFechaFin.MaxDate = Date.Now
        'dtpFechaFin.MinDate = dtpFechaInicio.Value
        initcombos()
    End Sub

    Public Sub initcombos()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnAgregarColaboradores_Click_1(sender As Object, e As EventArgs) Handles btnAgregarColaboradores.Click
        Dim listado As New Nomina_ListadoColaboradores_ReporteEntradasSalidas
        listado.tipo_busqueda = 1
        If cmbNave.SelectedValue > 0 Then
            idNave = cmbNave.SelectedValue
        End If
        listado.naveId = idNave


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColaboradores.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdColaboradores.DataSource = listado.listaParametros
        With grdColaboradores
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colaborador"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub grdColaboradores_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles grdColaboradores.InitializeLayout
        grid_diseño(grdColaboradores)
        grdColaboradores.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colaboradores"
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

    Private Sub btnLimpiarColaboradores_Click_1(sender As Object, e As EventArgs) Handles btnLimpiarColaboradores.Click
        grdColaboradores.DataSource = listaInicial
    End Sub

    Private Sub grdColaboradores_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColaboradores.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColaboradores.DeleteSelectedRows(False)
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New ReporteColaboradoresBU
        Dim FColaboradores As String = String.Empty

        Dim fechainicio As Date = dtpFechaInicio.Value.ToShortDateString()
        Dim fechafin As Date = dtpFechaFin.Value.ToShortDateString()
        'Dim NaveID As Integer = 43  'QUITAR ANTES DE PUBLICAR 


        grdReporteColaboradores.DataSource = Nothing
        vwReporteColaboradores.Columns.Clear()
        vwReporteColaboradores.Bands.Clear()


        FColaboradores = ObtenerFiltrosGridColaboradores(grdColaboradores)

        Try
            Cursor = Cursors.WaitCursor

            If fechainicio > fechafin Then
                advertencia.mensaje = "La fecha de inicio no puede ser mayor a la de fin."
                advertencia.ShowDialog()
            Else
                If cmbNave.SelectedValue > 0 Then
                    idNave = cmbNave.SelectedValue
                End If

                dtObtieneReporteColaboradores = objBU.ObtieneReporteColaboradoresEntradasSalidas(fechainicio, fechafin, FColaboradores, idNave)

                If dtObtieneReporteColaboradores.Rows.Count > 0 Then
                    grdReporteColaboradores.DataSource = dtObtieneReporteColaboradores

                    inicio = False

                    Dim lstColaboradores As New List(Of String)

                    For Each row As DataRow In dtObtieneReporteColaboradores.Rows
                        If lstColaboradores.Contains((row.Item("nombreColaborador").ToString)) = False Then
                            lstColaboradores.Add((row.Item("nombreColaborador").ToString))
                        End If
                    Next

                    lblTotalColaboradoresNumero.Text = lstColaboradores.Count


                    lblFechaUltimaActualización.Text = Date.Now
                    DisenoGrid()

                    For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwReporteColaboradores.Columns
                        Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        Col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

                        If Col.ColumnType() = GetType(Double) Then
                            Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            Col.DisplayFormat.FormatString = "N2"
                            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        End If
                    Next


                    For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In vwReporteColaboradores.Bands
                        gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        For Each childrenBand In gridband.Children
                            childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        Next
                    Next



                Else
                    advertencia.mensaje = "No hay información para mostrar."
                    advertencia.ShowDialog()
                End If

            End If



        Catch ex As Exception

        End Try


        Cursor = Cursors.Default
    End Sub

    Private Sub DisenoGrid()
        DiseñoGrid.DiseñoBaseGrid(vwReporteColaboradores)



        Dim band1 As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim band2 As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band1.Caption = ""
        band2.Caption = ""
        band2.OptionsBand.AllowMove = False
        band1.OptionsBand.AllowMove = False
        band1.Fixed = Columns.FixedStyle.Left

        vwReporteColaboradores.OptionsView.AllowCellMerge = True

        vwReporteColaboradores.Columns("Orden").Visible = False

        For Each vColumna As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwReporteColaboradores.Columns
            Select Case vColumna.FieldName
                Case "OrdenColaborador"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                Case "nombreColaborador"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                Case "tipoRegistro"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                Case Else
                    vColumna.OwnerBand = band2
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            End Select

            vColumna.OptionsColumn.AllowMove = False
        Next

        vwReporteColaboradores.IndicatorWidth = 20

        vwReporteColaboradores.Bands.Add(band1)
        vwReporteColaboradores.Bands.Add(band2)
        vwReporteColaboradores.OptionsView.ShowFooter = False
        vwReporteColaboradores.OptionsCustomization.AllowSort = False

        vwReporteColaboradores.Columns.ColumnByFieldName("OrdenColaborador").Width = 30
        vwReporteColaboradores.Columns.ColumnByFieldName("OrdenColaborador").Caption = " "


        vwReporteColaboradores.Columns.ColumnByFieldName("nombreColaborador").Caption = "Colaborador"
        vwReporteColaboradores.Columns.ColumnByFieldName("tipoRegistro").Caption = "Tipo Registro"




    End Sub



    Public Function ObtenerFiltrosGridColaboradores(ByVal grid As UltraGrid) As String
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporteColaboradores.DataSource = Nothing
        dtpFechaInicio.MaxDate = Date.Now
        dtpFechaFin.MaxDate = Date.Now
        vwReporteColaboradores.Columns.Clear()
        vwReporteColaboradores.Bands.Clear()
        grdColaboradores.DataSource = listaInicial
        lblFechaUltimaActualización.Text = ""
        lblTotalColaboradoresNumero.Text = "0"
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub exportarExcel()
        If vwReporteColaboradores.RowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty

            Try

                nombreReporte = "\Reporte_EntradasSalidas_Colaboradores_"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        If vwReporteColaboradores.GroupCount > 0 Then
                            vwReporteColaboradores.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            vwReporteColaboradores.OptionsPrint.AutoWidth = True
                            vwReporteColaboradores.OptionsPrint.UsePrintStyles = True
                            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.DataAware

                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            grdReporteColaboradores.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Finally
                Me.Cursor = Cursors.Default
            End Try

        Else
            advertencia.mensaje = "No hay datos para exportar."
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Try

            Dim OrdenColaborador As Integer = vwReporteColaboradores.GetRowCellValue(e.RowHandle, "OrdenColaborador")

            If (OrdenColaborador Mod 2) <> 0 Then
                e.Formatting.BackColor = SystemColors.ActiveCaption
            Else
                e.Formatting.BackColor = Color.White
            End If



        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " + ex.Message)
        End Try

        e.Handled = True
    End Sub


    Private Sub btnAbajo_Click_2(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 210
    End Sub

    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 33
    End Sub

    Private Sub vwReporteColaboradores_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles vwReporteColaboradores.CustomDrawCell
        Dim View As GridView = TryCast(sender, GridView)

        If e.RowHandle >= 0 Then
            Dim OrdenColaborador As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("OrdenColaborador"))

            If (OrdenColaborador Mod 2) <> 0 Then
                e.Appearance.BackColor = SystemColors.ActiveCaption
            Else
                e.Appearance.BackColor = Color.White
            End If
        End If
    End Sub

    Private Sub chboxEntrada_CheckedChanged(sender As Object, e As EventArgs) Handles chboxEntrada.CheckedChanged
        If inicio = False Then
            If chboxRegresoComida.Checked = True Or chboxSalidaComida.Checked = True Or chboxSalida.Checked = True Then
                If chboxEntrada.Checked Then
                    btnMostrar_Click(Nothing, Nothing)
                Else
                    If dtObtieneReporteColaboradores.Rows.Count > 0 Then
                        btnMostrar_Click(Nothing, Nothing)
                    Else

                    End If
                End If
            Else
                chboxEntrada.Checked = True
            End If
        Else
            chboxEntrada.Checked = True
        End If
        'If vwReporteColaboradores.RowCount > 0 Then

        'Else
        'chboxEntrada.Checked = True
        ' End If

    End Sub

    Private Sub vwReporteColaboradores_CustomRowFilter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles vwReporteColaboradores.CustomRowFilter
        Dim view As ColumnView = CType(sender, ColumnView)

        Dim TipoRegistro As String = view.GetListSourceRowCellValue(e.ListSourceRow, "tipoRegistro").ToString()

        If chboxEntrada.Checked = False Then

            ' Check whether the current row contains "USA" in the "Country" field.
            If TipoRegistro = "ENTRADA" Then
                ' Make the current row visible.
                e.Visible = False
                ' Prevent default processing, so the row will be visible 
                ' regardless of the view's filter.
                e.Handled = True
                chboxEntrada.Checked = False

            End If
        Else
            If TipoRegistro = "ENTRADA" Then

            End If
        End If

        If chboxSalida.Checked = False Then

            ' Check whether the current row contains "USA" in the "Country" field.
            If TipoRegistro = "SALIDA" Then
                ' Make the current row visible.
                e.Visible = False
                ' Prevent default processing, so the row will be visible 
                ' regardless of the view's filter.
                e.Handled = True
                chboxSalida.Checked = False
            End If

        End If

        If chboxRegresoComida.Checked = False Then

            ' Check whether the current row contains "USA" in the "Country" field.
            If TipoRegistro = "REGRESO COMIDA" Then
                ' Make the current row visible.
                e.Visible = False
                ' Prevent default processing, so the row will be visible 
                ' regardless of the view's filter.
                e.Handled = True
                chboxRegresoComida.Checked = False
            End If

        End If

        If chboxSalidaComida.Checked = False Then
            
            ' Check whether the current row contains "USA" in the "Country" field.
            If TipoRegistro = "SALIDA COMIDA" Then
                ' Make the current row visible.
                e.Visible = False
                ' Prevent default processing, so the row will be visible 
                ' regardless of the view's filter.
                e.Handled = True
                chboxSalidaComida.Checked = False
            End If

        End If


    End Sub

    Private Sub chboxSalida_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSalida.CheckedChanged
        'If vwReporteColaboradores.RowCount > 0 Then
        If inicio = False Then
            If chboxEntrada.Checked = True Or chboxRegresoComida.Checked = True Or chboxSalidaComida.Checked = True Then
                If chboxSalida.Checked Then
                    btnMostrar_Click(Nothing, Nothing)
                Else
                    If dtObtieneReporteColaboradores.Rows.Count > 0 Then
                        btnMostrar_Click(Nothing, Nothing)
                    Else

                    End If
                End If
            Else
                chboxSalida.Checked = True
            End If
        Else
            chboxSalida.Checked = True
        End If

        'Else
        'chboxSalida.Checked = True
        'End If



    End Sub

    Private Sub chboxRegresoComida_CheckedChanged(sender As Object, e As EventArgs) Handles chboxRegresoComida.CheckedChanged
        'If vwReporteColaboradores.RowCount > 0 Then
        If inicio = False Then
            If chboxEntrada.Checked = True Or chboxSalidaComida.Checked = True Or chboxSalida.Checked = True Then
                If chboxRegresoComida.Checked Then
                    btnMostrar_Click(Nothing, Nothing)
                Else
                    If dtObtieneReporteColaboradores.Rows.Count > 0 Then
                        btnMostrar_Click(Nothing, Nothing)
                    Else

                    End If
                End If
            Else
                chboxRegresoComida.Checked = True
            End If
        Else
            chboxRegresoComida.Checked = True
        End If

        'Else
        'chboxRegresoComida.Checked = True
        'End If

    End Sub

    Private Sub chboxSalidaComida_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSalidaComida.CheckedChanged
        ' If vwReporteColaboradores.RowCount > 0 Then
        If inicio = False Then
            If chboxEntrada.Checked = True Or chboxRegresoComida.Checked = True Or chboxSalida.Checked = True Then

                If chboxSalidaComida.Checked Then
                    btnMostrar_Click(Nothing, Nothing)
                Else
                    If dtObtieneReporteColaboradores.Rows.Count > 0 Then
                        btnMostrar_Click(Nothing, Nothing)
                    Else

                    End If
                End If
            Else
                chboxSalidaComida.Checked = True
            End If
        Else
            chboxSalidaComida.Checked = True
        End If

        'Else
        'chboxSalidaComida.Checked = True
        'End If


    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaInicio.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaFin.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

End Class