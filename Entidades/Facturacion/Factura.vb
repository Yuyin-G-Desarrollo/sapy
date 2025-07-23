Public Class Factura

#Region "Factura"
    Private mensaje As String
    Public Property FMensaje() As String
        Get
            Return mensaje
        End Get
        Set(ByVal value As String)
            mensaje = value
        End Set
    End Property

    Private idFact As Integer
    Public Property FIdFact() As Integer
        Get
            Return idFact
        End Get
        Set(ByVal value As Integer)
            idFact = value
        End Set
    End Property

    Private idSucu As Integer
    Public Property FIdSucu() As Integer
        Get
            Return idSucu
        End Get
        Set(ByVal value As Integer)
            idSucu = value
        End Set
    End Property

    Private idEmp As Integer
    Public Property FIdEmp() As Integer
        Get
            Return idEmp
        End Get
        Set(ByVal value As Integer)
            idEmp = value
        End Set
    End Property

    Private idUser As Integer
    Public Property FIdUser() As Integer
        Get
            Return idUser
        End Get
        Set(ByVal value As Integer)
            idUser = value
        End Set
    End Property

    Private idCte As Integer
    Public Property FIdCte() As Integer
        Get
            Return idCte
        End Get
        Set(ByVal value As Integer)
            idCte = value
        End Set
    End Property

    Private cadenaOriginal As String
    Public Property FCadenaOriginal() As String
        Get
            Return cadenaOriginal
        End Get
        Set(ByVal value As String)
            cadenaOriginal = value
        End Set
    End Property

    Private cadenaOriginalSAT As String
    Public Property FCadenaOriginalSAT() As String
        Get
            Return cadenaOriginalSAT
        End Get
        Set(ByVal value As String)
            cadenaOriginalSAT = value
        End Set
    End Property

    Private xml As String
    Public Property FXml() As String
        Get
            Return xml
        End Get
        Set(ByVal value As String)
            xml = value
        End Set
    End Property

    Private pdf As String
    Public Property FPdf() As String
        Get
            Return pdf
        End Get
        Set(ByVal value As String)
            pdf = value
        End Set
    End Property

    Private estatus As String
    Public Property FEstatus() As String
        Get
            Return estatus
        End Get
        Set(ByVal value As String)
            estatus = value
        End Set
    End Property

    Private imprimeSucursal As Boolean
    Public Property FImprimeSucursal() As Boolean
        Get
            Return imprimeSucursal
        End Get
        Set(ByVal value As Boolean)
            imprimeSucursal = value
        End Set
    End Property

    Private reporteId As Integer
    Public Property FReporteId() As Integer
        Get
            Return reporteId
        End Get
        Set(ByVal value As Integer)
            reporteId = value
        End Set
    End Property

    Private observacion As String
    Public Property FObservacion() As String
        Get
            Return observacion
        End Get
        Set(ByVal value As String)
            observacion = value
        End Set
    End Property

#End Region


#Region "Cancelacion"
    Private uuidCancelacion As String
    Public Property FUuidCancelacion() As String
        Get
            Return uuidCancelacion
        End Get
        Set(ByVal value As String)
            uuidCancelacion = value
        End Set
    End Property

    Private fechaCancelacion As String
    Public Property FFechaCancelacion() As String
        Get
            Return fechaCancelacion
        End Get
        Set(ByVal value As String)
            fechaCancelacion = value
        End Set
    End Property

    Private idUserCancelacion As Integer
    Public Property FIdUserCancelacion() As Integer
        Get
            Return idUserCancelacion
        End Get
        Set(ByVal value As Integer)
            idUserCancelacion = value
        End Set
    End Property

    Private xmlCancelacion As String
    Public Property FXmlCancelacion() As String
        Get
            Return xmlCancelacion
        End Get
        Set(ByVal value As String)
            xmlCancelacion = value
        End Set
    End Property

    Private pdfCancelacion As String
    Public Property FPdfCancelacion() As String
        Get
            Return pdfCancelacion
        End Get
        Set(ByVal value As String)
            pdfCancelacion = value
        End Set
    End Property

    Private reporteCancId As Integer
    Public Property FReporteCancId() As Integer
        Get
            Return reporteCancId
        End Get
        Set(ByVal value As Integer)
            reporteCancId = value
        End Set
    End Property

    Private motivoCancelacion As String
    Public Property FMotivoCancelacion() As String
        Get
            Return motivoCancelacion
        End Get
        Set(ByVal value As String)
            motivoCancelacion = value
        End Set
    End Property


