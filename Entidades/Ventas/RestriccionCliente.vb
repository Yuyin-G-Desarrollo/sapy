Public Class RestriccionCliente

    Private Prestriccioclientenid As Integer
    Public Property restriccioclientenid() As Integer
        Get
            Return Prestriccioclientenid
        End Get
        Set(ByVal value As Integer)
            Prestriccioclientenid = value
        End Set
    End Property

    Private Pvalor As Integer
    Public Property valor() As Integer
        Get
            Return Pvalor
        End Get
        Set(ByVal value As Integer)
            Pvalor = value
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

    Private Prestriccion As Restriccion
    Public Property restriccion() As Restriccion
        Get
            Return Prestriccion
        End Get
        Set(ByVal value As Restriccion)
            Prestriccion = value
        End Set
    End Property

    Private Pcliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
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
