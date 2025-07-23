Public Class Incentivos

   
    Private IncentivoId As Int32 '' Entidad Para Alojar Id de Incentivo
    Private IncentivoNaveId As Naves '' Entidad para Arrojar el id de la nave a la que pertenece el incentivo
    Private Nombre As String '' Nombre del incentivo
    Private Activo As Boolean '' Define si el motivo del incentivo esta activo
    Private Descripcion As String '' Descripcion del motivo

    Private MontoMax As Int32 '' Define el monto maximo de cada motivo de incentivo
    Private NaveNombre As Entidades.Naves '' Mandamos traer desde la Entidad Naves el Nombre de la Nave a la que pertenece el motivo

    Private PagoDiaExtra As Boolean ''Se agrega campo pago dia extra 
   


   

    

    'Setters y getters de las cuales asignamos y devolvemos los valores desde la consulta


    Public Property INaveNombre As Entidades.Naves
        Get
            Return NaveNombre
        End Get
        Set(ByVal value As Entidades.Naves)
            NaveNombre = value
        End Set
    End Property


    Public Property IMontoMaximo As Int32
        Get
            Return MontoMax
        End Get
        Set(ByVal value As Int32)
            MontoMax = value
        End Set
    End Property


    Public Property IIncentivoId As Int32
        Get
            Return IncentivoId
        End Get
        Set(ByVal value As Int32)
            IncentivoId = value
        End Set
    End Property


    Public Property INombre As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property IActivo As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property


    Public Property IDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
        End Set
    End Property

    Public Property IIncentivosNaveId As Naves
        Get
            Return IncentivoNaveId
        End Get
        Set(ByVal value As Naves)
            IncentivoNaveId = value
        End Set
    End Property

    Public Property IPagoDiaExtra As Boolean
        Get
            Return PagoDiaExtra
        End Get
        Set(value As Boolean)
            PagoDiaExtra = value
        End Set
    End Property
End Class
