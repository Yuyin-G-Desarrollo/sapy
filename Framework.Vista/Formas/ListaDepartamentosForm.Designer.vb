<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDepartamentosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaDepartamentosForm))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblListaDepartamentos = New System.Windows.Forms.Label()
        Me.lblPerfiles = New System.Windows.Forms.Label()
        Me.btnPermisos = New System.Windows.Forms.Button()
        Me.Editar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.grbDepartamentos = New System.Windows.Forms.GroupBox()
        Me.lblAreas = New System.Windows.Forms.Label()
        Me.cmbAreas = New System.Windows.Forms.ComboBox()
        Me.lblNaves = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.txtNombreDelDepartamento = New System.Windows.Forms.TextBox()
        Me.lblNombreDepartamento = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.grdDepartamentos = New System.Windows.Forms.DataGridView()
        Me.ColId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAreas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalculoPrimaVacacionalDS1 = New Nomina.Vista.CalculoPrimaVacacionalDS()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDepartamentos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdDepartamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoPrimaVacacionalDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Controls.Add(Me.lblPerfiles)
        Me.pnlEncabezado.Controls.Add(Me.btnPermisos)
        Me.pnlEncabezado.Controls.Add(Me.Editar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(514, 67)
        Me.pnlEncabezado.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblListaDepartamentos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(265, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(179, 67)
        Me.Panel1.TabIndex = 34
        '
        'lblListaDepartamentos
        '
        Me.lblListaDepartamentos.AutoSize = True
        Me.lblListaDepartamentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaDepartamentos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaDepartamentos.Location = New System.Drawing.Point(43, 24)
        Me.lblListaDepartamentos.Name = "lblListaDepartamentos"
        Me.lblListaDepartamentos.Size = New System.Drawing.Size(133, 20)
        Me.lblListaDepartamentos.TabIndex = 21
        Me.lblListaDepartamentos.Text = "Departamentos"
        '
        'lblPerfiles
        '
        Me.lblPerfiles.AutoSize = True
        Me.lblPerfiles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPerfiles.Location = New System.Drawing.Point(109, 47)
        Me.lblPerfiles.Name = "lblPerfiles"
        Me.lblPerfiles.Size = New System.Drawing.Size(41, 13)
        Me.lblPerfiles.TabIndex = 33
        Me.lblPerfiles.Text = "Perfiles"
        Me.lblPerfiles.Visible = False
        '
        'btnPermisos
        '
        Me.btnPermisos.Image = CType(resources.GetObject("btnPermisos.Image"), System.Drawing.Image)
        Me.btnPermisos.Location = New System.Drawing.Point(114, 12)
        Me.btnPermisos.Name = "btnPermisos"
        Me.btnPermisos.Size = New System.Drawing.Size(32, 32)
        Me.btnPermisos.TabIndex = 3
        Me.btnPermisos.UseVisualStyleBackColor = True
        Me.btnPermisos.Visible = False
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(64, 47)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 19
        Me.Editar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(64, 12)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 12)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(18, 47)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.logoYuyin2
        Me.imgLogo.Location = New System.Drawing.Point(444, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 67)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'grbDepartamentos
        '
        Me.grbDepartamentos.Controls.Add(Me.lblAreas)
        Me.grbDepartamentos.Controls.Add(Me.cmbAreas)
        Me.grbDepartamentos.Controls.Add(Me.lblNaves)
        Me.grbDepartamentos.Controls.Add(Me.cmbNaves)
        Me.grbDepartamentos.Controls.Add(Me.btnAbajo)
        Me.grbDepartamentos.Controls.Add(Me.btnArriba)
        Me.grbDepartamentos.Controls.Add(Me.lblBúscar)
        Me.grbDepartamentos.Controls.Add(Me.lblLimpiar)
        Me.grbDepartamentos.Controls.Add(Me.btnLimpiar)
        Me.grbDepartamentos.Controls.Add(Me.btnBuscar)
        Me.grbDepartamentos.Controls.Add(Me.GroupBox2)
        Me.grbDepartamentos.Controls.Add(Me.txtNombreDelDepartamento)
        Me.grbDepartamentos.Controls.Add(Me.lblNombreDepartamento)
        Me.grbDepartamentos.Controls.Add(Me.lblActivo)
        Me.grbDepartamentos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbDepartamentos.Location = New System.Drawing.Point(0, 67)
        Me.grbDepartamentos.Name = "grbDepartamentos"
        Me.grbDepartamentos.Size = New System.Drawing.Size(514, 170)
        Me.grbDepartamentos.TabIndex = 2
        Me.grbDepartamentos.TabStop = False
        '
        'lblAreas
        '
        Me.lblAreas.AutoSize = True
        Me.lblAreas.Location = New System.Drawing.Point(83, 99)
        Me.lblAreas.Name = "lblAreas"
        Me.lblAreas.Size = New System.Drawing.Size(29, 13)
        Me.lblAreas.TabIndex = 38
        Me.lblAreas.Text = "Área"
        '
        'cmbAreas
        '
        Me.cmbAreas.FormattingEnabled = True
        Me.cmbAreas.Location = New System.Drawing.Point(146, 96)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(255, 21)
        Me.cmbAreas.TabIndex = 37
        '
        'lblNaves
        '
        Me.lblNaves.AutoSize = True
        Me.lblNaves.Location = New System.Drawing.Point(83, 72)
        Me.lblNaves.Name = "lblNaves"
        Me.lblNaves.Size = New System.Drawing.Size(33, 13)
        Me.lblNaves.TabIndex = 36
        Me.lblNaves.Text = "Nave"
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(146, 69)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(255, 21)
        Me.cmbNaves.TabIndex = 35
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(484, 15)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 11
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(453, 14)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 10
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(419, 148)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 22
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(469, 148)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 21
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(472, 114)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 9
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(422, 114)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoNo)
        Me.GroupBox2.Controls.Add(Me.rdoSi)
        Me.GroupBox2.Location = New System.Drawing.Point(146, 119)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(191, 37)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(59, 12)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 7
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(17, 12)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 6
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'txtNombreDelDepartamento
        '
        Me.txtNombreDelDepartamento.Location = New System.Drawing.Point(146, 43)
        Me.txtNombreDelDepartamento.Name = "txtNombreDelDepartamento"
        Me.txtNombreDelDepartamento.Size = New System.Drawing.Size(255, 20)
        Me.txtNombreDelDepartamento.TabIndex = 4
        '
        'lblNombreDepartamento
        '
        Me.lblNombreDepartamento.AutoSize = True
        Me.lblNombreDepartamento.Location = New System.Drawing.Point(82, 46)
        Me.lblNombreDepartamento.Name = "lblNombreDepartamento"
        Me.lblNombreDepartamento.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreDepartamento.TabIndex = 1
        Me.lblNombreDepartamento.Text = "Nombre"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(82, 133)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 0
        Me.lblActivo.Text = "Activo"
        '
        'grdDepartamentos
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDepartamentos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdDepartamentos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDepartamentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColId, Me.ColNombre, Me.ColNave, Me.ColAreas, Me.ColActivo})
        Me.grdDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDepartamentos.Location = New System.Drawing.Point(0, 237)
        Me.grdDepartamentos.Name = "grdDepartamentos"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDepartamentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdDepartamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDepartamentos.Size = New System.Drawing.Size(514, 305)
        Me.grdDepartamentos.TabIndex = 12
        '
        'ColId
        '
        Me.ColId.HeaderText = "Column1"
        Me.ColId.Name = "ColId"
        Me.ColId.Visible = False
        '
        'ColNombre
        '
        Me.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNombre.HeaderText = "Nombre"
        Me.ColNombre.Name = "ColNombre"
        '
        'ColNave
        '
        Me.ColNave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNave.HeaderText = "Nave"
        Me.ColNave.Name = "ColNave"
        '
        'ColAreas
        '
        Me.ColAreas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColAreas.HeaderText = "Área"
        Me.ColAreas.Name = "ColAreas"
        '
        'ColActivo
        '
        Me.ColActivo.HeaderText = "Activo"
        Me.ColActivo.Name = "ColActivo"
        Me.ColActivo.ReadOnly = True
        Me.ColActivo.Visible = False
        Me.ColActivo.Width = 129
        '
        'CalculoPrimaVacacionalDS1
        '
        Me.CalculoPrimaVacacionalDS1.DataSetName = "CalculoPrimaVacacionalDS"
        Me.CalculoPrimaVacacionalDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ListaDepartamentosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(514, 542)
        Me.Controls.Add(Me.grdDepartamentos)
        Me.Controls.Add(Me.grbDepartamentos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(530, 576)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(530, 576)
        Me.Name = "ListaDepartamentosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Lista Departamentos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDepartamentos.ResumeLayout(False)
        Me.grbDepartamentos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdDepartamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoPrimaVacacionalDS1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblListaDepartamentos As System.Windows.Forms.Label
	Friend WithEvents Editar As System.Windows.Forms.Label
	Friend WithEvents btnEditar As System.Windows.Forms.Button
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents lblPerfiles As System.Windows.Forms.Label
	Friend WithEvents btnPermisos As System.Windows.Forms.Button
	Friend WithEvents grbDepartamentos As System.Windows.Forms.GroupBox
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
	Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
	Friend WithEvents txtNombreDelDepartamento As System.Windows.Forms.TextBox
	Friend WithEvents lblNombreDepartamento As System.Windows.Forms.Label
	Friend WithEvents lblActivo As System.Windows.Forms.Label
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents grdDepartamentos As System.Windows.Forms.DataGridView
	Friend WithEvents lblNaves As System.Windows.Forms.Label
	Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
	Friend WithEvents lblAreas As System.Windows.Forms.Label
	Friend WithEvents cmbAreas As System.Windows.Forms.ComboBox
    Friend WithEvents CalculoPrimaVacacionalDS1 As Nomina.Vista.CalculoPrimaVacacionalDS
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ColId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAreas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
