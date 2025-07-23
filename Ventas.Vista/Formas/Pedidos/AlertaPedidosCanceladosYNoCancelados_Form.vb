Public Class AlertaPedidosCanceladosYNoCancelados_Form
    Private pedidosCancelados As New DataTable
    Private pedidosNoCancelados As New DataTable

    Private Sub AlertaPedidosCanceladosYNoCancelados_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInformacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Public Sub SetPedidosCancelados(pedidosCancelados As DataTable)
        Me.pedidosCancelados = pedidosCancelados
    End Sub

    Public Sub SetPedidosNoCancelados(pedidosNoCancelados As DataTable)
        Me.pedidosNoCancelados = pedidosNoCancelados
    End Sub

    Private Sub MostrarInformacion()
        Dim dtResultadoTotal As New DataTable
        Dim dtRow As DataRow = Nothing

        dtResultadoTotal = pedidosCancelados.Clone

        For index = 0 To pedidosCancelados.Rows.Count - 1
            dtResultadoTotal.ImportRow(pedidosCancelados.Rows(index))
        Next

        For index = 0 To pedidosNoCancelados.Rows.Count - 1
            'dtRow = dtResultadoTotal.NewRow()
            'dtRow = pedidosNoCancelados.Rows(index)
            dtResultadoTotal.ImportRow(pedidosNoCancelados.Rows(index))
        Next

        If dtResultadoTotal.Rows.Count > 0 Then
            grdPedidos.DataSource = dtResultadoTotal
            DisenioGrid()
        End If

    End Sub


    Private Sub DisenioGrid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosPedidos)

        grdDatosPedidos.Columns("PedidoSAY").Caption = "Pedido" + vbCrLf + "SAY"
        grdDatosPedidos.Columns("OrdenesTrabajo").Caption = "Órdenes" + vbCrLf + "Trabajo"
        grdDatosPedidos.Columns("PartidasSinLotes").Caption = "Partidas" + vbCrLf + "Sin Lotes"
        grdDatosPedidos.Columns("OrdenesDesasignacion").Caption = "Órdenes" + vbCrLf + "Desasignación"

        grdDatosPedidos.Columns("Mensaje").BestFit()

    End Sub
End Class
