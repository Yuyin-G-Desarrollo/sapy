Public Class RealesFiscalesBU

    Public Function LimpiarColaboradoresNoEncontradosNomina(ByVal NaveID As Integer, ByVal Año As Integer) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.LimpiarColaboradoresNoEncontradosNomina(NaveID, Año)
    End Function

    Public Function getNaves() As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.getNaves()
    End Function
    Public Function getDatos(ByVal idNave As Integer, ByVal year As Integer, ByVal Colaborador As String, ByVal soloVacaciones As Int32) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.getDatos(idNave, year, Colaborador, soloVacaciones)
    End Function
    Public Function getDatosReporteVacAgui(ByVal idNave As Integer, ByVal year As Integer, ByVal soloVacaciones As Integer) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.getDatosReporteVacAgui(idNave, year, soloVacaciones)
    End Function
    Public Function countVacaciones(ByVal idNave As Integer, ByVal year As Integer) As Integer
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.countVacaciones(idNave, year)
    End Function
    Public Function countAguinaldos(ByVal idNave As Integer, ByVal year As Integer) As Integer
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.countAguinaldos(idNave, year)
    End Function
    Public Function getidCaja(ByVal idNave As Integer) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.getidCaja(idNave)
    End Function
    Public Function updateAguinaldo(ByVal idAguinaldo As Integer, ByVal totalFiscal As Double) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.updateAguinaldo(idAguinaldo, totalFiscal)
    End Function
    Public Function updateVacaciones(ByVal idVacaciones As Integer, ByVal totalFiscal As Double) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.updateVacaciones(idVacaciones, totalFiscal)
    End Function
    Public Function altaVacacionesAguinaldos(ByVal idCaja As Integer, ByVal tipoSolicitud As String, ByVal importe As Double,
                                                ByVal beneficiario As String, ByVal observaciones As String, ByVal razonsocial As String) As String
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.altaVacacionesAguinaldos(idCaja, tipoSolicitud, importe, beneficiario, observaciones, razonsocial)
    End Function
    Public Function validarTotalFiscales(ByVal anio As String, ByVal idNave As String) As Double
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.validarTotalFiscales(anio, idNave)
    End Function

    Public Function getTotalExternos(ByVal anio As String, ByVal idNave As String) As Integer
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.getTotalExternos(idNave, anio)
    End Function

    Public Function validarTotalFiscales2(ByVal anio As String, ByVal idNave As String) As Boolean
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.validarTotalFiscales2(anio, idNave)
    End Function
    Public Function insertarExcluidos(ByVal nombre As String, ByVal Materno As String, ByVal Paterno As String, ByVal TotalFiscal As Double, ByVal anio As String, ByVal idNave As String) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.insertarExcluidos(nombre, Materno, Paterno, TotalFiscal, anio, idNave)
    End Function
    Public Function getExcluidos(ByVal anio As String, ByVal idNave As String) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.getExcluidos(anio, idNave)
    End Function
    Public Function eliminarExcluidos(ByVal anio As String, ByVal idNave As String) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.eliminarExcluidos(anio, idNave)
    End Function

    'Prueba 
    Public Function getExcluidos2(ByVal idNave As String) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.getExcluidos2(idNave)
    End Function


    Public Function ConsultaAguinaldoVacacionesNave(ByVal Año As Integer) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.ConsultaAguinaldoVacacionesNave(Año)
    End Function


    Public Function ObtenerDatosExterno(ByVal NaveId As Integer, ByVal Anio As Integer) As DataTable
        Dim datos As New Nomina.Datos.RealesFiscalesDA
        Return datos.ObtenerDatosExterno(NaveId, Anio)
    End Function

    Public Function llenarComboAnio(ByVal idNave As Integer) As DataTable
        Dim objDA As New Datos.RealesFiscalesDA
        Return objDA.llenarComboAnio(idNave)
    End Function

    Public Function updateAguiVacFiscal(ByVal xmlAguinaldos As String, ByVal xmlVacaciones As String, ByVal naveId As Integer, ByVal anio As Integer) As DataTable
        Dim objDa As New Datos.RealesFiscalesDA
        Return objDa.updateAguiVacFiscal(xmlAguinaldos, xmlVacaciones, naveId, anio)
    End Function

    Public Function updateVacacionesFiscal(ByVal xmlVacaciones As String, ByVal naveId As Integer, ByVal anio As Integer) As DataTable
        Dim objDa As New Datos.RealesFiscalesDA
        Return objDa.updateVacacionesFiscal(xmlVacaciones, naveId, anio)
    End Function

    Public Function validarInfoVacaciones(ByVal naveId As Integer, ByVal anio As Integer) As Boolean
        Dim objDa As New Datos.RealesFiscalesDA
        Dim tabla As New DataTable()
        Dim resultado As Boolean

        tabla = objDa.validarInfoVacaciones(naveId, anio)
        If tabla.Rows.Count() > 0 Then
            resultado = False
        Else
            resultado = True
        End If
        Return resultado
    End Function

End Class
