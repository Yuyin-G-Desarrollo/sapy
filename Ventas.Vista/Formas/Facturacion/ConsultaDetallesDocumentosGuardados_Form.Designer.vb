<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaDetallesDocumentosGuardados_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.lblFolioFactura = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCantidadLetra = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNumCajas = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.lblTipoIVA = New System.Windows.Forms.Label()
        Me.txtDescuentoTotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chkImprimirTienda = New System.Windows.Forms.CheckBox()
        Me.txtTienda = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtOC = New System.Windows.Forms.TextBox()
        Me.lblOC = New System.Windows.Forms.Label()
        Me.lblTextoFactura = New System.Windows.Forms.Label()
        Me.lblRFCEmisor = New System.Windows.Forms.Label()
        Me.lblTextoRFCEmisor = New System.Windows.Forms.Label()
        Me.lblRazonSocialEmisor = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.chkImprimirOC = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.lblDiasPlazo = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblRestriccionMarca = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblRestriccion = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblMontoMax = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdDescuentos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblRFCReceptor = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblRazonSocialReceptor = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblTextoRFCReceptor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.lblTextoIdDocumento = New System.Windows.Forms.Label()
        Me.lblUsoCFDI = New System.Windows.Forms.Label()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.UsuarioCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cancelados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PorConfirmar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Confirmados = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaPreparacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaEntregaProgramacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrdenCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaCaptura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PedidoSAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.STATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Agente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OTSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Seleccionar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TipoOT = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.grdDetallesDocumento = New DevExpress.XtraGrid.GridControl()
        Me.bgvDetallesDocumento = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.txt_CargoAdicional = New System.Windows.Forms.TextBox()
        Me.lbl_CargoAdicional = New System.Windows.Forms.Label()
        Me.lblTextoMensaje = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvDetallesDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFolioFactura
        '
        Me.lblFolioFactura.AutoSize = True
        Me.lblFolioFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioFactura.Location = New System.Drawing.Point(954, 83)
        Me.lblFolioFactura.Name = "lblFolioFactura"
        Me.lblFolioFactura.Size = New System.Drawing.Size(19, 13)
        Me.lblFolioFactura.TabIndex = 48
        Me.lblFolioFactura.Text = "---"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblCantidadLetra)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 108)
        Me.Panel2.MaximumSize = New System.Drawing.Size(725, 26)
        Me.Panel2.MinimumSize = New System.Drawing.Size(725, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(725, 26)
        Me.Panel2.TabIndex = 69
        '
        'lblCantidadLetra
        '
        Me.lblCantidadLetra.AutoSize = True
        Me.lblCantidadLetra.Location = New System.Drawing.Point(97, 7)
        Me.lblCantidadLetra.Name = "lblCantidadLetra"
        Me.lblCantidadLetra.Size = New System.Drawing.Size(16, 13)
        Me.lblCantidadLetra.TabIndex = 51
        Me.lblCantidadLetra.Text = "---"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "Cantidad Letra:"
        '
        'txtNumCajas
        '
        Me.txtNumCajas.Location = New System.Drawing.Point(100, 9)
        Me.txtNumCajas.MaxLength = 5
        Me.txtNumCajas.Name = "txtNumCajas"
        Me.txtNumCajas.Size = New System.Drawing.Size(47, 20)
        Me.txtNumCajas.TabIndex = 68
        Me.txtNumCajas.Text = "0"
        Me.txtNumCajas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(12, 12)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 13)
        Me.Label29.TabIndex = 67
        Me.Label29.Text = "No. Cajas:"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(800, 105)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(111, 20)
        Me.txtTotal.TabIndex = 66
        Me.txtTotal.Text = "0"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(723, 108)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 65
        Me.Label26.Text = "Total:"
        '
        'txtIVA
        '
        Me.txtIVA.Enabled = False
        Me.txtIVA.Location = New System.Drawing.Point(800, 82)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(111, 20)
        Me.txtIVA.TabIndex = 64
        Me.txtIVA.Text = "0"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTipoIVA
        '
        Me.lblTipoIVA.AutoSize = True
        Me.lblTipoIVA.Location = New System.Drawing.Point(723, 85)
        Me.lblTipoIVA.Name = "lblTipoIVA"
        Me.lblTipoIVA.Size = New System.Drawing.Size(50, 13)
        Me.lblTipoIVA.TabIndex = 63
        Me.lblTipoIVA.Text = "Más IVA:"
        '
        'txtDescuentoTotal
        '
        Me.txtDescuentoTotal.Enabled = False
        Me.txtDescuentoTotal.Location = New System.Drawing.Point(800, 59)
        Me.txtDescuentoTotal.Name = "txtDescuentoTotal"
        Me.txtDescuentoTotal.Size = New System.Drawing.Size(111, 20)
        Me.txtDescuentoTotal.TabIndex = 62
        Me.txtDescuentoTotal.Text = "0"
        Me.txtDescuentoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(723, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Descuento:"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Enabled = False
        Me.txtSubTotal.Location = New System.Drawing.Point(800, 35)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(111, 20)
        Me.txtSubTotal.TabIndex = 62
        Me.txtSubTotal.Text = "0"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(723, 39)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 13)
        Me.Label24.TabIndex = 61
        Me.Label24.Text = "Sub-Total:"
        '
        'chkImprimirTienda
        '
        Me.chkImprimirTienda.AutoSize = True
        Me.chkImprimirTienda.Enabled = False
        Me.chkImprimirTienda.Location = New System.Drawing.Point(480, 58)
        Me.chkImprimirTienda.Name = "chkImprimirTienda"
        Me.chkImprimirTienda.Size = New System.Drawing.Size(97, 17)
        Me.chkImprimirTienda.TabIndex = 59
        Me.chkImprimirTienda.Text = "Imprimir Tienda"
        Me.chkImprimirTienda.UseVisualStyleBackColor = True
        '
        'txtTienda
        '
        Me.txtTienda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTienda.Enabled = False
        Me.txtTienda.Location = New System.Drawing.Point(526, 82)
        Me.txtTienda.Name = "txtTienda"
        Me.txtTienda.Size = New System.Drawing.Size(182, 20)
        Me.txtTienda.TabIndex = 57
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(477, 85)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 13)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Tienda:"
        '
        'txtOC
        '
        Me.txtOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOC.Enabled = False
        Me.txtOC.Location = New System.Drawing.Point(526, 32)
        Me.txtOC.MaxLength = 500
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(182, 20)
        Me.txtOC.TabIndex = 55
        '
        'lblOC
        '
        Me.lblOC.AutoSize = True
        Me.lblOC.Location = New System.Drawing.Point(477, 35)
        Me.lblOC.Name = "lblOC"
        Me.lblOC.Size = New System.Drawing.Size(25, 13)
        Me.lblOC.TabIndex = 54
        Me.lblOC.Text = "OC:"
        '
        'lblTextoFactura
        '
        Me.lblTextoFactura.AutoSize = True
        Me.lblTextoFactura.Location = New System.Drawing.Point(933, 60)
        Me.lblTextoFactura.Name = "lblTextoFactura"
        Me.lblTextoFactura.Size = New System.Drawing.Size(71, 13)
        Me.lblTextoFactura.TabIndex = 49
        Me.lblTextoFactura.Text = "Folio Factura:"
        '
        'lblRFCEmisor
        '
        Me.lblRFCEmisor.AutoSize = True
        Me.lblRFCEmisor.Location = New System.Drawing.Point(427, 22)
        Me.lblRFCEmisor.Name = "lblRFCEmisor"
        Me.lblRFCEmisor.Size = New System.Drawing.Size(16, 13)
        Me.lblRFCEmisor.TabIndex = 48
        Me.lblRFCEmisor.Text = "---"
        '
        'lblTextoRFCEmisor
        '
        Me.lblTextoRFCEmisor.AutoSize = True
        Me.lblTextoRFCEmisor.Location = New System.Drawing.Point(390, 22)
        Me.lblTextoRFCEmisor.Name = "lblTextoRFCEmisor"
        Me.lblTextoRFCEmisor.Size = New System.Drawing.Size(31, 13)
        Me.lblTextoRFCEmisor.TabIndex = 49
        Me.lblTextoRFCEmisor.Text = "RFC:"
        '
        'lblRazonSocialEmisor
        '
        Me.lblRazonSocialEmisor.AutoSize = True
        Me.lblRazonSocialEmisor.Location = New System.Drawing.Point(106, 22)
        Me.lblRazonSocialEmisor.Name = "lblRazonSocialEmisor"
        Me.lblRazonSocialEmisor.Size = New System.Drawing.Size(16, 13)
        Me.lblRazonSocialEmisor.TabIndex = 48
        Me.lblRazonSocialEmisor.Text = "---"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(27, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Razón Social:"
        '
        'chkImprimirOC
        '
        Me.chkImprimirOC.AutoSize = True
        Me.chkImprimirOC.Checked = True
        Me.chkImprimirOC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImprimirOC.Enabled = False
        Me.chkImprimirOC.Location = New System.Drawing.Point(480, 7)
        Me.chkImprimirOC.Name = "chkImprimirOC"
        Me.chkImprimirOC.Size = New System.Drawing.Size(79, 17)
        Me.chkImprimirOC.TabIndex = 60
        Me.chkImprimirOC.Text = "Imprimir OC"
        Me.chkImprimirOC.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblRFCEmisor)
        Me.GroupBox3.Controls.Add(Me.lblTextoRFCEmisor)
        Me.GroupBox3.Controls.Add(Me.lblRazonSocialEmisor)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1028, 48)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Emisor"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1041, 65)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(540, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.pnlVentas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(402, 65)
        Me.Panel14.TabIndex = 3
        '
        'pnlVentas
        '
        Me.pnlVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVentas.Location = New System.Drawing.Point(0, 0)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(402, 65)
        Me.pnlVentas.TabIndex = 108
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(540, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(501, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(208, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(198, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Detalles del documento"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(418, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.AutoSize = True
        Me.lblTipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDocumento.Location = New System.Drawing.Point(733, 82)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(11, 13)
        Me.lblTipoDocumento.TabIndex = 73
        Me.lblTipoDocumento.Text = "-"
        '
        'lblDiasPlazo
        '
        Me.lblDiasPlazo.AutoSize = True
        Me.lblDiasPlazo.Location = New System.Drawing.Point(730, 37)
        Me.lblDiasPlazo.Name = "lblDiasPlazo"
        Me.lblDiasPlazo.Size = New System.Drawing.Size(13, 13)
        Me.lblDiasPlazo.TabIndex = 72
        Me.lblDiasPlazo.Text = "--"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(760, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "Días"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(684, 37)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(36, 13)
        Me.Label31.TabIndex = 70
        Me.Label31.Text = "Plazo:"
        '
        'lblRestriccionMarca
        '
        Me.lblRestriccionMarca.AutoSize = True
        Me.lblRestriccionMarca.Location = New System.Drawing.Point(525, 82)
        Me.lblRestriccionMarca.Name = "lblRestriccionMarca"
        Me.lblRestriccionMarca.Size = New System.Drawing.Size(16, 13)
        Me.lblRestriccionMarca.TabIndex = 68
        Me.lblRestriccionMarca.Text = "---"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(420, 36)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(16, 13)
        Me.lblMoneda.TabIndex = 68
        Me.lblMoneda.Text = "---"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(418, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Marcas Por Factura:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(341, 37)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(49, 13)
        Me.Label34.TabIndex = 69
        Me.Label34.Text = "Moneda:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(660, 62)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(109, 13)
        Me.Label30.TabIndex = 66
        Me.Label30.Text = "Máximo por factura $:"
        '
        'lblRestriccion
        '
        Me.lblRestriccion.AutoSize = True
        Me.lblRestriccion.Location = New System.Drawing.Point(497, 62)
        Me.lblRestriccion.Name = "lblRestriccion"
        Me.lblRestriccion.Size = New System.Drawing.Size(16, 13)
        Me.lblRestriccion.TabIndex = 63
        Me.lblRestriccion.Text = "---"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(418, 62)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(63, 13)
        Me.Label32.TabIndex = 64
        Me.Label32.Text = "Restricción:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(27, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 26)
        Me.Label14.TabIndex = 55
        Me.Label14.Text = "Descuentos en" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documento:"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblMontoMax)
        Me.Panel4.Location = New System.Drawing.Point(770, 60)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(80, 17)
        Me.Panel4.TabIndex = 67
        '
        'lblMontoMax
        '
        Me.lblMontoMax.AutoSize = True
        Me.lblMontoMax.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblMontoMax.Location = New System.Drawing.Point(67, 0)
        Me.lblMontoMax.Name = "lblMontoMax"
        Me.lblMontoMax.Size = New System.Drawing.Size(13, 13)
        Me.lblMontoMax.TabIndex = 65
        Me.lblMontoMax.Text = "0"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdDescuentos)
        Me.Panel3.Location = New System.Drawing.Point(109, 53)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(234, 53)
        Me.Panel3.TabIndex = 54
        '
        'grdDescuentos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDescuentos.DisplayLayout.Appearance = Appearance1
        Me.grdDescuentos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdDescuentos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDescuentos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDescuentos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDescuentos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDescuentos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdDescuentos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDescuentos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDescuentos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDescuentos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDescuentos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDescuentos.Location = New System.Drawing.Point(0, 0)
        Me.grdDescuentos.Name = "grdDescuentos"
        Me.grdDescuentos.Size = New System.Drawing.Size(234, 53)
        Me.grdDescuentos.TabIndex = 4
        '
        'lblRFCReceptor
        '
        Me.lblRFCReceptor.AutoSize = True
        Me.lblRFCReceptor.Location = New System.Drawing.Point(733, 18)
        Me.lblRFCReceptor.Name = "lblRFCReceptor"
        Me.lblRFCReceptor.Size = New System.Drawing.Size(16, 13)
        Me.lblRFCReceptor.TabIndex = 52
        Me.lblRFCReceptor.Text = "---"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(106, 18)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(16, 13)
        Me.lblNombreCliente.TabIndex = 48
        Me.lblNombreCliente.Text = "---"
        '
        'lblRazonSocialReceptor
        '
        Me.lblRazonSocialReceptor.AutoSize = True
        Me.lblRazonSocialReceptor.Location = New System.Drawing.Point(420, 18)
        Me.lblRazonSocialReceptor.Name = "lblRazonSocialReceptor"
        Me.lblRazonSocialReceptor.Size = New System.Drawing.Size(16, 13)
        Me.lblRazonSocialReceptor.TabIndex = 50
        Me.lblRazonSocialReceptor.Text = "---"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(341, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Razón Social:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(27, 38)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(56, 13)
        Me.Label27.TabIndex = 49
        Me.Label27.Text = "Uso CFDI:"
        '
        'lblTextoRFCReceptor
        '
        Me.lblTextoRFCReceptor.AutoSize = True
        Me.lblTextoRFCReceptor.Location = New System.Drawing.Point(684, 18)
        Me.lblTextoRFCReceptor.Name = "lblTextoRFCReceptor"
        Me.lblTextoRFCReceptor.Size = New System.Drawing.Size(31, 13)
        Me.lblTextoRFCReceptor.TabIndex = 53
        Me.lblTextoRFCReceptor.Text = "RFC:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Cliente:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblIdDocumento)
        Me.GroupBox1.Controls.Add(Me.lblTextoIdDocumento)
        Me.GroupBox1.Controls.Add(Me.lblFolioFactura)
        Me.GroupBox1.Controls.Add(Me.lblTipoDocumento)
        Me.GroupBox1.Controls.Add(Me.lblTextoFactura)
        Me.GroupBox1.Controls.Add(Me.lblDiasPlazo)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.lblRestriccionMarca)
        Me.GroupBox1.Controls.Add(Me.lblMoneda)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.lblRestriccion)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.lblRFCReceptor)
        Me.GroupBox1.Controls.Add(Me.lblUsoCFDI)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Controls.Add(Me.lblRazonSocialReceptor)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.lblTextoRFCReceptor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1028, 112)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Receptor"
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.AutoSize = True
        Me.lblIdDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdDocumento.Location = New System.Drawing.Point(954, 41)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 13)
        Me.lblIdDocumento.TabIndex = 74
        Me.lblIdDocumento.Text = "---"
        '
        'lblTextoIdDocumento
        '
        Me.lblTextoIdDocumento.AutoSize = True
        Me.lblTextoIdDocumento.Location = New System.Drawing.Point(936, 18)
        Me.lblTextoIdDocumento.Name = "lblTextoIdDocumento"
        Me.lblTextoIdDocumento.Size = New System.Drawing.Size(65, 13)
        Me.lblTextoIdDocumento.TabIndex = 75
        Me.lblTextoIdDocumento.Text = "Documento:"
        '
        'lblUsoCFDI
        '
        Me.lblUsoCFDI.AutoSize = True
        Me.lblUsoCFDI.Location = New System.Drawing.Point(106, 38)
        Me.lblUsoCFDI.Name = "lblUsoCFDI"
        Me.lblUsoCFDI.Size = New System.Drawing.Size(16, 13)
        Me.lblUsoCFDI.TabIndex = 48
        Me.lblUsoCFDI.Text = "---"
        '
        'txtMensaje
        '
        Me.txtMensaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMensaje.Enabled = False
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(100, 71)
        Me.txtMensaje.MaxLength = 500
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(371, 31)
        Me.txtMensaje.TabIndex = 53
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox3)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1041, 165)
        Me.pnlParametros.TabIndex = 26
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
        'Cancelados
        '
        Me.Cancelados.Caption = "Cancelados"
        Me.Cancelados.FieldName = "Cancelados"
        Me.Cancelados.Name = "Cancelados"
        Me.Cancelados.OptionsColumn.AllowEdit = False
        Me.Cancelados.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.Cancelados.Visible = True
        Me.Cancelados.VisibleIndex = 15
        Me.Cancelados.Width = 80
        '
        'PorConfirmar
        '
        Me.PorConfirmar.Caption = "Por Confirmar"
        Me.PorConfirmar.FieldName = "PorConfirmar"
        Me.PorConfirmar.Name = "PorConfirmar"
        Me.PorConfirmar.OptionsColumn.AllowEdit = False
        Me.PorConfirmar.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.PorConfirmar.Visible = True
        Me.PorConfirmar.VisibleIndex = 14
        Me.PorConfirmar.Width = 90
        '
        'Confirmados
        '
        Me.Confirmados.Caption = "Confirmados"
        Me.Confirmados.FieldName = "Confirmados"
        Me.Confirmados.Name = "Confirmados"
        Me.Confirmados.OptionsColumn.AllowEdit = False
        Me.Confirmados.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.Confirmados.Visible = True
        Me.Confirmados.VisibleIndex = 13
        Me.Confirmados.Width = 80
        '
        'Cantidad
        '
        Me.Cantidad.Caption = "Cantidad"
        Me.Cantidad.FieldName = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.OptionsColumn.AllowEdit = False
        Me.Cantidad.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.Cantidad.Visible = True
        Me.Cantidad.VisibleIndex = 12
        Me.Cantidad.Width = 80
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
        'Seleccionar
        '
        Me.Seleccionar.Caption = """"
        Me.Seleccionar.FieldName = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Visible = True
        Me.Seleccionar.VisibleIndex = 0
        Me.Seleccionar.Width = 35
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdDetallesDocumento
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView1.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
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
        'grdDetallesDocumento
        '
        Me.grdDetallesDocumento.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdDetallesDocumento.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdDetallesDocumento.Location = New System.Drawing.Point(0, 230)
        Me.grdDetallesDocumento.MainView = Me.bgvDetallesDocumento
        Me.grdDetallesDocumento.Name = "grdDetallesDocumento"
        Me.grdDetallesDocumento.Size = New System.Drawing.Size(1041, 184)
        Me.grdDetallesDocumento.TabIndex = 28
        Me.grdDetallesDocumento.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvDetallesDocumento, Me.grdDetallesOT, Me.GridView1})
        '
        'bgvDetallesDocumento
        '
        Me.bgvDetallesDocumento.GridControl = Me.grdDetallesDocumento
        Me.bgvDetallesDocumento.Name = "bgvDetallesDocumento"
        Me.bgvDetallesDocumento.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvDetallesDocumento.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvDetallesDocumento.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.bgvDetallesDocumento.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvDetallesDocumento.OptionsSelection.MultiSelect = True
        Me.bgvDetallesDocumento.OptionsView.ShowAutoFilterRow = True
        Me.bgvDetallesDocumento.OptionsView.ShowFooter = True
        Me.bgvDetallesDocumento.OptionsView.ShowGroupPanel = False
        '
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdDetallesDocumento
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdDetallesDocumento)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1041, 548)
        Me.Panel1.TabIndex = 1
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Controls.Add(Me.txtNumCajas)
        Me.pnlPie.Controls.Add(Me.Label29)
        Me.pnlPie.Controls.Add(Me.txtTotal)
        Me.pnlPie.Controls.Add(Me.Label26)
        Me.pnlPie.Controls.Add(Me.txtIVA)
        Me.pnlPie.Controls.Add(Me.lblTipoIVA)
        Me.pnlPie.Controls.Add(Me.txtDescuentoTotal)
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.txt_CargoAdicional)
        Me.pnlPie.Controls.Add(Me.lbl_CargoAdicional)
        Me.pnlPie.Controls.Add(Me.txtSubTotal)
        Me.pnlPie.Controls.Add(Me.Label24)
        Me.pnlPie.Controls.Add(Me.chkImprimirOC)
        Me.pnlPie.Controls.Add(Me.chkImprimirTienda)
        Me.pnlPie.Controls.Add(Me.txtTienda)
        Me.pnlPie.Controls.Add(Me.Label23)
        Me.pnlPie.Controls.Add(Me.txtOC)
        Me.pnlPie.Controls.Add(Me.lblOC)
        Me.pnlPie.Controls.Add(Me.txtMensaje)
        Me.pnlPie.Controls.Add(Me.lblTextoMensaje)
        Me.pnlPie.Controls.Add(Me.txtObservaciones)
        Me.pnlPie.Controls.Add(Me.Label20)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 414)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1041, 134)
        Me.pnlPie.TabIndex = 27
        '
        'txt_CargoAdicional
        '
        Me.txt_CargoAdicional.Enabled = False
        Me.txt_CargoAdicional.Location = New System.Drawing.Point(800, 9)
        Me.txt_CargoAdicional.Name = "txt_CargoAdicional"
        Me.txt_CargoAdicional.Size = New System.Drawing.Size(111, 20)
        Me.txt_CargoAdicional.TabIndex = 62
        Me.txt_CargoAdicional.Text = "0"
        Me.txt_CargoAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_CargoAdicional
        '
        Me.lbl_CargoAdicional.AutoSize = True
        Me.lbl_CargoAdicional.Location = New System.Drawing.Point(726, 7)
        Me.lbl_CargoAdicional.Name = "lbl_CargoAdicional"
        Me.lbl_CargoAdicional.Size = New System.Drawing.Size(53, 26)
        Me.lbl_CargoAdicional.TabIndex = 61
        Me.lbl_CargoAdicional.Text = "   Cargo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Adicional:"
        '
        'lblTextoMensaje
        '
        Me.lblTextoMensaje.AutoSize = True
        Me.lblTextoMensaje.Location = New System.Drawing.Point(12, 80)
        Me.lblTextoMensaje.Name = "lblTextoMensaje"
        Me.lblTextoMensaje.Size = New System.Drawing.Size(50, 13)
        Me.lblTextoMensaje.TabIndex = 52
        Me.lblTextoMensaje.Text = "Mensaje:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Enabled = False
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(100, 33)
        Me.txtObservaciones.MaxLength = 500
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(371, 31)
        Me.txtObservaciones.TabIndex = 51
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 42)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 13)
        Me.Label20.TabIndex = 50
        Me.Label20.Text = "Observaciones:"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(927, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(114, 134)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(22, 59)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(17, 91)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(69, 58)
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
        Me.lblCerrar.Location = New System.Drawing.Point(68, 90)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'ConsultaDetallesDocumentosGuardados_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 548)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ConsultaDetallesDocumentosGuardados_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalles del documento"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvDetallesDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFolioFactura As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCantidadLetra As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNumCajas As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoIVA As System.Windows.Forms.Label
    Friend WithEvents txtDescuentoTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents chkImprimirTienda As System.Windows.Forms.CheckBox
    Friend WithEvents txtTienda As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
    Friend WithEvents lblOC As System.Windows.Forms.Label
    Friend WithEvents lblTextoFactura As System.Windows.Forms.Label
    Friend WithEvents lblRFCEmisor As System.Windows.Forms.Label
    Friend WithEvents lblTextoRFCEmisor As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocialEmisor As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents chkImprimirOC As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents pnlVentas As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents lblDiasPlazo As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblRestriccionMarca As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblRestriccion As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblMontoMax As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblRFCReceptor As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocialReceptor As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblTextoRFCReceptor As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsoCFDI As System.Windows.Forms.Label
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents UsuarioCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cancelados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PorConfirmar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Confirmados As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaPreparacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaEntregaProgramacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrdenCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaCaptura As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PedidoSAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents STATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Agente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OTSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Seleccionar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TipoOT As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents grdDetallesDocumento As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvDetallesDocumento As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblTextoMensaje As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdDescuentos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblIdDocumento As System.Windows.Forms.Label
    Friend WithEvents lblTextoIdDocumento As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents txt_CargoAdicional As TextBox
    Friend WithEvents lbl_CargoAdicional As Label
End Class
