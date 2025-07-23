Imports System.Drawing
Imports Cobranza.Negocios
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools


Public Class Administracion_Inventario_ConsultaInventarioDetalles
    Public ProductoEstiloID As Integer
    Dim advertencia As New AdvertenciaForm
    Private Sub Administracion_Inventario_ConsultaInventarioDetalles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        dtpFechaFin.Value = Date.Now

    End Sub

    Public Sub CargarDetallesProducto()
        Dim FechaInicio As String = ""
        Dim FechaFin As String = ""

        Try

            If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
                advertencia.mensaje = "La fecha inicial no puede ser mayor a la fecha final."
                advertencia.ShowDialog()
                dtpFechaInicio.Focus()
            End If

            Dim objBU As New Administracion_ConsultaInventarioBU
            Dim dtDetallesInventario As New DataTable

            FechaInicio = dtpFechaInicio.Value.ToShortDateString
            FechaFin = dtpFechaFin.Value.ToShortDateString

            dtDetallesInventario = objBU.ObtieneDetalleInventario(ProductoEstiloID, FechaInicio, FechaFin)

            If dtDetallesInventario.Rows.Count > 0 Then
                grdDetallesInventario.DataSource = dtDetallesInventario
                DiseñoGrid()
            Else
                advertencia.mensaje = "No existen detalles del artículo."
                advertencia.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MVDetallesInventario_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MVDetallesInventario.RowCellStyle

        If e.Column.FieldName.Contains("CantidadPares") Then
            If Not IsDBNull(MVDetallesInventario.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                If CDbl(MVDetallesInventario.GetRowCellValue(e.RowHandle, e.Column.FieldName)) < 0 Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub


    Public Sub DiseñoGrid()
        MVDetallesInventario.OptionsView.ColumnAutoWidth = False
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVDetallesInventario.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
        Next

        MVDetallesInventario.Columns.ColumnByFieldName("CantidadPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVDetallesInventario.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        MVDetallesInventario.Columns.ColumnByFieldName("Factura").Width = 100
        MVDetallesInventario.Columns.ColumnByFieldName("RazonSocial").Width = 250
        MVDetallesInventario.Columns.ColumnByFieldName("ProductoEstiloID").Width = 100
        MVDetallesInventario.Columns.ColumnByFieldName("FechaFactura").Width = 100
        MVDetallesInventario.Columns.ColumnByFieldName("Accion").Width = 100
        MVDetallesInventario.Columns.ColumnByFieldName("CantidadPares").Width = 100


        MVDetallesInventario.Columns.ColumnByFieldName("ProductoEstiloID").Caption = "ID"
        MVDetallesInventario.Columns.ColumnByFieldName("Accion").Caption = "Acción"
        MVDetallesInventario.Columns.ColumnByFieldName("CantidadPares").Caption = "Cantidad Pares"
        MVDetallesInventario.Columns.ColumnByFieldName("FechaFactura").Caption = "Fecha Factura"
        MVDetallesInventario.Columns.ColumnByFieldName("RazonSocial").Caption = "Razón Social"


        If IsNothing(MVDetallesInventario.Columns("CantidadPares").Summary.FirstOrDefault(Function(x) x.FieldName = "CantidadPares")) = True Then
            MVDetallesInventario.Columns("CantidadPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CantidadPares", "{0:N2}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "CantidadPares"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            MVDetallesInventario.GroupSummary.Add(item2)
        End If
        ' MVDetallesInventario.BestFitColumns()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarDetallesProducto()
    End Sub
End Class