Public Class ProyeccionProduccionDA
    Public Function ObtieneProyeccionProduccionRVO(ByVal pSemanaInicio As Integer, ByVal pSemanaFin As Integer, ByVal pAño As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@semanaInicio"
        parametro.Value = pSemanaInicio
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@semanaFin"
        parametro.Value = pSemanaFin
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@año"
        parametro.Value = pAño
        listaParametros.Add(parametro)

        dt = operacion.EjecutarConsultaSP("Programacion.SP_Proyeccion_Produccion_RVO", listaParametros)

        Return dt
    End Function

    Public Function ObtieneProyeccionProduccionFVO(ByVal pSemanaInicio As Integer, ByVal pSemanaFin As Integer, ByVal pAño As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@semanaInicio"
        parametro.Value = pSemanaInicio
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@semanaFin"
        parametro.Value = pSemanaFin
        listaParametros.Add(parametro)
        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@año"
        parametro.Value = pAño
        listaParametros.Add(parametro)

        dt = operacion.EjecutarConsultaSP("Programacion.SP_Proyeccion_Produccion_FVO", listaParametros)

        Return dt
    End Function

    Public Function ObtieneProyeccionProduccionEncabezados(ByVal pClaveGrupo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim dt As New DataTable
        Dim mensaje As String = String.Empty
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@claveGrupo"
        parametro.Value = pClaveGrupo
        listaParametros.Add(parametro)

        dt = operacion.EjecutarConsultaSP("Programacion.SP_Programacion_ProyeccionDeProduccion_Encabezados", listaParametros)

        Return dt
    End Function

End Class
