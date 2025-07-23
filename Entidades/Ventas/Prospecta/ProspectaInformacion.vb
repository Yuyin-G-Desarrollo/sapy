

Public Class ProspectaInformacion

    Private PProspectaID As Int32
    Private PNumeroSemana As String
    Private PAño As Int32
    Private PFechaInicio As Date

    Private PFechaFin As Date
    Private PUsuarioCreoID As Int32
    Private PNombreUsuarioCreo As String
    Private PFechaCreacion As Date
    Private PUsuarioModifioID As Int32
    Private PNombreUsuarioModifio As String
    Private PFechaProgramacion As Date

    Private PFechaModificacion As Date
    Private PParesProspecta As Int32
    Private PParesProyectados As Int32
    Private PParesConfirmadosOrdenTrabajo As Int32
    Private PParesEntregados As Int32

    Private PParesEmbarcados As Int32
    Private PParesSalida As Int32    
    Private PIDEstatusProspecta As Int32
    Private PEstatusProspecta As String

    Private PEstatusBloqueo As Boolean
    Private PActivo As Boolean

#Region "Propeidades"

    Public Property ParesEntregados As Int32
        Get
            Return PParesEntregados
        End Get
        Set(value As Int32)
            PParesEntregados = value
        End Set
    End Property

    Public Property FechaProgramacion As Date
        Get
            Return PFechaProgramacion
        End Get
        Set(value As Date)
            PFechaProgramacion = value
        End Set
    End Property

    Public Property NombreUsuarioCreo As String
        Get
            Return PNombreUsuarioCreo
        End Get
        Set(value As String)
            PNombreUsuarioCreo = value
        End Set
    End Property

    Public Property NombreUsuarioModifio As String
        Get
            Return PNombreUsuarioModifio
        End Get
        Set(value As String)
            PNombreUsuarioModifio = value
        End Set
    End Property

    Public Property ProspectaID As Int32
        Get
            Return PProspectaID
        End Get
        Set(value As Int32)
            PProspectaID = value
        End Set
    End Property

    Public Property NumeroSemana As String
        Get
            Return PNumeroSemana
        End Get
        Set(value As String)
            PNumeroSemana = value
        End Set

    End Property

    Public Property Año As Int32
        Get
            Return PAño
        End Get
        Set(value As Int32)
            PAño = value
        End Set

    End Property



    Public Property FechaInicio As Date
        Get
            Return PFechaInicio
        End Get
        Set(value As Date)
            PFechaInicio = value
        End Set

    End Property

    Public Property FechaFin As Date
        Get
            Return PFechaFin
        End Get
        Set(value As Date)
            PFechaFin = value
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

    Public Property FechaCreacion As Date
        Get
            Return PFechaCreacion
        End Get
        Set(value As Date)
            PFechaCreacion = value
        End Set
    End Property

    Public Property UsuarioModifioID As Int32
        Get
            Return PUsuarioModifioID
        End Get
        Set(value As Int32)
            PUsuarioModifioID = value
        End Set
    End Property

    Public Property FechaModificacion As Date
        Get
            Return PFechaModificacion
        End Get
        Set(value As Date)
            PFechaModificacion = value
        End Set
    End Property

    Public Property ParesProspecta As Int32
        Get
            Return PParesProspecta
        End Get
        Set(value As Int32)
            PParesProspecta = value
        End Set
    End Property

    Public Property ParesProyectados As Int32
        Get
            Return PParesProyectados
        End Get
        Set(value As Int32)
            PParesProyectados = value
        End Set
    End Property

    Public Property ParesConfirmadosOrdenTrabajo As Int32
        Get
            Return PParesConfirmadosOrdenTrabajo
        End Get
        Set(value As Int32)
            PParesConfirmadosOrdenTrabajo = value
        End Set
    End Property


    Public Property ParesEmbarcados As Int32
        Get
            Return PParesEmbarcados
        End Get
        Set(value As Int32)
            PParesEmbarcados = value
        End Set
    End Property

    Public Property ParesSalida As Int32
        Get
            Return PParesSalida
        End Get
        Set(value As Int32)
            PParesSalida = value
        End Set
    End Property

    Public Property IDEstatusProspecta As Int32
        Get
            Return PIDEstatusProspecta
        End Get
        Set(value As Int32)
            PIDEstatusProspecta = value
        End Set
    End Property

    Public Property EstatusProspecta As String
        Get
            Return PEstatusProspecta
        End Get
        Set(value As String)
            PEstatusProspecta = value
        End Set
    End Property

    Public Property EstatusBloqueo As Boolean
        Get
            Return PEstatusBloqueo
        End Get
        Set(value As Boolean)
            PEstatusBloqueo = value
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return PActivo
        End Get
        Set(value As Boolean)
            PActivo = value
        End Set
    End Property


#End Region
    
End Class

