Public Class ComisionesBU
    Public Function consultarPeriodoNomina(ByVal patronId As Integer) As DataTable
        Dim objDatos As New Datos.ComisionesDA
        Return objDatos.consultarPeriodoNomina(patronId)
    End Function

    Public Function consultarColaboradoresAltaComision(ByVal patronId As Integer) As DataTable
        Dim objDatos As New Datos.ComisionesDA
        Return objDatos.consultarColaboradoresAltaComision(patronId)
    End Function

    Public Function validaEstatusPeriodoNominaFiscal(ByVal periodoid As Integer) As Boolean
        Dim objDAtos As New Datos.ComisionesDA
        Return objDAtos.validaEstatusPeriodoNominaFiscal(periodoid)
    End Function

    Public Function guardarComisiones(ByVal comision As Entidades.ComisionMensual) As String
        Dim objDatos As New Datos.ComisionesDA
        Dim dtResultado As New DataTable
        Dim resultado As String = ""

        dtResultado = objDatos.guardarComisiones(comision)

        If dtResultado.Rows.Count > 0 Then
            resultado = dtResultado.Rows(0).Item("mensaje")
        End If

        Return resultado

    End Function

    'Public Function obtenerPorcentajePatron(ByVal patronid As Integer) As String
    '    Dim objDatos As New Datos.ComisionesDA
    '    Dim dtResultado As New DataTable
    '    Dim resultado As String = ""

    '    dtResultado = objDatos.obtenerPorcentajePatron(patronid)

    '    If dtResultado.Rows.Count > 0 Then
    '        If dtResultado.Rows(0).Item("patr_porcentajecomisiones") > 0 Then
    '            resultado = String.Format("{0:P}", dtResultado.Rows(0).Item("patr_porcentajecomisiones"))
    '        End If
    '    End If
    '    Return resultado

    'End Function

    Public Function obtenerMaximoComision(ByVal colaboradorId As Integer) As DataTable
        Dim objDatos As New Datos.ComisionesDA
        'Dim dtResultado As New DataTable
        'Dim resultado As String = ""

        Return objDatos.obtenerMaximoComision(colaboradorId)

        'If dtResultado.Rows.Count > 0 Then
        '    If dtResultado.Rows(0).Item("cono_maximocomisiones") > 0 Then
        '        resultado = String.Format("{0:C}", dtResultado.Rows(0).Item("cono_maximocomisiones"))
        '    End If
        'End If
        'Return resultado

    End Function

    Public Function consultarComisionesMensuales(ByVal patronId As Integer, ByVal periodoId As Integer, ByVal rango As Boolean, ByVal fechaini As Date, ByVal fechafin As Date, ByVal colaboradoresid As String, ByVal estatus As Integer) As DataTable
        Dim objDatos As New Datos.ComisionesDA
        Return objDatos.consultarComisionesMensuales(patronId, periodoId, rango, fechaini, fechafin, colaboradoresid, estatus)
    End Function

    Public Function obtenerComisionModificar(ByVal comisionId As Integer) As Entidades.ComisionMensual
        Dim objResult As Entidades.ComisionMensual = Nothing
        Dim objDatos As New Datos.ComisionesDA
        Dim dtResultado As New DataTable

        dtResultado = objDatos.obtenerComisionModificar(comisionId)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            objResult = New Entidades.ComisionMensual
            With objResult
                .PComisionId = dtResultado.Rows(0).Item("cmnf_comisionid")
                .PPatronId = dtResultado.Rows(0).Item("cmnf_patronid")
                .PPeriodoId = dtResultado.Rows(0).Item("cmnf_periodoid")
                .PColaboradorId = dtResultado.Rows(0).Item("cmnf_colaboradorid")
                .PMontoComision = dtResultado.Rows(0).Item("cmnf_montocomision")
                .PMesComision = dtResultado.Rows(0).Item("cmnf_mes")
                .PAnioComision = dtResultado.Rows(0).Item("cmnf_anio")
            End With
        End If

        Return objResult
    End Function

    Public Function validaExisteComision(ByVal colaboradorId As Integer, ByVal mes As Integer, ByVal anio As Integer) As Boolean
        Dim objDAtos As New Datos.ComisionesDA
        Return objDAtos.validaExisteComision(colaboradorId, mes, anio)
    End Function

    Public Function obtenerEstatusComisiones() As DataTable
        Dim objDatos As New Datos.ComisionesDA
        Return objDatos.obtenerEstatusComisiones
    End Function

    Public Function cancelarComisiones(ByVal comisionId As Integer, ByVal usuarioCancela As Integer) As String
        Dim objDatos As New Datos.ComisionesDA
        Dim dtResultado As New DataTable
        Dim resultado As String = ""

        dtResultado = objDatos.cancelarComisiones(comisionId, usuarioCancela)

        If dtResultado.Rows.Count > 0 Then
            resultado = dtResultado.Rows(0).Item("mensaje")
        End If

        Return resultado

    End Function
End Class
