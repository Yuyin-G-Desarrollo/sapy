Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Ventas.Negocios
Imports Framework.Negocios
Imports Tools


Public Class ConsultaParesErroneos_IncidenciasForm

    Dim dtIncidencias As New DataTable()
    Dim dtErrores As New DataTable()    
    Public tipoConsulta As Integer = 0
    Public OrdenTrabajoID As String = String.Empty

    Private Sub SeguimientoParesProyeccionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ubicacionTitulo As New System.Drawing.Point(lblTitulo.Location.X - 140, lblTitulo.Location.Y)
        

        If tipoConsulta = 0 Then
            CargarIncidencias()
            CargarErrores()
            
            TabControl1.SelectedIndex = 0
            lblNumFiltrados.Text = grdIncidencias.Rows.Count()
        ElseIf tipoConsulta = 1 Then

            Me.Text = "Pares con Incidencia"
            lblTitulo.Text = "Pares con Incidencia"
            lblTitulo.Location = ubicacionTitulo
            CargarIncidencias()
            TabControl1.SelectedIndex = 0
            TabControl1.TabPages.Remove(TabPage2)            
            lblNumFiltrados.Text = CDbl(grdIncidencias.Rows.Count().ToString()).ToString("N0")

            lblStCorregido.Visible = False
            lblStPendienteCorregir.Visible = False
            lblEstatusPendienteCorregir.Visible = False
            pnlEstatusCorregido.Visible = False

        ElseIf tipoConsulta = 2 Then
            Me.Text = "Pares Erroneos"
            lblTitulo.Text = "Pares Erroneos"
            CargarErrores()
            TabControl1.SelectedIndex = 1
            TabControl1.TabPages.Remove(TabPage1)
            lblNumFiltrados.Text = CDbl(grdErrores.Rows.Count().ToString()).ToString("N0")

            lblStCorregido.Visible = True
            lblStPendienteCorregir.Visible = True
            lblEstatusPendienteCorregir.Visible = True
            pnlEstatusCorregido.Visible = True
           

        End If

        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()

    End Sub

    Public Sub CargarIncidencias()
        Dim objBU As New OrdenTrabajoBU
        grdIncidencias.DataSource = Nothing
        DiseñoIncidencias(grdIncidencias)
        grdIncidencias.DataSource = objBU.ConsultarIncidencias(OrdenTrabajoID)
    End Sub

    Public Sub CargarErrores()
        Dim objBU As New OrdenTrabajoBU
        grdErrores.DataSource = Nothing
        DiseñoErrores(grdErrores)
        grdErrores.DataSource = objBU.ConsultarErrores(OrdenTrabajoID)
    End Sub

   
    Private Sub DiseñoIncidencias(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        'grid.DisplayLayout.Override.AllowGroupBy = DefaultableBoolean.True
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

        AgregarColumna(grid, "OperadorUbico", "Operador" & vbCrLf & " Ubico", False, True, Nothing, 60, , False, HAlign.Left)
        AgregarColumna(grid, "FechaUbicacion", "Fecha" & vbCrLf & " Ubicación", False, True, Nothing, 75, False, False, HAlign.Right)
        AgregarColumna(grid, "Par", "Codigo" & vbCrLf & " Par", False, True, Nothing, 70, , False, HAlign.Right)
        AgregarColumna(grid, "UbicacionFisica", "Ubicación" & vbCrLf & " Física", False, True, Nothing, 90, , False, HAlign.Right)
        AgregarColumna(grid, "UbicacionSistema", "Ubicacion" & vbCrLf & " Sistema", False, True, Nothing, 90, , False, HAlign.Right)
        AgregarColumna(grid, "Operador", "Operador", False, True, Nothing, 90, , False, HAlign.Right)
        AgregarColumna(grid, "FechaConfirmo", "Fecha " & vbCrLf & "Confirmo", False, True, Nothing, 75, , False, HAlign.Right)

        
        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub DiseñoErrores(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

        AgregarColumna(grid, "Color", "", False, True, Nothing, 25, , False, HAlign.Right)
        AgregarColumna(grid, "Atado", "Atado", False, True, Nothing, 90, , False, HAlign.Right)
        AgregarColumna(grid, "Par", "Par", False, True, Nothing, 90, , False, HAlign.Right)
        AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 200, , , HAlign.Left)
        AgregarColumna(grid, "PedidoSAY", "Pedido" & vbCrLf & "SAY", False, True, Nothing, 60, , , HAlign.Right)
        AgregarColumna(grid, "PedidoSICY", "Pedido" & vbCrLf & "SICY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "OTSAYID", "OTS" & vbCrLf & "AYID", False, True, Nothing, 50, , , HAlign.Right)
        AgregarColumna(grid, "UsuarioEscaneo", "Usuario" & vbCrLf & "Escaneo", False, True, Nothing, 75, , False, HAlign.Left)
        AgregarColumna(grid, "FechaEscaneo", "Fecha" & vbCrLf & "Escaneo", False, True, Nothing, 75, , False, HAlign.Left)
        AgregarColumna(grid, "Ubicacion", "Ubicacion", False, True, Nothing, 80, , False, HAlign.Left)
        AgregarColumna(grid, "Descripcion", "Descripción", False, True, Nothing, 200, False, False, HAlign.Left)
        AgregarColumna(grid, "Corregido", "Corregido", True, True, Nothing, 200, False, False, HAlign.Left)



        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


    End Sub

    Private Sub DiseñoClientesBloqueados(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 200, False, False, HAlign.Left)
        AgregarColumna(grid, "Cap", "CAP", False, False, Nothing, 20, False, False, HAlign.Right)
        AgregarColumna(grid, "Pro", "PRO", False, False, Nothing, 20, False, False, HAlign.Right)
        AgregarColumna(grid, "Ent", "ENT", False, False, Nothing, 20, False, False, HAlign.Right)
        AgregarColumna(grid, "Cont", "CONT", False, False, Nothing, 20, False, False, HAlign.Right)
        AgregarColumna(grid, "PorEntregar", "Por Entregar", False, False, Nothing, 100, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "Inventario", "Inventario", False, False, Nothing, 100, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "Proceso", "Proceso", False, False, Nothing, 100, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "LimiteCredito", "Crédito Disponible", False, False, Nothing, 100, False, False, HAlign.Right)
        AgregarColumna(grid, "DiasPlazo", "Días de Plazo", False, False, Nothing, 100, False, False, HAlign.Right)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            lblNumFiltrados.Text = CDbl(grdIncidencias.Rows.Count().ToString()).ToString("N0")
        ElseIf TabControl1.SelectedIndex = 1 Then
            lblNumFiltrados.Text = CDbl(grdErrores.Rows.Count().ToString()).ToString("N0")        
        End If
    End Sub


    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "", Optional ByVal Operacion As SummaryType = SummaryType.Sum)
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key, Operacion)
            End If
            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            'If Alineacion <> HAlign.Default Then
            '    .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            'End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If
            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If


            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit
            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
        Dim FormatoPorcentaje As String = "##0%"
        columna.Hidden = Ocultar
        If EsCadena = True Then
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If

        End If

        If Width <> -1 Then
            columna.Width = Width
        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String, ByVal Operacion As SummaryType)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, Operacion, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        Dim grd As UltraGrid
        Dim tabSeleccionada As TabPage

        tabSeleccionada = TabControl1.SelectedTab
        If tabSeleccionada.Text = "Incidencias" Then
            grd = grdIncidencias
        ElseIf tabSeleccionada.Text = "Errores" Then
            grd = grdErrores        
        End If


        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay información para exportar a excel.")
                Return
            End If
        End If


        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                UltraGridExcelExporter1.Export(grd, fileName)
                show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default


            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function


   

    Private Sub grdErrores_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdErrores.InitializeRow
        'e.Row.Cells("Corregido").Appearance.ForeColor = Color.Transparent

        If CBool(e.Row.Cells("Corregido").Value) = True Then
            e.Row.Cells("Color").Appearance.BackColor = Color.Green
        Else
            e.Row.Cells("Color").Appearance.BackColor = Color.Red
        End If

        'Select Case e.Row.Cells("Corregido").Value
        '    Case "AC"
        '        e.Row.Cells("Color").Appearance.BackColor = pnlEstatusActivo.BackColor
        '    Case "EJ"
        '        e.Row.Cells("Color").Appearance.BackColor = pnlEstatusEnEjecucion.BackColor
        '    Case "PA"
        '        e.Row.Cells("Color").Appearance.BackColor = pnlEstatusParcialmenteConfirmado.BackColor
        'End Select
    End Sub



    'FormatoGrid
    'EstiloGrid
    'ColumnaGrid
    'ExportarExcel
    'ShowMessage
    'SessionID
    'EncabezadoDoble
    'FechaColumna






    Private Sub DisenoApartado(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        grid.DisplayLayout.Override.AllowGroupBy = DefaultableBoolean.True

        AgregarColumna(grid, "clie_nombregenerico", "CLIENTE", False, True, Nothing, 240, , False, HAlign.Left)
        AgregarColumna(grid, "apar_pedidosayid", "PEDIDO" & vbCrLf & "SAY", False, True, Nothing, 60, False, False, HAlign.Right)
        AgregarColumna(grid, "pedi_pedidoidsicy", "PEDIDO " & vbCrLf & " SICY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "apar_apartadoid", "APARTADO " & vbCrLf & " SAY", False, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "apar_apartadoidsicy", "APARTADO " & vbCrLf & "SICY", False, True, Nothing, 70, , False, HAlign.Right)
        AgregarColumna(grid, "apar_totalpares", "TOTAL " & vbCrLf & "APARTADO", False, True, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "apar_paresconfirmados", "CONFIRMADO", False, True, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "apar_paresporconfirmar", "PENDIENTE", False, True, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "clie_clienteid", "clie_clienteid", True, True, Nothing, 10)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub














End Class