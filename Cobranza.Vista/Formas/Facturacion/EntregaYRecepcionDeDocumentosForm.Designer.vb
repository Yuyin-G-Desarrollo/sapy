<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntregaYRecepcionDeDocumentosForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlYuyin = New System.Windows.Forms.Panel()
        Me.pnlEncabezadoExpander = New System.Windows.Forms.Panel()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.GroupBox()
        Me.grpCliente = New System.Windows.Forms.GroupBox()
        Me.btnFiltroCliente = New System.Windows.Forms.Button()
        Me.grdFiltroCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpFiltrosRecibidos = New System.Windows.Forms.GroupBox()
        Me.chkRecibidos = New System.Windows.Forms.CheckBox()
        Me.chkPendientesPorRecibir = New System.Windows.Forms.CheckBox()
        Me.grpFiltroEntregados = New System.Windows.Forms.GroupBox()
        Me.chkEntregados = New System.Windows.Forms.CheckBox()
        Me.chkPendientesPorEntregar = New System.Windows.Forms.CheckBox()
        Me.grpFiltroFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblDel = New System.Windows.Forms.Label()
        Me.pnlPieDePagina = New System.Windows.Forms.Panel()
        Me.pnlRecuento = New System.Windows.Forms.Panel()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.lblRecuentoRegistros = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.grdContenedor = New DevExpress.XtraGrid.GridControl()
        Me.grdDatos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grpFiltroCedis = New System.Windows.Forms.GroupBox()
        Me.cboCedis = New System.Windows.Forms.ComboBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlEncabezadoExpander.SuspendLayout()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.grpCliente.SuspendLayout()
        CType(Me.grdFiltroCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grpFiltrosRecibidos.SuspendLayout()
        Me.grpFiltroEntregados.SuspendLayout()
        Me.grpFiltroFecha.SuspendLayout()
        Me.pnlPieDePagina.SuspendLayout()
        Me.pnlRecuento.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdContenedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltroCedis.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Label17)
        Me.pnlEncabezado.Controls.Add(Me.btnExportarExcel)
        Me.pnlEncabezado.Controls.Add(Me.Panel2)
        Me.pnlEncabezado.Controls.Add(Me.pnlYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(954, 60)
        Me.pnlEncabezado.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label17.Location = New System.Drawing.Point(18, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "Exportar"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Cobranza.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(21, 8)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 77
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(532, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(335, 60)
        Me.Panel2.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(307, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Entrega y Recepción de Documentos"
        '
        'pnlYuyin
        '
        Me.pnlYuyin.BackgroundImage = Global.Cobranza.Vista.My.Resources.Resources.logoYuyin
        Me.pnlYuyin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlYuyin.Location = New System.Drawing.Point(867, 0)
        Me.pnlYuyin.Name = "pnlYuyin"
        Me.pnlYuyin.Size = New System.Drawing.Size(87, 60)
        Me.pnlYuyin.TabIndex = 0
        '
        'pnlEncabezadoExpander
        '
        Me.pnlEncabezadoExpander.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlEncabezadoExpander.Controls.Add(Me.pnlBotonesExpander)
        Me.pnlEncabezadoExpander.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezadoExpander.Location = New System.Drawing.Point(0, 60)
        Me.pnlEncabezadoExpander.Name = "pnlEncabezadoExpander"
        Me.pnlEncabezadoExpander.Size = New System.Drawing.Size(954, 25)
        Me.pnlEncabezadoExpander.TabIndex = 1
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(890, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(64, 25)
        Me.pnlBotonesExpander.TabIndex = 0
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Cobranza.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(34, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 1
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Cobranza.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(7, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 0
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.grpCliente)
        Me.pnlFiltros.Controls.Add(Me.Panel1)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 85)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(954, 159)
        Me.pnlFiltros.TabIndex = 2
        Me.pnlFiltros.TabStop = False
        '
        'grpCliente
        '
        Me.grpCliente.Controls.Add(Me.btnFiltroCliente)
        Me.grpCliente.Controls.Add(Me.grdFiltroCliente)
        Me.grpCliente.Location = New System.Drawing.Point(341, 16)
        Me.grpCliente.Name = "grpCliente"
        Me.grpCliente.Size = New System.Drawing.Size(198, 137)
        Me.grpCliente.TabIndex = 2
        Me.grpCliente.TabStop = False
        Me.grpCliente.Text = "Cliente"
        '
        'btnFiltroCliente
        '
        Me.btnFiltroCliente.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnFiltroCliente.Location = New System.Drawing.Point(170, 14)
        Me.btnFiltroCliente.Name = "btnFiltroCliente"
        Me.btnFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnFiltroCliente.TabIndex = 1
        Me.btnFiltroCliente.UseVisualStyleBackColor = True
        '
        'grdFiltroCliente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroCliente.DisplayLayout.Appearance = Appearance1
        Me.grdFiltroCliente.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdFiltroCliente.Location = New System.Drawing.Point(3, 39)
        Me.grdFiltroCliente.Name = "grdFiltroCliente"
        Me.grdFiltroCliente.Size = New System.Drawing.Size(192, 95)
        Me.grdFiltroCliente.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grpFiltrosRecibidos)
        Me.Panel1.Controls.Add(Me.grpFiltroCedis)
        Me.Panel1.Controls.Add(Me.grpFiltroEntregados)
        Me.Panel1.Controls.Add(Me.grpFiltroFecha)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(572, 140)
        Me.Panel1.TabIndex = 1
        '
        'grpFiltrosRecibidos
        '
        Me.grpFiltrosRecibidos.Controls.Add(Me.chkRecibidos)
        Me.grpFiltrosRecibidos.Controls.Add(Me.chkPendientesPorRecibir)
        Me.grpFiltrosRecibidos.Location = New System.Drawing.Point(179, 69)
        Me.grpFiltrosRecibidos.Name = "grpFiltrosRecibidos"
        Me.grpFiltrosRecibidos.Size = New System.Drawing.Size(154, 67)
        Me.grpFiltrosRecibidos.TabIndex = 1
        Me.grpFiltrosRecibidos.TabStop = False
        Me.grpFiltrosRecibidos.Text = "Recibidos"
        '
        'chkRecibidos
        '
        Me.chkRecibidos.AutoSize = True
        Me.chkRecibidos.Location = New System.Drawing.Point(7, 43)
        Me.chkRecibidos.Name = "chkRecibidos"
        Me.chkRecibidos.Size = New System.Drawing.Size(73, 17)
        Me.chkRecibidos.TabIndex = 2
        Me.chkRecibidos.Text = "Recibidos"
        Me.chkRecibidos.UseVisualStyleBackColor = True
        '
        'chkPendientesPorRecibir
        '
        Me.chkPendientesPorRecibir.AutoSize = True
        Me.chkPendientesPorRecibir.Location = New System.Drawing.Point(7, 20)
        Me.chkPendientesPorRecibir.Name = "chkPendientesPorRecibir"
        Me.chkPendientesPorRecibir.Size = New System.Drawing.Size(128, 17)
        Me.chkPendientesPorRecibir.TabIndex = 0
        Me.chkPendientesPorRecibir.Text = "Pendientes por recibir"
        Me.chkPendientesPorRecibir.UseVisualStyleBackColor = True
        '
        'grpFiltroEntregados
        '
        Me.grpFiltroEntregados.Controls.Add(Me.chkEntregados)
        Me.grpFiltroEntregados.Controls.Add(Me.chkPendientesPorEntregar)
        Me.grpFiltroEntregados.Location = New System.Drawing.Point(179, 0)
        Me.grpFiltroEntregados.Name = "grpFiltroEntregados"
        Me.grpFiltroEntregados.Size = New System.Drawing.Size(154, 67)
        Me.grpFiltroEntregados.TabIndex = 0
        Me.grpFiltroEntregados.TabStop = False
        Me.grpFiltroEntregados.Text = "Entregados"
        '
        'chkEntregados
        '
        Me.chkEntregados.AutoSize = True
        Me.chkEntregados.Location = New System.Drawing.Point(6, 41)
        Me.chkEntregados.Name = "chkEntregados"
        Me.chkEntregados.Size = New System.Drawing.Size(80, 17)
        Me.chkEntregados.TabIndex = 1
        Me.chkEntregados.Text = "Entregados"
        Me.chkEntregados.UseVisualStyleBackColor = True
        '
        'chkPendientesPorEntregar
        '
        Me.chkPendientesPorEntregar.AutoSize = True
        Me.chkPendientesPorEntregar.Location = New System.Drawing.Point(6, 18)
        Me.chkPendientesPorEntregar.Name = "chkPendientesPorEntregar"
        Me.chkPendientesPorEntregar.Size = New System.Drawing.Size(139, 17)
        Me.chkPendientesPorEntregar.TabIndex = 0
        Me.chkPendientesPorEntregar.Text = "Pendientes por entregar"
        Me.chkPendientesPorEntregar.UseVisualStyleBackColor = True
        '
        'grpFiltroFecha
        '
        Me.grpFiltroFecha.Controls.Add(Me.dtpFechaFin)
        Me.grpFiltroFecha.Controls.Add(Me.lblAl)
        Me.grpFiltroFecha.Controls.Add(Me.dtpFechaInicio)
        Me.grpFiltroFecha.Controls.Add(Me.lblDel)
        Me.grpFiltroFecha.Location = New System.Drawing.Point(3, 58)
        Me.grpFiltroFecha.Name = "grpFiltroFecha"
        Me.grpFiltroFecha.Size = New System.Drawing.Size(170, 78)
        Me.grpFiltroFecha.TabIndex = 0
        Me.grpFiltroFecha.TabStop = False
        Me.grpFiltroFecha.Text = "Fecha Captura"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(41, 44)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(123, 20)
        Me.dtpFechaFin.TabIndex = 3
        Me.dtpFechaFin.Value = New Date(2020, 1, 20, 9, 55, 14, 0)
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Location = New System.Drawing.Point(9, 50)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(19, 13)
        Me.lblAl.TabIndex = 2
        Me.lblAl.Text = "Al:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(41, 18)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(123, 20)
        Me.dtpFechaInicio.TabIndex = 1
        Me.dtpFechaInicio.Value = New Date(2020, 1, 20, 0, 0, 0, 0)
        '
        'lblDel
        '
        Me.lblDel.AutoSize = True
        Me.lblDel.Location = New System.Drawing.Point(9, 24)
        Me.lblDel.Name = "lblDel"
        Me.lblDel.Size = New System.Drawing.Size(26, 13)
        Me.lblDel.TabIndex = 0
        Me.lblDel.Text = "Del:"
        '
        'pnlPieDePagina
        '
        Me.pnlPieDePagina.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPieDePagina.Controls.Add(Me.pnlRecuento)
        Me.pnlPieDePagina.Controls.Add(Me.pnlAcciones)
        Me.pnlPieDePagina.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPieDePagina.Location = New System.Drawing.Point(0, 483)
        Me.pnlPieDePagina.Name = "pnlPieDePagina"
        Me.pnlPieDePagina.Size = New System.Drawing.Size(954, 58)
        Me.pnlPieDePagina.TabIndex = 3
        '
        'pnlRecuento
        '
        Me.pnlRecuento.Controls.Add(Me.lblRegistros)
        Me.pnlRecuento.Controls.Add(Me.lblRecuentoRegistros)
        Me.pnlRecuento.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRecuento.Location = New System.Drawing.Point(0, 0)
        Me.pnlRecuento.Name = "pnlRecuento"
        Me.pnlRecuento.Size = New System.Drawing.Size(142, 58)
        Me.pnlRecuento.TabIndex = 1
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(28, 28)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 24)
        Me.lblRegistros.TabIndex = 134
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecuentoRegistros
        '
        Me.lblRecuentoRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecuentoRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRecuentoRegistros.Location = New System.Drawing.Point(28, 7)
        Me.lblRecuentoRegistros.Name = "lblRecuentoRegistros"
        Me.lblRecuentoRegistros.Size = New System.Drawing.Size(86, 24)
        Me.lblRecuentoRegistros.TabIndex = 133
        Me.lblRecuentoRegistros.Text = "Registros"
        Me.lblRecuentoRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblSalir)
        Me.pnlAcciones.Controls.Add(Me.lblMostrar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(842, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(112, 58)
        Me.pnlAcciones.TabIndex = 0
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(72, 42)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(27, 13)
        Me.lblSalir.TabIndex = 3
        Me.lblSalir.Text = "Salir"
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(11, 41)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 2
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(63, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(37, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Cobranza.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(14, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'grdContenedor
        '
        Me.grdContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdContenedor.Location = New System.Drawing.Point(0, 244)
        Me.grdContenedor.MainView = Me.grdDatos
        Me.grdContenedor.Name = "grdContenedor"
        Me.grdContenedor.Size = New System.Drawing.Size(954, 239)
        Me.grdContenedor.TabIndex = 4
        Me.grdContenedor.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdDatos})
        '
        'grdDatos
        '
        Me.grdDatos.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatos.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdDatos.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdDatos.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdDatos.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdDatos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdDatos.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdDatos.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdDatos.GridControl = Me.grdContenedor
        Me.grdDatos.IndicatorWidth = 30
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDatos.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDatos.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDatos.OptionsSelection.MultiSelect = True
        Me.grdDatos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdDatos.OptionsView.ShowAutoFilterRow = True
        Me.grdDatos.OptionsView.ShowFooter = True
        '
        'grpFiltroCedis
        '
        Me.grpFiltroCedis.Controls.Add(Me.cboCedis)
        Me.grpFiltroCedis.Location = New System.Drawing.Point(3, 0)
        Me.grpFiltroCedis.Name = "grpFiltroCedis"
        Me.grpFiltroCedis.Size = New System.Drawing.Size(170, 56)
        Me.grpFiltroCedis.TabIndex = 0
        Me.grpFiltroCedis.TabStop = False
        Me.grpFiltroCedis.Text = "Cedis"
        '
        'cboCedis
        '
        Me.cboCedis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCedis.FormattingEnabled = True
        Me.cboCedis.Location = New System.Drawing.Point(6, 19)
        Me.cboCedis.Name = "cboCedis"
        Me.cboCedis.Size = New System.Drawing.Size(158, 21)
        Me.cboCedis.TabIndex = 3
        '
        'EntregaYRecepcionDeDocumentosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 541)
        Me.Controls.Add(Me.grdContenedor)
        Me.Controls.Add(Me.pnlPieDePagina)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEncabezadoExpander)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "EntregaYRecepcionDeDocumentosForm"
        Me.Text = "Entrega y recepción de documentos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlEncabezadoExpander.ResumeLayout(False)
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.grpCliente.ResumeLayout(False)
        CType(Me.grdFiltroCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.grpFiltrosRecibidos.ResumeLayout(False)
        Me.grpFiltrosRecibidos.PerformLayout()
        Me.grpFiltroEntregados.ResumeLayout(False)
        Me.grpFiltroEntregados.PerformLayout()
        Me.grpFiltroFecha.ResumeLayout(False)
        Me.grpFiltroFecha.PerformLayout()
        Me.pnlPieDePagina.ResumeLayout(False)
        Me.pnlRecuento.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdContenedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltroCedis.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents pnlYuyin As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlEncabezadoExpander As Windows.Forms.Panel
    Friend WithEvents pnlBotonesExpander As Windows.Forms.Panel
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents pnlFiltros As Windows.Forms.GroupBox
    Friend WithEvents grpFiltroFecha As Windows.Forms.GroupBox
    Friend WithEvents grpCliente As Windows.Forms.GroupBox
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents grpFiltrosRecibidos As Windows.Forms.GroupBox
    Friend WithEvents grpFiltroEntregados As Windows.Forms.GroupBox
    Friend WithEvents grdFiltroCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblDel As Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As Windows.Forms.DateTimePicker
    Friend WithEvents chkRecibidos As Windows.Forms.CheckBox
    Friend WithEvents chkPendientesPorRecibir As Windows.Forms.CheckBox
    Friend WithEvents chkEntregados As Windows.Forms.CheckBox
    Friend WithEvents chkPendientesPorEntregar As Windows.Forms.CheckBox
    Friend WithEvents dtpFechaFin As Windows.Forms.DateTimePicker
    Friend WithEvents lblAl As Windows.Forms.Label
    Friend WithEvents pnlPieDePagina As Windows.Forms.Panel
    Friend WithEvents pnlAcciones As Windows.Forms.Panel
    Friend WithEvents lblSalir As Windows.Forms.Label
    Friend WithEvents lblMostrar As Windows.Forms.Label
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents pnlRecuento As Windows.Forms.Panel
    Friend WithEvents lblRegistros As Windows.Forms.Label
    Friend WithEvents lblRecuentoRegistros As Windows.Forms.Label
    Friend WithEvents grdContenedor As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdDatos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnFiltroCliente As Windows.Forms.Button
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents btnExportarExcel As Windows.Forms.Button
    Friend WithEvents grpFiltroCedis As Windows.Forms.GroupBox
    Friend WithEvents cboCedis As Windows.Forms.ComboBox
End Class
