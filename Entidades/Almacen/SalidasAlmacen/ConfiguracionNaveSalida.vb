Public Class ConfiguracionNaveSalida


    Private PNaveSICYID As Integer
    Private PNave As String = String.Empty
    Private PExterna As Boolean
    Private PMaquila As Boolean
    Private PSistemaSay As Boolean


    Public Property NaveSICYID() As Integer
        Get
            Return PNaveSICYID
        End Get
        Set(ByVal value As Integer)
            PNaveSICYID = value
        End Set
    End Property

    Public Property Nave() As String
        Get
            Return PNave
        End Get
        Set(ByVal value As String)
            PNave = value
        End Set
    End Property


    Public Property Externa() As Boolean
        Get
            Return PExterna
        End Get
        Set(ByVal value As Boolean)
            PExterna = value
        End Set
    End Property

    Public Property Maquila() As Boolean
        Get
            Return PMaquila
        End Get
        Set(ByVal value As Boolean)
            PMaquila = value
        End Set
    End Property

    Public Property SistemaSay As Boolean
        Get
            Return PSistemaSay
        End Get
        Set(value As Boolean)
            PSistemaSay = value
        End Set
    End Property
End Class
