Public Class Polizas

#Region "DIM ALTA POLIZAS SAY"
    Private transferenciaID As Integer
    Private compraID As Integer
    Private ventaID As Integer
    Private VentaCanceladaId As Integer
    Private NotaCreditoID As Integer
    Private NotaCreditoIDCancelada As Integer
    Private NotaCargoID As Integer
    Private cobroID As Integer
    Private rutaXML As String
    Private rutaPDF As String
    Private usuarioCreoID As Integer

    Private IdChequePosfechado As Integer
    Private IdChequeDepositoInterno As Integer
    Private IdChequeDevuelto As Integer
    Private IdChequeDepositoDevuelto As Integer

    Private tipoPoliza As Integer
    Private ccSAYID As Integer
#End Region

#Region "DIM ALTA POLIZAS"

    Private serie As String
    Private folio As String
    Private fecha As DateTime
    Private uuid As String
    Private referencia As String
    Private tipoMovimiento As Integer
    Private numMovimiento As Integer
    Private guid As Guid
    Private polizaID As Integer
    Private polizaCONTPAQID As Integer
    Private ejercicio As Integer
    Private periodo As Integer
    Private tipoPolizaCompaq As Integer
    Private concepto As String
    Private cargos As Double
    Private abonos As Double
    Private subtotal As Double
    Private iva As Double
    Private clabeInterbancaria As String
    Private bancoContpaqid As String
    Private CuentaGeneralContpaqid As String
    Private totalPoliza As Double
    Private diarioID As Integer

#End Region

#Region "DIM DATOS SERVIDOR"
    Private servidorBD As String
    Private empresaBD As String
#End Region

#Region "DIM ALTA CUENTAS CONTABLES"
    Private cuentaContable As String
    Private constante1 As String
    Private constante2 As String
    Private letra As String
    Private consecutivo As String
    Private ccContpaqID As Integer
    Private ccSICYID As Integer
    Private proveedorID As Integer
    Private proveedorSicyID As Integer
    Private ccTipo As Integer
    Private empresaID As Integer
    Private clienteID As String
#End Region

#Region "DIM ALTA PERSONAS"
    Private proveedorNombre As String
    Private proveedorRFC As String
    Private proveedorCURP As String
    Private proveedorPersonaID As Integer
#End Region

#Region "Get/Set ALTA POLIZAS SAY"
    Public Property PtransferenciaID As Integer
        Get
            Return transferenciaID
        End Get
        Set(value As Integer)
            transferenciaID = value
        End Set
    End Property

    Public Property PcompraID As Integer
        Get
            Return compraID
        End Get
        Set(value As Integer)
            compraID = value
        End Set
    End Property

    Public Property PventaID As Integer
        Get
            Return ventaID
        End Get
        Set(value As Integer)
            ventaID = value
        End Set
    End Property

    Public Property PventaCanceladaID As Integer
        Get
            Return VentaCanceladaId
        End Get
        Set(value As Integer)
            VentaCanceladaId = value
        End Set
    End Property

    Public Property PNotaCredito As Integer
        Get
            Return NotaCreditoID
        End Get
        Set(value As Integer)
            NotaCreditoID = value
        End Set
    End Property

    Public Property PNotaCreditoCandelada As Integer
        Get
            Return NotaCreditoIDCancelada
        End Get
        Set(value As Integer)
            NotaCreditoIDCancelada = value
        End Set
    End Property

    Public Property PNotaCargo As Integer
        Get
            Return NotaCargoID
        End Get
        Set(value As Integer)
            NotaCargoID = value
        End Set
    End Property

    Public Property pcobroid As Integer
        Get
            Return cobroID
        End Get
        Set(value As Integer)
            cobroID = value
        End Set
    End Property

    Public Property PrutaXML As String
        Get
            Return rutaXML
        End Get
        Set(value As String)
            rutaXML = value
        End Set
    End Property

    Public Property PrutaPDF As String
        Get
            Return rutaPDF
        End Get
        Set(value As String)
            rutaPDF = value
        End Set
    End Property

    Public Property PusuarioCreoID As Integer
        Get
            Return usuarioCreoID
        End Get
        Set(value As Integer)
            usuarioCreoID = value
        End Set
    End Property

    Public Property PtipoPoliza As Integer
        Get
            Return tipoPoliza
        End Get
        Set(value As Integer)
            tipoPoliza = value
        End Set
    End Property

    Public Property PccSAYID As Integer
        Get
            Return ccSAYID
        End Get
        Set(value As Integer)
            ccSAYID = value
        End Set
    End Property

