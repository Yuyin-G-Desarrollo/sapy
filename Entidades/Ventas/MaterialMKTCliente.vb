Public Class MaterialMKTCliente

    Private Pmaterialmercadotecniaclienteid As Integer
    Public Property materialmercadotecniaclienteid() As Integer
        Get
            Return Pmaterialmercadotecniaclienteid
        End Get
        Set(ByVal value As Integer)
            Pmaterialmercadotecniaclienteid = value
        End Set
    End Property

    Private Pmaterialmercadotecnia As MaterialMKT
    Public Property materialmercadotecnia() As MaterialMKT
        Get
            Return Pmaterialmercadotecnia
        End Get
        Set(ByVal value As MaterialMKT)
            Pmaterialmercadotecnia = value
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
