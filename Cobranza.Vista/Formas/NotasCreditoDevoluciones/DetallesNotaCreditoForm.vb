Imports System.Drawing
Imports Cobranza.Negocios
Imports Entidades
Imports Tools

Public Class DetallesNotaCreditoForm
    Public notacreditoId As Integer
    Public cliente As String
    Public tipoNC As String
    Private Sub DetallesNotaCreditoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaEncabezadoDetalles()
        cargarDetallesNotaCredito()
    End Sub
    Private Sub cargarDetallesNotaCredito()
        Dim cargaDetalles As New NotasCreditoDevoluciones
        Dim objDetalles As New NotaCreditoDevolucionesBU
        Dim dtDetalle As New DataTable
        cargaDetalles.NotaCreditoId = notacreditoId
        dtDetalle = objDetalles.obtenerDetallesNotaCredito(cargaDetalles)
        If dtDetalle.Rows.Count > 0 Then
            grdDetallesNotaCredito.DataSource = dtDetalle
            diseñoDetallesNotaCredito()
        End If
        lblNoRegistros.Text = dtDetalle.Rows.Count
    End Sub
    Private Sub cargaEncabezadoDetalles()
        Dim cargaEncabezado As New NotasCreditoDevoluciones
        Dim objEncabezado As New NotaCreditoDevolucionesBU
        Dim dtEncabezado As New DataTable
        cargaEncabezado.NotaCreditoId = notacreditoId
        cargaEncabezado.NotaCreditoCliente = cliente
        cargaEncabezado.NotaCreditoTipo = tipoNC
        dtEncabezado = objEncabezado.obtenerEncabezadoDetallesNC(cargaEncabezado)
        If dtEncabezado.Rows.Count > 0 Then
            lblfolioactual.Text = dtEncabezado.Rows(0).Item(0)
            lblC_cliente.Text = dtEncabezado.Rows(0).Item(1)
            lblTotalPares.Text = dtEncabezado.Rows(0).Item(2)
            If tipoNC = "F" Then
                lblrazSocialemisor.Text = dtEncabezado.Rows(0).Item(3)
                lblsocialreceptor.Text = dtEncabezado.Rows(0).Item(4)
                lblfecha.Text = dtEncabezado.Rows(0).Item(5)
            Else
                lblrazSocialemisor.Text = ""
                lblsocialreceptor.Text = dtEncabezado.Rows(0).Item(3)
                lblfecha.Text = dtEncabezado.Rows(0).Item(4)
            End If
        End If
        lblultimaFecActualizacion.Text = Now
    End Sub
    Private Sub diseñoDetallesNotaCredito()
        Tools.DiseñoGrid.AlternarColorEnFilas(wvDetallesNotaCredito) '' pone color a las filas del gridview
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvDetallesNotaCredito.Columns
            If col.FieldName = "Articulo" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 165
            End If
            If col.FieldName = "Pares" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 35
            End If
            If col.FieldName = "Precio Venta" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "Importe" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "IVA" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "Total" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "Factura Aplicada" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 43
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvDetallesNotaCredito.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If col.FieldName.Contains("Pares") Or col.FieldName.Contains("Importe") Or col.FieldName.Contains("IVA") Or col.FieldName.Contains("Total") Then
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True And col.FieldName = "Pares" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    col.DisplayFormat.FormatString = "N0"
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Importe")) = True And col.FieldName = "Importe" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                    col.DisplayFormat.FormatString = "N2"
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                    col.DisplayFormat.FormatString = "N2"
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                    col.DisplayFormat.FormatString = "N2"
                End If
            End If
        Next
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarReporteDetalles()
    End Sub
    Private Sub exportarReporteDetalles()
        If wvDetallesNotaCredito.DataRowCount > 0 Then
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvDetallesNotaCredito.Columns
                col.AppearanceHeader.BackColor = Color.LightSkyBlue
            Next
            Tools.Excel.ExportarExcel(wvDetallesNotaCredito, "Reporte Detalles Nota Crédito")
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontrarón registros para exportar.")
        End If
    End Sub
End Class