#End Region

#Region "Get/Set ALTA POLIZAS"

    Public Property Pserie As String
        Get
            Return serie
        End Get
        Set(value As String)
            serie = value
        End Set
    End Property

    Public Property Pfolio As String
        Get
            Return folio
        End Get
        Set(value As String)
            folio = value
        End Set
    End Property

    Public Property Pfecha As DateTime
        Get
            Return fecha
        End Get
        Set(value As DateTime)
            fecha = value
        End Set
    End Property

    Public Property Puuid As String
        Get
            Return uuid
        End Get
        Set(value As String)
            uuid = value
        End Set
    End Property

    Public Property Preferencia As String
        Get
            Return referencia
        End Get
        Set(value As String)
            referencia = value
        End Set
    End Property

    Public Property PtipoMovimiento As Integer
        Get
            Return tipoMovimiento
        End Get
        Set(value As Integer)
            tipoMovimiento = value
        End Set
    End Property

    Public Property PnumMovimiento As Integer
        Get
            Return numMovimiento
        End Get
        Set(value As Integer)
            numMovimiento = value
        End Set
    End Property

    Public Property Pguid As Guid
        Get
            Return guid
        End Get
        Set(value As Guid)
            guid = value
        End Set
    End Property

    Public Property PpolizaID As Integer
        Get
            Return polizaID
        End Get
        Set(value As Integer)
            polizaID = value
        End Set
    End Property

    Public Property PpolizaCONTPAQID As Integer
        Get
            Return polizaCONTPAQID
        End Get
        Set(value As Integer)
            polizaCONTPAQID = value
        End Set
    End Property

    Public Property Pejercicio As Integer
        Get
            Return ejercicio
        End Get
        Set(value As Integer)
            ejercicio = value
        End Set
    End Property

    Public Property Pperiodo As Integer
        Get
            Return periodo
        End Get
        Set(value As Integer)
            periodo = value
        End Set
    End Property

    Public Property PtipoPolizaCompaq As Integer
        Get
            Return tipoPolizaCompaq
        End Get
        Set(value As Integer)
            tipoPolizaCompaq = value
        End Set
    End Property

    Public Property Pconcepto As String
        Get
            Return concepto
        End Get
        Set(value As String)
            concepto = value
        End Set
    End Property

    Public Property Pcargos As Double
        Get
            Return cargos
        End Get
        Set(value As Double)
            cargos = value
        End Set
    End Property

    Public Property Pabonos As Double
        Get
            Return abonos
        End Get
        Set(value As Double)
            abonos = value
        End Set
    End Property

    Public Property Psubtotal As Double
        Get
            Return subtotal
        End Get
        Set(value As Double)
            subtotal = value
        End Set
    End Property

    Public Property Piva As Double
        Get
            Return iva
        End Get
        Set(value As Double)
            iva = value
        End Set
    End Property

    Public Property PclabeInterbancaria As String
        Get
            Return clabeInterbancaria
        End Get
        Set(value As String)
            clabeInterbancaria = value
        End Set
    End Property

    Public Property PbancoContpaqid As String
        Get
            Return bancoContpaqid
        End Get
        Set(value As String)
            bancoContpaqid = value
        End Set
    End Property

    Public Property PCuentaGeneralContpaqid As String
        Get
            Return CuentaGeneralContpaqid
        End Get
        Set(value As String)
            CuentaGeneralContpaqid = value
        End Set
    End Property

    Public Property PtotalPoliza As Double
        Get
            Return totalPoliza
        End Get
        Set(value As Double)
            totalPoliza = value
        End Set
    End Property

    Public Property PdiarioID As Integer
        Get
            Return diarioID
        End Get
        Set(value As Integer)
            diarioID = value
        End Set
    End Property

    Public Property PIdChequePosfechado As Integer
        Get
            Return IdChequePosfechado
        End Get
        Set(value As Integer)
            IdChequePosfechado = value
        End Set
    End Property

    Public Property PIdChequeDepositoInterno As Integer
        Get
            Return IdChequeDepositoInterno
        End Get
        Set(value As Integer)
            IdChequeDepositoInterno = value
        End Set
    End Property


    Public Property PIdChequeDevuelto As Integer
        Get
            Return IdChequeDevuelto
        End Get
        Set(value As Integer)
            IdChequeDevuelto = value
        End Set
    End Property

    Public Property PIdChequeDepositoDevuelto As Integer
        Get
            Return IdChequeDepositoDevuelto
        End Get
        Set(value As Integer)
            IdChequeDepositoDevuelto = value
        End Set
    End Property
   

