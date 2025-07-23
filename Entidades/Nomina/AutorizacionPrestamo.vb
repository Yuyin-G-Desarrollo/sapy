Public Class AutorizacionPrestamo
    Private prestamoId As Integer
    Private ColabodadorId As Colaborador
    Private gerenteId As Integer
    Private saldo As Double
    Private interes As Double
    Private tipodeinteres As String
    Private abono As Double
    Private semanas As Integer
    Private nombre As String
    Private apellidoPaterno As String
    Private apellidoMaterno As String
    Private estatus As String
    Private justificacion As String

    'Setters y getters de las cuales asignamos y devolvemos los valores desde la consulta
    Public Property PgerenteId As Integer
        Get
            Return gerenteId
        End Get
        Set(ByVal value As Integer)
            gerenteId = value

        End Set
    End Property

    Public Property PColabodadorId As Entidades.Colaborador
        Get
            Return ColabodadorId
        End Get
        Set(ByVal value As Entidades.Colaborador)
            ColabodadorId = value
        End Set
    End Property


    Public Property PprestamoId As Integer
        Get
            Return prestamoId
        End Get
        Set(ByVal value As Integer)
            prestamoId = value
        End Set
    End Property


    Public Property Psaldo As Double
        Get
            Return saldo
        End Get
        Set(ByVal value As Double)
            saldo = value
        End Set
    End Property


    Public Property Pinteres As Double
        Get
            Return interes
        End Get
        Set(ByVal value As Double)
            interes = value
        End Set
    End Property


    Public Property Ptipodeinteres As String
        Get
            Return tipodeinteres
        End Get
        Set(ByVal value As String)
            tipodeinteres = value
        End Set
    End Property

    Public Property Pestatus As String
        Get
            Return estatus
        End Get
        Set(ByVal value As String)
            estatus = value
        End Set
    End Property



    Public Property Pabono As Double
        Get
            Return abono
        End Get
        Set(ByVal value As Double)
            abono = value
        End Set
    End Property

    Public Property Psemanas As Integer
        Get
            Return semanas
        End Get
        Set(ByVal value As Integer)
            semanas = value
        End Set
    End Property


    Public Property Pnombre As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property


    Public Property PapellidoPaterno As String
        Get
            Return apellidoPaterno
        End Get
        Set(ByVal value As String)
            apellidoPaterno = value
        End Set
    End Property


    Public Property PapellidoMaterno As String
        Get
            Return apellidoMaterno
        End Get
        Set(ByVal value As String)
            apellidoMaterno = value
        End Set
    End Property

    Public Property Pjustificacion As String
        Get
            Return justificacion
        End Get
        Set(ByVal value As String)
            justificacion = value
        End Set
    End Property


End Class
