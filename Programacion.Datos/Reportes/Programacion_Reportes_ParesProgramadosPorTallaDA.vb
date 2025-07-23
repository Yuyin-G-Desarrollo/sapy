Imports System.Data.SqlClient

Public Class Programacion_Reportes_ParesProgramadosPorTallaDA


    Public Function ObtieneConsultaFiltro(ByVal pTipoConsulta As Integer, ByVal pIdNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TipoConsulta"
        parametro.Value = pTipoConsulta
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ConsultasFiltros]", listaparametros)
    End Function

    Public Function ObtieneNaves(ByVal pIdUsuario As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdUsuario"
        parametro.Value = pIdUsuario
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Framework].[SP_ConsultaNavesAsignadas]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasPrograma(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorPrograma_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasSemana(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorSemana_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasMes(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorMes_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasAnual(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_Anual_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasLote(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorLote_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasPrograma_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cliente"
        parametro.Value = pCliente
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorPrograma_Cliente_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasSemana_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cliente"
        parametro.Value = pCliente
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorSemana_Cliente_Pedido]", listaparametros) 'bueno
    End Function

    Public Function ObtieneParesProgramadosTallasMes_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cliente"
        parametro.Value = pCliente
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorMes_Cliente_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasLote_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cliente"
        parametro.Value = pCliente
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorLote_Cliente_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasAnual_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cliente"
        parametro.Value = pCliente
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_Anual_Cliente_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasProgramaVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorProgramaVerCliente_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasSemanaVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorSemanaVerCliente_Pedido]", listaparametros)
    End Function
    Public Function ObtieneParesProgramadosTallasMesVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorMesVerCliente_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasAnualVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_AnualVerCliente_Pedido]", listaparametros)
    End Function

    Public Function ObtieneParesProgramadosTallasLoteVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        parametro.Value = pPedidoSAY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = pPedidoSICY
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@VerPedido"
        parametro.Value = verPedido
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Obtiene_ParesProgramadosTallas_PorLoteVerClienteVerCliente_Pedido]", listaparametros)
    End Function
End Class
