


Public Class DocenasPares

    Dim ID_Docena As String
    Dim ID_Par As List(Of Entidades.LecturaCapturadoAtadoPar)
    Dim ParesErroneos As List(Of Entidades.LecturaCapturadoAtadoPar)
    Dim ParesLeidos As List(Of Entidades.LecturaCapturadoAtadoPar)
    Dim LeerParPorPar As Boolean
    Dim TipoErrorAtado As String
    Dim Descripcion As String
    Dim Talla As String
    Dim Pares As Int32
    Dim Status As String
    Dim idtblnave As Int32
    Dim idtbllote As Int32
    Dim idtblaño As Int32
    Dim idtblPrograma As Int32
    Dim idtblAlmacen As Int32
    Dim Fecha_salida As DateTime
    Dim idtblPedido As Int32
    Dim idtblPartida As Int32
    Dim idtblTienda As Int32
    Dim idtblOrdApartado As Int32
    Dim idtblPartidaOrdApa As Int32
    Dim idtblProducto As String
    Dim idtblTalla As String
    Dim idtblcte As Int32
    Dim TipoNumeracion As String
    Dim Noreg As Int32
    Dim idtblCancelacion As Int32
    Dim Disponible As Int32
    Dim Asignado As Int32
    Dim Calidad As Int32
    Dim Bloqueado As Int32
    Dim Transito As Int32
    Dim Reservado As Int32
    Dim Devolucion As Int32
    Dim idtblMovimiento As Int32
    Dim Reproceso As Int32
    Dim Proyectado As Int32


    Public Property PLeerParPorPar As Boolean
        Get
            Return LeerParPorPar
        End Get
        Set(value As Boolean)
            LeerParPorPar = value
        End Set
    End Property

    Public Property PNoCliente As Int32
        Get
            Return idtblcte
        End Get
        Set(value As Int32)
            idtblcte = value
        End Set
    End Property


    Public Property PTalla As String
        Get
            Return Talla
        End Get
        Set(value As String)
            Talla = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property PLote As Int32
        Get
            Return idtbllote
        End Get
        Set(value As Int32)
            idtbllote = value
        End Set
    End Property

    Public Property PID_Docena As String
        Get
            Return ID_Docena
        End Get
        Set(value As String)
            ID_Docena = value
        End Set
    End Property

    Public Property PID_Par As List(Of Entidades.LecturaCapturadoAtadoPar)
        Get
            Return ID_Par
        End Get
        Set(value As List(Of Entidades.LecturaCapturadoAtadoPar))
            ID_Par = value
        End Set
    End Property


    Public Property PParesErrones As List(Of Entidades.LecturaCapturadoAtadoPar)
        Get
            Return ParesErroneos
        End Get
        Set(value As List(Of Entidades.LecturaCapturadoAtadoPar))
            ParesErroneos = value
        End Set
    End Property


    Public Property PParesLeidos As List(Of Entidades.LecturaCapturadoAtadoPar)
        Get
            Return ParesLeidos
        End Get
        Set(value As List(Of Entidades.LecturaCapturadoAtadoPar))
            ParesLeidos = value
        End Set
    End Property

    Public Property PTipoErrorAtado As String
        Get
            Return TipoErrorAtado
        End Get
        Set(value As String)
            TipoErrorAtado = value
        End Set
    End Property


End Class
