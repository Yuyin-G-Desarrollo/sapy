''' <summary>
''' Clase que permite gestionar la visibilidad y uso de los componentes de las pantallas de devoluciones (botones, cajas de texto, radio botones, etc)
''' </summary>
Public Class DevolucionCliente_ComponentesPantallas
    ' Componentes de la pantalla "Administrador de devoluciones"
    Dim _btnAgregar As Boolean
    Dim _btnEditar_formAdmin As Boolean
    Dim _btnDisponerDelProducto As Boolean
    Dim _btnEntregaEmbarques As Boolean
    Dim _btnCancelarDev As Boolean

    ' Componentes pantallaAgregarEditarDevolución (Sección de cabecera)
    Dim _btnEditar_formAltaEdicion As Boolean
    Dim _btnVerDetalles_formAltaEdicion As Boolean
    Dim _btnSolicitarDocumentos As Boolean
    Dim _btnSolictarNotaCredito As Boolean
    Dim _cmbTipoDev As Boolean

    ' Componentes pantallaAgregarEditarDevolución (Panel de almacén)
    Dim _pnlAlmacen As Boolean
    Dim _cmbUnidad As Boolean
    Dim _cmbUbicacion As Boolean
    Dim _controlPedidos As Boolean
    Dim _cmbMotivo_Almacen As Boolean
    Dim _btnGuardar_pnlAlmacen As Boolean

    ' Componentes pantallaAgregarEditarDevolución (Panel ventas)
    Dim _pnlVentas As Boolean
    Dim _controlDocumentos As Boolean
    Dim _rdbAplicaNotaCredito As Boolean
    Dim _btnGuardar_Ventas As Boolean

    ' Componentes pantallaDetalles
    Dim _edicionPrecio As Boolean
    Dim _btnAgregarArticulo As Boolean
    Dim _btnEliminarDetalle As Boolean

    ' Componentes pantallaLecturaCodigos
    Dim _btnIniciar As Boolean
    Dim _btnEliminarCorrectos As Boolean
    Dim _btnEliminarErroneos As Boolean
    Dim _btnGuardar_codigos As Boolean

    Public Property BtnAgregar As Boolean
        Get
            Return _btnAgregar
        End Get
        Set(value As Boolean)
            _btnAgregar = value
        End Set
    End Property

    Public Property BtnEditar_formAdmin As Boolean
        Get
            Return _btnEditar_formAdmin
        End Get
        Set(value As Boolean)
            _btnEditar_formAdmin = value
        End Set
    End Property

    Public Property BtnDisponerDelProducto As Boolean
        Get
            Return _btnDisponerDelProducto
        End Get
        Set(value As Boolean)
            _btnDisponerDelProducto = value
        End Set
    End Property

    Public Property BtnEntregaEmbarques As Boolean
        Get
            Return _btnEntregaEmbarques
        End Get
        Set(value As Boolean)
            _btnEntregaEmbarques = value
        End Set
    End Property

    Public Property BtnCancelarDev As Boolean
        Get
            Return _btnCancelarDev
        End Get
        Set(value As Boolean)
            _btnCancelarDev = value
        End Set
    End Property

    Public Property BtnEditar_formAltaEdicion As Boolean
        Get
            Return _btnEditar_formAltaEdicion
        End Get
        Set(value As Boolean)
            _btnEditar_formAltaEdicion = value
        End Set
    End Property

    Public Property BtnVerDetalles_formAltaEdicion As Boolean
        Get
            Return _btnVerDetalles_formAltaEdicion
        End Get
        Set(value As Boolean)
            _btnVerDetalles_formAltaEdicion = value
        End Set
    End Property

    Public Property BtnSolicitarDocumentos As Boolean
        Get
            Return _btnSolicitarDocumentos
        End Get
        Set(value As Boolean)
            _btnSolicitarDocumentos = value
        End Set
    End Property

    Public Property BtnSolictarNotaCredito As Boolean
        Get
            Return _btnSolictarNotaCredito
        End Get
        Set(value As Boolean)
            _btnSolictarNotaCredito = value
        End Set
    End Property

    Public Property CmbTipoDev As Boolean
        Get
            Return _cmbTipoDev
        End Get
        Set(value As Boolean)
            _cmbTipoDev = value
        End Set
    End Property

    Public Property PnlAlmacen As Boolean
        Get
            Return _pnlAlmacen
        End Get
        Set(value As Boolean)
            _pnlAlmacen = value
        End Set
    End Property

    Public Property CmbUnidad As Boolean
        Get
            Return _cmbUnidad
        End Get
        Set(value As Boolean)
            _cmbUnidad = value
        End Set
    End Property

    Public Property CmbUbicacion As Boolean
        Get
            Return _cmbUbicacion
        End Get
        Set(value As Boolean)
            _cmbUbicacion = value
        End Set
    End Property

    Public Property ControlPedidos As Boolean
        Get
            Return _controlPedidos
        End Get
        Set(value As Boolean)
            _controlPedidos = value
        End Set
    End Property

    Public Property CmbMotivo_Almacen As Boolean
        Get
            Return _cmbMotivo_Almacen
        End Get
        Set(value As Boolean)
            _cmbMotivo_Almacen = value
        End Set
    End Property

    Public Property BtnGuardar_pnlAlmacen As Boolean
        Get
            Return _btnGuardar_pnlAlmacen
        End Get
        Set(value As Boolean)
            _btnGuardar_pnlAlmacen = value
        End Set
    End Property

    Public Property PnlVentas As Boolean
        Get
            Return _pnlVentas
        End Get
        Set(value As Boolean)
            _pnlVentas = value
        End Set
    End Property

    Public Property ControlDocumentos As Boolean
        Get
            Return _controlDocumentos
        End Get
        Set(value As Boolean)
            _controlDocumentos = value
        End Set
    End Property

    Public Property RdbAplicaNotaCredito As Boolean
        Get
            Return _rdbAplicaNotaCredito
        End Get
        Set(value As Boolean)
            _rdbAplicaNotaCredito = value
        End Set
    End Property

    Public Property BtnGuardar_Ventas As Boolean
        Get
            Return _btnGuardar_Ventas
        End Get
        Set(value As Boolean)
            _btnGuardar_Ventas = value
        End Set
    End Property

    Public Property EdicionPrecio As Boolean
        Get
            Return _edicionPrecio
        End Get
        Set(value As Boolean)
            _edicionPrecio = value
        End Set
    End Property

    Public Property BtnAgregarArticulo As Boolean
        Get
            Return _btnAgregarArticulo
        End Get
        Set(value As Boolean)
            _btnAgregarArticulo = value
        End Set
    End Property

    Public Property BtnEliminarDetalle As Boolean
        Get
            Return _btnEliminarDetalle
        End Get
        Set(value As Boolean)
            _btnEliminarDetalle = value
        End Set
    End Property

    Public Property BtnIniciar As Boolean
        Get
            Return _btnIniciar
        End Get
        Set(value As Boolean)
            _btnIniciar = value
        End Set
    End Property

    Public Property BtnEliminarCorrectos As Boolean
        Get
            Return _btnEliminarCorrectos
        End Get
        Set(value As Boolean)
            _btnEliminarCorrectos = value
        End Set
    End Property

    Public Property BtnEliminarErroneos As Boolean
        Get
            Return _btnEliminarErroneos
        End Get
        Set(value As Boolean)
            _btnEliminarErroneos = value
        End Set
    End Property

    Public Property BtnGuardar_codigos As Boolean
        Get
            Return _btnGuardar_codigos
        End Get
        Set(value As Boolean)
            _btnGuardar_codigos = value
        End Set
    End Property
End Class
