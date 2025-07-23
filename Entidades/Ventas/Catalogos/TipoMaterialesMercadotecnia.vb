Public Class TipoMaterialesMercadotecnia
    Private idtipoMaterial As Int32
    Private tipoMaterial As String

    Public Property PidTipoMaterial As Integer
        Get
            Return idtipoMaterial
        End Get
        Set(value As Integer)
            idtipoMaterial = value
        End Set
    End Property

    Public Property PTipoMaterial As String
        Get
            Return tipoMaterial
        End Get
        Set(value As String)
            tipoMaterial = value
        End Set
    End Property


End Class
