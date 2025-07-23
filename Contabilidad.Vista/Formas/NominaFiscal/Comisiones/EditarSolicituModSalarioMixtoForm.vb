Imports System.Windows.Forms

Public Class EditarSolicituModSalarioMixtoForm
    Public editar As Boolean = False
    Public versolicitud As Boolean = False
    Public guardado As Boolean = False
    Public solicitudId As Integer = 0
    Public colaboradorId As Integer = 0

    Private Sub EditarSolicituModSalarioMixtoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosSolicitud()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("LIST_SOLMODSAL", "CAPTDESTIEMPO_MOVSALARIO") Then
            dtpFechaMovimiento.MinDate = CDate("1900-01-01")
            dtpFechaMovimiento.MaxDate = CDate("2099-01-01")
        End If

        'txtSueldoNuevo.Visible = False
        lblFechaMovimiento.Visible = True
        dtpFechaMovimiento.Visible = False
        'End If

        txtSueldoNuevo.Enabled = Not versolicitud

    End Sub

    Private Sub cargarDatos(ByVal modSalario As Entidades.ModificacionSalarioMixto)
        Dim objMensajeError As New Tools.ErroresForm
        Try
            limpiarCampos()

            solicitudId = modSalario.MDID
            colaboradorId = modSalario.PColaboradorId
            'lblPatronId.Text = modSalario.MDPatronId
            lblColaborador.Text = modSalario.PNombreColaborador
            lblDepartamento.Text = modSalario.PDepartamento
            lblPuesto.Text = modSalario.PPuesto
            lblFechaIngreso.Text = modSalario.PFechaIngreso
            lblAntiguedad.Text = modSalario.PAntiguedad
            lblNSS.Text = modSalario.PNumSS
            lblSDIFijo.Text = modSalario.PSDIFijo.ToString("N2")
            'lblSueldoNuevo.Text = modSalario.MDSalarioNuevo.ToString("N2")            
            If modSalario.PSDINeto > 0 Then
                txtSueldoNuevo.Text = modSalario.PSDINeto.ToString("N2")
            Else
                txtSueldoNuevo.Text = ""
            End If

            If modSalario.PFechaMovimiento.ToString <> "" Then
                lblFechaMovimiento.Text = CDate(modSalario.PFechaMovimiento).ToShortDateString
                dtpFechaMovimiento.Text = CDate(modSalario.PFechaMovimiento).ToShortDateString
            End If

            lblBimestre.Text = modSalario.PBimestre
            lblComisiones.Text = modSalario.PComisiones.ToString("N2")
            lblDiasPagados.Text = modSalario.PDiasPagados.ToString("N2")
            lblSDIVariable.Text = modSalario.PSDIVariable.ToString("N2")

        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub limpiarCampos()
        solicitudId = 0
        colaboradorId = 0
        'lblPatronId.Text = "0"
        lblColaborador.Text = "--"
        lblDepartamento.Text = "--"
        lblPuesto.Text = "--"
        lblFechaIngreso.Text = "- -/- -/- - - -"
        lblAntiguedad.Text = "--"
        lblNSS.Text = "--"
        lblSDIFijo.Text = "--"
        txtSueldoNuevo.Text = "--"
        lblFechaMovimiento.Text = "- -/- -/- - - -"
        dtpFechaMovimiento.Text = Now.ToShortDateString

    End Sub

    Private Sub txtSueldoNuevo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldoNuevo.KeyPress
        Dim arreglo(2) As String

        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            If txtSueldoNuevo.Text.IndexOf(".") > 0 Then
                arreglo = Split(txtSueldoNuevo.Text, ".")

                If arreglo(1).Length >= 2 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "." And txtSueldoNuevo.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click, lblGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Try
            If validarCampos() Then
                If validarInformacion() Then
                    Dim objBU As New Negocios.ModSalarioMixtoBU
                    Dim resultado As String = String.Empty

                    resultado = objBU.editarModificacionSalario(solicitudId, dtpFechaMovimiento.Value, CDbl(txtSueldoNuevo.Text))

                    If resultado = "EXITO" Then
                        objMensajeExito.mensaje = "Solicitud guardada correctamente"
                        objMensajeExito.ShowDialog()
                        guardado = True
                        Me.Cursor = Cursors.Default
                        Me.Close()
                    Else
                        objMensajeError.mensaje = "Error al guardar la solicitud"
                        objMensajeError.ShowDialog()
                    End If
                End If
            End If

        Catch ex As Exception
            objMensajeError.mensaje = "Error al guardar"
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function validarCampos() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim esNumero As Double = 0.0

        If colaboradorId = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un colaborador."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If txtSueldoNuevo.Visible Then
            If txtSueldoNuevo.Text = "" Then
                objMensajeAdv.mensaje = "Favor de ingresar el Sueldo Diario Nuevo."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                Try
                    esNumero = CDbl(txtSueldoNuevo.Text)
                    If CDbl(txtSueldoNuevo.Text) <= 0 Then
                        objMensajeAdv.mensaje = "El Sueldo Diario Nuevo debe ser mayor a 0."
                        objMensajeAdv.ShowDialog()
                        Return False
                        Exit Function
                    End If

                    ''Cambiar al sueldo fijo xD
                    If CDbl(txtSueldoNuevo.Text) < CDbl(lblSDIFijo.Text) Then
                        objMensajeAdv.mensaje = "El Sueldo Diario Nuevo no puede ser menor al Sueldo Diaro Anterior."
                        objMensajeAdv.ShowDialog()
                        Return False
                        Exit Function
                    End If

                Catch ex As Exception
                    objMensajeAdv.mensaje = "El Sueldo Diario Nuevo debe ser un valor décimal."
                    objMensajeAdv.ShowDialog()
                    Return False
                    Exit Function
                End Try
            End If
        End If

        Return True
    End Function

    Private Function validarInformacion() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Try
            'Dim objUtileriasBU As New Negocios.UtileriasBU
            'If Not objUtileriasBU.existePeriodoNomina(lblPatronId.Text, 0, "") Then
            '    objMensajeAdv.mensaje = "No hay periodo de nómina fiscal cargado para el movimiento."
            '    objMensajeAdv.ShowDialog()
            '    Return False
            '    Exit Function
            'End If

            ''Consultar con Jorge
            'If dtpFechaMovimiento.Visible Then
            '    If dtpFechaMovimiento.Value.DayOfWeek = DayOfWeek.Saturday Or dtpFechaMovimiento.Value.DayOfWeek = DayOfWeek.Sunday Then
            '        objMensajeAdv.mensaje = "La fecha de movimiento no puede ser Sábado ni Domingo."
            '        objMensajeAdv.ShowDialog()
            '        Return False
            '        Exit Function
            '    End If
            'End If

            Return True
        Catch ex As Exception
            objMensajeError.mensaje = "Error al validar la información."
            objMensajeError.ShowDialog()
            Return False
        End Try
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cargarDatosSolicitud()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If solicitudId <> 0 Then
                Dim objBU As New Negocios.ModSalarioMixtoBU
                Dim modSalario As New Entidades.ModificacionSalarioMixto

                modSalario = objBU.consultarSolicitudModificacionSalario(solicitudId)
                cargarDatos(modSalario)
                dtpFechaMovimiento.MinDate = CDate(modSalario.PFechaMovimiento)
                'obtenerRangoPeriodoNomina()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar los datos de la solicitud."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    'Private Sub obtenerRangoPeriodoNomina()
    '    Dim objMensajeError As New Tools.ErroresForm
    '    Try
    '        Dim objBU As New Negocios.ModificacionSalarioBU
    '        Dim dtPeriodo As New DataTable

    '        dtPeriodo = objBU.consultarPeriodoNominaSolicitud(solicitudId)
    '        If Not dtPeriodo Is Nothing Then
    '            dtpFechaMovimiento.MinDate = dtPeriodo.Rows(0)("fechaInicial").ToString

    '            If CInt(dtPeriodo.Rows(0)("diasLaborados").ToString) > 7 Then
    '                Dim fecha As Date = dtPeriodo.Rows(0)("fechaInicial").ToString

    '                Dim dias As Int16 = 1
    '                Do Until dias = 5
    '                    fecha = fecha.AddDays(1)
    '                    If fecha.DayOfWeek <> DayOfWeek.Saturday And fecha.DayOfWeek <> DayOfWeek.Sunday Then
    '                        dias += 1
    '                    End If
    '                Loop
    '                dtpFechaMovimiento.MaxDate = fecha
    '            Else
    '                dtpFechaMovimiento.MaxDate = dtPeriodo.Rows(0)("fechaFinal").ToString
    '            End If
    '        Else
    '            objMensajeError.mensaje = "Error iniciar fecha de movimiento."
    '            objMensajeError.ShowDialog()
    '            Me.Close()
    '        End If
    '    Catch ex As Exception
    '        objMensajeError.mensaje = "Error iniciar fecha de movimiento."
    '        objMensajeError.ShowDialog()
    '        Me.Close()
    '    End Try
    'End Sub

End Class