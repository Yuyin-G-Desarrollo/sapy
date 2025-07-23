Public Class TipoRequerimientosEspeciales

    Private IdTipo As Int32
    Private Tipo As String

    Public Property PIdTipo As Integer
        Get
            Return IdTipo
        End Get
        Set(value As Integer)
            IdTipo = value
        End Set
    End Property

    Public Property PTipo As String
        Get
            Return Tipo
        End Get
        Set(value As String)
            Tipo = value
        End Set
    End Property

End Class
