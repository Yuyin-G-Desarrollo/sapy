<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaCajaDeAhorroColaboradorForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaCajaDeAhorroColaboradorForm))
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblCancelar = New System.Windows.Forms.Label()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.lblGuardar = New System.Windows.Forms.Label()
		Me.btnSaveAndClose = New System.Windows.Forms.Button()
		Me.lblCajaColaborador = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.grbCajaColaborador = New System.Windows.Forms.GroupBox()
		Me.lblIdCaja = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.rdoSi = New System.Windows.Forms.RadioButton()
		Me.rdoNo = New System.Windows.Forms.RadioButton()
		Me.txtNombre = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lblPeriodos = New System.Windows.Forms.Label()
		Me.lblNaves = New System.Windows.Forms.Label()
		Me.lblPeriodo = New System.Windows.Forms.Label()
		Me.lblNave = New System.Windows.Forms.Label()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.grdCajaColaborador = New System.Windows.Forms.DataGridView()
		Me.ColColaboradorId = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColApellidoPaterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColApellidoMaterno = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColDepartameto = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColSalario = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColMontoAcumulado = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColMontoAhorrado = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbCajaColaborador.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.grdCajaColaborador, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblCancelar)
		Me.pnlEncabezado.Controls.Add(Me.Button1)
		Me.pnlEncabezado.Controls.Add(Me.lblGuardar)
		Me.pnlEncabezado.Controls.Add(Me.btnSaveAndClose)
		Me.pnlEncabezado.Controls.Add(Me.lblCajaColaborador)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(0, 1)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(848, 69)
		Me.pnlEncabezado.TabIndex = 4
		'
		'lblCancelar
		'
		Me.lblCancelar.AutoSize = True
		Me.lblCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblCancelar.Location = New System.Drawing.Point(64, 43)
		Me.lblCancelar.Name = "lblCancelar"
		Me.lblCancelar.Size = New System.Drawing.Size(62, 16)
		Me.lblCancelar.TabIndex = 57
		Me.lblCancelar.Text = "Cancelar"
		Me.lblCancelar.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Button1
		'
		Me.Button1.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar_321
		Me.Button1.Location = New System.Drawing.Point(76, 11)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(32, 32)
		Me.Button1.TabIndex = 56
		Me.Button1.UseVisualStyleBackColor = True
		'
		'lblGuardar
		'
		Me.lblGuardar.AutoSize = True
		Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblGuardar.Location = New System.Drawing.Point(2, 43)
		Me.lblGuardar.Name = "lblGuardar"
		Me.lblGuardar.Size = New System.Drawing.Size(60, 16)
		Me.lblGuardar.TabIndex = 55
		Me.lblGuardar.Text = "Guardar "
		'
		'btnSaveAndClose
		'
		Me.btnSaveAndClose.Image = Global.Nomina.Vista.My.Resources.Resources.guardar_32
		Me.btnSaveAndClose.Location = New System.Drawing.Point(14, 11)
		Me.btnSaveAndClose.Name = "btnSaveAndClose"
		Me.btnSaveAndClose.Size = New System.Drawing.Size(32, 32)
		Me.btnSaveAndClose.TabIndex = 54
		Me.btnSaveAndClose.UseVisualStyleBackColor = True
		'
		'lblCajaColaborador
		'
		Me.lblCajaColaborador.AutoSize = True
		Me.lblCajaColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCajaColaborador.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblCajaColaborador.Location = New System.Drawing.Point(609, 47)
		Me.lblCajaColaborador.Name = "lblCajaColaborador"
		Me.lblCajaColaborador.Size = New System.Drawing.Size(232, 20)
		Me.lblCajaColaborador.TabIndex = 21
		Me.lblCajaColaborador.Text = "Caja de Ahorro Colaborador"
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(716, 3)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'grbCajaColaborador
		'
		Me.grbCajaColaborador.Controls.Add(Me.lblIdCaja)
		Me.grbCajaColaborador.Controls.Add(Me.Label1)
		Me.grbCajaColaborador.Controls.Add(Me.GroupBox1)
		Me.grbCajaColaborador.Controls.Add(Me.txtNombre)
		Me.grbCajaColaborador.Controls.Add(Me.Label3)
		Me.grbCajaColaborador.Controls.Add(Me.lblPeriodos)
		Me.grbCajaColaborador.Controls.Add(Me.lblNaves)
		Me.grbCajaColaborador.Controls.Add(Me.lblPeriodo)
		Me.grbCajaColaborador.Controls.Add(Me.lblNave)
		Me.grbCajaColaborador.Controls.Add(Me.btnAbajo)
		Me.grbCajaColaborador.Controls.Add(Me.btnArriba)
		Me.grbCajaColaborador.Controls.Add(Me.lblBúscar)
		Me.grbCajaColaborador.Controls.Add(Me.lblLimpiar)
		Me.grbCajaColaborador.Controls.Add(Me.btnLimpiar)
		Me.grbCajaColaborador.Controls.Add(Me.btnBuscar)
		Me.grbCajaColaborador.Location = New System.Drawing.Point(12, 77)
		Me.grbCajaColaborador.Name = "grbCajaColaborador"
		Me.grbCajaColaborador.Size = New System.Drawing.Size(824, 136)
		Me.grbCajaColaborador.TabIndex = 5
		Me.grbCajaColaborador.TabStop = False
		Me.grbCajaColaborador.Text = "Caja de Ahorro"
		'
		'lblIdCaja
		'
		Me.lblIdCaja.AutoSize = True
		Me.lblIdCaja.Location = New System.Drawing.Point(426, 15)
		Me.lblIdCaja.Name = "lblIdCaja"
		Me.lblIdCaja.Size = New System.Drawing.Size(39, 13)
		Me.lblIdCaja.TabIndex = 45
		Me.lblIdCaja.Text = "Label2"
		Me.lblIdCaja.Visible = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(395, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(31, 13)
		Me.Label1.TabIndex = 44
		Me.Label1.Text = "Caja:"
		Me.Label1.Visible = False
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.rdoSi)
		Me.GroupBox1.Controls.Add(Me.rdoNo)
		Me.GroupBox1.Location = New System.Drawing.Point(420, 81)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(209, 32)
		Me.GroupBox1.TabIndex = 43
		Me.GroupBox1.TabStop = False
		'
		'rdoSi
		'
		Me.rdoSi.AutoSize = True
		Me.rdoSi.Checked = True
		Me.rdoSi.Location = New System.Drawing.Point(6, 10)
		Me.rdoSi.Name = "rdoSi"
		Me.rdoSi.Size = New System.Drawing.Size(74, 17)
		Me.rdoSi.TabIndex = 1
		Me.rdoSi.TabStop = True
		Me.rdoSi.Text = "Asignados"
		Me.rdoSi.UseVisualStyleBackColor = True
		'
		'rdoNo
		'
		Me.rdoNo.AutoSize = True
		Me.rdoNo.Location = New System.Drawing.Point(112, 10)
		Me.rdoNo.Name = "rdoNo"
		Me.rdoNo.Size = New System.Drawing.Size(91, 17)
		Me.rdoNo.TabIndex = 0
		Me.rdoNo.Text = "No Asignados"
		Me.rdoNo.UseVisualStyleBackColor = True
		'
		'txtNombre
		'
		Me.txtNombre.Location = New System.Drawing.Point(73, 90)
		Me.txtNombre.Name = "txtNombre"
		Me.txtNombre.Size = New System.Drawing.Size(341, 20)
		Me.txtNombre.TabIndex = 42
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(17, 93)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(54, 13)
		Me.Label3.TabIndex = 41
		Me.Label3.Text = "Nombre:"
		'
		'lblPeriodos
		'
		Me.lblPeriodos.AutoSize = True
		Me.lblPeriodos.Location = New System.Drawing.Point(74, 65)
		Me.lblPeriodos.Name = "lblPeriodos"
		Me.lblPeriodos.Size = New System.Drawing.Size(39, 13)
		Me.lblPeriodos.TabIndex = 40
		Me.lblPeriodos.Text = "Label2"
		'
		'lblNaves
		'
		Me.lblNaves.AutoSize = True
		Me.lblNaves.Location = New System.Drawing.Point(74, 33)
		Me.lblNaves.Name = "lblNaves"
		Me.lblNaves.Size = New System.Drawing.Size(39, 13)
		Me.lblNaves.TabIndex = 39
		Me.lblNaves.Text = "Label1"
		'
		'lblPeriodo
		'
		Me.lblPeriodo.AutoSize = True
		Me.lblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPeriodo.Location = New System.Drawing.Point(17, 65)
		Me.lblPeriodo.Name = "lblPeriodo"
		Me.lblPeriodo.Size = New System.Drawing.Size(54, 13)
		Me.lblPeriodo.TabIndex = 38
		Me.lblPeriodo.Text = "Periodo:"
		'
		'lblNave
		'
		Me.lblNave.AutoSize = True
		Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNave.Location = New System.Drawing.Point(30, 33)
		Me.lblNave.Name = "lblNave"
		Me.lblNave.Size = New System.Drawing.Size(41, 13)
		Me.lblNave.TabIndex = 37
		Me.lblNave.Text = "Nave:"
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(798, 19)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 36
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(774, 19)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 35
		Me.btnArriba.UseVisualStyleBackColor = True
		'
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(717, 112)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 34
		Me.lblBúscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(766, 112)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 33
		Me.lblLimpiar.Text = "Limpiar"
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(769, 78)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 32
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(719, 78)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 31
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'grdCajaColaborador
		'
		Me.grdCajaColaborador.AllowUserToAddRows = False
		Me.grdCajaColaborador.AllowUserToDeleteRows = False
		Me.grdCajaColaborador.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdCajaColaborador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdCajaColaborador.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColColaboradorId, Me.ColNombre, Me.ColApellidoPaterno, Me.ColApellidoMaterno, Me.ColDepartameto, Me.ColSalario, Me.ColStatus, Me.ColMontoAcumulado, Me.ColMontoAhorrado})
		Me.grdCajaColaborador.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdCajaColaborador.Location = New System.Drawing.Point(12, 219)
		Me.grdCajaColaborador.Name = "grdCajaColaborador"
		Me.grdCajaColaborador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdCajaColaborador.Size = New System.Drawing.Size(824, 261)
		Me.grdCajaColaborador.TabIndex = 6
		'
		'ColColaboradorId
		'
		Me.ColColaboradorId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColColaboradorId.HeaderText = "Id"
		Me.ColColaboradorId.Name = "ColColaboradorId"
		'
		'ColNombre
		'
		Me.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColNombre.HeaderText = "Nombre del colaborador"
		Me.ColNombre.Name = "ColNombre"
		'
		'ColApellidoPaterno
		'
		Me.ColApellidoPaterno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColApellidoPaterno.HeaderText = "Apellido paterno"
		Me.ColApellidoPaterno.Name = "ColApellidoPaterno"
		'
		'ColApellidoMaterno
		'
		Me.ColApellidoMaterno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColApellidoMaterno.HeaderText = "Apellido materno"
		Me.ColApellidoMaterno.Name = "ColApellidoMaterno"
		'
		'ColDepartameto
		'
		Me.ColDepartameto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColDepartameto.HeaderText = "Departamento"
		Me.ColDepartameto.Name = "ColDepartameto"
		'
		'ColSalario
		'
		Me.ColSalario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColSalario.HeaderText = "Salario"
		Me.ColSalario.Name = "ColSalario"
		'
		'ColStatus
		'
		Me.ColStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColStatus.HeaderText = "Status"
		Me.ColStatus.Name = "ColStatus"
		'
		'ColMontoAcumulado
		'
		Me.ColMontoAcumulado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		DataGridViewCellStyle3.Format = "C2"
		DataGridViewCellStyle3.NullValue = Nothing
		Me.ColMontoAcumulado.DefaultCellStyle = DataGridViewCellStyle3
		Me.ColMontoAcumulado.HeaderText = "Monto acumulado"
		Me.ColMontoAcumulado.Name = "ColMontoAcumulado"
		'
		'ColMontoAhorrado
		'
		Me.ColMontoAhorrado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		DataGridViewCellStyle4.Format = "C2"
		DataGridViewCellStyle4.NullValue = Nothing
		Me.ColMontoAhorrado.DefaultCellStyle = DataGridViewCellStyle4
		Me.ColMontoAhorrado.HeaderText = "Monto ahorro"
		Me.ColMontoAhorrado.Name = "ColMontoAhorrado"
		'
		'ListaCajaDeAhorroColaboradorForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(848, 492)
		Me.Controls.Add(Me.grdCajaColaborador)
		Me.Controls.Add(Me.grbCajaColaborador)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaCajaDeAhorroColaboradorForm"
		Me.Text = "Caja De Ahorro Colaborador "
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbCajaColaborador.ResumeLayout(False)
		Me.grbCajaColaborador.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.grdCajaColaborador, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblCajaColaborador As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents grbCajaColaborador As System.Windows.Forms.GroupBox
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents txtNombre As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents lblPeriodos As System.Windows.Forms.Label
	Friend WithEvents lblNaves As System.Windows.Forms.Label
	Friend WithEvents lblPeriodo As System.Windows.Forms.Label
	Friend WithEvents lblNave As System.Windows.Forms.Label
	Friend WithEvents grdCajaColaborador As System.Windows.Forms.DataGridView
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
	Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnSaveAndClose As System.Windows.Forms.Button
	Friend WithEvents lblIdCaja As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents ColColaboradorId As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColNombre As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColApellidoPaterno As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColApellidoMaterno As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColDepartameto As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColSalario As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColStatus As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColMontoAcumulado As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColMontoAhorrado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
