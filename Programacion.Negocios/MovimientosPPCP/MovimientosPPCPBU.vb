Imports Programacion.Datos

Public Class MovimientosPPCPBU


    Public Function ObtieneArticulosNoAsignadosPorNave(ByVal IdNaveSAY As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtieneArticulosNoAsignadosPorNave(IdNaveSAY)
        Return dtResultado
    End Function

    Public Function InsertarArticulosNave(ByVal pXmlMovimientos As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.InsertarArticulosNave(pXmlMovimientos)
        Return dtResultado
    End Function

    Public Function InsertarArticulosNaveprioridad(ByVal pXmlMovimientos As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.InsertarArticulosNaveprioridad(pXmlMovimientos)
        Return dtResultado
    End Function

    Public Function ObtenerInformacionMovimientoColecciones(ByVal accionForm As String, ByVal ProductoEstiloSeleccionados As String, ByVal Existe As Boolean) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtenerInformacionMovimientoColecciones(accionForm, ProductoEstiloSeleccionados, Existe)
        Return dtResultado
    End Function

    Public Function ObtenerInformacionMovimientoColecciones_ReporteCostos(ByVal accionForm As String, ByVal ProductoEstiloSeleccionados As String, ByVal Existe As Boolean) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtenerInformacionMovimientoColecciones_ReporteCostos(accionForm, ProductoEstiloSeleccionados, existe)
        Return dtResultado
    End Function

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Return objDA.consultaCorreosEnvioFactura(ClaveEnvio)
    End Function

    Public Function ExistEnOtraNave(ByVal ProductoEstiloSeleccionados As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ExistEnOtraNave(ProductoEstiloSeleccionados)
        Return dtResultado
    End Function

    Public Function ActualizarEstatusCorreoExportar(ByVal ProductoEstiloSeleccionados As String, ByVal Existe As Boolean, ByVal NaveDestino As Integer, ByVal accionForm As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ActualizarEstatusCorreoExportar(ProductoEstiloSeleccionados, Existe, NaveDestino, accionForm)
        Return dtResultado
    End Function

    Public Function ObtieneArticulosParaTraspaso(ByVal Colecciones As String, ByVal accionForm As String, ByVal NaveOrigen As Integer, ByVal Marca As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtieneArticulosParaTraspaso(Colecciones, accionForm, NaveOrigen, Marca)
        Return dtResultado
    End Function

    Public Function ObtieneArticulosParaTraspasoTalla(ByVal Colecciones As String, ByVal accionForm As String, ByVal NaveOrigen As Integer, ByVal Marca As String, ByVal tallas As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtieneArticulosParaTraspasoTalla(Colecciones, accionForm, NaveOrigen, Marca, tallas)
        Return dtResultado
    End Function

    Public Function TransferirArticulosNave(ByVal IdNuevaNave As Integer, ByVal pXmlCeldas As String, ByVal FechaHasta As Date, ByVal FechaDesde As Date) As DataTable
        Dim obj As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = obj.TransferirArticulosNave(IdNuevaNave, pXmlCeldas, FechaHasta, FechaDesde)
        Return dtResultado
    End Function

    Public Function TransferirArticulosNavePrioridad(ByVal IdNuevaNave As Integer, ByVal pXmlCeldas As String, ByVal FechaHasta As Date, ByVal FechaDesde As Date) As DataTable
        Dim obj As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = obj.TransferirArticulosNavePrioridad(IdNuevaNave, pXmlCeldas, FechaHasta, FechaDesde)
        Return dtResultado
    End Function

    Public Function DesasignarArticulosNave(ByVal pXmlCeldas As String, ByVal Fecha As Date, OpcionesDevolucion As Integer) As DataTable
        Dim obj As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = obj.DesasignarArticulosNave(pXmlCeldas, Fecha, OpcionesDevolucion)
        Return dtResultado
    End Function

    Public Function ListadoParametroMovimientoColecciones(ByVal tipo_busqueda As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroMovimientoColecciones(tipo_busqueda)
        Return tabla
    End Function

    Public Function ObtieneInformacionMovimientoColecciones(ByVal FNave As String, ByVal FTipoMovimiento As String, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ObtieneInformacionMovimientoColecciones(FNave, FTipoMovimiento, TipoFecha, FechaInicio, FechaFin)
        Return tabla
    End Function

    Public Function ObtenerInformacionMovimientosGeneradosColecciones(ByVal TipoMovimiento As String, ProductoEstiloID As Integer, ByVal NaveOrigen As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ObtenerInformacionMovimientosGeneradosColecciones(TipoMovimiento, ProductoEstiloID, NaveOrigen)
        Return tabla
    End Function

    Public Function ObtenerInformacionMovimientosGeneradosColecciones_Costos(ByVal TipoMovimiento As String, ProductoEstiloID As Integer, ByVal NaveOrigen As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ObtenerInformacionMovimientosGeneradosColecciones_Costos(TipoMovimiento, ProductoEstiloID, NaveOrigen)
        Return tabla
    End Function

    Public Function ConsultarNavesAux() As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarNavesAux()
        Return tabla

    End Function


    Public Function ObtenerCorreosDestinatario(ByVal NaveOrigenID As Integer, ByVal NaveDestinoID As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ObtenerCorreosDestinatario(NaveOrigenID, NaveDestinoID)
        Return tabla
    End Function

    Public Function AltaEdicionCorreosMovimientoColecciones(ByVal TipoMovimientoID As Integer, ByVal ObtenerFiltroNave As String,
                                                            ByVal ObtenerFiltroMarca As String, ByVal CorreosMovimientoColecciones As String, ByVal UsuarioID As Integer,
                                                            ByVal AltaCorreo As Boolean, ByVal MovimientoID As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.AltaEdicionCorreosMovimientoColecciones(TipoMovimientoID, ObtenerFiltroNave, ObtenerFiltroMarca,
                                                              CorreosMovimientoColecciones, UsuarioID, AltaCorreo, MovimientoID)
        Return tabla

    End Function

    Public Function ObtieneInformacionCorreosAsignados(ByVal FNave As String, ByVal FTipoMovimiento As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ObtieneInformacionCorreosAsignados(FNave, FTipoMovimiento)
        Return tabla
    End Function

    Public Function ValidaImagenArticulos(ByVal ProductoEstiloSeleccionados As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ValidaImagenArticulos(ProductoEstiloSeleccionados)
        Return tabla
    End Function

    Public Function ConsultaLogoGerente(ByVal idnave As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dt As New DataTable
        dt = objDA.ConsultaLogoGerente(idnave)
        Return dt
    End Function

    Public Function ObtenerNaveDesarrolla(ByVal productoestiloId As String) As DataTable
        Dim obj As New MovimientosPPCPDA
        Dim dt As New DataTable
        dt = obj.ObtenerNaveDesarrolla(productoestiloId)
        Return dt
    End Function


    Public Function ListadoParametroMovimientoColeccionesfiltro(ByVal tipo As Integer, ByVal tipo_busqueda As Integer, ByVal NaveSayId As Integer, ByVal Marca As String, ByVal Colecciones As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroMovimientoColeccionesfiltro(tipo, tipo_busqueda, NaveSayId, Marca, Colecciones)
        Return tabla
    End Function

    Public Function ConsultarNavesMarca(ByVal tipo As Integer, ByVal NaveIdSAY As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarNavesMarca(tipo, NaveIdSAY)
        Return tabla
    End Function

    Public Function ObtieneArticulosNoAsignadosPorNave(ByVal IdNaveSAY As Integer, ByVal Marca As String, ByVal ColeccionSay As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim dtResultado As New DataTable
        dtResultado = objDA.ObtieneArticulosNoAsignadosPorNave(IdNaveSAY, Marca, ColeccionSay)
        Return dtResultado
    End Function

    Public Function ObtieneArticulostallas(ByVal NaveSayId As Integer, ByVal Colecciones As String, ByVal Marca As String, ByVal tallas As String) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ObtieneArticulostallas(NaveSayId, Colecciones, Marca, tallas)
        Return tabla
    End Function

    Public Function ValidaFamiliaAsignada(ByVal ProductoEstiloSeleccionados As String, ByVal NaveDestinoID As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ValidaFamiliaAsignada(ProductoEstiloSeleccionados, NaveDestinoID)
        Return tabla
    End Function

    Public Function ObtenerInformacionMovimientosGeneradosColeccionesDiscovery(ByVal TipoMovimiento As String, ProductoEstiloID As String, ByVal NaveOrigen As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ObtenerInformacionMovimientosGeneradosColeccionesDiscovery(TipoMovimiento, ProductoEstiloID, NaveOrigen)
        Return tabla
    End Function


    Public Function ObtenerInformacionMovimientosGeneradosColecciones_CostosDiscovery(ByVal TipoMovimiento As String, ByVal ProductoEstiloID As String, ByVal NaveOrigen As Integer) As DataTable
        Dim objDA As New MovimientosPPCPDA
        Dim tabla As New DataTable
        tabla = objDA.ObtenerInformacionMovimientosGeneradosColecciones_CostosDiscovery(TipoMovimiento, ProductoEstiloID, NaveOrigen)
        Return tabla
    End Function

End Class
