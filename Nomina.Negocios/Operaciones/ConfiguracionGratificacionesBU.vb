Public Class ConfiguracionGratificacionesBU

    Public Sub InsertarConfiguracionGratificacion(ByVal AutorizaGerente As Boolean, _
                                            ByVal AutorizaDirector As Boolean, ByVal NaveId As Int32, ByVal ApareceReporte As Boolean)
        Dim objConfiguracionDA As New Datos.ConfiguracionGratificacionDA
        objConfiguracionDA.InsertarConfiguracionGratificacion(AutorizaGerente, _
                                              AutorizaDirector, NaveId, ApareceReporte)
    End Sub



    Public Sub UpdateConfiguracionGratificacion(ByVal AutorizaGerente As Boolean, _
                                             ByVal AutorizaDirector As Boolean, ByVal ConfiguracionID As Int32, ByVal reportes As Boolean)
        Dim objConfiguracionDA As New Datos.ConfiguracionGratificacionDA
        objConfiguracionDA.UpdateConfiguracionGratificacion(AutorizaGerente, _
                                              AutorizaDirector, ConfiguracionID, reportes)
    End Sub

    Public Function ListaConfiguracionGratificacion() As List(Of Entidades.ConfiguracionGratificaciones)
        Dim objConfiguracionDA As New Datos.ConfiguracionGratificacionDA
        Dim objColaboradorBU As New ColaboradoresBU
        Dim tablaConfiguracion As New DataTable
        ListaConfiguracionGratificacion = New List(Of Entidades.ConfiguracionGratificaciones)
        tablaConfiguracion = objConfiguracionDA.ListaConfiguracionGratificacion()
        For Each row As DataRow In tablaConfiguracion.Rows
            Dim configuracion As New Entidades.ConfiguracionGratificaciones
            Dim Naves As New Entidades.Naves
            Try
                configuracion.PAutorizaGerente = CBool(row("confgrat_autorizagerente"))
            Catch ex As Exception
            End Try
            Try
                configuracion.PAutorizaDirector = CBool(row("confgrat_autorizadirector"))
            Catch ex As Exception
            End Try
            Try
                configuracion.PIDconfiguracion = CInt(row("confgrat_naveid"))
            Catch ex As Exception
            End Try
            Try
                configuracion.PconNaveId = CInt(row("confgrat_confguracionid"))
            Catch ex As Exception
            End Try
            Try
                configuracion.PApareceEnReportes = CBool(row("confgrat_aparecenomina"))
            Catch ex As Exception
            End Try
            Naves.PNombre = CStr(row("nave_nombre"))
            Naves.PNaveId = CStr(row("nave_naveid"))
            configuracion.PNaveNombre = Naves
            ListaConfiguracionGratificacion.Add(configuracion)

        Next
    End Function

    Public Function AutorizaGerente(ByVal Naveid As Int32) As Boolean
        Dim objDa As New Datos.ConfiguracionGratificacionDA
        Dim TablaConfiguracion As New DataTable
        Dim EntidadGratificacion As New Entidades.ConfiguracionGratificaciones
        TablaConfiguracion = objDa.buscarConfiguraciondeGratificacion(Naveid)
        For Each row As DataRow In TablaConfiguracion.Rows
            EntidadGratificacion.PAutorizaGerente = CBool(row("confgrat_autorizagerente"))
        Next
        If EntidadGratificacion.PAutorizaGerente = True Then
            AutorizaGerente = True
        Else
            AutorizaGerente = False
        End If

    End Function

    Public Function AutorizaDirector(ByVal Naveid As Int32) As Boolean
        Dim objDa As New Datos.ConfiguracionGratificacionDA
        Dim TablaConfiguracion As New DataTable
        Dim EntidadGratificacion As New Entidades.ConfiguracionGratificaciones
        TablaConfiguracion = objDa.buscarConfiguraciondeGratificacion(Naveid)
        For Each row As DataRow In TablaConfiguracion.Rows
            EntidadGratificacion.PAutorizaGerente = CBool(row("confgrat_autorizadirector"))
        Next
        If EntidadGratificacion.PAutorizaGerente = True Then
            AutorizaDirector = True
        Else
            AutorizaDirector = False
        End If

    End Function



    Public Function ApareceNomina(ByVal Naveid As Int32) As Boolean
        Dim objDa As New Datos.ConfiguracionGratificacionDA
        Dim TablaConfiguracion As New DataTable
        Dim EntidadGratificacion As New Entidades.ConfiguracionGratificaciones
        TablaConfiguracion = objDa.buscarConfiguraciondeGratificacion(Naveid)
        For Each row As DataRow In TablaConfiguracion.Rows
            EntidadGratificacion.PApareceEnReportes = CBool(row("confgrat_aparecenomina"))
        Next
        If EntidadGratificacion.PApareceEnReportes = True Then
            ApareceNomina = True
        Else
            ApareceNomina = False
        End If

    End Function




End Class
