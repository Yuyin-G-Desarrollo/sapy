Imports Persistencia
Imports System.Data.SqlClient

Public Class PolizaDA


    Public Function Combo_lista_Bases_Contpaq() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " SELECT name FROM [192.168.20.227\COMPAC].[master].[dbo].[sysdatabases] where name like 'ct%' AND name NOT IN (SELECT essc_empresacontpaq FROM Framework.empresaSaySicyContpaq) ORDER BY name"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Combo_lista_Contribuyentes() As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta += " SELECT IDRazSoc, RazonSocial FROM Contribuyentes ORDER BY RazonSocial"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Combo_lista_Documentos_SICY() As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        'consulta += " SELECT IdDocumento, RazonSocial FROM DoctosVentas WHERE IdDocumento NOT IN (SELECT essc_doctoventassicyid FROM [192.168.7.16].[YuyinERP].[Framework].[empresaSaySicyContpaq]) ORDER BY RazonSocial"
        consulta += " SELECT IdDocumento, RazonSocial FROM DoctosVentas WHERE IdDocumento NOT IN (SELECT essc_doctoventassicyid FROM [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].[Framework].[empresaSaySicyContpaq]) ORDER BY RazonSocial"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Combo_lista_Cuentas_Bancarias_SICY(ByVal Modo_Edicion As Boolean, ByVal IdCuenta As Integer) As DataTable
        Dim operacionesSay As New OperacionesProcedimientos
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        If Modo_Edicion = False Then
            If operaciones.Servidor <> operacionesSay.Servidor Then
                consulta = <Consulta> SELECT IdCuenta, CAST(Cuenta + ' - ' + Nombre AS VARCHAR(MAX)) AS Cuenta 
                                    FROM CuentasBancarias
                                    WHERE IdCuenta NOT IN ( SELECT cuba_cuentasicyid 
                                                            FROM [<%= operacionesSay.Servidor %>].[<%= operacionesSay.NombreDB %>].[Bancos].[CuentasBancarias] 
                                                            WHERE cuba_cuentasicyid IS NOT NULL 
                                    ) ORDER BY Nombre</Consulta>.Value
            Else
                consulta = <Consulta> SELECT IdCuenta, CAST(Cuenta + ' - ' + Nombre AS VARCHAR(MAX)) AS Cuenta 
                                    FROM CuentasBancarias 
                                    WHERE IdCuenta NOT IN ( SELECT cuba_cuentasicyid 
                                                            FROM [<%= operacionesSay.NombreDB %>].[Bancos].[CuentasBancarias]
                                                            WHERE cuba_cuentasicyid IS NOT NULL  
                                    ) ORDER BY Nombre</Consulta>.Value
            End If

        Else
            If operaciones.Servidor <> operacionesSay.Servidor Then
                consulta = <Consulta> SELECT IdCuenta, CAST(Cuenta + ' - ' + Nombre AS VARCHAR(MAX)) AS Cuenta 
                                    FROM CuentasBancarias
                                    WHERE IdCuenta NOT IN ( SELECT DISTINCT cuba_cuentasicyid 
                                                            FROM [<%= operacionesSay.Servidor %>].[<%= operacionesSay.NombreDB %>].[Bancos].[CuentasBancarias] 
                                                            WHERE cuba_cuentasicyid IS NOT NULL ) 
                                    OR idcuenta = <%= IdCuenta.ToString %> 
                                    ORDER BY Nombre</Consulta>.Value
            Else
                consulta = <Consulta> SELECT IdCuenta, CAST(Cuenta + ' - ' + Nombre AS VARCHAR(MAX)) AS Cuenta 
                                    FROM CuentasBancarias 
                                    WHERE IdCuenta NOT IN ( SELECT DISTINCT cuba_cuentasicyid 
                                                            FROM [<%= operacionesSay.NombreDB %>].[Bancos].[CuentasBancarias] 
                                                            WHERE cuba_cuentasicyid IS NOT NULL ) 
                                    OR idcuenta = <%= IdCuenta.ToString %> 
                                    ORDER BY Nombre</Consulta>.Value
            End If
        End If


        Return operaciones.EjecutaConsulta(consulta)

    End Function


    ''' <summary>
    ''' CONSULTA TODA LA INFORMACION DE LA TABLA EMPRESASAYSICYCONTPAQ (SAY)
    ''' </summary>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Combo_lista_Empresas_Say_Sicy_Contpaq() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " select  essc_empresaid , cast(essc_sayid as varchar(3))+' '+cast(essc_razonsocial  AS VARCHAR (250)) AS 'essc_razonsocial'" +
                    " from Framework.empresaSaySicyContpaq order by essc_sayid ASC"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Combo_lista_Bancos() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " SELECT banc_bancoid, banc_nombre FROM Framework.Bancos ORDER BY banc_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Combo_lista_Cuentas_Cheques_Contpaq(empresaID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += "  " +
                    " DECLARE @servidor AS VARCHAR(MAX) SET @servidor = LTRIM(RTRIM(CAST(((SELECT essc_servidor FROM Framework.empresaSaySicyContpaq WHERE essc_empresaid = " + empresaID.ToString + ")) AS VARCHAR(MAX))))" +
                    " DECLARE @base_datos AS VARCHAR(MAX) SET @base_datos = LTRIM(RTRIM(CAST(((SELECT essc_empresacontpaq FROM Framework.empresaSaySicyContpaq WHERE essc_empresaid = " + empresaID.ToString + ")) AS VARCHAR(MAX))))" +
                    " " +
                    " DECLARE @query AS VARCHAR(MAX)" +
                    " 	SET @query ='				" +
                    " 					SELECT " +
                    " 							Id," +
                    " 							Nombre" +
                    " 					FROM [' + @servidor + '].[' + @base_datos + '].[dbo].[CuentasCheques]'" +
                    " " +
                    " EXEC (@query)"

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    ''' <summary>
    ''' CONSULTA TODA LA INFORMACIÓN QUE ESTE ACTIVA DE LA TABLA TIPOSCUENTACONTABILIDAD 
    ''' </summary>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function Combo_lista_TipoCuentaContable() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " SELECT * FROM Contabilidad.TiposCuentasContabilidad WHERE ticc_activo = 1 ORDER BY ticc_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Combo_lista_TipoPoliza() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " SELECT * FROM Contabilidad.PolizasTipos WHERE poti_activo = 1 ORDER BY poti_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Combo_lista_Proveedor() As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " SELECT prov_proveedorid, prov_nombregenerico FROM Proveedor.Proveedor WHERE prov_activo = 1 ORDER BY prov_nombregenerico"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListadoParametroBusqueda(tipo_busqueda As Integer, id_parametros As String) As DataTable

        Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim listaparametros As New List(Of SqlParameter)

        If tipo_busqueda = 1 Then
            Dim id_parametros_split As String() = Nothing
            If Not IsNothing(id_parametros) Then
                id_parametros_split = id_parametros.ToString.Split(",")
            End If
            consulta += "  " +
                        " SELECT" +
                        " 	prov_proveedorid AS 'Parámetro'," +
                        " 	CAST(0 AS bit) AS ' '," +
                        " 	prov_nombregenerico AS 'Proveedor'," +
                        "   prov_sicyid" +
                        " FROM Proveedor.Proveedor" +
                        " WHERE prov_activo = 1 "
            If Not IsNothing(id_parametros) AndAlso id_parametros.Trim <> "," Then
                consulta += " " +
                        " AND prov_proveedorid NOT IN (" +
                        "                               SELECT cuco_proveedorid FROM Contabilidad.CuentasContables " +
                        "                               WHERE cuco_cuentacontabletipoid = " + id_parametros_split(0) + " And cuco_empresaid = " + id_parametros_split(1) + "" +
                        "                             )"
            End If

            consulta += " ORDER BY prov_nombregenerico "
        ElseIf tipo_busqueda = 2 Then
            Dim parametro As SqlParameter = Nothing

            If id_parametros.Contains(",") Then
                Dim id_parametros_split As String() = Nothing
                id_parametros_split = id_parametros.ToString.Split(",")

                parametro = New SqlParameter("@empresaIdSay", id_parametros_split(0))
                listaparametros.Add(parametro)

                parametro = New SqlParameter("@clienteId", id_parametros_split(1))
                listaparametros.Add(parametro)
            Else
                parametro = New SqlParameter("@empresaIdSay", id_parametros)
                listaparametros.Add(parametro)
            End If





            'Dim id_parametros_split As String() = Nothing
            'If Not IsNothing(id_parametros) Then
            '    id_parametros_split = id_parametros.ToString.Split(",")
            'End If
            'consulta += "  " +
            '            " SELECT" +
            '            " 	clie_clienteid AS 'Parámetro'," +
            '            " 	CAST(0 AS bit) AS ' '," +
            '            " 	clie_nombregenerico AS 'Cliente'," +
            '            "   clie_idsicy " +
            '            " FROM Cliente.Cliente" +
            '            " WHERE clie_activo = 1 "
            'If Not IsNothing(id_parametros) Then
            '    consulta += " " +
            '            " AND clie_nombregenerico NOT IN (" +
            '            "                                   SELECT clie_clienteid FROM Contabilidad.CuentasContables " +
            '            "                                   WHERE cuco_cuentacontabletipoid = " + id_parametros_split(0) + " And cuco_empresaid = " + id_parametros_split(1) + "" +
            '            "                                )"
            'End If

            'consulta += " ORDER BY clie_nombregenerico "
        ElseIf tipo_busqueda = 3 Then
                Dim id_parametros_split As String() = Nothing
                If Not IsNothing(id_parametros) Then
                    id_parametros_split = id_parametros.ToString.Split(",")
                End If

                If operaciones.Servidor = operaciones_sicy.Servidor Then
                    consulta += " " +
                       " SELECT IdCuenta,  CAST(0 AS bit) AS ' ', ltrim(rtrim(REPLACE(cuenta,'-',''))) as 'Cuenta'," +
                       " ltrim(rtrim(Descripcion)) as 'Descripción' FROM CuentasContabilidad " +
                       " WHERE idtipo = (select ticc_tipocuentacontabilidadSICYid from [" + operaciones.NombreDB + "].Contabilidad.TiposCuentasContabilidad" +
                       " where ticc_tipocuentacontabilidadid = " + id_parametros_split(0) + ") AND IdEmpresaSicy = " + id_parametros_split(1) +
                       " AND IdCuenta NOT IN ("
                    consulta += "                       SELECT " +
                        "                       cuco_cuentacontableid " +
                        "                       FROM [" + operaciones.NombreDB + "].[Contabilidad].[CuentasContables]" +
                        "                      )"
                Else
                    consulta += " " +
                       " SELECT IdCuenta,  CAST(0 AS bit) AS ' ', ltrim(rtrim(REPLACE(cuenta,'-',''))) as 'Cuenta'," +
                       " ltrim(rtrim(Descripcion)) as 'Descripción' FROM CuentasContabilidad " +
                       " WHERE idtipo = (select ticc_tipocuentacontabilidadSICYid from [" + operaciones.Servidor + "].[" + operaciones.NombreDB + "].Contabilidad.TiposCuentasContabilidad" +
                       " where ticc_tipocuentacontabilidadid = " + id_parametros_split(0) + ") AND IdEmpresaSicy = " + id_parametros_split(1) +
                       " AND IdCuenta NOT IN ("
                    consulta += "                       SELECT " +
                        "                       cuco_cuentacontableid " +
                        "                       FROM [" + operaciones.Servidor + "].[" + operaciones.NombreDB + "].[Contabilidad].[CuentasContables]" +
                        "                      )"
                End If
                consulta += " order by Descripción"
            ElseIf tipo_busqueda = 4 Then
                Dim id_parametros_split As String() = Nothing
                If Not IsNothing(id_parametros) Then
                    id_parametros_split = id_parametros.ToString.Split(",")
                End If
                consulta += " " +
                        " DECLARE @servidor AS VARCHAR(MAX) SET @servidor = LTRIM(RTRIM(CAST(((SELECT essc_servidor FROM Framework.empresaSaySicyContpaq " +
                        " WHERE essc_empresaid = " + id_parametros_split(1) + ")) AS VARCHAR(MAX))))" +
                        " DECLARE @base_datos AS VARCHAR(MAX) SET @base_datos = LTRIM(RTRIM(CAST(((SELECT essc_empresacontpaq FROM Framework.empresaSaySicyContpaq" +
                        " WHERE essc_empresaid = " + id_parametros_split(1) + ")) AS VARCHAR(MAX))))" +
                        " " +
                        " DECLARE @query AS VARCHAR(MAX)" +
                        " 	SET @query ='				" +
                        " 					SELECT " +
                        " 							Id AS ''Parámetro''," +
                        " 							CAST(0 AS bit) AS '' ''," +
                        " 							Codigo AS ''Código''," +
                        " 							Nombre AS ''Nombre de Cuenta''" +
                        " 					FROM [' + @servidor + '].[' + @base_datos + '].[dbo].[Cuentas]" +
                        " 					WHERE Codigo NOT LIKE ''103%'' AND Codigo NOT LIKE ''200%'' AND Codigo NOT LIKE ''201%'' AND Codigo NOT LIKE ''[_]%''" +
                        " 					ORDER BY [Nombre de Cuenta] '" +
                        " " +
                        " EXEC (@query)"
            ElseIf tipo_busqueda = 5 Then
                Dim id_parametros_split As String() = Nothing
                If Not IsNothing(id_parametros) Then
                    id_parametros_split = id_parametros.ToString.Split(",")
                End If
                consulta += " " +
                        " SELECT" +
                        "   cuco_cuentacontableid AS 'Parámetro'," +
                        " 	CAST(0 AS bit) AS ' '," +
                        " 	(CAST(cuco_constante1 + cuco_constante2+cuco_letra+cuco_consecutivo AS VARCHAR(MAX) ) )AS 'Número de Cuenta', cuco_descripcion AS 'Descripción'" +
                        " FROM Contabilidad.CuentasContables" +
                        " WHERE cuco_status = 1 And cuco_empresaid = " + id_parametros_split(0) +
                        " ORDER BY [Número de Cuenta]"
            ElseIf tipo_busqueda = 6 Then
                Dim id_parametros_split As String() = Nothing
                If Not IsNothing(id_parametros) Then
                    id_parametros_split = id_parametros.ToString.Split(",")
                End If
                consulta += " " +
                        " SELECT" +
                        " 	cuba_cuentaid AS 'Parámetro'," +
                        "   CAST(0 AS bit) AS ' '," +
                        "   cuba_numero AS 'Número de Cuenta'," +
                        "   cuba_cuentahabiente AS 'Cuentahabiente'" +
                        " FROM Bancos.CuentasBancarias" +
                        " WHERE cuba_empresaid = " + id_parametros_split(0) +
                        " ORDER BY [Número de Cuenta]"
            ElseIf tipo_busqueda = 7 Then
                Dim id_parametros_split As String() = Nothing
                If Not IsNothing(id_parametros) Then
                    id_parametros_split = id_parametros.ToString.Split(",")
                End If
                consulta += " " +
                        " DECLARE @servidor AS VARCHAR(MAX) SET @servidor = LTRIM(RTRIM(CAST(((SELECT essc_servidor FROM Framework.empresaSaySicyContpaq WHERE essc_empresaid = " + id_parametros_split(0) + ")) AS VARCHAR(MAX))))" +
                        " DECLARE @base_datos AS VARCHAR(MAX) SET @base_datos = LTRIM(RTRIM(CAST(((SELECT essc_empresacontpaq FROM Framework.empresaSaySicyContpaq WHERE essc_empresaid = " + id_parametros_split(0) + ")) AS VARCHAR(MAX))))" +
                        " " +
                        " DECLARE @query AS VARCHAR(MAX)" +
                        " 	SET @query ='				" +
                        " 					SELECT " +
                        " 							Id AS ''Parámetro''," +
                        " 							CAST(0 AS bit) AS '' ''," +
                        " 							Nombre AS ''Nombre de Banco''" +
                        " 					FROM [' + @servidor + '].[' + @base_datos + '].[dbo].[Bancos]" +
                        " 					ORDER BY [Nombre de Banco] '" +
                        " " +
                        " EXEC (@query)"
            ElseIf tipo_busqueda = 8 Then
                Dim id_parametros_split As String() = Nothing
                If Not IsNothing(id_parametros) Then
                    id_parametros_split = id_parametros.ToString.Split(",")
                End If
                consulta += " " +
                        " DECLARE @servidor AS VARCHAR(MAX) SET @servidor = LTRIM(RTRIM(CAST(((SELECT essc_servidor " +
                        "           FROM Framework.empresaSaySicyContpaq WHERE essc_empresaid = " + id_parametros_split(0).ToString + ")) AS VARCHAR(MAX))))" +
                        " DECLARE @base_datos AS VARCHAR(MAX) SET @base_datos = LTRIM(RTRIM(CAST(((SELECT essc_empresacontpaq " +
                        "                   FROM Framework.empresaSaySicyContpaq WHERE essc_empresaid = " + id_parametros_split(0).ToString + ")) AS VARCHAR(MAX))))" +
                        " DECLARE @query AS VARCHAR(MAX)" +
                        " SET @query =' SELECT " +
                        " 			Id AS ''Parámetro''," +
                        "             CAST(0 AS bit) AS '' ''," +
                        " 			Codigo as ''Código de Cuenta''," +
                        "             Nombre AS ''Nombre de Cuenta''" +
                        "             FROM [' + @servidor + '].[' + @base_datos + '].[dbo].[Cuentas]" +
                        "           ORDER BY [Nombre de Cuenta] '" +
                        " EXEC (@query)"
            ElseIf tipo_busqueda = 9 Then
                consulta = " select IDRazSoc as 'Parámetro', CAST(0 AS bit) AS ' ', RazonSocial as 'Razón Social', rfc as 'RFC'  " +
                        " from Contribuyentes where estatus = 'A' order by RazonSocial"
            ElseIf tipo_busqueda = 10 Then
                consulta = " select IdDocumento as 'Parámetro', CAST(0 AS bit) AS ' ', RazonSocial as 'Razón Social', RFC as 'RFC'" +
                        " from DoctosVentas where Estatus = 'A' order by RazonSocial"
            ElseIf tipo_busqueda = 11 Then
                Dim id_parametros_split As String() = Nothing
            If Not IsNothing(id_parametros) Then
                id_parametros_split = id_parametros.ToString.Split(",")
            End If
            consulta += " " +
                        " DECLARE @servidor AS VARCHAR(MAX) SET @servidor = LTRIM(RTRIM(CAST(((SELECT essc_servidor FROM Framework.empresaSaySicyContpaq " +
                        " WHERE essc_empresaid = " + id_parametros_split(0) + ")) AS VARCHAR(MAX))))" +
                        " DECLARE @base_datos AS VARCHAR(MAX) SET @base_datos = LTRIM(RTRIM(CAST(((SELECT essc_empresacontpaq FROM Framework.empresaSaySicyContpaq" +
                        " WHERE essc_empresaid = " + id_parametros_split(0) + ")) AS VARCHAR(MAX))))" +
                        " " +
                        " DECLARE @query AS VARCHAR(MAX)" +
                        " 	SET @query ='				" +
                        " 					SELECT " +
                        " 							cast(Codigo as int)  AS ''Parámetro''," +
                        "							CAST(0 AS bit) AS '' ''," +
                        "							Codigo AS ''Código'', Nombre as ''Tipo'' " +
                        " 					FROM [' + @servidor + '].[' + @base_datos + '].[dbo].[TiposPolizas]" +
                        " 					ORDER BY Tipo '" +
                        " " +
                        " EXEC (@query)"
        End If

        If tipo_busqueda = 9 Or tipo_busqueda = 10 Or tipo_busqueda = 3 Then
            Return operaciones_sicy.EjecutaConsulta(consulta)
        ElseIf tipo_busqueda = 2 Then
            Return operaciones.EjecutarConsultaSP("[Contabilidad].[SP_Cuentacontable_ConsultarCuentas]", listaparametros)
        Else
            Return operaciones.EjecutaConsulta(consulta)
        End If


    End Function

    Public Function Existe_Tabla_Contpaq(empresaID As Integer, nombre_tabla As String) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@empresaID AS INT
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@empresaID"
        parametro.Value = empresaID
        listaParametros.Add(parametro)

        ',@nombre_tabla AS VARCHAR(MAX)
        parametro = New SqlParameter
        parametro.ParameterName = "@nombre_tabla"
        parametro.Value = nombre_tabla
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_Verifica_Si_Existe_Tabla_Contpaq", listaParametros)

    End Function

    Public Function lista_polizas_generadas(empresaID As Integer, tipoPolizaID As Integer, fechaInicio As DateTime, fechaTermino As DateTime) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                    " SELECT" +
                    " 	poli_polizaid," +
                    " 	poli_anio Ejercicio," +
                    " 	poli_mes Periodo," +
                    " 	poli_fecha Fecha," +
                    " 	CAST(poli_foliomensual AS INTEGER)[# Póliza]," +
                    " 	poli_concepto [Concepto]," +
                    " 	poli_cargos [Total Cargos]," +
                    " 	poli_abonos [Total Abonos]" +
                    " FROM Contabilidad.Polizas" +
                    " WHERE poli_tipoid = " + tipoPolizaID.ToString +
                    " AND poli_fecha BETWEEN CAST('" + fechaInicio.ToShortDateString + "' AS DATETIME) AND CAST('" + fechaTermino.ToShortDateString + "' AS DATETIME)" +
                    " AND poli_empresaid = " + empresaID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function lista_movimientos_poliza(polizaID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta += " " +
                    " SELECT" +
                    " 	pomo_numeromovimiento [No.]," +
                    " 	b.cuco_constante1 + b.cuco_constante1 + b.cuco_constante2 Cuenta," +
                    " 	ISNULL(UPPER(cuco_descripcion), '') Nombre," +
                    " 	a.pomo_cargos Cargo," +
                    " 	a.pomo_abonos Abono," +
                    " 	a.pomo_referencia Referencia," +
                    " 	ISNULL(UPPER(pomo_concepto), '') Concepto," +
                    "   a.pomo_rutaxml," +
                    "   a.pomo_rutapdf" +
                    " FROM Contabilidad.PolizaMovimientos AS a" +
                    " JOIN Contabilidad.CuentasContables b ON a.pomo_cuentaid = b.cuco_cuentacontableid" +
                    " WHERE pomo_polizaid = " + polizaID.ToString +
                    " ORDER BY pomo_numeromovimiento ASC"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Eliminar_Poliza_Solo_SAY(polizaID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@polizaID AS INT
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@polizaID"
        parametro.Value = polizaID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Contabilidad.SP_Eliminar_Poliza_SAY", listaParametros)

    End Function



    Public Function consultaPruebaDemo() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT codr_nombre as NOMBRE, codr_apellidopaterno 'A. PATERNO', codr_apellidomaterno 'A.MATERNO', codr_curp CURP, codr_rfc RFC, codr_telefonocelular CELULAR from Nomina.Colaborador"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class
