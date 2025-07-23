Public Class CorteChecadorBU

    Public Sub guardarCorteChecador(ByVal corteChecador As Entidades.CorteChecador, ByVal faltasNuevoIngreso As Double)

        Dim objcorteChecador As New Datos.CorteChecadorDA

        objcorteChecador.guardarCorteChecador(corteChecador, faltasNuevoIngreso)

    End Sub

    Public Function consultar_ResumenCorteChecador(ByVal PeriodoNomID As Integer, ByVal colaboradorID As Integer, ByVal resultado As Integer, ByVal bandera As Integer) As Integer

        Dim objDA As New Nomina.Datos.CorteChecadorDA
        Dim tabla As New DataTable
        tabla = objDA.consultar_ResumenCorteChecador(PeriodoNomID, colaboradorID, resultado, bandera)

        consultar_ResumenCorteChecador = 0
        For Each row As DataRow In tabla.Rows
            consultar_ResumenCorteChecador = CInt(row("Resultado"))
        Next

    End Function

    Public Function Consultar_Incentivos_Registro_Excepcion(ByVal PeriodoNomID As Integer, ByVal colaboradorID As Integer) As List(Of Boolean)

        Dim objDA As New Nomina.Datos.CorteChecadorDA
        Dim tabla As New DataTable
        tabla = objDA.Consultar_Incentivos_Registro_Excepcion(PeriodoNomID, colaboradorID)

        Dim PyA As Boolean = True
        Dim CdA As Boolean = True
        'Dim incentivos As New List(Of Boolean)
        For Each row As DataRow In tabla.Rows
            ''regexc_puntualidad_asistencia	regexc_caja_ahorro
            If CBool(row("regexc_puntualidad_asistencia")) Then
                PyA = True
            Else
                PyA = False
                Exit For
            End If
        Next

        For Each row As DataRow In tabla.Rows
            ''regexc_puntualidad_asistencia	regexc_caja_ahorro
            If CBool(row("regexc_caja_ahorro")) Then
                CdA = True
            Else
                CdA = False
                Exit For
            End If
        Next

        'incentivos.Add(PyA)
        'incentivos.Add(CdA)

        Consultar_Incentivos_Registro_Excepcion = New List(Of Boolean)

        Consultar_Incentivos_Registro_Excepcion.Insert(0, PyA)
        Consultar_Incentivos_Registro_Excepcion.Insert(1, CdA)




    End Function


End Class
