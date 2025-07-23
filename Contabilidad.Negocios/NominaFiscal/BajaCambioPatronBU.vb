Public Class BajaCambioPatronBU
    Public Function obtenerListaColaboradores(ByVal patronId As Integer, ByVal nombre As String) As DataTable
        Dim objDatos As New Datos.BajaCambioPatronDA
        Return objDatos.obtenerListaColaboradores(patronId, nombre)
    End Function

    Public Function obtenerFechasMovimientos(ByVal patronDestinoId As Integer) As DataTable
        Dim objDatos As New Datos.BajaCambioPatronDA
        Return objDatos.obtenerFechasMovimientos(patronDestinoId)
    End Function

    'Public Function copiarColaborador(ByVal cambioColaborador As Entidades.ColaboradorCambioPatron) As String
    '    Dim objDatos As New Datos.BajaCambioPatronDA
    '    Dim dtResultado As New DataTable
    '    Dim resultado As String = String.Empty

    '    dtResultado = objDatos.copiarColaborador(cambioColaborador)
    '    If Not dtResultado Is Nothing Then
    '        resultado = dtResultado.Rows(0)("mensaje").ToString
    '    End If

    '    Return resultado
    'End Function

    Public Function copiarColaborador(ByVal cambioColaborador As Entidades.ColaboradorCambioPatron) As DataTable
        Dim objDatos As New Datos.BajaCambioPatronDA
        Return objDatos.copiarColaborador(cambioColaborador)
    End Function

    Public Function obtenerDatosAlta(ByVal colaboradorId As Integer, ByVal patronId As Integer) As DataTable
        Dim objDatos As New Datos.BajaCambioPatronDA
        Return objDatos.obtenerDatosAlta(colaboradorId, patronId)
    End Function

    Public Function consultaPatrones(ByVal idUsuario As Int32, ByVal idNave As Int32, ByVal idPatron As Int32) As DataTable
        Dim objDatos As New Datos.BajaCambioPatronDA
        Dim dtListado As New DataTable

        dtListado = objDatos.consultaPatrones(idUsuario, idNave, idPatron)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 0 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function validaFechaCierreNominaReal(ByVal idNave As Int32) As Boolean
        Dim objDatos As New Datos.BajaCambioPatronDA
        Dim dtDatos As New DataTable
        Dim blnResult As Boolean = False

        dtDatos = objDatos.validaFechaCierreNominaReal(idNave)
        If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
            blnResult = True
        End If

        Return blnResult
    End Function
End Class
