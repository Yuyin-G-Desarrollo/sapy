Imports Nomina.Negocios

Public Class CambioColaboradorNaveForm

    Public idColaborador As Integer
    Public idNave As Integer
    Public nombre As String
    Public asegurado As Boolean
    Public guardado As Boolean = False
    Public patronOrigenId As Integer
    Dim patronDestinoId As Integer
    Dim naveDestinoId As Integer



    Private Sub CambioColaboradorNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblColaborador.Text = nombre
        cargarComboNave()
        visualizarPatron()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        copiarColaborador()
    End Sub

    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        If cmbNave.Enabled AndAlso cmbPatron.Items.Count > 1 Then
            If cmbPatron.SelectedIndex > 0 Then
                cargarFechasCorte()
            End If
        End If
    End Sub

    Private Sub visualizarPatron()
        If asegurado = True Then
            pnlPatron.Visible = False
        Else
            pnlPatron.Visible = True
        End If
    End Sub

    Private Sub cargarComboNave()
        cmbNave.Enabled = False
        Dim objMensajeError As New Tools.ErroresForm
        cmbNave.DataSource = Nothing
        Try
            Dim objBu As New Contabilidad.Negocios.BajaCambioNaveBU
            Dim dtResultado As New DataTable

            dtResultado = objBu.obtenerNavesDestino(idNave)
            If dtResultado.Rows.Count > 0 Then
                cmbNave.DataSource = dtResultado
                cmbNave.DisplayMember = "nave_nombre"
                cmbNave.ValueMember = "naveDestinoId"

                If dtResultado.Rows.Count = 2 Then
                    cmbNave.SelectedIndex = 1
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar las naves destino."
            objMensajeError.ShowDialog()
        End Try
        cmbNave.Enabled = True
    End Sub



    Private Sub llenarComboPatron()
        cmbPatron.DataSource = Nothing
        If cmbNave.SelectedIndex > 0 Then
            Dim objBu As New Contabilidad.Negocios.UtileriasBU
            Dim dtEmpresa As New DataTable

            dtEmpresa = objBu.consultaPatronPorNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
            If dtEmpresa.Rows.Count > 0 Then
                If dtEmpresa.Rows.Count = 1 Then
                    Dim dtRow As DataRow = dtEmpresa.NewRow
                    dtRow("ID") = 0
                    dtRow("PATRON") = ""
                    dtEmpresa.Rows.InsertAt(dtRow, 0)
                End If

                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbPatron.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub copiarColaborador()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim resultado As String = String.Empty


        ''VALIDA SI SE HA SELECCIONADO LA NAVE y patron
        If validarSeleccion() Then
            Try
                objMensajeConf.mensaje = "¿Está seguro de cambiar al colaborador? Este proceso no se podrá revertir."
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Dim objBU As New Negocios.CambioNaveBU
                    If asegurado Then
                        ' resultado = objBU.copiarColaboradorConSeguro(idColaborador, idNave, naveDestinoId)
                    Else
                        ' resultado = objBU.copiarColaboradorSinSeguro(idColaborador, patronOrigenId, cmbPatron.SelectedValue, idNave, naveDestinoId)
                    End If

                    If resultado = "EXITO" Then
                        objMensajeExito.mensaje = "El colaborador ha sido cambiado exitosamente."
                        objMensajeExito.ShowDialog()
                        guardado = True
                        Me.Cursor = Cursors.Default
                        Me.Close()
                    Else
                        objMensajeError.mensaje = resultado
                        objMensajeError.ShowDialog()
                    End If
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
                objMensajeError.mensaje = "Error al copiar al colaborador a la nave destino."
                objMensajeError.ShowDialog()
            End Try
        End If
    End Sub
    Private Function validarSeleccion() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbNave.Items.Count > 1 And cmbNave.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Nave."
            objMensajeAdv.ShowDialog()
            Return False
        End If
        '' Si esta asegurado tomara el patron que ya tiene si no tomara el patron seleccionado del combo
        If asegurado = False Then
            If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
                objMensajeAdv.mensaje = "Favor de seleccionar un Patrón."
                objMensajeAdv.ShowDialog()
                Return False
            End If
        End If


        Return True
    End Function

    Private Function validacionSoloParaAsegurados() As Boolean
        'Validaciones:
        '•	Validaciones de movimientos de contabilidad (alta imss, baja imss, crédito Infonavit, modificaciones de salario).
        '•	Validar que no tenga un finiquito en proceso o no mostrarla en el listado inicial.
        '•	Validar fechas de cierre de nómina de nave destino (Ejemplo:  SP_NF_CambioPatron_ValidaFechaCierreNominaReal)
        Dim objBU As New CambioNaveBU

        Dim dtDatos As New DataTable
        dtDatos = objBU.validarColaborador(idColaborador, asegurado)


        Return True
    End Function

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.Enabled Then
            llenarComboPatron()
        End If

        ''Cargar datos para cambiar solo cuando no tenga seguro si tiene seguro los carga en el evento de cmbPatron
        If cmbNave.Items.Count > 1 AndAlso cmbNave.SelectedIndex > 0 Then
            If asegurado <> 0 Then
                cargarFechasCorte()
            End If
        End If
    End Sub

    Private Sub cargarFechasCorte()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim patronId As Integer = 0

        btnAceptar.Enabled = True
        lblNota.Visible = False
        'txtFechaCorteNaveOrigen.Text = ""
        'txtFechaCorteNaveDestino.Text = ""
        Try
            If validarSeleccion() Then
                Dim objBU As New Negocios.CambioNaveBU
                Dim dtResultado As New DataTable

                If asegurado Then
                    patronId = patronOrigenId
                Else
                    patronId = cmbPatron.SelectedValue
                End If
                dtResultado = objBU.obtenerFechaCorteNave(idNave, cmbNave.SelectedValue, idColaborador, patronId) ''Obtiene las fechas de corte origen y destino

                If Not dtResultado Is Nothing Then
                        If dtResultado.Rows.Count > 0 Then
                            If dtResultado.Rows.Count = 2 Then
                            'txtFechaCorteNaveOrigen.Text = dtResultado.Rows(1)("FechaCorte")
                            'txtFechaCorteNaveDestino.Text = dtResultado.Rows(0)("FechaCorte")
                            naveDestinoId = cmbNave.SelectedValue
                                patronOrigenId = dtResultado.Rows(1)("PatronID")
                                patronDestinoId = dtResultado.Rows(0)("PatronID")
                                btnAceptar.Enabled = CBool(dtResultado.Rows(0)("SolEnFecha"))
                                lblNota.Visible = Not CBool(dtResultado.Rows(0)("SolEnFecha"))
                            Else
                                objMensajeAdv.mensaje = "La nave seleccionada no es válida para hacer el cambio del colaborador."
                                objMensajeAdv.ShowDialog()
                            End If
                        End If
                    End If
                End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar fechas de corte de las naves."
            objMensajeError.ShowDialog()
        End Try
    End Sub


End Class