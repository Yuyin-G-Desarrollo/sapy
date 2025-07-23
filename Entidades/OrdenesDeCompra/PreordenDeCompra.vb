Public Class PreordenDeCompraDetalle

    Private PreordendeCompraid As Integer
    Public Property PreordendeCompraid_() As Integer
        Get
            Return PreordendeCompraid
        End Get
        Set(ByVal value As Integer)
            PreordendeCompraid = value
        End Set
    End Property

    Private Materialnaveid As Integer
    Public Property Materialnaveid_() As Integer
        Get
            Return Materialnaveid
        End Get
        Set(ByVal value As Integer)
            Materialnaveid = value
        End Set
    End Property

    Private Corridaid As Integer
    Public Property Corridaid_() As Integer
        Get
            Return Corridaid
        End Get
        Set(ByVal value As Integer)
            Corridaid = value
        End Set
    End Property

    Private Cantidadrequerida As Double
    Public Property Cantidadrequerida_() As Double
        Get
            Return Cantidadrequerida
        End Get
        Set(ByVal value As Double)
            Cantidadrequerida = value
        End Set
    End Property

    Private Cantidadinventario As Double
    Public Property Cantidadinventario_() As Double
        Get
            Return Cantidadinventario
        End Get
        Set(ByVal value As Double)
            Cantidadinventario = value
        End Set
    End Property

    Private Cantidadsolicitada As Double
    Public Property Cantidadsolicitada_() As Double
        Get
            Return Cantidadsolicitada
        End Get
        Set(ByVal value As Double)
            Cantidadsolicitada = value
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

    Private Factorconversion As Double
    Public Property Factorconversion_() As Double
        Get
            Return Factorconversion
        End Get
        Set(ByVal value As Double)
            Factorconversion = value
        End Set
    End Property

    Private Proveedorid As Integer
    Public Property Proveedorid_() As Integer
        Get
            Return Proveedorid
        End Get
        Set(ByVal value As Integer)
            Proveedorid = value
        End Set
    End Property

    Private inventario As Double
    Public Property inventario_() As Double
        Get
            Return inventario
        End Get
        Set(ByVal value As Double)
            inventario = value
        End Set
    End Property

    Private porrecibir As Double
    Public Property porrecibir_() As Double
        Get
            Return porrecibir
        End Get
        Set(ByVal value As Double)
            porrecibir = value
        End Set
    End Property

    Private Proveedoridreal As Integer
    Public Property Proveedoridreal_() As Integer
        Get
            Return Proveedoridreal
        End Get
        Set(ByVal value As Integer)
            Proveedoridreal = value
        End Set
    End Property

    Private Precio As Double
    Public Property Precio_() As Double
        Get
            Return Precio
        End Get
        Set(ByVal value As Double)
            Precio = value
        End Set
    End Property

    Private Total As Double
    Public Property Total_() As Double
        Get
            Return Total
        End Get
        Set(ByVal value As Double)
            Total = value
        End Set
    End Property

    Private Usuariocreoid As Integer
    Public Property Usuariocreoid_() As Integer
        Get
            Return Usuariocreoid
        End Get
        Set(ByVal value As Integer)
            Usuariocreoid = value
        End Set
    End Property

    Private Fechacreo As String
    Public Property Fechacreo_() As String
        Get
            Return Fechacreo
        End Get
        Set(ByVal value As String)
            Fechacreo = value
        End Set
    End Property

    Private tipo As String
    Public Property tipo_() As String
        Get
            Return tipo
        End Get
        Set(ByVal value As String)
            tipo = value
        End Set
    End Property


    Private Usuariomodifico As Integer
    Public Property Usuariomodifico_() As Integer
        Get
            Return Usuariomodifico
        End Get
        Set(ByVal value As Integer)
            Usuariomodifico = value
        End Set
    End Property

    Private Fechamodifico As String
    Public Property Fechamodifico_() As String
        Get
            Return Fechamodifico
        End Get
        Set(ByVal value As String)
            Fechamodifico = value
        End Set
    End Property
    Private monedaid As Integer
    Public Property Monedaid_() As Integer
        Get
            Return monedaid
        End Get
        Set(ByVal value As Integer)
            monedaid = value
        End Set
    End Property
End Class
