Public Class Consumos

    Private descripcion As String
    Public Property comp_descripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property comp_fechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property comp_usuariocreo() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private fechamodificacion As Date
    Public Property comp_fechamodificacion() As Date
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As Date)
            fechamodificacion = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property comp_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private activo As Integer
    Public Property comp_activo() As Integer
        Get
            Return activo
        End Get
        Set(ByVal value As Integer)
            activo = value
        End Set
    End Property

    Private idconsumo As Integer
    Public Property comp_idcomponente() As Integer
        Get
            Return idconsumo
        End Get
        Set(ByVal value As Integer)
            idconsumo = value
        End Set
    End Property

    Private naveid As Integer
    Public Property cons_naveid() As Integer
        Get
            Return naveid
        End Get
        Set(ByVal value As Integer)
            naveid = value
        End Set
    End Property

    Private estiloid As Integer
    Public Property cons_estiloid() As Integer
        Get
            Return estiloid
        End Get
        Set(ByVal value As Integer)
            estiloid = value
        End Set
    End Property

    Private idnave As Integer
    Public Property cons_idnave() As Integer
        Get
            Return idnave
        End Get
        Set(ByVal value As Integer)
            idnave = value
        End Set
    End Property

    Private fechaasignacion As Date
    Public Property cons_fechaasignacion() As Date
        Get
            Return fechaasignacion
        End Get
        Set(ByVal value As Date)
            fechaasignacion = value
        End Set
    End Property

    Private asignoid As Integer
    Public Property cons_asignoid() As Integer
        Get
            Return asignoid
        End Get
        Set(ByVal value As Integer)
            asignoid = value
        End Set
    End Property

    Private fechaautorizacion As Date
    Public Property cons_fechaautorizacion() As Date
        Get
            Return fechaautorizacion
        End Get
        Set(ByVal value As Date)
            fechaautorizacion = value
        End Set
    End Property

    Private autorizo As Integer
    Public Property cons_autorizo() As Integer
        Get
            Return autorizo
        End Get
        Set(ByVal value As Integer)
            autorizo = value
        End Set
    End Property

    Private productoestiloid As Integer
    Public Property cons_productoestiloid() As Integer
        Get
            Return productoestiloid
        End Get
        Set(ByVal value As Integer)
            productoestiloid = value
        End Set
    End Property

    Private naveasignaid As Integer
    Public Property cons_naveasignaid() As Integer
        Get
            Return naveasignaid
        End Get
        Set(ByVal value As Integer)
            naveasignaid = value
        End Set
    End Property

    Private productoestid As Integer
    Public Property hipe_productoestid() As Integer
        Get
            Return productoestid
        End Get
        Set(ByVal value As Integer)
            productoestid = value
        End Set
    End Property

    Private estatusde As String
    Public Property hipe_estatusde() As String
        Get
            Return estatusde
        End Get
        Set(ByVal value As String)
            estatusde = value
        End Set
    End Property

    Private estatusa As String
    Public Property hipe_estatusa() As String
        Get
            Return estatusa
        End Get
        Set(ByVal value As String)
            estatusa = value
        End Set
    End Property

    Private usuarioid As Integer
    Public Property hipe_usuarioid() As Integer
        Get
            Return usuarioid
        End Get
        Set(ByVal value As Integer)
            usuarioid = value
        End Set
    End Property

    Private idnavehipe As Integer
    Public Property hipe_idnavehipe() As Integer
        Get
            Return idnavehipe
        End Get
        Set(ByVal value As Integer)
            idnavehipe = value
        End Set
    End Property

    Private naveasignadaid As Integer
    Public Property hipe_naveasignadaid() As Integer
        Get
            Return naveasignadaid
        End Get
        Set(ByVal value As Integer)
            naveasignadaid = value
        End Set
    End Property

    Private asignado As Integer
    Public Property hipe_asignado() As Integer
        Get
            Return asignado
        End Get
        Set(ByVal value As Integer)
            asignado = value
        End Set
    End Property


End Class
