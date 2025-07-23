Imports System.Data.SqlClient

Public Class HistorialSalariosDA
    Public Sub InsertarSalarioDiario(ByVal idColaborador As Int32, ByVal SalarioDiario As Double)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Listaparametos As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = idColaborador
        Listaparametos.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "sueldodiario"
        parametro.Value = SalarioDiario
        Listaparametos.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("Nomina.SP_registro_sueldo_diario", Listaparametos)
    End Sub


    Public Function ListaHistorialSueldos(ByVal IDColaborador As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.HistorialSueldo where hist_idcolaborador=" + IDColaborador.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
