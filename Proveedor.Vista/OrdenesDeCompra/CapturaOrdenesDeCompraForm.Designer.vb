<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapturaOrdenesDeCompraForm
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CapturaOrdenesDeCompraForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtOcid = New System.Windows.Forms.TextBox()
        Me.txtModificar = New System.Windows.Forms.TextBox()
        Me.txtIdOC = New System.Windows.Forms.TextBox()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblGuardarOrden = New System.Windows.Forms.Label()
        Me.lblcerrar = New System.Windows.Forms.Label()
        Me.btnGuardarOrden = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlMaterialesSolicitados = New Infragistics.Win.Misc.UltraPanel()
        Me.grdListaMateriales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblSubTotal = New System.Windows.Forms.Label()
        Me.lblIVA = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.lblFechaEntregaEstimada = New System.Windows.Forms.Label()
        Me.lblFechaPagoEstimada = New System.Windows.Forms.Label()
        Me.dtpFechaEntregaEstimada = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaPagoEstimada = New System.Windows.Forms.DateTimePicker()
        Me.cbxUsarDireccionNave = New System.Windows.Forms.CheckBox()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.lblCodigoPostal = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblPlazo = New System.Windows.Forms.Label()
        Me.lblPrioridad = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.lblMaterialSolicitado = New System.Windows.Forms.Label()
        Me.txtEstatus = New System.Windows.Forms.TextBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.cmbPlazo = New System.Windows.Forms.ComboBox()
        Me.cmbPrioridad = New System.Windows.Forms.ComboBox()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.lblProgramadel = New System.Windows.Forms.Label()
        Me.lblProgramaal = New System.Windows.Forms.Label()
        Me.dtpProgramadel = New System.Windows.Forms.DateTimePicker()
        Me.dtpProgramaal = New System.Windows.Forms.DateTimePicker()
        Me.gbxDocumento = New System.Windows.Forms.GroupBox()
        Me.rdoRemision = New System.Windows.Forms.RadioButton()
        Me.rdoFactura = New System.Windows.Forms.RadioButton()
        Me.lblAgregar = New System.Windows.Forms.Label()
        Me.lblQuitar = New System.Windows.Forms.Label()
        Me.lblAMaterial = New System.Windows.Forms.Label()
        Me.lblQMaterial = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.lblFolioAsignado = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlInferior.SuspendLayout()
        Me.pnlMaterialesSolicitados.ClientArea.SuspendLayout()
        Me.pnlMaterialesSolicitados.SuspendLayout()
        CType(Me.grdListaMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDocumento.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.GroupBox2)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(880, 60)
        Me.pnlEncabezado.TabIndex = 154
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(17, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 35)
        Me.GroupBox2.TabIndex = 157
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(525, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(238, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Captura Ordenes de Compra"
        '
        'txtOcid
        '
        Me.txtOcid.Enabled = False
        Me.txtOcid.Location = New System.Drawing.Point(43, 167)
        Me.txtOcid.Name = "txtOcid"
        Me.txtOcid.Size = New System.Drawing.Size(19, 20)
        Me.txtOcid.TabIndex = 24
        Me.txtOcid.Visible = False
        '
        'txtModificar
        '
        Me.txtModificar.Enabled = False
        Me.txtModificar.Location = New System.Drawing.Point(18, 167)
        Me.txtModificar.Name = "txtModificar"
        Me.txtModificar.Size = New System.Drawing.Size(19, 20)
        Me.txtModificar.TabIndex = 23
        Me.txtModificar.Visible = False
        '
        'txtIdOC
        '
        Me.txtIdOC.Enabled = False
        Me.txtIdOC.Location = New System.Drawing.Point(67, 167)
        Me.txtIdOC.Name = "txtIdOC"
        Me.txtIdOC.Size = New System.Drawing.Size(19, 20)
        Me.txtIdOC.TabIndex = 25
        Me.txtIdOC.Visible = False
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblGuardarOrden)
        Me.pnlInferior.Controls.Add(Me.lblcerrar)
        Me.pnlInferior.Controls.Add(Me.btnGuardarOrden)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 635)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(880, 65)
        Me.pnlInferior.TabIndex = 155
        '
        'lblGuardarOrden
        '
        Me.lblGuardarOrden.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardarOrden.AutoSize = True
        Me.lblGuardarOrden.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarOrden.Location = New System.Drawing.Point(749, 39)
        Me.lblGuardarOrden.Name = "lblGuardarOrden"
        Me.lblGuardarOrden.Size = New System.Drawing.Size(77, 13)
        Me.lblGuardarOrden.TabIndex = 215
        Me.lblGuardarOrden.Text = "Guardar Orden"
        '
        'lblcerrar
        '
        Me.lblcerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblcerrar.AutoSize = True
        Me.lblcerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblcerrar.Location = New System.Drawing.Point(827, 39)
        Me.lblcerrar.Name = "lblcerrar"
        Me.lblcerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblcerrar.TabIndex = 98
        Me.lblcerrar.Text = "Cerrar"
        '
        'btnGuardarOrden
        '
        Me.btnGuardarOrden.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarOrden.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarOrden.Location = New System.Drawing.Point(768, 4)
        Me.btnGuardarOrden.Name = "btnGuardarOrden"
        Me.btnGuardarOrden.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarOrden.TabIndex = 21
        Me.btnGuardarOrden.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(827, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 22
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'pnlMaterialesSolicitados
        '
        Me.pnlMaterialesSolicitados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        'pnlMaterialesSolicitados.ClientArea
        '
        Me.pnlMaterialesSolicitados.ClientArea.Controls.Add(Me.grdListaMateriales)
        Me.pnlMaterialesSolicitados.Location = New System.Drawing.Point(0, 214)
        Me.pnlMaterialesSolicitados.Name = "pnlMaterialesSolicitados"
        Me.pnlMaterialesSolicitados.Size = New System.Drawing.Size(880, 258)
        Me.pnlMaterialesSolicitados.TabIndex = 156
        '
        'grdListaMateriales
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaMateriales.DisplayLayout.Appearance = Appearance1
        Me.grdListaMateriales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaMateriales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaMateriales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaMateriales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaMateriales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaMateriales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaMateriales.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListaMateriales.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdListaMateriales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaMateriales.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaMateriales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaMateriales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaMateriales.Location = New System.Drawing.Point(0, 0)
        Me.grdListaMateriales.Name = "grdListaMateriales"
        Me.grdListaMateriales.Size = New System.Drawing.Size(880, 258)
        Me.grdListaMateriales.TabIndex = 2000
        '
        'lblSubTotal
        '
        Me.lblSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSubTotal.AutoSize = True
        Me.lblSubTotal.Location = New System.Drawing.Point(414, 479)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(50, 13)
        Me.lblSubTotal.TabIndex = 157
        Me.lblSubTotal.Text = "SubTotal"
        '
        'lblIVA
        '
        Me.lblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblIVA.AutoSize = True
        Me.lblIVA.Location = New System.Drawing.Point(576, 479)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(24, 13)
        Me.lblIVA.TabIndex = 158
        Me.lblIVA.Text = "IVA"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(712, 479)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(31, 13)
        Me.lblTotal.TabIndex = 159
        Me.lblTotal.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(753, 475)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 160
        '
        'txtIVA
        '
        Me.txtIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtIVA.Enabled = False
        Me.txtIVA.Location = New System.Drawing.Point(612, 475)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(100, 20)
        Me.txtIVA.TabIndex = 161
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Location = New System.Drawing.Point(474, 475)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtSubTotal.TabIndex = 15
        '
        'lblFechaEntregaEstimada
        '
        Me.lblFechaEntregaEstimada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFechaEntregaEstimada.AutoSize = True
        Me.lblFechaEntregaEstimada.Location = New System.Drawing.Point(80, 510)
        Me.lblFechaEntregaEstimada.Name = "lblFechaEntregaEstimada"
        Me.lblFechaEntregaEstimada.Size = New System.Drawing.Size(138, 13)
        Me.lblFechaEntregaEstimada.TabIndex = 163
        Me.lblFechaEntregaEstimada.Text = "Fecha de Entrega Estimada"
        '
        'lblFechaPagoEstimada
        '
        Me.lblFechaPagoEstimada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFechaPagoEstimada.AutoSize = True
        Me.lblFechaPagoEstimada.Location = New System.Drawing.Point(435, 510)
        Me.lblFechaPagoEstimada.Name = "lblFechaPagoEstimada"
        Me.lblFechaPagoEstimada.Size = New System.Drawing.Size(126, 13)
        Me.lblFechaPagoEstimada.TabIndex = 164
        Me.lblFechaPagoEstimada.Text = "Fecha de Pago Estimada"
        '
        'dtpFechaEntregaEstimada
        '
        Me.dtpFechaEntregaEstimada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaEntregaEstimada.Enabled = False
        Me.dtpFechaEntregaEstimada.Location = New System.Drawing.Point(221, 506)
        Me.dtpFechaEntregaEstimada.Name = "dtpFechaEntregaEstimada"
        Me.dtpFechaEntregaEstimada.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaEntregaEstimada.TabIndex = 165
        '
        'dtpFechaPagoEstimada
        '
        Me.dtpFechaPagoEstimada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaPagoEstimada.Enabled = False
        Me.dtpFechaPagoEstimada.Location = New System.Drawing.Point(564, 506)
        Me.dtpFechaPagoEstimada.Name = "dtpFechaPagoEstimada"
        Me.dtpFechaPagoEstimada.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaPagoEstimada.TabIndex = 166
        '
        'cbxUsarDireccionNave
        '
        Me.cbxUsarDireccionNave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxUsarDireccionNave.AutoSize = True
        Me.cbxUsarDireccionNave.Checked = True
        Me.cbxUsarDireccionNave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxUsarDireccionNave.Location = New System.Drawing.Point(26, 533)
        Me.cbxUsarDireccionNave.Name = "cbxUsarDireccionNave"
        Me.cbxUsarDireccionNave.Size = New System.Drawing.Size(192, 17)
        Me.cbxUsarDireccionNave.TabIndex = 12
        Me.cbxUsarDireccionNave.Text = "Usar Dirección Asociada a la Nave"
        Me.cbxUsarDireccionNave.UseVisualStyleBackColor = True
        '
        'lblCalle
        '
        Me.lblCalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCalle.AutoSize = True
        Me.lblCalle.Location = New System.Drawing.Point(24, 574)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(30, 13)
        Me.lblCalle.TabIndex = 168
        Me.lblCalle.Text = "Calle"
        '
        'lblPais
        '
        Me.lblPais.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(524, 575)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(29, 13)
        Me.lblPais.TabIndex = 16
        Me.lblPais.Text = "País"
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(685, 543)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 170
        Me.lblEstado.Text = "Estado"
        '
        'lblCiudad
        '
        Me.lblCiudad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Location = New System.Drawing.Point(685, 576)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(40, 13)
        Me.lblCiudad.TabIndex = 171
        Me.lblCiudad.Text = "Ciudad"
        '
        'lblCodigoPostal
        '
        Me.lblCodigoPostal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCodigoPostal.AutoSize = True
        Me.lblCodigoPostal.Location = New System.Drawing.Point(481, 546)
        Me.lblCodigoPostal.Name = "lblCodigoPostal"
        Me.lblCodigoPostal.Size = New System.Drawing.Size(72, 13)
        Me.lblCodigoPostal.TabIndex = 172
        Me.lblCodigoPostal.Text = "Codigo Postal"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(23, 601)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 173
        Me.lblObservaciones.Text = "Observaciones"
        '
        'txtCalle
        '
        Me.txtCalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCalle.Enabled = False
        Me.txtCalle.Location = New System.Drawing.Point(57, 571)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(240, 20)
        Me.txtCalle.TabIndex = 13
        '
        'cmbPais
        '
        Me.cmbPais.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.ItemHeight = 13
        Me.cmbPais.Location = New System.Drawing.Point(556, 571)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(123, 21)
        Me.cmbPais.TabIndex = 17
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.ItemHeight = 13
        Me.cmbEstado.Location = New System.Drawing.Point(728, 539)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(125, 21)
        Me.cmbEstado.TabIndex = 18
        '
        'cmbCiudad
        '
        Me.cmbCiudad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(728, 572)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(125, 21)
        Me.cmbCiudad.TabIndex = 19
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCodigoPostal.Location = New System.Drawing.Point(556, 543)
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(123, 20)
        Me.txtCodigoPostal.TabIndex = 16
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(26, 613)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(690, 20)
        Me.txtObservaciones.TabIndex = 20
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(36, 76)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(42, 13)
        Me.lblEstatus.TabIndex = 180
        Me.lblEstatus.Text = "Estatus"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(45, 109)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 181
        Me.lblNave.Text = "Nave"
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(690, 74)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(29, 13)
        Me.lblFolio.TabIndex = 182
        Me.lblFolio.Text = "Folio"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(256, 109)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(60, 13)
        Me.lblProveedor.TabIndex = 183
        Me.lblProveedor.Text = "*Proveedor"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(279, 77)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblFecha.TabIndex = 184
        Me.lblFecha.Text = "Fecha"
        '
        'lblPlazo
        '
        Me.lblPlazo.AutoSize = True
        Me.lblPlazo.Location = New System.Drawing.Point(40, 143)
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Size = New System.Drawing.Size(37, 13)
        Me.lblPlazo.TabIndex = 185
        Me.lblPlazo.Text = "*Plazo"
        '
        'lblPrioridad
        '
        Me.lblPrioridad.AutoSize = True
        Me.lblPrioridad.Location = New System.Drawing.Point(461, 76)
        Me.lblPrioridad.Name = "lblPrioridad"
        Me.lblPrioridad.Size = New System.Drawing.Size(52, 13)
        Me.lblPrioridad.TabIndex = 186
        Me.lblPrioridad.Text = "*Prioridad"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(242, 143)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(74, 13)
        Me.lblRazonSocial.TabIndex = 187
        Me.lblRazonSocial.Text = "*Razón Social"
        '
        'lblMaterialSolicitado
        '
        Me.lblMaterialSolicitado.AutoSize = True
        Me.lblMaterialSolicitado.Location = New System.Drawing.Point(-3, 198)
        Me.lblMaterialSolicitado.Name = "lblMaterialSolicitado"
        Me.lblMaterialSolicitado.Size = New System.Drawing.Size(109, 13)
        Me.lblMaterialSolicitado.TabIndex = 192
        Me.lblMaterialSolicitado.Text = "Materiales Solicitados"
        '
        'txtEstatus
        '
        Me.txtEstatus.Enabled = False
        Me.txtEstatus.Location = New System.Drawing.Point(81, 73)
        Me.txtEstatus.Name = "txtEstatus"
        Me.txtEstatus.Size = New System.Drawing.Size(142, 20)
        Me.txtEstatus.TabIndex = 26
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Location = New System.Drawing.Point(319, 74)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(137, 20)
        Me.txtFecha.TabIndex = 27
        '
        'cmbPlazo
        '
        Me.cmbPlazo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlazo.FormattingEnabled = True
        Me.cmbPlazo.ItemHeight = 13
        Me.cmbPlazo.Location = New System.Drawing.Point(80, 140)
        Me.cmbPlazo.Name = "cmbPlazo"
        Me.cmbPlazo.Size = New System.Drawing.Size(142, 21)
        Me.cmbPlazo.TabIndex = 4
        '
        'cmbPrioridad
        '
        Me.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrioridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrioridad.FormattingEnabled = True
        Me.cmbPrioridad.Items.AddRange(New Object() {"ALTA", "MEDIA", "BAJA"})
        Me.cmbPrioridad.Location = New System.Drawing.Point(516, 73)
        Me.cmbPrioridad.Name = "cmbPrioridad"
        Me.cmbPrioridad.Size = New System.Drawing.Size(142, 21)
        Me.cmbPrioridad.TabIndex = 1
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Location = New System.Drawing.Point(319, 140)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(339, 21)
        Me.cmbRazonSocial.TabIndex = 5
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Location = New System.Drawing.Point(185, 174)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker3.TabIndex = 202
        '
        'lblProgramadel
        '
        Me.lblProgramadel.AutoSize = True
        Me.lblProgramadel.Location = New System.Drawing.Point(115, 177)
        Me.lblProgramadel.Name = "lblProgramadel"
        Me.lblProgramadel.Size = New System.Drawing.Size(67, 13)
        Me.lblProgramadel.TabIndex = 190
        Me.lblProgramadel.Text = "Programa de"
        '
        'lblProgramaal
        '
        Me.lblProgramaal.AutoSize = True
        Me.lblProgramaal.Location = New System.Drawing.Point(393, 177)
        Me.lblProgramaal.Name = "lblProgramaal"
        Me.lblProgramaal.Size = New System.Drawing.Size(13, 13)
        Me.lblProgramaal.TabIndex = 191
        Me.lblProgramaal.Text = "a"
        '
        'dtpProgramadel
        '
        Me.dtpProgramadel.Location = New System.Drawing.Point(185, 174)
        Me.dtpProgramadel.MinDate = New Date(2016, 3, 5, 0, 0, 0, 0)
        Me.dtpProgramadel.Name = "dtpProgramadel"
        Me.dtpProgramadel.Size = New System.Drawing.Size(200, 20)
        Me.dtpProgramadel.TabIndex = 8
        Me.dtpProgramadel.Value = New Date(2016, 3, 5, 0, 0, 0, 0)
        '
        'dtpProgramaal
        '
        Me.dtpProgramaal.Location = New System.Drawing.Point(409, 174)
        Me.dtpProgramaal.MinDate = New Date(2016, 3, 5, 0, 0, 0, 0)
        Me.dtpProgramaal.Name = "dtpProgramaal"
        Me.dtpProgramaal.Size = New System.Drawing.Size(200, 20)
        Me.dtpProgramaal.TabIndex = 9
        Me.dtpProgramaal.Value = New Date(2016, 3, 5, 0, 0, 0, 0)
        '
        'gbxDocumento
        '
        Me.gbxDocumento.Controls.Add(Me.rdoRemision)
        Me.gbxDocumento.Controls.Add(Me.rdoFactura)
        Me.gbxDocumento.Location = New System.Drawing.Point(698, 100)
        Me.gbxDocumento.Name = "gbxDocumento"
        Me.gbxDocumento.Size = New System.Drawing.Size(142, 39)
        Me.gbxDocumento.TabIndex = 6
        Me.gbxDocumento.TabStop = False
        Me.gbxDocumento.Text = "Documento"
        '
        'rdoRemision
        '
        Me.rdoRemision.AutoSize = True
        Me.rdoRemision.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rdoRemision.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdoRemision.Location = New System.Drawing.Point(71, 19)
        Me.rdoRemision.Name = "rdoRemision"
        Me.rdoRemision.Size = New System.Drawing.Size(68, 17)
        Me.rdoRemision.TabIndex = 7
        Me.rdoRemision.TabStop = True
        Me.rdoRemision.Text = "Remisión"
        Me.rdoRemision.UseVisualStyleBackColor = True
        '
        'rdoFactura
        '
        Me.rdoFactura.AutoSize = True
        Me.rdoFactura.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.rdoFactura.Checked = True
        Me.rdoFactura.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdoFactura.Location = New System.Drawing.Point(9, 19)
        Me.rdoFactura.Name = "rdoFactura"
        Me.rdoFactura.Size = New System.Drawing.Size(61, 17)
        Me.rdoFactura.TabIndex = 6
        Me.rdoFactura.TabStop = True
        Me.rdoFactura.Text = "Factura"
        Me.rdoFactura.UseVisualStyleBackColor = True
        '
        'lblAgregar
        '
        Me.lblAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAgregar.AutoSize = True
        Me.lblAgregar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAgregar.Location = New System.Drawing.Point(715, 182)
        Me.lblAgregar.Name = "lblAgregar"
        Me.lblAgregar.Size = New System.Drawing.Size(44, 13)
        Me.lblAgregar.TabIndex = 209
        Me.lblAgregar.Text = "Agregar"
        '
        'lblQuitar
        '
        Me.lblQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuitar.AutoSize = True
        Me.lblQuitar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblQuitar.Location = New System.Drawing.Point(786, 182)
        Me.lblQuitar.Name = "lblQuitar"
        Me.lblQuitar.Size = New System.Drawing.Size(35, 13)
        Me.lblQuitar.TabIndex = 211
        Me.lblQuitar.Text = "Quitar"
        '
        'lblAMaterial
        '
        Me.lblAMaterial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMaterial.AutoSize = True
        Me.lblAMaterial.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAMaterial.Location = New System.Drawing.Point(715, 195)
        Me.lblAMaterial.Name = "lblAMaterial"
        Me.lblAMaterial.Size = New System.Drawing.Size(44, 13)
        Me.lblAMaterial.TabIndex = 212
        Me.lblAMaterial.Text = "Material"
        '
        'lblQMaterial
        '
        Me.lblQMaterial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQMaterial.AutoSize = True
        Me.lblQMaterial.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblQMaterial.Location = New System.Drawing.Point(781, 195)
        Me.lblQMaterial.Name = "lblQMaterial"
        Me.lblQMaterial.Size = New System.Drawing.Size(44, 13)
        Me.lblQMaterial.TabIndex = 213
        Me.lblQMaterial.Text = "Material"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(81, 106)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(141, 21)
        Me.cmbNave.TabIndex = 2
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(319, 106)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(339, 21)
        Me.cmbProveedor.TabIndex = 3
        '
        'lblFolioAsignado
        '
        Me.lblFolioAsignado.AutoSize = True
        Me.lblFolioAsignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioAsignado.ForeColor = System.Drawing.Color.Red
        Me.lblFolioAsignado.Location = New System.Drawing.Point(717, 70)
        Me.lblFolioAsignado.Name = "lblFolioAsignado"
        Me.lblFolioAsignado.Size = New System.Drawing.Size(132, 20)
        Me.lblFolioAsignado.TabIndex = 216
        Me.lblFolioAsignado.Text = "POR ASIGNAR"
        '
        'txtColonia
        '
        Me.txtColonia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtColonia.Enabled = False
        Me.txtColonia.Location = New System.Drawing.Point(353, 574)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(123, 20)
        Me.txtColonia.TabIndex = 15
        '
        'lblColonia
        '
        Me.lblColonia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblColonia.AutoSize = True
        Me.lblColonia.Location = New System.Drawing.Point(308, 578)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(42, 13)
        Me.lblColonia.TabIndex = 218
        Me.lblColonia.Text = "Colonia"
        '
        'txtNumero
        '
        Me.txtNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNumero.Enabled = False
        Me.txtNumero.Location = New System.Drawing.Point(353, 543)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(123, 20)
        Me.txtNumero.TabIndex = 14
        '
        'lblNumero
        '
        Me.lblNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNumero.AutoSize = True
        Me.lblNumero.Location = New System.Drawing.Point(306, 546)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(44, 13)
        Me.lblNumero.TabIndex = 220
        Me.lblNumero.Text = "Numero"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(460, 479)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "$"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(597, 479)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 222
        Me.Label2.Text = "$"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(739, 479)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 223
        Me.Label3.Text = "$"
        '
        'btnQuitar
        '
        Me.btnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Image)
        Me.btnQuitar.Location = New System.Drawing.Point(786, 147)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(32, 32)
        Me.btnQuitar.TabIndex = 11
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Image = Global.Proveedor.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregar.Location = New System.Drawing.Point(721, 147)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(812, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 158
        Me.PictureBox1.TabStop = False
        '
        'CapturaOrdenesDeCompraForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(880, 700)
        Me.Controls.Add(Me.txtOcid)
        Me.Controls.Add(Me.txtModificar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtIdOC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNumero)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.cmbProveedor)
        Me.Controls.Add(Me.lblProveedor)
        Me.Controls.Add(Me.cmbNave)
        Me.Controls.Add(Me.lblNave)
        Me.Controls.Add(Me.txtColonia)
        Me.Controls.Add(Me.lblColonia)
        Me.Controls.Add(Me.lblFolioAsignado)
        Me.Controls.Add(Me.gbxDocumento)
        Me.Controls.Add(Me.lblQMaterial)
        Me.Controls.Add(Me.lblAMaterial)
        Me.Controls.Add(Me.lblQuitar)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.lblAgregar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dtpProgramaal)
        Me.Controls.Add(Me.dtpProgramadel)
        Me.Controls.Add(Me.DateTimePicker3)
        Me.Controls.Add(Me.cmbRazonSocial)
        Me.Controls.Add(Me.cmbPrioridad)
        Me.Controls.Add(Me.cmbPlazo)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.txtEstatus)
        Me.Controls.Add(Me.lblProgramaal)
        Me.Controls.Add(Me.lblMaterialSolicitado)
        Me.Controls.Add(Me.lblProgramadel)
        Me.Controls.Add(Me.lblRazonSocial)
        Me.Controls.Add(Me.lblPrioridad)
        Me.Controls.Add(Me.lblPlazo)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblFolio)
        Me.Controls.Add(Me.lblEstatus)
        Me.Controls.Add(Me.txtCodigoPostal)
        Me.Controls.Add(Me.cmbCiudad)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.cmbPais)
        Me.Controls.Add(Me.txtCalle)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.lblCodigoPostal)
        Me.Controls.Add(Me.lblCiudad)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.lblPais)
        Me.Controls.Add(Me.lblCalle)
        Me.Controls.Add(Me.cbxUsarDireccionNave)
        Me.Controls.Add(Me.dtpFechaPagoEstimada)
        Me.Controls.Add(Me.dtpFechaEntregaEstimada)
        Me.Controls.Add(Me.lblFechaPagoEstimada)
        Me.Controls.Add(Me.lblFechaEntregaEstimada)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.txtIVA)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblIVA)
        Me.Controls.Add(Me.lblSubTotal)
        Me.Controls.Add(Me.pnlMaterialesSolicitados)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "CapturaOrdenesDeCompraForm"
        Me.Text = "Captura Ordenes de Compra"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlMaterialesSolicitados.ClientArea.ResumeLayout(False)
        Me.pnlMaterialesSolicitados.ResumeLayout(False)
        CType(Me.grdListaMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDocumento.ResumeLayout(False)
        Me.gbxDocumento.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblcerrar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlMaterialesSolicitados As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents lblSubTotal As System.Windows.Forms.Label
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaEntregaEstimada As System.Windows.Forms.Label
    Friend WithEvents lblFechaPagoEstimada As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntregaEstimada As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaPagoEstimada As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxUsarDireccionNave As System.Windows.Forms.CheckBox
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents lblCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblGuardarOrden As System.Windows.Forms.Label
    Friend WithEvents btnGuardarOrden As System.Windows.Forms.Button
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblPlazo As System.Windows.Forms.Label
    Friend WithEvents lblPrioridad As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblMaterialSolicitado As System.Windows.Forms.Label
    Friend WithEvents txtEstatus As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents cmbPlazo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPrioridad As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProgramadel As System.Windows.Forms.Label
    Friend WithEvents lblProgramaal As System.Windows.Forms.Label
    Friend WithEvents dtpProgramadel As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpProgramaal As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbxDocumento As System.Windows.Forms.GroupBox
    Friend WithEvents rdoRemision As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFactura As System.Windows.Forms.RadioButton
    Friend WithEvents lblAgregar As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lblQuitar As System.Windows.Forms.Label
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents lblAMaterial As System.Windows.Forms.Label
    Friend WithEvents lblQMaterial As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lblFolioAsignado As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents grdListaMateriales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtIdOC As System.Windows.Forms.TextBox
    Friend WithEvents txtModificar As System.Windows.Forms.TextBox
    Friend WithEvents txtOcid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
