Imports System.Data.SqlClient
Imports Persistencia
Public Class ReciboNominaDA
    Public Function obtenerEstatusRecibosNomina() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC Contabilidad.SP_NFTimbrado_ObtenerListaEstatus"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultarListaRecibosNomina(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal filtroTimbrado As Boolean,
                                                ByVal timbrado As Boolean, ByVal periodoId As Integer, ByVal rango As Boolean,
                                                ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal tipo As String,
                                                ByVal colaboradorIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        If estatusId > 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "estatusId"
            parametro.Value = estatusId
            listaParametros.Add(parametro)
        End If

        If filtroTimbrado Then
            parametro = New SqlParameter
            parametro.ParameterName = "timbrado"
            parametro.Value = timbrado
            listaParametros.Add(parametro)
        End If

        If periodoId > 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "periodoId"
            parametro.Value = periodoId
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "rango"
        parametro.Value = rango
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        If tipo <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "tipo"
            parametro.Value = tipo
            listaParametros.Add(parametro)
        End If

        If colaboradorIds <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "colaboradorIds"
            parametro.Value = colaboradorIds
            listaParametros.Add(parametro)
        End If

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarListaRecibosNomina", listaParametros)
    End Function

    Public Function consultarRecibosTimbrados(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal filtroTimbrado As Boolean,
                                              ByVal timbrado As Boolean, ByVal periodoId As Integer, ByVal rango As Boolean,
                                              ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal tipo As String,
                                              ByVal colaboradorIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        If estatusId > 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "estatusId"
            parametro.Value = estatusId
            listaParametros.Add(parametro)
        End If

        If filtroTimbrado Then
            parametro = New SqlParameter
            parametro.ParameterName = "timbrado"
            parametro.Value = timbrado
            listaParametros.Add(parametro)
        End If

        If periodoId > 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "periodoId"
            parametro.Value = periodoId
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "rango"
        parametro.Value = rango
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        If tipo <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "tipo"
            parametro.Value = tipo
            listaParametros.Add(parametro)
        End If

        If colaboradorIds <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "colaboradorIds"
            parametro.Value = colaboradorIds
            listaParametros.Add(parametro)
        End If

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarRecibosTimbrados", listaParametros)
    End Function

    Public Function validarEstatus(ByVal timNominaId As Integer, ByVal opcAccion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcAccion"
        parametro.Value = opcAccion
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ValidarEstatus", listaParametros)
    End Function

    Public Function consultarDatosEmpresa(ByVal patronId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarDatosEmpresa", listaParametros)
    End Function

    Public Function consultarInformacionRecibo(ByVal timNominaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarInformacionRecibo", listaParametros)
    End Function

    Public Function consultarInformacionTimbrarPercepciones(ByVal timNominaId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarInformacionTimbrarPercepciones", listaParametros)
    End Function

    Public Function consultarInformacionTimbrarDeducciones(ByVal timNominaId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarInformacionTimbrarDeducciones", listaParametros)
    End Function

    Public Function consultarInformacionTimbrarOtrosPagos(ByVal timNominaId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarInformacionTimbrarOtrosPagos", listaParametros)
    End Function

    Public Function consultarInformacionTimbrarIncapacidades(ByVal timNominaId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarInformacionTimbrarIncapacidades", listaParametros)
    End Function

    Public Function consultarInformacionTimbrarHorasExtra(ByVal timNominaId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarInformacionTimbrarHorasExtra", listaParametros)
    End Function

    Public Function actualizarInformacionTimbrado(ByVal tmbNominafiscal As Entidades.TimbreNominaFiscal) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = tmbNominafiscal.TNFTimbreNominaFiscalId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sello"
        parametro.Value = tmbNominafiscal.TNFSello
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "certificado"
        parametro.Value = tmbNominafiscal.TNFCertificado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "uuid"
        parametro.Value = tmbNominafiscal.TNFUuid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaTimbrado"
        parametro.Value = tmbNominafiscal.TNFFechaTimbrado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noCertificadoSAT"
        parametro.Value = tmbNominafiscal.TNFNoCertificadoSAT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "selloSAT"
        parametro.Value = tmbNominafiscal.TNFSelloSAT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cadenaOriginal"
        parametro.Value = tmbNominafiscal.TNFCadenaOriginal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cadenaOriginalComplemento"
        parametro.Value = tmbNominafiscal.TNFCadenaOriginalComplemento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioTimbroId"
        parametro.Value = tmbNominafiscal.TNFUsuarioTimbroId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "xml"
        'parametro.Value = tmbNominafiscal.TNFXml
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "pdf"
        'parametro.Value = tmbNominafiscal.TNFPdf
        'listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ActualizarInformacionTimbrado", listaParametros)
    End Function

    Public Function actualizarCancelacionTimbrado(ByVal tmbNominafiscal As Entidades.TimbreNominaFiscal) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = tmbNominafiscal.TNFTimbreNominaFiscalId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "uuidCancelacion"
        parametro.Value = tmbNominafiscal.TNFUuidCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCancelacion"
        parametro.Value = tmbNominafiscal.TNFFechaCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCancelo"
        parametro.Value = tmbNominafiscal.TNFUsuarioCancelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoCancelacion"
        parametro.Value = tmbNominafiscal.TNFMotivoCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "xmlCancelacion"
        parametro.Value = tmbNominafiscal.TNFXmlCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pdfCancelacion"
        parametro.Value = tmbNominafiscal.TNFPdfCancelacion
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ActualizarCancelacionTimbrado", listaParametros)
    End Function

    Public Function actualizarMotivoSinTimbrar(ByVal timNominaId As Integer, ByVal motivoSinTimbrar As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "motivoSinTimbrar"
        parametro.Value = motivoSinTimbrar
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ActualizarMotivoSinTimbrar", listaParametros)
    End Function

    Public Function consultarInformacionTimbrarCfdiRelacionados(ByVal timNominaId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ConsultarInformacionTimbrarCfdiRelacionados", listaParametros)
    End Function

    Public Function actualizarRutaPdfCancelacion(ByVal timNominaId As Integer, ByVal rutaPdf As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "timNominaId"
        parametro.Value = timNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pdfCancelacion"
        parametro.Value = rutaPdf
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ActualizarRutaPdfCancelacion", listaParametros)
    End Function

    Public Function validaDiferenciasTimbradoNomina(ByVal patronId As Integer, ByVal periodoId As Integer,
                                                    ByVal rango As Boolean, ByVal fechaInicio As Date,
                                                    ByVal fechaFin As Date, ByVal tipo As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rango"
        parametro.Value = rango
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        If tipo <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "@tipo"
            parametro.Value = tipo
            listaParametros.Add(parametro)
        End If

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFTimbrado_ValidarTimbradoNomina", listaParametros)
    End Function
End Class