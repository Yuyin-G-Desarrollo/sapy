Public Class NotasCreditoDevoluciones
    Private notacreditodevid As Integer
    Public Property NotaCreditoDevolucionId() As Integer
        Get
            Return notacreditodevid
        End Get
        Set(ByVal value As Integer)
            notacreditodevid = value
        End Set
    End Property
    Private concepto As String
    Public Property NotaCreditoConcepto() As String
        Get
            Return concepto
        End Get
        Set(ByVal value As String)
            concepto = value
        End Set
    End Property
    Private moneda As String
    Public Property NotaCreditoMoneda() As String
        Get
            Return moneda
        End Get
        Set(ByVal value As String)
            moneda = value
        End Set
    End Property
    Private monedaId As Integer
    Public Property NotaCreditoMonedaId() As Integer
        Get
            Return monedaId
        End Get
        Set(ByVal value As Integer)
            monedaId = value
        End Set
    End Property
    Private iva As Double
    Public Property NotaCreditoIva() As Double
        Get
            Return iva
        End Get
        Set(ByVal value As Double)
            iva = value
        End Set
    End Property
    Private Descuentocxc As Double
    Public Property NotaCreditoDescuentoCxc() As Double
        Get
            Return Descuentocxc
        End Get
        Set(ByVal value As Double)
            Descuentocxc = value
        End Set
    End Property
    Private razonsocial As String
    Public Property NotaCreditoRazonSocial() As String
        Get
            Return razonsocial
        End Get
        Set(ByVal value As String)
            razonsocial = value
        End Set
    End Property
    Private razonsocialId As Integer
    Public Property NotaCreditoRazSocialId() As Integer
        Get
            Return razonsocialId
        End Get
        Set(ByVal value As Integer)
            razonsocialId = value
        End Set
    End Property
    Private clienteId As Integer
    Public Property NotaCreditoClienteId() As Integer
        Get
            Return clienteId
        End Get
        Set(ByVal value As Integer)
            clienteId = value
        End Set
    End Property
    Private cliente As String
    Public Property NotaCreditoCliente() As String
        Get
            Return cliente
        End Get
        Set(ByVal value As String)
            cliente = value
        End Set
    End Property
    Private rfccliente As String
    Public Property NotaCreditoRFCCliente As String
        Get
            Return rfccliente
        End Get
        Set(ByVal value As String)
            rfccliente = value
        End Set
    End Property
    Private rfcClienteId As Integer
    Public Property NotaCreditoRFCClienteId() As Integer
        Get
            Return rfcClienteId
        End Get
        Set(ByVal value As Integer)
            rfcClienteId = value
        End Set
    End Property
    Private textoConcepto As String
    Public Property NotaCreditoTextoConcepto() As String
        Get
            Return textoConcepto
        End Get
        Set(ByVal value As String)
            textoConcepto = value
        End Set
    End Property
    Private tipoNotaCredito As String
    Public Property NotaCreditoTipo() As String
        Get
            Return tipoNotaCredito
        End Get
        Set(ByVal value As String)
            tipoNotaCredito = value
        End Set
    End Property
    Private anio As Integer
    Public Property NotaCreditoAnio() As Integer
        Get
            Return anio
        End Get
        Set(ByVal value As Integer)
            anio = value
        End Set
    End Property
    Private certificadoid As Integer
    Public Property NotaCreditoCertificadoId() As Integer
        Get
            Return certificadoid
        End Get
        Set(ByVal value As Integer)
            certificadoid = value
        End Set
    End Property
    Private serie As String
    Public Property NotaCreditoSerie() As String
        Get
            Return serie
        End Get
        Set(ByVal value As String)
            serie = value
        End Set
    End Property
    Private remisionId As Integer
    Public Property NotaCreditoRemisionId() As Integer
        Get
            Return remisionId
        End Get
        Set(ByVal value As Integer)
            remisionId = value
        End Set
    End Property
    Private precioDev As Decimal
    Public Property NotaCreditoPrecioDevolucion() As Decimal
        Get
            Return precioDev
        End Get
        Set(ByVal value As Decimal)
            precioDev = value
        End Set
    End Property
    Private pares As Integer
    Public Property NotaCreditoParesAplicar() As Integer
        Get
            Return pares
        End Get
        Set(ByVal value As Integer)
            pares = value
        End Set
    End Property
    Private folio As Integer
    Public Property NotaCreditoFolio() As Integer
        Get
            Return folio
        End Get
        Set(ByVal value As Integer)
            folio = value
        End Set
    End Property
    Private docuemento As String
    Public Property NotaCredtioDocumento() As String
        Get
            Return docuemento
        End Get
        Set(ByVal value As String)
            docuemento = value
        End Set
    End Property
    Private ncId As Integer
    Public Property NotaCreditoId() As Integer
        Get
            Return ncId
        End Get
        Set(ByVal value As Integer)
            ncId = value
        End Set
    End Property
    Private sesionId As Integer
    Public Property NotaCreditoSesionId() As Integer
        Get
            Return sesionId
        End Get
        Set(ByVal value As Integer)
            sesionId = value
        End Set
    End Property
    Private busqueda As String
    Public Property NotaCreditoBusqueda() As String
        Get
            Return busqueda
        End Get
        Set(ByVal value As String)
            busqueda = value
        End Set
    End Property
    Private factura As String
    Public Property NotaCreditoFactura() As String
        Get
            Return factura
        End Get
        Set(ByVal value As String)
            factura = value
        End Set
    End Property
    Private folioDevoluciones As String
    Public Property NotaCreditoFoliosDevoluciones() As String
        Get
            Return folioDevoluciones
        End Get
        Set(ByVal value As String)
            folioDevoluciones = value
        End Set
    End Property
    Private subtotal As Decimal
    Public Property NotaCreditoSubtotal() As Decimal
        Get
            Return subtotal
        End Get
        Set(ByVal value As Decimal)
            subtotal = value
        End Set
    End Property
    Private ivaTotal As Decimal
    Public Property NotaCreditoIvaTotal() As Decimal
        Get
            Return ivaTotal
        End Get
        Set(ByVal value As Decimal)
            ivaTotal = value
        End Set
    End Property
    Private total As Decimal
    Public Property NotaCreditoTotal() As Decimal
        Get
            Return total
        End Get
        Set(ByVal value As Decimal)
            total = value
        End Set
    End Property
    Private descuento As Decimal
    Public Property NotaCreditoDescuento() As Decimal
        Get
            Return descuento
        End Get
        Set(ByVal value As Decimal)
            descuento = value
        End Set
    End Property
    Private estatus As String
    Public Property NotaCreditoEstatus() As String
        Get
            Return estatus
        End Get
        Set(ByVal value As String)
            estatus = value
        End Set
    End Property
    Private formapago As String
    Public Property NotaCreditoFormaPago() As String
        Get
            Return formapago
        End Get
        Set(ByVal value As String)
            formapago = value
        End Set
    End Property
    Private metodopago As String
    Public Property NotaCreditoMetodoPago() As String
        Get
            Return metodopago
        End Get
        Set(ByVal value As String)
            metodopago = value
        End Set
    End Property
    Private porcentajeIva As Decimal
    Public Property NotaCreditoPorcentajeIva() As Decimal
        Get
            Return porcentajeIva
        End Get
        Set(ByVal value As Decimal)
            porcentajeIva = value
        End Set
    End Property
    Private conceptoId As Integer
    Public Property NotaCreditoConceptoId() As Integer
        Get
            Return conceptoId
        End Get
        Set(ByVal value As Integer)
            conceptoId = value
        End Set
    End Property
    Private impporte As Decimal
    Public Property NotaCreditoImporte() As Decimal
        Get
            Return impporte
        End Get
        Set(ByVal value As Decimal)
            impporte = value
        End Set
    End Property
    Private observaciones As String
    Public Property NotaCreditoObservaciones() As String
        Get
            Return observaciones
        End Get
        Set(ByVal value As String)
            observaciones = value
        End Set
    End Property
    Private unidad As String
    Public Property NotaCreditoUnidad() As String
        Get
            Return unidad
        End Get
        Set(ByVal value As String)
            unidad = value
        End Set
    End Property
    Private paresFacturados As Integer
    Public Property NotaCreditoParesFacturados() As Integer
        Get
            Return paresFacturados
        End Get
        Set(ByVal value As Integer)
            paresFacturados = value
        End Set
    End Property
    Private saldoFactura As Decimal
    Public Property NotaCreditoSaldoFactura() As Decimal
        Get
            Return saldoFactura
        End Get
        Set(ByVal value As Decimal)
            saldoFactura = value
        End Set
    End Property
    Private sello As String
    Public Property NotaCreditoSello() As String
        Get
            Return sello
        End Get
        Set(ByVal value As String)
            sello = value
        End Set
    End Property
    Private uuid As String
    Public Property NotaCreditoUUID() As String
        Get
            Return uuid
        End Get
        Set(ByVal value As String)
            uuid = value
        End Set
    End Property
    Private usuariotimbro As Integer
    Public Property NotaCreditoUsuarioTimbro() As Integer
        Get
            Return usuariotimbro
        End Get
        Set(ByVal value As Integer)
            usuariotimbro = value
        End Set
    End Property
    Private fechatimbrado As Date
    Public Property NotaCreditoFechaTimbrado() As Date
        Get
            Return fechatimbrado
        End Get
        Set(ByVal value As Date)
            fechatimbrado = value
        End Set
    End Property
    Private versionsat As String
    Public Property NotaCreditoVersionSAT() As String
        Get
            Return versionsat
        End Get
        Set(ByVal value As String)
            versionsat = value
        End Set
    End Property
    Private rfcprovcertif As String
    Public Property NotaCreditoRFCProvCertif() As String
        Get
            Return rfcprovcertif
        End Get
        Set(ByVal value As String)
            rfcprovcertif = value
        End Set
    End Property
    Private nocertificado As String
    Public Property NotaCreditoNoCertificadoSAT() As String
        Get
            Return nocertificado
        End Get
        Set(ByVal value As String)
            nocertificado = value
        End Set
    End Property
    Private sellosat As String
    Public Property NotaCreditoSelloSAT() As String
        Get
            Return sellosat
        End Get
        Set(ByVal value As String)
            sellosat = value
        End Set
    End Property
    Private cadenaoriginal As String
    Public Property NotaCreditoCadenaOriginal() As String
        Get
            Return cadenaoriginal
        End Get
        Set(ByVal value As String)
            cadenaoriginal = value
        End Set
    End Property
    Private cadenaoriginalcomplemento As String
    Public Property NotaCreditoCadenaOriginalComplemento() As String
        Get
            Return cadenaoriginalcomplemento
        End Get
        Set(ByVal value As String)
            cadenaoriginalcomplemento = value
        End Set
    End Property
    Private enviado As String
    Public Property NotaCreditoCorreoEnviado() As String
        Get
            Return enviado
        End Get
        Set(ByVal value As String)
            enviado = value
        End Set
    End Property
    Private detalledevolucion As Integer
    Public Property NotaCreditoDetalleDevolucionId() As Integer
        Get
            Return detalledevolucion
        End Get
        Set(ByVal value As Integer)
            detalledevolucion = value
        End Set
    End Property
    Private productoestilo As Integer
    Public Property NotaCreditoProductoEstiloId() As Integer
        Get
            Return productoestilo
        End Get
        Set(ByVal value As Integer)
            productoestilo = value
        End Set
    End Property
    Private clienteid_SICY As Integer
    Public Property NotaCreditoClienteId_SICY() As Integer
        Get
            Return clienteid_SICY
        End Get
        Set(ByVal value As Integer)
            clienteid_SICY = value
        End Set
    End Property
End Class
