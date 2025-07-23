Public Class TimbreNominaFiscal
#Region "Comprobante"
    Private version As String
    Public Property TNFVersion() As String
        Get
            Return version
        End Get
        Set(ByVal value As String)
            version = value
        End Set
    End Property

    Private serie As String
    Public Property TNFSerie() As String
        Get
            Return serie
        End Get
        Set(ByVal value As String)
            serie = value
        End Set
    End Property

    Private folio As Integer
    Public Property TNFFolio() As Integer
        Get
            Return folio
        End Get
        Set(ByVal value As Integer)
            folio = value
        End Set
    End Property

    Private fecha As Date
    Public Property TNFFecha() As Date
        Get
            Return fecha
        End Get
        Set(ByVal value As Date)
            fecha = value
        End Set
    End Property

    Private sello As String
    Public Property TNFSello() As String
        Get
            Return sello
        End Get
        Set(ByVal value As String)
            sello = value
        End Set
    End Property

    Private formaPago As String
    Public Property TNFFormaPago() As String
        Get
            Return formaPago
        End Get
        Set(ByVal value As String)
            formaPago = value
        End Set
    End Property

    Private noCertificado As String
    Public Property TNFNoCertificado() As String
        Get
            Return noCertificado
        End Get
        Set(ByVal value As String)
            noCertificado = value
        End Set
    End Property

    Private certificado As String
    Public Property TNFCertificado() As String
        Get
            Return certificado
        End Get
        Set(ByVal value As String)
            certificado = value
        End Set
    End Property

    Private subTotal As Double
    Public Property TNFSubTotal() As Double
        Get
            Return subTotal
        End Get
        Set(ByVal value As Double)
            subTotal = value
        End Set
    End Property

    Private descuento As Double
    Public Property TNFDescuento() As Double
        Get
            Return descuento
        End Get
        Set(ByVal value As Double)
            descuento = value
        End Set
    End Property

    Private moneda As String
    Public Property TNFMoneda() As String
        Get
            Return moneda
        End Get
        Set(ByVal value As String)
            moneda = value
        End Set
    End Property

    Private total As Double
    Public Property TNFTotal() As Double
        Get
            Return total
        End Get
        Set(ByVal value As Double)
            total = value
        End Set
    End Property

    Private tipoDeComprobante As String
    Public Property TNFTipoDeComprobante() As String
        Get
            Return tipoDeComprobante
        End Get
        Set(ByVal value As String)
            tipoDeComprobante = value
        End Set
    End Property

    Private metodoDePago As String
    Public Property TNFMetodoDePago() As String
        Get
            Return metodoDePago
        End Get
        Set(ByVal value As String)
            metodoDePago = value
        End Set
    End Property

    Private lugarExpedicion As String
    Public Property TNFLugarExpedicion() As String
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
    Public Property TNFEmisorRfc() As String
        Get
            Return emisorRfc
        End Get
        Set(ByVal value As String)
            emisorRfc = value
        End Set
    End Property

    Private emisorRazonSocial As String
    Public Property TNFEmisorRazonSocial() As String
        Get
            Return emisorRazonSocial
        End Get
        Set(ByVal value As String)
            emisorRazonSocial = value
        End Set
    End Property

    Private emisorRegimen As String
    Public Property TNFEmisorRegimen() As String
        Get
            Return emisorRegimen
        End Get
        Set(ByVal value As String)
            emisorRegimen = value
        End Set
    End Property
#End Region

#Region "Receptor"
    Private receptorRfc As String
    Public Property TNFReceptorRfc() As String
        Get
            Return receptorRfc
        End Get
        Set(ByVal value As String)
            receptorRfc = value
        End Set
    End Property

    Private receptorNombre As String
    Public Property TNFReceptorNombre() As String
        Get
            Return receptorNombre
        End Get
        Set(ByVal value As String)
            receptorNombre = value
        End Set
    End Property

    Private usoCfdi As String
    Public Property TNFUsoCfdi() As String
        Get
            Return usoCfdi
        End Get
        Set(ByVal value As String)
            usoCfdi = value
        End Set
    End Property
#End Region

