Public Class Coleccion
    Private CcoleccionId As Int32
    Private CDescripcion As String
    Private CCodigo As String
    Private CActivo As Boolean
    Private CCodigoSicy As String

    Public Property PColeID As Int32
        Get
            Return CcoleccionId
        End Get
        Set(ByVal value As Int32)
            CcoleccionId = value
        End Set
    End Property

    Public Property PColeccionDescripcion As String
        Get
            Return CDescripcion
        End Get
        Set(ByVal value As String)
            CDescripcion = value
        End Set
    End Property

    Public Property PColeccionCodigo As String
        Get
            Return CCodigo
        End Get
        Set(ByVal value As String)
            CCodigo = value
        End Set
    End Property

    Public Property PColeccionActivo As Boolean
        Get
            Return CActivo
        End Get
        Set(ByVal value As Boolean)
            CActivo = value
        End Set
    End Property

    Public Property PColeccionCodigoSicy As String
        Get
            Return CCodigoSicy
        End Get
        Set(ByVal value As String)
            CCodigoSicy = value
        End Set
    End Property
End Class
