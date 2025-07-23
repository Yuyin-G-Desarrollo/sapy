<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarTiposDeTiendaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarTiposDeTiendaForm))
        Me.lblCerrarVentana = New System.Windows.Forms.Label()
        Me.lblGuardarTipoTienda = New System.Windows.Forms.Label()
        Me.gpbActualizarModificarTipoTienda = New System.Windows.Forms.GroupBox()
        Me.txtAgregarEditarTipoTiendaNombre = New System.Windows.Forms.TextBox()
        Me.lblAgregarEditarTipoTiendaNombre = New System.Windows.Forms.Label()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoAgregarEditarRutas = New System.Windows.Forms.Label()
        Me.pnlAgregarEditarRutas = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.btnCancelarTipoTienda = New System.Windows.Forms.Button()
        Me.btnGuardarTipoTienda = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gpbActualizarModificarTipoTienda.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        Me.pnlAgregarEditarRutas.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCerrarVentana
        '
        Me.lblCerrarVentana.AutoSize = True
        Me.lblCerrarVentana.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrarVentana.Location = New System.Drawing.Point(368, 218)
        Me.lblCerrarVentana.Name = "lblCerrarVentana"
        Me.lblCerrarVentana.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrarVentana.TabIndex = 34
        Me.lblCerrarVentana.Text = "Cerrar"
        '
        'lblGuardarTipoTienda
        '
        Me.lblGuardarTipoTienda.AutoSize = True
        Me.lblGuardarTipoTienda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarTipoTienda.Location = New System.Drawing.Point(305, 218)
        Me.lblGuardarTipoTienda.Name = "lblGuardarTipoTienda"
        Me.lblGuardarTipoTienda.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarTipoTienda.TabIndex = 33
        Me.lblGuardarTipoTienda.Text = "Guardar"
        '
        'gpbActualizarModificarTipoTienda
        '
        Me.gpbActualizarModificarTipoTienda.Controls.Add(Me.txtAgregarEditarTipoTiendaNombre)
        Me.gpbActualizarModificarTipoTienda.Controls.Add(Me.lblAgregarEditarTipoTiendaNombre)
        Me.gpbActualizarModificarTipoTienda.Controls.Add(Me.pnlrdoActivo)
        Me.gpbActualizarModificarTipoTienda.Controls.Add(Me.lblActivoAgregarEditarRutas)
        Me.gpbActualizarModificarTipoTienda.Location = New System.Drawing.Point(14, 77)
        Me.gpbActualizarModificarTipoTienda.Name = "gpbActualizarModificarTipoTienda"
        Me.gpbActualizarModificarTipoTienda.Size = New System.Drawing.Size(424, 92)
        Me.gpbActualizarModificarTipoTienda.TabIndex = 32
        Me.gpbActualizarModificarTipoTienda.TabStop = False
        '
        'txtAgregarEditarTipoTiendaNombre
        '
        Me.txtAgregarEditarTipoTiendaNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAgregarEditarTipoTiendaNombre.Location = New System.Drawing.Point(76, 19)
        Me.txtAgregarEditarTipoTiendaNombre.Name = "txtAgregarEditarTipoTiendaNombre"
        Me.txtAgregarEditarTipoTiendaNombre.Size = New System.Drawing.Size(321, 20)
        Me.txtAgregarEditarTipoTiendaNombre.TabIndex = 1
        '
        'lblAgregarEditarTipoTiendaNombre
        '
        Me.lblAgregarEditarTipoTiendaNombre.AutoSize = True
        Me.lblAgregarEditarTipoTiendaNombre.Location = New System.Drawing.Point(22, 22)
        Me.lblAgregarEditarTipoTiendaNombre.Name = "lblAgregarEditarTipoTiendaNombre"
        Me.lblAgregarEditarTipoTiendaNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblAgregarEditarTipoTiendaNombre.TabIndex = 10
        Me.lblAgregarEditarTipoTiendaNombre.Text = "*Nombre"
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(76, 48)
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
        'lblActivoAgregarEditarRutas
        '
        Me.lblActivoAgregarEditarRutas.AutoSize = True
        Me.lblActivoAgregarEditarRutas.Location = New System.Drawing.Point(22, 57)
        Me.lblActivoAgregarEditarRutas.Name = "lblActivoAgregarEditarRutas"
        Me.lblActivoAgregarEditarRutas.Size = New System.Drawing.Size(41, 13)
        Me.lblActivoAgregarEditarRutas.TabIndex = 2
        Me.lblActivoAgregarEditarRutas.Text = "*Activo"
        '
        'pnlAgregarEditarRutas
        '
        Me.pnlAgregarEditarRutas.BackColor = System.Drawing.Color.White
        Me.pnlAgregarEditarRutas.Controls.Add(Me.PictureBox1)
        Me.pnlAgregarEditarRutas.Controls.Add(Me.lblEncabezado)
        Me.pnlAgregarEditarRutas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgregarEditarRutas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarEditarRutas.Name = "pnlAgregarEditarRutas"
        Me.pnlAgregarEditarRutas.Size = New System.Drawing.Size(458, 60)
        Me.pnlAgregarEditarRutas.TabIndex = 31
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(252, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(136, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Tipos de Tienda"
        '
        'btnCancelarTipoTienda
        '
        Me.btnCancelarTipoTienda.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarTipoTienda.Location = New System.Drawing.Point(369, 182)
        Me.btnCancelarTipoTienda.Name = "btnCancelarTipoTienda"
        Me.btnCancelarTipoTienda.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarTipoTienda.TabIndex = 6
        Me.btnCancelarTipoTienda.UseVisualStyleBackColor = True
        '
        'btnGuardarTipoTienda
        '
        Me.btnGuardarTipoTienda.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarTipoTienda.Location = New System.Drawing.Point(312, 182)
        Me.btnGuardarTipoTienda.Name = "btnGuardarTipoTienda"
        Me.btnGuardarTipoTienda.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarTipoTienda.TabIndex = 5
        Me.btnGuardarTipoTienda.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(390, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarTiposDeTiendaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(458, 240)
        Me.Controls.Add(Me.lblCerrarVentana)
        Me.Controls.Add(Me.lblGuardarTipoTienda)
        Me.Controls.Add(Me.gpbActualizarModificarTipoTienda)
        Me.Controls.Add(Me.btnCancelarTipoTienda)
        Me.Controls.Add(Me.btnGuardarTipoTienda)
        Me.Controls.Add(Me.pnlAgregarEditarRutas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(474, 279)
        Me.Name = "AgregarEditarTiposDeTiendaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipos de Tienda"
        Me.gpbActualizarModificarTipoTienda.ResumeLayout(False)
        Me.gpbActualizarModificarTipoTienda.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        Me.pnlAgregarEditarRutas.ResumeLayout(False)
        Me.pnlAgregarEditarRutas.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCerrarVentana As System.Windows.Forms.Label
    Friend WithEvents lblGuardarTipoTienda As System.Windows.Forms.Label
    Friend WithEvents gpbActualizarModificarTipoTienda As System.Windows.Forms.GroupBox
    Friend WithEvents txtAgregarEditarTipoTiendaNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarEditarTipoTiendaNombre As System.Windows.Forms.Label
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoAgregarEditarRutas As System.Windows.Forms.Label
    Friend WithEvents btnCancelarTipoTienda As System.Windows.Forms.Button
    Friend WithEvents btnGuardarTipoTienda As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarEditarRutas As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
