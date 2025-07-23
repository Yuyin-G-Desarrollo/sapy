<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoUbicacionParAtado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoUbicacionParAtado))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gridListaUbicacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.btnUbicarMapa = New System.Windows.Forms.Button()
        Me.btnCiclico = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.lblCiclico = New System.Windows.Forms.Label()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblListaPuestos = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlResumen = New System.Windows.Forms.Panel()
        Me.lblParesSicy = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblParesSAY = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblErroneos = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblHoraReporteProductividad = New System.Windows.Forms.Label()
        Me.lblFechaReporteProductividad = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAtados = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRecuperados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridListaUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlResumen.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlParametros)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Controls.Add(Me.pnlPie)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1239, 566)
        Me.pnlContenedor.TabIndex = 2
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.pnlListaCliente)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1239, 399)
        Me.pnlParametros.TabIndex = 0
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.GridControl1)
        Me.pnlListaCliente.Controls.Add(Me.gridListaUbicacion)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(1239, 399)
        Me.pnlListaCliente.TabIndex = 4
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1239, 393)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.CustomizationFormHint.Options.UseTextOptions = True
        Me.GridView1.Appearance.CustomizationFormHint.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'gridListaUbicacion
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaUbicacion.DisplayLayout.Appearance = Appearance1
        Me.gridListaUbicacion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaUbicacion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaUbicacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaUbicacion.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaUbicacion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaUbicacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaUbicacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaUbicacion.Location = New System.Drawing.Point(0, 0)
        Me.gridListaUbicacion.Name = "gridListaUbicacion"
        Me.gridListaUbicacion.Size = New System.Drawing.Size(1239, 189)
        Me.gridListaUbicacion.TabIndex = 0
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1239, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1239, 59)
        Me.pnlEncabezado.TabIndex = 0
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.btnUbicarMapa)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnCiclico)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblAltas)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblCiclico)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblExportar)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnImprimir)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportar)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblImprimir)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(301, 59)
        Me.pnlAccionesCabecera.TabIndex = 1
        '
        'btnUbicarMapa
        '
        Me.btnUbicarMapa.Image = Global.Almacen.Vista.My.Resources.Resources.mapa32_321
        Me.btnUbicarMapa.Location = New System.Drawing.Point(27, 5)
        Me.btnUbicarMapa.Name = "btnUbicarMapa"
        Me.btnUbicarMapa.Size = New System.Drawing.Size(32, 32)
        Me.btnUbicarMapa.TabIndex = 17
        Me.btnUbicarMapa.UseVisualStyleBackColor = True
        '
        'btnCiclico
        '
        Me.btnCiclico.Image = CType(resources.GetObject("btnCiclico.Image"), System.Drawing.Image)
        Me.btnCiclico.Location = New System.Drawing.Point(214, 5)
        Me.btnCiclico.Name = "btnCiclico"
        Me.btnCiclico.Size = New System.Drawing.Size(32, 32)
        Me.btnCiclico.TabIndex = 27
        Me.btnCiclico.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(2, 40)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(82, 13)
        Me.lblAltas.TabIndex = 18
        Me.lblAltas.Text = "Ubicar en mapa"
        '
        'lblCiclico
        '
        Me.lblCiclico.AutoSize = True
        Me.lblCiclico.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCiclico.Location = New System.Drawing.Point(212, 40)
        Me.lblCiclico.Name = "lblCiclico"
        Me.lblCiclico.Size = New System.Drawing.Size(38, 13)
        Me.lblCiclico.TabIndex = 28
        Me.lblCiclico.Text = "Ciclico"
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(93, 40)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 24
        Me.lblExportar.Text = "Exportar"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Almacen.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(155, 5)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 25
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(100, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 23
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(151, 40)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 26
        Me.lblImprimir.Text = "Imprimir"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblListaPuestos)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(746, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(493, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblListaPuestos
        '
        Me.lblListaPuestos.AutoSize = True
        Me.lblListaPuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPuestos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPuestos.Location = New System.Drawing.Point(83, 19)
        Me.lblListaPuestos.Name = "lblListaPuestos"
        Me.lblListaPuestos.Size = New System.Drawing.Size(309, 20)
        Me.lblListaPuestos.TabIndex = 46
        Me.lblListaPuestos.Text = "Localización de Producto en Almacén"
        Me.lblListaPuestos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(958, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(206, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Ficha Técnica de Cliente"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label21)
        Me.pnlPie.Controls.Add(Me.Panel11)
        Me.pnlPie.Controls.Add(Me.Label20)
        Me.pnlPie.Controls.Add(Me.Label18)
        Me.pnlPie.Controls.Add(Me.Panel9)
        Me.pnlPie.Controls.Add(Me.Label19)
        Me.pnlPie.Controls.Add(Me.Panel10)
        Me.pnlPie.Controls.Add(Me.Label16)
        Me.pnlPie.Controls.Add(Me.Label13)
        Me.pnlPie.Controls.Add(Me.Panel7)
        Me.pnlPie.Controls.Add(Me.Panel4)
        Me.pnlPie.Controls.Add(Me.Label17)
        Me.pnlPie.Controls.Add(Me.Label15)
        Me.pnlPie.Controls.Add(Me.Panel8)
        Me.pnlPie.Controls.Add(Me.Panel5)
        Me.pnlPie.Controls.Add(Me.Label11)
        Me.pnlPie.Controls.Add(Me.Panel3)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.Label7)
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Controls.Add(Me.pnlResumen)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.Panel6)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 458)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1239, 108)
        Me.pnlPie.TabIndex = 3
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(264, 88)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 13)
        Me.Label21.TabIndex = 81
        Me.Label21.Text = "Validado"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.OrangeRed
        Me.Panel11.Location = New System.Drawing.Point(248, 87)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(15, 15)
        Me.Panel11.TabIndex = 80
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 55)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 13)
        Me.Label20.TabIndex = 70
        Me.Label20.Text = "Estatus"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(184, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 13)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Proyectado"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.DeepPink
        Me.Panel9.Location = New System.Drawing.Point(169, 87)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(15, 15)
        Me.Panel9.TabIndex = 78
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(184, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 13)
        Me.Label19.TabIndex = 77
        Me.Label19.Text = "Calidad"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.SaddleBrown
        Me.Panel10.Location = New System.Drawing.Point(169, 71)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(15, 15)
        Me.Panel10.TabIndex = 76
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(108, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 75
        Me.Label16.Text = "Reproceso"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Bloqueado"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Indigo
        Me.Panel7.Location = New System.Drawing.Point(93, 87)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(15, 15)
        Me.Panel7.TabIndex = 74
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Red
        Me.Panel4.Location = New System.Drawing.Point(15, 87)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(15, 15)
        Me.Panel4.TabIndex = 70
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(108, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "Asignado"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Disponible"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel8.Location = New System.Drawing.Point(93, 71)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(15, 15)
        Me.Panel8.TabIndex = 72
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel5.Location = New System.Drawing.Point(15, 71)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(15, 15)
        Me.Panel5.TabIndex = 68
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(93, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Coppel"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Purple
        Me.Panel3.Location = New System.Drawing.Point(78, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 66
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(93, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Error"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Atado"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Location = New System.Drawing.Point(78, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(15, 15)
        Me.Panel2.TabIndex = 64
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Aquamarine
        Me.Panel1.Location = New System.Drawing.Point(15, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(15, 15)
        Me.Panel1.TabIndex = 64
        '
        'pnlResumen
        '
        Me.pnlResumen.Controls.Add(Me.lblParesSicy)
        Me.pnlResumen.Controls.Add(Me.Label12)
        Me.pnlResumen.Controls.Add(Me.lblParesSAY)
        Me.pnlResumen.Controls.Add(Me.Label14)
        Me.pnlResumen.Controls.Add(Me.lblErroneos)
        Me.pnlResumen.Controls.Add(Me.Label10)
        Me.pnlResumen.Controls.Add(Me.Label8)
        Me.pnlResumen.Controls.Add(Me.lblHoraReporteProductividad)
        Me.pnlResumen.Controls.Add(Me.lblFechaReporteProductividad)
        Me.pnlResumen.Controls.Add(Me.lblTotalPares)
        Me.pnlResumen.Controls.Add(Me.Label4)
        Me.pnlResumen.Controls.Add(Me.lblPares)
        Me.pnlResumen.Controls.Add(Me.Label5)
        Me.pnlResumen.Controls.Add(Me.lblAtados)
        Me.pnlResumen.Controls.Add(Me.Label3)
        Me.pnlResumen.Controls.Add(Me.lblRecuperados)
        Me.pnlResumen.Controls.Add(Me.Label1)
        Me.pnlResumen.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlResumen.Location = New System.Drawing.Point(205, 0)
        Me.pnlResumen.Name = "pnlResumen"
        Me.pnlResumen.Size = New System.Drawing.Size(933, 108)
        Me.pnlResumen.TabIndex = 2
        '
        'lblParesSicy
        '
        Me.lblParesSicy.AutoSize = True
        Me.lblParesSicy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesSicy.ForeColor = System.Drawing.Color.Black
        Me.lblParesSicy.Location = New System.Drawing.Point(137, 47)
        Me.lblParesSicy.Name = "lblParesSicy"
        Me.lblParesSicy.Size = New System.Drawing.Size(43, 13)
        Me.lblParesSicy.TabIndex = 69
        Me.lblParesSicy.Text = "000000"
        Me.lblParesSicy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(16, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 26)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Pares en existencia " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "según SICY"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblParesSAY
        '
        Me.lblParesSAY.AutoSize = True
        Me.lblParesSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesSAY.ForeColor = System.Drawing.Color.Black
        Me.lblParesSAY.Location = New System.Drawing.Point(137, 16)
        Me.lblParesSAY.Name = "lblParesSAY"
        Me.lblParesSAY.Size = New System.Drawing.Size(43, 13)
        Me.lblParesSAY.TabIndex = 67
        Me.lblParesSAY.Text = "000000"
        Me.lblParesSAY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(16, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 26)
        Me.Label14.TabIndex = 66
        Me.Label14.Text = "Pares en SAY con " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "existencia en SICY"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblErroneos
        '
        Me.lblErroneos.AutoSize = True
        Me.lblErroneos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErroneos.ForeColor = System.Drawing.Color.Black
        Me.lblErroneos.Location = New System.Drawing.Point(738, 16)
        Me.lblErroneos.Name = "lblErroneos"
        Me.lblErroneos.Size = New System.Drawing.Size(43, 13)
        Me.lblErroneos.TabIndex = 65
        Me.lblErroneos.Text = "000000"
        Me.lblErroneos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(645, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Códigos Erróneos:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(680, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Última Actualización:"
        '
        'lblHoraReporteProductividad
        '
        Me.lblHoraReporteProductividad.AutoSize = True
        Me.lblHoraReporteProductividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraReporteProductividad.ForeColor = System.Drawing.Color.Black
        Me.lblHoraReporteProductividad.Location = New System.Drawing.Point(853, 47)
        Me.lblHoraReporteProductividad.Name = "lblHoraReporteProductividad"
        Me.lblHoraReporteProductividad.Size = New System.Drawing.Size(63, 13)
        Me.lblHoraReporteProductividad.TabIndex = 62
        Me.lblHoraReporteProductividad.Text = "88:88:88XX"
        '
        'lblFechaReporteProductividad
        '
        Me.lblFechaReporteProductividad.AutoSize = True
        Me.lblFechaReporteProductividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaReporteProductividad.ForeColor = System.Drawing.Color.Black
        Me.lblFechaReporteProductividad.Location = New System.Drawing.Point(785, 47)
        Me.lblFechaReporteProductividad.Name = "lblFechaReporteProductividad"
        Me.lblFechaReporteProductividad.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaReporteProductividad.TabIndex = 61
        Me.lblFechaReporteProductividad.Text = "8888/88/88"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPares.Location = New System.Drawing.Point(861, 16)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(49, 13)
        Me.lblTotalPares.TabIndex = 60
        Me.lblTotalPares.Text = "000000"
        Me.lblTotalPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(789, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Total Pares:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.ForeColor = System.Drawing.Color.Black
        Me.lblPares.Location = New System.Drawing.Point(594, 16)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(43, 13)
        Me.lblPares.TabIndex = 58
        Me.lblPares.Text = "000000"
        Me.lblPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(527, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Códigos Par:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAtados
        '
        Me.lblAtados.AutoSize = True
        Me.lblAtados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtados.ForeColor = System.Drawing.Color.Black
        Me.lblAtados.Location = New System.Drawing.Point(476, 16)
        Me.lblAtados.Name = "lblAtados"
        Me.lblAtados.Size = New System.Drawing.Size(43, 13)
        Me.lblAtados.TabIndex = 56
        Me.lblAtados.Text = "000000"
        Me.lblAtados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(397, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Códigos Atado:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecuperados
        '
        Me.lblRecuperados.AutoSize = True
        Me.lblRecuperados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecuperados.ForeColor = System.Drawing.Color.Black
        Me.lblRecuperados.Location = New System.Drawing.Point(346, 16)
        Me.lblRecuperados.Name = "lblRecuperados"
        Me.lblRecuperados.Size = New System.Drawing.Size(43, 13)
        Me.lblRecuperados.TabIndex = 54
        Me.lblRecuperados.Text = "000000"
        Me.lblRecuperados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(225, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Registros Recuperados:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1138, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(101, 108)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(11, 48)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 2
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(16, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(58, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(57, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Par"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Khaki
        Me.Panel6.Location = New System.Drawing.Point(15, 17)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(15, 15)
        Me.Panel6.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Localizado como"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(410, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'ListadoUbicacionParAtado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 566)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ListadoUbicacionParAtado"
        Me.Text = "Localización de Producto en Almacén"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridListaUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlResumen.ResumeLayout(False)
        Me.pnlResumen.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblListaPuestos As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents gridListaUbicacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnUbicarMapa As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlResumen As System.Windows.Forms.Panel
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblAtados As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRecuperados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblHoraReporteProductividad As System.Windows.Forms.Label
    Friend WithEvents lblFechaReporteProductividad As System.Windows.Forms.Label
    Friend WithEvents btnCiclico As System.Windows.Forms.Button
    Friend WithEvents lblCiclico As System.Windows.Forms.Label
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblErroneos As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblParesSicy As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblParesSAY As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PictureBox1 As PictureBox
End Class