#End Region


#Region "Comprobante"
    Private version As String
    Public Property FVersion() As String
        Get
            Return version
        End Get
        Set(ByVal value As String)
            version = value
        End Set
    End Property

    Private serie As String
    Public Property FSerie() As String
        Get
            Return serie
        End Get
        Set(ByVal value As String)
            serie = value
        End Set
    End Property

    Private folio As Integer
    Public Property FFolio() As Integer
        Get
            Return folio
        End Get
        Set(ByVal value As Integer)
            folio = value
        End Set
    End Property

    Private fechaExpedicion As String
    Public Property FFechaExpedicion() As String
        Get
            Return fechaExpedicion
        End Get
        Set(ByVal value As String)
            fechaExpedicion = value
        End Set
    End Property

    Private sello As String
    Public Property FSello() As String
        Get
            Return sello
        End Get
        Set(ByVal value As String)
            sello = value
        End Set
    End Property

    Private formaDePago As String
    Public Property FFormaDePago() As String
        Get
            Return formaDePago
        End Get
        Set(ByVal value As String)
            formaDePago = value
        End Set
    End Property

    Private noCertificado As String
    Public Property FNoCertificado() As String
        Get
            Return noCertificado
        End Get
        Set(ByVal value As String)
            noCertificado = value
        End Set
    End Property

    Private ceritficado As String
    Public Property FCertificado() As String
        Get
            Return ceritficado
        End Get
        Set(ByVal value As String)
            ceritficado = value
        End Set
    End Property

    Private condicionesPago As String
    Public Property FCondicionesPago() As String
        Get
            Return condicionesPago
        End Get
        Set(ByVal value As String)
            condicionesPago = value
        End Set
    End Property

    Private moneda As String
    Public Property FMoneda() As String
        Get
            Return moneda
        End Get
        Set(ByVal value As String)
            moneda = value
        End Set
    End Property


    Private subtotal As Double
    Public Property FSubtotal() As Double
        Get
            Return subtotal
        End Get
        Set(ByVal value As Double)
            subtotal = value
        End Set
    End Property

    Private total As Double
    Public Property FTotal() As Double
        Get
            Return total
        End Get
        Set(ByVal value As Double)
            total = value
        End Set
    End Property

    Private descuento As Double
    Public Property FDescuento() As Double
        Get
            Return descuento
        End Get
        Set(ByVal value As Double)
            descuento = value
        End Set
    End Property

    Private motivoDescuento As String
    Public Property FMotivoDescuento() As String
        Get
            Return motivoDescuento
        End Get
        Set(ByVal value As String)
            motivoDescuento = value
        End Set
    End Property

    Private tipoComprobante As String
    Public Property FTipoComprobante() As String
        Get
            Return tipoComprobante
        End Get
        Set(ByVal value As String)
            tipoComprobante = value
        End Set
    End Property

    Private metodoPago As String
    Public Property FMetodoPago() As String
        Get
            Return metodoPago
        End Get
        Set(ByVal value As String)
            metodoPago = value
        End Set
    End Property

    Private idMetodoPago As Integer
    Public Property FIdMetodoPago() As Integer
        Get
            Return idMetodoPago
        End Get
        Set(ByVal value As Integer)
            idMetodoPago = value
        End Set
    End Property

    Private claveMetodoPago As String
    Public Property FClaveMetodoPago() As String
        Get
            Return claveMetodoPago
        End Get
        Set(ByVal value As String)
            claveMetodoPago = value
        End Set
    End Property


    Private lugarExpedicion As String
    Public Property FLugarExpedicion() As String
        Get
            Return lugarExpedicion
        End Get
        Set(ByVal value As String)
            lugarExpedicion = value
        End Set
    End Property

