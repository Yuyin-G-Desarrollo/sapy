Imports Contabilidad.Negocios
Imports Tools

Public Class EditarCuentaGeneralForm

    Public cuenta_general_id As Integer

    Private Sub EditarCuentaGeneralForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lista_TipoPoliza()
        lista_Empresas()

        Dim objBU As New Negocios.CuentasGeneralesBU
        Dim tabla As New DataTable
        Dim row As DataRow

        tabla = objBU.Consulta_Datos_Cuentas_Generales(cuenta_general_id)
        row = tabla.Rows(0)

        cboxTipoPoliza.SelectedValue = row.Item("poti_polizatipoid")
        cboxEmpresa.SelectedValue = row.Item("essc_empresaid")

        If Not IsDBNull(row.Item("cgen_cuenta")) Then
            txtNumCuenta.Text = row.Item("cgen_cuenta")
        Else
            txtNumCuenta.Text = String.Empty
        End If

        If Not IsDBNull(row.Item("cgen_nombre")) Then
            txtNombreCuenta.Text = row.Item("cgen_nombre")
        Else
            txtNombreCuenta.Text = String.Empty
        End If

        If Not IsDBNull(row.Item("cgen_clave")) Then
            txtClave.Text = row.Item("cgen_clave")
        Else
            txtClave.Text = String.Empty
        End If

        ''COMBOBOX CUENTA CONTPAQ
        cboxCuentaContpaq.DisplayMember = "cgen_cuenta"
        cboxCuentaContpaq.ValueMember = "cgen_cuentacontpaqid"
        cboxCuentaContpaq.DataSource = tabla
        cboxCuentaContpaq.SelectedValue = CInt(row.Item("cgen_cuentacontpaqid"))
        'cboxCuentaContpaq.SelectedText = CInt(row.Item("cgen_cuenta"))

        ''COMBOBOX CUENTA CONTABLE EN SAY
        cboxCuentaSAY.DisplayMember = "cuco_cuentacontable"
        cboxCuentaSAY.ValueMember = "cuco_cuentacontableid"
        cboxCuentaSAY.DataSource = tabla
        cboxCuentaSAY.SelectedValue = CInt(row.Item("cuco_cuentacontableid"))
        'cboxCuentaContpaq.SelectedText = CInt(row.Item("cgen_cuenta"))

        ''COMBOBOX CUENTA BANCARIA
        cboxCuentaBancaria.DisplayMember = "cuba_numero"
        cboxCuentaBancaria.ValueMember = "cuba_cuentaid"
        cboxCuentaBancaria.DataSource = tabla
        Try
            cboxCuentaBancaria.SelectedValue = CInt(row.Item("cuba_cuentaid"))
        Catch ex As Exception
            cboxCuentaBancaria.SelectedValue = 0
        End Try

    End Sub

    Private Sub EditarCuentaGeneralForm_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim caracter As Char = e.KeyChar

        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub lista_TipoPoliza()
        cboxTipoPoliza.DataSource = Nothing
        Dim objBU As New PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_TipoPoliza
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxTipoPoliza.DisplayMember = "poti_nombre"
        cboxTipoPoliza.ValueMember = "poti_polizatipoid"
        cboxTipoPoliza.DataSource = tabla
        cboxTipoPoliza.SelectedValue = 0
    End Sub

    Private Sub lista_Empresas()
        cboxEmpresa.DataSource = Nothing
        Dim objBU As New PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cboxEmpresa.ValueMember = "essc_empresaid"
        cboxEmpresa.DisplayMember = "essc_razonsocial"
        cboxEmpresa.DataSource = tabla
        cboxEmpresa.SelectedValue = 0
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim objBU As New Negocios.CuentasGeneralesBU

        Dim CuentaContableGeneral As New Entidades.CuentaContableGeneral
        Dim EmpresaSAY_SICY As New Entidades.EmpresaSAY_SICY
        Dim TipoPoliza As New Entidades.TipoPoliza
        Dim CuentaBancaria As New Entidades.CuentaBancaria

        Dim guardar As Boolean = True
        CuentaContableGeneral.cuentageneralid = cuenta_general_id

        If Not IsNothing(cboxTipoPoliza.SelectedValue) Then
            TipoPoliza.polizatipoid = cboxTipoPoliza.SelectedValue
            CuentaContableGeneral.tipopoliza = TipoPoliza
            lblTipoPoliza.ForeColor = Drawing.Color.Black
        Else
            lblTipoPoliza.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If Not IsNothing(cboxEmpresa.SelectedValue) Then
            EmpresaSAY_SICY.empresaid = cboxEmpresa.SelectedValue
            CuentaContableGeneral.empresa = EmpresaSAY_SICY
            lblRazonSocial.ForeColor = Drawing.Color.Black
        Else
            lblRazonSocial.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If txtNumCuenta.Text.Length > 1 Then
            CuentaContableGeneral.cuenta = txtNumCuenta.Text
            lblCuenta.ForeColor = Drawing.Color.Black
        Else
            lblCuenta.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If txtNombreCuenta.Text.Length > 1 Then
            CuentaContableGeneral.nombre = txtNombreCuenta.Text
            lblNombre.ForeColor = Drawing.Color.Black
        Else
            lblNombre.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If txtClave.Text.Length > 1 Then
            CuentaContableGeneral.clave = txtClave.Text
            'lblClave.ForeColor = Drawing.Color.Black
        Else
            CuentaContableGeneral.clave = String.Empty
            'lblClave.ForeColor = Drawing.Color.Red
            'guardar = False
        End If

        If Not IsNothing(cboxCuentaContpaq.SelectedValue) Then
            CuentaContableGeneral.cuentacontpaq = cboxCuentaContpaq.SelectedValue
            lblClave.ForeColor = Drawing.Color.Black
        Else
            CuentaContableGeneral.cuentacontpaq = 0
            lblClave.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If Not IsNothing(cboxCuentaSAY.SelectedValue) Then
            CuentaContableGeneral.cuentasay = cboxCuentaSAY.SelectedValue
        Else
            CuentaContableGeneral.cuentasay = 0
        End If

        If Not IsNothing(cboxCuentaBancaria.SelectedValue) Then
            CuentaBancaria.cuentaid = cboxCuentaBancaria.SelectedValue
            CuentaContableGeneral.cuentabancaria = CuentaBancaria
        Else
            CuentaBancaria.cuentaid = 0
            CuentaContableGeneral.cuentabancaria = CuentaBancaria
        End If

        If guardar Then
            Try
                objBU.alta_edicion_cuenta_contable_general(2, CuentaContableGeneral)
                show_message("Exito", "Información guardada con éxito")
            Catch ex As Exception
                show_message("Error", "Algo surgió mal durante el proceso de guardado")
                Me.DialogResult = Windows.Forms.DialogResult.None
            End Try
        Else
            show_message("Advertencia", "Hay datos sin capturar")

            Me.DialogResult = Windows.Forms.DialogResult.None

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cboxTipoPoliza_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxTipoPoliza.SelectedValueChanged

        If Not IsDBNull(cboxTipoPoliza.SelectedValue) And Not IsNothing(cboxTipoPoliza.SelectedValue) Then

            If cboxTipoPoliza.SelectedValue > 0 Then

                cboxEmpresa.Enabled = True

            Else
                cboxEmpresa.Enabled = False
            End If

        Else
            cboxEmpresa.Enabled = False
        End If

    End Sub

    Private Sub cboxEmpresa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxEmpresa.SelectedValueChanged

        cboxCuentaContpaq.DataSource = Nothing
        cboxCuentaSAY.DataSource = Nothing
        cboxCuentaBancaria.DataSource = Nothing

        If Not IsDBNull(cboxEmpresa.SelectedValue) And Not IsNothing(cboxEmpresa.SelectedValue) Then

            If cboxEmpresa.SelectedValue > 0 Then

                txtNumCuenta.Enabled = True
                txtNombreCuenta.Enabled = True
                txtClave.Enabled = True
                btnCuentaSAY.Enabled = True
                cboxCuentaSAY.Enabled = True
                btnCuentaBancaria.Enabled = True
                cboxCuentaBancaria.Enabled = True

                Dim objBU As New Negocios.PolizaBU

                If objBU.Existe_Tabla_Contpaq(cboxEmpresa.SelectedValue, "Cuentas") Then
                    btnCuentaContpaq.Enabled = True
                    cboxCuentaContpaq.Enabled = True
                    btnAceptar.Enabled = True
                Else
                    show_message("Advertencia", "Esta empresa no tiene cuentas en Contpaq")
                    Me.DialogResult = Windows.Forms.DialogResult.None
                    btnCuentaContpaq.Enabled = False
                    cboxCuentaContpaq.Enabled = False
                    btnAceptar.Enabled = False
                End If

            Else
                txtNumCuenta.Enabled = False
                txtNombreCuenta.Enabled = False
                txtClave.Enabled = False
                btnCuentaSAY.Enabled = False
                cboxCuentaSAY.Enabled = False
                btnCuentaBancaria.Enabled = False
                cboxCuentaBancaria.Enabled = False
            End If

        Else
            btnCuentaSAY.Enabled = False
            cboxCuentaSAY.Enabled = False
        End If

    End Sub

    Private Sub btnCuentaContpaq_Click(sender As Object, e As EventArgs) Handles btnCuentaContpaq.Click

        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 4

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cboxCuentaContpaq.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxCuentaContpaq.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        If Not IsNothing(cboxEmpresa.SelectedValue) Then
            listado.id_parametros = cboxEmpresa.SelectedValue.ToString
        End If

        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cboxCuentaContpaq.DisplayMember = "Código"
        cboxCuentaContpaq.ValueMember = "Parámetro"
        cboxCuentaContpaq.DataSource = listado.listParametros

        cboxCuentaContpaq.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub

    Private Sub btnCuentaSAY_Click(sender As Object, e As EventArgs) Handles btnCuentaSAY.Click

        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 5

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cboxCuentaSAY.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxCuentaSAY.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        If Not IsNothing(cboxEmpresa.SelectedValue) Then
            listado.id_parametros = cboxEmpresa.SelectedValue.ToString
        End If

        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cboxCuentaSAY.DisplayMember = "Número de Cuenta"
        cboxCuentaSAY.ValueMember = "Parámetro"
        cboxCuentaSAY.DataSource = listado.listParametros

        cboxCuentaSAY.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub

    Private Sub btnCuentaBancaria_Click(sender As Object, e As EventArgs) Handles btnCuentaBancaria.Click

        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 6

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cboxCuentaBancaria.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cboxCuentaBancaria.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        If Not IsNothing(cboxEmpresa.SelectedValue) Then
            listado.id_parametros = cboxEmpresa.SelectedValue.ToString
        End If

        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cboxCuentaBancaria.DisplayMember = "Número de Cuenta"
        cboxCuentaBancaria.ValueMember = "Parámetro"
        cboxCuentaBancaria.DataSource = listado.listParametros

        cboxCuentaBancaria.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
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


End Class