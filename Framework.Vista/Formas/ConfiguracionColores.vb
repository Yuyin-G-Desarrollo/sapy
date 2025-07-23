Public Class PreferenciasColores

	Private Sub pnlEncabezado_Click(sender As System.Object, e As System.EventArgs) Handles pnlEncabezado.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			pnlEncabezado.BackColor = ColorDialog.Color
		End If
	End Sub

	Private Sub lblTitulo_Click(sender As System.Object, e As System.EventArgs) Handles lblTitulo.Click
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
		End If
	End Sub

	Private Sub lblLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles lblLimpiar.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			lblLimpiar.ForeColor = ColorDialog.Color
		End If
	End Sub


	Private Sub ConfiguracionColores_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			Me.BackColor = ColorDialog.Color
		End If
	End Sub

	Private Sub lblEtiquetas_Click(sender As System.Object, e As System.EventArgs) Handles lblEtiquetas.Click
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			lblEtiquetas.ForeColor = ColorDialog.Color
		End If
	End Sub




	Private Sub grdColores_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles grdColores.MouseClick
		If ColorDialog.ShowDialog() = DialogResult.OK Then
			grdColores.BackgroundColor = ColorDialog.Color
		End If
	End Sub

	Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        ConfigColores.cambiarConfiguracion(
          System.Drawing.ColorTranslator.ToHtml(pnlEncabezado.BackColor),
          System.Drawing.ColorTranslator.ToHtml(Me.BackColor),
          System.Drawing.ColorTranslator.ToHtml(lblEtiquetas.ForeColor),
          System.Drawing.ColorTranslator.ToHtml(grdColores.BackgroundColor),
          System.Drawing.ColorTranslator.ToHtml(lblTitulo.ForeColor))

        Nomina.Vista.ConfigColores.cambiarConfiguracion(
          System.Drawing.ColorTranslator.ToHtml(pnlEncabezado.BackColor),
          System.Drawing.ColorTranslator.ToHtml(Me.BackColor),
          System.Drawing.ColorTranslator.ToHtml(lblEtiquetas.ForeColor),
          System.Drawing.ColorTranslator.ToHtml(grdColores.BackgroundColor),
          System.Drawing.ColorTranslator.ToHtml(lblTitulo.ForeColor))
	End Sub

	Private Sub PreferenciasColores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

	End Sub
End Class