Public Class IncapacidadesReplicarDA

    Public Sub ReplicarIncapacidadesInsert(ByVal Incapacidad As Entidades.IncapacidadesReplicar, ByVal BD As String, ByVal Servidor As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " INSERT INTO [" + Servidor.ToString.Trim + "].[" + BD.ToString.Trim + "].[dbo].[nom10018]"
        consulta += " ("
        consulta += " idtipoincidencia"
        consulta += " ,idempleado"
        consulta += " ,folio"
        consulta += " ,diasautorizados"
        consulta += " ,fechainicio"
        consulta += " ,descripcion"
        consulta += " ,incapacidadinicial"
        consulta += " ,ramoseguro"
        consulta += " ,tiporiesgo"
        consulta += " ,numerocaso"
        consulta += " ,fincaso"
        consulta += " ,porcentajeincapacidad"
        consulta += " ,controlmaternidad"
        consulta += " ,nombremedico"
        consulta += " ,matriculamedico"
        consulta += " ,circunstancia"
        consulta += " ,timestamp"
        consulta += " ,controlincapacidad"
        consulta += " ,secuelaconsecuencia"
        consulta += " )"
        consulta += " VALUES("
        consulta += " " + Incapacidad.PIncapacidades.PIncidenciaIDNP.ToString
        consulta += " ," + Incapacidad.PColaborador.PColaboradoridNP.ToString
        consulta += " ,'" + Incapacidad.PIncapacidades.PIncapacidadFolio.ToString + "'"
        consulta += " ," + Incapacidad.PIncapacidades.PIncapacidadDiasAutorizados.ToString
        consulta += " ,'" + Incapacidad.PIncapacidades.PIncapacidadFechaInicio + "'"
        'consulta += " ,'" + Incapacidad.PIncapacidades.PIncapacidadFechaFin + "'"
        consulta += " ,'" + Incapacidad.PIncapacidades.PIncapacidadDescripcion.ToString + "'"
        consulta += " ,''" 'Incapacidad inicial?
        consulta += " ,'" + Incapacidad.PIncapacidades.PRamoDelSeguroNP.ToString + "'"
        consulta += " ,'" + Incapacidad.PIncapacidades.PTipoRiesgoNP.ToString + "'"
        consulta += " ,0" 'Numero caso
        consulta += " ,'0'" 'fin caso
        consulta += " ,0" 'porcentaje incapacidad
        consulta += " ,'" + Incapacidad.PIncapacidades.PTipoMaternidadNP.ToString + "'"
        consulta += " ,NULL" 'nombre medico
        consulta += " ,NULL" 'matricula medico
        consulta += " ,''" 'circunstancia
        consulta += " ,(SELECT GETDATE())"
        consulta += " ," + Incapacidad.PIncapacidades.PControlIncapacidadIDNP.ToString 'control incapacidad
        consulta += " ," + Incapacidad.PIncapacidades.PSecuelaIDNP.ToString ' secuela consecuencia
        consulta += " )"
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Function PeriodoIncapacidad(ByVal FechaIncapacidad As DateTime, ByVal BD As String, ByVal Servidor As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""
        Consulta += " SELECT * FROM [" + Servidor.ToString.Trim + "].[" + BD.ToString.Trim + "].[dbo].[nom10002]"
        Consulta += " WHERE'" + FechaIncapacidad + "'"
        Consulta += " BETWEEN fechainicio and fechafin"
        Return operaciones.EjecutaConsulta(Consulta)

    End Function

    Public Sub ReplicarIncapacidadesInsert2(ByVal Incapacidad As Entidades.IncapacidadesReplicar, ByVal BD As String, ByVal Servidor As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += "  INSERT INTO [" + Servidor.ToString.Trim + "].[" + BD.ToString.Trim + "].[dbo].[nom10010]"
        consulta += " ("
        consulta += " idPeriodo"
        consulta += " ,idEmpleado"
        consulta += " ,idtipoincidencia"
        consulta += " ,idtarjetaincapacidad"
        consulta += " ,idtcontrolvacaciones"
        consulta += " ,fecha"
        consulta += " ,valor"
        consulta += " ,timestamp"
        consulta += " )"
        consulta += " VALUES"
        consulta += " ("
        consulta += " " + Incapacidad.PIncapacidades.PIncapacidadPeriodo.ToString
        consulta += " ," + Incapacidad.PColaborador.PColaboradoridNP.ToString
        consulta += " ," + Incapacidad.PIncapacidades.PIncidenciaIDNP.ToString
        consulta += " ," + Incapacidad.PIncapacidades.PTarjetaIncapacidadID.ToString
        consulta += " ,NULL"
        consulta += " ,'" + Incapacidad.PIncapacidades.PIncapacidadFechaInicio.ToShortDateString + "'"
        consulta += " ,1"
        consulta += " ,(SELECT GETDATE())"
        consulta += " )"
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub ActualizarReplicar(ByVal idIncapacidad As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " UPDATE Nomina.Incapacidades"
        consulta += " SET inc_replicadonominpaq='TRUE'"
        consulta += " where inc_incapacidadid =" + idIncapacidad.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub


    Public Function TipoIncicendia(ByVal BD As String, ByVal Servidor As String)
        Dim opeaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += "SELECT * from [" + Servidor.ToString.Trim + "].[" + BD.ToString + "].[dbo].[nom10022]"
        Return opeaciones.EjecutaConsulta(consulta)
    End Function

    Public Function UltimaIncapacidad(ByVal BD As String, ByVal Servidor As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT top 1 * FROM [" + Servidor.ToString.Trim + "].[" + BD.ToString + "].[dbo].[nom10018]"
        consulta += " order by  idtarjetaincapacidad DESC "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    
End Class
