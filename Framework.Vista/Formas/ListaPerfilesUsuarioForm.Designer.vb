<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPerfilesUsuarioForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPerfilesUsuarioForm))
		Me.grdPeus = New System.Windows.Forms.DataGridView()
		Me.grbPeus = New System.Windows.Forms.GroupBox()
		Me.cmbUsuario = New System.Windows.Forms.ComboBox()
		Me.lblUsuario = New System.Windows.Forms.Label()
		Me.cmbPerfil = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
		Me.lblGrupo = New System.Windows.Forms.Label()
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblEliminar = New System.Windows.Forms.Label()
		Me.btnEliminar = New System.Windows.Forms.Button()
		Me.lblListaModulos = New System.Windows.Forms.Label()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.lblNave = New System.Windows.Forms.Label()
		Me.cmbNave = New System.Windows.Forms.ComboBox()
		Me.ColGrupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColPerfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColUsuarioid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColPerfilid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColNave = New System.Windows.Forms.DataGridViewTextBoxColumn()
		CType(Me.grdPeus, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbPeus.SuspendLayout()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'grdPeus
		'
		Me.grdPeus.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdPeus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColGrupo, Me.ColPerfil, Me.ColUsuario, Me.ColUsuarioid, Me.ColPerfilid, Me.ColNave})
		Me.grdPeus.Location = New System.Drawing.Point(8, 243)
		Me.grdPeus.Name = "grdPeus"
		Me.grdPeus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdPeus.Size = New System.Drawing.Size(462, 213)
		Me.grdPeus.TabIndex = 10
		'
		'grbPeus
		'
		Me.grbPeus.Controls.Add(Me.lblNave)
		Me.grbPeus.Controls.Add(Me.cmbNave)
		Me.grbPeus.Controls.Add(Me.cmbUsuario)
		Me.grbPeus.Controls.Add(Me.lblUsuario)
		Me.grbPeus.Controls.Add(Me.cmbPerfil)
		Me.grbPeus.Controls.Add(Me.Label1)
		Me.grbPeus.Controls.Add(Me.lblBúscar)
		Me.grbPeus.Controls.Add(Me.lblLimpiar)
		Me.grbPeus.Controls.Add(Me.btnLimpiar)
		Me.grbPeus.Controls.Add(Me.btnBuscar)
		Me.grbPeus.Controls.Add(Me.btnAbajo)
		Me.grbPeus.Controls.Add(Me.btnArriba)
		Me.grbPeus.Controls.Add(Me.cmbDepartamento)
		Me.grbPeus.Controls.Add(Me.lblGrupo)
		Me.grbPeus.Location = New System.Drawing.Point(8, 76)
		Me.grbPeus.Name = "grbPeus"
		Me.grbPeus.Size = New System.Drawing.Size(462, 159)
		Me.grbPeus.TabIndex = 1
		Me.grbPeus.TabStop = False
		Me.grbPeus.Text = "Pérfiles"
		'
		'cmbUsuario
		'
		Me.cmbUsuario.FormattingEnabled = True
		Me.cmbUsuario.Location = New System.Drawing.Point(112, 112)
		Me.cmbUsuario.Name = "cmbUsuario"
		Me.cmbUsuario.Size = New System.Drawing.Size(176, 21)
		Me.cmbUsuario.TabIndex = 5
		'
		'lblUsuario
		'
		Me.lblUsuario.AutoSize = True
		Me.lblUsuario.Location = New System.Drawing.Point(50, 115)
		Me.lblUsuario.Name = "lblUsuario"
		Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
		Me.lblUsuario.TabIndex = 34
		Me.lblUsuario.Text = "Usuario"
		'
		'cmbPerfil
		'
		Me.cmbPerfil.FormattingEnabled = True
		Me.cmbPerfil.Location = New System.Drawing.Point(112, 78)
		Me.cmbPerfil.Name = "cmbPerfil"
		Me.cmbPerfil.Size = New System.Drawing.Size(176, 21)
		Me.cmbPerfil.TabIndex = 4
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(26, 50)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(74, 13)
		Me.Label1.TabIndex = 32
		Me.Label1.Text = "Departamento"
		'
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(348, 132)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 30
		Me.lblBúscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(398, 132)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 29
		Me.lblLimpiar.Text = "Limpiar"
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(406, 98)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 7
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(351, 98)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 6
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(432, 16)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 9
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(401, 15)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 8
		Me.btnArriba.UseVisualStyleBackColor = True
		'
		'cmbDepartamento
		'
		Me.cmbDepartamento.FormattingEnabled = True
		Me.cmbDepartamento.Location = New System.Drawing.Point(112, 47)
		Me.cmbDepartamento.Name = "cmbDepartamento"
		Me.cmbDepartamento.Size = New System.Drawing.Size(176, 21)
		Me.cmbDepartamento.TabIndex = 3
		'
		'lblGrupo
		'
		Me.lblGrupo.AutoSize = True
		Me.lblGrupo.Location = New System.Drawing.Point(63, 81)
		Me.lblGrupo.Name = "lblGrupo"
		Me.lblGrupo.Size = New System.Drawing.Size(30, 13)
		Me.lblGrupo.TabIndex = 10
		Me.lblGrupo.Text = "Pérfil"
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblEliminar)
		Me.pnlEncabezado.Controls.Add(Me.btnEliminar)
		Me.pnlEncabezado.Controls.Add(Me.lblListaModulos)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(0, 3)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(483, 67)
		Me.pnlEncabezado.TabIndex = 2
		'
		'lblEliminar
		'
		Me.lblEliminar.AutoSize = True
		Me.lblEliminar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblEliminar.Location = New System.Drawing.Point(66, 48)
		Me.lblEliminar.Name = "lblEliminar"
		Me.lblEliminar.Size = New System.Drawing.Size(43, 13)
		Me.lblEliminar.TabIndex = 39
		Me.lblEliminar.Text = "Eliminar"
		'
		'btnEliminar
		'
		Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
		Me.btnEliminar.Location = New System.Drawing.Point(69, 13)
		Me.btnEliminar.Name = "btnEliminar"
		Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
		Me.btnEliminar.TabIndex = 2
		Me.btnEliminar.UseVisualStyleBackColor = True
		'
		'lblListaModulos
		'
		Me.lblListaModulos.AutoSize = True
		Me.lblListaModulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblListaModulos.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblListaModulos.Location = New System.Drawing.Point(340, 46)
		Me.lblListaModulos.Name = "lblListaModulos"
		Me.lblListaModulos.Size = New System.Drawing.Size(136, 20)
		Me.lblListaModulos.TabIndex = 21
		Me.lblListaModulos.Text = "Perfiles Usuario"
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
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(351, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'lblNave
		'
		Me.lblNave.AutoSize = True
		Me.lblNave.Location = New System.Drawing.Point(62, 23)
		Me.lblNave.Name = "lblNave"
		Me.lblNave.Size = New System.Drawing.Size(33, 13)
		Me.lblNave.TabIndex = 38
		Me.lblNave.Text = "Nave"
		'
		'cmbNave
		'
		Me.cmbNave.FormattingEnabled = True
		Me.cmbNave.Location = New System.Drawing.Point(112, 15)
		Me.cmbNave.Name = "cmbNave"
		Me.cmbNave.Size = New System.Drawing.Size(176, 21)
		Me.cmbNave.TabIndex = 37
		'
		'ColGrupo
		'
		Me.ColGrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColGrupo.HeaderText = "Departamento"
		Me.ColGrupo.Name = "ColGrupo"
		'
		'ColPerfil
		'
		Me.ColPerfil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColPerfil.HeaderText = "Perfil"
		Me.ColPerfil.Name = "ColPerfil"
		'
		'ColUsuario
		'
		Me.ColUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColUsuario.HeaderText = "Usuario"
		Me.ColUsuario.Name = "ColUsuario"
		'
		'ColUsuarioid
		'
		Me.ColUsuarioid.HeaderText = "usuario"
		Me.ColUsuarioid.Name = "ColUsuarioid"
		Me.ColUsuarioid.Visible = False
		'
		'ColPerfilid
		'
		Me.ColPerfilid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColPerfilid.HeaderText = "perfil"
		Me.ColPerfilid.Name = "ColPerfilid"
		Me.ColPerfilid.Visible = False
		'
		'ColNave
		'
		Me.ColNave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColNave.HeaderText = "Nave"
		Me.ColNave.Name = "ColNave"
		'
		'ListaPerfilesUsuarioForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(481, 465)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.Controls.Add(Me.grbPeus)
		Me.Controls.Add(Me.grdPeus)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaPerfilesUsuarioForm"
		Me.Text = "ListaPerfilesUsuarioForm"
		CType(Me.grdPeus, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbPeus.ResumeLayout(False)
		Me.grbPeus.PerformLayout()
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents grdPeus As System.Windows.Forms.DataGridView
	Friend WithEvents grbPeus As System.Windows.Forms.GroupBox
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblListaModulos As System.Windows.Forms.Label
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
	Friend WithEvents lblGrupo As System.Windows.Forms.Label
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents cmbPerfil As System.Windows.Forms.ComboBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
	Friend WithEvents lblUsuario As System.Windows.Forms.Label
	Friend WithEvents lblEliminar As System.Windows.Forms.Label
	Friend WithEvents btnEliminar As System.Windows.Forms.Button
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
	Friend WithEvents ColGrupo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColPerfil As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColUsuarioid As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColPerfilid As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColNave As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
