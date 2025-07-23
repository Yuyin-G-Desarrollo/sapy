Public Class BitacoraBU

    Public Function recuperar_datos_notificacion(TipoNotificacionID As Integer) As DataTable
        Dim objAccionesDA As New Datos.BitacoraDA
        Return objAccionesDA.recuperar_datos_notificacion(TipoNotificacionID)
    End Function

    Public Function recuperar_datos_cabecera_reporte(campo As String(), tabla As String, esquema As String, RegistroPrincipalID As Integer) As DataTable
        Dim objAccionesDA As New Datos.BitacoraDA
        Return objAccionesDA.recuperar_datos_cabecera_reporte(campo, tabla, esquema, RegistroPrincipalID)
    End Function

    Public Sub eliminar_registros_tabla_bitacora_temporal(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim objAccionesDA As New Datos.BitacoraDA
        objAccionesDA.eliminar_registros_tabla_bitacora_temporal(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    Public Function recuperar_datos_bitacora_sin_enviar(TipoNotificacionID As Integer, RegistroPrincipalID As Integer) As DataTable
        Dim objAccionesDA As New Datos.BitacoraDA
        Return objAccionesDA.recuperar_datos_bitacora_sin_enviar(TipoNotificacionID, RegistroPrincipalID)
    End Function

    Public Function recuperar_datos_bitacora_consulta(consulta As String) As DataTable
        Dim objAccionesDA As New Datos.BitacoraDA
        Return objAccionesDA.recuperar_datos_bitacora_consulta(consulta)
    End Function

    Public Sub insertar_registros_tabla_bitacora_temporal(consulta As String)
        Dim objAccionesDA As New Datos.BitacoraDA
        objAccionesDA.insertar_registros_tabla_bitacora_temporal(consulta)
    End Sub

    Public Function recuperar_registros_tabla_bitacora_temporal(TipoNotificacionID As Integer, RegistroPrincipalID As Integer) As DataTable
        Dim objAccionesDA As New Datos.BitacoraDA
        Return objAccionesDA.recuperar_registros_tabla_bitacora_temporal(TipoNotificacionID, RegistroPrincipalID)
    End Function

    Public Sub actualizar_registros_notificados_bitacora(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
         Dim objAccionesDA As New Datos.BitacoraDA
        objAccionesDA.actualizar_registros_notificados_bitacora(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    Public Sub insertar_registros_notificados_bitacora_temporal(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim objAccionesDA As New Datos.BitacoraDA
        objAccionesDA.insertar_registros_notificados_bitacora_temporal(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    Public Sub eliminar_datos_bitacora_enviados(TipoNotificacionID As Integer, RegistroPrincipalID As Integer)
        Dim objAccionesDA As New Datos.BitacoraDA
        objAccionesDA.eliminar_datos_bitacora_enviados(TipoNotificacionID, RegistroPrincipalID)
    End Sub

    ''inserta bitacora de acceso say web
    Public Sub insertaBitacoraAccesoPedidosWeb(ByVal bita_usuarioid As Int32, ByVal bita_ip As String, ByVal bita_ubicacion As String,
                                                    ByVal bita_dispositivo As String, ByVal bita_macaddress As String)

        Dim objDA As New Datos.BitacoraDA
        objDA.insertaBitacoraAccesoPedidosWeb(bita_usuarioid, bita_ip, bita_ubicacion, bita_dispositivo, bita_macaddress)
    End Sub

    ''funcion para validar el acceso externo a say web
    Public Function validaAccesoExternoSay(ByVal macaddres As String) As DataTable
        Dim dtValido As New DataTable
        Dim objDA As New Datos.BitacoraDA

        dtValido = objDA.validaAccesoExternoSay(macaddres)

        Return dtValido
    End Function


End Class
