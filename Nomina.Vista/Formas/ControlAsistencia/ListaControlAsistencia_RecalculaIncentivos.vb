Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Nomina.Negocios
Imports Tools
Public Class ListaControlAsistencia_RecalculaIncentivos
    Public PeriodoID As Integer
    Public NaveID As Integer
    Dim errorMensaje As New ErroresForm
    Dim exitoMensaje As New ExitoForm

    Private Sub ListaControlAsistencia_RecalculaIncentivos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ObtenerListaColaboradoresSinIncentivos()
    End Sub


    Public Sub ObtenerListaColaboradoresSinIncentivos()
        Dim objBU As New ControlAsistenciaBU
        Dim dtColaboradoresSinIncentivos As New DataTable

        grdIncentivos.DataSource = Nothing
        vwIncentivos.Columns.Clear()

        dtColaboradoresSinIncentivos = objBU.ObtieneListaColaboradoresSinIncentivos(PeriodoID, NaveID)

        If dtColaboradoresSinIncentivos.Rows.Count > 0 Then
            grdIncentivos.DataSource = dtColaboradoresSinIncentivos
            lblTotalSeleccionados.Text = CDbl(vwIncentivos.RowCount.ToString()).ToString("n0")
            DiseñoGrid()
        Else

        End If

    End Sub

    Private Sub DiseñoGrid()
        vwIncentivos.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwIncentivos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> "Asistencias" Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwIncentivos.IndicatorWidth = 40

        vwIncentivos.Columns.ColumnByFieldName("Colaborador").Width = 250
        vwIncentivos.Columns.ColumnByFieldName("ReMenor").Width = 40
        vwIncentivos.Columns.ColumnByFieldName("ReMayor").Width = 40
        vwIncentivos.Columns.ColumnByFieldName("FaltasReales").Width = 90
        vwIncentivos.Columns.ColumnByFieldName("Asistencias").Width = 80
        vwIncentivos.Columns.ColumnByFieldName("DiasSemana").Width = 80
        vwIncentivos.Columns.ColumnByFieldName("FaltasNuevo").Width = 80
        vwIncentivos.Columns.ColumnByFieldName("PyA").Width = 40
        vwIncentivos.Columns.ColumnByFieldName("Caja").Width = 40

        vwIncentivos.Columns.ColumnByFieldName("Asistencias").Caption = "Asistencias"
        vwIncentivos.Columns.ColumnByFieldName("FaltasNuevo").Caption = "Faltas Nuevo"
        vwIncentivos.Columns.ColumnByFieldName("ReMenor").Caption = "Rm"
        vwIncentivos.Columns.ColumnByFieldName("ReMayor").Caption = "RM"
        vwIncentivos.Columns.ColumnByFieldName("FaltasReales").Caption = "Faltas Reales"

        vwIncentivos.Columns.ColumnByFieldName("ColaboradorID").Visible = False

        vwIncentivos.Appearance.HeaderPanel.Options.UseBackColor = True

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = vwIncentivos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub

    Private Sub vwIncentivos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwIncentivos.CustomDrawRowIndicator

        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        exitoMensaje.mensaje = "¿Desea guardar los cambios?"
        exitoMensaje.ShowDialog()
        Me.BeginInvoke(New MethodInvoker(AddressOf Close))

    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub vwIncentivos_CustomDrawColumnHeader(sender As Object, e As ColumnHeaderCustomDrawEventArgs) Handles vwIncentivos.CustomDrawColumnHeader
        If e.Column Is Nothing OrElse e.Column.FieldName <> "Asistencias" Then
            Return
        End If
        e.Cache.FillRectangle(Color.Coral, e.Bounds)
        e.Appearance.DrawString(e.Cache, e.Info.Caption, e.Info.CaptionRect)
        For Each info As DrawElementInfo In e.Info.InnerElements
            If Not info.Visible Then
                Continue For
            End If
            ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo)
        Next info
        e.Handled = True
    End Sub

    Private Sub vwIncentivos_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles vwIncentivos.CellValueChanged

        Dim Asistencias As Integer = 0
        Dim ColaboradorID As Integer = 0
        Dim CalculoFaltasNuevo As Integer = 0
        Dim FaltasReales As Integer = 0
        Dim dtModificaCorteIncentivos As New DataTable
        Dim objBU As New ControlAsistenciaBU
        Dim GanaIncentivos As Boolean = False

        If e.Column.FieldName.Equals("Asistencias") Then

            Asistencias = vwIncentivos.GetRowCellValue(e.RowHandle, "Asistencias")
            ColaboradorID = vwIncentivos.GetRowCellValue(e.RowHandle, "ColaboradorID")
            FaltasReales = vwIncentivos.GetRowCellValue(e.RowHandle, "FaltasReales")

            CalculoFaltasNuevo = Asistencias - 6
            vwIncentivos.SetRowCellValue(e.RowHandle, "FaltasNuevo", CalculoFaltasNuevo)

            If CalculoFaltasNuevo = 0 Then
                vwIncentivos.SetRowCellValue(e.RowHandle, "PyA", "SI")
                vwIncentivos.SetRowCellValue(e.RowHandle, "Caja", "SI")
                GanaIncentivos = True
            End If


            dtModificaCorteIncentivos = objBU.ModificaCorteIncentivos(PeriodoID, ColaboradorID, CalculoFaltasNuevo)

            If dtModificaCorteIncentivos.Rows(0).Item("mensaje").ToString = "ERROR" Then
                errorMensaje.mensaje = "Ocurrió un error al actualizar los datos, intente de nuevo."
                errorMensaje.ShowDialog()
            Else


            End If

        End If

    End Sub

    Private Sub vwIncentivos_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles vwIncentivos.RowCellStyle
        Dim Valor As String = String.Empty
        Dim Caja As String = String.Empty

        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Caja" Then
                Valor = vwIncentivos.GetRowCellValue(e.RowHandle, "Caja").ToString.Trim.ToUpper

                If Valor.Equals("SI") Then
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                    e.Appearance.ForeColor = Color.DarkGreen
                    e.Appearance.BackColor = Color.Transparent
                End If

            End If

            If e.Column.FieldName = "PyA" Then
                Valor = vwIncentivos.GetRowCellValue(e.RowHandle, "PyA").ToString.Trim.ToUpper

                If Valor.Equals("SI") Then
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                    e.Appearance.ForeColor = Color.DarkGreen
                    e.Appearance.BackColor = Color.Transparent
                End If

            End If
        End If

    End Sub

    Private Sub vwIncentivos_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles vwIncentivos.ValidatingEditor
        Select Case vwIncentivos.FocusedColumn.FieldName
            Case "Asistencias"
                Dim num As Integer
                If IsNumeric(e.Value) Then
                    If Convert.ToInt32(e.Value) < 0 Or Convert.ToInt32(e.Value) <> 6 Then
                        e.Valid = False
                    End If
                Else
                    If Not Integer.TryParse(e.Value, num) Then
                        e.Valid = False
                    End If
                End If
        End Select
    End Sub

    Private Sub vwIncentivos_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles vwIncentivos.InvalidValueException
        Select Case vwIncentivos.FocusedColumn.FieldName
            Case "Asistencias"
                e.ErrorText = "El valor ingresado debe ser numérico y no puede ser diferente de 6."
        End Select
    End Sub


End Class