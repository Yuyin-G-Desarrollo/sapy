
Public Class ValidacionCodigoLeido

    Private _ExisteOParEnFolio As Boolean
    Private _EsAtado As Boolean
    Private _EsCodigoCliente As Boolean
    Private _EsCodigoPar As Boolean
    Private _FolioSalidaID As Integer


    Public Property ExisteOParEnFolio As Boolean
        Get
            Return _ExisteOParEnFolio
        End Get
        Set(value As Boolean)
            _ExisteOParEnFolio = value
        End Set
    End Property


    Public Property EsAtado As Boolean
        Get
            Return _EsAtado
        End Get
        Set(value As Boolean)
            _EsAtado = value
        End Set
    End Property

    Public Property EsCodigoCliente As Boolean
        Get
            Return _EsCodigoCliente
        End Get
        Set(value As Boolean)
            _EsCodigoCliente = value
        End Set
    End Property

    Public Property EsCodigoPar As Boolean
        Get
            Return _EsCodigoPar
        End Get
        Set(value As Boolean)
            _EsCodigoPar = value
        End Set
    End Property

    Public Property FolioSalidaID As Integer
        Get
            Return _FolioSalidaID
        End Get
        Set(value As Integer)
            _FolioSalidaID = value
        End Set
    End Property

End Class
