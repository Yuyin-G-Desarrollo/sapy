Imports System.Data.SqlClient

Public Class EnvioRecepcionMuestrasDA
    Public Function ConsultaTablaFiltros(ByVal Tabla As String, ByVal cedisid As Integer, Optional ByVal Param1 As String = Nothing) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        Try
            ParametroParaLista.ParameterName = "@Tabla"
            ParametroParaLista.Value = Tabla
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Param1"
            ParametroParaLista.Value = IIf(IsNothing(Param1), DBNull.Value, Param1)
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@cedisId"
            ParametroParaLista.Value = IIf(IsNothing(Param1), DBNull.Value, cedisid)
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("Programacion.SP_Muestras_EnvioRecepcion_Consultas_TablasDeFiltros", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaDetallada(ByVal PorPorcentaje As Boolean,
                                      ByVal Operador As String,
                                      ByVal Naves As String,
                                      ByVal Piezas As String,
                                      ByVal Clientes As String,
                                      ByVal PedidosM As String,
                                      ByVal Articulos As String,
                                      ByVal Corridas As String,
                                      ByVal Tallas As String,
                                      ByVal FechaEntregaNave As String,
                                      ByVal FechaEntregaCliente As String,
                                      ByVal FechaEnvioDeNave As String,
                                      ByVal FechaRecepcionDeComer As String,
                                      ByVal cedisIdNave As String
                                      ) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        Try
            ParametroParaLista.ParameterName = "@Porcentaje"
            ParametroParaLista.Value = PorPorcentaje
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Operador"
            ParametroParaLista.Value = Operador
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pNaves"
            ParametroParaLista.Value = Naves
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPiezas"
            ParametroParaLista.Value = Piezas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pClientes"
            ParametroParaLista.Value = Clientes
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPedidosM"
            ParametroParaLista.Value = PedidosM
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pArticulos"
            ParametroParaLista.Value = Articulos
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pCorridas"
            ParametroParaLista.Value = Corridas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pTallas"
            ParametroParaLista.Value = Tallas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEntregaNave"
            ParametroParaLista.Value = FechaEntregaNave
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEntregaCliente"
            ParametroParaLista.Value = FechaEntregaCliente
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEnvioDeNave"
            ParametroParaLista.Value = FechaEnvioDeNave
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaRecepcionDeComer"
            ParametroParaLista.Value = FechaRecepcionDeComer
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@cedisId"
            ParametroParaLista.Value = cedisIdNave
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("Programacion.SP_Muestras_EnvioRecepcion_Consultas_Detallada", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaResumenProductos(ByVal Operador As String,
                                  ByVal Naves As String,
                                  ByVal Piezas As String,
                                  ByVal Clientes As String,
                                  ByVal PedidosM As String,
                                  ByVal Articulos As String,
                                  ByVal Corridas As String,
                                  ByVal Tallas As String,
                                  ByVal FechaEntregaNave As String,
                                  ByVal FechaEntregaCliente As String,
                                  ByVal FechaEnvioDeNave As String,
                                  ByVal FechaRecepcionDeComer As String,
                                  ByVal cedisIdNave As String
                                  ) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        Try
            ParametroParaLista.ParameterName = "@Operador"
            ParametroParaLista.Value = Operador
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pNaves"
            ParametroParaLista.Value = Naves
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPiezas"
            ParametroParaLista.Value = Piezas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pClientes"
            ParametroParaLista.Value = Clientes
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPedidosM"
            ParametroParaLista.Value = PedidosM
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pArticulos"
            ParametroParaLista.Value = Articulos
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pCorridas"
            ParametroParaLista.Value = Corridas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pTallas"
            ParametroParaLista.Value = Tallas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEntregaNave"
            ParametroParaLista.Value = FechaEntregaNave
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEntregaCliente"
            ParametroParaLista.Value = FechaEntregaCliente
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEnvioDeNave"
            ParametroParaLista.Value = FechaEnvioDeNave
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaRecepcionDeComer"
            ParametroParaLista.Value = FechaRecepcionDeComer
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@cedisId"
            ParametroParaLista.Value = cedisIdNave
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("Programacion.SP_Muestras_EnvioRecepcion_Consultas_ResumenProductos", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultaMuestrasPorNave(ByVal AgruparMarcaCollecionTemporada As Boolean,
                                            ByVal AgruparModelo As Boolean,
                                            ByVal AgruparPielColor As Boolean,
                                            ByVal AgruparCorrida As Boolean,
                                            ByVal Operador As String,
                                            ByVal Naves As String,
                                            ByVal Piezas As String,
                                            ByVal Clientes As String,
                                            ByVal PedidosM As String,
                                            ByVal Articulos As String,
                                            ByVal Corridas As String,
                                            ByVal Tallas As String,
                                            ByVal FechaEntregaNave As String,
                                            ByVal FechaEntregaCliente As String,
                                            ByVal FechaEnvioDeNave As String,
                                            ByVal FechaRecepcionDeComer As String,
                                            ByVal cedisidnave As String
                                            ) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        Try

            ParametroParaLista.ParameterName = "@p_MarcaCollecionTemporada"
            ParametroParaLista.Value = AgruparMarcaCollecionTemporada
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@p_Modelo"
            ParametroParaLista.Value = AgruparModelo
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@p_PielColor"
            ParametroParaLista.Value = AgruparPielColor
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@p_Corrida"
            ParametroParaLista.Value = AgruparCorrida
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Operador"
            ParametroParaLista.Value = Operador
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pNaves"
            ParametroParaLista.Value = Naves
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPiezas"
            ParametroParaLista.Value = Piezas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pClientes"
            ParametroParaLista.Value = Clientes
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPedidosM"
            ParametroParaLista.Value = PedidosM
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pArticulos"
            ParametroParaLista.Value = Articulos
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pCorridas"
            ParametroParaLista.Value = Corridas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pTallas"
            ParametroParaLista.Value = Tallas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEntregaNave"
            ParametroParaLista.Value = FechaEntregaNave
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEntregaCliente"
            ParametroParaLista.Value = FechaEntregaCliente
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaEnvioDeNave"
            ParametroParaLista.Value = FechaEnvioDeNave
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaRecepcionDeComer"
            ParametroParaLista.Value = FechaRecepcionDeComer
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@cedisId"
            ParametroParaLista.Value = cedisidnave
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("Programacion.SP_Muestras_EnvioRecepcion_Consultas_MuestrasPorNave", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarUbicacionPiezas(ByVal EntFiltros As Entidades.FiltrosEnvioRecepcionMuestras) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        Try
            ParametroParaLista.ParameterName = "@NaveAlmacen"
            ParametroParaLista.Value = EntFiltros.NaveAlmacen
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@NumeroAlmacen"
            ParametroParaLista.Value = EntFiltros.NumeroAlmacen
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FiltroUbicacion"
            ParametroParaLista.Value = EntFiltros.FiltroUbicacion
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaUbicacionDel"
            ParametroParaLista.Value = EntFiltros.FechaUbicacionDel
            ListaParametros.Add(ParametroParaLista)

            'ParametroParaLista = New SqlParameter
            'ParametroParaLista.ParameterName = "@HoraUbicacionDel"
            'ParametroParaLista.Value = EntFiltros.HoraUbicacionDel
            'ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaUbicacionAl"
            ParametroParaLista.Value = EntFiltros.FechaUbicacionAl
            ListaParametros.Add(ParametroParaLista)

            'ParametroParaLista = New SqlParameter
            'ParametroParaLista.ParameterName = "@HoraUbicacionAl"
            'ParametroParaLista.Value = EntFiltros.HoraUbicacionAl
            'ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FiltroEntregaNave"
            ParametroParaLista.Value = EntFiltros.FiltroentregaNave
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaEntregaNaveDel"
            ParametroParaLista.Value = EntFiltros.FechaEntregaNaveDel
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaEntregaNaveAl"
            ParametroParaLista.Value = EntFiltros.FechaEntregaNaveAl
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FiltroEntregaCliente"
            ParametroParaLista.Value = EntFiltros.FiltroEntregaCliente
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaEntregaClienteDel"
            ParametroParaLista.Value = EntFiltros.FechaEntregaClienteDel
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaEntregaClienteAl"
            ParametroParaLista.Value = EntFiltros.FechaEntregaClienteAl
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FiltroEnvioNave"
            ParametroParaLista.Value = EntFiltros.FiltroEnvioNave
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaEnvioNaveDel"
            ParametroParaLista.Value = EntFiltros.FechaEnvioNaveDel
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaEnvioNaveAl"
            ParametroParaLista.Value = EntFiltros.FechaEnvioNaveAl
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FiltroFechaRecepcion"
            ParametroParaLista.Value = EntFiltros.FiltroRecepcionComercializadora
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaRecepcionComercializadoraDel"
            ParametroParaLista.Value = EntFiltros.FechaRecepcionComercializadoraDel
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@FechaRecepcionComercializadoraAl"
            ParametroParaLista.Value = EntFiltros.FechaRecepcionComercializadoraAl
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@NaveSAYID"
            ParametroParaLista.Value = EntFiltros.NaveSICYID
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Bahia"
            ParametroParaLista.Value = EntFiltros.BahiaID
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@CodigosPieza"
            ParametroParaLista.Value = EntFiltros.CodigosPieza
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@EsClienteOrigen"
            ParametroParaLista.Value = EntFiltros.EsClienteOrigen
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Clientes"
            ParametroParaLista.Value = EntFiltros.Clientes
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@EsPedidoOrigen"
            ParametroParaLista.Value = EntFiltros.EsPedidoOrigen
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@PedidosMuestras"
            ParametroParaLista.Value = EntFiltros.PedidoMuestras
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@StatusAsignada"
            ParametroParaLista.Value = EntFiltros.StatusAsignada
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@StatusDisponible"
            ParametroParaLista.Value = EntFiltros.StatusDisponible
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Articulos"
            ParametroParaLista.Value = EntFiltros.Articulos
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Corrida"
            ParametroParaLista.Value = EntFiltros.Corrida
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Tallas"
            ParametroParaLista.Value = EntFiltros.Tallas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Operador"
            ParametroParaLista.Value = EntFiltros.Operador
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@TipoUbicacion"
            ParametroParaLista.Value = EntFiltros.TipoUbicacion
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@TipoOperacion"
            ParametroParaLista.Value = EntFiltros.TipoOperacion
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("Programacion.SP_Muestras_Ubicacion_Consultas_UbicacionPiezas", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ConsultaMovimientosMuestras(ByVal EntFiltro As Entidades.FiltrosEnvioRecepcionMuestras) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        Try
            ParametroParaLista.ParameterName = "@Operador"
            ParametroParaLista.Value = EntFiltro.Operador
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pMovimientos"
            ParametroParaLista.Value = EntFiltro.Movimientos
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pDelPedidoOrigen"
            ParametroParaLista.Value = EntFiltro.DelPedidoOrigen
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pDelPedidoDelMovimiento"
            ParametroParaLista.Value = EntFiltro.DelPedidoDelMovimiento
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pClientes"
            ParametroParaLista.Value = EntFiltro.Clientes
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPedidosMOrigen"
            ParametroParaLista.Value = EntFiltro.PedidosMOrigen
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPedidosMMovimiento"
            ParametroParaLista.Value = EntFiltro.PedidosMMovimiento
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPedidosM"
            ParametroParaLista.Value = EntFiltro.PedidoMuestras
            ListaParametros.Add(ParametroParaLista)


            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pPiezas"
            ParametroParaLista.Value = EntFiltro.CodigosPieza
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pArticulos"
            ParametroParaLista.Value = EntFiltro.Articulos
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pCorridas"
            ParametroParaLista.Value = EntFiltro.Corrida
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pTallas"
            ParametroParaLista.Value = EntFiltro.Tallas
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@pFechaMovimiento"
            ParametroParaLista.Value = EntFiltro.FechaMovimiento
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("Programacion.SP_Muestras_Movimientos_Consultas", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


End Class
