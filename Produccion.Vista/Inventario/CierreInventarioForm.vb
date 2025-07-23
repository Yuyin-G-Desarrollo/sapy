Imports Tools
Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid

Public Class CierreInventarioForm

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim confir As New ConfirmarAdvertenciaForm
        If confir.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim form As New ResumenInventarioProcesoForm
            form.ShowDialog()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CierreInventarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaControles()
    End Sub

    Public Sub cargaControles()
        llenarComboNaves()
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Public Sub llenarComboNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        Dim obj As New InventarioBU
        If cmbNave.SelectedIndex > 0 Then
            grdInventario.DataSource = obj.getCierres(cmbNave.SelectedValue, dtpFechaInicio.Value)
            Try
                With grdInventario.DisplayLayout.Bands(0)
                    .Columns("innc_total").Format = "##,##0.00"
                    .Columns("innc_precio").Format = "##,##0.00"
                    .Columns("innc_entradas").Format = "##,##0.00"
                    .Columns("innc_salidas").Format = "##,##0.00"
                    .Columns("mate_descripcion").Width = 300
                    .Columns("prov_razonsocial").Width = 300
                    .Columns("mate_descripcion").Header.Caption = "Material"
                    .Columns("prov_razonsocial").Header.Caption = "Proveedor"
                    .Columns("innc_entradas").Header.Caption = "Entradas"
                    .Columns("innc_salidas").Header.Caption = "Salidas"
                    .Columns("innc_total").Header.Caption = "Total"
                    .Columns("innc_precio").Header.Caption = "Precio"
                    .Columns("innc_fechacierre").Header.Caption = "Fecha Cierre"
                    .Columns("innc_total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    .Columns("innc_precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    .Columns("innc_entradas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    .Columns("innc_salidas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                End With
            Catch ex As Exception

            End Try
            grdInventario.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdInventario.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            grdInventario.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        End If

    End Sub

    Private Sub grdInventario_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdInventario.ClickCell
        Try
            grdInventario.ActiveRow.Selected = True
        Catch ex As Exception

        End Try
    End Sub
End Class