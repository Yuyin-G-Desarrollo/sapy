Public Class Carrito

    Private Pcarritoid As Integer
    Public Property carritoid() As Integer
        Get
            Return Pcarritoid
        End Get
        Set(ByVal value As Integer)
            Pcarritoid = value
        End Set
    End Property

    Private Pdescripcion As String
    Public Property descripcion() As String
        Get
            Return Pdescripcion
        End Get
        Set(ByVal value As String)
            Pdescripcion = value
        End Set
    End Property

    Private Ptipocarrito As TipoCarrito
    Public Property tipocarrito() As TipoCarrito
        Get
            Return Ptipocarrito
        End Get
        Set(ByVal value As TipoCarrito)
            Ptipocarrito = value
        End Set
    End Property

    Private Pnave As Naves
    Public Property nave() As Naves
        Get
            Return Pnave
        End Get
        Set(ByVal value As Naves)
            Pnave = value
        End Set
    End Property

    Private Palmacen As Almacen
    Public Property almacen() As Almacen
        Get
            Return Palmacen
        End Get
        Set(ByVal value As Almacen)
            Palmacen = value
        End Set
    End Property


    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property

End Class
