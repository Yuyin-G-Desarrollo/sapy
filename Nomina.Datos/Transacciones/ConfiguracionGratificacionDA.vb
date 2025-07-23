Public Class ConfiguracionGratificacionDA

    Public Function buscarConfiguraciondeGratificacion(ByVal NaveId As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select * from Nomina.ConfiguracionGratificaciones where confgrat_naveid=" + NaveId.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function ListaConfiguracionGratificacion() As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select * from Framework.Naves  as b join Framework.NavesUsuario as c on (b.nave_naveid = naus_naveid)"
        Consulta += " left join Nomina.ConfiguracionGratificaciones on"
        Consulta += " (nave_naveid = confgrat_naveid)  where naus_usuarioid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        Return ObjPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Sub InsertarConfiguracionGratificacion(ByVal AutorizaGerente As Boolean, _
                                              ByVal AutorizaDirector As Boolean, ByVal NaveId As Int32, ByVal ApareceReportes As Boolean)
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Dim Director, Gerente, Reportes As Int32
        If AutorizaDirector = True Then
            Director = 1
        Else
            Director = 0
        End If
        If AutorizaGerente = True Then
            Gerente = 1
        Else
            Gerente = 0
        End If
        If ApareceReportes = True Then
            Reportes = 1
        Else
            Reportes = 0
        End If
        Consulta = "insert into Nomina.ConfiguracionGratificaciones(confgrat_naveid,confgrat_autorizagerente,confgrat_autorizadirector,confgrat_fechaultimamodificacion,confgrat_usuariomodifico, confgrat_aparecenomina) values("
        Consulta += NaveId.ToString + "," + Gerente.ToString + "," + Director.ToString + ", (select getdate()),'" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername + "'," + Reportes.ToString + " )"
        ObjPersistencia.EjecutaConsulta(Consulta)
    End Sub

    Public Sub UpdateConfiguracionGratificacion(ByVal AutorizaGerente As Boolean, _
                                              ByVal AutorizaDirector As Boolean, ByVal IDConfiguracion As Int32, ByVal ApareceReportes As Boolean)
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Dim Director, Gerente, Reportes As Int32
        If AutorizaDirector = True Then
            Director = 1
        Else
            Director = 0
        End If
        If AutorizaGerente = True Then
            Gerente = 1
        Else
            Gerente = 0
        End If
        If ApareceReportes = True Then
            Reportes = 1
        Else
            Reportes = 0
        End If
        Consulta = "update Nomina.ConfiguracionGratificaciones set confgrat_autorizagerente=" + Gerente.ToString + ", confgrat_autorizadirector=" + Director.ToString + ",confgrat_fechaultimamodificacion= (select getdate()), "
        Consulta += "confgrat_usuariomodifico='" + Entidades.SesionUsuario.UsuarioSesion.PUserUsername + "', confgrat_aparecenomina=" + Reportes.ToString + " where confgrat_confguracionid=" + IDConfiguracion.ToString
        ObjPersistencia.EjecutaConsulta(Consulta)
    End Sub

End Class
