Public Class RutasGenerales
    Private rutaEtiquetas_Coppel As String
    Private rutaCRP_Compensacion As String
    Private rutaComprobante_Maquilas As String

    Public Property PRutaEtiquetas_Coppel As String
        Get
            Return rutaEtiquetas_Coppel
        End Get
        Set(value As String)
            rutaEtiquetas_Coppel = value
        End Set
    End Property

    Public Property PRutaCRP_Compensacion As String
        Get
            Return rutaCRP_Compensacion
        End Get
        Set(value As String)
            rutaCRP_Compensacion = value
        End Set
    End Property

    Public Property PRutaComprobante_Maquilas As String
        Get
            Return rutaComprobante_Maquilas
        End Get
        Set(value As String)
            rutaComprobante_Maquilas = value
        End Set
    End Property

End Class
