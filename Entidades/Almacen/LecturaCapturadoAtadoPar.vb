Public Class LecturaCapturadoAtadoPar
    Dim codigoatado As String
    Dim codigopar As String
    Dim Estatus As Boolean
    Dim Lote As String
    Dim Descripcion As String
    Dim Talla As String
    Dim CodigoCliente As String
    Dim Leido As Boolean = False


    Public Property PLeido As Boolean
        Get
            Return Leido
        End Get
        Set(value As Boolean)
            Leido = value
        End Set
    End Property

    Public Property PCodigoCliente As String
        Get
            Return CodigoCliente
        End Get
        Set(value As String)
            CodigoCliente = value
        End Set
    End Property



    Public Property PTalla As String
        Get
            Return Talla
        End Get
        Set(value As String)
            Talla = value
        End Set
    End Property


    Public Property PDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property PLote As String
        Get
            Return Lote
        End Get
        Set(value As String)
            Lote = value
        End Set
    End Property

    Public Property PEstatus As Boolean
        Get
            Return Estatus
        End Get
        Set(value As Boolean)
            Estatus = value
        End Set
    End Property


    Public Property pcodigopar As String
        Get
            Return codigopar
        End Get
        Set(value As String)
            codigopar = value
        End Set
    End Property

    Public Property pcodigoatado As String
        Get
            Return codigoatado
        End Get
        Set(value As String)
            codigoatado = value
        End Set
    End Property


End Class