#End Region


#Region "Emisor"
    Private emisorRfc As String
    Public Property FEmisorRfc() As String
        Get
            Return emisorRfc
        End Get
        Set(ByVal value As String)
            emisorRfc = value
        End Set
    End Property

    Private emisorNombre As String
    Public Property FEmisorNombre() As String
        Get
            Return emisorNombre
        End Get
        Set(ByVal value As String)
            emisorNombre = value
        End Set
    End Property

    Private emisorRegimen As String
    Public Property FEmisorRegimen() As String
        Get
            Return emisorRegimen
        End Get
        Set(ByVal value As String)
            emisorRegimen = value
        End Set
    End Property

    Private emisorCalle As String
    Public Property FEmisorCalle() As String
        Get
            Return emisorCalle
        End Get
        Set(ByVal value As String)
            emisorCalle = value
        End Set
    End Property

    Private emisorNoExterior As String
    Public Property FEmisorNoExterior() As String
        Get
            Return emisorNoExterior
        End Get
        Set(ByVal value As String)
            emisorNoExterior = value
        End Set
    End Property

    Private emisorColonia As String
    Public Property FEmisorColonia() As String
        Get
            Return emisorColonia
        End Get
        Set(ByVal value As String)
            emisorColonia = value
        End Set
    End Property

    Private emisorMunicipio As String
    Public Property FEmisorMunicipio() As String
        Get
            Return emisorMunicipio
        End Get
        Set(ByVal value As String)
            emisorMunicipio = value
        End Set
    End Property

    Private emisorEstado As String
    Public Property FEmisorEstado() As String
        Get
            Return emisorEstado
        End Get
        Set(ByVal value As String)
            emisorEstado = value
        End Set
    End Property

    Private emisorPais As String
    Public Property FEmisorPais() As String
        Get
            Return emisorPais
        End Get
        Set(ByVal value As String)
            emisorPais = value
        End Set
    End Property

    Private emisorCp As String
    Public Property FEmisorCp() As String
        Get
            Return emisorCp
        End Get
        Set(ByVal value As String)
            emisorCp = value
        End Set
    End Property


#Region "Expedido"
    Private expedidoCalle As String
    Public Property FExpedidoCalle() As String
        Get
            Return expedidoCalle
        End Get
        Set(ByVal value As String)
            expedidoCalle = value
        End Set
    End Property

    Private expedidoNoExterior As String
    Public Property FExpedidoNoExterior() As String
        Get
            Return expedidoNoExterior
        End Get
        Set(ByVal value As String)
            expedidoNoExterior = value
        End Set
    End Property

    Private expedidoColonia As String
    Public Property FExpedidoColonia() As String
        Get
            Return expedidoColonia
        End Get
        Set(ByVal value As String)
            expedidoColonia = value
        End Set
    End Property

    Private expedidoMunicipio As String
    Public Property FExpedidoMunicipio() As String
        Get
            Return expedidoMunicipio
        End Get
        Set(ByVal value As String)
            expedidoMunicipio = value
        End Set
    End Property

    Private expedidoEstado As String
    Public Property FExpedidoEstado() As String
        Get
            Return expedidoEstado
        End Get
        Set(ByVal value As String)
            expedidoEstado = value
        End Set
    End Property

    Private expedidoPais As String
    Public Property FExpedidoPais() As String
        Get
            Return expedidoPais
        End Get
        Set(ByVal value As String)
            expedidoPais = value
        End Set
    End Property

    Private expedidoCp As String
    Public Property FExpedidoCp() As String
        Get
            Return expedidoCp
        End Get
        Set(ByVal value As String)
            expedidoCp = value
        End Set
    End Property
#End Region
#End Region


