Imports Infragistics.Win.UltraWinGrid
Imports Entidades
Imports Tools

Public Class ColoresClientesForm
    Dim codigoCliente As String
    Dim nombreCliente As String
    '///LLenar Combos'
    Public Sub llenarComboClientes()
        Dim objColCli As New Programacion.Negocios.ColoresClientesBU
        Dim dtClientes As New DataTable
        dtClientes = objColCli.ClientesCodigosEspeciales
        If Not dtClientes.Rows.Count = 0 Then
            dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)
            cmbClientes.DataSource = dtClientes
            cmbClientes.DisplayMember = "clie_razonsocial"
            cmbClientes.ValueMember = "clie_clienteid"
        End If
    End Sub
    '///Botones'
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    '//Metodos
    Private Sub ColoresClientesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientes()
        cmbClientes.SelectedIndex = 1
        codigoCliente = " "
        nombreCliente = " "
    End Sub
    Public Sub llenarTablaColores()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ColoresClientesBU
        Dim dtColoresCli As New DataTable
        Dim idCliente As Int32 = 0
        grdListaColoresClientes.DataSource = Nothing
        If cmbClientes.SelectedIndex > 0 Then
            idCliente = cmbClientes.SelectedValue
        End If

        If (rdoListaPrecios.Checked) Then
            dtColoresCli = objBU.TablaColoresClientesListaPrecios(idCliente)
        Else
            dtColoresCli = objBU.TablaColoresClientesColoresActivos(idCliente)
        End If

        If dtColoresCli.Rows.Count > 0 Then
            grdListaColoresClientes.DataSource = dtColoresCli
            disenioGrid()
        Else
            grdListaColoresClientes.DataSource = Nothing
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedIndexChanged
        If (cmbClientes.SelectedIndex > 0) Then
            llenarTablaColores()
        End If
    End Sub
    Public Sub disenioGrid()
        With grdListaColoresClientes.DisplayLayout.Bands(0)
            .Columns("idColorCliente").Hidden = True
            .Columns("Código").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("Código").Width = 14
            .Columns("Nombre").Width = 90
            .Columns("CódigoCliente").Width = 27
            .Columns("SICY").Width = 15
            .Columns("NombreCliente").MaxLength = 50
            .Columns("NombreCliente").CharacterCasing = CharacterCasing.Upper
            .Columns("CódigoCliente").MaxLength = 50
            .Columns("CódigoCliente").CharacterCasing = CharacterCasing.Upper

        End With

        grdListaColoresClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaColoresClientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaColoresClientes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    End Sub

    Private Sub grdListaColoresClientes_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdListaColoresClientes.AfterCellUpdate

    End Sub

    Private Sub grdListaColoresClientes_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdListaColoresClientes.BeforeCellUpdate
        If cmbClientes.SelectedIndex > 0 Then
            If e.Cell.Row.IsFilterRow = False Then
                If e.Cell.Column.ToString = "CódigoCliente" Then
                    If cmbClientes.SelectedValue > 0 Then
                        codigoCliente = e.NewValue.ToString
                    End If
                ElseIf e.Cell.Column.ToString = "NombreCliente" Then
                    If cmbClientes.SelectedValue > 0 Then
                        nombreCliente = e.NewValue.ToString
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdListaColoresClientes_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdListaColoresClientes.BeforeRowUpdate
        If cmbClientes.SelectedIndex > 0 Then
            If e.Row.IsFilterRow = False Then
                If codigoCliente.Equals(" ") And nombreCliente.Equals(" ") Then
                    'Posible mensaje de completar campos
                Else
                    If cmbClientes.SelectedValue > 0 Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "¿Estás seguro de guardar los cambios?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim objBU As New Negocios.ColoresClientesBU
                            Dim mensj As String
                            Dim idPielCliente As Integer
                            idPielCliente = grdListaColoresClientes.ActiveRow.Cells("idColorCliente").Value
                            codigoCliente = grdListaColoresClientes.ActiveRow.Cells("CódigoCliente").Value
                            nombreCliente = grdListaColoresClientes.ActiveRow.Cells("NombreCliente").Value
                            Me.Cursor = Cursors.WaitCursor
                            mensj = objBU.insertarActualizarColoresClientes(idPielCliente,
                        grdListaColoresClientes.ActiveRow.Cells("Código").Value, cmbClientes.SelectedValue,
                        codigoCliente.Trim, nombreCliente.Trim)
                            Me.Cursor = Cursors.Default
                            If mensj.Contains("Error") Then
                                Dim objMensajeError As New Tools.ErroresForm
                                objMensajeError.mensaje = mensj
                                objMensajeError.ShowDialog()
                            Else
                                codigoCliente = " "
                                nombreCliente = " "
                                If idPielCliente = 0 Then
                                    Me.Cursor = Cursors.WaitCursor
                                    llenarTablaColores()
                                    Me.Cursor = Cursors.Default
                                End If
                            End If
                        Else
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Else
            Dim objMensajeError As New Tools.AvisoForm
            objMensajeError.mensaje = "Seleccione un cliente para relacionar el color."
            objMensajeError.ShowDialog()
            e.Cancel = True
        End If
    End Sub

    Private Sub grdListaColoresClientes_Error(sender As Object, e As ErrorEventArgs) Handles grdListaColoresClientes.Error
        If e.ErrorText.Contains("Unable to update the data value: No se puede obtener acceso al objeto desechado.") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub grdListaColoresClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdListaColoresClientes.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                grdListaColoresClientes.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdListaColoresClientes.DisplayLayout.Bands(0)
                If grdListaColoresClientes.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdListaColoresClientes.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdListaColoresClientes.ActiveCell = nextRow.Cells(grdListaColoresClientes.ActiveCell.Column)
                    e.Handled = True
                    grdListaColoresClientes.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdoListaPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles rdoListaPrecios.CheckedChanged
        If (cmbClientes.SelectedIndex > 0) Then
            llenarTablaColores()
        End If
    End Sub

    Private Sub rdoColores_CheckedChanged(sender As Object, e As EventArgs) Handles rdoColores.CheckedChanged
        If (cmbClientes.SelectedIndex > 0) Then
            llenarTablaColores()
        End If
    End Sub

    Private Sub grdListaColoresClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaColoresClientes.InitializeLayout

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If grdListaColoresClientes.ActiveRow.Selected Then
                Dim form As New ColorClienteAltaEditar
                Dim p As New ColorCliente
                form.colorCliente.codigoClienteColor = grdListaColoresClientes.ActiveRow.Cells("CódigoCliente").Value
                form.colorCliente.codigoSICYColor = grdListaColoresClientes.ActiveRow.Cells("SICY").Value
                form.colorCliente.idCliente = cmbClientes.SelectedValue
                form.colorCliente.idColor = grdListaColoresClientes.ActiveRow.Cells("Código").Value
                form.colorCliente.nombreClienteColor = grdListaColoresClientes.ActiveRow.Cells("NombreCliente").Value
                form.colorCliente.idColorCliente = grdListaColoresClientes.ActiveRow.Cells("idColorCliente").Value
                form.ShowDialog()
                llenarTablaColores()
            Else
                Dim adv As New AdvertenciaForm
                adv.mensaje = "Selecciona un registro"
                adv.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If cmbClientes.SelectedValue > 0 Then
                Dim form As New ColorClienteAltaEditar
                form.colorCliente.idCliente = cmbClientes.SelectedValue
                form.ShowDialog()
                llenarTablaColores()
            Else
                Dim objMensajeError As New Tools.AdvertenciaForm
                objMensajeError.mensaje = "Seleccione un cliente"
                objMensajeError.ShowDialog()
            End If
        Catch ex As Exception
            Dim objMensajeError As New Tools.AdvertenciaForm
            objMensajeError.mensaje = "Seleccione un cliente"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub grdListaColoresClientes_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaColoresClientes.ClickCell
        Try
            grdListaColoresClientes.ActiveRow.Selected = True
        Catch ex As Exception

        End Try
    End Sub
End Class