#Region "Conceptos"
    Private claveProdServ As String
    Public Property TNFClaveProdServ() As String
        Get
            Return claveProdServ
        End Get
        Set(ByVal value As String)
            claveProdServ = value
        End Set
    End Property

    Private cantidad As Integer
    Public Property TNFCantidad() As Integer
        Get
            Return cantidad
        End Get
        Set(ByVal value As Integer)
            cantidad = value
        End Set
    End Property

    Private unidad As String
    Public Property TNFUnidad() As String
        Get
            Return unidad
        End Get
        Set(ByVal value As String)
            unidad = value
        End Set
    End Property

    Private descripcion As String
    Public Property TNFDescripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private valorUnitario As Double
    Public Property TNFValorUnitario() As Double
        Get
            Return valorUnitario
        End Get
        Set(ByVal value As Double)
            valorUnitario = value
        End Set
    End Property

    Private importe As Double
    Public Property TNFImporte() As Double
        Get
            Return importe
        End Get
        Set(ByVal value As Double)
            importe = value
        End Set
    End Property

    Private conceptoDescuento As Double
    Public Property TNFConceptoDescuento() As Double
        Get
            Return conceptoDescuento
        End Get
        Set(ByVal value As Double)
            conceptoDescuento = value
        End Set
    End Property

#End Region

#Region "ComplementoNomina"
    Private versionNom As String
    Public Property TNFVersionNom() As String
        Get
            Return versionNom
        End Get
        Set(ByVal value As String)
            versionNom = value
        End Set
    End Property

    Private tipoNomina As String
    Public Property TNFTipoNomina() As String
        Get
            Return tipoNomina
        End Get
        Set(ByVal value As String)
            tipoNomina = value
        End Set
    End Property

    Private fechaPago As Date
    Public Property TNFFechaPago() As Date
        Get
            Return fechaPago
        End Get
        Set(ByVal value As Date)
            fechaPago = value
        End Set
    End Property

    Private fechaInicialPago As Date
    Public Property TNFFechaInicialPago() As Date
        Get
            Return fechaInicialPago
        End Get
        Set(ByVal value As Date)
            fechaInicialPago = value
        End Set
    End Property

    Private fechaFinalPago As Date
    Public Property TNFFechaFinalPago() As Date
        Get
            Return fechaFinalPago
        End Get
        Set(ByVal value As Date)
            fechaFinalPago = value
        End Set
    End Property

    Private numDiasPagados As Double
    Public Property TNFNumDiasPagados() As Double
        Get
            Return numDiasPagados
        End Get
        Set(ByVal value As Double)
            numDiasPagados = value
        End Set
    End Property

    Private totalPercepciones As Double
    Public Property TNFTotalPercepciones() As Double
        Get
            Return totalPercepciones
        End Get
        Set(ByVal value As Double)
            totalPercepciones = value
        End Set
    End Property

    Private totalDeducciones As Double
    Public Property TNFTotalDeducciones() As Double
        Get
            Return totalDeducciones
        End Get
        Set(ByVal value As Double)
            totalDeducciones = value
        End Set
    End Property

    Private totalOtrosPagos As Double
    Public Property TNFTotalOtrosPagos() As Double
        Get
            Return totalOtrosPagos
        End Get
        Set(ByVal value As Double)
            totalOtrosPagos = value
        End Set
    End Property
#End Region

#Region "ComplementoNomina/Emisor"
    Private emisorCurp As String
    Public Property TNFEmisorCurp() As String
        Get
            Return emisorCurp
        End Get
        Set(ByVal value As String)
            emisorCurp = value
        End Set
    End Property

    Private registroPatronal As String
    Public Property TNFRegistroPatronal() As String
        Get
            Return registroPatronal
        End Get
        Set(ByVal value As String)
            registroPatronal = value
        End Set
    End Property
#End Region

