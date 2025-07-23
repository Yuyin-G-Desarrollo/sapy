
Public Class AcademicosColaborador

    Private Academicaid As Int32
    Private Colaboradorid As Colaborador
    Private NombreEscuela As String
    Private AnioInicio As Int32
    Private AnioTermino As Int32
    Private Estado As String
    Private Carrera As String
    Private Grado As String

    Public Property PAcademicaId As Int32
        Get
            Return Academicaid
        End Get
        Set(ByVal value As Int32)
            Academicaid = value
        End Set
    End Property

    Public Property PCarrera As String
        Get
            Return Carrera
        End Get
        Set(ByVal value As String)
            Carrera = value
        End Set
    End Property

    Public Property PColaboradorId As Colaborador
        Get
            Return Colaboradorid
        End Get
        Set(ByVal value As Colaborador)
            Colaboradorid = value
        End Set
    End Property

    Public Property PNombreEscuela As String
        Get
            Return NombreEscuela
        End Get
        Set(ByVal value As String)
            NombreEscuela = value
        End Set
    End Property

    Public Property PAnioInicio As Int32
        Get
            Return AnioInicio
        End Get
        Set(ByVal value As Int32)
            AnioInicio = value
        End Set
    End Property

    Public Property PAnioTermino As Int32
        Get
            Return AnioTermino
        End Get
        Set(ByVal value As Int32)
            AnioTermino = value
        End Set
    End Property


    Public Property PEstado As String
        Get
            Return Estado
        End Get
        Set(ByVal value As String)
            Estado = value
        End Set
    End Property

    Public Property PGrado As String
        Get
            Return Grado
        End Get
        Set(ByVal value As String)
            Grado = value
        End Set
    End Property

End Class
