<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevolucionCliente_EntregaAEmbarques_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_EntregaAEmbarques_Form))
        Me.groupHeader = New System.Windows.Forms.GroupBox()
        Me.txtUsuarioRecibe = New System.Windows.Forms.TextBox()
        Me.txtUsuarioEntrega = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblUnidad = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFolioDev = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblTipoMotivo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.groupHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupHeader
        '
        Me.groupHeader.BackColor = System.Drawing.Color.AliceBlue
        Me.groupHeader.Controls.Add(Me.txtUsuarioRecibe)
        Me.groupHeader.Controls.Add(Me.txtUsuarioEntrega)
        Me.groupHeader.Controls.Add(Me.Label4)
        Me.groupHeader.Controls.Add(Me.lblUnidad)
        Me.groupHeader.Controls.Add(Me.lblCantidad)
        Me.groupHeader.Controls.Add(Me.Label1)
        Me.groupHeader.Controls.Add(Me.Label8)
        Me.groupHeader.Controls.Add(Me.lblFolioDev)
        Me.groupHeader.Controls.Add(Me.lblCliente)
        Me.groupHeader.Controls.Add(Me.lblTipoMotivo)
        Me.groupHeader.Location = New System.Drawing.Point(7, 64)
        Me.groupHeader.Name = "groupHeader"
        Me.groupHeader.Size = New System.Drawing.Size(514, 164)
        Me.groupHeader.TabIndex = 81
        Me.groupHeader.TabStop = False
        '
        'txtUsuarioRecibe
        '
        Me.txtUsuarioRecibe.Location = New System.Drawing.Point(143, 129)
        Me.txtUsuarioRecibe.Name = "txtUsuarioRecibe"
        Me.txtUsuarioRecibe.ReadOnly = True
        Me.txtUsuarioRecibe.Size = New System.Drawing.Size(354, 20)
        Me.txtUsuarioRecibe.TabIndex = 215
        '
        'txtUsuarioEntrega
        '
        Me.txtUsuarioEntrega.Location = New System.Drawing.Point(143, 95)
        Me.txtUsuarioEntrega.Name = "txtUsuarioEntrega"
        Me.txtUsuarioEntrega.ReadOnly = True
        Me.txtUsuarioEntrega.Size = New System.Drawing.Size(354, 20)
        Me.txtUsuarioEntrega.TabIndex = 214
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 13)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "* Recibe (Embarques)"
        '
        'lblUnidad
        '
        Me.lblUnidad.AutoSize = True
        Me.lblUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidad.Location = New System.Drawing.Point(116, 65)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(19, 15)
        Me.lblUnidad.TabIndex = 212
        Me.lblUnidad.Text = "(-)"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(67, 65)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(14, 15)
        Me.lblCantidad.TabIndex = 211
        Me.lblCantidad.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 210
        Me.Label1.Text = "Cantidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(13, 21)
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
        Me.lblFolioDev.Location = New System.Drawing.Point(166, 16)
        Me.lblFolioDev.Name = "lblFolioDev"
        Me.lblFolioDev.Size = New System.Drawing.Size(20, 25)
        Me.lblFolioDev.TabIndex = 208
        Me.lblFolioDev.Text = "-"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(13, 41)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(13, 16)
        Me.lblCliente.TabIndex = 209
        Me.lblCliente.Text = "-"
        '
        'lblTipoMotivo
        '
        Me.lblTipoMotivo.AutoSize = True
        Me.lblTipoMotivo.Location = New System.Drawing.Point(12, 98)
        Me.lblTipoMotivo.Name = "lblTipoMotivo"
        Me.lblTipoMotivo.Size = New System.Drawing.Size(125, 13)
        Me.lblTipoMotivo.TabIndex = 2
        Me.lblTipoMotivo.Text = "* Entrega (Devoluciones)"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pnlEncabezado)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(531, 61)
        Me.pnlTitulo.TabIndex = 80
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(463, 61)
        Me.pnlEncabezado.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(129, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(333, 20)
        Me.lblTitulo.TabIndex = 47
        Me.lblTitulo.Text = "Recepción de Devolución en Embarques"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.BackColor = System.Drawing.Color.White
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(463, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 61)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 237)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(531, 61)
        Me.pnlPie.TabIndex = 79
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(387, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 61)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(86, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(25, 39)
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
        Me.lblCancelar.Location = New System.Drawing.Point(86, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(29, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'DevolucionCliente_EntregaAEmbarques_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(531, 298)
        Me.Controls.Add(Me.groupHeader)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.pnlPie)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DevolucionCliente_EntregaAEmbarques_Form"
        Me.Text = "Recepción de Devolución en Embarques"
        Me.groupHeader.ResumeLayout(False)
        Me.groupHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupHeader As GroupBox
    Friend WithEvents lblTipoMotivo As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lblUnidad As Label
    Friend WithEvents lblCantidad As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblFolioDev As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents txtUsuarioRecibe As TextBox
    Friend WithEvents txtUsuarioEntrega As TextBox
End Class
