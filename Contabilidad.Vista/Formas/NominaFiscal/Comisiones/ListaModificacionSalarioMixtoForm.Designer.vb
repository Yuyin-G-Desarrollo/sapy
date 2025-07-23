<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaModificacionSalarioMixtoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaModificacionSalarioMixtoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.pnlArchivoCargado = New System.Windows.Forms.Panel()
        Me.btnSeleccionarColaborador = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblFechaFinal = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlPDFAcuse = New System.Windows.Forms.Panel()
        Me.btnPDFAcuse = New System.Windows.Forms.Button()
        Me.lblPDFAcuse = New System.Windows.Forms.Label()
        Me.pnlGenerarTxt = New System.Windows.Forms.Panel()
        Me.btnGenerarTxt = New System.Windows.Forms.Button()
        Me.lblGenerarTxt = New System.Windows.Forms.Label()
        Me.pnlVer = New System.Windows.Forms.Panel()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlRechazar = New System.Windows.Forms.Panel()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.lblRechazar = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grdListadoSolicitudes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.menuAyuda = New System.Windows.Forms.ContextMenuStrip()
        Me.AyudaModSalMixtoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificaciónSalarioMixtoWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificaciónSalarioMixtoPropuestaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlPDFAcuse.SuspendLayout()
        Me.pnlGenerarTxt.SuspendLayout()
        Me.pnlVer.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlRechazar.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdListadoSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuAyuda.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 508)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1249, 60)
        Me.pnlPie.TabIndex = 32
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1192, 0)
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
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1176, 60)
        Me.pnlEstado.TabIndex = 22
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.cmbEstatus)
        Me.grbFiltros.Controls.Add(Me.lblEstatus)
        Me.grbFiltros.Controls.Add(Me.pnlArchivoCargado)
        Me.grbFiltros.Controls.Add(Me.btnSeleccionarColaborador)
        Me.grbFiltros.Controls.Add(Me.Label12)
        Me.grbFiltros.Controls.Add(Me.GroupBox1)
        Me.grbFiltros.Controls.Add(Me.Panel6)
        Me.grbFiltros.Controls.Add(Me.cmbEmpresa)
        Me.grbFiltros.Controls.Add(Me.lblEmpresa)
        Me.grbFiltros.ForeColor = System.Drawing.Color.Black
        Me.grbFiltros.Location = New System.Drawing.Point(3, 23)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1243, 108)
        Me.grbFiltros.TabIndex = 31
        Me.grbFiltros.TabStop = False
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(71, 64)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(261, 21)
        Me.cmbEstatus.TabIndex = 151
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.ForeColor = System.Drawing.Color.Black
        Me.lblEstatus.Location = New System.Drawing.Point(23, 67)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(42, 13)
        Me.lblEstatus.TabIndex = 150
        Me.lblEstatus.Text = "Estatus"
        '
        'pnlArchivoCargado
        '
        Me.pnlArchivoCargado.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.seleccionar
        Me.pnlArchivoCargado.Location = New System.Drawing.Point(438, 61)
        Me.pnlArchivoCargado.Name = "pnlArchivoCargado"
        Me.pnlArchivoCargado.Size = New System.Drawing.Size(16, 16)
        Me.pnlArchivoCargado.TabIndex = 149
        Me.pnlArchivoCargado.Visible = False
        '
        'btnSeleccionarColaborador
        '
        Me.btnSeleccionarColaborador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionarColaborador.Image = Global.Contabilidad.Vista.My.Resources.Resources.perfiles_32
        Me.btnSeleccionarColaborador.Location = New System.Drawing.Point(400, 53)
        Me.btnSeleccionarColaborador.Name = "btnSeleccionarColaborador"
        Me.btnSeleccionarColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnSeleccionarColaborador.TabIndex = 147
        Me.btnSeleccionarColaborador.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.Location = New System.Drawing.Point(383, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 17)
        Me.Label12.TabIndex = 148
        Me.Label12.Text = "Colaborador"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.chkPeriodo)
        Me.GroupBox1.Controls.Add(Me.lblFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaFinal)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(511, 19)
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
        Me.dtpFechaFin.Location = New System.Drawing.Point(108, 43)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaFin.TabIndex = 32
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Enabled = False
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(108, 15)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaInicio.TabIndex = 31
        '
        'chkPeriodo
        '
        Me.chkPeriodo.AutoSize = True
        Me.chkPeriodo.Location = New System.Drawing.Point(15, 18)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(15, 14)
        Me.chkPeriodo.TabIndex = 24
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFechaInicio.Location = New System.Drawing.Point(36, 18)
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
        Me.lblFechaFinal.Location = New System.Drawing.Point(43, 46)
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
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(1131, 16)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(109, 89)
        Me.Panel6.TabIndex = 51
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(12, 45)
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
        Me.lblLimpiar.Location = New System.Drawing.Point(64, 45)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(67, 13)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(15, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColor = System.Drawing.Color.Black
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(71, 29)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(380, 21)
        Me.cmbEmpresa.TabIndex = 44
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(27, 32)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(38, 13)
        Me.lblEmpresa.TabIndex = 43
        Me.lblEmpresa.Text = "Patrón"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAyuda)
        Me.pnlEncabezado.Controls.Add(Me.pnlExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlPDFAcuse)
        Me.pnlEncabezado.Controls.Add(Me.pnlGenerarTxt)
        Me.pnlEncabezado.Controls.Add(Me.pnlVer)
        Me.pnlEncabezado.Controls.Add(Me.pnlEditar)
        Me.pnlEncabezado.Controls.Add(Me.pnlRechazar)
        Me.pnlEncabezado.Controls.Add(Me.pnlAutorizar)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1249, 69)
        Me.pnlEncabezado.TabIndex = 30
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnAyuda)
        Me.pnlAyuda.Controls.Add(Me.lblAyuda)
        Me.pnlAyuda.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAyuda.Location = New System.Drawing.Point(462, 0)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(66, 69)
        Me.pnlAyuda.TabIndex = 125
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(16, 11)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 10
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'lblAyuda
        '
        Me.lblAyuda.AutoSize = True
        Me.lblAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAyuda.Location = New System.Drawing.Point(14, 45)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(37, 13)
        Me.lblAyuda.TabIndex = 8
        Me.lblAyuda.Text = "Ayuda"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(396, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(66, 69)
        Me.pnlExportar.TabIndex = 124
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(16, 11)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(31, 32)
        Me.btnExportar.TabIndex = 10
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(10, 45)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 8
        Me.lblExportar.Text = "Exportar"
        '
        'pnlPDFAcuse
        '
        Me.pnlPDFAcuse.Controls.Add(Me.btnPDFAcuse)
        Me.pnlPDFAcuse.Controls.Add(Me.lblPDFAcuse)
        Me.pnlPDFAcuse.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPDFAcuse.Location = New System.Drawing.Point(324, 0)
        Me.pnlPDFAcuse.Name = "pnlPDFAcuse"
        Me.pnlPDFAcuse.Size = New System.Drawing.Size(72, 69)
        Me.pnlPDFAcuse.TabIndex = 123
        '
        'btnPDFAcuse
        '
        Me.btnPDFAcuse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPDFAcuse.Image = Global.Contabilidad.Vista.My.Resources.Resources.agregar_pdf
        Me.btnPDFAcuse.Location = New System.Drawing.Point(20, 11)
        Me.btnPDFAcuse.Name = "btnPDFAcuse"
        Me.btnPDFAcuse.Size = New System.Drawing.Size(32, 32)
        Me.btnPDFAcuse.TabIndex = 29
        Me.btnPDFAcuse.UseVisualStyleBackColor = True
        '
        'lblPDFAcuse
        '
        Me.lblPDFAcuse.AutoSize = True
        Me.lblPDFAcuse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPDFAcuse.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPDFAcuse.Location = New System.Drawing.Point(6, 45)
        Me.lblPDFAcuse.Name = "lblPDFAcuse"
        Me.lblPDFAcuse.Size = New System.Drawing.Size(61, 13)
        Me.lblPDFAcuse.TabIndex = 30
        Me.lblPDFAcuse.Text = "PDF Acuse"
        '
        'pnlGenerarTxt
        '
        Me.pnlGenerarTxt.Controls.Add(Me.btnGenerarTxt)
        Me.pnlGenerarTxt.Controls.Add(Me.lblGenerarTxt)
        Me.pnlGenerarTxt.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarTxt.Location = New System.Drawing.Point(248, 0)
        Me.pnlGenerarTxt.Name = "pnlGenerarTxt"
        Me.pnlGenerarTxt.Size = New System.Drawing.Size(76, 69)
        Me.pnlGenerarTxt.TabIndex = 122
        '
        'btnGenerarTxt
        '
        Me.btnGenerarTxt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerarTxt.Image = Global.Contabilidad.Vista.My.Resources.Resources.reporteDeducciones_
        Me.btnGenerarTxt.Location = New System.Drawing.Point(19, 11)
        Me.btnGenerarTxt.Name = "btnGenerarTxt"
        Me.btnGenerarTxt.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarTxt.TabIndex = 27
        Me.btnGenerarTxt.UseVisualStyleBackColor = True
        '
        'lblGenerarTxt
        '
        Me.lblGenerarTxt.AutoSize = True
        Me.lblGenerarTxt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGenerarTxt.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarTxt.Location = New System.Drawing.Point(3, 45)
        Me.lblGenerarTxt.Name = "lblGenerarTxt"
        Me.lblGenerarTxt.Size = New System.Drawing.Size(69, 13)
        Me.lblGenerarTxt.TabIndex = 28
        Me.lblGenerarTxt.Text = "Generar TXT"
        '
        'pnlVer
        '
        Me.pnlVer.Controls.Add(Me.btnVer)
        Me.pnlVer.Controls.Add(Me.lblVer)
        Me.pnlVer.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVer.Location = New System.Drawing.Point(189, 0)
        Me.pnlVer.Name = "pnlVer"
        Me.pnlVer.Size = New System.Drawing.Size(59, 69)
        Me.pnlVer.TabIndex = 121
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
        Me.pnlEditar.Location = New System.Drawing.Point(127, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(62, 69)
        Me.pnlEditar.TabIndex = 116
        '
        'btnEditar
        '
        Me.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(12, 11)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(11, 45)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 19
        Me.lblEditar.Text = "Editar"
        '
        'pnlRechazar
        '
        Me.pnlRechazar.Controls.Add(Me.btnRechazar)
        Me.pnlRechazar.Controls.Add(Me.lblRechazar)
        Me.pnlRechazar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRechazar.Location = New System.Drawing.Point(59, 0)
        Me.pnlRechazar.Name = "pnlRechazar"
        Me.pnlRechazar.Size = New System.Drawing.Size(68, 69)
        Me.pnlRechazar.TabIndex = 115
        '
        'btnRechazar
        '
        Me.btnRechazar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRechazar.Image = Global.Contabilidad.Vista.My.Resources.Resources.cancelar_32
        Me.btnRechazar.Location = New System.Drawing.Point(18, 11)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazar.TabIndex = 23
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'lblRechazar
        '
        Me.lblRechazar.AutoSize = True
        Me.lblRechazar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblRechazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazar.Location = New System.Drawing.Point(8, 45)
        Me.lblRechazar.Name = "lblRechazar"
        Me.lblRechazar.Size = New System.Drawing.Size(53, 13)
        Me.lblRechazar.TabIndex = 24
        Me.lblRechazar.Text = "Rechazar"
        Me.lblRechazar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizar)
        Me.pnlAutorizar.Controls.Add(Me.lblAutorizar)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizar.Location = New System.Drawing.Point(0, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(59, 69)
        Me.pnlAutorizar.TabIndex = 34
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutorizar.Image = Global.Contabilidad.Vista.My.Resources.Resources.aceptar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(13, 11)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 25
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(6, 45)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizar.TabIndex = 26
        Me.lblAutorizar.Text = "Autorizar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(774, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 69)
        Me.Panel1.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(131, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(261, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Modificaciones de Salario Mixto"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 69)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1249, 131)
        Me.pnlFiltros.TabIndex = 34
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Location = New System.Drawing.Point(1178, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(59, 22)
        Me.Panel2.TabIndex = 32
        '
        'btnAbajo
        '
        Me.btnAbajo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(32, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 34
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(8, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 33
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grdListadoSolicitudes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadoSolicitudes.DisplayLayout.Appearance = Appearance1
        Me.grdListadoSolicitudes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListadoSolicitudes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListadoSolicitudes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListadoSolicitudes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListadoSolicitudes.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListadoSolicitudes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListadoSolicitudes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdListadoSolicitudes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListadoSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListadoSolicitudes.Location = New System.Drawing.Point(0, 200)
        Me.grdListadoSolicitudes.Name = "grdListadoSolicitudes"
        Me.grdListadoSolicitudes.Size = New System.Drawing.Size(1249, 308)
        Me.grdListadoSolicitudes.TabIndex = 35
        '
        'menuAyuda
        '
        Me.menuAyuda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaModSalMixtoToolStripMenuItem, Me.ModificaciónSalarioMixtoWordToolStripMenuItem, Me.ModificaciónSalarioMixtoPropuestaToolStripMenuItem})
        Me.menuAyuda.Name = "menuAyuda"
        Me.menuAyuda.Size = New System.Drawing.Size(249, 70)
        '
        'AyudaModSalMixtoToolStripMenuItem
        '
        Me.AyudaModSalMixtoToolStripMenuItem.Name = "AyudaModSalMixtoToolStripMenuItem"
        Me.AyudaModSalMixtoToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AyudaModSalMixtoToolStripMenuItem.Text = "Ayuda Modificación de Salario Mixto"
        '
        'ModificaciónSalarioMixtoWordToolStripMenuItem
        '
        Me.ModificaciónSalarioMixtoWordToolStripMenuItem.Name = "ModificaciónSalarioMixtoWordToolStripMenuItem"
        Me.ModificaciónSalarioMixtoWordToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ModificaciónSalarioMixtoWordToolStripMenuItem.Text = "Modificación Salario Mixto Word"
        '
        'ModificaciónSalarioMixtoPropuestaToolStripMenuItem
        '
        Me.ModificaciónSalarioMixtoPropuestaToolStripMenuItem.Name = "ModificaciónSalarioMixtoPropuestaToolStripMenuItem"
        Me.ModificaciónSalarioMixtoPropuestaToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ModificaciónSalarioMixtoPropuestaToolStripMenuItem.Text = "Modificación Salario Mixto Propuesta"
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
        'ListaModificacionSalarioMixtoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1249, 568)
        Me.Controls.Add(Me.grdListadoSolicitudes)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MinimumSize = New System.Drawing.Size(1257, 595)
        Me.Name = "ListaModificacionSalarioMixtoForm"
        Me.Text = "Modificaciones de Salario Mixto"
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlPDFAcuse.ResumeLayout(False)
        Me.pnlPDFAcuse.PerformLayout()
        Me.pnlGenerarTxt.ResumeLayout(False)
        Me.pnlGenerarTxt.PerformLayout()
        Me.pnlVer.ResumeLayout(False)
        Me.pnlVer.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlRechazar.ResumeLayout(False)
        Me.pnlRechazar.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdListadoSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuAyuda.ResumeLayout(False)
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As Windows.Forms.Panel
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents pnlEstado As Windows.Forms.Panel
    Friend WithEvents grbFiltros As Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents dtpFechaFin As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As Windows.Forms.DateTimePicker
    Friend WithEvents chkPeriodo As Windows.Forms.CheckBox
    Friend WithEvents lblFechaInicio As Windows.Forms.Label
    Friend WithEvents lblFechaFinal As Windows.Forms.Label
    Friend WithEvents Panel6 As Windows.Forms.Panel
    Friend WithEvents lblMostrar As Windows.Forms.Label
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents btnBuscar As Windows.Forms.Button
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents cmbEmpresa As Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As Windows.Forms.Label
    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents pnlAutorizar As Windows.Forms.Panel
    Friend WithEvents btnAutorizar As Windows.Forms.Button
    Friend WithEvents lblAutorizar As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlArchivoCargado As Windows.Forms.Panel
    Friend WithEvents btnSeleccionarColaborador As Windows.Forms.Button
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents pnlFiltros As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents grdListadoSolicitudes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbEstatus As Windows.Forms.ComboBox
    Friend WithEvents lblEstatus As Windows.Forms.Label
    Friend WithEvents pnlRechazar As Windows.Forms.Panel
    Friend WithEvents btnRechazar As Windows.Forms.Button
    Friend WithEvents lblRechazar As Windows.Forms.Label
    Friend WithEvents pnlEditar As Windows.Forms.Panel
    Friend WithEvents btnEditar As Windows.Forms.Button
    Friend WithEvents lblEditar As Windows.Forms.Label
    Friend WithEvents menuAyuda As Windows.Forms.ContextMenuStrip
    Friend WithEvents AyudaModSalMixtoToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificaciónSalarioMixtoWordToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificaciónSalarioMixtoPropuestaToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlAyuda As Windows.Forms.Panel
    Friend WithEvents btnAyuda As Windows.Forms.Button
    Friend WithEvents lblAyuda As Windows.Forms.Label
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlPDFAcuse As Windows.Forms.Panel
    Friend WithEvents btnPDFAcuse As Windows.Forms.Button
    Friend WithEvents lblPDFAcuse As Windows.Forms.Label
    Friend WithEvents pnlGenerarTxt As Windows.Forms.Panel
    Friend WithEvents btnGenerarTxt As Windows.Forms.Button
    Friend WithEvents lblGenerarTxt As Windows.Forms.Label
    Friend WithEvents pnlVer As Windows.Forms.Panel
    Friend WithEvents btnVer As Windows.Forms.Button
    Friend WithEvents lblVer As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