#End Region


#Region "Get/Set Datos servidor"
    Public Property PservidorBD As String
        Get
            Return servidorBD
        End Get
        Set(value As String)
            servidorBD = value
        End Set
    End Property

    Public Property PempresaBD As String
        Get
            Return empresaBD
        End Get
        Set(value As String)
            empresaBD = value
        End Set
    End Property
#End Region

#Region "Get/Set Alta cuentas contables"

    Public Property PcuentaContable As String
        Get
            Return cuentaContable
        End Get
        Set(value As String)
            cuentaContable = value
        End Set
    End Property

    Public Property Pconstante1 As String
        Get
            Return constante1
        End Get
        Set(value As String)
            constante1 = value
        End Set
    End Property

    Public Property Pconstante2 As String
        Get
            Return constante2
        End Get
        Set(value As String)
            constante2 = value
        End Set
    End Property

    Public Property Pletra As String
        Get
            Return letra
        End Get
        Set(value As String)
            letra = value
        End Set
    End Property

    Public Property Pconsecutivo As String
        Get
            Return consecutivo
        End Get
        Set(value As String)
            consecutivo = value
        End Set
    End Property

    Public Property PccContpaqID As Integer
        Get
            Return ccContpaqID
        End Get
        Set(value As Integer)
            ccContpaqID = value
        End Set
    End Property

    Public Property PccSICYID As Integer
        Get
            Return ccSICYID
        End Get
        Set(value As Integer)
            ccSICYID = value
        End Set
    End Property

    Public Property PproveedoID As Integer
        Get
            Return proveedorID
        End Get
        Set(value As Integer)
            proveedorID = value
        End Set
    End Property

    Public Property PproveedorSicyID As Integer
        Get
            Return proveedorSicyID
        End Get
        Set(value As Integer)
            proveedorSicyID = value
        End Set
    End Property

    Public Property PccTipo As Integer
        Get
            Return ccTipo
        End Get
        Set(value As Integer)
            ccTipo = value
        End Set
    End Property

    Public Property PempresaID As Integer
        Get
            Return empresaID
        End Get
        Set(value As Integer)
            empresaID = value
        End Set
    End Property

    Public Property PclienteID As String
        Get
            Return clienteID
        End Get
        Set(value As String)
            clienteID = value
        End Set
    End Property
#End Region

#Region "Get/Set Alta personas"
    Public Property PproveedorNombre As String
        Get
            Return proveedorNombre
        End Get
        Set(value As String)
            proveedorNombre = value
        End Set
    End Property

    Public Property PproveedorRFC As String
        Get
            Return proveedorRFC
        End Get
        Set(value As String)
            proveedorRFC = value
        End Set
    End Property

    Public Property PproveedorCurp As String
        Get
            Return proveedorRFC
        End Get
        Set(value As String)
            proveedorRFC = value
        End Set
    End Property

    Public Property PproveedorPersonaID As Integer
        Get
            Return proveedorPersonaID
        End Get
        Set(value As Integer)
            proveedorPersonaID = value
        End Set
    End Property

#End Region

End Class
