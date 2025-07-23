<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultaAvancesProdccionForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaAvancesProdccionForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.rdoProcesos = New System.Windows.Forms.RadioButton()
        Me.rdoTerminados = New System.Windows.Forms.RadioButton()
        Me.rdoAtrasados = New System.Windows.Forms.RadioButton()
        Me.rdoTodos = New System.Windows.Forms.RadioButton()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cmbCelulas = New System.Windows.Forms.ComboBox()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdInventarioDepartamento = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid4 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdResumenesDepartamentos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid6 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid5 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.grdResumenesNave = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid3 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grdAvances = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdAvancesDetallado = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.chkMotivoAtraso = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnResumenAtrasos = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.menuImprimir = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ReporteAvancesPorProgramaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteAvancesPorProgramaDetalladoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.hilo = New System.ComponentModel.BackgroundWorker()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlRegistrarAtraso = New System.Windows.Forms.Panel()
        Me.btnRegistrarAtraso = New System.Windows.Forms.Button()
        Me.lblRegistrarAtraso = New System.Windows.Forms.Label()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdInventarioDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdResumenesDepartamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel20.SuspendLayout()
        CType(Me.grdResumenesNave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAvances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdAvancesDetallado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.menuImprimir.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlRegistrarAtraso.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlRegistrarAtraso)
        Me.pnlListaPaises.Controls.Add(Me.pnlExportar)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1145, 66)
        Me.pnlListaPaises.TabIndex = 28
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(599, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(546, 66)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(57, 23)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(410, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Consulta de Avances de Producción por Programa"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(477, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(69, 66)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(63, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Mostrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(66, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'rdoProcesos
        '
        Me.rdoProcesos.AutoSize = True
        Me.rdoProcesos.Location = New System.Drawing.Point(696, 49)
        Me.rdoProcesos.Name = "rdoProcesos"
        Me.rdoProcesos.Size = New System.Drawing.Size(93, 17)
        Me.rdoProcesos.TabIndex = 3
        Me.rdoProcesos.Text = "Lotes Proceso"
        Me.rdoProcesos.UseVisualStyleBackColor = True
        '
        'rdoTerminados
        '
        Me.rdoTerminados.AutoSize = True
        Me.rdoTerminados.Location = New System.Drawing.Point(696, 79)
        Me.rdoTerminados.Name = "rdoTerminados"
        Me.rdoTerminados.Size = New System.Drawing.Size(109, 17)
        Me.rdoTerminados.TabIndex = 2
        Me.rdoTerminados.Text = "Lotes Terminados"
        Me.rdoTerminados.UseVisualStyleBackColor = True
        '
        'rdoAtrasados
        '
        Me.rdoAtrasados.AutoSize = True
        Me.rdoAtrasados.Location = New System.Drawing.Point(593, 79)
        Me.rdoAtrasados.Name = "rdoAtrasados"
        Me.rdoAtrasados.Size = New System.Drawing.Size(101, 17)
        Me.rdoAtrasados.TabIndex = 1
        Me.rdoAtrasados.Text = "Lotes Atrasados"
        Me.rdoAtrasados.UseVisualStyleBackColor = True
        '
        'rdoTodos
        '
        Me.rdoTodos.AutoSize = True
        Me.rdoTodos.Checked = True
        Me.rdoTodos.Location = New System.Drawing.Point(593, 48)
        Me.rdoTodos.Name = "rdoTodos"
        Me.rdoTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoTodos.TabIndex = 0
        Me.rdoTodos.TabStop = True
        Me.rdoTodos.Text = "Todos"
        Me.rdoTodos.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(447, 74)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(118, 20)
        Me.dtpFechaFinal.TabIndex = 4
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(447, 47)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(118, 20)
        Me.dtpFechaInicio.TabIndex = 3
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(425, 78)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(14, 13)
        Me.lblA.TabIndex = 2
        Me.lblA.Text = "A"
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(425, 50)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(21, 13)
        Me.lblDe.TabIndex = 1
        Me.lblDe.Text = "De"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(236, 50)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(36, 13)
        Me.lblCelula.TabIndex = 5
        Me.lblCelula.Text = "Célula"
        '
        'cmbCelulas
        '
        Me.cmbCelulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCelulas.FormattingEnabled = True
        Me.cmbCelulas.Location = New System.Drawing.Point(278, 47)
        Me.cmbCelulas.Name = "cmbCelulas"
        Me.cmbCelulas.Size = New System.Drawing.Size(121, 21)
        Me.cmbCelulas.TabIndex = 4
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(97, 77)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(121, 21)
        Me.cmbDepartamento.TabIndex = 3
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(97, 47)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(121, 21)
        Me.cmbNave.TabIndex = 2
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(17, 80)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.lblDepartamento.TabIndex = 1
        Me.lblDepartamento.Text = "Departamento"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(17, 47)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Nave"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel3)
        Me.Panel7.Controls.Add(Me.Panel1)
        Me.Panel7.Controls.Add(Me.Panel20)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 501)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1145, 150)
        Me.Panel7.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdInventarioDepartamento)
        Me.Panel3.Controls.Add(Me.C1FlexGrid4)
        Me.Panel3.Controls.Add(Me.C1FlexGrid2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(712, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(433, 150)
        Me.Panel3.TabIndex = 22
        '
        'grdInventarioDepartamento
        '
        Me.grdInventarioDepartamento.ColumnInfo = resources.GetString("grdInventarioDepartamento.ColumnInfo")
        Me.grdInventarioDepartamento.Location = New System.Drawing.Point(12, 42)
        Me.grdInventarioDepartamento.Name = "grdInventarioDepartamento"
        Me.grdInventarioDepartamento.Rows.Count = 1
        Me.grdInventarioDepartamento.Rows.DefaultSize = 19
        Me.grdInventarioDepartamento.Size = New System.Drawing.Size(442, 105)
        Me.grdInventarioDepartamento.StyleInfo = resources.GetString("grdInventarioDepartamento.StyleInfo")
        Me.grdInventarioDepartamento.TabIndex = 24
        '
        'C1FlexGrid4
        '
        Me.C1FlexGrid4.ColumnInfo = resources.GetString("C1FlexGrid4.ColumnInfo")
        Me.C1FlexGrid4.Location = New System.Drawing.Point(12, 21)
        Me.C1FlexGrid4.Name = "C1FlexGrid4"
        Me.C1FlexGrid4.Rows.Count = 1
        Me.C1FlexGrid4.Rows.DefaultSize = 19
        Me.C1FlexGrid4.Size = New System.Drawing.Size(442, 36)
        Me.C1FlexGrid4.StyleInfo = resources.GetString("C1FlexGrid4.StyleInfo")
        Me.C1FlexGrid4.TabIndex = 23
        '
        'C1FlexGrid2
        '
        Me.C1FlexGrid2.ColumnInfo = "2,1,0,0,0,95,Columns:0{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:437;Name:""Departamento"";Caption:""R" &
    "esumen por Departamento"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:C" &
    "enterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid2.Location = New System.Drawing.Point(12, 3)
        Me.C1FlexGrid2.Name = "C1FlexGrid2"
        Me.C1FlexGrid2.Rows.Count = 1
        Me.C1FlexGrid2.Rows.DefaultSize = 19
        Me.C1FlexGrid2.Size = New System.Drawing.Size(442, 24)
        Me.C1FlexGrid2.StyleInfo = resources.GetString("C1FlexGrid2.StyleInfo")
        Me.C1FlexGrid2.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdResumenesDepartamentos)
        Me.Panel1.Controls.Add(Me.C1FlexGrid6)
        Me.Panel1.Controls.Add(Me.C1FlexGrid5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(240, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 150)
        Me.Panel1.TabIndex = 17
        '
        'grdResumenesDepartamentos
        '
        Me.grdResumenesDepartamentos.ColumnInfo = resources.GetString("grdResumenesDepartamentos.ColumnInfo")
        Me.grdResumenesDepartamentos.Location = New System.Drawing.Point(0, 42)
        Me.grdResumenesDepartamentos.Name = "grdResumenesDepartamentos"
        Me.grdResumenesDepartamentos.Rows.Count = 1
        Me.grdResumenesDepartamentos.Rows.DefaultSize = 19
        Me.grdResumenesDepartamentos.Size = New System.Drawing.Size(457, 105)
        Me.grdResumenesDepartamentos.StyleInfo = resources.GetString("grdResumenesDepartamentos.StyleInfo")
        Me.grdResumenesDepartamentos.TabIndex = 21
        '
        'C1FlexGrid6
        '
        Me.C1FlexGrid6.ColumnInfo = resources.GetString("C1FlexGrid6.ColumnInfo")
        Me.C1FlexGrid6.Location = New System.Drawing.Point(0, 22)
        Me.C1FlexGrid6.Name = "C1FlexGrid6"
        Me.C1FlexGrid6.Rows.Count = 1
        Me.C1FlexGrid6.Rows.DefaultSize = 19
        Me.C1FlexGrid6.Size = New System.Drawing.Size(457, 35)
        Me.C1FlexGrid6.StyleInfo = resources.GetString("C1FlexGrid6.StyleInfo")
        Me.C1FlexGrid6.TabIndex = 23
        '
        'C1FlexGrid5
        '
        Me.C1FlexGrid5.ColumnInfo = "2,1,0,0,0,95,Columns:0{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:451;Name:""Departamento"";Caption:""R" &
    "esumen por Célula"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:CenterC" &
    "enter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid5.Location = New System.Drawing.Point(0, 2)
        Me.C1FlexGrid5.Name = "C1FlexGrid5"
        Me.C1FlexGrid5.Rows.Count = 1
        Me.C1FlexGrid5.Rows.DefaultSize = 19
        Me.C1FlexGrid5.Size = New System.Drawing.Size(457, 34)
        Me.C1FlexGrid5.StyleInfo = resources.GetString("C1FlexGrid5.StyleInfo")
        Me.C1FlexGrid5.TabIndex = 22
        '
        'Panel20
        '
        Me.Panel20.Controls.Add(Me.grdResumenesNave)
        Me.Panel20.Controls.Add(Me.C1FlexGrid3)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel20.Location = New System.Drawing.Point(0, 0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(240, 150)
        Me.Panel20.TabIndex = 15
        '
        'grdResumenesNave
        '
        Me.grdResumenesNave.ColumnInfo = resources.GetString("grdResumenesNave.ColumnInfo")
        Me.grdResumenesNave.Location = New System.Drawing.Point(3, 21)
        Me.grdResumenesNave.Name = "grdResumenesNave"
        Me.grdResumenesNave.Rows.Count = 1
        Me.grdResumenesNave.Rows.DefaultSize = 19
        Me.grdResumenesNave.Size = New System.Drawing.Size(206, 126)
        Me.grdResumenesNave.StyleInfo = resources.GetString("grdResumenesNave.StyleInfo")
        Me.grdResumenesNave.TabIndex = 20
        '
        'C1FlexGrid3
        '
        Me.C1FlexGrid3.ColumnInfo = resources.GetString("C1FlexGrid3.ColumnInfo")
        Me.C1FlexGrid3.Location = New System.Drawing.Point(2, 2)
        Me.C1FlexGrid3.Name = "C1FlexGrid3"
        Me.C1FlexGrid3.Rows.Count = 1
        Me.C1FlexGrid3.Rows.DefaultSize = 19
        Me.C1FlexGrid3.Size = New System.Drawing.Size(207, 56)
        Me.C1FlexGrid3.StyleInfo = resources.GetString("C1FlexGrid3.StyleInfo")
        Me.C1FlexGrid3.TabIndex = 21
        '
        'grdAvances
        '
        Me.grdAvances.ColumnInfo = resources.GetString("grdAvances.ColumnInfo")
        Me.grdAvances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAvances.ExtendLastCol = True
        Me.grdAvances.Location = New System.Drawing.Point(0, 173)
        Me.grdAvances.Name = "grdAvances"
        Me.grdAvances.Rows.Count = 1
        Me.grdAvances.Rows.DefaultSize = 19
        Me.grdAvances.Size = New System.Drawing.Size(1145, 328)
        Me.grdAvances.StyleInfo = resources.GetString("grdAvances.StyleInfo")
        Me.grdAvances.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.chkMotivoAtraso)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.rdoProcesos)
        Me.GroupBox1.Controls.Add(Me.rdoTerminados)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox1.Controls.Add(Me.rdoAtrasados)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.rdoTodos)
        Me.GroupBox1.Controls.Add(Me.lblCelula)
        Me.GroupBox1.Controls.Add(Me.lblA)
        Me.GroupBox1.Controls.Add(Me.lblDe)
        Me.GroupBox1.Controls.Add(Me.cmbCelulas)
        Me.GroupBox1.Controls.Add(Me.cmbDepartamento)
        Me.GroupBox1.Controls.Add(Me.cmbNave)
        Me.GroupBox1.Controls.Add(Me.lblDepartamento)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1145, 107)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdAvancesDetallado)
        Me.Panel5.Location = New System.Drawing.Point(967, 16)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(17, 88)
        Me.Panel5.TabIndex = 41
        Me.Panel5.Visible = False
        '
        'grdAvancesDetallado
        '
        Me.grdAvancesDetallado.ColumnInfo = resources.GetString("grdAvancesDetallado.ColumnInfo")
        Me.grdAvancesDetallado.ExtendLastCol = True
        Me.grdAvancesDetallado.Location = New System.Drawing.Point(3, 5)
        Me.grdAvancesDetallado.Name = "grdAvancesDetallado"
        Me.grdAvancesDetallado.Rows.Count = 1
        Me.grdAvancesDetallado.Rows.DefaultSize = 19
        Me.grdAvancesDetallado.Size = New System.Drawing.Size(1138, 80)
        Me.grdAvancesDetallado.StyleInfo = resources.GetString("grdAvancesDetallado.StyleInfo")
        Me.grdAvancesDetallado.TabIndex = 9
        Me.grdAvancesDetallado.Visible = False
        '
        'chkMotivoAtraso
        '
        Me.chkMotivoAtraso.AutoSize = True
        Me.chkMotivoAtraso.Location = New System.Drawing.Point(825, 80)
        Me.chkMotivoAtraso.Name = "chkMotivoAtraso"
        Me.chkMotivoAtraso.Size = New System.Drawing.Size(110, 17)
        Me.chkMotivoAtraso.TabIndex = 40
        Me.chkMotivoAtraso.Text = "Ver Motivo Atraso"
        Me.chkMotivoAtraso.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnResumenAtrasos)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.lblLimpiar)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(985, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(157, 88)
        Me.Panel2.TabIndex = 39
        '
        'btnResumenAtrasos
        '
        Me.btnResumenAtrasos.Image = Global.Produccion.Vista.My.Resources.Resources.details
        Me.btnResumenAtrasos.Location = New System.Drawing.Point(14, 31)
        Me.btnResumenAtrasos.Name = "btnResumenAtrasos"
        Me.btnResumenAtrasos.Size = New System.Drawing.Size(32, 32)
        Me.btnResumenAtrasos.TabIndex = 37
        Me.btnResumenAtrasos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(5, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 26)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Resumen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Motivos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(103, 8)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(128, 8)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(116, 31)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(113, 62)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 33
        Me.lblLimpiar.Text = "Limpiar"
        '
        'menuImprimir
        '
        Me.menuImprimir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReporteAvancesPorProgramaToolStripMenuItem, Me.ReporteAvancesPorProgramaDetalladoToolStripMenuItem})
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Size = New System.Drawing.Size(292, 48)
        '
        'ReporteAvancesPorProgramaToolStripMenuItem
        '
        Me.ReporteAvancesPorProgramaToolStripMenuItem.Name = "ReporteAvancesPorProgramaToolStripMenuItem"
        Me.ReporteAvancesPorProgramaToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.ReporteAvancesPorProgramaToolStripMenuItem.Text = "Reporte Avances por Programa"
        '
        'ReporteAvancesPorProgramaDetalladoToolStripMenuItem
        '
        Me.ReporteAvancesPorProgramaDetalladoToolStripMenuItem.Name = "ReporteAvancesPorProgramaDetalladoToolStripMenuItem"
        Me.ReporteAvancesPorProgramaDetalladoToolStripMenuItem.Size = New System.Drawing.Size(291, 22)
        Me.ReporteAvancesPorProgramaDetalladoToolStripMenuItem.Text = "Reporte Avances por Programa Detallado"
        '
        'hilo
        '
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(68, 66)
        Me.pnlExportar.TabIndex = 55
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(17, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 174
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblExportar.Location = New System.Drawing.Point(12, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 173
        Me.lblExportar.Text = "Exportar"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlRegistrarAtraso
        '
        Me.pnlRegistrarAtraso.Controls.Add(Me.btnRegistrarAtraso)
        Me.pnlRegistrarAtraso.Controls.Add(Me.lblRegistrarAtraso)
        Me.pnlRegistrarAtraso.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRegistrarAtraso.Location = New System.Drawing.Point(68, 0)
        Me.pnlRegistrarAtraso.Name = "pnlRegistrarAtraso"
        Me.pnlRegistrarAtraso.Size = New System.Drawing.Size(77, 66)
        Me.pnlRegistrarAtraso.TabIndex = 56
        '
        'btnRegistrarAtraso
        '
        Me.btnRegistrarAtraso.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRegistrarAtraso.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnRegistrarAtraso.Image = Global.Produccion.Vista.My.Resources.Resources.ciudades_32
        Me.btnRegistrarAtraso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRegistrarAtraso.Location = New System.Drawing.Point(24, 5)
        Me.btnRegistrarAtraso.Name = "btnRegistrarAtraso"
        Me.btnRegistrarAtraso.Size = New System.Drawing.Size(32, 32)
        Me.btnRegistrarAtraso.TabIndex = 174
        Me.btnRegistrarAtraso.UseVisualStyleBackColor = True
        '
        'lblRegistrarAtraso
        '
        Me.lblRegistrarAtraso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRegistrarAtraso.AutoSize = True
        Me.lblRegistrarAtraso.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRegistrarAtraso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRegistrarAtraso.Location = New System.Drawing.Point(14, 38)
        Me.lblRegistrarAtraso.Name = "lblRegistrarAtraso"
        Me.lblRegistrarAtraso.Size = New System.Drawing.Size(52, 26)
        Me.lblRegistrarAtraso.TabIndex = 173
        Me.lblRegistrarAtraso.Text = "Registrar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Atraso"
        Me.lblRegistrarAtraso.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ConsultaAvancesProdccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1145, 651)
        Me.Controls.Add(Me.grdAvances)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.Panel7)
        Me.Name = "ConsultaAvancesProdccionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Avances de Producción por Programa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdInventarioDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdResumenesDepartamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel20.ResumeLayout(False)
        CType(Me.grdResumenesNave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAvances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdAvancesDetallado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.menuImprimir.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlRegistrarAtraso.ResumeLayout(False)
        Me.pnlRegistrarAtraso.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rdoTerminados As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAtrasados As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTodos As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grdAvances As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents C1FlexGrid2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents rdoProcesos As System.Windows.Forms.RadioButton
    Friend WithEvents cmbCelulas As System.Windows.Forms.ComboBox
    Friend WithEvents C1FlexGrid3 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grdResumenesNave As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents grdInventarioDepartamento As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid4 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdResumenesDepartamentos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid6 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid5 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkMotivoAtraso As System.Windows.Forms.CheckBox
    Friend WithEvents menuImprimir As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReporteAvancesPorProgramaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteAvancesPorProgramaDetalladoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents grdAvancesDetallado As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnResumenAtrasos As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents hilo As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlRegistrarAtraso As Panel
    Friend WithEvents btnRegistrarAtraso As Button
    Friend WithEvents lblRegistrarAtraso As Label
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
End Class
