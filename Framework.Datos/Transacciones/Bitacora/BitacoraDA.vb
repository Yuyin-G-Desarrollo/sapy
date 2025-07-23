Imports System.Data.SqlClient

Public Class BitacoraDA

    Public Function recuperar_datos_notificacion(TipoNotificacionID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Framework.BitacoraTipoNotificacion  WHERE btno_bitacoratiponotificacionid =" & TipoNotificacionID
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function recuperar_datos_cabecera_reporte(campo As String(), tabla As String, esquema As String, RegistroPrincipalID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT " +
                                "  " + campo(0) +
                                ", " + campo(1) +
                                " FROM " + esquema + "." + tabla + " WHERE " + campo(0) + " = " + RegistroPrincipalID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub eliminar_registros_tabla_bitacora_temporal(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " DELETE FROM Framework.BitacoraTemporal WHERE btem_tiponotificacionid = " + TipoNotificacionID.ToString + " AND btem_principalid = " + RegistroPrincipalID.ToString

        operaciones.EjecutaConsulta(consulta)

    End Sub

    Public Function recuperar_datos_bitacora_sin_enviar(TipoNotificacionID As Integer, RegistroPrincipalID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT * FROM Framework.Bitacora WHERE bita_notificado = 0 AND bita_bitacoratiponotificacionid = " + TipoNotificacionID.ToString + " AND bita_registroprincipalid = " + RegistroPrincipalID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function recuperar_datos_bitacora_consulta(consulta As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub insertar_registros_tabla_bitacora_temporal(consulta As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        operaciones.EjecutaConsulta(consulta)

    End Sub

    Public Function recuperar_registros_tabla_bitacora_temporal(TipoNotificacionID As Integer, RegistroPrincipalID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT " +
                                "   btem_nivelinformacion" +
                                " , btem_nombrenivelinformacion1" +
                                " , btem_nombrenivelinformacion2" +
                                " , btem_apartadoprincipal" +
                                " , btem_apartado" +
                                " , btem_etiqueta" +
                                " , btem_valor_antes" +
                                " , btem_valor_despues" +
                                " , btem_registroid" +
                                " FROM Framework.BitacoraTemporal" +
                                " WHERE btem_tiponotificacionid = " + TipoNotificacionID.ToString +
                                " AND btem_principalid = " + RegistroPrincipalID.ToString +
                                " AND btem_mostrar = 1" +
                                " ORDER BY btem_nivelinformacion, btem_nombrenivelinformacion1, btem_nombrenivelinformacion2, btem_apartadoprincipal, btem_apartado, btem_orden, btem_etiqueta, btem_registroid"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub actualizar_registros_notificados_bitacora(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " UPDATE Framework.Bitacora SET bita_notificado = 1 WHERE bita_notificado = 0 AND bita_bitacoratiponotificacionid = " + TipoNotificacionID.ToString + " AND bita_registroprincipalid = " + RegistroPrincipalID.ToString

        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub insertar_registros_notificados_bitacora_temporal(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " INSERT INTO Framework.Bitacora_Hist " +
                                " ( " +
                                "   bita_bitacoraid " +
                                " , bita_bitacoratiponotificacionid " +
                                " , bita_registroprincipalid " +
                                " , bita_registroid " +
                                " , bita_personaregistroid " +
                                " , bita_nivelinformacion " +
                                " , bita_tabla " +
                                " , bita_campos " +
                                " , bita_valor_antes " +
                                " , bita_valor_despues " +
                                " , bita_fecha " +
                                " , bita_usuarioid	" +
                                " , bita_notificado " +
                                " ) " +
                                " SELECT " +
                                "   BO.bita_bitacoraid " +
                                " , BO.bita_bitacoratiponotificacionid " +
                                " , BO.bita_registroprincipalid " +
                                " , BO.bita_registroid " +
                                " , BO.bita_personaregistroid " +
                                " , BO.bita_nivelinformacion " +
                                " , BO.bita_tabla " +
                                " , BO.bita_campos " +
                                " , BO.bita_valor_antes " +
                                " , BO.bita_valor_despues " +
                                " , BO.bita_fecha " +
                                " , BO.bita_usuarioid " +
                                " , BO.bita_notificado " +
                                " FROM Framework.Bitacora AS BO " +
                                " WHERE bita_notificado = 1 " +
                                " AND bita_bitacoratiponotificacionid = " + TipoNotificacionID.ToString +
                                " AND bita_registroprincipalid = " + RegistroPrincipalID.ToString

        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub eliminar_datos_bitacora_enviados(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " DELETE Framework.Bitacora WHERE bita_notificado = 1 AND bita_bitacoratiponotificacionid = " + TipoNotificacionID.ToString + " AND bita_registroprincipalid = " + RegistroPrincipalID.ToString
        operaciones.EjecutaConsulta(consulta)

    End Sub

    ''inserta bitacora de acceso say web
    Public Sub insertaBitacoraAccesoPedidosWeb(ByVal bita_usuarioid As Int32, ByVal bita_ip As String, ByVal bita_ubicacion As String,
                                                    ByVal bita_dispositivo As String, ByVal bita_macaddress As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "bita_usuarioid"
        parametros.Value = bita_usuarioid
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "bita_ip"
        parametros.Value = bita_ip
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "bita_ubicacion"
        parametros.Value = bita_ubicacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "bita_dispositivo"
        parametros.Value = bita_dispositivo
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "bita_macaddress"
        parametros.Value = bita_macaddress
        listaParametros.Add(parametros)
        'Dim consulta As String = String.Empty

        'consulta = "EXEC Ventas.SP_PedidosWeb_Inserta_BitacoraAcceso '" + bita_usuarioid.ToString + "'," + "'" + bita_ip.ToString + "'," + "'" + bita_ubicacion.ToString + "'," + "'" + bita_dispositivo.ToString + "'," + "'" + bita_macaddress.ToString + "'"

        operaciones.EjecutarSentenciaSP("Ventas.SP_PedidosWeb_Inserta_BitacoraAcceso", listaParametros)
    End Sub

    ''funcion para validar el acceso externo a say web
    Public Function validaAccesoExternoSay(ByVal macaddres As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "macaddress"
        parametros.Value = macaddres
        listaParametros.Add(parametros)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ValidaAccesoExternoSay", listaParametros)
    End Function

End Class
