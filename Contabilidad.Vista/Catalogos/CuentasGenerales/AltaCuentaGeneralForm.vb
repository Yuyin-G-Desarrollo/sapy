Imports Contabilidad.Negocios
Imports Tools

Public Class AltaCuentaGeneralForm

    Dim CuentaSAy As String
    Dim CuentaContpaq As String
    Dim GuardarEditar As Boolean ''Valor true para guradar informacion, valor false para editar einformacion
    Dim objCuentaGeneral As New Entidades.CuentaContableGeneral

    Public Agregar_Editar As Boolean ''TRUE PARA DAR DE ALTA CUENTAS CONTABLES, FALSE PARA EDITAR CUENTAS CONTABLES
    Public cuenta_general_id As Integer

    Private Sub AltaCuentaGeneralForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lista_Empresas()
        lista_TipoPoliza()

        If Agregar_Editar = False Then
            CargarInformacionCliente()
            lblTitulo.Text = "Editar Cuenta General"
            Me.Text = "Editar Cuenta General"
        Else
            lblTitulo.Text = "Alta Cuenta General"
            Me.Text = "Alta Cuenta General"
        End If
    End Sub

    Private Sub CargarInformacionCliente()
        Dim objBU As New Negocios.CuentasGeneralesBU
        Dim tabla As New DataTable
        Dim row As DataRow

        tabla = objBU.Consulta_Datos_Cuentas_Generales(cuenta_general_id)
        row = tabla.Rows(0)

        cmbEmpresa.SelectedValue = row.Item("essc_empresaid")
        cmbTipoPoliza.SelectedValue = row.Item("poti_polizatipoid")


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
        cmbCuentaContpaq.DisplayMember = "cgen_cuenta"
        cmbCuentaContpaq.ValueMember = "cgen_cuentacontpaqid"
        cmbCuentaContpaq.DataSource = tabla
        cmbCuentaContpaq.SelectedValue = CInt(row.Item("cgen_cuentacontpaqid"))
        'cboxCuentaContpaq.SelectedText = CInt(row.Item("cgen_cuenta"))

        ''COMBOBOX CUENTA CONTABLE EN SAY
        cmbCuentaSAY.DisplayMember = "cuco_cuentacontable"
        cmbCuentaSAY.ValueMember = "cuco_cuentacontableid"
        cmbCuentaSAY.DataSource = tabla
        cmbCuentaSAY.SelectedValue = CInt(row.Item("cuco_cuentacontableid"))
        'cboxCuentaContpaq.SelectedText = CInt(row.Item("cgen_cuenta"))

        ''COMBOBOX CUENTA BANCARIA
        cmbCuentaBancaria.DisplayMember = "cuba_numero"
        cmbCuentaBancaria.ValueMember = "cuba_cuentaid"
        cmbCuentaBancaria.DataSource = tabla
        Try
            cmbCuentaBancaria.SelectedValue = CInt(row.Item("cuba_cuentaid"))
        Catch ex As Exception
            cmbCuentaBancaria.SelectedValue = 0
        End Try

        '' COMBOBOX TIPO POLIZA CONTPAQ
        If Not IsDBNull(row.Item("cgen_tipopolizacontpaqid")) Then
            If row.Item("cgen_tipopolizacontpaqid") > 0 Then
                objCuentaGeneral.tipopolizaContpaq = CInt(row.Item("cgen_tipopolizacontpaqid"))
                btnTipoPolizaContpaq.PerformClick()
            End If
        End If


    End Sub


    Private Sub AltaCuentaGeneralForm_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim caracter As Char = e.KeyChar

        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    ''' <summary>
    ''' VALIDA QUE TODOS LOS CAMPOS MARCADOS COMO OBLIGATORIOS HAYAN SIDO LLENADOS
    ''' </summary>
    ''' <returns>VARIABLE DEL TIPO BOOOLEANO CON VALOR TRUE PARA CUANDO HAYA CAMPOS SIN LLENAR Y 
    ''' VALOR FALSE PARA CUANDO TODOS LOS CAMPOS OBLIGATORIOS HAYAN SIDO LLENADOS</returns>
    ''' <remarks></remarks>
    Private Function ValidarCamposVacios() As Boolean

        ''RAZON SOCIAL
        If Not IsNothing(cmbEmpresa.SelectedValue) Then
            lblRazonSocial.ForeColor = Drawing.Color.Black
        Else
            show_message("Advertencia", "Selecciona una empresa.")
            lblRazonSocial.ForeColor = Drawing.Color.Red
            ValidarCamposVacios = True
        End If

        ''TIPO POLIZA
        If Not IsNothing(cmbTipoPoliza.SelectedValue) Then
            lblTipoPoliza.ForeColor = Drawing.Color.Black
        Else
            show_message("Advertencia", "Selecciona un tipo de poliza.")
            lblTipoPoliza.ForeColor = Drawing.Color.Red
            ValidarCamposVacios = True
        End If

        ''CUENTA SAY
        If Not IsNothing(cmbCuentaSAY.SelectedValue) Then
            lblClave.ForeColor = Drawing.Color.Black
        Else
            show_message("Advertencia", "El Selecciona una cuenta Contpaq.")
            lblCuentaSAY.ForeColor = Drawing.Color.Red
            ValidarCamposVacios = True
        End If

        ''CUENTA CONTPAQ
        If Not IsNothing(cmbCuentaContpaq.SelectedValue) Then
            lblCuentaContpaq.ForeColor = Drawing.Color.Black
            lblNombre.ForeColor = Drawing.Color.Black
            lblCuenta.ForeColor = Drawing.Color.Black
        Else
            show_message("Advertencia", "El Selecciona una cuenta Contpaq.")
            lblCuentaContpaq.ForeColor = Drawing.Color.Red
            lblNombre.ForeColor = Drawing.Color.Red
            lblCuenta.ForeColor = Drawing.Color.Red
            ValidarCamposVacios = True
        End If


        If CuentaContpaq <> CuentaSAy And CuentaContpaq <> "" And CuentaSAy <> "" Then
            show_message("Advertencia", "La cuenta Contpaq y la cuenta SAY no coinciden")
            lblCuenta.ForeColor = Drawing.Color.Red
            ValidarCamposVacios = True
        Else
            lblCuenta.ForeColor = Drawing.Color.Black
        End If

        Return ValidarCamposVacios
    End Function

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


