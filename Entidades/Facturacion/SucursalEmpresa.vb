Public Class SucursalEmpresa
    Private sucursalempresaid As Int32
    Private sucursalid As Int32
    Private empresaid As Int32
    Private serie As String
    Private folioactual As Int32
    Private folioinicio As Int32
    Private foliofinal As Int32
    Private reportefacturaid As Int32
    Private reportecancelacionid As Int32
    Private imprimirsucursal As Boolean
    Private activo As Boolean
    Private usuario As Int32
    Private fecha As Date


    Public Property SEId() As Int32
        Get
            Return sucursalempresaid
        End Get
        Set(ByVal value As Int32)
            sucursalempresaid = value
        End Set
    End Property

    Public Property SESucursalid() As Int32
        Get
            Return sucursalid
        End Get
        Set(ByVal value As Int32)
            sucursalid = value
        End Set
    End Property

    Public Property SEEmpresaid() As Int32
        Get
            Return empresaid
        End Get
        Set(ByVal value As Int32)
            empresaid = value
        End Set
    End Property

    Public Property SESerie() As String
        Get
            Return serie
        End Get
        Set(ByVal value As String)
            serie = value
        End Set
    End Property

    Public Property SEFolioactual() As Int32
        Get
            Return folioactual
        End Get
        Set(ByVal value As Int32)
            folioactual = value
        End Set
    End Property

    Public Property SEFolioinicio() As Int32
        Get
            Return folioinicio
        End Get
        Set(ByVal value As Int32)
            folioinicio = value
        End Set
    End Property

    Public Property SEFoliofinal() As Int32
        Get
            Return foliofinal
        End Get
        Set(ByVal value As Int32)
            foliofinal = value
        End Set
    End Property

    Public Property SEReportefacturaid() As Int32
        Get
            Return reportefacturaid
        End Get
        Set(ByVal value As Int32)
            reportefacturaid = value
        End Set
    End Property

    Public Property SEReportecancelacionid() As Int32
        Get
            Return reportecancelacionid
        End Get
        Set(ByVal value As Int32)
            reportecancelacionid = value
        End Set
    End Property

    Public Property SEImprimirsucursal() As Boolean
        Get
            Return imprimirsucursal
        End Get
        Set(ByVal value As Boolean)
            imprimirsucursal = value
        End Set
    End Property

    Public Property SEActivo() As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property

    Public Property SEUsuario() As Int32
        Get
            Return usuario
        End Get
        Set(ByVal value As Int32)
            usuario = value
        End Set
    End Property

    Public Property SEFecha() As Date
        Get
            Return fecha
        End Get
        Set(ByVal value As Date)
            fecha = value
        End Set
    End Property
End Class
