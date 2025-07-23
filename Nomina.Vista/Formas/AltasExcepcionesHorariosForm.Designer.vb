<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasExcepcionesHorariosForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasExcepcionesHorariosForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblHorarios = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
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
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblHorarios)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(4, 3)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(741, 69)
		Me.pnlEncabezado.TabIndex = 4
		'
		'lblHorarios
		'
		Me.lblHorarios.AutoSize = True
		Me.lblHorarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHorarios.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblHorarios.Location = New System.Drawing.Point(508, 44)
		Me.lblHorarios.Name = "lblHorarios"
		Me.lblHorarios.Size = New System.Drawing.Size(229, 20)
		Me.lblHorarios.TabIndex = 21
		Me.lblHorarios.Text = "Altas Excepciones Horarios"
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
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.lblActivo)
		Me.GroupBox1.Controls.Add(Me.GroupBox2)
		Me.GroupBox1.Controls.Add(Me.cmbTipo)
		Me.GroupBox1.Controls.Add(Me.cmbHorario)
		Me.GroupBox1.Controls.Add(Me.dtpFecha)
		Me.GroupBox1.Controls.Add(Me.txtNombre)
		Me.GroupBox1.Controls.Add(Me.lblTipo)
		Me.GroupBox1.Controls.Add(Me.lblHorario)
		Me.GroupBox1.Controls.Add(Me.lblFecha)
		Me.GroupBox1.Controls.Add(Me.lblNombre)
		Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.GroupBox1.Location = New System.Drawing.Point(7, 78)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(726, 231)
		Me.GroupBox1.TabIndex = 5
		Me.GroupBox1.TabStop = False
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(109, 168)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 45
		Me.lblActivo.Text = "Activo"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.btnSi)
		Me.GroupBox2.Controls.Add(Me.btnNo)
		Me.GroupBox2.Location = New System.Drawing.Point(175, 153)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(157, 34)
		Me.GroupBox2.TabIndex = 44
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
		Me.cmbTipo.Location = New System.Drawing.Point(175, 114)
		Me.cmbTipo.Name = "cmbTipo"
		Me.cmbTipo.Size = New System.Drawing.Size(157, 21)
		Me.cmbTipo.TabIndex = 8
		'
		'cmbHorario
		'
		Me.cmbHorario.FormattingEnabled = True
		Me.cmbHorario.Location = New System.Drawing.Point(175, 69)
		Me.cmbHorario.Name = "cmbHorario"
		Me.cmbHorario.Size = New System.Drawing.Size(157, 21)
		Me.cmbHorario.TabIndex = 7
		'
		'dtpFecha
		'
		Me.dtpFecha.Location = New System.Drawing.Point(487, 25)
		Me.dtpFecha.Name = "dtpFecha"
		Me.dtpFecha.TabIndex = 6
		'
		'txtNombre
		'
		Me.txtNombre.Location = New System.Drawing.Point(175, 26)
		Me.txtNombre.Name = "txtNombre"
		Me.txtNombre.Size = New System.Drawing.Size(227, 20)
		Me.txtNombre.TabIndex = 5
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.Location = New System.Drawing.Point(118, 122)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(28, 13)
		Me.lblTipo.TabIndex = 4
		Me.lblTipo.Text = "Tipo"
		Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'lblHorario
		'
		Me.lblHorario.AutoSize = True
		Me.lblHorario.Location = New System.Drawing.Point(105, 77)
		Me.lblHorario.Name = "lblHorario"
		Me.lblHorario.Size = New System.Drawing.Size(41, 13)
		Me.lblHorario.TabIndex = 3
		Me.lblHorario.Text = "Horario"
		'
		'lblFecha
		'
		Me.lblFecha.AutoSize = True
		Me.lblFecha.Location = New System.Drawing.Point(427, 29)
		Me.lblFecha.Name = "lblFecha"
		Me.lblFecha.Size = New System.Drawing.Size(37, 13)
		Me.lblFecha.TabIndex = 2
		Me.lblFecha.Text = "Fecha"
		'
		'lblNombre
		'
		Me.lblNombre.AutoSize = True
		Me.lblNombre.BackColor = System.Drawing.Color.AliceBlue
		Me.lblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.lblNombre.Location = New System.Drawing.Point(102, 29)
		Me.lblNombre.Name = "lblNombre"
		Me.lblNombre.Size = New System.Drawing.Size(44, 13)
		Me.lblNombre.TabIndex = 1
		Me.lblNombre.Text = "Nombre"
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(683, 362)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 44
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(632, 362)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 43
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(638, 324)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 41
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(689, 324)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 42
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'AltasExcepcionesHorariosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(745, 421)
		Me.Controls.Add(Me.lblCancelar)
		Me.Controls.Add(Me.lblGuardar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.btnCncelar)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.ForeColor = System.Drawing.Color.AliceBlue
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "AltasExcepcionesHorariosForm"
		Me.Text = "Altas Excepciones Horarios "
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblHorarios As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents dtpFecha As System.Windows.Forms.MonthCalendar
	Friend WithEvents txtNombre As System.Windows.Forms.TextBox
	Friend WithEvents lblTipo As System.Windows.Forms.Label
	Friend WithEvents lblHorario As System.Windows.Forms.Label
	Friend WithEvents lblFecha As System.Windows.Forms.Label
	Friend WithEvents lblNombre As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
	Friend WithEvents cmbHorario As System.Windows.Forms.ComboBox
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents btnSi As System.Windows.Forms.RadioButton
	Friend WithEvents btnNo As System.Windows.Forms.RadioButton
End Class
