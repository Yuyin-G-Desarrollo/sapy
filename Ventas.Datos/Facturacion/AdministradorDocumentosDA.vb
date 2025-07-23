Imports System.Data.SqlClient

Public Class AdministradorDocumentosDA

    Public Function consultaAdministradorDocumentos(ByVal filtrosAdministradorDocumentos As Entidades.FiltrosAdministradorDocumentos) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = filtrosAdministradorDocumentos.TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = filtrosAdministradorDocumentos.FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaTermino"
        parametro.Value = filtrosAdministradorDocumentos.FechaTermino
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusID"
        parametro.Value = filtrosAdministradorDocumentos.StatusID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = filtrosAdministradorDocumentos.DocumentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FacturaId"
        parametro.Value = filtrosAdministradorDocumentos.FacturaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioOT"
        parametro.Value = filtrosAdministradorDocumentos.FolioOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClienteId"
        parametro.Value = filtrosAdministradorDocumentos.ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EmisorId"
        parametro.Value = filtrosAdministradorDocumentos.EmisorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ConsultaContabilidad"
        parametro.Value = filtrosAdministradorDocumentos.ConsultaContabilidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = filtrosAdministradorDocumentos.UsuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarOT"
        parametro.Value = filtrosAdministradorDocumentos.MostrarOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CEDIS"
        parametro.Value = filtrosAdministradorDocumentos.CEDISID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaAdministradorDocumentos_v3", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaOTPorDocumento(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaOrdenesTrabajoDocumento_AdministradorDocumentos", listaParametros)

        Return dtResultadoConsulta

    End Function
    Public Function ConsultaCancelacionEstatusSAT() As DataTable
        Dim dt As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            dt = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Cancelacion_EstatusCancelacionSAT]", listaParametros)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultaEncabezadoPantallaVerDetalles(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaEncabezado_VerDetallesAdministradorDocumentos", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaDescuentosPantallaVerDetalles(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaDescuentos_VerDetallesAdministradorDocumentos", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function consultaDetallesDocumentoPantallaVerDetalles(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaDetalles_VerDetallesAdministradorDocumentos", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultarReporteFacturas(ByVal DocumentoId As String, ByVal StatusId As String, ByVal FolioFactura As String, ByVal ClienteId As String, ByVal EmisorID As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@StatusID"
        parametro.Value = StatusId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FolioFactura"
        parametro.Value = FolioFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteID"
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmisorID"
        parametro.Value = EmisorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicioFacturacion"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFinFacturacion"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Reporte_Facturas]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ConsultarDetallesDocumentos(ByVal Documentos As String) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@Documentos"
            parametro.Value = Documentos
            listaParametros.Add(parametro)

            Return ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzadoDocumentoDetalles_DatosCompletos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarDetallesDocumentos_TotalParesPedido(ByVal Documentos As String) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@Documentos"
            parametro.Value = Documentos
            listaParametros.Add(parametro)

            Return ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzadoDocumentoDetalles_DatosCompletos_ParesPedido]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerRutas_PDF_XML_DocumentoExtanjero(ByVal DocumentoID As Integer) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@DocumentoID"
            parametro.Value = DocumentoID
            listaParametros.Add(parametro)

            Return ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_Facturacion_ObtenerRutas_PDF_XML_DocumentoExtanjero]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardarRutaFacturaDocumentosExternos(ByVal DocumentoID As Integer, ByVal RutaPDF As String, ByVal RutaXML As String) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@DocumentoID"
            parametro.Value = DocumentoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaPDF"
            parametro.Value = RutaPDF
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaXML"
            parametro.Value = RutaXML
            listaParametros.Add(parametro)

            Return ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_AdministradorOT_GuardarRutaFacturaDocumentosExternos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EnviarRefacturar(ByVal idRemision As Integer, ByVal anio As Int16)
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@RemisionID"
            parametro.Value = idRemision
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AñoID"
            parametro.Value = anio
            listaParametros.Add(parametro)

            ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_NotaCredito_CambiarStatusOT]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerArchivosXMLSAP(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal documentosSeleccionados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@DocumentosSeleccionados", documentosSeleccionados)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Facturacion].[SP_FacturacionSAP_GenerarXmlReplicas]", listaParametros)
    End Function
    Public Function actualizaSaldosSicySay()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutaConsulta("[Ventas].[SP_FacturacionCalzado_ActualizarSaldos_SICY_SAY]")
    End Function

    Public Function ObtenerPermisoCancelacion(ByVal documentoid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Documentoid", documentoid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ObtenerPermisoCancelacion]", listaParametros)
    End Function

    Public Function ConsultarSolicitud(ByVal documentoid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Documentoid", documentoid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_CancelacionFactura_ConsultarSolicitud]", listaParametros)
    End Function
End Class
