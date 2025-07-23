<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FactoresDeIntegracionForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FactoresDeIntegracionForm))
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblActualizar = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.btnEliminar = New System.Windows.Forms.Button()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.lblFactoresDeIntegracion = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grdFactoresDeIntegracion = New System.Windows.Forms.DataGridView()
		Me.ColId = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColAñosDeServicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColDiasDeVacaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColFactorPrimaVacacional = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColFactorAguinaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColFactorDeIntegracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.grdFactoresDeIntegracion, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblActualizar)
		Me.pnlEncabezado.Controls.Add(Me.Button1)
		Me.pnlEncabezado.Controls.Add(Me.lblCancelar)
		Me.pnlEncabezado.Controls.Add(Me.btnEliminar)
		Me.pnlEncabezado.Controls.Add(Me.lblGuardar)
		Me.pnlEncabezado.Controls.Add(Me.btnGuardar)
		Me.pnlEncabezado.Controls.Add(Me.lblFactoresDeIntegracion)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(1, 1)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(744, 69)
		Me.pnlEncabezado.TabIndex = 5
		'
		'lblActualizar
		'
		Me.lblActualizar.AutoSize = True
		Me.lblActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblActualizar.Location = New System.Drawing.Point(138, 42)
		Me.lblActualizar.Name = "lblActualizar"
		Me.lblActualizar.Size = New System.Drawing.Size(66, 16)
		Me.lblActualizar.TabIndex = 65
		Me.lblActualizar.Text = "Actualizar"
		Me.lblActualizar.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Button1
		'
		Me.Button1.Image = Global.Nomina.Vista.My.Resources.Resources.refresh_32
		Me.Button1.Location = New System.Drawing.Point(150, 10)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(32, 32)
		Me.Button1.TabIndex = 64
		Me.Button1.UseVisualStyleBackColor = True
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(74, 42)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(56, 16)
		Me.lblCancelar.TabIndex = 63
		Me.lblCancelar.Text = "Eliminar"
		Me.lblCancelar.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'btnEliminar
		'
		Me.btnEliminar.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar_321
		Me.btnEliminar.Location = New System.Drawing.Point(86, 10)
		Me.btnEliminar.Name = "btnEliminar"
		Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
		Me.btnEliminar.TabIndex = 62
		Me.btnEliminar.UseVisualStyleBackColor = True
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(12, 42)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(60, 16)
		Me.lblGuardar.TabIndex = 61
		Me.lblGuardar.Text = "Guardar "
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar_32
		Me.btnGuardar.Location = New System.Drawing.Point(24, 10)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 60
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'lblFactoresDeIntegracion
		'
		Me.lblFactoresDeIntegracion.AutoSize = True
		Me.lblFactoresDeIntegracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFactoresDeIntegracion.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblFactoresDeIntegracion.Location = New System.Drawing.Point(541, 47)
		Me.lblFactoresDeIntegracion.Name = "lblFactoresDeIntegracion"
		Me.lblFactoresDeIntegracion.Size = New System.Drawing.Size(199, 20)
		Me.lblFactoresDeIntegracion.TabIndex = 21
		Me.lblFactoresDeIntegracion.Text = "Factores de integracion"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(612, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grdFactoresDeIntegracion
		'
		Me.grdFactoresDeIntegracion.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.grdFactoresDeIntegracion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		Me.grdFactoresDeIntegracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdFactoresDeIntegracion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColId, Me.ColAñosDeServicio, Me.ColDiasDeVacaciones, Me.ColFactorPrimaVacacional, Me.ColFactorAguinaldo, Me.ColFactorDeIntegracion})
		Me.grdFactoresDeIntegracion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
		Me.grdFactoresDeIntegracion.Location = New System.Drawing.Point(11, 76)
		Me.grdFactoresDeIntegracion.Name = "grdFactoresDeIntegracion"
		Me.grdFactoresDeIntegracion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdFactoresDeIntegracion.Size = New System.Drawing.Size(724, 384)
		Me.grdFactoresDeIntegracion.TabIndex = 6
		'
		'ColId
		'
		Me.ColId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColId.HeaderText = "id"
		Me.ColId.Name = "ColId"
		Me.ColId.Visible = False
		'
		'ColAñosDeServicio
		'
		Me.ColAñosDeServicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColAñosDeServicio.HeaderText = "Años de servicio"
		Me.ColAñosDeServicio.Name = "ColAñosDeServicio"
		'
		'ColDiasDeVacaciones
		'
		Me.ColDiasDeVacaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColDiasDeVacaciones.HeaderText = "Dias de vacaciones"
		Me.ColDiasDeVacaciones.Name = "ColDiasDeVacaciones"
		'
		'ColFactorPrimaVacacional
		'
		Me.ColFactorPrimaVacacional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColFactorPrimaVacacional.HeaderText = "Prima vacacional"
		Me.ColFactorPrimaVacacional.Name = "ColFactorPrimaVacacional"
		'
		'ColFactorAguinaldo
		'
		Me.ColFactorAguinaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColFactorAguinaldo.HeaderText = "Factor aguinaldo"
		Me.ColFactorAguinaldo.Name = "ColFactorAguinaldo"
		'
		'ColFactorDeIntegracion
		'
		Me.ColFactorDeIntegracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColFactorDeIntegracion.HeaderText = "Factor de integracion"
		Me.ColFactorDeIntegracion.Name = "ColFactorDeIntegracion"
		'
		'DataGridViewTextBoxColumn1
		'
		Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn1.HeaderText = "Años de servicio"
		Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
		Me.DataGridViewTextBoxColumn1.Visible = False
		'
		'DataGridViewTextBoxColumn2
		'
		Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn2.HeaderText = "id"
		Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
		Me.DataGridViewTextBoxColumn2.Visible = False
		'
		'DataGridViewTextBoxColumn3
		'
		Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn3.HeaderText = "Dias de vacaciones"
		Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
		'
		'DataGridViewTextBoxColumn4
		'
		Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn4.HeaderText = "Prima vacacional"
		Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
		'
		'DataGridViewTextBoxColumn5
		'
		Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn5.HeaderText = "Factor aguinaldo"
		Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
		'
		'DataGridViewTextBoxColumn6
		'
		Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn6.HeaderText = "Factor de integracion"
		Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
		'
		'FactoresDeIntegracionForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(744, 470)
		Me.Controls.Add(Me.grdFactoresDeIntegracion)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "FactoresDeIntegracionForm"
		Me.Text = "FactoresDeIntegracionForm"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grdFactoresDeIntegracion, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblFactoresDeIntegracion As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grdFactoresDeIntegracion As System.Windows.Forms.DataGridView
	Friend WithEvents lblActualizar As System.Windows.Forms.Label
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents btnEliminar As System.Windows.Forms.Button
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColId As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColAñosDeServicio As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColDiasDeVacaciones As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColFactorPrimaVacacional As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColFactorAguinaldo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColFactorDeIntegracion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
