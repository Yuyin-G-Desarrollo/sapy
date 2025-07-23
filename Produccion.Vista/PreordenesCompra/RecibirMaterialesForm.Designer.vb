<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecibirMaterialesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecibirMaterialesForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblIdoc = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblAbreviatura = New System.Windows.Forms.Label()
        Me.lblEstatus1 = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal1 = New System.Windows.Forms.TextBox()
        Me.txtIVA1 = New System.Windows.Forms.TextBox()
        Me.txtsubTotal1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTipoOrd = New System.Windows.Forms.Label()
        Me.lblFechaEntreg = New System.Windows.Forms.Label()
        Me.lblFechaProg = New System.Windows.Forms.Label()
        Me.lblProv = New System.Windows.Forms.Label()
        Me.txtDescuento1 = New System.Windows.Forms.TextBox()
        Me.lblParesText = New System.Windows.Forms.Label()
        Me.lblNumeroOCText = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblNumeroOC = New System.Windows.Forms.Label()
        Me.lblDescuentoTitulo = New System.Windows.Forms.Label()
        Me.lblTipoDeOrden = New System.Windows.Forms.Label()
        Me.lblFechaEntrega = New System.Windows.Forms.Label()
        Me.lblFechaPrograma = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.grdOrdenCompra = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.pnlColor = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdClasificacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtTotalText = New System.Windows.Forms.TextBox()
        Me.txtDecuentoText = New System.Windows.Forms.TextBox()
        Me.txtIvaText = New System.Windows.Forms.TextBox()
        Me.txtSubtotalText = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblAbreviatura2 = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdOrdenCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        Me.pnlColor.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.Label3)
        Me.pnlEncabezado.Controls.Add(Me.lblIdoc)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1149, 63)
        Me.pnlEncabezado.TabIndex = 2030
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1081, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(887, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(188, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Recepción de Material"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(773, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 156
        Me.Label3.Text = "ID ORDEN"
        Me.Label3.Visible = False
        '
        'lblIdoc
        '
        Me.lblIdoc.AutoSize = True
        Me.lblIdoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdoc.Location = New System.Drawing.Point(867, 25)
        Me.lblIdoc.Name = "lblIdoc"
        Me.lblIdoc.Size = New System.Drawing.Size(13, 16)
        Me.lblIdoc.TabIndex = 157
        Me.lblIdoc.Text = "-"
        Me.lblIdoc.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblAbreviatura)
        Me.Panel2.Controls.Add(Me.lblEstatus1)
        Me.Panel2.Controls.Add(Me.lblDesc)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtTotal1)
        Me.Panel2.Controls.Add(Me.txtIVA1)
        Me.Panel2.Controls.Add(Me.txtsubTotal1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblTipoOrd)
        Me.Panel2.Controls.Add(Me.lblFechaEntreg)
        Me.Panel2.Controls.Add(Me.lblFechaProg)
        Me.Panel2.Controls.Add(Me.lblProv)
        Me.Panel2.Controls.Add(Me.txtDescuento1)
        Me.Panel2.Controls.Add(Me.lblParesText)
        Me.Panel2.Controls.Add(Me.lblNumeroOCText)
        Me.Panel2.Controls.Add(Me.lblPares)
        Me.Panel2.Controls.Add(Me.lblNumeroOC)
        Me.Panel2.Controls.Add(Me.lblDescuentoTitulo)
        Me.Panel2.Controls.Add(Me.lblTipoDeOrden)
        Me.Panel2.Controls.Add(Me.lblFechaEntrega)
        Me.Panel2.Controls.Add(Me.lblFechaPrograma)
        Me.Panel2.Controls.Add(Me.lblProveedor)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 63)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1149, 83)
        Me.Panel2.TabIndex = 2033
        '
        'lblAbreviatura
        '
        Me.lblAbreviatura.AutoSize = True
        Me.lblAbreviatura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbreviatura.Location = New System.Drawing.Point(666, 61)
        Me.lblAbreviatura.Name = "lblAbreviatura"
        Me.lblAbreviatura.Size = New System.Drawing.Size(13, 16)
        Me.lblAbreviatura.TabIndex = 2058
        Me.lblAbreviatura.Text = "-"
        '
        'lblEstatus1
        '
        Me.lblEstatus1.AutoSize = True
        Me.lblEstatus1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblEstatus1.Location = New System.Drawing.Point(850, 59)
        Me.lblEstatus1.Name = "lblEstatus1"
        Me.lblEstatus1.Size = New System.Drawing.Size(13, 16)
        Me.lblEstatus1.TabIndex = 158
        Me.lblEstatus1.Text = "-"
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Location = New System.Drawing.Point(671, 27)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(28, 13)
        Me.lblDesc.TabIndex = 2057
        Me.lblDesc.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(708, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 2056
        Me.Label5.Text = "%"
        '
        'txtTotal1
        '
        Me.txtTotal1.BackColor = System.Drawing.Color.AliceBlue
        Me.txtTotal1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotal1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal1.Location = New System.Drawing.Point(552, 62)
        Me.txtTotal1.MaxLength = 5
        Me.txtTotal1.Name = "txtTotal1"
        Me.txtTotal1.ReadOnly = True
        Me.txtTotal1.Size = New System.Drawing.Size(84, 13)
        Me.txtTotal1.TabIndex = 2055
        Me.txtTotal1.Text = "0"
        Me.txtTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA1
        '
        Me.txtIVA1.BackColor = System.Drawing.Color.AliceBlue
        Me.txtIVA1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIVA1.Location = New System.Drawing.Point(552, 43)
        Me.txtIVA1.MaxLength = 5
        Me.txtIVA1.Name = "txtIVA1"
        Me.txtIVA1.ReadOnly = True
        Me.txtIVA1.Size = New System.Drawing.Size(84, 13)
        Me.txtIVA1.TabIndex = 2054
        Me.txtIVA1.Text = "0"
        Me.txtIVA1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtsubTotal1
        '
        Me.txtsubTotal1.BackColor = System.Drawing.Color.AliceBlue
        Me.txtsubTotal1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtsubTotal1.Location = New System.Drawing.Point(552, 11)
        Me.txtsubTotal1.MaxLength = 5
        Me.txtsubTotal1.Name = "txtsubTotal1"
        Me.txtsubTotal1.ReadOnly = True
        Me.txtsubTotal1.Size = New System.Drawing.Size(84, 13)
        Me.txtsubTotal1.TabIndex = 2053
        Me.txtsubTotal1.Text = "0"
        Me.txtsubTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(487, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 2052
        Me.Label4.Text = "TOTAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(487, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2052
        Me.Label2.Text = "I.V.A."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(487, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 2052
        Me.Label1.Text = "Subtotal"
        '
        'lblTipoOrd
        '
        Me.lblTipoOrd.AutoSize = True
        Me.lblTipoOrd.Location = New System.Drawing.Point(136, 64)
        Me.lblTipoOrd.Name = "lblTipoOrd"
        Me.lblTipoOrd.Size = New System.Drawing.Size(10, 13)
        Me.lblTipoOrd.TabIndex = 162
        Me.lblTipoOrd.Text = "-"
        '
        'lblFechaEntreg
        '
        Me.lblFechaEntreg.AutoSize = True
        Me.lblFechaEntreg.Location = New System.Drawing.Point(136, 45)
        Me.lblFechaEntreg.Name = "lblFechaEntreg"
        Me.lblFechaEntreg.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaEntreg.TabIndex = 161
        Me.lblFechaEntreg.Text = "-"
        '
        'lblFechaProg
        '
        Me.lblFechaProg.AutoSize = True
        Me.lblFechaProg.Location = New System.Drawing.Point(136, 26)
        Me.lblFechaProg.Name = "lblFechaProg"
        Me.lblFechaProg.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaProg.TabIndex = 159
        Me.lblFechaProg.Text = "-"
        '
        'lblProv
        '
        Me.lblProv.AutoSize = True
        Me.lblProv.Location = New System.Drawing.Point(136, 9)
        Me.lblProv.Name = "lblProv"
        Me.lblProv.Size = New System.Drawing.Size(10, 13)
        Me.lblProv.TabIndex = 158
        Me.lblProv.Text = "-"
        '
        'txtDescuento1
        '
        Me.txtDescuento1.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescuento1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDescuento1.Location = New System.Drawing.Point(552, 27)
        Me.txtDescuento1.MaxLength = 5
        Me.txtDescuento1.Name = "txtDescuento1"
        Me.txtDescuento1.ReadOnly = True
        Me.txtDescuento1.Size = New System.Drawing.Size(84, 13)
        Me.txtDescuento1.TabIndex = 150
        Me.txtDescuento1.Text = "0"
        Me.txtDescuento1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblParesText
        '
        Me.lblParesText.AutoSize = True
        Me.lblParesText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesText.Location = New System.Drawing.Point(980, 28)
        Me.lblParesText.Name = "lblParesText"
        Me.lblParesText.Size = New System.Drawing.Size(13, 16)
        Me.lblParesText.TabIndex = 146
        Me.lblParesText.Text = "-"
        '
        'lblNumeroOCText
        '
        Me.lblNumeroOCText.AutoSize = True
        Me.lblNumeroOCText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroOCText.ForeColor = System.Drawing.Color.DarkRed
        Me.lblNumeroOCText.Location = New System.Drawing.Point(980, 8)
        Me.lblNumeroOCText.Name = "lblNumeroOCText"
        Me.lblNumeroOCText.Size = New System.Drawing.Size(13, 16)
        Me.lblNumeroOCText.TabIndex = 145
        Me.lblNumeroOCText.Text = "-"
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.Location = New System.Drawing.Point(850, 28)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(59, 16)
        Me.lblPares.TabIndex = 144
        Me.lblPares.Text = "PARES"
        '
        'lblNumeroOC
        '
        Me.lblNumeroOC.AutoSize = True
        Me.lblNumeroOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroOC.ForeColor = System.Drawing.Color.DarkRed
        Me.lblNumeroOC.Location = New System.Drawing.Point(850, 8)
        Me.lblNumeroOC.Name = "lblNumeroOC"
        Me.lblNumeroOC.Size = New System.Drawing.Size(117, 16)
        Me.lblNumeroOC.TabIndex = 143
        Me.lblNumeroOC.Text = "NO. DE ORDEN"
        '
        'lblDescuentoTitulo
        '
        Me.lblDescuentoTitulo.AutoSize = True
        Me.lblDescuentoTitulo.Location = New System.Drawing.Point(487, 27)
        Me.lblDescuentoTitulo.Name = "lblDescuentoTitulo"
        Me.lblDescuentoTitulo.Size = New System.Drawing.Size(59, 13)
        Me.lblDescuentoTitulo.TabIndex = 141
        Me.lblDescuentoTitulo.Text = "Descuento"
        '
        'lblTipoDeOrden
        '
        Me.lblTipoDeOrden.AutoSize = True
        Me.lblTipoDeOrden.Location = New System.Drawing.Point(22, 63)
        Me.lblTipoDeOrden.Name = "lblTipoDeOrden"
        Me.lblTipoDeOrden.Size = New System.Drawing.Size(75, 13)
        Me.lblTipoDeOrden.TabIndex = 138
        Me.lblTipoDeOrden.Text = "Tipo de Orden"
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.Location = New System.Drawing.Point(22, 45)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(92, 13)
        Me.lblFechaEntrega.TabIndex = 137
        Me.lblFechaEntrega.Text = "Fecha de Entrega"
        '
        'lblFechaPrograma
        '
        Me.lblFechaPrograma.AutoSize = True
        Me.lblFechaPrograma.Location = New System.Drawing.Point(22, 26)
        Me.lblFechaPrograma.Name = "lblFechaPrograma"
        Me.lblFechaPrograma.Size = New System.Drawing.Size(100, 13)
        Me.lblFechaPrograma.TabIndex = 132
        Me.lblFechaPrograma.Text = "Fecha de Programa"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(22, 9)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedor.TabIndex = 131
        Me.lblProveedor.Text = "Proveedor"
        '
        'grdOrdenCompra
        '
        Me.grdOrdenCompra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenCompra.DisplayLayout.Appearance = Appearance1
        Me.grdOrdenCompra.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenCompra.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdOrdenCompra.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdOrdenCompra.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdOrdenCompra.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdOrdenCompra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenCompra.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdOrdenCompra.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdOrdenCompra.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdOrdenCompra.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdOrdenCompra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdOrdenCompra.Location = New System.Drawing.Point(0, 146)
        Me.grdOrdenCompra.Name = "grdOrdenCompra"
        Me.grdOrdenCompra.Size = New System.Drawing.Size(1149, 264)
        Me.grdOrdenCompra.TabIndex = 2034
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.pnlColor)
        Me.pnlInferior.Controls.Add(Me.lblGuardar)
        Me.pnlInferior.Controls.Add(Me.btnGuardar)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 516)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1149, 65)
        Me.pnlInferior.TabIndex = 2035
        '
        'pnlColor
        '
        Me.pnlColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlColor.BackColor = System.Drawing.Color.White
        Me.pnlColor.Controls.Add(Me.Panel1)
        Me.pnlColor.Controls.Add(Me.Label6)
        Me.pnlColor.Controls.Add(Me.Label7)
        Me.pnlColor.Controls.Add(Me.Panel12)
        Me.pnlColor.Location = New System.Drawing.Point(1, 1)
        Me.pnlColor.Name = "pnlColor"
        Me.pnlColor.Size = New System.Drawing.Size(285, 60)
        Me.pnlColor.TabIndex = 2046
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Location = New System.Drawing.Point(11, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(15, 14)
        Me.Panel1.TabIndex = 2044
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(174, 13)
        Me.Label6.TabIndex = 2044
        Me.Label6.Text = "Materiales agregados manualmente"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(33, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 13)
        Me.Label7.TabIndex = 2048
        Me.Label7.Text = "Materiales Cancelados"
        '
        'Panel12
        '
        Me.Panel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.Panel12.Location = New System.Drawing.Point(11, 10)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(15, 14)
        Me.Panel12.TabIndex = 2043
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(1044, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 102
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.Image = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(1047, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 101
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1095, 8)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 101
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1095, 42)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 102
        Me.lblSalir.Text = "Cerrar"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(0, 410)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(798, 100)
        Me.TabControl1.TabIndex = 2036
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdClasificacion)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(790, 74)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Totales"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdClasificacion
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClasificacion.DisplayLayout.Appearance = Appearance4
        Me.grdClasificacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClasificacion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClasificacion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClasificacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClasificacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClasificacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClasificacion.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.DarkGray
        Me.grdClasificacion.DisplayLayout.Override.RowAppearance = Appearance6
        Me.grdClasificacion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClasificacion.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdClasificacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClasificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClasificacion.Location = New System.Drawing.Point(0, 0)
        Me.grdClasificacion.Name = "grdClasificacion"
        Me.grdClasificacion.Size = New System.Drawing.Size(790, 74)
        Me.grdClasificacion.TabIndex = 2023
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtObservaciones)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(790, 74)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Observaciones"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(15, 10)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.Size = New System.Drawing.Size(816, 53)
        Me.txtObservaciones.TabIndex = 130
        '
        'txtTotalText
        '
        Me.txtTotalText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalText.Enabled = False
        Me.txtTotalText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalText.Location = New System.Drawing.Point(909, 488)
        Me.txtTotalText.Name = "txtTotalText"
        Me.txtTotalText.Size = New System.Drawing.Size(117, 22)
        Me.txtTotalText.TabIndex = 2051
        Me.txtTotalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDecuentoText
        '
        Me.txtDecuentoText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDecuentoText.Enabled = False
        Me.txtDecuentoText.Location = New System.Drawing.Point(908, 442)
        Me.txtDecuentoText.Name = "txtDecuentoText"
        Me.txtDecuentoText.Size = New System.Drawing.Size(117, 20)
        Me.txtDecuentoText.TabIndex = 2050
        Me.txtDecuentoText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaText
        '
        Me.txtIvaText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIvaText.Enabled = False
        Me.txtIvaText.Location = New System.Drawing.Point(908, 465)
        Me.txtIvaText.Name = "txtIvaText"
        Me.txtIvaText.Size = New System.Drawing.Size(117, 20)
        Me.txtIvaText.TabIndex = 2049
        Me.txtIvaText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubtotalText
        '
        Me.txtSubtotalText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotalText.Enabled = False
        Me.txtSubtotalText.Location = New System.Drawing.Point(908, 419)
        Me.txtSubtotalText.Name = "txtSubtotalText"
        Me.txtSubtotalText.Size = New System.Drawing.Size(117, 20)
        Me.txtSubtotalText.TabIndex = 2048
        Me.txtSubtotalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(836, 488)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 16)
        Me.lblTotal.TabIndex = 2047
        Me.lblTotal.Text = "TOTAL"
        '
        'lblIva
        '
        Me.lblIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIva.AutoSize = True
        Me.lblIva.Location = New System.Drawing.Point(859, 466)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(33, 13)
        Me.lblIva.TabIndex = 2046
        Me.lblIva.Text = "I.V.A."
        '
        'lblDescuento
        '
        Me.lblDescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Location = New System.Drawing.Point(833, 444)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(59, 13)
        Me.lblDescuento.TabIndex = 2045
        Me.lblDescuento.Text = "Descuento"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(847, 422)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(46, 13)
        Me.lblSubtotal.TabIndex = 2044
        Me.lblSubtotal.Text = "Subtotal"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(1213, 392)
        Me.TextBox1.MaxLength = 5
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(84, 13)
        Me.TextBox1.TabIndex = 2056
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAbreviatura2
        '
        Me.lblAbreviatura2.AutoSize = True
        Me.lblAbreviatura2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbreviatura2.Location = New System.Drawing.Point(1032, 490)
        Me.lblAbreviatura2.Name = "lblAbreviatura2"
        Me.lblAbreviatura2.Size = New System.Drawing.Size(13, 16)
        Me.lblAbreviatura2.TabIndex = 2059
        Me.lblAbreviatura2.Text = "-"
        '
        'RecibirMaterialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1149, 581)
        Me.Controls.Add(Me.lblAbreviatura2)
        Me.Controls.Add(Me.txtTotalText)
        Me.Controls.Add(Me.txtDecuentoText)
        Me.Controls.Add(Me.txtIvaText)
        Me.Controls.Add(Me.txtSubtotalText)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblIva)
        Me.Controls.Add(Me.lblDescuento)
        Me.Controls.Add(Me.lblSubtotal)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.grdOrdenCompra)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RecibirMaterialesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recepción de Material"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdOrdenCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlColor.ResumeLayout(False)
        Me.pnlColor.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblIdoc As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblParesText As System.Windows.Forms.Label
    Friend WithEvents lblNumeroOCText As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents lblNumeroOC As System.Windows.Forms.Label
    Friend WithEvents lblDescuentoTitulo As System.Windows.Forms.Label
    Friend WithEvents lblTipoDeOrden As System.Windows.Forms.Label
    Friend WithEvents lblFechaEntrega As System.Windows.Forms.Label
    Friend WithEvents lblFechaPrograma As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents grdOrdenCompra As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdClasificacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalText As System.Windows.Forms.TextBox
    Friend WithEvents txtDecuentoText As System.Windows.Forms.TextBox
    Friend WithEvents txtIvaText As System.Windows.Forms.TextBox
    Friend WithEvents txtSubtotalText As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents txtDescuento1 As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoOrd As System.Windows.Forms.Label
    Friend WithEvents lblFechaEntreg As System.Windows.Forms.Label
    Friend WithEvents lblFechaProg As System.Windows.Forms.Label
    Friend WithEvents lblProv As System.Windows.Forms.Label
    Friend WithEvents txtTotal1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA1 As System.Windows.Forms.TextBox
    Friend WithEvents txtsubTotal1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEstatus1 As System.Windows.Forms.Label
    Friend WithEvents pnlColor As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents lblAbreviatura As System.Windows.Forms.Label
    Friend WithEvents lblAbreviatura2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
