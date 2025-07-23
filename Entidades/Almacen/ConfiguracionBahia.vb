Public Class ConfiguracionBahia
    Private cobo_configuracionbloqueid As Int32
    Private cobo_nave As Int32
    Private cobo_almacen As String
    Private cobl_bloque As String
    Private cobl_renglones As String
    Private cobl_columnas As String
    Private cobo_activo As Boolean
    Private cobo_usuariocreoid As Int32
    Private cobo_usuariomodificaid As Int32
    Private cobo_fechacreacion As Date
    Private cobo_fechamodificacion As Date
    Private cobl_nivel As String

    Public Property pcobl_nivel As String
        Get
            Return cobl_nivel
        End Get
        Set(value As String)
            cobl_nivel = value
        End Set
    End Property

    Public Property pcobo_configuracionbloqueid As Int32
        Get
            Return cobo_configuracionbloqueid
        End Get
        Set(value As Int32)
            cobo_configuracionbloqueid = value
        End Set
    End Property
    Public Property pcobo_nave As Int32
        Get
            Return cobo_nave

        End Get
        Set(value As Int32)
            cobo_nave = value
        End Set
    End Property
    Public Property pcobo_almacen As String
        Get
            Return cobo_almacen
        End Get
        Set(value As String)
            cobo_almacen = value
        End Set
    End Property
    Public Property pcobl_bloque As String
        Get
            Return cobl_bloque
        End Get
        Set(value As String)
            cobl_bloque = value
        End Set
    End Property
    Public Property pcobl_renglones As String
        Get
            Return cobl_renglones
        End Get
        Set(value As String)
            cobl_renglones = value
        End Set
    End Property
    Public Property pcobl_columnas As String
        Get
            Return cobl_columnas
        End Get
        Set(value As String)
            cobl_columnas = value
        End Set
    End Property
    
    Public Property pcobo_activo As Boolean
        Get
            Return cobo_activo
        End Get
        Set(value As Boolean)
            cobo_activo = value
        End Set
    End Property
    Public Property pcobo_usuariocreoid As Int32
        Get
            Return cobo_usuariocreoid
        End Get
        Set(value As Int32)
            cobo_usuariocreoid = value
        End Set
    End Property
    Public Property pcobo_usuariomodificaid As Int32
        Get
            Return cobo_usuariomodificaid
        End Get
        Set(value As Int32)
            cobo_usuariomodificaid = value
        End Set
    End Property
    Public Property pcobo_fechacreacion As Date
        Get
            Return cobo_fechacreacion
        End Get
        Set(value As Date)
            cobo_fechacreacion = value
        End Set
    End Property
    Public Property pcobo_fechamodificacion As Date
        Get
            Return cobo_fechamodificacion
        End Get
        Set(value As Date)
            cobo_fechamodificacion = value
        End Set
    End Property



End Class
