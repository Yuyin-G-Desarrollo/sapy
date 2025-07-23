<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportesProduccionMaquilasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportesProduccionMaquilasForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdReporte = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chekReportedePlanta = New System.Windows.Forms.CheckBox()
        Me.chekOrdenPedidoDesglosadoCorte = New System.Windows.Forms.CheckBox()
        Me.chekDesglosadoSuela = New System.Windows.Forms.CheckBox()
        Me.chekConcentradoPlantaporProveedor = New System.Windows.Forms.CheckBox()
        Me.chekConcentradoSuelaporProveedor = New System.Windows.Forms.CheckBox()
        Me.chekReporteSuela = New System.Windows.Forms.CheckBox()
        Me.chekReporteCaja = New System.Windows.Forms.CheckBox()
        Me.chekOrdenProduccion = New System.Windows.Forms.CheckBox()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblImprimir)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Controls.Add(Me.btnImprimir)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(472, 63)
        Me.pnlEncabezado.TabIndex = 2025
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(14, 43)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 104
        Me.lblImprimir.Text = "Imprimir"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(115, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(283, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = " Reportes de Producción Maquilas"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(404, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(17, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 101
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.cmbNave)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 99)
        Me.Panel1.TabIndex = 2026
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(15, 77)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodo.TabIndex = 146
        Me.chkSeleccionarTodo.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(120, 9)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(200, 21)
        Me.cmbNave.TabIndex = 145
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(120, 45)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 105
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nave:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.grdReporte)
        Me.Panel2.Controls.Add(Me.chekReportedePlanta)
        Me.Panel2.Controls.Add(Me.chekOrdenPedidoDesglosadoCorte)
        Me.Panel2.Controls.Add(Me.chekDesglosadoSuela)
        Me.Panel2.Controls.Add(Me.chekConcentradoPlantaporProveedor)
        Me.Panel2.Controls.Add(Me.chekConcentradoSuelaporProveedor)
        Me.Panel2.Controls.Add(Me.chekReporteSuela)
        Me.Panel2.Controls.Add(Me.chekReporteCaja)
        Me.Panel2.Controls.Add(Me.chekOrdenProduccion)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 162)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 311)
        Me.Panel2.TabIndex = 2027
        '
        'grdReporte
        '
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporte.Location = New System.Drawing.Point(0, 0)
        Me.grdReporte.MainView = Me.vwReporte
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(472, 311)
        Me.grdReporte.TabIndex = 13
        Me.grdReporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte})
        '
        'vwReporte
        '
        Me.vwReporte.GridControl = Me.grdReporte
        Me.vwReporte.IndicatorWidth = 25
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsCustomization.AllowColumnMoving = False
        Me.vwReporte.OptionsCustomization.AllowGroup = False
        Me.vwReporte.OptionsMenu.EnableColumnMenu = False
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsView.ShowAutoFilterRow = True
        Me.vwReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwReporte.OptionsView.ShowDetailButtons = False
        Me.vwReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwReporte.OptionsView.ShowFooter = True
        Me.vwReporte.OptionsView.ShowGroupPanel = False
        '
        'chekReportedePlanta
        '
        Me.chekReportedePlanta.AutoSize = True
        Me.chekReportedePlanta.Location = New System.Drawing.Point(189, 130)
        Me.chekReportedePlanta.Name = "chekReportedePlanta"
        Me.chekReportedePlanta.Size = New System.Drawing.Size(112, 17)
        Me.chekReportedePlanta.TabIndex = 8
        Me.chekReportedePlanta.Text = "Reporte de Planta"
        Me.chekReportedePlanta.UseVisualStyleBackColor = True
        '
        'chekOrdenPedidoDesglosadoCorte
        '
        Me.chekOrdenPedidoDesglosadoCorte.AutoSize = True
        Me.chekOrdenPedidoDesglosadoCorte.Location = New System.Drawing.Point(189, 59)
        Me.chekOrdenPedidoDesglosadoCorte.Name = "chekOrdenPedidoDesglosadoCorte"
        Me.chekOrdenPedidoDesglosadoCorte.Size = New System.Drawing.Size(205, 17)
        Me.chekOrdenPedidoDesglosadoCorte.TabIndex = 7
        Me.chekOrdenPedidoDesglosadoCorte.Text = "Orden de Pedido Desglosado P/Corte"
        Me.chekOrdenPedidoDesglosadoCorte.UseVisualStyleBackColor = True
        '
        'chekDesglosadoSuela
        '
        Me.chekDesglosadoSuela.AutoSize = True
        Me.chekDesglosadoSuela.Location = New System.Drawing.Point(17, 59)
        Me.chekDesglosadoSuela.Name = "chekDesglosadoSuela"
        Me.chekDesglosadoSuela.Size = New System.Drawing.Size(127, 17)
        Me.chekDesglosadoSuela.TabIndex = 6
        Me.chekDesglosadoSuela.Text = "Desglosado de Suela"
        Me.chekDesglosadoSuela.UseVisualStyleBackColor = True
        '
        'chekConcentradoPlantaporProveedor
        '
        Me.chekConcentradoPlantaporProveedor.AutoSize = True
        Me.chekConcentradoPlantaporProveedor.Location = New System.Drawing.Point(189, 96)
        Me.chekConcentradoPlantaporProveedor.Name = "chekConcentradoPlantaporProveedor"
        Me.chekConcentradoPlantaporProveedor.Size = New System.Drawing.Size(199, 17)
        Me.chekConcentradoPlantaporProveedor.TabIndex = 5
        Me.chekConcentradoPlantaporProveedor.Text = "Concentrado de Planta P/Proveedor"
        Me.chekConcentradoPlantaporProveedor.UseVisualStyleBackColor = True
        '
        'chekConcentradoSuelaporProveedor
        '
        Me.chekConcentradoSuelaporProveedor.AutoSize = True
        Me.chekConcentradoSuelaporProveedor.Location = New System.Drawing.Point(189, 22)
        Me.chekConcentradoSuelaporProveedor.Name = "chekConcentradoSuelaporProveedor"
        Me.chekConcentradoSuelaporProveedor.Size = New System.Drawing.Size(196, 17)
        Me.chekConcentradoSuelaporProveedor.TabIndex = 4
        Me.chekConcentradoSuelaporProveedor.Text = "Concentrado de Suela P/Proveedor"
        Me.chekConcentradoSuelaporProveedor.UseVisualStyleBackColor = True
        '
        'chekReporteSuela
        '
        Me.chekReporteSuela.AutoSize = True
        Me.chekReporteSuela.Location = New System.Drawing.Point(17, 130)
        Me.chekReporteSuela.Name = "chekReporteSuela"
        Me.chekReporteSuela.Size = New System.Drawing.Size(109, 17)
        Me.chekReporteSuela.TabIndex = 2
        Me.chekReporteSuela.Text = "Reporte de Suela"
        Me.chekReporteSuela.UseVisualStyleBackColor = True
        '
        'chekReporteCaja
        '
        Me.chekReporteCaja.AutoSize = True
        Me.chekReporteCaja.Location = New System.Drawing.Point(17, 96)
        Me.chekReporteCaja.Name = "chekReporteCaja"
        Me.chekReporteCaja.Size = New System.Drawing.Size(103, 17)
        Me.chekReporteCaja.TabIndex = 1
        Me.chekReporteCaja.Text = "Reporte de Caja"
        Me.chekReporteCaja.UseVisualStyleBackColor = True
        '
        'chekOrdenProduccion
        '
        Me.chekOrdenProduccion.AutoSize = True
        Me.chekOrdenProduccion.Location = New System.Drawing.Point(17, 22)
        Me.chekOrdenProduccion.Name = "chekOrdenProduccion"
        Me.chekOrdenProduccion.Size = New System.Drawing.Size(127, 17)
        Me.chekOrdenProduccion.TabIndex = 0
        Me.chekOrdenProduccion.Text = "Orden de Produccion"
        Me.chekOrdenProduccion.UseVisualStyleBackColor = True
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'ReportesProduccionMaquilasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 473)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(480, 500)
        Me.MinimumSize = New System.Drawing.Size(480, 500)
        Me.Name = "ReportesProduccionMaquilasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes Producción Maquilas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblImprimir As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chekConcentradoPlantaporProveedor As CheckBox
    Friend WithEvents chekConcentradoSuelaporProveedor As CheckBox
    Friend WithEvents chekReporteSuela As CheckBox
    Friend WithEvents chekReporteCaja As CheckBox
    Friend WithEvents chekOrdenProduccion As CheckBox
    Friend WithEvents chekDesglosadoSuela As CheckBox
    Friend WithEvents chekOrdenPedidoDesglosadoCorte As CheckBox
    Friend WithEvents chekReportedePlanta As CheckBox
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdReporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkSeleccionarTodo As CheckBox
End Class
