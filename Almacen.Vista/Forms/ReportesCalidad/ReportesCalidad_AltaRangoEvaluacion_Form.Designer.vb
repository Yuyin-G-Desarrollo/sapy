<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportesCalidad_AltaRangoEvaluacion_Form
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
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblEtiquetaCriterio = New System.Windows.Forms.Label()
        Me.nudPuntuacion = New System.Windows.Forms.NumericUpDown()
        Me.lblEtiquetaValorInicial = New System.Windows.Forms.Label()
        Me.nudValorFinal = New System.Windows.Forms.NumericUpDown()
        Me.lblEtiquetaValorFinal = New System.Windows.Forms.Label()
        Me.nudValorInicial = New System.Windows.Forms.NumericUpDown()
        Me.lblEtiquetaPuntuacion = New System.Windows.Forms.Label()
        Me.cmbCriterio = New System.Windows.Forms.ComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblEtiquetaNave = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContenido.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudPuntuacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudValorFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudValorInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPie.Location = New System.Drawing.Point(0, 260)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(426, 60)
        Me.pnlPie.TabIndex = 31
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.Label6)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(302, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(124, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(27, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(21, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(78, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(77, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(426, 65)
        Me.pnlEncabezado.TabIndex = 32
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-491, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(917, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(564, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(270, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Criterios de Evaluación Por Nave"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(840, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(77, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlContenido
        '
        Me.pnlContenido.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenido.Controls.Add(Me.GroupBox1)
        Me.pnlContenido.Controls.Add(Me.Panel6)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 65)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(426, 195)
        Me.pnlContenido.TabIndex = 33
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaCriterio)
        Me.GroupBox1.Controls.Add(Me.nudPuntuacion)
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaValorInicial)
        Me.GroupBox1.Controls.Add(Me.nudValorFinal)
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaValorFinal)
        Me.GroupBox1.Controls.Add(Me.nudValorInicial)
        Me.GroupBox1.Controls.Add(Me.lblEtiquetaPuntuacion)
        Me.GroupBox1.Controls.Add(Me.cmbCriterio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(402, 156)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        '
        'lblEtiquetaCriterio
        '
        Me.lblEtiquetaCriterio.AutoSize = True
        Me.lblEtiquetaCriterio.Location = New System.Drawing.Point(6, 16)
        Me.lblEtiquetaCriterio.Name = "lblEtiquetaCriterio"
        Me.lblEtiquetaCriterio.Size = New System.Drawing.Size(42, 13)
        Me.lblEtiquetaCriterio.TabIndex = 0
        Me.lblEtiquetaCriterio.Text = "Criterio:"
        '
        'nudPuntuacion
        '
        Me.nudPuntuacion.Location = New System.Drawing.Point(92, 114)
        Me.nudPuntuacion.Name = "nudPuntuacion"
        Me.nudPuntuacion.Size = New System.Drawing.Size(100, 20)
        Me.nudPuntuacion.TabIndex = 54
        '
        'lblEtiquetaValorInicial
        '
        Me.lblEtiquetaValorInicial.AutoSize = True
        Me.lblEtiquetaValorInicial.Location = New System.Drawing.Point(6, 49)
        Me.lblEtiquetaValorInicial.Name = "lblEtiquetaValorInicial"
        Me.lblEtiquetaValorInicial.Size = New System.Drawing.Size(64, 13)
        Me.lblEtiquetaValorInicial.TabIndex = 48
        Me.lblEtiquetaValorInicial.Text = "Valor Inicial:"
        '
        'nudValorFinal
        '
        Me.nudValorFinal.Location = New System.Drawing.Point(92, 80)
        Me.nudValorFinal.Name = "nudValorFinal"
        Me.nudValorFinal.Size = New System.Drawing.Size(100, 20)
        Me.nudValorFinal.TabIndex = 53
        '
        'lblEtiquetaValorFinal
        '
        Me.lblEtiquetaValorFinal.AutoSize = True
        Me.lblEtiquetaValorFinal.Location = New System.Drawing.Point(6, 82)
        Me.lblEtiquetaValorFinal.Name = "lblEtiquetaValorFinal"
        Me.lblEtiquetaValorFinal.Size = New System.Drawing.Size(59, 13)
        Me.lblEtiquetaValorFinal.TabIndex = 49
        Me.lblEtiquetaValorFinal.Text = "Valor Final:"
        '
        'nudValorInicial
        '
        Me.nudValorInicial.Location = New System.Drawing.Point(92, 47)
        Me.nudValorInicial.Name = "nudValorInicial"
        Me.nudValorInicial.Size = New System.Drawing.Size(100, 20)
        Me.nudValorInicial.TabIndex = 52
        '
        'lblEtiquetaPuntuacion
        '
        Me.lblEtiquetaPuntuacion.AutoSize = True
        Me.lblEtiquetaPuntuacion.Location = New System.Drawing.Point(6, 116)
        Me.lblEtiquetaPuntuacion.Name = "lblEtiquetaPuntuacion"
        Me.lblEtiquetaPuntuacion.Size = New System.Drawing.Size(64, 13)
        Me.lblEtiquetaPuntuacion.TabIndex = 50
        Me.lblEtiquetaPuntuacion.Text = "Puntuación:"
        '
        'cmbCriterio
        '
        Me.cmbCriterio.FormattingEnabled = True
        Me.cmbCriterio.Items.AddRange(New Object() {"DEVOLUCIONES", "ALERTAS_MAYORES", "ALERTAS_MENORES"})
        Me.cmbCriterio.Location = New System.Drawing.Point(92, 13)
        Me.cmbCriterio.Name = "cmbCriterio"
        Me.cmbCriterio.Size = New System.Drawing.Size(284, 21)
        Me.cmbCriterio.TabIndex = 51
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblEtiquetaNave)
        Me.Panel6.Controls.Add(Me.lblNave)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(426, 27)
        Me.Panel6.TabIndex = 47
        '
        'lblEtiquetaNave
        '
        Me.lblEtiquetaNave.AutoSize = True
        Me.lblEtiquetaNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaNave.Location = New System.Drawing.Point(12, 6)
        Me.lblEtiquetaNave.Name = "lblEtiquetaNave"
        Me.lblEtiquetaNave.Size = New System.Drawing.Size(43, 15)
        Me.lblEtiquetaNave.TabIndex = 51
        Me.lblEtiquetaNave.Text = "Nave:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.Location = New System.Drawing.Point(66, 6)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(12, 15)
        Me.lblNave.TabIndex = 52
        Me.lblNave.Text = "-"
        '
        'ReportesCalidad_AltaRangoEvaluacion_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 320)
        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlPie)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(442, 359)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(442, 359)
        Me.Name = "ReportesCalidad_AltaRangoEvaluacion_Form"
        Me.Text = "Alta Rango de Evaluación"
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContenido.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudPuntuacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudValorFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudValorInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents lblEtiquetaCriterio As Label
    Friend WithEvents nudPuntuacion As NumericUpDown
    Friend WithEvents nudValorFinal As NumericUpDown
    Friend WithEvents nudValorInicial As NumericUpDown
    Friend WithEvents cmbCriterio As ComboBox
    Friend WithEvents lblEtiquetaPuntuacion As Label
    Friend WithEvents lblEtiquetaValorFinal As Label
    Friend WithEvents lblEtiquetaValorInicial As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblEtiquetaNave As Label
    Friend WithEvents lblNave As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
