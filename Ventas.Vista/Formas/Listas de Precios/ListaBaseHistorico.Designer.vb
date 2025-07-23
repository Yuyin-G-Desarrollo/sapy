<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaBaseHistorico
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnHistorico = New System.Windows.Forms.Button()
        Me.lblHistorico = New System.Windows.Forms.Label()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnGenerarReportePDF = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarPDF = New System.Windows.Forms.Label()
        Me.lblArticulos = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblContados = New System.Windows.Forms.Label()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.chkSelccionarTodo = New System.Windows.Forms.CheckBox()
        Me.grdHistoricoPreciosBase = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pblContenedor = New System.Windows.Forms.Panel()
        Me.pnlCombo = New System.Windows.Forms.Panel()
        Me.cmbListas = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblListas = New System.Windows.Forms.Label()
        Me.exportExcelListasP = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.pnlHeader.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdHistoricoPreciosBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pblContenedor.SuspendLayout()
        Me.pnlCombo.SuspendLayout()
        CType(Me.cmbListas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Panel3)
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1085, 60)
        Me.pnlHeader.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(433, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(592, 60)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblTitulo)
        Me.Panel4.Location = New System.Drawing.Point(54, 19)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(538, 38)
        Me.Panel4.TabIndex = 4
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(250, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(288, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Historial de Listas de Precios Base"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnHistorico)
        Me.pnlAcciones.Controls.Add(Me.lblHistorico)
        Me.pnlAcciones.Controls.Add(Me.lblExportarExcel)
        Me.pnlAcciones.Controls.Add(Me.btnGenerarReportePDF)
        Me.pnlAcciones.Controls.Add(Me.btnExportarExcel)
        Me.pnlAcciones.Controls.Add(Me.lblExportarPDF)
        Me.pnlAcciones.Controls.Add(Me.lblArticulos)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(378, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnHistorico
        '
        Me.btnHistorico.Image = Global.Ventas.Vista.My.Resources.Resources.historico
        Me.btnHistorico.Location = New System.Drawing.Point(39, 3)
        Me.btnHistorico.Name = "btnHistorico"
        Me.btnHistorico.Size = New System.Drawing.Size(32, 32)
        Me.btnHistorico.TabIndex = 27
        Me.btnHistorico.UseVisualStyleBackColor = True
        '
        'lblHistorico
        '
        Me.lblHistorico.AutoSize = True
        Me.lblHistorico.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblHistorico.Location = New System.Drawing.Point(31, 34)
        Me.lblHistorico.Name = "lblHistorico"
        Me.lblHistorico.Size = New System.Drawing.Size(48, 13)
        Me.lblHistorico.TabIndex = 26
        Me.lblHistorico.Text = "Histórico"
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(113, 37)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(75, 13)
        Me.lblExportarExcel.TabIndex = 24
        Me.lblExportarExcel.Text = "Exportar Excel"
        '
        'btnGenerarReportePDF
        '
        Me.btnGenerarReportePDF.Image = Global.Ventas.Vista.My.Resources.Resources.pdf_32
        Me.btnGenerarReportePDF.Location = New System.Drawing.Point(230, 3)
        Me.btnGenerarReportePDF.Name = "btnGenerarReportePDF"
        Me.btnGenerarReportePDF.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarReportePDF.TabIndex = 22
        Me.btnGenerarReportePDF.Text = "✓"
        Me.btnGenerarReportePDF.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(134, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 2
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarPDF
        '
        Me.lblExportarPDF.AutoSize = True
        Me.lblExportarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarPDF.Location = New System.Drawing.Point(211, 37)
        Me.lblExportarPDF.Name = "lblExportarPDF"
        Me.lblExportarPDF.Size = New System.Drawing.Size(70, 13)
        Me.lblExportarPDF.TabIndex = 23
        Me.lblExportarPDF.Text = "Exportar PDF"
        '
        'lblArticulos
        '
        Me.lblArticulos.AutoSize = True
        Me.lblArticulos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblArticulos.Location = New System.Drawing.Point(30, 46)
        Me.lblArticulos.Name = "lblArticulos"
        Me.lblArticulos.Size = New System.Drawing.Size(49, 13)
        Me.lblArticulos.TabIndex = 28
        Me.lblArticulos.Text = "Artículos"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(1025, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.lblSeleccionados)
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Controls.Add(Me.lblRegistros)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 457)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1085, 81)
        Me.Panel2.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblContados)
        Me.Panel1.Location = New System.Drawing.Point(51, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(157, 34)
        Me.Panel1.TabIndex = 9
        '
        'lblContados
        '
        Me.lblContados.AutoSize = True
        Me.lblContados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblContados.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblContados.Location = New System.Drawing.Point(0, 0)
        Me.lblContados.Name = "lblContados"
        Me.lblContados.Size = New System.Drawing.Size(25, 25)
        Me.lblContados.TabIndex = 7
        Me.lblContados.Text = "0"
        '
        'lblSeleccionados
        '
        Me.lblSeleccionados.AutoSize = True
        Me.lblSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionados.Location = New System.Drawing.Point(12, 28)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(126, 20)
        Me.lblSeleccionados.TabIndex = 8
        Me.lblSeleccionados.Text = "Seleccionados"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlBotones.Controls.Add(Me.lblAceptar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(854, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(231, 81)
        Me.pnlBotones.TabIndex = 5
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_321
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(115, 16)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 21
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(111, 51)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 22
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(54, 51)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 19
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(59, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 20
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(171, 16)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(170, 51)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(35, 10)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(79, 20)
        Me.lblRegistros.TabIndex = 6
        Me.lblRegistros.Text = "Artículos"
        '
        'chkSelccionarTodo
        '
        Me.chkSelccionarTodo.AutoSize = True
        Me.chkSelccionarTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSelccionarTodo.Location = New System.Drawing.Point(19, 44)
        Me.chkSelccionarTodo.Name = "chkSelccionarTodo"
        Me.chkSelccionarTodo.Size = New System.Drawing.Size(135, 20)
        Me.chkSelccionarTodo.TabIndex = 11
        Me.chkSelccionarTodo.Text = "Seleccionar Todo"
        Me.chkSelccionarTodo.UseVisualStyleBackColor = True
        '
        'grdHistoricoPreciosBase
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdHistoricoPreciosBase.DisplayLayout.Appearance = Appearance1
        Me.grdHistoricoPreciosBase.DisplayLayout.GroupByBox.Hidden = True
        Me.grdHistoricoPreciosBase.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdHistoricoPreciosBase.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdHistoricoPreciosBase.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdHistoricoPreciosBase.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdHistoricoPreciosBase.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdHistoricoPreciosBase.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdHistoricoPreciosBase.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdHistoricoPreciosBase.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdHistoricoPreciosBase.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdHistoricoPreciosBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHistoricoPreciosBase.Location = New System.Drawing.Point(0, 130)
        Me.grdHistoricoPreciosBase.Name = "grdHistoricoPreciosBase"
        Me.grdHistoricoPreciosBase.Size = New System.Drawing.Size(1085, 327)
        Me.grdHistoricoPreciosBase.TabIndex = 6
        '
        'pblContenedor
        '
        Me.pblContenedor.Controls.Add(Me.pnlCombo)
        Me.pblContenedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.pblContenedor.Location = New System.Drawing.Point(0, 60)
        Me.pblContenedor.Name = "pblContenedor"
        Me.pblContenedor.Size = New System.Drawing.Size(1085, 70)
        Me.pblContenedor.TabIndex = 7
        '
        'pnlCombo
        '
        Me.pnlCombo.Controls.Add(Me.chkSelccionarTodo)
        Me.pnlCombo.Controls.Add(Me.cmbListas)
        Me.pnlCombo.Controls.Add(Me.lblListas)
        Me.pnlCombo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCombo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCombo.Name = "pnlCombo"
        Me.pnlCombo.Size = New System.Drawing.Size(753, 70)
        Me.pnlCombo.TabIndex = 2
        '
        'cmbListas
        '
        Me.cmbListas.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cmbListas.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbListas.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbListas.CheckedListSettings.CheckBoxStyle = Infragistics.Win.CheckStyle.TriState
        Me.cmbListas.CheckedListSettings.EditorValueSource = Infragistics.Win.EditorWithComboValueSource.CheckedItems
        Me.cmbListas.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.cmbListas.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbListas.Location = New System.Drawing.Point(214, 11)
        Me.cmbListas.Name = "cmbListas"
        Me.cmbListas.Size = New System.Drawing.Size(503, 21)
        Me.cmbListas.TabIndex = 0
        '
        'lblListas
        '
        Me.lblListas.AutoSize = True
        Me.lblListas.Location = New System.Drawing.Point(16, 15)
        Me.lblListas.Name = "lblListas"
        Me.lblListas.Size = New System.Drawing.Size(192, 13)
        Me.lblListas.TabIndex = 1
        Me.lblListas.Text = "Seleccionar listas de precio a comparar"
        '
        'exportExcelListasP
        '
        '
        'ListaBaseHistorico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1085, 538)
        Me.Controls.Add(Me.grdHistoricoPreciosBase)
        Me.Controls.Add(Me.pblContenedor)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ListaBaseHistorico"
        Me.Text = "Historial de Listas de Precios Base"
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdHistoricoPreciosBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pblContenedor.ResumeLayout(False)
        Me.pnlCombo.ResumeLayout(False)
        Me.pnlCombo.PerformLayout()
        CType(Me.cmbListas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdHistoricoPreciosBase As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pblContenedor As System.Windows.Forms.Panel
    Friend WithEvents lblListas As System.Windows.Forms.Label
    Friend WithEvents cmbListas As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents pnlCombo As System.Windows.Forms.Panel
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents btnGenerarReportePDF As System.Windows.Forms.Button
    Friend WithEvents lblExportarPDF As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents exportExcelListasP As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblContados As System.Windows.Forms.Label
    Friend WithEvents lblSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents btnHistorico As System.Windows.Forms.Button
    Friend WithEvents lblHistorico As System.Windows.Forms.Label
    Friend WithEvents lblArticulos As System.Windows.Forms.Label
    Friend WithEvents chkSelccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
End Class
