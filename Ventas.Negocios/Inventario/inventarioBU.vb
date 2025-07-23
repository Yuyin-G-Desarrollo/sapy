Public Class inventarioBU

    Public Function ConsultarInventarioProceso(ByVal TipoConsulta As Integer, ByVal EstatusPedido As String, ByVal ConceptoPar As String, ByVal ClienteSICYID As String, ByVal PedidoSICY As String, ByVal Lote As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal PedidoSAY As String, ByVal Cedis As Integer) As DataTable
        Dim objDA As New Ventas.Datos.InventarioDA
        Return objDA.ConsultarInventarioProceso(TipoConsulta, EstatusPedido, ConceptoPar, ClienteSICYID, PedidoSICY, Lote, Coleccion, Modelo, PedidoSAY, Cedis)
    End Function

    Public Function ConsultarTotalParesProceso() As DataTable
        Dim objDA As New Ventas.Datos.InventarioDA
        Return objDA.ConsultarTotalParesProceso()
    End Function

    Public Function ConsultarParesPorCliente(programado As Boolean, proceso As Boolean, terminado As Boolean, disponible As Boolean, reservado As Boolean, proyectado As Boolean,
                                             clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String, reproceso As Boolean, ByVal Coleccion As String) As DataTable
        Dim objDA As New Ventas.Datos.InventarioDA
        Return objDA.ConsultarParesPorCliente(programado, proceso, terminado, disponible, reservado, proyectado, clientes, familias, modelos, pieles, colores, corridas, reproceso, Coleccion)
    End Function

    Public Function ConsultarParesPorClienteDetalles(programado As Boolean, proceso As Boolean, terminado As Boolean, disponible As Boolean, reservado As Boolean, proyectado As Boolean,
                                                     clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String, reproceso As Boolean, ByVal Coleccion As String) As DataTable
        Dim objDA As New Ventas.Datos.InventarioDA
        Return objDA.ConsultarParesPorClienteDetalles(programado, proceso, terminado, disponible, reservado, proyectado, clientes, familias, modelos, pieles, colores, corridas, reproceso, Coleccion)
    End Function

    Public Function ConsultarParesClientePorFamilia(programado As Boolean, proceso As Boolean, terminado As Boolean, disponible As Boolean, reservado As Boolean, proyectado As Boolean,
                                                    clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String,
                                                    escolar As Boolean, bota As Boolean, sandalia As Boolean, reproceso As Boolean, ByVal Coleccion As String) As DataTable
        Dim objDA As New Ventas.Datos.InventarioDA
        Return objDA.ConsultarParesClientePorFamilia(programado, proceso, terminado, disponible, reservado, proyectado, clientes, familias, modelos, pieles, colores, corridas, escolar, bota, sandalia, reproceso, Coleccion)
    End Function

    Public Function ConsultarParesPorClienteDetallesPedido(programado As Boolean, proceso As Boolean, terminado As Boolean, disponible As Boolean, reservado As Boolean, proyectado As Boolean,
                                                           clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String, reproceso As Boolean, ByVal Coleccion As String) As DataTable
        Dim objDA As New Ventas.Datos.InventarioDA
        Return objDA.ConsultarParesPorClienteDetallesPedido(programado, proceso, terminado, disponible, reservado, proyectado, clientes, familias, modelos, pieles, colores, corridas, reproceso, Coleccion)
    End Function

    Public Function ConsultarParesPorClienteDetallesPedidoPartida(programado As Boolean, proceso As Boolean, terminado As Boolean, disponible As Boolean, reservado As Boolean, proyectado As Boolean,
                                                                  clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String, reproceso As Boolean, ByVal Coleccion As String) As DataTable
        Dim objDA As New Ventas.Datos.InventarioDA
        Return objDA.ConsultarParesPorClienteDetallesPedidoPartida(programado, proceso, terminado, disponible, reservado, proyectado, clientes, familias, modelos, pieles, colores, corridas, reproceso, Coleccion)
    End Function

    Public Function familias() As DataTable
        Dim objDA As New Ventas.Datos.InventarioDA
        Return objDA.familias()
    End Function
End Class
