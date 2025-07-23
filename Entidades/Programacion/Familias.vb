Public Class Familias

    Private FIdFamilia As Int32
    Private FDescripcion As String
    Private FCodigo As String
    Private FActivo As Boolean
    'Private FCodigoSicy As String



    Public Property PIdFamilia As Int32
        Get
            Return FIdFamilia
        End Get
        Set(ByVal value As Int32)
            FIdFamilia = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return FDescripcion
        End Get
        Set(ByVal value As String)
            FDescripcion = value
        End Set
    End Property

    Public Property PCodigo As String
        Get
            Return FCodigo
        End Get
        Set(ByVal value As String)
            FCodigo = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return FActivo
        End Get
        Set(ByVal value As Boolean)
            FActivo = value
        End Set
    End Property

    'Public Property PCodigoSicy As String
    '    Get
    '        Return FCodigoSicy
    '    End Get
    '    Set(ByVal value As String)
    '        FCodigoSicy = value
    '    End Set
    'End Property

End Class
