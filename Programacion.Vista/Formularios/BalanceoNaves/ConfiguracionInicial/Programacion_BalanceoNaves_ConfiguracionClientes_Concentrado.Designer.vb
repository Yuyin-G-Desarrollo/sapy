<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programacion_BalanceoNaves_ConfiguracionClientes_Concentrado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Programacion_BalanceoNaves_ConfiguracionClientes_Concentrado))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpNaves = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdConfCliente = New DevExpress.XtraGrid.GridControl()
        Me.vwConfCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.grpNaves.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdConfCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwConfCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(601, 62)
        Me.pnlTitulo.TabIndex = 178
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pctTitulo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(144, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(457, 62)
        Me.Panel1.TabIndex = 165
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = CType(resources.GetObject("pctTitulo.Image"), System.Drawing.Image)
        Me.pctTitulo.Location = New System.Drawing.Point(389, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 62)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 90
        Me.pctTitulo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(41, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(329, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Configuración de Clientes -Concentrado"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.pnlBotonesExpander)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 62)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(601, 27)
        Me.Panel6.TabIndex = 179
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(537, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(64, 27)
        Me.pnlBotonesExpander.TabIndex = 1
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(34, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 13
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(7, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 12
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel3)
        Me.pnlFiltros.Controls.Add(Me.grpNaves)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 89)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(601, 133)
        Me.pnlFiltros.TabIndex = 180
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnMostrar)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(465, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(136, 133)
        Me.Panel3.TabIndex = 120
        '
        'btnMostrar
        '
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(20, 44)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 119
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(15, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Mostrar"
        '
        'grpNaves
        '
        Me.grpNaves.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.grpNaves.Controls.Add(Me.Panel7)
        Me.grpNaves.Controls.Add(Me.btnCliente)
        Me.grpNaves.Location = New System.Drawing.Point(12, 5)
        Me.grpNaves.Name = "grpNaves"
        Me.grpNaves.Size = New System.Drawing.Size(209, 125)
        Me.grpNaves.TabIndex = 116
        Me.grpNaves.TabStop = False
        Me.grpNaves.Text = "Cliente"
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(153, 11)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 5
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdCliente)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 39)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(203, 83)
        Me.Panel7.TabIndex = 2
        '
        'grdCliente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Appearance = Appearance1
        Me.grdCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.Size = New System.Drawing.Size(203, 83)
        Me.grdCliente.TabIndex = 6
        '
        'btnCliente
        '
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(181, 11)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnCliente.TabIndex = 0
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblRegistrosTitulo)
        Me.pnlPie.Controls.Add(Me.lblRegistros)
        Me.pnlPie.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 420)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(601, 58)
        Me.pnlPie.TabIndex = 181
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(12, 8)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 185
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(7, 29)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 186
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(304, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 183
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(312, 13)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 182
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(465, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(68, 58)
        Me.Panel2.TabIndex = 181
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(20, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 18
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(15, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Guardar"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(533, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(68, 58)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(20, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 18
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(19, 35)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 17
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdConfCliente
        '
        Me.grdConfCliente.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdConfCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConfCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode2.RelationName = "Level1"
        Me.grdConfCliente.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdConfCliente.Location = New System.Drawing.Point(0, 222)
        Me.grdConfCliente.MainView = Me.vwConfCliente
        Me.grdConfCliente.Name = "grdConfCliente"
        Me.grdConfCliente.Size = New System.Drawing.Size(601, 198)
        Me.grdConfCliente.TabIndex = 182
        Me.grdConfCliente.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwConfCliente, Me.GridView3})
        '
        'vwConfCliente
        '
        Me.vwConfCliente.GridControl = Me.grdConfCliente
        Me.vwConfCliente.IndicatorWidth = 30
        Me.vwConfCliente.Name = "vwConfCliente"
        Me.vwConfCliente.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwConfCliente.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwConfCliente.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwConfCliente.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwConfCliente.OptionsPrint.AllowMultilineHeaders = True
        Me.vwConfCliente.OptionsSelection.MultiSelect = True
        Me.vwConfCliente.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.vwConfCliente.OptionsView.ColumnAutoWidth = False
        Me.vwConfCliente.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwConfCliente.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwConfCliente.OptionsView.ShowAutoFilterRow = True
        Me.vwConfCliente.OptionsView.ShowFooter = True
        Me.vwConfCliente.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdConfCliente
        Me.GridView3.Name = "GridView3"
        '
        'Programacion_BalanceoNaves_ConfiguracionClientes_Concentrado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 478)
        Me.Controls.Add(Me.grdConfCliente)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.pnlTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Programacion_BalanceoNaves_ConfiguracionClientes_Concentrado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de Clientes -Concentrado"
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.grpNaves.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdConfCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwConfCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pctTitulo As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents grpNaves As GroupBox
    Friend WithEvents btnLimpiarFiltroCliente As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grdCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnCliente As Button
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdConfCliente As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwConfCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
End Class
