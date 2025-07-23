<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarRequerimientosEspecialesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarRequerimientosEspecialesForm))
        Me.gpbRegistroRequerimientos = New System.Windows.Forms.GroupBox()
        Me.cboTipoRequerimiento = New System.Windows.Forms.ComboBox()
        Me.lblAgregarEditarTipoRequerimiento = New System.Windows.Forms.Label()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoRequerieminto = New System.Windows.Forms.Label()
        Me.TxtAgregarEditarNombreRequerimiento = New System.Windows.Forms.TextBox()
        Me.lblAgregarEditarNombreRequerimiento = New System.Windows.Forms.Label()
        Me.lblCancelarRequerimiento = New System.Windows.Forms.Label()
        Me.lblGuardarRequerimiento = New System.Windows.Forms.Label()
        Me.btnCancelarRequerimiento = New System.Windows.Forms.Button()
        Me.btnGuardarRequerimiento = New System.Windows.Forms.Button()
        Me.pnlAgregarEditarRequerimientos = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gpbRegistroRequerimientos.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        Me.pnlAgregarEditarRequerimientos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbRegistroRequerimientos
        '
        Me.gpbRegistroRequerimientos.Controls.Add(Me.cboTipoRequerimiento)
        Me.gpbRegistroRequerimientos.Controls.Add(Me.lblAgregarEditarTipoRequerimiento)
        Me.gpbRegistroRequerimientos.Controls.Add(Me.pnlrdoActivo)
        Me.gpbRegistroRequerimientos.Controls.Add(Me.lblActivoRequerieminto)
        Me.gpbRegistroRequerimientos.Controls.Add(Me.TxtAgregarEditarNombreRequerimiento)
        Me.gpbRegistroRequerimientos.Controls.Add(Me.lblAgregarEditarNombreRequerimiento)
        Me.gpbRegistroRequerimientos.Location = New System.Drawing.Point(34, 71)
        Me.gpbRegistroRequerimientos.Name = "gpbRegistroRequerimientos"
        Me.gpbRegistroRequerimientos.Size = New System.Drawing.Size(394, 120)
        Me.gpbRegistroRequerimientos.TabIndex = 21
        Me.gpbRegistroRequerimientos.TabStop = False
        '
        'cboTipoRequerimiento
        '
        Me.cboTipoRequerimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRequerimiento.FormattingEnabled = True
        Me.cboTipoRequerimiento.Location = New System.Drawing.Point(71, 21)
        Me.cboTipoRequerimiento.Name = "cboTipoRequerimiento"
        Me.cboTipoRequerimiento.Size = New System.Drawing.Size(305, 21)
        Me.cboTipoRequerimiento.TabIndex = 1
        '
        'lblAgregarEditarTipoRequerimiento
        '
        Me.lblAgregarEditarTipoRequerimiento.AutoSize = True
        Me.lblAgregarEditarTipoRequerimiento.Location = New System.Drawing.Point(17, 24)
        Me.lblAgregarEditarTipoRequerimiento.Name = "lblAgregarEditarTipoRequerimiento"
        Me.lblAgregarEditarTipoRequerimiento.Size = New System.Drawing.Size(32, 13)
        Me.lblAgregarEditarTipoRequerimiento.TabIndex = 10
        Me.lblAgregarEditarTipoRequerimiento.Text = "*Tipo"
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(71, 78)
        Me.pnlrdoActivo.Name = "pnlrdoActivo"
        Me.pnlrdoActivo.Size = New System.Drawing.Size(84, 30)
        Me.pnlrdoActivo.TabIndex = 9
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(42, 7)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 4
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(3, 7)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 3
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'lblActivoRequerieminto
        '
        Me.lblActivoRequerieminto.AutoSize = True
        Me.lblActivoRequerieminto.Location = New System.Drawing.Point(17, 87)
        Me.lblActivoRequerieminto.Name = "lblActivoRequerieminto"
        Me.lblActivoRequerieminto.Size = New System.Drawing.Size(41, 13)
        Me.lblActivoRequerieminto.TabIndex = 2
        Me.lblActivoRequerieminto.Text = "*Activo"
        '
        'TxtAgregarEditarNombreRequerimiento
        '
        Me.TxtAgregarEditarNombreRequerimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAgregarEditarNombreRequerimiento.Location = New System.Drawing.Point(71, 52)
        Me.TxtAgregarEditarNombreRequerimiento.Name = "TxtAgregarEditarNombreRequerimiento"
        Me.TxtAgregarEditarNombreRequerimiento.Size = New System.Drawing.Size(305, 20)
        Me.TxtAgregarEditarNombreRequerimiento.TabIndex = 2
        '
        'lblAgregarEditarNombreRequerimiento
        '
        Me.lblAgregarEditarNombreRequerimiento.AutoSize = True
        Me.lblAgregarEditarNombreRequerimiento.Location = New System.Drawing.Point(17, 55)
        Me.lblAgregarEditarNombreRequerimiento.Name = "lblAgregarEditarNombreRequerimiento"
        Me.lblAgregarEditarNombreRequerimiento.Size = New System.Drawing.Size(48, 13)
        Me.lblAgregarEditarNombreRequerimiento.TabIndex = 0
        Me.lblAgregarEditarNombreRequerimiento.Text = "*Nombre"
        '
        'lblCancelarRequerimiento
        '
        Me.lblCancelarRequerimiento.AutoSize = True
        Me.lblCancelarRequerimiento.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarRequerimiento.Location = New System.Drawing.Point(378, 232)
        Me.lblCancelarRequerimiento.Name = "lblCancelarRequerimiento"
        Me.lblCancelarRequerimiento.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelarRequerimiento.TabIndex = 25
        Me.lblCancelarRequerimiento.Text = "Cerrar"
        '
        'lblGuardarRequerimiento
        '
        Me.lblGuardarRequerimiento.AutoSize = True
        Me.lblGuardarRequerimiento.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarRequerimiento.Location = New System.Drawing.Point(318, 232)
        Me.lblGuardarRequerimiento.Name = "lblGuardarRequerimiento"
        Me.lblGuardarRequerimiento.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarRequerimiento.TabIndex = 24
        Me.lblGuardarRequerimiento.Text = "Guardar"
        '
        'btnCancelarRequerimiento
        '
        Me.btnCancelarRequerimiento.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarRequerimiento.Location = New System.Drawing.Point(378, 197)
        Me.btnCancelarRequerimiento.Name = "btnCancelarRequerimiento"
        Me.btnCancelarRequerimiento.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarRequerimiento.TabIndex = 23
        Me.btnCancelarRequerimiento.UseVisualStyleBackColor = True
        '
        'btnGuardarRequerimiento
        '
        Me.btnGuardarRequerimiento.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarRequerimiento.Location = New System.Drawing.Point(321, 197)
        Me.btnGuardarRequerimiento.Name = "btnGuardarRequerimiento"
        Me.btnGuardarRequerimiento.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarRequerimiento.TabIndex = 22
        Me.btnGuardarRequerimiento.UseVisualStyleBackColor = True
        '
        'pnlAgregarEditarRequerimientos
        '
        Me.pnlAgregarEditarRequerimientos.BackColor = System.Drawing.Color.White
        Me.pnlAgregarEditarRequerimientos.Controls.Add(Me.PictureBox1)
        Me.pnlAgregarEditarRequerimientos.Controls.Add(Me.lblEncabezado)
        Me.pnlAgregarEditarRequerimientos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgregarEditarRequerimientos.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarEditarRequerimientos.Name = "pnlAgregarEditarRequerimientos"
        Me.pnlAgregarEditarRequerimientos.Size = New System.Drawing.Size(459, 60)
        Me.pnlAgregarEditarRequerimientos.TabIndex = 20
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(160, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(225, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Requerimientos especiales"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(391, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarRequerimientosEspecialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(459, 255)
        Me.Controls.Add(Me.gpbRegistroRequerimientos)
        Me.Controls.Add(Me.lblCancelarRequerimiento)
        Me.Controls.Add(Me.lblGuardarRequerimiento)
        Me.Controls.Add(Me.btnCancelarRequerimiento)
        Me.Controls.Add(Me.btnGuardarRequerimiento)
        Me.Controls.Add(Me.pnlAgregarEditarRequerimientos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(475, 294)
        Me.Name = "AgregarEditarRequerimientosEspecialesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Requerimientos especiales"
        Me.gpbRegistroRequerimientos.ResumeLayout(False)
        Me.gpbRegistroRequerimientos.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        Me.pnlAgregarEditarRequerimientos.ResumeLayout(False)
        Me.pnlAgregarEditarRequerimientos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpbRegistroRequerimientos As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoRequerimiento As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgregarEditarTipoRequerimiento As System.Windows.Forms.Label
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoRequerieminto As System.Windows.Forms.Label
    Friend WithEvents TxtAgregarEditarNombreRequerimiento As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarEditarNombreRequerimiento As System.Windows.Forms.Label
    Friend WithEvents lblCancelarRequerimiento As System.Windows.Forms.Label
    Friend WithEvents lblGuardarRequerimiento As System.Windows.Forms.Label
    Friend WithEvents btnCancelarRequerimiento As System.Windows.Forms.Button
    Friend WithEvents btnGuardarRequerimiento As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarEditarRequerimientos As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
