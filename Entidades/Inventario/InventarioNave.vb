Public Class InventarioNave

    Private inventarionaveid_ As Integer
    Public Property inventarionaveid() As Integer
        Get
            Return inventarionaveid_
        End Get
        Set(ByVal value As Integer)
            inventarionaveid_ = value
        End Set
    End Property

    Private naveid_ As Integer
    Public Property naveid() As Integer
        Get
            Return naveid_
        End Get
        Set(ByVal value As Integer)
            naveid_ = value
        End Set
    End Property

    Private materialnaveid_ As Integer
    Public Property materialnaveid() As Integer
        Get
            Return materialnaveid_
        End Get
        Set(ByVal value As Integer)
            materialnaveid_ = value
        End Set
    End Property

    Private proveedorid_ As Integer
    Public Property proveedorid() As Integer
        Get
            Return proveedorid_
        End Get
        Set(ByVal value As Integer)
            proveedorid_ = value
        End Set
    End Property

    Private ordencompraid_ As Integer
    Public Property ordencompraid() As Integer
        Get
            Return ordencompraid_
        End Get
        Set(ByVal value As Integer)
            ordencompraid_ = value
        End Set
    End Property

    Private fechaprograma_ As Date
    Public Property fechaprograma() As Date
        Get
            Return fechaprograma_
        End Get
        Set(ByVal value As Date)
            fechaprograma_ = value
        End Set
    End Property

    Private movimientoinventarioid_ As Integer
    Public Property movimientoinventarioid() As Integer
        Get
            Return movimientoinventarioid_
        End Get
        Set(ByVal value As Integer)
            movimientoinventarioid_ = value
        End Set
    End Property

    Private cantidad_ As Double
    Public Property cantidad() As Double
        Get
            Return cantidad_
        End Get
        Set(ByVal value As Double)
            cantidad_ = value
        End Set
    End Property

    Private umc_ As Integer
    Public Property umc() As Integer
        Get
            Return umc_
        End Get
        Set(ByVal value As Integer)
            umc_ = value
        End Set
    End Property

    Private precio_ As Double
    Public Property precio() As Double
        Get
            Return precio_
        End Get
        Set(ByVal value As Double)
            precio_ = value
        End Set
    End Property

    Private factorconversion_ As Double
    Public Property factorconversion() As Double
        Get
            Return factorconversion_
        End Get
        Set(ByVal value As Double)
            factorconversion_ = value
        End Set
    End Property

    Private cantidadsalida_ As Double
    Public Property cantidadsalida() As Double
        Get
            Return cantidadsalida_
        End Get
        Set(ByVal value As Double)
            cantidadsalida_ = value
        End Set
    End Property

    Private ump_ As Integer
    Public Property ump() As Integer
        Get
            Return ump_
        End Get
        Set(ByVal value As Integer)
            ump_ = value
        End Set
    End Property

    Private usuariocreoid_ As Integer
    Public Property usuariocreoid() As Integer
        Get
            Return usuariocreoid_
        End Get
        Set(ByVal value As Integer)
            usuariocreoid_ = value
        End Set
    End Property

    Private fechacreoid_ As Date
    Public Property fechacreoid() As Date
        Get
            Return fechacreoid_
        End Get
        Set(ByVal value As Date)
            fechacreoid_ = value
        End Set
    End Property

    Private cerrado_ As Boolean
    Public Property cerrado() As Boolean
        Get
            Return cerrado_
        End Get
        Set(ByVal value As Boolean)
            cerrado_ = value
        End Set
    End Property

    Private fechacerrado_ As Date
    Public Property fechacerrado() As Date
        Get
            Return fechacerrado_
        End Get
        Set(ByVal value As Date)
            fechacerrado_ = value
        End Set
    End Property

    Private invn_observaciones_ As String = ""
    Public Property invn_observaciones() As String
        Get
            Return invn_observaciones_
        End Get
        Set(ByVal value As String)
            invn_observaciones_ = value
        End Set
    End Property
    Private inventarioinicial_ As Double
    Public Property inventarioinicial() As Double
        Get
            Return inventarioinicial_
        End Get
        Set(ByVal value As Double)
            inventarioinicial_ = value
        End Set
    End Property
    Private inventariofinal_ As Double
    Public Property inventariofinal() As Double
        Get
            Return inventariofinal_
        End Get
        Set(ByVal value As Double)
            inventariofinal_ = value
        End Set
    End Property

    Private nombreNave_ As String
    Public Property nombreNave() As String
        Get
            Return nombreNave_
        End Get
        Set(ByVal value As String)
            nombreNave_ = value
        End Set
    End Property

    Private totalDinero_ As Double
    Public Property totalDinero() As Double
        Get
            Return totalDinero_
        End Get
        Set(ByVal value As Double)
            totalDinero_ = value
        End Set
    End Property
    Private nombreMaterial_ As String
    Public Property nombreMaterial() As String
        Get
            Return nombreMaterial_
        End Get
        Set(ByVal value As String)
            nombreMaterial_ = value
        End Set
    End Property

    Private umcMaterial_ As String
    Public Property umcMaterial() As String
        Get
            Return umcMaterial_
        End Get
        Set(ByVal value As String)
            umcMaterial_ = value
        End Set
    End Property
    Private monedaid_ As Integer
    Public Property monedaid() As Integer
        Get
            Return monedaid_
        End Get
        Set(ByVal value As Integer)
            monedaid_ = value
        End Set
    End Property
End Class
