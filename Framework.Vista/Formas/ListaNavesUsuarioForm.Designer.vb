<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaNavesUsuarioForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaNavesUsuarioForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblEliminar = New System.Windows.Forms.Label()
		Me.btnEliminar = New System.Windows.Forms.Button()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.lblNavesUser = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grbNaus = New System.Windows.Forms.GroupBox()
		Me.lblNaves = New System.Windows.Forms.Label()
		Me.cmbNaves = New System.Windows.Forms.ComboBox()
		Me.txtUsuario = New System.Windows.Forms.TextBox()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.lblUsuario = New System.Windows.Forms.Label()
		Me.grdNaus = New System.Windows.Forms.DataGridView()
		Me.ColUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColUsuarioid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColNaves = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColNaveid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbNaus.SuspendLayout()
		CType(Me.grdNaus, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblEliminar)
		Me.pnlEncabezado.Controls.Add(Me.btnEliminar)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblNavesUser)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(-1, 2)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(482, 67)
		Me.pnlEncabezado.TabIndex = 4
		'
		'lblEliminar
		'
		Me.lblEliminar.AutoSize = True
		Me.lblEliminar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblEliminar.Location = New System.Drawing.Point(57, 47)
		Me.lblEliminar.Name = "lblEliminar"
		Me.lblEliminar.Size = New System.Drawing.Size(43, 13)
		Me.lblEliminar.TabIndex = 37
		Me.lblEliminar.Text = "Eliminar"
		'
		'btnEliminar
		'
		Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
		Me.btnEliminar.Location = New System.Drawing.Point(60, 12)
		Me.btnEliminar.Name = "btnEliminar"
		Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
		Me.btnEliminar.TabIndex = 2
		Me.btnEliminar.UseVisualStyleBackColor = True
		'
		'btnAltas
		'
		Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
		Me.btnAltas.Location = New System.Drawing.Point(12, 12)
		Me.btnAltas.Name = "btnAltas"
		Me.btnAltas.Size = New System.Drawing.Size(32, 32)
		Me.btnAltas.TabIndex = 1
		Me.btnAltas.UseVisualStyleBackColor = True
		'
		'lblAltas
		'
		Me.lblAltas.AutoSize = True
		Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblAltas.Location = New System.Drawing.Point(13, 47)
		Me.lblAltas.Name = "lblAltas"
		Me.lblAltas.Size = New System.Drawing.Size(30, 13)
		Me.lblAltas.TabIndex = 35
		Me.lblAltas.Text = "Altas"
		'
		'lblNavesUser
		'
		Me.lblNavesUser.AutoSize = True
		Me.lblNavesUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNavesUser.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblNavesUser.Location = New System.Drawing.Point(307, 45)
		Me.lblNavesUser.Name = "lblNavesUser"
		Me.lblNavesUser.Size = New System.Drawing.Size(169, 20)
		Me.lblNavesUser.TabIndex = 21
		Me.lblNavesUser.Text = "Lista Naves Usuario"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(350, 2)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grbNaus
		'
		Me.grbNaus.Controls.Add(Me.lblNaves)
		Me.grbNaus.Controls.Add(Me.cmbNaves)
		Me.grbNaus.Controls.Add(Me.txtUsuario)
		Me.grbNaus.Controls.Add(Me.btnAbajo)
		Me.grbNaus.Controls.Add(Me.btnArriba)
		Me.grbNaus.Controls.Add(Me.lblBúscar)
		Me.grbNaus.Controls.Add(Me.lblLimpiar)
		Me.grbNaus.Controls.Add(Me.btnLimpiar)
		Me.grbNaus.Controls.Add(Me.btnBuscar)
		Me.grbNaus.Controls.Add(Me.lblUsuario)
		Me.grbNaus.Location = New System.Drawing.Point(12, 75)
		Me.grbNaus.Name = "grbNaus"
		Me.grbNaus.Size = New System.Drawing.Size(458, 171)
		Me.grbNaus.TabIndex = 5
		Me.grbNaus.TabStop = False
		'
		'lblNaves
		'
		Me.lblNaves.AutoSize = True
		Me.lblNaves.Location = New System.Drawing.Point(78, 45)
		Me.lblNaves.Name = "lblNaves"
		Me.lblNaves.Size = New System.Drawing.Size(38, 13)
		Me.lblNaves.TabIndex = 32
		Me.lblNaves.Text = "Naves"
		'
		'cmbNaves
		'
		Me.cmbNaves.FormattingEnabled = True
		Me.cmbNaves.Location = New System.Drawing.Point(143, 42)
		Me.cmbNaves.Name = "cmbNaves"
		Me.cmbNaves.Size = New System.Drawing.Size(176, 21)
		Me.cmbNaves.TabIndex = 1
		'
		'txtUsuario
		'
		Me.txtUsuario.Location = New System.Drawing.Point(143, 78)
		Me.txtUsuario.Name = "txtUsuario"
		Me.txtUsuario.Size = New System.Drawing.Size(176, 20)
		Me.txtUsuario.TabIndex = 2
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(423, 15)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 10
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(392, 14)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 9
		Me.btnArriba.UseVisualStyleBackColor = True
		'
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(358, 139)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 26
		Me.lblBúscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(408, 139)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 25
		Me.lblLimpiar.Text = "Limpiar"
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(411, 105)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 8
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(361, 105)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 7
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'lblUsuario
		'
		Me.lblUsuario.AutoSize = True
		Me.lblUsuario.Location = New System.Drawing.Point(77, 78)
		Me.lblUsuario.Name = "lblUsuario"
		Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
		Me.lblUsuario.TabIndex = 2
		Me.lblUsuario.Text = "Usuario"
		'
		'grdNaus
		'
		Me.grdNaus.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdNaus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdNaus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColUsuario, Me.ColUsuarioid, Me.ColNaves, Me.ColNaveid})
		Me.grdNaus.Location = New System.Drawing.Point(12, 258)
		Me.grdNaus.Name = "grdNaus"
		Me.grdNaus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdNaus.Size = New System.Drawing.Size(458, 187)
		Me.grdNaus.TabIndex = 12
		'
		'ColUsuario
		'
		Me.ColUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColUsuario.HeaderText = "Usuario"
		Me.ColUsuario.Name = "ColUsuario"
		'
		'ColUsuarioid
		'
		Me.ColUsuarioid.HeaderText = "usuarioid"
		Me.ColUsuarioid.Name = "ColUsuarioid"
		Me.ColUsuarioid.Visible = False
		'
		'ColNaves
		'
		Me.ColNaves.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColNaves.HeaderText = "Naves"
		Me.ColNaves.Name = "ColNaves"
		'
		'ColNaveid
		'
		Me.ColNaveid.HeaderText = "naveid"
		Me.ColNaveid.Name = "ColNaveid"
		Me.ColNaveid.Visible = False
		'
		'ListaNavesUsuarioForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(483, 457)
		Me.Controls.Add(Me.grdNaus)
		Me.Controls.Add(Me.grbNaus)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaNavesUsuarioForm"
		Me.Text = "Lista Naves Usuario"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbNaus.ResumeLayout(False)
		Me.grbNaus.PerformLayout()
		CType(Me.grdNaus, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblEliminar As System.Windows.Forms.Label
	Friend WithEvents btnEliminar As System.Windows.Forms.Button
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents lblNavesUser As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grbNaus As System.Windows.Forms.GroupBox
	Friend WithEvents lblNaves As System.Windows.Forms.Label
	Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
	Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents lblUsuario As System.Windows.Forms.Label
	Friend WithEvents grdNaus As System.Windows.Forms.DataGridView
	Friend WithEvents ColUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColUsuarioid As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColNaves As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColNaveid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
