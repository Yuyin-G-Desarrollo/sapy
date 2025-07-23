Imports System.Windows.Forms
Imports Cobranza.Negocios
Public Class MuestrarioClientesform
    Public razonSocialId As Integer
    Public tipoNC As String
    Public nombreCliente As String
    Public clienteidSAY As Integer
    Public clienteIdSICY As Integer
    Private Sub MuestrarioClientesform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaClientesF1()
        nombreCliente = ""
        clienteidSAY = 0
        'vwClientes.FocusedRowHandle = True
    End Sub
    Private Sub cargaClientesF1()
        Dim objClientesF1 As New NotaCreditoDevolucionesBU
        Dim dtClientesF1 As New DataTable
        dtClientesF1 = objClientesF1.obtenerClientesFuncionF1(tipoNC, razonSocialId)
        If dtClientesF1.Rows.Count > 0 Then
            grdClientes.DataSource = dtClientesF1
            diseñoGridClientes(vwClientes)
        End If
    End Sub
    Private Sub diseñoGridClientes(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(vwClientes)
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwClientes.Columns
            If col.FieldName = "IdCliente" Then
                col.Visible = False
            End If
            If col.FieldName = "Nombre" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 335
            End If
            If col.FieldName = "Ciudad" Then
                col.Visible = False
            End If
            If col.FieldName = "Estado" Then
                col.Visible = False
            End If
            If col.FieldName = "id_sicy" Then
                col.Visible = False
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwClientes.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Grid.IndicatorWidth = 30
        grdClientes.ForceInitialize()
        vwClientes.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
    Private Sub vwClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles vwClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            nombreCliente = Convert.ToString(vwClientes.GetFocusedRowCellValue("Nombre"))
            clienteidSAY = Convert.ToInt32(vwClientes.GetFocusedRowCellValue("IdCliente"))
            clienteIdSICY = Convert.ToInt32(vwClientes.GetFocusedRowCellValue("id_sicy"))
            Close()
        End If
    End Sub
    Private Sub MuestrarioClientesform_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
    Private Sub vwClientes_DoubleClick(sender As Object, e As EventArgs) Handles vwClientes.DoubleClick
        nombreCliente = Convert.ToString(vwClientes.GetFocusedRowCellValue("Nombre"))
        clienteidSAY = Convert.ToInt32(vwClientes.GetFocusedRowCellValue("IdCliente"))
        clienteIdSICY = Convert.ToInt32(vwClientes.GetFocusedRowCellValue("id_sicy"))
        Close()
    End Sub
End Class