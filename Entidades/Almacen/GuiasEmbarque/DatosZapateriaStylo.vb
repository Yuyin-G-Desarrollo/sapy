Public Class DatosZapateriaStylo
    Private _TDA As String
    Private _numeroFactura As String
    Private _remitente As String
    Private _fechaCancelacion As String
    Private _descripcion As String

    Public Property TDA As String
        Get
            Return _TDA
        End Get
        Set(value As String)
            _TDA = value
        End Set
    End Property

    Public Property NumeroFactura As String
        Get
            Return _numeroFactura
        End Get
        Set(value As String)
            _numeroFactura = value
        End Set
    End Property

    Public Property Remitente As String
        Get
            Return _remitente
        End Get
        Set(value As String)
            _remitente = value
        End Set
    End Property

    Public Property FechaCancelacion As String
        Get
            Return _fechaCancelacion
        End Get
        Set(value As String)
            _fechaCancelacion = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
End Class
