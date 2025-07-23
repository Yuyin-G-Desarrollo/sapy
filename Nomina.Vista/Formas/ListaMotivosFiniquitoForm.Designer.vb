<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaMotivosFiniquitoForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaMotivosFiniquitoForm))
        Me.grdMotivos = New System.Windows.Forms.DataGridView()
        Me.ColMFiniquitos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.Editar = New System.Windows.Forms.Label()
        Me.lblListaMotivosFiniquito = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.grbMotivos = New System.Windows.Forms.GroupBox()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        CType(Me.grdMotivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.grbMotivos.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdMotivos
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMotivos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdMotivos.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdMotivos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdMotivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdMotivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMFiniquitos, Me.ColNave, Me.ColNombre, Me.ColActivo})
        Me.grdMotivos.Location = New System.Drawing.Point(12, 196)
        Me.grdMotivos.Name = "grdMotivos"
        Me.grdMotivos.ReadOnly = True
        Me.grdMotivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdMotivos.Size = New System.Drawing.Size(851, 334)
        Me.grdMotivos.TabIndex = 6
        '
        'ColMFiniquitos
        '
        Me.ColMFiniquitos.HeaderText = "ID"
        Me.ColMFiniquitos.Name = "ColMFiniquitos"
        Me.ColMFiniquitos.ReadOnly = True
        Me.ColMFiniquitos.Visible = False
        '
        'ColNave
        '
        Me.ColNave.HeaderText = "Nave"
        Me.ColNave.Name = "ColNave"
        Me.ColNave.ReadOnly = True
        Me.ColNave.Width = 250
        '
        'ColNombre
        '
        Me.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNombre.HeaderText = "Nombre"
        Me.ColNombre.Name = "ColNombre"
        Me.ColNombre.ReadOnly = True
        '
        'ColActivo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColActivo.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColActivo.HeaderText = "Activo"
        Me.ColActivo.Name = "ColActivo"
        Me.ColActivo.ReadOnly = True
        Me.ColActivo.Width = 80
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(18, 41)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 5)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(64, 6)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 22
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(64, 41)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 23
        Me.Editar.Text = "Editar"
        '
        'lblListaMotivosFiniquito
        '
        Me.lblListaMotivosFiniquito.AutoSize = True
        Me.lblListaMotivosFiniquito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaMotivosFiniquito.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaMotivosFiniquito.Location = New System.Drawing.Point(637, 18)
        Me.lblListaMotivosFiniquito.Name = "lblListaMotivosFiniquito"
        Me.lblListaMotivosFiniquito.Size = New System.Drawing.Size(169, 20)
        Me.lblListaMotivosFiniquito.TabIndex = 21
        Me.lblListaMotivosFiniquito.Text = "Motivos de Finiquito"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblListaMotivosFiniquito)
        Me.pnlEncabezado.Controls.Add(Me.Editar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Location = New System.Drawing.Point(1, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(873, 59)
        Me.pnlEncabezado.TabIndex = 5
        '
        'grbMotivos
        '
        Me.grbMotivos.Controls.Add(Me.rdoNo)
        Me.grbMotivos.Controls.Add(Me.lblBuscar)
        Me.grbMotivos.Controls.Add(Me.rdoSi)
        Me.grbMotivos.Controls.Add(Me.cmbNave)
        Me.grbMotivos.Controls.Add(Me.lblNave)
        Me.grbMotivos.Controls.Add(Me.txtNombre)
        Me.grbMotivos.Controls.Add(Me.lblNombre)
        Me.grbMotivos.Controls.Add(Me.lblActivo)
        Me.grbMotivos.Controls.Add(Me.btnAbajo)
        Me.grbMotivos.Controls.Add(Me.btnArriba)
        Me.grbMotivos.Controls.Add(Me.lblLimpiar)
        Me.grbMotivos.Controls.Add(Me.btnLimpiar)
        Me.grbMotivos.Controls.Add(Me.btnBuscar)
        Me.grbMotivos.Location = New System.Drawing.Point(12, 61)
        Me.grbMotivos.Name = "grbMotivos"
        Me.grbMotivos.Size = New System.Drawing.Size(850, 129)
        Me.grbMotivos.TabIndex = 7
        Me.grbMotivos.TabStop = False
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.ForeColor = System.Drawing.Color.Black
        Me.rdoNo.Location = New System.Drawing.Point(267, 106)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 7
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(753, 110)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 35
        Me.lblBuscar.Text = "Mostrar"
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.ForeColor = System.Drawing.Color.Black
        Me.rdoSi.Location = New System.Drawing.Point(203, 106)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 6
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(203, 47)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(524, 21)
        Me.cmbNave.TabIndex = 34
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(133, 52)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 33
        Me.lblNave.Text = "Nave"
        '
        'txtNombre
        '
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(203, 78)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(524, 20)
        Me.txtNombre.TabIndex = 31
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(133, 79)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 30
        Me.lblNombre.Text = "Nombre"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.Color.Black
        Me.lblActivo.Location = New System.Drawing.Point(133, 106)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 29
        Me.lblActivo.Text = "Activo"
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(815, 10)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 26
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(789, 10)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 25
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(800, 110)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 27
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(803, 78)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 24
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(756, 78)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 23
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nave"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Activo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(805, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'ListaMotivosFiniquitoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(884, 550)
        Me.Controls.Add(Me.grdMotivos)
        Me.Controls.Add(Me.grbMotivos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(890, 572)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(890, 572)
        Me.Name = "ListaMotivosFiniquitoForm"
        Me.Text = "Motivos de Finiquito"
        CType(Me.grdMotivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grbMotivos.ResumeLayout(False)
        Me.grbMotivos.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdMotivos As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents Editar As System.Windows.Forms.Label
    Friend WithEvents lblListaMotivosFiniquito As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents grbMotivos As System.Windows.Forms.GroupBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ColMFiniquitos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
