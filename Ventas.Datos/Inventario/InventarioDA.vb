Imports System.Data.SqlClient

Public Class InventarioDA

    Public Function ConsultarInventarioProceso(ByVal TipoConsulta As Integer, ByVal EstatusPedido As String, ByVal ConceptoPar As String, ByVal ClienteSICYID As String, ByVal PedidoSICY As String, ByVal Lote As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal PedidoSAY As String, ByVal Cedis As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@TipoConsulta"
        parametro.Value = TipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EstatusPedido"
        parametro.Value = EstatusPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ConceptoPar"
        parametro.Value = ConceptoPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteSICYID"
        parametro.Value = ClienteSICYID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = Lote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = Modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cedis"
        parametro.Value = Cedis
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_ConsultaInvetarioProceso]", listaParametros)

    End Function


    Public Function ConsultarTotalParesProceso() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Inventario_TotalParesProceso]", listaParametros)

    End Function


    'Consulta el total de pares por cada cliente (Cliente,Total Pares)'
    Public Function ConsultarParesPorCliente(programado As Boolean, proceso As Boolean, terminado As Boolean, disponibles As Boolean, reservado As Boolean, proyectados As Boolean,
                                             clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String, reproceso As Boolean, ByVal Coleccion As String
                                             ) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@programado"
        parametro.Value = programado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proceso" '0-1'
        parametro.Value = proceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@terminado" '0-1'
        parametro.Value = terminado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@disponible"
        parametro.Value = disponibles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reservado"
        parametro.Value = reservado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proyectados"
        parametro.Value = proyectados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familias"
        parametro.Value = familias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modelos"
        parametro.Value = modelos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pieles"
        parametro.Value = pieles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colores"
        parametro.Value = colores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@corridas"
        parametro.Value = corridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reproceso"
        parametro.Value = reproceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Consulta_Pares_Totales_Por_Cliente_Prueba]", listaParametros)
    End Function


    'Consulta el total de pares por cada cliente con detalles (Cliente,Corrida,Modelo SYSI, Modelo SAY,Agrupamiento,Total Pares)'
    Public Function ConsultarParesPorClienteDetalles(programado As Boolean, proceso As Boolean, terminado As Boolean, disponibles As Boolean, reservado As Boolean, proyectados As Boolean,
                                                     clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String, reproceso As Boolean, ByVal Coleccion As String
                                                     ) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@programado"
        parametro.Value = programado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proceso" '0-1'
        parametro.Value = proceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@terminado" '0-1'
        parametro.Value = terminado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@disponibles"
        parametro.Value = disponibles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reservado"
        parametro.Value = reservado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proyectados"
        parametro.Value = proyectados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familias"
        parametro.Value = familias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modelos"
        parametro.Value = modelos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pieles"
        parametro.Value = pieles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colores"
        parametro.Value = colores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@corridas"
        parametro.Value = corridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reproceso"
        parametro.Value = reproceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Consulta_Pares_Totales_Por_Cliente_Detalles_Prueba]", listaParametros)
    End Function
    'Consulta el total de pares por cada cliente y por familia 
    Public Function ConsultarParesClientePorFamilia(programado As Boolean, proceso As Boolean, terminado As Boolean, disponibles As Boolean, reservado As Boolean, proyectados As Boolean,
                                                    clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String,
                                                    escolar As Boolean, bota As Boolean, sandalia As Boolean, reproceso As Boolean, ByVal Coleccion As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@programado"
        parametro.Value = programado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proceso" '0-1'
        parametro.Value = proceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@terminado" '0-1'
        parametro.Value = terminado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@disponibles"
        parametro.Value = disponibles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reservado"
        parametro.Value = reservado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proyectados"
        parametro.Value = proyectados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familias"
        parametro.Value = familias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modelos"
        parametro.Value = modelos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pieles"
        parametro.Value = pieles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colores"
        parametro.Value = colores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@corridas"
        parametro.Value = corridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@escolar"
        parametro.Value = escolar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@bota"
        parametro.Value = bota
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@sandalia"
        parametro.Value = sandalia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reproceso"
        parametro.Value = reproceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Consulta_Pares_Totales_Por_Familia_Prueba]", listaParametros)
    End Function

    Public Function ConsultarParesPorClienteDetallesPedido(programado As Boolean, proceso As Boolean, terminado As Boolean, disponibles As Boolean, reservado As Boolean, proyectados As Boolean,
                                                           clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String, reproceso As Boolean, ByVal Coleccion As String
                                                          ) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@programado"
        parametro.Value = programado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proceso" '0-1'
        parametro.Value = proceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@terminado" '0-1'
        parametro.Value = terminado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@disponibles"
        parametro.Value = disponibles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reservado"
        parametro.Value = reservado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proyectados"
        parametro.Value = proyectados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familias"
        parametro.Value = familias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modelos"
        parametro.Value = modelos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pieles"
        parametro.Value = pieles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colores"
        parametro.Value = colores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@corridas"
        parametro.Value = corridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reproceso"
        parametro.Value = reproceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Consulta_Pares_Totales_Por_Cliente_Detalles_Pedido_Prueba]", listaParametros)
    End Function

    Public Function ConsultarParesPorClienteDetallesPedidoPartida(programado As Boolean, proceso As Boolean, terminado As Boolean, disponibles As Boolean, reservado As Boolean, proyectados As Boolean,
                                                                  clientes As String, familias As String, modelos As String, pieles As String, colores As String, corridas As String, reproceso As Boolean, ByVal Coleccion As String
                                                                 ) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@programado"
        parametro.Value = programado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proceso" '0-1'
        parametro.Value = proceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@terminado" '0-1'
        parametro.Value = terminado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@disponibles"
        parametro.Value = disponibles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reservado"
        parametro.Value = reservado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proyectados"
        parametro.Value = proyectados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clientes"
        parametro.Value = clientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familias"
        parametro.Value = familias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modelos"
        parametro.Value = modelos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pieles"
        parametro.Value = pieles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colores"
        parametro.Value = colores
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@corridas"
        parametro.Value = corridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@reproceso"
        parametro.Value = reproceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Consulta_Pares_Totales_Por_Cliente_Detalles_Pedido_Partida_Prueba]", listaParametros)
    End Function

    Public Function familias() As DataTable
        Try
            Dim objPersistencia As New Persistencia.OperacionesProcedimientos
            Return objPersistencia.EjecutaConsulta(" Select  DISTINCT FamiliaProyeccion as Familia FROM Programacion.vProductoEstilos_Completo ")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
