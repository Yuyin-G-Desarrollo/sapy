Imports Persistencia
Imports System.Data.SqlClient

Public Class CuentasContablesDA

    Public Function Consulta_lista_Cuentas_Contables(empresaID As String, tipoCuentaID As String, proveedorID As String,
                                                     clienteID As String, ByVal ClienteProveedor As Boolean) As DataTable

        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@EmpresaID", empresaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoCuentaID", tipoCuentaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProveedorID", proveedorID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ClienteID", clienteID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ClienteProveedor", ClienteProveedor)
        listaParametros.Add(parametro)

        Return ObjPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Consulta_ListaCuentasContables]", listaParametros)

        'Dim operaciones As New OperacionesProcedimientos
        'Dim consulta As String = String.Empty
        'consulta += " SELECT cuco_empresaid AS 'Empresa ID'," +
        '            " 	essc_razonsocial AS 'Empresa'," +
        '            " 	cuco_cuentacontableid AS 'Cuenta ID'," +
        '            " 	CAST(cuco_constante1 + cuco_constante2 + cuco_letra + cuco_consecutivo AS varchar(max)) AS 'Cuenta'," +
        '            " 	cuco_cuentacontabletipoid AS 'Tipo Cuenta ID'," +
        '            " 	ticc_nombre AS 'Tipo Cuenta'," +
        '            " 	cuco_proveedorid AS 'Proveedor ID'," +
        '            " 	cuco_clienteid AS 'Cliente ID',"
        'If ClienteProveedor = True Then
        '    consulta += " 	prov_nombregenerico AS 'Proveedor'," +
        '            " 	clie_nombregenerico AS 'Cliente',"
        'Else
        '    consulta += " 	'' AS 'Proveedor'," +
        '            " 	'' AS 'Cliente',"
        'End If

        'consulta += " 	cuco_descripcion as 'Descripción'," +
        '            " 	cuco_constante1 as 'Constante_1', " +
        '            " 	cuco_constante2 as 'Constante_2'," +
        '            " 	cuco_letra as 'Letra'," +
        '            " 	cuco_consecutivo as 'Consecutivo'," +
        '            " 	cuco_cuentacontablecontpaqid as 'Id_Cuenta_Contpaq'," +
        '            " 	cuco_cuentacontablesicyid as 'Id_Cuenta_Sicy'," +
        '            " 	cuco_status as 'Status'" +
        '            " FROM Contabilidad.CuentasContables" +
        '            " JOIN Framework.empresaSaySicyContpaq ON cuco_empresaid = essc_empresaid" +
        '            " JOIN Contabilidad.TiposCuentasContabilidad ON cuco_cuentacontabletipoid = ticc_tipocuentacontabilidadid"
        'If ClienteProveedor = True Then
        '    consulta += " LEFT JOIN Proveedor.Proveedor ON prov_proveedorid = cuco_proveedorid" +
        '            " LEFT JOIN Cliente.Cliente ON clie_clienteid = cuco_clienteid"
        'End If

        'consulta += " WHERE cuco_status = 1  "

        'If Not IsNothing(empresaID) Then
        '    consulta += "AND essc_empresaid = " + empresaID
        'End If

        'If Not IsNothing(tipoCuentaID) Then
        '    consulta += "AND ticc_tipocuentacontabilidadid = " + tipoCuentaID
        'End If

        'If ClienteProveedor = True Then
        '    If Not IsNothing(proveedorID) Then
        '        consulta += "AND prov_proveedorid = " + proveedorID
        '    End If

        '    If Not IsNothing(clienteID) Then
        '        consulta += "AND clie_clienteid = " + clienteID
        '    End If
        'End If

        'consulta += " ORDER BY [Empresa], [Cuenta], [Tipo Cuenta], [Proveedor], [Cliente]"

        'Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function Consulta_Cuentas_Contables_Consecutivo(empresaID As String, constante1 As String, constante2 As String, letra As String) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                    " SELECT TOP 1 ISNULL(cuco_consecutivo + 1, 1)" +
                    " FROM Contabilidad.CuentasContables" +
                    " WHERE" +
                    "   cuco_empresaid = " + empresaID +
                    "   AND cuco_constante1 = '" + constante1 + "'" +
                    "   AND cuco_constante2 = '" + constante2 + "'" +
                    "   AND cuco_letra = '" + letra + "'" +
                    " ORDER BY cuco_consecutivo DESC"

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function Recuperar_Empresa_SSC(ByVal IdEmpresaSaySicyContpaq As Integer)
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " select essc_empresaid, essc_sayid, essc_contribuyentesicyid, essc_razonsocial," +
            " essc_doctoventassicyid" +
            " from Framework.empresaSaySicyContpaq where essc_empresaid = " + IdEmpresaSaySicyContpaq.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function Recuperar_Id_Tipo_CuentaContabilidad_Sicy(ByVal IdTipoCuentaSay As Integer)
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += "select ticc_nombre, ticc_tipocuentacontabilidadSICYid " +
        " from Contabilidad.TiposCuentasContabilidad" +
        " where ticc_tipocuentacontabilidadid = " + IdTipoCuentaSay.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' FUNCION LA CUAL VALIDA QUE UNA CUENTA CONTABLE QUE SE PRETENDE REGISTRAR NO HAYA SIDO DADA DE ALTA ANTERIORMENTE, SÍ LA CUENTA YA
    ''' EXISTE DEVOLVERA UN VALOR DEL TIPO BOLEANO 'TRUE', DE LO CONTRARIO MANDARA UN VALOR FALSE INDICANDO QUE LA CUENTA NO EXISTE
    ''' </summary>
    ''' <param name="CuentaContable"> ENTIDAD DE LA CLASE CUENTACONTABLE CON LA INFORMACION DE LA CUENTA A VALIDAR</param>
    ''' <returns>VARIABLE DEL TIPO BOLEANA CON VALOR TRUE EN CASO DE QUE LA CUENTA BUSCADA EXISTA, Y VALOR FALSE EN CASO DE QUE LA CUENTA NO EXISTA</returns>
    ''' <remarks></remarks>
    Public Function Validar_CuentaContable_No_Existente(ByVal CuentaContable As Entidades.CuentaContable)
        Dim objOperaciones As New OperacionesProcedimientos
        ''Se cambia la consulta a SP Carolina Díaz 28/05/2021 12:30
        'Dim consulta As String = "select * from Contabilidad.CuentasContables " +
        '    " where cuco_constante1 = '" + CuentaContable.PConstante1 +
        '    "' and cuco_constante2 = '" + CuentaContable.PConstante2 + "'" +
        '    " and cuco_letra = '" + CuentaContable.PLetra +
        '    "' and cuco_consecutivo = '" + CuentaContable.PConsecutivo + "'" +
        '    " and  cuco_cuentacontablecontpaqid = " + CuentaContable.PIDCuentaContableContpaq.ToString +
        '    " and cuco_cuentacontabletipoid = " + CuentaContable.PIdTipoCuenta.ToString +
        '    " and cuco_status = 1 and cuco_empresaid =" + CuentaContable.PIdEmpresa.ToString

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@empresaId", CuentaContable.PIdEmpresa)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@constante1", CuentaContable.PConstante1)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@constante2", CuentaContable.PConstante2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@letra", CuentaContable.PLetra)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@consecutivo", CuentaContable.PConsecutivo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cuentacontpaqid", CuentaContable.PIDCuentaContableContpaq)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipocuenta", CuentaContable.PIdTipoCuenta)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cliente", CuentaContable.PIdCliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@proveedor", CuentaContable.PIdProveedor)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("Contabilidad.SP_CuentasContablesSAY_ValidaExisteCuenta", listaParametros)
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
    Public Function Alta_Edicion_CuentasContablesSay(ByVal AltaEdicion As Boolean, ByVal CuentaContable As Entidades.CuentaContable)
        Dim objOperaciones As New OperacionesProcedimientos
        Dim consulta As String = ""

        If AltaEdicion = True Then
            consulta = "INSERT INTO Contabilidad.CuentasContables" +
                    "       (cuco_constante1 ,cuco_constante2, cuco_letra, cuco_consecutivo, cuco_cuentacontablecontpaqid, cuco_cuentacontablesicyid, cuco_proveedorid, " +
                    "       cuco_cuentacontabletipoid, cuco_empresaid, cuco_clienteid, cuco_status, cuco_usuariocreo, cuco_fechacreacion, cuco_descripcion)" +
                    " VALUES" +
                    "       ('" + CuentaContable.PConstante1.ToString + "'" +
                    "       , '" + CuentaContable.PConstante2.ToString + "'" +
                    "       , '" + CuentaContable.PLetra + "'" +
                    "       , '" + CuentaContable.PConsecutivo + "'" +
                    "       , " + CuentaContable.PIDCuentaContableContpaq.ToString +
                    "       , " + CuentaContable.PIdCuentaContableSicy.ToString +
                    "       , " + CuentaContable.PIdProveedor.ToString +
                    "       , " + CuentaContable.PIdTipoCuenta.ToString +
                    "       , " + CuentaContable.PIdEmpresa.ToString +
                    "       , " + CuentaContable.PIdCliente.ToString +
                    "       , '" + CuentaContable.PStatus.ToString + "'" +
                    "       , " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                    "       , (SELECT GETDATE())" +
                    "       , '" + CuentaContable.PDescripcion + "')"
        Else

            consulta = " UPDATE Contabilidad.CuentasContables " +
                         " SET cuco_constante1 = '" + CuentaContable.PConstante1.ToString + "'" +
                         "      ,cuco_constante2 = '" + CuentaContable.PConstante2.ToString + "'" +
                         "      ,cuco_letra = '" + CuentaContable.PLetra + "'" +
                         "      ,cuco_consecutivo = '" + CuentaContable.PConsecutivo + "'" +
                         "      ,cuco_cuentacontablecontpaqid = " + CuentaContable.PIDCuentaContableContpaq.ToString +
                         "      ,cuco_cuentacontablesicyid = " + CuentaContable.PIdCuentaContableSicy.ToString +
                         "      ,cuco_proveedorid = " + CuentaContable.PIdProveedor.ToString +
                         "      ,cuco_cuentacontabletipoid = " + CuentaContable.PIdTipoCuenta.ToString +
                         "      ,cuco_empresaid = " + CuentaContable.PIdEmpresa.ToString +
                         "      ,cuco_clienteid = " + CuentaContable.PIdCliente.ToString +
                         "      ,cuco_status = '" + CuentaContable.PStatus.ToString + "'" +
                         "      ,cuco_descripcion = '" + CuentaContable.PDescripcion + "'" +
                         "      ,cuco_usuariomodifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                         "      ,cuco_fechamodifico = (select getdate())" +
                         " WHERE cuco_cuentacontableid = " + CuentaContable.PIdCuentaContable.ToString
        End If

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function EmpresasRegistrarCuentas() As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_EmpresasRegistrarCuenta]", listaParametros)

    End Function

    Public Function tiopoCuenta() As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_RegistrarCuentas_TipoDeCuenta]", listaParametros)

    End Function

    Public Function RegistrarCuentasAlmacen() As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_RegistrarCuentasAlmacen]", listaParametros)

    End Function

    Public Function ConsultaRegistrarCuentas(ByVal Empresa As String, ByVal TipoCta As String, Mostrar As Integer, Estatus As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro.ParameterName = "@Empresa"
        parametro.Value = Empresa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoCuenta"
        parametro.Value = TipoCta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Mostrar"
        parametro.Value = Mostrar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = Estatus
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_ConsultasRegistrarCuentas]", listaParametros)

    End Function

    Public Function ConsultaRegistrarCuentasMateriales(ByVal Empresa As String, ByVal TipoCta As String, Mostrar As Integer, Estatus As Integer, ByVal Almacen As Integer) As DataTable
        ', ByVal FechaDel As Date, ByVal FechaAl As Date
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro.ParameterName = "@Empresa"
        parametro.Value = Empresa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoCuenta"
        parametro.Value = TipoCta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Mostrar"
        parametro.Value = Mostrar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = Estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Almacen"
        parametro.Value = Almacen
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@FechaDel"
        'parametro.Value = FechaDel
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@FrchaAl"
        'parametro.Value = FechaAl
        'listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_ConsultasRegistrarCuentas_Materiales]", listaParametros)

    End Function

    Public Function ConsultaEmpresaSICY(ByVal IdEmpresa As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdEmpresa"
        parametro.Value = IdEmpresa
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_RegistrarCuentas_ConsultaEmpresaSICY]", listaParametros)

    End Function

    Public Function ConsultarEmpresaCP(ByVal IdEmpresaCP As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdEmpresaCP"
        parametro.Value = IdEmpresaCP
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_RegistrarCuentas_ConsultaEmpresaCompac]", listaParametros)

    End Function

    Public Function ConsultaCuentasporEmpresa(ByVal AliasBDD As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@AliasBDD"
        parametro.Value = AliasBDD
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_RegistrarCuentas_ConsultaCuentasEmpresa]", listaParametros)

    End Function

    Public Function InsertarRegistrarCuentas(ByVal IdEmpresaSICY As Integer, ByVal IdEmpresaContpaq As Integer, ByVal IdTipoCta As Integer, ByVal ClaveSicy As Integer,
                                             ByVal ClaveCuenta As Integer, ByVal Cuenta As String, ByVal Descripcion As String, ByVal IdSegmentoN As String, ByVal Estatus As String,
                                             ByVal UsuarioAlta As String, ByVal UsuarioActualizo As String, ByVal Concurrency As Integer, ByVal IdAlmacen As Integer,
                                             ByVal Accion As Integer, ByVal idTabla As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdEmpresaSICY"
        parametro.Value = IdEmpresaSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdEmpresaContpac"
        parametro.Value = IdEmpresaContpaq
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdTipoCta"
        parametro.Value = IdTipoCta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClaveSicy"
        parametro.Value = ClaveSicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClaveCuenta"
        parametro.Value = ClaveCuenta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cuenta"
        parametro.Value = Cuenta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descripcion"
        parametro.Value = Descripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdSegmentoNegocio"
        parametro.Value = IdSegmentoN
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = Estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioAlta"
        parametro.Value = UsuarioAlta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioActualizo"
        parametro.Value = UsuarioActualizo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Concurrency"
        parametro.Value = Concurrency
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdAlmacen"
        parametro.Value = IdAlmacen
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Accion"
        parametro.Value = Accion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IDtabla"
        parametro.Value = idTabla
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_InsertaRegistrarCuentas]", listaParametros)

    End Function

End Class
