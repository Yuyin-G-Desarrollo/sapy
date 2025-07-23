Public Class Alta_E_CuentaContableForm

    'Private Sub AltaCuentaContableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    lista_Empresas()
    '    lista_TipoCuentaContable()
    'End Sub

    Private Sub lista_Empresas()
        cboxRazonSocial.DataSource = Nothing
        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxRazonSocial.DataSource = tabla
        cboxRazonSocial.DisplayMember = "essc_razonsocial"
        cboxRazonSocial.ValueMember = "essc_contribuyentesicyid"
        cboxRazonSocial.SelectedValue = 0
    End Sub

    Private Sub lista_TipoCuentaContable()
        cboxTipoCuenta.DataSource = Nothing
        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_TipoCuentaContable
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxTipoCuenta.DataSource = tabla
        cboxTipoCuenta.ValueMember = "ticc_tipocuentacontabilidadSICYid"
        cboxTipoCuenta.DisplayMember = "ticc_nombre"
        cboxTipoCuenta.SelectedValue = 0
    End Sub


    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        'For Each row As UltraGridRow In gridListaCuentaContable.Rows
        Dim parametro As String
        If IsNothing(cboxProveedor.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxProveedor.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        'Next
        listado.listaParametroID = listaParametroID
        listado.id_parametros = cboxTipoCuenta.SelectedValue.ToString + "," + cboxRazonSocial.SelectedValue.ToString
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        cboxProveedor.DataSource = listado.listParametros
        'With cboxCliente
        '.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Productos"
        cboxProveedor.ValueMember = "prov_sicyid"
        cboxProveedor.DisplayMember = "Proveedor"
        'End With
        cboxProveedor.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))

        If Not IsDBNull(cboxProveedor.SelectedValue) Then
            txtNumCuenta3.Text = cboxProveedor.Text.Substring(0, 1)
        End If

        Dim objBU As New Negocios.CuentasContablesBU
        Dim tabla As New DataTable
        Dim consecutivo As String = String.Empty
        tabla = objBU.Consulta_Cuentas_Contables_Consecutivo(cboxRazonSocial.SelectedValue, txtNumCuenta1.Text, txtNumCuenta2.Text, txtNumCuenta3.Text)

        If tabla.Rows.Count > 0 Then
            consecutivo = tabla.Rows(0).Item(0).ToString
        Else
            consecutivo = 1
        End If

        txtNumCuenta4.Text = consecutivo

        btnCuentaSICY.Enabled = True

    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 2

        Dim listaParametroID As New List(Of String)
        'For Each row As UltraGridRow In gridListaCuentaContable.Rows
        Dim parametro As String
        If IsNothing(cboxCliente.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxCliente.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        'Next
        listado.listaParametroID = listaParametroID
        listado.id_parametros = cboxTipoCuenta.SelectedValue.ToString + "," + cboxRazonSocial.SelectedValue.ToString
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        cboxCliente.DataSource = listado.listParametros
        'With cboxCliente
        '.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Productos"
        cboxCliente.ValueMember = "clie_idsicy"
        cboxCliente.DisplayMember = "Cliente"
        'End With
        cboxCliente.SelectedValue = CInt(listado.listParametros.Rows(0).Item("clie_idsicy"))

        If Not IsDBNull(cboxCliente.SelectedValue) Then
            txtNumCuenta3.Text = cboxCliente.Text.Substring(0, 1)
        End If

        Dim objBU As New Negocios.CuentasContablesBU
        Dim tabla As New DataTable
        Dim consecutivo As String = String.Empty
        tabla = objBU.Consulta_Cuentas_Contables_Consecutivo(cboxRazonSocial.SelectedValue, txtNumCuenta1.Text, txtNumCuenta2.Text, txtNumCuenta3.Text)

        If tabla.Rows.Count > 0 Then
            consecutivo = tabla.Rows(0).Item(0).ToString
        Else
            consecutivo = 1
        End If

        txtNumCuenta4.Text = consecutivo

        btnCuentaSICY.Enabled = True

    End Sub

    Private Sub cboxTipoCuenta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxTipoCuenta.SelectionChangeCommitted
        If Not IsDBNull(cboxTipoCuenta.SelectedValue) Then
            cboxRazonSocial.Enabled = True
            btnCliente.Enabled = False
            cboxCliente.Enabled = False
            cboxCliente.SelectedValue = 0
            btnProveedor.Enabled = False
            cboxProveedor.Enabled = False
            cboxProveedor.SelectedValue = 0
            If cboxTipoCuenta.SelectedValue = 2 Then
                txtNumCuenta1.Text = "103"
                txtNumCuenta2.Text = "1000"
            ElseIf cboxTipoCuenta.SelectedValue = 6 Then
                txtNumCuenta1.Text = "200"
                txtNumCuenta2.Text = "1000"
            End If
        Else
            cboxRazonSocial.Enabled = False
        End If
    End Sub

    Private Sub cboxRazonSocial_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxRazonSocial.SelectionChangeCommitted
        If Not IsDBNull(cboxRazonSocial.SelectedValue) Then
            If cboxTipoCuenta.SelectedValue = 2 Then
                btnCliente.Enabled = True
                cboxCliente.Enabled = True
                btnProveedor.Enabled = False
                cboxProveedor.Enabled = False
                cboxProveedor.SelectedValue = 0
            ElseIf cboxTipoCuenta.SelectedValue = 6 Then
                btnCliente.Enabled = False
                cboxCliente.Enabled = False
                cboxCliente.SelectedValue = 0
                btnProveedor.Enabled = True
                cboxProveedor.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtNumCuenta3_TextChanged(sender As Object, e As Windows.Forms.MaskInputRejectedEventArgs) Handles txtNumCuenta3.TextChanged
        Dim objBU As New Negocios.CuentasContablesBU
        Dim tabla As New DataTable
        Dim consecutivo As String = String.Empty
        tabla = objBU.Consulta_Cuentas_Contables_Consecutivo(cboxRazonSocial.SelectedValue, txtNumCuenta1.Text, txtNumCuenta2.Text, txtNumCuenta3.Text)

        consecutivo = tabla.Rows(0).Item(0).ToString

        txtNumCuenta4.Text = consecutivo

    End Sub

    Private Sub btnCuentaSICY_Click(sender As Object, e As EventArgs) Handles btnCuentaSICY.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 3

        Dim listaParametroID As New List(Of String)
        'For Each row As UltraGridRow In gridListaCuentaContable.Rows
        Dim parametro As String
        If IsNothing(cboxCuentaSICY.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxCuentaSICY.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        'Next
        listado.listaParametroID = listaParametroID
        If IsNothing(cboxCliente.SelectedValue) Then
            listado.id_parametros = cboxTipoCuenta.SelectedValue.ToString + "," + cboxProveedor.SelectedValue.ToString + "," + cboxRazonSocial.SelectedValue.ToString
        Else
            listado.id_parametros = cboxTipoCuenta.SelectedValue.ToString + "," + cboxCliente.SelectedValue.ToString + "," + cboxRazonSocial.SelectedValue.ToString
        End If

        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        cboxCuentaSICY.DataSource = listado.listParametros
        'With cboxCliente
        '.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Productos"
        cboxCuentaSICY.ValueMember = "Parámetro"
        cboxCuentaSICY.DisplayMember = "Número de Cuenta"
        'End With
        cboxCuentaSICY.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))


    End Sub

    Private Sub AltaCuentaContableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Alta_Editar_CuentaContableForm
        '
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Name = "Alta_Editar_CuentaContableForm"
        Me.ResumeLayout(False)

    End Sub
End Class