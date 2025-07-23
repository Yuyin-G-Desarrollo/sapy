Imports System.Data.SqlClient
Imports Entidades

Public Class AdministradorResumenCostosDA
    Dim objPersistencia As New Persistencia.OperacionesProcedimientos

    '' ---------------------------------- AdministradorResumenCostosForm ---------------------------------- ''

    Public Function ConsultarNavesDesarrollo() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_Naves_ConsultarNavesDesarrollo]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarNaveLabora() As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@UsuarioId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_ConsultarNaveLabora]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarMarcas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_Marcas_ConsultarMarcas]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarColecciones() As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@Activo", 1)
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_Coleccion_ConsultarColecciones]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarEstatusProductoCosto() As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_ConsultarEstatus]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function





    Public Function ConsultarEstatusModelos() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_Modelos_ConsultarEstatusModelos]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarResumenCostosPorNave(ByVal NavesDesarrollo As String, ByVal Marcas As String, ByVal Temporadas As String, ByVal Colecciones As String, ByVal EstatusProductoCompra As String, ByVal EsArticulosClientesEspeciales As Boolean) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@NavesDesarrollo", NavesDesarrollo)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Marcas", Marcas)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Temporadas", Temporadas)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Colecciones", Colecciones)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@EstatusProductoCompra", EstatusProductoCompra)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@EsArticulosClientesEspeciales", EsArticulosClientesEspeciales)
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_ConsultarResumenCostosPorNave]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarIndicadoresPorNave(ByVal NavesDesarrollo As String, ByVal Marcas As String, ByVal Temporadas As String, ByVal Colecciones As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@NavesDesarrollo", NavesDesarrollo)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Marca", Marcas)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Temporadas", Temporadas)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Colecciones", Colecciones)
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_ConsultarIndicadoresArticulosSolicitadosPorNave]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function ConsultarReporteModelosPorColecciones(ByVal NavesDesarrollo As String, ByVal Temporadas As String, ByVal Colecciones As String, ByVal EstatusProductoCompra As String) As DataTable
    '    Dim listaParametros As New List(Of SqlParameter)

    '    Try
    '        Dim parametro As New SqlParameter("@NavesDesarrollo", NavesDesarrollo)
    '        listaParametros.Add(parametro)
    '        parametro = New SqlParameter("@Temporadas", Temporadas)
    '        listaParametros.Add(parametro)
    '        parametro = New SqlParameter("@Colecciones", Colecciones)
    '        listaParametros.Add(parametro)
    '        parametro = New SqlParameter("@EstatusProductoCompra", EstatusProductoCompra)
    '        listaParametros.Add(parametro)

    '        Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_Consultar_ReporteModelosPorColecciones]", listaParametros)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Function ConsultarReporteModelosPorColecciones_Encabezados(ByVal NavesDesarrollo As String, ByVal Temporadas As String, ByVal Colecciones As String, ByVal EstatusProductoCompra As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@NavesDesarrollo", NavesDesarrollo)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Temporadas", Temporadas)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Colecciones", Colecciones)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@EstatusProductoCompra", EstatusProductoCompra)
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_Consultar_ReporteModelosPorColecciones_Encabezados]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarReporteModelosPorColecciones_Modelos(ByVal NavesDesarrollo As String, ByVal Temporadas As String, ByVal Colecciones As String, ByVal EstatusProductoCompra As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@NavesDesarrollo", NavesDesarrollo)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Temporadas", Temporadas)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@Colecciones", Colecciones)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@EstatusProductoCompra", EstatusProductoCompra)
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_Consultar_ReporteModelosPorColecciones_Modelos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarReporteModelosPorColecciones_Especiales(ByVal ProductosEstilosSeleccionados As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@ProductosEstilosSeleccionados", ProductosEstilosSeleccionados)
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_Consultar_ReporteModelosPorColecciones_Especiales]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function





    Public Function GuardarCostoArticulos(ByVal CadenaXMLPrecios As String, ByVal NuevoEstatusId As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@CadenaXMLPrecios", CadenaXMLPrecios)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@NuevoEstatusId", NuevoEstatusId)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@UsuarioId", CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_GuardarCostoArticulos_ND]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CambiarEstatusPrecioCosto(ByVal ProductosEstilosConcantenados As String, ByVal NuevoEstatusId As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@ProductosEstilosConcantenados", ProductosEstilosConcantenados)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@NuevoEstatusId", NuevoEstatusId)
            listaParametros.Add(parametro)
            parametro = New SqlParameter("@UsuarioId", CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[DiseñoConceptual].[SP_PrecioCompra_CambiarEstatusPrecioCosto_DC]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '' ---------------------------------- AdministradorResumenCostosForm ---------------------------------- ''

End Class
