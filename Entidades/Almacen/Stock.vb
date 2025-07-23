Public Class Stock
    Private pedidoID As Integer
    Private agenteID As Integer
    Private clienteID As Integer
    Private usuarioCreoID As Integer
    Private estatus As String
    Private productoId As Integer
    Private corrida As String
    Private talla As Double
    Private corridaSICY As String
    Private pares As Integer
    Private codigo As String
    Private docenas As Integer
    Private original As Integer
    Private tipoCorrida As String
    Private estatusid As Integer
    Private tipoMovimiento As Integer
    Private partida As Integer
    Private pedidoDetalleID As Integer

    Public Property PpedidoDetalleID As Integer
        Get
            Return pedidoDetalleID
        End Get
        Set(value As Integer)
            pedidoDetalleID = value
        End Set
    End Property


    Public Property Ppartida As Integer
        Get
            Return partida
        End Get
        Set(value As Integer)
            partida = value
        End Set
    End Property


    Public Property PtipoMovimiento As Integer
        Get
            Return tipoMovimiento
        End Get
        Set(value As Integer)
            tipoMovimiento = value
        End Set
    End Property



    Public Property Pestatusid As Integer
        Get
            Return estatusid
        End Get
        Set(value As Integer)
            estatusid = value
        End Set
    End Property

    Public Property PtipoCorrida As String
        Get
            Return tipoCorrida
        End Get
        Set(value As String)
            tipoCorrida = value
        End Set
    End Property

    Public Property Poriginal As Integer
        Get
            Return original
        End Get
        Set(value As Integer)
            original = value
        End Set
    End Property

    Public Property Pdocenas As Integer
        Get
            Return docenas
        End Get
        Set(value As Integer)
            docenas = value
        End Set
    End Property


    Public Property PpedidoID As Integer
        Get
            Return pedidoID
        End Get
        Set(value As Integer)
            pedidoID = value
        End Set
    End Property

    Public Property PagenteID As Integer
        Get
            Return agenteID
        End Get
        Set(value As Integer)
            agenteID = value
        End Set
    End Property

    Public Property PclienteID As Integer
        Get
            Return clienteID
        End Get
        Set(value As Integer)
            clienteID = value
        End Set
    End Property

    Public Property PusuarioCreoID As Integer
        Get
            Return usuarioCreoID
        End Get
        Set(value As Integer)
            usuarioCreoID = value
        End Set
    End Property

    Public Property Pestatus As String
        Get
            Return estatus
        End Get
        Set(value As String)
            estatus = value
        End Set
    End Property


    Public Property PproductoID As Integer
        Get
            Return productoId
        End Get
        Set(value As Integer)
            productoId = value
        End Set
    End Property

    Public Property Pcorrida As String
        Get
            Return corrida
        End Get
        Set(value As String)
            corrida = value
        End Set
    End Property

    Public Property Ptalla As Double
        Get
            Return talla
        End Get
        Set(value As Double)
            talla = value
        End Set
    End Property

    Public Property PcorridaSICY As String
        Get
            Return corridaSICY
        End Get
        Set(value As String)
            corridaSICY = value
        End Set
    End Property

    Public Property Ppares As Integer
        Get
            Return pares
        End Get
        Set(value As Integer)
            pares = value
        End Set
    End Property

    Public Property Pcodigo As String
        Get
            Return codigo
        End Get
        Set(value As String)
            codigo = value
        End Set
    End Property
End Class
