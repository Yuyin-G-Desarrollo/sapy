<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionColoresForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionColoresForm))
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.lblBuscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.grdColores = New System.Windows.Forms.DataGridView()
		Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblTitulo = New System.Windows.Forms.Label()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.lblEtiquetas = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.ColorDialog = New System.Windows.Forms.ColorDialog()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblRevertir = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		CType(Me.grdColores, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(508, 493)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 58
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(432, 493)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 57
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(437, 455)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 55
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(515, 455)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 56
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'lblBuscar
		'
		Me.lblBuscar.AutoSize = True
		Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBuscar.Location = New System.Drawing.Point(447, 77)
		Me.lblBuscar.Name = "lblBuscar"
		Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBuscar.TabIndex = 53
		Me.lblBuscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(496, 77)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 52
		Me.lblLimpiar.Text = "Limpiar"
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(499, 42)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 51
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(450, 42)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 50
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'grdColores
		'
		Me.grdColores.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdColores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdColores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6})
		Me.grdColores.Cursor = System.Windows.Forms.Cursors.Hand
		Me.grdColores.Location = New System.Drawing.Point(13, 217)
		Me.grdColores.Name = "grdColores"
		Me.grdColores.Size = New System.Drawing.Size(563, 232)
		Me.grdColores.TabIndex = 53
		'
		'Column1
		'
		Me.Column1.HeaderText = "Nombre"
		Me.Column1.Name = "Column1"
		'
		'Column2
		'
		Me.Column2.HeaderText = "Apellido"
		Me.Column2.Name = "Column2"
		'
		'Column3
		'
		Me.Column3.HeaderText = "Teléfono"
		Me.Column3.Name = "Column3"
		'
		'Column4
		'
		Me.Column4.HeaderText = "Direccion"
		Me.Column4.Name = "Column4"
		'
		'Column6
		'
		Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.Column6.HeaderText = "Ciudad"
		Me.Column6.Name = "Column6"
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblEtiquetas)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Cursor = System.Windows.Forms.Cursors.Hand
		Me.pnlEncabezado.Location = New System.Drawing.Point(-1, -1)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(593, 86)
		Me.pnlEncabezado.TabIndex = 52
		'
		'lblTitulo
		'
		Me.lblTitulo.AutoSize = True
		Me.lblTitulo.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblTitulo.Location = New System.Drawing.Point(374, 60)
		Me.lblTitulo.Name = "lblTitulo"
		Me.lblTitulo.Size = New System.Drawing.Size(214, 20)
		Me.lblTitulo.TabIndex = 34
		Me.lblTitulo.Text = "Configuracion De Colores"
		'
		'btnAltas
		'
		Me.btnAltas.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
		Me.btnAltas.Location = New System.Drawing.Point(17, 11)
		Me.btnAltas.Name = "btnAltas"
		Me.btnAltas.Size = New System.Drawing.Size(32, 32)
		Me.btnAltas.TabIndex = 31
		Me.btnAltas.UseVisualStyleBackColor = True
		'
		'lblEtiquetas
		'
		Me.lblEtiquetas.AutoSize = True
		Me.lblEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblEtiquetas.Location = New System.Drawing.Point(14, 46)
		Me.lblEtiquetas.Name = "lblEtiquetas"
		Me.lblEtiquetas.Size = New System.Drawing.Size(45, 13)
		Me.lblEtiquetas.TabIndex = 33
		Me.lblEtiquetas.Text = "Muestra"
		'
		'imgLogo
		'
		Me.imgLogo.Cursor = System.Windows.Forms.Cursors.Default
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(453, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 56)
		Me.imgLogo.TabIndex = 1
		Me.imgLogo.TabStop = False
		'
		'ColorDialog
		'
		Me.ColorDialog.FullOpen = True
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Controls.Add(Me.btnBuscar)
		Me.Panel1.Controls.Add(Me.btnLimpiar)
		Me.Panel1.Controls.Add(Me.lblLimpiar)
		Me.Panel1.Controls.Add(Me.lblBuscar)
		Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Panel1.Location = New System.Drawing.Point(12, 91)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(564, 115)
		Me.Panel1.TabIndex = 59
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(4, 4)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(55, 13)
		Me.Label1.TabIndex = 54
		Me.Label1.Text = "Búsqueda"
		'
		'lblRevertir
		'
		Me.lblRevertir.AutoSize = True
		Me.lblRevertir.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblRevertir.Location = New System.Drawing.Point(358, 495)
		Me.lblRevertir.Name = "lblRevertir"
		Me.lblRevertir.Size = New System.Drawing.Size(53, 13)
		Me.lblRevertir.TabIndex = 61
		Me.lblRevertir.Text = "Restaurar"
		'
		'Button1
		'
		Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
		Me.Button1.Location = New System.Drawing.Point(363, 457)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(32, 32)
		Me.Button1.TabIndex = 60
		Me.Button1.UseVisualStyleBackColor = True
		'
		'ConfiguracionColoresForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(591, 519)
		Me.Controls.Add(Me.lblRevertir)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.grdColores)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ConfiguracionColoresForm"
		Me.Text = "Configuracion Colores"
		CType(Me.grdColores, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents lblBuscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents grdColores As System.Windows.Forms.DataGridView
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblEtiquetas As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents ColorDialog As System.Windows.Forms.ColorDialog
	Friend WithEvents lblTitulo As System.Windows.Forms.Label
	Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents lblRevertir As System.Windows.Forms.Label
	Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
