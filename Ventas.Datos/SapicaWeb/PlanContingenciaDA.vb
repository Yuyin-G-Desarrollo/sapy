Imports System.Data.SqlClient

Public Class PlanContingenciaDA
    ''''funcion para recuperar las sentencias a insertar
    Public Function generaSentencias(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametros As New SqlParameter

        parametros.ParameterName = "fechaInicio"
        parametros.Value = fechaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaFin"
        parametros.Value = fechaFin
        listaParametros.Add(parametros)

        Return persistencia.EjecutarConsultaSP("SAPICA.PedidosWeb_PlanContingencia_GenerarSentencias", listaParametros)
    End Function

    ''''funcion para consultar la feacha d ela ultima actualizacion 
    Public Function consultaUltimaActualizacion() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC Sapica.PedidosWeb_PlanContingencia_UltimaActualizacion"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta de las sentencias temporales
    Public Function consultaSentenciasTemporales() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC Sapica.PedidosWeb_PlanContingencia_ConsultaSentenciaTemporal"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''consulta nombre tabla
    Public Function consultaNombreTabla(ByVal idTabla As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametros As New SqlParameter

        parametros.ParameterName = "idTabla"
        parametros.Value = idTabla
        listaParametros.Add(parametros)


        Return persistencia.EjecutarConsultaSP("SAPICA.PedidosWeb_PlanContingencia_ConsultaNombreTabla", listaParametros)
    End Function


    ''consulta del nombre para la sincronizacion
    Public Function consultaNombreSincronizacion() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC Sapica.PedidosWeb_PlanContingencia_TituloSincronizacion"

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    ''Genera el encabezado de la bitacora
    Public Sub insertaBitacoraSentenciasPaso1(ByVal sincronizacion_De As String, ByVal Sincronizacion_A As String,
                                                   ByVal UsuarioGeneraID As Int32, ByVal fechaInicio As DateTime,
                                                   ByVal fechaFin As DateTime)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametros As New SqlParameter

        parametros.ParameterName = "sincronizacion_De"
        parametros.Value = sincronizacion_De
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "Sincronizacion_A"
        parametros.Value = Sincronizacion_A
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaInicio"
        parametros.Value = fechaInicio
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fechaFin"
        parametros.Value = fechaFin
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "UsuarioGeneraID"
        parametros.Value = UsuarioGeneraID
        listaParametros.Add(parametros)

        persistencia.EjecutarSentenciaSP("SAPICA.Pedidos_Web_PlanContingencia_GenerarBitacora_Paso1", listaParametros)
    End Sub

    ''inserta las sentencias 
    Public Sub insertaSentenciasPaso2(ByVal idUsuario As Int32, ByVal sentencia As String)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametros As New SqlParameter

        parametros.ParameterName = "idUsuario"
        parametros.Value = idUsuario
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "CadenaArchivo"
        parametros.Value = sentencia
        listaParametros.Add(parametros)

        persistencia.EjecutarSentenciaSP("SAPICA.Pedidos_Web_PlanContingencia_GuardarSentencia_Paso2", listaParametros)
    End Sub

    ''consulta para ejecutar las sentencias, paso 3
    Public Sub ejecutaSentenciasPaso3()
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC [SAPICA].[Pedidos_Web_PlanContingencia_EjecutarSentencias_Paso3]"

        persistencia.EjecutaSentencia(consulta)
    End Sub

    ''consulta del resumen de las sentencias insertadas
    Public Function consultaResumenSentenciasInsertadas() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC [SAPICA].[Pedidos_Web_PlanContingencia_ConsultaSentenciasInsertadas]"

        Return persistencia.EjecutaConsulta(consulta)
    End Function
End Class
