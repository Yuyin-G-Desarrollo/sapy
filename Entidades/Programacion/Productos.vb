Public Class Productos

    Private idProducto As Int32
    Private codigoProducto As String
    Private descripcionProducto As String
    Private marcaIdProducto As Int32
    'Private familiaIdProducto As String
    Private coleccionIdProducto As Int32
    Private grupoIdProducto As Int32
    Private temporadaidProducto As Int32
    Private activoProducto As Boolean
    Private codigoSicy As String
    Private subfamilia As String
    Private foto As String
    Private dibujo As String
    Private consecutivo As String
    Private horma As Int32
    Private codCliente As String
    Private categoria As Int32
    Private idNaveDesarrolla_ As Integer = 0
    Private modeloSAYLicencia As String
    Public Property idNaveDesarrolla As Integer
        Get
            Return idNaveDesarrolla_
        End Get
        Set(ByVal value As Integer)
            idNaveDesarrolla_ = value
        End Set
    End Property


    Public Property PidProd As Int32
        Get
            Return idProducto
        End Get
        Set(ByVal value As Int32)
            idProducto = value
        End Set
    End Property

    Public Property PCodigoProd As String
        Get
            Return codigoProducto
        End Get
        Set(ByVal value As String)
            codigoProducto = value
        End Set
    End Property

    Public Property PDescripcionProd As String
        Get
            Return descripcionProducto
        End Get
        Set(ByVal value As String)
            descripcionProducto = value
        End Set
    End Property

    Public Property PMarcaProd As Int32
        Get
            Return marcaIdProducto
        End Get
        Set(ByVal value As Int32)
            marcaIdProducto = value
        End Set
    End Property

    'Public Property PFamiliaProd As String
    '    Get
    '        Return familiaIdProducto
    '    End Get
    '    Set(ByVal value As String)
    '        familiaIdProducto = value
    '    End Set
    'End Property


    Public Property PColeccionProd As Int32
        Get
            Return coleccionIdProducto
        End Get
        Set(ByVal value As Int32)
            coleccionIdProducto = value
        End Set
    End Property

    Public Property PGrupoProd As Int32
        Get
            Return grupoIdProducto
        End Get
        Set(ByVal value As Int32)
            grupoIdProducto = value
        End Set
    End Property

    Public Property PTemporadaProd As Int32
        Get
            Return temporadaidProducto
        End Get
        Set(ByVal value As Int32)
            temporadaidProducto = value
        End Set
    End Property


    Public Property PActivoProd As Boolean
        Get
            Return activoProducto
        End Get
        Set(ByVal value As Boolean)
            activoProducto = value
        End Set
    End Property

    Public Property PCodigoSicy As String
        Get
            Return codigoSicy
        End Get
        Set(ByVal value As String)
            codigoSicy = value
        End Set
    End Property

    Public Property PSubfamilia As String
        Get
            Return subfamilia
        End Get
        Set(ByVal value As String)
            subfamilia = value
        End Set
    End Property

    Public Property PFoto As String
        Get
            Return foto
        End Get
        Set(ByVal value As String)
            foto = value
        End Set
    End Property

    Public Property PDibujo As String
        Get
            Return dibujo
        End Get
        Set(ByVal value As String)
            dibujo = value
        End Set
    End Property

    Public Property PConsecutivo As String
        Get
            Return consecutivo
        End Get
        Set(ByVal value As String)
            consecutivo = value
        End Set
    End Property

    Public Property PHorma As Int32
        Get
            Return horma
        End Get
        Set(ByVal value As Int32)
            horma = value
        End Set
    End Property

    Public Property PCodCliente As String
        Get
            Return codCliente
        End Get
        Set(ByVal value As String)
            codCliente = value
        End Set
    End Property

    Public Property PCategoria As Int32
        Get
            Return categoria
        End Get
        Set(value As Int32)
            categoria = value
        End Set
    End Property

    Public Property PmodeloSAYLicencia As String
        Get
            Return modeloSAYLicencia
        End Get
        Set(ByVal value As String)
            modeloSAYLicencia = value
        End Set
    End Property
End Class
