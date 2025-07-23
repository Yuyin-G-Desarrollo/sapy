Public Class CatalogosDias

    ''Declaracion de variables.
    Private IdDia As Integer
    Private NombreDia As String
    Private Fecha As String
    Private Activo As Boolean


    Public Property PNombreDia As String
        Get
            Return NombreDia
        End Get
        Set(ByVal value As String)
            NombreDia = value
        End Set
    End Property



    Public Property PIdDia As Integer
        Get
            Return IdDia
        End Get
        Set(ByVal value As Integer)
            IdDia = value
        End Set
    End Property



    Public Property PFecha As String
        Get
            Return Fecha
        End Get
        Set(ByVal value As String)
            Fecha = value
        End Set
    End Property


    Public Property PActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property
End Class
