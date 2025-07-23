<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPerfilesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPerfilesForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblPermisos = New System.Windows.Forms.Label()
		Me.lblListaModulos = New System.Windows.Forms.Label()
		Me.Editar = New System.Windows.Forms.Label()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.grdPerfiles = New System.Windows.Forms.DataGridView()
		Me.ColNombreDelPerdil = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColGrupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.lblNombreDelPerfil = New System.Windows.Forms.Label()
		Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
		Me.txtNombreDelPerfil = New System.Windows.Forms.TextBox()
		Me.lblGrupo = New System.Windows.Forms.Label()
		Me.lblEstado = New System.Windows.Forms.Label()
		Me.grbGuardarHistorial = New System.Windows.Forms.GroupBox()
		Me.rdoSi = New System.Windows.Forms.RadioButton()
		Me.rdoNo = New System.Windows.Forms.RadioButton()
		Me.grbListaPerfiles = New System.Windows.Forms.GroupBox()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.lblUsuarios = New System.Windows.Forms.Label()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.btnPermisos = New System.Windows.Forms.Button()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.grdPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbGuardarHistorial.SuspendLayout()
		Me.grbListaPerfiles.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblUsuarios)
		Me.pnlEncabezado.Controls.Add(Me.Button1)
		Me.pnlEncabezado.Controls.Add(Me.lblPermisos)
		Me.pnlEncabezado.Controls.Add(Me.btnPermisos)
		Me.pnlEncabezado.Controls.Add(Me.lblListaModulos)
		Me.pnlEncabezado.Controls.Add(Me.Editar)
		Me.pnlEncabezado.Controls.Add(Me.btnEditar)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(2, 1)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(516, 67)
		Me.pnlEncabezado.TabIndex = 1
		'
		'lblPermisos
		'
		Me.lblPermisos.AutoSize = True
		Me.lblPermisos.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblPermisos.Location = New System.Drawing.Point(105, 47)
		Me.lblPermisos.Name = "lblPermisos"
		Me.lblPermisos.Size = New System.Drawing.Size(49, 13)
		Me.lblPermisos.TabIndex = 31
		Me.lblPermisos.Text = "Permisos"
		'
		'lblListaModulos
		'
		Me.lblListaModulos.AutoSize = True
		Me.lblListaModulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblListaModulos.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblListaModulos.Location = New System.Drawing.Point(420, 41)
		Me.lblListaModulos.Name = "lblListaModulos"
		Me.lblListaModulos.Size = New System.Drawing.Size(69, 20)
		Me.lblListaModulos.TabIndex = 21
		Me.lblListaModulos.Text = "Perfiles"
		'
		'Editar
		'
		Me.Editar.AutoSize = True
		Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.Editar.Location = New System.Drawing.Point(64, 47)
		Me.Editar.Name = "Editar"
		Me.Editar.Size = New System.Drawing.Size(34, 13)
		Me.Editar.TabIndex = 19
		Me.Editar.Text = "Editar"
		'
		'lblAltas
		'
		Me.lblAltas.AutoSize = True
		Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblAltas.Location = New System.Drawing.Point(18, 47)
		Me.lblAltas.Name = "lblAltas"
		Me.lblAltas.Size = New System.Drawing.Size(30, 13)
		Me.lblAltas.TabIndex = 16
		Me.lblAltas.Text = "Altas"
		'
		'grdPerfiles
		'
		Me.grdPerfiles.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdPerfiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNombreDelPerdil, Me.ColGrupo, Me.ColEstado, Me.id})
		Me.grdPerfiles.Location = New System.Drawing.Point(11, 255)
		Me.grdPerfiles.Name = "grdPerfiles"
		Me.grdPerfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdPerfiles.Size = New System.Drawing.Size(501, 153)
		Me.grdPerfiles.TabIndex = 11
		'
		'ColNombreDelPerdil
		'
		Me.ColNombreDelPerdil.HeaderText = "Nombre del perfil"
		Me.ColNombreDelPerdil.Name = "ColNombreDelPerdil"
		Me.ColNombreDelPerdil.Width = 150
		'
		'ColGrupo
		'
		Me.ColGrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColGrupo.HeaderText = "Grupo"
		Me.ColGrupo.Name = "ColGrupo"
		'
		'ColEstado
		'
		Me.ColEstado.HeaderText = "Estado"
		Me.ColEstado.Name = "ColEstado"
		Me.ColEstado.Width = 150
		'
		'id
		'
		Me.id.HeaderText = "Id"
		Me.id.Name = "id"
		Me.id.Visible = False
		'
		'lblNombreDelPerfil
		'
		Me.lblNombreDelPerfil.AutoSize = True
		Me.lblNombreDelPerfil.Location = New System.Drawing.Point(7, 58)
		Me.lblNombreDelPerfil.Name = "lblNombreDelPerfil"
		Me.lblNombreDelPerfil.Size = New System.Drawing.Size(86, 13)
		Me.lblNombreDelPerfil.TabIndex = 3
		Me.lblNombreDelPerfil.Text = "Nombre del perfil"
		'
		'cmbDepartamento
		'
		Me.cmbDepartamento.FormattingEnabled = True
		Me.cmbDepartamento.Location = New System.Drawing.Point(318, 54)
		Me.cmbDepartamento.Name = "cmbDepartamento"
		Me.cmbDepartamento.Size = New System.Drawing.Size(121, 21)
		Me.cmbDepartamento.TabIndex = 5
		'
		'txtNombreDelPerfil
		'
		Me.txtNombreDelPerfil.Location = New System.Drawing.Point(116, 54)
		Me.txtNombreDelPerfil.Name = "txtNombreDelPerfil"
		Me.txtNombreDelPerfil.Size = New System.Drawing.Size(100, 20)
		Me.txtNombreDelPerfil.TabIndex = 4
		'
		'lblGrupo
		'
		Me.lblGrupo.AutoSize = True
		Me.lblGrupo.Location = New System.Drawing.Point(232, 58)
		Me.lblGrupo.Name = "lblGrupo"
		Me.lblGrupo.Size = New System.Drawing.Size(74, 13)
		Me.lblGrupo.TabIndex = 8
		Me.lblGrupo.Text = "Departamento"
		'
		'lblEstado
		'
		Me.lblEstado.AutoSize = True
		Me.lblEstado.Location = New System.Drawing.Point(8, 107)
		Me.lblEstado.Name = "lblEstado"
		Me.lblEstado.Size = New System.Drawing.Size(40, 13)
		Me.lblEstado.TabIndex = 9
		Me.lblEstado.Text = "Estado"
		'
		'grbGuardarHistorial
		'
		Me.grbGuardarHistorial.Controls.Add(Me.rdoSi)
		Me.grbGuardarHistorial.Controls.Add(Me.rdoNo)
		Me.grbGuardarHistorial.Location = New System.Drawing.Point(115, 95)
		Me.grbGuardarHistorial.Name = "grbGuardarHistorial"
		Me.grbGuardarHistorial.Size = New System.Drawing.Size(100, 34)
		Me.grbGuardarHistorial.TabIndex = 6
		Me.grbGuardarHistorial.TabStop = False
		'
		'rdoSi
		'
		Me.rdoSi.AutoSize = True
		Me.rdoSi.Checked = True
		Me.rdoSi.Location = New System.Drawing.Point(6, 12)
		Me.rdoSi.Name = "rdoSi"
		Me.rdoSi.Size = New System.Drawing.Size(36, 17)
		Me.rdoSi.TabIndex = 7
		Me.rdoSi.TabStop = True
		Me.rdoSi.Text = "Sí"
		Me.rdoSi.UseVisualStyleBackColor = True
		'
		'rdoNo
		'
		Me.rdoNo.AutoSize = True
		Me.rdoNo.Location = New System.Drawing.Point(56, 11)
		Me.rdoNo.Name = "rdoNo"
		Me.rdoNo.Size = New System.Drawing.Size(39, 17)
		Me.rdoNo.TabIndex = 8
		Me.rdoNo.TabStop = True
		Me.rdoNo.Text = "No"
		Me.rdoNo.UseVisualStyleBackColor = True
		'
		'grbListaPerfiles
		'
		Me.grbListaPerfiles.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar
		Me.grbListaPerfiles.Controls.Add(Me.btnAbajo)
		Me.grbListaPerfiles.Controls.Add(Me.btnArriba)
		Me.grbListaPerfiles.Controls.Add(Me.lblBúscar)
		Me.grbListaPerfiles.Controls.Add(Me.lblLimpiar)
		Me.grbListaPerfiles.Controls.Add(Me.btnLimpiar)
		Me.grbListaPerfiles.Controls.Add(Me.btnBuscar)
		Me.grbListaPerfiles.Controls.Add(Me.lblEstado)
		Me.grbListaPerfiles.Controls.Add(Me.grbGuardarHistorial)
		Me.grbListaPerfiles.Controls.Add(Me.lblNombreDelPerfil)
		Me.grbListaPerfiles.Controls.Add(Me.cmbDepartamento)
		Me.grbListaPerfiles.Controls.Add(Me.lblGrupo)
		Me.grbListaPerfiles.Controls.Add(Me.txtNombreDelPerfil)
		Me.grbListaPerfiles.Location = New System.Drawing.Point(12, 74)
		Me.grbListaPerfiles.Name = "grbListaPerfiles"
		Me.grbListaPerfiles.Size = New System.Drawing.Size(502, 167)
		Me.grbListaPerfiles.TabIndex = 14
		Me.grbListaPerfiles.TabStop = False
		'
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(309, 141)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 26
		Me.lblBúscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(359, 141)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 25
		Me.lblLimpiar.Text = "Limpiar"
		'
		'lblUsuarios
		'
		Me.lblUsuarios.AutoSize = True
		Me.lblUsuarios.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblUsuarios.Location = New System.Drawing.Point(158, 47)
		Me.lblUsuarios.Name = "lblUsuarios"
		Me.lblUsuarios.Size = New System.Drawing.Size(48, 13)
		Me.lblUsuarios.TabIndex = 33
		Me.lblUsuarios.Text = "Usuarios"
		Me.lblUsuarios.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(473, 11)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 13
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(442, 10)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 12
		Me.btnArriba.UseVisualStyleBackColor = True
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(362, 107)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 10
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(312, 107)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 9
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'Button1
		'
		Me.Button1.BackColor = System.Drawing.Color.Gray
		Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
		Me.Button1.Location = New System.Drawing.Point(166, 12)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(32, 32)
		Me.Button1.TabIndex = 32
		Me.Button1.UseVisualStyleBackColor = False
		'
		'btnPermisos
		'
		Me.btnPermisos.Image = CType(resources.GetObject("btnPermisos.Image"), System.Drawing.Image)
		Me.btnPermisos.Location = New System.Drawing.Point(113, 12)
		Me.btnPermisos.Name = "btnPermisos"
		Me.btnPermisos.Size = New System.Drawing.Size(32, 32)
		Me.btnPermisos.TabIndex = 3
		Me.btnPermisos.UseVisualStyleBackColor = True
		'
		'btnEditar
		'
		Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
		Me.btnEditar.Location = New System.Drawing.Point(64, 12)
		Me.btnEditar.Name = "btnEditar"
		Me.btnEditar.Size = New System.Drawing.Size(32, 32)
		Me.btnEditar.TabIndex = 2
		Me.btnEditar.UseVisualStyleBackColor = True
		'
		'btnAltas
		'
		Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
		Me.btnAltas.Location = New System.Drawing.Point(17, 12)
		Me.btnAltas.Name = "btnAltas"
		Me.btnAltas.Size = New System.Drawing.Size(32, 32)
		Me.btnAltas.TabIndex = 1
		Me.btnAltas.UseVisualStyleBackColor = True
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(385, 0)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'ListaPerfilesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(526, 423)
		Me.Controls.Add(Me.grbListaPerfiles)
		Me.Controls.Add(Me.grdPerfiles)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaPerfilesForm"
		Me.Text = "Lista Perfiles"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.grdPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbGuardarHistorial.ResumeLayout(False)
		Me.grbGuardarHistorial.PerformLayout()
		Me.grbListaPerfiles.ResumeLayout(False)
		Me.grbListaPerfiles.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblListaModulos As System.Windows.Forms.Label
	Friend WithEvents Editar As System.Windows.Forms.Label
	Friend WithEvents btnEditar As System.Windows.Forms.Button
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents lblPermisos As System.Windows.Forms.Label
	Friend WithEvents btnPermisos As System.Windows.Forms.Button
	Friend WithEvents grdPerfiles As System.Windows.Forms.DataGridView
	Friend WithEvents lblNombreDelPerfil As System.Windows.Forms.Label
	Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
	Friend WithEvents txtNombreDelPerfil As System.Windows.Forms.TextBox
	Friend WithEvents lblGrupo As System.Windows.Forms.Label
	Friend WithEvents lblEstado As System.Windows.Forms.Label
	Friend WithEvents grbGuardarHistorial As System.Windows.Forms.GroupBox
	Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
	Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
	Friend WithEvents grbListaPerfiles As System.Windows.Forms.GroupBox
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents ColNombreDelPerdil As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColGrupo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColEstado As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents lblUsuarios As System.Windows.Forms.Label
	Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
