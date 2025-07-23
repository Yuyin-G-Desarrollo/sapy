Public Class CatalogoMaterialesMercadotecnia

    ''Declaraciond e variables
    Private MaterialesMercadotecniaId As Integer
    Private MaterialMErcadotecniaIdTipo As Integer
    Private MaterialesMercadotecniaNombre As String
    Private MaterialesMercadotecniaTipo As String
    Private MaterialesMercadotecniaActivo As Boolean

    'Creacion de los Gets y Sets
    Public Property PmameID As Integer
        Get
            Return MaterialesMercadotecniaId
        End Get
        Set(value As Integer)
            MaterialesMercadotecniaId = value
        End Set
    End Property

    Public Property PmameNombre As String
        Get
            Return MaterialesMercadotecniaNombre
        End Get
        Set(value As String)
            MaterialesMercadotecniaNombre = value
        End Set
    End Property

    Public Property PmameTipoId As Integer
        Get
            Return MaterialMErcadotecniaIdTipo
        End Get
        Set(value As Integer)
            MaterialMErcadotecniaIdTipo = value
        End Set
    End Property

    Public Property PmameTipo As String
        Get
            Return MaterialesMercadotecniaTipo
        End Get
        Set(value As String)
            MaterialesMercadotecniaTipo = value
        End Set
    End Property

    Public Property Pmameactivo As Boolean
        Get
            Return MaterialesMercadotecniaActivo
        End Get
        Set(value As Boolean)
            MaterialesMercadotecniaActivo = value
        End Set
    End Property

End Class
