<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaEdicionMaquinariaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaEdicionMaquinariaForm))
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblFechaAutorizacion = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.lblIdMaquinaria = New System.Windows.Forms.Label()
        Me.txtIDMaquinaria = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblMaquinaria = New System.Windows.Forms.Label()
        Me.txtMaquinaria = New System.Windows.Forms.TextBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLimipar = New System.Windows.Forms.Button()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlInferior.Location = New System.Drawing.Point(0, 169)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(492, 54)
        Me.pnlInferior.TabIndex = 2018
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(381, 38)
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
        Me.lblSalir.Location = New System.Drawing.Point(444, 40)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(444, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Image = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(387, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Label5)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Controls.Add(Me.lblFechaAutorizacion)
        Me.pnlEncabezado.Controls.Add(Me.lbl)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(492, 63)
        Me.pnlEncabezado.TabIndex = 2017
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(-450, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 16)
        Me.Label5.TabIndex = 232
        Me.Label5.Text = "VENTANA NO FUNCIONAL"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(198, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(223, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Alta/Edición de Maquinaria"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(424, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblFechaAutorizacion
        '
        Me.lblFechaAutorizacion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFechaAutorizacion.AutoSize = True
        Me.lblFechaAutorizacion.Location = New System.Drawing.Point(-108, 18)
        Me.lblFechaAutorizacion.Name = "lblFechaAutorizacion"
        Me.lblFechaAutorizacion.Size = New System.Drawing.Size(112, 13)
        Me.lblFechaAutorizacion.TabIndex = 228
        Me.lblFechaAutorizacion.Text = "Fecha de autorización"
        Me.lblFechaAutorizacion.Visible = False
        '
        'lbl
        '
        Me.lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(-42, 17)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(42, 13)
        Me.lbl.TabIndex = 229
        Me.lbl.Text = "Estatus"
        Me.lbl.Visible = False
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(354, 87)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 3
        Me.rdoNo.TabStop = True
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(314, 87)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 2
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'lblIdMaquinaria
        '
        Me.lblIdMaquinaria.AutoSize = True
        Me.lblIdMaquinaria.Location = New System.Drawing.Point(73, 91)
        Me.lblIdMaquinaria.Name = "lblIdMaquinaria"
        Me.lblIdMaquinaria.Size = New System.Drawing.Size(18, 13)
        Me.lblIdMaquinaria.TabIndex = 2040
        Me.lblIdMaquinaria.Text = "ID"
        '
        'txtIDMaquinaria
        '
        Me.txtIDMaquinaria.Enabled = False
        Me.txtIDMaquinaria.Location = New System.Drawing.Point(166, 88)
        Me.txtIDMaquinaria.Name = "txtIDMaquinaria"
        Me.txtIDMaquinaria.Size = New System.Drawing.Size(59, 20)
        Me.txtIDMaquinaria.TabIndex = 6
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(166, 88)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(59, 20)
        Me.txtID.TabIndex = 2039
        '
        'lblMaquinaria
        '
        Me.lblMaquinaria.AutoSize = True
        Me.lblMaquinaria.Location = New System.Drawing.Point(73, 113)
        Me.lblMaquinaria.Name = "lblMaquinaria"
        Me.lblMaquinaria.Size = New System.Drawing.Size(63, 13)
        Me.lblMaquinaria.TabIndex = 2038
        Me.lblMaquinaria.Text = "*Maquinaria"
        '
        'txtMaquinaria
        '
        Me.txtMaquinaria.Location = New System.Drawing.Point(166, 113)
        Me.txtMaquinaria.Name = "txtMaquinaria"
        Me.txtMaquinaria.Size = New System.Drawing.Size(227, 20)
        Me.txtMaquinaria.TabIndex = 1
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(273, 89)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 2042
        Me.lblActivo.Text = "Activo"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(412, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2044
        Me.Label1.Text = "Limpiar"
        Me.Label1.Visible = False
        '
        'btnLimipar
        '
        Me.btnLimipar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimipar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimipar.Location = New System.Drawing.Point(416, 83)
        Me.btnLimipar.Name = "btnLimipar"
        Me.btnLimipar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimipar.TabIndex = 2043
        Me.btnLimipar.UseVisualStyleBackColor = True
        Me.btnLimipar.Visible = False
        '
        'AltaEdicionMaquinariaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(492, 223)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLimipar)
        Me.Controls.Add(Me.lblActivo)
        Me.Controls.Add(Me.rdoNo)
        Me.Controls.Add(Me.rdoSi)
        Me.Controls.Add(Me.lblIdMaquinaria)
        Me.Controls.Add(Me.txtIDMaquinaria)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblMaquinaria)
        Me.Controls.Add(Me.txtMaquinaria)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(500, 250)
        Me.MinimumSize = New System.Drawing.Size(500, 250)
        Me.Name = "AltaEdicionMaquinariaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta/Edición de Maquinaria"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblFechaAutorizacion As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblIdMaquinaria As System.Windows.Forms.Label
    Friend WithEvents txtIDMaquinaria As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblMaquinaria As System.Windows.Forms.Label
    Friend WithEvents txtMaquinaria As System.Windows.Forms.TextBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLimipar As System.Windows.Forms.Button
End Class
