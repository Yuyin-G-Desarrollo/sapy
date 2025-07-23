Public Class ModSalarioMixtoBU
    Public Function consultarListaSolicitudesModificacionSalario(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal colaboradoresId As String,
                                                                 ByVal periodo As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String) As DataTable
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Return objDatos.consultarListaSolicitudesModificacionSalario(patronId, estatusId, colaboradoresId, periodo, fechaInicio, fechaFin)
    End Function

    Public Function validarEstatus(ByVal solicitudId As Integer, ByVal opcEstatus As Integer) As String
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.validarEstatus(solicitudId, opcEstatus)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultarInformacionIDSE(ByVal solicitudIds As String) As List(Of Entidades.InformacionIDSE_SUA)
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Dim dtResultado As New DataTable
        Dim informacionIdse As Entidades.InformacionIDSE_SUA
        Dim listInfoIdse As New List(Of Entidades.InformacionIDSE_SUA)

        dtResultado = objDatos.consultarInformacionIDSE(solicitudIds)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                For Each row As DataRow In dtResultado.Rows
                    informacionIdse = New Entidades.InformacionIDSE_SUA
                    informacionIdse.IITablaId = CInt(row.Item("modsalm_solicitudid").ToString)
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

    Public Function cambiarEstatus(ByVal solicitudId As Integer, ByVal opcEstatus As Integer, ByVal motivoRechazo As String) As String
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.cambiarEstatus(solicitudId, opcEstatus, motivoRechazo)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function editarModificacionSalario(ByVal solicitudId As Integer, ByVal fechaMovimiento As Date, ByVal salarioNuevo As Double) As String
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.editarModificacionSalario(solicitudId, fechaMovimiento, salarioNuevo)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function
    Public Function consultarSolicitudModificacionSalario(ByVal solicitudId As Integer) As Entidades.ModificacionSalarioMixto
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Dim dtResultado As New DataTable
        Dim modSalario As New Entidades.ModificacionSalarioMixto

        dtResultado = objDatos.consultarSolicitudModificacionSalario(solicitudId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                modSalario.MDID = CInt(dtResultado.Rows(0)("modsalm_solicitudid").ToString)
                modSalario.PColaboradorId = CInt(dtResultado.Rows(0)("modsalm_colaboradorid").ToString)
                modSalario.PNombreColaborador = dtResultado.Rows(0)("nombreCompleto").ToString
                modSalario.PDepartamento = dtResultado.Rows(0)("departamento").ToString
                modSalario.PPuesto = dtResultado.Rows(0)("puesto").ToString
                modSalario.PFechaIngreso = CDate(dtResultado.Rows(0)("real_fecha").ToString)
                modSalario.PAntiguedad = dtResultado.Rows(0)("Antiguedad").ToString
                modSalario.PNumSS = dtResultado.Rows(0)("cono_nss").ToString
                modSalario.PIMSSDiario = dtResultado.Rows(0)("modsalm_imssdiario").ToString
                modSalario.PIMSSSemanal = dtResultado.Rows(0)("modsalm_imsssemanal").ToString
                modSalario.PBimestre = CDbl(dtResultado.Rows(0)("modsalm_bimestre").ToString)
                modSalario.PComisiones = CDbl(dtResultado.Rows(0)("modsalm_comisiones").ToString)
                modSalario.PDiasPagados = CDbl(dtResultado.Rows(0)("modsalm_diaspagados").ToString)
                modSalario.PSDIFijo = CDbl(dtResultado.Rows(0)("modsalm_salariodiariofijo").ToString)
                modSalario.PSDIVariable = CDbl(dtResultado.Rows(0)("modsalm_salariodiariovariable").ToString)
                If Not dtResultado.Rows(0)("modsalm_fechamovimiento") Is DBNull.Value Then
                    modSalario.PFechaMovimiento = CDate(dtResultado.Rows(0)("modsalm_fechamovimiento").ToString)
                End If
                modSalario.PSDINeto = dtResultado.Rows(0)("modsalm_salariodiarioneto").ToString
            End If
        End If

        Return modSalario
    End Function
    Public Function aplicarSolicitud(ByVal solicitudId As Integer, ByVal carpeta As String, ByVal archivo As String) As DataTable
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Return objDatos.aplicarSolicitud(solicitudId, carpeta, archivo)
    End Function

    Public Function rechazarIdseSolicitud(ByVal solicitudId As Integer, ByVal carpeta As String, ByVal archivo As String,
                                          ByVal motivoRechazo As String) As String
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.rechazarIdseSolicitud(solicitudId, carpeta, archivo, motivoRechazo)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultaDatosCorreo(ByVal solicitudId As Integer) As DataTable
        Dim objDatos As New Datos.ModSalarioMixtoDA
        Return objDatos.consultaDatosCorreo(solicitudId)
    End Function
End Class
