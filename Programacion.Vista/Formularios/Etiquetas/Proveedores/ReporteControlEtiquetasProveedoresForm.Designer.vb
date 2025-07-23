<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteControlEtiquetasProveedoresForm
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblPrograma = New System.Windows.Forms.Label()
        Me.lblEnvia = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFecha2 = New System.Windows.Forms.Label()
        Me.lblFecha1 = New System.Windows.Forms.Label()
        Me.grdReporte = New DevExpress.XtraGrid.GridControl()
        Me.grdVReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.UltraPanel1)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(382, 65)
        Me.pnlListaPaises.TabIndex = 39
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnExportar)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label1)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(89, 65)
        Me.UltraPanel1.TabIndex = 7
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(29, 9)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 14
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(21, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Exportar"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(115, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(267, 65)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(11, 9)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(191, 40)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Control de Etiquetas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Proveedor de Suela"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblProveedor)
        Me.Panel1.Controls.Add(Me.lblPrograma)
        Me.Panel1.Controls.Add(Me.lblEnvia)
        Me.Panel1.Controls.Add(Me.lblFecha)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblFecha2)
        Me.Panel1.Controls.Add(Me.lblFecha1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(382, 118)
        Me.Panel1.TabIndex = 40
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(95, 82)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(16, 13)
        Me.lblProveedor.TabIndex = 153
        Me.lblProveedor.Text = "..."
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.Location = New System.Drawing.Point(95, 58)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(16, 13)
        Me.lblPrograma.TabIndex = 152
        Me.lblPrograma.Text = "..."
        '
        'lblEnvia
        '
        Me.lblEnvia.AutoSize = True
        Me.lblEnvia.Location = New System.Drawing.Point(95, 33)
        Me.lblEnvia.Name = "lblEnvia"
        Me.lblEnvia.Size = New System.Drawing.Size(16, 13)
        Me.lblEnvia.TabIndex = 151
        Me.lblEnvia.Text = "..."
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(95, 12)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(16, 13)
        Me.lblFecha.TabIndex = 150
        Me.lblFecha.Text = "..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(26, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Proveedor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(26, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Programa:"
        '
        'lblFecha2
        '
        Me.lblFecha2.AutoSize = True
        Me.lblFecha2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lblFecha2.Location = New System.Drawing.Point(26, 33)
        Me.lblFecha2.Name = "lblFecha2"
        Me.lblFecha2.Size = New System.Drawing.Size(39, 13)
        Me.lblFecha2.TabIndex = 147
        Me.lblFecha2.Text = "Envía:"
        '
        'lblFecha1
        '
        Me.lblFecha1.AutoSize = True
        Me.lblFecha1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.lblFecha1.Location = New System.Drawing.Point(26, 12)
        Me.lblFecha1.Name = "lblFecha1"
        Me.lblFecha1.Size = New System.Drawing.Size(49, 13)
        Me.lblFecha1.TabIndex = 65
        Me.lblFecha1.Text = "F. Envio:"
        '
        'grdReporte
        '
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdReporte.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdReporte.Location = New System.Drawing.Point(0, 0)
        Me.grdReporte.MainView = Me.grdVReporte
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(382, 242)
        Me.grdReporte.TabIndex = 41
        Me.grdReporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVReporte, Me.GridView4})
        '
        'grdVReporte
        '
        Me.grdVReporte.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.Control
        Me.grdVReporte.Appearance.EvenRow.Options.UseBackColor = True
        Me.grdVReporte.Appearance.OddRow.BackColor = System.Drawing.SystemColors.Control
        Me.grdVReporte.Appearance.OddRow.Options.UseBackColor = True
        Me.grdVReporte.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White
        Me.grdVReporte.AppearancePrint.EvenRow.BackColor2 = System.Drawing.Color.White
        Me.grdVReporte.AppearancePrint.EvenRow.Options.UseBackColor = True
        Me.grdVReporte.AppearancePrint.OddRow.BackColor = System.Drawing.Color.White
        Me.grdVReporte.AppearancePrint.OddRow.Options.UseBackColor = True
        Me.grdVReporte.GridControl = Me.grdReporte
        Me.grdVReporte.Name = "grdVReporte"
        Me.grdVReporte.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVReporte.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVReporte.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.grdVReporte.OptionsPrint.AllowMultilineHeaders = True
        Me.grdVReporte.OptionsSelection.MultiSelect = True
        Me.grdVReporte.OptionsView.ColumnAutoWidth = False
        Me.grdVReporte.OptionsView.ShowAutoFilterRow = True
        Me.grdVReporte.OptionsView.ShowGroupPanel = False
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.grdReporte
        Me.GridView4.Name = "GridView4"
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnSalir.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSalir.Location = New System.Drawing.Point(57, 9)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 16
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(59, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Salir"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 425)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(382, 65)
        Me.Panel2.TabIndex = 42
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnSalir)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(267, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(115, 65)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdReporte)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 183)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(382, 242)
        Me.Panel4.TabIndex = 43
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(208, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'ReporteControlEtiquetasProveedoresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 490)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(390, 517)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(390, 517)
        Me.Name = "ReporteControlEtiquetasProveedoresForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Control Etiquetas Proveedores"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblFecha2 As Label
    Friend WithEvents lblFecha1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblProveedor As Label
    Friend WithEvents lblPrograma As Label
    Friend WithEvents lblEnvia As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents grdReporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
