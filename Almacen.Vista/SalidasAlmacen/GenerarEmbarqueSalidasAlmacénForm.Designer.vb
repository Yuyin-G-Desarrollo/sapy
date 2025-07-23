<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarEmbarqueSalidasAlmacénForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerarEmbarqueSalidasAlmacénForm))
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlCorregirErrores = New System.Windows.Forms.Panel()
        Me.btnCodigosConErrores = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlActualizarDatos = New System.Windows.Forms.Panel()
        Me.btnActualizarDatos = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlVerPares = New System.Windows.Forms.Panel()
        Me.btnVerPares = New System.Windows.Forms.Button()
        Me.lblDetalles = New System.Windows.Forms.Label()
        Me.pnlGenerarEmbarque = New System.Windows.Forms.Panel()
        Me.btnGenerarEmbarque = New System.Windows.Forms.Button()
        Me.lblBtnGenerarEmbarques = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gridEmbarques = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cboxStatus = New System.Windows.Forms.ComboBox()
        Me.dtpFacturacionDel = New System.Windows.Forms.DateTimePicker()
        Me.lblFacturacionDel = New System.Windows.Forms.Label()
        Me.chboxFiltrarFechaFacturacion = New System.Windows.Forms.CheckBox()
        Me.dtpFacturacionAl = New System.Windows.Forms.DateTimePicker()
        Me.lblFacturacionAl = New System.Windows.Forms.Label()
        Me.dtpConfirmacionDel = New System.Windows.Forms.DateTimePicker()
        Me.lblConfirmacionOTDel = New System.Windows.Forms.Label()
        Me.chboxFiltrarFechaConfirmacionOT = New System.Windows.Forms.CheckBox()
        Me.dtpConfirmacionAl = New System.Windows.Forms.DateTimePicker()
        Me.lblConfirmacionOTAl = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chboxSepararTienda = New System.Windows.Forms.CheckBox()
        Me.rbtnPedidos = New System.Windows.Forms.RadioButton()
        Me.rbtnFacturasDocumentos = New System.Windows.Forms.RadioButton()
        Me.rbtnOrdenesTrabajo = New System.Windows.Forms.RadioButton()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.gboxClientes = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.gridClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.gboxPedidos = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.gridPedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtPedido = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridOrdenTrabajo = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtOrdenTrabajo = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gridMensajeria = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnMensajerias = New System.Windows.Forms.Button()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.lblNaveAlmacen = New System.Windows.Forms.Label()
        Me.cboxNaveAlmacen = New System.Windows.Forms.ComboBox()
        Me.lblStatusProceso = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMensajeUltimaActualizacion = New System.Windows.Forms.Label()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlCorregirErrores.SuspendLayout()
        Me.pnlActualizarDatos.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlVerPares.SuspendLayout()
        Me.pnlGenerarEmbarque.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gridEmbarques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.gboxClientes.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.gridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxPedidos.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridOrdenTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gridMensajeria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(1154, 59)
        Me.pnlEncabezado.TabIndex = 3
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlCorregirErrores)
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlActualizarDatos)
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlExportar)
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlVerPares)
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlGenerarEmbarque)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(496, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlCorregirErrores
        '
        Me.pnlCorregirErrores.Controls.Add(Me.btnCodigosConErrores)
        Me.pnlCorregirErrores.Controls.Add(Me.Label4)
        Me.pnlCorregirErrores.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCorregirErrores.Location = New System.Drawing.Point(328, 0)
        Me.pnlCorregirErrores.Name = "pnlCorregirErrores"
        Me.pnlCorregirErrores.Size = New System.Drawing.Size(85, 59)
        Me.pnlCorregirErrores.TabIndex = 57
        '
        'btnCodigosConErrores
        '
        Me.btnCodigosConErrores.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCodigosConErrores.BackgroundImage = CType(resources.GetObject("btnCodigosConErrores.BackgroundImage"), System.Drawing.Image)
        Me.btnCodigosConErrores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCodigosConErrores.Image = CType(resources.GetObject("btnCodigosConErrores.Image"), System.Drawing.Image)
        Me.btnCodigosConErrores.Location = New System.Drawing.Point(26, 3)
        Me.btnCodigosConErrores.Name = "btnCodigosConErrores"
        Me.btnCodigosConErrores.Size = New System.Drawing.Size(32, 32)
        Me.btnCodigosConErrores.TabIndex = 53
        Me.btnCodigosConErrores.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(3, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Corregir Errores"
        '
        'pnlActualizarDatos
        '
        Me.pnlActualizarDatos.Controls.Add(Me.btnActualizarDatos)
        Me.pnlActualizarDatos.Controls.Add(Me.lblActualizarDatos)
        Me.pnlActualizarDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlActualizarDatos.Location = New System.Drawing.Point(233, 0)
        Me.pnlActualizarDatos.Name = "pnlActualizarDatos"
        Me.pnlActualizarDatos.Size = New System.Drawing.Size(95, 59)
        Me.pnlActualizarDatos.TabIndex = 56
        Me.pnlActualizarDatos.Visible = False
        '
        'btnActualizarDatos
        '
        Me.btnActualizarDatos.Image = Global.Almacen.Vista.My.Resources.Resources.refresh_32
        Me.btnActualizarDatos.Location = New System.Drawing.Point(31, 3)
        Me.btnActualizarDatos.Name = "btnActualizarDatos"
        Me.btnActualizarDatos.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizarDatos.TabIndex = 49
        Me.btnActualizarDatos.UseVisualStyleBackColor = True
        '
        'lblActualizarDatos
        '
        Me.lblActualizarDatos.AutoSize = True
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Location = New System.Drawing.Point(5, 38)
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        Me.lblActualizarDatos.Size = New System.Drawing.Size(84, 13)
        Me.lblActualizarDatos.TabIndex = 50
        Me.lblActualizarDatos.Text = "Actualizar Datos"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(174, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(59, 59)
        Me.pnlExportar.TabIndex = 55
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(14, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 25
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(6, 38)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 26
        Me.lblExportar.Text = "Exportar"
        '
        'pnlVerPares
        '
        Me.pnlVerPares.Controls.Add(Me.btnVerPares)
        Me.pnlVerPares.Controls.Add(Me.lblDetalles)
        Me.pnlVerPares.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVerPares.Location = New System.Drawing.Point(109, 0)
        Me.pnlVerPares.Name = "pnlVerPares"
        Me.pnlVerPares.Size = New System.Drawing.Size(65, 59)
        Me.pnlVerPares.TabIndex = 39
        '
        'btnVerPares
        '
        Me.btnVerPares.Image = Global.Almacen.Vista.My.Resources.Resources.pares
        Me.btnVerPares.Location = New System.Drawing.Point(17, 3)
        Me.btnVerPares.Name = "btnVerPares"
        Me.btnVerPares.Size = New System.Drawing.Size(32, 32)
        Me.btnVerPares.TabIndex = 40
        Me.btnVerPares.UseVisualStyleBackColor = True
        '
        'lblDetalles
        '
        Me.lblDetalles.AutoSize = True
        Me.lblDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDetalles.Location = New System.Drawing.Point(6, 38)
        Me.lblDetalles.Name = "lblDetalles"
        Me.lblDetalles.Size = New System.Drawing.Size(53, 13)
        Me.lblDetalles.TabIndex = 39
        Me.lblDetalles.Text = "Ver Pares"
        '
        'pnlGenerarEmbarque
        '
        Me.pnlGenerarEmbarque.Controls.Add(Me.btnGenerarEmbarque)
        Me.pnlGenerarEmbarque.Controls.Add(Me.lblBtnGenerarEmbarques)
        Me.pnlGenerarEmbarque.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarEmbarque.Location = New System.Drawing.Point(0, 0)
        Me.pnlGenerarEmbarque.Name = "pnlGenerarEmbarque"
        Me.pnlGenerarEmbarque.Size = New System.Drawing.Size(109, 59)
        Me.pnlGenerarEmbarque.TabIndex = 54
        '
        'btnGenerarEmbarque
        '
        Me.btnGenerarEmbarque.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGenerarEmbarque.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarEmbarque.Image = Global.Almacen.Vista.My.Resources.Resources.embarcar
        Me.btnGenerarEmbarque.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGenerarEmbarque.Location = New System.Drawing.Point(40, 3)
        Me.btnGenerarEmbarque.Name = "btnGenerarEmbarque"
        Me.btnGenerarEmbarque.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarEmbarque.TabIndex = 8
        Me.btnGenerarEmbarque.UseVisualStyleBackColor = True
        '
        'lblBtnGenerarEmbarques
        '
        Me.lblBtnGenerarEmbarques.AutoSize = True
        Me.lblBtnGenerarEmbarques.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnGenerarEmbarques.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBtnGenerarEmbarques.Location = New System.Drawing.Point(6, 38)
        Me.lblBtnGenerarEmbarques.Name = "lblBtnGenerarEmbarques"
        Me.lblBtnGenerarEmbarques.Size = New System.Drawing.Size(96, 13)
        Me.lblBtnGenerarEmbarques.TabIndex = 7
        Me.lblBtnGenerarEmbarques.Text = "Generar Embarque"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(502, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(652, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(317, 15)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(223, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Generación de Embarques"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gridEmbarques)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 298)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1154, 175)
        Me.Panel3.TabIndex = 8
        '
        'gridEmbarques
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridEmbarques.DisplayLayout.Appearance = Appearance1
        Me.gridEmbarques.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridEmbarques.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridEmbarques.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridEmbarques.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridEmbarques.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridEmbarques.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridEmbarques.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridEmbarques.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridEmbarques.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.gridEmbarques.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridEmbarques.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridEmbarques.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridEmbarques.Location = New System.Drawing.Point(0, 0)
        Me.gridEmbarques.Name = "gridEmbarques"
        Me.gridEmbarques.Size = New System.Drawing.Size(1154, 175)
        Me.gridEmbarques.TabIndex = 2
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(355, 74)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(88, 13)
        Me.lblNave.TabIndex = 13
        Me.lblNave.Text = "Status Embarque"
        '
        'cboxStatus
        '
        Me.cboxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxStatus.FormattingEnabled = True
        Me.cboxStatus.Items.AddRange(New Object() {"", "ACTIVA", "EN RUTA", "ENTREGA COMPLETA", "ENTREGA PARCIAL"})
        Me.cboxStatus.Location = New System.Drawing.Point(464, 71)
        Me.cboxStatus.Name = "cboxStatus"
        Me.cboxStatus.Size = New System.Drawing.Size(130, 21)
        Me.cboxStatus.TabIndex = 14
        '
        'dtpFacturacionDel
        '
        Me.dtpFacturacionDel.CustomFormat = ""
        Me.dtpFacturacionDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFacturacionDel.Location = New System.Drawing.Point(747, 63)
        Me.dtpFacturacionDel.Name = "dtpFacturacionDel"
        Me.dtpFacturacionDel.Size = New System.Drawing.Size(86, 20)
        Me.dtpFacturacionDel.TabIndex = 18
        Me.dtpFacturacionDel.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblFacturacionDel
        '
        Me.lblFacturacionDel.AutoSize = True
        Me.lblFacturacionDel.ForeColor = System.Drawing.Color.Black
        Me.lblFacturacionDel.Location = New System.Drawing.Point(720, 66)
        Me.lblFacturacionDel.Name = "lblFacturacionDel"
        Me.lblFacturacionDel.Size = New System.Drawing.Size(23, 13)
        Me.lblFacturacionDel.TabIndex = 21
        Me.lblFacturacionDel.Text = "Del"
        '
        'chboxFiltrarFechaFacturacion
        '
        Me.chboxFiltrarFechaFacturacion.AutoSize = True
        Me.chboxFiltrarFechaFacturacion.Location = New System.Drawing.Point(606, 65)
        Me.chboxFiltrarFechaFacturacion.Name = "chboxFiltrarFechaFacturacion"
        Me.chboxFiltrarFechaFacturacion.Size = New System.Drawing.Size(82, 17)
        Me.chboxFiltrarFechaFacturacion.TabIndex = 23
        Me.chboxFiltrarFechaFacturacion.Text = "Facturación"
        Me.chboxFiltrarFechaFacturacion.UseVisualStyleBackColor = True
        '
        'dtpFacturacionAl
        '
        Me.dtpFacturacionAl.CustomFormat = ""
        Me.dtpFacturacionAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFacturacionAl.Location = New System.Drawing.Point(891, 63)
        Me.dtpFacturacionAl.Name = "dtpFacturacionAl"
        Me.dtpFacturacionAl.Size = New System.Drawing.Size(86, 20)
        Me.dtpFacturacionAl.TabIndex = 24
        Me.dtpFacturacionAl.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblFacturacionAl
        '
        Me.lblFacturacionAl.AutoSize = True
        Me.lblFacturacionAl.ForeColor = System.Drawing.Color.Black
        Me.lblFacturacionAl.Location = New System.Drawing.Point(869, 66)
        Me.lblFacturacionAl.Name = "lblFacturacionAl"
        Me.lblFacturacionAl.Size = New System.Drawing.Size(16, 13)
        Me.lblFacturacionAl.TabIndex = 25
        Me.lblFacturacionAl.Text = "Al"
        '
        'dtpConfirmacionDel
        '
        Me.dtpConfirmacionDel.CustomFormat = ""
        Me.dtpConfirmacionDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpConfirmacionDel.Location = New System.Drawing.Point(747, 37)
        Me.dtpConfirmacionDel.Name = "dtpConfirmacionDel"
        Me.dtpConfirmacionDel.Size = New System.Drawing.Size(86, 20)
        Me.dtpConfirmacionDel.TabIndex = 36
        Me.dtpConfirmacionDel.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblConfirmacionOTDel
        '
        Me.lblConfirmacionOTDel.AutoSize = True
        Me.lblConfirmacionOTDel.ForeColor = System.Drawing.Color.Black
        Me.lblConfirmacionOTDel.Location = New System.Drawing.Point(720, 41)
        Me.lblConfirmacionOTDel.Name = "lblConfirmacionOTDel"
        Me.lblConfirmacionOTDel.Size = New System.Drawing.Size(23, 13)
        Me.lblConfirmacionOTDel.TabIndex = 37
        Me.lblConfirmacionOTDel.Text = "Del"
        '
        'chboxFiltrarFechaConfirmacionOT
        '
        Me.chboxFiltrarFechaConfirmacionOT.AutoSize = True
        Me.chboxFiltrarFechaConfirmacionOT.Location = New System.Drawing.Point(606, 40)
        Me.chboxFiltrarFechaConfirmacionOT.Name = "chboxFiltrarFechaConfirmacionOT"
        Me.chboxFiltrarFechaConfirmacionOT.Size = New System.Drawing.Size(105, 17)
        Me.chboxFiltrarFechaConfirmacionOT.TabIndex = 38
        Me.chboxFiltrarFechaConfirmacionOT.Text = "Confirmación OT"
        Me.chboxFiltrarFechaConfirmacionOT.UseVisualStyleBackColor = True
        '
        'dtpConfirmacionAl
        '
        Me.dtpConfirmacionAl.CustomFormat = ""
        Me.dtpConfirmacionAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpConfirmacionAl.Location = New System.Drawing.Point(891, 37)
        Me.dtpConfirmacionAl.Name = "dtpConfirmacionAl"
        Me.dtpConfirmacionAl.Size = New System.Drawing.Size(86, 20)
        Me.dtpConfirmacionAl.TabIndex = 39
        Me.dtpConfirmacionAl.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblConfirmacionOTAl
        '
        Me.lblConfirmacionOTAl.AutoSize = True
        Me.lblConfirmacionOTAl.ForeColor = System.Drawing.Color.Black
        Me.lblConfirmacionOTAl.Location = New System.Drawing.Point(869, 42)
        Me.lblConfirmacionOTAl.Name = "lblConfirmacionOTAl"
        Me.lblConfirmacionOTAl.Size = New System.Drawing.Size(16, 13)
        Me.lblConfirmacionOTAl.TabIndex = 40
        Me.lblConfirmacionOTAl.Text = "Al"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chboxSepararTienda)
        Me.GroupBox2.Controls.Add(Me.rbtnPedidos)
        Me.GroupBox2.Controls.Add(Me.rbtnFacturasDocumentos)
        Me.GroupBox2.Controls.Add(Me.rbtnOrdenesTrabajo)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 26)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(299, 67)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agrupamiento"
        '
        'chboxSepararTienda
        '
        Me.chboxSepararTienda.AutoSize = True
        Me.chboxSepararTienda.Checked = True
        Me.chboxSepararTienda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSepararTienda.Location = New System.Drawing.Point(184, 47)
        Me.chboxSepararTienda.Name = "chboxSepararTienda"
        Me.chboxSepararTienda.Size = New System.Drawing.Size(113, 17)
        Me.chboxSepararTienda.TabIndex = 3
        Me.chboxSepararTienda.Text = "Separar por tienda"
        Me.chboxSepararTienda.UseVisualStyleBackColor = True
        '
        'rbtnPedidos
        '
        Me.rbtnPedidos.AutoSize = True
        Me.rbtnPedidos.Location = New System.Drawing.Point(11, 49)
        Me.rbtnPedidos.Name = "rbtnPedidos"
        Me.rbtnPedidos.Size = New System.Drawing.Size(63, 17)
        Me.rbtnPedidos.TabIndex = 2
        Me.rbtnPedidos.Text = "Pedidos"
        Me.rbtnPedidos.UseVisualStyleBackColor = True
        '
        'rbtnFacturasDocumentos
        '
        Me.rbtnFacturasDocumentos.AutoSize = True
        Me.rbtnFacturasDocumentos.Location = New System.Drawing.Point(11, 32)
        Me.rbtnFacturasDocumentos.Name = "rbtnFacturasDocumentos"
        Me.rbtnFacturasDocumentos.Size = New System.Drawing.Size(137, 17)
        Me.rbtnFacturasDocumentos.TabIndex = 1
        Me.rbtnFacturasDocumentos.Text = "Facturas / Documentos"
        Me.rbtnFacturasDocumentos.UseVisualStyleBackColor = True
        '
        'rbtnOrdenesTrabajo
        '
        Me.rbtnOrdenesTrabajo.AutoSize = True
        Me.rbtnOrdenesTrabajo.Checked = True
        Me.rbtnOrdenesTrabajo.Location = New System.Drawing.Point(11, 16)
        Me.rbtnOrdenesTrabajo.Name = "rbtnOrdenesTrabajo"
        Me.rbtnOrdenesTrabajo.Size = New System.Drawing.Size(119, 17)
        Me.rbtnOrdenesTrabajo.TabIndex = 0
        Me.rbtnOrdenesTrabajo.TabStop = True
        Me.rbtnOrdenesTrabajo.Text = "Órdenes de Trabajo"
        Me.rbtnOrdenesTrabajo.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1154, 24)
        Me.Panel6.TabIndex = 46
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnArriba.Image = Global.Almacen.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(1084, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbajo.Image = Global.Almacen.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(1110, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'gboxClientes
        '
        Me.gboxClientes.Controls.Add(Me.Panel4)
        Me.gboxClientes.Controls.Add(Me.btnClientes)
        Me.gboxClientes.Location = New System.Drawing.Point(11, 98)
        Me.gboxClientes.Name = "gboxClientes"
        Me.gboxClientes.Size = New System.Drawing.Size(441, 117)
        Me.gboxClientes.TabIndex = 52
        Me.gboxClientes.TabStop = False
        Me.gboxClientes.Text = "Cliente"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.gridClientes)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(3, 36)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(435, 78)
        Me.Panel4.TabIndex = 2
        '
        'gridClientes
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridClientes.DisplayLayout.Appearance = Appearance3
        Me.gridClientes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridClientes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.gridClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridClientes.Location = New System.Drawing.Point(0, 0)
        Me.gridClientes.Name = "gridClientes"
        Me.gridClientes.Size = New System.Drawing.Size(435, 78)
        Me.gridClientes.TabIndex = 2
        '
        'btnClientes
        '
        Me.btnClientes.Image = CType(resources.GetObject("btnClientes.Image"), System.Drawing.Image)
        Me.btnClientes.Location = New System.Drawing.Point(413, 11)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(22, 22)
        Me.btnClientes.TabIndex = 0
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'gboxPedidos
        '
        Me.gboxPedidos.Controls.Add(Me.Panel5)
        Me.gboxPedidos.Controls.Add(Me.txtPedido)
        Me.gboxPedidos.Location = New System.Drawing.Point(458, 98)
        Me.gboxPedidos.Name = "gboxPedidos"
        Me.gboxPedidos.Size = New System.Drawing.Size(139, 137)
        Me.gboxPedidos.TabIndex = 53
        Me.gboxPedidos.TabStop = False
        Me.gboxPedidos.Text = "Pedido SICY"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.gridPedidos)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 36)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(133, 98)
        Me.Panel5.TabIndex = 2
        '
        'gridPedidos
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridPedidos.DisplayLayout.Appearance = Appearance5
        Me.gridPedidos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridPedidos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridPedidos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridPedidos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridPedidos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridPedidos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridPedidos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridPedidos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridPedidos.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.gridPedidos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridPedidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPedidos.Location = New System.Drawing.Point(0, 0)
        Me.gridPedidos.Name = "gridPedidos"
        Me.gridPedidos.Size = New System.Drawing.Size(133, 98)
        Me.gridPedidos.TabIndex = 1
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(6, 14)
        Me.txtPedido.Mask = "99999999999999999"
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPedido.Size = New System.Drawing.Size(101, 20)
        Me.txtPedido.TabIndex = 0
        Me.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.txtOrdenTrabajo)
        Me.GroupBox1.Location = New System.Drawing.Point(604, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 137)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Orden Trabajo"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gridOrdenTrabajo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(133, 98)
        Me.Panel1.TabIndex = 2
        '
        'gridOrdenTrabajo
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridOrdenTrabajo.DisplayLayout.Appearance = Appearance7
        Me.gridOrdenTrabajo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridOrdenTrabajo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridOrdenTrabajo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridOrdenTrabajo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridOrdenTrabajo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridOrdenTrabajo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridOrdenTrabajo.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridOrdenTrabajo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridOrdenTrabajo.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.gridOrdenTrabajo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridOrdenTrabajo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridOrdenTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridOrdenTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.gridOrdenTrabajo.Name = "gridOrdenTrabajo"
        Me.gridOrdenTrabajo.Size = New System.Drawing.Size(133, 98)
        Me.gridOrdenTrabajo.TabIndex = 1
        '
        'txtOrdenTrabajo
        '
        Me.txtOrdenTrabajo.Location = New System.Drawing.Point(6, 14)
        Me.txtOrdenTrabajo.Mask = "99999999999999999"
        Me.txtOrdenTrabajo.Name = "txtOrdenTrabajo"
        Me.txtOrdenTrabajo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtOrdenTrabajo.Size = New System.Drawing.Size(101, 20)
        Me.txtOrdenTrabajo.TabIndex = 0
        Me.txtOrdenTrabajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Controls.Add(Me.btnMensajerias)
        Me.GroupBox3.Location = New System.Drawing.Point(749, 98)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(398, 137)
        Me.GroupBox3.TabIndex = 54
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensajerías"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.gridMensajeria)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(392, 98)
        Me.Panel2.TabIndex = 2
        '
        'gridMensajeria
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridMensajeria.DisplayLayout.Appearance = Appearance9
        Me.gridMensajeria.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridMensajeria.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridMensajeria.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridMensajeria.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridMensajeria.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridMensajeria.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridMensajeria.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridMensajeria.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridMensajeria.DisplayLayout.Override.RowAlternateAppearance = Appearance10
        Me.gridMensajeria.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridMensajeria.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridMensajeria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMensajeria.Location = New System.Drawing.Point(0, 0)
        Me.gridMensajeria.Name = "gridMensajeria"
        Me.gridMensajeria.Size = New System.Drawing.Size(392, 98)
        Me.gridMensajeria.TabIndex = 1
        '
        'btnMensajerias
        '
        Me.btnMensajerias.Image = CType(resources.GetObject("btnMensajerias.Image"), System.Drawing.Image)
        Me.btnMensajerias.Location = New System.Drawing.Point(370, 11)
        Me.btnMensajerias.Name = "btnMensajerias"
        Me.btnMensajerias.Size = New System.Drawing.Size(22, 22)
        Me.btnMensajerias.TabIndex = 0
        Me.btnMensajerias.UseVisualStyleBackColor = True
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.lblNaveAlmacen)
        Me.pnlParametros.Controls.Add(Me.cboxNaveAlmacen)
        Me.pnlParametros.Controls.Add(Me.lblStatusProceso)
        Me.pnlParametros.Controls.Add(Me.Label2)
        Me.pnlParametros.Controls.Add(Me.lblMensajeUltimaActualizacion)
        Me.pnlParametros.Controls.Add(Me.chkSeleccionarTodo)
        Me.pnlParametros.Controls.Add(Me.GroupBox3)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.gboxPedidos)
        Me.pnlParametros.Controls.Add(Me.gboxClientes)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Controls.Add(Me.GroupBox2)
        Me.pnlParametros.Controls.Add(Me.lblConfirmacionOTAl)
        Me.pnlParametros.Controls.Add(Me.dtpConfirmacionAl)
        Me.pnlParametros.Controls.Add(Me.chboxFiltrarFechaConfirmacionOT)
        Me.pnlParametros.Controls.Add(Me.lblConfirmacionOTDel)
        Me.pnlParametros.Controls.Add(Me.dtpConfirmacionDel)
        Me.pnlParametros.Controls.Add(Me.lblFacturacionAl)
        Me.pnlParametros.Controls.Add(Me.dtpFacturacionAl)
        Me.pnlParametros.Controls.Add(Me.chboxFiltrarFechaFacturacion)
        Me.pnlParametros.Controls.Add(Me.lblFacturacionDel)
        Me.pnlParametros.Controls.Add(Me.dtpFacturacionDel)
        Me.pnlParametros.Controls.Add(Me.cboxStatus)
        Me.pnlParametros.Controls.Add(Me.lblNave)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1154, 239)
        Me.pnlParametros.TabIndex = 7
        '
        'lblNaveAlmacen
        '
        Me.lblNaveAlmacen.AutoSize = True
        Me.lblNaveAlmacen.BackColor = System.Drawing.Color.Transparent
        Me.lblNaveAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblNaveAlmacen.ForeColor = System.Drawing.Color.Black
        Me.lblNaveAlmacen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNaveAlmacen.Location = New System.Drawing.Point(993, 42)
        Me.lblNaveAlmacen.Name = "lblNaveAlmacen"
        Me.lblNaveAlmacen.Size = New System.Drawing.Size(39, 13)
        Me.lblNaveAlmacen.TabIndex = 80
        Me.lblNaveAlmacen.Text = "CEDIS"
        '
        'cboxNaveAlmacen
        '
        Me.cboxNaveAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNaveAlmacen.FormattingEnabled = True
        Me.cboxNaveAlmacen.Location = New System.Drawing.Point(1038, 38)
        Me.cboxNaveAlmacen.Name = "cboxNaveAlmacen"
        Me.cboxNaveAlmacen.Size = New System.Drawing.Size(106, 21)
        Me.cboxNaveAlmacen.TabIndex = 79
        '
        'lblStatusProceso
        '
        Me.lblStatusProceso.AutoSize = True
        Me.lblStatusProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusProceso.ForeColor = System.Drawing.Color.Black
        Me.lblStatusProceso.Location = New System.Drawing.Point(452, 52)
        Me.lblStatusProceso.Name = "lblStatusProceso"
        Me.lblStatusProceso.Size = New System.Drawing.Size(11, 13)
        Me.lblStatusProceso.TabIndex = 58
        Me.lblStatusProceso.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(342, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Última actualización:"
        '
        'lblMensajeUltimaActualizacion
        '
        Me.lblMensajeUltimaActualizacion.AutoSize = True
        Me.lblMensajeUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblMensajeUltimaActualizacion.Location = New System.Drawing.Point(452, 32)
        Me.lblMensajeUltimaActualizacion.Name = "lblMensajeUltimaActualizacion"
        Me.lblMensajeUltimaActualizacion.Size = New System.Drawing.Size(11, 13)
        Me.lblMensajeUltimaActualizacion.TabIndex = 56
        Me.lblMensajeUltimaActualizacion.Text = "."
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(11, 218)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodo.TabIndex = 55
        Me.chkSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(522, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(295, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "La información mostrada corresponde a mercancía facturada"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 32)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Registros seleccionados"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(41, 38)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(49, 22)
        Me.lblNumFiltrados.TabIndex = 123
        Me.lblNumFiltrados.Text = "2"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 473)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1154, 66)
        Me.pnlPie.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(522, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "El filtro de Mensajerias no aplica para COPPEL"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(823, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(331, 66)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Almacen.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(215, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(212, 44)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 4
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(271, 12)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(154, 44)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Mostrar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(270, 44)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(159, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(569, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'GenerarEmbarqueSalidasAlmacénForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 539)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlPie)
        Me.Name = "GenerarEmbarqueSalidasAlmacénForm"
        Me.Text = "Generación de Embarques"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlCorregirErrores.ResumeLayout(False)
        Me.pnlCorregirErrores.PerformLayout()
        Me.pnlActualizarDatos.ResumeLayout(False)
        Me.pnlActualizarDatos.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlVerPares.ResumeLayout(False)
        Me.pnlVerPares.PerformLayout()
        Me.pnlGenerarEmbarque.ResumeLayout(False)
        Me.pnlGenerarEmbarque.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.gridEmbarques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.gboxClientes.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.gridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxPedidos.ResumeLayout(False)
        Me.gboxPedidos.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.gridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.gridOrdenTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.gridMensajeria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblBtnGenerarEmbarques As System.Windows.Forms.Label
    Friend WithEvents btnGenerarEmbarque As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblDetalles As System.Windows.Forms.Label
    Friend WithEvents btnVerPares As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cboxStatus As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFacturacionDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFacturacionDel As System.Windows.Forms.Label
    Friend WithEvents chboxFiltrarFechaFacturacion As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFacturacionAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFacturacionAl As System.Windows.Forms.Label
    Friend WithEvents dtpConfirmacionDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblConfirmacionOTDel As System.Windows.Forms.Label
    Friend WithEvents chboxFiltrarFechaConfirmacionOT As System.Windows.Forms.CheckBox
    Friend WithEvents dtpConfirmacionAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblConfirmacionOTAl As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chboxSepararTienda As System.Windows.Forms.CheckBox
    Friend WithEvents rbtnPedidos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFacturasDocumentos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnOrdenesTrabajo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents gboxClientes As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnClientes As System.Windows.Forms.Button
    Friend WithEvents gboxPedidos As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents gridPedidos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtPedido As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridOrdenTrabajo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtOrdenTrabajo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents gridMensajeria As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnMensajerias As System.Windows.Forms.Button
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gridClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents lblActualizarDatos As System.Windows.Forms.Label
    Friend WithEvents btnActualizarDatos As System.Windows.Forms.Button
    Friend WithEvents lblStatusProceso As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMensajeUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents gridEmbarques As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCodigosConErrores As Button
    Friend WithEvents pnlCorregirErrores As Panel
    Friend WithEvents pnlActualizarDatos As Panel
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents pnlVerPares As Panel
    Friend WithEvents pnlGenerarEmbarque As Panel
    Friend WithEvents lblNaveAlmacen As Label
    Friend WithEvents cboxNaveAlmacen As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
