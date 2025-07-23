<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaExcepcionesForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaExcepcionesForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblEliminar = New System.Windows.Forms.Label()
		Me.btnEliminar = New System.Windows.Forms.Button()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.lblExcepciones = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grdExcepciones = New System.Windows.Forms.DataGridView()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.grbExcepciones = New System.Windows.Forms.GroupBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cmbExcepciones = New System.Windows.Forms.ComboBox()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.rdoDengar = New System.Windows.Forms.RadioButton()
		Me.rdoAutorizar = New System.Windows.Forms.RadioButton()
		Me.lblTipo = New System.Windows.Forms.Label()
		Me.txtUsuario = New System.Windows.Forms.TextBox()
		Me.lblUsuario = New System.Windows.Forms.Label()
		Me.lblAccion = New System.Windows.Forms.Label()
		Me.cmbAccion = New System.Windows.Forms.ComboBox()
		Me.ColModulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColModuloid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColUsuarioid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColAccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColAccionid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.grdExcepciones, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbExcepciones.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblEliminar)
		Me.pnlEncabezado.Controls.Add(Me.btnEliminar)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblExcepciones)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(480, 67)
		Me.pnlEncabezado.TabIndex = 3
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
		'lblExcepciones
		'
		Me.lblExcepciones.AutoSize = True
		Me.lblExcepciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblExcepciones.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblExcepciones.Location = New System.Drawing.Point(348, 44)
		Me.lblExcepciones.Name = "lblExcepciones"
		Me.lblExcepciones.Size = New System.Drawing.Size(110, 20)
		Me.lblExcepciones.TabIndex = 21
		Me.lblExcepciones.Text = "Excepciones"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(337, 1)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grdExcepciones
		'
		Me.grdExcepciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdExcepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdExcepciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColModulo, Me.ColModuloid, Me.ColUsuario, Me.ColUsuarioid, Me.ColAccion, Me.ColAccionid, Me.ColTipo})
		Me.grdExcepciones.Location = New System.Drawing.Point(12, 266)
		Me.grdExcepciones.Name = "grdExcepciones"
		Me.grdExcepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdExcepciones.Size = New System.Drawing.Size(458, 187)
		Me.grdExcepciones.TabIndex = 11
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(343, 122)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 7
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(393, 122)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 8
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(390, 156)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 25
		Me.lblLimpiar.Text = "Limpiar"
		'
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(340, 156)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 26
		Me.lblBúscar.Text = "Búscar"
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
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(423, 15)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 10
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'grbExcepciones
		'
		Me.grbExcepciones.Controls.Add(Me.Label1)
		Me.grbExcepciones.Controls.Add(Me.cmbExcepciones)
		Me.grbExcepciones.Controls.Add(Me.GroupBox2)
		Me.grbExcepciones.Controls.Add(Me.lblTipo)
		Me.grbExcepciones.Controls.Add(Me.txtUsuario)
		Me.grbExcepciones.Controls.Add(Me.btnAbajo)
		Me.grbExcepciones.Controls.Add(Me.btnArriba)
		Me.grbExcepciones.Controls.Add(Me.lblBúscar)
		Me.grbExcepciones.Controls.Add(Me.lblLimpiar)
		Me.grbExcepciones.Controls.Add(Me.btnLimpiar)
		Me.grbExcepciones.Controls.Add(Me.btnBuscar)
		Me.grbExcepciones.Controls.Add(Me.lblUsuario)
		Me.grbExcepciones.Controls.Add(Me.lblAccion)
		Me.grbExcepciones.Controls.Add(Me.cmbAccion)
		Me.grbExcepciones.Location = New System.Drawing.Point(12, 73)
		Me.grbExcepciones.Name = "grbExcepciones"
		Me.grbExcepciones.Size = New System.Drawing.Size(458, 187)
		Me.grbExcepciones.TabIndex = 4
		Me.grbExcepciones.TabStop = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(78, 45)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(42, 13)
		Me.Label1.TabIndex = 32
		Me.Label1.Text = "Módulo"
		'
		'cmbExcepciones
		'
		Me.cmbExcepciones.FormattingEnabled = True
		Me.cmbExcepciones.Location = New System.Drawing.Point(143, 42)
		Me.cmbExcepciones.Name = "cmbExcepciones"
		Me.cmbExcepciones.Size = New System.Drawing.Size(176, 21)
		Me.cmbExcepciones.TabIndex = 1
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.rdoDengar)
		Me.GroupBox2.Controls.Add(Me.rdoAutorizar)
		Me.GroupBox2.Location = New System.Drawing.Point(142, 138)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(176, 34)
		Me.GroupBox2.TabIndex = 4
		Me.GroupBox2.TabStop = False
		'
		'rdoDengar
		'
		Me.rdoDengar.AutoSize = True
		Me.rdoDengar.Location = New System.Drawing.Point(96, 11)
		Me.rdoDengar.Name = "rdoDengar"
		Me.rdoDengar.Size = New System.Drawing.Size(69, 17)
		Me.rdoDengar.TabIndex = 6
		Me.rdoDengar.Text = " Denegar"
		Me.rdoDengar.UseVisualStyleBackColor = True
		'
		'rdoAutorizar
		'
		Me.rdoAutorizar.AutoSize = True
		Me.rdoAutorizar.Checked = True
		Me.rdoAutorizar.Location = New System.Drawing.Point(6, 11)
		Me.rdoAutorizar.Name = "rdoAutorizar"
		Me.rdoAutorizar.Size = New System.Drawing.Size(66, 17)
		Me.rdoAutorizar.TabIndex = 5
		Me.rdoAutorizar.TabStop = True
		Me.rdoAutorizar.Text = "Autorizar"
		Me.rdoAutorizar.UseVisualStyleBackColor = True
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.Location = New System.Drawing.Point(92, 153)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(28, 13)
		Me.lblTipo.TabIndex = 30
		Me.lblTipo.Text = "Tipo"
		'
		'txtUsuario
		'
		Me.txtUsuario.Location = New System.Drawing.Point(143, 78)
		Me.txtUsuario.Name = "txtUsuario"
		Me.txtUsuario.Size = New System.Drawing.Size(176, 20)
		Me.txtUsuario.TabIndex = 2
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
		'lblAccion
		'
		Me.lblAccion.AutoSize = True
		Me.lblAccion.Location = New System.Drawing.Point(80, 118)
		Me.lblAccion.Name = "lblAccion"
		Me.lblAccion.Size = New System.Drawing.Size(40, 13)
		Me.lblAccion.TabIndex = 1
		Me.lblAccion.Text = "Acción"
		'
		'cmbAccion
		'
		Me.cmbAccion.FormattingEnabled = True
		Me.cmbAccion.Location = New System.Drawing.Point(143, 110)
		Me.cmbAccion.Name = "cmbAccion"
		Me.cmbAccion.Size = New System.Drawing.Size(176, 21)
		Me.cmbAccion.TabIndex = 3
		'
		'ColModulo
		'
		Me.ColModulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColModulo.HeaderText = "Módulo"
		Me.ColModulo.Name = "ColModulo"
		'
		'ColModuloid
		'
		Me.ColModuloid.HeaderText = "moduloid"
		Me.ColModuloid.Name = "ColModuloid"
		Me.ColModuloid.Visible = False
		'
		'ColUsuario
		'
		Me.ColUsuario.HeaderText = "Usuario"
		Me.ColUsuario.Name = "ColUsuario"
		'
		'ColUsuarioid
		'
		Me.ColUsuarioid.HeaderText = "usuarioid"
		Me.ColUsuarioid.Name = "ColUsuarioid"
		Me.ColUsuarioid.Visible = False
		'
		'ColAccion
		'
		Me.ColAccion.HeaderText = "Acción"
		Me.ColAccion.Name = "ColAccion"
		'
		'ColAccionid
		'
		Me.ColAccionid.HeaderText = "Accionid"
		Me.ColAccionid.Name = "ColAccionid"
		Me.ColAccionid.Visible = False
		'
		'ColTipo
		'
		Me.ColTipo.HeaderText = "Tipo"
		Me.ColTipo.Name = "ColTipo"
		'
		'ListaExcepcionesForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(482, 465)
		Me.Controls.Add(Me.grdExcepciones)
		Me.Controls.Add(Me.grbExcepciones)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaExcepcionesForm"
		Me.Text = "Lista Excepciones"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.grdExcepciones, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbExcepciones.ResumeLayout(False)
		Me.grbExcepciones.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblExcepciones As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents lblEliminar As System.Windows.Forms.Label
	Friend WithEvents btnEliminar As System.Windows.Forms.Button
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents grdExcepciones As System.Windows.Forms.DataGridView
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents grbExcepciones As System.Windows.Forms.GroupBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents cmbExcepciones As System.Windows.Forms.ComboBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents rdoDengar As System.Windows.Forms.RadioButton
	Friend WithEvents rdoAutorizar As System.Windows.Forms.RadioButton
	Friend WithEvents lblTipo As System.Windows.Forms.Label
	Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
	Friend WithEvents lblUsuario As System.Windows.Forms.Label
	Friend WithEvents lblAccion As System.Windows.Forms.Label
	Friend WithEvents cmbAccion As System.Windows.Forms.ComboBox
	Friend WithEvents ColModulo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColModuloid As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColUsuarioid As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColAccion As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColAccionid As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColTipo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
