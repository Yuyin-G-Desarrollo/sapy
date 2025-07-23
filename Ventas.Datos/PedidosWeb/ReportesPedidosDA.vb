Imports System.Data.SqlClient

Public Class ReportesPedidosDA
    ''consulta de reporte general de pedidos
    Public Function consultaReporteGeneralPedidos(ByVal estatusProgramacion As String, ByVal estatusFechaE As String, ByVal tipoCondicion As String,
                                                  ByVal estatusPedido As String, ByVal estatusPartida As String, ByVal idCliente As String,
                                                  ByVal idAgente As String, ByVal idAtencion As String, ByVal idRamos As String, ByVal marcas As String,
                                                  ByVal coleccionMarca As String, ByVal modelo As String, ByVal corrida As String, ByVal piel As String,
                                                  ByVal color As String, ByVal familia As String, ByVal tec As String, ByVal pedidoInicial As Boolean, ByVal pedidoResutido As Boolean,
                                                  ByVal pedidoSay As String, ByVal pedidoSicy As String, ByVal fechaCaptura As Boolean, ByVal fechaCapturaInicio As Date,
                                                  ByVal fechaCapturaFin As Date, ByVal fechaSolicitada As Boolean, ByVal fechaSolicitadaInicio As Date,
                                                  ByVal fechaSolicitadaFin As Date, ByVal fechaProgramacion As Boolean, ByVal fechaProgramacionInicio As Date,
                                                  ByVal fechaProgramacionFin As Date, ByVal idusuario As String, ByVal NaveUsuaruio As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'parametros = New SqlParameter()
        parametros.ParameterName = "estatusProgramacion"
        parametros.Value = estatusProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "estatusFechaEntrega"
        parametros.Value = estatusFechaE
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "tipoCondicion"
        parametros.Value = tipoCondicion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "estatusPedido"
        parametros.Value = estatusPedido
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "estatusPartida"
        parametros.Value = estatusPartida
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idAgente"
        parametros.Value = idAgente
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idAtencion"
        parametros.Value = idAtencion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idRamos"
        parametros.Value = idRamos
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "Marcas"
        parametros.Value = marcas
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "coleccionMarca"
        parametros.Value = coleccionMarca
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "modelo"
        parametros.Value = modelo
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "corrida"
        parametros.Value = corrida
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "piel"
        parametros.Value = piel
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "color"
        parametros.Value = color
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "familia"
        parametros.Value = familia
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TEC"
        parametros.Value = tec
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "pedidoInicial"
        parametros.Value = pedidoInicial
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "pedidoResurtido"
        parametros.Value = pedidoResutido
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "pedidoSay"
        parametros.Value = pedidoSay
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "pedidoSicy"
        parametros.Value = pedidoSicy
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaCaptura"
        parametros.Value = fechaCaptura
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaCapturaInicio"
        parametros.Value = fechaCapturaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaCapturaFin"
        parametros.Value = fechaCapturaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaSolicitada"
        parametros.Value = fechaSolicitada
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaSolicitadaInicio"
        parametros.Value = fechaSolicitadaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaSolicitadaFin"
        parametros.Value = fechaSolicitadaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaProgramacion"
        parametros.Value = fechaProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaProgramacionInicio"
        parametros.Value = fechaProgramacionInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaProgramacionFin"
        parametros.Value = fechaProgramacionFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idUsuario"
        parametros.Value = idusuario
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TipoComercializadora"
        parametros.Value = NaveUsuaruio
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaReporteGeneral_v2_05/11/2020", listaParametros)
    End Function

    ''consulta con el listado de marcas(filtro reportes pedido)
    Public Function consultaListadoMarcas() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaListadoMarcas"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de atencion a clientes(filtro reportes pedido)
    Public Function consultaListadoAtencionClientes()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC  Ventas.SP_PedidosWeb_ConsultaListadoAtencionClientes"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de ramos(filtro reportes pedido)
    Public Function consultaListadoRamos()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC  Ventas.SP_PedidosWeb_ConsultaListadoRamos"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de colecciones(filtro reportes pedido)
    Public Function consultaListadoColecciones()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaListadoColecciones"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de modelos(filtro reportes pedido)
    Public Function consultaListadoModelos()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaListadoModelos"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de corridas (filtro reportes pedido)
    Public Function consultaListadoCorridas()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaListadoCorridas"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de pieles (filtro reportes pedido)
    Public Function consultaListadoPieles()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaListadoPieles"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de colores (filtro reportes pedido)
    Public Function consultaListadoColores()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaListadoColores"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de colores (filtro reportes pedido)
    Public Function consultaListadoClienteTec()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaListadoClienteTec"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta con el listado de naves (filtro reportes pedido)
    Public Function consultaListadoNaves()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_ConsultaListadoNaves"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta reporte detallado simplificado
    Public Function consultaReporteDetalladoSimplificado(ByVal verTallas As Boolean, ByVal estatusProgramacion As String, ByVal estatusFechaEntrega As String,
                                                         ByVal tipoCondicion As String, ByVal estatusPedido As String, ByVal estatusPartida As String,
                                                         ByVal idCliente As String, ByVal idAgente As String, ByVal idAtencion As String, ByVal idRamos As String,
                                                         ByVal Marcas As String, ByVal coleccionMarca As String, ByVal modelo As String, ByVal corrida As String,
                                                         ByVal piel As String, ByVal color As String, ByVal familia As String, ByVal TEC As String, ByVal pedidoInicial As String,
                                                         ByVal pedidoResurtido As String, ByVal pedidoSay As String, ByVal pedidoSicy As String,
                                                         ByVal fechaCaptura As Boolean, ByVal fechaCapturaInicio As Date, ByVal fechaCapturaFin As Date,
                                                         ByVal fechaSolicitada As Boolean, ByVal fechaSolicitadaInicio As Date, ByVal fechaSolicitadaFin As Date,
                                                         ByVal fechaProgramacion As Boolean, ByVal fechaProgramacionInicio As Date, ByVal fechaProgramacionFin As Date, ByVal idUsuario As String, ByVal NaveUsuaruio As String) As DataTable

        Dim parametros As New SqlParameter
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "verTallas"
        parametros.Value = verTallas
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusProgramacion"
        parametros.Value = estatusProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusFechaEntrega"
        parametros.Value = estatusFechaEntrega
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "tipoCondicion"
        parametros.Value = tipoCondicion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusPedido"
        parametros.Value = estatusPedido
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusPartida"
        parametros.Value = estatusPartida
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idAgente"
        parametros.Value = idAgente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idAtencion"
        parametros.Value = idAtencion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idRamos"
        parametros.Value = idRamos
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "Marcas"
        parametros.Value = Marcas
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "coleccionMarca"
        parametros.Value = coleccionMarca
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "modelo"
        parametros.Value = modelo
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "corrida"
        parametros.Value = corrida
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "piel"
        parametros.Value = piel
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "color"
        parametros.Value = color
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "familia"
        parametros.Value = familia
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "tec"
        parametros.Value = TEC
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoInicial"
        parametros.Value = pedidoInicial
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoResurtido"
        parametros.Value = pedidoResurtido
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoSay"
        parametros.Value = pedidoSay
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoSicy"
        parametros.Value = pedidoSicy
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaCaptura"
        parametros.Value = fechaCaptura
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaCapturaInicio"
        parametros.Value = fechaCapturaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaCapturaFin"
        parametros.Value = fechaCapturaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaSolicitada"
        parametros.Value = fechaSolicitada
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaSolicitadaInicio"
        parametros.Value = fechaSolicitadaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaSolicitadafin"
        parametros.Value = fechaSolicitadaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacion"
        parametros.Value = fechaProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacioninicio"
        parametros.Value = fechaProgramacionInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacionfin"
        parametros.Value = fechaProgramacionFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idUsuario"
        parametros.Value = idUsuario
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TipoComercializadora"
        parametros.Value = NaveUsuaruio
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaReporteDetallado_Simplificado_v2_05/11/2020", listaParametros)
    End Function

    ''consulta reporte detallado completo
    Public Function consultaReporteDetalladoCompleto(ByVal verTallas As Boolean, ByVal estatusProgramacion As String, ByVal estatusFechaEntrega As String,
                                                        ByVal tipoCondicion As String, ByVal estatusPedido As String, ByVal estatusPartida As String,
                                                        ByVal idCliente As String, ByVal idAgente As String, ByVal idAtencion As String, ByVal idRamos As String,
                                                        ByVal Marcas As String, ByVal coleccionMarca As String, ByVal modelo As String, ByVal corrida As String,
                                                        ByVal piel As String, ByVal color As String, ByVal familia As String, ByVal TEC As String, ByVal pedidoInicial As String,
                                                        ByVal pedidoResurtido As String, ByVal pedidoSay As String, ByVal pedidoSicy As String,
                                                        ByVal fechaCaptura As Boolean, ByVal fechaCapturaInicio As Date, ByVal fechaCapturaFin As Date,
                                                        ByVal fechaSolicitada As Boolean, ByVal fechaSolicitadaInicio As Date, ByVal fechaSolicitadaFin As Date,
                                                        ByVal fechaProgramacion As Boolean, ByVal fechaProgramacionInicio As Date, ByVal fechaProgramacionFin As Date,
                                                        ByVal deptoLote As String, ByVal numeroLote As String, ByVal aniolote As String, ByVal naveLote As String,
                                                        ByVal fechaProgramacionLote As Boolean, ByVal fechaProgramacionLoteInicio As Date, ByVal fechaProgramacionLoteFin As Date,
                                                        ByVal fechaLlegadaLote As Boolean, ByVal fechaLlegadaLoteInicio As Date, ByVal fechaLlegadaLoteFin As Date, ByVal idUsuario As String, ByVal NaveUsuaruio As String) As DataTable

        Dim parametros As New SqlParameter
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "verTallas"
        parametros.Value = verTallas
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusProgramacion"
        parametros.Value = estatusProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusFechaEntrega"
        parametros.Value = estatusFechaEntrega
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "tipoCondicion"
        parametros.Value = tipoCondicion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusPedido"
        parametros.Value = estatusPedido
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusPartida"
        parametros.Value = estatusPartida
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idAgente"
        parametros.Value = idAgente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idAtencion"
        parametros.Value = idAtencion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idRamos"
        parametros.Value = idRamos
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "Marcas"
        parametros.Value = Marcas
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "coleccionMarca"
        parametros.Value = coleccionMarca
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "modelo"
        parametros.Value = modelo
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "corrida"
        parametros.Value = corrida
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "piel"
        parametros.Value = piel
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "color"
        parametros.Value = color
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "familia"
        parametros.Value = familia
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "tec"
        parametros.Value = TEC
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoInicial"
        parametros.Value = pedidoInicial
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoResurtido"
        parametros.Value = pedidoResurtido
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoSay"
        parametros.Value = pedidoSay
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "pedidoSicy"
        parametros.Value = pedidoSicy
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaCaptura"
        parametros.Value = fechaCaptura
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaCapturaInicio"
        parametros.Value = fechaCapturaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaCapturaFin"
        parametros.Value = fechaCapturaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaSolicitada"
        parametros.Value = fechaSolicitada
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaSolicitadaInicio"
        parametros.Value = fechaSolicitadaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaSolicitadafin"
        parametros.Value = fechaSolicitadaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacion"
        parametros.Value = fechaProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacioninicio"
        parametros.Value = fechaProgramacionInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacionfin"
        parametros.Value = fechaProgramacionFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "deptoLote"
        parametros.Value = deptoLote
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "numeroLote"
        parametros.Value = numeroLote
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "aniolote"
        parametros.Value = aniolote
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "naveLote"
        parametros.Value = naveLote
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacionLote"
        parametros.Value = fechaProgramacionLote
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacionLoteInicio"
        parametros.Value = fechaProgramacionLoteInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaProgramacionLoteFin"
        parametros.Value = fechaProgramacionLoteFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaLlegadaLote"
        parametros.Value = fechaLlegadaLote
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaLlegadaLoteInicio"
        parametros.Value = fechaLlegadaLoteInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaLlegadaLoteFin"
        parametros.Value = fechaLlegadaLoteFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idUsuario"
        parametros.Value = idUsuario
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TipoComercializadora"
        parametros.Value = NaveUsuaruio
        listaParametros.Add(parametros)


        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaReporteDetallado_Completo_v2_05/11/2020", listaParametros)
    End Function


    Public Function consultaReportePorFechas(ByVal fechaBase As String, ByVal visualizar As String, ByVal estatusProgramacion As String, ByVal estatusFechaE As String, ByVal tipoCondicion As String,
                                                  ByVal estatusPedido As String, ByVal estatusPartida As String, ByVal idCliente As String,
                                                  ByVal idAgente As String, ByVal idAtencion As String, ByVal idRamos As String, ByVal marcas As String,
                                                  ByVal coleccionMarca As String, ByVal modelo As String, ByVal corrida As String, ByVal piel As String,
                                                  ByVal color As String, ByVal familia As String, ByVal tec As String, ByVal pedidoInicial As Boolean, ByVal pedidoResutido As Boolean,
                                                  ByVal pedidoSay As String, ByVal pedidoSicy As String, ByVal fechaCaptura As Boolean, ByVal fechaCapturaInicio As Date,
                                                  ByVal fechaCapturaFin As Date, ByVal fechaSolicitada As Boolean, ByVal fechaSolicitadaInicio As Date,
                                                  ByVal fechaSolicitadaFin As Date, ByVal fechaProgramacion As Boolean, ByVal fechaProgramacionInicio As Date,
                                                  ByVal fechaProgramacionFin As Date, ByVal idUsuario As String, ByVal NaveUsuaruio As String) As DataTable


        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'parametros = New SqlParameter()
        parametros.ParameterName = "fechaBase"
        parametros.Value = fechaBase
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "visualizar"
        parametros.Value = visualizar
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "estatusProgramacion"
        parametros.Value = estatusProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "estatusFechaEntrega"
        parametros.Value = estatusFechaE
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "tipoCondicion"
        parametros.Value = tipoCondicion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "estatusPedido"
        parametros.Value = estatusPedido
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "estatusPartida"
        parametros.Value = estatusPartida
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idAgente"
        parametros.Value = idAgente
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idAtencion"
        parametros.Value = idAtencion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idRamos"
        parametros.Value = idRamos
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "Marcas"
        parametros.Value = marcas
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "coleccionMarca"
        parametros.Value = coleccionMarca
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "modelo"
        parametros.Value = modelo
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "corrida"
        parametros.Value = corrida
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "piel"
        parametros.Value = piel
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "color"
        parametros.Value = color
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "familia"
        parametros.Value = familia
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TEC"
        parametros.Value = tec
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "pedidoInicial"
        parametros.Value = pedidoInicial
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "pedidoResurtido"
        parametros.Value = pedidoResutido
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "pedidoSay"
        parametros.Value = pedidoSay
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "pedidoSicy"
        parametros.Value = pedidoSicy
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaCaptura"
        parametros.Value = fechaCaptura
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaCapturaInicio"
        parametros.Value = fechaCapturaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaCapturaFin"
        parametros.Value = fechaCapturaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaSolicitada"
        parametros.Value = fechaSolicitada
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaSolicitadaInicio"
        parametros.Value = fechaSolicitadaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaSolicitadaFin"
        parametros.Value = fechaSolicitadaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaProgramacion"
        parametros.Value = fechaProgramacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaProgramacionInicio"
        parametros.Value = fechaProgramacionInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechaProgramacionFin"
        parametros.Value = fechaProgramacionFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "idUsuario"
        parametros.Value = idUsuario
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TipoComercializadora"
        parametros.Value = NaveUsuaruio
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaReporte_PorFechas_v2_05/11/2020", listaParametros)

    End Function

    ''funcion para consultar la lista de los clientes todos
    Public Function consultaClientesTodos(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaCLientes_Todos", listaParametros)
    End Function

#Region "ventas reporte estadisticas"

    Public Function consultaListadoColeccionesEstadVentas()
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_EstadVta_ConsultaListadoColecciones"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    Public Function consultaListadoFamilias() As DataTable
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        consulta = "EXEC Ventas.SP_PedidosWeb_EstadVta_ConsultaListadoFamilias"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    Public Function consultaClientesTodosRPTVENTAS(ByVal idUsuario As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_EstadVta_ConsultaCLientes_Todos", listaParametros)
    End Function
    Public Function consultaReporteEstadisticoVentas(ByVal idCliente As String,
                                                 ByVal idAgente As String,
                                                 ByVal marcas As String,
                                                 ByVal familias As String,
                                                 ByVal colecciones As String,
                                                 ByVal fechaInicio As Date,
                                                 ByVal fechaFin As Date, ByVal idusuario As String, ByVal NaveUsuaruio As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'parametros = New SqlParameter()


        parametros = New SqlParameter()
        parametros.ParameterName = "ClientesIDSay"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "AgentesIDSay"
        parametros.Value = idAgente
        listaParametros.Add(parametros)


        parametros = New SqlParameter()
        parametros.ParameterName = "MarcasIDSay"
        parametros.Value = marcas
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FamiliasProyeccionIDSay"
        parametros.Value = familias
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "ColeccionMarcaIDSay"
        parametros.Value = colecciones
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FechaInicio"
        parametros.Value = fechaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FechaFin"
        parametros.Value = fechaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "UsuarioIdSay"
        parametros.Value = idusuario
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TipoComercializadora"
        parametros.Value = NaveUsuaruio
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSayWeb_EstadisticaVentasGeneral_ConcentradoTotal_02/11/2020", listaParametros)
    End Function
    Public Function consultaReporteEstadisticoVentas2(ByVal idCliente As String,
                                                ByVal idAgente As String,
                                                ByVal marcas As String,
                                                ByVal familias As String,
                                                ByVal colecciones As String,
                                                ByVal fechaInicio As Date,
                                                ByVal fechaFin As Date, ByVal idusuario As String,
                                                ByVal NaveUsuario As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'parametros = New SqlParameter()


        parametros = New SqlParameter()
        parametros.ParameterName = "ClientesIDSay"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "AgentesIDSay"
        parametros.Value = idAgente
        listaParametros.Add(parametros)


        parametros = New SqlParameter()
        parametros.ParameterName = "MarcasIDSay"
        parametros.Value = marcas
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FamiliasProyeccionIDSay"
        parametros.Value = familias
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "ColeccionMarcaIDSay"
        parametros.Value = colecciones
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FechaInicio"
        parametros.Value = fechaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FechaFin"
        parametros.Value = fechaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "UsuarioIdSay"
        parametros.Value = idusuario
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TipoComercializadora"
        parametros.Value = NaveUsuario
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSayWeb_EstadVtasGral_ConcentradoTotal_31/10/2020", listaParametros)
    End Function
    Public Function consultaReporteEstadisticoVentasClienteFamilia(ByVal idCliente As String,
                                                 ByVal idAgente As String,
                                                 ByVal marcas As String,
                                                 ByVal familias As String,
                                                 ByVal colecciones As String,
                                                 ByVal fechaInicio As Date,
                                                 ByVal fechaFin As Date, ByVal idusuario As String,
                                                 ByVal NaveUsuario As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'parametros = New SqlParameter()


        parametros = New SqlParameter()
        parametros.ParameterName = "ClientesIDSay"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "AgentesIDSay"
        parametros.Value = idAgente
        listaParametros.Add(parametros)


        parametros = New SqlParameter()
        parametros.ParameterName = "MarcasIDSay"
        parametros.Value = marcas
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FamiliasProyeccionIDSay"
        parametros.Value = familias
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "ColeccionMarcaIDSay"
        parametros.Value = colecciones
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FechaInicio"
        parametros.Value = fechaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FechaFin"
        parametros.Value = fechaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "UsuarioIdSay"
        parametros.Value = idusuario
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "TipoComercializadora"
        parametros.Value = NaveUsuario
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSayWeb_EstadisticaVentasGeneral_ClienteFamilia_31/10/2020", listaParametros)
    End Function

    Public Function consultaReporteEstadisticoVentasFamiliaCliente(ByVal idCliente As String,
                                                 ByVal idAgente As String,
                                                 ByVal marcas As String,
                                                 ByVal familias As String,
                                                 ByVal colecciones As String,
                                                 ByVal fechaInicio As Date,
                                                 ByVal fechaFin As Date, ByVal idusuario As String) As DataTable

        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'parametros = New SqlParameter()


        parametros = New SqlParameter()
        parametros.ParameterName = "ClientesIDSay"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "AgentesIDSay"
        parametros.Value = idAgente
        listaParametros.Add(parametros)


        parametros = New SqlParameter()
        parametros.ParameterName = "MarcasIDSay"
        parametros.Value = marcas
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FamiliasProyeccionIDSay"
        parametros.Value = familias
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "ColeccionMarcaIDSay"
        parametros.Value = colecciones
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FechaInicio"
        parametros.Value = fechaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "FechaFin"
        parametros.Value = fechaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "UsuarioIdSay"
        parametros.Value = idusuario
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ReportesSayWeb_EstadisticaVentasGeneral_FamiliaCliente", listaParametros)
    End Function

    Public Function bitacora_reporte_venta(ByVal Exportado_a As String,
                                             ByVal Aplicacion As String,
                                             ByVal tipoReporte As String,
                                             ByVal fechaInicio As Date,
                                             ByVal fechaFin As Date, ByVal idusuario As String)

        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'parametros = New SqlParameter()


        parametros = New SqlParameter()
        parametros.ParameterName = "exportado_a"
        parametros.Value = Exportado_a
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "aplicacion"
        parametros.Value = Aplicacion
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "tiporeporte"
        parametros.Value = tipoReporte
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechainicio"
        parametros.Value = fechaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "fechafin"
        parametros.Value = fechaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter()
        parametros.ParameterName = "usuarioid"
        parametros.Value = idusuario
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("Framework.SP_framework_CreacionBitacoraExportacionArchivo", listaParametros)
    End Function

#End Region
End Class
