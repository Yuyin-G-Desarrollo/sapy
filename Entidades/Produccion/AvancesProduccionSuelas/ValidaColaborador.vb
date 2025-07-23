Public Class ValidaColaborador
    Private _NaveId As Integer
    Private _Nave As String
    Private _NombreColaborador As String
    Private _ColaboradorId As Integer



    Public Property NaveId As Integer
        Get
            Return _NaveId
        End Get
        Set(value As Integer)
            _NaveId = value
        End Set
    End Property

    Public Property Nave As String
        Get
            Return _Nave
        End Get
        Set(value As String)
            _Nave = value
        End Set
    End Property

    Public Property NombreColaborador As String
        Get
            Return _NombreColaborador
        End Get
        Set(value As String)
            _NombreColaborador = value
        End Set
    End Property

    Public Property ColaboradorId As Integer
        Get
            Return _ColaboradorId
        End Get
        Set(value As Integer)
            _ColaboradorId = value
        End Set
    End Property

    Sub New()
        NaveId = 0
        Nave = String.Empty
        NombreColaborador = String.Empty
        ColaboradorId = 0

    End Sub


End Class
