Imports Tools

Public Class EditarCuenta_BancariaForm

    Public cuentaid As Integer

    Public numero As String = String.Empty
    Public cuentahabiente As String = String.Empty
    Public empresaid As Integer
    Public cuentasicyid As Integer
    Public cuentasicy As String
    Public bancoid As Integer


    Private Sub EditarCuenta_BancariaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtNumeroCuenta.Text = numero
        txtCuentahabiente.Text = cuentahabiente

        lista_CuentasBancarias_SICY()
        lista_Empresas()
        cboxRazonSocial.SelectedValue = empresaid
        lista_Bancos()
        cboxBanco.SelectedValue = bancoid
        lista_CuentasBancarias_SICY()
        Dim objBU As New Negocios.CuentasBancariasBU
        Dim tabla As New DataTable
        tabla = objBU.Datos_CuentaBancaria(cuentaid)

        If Not IsDBNull(tabla.Rows(0).Item("cuba_cuentacontpaqid")) Then
            cboxCuentaContpaq.SelectedValue = CInt(tabla.Rows(0).Item("cuba_cuentacontpaqid"))
        End If

        If Not IsDBNull(tabla.Rows(0).Item("cuba_bancocontpaqid")) Then
            Dim PolizaBU As New Negocios.PolizaBU

            If PolizaBU.Existe_Tabla_Contpaq(cboxRazonSocial.SelectedValue, "Bancos") Then
                tabla = objBU.Datos_Banco_Contpaq(empresaid, CInt(tabla.Rows(0).Item("cuba_bancocontpaqid")))
                ''COMBOBOX CUENTA BANCARIA
                cboxBancoContpaq.DisplayMember = "Id"
                cboxBancoContpaq.ValueMember = "Nombre"
                cboxBancoContpaq.DataSource = tabla
                Try
                    cboxBancoContpaq.SelectedValue = CInt(tabla.Rows(0).Item("Id"))
                Catch ex As Exception
                    cboxBancoContpaq.SelectedValue = 0
                End Try
                btnAceptar.Enabled = False
            Else
                show_message("Advertencia", "Esta empresa no tiene cuentas en Contpaq")
                btnAceptar.Enabled = False
            End If


        End If


    End Sub

    Private Sub lista_CuentasBancarias_SICY()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable


        tabla = objBU.Combo_lista_Cuentas_Bancarias_SICY()
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        tabla.Rows.Add(cuentasicyid, cuentasicy)
        cboxNumeroCuentaSICY.DataSource = tabla
        cboxNumeroCuentaSICY.DisplayMember = "Cuenta"
        cboxNumeroCuentaSICY.ValueMember = "IdCuenta"

        cboxNumeroCuentaSICY.SelectedValue = cuentasicyid

    End Sub

    Private Sub lista_Empresas()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxRazonSocial.DataSource = tabla
        cboxRazonSocial.DisplayMember = "essc_razonsocial"
        cboxRazonSocial.ValueMember = "essc_empresaid"
    End Sub

    Private Sub lista_Bancos()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Bancos
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxBanco.DataSource = tabla
        cboxBanco.DisplayMember = "banc_nombre"
        cboxBanco.ValueMember = "banc_bancoid"

    End Sub

    Private Sub lista_Cuentas_Cheques_Contpaq(empresaID As Integer)

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Cuentas_Cheques_Contpaq(empresaID)
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        If tabla.Rows.Count > 0 Then
            cboxCuentaContpaq.DataSource = tabla
            cboxCuentaContpaq.DisplayMember = "Nombre"
            cboxCuentaContpaq.ValueMember = "Id"
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim objBU As New Negocios.CuentasBancariasBU
        Dim cuentacontpaqid As Integer
        Dim bancocontpaqid As Integer

        Dim guardar As Boolean = True

        numero = txtNumeroCuenta.Text
        cuentahabiente = txtCuentahabiente.Text

        If Not IsNothing(cboxRazonSocial.SelectedValue) Then
            empresaid = CInt(cboxRazonSocial.SelectedValue)
        Else
            guardar = False
        End If

        If Not IsNothing(cboxNumeroCuentaSICY.SelectedValue) Then
            cuentasicyid = CInt(cboxNumeroCuentaSICY.SelectedValue)
        Else
            guardar = False
        End If

        If Not IsNothing(cboxBanco.SelectedValue) Then
            bancoid = CInt(cboxBanco.SelectedValue)
        Else
            guardar = False
        End If

        If Not IsNothing(cboxCuentaContpaq.SelectedValue) And Not IsDBNull(cboxCuentaContpaq.SelectedValue) Then
            cuentacontpaqid = cboxCuentaContpaq.SelectedValue
        Else
            guardar = False
        End If

        If Not IsNothing(cboxBancoContpaq.SelectedValue) And Not IsDBNull(cboxBancoContpaq.SelectedValue) Then
            bancocontpaqid = cboxBancoContpaq.SelectedValue
        Else
            guardar = False
        End If

        If guardar Then
            Try
                objBU.alta_edicion_CuentaBancaria(cuentaid, numero, cuentahabiente, empresaid, cuentasicyid, bancoid, cuentacontpaqid, bancocontpaqid, 1)
                show_message("Exito", "Información guardada con éxito")
            Catch ex As Exception
                show_message("Error", "Algo surgió mal durante el proceso de guardado")
            End Try
        Else
            show_message("Advertencia", "Hay datos sin capturar")

            Me.DialogResult = Windows.Forms.DialogResult.None

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub cboxRazonSocial_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxRazonSocial.SelectedValueChanged

        Dim objBU As New Negocios.PolizaBU
        Try
            If objBU.Existe_Tabla_Contpaq(cboxRazonSocial.SelectedValue, "Cuentas") Then
                If Not IsNothing(cboxRazonSocial.SelectedValue) And Not IsDBNull(cboxRazonSocial.SelectedValue) Then
                    empresaid = CInt(cboxRazonSocial.SelectedValue)
                    cboxCuentaContpaq.Enabled = True
                    lista_Cuentas_Cheques_Contpaq(empresaid)
                    btnBancoContpaq.Enabled = True
                    cboxBancoContpaq.Enabled = True
                Else
                    cboxCuentaContpaq.Enabled = False
                End If
            Else
                show_message("Advertencia", "Esta empresa no tiene Cuentas en Contpaq")
                Me.DialogResult = Windows.Forms.DialogResult.None
                cboxCuentaContpaq.Enabled = False
                btnAceptar.Enabled = False
            End If
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub btnBancoContpaq_Click(sender As Object, e As EventArgs) Handles btnBancoContpaq.Click

        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 7

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cboxBancoContpaq.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxBancoContpaq.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        If Not IsNothing(cboxRazonSocial.SelectedValue) Then
            listado.id_parametros = cboxRazonSocial.SelectedValue.ToString
        End If

        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cboxBancoContpaq.DataSource = Nothing
        cboxBancoContpaq.DisplayMember = "Nombre de Banco"
        cboxBancoContpaq.ValueMember = "Parámetro"
        cboxBancoContpaq.DataSource = listado.listParametros

        cboxBancoContpaq.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub

End Class