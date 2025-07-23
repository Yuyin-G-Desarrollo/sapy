<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReporteOrdenesEnProcesoPorMesForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteOrdenesEnProcesoPorMesForm))
        Me.gridVReporteMes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdReporteMes = New DevExpress.XtraGrid.GridControl()
        Me.pnlReporte = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        CType(Me.gridVReporteMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdReporteMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReporte.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridVReporteMes
        '
        Me.gridVReporteMes.GridControl = Me.grdReporteMes
        Me.gridVReporteMes.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, Nothing, Nothing, "")})
        Me.gridVReporteMes.Name = "gridVReporteMes"
        Me.gridVReporteMes.OptionsDetail.EnableDetailToolTip = True
        Me.gridVReporteMes.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.gridVReporteMes.OptionsView.ShowAutoFilterRow = True
        Me.gridVReporteMes.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.gridVReporteMes.OptionsView.ShowFooter = True
        Me.gridVReporteMes.OptionsView.ShowGroupPanel = False
        '
        'grdReporteMes
        '
        Me.grdReporteMes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdReporteMes.Location = New System.Drawing.Point(3, 3)
        Me.grdReporteMes.MainView = Me.gridVReporteMes
        Me.grdReporteMes.Name = "grdReporteMes"
        Me.grdReporteMes.Size = New System.Drawing.Size(881, 215)
        Me.grdReporteMes.TabIndex = 0
        Me.grdReporteMes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridVReporteMes})
        '
        'pnlReporte
        '
        Me.pnlReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlReporte.Controls.Add(Me.grdReporteMes)
        Me.pnlReporte.Location = New System.Drawing.Point(0, 60)
        Me.pnlReporte.Name = "pnlReporte"
        Me.pnlReporte.Size = New System.Drawing.Size(887, 221)
        Me.pnlReporte.TabIndex = 2028
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(12, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 46
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(475, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(336, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Reporte de Órdenes en Proceso por Mes"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(819, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(5, 43)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 47
        Me.lblExportar.Text = "Exportar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(887, 63)
        Me.pnlEncabezado.TabIndex = 2026
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(851, 324)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 2030
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(852, 287)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 2029
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'ReporteOrdenesEnProcesoPorMesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 338)
        Me.Controls.Add(Me.lblSalir)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.pnlReporte)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ReporteOrdenesEnProcesoPorMesForm"
        Me.Text = "Reporte Ordenes En Proceso Por Mes"
        CType(Me.gridVReporteMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdReporteMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReporte.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gridVReporteMes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdReporteMes As DevExpress.XtraGrid.GridControl
    Friend WithEvents pnlReporte As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblExportar As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblSalir As Label
    Friend WithEvents btnSalir As Button
End Class
