Imports Cobranza.Negocios
Imports Tools
Public Class AltaProveedorClienteInternoForm
    Dim terminaCarga As Boolean = False
    Dim lstObtenerClientes As New DataTable
    Private Sub AltaProveedorClienteInternoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaProveedores()
        cargaClientes()
        cargaNaves()
        terminaCarga = True
    End Sub
    Private Sub cargaProveedores()
        Dim objConfigInterno As New AltaClienteProveedorInternoBU
        Dim lstObtenerProvedores As New DataTable
        BtnGuardar.Enabled = False
        lblGuardar.Enabled = False
        lstObtenerProvedores = objConfigInterno.consultaProveedores
        lstObtenerProvedores.Rows.InsertAt(lstObtenerProvedores.NewRow, 0)
        cmbProveedoresAlta.DataSource = lstObtenerProvedores
        cmbProveedoresAlta.ValueMember = "id"
        cmbProveedoresAlta.DisplayMember = "Proveedor"
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        LimpiarInformacion()
    End Sub
    Private Sub LimpiarInformacion()
        cmbProveedoresAlta.Text = Nothing
        CmbClientesAlta.Text = Nothing
        cmbCuentasBancos.Text = Nothing
        CmbNaves.Text = Nothing
        BtnGuardar.Enabled = False
        lblGuardar.Enabled = False
    End Sub
    Private Sub cargaClientes()
        Dim objConfigInterno As New AltaClienteProveedorInternoBU
        lstObtenerClientes = objConfigInterno.consultaClientes
        lstObtenerClientes.Rows.InsertAt(lstObtenerClientes.NewRow, 0)
        CmbClientesAlta.DataSource = lstObtenerClientes
        CmbClientesAlta.ValueMember = "id"
        CmbClientesAlta.DisplayMember = "Cliente"
    End Sub
    Private Sub cargaNaves()
        Dim objConfigInterno As New AltaClienteProveedorInternoBU
        Dim lstObtenerNaves As New DataTable
        lstObtenerNaves = objConfigInterno.consultaNaves
        lstObtenerNaves.Rows.InsertAt(lstObtenerNaves.NewRow, 0)
        CmbNaves.DataSource = lstObtenerNaves
        CmbNaves.ValueMember = "id"
        CmbNaves.DisplayMember = "Nave"
    End Sub
    Private Sub CmbClientesAlta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbClientesAlta.SelectedIndexChanged
        If terminaCarga Then
            cargaCuentasBancariasClientesInternos()
        End If
    End Sub
    Private Sub cargaCuentasBancariasClientesInternos()
        Dim objClienteInterno As New Entidades.ConfiguracionClienteProveedorInterno
        Dim objConsultaBanco As New AltaClienteProveedorInternoBU
        Dim lstCuentaBanco As New DataTable
        objClienteInterno.ClienteInterno = CmbClientesAlta.Text
        lstCuentaBanco = objConsultaBanco.cargaCuentasClienteInterno(objClienteInterno)
        If lstCuentaBanco.Rows.Count > 0 Then
            lstCuentaBanco.Rows.InsertAt(lstCuentaBanco.NewRow, 0)
            cmbCuentasBancos.DataSource = lstCuentaBanco
            cmbCuentasBancos.ValueMember = "id"
            cmbCuentasBancos.DisplayMember = "cuenta"
        End If
    End Sub

    Private Sub cmbCuentasBancos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCuentasBancos.SelectedIndexChanged
        If cmbProveedoresAlta.Text <> "" And CmbClientesAlta.Text <> "" And CmbNaves.Text <> "" And cmbCuentasBancos.Text <> "" Then
            BtnGuardar.Enabled = True
            lblGuardar.Enabled = True
        End If
    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        guardarClienteProveedorInterno()
    End Sub
    Private Sub guardarClienteProveedorInterno()
        Dim objInformacion As New Entidades.ConfiguracionClienteProveedorInterno
        Dim ObjInsertaInformacion As New AltaClienteProveedorInternoBU
        Dim correcto As New Tools.ExitoForm
        objInformacion.IdProveedorInterno = cmbProveedoresAlta.SelectedValue
        objInformacion.ProveedorInterno = cmbProveedoresAlta.Text
        objInformacion.idClienteInterno = CmbClientesAlta.SelectedValue
        objInformacion.ClienteInterno = CmbClientesAlta.Text
        objInformacion.IdNaveInterno = CmbNaves.SelectedValue
        objInformacion.NaveInterno = CmbNaves.Text
        objInformacion.IdCuentaBancaria = cmbCuentasBancos.SelectedValue
        objInformacion.CuentaBancariaInterno = cmbCuentasBancos.Text
        objInformacion.IntMsgResult = ObjInsertaInformacion.InsertaProveedorClienteInterno(objInformacion)
        If objInformacion.IntMsgResult <> "" Then
            correcto.mensaje = "Registro Insertado Correctamente"
            correcto.ShowDialog()
            LimpiarInformacion()
        End If
    End Sub

End Class