
Public Class TipoDocumento

    Private Ptipodocumentoid As Integer
    Public Property tipodocumentoid() As Integer
        Get
            Return Ptipodocumentoid
        End Get
        Set(ByVal value As Integer)
            Ptipodocumentoid = value
        End Set
    End Property

    Private Pnombre As String
    Public Property nombre() As String
        Get
            Return Pnombre
        End Get
        Set(ByVal value As String)
            Pnombre = value
        End Set
    End Property

    Private Pclasedocumento As String
    Public Property clasedocumento() As String
        Get
            Return Pclasedocumento
        End Get
        Set(ByVal value As String)
            Pclasedocumento = value
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
