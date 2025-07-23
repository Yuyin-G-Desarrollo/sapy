<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarCondicionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarCondicionesForm))
        Me.grpCondicion = New System.Windows.Forms.GroupBox()
        Me.cboCondicionTipo = New System.Windows.Forms.ComboBox()
        Me.lblCondicionTipo = New System.Windows.Forms.Label()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoCondicionActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoCondicionActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblCondicionActivo = New System.Windows.Forms.Label()
        Me.txtCondicionNombre = New System.Windows.Forms.TextBox()
        Me.lblCondicionNombre = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlAltaDias = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarTipoPolitica = New System.Windows.Forms.Button()
        Me.btnGuardarCondiciones = New System.Windows.Forms.Button()
        Me.grpCatalogoCondicion = New System.Windows.Forms.GroupBox()
        Me.cboTipoPolitica = New System.Windows.Forms.ComboBox()
        Me.cboCatalogoCondicion = New System.Windows.Forms.ComboBox()
        Me.lblTipoPolitica = New System.Windows.Forms.Label()
        Me.lblCatalogoCondicion = New System.Windows.Forms.Label()
        Me.pnlCatalogoTipo = New System.Windows.Forms.Panel()
        Me.rdoCatalogoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoCatalogoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblCatalogoActivo = New System.Windows.Forms.Label()
        Me.txtDescripcionCatalogo = New System.Windows.Forms.TextBox()
        Me.lblCatalogoDescripcion = New System.Windows.Forms.Label()
        Me.grpTipoCondicion = New System.Windows.Forms.GroupBox()
        Me.pnlTipoActivo = New System.Windows.Forms.Panel()
        Me.rdoTipoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoTipoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblTipoActivo = New System.Windows.Forms.Label()
        Me.txtTipoNombre = New System.Windows.Forms.TextBox()
        Me.lblTipoNombre = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grpCondicion.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        Me.pnlAltaDias.SuspendLayout()
        Me.grpCatalogoCondicion.SuspendLayout()
        Me.pnlCatalogoTipo.SuspendLayout()
        Me.grpTipoCondicion.SuspendLayout()
        Me.pnlTipoActivo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpCondicion
        '
        Me.grpCondicion.Controls.Add(Me.cboCondicionTipo)
        Me.grpCondicion.Controls.Add(Me.lblCondicionTipo)
        Me.grpCondicion.Controls.Add(Me.pnlrdoActivo)
        Me.grpCondicion.Controls.Add(Me.lblCondicionActivo)
        Me.grpCondicion.Controls.Add(Me.txtCondicionNombre)
        Me.grpCondicion.Controls.Add(Me.lblCondicionNombre)
        Me.grpCondicion.Location = New System.Drawing.Point(27, 80)
        Me.grpCondicion.Name = "grpCondicion"
        Me.grpCondicion.Size = New System.Drawing.Size(349, 109)
        Me.grpCondicion.TabIndex = 18
        Me.grpCondicion.TabStop = False
        Me.grpCondicion.Visible = False
        '
        'cboCondicionTipo
        '
        Me.cboCondicionTipo.FormattingEnabled = True
        Me.cboCondicionTipo.Location = New System.Drawing.Point(71, 19)
        Me.cboCondicionTipo.Name = "cboCondicionTipo"
        Me.cboCondicionTipo.Size = New System.Drawing.Size(254, 21)
        Me.cboCondicionTipo.TabIndex = 2
        '
        'lblCondicionTipo
        '
        Me.lblCondicionTipo.AutoSize = True
        Me.lblCondicionTipo.Location = New System.Drawing.Point(17, 22)
        Me.lblCondicionTipo.Name = "lblCondicionTipo"
        Me.lblCondicionTipo.Size = New System.Drawing.Size(32, 13)
        Me.lblCondicionTipo.TabIndex = 10
        Me.lblCondicionTipo.Text = "*Tipo"
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoCondicionActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoCondicionActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(68, 72)
        Me.pnlrdoActivo.Name = "pnlrdoActivo"
        Me.pnlrdoActivo.Size = New System.Drawing.Size(84, 30)
        Me.pnlrdoActivo.TabIndex = 9
        '
        'rdoCondicionActivoNo
        '
        Me.rdoCondicionActivoNo.AutoSize = True
        Me.rdoCondicionActivoNo.Location = New System.Drawing.Point(42, 9)
        Me.rdoCondicionActivoNo.Name = "rdoCondicionActivoNo"
        Me.rdoCondicionActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoCondicionActivoNo.TabIndex = 3
        Me.rdoCondicionActivoNo.Text = "No"
        Me.rdoCondicionActivoNo.UseVisualStyleBackColor = True
        '
        'rdoCondicionActivoSi
        '
        Me.rdoCondicionActivoSi.AutoSize = True
        Me.rdoCondicionActivoSi.Checked = True
        Me.rdoCondicionActivoSi.Location = New System.Drawing.Point(3, 9)
        Me.rdoCondicionActivoSi.Name = "rdoCondicionActivoSi"
        Me.rdoCondicionActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoCondicionActivoSi.TabIndex = 3
        Me.rdoCondicionActivoSi.TabStop = True
        Me.rdoCondicionActivoSi.Text = "Si"
        Me.rdoCondicionActivoSi.UseVisualStyleBackColor = True
        '
        'lblCondicionActivo
        '
        Me.lblCondicionActivo.AutoSize = True
        Me.lblCondicionActivo.Location = New System.Drawing.Point(17, 81)
        Me.lblCondicionActivo.Name = "lblCondicionActivo"
        Me.lblCondicionActivo.Size = New System.Drawing.Size(41, 13)
        Me.lblCondicionActivo.TabIndex = 2
        Me.lblCondicionActivo.Text = "*Activo"
        '
        'txtCondicionNombre
        '
        Me.txtCondicionNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCondicionNombre.Location = New System.Drawing.Point(71, 46)
        Me.txtCondicionNombre.Name = "txtCondicionNombre"
        Me.txtCondicionNombre.Size = New System.Drawing.Size(254, 20)
        Me.txtCondicionNombre.TabIndex = 1
        '
        'lblCondicionNombre
        '
        Me.lblCondicionNombre.AutoSize = True
        Me.lblCondicionNombre.Location = New System.Drawing.Point(17, 49)
        Me.lblCondicionNombre.Name = "lblCondicionNombre"
        Me.lblCondicionNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblCondicionNombre.TabIndex = 0
        Me.lblCondicionNombre.Text = "*Nombre"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(332, 241)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 20
        Me.lblLimpiar.Text = "Cerrar"
        '
        'pnlAltaDias
        '
        Me.pnlAltaDias.BackColor = System.Drawing.Color.White
        Me.pnlAltaDias.Controls.Add(Me.PictureBox1)
        Me.pnlAltaDias.Controls.Add(Me.lblEncabezado)
        Me.pnlAltaDias.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAltaDias.Location = New System.Drawing.Point(0, 0)
        Me.pnlAltaDias.Name = "pnlAltaDias"
        Me.pnlAltaDias.Size = New System.Drawing.Size(406, 60)
        Me.pnlAltaDias.TabIndex = 17
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(179, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(140, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Tipo de Politicas"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(267, 241)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 19
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarTipoPolitica
        '
        Me.btnCancelarTipoPolitica.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelarTipoPolitica.Location = New System.Drawing.Point(332, 205)
        Me.btnCancelarTipoPolitica.Name = "btnCancelarTipoPolitica"
        Me.btnCancelarTipoPolitica.Size = New System.Drawing.Size(32, 33)
        Me.btnCancelarTipoPolitica.TabIndex = 16
        Me.btnCancelarTipoPolitica.UseVisualStyleBackColor = True
        '
        'btnGuardarCondiciones
        '
        Me.btnGuardarCondiciones.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarCondiciones.Location = New System.Drawing.Point(272, 205)
        Me.btnGuardarCondiciones.Name = "btnGuardarCondiciones"
        Me.btnGuardarCondiciones.Size = New System.Drawing.Size(32, 33)
        Me.btnGuardarCondiciones.TabIndex = 15
        Me.btnGuardarCondiciones.UseVisualStyleBackColor = True
        '
        'grpCatalogoCondicion
        '
        Me.grpCatalogoCondicion.Controls.Add(Me.cboTipoPolitica)
        Me.grpCatalogoCondicion.Controls.Add(Me.cboCatalogoCondicion)
        Me.grpCatalogoCondicion.Controls.Add(Me.lblTipoPolitica)
        Me.grpCatalogoCondicion.Controls.Add(Me.lblCatalogoCondicion)
        Me.grpCatalogoCondicion.Controls.Add(Me.pnlCatalogoTipo)
        Me.grpCatalogoCondicion.Controls.Add(Me.lblCatalogoActivo)
        Me.grpCatalogoCondicion.Controls.Add(Me.txtDescripcionCatalogo)
        Me.grpCatalogoCondicion.Controls.Add(Me.lblCatalogoDescripcion)
        Me.grpCatalogoCondicion.Location = New System.Drawing.Point(33, 66)
        Me.grpCatalogoCondicion.Name = "grpCatalogoCondicion"
        Me.grpCatalogoCondicion.Size = New System.Drawing.Size(349, 135)
        Me.grpCatalogoCondicion.TabIndex = 47
        Me.grpCatalogoCondicion.TabStop = False
        Me.grpCatalogoCondicion.Visible = False
        '
        'cboTipoPolitica
        '
        Me.cboTipoPolitica.FormattingEnabled = True
        Me.cboTipoPolitica.Location = New System.Drawing.Point(76, 15)
        Me.cboTipoPolitica.Name = "cboTipoPolitica"
        Me.cboTipoPolitica.Size = New System.Drawing.Size(254, 21)
        Me.cboTipoPolitica.TabIndex = 11
        '
        'cboCatalogoCondicion
        '
        Me.cboCatalogoCondicion.FormattingEnabled = True
        Me.cboCatalogoCondicion.Location = New System.Drawing.Point(76, 42)
        Me.cboCatalogoCondicion.Name = "cboCatalogoCondicion"
        Me.cboCatalogoCondicion.Size = New System.Drawing.Size(254, 21)
        Me.cboCatalogoCondicion.TabIndex = 2
        '
        'lblTipoPolitica
        '
        Me.lblTipoPolitica.AutoSize = True
        Me.lblTipoPolitica.Location = New System.Drawing.Point(6, 18)
        Me.lblTipoPolitica.Name = "lblTipoPolitica"
        Me.lblTipoPolitica.Size = New System.Drawing.Size(32, 13)
        Me.lblTipoPolitica.TabIndex = 12
        Me.lblTipoPolitica.Text = "*Tipo"
        '
        'lblCatalogoCondicion
        '
        Me.lblCatalogoCondicion.AutoSize = True
        Me.lblCatalogoCondicion.Location = New System.Drawing.Point(6, 46)
        Me.lblCatalogoCondicion.Name = "lblCatalogoCondicion"
        Me.lblCatalogoCondicion.Size = New System.Drawing.Size(47, 13)
        Me.lblCatalogoCondicion.TabIndex = 10
        Me.lblCatalogoCondicion.Text = "*Política"
        '
        'pnlCatalogoTipo
        '
        Me.pnlCatalogoTipo.Controls.Add(Me.rdoCatalogoActivoNo)
        Me.pnlCatalogoTipo.Controls.Add(Me.rdoCatalogoActivoSi)
        Me.pnlCatalogoTipo.Location = New System.Drawing.Point(76, 96)
        Me.pnlCatalogoTipo.Name = "pnlCatalogoTipo"
        Me.pnlCatalogoTipo.Size = New System.Drawing.Size(84, 30)
        Me.pnlCatalogoTipo.TabIndex = 9
        '
        'rdoCatalogoActivoNo
        '
        Me.rdoCatalogoActivoNo.AutoSize = True
        Me.rdoCatalogoActivoNo.Location = New System.Drawing.Point(42, 9)
        Me.rdoCatalogoActivoNo.Name = "rdoCatalogoActivoNo"
        Me.rdoCatalogoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoCatalogoActivoNo.TabIndex = 4
        Me.rdoCatalogoActivoNo.Text = "No"
        Me.rdoCatalogoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoCatalogoActivoSi
        '
        Me.rdoCatalogoActivoSi.AutoSize = True
        Me.rdoCatalogoActivoSi.Checked = True
        Me.rdoCatalogoActivoSi.Location = New System.Drawing.Point(3, 9)
        Me.rdoCatalogoActivoSi.Name = "rdoCatalogoActivoSi"
        Me.rdoCatalogoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoCatalogoActivoSi.TabIndex = 3
        Me.rdoCatalogoActivoSi.TabStop = True
        Me.rdoCatalogoActivoSi.Text = "Si"
        Me.rdoCatalogoActivoSi.UseVisualStyleBackColor = True
        '
        'lblCatalogoActivo
        '
        Me.lblCatalogoActivo.AutoSize = True
        Me.lblCatalogoActivo.Location = New System.Drawing.Point(6, 108)
        Me.lblCatalogoActivo.Name = "lblCatalogoActivo"
        Me.lblCatalogoActivo.Size = New System.Drawing.Size(41, 13)
        Me.lblCatalogoActivo.TabIndex = 2
        Me.lblCatalogoActivo.Text = "*Activo"
        '
        'txtDescripcionCatalogo
        '
        Me.txtDescripcionCatalogo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionCatalogo.Location = New System.Drawing.Point(76, 69)
        Me.txtDescripcionCatalogo.Name = "txtDescripcionCatalogo"
        Me.txtDescripcionCatalogo.Size = New System.Drawing.Size(254, 20)
        Me.txtDescripcionCatalogo.TabIndex = 1
        '
        'lblCatalogoDescripcion
        '
        Me.lblCatalogoDescripcion.AutoSize = True
        Me.lblCatalogoDescripcion.Location = New System.Drawing.Point(6, 72)
        Me.lblCatalogoDescripcion.Name = "lblCatalogoDescripcion"
        Me.lblCatalogoDescripcion.Size = New System.Drawing.Size(67, 13)
        Me.lblCatalogoDescripcion.TabIndex = 0
        Me.lblCatalogoDescripcion.Text = "*Descripción"
        '
        'grpTipoCondicion
        '
        Me.grpTipoCondicion.Controls.Add(Me.pnlTipoActivo)
        Me.grpTipoCondicion.Controls.Add(Me.lblTipoActivo)
        Me.grpTipoCondicion.Controls.Add(Me.txtTipoNombre)
        Me.grpTipoCondicion.Controls.Add(Me.lblTipoNombre)
        Me.grpTipoCondicion.Location = New System.Drawing.Point(24, 77)
        Me.grpTipoCondicion.Name = "grpTipoCondicion"
        Me.grpTipoCondicion.Size = New System.Drawing.Size(349, 109)
        Me.grpTipoCondicion.TabIndex = 48
        Me.grpTipoCondicion.TabStop = False
        Me.grpTipoCondicion.Visible = False
        '
        'pnlTipoActivo
        '
        Me.pnlTipoActivo.Controls.Add(Me.rdoTipoActivoNo)
        Me.pnlTipoActivo.Controls.Add(Me.rdoTipoActivoSi)
        Me.pnlTipoActivo.Location = New System.Drawing.Point(68, 48)
        Me.pnlTipoActivo.Name = "pnlTipoActivo"
        Me.pnlTipoActivo.Size = New System.Drawing.Size(84, 30)
        Me.pnlTipoActivo.TabIndex = 11
        '
        'rdoTipoActivoNo
        '
        Me.rdoTipoActivoNo.AutoSize = True
        Me.rdoTipoActivoNo.Location = New System.Drawing.Point(42, 9)
        Me.rdoTipoActivoNo.Name = "rdoTipoActivoNo"
        Me.rdoTipoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoTipoActivoNo.TabIndex = 3
        Me.rdoTipoActivoNo.Text = "No"
        Me.rdoTipoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoTipoActivoSi
        '
        Me.rdoTipoActivoSi.AutoSize = True
        Me.rdoTipoActivoSi.Checked = True
        Me.rdoTipoActivoSi.Location = New System.Drawing.Point(3, 9)
        Me.rdoTipoActivoSi.Name = "rdoTipoActivoSi"
        Me.rdoTipoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoTipoActivoSi.TabIndex = 2
        Me.rdoTipoActivoSi.TabStop = True
        Me.rdoTipoActivoSi.Text = "Si"
        Me.rdoTipoActivoSi.UseVisualStyleBackColor = True
        '
        'lblTipoActivo
        '
        Me.lblTipoActivo.AutoSize = True
        Me.lblTipoActivo.Location = New System.Drawing.Point(13, 57)
        Me.lblTipoActivo.Name = "lblTipoActivo"
        Me.lblTipoActivo.Size = New System.Drawing.Size(41, 13)
        Me.lblTipoActivo.TabIndex = 10
        Me.lblTipoActivo.Text = "*Activo"
        '
        'txtTipoNombre
        '
        Me.txtTipoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoNombre.Location = New System.Drawing.Point(68, 19)
        Me.txtTipoNombre.Name = "txtTipoNombre"
        Me.txtTipoNombre.Size = New System.Drawing.Size(232, 20)
        Me.txtTipoNombre.TabIndex = 1
        '
        'lblTipoNombre
        '
        Me.lblTipoNombre.AutoSize = True
        Me.lblTipoNombre.Location = New System.Drawing.Point(13, 22)
        Me.lblTipoNombre.Name = "lblTipoNombre"
        Me.lblTipoNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblTipoNombre.TabIndex = 0
        Me.lblTipoNombre.Text = "*Nombre"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(338, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarCondicionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(406, 261)
        Me.Controls.Add(Me.grpCatalogoCondicion)
        Me.Controls.Add(Me.grpTipoCondicion)
        Me.Controls.Add(Me.grpCondicion)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.pnlAltaDias)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.btnCancelarTipoPolitica)
        Me.Controls.Add(Me.btnGuardarCondiciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(422, 300)
        Me.Name = "AgregarEditarCondicionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AgregarEditarCondicionesForm"
        Me.grpCondicion.ResumeLayout(False)
        Me.grpCondicion.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        Me.pnlAltaDias.ResumeLayout(False)
        Me.pnlAltaDias.PerformLayout()
        Me.grpCatalogoCondicion.ResumeLayout(False)
        Me.grpCatalogoCondicion.PerformLayout()
        Me.pnlCatalogoTipo.ResumeLayout(False)
        Me.pnlCatalogoTipo.PerformLayout()
        Me.grpTipoCondicion.ResumeLayout(False)
        Me.grpTipoCondicion.PerformLayout()
        Me.pnlTipoActivo.ResumeLayout(False)
        Me.pnlTipoActivo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpCondicion As System.Windows.Forms.GroupBox
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoCondicionActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCondicionActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblCondicionActivo As System.Windows.Forms.Label
    Friend WithEvents txtCondicionNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblCondicionNombre As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents pnlAltaDias As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarTipoPolitica As System.Windows.Forms.Button
    Friend WithEvents btnGuardarCondiciones As System.Windows.Forms.Button
    Friend WithEvents cboCondicionTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCondicionTipo As System.Windows.Forms.Label
    Friend WithEvents grpCatalogoCondicion As System.Windows.Forms.GroupBox
    Friend WithEvents cboCatalogoCondicion As System.Windows.Forms.ComboBox
    Friend WithEvents lblCatalogoCondicion As System.Windows.Forms.Label
    Friend WithEvents pnlCatalogoTipo As System.Windows.Forms.Panel
    Friend WithEvents rdoCatalogoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCatalogoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblCatalogoActivo As System.Windows.Forms.Label
    Friend WithEvents txtDescripcionCatalogo As System.Windows.Forms.TextBox
    Friend WithEvents lblCatalogoDescripcion As System.Windows.Forms.Label
    Friend WithEvents grpTipoCondicion As System.Windows.Forms.GroupBox
    Friend WithEvents pnlTipoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoTipoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTipoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblTipoActivo As System.Windows.Forms.Label
    Friend WithEvents txtTipoNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoNombre As System.Windows.Forms.Label
    Friend WithEvents cboTipoPolitica As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoPolitica As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
