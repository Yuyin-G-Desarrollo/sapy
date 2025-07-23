<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoverHorma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMoverHorma))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cmbSimulaciones = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLineaProduccion = New System.Windows.Forms.Label()
        Me.cmbLineaProduccion = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.tbtDatos = New System.Windows.Forms.TabControl()
        Me.tbtProductos = New System.Windows.Forms.TabPage()
        Me.grdArticulosDestino = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdOrdenNaves = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnGuardarOrdenamiento = New System.Windows.Forms.Button()
        Me.lblGuardarOrden = New System.Windows.Forms.Label()
        Me.grpProductosDatos = New System.Windows.Forms.GroupBox()
        Me.chkTodosProductos = New System.Windows.Forms.CheckBox()
        Me.btnCambiarCapacidadCeldas = New System.Windows.Forms.Button()
        Me.numCamtidadProds = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnFiltroRapidoArticulos = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rdoAnadir = New System.Windows.Forms.RadioButton()
        Me.rdoTraspasar = New System.Windows.Forms.RadioButton()
        Me.rdoDuplicar = New System.Windows.Forms.RadioButton()
        Me.cmbLineasProduccionArticulos = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numAnioProds = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numSemPrdsFin = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numSemPrdsInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbtHormas = New System.Windows.Forms.TabPage()
        Me.grdHormasCapacidadSimulacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpHormasDatos = New System.Windows.Forms.GroupBox()
        Me.chkTodosHormas = New System.Windows.Forms.CheckBox()
        Me.btnCantidadHorma = New System.Windows.Forms.Button()
        Me.numCantidadHorms = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numSemHormsFin = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numSemHormsInicio = New System.Windows.Forms.NumericUpDown()
        Me.lblSemanaInicio = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblQuitar = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblSeleccionado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.grpDatos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tbtDatos.SuspendLayout()
        Me.tbtProductos.SuspendLayout()
        CType(Me.grdArticulosDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdOrdenNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.grpProductosDatos.SuspendLayout()
        CType(Me.numCamtidadProds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.numAnioProds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemPrdsFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemPrdsInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtHormas.SuspendLayout()
        CType(Me.grdHormasCapacidadSimulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpHormasDatos.SuspendLayout()
        CType(Me.numCantidadHorms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemHormsFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemHormsInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotones.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Panel4)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1053, 60)
        Me.pnlHeader.TabIndex = 38
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.lblTitulo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(754, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(299, 60)
        Me.Panel4.TabIndex = 48
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(21, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(209, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Cambiar Horma / Artículo"
        '
        'grpDatos
        '
        Me.grpDatos.BackColor = System.Drawing.Color.Transparent
        Me.grpDatos.Controls.Add(Me.cmbSimulaciones)
        Me.grpDatos.Controls.Add(Me.Label1)
        Me.grpDatos.Controls.Add(Me.lblLineaProduccion)
        Me.grpDatos.Controls.Add(Me.cmbLineaProduccion)
        Me.grpDatos.Controls.Add(Me.Panel1)
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpDatos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpDatos.Location = New System.Drawing.Point(0, 60)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(1053, 69)
        Me.grpDatos.TabIndex = 49
        Me.grpDatos.TabStop = False
        '
        'cmbSimulaciones
        '
        Me.cmbSimulaciones.FormattingEnabled = True
        Me.cmbSimulaciones.Location = New System.Drawing.Point(73, 43)
        Me.cmbSimulaciones.Name = "cmbSimulaciones"
        Me.cmbSimulaciones.Size = New System.Drawing.Size(305, 21)
        Me.cmbSimulaciones.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Simulación"
        '
        'lblLineaProduccion
        '
        Me.lblLineaProduccion.AutoSize = True
        Me.lblLineaProduccion.Location = New System.Drawing.Point(401, 40)
        Me.lblLineaProduccion.Name = "lblLineaProduccion"
        Me.lblLineaProduccion.Size = New System.Drawing.Size(61, 26)
        Me.lblLineaProduccion.TabIndex = 40
        Me.lblLineaProduccion.Text = "Linea de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Producción"
        '
        'cmbLineaProduccion
        '
        Me.cmbLineaProduccion.FormattingEnabled = True
        Me.cmbLineaProduccion.Location = New System.Drawing.Point(465, 43)
        Me.cmbLineaProduccion.Name = "cmbLineaProduccion"
        Me.cmbLineaProduccion.Size = New System.Drawing.Size(305, 21)
        Me.cmbLineaProduccion.TabIndex = 39
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(971, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(79, 50)
        Me.Panel1.TabIndex = 38
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(15, -1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 3
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(45, -1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 4
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'tbtDatos
        '
        Me.tbtDatos.Controls.Add(Me.tbtProductos)
        Me.tbtDatos.Controls.Add(Me.tbtHormas)
        Me.tbtDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtDatos.Location = New System.Drawing.Point(0, 129)
        Me.tbtDatos.Name = "tbtDatos"
        Me.tbtDatos.SelectedIndex = 0
        Me.tbtDatos.Size = New System.Drawing.Size(1053, 402)
        Me.tbtDatos.TabIndex = 39
        '
        'tbtProductos
        '
        Me.tbtProductos.BackColor = System.Drawing.Color.AliceBlue
        Me.tbtProductos.Controls.Add(Me.grdArticulosDestino)
        Me.tbtProductos.Controls.Add(Me.Splitter1)
        Me.tbtProductos.Controls.Add(Me.Panel2)
        Me.tbtProductos.Controls.Add(Me.grpProductosDatos)
        Me.tbtProductos.Location = New System.Drawing.Point(4, 22)
        Me.tbtProductos.Name = "tbtProductos"
        Me.tbtProductos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtProductos.Size = New System.Drawing.Size(1045, 376)
        Me.tbtProductos.TabIndex = 1
        Me.tbtProductos.Text = "Productos"
        '
        'grdArticulosDestino
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdArticulosDestino.DisplayLayout.Appearance = Appearance1
        Me.grdArticulosDestino.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdArticulosDestino.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdArticulosDestino.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdArticulosDestino.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdArticulosDestino.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdArticulosDestino.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdArticulosDestino.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdArticulosDestino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdArticulosDestino.Location = New System.Drawing.Point(3, 72)
        Me.grdArticulosDestino.Name = "grdArticulosDestino"
        Me.grdArticulosDestino.Size = New System.Drawing.Size(841, 301)
        Me.grdArticulosDestino.TabIndex = 99
        Me.grdArticulosDestino.Text = "Nave (Linea) Destino"
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.DarkGray
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(844, 72)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 301)
        Me.Splitter1.TabIndex = 105
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdOrdenNaves)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(847, 72)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(195, 301)
        Me.Panel2.TabIndex = 106
        '
        'grdOrdenNaves
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenNaves.DisplayLayout.Appearance = Appearance3
        Me.grdOrdenNaves.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdOrdenNaves.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdOrdenNaves.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenNaves.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenNaves.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdOrdenNaves.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOrdenNaves.Location = New System.Drawing.Point(0, 0)
        Me.grdOrdenNaves.Name = "grdOrdenNaves"
        Me.grdOrdenNaves.Size = New System.Drawing.Size(195, 256)
        Me.grdOrdenNaves.TabIndex = 100
        Me.grdOrdenNaves.Text = "Orden Naves"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 256)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(195, 45)
        Me.Panel6.TabIndex = 101
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnGuardarOrdenamiento)
        Me.Panel7.Controls.Add(Me.lblGuardarOrden)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(71, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(124, 45)
        Me.Panel7.TabIndex = 44
        '
        'btnGuardarOrdenamiento
        '
        Me.btnGuardarOrdenamiento.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarOrdenamiento.Location = New System.Drawing.Point(69, 1)
        Me.btnGuardarOrdenamiento.Name = "btnGuardarOrdenamiento"
        Me.btnGuardarOrdenamiento.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarOrdenamiento.TabIndex = 42
        Me.btnGuardarOrdenamiento.UseVisualStyleBackColor = True
        '
        'lblGuardarOrden
        '
        Me.lblGuardarOrden.AutoSize = True
        Me.lblGuardarOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardarOrden.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarOrden.Location = New System.Drawing.Point(48, 31)
        Me.lblGuardarOrden.Name = "lblGuardarOrden"
        Me.lblGuardarOrden.Size = New System.Drawing.Size(75, 13)
        Me.lblGuardarOrden.TabIndex = 43
        Me.lblGuardarOrden.Text = "Guardar orden"
        Me.lblGuardarOrden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpProductosDatos
        '
        Me.grpProductosDatos.BackColor = System.Drawing.Color.Transparent
        Me.grpProductosDatos.Controls.Add(Me.chkTodosProductos)
        Me.grpProductosDatos.Controls.Add(Me.btnCambiarCapacidadCeldas)
        Me.grpProductosDatos.Controls.Add(Me.numCamtidadProds)
        Me.grpProductosDatos.Controls.Add(Me.Label13)
        Me.grpProductosDatos.Controls.Add(Me.btnFiltroRapidoArticulos)
        Me.grpProductosDatos.Controls.Add(Me.Panel5)
        Me.grpProductosDatos.Controls.Add(Me.cmbLineasProduccionArticulos)
        Me.grpProductosDatos.Controls.Add(Me.Label5)
        Me.grpProductosDatos.Controls.Add(Me.Label6)
        Me.grpProductosDatos.Controls.Add(Me.numAnioProds)
        Me.grpProductosDatos.Controls.Add(Me.Label10)
        Me.grpProductosDatos.Controls.Add(Me.numSemPrdsFin)
        Me.grpProductosDatos.Controls.Add(Me.Label11)
        Me.grpProductosDatos.Controls.Add(Me.numSemPrdsInicio)
        Me.grpProductosDatos.Controls.Add(Me.Label12)
        Me.grpProductosDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpProductosDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpProductosDatos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpProductosDatos.Location = New System.Drawing.Point(3, 3)
        Me.grpProductosDatos.Name = "grpProductosDatos"
        Me.grpProductosDatos.Size = New System.Drawing.Size(1039, 69)
        Me.grpProductosDatos.TabIndex = 97
        Me.grpProductosDatos.TabStop = False
        '
        'chkTodosProductos
        '
        Me.chkTodosProductos.AutoSize = True
        Me.chkTodosProductos.Location = New System.Drawing.Point(18, 47)
        Me.chkTodosProductos.Name = "chkTodosProductos"
        Me.chkTodosProductos.Size = New System.Drawing.Size(56, 17)
        Me.chkTodosProductos.TabIndex = 84
        Me.chkTodosProductos.Text = "Todos"
        Me.chkTodosProductos.UseVisualStyleBackColor = True
        '
        'btnCambiarCapacidadCeldas
        '
        Me.btnCambiarCapacidadCeldas.Image = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        Me.btnCambiarCapacidadCeldas.Location = New System.Drawing.Point(677, 43)
        Me.btnCambiarCapacidadCeldas.Name = "btnCambiarCapacidadCeldas"
        Me.btnCambiarCapacidadCeldas.Size = New System.Drawing.Size(24, 24)
        Me.btnCambiarCapacidadCeldas.TabIndex = 97
        Me.btnCambiarCapacidadCeldas.UseVisualStyleBackColor = True
        '
        'numCamtidadProds
        '
        Me.numCamtidadProds.Location = New System.Drawing.Point(595, 45)
        Me.numCamtidadProds.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numCamtidadProds.Name = "numCamtidadProds"
        Me.numCamtidadProds.Size = New System.Drawing.Size(76, 20)
        Me.numCamtidadProds.TabIndex = 96
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(540, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "Cantidad"
        '
        'btnFiltroRapidoArticulos
        '
        Me.btnFiltroRapidoArticulos.Image = Global.Programacion.Vista.My.Resources.Resources._1385860942_Zoom
        Me.btnFiltroRapidoArticulos.Location = New System.Drawing.Point(153, 43)
        Me.btnFiltroRapidoArticulos.Name = "btnFiltroRapidoArticulos"
        Me.btnFiltroRapidoArticulos.Size = New System.Drawing.Size(24, 24)
        Me.btnFiltroRapidoArticulos.TabIndex = 89
        Me.btnFiltroRapidoArticulos.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.rdoAnadir)
        Me.Panel5.Controls.Add(Me.rdoTraspasar)
        Me.Panel5.Controls.Add(Me.rdoDuplicar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(835, 16)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(201, 50)
        Me.Panel5.TabIndex = 88
        '
        'rdoAnadir
        '
        Me.rdoAnadir.AutoSize = True
        Me.rdoAnadir.Location = New System.Drawing.Point(11, 34)
        Me.rdoAnadir.Name = "rdoAnadir"
        Me.rdoAnadir.Size = New System.Drawing.Size(179, 17)
        Me.rdoAnadir.TabIndex = 2
        Me.rdoAnadir.Text = "Añadir Artículo a la Nave (Linea)"
        Me.rdoAnadir.UseVisualStyleBackColor = True
        '
        'rdoTraspasar
        '
        Me.rdoTraspasar.AutoSize = True
        Me.rdoTraspasar.Location = New System.Drawing.Point(11, 17)
        Me.rdoTraspasar.Name = "rdoTraspasar"
        Me.rdoTraspasar.Size = New System.Drawing.Size(191, 17)
        Me.rdoTraspasar.TabIndex = 1
        Me.rdoTraspasar.Text = "Traspasar Artículo de Nave (Linea)"
        Me.rdoTraspasar.UseVisualStyleBackColor = True
        '
        'rdoDuplicar
        '
        Me.rdoDuplicar.AutoSize = True
        Me.rdoDuplicar.Checked = True
        Me.rdoDuplicar.Location = New System.Drawing.Point(11, 0)
        Me.rdoDuplicar.Name = "rdoDuplicar"
        Me.rdoDuplicar.Size = New System.Drawing.Size(164, 17)
        Me.rdoDuplicar.TabIndex = 0
        Me.rdoDuplicar.TabStop = True
        Me.rdoDuplicar.Text = "Duplicar de otra Nave (Linea)"
        Me.rdoDuplicar.UseVisualStyleBackColor = True
        '
        'cmbLineasProduccionArticulos
        '
        Me.cmbLineasProduccionArticulos.FormattingEnabled = True
        Me.cmbLineasProduccionArticulos.Location = New System.Drawing.Point(84, 16)
        Me.cmbLineasProduccionArticulos.Name = "cmbLineasProduccionArticulos"
        Me.cmbLineasProduccionArticulos.Size = New System.Drawing.Size(305, 21)
        Me.cmbLineasProduccionArticulos.TabIndex = 86
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 26)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Lineas de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Producción"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(90, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Artículos"
        '
        'numAnioProds
        '
        Me.numAnioProds.Location = New System.Drawing.Point(234, 45)
        Me.numAnioProds.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnioProds.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.numAnioProds.Name = "numAnioProds"
        Me.numAnioProds.Size = New System.Drawing.Size(76, 20)
        Me.numAnioProds.TabIndex = 42
        Me.numAnioProds.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(201, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Año"
        '
        'numSemPrdsFin
        '
        Me.numSemPrdsFin.Location = New System.Drawing.Point(447, 45)
        Me.numSemPrdsFin.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemPrdsFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemPrdsFin.Name = "numSemPrdsFin"
        Me.numSemPrdsFin.Size = New System.Drawing.Size(57, 20)
        Me.numSemPrdsFin.TabIndex = 46
        Me.numSemPrdsFin.Value = New Decimal(New Integer() {52, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(421, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Fin"
        '
        'numSemPrdsInicio
        '
        Me.numSemPrdsInicio.Location = New System.Drawing.Point(356, 45)
        Me.numSemPrdsInicio.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemPrdsInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemPrdsInicio.Name = "numSemPrdsInicio"
        Me.numSemPrdsInicio.Size = New System.Drawing.Size(57, 20)
        Me.numSemPrdsInicio.TabIndex = 44
        Me.numSemPrdsInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(319, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Inicio"
        '
        'tbtHormas
        '
        Me.tbtHormas.BackColor = System.Drawing.Color.AliceBlue
        Me.tbtHormas.Controls.Add(Me.grdHormasCapacidadSimulacion)
        Me.tbtHormas.Controls.Add(Me.grpHormasDatos)
        Me.tbtHormas.Location = New System.Drawing.Point(4, 22)
        Me.tbtHormas.Name = "tbtHormas"
        Me.tbtHormas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtHormas.Size = New System.Drawing.Size(1045, 376)
        Me.tbtHormas.TabIndex = 0
        Me.tbtHormas.Text = "Hormas"
        '
        'grdHormasCapacidadSimulacion
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Appearance = Appearance5
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdHormasCapacidadSimulacion.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdHormasCapacidadSimulacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdHormasCapacidadSimulacion.Location = New System.Drawing.Point(3, 51)
        Me.grdHormasCapacidadSimulacion.Name = "grdHormasCapacidadSimulacion"
        Me.grdHormasCapacidadSimulacion.Size = New System.Drawing.Size(1039, 322)
        Me.grdHormasCapacidadSimulacion.TabIndex = 97
        '
        'grpHormasDatos
        '
        Me.grpHormasDatos.BackColor = System.Drawing.Color.Transparent
        Me.grpHormasDatos.Controls.Add(Me.chkTodosHormas)
        Me.grpHormasDatos.Controls.Add(Me.btnCantidadHorma)
        Me.grpHormasDatos.Controls.Add(Me.numCantidadHorms)
        Me.grpHormasDatos.Controls.Add(Me.Label3)
        Me.grpHormasDatos.Controls.Add(Me.numSemHormsFin)
        Me.grpHormasDatos.Controls.Add(Me.Label4)
        Me.grpHormasDatos.Controls.Add(Me.numSemHormsInicio)
        Me.grpHormasDatos.Controls.Add(Me.lblSemanaInicio)
        Me.grpHormasDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpHormasDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpHormasDatos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpHormasDatos.Location = New System.Drawing.Point(3, 3)
        Me.grpHormasDatos.Name = "grpHormasDatos"
        Me.grpHormasDatos.Size = New System.Drawing.Size(1039, 48)
        Me.grpHormasDatos.TabIndex = 96
        Me.grpHormasDatos.TabStop = False
        '
        'chkTodosHormas
        '
        Me.chkTodosHormas.AutoSize = True
        Me.chkTodosHormas.Location = New System.Drawing.Point(8, 23)
        Me.chkTodosHormas.Name = "chkTodosHormas"
        Me.chkTodosHormas.Size = New System.Drawing.Size(56, 17)
        Me.chkTodosHormas.TabIndex = 95
        Me.chkTodosHormas.Text = "Todos"
        Me.chkTodosHormas.UseVisualStyleBackColor = True
        '
        'btnCantidadHorma
        '
        Me.btnCantidadHorma.Image = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        Me.btnCantidadHorma.Location = New System.Drawing.Point(496, 19)
        Me.btnCantidadHorma.Name = "btnCantidadHorma"
        Me.btnCantidadHorma.Size = New System.Drawing.Size(24, 24)
        Me.btnCantidadHorma.TabIndex = 94
        Me.btnCantidadHorma.UseVisualStyleBackColor = True
        '
        'numCantidadHorms
        '
        Me.numCantidadHorms.Location = New System.Drawing.Point(417, 21)
        Me.numCantidadHorms.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numCantidadHorms.Name = "numCantidadHorms"
        Me.numCantidadHorms.Size = New System.Drawing.Size(76, 20)
        Me.numCantidadHorms.TabIndex = 93
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(362, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Cantidad"
        '
        'numSemHormsFin
        '
        Me.numSemHormsFin.Location = New System.Drawing.Point(250, 21)
        Me.numSemHormsFin.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemHormsFin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemHormsFin.Name = "numSemHormsFin"
        Me.numSemHormsFin.Size = New System.Drawing.Size(57, 20)
        Me.numSemHormsFin.TabIndex = 46
        Me.numSemHormsFin.Value = New Decimal(New Integer() {52, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(224, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Fin"
        '
        'numSemHormsInicio
        '
        Me.numSemHormsInicio.Location = New System.Drawing.Point(159, 21)
        Me.numSemHormsInicio.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemHormsInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemHormsInicio.Name = "numSemHormsInicio"
        Me.numSemHormsInicio.Size = New System.Drawing.Size(57, 20)
        Me.numSemHormsInicio.TabIndex = 44
        Me.numSemHormsInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblSemanaInicio
        '
        Me.lblSemanaInicio.AutoSize = True
        Me.lblSemanaInicio.Location = New System.Drawing.Point(122, 25)
        Me.lblSemanaInicio.Name = "lblSemanaInicio"
        Me.lblSemanaInicio.Size = New System.Drawing.Size(32, 13)
        Me.lblSemanaInicio.TabIndex = 43
        Me.lblSemanaInicio.Text = "Inicio"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.lblQuitar)
        Me.pnlBotones.Controls.Add(Me.btnEliminar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnRegresar)
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.lblAccionRegresar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(820, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(233, 60)
        Me.pnlBotones.TabIndex = 41
        '
        'lblQuitar
        '
        Me.lblQuitar.AutoSize = True
        Me.lblQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuitar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblQuitar.Location = New System.Drawing.Point(56, 41)
        Me.lblQuitar.Name = "lblQuitar"
        Me.lblQuitar.Size = New System.Drawing.Size(35, 13)
        Me.lblQuitar.TabIndex = 43
        Me.lblQuitar.Text = "Quitar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Programacion.Vista.My.Resources.Resources.cancelar_32
        Me.btnEliminar.Location = New System.Drawing.Point(57, 8)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 42
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(111, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 41
        Me.lblGuardar.Text = "Guardar"
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(173, 8)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 7
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(117, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 40
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblAccionRegresar
        '
        Me.lblAccionRegresar.AutoSize = True
        Me.lblAccionRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionRegresar.Location = New System.Drawing.Point(172, 41)
        Me.lblAccionRegresar.Name = "lblAccionRegresar"
        Me.lblAccionRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblAccionRegresar.TabIndex = 39
        Me.lblAccionRegresar.Text = "Cerrar"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.lblSeleccionado)
        Me.Panel3.Controls.Add(Me.pnlBotones)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 531)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1053, 60)
        Me.Panel3.TabIndex = 102
        '
        'lblSeleccionado
        '
        Me.lblSeleccionado.AutoSize = True
        Me.lblSeleccionado.Location = New System.Drawing.Point(9, 8)
        Me.lblSeleccionado.Name = "lblSeleccionado"
        Me.lblSeleccionado.Size = New System.Drawing.Size(16, 13)
        Me.lblSeleccionado.TabIndex = 42
        Me.lblSeleccionado.Text = "---"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(237, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'frmMoverHorma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1053, 591)
        Me.Controls.Add(Me.tbtDatos)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMoverHorma"
        Me.Text = "Cambiar Horma / Artículo"
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.tbtDatos.ResumeLayout(False)
        Me.tbtProductos.ResumeLayout(False)
        CType(Me.grdArticulosDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdOrdenNaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.grpProductosDatos.ResumeLayout(False)
        Me.grpProductosDatos.PerformLayout()
        CType(Me.numCamtidadProds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.numAnioProds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemPrdsFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemPrdsInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtHormas.ResumeLayout(False)
        CType(Me.grdHormasCapacidadSimulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpHormasDatos.ResumeLayout(False)
        Me.grpHormasDatos.PerformLayout()
        CType(Me.numCantidadHorms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemHormsFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemHormsInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents tbtDatos As System.Windows.Forms.TabControl
    Friend WithEvents tbtHormas As System.Windows.Forms.TabPage
    Friend WithEvents lblLineaProduccion As System.Windows.Forms.Label
    Friend WithEvents cmbLineaProduccion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSimulaciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpHormasDatos As System.Windows.Forms.GroupBox
    Friend WithEvents numSemHormsFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numSemHormsInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSemanaInicio As System.Windows.Forms.Label
    Friend WithEvents tbtProductos As System.Windows.Forms.TabPage
    Friend WithEvents grdHormasCapacidadSimulacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdOrdenNaves As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdArticulosDestino As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpProductosDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents rdoAnadir As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTraspasar As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDuplicar As System.Windows.Forms.RadioButton
    Friend WithEvents cmbLineasProduccionArticulos As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numAnioProds As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents numSemPrdsFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents numSemPrdsInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnFiltroRapidoArticulos As System.Windows.Forms.Button
    Friend WithEvents btnCantidadHorma As System.Windows.Forms.Button
    Friend WithEvents numCantidadHorms As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCambiarCapacidadCeldas As System.Windows.Forms.Button
    Friend WithEvents numCamtidadProds As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents lblGuardarOrden As System.Windows.Forms.Label
    Friend WithEvents btnGuardarOrdenamiento As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lblSeleccionado As System.Windows.Forms.Label
    Friend WithEvents lblQuitar As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents chkTodosProductos As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodosHormas As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
