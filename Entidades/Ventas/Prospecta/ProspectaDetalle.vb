
Public Class ProspectaDetalle


    Private PProspectaID As Int32
    Private PMotivoIncidenciaID As Int32
    Private PConfirmacion As Boolean
    Private PMotivoIncidencia As String
    Private PObservaciones As String
    Private PProspectaDetalleDias As New List(Of ProspectaDetalleDias)
    Private PClienteID As Int32
    Private PUsuarioModificoId As Int32

#Region "Propiedaes"

    Public Property Confirmacion As Boolean
        Get
            Return PConfirmacion
        End Get
        Set(value As Boolean)
            PConfirmacion = value
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

    Public Property ClienteID As Int32
        Get
            Return PClienteID
        End Get
        Set(value As Int32)
            PClienteID = value
        End Set
    End Property

    Public Property ProspectaDetalleDias As List(Of ProspectaDetalleDias)
        Get
            Return PProspectaDetalleDias
        End Get
        Set(value As List(Of ProspectaDetalleDias))
            PProspectaDetalleDias = value
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Return PObservaciones
        End Get
        Set(value As String)
            PObservaciones = value
        End Set
    End Property

    Public Property MotivoIncidencia As String
        Get
            Return PMotivoIncidencia
        End Get
        Set(value As String)
            PMotivoIncidencia = value
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

    Public Property MotivoIncidenciaID As Int32
        Get
            Return PMotivoIncidenciaID
        End Get
        Set(value As Int32)
            PMotivoIncidenciaID = value
        End Set
    End Property
#End Region

    Sub New()
        PProspectaDetalleDias = New List(Of ProspectaDetalleDias)
    End Sub

End Class
