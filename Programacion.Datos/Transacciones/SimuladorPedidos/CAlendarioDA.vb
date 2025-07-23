Imports System.Data.SqlClient

Public Class CAlendarioDA
    Public Function TablaAños() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT DISTINCT top 15 cale_año Año from Programacion.Calendario  where cale_año>= datepart(year,getdate()) order by 1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function TablaSemanas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT DISTINCT cast(cale_año as varchar) + '-' + cast(cale_semana as varchar) Semana,cale_año,cale_semana   from Programacion.Calendario where cale_fecha >=getdate() and cale_fecha <=getdate()+360 ORDER BY cale_año,cale_semana"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function TablaNaveAño(naveID As Int32, Año As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select nave_nombre Nave,caln_fecha Fecha,datename(dw,caln_fecha) Dia,datepart(wk,caln_fecha) Semana,caln_dias Dias,caln_naveID id_nave from Programacion.CalendarioNaves inner JOIN Framework.Naves on nave_naveid = caln_naveID where "
        If Not naveID = 0 Then
            consulta += " caln_naveID=" & naveID.ToString & " and"
        End If
        consulta += " datepart(year,caln_fecha)=" & Año.ToString & " ORDER by nave_nombre, caln_fecha"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub agregarAnioCalendario(ByVal nave As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inicio"
        parametro.Value = fechaInicio.ToShortDateString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "final"
        parametro.Value = fechaFin.ToShortDateString
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Programacion.sp_CalendarioNaveCrearAño", listaParametros)
    End Sub
    Public Sub actualizarDia(ByVal dia As String, ByVal fecha As Date, ByVal nave As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "UPDATE programacion.calendarioNaves set caln_dias = " + dia.ToString + " Where  caln_fecha= '" + fecha.ToShortDateString + "' and caln_naveID = " + nave.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub
    Public Sub actualizarDiaNaves(ByVal dia As String, ByVal fecha As Date)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "UPDATE programacion.calendarioNaves set caln_dias = " + dia.ToString + " Where  caln_fecha= '" + fecha.ToShortDateString + "'"
        operaciones.EjecutaConsulta(consulta)
    End Sub
End Class
