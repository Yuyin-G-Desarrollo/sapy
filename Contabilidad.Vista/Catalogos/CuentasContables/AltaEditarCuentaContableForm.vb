Imports System.Windows.Forms

Public Class AltaEditarCuentaContableForm

    Public objCuentaContable As New Entidades.CuentaContable
    Public Alta_Edicion As Boolean = True ''TRUE PARA ALTA Y FALSE PARA EDICIÓN
    Public IdTipoCuentaContable As Integer
    Public IdEmpresaSSC As Integer
    Public IdProveedorSAY As Integer
    Public IdClienteSAY As Integer
    Public IdCuentaSicy As Integer
    Public IdCuentaContPac As Integer

    Dim CuentaContpaq As String = ""
    Dim cuentaSicy As String = ""
    Dim EmpresaSicyID As Integer

    Dim CamposVacios As Boolean ''TRUE PARA CAMPOS VACIOS, FALSE PARA CAMPOS COMPLETOS

    Private Sub AltaEditarCuentaContableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        lista_Empresas()
        lista_TipoCuentaContable()

        If Alta_Edicion = True Then
            Me.Text = "Alta de Cuentas Contables"
            lblTitulo.Text = "Alta de Cuentas Contables"
        Else
            Me.Text = "Edición de Cuentas Contables"
            lblTitulo.Text = "Edición de Cuentas Contables"
            cmbRazonSocial.SelectedValue = objCuentaContable.PIdEmpresa
            cmbTipoCuenta.SelectedValue = objCuentaContable.PIdTipoCuenta
            chkActivo.Checked = objCuentaContable.PStatus

            btnCuentaContpaq.PerformClick()

            If objCuentaContable.PIdCuentaContableSicy <> 0 Then
                btnCuentaSicy.PerformClick()
            End If

            If cmbTipoCuenta.Text = "CLIENTES" Then
                lblClienteProveedor.Visible = True
                cmbUClienteProveedor.Visible = True
                btnClienteProveedor.Visible = True
                lblClienteProveedor.Text = "* Cliente"
                btnClienteProveedor.PerformClick()
            ElseIf cmbTipoCuenta.Text = "PROVEEDORES" Then
                lblClienteProveedor.Visible = True
                cmbUClienteProveedor.Visible = True
                btnClienteProveedor.Visible = True
                lblClienteProveedor.Text = "* Proveedor"
                btnClienteProveedor.PerformClick()
            End If

            cmbRazonSocial.Enabled = False
            cmbTipoCuenta.Enabled = False
        End If
    End Sub


#Region "POBLAR COMBOS"

    Private Sub lista_Empresas()
        cmbRazonSocial.DataSource = Nothing
        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbRazonSocial.DataSource = tabla
        cmbRazonSocial.DisplayMember = "essc_razonsocial"
        cmbRazonSocial.ValueMember = "essc_empresaid"
        cmbRazonSocial.SelectedValue = 0
    End Sub

    Private Sub lista_TipoCuentaContable()
        cmbTipoCuenta.DataSource = Nothing
        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_TipoCuentaContable
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbTipoCuenta.DataSource = tabla
        cmbTipoCuenta.ValueMember = "ticc_tipocuentacontabilidadid"
        cmbTipoCuenta.DisplayMember = "ticc_nombre"
        cmbTipoCuenta.SelectedValue = 0
    End Sub

#End Region

