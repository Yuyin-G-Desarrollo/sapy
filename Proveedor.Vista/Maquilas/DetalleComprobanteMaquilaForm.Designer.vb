<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetalleComprobanteMaquilaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetalleComprobanteMaquilaForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTotalDocumento = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdDetalles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblTotalDocumento)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.lblTotalPares)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 449)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1074, 60)
        Me.Panel1.TabIndex = 80
        '
        'lblTotalDocumento
        '
        Me.lblTotalDocumento.AutoSize = True
        Me.lblTotalDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblTotalDocumento.Location = New System.Drawing.Point(798, 37)
        Me.lblTotalDocumento.Name = "lblTotalDocumento"
        Me.lblTotalDocumento.Size = New System.Drawing.Size(25, 13)
        Me.lblTotalDocumento.TabIndex = 59
        Me.lblTotalDocumento.Text = "$ 0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(756, 37)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(34, 13)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "Total:"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.Location = New System.Drawing.Point(798, 16)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(25, 13)
        Me.lblTotalPares.TabIndex = 57
        Me.lblTotalPares.Text = "$ 0"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(729, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(63, 13)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Total pares:"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(996, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(78, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(23, 6)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(24, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnExportar)
        Me.pnlHeader.Controls.Add(Me.Label14)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1074, 60)
        Me.pnlHeader.TabIndex = 78
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(15, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 168
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label14.Location = New System.Drawing.Point(8, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Exportar"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(518, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(556, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(17, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(437, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Detalle Comprobante de Compra Producto Terminado"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdDetalles)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1074, 389)
        Me.Panel2.TabIndex = 82
        '
        'grdDetalles
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetalles.DisplayLayout.Appearance = Appearance1
        Me.grdDetalles.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDetalles.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdDetalles.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDetalles.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDetalles.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdDetalles.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetalles.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDetalles.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDetalles.Location = New System.Drawing.Point(0, 0)
        Me.grdDetalles.Name = "grdDetalles"
        Me.grdDetalles.Size = New System.Drawing.Size(1074, 389)
        Me.grdDetalles.TabIndex = 34
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(488, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'DetalleComprobanteMaquilaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 509)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1082, 536)
        Me.MinimumSize = New System.Drawing.Size(1082, 536)
        Me.Name = "DetalleComprobanteMaquilaForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents lblTotalDocumento As Windows.Forms.Label
    Friend WithEvents Label25 As Windows.Forms.Label
    Friend WithEvents lblTotalPares As Windows.Forms.Label
    Friend WithEvents Label23 As Windows.Forms.Label
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents bntSalir As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents grdDetalles As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
