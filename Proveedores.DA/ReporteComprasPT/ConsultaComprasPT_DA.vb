Imports System.Data.SqlClient
Imports Entidades
Public Class ConsultaComprasPT_DA
    Public Function ObtieneCompradeProductoIngresado(pFechaInicio As Date, pFechaFin As Date, pIdNaves As String, pIdMarcas As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NavesIdSay"
        parametro.Value = pIdNaves
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MarcasId"
        parametro.Value = pIdMarcas
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Proveedor].[SP_Consulta_CompraDeProductoIngresado_ConDatosFacturacion]", listaparametros)

    End Function

    Public Function ObtienePreciosNavesPropias() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Return operacion.EjecutaConsulta("[Proveedor].[SP_Consulta_PreciosNavesPropias]")
    End Function

    Public Function ObtieneCompradeProductoIngresadoCopel(rowsGrdPedidos As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Pedidos"
        parametro.Value = rowsGrdPedidos
        listaparametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Proveedor].[SP_Proveedores_CompraDeProducto_Coppel]", listaparametros)
    End Function

    Public Function listadoParametroMarcas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        'Dim listaparametros As New List(Of SqlParameter)
        'Dim parametro As New SqlParameter

        'parametro.ParameterName = "MarcaActivo"
        'parametro.Value = 1
        'listaparametros.Add(parametro)

        Return objPersistencia.EjecutaConsulta("[Proveedor].[SP_Proveedores_ConsultaMarcas]")

    End Function

    Public Function listadoParametroNaves(tipo_Nave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "Maquila"
        parametro.Value = tipo_Nave
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_Proveedores_ConsultaNavesFiltro]", listaparametros)

    End Function

    Public Function ObtenerNavesReceptoras() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Return operacion.EjecutaConsulta("Proveedor.SP_ComprasPT_ObtenerNavesReceptoras")
    End Function

    Public Function ObtenerResumenFacturacion(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal navesId As String, ByVal marcasId As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter With {
            .ParameterName = "FechaInicio",
            .Value = fechaInicio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "FechaFin",
            .Value = fechaFin
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "NavesIdSay",
            .Value = navesId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "MarcasId",
            .Value = marcasId
        }
        listaParametros.Add(parametro)
        Return operacion.EjecutarConsultaSP("Proveedor.SP_Consulta_CompraDeProductoIngresado_Resumen", listaParametros)
    End Function

    Public Function InsertarDocumentoFactura(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal navesId As String, ByVal marcasId As String, ByVal pruebas As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter With {
            .ParameterName = "FechaInicio",
            .Value = fechaInicio
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "FechaFin",
            .Value = fechaFin
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "NavesIdSay",
            .Value = navesId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "MarcasId",
            .Value = marcasId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "usuarioCreoId",
            .Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "pruebas",
            .Value = pruebas
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_InsertarFacturaPIDocumento", listaParametros)
    End Function

    Public Function InsertarDocumentoFacturaDetalle(ByVal facturaPTIngresadoDetalle As FacturaPTIngresadoDetalle) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter With {
            .ParameterName = "documentoId",
            .Value = facturaPTIngresadoDetalle.PDocumentoId
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "claveProdServ",
            .Value = facturaPTIngresadoDetalle.PClaveProdServ
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "noIdentificacion",
            .Value = facturaPTIngresadoDetalle.PNoIdentificacion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "cantidad",
            .Value = facturaPTIngresadoDetalle.PCantidad
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "descripcion",
            .Value = facturaPTIngresadoDetalle.PDescripcion
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "valorUnitario",
            .Value = facturaPTIngresadoDetalle.PValorUnitario
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "importe",
            .Value = facturaPTIngresadoDetalle.PImporte
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "descuento",
            .Value = facturaPTIngresadoDetalle.PDescuento
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_InsertarFacturaPIDocumentoDetalle", listaParametros)
    End Function

    Public Function GeneraInformacionTimbrar(ByVal documentoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "IdDocumento",
            .Value = documentoId
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Proveedor.SP_ComprasPT_GeneraInformacionTimbrar", listaParametros)
    End Function

    Public Function ListadoParametroArticulos() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutaConsulta("[Proveedor].[SP_ComprasPT_ObtenerListaArticulos]")
    End Function
End Class
