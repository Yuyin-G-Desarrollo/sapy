Public Class ListaBase

    Private listaBaseId As Int32
    Private listaBaseCodigo As String
    Private listaBaseNombre As String
    Private vigenciaInicio As Date
    Private vigenciaFin As Date
    Private estatusListaBase As String

    Public Property PListaBaseId As Int32
        Get
            Return listaBaseId
        End Get
        Set(value As Int32)
            listaBaseId = value
        End Set
    End Property

    Public Property PListaBaseCodigo As String
        Get
            Return listaBaseCodigo
        End Get
        Set(value As String)
            listaBaseCodigo = value
        End Set
    End Property

    Public Property PListaBaseNombre As String
        Get
            Return listaBaseNombre
        End Get
        Set(value As String)
            listaBaseNombre = value
        End Set
    End Property

    Public Property PVigenciaInicio As Date
        Get
            Return vigenciaInicio
        End Get
        Set(value As Date)
            vigenciaInicio = value
        End Set
    End Property

    Public Property PVigenciaFin As Date
        Get
            Return vigenciaFin
        End Get
        Set(value As Date)
            vigenciaFin = value
        End Set
    End Property

    Public Property PListaBaseEstatus As String
        Get
            Return estatusListaBase
        End Get
        Set(value As String)
            estatusListaBase = value
        End Set
    End Property

End Class
