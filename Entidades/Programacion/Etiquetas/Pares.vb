Public Class Pares

    Private _Imprimir As Boolean
    Public Property Imprimir() As Boolean
        Get
            Return _Imprimir
        End Get
        Set(ByVal value As Boolean)
            _Imprimir = value
        End Set
    End Property

    Private _Lote As Integer
    Public Property Lote() As Integer
        Get
            Return _Lote
        End Get
        Set(ByVal value As Integer)
            _Lote = value
        End Set
    End Property

    Private _Docena As Integer
    Public Property Docena() As Integer
        Get
            Return _Docena
        End Get
        Set(ByVal value As Integer)
            _Docena = value
        End Set
    End Property

    Private _idDocena As String
    Public Property idDocena() As String
        Get
            Return _idDocena
        End Get
        Set(ByVal value As String)
            _idDocena = value
        End Set
    End Property

    Private _IdPar As String
    Public Property idPar() As String
        Get
            Return _IdPar
        End Get
        Set(ByVal value As String)
            _IdPar = value
        End Set
    End Property

    Private _Talla As String
    Public Property Talla() As String
        Get
            Return _Talla
        End Get
        Set(ByVal value As String)
            _Talla = value
        End Set
    End Property

    Private _ModeloSAY As String
    Public Property ModeloSAY() As String
        Get
            Return _ModeloSAY
        End Get
        Set(ByVal value As String)
            _ModeloSAY = value
        End Set
    End Property

    Private _Color As String
    Public Property Color() As String
        Get
            Return _Color
        End Get
        Set(ByVal value As String)
            _Color = value
        End Set
    End Property

End Class
