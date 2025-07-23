
Public Class DatosProveedor


    Private NombreComercial As String
    Public Property dage_nombrecomercial() As String
        Get
            Return NombreComercial
        End Get
        Set(ByVal value As String)
            NombreComercial = value
        End Set
    End Property


    Private NombreGenerico As String
    Public Property prov_nombregenerico() As String
        Get
            Return NombreGenerico
        End Get
        Set(ByVal value As String)
            NombreGenerico = value
        End Set
    End Property

    Private ProvProveedorID As Integer
    Public Property prov_ProveedorID() As Integer
        Get
            Return ProvProveedorID
        End Get
        Set(ByVal value As Integer)
            ProvProveedorID = value
        End Set
    End Property

    Private rfc As String
    Public Property prov_rfc() As String
        Get
            Return rfc
        End Get
        Set(ByVal value As String)
            rfc = value
        End Set
    End Property

    Private ciudadid As Integer
    Public Property prov_ciudadid() As Integer
        Get
            Return ciudadid
        End Get
        Set(ByVal value As Integer)
            ciudadid = value
        End Set
    End Property

    Private estadoid As Integer
    Public Property prov_estadoid() As Integer
        Get
            Return estadoid
        End Get
        Set(ByVal value As Integer)
            estadoid = value
        End Set
    End Property

    Private paisid As Integer
    Public Property prov_paisid() As Integer
        Get
            Return paisid
        End Get
        Set(ByVal value As Integer)
            paisid = value
        End Set
    End Property

    Private tiporazonsocial As String
    Public Property prov_tiporazonsocial() As String
        Get
            Return tiporazonsocial
        End Get
        Set(ByVal value As String)
            tiporazonsocial = value
        End Set
    End Property

    Private tipofiscal As String
    Public Property prov_tipofiscal() As String
        Get
            Return tipofiscal
        End Get
        Set(ByVal value As String)
            tipofiscal = value
        End Set
    End Property

    Private curp As String
    Public Property prov_curp() As String
        Get
            Return curp
        End Get
        Set(ByVal value As String)
            curp = value
        End Set
    End Property

    Private colonia As String

    Public Property prov_colonia() As String
        Get
            Return colonia
        End Get
        Set(ByVal value As String)
            colonia = value
        End Set
    End Property

    Private ciudad As String
    Public Property prov_ciudad() As String
        Get
            Return ciudad
        End Get
        Set(ByVal value As String)
            ciudad = value
        End Set
    End Property

    Private calle As String
    Public Property prov_calle() As String
        Get
            Return calle
        End Get
        Set(ByVal value As String)
            calle = value
        End Set
    End Property

    Private numeroexterior As String
    Public Property prov_numeroexterior() As String
        Get
            Return numeroexterior
        End Get
        Set(ByVal value As String)
            numeroexterior = value
        End Set
    End Property

    Private numerointerior As String
    Public Property prov_numerointerior() As String
        Get
            Return numerointerior
        End Get
        Set(ByVal value As String)
            numerointerior = value
        End Set
    End Property

    Private codigopostal As String
    Public Property prov_codigopostal() As String
        Get
            Return codigopostal
        End Get
        Set(ByVal value As String)
            codigopostal = value
        End Set
    End Property

    Private estado As String
    Public Property prov_estado() As String
        Get
            Return estado
        End Get
        Set(ByVal value As String)
            estado = value
        End Set
    End Property

    Private activoordenesdecompra As String
    Public Property prov_activoordenesdecompra() As String
        Get
            Return activoordenesdecompra
        End Get
        Set(ByVal value As String)
            activoordenesdecompra = value
        End Set
    End Property


    Private activopagos As String
    Public Property prov_activopagos() As String
        Get
            Return activopagos
        End Get
        Set(ByVal value As String)
            activopagos = value
        End Set
    End Property


    Private activocompras As String
    Public Property prov_activocompras() As String
        Get
            Return activocompras
        End Get
        Set(ByVal value As String)
            activocompras = value
        End Set
    End Property


    Private nombre As String
    Public Property prov_nombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private apellidopaterno As String
    Public Property prov_apellidopaterno() As String
        Get
            Return apellidopaterno
        End Get
        Set(ByVal value As String)
            apellidopaterno = value
        End Set
    End Property

    Private apellidomaterno As String
    Public Property prov_apellidomaterno() As String
        Get
            Return apellidomaterno
        End Get
        Set(ByVal value As String)
            apellidomaterno = value
        End Set
    End Property

    Private proveedorid As Integer
    Public Property dage_proveedorid() As Integer
        Get
            Return proveedorid
        End Get
        Set(ByVal value As Integer)
            proveedorid = value
        End Set
    End Property

    Private rfcsicy As Integer
    Public Property prov_rfcsicy() As Integer
        Get
            Return rfcsicy
        End Get
        Set(ByVal value As Integer)
            rfcsicy = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property prov_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property prov_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechacreacion As DateTime
    Public Property prov_fechacreacion() As DateTime
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As DateTime)
            fechacreacion = value
        End Set
    End Property

    Private fechamodificacion As DateTime
    Public Property prov_fechamodificacion() As DateTime
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As DateTime)
            fechamodificacion = value
        End Set
    End Property

    Private razonsocial As String
    Public Property prov_razonsocial() As String
        Get
            Return razonsocial
        End Get
        Set(ByVal value As String)
            razonsocial = value
        End Set
    End Property

    Private pais As String
    Public Property prov_pais() As String
        Get
            Return pais
        End Get
        Set(ByVal value As String)
            pais = value
        End Set
    End Property

    Private datosrfcid As Integer
    Public Property prov_datosrfcid() As Integer
        Get
            Return datosrfcid
        End Get
        Set(ByVal value As Integer)
            datosrfcid = value
        End Set
    End Property

    Private personaidproveedor As Integer
    Public Property prov_personaidproveedor() As Integer
        Get
            Return personaidproveedor
        End Get
        Set(ByVal value As Integer)
            personaidproveedor = value
        End Set
    End Property

    Private clasificacionpersonaid As Integer
    Public Property prov_clasificacionpersonaid() As Integer
        Get
            Return clasificacionpersonaid
        End Get
        Set(ByVal value As Integer)
            clasificacionpersonaid = value
        End Set
    End Property

    Private activo As Integer
    Public Property prov_activo() As Integer
        Get
            Return activo
        End Get
        Set(ByVal value As Integer)
            activo = value
        End Set
    End Property

    Private ClasificacionGiro As Integer = -1
    Public Property prov_clasificaciongiroid() As Integer
        Get
            Return ClasificacionGiro
        End Get
        Set(ByVal value As Integer)
            ClasificacionGiro = value
        End Set
    End Property


    Private PagoParcialidades As Integer
    Public Property prov_pagoParcialidades() As Integer
        Get
            Return PagoParcialidades
        End Get
        Set(ByVal value As Integer)
            PagoParcialidades = value
        End Set
    End Property

End Class
