Imports Persistencia
Imports System.Data.SqlClient

Public Class CalculoNominaFiscalDA


    Public Function consultar_DatosBasicosColaboradores(ByVal naveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT codr_colaboradorid, codr_apellidopaterno, codr_apellidomaterno, codr_nombre, cono_salariodiario, cono_fechaaltaimss, ccheck_inasistencia, cono_infonavit, cono_infonavit_tipo, cono_infonavit_monto " &
                                " FROM Nomina.ColaboradorNomina AS a" &
                                " JOIN Nomina.Colaborador AS b ON a.cono_colaboradorid=b.codr_colaboradorid" &
                                " JOIN Nomina.ColaboradorLaboral AS c ON b.codr_colaboradorid=c.labo_colaboradorid" &
                                " JOIN ControlAsistencia.CorteChecador AS d ON b.codr_colaboradorid = d.ccheck_colaborador" &
                                " WHERE labo_naveid = " + naveID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function consultar_ConfiguracionNominaFiscal() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.ConfiguracionFiscalNomina"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function consultar_DatosCalculoSubsidio(ByVal salarioSemanal As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.RangosImpuestoSubsidioEmpleo" &
                                " WHERE rise_limiteinferior < " + salarioSemanal.ToString + "" &
                                " AND rise_limitesuperior > " + salarioSemanal.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function consultar_SubsidioEmpleo(ByVal salarioSemanal As Decimal) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.RangoSubsidioEmpleo" &
        " WHERE rase_limiteinferior < " + salarioSemanal.ToString + "" &
        " AND rase_limitesuperior > " + salarioSemanal.ToString + ""

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function consultar_SubsidioEmpleoRangoMayor() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT top 1 * FROM Nomina.RangosImpuestoSubsidioEmpleo ORDER BY rise_limiteinferior DESC"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function consultar_FactorIntegracion(ByVal anios As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.FactoresIntegracion WHERE fact_anios = " + anios.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function consultar_DiasIncapacidad(ByVal PeriodoNomID As Integer, ByVal colaboradorID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@PeriodoNomID AS INTEGER,
        '@departamentoID AS INTEGER,
        '@colaboradorID AS INTEGER,
        '@resultado AS INTEGER

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PeriodoNomID"
        parametro.Value = PeriodoNomID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorID"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_Consultar_Dias_Incapacidad", listaParametros)

    End Function

    'SELECT * FROM Nomina.FactoresIntegracion WHERE fact_anios = 3
    'SELECT top 1 * FROM Nomina.RangosImpuestoSubsidioEmpleo ORDER BY rise_limiteinferior DESC
End Class
