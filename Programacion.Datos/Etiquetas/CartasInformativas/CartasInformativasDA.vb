Imports System.Data.SqlClient

Public Class CartasInformativasDA

    Public Function ConsultaPedidosPorEntregar(ByVal filtroFecha As Integer, ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal acciones As String, ByVal idEstatus As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim dtPedidos As New DataTable

        Dim parametro As New SqlParameter("@filtroFecha", filtroFecha)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaDel", fechaDel)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("fechaAl", fechaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@acciones", acciones)
        listaParametros.Add(parametro)

        If idEstatus = 0 Then
            If acciones = "REGISTRAR_ENVIAR" Then
                dtPedidos = objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaPedidosPorEntregar]", listaParametros)
            ElseIf acciones = "VALIDAR_SOLICITAR" Then
                dtPedidos = objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaPedidosPorEntregarEnviadosPPCP]", listaParametros)
            End If
        Else
            parametro = New SqlParameter("@IdEstatus", idEstatus)
            listaParametros.Add(parametro)

            dtPedidos = objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaPedidosPorEntregarEstatusCarta]", listaParametros)

        End If

        Return dtPedidos
    End Function

    Public Function ConsultaPartidasDelPedido(ByVal PedidoSAY As Integer, ByVal acciones As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@PedidoSAY", PedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@acciones", acciones)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaPedidosPorEntregar_Partidas]", listaParametros)
    End Function

    Public Function ConsultaPartidasTallaDelPedido(ByVal PedidoSAY As Integer, ByVal Partidas As String, ByVal Acciones As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@PedidoSAY", PedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Partidas", Partidas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Acciones", Acciones)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaPedidosPorEntregar_PartidasTallas]", listaParametros)

    End Function

    Public Function RegistrarEtiquetas(ByVal PedidoSAY As Integer,
                                       ByVal Cliente As String,
                                       ByVal Partida As Integer,
                                       ByVal ModeloSay As String,
                                       ByVal PielColor As String,
                                       ByVal Corrida As String,
                                       ByVal Talla As String,
                                       ByVal Etiquetas As Integer,
                                       ByVal Usuario As String,
                                       ByVal Estatus As Integer,
                                       ByVal Acciones As String,
                                       ByVal Observaciones As String,
                                       ByVal NaveId As Integer
                                       )
        'ByVal Lote As Integer,
        'ByVal FechaPrograma As Date

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@PedidoSAY", PedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Cliente", Cliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Partida", Partida)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ModeloSay", ModeloSay)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PielColor", PielColor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Corrida", Corrida)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Talla", Talla)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Etiquetas", Etiquetas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Usuario", Usuario)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Estatus", Estatus)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Acciones", Acciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Observaciones", Observaciones)
        listaParametros.Add(parametro)

        'parametro = New SqlParameter("@Lote", Lote)
        'listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveId", NaveId)
        listaParametros.Add(parametro)

        'parametro = New SqlParameter("@FechaPrograma", FechaPrograma)
        'listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_RegistrarEtiquetasTallas]", listaParametros)

    End Function

    Public Function ActualizaEstatus(ByVal Operacion As String, ByVal Pedidos As String, ByVal fecha As DateTime)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Operacion", Operacion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Pedidos", Pedidos)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Fecha", fecha)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ActualizaEstatusPedidosPartidasTallas]", listaParametros)

    End Function

    Public Function ConsultaLotesConEtiquetasFaltantes(ByVal NaveId As Integer, ByVal FechaPrograma As Date)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter("@NaveId", NaveId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaPrograma", FechaPrograma)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaLotesConEtiquetasFaltantes]", listaParametros)

    End Function

    Public Function ObtenerFolioCarta()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ObtenerFolio]", listaParametros)
    End Function

    Public Function GuardarFolioCarta(ByVal Folio As Integer,
                                      ByVal Nave As String,
                                      ByVal NaveId As Integer,
                                      ByVal Lote As Integer,
                                      ByVal ParesLote As Integer,
                                      ByVal EtiqFaltante As Integer,
                                      ByVal Modelo As String,
                                      ByVal Corrida As String,
                                      ByVal PielColor As String,
                                      ByVal PedidoSICY As Integer,
                                      ByVal PedidoSAY As Integer,
                                      ByVal Cliente As String,
                                      ByVal FechaPrograma As Date,
                                      ByVal Observaciones As String,
                                      ByVal Estatus As Integer,
                                      ByVal Partida As Integer,
                                      ByVal Solicitante As String
                                      )
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Folio", Folio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Nave", Nave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveId", NaveId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Lote", Lote)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ParesLote", ParesLote)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@EtiqFaltante", EtiqFaltante)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Modelo", Modelo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Corrida", Corrida)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PielColor", PielColor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PedidoSICY", PedidoSICY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PedidoSAY", PedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Cliente", Cliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaPrograma", FechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Observaciones", Observaciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Estatus", Estatus)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Partida", Partida)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Solicitante", Solicitante)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_GuardarFolio]", listaParametros)
    End Function

    Public Function SolicitarCarta(ByVal NaveId As Integer, ByVal Folio As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@NaveId", NaveId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Folio", Folio)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaFolioLotes]", listaParametros)

    End Function

    Public Function ConsultaFolioSolicitud(ByVal filtroFechas As Integer, ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal idEstatus As Integer, ByVal pedidoSay As Integer)
        'ByVal fechaDel As Date, ByVal fechaAl As Date
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@filtroFechas", filtroFechas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaDel", fechaDel)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaAl", fechaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@estatusId", idEstatus)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@pedidoSay", pedidoSay)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaFolioSolicitud]", listaParametros)
    End Function

    Public Function ConsultaFolioSolicitudDetalle(ByVal folio As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Folio", folio)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaFolioSolicitudDetalle]", listaParametros)
    End Function

    Public Function RechazarAutorizarFolioCarta(ByVal accion As Integer, ByVal folios As String)
        Dim obj = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Accion", accion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Folios", folios)
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_AutorizarRechazarFolio]", listaParametros)
    End Function

    Public Function ConsultaEstatusCartas()
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaEstatusCombo]", listaParametros)
    End Function

    Public Function ConsultarFoliosAutorizados(ByVal idNave As Integer, ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal detalle As Integer)
        Dim obj = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter("@idNave", idNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaDel", fechaDel)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaAl", fechaAl)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@detalle", detalle)
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaAutorizadas]", listaParametros)

    End Function

    Public Function InsertarTablaFaltantes(ByVal idPedidoSay As Integer)
        Dim obj = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@pedidoSAY", idPedidoSay)
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_RegistrarEtiquetasFaltantes]", listaParametros)

    End Function

    Public Function ConsultaEstatusSolicitud()
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativa_ConsultaEstatusVerSolicitud]", listaParametros)
    End Function


    Public Function ConsultarEtiquetadoEspecial(ByVal FechaPrograma As Date, ByVal NaveID As Integer, ByVal ComercializadoraID As Integer) As DataTable
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@FechaPrograma", FechaPrograma)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ComercializadoraID", ComercializadoraID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CartaInformativas_ConsultarEtiquetadoEspecial]", listaParametros)
    End Function

End Class
