Public Class CatalogoEquipo

    Private catequi_hardwareid As Integer

    Public Property CEHardwareid() As Integer
        Get
            Return catequi_hardwareid
        End Get
        Set(ByVal value As Integer)
            catequi_hardwareid = value
        End Set
    End Property


    Private catequi_nombrehardware As String

    Public Property CENombreHardware() As String
        Get
            Return catequi_nombrehardware
        End Get
        Set(ByVal value As String)
            catequi_nombrehardware = value
        End Set
    End Property

    Private catequi_status As Boolean

    Public Property CEStatus() As Boolean
        Get
            Return catequi_status
        End Get
        Set(ByVal value As Boolean)
            catequi_status = value
        End Set
    End Property

    Private catequi_categoriaid As Integer

    Public Property CECategoriaid() As Integer
        Get
            Return catequi_categoriaid
        End Get
        Set(ByVal value As Integer)
            catequi_categoriaid = value
        End Set
    End Property


    Private catequi_usuariocrea As Integer

    Public Property CEUsuCrea() As Integer
        Get
            Return catequi_usuariocrea
        End Get
        Set(ByVal value As Integer)
            catequi_usuariocrea = value
        End Set
    End Property

    Private catequi_usuariomodifica As Integer

    Public Property CEUsuModi() As Integer
        Get
            Return catequi_usuariomodifica
        End Get
        Set(ByVal value As Integer)
            catequi_usuariomodifica = value
        End Set
    End Property



End Class
