<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarRutasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarRutasForm))
        Me.pnlAgregarEditarRutas = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.gpbRegistroDias = New System.Windows.Forms.GroupBox()
        Me.txtAgregarEditarRutasNombre = New System.Windows.Forms.TextBox()
        Me.lblAgregarEditarRutasNombre = New System.Windows.Forms.Label()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoAgregarEditarRutas = New System.Windows.Forms.Label()
        Me.btnCancelarRuta = New System.Windows.Forms.Button()
        Me.btnGuardarRuta = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlAgregarEditarRutas.SuspendLayout()
        Me.gpbRegistroDias.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlAgregarEditarRutas
        '
        Me.pnlAgregarEditarRutas.BackColor = System.Drawing.Color.White
        Me.pnlAgregarEditarRutas.Controls.Add(Me.PictureBox1)
        Me.pnlAgregarEditarRutas.Controls.Add(Me.lblEncabezado)
        Me.pnlAgregarEditarRutas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgregarEditarRutas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarEditarRutas.Name = "pnlAgregarEditarRutas"
        Me.pnlAgregarEditarRutas.Size = New System.Drawing.Size(450, 60)
        Me.pnlAgregarEditarRutas.TabIndex = 24
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(319, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(57, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Rutas"
        '
        'gpbRegistroDias
        '
        Me.gpbRegistroDias.Controls.Add(Me.txtAgregarEditarRutasNombre)
        Me.gpbRegistroDias.Controls.Add(Me.lblAgregarEditarRutasNombre)
        Me.gpbRegistroDias.Controls.Add(Me.pnlrdoActivo)
        Me.gpbRegistroDias.Controls.Add(Me.lblActivoAgregarEditarRutas)
        Me.gpbRegistroDias.Location = New System.Drawing.Point(14, 76)
        Me.gpbRegistroDias.Name = "gpbRegistroDias"
        Me.gpbRegistroDias.Size = New System.Drawing.Size(424, 92)
        Me.gpbRegistroDias.TabIndex = 26
        Me.gpbRegistroDias.TabStop = False
        '
        'txtAgregarEditarRutasNombre
        '
        Me.txtAgregarEditarRutasNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAgregarEditarRutasNombre.Location = New System.Drawing.Point(76, 19)
        Me.txtAgregarEditarRutasNombre.Name = "txtAgregarEditarRutasNombre"
        Me.txtAgregarEditarRutasNombre.Size = New System.Drawing.Size(322, 20)
        Me.txtAgregarEditarRutasNombre.TabIndex = 1
        '
        'lblAgregarEditarRutasNombre
        '
        Me.lblAgregarEditarRutasNombre.AutoSize = True
        Me.lblAgregarEditarRutasNombre.Location = New System.Drawing.Point(22, 22)
        Me.lblAgregarEditarRutasNombre.Name = "lblAgregarEditarRutasNombre"
        Me.lblAgregarEditarRutasNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblAgregarEditarRutasNombre.TabIndex = 10
        Me.lblAgregarEditarRutasNombre.Text = "*Nombre"
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(78, 48)
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
        'btnCancelarRuta
        '
        Me.btnCancelarRuta.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarRuta.Location = New System.Drawing.Point(368, 179)
        Me.btnCancelarRuta.Name = "btnCancelarRuta"
        Me.btnCancelarRuta.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarRuta.TabIndex = 23
        Me.btnCancelarRuta.UseVisualStyleBackColor = True
        '
        'btnGuardarRuta
        '
        Me.btnGuardarRuta.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarRuta.Location = New System.Drawing.Point(311, 179)
        Me.btnGuardarRuta.Name = "btnGuardarRuta"
        Me.btnGuardarRuta.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarRuta.TabIndex = 22
        Me.btnGuardarRuta.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(367, 215)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 28
        Me.lblLimpiar.Text = "Cerrar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(304, 215)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 27
        Me.lblBuscar.Text = "Guardar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(382, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarRutasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(450, 236)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.gpbRegistroDias)
        Me.Controls.Add(Me.btnCancelarRuta)
        Me.Controls.Add(Me.btnGuardarRuta)
        Me.Controls.Add(Me.pnlAgregarEditarRutas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(466, 275)
        Me.Name = "AgregarEditarRutasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rutas"
        Me.pnlAgregarEditarRutas.ResumeLayout(False)
        Me.pnlAgregarEditarRutas.PerformLayout()
        Me.gpbRegistroDias.ResumeLayout(False)
        Me.gpbRegistroDias.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelarRuta As System.Windows.Forms.Button
    Friend WithEvents btnGuardarRuta As System.Windows.Forms.Button
    Friend WithEvents pnlAgregarEditarRutas As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents gpbRegistroDias As System.Windows.Forms.GroupBox
    Friend WithEvents txtAgregarEditarRutasNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarEditarRutasNombre As System.Windows.Forms.Label
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoAgregarEditarRutas As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
