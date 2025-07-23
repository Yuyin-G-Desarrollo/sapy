Imports Programacion.Datos
Public Class CartasInformativasBU

    Public Function ConsultaPedidosPorEntregar(ByVal filtroFecha As Integer, ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal acciones As String, ByVal idEstatus As Integer) As DataTable
        Dim obj As New CartasInformativasDA
        Return obj.ConsultaPedidosPorEntregar(filtroFecha, fechaDel, fechaAl, acciones, idEstatus)
    End Function

    Public Function ConsultaPartidasDelPedido(ByVal PedidoSAY As Integer, ByVal acciones As String)
        Dim obj As New CartasInformativasDA
        Return obj.ConsultaPartidasDelPedido(PedidoSAY, acciones)
    End Function

    Public Function ConsultaPartidasTallaDelPedido(ByVal PedidoSAY As Integer, ByVal Partidas As String, ByVal Acciones As String)
        Dim obj As New CartasInformativasDA
        Return obj.ConsultaPartidasTallaDelPedido(PedidoSAY, Partidas, Acciones)
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
                                       ByVal NaveId As Integer)
        'ByVal Lote As Integer,
        'ByVal FechaPrograma As Date

        Dim obj As New CartasInformativasDA
        Return obj.RegistrarEtiquetas(PedidoSAY, Cliente, Partida, ModeloSay, PielColor, Corrida, Talla, Etiquetas, Usuario, Estatus, Acciones, Observaciones, NaveId)
    End Function
    Public Function ActualizaEstatus(ByVal Operacion As String, ByVal Pedidos As String, ByVal Fecha As DateTime)
        Dim obj As New CartasInformativasDA
        Return obj.ActualizaEstatus(Operacion, Pedidos, Fecha)
    End Function

    Public Function ConsultaLotesConEtiquetasFaltantes(ByVal NaveId As Integer, ByVal FechaPrograma As Date)
        Dim obj As New CartasInformativasDA
        Return obj.ConsultaLotesConEtiquetasFaltantes(NaveId, FechaPrograma)
    End Function

    Public Function obtenerFolioCarta() As Integer
        Dim obj As New CartasInformativasDA
        Dim tabla As New DataTable
        Dim folio As Integer
        tabla = obj.ObtenerFolioCarta()
        folio = CInt(tabla.Rows(0).Item("Folio"))
        Return folio
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
        Dim obj As New CartasInformativasDA
        Return obj.GuardarFolioCarta(Folio, Nave, NaveId, Lote, ParesLote, EtiqFaltante, Modelo, Corrida, PielColor, PedidoSICY, PedidoSAY, Cliente, FechaPrograma, Observaciones, Estatus, Partida, Solicitante)
    End Function

    Public Function solicitarCarta(ByVal NaveId As Integer, ByVal Folio As Integer)
        Dim obj As New CartasInformativasDA
        Return obj.SolicitarCarta(NaveId, Folio)
    End Function

    Public Function consultaFolioSolicitud(ByVal filtroFechas As Integer, ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal idEstatus As Integer, ByVal pedidoSay As Integer)
        'ByVal fechaDel As Date, ByVal fechaAl As Date
        Dim obj As New CartasInformativasDA
        Return obj.ConsultaFolioSolicitud(filtroFechas, fechaDel, fechaAl, idEstatus, pedidoSay)
    End Function

    Public Function consultaFolioSolicitudDetalle(ByVal folio As Integer)
        Dim obj As New CartasInformativasDA
        Return obj.ConsultaFolioSolicitudDetalle(folio)
    End Function

    Public Function rechazarAutorizarFolioCarta(ByVal accion As Integer, ByVal folios As String)
        Dim obj As New CartasInformativasDA
        Return obj.RechazarAutorizarFolioCarta(accion, folios)
    End Function

    Public Function consultaEstatusCartas()
        Dim obj As New CartasInformativasDA
        Return obj.consultaEstatusCartas()
    End Function

    Public Function ConsultarFoliosAutorizados(ByVal idNave As Integer, ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal detalle As Integer)
        Dim obj As New CartasInformativasDA
        Return obj.ConsultarFoliosAutorizados(idNave, fechaDel, fechaAl, detalle)
    End Function

    Public Function InsertarTablaFaltantes(ByVal idPedidoSay As Integer)
        Dim obj As New CartasInformativasDA
        Return obj.InsertarTablaFaltantes(idPedidoSay)
    End Function

    Public Function ConsultaEstatusSolicitud()
        Dim obj As New CartasInformativasDA
        Return obj.ConsultaEstatusSolicitud()
    End Function

    Public Function ConsultarEtiquetadoEspecial(ByVal FechaPrograma As Date, ByVal NaveID As Integer, ByVal ComercializadoraID As Integer) As DataTable
        Dim obj As New CartasInformativasDA
        Return obj.ConsultarEtiquetadoEspecial(FechaPrograma, NaveID, ComercializadoraID)
    End Function

End Class
