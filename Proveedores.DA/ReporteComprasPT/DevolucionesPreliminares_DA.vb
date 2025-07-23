Imports System.Data.SqlClient
Public Class DevolucionesPreliminares_DA
    Public Function obtenerFacturasConSaldo(ByVal emisorSicyId As Integer, ByVal receptorSicyId As Integer) As DataTable
        Dim opreacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@EmisorSicyId"
        parametro.Value = emisorSicyId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ReceptorSicyId"
        parametro.Value = receptorSicyId
        listaParametros.Add(parametro)

        Return opreacion.EjecutarConsultaSP("[Proveedores].[SP_ComprasPT_obtenerFacturasSaldo]", listaParametros)
    End Function

    Public Function insertarDevolucionPreliminar(ByVal xmlDetalles As String, ByVal facturaCompraId As Integer, ByVal facturaAplicarId As Integer, ByVal emisorId As Integer, ByVal receptorId As Integer) As DataTable
        Dim opreacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@XMLDetalles"
        parametro.Value = xmlDetalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FacturaCompraId"
        parametro.Value = facturaCompraId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FacturaAplicarId"
        parametro.Value = facturaAplicarId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmisorId"
        parametro.Value = emisorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ReceptorId"
        parametro.Value = receptorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return opreacion.EjecutarConsultaSP("[Proveedor].[SP_ComprasPT_InsertarDevolucionPreliminar]", listaParametros)
    End Function

    Public Function ObtenerEstatusDevolucion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Proveedor.SP_ConsultarEstatusDevolucionPTI")
    End Function
    
    Public Function consultarDevolucionesPT(ByVal porFechaDevolucion As Boolean, ByVal porFechaFactura As Boolean, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal emisorIds As String, ByVal receptorIds As String, ByVal estatusIds As String) As DataTable
        Dim opreacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@PorFechaDevolucion"
        parametro.Value = porFechaDevolucion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PorFechaFacturacion"
        parametro.Value = porFechaFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmisorIds"
        parametro.Value = emisorIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ReceptorIds"
        parametro.Value = receptorIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EstatusIds"
        parametro.Value = estatusIds
        listaParametros.Add(parametro)

        Return opreacion.EjecutarConsultaSP("[Proveedor].[SP_ComprasPT_ConsultaDevoluciones]", listaParametros)
    End Function

    Public Function obtenerDetalleDevolucion(ByVal devolucionId As Integer) As DataTable
        Dim opreacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@DevolucionId"
        parametro.Value = devolucionId
        listaParametros.Add(parametro)

        Return opreacion.EjecutarConsultaSP("[Proveedor].[SP_ComprasPT_ConsultaDetalleDevolucion]", listaParametros)
    End Function

    Public Function validarExisteDevolucion(ByVal rfcEmisor As String, ByVal serieDocumento As String, ByVal folioDocumento As Integer, ByVal UUID As String) As DataTable
        Dim opreacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@RFC_Emisor"
        parametro.Value = rfcEmisor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Serie"
        parametro.Value = serieDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Folio"
        parametro.Value = folioDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UUID"
        parametro.Value = UUID
        listaParametros.Add(parametro)

        Return opreacion.EjecutarConsultaSP("[Proveedor].[SP_ComprasPT_ValidaDevolucionExiste]", listaParametros)
    End Function

    Public Function aplicarDevolucion(ByVal devolucionId As Integer, ByVal devComprasXML As Entidades.DevComprasPT_XML, ByVal rutaXML As String, ByVal rutaPDF As String) As DataTable
        Dim opreacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@DevolucionId"
        parametro.Value = devolucionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Serie"
        parametro.Value = devComprasXML.PSerie
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Folio"
        parametro.Value = devComprasXML.PFolio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaTimbrado"
        parametro.Value = devComprasXML.PFechaTimbrado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoMoneda"
        parametro.Value = devComprasXML.PTipoMoneda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UUID"
        parametro.Value = devComprasXML.PUUID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RutaXML"
        parametro.Value = rutaXML
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RutaPDF"
        parametro.Value = rutaPDF
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return opreacion.EjecutarConsultaSP("[Proveedor].[SP_ComprasPT_AplicarDevolucionPreliminar]", listaParametros)
    End Function

    Public Function obtenerRutasSICY_Emisor(ByVal emisorId As Integer) As DataTable
        Dim opreacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@EmisorId"
        parametro.Value = emisorId
        listaParametros.Add(parametro)

        Return opreacion.EjecutarConsultaSP("[Proveedor].[SP_ComprasPT_RutasNCDevolucion]", listaParametros)
    End Function

    Public Function insertarRegistroDevolucionCompras(ByVal documentoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter With {
            .ParameterName = "@documentoId",
            .Value = documentoId
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_TarjetaAlmacen_InsertarRegistro_NC_ComprasPI]", listaParametros)
    End Function

    Public Function obtenerLauyoutDevolucionesPT(ByVal porFechaDevolucion As Boolean, ByVal porFechaFactura As Boolean, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal emisorIds As String, ByVal receptorIds As String) As DataTable
        Dim opreacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@PorFechaDevolucion"
        parametro.Value = porFechaDevolucion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PorFechaFacturacion"
        parametro.Value = porFechaFactura
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmisorIds"
        parametro.Value = emisorIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ReceptorIds"
        parametro.Value = receptorIds
        listaParametros.Add(parametro)

        Return opreacion.EjecutarConsultaSP("[Proveedor].[SP_ComprasPT_ObtenerLayoutNCDevoluciones]", listaParametros)
    End Function

End Class
