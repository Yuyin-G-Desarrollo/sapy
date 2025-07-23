Imports Nomina.Datos

Public Class ConfiguracionNaveNominaBU


    Public Function buscarConfiguracionNave(ByVal naveId As Int32) As Entidades.ConfiguracionNaveNomina
        Dim objConfiguracionDA As New ConfiguracionNaveNominaDA
        'Dim objColaboradorBU As New ColaboradoresBU

        Dim tablaConfiguracion As New DataTable
        buscarConfiguracionNave = New Entidades.ConfiguracionNaveNomina

        tablaConfiguracion = objConfiguracionDA.buscarConfiguraciondeNave(naveId)
        For Each row As DataRow In tablaConfiguracion.Rows
            buscarConfiguracionNave.PConDiasAguinaldo = CInt(row("conf_diasaguinaldo"))
            buscarConfiguracionNave.PconDiasVacaciones = CInt(row("conf_diasvacaciones"))
            buscarConfiguracionNave.PconDiasGratificacion = CStr(row("conf_finiquitodiasgratificacion"))
         


            
        Next



    End Function


    Public Sub InsertarConfiguracionNave(ByVal DiasGratificacion As Int32, ByVal AutorizaGerente As Boolean, _
                                             ByVal AutorizaDirector As Boolean, ByVal DiasAguinaldo As Int32, ByVal NaveId As Int32, ByVal Vacaciones As Int32)
        Dim objConfiguracionDA As New ConfiguracionNaveNominaDA
        objConfiguracionDA.InsertarConfiguracionNave(DiasGratificacion, AutorizaGerente, _
                                              AutorizaDirector, DiasAguinaldo, NaveId, Vacaciones)
    End Sub



    Public Sub UpdateConfiguracionNave(ByVal DiasGratificacion As Int32, ByVal AutorizaGerente As Boolean, _
                                             ByVal AutorizaDirector As Boolean, ByVal DiasAguinaldo As Int32, ByVal ConfiguracionID As Int32, ByVal Vacaciones As Int32)
        Dim objConfiguracionDA As New ConfiguracionNaveNominaDA
        objConfiguracionDA.UpdateConfiguracionNave(DiasGratificacion, AutorizaGerente, _
                                              AutorizaDirector, DiasAguinaldo, ConfiguracionID, Vacaciones)
    End Sub





    Public Function ListaConfiguracionNave() As List(Of Entidades.ConfiguracionNaveNomina)
        Dim objConfiguracionDA As New ConfiguracionNaveNominaDA
        Dim objColaboradorBU As New ColaboradoresBU

        Dim tablaConfiguracion As New DataTable
        ListaConfiguracionNave = New List(Of Entidades.ConfiguracionNaveNomina)

        tablaConfiguracion = objConfiguracionDA.ListaConfiguracionNaves()
        For Each row As DataRow In tablaConfiguracion.Rows
            Dim configuracion As New Entidades.ConfiguracionNaveNomina
            Dim Naves As New Entidades.Naves
            Try
                configuracion.PConDiasAguinaldo = CInt(row("conf_diasaguinaldo"))
            Catch ex As Exception

            End Try
            Try
                configuracion.PconDiasVacaciones = CInt(row("conf_diasvacaciones"))
            Catch ex As Exception

            End Try

            Try
                configuracion.PconDiasGratificacion = CStr(row("conf_finiquitodiasgratificacion"))
            Catch ex As Exception

            End Try
            Try
                configuracion.PAutorizaGerente = CBool(row("conf_autorizagerente"))
            Catch ex As Exception

            End Try
            Try
                configuracion.PAutorizaDirector = CBool(row("conf_autorizadirector"))
            Catch ex As Exception

            End Try

            Try
                configuracion.PIDconfiguracion = CInt(row("conf_nominanave"))
            Catch ex As Exception

            End Try

            Try
                configuracion.PconDiasVacaciones = CInt(row("conf_diasvacaciones"))
            Catch ex As Exception

            End Try


            Naves.PNombre = CStr(row("nave_nombre"))
            Naves.PNaveId = CStr(row("nave_naveid"))
            configuracion.PNaveNombre = Naves


            ListaConfiguracionNave.Add(configuracion)


        Next



    End Function





    Public Function CalcularVacacionesSegunAntiguedad(ByVal Antiguedad As Double, ByVal SalarioDiario As Double) As Double

        If Antiguedad >= 20 Then
            CalcularVacacionesSegunAntiguedad = SalarioDiario * 20

        ElseIf Antiguedad >= 15 Then
            CalcularVacacionesSegunAntiguedad = SalarioDiario * 18

        ElseIf Antiguedad >= 10 Then
            CalcularVacacionesSegunAntiguedad = SalarioDiario * 16

        ElseIf Antiguedad >= 5 Then
            CalcularVacacionesSegunAntiguedad = SalarioDiario * 14
        ElseIf Antiguedad >= 4 Then
            CalcularVacacionesSegunAntiguedad = SalarioDiario * 12
        ElseIf Antiguedad >= 3 Then
            CalcularVacacionesSegunAntiguedad = SalarioDiario * 10
        ElseIf Antiguedad >= 2 Then
            CalcularVacacionesSegunAntiguedad = SalarioDiario * 8
        Else
            CalcularVacacionesSegunAntiguedad = SalarioDiario * 6
        End If
        Return CalcularVacacionesSegunAntiguedad
    End Function


    Public Function CalcularDiasSegunAntiguedad(ByVal Naveid As Int32, ByVal Antiguedad As Double) As Double
        Dim objConfiguracionDA As New ConfiguracionNaveNominaDA
        Dim objColaboradorBU As New ColaboradoresBU

        Dim tablaConfiguracion As New DataTable


        tablaConfiguracion = objConfiguracionDA.ListaConfiguracionNavesFiniquito(Naveid)

        For Each row As DataRow In tablaConfiguracion.Rows


            CalcularDiasSegunAntiguedad = CInt(row("conf_diasvacaciones"))



        Next
        If CalcularDiasSegunAntiguedad = 0 Then
            If Antiguedad >= 20 Then
                CalcularDiasSegunAntiguedad = 20

            ElseIf Antiguedad >= 15 Then
                CalcularDiasSegunAntiguedad = 18

            ElseIf Antiguedad >= 10 Then
                CalcularDiasSegunAntiguedad = 16

            ElseIf Antiguedad >= 5 Then
                CalcularDiasSegunAntiguedad = 14
            ElseIf Antiguedad >= 4 Then
                CalcularDiasSegunAntiguedad = 12
            ElseIf Antiguedad >= 3 Then
                CalcularDiasSegunAntiguedad = 10
            ElseIf Antiguedad >= 2 Then
                CalcularDiasSegunAntiguedad = 8
            Else
                CalcularDiasSegunAntiguedad = 6
            End If
        End If





        Return CalcularDiasSegunAntiguedad
    End Function

    ''metodos para formulario configuraciones de nomina
    Public Function ConfiguracionSolicitudFinanzasNomina() As DataTable
        Dim objDa As New Datos.ConfiguracionNaveNominaDA
        Dim dtsolicitudes As New DataTable
        dtsolicitudes = objDa.ConfiguracionSolicitudFinanzasNomina()
        Return dtsolicitudes
    End Function

    Public Function actualizarConfiguracionSolicitudes(ByVal idPeriodo As Int32, ByVal tipoSolicitud As String, ByVal idNave As Int32, ByVal beneficiario As String, ByVal usuarioModifica As Integer) As DataTable
        Dim objDa As New Datos.ConfiguracionNaveNominaDA
        Return objDa.ActualizaConfiguracionSolicitudes(idPeriodo, tipoSolicitud, idNave, beneficiario, usuarioModifica)
    End Function

    Public Function obtenerConfiguracionNomina(ByVal idPeriodo As Int32) As DataTable
        Dim objDa As New Datos.ConfiguracionNaveNominaDA
        Dim dtConfN As New DataTable
        dtConfN = objDa.obtenerConfiguracionNomina(idPeriodo)
        Return dtConfN
    End Function

    Public Function obtenerIdBeneficiario(ByVal idCaja As Int32, ByVal beneficiario As String) As DataTable
        Dim objDa As New Datos.ConfiguracionNaveNominaDA
        Dim dtBeneficiario As New DataTable
        dtBeneficiario = objDa.obtenerIdBeneficiario(idCaja, beneficiario)
        Return dtBeneficiario
    End Function

    Public Function ComboRazonesSocialesCajaChica(ByVal idCaja As Int32) As DataTable
        Dim objDa As New Datos.ConfiguracionNaveNominaDA
        Dim dtCombo As New DataTable
        dtCombo = objDa.comboRazonSocialCajaChica(idCaja)
        Return dtCombo
    End Function

    Public Sub actualizarIdSolicitudesCajaChica(ByVal idPeriodo As Int32, ByVal idEfectivo As Int32, ByVal idCheque As Int32, ByVal idDeduccion As Int32)
        Dim objDa As New Datos.ConfiguracionNaveNominaDA
        objDa.actualizarIdSolicitudesCajaChica(idPeriodo, idEfectivo, idCheque, idDeduccion)
    End Sub

    Public Function obtenerSemanaActualConfiguracionNomina() As DataTable
        Dim objDa As New Datos.ConfiguracionNaveNominaDA
        Dim dtSemana As New DataTable
        dtSemana = objDa.obtenerSemanaActualConfiguracionNomina()
        Return dtSemana
    End Function


    Public Function ValidaUtilidadesNave(ByVal NaveID As Integer) As DataTable
        Dim obJDA As New Datos.ConfiguracionNaveNominaDA
        Dim dtUtilidadesNave As New DataTable
        dtUtilidadesNave = obJDA.ValidaUtilidadesNave(NaveID)
        Return dtUtilidadesNave
    End Function

End Class
