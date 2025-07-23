<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaListadoModelosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaListadoModelosForm))
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btn_ExportarFracciones = New System.Windows.Forms.Button()
        Me.lbl_ExportarFracciones = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.grdModelos = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(931, 39)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 103
        Me.lblSalir.Text = "Cerrar"
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Location = New System.Drawing.Point(12, 16)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(0, 13)
        Me.lblMensaje.TabIndex = 99
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.Button1)
        Me.pnlInferior.Controls.Add(Me.lblMensaje)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 394)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(982, 56)
        Me.pnlInferior.TabIndex = 160
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.Button1.Location = New System.Drawing.Point(931, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 102
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(754, 25)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(143, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Articulos Nuevos"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btn_ExportarFracciones)
        Me.pnlEncabezado.Controls.Add(Me.lbl_ExportarFracciones)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(982, 63)
        Me.pnlEncabezado.TabIndex = 159
        '
        'btn_ExportarFracciones
        '
        Me.btn_ExportarFracciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_ExportarFracciones.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btn_ExportarFracciones.Location = New System.Drawing.Point(26, 3)
        Me.btn_ExportarFracciones.Name = "btn_ExportarFracciones"
        Me.btn_ExportarFracciones.Size = New System.Drawing.Size(32, 32)
        Me.btn_ExportarFracciones.TabIndex = 241
        Me.btn_ExportarFracciones.UseVisualStyleBackColor = True
        '
        'lbl_ExportarFracciones
        '
        Me.lbl_ExportarFracciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_ExportarFracciones.AutoSize = True
        Me.lbl_ExportarFracciones.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbl_ExportarFracciones.Location = New System.Drawing.Point(3, 38)
        Me.lbl_ExportarFracciones.Name = "lbl_ExportarFracciones"
        Me.lbl_ExportarFracciones.Size = New System.Drawing.Size(89, 13)
        Me.lbl_ExportarFracciones.TabIndex = 242
        Me.lbl_ExportarFracciones.Text = "Exportar Articulos"
        Me.lbl_ExportarFracciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(914, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'grdModelos
        '
        Me.grdModelos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdModelos.Location = New System.Drawing.Point(0, 63)
        Me.grdModelos.MainView = Me.vwReporte
        Me.grdModelos.Name = "grdModelos"
        Me.grdModelos.Size = New System.Drawing.Size(982, 331)
        Me.grdModelos.TabIndex = 2022
        Me.grdModelos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte, Me.GridView1})
        '
        'vwReporte
        '
        Me.vwReporte.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.vwReporte.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwReporte.GridControl = Me.grdModelos
        Me.vwReporte.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.vwReporte.IndicatorWidth = 25
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsCustomization.AllowColumnMoving = False
        Me.vwReporte.OptionsCustomization.AllowGroup = False
        Me.vwReporte.OptionsMenu.EnableColumnMenu = False
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsView.EnableAppearanceEvenRow = True
        Me.vwReporte.OptionsView.EnableAppearanceOddRow = True
        Me.vwReporte.OptionsView.ShowAutoFilterRow = True
        Me.vwReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwReporte.OptionsView.ShowDetailButtons = False
        Me.vwReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwReporte.OptionsView.ShowFooter = True
        Me.vwReporte.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdModelos
        Me.GridView1.Name = "GridView1"
        '
        'ConsultaListadoModelosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 450)
        Me.Controls.Add(Me.grdModelos)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ConsultaListadoModelosForm"
        Me.Text = "Consulta Listado Modelos"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdModelos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSalir As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblMensaje As Label
    Friend WithEvents pnlInferior As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents grdModelos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btn_ExportarFracciones As Button
    Friend WithEvents lbl_ExportarFracciones As Label
End Class
