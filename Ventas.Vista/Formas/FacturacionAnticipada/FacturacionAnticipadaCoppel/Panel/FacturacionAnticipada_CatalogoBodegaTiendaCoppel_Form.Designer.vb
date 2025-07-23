<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturacionAnticipada_CatalogoBodegaTiendaCoppel_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturacionAnticipada_CatalogoBodegaTiendaCoppel_Form))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnVincularTienda = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnAltaBodega = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlEncabezadoExpander = New System.Windows.Forms.Panel()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.grdBodegas = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosBodegas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdTiendas = New DevExpress.XtraGrid.GridControl()
        Me.grdDatosTiendas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlEncabezadoExpander.SuspendLayout()
        CType(Me.grdBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosBodegas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTiendas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatosTiendas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pnlExportar)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(800, 65)
        Me.pnlTitulo.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnVincularTienda)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(58, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(62, 65)
        Me.Panel1.TabIndex = 108
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(9, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Tiendas"
        '
        'btnVincularTienda
        '
        Me.btnVincularTienda.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVincularTienda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVincularTienda.Image = Global.Ventas.Vista.My.Resources.Resources.editar_321
        Me.btnVincularTienda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVincularTienda.Location = New System.Drawing.Point(15, 3)
        Me.btnVincularTienda.Name = "btnVincularTienda"
        Me.btnVincularTienda.Size = New System.Drawing.Size(32, 32)
        Me.btnVincularTienda.TabIndex = 100
        Me.btnVincularTienda.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Vincular"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnAltaBodega)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(58, 65)
        Me.pnlExportar.TabIndex = 107
        '
        'btnAltaBodega
        '
        Me.btnAltaBodega.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAltaBodega.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAltaBodega.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAltaBodega.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAltaBodega.Location = New System.Drawing.Point(15, 3)
        Me.btnAltaBodega.Name = "btnAltaBodega"
        Me.btnAltaBodega.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaBodega.TabIndex = 100
        Me.btnAltaBodega.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(19, 38)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(25, 13)
        Me.lblExportar.TabIndex = 99
        Me.lblExportar.Text = "Alta"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(448, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(278, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Catálogo Bodega-Tiendas Coppel"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.btnMostrar)
        Me.pnlPie.Controls.Add(Me.lblCerrar)
        Me.pnlPie.Controls.Add(Me.btnCerrar)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 387)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(800, 63)
        Me.pnlPie.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(704, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(705, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(753, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(756, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pnlEncabezadoExpander
        '
        Me.pnlEncabezadoExpander.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlEncabezadoExpander.Controls.Add(Me.pnlBotonesExpander)
        Me.pnlEncabezadoExpander.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezadoExpander.Location = New System.Drawing.Point(0, 65)
        Me.pnlEncabezadoExpander.Name = "pnlEncabezadoExpander"
        Me.pnlEncabezadoExpander.Size = New System.Drawing.Size(800, 25)
        Me.pnlEncabezadoExpander.TabIndex = 162
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(736, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(64, 25)
        Me.pnlBotonesExpander.TabIndex = 0
        '
        'grdBodegas
        '
        Me.grdBodegas.Dock = System.Windows.Forms.DockStyle.Left
        Me.grdBodegas.Location = New System.Drawing.Point(0, 90)
        Me.grdBodegas.MainView = Me.grdDatosBodegas
        Me.grdBodegas.Name = "grdBodegas"
        Me.grdBodegas.Size = New System.Drawing.Size(400, 297)
        Me.grdBodegas.TabIndex = 163
        Me.grdBodegas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosBodegas})
        '
        'grdDatosBodegas
        '
        Me.grdDatosBodegas.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosBodegas.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosBodegas.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosBodegas.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosBodegas.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosBodegas.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosBodegas.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosBodegas.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosBodegas.GridControl = Me.grdBodegas
        Me.grdDatosBodegas.IndicatorWidth = 30
        Me.grdDatosBodegas.Name = "grdDatosBodegas"
        Me.grdDatosBodegas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosBodegas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosBodegas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosBodegas.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosBodegas.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosBodegas.OptionsView.ColumnAutoWidth = False
        Me.grdDatosBodegas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosBodegas.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosBodegas.OptionsView.ShowAutoFilterRow = True
        Me.grdDatosBodegas.OptionsView.ShowFooter = True
        '
        'grdTiendas
        '
        Me.grdTiendas.Dock = System.Windows.Forms.DockStyle.Left
        Me.grdTiendas.Location = New System.Drawing.Point(400, 90)
        Me.grdTiendas.MainView = Me.grdDatosTiendas
        Me.grdTiendas.Name = "grdTiendas"
        Me.grdTiendas.Size = New System.Drawing.Size(400, 297)
        Me.grdTiendas.TabIndex = 164
        Me.grdTiendas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatosTiendas})
        '
        'grdDatosTiendas
        '
        Me.grdDatosTiendas.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosTiendas.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatosTiendas.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatosTiendas.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatosTiendas.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatosTiendas.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatosTiendas.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatosTiendas.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatosTiendas.GridControl = Me.grdTiendas
        Me.grdDatosTiendas.IndicatorWidth = 30
        Me.grdDatosTiendas.Name = "grdDatosTiendas"
        Me.grdDatosTiendas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosTiendas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatosTiendas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatosTiendas.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdDatosTiendas.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatosTiendas.OptionsView.ColumnAutoWidth = False
        Me.grdDatosTiendas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatosTiendas.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdDatosTiendas.OptionsView.ShowAutoFilterRow = True
        Me.grdDatosTiendas.OptionsView.ShowFooter = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(732, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 109
        Me.PictureBox1.TabStop = False
        '
        'FacturacionAnticipada_CatalogoBodegaTiendaCoppel_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.grdTiendas)
        Me.Controls.Add(Me.grdBodegas)
        Me.Controls.Add(Me.pnlEncabezadoExpander)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "FacturacionAnticipada_CatalogoBodegaTiendaCoppel_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Bodega-Tiendas Coppel"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlEncabezadoExpander.ResumeLayout(False)
        CType(Me.grdBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosBodegas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTiendas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatosTiendas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblCerrar As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents pnlEncabezadoExpander As Panel
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents btnVincularTienda As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnAltaBodega As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents grdBodegas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosBodegas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdTiendas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatosTiendas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label3 As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
