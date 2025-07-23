Public Class MaterialOrdenDeCompra

    Private materialordendecompraid As Integer
    Public Property maoc_materialordendecompraid() As Integer
        Get
            Return materialordendecompraid
        End Get
        Set(ByVal value As Integer)
            materialordendecompraid = value
        End Set
    End Property

    Private materialpreciosid As Integer
    Public Property maoc_materialpreciosid() As Integer
        Get
            Return materialpreciosid
        End Get
        Set(ByVal value As Integer)
            materialpreciosid = value
        End Set
    End Property

    Private cantidad As Double
    Public Property maoc_cantidad() As Double
        Get
            Return cantidad
        End Get
        Set(ByVal value As Double)
            cantidad = value
        End Set
    End Property

    Private preciounitario As Double
    Public Property maoc_preciounitario() As Double
        Get
            Return preciounitario
        End Get
        Set(ByVal value As Double)
            preciounitario = value
        End Set
    End Property

    Private umpid As String
    Public Property maoc_umpid() As String
        Get
            Return umpid
        End Get
        Set(ByVal value As String)
            umpid = value
        End Set
    End Property

    Private umcid As String
    Public Property maoc_umcid() As String
        Get
            Return umcid
        End Get
        Set(ByVal value As String)
            umcid = value
        End Set
    End Property

    Private ordencompraid As String
    Public Property maoc_ordencompraid() As String
        Get
            Return ordencompraid
        End Get
        Set(ByVal value As String)
            ordencompraid = value
        End Set
    End Property

    Private usuariocreoid As String
    Public Property maoc_usuariocreoid() As String
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As String)
            usuariocreoid = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property maoc_fechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property maoc_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechamodificacion As String
    Public Property maoc_fechamodificacion() As String
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As String)
            fechamodificacion = value
        End Set
    End Property

    Private estatusmaterial As String
    Public Property maoc_estatusmaterial() As String
        Get
            Return estatusmaterial
        End Get
        Set(ByVal value As String)
            estatusmaterial = value
        End Set
    End Property

    Private materialid As Integer
    Public Property maoc_materialid() As Integer
        Get
            Return materialid
        End Get
        Set(ByVal value As Integer)
            materialid = value
        End Set
    End Property


End Class

