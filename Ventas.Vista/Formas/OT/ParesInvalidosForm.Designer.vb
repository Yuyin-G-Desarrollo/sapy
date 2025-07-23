<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParesInvalidosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParesInvalidosForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdAtadosIncompletos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdParesInvalidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlMarcarTodo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdAtadosIncompletos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdParesInvalidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(670, 59)
        Me.pnlEncabezado.TabIndex = 27
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(670, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(602, 59)
        Me.Panel1.TabIndex = 47
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Controls.Add(Me.Label2)
        Me.pnlMarcarTodo.Controls.Add(Me.btnExportar)
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(113, 59)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(25, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(32, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(456, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(131, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Pares Inválidos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(602, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 394)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(670, 71)
        Me.pnlPie.TabIndex = 65
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(526, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(86, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(85, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(24, 33)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 116
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdAtadosIncompletos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(662, 309)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Atados Incompletos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdAtadosIncompletos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAtadosIncompletos.DisplayLayout.Appearance = Appearance1
        Me.grdAtadosIncompletos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdAtadosIncompletos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAtadosIncompletos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdAtadosIncompletos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdAtadosIncompletos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAtadosIncompletos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAtadosIncompletos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAtadosIncompletos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAtadosIncompletos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAtadosIncompletos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAtadosIncompletos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAtadosIncompletos.Location = New System.Drawing.Point(3, 3)
        Me.grdAtadosIncompletos.Name = "grdAtadosIncompletos"
        Me.grdAtadosIncompletos.Size = New System.Drawing.Size(656, 303)
        Me.grdAtadosIncompletos.TabIndex = 65
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdParesInvalidos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(662, 309)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pares Inválidos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdParesInvalidos
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesInvalidos.DisplayLayout.Appearance = Appearance2
        Me.grdParesInvalidos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdParesInvalidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesInvalidos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdParesInvalidos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdParesInvalidos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdParesInvalidos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdParesInvalidos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdParesInvalidos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdParesInvalidos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdParesInvalidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesInvalidos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdParesInvalidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesInvalidos.Location = New System.Drawing.Point(3, 3)
        Me.grdParesInvalidos.Name = "grdParesInvalidos"
        Me.grdParesInvalidos.Size = New System.Drawing.Size(656, 303)
        Me.grdParesInvalidos.TabIndex = 64
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 59)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(670, 335)
        Me.TabControl1.TabIndex = 66
        '
        'ParesInvalidosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 465)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ParesInvalidosForm"
        Me.Text = "Pares Inválidos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlMarcarTodo.ResumeLayout(False)
        Me.pnlMarcarTodo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdAtadosIncompletos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdParesInvalidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlMarcarTodo As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdAtadosIncompletos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grdParesInvalidos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
End Class
