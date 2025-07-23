Public Class Material
    Private materialIdNave_ As Integer
    Public Property materialIdNave() As Integer
        Get
            Return materialIdNave_
        End Get
        Set(ByVal value As Integer)
            materialIdNave_ = value
        End Set
    End Property
    Private materiaEstatus_ As Char
    Public Property materialEstatus() As Char
        Get
            Return materiaEstatus_
        End Get
        Set(ByVal value As Char)
            materiaEstatus_ = value
        End Set
    End Property
    Private materialNombre_ As String
    Public Property materiaNombre() As String
        Get
            Return materialNombre_
        End Get
        Set(ByVal value As String)
            materialNombre_ = value
        End Set
    End Property
    Private materialIdSICY_ As Integer
    Public Property materialIdSICY() As Integer
        Get
            Return materialIdSICY_
        End Get
        Set(ByVal value As Integer)
            materialIdSICY_ = value
        End Set
    End Property

    Private materialId_ As Integer
    Public Property materialId() As Integer
        Get
            Return materialId_
        End Get
        Set(ByVal value As Integer)
            materialId_ = value
        End Set
    End Property
    Private usuarioCreo_ As Integer
    Public Property usuarioCreo() As Integer
        Get
            Return usuarioCreo_
        End Get
        Set(ByVal value As Integer)
            usuarioCreo_ = value
        End Set
    End Property
    Private usuarioModifico_ As Integer
    Public Property usuarioModifico() As Integer
        Get
            Return usuarioModifico_
        End Get
        Set(ByVal value As Integer)
            usuarioModifico_ = value
        End Set
    End Property
    Private proveedorId_ As Integer
    Public Property proveedorId() As Integer
        Get
            Return proveedorId_
        End Get
        Set(ByVal value As Integer)
            proveedorId_ = value
        End Set
    End Property
    Private fechaRegistro_ As Date
    Public Property fechaRegistro() As Date
        Get
            Return fechaRegistro_
        End Get
        Set(ByVal value As Date)
            fechaRegistro_ = value
        End Set
    End Property
    Private fechaModificacion_ As Date
    Public Property fechaModificacion() As Date
        Get
            Return fechaModificacion_
        End Get
        Set(ByVal value As Date)
            fechaModificacion_ = value
        End Set
    End Property
    Private descripcion_ As String
    Public Property descripcion() As String
        Get
            Return descripcion_
        End Get
        Set(ByVal value As String)
            descripcion_ = value
        End Set
    End Property
    Private activo_ As String
    Public Property activo() As String
        Get
            Return activo_
        End Get
        Set(ByVal value As String)
            activo_ = value
        End Set
    End Property
    Private sku_ As String
    Public Property sku() As String
        Get
            Return sku_
        End Get
        Set(ByVal value As String)
            sku_ = value
        End Set
    End Property
    Private umc_ As String
    Public Property umc() As String
        Get
            Return umc_
        End Get
        Set(ByVal value As String)
            umc_ = value
        End Set
    End Property
    Private equivalenciaumc_ As Double
    Public Property equivalenciaumc() As Double
        Get
            Return equivalenciaumc_
        End Get
        Set(ByVal value As Double)
            equivalenciaumc_ = value
        End Set
    End Property
    Private categoria_ As Integer
    Public Property categoria() As Integer
        Get
            Return categoria_
        End Get
        Set(ByVal value As Integer)
            categoria_ = value
        End Set
    End Property
    Private departamento_ As Integer
    Public Property departamento() As Integer
        Get
            Return departamento_
        End Get
        Set(ByVal value As Integer)
            departamento_ = value
        End Set
    End Property
    Private tipoMaterial_ As Integer
    Public Property tipoMaterial() As Integer
        Get
            Return tipoMaterial_
        End Get
        Set(ByVal value As Integer)
            tipoMaterial_ = value
        End Set
    End Property
    Private critico_ As String
    Public Property critico() As String
        Get
            Return critico_
        End Get
        Set(ByVal value As String)
            critico_ = value
        End Set
    End Property
    Private idMaterialRemplazo_ As Integer
    Public Property idMaterialRemplazo() As Integer
        Get
            Return idMaterialRemplazo_
        End Get
        Set(ByVal value As Integer)
            idMaterialRemplazo_ = value
        End Set
    End Property
    Private clasificacion_ As Integer
    Public Property clasificacion() As Integer
        Get
            Return clasificacion_
        End Get
        Set(ByVal value As Integer)
            clasificacion_ = value
        End Set
    End Property
    Private idNave_ As Integer
    Public Property idNave() As Integer
        Get
            Return idNave_
        End Get
        Set(ByVal value As Integer)
            idNave_ = value
        End Set
    End Property
    Private idColor_ As Integer = 0
    Public Property idColor() As Integer
        Get
            Return idColor_
        End Get
        Set(ByVal value As Integer)
            idColor_ = value
        End Set
    End Property
    Private idTamaño_ As Integer = 0
    Public Property idTamaño() As Integer
        Get
            Return idTamaño_
        End Get
        Set(ByVal value As Integer)
            idTamaño_ = value
        End Set
    End Property
    Private idNaveDesarrolla_ As Integer
    Public Property idNaveDesarrolla() As Integer
        Get
            Return idNaveDesarrolla_
        End Get
        Set(ByVal value As Integer)
            idNaveDesarrolla_ = value
        End Set
    End Property
    Private exclusivo_ As Integer
    Public Property exclusivo() As Integer
        Get
            Return exclusivo_
        End Get
        Set(ByVal value As Integer)
            exclusivo_ = value
        End Set
    End Property

    Private origenpreciomaterial_ As String
    Public Property origenpreciomaterial() As String
        Get
            Return origenpreciomaterial_
        End Get
        Set(ByVal value As String)
            origenpreciomaterial_ = value
        End Set
    End Property
End Class
