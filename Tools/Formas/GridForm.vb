Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing


Public Class GridForm
    Public año As String
    Public nave As String

    Public DTExcluidos As DataTable

    Public Sub cargarDatos(ByVal anio As String, ByVal idNave As String)
        año = anio
        nave = idNave
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        Dim datos As DataTable

        Try
            datos = obj.getExcluidos(anio, idNave)
            'For i As Integer = 0 To datos.Rows.Count - 1
            '    grdNombresExcluidos.Rows.Add(datos.Rows(i).Item("Nombre").ToString)
            'Next i
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim objMensajeAdv As New Tools.ConfirmarForm
        Dim obj As New Nomina.Negocios.RealesFiscalesBU

        Try
            objMensajeAdv.mensaje = "Esta seguro de borrar los registros, no podrán ser visualizados posteriormente."
            If objMensajeAdv.ShowDialog = Windows.Forms.DialogResult.OK Then
                obj.eliminarExcluidos(año, nave)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GridForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        grdNombresExcluidos.DataSource = Nothing
        AgregarColumna(grdNombresExcluidos, "Paterno", "Apellido Paterno", False, True, Nothing, 100)
        AgregarColumna(grdNombresExcluidos, "Materno", "Apellido Materno", False, True, Nothing, 100)
        AgregarColumna(grdNombresExcluidos, "Nombre", "Nombre", False, True, Nothing, 100)
        AgregarColumna(grdNombresExcluidos, "FiniquitoFiscal", "Total Fiscal", False, False, Nothing, 100, True, , HAlign.Right)


        grdNombresExcluidos.DataSource = DTExcluidos
        grdNombresExcluidos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNombresExcluidos.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdNombresExcluidos.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdNombresExcluidos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNombresExcluidos.DisplayLayout.Override.RowSelectorWidth = 35
        grdNombresExcluidos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grdNombresExcluidos.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grdNombresExcluidos.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdNombresExcluidos.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grdNombresExcluidos.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdNombresExcluidos.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grdNombresExcluidos.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grdNombresExcluidos.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard


     
        'DTNoEncontrados.Columns.Add("Paterno", Type.GetType("System.String"))
        'DTNoEncontrados.Columns.Add("Materno", Type.GetType("System.String"))
        'DTNoEncontrados.Columns.Add("Nombre", Type.GetType("System.String"))
        'DTNoEncontrados.Columns.Add("FiniquitoFiscal", Type.GetType("System.Double"))

        'grdNombresExcluidos.DisplayLayout.Bands(0).Columns(3).CellAppearance.TextHAlign = HAlign.Right

        'SumarizarColumnaGrid(grdNombresExcluidos, 3, "Total")

        btnBorrar.Visible = False
        lblBorrar.Visible = False

    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal Index As Integer, ByVal Key As String)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(Index)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub


    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "")
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key)
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
            If EsCadena = False Then
                columna.MaxWidth = Width
            End If

        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, SummaryType.Sum, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        show_message("Advertencia", Eliminar_Acentos("áéíóúÁÉÍÚÓÑ"))
    End Sub

    Public Function Eliminar_Acentos(ByVal accentedStr As String) As String
        Dim tempBytes As Byte()
        tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr)
        Return System.Text.Encoding.UTF8.GetString(tempBytes)
    End Function


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

End Class