#Region "ACCIONES COMBOS"

    Private Sub cmbRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRazonSocial.SelectedIndexChanged
        If Not IsNothing(cmbTipoCuenta.DataSource) Then
            cmbTipoCuenta.SelectedIndex = 0
        End If
        If Not IsNothing(cmbUCuentaContpaq.DataSource) Then
            cmbUCuentaContpaq.DataSource = Nothing
        End If
        If Not IsNothing(cmbUCuentaSicy.DataSource) Then
            cmbUCuentaSicy.DataSource = Nothing
        End If
        If Not IsNothing(cmbUClienteProveedor.DataSource) Then
            cmbUClienteProveedor.DataSource = Nothing
        End If
        txtNumeroCuenta.Text = ""

        If Not IsDBNull(cmbRazonSocial.SelectedValue) Then
            cmbTipoCuenta.Enabled = True
        Else
            cmbTipoCuenta.Enabled = False
        End If
    End Sub

    Private Sub cmbTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCuenta.SelectedIndexChanged
        If Not IsDBNull(cmbTipoCuenta.SelectedValue) Then
            cmbUClienteProveedor.Enabled = True
            btnClienteProveedor.Enabled = True
            cmbUCuentaContpaq.Enabled = True
            btnCuentaContpaq.Enabled = True
            cmbUCuentaSicy.Enabled = True
            btnCuentaSicy.Enabled = True
            cuentaSicy = ""
            CuentaContpaq = ""
            If cmbTipoCuenta.Text = "CLIENTES" Then
                lblClienteProveedor.Text = "* Cliente"
                lblClienteProveedor.Visible = True
                cmbUClienteProveedor.Visible = True
                btnClienteProveedor.Visible = True
            ElseIf cmbTipoCuenta.Text = "PROVEEDORES" Then
                lblClienteProveedor.Text = "* Proveedor"
                lblClienteProveedor.Visible = True
                cmbUClienteProveedor.Visible = True
                btnClienteProveedor.Visible = True
            Else
                lblClienteProveedor.Visible = False
                cmbUClienteProveedor.Visible = False
                btnClienteProveedor.Visible = False
            End If

            'If cmbTipoCuenta.Text = "CUENTAS BANCARIAS" Then
            '    cmbUCuentaSicy.Visible = False
            '    btnCuentaSicy.Visible = False
            '    cmbUCuentaSicy.DataSource = Nothing
            '    lblCuentaSicy.Visible = False
            'Else
            cmbUCuentaSicy.Visible = True
            btnCuentaSicy.Visible = True
            cmbUCuentaSicy.DataSource = Nothing
            lblCuentaSicy.Visible = True
            'End If
        Else
            cmbUClienteProveedor.Enabled = False
            btnClienteProveedor.Enabled = False
            cmbUCuentaContpaq.Enabled = False
            btnCuentaContpaq.Enabled = False
            cmbUCuentaSicy.Enabled = False
            btnCuentaSicy.Enabled = False
            cuentaSicy = ""
            CuentaContpaq = ""
        End If
    End Sub


#End Region

