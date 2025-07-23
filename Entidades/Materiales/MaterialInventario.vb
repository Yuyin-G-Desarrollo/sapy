Public Class MaterialInventario

    Private invn_naveid_ As Integer
    Public Property invn_naveid() As Integer
        Get
            Return invn_naveid_
        End Get
        Set(ByVal value As Integer)
            invn_naveid_ = value
        End Set
    End Property

    Private invn_materialnaveid_ As Integer
    Public Property invn_materialnaveid() As Integer
        Get
            Return invn_materialnaveid_
        End Get
        Set(ByVal value As Integer)
            invn_materialnaveid_ = value
        End Set
    End Property

    Private invn_proveedorid_ As Integer
    Public Property invn_proveedorid() As Integer
        Get
            Return invn_proveedorid_
        End Get
        Set(ByVal value As Integer)
            invn_proveedorid_ = value
        End Set
    End Property

    Private invn_movimientoinventarioid_ As Integer
    Public Property invn_movimientoinventarioid() As Integer
        Get
            Return invn_movimientoinventarioid_
        End Get
        Set(ByVal value As Integer)
            invn_movimientoinventarioid_ = value
        End Set
    End Property

    Private invn_cantidad_ As Double
    Public Property invn_cantidad() As Double
        Get
            Return invn_cantidad_
        End Get
        Set(ByVal value As Double)
            invn_cantidad_ = value
        End Set
    End Property

    Private invn_umc_ As Integer
    Public Property invn_umc() As Integer
        Get
            Return invn_umc_
        End Get
        Set(ByVal value As Integer)
            invn_umc_ = value
        End Set
    End Property

    Private invn_precio_ As Double
    Public Property invn_precio() As Double
        Get
            Return invn_precio_
        End Get
        Set(ByVal value As Double)
            invn_precio_ = value
        End Set
    End Property

    Private invn_factorconversion_ As Double
    Public Property invn_factorconversion() As Double
        Get
            Return invn_factorconversion_
        End Get
        Set(ByVal value As Double)
            invn_factorconversion_ = value
        End Set
    End Property

    Private invn_inventariototal_ As Double
    Public Property invn_inventariototal() As Double
        Get
            Return invn_inventariototal_
        End Get
        Set(ByVal value As Double)
            invn_inventariototal_ = value
        End Set
    End Property

    Private invn_ump_ As Integer
    Public Property invn_ump() As Integer
        Get
            Return invn_ump_
        End Get
        Set(ByVal value As Integer)
            invn_ump_ = value
        End Set
    End Property

    Private invn_usuariocreoid_ As Integer
    Public Property invn_usuariocreoid() As Integer
        Get
            Return invn_usuariocreoid_
        End Get
        Set(ByVal value As Integer)
            invn_usuariocreoid_ = value
        End Set
    End Property

    Private invn_fechacreoid_ As Date
    Public Property invn_fechacreoid() As Date
        Get
            Return invn_fechacreoid_
        End Get
        Set(ByVal value As Date)
            invn_fechacreoid_ = value
        End Set
    End Property

    Private invn_monedaid_ As Integer
    Public Property invn_monedaid() As Integer
        Get
            Return invn_monedaid_
        End Get
        Set(ByVal value As Integer)
            invn_monedaid_ = value
        End Set
    End Property
End Class
