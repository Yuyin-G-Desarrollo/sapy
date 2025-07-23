Imports System.Data.SqlClient

Public Class AdmonDoctosComprasPT_DA
    Public Function ObtenerEstatusFacturacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Proveedor.SP_ConsultarEstatusFacturacionPTI")
    End Function

    Public Function ObtenerEmisorFacturacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Proveedor.SP_ConsultarEmpresaReceptora")
    End Function

    Public Function ObtenerReceptorFacturacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Proveedor.SP_ConsultarEmpresaEmisora")
    End Function

    Public Function ObtenerDocumentos(ByVal porFFacturacion As Boolean, ByVal porFCancelacion As Boolean, ByVal porFIngreso As Boolean,
                                      ByVal fechaInicio As Date, ByVal fechaFin As Date,
                                      ByVal estatusIds As String, ByVal DocumentosIds As String, ByVal folios As String,
                                      ByVal emisorIds As String, ByVal receptorIds As String, ByVal articuloIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "PorFechaFacturacion",
            .Value = porFFacturacion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "PorFechaCancelacion",
            .Value = porFCancelacion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "PorFechaIngreso",
            .Value = porFIngreso
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "FechaInicio",
            .Value = fechaInicio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "FechaFin",
            .Value = fechaFin
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "EstatusIds",
            .Value = estatusIds
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "DocumentosIds",
            .Value = DocumentosIds
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Folios",
            .Value = folios
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "EmisorIds",
            .Value = emisorIds
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "ReceptorIds",
            .Value = receptorIds
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "ArticuloIds",
            .Value = articuloIds
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ObtenerDocumentos", listaParametros)
    End Function

    Public Function ObtenerDetallesDocumentos(ByVal documentosIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "DocumentosIds",
            .Value = documentosIds
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ObtenerDetallesDocumentos", listaParametros)
    End Function

    Public Function ActualizarMtvoSinTimbrarFacturaPIDocumento(ByVal idDocumento As Integer, ByVal motivo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "IdDocumento",
            .Value = idDocumento
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Motivo",
            .Value = motivo
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ActualizarMtvoSinTimbrarFacturaPIDocumento", listaParametros)
    End Function

    Public Function ActualizarInfoFacturaPIDocumento(ByVal idDocumento As Integer, ByVal sello As String,
                                                     ByVal uuid As String, ByVal fechaTimbrado As String,
                                                     ByVal versionSat As String, ByVal rfcProvCertif As String,
                                                     ByVal noCertificadoSAT As String, ByVal selloSAT As String,
                                                     ByVal cadenaOriginal As String, ByVal cadenaOriginalComplemento As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "IdDocumento",
            .Value = idDocumento
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Sello",
            .Value = sello
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Uuid",
            .Value = uuid
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "UsuarioTimbroId",
            .Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "FechaTimbrado",
            .Value = fechaTimbrado
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "VersionSat",
            .Value = versionSat
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "RfcProvCertif",
            .Value = rfcProvCertif
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "NoCertificadoSAT",
            .Value = noCertificadoSAT
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "SelloSAT",
            .Value = selloSAT
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "CadenaOriginal",
            .Value = cadenaOriginal
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "CadenaOriginalComplemento",
            .Value = cadenaOriginalComplemento
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ActualizarInfoFacturaPIDocumento", listaParametros)
    End Function

    Public Function ObtenerInfoCXPSaldo(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "IdDocumento",
            .Value = idDocumento
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ObtenerInfoCXPSaldo", listaParametros)
    End Function

    Public Function InsertarCXPSaldo(ByVal tipoDoc As Integer, ByVal idProveedor As Integer, ByVal numDoc As String,
                                     ByVal fechaDoc As Date, ByVal fechaVencimiento As Date, ByVal semanaPago As Integer,
                                     ByVal semanaPagada As Integer, ByVal subTotal As Double, ByVal iva As Double,
                                     ByVal total As Double, ByVal totalDoc As Double, ByVal moneda As Integer,
                                     ByVal nave As Integer, ByVal añoSemPago As Integer, ByVal rfcContribuyente As String,
                                     ByVal rfcProveedor As String, ByVal giro As String, ByVal idcomprobantesicy As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "tipoDoc",
            .Value = tipoDoc
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "idProveedor",
            .Value = idProveedor
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "numDoc",
            .Value = numDoc
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "fechaDoc",
            .Value = fechaDoc
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "fechaVencimiento",
            .Value = fechaVencimiento
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "semanaPago",
            .Value = semanaPago
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "semanaPagada",
            .Value = semanaPagada
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "subTotal",
            .Value = subTotal
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "iva",
            .Value = iva
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "total",
            .Value = total
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "totalDoc",
            .Value = totalDoc
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "moneda",
            .Value = moneda
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "nave",
            .Value = nave
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "añoSemPago",
            .Value = añoSemPago
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "usuario",
            .Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "rfcContribuyente",
            .Value = rfcContribuyente
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "rfcProveedor",
            .Value = rfcProveedor
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "giro",
            .Value = giro
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "idcomprobantesicy",
            .Value = idcomprobantesicy
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedores.SP_InsertcxpSaldoscxpMovimientosOrdenCompra", listaParametros)
    End Function

    Public Function ValidarCuentaPorPagar(ByVal folio As String, ByVal fecha As Date, ByVal total As Double) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "numDoc",
            .Value = folio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "fechaDoc",
            .Value = fecha
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "total",
            .Value = total
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedores.SP_ComprasPT_ValidaCuentaPorPagar", listaParametros)
    End Function

    Public Function ConsultarPerfilSistemas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "usuarioId",
            .Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        }
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Framework.SP_ValidarPerfilSistemas", listaParametros)
    End Function

    Public Function ObtenerIdComprobanteCFD(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "IdDocumento",
            .Value = idDocumento
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ObtenerIdComprobanteCFD", listaParametros)
    End Function

    Public Function existeTimbradoComplemento(ByVal DocumentoId As Integer, ByVal TipoComprobante As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@DocumentoId", DocumentoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoComprobante", TipoComprobante)
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_existeTimbradoComplemento", listaParametros)
    End Function

    Public Function actualizaNombreDocumento(ByVal DocumentoId As Integer, ByVal TipoComprobante As String, ByVal TipoDocumento As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@DocumentoId", DocumentoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoComprobante", TipoComprobante)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoDocumento", TipoDocumento)
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_actualizaNombreArchivoRegenerado", listaParametros)
    End Function

End Class
