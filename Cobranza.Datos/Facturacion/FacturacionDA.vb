Imports System.Data.SqlClient

Public Class FacturacionDA
    Public Function ConsultarDocumentos(fechaInicio As DateTime,
                                   fechaFin As DateTime,
                                   usuarioConsultaID As Integer,
                                   permiso As Integer,
                                   entregados As Integer,
                                   filtroCliente As String,
                                   cedis As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioConsultaID"
        parametro.Value = usuarioConsultaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "permiso"
        parametro.Value = permiso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "entregados"
        parametro.Value = entregados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroCliente"
        parametro.Value = filtroCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_ConsultarDocumentos", listaParametros)

    End Function

    Public Function ConsultarDocumentosCobranza(fechaInicio As DateTime,
                                   fechaFin As DateTime,
                                   usuarioConsultaID As Integer,
                                   permiso As Integer,
                                   entregados As Integer,
                                   recibidos As Integer,
                                   filtroCliente As String,
                                   cedis As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioConsultaID"
        parametro.Value = usuarioConsultaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "permiso"
        parametro.Value = permiso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "entregados"
        parametro.Value = entregados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "recibidos"
        parametro.Value = recibidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroCliente"
        parametro.Value = filtroCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_ConsultarDocumentos_Cobranza", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_ConsultarDocumentos_Cobranza_V2", listaParametros)

    End Function

    Public Function ConsultarCatalogoTipoComprobante() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_ConsultarTipoComprobante", listaParametros)

    End Function

    Public Function ConsultarCatalogoMotivosNoEntrega() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_ConsultarMotivosNoEntrega", listaParametros)

    End Function

    Public Function RegistrarEntregadoDocumento(documentoId As Integer, tipoComprobanteId As Integer, motivoNoEntrega As Integer, usuarioCaptura As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "documentoId"
        parametro.Value = documentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoComprobanteId"
        parametro.Value = tipoComprobanteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoNoEntrega"
        parametro.Value = motivoNoEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCaptura"
        parametro.Value = usuarioCaptura
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_RegistraDocumentos", listaParametros)

    End Function

    Public Function RegistrarEntregadoDocumento_SICY(remisionId As Integer, anioRemision As Integer, tipoComprobanteId As String, motivoNoEntrega As String, usuarioCaptura As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "remision"
        parametro.Value = remisionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anioRemision"
        parametro.Value = anioRemision
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoComprobante"
        parametro.Value = tipoComprobanteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoNoEntrega"
        parametro.Value = motivoNoEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCaptura"
        parametro.Value = usuarioCaptura
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_RegistraDocumentos", listaParametros)

    End Function

    Public Function CancelarEntregadoDocumento(documentoId As Integer, usuarioCaptura As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "documentoId"
        parametro.Value = documentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCaptura"
        parametro.Value = usuarioCaptura
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_CancelarDocumentos", listaParametros)

    End Function

    Public Function CancelarEntregadoDocumento_Cobranza(documentoId As Integer, usuarioCaptura As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "documentoId"
        parametro.Value = documentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCaptura"
        parametro.Value = usuarioCaptura
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_CancelarDocumentos_Cobranza", listaParametros)

    End Function

    Public Function RegistrarRecibidoDocumento(documentoId As Integer, usuarioCaptura As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "documentoId"
        parametro.Value = documentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCaptura"
        parametro.Value = usuarioCaptura
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Entrega_Documentos_RegistraDocumentos_Cobranza", listaParametros)

    End Function
End Class
