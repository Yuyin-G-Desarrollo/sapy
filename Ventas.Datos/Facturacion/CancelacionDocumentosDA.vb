Imports System.Data.SqlClient

Public Class CancelacionDocumentosDA

    Public Sub EjecutaRevisionCancelacionesPendientes()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_Cancelacion_PendientesSAY_AjustesAgo2018", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function consultaInformacionDocumentoCancelar(ByVal ClienteId As Integer, ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClienteID"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DocumentoID"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_Cancelacion_InformacionDocumento_AjustesAgo2018", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaFacturaDocumentosRelacionados(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@iddocumentosay"
            parametro.Value = DocumentoId
            listaParametros.Add(parametro)

            dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_CFDIRelacionados_ListadoCancelacion", listaParametros)
            Return dtResultadoConsulta
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function consultaMovimientosPorDocumento(ByVal RemisionID As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "RemisionID"
        parametro.Value = RemisionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_Cancelacion_MovimientosSICY", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaMotivosCancelacion(ByVal TipoDocumento As String, ByVal Timbrado As Integer, ByVal StatusProducto As String, ByVal ClienteID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "TipoDocumento"
        parametro.Value = TipoDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Timbrado"
        parametro.Value = Timbrado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusProducto"
        parametro.Value = StatusProducto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteID"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_Cancelacion_MotivosSinMovimientos", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultarConsideracionesPorMotivo(ByVal MotivoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "MotivoID"
        parametro.Value = MotivoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_Cancelacion_Consideraciones", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultarRFCPorDocumentoMotivo(ByVal ClienteID As Integer, ByVal TipoDocumento As String, ByVal MotivoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClienteID"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoDocumento"
        parametro.Value = TipoDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MotivoID"
        parametro.Value = MotivoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_Cancelacion_ListadoRFC", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultarUsosPorDocumento(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_Cancelacion_ListadoUsoCFDI", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function cancelarDocumento(ByVal DocumentoCancelar As Entidades.CancelacionDocumento) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
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
        parametro.ParameterName = "SustitucionInmediata"
        parametro.Value = DocumentoCancelar.SustitucionInmediata
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RequiereAutorizacionCliente"
        parametro.Value = DocumentoCancelar.RequiereAutorizacionCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NuevoRFCID"
        parametro.Value = DocumentoCancelar.NuevoRFCID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsoCFDIID"
        parametro.Value = DocumentoCancelar.UsoCFDIID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ProductoAlCancelar"
        parametro.Value = DocumentoCancelar.ProductoAlCancelar
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_Cancelacion_AjustesAgo2018", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function cancelarRefacturacion(ByVal ordenTrabajoId As Integer, ByVal usuarioId As Integer, ByVal observacionesCancelacion As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("exec Ventas.SP_FacturacionCalzado_RefacturacionCancelada " + ordenTrabajoId.ToString() + "," + usuarioId.ToString() + ",'" + observacionesCancelacion + "'")

    End Function

    Public Function cambiarStatusDocumentoCanceladoSAT(ByVal documentoId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("exec Ventas.SP_FacturacionCalzado_CambiarEstatusDocumentoCanceladoSAT " + documentoId.ToString() + "")

    End Function

    Public Function cambiarStatusDocumentoCancelado(ByVal documentoId As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("exec Ventas.SP_FacturacionCalzado_CambiarEstatusDocumentoCancelado  " + documentoId.ToString() + "")

    End Function


    Public Sub cancelarDocumentoSICY(ByVal DocumentoCancelar As Entidades.CancelacionDocumento)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoIDSay"
        parametro.Value = DocumentoCancelar.DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoDocumento"
        parametro.Value = DocumentoCancelar.TipoComprobrante
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RemisionID"
        parametro.Value = DocumentoCancelar.RemisionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = DocumentoCancelar.Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdMotivoSICY"
        parametro.Value = DocumentoCancelar.MotivoSICYID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoCatalogo"
        parametro.Value = DocumentoCancelar.MotivoCatalogo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoObservaciones"
        parametro.Value = DocumentoCancelar.Observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = DocumentoCancelar.UserName
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Cancelacion_SICY]", listaParametros)

    End Sub


    Public Function ObtenerInformacionMotivoCancelacionID(ByVal MotivoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@MotivoID"
        parametro.Value = MotivoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Cancelacion_ObtenerInfoMotivoCancelacion]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function validarEstatusOTParaCancelar(ByVal OT As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@OT"
        parametro.Value = OT
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_validarEstatusOTParaCancelar]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ValidarCancelacion(ByVal Documento As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idDocumento"
        parametro.Value = Documento
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Facturacion].[SP_validarCancelacionFacturacion]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ObtenerRelacionaCFDISegunMotivoCancelacion() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Cancelacion_ObtenerRelacionaCFDISegunMotivoCancelacion]", listaParametros)

        Return dtResultadoConsulta

    End Function


    Public Function EnviarParesRefacturarOT(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Cancelacion_EnviarAPorRefacturarUnaOT]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub EliminarRegistroSalidaNoEmbarcado(ByVal DocumentoSAYId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoSAYId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaVentas_EliminaSalida_NoEmbarcado]", listaParametros)

    End Sub

    Public Function ObtenerRelacionaCFDISegunMotivoCancelacionSolicitud(ByVal DocumentoSAYId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoSAYId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ObtenerMotivoCancelacion]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultarSolicitud(ByVal documentoid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Documentoid", documentoid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarSolicitud]", listaParametros)
    End Function

    Public Function ConsultarInfoMotivoCancelacionSAT(ByVal MotivoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@MotivoID"
        parametro.Value = MotivoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarInfoMotivoCancelacionSAT]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultarMotivoSatID(ByVal MotivoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@MotivoID"
        parametro.Value = MotivoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarMotivoSatID]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function cambiarStatusDocumentoConEsperaAceptacion(ByVal DocumentoID As Integer,
                                                              ByVal Solicita As String,
                                                              ByVal Observaciones As String,
                                                              ByVal UsuarioID As Integer,
                                                              ByVal ProductoAlCancelar As String,
                                                              ByVal MotivoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Solicita"
        parametro.Value = Solicita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Observaciones"
        parametro.Value = Observaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoAlCancelar"
        parametro.Value = ProductoAlCancelar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoID"
        parametro.Value = MotivoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_cambiarStatusDocumentoConEsperaAceptacion]", listaParametros)

        Return dtResultadoConsulta

    End Function


    Public Function ConsultarUbicacionProducto(ByVal documentoid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = documentoid
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarSalidasDeProductoDelDocumento]", listaParametros)

        Return dtResultadoConsulta

    End Function


End Class
