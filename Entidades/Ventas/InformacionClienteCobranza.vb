Public Class InformacionClienteCobranza

    Private Pinfoclienteid As Integer
    Public Property infoclienteid() As Integer
        Get
            Return Pinfoclienteid
        End Get
        Set(ByVal value As Integer)
            Pinfoclienteid = value
        End Set
    End Property

    Private Pplazo As Integer
    Public Property plazo() As Integer
        Get
            Return Pplazo
        End Get
        Set(ByVal value As Integer)
            Pplazo = value
        End Set
    End Property

    Private Plimitecredito As Decimal
    Public Property limitecredito() As Decimal
        Get
            Return Plimitecredito
        End Get
        Set(ByVal value As Decimal)
            Plimitecredito = value
        End Set
    End Property

    Private Pcuenta As String
    Public Property cuenta() As String
        Get
            Return Pcuenta
        End Get
        Set(ByVal value As String)
            Pcuenta = value
        End Set
    End Property

    Private Pfacturar As Decimal
    Public Property facturar() As Decimal
        Get
            Return Pfacturar
        End Get
        Set(ByVal value As Decimal)
            Pfacturar = value
        End Set
    End Property

    Private Pdocumentar As Decimal
    Public Property documentar() As Decimal
        Get
            Return Pdocumentar
        End Get
        Set(ByVal value As Decimal)
            Pdocumentar = value
        End Set
    End Property

    Private Pincrementoparporcent As Decimal
    Public Property incrementoparporcent() As Decimal
        Get
            Return Pincrementoparporcent
        End Get
        Set(ByVal value As Decimal)
            Pincrementoparporcent = value
        End Set
    End Property

    Private Pincrementoparmonto As Decimal
    Public Property incrementoparmonto() As Decimal
        Get
            Return Pincrementoparmonto
        End Get
        Set(ByVal value As Decimal)
            Pincrementoparmonto = value
        End Set
    End Property

    Private Pporcfacturasugerido As Decimal
    Public Property porcfacturasugerido() As Decimal
        Get
            Return Pporcfacturasugerido
        End Get
        Set(ByVal value As Decimal)
            Pporcfacturasugerido = value
        End Set
    End Property

    Private Pmoneda As Moneda
    Public Property moneda() As Moneda
        Get
            Return Pmoneda
        End Get
        Set(ByVal value As Moneda)
            Pmoneda = value
        End Set
    End Property

    Private Ptipoiva As TipoIVA
    Public Property tipoiva() As TipoIVA
        Get
            Return Ptipoiva
        End Get
        Set(ByVal value As TipoIVA)
            Ptipoiva = value
        End Set
    End Property

    Private Pmontocreditoautorizado As Decimal
    Public Property montocreditoautorizado() As Decimal
        Get
            Return Pmontocreditoautorizado
        End Get
        Set(ByVal value As Decimal)
            Pmontocreditoautorizado = value
        End Set
    End Property

    Private Pcliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property

End Class