#Region "ComplementoNomina/Receptor"
    Private receptorCurp As String
    Public Property TNFReceptorCurp() As String
        Get
            Return receptorCurp
        End Get
        Set(ByVal value As String)
            receptorCurp = value
        End Set
    End Property

    Private receptorNumSeguridadSocial As String
    Public Property TNFReceptorNumSeguridadSocial() As String
        Get
            Return receptorNumSeguridadSocial
        End Get
        Set(ByVal value As String)
            receptorNumSeguridadSocial = value
        End Set
    End Property

    Private receptorFechaInicioRelLaboral As Date
    Public Property TNFReceptorFechaInicioRelLaboral() As Date
        Get
            Return receptorFechaInicioRelLaboral
        End Get
        Set(ByVal value As Date)
            receptorFechaInicioRelLaboral = value
        End Set
    End Property

    Private receptorAntiguedad As String
    Public Property TNFReceptorAntiguedad() As String
        Get
            Return receptorAntiguedad
        End Get
        Set(ByVal value As String)
            receptorAntiguedad = value
        End Set
    End Property

    Private receptorTipoContrato As String
    Public Property TNFReceptorTipoContrato() As String
        Get
            Return receptorTipoContrato
        End Get
        Set(ByVal value As String)
            receptorTipoContrato = value
        End Set
    End Property

    Private receptorTipoJornada As String
    Public Property TNFReceptorTipoJornada() As String
        Get
            Return receptorTipoJornada
        End Get
        Set(ByVal value As String)
            receptorTipoJornada = value
        End Set
    End Property

    Private receptorTipoRegimen As String
    Public Property TNFReceptorTipoRegimen() As String
        Get
            Return receptorTipoRegimen
        End Get
        Set(ByVal value As String)
            receptorTipoRegimen = value
        End Set
    End Property

    Private receptorNumEmpleado As String
    Public Property TNFReceptorNumEmpleado() As String
        Get
            Return receptorNumEmpleado
        End Get
        Set(ByVal value As String)
            receptorNumEmpleado = value
        End Set
    End Property

    Private receptorRiesgoPuesto As String
    Public Property TNFReceptorRiesgoPuesto() As String
        Get
            Return receptorRiesgoPuesto
        End Get
        Set(ByVal value As String)
            receptorRiesgoPuesto = value
        End Set
    End Property

    Private receptorPeriodicidadPago As String
    Public Property TNFReceptorPeriodicidadPago() As String
        Get
            Return receptorPeriodicidadPago
        End Get
        Set(ByVal value As String)
            receptorPeriodicidadPago = value
        End Set
    End Property

    Private receptorSalarioBaseCotApor As Double
    Public Property TNFReceptorSalarioBaseCotApor() As Double
        Get
            Return receptorSalarioBaseCotApor
        End Get
        Set(ByVal value As Double)
            receptorSalarioBaseCotApor = value
        End Set
    End Property

    Private receptorSalarioDiarioIntegrado As Double
    Public Property TNFReceptorSalarioDiarioIntegrado() As Double
        Get
            Return receptorSalarioDiarioIntegrado
        End Get
        Set(ByVal value As Double)
            receptorSalarioDiarioIntegrado = value
        End Set
    End Property

    Private receptorClaveEntFed As String
    Public Property TNFReceptorClaveEntFed() As String
        Get
            Return receptorClaveEntFed
        End Get
        Set(ByVal value As String)
            receptorClaveEntFed = value
        End Set
    End Property
#End Region

#Region "ComplementoNomina/Percepciones"
    Private totalSueldos As Double
    Public Property TNFTotalSueldos() As Double
        Get
            Return totalSueldos
        End Get
        Set(ByVal value As Double)
            totalSueldos = value
        End Set
    End Property

    Private percepcionesTotalGravado As Double
    Public Property TNFPercepcionesTotalGravado() As Double
        Get
            Return percepcionesTotalGravado
        End Get
        Set(ByVal value As Double)
            percepcionesTotalGravado = value
        End Set
    End Property

    Private percepcionesTotalExento As Double
    Public Property TNFPercepcionesTotalExento() As Double
        Get
            Return percepcionesTotalExento
        End Get
        Set(ByVal value As Double)
            percepcionesTotalExento = value
        End Set
    End Property
#End Region

#Region "ComplementoNomina/Deducciones"
    Private deduccionesTotalOtras As Double
    Public Property TNFDeduccionesTotalOtras() As Double
        Get
            Return deduccionesTotalOtras
        End Get
        Set(ByVal value As Double)
            deduccionesTotalOtras = value
        End Set
    End Property

    Private deduccionesTotalImpuestosRet As Double
    Public Property TNFDeduccionesTotalImpuestosRet() As Double
        Get
            Return deduccionesTotalImpuestosRet
        End Get
        Set(ByVal value As Double)
            deduccionesTotalImpuestosRet = value
        End Set
    End Property
#End Region

#Region "ComplementoTimbreFiscalDigital"
    Private uuid As String
    Public Property TNFUuid() As String
        Get
            Return uuid
        End Get
        Set(ByVal value As String)
            uuid = value
        End Set
    End Property

    Private fechaTimbrado As Date
    Public Property TNFFechaTimbrado() As Date
        Get
            Return fechaTimbrado
        End Get
        Set(ByVal value As Date)
            fechaTimbrado = value
        End Set
    End Property

    Private noCertificadoSAT As String
    Public Property TNFNoCertificadoSAT() As String
        Get
            Return noCertificadoSAT
        End Get
        Set(ByVal value As String)
            noCertificadoSAT = value
        End Set
    End Property

    Private selloSAT As String
    Public Property TNFSelloSAT() As String
        Get
            Return selloSAT
        End Get
        Set(ByVal value As String)
            selloSAT = value
        End Set
    End Property
#End Region

