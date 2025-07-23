Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class VerificacionSalidasDA

    Public Function InsertarParesOT(ByVal CodigoCapturado As String, ByVal EsCodigoPar As Boolean, ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "CodigoCapturado"
        parametro.Value = CodigoCapturado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsCodigoPar"
        parametro.Value = EsCodigoPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_InsertarParesOT]", listaParametros)

    End Function


    Public Function InsertarFolio(ByVal EntidadFolio As Entidades.InfoVerificacionFolio) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = EntidadFolio.ColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Mensajeriaid"
        parametro.Value = EntidadFolio.MensajeriaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Mensajeria"
        parametro.Value = EntidadFolio.Mensajeria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OperadorID"
        parametro.Value = EntidadFolio.OperadorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operador"
        parametro.Value = EntidadFolio.Operador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UnidadID"
        parametro.Value = EntidadFolio.UnidadID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Unidad"
        parametro.Value = EntidadFolio.Unidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioPaqueteria"
        parametro.Value = EntidadFolio.FolioPaqueteria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusID"
        parametro.Value = EntidadFolio.StatusID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = EntidadFolio.UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsAndrea"
        parametro.Value = EntidadFolio.EsAndrea
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_InsertarFolio]", listaParametros)


    End Function

    Public Function ConsultaSessionActiva(ByVal ColaboradorId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultaSessionActiva]", listaParametros)

    End Function

    Public Function ParesPendientesDeConfirmar(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultarParesPendientesDeConfirmar]", listaParametros)

    End Function

    Public Function ConsultarParesOrdenTrabajo(ByVal FolioVerificacionID As Integer, ByVal OrdenTrabajoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionId"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrdenTrabajoID"
        parametro.Value = OrdenTrabajoId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultarParesOrdenTrabajo]", listaParametros)


    End Function

    Public Function ConsultarParesConfirmados(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultarParesConfirmados]", listaParametros)


    End Function

    Public Function ConsultarFolios(ByVal FiltrarPorFecha As Boolean, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal EstatusId As String, FolioVerificacionId As String, ByVal FiltroOT As String, ByVal Cedis As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FiltrarPorFecha"
        parametro.Value = FiltrarPorFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusID"
        parametro.Value = EstatusId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroOT"
        parametro.Value = FiltroOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cedis"
        parametro.Value = Cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultaFolios]", listaParametros)


    End Function


    Public Function ObtenerFolioVerificacionSession(ByVal ColaboradorID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ObtenerFolioSessionActiva]", listaParametros)


    End Function

    Public Function ValidaCodigoCapturado(ByVal CodigoCapturado As String, ByVal EsCodigoPar As Boolean, ByVal FolioVerificacion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "CodigoCapturado"
        parametro.Value = CodigoCapturado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsCodigoPar"
        parametro.Value = EsCodigoPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioVerificacion"
        parametro.Value = FolioVerificacion
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ValidarCodigoCapturado]", listaParametros)

    End Function


    Public Function ConsultarParesVerificacionFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultarParesVerificacionFolio]", listaParametros)

    End Function

    Public Function ConfirmarParesFolioVerificacion(ByVal FolioVerificacionID As Integer, ByVal EsCodigoPar As Boolean, ByVal CodigoCapturado As String, ByVal ColaboradorId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "CodigoCapturado"
        parametro.Value = CodigoCapturado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsCodigoPar"
        parametro.Value = EsCodigoPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradoraID"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConfirmarPares]", listaParametros)

    End Function

    Public Function ActualizarEncabezados(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ActualizarEncabezados]", listaParametros)

    End Function

    Public Function FinalizarFolioVerificacion(ByVal FolioVerificacionID As Integer, ByVal MensajeriaId As Integer, ByVal Mensajeria As String, ByVal OperadorId As Integer, ByVal Operador As String, ByRef UnidadId As Integer, ByVal Unidad As String, ByVal FolioPaqueteria As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MensajeriaID"
        parametro.Value = MensajeriaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Mensajeria"
        parametro.Value = Mensajeria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OperadorId"
        parametro.Value = OperadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operador"
        parametro.Value = Operador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UnidadId"
        parametro.Value = UnidadId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Unidad"
        parametro.Value = Unidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioPaqueteria"
        parametro.Value = FolioPaqueteria
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_FinalizarVerificacionSalida]", listaParametros)

    End Function

    Public Function DescartarOrdenTrabajo(ByVal FolioVerificacionID As Integer, ByVal OrdenTrabajo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrdenTrabajoID"
        parametro.Value = OrdenTrabajo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_DescartarOrdenTrabajo]", listaParametros)

    End Function

    Public Function ConsultaDetallesFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultaDetallesFolios]", listaParametros)

    End Function

    Public Function ObtenerInformacionFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultaInformacionFolio]", listaParametros)

    End Function

    Public Function ObtenerInformacionReporteFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_Reporte_ConsultaInformacionFolio]", listaParametros)

    End Function

    Public Function ObtenerInformacionEncabezadoReporteFolio(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_Reporte_ConsultaEncabezadoFolio]", listaParametros)

    End Function



    Public Function GenerarEmbarqueYSalida(ByVal idnave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdNave"
        parametro.Value = idnave
        listaParametros.Add(parametro)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_GenerarEmbarqueYSalida_Base_V2]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub ActualizarFolioEmbarqueAFacturado(ByVal idNave As Integer
                                                 )
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Idnave"
        parametro.Value = idNave
        listaParametros.Add(parametro)
        Try
            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_VerificacionSalida_ActualizarFacturadoFolio_Base_V2]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub GenerarDetallesSalidaVentas(ByVal idNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)
        Try
            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_VerificacionSalida_GenerarSalidaVentas_Base_V2]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ActualizarOT_A_Entregado(idNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)
        Try
            objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_FinalizarEntregaFolio_Base_V2]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ConsultaCodigoError(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FolioVerificacion"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultarCodigoError]", listaParametros)

    End Function

    Public Function ValidaUsuario(ByVal Colaborador As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Colaborador"
        parametro.Value = Colaborador
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ValidaUsuario]", listaParametros)

    End Function

    Public Function DescartarPares(ByVal FolioVerificacionID As Integer, ByVal Codigo As String, ByVal EsCodigoPar As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FolioVerificacionID"
        parametro.Value = FolioVerificacionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CodigoPar"
        parametro.Value = Codigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EsCodigoPar"
        parametro.Value = EsCodigoPar
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_DescartarPares]", listaParametros)

    End Function

    Public Function ConsultaLotesAndreaPorOT(ByVal FechaConfirmacion As Date, ByVal FechaFinConfirmacion As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "FechaConfirmacion"
        parametro.Value = FechaConfirmacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFinConfirmacion"
        parametro.Value = FechaFinConfirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_SeleccionarLotesAndreaConfirmadosv2]", listaParametros)

    End Function

    Public Function InsertarParesAndrea(ByVal FolioVerificacionID As Integer, ByVal OT As Integer, ByVal LoteAndrea As Integer, ByVal Partida As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@OT"
            parametro.Value = OT
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@LoteAndrea"
            parametro.Value = LoteAndrea
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Partida"
            parametro.Value = Partida
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ANDREA_InsertarParesOT]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarParesAConfirmarAndrea(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionID
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ANDREA_ConsultarParesSalida]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarParesConfirmadosAndrea(ByVal FolioVerificacionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ANDREA_ConsultarParesConfirmados]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConfirmarParesAndrea(ByVal FolioVerificacionID As Integer, ByVal CodigoAndrea As String, ByVal ColaboradorId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoAndrea"
            parametro.Value = CodigoAndrea
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColaboradorConfirmoId"
            parametro.Value = ColaboradorId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ANDREA_ConfirmarCodigoPar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function InsertaCodigoErrorAndrea(ByVal FolioVerificacionID As Integer, ByVal CodigoAndrea As String, ByVal MensajeError As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoLeido"
            parametro.Value = CodigoAndrea
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MensajeError"
            parametro.Value = MensajeError
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ANDREA_InsertarCodigoError]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LimpiarParesAndrea(ByVal FolioVerificacionID As Integer, ByVal CodigoAndrea As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoAndrea"
            parametro.Value = CodigoAndrea
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ANDREA_LimpiarCodigoAndrea]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaOTsPendientesSalida(ByVal ClienteID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ClienteSAYID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_VerificacionSalidas_ConsultaOTs_Agregar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function InsertarOT(ByVal FolioVerificacionID As Integer, ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@OT"
            parametro.Value = OrdenTrabajoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_InsertarOT]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function SessionActivaAndrea() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_SessionActivaAndrea]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaFolioAndrea() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultaFolioAndrea]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaLotesAndrea(ByVal FolioVerificacionId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ConsultaLotesAndrea]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function QuitarLotesAndrea(ByVal FolioVerificacionId As Integer, ByVal OrdenTrabajoId As Integer, ByVal LoteAndrea As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioVerificacionID"
            parametro.Value = FolioVerificacionId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = LoteAndrea
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@OrdenTrabajoID"
            parametro.Value = OrdenTrabajoId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VerificacionSalida_ANDREA_QuitarLotes]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaFolioDevolucionPendienteSalida() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_ConsultaFoliosPendienteSalida]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GenerarSalidaFolioDevolucion(ByVal FoliosDevolucion As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FoliosDevolucion"
            parametro.Value = FoliosDevolucion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_DevolucionCliente_GenerarSalidaFolioDevolucion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtenerNaveUsuario(ByVal usuarioid As Integer)
        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@idusuario", usuarioid)
        listaParametros.Add(parametro)
        Return obj.EjecutarConsultaSP("[Programacion].[SP_BuscarNave]", listaParametros)
    End Function


End Class
