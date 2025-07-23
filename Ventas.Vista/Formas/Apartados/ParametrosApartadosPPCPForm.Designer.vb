<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametrosApartadosPPCPForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParametrosApartadosPPCPForm))
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.chboxDestallarPunto = New System.Windows.Forms.CheckBox()
        Me.chboxDestallarNormales = New System.Windows.Forms.CheckBox()
        Me.chboxAtadosPar = New System.Windows.Forms.CheckBox()
        Me.chboxAtadosNon = New System.Windows.Forms.CheckBox()
        Me.chboxAtadosPunto = New System.Windows.Forms.CheckBox()
        Me.chboxParesDestallados = New System.Windows.Forms.CheckBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnActualizarDistribucion = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox9.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.chboxDestallarPunto)
        Me.GroupBox9.Controls.Add(Me.chboxDestallarNormales)
        Me.GroupBox9.Controls.Add(Me.chboxAtadosPar)
        Me.GroupBox9.Controls.Add(Me.chboxAtadosNon)
        Me.GroupBox9.Controls.Add(Me.chboxAtadosPunto)
        Me.GroupBox9.Controls.Add(Me.chboxParesDestallados)
        Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(356, 56)
        Me.GroupBox9.TabIndex = 120
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Tipo de Atados a disponer"
        '
        'chboxDestallarPunto
        '
        Me.chboxDestallarPunto.AutoSize = True
        Me.chboxDestallarPunto.Checked = True
        Me.chboxDestallarPunto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxDestallarPunto.Location = New System.Drawing.Point(187, 36)
        Me.chboxDestallarPunto.Name = "chboxDestallarPunto"
        Me.chboxDestallarPunto.Size = New System.Drawing.Size(153, 17)
        Me.chboxDestallarPunto.TabIndex = 74
        Me.chboxDestallarPunto.Text = "Destallar Atados Por Punto"
        Me.chboxDestallarPunto.UseVisualStyleBackColor = True
        '
        'chboxDestallarNormales
        '
        Me.chboxDestallarNormales.AutoSize = True
        Me.chboxDestallarNormales.Checked = True
        Me.chboxDestallarNormales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxDestallarNormales.Location = New System.Drawing.Point(15, 36)
        Me.chboxDestallarNormales.Name = "chboxDestallarNormales"
        Me.chboxDestallarNormales.Size = New System.Drawing.Size(150, 17)
        Me.chboxDestallarNormales.TabIndex = 73
        Me.chboxDestallarNormales.Text = "Destallar Atados Normales"
        Me.chboxDestallarNormales.UseVisualStyleBackColor = True
        '
        'chboxAtadosPar
        '
        Me.chboxAtadosPar.AutoSize = True
        Me.chboxAtadosPar.Checked = True
        Me.chboxAtadosPar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxAtadosPar.Location = New System.Drawing.Point(80, 18)
        Me.chboxAtadosPar.Name = "chboxAtadosPar"
        Me.chboxAtadosPar.Size = New System.Drawing.Size(42, 17)
        Me.chboxAtadosPar.TabIndex = 71
        Me.chboxAtadosPar.Text = "Par"
        Me.chboxAtadosPar.UseVisualStyleBackColor = True
        '
        'chboxAtadosNon
        '
        Me.chboxAtadosNon.AutoSize = True
        Me.chboxAtadosNon.Checked = True
        Me.chboxAtadosNon.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxAtadosNon.Location = New System.Drawing.Point(15, 18)
        Me.chboxAtadosNon.Name = "chboxAtadosNon"
        Me.chboxAtadosNon.Size = New System.Drawing.Size(46, 17)
        Me.chboxAtadosNon.TabIndex = 71
        Me.chboxAtadosNon.Text = "Non"
        Me.chboxAtadosNon.UseVisualStyleBackColor = True
        '
        'chboxAtadosPunto
        '
        Me.chboxAtadosPunto.AutoSize = True
        Me.chboxAtadosPunto.Checked = True
        Me.chboxAtadosPunto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxAtadosPunto.Location = New System.Drawing.Point(144, 18)
        Me.chboxAtadosPunto.Name = "chboxAtadosPunto"
        Me.chboxAtadosPunto.Size = New System.Drawing.Size(73, 17)
        Me.chboxAtadosPunto.TabIndex = 72
        Me.chboxAtadosPunto.Text = "Por Punto"
        Me.chboxAtadosPunto.UseVisualStyleBackColor = True
        '
        'chboxParesDestallados
        '
        Me.chboxParesDestallados.Checked = True
        Me.chboxParesDestallados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxParesDestallados.Location = New System.Drawing.Point(239, 15)
        Me.chboxParesDestallados.Name = "chboxParesDestallados"
        Me.chboxParesDestallados.Size = New System.Drawing.Size(111, 23)
        Me.chboxParesDestallados.TabIndex = 72
        Me.chboxParesDestallados.Text = "Pares Destallados"
        Me.chboxParesDestallados.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(387, 59)
        Me.pnlEncabezado.TabIndex = 121
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(36, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-265, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(652, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(339, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(245, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Parámetros de la Distribución" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(211, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 26)
        Me.Label18.TabIndex = 58
        Me.Label18.Text = " Actualizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Distribución"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 148)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(387, 75)
        Me.pnlPie.TabIndex = 122
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Label18)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnActualizarDistribucion)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(56, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(331, 75)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(284, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnActualizarDistribucion
        '
        Me.btnActualizarDistribucion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnActualizarDistribucion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizarDistribucion.Image = CType(resources.GetObject("btnActualizarDistribucion.Image"), System.Drawing.Image)
        Me.btnActualizarDistribucion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActualizarDistribucion.Location = New System.Drawing.Point(224, 8)
        Me.btnActualizarDistribucion.Name = "btnActualizarDistribucion"
        Me.btnActualizarDistribucion.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizarDistribucion.TabIndex = 59
        Me.btnActualizarDistribucion.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(283, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(584, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ParametrosApartadosPPCPForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(387, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.GroupBox9)
        Me.MaximumSize = New System.Drawing.Size(395, 250)
        Me.MinimumSize = New System.Drawing.Size(395, 250)
        Me.Name = "ParametrosApartadosPPCPForm"
        Me.Text = "Parámetros de la Distribución"
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents chboxDestallarPunto As System.Windows.Forms.CheckBox
    Friend WithEvents chboxDestallarNormales As System.Windows.Forms.CheckBox
    Friend WithEvents chboxAtadosPar As System.Windows.Forms.CheckBox
    Friend WithEvents chboxAtadosNon As System.Windows.Forms.CheckBox
    Friend WithEvents chboxAtadosPunto As System.Windows.Forms.CheckBox
    Friend WithEvents chboxParesDestallados As System.Windows.Forms.CheckBox
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnActualizarDistribucion As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
