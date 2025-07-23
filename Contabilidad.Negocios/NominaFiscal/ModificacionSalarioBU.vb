Public Class ModificacionSalarioBU
    Public Function obtenerEstatusModificacionSalario() As DataTable
        Dim objDatos As New Datos.ModificacionSalarioDA
        Return objDatos.obtenerEstatusModificacionSalario
    End Function

    Public Function consultarListaSolicitudesModificacionSalario(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal naveId As Integer, ByVal nombre As String,
                                                                 ByVal periodo As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String) As DataTable
        Dim objDatos As New Datos.ModificacionSalarioDA
        Return objDatos.consultarListaSolicitudesModificacionSalario(patronId, estatusId, naveId, nombre, periodo, fechaInicio, fechaFin)
    End Function

    Public Function obtenerColaboradorModificacionSalario(ByVal colaboradorId As Integer) As Entidades.ModificacionSalario
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim modSalario As New Entidades.ModificacionSalario

        dtResultado = objDatos.obtenerColaboradorModificacionSalario(colaboradorId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                modSalario.MDColaboradorId = CInt(dtResultado.Rows(0)("ID").ToString)
                modSalario.MDPatronId = CInt(dtResultado.Rows(0)("PatronId").ToString)
                modSalario.MDColaborador = dtResultado.Rows(0)("Colaborador").ToString
                modSalario.MDDepartamento = dtResultado.Rows(0)("Departamento").ToString
                modSalario.MDPuesto = dtResultado.Rows(0)("Puesto").ToString
                modSalario.MdFechaIngreso = CDate(dtResultado.Rows(0)("FechaIngreso").ToString)
                modSalario.MDAntiguedad = dtResultado.Rows(0)("Antiguedad").ToString
                modSalario.MDNSS = dtResultado.Rows(0)("NSS").ToString
                modSalario.MDSalarioAnterior = CDbl(dtResultado.Rows(0)("SalarioAnterior").ToString)
                modSalario.MDFactorIntegracion = CDbl(dtResultado.Rows(0)("FactorIntegracion").ToString)
                modSalario.MDNumCreditoInfonavit = dtResultado.Rows(0)("NumCredito").ToString
                modSalario.MDTipoDescuento = dtResultado.Rows(0)("TipoDescuento").ToString
                modSalario.MDvalorDescuentoInfonavit = CDbl(dtResultado.Rows(0)("ValorDescuento").ToString)
                modSalario.MDDescuentoInfonavitAnterior = CDbl(dtResultado.Rows(0)("DescuentoSemanal").ToString)
            End If
        End If

        Return modSalario
    End Function

    Public Function altaModificacionSalario(ByVal modSalario As Entidades.ModificacionSalario) As String
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.altaModificacionSalario(modSalario)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function validarSolicitud(ByVal colaboradorId As Integer) As String
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validarColaboradorSolicitud(colaboradorId)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function obtenerExedenteTabulador(ByVal colaboradorId As Integer, ByVal salarioAnterior As Double, ByVal salarioNuevo As Double) As Double
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.obtenerExedenteTabulador(colaboradorId, salarioAnterior, salarioNuevo)
        If Not dtResultado Is Nothing Then
            resultado = CDbl(dtResultado.Rows(0)("Excedente").ToString)
        End If

        Return resultado
    End Function

    Public Function validarEstatus(ByVal solicitudId As Integer, ByVal opcEstatus As Integer) As String
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validarEstatus(solicitudId, opcEstatus)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function cambiarEstatus(ByVal solicitudId As Integer, ByVal opcEstatus As Integer, ByVal motivoRechazo As String, ByVal descuentoSem As Double, ByVal descuentoDiario As Double) As String
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.cambiarEstatus(solicitudId, opcEstatus, motivoRechazo, descuentoSem, descuentoDiario)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultarSolicitudModificacionSalario(ByVal solicitudId As Integer) As Entidades.ModificacionSalario
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim modSalario As New Entidades.ModificacionSalario

        dtResultado = objDatos.consultarSolicitudModificacionSalario(solicitudId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                modSalario.MDID = CInt(dtResultado.Rows(0)("modSal_modificacionsalarioid").ToString)
                modSalario.MDColaboradorId = CInt(dtResultado.Rows(0)("modSal_colaboradorId").ToString)
                modSalario.MDPatronId = CInt(dtResultado.Rows(0)("modSal_patronId").ToString)
                modSalario.MDAPaterno = dtResultado.Rows(0)("APaterno").ToString
                modSalario.MDAMaterno = dtResultado.Rows(0)("AMaterno").ToString
                modSalario.MDNombre = dtResultado.Rows(0)("Nombre").ToString
                modSalario.MDColaborador = dtResultado.Rows(0)("Colaborador").ToString
                modSalario.MDDepartamento = dtResultado.Rows(0)("Departamento").ToString
                modSalario.MDPuesto = dtResultado.Rows(0)("Puesto").ToString
                modSalario.MDFechaIngreso = CDate(dtResultado.Rows(0)("real_fecha").ToString)
                modSalario.MDAntiguedad = dtResultado.Rows(0)("Antiguedad").ToString
                modSalario.MDNSS = dtResultado.Rows(0)("cono_nss").ToString
                modSalario.MDSalarioAnterior = CDbl(dtResultado.Rows(0)("modSal_salarioanterior").ToString)
                modSalario.MDSalarioNuevo = CDbl(dtResultado.Rows(0)("modSal_salarionuevo").ToString)
                If Not dtResultado.Rows(0)("modSal_fechaMovimiento") Is DBNull.Value Then
                    modSalario.MDFechaMovimiento = CDate(dtResultado.Rows(0)("modSal_fechaMovimiento").ToString)
                End If
                modSalario.MDNumCreditoInfonavit = dtResultado.Rows(0)("NumCredito").ToString
                modSalario.MDTipoDescuento = dtResultado.Rows(0)("TipoDescuento").ToString
                modSalario.MDvalorDescuentoInfonavit = dtResultado.Rows(0)("ValorDescuento").ToString
                modSalario.MDDescuentoInfonavitAnterior = CDbl(dtResultado.Rows(0)("DescuentoAnterior").ToString)
                modSalario.MDDescuentoInfonavitNuevo = CDbl(dtResultado.Rows(0)("DescuentoNuevo").ToString)
                modSalario.MDDescuentoImssDiario = CDbl(dtResultado.Rows(0)("DescuentoImssDiario").ToString)
                modSalario.MDDescuentoImssSem = CDbl(dtResultado.Rows(0)("DescuentoImssSem").ToString)
                modSalario.MDDescuentoISRDiario = CDbl(dtResultado.Rows(0)("DescuentoISRDiario").ToString)
                modSalario.MDDescuentoISRSem = CDbl(dtResultado.Rows(0)("DescuentoISRSem").ToString)
            End If
        End If

        Return modSalario
    End Function

    Public Function consultarPeriodoNominaSolicitud(ByVal solicitudId As Integer) As DataTable
        Dim objDatos As New Datos.ModificacionSalarioDA

        Return objDatos.consultarPeriodoNominaSolicitud(solicitudId)
    End Function

    Public Function editarModificacionSalario(ByVal solicitudId As Integer, ByVal fechaMovimiento As Date) As String
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.editarModificacionSalario(solicitudId, fechaMovimiento)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultarInformacionIDSE(ByVal solicitudIds As String) As List(Of Entidades.InformacionIDSE_SUA)
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim informacionIdse As Entidades.InformacionIDSE_SUA
        Dim listInfoIdse As New List(Of Entidades.InformacionIDSE_SUA)

        dtResultado = objDatos.consultarInformacionIDSE(solicitudIds)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                For Each row As DataRow In dtResultado.Rows
                    informacionIdse = New Entidades.InformacionIDSE_SUA
                    informacionIdse.IITablaId = CInt(row.Item("modSal_modificacionsalarioid").ToString)
                    informacionIdse.IIRegistroPatronal = row.Item("patr_nopatronal").ToString
                    informacionIdse.IINumeroSeguroSocial = row.Item("cono_nss").ToString
                    informacionIdse.IIAPaterno = row.Item("codr_apellidopaterno").ToString
                    informacionIdse.IIAMaterno = row.Item("codr_apellidomaterno").ToString
                    informacionIdse.IINombre = row.Item("codr_nombre").ToString
                    informacionIdse.IISalarioDiario = row.Item("modSal_salarionuevo").ToString
                    informacionIdse.IIClaveTipoSalario = row.Item("tipSal_Clave").ToString
                    informacionIdse.IIClaveTipoJornada = row.Item("tipJor_clave").ToString
                    informacionIdse.IIFechaMovimiento = row.Item("modSal_fechaMovimiento").ToString
                    informacionIdse.IIClaveMovimiento = row.Item("mov_clave").ToString
                    informacionIdse.IIClaveTrabajador = row.Item("claveTrabajador").ToString
                    informacionIdse.IICurp = row.Item("codr_curp").ToString
                    informacionIdse.IIIdentificador = row.Item("identificador").ToString
                    informacionIdse.IIRutaDescarga = row.Item("rutaDescarga").ToString
                    listInfoIdse.Add(informacionIdse)
                Next
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

        Return listInfoIdse
    End Function

    Public Function aplicarSolicitud(ByVal solicitudId As Integer, ByVal carpeta As String, ByVal archivo As String) As DataTable
        Dim objDatos As New Datos.ModificacionSalarioDA
        Return objDatos.aplicarSolicitud(solicitudId, carpeta, archivo)
    End Function

    Public Function rechazarIdseSolicitud(ByVal solicitudId As Integer, ByVal carpeta As String, ByVal archivo As String,
                                          ByVal motivoRechazo As String, ByVal descuentoSem As Double,
                                          ByVal descuentoDiario As Double) As String
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.rechazarIdseSolicitud(solicitudId, carpeta, archivo, motivoRechazo, descuentoSem, descuentoDiario)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultaDatosCorreo(ByVal solicitudId As Integer) As DataTable
        Dim objDatos As New Datos.ModificacionSalarioDA
        Return objDatos.consultaDatosCorreo(solicitudId)
    End Function

    Public Function obtenerFechaMovimiento(ByVal patronId As Integer) As String
        Dim objDatos As New Datos.ModificacionSalarioDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.obtenerFechaMovimiento(patronId)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("fechaMovimiento").ToString
        End If

        Return resultado
    End Function
End Class
