<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaPreciosFotoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPreciosFotoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.pnPBar = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pBar = New System.Windows.Forms.ProgressBar()
        Me.grdReporte = New DevExpress.XtraGrid.GridControl()
        Me.bgvReporte = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNumRegistros = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTextoUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.rdbListaCapturada = New System.Windows.Forms.RadioButton()
        Me.rdbListaCompleta = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiaArticulos = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gridArticulos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnArticulos = New System.Windows.Forms.Button()
        Me.Cliente = New System.Windows.Forms.GroupBox()
        Me.lblMensajeSinListaVentas = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFechaFinListaDato = New System.Windows.Forms.Label()
        Me.lblFechaFinLista = New System.Windows.Forms.Label()
        Me.lblFechaInicioLista_Dato = New System.Windows.Forms.Label()
        Me.lblListaVentas = New System.Windows.Forms.Label()
        Me.lblFechaInicioLista = New System.Windows.Forms.Label()
        Me.lblListaVenta = New System.Windows.Forms.Label()
        Me.cmbListaVentasCliente = New System.Windows.Forms.ComboBox()
        Me.lblEstatusListaPrecios = New System.Windows.Forms.Label()
        Me.cmbListaBase = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiaFamilias = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdFamiliaDeVentas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnFamilias = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarColecciones = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdColecciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnColecciones = New System.Windows.Forms.Button()
        Me.gboxCorrida = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdAgentes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cmbListaVentas = New System.Windows.Forms.ComboBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExportarConFoto = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlPrincipal.SuspendLayout()
        Me.pnPBar.SuspendLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gridArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cliente.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdFamiliaDeVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdColecciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxCorrida.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.pnPBar)
        Me.pnlPrincipal.Controls.Add(Me.grdReporte)
        Me.pnlPrincipal.Controls.Add(Me.pnlPie)
        Me.pnlPrincipal.Controls.Add(Me.pnlParametros)
        Me.pnlPrincipal.Controls.Add(Me.pnlEncabezado)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1259, 552)
        Me.pnlPrincipal.TabIndex = 2
        '
        'pnPBar
        '
        Me.pnPBar.BackColor = System.Drawing.SystemColors.Control
        Me.pnPBar.Controls.Add(Me.lblInfo)
        Me.pnPBar.Controls.Add(Me.pBar)
        Me.pnPBar.Location = New System.Drawing.Point(223, 430)
        Me.pnPBar.Name = "pnPBar"
        Me.pnPBar.Size = New System.Drawing.Size(601, 56)
        Me.pnPBar.TabIndex = 109
        Me.pnPBar.Visible = False
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(16, 7)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(43, 16)
        Me.lblInfo.TabIndex = 108
        Me.lblInfo.Text = "lblInfo"
        '
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(15, 24)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(564, 23)
        Me.pBar.TabIndex = 107
        '
        'grdReporte
        '
        Me.grdReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporte.Location = New System.Drawing.Point(0, 424)
        Me.grdReporte.MainView = Me.bgvReporte
        Me.grdReporte.Name = "grdReporte"
        Me.grdReporte.Size = New System.Drawing.Size(1259, 68)
        Me.grdReporte.TabIndex = 30
        Me.grdReporte.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvReporte})
        '
        'bgvReporte
        '
        Me.bgvReporte.GridControl = Me.grdReporte
        Me.bgvReporte.Name = "bgvReporte"
        Me.bgvReporte.OptionsBehavior.Editable = False
        Me.bgvReporte.OptionsCustomization.AllowColumnMoving = False
        Me.bgvReporte.OptionsCustomization.AllowFilter = False
        Me.bgvReporte.OptionsCustomization.AllowGroup = False
        Me.bgvReporte.OptionsCustomization.AllowSort = False
        Me.bgvReporte.OptionsMenu.EnableColumnMenu = False
        Me.bgvReporte.OptionsSelection.MultiSelect = True
        Me.bgvReporte.OptionsView.ColumnAutoWidth = False
        Me.bgvReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.bgvReporte.OptionsView.ShowDetailButtons = False
        Me.bgvReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvReporte.OptionsView.ShowGroupPanel = False
        Me.bgvReporte.OptionsView.ShowIndicator = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.lblNumRegistros)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualización)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 492)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1259, 60)
        Me.pnlPie.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(152, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Click en la FOTO para maximizarla."
        '
        'lblNumRegistros
        '
        Me.lblNumRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumRegistros.Location = New System.Drawing.Point(6, 31)
        Me.lblNumRegistros.Name = "lblNumRegistros"
        Me.lblNumRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblNumRegistros.TabIndex = 123
        Me.lblNumRegistros.Text = "0"
        Me.lblNumRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNumRegistros.Visible = False
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 32)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "Registros"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label9.Visible = False
        '
        'lblTextoUltimaActualizacion
        '
        Me.lblTextoUltimaActualizacion.AutoSize = True
        Me.lblTextoUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaActualizacion.Location = New System.Drawing.Point(909, 13)
        Me.lblTextoUltimaActualizacion.Name = "lblTextoUltimaActualizacion"
        Me.lblTextoUltimaActualizacion.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoUltimaActualizacion.TabIndex = 104
        Me.lblTextoUltimaActualizacion.Text = "Última actualización:"
        Me.lblTextoUltimaActualizacion.Visible = False
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(897, 30)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaUltimaActualización.TabIndex = 105
        Me.lblFechaUltimaActualización.Text = "-"
        Me.lblFechaUltimaActualización.Visible = False
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1109, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(150, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(62, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 2
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(17, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 2
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(66, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(22, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(107, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(106, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox4)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.Cliente)
        Me.pnlParametros.Controls.Add(Me.GroupBox3)
        Me.pnlParametros.Controls.Add(Me.GroupBox2)
        Me.pnlParametros.Controls.Add(Me.gboxCorrida)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1259, 365)
        Me.pnlParametros.TabIndex = 27
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox4.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox4.Controls.Add(Me.rdbListaCapturada)
        Me.GroupBox4.Controls.Add(Me.rdbListaCompleta)
        Me.GroupBox4.Location = New System.Drawing.Point(11, 160)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(395, 54)
        Me.GroupBox4.TabIndex = 109
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Filtro"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(276, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Al:"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(296, 27)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(80, 20)
        Me.dtpFechaFin.TabIndex = 3
        Me.dtpFechaFin.Value = New Date(2018, 7, 9, 0, 0, 0, 0)
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(179, 27)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(80, 20)
        Me.dtpFechaInicio.TabIndex = 2
        Me.dtpFechaInicio.Value = New Date(2018, 7, 1, 0, 0, 0, 0)
        '
        'rdbListaCapturada
        '
        Me.rdbListaCapturada.AutoSize = True
        Me.rdbListaCapturada.Location = New System.Drawing.Point(38, 28)
        Me.rdbListaCapturada.Name = "rdbListaCapturada"
        Me.rdbListaCapturada.Size = New System.Drawing.Size(142, 17)
        Me.rdbListaCapturada.TabIndex = 1
        Me.rdbListaCapturada.Text = "Pedidos Capturados Del:"
        Me.rdbListaCapturada.UseVisualStyleBackColor = True
        '
        'rdbListaCompleta
        '
        Me.rdbListaCompleta.AutoSize = True
        Me.rdbListaCompleta.Checked = True
        Me.rdbListaCompleta.Location = New System.Drawing.Point(38, 12)
        Me.rdbListaCompleta.Name = "rdbListaCompleta"
        Me.rdbListaCompleta.Size = New System.Drawing.Size(94, 17)
        Me.rdbListaCompleta.TabIndex = 0
        Me.rdbListaCompleta.TabStop = True
        Me.rdbListaCompleta.Text = "Lista Completa"
        Me.rdbListaCompleta.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLimpiaArticulos)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.btnArticulos)
        Me.GroupBox1.Location = New System.Drawing.Point(416, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 147)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Artículos"
        '
        'btnLimpiaArticulos
        '
        Me.btnLimpiaArticulos.Image = CType(resources.GetObject("btnLimpiaArticulos.Image"), System.Drawing.Image)
        Me.btnLimpiaArticulos.Location = New System.Drawing.Point(773, 11)
        Me.btnLimpiaArticulos.Name = "btnLimpiaArticulos"
        Me.btnLimpiaArticulos.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiaArticulos.TabIndex = 3
        Me.btnLimpiaArticulos.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gridArticulos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 39)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(823, 105)
        Me.Panel3.TabIndex = 2
        '
        'gridArticulos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridArticulos.DisplayLayout.Appearance = Appearance1
        Me.gridArticulos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridArticulos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridArticulos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridArticulos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridArticulos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridArticulos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridArticulos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridArticulos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridArticulos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.gridArticulos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridArticulos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridArticulos.Location = New System.Drawing.Point(0, 0)
        Me.gridArticulos.Name = "gridArticulos"
        Me.gridArticulos.Size = New System.Drawing.Size(823, 105)
        Me.gridArticulos.TabIndex = 3
        '
        'btnArticulos
        '
        Me.btnArticulos.Image = CType(resources.GetObject("btnArticulos.Image"), System.Drawing.Image)
        Me.btnArticulos.Location = New System.Drawing.Point(800, 11)
        Me.btnArticulos.Name = "btnArticulos"
        Me.btnArticulos.Size = New System.Drawing.Size(22, 22)
        Me.btnArticulos.TabIndex = 0
        Me.btnArticulos.UseVisualStyleBackColor = True
        '
        'Cliente
        '
        Me.Cliente.Controls.Add(Me.lblMensajeSinListaVentas)
        Me.Cliente.Controls.Add(Me.Label5)
        Me.Cliente.Controls.Add(Me.lblFechaFinListaDato)
        Me.Cliente.Controls.Add(Me.lblFechaFinLista)
        Me.Cliente.Controls.Add(Me.lblFechaInicioLista_Dato)
        Me.Cliente.Controls.Add(Me.lblListaVentas)
        Me.Cliente.Controls.Add(Me.lblFechaInicioLista)
        Me.Cliente.Controls.Add(Me.lblListaVenta)
        Me.Cliente.Controls.Add(Me.cmbListaVentasCliente)
        Me.Cliente.Controls.Add(Me.lblEstatusListaPrecios)
        Me.Cliente.Controls.Add(Me.cmbListaBase)
        Me.Cliente.Controls.Add(Me.Label4)
        Me.Cliente.Controls.Add(Me.cmbClientes)
        Me.Cliente.Location = New System.Drawing.Point(12, 30)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Size = New System.Drawing.Size(394, 124)
        Me.Cliente.TabIndex = 107
        Me.Cliente.TabStop = False
        Me.Cliente.Text = "Información de la Lista de Precios"
        '
        'lblMensajeSinListaVentas
        '
        Me.lblMensajeSinListaVentas.AutoSize = True
        Me.lblMensajeSinListaVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeSinListaVentas.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeSinListaVentas.Location = New System.Drawing.Point(3, 108)
        Me.lblMensajeSinListaVentas.Name = "lblMensajeSinListaVentas"
        Me.lblMensajeSinListaVentas.Size = New System.Drawing.Size(229, 13)
        Me.lblMensajeSinListaVentas.TabIndex = 83
        Me.lblMensajeSinListaVentas.Text = "El cliente no tiene asignada una lista de ventas"
        Me.lblMensajeSinListaVentas.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "L Precios"
        '
        'lblFechaFinListaDato
        '
        Me.lblFechaFinListaDato.AutoSize = True
        Me.lblFechaFinListaDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFinListaDato.Location = New System.Drawing.Point(256, 91)
        Me.lblFechaFinListaDato.Name = "lblFechaFinListaDato"
        Me.lblFechaFinListaDato.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaFinListaDato.TabIndex = 93
        Me.lblFechaFinListaDato.Text = "01/01/2000"
        '
        'lblFechaFinLista
        '
        Me.lblFechaFinLista.AutoSize = True
        Me.lblFechaFinLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFinLista.Location = New System.Drawing.Point(229, 91)
        Me.lblFechaFinLista.Name = "lblFechaFinLista"
        Me.lblFechaFinLista.Size = New System.Drawing.Size(21, 13)
        Me.lblFechaFinLista.TabIndex = 92
        Me.lblFechaFinLista.Text = "Fin"
        '
        'lblFechaInicioLista_Dato
        '
        Me.lblFechaInicioLista_Dato.AutoSize = True
        Me.lblFechaInicioLista_Dato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicioLista_Dato.Location = New System.Drawing.Point(153, 91)
        Me.lblFechaInicioLista_Dato.Name = "lblFechaInicioLista_Dato"
        Me.lblFechaInicioLista_Dato.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaInicioLista_Dato.TabIndex = 83
        Me.lblFechaInicioLista_Dato.Text = "01/01/2000"
        '
        'lblListaVentas
        '
        Me.lblListaVentas.AutoSize = True
        Me.lblListaVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaVentas.Location = New System.Drawing.Point(57, 91)
        Me.lblListaVentas.Name = "lblListaVentas"
        Me.lblListaVentas.Size = New System.Drawing.Size(13, 13)
        Me.lblListaVentas.TabIndex = 91
        Me.lblListaVentas.Text = "--"
        '
        'lblFechaInicioLista
        '
        Me.lblFechaInicioLista.AutoSize = True
        Me.lblFechaInicioLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicioLista.Location = New System.Drawing.Point(115, 91)
        Me.lblFechaInicioLista.Name = "lblFechaInicioLista"
        Me.lblFechaInicioLista.Size = New System.Drawing.Size(32, 13)
        Me.lblFechaInicioLista.TabIndex = 82
        Me.lblFechaInicioLista.Text = "Inicio"
        '
        'lblListaVenta
        '
        Me.lblListaVenta.AutoSize = True
        Me.lblListaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaVenta.Location = New System.Drawing.Point(5, 68)
        Me.lblListaVenta.Name = "lblListaVenta"
        Me.lblListaVenta.Size = New System.Drawing.Size(48, 13)
        Me.lblListaVenta.TabIndex = 90
        Me.lblListaVenta.Text = "L Cliente"
        '
        'cmbListaVentasCliente
        '
        Me.cmbListaVentasCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaVentasCliente.FormattingEnabled = True
        Me.cmbListaVentasCliente.Location = New System.Drawing.Point(56, 67)
        Me.cmbListaVentasCliente.Name = "cmbListaVentasCliente"
        Me.cmbListaVentasCliente.Size = New System.Drawing.Size(329, 21)
        Me.cmbListaVentasCliente.TabIndex = 87
        '
        'lblEstatusListaPrecios
        '
        Me.lblEstatusListaPrecios.AutoSize = True
        Me.lblEstatusListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatusListaPrecios.Location = New System.Drawing.Point(5, 45)
        Me.lblEstatusListaPrecios.Name = "lblEstatusListaPrecios"
        Me.lblEstatusListaPrecios.Size = New System.Drawing.Size(40, 13)
        Me.lblEstatusListaPrecios.TabIndex = 89
        Me.lblEstatusListaPrecios.Text = "L Base"
        '
        'cmbListaBase
        '
        Me.cmbListaBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaBase.FormattingEnabled = True
        Me.cmbListaBase.Location = New System.Drawing.Point(56, 42)
        Me.cmbListaBase.Name = "cmbListaBase"
        Me.cmbListaBase.Size = New System.Drawing.Size(329, 21)
        Me.cmbListaBase.TabIndex = 88
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Cliente"
        '
        'cmbClientes
        '
        Me.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(56, 17)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(329, 21)
        Me.cmbClientes.TabIndex = 85
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnLimpiaFamilias)
        Me.GroupBox3.Controls.Add(Me.Panel1)
        Me.GroupBox3.Controls.Add(Me.btnFamilias)
        Me.GroupBox3.Location = New System.Drawing.Point(881, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(361, 184)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Familia de Ventas"
        '
        'btnLimpiaFamilias
        '
        Me.btnLimpiaFamilias.Image = CType(resources.GetObject("btnLimpiaFamilias.Image"), System.Drawing.Image)
        Me.btnLimpiaFamilias.Location = New System.Drawing.Point(308, 8)
        Me.btnLimpiaFamilias.Name = "btnLimpiaFamilias"
        Me.btnLimpiaFamilias.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiaFamilias.TabIndex = 3
        Me.btnLimpiaFamilias.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdFamiliaDeVentas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(355, 145)
        Me.Panel1.TabIndex = 2
        '
        'grdFamiliaDeVentas
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFamiliaDeVentas.DisplayLayout.Appearance = Appearance3
        Me.grdFamiliaDeVentas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFamiliaDeVentas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFamiliaDeVentas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFamiliaDeVentas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFamiliaDeVentas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFamiliaDeVentas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFamiliaDeVentas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFamiliaDeVentas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFamiliaDeVentas.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdFamiliaDeVentas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFamiliaDeVentas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFamiliaDeVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFamiliaDeVentas.Location = New System.Drawing.Point(0, 0)
        Me.grdFamiliaDeVentas.Name = "grdFamiliaDeVentas"
        Me.grdFamiliaDeVentas.Size = New System.Drawing.Size(355, 145)
        Me.grdFamiliaDeVentas.TabIndex = 3
        '
        'btnFamilias
        '
        Me.btnFamilias.Image = CType(resources.GetObject("btnFamilias.Image"), System.Drawing.Image)
        Me.btnFamilias.Location = New System.Drawing.Point(333, 9)
        Me.btnFamilias.Name = "btnFamilias"
        Me.btnFamilias.Size = New System.Drawing.Size(22, 22)
        Me.btnFamilias.TabIndex = 0
        Me.btnFamilias.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimpiarColecciones)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.btnColecciones)
        Me.GroupBox2.Location = New System.Drawing.Point(419, 30)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(456, 184)
        Me.GroupBox2.TabIndex = 105
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Colecciones"
        '
        'btnLimpiarColecciones
        '
        Me.btnLimpiarColecciones.Image = CType(resources.GetObject("btnLimpiarColecciones.Image"), System.Drawing.Image)
        Me.btnLimpiarColecciones.Location = New System.Drawing.Point(402, 9)
        Me.btnLimpiarColecciones.Name = "btnLimpiarColecciones"
        Me.btnLimpiarColecciones.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarColecciones.TabIndex = 3
        Me.btnLimpiarColecciones.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdColecciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(450, 144)
        Me.Panel2.TabIndex = 2
        '
        'grdColecciones
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColecciones.DisplayLayout.Appearance = Appearance5
        Me.grdColecciones.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdColecciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColecciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColecciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColecciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColecciones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColecciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColecciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColecciones.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdColecciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColecciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColecciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColecciones.Location = New System.Drawing.Point(0, 0)
        Me.grdColecciones.Name = "grdColecciones"
        Me.grdColecciones.Size = New System.Drawing.Size(450, 144)
        Me.grdColecciones.TabIndex = 3
        '
        'btnColecciones
        '
        Me.btnColecciones.Image = CType(resources.GetObject("btnColecciones.Image"), System.Drawing.Image)
        Me.btnColecciones.Location = New System.Drawing.Point(428, 9)
        Me.btnColecciones.Name = "btnColecciones"
        Me.btnColecciones.Size = New System.Drawing.Size(22, 22)
        Me.btnColecciones.TabIndex = 0
        Me.btnColecciones.UseVisualStyleBackColor = True
        '
        'gboxCorrida
        '
        Me.gboxCorrida.Controls.Add(Me.chkSeleccionarTodo)
        Me.gboxCorrida.Controls.Add(Me.Panel8)
        Me.gboxCorrida.Location = New System.Drawing.Point(13, 214)
        Me.gboxCorrida.Name = "gboxCorrida"
        Me.gboxCorrida.Size = New System.Drawing.Size(393, 148)
        Me.gboxCorrida.TabIndex = 104
        Me.gboxCorrida.TabStop = False
        Me.gboxCorrida.Text = "Marca/Agente"
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(8, 16)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodo.TabIndex = 29
        Me.chkSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdAgentes)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 39)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(387, 106)
        Me.Panel8.TabIndex = 2
        '
        'grdAgentes
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Appearance = Appearance7
        Me.grdAgentes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdAgentes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAgentes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAgentes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAgentes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAgentes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAgentes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgentes.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdAgentes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAgentes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAgentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAgentes.Location = New System.Drawing.Point(0, 0)
        Me.grdAgentes.Name = "grdAgentes"
        Me.grdAgentes.Size = New System.Drawing.Size(387, 106)
        Me.grdAgentes.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.cmbListaVentas)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1259, 27)
        Me.Panel6.TabIndex = 46
        '
        'cmbListaVentas
        '
        Me.cmbListaVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaVentas.FormattingEnabled = True
        Me.cmbListaVentas.Location = New System.Drawing.Point(66, 3)
        Me.cmbListaVentas.Name = "cmbListaVentas"
        Me.cmbListaVentas.Size = New System.Drawing.Size(331, 21)
        Me.cmbListaVentas.TabIndex = 39
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1199, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(1225, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1259, 59)
        Me.pnlEncabezado.TabIndex = 26
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Label3)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportarConFoto)
        Me.pnlAccionesCabecera.Controls.Add(Me.Label2)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportarExcel)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblActualizarDatos)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(698, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(63, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Con Foto"
        '
        'btnExportarConFoto
        '
        Me.btnExportarConFoto.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarConFoto.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarConFoto.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarConFoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarConFoto.Location = New System.Drawing.Point(69, 3)
        Me.btnExportarConFoto.Name = "btnExportarConFoto"
        Me.btnExportarConFoto.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarConFoto.TabIndex = 55
        Me.btnExportarConFoto.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(63, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Exportar"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(16, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 53
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblActualizarDatos
        '
        Me.lblActualizarDatos.AutoSize = True
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Location = New System.Drawing.Point(10, 33)
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        Me.lblActualizarDatos.Size = New System.Drawing.Size(46, 13)
        Me.lblActualizarDatos.TabIndex = 52
        Me.lblActualizarDatos.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(680, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(579, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(289, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(216, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Lista de Precios Con Foto"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(509, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'ListaPreciosFotoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1259, 552)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.Name = "ListaPreciosFotoForm"
        Me.Text = "Lista de Precios Con Foto"
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnPBar.ResumeLayout(False)
        Me.pnPBar.PerformLayout()
        CType(Me.grdReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.gridArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cliente.ResumeLayout(False)
        Me.Cliente.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdFamiliaDeVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdColecciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxCorrida.ResumeLayout(False)
        Me.gboxCorrida.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdAgentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPrincipal As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblNumRegistros As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTextoUltimaActualizacion As Label
    Friend WithEvents lblFechaUltimaActualización As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnMostrar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblActualizarDatos As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnLimpiaFamilias As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdFamiliaDeVentas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnFamilias As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnLimpiarColecciones As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdColecciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnColecciones As Button
    Friend WithEvents gboxCorrida As GroupBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents grdAgentes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnExportarConFoto As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Cliente As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents rdbListaCapturada As RadioButton
    Friend WithEvents rdbListaCompleta As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLimpiaArticulos As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents gridArticulos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnArticulos As Button
    Friend WithEvents lblListaVentas As Label
    Friend WithEvents lblListaVenta As Label
    Friend WithEvents cmbListaVentasCliente As ComboBox
    Friend WithEvents lblEstatusListaPrecios As Label
    Friend WithEvents cmbListaBase As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbClientes As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbListaVentas As ComboBox
    Friend WithEvents lblMensajeSinListaVentas As Label
    Friend WithEvents lblFechaInicioLista_Dato As Label
    Friend WithEvents lblFechaInicioLista As Label
    Friend WithEvents lblFechaFinListaDato As Label
    Friend WithEvents lblFechaFinLista As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents grdReporte As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvReporte As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents pnPBar As Panel
    Friend WithEvents lblInfo As Label
    Friend WithEvents pBar As ProgressBar
    Friend WithEvents chkSeleccionarTodo As CheckBox
    Friend WithEvents imgLogo As PictureBox
End Class
