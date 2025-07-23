

Imports System.Data.SqlClient

Public Class EntradaSalidaMuestrasDA

    Dim objPersistencia As New Persistencia.OperacionesProcedimientos
    Public Function ConsultarNavesUsuario_EnvioRecepcion(ByVal NombreUsuario As String, Proceso As Integer) As DataTable

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NombreUsuario"
            parametro.Value = NombreUsuario
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@Proceso"
            parametro.Value = Proceso
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[Sp_EnvioRecepcionMuestras_ConsultarNavesUsuario_EnvioRecepcion]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarNavesUsuario_Recepcion(ByVal NombreUsuario As String) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NombreUsuario"
            parametro.Value = NombreUsuario
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[Sp_EnvioRecepcionMuestras_ConsultarNavesUsuario_Recepcion]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarCodigoMuestra(ByVal codigo As String, NaveID As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@Codigo"
            parametro.Value = codigo
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveEnvia"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ValidarCodigoMuestra]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarCodigoMuestra_Recepcion(ByVal codigo As String, FolioRecepcion As Integer, NaveID As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@CodigoPieza"
            parametro.Value = codigo
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@Folio"
            parametro.Value = FolioRecepcion
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ValidarCodigoPieza_Recepcion]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardarEncabezadoPrimerCodigoLeido(NaveID As Integer, UsuarioEnviaID As Integer, CodigoPieza As String, ByVal cedisId As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@UsuarioEnviaID"
            parametro.Value = UsuarioEnviaID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@PiezaID"
            parametro.Value = CodigoPieza
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@cedisId"
            parametro.Value = cedisId
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_InsertarEncabezadoYPrimerPiezaLeida]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ValidarFolioEnProceso(NaveID As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ConsultarFoliosEnProceso]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPiezasEscaneadas(Folio As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvioRecepcion"
            parametro.Value = Folio
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ConsultarPiezasEscaneadas]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarPiezaMuestra(FolioEnvio As Integer, Codigo As String, UsuarioID As Integer, ByVal cedisId As Integer)
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvioRecepcion"
            parametro.Value = FolioEnvio
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@PiezaID"
            parametro.Value = Codigo
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@UsuarioEnviaID"
            parametro.Value = UsuarioID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@cedisId"
            parametro.Value = cedisId
            ListaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_InsertarPiezas]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ActualizarEstausEnvioRecepcionMuestras(Folio As Integer, UsuarioID As Integer, Proceso As Integer, ByVal seVanPiezasEnReproceso As Boolean, ByVal idReproceso As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@Folio"
            parametro.Value = Folio
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@Proceso"
            parametro.Value = Proceso
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ActualizarEstatusFolioEnvioRecepcion]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPiezasPorFolioEnvio_Reporte(ByVal FolioEnvio As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvio"
            parametro.Value = FolioEnvio
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_Consultar_EnvioRecepcionPiezasNave_Reporte]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPiezasPorFolioEnvio_Reporte_EnviadasDeReproceso(ByVal FolioEnvio As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvio"
            parametro.Value = FolioEnvio
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_Consultar_EnvioRecepcionPiezasNave_Reporte_EnviadasDeReproceso]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarFoliosEnvioRecepcion_Reporte(NaveID As Integer, FechaInicio As String, FechaFin As String, ByVal cedisId As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@cedisId"
            parametro.Value = cedisId
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ConsultarFoliosEmbarcados_Reporte]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarTipoNave_Recepcion(NaveID As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter

        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ValidarTipoNaveRecepcion]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarFoliosEnviosNaves_Recepcion(NaveID As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ConsultarFoliosEnvioNaves_Recepcion]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecibirPrimerPiezaRecepcion(NaveID As Integer, CodigoPieza As String, FolioEnvio As Integer, UsuarioID As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@CodigoPieza"
            parametro.Value = CodigoPieza
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvio"
            parametro.Value = FolioEnvio
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@UsuarioRecibeID"
            parametro.Value = UsuarioID
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_IngresarPiezaComercializadora]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecibirPrimerPiezaRecepcion_NaveExterna(NaveID As Integer, CodigoPieza As String, UsuarioID As Integer, ByVal cedisid As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@CodigoPieza"
            parametro.Value = CodigoPieza
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@UsuarioRecibeID"
            parametro.Value = UsuarioID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@cedisid"
            parametro.Value = cedisid
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_IngresarPiezaComercializadora_NaveExterna]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub ActualizaPiezaRecibidaComercializadora(CodigoPiezas As String, UsuarioID As Integer, FolioEnvio As Integer)
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@CodigoPieza"
            parametro.Value = CodigoPiezas
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@UsuarioRecibeID"
            parametro.Value = UsuarioID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvio"
            parametro.Value = FolioEnvio
            ListaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ActualizarPiezasRecibidasComercializadora]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ActualizaPiezaRecibidaComercializadora_NaveExterna(CodigoPiezas As String, UsuarioID As Integer, FolioEnvio As Integer, ByVal cedisid As Integer)
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@CodigoPieza"
            parametro.Value = CodigoPiezas
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@UsuarioRecibeID"
            parametro.Value = UsuarioID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvioRecepcion"
            parametro.Value = FolioEnvio
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@cedisid"
            parametro.Value = cedisid
            ListaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_InsertarPiezasRecibidasComercializadora_NaveExterna]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ValidarFolioIngresando(NaveID As Integer, ComercializadoraID As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@ComercializadoraID"
            parametro.Value = ComercializadoraID
            ListaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ValidarFolioRecepcion]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPiezasRecibidas(Folio As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvioRecepcion"
            parametro.Value = Folio
            ListaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ConsultarPiezasRecibidas]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DescartarPiezas(PiezaID As String, UsuarioRecibe As Integer, FolioEnvio As Integer)

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@PiezaID"
            parametro.Value = PiezaID
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@UsuarioRecibeID"
            parametro.Value = UsuarioRecibe
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvio"
            parametro.Value = FolioEnvio
            ListaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_DescartarPiezasMuestras]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function ConsultarEncabezadoReporte(Folio As Integer, ByVal cedisId As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvioRecepcion"
            parametro.Value = Folio
            ListaParametros.Add(parametro)

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@cedisId"
            parametro.Value = cedisId
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ConsultarEncabezadoFolioEnvioRecepcion_Reporte]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPiezasDescartadas(Folio As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@FolioEnvioRecepcion"
            parametro.Value = Folio
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ConsultarPiezasDescartadas_Reporte]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerCedisNaves()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[Sp_EnvioRecepcionMuestras_ObtenerCedis]", listaParametros)
    End Function
    Public Function ConsultarNaveCedisPieza(ByVal codigoMuestra As String) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@codigoMuestra"
            parametro.Value = codigoMuestra
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ValidarCodigoMuestra_PerteneceCedis]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarNaveCedisPiezaCorrespondiente(ByVal codigoMuestra As String) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try
            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@piezaEscaneadaId"
            parametro.Value = codigoMuestra
            ListaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_ValidaPiezaEscaneada_CedisPerteneciente]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function obtenerReporteEnvioPiezasReproceso(ByVal folio As Integer, ByVal tipoReporte As String) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@FolioEnvio"
        parametro.Value = folio
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@tipoReporte"
        parametro.Value = tipoReporte
        ListaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_EnvioRecepcionMuestras_Consultar_PiezasEnReproceso]", ListaParametros)
    End Function


    Public Sub actualizaReprocesosPiezas(ByVal folioReproceso As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@folio", folioReproceso)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarSentenciaSP("[Programacion].[SP_ReprocesosMuestras_ActualizaEstatusReprocesos]", listaParametros)
    End Sub

    Public Function obtenerTotalPiezasEnvidas(ByVal folioMuestra As Integer) As DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@folioMuestraId"
        parametro.Value = folioMuestra
        ListaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_EnvioRecepcionMuestras_ValidaParesEscanedos]", ListaParametros)
    End Function

End Class
