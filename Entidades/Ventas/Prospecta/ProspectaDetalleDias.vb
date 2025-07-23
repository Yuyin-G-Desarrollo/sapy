


Public Class ProspectaDetalleDias

    Private PDetalleDia As Int32
    Private PDetalleProspectaID As Int32
    Private PUsuarioCreoID As Int32
    Private PFecha As Date
    Private PNumeroDia As Int32
    Private PPlaneacionSemanal As Int32
    Private PProyeccionSemanal As Int32
    Private PConfirmacionSemanal As Int32
    Private PEmbarqueSemanal As Int32
    Private PSalidaSemanal As Int32
    Private PUsuarioModificoId As Int32
    Private PFechaModificacion As Date

#Region "Propeidades"


    Public Property FechaModificacion As Date
        Get
            Return PFechaModificacion
        End Get
        Set(value As Date)
            PFechaModificacion = value
        End Set

    End Property

    Public Property UsuarioModificoId As Int32
        Get
            Return PUsuarioModificoId
        End Get
        Set(value As Int32)
            PUsuarioModificoId = value
        End Set

    End Property

    Public Property SalidaSemanal As Int32
        Get
            Return PSalidaSemanal
        End Get
        Set(value As Int32)
            PSalidaSemanal = value
        End Set
    End Property

    Public Property EmbarqueSemanal As Int32
        Get
            Return PEmbarqueSemanal
        End Get
        Set(value As Int32)
            PEmbarqueSemanal = value
        End Set

    End Property

    Public Property ConfirmacionSemanal As Int32
        Get
            Return PConfirmacionSemanal
        End Get
        Set(value As Int32)
            PConfirmacionSemanal = value
        End Set

    End Property

    Public Property ProyeccionSemanal As Int32
        Get
            Return PProyeccionSemanal
        End Get
        Set(value As Int32)
            PProyeccionSemanal = value
        End Set

    End Property

    Public Property PlaneacionSemanal As Int32
        Get
            Return PPlaneacionSemanal
        End Get
        Set(value As Int32)
            PPlaneacionSemanal = value
        End Set
    End Property


    Public Property NumeroDia As Int32
        Get
            Return PNumeroDia
        End Get
        Set(value As Int32)
            PNumeroDia = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return PFecha
        End Get
        Set(value As Date)
            PFecha = value
        End Set
    End Property

    Public Property UsuarioCreoID As Int32
        Get
            Return PUsuarioCreoID
        End Get
        Set(value As Int32)
            PUsuarioCreoID = value
        End Set
    End Property


    Public Property DetalleProspectaID As Int32
        Get
            Return PDetalleProspectaID
        End Get
        Set(value As Int32)
            PDetalleProspectaID = value
        End Set
    End Property

    Public Property DetalleDia As Int32
        Get
            Return PDetalleDia
        End Get
        Set(value As Int32)
            PDetalleDia = value
        End Set
    End Property

#End Region

End Class
