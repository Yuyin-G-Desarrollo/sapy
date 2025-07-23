Imports System.Data.SqlClient

Public Class MovimientosPPCPDA

    Public Function ObtieneArticulosNoAsignadosPorNave(ByVal IdNaveSAY As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveIdSAY", IdNaveSAY)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColeccionesPPCP_ObtenerArticulosNoAsignadosPorNave]", listaParametros)

    End Function

    Public Function InsertarArticulosNave(ByVal pXmlMovimientos As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Xml_Movimientos", pXmlMovimientos)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColeccionesPPCP_InsertarArticuloNave]", listaParametros)

    End Function

    Public Function InsertarArticulosNaveprioridad(ByVal pXmlMovimientos As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Xml_Movimientos", pXmlMovimientos)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColeccionesPPCP_InsertarArticuloNave_prioridades]", listaParametros)

    End Function

    Public Function ObtenerInformacionMovimientoColecciones(ByVal accionForm As String, ByVal ProductoEstiloSeleccionados As String, ByVal Existe As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TipoMovimiento", accionForm)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProductoEstiloSeleccionados", ProductoEstiloSeleccionados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Existe", Existe)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ObtieneInformacion_MovimientoColecciones_Reporte]", listaParametros)
    End Function


    Public Function ObtenerInformacionMovimientoColecciones_ReporteCostos(ByVal accionForm As String, ByVal ProductoEstiloSeleccionados As String, ByVal Existe As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TipoMovimiento", accionForm)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProductoEstiloSeleccionados", ProductoEstiloSeleccionados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Existe", Existe)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ObtieneInformacion_MovimientoColecciones_ReporteCostos]", listaParametros)
    End Function

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("ClaveEnvio", ClaveEnvio)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaDatosCorreosFacturacion", listaParametros)

    End Function

    Public Function ExistEnOtraNave(ByVal ProductoEstiloSeleccionados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@ProductoEstiloSeleccionados", ProductoEstiloSeleccionados)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ExisteEnOtraNave]", listaParametros)

    End Function


    Public Function ActualizarEstatusCorreoExportar(ByVal ProductoEstiloSeleccionados As String, ByVal Existe As Boolean, ByVal NaveDestino As Integer, ByVal accionForm As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProductoEstiloSeleccionados", ProductoEstiloSeleccionados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Existe", Existe)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveDestino", NaveDestino)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoMovimiento", accionForm)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_ActualizarEstatusCorreoExportar]", listaParametros)
    End Function

    Public Function ObtieneArticulosParaTraspaso(ByVal Colecciones As String, ByVal accionForm As String, ByVal NaveOrigen As Integer, ByVal Marca As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter



        parametro = New SqlParameter("@TipoMovimiento", accionForm)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveOrigen", NaveOrigen)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marca", Marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colecciones", Colecciones)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_ObtieneInformacionTraspasoDescontinuar]", listaParametros)
    End Function
    Public Function ObtieneArticulosParaTraspasoTalla(ByVal Colecciones As String, ByVal accionForm As String, ByVal NaveOrigen As Integer, ByVal Marca As String, ByVal Tallas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter



        parametro = New SqlParameter("@TipoMovimiento", accionForm)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveOrigen", NaveOrigen)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marca", Marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colecciones", Colecciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Corrida", Tallas)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_ObtieneInformacionTraspasoDescontinuartallas]", listaParametros)
    End Function



    Public Function TransferirArticulosNave(ByVal IdNuevaNave As Integer, ByVal pXmlCeldas As String, ByVal FechaHasta As Date, ByVal FechaDesde As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveNuevaIdSAY", IdNuevaNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaHasta", FechaHasta)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaDesde", FechaDesde)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_TransferirArticuloNave_prioridad]", listaParametros)

    End Function


    Public Function TransferirArticulosNavePrioridad(ByVal IdNuevaNave As Integer, ByVal pXmlCeldas As String, ByVal FechaHasta As Date, ByVal FechaDesde As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveNuevaIdSAY", IdNuevaNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaHasta", FechaHasta)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaDesde", FechaDesde)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_TransferirArticuloNave_InsertaPrioridad]", listaParametros)

    End Function

    Public Function DesasignarArticulosNave(ByVal pXmlCeldas As String, ByVal Fecha As Date, OpcionesDevolucion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaDesasignacion", Fecha)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@OpcionesDevolucion", OpcionesDevolucion)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_DesasignarArticuloNave]", listaParametros)

    End Function

    Public Function ListadoParametroMovimientoColecciones(ByVal tipo_busqueda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipo_busqueda", tipo_busqueda)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_ListaParametros]", listaParametros)
    End Function

    Public Function ObtieneInformacionMovimientoColecciones(ByVal FNave As String, ByVal FTipoMovimiento As String, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FNave", FNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FTipoMovimiento", FTipoMovimiento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoFecha", TipoFecha)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ObtieneInformacionMovimientos]", listaParametros)
    End Function

    Public Function ObtenerInformacionMovimientosGeneradosColecciones(ByVal TipoMovimiento As String, ProductoEstiloID As Integer, ByVal NaveOrigen As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TipoMovimiento", TipoMovimiento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProductoEstiloID", ProductoEstiloID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveOrigen", NaveOrigen)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ObtenerInformacionMovimientosGenerados]", listaParametros)
    End Function

    Public Function ObtenerInformacionMovimientosGeneradosColecciones_Costos(ByVal TipoMovimiento As String, ProductoEstiloID As Integer, ByVal NaveOrigen As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TipoMovimiento", TipoMovimiento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProductoEstiloID", ProductoEstiloID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveOrigen", NaveOrigen)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ObtenerInformacionMovimientosGenerados_Costos]", listaParametros)
    End Function


    Public Function ConsultarNavesAux() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ConsultaNavesAux]", listaParametros)
    End Function

    Public Function ConsultarNaveColeccion(ByVal NaveOrigen As Integer, ByVal Coleccion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveOrigen", NaveOrigen)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ConsultaNavesColeccion]", listaParametros)


    End Function



    Public Function ObtenerCorreosDestinatario(ByVal NaveOrigenID As Integer, ByVal NaveDestinoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveOrigenID", NaveOrigenID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveDestinoID", NaveDestinoID)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ObtieneCorreosDestinatario]", listaParametros)
    End Function

    Public Function AltaEdicionCorreosMovimientoColecciones(ByVal TipoMovimientoID As Integer, ByVal ObtenerFiltroNave As String,
                                                            ByVal ObtenerFiltroMarca As String, ByVal CorreosMovimientoColecciones As String,
                                                            ByVal UsuarioID As Integer,
                                                            ByVal AltaCorreo As Boolean, ByVal MovimientoID As Integer)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TipoMovimientoID", TipoMovimientoID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ObtenerFiltroNave", ObtenerFiltroNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ObtenerFiltroMarca", ObtenerFiltroMarca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@CorreosMovimientoColecciones", CorreosMovimientoColecciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AltaCorreo", AltaCorreo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@MovimientoID", MovimientoID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_AltaEdicionCorreos]", listaParametros)

    End Function

    Public Function ObtieneInformacionCorreosAsignados(ByVal FNave As String, ByVal FTipoMovimiento As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FNave", FNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FTipoMovimiento", FTipoMovimiento)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_ObtieneListaCorreos]", listaParametros)
    End Function

    Public Function ValidaImagenArticulos(ByVal ProductoEstiloSeleccionados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProductoEstiloSeleccionados", ProductoEstiloSeleccionados)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientoColecciones_ValidaImagenArticulos]", listaParametros)

    End Function

    Public Function ConsultaLogoGerente(ByVal idnave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@idNave", idnave)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaLogoGerente]", listaParametros)

    End Function


    Public Function ObtenerNaveDesarrolla(ByVal productoestiloId As String)
        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@productoEstilo", productoestiloId)
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Programacion].[SP_ConsultaNaveDesarrollaXProductoEstilo]", listaParametros)

    End Function
    Public Function ListadoParametroMovimientoColeccionesfiltro(ByVal tipo As Integer, ByVal tipo_busqueda As Integer, ByVal NaveSayId As Integer, ByVal Marca As String, ByVal Colecciones As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipo", tipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipo_busqueda", tipo_busqueda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveOrigen", NaveSayId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marca", Marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colecciones", Colecciones)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ActualizarCostos_ListaParametros_MovimientosPPCP]", listaParametros)
    End Function


    Public Function ConsultarNavesMarca(ByVal tipo As Integer, ByVal NaveIdSAY As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipo", tipo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@IdNaveSay", NaveIdSAY)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ConsultaNavesmarca_Movimientosppcp]", listaParametros)
    End Function

    Public Function ObtieneArticulosNoAsignadosPorNave(ByVal IdNaveSAY As Integer, ByVal Marca As String, ByVal ColeccionSay As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveIdSAY", IdNaveSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marca", Marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColeccionSay", ColeccionSay)
        listaParametros.Add(parametro)



        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Articulos_CostosNave_Coleccion_MovimientosPPCP]", listaParametros)

    End Function

    Public Function ObtieneArticulostallas(ByVal NaveSayId As Integer, ByVal Colecciones As String, ByVal Marca As String, ByVal tallas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveIdSAY", NaveSayId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColeccionSay", Colecciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marca", Marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@corrida", tallas)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Articulos_MovimientoPPCP_Coleccion_talla]", listaParametros)
    End Function

    Public Function ValidaFamiliaAsignada(ByVal ProductoEstiloSeleccionados As String, ByVal NaveDestinoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProductoEstiloSeleccionados", ProductoEstiloSeleccionados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveDestinoID", NaveDestinoID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Articulos_MovimientoPPCP_ValidaAsignacionFamilia]", listaParametros)
    End Function


    Public Function ObtenerInformacionMovimientosGeneradosColeccionesDiscovery(ByVal TipoMovimiento As String, ProductoEstiloID As String, ByVal NaveOrigen As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TipoMovimiento", TipoMovimiento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProductoEstiloID", ProductoEstiloID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveOrigen", NaveOrigen)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ObtenerInformacionMovimientosGeneradosDiscovery]", listaParametros)
    End Function

    Public Function ObtenerInformacionMovimientosGeneradosColecciones_CostosDiscovery(ByVal TipoMovimiento As String, ProductoEstiloID As String, ByVal NaveOrigen As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@TipoMovimiento", TipoMovimiento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProductoEstiloID", ProductoEstiloID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveOrigen", NaveOrigen)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ObtenerInformacionMovimientosGenerados_CostosDiscovery]", listaParametros)
    End Function

End Class
