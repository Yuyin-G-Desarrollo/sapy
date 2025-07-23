Public Class HistorialDeCompras

    Private ultimodocumento As String
    Public Property hidc_ultimodocumento() As String
        Get
            Return ultimodocumento
        End Get
        Set(ByVal value As String)
            ultimodocumento = value
        End Set
    End Property

Private fechaultimodocumento As datetime
    Public Property hidc_fechaultimodocumento() As DateTime
        Get
            Return fechaultimodocumento
        End Get
        Set(ByVal value As DateTime)
            fechaultimodocumento = value
        End Set
    End Property

Private fechaultimopago As datetime
    Public Property hidc_fechaultimopago() As DateTime
        Get
            Return fechaultimopago
        End Get
        Set(ByVal value As DateTime)
            fechaultimopago = value
        End Set
    End Property

    Private ordendecompra As Integer
    Public Property hidc_ordendecompra() As Integer
        Get
            Return ordendecompra
        End Get
        Set(ByVal value As Integer)
            ordendecompra = value
        End Set
    End Property

Private importeultimopago As double
    Public Property hidc_importeultimopago() As Double
        Get
            Return importeultimopago
        End Get
        Set(ByVal value As Double)
            importeultimopago = value
        End Set
    End Property

Private pagado As char
    Public Property hidc_pagoado() As Char
        Get
            Return pagado
        End Get
        Set(ByVal value As Char)
            pagado = value
        End Set
    End Property

Private saldo As double
    Public Property hidc_saldo() As Double
        Get
            Return saldo
        End Get
        Set(ByVal value As Double)
            saldo = value
        End Set
    End Property

Private proveedorid As integer
    Public Property dage_proveedorid() As Integer
        Get
            Return proveedorid
        End Get
        Set(ByVal value As Integer)
            proveedorid = value
        End Set

    End Property
Private usuariocreoid As integer
    Public Property hidc_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

Private usuariomodificoid As integer
    Public Property hidc_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

Private fechacreacion As datetime
    Public Property hidc_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

Private fechamodificacion As datetime
    Public Property hidc_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property





End Class
