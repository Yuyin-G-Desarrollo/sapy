Public Class ValidacionCompartidaWeb
    Private validacionTexto1 As String
    Public Property PValidacionTexto1() As String
        Get
            Return validacionTexto1
        End Get
        Set(ByVal value As String)
            validacionTexto1 = value
        End Set
    End Property

    Private validacionTexto2 As String
    Public Property PValidacionTexto2() As String
        Get
            Return validacionTexto2
        End Get
        Set(ByVal value As String)
            validacionTexto2 = value
        End Set
    End Property


End Class
