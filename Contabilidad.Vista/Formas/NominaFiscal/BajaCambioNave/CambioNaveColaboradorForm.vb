Imports System.Windows.Forms
Public Class CambioNaveColaboradorForm
    Public idColaborador As Integer
    Public idNave As Integer
    Public nombre As String
    Public guardado As Boolean = False
    Dim patronOrigenId As Integer
    Dim patronDestinoId As Integer
    Dim naveDestinoId As Integer

    Private Sub CambioNaveColaboradorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblColaborador.Text = nombre
        cargarComboNave()
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

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.Enabled Then
            llenarComboPatron()
            'cargarFechasCorte()
        End If
    End Sub

    Private Sub cargarFechasCorte()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        btnAceptar.Enabled = True
        lblNota.Visible = False
        txtFechaCorteNaveOrigen.Text = ""
        txtFechaCorteNaveDestino.Text = ""
        Try
            If validarSeleccion() Then
                Dim objBU As New Negocios.BajaCambioNaveBU
                Dim dtResultado As New DataTable

                dtResultado = objBU.obtenerFechaCorteNave(idNave, cmbNave.SelectedValue, idColaborador, cmbPatron.SelectedValue)
                If Not dtResultado Is Nothing Then
                    If dtResultado.Rows.Count > 0 Then
                        If dtResultado.Rows.Count = 2 Then
                            txtFechaCorteNaveOrigen.Text = dtResultado.Rows(1)("FechaCorte")
                            txtFechaCorteNaveDestino.Text = dtResultado.Rows(0)("FechaCorte")
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

    Private Function validarSeleccion() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbNave.Items.Count > 1 And cmbNave.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Nave."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Patrón."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        Return True
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        copiarColaborador()
    End Sub

    Private Sub copiarColaborador()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim resultado As String = String.Empty

        If validarSeleccion() Then
            Try
                objMensajeConf.mensaje = "¿Está seguro de cambiar al colaborador? Este proceso no se podrá revertir."
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.BajaCambioNaveBU
                    patronDestinoId = cmbPatron.SelectedValue
                    resultado = objBU.copiarColaborador(idColaborador, patronOrigenId, patronDestinoId, idNave, naveDestinoId)

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

    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        If cmbNave.Enabled AndAlso cmbPatron.Items.Count > 1 Then
            If cmbPatron.SelectedIndex > 0 Then
                cargarFechasCorte()
            End If
        End If
    End Sub
End Class