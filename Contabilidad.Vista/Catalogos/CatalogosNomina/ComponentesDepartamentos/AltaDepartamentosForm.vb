Imports Tools

Public Class AltaDepartamentosForm
    Private Sub AltaDepartamentosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjB As New Contabilidad.Negocios.CatalogoDepartamentoBU
        cmbC_Sueldo = ObjB.llenarcmbClaves(cmbC_Sueldo, 0)
        cmbC_PremioP = ObjB.llenarcmbClaves(cmbC_PremioP, 1)
        cmbPremio_P = ObjB.llenarcmbClaves(cmbPremio_P, 2)
        cmbClaveV = ObjB.llenarcmbClaves(cmbClaveV, 3)
        cmbPrimaV = ObjB.llenarcmbClaves(cmbPrimaV, 4)
        cmbClave_A = ObjB.llenarcmbClaves(cmbClave_A, 5)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim entidadDepa As New Entidades.DepartamentosByPatron
            entidadDepa.ID_Patron = txtidpatron.Text
            entidadDepa.NombreDepartamento = txtdepartamento.Text
            entidadDepa.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidadDepa.Fecha = Date.Now

            If cmbC_Sueldo.Text.Equals("") Then
                lblcs.ForeColor = Drawing.Color.Red
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Llena los campos requeridos")
                Return
            Else
                lblcs.ForeColor = Drawing.Color.Black
            End If
            If txtdepartamento.Text.Equals("") Then
                lbldepa.ForeColor = Drawing.Color.Red
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Llena los campos requeridos")
                Return
            Else
                lbldepa.ForeColor = Drawing.Color.Black
            End If
            If cmbPrimaV.Text.Equals("") Then
                lblcpv.ForeColor = Drawing.Color.Red
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Llena los campos requeridos")
                Return
            Else
                lblcpv.ForeColor = Drawing.Color.Black
            End If
            If cmbClaveV.Text.Equals("") Then
                lblca.ForeColor = Drawing.Color.Red
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Llena los campos requeridos")
                Return
            Else
                lblca.ForeColor = Drawing.Color.Black
            End If
            If cmbClave_A.Text.Equals("") Then
                lblca2.ForeColor = Drawing.Color.Red
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Llena los campos requeridos")
                Return
            Else
                lblca2.ForeColor = Drawing.Color.Black
            End If
            entidadDepa.ClaveSueldo = cmbC_Sueldo.Text
            entidadDepa.ClavePremioPuntualidad = cmbC_PremioP.Text
            entidadDepa.ClavePremioAsistencia = cmbPremio_P.Text
            entidadDepa.ClavePrimaVacacional = cmbPrimaV.Text
            entidadDepa.ClaveVacaciones = cmbClaveV.Text
            entidadDepa.ClaveAguinaldo = cmbClave_A.Text
            insertarDepartamento(entidadDepa)
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Error" + " " + ex.Message)
        End Try

    End Sub

    Private Sub insertarDepartamento(ByVal entidadDepa As Entidades.DepartamentosByPatron)

        Dim ObjB As New Contabilidad.Negocios.CatalogoDepartamentoBU
        Try
            If txtPatron.Text = "" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de ingresar un Patron")
            ElseIf txtdepartamento.Text = "" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de ingresar un Departamento")
            Else

                Dim success = ObjB.InsertarDepartamento_PorPatron(entidadDepa)
                If success.Resp > 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                    Me.Close()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
                End If
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El departamento no es valido")
        End Try
    End Sub




    Private Sub cmbPrimaV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPrimaV.KeyPress
        If Not IsNumeric(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbClaveV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbClaveV.KeyPress
        If Not IsNumeric(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbClave_A_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbClave_A.KeyPress
        If Not IsNumeric(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbC_PremioP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbC_PremioP.KeyPress
        If Not IsNumeric(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbPremio_P_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPremio_P.KeyPress
        If Not IsNumeric(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub cmbC_Sueldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbC_Sueldo.KeyPress
        If Not IsNumeric(e.KeyChar) _
                     AndAlso Not Char.IsControl(e.KeyChar) _
                     AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtdepartamento_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtdepartamento.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub
End Class