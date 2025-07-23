Imports System.Data.SqlClient

Public Class SolicitarCancelacionDA

    Public Function ConsultarMotivosInternos(ByVal Optional motivoid As Integer = 0) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@motivoid"
        parametro.Value = motivoid
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarMotivosInternosFacturas]", listaParmetros)
    End Function

    Public Function ConsultarMotivosInternoEditar(ByVal relacionado As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idMotivo"
        parametro.Value = relacionado
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarMotivosInternosEditar]", listaParmetros)
    End Function

    Public Function ConsultarColaboradores() As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        'parametro.ParameterName = "@Relacionado"
        'parametro.Value = relacionado
        'listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarColaboradores]", listaParmetros)
    End Function

    Public Function InsertarSolicitudCancelacionFactura(ByVal documentoId As Integer,
                                                        ByVal metodoPago As String,
                                                        ByVal razonsocialemisorid As Integer,
                                                        ByVal razonsocialreceptorid As Integer,
                                                        ByVal quienSolicita As Boolean,
                                                        ByVal facturaRequiereSustitucion As Boolean,
                                                        ByVal facturaMismoEmisorReceptor As Boolean,
                                                        ByVal motivoInternoid As Integer,
                                                        ByVal seRelaciona As Boolean,
                                                        ByVal observacion As String,
                                                        ByVal nombreSolicita As String,
                                                        ByVal solicitaColaboradorId As String
                                                        ) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@usuarioCreo", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@documentoId", documentoId)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@metodoPago", metodoPago)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@razonsocialemisorid", razonsocialemisorid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@razonsocialreceptorid", razonsocialreceptorid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@quienSolicita", quienSolicita)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@nombreSolicita", nombreSolicita)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@facturaRequiereSustitucion", facturaRequiereSustitucion)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@facturaMismoEmisorReceptor", facturaMismoEmisorReceptor)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@motivoInternoid", motivoInternoid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@seRelaciona", seRelaciona)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@observacion", observacion)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@solicitaColaboradorId", solicitaColaboradorId)
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_InsertarSolicitudCancelacion]", listaParmetros)
    End Function

    Public Function ConsultarSolicitudesCancelacionFactura(ByVal filtros As Entidades.FiltrosAdministradorSoliciturCancelacion) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "TipoFecha"
            parametro.Value = filtros.TipoFecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "FechaInicio"
            parametro.Value = filtros.FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "FechaTermino"
            parametro.Value = filtros.FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "StatusID"
            parametro.Value = filtros.StatusID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "FacturaId"
            parametro.Value = filtros.FacturaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "FolioFactura"
            parametro.Value = filtros.FolioFacturaID
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "ClienteId"
            parametro.Value = filtros.Clienteid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "EmisorId"
            parametro.Value = filtros.EmisorID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "ReceptorId"
            parametro.Value = filtros.ReceptorID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "MotivoInterno"
            parametro.Value = filtros.MotivoInterno
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "SolicitaInterno"
            parametro.Value = filtros.SolicitaInterno
            listaParametros.Add(parametro)

            'parametro = New SqlParameter
            'parametro.ParameterName = "SolicitaExterno"
            'parametro.Value = filtros.SolicitaExterno
            'listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "CEDIS"
            parametro.Value = filtros.CedisId
            listaParametros.Add(parametro)

            'parametro = New SqlParameter
            'parametro.ParameterName = "UsuarioConsultaId"
            'parametro.Value = filtros.UsuarioConsultaId
            'listaParametros.Add(parametro)

            dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_CancelacionFactura_ConsultarSolicitudCancelacion", listaParametros)

            'Return dtResultadoConsulta
        Catch ex As Exception

        End Try
        Return dtResultadoConsulta
    End Function

    Public Function ConsultarTodosMotivosCancelacion(ByVal activo As Boolean) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = activo
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarTodosMotivosCancelacionFacturas]", listaParmetros)
    End Function



    Public Function ConsultarMotivosSat(Optional motimoid As Integer = 0) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@motivoid"
        parametro.Value = motimoid
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarMotivosSAT]", listaParmetros)
    End Function

    Public Function InsertarMotivoCancelacion(ByVal motivo As String,
                                               ByVal seRelaciona As Boolean,
                                               ByVal motivoSat As Integer,
                                               ByVal activo As Boolean
                                               ) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@usuarioCreo", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@motivo", motivo)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@seRelaciona", seRelaciona)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@motivoSat", motivoSat)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@activo", activo)
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_InsertarMotivoCancelacion]", listaParmetros)
    End Function

    Public Function EditarMotivoCancelacion(ByVal motivo As String,
                                               ByVal seRelaciona As Boolean,
                                               ByVal motivoSat As Integer,
                                               ByVal activo As Boolean,
                                               ByVal motivoInterno As Integer
                                               ) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@usuarioCreo", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@motivo", motivo)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@seRelaciona", seRelaciona)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@motivoSat", motivoSat)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@activo", activo)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@motivoid", motivoInterno)
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_EditarMotivoCancelacion]", listaParmetros)
    End Function

    Public Function ConsultarDeclaracionesAnteriores(ByVal documnetoid As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = documnetoid
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarDeclaracionesAnteriores]", listaParmetros)
    End Function

    Public Function AutorizarSolicitudCancelacion(ByVal solicitudID As Integer,
                                                  ByVal Observaciones As String
                                               ) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@solicitudID", solicitudID)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@usuarioAutoriza", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@Observaciones", Observaciones)
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_AutorizarSolicitudCancelacion]", listaParmetros)
    End Function

    Public Function RechazarSolicitudCancelacion(ByVal solicitudID As Integer,
                                                  ByVal Observaciones As String
                                               ) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@solicitudID", solicitudID)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@usuarioAutoriza", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@Observaciones", Observaciones)
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_RechazarSolicitudCancelacion]", listaParmetros)
    End Function

    Public Function ConsultarSolicitudesPendientes(ByVal documentoID As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@documentoID"
        parametro.Value = documentoID
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarSolicitudesPendientes]", listaParmetros)
    End Function

    Public Function ConsultarDeclaraciones(ByVal Empresa As String, ByVal anio As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@Empresa"
            parametro.Value = Empresa
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = anio
            listaParametros.Add(parametro)

            dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_CancelacionFactura_ConsultarDeclaraciones", listaParametros)

            Return dtResultadoConsulta
        Catch ex As Exception

        End Try
        Return dtResultadoConsulta
    End Function

    Public Function ConsultarEmpresas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@Usuario"
            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            listaParametros.Add(parametro)


            dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_CancelacionFactura_ConsultarEmpresas", listaParametros)

            Return dtResultadoConsulta
        Catch ex As Exception

        End Try
        Return dtResultadoConsulta
    End Function

    Public Function InsertarDeclaracionComplementaria(ByVal empresa As Integer,
                                               ByVal mes As String,
                                               ByVal fecha As String
                                               ) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@usuarioCreo", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@empresa", empresa)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@mes", mes)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@fecha", fecha)
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_InsertarDeclaracionComplementaria]", listaParmetros)
    End Function

    Public Function ConsultarDeclaracionesPorMes(ByVal mes As String, ByVal empresaid As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@mes", mes)
        listaParmetros.Add(parametro)

        parametro = New SqlParameter("@empresa", empresaid)
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarDeclaracionesPorMes]", listaParmetros)
    End Function

    Public Function ConsultarEstatusSolicitud(ByVal solicitudid As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = solicitudid
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarEstatusSolicitud]", listaParmetros)
    End Function

    Public Function ActualizarEstatusSolicitud(ByVal documentoid As Integer, ByVal status As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = documentoid
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@StatusID"
        parametro.Value = status
        listaParmetros.Add(parametro)
        Try
            Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ActualizarEstatusSolicitud]", listaParmetros)
        Catch ex As Exception

        End Try

    End Function

    Public Function InsertaCancelacion(ByVal DocumentoCancelar As Entidades.CancelacionDocumento) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos

        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoID"
        parametro.Value = DocumentoCancelar.DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = DocumentoCancelar.UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Solicita"
        parametro.Value = DocumentoCancelar.Solicita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MotivoID"
        parametro.Value = DocumentoCancelar.MotivoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = DocumentoCancelar.Observaciones
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ProductoAlCancelar"
        parametro.Value = DocumentoCancelar.ProductoAlCancelar
        listaParametros.Add(parametro)



        dtResultadoConsulta = opeacion.EjecutarConsultaSP("Ventas.SP_CancelacionFactura_InsertarCancelacion", listaParametros)

        Return dtResultadoConsulta

    End Function


    Public Function ConsultarSolcitud(ByVal idDocumento As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarSolicitudesPendientesACancelar]", listaParmetros)
    End Function

    Public Function ActualizarDocumentoRechazadoCliente(ByVal idDocumento As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ActualizaStatusDocumento]", listaParmetros)
    End Function


    Public Function ConsultarClaveSatSolicitud(ByVal solicitud As Integer) As DataTable
        Dim opeacion As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@solicitud"
        parametro.Value = solicitud
        listaParmetros.Add(parametro)

        Return opeacion.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarClaveSATCancelacion]", listaParmetros)
    End Function

    Public Function EnviarParesRefacturarOT(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_EnviarAPorRefacturarUnaOT]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function TieneSolicitudesEnProceso(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_TieneSolicitudesEnProceso]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ActualizarSolicitudConDocumentoRelacionado(ByVal DocumentoId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoSustituto"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ActualizarSolicitudConDocumentoRelacionado]", listaParametros)

        Return dtResultadoConsulta

    End Function


End Class
