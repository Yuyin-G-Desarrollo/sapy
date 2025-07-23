<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NotasCreditoDevolucionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotasCreditoDevolucionForm))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.lbleliminarfila = New System.Windows.Forms.Label()
        Me.btnlEliminarFila = New System.Windows.Forms.Button()
        Me.lblCargarDocumentos = New System.Windows.Forms.Label()
        Me.btnCargaDocumentos = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRFCCliente = New System.Windows.Forms.TextBox()
        Me.lblidclienteSICY = New System.Windows.Forms.Label()
        Me.txtClientes = New System.Windows.Forms.TextBox()
        Me.lblrfcidcliente = New System.Windows.Forms.Label()
        Me.txtrazonSocialCliente = New System.Windows.Forms.TextBox()
        Me.lblidCliente = New System.Windows.Forms.Label()
        Me.lblidempresa = New System.Windows.Forms.Label()
        Me.lblTTotal = New System.Windows.Forms.Label()
        Me.lblTIva = New System.Windows.Forms.Label()
        Me.lblTSubtotal = New System.Windows.Forms.Label()
        Me.CmbConcepto = New System.Windows.Forms.ComboBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNotaCredito = New System.Windows.Forms.Label()
        Me.lblRFCCliente = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblRazSocial = New System.Windows.Forms.Label()
        Me.lblsignoPorciento = New System.Windows.Forms.Label()
        Me.lblDescCxc = New System.Windows.Forms.Label()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.txtDescuentoCXC = New System.Windows.Forms.TextBox()
        Me.txtiva = New System.Windows.Forms.TextBox()
        Me.gpbFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.pnlOcultaFiltros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.gpTipoNC = New System.Windows.Forms.GroupBox()
        Me.rdRemision = New System.Windows.Forms.RadioButton()
        Me.rdFactura = New System.Windows.Forms.RadioButton()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblguardar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdNotasCreditoCliente = New DevExpress.XtraGrid.GridControl()
        Me.wvNotasCreditoCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lbl_cliente_sicy = New System.Windows.Forms.Label()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcciones.SuspendLayout()
        Me.gpbFecha.SuspendLayout()
        Me.pnlOcultaFiltros.SuspendLayout()
        Me.gpTipoNC.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdNotasCreditoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wvNotasCreditoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.lbleliminarfila)
        Me.pnlBanner.Controls.Add(Me.btnlEliminarFila)
        Me.pnlBanner.Controls.Add(Me.lblCargarDocumentos)
        Me.pnlBanner.Controls.Add(Me.btnCargaDocumentos)
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(1000, 63)
        Me.pnlBanner.TabIndex = 63
        '
        'lbleliminarfila
        '
        Me.lbleliminarfila.AutoSize = True
        Me.lbleliminarfila.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbleliminarfila.Location = New System.Drawing.Point(119, 42)
        Me.lbleliminarfila.Name = "lbleliminarfila"
        Me.lbleliminarfila.Size = New System.Drawing.Size(62, 13)
        Me.lbleliminarfila.TabIndex = 115
        Me.lbleliminarfila.Text = "Eliminar Fila"
        Me.lbleliminarfila.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnlEliminarFila
        '
        Me.btnlEliminarFila.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnlEliminarFila.Image = Global.Cobranza.Vista.My.Resources.Resources.cancelar_32
        Me.btnlEliminarFila.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnlEliminarFila.Location = New System.Drawing.Point(133, 7)
        Me.btnlEliminarFila.Name = "btnlEliminarFila"
        Me.btnlEliminarFila.Size = New System.Drawing.Size(32, 32)
        Me.btnlEliminarFila.TabIndex = 114
        Me.btnlEliminarFila.UseVisualStyleBackColor = True
        '
        'lblCargarDocumentos
        '
        Me.lblCargarDocumentos.AutoSize = True
        Me.lblCargarDocumentos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCargarDocumentos.Location = New System.Drawing.Point(12, 42)
        Me.lblCargarDocumentos.Name = "lblCargarDocumentos"
        Me.lblCargarDocumentos.Size = New System.Drawing.Size(101, 13)
        Me.lblCargarDocumentos.TabIndex = 111
        Me.lblCargarDocumentos.Text = "Cargar Documentos"
        Me.lblCargarDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCargaDocumentos
        '
        Me.btnCargaDocumentos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCargaDocumentos.Image = CType(resources.GetObject("btnCargaDocumentos.Image"), System.Drawing.Image)
        Me.btnCargaDocumentos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCargaDocumentos.Location = New System.Drawing.Point(46, 7)
        Me.btnCargaDocumentos.Name = "btnCargaDocumentos"
        Me.btnCargaDocumentos.Size = New System.Drawing.Size(32, 32)
        Me.btnCargaDocumentos.TabIndex = 1
        Me.btnCargaDocumentos.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(714, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(286, 63)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(218, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(56, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(144, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Notas de Crédito"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlAcciones.Controls.Add(Me.lbl_cliente_sicy)
        Me.pnlAcciones.Controls.Add(Me.Label2)
        Me.pnlAcciones.Controls.Add(Me.txtRFCCliente)
        Me.pnlAcciones.Controls.Add(Me.lblidclienteSICY)
        Me.pnlAcciones.Controls.Add(Me.txtClientes)
        Me.pnlAcciones.Controls.Add(Me.lblrfcidcliente)
        Me.pnlAcciones.Controls.Add(Me.txtrazonSocialCliente)
        Me.pnlAcciones.Controls.Add(Me.lblidCliente)
        Me.pnlAcciones.Controls.Add(Me.lblidempresa)
        Me.pnlAcciones.Controls.Add(Me.lblTTotal)
        Me.pnlAcciones.Controls.Add(Me.lblTIva)
        Me.pnlAcciones.Controls.Add(Me.lblTSubtotal)
        Me.pnlAcciones.Controls.Add(Me.CmbConcepto)
        Me.pnlAcciones.Controls.Add(Me.lblFolio)
        Me.pnlAcciones.Controls.Add(Me.lblSerie)
        Me.pnlAcciones.Controls.Add(Me.cmbRazonSocial)
        Me.pnlAcciones.Controls.Add(Me.lblTotal)
        Me.pnlAcciones.Controls.Add(Me.lblSubtotal)
        Me.pnlAcciones.Controls.Add(Me.Label1)
        Me.pnlAcciones.Controls.Add(Me.lblNotaCredito)
        Me.pnlAcciones.Controls.Add(Me.lblRFCCliente)
        Me.pnlAcciones.Controls.Add(Me.lblCliente)
        Me.pnlAcciones.Controls.Add(Me.lblRazSocial)
        Me.pnlAcciones.Controls.Add(Me.lblsignoPorciento)
        Me.pnlAcciones.Controls.Add(Me.lblDescCxc)
        Me.pnlAcciones.Controls.Add(Me.lblIva)
        Me.pnlAcciones.Controls.Add(Me.lblMoneda)
        Me.pnlAcciones.Controls.Add(Me.txtDescuentoCXC)
        Me.pnlAcciones.Controls.Add(Me.txtiva)
        Me.pnlAcciones.Controls.Add(Me.gpbFecha)
        Me.pnlAcciones.Controls.Add(Me.cmbMoneda)
        Me.pnlAcciones.Controls.Add(Me.lblConcepto)
        Me.pnlAcciones.Controls.Add(Me.pnlOcultaFiltros)
        Me.pnlAcciones.Controls.Add(Me.gpTipoNC)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 63)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1000, 206)
        Me.pnlAcciones.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(421, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "RFC Cliente:"
        '
        'txtRFCCliente
        '
        Me.txtRFCCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRFCCliente.Location = New System.Drawing.Point(493, 164)
        Me.txtRFCCliente.MaxLength = 50
        Me.txtRFCCliente.Name = "txtRFCCliente"
        Me.txtRFCCliente.ReadOnly = True
        Me.txtRFCCliente.Size = New System.Drawing.Size(272, 20)
        Me.txtRFCCliente.TabIndex = 189
        Me.txtRFCCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblidclienteSICY
        '
        Me.lblidclienteSICY.AutoSize = True
        Me.lblidclienteSICY.Location = New System.Drawing.Point(785, 91)
        Me.lblidclienteSICY.Name = "lblidclienteSICY"
        Me.lblidclienteSICY.Size = New System.Drawing.Size(15, 13)
        Me.lblidclienteSICY.TabIndex = 188
        Me.lblidclienteSICY.Text = "id"
        Me.lblidclienteSICY.Visible = False
        '
        'txtClientes
        '
        Me.txtClientes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClientes.Location = New System.Drawing.Point(493, 84)
        Me.txtClientes.MaxLength = 50
        Me.txtClientes.Name = "txtClientes"
        Me.txtClientes.ReadOnly = True
        Me.txtClientes.Size = New System.Drawing.Size(272, 20)
        Me.txtClientes.TabIndex = 187
        Me.txtClientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblrfcidcliente
        '
        Me.lblrfcidcliente.AutoSize = True
        Me.lblrfcidcliente.Location = New System.Drawing.Point(769, 130)
        Me.lblrfcidcliente.Name = "lblrfcidcliente"
        Me.lblrfcidcliente.Size = New System.Drawing.Size(27, 13)
        Me.lblrfcidcliente.TabIndex = 186
        Me.lblrfcidcliente.Text = "idrfc"
        Me.lblrfcidcliente.Visible = False
        '
        'txtrazonSocialCliente
        '
        Me.txtrazonSocialCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrazonSocialCliente.Location = New System.Drawing.Point(493, 127)
        Me.txtrazonSocialCliente.MaxLength = 50
        Me.txtrazonSocialCliente.Name = "txtrazonSocialCliente"
        Me.txtrazonSocialCliente.ReadOnly = True
        Me.txtrazonSocialCliente.Size = New System.Drawing.Size(272, 20)
        Me.txtrazonSocialCliente.TabIndex = 185
        Me.txtrazonSocialCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblidCliente
        '
        Me.lblidCliente.AutoSize = True
        Me.lblidCliente.Location = New System.Drawing.Point(769, 90)
        Me.lblidCliente.Name = "lblidCliente"
        Me.lblidCliente.Size = New System.Drawing.Size(15, 13)
        Me.lblidCliente.TabIndex = 182
        Me.lblidCliente.Text = "id"
        Me.lblidCliente.Visible = False
        '
        'lblidempresa
        '
        Me.lblidempresa.AutoSize = True
        Me.lblidempresa.Location = New System.Drawing.Point(768, 50)
        Me.lblidempresa.Name = "lblidempresa"
        Me.lblidempresa.Size = New System.Drawing.Size(15, 13)
        Me.lblidempresa.TabIndex = 181
        Me.lblidempresa.Text = "id"
        Me.lblidempresa.Visible = False
        '
        'lblTTotal
        '
        Me.lblTTotal.AutoSize = True
        Me.lblTTotal.Location = New System.Drawing.Point(909, 145)
        Me.lblTTotal.Name = "lblTTotal"
        Me.lblTTotal.Size = New System.Drawing.Size(13, 13)
        Me.lblTTotal.TabIndex = 180
        Me.lblTTotal.Text = "0"
        '
        'lblTIva
        '
        Me.lblTIva.AutoSize = True
        Me.lblTIva.Location = New System.Drawing.Point(909, 114)
        Me.lblTIva.Name = "lblTIva"
        Me.lblTIva.Size = New System.Drawing.Size(13, 13)
        Me.lblTIva.TabIndex = 179
        Me.lblTIva.Text = "0"
        '
        'lblTSubtotal
        '
        Me.lblTSubtotal.AutoSize = True
        Me.lblTSubtotal.Location = New System.Drawing.Point(909, 81)
        Me.lblTSubtotal.Name = "lblTSubtotal"
        Me.lblTSubtotal.Size = New System.Drawing.Size(13, 13)
        Me.lblTSubtotal.TabIndex = 178
        Me.lblTSubtotal.Text = "0"
        '
        'CmbConcepto
        '
        Me.CmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbConcepto.DropDownWidth = 200
        Me.CmbConcepto.FormattingEnabled = True
        Me.CmbConcepto.Location = New System.Drawing.Point(233, 46)
        Me.CmbConcepto.Name = "CmbConcepto"
        Me.CmbConcepto.Size = New System.Drawing.Size(134, 21)
        Me.CmbConcepto.TabIndex = 177
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(934, 49)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(34, 13)
        Me.lblFolio.TabIndex = 175
        Me.lblFolio.Text = "Folio"
        Me.lblFolio.Visible = False
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerie.Location = New System.Drawing.Point(909, 49)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(34, 13)
        Me.lblSerie.TabIndex = 174
        Me.lblSerie.Text = "serie"
        Me.lblSerie.Visible = False
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Items.AddRange(New Object() {""})
        Me.cmbRazonSocial.Location = New System.Drawing.Point(493, 46)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(272, 21)
        Me.cmbRazonSocial.TabIndex = 9
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(819, 145)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(34, 13)
        Me.lblTotal.TabIndex = 172
        Me.lblTotal.Text = "Total:"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(819, 81)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(49, 13)
        Me.lblSubtotal.TabIndex = 171
        Me.lblSubtotal.Text = "Subtotal:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(819, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "IVA:"
        '
        'lblNotaCredito
        '
        Me.lblNotaCredito.AutoSize = True
        Me.lblNotaCredito.Location = New System.Drawing.Point(819, 49)
        Me.lblNotaCredito.Name = "lblNotaCredito"
        Me.lblNotaCredito.Size = New System.Drawing.Size(84, 13)
        Me.lblNotaCredito.TabIndex = 169
        Me.lblNotaCredito.Text = "Nota de Crédito:"
        '
        'lblRFCCliente
        '
        Me.lblRFCCliente.AutoSize = True
        Me.lblRFCCliente.Location = New System.Drawing.Point(379, 130)
        Me.lblRFCCliente.Name = "lblRFCCliente"
        Me.lblRFCCliente.Size = New System.Drawing.Size(108, 13)
        Me.lblRFCCliente.TabIndex = 165
        Me.lblRFCCliente.Text = "Razón Social Cliente:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(445, 87)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 13)
        Me.lblCliente.TabIndex = 164
        Me.lblCliente.Text = "Cliente:"
        '
        'lblRazSocial
        '
        Me.lblRazSocial.AutoSize = True
        Me.lblRazSocial.Location = New System.Drawing.Point(414, 49)
        Me.lblRazSocial.Name = "lblRazSocial"
        Me.lblRazSocial.Size = New System.Drawing.Size(73, 13)
        Me.lblRazSocial.TabIndex = 163
        Me.lblRazSocial.Text = "Razón Social:"
        '
        'lblsignoPorciento
        '
        Me.lblsignoPorciento.AutoSize = True
        Me.lblsignoPorciento.Location = New System.Drawing.Point(367, 167)
        Me.lblsignoPorciento.Name = "lblsignoPorciento"
        Me.lblsignoPorciento.Size = New System.Drawing.Size(15, 13)
        Me.lblsignoPorciento.TabIndex = 161
        Me.lblsignoPorciento.Text = "%"
        '
        'lblDescCxc
        '
        Me.lblDescCxc.AutoSize = True
        Me.lblDescCxc.Location = New System.Drawing.Point(143, 166)
        Me.lblDescCxc.Name = "lblDescCxc"
        Me.lblDescCxc.Size = New System.Drawing.Size(84, 13)
        Me.lblDescCxc.TabIndex = 160
        Me.lblDescCxc.Text = "Descuento CxC:"
        '
        'lblIva
        '
        Me.lblIva.AutoSize = True
        Me.lblIva.Location = New System.Drawing.Point(197, 127)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(30, 13)
        Me.lblIva.TabIndex = 159
        Me.lblIva.Text = "I.V.A"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(178, 86)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(49, 13)
        Me.lblMoneda.TabIndex = 158
        Me.lblMoneda.Text = "Moneda:"
        '
        'txtDescuentoCXC
        '
        Me.txtDescuentoCXC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescuentoCXC.Location = New System.Drawing.Point(233, 163)
        Me.txtDescuentoCXC.MaxLength = 50
        Me.txtDescuentoCXC.Name = "txtDescuentoCXC"
        Me.txtDescuentoCXC.ReadOnly = True
        Me.txtDescuentoCXC.Size = New System.Drawing.Size(134, 20)
        Me.txtDescuentoCXC.TabIndex = 8
        Me.txtDescuentoCXC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtiva
        '
        Me.txtiva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtiva.Location = New System.Drawing.Point(233, 123)
        Me.txtiva.MaxLength = 50
        Me.txtiva.Name = "txtiva"
        Me.txtiva.ReadOnly = True
        Me.txtiva.Size = New System.Drawing.Size(134, 20)
        Me.txtiva.TabIndex = 7
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpbFecha
        '
        Me.gpbFecha.Controls.Add(Me.dtpFechaInicio)
        Me.gpbFecha.Location = New System.Drawing.Point(10, 120)
        Me.gpbFecha.Name = "gpbFecha"
        Me.gpbFecha.Size = New System.Drawing.Size(123, 65)
        Me.gpbFecha.TabIndex = 155
        Me.gpbFecha.TabStop = False
        Me.gpbFecha.Text = "Fecha:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Enabled = False
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(7, 25)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(105, 20)
        Me.dtpFechaInicio.TabIndex = 4
        '
        'cmbMoneda
        '
        Me.cmbMoneda.Enabled = False
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Items.AddRange(New Object() {""})
        Me.cmbMoneda.Location = New System.Drawing.Point(233, 83)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(134, 21)
        Me.cmbMoneda.TabIndex = 6
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Location = New System.Drawing.Point(178, 49)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(56, 13)
        Me.lblConcepto.TabIndex = 153
        Me.lblConcepto.Text = "Concepto:"
        '
        'pnlOcultaFiltros
        '
        Me.pnlOcultaFiltros.Controls.Add(Me.btnArriba)
        Me.pnlOcultaFiltros.Controls.Add(Me.btnAbajo)
        Me.pnlOcultaFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOcultaFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlOcultaFiltros.Name = "pnlOcultaFiltros"
        Me.pnlOcultaFiltros.Size = New System.Drawing.Size(1000, 25)
        Me.pnlOcultaFiltros.TabIndex = 20
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Image = Global.Cobranza.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(932, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 0
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Image = Global.Cobranza.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(958, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 0
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'gpTipoNC
        '
        Me.gpTipoNC.Controls.Add(Me.rdRemision)
        Me.gpTipoNC.Controls.Add(Me.rdFactura)
        Me.gpTipoNC.Location = New System.Drawing.Point(10, 31)
        Me.gpTipoNC.Name = "gpTipoNC"
        Me.gpTipoNC.Size = New System.Drawing.Size(123, 73)
        Me.gpTipoNC.TabIndex = 3
        Me.gpTipoNC.TabStop = False
        Me.gpTipoNC.Text = "Tipo NC:"
        '
        'rdRemision
        '
        Me.rdRemision.AutoSize = True
        Me.rdRemision.Location = New System.Drawing.Point(27, 45)
        Me.rdRemision.Name = "rdRemision"
        Me.rdRemision.Size = New System.Drawing.Size(80, 17)
        Me.rdRemision.TabIndex = 3
        Me.rdRemision.Text = "Documento"
        Me.rdRemision.UseVisualStyleBackColor = True
        '
        'rdFactura
        '
        Me.rdFactura.AutoSize = True
        Me.rdFactura.Location = New System.Drawing.Point(27, 22)
        Me.rdFactura.Name = "rdFactura"
        Me.rdFactura.Size = New System.Drawing.Size(61, 17)
        Me.rdFactura.TabIndex = 2
        Me.rdFactura.Text = "Factura"
        Me.rdFactura.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 505)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1000, 62)
        Me.pnlPie.TabIndex = 74
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblguardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(822, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(178, 62)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Cobranza.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(76, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 14
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(73, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 5
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(24, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblguardar
        '
        Me.lblguardar.AutoSize = True
        Me.lblguardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblguardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblguardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblguardar.Location = New System.Drawing.Point(19, 41)
        Me.lblguardar.Name = "lblguardar"
        Me.lblguardar.Size = New System.Drawing.Size(45, 13)
        Me.lblguardar.TabIndex = 3
        Me.lblguardar.Text = "Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(124, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(124, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdNotasCreditoCliente
        '
        Me.grdNotasCreditoCliente.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdNotasCreditoCliente.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdNotasCreditoCliente.Location = New System.Drawing.Point(0, 269)
        Me.grdNotasCreditoCliente.MainView = Me.wvNotasCreditoCliente
        Me.grdNotasCreditoCliente.Name = "grdNotasCreditoCliente"
        Me.grdNotasCreditoCliente.Size = New System.Drawing.Size(1000, 236)
        Me.grdNotasCreditoCliente.TabIndex = 77
        Me.grdNotasCreditoCliente.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.wvNotasCreditoCliente})
        '
        'wvNotasCreditoCliente
        '
        Me.wvNotasCreditoCliente.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.wvNotasCreditoCliente.Appearance.EvenRow.Options.UseBackColor = True
        Me.wvNotasCreditoCliente.GridControl = Me.grdNotasCreditoCliente
        Me.wvNotasCreditoCliente.Name = "wvNotasCreditoCliente"
        Me.wvNotasCreditoCliente.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvNotasCreditoCliente.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvNotasCreditoCliente.OptionsCustomization.AllowColumnMoving = False
        Me.wvNotasCreditoCliente.OptionsView.ShowFooter = True
        Me.wvNotasCreditoCliente.OptionsView.ShowGroupPanel = False
        '
        'lbl_cliente_sicy
        '
        Me.lbl_cliente_sicy.AutoSize = True
        Me.lbl_cliente_sicy.Location = New System.Drawing.Point(798, 89)
        Me.lbl_cliente_sicy.Name = "lbl_cliente_sicy"
        Me.lbl_cliente_sicy.Size = New System.Drawing.Size(15, 13)
        Me.lbl_cliente_sicy.TabIndex = 191
        Me.lbl_cliente_sicy.Text = "id"
        Me.lbl_cliente_sicy.Visible = False
        '
        'NotasCreditoDevolucionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 567)
        Me.Controls.Add(Me.grdNotasCreditoCliente)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlBanner)
        Me.KeyPreview = True
        Me.Name = "NotasCreditoDevolucionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notas de Crédito"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.gpbFecha.ResumeLayout(False)
        Me.pnlOcultaFiltros.ResumeLayout(False)
        Me.gpTipoNC.ResumeLayout(False)
        Me.gpTipoNC.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdNotasCreditoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wvNotasCreditoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents btnCargaDocumentos As Windows.Forms.Button
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents lblCargarDocumentos As Windows.Forms.Label
    Friend WithEvents pnlAcciones As Windows.Forms.Panel
    Friend WithEvents pnlOcultaFiltros As Windows.Forms.Panel
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents dtpFechaInicio As Windows.Forms.DateTimePicker
    Friend WithEvents gpTipoNC As Windows.Forms.GroupBox
    Friend WithEvents rdRemision As Windows.Forms.RadioButton
    Friend WithEvents rdFactura As Windows.Forms.RadioButton
    Friend WithEvents lblConcepto As Windows.Forms.Label
    Friend WithEvents gpbFecha As Windows.Forms.GroupBox
    Friend WithEvents lblDescCxc As Windows.Forms.Label
    Friend WithEvents lblIva As Windows.Forms.Label
    Friend WithEvents lblMoneda As Windows.Forms.Label
    Friend WithEvents txtDescuentoCXC As Windows.Forms.TextBox
    Friend WithEvents txtiva As Windows.Forms.TextBox
    Friend WithEvents lblsignoPorciento As Windows.Forms.Label
    Friend WithEvents lblRFCCliente As Windows.Forms.Label
    Friend WithEvents lblCliente As Windows.Forms.Label
    Friend WithEvents lblRazSocial As Windows.Forms.Label
    Friend WithEvents lblTotal As Windows.Forms.Label
    Friend WithEvents lblSubtotal As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblNotaCredito As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents lblSerie As Windows.Forms.Label
    Friend WithEvents lblFolio As Windows.Forms.Label
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblguardar As Windows.Forms.Label
    Friend WithEvents cmbMoneda As Windows.Forms.ComboBox
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents CmbConcepto As Windows.Forms.ComboBox
    Friend WithEvents lblTIva As Windows.Forms.Label
    Friend WithEvents lblTSubtotal As Windows.Forms.Label
    Friend WithEvents lblTTotal As Windows.Forms.Label
    Friend WithEvents grdNotasCreditoCliente As DevExpress.XtraGrid.GridControl
    Friend WithEvents wvNotasCreditoCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblidempresa As Windows.Forms.Label
    Friend WithEvents cmbRazonSocial As Windows.Forms.ComboBox
    Friend WithEvents lblidCliente As Windows.Forms.Label
    Friend WithEvents lblrfcidcliente As Windows.Forms.Label
    Friend WithEvents txtrazonSocialCliente As Windows.Forms.TextBox
    Friend WithEvents lblidclienteSICY As Windows.Forms.Label
    Friend WithEvents txtClientes As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtRFCCliente As Windows.Forms.TextBox
    Friend WithEvents lbleliminarfila As Windows.Forms.Label
    Friend WithEvents btnlEliminarFila As Windows.Forms.Button
    Friend WithEvents lbl_cliente_sicy As Windows.Forms.Label
End Class
