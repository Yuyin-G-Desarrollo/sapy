<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerificarAvancesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VerificarAvancesForm))
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdResumenesDepartamentos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.head2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlNave = New System.Windows.Forms.Panel()
        Me.lblInventarioNave = New System.Windows.Forms.Label()
        Me.lb_linvNave = New System.Windows.Forms.Label()
        Me.lblinvdepartamento = New System.Windows.Forms.Label()
        Me.pnlDepartamento = New System.Windows.Forms.Panel()
        Me.lblTotalInventario = New System.Windows.Forms.Label()
        Me.head = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grdInventarioNave = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grdInventarioDepartamento = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnExpCod = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlMasFiltros = New System.Windows.Forms.Panel()
        Me.rdoTerminados = New System.Windows.Forms.RadioButton()
        Me.rdoAtrasados = New System.Windows.Forms.RadioButton()
        Me.rdoTodos = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.lblDias = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cmbCelulas = New System.Windows.Forms.ComboBox()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.grdAvances = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdResumenesDepartamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.head2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlNave.SuspendLayout()
        Me.pnlDepartamento.SuspendLayout()
        CType(Me.head, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInventarioNave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInventarioDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMasFiltros.SuspendLayout()
        CType(Me.grdAvances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel1)
        Me.Panel7.Controls.Add(Me.head2)
        Me.Panel7.Controls.Add(Me.Panel3)
        Me.Panel7.Controls.Add(Me.grdInventarioNave)
        Me.Panel7.Controls.Add(Me.grdInventarioDepartamento)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 445)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(857, 147)
        Me.Panel7.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(857, 147)
        Me.Panel1.TabIndex = 15
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdResumenesDepartamentos)
        Me.Panel4.Controls.Add(Me.C1FlexGrid1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(857, 147)
        Me.Panel4.TabIndex = 9
        '
        'grdResumenesDepartamentos
        '
        Me.grdResumenesDepartamentos.ColumnInfo = resources.GetString("grdResumenesDepartamentos.ColumnInfo")
        Me.grdResumenesDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdResumenesDepartamentos.ExtendLastCol = True
        Me.grdResumenesDepartamentos.Location = New System.Drawing.Point(0, 22)
        Me.grdResumenesDepartamentos.Name = "grdResumenesDepartamentos"
        Me.grdResumenesDepartamentos.Rows.Count = 1
        Me.grdResumenesDepartamentos.Rows.DefaultSize = 19
        Me.grdResumenesDepartamentos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdResumenesDepartamentos.Size = New System.Drawing.Size(857, 125)
        Me.grdResumenesDepartamentos.StyleInfo = resources.GetString("grdResumenesDepartamentos.StyleInfo")
        Me.grdResumenesDepartamentos.TabIndex = 12
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = "2,1,0,0,0,95,Columns:0{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:413;Name:""Descripcion"";Caption:""Lo" &
    "tes Terminados por Célula"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign" &
    ":CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1FlexGrid1.ExtendLastCol = True
        Me.C1FlexGrid1.Location = New System.Drawing.Point(0, 0)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.Count = 1
        Me.C1FlexGrid1.Rows.DefaultSize = 19
        Me.C1FlexGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.C1FlexGrid1.Size = New System.Drawing.Size(857, 22)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 7
        '
        'head2
        '
        Me.head2.ColumnInfo = "2,1,0,0,0,95,Columns:0{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:460;Name:""Descripcion"";Caption:""In" &
    "ventarios Nave"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:CenterCent" &
    "er;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.head2.Location = New System.Drawing.Point(794, 8)
        Me.head2.Name = "head2"
        Me.head2.Rows.Count = 1
        Me.head2.Rows.DefaultSize = 19
        Me.head2.Size = New System.Drawing.Size(49, 31)
        Me.head2.TabIndex = 9
        Me.head2.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlNave)
        Me.Panel3.Controls.Add(Me.lb_linvNave)
        Me.Panel3.Controls.Add(Me.lblinvdepartamento)
        Me.Panel3.Controls.Add(Me.pnlDepartamento)
        Me.Panel3.Location = New System.Drawing.Point(802, 45)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(41, 44)
        Me.Panel3.TabIndex = 5
        Me.Panel3.Visible = False
        '
        'pnlNave
        '
        Me.pnlNave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNave.Controls.Add(Me.lblInventarioNave)
        Me.pnlNave.Location = New System.Drawing.Point(25, 92)
        Me.pnlNave.Name = "pnlNave"
        Me.pnlNave.Size = New System.Drawing.Size(114, 35)
        Me.pnlNave.TabIndex = 6
        '
        'lblInventarioNave
        '
        Me.lblInventarioNave.AutoSize = True
        Me.lblInventarioNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventarioNave.Location = New System.Drawing.Point(1, 0)
        Me.lblInventarioNave.Name = "lblInventarioNave"
        Me.lblInventarioNave.Size = New System.Drawing.Size(25, 26)
        Me.lblInventarioNave.TabIndex = 2
        Me.lblInventarioNave.Text = "0"
        '
        'lb_linvNave
        '
        Me.lb_linvNave.AutoSize = True
        Me.lb_linvNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_linvNave.Location = New System.Drawing.Point(36, 69)
        Me.lb_linvNave.Name = "lb_linvNave"
        Me.lb_linvNave.Size = New System.Drawing.Size(91, 15)
        Me.lb_linvNave.TabIndex = 5
        Me.lb_linvNave.Text = "Inventario Nave"
        '
        'lblinvdepartamento
        '
        Me.lblinvdepartamento.AutoSize = True
        Me.lblinvdepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinvdepartamento.Location = New System.Drawing.Point(10, 3)
        Me.lblinvdepartamento.Name = "lblinvdepartamento"
        Me.lblinvdepartamento.Size = New System.Drawing.Size(139, 15)
        Me.lblinvdepartamento.TabIndex = 0
        Me.lblinvdepartamento.Text = "Inventario Deparamento"
        '
        'pnlDepartamento
        '
        Me.pnlDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDepartamento.Controls.Add(Me.lblTotalInventario)
        Me.pnlDepartamento.Controls.Add(Me.head)
        Me.pnlDepartamento.Location = New System.Drawing.Point(25, 21)
        Me.pnlDepartamento.Name = "pnlDepartamento"
        Me.pnlDepartamento.Size = New System.Drawing.Size(114, 35)
        Me.pnlDepartamento.TabIndex = 4
        '
        'lblTotalInventario
        '
        Me.lblTotalInventario.AutoSize = True
        Me.lblTotalInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalInventario.Location = New System.Drawing.Point(1, 0)
        Me.lblTotalInventario.Name = "lblTotalInventario"
        Me.lblTotalInventario.Size = New System.Drawing.Size(25, 26)
        Me.lblTotalInventario.TabIndex = 2
        Me.lblTotalInventario.Text = "0"
        '
        'head
        '
        Me.head.ColumnInfo = "2,1,0,0,0,95,Columns:0{Visible:False;}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:481;Name:""Descripcion"";Caption:""In" &
    "ventarios Departamento"";Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:Ce" &
    "nterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.head.Location = New System.Drawing.Point(-510, 29)
        Me.head.Name = "head"
        Me.head.Rows.Count = 1
        Me.head.Rows.DefaultSize = 19
        Me.head.Size = New System.Drawing.Size(555, 25)
        Me.head.TabIndex = 8
        Me.head.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black
        '
        'grdInventarioNave
        '
        Me.grdInventarioNave.ColumnInfo = resources.GetString("grdInventarioNave.ColumnInfo")
        Me.grdInventarioNave.Location = New System.Drawing.Point(804, 95)
        Me.grdInventarioNave.Name = "grdInventarioNave"
        Me.grdInventarioNave.Rows.Count = 1
        Me.grdInventarioNave.Rows.DefaultSize = 19
        Me.grdInventarioNave.Size = New System.Drawing.Size(39, 44)
        Me.grdInventarioNave.TabIndex = 14
        Me.grdInventarioNave.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black
        '
        'grdInventarioDepartamento
        '
        Me.grdInventarioDepartamento.ColumnInfo = resources.GetString("grdInventarioDepartamento.ColumnInfo")
        Me.grdInventarioDepartamento.Location = New System.Drawing.Point(743, 8)
        Me.grdInventarioDepartamento.Name = "grdInventarioDepartamento"
        Me.grdInventarioDepartamento.Rows.Count = 1
        Me.grdInventarioDepartamento.Rows.DefaultSize = 19
        Me.grdInventarioDepartamento.Size = New System.Drawing.Size(53, 58)
        Me.grdInventarioDepartamento.TabIndex = 13
        Me.grdInventarioDepartamento.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel5.Controls.Add(Me.pnlListaPaises)
        Me.Panel5.Controls.Add(Me.pnlMasFiltros)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(857, 50)
        Me.Panel5.TabIndex = 9
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
        Me.pnlListaPaises.Size = New System.Drawing.Size(857, 50)
        Me.pnlListaPaises.TabIndex = 30
        '
        'btnExpCod
        '
        Me.btnExpCod.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnExpCod.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExpCod.Location = New System.Drawing.Point(12, 3)
        Me.btnExpCod.Name = "btnExpCod"
        Me.btnExpCod.Size = New System.Drawing.Size(32, 32)
        Me.btnExpCod.TabIndex = 35
        Me.btnExpCod.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(6, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Exportar"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(311, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(546, 50)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(25, 14)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(472, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Consulta de Avances de Producción por Fecha de Avance"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(493, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(53, 50)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlMasFiltros
        '
        Me.pnlMasFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMasFiltros.Controls.Add(Me.rdoTerminados)
        Me.pnlMasFiltros.Controls.Add(Me.rdoAtrasados)
        Me.pnlMasFiltros.Controls.Add(Me.rdoTodos)
        Me.pnlMasFiltros.Location = New System.Drawing.Point(925, 97)
        Me.pnlMasFiltros.Name = "pnlMasFiltros"
        Me.pnlMasFiltros.Size = New System.Drawing.Size(149, 62)
        Me.pnlMasFiltros.TabIndex = 7
        Me.pnlMasFiltros.Visible = False
        '
        'rdoTerminados
        '
        Me.rdoTerminados.AutoSize = True
        Me.rdoTerminados.Location = New System.Drawing.Point(214, 11)
        Me.rdoTerminados.Name = "rdoTerminados"
        Me.rdoTerminados.Size = New System.Drawing.Size(109, 17)
        Me.rdoTerminados.TabIndex = 2
        Me.rdoTerminados.Text = "Lotes Terminados"
        Me.rdoTerminados.UseVisualStyleBackColor = True
        '
        'rdoAtrasados
        '
        Me.rdoAtrasados.AutoSize = True
        Me.rdoAtrasados.Location = New System.Drawing.Point(105, 11)
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
        Me.rdoTodos.Location = New System.Drawing.Point(17, 11)
        Me.rdoTodos.Name = "rdoTodos"
        Me.rdoTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoTodos.TabIndex = 0
        Me.rdoTodos.TabStop = True
        Me.rdoTodos.Text = "Todos"
        Me.rdoTodos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(26, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Mostrar"
        '
        'txtDias
        '
        Me.txtDias.Location = New System.Drawing.Point(-86, 40)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(45, 20)
        Me.txtDias.TabIndex = 6
        Me.txtDias.Visible = False
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Location = New System.Drawing.Point(615, 58)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(30, 13)
        Me.lblDias.TabIndex = 5
        Me.lblDias.Text = "Días"
        Me.lblDias.Visible = False
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(500, 74)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaFinal.TabIndex = 4
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(500, 44)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.dtpFechaInicio.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaInicio.TabIndex = 3
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(473, 73)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(14, 13)
        Me.lblA.TabIndex = 2
        Me.lblA.Text = "A"
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(473, 47)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(21, 13)
        Me.lblDe.TabIndex = 1
        Me.lblDe.Text = "De"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(29, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(262, 47)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(36, 13)
        Me.lblCelula.TabIndex = 7
        Me.lblCelula.Text = "Célula"
        '
        'cmbCelulas
        '
        Me.cmbCelulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCelulas.FormattingEnabled = True
        Me.cmbCelulas.Location = New System.Drawing.Point(311, 44)
        Me.cmbCelulas.Name = "cmbCelulas"
        Me.cmbCelulas.Size = New System.Drawing.Size(121, 21)
        Me.cmbCelulas.TabIndex = 6
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(114, 73)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(121, 21)
        Me.cmbDepartamento.TabIndex = 3
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(114, 44)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(121, 21)
        Me.cmbNave.TabIndex = 2
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(13, 76)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.lblDepartamento.TabIndex = 1
        Me.lblDepartamento.Text = "Departamento"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(13, 47)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Nave"
        '
        'grdAvances
        '
        Me.grdAvances.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.grdAvances.ColumnInfo = resources.GetString("grdAvances.ColumnInfo")
        Me.grdAvances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAvances.ExtendLastCol = True
        Me.grdAvances.Location = New System.Drawing.Point(0, 150)
        Me.grdAvances.Name = "grdAvances"
        Me.grdAvances.Rows.Count = 1
        Me.grdAvances.Rows.DefaultSize = 19
        Me.grdAvances.Size = New System.Drawing.Size(857, 295)
        Me.grdAvances.StyleInfo = resources.GetString("grdAvances.StyleInfo")
        Me.grdAvances.TabIndex = 11
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.lblCelula)
        Me.grbFiltros.Controls.Add(Me.lblDias)
        Me.grbFiltros.Controls.Add(Me.Panel2)
        Me.grbFiltros.Controls.Add(Me.cmbCelulas)
        Me.grbFiltros.Controls.Add(Me.dtpFechaFinal)
        Me.grbFiltros.Controls.Add(Me.cmbDepartamento)
        Me.grbFiltros.Controls.Add(Me.lblNave)
        Me.grbFiltros.Controls.Add(Me.lblA)
        Me.grbFiltros.Controls.Add(Me.dtpFechaInicio)
        Me.grbFiltros.Controls.Add(Me.cmbNave)
        Me.grbFiltros.Controls.Add(Me.lblDe)
        Me.grbFiltros.Controls.Add(Me.lblDepartamento)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFiltros.Location = New System.Drawing.Point(0, 50)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(857, 100)
        Me.grbFiltros.TabIndex = 12
        Me.grbFiltros.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtDias)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.lblLimpiar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(737, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(117, 81)
        Me.Panel2.TabIndex = 40
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(61, 5)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(86, 5)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(74, 31)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(71, 64)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 33
        Me.lblLimpiar.Text = "Limpiar"
        '
        'VerificarAvancesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(857, 592)
        Me.Controls.Add(Me.grdAvances)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel5)
        Me.Name = "VerificarAvancesForm"
        Me.Text = "Consulta de Avances de Producción por Fecha de Avance"
        Me.Panel7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdResumenesDepartamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.head2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlNave.ResumeLayout(False)
        Me.pnlNave.PerformLayout()
        Me.pnlDepartamento.ResumeLayout(False)
        Me.pnlDepartamento.PerformLayout()
        CType(Me.head, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInventarioNave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInventarioDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMasFiltros.ResumeLayout(False)
        Me.pnlMasFiltros.PerformLayout()
        CType(Me.grdAvances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents pnlMasFiltros As System.Windows.Forms.Panel
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
    Friend WithEvents lblTotalInventario As System.Windows.Forms.Label
    Friend WithEvents pnlDepartamento As System.Windows.Forms.Panel
    Friend WithEvents lblinvdepartamento As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents lblDias As System.Windows.Forms.Label
    Friend WithEvents grdAvances As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grdResumenesDepartamentos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents head As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents head2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grdInventarioDepartamento As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grdInventarioNave As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pnlNave As System.Windows.Forms.Panel
    Friend WithEvents lblInventarioNave As System.Windows.Forms.Label
    Friend WithEvents lb_linvNave As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cmbCelulas As System.Windows.Forms.ComboBox
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExpCod As Button
    Friend WithEvents Label7 As Label
End Class
