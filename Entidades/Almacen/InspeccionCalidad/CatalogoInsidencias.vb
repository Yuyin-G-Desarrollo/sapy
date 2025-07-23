Public Class CatalogoInsidencias
    Private _iDIncidencias As Integer
    Private _incidencias As String
    Private _departamento As String
    Private _idDepa As Integer
    Private _fecha As String
    Private _usuario As String

    Public Property IDIncidencias As Integer
        Get
            Return _iDIncidencias
        End Get
        Set(value As Integer)
            _iDIncidencias = value
        End Set
    End Property

    Public Property Incidencias As String
        Get
            Return _incidencias
        End Get
        Set(value As String)
            _incidencias = value
        End Set
    End Property

    Public Property Departamento As String
        Get
            Return _departamento
        End Get
        Set(value As String)
            _departamento = value
        End Set
    End Property

    Public Property Fecha As String
        Get
            Return _fecha
        End Get
        Set(value As String)
            _fecha = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
        End Set
    End Property

    Public Property IdDepa As Integer
        Get
            Return _idDepa
        End Get
        Set(value As Integer)
            _idDepa = value
        End Set
    End Property
End Class
