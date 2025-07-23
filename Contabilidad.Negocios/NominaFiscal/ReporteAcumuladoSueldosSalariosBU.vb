Public Class ReporteAcumuladoSueldosSalariosBU
    Public Function consultarPatronEmpresaBU() As DataTable
        'Dim objDatos As New Datos.UtileriasDA
        Dim objDatos As New Datos.ReporteAcumuladoSueldosSalariosDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultarPatronEmpresaDA()
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function
    Public Function validarExistenciaBU(ByVal patronId As Int32, ByVal anio As Int32) As String
        Dim objDatos As New Datos.ReporteAcumuladoSueldosSalariosDA
        Dim dtDatos As New DataTable
        Dim resultado As String = String.Empty

        dtDatos = objDatos.validarExistenciaDA(patronId, anio)
        If Not dtDatos Is Nothing Then
            If dtDatos.Rows.Count > 0 Then
                resultado = dtDatos.Rows(0)("mensaje").ToString
            End If
        End If
        Return resultado
    End Function
    Public Function consultarDatosPatronBU(ByVal patronId As Int32, ByVal periodoDel As Int32, ByVal periodoAl As Int32)
        Dim dtDatosPatron As New DataTable
        Dim objDA As New Datos.ReporteAcumuladoSueldosSalariosDA

        dtDatosPatron = objDA.consultarDatosPatronDA(patronId, periodoDel, periodoAl)
        Return dtDatosPatron
    End Function

    Public Function mostrarAcumuladoBU(ByVal patronId As Int32, ByVal periodoDel As Int32, ByVal periodoAl As Int32, ByVal anio As Int32, ByVal nombre As String, ByVal colaboradorIds As String) As DataTable
        Dim dtAcumulado As New DataTable
        Dim objDA As New Datos.ReporteAcumuladoSueldosSalariosDA

        dtAcumulado = objDA.mostrarAcumuladoDA(patronId, periodoDel, periodoAl, anio, nombre, colaboradorIds)
        Return dtAcumulado
    End Function
    Public Function guardarCalculoBU(ByVal patronId As Int32, ByVal periodoDel As Int32, ByVal periodoAl As Int32, ByVal anio As Int32, ByVal nombre As String, ByVal colaboradorIds As String, ByVal accion As Int32) As String
        Dim dtAcumulado As New DataTable
        Dim objDA As New Datos.ReporteAcumuladoSueldosSalariosDA
        Dim resultado As String = String.Empty

        dtAcumulado = objDA.guardarCalculoDA(patronId, periodoDel, periodoAl, anio, nombre, colaboradorIds, accion)
        If Not resultado Is Nothing Then
            resultado = dtAcumulado.Rows(0)("mensaje").ToString
        End If
        Return resultado
    End Function



    Public Function consultarCalculoBU(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim objDatos As New Datos.ReporteAcumuladoSueldosSalariosDA
        Dim dtDatos As New DataTable

        dtDatos = objDatos.consultarCalculoDA(patronId, anio)
        Return dtDatos
    End Function
    'Public Function guardarCalculoBU(ByVal patronId As Int32, ByVal periodoDel As Int32, ByVal periodoAl As Int32, ByVal anio As Int32, ByVal nombre As String, ByVal colaboradorIds As String, ByVal accion As Int32) As String
    '    Dim objDA As New Datos.ReporteAcumuladoSueldosSalariosDA
    '    Dim dtResultado As New DataTable
    '    Dim resultado As String = String.Empty

    '    dtResultado = objDA.mostrarCalculoDA(patronId, periodoDel, periodoAl, anio, nombre, colaboradorIds, accion)
    '    If Not dtResultado Is Nothing Then
    '        If dtResultado.Rows.Count > 0 Then
    '            resultado = dtResultado.Rows(0)("mensaje").ToString
    '        End If
    '    End If

    '    Return resultado
    'End Function
    Public Function actualizarCalculoBU(ByVal patronId As Int32, ByVal anio As Int32, ByVal colaboradorid As Integer, ByVal exentocargado As String, ByVal gravadocargado As String, ByVal isrcargado As String) As DataTable
        Dim dtAcumulado As New DataTable
        Dim objDA As New Datos.ReporteAcumuladoSueldosSalariosDA

        dtAcumulado = objDA.actualizarCalculoDA(patronId, anio, colaboradorid, exentocargado, gravadocargado, isrcargado)
        Return dtAcumulado
    End Function
    Public Function autorizarCalculoBU(ByVal patronid As Int16, ByVal anio As Int32) As String
        Dim objDA As New Datos.ReporteAcumuladoSueldosSalariosDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.autorizarCalculoDA(patronid, anio)
        If Not resultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If
        Return resultado
    End Function
End Class
