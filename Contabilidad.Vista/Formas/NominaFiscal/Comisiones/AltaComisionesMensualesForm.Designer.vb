<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AltaComisionesMensualesForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlAreaTrabajo = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblMontoMax = New System.Windows.Forms.Label()
        Me.numMes = New System.Windows.Forms.NumericUpDown()
        Me.numMontoComision = New System.Windows.Forms.NumericUpDown()
        Me.numAnio = New System.Windows.Forms.NumericUpDown()
        Me.lblMontoComision = New System.Windows.Forms.Label()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.cmbColaborador = New System.Windows.Forms.ComboBox()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlContenido.SuspendLayout()
        Me.pnlAreaTrabajo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMontoComision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenido
        '
        Me.pnlContenido.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenido.Controls.Add(Me.pnlAreaTrabajo)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(633, 311)
        Me.pnlContenido.TabIndex = 14
        '
        'pnlAreaTrabajo
        '
        Me.pnlAreaTrabajo.AutoSize = True
        Me.pnlAreaTrabajo.Controls.Add(Me.GroupBox2)
        Me.pnlAreaTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAreaTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.pnlAreaTrabajo.Name = "pnlAreaTrabajo"
        Me.pnlAreaTrabajo.Size = New System.Drawing.Size(633, 311)
        Me.pnlAreaTrabajo.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblMontoMax)
        Me.GroupBox2.Controls.Add(Me.numMes)
        Me.GroupBox2.Controls.Add(Me.numMontoComision)
        Me.GroupBox2.Controls.Add(Me.numAnio)
        Me.GroupBox2.Controls.Add(Me.lblMontoComision)
        Me.GroupBox2.Controls.Add(Me.lblMes)
        Me.GroupBox2.Controls.Add(Me.lblAnio)
        Me.GroupBox2.Controls.Add(Me.cmbEmpresa)
        Me.GroupBox2.Controls.Add(Me.lblPatron)
        Me.GroupBox2.Controls.Add(Me.lblPeriodo)
        Me.GroupBox2.Controls.Add(Me.cmbColaborador)
        Me.GroupBox2.Controls.Add(Me.cmbPeriodo)
        Me.GroupBox2.Controls.Add(Me.lblColaborador)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(599, 282)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        '
        'lblMontoMax
        '
        Me.lblMontoMax.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMontoMax.Location = New System.Drawing.Point(240, 147)
        Me.lblMontoMax.Name = "lblMontoMax"
        Me.lblMontoMax.Size = New System.Drawing.Size(339, 13)
        Me.lblMontoMax.TabIndex = 155
        Me.lblMontoMax.Text = "Máximo: $16000"
        '
        'numMes
        '
        Me.numMes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.numMes.Location = New System.Drawing.Point(106, 179)
        Me.numMes.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numMes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMes.Name = "numMes"
        Me.numMes.Size = New System.Drawing.Size(110, 20)
        Me.numMes.TabIndex = 154
        Me.numMes.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'numMontoComision
        '
        Me.numMontoComision.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.numMontoComision.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numMontoComision.Location = New System.Drawing.Point(106, 145)
        Me.numMontoComision.Maximum = New Decimal(New Integer() {11500, 0, 0, 0})
        Me.numMontoComision.Name = "numMontoComision"
        Me.numMontoComision.Size = New System.Drawing.Size(110, 20)
        Me.numMontoComision.TabIndex = 38
        '
        'numAnio
        '
        Me.numAnio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.numAnio.Location = New System.Drawing.Point(106, 214)
        Me.numAnio.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.numAnio.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.numAnio.Name = "numAnio"
        Me.numAnio.Size = New System.Drawing.Size(110, 20)
        Me.numAnio.TabIndex = 153
        Me.numAnio.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'lblMontoComision
        '
        Me.lblMontoComision.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMontoComision.AutoSize = True
        Me.lblMontoComision.Location = New System.Drawing.Point(40, 147)
        Me.lblMontoComision.Name = "lblMontoComision"
        Me.lblMontoComision.Size = New System.Drawing.Size(37, 13)
        Me.lblMontoComision.TabIndex = 37
        Me.lblMontoComision.Text = "Monto"
        '
        'lblMes
        '
        Me.lblMes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMes.AutoSize = True
        Me.lblMes.Location = New System.Drawing.Point(50, 181)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(27, 13)
        Me.lblMes.TabIndex = 152
        Me.lblMes.Text = "Mes"
        '
        'lblAnio
        '
        Me.lblAnio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(53, 216)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(26, 13)
        Me.lblAnio.TabIndex = 151
        Me.lblAnio.Text = "Año"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(106, 40)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(473, 21)
        Me.cmbEmpresa.TabIndex = 12
        '
        'lblPatron
        '
        Me.lblPatron.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPatron.AutoSize = True
        Me.lblPatron.Location = New System.Drawing.Point(41, 43)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(38, 13)
        Me.lblPatron.TabIndex = 0
        Me.lblPatron.Text = "Patrón"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(36, 79)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(43, 13)
        Me.lblPeriodo.TabIndex = 1
        Me.lblPeriodo.Text = "Periodo"
        '
        'cmbColaborador
        '
        Me.cmbColaborador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColaborador.FormattingEnabled = True
        Me.cmbColaborador.Location = New System.Drawing.Point(106, 110)
        Me.cmbColaborador.Name = "cmbColaborador"
        Me.cmbColaborador.Size = New System.Drawing.Size(473, 21)
        Me.cmbColaborador.TabIndex = 25
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(106, 76)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(473, 21)
        Me.cmbPeriodo.TabIndex = 20
        '
        'lblColaborador
        '
        Me.lblColaborador.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(15, 113)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(64, 13)
        Me.lblColaborador.TabIndex = 23
        Me.lblColaborador.Text = "Colaborador"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(633, 60)
        Me.pnlHeader.TabIndex = 12
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-16, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(649, 60)
        Me.pnlTitulo.TabIndex = 2
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(400, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(163, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Alta de Comisiones"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 371)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(633, 60)
        Me.pnlPie.TabIndex = 13
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(371, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(262, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(220, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 32
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(219, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 33
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnGuardar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(173, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 24
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(168, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 25
        Me.lblGuardar.Text = "Guardar"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(577, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 38
        Me.imgLogo.TabStop = False
        '
        'AltaComisionesMensualesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(633, 431)
        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlPie)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(641, 458)
        Me.MinimumSize = New System.Drawing.Size(641, 458)
        Me.Name = "AltaComisionesMensualesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Comisiones Mensuales"
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenido.PerformLayout()
        Me.pnlAreaTrabajo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMontoComision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContenido As Windows.Forms.Panel
    Friend WithEvents pnlAreaTrabajo As Windows.Forms.Panel
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents numMes As Windows.Forms.NumericUpDown
    Friend WithEvents numMontoComision As Windows.Forms.NumericUpDown
    Friend WithEvents numAnio As Windows.Forms.NumericUpDown
    Friend WithEvents lblMontoComision As Windows.Forms.Label
    Friend WithEvents lblMes As Windows.Forms.Label
    Friend WithEvents lblAnio As Windows.Forms.Label
    Friend WithEvents cmbEmpresa As Windows.Forms.ComboBox
    Friend WithEvents lblPatron As Windows.Forms.Label
    Friend WithEvents lblPeriodo As Windows.Forms.Label
    Friend WithEvents cmbColaborador As Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodo As Windows.Forms.ComboBox
    Friend WithEvents lblColaborador As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents lblMontoMax As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
