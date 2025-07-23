<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenMotivosAtrasos
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResumenMotivosAtrasos))
        Me.grdResumenAtrasos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnExpCod = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.ultGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        CType(Me.grdResumenAtrasos,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlListaPaises.SuspendLayout
        Me.pnlHeader.SuspendLayout
        CType(Me.pbYuyin,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'grdResumenAtrasos
        '
        Me.grdResumenAtrasos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenAtrasos.DisplayLayout.Appearance = Appearance1
        Me.grdResumenAtrasos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdResumenAtrasos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdResumenAtrasos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdResumenAtrasos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdResumenAtrasos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdResumenAtrasos.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdResumenAtrasos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenAtrasos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdResumenAtrasos.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdResumenAtrasos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdResumenAtrasos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdResumenAtrasos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdResumenAtrasos.Location = New System.Drawing.Point(0, 50)
        Me.grdResumenAtrasos.Name = "grdResumenAtrasos"
        Me.grdResumenAtrasos.Size = New System.Drawing.Size(687, 279)
        Me.grdResumenAtrasos.TabIndex = 61
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.btnExpCod)
        Me.pnlListaPaises.Controls.Add(Me.Label7)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(687, 50)
        Me.pnlListaPaises.TabIndex = 62
        '
        'btnExpCod
        '
        Me.btnExpCod.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnExpCod.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExpCod.Location = New System.Drawing.Point(12, 4)
        Me.btnExpCod.Name = "btnExpCod"
        Me.btnExpCod.Size = New System.Drawing.Size(32, 32)
        Me.btnExpCod.TabIndex = 30
        Me.btnExpCod.UseVisualStyleBackColor = false
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(6, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Exportar"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(141, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(546, 50)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = true
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(230, 18)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(259, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Resumen de Motivos de Atraso"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"),System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(492, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(54, 50)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = false
        '
        'ResumenMotivosAtrasos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 329)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.grdResumenAtrasos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ResumenMotivosAtrasos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen Días de Retraso por Motivos de Atrasos"
        CType(Me.grdResumenAtrasos,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlListaPaises.ResumeLayout(false)
        Me.pnlListaPaises.PerformLayout
        Me.pnlHeader.ResumeLayout(false)
        Me.pnlHeader.PerformLayout
        CType(Me.pbYuyin,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents grdResumenAtrasos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents btnExpCod As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents ultGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    'Friend WithEvents ultGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
