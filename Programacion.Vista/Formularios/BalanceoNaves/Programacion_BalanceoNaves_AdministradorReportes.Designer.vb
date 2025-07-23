<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programacion_BalanceoNaves_AdministradorReportes
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlEnviarCorreo = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.nudSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.grdDesgloseProyeccion = New DevExpress.XtraGrid.GridControl()
        Me.vwDesgloseProyeccion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.grdNecesidadSemanal = New DevExpress.XtraGrid.GridControl()
        Me.vwNecesidadSemanal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.grdDistribucionEquivalencias = New DevExpress.XtraGrid.GridControl()
        Me.vwDistribucionEquivalencias = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.XtraTabPage4 = New DevExpress.XtraTab.XtraTabPage()
        Me.grdConversionEquivalencias = New DevExpress.XtraGrid.GridControl()
        Me.vwConversionEquivalencias = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEnviarCorreo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.grdDesgloseProyeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwDesgloseProyeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.grdNecesidadSemanal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwNecesidadSemanal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.grdDistribucionEquivalencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwDistribucionEquivalencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage4.SuspendLayout()
        CType(Me.grdConversionEquivalencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwConversionEquivalencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.pnlEnviarCorreo)
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1110, 59)
        Me.pnlTitulo.TabIndex = 172
        '
        'pnlEnviarCorreo
        '
        Me.pnlEnviarCorreo.Controls.Add(Me.btnExportar)
        Me.pnlEnviarCorreo.Controls.Add(Me.Label3)
        Me.pnlEnviarCorreo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEnviarCorreo.Location = New System.Drawing.Point(0, 0)
        Me.pnlEnviarCorreo.Name = "pnlEnviarCorreo"
        Me.pnlEnviarCorreo.Size = New System.Drawing.Size(87, 59)
        Me.pnlEnviarCorreo.TabIndex = 170
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(29, 4)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 115
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(22, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Exportar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pbYuyin)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(667, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 59)
        Me.Panel1.TabIndex = 165
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(130, 15)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(217, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Reportes Balanceo Naves"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 454)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1110, 57)
        Me.pnlPie.TabIndex = 175
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(790, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(320, 57)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(213, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 58
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(218, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 14
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(8, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 160
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(16, 13)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 159
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(275, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 16
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(274, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.pnlBotonesExpander)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 59)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1110, 27)
        Me.Panel6.TabIndex = 176
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(1046, 0)
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
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 86)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1110, 102)
        Me.pnlFiltros.TabIndex = 177
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.cmbGrupo)
        Me.GroupBox1.Controls.Add(Me.lblGrupo)
        Me.GroupBox1.Controls.Add(Me.nudAño)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.nudSemanaInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(530, 77)
        Me.GroupBox1.TabIndex = 96
        Me.GroupBox1.TabStop = False
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(65, 48)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(184, 21)
        Me.cmbNave.TabIndex = 86
        '
        'cmbGrupo
        '
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Items.AddRange(New Object() {"TODAS", "RVO", "FVO"})
        Me.cmbGrupo.Location = New System.Drawing.Point(65, 19)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(184, 21)
        Me.cmbGrupo.TabIndex = 87
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(7, 22)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(42, 13)
        Me.lblGrupo.TabIndex = 89
        Me.lblGrupo.Text = "Grupo :"
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(449, 19)
        Me.nudAño.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(61, 20)
        Me.nudAño.TabIndex = 93
        Me.nudAño.Value = New Decimal(New Integer() {2021, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(318, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Semana :"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(10, 52)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(39, 13)
        Me.lblNave.TabIndex = 88
        Me.lblNave.Text = "Nave :"
        '
        'nudSemanaInicio
        '
        Me.nudSemanaInicio.Location = New System.Drawing.Point(385, 19)
        Me.nudSemanaInicio.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.nudSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaInicio.Name = "nudSemanaInicio"
        Me.nudSemanaInicio.Size = New System.Drawing.Size(50, 20)
        Me.nudSemanaInicio.TabIndex = 95
        Me.nudSemanaInicio.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 188)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage2
        Me.XtraTabControl1.Size = New System.Drawing.Size(1110, 266)
        Me.XtraTabControl1.TabIndex = 179
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3, Me.XtraTabPage4})
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.grdDesgloseProyeccion)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1104, 238)
        Me.XtraTabPage2.Text = "Desglose de Proyección"
        '
        'grdDesgloseProyeccion
        '
        Me.grdDesgloseProyeccion.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdDesgloseProyeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDesgloseProyeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.grdDesgloseProyeccion.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdDesgloseProyeccion.Location = New System.Drawing.Point(0, 0)
        Me.grdDesgloseProyeccion.MainView = Me.vwDesgloseProyeccion
        Me.grdDesgloseProyeccion.Name = "grdDesgloseProyeccion"
        Me.grdDesgloseProyeccion.Size = New System.Drawing.Size(1104, 238)
        Me.grdDesgloseProyeccion.TabIndex = 178
        Me.grdDesgloseProyeccion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwDesgloseProyeccion, Me.GridView2})
        '
        'vwDesgloseProyeccion
        '
        Me.vwDesgloseProyeccion.GridControl = Me.grdDesgloseProyeccion
        Me.vwDesgloseProyeccion.IndicatorWidth = 30
        Me.vwDesgloseProyeccion.Name = "vwDesgloseProyeccion"
        Me.vwDesgloseProyeccion.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwDesgloseProyeccion.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwDesgloseProyeccion.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwDesgloseProyeccion.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwDesgloseProyeccion.OptionsPrint.AllowMultilineHeaders = True
        Me.vwDesgloseProyeccion.OptionsSelection.MultiSelect = True
        Me.vwDesgloseProyeccion.OptionsView.ColumnAutoWidth = False
        Me.vwDesgloseProyeccion.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwDesgloseProyeccion.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwDesgloseProyeccion.OptionsView.ShowAutoFilterRow = True
        Me.vwDesgloseProyeccion.OptionsView.ShowFooter = True
        Me.vwDesgloseProyeccion.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdDesgloseProyeccion
        Me.GridView2.Name = "GridView2"
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.grdNecesidadSemanal)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1104, 238)
        Me.XtraTabPage1.Text = "Necesidad Semanal"
        '
        'grdNecesidadSemanal
        '
        Me.grdNecesidadSemanal.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdNecesidadSemanal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNecesidadSemanal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode2.RelationName = "Level1"
        Me.grdNecesidadSemanal.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdNecesidadSemanal.Location = New System.Drawing.Point(0, 0)
        Me.grdNecesidadSemanal.MainView = Me.vwNecesidadSemanal
        Me.grdNecesidadSemanal.Name = "grdNecesidadSemanal"
        Me.grdNecesidadSemanal.Size = New System.Drawing.Size(1104, 238)
        Me.grdNecesidadSemanal.TabIndex = 177
        Me.grdNecesidadSemanal.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwNecesidadSemanal, Me.GridView3})
        '
        'vwNecesidadSemanal
        '
        Me.vwNecesidadSemanal.GridControl = Me.grdNecesidadSemanal
        Me.vwNecesidadSemanal.IndicatorWidth = 30
        Me.vwNecesidadSemanal.Name = "vwNecesidadSemanal"
        Me.vwNecesidadSemanal.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwNecesidadSemanal.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwNecesidadSemanal.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwNecesidadSemanal.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwNecesidadSemanal.OptionsPrint.AllowMultilineHeaders = True
        Me.vwNecesidadSemanal.OptionsSelection.MultiSelect = True
        Me.vwNecesidadSemanal.OptionsView.ColumnAutoWidth = False
        Me.vwNecesidadSemanal.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwNecesidadSemanal.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwNecesidadSemanal.OptionsView.ShowAutoFilterRow = True
        Me.vwNecesidadSemanal.OptionsView.ShowFooter = True
        Me.vwNecesidadSemanal.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdNecesidadSemanal
        Me.GridView3.Name = "GridView3"
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.grdDistribucionEquivalencias)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(1104, 238)
        Me.XtraTabPage3.Text = "Distribución Equivalencias"
        '
        'grdDistribucionEquivalencias
        '
        Me.grdDistribucionEquivalencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDistribucionEquivalencias.Location = New System.Drawing.Point(0, 0)
        Me.grdDistribucionEquivalencias.MainView = Me.vwDistribucionEquivalencias
        Me.grdDistribucionEquivalencias.Name = "grdDistribucionEquivalencias"
        Me.grdDistribucionEquivalencias.Size = New System.Drawing.Size(1104, 238)
        Me.grdDistribucionEquivalencias.TabIndex = 75
        Me.grdDistribucionEquivalencias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwDistribucionEquivalencias})
        '
        'vwDistribucionEquivalencias
        '
        Me.vwDistribucionEquivalencias.ActiveFilterEnabled = False
        Me.vwDistribucionEquivalencias.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.vwDistribucionEquivalencias.GridControl = Me.grdDistribucionEquivalencias
        Me.vwDistribucionEquivalencias.Name = "vwDistribucionEquivalencias"
        Me.vwDistribucionEquivalencias.OptionsCustomization.AllowBandMoving = False
        Me.vwDistribucionEquivalencias.OptionsCustomization.AllowColumnMoving = False
        Me.vwDistribucionEquivalencias.OptionsCustomization.AllowFilter = False
        Me.vwDistribucionEquivalencias.OptionsCustomization.AllowGroup = False
        Me.vwDistribucionEquivalencias.OptionsCustomization.AllowSort = False
        Me.vwDistribucionEquivalencias.OptionsFilter.AllowFilterEditor = False
        Me.vwDistribucionEquivalencias.OptionsMenu.EnableColumnMenu = False
        Me.vwDistribucionEquivalencias.OptionsView.ColumnAutoWidth = False
        Me.vwDistribucionEquivalencias.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwDistribucionEquivalencias.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwDistribucionEquivalencias.OptionsView.ShowDetailButtons = False
        Me.vwDistribucionEquivalencias.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwDistribucionEquivalencias.OptionsView.ShowFooter = True
        Me.vwDistribucionEquivalencias.OptionsView.ShowGroupPanel = False
        '
        'XtraTabPage4
        '
        Me.XtraTabPage4.Controls.Add(Me.grdConversionEquivalencias)
        Me.XtraTabPage4.Name = "XtraTabPage4"
        Me.XtraTabPage4.Size = New System.Drawing.Size(1104, 238)
        Me.XtraTabPage4.Text = "Conversión de Equivalencias"
        '
        'grdConversionEquivalencias
        '
        Me.grdConversionEquivalencias.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdConversionEquivalencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConversionEquivalencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode3.RelationName = "Level1"
        Me.grdConversionEquivalencias.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode3})
        Me.grdConversionEquivalencias.Location = New System.Drawing.Point(0, 0)
        Me.grdConversionEquivalencias.MainView = Me.vwConversionEquivalencias
        Me.grdConversionEquivalencias.Name = "grdConversionEquivalencias"
        Me.grdConversionEquivalencias.Size = New System.Drawing.Size(1104, 238)
        Me.grdConversionEquivalencias.TabIndex = 177
        Me.grdConversionEquivalencias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwConversionEquivalencias, Me.GridView1})
        '
        'vwConversionEquivalencias
        '
        Me.vwConversionEquivalencias.GridControl = Me.grdConversionEquivalencias
        Me.vwConversionEquivalencias.IndicatorWidth = 30
        Me.vwConversionEquivalencias.Name = "vwConversionEquivalencias"
        Me.vwConversionEquivalencias.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwConversionEquivalencias.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwConversionEquivalencias.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwConversionEquivalencias.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwConversionEquivalencias.OptionsPrint.AllowMultilineHeaders = True
        Me.vwConversionEquivalencias.OptionsSelection.MultiSelect = True
        Me.vwConversionEquivalencias.OptionsView.ColumnAutoWidth = False
        Me.vwConversionEquivalencias.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwConversionEquivalencias.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwConversionEquivalencias.OptionsView.ShowAutoFilterRow = True
        Me.vwConversionEquivalencias.OptionsView.ShowFooter = True
        Me.vwConversionEquivalencias.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdConversionEquivalencias
        Me.GridView1.Name = "GridView1"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(360, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 91
        Me.pbYuyin.TabStop = False
        '
        'Programacion_BalanceoNaves_AdministradorReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 511)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "Programacion_BalanceoNaves_AdministradorReportes"
        Me.Text = "Reportes Balanceo Semanal"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlEnviarCorreo.ResumeLayout(False)
        Me.pnlEnviarCorreo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.grdDesgloseProyeccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwDesgloseProyeccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.grdNecesidadSemanal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwNecesidadSemanal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.grdDistribucionEquivalencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwDistribucionEquivalencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage4.ResumeLayout(False)
        CType(Me.grdConversionEquivalencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwConversionEquivalencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlEnviarCorreo As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents lblNave As Label
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents nudAño As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents nudSemanaInicio As NumericUpDown
    Friend WithEvents lblGrupo As Label
    Friend WithEvents cmbGrupo As ComboBox
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents XtraTabPage4 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grdNecesidadSemanal As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwNecesidadSemanal As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDesgloseProyeccion As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwDesgloseProyeccion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDistribucionEquivalencias As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwDistribucionEquivalencias As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents grdConversionEquivalencias As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwConversionEquivalencias As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pbYuyin As PictureBox
End Class
