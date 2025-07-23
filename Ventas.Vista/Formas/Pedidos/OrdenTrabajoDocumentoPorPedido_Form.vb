Imports Ventas.Negocios

Public Class OrdenTrabajoDocumentoPorPedido_Form

    Public pedidoSAY As Integer = 0
    Public partida As Integer = 0
    Public tipoVista As Integer = 0
    Public dtResultado As New DataTable
    Private obj As New AdministradorPedidosEscritorioBU

    Private Sub OrdenTrabajoDocumentoPorPedido_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If tipoVista = 0 Then 'OT
            Me.Text = "Órdenes de Trabajo"
            lblTitulo.Text = "Órdenes de Trabajo"
        Else
            Me.Text = "Documentos"
            lblTitulo.Text = "Facturas"
        End If

        Mostrar()
    End Sub

    Private Sub Mostrar()
        If dtResultado.Rows.Count > 0 Then
            grdGrid.DataSource = dtResultado
            Disenio_Grid()
        End If
    End Sub

    Private Sub Disenio_Grid()
        If tipoVista = 0 Then 'OT
            Disenio_Grid_OT()
        Else
            Disenio_Grid_Facturas()
        End If
    End Sub

    Private Sub Disenio_Grid_OT()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatos)

        grdDatos.Columns(0).OptionsColumn.AllowEdit = True

        grdDatos.Columns("ot").Caption = "Orden" + vbCrLf + "Trabajo"
        grdDatos.Columns("pedidoSAY").Caption = "P SAY"
        grdDatos.Columns("partida").Caption = "Partida"
        grdDatos.Columns("pares").Caption = "Pares"
        grdDatos.Columns("confirmados").Caption = "Confirmados"
        grdDatos.Columns("cancelados").Caption = "Cancelados"
    End Sub

    Private Sub Disenio_Grid_Facturas()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatos)

        grdDatos.Columns(0).OptionsColumn.AllowEdit = True

        'grdDatos.Columns("ot").Caption = "Orden" + vbCrLf + "Trabajo"
        'grdDatos.Columns("pedidoSAY").Caption = "P SAY"
        'grdDatos.Columns("partida").Caption = "Partida"
        'grdDatos.Columns("pares").Caption = "Pares"
        'grdDatos.Columns("confirmados").Caption = "Confirmados"
        'grdDatos.Columns("cancelados").Caption = "Cancelados"
    End Sub
End Class