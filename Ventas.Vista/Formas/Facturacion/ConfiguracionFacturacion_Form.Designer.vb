<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionFacturacion_Form
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblRFCEmisor = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblRazonSocialEmisor = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblMontoMax = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblRestriccionMarca = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblRestriccion = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblDiasPlazo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPorcentajeFacturacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.txtPorcentajeRemision = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPorcentajeFacturacionSeleccionRazones = New System.Windows.Forms.TextBox()
        Me.txtPorcentajeRemisionSeleccionRazones = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlRFCPedido = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdRazonesSociales = New DevExpress.XtraGrid.GridControl()
        Me.bgvRazonesSociales = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.grdDetallesOT = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdRazonesSociales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvRazonesSociales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(955, 65)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(454, 65)
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
        Me.pnlTitulo.Location = New System.Drawing.Point(454, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(501, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(198, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(223, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Configuración documentos"
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
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.chboxSeleccionarTodo)
        Me.pnlParametros.Controls.Add(Me.GroupBox3)
        Me.pnlParametros.Controls.Add(Me.GroupBox2)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(955, 121)
        Me.pnlParametros.TabIndex = 26
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(18, 102)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 63
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblRFCEmisor)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.lblRazonSocialEmisor)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(939, 44)
        Me.GroupBox3.TabIndex = 62
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Emisor"
        '
        'lblRFCEmisor
        '
        Me.lblRFCEmisor.AutoSize = True
        Me.lblRFCEmisor.Location = New System.Drawing.Point(596, 22)
        Me.lblRFCEmisor.Name = "lblRFCEmisor"
        Me.lblRFCEmisor.Size = New System.Drawing.Size(16, 13)
        Me.lblRFCEmisor.TabIndex = 58
        Me.lblRFCEmisor.Text = "---"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(548, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "RFC:"
        '
        'lblRazonSocialEmisor
        '
        Me.lblRazonSocialEmisor.AutoSize = True
        Me.lblRazonSocialEmisor.Location = New System.Drawing.Point(84, 22)
        Me.lblRazonSocialEmisor.Name = "lblRazonSocialEmisor"
        Me.lblRazonSocialEmisor.Size = New System.Drawing.Size(16, 13)
        Me.lblRazonSocialEmisor.TabIndex = 59
        Me.lblRazonSocialEmisor.Text = "---"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 13)
        Me.Label18.TabIndex = 61
        Me.Label18.Text = "Razón Social:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.lblRestriccionMarca)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.lblRestriccion)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox2.Controls.Add(Me.lblDiasPlazo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtPorcentajeFacturacion)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.lblMoneda)
        Me.GroupBox2.Controls.Add(Me.txtPorcentajeRemision)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(939, 53)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Receptor"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblMontoMax)
        Me.Panel4.Location = New System.Drawing.Point(445, 34)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(80, 17)
        Me.Panel4.TabIndex = 70
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
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(330, 36)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(109, 13)
        Me.Label25.TabIndex = 62
        Me.Label25.Text = "Máximo por factura $:"
        '
        'lblRestriccionMarca
        '
        Me.lblRestriccionMarca.AutoSize = True
        Me.lblRestriccionMarca.Location = New System.Drawing.Point(669, 36)
        Me.lblRestriccionMarca.Name = "lblRestriccionMarca"
        Me.lblRestriccionMarca.Size = New System.Drawing.Size(16, 13)
        Me.lblRestriccionMarca.TabIndex = 59
        Me.lblRestriccionMarca.Text = "---"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(562, 36)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(103, 13)
        Me.Label26.TabIndex = 60
        Me.Label26.Text = "Marcas Por Factura:"
        '
        'lblRestriccion
        '
        Me.lblRestriccion.AutoSize = True
        Me.lblRestriccion.Location = New System.Drawing.Point(78, 36)
        Me.lblRestriccion.Name = "lblRestriccion"
        Me.lblRestriccion.Size = New System.Drawing.Size(16, 13)
        Me.lblRestriccion.TabIndex = 59
        Me.lblRestriccion.Text = "---"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 36)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(63, 13)
        Me.Label23.TabIndex = 60
        Me.Label23.Text = "Restricción:"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(57, 17)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(16, 13)
        Me.lblNombreCliente.TabIndex = 47
        Me.lblNombreCliente.Text = "---"
        '
        'lblDiasPlazo
        '
        Me.lblDiasPlazo.AutoSize = True
        Me.lblDiasPlazo.Location = New System.Drawing.Point(863, 17)
        Me.lblDiasPlazo.Name = "lblDiasPlazo"
        Me.lblDiasPlazo.Size = New System.Drawing.Size(13, 13)
        Me.lblDiasPlazo.TabIndex = 58
        Me.lblDiasPlazo.Text = "--"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(330, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Facturar:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(426, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(452, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Remisionar:"
        '
        'txtPorcentajeFacturacion
        '
        Me.txtPorcentajeFacturacion.Location = New System.Drawing.Point(383, 13)
        Me.txtPorcentajeFacturacion.Name = "txtPorcentajeFacturacion"
        Me.txtPorcentajeFacturacion.Size = New System.Drawing.Size(41, 20)
        Me.txtPorcentajeFacturacion.TabIndex = 50
        Me.txtPorcentajeFacturacion.Text = "0"
        Me.txtPorcentajeFacturacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(893, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Días"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(562, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "%"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(686, 17)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(16, 13)
        Me.lblMoneda.TabIndex = 53
        Me.lblMoneda.Text = "---"
        '
        'txtPorcentajeRemision
        '
        Me.txtPorcentajeRemision.Location = New System.Drawing.Point(515, 13)
        Me.txtPorcentajeRemision.Name = "txtPorcentajeRemision"
        Me.txtPorcentajeRemision.Size = New System.Drawing.Size(41, 20)
        Me.txtPorcentajeRemision.TabIndex = 52
        Me.txtPorcentajeRemision.Text = "100"
        Me.txtPorcentajeRemision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(632, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Moneda:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(817, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Plazo:"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.GroupBox1)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.pnlRFCPedido)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 461)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(955, 60)
        Me.pnlPie.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtPorcentajeFacturacionSeleccionRazones)
        Me.GroupBox1.Controls.Add(Me.txtPorcentajeRemisionSeleccionRazones)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Location = New System.Drawing.Point(550, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 54)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totales"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(256, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 13)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "%"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(125, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 55
        Me.Label15.Text = "%"
        '
        'txtPorcentajeFacturacionSeleccionRazones
        '
        Me.txtPorcentajeFacturacionSeleccionRazones.Enabled = False
        Me.txtPorcentajeFacturacionSeleccionRazones.Location = New System.Drawing.Point(83, 21)
        Me.txtPorcentajeFacturacionSeleccionRazones.Name = "txtPorcentajeFacturacionSeleccionRazones"
        Me.txtPorcentajeFacturacionSeleccionRazones.Size = New System.Drawing.Size(41, 20)
        Me.txtPorcentajeFacturacionSeleccionRazones.TabIndex = 52
        Me.txtPorcentajeFacturacionSeleccionRazones.Text = "100"
        Me.txtPorcentajeFacturacionSeleccionRazones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorcentajeRemisionSeleccionRazones
        '
        Me.txtPorcentajeRemisionSeleccionRazones.Enabled = False
        Me.txtPorcentajeRemisionSeleccionRazones.Location = New System.Drawing.Point(215, 21)
        Me.txtPorcentajeRemisionSeleccionRazones.Name = "txtPorcentajeRemisionSeleccionRazones"
        Me.txtPorcentajeRemisionSeleccionRazones.Size = New System.Drawing.Size(41, 20)
        Me.txtPorcentajeRemisionSeleccionRazones.TabIndex = 54
        Me.txtPorcentajeRemisionSeleccionRazones.Text = "100"
        Me.txtPorcentajeRemisionSeleccionRazones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 51
        Me.Label13.Text = "Facturación:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(148, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "Remisión:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(33, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "RFC del pedido"
        '
        'pnlRFCPedido
        '
        Me.pnlRFCPedido.BackColor = System.Drawing.Color.MediumAquamarine
        Me.pnlRFCPedido.ForeColor = System.Drawing.Color.Black
        Me.pnlRFCPedido.Location = New System.Drawing.Point(15, 25)
        Me.pnlRFCPedido.Name = "pnlRFCPedido"
        Me.pnlRFCPedido.Size = New System.Drawing.Size(15, 15)
        Me.pnlRFCPedido.TabIndex = 39
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.Label12)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(841, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(114, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(25, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(19, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Aceptar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(69, 8)
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
        Me.lblCerrar.Location = New System.Drawing.Point(68, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdRazonesSociales)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(955, 521)
        Me.Panel1.TabIndex = 1
        '
        'grdRazonesSociales
        '
        Me.grdRazonesSociales.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdRazonesSociales.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdRazonesSociales.Location = New System.Drawing.Point(0, 186)
        Me.grdRazonesSociales.MainView = Me.bgvRazonesSociales
        Me.grdRazonesSociales.Name = "grdRazonesSociales"
        Me.grdRazonesSociales.Size = New System.Drawing.Size(955, 275)
        Me.grdRazonesSociales.TabIndex = 28
        Me.grdRazonesSociales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvRazonesSociales, Me.GridView1, Me.grdDetallesOT})
        '
        'bgvRazonesSociales
        '
        Me.bgvRazonesSociales.GridControl = Me.grdRazonesSociales
        Me.bgvRazonesSociales.Name = "bgvRazonesSociales"
        Me.bgvRazonesSociales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvRazonesSociales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.bgvRazonesSociales.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.bgvRazonesSociales.OptionsPrint.AllowMultilineHeaders = True
        Me.bgvRazonesSociales.OptionsSelection.MultiSelect = True
        Me.bgvRazonesSociales.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Seleccionar, Me.OT, Me.OTSICY, Me.Cliente, Me.Agente, Me.STATUS, Me.TipoOT, Me.PedidoSAY, Me.PedidoSICY, Me.OrdenCliente, Me.FechaEntregaProgramacion, Me.FechaPreparacion, Me.Cantidad, Me.Confirmados, Me.PorConfirmar, Me.Cancelados, Me.UsuarioCaptura, Me.FechaCaptura, Me.Cita, Me.UsuarioModifico, Me.FechaModificacion, Me.DiasFaltantes, Me.BE, Me.MotivoCancelacion, Me.EstatusID, Me.GridColumn2, Me.Observaciones, Me.FechaCitaEntrega, Me.HoraCita})
        Me.GridView1.GridControl = Me.grdRazonesSociales
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
        Me.Cantidad.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
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
        Me.Confirmados.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
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
        Me.PorConfirmar.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
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
        Me.Cancelados.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
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
        'grdDetallesOT
        '
        Me.grdDetallesOT.GridControl = Me.grdRazonesSociales
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
        'ConfiguracionFacturacion_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 521)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(961, 543)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(961, 543)
        Me.Name = "ConfiguracionFacturacion_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración documentos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdRazonesSociales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvRazonesSociales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetallesOT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents pnlVentas As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents chboxSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRFCEmisor As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocialEmisor As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblMontoMax As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblRestriccionMarca As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblRestriccion As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblDiasPlazo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeFacturacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeRemision As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeFacturacionSeleccionRazones As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcentajeRemisionSeleccionRazones As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlRFCPedido As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdRazonesSociales As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvRazonesSociales As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents grdDetallesOT As DevExpress.XtraGrid.Views.Grid.GridView
End Class
