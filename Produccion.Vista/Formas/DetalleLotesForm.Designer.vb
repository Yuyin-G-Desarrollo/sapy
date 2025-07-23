<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetalleLotesForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetalleLotesForm))
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdInventarioNave = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grdAvances = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.cmbCelulas = New System.Windows.Forms.ComboBox()
        Me.lbl_Celulas = New System.Windows.Forms.Label()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Cms_Celulas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CELULA1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CELULA2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvDepartamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel7.SuspendLayout()
        CType(Me.grdInventarioNave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAvances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cms_Celulas.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel7.Controls.Add(Me.grdInventarioNave)
        Me.Panel7.Controls.Add(Me.C1FlexGrid3)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 346)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(945, 148)
        Me.Panel7.TabIndex = 8
        '
        'grdInventarioNave
        '
        Me.grdInventarioNave.ColumnInfo = resources.GetString("grdInventarioNave.ColumnInfo")
        Me.grdInventarioNave.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdInventarioNave.Location = New System.Drawing.Point(0, 24)
        Me.grdInventarioNave.Name = "grdInventarioNave"
        Me.grdInventarioNave.Rows.Count = 1
        Me.grdInventarioNave.Rows.DefaultSize = 19
        Me.grdInventarioNave.Size = New System.Drawing.Size(945, 127)
        Me.grdInventarioNave.StyleInfo = resources.GetString("grdInventarioNave.StyleInfo")
        Me.grdInventarioNave.TabIndex = 17
        '
        'C1FlexGrid3
        '
        Me.C1FlexGrid3.ColumnInfo = resources.GetString("C1FlexGrid3.ColumnInfo")
        Me.C1FlexGrid3.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1FlexGrid3.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexGrid3.Name = "C1FlexGrid3"
        Me.C1FlexGrid3.Rows.Count = 1
        Me.C1FlexGrid3.Rows.DefaultSize = 19
        Me.C1FlexGrid3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid3.Size = New System.Drawing.Size(945, 24)
        Me.C1FlexGrid3.StyleInfo = resources.GetString("C1FlexGrid3.StyleInfo")
        Me.C1FlexGrid3.TabIndex = 21
        '
        'grdAvances
        '
        Me.grdAvances.ColumnInfo = resources.GetString("grdAvances.ColumnInfo")
        Me.grdAvances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAvances.Location = New System.Drawing.Point(0, 50)
        Me.grdAvances.Name = "grdAvances"
        Me.grdAvances.Rows.Count = 1
        Me.grdAvances.Rows.DefaultSize = 19
        Me.grdAvances.Size = New System.Drawing.Size(945, 296)
        Me.grdAvances.StyleInfo = resources.GetString("grdAvances.StyleInfo")
        Me.grdAvances.TabIndex = 9
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.cmbCelulas)
        Me.pnlListaPaises.Controls.Add(Me.lbl_Celulas)
        Me.pnlListaPaises.Controls.Add(Me.lblImprimir)
        Me.pnlListaPaises.Controls.Add(Me.btnImprimir)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(945, 50)
        Me.pnlListaPaises.TabIndex = 29
        '
        'cmbCelulas
        '
        Me.cmbCelulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCelulas.ForeColor = System.Drawing.Color.Black
        Me.cmbCelulas.FormattingEnabled = True
        Me.cmbCelulas.Items.AddRange(New Object() {""})
        Me.cmbCelulas.Location = New System.Drawing.Point(131, 12)
        Me.cmbCelulas.Name = "cmbCelulas"
        Me.cmbCelulas.Size = New System.Drawing.Size(142, 21)
        Me.cmbCelulas.TabIndex = 27
        '
        'lbl_Celulas
        '
        Me.lbl_Celulas.AutoSize = True
        Me.lbl_Celulas.ForeColor = System.Drawing.Color.Black
        Me.lbl_Celulas.Location = New System.Drawing.Point(84, 15)
        Me.lbl_Celulas.Name = "lbl_Celulas"
        Me.lbl_Celulas.Size = New System.Drawing.Size(41, 13)
        Me.lbl_Celulas.TabIndex = 128
        Me.lbl_Celulas.Text = "Celulas"
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(9, 35)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 126
        Me.lblImprimir.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(13, 0)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 125
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Panel1)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(280, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(665, 50)
        Me.pnlHeader.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(607, 50)
        Me.Panel1.TabIndex = 46
        '
        'lblEncabezado
        '
        Me.lblEncabezado.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(3, 0)
        Me.lblEncabezado.Margin = New System.Windows.Forms.Padding(3, 50, 3, 0)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(604, 50)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Detalle de Lotes"
        Me.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(610, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(55, 50)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Cms_Celulas
        '
        Me.Cms_Celulas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CELULA1ToolStripMenuItem, Me.CELULA2ToolStripMenuItem, Me.InvDepartamentoToolStripMenuItem})
        Me.Cms_Celulas.Name = "Cms_Celulas"
        Me.Cms_Celulas.Size = New System.Drawing.Size(167, 70)
        '
        'CELULA1ToolStripMenuItem
        '
        Me.CELULA1ToolStripMenuItem.Name = "CELULA1ToolStripMenuItem"
        Me.CELULA1ToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CELULA1ToolStripMenuItem.Text = "CELULA 1"
        '
        'CELULA2ToolStripMenuItem
        '
        Me.CELULA2ToolStripMenuItem.Name = "CELULA2ToolStripMenuItem"
        Me.CELULA2ToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.CELULA2ToolStripMenuItem.Text = "CELULA 2"
        '
        'InvDepartamentoToolStripMenuItem
        '
        Me.InvDepartamentoToolStripMenuItem.Name = "InvDepartamentoToolStripMenuItem"
        Me.InvDepartamentoToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.InvDepartamentoToolStripMenuItem.Text = "Inv. Departamento"
        '
        'DetalleLotesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 494)
        Me.Controls.Add(Me.grdAvances)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.Panel7)
        Me.Name = "DetalleLotesForm"
        Me.Text = "Detalle de Lotes"
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdInventarioNave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAvances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cms_Celulas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents C1FlexGrid3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grdAvances As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grdInventarioNave As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblImprimir As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents lbl_Celulas As Label
    Friend WithEvents cmbCelulas As ComboBox
    Friend WithEvents Cms_Celulas As ContextMenuStrip
    Friend WithEvents CELULA1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CELULA2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InvDepartamentoToolStripMenuItem As ToolStripMenuItem
End Class
