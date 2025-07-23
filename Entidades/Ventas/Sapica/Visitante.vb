Public Class Visitante
    Private visitanteId As Integer
    Public Property VId() As Integer
        Get
            Return visitanteId
        End Get
        Set(ByVal value As Integer)
            visitanteId = value
        End Set
    End Property

    Private consecutivoEvento As Integer
    Public Property VConsecutivoEvento() As Integer
        Get
            Return consecutivoEvento
        End Get
        Set(ByVal value As Integer)
            consecutivoEvento = value
        End Set
    End Property

    Private clienteId As Integer
    Public Property VClienteId() As Integer
        Get
            Return clienteId
        End Get
        Set(ByVal value As Integer)
            clienteId = value
        End Set
    End Property

    Private eventoId As Integer
    Public Property VEventoId() As Integer
        Get
            Return eventoId
        End Get
        Set(ByVal value As Integer)
            eventoId = value
        End Set
    End Property

    Private nombreVisitante As String
    Public Property VNombreVisitante() As String
        Get
            Return nombreVisitante
        End Get
        Set(ByVal value As String)
            nombreVisitante = value
        End Set
    End Property

    Private clasificacionPersonaId As Integer
    Public Property VClasificacionPersonaId() As Integer
        Get
            Return clasificacionPersonaId
        End Get
        Set(ByVal value As Integer)
            clasificacionPersonaId = value
        End Set
    End Property

    Private eventosAnteriores As Boolean
    Public Property VEventosAnteriores() As Boolean
        Get
            Return eventosAnteriores
        End Get
        Set(ByVal value As Boolean)
            eventosAnteriores = value
        End Set
    End Property

    Private calle As String
    Public Property VCalle() As String
        Get
            Return calle
        End Get
        Set(ByVal value As String)
            calle = value
        End Set
    End Property

    Private numeroExterior As String
    Public Property VNumeroExterior() As String
        Get
            Return numeroExterior
        End Get
        Set(ByVal value As String)
            numeroExterior = value
        End Set
    End Property

    Private colonia As String
    Public Property VColonia() As String
        Get
            Return colonia
        End Get
        Set(ByVal value As String)
            colonia = value
        End Set
    End Property

    Private ciudadId As Integer
    Public Property VCiudadId() As Integer
        Get
            Return ciudadId
        End Get
        Set(ByVal value As Integer)
            ciudadId = value
        End Set
    End Property

    Private ciudad As String
    Public Property VCiudad() As String
        Get
            Return Ciudad
        End Get
        Set(ByVal value As String)
            ciudad = value
        End Set
    End Property

    Private estado As String
    Public Property VEstado() As String
        Get
            Return estado
        End Get
        Set(ByVal value As String)
            estado = value
        End Set
    End Property

    Private pais As String
    Public Property VPais() As String
        Get
            Return pais
        End Get
        Set(ByVal value As String)
            pais = value
        End Set
    End Property

    Private correoElectronico As String
    Public Property VCorreoElectronico() As String
        Get
            Return correoElectronico
        End Get
        Set(ByVal value As String)
            correoElectronico = value
        End Set
    End Property

    Private director As String
    Public Property VDirector() As String
        Get
            Return director
        End Get
        Set(ByVal value As String)
            director = value
        End Set
    End Property

    Private otroContacto As String
    Public Property VOtroContacto() As String
        Get
            Return otroContacto
        End Get
        Set(ByVal value As String)
            otroContacto = value
        End Set
    End Property

    Private haCompradoYuyin As Boolean
    Public Property VHaCombradoYuyin() As Boolean
        Get
            Return haCompradoYuyin
        End Get
        Set(ByVal value As Boolean)
            haCompradoYuyin = value
        End Set
    End Property

    Private ditribuidorClienteId As Integer
    Public Property VDistribuidorClienteId() As Integer
        Get
            Return ditribuidorClienteId
        End Get
        Set(ByVal value As Integer)
            ditribuidorClienteId = value
        End Set
    End Property

    Private otroDistribuidor As String
    Public Property VOtroDistribuidor() As String
        Get
            Return otroDistribuidor
        End Get
        Set(ByVal value As String)
            otroDistribuidor = value
        End Set
    End Property

    Private nombreComercial As String
    Public Property VNombreComercial() As String
        Get
            Return nombreComercial
        End Get
        Set(ByVal value As String)
            nombreComercial = value
        End Set
    End Property

    Private ramoId As Integer
    Public Property VRamoId() As Integer
        Get
            Return ramoId
        End Get
        Set(ByVal value As Integer)
            ramoId = value
        End Set
    End Property

    Private cantidadTiendas As Integer
    Public Property VCantidadTiendas() As Integer
        Get
            Return cantidadTiendas
        End Get
        Set(ByVal value As Integer)
            cantidadTiendas = value
        End Set
    End Property

    Private observaciones As String
    Public Property VObservaciones() As String
        Get
            Return observaciones
        End Get
        Set(ByVal value As String)
            observaciones = value
        End Set
    End Property

    Private usuarioAtiendeId As Integer
    Public Property VUsuarioAtiendeId() As Integer
        Get
            Return usuarioAtiendeId
        End Get
        Set(ByVal value As Integer)
            usuarioAtiendeId = value
        End Set
    End Property

    Private activo As Boolean
    Public Property VActivo() As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property

    Private usuarioCreoId As Integer
    Public Property VUsuarioCreoId() As Integer
        Get
            Return usuarioCreoId
        End Get
        Set(ByVal value As Integer)
            usuarioCreoId = value
        End Set
    End Property

    Private usuarioModifico As Integer
    Public Property VUsuarioModifico() As Integer
        Get
            Return usuarioModifico
        End Get
        Set(ByVal value As Integer)
            usuarioModifico = value
        End Set
    End Property

    Private fechaCreacion As Date
    Public Property VFechaCreacion() As Date
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As Date)
            fechaCreacion = value
        End Set
    End Property

    Private fechaModificacion As Date
    Public Property VFechaModificacion() As Date
        Get
            Return fechaModificacion
        End Get
        Set(ByVal value As Date)
            fechaModificacion = value
        End Set
    End Property

    Private estadoId As Integer
    Public Property VEstadoId() As Integer
        Get
            Return estadoId
        End Get
        Set(ByVal value As Integer)
            estadoId = value
        End Set
    End Property

    Private paisId As Integer
    Public Property VPaisId() As Integer
        Get
            Return paisId
        End Get
        Set(ByVal value As Integer)
            paisId = value
        End Set
    End Property

    Private personaId As Integer
    Public Property VPersonaId() As Integer
        Get
            Return personaId
        End Get
        Set(ByVal value As Integer)
            personaId = value
        End Set
    End Property

    Private evento As String
    Public Property VEvento() As String
        Get
            Return evento
        End Get
        Set(ByVal value As String)
            evento = value
        End Set
    End Property

    Private fecha As String
    Public Property VFecha() As String
        Get
            Return fecha
        End Get
        Set(ByVal value As String)
            fecha = value
        End Set
    End Property

    Private usuario As String
    Public Property VUsuario() As String
        Get
            Return usuario
        End Get
        Set(ByVal value As String)
            usuario = value
        End Set
    End Property

End Class
