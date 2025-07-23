Public Class CorteNominaFiscalBU
    Public Function consultaCorteNomina(ByVal periodoId As Int32, ByVal patronid As Int32, ByVal nombre As String) As DataTable
        Dim dtCOrte As New DataTable
        Dim objDa As New Datos.CorteNominaFiscalDA

        dtCOrte = objDa.consultaCorteNomina(periodoId, patronid, nombre)

        Return dtCOrte
    End Function

    Public Function datosEmpresa(ByVal periodoId As Int32, ByVal patronid As Int32) As DataTable
        Dim dtEmpresa As New DataTable
        Dim objDa As New Datos.CorteNominaFiscalDA

        dtEmpresa = objDa.datosEmpresa(periodoId, patronid)

        Return dtEmpresa
    End Function

    Public Function obtnerTotalNominaFiscal(ByVal idPeriodoReal As Int32) As Double
        Dim dtTotales As New DataTable
        Dim objDa As New Datos.CorteNominaFiscalDA
        Dim total As Double = 0

        dtTotales = objDa.obtnerTotalNominaFiscal(idPeriodoReal)

        If dtTotales.Rows.Count > 0 Then
            total = dtTotales.Rows(0).Item("total")
        End If

        Return total
    End Function

    Public Function validaTimbreFiscalesCompletos(ByVal idPeriodo As Int32) As Boolean
        Dim existenTimbres As Boolean = False
        Dim dtTimbres As New DataTable
        Dim objDa As New Datos.CorteNominaFiscalDA

        dtTimbres = objDa.validaTimbreFiscalesCompletos(idPeriodo)

        If dtTimbres.Rows.Count > 0 Then
            existenTimbres = dtTimbres.Rows(0).Item("faltanTimbres")
        End If

        Return existenTimbres
    End Function

    Public Function obtenerConfiguracionPatron(ByVal patronId As Integer) As DataTable
        Dim objDa As New Datos.CorteNominaFiscalDA
        Return objDa.obtenerConfiguracionPatron(patronId)
    End Function
End Class
