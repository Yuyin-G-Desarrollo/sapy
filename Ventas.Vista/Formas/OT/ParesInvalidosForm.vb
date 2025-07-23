Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet

Public Class ParesInvalidosForm

    Public OrdenTrabajoID As String = String.Empty
    Public DTParesInvalidosOT As DataTable
    Public DTAtadosIncompletos As DataTable
    Public EsAndrea As Boolean = False

    Private Sub ParesInvalidosForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        TabControl1.SelectedIndex = 0

        If EsAndrea = False Then
            TabControl1.TabPages.Remove(TabPage2)
        Else
            CargarAtadosIncompletos()
        End If
        
        CargarParesInvalidos()
        lblNumFiltrados.Text = CDbl(grdParesInvalidos.Rows.Count()).ToString("N0")
    End Sub



    Private Sub CargarAtadosIncompletos()
        grdAtadosIncompletos.DataSource = Nothing
        DiseñogridAtadosIncompletos(grdAtadosIncompletos)
        grdAtadosIncompletos.DataSource = DTAtadosIncompletos
    End Sub

    Private Sub CargarParesInvalidos()
        grdParesInvalidos.DataSource = Nothing
        Diseñogrid(grdParesInvalidos)
        grdParesInvalidos.DataSource = DTParesInvalidosOT
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


    Private Sub DiseñogridAtadosIncompletos(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
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

        AgregarColumna(grid, "OTID", "OT SAY", False, True, Nothing, 30, , False, HAlign.Right)
        AgregarColumna(grid, "CodigoAtado", "Atado ", False, True, Nothing, 60, , False, HAlign.Right)        
        AgregarColumna(grid, "Valido", "Resultado ", True, True, Nothing, 70, False, False, HAlign.Left)


        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub



    Private Sub Diseñogrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
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

        AgregarColumna(grid, "OTID", "OT SAY", False, True, Nothing, 30, , False, HAlign.Right)
        AgregarColumna(grid, "Estiba", "Estiba", True, True, Nothing, 60, False, False, HAlign.Right)
        AgregarColumna(grid, "CodigoAtado", "Atado ", False, True, Nothing, 60, , False, HAlign.Right)
        If EsAndrea = True Then
            AgregarColumna(grid, "CodigoPar", "Código Andrea ", False, True, Nothing, 60, , False, HAlign.Right)
        Else
            AgregarColumna(grid, "CodigoPar", "Par ", False, True, Nothing, 60, , False, HAlign.Right)
        End If

        AgregarColumna(grid, "Talla", "Talla", True, True, Nothing, 35, False, False, HAlign.Right)
        AgregarColumna(grid, "Articulo", "Articulo", True, True, Nothing, 100, False, False, HAlign.Left)
        AgregarColumna(grid, "ResultadoID", "ResultadoID ", True, True, Nothing, 70, , False, HAlign.Right)
        AgregarColumna(grid, "Valido", "Resultado ", False, True, Nothing, 70, False, False, HAlign.Left)
        AgregarColumna(grid, "Operador", "Operador", True, True, Nothing, 70, True, False, HAlign.Right)
        AgregarColumna(grid, "FechaConfirmacion", "FConfirmacion", True, True, Nothing, 70, False, False, HAlign.Right)
        AgregarColumna(grid, "StatusPartida", "StatusPartida", True, True, Nothing, 10)


        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

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
        exportarExcel(grdParesInvalidos)
    End Sub

    Private Sub TabControl1_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.TabIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            lblTitulo.Text = "Pares inválidos"
        Else
            lblTitulo.Text = "Atados Incompletos"
        End If
    End Sub
End Class