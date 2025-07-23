Public Class ZapateriaCompetenciaCliente

    Private Pzapateriascompetenciaclienteid As Integer
    Public Property zapateriascompetenciaclienteid() As Integer
        Get
            Return Pzapateriascompetenciaclienteid
        End Get
        Set(ByVal value As Integer)
            Pzapateriascompetenciaclienteid = value
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

    Private Pzapateria As ZapateriaCompetencia
    Public Property zapateria() As ZapateriaCompetencia
        Get
            Return Pzapateria
        End Get
        Set(ByVal value As ZapateriaCompetencia)
            Pzapateria = value
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
