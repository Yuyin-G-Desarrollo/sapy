Imports DevExpress.XtraGrid.Views.Base

Public Class PedidosMuestras_EntradasSalidas_FoliosEnvio

    Public NaveID As Integer
    Public NaveNombre As String
    Public dtFoliosEnviadosNaves As DataTable
    Public PedidosMuestras_SalidasEntradasForm As PedidosMuestras_SalidasEntradas

    Dim FolioSeleccionado As Integer = 0
    Dim Fila_Seleccionada As Integer = 0

    Dim ObjBU As New Negocios.EntradaSalidaMuestrasBU

    Private Sub PedidosMuestras_EntradasSalidas_FoliosEnvio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor

        CargarGrid()
        DiseñoGridEditable(GrdVFoliosEnvios, " ")
        lblNave.Text = NaveNombre

        Cursor = Cursors.Default
    End Sub

    Private Sub CargarGrid()
        GrdFoliosEnvios.DataSource = Nothing
        Try
            GrdFoliosEnvios.DataSource = dtFoliosEnviadosNaves
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DiseñoGridEditable(Grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal ParamArray ColumnasEditables As Object())

        Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 30

        Grid.OptionsView.EnableAppearanceEvenRow = True
        Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = True
        Grid.OptionsSelection.EnableAppearanceFocusedRow = True
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        Grid.Appearance.EvenRow.BackColor = Color.White
        Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next

        For i As Integer = 0 To ColumnasEditables.Length - 1
            Grid.Columns.ColumnByFieldName(ColumnasEditables(i)).OptionsColumn.AllowEdit = True
        Next

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub GrdVFoliosEnvios_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GrdVFoliosEnvios.CellValueChanging
        GrdVFoliosEnvios.SetRowCellValue(Fila_Seleccionada, " ", False)
        If e.Column.ToString = " " Then
            If e.Value = True Then
                FolioSeleccionado = GrdVFoliosEnvios.GetRowCellValue(e.RowHandle, "FolioEnvío")
                lblFolioSeleccionado.Text = FolioSeleccionado
                Fila_Seleccionada = e.RowHandle
            Else
                lblFolioSeleccionado.Text = "-"
                FolioSeleccionado = 0
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If FolioSeleccionado > 0 Then
            PedidosMuestras_SalidasEntradasForm.FolioEnvio = FolioSeleccionado
            Me.Close()
        Else
            Dim msg_Adv As New Tools.AdvertenciaForm
            msg_Adv.mensaje = "Debe seleccionar un folio."
            msg_Adv.ShowDialog()
        End If
    End Sub
End Class