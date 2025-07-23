Imports Entidades
Imports Framework.Negocios
Imports Framework.Datos

Public Class AltasModulosForm

  

    Private Sub txtNombreDelModulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelModulo.KeyPress

        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If

    End Sub

    Private Sub txtModuloSuperior_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) _
        Or e.KeyChar = "." _
        Or e.KeyChar = "_" _
        Or e.KeyChar = "-" Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtModulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSuperior.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtComponente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComponente.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) _
        Or e.KeyChar = "." _
        Or e.KeyChar = "_" _
        Or e.KeyChar = "-" Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtIcono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIcono.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) _
        Or e.KeyChar = "." _
        Or e.KeyChar = "_" _
        Or e.KeyChar = "-" Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtArchivoDeReporte_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArchivoDeReporte.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) _
        Or e.KeyChar = "." _
        Or e.KeyChar = "_" _
        Or e.KeyChar = "-" Then

            e.Handled = False
        End If
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim falla As Boolean = False
        If txtNombreDelModulo.Text <> "" Then

            lblNombreDelModulo.ForeColor = Color.Black
        Else


            lblNombreDelModulo.ForeColor = Color.Red
            falla = True

        End If

        If txtClave.Text <> "" Then

            lblClave.ForeColor = Color.Black
        Else

            lblClave.ForeColor = Color.Red
            falla = True


        End If

        If falla Then
            Dim formaError As New AdvertenciaForm
            formaError.mensaje = "Complete todos los campos obligatorios"
            formaError.Show()
        Else
            Try
                Dim modulo As New Modulos
                Dim objModulosBU As New ModulosBU
                modulo.PNombre = txtNombreDelModulo.Text
                modulo.PClave = txtClave.Text
                modulo.PMenu = rdoMenu.Checked
                modulo.PGuardarHistorial = rdoGuardarHistorial.Checked
                modulo.PActivo = rdoActivo.Checked
                modulo.PComponente = txtComponente.Text
                modulo.PIcono = txtIcono.Text
                modulo.PArchivoReporte = txtArchivoDeReporte.Text

                If (cmbSuperior.SelectedIndex > 0) Then
                    Dim superior As New Modulos
                    superior.PModuloid = CInt(cmbSuperior.SelectedValue)
                    modulo.PSuperiorid = superior
                End If

                objModulosBU.AgregarModulo(modulo)
                Dim exitoForm As New ExitoForm
                exitoForm.mensaje = "Registro Guardado"
                exitoForm.ShowDialog()
                Me.Close()
            Catch ex As Exception
                Dim Fail As New ErroresForm
                Fail.mensaje = HistorialBU.GuardaError(Errores.MensajeInterno(ex))
                Fail.ShowDialog()
            End Try

        End If
    End Sub




    Private Sub AltasModulosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitCombos()
    End Sub

    Private Sub InitCombos()
        'INIT combo Modulo superior
        Dim objModulosBU As New ModulosBU
        Dim tablaModulos As New DataTable
        tablaModulos = objModulosBU.ListaModulosTodos
        tablaModulos.Rows.InsertAt(tablaModulos.NewRow, 0)
        With cmbSuperior
            .DataSource = tablaModulos
            .DisplayMember = "modu_nombre"
            .ValueMember = "modu_moduloid"
        End With
    End Sub
End Class