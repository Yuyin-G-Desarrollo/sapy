Public Class HorarioContrarecibo

    Private Pdiascontrareciboid As Integer
    Public Property diascontrareciboid() As Integer
        Get
            Return Pdiascontrareciboid
        End Get
        Set(ByVal value As Integer)
            Pdiascontrareciboid = value
        End Set
    End Property

    Private Phorario As String
    Public Property horario() As String
        Get
            Return Phorario
        End Get
        Set(ByVal value As String)
            Phorario = value
        End Set
    End Property

    Private Pdias As Dias
    Public Property dias() As Dias
        Get
            Return Pdias
        End Get
        Set(ByVal value As Dias)
            Pdias = value
        End Set
    End Property

    Private Ptipohorario As TipoHorario
    Public Property tipohorario() As TipoHorario
        Get
            Return Ptipohorario
        End Get
        Set(ByVal value As TipoHorario)
            Ptipohorario = value
        End Set
    End Property

    Private Pcliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property


End Class
