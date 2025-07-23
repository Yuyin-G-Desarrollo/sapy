Public Class TablasSPE
    Private tablaid As Integer
    Private tipo As String
    Private limiteinferior As Double
    Private limitesuperior As Double
    Private spemensual As Double

    Public Property PTablaId As Integer
        Get
            Return tablaid
        End Get
        Set(value As Integer)
            tablaid = value
        End Set
    End Property

    Public Property PTipo As String
        Get
            Return tipo
        End Get
        Set(value As String)
            tipo = value
        End Set
    End Property

    Public Property PLimiteInferior As Double
        Get
            Return limiteinferior
        End Get
        Set(value As Double)
            limiteinferior = value
        End Set
    End Property

    Public Property PLimiteSuperior As Double
        Get
            Return limitesuperior
        End Get
        Set(value As Double)
            limitesuperior = value
        End Set
    End Property

    Public Property PSPEMensual As Double
        Get
            Return spemensual
        End Get
        Set(value As Double)
            spemensual = value
        End Set
    End Property

End Class
