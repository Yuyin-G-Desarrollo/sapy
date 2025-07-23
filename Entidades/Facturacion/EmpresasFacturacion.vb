Public Class EmpresasFacturacion
    Private empresaId As Int32
    Public Property EId() As Int32
        Get
            Return empresaId
        End Get
        Set(ByVal value As Int32)
            empresaId = value
        End Set
    End Property

    Private nombre As String
    Public Property ENombre() As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Private rfc As String
    Public Property ERfc() As String
        Get
            Return rfc
        End Get
        Set(value As String)
            rfc = value
        End Set
    End Property

    Private activo As Boolean
    Public Property EActivo() As Boolean
        Get
            Return activo
        End Get
        Set(value As Boolean)
            activo = value
        End Set
    End Property

    Private arrendamiento As Boolean
    Public Property EArrendamiento() As Boolean
        Get
            Return arrendamiento
        End Get
        Set(ByVal value As Boolean)
            arrendamiento = value
        End Set
    End Property

    Private usuCreoId As Int32
    Public Property EUsuCreoId() As Int32
        Get
            Return usuCreoId
        End Get
        Set(ByVal value As Int32)
            usuCreoId = value
        End Set
    End Property

    Private usuModificoId As Int32
    Public Property EUsuModificoId() As Int32
        Get
            Return usuModificoId
        End Get
        Set(ByVal value As Int32)
            usuModificoId = value
        End Set
    End Property

    Private fechaCreacion As Date
    Public Property EFechaCreacion() As Date
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As Date)
            fechaCreacion = value
        End Set
    End Property

    Private fechaModificacion As Date
    Public Property EFechaModificacion() As Date
        Get
            Return fechaModificacion
        End Get
        Set(ByVal value As Date)
            fechaModificacion = value
        End Set
    End Property

    Private tasaIva As Int32
    Public Property ETasaIva() As Int32
        Get
            Return tasaIva
        End Get
        Set(ByVal value As Int32)
            tasaIva = value
        End Set
    End Property

    Private tasaivaencabezado As Int32
    Public Property ETasaivaencabezado() As Int32
        Get
            Return tasaivaencabezado
        End Get
        Set(ByVal value As Int32)
            tasaivaencabezado = value
        End Set
    End Property

    Private razonsocial As String
    Public Property ERazonsocial() As String
        Get
            Return razonsocial
        End Get
        Set(value As String)
            razonsocial = value
        End Set
    End Property

    Private calle As String
    Public Property ECalle() As String
        Get
            Return calle
        End Get
        Set(value As String)
            calle = value
        End Set
    End Property

    Private colonia As String
    Public Property EColonia() As String
        Get
            Return colonia
        End Get
        Set(value As String)
            colonia = value
        End Set
    End Property

    Private numero As String
    Public Property ENumero() As String
        Get
            Return numero
        End Get
        Set(ByVal value As String)
            numero = value
        End Set
    End Property

    Private cp As String
    Public Property ECp() As String
        Get
            Return cp
        End Get
        Set(ByVal value As String)
            cp = value
        End Set
    End Property

    Private estadoid As Int32
    Public Property EEstadoid() As Int32
        Get
            Return estadoid
        End Get
        Set(ByVal value As Int32)
            estadoid = value
        End Set
    End Property

    Private ciudadid As Int32
    Public Property ECiudadid() As Int32
        Get
            Return ciudadid
        End Get
        Set(ByVal value As Int32)
            ciudadid = value
        End Set
    End Property

    Private curp As String
    Public Property ECurp() As String
        Get
            Return curp
        End Get
        Set(value As String)
            curp = value
        End Set
    End Property

    Private rutacertificado As String
    Public Property ERutacertificado() As String
        Get
            Return rutacertificado
        End Get
        Set(value As String)
            rutacertificado = value
        End Set
    End Property

    Private rutakey As String
    Public Property ERutakey() As String
        Get
            Return rutakey
        End Get
        Set(value As String)
            rutakey = value
        End Set
    End Property

    Private numerocertificado As String
    Public Property ENumerocertificado() As String
        Get
            Return numerocertificado
        End Get
        Set(ByVal value As String)
            numerocertificado = value
        End Set
    End Property

    Private webservice As String
    Public Property EWebservice() As String
        Get
            Return webservice
        End Get
        Set(value As String)
            webservice = value
        End Set
    End Property

    Private usuariows As String
    Public Property EUsuariows() As String
        Get
            Return usuariows
        End Get
        Set(value As String)
            usuariows = value
        End Set
    End Property

    Private contrasenaws As String
    Public Property EContrasenaws() As String
        Get
            Return contrasenaws
        End Get
        Set(value As String)
            contrasenaws = value
        End Set
    End Property

    Private identidificadorpax As String
    Public Property EIdentificadorPax() As String
        Get
            Return identidificadorpax
        End Get
        Set(ByVal value As String)
            identidificadorpax = value
        End Set
    End Property

    Private contrasenacertificado As String
    Public Property EContrasenacertificado() As String
        Get
            Return contrasenacertificado
        End Get
        Set(value As String)
            contrasenacertificado = value
        End Set
    End Property

    Private certificadovigenciainicio As Date
    Public Property ECertificadovigenciainicio() As Date
        Get
            Return certificadovigenciainicio
        End Get
        Set(ByVal value As Date)
            certificadovigenciainicio = value
        End Set
    End Property

    Private certificadovigenciafin As Date
    Public Property ECertificadovigenciafin() As Date
        Get
            Return certificadovigenciafin
        End Get
        Set(ByVal value As Date)
            certificadovigenciafin = value
        End Set
    End Property

    Private foliosinicio As Int32
    Public Property EFoliosinicio() As Int32
        Get
            Return foliosinicio
        End Get
        Set(ByVal value As Int32)
            foliosinicio = value
        End Set
    End Property

    Private foliosfin As Int32
    Public Property EFoliosFin() As Int32
        Get
            Return foliosfin
        End Get
        Set(ByVal value As Int32)
            foliosfin = value
        End Set
    End Property

    Private folioactual As Int32
    Public Property EFolioactual() As Int32
        Get
            Return folioactual
        End Get
        Set(ByVal value As Int32)
            folioactual = value
        End Set
    End Property

    Private rutapdfcalzado As String
    Public Property ERutapdfcalzado() As String
        Get
            Return rutapdfcalzado
        End Get
        Set(value As String)
            rutapdfcalzado = value
        End Set
    End Property

    Private rutaxmlcalzado As String
    Public Property ERutaxmlcalzado() As String
        Get
            Return rutaxmlcalzado
        End Get
        Set(value As String)
            rutaxmlcalzado = value
        End Set
    End Property

    Private serie As String
    Public Property ESerie() As String
        Get
            Return serie
        End Get
        Set(value As String)
            serie = value
        End Set
    End Property

    Private folioactualcalzado As Int32
    Public Property EFolioactualcalzado() As Int32
        Get
            Return folioactualcalzado
        End Get
        Set(ByVal value As Int32)
            folioactualcalzado = value
        End Set
    End Property

    Private renglones As Int32
    Public Property ERenglones() As Int32
        Get
            Return renglones
        End Get
        Set(ByVal value As Int32)
            renglones = value
        End Set
    End Property

    Private reportecalzadoid As Int32
    Public Property EReportecalzadoid() As Int32
        Get
            Return reportecalzadoid
        End Get
        Set(ByVal value As Int32)
            reportecalzadoid = value
        End Set
    End Property

    Private rutapdfproductos As String
    Public Property ERutapdfproductos() As String
        Get
            Return rutapdfproductos
        End Get
        Set(value As String)
            rutapdfproductos = value
        End Set
    End Property

    Private rutaxmlproductos As String
    Public Property ERutaxmlproductos() As String
        Get
            Return rutaxmlproductos
        End Get
        Set(value As String)
            rutaxmlproductos = value
        End Set
    End Property

    Private reporteproductosid As Int32
    Public Property EReporteproductosid() As Int32
        Get
            Return reporteproductosid
        End Get
        Set(ByVal value As Int32)
            reporteproductosid = value
        End Set
    End Property

    Private rutalogo As String
    Public Property ERutalogo() As String
        Get
            Return rutalogo
        End Get
        Set(value As String)
            rutalogo = value
        End Set
    End Property

    Private regimen As String
    Public Property ERegimen() As String
        Get
            Return regimen
        End Get
        Set(value As String)
            regimen = value
        End Set
    End Property

    Private claveRegimen As String
    Public Property EClaveRegimen() As String
        Get
            Return claveRegimen
        End Get
        Set(ByVal value As String)
            claveRegimen = value
        End Set
    End Property

    Private cadenacertificado As String
    Public Property ECadenacertificado() As String
        Get
            Return cadenacertificado
        End Get
        Set(value As String)
            cadenacertificado = value
        End Set
    End Property

    Private reportecanccalzadoid As String
    Public Property EReportecanccalzadoid() As String
        Get
            Return reportecanccalzadoid
        End Get
        Set(value As String)
            reportecanccalzadoid = value
        End Set
    End Property

    Private reportecancproductosid As String
    Public Property EReportecancproductosid() As String
        Get
            Return reportecancproductosid
        End Get
        Set(value As String)
            reportecancproductosid = value
        End Set
    End Property

    Private ciudad As String
    Public Property ECiudad() As String
        Get
            Return ciudad
        End Get
        Set(ByVal value As String)
            ciudad = value
        End Set
    End Property

    Private estado As String
    Public Property EEstado() As String
        Get
            Return estado
        End Get
        Set(ByVal value As String)
            estado = value
        End Set
    End Property

    Private Pais As String
    Public Property EPais() As String
        Get
            Return Pais
        End Get
        Set(ByVal value As String)
            Pais = value
        End Set
    End Property

End Class