#Region "Cancelacion"
    Private uuidCancelacion As String
    Public Property TNFUuidCancelacion() As String
        Get
            Return uuidCancelacion
        End Get
        Set(ByVal value As String)
            uuidCancelacion = value
        End Set
    End Property

    Private fechaCancelacion As Date
    Public Property TNFFechaCancelacion() As Date
        Get
            Return fechaCancelacion
        End Get
        Set(ByVal value As Date)
            fechaCancelacion = value
        End Set
    End Property
#End Region

#Region "Otros"
    Private timbreNominaFiscalId As Integer
    Public Property TNFTimbreNominaFiscalId() As Integer
        Get
            Return timbreNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            timbreNominaFiscalId = value
        End Set
    End Property

    Private patronId As Integer
    Public Property TNFPatronId() As Integer
        Get
            Return patronId
        End Get
        Set(ByVal value As Integer)
            patronId = value
        End Set
    End Property

    Private nominaFiscalId As Integer
    Public Property TNFNominaFiscalId() As Integer
        Get
            Return nominaFiscalId
        End Get
        Set(ByVal value As Integer)
            nominaFiscalId = value
        End Set
    End Property

    Private bajaImssId As Integer
    Public Property TNFBajaImssId() As Integer
        Get
            Return bajaImssId
        End Get
        Set(ByVal value As Integer)
            bajaImssId = value
        End Set
    End Property

    Private periodoNominaFiscalId As Integer
    Public Property TNFPeriodoNominaFiscalId() As Integer
        Get
            Return periodoNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            periodoNominaFiscalId = value
        End Set
    End Property

    Private xml As String
    Public Property TNFXml() As String
        Get
            Return xml
        End Get
        Set(ByVal value As String)
            xml = value
        End Set
    End Property

    Private pdf As String
    Public Property TNFPdf() As String
        Get
            Return pdf
        End Get
        Set(ByVal value As String)
            pdf = value
        End Set
    End Property

    Private estatusId As Integer
    Public Property TNFEstatusId() As Integer
        Get
            Return estatusId
        End Get
        Set(ByVal value As Integer)
            estatusId = value
        End Set
    End Property

    Private tipo As String
    Public Property TNFTipo() As String
        Get
            Return tipo
        End Get
        Set(ByVal value As String)
            tipo = value
        End Set
    End Property

    Private timbrado As Boolean
    Public Property TNFTimbrado() As Boolean
        Get
            Return timbrado
        End Get
        Set(ByVal value As Boolean)
            timbrado = value
        End Set
    End Property

    Private usuarioCreoId As Integer
    Public Property TNFUsuarioCreoId() As Integer
        Get
            Return usuarioCreoId
        End Get
        Set(ByVal value As Integer)
            usuarioCreoId = value
        End Set
    End Property

    Private fechaCreacion As Date
    Public Property TNFFechaCreacion() As Date
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As Date)
            fechaCreacion = value
        End Set
    End Property

    Private emisorRegimenDescripcion As String
    Public Property TNFEmisorRegimenDescripcion() As String
        Get
            Return emisorRegimenDescripcion
        End Get
        Set(ByVal value As String)
            emisorRegimenDescripcion = value
        End Set
    End Property

    Private tipoJornadaPdf As String
    Public Property TNFTipoJornadaPdf() As String
        Get
            Return tipoJornadaPdf
        End Get
        Set(ByVal value As String)
            tipoJornadaPdf = value
        End Set
    End Property

    Private salario As String
    Public Property TNFSalario() As String
        Get
            Return salario
        End Get
        Set(ByVal value As String)
            salario = value
        End Set
    End Property

    Private tipoNominaPdf As String
    Public Property TNFTipoNominaPdf() As String
        Get
            Return tipoNominaPdf
        End Get
        Set(ByVal value As String)
            tipoNominaPdf = value
        End Set
    End Property

    Private tipoContratoPdf As String
    Public Property TNFTipoContratoPdf() As String
        Get
            Return tipoContratoPdf
        End Get
        Set(ByVal value As String)
            tipoContratoPdf = value
        End Set
    End Property

    Private tipoRegimenPdf As String
    Public Property TNFTipoRegimenPdf() As String
        Get
            Return tipoRegimenPdf
        End Get
        Set(ByVal value As String)
            tipoRegimenPdf = value
        End Set
    End Property

    Private periodicidadPagoPdf As String
    Public Property TNFPeriodicidadPagoPdf() As String
        Get
            Return periodicidadPagoPdf
        End Get
        Set(ByVal value As String)
            periodicidadPagoPdf = value
        End Set
    End Property

    Private usoCfdiPdf As String
    Public Property TNFUsoCfdiPdf() As String
        Get
            Return usoCfdiPdf
        End Get
        Set(ByVal value As String)
            usoCfdiPdf = value
        End Set
    End Property

    Private claveEntFedPdf As String
    Public Property TNFClaveEntFedPdf() As String
        Get
            Return claveEntFedPdf
        End Get
        Set(ByVal value As String)
            claveEntFedPdf = value
        End Set
    End Property

    Private formaPagoPdf As String
    Public Property TNFFormaPagoPdf() As String
        Get
            Return formaPagoPdf
        End Get
        Set(ByVal value As String)
            formaPagoPdf = value
        End Set
    End Property

    Private metodoPagoPdf As String
    Public Property TNFMetodoPagoPdf() As String
        Get
            Return metodoPagoPdf
        End Get
        Set(ByVal value As String)
            metodoPagoPdf = value
        End Set
    End Property

    Private tipoComprobantePdf As String
    Public Property TNFTipoComprobantePdf() As String
        Get
            Return tipoComprobantePdf
        End Get
        Set(ByVal value As String)
            tipoComprobantePdf = value
        End Set
    End Property

    Private xmlCancelacion As String
    Public Property TNFXmlCancelacion() As String
        Get
            Return xmlCancelacion
        End Get
        Set(ByVal value As String)
            xmlCancelacion = value
        End Set
    End Property

    Private pdfCancelacion As String
    Public Property TNFPdfCancelacion() As String
        Get
            Return pdfCancelacion
        End Get
        Set(ByVal value As String)
            pdfCancelacion = value
        End Set
    End Property

    Private usuarioCancelo As Integer
    Public Property TNFUsuarioCancelo() As Integer
        Get
            Return usuarioCancelo
        End Get
        Set(ByVal value As Integer)
            usuarioCancelo = value
        End Set
    End Property

    Private motivoCancelacion As String
    Public Property TNFMotivoCancelacion() As String
        Get
            Return motivoCancelacion
        End Get
        Set(ByVal value As String)
            motivoCancelacion = value
        End Set
    End Property

    Private mensajeError As String
    Public Property TNFMensajeError() As String
        Get
            Return mensajeError
        End Get
        Set(ByVal value As String)
            mensajeError = value
        End Set
    End Property

    Private cadenaOriginal As String
    Public Property TNFCadenaOriginal() As String
        Get
            Return cadenaOriginal
        End Get
        Set(ByVal value As String)
            cadenaOriginal = value
        End Set
    End Property

    Private cadenaOriginalComplemento As String
    Public Property TNFCadenaOriginalComplemento() As String
        Get
            Return cadenaOriginalComplemento
        End Get
        Set(ByVal value As String)
            cadenaOriginalComplemento = value
        End Set
    End Property

    Private cancelado As Boolean
    Public Property TNFCancelado() As Boolean
        Get
            Return cancelado
        End Get
        Set(ByVal value As Boolean)
            cancelado = value
        End Set
    End Property

    Private usuarioTimbroId As Integer
    Public Property TNFUsuarioTimbroId() As Integer
        Get
            Return usuarioTimbroId
        End Get
        Set(ByVal value As Integer)
            usuarioTimbroId = value
        End Set
    End Property
