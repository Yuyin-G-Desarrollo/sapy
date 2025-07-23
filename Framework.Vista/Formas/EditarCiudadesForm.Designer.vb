<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarCiudadesForm
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
        Me.gpbRegistroPaises = New System.Windows.Forms.GroupBox()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.pnlradoButton = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarEdicionPais = New System.Windows.Forms.Button()
        Me.btnGuardarEdicionPais = New System.Windows.Forms.Button()
        Me.lblActivoPaisAlta = New System.Windows.Forms.Label()
        Me.txtEditarNombreCiudad = New System.Windows.Forms.TextBox()
        Me.lblEditarNombreEstado = New System.Windows.Forms.Label()
        Me.pnlAltaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gpbRegistroPaises.SuspendLayout()
        Me.pnlradoButton.SuspendLayout()
        Me.pnlAltaPaises.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbRegistroPaises
        '
        Me.gpbRegistroPaises.Controls.Add(Me.cmbEstados)
        Me.gpbRegistroPaises.Controls.Add(Me.lblEstado)
        Me.gpbRegistroPaises.Controls.Add(Me.cmbPais)
        Me.gpbRegistroPaises.Controls.Add(Me.lblPais)
        Me.gpbRegistroPaises.Controls.Add(Me.pnlradoButton)
        Me.gpbRegistroPaises.Controls.Add(Me.lblLimpiar)
        Me.gpbRegistroPaises.Controls.Add(Me.lblBuscar)
        Me.gpbRegistroPaises.Controls.Add(Me.btnCancelarEdicionPais)
        Me.gpbRegistroPaises.Controls.Add(Me.btnGuardarEdicionPais)
        Me.gpbRegistroPaises.Controls.Add(Me.lblActivoPaisAlta)
        Me.gpbRegistroPaises.Controls.Add(Me.txtEditarNombreCiudad)
        Me.gpbRegistroPaises.Controls.Add(Me.lblEditarNombreEstado)
        Me.gpbRegistroPaises.Location = New System.Drawing.Point(15, 69)
        Me.gpbRegistroPaises.Name = "gpbRegistroPaises"
        Me.gpbRegistroPaises.Size = New System.Drawing.Size(483, 273)
        Me.gpbRegistroPaises.TabIndex = 8
        Me.gpbRegistroPaises.TabStop = False
        '
        'cmbEstados
        '
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(79, 88)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstados.TabIndex = 15
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(33, 91)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 14
        Me.lblEstado.Text = "Estado"
        '
        'cmbPais
        '
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(79, 50)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(121, 21)
        Me.cmbPais.TabIndex = 13
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(46, 50)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(27, 13)
        Me.lblPais.TabIndex = 12
        Me.lblPais.Text = "Pais"
        '
        'pnlradoButton
        '
        Me.pnlradoButton.Controls.Add(Me.rdoActivoNo)
        Me.pnlradoButton.Controls.Add(Me.rdoActivoSi)
        Me.pnlradoButton.Location = New System.Drawing.Point(85, 129)
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
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(419, 246)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Cancelar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(356, 246)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarEdicionPais
        '
        Me.btnCancelarEdicionPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.cancelar_32
        Me.btnCancelarEdicionPais.Location = New System.Drawing.Point(422, 210)
        Me.btnCancelarEdicionPais.Name = "btnCancelarEdicionPais"
        Me.btnCancelarEdicionPais.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarEdicionPais.TabIndex = 6
        Me.btnCancelarEdicionPais.UseVisualStyleBackColor = True
        '
        'btnGuardarEdicionPais
        '
        Me.btnGuardarEdicionPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar_32
        Me.btnGuardarEdicionPais.Location = New System.Drawing.Point(360, 210)
        Me.btnGuardarEdicionPais.Name = "btnGuardarEdicionPais"
        Me.btnGuardarEdicionPais.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarEdicionPais.TabIndex = 5
        Me.btnGuardarEdicionPais.UseVisualStyleBackColor = True
        '
        'lblActivoPaisAlta
        '
        Me.lblActivoPaisAlta.AutoSize = True
        Me.lblActivoPaisAlta.Location = New System.Drawing.Point(36, 139)
        Me.lblActivoPaisAlta.Name = "lblActivoPaisAlta"
        Me.lblActivoPaisAlta.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoPaisAlta.TabIndex = 2
        Me.lblActivoPaisAlta.Text = "Activo"
        '
        'txtEditarNombreCiudad
        '
        Me.txtEditarNombreCiudad.Location = New System.Drawing.Point(79, 13)
        Me.txtEditarNombreCiudad.Name = "txtEditarNombreCiudad"
        Me.txtEditarNombreCiudad.Size = New System.Drawing.Size(118, 20)
        Me.txtEditarNombreCiudad.TabIndex = 1
        '
        'lblEditarNombreEstado
        '
        Me.lblEditarNombreEstado.AutoSize = True
        Me.lblEditarNombreEstado.Location = New System.Drawing.Point(29, 16)
        Me.lblEditarNombreEstado.Name = "lblEditarNombreEstado"
        Me.lblEditarNombreEstado.Size = New System.Drawing.Size(44, 13)
        Me.lblEditarNombreEstado.TabIndex = 0
        Me.lblEditarNombreEstado.Text = "Nombre"
        '
        'pnlAltaPaises
        '
        Me.pnlAltaPaises.BackColor = System.Drawing.Color.White
        Me.pnlAltaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlAltaPaises.Controls.Add(Me.PictureBox1)
        Me.pnlAltaPaises.Location = New System.Drawing.Point(1, 0)
        Me.pnlAltaPaises.Name = "pnlAltaPaises"
        Me.pnlAltaPaises.Size = New System.Drawing.Size(508, 70)
        Me.pnlAltaPaises.TabIndex = 7
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(370, 50)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(137, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Editar Ciudades"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.yuyin
        Me.PictureBox1.Location = New System.Drawing.Point(374, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(131, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'EditarCiudadesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(510, 370)
        Me.Controls.Add(Me.gpbRegistroPaises)
        Me.Controls.Add(Me.pnlAltaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "EditarCiudadesForm"
        Me.Text = "Editar Ciudades"
        Me.gpbRegistroPaises.ResumeLayout(False)
        Me.gpbRegistroPaises.PerformLayout()
        Me.pnlradoButton.ResumeLayout(False)
        Me.pnlradoButton.PerformLayout()
        Me.pnlAltaPaises.ResumeLayout(False)
        Me.pnlAltaPaises.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbRegistroPaises As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents pnlradoButton As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEdicionPais As System.Windows.Forms.Button
    Friend WithEvents btnGuardarEdicionPais As System.Windows.Forms.Button
    Friend WithEvents lblActivoPaisAlta As System.Windows.Forms.Label
    Friend WithEvents txtEditarNombreCiudad As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarNombreEstado As System.Windows.Forms.Label
    Friend WithEvents pnlAltaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
