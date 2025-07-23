Imports Contabilidad.Datos

Public Class CuentasContablesBU

    ''' <summary>
    ''' FUNCION PARA RECUPERAR LA LISTA DE CUENTAS CONTABLES SEGUN LOS FILTROS SELECCIONADOS POR EL USUSARIO
    ''' </summary>
    ''' <param name="empresaID">ID DE LA EMPRESA(EMPRESASAYSICYCONTPAQ) DE LA CUAL SE RECUPERARAN LAS CUENTAS CONTABLES</param>
    ''' <param name="tipoCuentaID">ID DEL TIPO DE CUENTA(SAY) DEL CUAL SE RECUPERARAN LAS CUENTAS CONTABLES</param>
    ''' <param name="proveedorID"> ID DEL PROVEEDOR(SAY) DEL CUAL SE RECUPERARAN LAS CUENTAS CONTABLES</param>
    ''' <param name="clienteID">ID DEL CLIENTE(SAY) DEL CUAL SE RECUPERARAN LAS CUENTAS CONTABLES</param>
    ''' <param name="ClienteProveedor">VARIABLE DEL TIPO BOLEANO QUE EN SU VALOR POSITIVO INDICA QUE SE HARA JOIN CON LAS TABLAS DE
    ''' CLIENTES Y PROVEEDORES</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Consulta_lista_Cuentas_Contables(empresaID As String, tipoCuentaID As String, proveedorID As String,
                                                     clienteID As String, ClienteProveedor As Boolean) As DataTable

        Dim objDA As New CuentasContablesDA
        Return objDA.Consulta_lista_Cuentas_Contables(empresaID, tipoCuentaID, proveedorID, clienteID, ClienteProveedor)

    End Function


    Public Function Consulta_Cuentas_Contables_Consecutivo(empresaID As String, constante1 As String, constante2 As String, letra As String) As DataTable

        Dim objDA As New CuentasContablesDA
        Return objDA.Consulta_Cuentas_Contables_Consecutivo(empresaID, constante1, constante2, letra)

    End Function


    Public Function Recuperar_Empresa_SSC(ByVal IdEmpresaSaySicyContpaq As Integer) As Entidades.EmpresaSAY_SICY
        Dim objDA As New Datos.CuentasContablesDA
        Dim dtTabla As New DataTable
        Recuperar_Empresa_SSC = New Entidades.EmpresaSAY_SICY

        dtTabla = objDA.Recuperar_Empresa_SSC(IdEmpresaSaySicyContpaq)

        If dtTabla.Rows.Count = 1 Then
            Recuperar_Empresa_SSC.empresaid = dtTabla.Rows(0).Item("essc_empresaid")
            Recuperar_Empresa_SSC.sayid = dtTabla.Rows(0).Item("essc_sayid")
            Recuperar_Empresa_SSC.contribuyentesicyid = dtTabla.Rows(0).Item("essc_contribuyentesicyid")
            Recuperar_Empresa_SSC.razonsocial = dtTabla.Rows(0).Item("essc_razonsocial")
            Recuperar_Empresa_SSC.doctoventassicyid = dtTabla.Rows(0).Item("essc_doctoventassicyid")
        End If

        Return Recuperar_Empresa_SSC
    End Function


    ''' <summary>
    ''' FUNCION QUE REGRESA UN VALOR DEL TIPO ENTERO EL CUAL CORRESPONDE AL ID DE TIPO DE CUENTA CONTABLE EN LA BASE DE DATOS DEL SICY, EL CUAL ES CONSULTADO
    ''' EN LA BASE DE DATOS DE SAY
    ''' </summary>
    ''' <param name="IdTipoCuentaContableSay">ID DEL TIPO DE CUENTA CONTABLE EN LA BASE DE DATOS DEL SAY DEL CUAL SE OBTENDRA EL ID DE TIPO
    ''' DE CUENTA CONTABLE CORRESPONDIENTE A LA BASE DE DATOS DEL SICY</param>
    ''' <returns>VARIABLE DEL TIPO ENTERO CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Id_Tipo_CuentaContabilidad_Sicy(ByVal IdTipoCuentaContableSay As Integer) As Integer
        Dim objDA As New Datos.CuentasContablesDA
        Dim dtTabla As New DataTable

        dtTabla = objDA.Recuperar_Id_Tipo_CuentaContabilidad_Sicy(IdTipoCuentaContableSay)

        If dtTabla.Rows.Count = 1 Then
            Recuperar_Id_Tipo_CuentaContabilidad_Sicy = dtTabla.Rows(0).Item("ticc_tipocuentacontabilidadSICYid")
        Else
            Recuperar_Id_Tipo_CuentaContabilidad_Sicy = 0
        End If

        Return Recuperar_Id_Tipo_CuentaContabilidad_Sicy

    End Function


    ''' <summary>
    ''' FUNCION LA CUAL VALIDA QUE UNA CUENTA CONTABLE QUE SE PRETENDE REGISTRAR NO HAYA SIDO DADA DE ALTA ANTERIORMENTE, SÍ LA CUENTA YA
    ''' EXISTE DEVOLVERA UN VALOR DEL TIPO BOLEANO 'TRUE', DE LO CONTRARIO MANDARA UN VALOR FALSE INDICANDO QUE LA CUENTA NO EXISTE
    ''' </summary>
    ''' <param name="CuentaContable"> ENTIDAD DE LA CLASE CUENTACONTABLE CON LA INFORMACION DE LA CUENTA A VALIDAR</param>
    ''' <returns>VARIABLE DEL TIPO BOLEANA CON VALOR TRUE EN CASO DE QUE LA CUENTA BUSCADA EXISTA, Y VALOR FALSE EN CASO DE QUE LA CUENTA NO EXISTA</returns>
    ''' <remarks></remarks>
    Public Function Validar_CuentaContable_No_Existente(ByVal CuentaContable As Entidades.CuentaContable) As Boolean
        Dim objDA As New Datos.CuentasContablesDA
        Dim dtTabla As New DataTable

        dtTabla = objDA.Validar_CuentaContable_No_Existente(CuentaContable)

        If dtTabla.Rows.Count > 0 Then
            Validar_CuentaContable_No_Existente = True
        Else
            Validar_CuentaContable_No_Existente = False
        End If

        Return Validar_CuentaContable_No_Existente
    End Function


    ''' <summary>
    ''' METODO EL CUAL DA DE ALTA O EDITA UN REGISTRO DE CUENTA CONTBLE DE LA BASE DE DATOS DEL SICY, ESTO SEGUN EL VALOR RECIBIDO EN UNA DE 
    ''' SUS VARIABLES
    ''' </summary>
    ''' <param name="AltaEdicion">VARIABLE DEL TIPO BOLEANO LA CUAL INDICA QUE SE REALIZARA UN INSERT EN LA BASE DE DATOS CUANDO SU VALOR SEA 
    ''' 'TRUE' E INDICA QUE LA ACCION QUE SE REALIZARA SERA UN UPDATE CUANDO SU VALOR SEA 'FALSE'</param>
    ''' <param name="CuentaContable"></param>
    ''' <returns>ENTIDAD DE LA CLASE CUENTACONTABLE CON LA INFORMACION DE LA CUENTA CONTABLE A INSERTAR/EDITAR</returns>
    ''' <remarks></remarks>
    Public Function Alta_Edicion_CuentasContablesSay(ByVal AltaEdicion As Boolean, ByVal CuentaContable As Entidades.CuentaContable) As String
        Dim objDA As New Datos.CuentasContablesDA
        Alta_Edicion_CuentasContablesSay = String.Empty

        If AltaEdicion = True Then
            If Validar_CuentaContable_No_Existente(CuentaContable) = False Then
                objDA.Alta_Edicion_CuentasContablesSay(AltaEdicion, CuentaContable)
                Alta_Edicion_CuentasContablesSay = "Registro guardado exitosamente"
            Else
                Alta_Edicion_CuentasContablesSay = "La cuenta contable ya existe"
            End If
        Else
            objDA.Alta_Edicion_CuentasContablesSay(AltaEdicion, CuentaContable)
            Alta_Edicion_CuentasContablesSay = "Registro actualizado exitosamente"
        End If

    End Function

    Public Function EmpresasRegistrarCuentas() As DataTable
        Dim ObjD As New CuentasContablesDA
        Return ObjD.EmpresasRegistrarCuentas()
    End Function

    Public Function tiopoCuenta() As DataTable
        Dim objD As New CuentasContablesDA
        Return objD.tiopoCuenta()
    End Function

    Public Function RegistrarCuentasAlmacen() As DataTable
        Dim objD As New CuentasContablesDA
        Return objD.RegistrarCuentasAlmacen()
    End Function

    Public Function ConsultaRegistrarCuentas(ByVal Empresa As String, ByVal TipoCta As String, Mostrar As Integer, Estatus As Integer) As DataTable
        Dim objD As New CuentasContablesDA
        Return objD.ConsultaRegistrarCuentas(Empresa, TipoCta, Mostrar, Estatus)
    End Function

    Public Function ConsultaRegistrarCuentasMateriales(ByVal Empresa As String, ByVal TipoCta As String, Mostrar As Integer, Estatus As Integer, ByVal Almacen As Integer) As DataTable
        ', ByVal FechaDel As Date, ByVal FechaAl As Date
        Dim objD As New CuentasContablesDA
        Return objD.ConsultaRegistrarCuentasMateriales(Empresa, TipoCta, Mostrar, Estatus, Almacen)
        ', FechaDel, FechaAl
    End Function

    Public Function ConsultaEmpresaSICY(ByVal IdEmpresa As Integer) As DataTable
        Dim objD As New CuentasContablesDA
        Return objD.ConsultaEmpresaSICY(IdEmpresa)
    End Function

    Public Function ConsultarEmpresaCP(ByVal IdEmpresaCP As Integer) As DataTable
        Dim objD As New CuentasContablesDA
        Return objD.ConsultarEmpresaCP(IdEmpresaCP)
    End Function

    Public Function ConsultaCuentasporEmpresa(ByVal AliasBDD As String) As DataTable
        Dim objD As New CuentasContablesDA
        Return objD.ConsultaCuentasporEmpresa(AliasBDD)
    End Function

    Public Function InsertarRegistrarCuentas(ByVal IdEmpresaSICY As Integer, ByVal IdEmpresaContpaq As Integer, ByVal IdTipoCta As Integer, ByVal ClaveSicy As Integer,
                                           ByVal ClaveCuenta As Integer, ByVal Cuenta As String, ByVal Descripcion As String, ByVal IdSegmentoN As String, ByVal Estatus As String,
                                           ByVal UsuarioAlta As String, ByVal UsuarioActualizo As String, ByVal Concurrency As Integer, ByVal IdAlmacen As Integer,
                                           ByVal Accion As Integer, ByVal idTabla As Integer) As DataTable
        Dim objD As New CuentasContablesDA
        Return objD.InsertarRegistrarCuentas(IdEmpresaSICY, IdEmpresaContpaq, IdTipoCta, ClaveSicy, ClaveCuenta, Cuenta, Descripcion, IdSegmentoN, Estatus, UsuarioAlta, UsuarioActualizo, Concurrency, IdAlmacen, Accion, idTabla)
    End Function
End Class