#Region "ACCIONES COMBOS"

    Private Sub lista_TipoPoliza()
        cmbTipoPoliza.DataSource = Nothing
        Dim objBU As New PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_TipoPoliza
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbTipoPoliza.DisplayMember = "poti_nombre"
        cmbTipoPoliza.ValueMember = "poti_polizatipoid"
        cmbTipoPoliza.DataSource = tabla
        cmbTipoPoliza.SelectedValue = 0
    End Sub

    Private Sub lista_Empresas()
        cmbEmpresa.DataSource = Nothing
        Dim objBU As New PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbEmpresa.ValueMember = "essc_empresaid"
        cmbEmpresa.DisplayMember = "essc_razonsocial"
        cmbEmpresa.DataSource = tabla
        cmbEmpresa.SelectedValue = 0
    End Sub

    Private Sub cboxEmpresa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedValueChanged

        If Not IsDBNull(cmbEmpresa.SelectedValue) And Not IsNothing(cmbEmpresa.SelectedValue) Then
            If cmbEmpresa.SelectedValue > 0 Then
                cmbTipoPoliza.Enabled = True
            Else
                cmbTipoPoliza.SelectedIndex = 0
                cmbTipoPoliza.Enabled = False
            End If
        Else
            cmbTipoPoliza.SelectedIndex = -1
            cmbTipoPoliza.Enabled = False
        End If

    End Sub

    Private Sub cboxTipoPoliza_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoPoliza.SelectedValueChanged

        cmbCuentaContpaq.DataSource = Nothing
        cmbCuentaSAY.DataSource = Nothing
        cmbCuentaBancaria.DataSource = Nothing
        cmbTipoPolizaContpaq.DataSource = Nothing

        If Not IsDBNull(cmbTipoPoliza.SelectedValue) And Not IsNothing(cmbTipoPoliza.SelectedValue) Then

            If cmbTipoPoliza.SelectedValue > 0 Then
                Dim objBU As New Negocios.PolizaBU

                txtNumCuenta.Enabled = True
                txtNombreCuenta.Enabled = True
                txtClave.Enabled = True
                btnCuentaSAY.Enabled = True
                cmbCuentaSAY.Enabled = True
                btnCuentaBancaria.Enabled = True
                cmbCuentaBancaria.Enabled = True

                If objBU.Existe_Tabla_Contpaq(cmbEmpresa.SelectedValue, "Cuentas") Then
                    btnCuentaContpaq.Enabled = True
                    cmbCuentaContpaq.Enabled = True
                    btnTipoPolizaContpaq.Enabled = True
                    cmbTipoPolizaContpaq.Enabled = True
                    btnAceptar.Enabled = True
                Else
                    show_message("Advertencia", "Esta empresa no tiene cuentas en Contpaq")
                    Me.DialogResult = Windows.Forms.DialogResult.None
                    btnCuentaContpaq.Enabled = False
                    cmbCuentaContpaq.Enabled = False
                    btnTipoPolizaContpaq.Enabled = False
                    cmbTipoPolizaContpaq.Enabled = False
                    btnAceptar.Enabled = False
                End If
            Else
                txtNumCuenta.Enabled = False
                txtNombreCuenta.Enabled = False
                txtClave.Enabled = False
                btnCuentaSAY.Enabled = False
                cmbCuentaSAY.Enabled = False
                btnCuentaBancaria.Enabled = False
                cmbCuentaBancaria.Enabled = False
            End If

        Else
            btnCuentaSAY.Enabled = False
            cmbCuentaSAY.Enabled = False
        End If

        txtClave.Text = ""
        txtNombreCuenta.Text = ""
        txtNumCuenta.Text = ""

    End Sub


