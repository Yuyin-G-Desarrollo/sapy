
Public Class FuenteInformacionEtiqueta

    Private Pfuenteinformacionetiquetaid As Integer
    Public Property fuenteinformacionetiquetaid() As Integer
        Get
            Return Pfuenteinformacionetiquetaid
        End Get
        Set(ByVal value As Integer)
            Pfuenteinformacionetiquetaid = value
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
