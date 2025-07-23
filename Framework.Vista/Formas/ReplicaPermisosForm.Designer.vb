<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReplicaPermisosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReplicaPermisosForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblReplicaPermisos = New System.Windows.Forms.Label()
        Me.grpUsuarioOrigen = New System.Windows.Forms.GroupBox()
        Me.txtNombreColaboradorOrigen = New System.Windows.Forms.TextBox()
        Me.lblColaboradorOrigen = New System.Windows.Forms.Label()
        Me.lblBuscarUsuarioOrigen = New System.Windows.Forms.Label()
        Me.btnBuscarUsuarioOrigen = New System.Windows.Forms.Button()
        Me.txtUsuarioOrigen = New System.Windows.Forms.TextBox()
        Me.lblUsuarioOrigen = New System.Windows.Forms.Label()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.txtNombreColaboradorDestino = New System.Windows.Forms.TextBox()
        Me.lblColaboradorDestino = New System.Windows.Forms.Label()
        Me.lblBuscarUsuarioDestino = New System.Windows.Forms.Label()
        Me.txtUsuarioDestino = New System.Windows.Forms.TextBox()
        Me.lblUsuarioDestino = New System.Windows.Forms.Label()
        Me.grpUsuarioDestino = New System.Windows.Forms.GroupBox()
        Me.btnBuscarUsuarioDestino = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grpUsuarioOrigen.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.grpUsuarioDestino.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblReplicaPermisos)
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 2)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(674, 57)
        Me.pnlEncabezado.TabIndex = 4
        '
        'lblReplicaPermisos
        '
        Me.lblReplicaPermisos.AutoSize = True
        Me.lblReplicaPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReplicaPermisos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblReplicaPermisos.Location = New System.Drawing.Point(453, 19)
        Me.lblReplicaPermisos.Name = "lblReplicaPermisos"
        Me.lblReplicaPermisos.Size = New System.Drawing.Size(153, 20)
        Me.lblReplicaPermisos.TabIndex = 21
        Me.lblReplicaPermisos.Text = "Replicar Permisos"
        '
        'grpUsuarioOrigen
        '
        Me.grpUsuarioOrigen.Controls.Add(Me.txtNombreColaboradorOrigen)
        Me.grpUsuarioOrigen.Controls.Add(Me.lblColaboradorOrigen)
        Me.grpUsuarioOrigen.Controls.Add(Me.lblBuscarUsuarioOrigen)
        Me.grpUsuarioOrigen.Controls.Add(Me.btnBuscarUsuarioOrigen)
        Me.grpUsuarioOrigen.Controls.Add(Me.txtUsuarioOrigen)
        Me.grpUsuarioOrigen.Controls.Add(Me.lblUsuarioOrigen)
        Me.grpUsuarioOrigen.Location = New System.Drawing.Point(12, 83)
        Me.grpUsuarioOrigen.Name = "grpUsuarioOrigen"
        Me.grpUsuarioOrigen.Size = New System.Drawing.Size(322, 178)
        Me.grpUsuarioOrigen.TabIndex = 5
        Me.grpUsuarioOrigen.TabStop = False
        Me.grpUsuarioOrigen.Text = "Usuario Origen"
        '
        'txtNombreColaboradorOrigen
        '
        Me.txtNombreColaboradorOrigen.Enabled = False
        Me.txtNombreColaboradorOrigen.Location = New System.Drawing.Point(100, 104)
        Me.txtNombreColaboradorOrigen.Name = "txtNombreColaboradorOrigen"
        Me.txtNombreColaboradorOrigen.ReadOnly = True
        Me.txtNombreColaboradorOrigen.Size = New System.Drawing.Size(191, 20)
        Me.txtNombreColaboradorOrigen.TabIndex = 30
        '
        'lblColaboradorOrigen
        '
        Me.lblColaboradorOrigen.AutoSize = True
        Me.lblColaboradorOrigen.Location = New System.Drawing.Point(27, 107)
        Me.lblColaboradorOrigen.Name = "lblColaboradorOrigen"
        Me.lblColaboradorOrigen.Size = New System.Drawing.Size(67, 13)
        Me.lblColaboradorOrigen.TabIndex = 29
        Me.lblColaboradorOrigen.Text = "Colaborador:"
        '
        'lblBuscarUsuarioOrigen
        '
        Me.lblBuscarUsuarioOrigen.AutoSize = True
        Me.lblBuscarUsuarioOrigen.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscarUsuarioOrigen.Location = New System.Drawing.Point(251, 66)
        Me.lblBuscarUsuarioOrigen.Name = "lblBuscarUsuarioOrigen"
        Me.lblBuscarUsuarioOrigen.Size = New System.Drawing.Size(40, 13)
        Me.lblBuscarUsuarioOrigen.TabIndex = 28
        Me.lblBuscarUsuarioOrigen.Text = "Búscar"
        '
        'btnBuscarUsuarioOrigen
        '
        Me.btnBuscarUsuarioOrigen.Image = CType(resources.GetObject("btnBuscarUsuarioOrigen.Image"), System.Drawing.Image)
        Me.btnBuscarUsuarioOrigen.Location = New System.Drawing.Point(254, 31)
        Me.btnBuscarUsuarioOrigen.Name = "btnBuscarUsuarioOrigen"
        Me.btnBuscarUsuarioOrigen.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscarUsuarioOrigen.TabIndex = 27
        Me.btnBuscarUsuarioOrigen.UseVisualStyleBackColor = True
        '
        'txtUsuarioOrigen
        '
        Me.txtUsuarioOrigen.Enabled = False
        Me.txtUsuarioOrigen.Location = New System.Drawing.Point(100, 43)
        Me.txtUsuarioOrigen.Name = "txtUsuarioOrigen"
        Me.txtUsuarioOrigen.ReadOnly = True
        Me.txtUsuarioOrigen.Size = New System.Drawing.Size(130, 20)
        Me.txtUsuarioOrigen.TabIndex = 1
        '
        'lblUsuarioOrigen
        '
        Me.lblUsuarioOrigen.AutoSize = True
        Me.lblUsuarioOrigen.Location = New System.Drawing.Point(27, 46)
        Me.lblUsuarioOrigen.Name = "lblUsuarioOrigen"
        Me.lblUsuarioOrigen.Size = New System.Drawing.Size(46, 13)
        Me.lblUsuarioOrigen.TabIndex = 0
        Me.lblUsuarioOrigen.Text = "Usuario:"
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.White
        Me.pnlContenedor.Controls.Add(Me.pnlAcciones)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 285)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(674, 60)
        Me.pnlContenedor.TabIndex = 6
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(510, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(164, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(97, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 2
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(42, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(98, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(37, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'txtNombreColaboradorDestino
        '
        Me.txtNombreColaboradorDestino.Enabled = False
        Me.txtNombreColaboradorDestino.Location = New System.Drawing.Point(95, 104)
        Me.txtNombreColaboradorDestino.Name = "txtNombreColaboradorDestino"
        Me.txtNombreColaboradorDestino.ReadOnly = True
        Me.txtNombreColaboradorDestino.Size = New System.Drawing.Size(196, 20)
        Me.txtNombreColaboradorDestino.TabIndex = 30
        '
        'lblColaboradorDestino
        '
        Me.lblColaboradorDestino.AutoSize = True
        Me.lblColaboradorDestino.Location = New System.Drawing.Point(22, 107)
        Me.lblColaboradorDestino.Name = "lblColaboradorDestino"
        Me.lblColaboradorDestino.Size = New System.Drawing.Size(67, 13)
        Me.lblColaboradorDestino.TabIndex = 29
        Me.lblColaboradorDestino.Text = "Colaborador:"
        '
        'lblBuscarUsuarioDestino
        '
        Me.lblBuscarUsuarioDestino.AutoSize = True
        Me.lblBuscarUsuarioDestino.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscarUsuarioDestino.Location = New System.Drawing.Point(251, 66)
        Me.lblBuscarUsuarioDestino.Name = "lblBuscarUsuarioDestino"
        Me.lblBuscarUsuarioDestino.Size = New System.Drawing.Size(40, 13)
        Me.lblBuscarUsuarioDestino.TabIndex = 28
        Me.lblBuscarUsuarioDestino.Text = "Búscar"
        '
        'txtUsuarioDestino
        '
        Me.txtUsuarioDestino.BackColor = System.Drawing.SystemColors.Window
        Me.txtUsuarioDestino.Enabled = False
        Me.txtUsuarioDestino.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUsuarioDestino.Location = New System.Drawing.Point(95, 43)
        Me.txtUsuarioDestino.Name = "txtUsuarioDestino"
        Me.txtUsuarioDestino.ReadOnly = True
        Me.txtUsuarioDestino.Size = New System.Drawing.Size(135, 20)
        Me.txtUsuarioDestino.TabIndex = 1
        '
        'lblUsuarioDestino
        '
        Me.lblUsuarioDestino.AutoSize = True
        Me.lblUsuarioDestino.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUsuarioDestino.Location = New System.Drawing.Point(22, 46)
        Me.lblUsuarioDestino.Name = "lblUsuarioDestino"
        Me.lblUsuarioDestino.Size = New System.Drawing.Size(46, 13)
        Me.lblUsuarioDestino.TabIndex = 0
        Me.lblUsuarioDestino.Text = "Usuario:"
        '
        'grpUsuarioDestino
        '
        Me.grpUsuarioDestino.Controls.Add(Me.txtNombreColaboradorDestino)
        Me.grpUsuarioDestino.Controls.Add(Me.lblColaboradorDestino)
        Me.grpUsuarioDestino.Controls.Add(Me.lblBuscarUsuarioDestino)
        Me.grpUsuarioDestino.Controls.Add(Me.btnBuscarUsuarioDestino)
        Me.grpUsuarioDestino.Controls.Add(Me.txtUsuarioDestino)
        Me.grpUsuarioDestino.Controls.Add(Me.lblUsuarioDestino)
        Me.grpUsuarioDestino.Location = New System.Drawing.Point(340, 83)
        Me.grpUsuarioDestino.Name = "grpUsuarioDestino"
        Me.grpUsuarioDestino.Size = New System.Drawing.Size(322, 178)
        Me.grpUsuarioDestino.TabIndex = 7
        Me.grpUsuarioDestino.TabStop = False
        Me.grpUsuarioDestino.Text = "Usuario Destino"
        '
        'btnBuscarUsuarioDestino
        '
        Me.btnBuscarUsuarioDestino.Image = CType(resources.GetObject("btnBuscarUsuarioDestino.Image"), System.Drawing.Image)
        Me.btnBuscarUsuarioDestino.Location = New System.Drawing.Point(254, 31)
        Me.btnBuscarUsuarioDestino.Name = "btnBuscarUsuarioDestino"
        Me.btnBuscarUsuarioDestino.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscarUsuarioDestino.TabIndex = 27
        Me.btnBuscarUsuarioDestino.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(606, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 57)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'ReplicaPermisosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(674, 345)
        Me.Controls.Add(Me.grpUsuarioDestino)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Controls.Add(Me.grpUsuarioOrigen)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReplicaPermisosForm"
        Me.Text = "Replicar Permisos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grpUsuarioOrigen.ResumeLayout(False)
        Me.grpUsuarioOrigen.PerformLayout()
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.grpUsuarioDestino.ResumeLayout(False)
        Me.grpUsuarioDestino.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblReplicaPermisos As Label
    Friend WithEvents grpUsuarioOrigen As GroupBox
    Friend WithEvents txtUsuarioOrigen As TextBox
    Friend WithEvents lblUsuarioOrigen As Label
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents lblBuscarUsuarioOrigen As Label
    Friend WithEvents btnBuscarUsuarioOrigen As Button
    Friend WithEvents txtNombreColaboradorOrigen As TextBox
    Friend WithEvents lblColaboradorOrigen As Label
    Friend WithEvents txtNombreColaboradorDestino As TextBox
    Friend WithEvents lblColaboradorDestino As Label
    Friend WithEvents lblBuscarUsuarioDestino As Label
    Friend WithEvents btnBuscarUsuarioDestino As Button
    Friend WithEvents txtUsuarioDestino As TextBox
    Friend WithEvents lblUsuarioDestino As Label
    Friend WithEvents grpUsuarioDestino As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