#End Region

#Region "ACCIONES BOTONES"

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click


        Dim CamposVacios As Boolean = ValidarCamposVacios()

        If CamposVacios = False Then


            Dim objBU As New Negocios.CuentasGeneralesBU
            Dim EmpresaSAY_SICY As New Entidades.EmpresaSAY_SICY
            Dim TipoPoliza As New Entidades.TipoPoliza
            Dim CuentaBancaria As New Entidades.CuentaBancaria

            TipoPoliza.polizatipoid = cmbTipoPoliza.SelectedValue
            EmpresaSAY_SICY.empresaid = cmbEmpresa.SelectedValue

            objCuentaGeneral.tipopoliza = TipoPoliza
            objCuentaGeneral.empresa = EmpresaSAY_SICY
            objCuentaGeneral.cuenta = txtNumCuenta.Text
            objCuentaGeneral.nombre = txtNombreCuenta.Text
            objCuentaGeneral.cuentacontpaq = cmbCuentaContpaq.SelectedValue
            objCuentaGeneral.cuentasay = cmbCuentaSAY.SelectedValue

            If txtClave.Text.Length > 1 Then
                objCuentaGeneral.clave = txtClave.Text
            Else
                objCuentaGeneral.clave = String.Empty
            End If

            If Not IsNothing(cmbCuentaBancaria.SelectedValue) Then
                CuentaBancaria.cuentaid = cmbCuentaBancaria.SelectedValue
                objCuentaGeneral.cuentabancaria = CuentaBancaria
            Else
                CuentaBancaria.cuentaid = 0
                objCuentaGeneral.cuentabancaria = CuentaBancaria
            End If

            If Not IsNothing(cmbTipoPolizaContpaq.SelectedValue) Then
                objCuentaGeneral.tipopolizaContpaq = cmbTipoPolizaContpaq.SelectedValue
            Else
                objCuentaGeneral.tipopolizaContpaq = 0
            End If

            If Agregar_Editar Then
                Try
                    objBU.alta_edicion_cuenta_contable_general(1, objCuentaGeneral)
                    show_message("Exito", "Información guardada con éxito")
                Catch ex As Exception
                    show_message("Error", "Algo surgió mal durante el proceso de guardado: " + ex.Message)
                    Me.DialogResult = Windows.Forms.DialogResult.None
                End Try


            Else
                objCuentaGeneral.cuentageneralid = cuenta_general_id
                Try
                    objBU.alta_edicion_cuenta_contable_general(2, objCuentaGeneral)
                    show_message("Exito", "Información guardada con éxito")
                Catch ex As Exception
                    show_message("Error", "Algo surgió mal durante el proceso de guardado")
                    Me.DialogResult = Windows.Forms.DialogResult.None
                End Try
            End If

        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If

    End Sub

    Private Sub btnCuentaContpaq_Click(sender As Object, e As EventArgs) Handles btnCuentaContpaq.Click

        Dim listado As New ListadoParametrosBusquedaForm
        listado.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        listado.tipo_busqueda = 4

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cmbCuentaContpaq.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cmbCuentaContpaq.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        If Not IsNothing(cmbEmpresa.SelectedValue) Then
            listado.id_parametros = "0," + cmbEmpresa.SelectedValue.ToString
        End If

        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cmbCuentaContpaq.DataSource = listado.listParametros
        cmbCuentaContpaq.DisplayMember = "Código"
        cmbCuentaContpaq.ValueMember = "Parámetro"


        txtNombreCuenta.Text = listado.listParametros.Rows(0).Item("Nombre de Cuenta")
        txtNumCuenta.Text = listado.listParametros.Rows(0).Item("Código")

        cmbCuentaContpaq.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub

    Private Sub btnCuentaSAY_Click(sender As Object, e As EventArgs) Handles btnCuentaSAY.Click

        Dim listado As New ListadoParametrosBusquedaForm
        listado.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        listado.tipo_busqueda = 5

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cmbCuentaSAY.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cmbCuentaSAY.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        If Not IsNothing(cmbEmpresa.SelectedValue) Then
            listado.id_parametros = cmbEmpresa.SelectedValue.ToString
        End If

        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cmbCuentaSAY.DataSource = listado.listParametros
        cmbCuentaSAY.DisplayMember = "Número de Cuenta"
        cmbCuentaSAY.ValueMember = "Parámetro"


        cmbCuentaSAY.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub

    Private Sub btnCuentaBancaria_Click(sender As Object, e As EventArgs) Handles btnCuentaBancaria.Click

        Dim listado As New ListadoParametrosBusquedaForm
        listado.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        listado.tipo_busqueda = 6

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cmbCuentaBancaria.SelectedValue) Then
            parametro = String.Empty
        Else
            parametro = cmbCuentaBancaria.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        If Not IsNothing(cmbEmpresa.SelectedValue) Then
            listado.id_parametros = cmbEmpresa.SelectedValue.ToString
        End If

        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cmbCuentaBancaria.DataSource = listado.listParametros
        cmbCuentaBancaria.DisplayMember = "Número de Cuenta"
        cmbCuentaBancaria.ValueMember = "Parámetro"


        cmbCuentaBancaria.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub


