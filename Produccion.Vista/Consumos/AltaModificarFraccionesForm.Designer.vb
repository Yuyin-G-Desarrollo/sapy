<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaModificarFraccionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaModificarFraccionesForm))
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblTiempo = New System.Windows.Forms.Label()
        Me.txtTiempo = New System.Windows.Forms.TextBox()
        Me.gbxPaga = New System.Windows.Forms.GroupBox()
        Me.rdoPagaNo = New System.Windows.Forms.RadioButton()
        Me.rdoPagaSi = New System.Windows.Forms.RadioButton()
        Me.llbId = New System.Windows.Forms.Label()
        Me.txtIDFraccion = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblFracciones = New System.Windows.Forms.Label()
        Me.gbxActivo = New System.Windows.Forms.GroupBox()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.txtFracciones = New System.Windows.Forms.TextBox()
        Me.lblMinutos = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblMaquinaria = New System.Windows.Forms.Label()
        Me.cmbMaquinaria = New System.Windows.Forms.ComboBox()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxPaga.SuspendLayout()
        Me.gbxActivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblGuardar)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.btnGuardar)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 173)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(461, 54)
        Me.pnlInferior.TabIndex = 2016
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(350, 38)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 102
        Me.lblGuardar.Text = "Guardar"
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(412, 40)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(413, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 10
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Image = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(356, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(461, 63)
        Me.pnlEncabezado.TabIndex = 2015
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(168, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(223, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta/Edición de Fracciones"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(393, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(205, 166)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecio.TabIndex = 2045
        Me.lblPrecio.Text = "Precio"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(248, 163)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(81, 20)
        Me.txtPrecio.TabIndex = 3
        '
        'lblTiempo
        '
        Me.lblTiempo.AutoSize = True
        Me.lblTiempo.Location = New System.Drawing.Point(23, 166)
        Me.lblTiempo.Name = "lblTiempo"
        Me.lblTiempo.Size = New System.Drawing.Size(42, 13)
        Me.lblTiempo.TabIndex = 2044
        Me.lblTiempo.Text = "Tiempo"
        '
        'txtTiempo
        '
        Me.txtTiempo.Location = New System.Drawing.Point(102, 163)
        Me.txtTiempo.Name = "txtTiempo"
        Me.txtTiempo.Size = New System.Drawing.Size(48, 20)
        Me.txtTiempo.TabIndex = 2
        '
        'gbxPaga
        '
        Me.gbxPaga.Controls.Add(Me.rdoPagaNo)
        Me.gbxPaga.Controls.Add(Me.rdoPagaSi)
        Me.gbxPaga.Location = New System.Drawing.Point(345, 174)
        Me.gbxPaga.Name = "gbxPaga"
        Me.gbxPaga.Size = New System.Drawing.Size(91, 35)
        Me.gbxPaga.TabIndex = 5
        Me.gbxPaga.TabStop = False
        Me.gbxPaga.Text = "Paga"
        '
        'rdoPagaNo
        '
        Me.rdoPagaNo.AutoSize = True
        Me.rdoPagaNo.Location = New System.Drawing.Point(46, 14)
        Me.rdoPagaNo.Name = "rdoPagaNo"
        Me.rdoPagaNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoPagaNo.TabIndex = 6
        Me.rdoPagaNo.Text = "No"
        Me.rdoPagaNo.UseVisualStyleBackColor = True
        '
        'rdoPagaSi
        '
        Me.rdoPagaSi.AutoSize = True
        Me.rdoPagaSi.Checked = True
        Me.rdoPagaSi.Location = New System.Drawing.Point(6, 14)
        Me.rdoPagaSi.Name = "rdoPagaSi"
        Me.rdoPagaSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoPagaSi.TabIndex = 5
        Me.rdoPagaSi.TabStop = True
        Me.rdoPagaSi.Text = "Si"
        Me.rdoPagaSi.UseVisualStyleBackColor = True
        '
        'llbId
        '
        Me.llbId.AutoSize = True
        Me.llbId.Location = New System.Drawing.Point(23, 89)
        Me.llbId.Name = "llbId"
        Me.llbId.Size = New System.Drawing.Size(18, 13)
        Me.llbId.TabIndex = 2042
        Me.llbId.Text = "ID"
        '
        'txtIDFraccion
        '
        Me.txtIDFraccion.Enabled = False
        Me.txtIDFraccion.Location = New System.Drawing.Point(102, 86)
        Me.txtIDFraccion.Name = "txtIDFraccion"
        Me.txtIDFraccion.Size = New System.Drawing.Size(59, 20)
        Me.txtIDFraccion.TabIndex = 11
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(102, 86)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(59, 20)
        Me.txtID.TabIndex = 2040
        '
        'lblFracciones
        '
        Me.lblFracciones.AutoSize = True
        Me.lblFracciones.Location = New System.Drawing.Point(23, 117)
        Me.lblFracciones.Name = "lblFracciones"
        Me.lblFracciones.Size = New System.Drawing.Size(52, 13)
        Me.lblFracciones.TabIndex = 2037
        Me.lblFracciones.Text = "*Fracción"
        '
        'gbxActivo
        '
        Me.gbxActivo.Controls.Add(Me.rdoActivoNo)
        Me.gbxActivo.Controls.Add(Me.rdoActivoSi)
        Me.gbxActivo.Location = New System.Drawing.Point(345, 99)
        Me.gbxActivo.Name = "gbxActivo"
        Me.gbxActivo.Size = New System.Drawing.Size(91, 35)
        Me.gbxActivo.TabIndex = 7
        Me.gbxActivo.TabStop = False
        Me.gbxActivo.Text = "Activo"
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(46, 14)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 8
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(6, 14)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 7
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'txtFracciones
        '
        Me.txtFracciones.Location = New System.Drawing.Point(102, 114)
        Me.txtFracciones.Name = "txtFracciones"
        Me.txtFracciones.Size = New System.Drawing.Size(227, 20)
        Me.txtFracciones.TabIndex = 1
        '
        'lblMinutos
        '
        Me.lblMinutos.AutoSize = True
        Me.lblMinutos.Location = New System.Drawing.Point(150, 166)
        Me.lblMinutos.Name = "lblMinutos"
        Me.lblMinutos.Size = New System.Drawing.Size(43, 13)
        Me.lblMinutos.TabIndex = 2047
        Me.lblMinutos.Text = "minutos"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(102, 167)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(227, 21)
        Me.cmbDepartamento.TabIndex = 2048
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(23, 170)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(78, 13)
        Me.lblDepartamento.TabIndex = 2049
        Me.lblDepartamento.Text = "*Departamento"
        '
        'lblMaquinaria
        '
        Me.lblMaquinaria.AutoSize = True
        Me.lblMaquinaria.Location = New System.Drawing.Point(23, 196)
        Me.lblMaquinaria.Name = "lblMaquinaria"
        Me.lblMaquinaria.Size = New System.Drawing.Size(59, 13)
        Me.lblMaquinaria.TabIndex = 2046
        Me.lblMaquinaria.Text = "Maquinaria"
        Me.lblMaquinaria.Visible = False
        '
        'cmbMaquinaria
        '
        Me.cmbMaquinaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaquinaria.FormattingEnabled = True
        Me.cmbMaquinaria.Location = New System.Drawing.Point(102, 196)
        Me.cmbMaquinaria.Name = "cmbMaquinaria"
        Me.cmbMaquinaria.Size = New System.Drawing.Size(227, 21)
        Me.cmbMaquinaria.TabIndex = 4
        Me.cmbMaquinaria.Visible = False
        '
        'AltaModificarFraccionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(461, 227)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.lblDepartamento)
        Me.Controls.Add(Me.cmbDepartamento)
        Me.Controls.Add(Me.lblMinutos)
        Me.Controls.Add(Me.cmbMaquinaria)
        Me.Controls.Add(Me.lblMaquinaria)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.lblTiempo)
        Me.Controls.Add(Me.txtTiempo)
        Me.Controls.Add(Me.gbxPaga)
        Me.Controls.Add(Me.llbId)
        Me.Controls.Add(Me.txtIDFraccion)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblFracciones)
        Me.Controls.Add(Me.gbxActivo)
        Me.Controls.Add(Me.txtFracciones)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximumSize = New System.Drawing.Size(469, 251)
        Me.MinimumSize = New System.Drawing.Size(469, 251)
        Me.Name = "AltaModificarFraccionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta/Edición de Fracciones"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxPaga.ResumeLayout(False)
        Me.gbxPaga.PerformLayout()
        Me.gbxActivo.ResumeLayout(False)
        Me.gbxActivo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents lblTiempo As System.Windows.Forms.Label
    Friend WithEvents txtTiempo As System.Windows.Forms.TextBox
    Friend WithEvents gbxPaga As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPagaNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPagaSi As System.Windows.Forms.RadioButton
    Friend WithEvents llbId As System.Windows.Forms.Label
    Friend WithEvents txtIDFraccion As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblFracciones As System.Windows.Forms.Label
    Friend WithEvents gbxActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents txtFracciones As System.Windows.Forms.TextBox
    Friend WithEvents lblMinutos As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblMaquinaria As System.Windows.Forms.Label
    Friend WithEvents cmbMaquinaria As System.Windows.Forms.ComboBox
End Class
