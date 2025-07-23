Public Class Fracciones
    Private noOrden_ As Integer
    Public Property noOrden() As Integer
        Get
            Return noOrden_
        End Get
        Set(ByVal value As Integer)
            noOrden_ = value
        End Set
    End Property

    Private accion_ As Integer
    Public Property accion() As Integer
        Get
            Return accion_
        End Get
        Set(ByVal value As Integer)
            accion_ = value
        End Set
    End Property

    Private departamentogeneralid_ As Integer
    Public Property departamentogeneralid() As Integer
        Get
            Return departamentogeneralid_
        End Get
        Set(ByVal value As Integer)
            departamentogeneralid_ = value
        End Set
    End Property


    Private fraccionidProd_ As Integer
    Public Property fraccionidProd() As Integer
        Get
            Return fraccionidProd_
        End Get
        Set(ByVal value As Integer)
            fraccionidProd_ = value
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

    Private fraccionid As Integer
    Public Property frap_fraccionid() As Integer
        Get
            Return fraccionid
        End Get
        Set(ByVal value As Integer)
            fraccionid = value
        End Set
    End Property

    Private descripcion As String
    Public Property frap_descripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private paga As Integer
    Public Property frap_paga() As Integer
        Get
            Return paga
        End Get
        Set(ByVal value As Integer)
            paga = value
        End Set
    End Property

    Private tiempo As Double
    Public Property frap_tiempo() As Double
        Get
            Return tiempo
        End Get
        Set(ByVal value As Double)
            tiempo = value
        End Set
    End Property

    Private precio As Double
    Public Property frap_precio() As Double
        Get
            Return precio
        End Get
        Set(ByVal value As Double)
            precio = value
        End Set
    End Property

    Private maquinaria As Integer
    Public Property frap_maquinaria() As Integer
        Get
            Return maquinaria
        End Get
        Set(ByVal value As Integer)
            maquinaria = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property frap_usuariocreo() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property frap_fechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property frap_usuariomodifico() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechamodificacion As Date
    Public Property frap_fechamodificacion() As Date
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As Date)
            fechamodificacion = value
        End Set
    End Property

    Private activo As Integer
    Public Property frap_activo() As Integer
        Get
            Return activo
        End Get
        Set(ByVal value As Integer)
            activo = value
        End Set
    End Property

    Private costo As Double
    Public Property frap_costo() As Double
        Get
            Return costo
        End Get
        Set(ByVal value As Double)
            costo = value
        End Set
    End Property

    Private sumarcosto As Integer
    Public Property sumar_Costo() As Integer
        Get
            Return sumarcosto
        End Get
        Set(ByVal value As Integer)
            sumarcosto = value
        End Set
    End Property

    Private sumartiempo As Integer
    Public Property sumar_Tiempo() As Integer
        Get
            Return sumartiempo
        End Get
        Set(ByVal value As Integer)
            sumartiempo = value
        End Set
    End Property

    Private horas As Integer
    Public Property horas_() As Integer
        Get
            Return horas
        End Get
        Set(ByVal value As Integer)
            horas = value
        End Set
    End Property

    Private minutos As Integer
    Public Property minutos_() As Integer
        Get
            Return minutos
        End Get
        Set(ByVal value As Integer)
            minutos = value
        End Set
    End Property

    Private segundos As Integer
    Public Property segundos_() As Integer
        Get
            Return segundos
        End Get
        Set(ByVal value As Integer)
            segundos = value
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

    Private observaciones_ As String
    Public Property observaciones() As String
        Get
            Return observaciones_
        End Get
        Set(ByVal value As String)
            observaciones_ = value
        End Set
    End Property

    Private maquinariaid_ As Integer
    Public Property maquinariaid() As Integer
        Get
            Return maquinariaid_
        End Get
        Set(ByVal value As Integer)
            maquinariaid_ = value
        End Set
    End Property




End Class
