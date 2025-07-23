<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentosExtranjeros_Paridad_Form
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblGuardarCancelacion = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtParidad = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblOts = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(411, 305)
        Me.Panel1.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 241)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(411, 4)
        Me.Panel3.TabIndex = 27
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 245)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(411, 60)
        Me.pnlPie.TabIndex = 26
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardarCancelacion)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(249, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblGuardarCancelacion
        '
        Me.lblGuardarCancelacion.AutoSize = True
        Me.lblGuardarCancelacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarCancelacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardarCancelacion.Location = New System.Drawing.Point(64, 40)
        Me.lblGuardarCancelacion.Name = "lblGuardarCancelacion"
        Me.lblGuardarCancelacion.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarCancelacion.TabIndex = 0
        Me.lblGuardarCancelacion.Text = "Guardar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(70, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.Label8)
        Me.pnlParametros.Controls.Add(Me.txtParidad)
        Me.pnlParametros.Controls.Add(Me.Label7)
        Me.pnlParametros.Controls.Add(Me.lblMoneda)
        Me.pnlParametros.Controls.Add(Me.Label5)
        Me.pnlParametros.Controls.Add(Me.lblCliente)
        Me.pnlParametros.Controls.Add(Me.Label3)
        Me.pnlParametros.Controls.Add(Me.lblOts)
        Me.pnlParametros.Controls.Add(Me.Label2)
        Me.pnlParametros.Controls.Add(Me.Label1)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(411, 176)
        Me.pnlParametros.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(229, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(159, 13)
        Me.Label8.TabIndex = 115
        Me.Label8.Text = "Puede tener hasta 4 decimales. "
        '
        'txtParidad
        '
        Me.txtParidad.Location = New System.Drawing.Point(127, 99)
        Me.txtParidad.Mask = "999,999.0000"
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(96, 20)
        Me.txtParidad.TabIndex = 114
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(72, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(281, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Todos los documentos se generarán con la misma paridad"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(87, 64)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(58, 13)
        Me.lblMoneda.TabIndex = 6
        Me.lblMoneda.Text = "DÓLARES"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Moneda:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(87, 17)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(177, 13)
        Me.lblCliente.TabIndex = 4
        Me.lblCliente.Text = "ZAPATOS IMPORTADOS MARIAN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cliente"
        '
        'lblOts
        '
        Me.lblOts.AutoSize = True
        Me.lblOts.Location = New System.Drawing.Point(87, 41)
        Me.lblOts.Name = "lblOts"
        Me.lblOts.Size = New System.Drawing.Size(145, 13)
        Me.lblOts.TabIndex = 2
        Me.lblOts.Text = "60471, 60472, 60473, 60474"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "OT:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "*Paridad (Pesos) $"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(411, 65)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-162, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(573, 65)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(410, 25)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(75, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Paridad "
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(490, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'DocumentosExtranjeros_Paridad_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 305)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "DocumentosExtranjeros_Paridad_Form"
        Me.Text = "DocumentosExtranjeros_Paridad_Form"
        Me.Panel1.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblGuardarCancelacion As Label
    Friend WithEvents lblCerrar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents txtParidad As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblMoneda As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblOts As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
End Class
