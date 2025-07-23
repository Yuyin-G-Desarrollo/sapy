Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form

    Public idCliente As Int32
    Public tipoConsulta As Int32
    Public listaSeleccionados As DataTable
    Public filtroActual As List(Of String)

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If CDate(dtpFechaFin.Value) >= CDate(dtpFechaInicio.Value) Then
            Cursor = Cursors.WaitCursor
            gridListadoParametros.DataSource = Nothing
            Dim objBU As New Negocios.DevolucionClientesBU
            Dim tablaPedidos As New DataTable
            Dim index As Int16

            tablaPedidos = objBU.ListaPedidosCliente(idCliente, CDate(dtpFechaInicio.Value), CDate(dtpFechaFin.Value))
            index = 1

            gridListadoParametros.DataSource = tablaPedidos

            For Each row As UltraGridRow In gridListadoParametros.Rows
                For Each elemento In filtroActual
                    If CStr(row.Cells(index).Value) = elemento Then
                        row.Cells(0).Value = True
                    End If
                Next
            Next

            If gridListadoParametros.Rows.Count > 0 Then
                chboxMarcarTodo.Enabled = True
            Else
                chboxMarcarTodo.Enabled = False
            End If
            Cursor = Cursors.Default
        Else
            Dim FormularioMensaje As New Tools.AdvertenciaForm
            FormularioMensaje.mensaje = "La fecha de Fin debe ser mayor o igual a la fecha de inicio"
            FormularioMensaje.ShowDialog()
        End If
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
                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub DevolucionCliente_Filtro_PedidosDocumentos_PorCliente_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaInicio.MinDate = "01/01/2017"
        dtpFechaInicio.MaxDate = Date.Now
        dtpFechaInicio.Value = Date.Now.AddMonths(-6)

        dtpFechaFin.MinDate = "01/01/2017"
        dtpFechaFin.Value = Date.Now
        dtpFechaFin.MaxDate = Date.Now
        If tipoConsulta = 1 Then
            Me.Size = New System.Drawing.Size(828, 528)
        Else
            Me.Size = New System.Drawing.Size(1028, 528)
        End If
        btnAceptar.Enabled = False
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If gridListadoParametros.Rows.Count = 0 Then Return
        Dim grid As DataTable = gridListadoParametros.DataSource
        listaSeleccionados = grid.Clone

        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                Dim fila As DataRow = listaSeleccionados.NewRow

                For index = 0 To row.Cells.Count - 1 Step 1
                    fila(index) = row.Cells(index).Value
                Next
                listaSeleccionados.Rows.Add(fila)
            End If
        Next
    End Sub

    Private Sub gridListadoParametros_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles gridListadoParametros.InitializeLayout
        With gridListadoParametros.DisplayLayout
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single

            .Bands(0).ColHeaderLines = 2
            .Bands(0).Columns(6).CellActivation = Activation.NoEdit

            If tipoConsulta = 1 Then
                .Bands(0).Columns(7).CellActivation = Activation.NoEdit
                .Bands(0).Columns(1).Header.Caption = "Pedido " + vbCrLf + "SAY"
                .Bands(0).Columns(2).Header.Caption = "Pedido " + vbCrLf + "SICY"
                .Bands(0).Columns(3).Header.Caption = "Orden de " + vbCrLf + "Cliente"
                .Bands(0).Columns(5).Header.Caption = "Agente " + vbCrLf + "Pedido"
                .Bands(0).Columns(6).Header.Caption = "Fecha de " + vbCrLf + "Captura"
                .Bands(0).Columns(7).Header.Caption = "Fecha de " + vbCrLf + "Entrega"
                .Bands(0).Columns(8).Header.Caption = "Agente " + vbCrLf + "Actual"
            ElseIf tipoConsulta = 2 Then
                .Bands(0).Columns(2).Header.Caption = "Docto SAY"
                .Bands(0).Columns(5).Header.Caption = "Folio " + vbCrLf + "Factura"
                .Bands(0).Columns(6).Header.Caption = "Fecha " + vbCrLf + "Documento"
                .Bands(0).Columns(7).Header.Caption = "Razón Social"
                .Bands(0).Columns(10).Hidden = True
            End If


            '.Bands(0).Columns(1).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            '.Bands(0).Columns(2).PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
            .Scrollbars = Scrollbars.Both

            If .Bands(0).Columns.Exists("Pares") Then
                With .Bands(0)
                    .Columns("Pares").AllowRowSummaries = AllowRowSummaries.True
                    Dim configuracionDeSuma As SummarySettings = .Summaries.Add(SummaryType.Sum, gridListadoParametros.DisplayLayout.Bands(0).Columns("Pares"))
                    configuracionDeSuma.DisplayFormat = "{0}"
                    configuracionDeSuma.Appearance.TextHAlign = HAlign.Right
                    .SummaryFooterCaption = "Total:"
                End With
            End If
        End With
        asignaFormato_Columna(gridListadoParametros)
    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In gridListadoParametros.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub gridListadoParametros_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListadoParametros.ClickCell
        If Not Me.gridListadoParametros.ActiveRow.IsDataRow Then Return

        If IsNothing(gridListadoParametros.ActiveRow) Then Return

        If gridListadoParametros.ActiveRow.Cells(" ").Value Then
            gridListadoParametros.ActiveRow.Cells(" ").Value = False
        Else
            gridListadoParametros.ActiveRow.Cells(" ").Value = True
        End If


        Dim marcados As Integer
        For Each row As UltraGridRow In gridListadoParametros.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If marcados > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub
End Class