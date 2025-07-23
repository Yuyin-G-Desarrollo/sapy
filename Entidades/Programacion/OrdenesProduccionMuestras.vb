Public Class OrdenesProduccionMuestras

    Private _pdetorm_ordenproduccionid As Integer
    Public Property pdetorm_ordenproduccionid() As Integer
        Get
            Return _pdetorm_ordenproduccionid
        End Get
        Set(ByVal value As Integer)
            _pdetorm_ordenproduccionid = value
        End Set
    End Property


    Private _pdetorm_colaboradorencargadoid As Integer
    Public Property pdetorm_colaboradorencargadoid() As Integer
        Get
            Return _pdetorm_colaboradorencargadoid
        End Get
        Set(ByVal value As Integer)
            _pdetorm_colaboradorencargadoid = value
        End Set
    End Property


    Private _pdetorm_naveid As Integer
    Public Property pdetorm_naveid() As Integer
        Get
            Return _pdetorm_naveid
        End Get
        Set(ByVal value As Integer)
            _pdetorm_naveid = value
        End Set
    End Property



    Private _pdetorm_cantsolicitada As Integer
    Public Property pdetorm_cantsolicitada() As Integer
        Get
            Return _pdetorm_cantsolicitada
        End Get
        Set(ByVal value As Integer)
            _pdetorm_cantsolicitada = value
        End Set
    End Property

    Private _Disponible As Integer
    Public Property Disponible() As Integer
        Get
            Return _Disponible
        End Get
        Set(ByVal value As Integer)
            _Disponible = value
        End Set
    End Property

    Private _Apartados As Integer
    Public Property Apartados() As Integer
        Get
            Return _Apartados
        End Get
        Set(ByVal value As Integer)
            _Apartados = value
        End Set
    End Property

    Private _EnviarAproducir As Integer
    Public Property EnviarAproducir() As Integer
        Get
            Return _EnviarAproducir
        End Get
        Set(ByVal value As Integer)
            _EnviarAproducir = value
        End Set
    End Property


    Private _pdetorm_productoestiloid As Integer
    Public Property pdetorm_productoestiloid() As Integer
        Get
            Return _pdetorm_productoestiloid
        End Get
        Set(ByVal value As Integer)
            _pdetorm_productoestiloid = value
        End Set
    End Property


    '' CAMBIOS OAMB (22/05/2024) - Se agrega la columna de las partidas.
    Private _pdetm_partidaid As Integer
    Public Property pdetm_partidaid() As Integer
        Get
            Return _pdetm_partidaid
        End Get
        Set(ByVal value As Integer)
            _pdetm_partidaid = value
        End Set
    End Property


    Private _pdetorm_unidadmedidaid As Integer
    Public Property pdetorm_unidadmedidaid() As Integer
        Get
            Return _pdetorm_unidadmedidaid
        End Get
        Set(ByVal value As Integer)
            _pdetorm_unidadmedidaid = value
        End Set
    End Property

    Private _pdetorm_talla As String
    Public Property pdetorm_talla() As String
        Get
            Return _pdetorm_talla
        End Get
        Set(ByVal value As String)
            _pdetorm_talla = value
        End Set
    End Property

    Private _pdetorm_pedidoid As Integer
    Public Property pdetorm_pedidoid() As Integer
        Get
            Return _pdetorm_pedidoid
        End Get
        Set(ByVal value As Integer)
            _pdetorm_pedidoid = value
        End Set
    End Property


    Private _pdetorm_fechacorte As Date
    Public Property pdetorm_fechacorte() As Date
        Get
            Return _pdetorm_fechacorte
        End Get
        Set(ByVal value As Date)
            _pdetorm_fechacorte = value
        End Set
    End Property




    Private _pdetorm_cantpendiente As Integer
    Public Property pdetorm_cantpendiente() As Integer
        Get
            Return _pdetorm_cantpendiente
        End Get
        Set(ByVal value As Integer)
            _pdetorm_cantpendiente = value
        End Set
    End Property




    Private _pdetorm_usuariocreoid As Integer
    Public Property pdetorm_usuariocreoid() As Integer
        Get
            Return _pdetorm_usuariocreoid
        End Get
        Set(ByVal value As Integer)
            _pdetorm_usuariocreoid = value
        End Set
    End Property

    Private _pdetorm_fechacreacion As Date
    Public Property pdetorm_fechacreacion() As Date
        Get
            Return _pdetorm_fechacreacion
        End Get
        Set(ByVal value As Date)
            _pdetorm_fechacreacion = value
        End Set
    End Property

End Class
