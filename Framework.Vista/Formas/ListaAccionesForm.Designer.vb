<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaAccionesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaAccionesForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblPermisos = New System.Windows.Forms.Label()
		Me.btnPermisos = New System.Windows.Forms.Button()
		Me.lblExcepciones = New System.Windows.Forms.Label()
		Me.Editar = New System.Windows.Forms.Label()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.btnExcepciones = New System.Windows.Forms.Button()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.lblAcciones = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.lblNombreDeLaAccion = New System.Windows.Forms.Label()
		Me.txtNombreDeLaAccion = New System.Windows.Forms.TextBox()
		Me.lblTipo = New System.Windows.Forms.Label()
		Me.cmbTipo = New System.Windows.Forms.ComboBox()
		Me.grdAcciones = New System.Windows.Forms.DataGridView()
		Me.grbListaAcciones = New System.Windows.Forms.GroupBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.rdoActivo = New System.Windows.Forms.RadioButton()
		Me.rdoInactivo = New System.Windows.Forms.RadioButton()
		Me.lblActivo = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtClave = New System.Windows.Forms.TextBox()
		Me.cmbModulo = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.ColNombreDeLaAccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.colClave = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.colModulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.colActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.grdAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbListaAcciones.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblPermisos)
		Me.pnlEncabezado.Controls.Add(Me.btnPermisos)
		Me.pnlEncabezado.Controls.Add(Me.lblExcepciones)
		Me.pnlEncabezado.Controls.Add(Me.Editar)
		Me.pnlEncabezado.Controls.Add(Me.btnEditar)
		Me.pnlEncabezado.Controls.Add(Me.btnExcepciones)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAcciones)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(1, -1)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(678, 71)
		Me.pnlEncabezado.TabIndex = 1
		'
		'lblPermisos
		'
		Me.lblPermisos.AutoSize = True
		Me.lblPermisos.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblPermisos.Location = New System.Drawing.Point(118, 44)
		Me.lblPermisos.Name = "lblPermisos"
		Me.lblPermisos.Size = New System.Drawing.Size(49, 13)
		Me.lblPermisos.TabIndex = 29
		Me.lblPermisos.Text = "Permisos"
		'
		'btnPermisos
		'
		Me.btnPermisos.Image = CType(resources.GetObject("btnPermisos.Image"), System.Drawing.Image)
		Me.btnPermisos.Location = New System.Drawing.Point(129, 9)
		Me.btnPermisos.Name = "btnPermisos"
		Me.btnPermisos.Size = New System.Drawing.Size(32, 32)
		Me.btnPermisos.TabIndex = 3
		Me.btnPermisos.UseVisualStyleBackColor = True
		'
		'lblExcepciones
		'
		Me.lblExcepciones.AutoSize = True
		Me.lblExcepciones.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblExcepciones.Location = New System.Drawing.Point(176, 43)
		Me.lblExcepciones.Name = "lblExcepciones"
		Me.lblExcepciones.Size = New System.Drawing.Size(68, 13)
		Me.lblExcepciones.TabIndex = 27
		Me.lblExcepciones.Text = "Excepciones"
		'
		'Editar
		'
		Me.Editar.AutoSize = True
		Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.Editar.Location = New System.Drawing.Point(68, 44)
		Me.Editar.Name = "Editar"
		Me.Editar.Size = New System.Drawing.Size(34, 13)
		Me.Editar.TabIndex = 26
		Me.Editar.Text = "Editar"
		'
		'btnEditar
		'
		Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
		Me.btnEditar.Location = New System.Drawing.Point(70, 9)
		Me.btnEditar.Name = "btnEditar"
		Me.btnEditar.Size = New System.Drawing.Size(32, 32)
		Me.btnEditar.TabIndex = 2
		Me.btnEditar.UseVisualStyleBackColor = True
		'
		'btnExcepciones
		'
		Me.btnExcepciones.Image = CType(resources.GetObject("btnExcepciones.Image"), System.Drawing.Image)
		Me.btnExcepciones.Location = New System.Drawing.Point(193, 9)
		Me.btnExcepciones.Name = "btnExcepciones"
		Me.btnExcepciones.Size = New System.Drawing.Size(32, 32)
		Me.btnExcepciones.TabIndex = 4
		Me.btnExcepciones.UseVisualStyleBackColor = True
		'
		'btnAltas
		'
		Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
		Me.btnAltas.Location = New System.Drawing.Point(11, 9)
		Me.btnAltas.Name = "btnAltas"
		Me.btnAltas.Size = New System.Drawing.Size(32, 32)
		Me.btnAltas.TabIndex = 1
		Me.btnAltas.UseVisualStyleBackColor = True
		'
		'lblAltas
		'
		Me.lblAltas.AutoSize = True
		Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblAltas.Location = New System.Drawing.Point(12, 44)
		Me.lblAltas.Name = "lblAltas"
		Me.lblAltas.Size = New System.Drawing.Size(30, 13)
		Me.lblAltas.TabIndex = 25
		Me.lblAltas.Text = "Altas"
		'
		'lblAcciones
		'
		Me.lblAcciones.AutoSize = True
		Me.lblAcciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAcciones.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblAcciones.Location = New System.Drawing.Point(573, 50)
		Me.lblAcciones.Name = "lblAcciones"
		Me.lblAcciones.Size = New System.Drawing.Size(82, 20)
		Me.lblAcciones.TabIndex = 21
		Me.lblAcciones.Text = "Acciones"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(552, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(123, 53)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'lblNombreDeLaAccion
		'
		Me.lblNombreDeLaAccion.AutoSize = True
		Me.lblNombreDeLaAccion.Location = New System.Drawing.Point(33, 45)
		Me.lblNombreDeLaAccion.Name = "lblNombreDeLaAccion"
		Me.lblNombreDeLaAccion.Size = New System.Drawing.Size(105, 13)
		Me.lblNombreDeLaAccion.TabIndex = 2
		Me.lblNombreDeLaAccion.Text = "Nombre de la accion"
		'
		'txtNombreDeLaAccion
		'
		Me.txtNombreDeLaAccion.Location = New System.Drawing.Point(139, 43)
		Me.txtNombreDeLaAccion.MaxLength = 50
		Me.txtNombreDeLaAccion.Name = "txtNombreDeLaAccion"
		Me.txtNombreDeLaAccion.Size = New System.Drawing.Size(125, 20)
		Me.txtNombreDeLaAccion.TabIndex = 5
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.Location = New System.Drawing.Point(292, 80)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(28, 13)
		Me.lblTipo.TabIndex = 6
		Me.lblTipo.Text = "Tipo"
		'
		'cmbTipo
		'
		Me.cmbTipo.FormattingEnabled = True
		Me.cmbTipo.Items.AddRange(New Object() {"1,Altas", "2,Consultar", "3,Editar", "4,Eliminar", "5,Otro"})
		Me.cmbTipo.Location = New System.Drawing.Point(325, 76)
		Me.cmbTipo.Name = "cmbTipo"
		Me.cmbTipo.Size = New System.Drawing.Size(147, 21)
		Me.cmbTipo.TabIndex = 7
		'
		'grdAcciones
		'
		Me.grdAcciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdAcciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNombreDeLaAccion, Me.colClave, Me.colModulo, Me.colActivo, Me.ColTipo, Me.colId})
		Me.grdAcciones.Location = New System.Drawing.Point(12, 249)
		Me.grdAcciones.Name = "grdAcciones"
		Me.grdAcciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdAcciones.Size = New System.Drawing.Size(655, 254)
		Me.grdAcciones.TabIndex = 10
		'
		'grbListaAcciones
		'
		Me.grbListaAcciones.Controls.Add(Me.GroupBox1)
		Me.grbListaAcciones.Controls.Add(Me.lblActivo)
		Me.grbListaAcciones.Controls.Add(Me.Label2)
		Me.grbListaAcciones.Controls.Add(Me.txtClave)
		Me.grbListaAcciones.Controls.Add(Me.cmbModulo)
		Me.grbListaAcciones.Controls.Add(Me.Label1)
		Me.grbListaAcciones.Controls.Add(Me.btnAbajo)
		Me.grbListaAcciones.Controls.Add(Me.btnArriba)
		Me.grbListaAcciones.Controls.Add(Me.lblBúscar)
		Me.grbListaAcciones.Controls.Add(Me.lblLimpiar)
		Me.grbListaAcciones.Controls.Add(Me.btnLimpiar)
		Me.grbListaAcciones.Controls.Add(Me.btnBuscar)
		Me.grbListaAcciones.Controls.Add(Me.lblNombreDeLaAccion)
		Me.grbListaAcciones.Controls.Add(Me.txtNombreDeLaAccion)
		Me.grbListaAcciones.Controls.Add(Me.cmbTipo)
		Me.grbListaAcciones.Controls.Add(Me.lblTipo)
		Me.grbListaAcciones.Location = New System.Drawing.Point(12, 76)
		Me.grbListaAcciones.Name = "grbListaAcciones"
		Me.grbListaAcciones.Size = New System.Drawing.Size(655, 167)
		Me.grbListaAcciones.TabIndex = 9
		Me.grbListaAcciones.TabStop = False
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.rdoActivo)
		Me.GroupBox1.Controls.Add(Me.rdoInactivo)
		Me.GroupBox1.Location = New System.Drawing.Point(325, 100)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(147, 34)
		Me.GroupBox1.TabIndex = 28
		Me.GroupBox1.TabStop = False
		'
		'rdoActivo
		'
		Me.rdoActivo.AutoSize = True
		Me.rdoActivo.Checked = True
		Me.rdoActivo.Location = New System.Drawing.Point(6, 12)
		Me.rdoActivo.Name = "rdoActivo"
		Me.rdoActivo.Size = New System.Drawing.Size(36, 17)
		Me.rdoActivo.TabIndex = 8
		Me.rdoActivo.TabStop = True
		Me.rdoActivo.Text = "Sí"
		Me.rdoActivo.UseVisualStyleBackColor = True
		'
		'rdoInactivo
		'
		Me.rdoInactivo.AutoSize = True
		Me.rdoInactivo.Location = New System.Drawing.Point(88, 11)
		Me.rdoInactivo.Name = "rdoInactivo"
		Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
		Me.rdoInactivo.TabIndex = 9
		Me.rdoInactivo.Text = "No"
		Me.rdoInactivo.UseVisualStyleBackColor = True
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(285, 114)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 27
		Me.lblActivo.Text = "Activo"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(103, 83)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(34, 13)
		Me.Label2.TabIndex = 25
		Me.Label2.Text = "Clave"
		'
		'txtClave
		'
		Me.txtClave.Location = New System.Drawing.Point(139, 80)
		Me.txtClave.MaxLength = 50
		Me.txtClave.Name = "txtClave"
		Me.txtClave.Size = New System.Drawing.Size(125, 20)
		Me.txtClave.TabIndex = 26
		'
		'cmbModulo
		'
		Me.cmbModulo.FormattingEnabled = True
		Me.cmbModulo.Location = New System.Drawing.Point(325, 42)
		Me.cmbModulo.Name = "cmbModulo"
		Me.cmbModulo.Size = New System.Drawing.Size(147, 21)
		Me.cmbModulo.TabIndex = 24
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(283, 45)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(42, 13)
		Me.Label1.TabIndex = 23
		Me.Label1.Text = "Modulo"
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(624, 13)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 12
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(593, 13)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 11
		Me.btnArriba.UseVisualStyleBackColor = True
		'
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(519, 129)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 22
		Me.lblBúscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(569, 129)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 21
		Me.lblLimpiar.Text = "Limpiar"
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(572, 95)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 9
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(522, 95)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 8
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'ColNombreDeLaAccion
		'
		Me.ColNombreDeLaAccion.HeaderText = "Accion"
		Me.ColNombreDeLaAccion.Name = "ColNombreDeLaAccion"
		Me.ColNombreDeLaAccion.Width = 130
		'
		'colClave
		'
		Me.colClave.HeaderText = "Clave"
		Me.colClave.Name = "colClave"
		Me.colClave.Width = 130
		'
		'colModulo
		'
		Me.colModulo.HeaderText = "Modulo"
		Me.colModulo.Name = "colModulo"
		Me.colModulo.Width = 130
		'
		'colActivo
		'
		Me.colActivo.HeaderText = "Activo"
		Me.colActivo.Name = "colActivo"
		Me.colActivo.Width = 130
		'
		'ColTipo
		'
		Me.ColTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColTipo.HeaderText = "Tipo"
		Me.ColTipo.Name = "ColTipo"
		'
		'colId
		'
		Me.colId.HeaderText = "ID"
		Me.colId.Name = "colId"
		Me.colId.Visible = False
		'
		'ListaAccionesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(679, 516)
		Me.Controls.Add(Me.grbListaAcciones)
		Me.Controls.Add(Me.grdAcciones)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaAccionesForm"
		Me.Text = "Lista Acciones"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grdAcciones, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbListaAcciones.ResumeLayout(False)
		Me.grbListaAcciones.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblAcciones As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblExcepciones As System.Windows.Forms.Label
    Friend WithEvents Editar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnExcepciones As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents lblNombreDeLaAccion As System.Windows.Forms.Label
    Friend WithEvents txtNombreDeLaAccion As System.Windows.Forms.TextBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
	Friend WithEvents lblPermisos As System.Windows.Forms.Label
	Friend WithEvents btnPermisos As System.Windows.Forms.Button
	Friend WithEvents grdAcciones As System.Windows.Forms.DataGridView
	Friend WithEvents grbListaAcciones As System.Windows.Forms.GroupBox
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents ColNombreDeLaAccion As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents colClave As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents colModulo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents colActivo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColTipo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
