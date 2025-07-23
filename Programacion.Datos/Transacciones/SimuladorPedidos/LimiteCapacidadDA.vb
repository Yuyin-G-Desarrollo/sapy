Public Class LimiteCapacidadDA

    Public Function consultaLineaLimiteCapacidadAnio(ByVal idLinea As Int32,
                                                     ByVal anio As Int32,
                                                     ByVal simulacion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@linea"
        parametro.Value = idLinea
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@simulacion"
        parametro.Value = simulacion
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Programacion.SP_LineaLimiteCapacidad", listaParametros)

    End Function


    Public Sub guardardarLimiteCapacidadLinea(ByVal entLimiteCap As Entidades.LimiteCapacidad)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
       
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@limiteCapacidadId"
        If Not entLimiteCap.LimiteCapacidadID = Nothing Then
            parametro.Value = entLimiteCap.LimiteCapacidadID
        Else
            parametro.Value = DBNull.Value
        End If

        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@lineaId"
        parametro.Value = entLimiteCap.LineaId
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@simulacionMaestroId"
        parametro.Value = entLimiteCap.SimulacionMaestroId
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@porcentaje"
        parametro.Value = entLimiteCap.Porcentaje
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@cantidad"
        parametro.Value = entLimiteCap.Cantidad
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@semana"
        parametro.Value = entLimiteCap.semana
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = entLimiteCap.Anio
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@dias"
        parametro.Value = entLimiteCap.Dias
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = entLimiteCap.Activo
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Programacion.SP_GuardarLimiteCapacidad", listaParametros)
    End Sub

End Class
