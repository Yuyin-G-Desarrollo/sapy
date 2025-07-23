Imports Proveedores.BU
Imports Tools

Public Class ConfirmarRemisionesForm
    Public idNave As Integer = 0
    Dim adv As New ExitoForm
    Public cancelado As Boolean = False
    Dim guardar As Boolean = False
    Public lstProveedores As New DataTable
    Public idProveedor As Integer = 0
    Private Sub ConfirmarRemisionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboProveedores()
    End Sub
    Public Sub llenarComboProveedores()
        Dim obj As New MaterialesBU
        If Not lstProveedores.Rows.Count = 0 Then
            lstProveedores.Rows.InsertAt(lstProveedores.NewRow, 0)
            cmbProveedor.DataSource = lstProveedores
            cmbProveedor.DisplayMember = "Razón Social"
            cmbProveedor.ValueMember = "IdProveedor"
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If cmbProveedor.SelectedIndex > 0 Then
            idProveedor = cmbProveedor.SelectedValue
            guardar = True
            Me.Close()
        Else
            adv.mensaje = "Selecciona un proveedor."
            adv.ShowDialog()
        End If

    End Sub

    Private Sub ConfirmarRemisionesForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If guardar = False Then
            cancelado = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cancelado = True
        Me.Close()
    End Sub
End Class