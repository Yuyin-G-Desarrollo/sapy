<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarExcepcionesHorariosForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarExcepcionesHorariosForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblHorarios = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.lblActivo = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.btnSi = New System.Windows.Forms.RadioButton()
		Me.btnNo = New System.Windows.Forms.RadioButton()
		Me.cmbTipo = New System.Windows.Forms.ComboBox()
		Me.cmbHorario = New System.Windows.Forms.ComboBox()
		Me.dtpFecha = New System.Windows.Forms.MonthCalendar()
		Me.txtNombre = New System.Windows.Forms.TextBox()
		Me.lblTipo = New System.Windows.Forms.Label()
		Me.lblHorario = New System.Windows.Forms.Label()
		Me.lblFecha = New System.Windows.Forms.Label()
		Me.lblNombre = New System.Windows.Forms.Label()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.btnMenos = New System.Windows.Forms.Button()
		Me.btnMas = New System.Windows.Forms.Button()
		Me.lblTipoHoras = New System.Windows.Forms.Label()
		Me.cmbTipoHoras = New System.Windows.Forms.ComboBox()
		Me.grdHoras = New System.Windows.Forms.DataGridView()
		Me.txtMinutos = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtHoras = New System.Windows.Forms.TextBox()
		Me.lblHora = New System.Windows.Forms.Label()
		Me.dtpCalendario = New System.Windows.Forms.DateTimePicker()
		Me.col = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColMinutos = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabControl1.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.TabPage2.SuspendLayout()
		CType(Me.grdHoras, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblHorarios)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(2, 3)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(741, 69)
		Me.pnlEncabezado.TabIndex = 5
		'
		'lblHorarios
		'
		Me.lblHorarios.AutoSize = True
		Me.lblHorarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHorarios.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblHorarios.Location = New System.Drawing.Point(502, 44)
		Me.lblHorarios.Name = "lblHorarios"
		Me.lblHorarios.Size = New System.Drawing.Size(236, 20)
		Me.lblHorarios.TabIndex = 21
		Me.lblHorarios.Text = "Editar Excepciones Horarios"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(609, 1)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Location = New System.Drawing.Point(4, 80)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(728, 340)
		Me.TabControl1.TabIndex = 49
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.dtpCalendario)
		Me.TabPage1.Controls.Add(Me.btnCncelar)
		Me.TabPage1.Controls.Add(Me.lblCancelar)
		Me.TabPage1.Controls.Add(Me.btnGuardar)
		Me.TabPage1.Controls.Add(Me.lblGuardar)
		Me.TabPage1.Controls.Add(Me.lblActivo)
		Me.TabPage1.Controls.Add(Me.GroupBox2)
		Me.TabPage1.Controls.Add(Me.cmbTipo)
		Me.TabPage1.Controls.Add(Me.cmbHorario)
		Me.TabPage1.Controls.Add(Me.dtpFecha)
		Me.TabPage1.Controls.Add(Me.txtNombre)
		Me.TabPage1.Controls.Add(Me.lblTipo)
		Me.TabPage1.Controls.Add(Me.lblHorario)
		Me.TabPage1.Controls.Add(Me.lblFecha)
		Me.TabPage1.Controls.Add(Me.lblNombre)
		Me.TabPage1.Location = New System.Drawing.Point(4, 22)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(720, 314)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "Horarios"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(655, 244)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 57
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(649, 282)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 59
		Me.lblCancelar.Text = "Cancelar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(604, 244)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 56
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(598, 282)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 58
		Me.lblGuardar.Text = "Guardar"
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(61, 184)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 55
		Me.lblActivo.Text = "Activo"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.btnSi)
		Me.GroupBox2.Controls.Add(Me.btnNo)
		Me.GroupBox2.Location = New System.Drawing.Point(127, 169)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(157, 34)
		Me.GroupBox2.TabIndex = 54
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
		'cmbTipo
		'
		Me.cmbTipo.FormattingEnabled = True
		Me.cmbTipo.Items.AddRange(New Object() {"Entrada", "Salida"})
		Me.cmbTipo.Location = New System.Drawing.Point(127, 130)
		Me.cmbTipo.Name = "cmbTipo"
		Me.cmbTipo.Size = New System.Drawing.Size(157, 21)
		Me.cmbTipo.TabIndex = 53
		'
		'cmbHorario
		'
		Me.cmbHorario.FormattingEnabled = True
		Me.cmbHorario.Location = New System.Drawing.Point(127, 85)
		Me.cmbHorario.Name = "cmbHorario"
		Me.cmbHorario.Size = New System.Drawing.Size(157, 21)
		Me.cmbHorario.TabIndex = 52
		'
		'dtpFecha
		'
		Me.dtpFecha.Location = New System.Drawing.Point(409, 70)
		Me.dtpFecha.Name = "dtpFecha"
		Me.dtpFecha.TabIndex = 51
		Me.dtpFecha.Visible = False
		'
		'txtNombre
		'
		Me.txtNombre.Location = New System.Drawing.Point(127, 42)
		Me.txtNombre.Name = "txtNombre"
		Me.txtNombre.Size = New System.Drawing.Size(227, 20)
		Me.txtNombre.TabIndex = 50
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.Location = New System.Drawing.Point(70, 138)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(28, 13)
		Me.lblTipo.TabIndex = 49
		Me.lblTipo.Text = "Tipo"
		Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblHorario
		'
		Me.lblHorario.AutoSize = True
		Me.lblHorario.Location = New System.Drawing.Point(57, 93)
		Me.lblHorario.Name = "lblHorario"
		Me.lblHorario.Size = New System.Drawing.Size(41, 13)
		Me.lblHorario.TabIndex = 48
		Me.lblHorario.Text = "Horario"
		'
		'lblFecha
		'
		Me.lblFecha.AutoSize = True
		Me.lblFecha.Location = New System.Drawing.Point(379, 45)
		Me.lblFecha.Name = "lblFecha"
		Me.lblFecha.Size = New System.Drawing.Size(37, 13)
		Me.lblFecha.TabIndex = 47
		Me.lblFecha.Text = "Fecha"
		'
		'lblNombre
		'
		Me.lblNombre.AutoSize = True
		Me.lblNombre.BackColor = System.Drawing.Color.AliceBlue
		Me.lblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.lblNombre.Location = New System.Drawing.Point(54, 45)
		Me.lblNombre.Name = "lblNombre"
		Me.lblNombre.Size = New System.Drawing.Size(44, 13)
		Me.lblNombre.TabIndex = 46
		Me.lblNombre.Text = "Nombre"
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.btnAbajo)
		Me.TabPage2.Controls.Add(Me.btnArriba)
		Me.TabPage2.Controls.Add(Me.btnMenos)
		Me.TabPage2.Controls.Add(Me.btnMas)
		Me.TabPage2.Controls.Add(Me.lblTipoHoras)
		Me.TabPage2.Controls.Add(Me.cmbTipoHoras)
		Me.TabPage2.Controls.Add(Me.grdHoras)
		Me.TabPage2.Controls.Add(Me.txtMinutos)
		Me.TabPage2.Controls.Add(Me.Label2)
		Me.TabPage2.Controls.Add(Me.txtHoras)
		Me.TabPage2.Controls.Add(Me.lblHora)
		Me.TabPage2.Location = New System.Drawing.Point(4, 22)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(720, 314)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "Horas"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(684, 15)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 28
		Me.btnAbajo.UseVisualStyleBackColor = True
		Me.btnAbajo.Visible = False
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(653, 14)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 27
		Me.btnArriba.UseVisualStyleBackColor = True
		Me.btnArriba.Visible = False
		'
		'btnMenos
		'
		Me.btnMenos.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnMenos.Image = Global.Nomina.Vista.My.Resources.Resources.borrar_32
		Me.btnMenos.Location = New System.Drawing.Point(562, 85)
		Me.btnMenos.Name = "btnMenos"
		Me.btnMenos.Size = New System.Drawing.Size(32, 32)
		Me.btnMenos.TabIndex = 21
		Me.btnMenos.UseVisualStyleBackColor = False
		'
		'btnMas
		'
		Me.btnMas.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnMas.Image = Global.Nomina.Vista.My.Resources.Resources.altas_32
		Me.btnMas.Location = New System.Drawing.Point(524, 85)
		Me.btnMas.Name = "btnMas"
		Me.btnMas.Size = New System.Drawing.Size(32, 32)
		Me.btnMas.TabIndex = 19
		Me.btnMas.UseVisualStyleBackColor = False
		'
		'lblTipoHoras
		'
		Me.lblTipoHoras.AutoSize = True
		Me.lblTipoHoras.Location = New System.Drawing.Point(29, 76)
		Me.lblTipoHoras.Name = "lblTipoHoras"
		Me.lblTipoHoras.Size = New System.Drawing.Size(28, 13)
		Me.lblTipoHoras.TabIndex = 23
		Me.lblTipoHoras.Text = "Tipo"
		'
		'cmbTipoHoras
		'
		Me.cmbTipoHoras.FormattingEnabled = True
		Me.cmbTipoHoras.Items.AddRange(New Object() {"Entrada", "Salida"})
		Me.cmbTipoHoras.Location = New System.Drawing.Point(78, 73)
		Me.cmbTipoHoras.Name = "cmbTipoHoras"
		Me.cmbTipoHoras.Size = New System.Drawing.Size(120, 21)
		Me.cmbTipoHoras.TabIndex = 16
		'
		'grdHoras
		'
		Me.grdHoras.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdHoras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col, Me.ColTipo, Me.ColHora, Me.ColMinutos})
		Me.grdHoras.Location = New System.Drawing.Point(3, 140)
		Me.grdHoras.Name = "grdHoras"
		Me.grdHoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdHoras.Size = New System.Drawing.Size(717, 171)
		Me.grdHoras.TabIndex = 22
		'
		'txtMinutos
		'
		Me.txtMinutos.Location = New System.Drawing.Point(316, 32)
		Me.txtMinutos.Name = "txtMinutos"
		Me.txtMinutos.Size = New System.Drawing.Size(120, 20)
		Me.txtMinutos.TabIndex = 18
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(266, 35)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(44, 13)
		Me.Label2.TabIndex = 20
		Me.Label2.Text = "Minutos"
		'
		'txtHoras
		'
		Me.txtHoras.Location = New System.Drawing.Point(78, 32)
		Me.txtHoras.Name = "txtHoras"
		Me.txtHoras.Size = New System.Drawing.Size(120, 20)
		Me.txtHoras.TabIndex = 15
		'
		'lblHora
		'
		Me.lblHora.AutoSize = True
		Me.lblHora.Location = New System.Drawing.Point(32, 35)
		Me.lblHora.Name = "lblHora"
		Me.lblHora.Size = New System.Drawing.Size(30, 13)
		Me.lblHora.TabIndex = 17
		Me.lblHora.Text = "Hora"
		'
		'dtpCalendario
		'
		Me.dtpCalendario.Location = New System.Drawing.Point(436, 45)
		Me.dtpCalendario.Name = "dtpCalendario"
		Me.dtpCalendario.Size = New System.Drawing.Size(200, 20)
		Me.dtpCalendario.TabIndex = 60
		'
		'col
		'
		Me.col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.col.HeaderText = "Id"
		Me.col.Name = "col"
		Me.col.Visible = False
		'
		'ColTipo
		'
		Me.ColTipo.FillWeight = 189.6907!
		Me.ColTipo.HeaderText = "Tipo"
		Me.ColTipo.Name = "ColTipo"
		Me.ColTipo.Width = 220
		'
		'ColHora
		'
		Me.ColHora.FillWeight = 10.30928!
		Me.ColHora.HeaderText = "Hora"
		Me.ColHora.Name = "ColHora"
		Me.ColHora.Width = 220
		'
		'ColMinutos
		'
		Me.ColMinutos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColMinutos.HeaderText = "Minutos"
		Me.ColMinutos.Name = "ColMinutos"
		'
		'EditarExcepcionesHorariosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(744, 432)
		Me.Controls.Add(Me.TabControl1)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "EditarExcepcionesHorariosForm"
		Me.Text = "Editar Excepciones Horarios"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabControl1.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		Me.TabPage1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.TabPage2.ResumeLayout(False)
		Me.TabPage2.PerformLayout()
		CType(Me.grdHoras, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblHorarios As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents btnSi As System.Windows.Forms.RadioButton
	Friend WithEvents btnNo As System.Windows.Forms.RadioButton
	Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
	Friend WithEvents cmbHorario As System.Windows.Forms.ComboBox
	Friend WithEvents dtpFecha As System.Windows.Forms.MonthCalendar
	Friend WithEvents txtNombre As System.Windows.Forms.TextBox
	Friend WithEvents lblTipo As System.Windows.Forms.Label
	Friend WithEvents lblHorario As System.Windows.Forms.Label
	Friend WithEvents lblFecha As System.Windows.Forms.Label
	Friend WithEvents lblNombre As System.Windows.Forms.Label
	Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnMenos As System.Windows.Forms.Button
	Friend WithEvents btnMas As System.Windows.Forms.Button
	Friend WithEvents lblTipoHoras As System.Windows.Forms.Label
	Friend WithEvents cmbTipoHoras As System.Windows.Forms.ComboBox
	Friend WithEvents grdHoras As System.Windows.Forms.DataGridView
	Friend WithEvents txtMinutos As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtHoras As System.Windows.Forms.TextBox
	Friend WithEvents lblHora As System.Windows.Forms.Label
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents dtpCalendario As System.Windows.Forms.DateTimePicker
	Friend WithEvents col As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColTipo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColHora As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColMinutos As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
