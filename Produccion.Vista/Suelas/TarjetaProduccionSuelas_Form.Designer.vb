<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TarjetaProduccionSuelas_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TarjetaProduccionSuelas_Form))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblDesagrupar = New System.Windows.Forms.Label()
        Me.btnDesagrupar = New System.Windows.Forms.Button()
        Me.lblAgrupar = New System.Windows.Forms.Label()
        Me.btnAgrupar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFinalizar = New System.Windows.Forms.Label()
        Me.btnConcentradoSuelas = New System.Windows.Forms.Button()
        Me.btnVerDetalles = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.lblImprimirOrdenCompra = New System.Windows.Forms.Label()
        Me.btnImprimirTP = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.gboxColeccion = New System.Windows.Forms.GroupBox()
        Me.btnNaves = New System.Windows.Forms.Button()
        Me.btnLimpiarNave = New System.Windows.Forms.Button()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.grdNaves = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxMarca = New System.Windows.Forms.GroupBox()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaDel = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblEntregaAl = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdCntrlTarjeta = New DevExpress.XtraGrid.GridControl()
        Me.MVTarjeta = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.grdCntrolTarjetaOriginal = New DevExpress.XtraGrid.GridControl()
        Me.MVTarjetaOriginal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlTerminada = New System.Windows.Forms.Panel()
        Me.pnlActiva = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpParametros.SuspendLayout()
        Me.gboxColeccion.SuspendLayout()
        Me.Panel24.SuspendLayout()
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxMarca.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCntrlTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MVTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        CType(Me.grdCntrolTarjetaOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MVTarjetaOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1241, 72)
        Me.pnlHeader.TabIndex = 7
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblDesagrupar)
        Me.pnlAcciones.Controls.Add(Me.btnDesagrupar)
        Me.pnlAcciones.Controls.Add(Me.lblAgrupar)
        Me.pnlAcciones.Controls.Add(Me.btnAgrupar)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.Label2)
        Me.pnlAcciones.Controls.Add(Me.lblFinalizar)
        Me.pnlAcciones.Controls.Add(Me.btnConcentradoSuelas)
        Me.pnlAcciones.Controls.Add(Me.btnVerDetalles)
        Me.pnlAcciones.Controls.Add(Me.btnFinalizar)
        Me.pnlAcciones.Controls.Add(Me.lblImprimirOrdenCompra)
        Me.pnlAcciones.Controls.Add(Me.btnImprimirTP)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(523, 72)
        Me.pnlAcciones.TabIndex = 1
        '
        'lblDesagrupar
        '
        Me.lblDesagrupar.AutoSize = True
        Me.lblDesagrupar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDesagrupar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDesagrupar.Location = New System.Drawing.Point(278, 43)
        Me.lblDesagrupar.Name = "lblDesagrupar"
        Me.lblDesagrupar.Size = New System.Drawing.Size(62, 26)
        Me.lblDesagrupar.TabIndex = 113
        Me.lblDesagrupar.Text = "Desagrupar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tarjeta"
        '
        'btnDesagrupar
        '
        Me.btnDesagrupar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDesagrupar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnDesagrupar.Image = Global.Produccion.Vista.My.Resources.Resources._32x32px__2_1
        Me.btnDesagrupar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDesagrupar.Location = New System.Drawing.Point(290, 8)
        Me.btnDesagrupar.Name = "btnDesagrupar"
        Me.btnDesagrupar.Size = New System.Drawing.Size(32, 32)
        Me.btnDesagrupar.TabIndex = 112
        Me.btnDesagrupar.UseVisualStyleBackColor = True
        '
        'lblAgrupar
        '
        Me.lblAgrupar.AutoSize = True
        Me.lblAgrupar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAgrupar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAgrupar.Location = New System.Drawing.Point(231, 43)
        Me.lblAgrupar.Name = "lblAgrupar"
        Me.lblAgrupar.Size = New System.Drawing.Size(44, 26)
        Me.lblAgrupar.TabIndex = 111
        Me.lblAgrupar.Text = "Agrupar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tarjeta"
        '
        'btnAgrupar
        '
        Me.btnAgrupar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAgrupar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAgrupar.Image = Global.Produccion.Vista.My.Resources.Resources.dosar
        Me.btnAgrupar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgrupar.Location = New System.Drawing.Point(234, 8)
        Me.btnAgrupar.Name = "btnAgrupar"
        Me.btnAgrupar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgrupar.TabIndex = 110
        Me.btnAgrupar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(162, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 26)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Concentrado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    Suelas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(117, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Detalles"
        '
        'lblFinalizar
        '
        Me.lblFinalizar.AutoSize = True
        Me.lblFinalizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFinalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFinalizar.Location = New System.Drawing.Point(71, 43)
        Me.lblFinalizar.Name = "lblFinalizar"
        Me.lblFinalizar.Size = New System.Drawing.Size(45, 13)
        Me.lblFinalizar.TabIndex = 109
        Me.lblFinalizar.Text = "Finalizar"
        '
        'btnConcentradoSuelas
        '
        Me.btnConcentradoSuelas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConcentradoSuelas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnConcentradoSuelas.Image = Global.Produccion.Vista.My.Resources.Resources.tarjetaVista
        Me.btnConcentradoSuelas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnConcentradoSuelas.Location = New System.Drawing.Point(178, 8)
        Me.btnConcentradoSuelas.Name = "btnConcentradoSuelas"
        Me.btnConcentradoSuelas.Size = New System.Drawing.Size(32, 32)
        Me.btnConcentradoSuelas.TabIndex = 108
        Me.btnConcentradoSuelas.UseVisualStyleBackColor = True
        '
        'btnVerDetalles
        '
        Me.btnVerDetalles.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVerDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVerDetalles.Image = Global.Produccion.Vista.My.Resources.Resources.catalogos_32
        Me.btnVerDetalles.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVerDetalles.Location = New System.Drawing.Point(123, 8)
        Me.btnVerDetalles.Name = "btnVerDetalles"
        Me.btnVerDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnVerDetalles.TabIndex = 108
        Me.btnVerDetalles.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnFinalizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnFinalizar.Image = Global.Produccion.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnFinalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFinalizar.Location = New System.Drawing.Point(77, 8)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(32, 32)
        Me.btnFinalizar.TabIndex = 108
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'lblImprimirOrdenCompra
        '
        Me.lblImprimirOrdenCompra.AutoSize = True
        Me.lblImprimirOrdenCompra.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimirOrdenCompra.Location = New System.Drawing.Point(25, 43)
        Me.lblImprimirOrdenCompra.Name = "lblImprimirOrdenCompra"
        Me.lblImprimirOrdenCompra.Size = New System.Drawing.Size(45, 26)
        Me.lblImprimirOrdenCompra.TabIndex = 107
        Me.lblImprimirOrdenCompra.Text = "Imprimir " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tarjeta"
        Me.lblImprimirOrdenCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnImprimirTP
        '
        Me.btnImprimirTP.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimirTP.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimirTP.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimirTP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimirTP.Location = New System.Drawing.Point(31, 8)
        Me.btnImprimirTP.Name = "btnImprimirTP"
        Me.btnImprimirTP.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirTP.TabIndex = 75
        Me.btnImprimirTP.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(726, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(515, 72)
        Me.pnlTitulo.TabIndex = 0
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(447, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 72)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 27
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(140, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(278, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Tarjetas de Producción de Suelas"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpParametros
        '
        Me.grpParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grpParametros.Controls.Add(Me.gboxColeccion)
        Me.grpParametros.Controls.Add(Me.gboxMarca)
        Me.grpParametros.Controls.Add(Me.chboxSeleccionarTodo)
        Me.grpParametros.Controls.Add(Me.btnAbajo)
        Me.grpParametros.Controls.Add(Me.btnArriba)
        Me.grpParametros.Controls.Add(Me.GroupBox3)
        Me.grpParametros.Controls.Add(Me.btnLimpiar)
        Me.grpParametros.Controls.Add(Me.btnMostrar)
        Me.grpParametros.Controls.Add(Me.lblBuscar)
        Me.grpParametros.Controls.Add(Me.lblLimpiar)
        Me.grpParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpParametros.Location = New System.Drawing.Point(0, 72)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(1241, 118)
        Me.grpParametros.TabIndex = 9
        Me.grpParametros.TabStop = False
        '
        'gboxColeccion
        '
        Me.gboxColeccion.Controls.Add(Me.btnNaves)
        Me.gboxColeccion.Controls.Add(Me.btnLimpiarNave)
        Me.gboxColeccion.Controls.Add(Me.Panel24)
        Me.gboxColeccion.Location = New System.Drawing.Point(421, 19)
        Me.gboxColeccion.Name = "gboxColeccion"
        Me.gboxColeccion.Size = New System.Drawing.Size(186, 164)
        Me.gboxColeccion.TabIndex = 128
        Me.gboxColeccion.TabStop = False
        Me.gboxColeccion.Text = "Naves"
        Me.gboxColeccion.Visible = False
        '
        'btnNaves
        '
        Me.btnNaves.Image = CType(resources.GetObject("btnNaves.Image"), System.Drawing.Image)
        Me.btnNaves.Location = New System.Drawing.Point(158, 10)
        Me.btnNaves.Name = "btnNaves"
        Me.btnNaves.Size = New System.Drawing.Size(22, 22)
        Me.btnNaves.TabIndex = 131
        Me.btnNaves.UseVisualStyleBackColor = True
        '
        'btnLimpiarNave
        '
        Me.btnLimpiarNave.Image = CType(resources.GetObject("btnLimpiarNave.Image"), System.Drawing.Image)
        Me.btnLimpiarNave.Location = New System.Drawing.Point(133, 10)
        Me.btnLimpiarNave.Name = "btnLimpiarNave"
        Me.btnLimpiarNave.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarNave.TabIndex = 131
        Me.btnLimpiarNave.UseVisualStyleBackColor = True
        '
        'Panel24
        '
        Me.Panel24.Controls.Add(Me.grdNaves)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel24.Location = New System.Drawing.Point(3, 31)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(180, 130)
        Me.Panel24.TabIndex = 2
        '
        'grdNaves
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Appearance = Appearance1
        Me.grdNaves.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdNaves.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdNaves.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdNaves.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdNaves.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdNaves.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdNaves.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdNaves.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdNaves.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdNaves.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdNaves.Location = New System.Drawing.Point(0, 0)
        Me.grdNaves.Name = "grdNaves"
        Me.grdNaves.Size = New System.Drawing.Size(180, 130)
        Me.grdNaves.TabIndex = 5
        '
        'gboxMarca
        '
        Me.gboxMarca.Controls.Add(Me.cmbEstatus)
        Me.gboxMarca.Location = New System.Drawing.Point(215, 32)
        Me.gboxMarca.Name = "gboxMarca"
        Me.gboxMarca.Size = New System.Drawing.Size(188, 79)
        Me.gboxMarca.TabIndex = 127
        Me.gboxMarca.TabStop = False
        Me.gboxMarca.Text = "Estatus"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Items.AddRange(New Object() {"TODOS"})
        Me.cmbEstatus.Location = New System.Drawing.Point(19, 32)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(151, 21)
        Me.cmbEstatus.TabIndex = 0
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(12, 9)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 71
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(1215, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(1191, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox3.Controls.Add(Me.lblEntregaDel)
        Me.GroupBox3.Controls.Add(Me.dtpFechaFin)
        Me.GroupBox3.Controls.Add(Me.lblEntregaAl)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(188, 79)
        Me.GroupBox3.TabIndex = 130
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha Programa"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CustomFormat = ""
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(45, 21)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaInicio.TabIndex = 66
        Me.dtpFechaInicio.Value = New Date(2018, 7, 31, 0, 0, 0, 0)
        '
        'lblEntregaDel
        '
        Me.lblEntregaDel.AutoSize = True
        Me.lblEntregaDel.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaDel.Location = New System.Drawing.Point(16, 24)
        Me.lblEntregaDel.Name = "lblEntregaDel"
        Me.lblEntregaDel.Size = New System.Drawing.Size(23, 13)
        Me.lblEntregaDel.TabIndex = 67
        Me.lblEntregaDel.Text = "Del"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = ""
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(45, 47)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaFin.TabIndex = 69
        Me.dtpFechaFin.Value = New Date(2018, 7, 31, 0, 0, 0, 0)
        '
        'lblEntregaAl
        '
        Me.lblEntregaAl.AutoSize = True
        Me.lblEntregaAl.ForeColor = System.Drawing.Color.Black
        Me.lblEntregaAl.Location = New System.Drawing.Point(23, 50)
        Me.lblEntregaAl.Name = "lblEntregaAl"
        Me.lblEntregaAl.Size = New System.Drawing.Size(16, 13)
        Me.lblEntregaAl.TabIndex = 70
        Me.lblEntregaAl.Text = "Al"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(1194, 47)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 32
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.Location = New System.Drawing.Point(1146, 47)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 31
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(1141, 81)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 34
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(1191, 81)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 33
        Me.lblLimpiar.Text = "Limpiar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdCntrlTarjeta)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 190)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1241, 346)
        Me.Panel1.TabIndex = 13
        '
        'grdCntrlTarjeta
        '
        Me.grdCntrlTarjeta.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdCntrlTarjeta.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdCntrlTarjeta.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdCntrlTarjeta.Location = New System.Drawing.Point(0, 0)
        Me.grdCntrlTarjeta.MainView = Me.MVTarjeta
        Me.grdCntrlTarjeta.Name = "grdCntrlTarjeta"
        Me.grdCntrlTarjeta.Size = New System.Drawing.Size(1241, 346)
        Me.grdCntrlTarjeta.TabIndex = 12
        Me.grdCntrlTarjeta.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MVTarjeta})
        '
        'MVTarjeta
        '
        Me.MVTarjeta.GridControl = Me.grdCntrlTarjeta
        Me.MVTarjeta.Name = "MVTarjeta"
        Me.MVTarjeta.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MVTarjeta.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MVTarjeta.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.MVTarjeta.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.MVTarjeta.OptionsPrint.AllowMultilineHeaders = True
        Me.MVTarjeta.OptionsSelection.MultiSelect = True
        Me.MVTarjeta.OptionsView.ColumnAutoWidth = False
        Me.MVTarjeta.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.MVTarjeta.OptionsView.ShowFooter = True
        Me.MVTarjeta.OptionsView.ShowGroupPanel = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.grdCntrolTarjetaOriginal)
        Me.pnlPie.Controls.Add(Me.GroupBox1)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPie.Location = New System.Drawing.Point(0, 536)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1241, 69)
        Me.pnlPie.TabIndex = 27
        '
        'grdCntrolTarjetaOriginal
        '
        Me.grdCntrolTarjetaOriginal.Cursor = System.Windows.Forms.Cursors.Default
        GridLevelNode2.RelationName = "Level1"
        Me.grdCntrolTarjetaOriginal.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdCntrolTarjetaOriginal.Location = New System.Drawing.Point(432, 3)
        Me.grdCntrolTarjetaOriginal.MainView = Me.MVTarjetaOriginal
        Me.grdCntrolTarjetaOriginal.Name = "grdCntrolTarjetaOriginal"
        Me.grdCntrolTarjetaOriginal.Size = New System.Drawing.Size(417, 150)
        Me.grdCntrolTarjetaOriginal.TabIndex = 13
        Me.grdCntrolTarjetaOriginal.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MVTarjetaOriginal})
        Me.grdCntrolTarjetaOriginal.Visible = False
        '
        'MVTarjetaOriginal
        '
        Me.MVTarjetaOriginal.GridControl = Me.grdCntrolTarjetaOriginal
        Me.MVTarjetaOriginal.Name = "MVTarjetaOriginal"
        Me.MVTarjetaOriginal.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MVTarjetaOriginal.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MVTarjetaOriginal.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.MVTarjetaOriginal.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.MVTarjetaOriginal.OptionsPrint.AllowMultilineHeaders = True
        Me.MVTarjetaOriginal.OptionsSelection.MultiSelect = True
        Me.MVTarjetaOriginal.OptionsView.ColumnAutoWidth = False
        Me.MVTarjetaOriginal.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.MVTarjetaOriginal.OptionsView.ShowFooter = True
        Me.MVTarjetaOriginal.OptionsView.ShowGroupPanel = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.pnlTerminada)
        Me.GroupBox1.Controls.Add(Me.pnlActiva)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(156, 57)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status Tarjeta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Terminada"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(27, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "En Proceso"
        '
        'pnlTerminada
        '
        Me.pnlTerminada.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlTerminada.Location = New System.Drawing.Point(6, 37)
        Me.pnlTerminada.Name = "pnlTerminada"
        Me.pnlTerminada.Size = New System.Drawing.Size(15, 15)
        Me.pnlTerminada.TabIndex = 1
        '
        'pnlActiva
        '
        Me.pnlActiva.BackColor = System.Drawing.Color.DarkGreen
        Me.pnlActiva.Location = New System.Drawing.Point(6, 16)
        Me.pnlActiva.Name = "pnlActiva"
        Me.pnlActiva.Size = New System.Drawing.Size(15, 15)
        Me.pnlActiva.TabIndex = 0
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblSalir)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1056, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(185, 69)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(82, 46)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 9
        Me.lblGuardar.Text = "Guardar"
        Me.lblGuardar.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(88, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.UseVisualStyleBackColor = True
        Me.btnAceptar.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(135, 12)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSalir.Location = New System.Drawing.Point(140, 46)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(27, 13)
        Me.lblSalir.TabIndex = 0
        Me.lblSalir.Text = "Salir"
        '
        'TarjetaProduccionSuelas_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 605)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grpParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlPie)
        Me.Name = "TarjetaProduccionSuelas_Form"
        Me.Text = "Tarjetas de Producción de Suelas"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpParametros.ResumeLayout(False)
        Me.grpParametros.PerformLayout()
        Me.gboxColeccion.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxMarca.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdCntrlTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MVTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        CType(Me.grdCntrolTarjetaOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MVTarjetaOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents grpParametros As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblEntregaDel As Label
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents lblEntregaAl As Label
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents lblBuscar As Label
    Friend WithEvents btnImprimirTP As Button
    Friend WithEvents lblImprimirOrdenCompra As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdCntrlTarjeta As DevExpress.XtraGrid.GridControl
    Friend WithEvents MVTarjeta As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblSalir As Label
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pnlActiva As Panel
    Friend WithEvents pnlTerminada As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents lblFinalizar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents grdCntrolTarjetaOriginal As DevExpress.XtraGrid.GridControl
    Friend WithEvents MVTarjetaOriginal As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gboxMarca As GroupBox
    Friend WithEvents gboxColeccion As GroupBox
    Friend WithEvents Panel24 As Panel
    Friend WithEvents grdNaves As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnLimpiarNave As Button
    Friend WithEvents btnNaves As Button
    Friend WithEvents cmbEstatus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnVerDetalles As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnConcentradoSuelas As Button
    Friend WithEvents lblAgrupar As Label
    Friend WithEvents btnAgrupar As Button
    Friend WithEvents lblDesagrupar As Label
    Friend WithEvents btnDesagrupar As Button
End Class
