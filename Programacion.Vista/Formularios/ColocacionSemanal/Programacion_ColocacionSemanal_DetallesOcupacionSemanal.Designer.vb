<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Programacion_ColocacionSemanal_DetallesOcupacionSemanal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Programacion_ColocacionSemanal_DetallesOcupacionSemanal))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnDesprogramar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnReenviar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnMover = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblTextoExportar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.chkNave = New System.Windows.Forms.CheckBox()
        Me.chkSemana = New System.Windows.Forms.CheckBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpSemana = New System.Windows.Forms.GroupBox()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.grpNave = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdReporte = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblNumSemanas = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblNoMover = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel14.SuspendLayout()
        Me.pnlVentas.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.grpSemana.SuspendLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNave.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.pnlVentas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(682, 65)
        Me.Panel14.TabIndex = 3
        '
        'pnlVentas
        '
        Me.pnlVentas.Controls.Add(Me.Panel7)
        Me.pnlVentas.Controls.Add(Me.Panel6)
        Me.pnlVentas.Controls.Add(Me.Panel4)
        Me.pnlVentas.Controls.Add(Me.pnlExportar)
        Me.pnlVentas.Location = New System.Drawing.Point(3, 3)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(666, 62)
        Me.pnlVentas.TabIndex = 108
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnDesprogramar)
        Me.Panel7.Controls.Add(Me.Label12)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(191, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(76, 62)
        Me.Panel7.TabIndex = 122
        '
        'btnDesprogramar
        '
        Me.btnDesprogramar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnDesprogramar.Image = Global.Programacion.Vista.My.Resources.Resources.reasignar
        Me.btnDesprogramar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDesprogramar.Location = New System.Drawing.Point(21, 3)
        Me.btnDesprogramar.Name = "btnDesprogramar"
        Me.btnDesprogramar.Size = New System.Drawing.Size(32, 32)
        Me.btnDesprogramar.TabIndex = 113
        Me.btnDesprogramar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label12.Location = New System.Drawing.Point(2, 38)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 112
        Me.Label12.Text = "Desprogramar"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnReenviar)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(126, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(65, 62)
        Me.Panel6.TabIndex = 121
        Me.Panel6.Visible = False
        '
        'btnReenviar
        '
        Me.btnReenviar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnReenviar.Image = Global.Programacion.Vista.My.Resources.Resources.Enviar
        Me.btnReenviar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReenviar.Location = New System.Drawing.Point(17, 3)
        Me.btnReenviar.Name = "btnReenviar"
        Me.btnReenviar.Size = New System.Drawing.Size(32, 32)
        Me.btnReenviar.TabIndex = 113
        Me.btnReenviar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label10.Location = New System.Drawing.Point(10, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 26)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = "Volver a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Enviar"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnMover)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(61, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(65, 62)
        Me.Panel4.TabIndex = 120
        '
        'btnMover
        '
        Me.btnMover.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMover.Image = CType(resources.GetObject("btnMover.Image"), System.Drawing.Image)
        Me.btnMover.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMover.Location = New System.Drawing.Point(17, 3)
        Me.btnMover.Name = "btnMover"
        Me.btnMover.Size = New System.Drawing.Size(32, 32)
        Me.btnMover.TabIndex = 113
        Me.btnMover.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(15, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = "Mover"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportarExcel)
        Me.pnlExportar.Controls.Add(Me.lblTextoExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(61, 62)
        Me.pnlExportar.TabIndex = 119
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(15, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 113
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblTextoExportar
        '
        Me.lblTextoExportar.AutoSize = True
        Me.lblTextoExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoExportar.Location = New System.Drawing.Point(10, 35)
        Me.lblTextoExportar.Name = "lblTextoExportar"
        Me.lblTextoExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblTextoExportar.TabIndex = 112
        Me.lblTextoExportar.Text = "Exportar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1145, 65)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(714, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(572, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(573, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(296, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(190, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Detalles de Ocupación"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(490, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'GridView5
        '
        Me.GridView5.Name = "GridView5"
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.chkNave)
        Me.pnlParametros.Controls.Add(Me.chkSemana)
        Me.pnlParametros.Controls.Add(Me.Panel5)
        Me.pnlParametros.Controls.Add(Me.grpSemana)
        Me.pnlParametros.Controls.Add(Me.chkSeleccionar)
        Me.pnlParametros.Controls.Add(Me.grpNave)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1145, 25)
        Me.pnlParametros.TabIndex = 25
        '
        'chkNave
        '
        Me.chkNave.AutoSize = True
        Me.chkNave.Location = New System.Drawing.Point(387, 25)
        Me.chkNave.Name = "chkNave"
        Me.chkNave.Size = New System.Drawing.Size(52, 17)
        Me.chkNave.TabIndex = 66
        Me.chkNave.Text = "Nave"
        Me.chkNave.UseVisualStyleBackColor = True
        '
        'chkSemana
        '
        Me.chkSemana.AutoSize = True
        Me.chkSemana.Location = New System.Drawing.Point(18, 25)
        Me.chkSemana.Name = "chkSemana"
        Me.chkSemana.Size = New System.Drawing.Size(65, 17)
        Me.chkSemana.TabIndex = 63
        Me.chkSemana.Text = "Semana"
        Me.chkSemana.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnAsignar)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(1082, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(63, 8)
        Me.Panel5.TabIndex = 63
        '
        'btnAsignar
        '
        Me.btnAsignar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAsignar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAsignar.Location = New System.Drawing.Point(12, 45)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(32, 32)
        Me.btnAsignar.TabIndex = 1
        Me.btnAsignar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(7, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Asignar"
        '
        'grpSemana
        '
        Me.grpSemana.Controls.Add(Me.nudAño)
        Me.grpSemana.Controls.Add(Me.Label2)
        Me.grpSemana.Controls.Add(Me.Label3)
        Me.grpSemana.Controls.Add(Me.nudSemanaInicio)
        Me.grpSemana.Enabled = False
        Me.grpSemana.Location = New System.Drawing.Point(18, 36)
        Me.grpSemana.Name = "grpSemana"
        Me.grpSemana.Size = New System.Drawing.Size(337, 62)
        Me.grpSemana.TabIndex = 62
        Me.grpSemana.TabStop = False
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(64, 25)
        Me.nudAño.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2018, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(61, 20)
        Me.nudAño.TabIndex = 67
        Me.nudAño.Value = New Decimal(New Integer() {2018, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Año:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(204, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Semana de:"
        '
        'nudSemanaInicio
        '
        Me.nudSemanaInicio.Location = New System.Drawing.Point(274, 25)
        Me.nudSemanaInicio.Maximum = New Decimal(New Integer() {2018, 0, 0, 0})
        Me.nudSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaInicio.Name = "nudSemanaInicio"
        Me.nudSemanaInicio.Size = New System.Drawing.Size(50, 20)
        Me.nudSemanaInicio.TabIndex = 69
        Me.nudSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.chkSeleccionar.Location = New System.Drawing.Point(0, 8)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(1145, 17)
        Me.chkSeleccionar.TabIndex = 60
        Me.chkSeleccionar.Text = "Seleccionar Todo"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '
        'grpNave
        '
        Me.grpNave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNave.Controls.Add(Me.Label5)
        Me.grpNave.Controls.Add(Me.cmbNave)
        Me.grpNave.Enabled = False
        Me.grpNave.Location = New System.Drawing.Point(387, 36)
        Me.grpNave.Name = "grpNave"
        Me.grpNave.Size = New System.Drawing.Size(673, 62)
        Me.grpNave.TabIndex = 59
        Me.grpNave.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Nave:"
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Items.AddRange(New Object() {"TODAS", "FVO", "RVO"})
        Me.cmbNave.Location = New System.Drawing.Point(74, 25)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(334, 21)
        Me.cmbNave.TabIndex = 64
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdReporte)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1145, 390)
        Me.Panel2.TabIndex = 1
        '
        'grdReporte
        '
        Me.grdReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.grdReporte.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdReporte.Location = New System.Drawing.Point(0, 0)
        Me.grdReporte.MainView = Me.vwReporte
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(1145, 390)
        Me.grdReporte.TabIndex = 78
        Me.grdReporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte, Me.GridView3})
        '
        'vwReporte
        '
        Me.vwReporte.GridControl = Me.grdReporte
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwReporte.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwReporte.OptionsPrint.AllowMultilineHeaders = True
        Me.vwReporte.OptionsSelection.MultiSelect = True
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwReporte.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwReporte.OptionsView.ShowFooter = True
        Me.vwReporte.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdReporte
        Me.GridView3.Name = "GridView3"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 90)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1145, 390)
        Me.Panel3.TabIndex = 27
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1145, 548)
        Me.Panel1.TabIndex = 4
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label11)
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.lblNumSemanas)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label8)
        Me.pnlPie.Controls.Add(Me.Label7)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPie.Location = New System.Drawing.Point(0, 480)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1145, 68)
        Me.pnlPie.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(147, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 18)
        Me.Label11.TabIndex = 123
        Me.Label11.Text = "Seleccionadas"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 18)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Seleccionados"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumSemanas
        '
        Me.lblNumSemanas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumSemanas.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumSemanas.Location = New System.Drawing.Point(165, 40)
        Me.lblNumSemanas.Name = "lblNumSemanas"
        Me.lblNumSemanas.Size = New System.Drawing.Size(86, 24)
        Me.lblNumSemanas.TabIndex = 122
        Me.lblNumSemanas.Text = "0"
        Me.lblNumSemanas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(21, 40)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 122
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(123, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(170, 24)
        Me.Label8.TabIndex = 121
        Me.Label8.Text = "Semanas Diferentes"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(21, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 24)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "Pares"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblNoMover)
        Me.pnlDatosBotones.Controls.Add(Me.Label1)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(887, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(258, 68)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(175, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Enabled = False
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(169, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(214, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(213, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblNoMover
        '
        Me.lblNoMover.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoMover.AutoSize = True
        Me.lblNoMover.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoMover.ForeColor = System.Drawing.Color.Crimson
        Me.lblNoMover.Location = New System.Drawing.Point(3, 39)
        Me.lblNoMover.Name = "lblNoMover"
        Me.lblNoMover.Size = New System.Drawing.Size(161, 13)
        Me.lblNoMover.TabIndex = 3
        Me.lblNoMover.Text = "Editados (Semana Cerrada)"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkViolet
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Datos Editados"
        '
        'Programacion_ColocacionSemanal_DetallesOcupacionSemanal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 548)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Programacion_ColocacionSemanal_DetallesOcupacionSemanal"
        Me.Text = "Detalles de Ocupación"
        Me.Panel14.ResumeLayout(False)
        Me.pnlVentas.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.grpSemana.ResumeLayout(False)
        Me.grpSemana.PerformLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNave.ResumeLayout(False)
        Me.grpNave.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel14 As Panel
    Friend WithEvents pnlVentas As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnMover As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblTextoExportar As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents grpNave As GroupBox
    Friend WithEvents btnAsignar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents nudSemanaInicio As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents nudAño As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkSeleccionar As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblNumSemanas As Label
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents grdReporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grpSemana As GroupBox
    Friend WithEvents chkSemana As CheckBox
    Friend WithEvents chkNave As CheckBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblNoMover As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnDesprogramar As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnReenviar As Button
    Friend WithEvents Label10 As Label
End Class
