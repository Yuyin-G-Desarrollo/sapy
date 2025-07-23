<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblUserSession = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stblblUsuarioSistema = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSistema = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stblblSistema = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stblblFechaSistema = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mstMenuPrincipal = New System.Windows.Forms.MenuStrip()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUserSession, Me.stblblUsuarioSistema, Me.lblSistema, Me.stblblSistema, Me.lblFecha, Me.stblblFechaSistema})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 499)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(702, 22)
        Me.StatusStrip.TabIndex = 8
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblUserSession
        '
        Me.lblUserSession.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.lblUserSession.Name = "lblUserSession"
        Me.lblUserSession.Size = New System.Drawing.Size(43, 17)
        Me.lblUserSession.Text = "Usuario :"
        '
        'stblblUsuarioSistema
        '
        Me.stblblUsuarioSistema.Font = New System.Drawing.Font("Segoe UI Semibold", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stblblUsuarioSistema.ForeColor = System.Drawing.Color.Black
        Me.stblblUsuarioSistema.Name = "stblblUsuarioSistema"
        Me.stblblUsuarioSistema.Size = New System.Drawing.Size(9, 17)
        Me.stblblUsuarioSistema.Text = "-"
        '
        'lblSistema
        '
        Me.lblSistema.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Size = New System.Drawing.Size(43, 17)
        Me.lblSistema.Text = "Sistema :"
        '
        'stblblSistema
        '
        Me.stblblSistema.Font = New System.Drawing.Font("Segoe UI Semibold", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stblblSistema.ForeColor = System.Drawing.Color.Black
        Me.stblblSistema.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.stblblSistema.Name = "stblblSistema"
        Me.stblblSistema.Size = New System.Drawing.Size(9, 17)
        Me.stblblSistema.Text = "-"
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(36, 17)
        Me.lblFecha.Text = "Fecha :"
        '
        'stblblFechaSistema
        '
        Me.stblblFechaSistema.Font = New System.Drawing.Font("Segoe UI Semibold", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stblblFechaSistema.Name = "stblblFechaSistema"
        Me.stblblFechaSistema.Size = New System.Drawing.Size(9, 17)
        Me.stblblFechaSistema.Text = "-"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(702, 475)
        Me.Panel1.TabIndex = 9
        '
        'mstMenuPrincipal
        '
        Me.mstMenuPrincipal.BackColor = System.Drawing.Color.LightGray
        Me.mstMenuPrincipal.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.menubk7
        Me.mstMenuPrincipal.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.mstMenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.mstMenuPrincipal.Name = "mstMenuPrincipal"
        Me.mstMenuPrincipal.Size = New System.Drawing.Size(702, 24)
        Me.mstMenuPrincipal.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(702, 521)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.mstMenuPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mstMenuPrincipal
        Me.Name = "MainForm"
        Me.Text = "ERP Grupo Yuyin"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
	Friend WithEvents lblUserSession As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents stblblUsuarioSistema As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents lblSistema As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents stblblSistema As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents lblFecha As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents stblblFechaSistema As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents mstMenuPrincipal As System.Windows.Forms.MenuStrip
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
