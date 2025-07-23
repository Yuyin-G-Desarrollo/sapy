Public Class FiltrosCalculoPercepciones
    Private NaveId As Int32
    Private Agno As Int32
    Private Periodo As String
    Private UsuarioId As Int32
    Public Property PUsuarioId As Int32
        Get
            Return UsuarioId
        End Get
        Set(value As Int32)
            UsuarioId = value
        End Set
    End Property

    Public Property PNaveId As Int32
        Get
            Return NaveId
        End Get
        Set(value As Int32)
            NaveId = value
        End Set
    End Property

    Public Property PAgno As Int32
        Get
            Return Agno
        End Get
        Set(value As Int32)
            Agno = value
        End Set
    End Property
    Public Property PPeriodo As String
        Get
            Return Periodo
        End Get
        Set(value As String)
            Periodo = value
        End Set
    End Property
End Class
