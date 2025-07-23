Imports Tools

Public Class AltaEditarLineas
    Public esAltaLinea As Boolean
    Public idLineaEditar As Int32
    Public activoLinea As Boolean
    Public nombreLinea As String

    Public Sub cargarCodigoNuevo()
        Dim objLineasBU As New Negocios.LineasBU
        Dim dtDatosLineas As New DataTable
        dtDatosLineas = objLineasBU.verIdMaxLineas
        Dim idLineaCargado As Int32
        If dtDatosLineas.Rows(0)(0).ToString = "" Then
            idLineaCargado = 1
        Else
            idLineaCargado = CInt(dtDatosLineas.Rows(0)(0).ToString) + 1
        End If
        txtCodigo.Text = idLineaCargado
    End Sub

    Public Function validarExistenModelos() As Boolean
        Dim objLineaNE As New Negocios.LineasBU
        Dim dtLineaModelos As New DataTable

        If rdoActivo.Checked = False Then
            dtLineaModelos = objLineaNE.validarInactivarLinea(idLineaEditar)
        End If

        If dtLineaModelos.Rows.Count > 0 Then
            If CInt(dtLineaModelos.Rows(0).Item(0).ToString) > 0 Then
                MsgBox("La Linea " + txtDescripcion.Text + " no puede ser inactivado, debido a que existen " + CStr(CInt(dtLineaModelos.Rows(0).Item(0).ToString)) + " modelos activos registrados con esta linea.", MsgBoxStyle.Information, "")
                Return False
            End If
        End If
        Return True
    End Function

    Public Sub registrarEditarLinea()
        Dim objLineaBU As New Negocios.LineasBU
        Dim entidadLinea As New Entidades.Lineas
        Dim objConfirmar As New ConfirmarForm
        If esAltaLinea = True Then
            objConfirmar.mensaje = "¿Esta seguro de guardar los cambios?"
            If objConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                entidadLinea.PnombreLinea = txtDescripcion.Text
                entidadLinea.PactivoLinea = CBool(rdoActivo.Checked)
                objLineaBU.registrarEditaLinea(entidadLinea, esAltaLinea)
                Dim objMensaje As New ExitoForm
                objMensaje.mensaje = "El registro se realizó con éxito."
                objMensaje.ShowDialog()
                Me.Close()
            End If
        ElseIf esAltaLinea = False Then
            If validarExistenModelos() = True Then
                objConfirmar.mensaje = "¿Esta seguro de guardar los cambios?"
                If objConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then

                    entidadLinea.PidLinea = txtCodigo.Text
                    entidadLinea.PnombreLinea = txtDescripcion.Text
                    entidadLinea.PactivoLinea = CBool(rdoActivo.Checked)
                    objLineaBU.registrarEditaLinea(entidadLinea, esAltaLinea)
                    Dim objMensaje As New ExitoForm
                    objMensaje.mensaje = "El registro se realizó con éxito."
                    objMensaje.ShowDialog()
                    Me.Close()
                End If
            End If
        End If

    End Sub

    Public Function validarVaio() As Boolean
        If txtDescripcion.Text = "" Then
            lblDescripcion.ForeColor = Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Color.Black
        End If
        Return True
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub AltaEditarLineas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If esAltaLinea = True Then
            rdoActivo.Checked = True
            cargarCodigoNuevo()
        Else
            If activoLinea = True Then
                rdoActivo.Checked = True
            Else
                rdoInactivo.Checked = True
            End If
            txtCodigo.Text = idLineaEditar
            txtDescripcion.Text = nombreLinea
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarVaio() = True Then
            registrarEditarLinea()
        Else
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.mensaje = "Los campos marcados en rojo deben ser completados."
            objAdvertencia.ShowDialog()
        End If
    End Sub
End Class