#Region "Receptor"
    Private receptorRfc As String
    Public Property FReceptorRfc() As String
        Get
            Return receptorRfc
        End Get
        Set(ByVal value As String)
            receptorRfc = value
        End Set
    End Property

    Private receptorNombre As String
    Public Property FReceptorNombre() As String
        Get
            Return receptorNombre
        End Get
        Set(ByVal value As String)
            receptorNombre = value
        End Set
    End Property

    Private receptorCalle As String
    Public Property FReceptorCalle() As String
        Get
            Return receptorCalle
        End Get
        Set(ByVal value As String)
            receptorCalle = value
        End Set
    End Property

    Private receptorNoExterior As String
    Public Property FReceptorNoExterior() As String
        Get
            Return receptorNoExterior
        End Get
        Set(ByVal value As String)
            receptorNoExterior = value
        End Set
    End Property

    Private receptorColonia As String
    Public Property FReceptorColonia() As String
        Get
            Return receptorColonia
        End Get
        Set(ByVal value As String)
            receptorColonia = value
        End Set
    End Property

    Private receptorMunicipio As String
    Public Property FReceptorMunicipio() As String
        Get
            Return receptorMunicipio
        End Get
        Set(ByVal value As String)
            receptorMunicipio = value
        End Set
    End Property

    Private receptorEstado As String
    Public Property FReceptorEstado() As String
        Get
            Return receptorEstado
        End Get
        Set(ByVal value As String)
            receptorEstado = value
        End Set
    End Property

    Private receptorPais As String
    Public Property FReceptorPais() As String
        Get
            Return receptorPais
        End Get
        Set(ByVal value As String)
            receptorPais = value
        End Set
    End Property

    Private receptorCp As String
    Public Property FReceptorCp() As String
        Get
            Return receptorCp
        End Get
        Set(ByVal value As String)
            receptorCp = value
        End Set
    End Property
#End Region


#Region "Impuestos"
    Private totalImpuestosRetenidos As Double
    Public Property FTotalImpuestosRetenidos() As Double
        Get
            Return totalImpuestosRetenidos
        End Get
        Set(ByVal value As Double)
            totalImpuestosRetenidos = value
        End Set
    End Property

    Private totalImpuestosTrasladados As Double
    Public Property FTotalImpuestosTrasladados() As Double
        Get
            Return totalImpuestosTrasladados
        End Get
        Set(ByVal value As Double)
            totalImpuestosTrasladados = value
        End Set
    End Property

    Private impuesto As String
    Public Property FImpuesto() As String
        Get
            Return impuesto
        End Get
        Set(ByVal value As String)
            impuesto = value
        End Set
    End Property

    Private tasa As Double
    Public Property FTasa() As Double
        Get
            Return tasa
        End Get
        Set(ByVal value As Double)
            tasa = value
        End Set
    End Property

    Private impuestoTrasladadoImporte As Double
    Public Property FImpuestoTrasladadoImporte() As Double
        Get
            Return impuestoTrasladadoImporte
        End Get
        Set(ByVal value As Double)
            impuestoTrasladadoImporte = value
        End Set
    End Property
#End Region

#Region "Complemento"
    Private uuid As String
    Public Property FUuid() As String
        Get
            Return uuid
        End Get
        Set(ByVal value As String)
            uuid = value
        End Set
    End Property

    Private fechaTimbrado As String
    Public Property FFechaTimbrado() As String
        Get
            Return fechaTimbrado
        End Get
        Set(ByVal value As String)
            fechaTimbrado = value
        End Set
    End Property

    Private selloCFD As String
    Public Property FSelloCFD() As String
        Get
            Return selloCFD
        End Get
        Set(ByVal value As String)
            selloCFD = value
        End Set
    End Property

    Private noCertificadoSAT As String
    Public Property FNoCertificadoSAT() As String
        Get
            Return noCertificadoSAT
        End Get
        Set(ByVal value As String)
            noCertificadoSAT = value
        End Set
    End Property

    Private selloSat As String
    Public Property FSelloSat() As String
        Get
            Return selloSat
        End Get
        Set(ByVal value As String)
            selloSat = value
        End Set
    End Property

#End Region
End Class