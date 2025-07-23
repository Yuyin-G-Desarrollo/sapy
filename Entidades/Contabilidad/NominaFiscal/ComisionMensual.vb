Public Class ComisionMensual
    Private comisionid As Integer
    Private colaboradorid As Integer
    'Private sdicolaborador As Double
    Private patronid As Integer
    Private periodoid As Integer
    Private montocomision As Double
    Private mescomision As Integer
    Private aniocomision As Integer
    Private usuariocreo As String
    Private usuariomodifica As String
    Private maxcolaborador As Double
    'Private maxpatron As Double

    'Private comisionid As Integer
    Public Property PComisionId As Integer
        Get
            Return comisionid
        End Get
        Set(value As Integer)
            comisionid = value
        End Set
    End Property

    'Private colaboradorid As Integer
    Public Property PColaboradorId As Integer
        Get
            Return colaboradorid
        End Get
        Set(value As Integer)
            colaboradorid = value
        End Set
    End Property

    'Private sdicolaborador As Double
    'Public Property PSDIColaborador As Double
    '    Get
    '        Return sdicolaborador
    '    End Get
    '    Set(value As Double)
    '        sdicolaborador = value
    '    End Set
    'End Property

    'Private patronid As Integer
    Public Property PPatronId As Integer
        Get
            Return patronid
        End Get
        Set(value As Integer)
            patronid = value
        End Set
    End Property
    'Private periodoid As Integer
    Public Property PPeriodoId As Integer
        Get
            Return periodoid
        End Get
        Set(value As Integer)
            periodoid = value
        End Set
    End Property
    'Private montocomision As Double
    Public Property PMontoComision As Double
        Get
            Return montocomision
        End Get
        Set(value As Double)
            montocomision = value
        End Set
    End Property
    'Private mescomision As Integer
    Public Property PMesComision As Integer
        Get
            Return mescomision
        End Get
        Set(value As Integer)
            mescomision = value
        End Set
    End Property
    'Private aniocomision As Integer
    Public Property PAnioComision As Integer
        Get
            Return aniocomision
        End Get
        Set(value As Integer)
            aniocomision = value
        End Set
    End Property
    'Private usuariocreo As String
    Public Property PUsuarioCreo As String
        Get
            Return usuariocreo
        End Get
        Set(value As String)
            usuariocreo = value
        End Set
    End Property
    'Private usuariomodifica As String
    Public Property PUsuarioModifica As String
        Get
            Return usuariomodifica
        End Get
        Set(value As String)
            usuariomodifica = value
        End Set
    End Property
    'Private maxcolaborador As Double
    Public Property PMaxColaborador As Double
        Get
            Return maxcolaborador
        End Get
        Set(value As Double)
            maxcolaborador = value
        End Set
    End Property
    ''Private maxpatron As Double
    'Public Property PMaxPatron As Double
    '    Get
    '        Return maxpatron
    '    End Get
    '    Set(value As Double)
    '        maxpatron = value
    '    End Set
    'End Property

End Class
