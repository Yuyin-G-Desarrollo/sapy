<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Programacion_ColocacionSemanal_Configuracion_ArticulosForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdListadoArticulos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.lblAsignar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.pnlAsignar = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.chkFechaAsignar = New System.Windows.Forms.CheckBox()
        Me.chkFechaProgramar = New System.Windows.Forms.CheckBox()
        Me.dtpFechaProgramarDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpSiguienteFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnAsignarFecha = New System.Windows.Forms.Button()
        Me.pnlTransferir = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaProgramarDesdeTransferir = New System.Windows.Forms.DateTimePicker()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.lblNaveNueva = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblNaveActual = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaProgramarHastaTransferir = New System.Windows.Forms.DateTimePicker()
        Me.pnlDesasignar = New System.Windows.Forms.Panel()
        Me.dtpFechaProgramarHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblProgramarHasta = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdListadoArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlVentas.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.pnlAsignar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlTransferir.SuspendLayout()
        Me.pnlDesasignar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(675, 560)
        Me.Panel1.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 134)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(675, 355)
        Me.Panel3.TabIndex = 27
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdListadoArticulos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(675, 355)
        Me.Panel2.TabIndex = 1
        '
        'grdListadoArticulos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadoArticulos.DisplayLayout.Appearance = Appearance1
        Me.grdListadoArticulos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdListadoArticulos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdListadoArticulos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdListadoArticulos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdListadoArticulos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListadoArticulos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdListadoArticulos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListadoArticulos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdListadoArticulos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListadoArticulos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListadoArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListadoArticulos.Location = New System.Drawing.Point(0, 0)
        Me.grdListadoArticulos.Name = "grdListadoArticulos"
        Me.grdListadoArticulos.Size = New System.Drawing.Size(675, 355)
        Me.grdListadoArticulos.TabIndex = 64
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPie.Location = New System.Drawing.Point(0, 489)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(675, 71)
        Me.pnlPie.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 18)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Seleccionados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(21, 40)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 119
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnAsignar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAsignar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(513, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnAsignar
        '
        Me.btnAsignar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.autorizar_32
        Me.btnAsignar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAsignar.Enabled = False
        Me.btnAsignar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAsignar.Location = New System.Drawing.Point(74, 8)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(32, 32)
        Me.btnAsignar.TabIndex = 3
        Me.btnAsignar.UseVisualStyleBackColor = True
        '
        'lblAsignar
        '
        Me.lblAsignar.AutoSize = True
        Me.lblAsignar.Enabled = False
        Me.lblAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAsignar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAsignar.Location = New System.Drawing.Point(68, 40)
        Me.lblAsignar.Name = "lblAsignar"
        Me.lblAsignar.Size = New System.Drawing.Size(42, 13)
        Me.lblAsignar.TabIndex = 2
        Me.lblAsignar.Text = "Asignar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
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
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlEncabezado.Controls.Add(Me.Panel6)
        Me.pnlEncabezado.Controls.Add(Me.Panel5)
        Me.pnlEncabezado.Controls.Add(Me.pnlTransferir)
        Me.pnlEncabezado.Controls.Add(Me.pnlDesasignar)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(675, 134)
        Me.pnlEncabezado.TabIndex = 24
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.pnlVentas)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.MaximumSize = New System.Drawing.Size(667, 65)
        Me.Panel6.MinimumSize = New System.Drawing.Size(667, 65)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(667, 65)
        Me.Panel6.TabIndex = 4
        '
        'pnlVentas
        '
        Me.pnlVentas.BackColor = System.Drawing.Color.White
        Me.pnlVentas.Controls.Add(Me.pnlTitulo)
        Me.pnlVentas.Controls.Add(Me.lblTitulo)
        Me.pnlVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVentas.Location = New System.Drawing.Point(0, 0)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(667, 65)
        Me.pnlVentas.TabIndex = 2
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(591, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(76, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(3, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(73, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(107, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(79, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Artículos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.pnlAsignar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 66)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(675, 68)
        Me.Panel5.TabIndex = 3
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.chkSeleccionarTodo)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(73, 68)
        Me.Panel7.TabIndex = 0
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(4, 45)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(68, 17)
        Me.chkSeleccionarTodo.TabIndex = 41
        Me.chkSeleccionarTodo.Text = "Sel. todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'pnlAsignar
        '
        Me.pnlAsignar.Controls.Add(Me.GroupBox1)
        Me.pnlAsignar.Location = New System.Drawing.Point(79, 0)
        Me.pnlAsignar.Name = "pnlAsignar"
        Me.pnlAsignar.Size = New System.Drawing.Size(588, 68)
        Me.pnlAsignar.TabIndex = 65
        Me.pnlAsignar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.chkFechaAsignar)
        Me.GroupBox1.Controls.Add(Me.chkFechaProgramar)
        Me.GroupBox1.Controls.Add(Me.dtpFechaProgramarDesde)
        Me.GroupBox1.Controls.Add(Me.dtpSiguienteFecha)
        Me.GroupBox1.Controls.Add(Me.btnAsignarFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 60)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione ""La o Las"" Fechas a Modificar"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(24, 27)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(92, 13)
        Me.lblFecha.TabIndex = 124
        Me.lblFecha.Text = "Programar Desde:"
        Me.lblFecha.Visible = False
        '
        'chkFechaAsignar
        '
        Me.chkFechaAsignar.AutoSize = True
        Me.chkFechaAsignar.Location = New System.Drawing.Point(251, 24)
        Me.chkFechaAsignar.Name = "chkFechaAsignar"
        Me.chkFechaAsignar.Size = New System.Drawing.Size(144, 17)
        Me.chkFechaAsignar.TabIndex = 168
        Me.chkFechaAsignar.Text = "Siguiente Fecha Asignar:"
        Me.chkFechaAsignar.UseVisualStyleBackColor = True
        Me.chkFechaAsignar.Visible = False
        '
        'chkFechaProgramar
        '
        Me.chkFechaProgramar.AutoSize = True
        Me.chkFechaProgramar.Checked = True
        Me.chkFechaProgramar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFechaProgramar.Location = New System.Drawing.Point(8, 24)
        Me.chkFechaProgramar.Name = "chkFechaProgramar"
        Me.chkFechaProgramar.Size = New System.Drawing.Size(111, 17)
        Me.chkFechaProgramar.TabIndex = 167
        Me.chkFechaProgramar.Text = "Programar Desde:"
        Me.chkFechaProgramar.UseVisualStyleBackColor = True
        Me.chkFechaProgramar.Visible = False
        '
        'dtpFechaProgramarDesde
        '
        Me.dtpFechaProgramarDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProgramarDesde.Location = New System.Drawing.Point(119, 24)
        Me.dtpFechaProgramarDesde.Name = "dtpFechaProgramarDesde"
        Me.dtpFechaProgramarDesde.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaProgramarDesde.TabIndex = 121
        '
        'dtpSiguienteFecha
        '
        Me.dtpSiguienteFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSiguienteFecha.Location = New System.Drawing.Point(395, 24)
        Me.dtpSiguienteFecha.Name = "dtpSiguienteFecha"
        Me.dtpSiguienteFecha.Size = New System.Drawing.Size(98, 20)
        Me.dtpSiguienteFecha.TabIndex = 163
        Me.dtpSiguienteFecha.Visible = False
        '
        'btnAsignarFecha
        '
        Me.btnAsignarFecha.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAsignarFecha.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAsignarFecha.Image = Global.Programacion.Vista.My.Resources.Resources.aceptar_321
        Me.btnAsignarFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAsignarFecha.Location = New System.Drawing.Point(504, 17)
        Me.btnAsignarFecha.Name = "btnAsignarFecha"
        Me.btnAsignarFecha.Size = New System.Drawing.Size(32, 32)
        Me.btnAsignarFecha.TabIndex = 166
        Me.btnAsignarFecha.UseVisualStyleBackColor = True
        Me.btnAsignarFecha.Visible = False
        '
        'pnlTransferir
        '
        Me.pnlTransferir.Controls.Add(Me.Label3)
        Me.pnlTransferir.Controls.Add(Me.dtpFechaProgramarDesdeTransferir)
        Me.pnlTransferir.Controls.Add(Me.cmbNaves)
        Me.pnlTransferir.Controls.Add(Me.lblNaveNueva)
        Me.pnlTransferir.Controls.Add(Me.lblNave)
        Me.pnlTransferir.Controls.Add(Me.lblNaveActual)
        Me.pnlTransferir.Controls.Add(Me.Label2)
        Me.pnlTransferir.Controls.Add(Me.dtpFechaProgramarHastaTransferir)
        Me.pnlTransferir.Location = New System.Drawing.Point(75, 66)
        Me.pnlTransferir.Name = "pnlTransferir"
        Me.pnlTransferir.Size = New System.Drawing.Size(552, 68)
        Me.pnlTransferir.TabIndex = 123
        Me.pnlTransferir.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 158
        Me.Label3.Text = "Programar Desde:"
        '
        'dtpFechaProgramarDesdeTransferir
        '
        Me.dtpFechaProgramarDesdeTransferir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProgramarDesdeTransferir.Location = New System.Drawing.Point(323, 37)
        Me.dtpFechaProgramarDesdeTransferir.Name = "dtpFechaProgramarDesdeTransferir"
        Me.dtpFechaProgramarDesdeTransferir.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaProgramarDesdeTransferir.TabIndex = 159
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(308, 4)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(165, 21)
        Me.cmbNaves.TabIndex = 157
        '
        'lblNaveNueva
        '
        Me.lblNaveNueva.AutoSize = True
        Me.lblNaveNueva.Location = New System.Drawing.Point(231, 7)
        Me.lblNaveNueva.Name = "lblNaveNueva"
        Me.lblNaveNueva.Size = New System.Drawing.Size(71, 13)
        Me.lblNaveNueva.TabIndex = 124
        Me.lblNaveNueva.Text = "Nave Nueva:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(80, 7)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(102, 13)
        Me.lblNave.TabIndex = 123
        Me.lblNave.Text = "ALTERNA JEMPLO"
        '
        'lblNaveActual
        '
        Me.lblNaveActual.AutoSize = True
        Me.lblNaveActual.Location = New System.Drawing.Point(5, 7)
        Me.lblNaveActual.Name = "lblNaveActual"
        Me.lblNaveActual.Size = New System.Drawing.Size(69, 13)
        Me.lblNaveActual.TabIndex = 122
        Me.lblNaveActual.Text = "Nave Actual:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Programar Hasta:"
        '
        'dtpFechaProgramarHastaTransferir
        '
        Me.dtpFechaProgramarHastaTransferir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProgramarHastaTransferir.Location = New System.Drawing.Point(97, 37)
        Me.dtpFechaProgramarHastaTransferir.Name = "dtpFechaProgramarHastaTransferir"
        Me.dtpFechaProgramarHastaTransferir.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaProgramarHastaTransferir.TabIndex = 121
        '
        'pnlDesasignar
        '
        Me.pnlDesasignar.Controls.Add(Me.dtpFechaProgramarHasta)
        Me.pnlDesasignar.Controls.Add(Me.lblProgramarHasta)
        Me.pnlDesasignar.Location = New System.Drawing.Point(78, 66)
        Me.pnlDesasignar.Name = "pnlDesasignar"
        Me.pnlDesasignar.Size = New System.Drawing.Size(552, 68)
        Me.pnlDesasignar.TabIndex = 122
        Me.pnlDesasignar.Visible = False
        '
        'dtpFechaProgramarHasta
        '
        Me.dtpFechaProgramarHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProgramarHasta.Location = New System.Drawing.Point(204, 35)
        Me.dtpFechaProgramarHasta.Name = "dtpFechaProgramarHasta"
        Me.dtpFechaProgramarHasta.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaProgramarHasta.TabIndex = 121
        '
        'lblProgramarHasta
        '
        Me.lblProgramarHasta.AutoSize = True
        Me.lblProgramarHasta.Location = New System.Drawing.Point(109, 35)
        Me.lblProgramarHasta.Name = "lblProgramarHasta"
        Me.lblProgramarHasta.Size = New System.Drawing.Size(89, 13)
        Me.lblProgramarHasta.TabIndex = 120
        Me.lblProgramarHasta.Text = "Programar Hasta:"
        '
        'Programacion_ColocacionSemanal_Configuracion_ArticulosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 560)
        Me.Controls.Add(Me.Panel1)
        Me.MaximumSize = New System.Drawing.Size(683, 587)
        Me.MinimumSize = New System.Drawing.Size(683, 587)
        Me.Name = "Programacion_ColocacionSemanal_Configuracion_ArticulosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artículos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdListadoArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.pnlVentas.ResumeLayout(False)
        Me.pnlVentas.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.pnlAsignar.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlTransferir.ResumeLayout(False)
        Me.pnlTransferir.PerformLayout()
        Me.pnlDesasignar.ResumeLayout(False)
        Me.pnlDesasignar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdListadoArticulos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnAsignar As Button
    Friend WithEvents lblAsignar As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents dtpFechaProgramarDesde As DateTimePicker
    Friend WithEvents pnlTransferir As Panel
    Friend WithEvents lblNaveNueva As Label
    Friend WithEvents lblNave As Label
    Friend WithEvents lblNaveActual As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaProgramarHastaTransferir As DateTimePicker
    Friend WithEvents pnlAsignar As Panel
    Friend WithEvents pnlDesasignar As Panel
    Friend WithEvents lblProgramarHasta As Label
    Friend WithEvents dtpFechaProgramarHasta As DateTimePicker
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlVentas As Panel
    Friend WithEvents cmbNaves As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpFechaProgramarDesdeTransferir As DateTimePicker
    Friend WithEvents dtpSiguienteFecha As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAsignarFecha As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents chkSeleccionarTodo As CheckBox
    Friend WithEvents chkFechaAsignar As CheckBox
    Friend WithEvents chkFechaProgramar As CheckBox
    Friend WithEvents lblFecha As Label
End Class
