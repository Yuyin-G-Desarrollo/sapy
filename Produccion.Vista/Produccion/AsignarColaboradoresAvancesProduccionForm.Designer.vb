<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignarColaboradoresAvancesProduccionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignarColaboradoresAvancesProduccionForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblIdNAve = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblConfiguracion = New System.Windows.Forms.Label()
        Me.lblDepID = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.lblIdConfiguracion = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblIDDepartamento = New System.Windows.Forms.Label()
        Me.lblColaboradorSay = New System.Windows.Forms.Label()
        Me.lblIDColaboradorSay = New System.Windows.Forms.Label()
        Me.lblIDEmpleadoSicy = New System.Windows.Forms.Label()
        Me.lblIColaboradorSicy = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.lblIdText = New System.Windows.Forms.Label()
        Me.lbID = New System.Windows.Forms.Label()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnBuscar1 = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(562, 63)
        Me.pnlEncabezado.TabIndex = 162
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(52, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(436, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Asignación de Colaboradores Avances de Producción"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(494, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblIdNAve)
        Me.pnlInferior.Controls.Add(Me.lblGuardar)
        Me.pnlInferior.Controls.Add(Me.lblNave)
        Me.pnlInferior.Controls.Add(Me.btnGuardar)
        Me.pnlInferior.Controls.Add(Me.lblConfiguracion)
        Me.pnlInferior.Controls.Add(Me.lblDepID)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.lblIdConfiguracion)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.lblIDDepartamento)
        Me.pnlInferior.Controls.Add(Me.lblColaboradorSay)
        Me.pnlInferior.Controls.Add(Me.lblIDColaboradorSay)
        Me.pnlInferior.Controls.Add(Me.lblIDEmpleadoSicy)
        Me.pnlInferior.Controls.Add(Me.lblIColaboradorSicy)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 217)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(562, 56)
        Me.pnlInferior.TabIndex = 163
        '
        'lblIdNAve
        '
        Me.lblIdNAve.AutoSize = True
        Me.lblIdNAve.Location = New System.Drawing.Point(326, 34)
        Me.lblIdNAve.Name = "lblIdNAve"
        Me.lblIdNAve.Size = New System.Drawing.Size(13, 13)
        Me.lblIdNAve.TabIndex = 2045
        Me.lblIdNAve.Text = "0"
        Me.lblIdNAve.Visible = False
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(440, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 100
        Me.lblGuardar.Text = "Guardar"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(276, 34)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(44, 13)
        Me.lblNave.TabIndex = 2044
        Me.lblNave.Text = "id Nave"
        Me.lblNave.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(446, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 99
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblConfiguracion
        '
        Me.lblConfiguracion.AutoSize = True
        Me.lblConfiguracion.Location = New System.Drawing.Point(134, 34)
        Me.lblConfiguracion.Name = "lblConfiguracion"
        Me.lblConfiguracion.Size = New System.Drawing.Size(83, 13)
        Me.lblConfiguracion.TabIndex = 2043
        Me.lblConfiguracion.Text = "id Configuracion"
        Me.lblConfiguracion.Visible = False
        '
        'lblDepID
        '
        Me.lblDepID.AutoSize = True
        Me.lblDepID.Location = New System.Drawing.Point(134, 16)
        Me.lblDepID.Name = "lblDepID"
        Me.lblDepID.Size = New System.Drawing.Size(85, 13)
        Me.lblDepID.TabIndex = 2042
        Me.lblDepID.Text = "id Departamento"
        Me.lblDepID.Visible = False
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(508, 39)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'lblIdConfiguracion
        '
        Me.lblIdConfiguracion.AutoSize = True
        Me.lblIdConfiguracion.Location = New System.Drawing.Point(221, 34)
        Me.lblIdConfiguracion.Name = "lblIdConfiguracion"
        Me.lblIdConfiguracion.Size = New System.Drawing.Size(13, 13)
        Me.lblIdConfiguracion.TabIndex = 2038
        Me.lblIdConfiguracion.Text = "0"
        Me.lblIdConfiguracion.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(509, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblIDDepartamento
        '
        Me.lblIDDepartamento.AutoSize = True
        Me.lblIDDepartamento.Location = New System.Drawing.Point(221, 16)
        Me.lblIDDepartamento.Name = "lblIDDepartamento"
        Me.lblIDDepartamento.Size = New System.Drawing.Size(13, 13)
        Me.lblIDDepartamento.TabIndex = 2037
        Me.lblIDDepartamento.Text = "0"
        Me.lblIDDepartamento.Visible = False
        '
        'lblColaboradorSay
        '
        Me.lblColaboradorSay.AutoSize = True
        Me.lblColaboradorSay.Location = New System.Drawing.Point(12, 34)
        Me.lblColaboradorSay.Name = "lblColaboradorSay"
        Me.lblColaboradorSay.Size = New System.Drawing.Size(82, 13)
        Me.lblColaboradorSay.TabIndex = 2041
        Me.lblColaboradorSay.Text = "ColaboradorSay"
        Me.lblColaboradorSay.Visible = False
        '
        'lblIDColaboradorSay
        '
        Me.lblIDColaboradorSay.AutoSize = True
        Me.lblIDColaboradorSay.Location = New System.Drawing.Point(102, 34)
        Me.lblIDColaboradorSay.Name = "lblIDColaboradorSay"
        Me.lblIDColaboradorSay.Size = New System.Drawing.Size(13, 13)
        Me.lblIDColaboradorSay.TabIndex = 2040
        Me.lblIDColaboradorSay.Text = "0"
        Me.lblIDColaboradorSay.Visible = False
        '
        'lblIDEmpleadoSicy
        '
        Me.lblIDEmpleadoSicy.AutoSize = True
        Me.lblIDEmpleadoSicy.Location = New System.Drawing.Point(102, 14)
        Me.lblIDEmpleadoSicy.Name = "lblIDEmpleadoSicy"
        Me.lblIDEmpleadoSicy.Size = New System.Drawing.Size(13, 13)
        Me.lblIDEmpleadoSicy.TabIndex = 2036
        Me.lblIDEmpleadoSicy.Text = "0"
        Me.lblIDEmpleadoSicy.Visible = False
        '
        'lblIColaboradorSicy
        '
        Me.lblIColaboradorSicy.AutoSize = True
        Me.lblIColaboradorSicy.Location = New System.Drawing.Point(12, 16)
        Me.lblIColaboradorSicy.Name = "lblIColaboradorSicy"
        Me.lblIColaboradorSicy.Size = New System.Drawing.Size(84, 13)
        Me.lblIColaboradorSicy.TabIndex = 2039
        Me.lblIColaboradorSicy.Text = "ColaboradorSicy"
        Me.lblIColaboradorSicy.Visible = False
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Location = New System.Drawing.Point(135, 148)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(342, 20)
        Me.txtDepartamento.TabIndex = 2030
        '
        'lblIdText
        '
        Me.lblIdText.AutoSize = True
        Me.lblIdText.Location = New System.Drawing.Point(102, 101)
        Me.lblIdText.Name = "lblIdText"
        Me.lblIdText.Size = New System.Drawing.Size(10, 13)
        Me.lblIdText.TabIndex = 2033
        Me.lblIdText.Text = "-"
        '
        'lbID
        '
        Me.lbID.AutoSize = True
        Me.lbID.Location = New System.Drawing.Point(28, 101)
        Me.lbID.Name = "lbID"
        Me.lbID.Size = New System.Drawing.Size(18, 13)
        Me.lbID.TabIndex = 2032
        Me.lbID.Text = "ID"
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(414, 96)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(63, 17)
        Me.rdoInactivo.TabIndex = 2025
        Me.rdoInactivo.Text = "Inactivo"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Checked = True
        Me.rdoActivo.Location = New System.Drawing.Point(363, 96)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(55, 17)
        Me.rdoActivo.TabIndex = 2024
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Activo"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(315, 98)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(42, 13)
        Me.lblEstatus.TabIndex = 2023
        Me.lblEstatus.Text = "Estatus"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(28, 151)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.lblDepartamento.TabIndex = 2029
        Me.lblDepartamento.Text = "Departamento"
        '
        'txtColaborador
        '
        Me.txtColaborador.Enabled = False
        Me.txtColaborador.Location = New System.Drawing.Point(135, 121)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.Size = New System.Drawing.Size(342, 20)
        Me.txtColaborador.TabIndex = 2027
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(28, 125)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(64, 13)
        Me.lblColaborador.TabIndex = 2026
        Me.lblColaborador.Text = "Colaborador"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(499, 155)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 2035
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(501, 120)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2034
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_calcular
        Me.Button1.Location = New System.Drawing.Point(105, 146)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 24)
        Me.Button1.TabIndex = 2031
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnBuscar1
        '
        Me.btnBuscar1.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_calcular
        Me.btnBuscar1.Location = New System.Drawing.Point(105, 120)
        Me.btnBuscar1.Name = "btnBuscar1"
        Me.btnBuscar1.Size = New System.Drawing.Size(24, 24)
        Me.btnBuscar1.TabIndex = 2028
        Me.btnBuscar1.UseVisualStyleBackColor = True
        '
        'AsignarColaboradoresAvancesProduccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(562, 273)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.txtDepartamento)
        Me.Controls.Add(Me.lblIdText)
        Me.Controls.Add(Me.lbID)
        Me.Controls.Add(Me.rdoInactivo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rdoActivo)
        Me.Controls.Add(Me.lblEstatus)
        Me.Controls.Add(Me.lblDepartamento)
        Me.Controls.Add(Me.btnBuscar1)
        Me.Controls.Add(Me.txtColaborador)
        Me.Controls.Add(Me.lblColaborador)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(570, 300)
        Me.MinimumSize = New System.Drawing.Size(570, 300)
        Me.Name = "AsignarColaboradoresAvancesProduccionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = resources.GetString("$this.Text")
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents lblIdText As System.Windows.Forms.Label
    Friend WithEvents lbID As System.Windows.Forms.Label
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents btnBuscar1 As System.Windows.Forms.Button
    Friend WithEvents txtColaborador As System.Windows.Forms.TextBox
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblIDDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblIDEmpleadoSicy As System.Windows.Forms.Label
    Friend WithEvents lblIdConfiguracion As System.Windows.Forms.Label
    Friend WithEvents lblIColaboradorSicy As System.Windows.Forms.Label
    Friend WithEvents lblIDColaboradorSay As System.Windows.Forms.Label
    Friend WithEvents lblColaboradorSay As System.Windows.Forms.Label
    Friend WithEvents lblDepID As System.Windows.Forms.Label
    Friend WithEvents lblConfiguracion As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblIdNAve As System.Windows.Forms.Label
End Class
