Imports DevExpress.XtraGrid
Imports Programacion.Negocios

Public Class Programacion_ColocacionSemanal_ReAbrirPlan_Form

    Public tabla As DataTable
    Public año As Integer
    Dim objExito As New Tools.ExitoForm

    Private Sub diseñoGrid()
        grdVReporte.OptionsView.ColumnAutoWidth = True
        grdVReporte.OptionsView.EnableAppearanceEvenRow = True
        grdVReporte.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVReporte.IndicatorWidth = 30
        grdVReporte.OptionsView.ShowAutoFilterRow = False
        grdVReporte.OptionsView.RowAutoHeight = True
        grdVReporte.OptionsClipboard.AllowCopy = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next
        grdVReporte.Columns.ColumnByFieldName(" ").Visible = False
        grdVReporte.Columns.ColumnByFieldName("NaveId").Visible = False
        'grdVReporte.Columns.ColumnByFieldName("Capacidad").Visible = False
        'grdVReporte.Columns.ColumnByFieldName("ATR").Visible = False
        'grdVReporte.Columns.ColumnByFieldName("CapacidadOriginal").Visible = False
        'grdVReporte.Columns.ColumnByFieldName("ATROriginal").Visible = False
        grdVReporte.BestFitColumns()
    End Sub
    Private Function generarXML()
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        For i = 0 To grdVReporte.RowCount - 1
            Dim vNodo As XElement = New XElement("Celda")
            vNodo.Add(New XAttribute("NaveId", grdVReporte.GetRowCellValue(i, "NaveId")))
            vNodo.Add(New XAttribute("Semana", grdVReporte.GetRowCellValue(i, "Semana")))
            vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
            vNodo.Add(New XAttribute("Año", grdVReporte.GetRowCellValue(i, "Año")))
            vXmlCeldasModificadas.Add(vNodo)
        Next
        Return vXmlCeldasModificadas
    End Function
    Private Sub Programacion_ColocacionSemanal_ReAbrirPlan_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdReporte.DataSource = tabla
        diseñoGrid()
    End Sub
    Private Sub grdVReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim obj As New Programacion_MapaOcupacionBU
        Dim vXmlCeldasModificadas As XElement = generarXML()
        obj.ReAbrirPlan(vXmlCeldasModificadas.ToString, año)
        objExito.mensaje = "Datos guardados correctamente."
        objExito.ShowDialog()
    End Sub
End Class