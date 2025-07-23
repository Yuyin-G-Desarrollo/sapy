<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaCierreAnualCerrada
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaCierreAnualCerrada))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblReporteDeducciones = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblAccionExportar = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.grCajaAhorro = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkVerDetalleSemanas = New System.Windows.Forms.CheckBox()
        Me.chkTotales = New System.Windows.Forms.CheckBox()
        Me.chkResumen = New System.Windows.Forms.CheckBox()
        Me.chkSeleccionarTodos = New System.Windows.Forms.CheckBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grdCierreAnual = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.exportExcelDetalle = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.menuImprimir = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CartaCajaDeAhorroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResumenAnualCajaDeAhorroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpresionDeSobresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grCajaAhorro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCierreAnual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuImprimir.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblReporteDeducciones)
        Me.pnlHeader.Controls.Add(Me.btnImprimir)
        Me.pnlHeader.Controls.Add(Me.lblAccionExportar)
        Me.pnlHeader.Controls.Add(Me.Panel4)
        Me.pnlHeader.Controls.Add(Me.btnExportar)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1241, 60)
        Me.pnlHeader.TabIndex = 35
        '
        'lblReporteDeducciones
        '
        Me.lblReporteDeducciones.AutoSize = True
        Me.lblReporteDeducciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporteDeducciones.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReporteDeducciones.Location = New System.Drawing.Point(87, 41)
        Me.lblReporteDeducciones.Name = "lblReporteDeducciones"
        Me.lblReporteDeducciones.Size = New System.Drawing.Size(42, 13)
        Me.lblReporteDeducciones.TabIndex = 50
        Me.lblReporteDeducciones.Text = "Imprimir"
        Me.lblReporteDeducciones.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.AliceBlue
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(91, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 49
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblAccionExportar
        '
        Me.lblAccionExportar.AutoSize = True
        Me.lblAccionExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionExportar.Location = New System.Drawing.Point(17, 42)
        Me.lblAccionExportar.Name = "lblAccionExportar"
        Me.lblAccionExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblAccionExportar.TabIndex = 40
        Me.lblAccionExportar.Text = "Exportar"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pcbTitulo)
        Me.Panel4.Controls.Add(Me.lblTitulo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(841, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(400, 60)
        Me.Panel4.TabIndex = 48
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(72, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(258, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Cierre Anual de Caja de Ahorro"
        '
        'btnExportar
        '
        Me.btnExportar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(24, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 39
        Me.btnExportar.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 465)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1241, 60)
        Me.Panel3.TabIndex = 43
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnRegresar)
        Me.Panel2.Controls.Add(Me.lblAccionRegresar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1097, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(144, 60)
        Me.Panel2.TabIndex = 41
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(94, 6)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 36
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'lblAccionRegresar
        '
        Me.lblAccionRegresar.AutoSize = True
        Me.lblAccionRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionRegresar.Location = New System.Drawing.Point(93, 40)
        Me.lblAccionRegresar.Name = "lblAccionRegresar"
        Me.lblAccionRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblAccionRegresar.TabIndex = 39
        Me.lblAccionRegresar.Text = "Cerrar"
        '
        'grCajaAhorro
        '
        Me.grCajaAhorro.BackColor = System.Drawing.Color.Transparent
        Me.grCajaAhorro.Controls.Add(Me.GroupBox1)
        Me.grCajaAhorro.Controls.Add(Me.chkSeleccionarTodos)
        Me.grCajaAhorro.Controls.Add(Me.lblConcepto)
        Me.grCajaAhorro.Controls.Add(Me.Panel1)
        Me.grCajaAhorro.Dock = System.Windows.Forms.DockStyle.Top
        Me.grCajaAhorro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.grCajaAhorro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grCajaAhorro.Location = New System.Drawing.Point(0, 60)
        Me.grCajaAhorro.Name = "grCajaAhorro"
        Me.grCajaAhorro.Size = New System.Drawing.Size(1241, 75)
        Me.grCajaAhorro.TabIndex = 44
        Me.grCajaAhorro.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkVerDetalleSemanas)
        Me.GroupBox1.Controls.Add(Me.chkTotales)
        Me.GroupBox1.Controls.Add(Me.chkResumen)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(403, 33)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ver"
        '
        'chkVerDetalleSemanas
        '
        Me.chkVerDetalleSemanas.AutoSize = True
        Me.chkVerDetalleSemanas.Checked = True
        Me.chkVerDetalleSemanas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVerDetalleSemanas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerDetalleSemanas.Location = New System.Drawing.Point(39, 11)
        Me.chkVerDetalleSemanas.Name = "chkVerDetalleSemanas"
        Me.chkVerDetalleSemanas.Size = New System.Drawing.Size(119, 17)
        Me.chkVerDetalleSemanas.TabIndex = 51
        Me.chkVerDetalleSemanas.Text = "Detalle de semanas"
        Me.chkVerDetalleSemanas.UseVisualStyleBackColor = True
        '
        'chkTotales
        '
        Me.chkTotales.AutoSize = True
        Me.chkTotales.Checked = True
        Me.chkTotales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTotales.Location = New System.Drawing.Point(327, 11)
        Me.chkTotales.Name = "chkTotales"
        Me.chkTotales.Size = New System.Drawing.Size(61, 17)
        Me.chkTotales.TabIndex = 53
        Me.chkTotales.Text = "Totales"
        Me.chkTotales.UseVisualStyleBackColor = True
        '
        'chkResumen
        '
        Me.chkResumen.AutoSize = True
        Me.chkResumen.Checked = True
        Me.chkResumen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkResumen.Location = New System.Drawing.Point(177, 11)
        Me.chkResumen.Name = "chkResumen"
        Me.chkResumen.Size = New System.Drawing.Size(131, 17)
        Me.chkResumen.TabIndex = 52
        Me.chkResumen.Text = "Resumen de semanas"
        Me.chkResumen.UseVisualStyleBackColor = True
        '
        'chkSeleccionarTodos
        '
        Me.chkSeleccionarTodos.AutoSize = True
        Me.chkSeleccionarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarTodos.Location = New System.Drawing.Point(486, 50)
        Me.chkSeleccionarTodos.Name = "chkSeleccionarTodos"
        Me.chkSeleccionarTodos.Size = New System.Drawing.Size(196, 17)
        Me.chkSeleccionarTodos.TabIndex = 40
        Me.chkSeleccionarTodos.Text = "Seleccionar todo para generar carta"
        Me.chkSeleccionarTodos.UseVisualStyleBackColor = True
        '
        'lblConcepto
        '
        Me.lblConcepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcepto.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblConcepto.Location = New System.Drawing.Point(12, 16)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(27, 20)
        Me.lblConcepto.TabIndex = 39
        Me.lblConcepto.Text = "---"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1121, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(117, 56)
        Me.Panel1.TabIndex = 38
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(53, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(86, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'grdCierreAnual
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCierreAnual.DisplayLayout.Appearance = Appearance1
        UltraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        Me.grdCierreAnual.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.grdCierreAnual.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCierreAnual.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.grdCierreAnual.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdCierreAnual.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCierreAnual.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCierreAnual.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.FixOrder
        Me.grdCierreAnual.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCierreAnual.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdCierreAnual.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCierreAnual.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag
        Me.grdCierreAnual.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdCierreAnual.DisplayLayout.UseFixedHeaders = True
        Me.grdCierreAnual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCierreAnual.Location = New System.Drawing.Point(0, 135)
        Me.grdCierreAnual.Name = "grdCierreAnual"
        Me.grdCierreAnual.Size = New System.Drawing.Size(1241, 330)
        Me.grdCierreAnual.TabIndex = 45
        '
        'menuImprimir
        '
        Me.menuImprimir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CartaCajaDeAhorroToolStripMenuItem, Me.ResumenAnualCajaDeAhorroToolStripMenuItem, Me.ImpresionDeSobresToolStripMenuItem})
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Size = New System.Drawing.Size(235, 70)
        '
        'CartaCajaDeAhorroToolStripMenuItem
        '
        Me.CartaCajaDeAhorroToolStripMenuItem.Name = "CartaCajaDeAhorroToolStripMenuItem"
        Me.CartaCajaDeAhorroToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.CartaCajaDeAhorroToolStripMenuItem.Text = "Carta Cierre Caja de Ahorro"
        '
        'ResumenAnualCajaDeAhorroToolStripMenuItem
        '
        Me.ResumenAnualCajaDeAhorroToolStripMenuItem.Name = "ResumenAnualCajaDeAhorroToolStripMenuItem"
        Me.ResumenAnualCajaDeAhorroToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.ResumenAnualCajaDeAhorroToolStripMenuItem.Text = "Reporte Anual de Caja de Ahorro"
        '
        'ImpresionDeSobresToolStripMenuItem
        '
        Me.ImpresionDeSobresToolStripMenuItem.Name = "ImpresionDeSobresToolStripMenuItem"
        Me.ImpresionDeSobresToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.ImpresionDeSobresToolStripMenuItem.Text = "Impresión de Sobres"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(332, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 29
        Me.pcbTitulo.TabStop = False
        '
        'frmConsultaCierreAnualCerrada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 525)
        Me.Controls.Add(Me.grdCierreAnual)
        Me.Controls.Add(Me.grCajaAhorro)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaCierreAnualCerrada"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre Anual de Caja de Ahorro"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grCajaAhorro.ResumeLayout(False)
        Me.grCajaAhorro.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdCierreAnual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuImprimir.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents grCajaAhorro As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents grdCierreAnual As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblAccionExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblConcepto As System.Windows.Forms.Label
    Friend WithEvents exportExcelDetalle As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents chkSeleccionarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents lblReporteDeducciones As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents menuImprimir As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CartaCajaDeAhorroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResumenAnualCajaDeAhorroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkVerDetalleSemanas As System.Windows.Forms.CheckBox
    Friend WithEvents chkTotales As System.Windows.Forms.CheckBox
    Friend WithEvents chkResumen As System.Windows.Forms.CheckBox
    Friend WithEvents ImpresionDeSobresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pcbTitulo As PictureBox
End Class
