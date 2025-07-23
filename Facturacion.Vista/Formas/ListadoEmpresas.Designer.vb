<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoEmpresas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoEmpresas))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdEmpresas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.menuAyuda = New System.Windows.Forms.ContextMenuStrip()
        Me.FacturacionEmpresasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturacionEmpresasArchivoWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuAyuda.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.btnAyuda)
        Me.pnlBanner.Controls.Add(Me.Label1)
        Me.pnlBanner.Controls.Add(Me.btnEditar)
        Me.pnlBanner.Controls.Add(Me.lblEditar)
        Me.pnlBanner.Controls.Add(Me.btnNuevo)
        Me.pnlBanner.Controls.Add(Me.lblNuevo)
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(971, 68)
        Me.pnlBanner.TabIndex = 57
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(115, 7)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 63
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(113, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Ayuda"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Facturacion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(66, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 60
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(65, 39)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 61
        Me.lblEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Facturacion.Vista.My.Resources.Resources.altas_32
        Me.btnNuevo.Location = New System.Drawing.Point(14, 7)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevo.TabIndex = 58
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(16, 39)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(30, 13)
        Me.lblNuevo.TabIndex = 59
        Me.lblNuevo.Text = "Altas"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(714, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(257, 68)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(178, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Listado de Empresas"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.grdEmpresas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(971, 469)
        Me.Panel1.TabIndex = 58
        '
        'grdEmpresas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 7.0!
        Appearance1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdEmpresas.DisplayLayout.Appearance = Appearance1
        Me.grdEmpresas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdEmpresas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdEmpresas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdEmpresas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdEmpresas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.grdEmpresas.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdEmpresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEmpresas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdEmpresas.Location = New System.Drawing.Point(0, 0)
        Me.grdEmpresas.Name = "grdEmpresas"
        Me.grdEmpresas.Size = New System.Drawing.Size(969, 467)
        Me.grdEmpresas.TabIndex = 3
        '
        'menuAyuda
        '
        Me.menuAyuda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturacionEmpresasToolStripMenuItem, Me.FacturacionEmpresasArchivoWordToolStripMenuItem})
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Size = New System.Drawing.Size(245, 48)
        '
        'FacturacionEmpresasToolStripMenuItem
        '
        Me.FacturacionEmpresasToolStripMenuItem.Name = "FacturacionEmpresasToolStripMenuItem"
        Me.FacturacionEmpresasToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.FacturacionEmpresasToolStripMenuItem.Text = "Ayuda Facturación Empresas"
        '
        'FacturacionEmpresasArchivoWordToolStripMenuItem
        '
        Me.FacturacionEmpresasArchivoWordToolStripMenuItem.Name = "FacturacionEmpresasArchivoWordToolStripMenuItem"
        Me.FacturacionEmpresasArchivoWordToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.FacturacionEmpresasArchivoWordToolStripMenuItem.Text = "FacturacionEmpresas Archivo Word"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(189, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 68)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 44
        Me.PictureBox1.TabStop = False
        '
        'ListadoEmpresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(971, 543)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlBanner)
        Me.Name = "ListadoEmpresas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado Empresas"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuAyuda.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdEmpresas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAyuda As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents menuAyuda As ContextMenuStrip
    Friend WithEvents FacturacionEmpresasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturacionEmpresasArchivoWordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
End Class
