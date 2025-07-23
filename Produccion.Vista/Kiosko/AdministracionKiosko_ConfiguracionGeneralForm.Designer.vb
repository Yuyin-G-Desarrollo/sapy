<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministracionKiosko_ConfiguracionGeneralForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministracionKiosko_ConfiguracionGeneralForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlNave = New System.Windows.Forms.Panel()
        Me.lblFichaTecnica = New System.Windows.Forms.Label()
        Me.grpRutasFotograficas = New System.Windows.Forms.GroupBox()
        Me.lblVistaInterna = New System.Windows.Forms.Label()
        Me.lblVistaExterna = New System.Windows.Forms.Label()
        Me.lblPrincipal = New System.Windows.Forms.Label()
        Me.txtPrincipal = New DevExpress.XtraEditors.TextEdit()
        Me.txtVistaExterna = New DevExpress.XtraEditors.TextEdit()
        Me.txtVistaInterna = New DevExpress.XtraEditors.TextEdit()
        Me.txtFichaTecnica = New DevExpress.XtraEditors.TextEdit()
        Me.Panel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlNave.SuspendLayout()
        Me.grpRutasFotograficas.SuspendLayout()
        CType(Me.txtPrincipal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVistaExterna.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVistaInterna.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFichaTecnica.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 75)
        Me.Panel1.TabIndex = 7
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(189, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(371, 75)
        Me.pnlTitulo.TabIndex = 49
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(294, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(77, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 93
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(41, 28)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(247, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Configuración General Kiosko"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 238)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(560, 81)
        Me.pnlPie.TabIndex = 133
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(403, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(157, 81)
        Me.pnlDatosBotones.TabIndex = 2
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(56, 48)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 3
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(62, 15)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(110, 49)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(112, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlNave
        '
        Me.pnlNave.Controls.Add(Me.lblFichaTecnica)
        Me.pnlNave.Controls.Add(Me.grpRutasFotograficas)
        Me.pnlNave.Controls.Add(Me.txtFichaTecnica)
        Me.pnlNave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlNave.Location = New System.Drawing.Point(0, 75)
        Me.pnlNave.Name = "pnlNave"
        Me.pnlNave.Size = New System.Drawing.Size(560, 163)
        Me.pnlNave.TabIndex = 134
        '
        'lblFichaTecnica
        '
        Me.lblFichaTecnica.AutoSize = True
        Me.lblFichaTecnica.Location = New System.Drawing.Point(29, 130)
        Me.lblFichaTecnica.Name = "lblFichaTecnica"
        Me.lblFichaTecnica.Size = New System.Drawing.Size(78, 13)
        Me.lblFichaTecnica.TabIndex = 6
        Me.lblFichaTecnica.Text = "Ficha Tecnica:"
        '
        'grpRutasFotograficas
        '
        Me.grpRutasFotograficas.Controls.Add(Me.lblVistaInterna)
        Me.grpRutasFotograficas.Controls.Add(Me.lblVistaExterna)
        Me.grpRutasFotograficas.Controls.Add(Me.lblPrincipal)
        Me.grpRutasFotograficas.Controls.Add(Me.txtPrincipal)
        Me.grpRutasFotograficas.Controls.Add(Me.txtVistaExterna)
        Me.grpRutasFotograficas.Controls.Add(Me.txtVistaInterna)
        Me.grpRutasFotograficas.Location = New System.Drawing.Point(12, 6)
        Me.grpRutasFotograficas.Name = "grpRutasFotograficas"
        Me.grpRutasFotograficas.Size = New System.Drawing.Size(536, 114)
        Me.grpRutasFotograficas.TabIndex = 0
        Me.grpRutasFotograficas.TabStop = False
        Me.grpRutasFotograficas.Text = "Rutas Fotograficas"
        '
        'lblVistaInterna
        '
        Me.lblVistaInterna.AutoSize = True
        Me.lblVistaInterna.Location = New System.Drawing.Point(16, 79)
        Me.lblVistaInterna.Name = "lblVistaInterna"
        Me.lblVistaInterna.Size = New System.Drawing.Size(69, 13)
        Me.lblVistaInterna.TabIndex = 5
        Me.lblVistaInterna.Text = "Vista Interna:"
        '
        'lblVistaExterna
        '
        Me.lblVistaExterna.AutoSize = True
        Me.lblVistaExterna.Location = New System.Drawing.Point(16, 51)
        Me.lblVistaExterna.Name = "lblVistaExterna"
        Me.lblVistaExterna.Size = New System.Drawing.Size(72, 13)
        Me.lblVistaExterna.TabIndex = 4
        Me.lblVistaExterna.Text = "Vista Externa:"
        '
        'lblPrincipal
        '
        Me.lblPrincipal.AutoSize = True
        Me.lblPrincipal.Location = New System.Drawing.Point(16, 23)
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Size = New System.Drawing.Size(70, 13)
        Me.lblPrincipal.TabIndex = 3
        Me.lblPrincipal.Text = "Principal 3/4:"
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Location = New System.Drawing.Point(110, 19)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Size = New System.Drawing.Size(411, 20)
        Me.txtPrincipal.TabIndex = 0
        '
        'txtVistaExterna
        '
        Me.txtVistaExterna.Location = New System.Drawing.Point(110, 47)
        Me.txtVistaExterna.Name = "txtVistaExterna"
        Me.txtVistaExterna.Size = New System.Drawing.Size(411, 20)
        Me.txtVistaExterna.TabIndex = 1
        '
        'txtVistaInterna
        '
        Me.txtVistaInterna.Location = New System.Drawing.Point(110, 75)
        Me.txtVistaInterna.Name = "txtVistaInterna"
        Me.txtVistaInterna.Size = New System.Drawing.Size(411, 20)
        Me.txtVistaInterna.TabIndex = 2
        '
        'txtFichaTecnica
        '
        Me.txtFichaTecnica.Location = New System.Drawing.Point(122, 126)
        Me.txtFichaTecnica.Name = "txtFichaTecnica"
        Me.txtFichaTecnica.Size = New System.Drawing.Size(411, 20)
        Me.txtFichaTecnica.TabIndex = 3
        '
        'AdministracionKiosko_ConfiguracionGeneralForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(560, 319)
        Me.Controls.Add(Me.pnlNave)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AdministracionKiosko_ConfiguracionGeneralForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración General Kiosko"
        Me.Panel1.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlNave.ResumeLayout(False)
        Me.pnlNave.PerformLayout()
        Me.grpRutasFotograficas.ResumeLayout(False)
        Me.grpRutasFotograficas.PerformLayout()
        CType(Me.txtPrincipal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVistaExterna.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVistaInterna.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFichaTecnica.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents pnlNave As Panel
    Friend WithEvents grpRutasFotograficas As GroupBox
    Friend WithEvents lblPrincipal As Label
    Friend WithEvents lblVistaExterna As Label
    Friend WithEvents lblVistaInterna As Label
    Friend WithEvents lblFichaTecnica As Label
    Friend WithEvents txtPrincipal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtVistaExterna As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtVistaInterna As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFichaTecnica As DevExpress.XtraEditors.TextEdit
End Class
