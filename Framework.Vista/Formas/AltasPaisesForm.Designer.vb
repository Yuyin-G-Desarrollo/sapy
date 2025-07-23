<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasPaisesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasPaisesForm))
        Me.pnlAltaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.gpbRegistroPaises = New System.Windows.Forms.GroupBox()
        Me.pnlradoButton = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoPaisAlta = New System.Windows.Forms.Label()
        Me.txtAltaNombrePais = New System.Windows.Forms.TextBox()
        Me.lblNombrePaisAlta = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarPais = New System.Windows.Forms.Button()
        Me.btnGuardarPais = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlAltaPaises.SuspendLayout()
        Me.gpbRegistroPaises.SuspendLayout()
        Me.pnlradoButton.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlAltaPaises
        '
        Me.pnlAltaPaises.BackColor = System.Drawing.Color.White
        Me.pnlAltaPaises.Controls.Add(Me.PictureBox1)
        Me.pnlAltaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlAltaPaises.Location = New System.Drawing.Point(2, 1)
        Me.pnlAltaPaises.Name = "pnlAltaPaises"
        Me.pnlAltaPaises.Size = New System.Drawing.Size(398, 60)
        Me.pnlAltaPaises.TabIndex = 1
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(269, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(62, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Países"
        '
        'gpbRegistroPaises
        '
        Me.gpbRegistroPaises.Controls.Add(Me.pnlradoButton)
        Me.gpbRegistroPaises.Controls.Add(Me.lblActivoPaisAlta)
        Me.gpbRegistroPaises.Controls.Add(Me.txtAltaNombrePais)
        Me.gpbRegistroPaises.Controls.Add(Me.lblNombrePaisAlta)
        Me.gpbRegistroPaises.Location = New System.Drawing.Point(8, 66)
        Me.gpbRegistroPaises.Name = "gpbRegistroPaises"
        Me.gpbRegistroPaises.Size = New System.Drawing.Size(385, 84)
        Me.gpbRegistroPaises.TabIndex = 2
        Me.gpbRegistroPaises.TabStop = False
        '
        'pnlradoButton
        '
        Me.pnlradoButton.Controls.Add(Me.rdoActivoNo)
        Me.pnlradoButton.Controls.Add(Me.rdoActivoSi)
        Me.pnlradoButton.Location = New System.Drawing.Point(68, 45)
        Me.pnlradoButton.Name = "pnlradoButton"
        Me.pnlradoButton.Size = New System.Drawing.Size(84, 30)
        Me.pnlradoButton.TabIndex = 9
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(42, 9)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 6
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
        Me.rdoActivoSi.TabIndex = 5
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'lblActivoPaisAlta
        '
        Me.lblActivoPaisAlta.AutoSize = True
        Me.lblActivoPaisAlta.Location = New System.Drawing.Point(18, 55)
        Me.lblActivoPaisAlta.Name = "lblActivoPaisAlta"
        Me.lblActivoPaisAlta.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoPaisAlta.TabIndex = 2
        Me.lblActivoPaisAlta.Text = "Activo"
        '
        'txtAltaNombrePais
        '
        Me.txtAltaNombrePais.Location = New System.Drawing.Point(68, 19)
        Me.txtAltaNombrePais.Name = "txtAltaNombrePais"
        Me.txtAltaNombrePais.Size = New System.Drawing.Size(303, 20)
        Me.txtAltaNombrePais.TabIndex = 1
        '
        'lblNombrePaisAlta
        '
        Me.lblNombrePaisAlta.AutoSize = True
        Me.lblNombrePaisAlta.Location = New System.Drawing.Point(18, 22)
        Me.lblNombrePaisAlta.Name = "lblNombrePaisAlta"
        Me.lblNombrePaisAlta.Size = New System.Drawing.Size(44, 13)
        Me.lblNombrePaisAlta.TabIndex = 0
        Me.lblNombrePaisAlta.Text = "Nombre"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(355, 191)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Cerrar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(293, 191)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarPais
        '
        Me.btnCancelarPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelarPais.Location = New System.Drawing.Point(355, 156)
        Me.btnCancelarPais.Name = "btnCancelarPais"
        Me.btnCancelarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarPais.TabIndex = 6
        Me.btnCancelarPais.UseVisualStyleBackColor = True
        '
        'btnGuardarPais
        '
        Me.btnGuardarPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarPais.Location = New System.Drawing.Point(298, 156)
        Me.btnGuardarPais.Name = "btnGuardarPais"
        Me.btnGuardarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarPais.TabIndex = 5
        Me.btnGuardarPais.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(330, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'AltasPaisesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(399, 210)
        Me.Controls.Add(Me.gpbRegistroPaises)
        Me.Controls.Add(Me.lblLimpiar)
        Me.Controls.Add(Me.pnlAltaPaises)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.btnCancelarPais)
        Me.Controls.Add(Me.btnGuardarPais)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltasPaisesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Países"
        Me.pnlAltaPaises.ResumeLayout(False)
        Me.pnlAltaPaises.PerformLayout()
        Me.gpbRegistroPaises.ResumeLayout(False)
        Me.gpbRegistroPaises.PerformLayout()
        Me.pnlradoButton.ResumeLayout(False)
        Me.pnlradoButton.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlAltaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents gpbRegistroPaises As System.Windows.Forms.GroupBox
    Friend WithEvents pnlradoButton As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarPais As System.Windows.Forms.Button
    Friend WithEvents btnGuardarPais As System.Windows.Forms.Button
    Friend WithEvents lblActivoPaisAlta As System.Windows.Forms.Label
    Friend WithEvents txtAltaNombrePais As System.Windows.Forms.TextBox
    Friend WithEvents lblNombrePaisAlta As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
