<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovtosCreditosInfonavitForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovtosCreditosInfonavitForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlReporte = New System.Windows.Forms.Panel()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.pnlAplicar = New System.Windows.Forms.Panel()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.lblAplicar = New System.Windows.Forms.Label()
        Me.pnlGenerarTxt = New System.Windows.Forms.Panel()
        Me.btnGenerarTxt = New System.Windows.Forms.Button()
        Me.lblGenerarTxt = New System.Windows.Forms.Label()
        Me.pnlVer = New System.Windows.Forms.Panel()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlAltas = New System.Windows.Forms.Panel()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblFechaFinal = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPagado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdListadoMovimientos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlReporte.SuspendLayout()
        Me.pnlAplicar.SuspendLayout()
        Me.pnlGenerarTxt.SuspendLayout()
        Me.pnlVer.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlAltas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        CType(Me.grdListadoMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlReporte)
        Me.pnlEncabezado.Controls.Add(Me.pnlAplicar)
        Me.pnlEncabezado.Controls.Add(Me.pnlGenerarTxt)
        Me.pnlEncabezado.Controls.Add(Me.pnlVer)
        Me.pnlEncabezado.Controls.Add(Me.pnlEditar)
        Me.pnlEncabezado.Controls.Add(Me.pnlAltas)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1241, 69)
        Me.pnlEncabezado.TabIndex = 6
        '
        'pnlReporte
        '
        Me.pnlReporte.Controls.Add(Me.btnReporte)
        Me.pnlReporte.Controls.Add(Me.lblReporte)
        Me.pnlReporte.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlReporte.Location = New System.Drawing.Point(318, 0)
        Me.pnlReporte.Name = "pnlReporte"
        Me.pnlReporte.Size = New System.Drawing.Size(59, 69)
        Me.pnlReporte.TabIndex = 39
        Me.pnlReporte.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReporte.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnReporte.Location = New System.Drawing.Point(14, 11)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnReporte.TabIndex = 31
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblReporte.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReporte.Location = New System.Drawing.Point(10, 45)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(45, 13)
        Me.lblReporte.TabIndex = 32
        Me.lblReporte.Text = "Reporte"
        '
        'pnlAplicar
        '
        Me.pnlAplicar.Controls.Add(Me.btnAplicar)
        Me.pnlAplicar.Controls.Add(Me.lblAplicar)
        Me.pnlAplicar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAplicar.Location = New System.Drawing.Point(259, 0)
        Me.pnlAplicar.Name = "pnlAplicar"
        Me.pnlAplicar.Size = New System.Drawing.Size(59, 69)
        Me.pnlAplicar.TabIndex = 38
        Me.pnlAplicar.Visible = False
        '
        'btnAplicar
        '
        Me.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAplicar.Image = Global.Contabilidad.Vista.My.Resources.Resources.aceptar_32
        Me.btnAplicar.Location = New System.Drawing.Point(13, 11)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(32, 32)
        Me.btnAplicar.TabIndex = 29
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'lblAplicar
        '
        Me.lblAplicar.AutoSize = True
        Me.lblAplicar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAplicar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAplicar.Location = New System.Drawing.Point(10, 45)
        Me.lblAplicar.Name = "lblAplicar"
        Me.lblAplicar.Size = New System.Drawing.Size(39, 13)
        Me.lblAplicar.TabIndex = 30
        Me.lblAplicar.Text = "Aplicar"
        '
        'pnlGenerarTxt
        '
        Me.pnlGenerarTxt.Controls.Add(Me.btnGenerarTxt)
        Me.pnlGenerarTxt.Controls.Add(Me.lblGenerarTxt)
        Me.pnlGenerarTxt.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarTxt.Location = New System.Drawing.Point(177, 0)
        Me.pnlGenerarTxt.Name = "pnlGenerarTxt"
        Me.pnlGenerarTxt.Size = New System.Drawing.Size(82, 69)
        Me.pnlGenerarTxt.TabIndex = 36
        '
        'btnGenerarTxt
        '
        Me.btnGenerarTxt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerarTxt.Image = Global.Contabilidad.Vista.My.Resources.Resources.reporteDeducciones_
        Me.btnGenerarTxt.Location = New System.Drawing.Point(24, 11)
        Me.btnGenerarTxt.Name = "btnGenerarTxt"
        Me.btnGenerarTxt.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarTxt.TabIndex = 29
        Me.btnGenerarTxt.UseVisualStyleBackColor = True
        '
        'lblGenerarTxt
        '
        Me.lblGenerarTxt.AutoSize = True
        Me.lblGenerarTxt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGenerarTxt.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarTxt.Location = New System.Drawing.Point(8, 45)
        Me.lblGenerarTxt.Name = "lblGenerarTxt"
        Me.lblGenerarTxt.Size = New System.Drawing.Size(69, 13)
        Me.lblGenerarTxt.TabIndex = 30
        Me.lblGenerarTxt.Text = "Generar TXT"
        '
        'pnlVer
        '
        Me.pnlVer.Controls.Add(Me.btnVer)
        Me.pnlVer.Controls.Add(Me.lblVer)
        Me.pnlVer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVer.Location = New System.Drawing.Point(118, 0)
        Me.pnlVer.Name = "pnlVer"
        Me.pnlVer.Size = New System.Drawing.Size(59, 69)
        Me.pnlVer.TabIndex = 35
        '
        'btnVer
        '
        Me.btnVer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVer.Image = Global.Contabilidad.Vista.My.Resources.Resources.verRegistro
        Me.btnVer.Location = New System.Drawing.Point(15, 11)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(32, 32)
        Me.btnVer.TabIndex = 23
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'lblVer
        '
        Me.lblVer.AutoSize = True
        Me.lblVer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblVer.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVer.Location = New System.Drawing.Point(19, 45)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(23, 13)
        Me.lblVer.TabIndex = 24
        Me.lblVer.Text = "Ver"
        Me.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEditar)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEditar.Location = New System.Drawing.Point(59, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(59, 69)
        Me.pnlEditar.TabIndex = 34
        '
        'btnEditar
        '
        Me.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(13, 11)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 22
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(12, 45)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 23
        Me.lblEditar.Text = "Editar"
        '
        'pnlAltas
        '
        Me.pnlAltas.Controls.Add(Me.btnAltas)
        Me.pnlAltas.Controls.Add(Me.lblAltas)
        Me.pnlAltas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAltas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAltas.Name = "pnlAltas"
        Me.pnlAltas.Size = New System.Drawing.Size(59, 69)
        Me.pnlAltas.TabIndex = 33
        '
        'btnAltas
        '
        Me.btnAltas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(14, 11)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(15, 45)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(766, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 69)
        Me.Panel1.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(52, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(349, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Lista de Movimientos de Créditos Infonavit"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.GroupBox1)
        Me.grbFiltros.Controls.Add(Me.Panel6)
        Me.grbFiltros.Controls.Add(Me.cmbEstatus)
        Me.grbFiltros.Controls.Add(Me.lblEstatus)
        Me.grbFiltros.Controls.Add(Me.cmbEmpresa)
        Me.grbFiltros.Controls.Add(Me.lblEmpresa)
        Me.grbFiltros.Controls.Add(Me.cmbNave)
        Me.grbFiltros.Controls.Add(Me.lblNave)
        Me.grbFiltros.Controls.Add(Me.txtNombre)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFiltros.ForeColor = System.Drawing.Color.Black
        Me.grbFiltros.Location = New System.Drawing.Point(0, 69)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1241, 114)
        Me.grbFiltros.TabIndex = 7
        Me.grbFiltros.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.chkPeriodo)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaFinal)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(824, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(223, 67)
        Me.GroupBox1.TabIndex = 52
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(111, 44)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaFin.TabIndex = 30
        '
        'chkPeriodo
        '
        Me.chkPeriodo.AutoSize = True
        Me.chkPeriodo.Location = New System.Drawing.Point(15, 21)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(15, 14)
        Me.chkPeriodo.TabIndex = 24
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Enabled = False
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(111, 18)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaInicio.TabIndex = 29
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFechaInicio.Location = New System.Drawing.Point(36, 21)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(66, 13)
        Me.lblFechaInicio.TabIndex = 20
        Me.lblFechaInicio.Text = "Fecha inicial"
        '
        'lblFechaFinal
        '
        Me.lblFechaFinal.AutoSize = True
        Me.lblFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFinal.ForeColor = System.Drawing.Color.Black
        Me.lblFechaFinal.Location = New System.Drawing.Point(43, 49)
        Me.lblFechaFinal.Name = "lblFechaFinal"
        Me.lblFechaFinal.Size = New System.Drawing.Size(59, 13)
        Me.lblFechaFinal.TabIndex = 21
        Me.lblFechaFinal.Text = "Fecha final"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblMostrar)
        Me.Panel6.Controls.Add(Me.lblLimpiar)
        Me.Panel6.Controls.Add(Me.btnLimpiar)
        Me.Panel6.Controls.Add(Me.btnBuscar)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1129, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(109, 95)
        Me.Panel6.TabIndex = 51
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(12, 70)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 54
        Me.lblMostrar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(64, 70)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(67, 38)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(15, 38)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(79, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 34
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(55, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 33
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(534, 47)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(261, 21)
        Me.cmbEstatus.TabIndex = 46
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.ForeColor = System.Drawing.Color.Black
        Me.lblEstatus.Location = New System.Drawing.Point(486, 50)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(42, 13)
        Me.lblEstatus.TabIndex = 45
        Me.lblEstatus.Text = "Estatus"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColor = System.Drawing.Color.Black
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(75, 80)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(380, 21)
        Me.cmbEmpresa.TabIndex = 44
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(21, 83)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 43
        Me.lblEmpresa.Text = "Empresa"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(75, 47)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(380, 21)
        Me.cmbNave.TabIndex = 42
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(36, 50)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 41
        Me.lblNave.Text = "Nave"
        '
        'txtNombre
        '
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(534, 80)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(261, 20)
        Me.txtNombre.TabIndex = 36
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(484, 83)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 35
        Me.lblNombre.Text = "Nombre"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 496)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1241, 60)
        Me.pnlPie.TabIndex = 29
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1184, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(57, 60)
        Me.pnlOperaciones.TabIndex = 24
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(13, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 28
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(12, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 29
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.Label8)
        Me.pnlEstado.Controls.Add(Me.Label9)
        Me.pnlEstado.Controls.Add(Me.lblPagado)
        Me.pnlEstado.Controls.Add(Me.Label2)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1176, 60)
        Me.pnlEstado.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(34, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Correcto"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Black
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(13, 11)
        Me.Label9.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label9.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 15)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "___"
        '
        'lblPagado
        '
        Me.lblPagado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPagado.AutoSize = True
        Me.lblPagado.ForeColor = System.Drawing.Color.Black
        Me.lblPagado.Location = New System.Drawing.Point(33, 37)
        Me.lblPagado.Name = "lblPagado"
        Me.lblPagado.Size = New System.Drawing.Size(59, 13)
        Me.lblPagado.TabIndex = 1
        Me.lblPagado.Text = "Modificado"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Red
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(13, 37)
        Me.Label2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label2.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.UseMnemonic = False
        '
        'grdListadoMovimientos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadoMovimientos.DisplayLayout.Appearance = Appearance1
        Me.grdListadoMovimientos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListadoMovimientos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListadoMovimientos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListadoMovimientos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListadoMovimientos.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListadoMovimientos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadoMovimientos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdListadoMovimientos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListadoMovimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListadoMovimientos.Location = New System.Drawing.Point(0, 183)
        Me.grdListadoMovimientos.Name = "grdListadoMovimientos"
        Me.grdListadoMovimientos.Size = New System.Drawing.Size(1241, 313)
        Me.grdListadoMovimientos.TabIndex = 30
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(403, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'MovtosCreditosInfonavitForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 556)
        Me.Controls.Add(Me.grdListadoMovimientos)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "MovtosCreditosInfonavitForm"
        Me.Text = "Movimientos de Créditos Infonavit"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlReporte.ResumeLayout(False)
        Me.pnlReporte.PerformLayout()
        Me.pnlAplicar.ResumeLayout(False)
        Me.pnlAplicar.PerformLayout()
        Me.pnlGenerarTxt.ResumeLayout(False)
        Me.pnlGenerarTxt.PerformLayout()
        Me.pnlVer.ResumeLayout(False)
        Me.pnlVer.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlAltas.ResumeLayout(False)
        Me.pnlAltas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        CType(Me.grdListadoMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlReporte As System.Windows.Forms.Panel
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents pnlAplicar As System.Windows.Forms.Panel
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents lblAplicar As System.Windows.Forms.Label
    Friend WithEvents pnlGenerarTxt As System.Windows.Forms.Panel
    Friend WithEvents pnlVer As System.Windows.Forms.Panel
    Friend WithEvents btnVer As System.Windows.Forms.Button
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents pnlEditar As System.Windows.Forms.Panel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents pnlAltas As System.Windows.Forms.Panel
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnGenerarTxt As System.Windows.Forms.Button
    Friend WithEvents lblGenerarTxt As System.Windows.Forms.Label
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPeriodo As System.Windows.Forms.CheckBox
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPagado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdListadoMovimientos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
