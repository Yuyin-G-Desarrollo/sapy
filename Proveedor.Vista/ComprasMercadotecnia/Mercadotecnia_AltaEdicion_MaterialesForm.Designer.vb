<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mercadotecnia_AltaEdicion_MaterialesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mercadotecnia_AltaEdicion_MaterialesForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtExistencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.cmbUMC = New System.Windows.Forms.ComboBox()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lblUMC = New System.Windows.Forms.Label()
        Me.txtMotivoFabricacion = New System.Windows.Forms.TextBox()
        Me.txtDescripcionMaterial = New System.Windows.Forms.TextBox()
        Me.txtNombreMaterial = New System.Windows.Forms.TextBox()
        Me.lblMotivoFabricacion = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnAbrirFoto = New System.Windows.Forms.Button()
        Me.lblFoto = New System.Windows.Forms.Label()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.ofdFoto = New System.Windows.Forms.OpenFileDialog()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 426)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 60)
        Me.Panel1.TabIndex = 70
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(554, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(145, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(139, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 5
        Me.lblGuardar.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 6)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(800, 54)
        Me.pnlHeader.TabIndex = 71
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(332, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(468, 54)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(123, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(271, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Alta y Edición de Materiales POP"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.btnAbrirFoto)
        Me.Panel2.Controls.Add(Me.lblFoto)
        Me.Panel2.Controls.Add(Me.picFoto)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 54)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 372)
        Me.Panel2.TabIndex = 72
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtExistencia)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtPrecio)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.rdoNo)
        Me.Panel3.Controls.Add(Me.rdoSi)
        Me.Panel3.Controls.Add(Me.cmbMarca)
        Me.Panel3.Controls.Add(Me.cmbUMC)
        Me.Panel3.Controls.Add(Me.lblMarca)
        Me.Panel3.Controls.Add(Me.lblUMC)
        Me.Panel3.Controls.Add(Me.txtMotivoFabricacion)
        Me.Panel3.Controls.Add(Me.txtDescripcionMaterial)
        Me.Panel3.Controls.Add(Me.txtNombreMaterial)
        Me.Panel3.Controls.Add(Me.lblMotivoFabricacion)
        Me.Panel3.Controls.Add(Me.lblDescripcion)
        Me.Panel3.Controls.Add(Me.lblNombre)
        Me.Panel3.Location = New System.Drawing.Point(12, 21)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(503, 333)
        Me.Panel3.TabIndex = 70
        '
        'txtExistencia
        '
        Me.txtExistencia.Location = New System.Drawing.Point(143, 213)
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.Size = New System.Drawing.Size(147, 20)
        Me.txtExistencia.TabIndex = 89
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 217)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Existencia :"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(143, 175)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(147, 20)
        Me.txtPrecio.TabIndex = 87
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Precio $ :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(347, 295)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Activo"
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(440, 293)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 82
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(400, 293)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 81
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'cmbMarca
        '
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(143, 291)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(147, 21)
        Me.cmbMarca.TabIndex = 62
        '
        'cmbUMC
        '
        Me.cmbUMC.FormattingEnabled = True
        Me.cmbUMC.Location = New System.Drawing.Point(143, 254)
        Me.cmbUMC.Name = "cmbUMC"
        Me.cmbUMC.Size = New System.Drawing.Size(147, 21)
        Me.cmbUMC.TabIndex = 61
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(18, 295)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(50, 13)
        Me.lblMarca.TabIndex = 60
        Me.lblMarca.Text = "Marca : *"
        '
        'lblUMC
        '
        Me.lblUMC.AutoSize = True
        Me.lblUMC.Location = New System.Drawing.Point(18, 258)
        Me.lblUMC.Name = "lblUMC"
        Me.lblUMC.Size = New System.Drawing.Size(44, 13)
        Me.lblUMC.TabIndex = 59
        Me.lblUMC.Text = "UMC : *"
        '
        'txtMotivoFabricacion
        '
        Me.txtMotivoFabricacion.Location = New System.Drawing.Point(143, 126)
        Me.txtMotivoFabricacion.Name = "txtMotivoFabricacion"
        Me.txtMotivoFabricacion.Size = New System.Drawing.Size(257, 20)
        Me.txtMotivoFabricacion.TabIndex = 56
        '
        'txtDescripcionMaterial
        '
        Me.txtDescripcionMaterial.Location = New System.Drawing.Point(143, 76)
        Me.txtDescripcionMaterial.Name = "txtDescripcionMaterial"
        Me.txtDescripcionMaterial.Size = New System.Drawing.Size(257, 20)
        Me.txtDescripcionMaterial.TabIndex = 53
        '
        'txtNombreMaterial
        '
        Me.txtNombreMaterial.Location = New System.Drawing.Point(143, 27)
        Me.txtNombreMaterial.Name = "txtNombreMaterial"
        Me.txtNombreMaterial.Size = New System.Drawing.Size(257, 20)
        Me.txtNombreMaterial.TabIndex = 52
        '
        'lblMotivoFabricacion
        '
        Me.lblMotivoFabricacion.AutoSize = True
        Me.lblMotivoFabricacion.Location = New System.Drawing.Point(18, 130)
        Me.lblMotivoFabricacion.Name = "lblMotivoFabricacion"
        Me.lblMotivoFabricacion.Size = New System.Drawing.Size(125, 13)
        Me.lblMotivoFabricacion.TabIndex = 51
        Me.lblMotivoFabricacion.Text = "Motivo de Fabricación : *"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(18, 80)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(76, 13)
        Me.lblDescripcion.TabIndex = 48
        Me.lblDescripcion.Text = "Descripción : *"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(18, 31)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(57, 13)
        Me.lblNombre.TabIndex = 47
        Me.lblNombre.Text = "Nombre : *"
        '
        'btnAbrirFoto
        '
        Me.btnAbrirFoto.Image = Global.Proveedor.Vista.My.Resources.Resources.colaboradorexpediente_32
        Me.btnAbrirFoto.Location = New System.Drawing.Point(646, 240)
        Me.btnAbrirFoto.Name = "btnAbrirFoto"
        Me.btnAbrirFoto.Size = New System.Drawing.Size(32, 32)
        Me.btnAbrirFoto.TabIndex = 68
        Me.btnAbrirFoto.UseVisualStyleBackColor = True
        '
        'lblFoto
        '
        Me.lblFoto.AutoSize = True
        Me.lblFoto.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFoto.Location = New System.Drawing.Point(634, 275)
        Me.lblFoto.Name = "lblFoto"
        Me.lblFoto.Size = New System.Drawing.Size(56, 13)
        Me.lblFoto.TabIndex = 69
        Me.lblFoto.Text = "Fotografía"
        '
        'picFoto
        '
        Me.picFoto.BackColor = System.Drawing.Color.White
        Me.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFoto.Location = New System.Drawing.Point(570, 53)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(186, 176)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 67
        Me.picFoto.TabStop = False
        '
        'ofdFoto
        '
        Me.ofdFoto.FileName = "ofdFoto"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(400, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 54)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'Mercadotecnia_AltaEdicion_MaterialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 486)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Mercadotecnia_AltaEdicion_MaterialesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta y Edición de Materiales POP"
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents bntSalir As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents picFoto As Windows.Forms.PictureBox
    Friend WithEvents btnAbrirFoto As Windows.Forms.Button
    Friend WithEvents lblFoto As Windows.Forms.Label
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents txtDescripcionMaterial As Windows.Forms.TextBox
    Friend WithEvents txtNombreMaterial As Windows.Forms.TextBox
    Friend WithEvents lblMotivoFabricacion As Windows.Forms.Label
    Friend WithEvents lblDescripcion As Windows.Forms.Label
    Friend WithEvents lblNombre As Windows.Forms.Label
    Friend WithEvents txtMotivoFabricacion As Windows.Forms.TextBox
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents rdoNo As Windows.Forms.RadioButton
    Friend WithEvents rdoSi As Windows.Forms.RadioButton
    Friend WithEvents cmbMarca As Windows.Forms.ComboBox
    Friend WithEvents cmbUMC As Windows.Forms.ComboBox
    Friend WithEvents lblMarca As Windows.Forms.Label
    Friend WithEvents lblUMC As Windows.Forms.Label
    Friend WithEvents ofdFoto As Windows.Forms.OpenFileDialog
    Friend WithEvents txtExistencia As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtPrecio As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
