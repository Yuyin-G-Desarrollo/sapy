Public Class Credencial

    Private datoscontactoid As Integer
    Public Property daco_datoscontactoid() As Integer
        Get
            Return datoscontactoid
        End Get
        Set(ByVal value As Integer)
            datoscontactoid = value
        End Set
    End Property

    Private nombre As String
    Public Property daco_nombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private cargo As String
    Public Property daco_cargo() As String
        Get
            Return cargo
        End Get
        Set(ByVal value As String)
            cargo = value
        End Set
    End Property

    Private telefono As String
    Public Property daco_telefono() As String
        Get
            Return telefono
        End Get
        Set(ByVal value As String)
            telefono = value
        End Set
    End Property

    Private email As String
    Public Property daco_email() As String
        Get
            Return email
        End Get
        Set(ByVal value As String)
            email = value
        End Set
    End Property

    Private foto As String
    Public Property daco_foto() As String
        Get
            Return foto
        End Get
        Set(ByVal value As String)
            foto = value
        End Set
    End Property


End Class
