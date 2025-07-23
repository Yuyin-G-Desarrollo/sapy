Imports Tools
Imports System.Windows.Forms


Public Class RelacionarEmpresaSaySicyContpaqForm

    Public objEmpresaSSC As New Entidades.EmpresaSAY_SICY
    Public AltaEdicion As Boolean
    Dim objLista As New ListadoParametrosBusquedaForm
    Dim camposVacios As Boolean = False

    ''' <summary>
    ''' EVENTO LOAD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RelacionarEmpresaSaySicyContpaqForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tools.Controles.ComboEmpresaActiva(cmbRazonSocial)

        If AltaEdicion = False Then
            cmbRazonSocial.SelectedValue = objEmpresaSSC.sayid
            txtBaseDeDatos.Text = objEmpresaSSC.empresacontpaq
            txtServidor.Text = objEmpresaSSC.servidor

            btnContribuyente.PerformClick()
            btnEmpresaDoctosVentas.PerformClick()

        End If

    End Sub



    ''' <summary>
    ''' EVENTO CLICK EN EL BOTON "BTNALTAEMPRESASAY" PARA ABRIR EL FORMULARIO PARA DAR DE ALTA UNA EMPRESA EN LA BASE DE DATOS DEL SAY
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAltaEmpresaSay.Click
        Dim FormaAltaEmpresa As New AltaEdicion_Empresa_SayForm
        FormaAltaEmpresa.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        FormaAltaEmpresa.Agregar_Editar_Empresa = True
        FormaAltaEmpresa.Empresa.Pempr_empresaid = 0
        FormaAltaEmpresa.ShowDialog()
    End Sub

    ''' <summary>
    ''' EVENTO CLICK EN EL BOTON "BTNCONTRIBUYENTE" PARA SELECCIONAR UN CONTROBUYENTE DE UNA LISTA QUE SE ABRIRA EN UNA VENTANA NUEVA "
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnContribuyente_Click(sender As Object, e As EventArgs) Handles btnContribuyente.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 9

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cmbUContribuyente.SelectedValue) And AltaEdicion = True Then
            parametro = String.Empty
        ElseIf IsNothing(cmbUContribuyente.SelectedValue) And AltaEdicion = False Then
            parametro = objEmpresaSSC.contribuyentesicyid
            listado.carga_Automatica = True
        Else
            parametro = cmbUContribuyente.SelectedValue.ToString
        End If


        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        'If Not IsNothing(cmbUContribuyente.SelectedValue) Then
        '    listado.id_parametros = cmbRazonSocial.SelectedValue.ToString
        'End If
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cmbUContribuyente.DisplayMember = "Razón Social"
        cmbUContribuyente.ValueMember = "Parámetro"
        cmbUContribuyente.DataSource = listado.listParametros

        cmbUContribuyente.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub

    ''' <summary>
    ''' EVENTO CLICK EN EL BOTÓN "BTNEMPRESASDOCTOSVENTAS" PARA SELECCIONAR UNA EMPRESA DE LA TABLA DOCTOSVENTAS DEL SICY DE 
    ''' UNA LISTA QUE SE DESPLEGARA EN UNA VENTANA NUEVA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEmpresaDoctosVentas_Click(sender As Object, e As EventArgs) Handles btnEmpresaDoctosVentas.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 10

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cmbUEmpresaDOctosVentas.SelectedValue) And AltaEdicion = True Then
            parametro = String.Empty
        ElseIf IsNothing(cmbUEmpresaDOctosVentas.SelectedValue) And AltaEdicion = False Then
            parametro = objEmpresaSSC.doctoventassicyid
            listado.carga_Automatica = True
        Else
            parametro = cmbUEmpresaDOctosVentas.SelectedValue.ToString
        End If

        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        'If Not IsNothing(cmbUContribuyente.SelectedValue) Then
        '    listado.id_parametros = cmbRazonSocial.SelectedValue.ToString
        'End If
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cmbUEmpresaDOctosVentas.DisplayMember = "Razón Social"
        cmbUEmpresaDOctosVentas.ValueMember = "Parámetro"
        cmbUEmpresaDOctosVentas.DataSource = listado.listParametros

        cmbUEmpresaDOctosVentas.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub

    ''' <summary>
    ''' EVENTO CLIECK EN EL BOTÓN "BTNGUARDAR" PARA GUARDAR LA INFORMACION DEPENDIENDO DE SI LA VENTANA SE ABRIO PARA EDITAR 
    ''' INFORMACION O PARA DAR DE ALTA UNA RELACIÓN DE EMPRESAS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ValidarCamposVacios()

        If camposVacios = True Then Return

        Dim objBU As New Negocios.EmpresaSAY_SICY_ContpaqBU

        objEmpresaSSC.razonsocial = cmbRazonSocial.Text
        objEmpresaSSC.sayid = cmbRazonSocial.SelectedValue

        objEmpresaSSC.contribuyentesicyid = cmbUContribuyente.SelectedValue
        objEmpresaSSC.doctoventassicyid = cmbUEmpresaDOctosVentas.SelectedValue

        objEmpresaSSC.servidor = txtServidor.Text
        objEmpresaSSC.empresacontpaq = txtBaseDeDatos.Text

        Try
            objBU.AltaEdicion_Relacion_EmpresaSAySicyContpaq(objEmpresaSSC, AltaEdicion)

            Dim objExito As New ExitoForm
            objExito.StartPosition = FormStartPosition.CenterScreen
            objExito.mensaje = "Registro guardado exitosamente."
            objExito.ShowDialog()
        Catch ex As Exception
            Dim objError As New ErroresForm
            objError.StartPosition = FormStartPosition.CenterScreen
            objError.mensaje = "Ocurrio un error inesperado: " + ex.Message
            objError.ShowDialog()
        End Try

    End Sub

    ''' <summary>
    ''' METÓDO PARA VALIDAR SI EXISTEN CAMPOS OBLIGATORIOS SIN SER LLENADOS E IMPEDIR QUE SE PUEDA GUARDAR LA INFORMACIÓN
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ValidarCamposVacios()
        camposVacios = False

        If cmbRazonSocial.SelectedIndex = 0 Then
            lblRazonSocialSay.ForeColor = Drawing.Color.Red
            camposVacios = True
        Else
            lblRazonSocialSay.ForeColor = Drawing.Color.Black
        End If

        'If txtRFC.Text = "" Then
        '    lblRFCSay.ForeColor = Drawing.Color.Red
        '    camposVacios = True
        'Else
        '    txtRFC.ForeColor = Drawing.Color.Black
        'End If

        If IsNothing(cmbUContribuyente.DataSource) Then
            camposVacios = True
            lblContribuyente.ForeColor = Drawing.Color.Red
        Else
            lblContribuyente.ForeColor = Drawing.Color.Black
        End If

        If IsNothing(cmbUEmpresaDOctosVentas.DataSource) Then
            camposVacios = True
            lblEmpresaDoctosVentas.ForeColor = Drawing.Color.Red
        Else
            lblEmpresaDoctosVentas.ForeColor = Drawing.Color.Black
        End If

        If txtBaseDeDatos.Text = "" Then
            lblDB.ForeColor = Drawing.Color.Red
            camposVacios = True
        Else
            lblDB.ForeColor = Drawing.Color.Black
        End If

        If txtServidor.Text = "" Then
            camposVacios = True
            lblServidor.ForeColor = Drawing.Color.Red
        Else
            lblServidor.ForeColor = Drawing.Color.Black
        End If


    End Sub

    ''' <summary>
    ''' EVENTO CLICK EN EL BOTÓN "BTNCERRAR" PARA CERRAR LA VENTANA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


End Class