<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarEditarMotivosCancelacionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarEditarMotivosCancelacionForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaCatalogoRamos = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtDescripcionCancelacion = New System.Windows.Forms.TextBox()
        Me.txtNombreMotivo = New System.Windows.Forms.TextBox()
        Me.lblDescripcionCancelacion = New System.Windows.Forms.Label()
        Me.lblMotivoCancelacion = New System.Windows.Forms.Label()
        Me.rdono = New System.Windows.Forms.RadioButton()
        Me.rdosi = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblListaCatalogoRamos)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(428, 53)
        Me.pnlEncabezado.TabIndex = 72
        '
        'lblListaCatalogoRamos
        '
        Me.lblListaCatalogoRamos.AutoSize = True
        Me.lblListaCatalogoRamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaCatalogoRamos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaCatalogoRamos.Location = New System.Drawing.Point(190, 9)
        Me.lblListaCatalogoRamos.Name = "lblListaCatalogoRamos"
        Me.lblListaCatalogoRamos.Size = New System.Drawing.Size(164, 20)
        Me.lblListaCatalogoRamos.TabIndex = 46
        Me.lblListaCatalogoRamos.Text = "Motivo Cancelación"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblCerrar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(428, 221)
        Me.Panel1.TabIndex = 73
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(355, 190)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 38
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(292, 189)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 37
        Me.lblGuardar.Text = "Guardar"
        '
        'btnClose
        '
        Me.btnClose.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnClose.Location = New System.Drawing.Point(358, 153)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(32, 32)
        Me.btnClose.TabIndex = 36
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardar.Location = New System.Drawing.Point(299, 153)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 35
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblActivo)
        Me.GroupBox1.Controls.Add(Me.txtDescripcionCancelacion)
        Me.GroupBox1.Controls.Add(Me.txtNombreMotivo)
        Me.GroupBox1.Controls.Add(Me.lblDescripcionCancelacion)
        Me.GroupBox1.Controls.Add(Me.lblMotivoCancelacion)
        Me.GroupBox1.Controls.Add(Me.rdono)
        Me.GroupBox1.Controls.Add(Me.rdosi)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 127)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Motivo Cancelación"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(6, 100)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 6
        Me.lblActivo.Text = "Activo"
        '
        'txtDescripcionCancelacion
        '
        Me.txtDescripcionCancelacion.Location = New System.Drawing.Point(101, 57)
        Me.txtDescripcionCancelacion.Name = "txtDescripcionCancelacion"
        Me.txtDescripcionCancelacion.Size = New System.Drawing.Size(250, 20)
        Me.txtDescripcionCancelacion.TabIndex = 5
        '
        'txtNombreMotivo
        '
        Me.txtNombreMotivo.Location = New System.Drawing.Point(101, 30)
        Me.txtNombreMotivo.Name = "txtNombreMotivo"
        Me.txtNombreMotivo.Size = New System.Drawing.Size(250, 20)
        Me.txtNombreMotivo.TabIndex = 4
        '
        'lblDescripcionCancelacion
        '
        Me.lblDescripcionCancelacion.AutoSize = True
        Me.lblDescripcionCancelacion.Location = New System.Drawing.Point(24, 62)
        Me.lblDescripcionCancelacion.Name = "lblDescripcionCancelacion"
        Me.lblDescripcionCancelacion.Size = New System.Drawing.Size(67, 13)
        Me.lblDescripcionCancelacion.TabIndex = 3
        Me.lblDescripcionCancelacion.Text = "*Descripción"
        '
        'lblMotivoCancelacion
        '
        Me.lblMotivoCancelacion.AutoSize = True
        Me.lblMotivoCancelacion.Location = New System.Drawing.Point(24, 34)
        Me.lblMotivoCancelacion.Name = "lblMotivoCancelacion"
        Me.lblMotivoCancelacion.Size = New System.Drawing.Size(43, 13)
        Me.lblMotivoCancelacion.TabIndex = 2
        Me.lblMotivoCancelacion.Text = "*Motivo"
        '
        'rdono
        '
        Me.rdono.AutoSize = True
        Me.rdono.Location = New System.Drawing.Point(137, 100)
        Me.rdono.Name = "rdono"
        Me.rdono.Size = New System.Drawing.Size(39, 17)
        Me.rdono.TabIndex = 0
        Me.rdono.Text = "No"
        Me.rdono.UseVisualStyleBackColor = True
        '
        'rdosi
        '
        Me.rdosi.AutoSize = True
        Me.rdosi.Checked = True
        Me.rdosi.Location = New System.Drawing.Point(73, 100)
        Me.rdosi.Name = "rdosi"
        Me.rdosi.Size = New System.Drawing.Size(34, 17)
        Me.rdosi.TabIndex = 1
        Me.rdosi.TabStop = True
        Me.rdosi.Text = "Si"
        Me.rdosi.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(360, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgregarEditarMotivosCancelacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 274)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AgregarEditarMotivosCancelacionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motivo Cancelación"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblListaCatalogoRamos As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdono As RadioButton
    Friend WithEvents rdosi As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblActivo As Label
    Friend WithEvents txtDescripcionCancelacion As TextBox
    Friend WithEvents txtNombreMotivo As TextBox
    Friend WithEvents lblDescripcionCancelacion As Label
    Friend WithEvents lblMotivoCancelacion As Label
    Friend WithEvents lblCerrar As Label
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
