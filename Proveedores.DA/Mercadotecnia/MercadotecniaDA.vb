Imports System.Data.SqlClient

Public Class MercadotecniaDA

    Public Function ObtieneListadoMaterialesPOP(ByVal Estatus As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Estatus", Estatus)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Mercadotecnia].[Mercadotecnia_SP_ListadoMateriales_MaterialesPOP]", listaParametros)

    End Function

    Public Function llenarComboMarcas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT marc_marcaid MarcaID, marc_descripcion Marca  FROM Programacion.Marcas WHERE marc_activo=1 ORDER BY marc_descripcion"
        Return objPersistencia.EjecutaConsulta(cadena)
    End Function

    Public Function llenarComboUnidad() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT umed_unidadmedidaid UnidadID, umed_nombre UnidadNombre  FROM Mercadotecnia.TBL_Mercadotecnia_UnidadesMedidaPOP WHERE umed_activo=1"
        Return objPersistencia.EjecutaConsulta(cadena)
    End Function

    Public Function ActualizarInventarioMaterialPOP(pXmlMateriales As String, ByVal accion As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Xml_Materiales", pXmlMateriales)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Accion", accion)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Mercadotecnia].[Mercadotecnia_SP_Alta_Edicion_MaterialesPOP]", listaParametros)

    End Function

    Public Function llenarComboClientes() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT clie_clienteid ClienteID , clie_nombregenerico Cliente  FROM Cliente.Cliente WHERE clie_activo=1 ORDER BY clie_nombregenerico"
        Return objPersistencia.EjecutaConsulta(cadena)
    End Function

    Public Function llenarComboEstatus() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT eocpop_estatusid EstatusID, eocpop_nombreEstatus Estatus  FROM Mercadotecnia.TBL_Mercadotecnia_Estatus_OrdenCompra WHERE eocpop_activo=1 ORDER BY eocpop_nombreEstatus"
        Return objPersistencia.EjecutaConsulta(cadena)
    End Function


    Public Function llenarGridMaterialesPOP(ByVal Material As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Material", Material)
        listaparametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Mercadotecnia].[SP_ObtieneListaMaterialPOP]", listaparametros)

    End Function


    Public Function GuardarSolicitudesPOP(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Mercadotecnia].[SP_Alta_Edicion_SolicitudOrdenCompra]", listaParametros)

    End Function

    Public Function InsertarEncabezadoOrdenCompra(ByVal ClienteID As Integer, ByVal MotivoSolicitud As String, ByVal EstatusID As Integer, ByVal Observaciones As String, ByVal UsuarioCreoID As Integer, ByVal TotalGrid As Double, ByVal SolicitudOrdenCompra As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim consulta As String = "DECLARE @Mensaje INT "
        consulta += "EXEC [Mercadotecnia].[SP_InsertaEncabezado_OrdenCompra] @Mensaje OUTPUT," + ClienteID.ToString + ",'" + MotivoSolicitud + "'," + EstatusID.ToString + ",'" + Observaciones + "','" + UsuarioCreoID.ToString + "','" + TotalGrid.ToString + "','" + SolicitudOrdenCompra.ToString + "' SELECT @Mensaje"

        InsertarEncabezadoOrdenCompra = objPersistencia.EjecutaConsulta(consulta)
        Return InsertarEncabezadoOrdenCompra
    End Function

    Public Function ObtieneOrdenesCompraEncabezado()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Mercadotecnia].[SP_Listado_OrdenCompraEncabezado]", listaParametros)

    End Function

    Public Function ObtieneOrdenesCompraDetalle(ByVal SolicitudID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@SolicitudID", SolicitudID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Mercadotecnia].[SP_ObtieneDetalles_OrdenCompra]", listaParametros)

    End Function

    Public Function ObtieneEncabezadoReporte(ByVal SolicitudOrdenCompra As Integer, ByVal Accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@SolicitudID", SolicitudOrdenCompra)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Mercadotecnia].[SP_ObtieneReciboSalidaMaterial]", listaParametros)

    End Function

    Public Function ConsultaInventarioParesECommerce()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        'Cambio
        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Consulta_Pares_Totales_ECommerce_Detalles_Pedido_Partida]", New List(Of SqlParameter))

    End Function

    Public Function ConsultaInventario_ECOMMERCE_PorProgramar() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_ECOMMERCE_ConsultaInventario_PorProgramar]", listaParametros)
    End Function

    Public Function ConsultaInventario_ECOMMERCE_EnProceso() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_ECOMMERCE_ConsultaInventario_EnProceso]", listaParametros)
    End Function

    Public Function ConsultaInventario_ECOMMERCE_EnInventario() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_ECOMMERCE_ConsultaInventario_EnInventario]", listaParametros)
    End Function

    Public Function ConsultaArticulosIngresados(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_ECOMMERCE_ConsultaArticulosIngresadosCEDIS]", listaParametros)
    End Function

End Class
