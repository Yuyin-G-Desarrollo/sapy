Imports Framework.Negocios
Imports Entidades

Public Class EditarModulosForm

    Public ModuloId As Int32

    Private Sub txtNombreDelModulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtClave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtModulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtComponente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub txtIcono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtArchivoDeReporte_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
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
            MsgBox("Falta completar campos")
        Else
            Try
                Dim modulo As New Modulos
                Dim objModulosBU As New ModulosBU
                modulo.PNombre = txtNombreDelModulo.Text
                modulo.PClave = txtClave.Text
                modulo.PMenu = rdoMenuSi.Checked
                modulo.PGuardarHistorial = rdoHistorialSi.Checked
                modulo.PActivo = rdoActivoSi.Checked
                modulo.PComponente = txtComponente.Text
                modulo.PIcono = txtIcono.Text
                modulo.PArchivoReporte = txtArchivoDeReporte.Text

                If (cmbModulo.SelectedIndex > 0) Then
                    Dim superior As New Modulos
                    superior.PModuloid = CInt(cmbModulo.SelectedValue)
                    modulo.PSuperiorid = superior
                End If

                modulo.PModuloid = ModuloId
                objModulosBU.EditarModulo(modulo)
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

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub EditarModulosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitCombos()
        Dim objModulosBu As New ModulosBU
        Dim modulos As New Entidades.Modulos
        modulos = objModulosBu.BuscarModulo(ModuloId)
        txtNombreDelModulo.Text = modulos.PNombre
        txtClave.Text = modulos.PClave
        txtComponente.Text = modulos.PComponente
        txtIcono.Text = modulos.PIcono
        txtArchivoDeReporte.Text = modulos.PArchivoReporte

        If Not IsNothing(modulos.PSuperiorid) Then
            cmbModulo.SelectedValue = modulos.PSuperiorid.PModuloid
        End If


        If modulos.PMenu Then
            rdoMenuSi.Checked = True
        Else
            rdoMenuNo.Checked = True
        End If

        If modulos.PGuardarHistorial Then
            rdoHistorialSi.Checked = True
        Else
            rdoHistorialNo.Checked = True
        End If

        If modulos.PActivo Then
            rdoActivoSi.Checked = True
        Else
            rdoActivoNo.Checked = True
        End If

    End Sub

    Private Sub InitCombos()
        'INIT combo Modulo superior
        Dim objModulosBU As New ModulosBU
        Dim tablaModulos As New DataTable
        tablaModulos = objModulosBU.ListaModulosTodos
        tablaModulos.Rows.InsertAt(tablaModulos.NewRow, 0)
        With cmbModulo
            .DataSource = tablaModulos
            .DisplayMember = "modu_nombre"
            .ValueMember = "modu_moduloid"
        End With
    End Sub

    Private Sub txtNombreDelModulo_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelModulo.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtClave_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
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

    Private Sub txtComponente_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComponente.KeyPress
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

    Private Sub txtIcono_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIcono.KeyPress
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

    Private Sub txtArchivoDeReporte_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtArchivoDeReporte.KeyPress
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
End Class