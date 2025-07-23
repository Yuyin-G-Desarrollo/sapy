Public Class FacturaPTIngresadoDetalle
    Private documentoDetalleId As Integer
    Public Property PDocumentoDetalleId() As Integer
        Get
            Return documentoDetalleId
        End Get
        Set(ByVal value As Integer)
            documentoDetalleId = value
        End Set
    End Property

    Private documentoId As Integer
    Public Property PDocumentoId() As Integer
        Get
            Return documentoId
        End Get
        Set(ByVal value As Integer)
            documentoId = value
        End Set
    End Property

    Private claveProdServ As String
    Public Property PClaveProdServ() As String
        Get
            Return claveProdServ
        End Get
        Set(ByVal value As String)
            claveProdServ = value
        End Set
    End Property

    Private noIdentificacion As String
    Public Property PNoIdentificacion() As String
        Get
            Return noIdentificacion
        End Get
        Set(ByVal value As String)
            noIdentificacion = value
        End Set
    End Property

    Private cantidad As Integer
    Public Property PCantidad() As Integer
        Get
            Return cantidad
        End Get
        Set(ByVal value As Integer)
            cantidad = value
        End Set
    End Property

    Private claveUnidad As String
    Public Property PClaveUnidad() As String
        Get
            Return claveUnidad
        End Get
        Set(ByVal value As String)
            claveUnidad = value
        End Set
    End Property

    Private descripcion As String
    Public Property PDescripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private valorUnitario As Double
    Public Property PValorUnitario() As Double
        Get
            Return valorUnitario
        End Get
        Set(ByVal value As Double)
            valorUnitario = value
        End Set
    End Property

    Private importe As Double
    Public Property PImporte() As Double
        Get
            Return importe
        End Get
        Set(ByVal value As Double)
            importe = value
        End Set
    End Property

    Private descuento As Double
    Public Property PDescuento() As Double
        Get
            Return descuento
        End Get
        Set(ByVal value As Double)
            descuento = value
        End Set
    End Property

    Private base As Double
    Public Property PBase() As Double
        Get
            Return base
        End Get
        Set(ByVal value As Double)
            base = value
        End Set
    End Property

    Private impuesto As String
    Public Property PImpuesto() As String
        Get
            Return impuesto
        End Get
        Set(ByVal value As String)
            impuesto = value
        End Set
    End Property

    Private tipoFactor As String
    Public Property PTipoFactor() As String
        Get
            Return tipoFactor
        End Get
        Set(ByVal value As String)
            tipoFactor = value
        End Set
    End Property

    Private tasaCuota As Double
    Public Property PTasaCuota() As Double
        Get
            Return tasaCuota
        End Get
        Set(ByVal value As Double)
            tasaCuota = value
        End Set
    End Property

    Private importeImpuesto As Double
    Public Property PImporteImpuesto() As Double
        Get
            Return importeImpuesto
        End Get
        Set(ByVal value As Double)
            importeImpuesto = value
        End Set
    End Property
End Class
