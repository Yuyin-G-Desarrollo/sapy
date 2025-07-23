<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImprimirEtiquetasEmbarqueForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImprimirEtiquetasEmbarqueForm))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdEspecial = New System.Windows.Forms.RadioButton()
        Me.cmbImpresoras = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnarchivo = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdTodos = New System.Windows.Forms.RadioButton()
        Me.rdOtros = New System.Windows.Forms.RadioButton()
        Me.txtarchivo = New System.Windows.Forms.TextBox()
        Me.lblArchivo = New System.Windows.Forms.Label()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(430, 59)
        Me.pnlTitulo.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(362, 41)
        Me.Panel1.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(120, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(242, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Imprimir Etiquetas Embarque"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(362, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdEspecial)
        Me.GroupBox1.Controls.Add(Me.cmbImpresoras)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnarchivo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.rdTodos)
        Me.GroupBox1.Controls.Add(Me.rdOtros)
        Me.GroupBox1.Controls.Add(Me.txtarchivo)
        Me.GroupBox1.Controls.Add(Me.lblArchivo)
        Me.GroupBox1.Controls.Add(Me.txtnumero)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 214)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        '
        'rdEspecial
        '
        Me.rdEspecial.AutoSize = True
        Me.rdEspecial.Location = New System.Drawing.Point(287, 72)
        Me.rdEspecial.Name = "rdEspecial"
        Me.rdEspecial.Size = New System.Drawing.Size(97, 30)
        Me.rdEspecial.TabIndex = 127
        Me.rdEspecial.Text = "Caja Embarque" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Especial"
        Me.rdEspecial.UseVisualStyleBackColor = True
        '
        'cmbImpresoras
        '
        Me.cmbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresoras.FormattingEnabled = True
        Me.cmbImpresoras.Items.AddRange(New Object() {"200dpi", "300dpi"})
        Me.cmbImpresoras.Location = New System.Drawing.Point(83, 119)
        Me.cmbImpresoras.Name = "cmbImpresoras"
        Me.cmbImpresoras.Size = New System.Drawing.Size(152, 21)
        Me.cmbImpresoras.TabIndex = 126
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Impresora:"
        '
        'btnarchivo
        '
        Me.btnarchivo.Location = New System.Drawing.Point(265, 152)
        Me.btnarchivo.Name = "btnarchivo"
        Me.btnarchivo.Size = New System.Drawing.Size(65, 23)
        Me.btnarchivo.TabIndex = 124
        Me.btnarchivo.Text = "Examinar"
        Me.btnarchivo.UseVisualStyleBackColor = True
        Me.btnarchivo.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "Tipo Etiqueta:"
        '
        'rdTodos
        '
        Me.rdTodos.AutoSize = True
        Me.rdTodos.Checked = True
        Me.rdTodos.Location = New System.Drawing.Point(83, 79)
        Me.rdTodos.Name = "rdTodos"
        Me.rdTodos.Size = New System.Drawing.Size(98, 17)
        Me.rdTodos.TabIndex = 2
        Me.rdTodos.TabStop = True
        Me.rdTodos.Text = "Guia Embarque"
        Me.rdTodos.UseVisualStyleBackColor = True
        '
        'rdOtros
        '
        Me.rdOtros.AutoSize = True
        Me.rdOtros.Location = New System.Drawing.Point(187, 79)
        Me.rdOtros.Name = "rdOtros"
        Me.rdOtros.Size = New System.Drawing.Size(97, 17)
        Me.rdOtros.TabIndex = 0
        Me.rdOtros.Text = "Caja Embarque"
        Me.rdOtros.UseVisualStyleBackColor = True
        '
        'txtarchivo
        '
        Me.txtarchivo.BackColor = System.Drawing.Color.White
        Me.txtarchivo.Location = New System.Drawing.Point(82, 155)
        Me.txtarchivo.Name = "txtarchivo"
        Me.txtarchivo.Size = New System.Drawing.Size(177, 20)
        Me.txtarchivo.TabIndex = 118
        Me.txtarchivo.Visible = False
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.Location = New System.Drawing.Point(31, 158)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
        Me.lblArchivo.TabIndex = 117
        Me.lblArchivo.Text = "Archivo"
        Me.lblArchivo.Visible = False
        '
        'txtnumero
        '
        Me.txtnumero.BackColor = System.Drawing.Color.White
        Me.txtnumero.Enabled = False
        Me.txtnumero.Location = New System.Drawing.Point(82, 32)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(248, 20)
        Me.txtnumero.TabIndex = 115
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Cliente:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.pnlDatosBotones)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 285)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(430, 57)
        Me.Panel3.TabIndex = 126
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.Button3)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(268, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 57)
        Me.pnlDatosBotones.TabIndex = 141
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(94, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(32, 38)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Imprimir"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(93, 38)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Button3.Image = Global.Almacen.Vista.My.Resources.Resources.ImprimirEtiquetas
        Me.Button3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3.Location = New System.Drawing.Point(37, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 0
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ImprimirEtiquetasEmbarqueForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(430, 342)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlTitulo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImprimirEtiquetasEmbarqueForm"
        Me.Text = "Imprimir Etiquetas Embarque"
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtarchivo As TextBox
    Friend WithEvents lblArchivo As Label
    Friend WithEvents txtnumero As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents rdTodos As RadioButton
    Friend WithEvents rdOtros As RadioButton
    Friend WithEvents btnarchivo As Button
    Friend WithEvents cmbImpresoras As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents rdEspecial As RadioButton
End Class
