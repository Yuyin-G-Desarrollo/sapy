Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class PorcentajeInspeccionClienteForm

    Dim ObjBu As New Almacen.Negocios.InspeccionCalidadBU

    Private Sub PorcentajeInspeccionClienteForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        CargarListadoClientes()

    End Sub

    Private Sub CargarListadoClientes()
        Try
            Dim dtResultado As New DataTable
            dtResultado = ObjBu.ConsultaListadoClientesPorcentajeInspeccion()
            grdListadoCliente.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(viewListadoCliente)
            DiseñoGrid.EstiloColumna(viewListadoCliente, "Cliente", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewListadoCliente, "PorcentajeInspeccion", "Porcentaje inspección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, True, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "")
            viewListadoCliente.IndicatorWidth = 30
            viewListadoCliente.OptionsView.ColumnAutoWidth = True

            lblTotalRegistros.Text = CDbl(dtResultado.Rows.Count).ToString("N0")
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub
    Private Sub viewListadoCliente_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewListadoCliente.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub viewListadoCliente_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles viewListadoCliente.ValidatingEditor
        Dim Porcentaje As String = String.Empty
        Dim ParesDocumentados As Integer = 0
        Dim indexFila As Integer = 0

        If viewListadoCliente.FocusedRowHandle >= 0 Then
            Porcentaje = viewListadoCliente.GetRowCellValue(viewListadoCliente.FocusedRowHandle, "PorcentajeInspeccion")
            'ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "Documentado")
            If IsNumeric(e.Value) = False Then
                e.Valid = False
                e.ErrorText = "Formato invalido."
            ElseIf e.Value < 0 Then
                e.Valid = False
                e.ErrorText = "El número de pares tiene que ser mayor a 0."
            ElseIf e.Value > 100 Then
                e.Valid = False
                e.ErrorText = "El porcentaje tiene que ser menor a 100."
            End If

            'If e.Valid = False Then
            '    FormatoInvalido = True


            'Else
            '    FormatoInvalido = False
            'End If

            'If FormatoInvalido = False Then
            '    indexFila = viewPartidas.FocusedRowHandle
            '    CargarTotalesDocumento(viewPartidas.FocusedRowHandle, e.Value)
            '    If indexFila < viewPartidas.DataRowCount Then
            '        viewPartidas.FocusedRowHandle = indexFila + 1
            '    End If


            'End If
        End If
    End Sub

    Private Sub viewListadoCliente_KeyUp(sender As Object, e As KeyEventArgs) Handles viewListadoCliente.KeyUp
        Dim IndexFila As Integer = -1
        If e.KeyCode = "13" Then
            IndexFila = viewListadoCliente.FocusedRowHandle
            If IndexFila < viewListadoCliente.DataRowCount Then
                viewListadoCliente.FocusedRowHandle = IndexFila + 1
            End If

            'If FormatoInvalido = False Then
            '    IndexFila = viewListadoCliente.FocusedRowHandle
            '    If IndexFila < viewListadoCliente.DataRowCount Then
            '        viewListadoCliente.FocusedRowHandle = IndexFila + 1
            '    End If
            '    'CargarTotalesDocumento()
            'End If
        End If
    End Sub
End Class