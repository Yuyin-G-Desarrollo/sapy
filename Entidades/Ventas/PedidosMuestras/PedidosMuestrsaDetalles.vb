Public Class PedidosMuestrsaDetalles

    Private _ProductoEstilo As Integer
    Public Property ProductoEstilo() As Integer
        Get
            Return _ProductoEstilo
        End Get
        Set(ByVal value As Integer)
            _ProductoEstilo = value
        End Set
    End Property

    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _pielColor As String
    Public Property pielColor() As String
        Get
            Return _pielColor
        End Get
        Set(ByVal value As String)
            _pielColor = value
        End Set
    End Property

    Private _talla As String
    Public Property talla() As String
        Get
            Return _talla
        End Get
        Set(ByVal value As String)
            _talla = value
        End Set
    End Property


    Private _familia As String
    Public Property familia() As String
        Get
            Return _familia
        End Get
        Set(ByVal value As String)
            _familia = value
        End Set
    End Property

    Private _linea As String
    Public Property linea() As String
        Get
            Return _linea
        End Get
        Set(ByVal value As String)
            _linea = value
        End Set
    End Property


    Private _familia_Ventas As String
    Public Property familia_Ventas() As String
        Get
            Return _familia_Ventas
        End Get
        Set(ByVal value As String)
            _familia_Ventas = value
        End Set
    End Property

    Private _corte As String
    Public Property corte() As String
        Get
            Return _corte
        End Get
        Set(ByVal value As String)
            _corte = value
        End Set
    End Property


    Private _forro As String
    Public Property forro() As String
        Get
            Return _forro
        End Get
        Set(ByVal value As String)
            _forro = value
        End Set
    End Property

    Private _suela As String
    Public Property suela() As String
        Get
            Return _suela
        End Get
        Set(ByVal value As String)
            _suela = value
        End Set
    End Property




    Private _Horma As String
    Public Property Horma() As String
        Get
            Return _Horma
        End Get
        Set(ByVal value As String)
            _Horma = value
        End Set
    End Property


    Private _Sicy As String
    Public Property Sicy() As String
        Get
            Return _Sicy
        End Get
        Set(ByVal value As String)
            _Sicy = value
        End Set
    End Property


    Private _Estatus As String
    Public Property Estatus As String
        Get
            Return _Estatus
        End Get
        Set(ByVal value As String)
            _Estatus = value
        End Set
    End Property

    Private _Tipo As String
    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

End Class
