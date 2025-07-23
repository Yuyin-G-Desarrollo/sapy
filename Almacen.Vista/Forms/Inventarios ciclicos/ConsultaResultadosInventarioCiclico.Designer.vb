<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaResultadosInventarioCiclico
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
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dateFin = New System.Windows.Forms.DateTimePicker()
        Me.grbDias = New System.Windows.Forms.GroupBox()
        Me.txtObservaciones = New System.Windows.Forms.RichTextBox()
        Me.DateStart = New System.Windows.Forms.DateTimePicker()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDias.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Controls.Add(Me.btnMostrar)
        Me.pnlCabecera.Controls.Add(Me.lblBuscar)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(381, 60)
        Me.pnlCabecera.TabIndex = 8
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(101, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(210, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(43, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(164, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Inventarios Cíclicos"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(311, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = Global.Almacen.Vista.My.Resources.Resources.imprimir_32
        Me.btnMostrar.Location = New System.Drawing.Point(12, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 30
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(8, 42)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 32
        Me.lblBuscar.Text = "Imprimir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(44, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Fecha Fin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(44, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Fecha Inicio"
        '
        'dateFin
        '
        Me.dateFin.CustomFormat = "yyyy/MM/dd"
        Me.dateFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFin.Location = New System.Drawing.Point(144, 75)
        Me.dateFin.Name = "dateFin"
        Me.dateFin.Size = New System.Drawing.Size(200, 20)
        Me.dateFin.TabIndex = 24
        '
        'grbDias
        '
        Me.grbDias.Controls.Add(Me.lblObservaciones)
        Me.grbDias.Controls.Add(Me.txtObservaciones)
        Me.grbDias.Controls.Add(Me.DateStart)
        Me.grbDias.Controls.Add(Me.Label3)
        Me.grbDias.Controls.Add(Me.dateFin)
        Me.grbDias.Controls.Add(Me.Label2)
        Me.grbDias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbDias.Location = New System.Drawing.Point(0, 60)
        Me.grbDias.Name = "grbDias"
        Me.grbDias.Size = New System.Drawing.Size(381, 133)
        Me.grbDias.TabIndex = 27
        Me.grbDias.TabStop = False
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(0, 33)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(369, 97)
        Me.txtObservaciones.TabIndex = 28
        Me.txtObservaciones.Text = ""
        Me.txtObservaciones.Visible = False
        '
        'DateStart
        '
        Me.DateStart.CustomFormat = "yyyy/MM/dd"
        Me.DateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateStart.Location = New System.Drawing.Point(144, 38)
        Me.DateStart.Name = "DateStart"
        Me.DateStart.Size = New System.Drawing.Size(200, 20)
        Me.DateStart.TabIndex = 27
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(5, 17)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 29
        Me.lblObservaciones.Text = "Observaciones:"
        Me.lblObservaciones.Visible = False
        '
        'ConsultaResultadosInventarioCiclico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(381, 193)
        Me.Controls.Add(Me.grbDias)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(397, 232)
        Me.Name = "ConsultaResultadosInventarioCiclico"
        Me.Text = "Inventarios Cíclicos"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDias.ResumeLayout(False)
        Me.grbDias.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dateFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents grbDias As System.Windows.Forms.GroupBox
    Friend WithEvents DateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservaciones As System.Windows.Forms.RichTextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
End Class
