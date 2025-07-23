<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarMaterialesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarMaterialesForm))
        Me.pnlAgregarEditarMateriales = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.gpbRegistroDias = New System.Windows.Forms.GroupBox()
        Me.cboMaterialesMercadotecniaTipo = New System.Windows.Forms.ComboBox()
        Me.lblAgregarEditarMaterialesTipo = New System.Windows.Forms.Label()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoDiaAlta = New System.Windows.Forms.Label()
        Me.TxtAgregarEditarMaterialesNombre = New System.Windows.Forms.TextBox()
        Me.lblAgregarEditarMaterialesNombre = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarMaterial = New System.Windows.Forms.Button()
        Me.btnGuardarDia = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlAgregarEditarMateriales.SuspendLayout()
        Me.gpbRegistroDias.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlAgregarEditarMateriales
        '
        Me.pnlAgregarEditarMateriales.BackColor = System.Drawing.Color.White
        Me.pnlAgregarEditarMateriales.Controls.Add(Me.PictureBox1)
        Me.pnlAgregarEditarMateriales.Controls.Add(Me.lblEncabezado)
        Me.pnlAgregarEditarMateriales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAgregarEditarMateriales.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgregarEditarMateriales.Name = "pnlAgregarEditarMateriales"
        Me.pnlAgregarEditarMateriales.Size = New System.Drawing.Size(469, 60)
        Me.pnlAgregarEditarMateriales.TabIndex = 13
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(180, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(215, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Materiales Mercadotecnia"
        '
        'gpbRegistroDias
        '
        Me.gpbRegistroDias.Controls.Add(Me.cboMaterialesMercadotecniaTipo)
        Me.gpbRegistroDias.Controls.Add(Me.lblAgregarEditarMaterialesTipo)
        Me.gpbRegistroDias.Controls.Add(Me.pnlrdoActivo)
        Me.gpbRegistroDias.Controls.Add(Me.lblActivoDiaAlta)
        Me.gpbRegistroDias.Controls.Add(Me.TxtAgregarEditarMaterialesNombre)
        Me.gpbRegistroDias.Controls.Add(Me.lblAgregarEditarMaterialesNombre)
        Me.gpbRegistroDias.Location = New System.Drawing.Point(37, 78)
        Me.gpbRegistroDias.Name = "gpbRegistroDias"
        Me.gpbRegistroDias.Size = New System.Drawing.Size(394, 120)
        Me.gpbRegistroDias.TabIndex = 15
        Me.gpbRegistroDias.TabStop = False
        '
        'cboMaterialesMercadotecniaTipo
        '
        Me.cboMaterialesMercadotecniaTipo.FormattingEnabled = True
        Me.cboMaterialesMercadotecniaTipo.Location = New System.Drawing.Point(74, 21)
        Me.cboMaterialesMercadotecniaTipo.Name = "cboMaterialesMercadotecniaTipo"
        Me.cboMaterialesMercadotecniaTipo.Size = New System.Drawing.Size(305, 21)
        Me.cboMaterialesMercadotecniaTipo.TabIndex = 1
        '
        'lblAgregarEditarMaterialesTipo
        '
        Me.lblAgregarEditarMaterialesTipo.AutoSize = True
        Me.lblAgregarEditarMaterialesTipo.Location = New System.Drawing.Point(16, 24)
        Me.lblAgregarEditarMaterialesTipo.Name = "lblAgregarEditarMaterialesTipo"
        Me.lblAgregarEditarMaterialesTipo.Size = New System.Drawing.Size(32, 13)
        Me.lblAgregarEditarMaterialesTipo.TabIndex = 10
        Me.lblAgregarEditarMaterialesTipo.Text = "*Tipo"
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(74, 78)
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
        'lblActivoDiaAlta
        '
        Me.lblActivoDiaAlta.AutoSize = True
        Me.lblActivoDiaAlta.Location = New System.Drawing.Point(16, 87)
        Me.lblActivoDiaAlta.Name = "lblActivoDiaAlta"
        Me.lblActivoDiaAlta.Size = New System.Drawing.Size(41, 13)
        Me.lblActivoDiaAlta.TabIndex = 2
        Me.lblActivoDiaAlta.Text = "*Activo"
        '
        'TxtAgregarEditarMaterialesNombre
        '
        Me.TxtAgregarEditarMaterialesNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAgregarEditarMaterialesNombre.Location = New System.Drawing.Point(74, 52)
        Me.TxtAgregarEditarMaterialesNombre.Name = "TxtAgregarEditarMaterialesNombre"
        Me.TxtAgregarEditarMaterialesNombre.Size = New System.Drawing.Size(305, 20)
        Me.TxtAgregarEditarMaterialesNombre.TabIndex = 2
        '
        'lblAgregarEditarMaterialesNombre
        '
        Me.lblAgregarEditarMaterialesNombre.AutoSize = True
        Me.lblAgregarEditarMaterialesNombre.Location = New System.Drawing.Point(16, 55)
        Me.lblAgregarEditarMaterialesNombre.Name = "lblAgregarEditarMaterialesNombre"
        Me.lblAgregarEditarMaterialesNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblAgregarEditarMaterialesNombre.TabIndex = 0
        Me.lblAgregarEditarMaterialesNombre.Text = "*Nombre"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(381, 239)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 19
        Me.lblLimpiar.Text = "Cerrar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(321, 239)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 18
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarMaterial
        '
        Me.btnCancelarMaterial.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarMaterial.Location = New System.Drawing.Point(381, 204)
        Me.btnCancelarMaterial.Name = "btnCancelarMaterial"
        Me.btnCancelarMaterial.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarMaterial.TabIndex = 17
        Me.btnCancelarMaterial.UseVisualStyleBackColor = True
        '
        'btnGuardarDia
        '
        Me.btnGuardarDia.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarDia.Location = New System.Drawing.Point(324, 204)
        Me.btnGuardarDia.Name = "btnGuardarDia"
        Me.btnGuardarDia.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarDia.TabIndex = 16
        Me.btnGuardarDia.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(401, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarMaterialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(469, 261)
        Me.Controls.Add(Me.gpbRegistroDias)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.btnCancelarMaterial)
        Me.Controls.Add(Me.btnGuardarDia)
        Me.Controls.Add(Me.pnlAgregarEditarMateriales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(485, 300)
        Me.Name = "AgregarEditarMaterialesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Materiales Mercadotecnia"
        Me.pnlAgregarEditarMateriales.ResumeLayout(False)
        Me.pnlAgregarEditarMateriales.PerformLayout()
        Me.gpbRegistroDias.ResumeLayout(False)
        Me.gpbRegistroDias.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlAgregarEditarMateriales As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents gpbRegistroDias As System.Windows.Forms.GroupBox
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoDiaAlta As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarMaterial As System.Windows.Forms.Button
    Friend WithEvents btnGuardarDia As System.Windows.Forms.Button
    Friend WithEvents lblAgregarEditarMaterialesTipo As System.Windows.Forms.Label
    Friend WithEvents TxtAgregarEditarMaterialesNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarEditarMaterialesNombre As System.Windows.Forms.Label
    Friend WithEvents cboMaterialesMercadotecniaTipo As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
