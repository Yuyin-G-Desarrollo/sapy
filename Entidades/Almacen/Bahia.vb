Public Class Bahia
    Private pbahi_bahiaid As String
    Private pbahi_bloque As String
    Private pbahi_fila As String
    Private pbahi_segmento As String
    Private pbahi_nivel As String
    Private pbahi_estiba As String
    Private pbahi_descripcion As String
    Private pbahi_posicion As String
    Private pbahi_activo As Boolean
    Private pbahi_usuariocreoid As Int32
    Private pbahi_usuariomodificaid As Int32
    Private pbahi_fechacreacion As Date
    Private pbahi_fechamodificacion As Date
    Private pbahi_nave As Int32
    Private pbahi_almacen As String
    Private pbahi_color As String
    Private pbahia_capacidadenpares As Int32
    Private PCliente As New Entidades.ClientesAlmacen
    Private pbahi_bahiaprincipalid As String
    Private ListaEstibasBahia As List(Of Entidades.Estibas)
    Private PListaClientes As List(Of Entidades.ClientesAlmacen)
    Private PCapacidadenpares As Int32
    Private Pbahi_referenciaubicacionid As Int32
    Private PporcentajeOcupacion As Double
    Private Ppares_actuales As Int32

    Public Property paresactuales As Int32
        Get
            Return Ppares_actuales
        End Get
        Set(value As Int32)
            Ppares_actuales = value
        End Set
    End Property

    Public Property porcentajeocupacion As Double
        Get
            Return PporcentajeOcupacion
        End Get
        Set(value As Double)
            PporcentajeOcupacion = value
        End Set
    End Property

    Public Property bahi_referenciaubicacionid As Int32
        Get
            Return Pbahi_referenciaubicacionid
        End Get
        Set(value As Int32)
            Pbahi_referenciaubicacionid = value
        End Set
    End Property

    Public Property capacidadenpares As Int32
        Get
            Return PCapacidadenpares
        End Get
        Set(value As Int32)
            PCapacidadenpares = value
        End Set
    End Property


    Public Property ListaClientes As List(Of Entidades.ClientesAlmacen)
        Get
            Return PListaClientes
        End Get
        Set(value As List(Of Entidades.ClientesAlmacen))
            PListaClientes = value
        End Set
    End Property

    Public Property PListaEstibaBahia As List(Of Entidades.Estibas)
        Get
            Return ListaEstibasBahia
        End Get
        Set(value As List(Of Entidades.Estibas))
            ListaEstibasBahia = value
        End Set
    End Property


    Public Property bahi_bahiaprincipalid As String
        Get
            Return pbahi_bahiaprincipalid
        End Get
        Set(value As String)
            pbahi_bahiaprincipalid = value
        End Set
    End Property
    Public Property Cliente As Entidades.ClientesAlmacen
        Get
            Return PCliente
        End Get
        Set(value As Entidades.ClientesAlmacen)
            PCliente = value
        End Set
    End Property
    Public Property bahi_capacidadenpares As Int32
        Get
            Return pbahia_capacidadenpares
        End Get
        Set(value As Int32)
            pbahia_capacidadenpares = value
        End Set
    End Property
    Public Property bahi_color As String
        Get
            Return pbahi_color
        End Get
        Set(value As String)
            pbahi_color = value
        End Set
    End Property
    Public Property bahia_nave As Int32
        Get
            Return pbahi_nave
        End Get
        Set(value As Int32)
            pbahi_nave = value
        End Set
    End Property
    Public Property bahi_almacen As String
        Get
            Return pbahi_almacen
        End Get
        Set(value As String)
            pbahi_almacen = value
        End Set
    End Property
    Public Property bahiaid As String
        Get
            Return pbahi_bahiaid
        End Get
        Set(value As String)
            pbahi_bahiaid = value
        End Set
    End Property

    Public Property bahi_bloque As String
        Get
            Return pbahi_bloque
        End Get
        Set(value As String)
            pbahi_bloque = value
        End Set
    End Property
    Public Property bahi_fila As String
        Get
            Return pbahi_fila
        End Get
        Set(value As String)
            pbahi_fila = value
        End Set
    End Property

    Public Property bahi_segmento As String
        Get
            Return pbahi_segmento
        End Get
        Set(value As String)
            pbahi_segmento = value
        End Set
    End Property


    Public Property bahi_nivel As String
        Get
            Return pbahi_nivel
        End Get
        Set(value As String)
            pbahi_nivel = value
        End Set
    End Property

    Public Property bahi_estiba As String
        Get
            Return pbahi_estiba
        End Get
        Set(value As String)
            pbahi_estiba = value
        End Set
    End Property

    Public Property bahi_descripcion As String
        Get
            Return pbahi_descripcion
        End Get
        Set(value As String)
            pbahi_descripcion = value
        End Set
    End Property

    Public Property bahi_posicion As String
        Get
            Return pbahi_posicion
        End Get
        Set(value As String)
            pbahi_posicion = value
        End Set
    End Property


    Public Property bahi_activo As Boolean
        Get
            Return pbahi_activo
        End Get
        Set(value As Boolean)
            pbahi_activo = value
        End Set
    End Property

    Public Property bahi_usuariocreoid As Int32
        Get
            Return pbahi_usuariocreoid
        End Get
        Set(value As Int32)
            pbahi_usuariocreoid = value
        End Set
    End Property

    Public Property bahi_usuariomodificaid As Int32
        Get
            Return pbahi_usuariomodificaid
        End Get
        Set(value As Int32)
            pbahi_usuariomodificaid = value
        End Set
    End Property


    Public Property bahi_fechacreacion As Date
        Get
            Return pbahi_fechacreacion
        End Get
        Set(value As Date)
            pbahi_fechacreacion = value
        End Set
    End Property

    Public Property bahi_fechamodificacion As Date
        Get
            Return pbahi_fechamodificacion
        End Get
        Set(value As Date)
            pbahi_fechamodificacion = value
        End Set
    End Property


End Class
