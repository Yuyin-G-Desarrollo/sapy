<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionPermisosDetalleForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionPermisosDetalleForm))
        Me.pnlCabezera = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.lblIdConfPermiso = New System.Windows.Forms.Label()
        Me.lblIdNave = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.gpbIncentivos = New System.Windows.Forms.GroupBox()
        Me.chkCajaAhorro = New System.Windows.Forms.CheckBox()
        Me.chkPuntualidadAsistencia = New System.Windows.Forms.CheckBox()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlCabezera.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpbIncentivos.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabezera
        '
        Me.pnlCabezera.BackColor = System.Drawing.Color.White
        Me.pnlCabezera.Controls.Add(Me.Panel1)
        Me.pnlCabezera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabezera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabezera.Name = "pnlCabezera"
        Me.pnlCabezera.Size = New System.Drawing.Size(394, 60)
        Me.pnlCabezera.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(-74, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(468, 60)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(281, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(120, 18)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "de Inasistencia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(109, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(289, 18)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Alta y Edición de Motivos de Permiso"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 368)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(394, 60)
        Me.pnlPie.TabIndex = 2
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(200, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(194, 60)
        Me.pnlOperaciones.TabIndex = 25
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(89, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 33)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(141, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(142, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 33)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(83, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 1
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.lblIdConfPermiso)
        Me.pnlContenido.Controls.Add(Me.lblIdNave)
        Me.pnlContenido.Controls.Add(Me.GroupBox1)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 60)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(394, 308)
        Me.pnlContenido.TabIndex = 1
        '
        'lblIdConfPermiso
        '
        Me.lblIdConfPermiso.AutoSize = True
        Me.lblIdConfPermiso.Location = New System.Drawing.Point(3, 3)
        Me.lblIdConfPermiso.Name = "lblIdConfPermiso"
        Me.lblIdConfPermiso.Size = New System.Drawing.Size(13, 13)
        Me.lblIdConfPermiso.TabIndex = 4
        Me.lblIdConfPermiso.Text = "0"
        Me.lblIdConfPermiso.Visible = False
        '
        'lblIdNave
        '
        Me.lblIdNave.AutoSize = True
        Me.lblIdNave.Location = New System.Drawing.Point(452, 3)
        Me.lblIdNave.Name = "lblIdNave"
        Me.lblIdNave.Size = New System.Drawing.Size(13, 13)
        Me.lblIdNave.TabIndex = 3
        Me.lblIdNave.Text = "0"
        Me.lblIdNave.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMotivo)
        Me.GroupBox1.Controls.Add(Me.lblMotivo)
        Me.GroupBox1.Controls.Add(Me.gpbIncentivos)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 240)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'txtMotivo
        '
        Me.txtMotivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotivo.Location = New System.Drawing.Point(68, 41)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(248, 43)
        Me.txtMotivo.TabIndex = 1
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(20, 41)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(42, 13)
        Me.lblMotivo.TabIndex = 0
        Me.lblMotivo.Text = "Motivo:"
        '
        'gpbIncentivos
        '
        Me.gpbIncentivos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbIncentivos.Controls.Add(Me.chkCajaAhorro)
        Me.gpbIncentivos.Controls.Add(Me.chkPuntualidadAsistencia)
        Me.gpbIncentivos.Location = New System.Drawing.Point(66, 100)
        Me.gpbIncentivos.Name = "gpbIncentivos"
        Me.gpbIncentivos.Size = New System.Drawing.Size(208, 98)
        Me.gpbIncentivos.TabIndex = 2
        Me.gpbIncentivos.TabStop = False
        Me.gpbIncentivos.Text = "¿ Conserva Incentivos ?"
        '
        'chkCajaAhorro
        '
        Me.chkCajaAhorro.AutoSize = True
        Me.chkCajaAhorro.Location = New System.Drawing.Point(38, 63)
        Me.chkCajaAhorro.Name = "chkCajaAhorro"
        Me.chkCajaAhorro.Size = New System.Drawing.Size(96, 17)
        Me.chkCajaAhorro.TabIndex = 1
        Me.chkCajaAhorro.Text = "Caja de Ahorro"
        Me.chkCajaAhorro.UseVisualStyleBackColor = True
        '
        'chkPuntualidadAsistencia
        '
        Me.chkPuntualidadAsistencia.AutoSize = True
        Me.chkPuntualidadAsistencia.Location = New System.Drawing.Point(38, 31)
        Me.chkPuntualidadAsistencia.Name = "chkPuntualidadAsistencia"
        Me.chkPuntualidadAsistencia.Size = New System.Drawing.Size(141, 17)
        Me.chkPuntualidadAsistencia.TabIndex = 0
        Me.chkPuntualidadAsistencia.Text = "Puntualidad y Asistencia"
        Me.chkPuntualidadAsistencia.UseVisualStyleBackColor = True
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(400, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 31
        Me.pcbTitulo.TabStop = False
        '
        'ConfiguracionPermisosDetalleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(394, 428)
        Me.Controls.Add(Me.pnlContenido)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabezera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(400, 450)
        Me.MinimumSize = New System.Drawing.Size(400, 450)
        Me.Name = "ConfiguracionPermisosDetalleForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta y Edición de Motivos de Permiso de Inasistencia"
        Me.pnlCabezera.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenido.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpbIncentivos.ResumeLayout(False)
        Me.gpbIncentivos.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabezera As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents pnlContenido As System.Windows.Forms.Panel
    Friend WithEvents gpbIncentivos As System.Windows.Forms.GroupBox
    Friend WithEvents chkCajaAhorro As System.Windows.Forms.CheckBox
    Friend WithEvents chkPuntualidadAsistencia As System.Windows.Forms.CheckBox
    Friend WithEvents txtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblIdNave As System.Windows.Forms.Label
    Friend WithEvents lblIdConfPermiso As System.Windows.Forms.Label
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
