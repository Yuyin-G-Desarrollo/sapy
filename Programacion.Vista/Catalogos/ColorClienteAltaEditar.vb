Imports Entidades
Imports Tools

Public Class ColorClienteAltaEditar
    Public colorCliente As New ColorCliente
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Public Sub llenarComboColores()
        Dim obj As New Programacion.Negocios.ColoresClientesBU
        Dim dt As New DataTable
        dt = obj.getListaColores
        If Not dt.Rows.Count = 0 Then
            dt.Rows.InsertAt(dt.NewRow, 0)
            cmbColor.DataSource = dt
            cmbColor.DisplayMember = "color_descripcion"
            cmbColor.ValueMember = "color_colorid"
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objMensajeError As New Tools.AdvertenciaForm

        Try
            If ValidarInformacionCapturada() = True Then
                guardar()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = ex.Message
            objMensajeError.ShowDialog()
        End Try

        'Dim objMensajeError As New Tools.AdvertenciaForm
        'Try
        '    If cmbColor.SelectedValue > 0 Then
        '        guardar()
        '    Else
        '        objMensajeError.mensaje = "Seleciona un color"
        '        objMensajeError.ShowDialog()
        '    End If
        'Catch ex As Exception
        '    objMensajeError.mensaje = ex.Message
        '    objMensajeError.ShowDialog()
        'End Try
    End Sub

    Public Sub guardar()
        If colorCliente.idCliente > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Estás seguro de guardar los cambios?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim objBU As New Negocios.ColoresClientesBU
                Dim mensj As String
                colorCliente.idColor = cmbColor.SelectedValue
                objBU.actualizarEstatusColorCliente(rdoActivo.Checked, colorCliente.idColorCliente)
                mensj = objBU.insertarActualizarColoresClientes(colorCliente.idColorCliente,
                colorCliente.idColor, colorCliente.idCliente,
                txtCodigoCliente.Text.Trim, txtNombreCliente.Text.Trim)
                If mensj.Contains("Error") Then
                    Dim objMensajeError As New Tools.AdvertenciaForm
                    objMensajeError.mensaje = mensj
                    objMensajeError.ShowDialog()
                Else
                    Dim exito As New ExitoForm
                    exito.mensaje = "Registro correcto"
                    exito.ShowDialog()
                    Me.Close()
                End If

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub ColorClienteAltaEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboColores()
        getDatosEdicion()
    End Sub
    Public Sub getDatosEdicion()
        Try
            If colorCliente.idColor > 0 Then
                cmbColor.SelectedValue = colorCliente.idColor
                cmbColor.Enabled = False
                txtCodSicy.Text = colorCliente.codigoSICYColor
                txtCodigoCliente.Text = colorCliente.codigoClienteColor
                txtNombreCliente.Text = colorCliente.nombreClienteColor
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColor.SelectedIndexChanged
        Try
            Dim row As DataRowView
            row = cmbColor.SelectedItem
            txtCodSicy.Text = row("color_codsicy")

        Catch ex As Exception
            txtCodSicy.Text = ""
        End Try
    End Sub


    Private Function ValidarInformacionCapturada() As Boolean
        Dim objBU As New Negocios.ColoresClientesBU
        Dim DTInformacion As DataTable
        Dim objMensajeError As New Tools.AdvertenciaForm
        Dim Resultado As Boolean = True

        Try

            If ValidarCamposObligatorios() = True Then
                DTInformacion = objBU.ExisteCombinacionColorCliente(cmbColor.SelectedValue, txtCodigoCliente.Text.Trim(), txtNombreCliente.Text.Trim(), colorCliente.idCliente, colorCliente.idColorCliente)
                If DTInformacion.Rows.Count > 0 Then

                    If colorCliente.idColorCliente > 0 Then 'Edicion de combinacion
                        If DTInformacion.Rows(0).Item("Valido").ToString = "1" Then
                            Resultado = True
                        Else
                            Resultado = False
                            show_message("Advertencia", "La combinación de Color-Cliente ya existe.")
                        End If

                    Else ' Alta de combinacion

                        If DTInformacion.Rows(0).Item("Valido").ToString = "1" Then
                            Resultado = True
                        Else
                            Resultado = False
                            If CBool(DTInformacion.Rows(0).Item("Activo").ToString()) = False Then
                                show_message("Advertencia", "La combinación de Color-Cliente ya existe y se encuentra inactiva.")
                            Else
                                show_message("Advertencia", "La combinación de Color-Cliente ya existe.")
                            End If
                        End If

                    End If


                Else
                    Resultado = True
                End If
            Else
                show_message("Advertencia", "Faltan campos por capturar")
                Resultado = False
            End If
        Catch ex As Exception
            objMensajeError.mensaje = ex.Message
            objMensajeError.ShowDialog()
            Resultado = False
        End Try

        Return Resultado

    End Function


    Private Function ValidarCamposObligatorios() As Boolean
        Dim Resultado As Boolean = True

        If cmbColor.SelectedIndex > 0 Then
            lblColor.ForeColor = Color.Black
        Else
            lblColor.ForeColor = Color.Red
            Resultado = False
        End If


        If txtCodigoCliente.Text.Trim() = String.Empty Then
            Resultado = False
            lblCodigoCliente.ForeColor = Color.Red
        Else
            lblCodigoCliente.ForeColor = Color.Black
        End If


        If txtNombreCliente.Text.Trim() = String.Empty Then
            Resultado = False
            lblNombreCliente.ForeColor = Color.Red
        Else
            lblNombreCliente.ForeColor = Color.Black
        End If


        Return Resultado
    End Function


    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub







End Class