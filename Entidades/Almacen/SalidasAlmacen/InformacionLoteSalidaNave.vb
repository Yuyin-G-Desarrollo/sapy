Public Class InformacionLoteSalidaNave
    Private PLote As Integer
    Private PNaveSICYID As Integer
    Private PParesLote As Integer
    Private PStatusLote As Integer
    Private PConfirmacionPorPar As Boolean
    Private PAño As Integer
    Private PParesConfirmados As Integer = 0

    Public Property ParesConfirmados() As Integer
        Get
            Return PParesConfirmados
        End Get
        Set(ByVal value As Integer)
            PParesConfirmados = value
        End Set
    End Property

    Public Property Año() As Integer
        Get
            Return PAño
        End Get
        Set(ByVal value As Integer)
            PAño = value
        End Set
    End Property

    Public Property ConfirmacionPorPar() As Boolean
        Get
            Return PConfirmacionPorPar
        End Get
        Set(ByVal value As Boolean)
            PConfirmacionPorPar = value
        End Set
    End Property
    Public Property Lote() As Integer
        Get
            Return PLote
        End Get
        Set(ByVal value As Integer)
            PLote = value
        End Set
    End Property

    Public Property NaveSICYID() As Integer
        Get
            Return PNaveSICYID
        End Get
        Set(ByVal value As Integer)
            PNaveSICYID = value
        End Set
    End Property

    Public Property ParesLote() As Integer
        Get
            Return PParesLote
        End Get
        Set(ByVal value As Integer)
            PParesLote = value
        End Set
    End Property

    Public Property StatusLote() As Integer
        Get
            Return PStatusLote
        End Get
        Set(ByVal value As Integer)
            PStatusLote = value
        End Set
    End Property


End Class
