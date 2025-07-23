Imports Entidades

Public Class DevolucionCliente

    Private _devolucionclienteid As Integer
    Private _tipodevolucion As String
    Private _clienteid As Integer
    Private _nombreCliente As String
    Private _statusid As Integer
    Private _estatus As String
    Private _resolucion As String
    Private _procedeautoriza As String
    Private _fechacaptura As Date
    Private _UsuarioAtnCte As String
    Private _usuariocapturaid As Integer
    Private _usuariocaptura As String
    Private _fecharecepcion As Date
    Private _colaboradorid_recibio As Integer
    Private _cantidad_inicial As Integer
    Private _unidadid As Integer
    Private _unidad As String
    Private _cajas As Integer
    Private _motivoinicialalmacen_statusid As Integer
    Private _motivoinicialalmacen As String
    Private _observaciones_almacen As String
    Private _paqueteria_proveedorid As Integer
    Private _tipofleteid As Integer
    Private _costopaqueteria As Double
    Private _numeroguia As String
    Private _modelos_say As String
    Private _colores_say As String
    Private _corridas_say As String
    Private _almacen_actual_estatusid As Integer
    Private _almacen_usuariomodificaid As Integer
    Private _almacen_usuariomodifica As String
    Private _almacen_fechamodificacion As Date
    Private _fechalimiteaccion As Date
    Private _dias_transcurridosventas As Int16
    Private _indicarecepcion As String
    Private _motivoventas_statusid As Integer
    Private _motivoventas As String
    Private _destinoproducto As String
    Private _requiereautorizacion As Int16
    Private _rutaautorizacion As String
    Private _aplicanotacredito As Int16
    Private _responsabledevolucion_estatusid As Integer
    Private _observaciones_ventas As String
    Private _ventas_usuariomodificaid As Integer
    Private _ventas_usuariomodifica As String
    Private _ventas_fechamodificacion As Date
    Private _ventas_fechaEnviadoRevision As Date
    Private _observaciones_cobranza As String
    Private _cantidadtotal As Integer
    Private _total As Double
    Private _devolucionsicyid As Integer
    Private _cantidad_aplicado As Integer
    Private _cantidad_poraplicar As Integer
    Private _fechaConclusion As Date
    Private _pedidos As String
    Private _pedidosSAY As String
    Private _pedidosSICY As String
    Private _XMLdocumentos As String
    Private _identificadorDocumentos As String
    Private _documentosdetalles As String
    Private _Remisiones As String
    Private _sinDocumentos As Int16
    Private _cobranza_fechaMoficacion As Date
    Private _cobranza_usuarioModificaid As Integer
    Private _cobranza_usuarioModifica As String
    Private _UsuarioPasaEmbarquesID As Integer
    Private _UsuarioPasaEmbarques As String
    Private _UsuarioSolicitaNCId As Integer
    Private _UsuarioSolicitaNC As String
    Private _FechaPasaEmbarques As Date
    Private _DiasProcesamiento As Int16

    Private _UsuarioIDGeneraLote As Integer
    Private _UsuarioGeneraLote As String
    Private _FechaGeneraLote As Date
    Private _LoteGenerado As Boolean
    Private _ObservacionFactura As String

    Public Property Devolucionclienteid As Integer
        Get
            Return _devolucionclienteid
        End Get
        Set(value As Integer)
            _devolucionclienteid = value
        End Set
    End Property

    Public Property Tipodevolucion As String
        Get
            Return _tipodevolucion
        End Get
        Set(value As String)
            _tipodevolucion = value
        End Set
    End Property

    Public Property Clienteid As Integer
        Get
            Return _clienteid
        End Get
        Set(value As Integer)
            _clienteid = value
        End Set
    End Property

    Public Property Statusid As Integer
        Get
            Return _statusid
        End Get
        Set(value As Integer)
            _statusid = value
        End Set
    End Property

    Public Property Resolucion As String
        Get
            Return _resolucion
        End Get
        Set(value As String)
            _resolucion = value
        End Set
    End Property

    Public Property Procedeautoriza As String
        Get
            Return _procedeautoriza
        End Get
        Set(value As String)
            _procedeautoriza = value
        End Set
    End Property

    Public Property Fechacaptura As Date
        Get
            Return _fechacaptura
        End Get
        Set(value As Date)
            _fechacaptura = value
        End Set
    End Property

    Public Property Usuariocapturaid As Integer
        Get
            Return _usuariocapturaid
        End Get
        Set(value As Integer)
            _usuariocapturaid = value
        End Set
    End Property

    Public Property Fecharecepcion As Date
        Get
            Return _fecharecepcion
        End Get
        Set(value As Date)
            _fecharecepcion = value
        End Set
    End Property

    Public Property Colaboradorid_recibio As Integer
        Get
            Return _colaboradorid_recibio
        End Get
        Set(value As Integer)
            _colaboradorid_recibio = value
        End Set
    End Property

    Public Property Cantidad_inicial As Integer
        Get
            Return _cantidad_inicial
        End Get
        Set(value As Integer)
            _cantidad_inicial = value
        End Set
    End Property

    Public Property Unidadid As Integer
        Get
            Return _unidadid
        End Get
        Set(value As Integer)
            _unidadid = value
        End Set
    End Property

    Public Property Cajas As Integer
        Get
            Return _cajas
        End Get
        Set(value As Integer)
            _cajas = value
        End Set
    End Property

    Public Property Motivoinicialalmacen_statusid As Integer
        Get
            Return _motivoinicialalmacen_statusid
        End Get
        Set(value As Integer)
            _motivoinicialalmacen_statusid = value
        End Set
    End Property

    Public Property Observaciones_almacen As String
        Get
            Return _observaciones_almacen
        End Get
        Set(value As String)
            _observaciones_almacen = value
        End Set
    End Property

    Public Property Paqueteria_proveedorid As Integer
        Get
            Return _paqueteria_proveedorid
        End Get
        Set(value As Integer)
            _paqueteria_proveedorid = value
        End Set
    End Property

    Public Property Tipofleteid As Integer
        Get
            Return _tipofleteid
        End Get
        Set(value As Integer)
            _tipofleteid = value
        End Set
    End Property

    Public Property Costopaqueteria As Double
        Get
            Return _costopaqueteria
        End Get
        Set(value As Double)
            _costopaqueteria = value
        End Set
    End Property

    Public Property Numeroguia As String
        Get
            Return _numeroguia
        End Get
        Set(value As String)
            _numeroguia = value
        End Set
    End Property

    Public Property Modelos_say As String
        Get
            Return _modelos_say
        End Get
        Set(value As String)
            _modelos_say = value
        End Set
    End Property

    Public Property Colores_say As String
        Get
            Return _colores_say
        End Get
        Set(value As String)
            _colores_say = value
        End Set
    End Property

    Public Property Corridas_say As String
        Get
            Return _corridas_say
        End Get
        Set(value As String)
            _corridas_say = value
        End Set
    End Property

    Public Property Almacen_usuariomodificaid As Integer
        Get
            Return _almacen_usuariomodificaid
        End Get
        Set(value As Integer)
            _almacen_usuariomodificaid = value
        End Set
    End Property

    Public Property Almacen_fechamodificacion As Date
        Get
            Return _almacen_fechamodificacion
        End Get
        Set(value As Date)
            _almacen_fechamodificacion = value
        End Set
    End Property

    Public Property Fechalimiteaccion As Date
        Get
            Return _fechalimiteaccion
        End Get
        Set(value As Date)
            _fechalimiteaccion = value
        End Set
    End Property

    Public Property Dias_transcurridosventas As Short
        Get
            Return _dias_transcurridosventas
        End Get
        Set(value As Short)
            _dias_transcurridosventas = value
        End Set
    End Property

    Public Property Indicarecepcion As String
        Get
            Return _indicarecepcion
        End Get
        Set(value As String)
            _indicarecepcion = value
        End Set
    End Property

    Public Property Motivoventas_statusid As Integer
        Get
            Return _motivoventas_statusid
        End Get
        Set(value As Integer)
            _motivoventas_statusid = value
        End Set
    End Property

    Public Property Destinoproducto As String
        Get
            Return _destinoproducto
        End Get
        Set(value As String)
            _destinoproducto = value
        End Set
    End Property

    Public Property Requiereautorizacion As Short
        Get
            Return _requiereautorizacion
        End Get
        Set(value As Short)
            _requiereautorizacion = value
        End Set
    End Property

    Public Property Rutaautorizacion As String
        Get
            Return _rutaautorizacion
        End Get
        Set(value As String)
            _rutaautorizacion = value
        End Set
    End Property

    Public Property Aplicanotacredito As Short
        Get
            Return _aplicanotacredito
        End Get
        Set(value As Short)
            _aplicanotacredito = value
        End Set
    End Property

    Public Property Observaciones_ventas As String
        Get
            Return _observaciones_ventas
        End Get
        Set(value As String)
            _observaciones_ventas = value
        End Set
    End Property

    Public Property Ventas_usuariomodificaid As Integer
        Get
            Return _ventas_usuariomodificaid
        End Get
        Set(value As Integer)
            _ventas_usuariomodificaid = value
        End Set
    End Property

    Public Property Ventas_fechamodificacion As Date
        Get
            Return _ventas_fechamodificacion
        End Get
        Set(value As Date)
            _ventas_fechamodificacion = value
        End Set
    End Property

    Public Property Observaciones_cobranza As String
        Get
            Return _observaciones_cobranza
        End Get
        Set(value As String)
            _observaciones_cobranza = value
        End Set
    End Property

    Public Property Cantidadtotal As Integer
        Get
            Return _cantidadtotal
        End Get
        Set(value As Integer)
            _cantidadtotal = value
        End Set
    End Property

    Public Property Total As Double
        Get
            Return _total
        End Get
        Set(value As Double)
            _total = value
        End Set
    End Property

    Public Property Devolucionsicyid As Integer
        Get
            Return _devolucionsicyid
        End Get
        Set(value As Integer)
            _devolucionsicyid = value
        End Set
    End Property

    Public Property Cantidad_aplicado As Integer
        Get
            Return _cantidad_aplicado
        End Get
        Set(value As Integer)
            _cantidad_aplicado = value
        End Set
    End Property

    Public Property Cantidad_poraplicar As Integer
        Get
            Return _cantidad_poraplicar
        End Get
        Set(value As Integer)
            _cantidad_poraplicar = value
        End Set
    End Property

    Public Property Almacen_actual_estatusid As Integer
        Get
            Return _almacen_actual_estatusid
        End Get
        Set(value As Integer)
            _almacen_actual_estatusid = value
        End Set
    End Property

    Public Property Responsabledevolucion_estatusid As Integer
        Get
            Return _responsabledevolucion_estatusid
        End Get
        Set(value As Integer)
            _responsabledevolucion_estatusid = value
        End Set
    End Property

    Public Property FechaConclusion As Date
        Get
            Return _fechaConclusion
        End Get
        Set(value As Date)
            _fechaConclusion = value
        End Set
    End Property

    Public Property Pedidos As String
        Get
            Return _pedidos
        End Get
        Set(value As String)
            _pedidos = value
        End Set
    End Property

    Public Property PedidosSAY As String
        Get
            Return _pedidosSAY
        End Get
        Set(value As String)
            _pedidosSAY = value
        End Set
    End Property

    Public Property PedidosSICY As String
        Get
            Return _pedidosSICY
        End Get
        Set(value As String)
            _pedidosSICY = value
        End Set
    End Property

    Public Property XMLDocumentos As String
        Get
            Return _XMLdocumentos
        End Get
        Set(value As String)
            _XMLdocumentos = value
        End Set
    End Property

    Public Property NombreCliente As String
        Get
            Return _nombreCliente
        End Get
        Set(value As String)
            _nombreCliente = value
        End Set
    End Property

    Public Property SinDocumentos As Short
        Get
            Return _sinDocumentos
        End Get
        Set(value As Short)
            _sinDocumentos = value
        End Set
    End Property

    Public Property Ventas_fechaEnviadoRevision As Date
        Get
            Return _ventas_fechaEnviadoRevision
        End Get
        Set(value As Date)
            _ventas_fechaEnviadoRevision = value
        End Set
    End Property

    Public Property Estatus As String
        Get
            Return _estatus
        End Get
        Set(value As String)
            _estatus = value
        End Set
    End Property

    Public Property IdentificadorDocumentos As String
        Get
            Return _identificadorDocumentos
        End Get
        Set(value As String)
            _identificadorDocumentos = value
        End Set
    End Property

    Public Property Cobranza_fechaMoficacion As Date
        Get
            Return _cobranza_fechaMoficacion
        End Get
        Set(value As Date)
            _cobranza_fechaMoficacion = value
        End Set
    End Property

    Public Property Usuariocaptura As String
        Get
            Return _usuariocaptura
        End Get
        Set(value As String)
            _usuariocaptura = value
        End Set
    End Property

    Public Property Almacen_usuariomodifica As String
        Get
            Return _almacen_usuariomodifica
        End Get
        Set(value As String)
            _almacen_usuariomodifica = value
        End Set
    End Property

    Public Property Cobranza_usuarioModificaid As Integer
        Get
            Return _cobranza_usuarioModificaid
        End Get
        Set(value As Integer)
            _cobranza_usuarioModificaid = value
        End Set
    End Property

    Public Property Ventas_usuariomodifica As String
        Get
            Return _ventas_usuariomodifica
        End Get
        Set(value As String)
            _ventas_usuariomodifica = value
        End Set
    End Property

    Public Property Cobranza_usuarioModifica As String
        Get
            Return _cobranza_usuarioModifica
        End Get
        Set(value As String)
            _cobranza_usuarioModifica = value
        End Set
    End Property

    Public Property Unidad As String
        Get
            Return _unidad
        End Get
        Set(value As String)
            _unidad = value
        End Set
    End Property

    Public Property Motivoinicialalmacen As String
        Get
            Return _motivoinicialalmacen
        End Get
        Set(value As String)
            _motivoinicialalmacen = value
        End Set
    End Property

    Public Property Motivoventas As String
        Get
            Return _motivoventas
        End Get
        Set(value As String)
            _motivoventas = value
        End Set
    End Property

    Public Property UsuarioPasaEmbarquesID As Integer
        Get
            Return _UsuarioPasaEmbarquesID
        End Get
        Set(value As Integer)
            _UsuarioPasaEmbarquesID = value
        End Set
    End Property

    Public Property UsuarioPasaEmbarques As String
        Get
            Return _UsuarioPasaEmbarques
        End Get
        Set(value As String)
            _UsuarioPasaEmbarques = value
        End Set
    End Property

    Public Property FechaPasaEmbarques As Date
        Get
            Return _FechaPasaEmbarques
        End Get
        Set(value As Date)
            _FechaPasaEmbarques = value
        End Set
    End Property


    Public Property UsuarioIDGeneraLote As Integer
        Get
            Return _UsuarioIDGeneraLote
        End Get
        Set(value As Integer)
            _UsuarioIDGeneraLote = value
        End Set
    End Property

    Public Property UsuarioGeneraLote As String
        Get
            Return _UsuarioGeneraLote
        End Get
        Set(value As String)
            _UsuarioGeneraLote = value
        End Set
    End Property

    Public Property FechaGeneraLote As Date
        Get
            Return _FechaGeneraLote
        End Get
        Set(value As Date)
            _FechaGeneraLote = value
        End Set
    End Property

    Public Property LoteGenerado As Boolean
        Get
            Return _LoteGenerado
        End Get
        Set(value As Boolean)
            _LoteGenerado = value
        End Set
    End Property

    Public Property UsuarioSolicitaNCId As Integer
        Get
            Return _UsuarioSolicitaNCId
        End Get
        Set(value As Integer)
            _UsuarioSolicitaNCId = value
        End Set
    End Property

    Public Property UsuarioSolicitaNC As String
        Get
            Return _UsuarioSolicitaNC
        End Get
        Set(value As String)
            _UsuarioSolicitaNC = value
        End Set
    End Property

    Public Property DiasProcesamiento As Short
        Get
            Return _DiasProcesamiento
        End Get
        Set(value As Short)
            _DiasProcesamiento = value
        End Set
    End Property

    Public Property Documentosdetalles As String
        Get
            Return _documentosdetalles
        End Get
        Set(value As String)
            _documentosdetalles = value
        End Set
    End Property

    Public Property Remisiones As String
        Get
            Return _Remisiones
        End Get
        Set(value As String)
            _Remisiones = value
        End Set
    End Property

    Public Property UsuarioAtnCte As String
        Get
            Return _UsuarioAtnCte
        End Get
        Set(value As String)
            _UsuarioAtnCte = value
        End Set
    End Property

    Public Property ObservacionFactura As String
        Get
            Return _ObservacionFactura
        End Get
        Set(value As String)
            _ObservacionFactura = value
        End Set
    End Property

    Public Shared Widening Operator CType(v As DevolucionCliente) As List(Of Object)
        Throw New NotImplementedException()
    End Operator
End Class
