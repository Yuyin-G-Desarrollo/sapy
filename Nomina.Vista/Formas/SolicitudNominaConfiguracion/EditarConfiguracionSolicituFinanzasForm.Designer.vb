<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditarConfiguracionSolicituFinanzasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarConfiguracionSolicituFinanzasForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbTipoSolicitud = New System.Windows.Forms.ComboBox()
        Me.txtBeneficiario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 301)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(384, 60)
        Me.Panel1.TabIndex = 70
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(249, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(135, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(28, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(22, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 9
        Me.lblGuardar.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(79, 6)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 6
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(78, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 7
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(384, 60)
        Me.pnlHeader.TabIndex = 71
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(43, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(341, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(82, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(185, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Configuración Nómina"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(384, 241)
        Me.Panel2.TabIndex = 72
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cmbTipoSolicitud)
        Me.Panel3.Controls.Add(Me.txtBeneficiario)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(24, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(338, 203)
        Me.Panel3.TabIndex = 0
        '
        'cmbTipoSolicitud
        '
        Me.cmbTipoSolicitud.FormattingEnabled = True
        Me.cmbTipoSolicitud.Location = New System.Drawing.Point(94, 107)
        Me.cmbTipoSolicitud.Name = "cmbTipoSolicitud"
        Me.cmbTipoSolicitud.Size = New System.Drawing.Size(218, 21)
        Me.cmbTipoSolicitud.TabIndex = 40
        '
        'txtBeneficiario
        '
        Me.txtBeneficiario.Location = New System.Drawing.Point(94, 48)
        Me.txtBeneficiario.Name = "txtBeneficiario"
        Me.txtBeneficiario.Size = New System.Drawing.Size(218, 20)
        Me.txtBeneficiario.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tipo Solicitud *"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Beneficiario *"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(273, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'EditarConfiguracionSolicituFinanzasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 361)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EditarConfiguracionSolicituFinanzasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Configuración Finanzas"
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents bntSalir As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtBeneficiario As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTipoSolicitud As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
