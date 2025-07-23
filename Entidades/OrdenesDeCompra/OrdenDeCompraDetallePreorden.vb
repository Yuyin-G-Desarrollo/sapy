Public Class OrdenDeCompraDetallePreorden

    Private ordendecompraid As Integer
    Public Property ordendecompraid_() As Integer
        Get
            Return ordendecompraid
        End Get
        Set(ByVal value As Integer)
            ordendecompraid = value
        End Set
    End Property

    Private materialnaveid As Integer
    Public Property materialnaveid_() As Integer
        Get
            Return materialnaveid
        End Get
        Set(ByVal value As Integer)
            materialnaveid = value
        End Set
    End Property

    Private corridaid As Integer
    Public Property corridaid_() As Integer
        Get
            Return corridaid
        End Get
        Set(ByVal value As Integer)
            corridaid = value
        End Set
    End Property

    Private cantidadsolicitada As Double
    Public Property cantidadsolicitada_() As Double
        Get
            Return cantidadsolicitada
        End Get
        Set(ByVal value As Double)
            cantidadsolicitada = value
        End Set
    End Property

    Private cantidadrecibida As Double
    Public Property cantidadrecibida_() As Double
        Get
            Return cantidadrecibida
        End Get
        Set(ByVal value As Double)
            cantidadrecibida = value
        End Set
    End Property

    Private tipocaptura As String
    Public Property tipocaptura_() As String
        Get
            Return tipocaptura
        End Get
        Set(ByVal value As String)
            tipocaptura = value
        End Set
    End Property

    Private almace As Double
    Public Property almacen_() As Double
        Get
            Return almace
        End Get
        Set(ByVal value As Double)
            almace = value
        End Set
    End Property


    Private umc As Integer
    Public Property umc_() As Integer
        Get
            Return umc
        End Get
        Set(ByVal value As Integer)
            umc = value
        End Set
    End Property

    Private factorconversion As Double
    Public Property factorconversion_() As Double
        Get
            Return factorconversion
        End Get
        Set(ByVal value As Double)
            factorconversion = value
        End Set
    End Property

    Private proveedorid As Integer
    Public Property proveedorid_() As Integer
        Get
            Return proveedorid
        End Get
        Set(ByVal value As Integer)
            proveedorid = value
        End Set
    End Property

    Private precio As Double
    Public Property precio_() As Double
        Get
            Return precio
        End Get
        Set(ByVal value As Double)
            precio = value
        End Set
    End Property

    Private total As Double
    Public Property total_() As Double
        Get
            Return total
        End Get
        Set(ByVal value As Double)
            total = value
        End Set
    End Property

    Private claveproveedor As String
    Public Property claveproveedor_() As String
        Get
            Return claveproveedor
        End Get
        Set(ByVal value As String)
            claveproveedor = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property usuariocreoid_() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private fechacreo As String
    Public Property fechacreo_() As String
        Get
            Return fechacreo
        End Get
        Set(ByVal value As String)
            fechacreo = value
        End Set
    End Property

    Private estatusmaterial As String
    Public Property estatusmaterial_() As String
        Get
            Return estatusmaterial
        End Get
        Set(ByVal value As String)
            estatusmaterial = value
        End Set
    End Property
    Private monedaid As Integer
    Public Property monedaid_() As Integer
        Get
            Return monedaid
        End Get
        Set(ByVal value As Integer)
            monedaid = value
        End Set
    End Property
End Class
