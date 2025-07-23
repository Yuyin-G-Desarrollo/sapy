<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Programacion_FiltrosMapaOcupacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Programacion_FiltrosMapaOcupacion))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtPedidoSICY = New System.Windows.Forms.MaskedTextBox()
        Me.btnLimpiarPedidoSICY = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdPedidoSICY = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPedidoSAY = New System.Windows.Forms.MaskedTextBox()
        Me.btnLimpiarFiltroPedidoSAY = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdPedidoSAY = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.chFecha = New System.Windows.Forms.CheckBox()
        Me.grpFecha = New System.Windows.Forms.GroupBox()
        Me.rdoSolicitaCliente = New System.Windows.Forms.RadioButton()
        Me.rdoProgramacion = New System.Windows.Forms.RadioButton()
        Me.rdoEntregaCliente = New System.Windows.Forms.RadioButton()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.btnLimTemporada = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.grdTemporada = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarTemporada = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btnLimFamilia = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.grdFamilia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarFamilia = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btnLimCorrida = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.grdCorrida = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarCorrida = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnLimColor = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.grdColor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarColor = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnLimPiel = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdPiel = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarPiel = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnLimColeccion = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdColeccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarColeccion = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnLimpMarca = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.grdMarca = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.bntAgregarMarca = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLimCliente = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarCliente = New System.Windows.Forms.Button()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.btnLimNave = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdNaves = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnAgregarNave = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdPedidoSICY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdPedidoSAY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFecha.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.grdTemporada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.grdFamilia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.grdCorrida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.grdColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdPiel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.grdMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedor.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1041, 64)
        Me.Panel1.TabIndex = 174
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(673, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(294, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Filtros Detalles Mapa de Ocupación"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.SystemColors.Window
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 445)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1041, 63)
        Me.pnlPie.TabIndex = 175
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(721, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(320, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(174, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(44, 13)
        Me.lblMostrar.TabIndex = 58
        Me.lblMostrar.Text = "Aceptar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(225, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 161
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(179, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(227, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(275, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 16
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(274, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.GroupBox3)
        Me.pnlFiltros.Controls.Add(Me.GroupBox2)
        Me.pnlFiltros.Controls.Add(Me.chFecha)
        Me.pnlFiltros.Controls.Add(Me.grpFecha)
        Me.pnlFiltros.Controls.Add(Me.GroupBox10)
        Me.pnlFiltros.Controls.Add(Me.GroupBox9)
        Me.pnlFiltros.Controls.Add(Me.GroupBox8)
        Me.pnlFiltros.Controls.Add(Me.GroupBox7)
        Me.pnlFiltros.Controls.Add(Me.GroupBox6)
        Me.pnlFiltros.Controls.Add(Me.GroupBox5)
        Me.pnlFiltros.Controls.Add(Me.GroupBox4)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Controls.Add(Me.gbProveedor)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 64)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1041, 381)
        Me.pnlFiltros.TabIndex = 176
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtPedidoSICY)
        Me.GroupBox3.Controls.Add(Me.btnLimpiarPedidoSICY)
        Me.GroupBox3.Controls.Add(Me.Panel5)
        Me.GroupBox3.Location = New System.Drawing.Point(613, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(184, 122)
        Me.GroupBox3.TabIndex = 117
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pedido SICY"
        '
        'txtPedidoSICY
        '
        Me.txtPedidoSICY.Location = New System.Drawing.Point(6, 15)
        Me.txtPedidoSICY.Mask = "999999999999999999999999999999"
        Me.txtPedidoSICY.Name = "txtPedidoSICY"
        Me.txtPedidoSICY.Size = New System.Drawing.Size(122, 20)
        Me.txtPedidoSICY.TabIndex = 6
        Me.txtPedidoSICY.ValidatingType = GetType(Integer)
        '
        'btnLimpiarPedidoSICY
        '
        Me.btnLimpiarPedidoSICY.Image = CType(resources.GetObject("btnLimpiarPedidoSICY.Image"), System.Drawing.Image)
        Me.btnLimpiarPedidoSICY.Location = New System.Drawing.Point(134, 11)
        Me.btnLimpiarPedidoSICY.Name = "btnLimpiarPedidoSICY"
        Me.btnLimpiarPedidoSICY.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarPedidoSICY.TabIndex = 5
        Me.btnLimpiarPedidoSICY.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdPedidoSICY)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 36)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(178, 83)
        Me.Panel5.TabIndex = 2
        '
        'grdPedidoSICY
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSICY.DisplayLayout.Appearance = Appearance1
        Me.grdPedidoSICY.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdPedidoSICY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPedidoSICY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidoSICY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPedidoSICY.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidoSICY.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSICY.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPedidoSICY.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPedidoSICY.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidoSICY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidoSICY.Location = New System.Drawing.Point(0, 0)
        Me.grdPedidoSICY.Name = "grdPedidoSICY"
        Me.grdPedidoSICY.Size = New System.Drawing.Size(178, 83)
        Me.grdPedidoSICY.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPedidoSAY)
        Me.GroupBox2.Controls.Add(Me.btnLimpiarFiltroPedidoSAY)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Location = New System.Drawing.Point(416, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(184, 122)
        Me.GroupBox2.TabIndex = 116
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pedido SAY"
        '
        'txtPedidoSAY
        '
        Me.txtPedidoSAY.Location = New System.Drawing.Point(6, 15)
        Me.txtPedidoSAY.Mask = "999999999999999999999999999999999999999"
        Me.txtPedidoSAY.Name = "txtPedidoSAY"
        Me.txtPedidoSAY.Size = New System.Drawing.Size(122, 20)
        Me.txtPedidoSAY.TabIndex = 6
        '
        'btnLimpiarFiltroPedidoSAY
        '
        Me.btnLimpiarFiltroPedidoSAY.Image = CType(resources.GetObject("btnLimpiarFiltroPedidoSAY.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroPedidoSAY.Location = New System.Drawing.Point(134, 11)
        Me.btnLimpiarFiltroPedidoSAY.Name = "btnLimpiarFiltroPedidoSAY"
        Me.btnLimpiarFiltroPedidoSAY.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroPedidoSAY.TabIndex = 5
        Me.btnLimpiarFiltroPedidoSAY.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdPedidoSAY)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(178, 83)
        Me.Panel3.TabIndex = 2
        '
        'grdPedidoSAY
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSAY.DisplayLayout.Appearance = Appearance3
        Me.grdPedidoSAY.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdPedidoSAY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPedidoSAY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidoSAY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPedidoSAY.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidoSAY.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidoSAY.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdPedidoSAY.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPedidoSAY.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidoSAY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidoSAY.Location = New System.Drawing.Point(0, 0)
        Me.grdPedidoSAY.Name = "grdPedidoSAY"
        Me.grdPedidoSAY.Size = New System.Drawing.Size(178, 83)
        Me.grdPedidoSAY.TabIndex = 6
        '
        'chFecha
        '
        Me.chFecha.AutoSize = True
        Me.chFecha.Location = New System.Drawing.Point(214, 265)
        Me.chFecha.Name = "chFecha"
        Me.chFecha.Size = New System.Drawing.Size(56, 17)
        Me.chFecha.TabIndex = 70
        Me.chFecha.Text = "Fecha"
        Me.chFecha.UseVisualStyleBackColor = True
        '
        'grpFecha
        '
        Me.grpFecha.Controls.Add(Me.rdoSolicitaCliente)
        Me.grpFecha.Controls.Add(Me.rdoProgramacion)
        Me.grpFecha.Controls.Add(Me.rdoEntregaCliente)
        Me.grpFecha.Controls.Add(Me.dtpFechaInicio)
        Me.grpFecha.Controls.Add(Me.lblEntregaDel)
        Me.grpFecha.Controls.Add(Me.dtpFechaFin)
        Me.grpFecha.Controls.Add(Me.lblEntregaAl)
        Me.grpFecha.Enabled = False
        Me.grpFecha.Location = New System.Drawing.Point(214, 276)
        Me.grpFecha.Name = "grpFecha"
        Me.grpFecha.Size = New System.Drawing.Size(268, 96)
        Me.grpFecha.TabIndex = 69
        Me.grpFecha.TabStop = False
        '
        'rdoSolicitaCliente
        '
        Me.rdoSolicitaCliente.AutoSize = True
        Me.rdoSolicitaCliente.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoSolicitaCliente.Location = New System.Drawing.Point(101, 13)
        Me.rdoSolicitaCliente.Name = "rdoSolicitaCliente"
        Me.rdoSolicitaCliente.Size = New System.Drawing.Size(94, 17)
        Me.rdoSolicitaCliente.TabIndex = 77
        Me.rdoSolicitaCliente.Text = "Solicita Cliente"
        Me.rdoSolicitaCliente.UseVisualStyleBackColor = False
        '
        'rdoProgramacion
        '
        Me.rdoProgramacion.AutoSize = True
        Me.rdoProgramacion.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoProgramacion.Checked = True
        Me.rdoProgramacion.Location = New System.Drawing.Point(9, 13)
        Me.rdoProgramacion.Name = "rdoProgramacion"
        Me.rdoProgramacion.Size = New System.Drawing.Size(90, 17)
        Me.rdoProgramacion.TabIndex = 75
        Me.rdoProgramacion.TabStop = True
        Me.rdoProgramacion.Text = "Programación"
        Me.rdoProgramacion.UseVisualStyleBackColor = False
        '
        'rdoEntregaCliente
        '
        Me.rdoEntregaCliente.AutoSize = True
        Me.rdoEntregaCliente.BackColor = System.Drawing.Color.AliceBlue
        Me.rdoEntregaCliente.Location = New System.Drawing.Point(9, 36)
        Me.rdoEntregaCliente.Name = "rdoEntregaCliente"
        Me.rdoEntregaCliente.Size = New System.Drawing.Size(97, 17)
        Me.rdoEntregaCliente.TabIndex = 76
        Me.rdoEntregaCliente.Text = "Entrega Cliente"
        Me.rdoEntregaCliente.UseVisualStyleBackColor = False
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(35, 65)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(89, 20)
        Me.dtpFechaInicio.TabIndex = 71
        Me.dtpFechaInicio.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(6, 69)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 73
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(159, 65)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(92, 20)
        Me.dtpFechaFin.TabIndex = 72
        Me.dtpFechaFin.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(137, 69)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 74
        Me.lblEntregaAl.Text = "Al"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.btnLimTemporada)
        Me.GroupBox10.Controls.Add(Me.Panel12)
        Me.GroupBox10.Controls.Add(Me.btnAgregarTemporada)
        Me.GroupBox10.Location = New System.Drawing.Point(12, 259)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(184, 116)
        Me.GroupBox10.TabIndex = 16
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Temporada"
        '
        'btnLimTemporada
        '
        Me.btnLimTemporada.Image = CType(resources.GetObject("btnLimTemporada.Image"), System.Drawing.Image)
        Me.btnLimTemporada.Location = New System.Drawing.Point(128, 7)
        Me.btnLimTemporada.Name = "btnLimTemporada"
        Me.btnLimTemporada.Size = New System.Drawing.Size(22, 22)
        Me.btnLimTemporada.TabIndex = 7
        Me.btnLimTemporada.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.grdTemporada)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel12.Location = New System.Drawing.Point(3, 30)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(178, 83)
        Me.Panel12.TabIndex = 2
        '
        'grdTemporada
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTemporada.DisplayLayout.Appearance = Appearance5
        Me.grdTemporada.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdTemporada.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTemporada.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTemporada.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTemporada.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTemporada.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdTemporada.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTemporada.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTemporada.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdTemporada.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTemporada.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTemporada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTemporada.Location = New System.Drawing.Point(0, 0)
        Me.grdTemporada.Name = "grdTemporada"
        Me.grdTemporada.Size = New System.Drawing.Size(178, 83)
        Me.grdTemporada.TabIndex = 6
        '
        'btnAgregarTemporada
        '
        Me.btnAgregarTemporada.Image = CType(resources.GetObject("btnAgregarTemporada.Image"), System.Drawing.Image)
        Me.btnAgregarTemporada.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarTemporada.Name = "btnAgregarTemporada"
        Me.btnAgregarTemporada.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarTemporada.TabIndex = 8
        Me.btnAgregarTemporada.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btnLimFamilia)
        Me.GroupBox9.Controls.Add(Me.Panel11)
        Me.GroupBox9.Controls.Add(Me.btnAgregarFamilia)
        Me.GroupBox9.Location = New System.Drawing.Point(815, 134)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(184, 116)
        Me.GroupBox9.TabIndex = 15
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Familia Ventas"
        '
        'btnLimFamilia
        '
        Me.btnLimFamilia.Image = CType(resources.GetObject("btnLimFamilia.Image"), System.Drawing.Image)
        Me.btnLimFamilia.Location = New System.Drawing.Point(128, 7)
        Me.btnLimFamilia.Name = "btnLimFamilia"
        Me.btnLimFamilia.Size = New System.Drawing.Size(22, 22)
        Me.btnLimFamilia.TabIndex = 7
        Me.btnLimFamilia.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.grdFamilia)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel11.Location = New System.Drawing.Point(3, 30)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(178, 83)
        Me.Panel11.TabIndex = 2
        '
        'grdFamilia
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFamilia.DisplayLayout.Appearance = Appearance7
        Me.grdFamilia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFamilia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFamilia.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFamilia.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFamilia.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFamilia.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFamilia.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFamilia.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFamilia.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdFamilia.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFamilia.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFamilia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFamilia.Location = New System.Drawing.Point(0, 0)
        Me.grdFamilia.Name = "grdFamilia"
        Me.grdFamilia.Size = New System.Drawing.Size(178, 83)
        Me.grdFamilia.TabIndex = 6
        '
        'btnAgregarFamilia
        '
        Me.btnAgregarFamilia.Image = CType(resources.GetObject("btnAgregarFamilia.Image"), System.Drawing.Image)
        Me.btnAgregarFamilia.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarFamilia.Name = "btnAgregarFamilia"
        Me.btnAgregarFamilia.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFamilia.TabIndex = 8
        Me.btnAgregarFamilia.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnLimCorrida)
        Me.GroupBox8.Controls.Add(Me.Panel10)
        Me.GroupBox8.Controls.Add(Me.btnAgregarCorrida)
        Me.GroupBox8.Location = New System.Drawing.Point(613, 134)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(184, 116)
        Me.GroupBox8.TabIndex = 9
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Corrida"
        '
        'btnLimCorrida
        '
        Me.btnLimCorrida.Image = CType(resources.GetObject("btnLimCorrida.Image"), System.Drawing.Image)
        Me.btnLimCorrida.Location = New System.Drawing.Point(128, 7)
        Me.btnLimCorrida.Name = "btnLimCorrida"
        Me.btnLimCorrida.Size = New System.Drawing.Size(22, 22)
        Me.btnLimCorrida.TabIndex = 7
        Me.btnLimCorrida.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.grdCorrida)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(3, 30)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(178, 83)
        Me.Panel10.TabIndex = 2
        '
        'grdCorrida
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCorrida.DisplayLayout.Appearance = Appearance9
        Me.grdCorrida.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCorrida.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCorrida.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCorrida.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCorrida.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCorrida.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCorrida.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCorrida.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCorrida.DisplayLayout.Override.RowAlternateAppearance = Appearance10
        Me.grdCorrida.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCorrida.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCorrida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCorrida.Location = New System.Drawing.Point(0, 0)
        Me.grdCorrida.Name = "grdCorrida"
        Me.grdCorrida.Size = New System.Drawing.Size(178, 83)
        Me.grdCorrida.TabIndex = 6
        '
        'btnAgregarCorrida
        '
        Me.btnAgregarCorrida.Image = CType(resources.GetObject("btnAgregarCorrida.Image"), System.Drawing.Image)
        Me.btnAgregarCorrida.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarCorrida.Name = "btnAgregarCorrida"
        Me.btnAgregarCorrida.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarCorrida.TabIndex = 8
        Me.btnAgregarCorrida.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnLimColor)
        Me.GroupBox7.Controls.Add(Me.Panel9)
        Me.GroupBox7.Controls.Add(Me.btnAgregarColor)
        Me.GroupBox7.Location = New System.Drawing.Point(416, 134)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(184, 116)
        Me.GroupBox7.TabIndex = 9
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Color"
        '
        'btnLimColor
        '
        Me.btnLimColor.Image = CType(resources.GetObject("btnLimColor.Image"), System.Drawing.Image)
        Me.btnLimColor.Location = New System.Drawing.Point(128, 7)
        Me.btnLimColor.Name = "btnLimColor"
        Me.btnLimColor.Size = New System.Drawing.Size(22, 22)
        Me.btnLimColor.TabIndex = 7
        Me.btnLimColor.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.grdColor)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(3, 30)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(178, 83)
        Me.Panel9.TabIndex = 2
        '
        'grdColor
        '
        Appearance11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColor.DisplayLayout.Appearance = Appearance11
        Me.grdColor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdColor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColor.DisplayLayout.Override.RowAlternateAppearance = Appearance12
        Me.grdColor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColor.Location = New System.Drawing.Point(0, 0)
        Me.grdColor.Name = "grdColor"
        Me.grdColor.Size = New System.Drawing.Size(178, 83)
        Me.grdColor.TabIndex = 6
        '
        'btnAgregarColor
        '
        Me.btnAgregarColor.Image = CType(resources.GetObject("btnAgregarColor.Image"), System.Drawing.Image)
        Me.btnAgregarColor.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarColor.Name = "btnAgregarColor"
        Me.btnAgregarColor.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarColor.TabIndex = 8
        Me.btnAgregarColor.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnLimPiel)
        Me.GroupBox6.Controls.Add(Me.Panel8)
        Me.GroupBox6.Controls.Add(Me.btnAgregarPiel)
        Me.GroupBox6.Location = New System.Drawing.Point(217, 134)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(184, 116)
        Me.GroupBox6.TabIndex = 14
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Piel"
        '
        'btnLimPiel
        '
        Me.btnLimPiel.Image = CType(resources.GetObject("btnLimPiel.Image"), System.Drawing.Image)
        Me.btnLimPiel.Location = New System.Drawing.Point(128, 7)
        Me.btnLimPiel.Name = "btnLimPiel"
        Me.btnLimPiel.Size = New System.Drawing.Size(22, 22)
        Me.btnLimPiel.TabIndex = 7
        Me.btnLimPiel.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdPiel)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 30)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(178, 83)
        Me.Panel8.TabIndex = 2
        '
        'grdPiel
        '
        Appearance13.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPiel.DisplayLayout.Appearance = Appearance13
        Me.grdPiel.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdPiel.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPiel.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPiel.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPiel.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPiel.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPiel.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPiel.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance14.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPiel.DisplayLayout.Override.RowAlternateAppearance = Appearance14
        Me.grdPiel.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPiel.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPiel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPiel.Location = New System.Drawing.Point(0, 0)
        Me.grdPiel.Name = "grdPiel"
        Me.grdPiel.Size = New System.Drawing.Size(178, 83)
        Me.grdPiel.TabIndex = 6
        '
        'btnAgregarPiel
        '
        Me.btnAgregarPiel.Image = CType(resources.GetObject("btnAgregarPiel.Image"), System.Drawing.Image)
        Me.btnAgregarPiel.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarPiel.Name = "btnAgregarPiel"
        Me.btnAgregarPiel.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarPiel.TabIndex = 8
        Me.btnAgregarPiel.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnLimColeccion)
        Me.GroupBox5.Controls.Add(Me.Panel7)
        Me.GroupBox5.Controls.Add(Me.btnAgregarColeccion)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 134)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(184, 116)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Colección"
        '
        'btnLimColeccion
        '
        Me.btnLimColeccion.Image = CType(resources.GetObject("btnLimColeccion.Image"), System.Drawing.Image)
        Me.btnLimColeccion.Location = New System.Drawing.Point(128, 7)
        Me.btnLimColeccion.Name = "btnLimColeccion"
        Me.btnLimColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnLimColeccion.TabIndex = 7
        Me.btnLimColeccion.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdColeccion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 30)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(178, 83)
        Me.Panel7.TabIndex = 2
        '
        'grdColeccion
        '
        Appearance15.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColeccion.DisplayLayout.Appearance = Appearance15
        Me.grdColeccion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdColeccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColeccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColeccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColeccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColeccion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColeccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColeccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance16.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColeccion.DisplayLayout.Override.RowAlternateAppearance = Appearance16
        Me.grdColeccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColeccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColeccion.Location = New System.Drawing.Point(0, 0)
        Me.grdColeccion.Name = "grdColeccion"
        Me.grdColeccion.Size = New System.Drawing.Size(178, 83)
        Me.grdColeccion.TabIndex = 6
        '
        'btnAgregarColeccion
        '
        Me.btnAgregarColeccion.Image = CType(resources.GetObject("btnAgregarColeccion.Image"), System.Drawing.Image)
        Me.btnAgregarColeccion.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarColeccion.Name = "btnAgregarColeccion"
        Me.btnAgregarColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarColeccion.TabIndex = 8
        Me.btnAgregarColeccion.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnLimpMarca)
        Me.GroupBox4.Controls.Add(Me.Panel6)
        Me.GroupBox4.Controls.Add(Me.bntAgregarMarca)
        Me.GroupBox4.Location = New System.Drawing.Point(812, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(184, 116)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Marca"
        '
        'btnLimpMarca
        '
        Me.btnLimpMarca.Image = CType(resources.GetObject("btnLimpMarca.Image"), System.Drawing.Image)
        Me.btnLimpMarca.Location = New System.Drawing.Point(128, 7)
        Me.btnLimpMarca.Name = "btnLimpMarca"
        Me.btnLimpMarca.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpMarca.TabIndex = 7
        Me.btnLimpMarca.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.grdMarca)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(3, 30)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(178, 83)
        Me.Panel6.TabIndex = 2
        '
        'grdMarca
        '
        Appearance17.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarca.DisplayLayout.Appearance = Appearance17
        Me.grdMarca.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdMarca.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdMarca.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMarca.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMarca.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMarca.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdMarca.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMarca.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance18.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarca.DisplayLayout.Override.RowAlternateAppearance = Appearance18
        Me.grdMarca.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMarca.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMarca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMarca.Location = New System.Drawing.Point(0, 0)
        Me.grdMarca.Name = "grdMarca"
        Me.grdMarca.Size = New System.Drawing.Size(178, 83)
        Me.grdMarca.TabIndex = 6
        '
        'bntAgregarMarca
        '
        Me.bntAgregarMarca.Image = CType(resources.GetObject("bntAgregarMarca.Image"), System.Drawing.Image)
        Me.bntAgregarMarca.Location = New System.Drawing.Point(156, 7)
        Me.bntAgregarMarca.Name = "bntAgregarMarca"
        Me.bntAgregarMarca.Size = New System.Drawing.Size(22, 22)
        Me.bntAgregarMarca.TabIndex = 8
        Me.bntAgregarMarca.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLimCliente)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.btnAgregarCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(214, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 116)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cliente"
        '
        'btnLimCliente
        '
        Me.btnLimCliente.Image = CType(resources.GetObject("btnLimCliente.Image"), System.Drawing.Image)
        Me.btnLimCliente.Location = New System.Drawing.Point(128, 7)
        Me.btnLimCliente.Name = "btnLimCliente"
        Me.btnLimCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimCliente.TabIndex = 7
        Me.btnLimCliente.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdCliente)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(178, 83)
        Me.Panel2.TabIndex = 2
        '
        'grdCliente
        '
        Appearance19.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Appearance = Appearance19
        Me.grdCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance20.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance20
        Me.grdCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdCliente.Name = "grdCliente"
        Me.grdCliente.Size = New System.Drawing.Size(178, 83)
        Me.grdCliente.TabIndex = 6
        '
        'btnAgregarCliente
        '
        Me.btnAgregarCliente.Image = CType(resources.GetObject("btnAgregarCliente.Image"), System.Drawing.Image)
        Me.btnAgregarCliente.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarCliente.Name = "btnAgregarCliente"
        Me.btnAgregarCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarCliente.TabIndex = 8
        Me.btnAgregarCliente.UseVisualStyleBackColor = True
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.btnLimNave)
        Me.gbProveedor.Controls.Add(Me.Panel4)
        Me.gbProveedor.Controls.Add(Me.btnAgregarNave)
        Me.gbProveedor.Location = New System.Drawing.Point(12, 6)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(184, 116)
        Me.gbProveedor.TabIndex = 7
        Me.gbProveedor.TabStop = False
        Me.gbProveedor.Text = "Nave"
        '
        'btnLimNave
        '
        Me.btnLimNave.Image = CType(resources.GetObject("btnLimNave.Image"), System.Drawing.Image)
        Me.btnLimNave.Location = New System.Drawing.Point(128, 7)
        Me.btnLimNave.Name = "btnLimNave"
        Me.btnLimNave.Size = New System.Drawing.Size(22, 22)
        Me.btnLimNave.TabIndex = 7
        Me.btnLimNave.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdNaves)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(178, 83)
        Me.Panel4.TabIndex = 2
        '
        'grdNaves
        '
        Appearance21.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Appearance = Appearance21
        Me.grdNaves.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdNaves.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNaves.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdNaves.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdNaves.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNaves.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNaves.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNaves.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance22.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Override.RowAlternateAppearance = Appearance22
        Me.grdNaves.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdNaves.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNaves.Location = New System.Drawing.Point(0, 0)
        Me.grdNaves.Name = "grdNaves"
        Me.grdNaves.Size = New System.Drawing.Size(178, 83)
        Me.grdNaves.TabIndex = 6
        '
        'btnAgregarNave
        '
        Me.btnAgregarNave.Image = CType(resources.GetObject("btnAgregarNave.Image"), System.Drawing.Image)
        Me.btnAgregarNave.Location = New System.Drawing.Point(156, 7)
        Me.btnAgregarNave.Name = "btnAgregarNave"
        Me.btnAgregarNave.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarNave.TabIndex = 8
        Me.btnAgregarNave.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(979, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'Programacion_FiltrosMapaOcupacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 508)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Programacion_FiltrosMapaOcupacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtros Detalles Mapa Ocupación"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdPedidoSICY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdPedidoSAY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFecha.ResumeLayout(False)
        Me.grpFecha.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.grdTemporada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        CType(Me.grdFamilia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.grdCorrida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        CType(Me.grdColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdPiel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.grdMarca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedor.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblMostrar As Label
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents btnLimTemporada As Button
    Friend WithEvents Panel12 As Panel
    Friend WithEvents grdTemporada As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarTemporada As Button
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents btnLimFamilia As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents grdFamilia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarFamilia As Button
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents btnLimCorrida As Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents grdCorrida As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarCorrida As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents btnLimColor As Button
    Friend WithEvents Panel9 As Panel
    Friend WithEvents grdColor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarColor As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents btnLimPiel As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents grdPiel As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarPiel As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnLimColeccion As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grdColeccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarColeccion As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnLimpMarca As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents grdMarca As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bntAgregarMarca As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLimCliente As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarCliente As Button
    Friend WithEvents gbProveedor As GroupBox
    Friend WithEvents btnLimNave As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grdNaves As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAgregarNave As Button
    Friend WithEvents chFecha As CheckBox
    Friend WithEvents grpFecha As GroupBox
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblEntregaDel As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents lblEntregaAl As Label
    Friend WithEvents rdoSolicitaCliente As RadioButton
    Friend WithEvents rdoProgramacion As RadioButton
    Friend WithEvents rdoEntregaCliente As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtPedidoSICY As MaskedTextBox
    Friend WithEvents btnLimpiarPedidoSICY As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents grdPedidoSICY As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtPedidoSAY As MaskedTextBox
    Friend WithEvents btnLimpiarFiltroPedidoSAY As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdPedidoSAY As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents PictureBox1 As PictureBox
End Class
