Public Class PrecioMaterial

    Private idMaterialSICY_ As Integer
    Public Property idMaterialSICY() As Integer
        Get
            Return idMaterialSICY_
        End Get
        Set(ByVal value As Integer)
            idMaterialSICY_ = value
        End Set
    End Property

    Private idNaveSicy_ As Integer
    Public Property idNaveSICY() As Integer
        Get
            Return idNaveSicy_
        End Get
        Set(ByVal value As Integer)
            idNaveSicy_ = value
        End Set
    End Property
    Private idMaterialNave_ As Integer
    Public Property idMaterialNave() As Integer
        Get
            Return idMaterialNave_
        End Get
        Set(ByVal value As Integer)
            idMaterialNave_ = value
        End Set
    End Property
    Private existe_ As Integer
    Public Property existe() As Integer
        Get
            Return existe_
        End Get
        Set(ByVal value As Integer)
            existe_ = value
        End Set
    End Property
    Private preciosmaterialid_ As Integer = 0
    Public Property preciosmaterialid() As Integer
        Get
            Return preciosmaterialid_
        End Get
        Set(ByVal value As Integer)
            preciosmaterialid_ = value
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
    Private tiempodeEntrega_ As Double
    Public Property tiempodeEntrega() As Double
        Get
            Return tiempodeEntrega_
        End Get
        Set(ByVal value As Double)
            tiempodeEntrega_ = value
        End Set
    End Property

    Private precioUnitario_ As Double
    Public Property precioUnitario() As Double
        Get
            Return precioUnitario_
        End Get
        Set(ByVal value As Double)
            precioUnitario_ = value
        End Set
    End Property
    Private clasificacion_ As String
    Public Property clasificacion() As String
        Get
            Return clasificacion_
        End Get
        Set(ByVal value As String)
            clasificacion_ = value
        End Set
    End Property
    Private usuarioCreoid_ As Integer
    Public Property usuarioCreoid() As Integer
        Get
            Return usuarioCreoid_
        End Get
        Set(ByVal value As Integer)
            usuarioCreoid_ = value
        End Set
    End Property
    Private usuarioModificoid_ As Integer
    Public Property usuarioModificoid() As Integer
        Get
            Return usuarioModificoid_
        End Get
        Set(ByVal value As Integer)
            usuarioModificoid_ = value
        End Set
    End Property
    Private fechaRegistro_ As DateTime
    Public Property fechaRegistro() As DateTime
        Get
            Return fechaRegistro_
        End Get
        Set(ByVal value As DateTime)
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
    Private materialId_ As Integer
    Public Property materialId() As Integer
        Get
            Return materialId_
        End Get
        Set(ByVal value As Integer)
            materialId_ = value
        End Set
    End Property
    Private claveNave_ As String
    Public Property claveNave() As String
        Get
            Return claveNave_
        End Get
        Set(ByVal value As String)
            claveNave_ = value
        End Set
    End Property
    Private proveedorIdSICY_ As Integer
    Public Property proveedorIdSICY() As Integer
        Get
            Return proveedorIdSICY_
        End Get
        Set(ByVal value As Integer)
            proveedorIdSICY_ = value
        End Set
    End Property
    Private monedaId_ As Integer
    Public Property monedaId() As Integer
        Get
            Return monedaId_
        End Get
        Set(ByVal value As Integer)
            monedaId_ = value
        End Set
    End Property

    Private moneda_ As String
    Public Property moneda() As String
        Get
            Return moneda_
        End Get
        Set(ByVal value As String)
            moneda_ = value
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
    Private proveedordgId_ As Integer
    Public Property proveedordgId() As Integer
        Get
            Return proveedordgId_
        End Get
        Set(ByVal value As Integer)
            proveedordgId_ = value
        End Set
    End Property
    Private proveedor_ As String
    Public Property proveedor() As String
        Get
            Return proveedor_
        End Get
        Set(ByVal value As String)
            proveedor_ = value
        End Set
    End Property
    Private naveId_ As Integer
    Public Property naveId() As Integer
        Get
            Return naveId_
        End Get
        Set(ByVal value As Integer)
            naveId_ = value
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
    Private ump_ As String
    Public Property ump() As String
        Get
            Return ump_
        End Get
        Set(ByVal value As String)
            ump_ = value
        End Set
    End Property
    Private equivalenciaUMP_ As Double = 1
    Public Property equivalenciaUMP() As Double
        Get
            Return equivalenciaUMP_
        End Get
        Set(ByVal value As Double)
            equivalenciaUMP_ = value
        End Set
    End Property
    Private usuario_ As String
    Public Property usuario() As String
        Get
            Return usuario_
        End Get
        Set(ByVal value As String)
            usuario_ = value
        End Set
    End Property
    Private descripcionProv_ As String
    Public Property descripcionProv() As String
        Get
            Return descripcionProv_
        End Get
        Set(ByVal value As String)
            descripcionProv_ = value
        End Set
    End Property
    Private claveProveedor_ As String
    Public Property claveProveedor() As String
        Get
            Return claveProveedor_
        End Get
        Set(ByVal value As String)
            claveProveedor_ = value
        End Set
    End Property

    Private idumc_ As Integer
    Public Property idumc() As Integer
        Get
            Return idumc_
        End Get
        Set(ByVal value As Integer)
            idumc_ = value
        End Set
    End Property
    Private idump_ As Integer
    Public Property idump() As Integer
        Get
            Return idump_
        End Get
        Set(ByVal value As Integer)
            idump_ = value
        End Set
    End Property
    Private usuarioId_ As Integer
    Public Property usuarioId() As Integer
        Get
            Return usuarioId_
        End Get
        Set(ByVal value As Integer)
            usuarioId_ = value
        End Set
    End Property
    Private navedesarrollaid_ As Integer
    Public Property navedesarrollaid() As Integer
        Get
            Return navedesarrollaid_
        End Get
        Set(ByVal value As Integer)
            navedesarrollaid_ = value
        End Set
    End Property
    Private naveDesarrolla_ As String
    Public Property naveDesarrolla() As String
        Get
            Return naveDesarrolla_
        End Get
        Set(ByVal value As String)
            naveDesarrolla_ = value
        End Set
    End Property

    Private usuarioModifico_ As String

    Public Property usuarioModifico() As String
        Get
            Return usuarioModifico_
        End Get
        Set(ByVal value As String)
            usuarioModifico_ = value
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
