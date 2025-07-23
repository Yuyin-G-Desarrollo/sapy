<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevolucionCliente_CancelarDevolucion_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_CancelarDevolucion_Form))
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFolioDev = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.groupHeader = New System.Windows.Forms.GroupBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.nudCantidadPares = New System.Windows.Forms.NumericUpDown()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.cmbMotivoCancelacion = New System.Windows.Forms.ComboBox()
        Me.lblMotivoCancelacion = New System.Windows.Forms.Label()
        Me.lblParesCancelados = New System.Windows.Forms.Label()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.groupHeader.SuspendLayout()
        CType(Me.nudCantidadPares, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(523, 59)
        Me.pnlCabecera.TabIndex = 2
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(523, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(523, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(455, 41)
        Me.Panel1.TabIndex = 47
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(183, 41)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(282, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(173, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Cancelar Devolución"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(455, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 300)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(523, 65)
        Me.pnlPie.TabIndex = 65
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(379, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 65)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(95, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(31, 43)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(45, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(92, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_321
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(36, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'pnlContenido
        '
        Me.pnlContenido.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenido.Controls.Add(Me.Label8)
        Me.pnlContenido.Controls.Add(Me.lblFolioDev)
        Me.pnlContenido.Controls.Add(Me.lblCliente)
        Me.pnlContenido.Controls.Add(Me.groupHeader)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 59)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(523, 241)
        Me.pnlContenido.TabIndex = 66
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(5, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 16)
        Me.Label8.TabIndex = 207
        Me.Label8.Text = "Folio de Devolución"
        '
        'lblFolioDev
        '
        Me.lblFolioDev.AutoSize = True
        Me.lblFolioDev.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioDev.ForeColor = System.Drawing.Color.Black
        Me.lblFolioDev.Location = New System.Drawing.Point(158, 5)
        Me.lblFolioDev.Name = "lblFolioDev"
        Me.lblFolioDev.Size = New System.Drawing.Size(51, 25)
        Me.lblFolioDev.TabIndex = 208
        Me.lblFolioDev.Text = "589"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(5, 35)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(173, 16)
        Me.lblCliente.TabIndex = 209
        Me.lblCliente.Text = "NOMBRE DEL CLIENTE"
        '
        'groupHeader
        '
        Me.groupHeader.BackColor = System.Drawing.Color.AliceBlue
        Me.groupHeader.Controls.Add(Me.txtObservaciones)
        Me.groupHeader.Controls.Add(Me.nudCantidadPares)
        Me.groupHeader.Controls.Add(Me.lblObservaciones)
        Me.groupHeader.Controls.Add(Me.cmbMotivoCancelacion)
        Me.groupHeader.Controls.Add(Me.lblMotivoCancelacion)
        Me.groupHeader.Controls.Add(Me.lblParesCancelados)
        Me.groupHeader.Location = New System.Drawing.Point(4, 54)
        Me.groupHeader.Name = "groupHeader"
        Me.groupHeader.Size = New System.Drawing.Size(514, 173)
        Me.groupHeader.TabIndex = 79
        Me.groupHeader.TabStop = False
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtObservaciones.Location = New System.Drawing.Point(139, 73)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(359, 86)
        Me.txtObservaciones.TabIndex = 3
        '
        'nudCantidadPares
        '
        Me.nudCantidadPares.Enabled = False
        Me.nudCantidadPares.Location = New System.Drawing.Point(139, 45)
        Me.nudCantidadPares.Name = "nudCantidadPares"
        Me.nudCantidadPares.ReadOnly = True
        Me.nudCantidadPares.Size = New System.Drawing.Size(120, 20)
        Me.nudCantidadPares.TabIndex = 2
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(11, 73)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(85, 13)
        Me.lblObservaciones.TabIndex = 94
        Me.lblObservaciones.Text = "* Observaciones"
        '
        'cmbMotivoCancelacion
        '
        Me.cmbMotivoCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivoCancelacion.FormattingEnabled = True
        Me.cmbMotivoCancelacion.Items.AddRange(New Object() {"DEVOLUCION_CLIENTE_MOTIVO_CANCELACION", "DEVOLUCION_CLIENTE_MOTIVO_INICIAL", "DEVOLUCION_CLIENTE_MOTIVO_VENTAS"})
        Me.cmbMotivoCancelacion.Location = New System.Drawing.Point(139, 17)
        Me.cmbMotivoCancelacion.Name = "cmbMotivoCancelacion"
        Me.cmbMotivoCancelacion.Size = New System.Drawing.Size(359, 21)
        Me.cmbMotivoCancelacion.TabIndex = 1
        '
        'lblMotivoCancelacion
        '
        Me.lblMotivoCancelacion.AutoSize = True
        Me.lblMotivoCancelacion.Location = New System.Drawing.Point(10, 20)
        Me.lblMotivoCancelacion.Name = "lblMotivoCancelacion"
        Me.lblMotivoCancelacion.Size = New System.Drawing.Size(123, 13)
        Me.lblMotivoCancelacion.TabIndex = 2
        Me.lblMotivoCancelacion.Text = "* Motivo de Cancelación"
        '
        'lblParesCancelados
        '
        Me.lblParesCancelados.AutoSize = True
        Me.lblParesCancelados.Location = New System.Drawing.Point(10, 47)
        Me.lblParesCancelados.Name = "lblParesCancelados"
        Me.lblParesCancelados.Size = New System.Drawing.Size(95, 13)
        Me.lblParesCancelados.TabIndex = 3
        Me.lblParesCancelados.Text = "* Pares a Cancelar"
        '
        'DevolucionCliente_CancelarDevolucion_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 365)
        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DevolucionCliente_CancelarDevolucion_Form"
        Me.Text = "Cancelar Devolución"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenido.PerformLayout()
        Me.groupHeader.ResumeLayout(False)
        Me.groupHeader.PerformLayout()
        CType(Me.nudCantidadPares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlMarcarTodo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents groupHeader As GroupBox
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents cmbMotivoCancelacion As ComboBox
    Friend WithEvents lblMotivoCancelacion As Label
    Friend WithEvents lblParesCancelados As Label
    Friend WithEvents nudCantidadPares As NumericUpDown
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblFolioDev As Label
    Friend WithEvents lblCliente As Label
End Class
