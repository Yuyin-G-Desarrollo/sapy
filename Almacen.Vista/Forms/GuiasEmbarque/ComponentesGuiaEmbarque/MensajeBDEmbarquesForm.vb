Imports DevExpress.XtraGrid.Views.Base
Imports Tools

Public Class MensajeBDEmbarquesForm
    Public mensajes As DataTable

    Private Sub MensajeBDEmbarquesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recibirDatos()
    End Sub

    Private Sub recibirDatos()
        grdmensajeEmbarques.DataSource = mensajes

        DiseñoGrid.DiseñoBaseGrid(vwmensajeEmbarque)
        DiseñoGrid.EstiloColumna(vwmensajeEmbarque, "mostrar", "mostrar", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, True, 60, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwmensajeEmbarque, "Estatus", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwmensajeEmbarque, "mensaje", "Mensaje", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "#,0#")
        vwmensajeEmbarque.OptionsView.ColumnAutoWidth = True
        vwmensajeEmbarque.IndicatorWidth = 35

        lblTotalParesProceso.Text = String.Format("{0:N0}", mensajes.Rows.Count)
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub viewModelos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwmensajeEmbarque.CustomDrawCell



        Dim status = vwmensajeEmbarque.GetRowCellValue(e.RowHandle, "Estatus")


        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Estatus" Then
                If status = 1 Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.Red
                ElseIf status = 0 Then
                    e.Appearance.BackColor = Color.Green
                    e.Appearance.ForeColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.Red
                End If
            End If

        End If


    End Sub
End Class