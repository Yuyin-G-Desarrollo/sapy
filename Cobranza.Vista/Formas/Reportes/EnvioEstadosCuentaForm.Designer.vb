<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EnvioEstadosCuentaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvioEstadosCuentaForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pnlOcultaFiltros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblgeneracion = New System.Windows.Forms.Label()
        Me.BtnGeneracionAutomatica = New System.Windows.Forms.Button()
        Me.gpCliente = New System.Windows.Forms.GroupBox()
        Me.grdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLimpiarCliente = New System.Windows.Forms.Button()
        Me.btnSeleccionarCliente = New System.Windows.Forms.Button()
        Me.gpverArchivos = New System.Windows.Forms.GroupBox()
        Me.rdTodos = New System.Windows.Forms.RadioButton()
        Me.rdporenviar = New System.Windows.Forms.RadioButton()
        Me.rdEnviados = New System.Windows.Forms.RadioButton()
        Me.lblenviar = New System.Windows.Forms.Label()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdRazonSocial = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLimpiarRazonSocial = New System.Windows.Forms.Button()
        Me.btnSeleccionarRazonSocial = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblcorreoEnviado = New System.Windows.Forms.Label()
        Me.lblcorreoNoEnviado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.grdEnvioEstadosCuenta = New DevExpress.XtraGrid.GridControl()
        Me.vwEnvioEstadosCuenta = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlOcultaFiltros.SuspendLayout()
        Me.gpCliente.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpverArchivos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdRazonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdEnvioEstadosCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwEnvioEstadosCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.lblAyuda)
        Me.pnlBanner.Controls.Add(Me.btnAyuda)
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(980, 60)
        Me.pnlBanner.TabIndex = 61
        '
        'lblAyuda
        '
        Me.lblAyuda.AutoSize = True
        Me.lblAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAyuda.Location = New System.Drawing.Point(26, 41)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(37, 13)
        Me.lblAyuda.TabIndex = 106
        Me.lblAyuda.Text = "Ayuda"
        '
        'btnAyuda
        '
        Me.btnAyuda.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAyuda.Location = New System.Drawing.Point(29, 8)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 105
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(637, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(343, 60)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(275, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(32, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(237, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Envio de Estados de Cuenta"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlAcciones.Controls.Add(Me.pnlOcultaFiltros)
        Me.pnlAcciones.Controls.Add(Me.lblgeneracion)
        Me.pnlAcciones.Controls.Add(Me.BtnGeneracionAutomatica)
        Me.pnlAcciones.Controls.Add(Me.gpCliente)
        Me.pnlAcciones.Controls.Add(Me.gpverArchivos)
        Me.pnlAcciones.Controls.Add(Me.lblenviar)
        Me.pnlAcciones.Controls.Add(Me.btnEnviar)
        Me.pnlAcciones.Controls.Add(Me.GroupBox1)
        Me.pnlAcciones.Controls.Add(Me.GroupBox3)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 60)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(980, 204)
        Me.pnlAcciones.TabIndex = 71
        '
        'pnlOcultaFiltros
        '
        Me.pnlOcultaFiltros.Controls.Add(Me.btnArriba)
        Me.pnlOcultaFiltros.Controls.Add(Me.btnAbajo)
        Me.pnlOcultaFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOcultaFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlOcultaFiltros.Name = "pnlOcultaFiltros"
        Me.pnlOcultaFiltros.Size = New System.Drawing.Size(980, 25)
        Me.pnlOcultaFiltros.TabIndex = 20
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Image = Global.Cobranza.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(887, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 40
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Image = Global.Cobranza.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(913, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 39
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'lblgeneracion
        '
        Me.lblgeneracion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblgeneracion.AutoSize = True
        Me.lblgeneracion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblgeneracion.Location = New System.Drawing.Point(855, 81)
        Me.lblgeneracion.Name = "lblgeneracion"
        Me.lblgeneracion.Size = New System.Drawing.Size(62, 26)
        Me.lblgeneracion.TabIndex = 17
        Me.lblgeneracion.Text = "Generación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Manual"
        '
        'BtnGeneracionAutomatica
        '
        Me.BtnGeneracionAutomatica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGeneracionAutomatica.Image = Global.Cobranza.Vista.My.Resources.Resources.reporteDeducciones_
        Me.BtnGeneracionAutomatica.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnGeneracionAutomatica.Location = New System.Drawing.Point(866, 45)
        Me.BtnGeneracionAutomatica.Name = "BtnGeneracionAutomatica"
        Me.BtnGeneracionAutomatica.Size = New System.Drawing.Size(32, 32)
        Me.BtnGeneracionAutomatica.TabIndex = 16
        Me.BtnGeneracionAutomatica.UseVisualStyleBackColor = True
        '
        'gpCliente
        '
        Me.gpCliente.Controls.Add(Me.grdClientes)
        Me.gpCliente.Controls.Add(Me.btnLimpiarCliente)
        Me.gpCliente.Controls.Add(Me.btnSeleccionarCliente)
        Me.gpCliente.Location = New System.Drawing.Point(324, 31)
        Me.gpCliente.Name = "gpCliente"
        Me.gpCliente.Size = New System.Drawing.Size(303, 166)
        Me.gpCliente.TabIndex = 12
        Me.gpCliente.TabStop = False
        Me.gpCliente.Text = "Cliente"
        '
        'grdClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Appearance = Appearance1
        Me.grdClientes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdClientes.Location = New System.Drawing.Point(3, 37)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(297, 126)
        Me.grdClientes.TabIndex = 15
        '
        'btnLimpiarCliente
        '
        Me.btnLimpiarCliente.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarCliente.Location = New System.Drawing.Point(245, 9)
        Me.btnLimpiarCliente.Name = "btnLimpiarCliente"
        Me.btnLimpiarCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarCliente.TabIndex = 13
        Me.btnLimpiarCliente.UseVisualStyleBackColor = True
        '
        'btnSeleccionarCliente
        '
        Me.btnSeleccionarCliente.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnSeleccionarCliente.Location = New System.Drawing.Point(273, 9)
        Me.btnSeleccionarCliente.Name = "btnSeleccionarCliente"
        Me.btnSeleccionarCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnSeleccionarCliente.TabIndex = 14
        Me.btnSeleccionarCliente.UseVisualStyleBackColor = True
        '
        'gpverArchivos
        '
        Me.gpverArchivos.Controls.Add(Me.rdTodos)
        Me.gpverArchivos.Controls.Add(Me.rdporenviar)
        Me.gpverArchivos.Controls.Add(Me.rdEnviados)
        Me.gpverArchivos.Location = New System.Drawing.Point(637, 40)
        Me.gpverArchivos.Name = "gpverArchivos"
        Me.gpverArchivos.Size = New System.Drawing.Size(132, 83)
        Me.gpverArchivos.TabIndex = 3
        Me.gpverArchivos.TabStop = False
        Me.gpverArchivos.Text = "Ver Archivos"
        '
        'rdTodos
        '
        Me.rdTodos.AutoSize = True
        Me.rdTodos.Location = New System.Drawing.Point(11, 60)
        Me.rdTodos.Name = "rdTodos"
        Me.rdTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdTodos.TabIndex = 7
        Me.rdTodos.Text = "Todos"
        Me.rdTodos.UseVisualStyleBackColor = True
        '
        'rdporenviar
        '
        Me.rdporenviar.AutoSize = True
        Me.rdporenviar.Location = New System.Drawing.Point(11, 39)
        Me.rdporenviar.Name = "rdporenviar"
        Me.rdporenviar.Size = New System.Drawing.Size(74, 17)
        Me.rdporenviar.TabIndex = 6
        Me.rdporenviar.Text = "Por Enviar"
        Me.rdporenviar.UseVisualStyleBackColor = True
        '
        'rdEnviados
        '
        Me.rdEnviados.AutoSize = True
        Me.rdEnviados.Checked = True
        Me.rdEnviados.Location = New System.Drawing.Point(11, 19)
        Me.rdEnviados.Name = "rdEnviados"
        Me.rdEnviados.Size = New System.Drawing.Size(69, 17)
        Me.rdEnviados.TabIndex = 5
        Me.rdEnviados.TabStop = True
        Me.rdEnviados.Text = "Enviados"
        Me.rdEnviados.UseVisualStyleBackColor = True
        '
        'lblenviar
        '
        Me.lblenviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblenviar.AutoSize = True
        Me.lblenviar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblenviar.Location = New System.Drawing.Point(926, 80)
        Me.lblenviar.Name = "lblenviar"
        Me.lblenviar.Size = New System.Drawing.Size(37, 13)
        Me.lblenviar.TabIndex = 19
        Me.lblenviar.Text = "Enviar"
        Me.lblenviar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Image = Global.Cobranza.Vista.My.Resources.Resources.Enviar
        Me.btnEnviar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnviar.Location = New System.Drawing.Point(929, 45)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviar.TabIndex = 18
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdRazonSocial)
        Me.GroupBox1.Controls.Add(Me.btnLimpiarRazonSocial)
        Me.GroupBox1.Controls.Add(Me.btnSeleccionarRazonSocial)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(303, 166)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Razón Social"
        '
        'grdRazonSocial
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazonSocial.DisplayLayout.Appearance = Appearance3
        Me.grdRazonSocial.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdRazonSocial.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdRazonSocial.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdRazonSocial.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdRazonSocial.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdRazonSocial.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdRazonSocial.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdRazonSocial.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazonSocial.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdRazonSocial.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdRazonSocial.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRazonSocial.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdRazonSocial.Location = New System.Drawing.Point(3, 37)
        Me.grdRazonSocial.Name = "grdRazonSocial"
        Me.grdRazonSocial.Size = New System.Drawing.Size(297, 126)
        Me.grdRazonSocial.TabIndex = 11
        '
        'btnLimpiarRazonSocial
        '
        Me.btnLimpiarRazonSocial.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarRazonSocial.Location = New System.Drawing.Point(247, 10)
        Me.btnLimpiarRazonSocial.Name = "btnLimpiarRazonSocial"
        Me.btnLimpiarRazonSocial.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarRazonSocial.TabIndex = 9
        Me.btnLimpiarRazonSocial.UseVisualStyleBackColor = True
        '
        'btnSeleccionarRazonSocial
        '
        Me.btnSeleccionarRazonSocial.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnSeleccionarRazonSocial.Location = New System.Drawing.Point(275, 10)
        Me.btnSeleccionarRazonSocial.Name = "btnSeleccionarRazonSocial"
        Me.btnSeleccionarRazonSocial.Size = New System.Drawing.Size(22, 22)
        Me.btnSeleccionarRazonSocial.TabIndex = 10
        Me.btnSeleccionarRazonSocial.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox3.Controls.Add(Me.lblEntregaDel)
        Me.GroupBox3.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox3.Controls.Add(Me.lblEntregaAl)
        Me.GroupBox3.Location = New System.Drawing.Point(637, 129)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(132, 65)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha"
        Me.GroupBox3.Visible = False
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(33, 17)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(90, 20)
        Me.dtpFechaInicio.TabIndex = 3
        Me.dtpFechaInicio.Value = New Date(2017, 8, 28, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(9, 22)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 2
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(33, 44)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(90, 20)
        Me.dtpFechaFin.TabIndex = 5
        Me.dtpFechaFin.Value = New Date(2017, 8, 28, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(9, 43)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 4
        Me.lblEntregaAl.Text = "Al"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblcorreoEnviado)
        Me.Panel1.Controls.Add(Me.lblcorreoNoEnviado)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 516)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(980, 60)
        Me.Panel1.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Correo Enviado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "Correo No Enviado"
        '
        'lblcorreoEnviado
        '
        Me.lblcorreoEnviado.BackColor = System.Drawing.Color.ForestGreen
        Me.lblcorreoEnviado.Location = New System.Drawing.Point(23, 32)
        Me.lblcorreoEnviado.Name = "lblcorreoEnviado"
        Me.lblcorreoEnviado.Size = New System.Drawing.Size(15, 15)
        Me.lblcorreoEnviado.TabIndex = 138
        '
        'lblcorreoNoEnviado
        '
        Me.lblcorreoNoEnviado.BackColor = System.Drawing.Color.Red
        Me.lblcorreoNoEnviado.Location = New System.Drawing.Point(23, 9)
        Me.lblcorreoNoEnviado.Name = "lblcorreoNoEnviado"
        Me.lblcorreoNoEnviado.Size = New System.Drawing.Size(15, 15)
        Me.lblcorreoNoEnviado.TabIndex = 137
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblLimpiar)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.lblCancelar)
        Me.Panel2.Controls.Add(Me.lblGuardar)
        Me.Panel2.Controls.Add(Me.btnMostrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(814, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(166, 60)
        Me.Panel2.TabIndex = 6
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(70, 42)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 24
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(71, 7)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 23
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(114, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 25
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(114, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 26
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(22, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(42, 13)
        Me.lblGuardar.TabIndex = 22
        Me.lblGuardar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Cobranza.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(26, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 21
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'grdEnvioEstadosCuenta
        '
        Me.grdEnvioEstadosCuenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEnvioEstadosCuenta.Location = New System.Drawing.Point(0, 264)
        Me.grdEnvioEstadosCuenta.MainView = Me.vwEnvioEstadosCuenta
        Me.grdEnvioEstadosCuenta.Name = "grdEnvioEstadosCuenta"
        Me.grdEnvioEstadosCuenta.Size = New System.Drawing.Size(980, 252)
        Me.grdEnvioEstadosCuenta.TabIndex = 81
        Me.grdEnvioEstadosCuenta.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwEnvioEstadosCuenta})
        '
        'vwEnvioEstadosCuenta
        '
        Me.vwEnvioEstadosCuenta.GridControl = Me.grdEnvioEstadosCuenta
        Me.vwEnvioEstadosCuenta.Name = "vwEnvioEstadosCuenta"
        Me.vwEnvioEstadosCuenta.OptionsCustomization.AllowColumnMoving = False
        Me.vwEnvioEstadosCuenta.OptionsView.ShowAutoFilterRow = True
        Me.vwEnvioEstadosCuenta.OptionsView.ShowGroupPanel = False
        '
        'EnvioEstadosCuentaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 576)
        Me.Controls.Add(Me.grdEnvioEstadosCuenta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlBanner)
        Me.Name = "EnvioEstadosCuentaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envio de Estados de Cuenta"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlOcultaFiltros.ResumeLayout(False)
        Me.gpCliente.ResumeLayout(False)
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpverArchivos.ResumeLayout(False)
        Me.gpverArchivos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdRazonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdEnvioEstadosCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwEnvioEstadosCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlAcciones As Windows.Forms.Panel
    Friend WithEvents gpverArchivos As Windows.Forms.GroupBox
    Friend WithEvents lblenviar As Windows.Forms.Label
    Friend WithEvents btnEnviar As Windows.Forms.Button
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents btnSeleccionarRazonSocial As Windows.Forms.Button
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents dtpFechaInicio As Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaDel As Windows.Forms.Label
    Friend WithEvents dtpFechaFin As Windows.Forms.DateTimePicker
    Friend WithEvents lblEntregaAl As Windows.Forms.Label
    Friend WithEvents gpCliente As Windows.Forms.GroupBox
    Friend WithEvents btnSeleccionarCliente As Windows.Forms.Button
    Friend WithEvents rdporenviar As Windows.Forms.RadioButton
    Friend WithEvents rdEnviados As Windows.Forms.RadioButton
    Friend WithEvents rdTodos As Windows.Forms.RadioButton
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents BtnGeneracionAutomatica As Windows.Forms.Button
    Friend WithEvents lblgeneracion As Windows.Forms.Label
    Friend WithEvents lblcorreoEnviado As Windows.Forms.Label
    Friend WithEvents lblcorreoNoEnviado As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents btnLimpiarCliente As Windows.Forms.Button
    Friend WithEvents btnLimpiarRazonSocial As Windows.Forms.Button
    Friend WithEvents grdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdRazonSocial As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents grdEnvioEstadosCuenta As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwEnvioEstadosCuenta As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAyuda As Windows.Forms.Button
    Friend WithEvents lblAyuda As Windows.Forms.Label
    Friend WithEvents pnlOcultaFiltros As Windows.Forms.Panel
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents btnAbajo As Windows.Forms.Button
End Class
