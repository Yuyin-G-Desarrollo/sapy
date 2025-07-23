Public Class ColaboradorReferencias
    Private ColaboradorReferenciaId As Int32
    Private ColaboradorId As Colaborador
    Private Nombre As String
    Private Parentezco As String
    Private Ocupacion As String
    Private Telefono As String
    Private FechaNacimiento As Date

    Public Property PFechaNacimiento As Date
        Get
            Return FechaNacimiento
        End Get
        Set(ByVal value As Date)
            FechaNacimiento = value
        End Set
    End Property

    Public Property PColaboradorReferenciaId As Int32
        Get
            Return ColaboradorReferenciaId
        End Get
        Set(ByVal value As Int32)
            ColaboradorReferenciaId = value
        End Set
    End Property

    Public Property PColaboradorId As Colaborador
        Get
            Return ColaboradorId
        End Get
        Set(ByVal value As Colaborador)
            ColaboradorId = value
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

    Public Property PParentezco As String
        Get
            Return Parentezco
        End Get
        Set(ByVal value As String)
            Parentezco = value
        End Set
    End Property

    Public Property POcupacion As String
        Get
            Return Ocupacion
        End Get
        Set(ByVal value As String)
            Ocupacion = value
        End Set
    End Property

    Public Property PTelefono As String
        Get
            Return Telefono
        End Get
        Set(ByVal value As String)
            Telefono = value
        End Set
    End Property

End Class
