<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpuestoSubsidioEmpleoForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpuestoSubsidioEmpleoForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblActualizar = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.btnEliminar = New System.Windows.Forms.Button()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.lblImpuestoSubsidio = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grdImpuestoSubsidio = New System.Windows.Forms.DataGridView()
		Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColRiseId = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColLimiteInferior = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColLimiteSuperior = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColCuotaFija = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColPorcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.grdImpuestoSubsidio, System.ComponentModel.ISupportInitialize).BeginInit()
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
		Me.pnlEncabezado.Controls.Add(Me.lblImpuestoSubsidio)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(0, 2)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(572, 69)
		Me.pnlEncabezado.TabIndex = 6
		'
		'lblActualizar
		'
		Me.lblActualizar.AutoSize = True
		Me.lblActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblActualizar.Location = New System.Drawing.Point(128, 43)
		Me.lblActualizar.Name = "lblActualizar"
		Me.lblActualizar.Size = New System.Drawing.Size(66, 16)
		Me.lblActualizar.TabIndex = 59
		Me.lblActualizar.Text = "Actualizar"
		Me.lblActualizar.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Button1
		'
        Me.Button1.Image = Global.Nomina.Vista.My.Resources.Resources.aceptar_32
		Me.Button1.Location = New System.Drawing.Point(140, 11)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(32, 32)
		Me.Button1.TabIndex = 58
		Me.Button1.UseVisualStyleBackColor = True
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(64, 43)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(56, 16)
		Me.lblCancelar.TabIndex = 57
		Me.lblCancelar.Text = "Eliminar"
		Me.lblCancelar.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'btnEliminar
		'
		Me.btnEliminar.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar_321
		Me.btnEliminar.Location = New System.Drawing.Point(76, 11)
		Me.btnEliminar.Name = "btnEliminar"
		Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
		Me.btnEliminar.TabIndex = 56
		Me.btnEliminar.UseVisualStyleBackColor = True
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(2, 43)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(60, 16)
		Me.lblGuardar.TabIndex = 55
		Me.lblGuardar.Text = "Guardar "
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar_32
		Me.btnGuardar.Location = New System.Drawing.Point(14, 11)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 54
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'lblImpuestoSubsidio
		'
		Me.lblImpuestoSubsidio.AutoSize = True
		Me.lblImpuestoSubsidio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblImpuestoSubsidio.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblImpuestoSubsidio.Location = New System.Drawing.Point(331, 47)
		Me.lblImpuestoSubsidio.Name = "lblImpuestoSubsidio"
		Me.lblImpuestoSubsidio.Size = New System.Drawing.Size(237, 20)
		Me.lblImpuestoSubsidio.TabIndex = 21
		Me.lblImpuestoSubsidio.Text = " Impuestos Subcidio Empleo"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(440, 4)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grdImpuestoSubsidio
		'
		Me.grdImpuestoSubsidio.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdImpuestoSubsidio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdImpuestoSubsidio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRiseId, Me.ColLimiteInferior, Me.ColLimiteSuperior, Me.ColCuotaFija, Me.ColPorcentaje})
		Me.grdImpuestoSubsidio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
		Me.grdImpuestoSubsidio.Location = New System.Drawing.Point(5, 80)
		Me.grdImpuestoSubsidio.Name = "grdImpuestoSubsidio"
		Me.grdImpuestoSubsidio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdImpuestoSubsidio.Size = New System.Drawing.Size(563, 240)
		Me.grdImpuestoSubsidio.TabIndex = 7
		'
		'DataGridViewTextBoxColumn1
		'
		Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn1.HeaderText = "id"
		Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
		Me.DataGridViewTextBoxColumn1.Visible = False
		'
		'DataGridViewTextBoxColumn2
		'
		Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn2.HeaderText = "Limite Inferior"
		Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
		'
		'DataGridViewTextBoxColumn3
		'
		Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn3.HeaderText = "Limite Superior"
		Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
		'
		'DataGridViewTextBoxColumn4
		'
		Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn4.HeaderText = "Cuota Fija"
		Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
		'
		'DataGridViewTextBoxColumn5
		'
		Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.DataGridViewTextBoxColumn5.HeaderText = "Por ciento sobre el excedente del límite inferior "
		Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
		'
		'ColRiseId
		'
		Me.ColRiseId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColRiseId.HeaderText = "id"
		Me.ColRiseId.Name = "ColRiseId"
		Me.ColRiseId.Visible = False
		'
		'ColLimiteInferior
		'
		Me.ColLimiteInferior.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColLimiteInferior.HeaderText = "Limite Inferior"
		Me.ColLimiteInferior.Name = "ColLimiteInferior"
		'
		'ColLimiteSuperior
		'
		Me.ColLimiteSuperior.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColLimiteSuperior.HeaderText = "Limite Superior"
		Me.ColLimiteSuperior.Name = "ColLimiteSuperior"
		'
		'ColCuotaFija
		'
		Me.ColCuotaFija.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColCuotaFija.HeaderText = "Cuota Fija"
		Me.ColCuotaFija.Name = "ColCuotaFija"
		'
		'ColPorcentaje
		'
		Me.ColPorcentaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColPorcentaje.HeaderText = "Por ciento sobre el excedente del límite inferior "
		Me.ColPorcentaje.Name = "ColPorcentaje"
		'
		'ImpuestoSubsidioEmpleoForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(575, 329)
		Me.Controls.Add(Me.grdImpuestoSubsidio)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ImpuestoSubsidioEmpleoForm"
		Me.Text = "Rango De Impuestos Subsidio Empleo "
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grdImpuestoSubsidio, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblActualizar As System.Windows.Forms.Label
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents btnEliminar As System.Windows.Forms.Button
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents lblImpuestoSubsidio As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grdImpuestoSubsidio As System.Windows.Forms.DataGridView
	Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColRiseId As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColLimiteInferior As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColLimiteSuperior As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColCuotaFija As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColPorcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
