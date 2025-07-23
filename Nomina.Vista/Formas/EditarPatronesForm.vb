Imports Nomina.Negocios
Imports Framework.Negocios
Imports Tools

Public Class EditarPatronesForm
    Public patronid As Integer
    Public Property Ppatronid As Integer
        Get
            Return patronid
        End Get
        Set(value As Integer)
            patronid = value
        End Set
    End Property
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim objConfirmacion As New ConfirmarForm
        Dim objAdvertencia As New AdvertenciaForm
        objAdvertencia.mensaje = "Debe validar todos los datos a modificar antes de guardar." + vbNewLine + "Esta acción podrá afectar otros procesos."
        objAdvertencia.ShowDialog()
        objConfirmacion.mensaje = "¿Está seguro de guardar los cambios?"
        If objConfirmacion.ShowDialog = DialogResult.OK Then

            Dim falla As Boolean = False

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


            If falla Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Faltan campos por completar"
                mensajeAdvertencia.ShowDialog()
                'MsgBox("Falta completar campos")
            Else
                'TOdo OK para editar
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

                patron.Ppatronid = patronid
                Dim objPatronesBU As New PatronesBU
                objPatronesBU.editarPatron(patron)
                Me.Close()
                Dim mensajeExito As New ExitoForm
                mensajeExito.mensaje = "Transaccion exitosa"
                mensajeExito.ShowDialog()
                'MsgBox("Transaccion exitosa")
            End If
        End If
    End Sub
    Public Sub initCombos()
        Dim objCiudadesBU As New CiudadesBU
        Dim tablaCiudades As New DataTable
        tablaCiudades = objCiudadesBU.listaCiudadesActivas(0)
        tablaCiudades.Rows.InsertAt(tablaCiudades.NewRow, 0)
        With cmbCiudad
            .DataSource = tablaCiudades
            .DisplayMember = "city_nombre"
            .ValueMember = "city_ciudadid"
        End With
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub EditarPatronesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.header)

        '      'lblEditarPatrones.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.titulo)
        'lblCancelar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)
        'lblGuardar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.etiquetas)


        'Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.fondo)


        initCombos()
        Dim objPatronBU As New PatronesBU
        Dim patron As New Entidades.Patrones
        patron = objPatronBU.buscarPatrones(patronid)

        txtNombreDelPatron.Text = patron.Pnombre
        txtRFC.Text = patron.Prfc
        txtNumeroDeRegistro.Text = patron.PNpatronal
        txtCalle.Text = patron.Pcalle
        txtNumero.Text = patron.PDnumero
        txtColonia.Text = patron.Pcolonia

        cmbCiudad.SelectedValue = patron.PciudadId
        txtCP.Text = patron.Pcp


        If (patron.Pactivo) Then
            btnSi.Checked = True
        Else
            btnNo.Checked = True
        End If

        rdoComisionSI.Checked = patron.Pcomisiones
        rdoComisionNO.Checked = Not (patron.Pcomisiones)
        numPorcentajeComision.Value = patron.PporcentajeComision


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

    Private Sub lblCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancelar.Click

    End Sub

    Private Sub btnCncelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub rdoComisionSI_CheckedChanged(sender As Object, e As EventArgs) Handles rdoComisionSI.CheckedChanged
        pnlPorcentaje.Visible = rdoComisionSI.Checked
    End Sub

End Class