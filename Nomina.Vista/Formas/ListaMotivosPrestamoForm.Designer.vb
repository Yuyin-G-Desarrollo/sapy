<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaMotivosPrestamoForm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaMotivosPrestamoForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaMotivosPrestamos = New System.Windows.Forms.Label()
        Me.Editar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.grdPrestamos = New System.Windows.Forms.DataGridView()
        Me.ColMotivosPrestamoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbBancos = New System.Windows.Forms.GroupBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombreBanco = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.grdPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbBancos.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblListaMotivosPrestamos)
        Me.pnlEncabezado.Controls.Add(Me.Editar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(884, 60)
        Me.pnlEncabezado.TabIndex = 4
        '
        'lblListaMotivosPrestamos
        '
        Me.lblListaMotivosPrestamos.AutoSize = True
        Me.lblListaMotivosPrestamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaMotivosPrestamos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaMotivosPrestamos.Location = New System.Drawing.Point(613, 17)
        Me.lblListaMotivosPrestamos.Name = "lblListaMotivosPrestamos"
        Me.lblListaMotivosPrestamos.Size = New System.Drawing.Size(185, 20)
        Me.lblListaMotivosPrestamos.TabIndex = 21
        Me.lblListaMotivosPrestamos.Text = "Motivos de Préstamos"
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(68, 41)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 23
        Me.Editar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(68, 6)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 22
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 6)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
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
        'grdPrestamos
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdPrestamos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPrestamos.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPrestamos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPrestamos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMotivosPrestamoid, Me.ColNombre, Me.ColNave, Me.ColActivo})
        Me.grdPrestamos.Location = New System.Drawing.Point(12, 196)
        Me.grdPrestamos.Name = "grdPrestamos"
        Me.grdPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPrestamos.Size = New System.Drawing.Size(851, 334)
        Me.grdPrestamos.TabIndex = 6
        '
        'ColMotivosPrestamoid
        '
        Me.ColMotivosPrestamoid.HeaderText = "id"
        Me.ColMotivosPrestamoid.Name = "ColMotivosPrestamoid"
        Me.ColMotivosPrestamoid.Visible = False
        '
        'ColNombre
        '
        Me.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNombre.FillWeight = 10.30928!
        Me.ColNombre.HeaderText = "Nombre"
        Me.ColNombre.Name = "ColNombre"
        '
        'ColNave
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColNave.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColNave.HeaderText = "Nave"
        Me.ColNave.Name = "ColNave"
        Me.ColNave.Width = 250
        '
        'ColActivo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColActivo.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColActivo.FillWeight = 189.6907!
        Me.ColActivo.HeaderText = "Activo"
        Me.ColActivo.Name = "ColActivo"
        Me.ColActivo.Width = 80
        '
        'grbBancos
        '
        Me.grbBancos.Controls.Add(Me.btnAbajo)
        Me.grbBancos.Controls.Add(Me.rdoNo)
        Me.grbBancos.Controls.Add(Me.btnArriba)
        Me.grbBancos.Controls.Add(Me.rdoSi)
        Me.grbBancos.Controls.Add(Me.btnLimpiar)
        Me.grbBancos.Controls.Add(Me.lblBúscar)
        Me.grbBancos.Controls.Add(Me.btnBuscar)
        Me.grbBancos.Controls.Add(Me.cmbNave)
        Me.grbBancos.Controls.Add(Me.lblLimpiar)
        Me.grbBancos.Controls.Add(Me.lblNave)
        Me.grbBancos.Controls.Add(Me.txtNombre)
        Me.grbBancos.Controls.Add(Me.lblNombreBanco)
        Me.grbBancos.Controls.Add(Me.lblActivo)
        Me.grbBancos.Location = New System.Drawing.Point(12, 61)
        Me.grbBancos.Name = "grbBancos"
        Me.grbBancos.Size = New System.Drawing.Size(850, 129)
        Me.grbBancos.TabIndex = 8
        Me.grbBancos.TabStop = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(815, 10)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 11
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(267, 106)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 7
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(789, 10)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 10
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(203, 106)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 6
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(803, 78)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(753, 110)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 22
        Me.lblBúscar.Text = "Mostrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(756, 78)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(203, 47)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(524, 21)
        Me.cmbNave.TabIndex = 24
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(800, 110)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 21
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(133, 52)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 23
        Me.lblNave.Text = "Nave"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(203, 78)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(524, 20)
        Me.txtNombre.TabIndex = 4
        '
        'lblNombreBanco
        '
        Me.lblNombreBanco.AutoSize = True
        Me.lblNombreBanco.Location = New System.Drawing.Point(133, 79)
        Me.lblNombreBanco.Name = "lblNombreBanco"
        Me.lblNombreBanco.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreBanco.TabIndex = 1
        Me.lblNombreBanco.Text = "Nombre"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(133, 106)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 0
        Me.lblActivo.Text = "Activo"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(816, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 48
        Me.pcbTitulo.TabStop = False
        '
        'ListaMotivosPrestamoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(884, 550)
        Me.Controls.Add(Me.grbBancos)
        Me.Controls.Add(Me.grdPrestamos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(890, 572)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(890, 572)
        Me.Name = "ListaMotivosPrestamoForm"
        Me.Text = "Lista Motivos Prestamo"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.grdPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbBancos.ResumeLayout(False)
        Me.grbBancos.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblListaMotivosPrestamos As System.Windows.Forms.Label
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents grdPrestamos As System.Windows.Forms.DataGridView
    Friend WithEvents Editar As System.Windows.Forms.Label
	Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents grbBancos As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreBanco As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents ColMotivosPrestamoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
