Public Class AguinaldoVacacionesBU
    Public Function obtenerAniosPatron(ByVal patronId As Int32) As DataTable
        Dim objDA As New Datos.AguinaldoVacacionesDA
        Dim dtlista As New DataTable

        dtlista = objDA.obtenerAniosPatron(patronId)
        If Not dtlista Is Nothing Then
            If dtlista.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtlista.NewRow
                dtRow("Anios") = ""
                dtlista.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtlista
    End Function

    Public Function consultarAguinaldosVacaciones(ByVal patronId As Int32, ByVal anio As Integer, ByVal metodo As Boolean) As DataTable
        Dim objDA As New Datos.AguinaldoVacacionesDA
        Return objDA.consultarAguinaldosVacaciones(patronId, anio, metodo)
    End Function

    Public Function validaAnioTimbrado(ByVal patronId As Int32, ByVal anio As Integer) As DataTable
        Dim objDA As New Datos.AguinaldoVacacionesDA
        Return objDA.validaAnioTimbrado(patronId, anio)
    End Function

    Public Function validaTimbreFiscalesCompletos(ByVal patronId As Int32, ByVal anio As Integer) As Boolean
        Dim objDA As New Datos.AguinaldoVacacionesDA
        Dim existenTimbres As Boolean = False
        Dim dtTimbres As New DataTable

        dtTimbres = objDA.validaTimbresFiscalesCompletos(patronId, anio)
        If dtTimbres.Rows.Count > 0 Then
            existenTimbres = dtTimbres.Rows(0).Item("faltanTimbres")
        End If

        Return existenTimbres
    End Function

    Public Sub calcularAguinaldoVacaciones(ByVal fechaCalculo As Date, ByVal patronId As Int32, ByVal porLey As Boolean, ByVal soloVacaciones As Int32)
        Dim objDA As New Datos.AguinaldoVacacionesDA
        objDA.calcularAguinaldoVacaciones(fechaCalculo, patronId, porLey, soloVacaciones)
    End Sub

    Public Function enviarTimbrar(ByVal patronId As Int32, ByVal anio As Integer, ByVal fechaPago As Date, ByVal soloVacaciones As Integer) As String
        Dim objDA As New Datos.AguinaldoVacacionesDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.enviarTimbrar(patronId, anio, fechaPago, soloVacaciones)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function altaVacacionesAguinaldos(ByVal idCaja As Integer, ByVal tipoSolicitud As String,
                                             ByVal importe As Double, ByVal beneficiario As String,
                                             ByVal observaciones As String, ByVal razonsocial As String) As String
        Dim objDA As New Datos.AguinaldoVacacionesDA
        Return objDA.altaVacacionesAguinaldos(idCaja, tipoSolicitud, importe, beneficiario, observaciones, razonsocial)
    End Function

    Public Function ConsultarCajaChicaPatron(ByVal patronId As Int32) As DataTable
        Dim objDA As New Datos.AguinaldoVacacionesDA
        Return objDA.ConsultarCajaChicaPatron(patronId)
    End Function
End Class