Imports Programacion.Datos

Public Class Programacion_Reportes_ParesProgramadosPorTallaBU

    Public Function ObtenerConsultaFiltro(ByVal pTipoConsulta As Integer, ByVal pIdNave As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneConsultaFiltro(pTipoConsulta, pIdNave)
    End Function

    Public Function ObtenerNaves(ByVal pIdUsuario As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneNaves(pIdUsuario)
    End Function

    Public Function ObtenerParesProgramadosTallasPrograma(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasPrograma(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasSemana(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasSemana(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasMes(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasMes(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasAnual(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasAnual(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasLote(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasLote(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasPrograma_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasPrograma_Cliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pCliente, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasSemana_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasSemana_Cliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pCliente, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasMes_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasMes_Cliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pCliente, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasLote_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasLote_Cliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pCliente, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasAnual_Cliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, ByVal pCliente As String, ByVal pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasAnual_Cliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pCliente, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasProgramaVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasProgramaVerCliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasSemanaVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasSemanaVerCliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasMesVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasMesVerCliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasAnualVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasAnualVerCliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

    Public Function ObtenerParesProgramadosTallasLoteVerCliente(ByVal pNave As String, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pColeccion As String, ByVal pModelo As String, pPielColor As String, ByVal pCorrida As String, pPedidoSAY As String, ByVal pPedidoSICY As String, ByVal verPedido As Integer) As DataTable
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaDA
        Return obj.ObtieneParesProgramadosTallasLoteVerCliente(pNave, pFechaInicio, pFechaFin, pColeccion, pModelo, pPielColor, pCorrida, pPedidoSAY, pPedidoSICY, verPedido)
    End Function

End Class
