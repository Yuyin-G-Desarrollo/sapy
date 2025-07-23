Public Class HorasExtrasBU
    Public Function SemanaActiva(ByVal Naveid As Int32) As Entidades.PeriodosNomina
        Dim ObjDa As New Datos.HorasExtrasDA
        Dim Tablaresultados As New DataTable
        Dim Semana As New Entidades.PeriodosNomina
        Tablaresultados = ObjDa.SemenaNominaActiva(Naveid)
        For Each row As DataRow In Tablaresultados.Rows
            Semana.FechaInicio = CDate(row("pnom_FechaInicial"))
            Semana.FechaFin = CDate(row("pnom_FechaFinal"))
            Semana.PPeriodoId = CInt(row("pnom_PeriodoNomId"))
        Next
        Return Semana

    End Function


    Public Function CalculoHorasExtras(ByVal FechaInicio As Date, ByVal FechaTope As Date, ByVal IDColaborador As Int32, ByVal idHorario As Int32, ByVal Dia As Int32) As Int32
        Dim objDA As New Datos.HorasExtrasDA
        Dim tabla As New DataTable
        tabla = objDA.CalculoHorasExtras(FechaInicio, FechaTope, IDColaborador, idHorario, Dia)
        Dim extras As New Int32
        Try
            For Each row As DataRow In tabla.Rows
                extras = CInt(row("MinutosExtrasTrabajados"))
            Next
        Catch ex As Exception

        End Try
      

        Return extras
    End Function

    Public Function Retardos(ByVal PeriodoNomina As Int32, ByVal ColaboradorId As Int32) As Entidades.HorasExtras
        Dim objDA As New Datos.HorasExtrasDA
        Dim tabla As New DataTable
        Dim Horas As Entidades.HorasExtras
        tabla = objDA.RetardosFaltas(PeriodoNomina, ColaboradorId)
        Dim extras As New Int32
        Try
            For Each row As DataRow In tabla.Rows
                Horas = New Entidades.HorasExtras
                Horas.PRetardosMenores = CInt(row("ccheck_retardo_menor"))
                Horas.PRetardosMayores = CInt(row("ccheck_retardo_mayor"))
                Horas.PFaltas = CInt(row("ccheck_inasistencia"))
            Next
        Catch ex As Exception

        End Try


        Return Horas
    End Function


    Public Sub AutorizarHorasExtras(ByVal HorasExtras As Entidades.HorasExtras)
        Dim objDA As New Datos.HorasExtrasDA
        objDA.AutorizarHorasExtras(HorasExtras)
    End Sub

    Public Function ValidacionHorasExtras(ByVal Colaboradorid As Int32, ByVal PeriodoNomina As Int32) As Boolean
        Dim objDA As New Datos.HorasExtrasDA
        Dim Tabla As New DataTable
        Tabla = objDA.ValidarHorasExtras(Colaboradorid, PeriodoNomina)
        If Tabla.Rows.Count > 0 Then
            ValidacionHorasExtras = True
        Else

            ValidacionHorasExtras = False
        End If
    End Function
  
End Class
