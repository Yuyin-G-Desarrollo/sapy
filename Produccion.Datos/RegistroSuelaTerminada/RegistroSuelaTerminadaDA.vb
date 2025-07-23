Imports System.Data.SqlClient
Imports Entidades
Imports Persistencia

Public Class RegistroSuelaTerminadaDA


    Public Function IniciarSesion(ByVal ColaboradorID As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@ColaboradorID", ColaboradorID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_IniciarSesion]", listaParametros)
    End Function

    Public Function ValidarCodigoLoteSuela(ByVal Codigo As String, ByVal Tipo As String, ByVal ColaboradorID As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Codigo", Codigo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Tipo", Tipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColaboradorID", ColaboradorID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_ValidarCodigoLoteSuela]", listaParametros)
    End Function

    Public Function ConsultarInformacionRegistroActivo()
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_ConsultarInformacionRegistroActivo]", listaParametros)
    End Function

    Public Function DescartarRegistro(ByVal RegistroID As Integer, ByVal ColaboradorID As Integer, ByVal Observaciones As String)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@RegistroID", RegistroID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColaboradorID", ColaboradorID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Observaciones", Observaciones)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_DescartarRegistro]", listaParametros)
    End Function

    Public Function FinalizarRegistro(ByVal RegistroID As Integer, ByVal ColaboradorID As Integer, ByVal Observaciones As String)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@RegistroID", RegistroID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColaboradorID", ColaboradorID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Observaciones", Observaciones)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_FinalizarRegistro]", listaParametros)
    End Function

    Public Function ConsultarCodigosErroneos(ByVal RegistroID As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@RegistroID", RegistroID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_ConsultarCodigosErroneos]", listaParametros)
    End Function

    Public Function Consultar(ByVal FechaInicio As String, ByVal FechaTermino As String)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaTermino", FechaTermino)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_Consultar]", listaParametros)
    End Function

    Public Function ConsultarDetalles(ByVal Folios As String)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Folios", Folios)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_ConsultarDetalles]", listaParametros)
    End Function

    Public Function ConsultarReporteAvanceParesPorEntregar() As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_ConsultarReporteAvanceParesPorEntregar]", listaParametros)
    End Function

    Public Function ConsultarReporteAvancesProduccion() As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_ConsultarReporteAvancesProduccion]", listaParametros)
    End Function

    Public Function ConsultarReporteLotesPendientes() As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_ConsultarReporteLotesPendientes]", listaParametros)
    End Function
    Public Function ConsultarReporteAvancePorDia() As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_RegistroSuelaTerminada_ConsultarReporteAvancePorDia]", listaParametros)
    End Function

    Public Function ConsultarReporteAvancesProduccionPespunte(NaveID As Integer, ConfiguracionID As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ConfiguracionID", ConfiguracionID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccion_ConsultarReporteAvancesProduccion]", listaParametros)
    End Function

    Public Function ConsultarReporteAvancePorDiaPespunte(NaveID As Integer, ConfiguracionID As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ConfiguracionID", ConfiguracionID)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccion_ConsultarReporteAvancePorDia]", listaParametros)
    End Function

    Public Function ConsultarReporteLotesPendientesPespunte(NaveID As Integer, ConfiguracionID As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ConfiguracionID", ConfiguracionID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccion_ConsultarReporteLotesPendientes]", listaParametros)
    End Function

    Public Function ConsultarLotesPendientesDepartamentoNave(NaveID As Integer, DepartamentoID As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@DepartamentoID", DepartamentoID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccion_ConsultarLotesPendientesDepartamentoNave]", listaParametros)
    End Function

    Public Sub ActualizarMotivoAtraso(LotesActualizar As String, UsuarioID As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@LotesActualizar", LotesActualizar)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccion_ActualizarMotivoAtraso]", listaParametros)
    End Sub

    Public Function ConsultarNaves(UsuarioID As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccion_ConsultarNaves]", listaParametros)
    End Function

    Public Function ConsultarDepartamentosConfiguracionNave(NaveID As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccion_ConsultarDepartamentosConfiguracionNave]", listaParametros)
    End Function
End Class
