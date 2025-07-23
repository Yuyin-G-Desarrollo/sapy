<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaHorariosForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaHorariosForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.Editar = New System.Windows.Forms.Label()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.lblHorarios = New System.Windows.Forms.Label()
		Me.grbHorarios = New System.Windows.Forms.GroupBox()
		Me.lblNave = New System.Windows.Forms.Label()
		Me.cmbNave = New System.Windows.Forms.ComboBox()
		Me.lblActivo = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.btnSi = New System.Windows.Forms.RadioButton()
		Me.btnNo = New System.Windows.Forms.RadioButton()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.lblNombreDelHorario = New System.Windows.Forms.Label()
		Me.txtNombreDeLHorario = New System.Windows.Forms.TextBox()
		Me.grdHorarios = New System.Windows.Forms.DataGridView()
		Me.ColHorarioId = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColNave = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.lblExcepciones = New System.Windows.Forms.Label()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.btnExcepciones = New System.Windows.Forms.Button()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.pnlEncabezado.SuspendLayout()
		Me.grbHorarios.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		CType(Me.grdHorarios, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblExcepciones)
		Me.pnlEncabezado.Controls.Add(Me.btnExcepciones)
		Me.pnlEncabezado.Controls.Add(Me.Editar)
		Me.pnlEncabezado.Controls.Add(Me.btnEditar)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblHorarios)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(1, 3)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(482, 66)
		Me.pnlEncabezado.TabIndex = 2
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
		Me.lblHorarios.Location = New System.Drawing.Point(378, 40)
		Me.lblHorarios.Name = "lblHorarios"
		Me.lblHorarios.Size = New System.Drawing.Size(77, 20)
		Me.lblHorarios.TabIndex = 21
		Me.lblHorarios.Text = "Horarios"
		'
		'grbHorarios
		'
		Me.grbHorarios.Controls.Add(Me.lblNave)
		Me.grbHorarios.Controls.Add(Me.cmbNave)
		Me.grbHorarios.Controls.Add(Me.btnAbajo)
		Me.grbHorarios.Controls.Add(Me.btnArriba)
		Me.grbHorarios.Controls.Add(Me.lblActivo)
		Me.grbHorarios.Controls.Add(Me.GroupBox2)
		Me.grbHorarios.Controls.Add(Me.lblBúscar)
		Me.grbHorarios.Controls.Add(Me.lblLimpiar)
		Me.grbHorarios.Controls.Add(Me.btnLimpiar)
		Me.grbHorarios.Controls.Add(Me.btnBuscar)
		Me.grbHorarios.Controls.Add(Me.lblNombreDelHorario)
		Me.grbHorarios.Controls.Add(Me.txtNombreDeLHorario)
		Me.grbHorarios.Location = New System.Drawing.Point(18, 72)
		Me.grbHorarios.Name = "grbHorarios"
		Me.grbHorarios.Size = New System.Drawing.Size(448, 167)
		Me.grbHorarios.TabIndex = 10
		Me.grbHorarios.TabStop = False
		'
		'lblNave
		'
		Me.lblNave.AutoSize = True
		Me.lblNave.Location = New System.Drawing.Point(98, 91)
		Me.lblNave.Name = "lblNave"
		Me.lblNave.Size = New System.Drawing.Size(33, 13)
		Me.lblNave.TabIndex = 33
		Me.lblNave.Text = "Nave"
		'
		'cmbNave
		'
		Me.cmbNave.FormattingEnabled = True
		Me.cmbNave.Location = New System.Drawing.Point(153, 88)
		Me.cmbNave.Name = "cmbNave"
		Me.cmbNave.Size = New System.Drawing.Size(129, 21)
		Me.cmbNave.TabIndex = 32
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(94, 131)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 29
		Me.lblActivo.Text = "Activo"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.btnSi)
		Me.GroupBox2.Controls.Add(Me.btnNo)
		Me.GroupBox2.Location = New System.Drawing.Point(153, 115)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(129, 34)
		Me.GroupBox2.TabIndex = 4
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
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(341, 131)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 22
		Me.lblBúscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(391, 131)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 21
		Me.lblLimpiar.Text = "Limpiar"
		'
		'lblNombreDelHorario
		'
		Me.lblNombreDelHorario.AutoSize = True
		Me.lblNombreDelHorario.Location = New System.Drawing.Point(84, 52)
		Me.lblNombreDelHorario.Name = "lblNombreDelHorario"
		Me.lblNombreDelHorario.Size = New System.Drawing.Size(47, 13)
		Me.lblNombreDelHorario.TabIndex = 2
		Me.lblNombreDelHorario.Text = "Nombre "
		'
		'txtNombreDeLHorario
		'
		Me.txtNombreDeLHorario.Location = New System.Drawing.Point(153, 52)
		Me.txtNombreDeLHorario.MaxLength = 50
		Me.txtNombreDeLHorario.Name = "txtNombreDeLHorario"
		Me.txtNombreDeLHorario.Size = New System.Drawing.Size(129, 20)
		Me.txtNombreDeLHorario.TabIndex = 3
		'
		'grdHorarios
		'
		Me.grdHorarios.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdHorarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColHorarioId, Me.ColNombre, Me.ColNave, Me.ColActivo})
		Me.grdHorarios.Location = New System.Drawing.Point(12, 254)
		Me.grdHorarios.Name = "grdHorarios"
		Me.grdHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdHorarios.Size = New System.Drawing.Size(458, 199)
		Me.grdHorarios.TabIndex = 11
		'
		'ColHorarioId
		'
		Me.ColHorarioId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColHorarioId.HeaderText = "HorarioId"
		Me.ColHorarioId.Name = "ColHorarioId"
		Me.ColHorarioId.Visible = False
		'
		'ColNombre
		'
		Me.ColNombre.HeaderText = "Nombre"
		Me.ColNombre.Name = "ColNombre"
		Me.ColNombre.Width = 130
		'
		'ColNave
		'
		Me.ColNave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColNave.HeaderText = "Nave"
		Me.ColNave.Name = "ColNave"
		'
		'ColActivo
		'
		Me.ColActivo.HeaderText = "Activo"
		Me.ColActivo.Name = "ColActivo"
		Me.ColActivo.Width = 130
		'
		'lblExcepciones
		'
		Me.lblExcepciones.AutoSize = True
		Me.lblExcepciones.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblExcepciones.Location = New System.Drawing.Point(118, 45)
		Me.lblExcepciones.Name = "lblExcepciones"
		Me.lblExcepciones.Size = New System.Drawing.Size(68, 13)
		Me.lblExcepciones.TabIndex = 29
		Me.lblExcepciones.Text = "Excepciones"
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(417, 14)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 31
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(386, 13)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 30
		Me.btnArriba.UseVisualStyleBackColor = True
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(394, 97)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 8
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(344, 97)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 7
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'btnExcepciones
		'
		Me.btnExcepciones.Image = CType(resources.GetObject("btnExcepciones.Image"), System.Drawing.Image)
		Me.btnExcepciones.Location = New System.Drawing.Point(135, 11)
		Me.btnExcepciones.Name = "btnExcepciones"
		Me.btnExcepciones.Size = New System.Drawing.Size(32, 32)
		Me.btnExcepciones.TabIndex = 28
		Me.btnExcepciones.UseVisualStyleBackColor = True
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
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(348, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'ListaHorariosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(482, 465)
		Me.Controls.Add(Me.grdHorarios)
		Me.Controls.Add(Me.grbHorarios)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaHorariosForm"
		Me.Text = "Lista Horarios"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		Me.grbHorarios.ResumeLayout(False)
		Me.grbHorarios.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		CType(Me.grdHorarios, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents Editar As System.Windows.Forms.Label
	Friend WithEvents btnEditar As System.Windows.Forms.Button
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents lblHorarios As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grbHorarios As System.Windows.Forms.GroupBox
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents lblNombreDelHorario As System.Windows.Forms.Label
	Friend WithEvents txtNombreDeLHorario As System.Windows.Forms.TextBox
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents btnSi As System.Windows.Forms.RadioButton
	Friend WithEvents btnNo As System.Windows.Forms.RadioButton
	Friend WithEvents grdHorarios As System.Windows.Forms.DataGridView
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
	Friend WithEvents ColHorarioId As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColNombre As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColNave As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents lblExcepciones As System.Windows.Forms.Label
	Friend WithEvents btnExcepciones As System.Windows.Forms.Button
End Class
