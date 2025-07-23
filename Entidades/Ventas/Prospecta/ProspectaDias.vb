Public Class ProspectaDias


    Private pDia As Date
    Private PNumeroDia As Int32
    Private pNombreDia As String
    Private pCantidad As Int32


    Public Property Dia As Date
        Get
            Return pDia
        End Get
        Set(value As Date)
            pDia = value
        End Set
    End Property

    Public Property NumeroDia As Int32
        Get
            Return PNumeroDia
        End Get
        Set(value As Int32)
            PNumeroDia = value
        End Set
    End Property

    Public Property NombreDia As String
        Get
            Return pNombreDia
        End Get
        Set(value As String)
            pNombreDia = value
        End Set
    End Property

    Public Property Cantidad As Int32
        Get
            Return pCantidad
        End Get
        Set(value As Int32)
            pCantidad = value
        End Set
    End Property


End Class
