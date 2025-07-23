<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MotivosCancelacionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MotivosCancelacionForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnActivar = New System.Windows.Forms.Button()
        Me.lblActivar = New System.Windows.Forms.Label()
        Me.btnDesactivar = New System.Windows.Forms.Button()
        Me.lbldesactivar = New System.Windows.Forms.Label()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.gbRazonSocialEmisor = New System.Windows.Forms.GroupBox()
        Me.grdRazSocEmisor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLimpiarRacZocEmisor = New System.Windows.Forms.Button()
        Me.btnAgregarRacSocEmisor = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gbRazonSocialReceptor = New System.Windows.Forms.GroupBox()
        Me.grdRazSocReceptor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnLImpiarRazSocReceptor = New System.Windows.Forms.Button()
        Me.btnAgregarRazSocReceptor = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.rpActivoNo = New System.Windows.Forms.RadioButton()
        Me.rpActivoSi = New System.Windows.Forms.RadioButton()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblfechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblultimaactualizacion = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMostrarMotivos = New System.Windows.Forms.Button()
        Me.btnCerrarMotivos = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdMotivosCancelacion = New DevExpress.XtraGrid.GridControl()
        Me.wvMotivosCancelaciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRazonSocialEmisor.SuspendLayout()
        CType(Me.grdRazSocEmisor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRazonSocialReceptor.SuspendLayout()
        CType(Me.grdRazSocReceptor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcciones.SuspendLayout()
        Me.gpFecha.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdMotivosCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wvMotivosCancelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.lblEditar)
        Me.pnlBanner.Controls.Add(Me.btnActivar)
        Me.pnlBanner.Controls.Add(Me.lblActivar)
        Me.pnlBanner.Controls.Add(Me.btnDesactivar)
        Me.pnlBanner.Controls.Add(Me.lbldesactivar)
        Me.pnlBanner.Controls.Add(Me.lblAlta)
        Me.pnlBanner.Controls.Add(Me.btnAlta)
        Me.pnlBanner.Controls.Add(Me.btnEditar)
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(610, 65)
        Me.pnlBanner.TabIndex = 63
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(94, 41)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(42, 13)
        Me.lblEditar.TabIndex = 115
        Me.lblEditar.Text = "Edición"
        Me.lblEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnActivar
        '
        Me.btnActivar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnActivar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActivar.Image = CType(resources.GetObject("btnActivar.Image"), System.Drawing.Image)
        Me.btnActivar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActivar.Location = New System.Drawing.Point(246, 8)
        Me.btnActivar.Name = "btnActivar"
        Me.btnActivar.Size = New System.Drawing.Size(32, 32)
        Me.btnActivar.TabIndex = 114
        Me.btnActivar.UseVisualStyleBackColor = True
        '
        'lblActivar
        '
        Me.lblActivar.AutoSize = True
        Me.lblActivar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActivar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblActivar.Location = New System.Drawing.Point(242, 42)
        Me.lblActivar.Name = "lblActivar"
        Me.lblActivar.Size = New System.Drawing.Size(40, 13)
        Me.lblActivar.TabIndex = 113
        Me.lblActivar.Text = "Activar"
        '
        'btnDesactivar
        '
        Me.btnDesactivar.BackgroundImage = CType(resources.GetObject("btnDesactivar.BackgroundImage"), System.Drawing.Image)
        Me.btnDesactivar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDesactivar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnDesactivar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDesactivar.Location = New System.Drawing.Point(174, 8)
        Me.btnDesactivar.Name = "btnDesactivar"
        Me.btnDesactivar.Size = New System.Drawing.Size(32, 32)
        Me.btnDesactivar.TabIndex = 112
        Me.btnDesactivar.UseVisualStyleBackColor = True
        '
        'lbldesactivar
        '
        Me.lbldesactivar.AutoSize = True
        Me.lbldesactivar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbldesactivar.Location = New System.Drawing.Point(162, 42)
        Me.lbldesactivar.Name = "lbldesactivar"
        Me.lbldesactivar.Size = New System.Drawing.Size(58, 13)
        Me.lbldesactivar.TabIndex = 111
        Me.lbldesactivar.Text = "Desactivar"
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(32, 41)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 110
        Me.lblAlta.Text = "Alta"
        '
        'btnAlta
        '
        Me.btnAlta.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAlta.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnAlta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAlta.Location = New System.Drawing.Point(29, 7)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 109
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEditar.Location = New System.Drawing.Point(99, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 107
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(299, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(311, 65)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(243, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(37, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(198, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Motivos de Cancelación"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Cobranza.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(1258, 42)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 21
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(1254, 76)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(42, 13)
        Me.lblGuardar.TabIndex = 22
        Me.lblGuardar.Text = "Mostrar"
        '
        'gbRazonSocialEmisor
        '
        Me.gbRazonSocialEmisor.Controls.Add(Me.grdRazSocEmisor)
        Me.gbRazonSocialEmisor.Controls.Add(Me.btnLimpiarRacZocEmisor)
        Me.gbRazonSocialEmisor.Controls.Add(Me.btnAgregarRacSocEmisor)
        Me.gbRazonSocialEmisor.Location = New System.Drawing.Point(882, 31)
        Me.gbRazonSocialEmisor.Name = "gbRazonSocialEmisor"
        Me.gbRazonSocialEmisor.Size = New System.Drawing.Size(181, 162)
        Me.gbRazonSocialEmisor.TabIndex = 131
        Me.gbRazonSocialEmisor.TabStop = False
        Me.gbRazonSocialEmisor.Text = "Razón Social Emisor"
        '
        'grdRazSocEmisor
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazSocEmisor.DisplayLayout.Appearance = Appearance1
        Me.grdRazSocEmisor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdRazSocEmisor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdRazSocEmisor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdRazSocEmisor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazSocEmisor.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdRazSocEmisor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdRazSocEmisor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRazSocEmisor.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdRazSocEmisor.Location = New System.Drawing.Point(3, 33)
        Me.grdRazSocEmisor.Name = "grdRazSocEmisor"
        Me.grdRazSocEmisor.Size = New System.Drawing.Size(175, 126)
        Me.grdRazSocEmisor.TabIndex = 15
        '
        'btnLimpiarRacZocEmisor
        '
        Me.btnLimpiarRacZocEmisor.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarRacZocEmisor.Location = New System.Drawing.Point(126, 9)
        Me.btnLimpiarRacZocEmisor.Name = "btnLimpiarRacZocEmisor"
        Me.btnLimpiarRacZocEmisor.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarRacZocEmisor.TabIndex = 13
        Me.btnLimpiarRacZocEmisor.UseVisualStyleBackColor = True
        '
        'btnAgregarRacSocEmisor
        '
        Me.btnAgregarRacSocEmisor.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregarRacSocEmisor.Location = New System.Drawing.Point(154, 9)
        Me.btnAgregarRacSocEmisor.Name = "btnAgregarRacSocEmisor"
        Me.btnAgregarRacSocEmisor.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarRacSocEmisor.TabIndex = 14
        Me.btnAgregarRacSocEmisor.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(1303, 41)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 23
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'gbRazonSocialReceptor
        '
        Me.gbRazonSocialReceptor.Controls.Add(Me.grdRazSocReceptor)
        Me.gbRazonSocialReceptor.Controls.Add(Me.btnLImpiarRazSocReceptor)
        Me.gbRazonSocialReceptor.Controls.Add(Me.btnAgregarRazSocReceptor)
        Me.gbRazonSocialReceptor.Location = New System.Drawing.Point(1065, 31)
        Me.gbRazonSocialReceptor.Name = "gbRazonSocialReceptor"
        Me.gbRazonSocialReceptor.Size = New System.Drawing.Size(181, 162)
        Me.gbRazonSocialReceptor.TabIndex = 84
        Me.gbRazonSocialReceptor.TabStop = False
        Me.gbRazonSocialReceptor.Text = "Razón Social Receptor"
        '
        'grdRazSocReceptor
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazSocReceptor.DisplayLayout.Appearance = Appearance3
        Me.grdRazSocReceptor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdRazSocReceptor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdRazSocReceptor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdRazSocReceptor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdRazSocReceptor.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdRazSocReceptor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdRazSocReceptor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRazSocReceptor.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdRazSocReceptor.Location = New System.Drawing.Point(3, 33)
        Me.grdRazSocReceptor.Name = "grdRazSocReceptor"
        Me.grdRazSocReceptor.Size = New System.Drawing.Size(175, 126)
        Me.grdRazSocReceptor.TabIndex = 15
        '
        'btnLImpiarRazSocReceptor
        '
        Me.btnLImpiarRazSocReceptor.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLImpiarRazSocReceptor.Location = New System.Drawing.Point(126, 9)
        Me.btnLImpiarRazSocReceptor.Name = "btnLImpiarRazSocReceptor"
        Me.btnLImpiarRazSocReceptor.Size = New System.Drawing.Size(22, 22)
        Me.btnLImpiarRazSocReceptor.TabIndex = 13
        Me.btnLImpiarRazSocReceptor.UseVisualStyleBackColor = True
        '
        'btnAgregarRazSocReceptor
        '
        Me.btnAgregarRazSocReceptor.Image = Global.Cobranza.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregarRazSocReceptor.Location = New System.Drawing.Point(154, 9)
        Me.btnAgregarRazSocReceptor.Name = "btnAgregarRazSocReceptor"
        Me.btnAgregarRazSocReceptor.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarRazSocReceptor.TabIndex = 14
        Me.btnAgregarRazSocReceptor.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(1302, 76)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 24
        Me.lblLimpiar.Text = "Limpiar"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlAcciones.Controls.Add(Me.gpFecha)
        Me.pnlAcciones.Controls.Add(Me.lblLimpiar)
        Me.pnlAcciones.Controls.Add(Me.gbRazonSocialReceptor)
        Me.pnlAcciones.Controls.Add(Me.btnLimpiar)
        Me.pnlAcciones.Controls.Add(Me.gbRazonSocialEmisor)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 65)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(610, 74)
        Me.pnlAcciones.TabIndex = 73
        '
        'gpFecha
        '
        Me.gpFecha.Controls.Add(Me.rpActivoNo)
        Me.gpFecha.Controls.Add(Me.rpActivoSi)
        Me.gpFecha.Location = New System.Drawing.Point(29, 13)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(128, 51)
        Me.gpFecha.TabIndex = 132
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Activo"
        '
        'rpActivoNo
        '
        Me.rpActivoNo.AutoSize = True
        Me.rpActivoNo.Location = New System.Drawing.Point(68, 21)
        Me.rpActivoNo.Name = "rpActivoNo"
        Me.rpActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rpActivoNo.TabIndex = 9
        Me.rpActivoNo.Text = "No"
        Me.rpActivoNo.UseVisualStyleBackColor = True
        '
        'rpActivoSi
        '
        Me.rpActivoSi.AutoSize = True
        Me.rpActivoSi.Location = New System.Drawing.Point(20, 21)
        Me.rpActivoSi.Name = "rpActivoSi"
        Me.rpActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rpActivoSi.TabIndex = 8
        Me.rpActivoSi.Text = "Si"
        Me.rpActivoSi.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblfechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblultimaactualizacion)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 379)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(610, 71)
        Me.pnlPie.TabIndex = 74
        '
        'lblfechaUltimaActualizacion
        '
        Me.lblfechaUltimaActualizacion.AutoSize = True
        Me.lblfechaUltimaActualizacion.Location = New System.Drawing.Point(326, 25)
        Me.lblfechaUltimaActualizacion.Name = "lblfechaUltimaActualizacion"
        Me.lblfechaUltimaActualizacion.Size = New System.Drawing.Size(135, 13)
        Me.lblfechaUltimaActualizacion.TabIndex = 139
        Me.lblfechaUltimaActualizacion.Text = "fecha Última Actualización:"
        Me.lblfechaUltimaActualizacion.Visible = False
        '
        'lblultimaactualizacion
        '
        Me.lblultimaactualizacion.AutoSize = True
        Me.lblultimaactualizacion.Location = New System.Drawing.Point(212, 24)
        Me.lblultimaactualizacion.Name = "lblultimaactualizacion"
        Me.lblultimaactualizacion.Size = New System.Drawing.Size(105, 13)
        Me.lblultimaactualizacion.TabIndex = 138
        Me.lblultimaactualizacion.Text = "Última Actualización:"
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(26, 16)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(79, 16)
        Me.lblClientes.TabIndex = 137
        Me.lblClientes.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(20, 37)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalRegistros.TabIndex = 136
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Label1)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrarMotivos)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrarMotivos)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(474, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(136, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(24, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Mostrar"
        '
        'btnMostrarMotivos
        '
        Me.btnMostrarMotivos.Image = Global.Cobranza.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrarMotivos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrarMotivos.Location = New System.Drawing.Point(28, 14)
        Me.btnMostrarMotivos.Name = "btnMostrarMotivos"
        Me.btnMostrarMotivos.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrarMotivos.TabIndex = 23
        Me.btnMostrarMotivos.UseVisualStyleBackColor = True
        '
        'btnCerrarMotivos
        '
        Me.btnCerrarMotivos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrarMotivos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrarMotivos.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCerrarMotivos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrarMotivos.Location = New System.Drawing.Point(88, 13)
        Me.btnCerrarMotivos.Name = "btnCerrarMotivos"
        Me.btnCerrarMotivos.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrarMotivos.TabIndex = 2
        Me.btnCerrarMotivos.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(87, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdMotivosCancelacion
        '
        Me.grdMotivosCancelacion.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdMotivosCancelacion.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdMotivosCancelacion.Location = New System.Drawing.Point(0, 139)
        Me.grdMotivosCancelacion.MainView = Me.wvMotivosCancelaciones
        Me.grdMotivosCancelacion.Name = "grdMotivosCancelacion"
        Me.grdMotivosCancelacion.Size = New System.Drawing.Size(610, 240)
        Me.grdMotivosCancelacion.TabIndex = 75
        Me.grdMotivosCancelacion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.wvMotivosCancelaciones})
        '
        'wvMotivosCancelaciones
        '
        Me.wvMotivosCancelaciones.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.wvMotivosCancelaciones.Appearance.EvenRow.Options.UseBackColor = True
        Me.wvMotivosCancelaciones.GridControl = Me.grdMotivosCancelacion
        Me.wvMotivosCancelaciones.Name = "wvMotivosCancelaciones"
        Me.wvMotivosCancelaciones.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvMotivosCancelaciones.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvMotivosCancelaciones.OptionsCustomization.AllowColumnMoving = False
        Me.wvMotivosCancelaciones.OptionsView.ShowFooter = True
        Me.wvMotivosCancelaciones.OptionsView.ShowGroupPanel = False
        '
        'MotivosCancelacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 450)
        Me.Controls.Add(Me.grdMotivosCancelacion)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlBanner)
        Me.MaximumSize = New System.Drawing.Size(626, 489)
        Me.MinimumSize = New System.Drawing.Size(626, 489)
        Me.Name = "MotivosCancelacionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motivos de Cancelacion"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRazonSocialEmisor.ResumeLayout(False)
        CType(Me.grdRazSocEmisor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRazonSocialReceptor.ResumeLayout(False)
        CType(Me.grdRazSocReceptor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdMotivosCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wvMotivosCancelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents lblEditar As Windows.Forms.Label
    Friend WithEvents btnActivar As Windows.Forms.Button
    Friend WithEvents lblActivar As Windows.Forms.Label
    Friend WithEvents btnDesactivar As Windows.Forms.Button
    Friend WithEvents lbldesactivar As Windows.Forms.Label
    Friend WithEvents lblAlta As Windows.Forms.Label
    Friend WithEvents btnAlta As Windows.Forms.Button
    Friend WithEvents btnEditar As Windows.Forms.Button
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents gbRazonSocialEmisor As Windows.Forms.GroupBox
    Friend WithEvents grdRazSocEmisor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLimpiarRacZocEmisor As Windows.Forms.Button
    Friend WithEvents btnAgregarRacSocEmisor As Windows.Forms.Button
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents gbRazonSocialReceptor As Windows.Forms.GroupBox
    Friend WithEvents grdRazSocReceptor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLImpiarRazSocReceptor As Windows.Forms.Button
    Friend WithEvents btnAgregarRazSocReceptor As Windows.Forms.Button
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents pnlAcciones As Windows.Forms.Panel
    Friend WithEvents gpFecha As Windows.Forms.GroupBox
    Friend WithEvents rpActivoNo As Windows.Forms.RadioButton
    Friend WithEvents rpActivoSi As Windows.Forms.RadioButton
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents lblClientes As Windows.Forms.Label
    Friend WithEvents lblTotalRegistros As Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents btnCerrarMotivos As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btnMostrarMotivos As Windows.Forms.Button
    Friend WithEvents grdMotivosCancelacion As DevExpress.XtraGrid.GridControl
    Friend WithEvents wvMotivosCancelaciones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblultimaactualizacion As Windows.Forms.Label
    Friend WithEvents lblfechaUltimaActualizacion As Windows.Forms.Label
End Class
