Public Class CorteNominaRealBU

    Public Sub GuardarCorteNomina(ByVal nomina As Entidades.CorteNominaReal)
        Dim objNomina As New Datos.CorteNominaRealDA
        objNomina.GuardarCorteNomina(nomina)
    End Sub


    Public Sub CambiarSemanaNomina(ByVal Nave As Entidades.CorteNominaReal)
        Dim objNomina As New Datos.CorteNominaRealDA
        objNomina.CambiarSemanaNomina(Nave)
    End Sub

    Public Sub LiquidarGratificaciones(ByVal Gratificaciones As Entidades.CalcularNominaReal)
        Dim objNomina As New Datos.CorteNominaRealDA
        objNomina.LiquidarGratificaciones(Gratificaciones)
    End Sub

    Public Function obtenerDescripcionGratificaciones(ByVal colaboradorID As String, ByVal periodonomina As Integer) As DataTable
        Dim objDA As New Datos.CorteNominaRealDA
        Return objDA.obtenerDescripcionGratificaciones(colaboradorID, periodonomina)
    End Function

    Public Function obtenerNaveIDsicy(ByVal naveID As Integer) As DataTable
        Dim objDA As New Datos.CorteNominaRealDA
        Return objDA.obtenerNaveIDsicy(naveID)
    End Function

    Public Function ObtenerDatosCorreos(Nave As Entidades.Naves, Accion As Integer, Optional NaveDestinoID As Integer = 0) As DataTable
        Dim objDA As New Datos.CorteNominaRealDA
        Try
            Return objDA.ObtenerDatosCorreos(Nave, Accion, NaveDestinoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarReporteGeneralDeducciones(ByVal IdPeriodo As Integer)
        Dim objDA As New Datos.CorteNominaRealDA
        objDA.GuardarReporteGeneralDeducciones(IdPeriodo)
    End Sub

    Public Sub GuardarReportePrestamos(ByVal IdPeriodo As Integer)
        Dim objDA As New Datos.CorteNominaRealDA
        objDA.GuardarReportePrestamos(IdPeriodo)
    End Sub

    Public Function GuardarNominaReal(ByVal nominaColaborador As Entidades.CierreNominaReal) As String
        Dim objDA As New Datos.CorteNominaRealDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.GuardarNominaReal(nominaColaborador)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            resultado = dtResultado.Rows(0).Item("mensaje")
        End If

        Return resultado
    End Function

    Public Sub GuardarBitacoraError(ByVal colaboradorId As Integer, ByVal IdPeriodo As Integer, ByVal Proceso As String, ByVal mensajeError As String)
        Dim objDA As New Datos.CorteNominaRealDA
        objDA.GuardarBitacoraError(colaboradorId, IdPeriodo, Proceso, mensajeError)
    End Sub

End Class
