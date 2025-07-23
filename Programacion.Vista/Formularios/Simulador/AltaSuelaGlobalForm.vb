Imports Tools

Public Class AltaSuelaGlobalForm
    Public idSuela As Integer
    Public descripcion As String
    Public activo As Boolean

    Public Sub AltaSuelaGlobalForm(ByVal suelaId As Integer, ByVal descripcionEntrada As String, ByVal activoEntrada As Boolean)
        idSuela = suelaId
        descripcion = descripcionEntrada
        activo = activoEntrada

        txtCodigo.Text = idSuela.ToString
        txtDescripcion.Text = descripcion.ToString
        If activo Then
            rdoActivo.Checked = True
            rdoInactivo.Checked = False
        Else
            rdoActivo.Checked = False
            rdoInactivo.Checked = True
        End If
    End Sub
    

    Public Function validaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        End If
        Return True
    End Function

    


    Private Sub AltaSuelaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim mensaje As New ExitoForm
        Dim mensajeError As New ErroresForm
        If (validaVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                Dim objSuela As New Programacion.Negocios.CargaSuelaGlobalBU
                If txtCodigo.Text <> "0" And txtCodigo.Text <> "" Then
                    If objSuela.ModificarSuelaGlobal(txtDescripcion.Text, rdoActivo.Checked, Integer.Parse(txtCodigo.Text)) Then
                        mensaje.mensaje = "El registro se realizó con éxito."
                        mensaje.ShowDialog()
                        Me.Close()
                    Else
                        mensajeError.mensaje = "Ocurrio un error al registrar información."
                        mensajeError.ShowDialog()
                    End If
                Else
                    If objSuela.RegistraSuelaGlobal(txtDescripcion.Text, rdoActivo.Checked) Then
                        mensaje.mensaje = "El registro se realizó con éxito."
                        mensaje.ShowDialog()
                        Me.Close()
                    Else
                        mensajeError.mensaje = "Ocurrio un error al registrar información."
                        mensajeError.ShowDialog()
                    End If
                End If


            Else
            End If
        Else
            Dim mensaje2 As New AdvertenciaForm
            mensaje2.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje2.ShowDialog()
        End If
    End Sub

    

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class