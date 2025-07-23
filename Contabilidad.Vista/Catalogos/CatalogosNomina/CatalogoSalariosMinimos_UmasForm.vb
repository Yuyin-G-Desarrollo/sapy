Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class CatalogoSalariosMinimos_UmasForm
    Dim ObjBU As New Negocios.CatalogoSalariosMinimos_UmasBU
    Private Sub CatalogoSalariosMinimos_Umas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PoblarGrid()
        ConsultaPrecio_SalarioMIN_UMA()
    End Sub
    Public Sub PoblarGrid()
        Try
            Dim ObjB As New Contabilidad.Negocios.CatalogoSalariosMinimos_UmasBU
            Dim dataTable = ObjB.ConsultaBitacoraPrecio_SalarioMIN_UMA
            grdSalariosUMAS.DataSource = dataTable
            DiseñoGrid.DiseñoBaseGrid(viewSalariosUMAS)
            viewSalariosUMAS.IndicatorWidth = 35
            viewSalariosUMAS.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewSalariosUMAS, "SalarioMinimo", "Salario Minimo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewSalariosUMAS, "UMA", "Monto UMA", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 130, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewSalariosUMAS, "UMI", "Monto UMI", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 178, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewSalariosUMAS, "Usuario", "Usuario Modifico", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 190, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewSalariosUMAS, "FechaM", "Fecha Modificación", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 178, False, Nothing, "")
            lblTotalRegistros.Text = dataTable.Rows.Count
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim listado As New EditarSalariosMinimos_UmasForm
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog()
        PoblarGrid()
        ConsultaPrecio_SalarioMIN_UMA()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        ConsultaPrecio_SalarioMIN_UMA()
        PoblarGrid()
        MessageBox.Show("Se actualizaron los datos")
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Public Sub ConsultaPrecio_SalarioMIN_UMA()
        Dim listaentidad = ObjBU.ConsultaPrecio_SalarioMIN_UMA()
        txtsalarioM.Text = listaentidad(0).MontoSalarioMinimo
        txtuma.Text = listaentidad(1).MontoSalarioMinimo
        txtumi.Text = listaentidad(2).MontoSalarioMinimo
    End Sub
    Private Sub viewSalariosMinimos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewSalariosUMAS.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

End Class