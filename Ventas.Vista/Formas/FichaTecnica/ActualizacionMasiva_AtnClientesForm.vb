Imports Tools
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ActualizacionMasiva_AtnClientesForm

    Private Sub ActualizacionMasiva_AtnClientesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Me.Left = 0
        Me.Top = 0

        ListaAtnCliente()
        ListaVendedor()
        poblar_gridListaCliente(gridListaCliente)
    End Sub

    Private Sub ListaAtnCliente()


        Try
            Controles.ComboAtnCliente(cboxClienteAtnClientes)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaVendedor()

        Try
            Controles.ComboNombreVendedorSegunCliente(cboxClienteVendedor)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub chboxMarcarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxMarcarTodo.CheckedChanged
        If chboxMarcarTodo.Checked Then
            For Each row In gridListaCliente.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row In gridListaCliente.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In gridListaCliente.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString
    End Sub

    Private Sub rbtnAtnClientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnAtnClientes.CheckedChanged
        If rbtnAtnClientes.Checked Then
            cboxClienteAtnClientes.Enabled = True
        Else
            cboxClienteAtnClientes.Enabled = False
        End If
    End Sub

    Private Sub rbtnAgenteVentas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnAgenteVentas.CheckedChanged
        If rbtnAgenteVentas.Checked Then
            cboxClienteVendedor.Enabled = True
        Else
            cboxClienteVendedor.Enabled = False
        End If
    End Sub

    Private Sub btnGuardarCliente_Click(sender As Object, e As EventArgs) Handles btnGuardarCliente.Click

        Dim mensajeTextDialog As New TextDialogForm
        mensajeTextDialog.mensaje = "¿Desea actualizar los registros seleccionados? " + Environment.NewLine + "Para continuar escriba la palabra ACTUALIZAR" + Environment.NewLine
        mensajeTextDialog.ShowDialog()

        If mensajeTextDialog.DialogResult = Windows.Forms.DialogResult.OK Then
            If String.IsNullOrEmpty(mensajeTextDialog.txtParam.Text) Then Return
            If mensajeTextDialog.txtParam.Text = "ACTUALIZAR" Then
                If gridListaCliente.Rows.Count = 0 Then Return

                Dim grid As DataTable = gridListaCliente.DataSource
                Dim objBU As New Negocios.ClientesBU
                For Each row As UltraGridRow In gridListaCliente.Rows
                    If rbtnAtnClientes.Checked Then
                        If CBool(row.Cells(" ").Value) Then
                            objBU.Asignacion_Masiva_Atn_Clientes(CInt(row.Cells("ID SAY").Value), CInt(cboxClienteAtnClientes.SelectedValue))
                            objBU.Asignacion_Masiva_Atn_Clientes_SICY(CInt(row.Cells("ID SICY").Value), CInt(cboxClienteAtnClientes.SelectedValue))
                        End If
                    End If
                    If rbtnAgenteVentas.Checked Then
                        If CBool(row.Cells(" ").Value) Then
                            objBU.Asignacion_Masiva_Agente_Ventas(CInt(row.Cells("ID SAY").Value), CInt(cboxClienteVendedor.SelectedValue))
                            objBU.Asignacion_Masiva_Agente_Ventas_SICY(CInt(row.Cells("ID SICY").Value), CInt(cboxClienteVendedor.SelectedValue))
                        End If
                    End If
                Next
                'INICIA ACTUALIZA TABLA DE CLIENTES REPLICA DE SAY EN SICY
                objBU.actualizarClientesSICY()
                'TERMINA ACTUALIZA TABLA DE CLIENTES REPLICA DE SAY EN SICY
                show_message("Exito", "Se asignó el nuevo colaborador de Atención a Clientes con éxito.")
                chboxMarcarTodo.Checked = False
                poblar_gridListaCliente(gridListaCliente)
                lblNumFiltrados.Text = "0"

            Else
                show_message("Aviso", "No se actualizó ningun cliente")
            End If
        End If

    End Sub

    Private Sub btnCancelarCliente_Click(sender As Object, e As EventArgs) Handles btnCancelarCliente.Click
        Me.Close()
    End Sub

    'Muestra el form de mensaje
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

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeConfirmar As New ConfirmarForm
            mensajeConfirmar.mensaje = mensaje
            mensajeConfirmar.ShowDialog()

        End If

        If tipo.ToString.Equals("Text") Then

            Dim mensajeText As New TextDialogForm
            mensajeText.mensaje = mensaje
            mensajeText.ShowDialog()

        End If

    End Sub

    'Asigna formato a columnas de ultragrid
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

    'Acciones grid Lista de Clientes
    Public Sub poblar_gridListaCliente(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.ClientesBU
        Dim ListaCliente As New DataTable

        ListaCliente = objBU.ListaCliente_ActualizacionMasiva()

        grid.DataSource = ListaCliente

        gridListaClienteDiseno(grid)

    End Sub

    Private Sub gridListaClienteDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        asignaFormato_Columna(grid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

        Me.gridListaCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
        Me.gridListaCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

        gridListaCliente.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti

    End Sub

    Private Sub asignar_grid_gridListaCliente(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        gridListaCliente = grid

    End Sub

    Private Sub gridListaCliente_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridListaCliente.MouseDoubleClick
        If gridListaCliente.ActiveRow.Index >= 0 Then
            If IsNothing(gridListaCliente.ActiveRow) Then Return

            If gridListaCliente.ActiveRow.Cells(" ").Value Then

                gridListaCliente.ActiveRow.Cells(" ").Value = False
            Else
                gridListaCliente.ActiveRow.Cells(" ").Value = True
            End If
            Dim marcados As Integer
            For Each row As UltraGridRow In gridListaCliente.Rows
                If CBool(row.Cells(" ").Value) Then
                    marcados += 1
                End If
            Next
            lblNumFiltrados.Text = marcados.ToString
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim SaveFileDialog As New SaveFileDialog
        Dim NombreArchivo As String = "Atención_Clientes"
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter

        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"


        Dim FileName As String = SaveFileDialog.FileName
        If SaveFileDialog.ShowDialog = DialogResult.OK Then
            gridExcelExporter.Export(Me.gridListaCliente, FileName)

            Dim msg_exito As New Tools.ExitoForm
            msg_exito.mensaje = "Los datos se exportaron correctamente"
            msg_exito.ShowDialog()

            System.Diagnostics.Process.Start(FileName)

        End If
    End Sub
End Class