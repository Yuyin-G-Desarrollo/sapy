Public Class MaquilaComprobante

    Private datosPagoCompra_ As DatosPago
    Public Property datosPagoCompra() As DatosPago
        Get
            Return datosPagoCompra_
        End Get
        Set(ByVal value As DatosPago)
            datosPagoCompra_ = value
        End Set
    End Property

    ''' <summary>
    ''' Fecha de emisión del documento.  (Fecha que tiene el XML)
    ''' </summary>
    ''' <remarks></remarks>
    Private fechadocumento_ As Date
    Public Property fechadocumento() As Date
        Get
            Return fechadocumento_
        End Get
        Set(ByVal value As Date)
            fechadocumento_ = value
        End Set
    End Property

    ''' <summary>
    ''' Fecha en la que se tiene que liquidar el documento.Fecha de autorización + días plazo del proveedor.
    '''Considerar los días no hábiles
    ''' </summary>
    ''' <remarks></remarks>
    Private fechavencimiento_ As Date
    Public Property fechavencimiento() As Date
        Get
            Return fechavencimiento_
        End Get
        Set(ByVal value As Date)
            fechavencimiento_ = value
        End Set
    End Property


    ''' <summary>
    ''' Año correspondiente a la semana de pago
    ''' </summary>
    ''' <remarks></remarks>
    Private aniopago_ As Integer
    Public Property aniopago() As Integer
        Get
            Return aniopago_
        End Get
        Set(ByVal value As Integer)
            aniopago_ = value
        End Set
    End Property

    ''' <summary>
    ''' Semana de pago correspondiente a la fecha de vencimiento del documento
    ''' </summary>
    ''' <remarks></remarks>
    Private semanaPago_ As Integer
    Public Property semanaPago() As Integer
        Get
            Return semanaPago_
        End Get
        Set(ByVal value As Integer)
            semanaPago_ = value
        End Set
    End Property

    Private usuarioautoriza_ As String
    Public Property usuarioautoriza() As String
        Get
            Return usuarioautoriza_
        End Get
        Set(ByVal value As String)
            usuarioautoriza_ = value
        End Set
    End Property



    Private fechaAutoriza_ As Date
    Public Property fechaAutoriza() As Date
        Get
            Return fechaAutoriza_
        End Get
        Set(ByVal value As Date)
            fechaAutoriza_ = value
        End Set
    End Property


    ''' <summary>
    ''' Anio correspondiente a la semana de compra
    ''' </summary>
    ''' <remarks></remarks>
    Private aniocompra_ As Integer
    Public Property aniocompra() As Integer
        Get
            Return aniocompra_
        End Get
        Set(ByVal value As Integer)
            aniocompra_ = value
        End Set
    End Property

    ''' <summary>
    ''' Semana del año en la cual se autoriza el documento. Mientras el documento
    ''' </summary>
    ''' <remarks></remarks>
    Private semanacompra_ As Integer
    Public Property semanacompra() As Integer
        Get
            Return semanacompra_
        End Get
        Set(ByVal value As Integer)
            semanacompra_ = value
        End Set
    End Property


    ''' <summary>
    ''' C=Capturado,A=Autorizado,R=Rechazado
    ''' </summary>
    ''' <remarks></remarks>
    Private estatus_ As String
    Public Property estatus() As String
        Get
            Return estatus_
        End Get
        Set(ByVal value As String)
            estatus_ = value
        End Set
    End Property


    ''' <summary>
    ''' Fecha a la que corresponden los comprobantes según el producto ingresado
    ''' </summary>
    ''' <remarks></remarks>
    Private fecha_ As Date
    Public Property fecha() As Date
        Get
            Return fecha_
        End Get
        Set(ByVal value As Date)
            fecha_ = value
        End Set
    End Property

    Private idNave_ As String
    Public Property idNave() As String
        Get
            Return idNave_
        End Get
        Set(ByVal value As String)
            idNave_ = value
        End Set
    End Property

    Private usuariocreo_ As String
    Public Property usuariocreo() As String
        Get
            Return usuariocreo_
        End Get
        Set(ByVal value As String)
            usuariocreo_ = value
        End Set
    End Property


    Private rutapdf_ As String
    Public Property rutapdf() As String
        Get
            Return rutapdf_
        End Get
        Set(ByVal value As String)
            rutapdf_ = value
        End Set
    End Property
    Private rutaxml_ As String
    Public Property rutaxml() As String
        Get
            Return rutaxml_
        End Get
        Set(ByVal value As String)
            rutaxml_ = value
        End Set
    End Property

    Private uuid_ As String
    Public Property uuid() As String
        Get
            Return uuid_
        End Get
        Set(ByVal value As String)
            uuid_ = value
        End Set
    End Property


    Private total_ As Double
    Public Property total() As Double
        Get
            Return total_
        End Get
        Set(ByVal value As Double)
            total_ = value
        End Set
    End Property

    Private iva_ As Double
    Public Property iva() As Double
        Get
            Return iva_
        End Get
        Set(ByVal value As Double)
            iva_ = value
        End Set
    End Property


    Private subtotal_ As Double
    Public Property subtotal() As Double
        Get
            Return subtotal_
        End Get
        Set(ByVal value As Double)
            subtotal_ = value
        End Set
    End Property

    Private pares_ As Integer
    Public Property pares() As Integer
        Get
            Return pares_
        End Get
        Set(ByVal value As Integer)
            pares_ = value
        End Set
    End Property


    Private receptorid_ As Integer = 0
    Public Property receptorid() As Integer
        Get
            Return receptorid_
        End Get
        Set(ByVal value As Integer)
            receptorid_ = value
        End Set
    End Property


    Private proveedorid_ As Integer = 0
    Public Property proveedorid() As Integer
        Get
            Return proveedorid_
        End Get
        Set(ByVal value As Integer)
            proveedorid_ = value
        End Set
    End Property


    Private folio_ As String
    Public Property folio() As String
        Get
            Return folio_
        End Get
        Set(ByVal value As String)
            folio_ = value
        End Set
    End Property


    Private tipo_ As String
    Public Property tipo() As String
        Get
            Return tipo_
        End Get
        Set(ByVal value As String)
            tipo_ = value
        End Set
    End Property
    Private idComprobante_ As Integer
    Public Property idComprobante() As Integer
        Get
            Return idComprobante_
        End Get
        Set(ByVal value As Integer)
            idComprobante_ = value
        End Set
    End Property

    Private tipoDocumento_ As Integer
    Public Property tipoDocumento() As Integer
        Get
            Return tipoDocumento_
        End Get
        Set(ByVal value As Integer)
            tipoDocumento_ = value
        End Set
    End Property
    Private idBanco_ As Integer = 0
    Public Property idBanco() As Integer
        Get
            Return idBanco_
        End Get
        Set(ByVal value As Integer)
            idBanco_ = value
        End Set
    End Property
    Private idCuenta_ As Integer = 0
    Public Property idCuenta() As Integer
        Get
            Return idCuenta_
        End Get
        Set(ByVal value As Integer)
            idCuenta_ = value
        End Set
    End Property
    Private rfcReceptor_ As String
    Public Property rfcReceptor() As String
        Get
            Return rfcReceptor_
        End Get
        Set(ByVal value As String)
            rfcReceptor_ = value
        End Set
    End Property
    Private rfcEmisor_ As String
    Public Property rfcEmisor() As String
        Get
            Return rfcEmisor_
        End Get
        Set(ByVal value As String)
            rfcEmisor_ = value
        End Set
    End Property

    Private serie_ As String
    Public Property serie() As String
        Get
            Return serie_
        End Get
        Set(ByVal value As String)
            serie_ = value
        End Set
    End Property
    Private motivo_ As String
    Public Property motivo() As String
        Get
            Return motivo_
        End Get
        Set(ByVal value As String)
            motivo_ = value
        End Set
    End Property
End Class
