Public Class RequerimientoEspCliente

    Private Prequerimientoespecialclienteid As Integer
    Public Property requerimientoespecialclienteid() As Integer
        Get
            Return Prequerimientoespecialclienteid
        End Get
        Set(ByVal value As Integer)
            Prequerimientoespecialclienteid = value
        End Set
    End Property

    Private Pvalor As String
    Public Property valor() As String
        Get
            Return Pvalor
        End Get
        Set(ByVal value As String)
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

    Private Prequerimientoespecial As RequerimientoEspecial
    Public Property requerimientoespecial() As RequerimientoEspecial
        Get
            Return Prequerimientoespecial
        End Get
        Set(ByVal value As RequerimientoEspecial)
            Prequerimientoespecial = value
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