#Region "ACCIONES BOTONES"

    Private Sub btnClienteProveedor_Click(sender As Object, e As EventArgs) Handles btnClienteProveedor.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Dim listaParametroID As New List(Of String)
        Dim parametro As String

        If cmbTipoCuenta.Text = "PROVEEDORES" Then
            listado.tipo_busqueda = 1

            If IsNothing(cmbUClienteProveedor.SelectedValue) And Alta_Edicion = True Then
                parametro = String.Empty
            ElseIf IsNothing(cmbUCuentaSicy.SelectedValue) And Alta_Edicion = False Then
                parametro = objCuentaContable.PIdProveedor
                listado.carga_Automatica = True
            Else
                parametro = cmbUClienteProveedor.SelectedValue.ToString
            End If
            listaParametroID.Add(parametro)
            listado.listaParametroID = listaParametroID
            listado.id_parametros = cmbTipoCuenta.SelectedValue.ToString + "," + cmbRazonSocial.SelectedValue.ToString

            listado.ShowDialog(Me)

            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return

            If listado.listParametros.Rows.Count = 0 Then Return

            cmbUClienteProveedor.DataSource = listado.listParametros
            cmbUClienteProveedor.ValueMember = "Parámetro"
            cmbUClienteProveedor.DisplayMember = "Proveedor"
            cmbUClienteProveedor.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))

        ElseIf cmbTipoCuenta.Text = "CLIENTES" Then
            listado.tipo_busqueda = 2

            If IsNothing(cmbUClienteProveedor.SelectedValue) And Alta_Edicion = True Then 'Si no tiene nada seleccionado en el combo y es alta se trae todo el listado de clientes
                parametro = String.Empty
            ElseIf IsNothing(cmbUClienteProveedor.SelectedValue) And Alta_Edicion = False Then 'Si no tiene nada seleccionado en el combo y es edición envía como parámetro de búsqueda el idcliente
                parametro = objCuentaContable.PIdCliente
                listado.carga_Automatica = CBool(objCuentaContable.PIdCliente <> 0)
            Else
                parametro = cmbUClienteProveedor.SelectedValue.ToString
            End If
            listaParametroID.Add(parametro)

            listado.listaParametroID = listaParametroID
            '' If IsNothing(cmbUClienteProveedor.SelectedValue) Then
            'listado.id_parametros = ","
            If Not IsNothing(objCuentaContable.PIdCliente) AndAlso objCuentaContable.PIdCliente <> 0 Then
                listado.id_parametros = cmbRazonSocial.SelectedValue.ToString + "," + objCuentaContable.PIdCliente.ToString
            Else
                listado.id_parametros = cmbRazonSocial.SelectedValue
            End If


            ''Else
            'listado.id_parametros = cmbUClienteProveedor.SelectedValue.ToString + "," + cmbUClienteProveedor.SelectedValue.ToString
            ''End If

            listado.ShowDialog(Me)

                If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return

                If listado.listParametros.Rows.Count = 0 Then Return

                cmbUClienteProveedor.DataSource = listado.listParametros
                cmbUClienteProveedor.ValueMember = "Parámetro"
                cmbUClienteProveedor.DisplayMember = "Cliente"
                cmbUClienteProveedor.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))

            End If
    End Sub


    Private Sub btnCuentaSicy_Click(sender As Object, e As EventArgs) Handles btnCuentaSicy.Click
        If IsNothing(cmbRazonSocial.SelectedValue) Then Return

        Dim objBU As New Negocios.CuentasContablesBU
        Dim Empresa_SSC As New Entidades.EmpresaSAY_SICY
        Dim listado As New ListadoParametrosBusquedaForm
        Dim listaParametroID As New List(Of String)
        Dim parametro As String


        listado.StartPosition = Windows.Forms.FormStartPosition.CenterScreen

        listado.tipo_busqueda = 3

        If IsNothing(cmbUCuentaSicy.SelectedValue) And Alta_Edicion = True Then
            parametro = String.Empty
        ElseIf IsNothing(cmbUCuentaSicy.SelectedValue) And Alta_Edicion = False Then
            If objCuentaContable.PIdCuentaContableSicy = 0 Then
                parametro = String.Empty
            Else
                parametro = objCuentaContable.PIdCuentaContableSicy
                listado.carga_Automatica = True
            End If


        Else
            parametro = cmbUCuentaSicy.SelectedValue.ToString
        End If
        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID

        ''Recuperamos el id de la empresa en sicy
        Empresa_SSC = objBU.Recuperar_Empresa_SSC(cmbRazonSocial.SelectedValue.ToString)


        listado.id_parametros = cmbTipoCuenta.SelectedValue.ToString + "," + Empresa_SSC.contribuyentesicyid.ToString

        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return

        If listado.listParametros.Rows.Count = 0 Then Return

        cuentaSicy = listado.listParametros.Rows(0).Item("Cuenta")
        cmbUCuentaSicy.DataSource = listado.listParametros
        cmbUCuentaSicy.DisplayMember = "Descripción"
        cmbUCuentaSicy.ValueMember = "IdCuenta"
        cmbUCuentaSicy.SelectedValue = CInt(listado.listParametros.Rows(0).Item("IdCuenta"))


        If cuentaSicy <> "" And CuentaContpaq <> "" Then
            If cuentaSicy = CuentaContpaq Then
                txtNumeroCuenta.Text = CuentaContpaq.ToString
            End If
        End If

    End Sub


    Private Sub btnCuentaContpaq_Click(sender As Object, e As EventArgs) Handles btnCuentaContpaq.Click
        If IsNothing(cmbRazonSocial.SelectedValue) Then Return

        Dim listado As New ListadoParametrosBusquedaForm
        listado.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        listado.tipo_busqueda = 4

        If IsNothing(cmbUCuentaContpaq.SelectedValue) And Alta_Edicion = True Then
            parametro = String.Empty
        ElseIf IsNothing(cmbUCuentaContpaq.SelectedValue) And Alta_Edicion = False Then
            parametro = objCuentaContable.PIDCuentaContableContpaq
            listado.carga_Automatica = True
        Else
            parametro = cmbUCuentaContpaq.SelectedValue.ToString
        End If

        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        listado.id_parametros = cmbTipoCuenta.SelectedValue.ToString + "," + cmbRazonSocial.SelectedValue.ToString

        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return

        If listado.listParametros.Rows.Count = 0 Then Return

        CuentaContpaq = listado.listParametros.Rows(0).Item("Código")

        cmbUCuentaContpaq.DisplayMember = "Nombre de Cuenta"
        cmbUCuentaContpaq.ValueMember = "Parámetro"
        cmbUCuentaContpaq.DataSource = listado.listParametros

        cmbUCuentaContpaq.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))

        txtNumeroCuenta.Text = CuentaContpaq

        If cuentaSicy <> "" And CuentaContpaq <> "" Then
            If cuentaSicy = CuentaContpaq Then
                txtNumeroCuenta.Text = CuentaContpaq.ToString
            End If
        End If



    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        ValidarCamposVacios()

        If CamposVacios Then Return

        

        objCuentaContable.PConstante1 = txtNumeroCuenta.Text.Substring(0, 3)
        objCuentaContable.PConstante2 = txtNumeroCuenta.Text.Substring(3, 4)
        objCuentaContable.PLetra = txtNumeroCuenta.Text.Substring(7, 1)
        objCuentaContable.PConsecutivo = txtNumeroCuenta.Text.Substring(8, 3)
        objCuentaContable.PIDCuentaContableContpaq = cmbUCuentaContpaq.SelectedValue
        objCuentaContable.PIdCuentaContableSicy = cmbUCuentaSicy.SelectedValue
        If cmbTipoCuenta.Text = "PROVEEDORES" Then
            objCuentaContable.PIdProveedor = cmbUClienteProveedor.SelectedValue
        Else
            objCuentaContable.PIdProveedor = 0
        End If
        If cmbTipoCuenta.Text = "CLIENTES" Then
            objCuentaContable.PIdCliente = cmbUClienteProveedor.SelectedValue
        Else
            objCuentaContable.PIdCliente = 0
        End If
        objCuentaContable.PIdTipoCuenta = cmbTipoCuenta.SelectedValue
        objCuentaContable.PIdEmpresa = cmbRazonSocial.SelectedValue
        objCuentaContable.PStatus = chkActivo.Checked
        objCuentaContable.PDescripcion = cmbUCuentaContpaq.Text

        If Alta_Edicion = True Then
            GuardarCuentaContable(objCuentaContable)
        Else
            EditarCuentaContable(objCuentaContable)
        End If

    End Sub

