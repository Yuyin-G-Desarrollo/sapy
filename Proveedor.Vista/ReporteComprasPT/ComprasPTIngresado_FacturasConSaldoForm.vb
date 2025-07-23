Imports Tools
Public Class ComprasPTIngresado_FacturasConSaldoForm
    Public emisorSicyId As Integer
    Public receptorSicyId As Integer
    Public facturaId As Integer = 0

    Private Sub ComprasPTIngresado_FacturasConSaldoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarFacturas()
    End Sub

    Private Sub cargarFacturas()
        Dim objBU As New Proveedores.BU.DevolucionesPreliminares_BU
        Dim dtFacturas As New DataTable
        grdListado.DataSource = Nothing

        dtFacturas = objBU.obtenerFacturasConSaldo(emisorSicyId, receptorSicyId)

        If Not dtFacturas Is Nothing AndAlso dtFacturas.Rows.Count > 0 Then
            grdListado.DataSource = dtFacturas
            disenioGrid()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró ninguna factura con saldo para este proveedor.")
            Me.Close()
        End If

    End Sub

    Private Sub disenioGrid()
        gvwListado.Columns.ColumnByFieldName("IDTABLA").Visible = False
        DiseñoGrid.DiseñoBaseGrid(gvwListado)
        gvwListado.BestFitColumns()
    End Sub

    Private Sub gvwListado_DoubleClick(sender As Object, e As EventArgs) Handles gvwListado.DoubleClick
        Try
            facturaId = 0
            If Not IsDBNull(gvwListado.GetFocusedRowCellValue("IDTABLA")) AndAlso IsNumeric(gvwListado.GetFocusedRowCellValue("IDTABLA")) Then
                facturaId = CInt(gvwListado.GetFocusedRowCellValue("IDTABLA"))
            End If
            Me.Close()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ocurrió un error al obtener la información de la factura seleccionada.")
        End Try
    End Sub
End Class