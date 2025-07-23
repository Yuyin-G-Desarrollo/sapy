<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevolucionCliente_Reportes_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_Reportes_Form))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlContenedorPrincipal = New System.Windows.Forms.Panel()
        Me.grdDevolucionesClientes = New DevExpress.XtraGrid.GridControl()
        Me.bgvDevolucionesClientes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Seleccionar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OTSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Agente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.STATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoOT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrdenCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaEntregaProgramacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaPreparacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Confirmados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PorConfirmar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cancelados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UsuarioCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UsuarioModifico = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaModificacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DiasFaltantes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MotivoCancelacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EstatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Observaciones = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCitaEntrega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HoraCita = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cmbUCCorrida = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbUCNave = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpbTipoDevolucion = New System.Windows.Forms.GroupBox()
        Me.rdbMenudeo = New System.Windows.Forms.RadioButton()
        Me.rdbMayoreo = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btbLimpiarFiltroDefecto = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdDefecto = New DevExpress.XtraGrid.GridControl()
        Me.bgvDefecto = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnDefectos = New System.Windows.Forms.Button()
        Me.grpbTipoReporte = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rdbRepGeneral = New System.Windows.Forms.RadioButton()
        Me.rdbRepCliente = New System.Windows.Forms.RadioButton()
        Me.rdbRepDefecto = New System.Windows.Forms.RadioButton()
        Me.rdbRepEnviosNave = New System.Windows.Forms.RadioButton()
        Me.rdbRepNaveDetallado = New System.Windows.Forms.RadioButton()
        Me.rdbRepNaveResumen = New System.Windows.Forms.RadioButton()
        Me.gboxModelo = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarModelo = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdModelo = New DevExpress.XtraGrid.GridControl()
        Me.bgvModelo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnModelo = New System.Windows.Forms.Button()
        Me.gboxPiel = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarPiel = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.grdPiel = New DevExpress.XtraGrid.GridControl()
        Me.bgvPiel = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnPiel = New System.Windows.Forms.Button()
        Me.gboxColor = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarColor = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.grdColor = New DevExpress.XtraGrid.GridControl()
        Me.bgvColor = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.gboxCliente = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdCliente = New DevExpress.XtraGrid.GridControl()
        Me.bgvCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.gboxColeccion = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarColeccion = New System.Windows.Forms.Button()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.grdColeccion = New DevExpress.XtraGrid.GridControl()
        Me.bgvColeccion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnColeccion = New System.Windows.Forms.Button()
        Me.grpbFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel14.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlContenedorPrincipal.SuspendLayout()
        CType(Me.grdDevolucionesClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvDevolucionesClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.cmbUCCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUCNave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbTipoDevolucion.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdDefecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvDefecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbTipoReporte.SuspendLayout()
        Me.gboxModelo.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxPiel.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.grdPiel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvPiel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxColor.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.grdColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxCliente.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxColeccion.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pnlEncabezado)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1351, 57)
        Me.pnlTitulo.TabIndex = 81
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel5)
        Me.pnlEncabezado.Controls.Add(Me.Panel14)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1283, 57)
        Me.pnlEncabezado.TabIndex = 47
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnImprimir)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(69, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(69, 57)
        Me.Panel5.TabIndex = 214
        '
        'btnImprimir
        '
        Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.Image = Global.Almacen.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimir.Location = New System.Drawing.Point(16, 6)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 100
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(13, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "Imprimir"
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Label40)
        Me.Panel14.Controls.Add(Me.btnExportar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(69, 57)
        Me.Panel14.TabIndex = 213
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label40.Location = New System.Drawing.Point(10, 35)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(46, 13)
        Me.Label40.TabIndex = 91
        Me.Label40.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_321
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(18, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 92
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1057, 15)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(220, 20)
        Me.lblTitulo.TabIndex = 47
        Me.lblTitulo.Text = "Reportes de Devoluciones"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.BackColor = System.Drawing.Color.White
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1283, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 57)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.Label31)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 508)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1351, 61)
        Me.pnlPie.TabIndex = 82
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(1114, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 162
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'Label31
        '
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(1120, 15)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(102, 13)
        Me.Label31.TabIndex = 161
        Me.Label31.Text = "Última Actualización"
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(10, 10)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(79, 16)
        Me.lblClientes.TabIndex = 120
        Me.lblClientes.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(10, 31)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(71, 18)
        Me.lblTotalRegistros.TabIndex = 119
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Label6)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1247, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(104, 61)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(12, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(16, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 94
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(64, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(63, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlContenedorPrincipal)
        Me.pnlContenedor.Controls.Add(Me.Panel1)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 57)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1351, 451)
        Me.pnlContenedor.TabIndex = 83
        '
        'pnlContenedorPrincipal
        '
        Me.pnlContenedorPrincipal.Controls.Add(Me.grdDevolucionesClientes)
        Me.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedorPrincipal.Location = New System.Drawing.Point(0, 208)
        Me.pnlContenedorPrincipal.Name = "pnlContenedorPrincipal"
        Me.pnlContenedorPrincipal.Size = New System.Drawing.Size(1351, 243)
        Me.pnlContenedorPrincipal.TabIndex = 2
        '
        'grdDevolucionesClientes
        '
        Me.grdDevolucionesClientes.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdDevolucionesClientes.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdDevolucionesClientes.Location = New System.Drawing.Point(0, 0)
        Me.grdDevolucionesClientes.MainView = Me.bgvDevolucionesClientes
        Me.grdDevolucionesClientes.Name = "grdDevolucionesClientes"
        Me.grdDevolucionesClientes.Size = New System.Drawing.Size(1351, 243)
        Me.grdDevolucionesClientes.TabIndex = 3
        Me.grdDevolucionesClientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvDevolucionesClientes, Me.grdDetallesOT, Me.GridView6})
        '
        'bgvDevolucionesClientes
        '
        Me.bgvDevolucionesClientes.GridControl = Me.grdDevolucionesClientes
        Me.bgvDevolucionesClientes.Name = "bgvDevolucionesClientes"
        Me.bgvDevolucionesClientes.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvDevolucionesClientes.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvDevolucionesClientes.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.bgvDevolucionesClientes.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvDevolucionesClientes.OptionsSelection.MultiSelect = True
        Me.bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = False
        Me.bgvDevolucionesClientes.OptionsView.ShowAutoFilterRow = True
        Me.bgvDevolucionesClientes.OptionsView.ShowFooter = True
        '
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdDevolucionesClientes
        Me.grdDetallesOT.Name = "grdDetallesOT"
        Me.grdDetallesOT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDetallesOT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdDetallesOT.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdDetallesOT.OptionsPrint.AllowMultilineHeaders = True
        Me.grdDetallesOT.OptionsSelection.MultiSelect = True
        Me.grdDetallesOT.OptionsView.ColumnAutoWidth = False
        Me.grdDetallesOT.OptionsView.ShowAutoFilterRow = True
        Me.grdDetallesOT.OptionsView.ShowFooter = True
        '
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView6.GridControl = Me.grdDevolucionesClientes
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView6.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView6.OptionsSelection.MultiSelect = True
        Me.GridView6.OptionsView.ColumnAutoWidth = False
        Me.GridView6.OptionsView.ShowAutoFilterRow = True
        Me.GridView6.OptionsView.ShowFooter = True
        '
        'Seleccionar
        '
        Me.Seleccionar.Caption = """"
        Me.Seleccionar.FieldName = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Visible = True
        Me.Seleccionar.VisibleIndex = 0
        Me.Seleccionar.Width = 35
        '
        'OT
        '
        Me.OT.Caption = "OT"
        Me.OT.FieldName = "OT"
        Me.OT.Name = "OT"
        Me.OT.OptionsColumn.AllowEdit = False
        Me.OT.Visible = True
        Me.OT.VisibleIndex = 1
        Me.OT.Width = 70
        '
        'OTSICY
        '
        Me.OTSICY.Caption = "OTSICY"
        Me.OTSICY.FieldName = "OTSICY"
        Me.OTSICY.Name = "OTSICY"
        Me.OTSICY.OptionsColumn.AllowEdit = False
        Me.OTSICY.Visible = True
        Me.OTSICY.VisibleIndex = 2
        Me.OTSICY.Width = 70
        '
        'Cliente
        '
        Me.Cliente.Caption = "Cliente"
        Me.Cliente.FieldName = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OptionsColumn.AllowEdit = False
        Me.Cliente.Visible = True
        Me.Cliente.VisibleIndex = 3
        Me.Cliente.Width = 220
        '
        'Agente
        '
        Me.Agente.Caption = "Agente"
        Me.Agente.FieldName = "Agente"
        Me.Agente.Name = "Agente"
        Me.Agente.OptionsColumn.AllowEdit = False
        Me.Agente.Visible = True
        Me.Agente.VisibleIndex = 4
        Me.Agente.Width = 80
        '
        'STATUS
        '
        Me.STATUS.Caption = "STATUS"
        Me.STATUS.FieldName = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.OptionsColumn.AllowEdit = False
        Me.STATUS.Visible = True
        Me.STATUS.VisibleIndex = 5
        Me.STATUS.Width = 90
        '
        'TipoOT
        '
        Me.TipoOT.Caption = "Tipo OT"
        Me.TipoOT.FieldName = "TipoOT"
        Me.TipoOT.Name = "TipoOT"
        Me.TipoOT.OptionsColumn.AllowEdit = False
        Me.TipoOT.Visible = True
        Me.TipoOT.VisibleIndex = 6
        Me.TipoOT.Width = 70
        '
        'PedidoSAY
        '
        Me.PedidoSAY.Caption = "Pedido SAY"
        Me.PedidoSAY.FieldName = "PedidoSAY"
        Me.PedidoSAY.Name = "PedidoSAY"
        Me.PedidoSAY.OptionsColumn.AllowEdit = False
        Me.PedidoSAY.Visible = True
        Me.PedidoSAY.VisibleIndex = 7
        Me.PedidoSAY.Width = 80
        '
        'PedidoSICY
        '
        Me.PedidoSICY.Caption = "Pedido SICY"
        Me.PedidoSICY.FieldName = "PedidoSICY"
        Me.PedidoSICY.Name = "PedidoSICY"
        Me.PedidoSICY.OptionsColumn.AllowEdit = False
        Me.PedidoSICY.Visible = True
        Me.PedidoSICY.VisibleIndex = 8
        Me.PedidoSICY.Width = 80
        '
        'OrdenCliente
        '
        Me.OrdenCliente.Caption = "Orden Cliente"
        Me.OrdenCliente.FieldName = "OrdenCliente"
        Me.OrdenCliente.Name = "OrdenCliente"
        Me.OrdenCliente.OptionsColumn.AllowEdit = False
        Me.OrdenCliente.Visible = True
        Me.OrdenCliente.VisibleIndex = 9
        Me.OrdenCliente.Width = 90
        '
        'FechaEntregaProgramacion
        '
        Me.FechaEntregaProgramacion.Caption = "Fecha Entrega Programación"
        Me.FechaEntregaProgramacion.FieldName = "FechaEntregaProgramacion"
        Me.FechaEntregaProgramacion.Name = "FechaEntregaProgramacion"
        Me.FechaEntregaProgramacion.OptionsColumn.AllowEdit = False
        Me.FechaEntregaProgramacion.Visible = True
        Me.FechaEntregaProgramacion.VisibleIndex = 10
        Me.FechaEntregaProgramacion.Width = 120
        '
        'FechaPreparacion
        '
        Me.FechaPreparacion.Caption = "Fecha Preparación"
        Me.FechaPreparacion.FieldName = "FechaPreparacion"
        Me.FechaPreparacion.Name = "FechaPreparacion"
        Me.FechaPreparacion.OptionsColumn.AllowEdit = False
        Me.FechaPreparacion.Visible = True
        Me.FechaPreparacion.VisibleIndex = 11
        Me.FechaPreparacion.Width = 120
        '
        'Cantidad
        '
        Me.Cantidad.Caption = "Cantidad"
        Me.Cantidad.FieldName = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.OptionsColumn.AllowEdit = False
        Me.Cantidad.Visible = True
        Me.Cantidad.VisibleIndex = 12
        Me.Cantidad.Width = 80
        '
        'Confirmados
        '
        Me.Confirmados.Caption = "Confirmados"
        Me.Confirmados.FieldName = "Confirmados"
        Me.Confirmados.Name = "Confirmados"
        Me.Confirmados.OptionsColumn.AllowEdit = False
        Me.Confirmados.Visible = True
        Me.Confirmados.VisibleIndex = 13
        Me.Confirmados.Width = 80
        '
        'PorConfirmar
        '
        Me.PorConfirmar.Caption = "Por Confirmar"
        Me.PorConfirmar.FieldName = "PorConfirmar"
        Me.PorConfirmar.Name = "PorConfirmar"
        Me.PorConfirmar.OptionsColumn.AllowEdit = False
        Me.PorConfirmar.Visible = True
        Me.PorConfirmar.VisibleIndex = 14
        Me.PorConfirmar.Width = 90
        '
        'Cancelados
        '
        Me.Cancelados.Caption = "Cancelados"
        Me.Cancelados.FieldName = "Cancelados"
        Me.Cancelados.Name = "Cancelados"
        Me.Cancelados.OptionsColumn.AllowEdit = False
        Me.Cancelados.Visible = True
        Me.Cancelados.VisibleIndex = 15
        Me.Cancelados.Width = 80
        '
        'UsuarioCaptura
        '
        Me.UsuarioCaptura.Caption = "Usuario Captura"
        Me.UsuarioCaptura.FieldName = "UsuarioCaptura"
        Me.UsuarioCaptura.Name = "UsuarioCaptura"
        Me.UsuarioCaptura.OptionsColumn.AllowEdit = False
        Me.UsuarioCaptura.Visible = True
        Me.UsuarioCaptura.VisibleIndex = 16
        Me.UsuarioCaptura.Width = 90
        '
        'FechaCaptura
        '
        Me.FechaCaptura.Caption = "Fecha Captura"
        Me.FechaCaptura.FieldName = "FechaCaptura"
        Me.FechaCaptura.Name = "FechaCaptura"
        Me.FechaCaptura.OptionsColumn.AllowEdit = False
        Me.FechaCaptura.Visible = True
        Me.FechaCaptura.VisibleIndex = 17
        Me.FechaCaptura.Width = 120
        '
        'Cita
        '
        Me.Cita.Caption = "Cita"
        Me.Cita.FieldName = "Cita"
        Me.Cita.Name = "Cita"
        Me.Cita.OptionsColumn.AllowEdit = False
        Me.Cita.Visible = True
        Me.Cita.VisibleIndex = 18
        Me.Cita.Width = 50
        '
        'UsuarioModifico
        '
        Me.UsuarioModifico.Caption = "Usuario Modifico"
        Me.UsuarioModifico.FieldName = "UsuarioModifico"
        Me.UsuarioModifico.Name = "UsuarioModifico"
        Me.UsuarioModifico.OptionsColumn.AllowEdit = False
        Me.UsuarioModifico.Visible = True
        Me.UsuarioModifico.VisibleIndex = 19
        Me.UsuarioModifico.Width = 90
        '
        'FechaModificacion
        '
        Me.FechaModificacion.Caption = "Fecha Modificación"
        Me.FechaModificacion.FieldName = "FechaModificacion"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.OptionsColumn.AllowEdit = False
        Me.FechaModificacion.Visible = True
        Me.FechaModificacion.VisibleIndex = 20
        Me.FechaModificacion.Width = 120
        '
        'DiasFaltantes
        '
        Me.DiasFaltantes.Caption = "Dias Faltantes"
        Me.DiasFaltantes.FieldName = "DiasFaltantes"
        Me.DiasFaltantes.Name = "DiasFaltantes"
        Me.DiasFaltantes.OptionsColumn.AllowEdit = False
        Me.DiasFaltantes.Visible = True
        Me.DiasFaltantes.VisibleIndex = 21
        Me.DiasFaltantes.Width = 90
        '
        'BE
        '
        Me.BE.Caption = "BE"
        Me.BE.FieldName = "BE"
        Me.BE.Name = "BE"
        Me.BE.OptionsColumn.AllowEdit = False
        Me.BE.Visible = True
        Me.BE.VisibleIndex = 22
        Me.BE.Width = 50
        '
        'MotivoCancelacion
        '
        Me.MotivoCancelacion.Caption = "Motivo Cancelación"
        Me.MotivoCancelacion.FieldName = "MotivoCancelacion"
        Me.MotivoCancelacion.Name = "MotivoCancelacion"
        Me.MotivoCancelacion.OptionsColumn.AllowEdit = False
        Me.MotivoCancelacion.Visible = True
        Me.MotivoCancelacion.VisibleIndex = 23
        Me.MotivoCancelacion.Width = 100
        '
        'EstatusID
        '
        Me.EstatusID.Caption = "EstatusID"
        Me.EstatusID.FieldName = "EstatusID"
        Me.EstatusID.Name = "EstatusID"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "ClaveCitaEntrega"
        Me.GridColumn2.FieldName = "ClaveCitaEntrega"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 24
        '
        'Observaciones
        '
        Me.Observaciones.Caption = "GridColumn3"
        Me.Observaciones.FieldName = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Visible = True
        Me.Observaciones.VisibleIndex = 25
        '
        'FechaCitaEntrega
        '
        Me.FechaCitaEntrega.Caption = "FechaCitaEntrega"
        Me.FechaCitaEntrega.FieldName = "FechaCitaEntrega"
        Me.FechaCitaEntrega.Name = "FechaCitaEntrega"
        Me.FechaCitaEntrega.Visible = True
        Me.FechaCitaEntrega.VisibleIndex = 26
        '
        'HoraCita
        '
        Me.HoraCita.Caption = "HoraCita"
        Me.HoraCita.FieldName = "HoraCita"
        Me.HoraCita.Name = "HoraCita"
        Me.HoraCita.Visible = True
        Me.HoraCita.VisibleIndex = 27
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.grpbTipoDevolucion)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.grpbTipoReporte)
        Me.Panel1.Controls.Add(Me.gboxModelo)
        Me.Panel1.Controls.Add(Me.gboxPiel)
        Me.Panel1.Controls.Add(Me.gboxColor)
        Me.Panel1.Controls.Add(Me.gboxCliente)
        Me.Panel1.Controls.Add(Me.gboxColeccion)
        Me.Panel1.Controls.Add(Me.grpbFecha)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1351, 208)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtLote)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 143)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(218, 52)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(58, 19)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(143, 20)
        Me.txtLote.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 166
        Me.Label5.Text = "Lote"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmbUCCorrida)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.cmbUCNave)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Location = New System.Drawing.Point(904, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(439, 46)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'cmbUCCorrida
        '
        Me.cmbUCCorrida.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cmbUCCorrida.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbUCCorrida.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbUCCorrida.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbUCCorrida.CheckedListSettings.CheckBoxStyle = Infragistics.Win.CheckStyle.CheckBox
        Me.cmbUCCorrida.CheckedListSettings.EditorValueSource = Infragistics.Win.EditorWithComboValueSource.CheckedItems
        Me.cmbUCCorrida.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista
        Me.cmbUCCorrida.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbUCCorrida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUCCorrida.Location = New System.Drawing.Point(267, 14)
        Me.cmbUCCorrida.Name = "cmbUCCorrida"
        Me.cmbUCCorrida.Size = New System.Drawing.Size(155, 21)
        Me.cmbUCCorrida.TabIndex = 165
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "Corrida:"
        '
        'cmbUCNave
        '
        Me.cmbUCNave.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cmbUCNave.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbUCNave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbUCNave.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbUCNave.CheckedListSettings.CheckBoxStyle = Infragistics.Win.CheckStyle.CheckBox
        Me.cmbUCNave.CheckedListSettings.EditorValueSource = Infragistics.Win.EditorWithComboValueSource.CheckedItems
        Me.cmbUCNave.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.WindowsVista
        Me.cmbUCNave.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbUCNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUCNave.Location = New System.Drawing.Point(57, 14)
        Me.cmbUCNave.Name = "cmbUCNave"
        Me.cmbUCNave.Size = New System.Drawing.Size(155, 21)
        Me.cmbUCNave.TabIndex = 163
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Nave:"
        '
        'grpbTipoDevolucion
        '
        Me.grpbTipoDevolucion.Controls.Add(Me.rdbMenudeo)
        Me.grpbTipoDevolucion.Controls.Add(Me.rdbMayoreo)
        Me.grpbTipoDevolucion.Location = New System.Drawing.Point(7, 6)
        Me.grpbTipoDevolucion.Name = "grpbTipoDevolucion"
        Me.grpbTipoDevolucion.Size = New System.Drawing.Size(218, 46)
        Me.grpbTipoDevolucion.TabIndex = 166
        Me.grpbTipoDevolucion.TabStop = False
        Me.grpbTipoDevolucion.Text = "Tipo Devolución"
        '
        'rdbMenudeo
        '
        Me.rdbMenudeo.AutoSize = True
        Me.rdbMenudeo.Location = New System.Drawing.Point(121, 18)
        Me.rdbMenudeo.Name = "rdbMenudeo"
        Me.rdbMenudeo.Size = New System.Drawing.Size(70, 17)
        Me.rdbMenudeo.TabIndex = 70
        Me.rdbMenudeo.Text = "Menudeo"
        Me.rdbMenudeo.UseVisualStyleBackColor = True
        '
        'rdbMayoreo
        '
        Me.rdbMayoreo.AutoSize = True
        Me.rdbMayoreo.Checked = True
        Me.rdbMayoreo.Location = New System.Drawing.Point(12, 18)
        Me.rdbMayoreo.Name = "rdbMayoreo"
        Me.rdbMayoreo.Size = New System.Drawing.Size(66, 17)
        Me.rdbMayoreo.TabIndex = 69
        Me.rdbMayoreo.TabStop = True
        Me.rdbMayoreo.Text = "Mayoreo"
        Me.rdbMayoreo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btbLimpiarFiltroDefecto)
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Controls.Add(Me.btnDefectos)
        Me.GroupBox3.Location = New System.Drawing.Point(1157, 58)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(186, 137)
        Me.GroupBox3.TabIndex = 165
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Defecto"
        '
        'btbLimpiarFiltroDefecto
        '
        Me.btbLimpiarFiltroDefecto.Image = CType(resources.GetObject("btbLimpiarFiltroDefecto.Image"), System.Drawing.Image)
        Me.btbLimpiarFiltroDefecto.Location = New System.Drawing.Point(136, 11)
        Me.btbLimpiarFiltroDefecto.Name = "btbLimpiarFiltroDefecto"
        Me.btbLimpiarFiltroDefecto.Size = New System.Drawing.Size(22, 22)
        Me.btbLimpiarFiltroDefecto.TabIndex = 7
        Me.btbLimpiarFiltroDefecto.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdDefecto)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(180, 98)
        Me.Panel3.TabIndex = 2
        '
        'grdDefecto
        '
        Me.grdDefecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDefecto.Location = New System.Drawing.Point(0, 0)
        Me.grdDefecto.MainView = Me.bgvDefecto
        Me.grdDefecto.Name = "grdDefecto"
        Me.grdDefecto.Size = New System.Drawing.Size(180, 98)
        Me.grdDefecto.TabIndex = 1
        Me.grdDefecto.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvDefecto})
        '
        'bgvDefecto
        '
        Me.bgvDefecto.GridControl = Me.grdDefecto
        Me.bgvDefecto.Name = "bgvDefecto"
        Me.bgvDefecto.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvDefecto.OptionsView.ShowGroupPanel = False
        '
        'btnDefectos
        '
        Me.btnDefectos.Image = CType(resources.GetObject("btnDefectos.Image"), System.Drawing.Image)
        Me.btnDefectos.Location = New System.Drawing.Point(159, 11)
        Me.btnDefectos.Name = "btnDefectos"
        Me.btnDefectos.Size = New System.Drawing.Size(22, 22)
        Me.btnDefectos.TabIndex = 0
        Me.btnDefectos.UseVisualStyleBackColor = True
        '
        'grpbTipoReporte
        '
        Me.grpbTipoReporte.Controls.Add(Me.RadioButton1)
        Me.grpbTipoReporte.Controls.Add(Me.rdbRepGeneral)
        Me.grpbTipoReporte.Controls.Add(Me.rdbRepCliente)
        Me.grpbTipoReporte.Controls.Add(Me.rdbRepDefecto)
        Me.grpbTipoReporte.Controls.Add(Me.rdbRepEnviosNave)
        Me.grpbTipoReporte.Controls.Add(Me.rdbRepNaveDetallado)
        Me.grpbTipoReporte.Controls.Add(Me.rdbRepNaveResumen)
        Me.grpbTipoReporte.Location = New System.Drawing.Point(231, 7)
        Me.grpbTipoReporte.Name = "grpbTipoReporte"
        Me.grpbTipoReporte.Size = New System.Drawing.Size(668, 45)
        Me.grpbTipoReporte.TabIndex = 164
        Me.grpbTipoReporte.TabStop = False
        Me.grpbTipoReporte.Text = "Tipo De Reporte"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 15)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(70, 17)
        Me.RadioButton1.TabIndex = 162
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Detallado"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rdbRepGeneral
        '
        Me.rdbRepGeneral.AutoSize = True
        Me.rdbRepGeneral.Location = New System.Drawing.Point(92, 15)
        Me.rdbRepGeneral.Name = "rdbRepGeneral"
        Me.rdbRepGeneral.Size = New System.Drawing.Size(62, 17)
        Me.rdbRepGeneral.TabIndex = 156
        Me.rdbRepGeneral.Text = "General"
        Me.rdbRepGeneral.UseVisualStyleBackColor = True
        '
        'rdbRepCliente
        '
        Me.rdbRepCliente.AutoSize = True
        Me.rdbRepCliente.Location = New System.Drawing.Point(171, 15)
        Me.rdbRepCliente.Name = "rdbRepCliente"
        Me.rdbRepCliente.Size = New System.Drawing.Size(57, 17)
        Me.rdbRepCliente.TabIndex = 157
        Me.rdbRepCliente.Text = "Cliente"
        Me.rdbRepCliente.UseVisualStyleBackColor = True
        '
        'rdbRepDefecto
        '
        Me.rdbRepDefecto.AutoSize = True
        Me.rdbRepDefecto.Location = New System.Drawing.Point(258, 15)
        Me.rdbRepDefecto.Name = "rdbRepDefecto"
        Me.rdbRepDefecto.Size = New System.Drawing.Size(63, 17)
        Me.rdbRepDefecto.TabIndex = 158
        Me.rdbRepDefecto.Text = "Defecto"
        Me.rdbRepDefecto.UseVisualStyleBackColor = True
        '
        'rdbRepEnviosNave
        '
        Me.rdbRepEnviosNave.AutoSize = True
        Me.rdbRepEnviosNave.Location = New System.Drawing.Point(562, 15)
        Me.rdbRepEnviosNave.Name = "rdbRepEnviosNave"
        Me.rdbRepEnviosNave.Size = New System.Drawing.Size(97, 17)
        Me.rdbRepEnviosNave.TabIndex = 161
        Me.rdbRepEnviosNave.Text = "Envíos a Nave"
        Me.rdbRepEnviosNave.UseVisualStyleBackColor = True
        '
        'rdbRepNaveDetallado
        '
        Me.rdbRepNaveDetallado.AutoSize = True
        Me.rdbRepNaveDetallado.Location = New System.Drawing.Point(344, 15)
        Me.rdbRepNaveDetallado.Name = "rdbRepNaveDetallado"
        Me.rdbRepNaveDetallado.Size = New System.Drawing.Size(99, 17)
        Me.rdbRepNaveDetallado.TabIndex = 159
        Me.rdbRepNaveDetallado.Text = "Nave Detallado"
        Me.rdbRepNaveDetallado.UseVisualStyleBackColor = True
        '
        'rdbRepNaveResumen
        '
        Me.rdbRepNaveResumen.AutoSize = True
        Me.rdbRepNaveResumen.Location = New System.Drawing.Point(457, 15)
        Me.rdbRepNaveResumen.Name = "rdbRepNaveResumen"
        Me.rdbRepNaveResumen.Size = New System.Drawing.Size(99, 17)
        Me.rdbRepNaveResumen.TabIndex = 160
        Me.rdbRepNaveResumen.Text = "Nave Resumen"
        Me.rdbRepNaveResumen.UseVisualStyleBackColor = True
        '
        'gboxModelo
        '
        Me.gboxModelo.Controls.Add(Me.btnLimpiarModelo)
        Me.gboxModelo.Controls.Add(Me.Panel4)
        Me.gboxModelo.Controls.Add(Me.btnModelo)
        Me.gboxModelo.Location = New System.Drawing.Point(803, 58)
        Me.gboxModelo.Name = "gboxModelo"
        Me.gboxModelo.Size = New System.Drawing.Size(96, 137)
        Me.gboxModelo.TabIndex = 152
        Me.gboxModelo.TabStop = False
        Me.gboxModelo.Text = "Modelo"
        '
        'btnLimpiarModelo
        '
        Me.btnLimpiarModelo.Image = CType(resources.GetObject("btnLimpiarModelo.Image"), System.Drawing.Image)
        Me.btnLimpiarModelo.Location = New System.Drawing.Point(41, 11)
        Me.btnLimpiarModelo.Name = "btnLimpiarModelo"
        Me.btnLimpiarModelo.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarModelo.TabIndex = 7
        Me.btnLimpiarModelo.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdModelo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 36)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 98)
        Me.Panel4.TabIndex = 2
        '
        'grdModelo
        '
        Me.grdModelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdModelo.Location = New System.Drawing.Point(0, 0)
        Me.grdModelo.MainView = Me.bgvModelo
        Me.grdModelo.Name = "grdModelo"
        Me.grdModelo.Size = New System.Drawing.Size(90, 98)
        Me.grdModelo.TabIndex = 1
        Me.grdModelo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvModelo})
        '
        'bgvModelo
        '
        Me.bgvModelo.GridControl = Me.grdModelo
        Me.bgvModelo.Name = "bgvModelo"
        Me.bgvModelo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvModelo.OptionsView.ShowGroupPanel = False
        '
        'btnModelo
        '
        Me.btnModelo.Image = CType(resources.GetObject("btnModelo.Image"), System.Drawing.Image)
        Me.btnModelo.Location = New System.Drawing.Point(65, 11)
        Me.btnModelo.Name = "btnModelo"
        Me.btnModelo.Size = New System.Drawing.Size(22, 22)
        Me.btnModelo.TabIndex = 0
        Me.btnModelo.UseVisualStyleBackColor = True
        '
        'gboxPiel
        '
        Me.gboxPiel.Controls.Add(Me.btnLimpiarPiel)
        Me.gboxPiel.Controls.Add(Me.Panel10)
        Me.gboxPiel.Controls.Add(Me.btnPiel)
        Me.gboxPiel.Location = New System.Drawing.Point(904, 58)
        Me.gboxPiel.Name = "gboxPiel"
        Me.gboxPiel.Size = New System.Drawing.Size(122, 137)
        Me.gboxPiel.TabIndex = 153
        Me.gboxPiel.TabStop = False
        Me.gboxPiel.Text = "Piel"
        '
        'btnLimpiarPiel
        '
        Me.btnLimpiarPiel.Image = CType(resources.GetObject("btnLimpiarPiel.Image"), System.Drawing.Image)
        Me.btnLimpiarPiel.Location = New System.Drawing.Point(68, 11)
        Me.btnLimpiarPiel.Name = "btnLimpiarPiel"
        Me.btnLimpiarPiel.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarPiel.TabIndex = 7
        Me.btnLimpiarPiel.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.grdPiel)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(3, 36)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(116, 98)
        Me.Panel10.TabIndex = 2
        '
        'grdPiel
        '
        Me.grdPiel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPiel.Location = New System.Drawing.Point(0, 0)
        Me.grdPiel.MainView = Me.bgvPiel
        Me.grdPiel.Name = "grdPiel"
        Me.grdPiel.Size = New System.Drawing.Size(116, 98)
        Me.grdPiel.TabIndex = 1
        Me.grdPiel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvPiel})
        '
        'bgvPiel
        '
        Me.bgvPiel.GridControl = Me.grdPiel
        Me.bgvPiel.Name = "bgvPiel"
        Me.bgvPiel.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvPiel.OptionsView.ShowGroupPanel = False
        '
        'btnPiel
        '
        Me.btnPiel.Image = CType(resources.GetObject("btnPiel.Image"), System.Drawing.Image)
        Me.btnPiel.Location = New System.Drawing.Point(91, 11)
        Me.btnPiel.Name = "btnPiel"
        Me.btnPiel.Size = New System.Drawing.Size(22, 22)
        Me.btnPiel.TabIndex = 0
        Me.btnPiel.UseVisualStyleBackColor = True
        '
        'gboxColor
        '
        Me.gboxColor.Controls.Add(Me.btnLimpiarColor)
        Me.gboxColor.Controls.Add(Me.Panel11)
        Me.gboxColor.Controls.Add(Me.btnColor)
        Me.gboxColor.Location = New System.Drawing.Point(1031, 58)
        Me.gboxColor.Name = "gboxColor"
        Me.gboxColor.Size = New System.Drawing.Size(119, 137)
        Me.gboxColor.TabIndex = 154
        Me.gboxColor.TabStop = False
        Me.gboxColor.Text = "Color"
        '
        'btnLimpiarColor
        '
        Me.btnLimpiarColor.Image = CType(resources.GetObject("btnLimpiarColor.Image"), System.Drawing.Image)
        Me.btnLimpiarColor.Location = New System.Drawing.Point(64, 11)
        Me.btnLimpiarColor.Name = "btnLimpiarColor"
        Me.btnLimpiarColor.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarColor.TabIndex = 7
        Me.btnLimpiarColor.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.grdColor)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel11.Location = New System.Drawing.Point(3, 36)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(113, 98)
        Me.Panel11.TabIndex = 2
        '
        'grdColor
        '
        Me.grdColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColor.Location = New System.Drawing.Point(0, 0)
        Me.grdColor.MainView = Me.bgvColor
        Me.grdColor.Name = "grdColor"
        Me.grdColor.Size = New System.Drawing.Size(113, 98)
        Me.grdColor.TabIndex = 1
        Me.grdColor.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvColor})
        '
        'bgvColor
        '
        Me.bgvColor.GridControl = Me.grdColor
        Me.bgvColor.Name = "bgvColor"
        Me.bgvColor.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvColor.OptionsView.ShowGroupPanel = False
        '
        'btnColor
        '
        Me.btnColor.Image = CType(resources.GetObject("btnColor.Image"), System.Drawing.Image)
        Me.btnColor.Location = New System.Drawing.Point(87, 11)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(22, 22)
        Me.btnColor.TabIndex = 0
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'gboxCliente
        '
        Me.gboxCliente.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.Panel7)
        Me.gboxCliente.Controls.Add(Me.btnCliente)
        Me.gboxCliente.Location = New System.Drawing.Point(231, 58)
        Me.gboxCliente.Name = "gboxCliente"
        Me.gboxCliente.Size = New System.Drawing.Size(322, 137)
        Me.gboxCliente.TabIndex = 150
        Me.gboxCliente.TabStop = False
        Me.gboxCliente.Text = "Cliente"
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(274, 10)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 6
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdCliente)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 36)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(316, 98)
        Me.Panel7.TabIndex = 2
        '
        'grdCliente
        '
        Me.grdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdCliente.MainView = Me.bgvCliente
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.Size = New System.Drawing.Size(316, 98)
        Me.grdCliente.TabIndex = 0
        Me.grdCliente.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvCliente})
        '
        'bgvCliente
        '
        Me.bgvCliente.GridControl = Me.grdCliente
        Me.bgvCliente.Name = "bgvCliente"
        Me.bgvCliente.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvCliente.OptionsView.ShowGroupPanel = False
        '
        'btnCliente
        '
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.Location = New System.Drawing.Point(298, 10)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnCliente.TabIndex = 0
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'gboxColeccion
        '
        Me.gboxColeccion.Controls.Add(Me.btnLimpiarColeccion)
        Me.gboxColeccion.Controls.Add(Me.Panel24)
        Me.gboxColeccion.Controls.Add(Me.btnColeccion)
        Me.gboxColeccion.Location = New System.Drawing.Point(558, 58)
        Me.gboxColeccion.Name = "gboxColeccion"
        Me.gboxColeccion.Size = New System.Drawing.Size(241, 137)
        Me.gboxColeccion.TabIndex = 151
        Me.gboxColeccion.TabStop = False
        Me.gboxColeccion.Text = "Colección"
        '
        'btnLimpiarColeccion
        '
        Me.btnLimpiarColeccion.Image = CType(resources.GetObject("btnLimpiarColeccion.Image"), System.Drawing.Image)
        Me.btnLimpiarColeccion.Location = New System.Drawing.Point(189, 11)
        Me.btnLimpiarColeccion.Name = "btnLimpiarColeccion"
        Me.btnLimpiarColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarColeccion.TabIndex = 7
        Me.btnLimpiarColeccion.UseVisualStyleBackColor = True
        '
        'Panel24
        '
        Me.Panel24.Controls.Add(Me.grdColeccion)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel24.Location = New System.Drawing.Point(3, 36)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(235, 98)
        Me.Panel24.TabIndex = 2
        '
        'grdColeccion
        '
        Me.grdColeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColeccion.Location = New System.Drawing.Point(0, 0)
        Me.grdColeccion.MainView = Me.bgvColeccion
        Me.grdColeccion.Name = "grdColeccion"
        Me.grdColeccion.Size = New System.Drawing.Size(235, 98)
        Me.grdColeccion.TabIndex = 1
        Me.grdColeccion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvColeccion})
        '
        'bgvColeccion
        '
        Me.bgvColeccion.GridControl = Me.grdColeccion
        Me.bgvColeccion.Name = "bgvColeccion"
        Me.bgvColeccion.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvColeccion.OptionsView.ShowGroupPanel = False
        '
        'btnColeccion
        '
        Me.btnColeccion.Image = CType(resources.GetObject("btnColeccion.Image"), System.Drawing.Image)
        Me.btnColeccion.Location = New System.Drawing.Point(213, 11)
        Me.btnColeccion.Name = "btnColeccion"
        Me.btnColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnColeccion.TabIndex = 0
        Me.btnColeccion.UseVisualStyleBackColor = True
        '
        'grpbFecha
        '
        Me.grpbFecha.Controls.Add(Me.dtpFechaFin)
        Me.grpbFecha.Controls.Add(Me.dtpFechaInicio)
        Me.grpbFecha.Controls.Add(Me.Label3)
        Me.grpbFecha.Controls.Add(Me.Label2)
        Me.grpbFecha.Location = New System.Drawing.Point(7, 58)
        Me.grpbFecha.Name = "grpbFecha"
        Me.grpbFecha.Size = New System.Drawing.Size(218, 85)
        Me.grpbFecha.TabIndex = 0
        Me.grpbFecha.TabStop = False
        Me.grpbFecha.Text = "Fecha"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(60, 54)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(141, 20)
        Me.dtpFechaFin.TabIndex = 68
        Me.dtpFechaFin.Value = New Date(2019, 2, 1, 0, 0, 0, 0)
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(58, 19)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(143, 20)
        Me.dtpFechaInicio.TabIndex = 67
        Me.dtpFechaInicio.Value = New Date(2019, 2, 1, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Al:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Del:"
        '
        'DevolucionCliente_Reportes_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1351, 569)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "DevolucionCliente_Reportes_Form"
        Me.Text = "Reportes de Devolución"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlContenedorPrincipal.ResumeLayout(False)
        CType(Me.grdDevolucionesClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvDevolucionesClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.cmbUCCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUCNave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbTipoDevolucion.ResumeLayout(False)
        Me.grpbTipoDevolucion.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdDefecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvDefecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbTipoReporte.ResumeLayout(False)
        Me.grpbTipoReporte.PerformLayout()
        Me.gboxModelo.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvModelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxPiel.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.grdPiel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvPiel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxColor.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        CType(Me.grdColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxCliente.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxColeccion.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbFecha.ResumeLayout(False)
        Me.grpbFecha.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlContenedorPrincipal As Panel
    Friend WithEvents grpbFecha As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label40 As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents gboxModelo As GroupBox
    Friend WithEvents btnLimpiarModelo As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnModelo As Button
    Friend WithEvents gboxPiel As GroupBox
    Friend WithEvents btnLimpiarPiel As Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents btnPiel As Button
    Friend WithEvents gboxColor As GroupBox
    Friend WithEvents btnLimpiarColor As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents btnColor As Button
    Friend WithEvents gboxCliente As GroupBox
    Friend WithEvents btnLimpiarFiltroCliente As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btnCliente As Button
    Friend WithEvents gboxColeccion As GroupBox
    Friend WithEvents btnLimpiarColeccion As Button
    Friend WithEvents Panel24 As Panel
    Friend WithEvents btnColeccion As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents rdbRepEnviosNave As RadioButton
    Friend WithEvents rdbRepNaveResumen As RadioButton
    Friend WithEvents rdbRepNaveDetallado As RadioButton
    Friend WithEvents rdbRepDefecto As RadioButton
    Friend WithEvents rdbRepCliente As RadioButton
    Friend WithEvents grpbTipoReporte As GroupBox
    Friend WithEvents cmbUCNave As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents grdCliente As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btbLimpiarFiltroDefecto As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdDefecto As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvDefecto As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnDefectos As Button
    Friend WithEvents grdModelo As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvModelo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdPiel As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvPiel As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdColor As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvColor As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdColeccion As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvColeccion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grpbTipoDevolucion As GroupBox
    Friend WithEvents rdbMenudeo As RadioButton
    Friend WithEvents rdbMayoreo As RadioButton
    Friend WithEvents cmbUCCorrida As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtLote As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents grdDevolucionesClientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvDevolucionesClientes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Seleccionar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OTSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Agente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents STATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoOT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrdenCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaEntregaProgramacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaPreparacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Confirmados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PorConfirmar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cancelados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UsuarioCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UsuarioModifico As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaModificacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DiasFaltantes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MotivoCancelacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EstatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Observaciones As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCitaEntrega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HoraCita As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblClientes As Label
    Friend WithEvents lblTotalRegistros As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents rdbRepGeneral As RadioButton
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Panel1 As Panel
End Class
