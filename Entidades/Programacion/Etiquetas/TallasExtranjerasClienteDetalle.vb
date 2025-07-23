Public Class TallasExtranjerasClienteDetalle

    Private _ClienteID As Integer
    Public Property Cliente() As Integer
        Get
            Return _ClienteID
        End Get
        Set(ByVal value As Integer)
            _ClienteID = value
        End Set
    End Property

    Private _TallaID As Integer
    Public Property TallaID() As Integer
        Get
            Return _TallaID
        End Get
        Set(ByVal value As Integer)
            _TallaID = value
        End Set
    End Property

    Private _FamiliaID As Integer
    Public Property FamiliaID() As Integer
        Get
            Return _FamiliaID
        End Get
        Set(ByVal value As Integer)
            _FamiliaID = value
        End Set
    End Property

    Private _PaisID As Integer
    Public Property Pais() As Integer
        Get
            Return _PaisID
        End Get
        Set(ByVal value As Integer)
            _PaisID = value
        End Set
    End Property

    Private _TallaMexicana As String
    Public Property TallaMexicana() As String
        Get
            Return _TallaMexicana
        End Get
        Set(ByVal value As String)
            _TallaMexicana = value
        End Set
    End Property

    Private _TallaExtranjera As String
    Public Property TallaExtranjera() As String
        Get
            Return _TallaExtranjera
        End Get
        Set(ByVal value As String)
            _TallaExtranjera = value
        End Set
    End Property

    Private _Activo As Boolean
    Public Property Activo() As Boolean
        Get
            Return _Activo
        End Get
        Set(ByVal value As Boolean)
            _Activo = value
        End Set
    End Property

    Private _PaisAbreviatura As String
    Public Property PaisAbreviatura() As String
        Get
            Return _PaisAbreviatura
        End Get
        Set(ByVal value As String)
            _PaisAbreviatura = value
        End Set
    End Property

    Private _Fila As Integer
    Public Property Fila() As Integer
        Get
            Return _Fila
        End Get
        Set(ByVal value As Integer)
            _Fila = value
        End Set
    End Property

End Class
