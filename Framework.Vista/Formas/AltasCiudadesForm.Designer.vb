<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasCiudadesForm
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
        Me.gpbFiltroPaises = New System.Windows.Forms.GroupBox()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnCancelarPais = New System.Windows.Forms.Button()
        Me.btnGuardarPais = New System.Windows.Forms.Button()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.cmbPaises = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.lblActivoPais = New System.Windows.Forms.Label()
        Me.txtAltaNombreCiudad = New System.Windows.Forms.TextBox()
        Me.lblNombreCiudad = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gpbFiltroPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbFiltroPaises
        '
        Me.gpbFiltroPaises.Controls.Add(Me.lblLimpiar)
        Me.gpbFiltroPaises.Controls.Add(Me.lblBuscar)
        Me.gpbFiltroPaises.Controls.Add(Me.btnCancelarPais)
        Me.gpbFiltroPaises.Controls.Add(Me.btnGuardarPais)
        Me.gpbFiltroPaises.Controls.Add(Me.cmbEstados)
        Me.gpbFiltroPaises.Controls.Add(Me.cmbPaises)
        Me.gpbFiltroPaises.Controls.Add(Me.lblEstado)
        Me.gpbFiltroPaises.Controls.Add(Me.lblPais)
        Me.gpbFiltroPaises.Controls.Add(Me.Panel1)
        Me.gpbFiltroPaises.Controls.Add(Me.lblActivoPais)
        Me.gpbFiltroPaises.Controls.Add(Me.txtAltaNombreCiudad)
        Me.gpbFiltroPaises.Controls.Add(Me.lblNombreCiudad)
        Me.gpbFiltroPaises.Location = New System.Drawing.Point(14, 83)
        Me.gpbFiltroPaises.Name = "gpbFiltroPaises"
        Me.gpbFiltroPaises.Size = New System.Drawing.Size(593, 287)
        Me.gpbFiltroPaises.TabIndex = 6
        Me.gpbFiltroPaises.TabStop = False
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(522, 258)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 13)
        Me.lblLimpiar.TabIndex = 22
        Me.lblLimpiar.Text = "Cancelar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(459, 258)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 21
        Me.lblBuscar.Text = "Guardar"
        '
        'btnCancelarPais
        '
        Me.btnCancelarPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.cancelar_32
        Me.btnCancelarPais.Location = New System.Drawing.Point(525, 222)
        Me.btnCancelarPais.Name = "btnCancelarPais"
        Me.btnCancelarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarPais.TabIndex = 20
        Me.btnCancelarPais.UseVisualStyleBackColor = True
        '
        'btnGuardarPais
        '
        Me.btnGuardarPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar_32
        Me.btnGuardarPais.Location = New System.Drawing.Point(463, 222)
        Me.btnGuardarPais.Name = "btnGuardarPais"
        Me.btnGuardarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarPais.TabIndex = 19
        Me.btnGuardarPais.UseVisualStyleBackColor = True
        '
        'cmbEstados
        '
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(74, 141)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstados.TabIndex = 18
        '
        'cmbPaises
        '
        Me.cmbPaises.FormattingEnabled = True
        Me.cmbPaises.Location = New System.Drawing.Point(74, 92)
        Me.cmbPaises.Name = "cmbPaises"
        Me.cmbPaises.Size = New System.Drawing.Size(121, 21)
        Me.cmbPaises.TabIndex = 17
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(15, 141)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 16
        Me.lblEstado.Text = "Estado"
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(28, 96)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(27, 13)
        Me.lblPais.TabIndex = 15
        Me.lblPais.Text = "Pais"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoActivoNo)
        Me.Panel1.Controls.Add(Me.rdoActivoSi)
        Me.Panel1.Location = New System.Drawing.Point(83, 222)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 30)
        Me.Panel1.TabIndex = 14
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(52, 7)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 6
        Me.rdoActivoNo.TabStop = True
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
        Me.rdoActivoSi.TabIndex = 5
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'lblActivoPais
        '
        Me.lblActivoPais.AutoSize = True
        Me.lblActivoPais.Location = New System.Drawing.Point(31, 231)
        Me.lblActivoPais.Name = "lblActivoPais"
        Me.lblActivoPais.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoPais.TabIndex = 2
        Me.lblActivoPais.Text = "Activo"
        '
        'txtAltaNombreCiudad
        '
        Me.txtAltaNombreCiudad.Location = New System.Drawing.Point(74, 40)
        Me.txtAltaNombreCiudad.Name = "txtAltaNombreCiudad"
        Me.txtAltaNombreCiudad.Size = New System.Drawing.Size(118, 20)
        Me.txtAltaNombreCiudad.TabIndex = 1
        '
        'lblNombreCiudad
        '
        Me.lblNombreCiudad.AutoSize = True
        Me.lblNombreCiudad.Location = New System.Drawing.Point(24, 43)
        Me.lblNombreCiudad.Name = "lblNombreCiudad"
        Me.lblNombreCiudad.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreCiudad.TabIndex = 0
        Me.lblNombreCiudad.Text = "Nombre"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.PictureBox1)
        Me.pnlListaPaises.Location = New System.Drawing.Point(1, 3)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(619, 70)
        Me.pnlListaPaises.TabIndex = 5
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(495, 49)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(121, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Alta Ciudades"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.yuyin
        Me.PictureBox1.Location = New System.Drawing.Point(500, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(119, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'AltasCiudadesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(616, 376)
        Me.Controls.Add(Me.gpbFiltroPaises)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltasCiudadesForm"
        Me.Text = "Altas Ciudades"
        Me.gpbFiltroPaises.ResumeLayout(False)
        Me.gpbFiltroPaises.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbFiltroPaises As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPaises As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoPais As System.Windows.Forms.Label
    Friend WithEvents txtAltaNombreCiudad As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreCiudad As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnCancelarPais As System.Windows.Forms.Button
    Friend WithEvents btnGuardarPais As System.Windows.Forms.Button
End Class
