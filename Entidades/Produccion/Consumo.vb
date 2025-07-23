Public Class Consumo
    ''' <summary>
    ''' 1 para insertar consumo, 2 para actualizar consumo
    ''' </summary>
    ''' <remarks></remarks>
    Private accion_ As Integer
    Public Property accion() As Integer
        Get
            Return accion_
        End Get
        Set(ByVal value As Integer)
            accion_ = value
        End Set
    End Property

    Private activo_ As Boolean = True
    Public Property activo() As Boolean
        Get
            Return activo_
        End Get
        Set(ByVal value As Boolean)
            activo_ = value
        End Set
    End Property
    Private idconsumo_ As Integer
    Public Property idconsumo() As Integer
        Get
            Return idconsumo_
        End Get
        Set(ByVal value As Integer)
            idconsumo_ = value
        End Set
    End Property

    Private totalConsumo_ As Double
    Public Property totalConsumo() As Double
        Get
            Return totalConsumo_
        End Get
        Set(ByVal value As Double)
            totalConsumo_ = value
        End Set
    End Property
    Private productoEstiloId_ As Integer
    Public Property productoEstiloId() As Integer
        Get
            Return productoEstiloId_
        End Get
        Set(ByVal value As Integer)
            productoEstiloId_ = value
        End Set
    End Property
    Private componenteid_ As Integer
    Public Property componenteid() As Integer
        Get
            Return componenteid_
        End Get
        Set(ByVal value As Integer)
            componenteid_ = value
        End Set
    End Property

    Private clasificacionid_ As Integer
    Public Property clasificacionid() As Integer
        Get
            Return clasificacionid_
        End Get
        Set(ByVal value As Integer)
            clasificacionid_ = value
        End Set
    End Property
    Private materialid_ As Integer
    Public Property materialId() As Integer
        Get
            Return materialid_
        End Get
        Set(ByVal value As Integer)
            materialid_ = value
        End Set
    End Property

    Private consumo_ As Double
    Public Property consumo() As Double
        Get
            Return consumo_
        End Get
        Set(ByVal value As Double)
            consumo_ = value
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
    Private umProveedorId_ As Integer
    Public Property umProveedorId() As Integer
        Get
            Return umProveedorId_
        End Get
        Set(ByVal value As Integer)
            umProveedorId_ = value
        End Set
    End Property

    Private umproduccionid_ As Integer
    Public Property umproduccionid() As Integer
        Get
            Return umproduccionid_
        End Get
        Set(ByVal value As Integer)
            umproduccionid_ = value
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
    Private preciocompra_ As Double
    Public Property preciocompra() As Double
        Get
            Return preciocompra_
        End Get
        Set(ByVal value As Double)
            preciocompra_ = value
        End Set
    End Property
    Private precioumproduccion_ As Double
    Public Property precioumproduccion() As Double
        Get
            Return precioumproduccion_
        End Get
        Set(ByVal value As Double)
            precioumproduccion_ = value
        End Set
    End Property
    Private costopar_ As Double
    Public Property costopar() As Double
        Get
            Return costopar_
        End Get
        Set(ByVal value As Double)
            costopar_ = value
        End Set
    End Property
    Private bloqueado_ As Boolean
    Public Property bloqueado() As Boolean
        Get
            Return bloqueado_
        End Get
        Set(ByVal value As Boolean)
            bloqueado_ = value
        End Set
    End Property

    Private explosionar_ As Boolean
    Public Property explosionar() As Boolean
        Get
            Return explosionar_
        End Get
        Set(ByVal value As Boolean)
            explosionar_ = value
        End Set
    End Property
    Private lotear_ As Boolean
    Public Property lotear() As Boolean
        Get
            Return lotear_
        End Get
        Set(ByVal value As Boolean)
            lotear_ = value
        End Set
    End Property

    Private usuariocreo_ As Integer
    Public Property usuariocreo() As Integer
        Get
            Return usuariocreo_
        End Get
        Set(ByVal value As Integer)
            usuariocreo_ = value
        End Set
    End Property

    Private usuariomodifico_ As Integer
    Public Property usuariomodifico() As Integer
        Get
            Return usuariomodifico_
        End Get
        Set(ByVal value As Integer)
            usuariomodifico_ = value
        End Set
    End Property

    Private fechacreacion_ As Date
    Public Property fechacreacion() As Date
        Get
            Return fechacreacion_
        End Get
        Set(ByVal value As Date)
            fechacreacion_ = value
        End Set
    End Property

    Private fechamodificacion_ As Date
    Public Property fechamodificacion() As Date
        Get
            Return fechamodificacion_
        End Get
        Set(ByVal value As Date)
            fechamodificacion_ = value
        End Set
    End Property
    Private noOrden_ As Integer
    Public Property noOrden() As Integer
        Get
            Return noOrden_
        End Get
        Set(ByVal value As Integer)
            noOrden_ = value
        End Set
    End Property

End Class
