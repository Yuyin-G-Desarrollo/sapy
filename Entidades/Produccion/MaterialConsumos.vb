Public Class MaterialConsumos
    Private IdMaterial As Integer
    Private Material As String
    Private SKU As String
    Private IdUMC As Integer
    Private UMC As String
    Private IdProveedor As Integer
    Private Proveedor As String
    Private IdUmProduccion As Integer
    Private UMP As String
    Private Factor As Decimal
    Private PrecioCompra As Decimal
    Private PrecioUm As Decimal

    Public Property PIdMaterial As Integer
        Get
            Return IdMaterial
        End Get
        Set(value As Integer)
            IdMaterial = value
        End Set
    End Property

    Public Property PMaterial As String
        Get
            Return Material
        End Get
        Set(value As String)
            Material = value
        End Set
    End Property

    Public Property PSKU As String
        Get
            Return SKU
        End Get
        Set(value As String)
            SKU = value
        End Set
    End Property

    Public Property PIdUMC As Integer
        Get
            Return IdUMC
        End Get
        Set(value As Integer)
            IdUMC = value
        End Set
    End Property

    Public Property PUMC As String
        Get
            Return UMC
        End Get
        Set(value As String)
            UMC = value
        End Set
    End Property

    Public Property PIdProveedor As Integer
        Get
            Return IdProveedor
        End Get
        Set(value As Integer)
            IdProveedor = value
        End Set
    End Property

    Public Property PProveedor As String
        Get
            Return Proveedor
        End Get
        Set(value As String)
            Proveedor = value
        End Set
    End Property

    Public Property PIdUmProduccion As Integer
        Get
            Return IdUmProduccion
        End Get
        Set(value As Integer)
            IdUmProduccion = value
        End Set
    End Property

    Public Property PUMP As String
        Get
            Return UMP
        End Get
        Set(value As String)
            UMP = value
        End Set
    End Property

    Public Property PFactor As Decimal
        Get
            Return Factor
        End Get
        Set(value As Decimal)
            Factor = value
        End Set
    End Property

    Public Property PPrecioCompra As Decimal
        Get
            Return PrecioCompra
        End Get
        Set(value As Decimal)
            PrecioCompra = value
        End Set
    End Property

    Public Property PPrecioUm As Decimal
        Get
            Return PrecioUm
        End Get
        Set(value As Decimal)
            PrecioUm = value
        End Set
    End Property


End Class
