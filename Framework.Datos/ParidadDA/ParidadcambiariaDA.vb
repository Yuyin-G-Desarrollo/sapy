Imports System.Data.SqlClient

Public Class ParidadcambiariaDA
    Public Function cargaMoneda(ByVal idMoneda As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select mone_monedaid, mone_nombre, mone_simbolo from Framework.Moneda " & _
                        " where mone_nombre NOT IN ('PESOS','PENDIENTE')"
        If idMoneda <> "" Then
            cadena += " AND mone_monedaid=" + idMoneda
        End If
        cadena += " ORDER by mone_nombre"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub guardaParidadMoneda(ByVal monedaID As Integer, ByVal valorParidad As String, ByVal moduloID As Integer, ByVal tipoCarga As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@monedaID"
        parametro.Value = monedaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@valorParidad"
        parametro.Value = valorParidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@moduloID"
        parametro.Value = moduloID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoCarga"
        parametro.Value = tipoCarga
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Framework.SP_CatalogoParidadMoneda", listaParametros)

    End Sub

    Public Function cargaParidad(ByVal estatus As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT" +
            " paca_paridadcambiariaid ," +
            " paca_monedaid," +
            " mone_nombre," +
            " ROUND(paca_paridadpesos,2) paca_paridadpesos," +
            " paca_moduloid," +
            " modu_nombre," +
            " mopc_automatica," +
            "   CASE" +
            " WHEN mopc_automatica = 0 THEN 'MANUAL'" +
            " ELSE 'AUTOMATICA'" +
            " END TipoActualizacion," +
            " paca_fechacreacion," +
            " case when  paca_usuariomodifico IS NULL THEN (SELECT user_nombrereal FROM Framework.Usuarios WHERE user_usuarioid = paca_usuariocreo)" +
            " ELSE (SELECT user_nombrereal FROM Framework.Usuarios WHERE user_usuarioid = paca_usuariomodifico)END AS 'Usuario'" +
            " FROM Framework.ParidadCambiaria" +
            " INNER JOIN Framework.Moneda" +
            " ON mone_monedaid = paca_monedaid" +
            " INNER JOIN Framework.Modulos" +
            " ON modu_moduloid = paca_moduloid" +
            " INNER JOIN Framework.ModuloParidadCarga" +
            " ON mopc_idmodulo = modu_moduloid " +
            " where paca_activo='" + estatus.ToString + "'" +
            " order by paca_fechacreacion DESC,mone_nombre"

        Return operacion.EjecutaConsulta(consulta)

    End Function

    Public Function cargaModuloActualizacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT" +
            " mopc_idmodulo," +
            " modu_nombre " +
            " FROM Framework.Modulos " +
            " JOIN Framework.ModuloParidadCarga " +
            " ON modu_moduloid = mopc_idmodulo" +
            " ORDER by modu_nombre"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function cargaModuloAlta() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT" +
            " modu_moduloid ," +
            " modu_nombre+' (ID ' +CAST(modu_moduloid AS varchar(5))+')' as nombre" +
            " FROM Framework.Modulos" +
            " WHERE modu_moduloid NOT IN (SELECT" +
            " mopc_idmodulo" +
            " FROM Framework.ModuloParidadCarga)" +
            " AND modu_superiorid IS NOT NULL order by nombre asc"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function ModulosAlta() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT" +
        " mopc_moduloparidadcargaid," +
        " mopc_idmodulo," +
        " modu_nombre+' (ID ' +CAST(modu_moduloid AS varchar(5))+')' as nombre," +
        " mopc_usuariocreo," +
        " user_username," +
        " mopc_fechacreacion/*, " +
        " mopc_automatica*/" +
        " FROM Framework.ModuloParidadCarga" +
        " INNER JOIN Framework.Modulos" +
        " ON modu_moduloid = mopc_idmodulo" +
        " INNER JOIN Framework.Usuarios" +
        " ON user_usuarioid = mopc_usuariocreo" +
        " order by modu_nombre asc"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Sub guardarCargaModulo(ByVal moduloID As Int32, ByVal tipoCarga As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@moduloID"
        parametro.Value = moduloID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoCarga"
        parametro.Value = tipoCarga
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Framework.SP_AltaModuloParidad", listaParametros)

    End Sub

    Public Sub actualizaCargaModulo(ByVal moduloID As Int32, ByVal tipoCarga As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@moduloID"
        parametro.Value = moduloID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoCarga"
        parametro.Value = tipoCarga
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Framework.SP_ActualizaModuloParidad", listaParametros)
    End Sub

    Public Function validaModuloActualizacionAutomatica(ByVal monedaID As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT DISTINCT " +
                                "   mopc_moduloparidadcargaid, mone_serieBanxico    " +
                                "   FROM Framework.ModuloParidadCarga   " +
                                "   INNER JOIN Framework.ParidadCambiaria   " +
                                "   on paca_moduloid=mopc_idmodulo  " +
                                "   INNER JOIN Framework.Moneda " +
                                "   on mone_monedaid=paca_monedaid  " +
                                "   WHERE mopc_automatica = 1   " +
                                "   AND mopc_activo = 1 " +                                
                                "   AND paca_monedaid=" + CStr(monedaID)
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function validacionActualizacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT	" +
                            " paca_monedaid, mone_nombre, paca_moduloid,mone_serieBanxico" +
                            "   FROM Framework.ParidadCambiaria   " +
                            "   INNER JOIN Framework.Moneda   " +
                            " ON mone_monedaid = paca_monedaid  " +
                            "   INNER JOIN Framework.Modulos    " +
                            " ON modu_moduloid = paca_moduloid  " +
                            "   INNER JOIN Framework.ModuloParidadCarga " +
                            " ON mopc_idmodulo = modu_moduloid  " +
                            " WHERE mopc_automatica = 1"
        Return operacion.EjecutaConsulta(consulta)
    End Function



End Class
