<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarClasificacionClienteForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarClasificacionClienteForm))
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.groRegistroDias = New System.Windows.Forms.GroupBox()
        Me.txtIDAgregarEditarClasificacionCliente = New System.Windows.Forms.TextBox()
        Me.lblIDAgregarEditarClasificacionCliente = New System.Windows.Forms.Label()
        Me.txtNombreAgregarEditarClasificacionCliente = New System.Windows.Forms.TextBox()
        Me.lblNombreAgregarEditarClasificacionCliente = New System.Windows.Forms.Label()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoAgregarEditarClasificacionCliente = New System.Windows.Forms.Label()
        Me.btnGuardarRuta = New System.Windows.Forms.Button()
        Me.pnlAgregarEditarRutas = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.btnCancelarRuta = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.groRegistroDias.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        Me.pnlAgregarEditarRutas.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(401, 245)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 34
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(338, 244)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 33
        Me.lblGuardar.Text = "Guardar"
        '
        'groRegistroDias
        '
        Me.groRegistroDias.Controls.Add(Me.txtIDAgregarEditarClasificacionCliente)
        Me.groRegistroDias.Controls.Add(Me.lblIDAgregarEditarClasificacionCliente)
        Me.groRegistroDias.Controls.Add(Me.txtNombreAgregarEditarClasificacionCliente)
        Me.groRegistroDias.Controls.Add(Me.lblNombreAgregarEditarClasificacionCliente)
        Me.groRegistroDias.Controls.Add(Me.pnlrdoActivo)
        Me.groRegistroDias.Controls.Add(Me.lblActivoAgregarEditarClasificacionCliente)
        Me.groRegistroDias.Location = New System.Drawing.Point(23, 75)
        Me.groRegistroDias.Name = "groRegistroDias"
        Me.groRegistroDias.Size = New System.Drawing.Size(424, 121)
        Me.groRegistroDias.TabIndex = 32
        Me.groRegistroDias.TabStop = False
        '
        'txtIDAgregarEditarClasificacionCliente
        '
        Me.txtIDAgregarEditarClasificacionCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIDAgregarEditarClasificacionCliente.Location = New System.Drawing.Point(86, 20)
        Me.txtIDAgregarEditarClasificacionCliente.Name = "txtIDAgregarEditarClasificacionCliente"
        Me.txtIDAgregarEditarClasificacionCliente.Size = New System.Drawing.Size(303, 20)
        Me.txtIDAgregarEditarClasificacionCliente.TabIndex = 1
        '
        'lblIDAgregarEditarClasificacionCliente
        '
        Me.lblIDAgregarEditarClasificacionCliente.AutoSize = True
        Me.lblIDAgregarEditarClasificacionCliente.Location = New System.Drawing.Point(29, 20)
        Me.lblIDAgregarEditarClasificacionCliente.Name = "lblIDAgregarEditarClasificacionCliente"
        Me.lblIDAgregarEditarClasificacionCliente.Size = New System.Drawing.Size(22, 13)
        Me.lblIDAgregarEditarClasificacionCliente.TabIndex = 12
        Me.lblIDAgregarEditarClasificacionCliente.Text = "*ID"
        '
        'txtNombreAgregarEditarClasificacionCliente
        '
        Me.txtNombreAgregarEditarClasificacionCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreAgregarEditarClasificacionCliente.Location = New System.Drawing.Point(86, 49)
        Me.txtNombreAgregarEditarClasificacionCliente.Name = "txtNombreAgregarEditarClasificacionCliente"
        Me.txtNombreAgregarEditarClasificacionCliente.Size = New System.Drawing.Size(303, 20)
        Me.txtNombreAgregarEditarClasificacionCliente.TabIndex = 2
        '
        'lblNombreAgregarEditarClasificacionCliente
        '
        Me.lblNombreAgregarEditarClasificacionCliente.AutoSize = True
        Me.lblNombreAgregarEditarClasificacionCliente.Location = New System.Drawing.Point(29, 52)
        Me.lblNombreAgregarEditarClasificacionCliente.Name = "lblNombreAgregarEditarClasificacionCliente"
        Me.lblNombreAgregarEditarClasificacionCliente.Size = New System.Drawing.Size(48, 13)
        Me.lblNombreAgregarEditarClasificacionCliente.TabIndex = 10
        Me.lblNombreAgregarEditarClasificacionCliente.Text = "*Nombre"
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(83, 79)
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
        'lblActivoAgregarEditarClasificacionCliente
        '
        Me.lblActivoAgregarEditarClasificacionCliente.AutoSize = True
        Me.lblActivoAgregarEditarClasificacionCliente.Location = New System.Drawing.Point(29, 86)
        Me.lblActivoAgregarEditarClasificacionCliente.Name = "lblActivoAgregarEditarClasificacionCliente"
        Me.lblActivoAgregarEditarClasificacionCliente.Size = New System.Drawing.Size(41, 13)
        Me.lblActivoAgregarEditarClasificacionCliente.TabIndex = 2
        Me.lblActivoAgregarEditarClasificacionCliente.Text = "*Activo"
        '
        'btnGuardarRuta
        '
        Me.btnGuardarRuta.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarRuta.Location = New System.Drawing.Point(345, 208)
        Me.btnGuardarRuta.Name = "btnGuardarRuta"
        Me.btnGuardarRuta.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarRuta.TabIndex = 5
        Me.btnGuardarRuta.UseVisualStyleBackColor = True
        '
        'pnlAgregarEditarRutas
        '
        Me.pnlAgregarEditarRutas.BackColor = System.Drawing.Color.White
        Me.pnlAgregarEditarRutas.Controls.Add(Me.PictureBox1)
        Me.pnlAgregarEditarRutas.Controls.Add(Me.lblEncabezado)
        Me.pnlAgregarEditarRutas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgregarEditarRutas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarEditarRutas.Name = "pnlAgregarEditarRutas"
        Me.pnlAgregarEditarRutas.Size = New System.Drawing.Size(468, 60)
        Me.pnlAgregarEditarRutas.TabIndex = 31
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(198, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(196, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Clasificación de Cliente"
        '
        'btnCancelarRuta
        '
        Me.btnCancelarRuta.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarRuta.Location = New System.Drawing.Point(404, 208)
        Me.btnCancelarRuta.Name = "btnCancelarRuta"
        Me.btnCancelarRuta.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarRuta.TabIndex = 6
        Me.btnCancelarRuta.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(400, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarClasificacionClienteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(468, 267)
        Me.Controls.Add(Me.lblCerrar)
        Me.Controls.Add(Me.lblGuardar)
        Me.Controls.Add(Me.groRegistroDias)
        Me.Controls.Add(Me.btnCancelarRuta)
        Me.Controls.Add(Me.btnGuardarRuta)
        Me.Controls.Add(Me.pnlAgregarEditarRutas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(484, 306)
        Me.Name = "AgregarEditarClasificacionClienteForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clasificación de Cliente"
        Me.groRegistroDias.ResumeLayout(False)
        Me.groRegistroDias.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        Me.pnlAgregarEditarRutas.ResumeLayout(False)
        Me.pnlAgregarEditarRutas.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents groRegistroDias As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardarRuta As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarEditarRutas As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents txtIDAgregarEditarClasificacionCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblIDAgregarEditarClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents txtNombreAgregarEditarClasificacionCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreAgregarEditarClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoAgregarEditarClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents btnCancelarRuta As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
