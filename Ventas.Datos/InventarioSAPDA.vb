Imports System.Data.SqlClient

Public Class InventarioSAPDA
    Public Sub RegistrarInventarioSAP(dtmostrardatos As DataTable)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@MyExcel"
        ParametroParaLista.Value = dtmostrardatos
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("work.Ventas.SP_RegistrarInventarioSAP", ListaParametros)

    End Sub
    Public Sub RegistrarInventarioClientesSAP(dtDatosMostrarImportadosClientesSAP As DataTable)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@MyExcel"
        ParametroParaLista.Value = dtDatosMostrarImportadosClientesSAP
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("[Work].[Ventas].[SP_RegistrarInventarioClientesSAP]", ListaParametros)
    End Sub
    Public Function ObtenerArticulosFaltantesSap(razonSocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date, ByVal facturasIds As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@razonSocial"
        ParametroParaLista.Value = razonSocial
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@fechaFacturasInicio"
        ParametroParaLista.Value = fechaFacturasInicio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@fechaFacturasFin"
        ParametroParaLista.Value = fechaFacturasFin
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@facturasIds"
        ParametroParaLista.Value = facturasIds
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Ventas.SP_ArticulosFaltantesSAP", ListaParametros)
    End Function


    Public Function obtenerCantidadesClientesFaltantesSAP(razonSocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@razonSocial"
        ParametroParaLista.Value = razonSocial
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@fechaInicio"
        ParametroParaLista.Value = fechaFacturasInicio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@fechaFinal"
        ParametroParaLista.Value = fechaFacturasFin
        ListaParametros.Add(ParametroParaLista)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ClientesInventarioFaltantesSAP]", ListaParametros)
        Return dtResultadoConsulta
    End Function
    Public Function ObtenerCantidadesSap(razonsocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date, ByVal facturasIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@razonSocial"
        ParametroParaLista.Value = razonsocial
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@fechaFacturasInicio"
        ParametroParaLista.Value = fechaFacturasInicio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@fechaFacturasFin"
        ParametroParaLista.Value = fechaFacturasFin
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@facturasIds"
        ParametroParaLista.Value = facturasIds
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Ventas.SP_CantidadesRequeridasCompraSAP", ListaParametros)
    End Function

    Public Sub LimpiarTablaTemporal()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaConsulta("Ventas.SP_LimpiarTablaTemporalInventarioSAP")
    End Sub
    Public Sub LimpiarTablaTemporalClientesSAP()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        operacion.EjecutaConsulta("[Ventas].[SP_LimpiarTablaTemporalClientesSAP]")
    End Sub

    Public Function ObtenerArticulosFaltantesSapEntradas(razonSocial As Int16, fechaFacturasInicio As Date, fechaFacturasFin As Date)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@RazonSocial"
        ParametroParaLista.Value = razonSocial
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@FechaInicio"
        ParametroParaLista.Value = fechaFacturasInicio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@FechaFin"
        ParametroParaLista.Value = fechaFacturasFin
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_Consulta_CompraDeProductoIngresado_ArticulosFaltantesSAP", ListaParametros)
    End Function
    Public Function ObtenerDocumentosDetallesArticulosFaltantesSAP(ByVal documentosID As String, ByVal FechaInicioSAP As Date, ByVal FechaFinalSAP As Date, ByVal razonSocial As Integer, ByVal facturasIds As String) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@idArticulos"
            parametro.Value = documentosID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = FechaInicioSAP
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFinal"
            parametro.Value = FechaFinalSAP
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@razonSocial"
            parametro.Value = razonSocial
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@facturasIds"
            parametro.Value = facturasIds
            listaParametros.Add(parametro)

            Return ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_ComplementosCompraPT_FacturacionCalzadoDetalles]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarResumenComplementosFacturarSAP(ByVal razonSocialId As String, ByVal FechaInicioSAP As Date, ByVal FechaFinalSAP As Date, ByVal facturasIds As String)
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@razonSocial"
            parametro.Value = razonSocialId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = FechaInicioSAP
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFinal"
            parametro.Value = FechaFinalSAP
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@facturasIds"
            parametro.Value = facturasIds
            listaParametros.Add(parametro)

            Return ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_Consulta_Complementos_ComprasIngresadosPT_SAP_Resumen]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertarFacturasComplementosSAP_PT(ByVal fechaInicio As Date, ByVal fechaFinal As Date, ByVal razonsocialId As Integer, ByVal pruebas As Boolean, ByVal facturasIds As String) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFinal"
            parametro.Value = fechaFinal
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@razonSocialId"
            parametro.Value = razonsocialId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioCreoId"
            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pruebas"
            parametro.Value = pruebas
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@facturasIds"
            parametro.Value = facturasIds
            listaParametros.Add(parametro)

            Return ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_ComplementosComprasPT_SAP_InsertarFactura]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GeneraInformacionComplementosPT_SAP_Timbrar(ByVal documentoId As Integer) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            Dim ParametroParaLista As New SqlParameter
            ParametroParaLista.ParameterName = "@idDocumento"
            ParametroParaLista.Value = documentoId
            listaParametros.Add(ParametroParaLista)

            Return ObjPersistencia.EjecutarConsultaSP("[Ventas].[SP_ComplementosCompras_SAP_PT_GeneraInformacionTimbrar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizarInformacionFacturasComplementosSAP_PT(ByVal idDocumento As Integer, ByVal sello As String,
                                                     ByVal uuid As String, ByVal fechaTimbrado As String,
                                                     ByVal versionSat As String, ByVal rfcProvCertif As String,
                                                     ByVal noCertificadoSAT As String, ByVal selloSAT As String,
                                                     ByVal cadenaOriginal As String, ByVal cadenaOriginalComplemento As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "IdDocumento",
            .Value = idDocumento
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Sello",
            .Value = sello
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "Uuid",
            .Value = uuid
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "UsuarioTimbroId",
            .Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "FechaTimbrado",
            .Value = fechaTimbrado
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "VersionSat",
            .Value = versionSat
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "RfcProvCertif",
            .Value = rfcProvCertif
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "NoCertificadoSAT",
            .Value = noCertificadoSAT
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "SelloSAT",
            .Value = selloSAT
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "CadenaOriginal",
            .Value = cadenaOriginal
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "CadenaOriginalComplemento",
            .Value = cadenaOriginalComplemento
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ActualizarInfoFacturaPIDocumento", listaParametros)
    End Function

    Public Function ObtenerIdComprobanteCFD(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "IdDocumento",
            .Value = idDocumento
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_ObtenerIdComprobanteCFD", listaParametros)
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

    Public Function InsertarCXPSaldo(ByVal tipoDoc As Integer, ByVal idProveedor As Integer, ByVal numDoc As String,
                                     ByVal fechaDoc As Date, ByVal fechaVencimiento As Date, ByVal semanaPago As Integer,
                                     ByVal semanaPagada As Integer, ByVal subTotal As Double, ByVal iva As Double,
                                     ByVal total As Double, ByVal totalDoc As Double, ByVal moneda As Integer,
                                     ByVal nave As Integer, ByVal añoSemPago As Integer, ByVal rfcContribuyente As String,
                                     ByVal rfcProveedor As String, ByVal giro As String, ByVal idcomprobantesicy As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "tipoDoc",
            .Value = tipoDoc
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "idProveedor",
            .Value = idProveedor
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "numDoc",
            .Value = numDoc
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "fechaDoc",
            .Value = fechaDoc
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "fechaVencimiento",
            .Value = fechaVencimiento
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "semanaPago",
            .Value = semanaPago
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "semanaPagada",
            .Value = semanaPagada
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "subTotal",
            .Value = subTotal
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "iva",
            .Value = iva
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "total",
            .Value = total
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "totalDoc",
            .Value = totalDoc
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "moneda",
            .Value = moneda
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "nave",
            .Value = nave
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "añoSemPago",
            .Value = añoSemPago
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "usuario",
            .Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "rfcContribuyente",
            .Value = rfcContribuyente
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "rfcProveedor",
            .Value = rfcProveedor
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "giro",
            .Value = giro
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "idcomprobantesicy",
            .Value = idcomprobantesicy
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedores.SP_InsertcxpSaldoscxpMovimientosOrdenCompra", listaParametros)
    End Function
    Public Function ConsultarArticulosSAPFacturados(ByVal razonSocialId As Integer, ByVal fechaInicio As Date, ByVal fechaFinal As Date) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@razonSocialId", razonSocialId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaInicio", fechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaFinal", fechaFinal)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Ventas].[SP_ComplementosComprasPT_SAP_ConsultaArticulosFacturados]", listaParametros)

    End Function
End Class
