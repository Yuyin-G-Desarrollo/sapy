Public Class MotivosFiniquito
    Private MotivoFiniquitoId As Int32
    Private Nombre As String
    Private NaveId As Naves
    Private Activo As Boolean

    Public Property PMotivoFiniquitoId As Int32
        Get
            Return MotivoFiniquitoId
        End Get
        Set(ByVal value As Int32)
            MotivoFiniquitoId = value
        End Set
    End Property

    Public Property PNombre As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property PNaveId As Naves
        Get
            Return NaveId
        End Get
        Set(ByVal value As Naves)
            NaveId = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property
End Class
