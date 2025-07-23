Imports Nomina.Negocios
Imports Framework.Negocios
'Imports Tools

Public Class AltasPatronesForm

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False
        Dim mensajeAdvertencia As New Tools.AdvertenciaForm

        If txtNombreDelPatron.Text <> "" Then
            lblNombreDelPatron.ForeColor = Color.Black
        Else
            lblNombreDelPatron.ForeColor = Color.Red
            falla = True
        End If

        If txtRFC.Text <> "" Then
            lblRFC.ForeColor = Color.Black
        Else
            lblRFC.ForeColor = Color.Red
            falla = True
        End If

        If txtNumeroDeRegistro.Text <> "" Then
            lblNumeroDeRegistroPatronal.ForeColor = Color.Black
            'lblPatronal.ForeColor = Color.Black
        Else
            lblNumeroDeRegistroPatronal.ForeColor = Color.Red
            'lblPatronal.ForeColor = Color.Red
            falla = True

        End If

        If txtCalle.Text <> "" Then
            lblCalle.ForeColor = Color.Black
        Else
            lblCalle.ForeColor = Color.Red
            falla = True
        End If

        If txtNumero.Text <> "" Then
            lblNúmero.ForeColor = Color.Black
        Else
            lblNúmero.ForeColor = Color.Red
            falla = True
        End If

        If txtColonia.Text <> "" Then
            lblColonia.ForeColor = Color.Black
        Else
            lblColonia.ForeColor = Color.Red
            falla = True
        End If

        If cmbCiudad.Text <> "" Then
            lblCiudad.ForeColor = Color.Black
        Else
            lblCiudad.ForeColor = Color.Red
            falla = True
        End If

        If txtCP.Text <> "" Then
            lblCP.ForeColor = Color.Black
        Else
            lblCP.ForeColor = Color.Red
            falla = True
        End If

        'If btnSi.Text <> "" Then
        '    lblActivo.ForeColor = Color.Black
        'Else
        '    lblActivo.ForeColor = Color.Red
        '    falla = True
        'End If

        If rdoComisionSI.Checked Then
            If numPorcentajeComision.Value > 0 Then
                lblPorcentaje.ForeColor = Color.Black
            Else
                lblPorcentaje.ForeColor = Color.Red
                falla = True
            End If
        End If


        If Not falla Then

            Dim patron As New Entidades.Patrones
            patron.Pnombre = txtNombreDelPatron.Text
            patron.Prfc = txtRFC.Text
            patron.PNpatronal = txtNumeroDeRegistro.Text
            patron.Pcalle = txtCalle.Text
            patron.PDnumero = txtNumero.Text
            patron.Pcolonia = txtColonia.Text
            patron.Pcp = txtCP.Text
            patron.Pactivo = btnSi.Checked
            patron.Pcomisiones = rdoComisionSI.Checked
            patron.PporcentajeComision = numPorcentajeComision.Value

            If cmbCiudad.SelectedIndex > 0 Then
                patron.PciudadId = CInt(cmbCiudad.SelectedValue)
            End If

            Dim objPatronesBU As New PatronesBU
            objPatronesBU.guardarPatron(patron)
            Me.Close()

            'MsgBox("Transaccion exitosa")
            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.ShowDialog()

            'Me.Close()
        Else
            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.ShowDialog()
            'MsgBox("Falta completar campos")

        End If
    End Sub


    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub
    '

    Private Sub AltasPatronesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)
        rdoComisionNO.Checked = True
        'lblAltasPatrones.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)

        initCombos()
    End Sub
    Public Sub initCombos()
        Dim objCiudadesBU As New CiudadesBU
        Dim tablaCiudad As New DataTable
        tablaCiudad = objCiudadesBU.listaCiudadesActivas(0)
        tablaCiudad.Rows.InsertAt(tablaCiudad.NewRow, 0)
        With cmbCiudad
            .DataSource = tablaCiudad
            .DisplayMember = "city_nombre"
            .ValueMember = "city_ciudadid"
        End With
    End Sub

    Private Sub txtNombreDelPatron_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelPatron.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtNombreDelPatron.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub txtRFC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtRFC.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub
    Private Sub txtNumeroDeRegistro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroDeRegistro.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtNumeroDeRegistro.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub txtCalle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalle.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtCalle.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtNumero.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub txtColonia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColonia.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtColonia.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub rdoComisionSI_CheckedChanged(sender As Object, e As EventArgs) Handles rdoComisionSI.CheckedChanged ', rdoComisionNO.CheckedChanged
        pnlPorcentaje.Visible = rdoComisionSI.Checked
    End Sub

End Class