#End Region


#Region "ParaEliminar"
    Private numSemana As Integer
    Public Property TNFNumSemana() As Integer
        Get
            Return numSemana
        End Get
        Set(ByVal value As Integer)
            numSemana = value
        End Set
    End Property

    Private tipoCambio As String
    Public Property TNFTipoCambio() As String
        Get
            Return tipoCambio
        End Get
        Set(ByVal value As String)
            tipoCambio = value
        End Set
    End Property

    Private receptorDepartamento As String
    Public Property TNFReceptorDepartamento() As String
        Get
            Return receptorDepartamento
        End Get
        Set(ByVal value As String)
            receptorDepartamento = value
        End Set
    End Property

    Private receptorPuesto As String
    Public Property TNFReceptorPuesto() As String
        Get
            Return receptorPuesto
        End Get
        Set(ByVal value As String)
            receptorPuesto = value
        End Set
    End Property

    Private receptorBanco As String
    Public Property TNFReceptorBanco() As String
        Get
            Return receptorBanco
        End Get
        Set(ByVal value As String)
            receptorBanco = value
        End Set
    End Property

    Private receptorCuenta As String
    Public Property TNFReceptorCuenta() As String
        Get
            Return receptorCuenta
        End Get
        Set(ByVal value As String)
            receptorCuenta = value
        End Set
    End Property

    Private retenciones As Double
    Public Property TNFRetenciones() As Double
        Get
            Return retenciones
        End Get
        Set(ByVal value As Double)
            retenciones = value
        End Set
    End Property
#End Region
End Class
