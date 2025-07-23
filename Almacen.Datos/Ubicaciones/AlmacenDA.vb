
Imports System.Data
Imports System.Data.SqlClient
Imports Persistencia
Imports System.Collections.Generic

Public Class AlmacenDA
    Dim operaciones As New OperacionesProcedimientosSICY

    Public Function Consulta__Carritos_Pendientes(ByVal colaboradorid As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta += " SELECT carr_descripcion FROM Almacen.OcupacionCarrito "
        consulta += " JOIN  Almacen.Carrito ON occa_carritoid = carr_carritoid "
        consulta += " WHERE occa_colaboradorid = " + colaboradorid
        consulta += " AND (occa_totalatados - occa_atadosubicados) > 0"
        consulta += " ORDER BY carr_descripcion"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Carrito_Valido(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty
        consulta += " SELECT CAST(1 AS BIT) AS carrito_valido, carr_descripcion FROM Almacen.Carrito JOIN Almacen.OcupacionCarrito ON carr_carritoid = occa_carritoid WHERE occa_fechafinubicacion IS NULL AND carr_carritoid = '" + codigo + "'"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Estiba_Valido(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT CAST(1 AS BIT) AS esti_valida FROM Almacen.Estiba WHERE esti_estibaid = '" + codigo + "' AND esti_activo = 1 "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Ocupacion_SinUbicar_Carrito(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT (occa_totalatados - occa_atadosubicados) AS occa_sinubicar FROM Almacen.OcupacionCarrito WHERE occa_fechafinubicacion IS NULL AND occa_carritoid = " + codigo.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Ocupacion_Ubicados_Carrito(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT occa_atadosubicados FROM Almacen.OcupacionCarrito WHERE occa_fechafinubicacion IS NULL AND occa_carritoid = " + codigo.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Atado_Valido(ByVal codigo As String, ByVal carrito_valido As Boolean) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        If carrito_valido Then
            consulta += " SELECT CAST(1 AS BIT) AS ocaa_valido FROM Almacen.OcupacionCarritoAtados WHERE ocaa_codigoatado = '" + codigo + "' " ''AND ocaa_estibaid IS NULL "
        Else
            consulta += " SELECT CAST(1 AS BIT) AS ubat_valido FROM Almacen.UbicacionAtados WHERE ubat_codigoatado = '" + codigo + "' "
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Atado_En_Ubicacion_Pares(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        consulta += " SELECT CAST(1 AS BIT) AS ubpa_valido FROM Almacen.UbicacionPares WHERE ubpa_codigoatado = '" + codigo + "' "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Atado_tmpDocenasPares(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT DISTINCT ID_Docena FROM tmpDocenasPares where ID_Docena = '" + codigo + "'"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Par_Valido(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT CAST(1 AS BIT) AS ubpa_valido FROM Almacen.UbicacionPares WHERE ubpa_codigopar = '" + codigo + "' "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Par_tmpDocenasPares(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT CAST(1 AS BIT) AS tmpdocenas_valido FROM tmpDocenasPares WHERE Id_Par = '" + codigo + "'"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Ubicacion_Atado(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT CAST(1 AS BIT) AS ubat_valido FROM Almacen.UbicacionAtados WHERE ubat_codigoatado = '" + codigo + "' "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Apartado_Valido(ByVal apartado As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        consulta += " " +
                    " SELECT " +
                    " (SELECT COUNT(*) FROM Almacen.UbicacionPares WHERE ubpa_apartado = " + apartado + ") AS UbicacionPares," +
                    " (SELECT COUNT(*) FROM Almacen.ContenidoAtados WHERE coat_idapartado = " + apartado + ") AS ContenidoAtados," +
                    " (SELECT COUNT(*) FROM Almacen.ErroresStatusPar WHERE ersp_apartado = " + apartado + ") AS ErroresStatusPar"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Pares_en_Apartado(ByVal apartado As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        consulta += " " +
                    " SELECT" +
                    " 	ubpa_codigopar" +
                    " FROM Almacen.UbicacionPares" +
                    " WHERE ubpa_apartado = " + apartado + "" +
                    " UNION" +
                    " SELECT" +
                    " 	coat_codigopar" +
                    " FROM Almacen.ContenidoAtados" +
                    " WHERE coat_idapartado = " + apartado + "" +
                    " UNION" +
                    " SELECT" +
                    " 	ersp_codigopar" +
                    " FROM Almacen.ErroresStatusPar" +
                    " WHERE ersp_apartado = " + apartado + ""


        Return operaciones.EjecutaConsulta(consulta)

    End Function

    'Public Function Consulta_Atados_En_Ubicacion_Par(ByVal codigo As String) As DataTable

    '    Dim operaciones As New OperacionesProcedimientosSICY
    '    Dim consulta As String = " SELECT * FROM Almacen.UbicacionPares WHERE ubpa_codigoatado = '" + codigo + "' "

    '    Return operaciones.EjecutaConsulta(consulta)

    'End Function

    Public Function Consulta_Ubicacion_Par(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT CAST(1 AS BIT) AS ubpa_valido FROM Almacen.UbicacionPares WHERE ubpa_codigopar = '" + codigo + "' "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_par_contenido_atado(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT CAST(1 AS BIT) AS coat_valido FROM Almacen.ContenidoAtados WHERE coat_codigopar = '" + codigo + "' "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Par_Pertenece_Atado(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT ubpa_codigoatado FROM Almacen.UbicacionPares WHERE ubpa_codigopar = '" + codigo + "' "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Consulta_Bahia_Valido(ByVal codigo As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT CAST(1 AS BIT) AS bahi_valido FROM Almacen.Bahia WHERE bahi_bahiaid = '" + codigo + "' AND bahi_activo = 1 "

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function alta_ubicacion_atado(ByVal estibaid As String, ByVal codigoatado As String,
                                         ByVal pares As Integer, ByVal lote As Integer, ByVal nave As Integer,
                                         ByVal colaboradorid As Integer, ByVal carritoid As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ' @estibaid AS VARCHAR(15)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@estibaid"
        parametro.Value = estibaid
        listaParametros.Add(parametro)

        ',@codigoatado AS VARCHAR(30)
        parametro = New SqlParameter
        parametro.ParameterName = "@codigoatado"
        parametro.Value = codigoatado
        listaParametros.Add(parametro)

        '',@pares AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "@pares"
        'parametro.Value = pares
        'listaParametros.Add(parametro)

        '',@lote AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "@lote"
        'parametro.Value = lote
        'listaParametros.Add(parametro)

        '',@nave AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "@nave"
        'parametro.Value = nave
        'listaParametros.Add(parametro)

        ',@colaboradorcreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorcreoid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        ',@carritoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@carritoid"
        parametro.Value = carritoid
        listaParametros.Add(parametro)

        '@InsertaSistema AS bit
        parametro = New SqlParameter
        parametro.ParameterName = "@InsertaSistema"
        parametro.Value = False
        listaParametros.Add(parametro)

        ',@OrigenUbicacion AS varchar(1)
        parametro = New SqlParameter
        parametro.ParameterName = "@OrigenUbicacion"
        parametro.Value = "A"
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("Almacen.SP_Alta_Ubicacion_Atado", listaParametros)

    End Function

    Public Function editar_ubicacion_atado(ByVal estibaid As String, ByVal codigoatado As String, ByVal colaboradorid As Integer, ByVal carritoid As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@estibaid AS VARCHAR(15)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@estibaid"
        parametro.Value = estibaid
        listaParametros.Add(parametro)

        ',@codigoatado AS VARCHAR(30)
        parametro = New SqlParameter
        parametro.ParameterName = "@codigoatado"
        parametro.Value = codigoatado
        listaParametros.Add(parametro)

        ',@colaboradormodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradormodificaid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        ',@carritoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@carritoid"
        parametro.Value = carritoid
        listaParametros.Add(parametro)


        ',@OrigenUbicacion AS varchar(1)
        parametro = New SqlParameter
        parametro.ParameterName = "@OrigenUbicacion"
        parametro.Value = "A"
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("Almacen.SP_Editar_Ubicacion_Atado", listaParametros)

    End Function


    Public Function alta_ubicacion_par(ByVal estibaid As String, ByVal codigopar As String, ByVal lote As Integer, ByVal nave As Integer, ByVal colaboradorid As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@estibaid AS VARCHAR(15)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@estibaid"
        parametro.Value = estibaid
        listaParametros.Add(parametro)

        ',@codigopar AS VARCHAR(30)
        parametro = New SqlParameter
        parametro.ParameterName = "@codigopar"
        parametro.Value = codigopar
        listaParametros.Add(parametro)

        '',@lote AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "@lote"
        'parametro.Value = lote
        'listaParametros.Add(parametro)

        '',@nave AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "@nave"
        'parametro.Value = nave
        'listaParametros.Add(parametro)

        ',@colaboradorcreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorcreoid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        '@InsertaSistema AS bit
        parametro = New SqlParameter
        parametro.ParameterName = "@InsertaSistema"
        parametro.Value = False
        listaParametros.Add(parametro)

        ',@OrigenUbicacion AS varchar(1)
        parametro = New SqlParameter
        parametro.ParameterName = "@OrigenUbicacion"
        parametro.Value = "A"
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("Almacen.SP_Alta_Ubicacion_Par", listaParametros)

    End Function

    Public Function editar_ubicacion_par(ByVal estibaid As String, ByVal codigopar As String, ByVal colaboradorid As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@estibaid AS VARCHAR(15)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@estibaid"
        parametro.Value = estibaid
        listaParametros.Add(parametro)

        ',@codigopar AS VARCHAR(30)
        parametro = New SqlParameter
        parametro.ParameterName = "@codigopar"
        parametro.Value = codigopar
        listaParametros.Add(parametro)

        ',@colaboradormodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradormodificaid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        ',@OrigenUbicacion AS varchar(1)
        parametro = New SqlParameter
        parametro.ParameterName = "@OrigenUbicacion"
        parametro.Value = "A"
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("Almacen.SP_Editar_Ubicacion_Par", listaParametros)

    End Function

    Public Function Actualizar_FechaSalidaNave()
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Return operaciones.EjecutarSentenciaSP("Almacen.SP_Actualizar_FechaSalidaNave", listaParametros)
    End Function

    Public Function Actualizar_GeneraUbicaciones()
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Return operaciones.EjecutarSentenciaSP("Almacen.SP_GeneraUbicacionesFaltantes", listaParametros)
    End Function

    Public Function Actualizar_ConvertirParesEnAtado()
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Return operaciones.EjecutarSentenciaSP("Almacen.SP_Convertir_Pares_En_Atado", listaParametros)
    End Function

    Public Function InventarioDiarioSICY_Cierre(ByVal ComercializadoraID As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioCierra"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@comercializadoraID"
        parametro.Value = ComercializadoraID
        listaParametros.Add(parametro)



        Return operaciones.EjecutarSentenciaSP("Almacen.SP_InventarioDiarioSICY_Cierre_v2_Comercializadoras", listaParametros)

    End Function

    Public Function Consulta_Ocupacion_Plataforma_lista(colaboradorID As String, fechaInicio As String, fechaTermino As String) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                " 	CAST(0 AS BIT) AS '	'" +
                                " 	,occa_ocupacioncarritoid AS 'PLATAFORMA ID'" +
                                " 	,carr_descripcion AS 'PLATAFORMA'" +
                                " 	,occa_status 'STATUS ID'" +
                                " 	,(CASE WHEN occa_status = 19 THEN 'POR ASIGNAR' " +
                                " 		ELSE " +
                                " 			CASE WHEN occa_status = 23 THEN 'COMPLETO' " +
                                " 				ELSE " +
                                " 				CASE WHEN occa_status = 20 THEN 'PENDIENTE' END" +
                                "         END" +
                                " 	END ) AS 'STATUS'" +
                                "         FROM Almacen.OcupacionCarrito" +
                                " JOIN Almacen.Carrito ON carr_carritoid = occa_carritoid" +
                                " WHERE occa_ocupacioncarritoid IN (" +
                                "                           SELECT DISTINCT" +
                                "                           ocaa_ocupacioncarritoid" +
                                "                           FROM Almacen.OcupacionCarritoAtados" +
                                "                           WHERE ocaa_fechaubicacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'" +
                                "                           AND ocaa_colaboradorid = " + colaboradorID +
                                "                          )"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Plataforma_completa_lista_para_validacion(ocupacion_carritoid As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                "   ubat_codigoatado" +
                                " FROM Almacen.UbicacionAtados" +
                                " WHERE ubat_codigoatado IN " +
                                "   (" +
                                " 	    SELECT" +
                                "           ocaa_codigoatado" +
                                "       FROM Almacen.OcupacionCarritoAtados" +
                                "       WHERE ocaa_ocupacioncarritoid = " + ocupacion_carritoid.ToString +
                                "       AND ocaa_estibaid IS NULL" +
                                "   )" +
                                " AND ubat_estibaid IS NOT NULL"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Editar_Status_Plataforma(bandera As Integer, ocupacion_carritoid As Integer, status As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        '@bandera AS INT
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@ocupacion_carritoid AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "ocupacion_carritoid"
        parametro.Value = ocupacion_carritoid
        listaParametros.Add(parametro)

        ',@ocupacion_carritoid AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "status"
        parametro.Value = status
        listaParametros.Add(parametro)

        ',@usuario_valido AS INT
        parametro = New SqlParameter
        parametro.ParameterName = "usuario_valido"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("Almacen.SP_Editar_Status_Plataforma", listaParametros)

    End Function


    Public Function encabezado_Plataforma_Detalle_Plataforma(ocupacion_carritoID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT" +
                                " 	occa_status AS 'STATUS ID'" +
                                "  ,carr_descripcion AS 'DESCRIPCIÓN'" +
                                "  ,CAST(CU.codr_nombre + ' ' + CU.codr_apellidopaterno + ' ' + CU.codr_apellidomaterno AS varchar(200)) AS 'VALIDÓ'" +
                                "  ,occa_fechavalidacion AS 'VALIDACIÓN'" +
                                "  ,CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'OPERADOR'" +
                                "  ,occa_fechacreacion AS 'CARGA DE PLATAFORMA'" +
                                "  ,occa_fechainicioubicacion AS 'INICIO DESCARGA'" +
                                "  ,occa_fechafinubicacion AS 'FIN DESCARGA'" +
                                "  ,DATEDIFF(MINUTE,occa_fechainicioubicacion,occa_fechafinubicacion) AS 'MIN. DESCARGANDO'" +
                                " FROM Almacen.Carrito" +
                                " JOIN Almacen.OcupacionCarrito ON carr_carritoid = occa_carritoid" +
                                " LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].[Framework].[Usuarios] ON user_usuarioid = occa_usuariovalidoid" +
                                " LEFT JOIN Nomina.Colaborador AS CU ON CU.codr_colaboradorid = user_colaboradorid" +
                                " LEFT JOIN Nomina.Colaborador AS A ON A.codr_colaboradorid = occa_colaboradorid" +
                                " WHERE occa_ocupacioncarritoid = " + ocupacion_carritoID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Resumen_Plataforma_Atados_Cargados(ocupacion_carritoID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                " 	COUNT(ocaa_codigoatado) AS 'ATADOS CARGADOS'" +
                                "  ,SUM(ocaa_paresporatado) AS 'PARES CARGADOS'" +
                                " FROM Almacen.OcupacionCarrito" +
                                " JOIN Almacen.OcupacionCarritoAtados ON ocaa_ocupacioncarritoid = occa_ocupacioncarritoid" +
                                " WHERE occa_ocupacioncarritoid = " + ocupacion_carritoID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Resumen_Plataforma_Atados_Ubicados(ocupacion_carritoID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                " 	COUNT(ocaa_codigoatado) AS 'ATADOS DESCARGADOS'" +
                                "  ,SUM(ocaa_paresporatado) AS 'PARES DESCARGADOS'" +
                                " FROM Almacen.OcupacionCarrito" +
                                " JOIN Almacen.OcupacionCarritoAtados ON ocaa_ocupacioncarritoid = occa_ocupacioncarritoid" +
                                " JOIN Almacen.UbicacionAtados ON ubat_codigoatado = ocaa_codigoatado" +
                                " WHERE ocaa_estibaid IS NOT NULL" +
                                " AND (" +
                                " 	    ubat_estibaid IS NOT NULL" +
                                "	  )" +
                                " AND occa_ocupacioncarritoid = " + ocupacion_carritoID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Resumen_Plataforma_Atados_Pendientes(ocupacion_carritoID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                " 	COUNT(DISTINCT coat_codigoatado) AS 'ATADOS PENDIENTES'" +
                                "  ,COUNT(*) AS 'PARES PENDIENTES'" +
                                " FROM Almacen.OcupacionCarrito" +
                                " JOIN Almacen.OcupacionCarritoAtados ON ocaa_ocupacioncarritoid = occa_ocupacioncarritoid" +
                                " JOIN Almacen.ContenidoAtados ON coat_codigoatado = ocaa_codigoatado" +
                                " JOIN Almacen.UbicacionAtados ON ubat_codigoatado = ocaa_codigoatado" +
                                " WHERE ocaa_estibaid IS NULL" +
                                " AND (" +
                                " 	    coat_estibaid IS NULL OR" +
                                " 	    ubat_estibaid IS NULL" +
                                "	  )" +
                                " AND occa_ocupacioncarritoid = " + ocupacion_carritoID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Resumen_Plataforma_Atados_Ubicados_Sin_Plataforma(ocupacion_carritoID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                " 	COUNT(DISTINCT coat_codigoatado) AS 'ATADOS SIN ESTIBA EN OCUPACION'" +
                                "  ,COUNT(*) AS 'PARES SIN ESTIBA EN OCUPACION'" +
                                " FROM Almacen.OcupacionCarrito" +
                                " JOIN Almacen.OcupacionCarritoAtados ON ocaa_ocupacioncarritoid = occa_ocupacioncarritoid" +
                                " JOIN Almacen.ContenidoAtados ON coat_codigoatado = ocaa_codigoatado" +
                                " JOIN Almacen.UbicacionAtados ON ubat_codigoatado = ocaa_codigoatado" +
                                " WHERE ocaa_estibaid IS NULL" +
                                " AND (" +
                                " 	    coat_estibaid IS NOT NULL OR" +
                                " 	    ubat_estibaid IS NOT NULL" +
                                "	  )" +
                                " AND occa_ocupacioncarritoid = " + ocupacion_carritoID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Resumen_Plataforma_Atados_Con_Status_Diferente_A_1(ocupacion_carritoID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                " 	COUNT(DISTINCT ID_Docena) AS 'ATADOS EN ERROR'" +
                                " 	,COUNT(*) AS 'PARES EN ERROR'" +
                                " FROM tmpDocenasPares" +
                                " WHERE ID_Docena" +
                                " IN (" +
                                " 	SELECT" +
                                " 		ID_Docena" +
                                " 	FROM tmpDocenasPares" +
                                " 	WHERE ID_Docena IN (" +
                                " 						SELECT" +
                                " 							ocaa_codigoatado" +
                                " 						FROM Almacen.OcupacionCarrito" +
                                " 						JOIN Almacen.OcupacionCarritoAtados" +
                                " 							ON ocaa_ocupacioncarritoid = occa_ocupacioncarritoid" +
                                " 						WHERE ocaa_estibaid IS NULL" +
                                " 						AND occa_ocupacioncarritoid = " + ocupacion_carritoID.ToString +
                                " 					   )" +
                                " 	AND STATUS <> 1" +
                                " )"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Detalle_Plataforma(ocupacion_carritoID As Integer) As DataTable

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                " 	(CASE" +
                                " 		WHEN Status = 1 THEN 'ALMACÉN'" +
                                " 		ELSE CASE" +
                                " 				WHEN Status = 2 THEN 'SALIDA'" +
                                " 				ELSE CASE" +
                                " 						WHEN Status = 0 THEN 'PRODUCCIÓN'" +
                                " 					END" +
                                " 			END" +
                                " 	END) AS 'Proceso'," +
                                " 	(CASE" +
                                " 		WHEN ocaa_estibaid IS NOT NULL THEN 'SI'" +
                                " 		ELSE CASE" +
                                " 				WHEN coat_estibaid IS NOT NULL THEN 'NO'" +
                                " 				ELSE CASE" +
                                " 						WHEN ubpa_estibaid IS NOT NULL THEN '--'" +
                                " 						ELSE ' '" +
                                " 					END" +
                                " 			END" +
                                " 	END) AS 'Plat'," +
                                " 	(CASE" +
                                " 		WHEN ocaa_estibaid IS NOT NULL THEN ocaa_estibaid" +
                                " 		ELSE '--'" +
                                " 	END) AS 'Estiba C/Plat'," +
                                " 	(CASE" +
                                " 		WHEN ocaa_estibaid IS NULL AND" +
                                " 			coat_estibaid IS NOT NULL THEN coat_estibaid" +
                                " 		ELSE '--'" +
                                " 	END) AS 'Estiba S/Plat'," +
                                " 	(CASE" +
                                " 		WHEN ocaa_estibaid IS NULL AND" +
                                " 			coat_estibaid IS NULL AND" +
                                " 			ubpa_estibaid IS NOT NULL THEN ubpa_estibaid" +
                                " 		ELSE '--'" +
                                " 	END) AS 'Estiba Destallado'," +
                                " (CASE" +
                                " 		WHEN CC.codr_colaboradorid IS NOT NULL THEN CC.codr_nombrecorto" +
                                " 		ELSE CASE" +
                                " 				WHEN CA.codr_colaboradorid IS NOT NULL THEN CA.codr_nombrecorto" +
                                " 				ELSE CASE" +
                                " 						WHEN CP.codr_colaboradorid IS NOT NULL THEN CP.codr_nombrecorto" +
                                " 					END" +
                                " 			END" +
                                " 	END) AS 'Operador'," +
                                " 	(CASE" +
                                " 		WHEN ocaa_fechaubicacion IS NOT NULL THEN ocaa_fechaubicacion" +
                                " 		ELSE CASE" +
                                " 				WHEN coat_fechamodificacion IS NOT NULL THEN coat_fechamodificacion" +
                                " 				ELSE CASE" +
                                " 						WHEN ubpa_fechamodificacion IS NOT NULL THEN ubpa_fechamodificacion" +
                                " 						ELSE NULL" +
                                " 					END" +
                                " 			END" +
                                " 	END) AS 'Ubicación (hr)'," +
                                " 	ID_Par AS 'Código Par'," +
                                " 	ID_Docena AS 'Código Atado'," +
                                " 	(" +
                                "       CASE WHEN ocaa_estibaid IS NOT NULL THEN (" +
                                "	        CASE WHEN ocaa_origenubicacion = 'A' THEN 'A'" +
                                "	        ELSE " +
                                "		        CASE WHEN ocaa_origenubicacion = 'H' THEN 'H'" +
                                "		        ELSE '--'" +
                                "		        END" +
                                "	        END)" +
                                "       ELSE" +
                                "	        CASE WHEN coat_estibaid IS NOT NULL THEN (" +
                                "		        CASE WHEN coat_origenubicacion = 'A' THEN 'A'" +
                                "		        ELSE " +
                                "			        CASE WHEN coat_origenubicacion = 'H' THEN 'H'" +
                                "			        ELSE '--'" +
                                "			        END" +
                                "		        END)" +
                                "	        ELSE " +
                                "               CASE WHEN ubpa_estibaid IS NOT NULL THEN (" +
                                "                   CASE WHEN ubpa_origenubicacion = 'A' THEN 'A'" +
                                "                   ELSE" +
                                "                       CASE WHEN ubpa_origenubicacion = 'H' THEN 'H'" +
                                "                       ELSE '--'" +
                                "                       END" +
                                "                   END)" +
                                "               END" +
                                "           END" +
                                " 	    END) AS 'Origen'," +
                                " 	IdModelo AS 'Modelo'," +
                                " 	Descripcion AS 'Producto'," +
                                " 	Talla AS 'Corrida'," +
                                " 	Calce AS 'Talla'," +
                                " 	PedidoSicy AS 'Pedido Origen'," +
                                " 	idtblPedido AS 'Pedido'," +
                                " 	(CASE" +
                                " 		WHEN coat_idpedido IS NOT NULL THEN coat_idpedido" +
                                " 		ELSE NULL" +
                                " 	END) AS 'Pedido Cliente'," +
                                " 	Cliente1 AS 'Cliente'," +
                                " 	Lote AS 'Lote'," +
                                " 	Año AS 'Año'," +
                                " 	Naves.Nave AS 'Nave'," +
                                " 	(CASE" +
                                " 		WHEN coat_idpedido IS NOT NULL THEN coat_idpedido" +
                                " 		ELSE NULL" +
                                " 	END) AS 'Lote Cliente'," +
                                " 	(CASE" +
                                " 		WHEN coat_fechasalidanave IS NOT NULL THEN ocaa_fechaubicacion" +
                                " 		ELSE CASE" +
                                " 				WHEN ubpa_fechasalidanave IS NOT NULL THEN coat_fechamodificacion" +
                                " 				ELSE CASE" +
                                " 						WHEN tmpDocenasPares.FechaSalidaAlmacen IS NOT NULL THEN tmpDocenasPares.Fecha_salida" +
                                " 						ELSE NULL" +
                                " 					END" +
                                " 			END" +
                                " 	END) AS 'Salida Nave (hr)'," +
                                " 	(CASE" +
                                " 		WHEN ocaa_fechaubicacion IS NOT NULL THEN ocaa_fechaubicacion" +
                                " 		ELSE CASE" +
                                " 				WHEN coat_fechamodificacion IS NOT NULL THEN coat_fechamodificacion" +
                                " 				ELSE CASE" +
                                " 						WHEN ubpa_fechamodificacion IS NOT NULL THEN ubpa_fechamodificacion" +
                                " 						ELSE NULL" +
                                " 					END" +
                                " 			END" +
                                " 	END) AS 'Ubicación'," +
                                " 	(CASE" +
                                " 		WHEN coat_fechasalidanave IS NOT NULL THEN ocaa_fechaubicacion" +
                                " 		ELSE CASE" +
                                " 				WHEN ubpa_fechasalidanave IS NOT NULL THEN coat_fechamodificacion" +
                                " 				ELSE CASE" +
                                " 						WHEN tmpDocenasPares.FechaSalidaAlmacen IS NOT NULL THEN tmpDocenasPares.Fecha_salida" +
                                " 						ELSE NULL" +
                                " 					END" +
                                " 			END" +
                                " 	END) AS 'Salida Nave'" +
                                " FROM tmpDocenasPares" +
                                " LEFT JOIN Almacen.OcupacionCarritoAtados ON ocaa_codigoatado = ID_Docena" +
                                " LEFT JOIN Almacen.OcupacionCarrito ON occa_ocupacioncarritoid = ocaa_ocupacioncarritoid" +
                                " LEFT JOIN Almacen.UbicacionAtados ON ubat_codigoatado = ID_Docena" +
                                " LEFT JOIN Almacen.ContenidoAtados ON coat_codigopar = ID_Par" +
                                " LEFT JOIN Almacen.UbicacionPares ON ubpa_codigopar = ID_Par" +
                                " LEFT JOIN Nomina.Colaborador AS CC ON CC.codr_colaboradorid = ocaa_colaboradorid" +
                                " LEFT JOIN Nomina.Colaborador AS CA ON CA.codr_colaboradorid = ubat_colaboradormodificaid" +
                                " LEFT JOIN Nomina.Colaborador AS CP ON CA.codr_colaboradorid = ubpa_colaboradormodificaid" +
                                " JOIN LotesDocenas ON IdDocena = ID_Docena" +
                                " JOIN vEstilos ON IdCodigo = idtblProducto" +
                                " JOIN Tallas ON IdTalla = idtblTalla" +
                                " JOIN Naves ON IdNave = LotesDocenas.Nave" +
                                " WHERE occa_ocupacioncarritoid = " + ocupacion_carritoID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function ConsultaCentroDistribucionActivos() As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Almacen_ConsultaAlmacenesActivos]", listaParametros)

    End Function

    Public Function ConsultaCentroDistribucionActivosUsuario(ByVal UsuarioID As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Almacen_ConsultaAlmacenesActivos_Usuario]", listaParametros)

    End Function

    Public Function ConsultaNumeroAlmacenes(ByVal NaveSAYID As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "NaveSAYID"
        parametro.Value = NaveSAYID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Almacen_ConsultaNumeroDeAlmacen]", listaParametros)

    End Function

    Public Function ConsultaDePlataformas(ByVal fechainicio As Date, ByVal fechafin As Date) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "@fechainicio"
        parametro.Value = fechainicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechafin"
        parametro.Value = fechafin
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_ubicacion_ConsultaPlataformasUbicadas]", listaParametros)

    End Function


    Public Function ConsultaCentroDistribucionActivosUsuario_tipo(ByVal UsuarioID As Integer, ByVal tipo As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tipo"
        parametro.Value = tipo
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Almacen_ConsultaAlmacenesActivos_Usuario_tipo]", listaParametros)

    End Function

End Class

