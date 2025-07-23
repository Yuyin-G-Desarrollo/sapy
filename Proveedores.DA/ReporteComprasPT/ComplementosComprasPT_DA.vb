Imports System.Data.SqlClient
Imports Entidades

Public Class ComplementosComprasPT_DA
    Public Function obtenerRutasSICY_Emisor(ByVal rfcEmisor As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter With {
            .ParameterName = "@RFC_Emisor",
            .Value = rfcEmisor
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_RutasFacturaComplemento", listaParametros)
    End Function

    Public Function InsertarDocumentoFactura(ByVal strXML As String, ByVal entXML As Entidades.FacturaComplementoXML, ByVal rutaXML As String, ByVal rutaPDF As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter With {
            .ParameterName = "@XMLCeldas",
            .Value = strXML
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Version",
            .Value = entXML.PVersion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Serie",
            .Value = entXML.PSerie
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Folio",
            .Value = entXML.PFolio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Fecha",
            .Value = entXML.PFechaXML
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Sello",
            .Value = entXML.PSelloXML
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FormaPago",
            .Value = entXML.PFormaPago
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@SubTotal",
            .Value = entXML.PSubtotalXML
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Total",
            .Value = entXML.PTotal
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@TipoMoneda",
            .Value = entXML.PTipoMoneda
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@TipoDeComprobante",
            .Value = entXML.PTipoComprobante
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@MetodoDePago",
            .Value = entXML.PMetodoPago
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@LugarExpedicion",
            .Value = entXML.PLugarExpedicion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@UUID",
            .Value = entXML.PUUID
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@EmisorRFC",
            .Value = entXML.PRFCEmisor
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@ReceptorRFC",
            .Value = entXML.PRFCReceptor
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@UsoCfdiId",
            .Value = entXML.PUsoCFDI
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@ImporteImpuesto",
            .Value = entXML.PImporteImpuesto
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@FechaTimbrado",
            .Value = entXML.PFechaTimbrado
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@VersionSat",
            .Value = entXML.PVersionSAT
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@RFCProvCertif",
            .Value = entXML.PRFCProvCert
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@NoCertificadoSAT",
            .Value = entXML.PNoCertSAT
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@SelloSAT",
            .Value = entXML.PSelloSAT
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@RutaXml",
            .Value = rutaXML
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@RutaPdf",
            .Value = rutaPDF
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Usuario",
            .Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_InsertarFacturaComplemento", listaParametros)
    End Function

    Public Function ObtenerInfoCXPSaldo(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "IdDocumento",
            .Value = idDocumento
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ObtenerInfoCXPSaldo", listaParametros)
    End Function

    Public Function validarExisteFacturaComplemento(ByVal rfcEmisor As String, ByVal serieDocumento As String, ByVal folioDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter With {
            .ParameterName = "@RFC_Emisor",
            .Value = rfcEmisor
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Serie",
            .Value = serieDocumento
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@Folio",
            .Value = folioDocumento
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ValidaFacturaComplementoExiste", listaParametros)
    End Function

    Public Function insertarRegistroComplemento(ByVal documentoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter With {
            .ParameterName = "@documentoId",
            .Value = documentoId
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_TarjetaAlmacen_InsertarRegistroCompras]", listaParametros)
    End Function

End Class
