Public Class frmAltaEditarCelulaProduccion
    Public idCelula As Int32 = 0
    Public idNave As Int32 = 0
    Public nombreCelula As String = ""
    Public capacidad As Int32 = 0
    Public activo As Boolean = 0
    Public accion As String = ""

    Public Function validarCapacidad() As Boolean
        If txtCapacidad.Value < 0 Then
            Return False
        End If
        Return True
    End Function

    Public Function validarInactivar() As Boolean
        If rdoActivo.Checked = False And activo = True Then
            Dim objBU As New Negocios.LineasProduccionBU
            Dim cont As Int32 = 0
            cont = objBU.consultaValidarCont(idCelula)
            If cont > 0 Then
                Return False
            End If
        End If
        Return True
    End Function


    Public Function validarNombre() As Boolean
        Dim objN As New Negocios.LineasProduccionBU
        Dim id As Int32 = 0
        id = objN.validarNombreRepetido(cmbNaves.SelectedValue, txtCelula.Text.Trim)
        If id > 0 Then
            If id <> idCelula Then
                If accion = "ALTAS" Then
                    guardarLineaCuandoEsRepetido(id)
                End If
                Return False
            End If
        End If
        Return True
    End Function

    Public Sub guardarLinea()
        Dim objN As New Negocios.LineasProduccionBU
        objN.registrarEditarLinea(accion, idCelula, cmbNaves.SelectedValue, txtCapacidad.Value, CBool(rdoActivo.Checked), txtCelula.Text.Trim)
    End Sub

    Public Sub guardarLineaCuandoEsRepetido(ByVal idLinea As Int32)
        Dim objN As New Negocios.LineasProduccionBU
        objN.registrarEditarLinea("EDITAR", idLinea, cmbNaves.SelectedValue, txtCapacidad.Value, True, txtCelula.Text.Trim)
    End Sub

    Public Function validarVacio() As Boolean
        lblNave.ForeColor = Color.Black
        lblCelula.ForeColor = Color.Black
        If cmbNaves.SelectedIndex <= 0 Or txtCelula.Text.Trim = "" Then
            If cmbNaves.SelectedIndex <= 0 Then
                lblNave.ForeColor = Color.Red
            End If
            If txtCelula.Text.Trim = "" Then
                lblCelula.ForeColor = Color.Red
            End If
            Return False
        End If

        Return True
    End Function

    Public Sub llenarComboNaves()
        Dim objN As New Negocios.NaveAuxBU
        Dim dtNaves As New DataTable
        dtNaves = objN.tablaNavesAux
        dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
        cmbNaves.DataSource = dtNaves
        cmbNaves.DisplayMember = "nave_nombre"
        cmbNaves.ValueMember = "nave_naveid"
    End Sub

    Private Sub frmAltaEditarCelulaProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboNaves()
        If accion = "ALTAS" Then
            rdoActivo.Checked = True
        ElseIf accion = "EDITAR" Then
            If idNave > 0 Then
                cmbNaves.SelectedValue = idNave
                txtCelula.Text = nombreCelula.Trim
                If activo = True Then
                    rdoActivo.Checked = True
                Else
                    rdoInactivo.Checked = True
                End If
                txtCapacidad.Value = capacidad
            End If
            cmbNaves.Enabled = False
        ElseIf accion = "CONSULTA" Then
            If idNave > 0 Then
                cmbNaves.SelectedValue = idNave
                txtCelula.Text = nombreCelula.Trim
                If activo = True Then
                    rdoActivo.Checked = True
                Else
                    rdoInactivo.Checked = True
                End If
                txtCapacidad.Value = capacidad
            End If
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            cmbNaves.Enabled = False
            txtCapacidad.Enabled = False
            txtCelula.Enabled = False
            rdoActivo.Enabled = False
            rdoInactivo.Enabled = False
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarCapacidad() = True Then
            If validarInactivar() = True Then
                If validarVacio() = True Then
                    Dim objMensaje As New Tools.ConfirmarForm
                    objMensaje.mensaje = "¿Desea guardar los cambios?"
                    If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        If validarNombre() = True Then
                            guardarLinea()
                            Dim objMExito As New Tools.ExitoForm
                            objMExito.mensaje = "Registro exitoso."
                            objMExito.ShowDialog()
                            Me.Close()
                        Else
                            If accion = "ALTAS" Then
                                Dim objMExito As New Tools.AdvertenciaForm
                                objMExito.mensaje = "La célula capturada ya existe en esta nave. Se activó y actualizó el registro."
                                objMExito.ShowDialog()
                                Me.Close()
                            Else
                                Dim objMExito As New Tools.AdvertenciaForm
                                objMExito.mensaje = "Ya existe una célula en esta nave con el mismo nombre, capture uno diferente."
                                objMExito.ShowDialog()
                            End If

                        End If


                        Me.Cursor = Cursors.Default
                    End If
                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "Complete los datos obligatorios."
                    objMensaje.ShowDialog()
                End If
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "No puede inactivar la célula ya que existen registros relacionados con ella."
                objMensaje.ShowDialog()
            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "La capacidad de una célula debe ser mayor o igual a 0"
            objMensaje.ShowDialog()
        End If
    End Sub
End Class