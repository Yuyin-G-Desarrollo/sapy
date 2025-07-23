Public Class GeneracionSalida

    Private IdDetalleEntrega As String
    Private UsuarioSalida As Integer
    Private CantidadParesSalida As Integer
    Private CantidadParesNoRecibidos As Integer


    Public Property PIdDetalleEntrega As String
        Get
            Return IdDetalleEntrega
        End Get
        Set(value As String)
            IdDetalleEntrega = value
        End Set
    End Property

    Public Property PUsuarioSalida As Integer
        Get
            Return UsuarioSalida
        End Get
        Set(value As Integer)
            UsuarioSalida = value
        End Set
    End Property

    Public Property PCantidadParesSalida As Integer
        Get
            Return CantidadParesSalida
        End Get
        Set(value As Integer)
            CantidadParesSalida = value
        End Set
    End Property

    Public Property PCantidadParesNoRecibidos As Integer
        Get
            Return CantidadParesNoRecibidos
        End Get
        Set(value As Integer)
            CantidadParesNoRecibidos = value
        End Set
    End Property

    
End Class
