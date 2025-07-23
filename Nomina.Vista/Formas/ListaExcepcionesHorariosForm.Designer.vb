<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaExcepcionesHorariosForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaExcepcionesHorariosForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.Editar = New System.Windows.Forms.Label()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.lblHorarios = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grbExeHorarios = New System.Windows.Forms.GroupBox()
		Me.cmbHorario = New System.Windows.Forms.ComboBox()
		Me.lblHorario = New System.Windows.Forms.Label()
		Me.lblActivo = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.btnSi = New System.Windows.Forms.RadioButton()
		Me.btnNo = New System.Windows.Forms.RadioButton()
		Me.dtpFecha = New System.Windows.Forms.MonthCalendar()
		Me.lblFecha = New System.Windows.Forms.Label()
		Me.txtNombre = New System.Windows.Forms.TextBox()
		Me.lblNombre = New System.Windows.Forms.Label()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.grdExeHorarios = New System.Windows.Forms.DataGridView()
		Me.COLID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColHorario = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbExeHorarios.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.grdExeHorarios, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.Editar)
		Me.pnlEncabezado.Controls.Add(Me.btnEditar)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblHorarios)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(1, 1)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(707, 69)
		Me.pnlEncabezado.TabIndex = 3
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
		'lblHorarios
		'
		Me.lblHorarios.AutoSize = True
		Me.lblHorarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHorarios.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblHorarios.Location = New System.Drawing.Point(515, 47)
		Me.lblHorarios.Name = "lblHorarios"
		Me.lblHorarios.Size = New System.Drawing.Size(183, 20)
		Me.lblHorarios.TabIndex = 21
		Me.lblHorarios.Text = "Excepciones Horarios"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(572, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grbExeHorarios
		'
		Me.grbExeHorarios.Controls.Add(Me.cmbHorario)
		Me.grbExeHorarios.Controls.Add(Me.lblHorario)
		Me.grbExeHorarios.Controls.Add(Me.lblActivo)
		Me.grbExeHorarios.Controls.Add(Me.GroupBox2)
		Me.grbExeHorarios.Controls.Add(Me.dtpFecha)
		Me.grbExeHorarios.Controls.Add(Me.lblFecha)
		Me.grbExeHorarios.Controls.Add(Me.txtNombre)
		Me.grbExeHorarios.Controls.Add(Me.lblNombre)
		Me.grbExeHorarios.Controls.Add(Me.lblBúscar)
		Me.grbExeHorarios.Controls.Add(Me.lblLimpiar)
		Me.grbExeHorarios.Controls.Add(Me.btnLimpiar)
		Me.grbExeHorarios.Controls.Add(Me.btnBuscar)
		Me.grbExeHorarios.Controls.Add(Me.btnAbajo)
		Me.grbExeHorarios.Controls.Add(Me.btnArriba)
		Me.grbExeHorarios.Location = New System.Drawing.Point(12, 76)
		Me.grbExeHorarios.Name = "grbExeHorarios"
		Me.grbExeHorarios.Size = New System.Drawing.Size(684, 228)
		Me.grbExeHorarios.TabIndex = 4
		Me.grbExeHorarios.TabStop = False
		Me.grbExeHorarios.Text = "Horarios Excepciones"
		'
		'cmbHorario
		'
		Me.cmbHorario.FormattingEnabled = True
		Me.cmbHorario.Location = New System.Drawing.Point(65, 97)
		Me.cmbHorario.Name = "cmbHorario"
		Me.cmbHorario.Size = New System.Drawing.Size(135, 21)
		Me.cmbHorario.TabIndex = 45
		'
		'lblHorario
		'
		Me.lblHorario.AutoSize = True
		Me.lblHorario.Location = New System.Drawing.Point(18, 100)
		Me.lblHorario.Name = "lblHorario"
		Me.lblHorario.Size = New System.Drawing.Size(41, 13)
		Me.lblHorario.TabIndex = 44
		Me.lblHorario.Text = "Horario"
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(22, 154)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 43
		Me.lblActivo.Text = "Activo"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.btnSi)
		Me.GroupBox2.Controls.Add(Me.btnNo)
		Me.GroupBox2.Location = New System.Drawing.Point(65, 143)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(135, 34)
		Me.GroupBox2.TabIndex = 42
		Me.GroupBox2.TabStop = False
		'
		'btnSi
		'
		Me.btnSi.AutoSize = True
		Me.btnSi.Checked = True
		Me.btnSi.Location = New System.Drawing.Point(19, 11)
		Me.btnSi.Name = "btnSi"
		Me.btnSi.Size = New System.Drawing.Size(36, 17)
		Me.btnSi.TabIndex = 5
		Me.btnSi.TabStop = True
		Me.btnSi.Text = "Sí"
		Me.btnSi.UseVisualStyleBackColor = True
		'
		'btnNo
		'
		Me.btnNo.AutoSize = True
		Me.btnNo.Location = New System.Drawing.Point(75, 11)
		Me.btnNo.Name = "btnNo"
		Me.btnNo.Size = New System.Drawing.Size(39, 17)
		Me.btnNo.TabIndex = 6
		Me.btnNo.Text = "No"
		Me.btnNo.UseVisualStyleBackColor = True
		'
		'dtpFecha
		'
		Me.dtpFecha.Location = New System.Drawing.Point(295, 42)
		Me.dtpFecha.Name = "dtpFecha"
		Me.dtpFecha.TabIndex = 41
		'
		'lblFecha
		'
		Me.lblFecha.AutoSize = True
		Me.lblFecha.Location = New System.Drawing.Point(246, 50)
		Me.lblFecha.Name = "lblFecha"
		Me.lblFecha.Size = New System.Drawing.Size(37, 13)
		Me.lblFecha.TabIndex = 40
		Me.lblFecha.Text = "Fecha"
		'
		'txtNombre
		'
		Me.txtNombre.Location = New System.Drawing.Point(65, 47)
		Me.txtNombre.Name = "txtNombre"
		Me.txtNombre.Size = New System.Drawing.Size(135, 20)
		Me.txtNombre.TabIndex = 39
		'
		'lblNombre
		'
		Me.lblNombre.AutoSize = True
		Me.lblNombre.Location = New System.Drawing.Point(15, 50)
		Me.lblNombre.Name = "lblNombre"
		Me.lblNombre.Size = New System.Drawing.Size(44, 13)
		Me.lblNombre.TabIndex = 38
		Me.lblNombre.Text = "Nombre"
		'
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(567, 206)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 37
		Me.lblBúscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(617, 206)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 36
		Me.lblLimpiar.Text = "Limpiar"
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(620, 172)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 35
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(570, 172)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 34
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(651, 14)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 33
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(620, 13)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 32
		Me.btnArriba.UseVisualStyleBackColor = True
		'
		'grdExeHorarios
		'
		Me.grdExeHorarios.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdExeHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdExeHorarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COLID, Me.ColNombre, Me.ColFecha, Me.ColHorario, Me.ColTipo, Me.ColActivo})
		Me.grdExeHorarios.Location = New System.Drawing.Point(12, 310)
		Me.grdExeHorarios.Name = "grdExeHorarios"
		Me.grdExeHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdExeHorarios.Size = New System.Drawing.Size(684, 231)
		Me.grdExeHorarios.TabIndex = 5
		'
		'COLID
		'
		Me.COLID.HeaderText = "ID"
		Me.COLID.Name = "COLID"
		Me.COLID.Visible = False
		'
		'ColNombre
		'
		Me.ColNombre.HeaderText = "Nombre"
		Me.ColNombre.Name = "ColNombre"
		Me.ColNombre.Width = 130
		'
		'ColFecha
		'
		Me.ColFecha.HeaderText = "Fecha"
		Me.ColFecha.Name = "ColFecha"
		Me.ColFecha.Width = 130
		'
		'ColHorario
		'
		Me.ColHorario.HeaderText = "Horario"
		Me.ColHorario.Name = "ColHorario"
		Me.ColHorario.Width = 130
		'
		'ColTipo
		'
		Me.ColTipo.HeaderText = "Tipo"
		Me.ColTipo.Name = "ColTipo"
		Me.ColTipo.Width = 130
		'
		'ColActivo
		'
		Me.ColActivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColActivo.HeaderText = "Activo"
		Me.ColActivo.Name = "ColActivo"
		'
		'ListaExcepcionesHorariosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(710, 553)
		Me.Controls.Add(Me.grdExeHorarios)
		Me.Controls.Add(Me.grbExeHorarios)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaExcepcionesHorariosForm"
		Me.Text = "ListaExcepcionesHorariosForm"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbExeHorarios.ResumeLayout(False)
		Me.grbExeHorarios.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.grdExeHorarios, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents Editar As System.Windows.Forms.Label
	Friend WithEvents btnEditar As System.Windows.Forms.Button
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents lblHorarios As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grbExeHorarios As System.Windows.Forms.GroupBox
	Friend WithEvents grdExeHorarios As System.Windows.Forms.DataGridView
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents dtpFecha As System.Windows.Forms.MonthCalendar
	Friend WithEvents lblFecha As System.Windows.Forms.Label
	Friend WithEvents txtNombre As System.Windows.Forms.TextBox
	Friend WithEvents lblNombre As System.Windows.Forms.Label
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents cmbHorario As System.Windows.Forms.ComboBox
	Friend WithEvents lblHorario As System.Windows.Forms.Label
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents btnSi As System.Windows.Forms.RadioButton
	Friend WithEvents btnNo As System.Windows.Forms.RadioButton
	Friend WithEvents COLID As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColNombre As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColFecha As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColHorario As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColTipo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
