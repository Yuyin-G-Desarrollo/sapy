Imports System.Data.SqlClient
Imports Persistencia

Public Class SolicitudBajaDA


    Public Function ConsultarSolicitudBajaExterno(ByVal ColaboradorID As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ExisteSolicitudBajaColaboradorExterno]", listaParametros)

    End Function

    Public Function ConsultaEnvioCorreo(ByVal SolicitudBajaID As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "SolicitudBajaID"
        parametro.Value = SolicitudBajaID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ConsultaDatosCorreo]", listaParametros)

    End Function


    Public Function EditarEstatusSolicitud(ByVal SolicitudBajaID As Integer, ByVal EstatusID As Integer, ByVal UsuarioId As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "SoliciutdBajaID"
        parametro.Value = SolicitudBajaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusID"
        parametro.Value = EstatusID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_EditarEstatus]", listaParametros)

    End Function

    Public Function ConsultaEstatusSolicitudBaja() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ConsultaEstatus]", listaParametros)
    End Function


    Public Function GuardarSolicitudBaja(ByVal ColaboradorID As Integer, ByVal FechaBaja As Date, ByVal UsuarioCreoID As Integer, ByVal FechaCreacion As Date, ByVal Motivo As String, ByVal FiniquitoRealID As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaBaja"
        parametro.Value = FechaBaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCreacion"
        parametro.Value = FechaCreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FinquitoRealID"
        parametro.Value = FiniquitoRealID
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_GuardarInformacion]", listaParametros)


    End Function


    Public Function ConsultaSolicitudesBaja(ByVal NaveID As Integer, ByVal EmpresaId As Integer, ByVal EstatusSolicitudID As Integer, ByVal Nombre As String, ByVal EsFiltroFechaBaja As Boolean, ByVal EsFiltroRango As Boolean, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal PeriodoId As Integer, ByVal FiltroFecha As Boolean) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EmpresaId"
        parametro.Value = EmpresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusSolicitudId"
        parametro.Value = EstatusSolicitudID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = Nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsFechaBaja"
        parametro.Value = EsFiltroFechaBaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroRango"
        parametro.Value = EsFiltroRango
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
        parametro.ParameterName = "PeriodoNominaID"
        parametro.Value = PeriodoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroFecha"
        parametro.Value = FiltroFecha
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ConsultaSolcitudes]", listaParametros)


    End Function

    Public Function EditarSolicitudBaja(ByVal SolicitudBajaID As Integer, ByVal ColaboradorID As Integer, ByVal FechaBaja As Date, ByVal UsuarioCreoID As Integer, ByVal FechaCreacion As Date, ByVal Motivo As String) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "SolicitudBajaIMSSId"
        parametro.Value = SolicitudBajaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaBaja"
        parametro.Value = FechaBaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = UsuarioCreoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCreacion"
        parametro.Value = FechaCreacion
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_EditarInformacion]", listaParametros)


    End Function


    Public Function ObtenerSolicitud(ByVal ColaboradorID As Integer, ByVal SolicitudIMSS As Integer, ByVal FiniquitoRealId As Integer, ByVal FinquitoFiscalID As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SoliciutdBajaIMSS"
        parametro.Value = SolicitudIMSS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FinquitoRealID"
        parametro.Value = FiniquitoRealId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FinquitoFiscalID"
        parametro.Value = FinquitoFiscalID
        listaParametros.Add(parametro)

        


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ConsultaInformacion]", listaParametros)


    End Function


    Public Function ObtenerInformacionDocumentoIDSE(ByVal ColaboradorId As Integer, ByVal FiniquitoFiscalID As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Colaborador"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiniquitoFiscalID"
        parametro.Value = FiniquitoFiscalID
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ConsultarInformacionIDSE]", listaParametros)

    End Function

    Public Function SolicitudBajaAceptada(ByVal BajaIMSS As Integer, ByVal ColaboradorID As Integer, ByVal Carpeta As String, ByVal Archivo As String, ByVal Movimiento As String, ByVal UsuarioID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "BajaIMSS"
        parametro.Value = BajaIMSS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "carpeta"
        parametro.Value = Carpeta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "archivo"
        parametro.Value = Archivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "movimiento"
        parametro.Value = Movimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NBajaIMSS_AceptarRechazarBajaImssIDSE]", listaParametros)
    End Function

    Public Function SolicitudBajaRechazada(ByVal BajaIMSS As Integer, ByVal ColaboradorID As Integer, ByVal Carpeta As String, ByVal Archivo As String, ByVal Movimiento As String, ByVal UsuarioID As Integer, ByVal motivo As String) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "BajaIMSS"
        parametro.Value = BajaIMSS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "carpeta"
        parametro.Value = Carpeta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "archivo"
        parametro.Value = Archivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "movimiento"
        parametro.Value = Movimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoRechazo"
        parametro.Value = motivo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NBajaIMSS_AceptarRechazarBajaImssIDSE]", listaParametros)
    End Function

    Public Function existePeriodoNominaBajas(ByVal colaboradorId As Int32, ByVal opcOperacion As Int32, ByVal fecha As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcOperacion"
        parametro.Value = opcOperacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fecha"
        parametro.Value = fecha
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ExistePeriodoNomina]", listaParametros)
    End Function

    Public Function validaIncapacidadColaborador(ByVal idColaborador As Int32, ByVal fechaBaja As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaBaja"
        parametro.Value = fechaBaja
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ValidaIncapacidadColaborador]", listaParametros)
    End Function

    Public Function validaTxtGenerado(ByVal solicitudId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "SolicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFSolicitudBaja_ValidaTxtGenerado]", listaParametros)
    End Function
End Class