#End Region


    Private Sub GuardarCuentaContable(ByVal CuentaContable As Entidades.CuentaContable)
        Dim objBU As New Negocios.CuentasContablesBU
        Dim Mensaje As String

        Try
            Mensaje = objBU.Alta_Edicion_CuentasContablesSay(True, CuentaContable)
            If Mensaje.Contains("existe") Then
                Mensajes_Y_Alertas("ADVERTENCIA", Mensaje)
            Else
                Mensajes_Y_Alertas("EXITO", Mensaje)
                Me.Close()
            End If

        Catch ex As Exception
            Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado: " + ex.Message)
        End Try

    End Sub


    Private Sub EditarCuentaContable(ByVal CuentaContable As Entidades.CuentaContable)
        Dim objBU As New Negocios.CuentasContablesBU
        Dim Mensaje As String

        Try
            Mensaje = objBU.Alta_Edicion_CuentasContablesSay(False, CuentaContable)
            Mensajes_Y_Alertas("EXITO", Mensaje)
            Me.Close()
        Catch ex As Exception
            Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado: " + ex.Message)
        End Try

    End Sub


    ''' <summary>
    ''' METODO QUE MANDA A LLAMAR UN FORMULARIO DE MENSAJE DE TOOLS, SEGUN EL TIPO DE MENSAJE QUE SE HAYA ENVIADO COMO PARAMETRO
    ''' </summary>
    ''' <param name="Tipo">CADENA CON EL NOMBRE DEL TIPO DE MENSAJE A MOSTRAR "ADVERTENCIA" PARA EL FORMULARIO ADVERTENCIAFORM DE TOOLS,
    ''' "EXITO" PARA EL FORMULARIO EXITOFORM DE TOOLS, "ERROR" PARA EL FORMULARIO ERRORESFORM DE TOOLS, "INFORMACION" PARA EL FORMULARIO
    ''' "AVISOFORM" DE TOOLS, Y "CONFIRMACION" PARA EL FORMULARIO "CONFIRMARFORM" </param>
    ''' <param name="Mensaje">MENSAJE QUE SE MOSTRARA EN EL FORMULARIO SELECCIONADO</param>
    ''' <remarks></remarks>
    Private Sub Mensajes_Y_Alertas(ByVal Tipo As String, ByVal Mensaje As String)
        If Tipo = "ADVERTENCIA" Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = Mensaje
            objAdvertencia.ShowDialog()
        ElseIf Tipo = "EXITO" Then
            Dim objExito As New Tools.ExitoForm
            objExito.StartPosition = FormStartPosition.CenterScreen
            objExito.mensaje = Mensaje
            objExito.ShowDialog()
        ElseIf Tipo = "ERROR" Then
            Dim objErrores As New Tools.ErroresForm
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.mensaje = Mensaje
            objErrores.ShowDialog()
        ElseIf Tipo = "INFORMACION" Then
            Dim objInformacion As New Tools.AvisoForm
            objInformacion.StartPosition = FormStartPosition.CenterScreen
            objInformacion.mensaje = Mensaje
            objInformacion.ShowDialog()
        ElseIf Tipo = "CONFIRMACION" Then
            Dim objConfirmacion As New Tools.ConfirmarForm
            objConfirmacion.StartPosition = FormStartPosition.CenterScreen
            objConfirmacion.mensaje = Mensaje
            objConfirmacion.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' METODO PARA VALIDAR QUE LOS CAMPOS OBLIGATORIOS HAYAN SIDO LLENADOS CORRECTAMENTE
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ValidarCamposVacios()
        Dim objAdvertencia As New Tools.AdvertenciaForm
        objAdvertencia.StartPosition = Windows.Forms.FormStartPosition.CenterScreen

        CamposVacios = False

        If cmbTipoCuenta.SelectedIndex <= 0 Then
            objAdvertencia.mensaje = "Selecciona el tipo de cuenta para poder guardar la información."
            objAdvertencia.ShowDialog()
            lblTipoCuenta.ForeColor = Drawing.Color.Red
            CamposVacios = True
        Else
            lblTipoCuenta.ForeColor = Drawing.Color.Black
        End If

        If cmbRazonSocial.SelectedIndex <= 0 Then
            objAdvertencia.mensaje = "Selecciona una 'Razón Social' para poder guardar la información"
            objAdvertencia.ShowDialog()
            lblRazonSocial.ForeColor = Drawing.Color.Red
            CamposVacios = True
        Else
            lblRazonSocial.ForeColor = Drawing.Color.Black
        End If

        If cmbUCuentaContpaq.SelectedValue <= 0 Then
            objAdvertencia.mensaje = "Selecciona una 'Cuenta Contpaq' para poder guardar la información"
            objAdvertencia.ShowDialog()
            lblCuentaContpaq.ForeColor = Drawing.Color.Red
            CamposVacios = True
        Else
            lblCuentaContpaq.ForeColor = Drawing.Color.Black
        End If

        If txtNumeroCuenta.Text = "" Then
            objAdvertencia.Text = "El numero de cuenta Sicy y Contpaq no coinciden o no han sido seleccionados"
            objAdvertencia.ShowDialog()
            lblNoCuenta.ForeColor = Drawing.Color.Red
            CamposVacios = True
        Else
            lblNoCuenta.ForeColor = Drawing.Color.Black
        End If

        If cmbUCuentaSicy.SelectedValue > 0 And cmbUCuentaContpaq.SelectedValue > 0 Then
            If CuentaContpaq <> cuentaSicy Then
                objAdvertencia.mensaje = "La cuenta Sicy y la cuenta Contpaq selecciónadas no coinciden. Seleccione las cuentas correctas"
                objAdvertencia.ShowDialog()
                lblNoCuenta.ForeColor = Drawing.Color.Red
                CamposVacios = True
            Else
                lblNoCuenta.ForeColor = Drawing.Color.Black
            End If
        End If
    End Sub


    
End Class