Public Class ClientesAlmacen
    Dim PIDAlmacen As String
    Dim PNombreAlmacen As String
    Dim PCadena As String
    Dim Activo As Boolean
    Public Property PActivo As Boolean
        Get
            Return Activo

        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property
    Public Property Cadena As String
        Get
            Return PCadena
        End Get
        Set(value As String)
            PCadena = value
        End Set
    End Property



    Public Property IDAlmacen As String
        Get
            Return PIDAlmacen
        End Get
        Set(value As String)
            PIDAlmacen = value
        End Set
    End Property
    Public Property NombreAlmacen As String
        Get
            Return PNombreAlmacen
        End Get
        Set(value As String)
            PNombreAlmacen = value
        End Set
    End Property




End Class
