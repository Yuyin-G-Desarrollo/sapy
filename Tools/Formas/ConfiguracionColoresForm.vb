Public Class ConfiguracionColoresForm
	Private Sub pnlEncabezado_Click(sender As System.Object, e As System.EventArgs) Handles pnlEncabezado.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			pnlEncabezado.BackColor = ColorDialog.Color
		End If
	End Sub

	Private Sub lblTitulo_Click(sender As System.Object, e As System.EventArgs)
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			lblTitulo.ForeColor = ColorDialog.Color
		End If
	End Sub

	Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdColores.CellContentClick
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			grdColores.BackgroundColor = ColorDialog.Color
		End If
	End Sub


	Private Sub lblBúscar_Click(sender As System.Object, e As System.EventArgs) Handles lblBuscar.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			lblBuscar.ForeColor = ColorDialog.Color

			lblEtiquetas.ForeColor = lblBuscar.ForeColor

			lblTitulo.ForeColor = lblBuscar.ForeColor
			lblLimpiar.ForeColor = lblBuscar.ForeColor
		End If
	End Sub

	Private Sub lblLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles lblLimpiar.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			lblLimpiar.ForeColor = ColorDialog.Color

			lblEtiquetas.ForeColor = lblLimpiar.ForeColor

			lblTitulo.ForeColor = lblLimpiar.ForeColor
			lblBuscar.ForeColor = lblLimpiar.ForeColor
		End If
	End Sub


	Private Sub ConfiguracionColores_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			Me.BackColor = ColorDialog.Color
			Panel1.BackColor = Me.BackColor
		End If
	End Sub

	Private Sub lblEtiquetas_Click(sender As System.Object, e As System.EventArgs) Handles lblEtiquetas.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			lblEtiquetas.ForeColor = ColorDialog.Color

   'lblTitulo.ForeColor = lblEtiquetas.ForeColor
			lblBuscar.ForeColor = lblEtiquetas.ForeColor
			lblLimpiar.ForeColor = lblEtiquetas.ForeColor
		End If
	End Sub




	Private Sub grdColores_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles grdColores.MouseClick
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			grdColores.BackgroundColor = ColorDialog.Color
		End If
	End Sub

 Private Sub ConfiguracionColoresForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        If My.Settings.ftpURL <> "" Then
            pnlEncabezado.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpURL)
        End If

       

        If My.Settings.ftpPassword <> "" Then
            lblBuscar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpPassword)
            lblEtiquetas.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpPassword)
            lblLimpiar.ForeColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpPassword)
        End If

        If My.Settings.ftpUser <> "" Then
            Me.BackColor = System.Drawing.ColorTranslator.FromHtml(My.Settings.ftpUser)
        End If



    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        cambiarConfiguracion(
          System.Drawing.ColorTranslator.ToHtml(pnlEncabezado.BackColor),
          System.Drawing.ColorTranslator.ToHtml(Me.BackColor),
          System.Drawing.ColorTranslator.ToHtml(lblEtiquetas.ForeColor),
          System.Drawing.ColorTranslator.ToHtml(grdColores.BackgroundColor),
          System.Drawing.ColorTranslator.ToHtml(lblTitulo.ForeColor))

        '    (
        'System.Drawing.ColorTranslator.ToHtml(pnlEncabezado.BackColor),
        'System.Drawing.ColorTranslator.ToHtml(Me.BackColor),
        'System.Drawing.ColorTranslator.ToHtml(lblEtiquetas.ForeColor),
        'System.Drawing.ColorTranslator.ToHtml(grdColores.BackgroundColor),
        'System.Drawing.ColorTranslator.ToHtml(lblTitulo.ForeColor))

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "Configuracion guardada"
        mensajeExito.Show()
    End Sub

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub lblAltasSucursales_Click(sender As System.Object, e As System.EventArgs) Handles lblTitulo.Click
        If ColorDialog.ShowDialog() = DialogResult.OK Then
            lblTitulo.ForeColor = ColorDialog.Color
            'lblEtiquetas.ForeColor = lblTitulo.ForeColor
            'lblBuscar.ForeColor = lblTitulo.ForeColor
            'lblLimpiar.ForeColor = lblTitulo.ForeColor
        End If
    End Sub


    Private Sub roundButton_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_Enter_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Panel1_Click(sender As System.Object, e As System.EventArgs) Handles Panel1.Click
        If ColorDialog.ShowDialog() = DialogResult.OK Then
            Panel1.BackColor = ColorDialog.Color
            Me.BackColor = ColorDialog.Color
        End If
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'If ColorDialog.ShowDialog() = DialogResult.OK Then
        'Me.BackColor = ColorDialog.Color


        Me.BackColor = Color.AliceBlue
        Panel1.BackColor = Color.AliceBlue
        lblBuscar.ForeColor = Color.DodgerBlue
        lblEtiquetas.ForeColor = Color.DodgerBlue
        lblLimpiar.ForeColor = Color.DodgerBlue
        lblTitulo.ForeColor = Color.SteelBlue
        grdColores.BackgroundColor = Color.LightSteelBlue
        pnlEncabezado.BackColor = Color.White

        'End If
    End Sub


    Private Sub cambiarConfiguracion(ByVal encabezado As String, fondo As String, etiquetas As String, grid As String, titulo As String)
        
    End Sub


End Class