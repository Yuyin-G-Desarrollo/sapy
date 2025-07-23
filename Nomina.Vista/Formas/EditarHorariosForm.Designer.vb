<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarHorariosForm
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarHorariosForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblHorarios = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grbListaAcciones = New System.Windows.Forms.GroupBox()
		Me.txtNombreDelHorario = New System.Windows.Forms.Label()
		Me.tbcHoras = New System.Windows.Forms.TabControl()
		Me.tbcHorarios = New System.Windows.Forms.TabPage()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.btnCncelar = New System.Windows.Forms.Button()
		Me.lblActivo = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.btnSi = New System.Windows.Forms.RadioButton()
		Me.btnNo = New System.Windows.Forms.RadioButton()
		Me.hora = New System.Windows.Forms.Label()
		Me.txtHora = New System.Windows.Forms.TextBox()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.btnMenos = New System.Windows.Forms.Button()
		Me.btnMas = New System.Windows.Forms.Button()
		Me.lblTipo = New System.Windows.Forms.Label()
		Me.cmbTipo = New System.Windows.Forms.ComboBox()
		Me.grdHoras = New System.Windows.Forms.DataGridView()
		Me.ColId = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColMinutos = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.txtMinutos = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtHoras = New System.Windows.Forms.TextBox()
		Me.lblHora = New System.Windows.Forms.Label()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.cmbNave = New System.Windows.Forms.ComboBox()
		Me.lblNave = New System.Windows.Forms.Label()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbListaAcciones.SuspendLayout()
		Me.tbcHoras.SuspendLayout()
		Me.tbcHorarios.SuspendLayout()
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
		Me.pnlEncabezado.Location = New System.Drawing.Point(2, 4)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(464, 66)
		Me.pnlEncabezado.TabIndex = 4
		'
		'lblHorarios
		'
		Me.lblHorarios.AutoSize = True
		Me.lblHorarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHorarios.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblHorarios.Location = New System.Drawing.Point(328, 45)
		Me.lblHorarios.Name = "lblHorarios"
		Me.lblHorarios.Size = New System.Drawing.Size(130, 20)
		Me.lblHorarios.TabIndex = 21
		Me.lblHorarios.Text = "Editar Horarios"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(331, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grbListaAcciones
		'
		Me.grbListaAcciones.Controls.Add(Me.txtNombreDelHorario)
		Me.grbListaAcciones.Location = New System.Drawing.Point(7, 76)
		Me.grbListaAcciones.Name = "grbListaAcciones"
		Me.grbListaAcciones.Size = New System.Drawing.Size(448, 44)
		Me.grbListaAcciones.TabIndex = 12
		Me.grbListaAcciones.TabStop = False
		'
		'txtNombreDelHorario
		'
		Me.txtNombreDelHorario.AutoSize = True
		Me.txtNombreDelHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtNombreDelHorario.ForeColor = System.Drawing.Color.SteelBlue
		Me.txtNombreDelHorario.Location = New System.Drawing.Point(16, 16)
		Me.txtNombreDelHorario.Name = "txtNombreDelHorario"
		Me.txtNombreDelHorario.Size = New System.Drawing.Size(26, 18)
		Me.txtNombreDelHorario.TabIndex = 8
		Me.txtNombreDelHorario.Text = "txt"
		'
		'tbcHoras
		'
		Me.tbcHoras.Controls.Add(Me.tbcHorarios)
		Me.tbcHoras.Controls.Add(Me.TabPage2)
		Me.tbcHoras.Location = New System.Drawing.Point(7, 126)
		Me.tbcHoras.Name = "tbcHoras"
		Me.tbcHoras.SelectedIndex = 0
		Me.tbcHoras.Size = New System.Drawing.Size(448, 279)
		Me.tbcHoras.TabIndex = 30
		'
		'tbcHorarios
		'
		Me.tbcHorarios.BackColor = System.Drawing.Color.AliceBlue
		Me.tbcHorarios.Controls.Add(Me.lblNave)
		Me.tbcHorarios.Controls.Add(Me.cmbNave)
		Me.tbcHorarios.Controls.Add(Me.lblCancelar)
		Me.tbcHorarios.Controls.Add(Me.lblGuardar)
		Me.tbcHorarios.Controls.Add(Me.btnGuardar)
		Me.tbcHorarios.Controls.Add(Me.btnCncelar)
		Me.tbcHorarios.Controls.Add(Me.lblActivo)
		Me.tbcHorarios.Controls.Add(Me.GroupBox2)
		Me.tbcHorarios.Controls.Add(Me.hora)
		Me.tbcHorarios.Controls.Add(Me.txtHora)
		Me.tbcHorarios.Location = New System.Drawing.Point(4, 22)
		Me.tbcHorarios.Name = "tbcHorarios"
		Me.tbcHorarios.Padding = New System.Windows.Forms.Padding(3)
		Me.tbcHorarios.Size = New System.Drawing.Size(440, 253)
		Me.tbcHorarios.TabIndex = 0
		Me.tbcHorarios.Text = "Horario"
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(357, 206)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
		Me.lblCancelar.TabIndex = 51
		Me.lblCancelar.Text = "Cancelar"
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(281, 206)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
		Me.lblGuardar.TabIndex = 50
		Me.lblGuardar.Text = "Guardar"
		'
		'btnGuardar
		'
		Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
		Me.btnGuardar.Location = New System.Drawing.Point(287, 168)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
		Me.btnGuardar.TabIndex = 5
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'btnCncelar
		'
		Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
		Me.btnCncelar.Location = New System.Drawing.Point(363, 168)
		Me.btnCncelar.Name = "btnCncelar"
		Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
		Me.btnCncelar.TabIndex = 6
		Me.btnCncelar.UseVisualStyleBackColor = True
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.Location = New System.Drawing.Point(72, 119)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 33
		Me.lblActivo.Text = "Activo"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.btnSi)
		Me.GroupBox2.Controls.Add(Me.btnNo)
		Me.GroupBox2.Location = New System.Drawing.Point(176, 108)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(129, 34)
		Me.GroupBox2.TabIndex = 2
		Me.GroupBox2.TabStop = False
		'
		'btnSi
		'
		Me.btnSi.AutoSize = True
		Me.btnSi.Checked = True
		Me.btnSi.Location = New System.Drawing.Point(19, 11)
		Me.btnSi.Name = "btnSi"
		Me.btnSi.Size = New System.Drawing.Size(36, 17)
		Me.btnSi.TabIndex = 3
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
		Me.btnNo.TabIndex = 4
		Me.btnNo.Text = "No"
		Me.btnNo.UseVisualStyleBackColor = True
		'
		'hora
		'
		Me.hora.AutoSize = True
		Me.hora.Location = New System.Drawing.Point(72, 33)
		Me.hora.Name = "hora"
		Me.hora.Size = New System.Drawing.Size(47, 13)
		Me.hora.TabIndex = 30
		Me.hora.Text = "Nombre "
		'
		'txtHora
		'
		Me.txtHora.Location = New System.Drawing.Point(176, 33)
		Me.txtHora.MaxLength = 50
		Me.txtHora.Name = "txtHora"
		Me.txtHora.Size = New System.Drawing.Size(129, 20)
		Me.txtHora.TabIndex = 1
		'
		'TabPage2
		'
		Me.TabPage2.BackColor = System.Drawing.Color.AliceBlue
		Me.TabPage2.Controls.Add(Me.btnMenos)
		Me.TabPage2.Controls.Add(Me.btnMas)
		Me.TabPage2.Controls.Add(Me.lblTipo)
		Me.TabPage2.Controls.Add(Me.cmbTipo)
		Me.TabPage2.Controls.Add(Me.grdHoras)
		Me.TabPage2.Controls.Add(Me.txtMinutos)
		Me.TabPage2.Controls.Add(Me.Label2)
		Me.TabPage2.Controls.Add(Me.txtHoras)
		Me.TabPage2.Controls.Add(Me.lblHora)
		Me.TabPage2.Location = New System.Drawing.Point(4, 22)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(440, 253)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "Horas"
		'
		'btnMenos
		'
		Me.btnMenos.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnMenos.Image = Global.Nomina.Vista.My.Resources.Resources.borrar_32
		Me.btnMenos.Location = New System.Drawing.Point(394, 50)
		Me.btnMenos.Name = "btnMenos"
		Me.btnMenos.Size = New System.Drawing.Size(32, 32)
		Me.btnMenos.TabIndex = 5
		Me.btnMenos.UseVisualStyleBackColor = False
		'
		'btnMas
		'
		Me.btnMas.BackColor = System.Drawing.SystemColors.ActiveCaption
		Me.btnMas.Image = Global.Nomina.Vista.My.Resources.Resources.altas_32
		Me.btnMas.Location = New System.Drawing.Point(356, 50)
		Me.btnMas.Name = "btnMas"
		Me.btnMas.Size = New System.Drawing.Size(32, 32)
		Me.btnMas.TabIndex = 4
		Me.btnMas.UseVisualStyleBackColor = False
		'
		'lblTipo
		'
		Me.lblTipo.AutoSize = True
		Me.lblTipo.Location = New System.Drawing.Point(45, 59)
		Me.lblTipo.Name = "lblTipo"
		Me.lblTipo.Size = New System.Drawing.Size(28, 13)
		Me.lblTipo.TabIndex = 14
		Me.lblTipo.Text = "Tipo"
		'
		'cmbTipo
		'
		Me.cmbTipo.FormattingEnabled = True
		Me.cmbTipo.Items.AddRange(New Object() {"1", "2"})
		Me.cmbTipo.Location = New System.Drawing.Point(94, 51)
		Me.cmbTipo.Name = "cmbTipo"
		Me.cmbTipo.Size = New System.Drawing.Size(120, 21)
		Me.cmbTipo.TabIndex = 2
		'
		'grdHoras
		'
		Me.grdHoras.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdHoras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColId, Me.ColTipo, Me.ColHora, Me.ColMinutos})
		Me.grdHoras.Location = New System.Drawing.Point(1, 95)
		Me.grdHoras.Name = "grdHoras"
		Me.grdHoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdHoras.Size = New System.Drawing.Size(436, 155)
		Me.grdHoras.TabIndex = 12
		'
		'ColId
		'
		Me.ColId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColId.HeaderText = "Id"
		Me.ColId.Name = "ColId"
		Me.ColId.Visible = False
		'
		'ColTipo
		'
		Me.ColTipo.FillWeight = 189.6907!
		Me.ColTipo.HeaderText = "Tipo"
		Me.ColTipo.Name = "ColTipo"
		Me.ColTipo.Width = 146
		'
		'ColHora
		'
		Me.ColHora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColHora.FillWeight = 10.30928!
		Me.ColHora.HeaderText = "Hora"
		Me.ColHora.Name = "ColHora"
		'
		'ColMinutos
		'
		Me.ColMinutos.HeaderText = "Minutos"
		Me.ColMinutos.Name = "ColMinutos"
		'
		'txtMinutos
		'
		Me.txtMinutos.Location = New System.Drawing.Point(322, 15)
		Me.txtMinutos.Name = "txtMinutos"
		Me.txtMinutos.Size = New System.Drawing.Size(100, 20)
		Me.txtMinutos.TabIndex = 3
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(244, 18)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(44, 13)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Minutos"
		'
		'txtHoras
		'
		Me.txtHoras.Location = New System.Drawing.Point(94, 15)
		Me.txtHoras.Name = "txtHoras"
		Me.txtHoras.Size = New System.Drawing.Size(120, 20)
		Me.txtHoras.TabIndex = 1
		'
		'lblHora
		'
		Me.lblHora.AutoSize = True
		Me.lblHora.Location = New System.Drawing.Point(48, 18)
		Me.lblHora.Name = "lblHora"
		Me.lblHora.Size = New System.Drawing.Size(30, 13)
		Me.lblHora.TabIndex = 2
		Me.lblHora.Text = "Hora"
		'
		'Timer1
		'
		'
		'cmbNave
		'
		Me.cmbNave.FormattingEnabled = True
		Me.cmbNave.Location = New System.Drawing.Point(176, 72)
		Me.cmbNave.Name = "cmbNave"
		Me.cmbNave.Size = New System.Drawing.Size(129, 21)
		Me.cmbNave.TabIndex = 52
		'
		'lblNave
		'
		Me.lblNave.AutoSize = True
		Me.lblNave.Location = New System.Drawing.Point(75, 72)
		Me.lblNave.Name = "lblNave"
		Me.lblNave.Size = New System.Drawing.Size(33, 13)
		Me.lblNave.TabIndex = 53
		Me.lblNave.Text = "Nave"
		'
		'EditarHorariosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(467, 417)
		Me.Controls.Add(Me.tbcHoras)
		Me.Controls.Add(Me.grbListaAcciones)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "EditarHorariosForm"
		Me.Text = "Editar Horarios"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbListaAcciones.ResumeLayout(False)
		Me.grbListaAcciones.PerformLayout()
		Me.tbcHoras.ResumeLayout(False)
		Me.tbcHorarios.ResumeLayout(False)
		Me.tbcHorarios.PerformLayout()
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
	Friend WithEvents grbListaAcciones As System.Windows.Forms.GroupBox
	Friend WithEvents tbcHoras As System.Windows.Forms.TabControl
	Friend WithEvents tbcHorarios As System.Windows.Forms.TabPage
	Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents btnSi As System.Windows.Forms.RadioButton
	Friend WithEvents btnNo As System.Windows.Forms.RadioButton
	Friend WithEvents hora As System.Windows.Forms.Label
	Friend WithEvents txtHora As System.Windows.Forms.TextBox
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents lblHora As System.Windows.Forms.Label
	Friend WithEvents Timer1 As System.Windows.Forms.Timer
	Friend WithEvents txtMinutos As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents txtHoras As System.Windows.Forms.TextBox
	Friend WithEvents grdHoras As System.Windows.Forms.DataGridView
	Friend WithEvents btnMenos As System.Windows.Forms.Button
	Friend WithEvents btnMas As System.Windows.Forms.Button
	Friend WithEvents lblTipo As System.Windows.Forms.Label
	Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
	Friend WithEvents txtNombreDelHorario As System.Windows.Forms.Label
	Friend WithEvents ColId As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColTipo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColHora As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColMinutos As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
End Class
