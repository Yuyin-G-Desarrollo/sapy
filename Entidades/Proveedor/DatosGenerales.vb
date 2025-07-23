Public Class DatosGenerales

    Private activo As String
    Public Property dage_activo() As String
        Get
            Return activo
        End Get
        Set(ByVal value As String)
            activo = value
        End Set
    End Property
    Private idtipoRazon As Integer
    Public Property dage_idtiporazon() As Integer
        Get
            Return idtipoRazon
        End Get
        Set(ByVal value As Integer)
            idtipoRazon = value
        End Set
    End Property


    Private nombrecomercial As String
    Public Property dage_nombrecomercial() As String
        Get
            Return nombrecomercial
        End Get
        Set(ByVal value As String)
            nombrecomercial = value
        End Set
    End Property

    Private categoria As Integer
    Public Property dage_categoria() As Integer
        Get
            Return categoria
        End Get
        Set(ByVal value As Integer)
            categoria = value
        End Set
    End Property

    Private giro As Integer
    Public Property dage_giro() As Integer
        Get
            Return giro
        End Get
        Set(ByVal value As Integer)
            giro = value
        End Set
    End Property

Private paginaweb As String
    Public Property dage_paginaweb() As String
        Get
            Return paginaweb
        End Get
        Set(ByVal value As String)
            paginaweb = value
        End Set
    End Property

Private tipodecompra As String
    Public Property dage_tipodecompra() As String
        Get
            Return tipodecompra
        End Get
        Set(ByVal value As String)
            tipodecompra = value
        End Set
    End Property

    Private limitedecredito As Double
    Public Property dage_limitedecredito() As Double
        Get
            Return limitedecredito
        End Get
        Set(ByVal value As Double)
            limitedecredito = value
        End Set
    End Property

Private tiempodeentrega As String
    Public Property dage_tiempodeentrega() As String
        Get
            Return tiempodeentrega
        End Get
        Set(ByVal value As String)
            tiempodeentrega = value
        End Set
    End Property

Private tiempoderespuesta As String
    Public Property dage_tiempoderespuesta() As String
        Get
            Return tiempoderespuesta
        End Get
        Set(ByVal value As String)
            tiempoderespuesta = value
        End Set
    End Property

Private usuariocreoid As integer
    Public Property dage_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property dage_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property dage_fechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As Date
    Public Property dage_fechamodificacion() As Date
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As Date)
            fechamodificacion = value
        End Set
    End Property

    Private pais As String
    Public Property dage_pais() As String
        Get
            Return pais
        End Get
        Set(ByVal value As String)
            pais = value
        End Set
    End Property

    Private paisid As Integer
    Public Property dage_paisid() As Integer
        Get
            Return paisid
        End Get
        Set(ByVal value As Integer)
            paisid = value
        End Set
    End Property


    Private proveedorid As Integer
    Public Property dage_proveedorid() As Integer
        Get
            Return proveedorid
        End Get
        Set(ByVal value As Integer)
            proveedorid = value
        End Set
    End Property

End Class


