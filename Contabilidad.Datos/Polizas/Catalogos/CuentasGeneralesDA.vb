Imports Persistencia
Imports System.Data.SqlClient

Public Class CuentasGeneralesDA



    ''' <summary>
    ''' CONSULTA LA LISTA DE LAS CUENTAS GENERALES EXISTENTES EN LA BASE DE DATOS DEACUERDO A LOS FILTROS SELECCIONADOS POR EL USUARIO
    ''' </summary>
    ''' <param name="TipoPolizaID">ID DEL TIPO DE POLIZA QUE SE BUSCARAN, EN CASO DE QUE EL VALOR SEA = 0 INDICA QUE NO SE USARA ESTA CONDICION EN LA BUSQUEDA</param>
    ''' <param name="TipoDeCUentaID">ID DEL TIPO DE CUENTA QUE SE BUSCARAM EN CASO DE QUE EL VALOR SEA = 0 INDICA QUE NO SE USARA ESTA CONDICION EN LA CONSULTA</param>
    ''' <param name="EmpresaSSCID">ID DE LA EMPRESA EN LA TABLA EMPRESA SAY SICY CONTPAQ, EN CASO DE QUE EL VALOR SEA = O INDICA QUE NO SE USARA ESTA CONDICION EN LA CONSULTA</param>
    ''' <param name="Cuenta">CADENA CON EL NUMERO DE CUENTA QUE SE BUSCARA, EN CASO DE QUE LA CADENA SEA = "" INDICA QUE NO SE USARA ESTA CONDICION EN LA CONSULTA</param>
    ''' <param name="CUentaExacta_O_Aproximada">VARIABLE DEL TIPO BOOLEAN QUE INDICA SI LA CUENTA QUE SE BUSCARA DEBERA SER EXACTA A LA VARIABLE "CUENTA" ESTO EN CASO DE QUE 
    ''' SU VALOR SEA POSITIVO, E INDICA QUE LA CUENTA QUE SE BUSCARA SERA PARECIDA A LA VARIABLE CUENTA ESTO EN CASO DE QUE EL VALOR SEA NEGATIVO</param>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Consulta_lista_Cuentas_Generales(ByVal TipoPolizaID As Integer, ByVal TipoDeCUentaID As Integer, ByVal EmpresaSSCID As Integer, ByVal Cuenta As String,
                                                     ByVal CUentaExacta_O_Aproximada As Boolean) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                    " SELECT cgen_cuentageneralid AS 'ID', essc_razonsocial aS 'Razón Social', cgen_empresaid as 'Empresa_ID', cgen_cuentacontpaqid as 'CuentaContpaq_Id', cgen_cuentasayid as 'CuentaSay_ID', " +
                    "   cgen_nombre AS 'Nombre de Cuenta',  cgen_cuenta as 'No. Cuenta', cuco_descripcion as 'Cuenta Contable', " +
                    "   poti_nombre as 'Tipo de Poliza', cuba_numero as 'Cuenta Bancaria', cgen_tipopolizaid as 'TipoPoliza_ID'," +
                    "   cgen_clave as 'Clave', cgen_cuentabancariaid as 'CuentaBancaria_Id', cgen_tipopolizacontpaqid as 'TipoPolizaContpaq_Id' " +
                    " FROM Contabilidad.CuentasContablesGenerales" +
                    " join Contabilidad.CuentasContables on cuco_cuentacontableid = cgen_cuentasayid" +
                    " join Framework.empresaSaySicyContpaq on essc_empresaid = cgen_empresaid" +
                    " join Contabilidad.PolizasTipos on poti_polizatipoid = cgen_tipopolizaid" +
                    " left join Bancos.CuentasBancarias on cuba_cuentaid = cgen_cuentabancariaid"
        If EmpresaSSCID = 0 Then
            consulta += " WHERE cgen_empresaid <> 0"
        Else
            consulta += " WHERE cgen_empresaid = " + EmpresaSSCID.ToString
        End If

        If TipoPolizaID > 0 Then
            consulta += " AND cgen_tipopolizaid = " + TipoPolizaID.ToString
        End If
        If Cuenta <> "" Then
            If CUentaExacta_O_Aproximada Then
                consulta += " AND cgen_cuenta = '" + Cuenta + "'"
            Else
                consulta += " AND cgen_cuenta LIKE '%" + Cuenta + "%' "
            End If
        End If
        If TipoDeCUentaID <> 0 Then
            consulta += " AND cuco_cuentacontabletipoid = " + TipoDeCUentaID.ToString
        End If

        consulta += " order by cgen_nombre, cgen_clave"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function alta_edicion_cuenta_contable_general(bandera As Integer, CuentaContableGeneral As Entidades.CuentaContableGeneral)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@cuentageneralid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@cuentageneralid"
        parametro.Value = CuentaContableGeneral.cuentageneralid
        listaParametros.Add(parametro)

        ',@empresaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@empresaid"
        parametro.Value = CuentaContableGeneral.empresa.empresaid
        listaParametros.Add(parametro)

        ',@cuenta AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "@cuenta"
        parametro.Value = CuentaContableGeneral.cuenta
        listaParametros.Add(parametro)

        ',@cuentacontpaqid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@cuentacontpaqid"
        If Not CuentaContableGeneral.cuentacontpaq = 0 Then
            parametro.Value = CuentaContableGeneral.cuentacontpaq
        Else
            parametro.Value = DBNull.Value
        End If
        listaParametros.Add(parametro)

        ',@cuentasayid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@cuentasayid"
        If Not CuentaContableGeneral.cuentasay = 0 Then
            parametro.Value = CuentaContableGeneral.cuentasay
        Else
            parametro.Value = DBNull.Value
        End If
        listaParametros.Add(parametro)

        ',@nombre AS VARCHAR(250)
        parametro = New SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = CuentaContableGeneral.nombre
        listaParametros.Add(parametro)

        ',@tipopolizaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@tipopolizaid"
        parametro.Value = CuentaContableGeneral.tipopoliza.polizatipoid
        listaParametros.Add(parametro)

        ',@clave AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "@clave"
        If Not String.IsNullOrEmpty(CuentaContableGeneral.clave) Then
            parametro.Value = CuentaContableGeneral.clave
        Else
            parametro.Value = DBNull.Value
        End If
        listaParametros.Add(parametro)

        ',@cuentabancariaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@cuentabancariaid"
        If Not CuentaContableGeneral.cuentabancaria.cuentaid = 0 Then
            parametro.Value = CuentaContableGeneral.cuentabancaria.cuentaid
        Else
            parametro.Value = DBNull.Value
        End If
        listaParametros.Add(parametro)

        ',@usuario AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)


        ',@TipoPolizaContpac AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@TipoPolizaContpac"
        parametro.Value = CuentaContableGeneral.tipopolizaContpaq
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("Contabilidad.SP_Alta_Edicion_Cuenta_Contable_General", listaParametros)

    End Function

    Public Function Consulta_Datos_Cuentas_Generales(cuenta_general_id As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                    " SELECT " +
                    " 	cgen.cgen_cuentageneralid," +
                    " 	poti.poti_polizatipoid," +
                    " 	poti.poti_nombre," +
                    " 	essc.essc_empresaid," +
                    " 	essc.essc_razonsocial," +
                    " 	cgen.cgen_cuenta," +
                    " 	cgen.cgen_nombre," +
                    " 	cgen.cgen_clave," +
                    " 	cgen.cgen_cuentacontpaqid," +
                    " 	cuco.cuco_cuentacontableid," +
                    " 	CAST(cuco.cuco_constante1 + cuco.cuco_constante2 + cuco.cuco_letra + cuco.cuco_consecutivo AS VARCHAR(12)) AS cuco_cuentacontable," +
                    "   cuba.cuba_cuentaid," +
                    "   cuba.cuba_numero," +
                    "   cgen.cgen_tipopolizacontpaqid" +
                    " FROM Contabilidad.CuentasContablesGenerales AS cgen" +
                    " LEFT JOIN Contabilidad.CuentasContables AS cuco ON cuco.cuco_cuentacontableid = cgen.cgen_cuentasayid" +
                    " JOIN Contabilidad.PolizasTipos AS poti ON poti.poti_polizatipoid = cgen.cgen_tipopolizaid" +
                    " JOIN Framework.empresaSaySicyContpaq AS essc ON essc.essc_empresaid = cgen.cgen_empresaid" +
                    " LEFT JOIN Bancos.CuentasBancarias AS cuba ON cuba.cuba_cuentaid = cgen.cgen_cuentabancariaid" +
                    " WHERE cgen.cgen_cuentageneralid = " + cuenta_general_id.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
