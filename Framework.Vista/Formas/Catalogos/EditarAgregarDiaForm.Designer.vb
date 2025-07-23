<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarAgregarDiaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarAgregarDiaForm))
        Me.grbRegistroDias = New System.Windows.Forms.GroupBox()
        Me.pnlrdoActivo = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoDiaAlta = New System.Windows.Forms.Label()
        Me.txtAltaNombreDias = New System.Windows.Forms.TextBox()
        Me.lblAltaNombreDia = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlAltaDias = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarDia = New System.Windows.Forms.Button()
        Me.btnGuardarDia = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grbRegistroDias.SuspendLayout()
        Me.pnlrdoActivo.SuspendLayout()
        Me.pnlAltaDias.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbRegistroDias
        '
        Me.grbRegistroDias.Controls.Add(Me.pnlrdoActivo)
        Me.grbRegistroDias.Controls.Add(Me.lblActivoDiaAlta)
        Me.grbRegistroDias.Controls.Add(Me.txtAltaNombreDias)
        Me.grbRegistroDias.Controls.Add(Me.lblAltaNombreDia)
        Me.grbRegistroDias.Location = New System.Drawing.Point(18, 77)
        Me.grbRegistroDias.Name = "grbRegistroDias"
        Me.grbRegistroDias.Size = New System.Drawing.Size(394, 84)
        Me.grbRegistroDias.TabIndex = 10
        Me.grbRegistroDias.TabStop = False
        '
        'pnlrdoActivo
        '
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoNo)
        Me.pnlrdoActivo.Controls.Add(Me.rdoActivoSi)
        Me.pnlrdoActivo.Location = New System.Drawing.Point(68, 45)
        Me.pnlrdoActivo.Name = "pnlrdoActivo"
        Me.pnlrdoActivo.Size = New System.Drawing.Size(84, 30)
        Me.pnlrdoActivo.TabIndex = 9
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(42, 9)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 3
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(3, 9)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 2
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'lblActivoDiaAlta
        '
        Me.lblActivoDiaAlta.AutoSize = True
        Me.lblActivoDiaAlta.Location = New System.Drawing.Point(11, 56)
        Me.lblActivoDiaAlta.Name = "lblActivoDiaAlta"
        Me.lblActivoDiaAlta.Size = New System.Drawing.Size(41, 13)
        Me.lblActivoDiaAlta.TabIndex = 2
        Me.lblActivoDiaAlta.Text = "*Activo"
        '
        'txtAltaNombreDias
        '
        Me.txtAltaNombreDias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAltaNombreDias.Location = New System.Drawing.Point(68, 19)
        Me.txtAltaNombreDias.Name = "txtAltaNombreDias"
        Me.txtAltaNombreDias.Size = New System.Drawing.Size(303, 20)
        Me.txtAltaNombreDias.TabIndex = 1
        '
        'lblAltaNombreDia
        '
        Me.lblAltaNombreDia.AutoSize = True
        Me.lblAltaNombreDia.Location = New System.Drawing.Point(11, 22)
        Me.lblAltaNombreDia.Name = "lblAltaNombreDia"
        Me.lblAltaNombreDia.Size = New System.Drawing.Size(48, 13)
        Me.lblAltaNombreDia.TabIndex = 0
        Me.lblAltaNombreDia.Text = "*Nombre"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(365, 202)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 14
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
        Me.pnlAltaDias.Size = New System.Drawing.Size(423, 60)
        Me.pnlAltaDias.TabIndex = 9
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(304, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(45, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Días"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(305, 202)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 13
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarDia
        '
        Me.btnCancelarDia.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelarDia.Location = New System.Drawing.Point(365, 167)
        Me.btnCancelarDia.Name = "btnCancelarDia"
        Me.btnCancelarDia.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarDia.TabIndex = 5
        Me.btnCancelarDia.UseVisualStyleBackColor = True
        '
        'btnGuardarDia
        '
        Me.btnGuardarDia.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarDia.Location = New System.Drawing.Point(308, 167)
        Me.btnGuardarDia.Name = "btnGuardarDia"
        Me.btnGuardarDia.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarDia.TabIndex = 4
        Me.btnGuardarDia.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(355, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'EditarAgregarDiaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(423, 225)
        Me.Controls.Add(Me.grbRegistroDias)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.pnlAltaDias)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.btnCancelarDia)
        Me.Controls.Add(Me.btnGuardarDia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(439, 264)
        Me.Name = "EditarAgregarDiaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Días"
        Me.grbRegistroDias.ResumeLayout(False)
        Me.grbRegistroDias.PerformLayout()
        Me.pnlrdoActivo.ResumeLayout(False)
        Me.pnlrdoActivo.PerformLayout()
        Me.pnlAltaDias.ResumeLayout(False)
        Me.pnlAltaDias.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbRegistroDias As System.Windows.Forms.GroupBox
    Friend WithEvents pnlrdoActivo As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoDiaAlta As System.Windows.Forms.Label
    Friend WithEvents txtAltaNombreDias As System.Windows.Forms.TextBox
    Friend WithEvents lblAltaNombreDia As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents pnlAltaDias As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarDia As System.Windows.Forms.Button
    Friend WithEvents btnGuardarDia As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
