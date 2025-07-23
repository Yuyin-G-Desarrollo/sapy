Imports Ventas.Negocios
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization

Public Class ConsultaProspectaAlmacenForm

    Public ProspectaID As Integer = -1

    Private Sub ConsultaProspectaAlmacenForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarInformacionProspecta()
        CargarGrid()
        lblNumFiltrados.Text = grdConsulta.Rows.Count.ToString()
        lblFechaUltimaActualizacion.Visible = True
        lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor
            If ProspectaID > 0 Then
                CargarGrid()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    'Private Function ObtenerClientesFiltro() As String
    '    Dim filtro As String = String.Empty
    '    If grdFiltroClientes.Rows.Count <> 0 Then
    '        For Each row As UltraGridRow In grdFiltroClientes.Rows
    '            If row.Index = 0 Then
    '                filtro += " " + Replace(row.Cells(0).Value.ToString(), ",", "") + ""
    '            Else
    '                filtro += ", " + Replace(row.Cells(0).Value.ToString(), ",", "") + ""
    '            End If
    '        Next
    '    End If
    '    Return filtro
    'End Function


    Public Sub CargarGrid()
        Dim obj As New ProspectaBU
        Dim DTInformacion As DataTable
        Dim DTInformacionTotal As DataTable
        Dim FiltroCliente As String = String.Empty
        grdConsulta.DataSource = Nothing
        DiseñoGrid(grdConsulta)        

        DTInformacion = obj.ConsultaProspectaAlmacen(ProspectaID, FiltroCliente)
        grdConsulta.DataSource = DTInformacion

        grdTotal.DataSource = Nothing
        DiseñoGrid(grdTotal)
        DTInformacionTotal = obj.ConsultaProspectaAlmacenTotales(ProspectaID)
        grdTotal.DataSource = DTInformacionTotal

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


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub DiseñoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim FechaInicioProspecta As Date = dtmFechaInicio.Value
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        If grid.Name = "grdConsulta" Then
            grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            grid.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
            grid.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Else
            grid.DisplayLayout.Override.RowSelectorWidth = 1
        End If

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        '        grid.DisplayLayout.Scrollbars = Scrollbars.Vertical

        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        'grid.DisplayLayout.Override.SelectTypeRow = SelectType.Single


        'AgregarColumna(grid, "ID", "ID", True, True, Nothing, 10, , False, HAlign.Left)
        'AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 240, False, False, HAlign.Left)
        'AgregarColumna(grid, "Concepto", "Concepto", False, True, Nothing, 100, , False, HAlign.Left)

        'AgregarColumna(grid, "EntregarLunes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, , False, HAlign.Right)
        'FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
        'AgregarColumna(grid, "EntregarMartes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, , False, HAlign.Right)
        'FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
        'AgregarColumna(grid, "EntregarMiercoles", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, False, False, HAlign.Right)
        'FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
        'AgregarColumna(grid, "EntregarJueves", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, False, False, HAlign.Right)
        'FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
        'AgregarColumna(grid, "EntregarViernes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, False, False, HAlign.Right)
        'FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
        'AgregarColumna(grid, "EntregarSabado", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, False, False, HAlign.Right)
        'AgregarColumna(grid, "Total", "Total", False, False, Nothing, 100, False, False, HAlign.Right)

        If grid.Name = "grdTotal" Then

            AgregarColumna(grid, "ID", "ID", True, True, Nothing, 10, , False, HAlign.Left)
            AgregarColumna(grid, "Cliente", "Total", False, True, Nothing, 120, False, False, HAlign.Left)
            AgregarColumna(grid, "Concepto", "Concepto", True, True, Nothing, 130, , False, HAlign.Left)

            AgregarColumna(grid, "EntregarLunes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 80, , False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarMartes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 80, , False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarMiercoles", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 80, False, False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarJueves", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 80, False, False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarViernes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 80, False, False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarSabado", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 80, False, False, HAlign.Right)
            AgregarColumna(grid, "Total Semana", "Total", True, False, Nothing, grdConsulta.DisplayLayout.Bands(0).Columns(9).Width, False, False, HAlign.Right)

        Else
            grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

            AgregarColumna(grid, "ID", "ID", True, True, Nothing, 10, , False, HAlign.Left)
            AgregarColumna(grid, "Cliente", "Cliente", False, True, Nothing, 240, False, False, HAlign.Left)
            AgregarColumna(grid, "Concepto", "Concepto", False, True, Nothing, 100, , False, HAlign.Left)

            AgregarColumna(grid, "EntregarLunes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, True, False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarMartes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, True, False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarMiercoles", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, True, False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarJueves", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, True, False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarViernes", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, True, False, HAlign.Right)
            FechaInicioProspecta = FechaInicioProspecta.AddDays(1)
            AgregarColumna(grid, "EntregarSabado", ObtenerFecha(FechaInicioProspecta), False, False, Nothing, 100, True, False, HAlign.Right)
            AgregarColumna(grid, "Total", "Total", False, False, Nothing, 100, True, False, HAlign.Right)


        End If


        If grid.Name <> "grdTotal" Then
            Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
            band.ColHeaderLines = 2
            band.GroupHeaderLines = 2
        End If

        'Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        'band.ColHeaderLines = 2
        'band.GroupHeaderLines = 2



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




    'UltraGridExcelExporter

    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog

        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay informacion para exportar a excel.")
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
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atencion")
            End Try
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel(grdConsulta)
    End Sub


    Private Sub btnComentarioRevision_Click(sender As Object, e As EventArgs) Handles btnComentarioRevision.Click
        Dim Form As New ProspectaNotasRevisionForm
        If ProspectaID = -1 Then
            show_message("Advertencia", "La prospecta todavia no se ha guardado.")
        Else
            Form.ProspectaID = ProspectaID

            Form.EstatusProspecta = txtStatusProspecta.Text.Trim
            Form.ShowDialog()
        End If
    End Sub

    'Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs)
    '    Dim listado As New ListadoParametrosApartadosForm
    '    listado.tipo_busqueda = 20

    '    Dim listaParametroID As New List(Of String)
    '    For Each row As UltraGridRow In grdFiltroClientes.Rows
    '        Dim parametro As String = row.Cells(0).Text
    '        listaParametroID.Add(parametro)
    '    Next

    '    listado.listaParametroID = listaParametroID
    '    listado.ShowDialog(Me)
    '    If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
    '    If listado.listParametros.Rows.Count = 0 Then Return
    '    grdFiltroClientes.DataSource = listado.listParametros
    '    With grdFiltroClientes
    '        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
    '        .DisplayLayout.Bands(0).Columns(0).Hidden = True
    '        '.DisplayLayout.Bands(0).Columns(1).Hidden = True
    '    End With
    '    grdFiltroClientes.DisplayLayout.Bands(0).Columns(1).Hidden = True

    'End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        Dim seleccionados As Integer = 0
        pnlFiltros.Height = 119
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        Dim seleccionados As Integer = 0
        pnlFiltros.Height = 24        
    End Sub

    'Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs)
    '    grdFiltroClientes.DataSource = Nothing
    'End Sub

    'Private Sub grdFiltroClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
    '    grid_diseño(grdFiltroClientes)
    '    grdFiltroClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    'End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        'For Each row In grid.Rows
        '    row.Activation = Activation.NoEdit
        'Next

        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If
        Next
    End Sub

    Private Function ObtenerFecha(ByVal Fecha As Date) As String
        Dim FormatoTitulo As String = String.Empty
        Dim day As New DayOfWeek
        'Fecha.DayOfWeek.Thursday
        If Fecha.DayOfWeek.ToString = "Monday" Then
            FormatoTitulo = "L"
        ElseIf Fecha.DayOfWeek.ToString = "Tuesday" Then
            FormatoTitulo = "M"
        ElseIf Fecha.DayOfWeek.ToString = "Wednesday" Then
            FormatoTitulo = "MI"
        ElseIf Fecha.DayOfWeek.ToString = "Thursday" Then
            FormatoTitulo = "J"
        ElseIf Fecha.DayOfWeek.ToString = "Friday" Then
            FormatoTitulo = "V"
        ElseIf Fecha.DayOfWeek.ToString = "Saturday" Then
            FormatoTitulo = "S"
        ElseIf Fecha.DayOfWeek.ToString = "Sunday" Then
            FormatoTitulo = "D"
        End If

        If Fecha.Month > 9 Then
            FormatoTitulo = FormatoTitulo + " " + Fecha.Day.ToString + "/" + Fecha.Month.ToString()
        Else
            FormatoTitulo = FormatoTitulo + " " + Fecha.Day.ToString + "/0" + Fecha.Month.ToString()
        End If

        Return FormatoTitulo
    End Function

   


    
End Class