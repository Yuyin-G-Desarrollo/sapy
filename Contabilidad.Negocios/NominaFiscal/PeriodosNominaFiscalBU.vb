Public Class PeriodosNominaFiscalBU
    Public Function VerificaPeriodo(ByVal patronId As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal periodoId As Integer) As Boolean

        Dim objDA As New Datos.PeriodosNominaFiscalDA
        Dim dtPeriodos As DataTable
        Dim blnReturn As Boolean = False

        dtPeriodos = objDA.verificarPeriodo(patronId, fechaInicio, fechaFin, periodoId)

        If Not IsNothing(dtPeriodos) AndAlso dtPeriodos.Rows.Count > 0 Then
            blnReturn = True
        End If
        Return blnReturn

    End Function

    Public Function cargarPatrones() As DataTable
        Dim objUtil As New UtileriasBU
        Return objUtil.consultarPatronEmpresa
    End Function

    Public Function obtenerListaEstatus() As DataTable
        Dim objUtil As New Datos.PeriodosNominaFiscalDA
        Return objUtil.obtenerListaEstatus
    End Function

    Public Function consultarPeriodos(ByVal patronId As Integer, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal estatus As Integer) As DataTable
        Dim objUtil As New Datos.PeriodosNominaFiscalDA
        Return objUtil.consultarPeriodos(patronId, fechaInicio, fechaFin, estatus)
    End Function

    Public Function calcularPeriodos(ByVal patronId As Integer, ByVal semana As Integer, ByVal fechaIni As Date, ByVal fechaFin As Date, ByVal fechaPago As Date, ByVal todos As Boolean) As DataTable
        Dim objDA As New Datos.PeriodosNominaFiscalDA
        Return objDA.calcularPeriodos(patronId, semana, fechaIni, fechaFin, fechaPago, todos)
    End Function

    Public Function AltaEdicionPeriodo(ByVal periodo As Entidades.PeriodoNominaFiscal) As String
        Dim objDa As New Datos.PeriodosNominaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDa.AltaEdicionPeriodo(periodo)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado

    End Function
    Public Function EliminarPeriodo(ByVal periodoId As Integer) As String
        Dim objDa As New Datos.PeriodosNominaFiscalDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDa.EliminarPeriodo(periodoId)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado

    End Function

    Public Function consultarPeriodoEditar(ByVal periodoId As Integer) As DataTable
        Dim objUtil As New Datos.PeriodosNominaFiscalDA
        Return objUtil.consultarPeriodoEditar(periodoId)
    End Function

    Public Function validaEstatusPeriodo(ByVal periodoId As Integer) As Boolean

        Dim objDA As New Datos.PeriodosNominaFiscalDA
        Dim dtPeriodos As DataTable
        Dim blnReturn As Boolean = True

        dtPeriodos = objDA.validaEstatusPeriodo(periodoId)

        If Not IsNothing(dtPeriodos) AndAlso dtPeriodos.Rows.Count > 0 Then
            If dtPeriodos.Rows(0)("registros") > 0 Then
                blnReturn = False
            End If
        End If
        Return blnReturn

    End Function

End Class
