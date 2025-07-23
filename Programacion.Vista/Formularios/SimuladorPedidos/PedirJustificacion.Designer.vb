<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedirJustificacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lbltituloFecha = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.groupContenedor = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreJustificacion = New System.Windows.Forms.TextBox()
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupContenedor.SuspendLayout()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(437, 60)
        Me.pnlHeader.TabIndex = 10
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lbltituloFecha)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(217, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(220, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lbltituloFecha
        '
        Me.lbltituloFecha.AutoSize = True
        Me.lbltituloFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltituloFecha.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbltituloFecha.Location = New System.Drawing.Point(4, 20)
        Me.lbltituloFecha.Name = "lbltituloFecha"
        Me.lbltituloFecha.Size = New System.Drawing.Size(128, 20)
        Me.lbltituloFecha.TabIndex = 2
        Me.lbltituloFecha.Text = "Justificaciones"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(152, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'groupContenedor
        '
        Me.groupContenedor.Controls.Add(Me.Label1)
        Me.groupContenedor.Controls.Add(Me.txtNombreJustificacion)
        Me.groupContenedor.Location = New System.Drawing.Point(27, 76)
        Me.groupContenedor.Name = "groupContenedor"
        Me.groupContenedor.Size = New System.Drawing.Size(382, 70)
        Me.groupContenedor.TabIndex = 12
        Me.groupContenedor.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "*Nombre"
        '
        'txtNombreJustificacion
        '
        Me.txtNombreJustificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreJustificacion.Location = New System.Drawing.Point(100, 25)
        Me.txtNombreJustificacion.Name = "txtNombreJustificacion"
        Me.txtNombreJustificacion.Size = New System.Drawing.Size(257, 20)
        Me.txtNombreJustificacion.TabIndex = 1
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 163)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(437, 60)
        Me.pnlExtado.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(303, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(134, 60)
        Me.Panel1.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(75, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(17, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(23, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(76, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'PedirJustificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(437, 223)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.groupContenedor)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PedirJustificacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Justificaciones"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupContenedor.ResumeLayout(False)
        Me.groupContenedor.PerformLayout()
        Me.pnlExtado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lbltituloFecha As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents groupContenedor As System.Windows.Forms.GroupBox
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtNombreJustificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
