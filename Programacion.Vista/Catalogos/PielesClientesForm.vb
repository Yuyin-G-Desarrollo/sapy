Imports Infragistics.Win.UltraWinGrid
Imports Entidades
Imports Tools

Public Class PielesClientesForm
    Dim codigoCliente As String
    Dim nombreCliente As String

    '///LLenar Combos'
    Public Sub llenarComboClientes()
        Dim objColCli As New Programacion.Negocios.PielesClientesBU
        Dim dtClientes As New DataTable
        dtClientes = objColCli.ClientesCodigosEspeciales
        If Not dtClientes.Rows.Count = 0 Then
            dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)
            cmbClientes.DataSource = dtClientes
            cmbClientes.DisplayMember = "clie_razonsocial"
            cmbClientes.ValueMember = "clie_clienteid"
        End If
    End Sub
    '///Métodos
    Private Sub PielesClientesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientes()
        cmbClientes.SelectedIndex = 1
        codigoCliente = " "
        nombreCliente = " "

    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Public Sub llenarTablaPieles()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.PielesClientesBU
        Dim dtColoresCli As New DataTable
        Dim idCliente As Int32 = 0
        grdListaPielesClientes.DataSource = Nothing
        If cmbClientes.SelectedIndex > 0 Then
            idCliente = cmbClientes.SelectedValue
        End If

        If (rdoListaPrecios.Checked) Then
            dtColoresCli = objBU.TablaPielesClientesListaPrecios(idCliente)
        Else
            dtColoresCli = objBU.TablaPielesClientesColoresActivos(idCliente)
        End If

        If dtColoresCli.Rows.Count > 0 Then
            grdListaPielesClientes.DataSource = dtColoresCli
            disenioGrid()
        Else
            grdListaPielesClientes.DataSource = Nothing
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub disenioGrid()
        With grdListaPielesClientes.DisplayLayout.Bands(0)
            .Columns("idPielCliente").Hidden = True
            .Columns("Código").Hidden = True
            .Columns("Código").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Corto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("Código").Width = 25
            .Columns("Nombre").Width = 90
            .Columns("Corto").Width = 80
            .Columns("CódigoCliente").Width = 40
            .Columns("SICY").Width = 20

            .Columns("NombreCliente").MaxLength = 50
            .Columns("NombreCliente").CharacterCasing = CharacterCasing.Upper
            .Columns("CódigoCliente").MaxLength = 50
            .Columns("CódigoCliente").CharacterCasing = CharacterCasing.Upper

        End With

        grdListaPielesClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListaPielesClientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaPielesClientes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    End Sub
    Private Sub grdListaPielesClientes_Error(sender As Object, e As ErrorEventArgs) Handles grdListaPielesClientes.Error
        If e.ErrorText.Contains("Unable to update the data value: No se puede obtener acceso al objeto desechado.") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub grdListaPielesClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdListaPielesClientes.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                grdListaPielesClientes.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdListaPielesClientes.DisplayLayout.Bands(0)
                If grdListaPielesClientes.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdListaPielesClientes.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdListaPielesClientes.ActiveCell = nextRow.Cells(grdListaPielesClientes.ActiveCell.Column)
                    e.Handled = True
                    grdListaPielesClientes.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedIndexChanged
        If (cmbClientes.SelectedIndex > 0) Then
            llenarTablaPieles()
        End If
    End Sub

    Private Sub grdListaPielesClientes_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdListaPielesClientes.BeforeCellUpdate
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
    Private Sub rdoPieles_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPieles.CheckedChanged
        If (cmbClientes.SelectedIndex > 0) Then
            llenarTablaPieles()
        End If
    End Sub
    Private Sub rdoListaPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles rdoListaPrecios.CheckedChanged
        If (cmbClientes.SelectedIndex > 0) Then
            llenarTablaPieles()
        End If
    End Sub

    Private Sub grdListaPielesClientes_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles grdListaPielesClientes.BeforeRowUpdate
        If cmbClientes.SelectedIndex > 0 Then
            If e.Row.IsFilterRow = False Then
                If codigoCliente.Equals(" ") And nombreCliente.Equals(" ") Then
                    'Posible mensaje de completar campos
                Else
                    If cmbClientes.SelectedValue > 0 Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "¿Estás seguro de guardar los cambios?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim objBU As New Negocios.PielesClientesBU
                            Dim mensj As String = String.Empty
                            Dim idPielCliente As Integer
                            idPielCliente = grdListaPielesClientes.ActiveRow.Cells("idPielCliente").Value
                            codigoCliente = grdListaPielesClientes.ActiveRow.Cells("CódigoCliente").Value
                            nombreCliente = grdListaPielesClientes.ActiveRow.Cells("NombreCliente").Value
                            Me.Cursor = Cursors.WaitCursor
                            'mensj = objBU.insertarActualizarPielesClientes(idPielCliente,
                            'grdListaPielesClientes.ActiveRow.Cells("Código").Value, cmbClientes.SelectedValue,
                            'codigoCliente.Trim, nombreCliente.Trim)
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
                                    llenarTablaPieles()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If cmbClientes.SelectedValue > 0 Then
                Dim form As New PielClienteAltaEditar
                form.pielCliente.idCliente = cmbClientes.SelectedValue
                form.ShowDialog()
                llenarTablaPieles()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If grdListaPielesClientes.ActiveRow.Selected Then
                Dim form As New PielClienteAltaEditar
                Dim p As New PielCliente
                form.pielCliente.codigoClientePiel = grdListaPielesClientes.ActiveRow.Cells("CódigoCliente").Value
                form.pielCliente.codigoSICYPiel = grdListaPielesClientes.ActiveRow.Cells("SICY").Value
                form.pielCliente.idCliente = cmbClientes.SelectedValue
                form.pielCliente.idPiel = grdListaPielesClientes.ActiveRow.Cells("Código").Value
                form.pielCliente.nombreClientePiel = grdListaPielesClientes.ActiveRow.Cells("NombreCliente").Value
                form.pielCliente.idPielCliente = grdListaPielesClientes.ActiveRow.Cells("idPielCliente").Value
                form.ShowDialog()
                llenarTablaPieles()
            Else
                Dim adv As New AdvertenciaForm
                adv.mensaje = "Selecciona un registro"
                adv.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdListaPielesClientes_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaPielesClientes.ClickCell
        Try
            grdListaPielesClientes.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class