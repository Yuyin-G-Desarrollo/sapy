Public Class TipoCarrito

    Private Ptipocarritoid As Integer
    Public Property tipocarritoid() As Integer
        Get
            Return Ptipocarritoid
        End Get
        Set(ByVal value As Integer)
            Ptipocarritoid = value
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
