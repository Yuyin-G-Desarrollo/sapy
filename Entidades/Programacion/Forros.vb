Public Class Forros
    Private FForroid As Int32
    Private FDescripcion As String
    Private FCodigo As String
    Private FActivo As Boolean

    Public Property ForroId As Int32
        Get
            Return FForroid
        End Get
        Set(ByVal value As Int32)
            FForroid = value
        End Set
    End Property

    Public Property ForroDescripcion As String
        Get
            Return FDescripcion
        End Get
        Set(ByVal value As String)
            FDescripcion = value
        End Set
    End Property

    Public Property ForroCodigo As String
        Get
            Return FCodigo
        End Get
        Set(ByVal value As String)
            FCodigo = value
        End Set
    End Property

    Public Property ForroActivo As Boolean
        Get
            Return FActivo
        End Get
        Set(ByVal value As Boolean)
            FActivo = value
        End Set
    End Property


End Class
