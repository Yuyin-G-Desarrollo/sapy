Public Class ColaboradorFirmaBiometrica

    Private colaboradorId As Int32
    Private mano As Int32
    Private dedo As Int32
    Private huella As String
    Private nave As Int32
    Private usuarioCreo As Int32
    Private dedoLibreria As Int32

    Public Property PcolaboradorId As Integer
        Get
            Return colaboradorId
        End Get
        Set(value As Integer)
            colaboradorId = value
        End Set
    End Property

    Public Property PdedoLibreria As Integer
        Get
            Return dedoLibreria
        End Get
        Set(value As Integer)
            dedoLibreria = value
        End Set
    End Property

    Public Property Pmano As Integer
        Get
            Return mano
        End Get
        Set(value As Integer)
            mano = value
        End Set
    End Property

    Public Property Pdedo As Integer
        Get
            Return dedo
        End Get
        Set(value As Integer)
            dedo = value
        End Set
    End Property

    Public Property PNave As Integer
        Get
            Return nave
        End Get
        Set(value As Integer)
            nave = value
        End Set
    End Property

    Public Property PusuarioCreo As Integer
        Get
            Return usuarioCreo
        End Get
        Set(value As Integer)
            usuarioCreo = value
        End Set
    End Property

    Public Property Phuella As String
        Get
            Return huella
        End Get
        Set(value As String)
            huella = value
        End Set
    End Property

End Class
