<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaCuentaContableForm
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
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.lblNombreRespaldo = New System.Windows.Forms.Label()
        Me.lblNombreRespaldo2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.advertencia
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Transparent
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.Location = New System.Drawing.Point(295, 154)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 33)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.Text = "No"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.advertencia
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Transparent
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.Location = New System.Drawing.Point(200, 154)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 33)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Si"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Contabilidad.Vista.My.Resources.Resources.aviso
        Me.PictureBox1.Location = New System.Drawing.Point(-3, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(397, 202)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.BackColor = System.Drawing.Color.AliceBlue
        Me.lblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumero.Location = New System.Drawing.Point(78, 95)
        Me.lblNumero.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(62, 22)
        Me.lblNumero.TabIndex = 18
        Me.lblNumero.Text = "Número"
        Me.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNumero.UseCompatibleTextRendering = True
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.BackColor = System.Drawing.Color.AliceBlue
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombre.Location = New System.Drawing.Point(13, 121)
        Me.lblNombre.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(127, 22)
        Me.lblNombre.TabIndex = 19
        Me.lblNombre.Text = "Nombre Contpaq"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNombre.UseCompatibleTextRendering = True
        '
        'txtNumero
        '
        Me.txtNumero.Enabled = False
        Me.txtNumero.Location = New System.Drawing.Point(146, 95)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(219, 20)
        Me.txtNumero.TabIndex = 20
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(146, 121)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(219, 20)
        Me.txtNombre.TabIndex = 21
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.BackColor = System.Drawing.Color.AliceBlue
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblMensaje.Location = New System.Drawing.Point(117, 45)
        Me.lblMensaje.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(198, 22)
        Me.lblMensaje.TabIndex = 22
        Me.lblMensaje.Text = "¿Desea generar la cuenta?"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblMensaje.UseCompatibleTextRendering = True
        '
        'lblNombreRespaldo
        '
        Me.lblNombreRespaldo.AutoSize = True
        Me.lblNombreRespaldo.BackColor = System.Drawing.Color.AliceBlue
        Me.lblNombreRespaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreRespaldo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreRespaldo.Location = New System.Drawing.Point(78, 70)
        Me.lblNombreRespaldo.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblNombreRespaldo.Name = "lblNombreRespaldo"
        Me.lblNombreRespaldo.Size = New System.Drawing.Size(62, 22)
        Me.lblNombreRespaldo.TabIndex = 23
        Me.lblNombreRespaldo.Text = "Nombre"
        Me.lblNombreRespaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNombreRespaldo.UseCompatibleTextRendering = True
        '
        'lblNombreRespaldo2
        '
        Me.lblNombreRespaldo2.AutoSize = True
        Me.lblNombreRespaldo2.BackColor = System.Drawing.Color.AliceBlue
        Me.lblNombreRespaldo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreRespaldo2.ForeColor = System.Drawing.Color.Black
        Me.lblNombreRespaldo2.Location = New System.Drawing.Point(146, 73)
        Me.lblNombreRespaldo2.MaximumSize = New System.Drawing.Size(329, 0)
        Me.lblNombreRespaldo2.Name = "lblNombreRespaldo2"
        Me.lblNombreRespaldo2.Size = New System.Drawing.Size(7, 17)
        Me.lblNombreRespaldo2.TabIndex = 24
        Me.lblNombreRespaldo2.Text = "."
        Me.lblNombreRespaldo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNombreRespaldo2.UseCompatibleTextRendering = True
        '
        'AltaCuentaContableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 201)
        Me.Controls.Add(Me.lblNombreRespaldo2)
        Me.Controls.Add(Me.lblNombreRespaldo)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaCuentaContableForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents lblNombreRespaldo As System.Windows.Forms.Label
    Friend WithEvents lblNombreRespaldo2 As System.Windows.Forms.Label
End Class
