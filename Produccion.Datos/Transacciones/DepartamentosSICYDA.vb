Imports Persistencia
Imports System.Data.SqlClient
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class DepartamentosSICYDA

    Public Function ListaDepartamentosSegunNaves(ByVal idnave As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY

        Dim consulta As String = "SELECT cnd.IdConfiguracion as IdDepartamento, d.Departamento  FROM LotesAvancesConfigNaveDepto cnd " & _
                                "INNER JOIN nmaDepartamentos d ON cnd.IdNave=d.Nave AND cnd.IdDepto=d.IdDepto " & _
                                "WHERE cnd.Estatus='A' AND cnd.IdNave=" & idnave & " " & _
                                "ORDER BY cnd.Orden"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaDepartamentosSegunNavesProduccion(ByVal idnave As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT cnd.IdConfiguracion as IdDepartamento, d.Departamento,cnd.Color, (select SUM(cndSum.DiasProceso) from LotesAvancesConfigNaveDepto as cndSum"
        consulta += " INNER JOIN nmaDepartamentos d ON cnd.IdNave=d.Nave AND cnd.IdDepto=d.IdDepto WHERE cnd.Estatus='A' AND cnd.IdNave=" + idnave.ToString + " and cndSum.Orden<=cnd.Orden)"
        consulta += " as DiasProceso FROM LotesAvancesConfigNaveDepto cnd INNER JOIN nmaDepartamentos d ON cnd.IdNave=d.Nave AND cnd.IdDepto=d.IdDepto "
        consulta += " WHERE cnd.Estatus='A' AND cnd.IdNave=" + idnave.ToString + " ORDER BY cnd.Orden"

        Return operaciones.EjecutaConsulta(consulta)

    End Function



    Public Function ListaCelulasSegunDepartamentoSICY(ByVal idnave As Integer, ByVal idConfiguracion As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim consulta As String = "  select Celula from LotesAvancesConfigNaveDepto as a join nmaCelulas as b on (a.IdDepto=b.IdDepto) where b.Nave=" + idnave.ToString + " and a.IdConfiguracion=" + idConfiguracion.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function







    Public Function BuscarValoresResumenPrograma(ByVal vNave As Int32, ByVal vFecha As Date, ByVal vTipo As String, ByVal vValor As String) As Long
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim tabla As New DataTable
        Dim lsSQL As String = ""
        BuscarValoresResumenPrograma = 0

        Select Case vTipo
            Case "Pares"
                lsSQL = "SELECT ISNULL(SUM(l.Pares),0) as Valor FROM Lotes l WHERE l.Nave = " & vNave & " and l.Lote<90000 AND l.Fecha='" & FormatDateTime(vFecha, DateFormat.ShortDate) & "'"
            Case "Lotes"
                lsSQL = "SELECT ISNULL(COUNT(l.Lote),0) as Valor FROM Lotes l WHERE l.Nave = " & vNave & " and l.Lote<90000 AND l.Fecha='" & FormatDateTime(vFecha, DateFormat.ShortDate) & "'"
            Case "Depto"
                lsSQL = "SELECT ISNULL(SUM(l.Pares),0) as Valor FROM Lotes l INNER JOIN LotesAvances la ON l.Año = la.Año AND l.Nave = la.Nave AND l.Lote = la.Lote " & _
                              "WHERE l.Lote<90000 AND la.Estado='C' AND l.Nave = " & vNave & " AND l.Fecha='" & FormatDateTime(vFecha, DateFormat.ShortDate) & "' AND la.IdConfiguracion = " & vValor
            Case "Embarque"
                lsSQL = "SELECT ISNULL(SUM(l.Pares),0) as Valor FROM Lotes l WHERE l.Lote<90000 AND l.Fecha_Salida IS NOT NULL AND l.Nave = " & vNave & " AND l.Fecha='" & FormatDateTime(vFecha, DateFormat.ShortDate) & "'"
        End Select

        tabla = operaciones.EjecutaConsulta(lsSQL)

        If tabla.Rows.Count > 0 Then
            BuscarValoresResumenPrograma = tabla(0)("Valor")
        End If

    End Function

    Public Function ListaProgramasNave(ByVal idnave As Integer, ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataTable
        Dim opereciones As New OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT DISTINCT Fecha FROM Lotes " &
                                 "WHERE Nave = " & idnave & " AND Fecha BETWEEN '" & FormatDateTime(FechaInicial, DateFormat.ShortDate) & "' AND '" & FormatDateTime(FechaFinal, DateFormat.ShortDate) & "' " &
                                 "ORDER BY Fecha"

        Return opereciones.EjecutaConsulta(consulta)

    End Function
    Public Function ListaCelulasSegunNaveDepto(ByVal idnave As Integer, ByVal iddepto As Integer) As DataTable
        Dim opereciones As New OperacionesProcedimientosSICY
        Dim consulta As String
            consulta = "SELECT c.IdCelula, c.Celula FROM LotesAvancesConfigNaveDepto cnd " & _
                                "INNER JOIN nmaDepartamentos d ON cnd.IdNave=d.Nave AND cnd.IdDepto=d.IdDepto " & _
                                "INNER JOIN nmaCelulas c ON d.IdDepto=c.IdDepto AND cnd.IdNave=c.Nave  " & _
                                "WHERE c.HabilitadaAvanProd='1' AND cnd.IdNave=" & idnave & " AND cnd.IdConfiguracion=" & iddepto & " " & _
                                "ORDER BY cnd.Orden, c.Celula "
        Return opereciones.EjecutaConsulta(consulta)

    End Function
    Public Function ListaCelulasSegunNaveDepto2(ByVal idnave As Integer, ByVal iddepto As Integer, ByVal conDep As Boolean) As DataTable
        Dim opereciones As New OperacionesProcedimientosSICY
        Dim consulta As String
        If conDep Then
            consulta = "SELECT c.IdCelula, c.Celula FROM LotesAvancesConfigNaveDepto cnd " & _
                                "INNER JOIN nmaDepartamentos d ON cnd.IdNave=d.Nave AND cnd.IdDepto=d.IdDepto " & _
                                "INNER JOIN nmaCelulas c ON d.IdDepto=c.IdDepto AND cnd.IdNave=c.Nave  " & _
                                "WHERE c.HabilitadaAvanProd='1' AND cnd.IdNave=" & idnave & " AND cnd.IdConfiguracion=" & iddepto & " " & _
                                "ORDER BY cnd.Orden, c.Celula "
        Else
            consulta = "SELECT c.IdCelula, c.Celula FROM LotesAvancesConfigNaveDepto cnd " & _
                                "INNER JOIN nmaDepartamentos d ON cnd.IdNave=d.Nave AND cnd.IdDepto=d.IdDepto " & _
                                "INNER JOIN nmaCelulas c ON d.IdDepto=c.IdDepto AND cnd.IdNave=c.Nave  " & _
                                "WHERE c.HabilitadaAvanProd='1' AND cnd.IdNave=" & idnave & " " & _
                                "ORDER BY cnd.Orden, c.Celula "
        End If
        Return opereciones.EjecutaConsulta(consulta)

    End Function

    Public Function UbicarNave(ByVal idnave As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ("SELECT TOP 1 * FROM framework.naves ")
        consulta += " WHERE nave_navesicyid = " + CStr(idnave)

        Return operaciones.EjecutaConsulta(consulta)

    End Function






End Class
