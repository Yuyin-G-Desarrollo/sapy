<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaPermisoEspecialForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaPermisoEspecialForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ArbolModulos = New System.Windows.Forms.TreeView()
        Me.pnlArbol = New System.Windows.Forms.Panel()
        Me.pnlPerfilUsuario = New System.Windows.Forms.Panel()
        Me.pnlPermiso = New System.Windows.Forms.Panel()
        Me.rdoSiPermiso = New System.Windows.Forms.RadioButton()
        Me.rdoNoPermiso = New System.Windows.Forms.RadioButton()
        Me.lblNombreUsuario = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlArbol.SuspendLayout()
        Me.pnlPerfilUsuario.SuspendLayout()
        Me.pnlPermiso.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(633, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(414, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(219, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(146, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Permiso Especial"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 506)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(633, 60)
        Me.pnlEstado.TabIndex = 1
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(476, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(157, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(98, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 8
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(99, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(35, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 1
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(40, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'ArbolModulos
        '
        Me.ArbolModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ArbolModulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ArbolModulos.Location = New System.Drawing.Point(0, 0)
        Me.ArbolModulos.Name = "ArbolModulos"
        Me.ArbolModulos.Size = New System.Drawing.Size(633, 394)
        Me.ArbolModulos.TabIndex = 2
        '
        'pnlArbol
        '
        Me.pnlArbol.Controls.Add(Me.ArbolModulos)
        Me.pnlArbol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlArbol.Location = New System.Drawing.Point(0, 112)
        Me.pnlArbol.Name = "pnlArbol"
        Me.pnlArbol.Size = New System.Drawing.Size(633, 394)
        Me.pnlArbol.TabIndex = 8
        '
        'pnlPerfilUsuario
        '
        Me.pnlPerfilUsuario.Controls.Add(Me.pnlPermiso)
        Me.pnlPerfilUsuario.Controls.Add(Me.lblNombreUsuario)
        Me.pnlPerfilUsuario.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPerfilUsuario.Location = New System.Drawing.Point(0, 60)
        Me.pnlPerfilUsuario.Name = "pnlPerfilUsuario"
        Me.pnlPerfilUsuario.Size = New System.Drawing.Size(633, 52)
        Me.pnlPerfilUsuario.TabIndex = 7
        '
        'pnlPermiso
        '
        Me.pnlPermiso.Controls.Add(Me.rdoSiPermiso)
        Me.pnlPermiso.Controls.Add(Me.rdoNoPermiso)
        Me.pnlPermiso.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlPermiso.Location = New System.Drawing.Point(463, 0)
        Me.pnlPermiso.Name = "pnlPermiso"
        Me.pnlPermiso.Size = New System.Drawing.Size(170, 52)
        Me.pnlPermiso.TabIndex = 3
        '
        'rdoSiPermiso
        '
        Me.rdoSiPermiso.AutoSize = True
        Me.rdoSiPermiso.Location = New System.Drawing.Point(6, 18)
        Me.rdoSiPermiso.Name = "rdoSiPermiso"
        Me.rdoSiPermiso.Size = New System.Drawing.Size(62, 17)
        Me.rdoSiPermiso.TabIndex = 4
        Me.rdoSiPermiso.TabStop = True
        Me.rdoSiPermiso.Text = "Permiso"
        Me.rdoSiPermiso.UseVisualStyleBackColor = True
        '
        'rdoNoPermiso
        '
        Me.rdoNoPermiso.AutoSize = True
        Me.rdoNoPermiso.Location = New System.Drawing.Point(77, 18)
        Me.rdoNoPermiso.Name = "rdoNoPermiso"
        Me.rdoNoPermiso.Size = New System.Drawing.Size(78, 17)
        Me.rdoNoPermiso.TabIndex = 3
        Me.rdoNoPermiso.TabStop = True
        Me.rdoNoPermiso.Text = "No permiso"
        Me.rdoNoPermiso.UseVisualStyleBackColor = True
        '
        'lblNombreUsuario
        '
        Me.lblNombreUsuario.AutoSize = True
        Me.lblNombreUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreUsuario.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreUsuario.Location = New System.Drawing.Point(12, 21)
        Me.lblNombreUsuario.Name = "lblNombreUsuario"
        Me.lblNombreUsuario.Size = New System.Drawing.Size(0, 16)
        Me.lblNombreUsuario.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(151, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AltaPermisoEspecialForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(633, 566)
        Me.Controls.Add(Me.pnlArbol)
        Me.Controls.Add(Me.pnlPerfilUsuario)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(639, 588)
        Me.Name = "AltaPermisoEspecialForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permiso Especial"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlArbol.ResumeLayout(False)
        Me.pnlPerfilUsuario.ResumeLayout(False)
        Me.pnlPerfilUsuario.PerformLayout()
        Me.pnlPermiso.ResumeLayout(False)
        Me.pnlPermiso.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents ArbolModulos As System.Windows.Forms.TreeView
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlArbol As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlPerfilUsuario As System.Windows.Forms.Panel
    Friend WithEvents lblNombreUsuario As System.Windows.Forms.Label
    Friend WithEvents pnlPermiso As System.Windows.Forms.Panel
    Friend WithEvents rdoSiPermiso As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNoPermiso As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As PictureBox
End Class
