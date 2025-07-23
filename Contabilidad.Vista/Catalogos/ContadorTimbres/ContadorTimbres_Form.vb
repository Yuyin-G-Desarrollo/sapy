Imports System.Windows.Forms
Imports Tools

Public Class ContadorTimbres_Form
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub ContadorTimbres_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrarContadordeTimbres()
    End Sub

    Private Sub mostrarContadordeTimbres()
        Me.Cursor = Cursors.WaitCursor
        Dim objBu As New Negocios.CatalogosBU
        Dim dtContadordeTimbres As New DataTable
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        dtContadordeTimbres = objBu.consultaContadordeTimbres


        If dtContadordeTimbres.Rows.Count > 0 Then
            grdContadordeTimbres.DataSource = dtContadordeTimbres
            DiseñoGrid.DiseñoBaseGrid(viewContadordeTimbres)
            viewContadordeTimbres.IndicatorWidth = 35
            viewContadordeTimbres.OptionsView.ColumnAutoWidth = True
            viewContadordeTimbres.Columns.ColumnByFieldName("Inicial").DisplayFormat.FormatString = "#,##00"
            ' DiseñoGrid.EstiloColumna(viewDiasFestivos, "Descripcion", "Descripción", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 300, False, Nothing, "")
            'DiseñoGrid.EstiloColumna(viewContadordeTimbres, "Fecha Compra", "Fecha Compra", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 169, False, Nothing, "")
        Else
            objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
            objMensajeAdv.Show()
            grdContadordeTimbres.DataSource = dtContadordeTimbres
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class