Public Class ControlAsistenciaBU
    Public Function consultarPeriodoNomina(ByVal patronId As Integer) As DataTable
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Return objDatos.consultarPeriodoNomina(patronId)
    End Function

    Public Function obtenerPeriodoNominaActual(ByVal patronId As Integer) As Integer
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As Integer = 0

        dtResultado = objDatos.obtenerPeriodoNominaActual(patronId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CInt(dtResultado.Rows(0)("penof_periodonominafiscalId").ToString)
            End If
        End If

        Return resultado
    End Function

    Public Function obtenerPoliticasPremios(ByVal periodoId As Integer) As DataTable
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Return objDatos.obtenerPoliticasPremios(periodoId)
    End Function

    Public Function consultaTieneChecador(ByVal patronId As Integer) As Boolean
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = True

        dtResultado = objDatos.consultaTieneChecador(patronId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CBool(dtResultado.Rows(0)("patr_tieneChecador").ToString)
            End If
        End If

        Return resultado
    End Function

    Public Function validadExistenChecadas(ByVal patronId As Integer, ByVal periodoId As Integer) As Integer
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As Integer = 0

        dtResultado = objDatos.validadExistenChecadas(patronId, periodoId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CInt(dtResultado.Rows(0)("Registros").ToString)
            End If
        End If

        Return resultado
    End Function

    Public Function consultaChecadasPeriodoNomina(ByVal patronId As Integer, ByVal periodoNominaId As Integer) As DataTable
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Return objDatos.consultaChecadasPeriodoNomina(patronId, periodoNominaId)
    End Function

    Public Function consultaIncapacidadColaborador(ByVal colaboradorId As Integer, ByVal periodoNominaId As Integer) As DataTable
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Return objDatos.consultaIncapacidadColaborador(colaboradorId, periodoNominaId)
    End Function

    Public Function validaPeriodoGenerarChecadas(ByVal periodoNominaId As Integer) As Boolean
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validaPeriodoGenerarChecadas(periodoNominaId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("Resultado")
            End If
        End If

        Return resultado
    End Function

    Public Function generaRegistrosChecadas(ByVal patronId As Integer, ByVal eliminar As Boolean) As String
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.generaRegistrosChecadas(patronId, eliminar)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function generaFaltaRegistro(ByVal registroId As Integer, ByVal colaboradorId As Integer) As String
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.generaFaltaRegistro(registroId, colaboradorId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function generaRetardoRegistro(ByVal registroId As Integer, ByVal colaboradorId As Integer) As String
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.generaRetardoRegistro(registroId, colaboradorId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function validaCierreChecador(ByVal periodoNominaId As Integer) As String
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validaCierreChecador(periodoNominaId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("Resultado").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function generaCorteChecadorFiscal(ByVal periodoNominaId As Integer) As String
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.generaCorteChecadorFiscal(periodoNominaId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString
            End If
        End If

        Return resultado
    End Function

    Public Function obtenerPeriodoNominaFiscalPeriodo(ByVal periodoRealId As Integer) As Integer
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As Integer = 0

        dtResultado = objDatos.obtenerPeriodoNominaFiscalPeriodo(periodoRealId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = CInt(dtResultado.Rows(0)("PeriodoFiscalId").ToString)
            End If
        End If

        Return resultado
    End Function

    Public Function consultaPatronNave(ByVal naveId As Integer) As DataTable
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Return objDatos.consultaPatronNave(naveId)
    End Function

    Public Function consultaMovimientosPendientes(ByVal patronid As Integer, ByVal periodofiscalid As Integer, ByVal NaveId As Integer) As DataTable
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Return objDatos.consultaMovimientosPendientes(patronid, periodofiscalid, NaveId)
    End Function

    Public Function consultaFechasVacaciones(ByVal patronId As Integer, ByVal periodoNominaId As Integer) As DataTable
        Dim objDatos As New Datos.ControlAsistenciaFiscalDA
        Return objDatos.consultaFechasVacaciones(patronId, periodoNominaId)
    End Function
End Class
