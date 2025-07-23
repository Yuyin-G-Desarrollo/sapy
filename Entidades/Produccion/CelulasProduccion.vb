Public Class CelulasProduccion
    Private IDCelula As Int32
    Private NombreCelula As String
    Private CantidadAcumuladaLotes As Int32
    Private CantidadAcumuladaPares As Int32
    Private CantidadAtrasadasLotes As Int32
    Private CantidadAtrasadasPares As Int32
    Private CantidadTerminadasLotes As Int32
    Private CantidadTerminadasPares As Int32

    Public Property PCantidadTerminadasPares As Int32
        Get
            Return CantidadTerminadasPares
        End Get
        Set(value As Int32)
            CantidadTerminadasPares = value
        End Set
    End Property

    Public Property PCantidadTerminadasLotes As Int32
        Get
            Return CantidadTerminadasLotes
        End Get
        Set(value As Int32)
            CantidadTerminadasLotes = value
        End Set
    End Property

    Public Property PCantidadAtrasadasPares As Int32
        Get
            Return CantidadAtrasadasPares
        End Get
        Set(value As Int32)
            CantidadAtrasadasPares = value
        End Set
    End Property

    Public Property PCantidadAtrasadasLotes As Int32
        Get
            Return CantidadAtrasadasLotes
        End Get
        Set(value As Int32)
            CantidadAtrasadasLotes = value
        End Set
    End Property


    Public Property PCantidadAcumuladaPares As Int32
        Get
            Return CantidadAcumuladaPares
        End Get
        Set(ByVal value As Int32)
            CantidadAcumuladaPares = value
        End Set
    End Property

    Public Property PCantidadAcumuladaLotes As Int32
        Get
            Return CantidadAcumuladaLotes
        End Get
        Set(ByVal value As Int32)
            CantidadAcumuladaLotes = value
        End Set
    End Property

    Public Property PIDCelula As Int32
        Get
            Return IDCelula
        End Get
        Set(ByVal value As Int32)
            IDCelula = value
        End Set
    End Property

    Public Property PNombreCelula As String
        Get
            Return NombreCelula
        End Get
        Set(ByVal value As String)
            NombreCelula = value
        End Set
    End Property


End Class
