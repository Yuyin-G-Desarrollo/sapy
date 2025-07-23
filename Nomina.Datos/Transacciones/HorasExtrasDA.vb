Imports System.Data.SqlClient

Public Class HorasExtrasDA

    Public Function SemenaNominaActiva(ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.PeriodosNomina where pnom_stPeriodoNomina = 'A' and pnom_NaveId=" + Naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function CalculoHorasExtras(ByVal FechaInicio As Date, ByVal FechaTope As Date, ByVal IDColaborador As Int32, ByVal idHorario As Int32, ByVal Dia As Int32) As DataTable
        Try
            Dim operaciones As New Persistencia.OperacionesProcedimientos
            Dim consulta As String = "Exec ControlAsistencia.SP_CalculandoHorasExtras '" + FechaInicio.ToShortDateString + "','" + FechaTope.ToShortDateString + "'," + IDColaborador.ToString + "," + idHorario.ToString + "," + Dia.ToString
            Return operaciones.EjecutaConsulta(consulta)
        Catch ex As Exception

        End Try

    End Function




    Public Function RetardosFaltas(ByVal PeriodoNomina As Int32, ByVal Colaboradorid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consultas As String = "select * from ControlAsistencia.CorteChecador where ccheck_periodo_id = " + PeriodoNomina.ToString + " and ccheck_colaborador = " + Colaboradorid.ToString
        Return operaciones.EjecutaConsulta(consultas)
    End Function


    Public Function ValidarHorasExtras(ByVal ColaboradorID As Int32, ByVal PeriodoNomina As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from ControlAsistencia.CorteHorasExtra where phex_periodonominaid = " + PeriodoNomina.ToString + " and phex_colaboradorid=" + ColaboradorID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub AutorizarHorasExtras(ByVal HorasExtras As Entidades.HorasExtras)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparamestros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@periodoNomina"
        parametro.Value = HorasExtras.PPeriodo
        listaparamestros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = HorasExtras.PColaboradorid
        listaparamestros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@horasperiodo"
        parametro.Value = HorasExtras.PHorasExtrasPeriodo
        listaparamestros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@monto"
        parametro.Value = HorasExtras.PMonto
        listaparamestros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioCreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparamestros.Add(parametro)
        parametro = New SqlParameter
        operaciones.EjecutarConsultaSP("ControlAsistencia.SP_SolicitudesHorasExtras", listaparamestros)
    End Sub

End Class
