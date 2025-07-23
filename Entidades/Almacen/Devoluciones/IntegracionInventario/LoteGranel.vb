Public Class LoteGranel

    Dim _Lote As Integer
    Dim _NoDocena As Integer
    Dim _Año As Integer
    Dim _CodigoSICY As String
    Dim _TallaSICYID As String

    Public Property Lote As Integer
        Get
            Return _Lote
        End Get
        Set(value As Integer)
            _Lote = value
        End Set
    End Property

    Public Property NoDocena As Integer
        Get
            Return _NoDocena
        End Get
        Set(value As Integer)
            _NoDocena = value
        End Set
    End Property

    Public Property Año As Integer
        Get
            Return _Año
        End Get
        Set(value As Integer)
            _Año = value
        End Set
    End Property

    Public Property CodigoSICY As String
        Get
            Return _CodigoSICY
        End Get
        Set(value As String)
            _CodigoSICY = value
        End Set
    End Property

    Public Property TallaSICYID As String
        Get
            Return _TallaSICYID
        End Get
        Set(value As String)
            _TallaSICYID = value
        End Set
    End Property

End Class
