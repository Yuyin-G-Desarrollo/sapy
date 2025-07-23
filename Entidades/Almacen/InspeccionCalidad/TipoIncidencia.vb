
Public Class TipoIncidencia

    Private _IncidenciaID As Integer
    Private _Incidencia As String

#Region "Propiedades"

    Public Property IncidenciaID As Integer
        Get
            Return _IncidenciaID
        End Get
        Set(value As Integer)
            _IncidenciaID = value
        End Set
    End Property

    Public Property Incidencia As String
        Get
            Return _Incidencia
        End Get
        Set(value As String)
            _Incidencia = value
        End Set
    End Property


#End Region

End Class
