Imports System.Data.SqlClient

Public Class ConsultaDocumentosDA

    Public Function ConsultaDocumentos(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal clienteID As String, ByVal estatus As String, ByVal UsuarioID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", fechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", fechaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ClienteID", clienteID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Estatus", estatus)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Cobranza].[SP_ConsultaDocumentos]", listaParametros)
    End Function

    Public Function ConsultaClientes(ByVal UsuarioID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Cobranza].[SP_ConsultaDocumentos_ConsultaClientes]", listaParametros)
    End Function

    Public Sub ActualizarObsevaciones(ByVal observaciones As String, ByVal idRemision As Integer, ByVal anio As Int16)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@observacionesCobranza",
            .Value = observaciones
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@IdRemision",
            .Value = idRemision
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Año",
            .Value = anio
        }
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("[Cobranza].[SP_ConsultaDocumentos_ActualizarObservacionesCobranza]", listaParametros)

    End Sub

    Public Function ObtieneNCDocumentos(ByVal DocumentoID As String, ByVal Año As String, ByVal ClienteSICYID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim dtNCDocumentos As New DataTable

        parametro = New SqlParameter("@DocumentoID", DocumentoID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ClienteSICYID", ClienteSICYID)
        listaParametros.Add(parametro)

        dtNCDocumentos = objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ConsultaDocumentos_NCRelacionadas]", listaParametros)

        Return dtNCDocumentos

    End Function


    Public Function ObtieneInformacionReporte(ByVal CadenaID As String, ByVal fechaInicio As Date, ByVal fechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@CadenaID", CadenaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", fechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", fechaFin)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ObtieneListadoCobranza_RegistroDepositos_SAY]", listaParametros)

    End Function

    Public Function ObtieneInformacionReportePagos(ByVal CadenaID As String, ByVal Agentes As String, ByVal Empresas As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal tipoReporte As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@CadenaID", CadenaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Agentes", Agentes)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Empresa", Empresas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", fechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", fechaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoReporte", tipoReporte)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ObtieneListadoCobranza_RecibosPago_SAY]", listaParametros)

    End Function

End Class
