Imports CrystalDecisions.Shared
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports Nomina.Negocios
Imports Tools
Imports System.Globalization

Public Class ListaPrestamosForm
    Dim fechaInicial As DateTime
    Dim Fechafinal As DateTime
    Dim idCajaAhorro As Integer = 0
    Dim prestamoID As Integer
    Dim colaboradorID As Integer
    Dim saldoPrestamo As Double
    Dim nombreColaborador As String

    'Variables para los permisos
    Dim perAbonoExtraordinario As Boolean = False
    Dim perAutorizarDirector As Boolean = False
    Dim perAutorizarGerente As Boolean = False
    Dim preAutorizar As Boolean = False
    Dim preCancelar As Boolean = False
    Dim preEditar As Boolean = False
    Dim preEditarPositivo As Boolean = False
    Dim preEditarNegativo As Boolean = False
    Dim preEditarAbono As Boolean = False
    Dim prepPAgos As Boolean = False
    Dim prePreAutorizacion As Boolean = False
    Dim preSolicitarFinanzas As Boolean = False
    Dim preSolicitarPrestamos As Boolean = False
    Dim preSolicitarPrestamoEspecial As Boolean = False
    Dim preSolicitarPrestacionesSAY As Boolean = False

    Public Property UseExternalSummaryCalculator As Infragistics.Win.DefaultableBoolean



    Dim valorPrestamos As Integer = 0
    Dim valorSaldo As Integer = 0
    Dim valorSaldoTermino As Integer = 0
    Dim valorCajaAhorro As Integer = 0



    Dim Parametros As New ParameterFields()

    ''Esta variable indica el nombre del parametro que se encuentra en el procedimiento almacenado

    Dim UserName As New ParameterField()
    Dim NombreArchivo As New ParameterField()
    Dim FechaIni As New ParameterField()
    Dim FechaFi As New ParameterField()
    Dim TotalConcentrado As New ParameterField

    ''Esta variable toma el valor dle parametro
    Dim myDiscreteValueUserName As New ParameterDiscreteValue()
    Dim myDiscreteValueNombreArchivo As New ParameterDiscreteValue()
    Dim myDiscreteValueFechaIni As New ParameterDiscreteValue()
    Dim myDiscreteValueFechaFi As New ParameterDiscreteValue()
    Dim myDiscreteValueTotalConcentrado As New ParameterDiscreteValue


    Public NaveID As Integer
    Public PrestamoEspecial As String
    Public PrestacionSAY As String
    Public Distintivo As String

    Public Sub llenarComboCajas()
        Dim objCajas As New CajasBU
        Dim dtCajas As New DataTable
        dtCajas = objCajas.listaCajas(CInt(cmbNave.SelectedValue))
        cmbCajas.DataSource = Nothing
        If dtCajas.Rows.Count > 0 Then
            cmbCajas.DataSource = dtCajas
            cmbCajas.DisplayMember = "Nombre"
            cmbCajas.ValueMember = "Id_Caja"
            btnSolicitarFinanzas.Enabled = True
            cmbCajas.Visible = True
            lblAlertaSinCaja.Visible = False
        Else
            cmbCajas.Visible = False
            lblAlertaSinCaja.Visible = True
            btnSolicitarFinanzas.Enabled = False
        End If
    End Sub

    Private Sub ListaPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
        If cmbNave.SelectedValue > 0 Then
            cmbNaveDrop()
            llenarComboCajas()
        End If
        ''comentado cambio en mostrado de prestamos
        ' formatoUltra()  

        'lblDirector.Visible = False
        'lblGerente.Visible = False
        pnlPeriodoBusqueda.Enabled = False
        pnlTipoBusqueda.Enabled = False
        rdbFechaSolicitud.Checked = True
        rdbFechaSolicitud.Enabled = False
        rdbFehcaEntrega.Enabled = False
        rdbRango.Checked = True
        cargarPermisos()
        ' llenarComboCajas()
        If preSolicitarPrestamos Then
            btnNuevoPrestamo.Enabled = True
        End If

        If preSolicitarPrestamoEspecial Then
            btnPrestamoEspecial.Enabled = True
            btnAyuda.Enabled = True
        End If

        If preSolicitarPrestacionesSAY Then
            btnPrestacion.Enabled = True
            btnAyuda.Enabled = True
        End If
        cmbCajas.Enabled = False
        lblAlertaSinCaja.Enabled = False
    End Sub

    Private Sub chkFecha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFecha.Click

        If Not cmbNave.Text = "" Then
            pnlTipoBusqueda.Enabled = True
            rdbFechaSolicitud.Enabled = True
            rdbFehcaEntrega.Enabled = True
            If chkFecha.Checked = True Then
                pnlPeriodoBusqueda.Enabled = True
                cmbPeriodoNomina.Enabled = False
            ElseIf chkFecha.Checked = False Then
                pnlPeriodoBusqueda.Enabled = False
                rdbRango.Checked = True
                pnlTipoBusqueda.Enabled = False
                rdbFechaSolicitud.Checked = True
                rdbFechaSolicitud.Enabled = False
                rdbFehcaEntrega.Enabled = False
            End If
        Else

            Dim vAdvertenciaForm As New AdvertenciaForm
            vAdvertenciaForm.Text = "Prestamos"
            vAdvertenciaForm.mensaje = "Seleccione Alguna Nave"
            vAdvertenciaForm.Show()
            pnlPeriodoBusqueda.Enabled = False

            rdbFechaSolicitud.Enabled = False
            rdbFehcaEntrega.Enabled = False
            chkFecha.Checked = False
            rdbRango.Checked = True
            pnlTipoBusqueda.Enabled = False
            rdbFechaSolicitud.Checked = True
            rdbFechaSolicitud.Enabled = False
            rdbFehcaEntrega.Enabled = False
        End If
    End Sub


    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        menuReporte.Show(btnReporte, 0, btnReporte.Height)
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        cmbNaveDrop()
        llenarComboCajas()

    End Sub



    Private Sub rdbRango_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRango.CheckedChanged
        If rdbRango.Checked = True Then

            DtpFechaFin.Enabled = True
            DtpFechaInicio.Enabled = True
            cmbPeriodoNomina.Enabled = False

        ElseIf rdbRango.Checked = False Then
            DtpFechaFin.Enabled = False
            DtpFechaInicio.Enabled = False
            cmbPeriodoNomina.Enabled = True
        End If
    End Sub

    Private Sub rdbPeriodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPeriodo.CheckedChanged
        If rdbPeriodo.Checked = True Then
            DtpFechaFin.Enabled = False
            DtpFechaInicio.Enabled = False
            cmbPeriodoNomina.Enabled = True

            Dim objBu As New Nomina.Negocios.SolicitudPrestamoBU
            Dim listafechas As New List(Of Entidades.SolicitudPrestamo)

            Dim idNom As DataRowView
            idNom = cmbPeriodoNomina.SelectedItem

            listafechas = objBu.FechasPeriodoNomina(idNom("pnom_PeriodoNomId"))

            For Each fila As Entidades.SolicitudPrestamo In listafechas
                fechaInicial = fila.PPeriodoNomina.PFechaInicio
                Fechafinal = fila.PPeriodoNomina.PFechaFin
            Next

        ElseIf rdbPeriodo.Checked = False Then
            DtpFechaFin.Enabled = True
            DtpFechaInicio.Enabled = True
            cmbPeriodoNomina.Enabled = False

        End If

    End Sub

    Private Sub cmbPeriodoNomina_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPeriodoNomina.DropDownClosed
        Dim objBu As New Nomina.Negocios.SolicitudPrestamoBU
        Dim listafechas As New List(Of Entidades.SolicitudPrestamo)

        Dim idNom As DataRowView
        idNom = cmbPeriodoNomina.SelectedItem

        listafechas = objBu.FechasPeriodoNomina(idNom("pnom_PeriodoNomId"))

        For Each fila As Entidades.SolicitudPrestamo In listafechas
            fechaInicial = fila.PPeriodoNomina.PFechaInicio
            Fechafinal = fila.PPeriodoNomina.PFechaFin
        Next

    End Sub



    Public Sub cmbNaveDrop()
        Try
            Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoNomina, cmbNave.SelectedValue)
            Dim objBu As New Negocios.SolicitudPrestamoBU
            Dim listaId As List(Of Entidades.SolicitudPrestamo)
            listaId = objBu.CajaDeAhorro(cmbNave.SelectedValue)

            For Each dato As Entidades.SolicitudPrestamo In listaId
                idCajaAhorro = dato.PCajaAhorro.pCajaAhorroId
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        grdDatosPrestamos.DataSource = Nothing
        Dim vAdvertenciaForm As New AdvertenciaForm
        If Not cmbNave.Text = "" Then
            If Not cmbEstatus.Text = "" Then
                mostrarDatos()
            Else
                vAdvertenciaForm.Text = "Prestamos"
                vAdvertenciaForm.mensaje = "Seleccione Un estatus"
                vAdvertenciaForm.Show()
            End If

        Else

            vAdvertenciaForm.Text = "Prestamos"
            vAdvertenciaForm.mensaje = "Seleccione Alguna Nave"
            vAdvertenciaForm.Show()

        End If

    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        cmbEstatus.SelectedIndex = cmbEstatus.Items.Count - 1
        cmbNave.SelectedIndex = 0
        lblDirector.Visible = False
        'lblGerente.Visible = False
        pnlPeriodoBusqueda.Enabled = False
        rdbRango.Checked = True
        grdDatosPrestamos.DataSource = Nothing

        'formatoUltra()
    End Sub

    Private Sub btnEditarAbono_Click(sender As Object, e As EventArgs) Handles btnEditarAbono.Click
        Dim objEditar As New EditarPrestamoForm
        If grdDatosPrestamos.ActiveRow.Cells("estatus").Value = "A" Then
            With objEditar
                .txtMonto.Enabled = True
                .txtMontoActual.Enabled = True
                .txtSemanas.Enabled = True
                .rbtnSemanas.Enabled = True
                .rbtnSemanas.Checked = False
                .rbtnAbono.Checked = True
                .txtAbono.Enabled = True
                .txtInteres.Enabled = False
                .cmbTipoInteres.Enabled = False
                .txtJustificacion.Enabled = False
                .PrestamoEditar = prestamoID
                .ColaboradorEditar = colaboradorID
                .saldoPrestamo = saldoPrestamo
                .editarAbono = True
                .editarmonto = True
                .ShowDialog()

            End With
        Else
            With objEditar
                .txtMonto.Enabled = False
                .txtMontoActual.Enabled = False
                .txtSemanas.Enabled = False
                .rbtnSemanas.Enabled = False
                .rbtnSemanas.Checked = False
                .rbtnAbono.Checked = True
                .txtAbono.Enabled = True
                .txtInteres.Enabled = False
                .cmbTipoInteres.Enabled = False
                .txtJustificacion.Enabled = False
                .PrestamoEditar = prestamoID
                .ColaboradorEditar = colaboradorID
                .saldoPrestamo = saldoPrestamo
                .editarAbono = True
                .editarmonto = False
                .ShowDialog()

            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAbonoExtraordinario.Click
        Dim vAbonoExtraordinario As New AbonoExtraordinarioForm
        vAbonoExtraordinario.pColaborado = colaboradorID
        vAbonoExtraordinario.pPrestamo = prestamoID
        vAbonoExtraordinario.pnave = cmbNave.SelectedValue
        'vAbonoExtraordinario.nombreNave = cmbNave.Text
        'vAbonoExtraordinario.idNaveLogo = cmbNave.SelectedValue
        'vAbonoExtraordinario.nombreColaborador = nombreColaborador
        vAbonoExtraordinario.ShowDialog()
    End Sub



    Private Sub btnNuevoPrestamo_Click(sender As Object, e As EventArgs) Handles btnNuevoPrestamo.Click
        Dim objSolcitud As New SolicitudPrestamosForm
        objSolcitud.ShowDialog()
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdDatosPrestamos.DataSource = Nothing
        If cmbNave.Text = "" Then
            pnlPeriodoBusqueda.Enabled = False
            pnlTipoBusqueda.Enabled = False
            rdbFechaSolicitud.Checked = True
            rdbFechaSolicitud.Enabled = False
            rdbFehcaEntrega.Enabled = False
            chkFecha.Checked = False
            rdbRango.Checked = True
        End If
    End Sub


    Private Sub cmbEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstatus.SelectedIndexChanged
        Dim estatus As String = ""
        cmbCajas.Enabled = False
        lblAlertaSinCaja.Enabled = False
        btnSolicitarFinanzas.Enabled = False
        lblSolicitar.Enabled = False
        btnAutorizarPrestamo.Enabled = False
        lblAutorizarPrestamo.Enabled = False
        btnEntregaColaborador.Enabled = False
        lblEntregar.Enabled = False
        btnRechazarPrestamo.Enabled = False
        lblRechazarPrestamo.Enabled = False
        lblDevolverDinero.Enabled = False
        btnDevolverDinero.Enabled = False

        If Not cmbEstatus.Text = "" Then
            estatus = cmbEstatus.SelectedItem

            If estatus.Equals("SOLICITADO") Then
                If perAutorizarDirector Then
                    btnAutorizarPrestamo.Enabled = True
                    lblAutorizarPrestamo.Enabled = True
                    btnRechazarPrestamo.Enabled = True
                    lblRechazarPrestamo.Enabled = True
                End If
            End If
            If estatus.Equals("AUTORIZADO") Then
                If preSolicitarFinanzas Then
                    btnSolicitarFinanzas.Enabled = True
                    lblSolicitar.Enabled = True
                    ' cmbCajas.Enabled = True
                    lblAlertaSinCaja.Enabled = True
                End If

            End If

            If estatus.Equals("DINERO ENTREGADO A NAVE") Then
                lblEntregar.Enabled = True
                btnEntregaColaborador.Enabled = True
                lblDevolverDinero.Enabled = True
                btnDevolverDinero.Enabled = True
            End If
            rdbFechaSolicitud.Checked = True
            mostrarDatos()
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdDatosPrestamos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDatosPrestamos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdDatosPrestamos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdDatosPrestamos.ClickCell
        Dim dtPerfil As New DataTable
        Dim perfilId As Integer = 0
        Dim objBU As New Nomina.Negocios.SolicitudPrestamoBU

        dtPerfil = objBU.ValidarPerfilUsuarioFinazas(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If dtPerfil.Rows.Count > 0 Then
            perfilId = dtPerfil.Rows(0).Item("peus_perfilid")
        End If


        With grdDatosPrestamos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With


        If perAbonoExtraordinario And preEditar Then
            If grdDatosPrestamos.ActiveRow.Cells("estatus").Value = "F" Or grdDatosPrestamos.ActiveRow.Cells("estatus").Value = "G" Then

                btnEditarAbono.Enabled = preEditarAbono
                lblEditarAbono.Enabled = preEditarAbono

                btnAbonoExtraordinario.Enabled = True
                lblAbonoExtraoridinario.Enabled = True
                prestamoID = grdDatosPrestamos.ActiveRow.Cells("idprestamo").Value
                colaboradorID = grdDatosPrestamos.ActiveRow.Cells("idcolaborador").Value

                nombreColaborador = grdDatosPrestamos.ActiveRow.Cells("nombre").Value

                saldoPrestamo = grdDatosPrestamos.ActiveRow.Cells("saldo").Value
            ElseIf grdDatosPrestamos.ActiveRow.Cells("estatus").Value = "A" Then
                btnEditarAbono.Enabled = preEditarAbono
                lblEditarAbono.Enabled = preEditarAbono

                btnAbonoExtraordinario.Enabled = False
                lblAbonoExtraoridinario.Enabled = False
                prestamoID = grdDatosPrestamos.ActiveRow.Cells("idprestamo").Value
                colaboradorID = grdDatosPrestamos.ActiveRow.Cells("idcolaborador").Value
                saldoPrestamo = grdDatosPrestamos.ActiveRow.Cells("saldo").Value
                nombreColaborador = grdDatosPrestamos.ActiveRow.Cells("nombre").Value

            Else
                btnEditarAbono.Enabled = False
                lblEditarAbono.Enabled = False
                btnAbonoExtraordinario.Enabled = True
                lblAbonoExtraoridinario.Enabled = True
                prestamoID = 0
                colaboradorID = 0
                nombreColaborador = ""
            End If
        Else
            btnEditarAbono.Enabled = False
            lblEditarAbono.Enabled = False
            btnAbonoExtraordinario.Enabled = True
            lblAbonoExtraoridinario.Enabled = True
            prestamoID = 0
            colaboradorID = 0
            nombreColaborador = ""


        End If

    End Sub

    Private Sub grdDatosPrestamos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdDatosPrestamos.DoubleClickCell
        ConsultarAbono()
    End Sub
    Private Sub btnAutorizarPrestamo_Click(sender As Object, e As EventArgs) Handles btnAutorizarPrestamo.Click

        With grdDatosPrestamos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With


        autorizarPrestamos("A", "B", "¿ Desea Autorizar los registros seleccionados ?, Si desea modifica el monto de algún préstamo autorice individualmente", "Prestamos Autorizados con éxito", "Autorizacion cancelada")
    End Sub

    Private Sub btnRechazarPrestamo_Click(sender As Object, e As EventArgs) Handles btnRechazarPrestamo.Click
        With grdDatosPrestamos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With


        autorizarPrestamos("A", "J", "¿ Desea Rechazar los registros seleccionados ?", "Prestamos Rechazados con éxito", "Autorizacion cancelada")
    End Sub

    Private Sub btnSolicitarFinanzas_Click(sender As Object, e As EventArgs) Handles btnSolicitarFinanzas.Click
        'With grdDatosPrestamos
        '    If .ActiveRow Is Nothing Then Exit Sub
        '    If .ActiveRow.Index < 0 Then Exit Sub
        'End With

        solicitarFinanzas()
    End Sub

    Public Function obtenerEstatusReal(ByVal estatus As String) As String
        If estatus.Equals("TODOS") Then
            estatus = ""
        End If
        If estatus.Equals("SOLICITADO") Then
            estatus = "A"
        End If
        If estatus.Equals("AUTORIZADO") Then
            estatus = "B"
        End If
        If estatus.Equals("SOLICITADO CAJA CHICA") Then
            estatus = "D"
        End If
        If estatus.Equals("DINERO ENTREGADO A NAVE") Then
            estatus = "E"
        End If
        If estatus.Equals("DINERO ENTREGADO AL COLABORADOR") Then
            estatus = "F"
        End If
        If estatus.Equals("EN COBRANZA") Then
            estatus = "G"
        End If
        If estatus.Equals("LIQUIDADO") Then
            estatus = "H"
        End If
        If estatus.Equals("CANCELADO") Then
            estatus = "I"
        End If
        If estatus.Equals("RECHAZADO") Then
            estatus = "J"
        End If
        If estatus.Equals("REGRESADO A FINANZAS") Then
            estatus = "k"
        End If
        Return estatus
    End Function

    Public Sub autorizarPrestamos(ByVal estatus_inicial As String, ByVal estatus_final As String, ByVal mensaje As String, ByVal mensaje2 As String, ByVal mensaje3 As String)
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vExitoForm As New ExitoForm
        Dim vErrores As New ErroresForm
        Dim objBU = New Nomina.Negocios.SolicitudPrestamoBU
        Dim ObjEnt = New Entidades.SolicitudPrestamo
        Dim bandera As Integer = 0
        'Dim cont As Integer

        For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
            If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = estatus_inicial Then
                bandera = 1
                'cont = cont + 1
                Exit For
            End If
        Next
        If bandera = 1 Then
            Try
                'If cont > 1 Then
                vConfirmarForm.Text = "Prestamos"
                vConfirmarForm.mensaje = mensaje
                Dim vDialogResult As New DialogResult
                vDialogResult = vConfirmarForm.ShowDialog
                If vDialogResult = Windows.Forms.DialogResult.OK Then
                    For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
                        If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = estatus_inicial Then
                            ObjEnt.Pestatus = estatus_final
                            ObjEnt.Pprestamoid = rowGrd.Cells("idprestamo").Value
                            ObjEnt.PgerenteId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            objBU.guardarAutorizacionPrestamosGerente(ObjEnt)
                        End If
                    Next
                    mostrarDatos()
                    vExitoForm.Text = "Prestamos"
                    vExitoForm.mensaje = mensaje2
                    vExitoForm.ShowDialog()
                Else
                    vAdvertenciaForm.Text = "Prestamos"
                    vAdvertenciaForm.mensaje = mensaje3
                    vAdvertenciaForm.ShowDialog()
                End If
                'Else
                'Dim EditarPrestamoform As New AutorizacionAbonosPrestamoForm
                'For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
                '    If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = estatus_inicial Then
                '        EditarPrestamoform.idcolaboradorEditar = rowGrd.Cells("idcolaborador").Value
                '        EditarPrestamoform.idprestamoEditar = rowGrd.Cells("idprestamo").Value
                '        EditarPrestamoform.montoeditar = rowGrd.Cells("prestamo").Value
                '        EditarPrestamoform.ShowDialog()
                '    End If
                'Next

                'End If

            Catch ex As Exception
                vErrores.Text = "Prestamos"
                vErrores.mensaje = ex.Message
                vErrores.ShowDialog()
            End Try

        Else
            vAdvertenciaForm.Text = "Prestamos"
            vAdvertenciaForm.mensaje = "Debe seleccionar al menos un prestamo"
            vAdvertenciaForm.ShowDialog()
        End If
    End Sub
    Private Sub btnEntregaColaborador_Click(sender As Object, e As EventArgs) Handles btnEntregaColaborador.Click
        With grdDatosPrestamos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        pagarPrestamos("E", "F")
    End Sub

    Public Sub pagarPrestamos(ByVal estatus_inicial As String, ByVal estatus_final As String)

        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vExitoForm As New ExitoForm
        Dim vErrores As New ErroresForm
        Dim objBU = New Nomina.Negocios.SolicitudPrestamoBU
        Dim ObjEnt = New Entidades.SolicitudPrestamo
        Dim vPedirFecha As New PedirFechaForm
        Dim bandera As Integer = 0

        For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
            If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = estatus_inicial Then
                bandera = 1
                Exit For
            End If
        Next
        If bandera = 1 Then
            Try
                Dim vDialogResult As New DialogResult
                vDialogResult = vPedirFecha.ShowDialog
                If vDialogResult = Windows.Forms.DialogResult.OK Then
                    Dim fechaEntrega As Date = vPedirFecha.pFecha
                    For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
                        If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = estatus_inicial Then
                            ObjEnt.Pestatus = estatus_final
                            ObjEnt.Pprestamoid = rowGrd.Cells("idprestamo").Value
                            ObjEnt.PgerenteId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            objBU.guardarEntregaDePrestamo(ObjEnt, fechaEntrega)
                        End If
                    Next
                    mostrarDatos()
                    vExitoForm.Text = "Prestamos"
                    vExitoForm.mensaje = "Se cambió el estado del préstamo a ENTREGADO correctamente"
                    vExitoForm.ShowDialog()
                Else
                    vAdvertenciaForm.Text = "Prestamos"
                    vAdvertenciaForm.mensaje = "Pago de prestamos cancelada"
                    vAdvertenciaForm.ShowDialog()
                End If
            Catch ex As Exception
                vErrores.Text = "Prestamos"
                vErrores.mensaje = ex.Message
                vErrores.ShowDialog()
            End Try
        Else
            vAdvertenciaForm.Text = "Prestamos"
            vAdvertenciaForm.mensaje = "Debe seleccionar al menos un prestamo"
            vAdvertenciaForm.ShowDialog()
        End If
    End Sub

    Public Sub RealizarSolicitudCajaChicaPrestaciones()
        Dim objBU As New SolicitudPrestamoBU
        Dim dtPrestacionRelacionada As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim exitoForm As New ExitoForm
        Dim IDSolicitudEmpresa As New DataTable
        Dim IDSolicitudColaboradores As New DataTable
        Dim MontoColaboradores As Integer = 0
        Dim MontoEmpresa As Integer = 0
        Dim ReposicionCajaChica = 1
        Dim dtActualizaDatosSolicitudesPrestaciones As New DataTable
        Dim LeyendaReposicionCajaChica As String = ""
        Dim SolicitudEmpresa As Integer = 0

        Try
            Dim vXmlCeldas As XElement = New XElement("Celdas")
            For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
                If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = "B" Then
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("PPrestamoID", rowGrd.Cells("idprestamo").Value))
                    vNodo.Add(New XAttribute("PColaboradorID", rowGrd.Cells("idcolaborador").Value))
                    vNodo.Add(New XAttribute("PConceptoID", rowGrd.Cells("ConceptoPrestacionID").Value))
                    vXmlCeldas.Add(vNodo)
                End If
            Next


            dtPrestacionRelacionada = objBU.ObtieneInformacionPrestacionesCajaChica(vXmlCeldas.ToString())

            If dtPrestacionRelacionada.Rows.Count > 0 Then
                vConfirmarForm.Text = "Prestamos"
                vConfirmarForm.mensaje = "Va a realizar una solicitud de efectivo de colaboradores a caja chica por $" + dtPrestacionRelacionada.Rows(0).Item("CantidadColaboradores").ToString + " Y una solicitud de efectivo de empresa a caja chica por $" + dtPrestacionRelacionada.Rows(0).Item("CantidadEmpresa").ToString + ". ¿Desea continuar?"

                Dim vDialogResult As New DialogResult
                vDialogResult = vConfirmarForm.ShowDialog
                Dim idCajas As Integer = 0
                If Not cmbCajas.DataSource Is Nothing Then
                    idCajas = cmbCajas.SelectedValue

                    MontoEmpresa = dtPrestacionRelacionada.Rows(0).Item("CantidadEmpresa")
                    MontoColaboradores = dtPrestacionRelacionada.Rows(0).Item("CantidadColaboradores")
                    LeyendaReposicionCajaChica = "REPOSICION CAJA CHICA PAGO DE : " + dtPrestacionRelacionada.Rows(0).Item("ConceptoPrestacion").ToString

                    If vDialogResult = Windows.Forms.DialogResult.OK Then
                        If Not idCajas = 0 Then

                            If MontoEmpresa > 0 Then
                                IDSolicitudEmpresa = objBU.EnviarSolicitudesPrestacionesCaja(idCajas, "EFECTIVO", MontoEmpresa, "", LeyendaReposicionCajaChica, ReposicionCajaChica)
                                IDSolicitudColaboradores = objBU.EnviarSolicitudesPrestacionesCaja(idCajas, "EFECTIVO", MontoColaboradores, "", "PAGO DE PRESTAMOS PRESTACION SAY", 0)
                                SolicitudEmpresa = 1
                            Else
                                IDSolicitudColaboradores = objBU.EnviarSolicitudesPrestacionesCaja(idCajas, "EFECTIVO", MontoColaboradores, "", "PAGO DE PRESTAMOS PRESTACION SAY", 0)
                                SolicitudEmpresa = 0
                            End If


                            Dim vXmlCeldasSolicitudes As XElement = New XElement("Celdas")
                            For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
                                If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = "B" Then
                                    Dim vNodo As XElement = New XElement("Celda")
                                    vNodo.Add(New XAttribute("PPrestamoID", rowGrd.Cells("idprestamo").Value))

                                    If SolicitudEmpresa = 1 Then
                                        vNodo.Add(New XAttribute("PSolicitudEmpresa", IDSolicitudEmpresa.Rows(0).Item(0).ToString))
                                    Else
                                        vNodo.Add(New XAttribute("PSolicitudEmpresa", 0))
                                    End If
                                    vNodo.Add(New XAttribute("PSolicitudColaboradores", IDSolicitudColaboradores.Rows(0).Item(0).ToString))
                                    vNodo.Add(New XAttribute("PConceptoID", rowGrd.Cells("ConceptoPrestacionID").Value))

                                    vXmlCeldasSolicitudes.Add(vNodo)
                                End If
                            Next
                            'Modificado 29/01/2021 
                            dtActualizaDatosSolicitudesPrestaciones = objBU.guardarSolicitudPrestacionID(vXmlCeldasSolicitudes.ToString())

                            mostrarDatos()
                            exitoForm.Text = "Prestamos"
                            exitoForm.mensaje = "Se realizó la solicitud a caja chica correctamente"
                            exitoForm.ShowDialog()
                        Else
                            advertencia.Text = "Prestamos"
                            advertencia.mensaje = "No tiene asignada una caja chica. Favor de contactar al área de sistemas"
                            advertencia.ShowDialog()
                        End If
                    Else
                        advertencia.Text = "Prestamos"
                        advertencia.mensaje = "Solicitud a caja chica cancelada"
                        advertencia.ShowDialog()
                    End If
                Else
                    advertencia.Text = "Prestamos"
                    advertencia.mensaje = "No tiene asignada una caja chica. Favor de contactar al área de sistemas"
                    advertencia.ShowDialog()
                End If

            Else
                advertencia.mensaje = "No existen datos para generar salidas."
                advertencia.ShowDialog()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub solicitarFinanzas()
        Dim bandera As Integer = 0
        Dim acumulador As Integer = 0
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vExitoForm As New ExitoForm
        Dim vErrores As New ErroresForm
        Dim objEnt As New Entidades.SolicitudPrestamo
        Dim IDSolicitud As DataTable
        Dim CajasBU As New Negocios.CajasBU
        Dim objBU As New Negocios.SolicitudPrestamoBU
        Dim error1 As Boolean = False

        For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
            If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = "B" Then
                bandera = 1
                acumulador += rowGrd.Cells("prestamo").Value
                Distintivo = rowGrd.Cells("Distintivo").Value
            End If
        Next

        'Si el usuario selecciona varios prestamos validar
        'QUE SEAN SOLO PRESTAMOS NORMALES O SOLO ESPECIALES 
        'QUE SEAN PRESTACIONES DEL MISMO CONCEPTO

        Dim registrosSeleccionados As Integer = 0
        Dim DtPrestamosSeleccionados As New DataTable
        DtPrestamosSeleccionados.Columns.Add("tipoPrestamo")
        DtPrestamosSeleccionados.Columns.Add("conceptoId")

        For Each RowGrd As UltraGridRow In grdDatosPrestamos.Rows
            If RowGrd.Cells("Seleccion").Value And RowGrd.Cells("estatus").Value = "B" Then
                Dim fila As DataRow = DtPrestamosSeleccionados.NewRow()
                fila("tipoPrestamo") = RowGrd.Cells("Distintivo").Value ''VERIFICAR QUE SEA LA COMUNA QUE NOS INDIQUE QUE ES PRESTAMOS ESPECIAL
                fila("conceptoId") = RowGrd.Cells("ConceptoPrestacionID").Value ''
                DtPrestamosSeleccionados.Rows.Add(fila)
                registrosSeleccionados += 1
            End If
        Next

        If registrosSeleccionados > 1 Then
            Dim totalPrestamosEspeciales As Integer = 0
            Dim totalPrestacionSAY As Integer = 0
            Dim totalPrestamos As Integer = 0
            Dim concepto As Integer = 0
            Dim totalConcepto As Integer = 0

            totalPrestamosEspeciales = DtPrestamosSeleccionados.AsEnumerable.Where(Function(x) CStr(x.Item("tipoPrestamo")) = "PE").Count
            totalPrestacionSAY = DtPrestamosSeleccionados.AsEnumerable.Where(Function(x) CStr(x.Item("tipoPrestamo")) = "PS").Count
            totalPrestamos = DtPrestamosSeleccionados.AsEnumerable.Where(Function(x) CStr(x.Item("tipoPrestamo")) = "").Count

            If totalPrestamosEspeciales > 0 Then
                    If totalPrestacionSAY > 0 Or totalPrestamos > 0 Then
                        error1 = True
                        vAdvertenciaForm.Text = "Prestamos"
                        vAdvertenciaForm.mensaje = "Solo se pueden solicitar prestamos del mismo tipo."
                        vAdvertenciaForm.ShowDialog()
                    End If
                Else
                    If totalPrestacionSAY > 0 Then
                        If totalPrestamosEspeciales > 0 Or totalPrestamos > 0 Then
                            error1 = True
                            vAdvertenciaForm.Text = "Prestamos"
                            vAdvertenciaForm.mensaje = "Solo se pueden solicitar prestamos del mismo tipo."
                            vAdvertenciaForm.ShowDialog()
                        End If
                    Else
                        If totalPrestamos > 0 Then
                            If totalPrestamosEspeciales > 0 Or totalPrestacionSAY > 0 Then
                                error1 = True
                                vAdvertenciaForm.Text = "Prestamos"
                                vAdvertenciaForm.mensaje = "Solo se pueden solicitar prestamos del mismo tipo."
                                vAdvertenciaForm.ShowDialog()
                            End If
                        End If

                    End If
                End If
            If error1 = False Then
                concepto = CInt(DtPrestamosSeleccionados.Rows().Item(0).Item(1).ToString())
                totalConcepto = DtPrestamosSeleccionados.AsEnumerable.Where(Function(x) x.Item("conceptoId") = concepto).Count

                If totalConcepto <> registrosSeleccionados Then
                    error1 = True
                    vAdvertenciaForm.Text = "Prestamos"
                    vAdvertenciaForm.mensaje = "Solo se pueden solicitar prestaciones con el mismo concepto."
                    vAdvertenciaForm.ShowDialog()
                End If
            End If
        End If


        If error1 = False Then
            If Distintivo = "PS" Then
                Try
                    RealizarSolicitudCajaChicaPrestaciones()
                    bandera = 0
                Catch ex As Exception

                End Try
            End If

            If Distintivo = "PE" Then
                PrestamoEspecial = "S"
            Else
                PrestamoEspecial = "N"
            End If



            If bandera = 1 Then
                Try
                    vConfirmarForm.Text = "Prestamos"
                    vConfirmarForm.mensaje = "Va a realizar una solicitud de efectivo a caja chica por $" + acumulador.ToString + ". ¿Desea continuar?"
                    Dim vDialogResult As New DialogResult
                    vDialogResult = vConfirmarForm.ShowDialog
                    Dim idCajas As Integer = 0
                    If Not cmbCajas.DataSource Is Nothing Then
                        idCajas = cmbCajas.SelectedValue

                        If vDialogResult = Windows.Forms.DialogResult.OK Then
                            If Not idCajas = 0 Then

                                IDSolicitud = CajasBU.EnviarSolicitudesPrestamoCaja(idCajas, "EFECTIVO", acumulador, "", "PAGO DE PRESTAMOS", PrestamoEspecial)
                                For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
                                    If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = "B" Then
                                        objEnt.Pprestamoid = rowGrd.Cells("idprestamo").Value
                                        objEnt.Psolicitudid = IDSolicitud.Rows(0).Item(0).ToString
                                        objBU.guardarIdSolicitudPrestamos(objEnt)

                                    End If
                                Next

                                mostrarDatos()
                                vExitoForm.Text = "Prestamos"
                                vExitoForm.mensaje = "Se realizó la solicitud a caja chica correctamente"
                                vExitoForm.ShowDialog()
                            Else
                                vAdvertenciaForm.Text = "Prestamos"
                                vAdvertenciaForm.mensaje = "No tiene asignada una caja chica. Favor de contactar al área de sistemas"
                                vAdvertenciaForm.ShowDialog()
                            End If
                        Else
                            vAdvertenciaForm.Text = "Prestamos"
                            vAdvertenciaForm.mensaje = "Solicitud a caja chica cancelada"
                            vAdvertenciaForm.ShowDialog()
                        End If
                    Else
                        vAdvertenciaForm.Text = "Prestamos"
                        vAdvertenciaForm.mensaje = "No tiene asignada una caja chica. Favor de contactar al área de sistemas"
                        vAdvertenciaForm.ShowDialog()
                    End If

                Catch ex As Exception
                    vErrores.Text = "Prestamos"
                    vErrores.mensaje = ex.Message
                    vErrores.ShowDialog()
                End Try
            End If
        End If

    End Sub
    Sub cargarPermisos()
        perAbonoExtraordinario = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PRES_EXTRA", "READ")
        perAutorizarDirector = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "DIRECTOR")
        perAutorizarGerente = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "GERENTE")
        preAutorizar = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "READ")
        preCancelar = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_CANCELAR", "READ")
        preEditar = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_EDITAR_PRES", "READ")
        preEditarPositivo = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_EDITAR_PRES", "EDITARABONOS")
        preEditarNegativo = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_EDITAR_PRES", "EDITARABONOSNEGATIVOS")
        preEditarAbono = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_LISTAPRESTAMOS", "NOM_PRES_EDITAB")
        prepPAgos = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_CONFIRMACIONNAVE", "READ")
        prePreAutorizacion = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_PREAUT", "READ")
        preSolicitarFinanzas = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_FINANZAS", "READ")
        preSolicitarPrestamos = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_SOL", "READ")
        btnExportar.Visible = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_LISTAPRESTAMOS", "NOM_PRES_EXPORTAR")
        lblExportar.Visible = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_LISTAPRESTAMOS", "NOM_PRES_EXPORTAR")
        preSolicitarPrestamoEspecial = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_LISTAPRESTAMOS", "NOM_PRES_SOL_ESP")
        preSolicitarPrestacionesSAY = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_LISTAPRESTAMOS", "NOM_PRES_SAY")
    End Sub

    ''LLENAR LA CONFIGURACION DE LOS PRESTAMOS
    Public Sub AgregarDatos(ByVal ConfiguracionPrestamos As Entidades.ConfiguracionPrestamos)
        Dim MaxNave = ConfiguracionPrestamos.PMontoMaximoPorNave
        lblGerente.Text = ConfiguracionPrestamos.PAutorizacionGerente
        lblDirector.Text = ConfiguracionPrestamos.PAutorizacionDirector
    End Sub

    Public Sub llenarconfiguracionPrestamo()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.ConfiguracionPrestamos)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))

            listaConfiguracionPrestamos = prestamosBU.ListaConfiguracionPrestamos(idNave)

            For Each objeto As Entidades.ConfiguracionPrestamos In listaConfiguracionPrestamos
                AgregarDatos(objeto)
            Next
        Catch ex As Exception
        End Try
    End Sub
    ''--------------------------------------------------------------------------------
    Public Sub mostrarDatos()
        grdDatosPrestamos.DataSource = Nothing
        Dim vErrorForm As New ErroresForm
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            Dim idNave As Integer = (Int(cmbNave.SelectedValue))
            Dim estatus As String = cmbEstatus.SelectedItem
            Dim fechainicio As DateTime
            Dim fechafin As DateTime
            Dim FechaI As String = ""
            Dim FechaF As String = ""
            Dim tipo As Integer = 0
            UseExternalSummaryCalculator = DefaultableBoolean.True
            'grdAutorizacion.Rows.Clear()
            estatus = obtenerEstatusReal(estatus)
            If chkFecha.Checked = True Then
                If rdbRango.Checked = True Then
                    fechainicio = DtpFechaInicio.Value.ToShortDateString
                    fechafin = DtpFechaFin.Value.ToShortDateString
                    FechaI = fechainicio.ToString("yyyy/dd/MM")
                    FechaF = fechafin.ToString("yyyy/dd/MM")

                ElseIf rdbPeriodo.Checked = True Then
                    fechainicio = fechaInicial.ToShortDateString
                    fechafin = Fechafinal.ToShortDateString
                    FechaI = fechainicio.ToString("yyyy/dd/MM")
                    FechaF = fechafin.ToString("yyyy/dd/MM")
                End If
                If rdbFechaSolicitud.Checked = True Then
                    tipo = 1
                ElseIf rdbFehcaEntrega.Checked = True Then
                    tipo = 2
                End If

            End If
            '   llenarTablaPrestamos(idNave, estatus, FechaI, FechaF, tipo)
            cargarDatosGrid(idNave, estatus, FechaI, FechaF, tipo)
        Catch ex As Exception
            vErrorForm.Text = "Prestamos"
            vErrorForm.mensaje = ex.Message
            vErrorForm.Show()
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub
    Public Sub formatoUltra()
        With grdDatosPrestamos.DisplayLayout.Bands(0)
            .Columns("idcolaborador").Hidden = True
            .Columns("idprestamo").Hidden = True
            .Columns("estatus").Hidden = True
            .Columns("estatus2").Hidden = True
            .Columns("tipointeres").Hidden = True
            .Columns("interes").Hidden = True
            .Columns("activo").Hidden = True
            .Columns("PrestamoEspecial").Hidden = True
            .Columns("PrestacionSAY").Hidden = True
            .Columns("ConceptoPrestacionID").Hidden = True

            .Columns("seleccion").Header.Caption = "Todos"
            .Columns("color").Header.Caption = ""
            .Columns("nombre").Header.Caption = "Nombre del Colaborador"
            .Columns("anios").Header.Caption = "Años"
            .Columns("meses").Header.Caption = "Meses"
            .Columns("faltas").Header.Caption = "Faltas"
            .Columns("fecha").Header.Caption = "Fecha Solicitud"
            .Columns("fechaentrega").Header.Caption = "Fecha Entrega"
            .Columns("periodo").Header.Caption = "Semana"
            .Columns("prestamo").Header.Caption = "Monto solicitado"
            .Columns("abono").Header.Caption = "Abono"
            .Columns("saldo").Header.Caption = "Saldo"
            .Columns("saldotermino").Header.Caption = "Saldo Término"
            .Columns("caja").Header.Caption = "Ahorro"
            .Columns("Intereses").Header.Caption = "Interés"
            .Columns("Distintivo").Header.Caption = "Tipo"
            '.Columns("Distintivo").Header.Caption = "Tipo"

            .Columns("ConceptoPrestacion").Header.Caption = "Concepto"
            .Columns("estatusReal").Hidden = True
            .Columns("Convenio").Hidden = True

            ' .Columns("PrestamoEspecial").Header.Caption = " "
            ' .Columns("PrestacionSAY").Header.Caption = " "

            .Columns("seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
            .Columns("seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection

            .Columns("seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("puesto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("anios").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("meses").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("faltas").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prestamo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("saldo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("saldotermino").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("caja").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaentrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("periodo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("abono").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Intereses").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Distintivo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ConceptoPrestacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            ' .Columns("PrestamoEspecial").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("PrestacionSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("faltas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("prestamo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("saldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("saldotermino").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("periodo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("caja").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("abono").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("anios").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("meses").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("meses").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Intereses").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .Columns("prestamo").Format = "###,###,##0"
            .Columns("Abono").Format = "###,###,##0"
            .Columns("saldo").Format = "###,###,##0"
            .Columns("Intereses").Format = "###,###,##0"
            .Columns("caja").Format = "###,###,##0"
            .Columns("saldotermino").Format = "###,###,##0"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdDatosPrestamos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatosPrestamos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatosPrestamos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatosPrestamos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdDatosPrestamos.DisplayLayout.Override.RowSelectorWidth = 40
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("seleccion").Width = 15
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("nombre").Width = 130
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("color").Width = 8
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("caja").Width = 25
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("saldo").Width = 25
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("saldotermino").Width = 35
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("periodo").Width = 25
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("prestamo").Width = 35
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("Intereses").Width = 30
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("faltas").Width = 18
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("anios").Width = 13
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("meses").Width = 18
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("fecha").Width = 38
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("fechaentrega").Width = 30
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("abono").Width = 20
        ' grdDatosPrestamos.DisplayLayout.Bands(0).Columns("PrestamoEspecial").Width = 10
        ' grdDatosPrestamos.DisplayLayout.Bands(0).Columns("PrestacionSAY").Width = 10
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("Distintivo").Width = 13
        grdDatosPrestamos.DisplayLayout.Bands(0).Columns("ConceptoPrestacion").Width = 70


        Dim sumarPrestamo As UltraGridColumn = grdDatosPrestamos.DisplayLayout.Bands(0).Columns("prestamo")

        Dim prestamo As SummarySettings = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add("TOTAL", SummaryType.Sum, sumarPrestamo)
        Dim saldo As SummarySettings = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDatosPrestamos.DisplayLayout.Bands(0).Columns("saldo"))
        Dim saldotermino As SummarySettings = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDatosPrestamos.DisplayLayout.Bands(0).Columns("saldotermino"))
        Dim caja As SummarySettings = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDatosPrestamos.DisplayLayout.Bands(0).Columns("caja"))
        Dim Intereses As SummarySettings = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDatosPrestamos.DisplayLayout.Bands(0).Columns("Intereses"))


        prestamo.DisplayFormat = "{0:#,##0}"
        prestamo.Appearance.TextHAlign = HAlign.Right
        saldo.DisplayFormat = "{0:#,##0}"
        saldo.Appearance.TextHAlign = HAlign.Right
        saldotermino.DisplayFormat = "{0:#,##0}"
        saldotermino.Appearance.TextHAlign = HAlign.Right
        caja.DisplayFormat = "{0:#,##0}"
        caja.Appearance.TextHAlign = HAlign.Right
        Intereses.DisplayFormat = "{0:#,##0}"
        Intereses.Appearance.TextHAlign = HAlign.Right

        grdDatosPrestamos.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"


        'Dim tmpSummary As SummarySettings
        'Try
        '    If grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Exists("sumaprestamo") Then
        '        tmpSummary = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries("sumaprestamo")
        '        grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Remove(tmpSummary)
        '        tmpSummary = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries("sumasaldo")
        '        grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Remove(tmpSummary)
        '        tmpSummary = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries("sumasaldotermino")
        '        grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Remove(tmpSummary)
        '        tmpSummary = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries("sumacaja")
        '        grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Remove(tmpSummary)

        '    End If


        '    grdDatosPrestamos.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        '    tmpSummary = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add("sumaprestamo", SummaryType.External, grdDatosPrestamos.DisplayLayout.Bands(0).Columns("prestamo"))
        '    tmpSummary.DisplayFormat = "{0:##,##0}"
        '    tmpSummary.Appearance.TextHAlign = HAlign.Right
        '    tmpSummary = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add("sumasaldo", SummaryType.External, grdDatosPrestamos.DisplayLayout.Bands(0).Columns("saldo"))
        '    tmpSummary.DisplayFormat = "{0:##,##0}"
        '    tmpSummary.Appearance.TextHAlign = HAlign.Right
        '    tmpSummary = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add("sumasaldotermino", SummaryType.External, grdDatosPrestamos.DisplayLayout.Bands(0).Columns("saldotermino"))
        '    tmpSummary.DisplayFormat = "{0:##,##0}"
        '    tmpSummary.Appearance.TextHAlign = HAlign.Right
        '    tmpSummary = grdDatosPrestamos.DisplayLayout.Bands(0).Summaries.Add("sumacaja", SummaryType.External, grdDatosPrestamos.DisplayLayout.Bands(0).Columns("caja"))
        '    tmpSummary.DisplayFormat = "{0:##,##0}"
        '    tmpSummary.Appearance.TextHAlign = HAlign.Right
        'Catch ex As Exception

        'End Try
    End Sub

    Public Sub llenarTablaPrestamos(ByVal idNave As Integer, ByVal estatus As String, ByVal fechaI As String, ByVal fechaf As String, ByVal tipo As Integer)
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            valorCajaAhorro = 0
            valorPrestamos = 0
            valorSaldo = 0
            valorSaldoTermino = 0
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamosfiltro(idNave, estatus, fechaI, fechaf, tipo)
            Dim dtDatosInicializar As New DataTable
            dtDatosInicializar.Columns.Add("idcolaborador")
            dtDatosInicializar.Columns.Add("idprestamo")
            dtDatosInicializar.Columns.Add("color")
            dtDatosInicializar.Columns.Add("seleccion")
            dtDatosInicializar.Columns.Add("estatus")
            dtDatosInicializar.Columns.Add("nombre")
            'dtDatosInicializar.Columns.Add("puesto")
            dtDatosInicializar.Columns.Add("anios")
            dtDatosInicializar.Columns.Add("meses")
            dtDatosInicializar.Columns.Add("faltas")
            dtDatosInicializar.Columns.Add("fecha")
            dtDatosInicializar.Columns.Add("fechaentrega")
            dtDatosInicializar.Columns.Add("periodo")
            dtDatosInicializar.Columns.Add("estatus2")
            dtDatosInicializar.Columns.Add("prestamo")
            dtDatosInicializar.Columns.Add("Intereses")
            dtDatosInicializar.Columns.Add("abono")
            dtDatosInicializar.Columns.Add("saldo")
            dtDatosInicializar.Columns.Add("saldotermino")
            dtDatosInicializar.Columns.Add("caja")
            dtDatosInicializar.Columns.Add("estatusReal")

            Dim color As Color
            'dtDatosInicializar.Rows.InsertAt(dtDatosInicializar.NewRow, 0)
            grdDatosPrestamos.DataSource = dtDatosInicializar
            For Each Prestamos As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                ''AgregarFilaDePrestamos(objeto)
                Dim tipoInteres As String
                tipoInteres = Prestamos.Ptipointeres


                Dim estatus2 As String = ""
                Dim estatusReal As String = ""
                estatus2 = Prestamos.Pestatus
                Dim estatus3 As String = ""
                If estatus2.Equals("A") Then
                    estatus3 = "TODOS"
                    estatusReal = "SOLICITADO"
                    color = Color.FromArgb(255, 251, 184)
                ElseIf estatus2.Equals("B") Then
                    estatus3 = "SOLICITADO"
                    estatusReal = "AUTORIZADO"
                    color = Color.FromArgb(150, 207, 58)
                ElseIf estatus2.Equals("C") Then
                    estatus3 = "AUTORIZADO"
                    color = Color.FromArgb(238, 156, 242)
                ElseIf estatus2.Equals("D") Then
                    estatus3 = "SOLICITADO CC"
                    estatusReal = "SOLICITADO CC"
                    color = Color.FromArgb(8, 138, 133)
                ElseIf estatus2.Equals("E") Then
                    estatus3 = "RECIBIDO"
                    estatusReal = "ENTREGADO NAVE"
                    color = Color.FromArgb(112, 238, 156)
                ElseIf estatus2.Equals("F") Then
                    estatus3 = "ENTREGADO"
                    estatusReal = "ENTREGADO COLABORADOR"
                    color = Color.FromArgb(254, 246, 13)
                ElseIf estatus2.Equals("G") Then
                    estatus3 = "EN COBRANZA"
                    estatusReal = "EN COBRANZA"
                    color = Color.FromArgb(100, 50, 100)
                ElseIf estatus2.Equals("H") Then
                    estatus3 = "LIQUIDADO"
                    estatusReal = "LIQUIDADO"
                    color = Color.FromArgb(172, 238, 155)
                ElseIf estatus2.Equals("I") Then
                    estatus3 = "CANCELADO"
                    estatusReal = "CANCELADO"
                    color = Color.FromArgb(235, 71, 71)
                ElseIf estatus2.Equals("J") Then
                    estatus3 = "RECHAZADO"
                    estatusReal = "RECHAZADO"
                    color = Color.FromArgb(242, 135, 115)
                End If

                ''LLENADO DE DATOS LABORALES
                Dim DatosLaborales As New Entidades.ColaboradorLaboral
                Dim DatosLaboralesBU As New Nomina.Negocios.ColaboradorLaboralBU

                DatosLaborales = DatosLaboralesBU.buscarInformacionLaboral(Prestamos.Pcolaborador.PColaboradorid)

                ''LLENADO DE DATOS REALES
                Dim DatosReales As New Entidades.ColaboradorReal
                Dim DatosRealesBU As New Nomina.Negocios.ColaboradorRealBU

                DatosReales = DatosRealesBU.BuscarColaboradorReal(Prestamos.Pcolaborador.PColaboradorid)

                ''Calcular antiguedad
                Dim FechaActual As Date = DateTime.Now().ToShortDateString()
                Dim anios As Int32 = 0
                Dim meses As Int32 = 0
                Dim dias As Int32 = 0
                Dim diasme As Int32 = 0
                Dim DiasTrabajados As Integer

                anios = 0
                meses = 0
                diasme = 0
                Dim FechaIngreso As Date = DatosReales.PFecha
                DiasTrabajados = (FechaActual - FechaIngreso).TotalDays

                anios = DiasTrabajados \ 365
                meses = (DiasTrabajados Mod 365) \ 30.4
                diasme = (DiasTrabajados Mod 365) Mod 30.4
                Dim mesesTotal As Double = Math.Round(meses + (diasme / 30.4), 1)
                If meses = 12 Then
                    meses = 0
                    anios += 1
                End If

                ''INASISTENCIAs
                Dim listaAsistencia As New List(Of Entidades.CalcularNominaReal)
                Dim ObjNominaBU As New Negocios.CalcularNominaRealBU
                Dim FechaFin As DateTime = Now.Date.ToShortDateString
                Dim FechaInicio As DateTime
                Dim inasistencias As Double = 0
                FechaInicio = DateAdd(DateInterval.Day, -30, FechaFin)

                listaAsistencia = ObjNominaBU.CorteChecadorFaltasUltimoMes(Prestamos.Pcolaborador.PColaboradorid, FechaInicio.ToShortDateString, FechaFin.ToShortDateString)

                For Each inasi As Entidades.CalcularNominaReal In listaAsistencia
                    inasistencias += inasi.Pchecador.PInasistencia
                Next

                Dim objBu As New Negocios.SolicitudPrestamoBU
                Dim listaId As List(Of Entidades.SolicitudPrestamo)
                Dim montoAhorro As Double = 0
                '   Dim contador As Integer = 0
                listaId = objBu.CajaDeAhorroMonto(Prestamos.Pcolaborador.PColaboradorid, idCajaAhorro)

                For Each dato As Entidades.SolicitudPrestamo In listaId
                    montoAhorro += dato.PCajaAhorro.pMontoAhorro
                    '  contador += 1
                Next
                Dim filaPres As UltraGridRow = grdDatosPrestamos.DisplayLayout.Bands(0).AddNew()
                ''If contador > 0 Then

                'Metodo
                Dim saldoalTermino As Integer = 0
                If Prestamos.Pestatus = "G" Or Prestamos.Pestatus = "F" Then
                    saldoalTermino = calcularSaldoTermino(tipoInteres, CDbl(Prestamos.Pinteres), CInt(Prestamos.Psaldo), CInt(Prestamos.Pabono))
                End If

                'If chkSaldoTermino.Checked = True Then
                '    saldoalTermino = calcularSaldoTermino(tipoInteres, CDbl(Prestamos.Pinteres), CInt(Prestamos.Psaldo), CInt(Prestamos.Pabono))
                'End If

                If cmbEstatus.Text = "TODOS" Then
                    If Not New String() {"I", "J"}.Contains(estatus2) Then
                        valorPrestamos = valorPrestamos + CInt(Prestamos.Pmontoprestamo)
                        valorSaldo = valorSaldo + CInt(Prestamos.Psaldo)
                        valorCajaAhorro = valorCajaAhorro + CInt(montoAhorro)
                        valorSaldoTermino = valorSaldoTermino + saldoalTermino
                    End If
                Else
                    valorPrestamos = valorPrestamos + CInt(Prestamos.Pmontoprestamo)
                    valorSaldo = valorSaldo + CInt(Prestamos.Psaldo)
                    valorCajaAhorro = valorCajaAhorro + CInt(montoAhorro)
                    valorSaldoTermino = valorSaldoTermino + saldoalTermino
                End If

                'Fin del metodo
                If tipoInteres.Equals("I") Then

                    tipoInteres = "SIN INTERES"
                Else
                    If tipoInteres.Equals("S") Then
                        tipoInteres = "INTERES SOBRE SALDO"

                    End If

                End If

                Dim fechaEntregas As String = ""
                Dim periodonominacaja As String = ""
                Dim fechaTemp As DateTime
                fechaTemp = Prestamos.PfechaEntrega.ToShortDateString
                If Not Prestamos.PfechaEntrega.ToShortDateString = "01/01/0001" Then
                    fechaEntregas = Prestamos.PfechaEntrega.ToShortDateString
                    fechaTemp = Prestamos.PfechaEntrega
                    periodonominacaja = CStr(objBu.obtenerPeriodoCaja(fechaEntregas, cmbNave.SelectedValue.ToString))

                End If

                filaPres.Cells("idcolaborador").Value = Prestamos.Pcolaborador.PColaboradorid
                filaPres.Cells("idprestamo").Value = Prestamos.Pprestamoid
                filaPres.Cells("Seleccion").Value = False
                filaPres.Cells("estatus").Value = estatus2
                filaPres.Cells("color").Appearance.BackColor = color
                filaPres.Cells("nombre").Value = Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno
                'filaPres.Cells("puesto").Value = DatosLaborales.PPuestoId.PNombre.ToString
                filaPres.Cells("anios").Value = anios.ToString
                filaPres.Cells("meses").Value = meses.ToString
                filaPres.Cells("fecha").Value = Prestamos.PfechaCreacion.ToShortDateString
                filaPres.Cells("faltas").Value = inasistencias
                filaPres.Cells("prestamo").Value = Prestamos.Pmontoprestamo.ToString("N0")
                filaPres.Cells("abono").Value = Prestamos.Pabono.ToString("N0")
                filaPres.Cells("saldo").Value = Prestamos.Psaldo.ToString("N0")
                filaPres.Cells("caja").Value = montoAhorro.ToString("N0")
                filaPres.Cells("saldotermino").Value = saldoalTermino.ToString("N0")
                filaPres.Cells("periodo").Value = periodonominacaja.ToString
                filaPres.Cells("estatus2").Value = estatus3
                'filaPres.Cells("fechaentrega").Value = fechaEntregas

                filaPres.Cells("fechaentrega").Value = Prestamos.PfechaEntrega
                filaPres.Cells("estatusReal").Value = estatusReal
                'grdAutorizacion.Rows.Add(Prestamos.Pprestamoid, grdAutorizacion.Rows.Count + 1, Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno, Prestamos.PfechaCreacion.ToShortDateString, DatosLaborales.PPuestoId.PNombre.ToString, anios.ToString, meses.ToString, inasistencias, montoAhorro.ToString("N0"), Prestamos.Pinteres, tipoInteres, Prestamos.Pabono.ToString("N0"), Prestamos.Psaldo.ToString("N0"), Prestamos.Psemanas, Prestamos.Pmontoprestamo.ToString("N0"), estatus2.ToUpper, Prestamos.Pcolaborador.PColaboradorid.ToString, Prestamos.PfechaGerente.ToShortDateString, Prestamos.PfechaDirector.ToShortDateString, Prestamos.Pfechamodificacion.ToShortDateString)
                ''End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function calcularSaldoTermino(ByVal tipoInteres As String, ByVal interes As Double, ByVal saldoAnterior As Integer, ByVal abono As Integer) As Integer
        Dim saldoActual As Integer = 0
        Dim totalinteres As Integer
        If tipoInteres = "S" Then
        Else
            interes = 0
        End If
        interes = 7 * (interes / 30.4)
        interes = interes / 100
        If saldoAnterior > 0 Then
            While saldoAnterior > 0
                totalinteres = saldoAnterior * interes
                If saldoAnterior > abono Then
                    saldoAnterior = saldoAnterior - (abono - totalinteres)
                Else
                    abono = saldoAnterior
                    totalinteres = 0
                    saldoAnterior = 0
                End If
                saldoActual = saldoActual + abono
            End While
        End If
        Return saldoActual
    End Function

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 140
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnConsultaAbono_Click(sender As Object, e As EventArgs) Handles btnConsultaAbono.Click
        ConsultarAbono()
    End Sub

    Private Sub ConsultarAbono()
        With grdDatosPrestamos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        Dim ConsultarSaldo As New ConsultarSaldoPrestamos
        ConsultarSaldo.PIDColaborador = CInt(grdDatosPrestamos.ActiveRow.Cells("idcolaborador").Value.ToString)
        ConsultarSaldo.pIdPrestamo = grdDatosPrestamos.ActiveRow.Cells("idprestamo").Value
        ConsultarSaldo.Pabbonos = grdDatosPrestamos.ActiveRow.Cells("abono").Value
        ConsultarSaldo.pMonto = grdDatosPrestamos.ActiveRow.Cells("prestamo").Value
        ConsultarSaldo.pfechas = grdDatosPrestamos.ActiveRow.Cells("fecha").Value
        ConsultarSaldo.pestatus = grdDatosPrestamos.ActiveRow.Cells("estatus").Value
        ConsultarSaldo.PInteresInicial = grdDatosPrestamos.ActiveRow.Cells("Intereses").Value
        'ConsultarSaldo.pagoSemanalQuincenal = 
        ConsultarSaldo.ShowDialog()
    End Sub

    Public Sub ImprimirReporteAbonosExtraordinarios()
        Dim objPrestamosBU As New Negocios.ConsultarPrestamosBU
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim Prestamos As New DataSet("Prestamos")
        Dim dtAbonos As New DataTable("dtAbonos")
        Dim FechaInicio As New DateTime
        Dim FechaFin As New DateTime
        Dim fechas As String = ""

        If chkFecha.Checked = True Then
            If rdbRango.Checked = True Or rdbFechaSolicitud.Checked = True Then
                FechaInicio = DtpFechaInicio.Value.ToShortDateString
                FechaFin = DtpFechaFin.Value.ToShortDateString
            ElseIf rdbPeriodo.Checked = True Then
                FechaInicio = fechaInicial.ToShortDateString
                FechaFin = Fechafinal.ToShortDateString
            End If

            Try

                Me.Cursor = Cursors.WaitCursor
                dtAbonos = objPrestamosBU.ImprimirConcentradoAbonosExtraordinarios(FechaInicio, FechaFin, cmbNave.SelectedValue)
                'SUMA SALDO ANTERIOR
                Dim totalSaldoPrestamo = (From a In dtAbonos.AsEnumerable()
                                          Select a.Field(Of Decimal)("SaldoPrestamo")).Sum()
                'SUMA IMPORTE ABONO 
                Dim totalImporteAbono = (From a In dtAbonos.AsEnumerable()
                                         Select a.Field(Of Decimal)("ImporteAbono")).Sum()

                Dim total As Integer = 0

                total = CInt(totalSaldoPrestamo) - CInt(totalImporteAbono)

                Prestamos.DataSetName = "Prestamos"

                dtAbonos.TableName = "dtAbonos"

                If dtAbonos.Rows.Count > 0 Then
                    Prestamos.Tables.Add(dtAbonos)

                    Dim objBU As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = objBU.LeerReporteporClave("RPT_PRESTAMO_ABONO_EXTRA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre.Trim + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()
                    fechas = "ABONOS DEL " + DtpFechaInicio.Value.ToShortDateString + " AL " + DtpFechaFin.Value.ToShortDateString
                    reporte("NaveNombre") = cmbNave.Text
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave((Int(cmbNave.SelectedValue)))
                    reporte("Fecha") = fechas
                    reporte("Total") = total

                    reporte.Dictionary.Clear()
                    reporte.RegData(Prestamos)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()

                Else
                    vAdvertenciaForm.Text = "Préstamos"
                    vAdvertenciaForm.mensaje = "No hay datos para mostrar."
                    vAdvertenciaForm.Show()
                End If

            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            vAdvertenciaForm.Text = "Prestamos"
            vAdvertenciaForm.mensaje = "Debe de seleccionar un rango de fechas o un periodo de nómina"
            vAdvertenciaForm.Show()
        End If
    End Sub


    Public Sub imprimirReporteNave()
        Dim Destajos = New DataSet("Prestamos Nomina")
        Destajos.DataSetName = "Prestamos Nomina"
        Dim ticketsBU As New Negocios.TicketsBU
        Dim tablaTickets As New DataTable("Prestamos")
        tablaTickets = obtnerValoresDatagrid()

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_PRES_NAVE")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre.Trim + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()

        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave((Int(cmbNave.SelectedValue)))
        Dim tabla As New DataTable
        Dim fechas As String = ""
        If rdbRango.Checked = True Then
            If rdbFechaSolicitud.Checked = True Then
                fechas = "FECHAS DE SOLICITUD DEL " + DtpFechaInicio.Value.ToShortDateString + " AL " + DtpFechaFin.Value.ToShortDateString
            Else
                fechas = "FECHAS DE ENTREGA DEL " + DtpFechaInicio.Value.ToShortDateString + " AL " + DtpFechaFin.Value.ToShortDateString
            End If

        ElseIf rdbPeriodo.Checked = True Then
            fechas = cmbPeriodoNomina.Text
        End If

        If Not cmbEstatus.Text = "TODOS" Then
            fechas += ", ESTATUS: " + cmbEstatus.Text
        End If



        reporte("Fecha") = fechas
        Dim naveNombre As New Entidades.Naves
        naveNombre = cmbNave.SelectedItem
        reporte("Nave") = naveNombre.PNombre

        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToUpper
        reporte("elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToUpper

        tablaTickets.TableName = "Prestamos"
        Destajos.Tables.Add(tablaTickets)

        reporte.RegData(Destajos)
        reporte.Show()
    End Sub
    Public Function obtnerValoresDatagrid() As DataTable
        Dim tabladatos As New DataTable
        Dim band As UltraGridBand = grdDatosPrestamos.DisplayLayout.Bands(0)
        tabladatos.Columns.Add("Consecutivo", System.Type.GetType("System.Int32"))
        For Each column As UltraGridColumn In band.Columns
            tabladatos.Columns.Add(column.Key, column.DataType)
        Next
        Dim i As Integer = 0
        Dim contador As Integer = 1
        For Each row As UltraGridRow In grdDatosPrestamos.Rows
            Dim cellValues As List(Of Object) = New List(Of Object)(row.Cells.Count)
            For Each cell As UltraGridCell In row.Cells
                If i = 0 Then
                    cellValues.Add(contador)
                    Try
                        cellValues.Add(CDbl(cell.Value))
                    Catch ex As Exception
                        cellValues.Add(cell.Value)
                    End Try
                    i = 1
                Else
                    Try
                        cellValues.Add(CDbl(cell.Value))
                    Catch ex As Exception
                        cellValues.Add(cell.Value)
                    End Try

                End If

            Next
            i = 0
            contador += 1
            tabladatos.Rows.Add(cellValues.ToArray())
        Next
        Return tabladatos
    End Function

    Private Sub pnlSolicitado_Paint(sender As Object, e As PaintEventArgs) Handles pnlSolicitado.Paint

    End Sub

    Private Sub pnlAGerente_Paint(sender As Object, e As PaintEventArgs) Handles pnlAGerente.Paint

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub grdDatosPrestamos_ExternalSummaryValueRequested(sender As Object, e As ExternalSummaryValueEventArgs) Handles grdDatosPrestamos.ExternalSummaryValueRequested
        Dim valor As String = sender.ToString
        Dim texto As String = e.SummaryValue.Key.ToString
        Select Case texto
            Case "sumaprestamo"
                e.SummaryValue.SetExternalSummaryValue(valorPrestamos)
                Exit Select
            Case "sumasaldo"
                e.SummaryValue.SetExternalSummaryValue(valorSaldo)
                Exit Select
            Case "sumacaja"
                e.SummaryValue.SetExternalSummaryValue(valorCajaAhorro)
                Exit Select
            Case "sumasaldotermino"
                e.SummaryValue.SetExternalSummaryValue(valorSaldoTermino)
                Exit Select
        End Select
    End Sub

    Private Sub grdDatosPrestamos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatosPrestamos.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next


    End Sub




    Private Sub rdbFehcaEntrega_Click(sender As Object, e As EventArgs) Handles rdbFehcaEntrega.Click
        Dim estatus As String = cmbEstatus.Text
        If Not New String() {"DINERO ENTREGADO AL COLABORADOR", "TODOS", "EN COBRANZA", "LIQUIDADO"}.Contains(estatus) Then
            'If Not cmbEstatus.Text = "DINERO ENTREGADO AL COLABORADOR" Or Not cmbEstatus.Text = "TODOS" Or Not cmbEstatus.Text = "EN COBRANZA" Or Not cmbEstatus.Text = "LIQUIDADO" Then
            rdbFechaSolicitud.Checked = True
            Dim vAdvertenciaForm As New AdvertenciaForm
            vAdvertenciaForm.Text = "Prestamos"
            vAdvertenciaForm.mensaje = "Los prestamos en el estatus " + cmbEstatus.Text + " no tienen fecha de entrega"
            vAdvertenciaForm.Show()
        End If
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged

    End Sub




    Private Sub grdDatosPrestamos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdDatosPrestamos.InitializeRow
        If e.Row.Cells("estatus").Value = "A" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(255, 251, 184)
        ElseIf e.Row.Cells("estatus").Value = "B" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(150, 207, 58)
        ElseIf e.Row.Cells("estatus").Value = "C" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(238, 156, 242)
        ElseIf e.Row.Cells("estatus").Value = "D" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(8, 138, 133)
        ElseIf e.Row.Cells("estatus").Value = "E" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(112, 238, 156)
        ElseIf e.Row.Cells("estatus").Value = "F" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(254, 246, 13)
        ElseIf e.Row.Cells("estatus").Value = "G" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(100, 50, 100)
        ElseIf e.Row.Cells("estatus").Value = "H" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(172, 238, 155)
        ElseIf e.Row.Cells("estatus").Value = "I" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(235, 71, 71)
        ElseIf e.Row.Cells("estatus").Value = "J" Then
            e.Row.Cells("color").Appearance.BackColor = Color.FromArgb(242, 135, 115)
        ElseIf e.Row.Cells("estatus").Value = "K" Then
            e.Row.Cells("color").Appearance.BackColor = Color.SandyBrown
        End If

        If e.Row.Cells("Distintivo").Value = "PE" Then
            e.Row.Cells("Distintivo").Appearance.BackColor = Color.FromArgb(34, 44, 162)
            e.Row.Cells("Distintivo").Appearance.ForeColor = Color.FromArgb(34, 44, 162)
        ElseIf e.Row.Cells("Distintivo").Value = "PS" Then
            e.Row.Cells("Distintivo").Appearance.BackColor = Color.FromArgb(135, 206, 235)
            e.Row.Cells("Distintivo").Appearance.ForeColor = Color.FromArgb(135, 206, 235)
        Else
            e.Row.Cells("Distintivo").Appearance.BackColor = Color.FromArgb(255, 255, 255)
        End If

        'If e.Row.Cells("Distintivo").Value = "PS" Then
        '    e.Row.Cells("Distintivo").Appearance.BackColor = Color.FromArgb(135, 206, 235)
        '    e.Row.Cells("Distintivo").Appearance.ForeColor = Color.FromArgb(135, 206, 235)
        'Else
        '    e.Row.Cells("Distintivo").Appearance.BackColor = Color.FromArgb(255, 255, 255)
        'End If

        If e.Row.Cells("Activo").Value = 0 Then
            e.Row.Cells("nombre").Appearance.ForeColor = Color.Red
        End If
    End Sub

    Public Sub asignarEstatusGrid()
        Dim cont As Integer
        Dim estatus3 As String = ""
        Dim estatusReal As String = ""
        Dim estatus2 As String = ""
        Dim interes As Double = 0
        Dim saldo, abono As Int32
        Dim tipoInteres As String = ""
        Dim saldoalTermino As Integer = 0
        Dim idcolaborado As Int32

        For cont = 0 To grdDatosPrestamos.Rows.Count - 1
            estatus2 = grdDatosPrestamos.Rows(cont).Cells("estatus").Value.ToString
            If estatus2.Equals("A") Then
                estatus3 = "TODOS"
                estatusReal = "SOLICITADO"
            ElseIf estatus2.Equals("B") Then
                estatus3 = "SOLICITADO"
                estatusReal = "AUTORIZADO"
            ElseIf estatus2.Equals("C") Then
                estatus3 = "AUTORIZADO"
            ElseIf estatus2.Equals("D") Then
                estatus3 = "SOLICITADO CC"
                estatusReal = "SOLICITADO CC"
            ElseIf estatus2.Equals("E") Then
                estatus3 = "RECIBIDO"
                estatusReal = "ENTREGADO NAVE"
            ElseIf estatus2.Equals("F") Then
                estatus3 = "ENTREGADO"
                estatusReal = "ENTREGADO COLABORADOR"
            ElseIf estatus2.Equals("G") Then
                estatus3 = "EN COBRANZA"
                estatusReal = "EN COBRANZA"
            ElseIf estatus2.Equals("H") Then
                estatus3 = "LIQUIDADO"
                estatusReal = "LIQUIDADO"
            ElseIf estatus2.Equals("I") Then
                estatus3 = "CANCELADO"
                estatusReal = "CANCELADO"
            ElseIf estatus2.Equals("J") Then
                estatus3 = "RECHAZADO"
                estatusReal = "RECHAZADO"
            ElseIf estatus2.Equals("K") Then
                estatus3 = "REGRESADO A FINANZAS"
                estatusReal = "REGRESADO A FINANZAS"

            End If

            interes = CDbl(grdDatosPrestamos.Rows(cont).Cells("interes").Value)
            saldo = grdDatosPrestamos.Rows(cont).Cells("saldo").Value
            abono = grdDatosPrestamos.Rows(cont).Cells("abono").Value
            idcolaborado = grdDatosPrestamos.Rows(cont).Cells("idColaborador").Value
            tipoInteres = grdDatosPrestamos.Rows(cont).Cells("tipoInteres").Value
            If estatus2 = "G" Or estatus2 = "F" Then
                saldoalTermino = calcularSaldoTermino(tipoInteres, interes, saldo, abono)
            Else
                saldoalTermino = 0
            End If
            grdDatosPrestamos.Rows(cont).Cells("estatus2").Value = estatus3
            grdDatosPrestamos.Rows(cont).Cells("estatusReal").Value = estatusReal
            grdDatosPrestamos.Rows(cont).Cells("saldotermino").Value = saldoalTermino

            Dim objBu As New Negocios.SolicitudPrestamoBU
            Dim montoA As New DataTable
            Dim montoAhorro As Double = 0
            montoA = objBu.obtenerMontoAhorro(idcolaborado, idCajaAhorro)
            montoAhorro = montoA.Rows(0).Item("monto")
            grdDatosPrestamos.Rows(cont).Cells("caja").Value = montoAhorro

            'Dim periodonominacaja As String = ""
            'If IsDBNull(grdDatosPrestamos.Rows(cont).Cells("fechaEntrega").Value) Then
            '    periodonominacaja = ""
            'Else
            '    periodonominacaja = CStr(objBu.obtenerPeriodoCaja(grdDatosPrestamos.Rows(cont).Cells("fechaEntrega").Value, cmbNave.SelectedValue.ToString))
            'End If
            'grdDatosPrestamos.Rows(cont).Cells("periodo").Value = periodonominacaja
        Next
    End Sub

    Public Sub cargarDatosGrid(ByVal idNave As Integer, ByVal estatus As String, ByVal fechaI As String, ByVal fechaf As String, ByVal tipo As Integer)
        Dim objBu As New Negocios.SolicitudPrestamoBU
        Dim dtPrestamos As New DataTable
        dtPrestamos = objBu.mostraDatosPrestamo(idNave, estatus, fechaI, fechaf, tipo)
        grdDatosPrestamos.DataSource = dtPrestamos
        formatoUltra()
        asignarEstatusGrid()


    End Sub

    Private Sub btnDevolverDinero_Click(sender As Object, e As EventArgs) Handles btnDevolverDinero.Click
        With grdDatosPrestamos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        devolverDineroFinanzas()

    End Sub

    Public Sub devolverDineroFinanzas()
        Dim bandera As Boolean = False
        Dim advertencia As New AdvertenciaForm
        Dim exito As New ExitoForm
        Dim objBU As New Negocios.SolicitudPrestamoBU
        Dim idprestamo As Int32 = 0
        Dim usuario As String = ""
        For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
            If rowGrd.Cells("Seleccion").Value And rowGrd.Cells("estatus").Value = "E" Then
                bandera = True
                Exit For
            End If
        Next
        If bandera = True Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Esta seguro que desea devolver los prestamos seleccionados?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each rowGrd As UltraGridRow In grdDatosPrestamos.Rows
                    If rowGrd.Cells("seleccion").Value And rowGrd.Cells("estatus").Value = "E" Then
                        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        idprestamo = rowGrd.Cells("idprestamo").Value
                        objBU.CambiarEstatusDineroDevuelto(idprestamo, "K", usuario)
                        EntregarReciboDevolucion()

                    End If
                Next
                exito.Text = "Prestamos"
                exito.mensaje = "Se cambió el estado del préstamo a REGRESADO A FINANZAS correctamente"
                exito.ShowDialog()
                mostrarDatos()
            Else
                advertencia.Text = "Prestamos"
                advertencia.mensaje = "Devolución a finanzas cancelada"
                advertencia.ShowDialog()
            End If

        Else
            advertencia.Text = "Prestamos"
            advertencia.mensaje = "Debes seleccionar al menos un préstamo "
            advertencia.ShowDialog()
        End If
    End Sub


    Public Sub EntregarReciboDevolucion()
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        entReporte = objReporte.LeerReporteporClave("NOM_RECB_DEVOLUCION_FINANZAS")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
        Dim reporte As New StiReport
        Dim objCajaAhorroBU As New Negocios.CajaAhorroBU

        Dim nombrecolaborador As String = ""
        Dim cantidad As Double = 0
        Dim estatus As String = ""
        Dim nombreNave As String = ""
        Dim idNave As Int32 = cmbNave.SelectedValue

        For Each row As UltraGridRow In grdDatosPrestamos.Rows.GetAllNonGroupByRows
            If CBool(row.Cells("seleccion").Value) = True Then
                nombrecolaborador = row.Cells("nombre").Value
                cantidad = CDbl(row.Cells("prestamo").Value)
                estatus = "ENTREGADO A NAVE"
                nombreNave = cmbNave.Text
            End If
        Next



        reporte.Load(archivo)
        reporte.Compile()
        reporte("NombreColaborador") = nombrecolaborador
        reporte("Cantidad") = cantidad
        reporte("Estatus") = estatus
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(idNave)
        reporte("Nave") = nombreNave
        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper

        reporte.Dictionary.Clear()
        reporte.Dictionary.Synchronize()
        reporte.Show()
    End Sub


    Private Sub ReporteAbonosExtraordinariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteAbonosExtraordinariosToolStripMenuItem.Click
        ImprimirReporteAbonosExtraordinarios()
    End Sub

    Private Sub ConcentradoPréstamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConcentradoPréstamosToolStripMenuItem.Click
        Dim vAdvertenciaForm As New AdvertenciaForm
        If chkFecha.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            mostrarDatos()
            imprimirReporteNave()
            Me.Cursor = Cursors.Default
        Else
            vAdvertenciaForm.Text = "Prestamos"
            vAdvertenciaForm.mensaje = "Debe de seleccionar un rango de fechas o un periodo nominal"
            vAdvertenciaForm.Show()
        End If
    End Sub

    Private Sub ReporteConcentradoPréstamosEInteresesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteConcentradoPréstamosEInteresesToolStripMenuItem.Click
        ImprimirReporteConcentradoPrestamoseIntereses()
    End Sub

    Public Sub ImprimirReporteConcentradoPrestamoseIntereses()
        Dim objPrestamosBU As New Negocios.ConsultarPrestamosBU
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim PrestamosNomina As New DataSet("Prestamos Nomina")
        Dim dtPrestamos As New DataTable("Prestamos")
        Dim NaveID As Integer = cmbNave.SelectedValue

        'dtPrestamos = objPrestamosBU.ImprimirReporteConcentradoPrestamoseIntereses(NaveID)
        dtPrestamos = objPrestamosBU.ImprimirReportePrestamosIntereses(NaveID, 0)

        PrestamosNomina.DataSetName = "Prestamos"

        dtPrestamos.TableName = "Prestamos"

        ''RESUMEN
        Dim dtSaldosAbonosExtraordinarios As New DataTable
        Dim SaldoAbonoExtraordinario As Integer = 0
        Dim InteresAbonoExtraordinario As Integer = 0
        Dim SaldoCierreCaja As Integer = 0

        dtSaldosAbonosExtraordinarios = objPrestamosBU.obtenerSaldosPrestamosExtraordinariosCaja(0, NaveID)
        If Not dtSaldosAbonosExtraordinarios Is Nothing AndAlso dtSaldosAbonosExtraordinarios.Rows.Count > 0 Then
            SaldoAbonoExtraordinario = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("SaldoAbonoExtraordinario"))
            InteresAbonoExtraordinario = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("InteresAbonoExtraordinario"))
            SaldoCierreCaja = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("SaldoCierreCaja"))
        End If

        Dim TotalSaldoPrestamos As Int32
        Dim SaldoInicalPrestamosI As Int32
        Dim SaldoFinalInteresesT As Int32
        Dim anio As Int32
        If dtPrestamos.Rows.Count > 0 Then
            TotalSaldoPrestamos = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
                                                        Select(Function(y) y.Item("TotalSaldoPrestamos")).First
            SaldoInicalPrestamosI = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
                                                        Select(Function(y) y.Item("SaldoInicial")).First
            SaldoFinalInteresesT = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
                                                        Select(Function(y) y.Item("TotalSaldoIntereses")).First
            anio = dtPrestamos.AsEnumerable.Where(Function(x) x.Item("Consecutivo")).
                                                            Select(Function(y) y.Item("Año")).First
        End If

        If dtPrestamos.Rows.Count > 0 Then
            PrestamosNomina.Tables.Add(dtPrestamos)
            Try
                Dim objBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = objBU.LeerReporteporClave("RPT_PRES_INTERESES_N")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre.Trim + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("Nave") = cmbNave.Text
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave((Int(cmbNave.SelectedValue)))
                ''Resumen
                reporte("Anio") = anio + 1
                reporte("TotalSaldoPrestamos") = TotalSaldoPrestamos
                reporte("SaldoFinalInteresesT") = SaldoFinalInteresesT
                reporte("AbonosExtraordinarios") = SaldoAbonoExtraordinario
                reporte("IntereseExtraordinarios") = InteresAbonoExtraordinario
                reporte("SaldoFinal") = TotalSaldoPrestamos - SaldoCierreCaja
                reporte("SaldoFinalIntereses") = SaldoFinalInteresesT - InteresAbonoExtraordinario
                reporte("SaldoCierreCaja") = SaldoCierreCaja

                reporte.Dictionary.Clear()
                reporte.RegData(PrestamosNomina)
                reporte.Dictionary.Synchronize()
                reporte.Show()

                Me.Cursor = Cursors.Default
            Catch ex As Exception

            End Try
        Else
            vAdvertenciaForm.Text = "Préstamos"
            vAdvertenciaForm.mensaje = "No hay información para imprimir."
            vAdvertenciaForm.Show()
        End If
        'Dim objPrestamosBU As New Negocios.ConsultarPrestamosBU
        'Dim vAdvertenciaForm As New AdvertenciaForm
        'Dim PrestamosNomina As New DataSet("Prestamos Nomina")
        'Dim dtPrestamos As New DataTable("Prestamos")
        'Dim NaveID As Integer = cmbNave.SelectedValue



        ''dtPrestamos = objPrestamosBU.ImprimirReporteConcentradoPrestamoseIntereses(NaveID)
        'dtPrestamos = objPrestamosBU.ImprimirReportePrestamosIntereses(NaveID, 0)

        'PrestamosNomina.DataSetName = "Prestamos"

        'dtPrestamos.TableName = "Prestamos"

        '''RESUMEN
        'Dim dtSaldosAbonosExtraordinarios As New DataTable
        'Dim SaldoAbonoExtraordinario As Integer = 0
        'Dim InteresAbonoExtraordinario As Integer = 0

        'dtSaldosAbonosExtraordinarios = objPrestamosBU.obtenerSaldosPrestamosExtraordinariosCaja(0, NaveID)
        'If Not dtSaldosAbonosExtraordinarios Is Nothing AndAlso dtSaldosAbonosExtraordinarios.Rows.Count > 0 Then
        '    SaldoAbonoExtraordinario = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("SaldoAbonoExtraordinario"))
        '    InteresAbonoExtraordinario = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("InteresAbonoExtraordinario"))
        'End If

        'Dim TotalSaldoPrestamos As Int32
        'Dim SaldoInicalPrestamosI As Int32
        'Dim SaldoFinalInteresesT As Int32
        'Dim anio As Int32
        'If dtPrestamos.Rows.Count > 0 Then
        '    TotalSaldoPrestamos = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
        '                                                Select(Function(y) y.Item("TotalSaldoPrestamos")).First
        '    SaldoInicalPrestamosI = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
        '                                                Select(Function(y) y.Item("SaldoInicial")).First
        '    SaldoFinalInteresesT = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
        '                                                Select(Function(y) y.Item("TotalSaldoIntereses")).First
        '    anio = dtPrestamos.AsEnumerable.Where(Function(x) x.Item("Consecutivo")).
        '                                                    Select(Function(y) y.Item("Año")).First
        'End If

        'If dtPrestamos.Rows.Count > 0 Then
        '    PrestamosNomina.Tables.Add(dtPrestamos)
        '    Try
        '        Dim objBU As New Framework.Negocios.ReportesBU
        '        Dim EntidadReporte As Entidades.Reportes
        '        EntidadReporte = objBU.LeerReporteporClave("RPT_PRES_INTERESES_N")
        '        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
        '    EntidadReporte.Pnombre.Trim + ".mrt"
        '        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        '        Dim reporte As New StiReport
        '        reporte.Load(archivo)
        '        reporte.Compile()
        '        reporte("Nave") = cmbNave.Text
        '        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        '        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave((Int(cmbNave.SelectedValue)))
        '        ''Resumen
        '        reporte("Anio") = anio + 1
        '        reporte("TotalSaldoPrestamos") = TotalSaldoPrestamos
        '        reporte("SaldoFinalInteresesT") = SaldoFinalInteresesT
        '        reporte("AbonosExtraordinarios") = SaldoAbonoExtraordinario
        '        reporte("IntereseExtraordinarios") = InteresAbonoExtraordinario
        '        reporte("SaldoFinal") = TotalSaldoPrestamos - SaldoAbonoExtraordinario
        '        reporte("SaldoFinalIntereses") = SaldoFinalInteresesT - InteresAbonoExtraordinario

        '        reporte.Dictionary.Clear()
        '        reporte.RegData(PrestamosNomina)
        '        reporte.Dictionary.Synchronize()
        '        reporte.Show()

        '        Me.Cursor = Cursors.Default
        '    Catch ex As Exception

        '    End Try
        'Else
        '    vAdvertenciaForm.Text = "Préstamos"
        '    vAdvertenciaForm.mensaje = "No hay información para imprimir."
        '    vAdvertenciaForm.Show()
        'End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdDatosPrestamos.Rows.Count > 0 Then
            Try
                Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                Dim archivo As String = String.Empty

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = Windows.Forms.DialogResult.OK Then

                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                        archivo = "ListadoPrestamos_" & fecha_hora & ".xlsx"
                        gridExcelExporter.Export(grdDatosPrestamos, .SelectedPath & "\" & archivo)

                    End If
                    objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                    objMensajeExito.ShowDialog()
                    .Dispose()
                End With
            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnPrestamoEspecial_Click(sender As Object, e As EventArgs) Handles btnPrestamoEspecial.Click
        Dim objPrestamoEspecial As New Nomina_SolicitudPrestamoEspecialForm

        objPrestamoEspecial.ShowDialog()
    End Sub

    Private Sub btnPrestacion_Click(sender As Object, e As EventArgs) Handles btnPrestacion.Click
        Dim objPrestacion As New Nomina_PrestacionesEspecialesSAY
        objPrestacion.ShowDialog()
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        If chboxSeleccionarTodo.Checked Then
            For Each row In grdDatosPrestamos.Rows.GetFilteredInNonGroupByRows
                row.Cells("seleccion").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdDatosPrestamos.Rows.GetFilteredInNonGroupByRows
                row.Cells("seleccion").Value = False
            Next
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In grdDatosPrestamos.Rows
            If CBool(row.Cells("seleccion").Value) Then
                marcados += 1
            End If
        Next
        lblTotalSeleccionados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)

    End Sub

    Private Sub ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteConcentradoPréstamosEspecialesYPrestacionesToolStripMenuItem.Click
        Dim vAdvertenciaForm As New AdvertenciaForm
        If chkFecha.Checked = True Then
            Me.Cursor = Cursors.WaitCursor
            mostrarDatos()
            ImprimirReporteConcentradoPrestamosEspecialesYPrestaciones()
            Me.Cursor = Cursors.Default
        Else
            vAdvertenciaForm.Text = "Prestamos"
            vAdvertenciaForm.mensaje = "Debe de seleccionar un rango de fechas o un periodo nominal"
            vAdvertenciaForm.Show()
        End If

    End Sub

    Public Sub ImprimirReporteConcentradoPrestamosEspecialesYPrestaciones()
        Dim PrestamosEspeciales = New DataSet("PrestamosEspeciales")
        PrestamosEspeciales.DataSetName = "PrestamosEspeciales"

        Dim tablaTickets As New DataTable("Prestamos")
        tablaTickets = obtnerValoresDatagridPrestamosEspeciales()

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_PRES_ESP_NAVE")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre.Trim + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()

        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave((Int(cmbNave.SelectedValue)))
        Dim tabla As New DataTable
        Dim fechas As String = ""
        If rdbRango.Checked = True Then
            If rdbFechaSolicitud.Checked = True Then
                fechas = "FECHAS DE SOLICITUD DEL " + DtpFechaInicio.Value.ToShortDateString + " AL " + DtpFechaFin.Value.ToShortDateString
            Else
                fechas = "FECHAS DE ENTREGA DEL " + DtpFechaInicio.Value.ToShortDateString + " AL " + DtpFechaFin.Value.ToShortDateString
            End If

        ElseIf rdbPeriodo.Checked = True Then
            fechas = cmbPeriodoNomina.Text
        End If

        If Not cmbEstatus.Text = "TODOS" Then
            fechas += ", ESTATUS: " + cmbEstatus.Text
        End If



        reporte("Fecha") = fechas
        Dim naveNombre As New Entidades.Naves
        naveNombre = cmbNave.SelectedItem
        reporte("Nave") = naveNombre.PNombre

        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToUpper
        reporte("elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToUpper

        tablaTickets.TableName = "Prestamos"
        PrestamosEspeciales.Tables.Add(tablaTickets)

        reporte.RegData(PrestamosEspeciales)
        reporte.Show()
    End Sub

    Public Function obtnerValoresDatagridPrestamosEspeciales() As DataTable
        Dim tabladatos As New DataTable
        Dim band As UltraGridBand = grdDatosPrestamos.DisplayLayout.Bands(0)
        tabladatos.Columns.Add("Consecutivo", System.Type.GetType("System.Int32"))
        For Each column As UltraGridColumn In band.Columns
            tabladatos.Columns.Add(column.Key, column.DataType)
        Next
        Dim i As Integer = 0
        Dim contador As Integer = 1
        For Each row As UltraGridRow In grdDatosPrestamos.Rows
            If row.Cells("Distintivo").Value <> "" Then
                Dim cellValues As List(Of Object) = New List(Of Object)(row.Cells.Count)
                For Each cell As UltraGridCell In row.Cells
                    If i = 0 Then
                        cellValues.Add(contador)
                        Try
                            cellValues.Add(CDbl(cell.Value))
                        Catch ex As Exception
                            cellValues.Add(cell.Value)
                        End Try
                        i = 1
                    Else
                        Try
                            cellValues.Add(CDbl(cell.Value))
                        Catch ex As Exception
                            cellValues.Add(cell.Value)
                        End Try

                    End If

                Next
                i = 0
                contador += 1
                tabladatos.Rows.Add(cellValues.ToArray())
            End If
        Next
        Return tabladatos

    End Function

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyudaReportes.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaPréstamosEspecialesYPrestacionesToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Nomina/", "Descargas\Manuales\Nomina", "NOM_MAUS_ProcesoPrestacionesEspecialesPrestamos_Prestamos_V1.pdf")
            Process.Start("Descargas\Manuales\Nomina\NOM_MAUS_ProcesoPrestacionesEspecialesPrestamos_Prestamos_V1.pdf")
        Catch ex As Exception

        End Try
    End Sub
End Class

