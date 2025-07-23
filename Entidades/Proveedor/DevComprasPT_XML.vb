Public Class DevComprasPT_XML
    Dim serie As String
    Dim folio As Integer
    Dim fechaTimbrado As Date
    Dim total As Double
    Dim UUID As String
    Dim totalPares As Integer
    Dim rfcEmisor As String
    Dim rfcReceptor As String
    Dim tipoMoneda As String

    Public Property PSerie As String
        Get
            Return serie
        End Get
        Set(value As String)
            serie = value
        End Set
    End Property

    Public Property PFolio As Integer
        Get
            Return folio
        End Get
        Set(value As Integer)
            folio = value
        End Set
    End Property

    Public Property PFechaTimbrado As Date
        Get
            Return fechaTimbrado
        End Get
        Set(value As Date)
            fechaTimbrado = value
        End Set
    End Property

    Public Property PTotal As Double
        Get
            Return total
        End Get
        Set(value As Double)
            total = value
        End Set
    End Property

    Public Property PUUID As String
        Get
            Return UUID
        End Get
        Set(value As String)
            UUID = value
        End Set
    End Property

    Public Property PTotalPares As Integer
        Get
            Return totalPares
        End Get
        Set(value As Integer)
            totalPares = value
        End Set
    End Property

    Public Property PRFCEmisor As String
        Get
            Return rfcEmisor
        End Get
        Set(value As String)
            rfcEmisor = value
        End Set
    End Property

    Public Property PRFCReceptor As String
        Get
            Return rfcReceptor
        End Get
        Set(value As String)
            rfcReceptor = value
        End Set
    End Property

    Public Property PTipoMoneda As String
        Get
            Return tipoMoneda
        End Get
        Set(value As String)
            tipoMoneda = value
        End Set
    End Property

End Class
