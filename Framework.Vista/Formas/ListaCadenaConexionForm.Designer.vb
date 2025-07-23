<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaCadenaConexionForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaCadenaConexionForm))
		Me.btnCancelar = New System.Windows.Forms.Button()
		Me.btnGuardar = New System.Windows.Forms.Button()
		Me.grbCadena = New System.Windows.Forms.GroupBox()
		Me.txtConexionSAY = New System.Windows.Forms.TextBox()
		Me.txtConexionPoolPruebas = New System.Windows.Forms.TextBox()
		Me.lblCadenaConexion = New System.Windows.Forms.Label()
		Me.lblConexionPruebas = New System.Windows.Forms.Label()
		Me.lblPollSicy = New System.Windows.Forms.Label()
		Me.txtConexionPoolSicy = New System.Windows.Forms.TextBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.lblDeduccionImss = New System.Windows.Forms.Label()
		Me.PictureBox3 = New System.Windows.Forms.PictureBox()
		Me.PictureBox2 = New System.Windows.Forms.PictureBox()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.btnComprobar = New System.Windows.Forms.Button()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Button2 = New System.Windows.Forms.Button()
		Me.pbMal = New System.Windows.Forms.PictureBox()
		Me.pbIncorrecto = New System.Windows.Forms.PictureBox()
		Me.pbMalI = New System.Windows.Forms.PictureBox()
		Me.grbCadena.SuspendLayout()
		Me.Panel1.SuspendLayout()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.pbMal, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.pbIncorrecto, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.pbMalI, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'btnCancelar
		'
		Me.btnCancelar.Location = New System.Drawing.Point(591, 291)
		Me.btnCancelar.Name = "btnCancelar"
		Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
		Me.btnCancelar.TabIndex = 13
		Me.btnCancelar.Text = "Cancelar"
		Me.btnCancelar.UseVisualStyleBackColor = True
		'
		'btnGuardar
		'
		Me.btnGuardar.Location = New System.Drawing.Point(692, 291)
		Me.btnGuardar.Name = "btnGuardar"
		Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
		Me.btnGuardar.TabIndex = 12
		Me.btnGuardar.Text = "Guardar"
		Me.btnGuardar.UseVisualStyleBackColor = True
		'
		'grbCadena
		'
		Me.grbCadena.Controls.Add(Me.pbMalI)
		Me.grbCadena.Controls.Add(Me.pbIncorrecto)
		Me.grbCadena.Controls.Add(Me.pbMal)
		Me.grbCadena.Controls.Add(Me.Button2)
		Me.grbCadena.Controls.Add(Me.Button1)
		Me.grbCadena.Controls.Add(Me.btnComprobar)
		Me.grbCadena.Controls.Add(Me.PictureBox3)
		Me.grbCadena.Controls.Add(Me.PictureBox2)
		Me.grbCadena.Controls.Add(Me.PictureBox1)
		Me.grbCadena.Controls.Add(Me.txtConexionSAY)
		Me.grbCadena.Controls.Add(Me.txtConexionPoolPruebas)
		Me.grbCadena.Controls.Add(Me.lblCadenaConexion)
		Me.grbCadena.Controls.Add(Me.lblConexionPruebas)
		Me.grbCadena.Controls.Add(Me.lblPollSicy)
		Me.grbCadena.Controls.Add(Me.txtConexionPoolSicy)
		Me.grbCadena.Location = New System.Drawing.Point(6, 78)
		Me.grbCadena.Name = "grbCadena"
		Me.grbCadena.Size = New System.Drawing.Size(782, 193)
		Me.grbCadena.TabIndex = 11
		Me.grbCadena.TabStop = False
		'
		'txtConexionSAY
		'
		Me.txtConexionSAY.ImeMode = System.Windows.Forms.ImeMode.Close
		Me.txtConexionSAY.Location = New System.Drawing.Point(186, 32)
		Me.txtConexionSAY.Name = "txtConexionSAY"
		Me.txtConexionSAY.Size = New System.Drawing.Size(433, 20)
		Me.txtConexionSAY.TabIndex = 2
		'
		'txtConexionPoolPruebas
		'
		Me.txtConexionPoolPruebas.Location = New System.Drawing.Point(186, 135)
		Me.txtConexionPoolPruebas.Name = "txtConexionPoolPruebas"
		Me.txtConexionPoolPruebas.Size = New System.Drawing.Size(433, 20)
		Me.txtConexionPoolPruebas.TabIndex = 6
		'
		'lblCadenaConexion
		'
		Me.lblCadenaConexion.AutoSize = True
		Me.lblCadenaConexion.Location = New System.Drawing.Point(65, 32)
		Me.lblCadenaConexion.Name = "lblCadenaConexion"
		Me.lblCadenaConexion.Size = New System.Drawing.Size(109, 13)
		Me.lblCadenaConexion.TabIndex = 1
		Me.lblCadenaConexion.Text = "CadenaConexionPool"
		'
		'lblConexionPruebas
		'
		Me.lblConexionPruebas.AutoSize = True
		Me.lblConexionPruebas.Location = New System.Drawing.Point(26, 135)
		Me.lblConexionPruebas.Name = "lblConexionPruebas"
		Me.lblConexionPruebas.Size = New System.Drawing.Size(148, 13)
		Me.lblConexionPruebas.TabIndex = 5
		Me.lblConexionPruebas.Text = "CadenaConexionPoolPruebas"
		'
		'lblPollSicy
		'
		Me.lblPollSicy.AutoSize = True
		Me.lblPollSicy.Location = New System.Drawing.Point(42, 85)
		Me.lblPollSicy.Name = "lblPollSicy"
		Me.lblPollSicy.Size = New System.Drawing.Size(132, 13)
		Me.lblPollSicy.TabIndex = 3
		Me.lblPollSicy.Text = "CadenaconexionPoolSICY"
		'
		'txtConexionPoolSicy
		'
		Me.txtConexionPoolSicy.Location = New System.Drawing.Point(186, 85)
		Me.txtConexionPoolSicy.Name = "txtConexionPoolSicy"
		Me.txtConexionPoolSicy.Size = New System.Drawing.Size(433, 20)
		Me.txtConexionPoolSicy.TabIndex = 4
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.White
		Me.Panel1.Controls.Add(Me.lblDeduccionImss)
		Me.Panel1.Controls.Add(Me.imgLogo)
		Me.Panel1.Location = New System.Drawing.Point(1, 2)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(792, 70)
		Me.Panel1.TabIndex = 10
		'
		'lblDeduccionImss
		'
		Me.lblDeduccionImss.AutoSize = True
		Me.lblDeduccionImss.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDeduccionImss.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblDeduccionImss.Location = New System.Drawing.Point(625, 47)
		Me.lblDeduccionImss.Name = "lblDeduccionImss"
		Me.lblDeduccionImss.Size = New System.Drawing.Size(162, 20)
		Me.lblDeduccionImss.TabIndex = 22
		Me.lblDeduccionImss.Text = "Cadena de conxion"
		'
		'PictureBox3
		'
		Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
		Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
		Me.PictureBox3.Location = New System.Drawing.Point(709, 116)
		Me.PictureBox3.Name = "PictureBox3"
		Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
		Me.PictureBox3.TabIndex = 10
		Me.PictureBox3.TabStop = False
		Me.PictureBox3.Visible = False
		'
		'PictureBox2
		'
		Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
		Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
		Me.PictureBox2.Location = New System.Drawing.Point(709, 66)
		Me.PictureBox2.Name = "PictureBox2"
		Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
		Me.PictureBox2.TabIndex = 9
		Me.PictureBox2.TabStop = False
		Me.PictureBox2.Visible = False
		'
		'PictureBox1
		'
		Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.Location = New System.Drawing.Point(709, 19)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
		Me.PictureBox1.TabIndex = 8
		Me.PictureBox1.TabStop = False
		Me.PictureBox1.Visible = False
		'
		'imgLogo
		'
		Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
		Me.imgLogo.Location = New System.Drawing.Point(661, 0)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 1
		Me.imgLogo.TabStop = False
		'
		'btnComprobar
		'
		Me.btnComprobar.Location = New System.Drawing.Point(628, 22)
		Me.btnComprobar.Name = "btnComprobar"
		Me.btnComprobar.Size = New System.Drawing.Size(75, 23)
		Me.btnComprobar.TabIndex = 11
		Me.btnComprobar.Text = "Comprobar"
		Me.btnComprobar.UseVisualStyleBackColor = True
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(628, 75)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 12
		Me.Button1.Text = "Comprobar"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(628, 130)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(75, 23)
		Me.Button2.TabIndex = 13
		Me.Button2.Text = "Comprobar"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'pbMal
		'
		Me.pbMal.Cursor = System.Windows.Forms.Cursors.Hand
		Me.pbMal.Image = CType(resources.GetObject("pbMal.Image"), System.Drawing.Image)
		Me.pbMal.Location = New System.Drawing.Point(709, 20)
		Me.pbMal.Name = "pbMal"
		Me.pbMal.Size = New System.Drawing.Size(32, 32)
		Me.pbMal.TabIndex = 14
		Me.pbMal.TabStop = False
		Me.pbMal.Visible = False
		'
		'pbIncorrecto
		'
		Me.pbIncorrecto.Cursor = System.Windows.Forms.Cursors.Hand
		Me.pbIncorrecto.Image = CType(resources.GetObject("pbIncorrecto.Image"), System.Drawing.Image)
		Me.pbIncorrecto.Location = New System.Drawing.Point(709, 66)
		Me.pbIncorrecto.Name = "pbIncorrecto"
		Me.pbIncorrecto.Size = New System.Drawing.Size(32, 32)
		Me.pbIncorrecto.TabIndex = 15
		Me.pbIncorrecto.TabStop = False
		Me.pbIncorrecto.Visible = False
		'
		'pbMalI
		'
		Me.pbMalI.Cursor = System.Windows.Forms.Cursors.Hand
		Me.pbMalI.Image = CType(resources.GetObject("pbMalI.Image"), System.Drawing.Image)
		Me.pbMalI.Location = New System.Drawing.Point(709, 116)
		Me.pbMalI.Name = "pbMalI"
		Me.pbMalI.Size = New System.Drawing.Size(32, 32)
		Me.pbMalI.TabIndex = 16
		Me.pbMalI.TabStop = False
		Me.pbMalI.Visible = False
		'
		'ListaCadenaConexionForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(795, 347)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.btnGuardar)
		Me.Controls.Add(Me.grbCadena)
		Me.Controls.Add(Me.Panel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaCadenaConexionForm"
		Me.Text = "ListaCadenaConexionForm"
		Me.grbCadena.ResumeLayout(False)
		Me.grbCadena.PerformLayout()
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.pbMal, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.pbIncorrecto, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.pbMalI, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnCancelar As System.Windows.Forms.Button
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents grbCadena As System.Windows.Forms.GroupBox
	Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
	Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
	Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
	Friend WithEvents txtConexionSAY As System.Windows.Forms.TextBox
	Friend WithEvents txtConexionPoolPruebas As System.Windows.Forms.TextBox
	Friend WithEvents lblCadenaConexion As System.Windows.Forms.Label
	Friend WithEvents lblConexionPruebas As System.Windows.Forms.Label
	Friend WithEvents lblPollSicy As System.Windows.Forms.Label
	Friend WithEvents txtConexionPoolSicy As System.Windows.Forms.TextBox
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents lblDeduccionImss As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents Button2 As System.Windows.Forms.Button
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents btnComprobar As System.Windows.Forms.Button
	Friend WithEvents pbMal As System.Windows.Forms.PictureBox
	Friend WithEvents pbMalI As System.Windows.Forms.PictureBox
	Friend WithEvents pbIncorrecto As System.Windows.Forms.PictureBox
End Class
