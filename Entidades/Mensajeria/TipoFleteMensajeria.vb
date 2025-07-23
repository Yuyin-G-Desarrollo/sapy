Public Class TipoFleteMensajeria
    Private ptipofletemensajeriaid As Int32
    Private ptipofleteid As Int32
    Private pproveedorid As Int32
    Private ptipotletenombre As String
    Private pactivo As Boolean

    Public Property tipofletenombre As String
        Get
            Return ptipotletenombre
        End Get
        Set(value As String)
            ptipotletenombre = value
        End Set
    End Property


    Public Property tipofletemensajeriaid As Int32
        Get
            Return ptipofletemensajeriaid
        End Get
        Set(value As Int32)
            ptipofletemensajeriaid = value
        End Set
    End Property
    Public Property tipofleteid As Int32
        Get
            Return ptipofleteid
        End Get
        Set(value As Int32)
            ptipofleteid = value
        End Set
    End Property
    Public Property proveedorid As Int32
        Get
            Return pproveedorid
        End Get
        Set(value As Int32)
            pproveedorid = value
        End Set
    End Property
    Public Property activo As Boolean
        Get
            Return pactivo
        End Get
        Set(value As Boolean)
            pactivo = value
        End Set
    End Property

End Class
