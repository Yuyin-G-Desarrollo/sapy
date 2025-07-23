<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCortadoresForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaCortadoresForm))
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblNaveid = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblIdRegistro = New System.Windows.Forms.Label()
        Me.lblIdColaborador = New System.Windows.Forms.Label()
        Me.lblIdText = New System.Windows.Forms.Label()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.cmbTipoCortador = New System.Windows.Forms.ComboBox()
        Me.txtNombreCorto = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblTipoCortador = New System.Windows.Forms.Label()
        Me.lblNombreCorto = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscarEmpleado = New System.Windows.Forms.Button()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblNaveid)
        Me.pnlInferior.Controls.Add(Me.lblGuardar)
        Me.pnlInferior.Controls.Add(Me.Label2)
        Me.pnlInferior.Controls.Add(Me.btnGuardar)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 217)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(412, 56)
        Me.pnlInferior.TabIndex = 162
        '
        'lblNaveid
        '
        Me.lblNaveid.AutoSize = True
        Me.lblNaveid.Location = New System.Drawing.Point(96, 34)
        Me.lblNaveid.Name = "lblNaveid"
        Me.lblNaveid.Size = New System.Drawing.Size(13, 13)
        Me.lblNaveid.TabIndex = 2032
        Me.lblNaveid.Text = "0"
        Me.lblNaveid.Visible = False
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(290, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 100
        Me.lblGuardar.Text = "Guardar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2031
        Me.Label2.Text = "ID Nave"
        Me.Label2.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(296, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 99
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(358, 39)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(359, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(337, 146)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 102
        Me.lblLimpiar.Text = "Limpiar"
        Me.lblLimpiar.Visible = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(412, 63)
        Me.pnlEncabezado.TabIndex = 161
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(114, 26)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(224, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta/Edición de Cortadores"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(344, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblIdRegistro
        '
        Me.lblIdRegistro.AutoSize = True
        Me.lblIdRegistro.Location = New System.Drawing.Point(211, 74)
        Me.lblIdRegistro.Name = "lblIdRegistro"
        Me.lblIdRegistro.Size = New System.Drawing.Size(55, 13)
        Me.lblIdRegistro.TabIndex = 2030
        Me.lblIdRegistro.Text = "ID registro"
        Me.lblIdRegistro.Visible = False
        '
        'lblIdColaborador
        '
        Me.lblIdColaborador.AutoSize = True
        Me.lblIdColaborador.Location = New System.Drawing.Point(117, 74)
        Me.lblIdColaborador.Name = "lblIdColaborador"
        Me.lblIdColaborador.Size = New System.Drawing.Size(10, 13)
        Me.lblIdColaborador.TabIndex = 2029
        Me.lblIdColaborador.Text = "-"
        '
        'lblIdText
        '
        Me.lblIdText.AutoSize = True
        Me.lblIdText.Location = New System.Drawing.Point(272, 74)
        Me.lblIdText.Name = "lblIdText"
        Me.lblIdText.Size = New System.Drawing.Size(0, 13)
        Me.lblIdText.TabIndex = 2027
        Me.lblIdText.Visible = False
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(207, 174)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(63, 17)
        Me.rdoInactivo.TabIndex = 2026
        Me.rdoInactivo.Text = "Inactivo"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Checked = True
        Me.rdoActivo.Location = New System.Drawing.Point(139, 174)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(55, 17)
        Me.rdoActivo.TabIndex = 2025
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Activo"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'cmbTipoCortador
        '
        Me.cmbTipoCortador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCortador.FormattingEnabled = True
        Me.cmbTipoCortador.Location = New System.Drawing.Point(120, 147)
        Me.cmbTipoCortador.Name = "cmbTipoCortador"
        Me.cmbTipoCortador.Size = New System.Drawing.Size(187, 21)
        Me.cmbTipoCortador.TabIndex = 2024
        '
        'txtNombreCorto
        '
        Me.txtNombreCorto.Enabled = False
        Me.txtNombreCorto.Location = New System.Drawing.Point(120, 120)
        Me.txtNombreCorto.Name = "txtNombreCorto"
        Me.txtNombreCorto.Size = New System.Drawing.Size(187, 20)
        Me.txtNombreCorto.TabIndex = 2023
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(120, 94)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(187, 20)
        Me.txtNombre.TabIndex = 2022
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(60, 174)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(46, 13)
        Me.lblEstatus.TabIndex = 2021
        Me.lblEstatus.Text = "*Estatus"
        '
        'lblTipoCortador
        '
        Me.lblTipoCortador.AutoSize = True
        Me.lblTipoCortador.Location = New System.Drawing.Point(31, 146)
        Me.lblTipoCortador.Name = "lblTipoCortador"
        Me.lblTipoCortador.Size = New System.Drawing.Size(75, 13)
        Me.lblTipoCortador.TabIndex = 2020
        Me.lblTipoCortador.Text = "*Tipo Cortador"
        '
        'lblNombreCorto
        '
        Me.lblNombreCorto.AutoSize = True
        Me.lblNombreCorto.Location = New System.Drawing.Point(34, 123)
        Me.lblNombreCorto.Name = "lblNombreCorto"
        Me.lblNombreCorto.Size = New System.Drawing.Size(72, 13)
        Me.lblNombreCorto.TabIndex = 2019
        Me.lblNombreCorto.Text = "Nombre Corto"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(34, 97)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblNombre.TabIndex = 2018
        Me.lblNombre.Text = "*Nombre"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(28, 74)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(78, 13)
        Me.lblId.TabIndex = 2017
        Me.lblId.Text = "ID Colaborador"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(339, 111)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 101
        Me.btnLimpiar.UseVisualStyleBackColor = True
        Me.btnLimpiar.Visible = False
        '
        'btnBuscarEmpleado
        '
        Me.btnBuscarEmpleado.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_calcular
        Me.btnBuscarEmpleado.Location = New System.Drawing.Point(82, 91)
        Me.btnBuscarEmpleado.Name = "btnBuscarEmpleado"
        Me.btnBuscarEmpleado.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscarEmpleado.TabIndex = 2028
        Me.btnBuscarEmpleado.UseVisualStyleBackColor = True
        '
        'AltaCortadoresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(412, 273)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.lblIdRegistro)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.lblIdColaborador)
        Me.Controls.Add(Me.btnBuscarEmpleado)
        Me.Controls.Add(Me.lblIdText)
        Me.Controls.Add(Me.rdoInactivo)
        Me.Controls.Add(Me.rdoActivo)
        Me.Controls.Add(Me.cmbTipoCortador)
        Me.Controls.Add(Me.txtNombreCorto)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblEstatus)
        Me.Controls.Add(Me.lblTipoCortador)
        Me.Controls.Add(Me.lblNombreCorto)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(420, 300)
        Me.MinimumSize = New System.Drawing.Size(420, 300)
        Me.Name = "AltaCortadoresForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta/Edición de Cortadores"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblIdRegistro As System.Windows.Forms.Label
    Friend WithEvents lblIdColaborador As System.Windows.Forms.Label
    Friend WithEvents btnBuscarEmpleado As System.Windows.Forms.Button
    Friend WithEvents lblIdText As System.Windows.Forms.Label
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents cmbTipoCortador As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreCorto As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblTipoCortador As System.Windows.Forms.Label
    Friend WithEvents lblNombreCorto As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents lblNaveid As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
