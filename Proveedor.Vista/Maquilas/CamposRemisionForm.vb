Imports Tools
Imports Proveedores.BU

Public Class CamposRemisionForm
    Public folio As String = ""
    Public monto As Double = 0
    Public pares As Integer = 0
    Dim adv As New AdvertenciaForm
    Public cancelado As Boolean = False
    Dim guardar As Boolean = False
    Public idFolio As Int16
    Public proveedoresCamposRemision As DataTable



    Private Sub TextBox2_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtMonto.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cancelado = True
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If pnlProveedor.Visible = True Then
            If Not IsDBNull(cboxProveedores.SelectedIndex) > 0 Then

                If txtFolio.Text.Trim <> String.Empty Then
                    If txtMonto.Text.Trim <> String.Empty Then
                        Try

                            monto = Convert.ToDouble(txtMonto.Text.Trim)
                            folio = txtFolio.Text.Trim
                            If txtPares.Text.Trim <> String.Empty Then
                                guardar = True
                                monto = Convert.ToDouble(txtMonto.Text.Trim)
                                folio = txtFolio.Text.Trim
                                Try
                                    pares = Convert.ToInt32(txtPares.Text.Trim)

                                    Me.Close()
                                Catch ex As Exception
                                    adv.mensaje = "Ingrese un número de pares valido."
                                    adv.ShowDialog()
                                End Try
                            Else
                                adv.mensaje = "Ingrese un número de pares."
                                adv.ShowDialog()
                            End If

                        Catch ex As Exception
                            adv.mensaje = "Ingrese un monto valido."
                            adv.ShowDialog()
                        End Try
                    Else
                        adv.mensaje = "Ingrese un monto."
                        adv.ShowDialog()
                    End If
                Else
                    adv.mensaje = "Ingrese un folio."
                    adv.ShowDialog()
                End If
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "No se ha seleccionado ningún proveedor."
                objMensaje.ShowDialog()
            End If
        Else
            If txtFolio.Text.Trim <> String.Empty Then
                If txtMonto.Text.Trim <> String.Empty Then
                    Try

                        monto = Convert.ToDouble(txtMonto.Text.Trim)
                        folio = txtFolio.Text.Trim
                        If txtPares.Text.Trim <> String.Empty Then
                            guardar = True
                            monto = Convert.ToDouble(txtMonto.Text.Trim)
                            folio = txtFolio.Text.Trim
                            Try
                                pares = Convert.ToInt32(txtPares.Text.Trim)

                                Me.Close()
                            Catch ex As Exception
                                adv.mensaje = "Ingrese un número de pares valido."
                                adv.ShowDialog()
                            End Try
                        Else
                            adv.mensaje = "Ingrese un número de pares."
                            adv.ShowDialog()
                        End If

                    Catch ex As Exception
                        adv.mensaje = "Ingrese un monto valido."
                        adv.ShowDialog()
                    End Try
                Else
                    adv.mensaje = "Ingrese un monto."
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Ingrese un folio."
                adv.ShowDialog()
            End If
        End If

    End Sub

    Private Sub CamposRemisionForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If guardar = False Then
            cancelado = True
        End If
    End Sub

    Private Sub CamposRemisionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtMonto.Enabled = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ComprobantesMaquilas", "EDITAR_REMISION")
        txtPares.Enabled = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ComprobantesMaquilas", "EDITAR_REMISION")

        If pnlProveedor.Visible = True Then

            If proveedoresCamposRemision.Rows.Count > 1 Then
                Dim newRow As DataRow = proveedoresCamposRemision.NewRow
                proveedoresCamposRemision.Rows.InsertAt(newRow, 0)
            End If

            cboxProveedores.DataSource = proveedoresCamposRemision
            cboxProveedores.ValueMember = "IdProveedor"
            cboxProveedores.DisplayMember = "RazonSocial"

            If proveedoresCamposRemision.Rows.Count = 2 Then
                cboxProveedores.SelectedIndex = 1
                txtFolio.Text = idFolio
            Else
                txtFolio.Text = idFolio
            End If
            obtenerFolio()
        Else
            txtFolio.Text = idFolio
        End If

        'asingar cantidades 
        txtMonto.Text = monto
        txtPares.Text = pares

    End Sub

    Private Sub txtPares_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtPares.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub cboxProveedores_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxProveedores.SelectionChangeCommitted
        obtenerFolio()
    End Sub

    Private Sub obtenerFolio()
        Dim consecutivo As Integer
        Dim obj As New AgregarComprobanteBU
        'If proveedoresCamposRemision.Rows.Count > 2 Then
        If IsDBNull(cboxProveedores.SelectedValue) Then
            txtFolio.Text = ""
        Else
            consecutivo = obj.consecutivo(cboxProveedores.SelectedValue)
            consecutivo += 1
            txtFolio.Text = CStr(consecutivo)
        End If

        ' End If
    End Sub
End Class