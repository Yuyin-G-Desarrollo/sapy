Public Class EditarOrdenCompra_MaterialesMerca
    Private IdOrdenCompra As Integer
    Private ClienteID As Integer
    Private Cliente As String
    Private MotivoSolicitud As String
    Private IdMaterial As Integer
    Private NombreMaterial As String
    Private Cantidad As Integer
    Private UMC As String
    Private Precio As Integer
    Private Observaciones As String
    Private Total As Integer
    Private Estatus As String
    Private MaterialID As Integer

    Public Property PIdOrdenCompra() As Integer
        Get
            Return IdOrdenCompra
        End Get
        Set(ByVal value As Integer)
            IdOrdenCompra = value
        End Set
    End Property

    Public Property PClienteID() As Integer
        Get
            Return ClienteID
        End Get
        Set(ByVal value As Integer)
            ClienteID = value
        End Set
    End Property

    Public Property PCliente() As String
        Get
            Return Cliente
        End Get
        Set(ByVal value As String)
            Cliente = value
        End Set
    End Property

    Public Property PMotivoSolicitud() As String
        Get
            Return MotivoSolicitud
        End Get
        Set(ByVal value As String)
            MotivoSolicitud = value
        End Set
    End Property

    Public Property PIdMaterial() As Integer
        Get
            Return IdMaterial
        End Get
        Set(ByVal value As Integer)
            IdMaterial = value
        End Set
    End Property

    Public Property PNombreMaterial() As String
        Get
            Return NombreMaterial
        End Get
        Set(ByVal value As String)
            NombreMaterial = value
        End Set
    End Property

    Public Property PUMC() As String
        Get
            Return UMC
        End Get
        Set(ByVal value As String)
            UMC = value
        End Set
    End Property

    Public Property PPrecio() As Integer
        Get
            Return Precio
        End Get
        Set(ByVal value As Integer)
            Precio = value
        End Set
    End Property

    Public Property PObservaciones() As String
        Get
            Return Observaciones
        End Get
        Set(ByVal value As String)
            Observaciones = value
        End Set
    End Property

    Public Property PTotal() As Integer
        Get
            Return Total
        End Get
        Set(ByVal value As Integer)
            Total = value
        End Set
    End Property

    Public Property PCantidad() As Integer
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Integer)
            Cantidad = value
        End Set
    End Property

    Public Property PEstatus() As String
        Get
            Return Estatus
        End Get
        Set(ByVal value As String)
            Estatus = value
        End Set
    End Property


    Public Property PMaterialID() As Integer
        Get
            Return MaterialID
        End Get
        Set(ByVal value As Integer)
            MaterialID = value
        End Set
    End Property

End Class