#End Region



    Private Sub btnTipoPolizaContpaq_Click(sender As Object, e As EventArgs) Handles btnTipoPolizaContpaq.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.StartPosition = Windows.Forms.FormStartPosition.CenterScreen

        listado.tipo_busqueda = 11

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cmbTipoPolizaContpaq.SelectedValue) And Agregar_Editar = True Then
            parametro = String.Empty
        ElseIf IsNothing(cmbTipoPolizaContpaq.SelectedValue) And Agregar_Editar = False Then
            If objCuentaGeneral.tipopolizaContpaq > 0 Then
                parametro = objCuentaGeneral.tipopolizaContpaq
                listado.carga_Automatica = True
            Else
                parametro = String.Empty
            End If
        Else
            parametro = cmbTipoPolizaContpaq.SelectedValue.ToString
        End If

        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID

        If Not IsNothing(cmbEmpresa.SelectedValue) Then
            listado.id_parametros = cmbEmpresa.SelectedValue.ToString
        End If

        listado.ShowDialog()
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        Dim codigo As Integer = CInt(listado.listParametros.Rows(0).Item("Código"))

        cmbTipoPolizaContpaq.DisplayMember = "Tipo"
        cmbTipoPolizaContpaq.ValueMember = "Parámetro"
        cmbTipoPolizaContpaq.DataSource = listado.listParametros

        cmbTipoPolizaContpaq.SelectedValue = codigo
    End Sub

    Private Sub txtNombreCuenta_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtNombreCuenta.KeyPress
        e.Handled = True
    End Sub

    Private Sub txtNumCuenta_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtNumCuenta.KeyPress
        e.Handled = True
    End Sub
End Class