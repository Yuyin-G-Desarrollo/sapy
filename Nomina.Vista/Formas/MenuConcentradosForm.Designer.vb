<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuConcentradosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuConcentradosForm))
        Me.chkAltas = New System.Windows.Forms.CheckBox()
        Me.chkBajas = New System.Windows.Forms.CheckBox()
        Me.chkCumpleañeros = New System.Windows.Forms.CheckBox()
        Me.chkDeducExtr = New System.Windows.Forms.CheckBox()
        Me.chkDeduccionesImss = New System.Windows.Forms.CheckBox()
        Me.chkGratificaciones = New System.Windows.Forms.CheckBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkAltas
        '
        Me.chkAltas.AutoSize = True
        Me.chkAltas.ForeColor = System.Drawing.Color.Black
        Me.chkAltas.Location = New System.Drawing.Point(32, 174)
        Me.chkAltas.Name = "chkAltas"
        Me.chkAltas.Size = New System.Drawing.Size(88, 17)
        Me.chkAltas.TabIndex = 0
        Me.chkAltas.Text = "Alta Personal"
        Me.chkAltas.UseVisualStyleBackColor = True
        '
        'chkBajas
        '
        Me.chkBajas.AutoSize = True
        Me.chkBajas.ForeColor = System.Drawing.Color.Black
        Me.chkBajas.Location = New System.Drawing.Point(32, 197)
        Me.chkBajas.Name = "chkBajas"
        Me.chkBajas.Size = New System.Drawing.Size(96, 17)
        Me.chkBajas.TabIndex = 1
        Me.chkBajas.Text = "Bajas Personal"
        Me.chkBajas.UseVisualStyleBackColor = True
        '
        'chkCumpleañeros
        '
        Me.chkCumpleañeros.AutoSize = True
        Me.chkCumpleañeros.ForeColor = System.Drawing.Color.Black
        Me.chkCumpleañeros.Location = New System.Drawing.Point(32, 220)
        Me.chkCumpleañeros.Name = "chkCumpleañeros"
        Me.chkCumpleañeros.Size = New System.Drawing.Size(93, 17)
        Me.chkCumpleañeros.TabIndex = 2
        Me.chkCumpleañeros.Text = "Cumpleañeros"
        Me.chkCumpleañeros.UseVisualStyleBackColor = True
        '
        'chkDeducExtr
        '
        Me.chkDeducExtr.AutoSize = True
        Me.chkDeducExtr.ForeColor = System.Drawing.Color.Black
        Me.chkDeducExtr.Location = New System.Drawing.Point(32, 243)
        Me.chkDeducExtr.Name = "chkDeducExtr"
        Me.chkDeducExtr.Size = New System.Drawing.Size(158, 17)
        Me.chkDeducExtr.TabIndex = 3
        Me.chkDeducExtr.Text = "Deducciones Extraodinarias"
        Me.chkDeducExtr.UseVisualStyleBackColor = True
        '
        'chkDeduccionesImss
        '
        Me.chkDeduccionesImss.AutoSize = True
        Me.chkDeduccionesImss.ForeColor = System.Drawing.Color.Black
        Me.chkDeduccionesImss.Location = New System.Drawing.Point(32, 266)
        Me.chkDeduccionesImss.Name = "chkDeduccionesImss"
        Me.chkDeduccionesImss.Size = New System.Drawing.Size(118, 17)
        Me.chkDeduccionesImss.TabIndex = 4
        Me.chkDeduccionesImss.Text = "Deducciones IMSS"
        Me.chkDeduccionesImss.UseVisualStyleBackColor = True
        '
        'chkGratificaciones
        '
        Me.chkGratificaciones.AutoSize = True
        Me.chkGratificaciones.ForeColor = System.Drawing.Color.Black
        Me.chkGratificaciones.Location = New System.Drawing.Point(32, 289)
        Me.chkGratificaciones.Name = "chkGratificaciones"
        Me.chkGratificaciones.Size = New System.Drawing.Size(139, 17)
        Me.chkGratificaciones.TabIndex = 5
        Me.chkGratificaciones.Text = "Gratificaciones (EXCEL)"
        Me.chkGratificaciones.UseVisualStyleBackColor = True
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Location = New System.Drawing.Point(32, 133)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(118, 20)
        Me.dtpFechaInicio.TabIndex = 6
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Location = New System.Drawing.Point(189, 132)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(118, 20)
        Me.dtpFechaFin.TabIndex = 7
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Label1)
        Me.pnlListaPaises.Controls.Add(Me.btnImprimir)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(358, 59)
        Me.pnlListaPaises.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(9, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(12, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(31, 32)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(167, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(191, 59)
        Me.Panel1.TabIndex = 5
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(18, 24)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(121, 20)
        Me.lblEncabezado.TabIndex = 9
        Me.lblEncabezado.Text = "Concentrados"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Del"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(156, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Al"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(51, 90)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(121, 21)
        Me.cmbNave.TabIndex = 17
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(123, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 47
        Me.pcbTitulo.TabStop = False
        '
        'MenuConcentradosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(358, 323)
        Me.Controls.Add(Me.cmbNave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.dtpFechaFin)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.chkGratificaciones)
        Me.Controls.Add(Me.chkDeduccionesImss)
        Me.Controls.Add(Me.chkDeducExtr)
        Me.Controls.Add(Me.chkCumpleañeros)
        Me.Controls.Add(Me.chkBajas)
        Me.Controls.Add(Me.chkAltas)
        Me.Name = "MenuConcentradosForm"
        Me.Text = "MenuConcentradosForm"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkAltas As System.Windows.Forms.CheckBox
    Friend WithEvents chkBajas As System.Windows.Forms.CheckBox
    Friend WithEvents chkCumpleañeros As System.Windows.Forms.CheckBox
    Friend WithEvents chkDeducExtr As System.Windows.Forms.CheckBox
    Friend WithEvents chkDeduccionesImss As System.Windows.Forms.CheckBox
    Friend WithEvents chkGratificaciones As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
