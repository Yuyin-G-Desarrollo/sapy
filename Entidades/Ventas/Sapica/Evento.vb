Public Class Evento
    Private eventoId As Integer
    Public Property EEventoId() As Integer
        Get
            Return eventoId
        End Get
        Set(ByVal value As Integer)
            eventoId = value
        End Set
    End Property

    Private nombre As String
    Public Property ENombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private abreviatura As String
    Public Property EAbreviatura() As String
        Get
            Return abreviatura
        End Get
        Set(ByVal value As String)
            abreviatura = value
        End Set
    End Property

    Private lugar As String
    Public Property ELugar() As String
        Get
            Return lugar
        End Get
        Set(ByVal value As String)
            lugar = value
        End Set
    End Property

    Private fechaInicioEvento As Date
    Public Property EFechaInicioEvento() As Date
        Get
            Return fechaInicioEvento
        End Get
        Set(ByVal value As Date)
            fechaInicioEvento = value
        End Set
    End Property

    Private fechaFinEvento As Date
    Public Property EFEchaFinEvento() As Date
        Get
            Return fechaFinEvento
        End Get
        Set(ByVal value As Date)
            fechaFinEvento = value
        End Set
    End Property

    Private paresPedidos As Integer
    Public Property EParesPedidos() As Integer
        Get
            Return paresPedidos
        End Get
        Set(ByVal value As Integer)
            paresPedidos = value
        End Set
    End Property

    Private consecutivoVisitante As Integer
    Public Property EConsecutivoVisitante() As Integer
        Get
            Return consecutivoVisitante
        End Get
        Set(ByVal value As Integer)
            consecutivoVisitante = value
        End Set
    End Property

    Private fechaEtrega_coleccionesNuevas As Date
    Public Property EFechaEntregaColeccionesNuevas() As Date
        Get
            Return fechaEtrega_coleccionesNuevas
        End Get
        Set(ByVal value As Date)
            fechaEtrega_coleccionesNuevas = value
        End Set
    End Property

    Private fechaEtrega_coleccionesVigentes As Date
    Public Property EFechaEntregaColeccionesVigentes() As Date
        Get
            Return fechaEtrega_coleccionesVigentes
        End Get
        Set(ByVal value As Date)
            fechaEtrega_coleccionesVigentes = value
        End Set
    End Property

    Private activo As Boolean
    Public Property EActivo() As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property

    Private usuarioCreoId As Integer
    Public Property EUsuarioCreoId() As Integer
        Get
            Return usuarioCreoId
        End Get
        Set(ByVal value As Integer)
            usuarioCreoId = value
        End Set
    End Property

    Private usuarioModificoId As Integer
    Public Property EUsuarioModificoId() As Integer
        Get
            Return usuarioModificoId
        End Get
        Set(ByVal value As Integer)
            usuarioModificoId = value
        End Set
    End Property

    Private fechaCreacion As Date
    Public Property EFechaCreacion() As Date
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As Date)
            fechaCreacion = value
        End Set
    End Property

    Private fechaModificacion As Date
    Public Property EFechaModificacion() As Date
        Get
            Return fechaModificacion
        End Get
        Set(ByVal value As Date)
            fechaModificacion = value
        End Set
    End Property
End Class
