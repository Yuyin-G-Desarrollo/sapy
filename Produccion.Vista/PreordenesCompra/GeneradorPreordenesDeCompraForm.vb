Imports Produccion.Negocios

Public Class GeneradorPreordenesDeCompraForm
    Public fechaInicial As String = ""
    Public fechaFinal As String = ""
    Public proveedor As Integer = 0
    Public nave As Integer = 0
    Public cerrar As Integer = 0

    Private Sub GeneradorPreordenesDeCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarListaProveedoresProgramaNave()
    End Sub

    Public Sub LlenarListaProveedoresProgramaNave()
        'Dim obj As New PreordenCompraBU
        'Dim componentes As New DataTable
        'componentes = obj.ConsultaProveedoresProgramaNave(nave, dtpInicial.Value.ToShortDateString)

        'If Not componentes.Rows.Count = 0 Then
        '    componentes.Rows.InsertAt(componentes.NewRow, 0)
        '    cbxProveedor.DataSource = componentes
        '    cbxProveedor.DisplayMember = "proveedor"
        '    cbxProveedor.ValueMember = "id"
        'End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        cerrar = 1
        Me.Close()
    End Sub

    'Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
    '    'fechaFinal = dtpFinal.Value.ToShortDateString
    '    fechaInicial = dtpInicial.Value.ToShortDateString
    '    If cbxProveedor.Text = "" Then
    '        proveedor = 0
    '    Else
    '        proveedor = cbxProveedor.SelectedValue
    '    End If
    '    Dim form As New ExplosionMaterialesForm
    '    form.fechaInicial = fechaInicial
    '    form.fechaFinal = fechaFinal
    '    form.proveedor = proveedor
    '    Me.Close()
    'End Sub

    Private Sub dtpInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpInicial.ValueChanged
        LlenarListaProveedoresProgramaNave()
    End Sub

    Private Sub dtpFinal_ValueChanged(sender As Object, e As EventArgs)
        LlenarListaProveedoresProgramaNave()
    End Sub

End Class