<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programacion_ImportarCalendarioForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlGenerar = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlDescargar = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDescargar = New System.Windows.Forms.Button()
        Me.pnlImportar = New System.Windows.Forms.Panel()
        Me.lblImportar = New System.Windows.Forms.Label()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMosrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudAnio = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgDatos = New DevExpress.XtraGrid.GridControl()
        Me.dgVDatos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnHabilitarProgramaSICY = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlGenerar.SuspendLayout()
        Me.pnlDescargar.SuspendLayout()
        Me.pnlImportar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgVDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.pnlGenerar)
        Me.Panel1.Controls.Add(Me.pnlDescargar)
        Me.Panel1.Controls.Add(Me.pnlImportar)
        Me.Panel1.Controls.Add(Me.pnlTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(863, 78)
        Me.Panel1.TabIndex = 0
        '
        'pnlGenerar
        '
        Me.pnlGenerar.Controls.Add(Me.Label2)
        Me.pnlGenerar.Controls.Add(Me.btnGenerar)
        Me.pnlGenerar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerar.Location = New System.Drawing.Point(134, 0)
        Me.pnlGenerar.Name = "pnlGenerar"
        Me.pnlGenerar.Size = New System.Drawing.Size(67, 78)
        Me.pnlGenerar.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(9, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 26)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Semanas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerar
        '
        Me.btnGenerar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnGenerar.Image = Global.Programacion.Vista.My.Resources.Resources.catalogos_32
        Me.btnGenerar.Location = New System.Drawing.Point(18, 9)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerar.TabIndex = 87
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'pnlDescargar
        '
        Me.pnlDescargar.Controls.Add(Me.Label1)
        Me.pnlDescargar.Controls.Add(Me.btnDescargar)
        Me.pnlDescargar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDescargar.Location = New System.Drawing.Point(67, 0)
        Me.pnlDescargar.Name = "pnlDescargar"
        Me.pnlDescargar.Size = New System.Drawing.Size(67, 78)
        Me.pnlDescargar.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 26)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Descargar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Formato"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnDescargar
        '
        Me.btnDescargar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnDescargar.Image = Global.Programacion.Vista.My.Resources.Resources.ordenar
        Me.btnDescargar.Location = New System.Drawing.Point(19, 9)
        Me.btnDescargar.Name = "btnDescargar"
        Me.btnDescargar.Size = New System.Drawing.Size(32, 32)
        Me.btnDescargar.TabIndex = 87
        Me.btnDescargar.UseVisualStyleBackColor = False
        '
        'pnlImportar
        '
        Me.pnlImportar.Controls.Add(Me.lblImportar)
        Me.pnlImportar.Controls.Add(Me.btnImportar)
        Me.pnlImportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlImportar.Name = "pnlImportar"
        Me.pnlImportar.Size = New System.Drawing.Size(67, 78)
        Me.pnlImportar.TabIndex = 2
        '
        'lblImportar
        '
        Me.lblImportar.AutoSize = True
        Me.lblImportar.BackColor = System.Drawing.Color.Transparent
        Me.lblImportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImportar.Location = New System.Drawing.Point(16, 44)
        Me.lblImportar.Name = "lblImportar"
        Me.lblImportar.Size = New System.Drawing.Size(45, 13)
        Me.lblImportar.TabIndex = 88
        Me.lblImportar.Text = "Importar"
        Me.lblImportar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImportar
        '
        Me.btnImportar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnImportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnImportar.Location = New System.Drawing.Point(20, 9)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(32, 32)
        Me.btnImportar.TabIndex = 87
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(601, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(262, 78)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(18, 27)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(145, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Calendario PPCP"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(179, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 78)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(863, 29)
        Me.Panel2.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnAbajo)
        Me.Panel7.Controls.Add(Me.btnArriba)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(743, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(120, 29)
        Me.Panel7.TabIndex = 0
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(57, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(21, 20)
        Me.btnAbajo.TabIndex = 2
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(30, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 1
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.lblRegistrosTitulo)
        Me.Panel3.Controls.Add(Me.lblRegistros)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 419)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(863, 65)
        Me.Panel3.TabIndex = 2
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(32, 11)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 187
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(32, 36)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 188
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblUltimaActualizacion)
        Me.Panel5.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.btnGuardar)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.btnCerrar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(547, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(316, 65)
        Me.Panel5.TabIndex = 0
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(65, 34)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 164
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(73, 16)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 163
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(203, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Guardar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(209, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 91
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(252, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Cerrar"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(253, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 89
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Label7)
        Me.pnlFiltros.Controls.Add(Me.Panel6)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 107)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(863, 90)
        Me.pnlFiltros.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(379, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Nuevo Formulario C"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Visible = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.btnMosrar)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(743, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(120, 90)
        Me.Panel6.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(41, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Mostrar"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnMosrar
        '
        Me.btnMosrar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnMosrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMosrar.Location = New System.Drawing.Point(44, 21)
        Me.btnMosrar.Name = "btnMosrar"
        Me.btnMosrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMosrar.TabIndex = 89
        Me.btnMosrar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudAnio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 71)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'nudAnio
        '
        Me.nudAnio.Location = New System.Drawing.Point(56, 28)
        Me.nudAnio.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.nudAnio.Name = "nudAnio"
        Me.nudAnio.Size = New System.Drawing.Size(93, 20)
        Me.nudAnio.TabIndex = 1
        Me.nudAnio.Value = New Decimal(New Integer() {2021, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Año:"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgDatos)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 197)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(863, 222)
        Me.Panel4.TabIndex = 4
        '
        'dgDatos
        '
        Me.dgDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDatos.Location = New System.Drawing.Point(0, 0)
        Me.dgDatos.MainView = Me.dgVDatos
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.Size = New System.Drawing.Size(863, 222)
        Me.dgDatos.TabIndex = 32
        Me.dgDatos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgVDatos})
        '
        'dgVDatos
        '
        Me.dgVDatos.GridControl = Me.dgDatos
        Me.dgVDatos.Name = "dgVDatos"
        Me.dgVDatos.OptionsMenu.EnableColumnMenu = False
        Me.dgVDatos.OptionsPrint.AllowMultilineHeaders = True
        Me.dgVDatos.OptionsSelection.InvertSelection = True
        Me.dgVDatos.OptionsSelection.MultiSelect = True
        Me.dgVDatos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.dgVDatos.OptionsView.ShowAutoFilterRow = True
        Me.dgVDatos.OptionsView.ShowGroupPanel = False
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Label8)
        Me.Panel8.Controls.Add(Me.btnHabilitarProgramaSICY)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(201, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(89, 78)
        Me.Panel8.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(4, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 26)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Habilitar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Programa SICY"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnHabilitarProgramaSICY
        '
        Me.btnHabilitarProgramaSICY.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnHabilitarProgramaSICY.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnHabilitarProgramaSICY.Location = New System.Drawing.Point(27, 9)
        Me.btnHabilitarProgramaSICY.Name = "btnHabilitarProgramaSICY"
        Me.btnHabilitarProgramaSICY.Size = New System.Drawing.Size(32, 32)
        Me.btnHabilitarProgramaSICY.TabIndex = 87
        Me.btnHabilitarProgramaSICY.UseVisualStyleBackColor = False
        '
        'Programacion_ImportarCalendarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 484)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Programacion_ImportarCalendarioForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Calendario"
        Me.Panel1.ResumeLayout(False)
        Me.pnlGenerar.ResumeLayout(False)
        Me.pnlGenerar.PerformLayout()
        Me.pnlDescargar.ResumeLayout(False)
        Me.pnlDescargar.PerformLayout()
        Me.pnlImportar.ResumeLayout(False)
        Me.pnlImportar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgVDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents pnlImportar As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblImportar As Label
    Friend WithEvents btnImportar As Button
    Friend WithEvents pnlGenerar As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGenerar As Button
    Friend WithEvents pnlDescargar As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDescargar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents nudAnio As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents dgDatos As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgVDatos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnMosrar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents btnHabilitarProgramaSICY As Button
End Class
