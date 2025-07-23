<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModulosForm
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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.lblTitulo = New System.Windows.Forms.Label()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.lblEditar = New System.Windows.Forms.Label()
		Me.btnBorrar = New System.Windows.Forms.Button()
		Me.btnEditar = New System.Windows.Forms.Button()
		Me.btnAgregar = New System.Windows.Forms.Button()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.lblBorrar = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.White
		Me.Panel1.Controls.Add(Me.lblBorrar)
		Me.Panel1.Controls.Add(Me.btnBorrar)
		Me.Panel1.Controls.Add(Me.lblEditar)
		Me.Panel1.Controls.Add(Me.btnEditar)
		Me.Panel1.Controls.Add(Me.lblAltas)
		Me.Panel1.Controls.Add(Me.btnAgregar)
		Me.Panel1.Controls.Add(Me.lblTitulo)
		Me.Panel1.Controls.Add(Me.PictureBox1)
		Me.Panel1.Location = New System.Drawing.Point(1, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(700, 70)
		Me.Panel1.TabIndex = 0
		'
		'lblTitulo
		'
		Me.lblTitulo.AutoSize = True
		Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblTitulo.Location = New System.Drawing.Point(578, 47)
		Me.lblTitulo.Name = "lblTitulo"
		Me.lblTitulo.Size = New System.Drawing.Size(76, 20)
		Me.lblTitulo.TabIndex = 1
		Me.lblTitulo.Text = "Módulos"
		'
		'lblAltas
		'
		Me.lblAltas.AutoSize = True
		Me.lblAltas.Location = New System.Drawing.Point(25, 53)
		Me.lblAltas.Name = "lblAltas"
		Me.lblAltas.Size = New System.Drawing.Size(30, 13)
		Me.lblAltas.TabIndex = 1
		Me.lblAltas.Text = "Altas"
		'
		'lblEditar
		'
		Me.lblEditar.AutoSize = True
		Me.lblEditar.Location = New System.Drawing.Point(70, 53)
		Me.lblEditar.Name = "lblEditar"
		Me.lblEditar.Size = New System.Drawing.Size(34, 13)
		Me.lblEditar.TabIndex = 3
		Me.lblEditar.Text = "Editar"
		'
		'btnBorrar
		'
		Me.btnBorrar.BackColor = System.Drawing.Color.White
		Me.btnBorrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
		Me.btnBorrar.Image = Global.Framework.Vista.My.Resources.Resources.borrar_32
		Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnBorrar.Location = New System.Drawing.Point(113, 12)
		Me.btnBorrar.Name = "btnBorrar"
		Me.btnBorrar.Size = New System.Drawing.Size(40, 40)
		Me.btnBorrar.TabIndex = 3
		Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnBorrar.UseVisualStyleBackColor = False
		'
		'btnEditar
		'
		Me.btnEditar.BackColor = System.Drawing.Color.White
		Me.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
		Me.btnEditar.Image = Global.Framework.Vista.My.Resources.Resources.editar_32
		Me.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnEditar.Location = New System.Drawing.Point(67, 12)
		Me.btnEditar.Name = "btnEditar"
		Me.btnEditar.Size = New System.Drawing.Size(40, 40)
		Me.btnEditar.TabIndex = 2
		Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnEditar.UseVisualStyleBackColor = False
		'
		'btnAgregar
		'
		Me.btnAgregar.BackColor = System.Drawing.Color.White
		Me.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
		Me.btnAgregar.Image = Global.Framework.Vista.My.Resources.Resources.nuevo_32
		Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnAgregar.Location = New System.Drawing.Point(21, 12)
		Me.btnAgregar.Name = "btnAgregar"
		Me.btnAgregar.Size = New System.Drawing.Size(40, 40)
		Me.btnAgregar.TabIndex = 1
		Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnAgregar.UseVisualStyleBackColor = False
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = Global.Framework.Vista.My.Resources.Resources.yuyin
		Me.PictureBox1.Location = New System.Drawing.Point(551, -2)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(132, 48)
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		'
		'lblBorrar
		'
		Me.lblBorrar.AutoSize = True
		Me.lblBorrar.Location = New System.Drawing.Point(115, 53)
		Me.lblBorrar.Name = "lblBorrar"
		Me.lblBorrar.Size = New System.Drawing.Size(35, 13)
		Me.lblBorrar.TabIndex = 4
		Me.lblBorrar.Text = "Borrar"
		'
		'ModulosForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(684, 462)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "ModulosForm"
		Me.Text = "ModulosForm"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
	Friend WithEvents lblTitulo As System.Windows.Forms.Label
	Friend WithEvents btnAgregar As System.Windows.Forms.Button
	Friend WithEvents btnEditar As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents lblEditar As System.Windows.Forms.Label
	Friend WithEvents btnBorrar As System.Windows.Forms.Button
	Friend WithEvents lblBorrar As System.Windows.Forms.Label
End Class
