<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComprasPTIngresado_AplicarDevoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComprasPTIngresado_AplicarDevoluciones))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdListado = New DevExpress.XtraGrid.GridControl()
        Me.gvwListado = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.grbEmisor = New System.Windows.Forms.GroupBox()
        Me.lblRFCEmisor = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRazonSocialEmisor = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grbReceptor = New System.Windows.Forms.GroupBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblNC = New System.Windows.Forms.Label()
        Me.lblRFCReceptor = New System.Windows.Forms.Label()
        Me.lblRazonSocialReceptor = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlControlesParam = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlGuardarDev = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.pnlVentas = New System.Windows.Forms.Panel()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlPDF = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.pnlXML = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnXML = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvwListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.grbEmisor.SuspendLayout()
        Me.grbReceptor.SuspendLayout()
        Me.pnlControlesParam.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlGuardarDev.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlVentas.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlPDF.SuspendLayout()
        Me.pnlXML.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdListado)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.pnlControlesParam)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1051, 509)
        Me.Panel1.TabIndex = 2
        '
        'grdListado
        '
        Me.grdListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListado.Location = New System.Drawing.Point(0, 222)
        Me.grdListado.MainView = Me.gvwListado
        Me.grdListado.Name = "grdListado"
        Me.grdListado.Size = New System.Drawing.Size(1051, 232)
        Me.grdListado.TabIndex = 58
        Me.grdListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvwListado})
        '
        'gvwListado
        '
        Me.gvwListado.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.gvwListado.Appearance.EvenRow.Options.UseBackColor = True
        Me.gvwListado.GridControl = Me.grdListado
        Me.gvwListado.Name = "gvwListado"
        Me.gvwListado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvwListado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvwListado.OptionsBehavior.Editable = False
        Me.gvwListado.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.Text
        Me.gvwListado.OptionsPrint.AllowMultilineHeaders = True
        Me.gvwListado.OptionsSelection.MultiSelect = True
        Me.gvwListado.OptionsView.ShowAutoFilterRow = True
        Me.gvwListado.OptionsView.ShowFooter = True
        Me.gvwListado.OptionsView.ShowGroupPanel = False
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.grbEmisor)
        Me.pnlParametros.Controls.Add(Me.grbReceptor)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 92)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1051, 130)
        Me.pnlParametros.TabIndex = 57
        '
        'grbEmisor
        '
        Me.grbEmisor.Controls.Add(Me.lblRFCEmisor)
        Me.grbEmisor.Controls.Add(Me.Label8)
        Me.grbEmisor.Controls.Add(Me.lblRazonSocialEmisor)
        Me.grbEmisor.Controls.Add(Me.Label7)
        Me.grbEmisor.Location = New System.Drawing.Point(9, 54)
        Me.grbEmisor.Name = "grbEmisor"
        Me.grbEmisor.Size = New System.Drawing.Size(1020, 48)
        Me.grbEmisor.TabIndex = 54
        Me.grbEmisor.TabStop = False
        Me.grbEmisor.Text = "Emisor"
        '
        'lblRFCEmisor
        '
        Me.lblRFCEmisor.AutoSize = True
        Me.lblRFCEmisor.Location = New System.Drawing.Point(537, 22)
        Me.lblRFCEmisor.Name = "lblRFCEmisor"
        Me.lblRFCEmisor.Size = New System.Drawing.Size(13, 13)
        Me.lblRFCEmisor.TabIndex = 48
        Me.lblRFCEmisor.Text = "--"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(500, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "RFC:"
        '
        'lblRazonSocialEmisor
        '
        Me.lblRazonSocialEmisor.AutoSize = True
        Me.lblRazonSocialEmisor.Location = New System.Drawing.Point(106, 22)
        Me.lblRazonSocialEmisor.Name = "lblRazonSocialEmisor"
        Me.lblRazonSocialEmisor.Size = New System.Drawing.Size(13, 13)
        Me.lblRazonSocialEmisor.TabIndex = 48
        Me.lblRazonSocialEmisor.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Razón Social:"
        '
        'grbReceptor
        '
        Me.grbReceptor.Controls.Add(Me.lblFolio)
        Me.grbReceptor.Controls.Add(Me.lblNC)
        Me.grbReceptor.Controls.Add(Me.lblRFCReceptor)
        Me.grbReceptor.Controls.Add(Me.lblRazonSocialReceptor)
        Me.grbReceptor.Controls.Add(Me.Label1)
        Me.grbReceptor.Controls.Add(Me.Label2)
        Me.grbReceptor.Location = New System.Drawing.Point(9, 4)
        Me.grbReceptor.Name = "grbReceptor"
        Me.grbReceptor.Size = New System.Drawing.Size(1020, 44)
        Me.grbReceptor.TabIndex = 48
        Me.grbReceptor.TabStop = False
        Me.grbReceptor.Text = "Receptor"
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(837, 19)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(13, 13)
        Me.lblFolio.TabIndex = 54
        Me.lblFolio.Text = "--"
        '
        'lblNC
        '
        Me.lblNC.AutoSize = True
        Me.lblNC.Location = New System.Drawing.Point(747, 19)
        Me.lblNC.Name = "lblNC"
        Me.lblNC.Size = New System.Drawing.Size(84, 13)
        Me.lblNC.TabIndex = 55
        Me.lblNC.Text = "Nota de Crédito:"
        '
        'lblRFCReceptor
        '
        Me.lblRFCReceptor.AutoSize = True
        Me.lblRFCReceptor.Location = New System.Drawing.Point(537, 19)
        Me.lblRFCReceptor.Name = "lblRFCReceptor"
        Me.lblRFCReceptor.Size = New System.Drawing.Size(13, 13)
        Me.lblRFCReceptor.TabIndex = 52
        Me.lblRFCReceptor.Text = "--"
        '
        'lblRazonSocialReceptor
        '
        Me.lblRazonSocialReceptor.AutoSize = True
        Me.lblRazonSocialReceptor.Location = New System.Drawing.Point(106, 19)
        Me.lblRazonSocialReceptor.Name = "lblRazonSocialReceptor"
        Me.lblRazonSocialReceptor.Size = New System.Drawing.Size(13, 13)
        Me.lblRazonSocialReceptor.TabIndex = 50
        Me.lblRazonSocialReceptor.Text = "--"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Razón Social:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(500, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "RFC:"
        '
        'pnlControlesParam
        '
        Me.pnlControlesParam.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlControlesParam.Controls.Add(Me.btnArriba)
        Me.pnlControlesParam.Controls.Add(Me.btnAbajo)
        Me.pnlControlesParam.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlControlesParam.Location = New System.Drawing.Point(0, 65)
        Me.pnlControlesParam.Name = "pnlControlesParam"
        Me.pnlControlesParam.Size = New System.Drawing.Size(1051, 27)
        Me.pnlControlesParam.TabIndex = 56
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(991, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(1017, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlGuardarDev)
        Me.pnlPie.Controls.Add(Me.lblRegistros)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 454)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1051, 55)
        Me.pnlPie.TabIndex = 27
        '
        'pnlGuardarDev
        '
        Me.pnlGuardarDev.Controls.Add(Me.btnGuardar)
        Me.pnlGuardarDev.Controls.Add(Me.Label10)
        Me.pnlGuardarDev.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGuardarDev.Location = New System.Drawing.Point(931, 0)
        Me.pnlGuardarDev.Name = "pnlGuardarDev"
        Me.pnlGuardarDev.Size = New System.Drawing.Size(60, 55)
        Me.pnlGuardarDev.TabIndex = 134
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(16, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(10, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Guardar"
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(31, 30)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(16, 16)
        Me.lblRegistros.TabIndex = 133
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 132
        Me.Label9.Text = "Registros"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(991, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(60, 55)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(16, 6)
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
        Me.lblCerrar.Location = New System.Drawing.Point(15, 38)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1051, 65)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(550, 65)
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
        Me.pnlVentas.Controls.Add(Me.pnlExportar)
        Me.pnlVentas.Controls.Add(Me.pnlPDF)
        Me.pnlVentas.Controls.Add(Me.pnlXML)
        Me.pnlVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVentas.Location = New System.Drawing.Point(0, 0)
        Me.pnlVentas.Name = "pnlVentas"
        Me.pnlVentas.Size = New System.Drawing.Size(402, 65)
        Me.pnlVentas.TabIndex = 108
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.Label4)
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(135, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(65, 65)
        Me.pnlExportar.TabIndex = 123
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(13, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(16, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 102
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlPDF
        '
        Me.pnlPDF.Controls.Add(Me.Label3)
        Me.pnlPDF.Controls.Add(Me.btnPDF)
        Me.pnlPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPDF.Location = New System.Drawing.Point(65, 0)
        Me.pnlPDF.Name = "pnlPDF"
        Me.pnlPDF.Size = New System.Drawing.Size(70, 65)
        Me.pnlPDF.TabIndex = 122
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(13, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 26)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PDF"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPDF
        '
        Me.btnPDF.Image = Global.Proveedor.Vista.My.Resources.Resources.agregar_pdf
        Me.btnPDF.Location = New System.Drawing.Point(18, 3)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnPDF.TabIndex = 102
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'pnlXML
        '
        Me.pnlXML.Controls.Add(Me.lblExportar)
        Me.pnlXML.Controls.Add(Me.btnXML)
        Me.pnlXML.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlXML.Location = New System.Drawing.Point(0, 0)
        Me.pnlXML.Name = "pnlXML"
        Me.pnlXML.Size = New System.Drawing.Size(65, 65)
        Me.pnlXML.TabIndex = 121
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(13, 38)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(44, 26)
        Me.lblExportar.TabIndex = 120
        Me.lblExportar.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XML"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnXML
        '
        Me.btnXML.Image = Global.Proveedor.Vista.My.Resources.Resources.agregar_xml_32
        Me.btnXML.Location = New System.Drawing.Point(16, 3)
        Me.btnXML.Name = "btnXML"
        Me.btnXML.Size = New System.Drawing.Size(32, 32)
        Me.btnXML.TabIndex = 102
        Me.btnXML.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(550, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(501, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(144, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(249, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Aplicar Devolución de Compra"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(433, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 49
        Me.pbYuyin.TabStop = False
        '
        'ComprasPTIngresado_AplicarDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 509)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ComprasPTIngresado_AplicarDevoluciones"
        Me.Text = "Aplicar Devoluciones"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvwListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.grbEmisor.ResumeLayout(False)
        Me.grbEmisor.PerformLayout()
        Me.grbReceptor.ResumeLayout(False)
        Me.grbReceptor.PerformLayout()
        Me.pnlControlesParam.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlGuardarDev.ResumeLayout(False)
        Me.pnlGuardarDev.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.pnlVentas.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlPDF.ResumeLayout(False)
        Me.pnlPDF.PerformLayout()
        Me.pnlXML.ResumeLayout(False)
        Me.pnlXML.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents grdListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvwListado As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlParametros As Windows.Forms.Panel
    Friend WithEvents grbEmisor As Windows.Forms.GroupBox
    Friend WithEvents lblRFCEmisor As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents lblRazonSocialEmisor As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents grbReceptor As Windows.Forms.GroupBox
    Friend WithEvents lblRFCReceptor As Windows.Forms.Label
    Friend WithEvents lblRazonSocialReceptor As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents pnlControlesParam As Windows.Forms.Panel
    Friend WithEvents btnArriba As Windows.Forms.Button
    Friend WithEvents btnAbajo As Windows.Forms.Button
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlGuardarDev As Windows.Forms.Panel
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents lblRegistros As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As Windows.Forms.Panel
    Friend WithEvents Panel14 As Windows.Forms.Panel
    Friend WithEvents pnlVentas As Windows.Forms.Panel
    Friend WithEvents pnlPDF As Windows.Forms.Panel
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btnPDF As Windows.Forms.Button
    Friend WithEvents pnlXML As Windows.Forms.Panel
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents btnXML As Windows.Forms.Button
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents pnlExportar As Windows.Forms.Panel
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblFolio As Windows.Forms.Label
    Friend WithEvents lblNC As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
