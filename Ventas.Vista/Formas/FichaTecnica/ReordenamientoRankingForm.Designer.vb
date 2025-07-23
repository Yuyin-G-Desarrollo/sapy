<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReordenamientoRankingForm
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReordenamientoRankingForm))
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardarRanking = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gpbFiltroIncentivos = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grpCliente = New System.Windows.Forms.GroupBox()
        Me.btnFiltroCliente = New System.Windows.Forms.Button()
        Me.grdFiltroCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdFiltroClasificacionCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cboxClienteClasificacion = New System.Windows.Forms.ComboBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridRanking = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.gpbFiltroIncentivos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpCliente.SuspendLayout()
        CType(Me.grdFiltroCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdFiltroClasificacionCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridRanking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.PictureBox1)
        Me.pnlCabecera.Controls.Add(Me.btnExportarExcel)
        Me.pnlCabecera.Controls.Add(Me.lblActualizarDatos)
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1238, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(18, 8)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 55
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblActualizarDatos
        '
        Me.lblActualizarDatos.AutoSize = True
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Location = New System.Drawing.Point(11, 40)
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        Me.lblActualizarDatos.Size = New System.Drawing.Size(46, 13)
        Me.lblActualizarDatos.TabIndex = 54
        Me.lblActualizarDatos.Text = "Exportar"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(836, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(309, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Reasignación de Ranking de Clientes"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Panel4)
        Me.pnlEstado.Controls.Add(Me.Panel3)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 551)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1238, 60)
        Me.pnlEstado.TabIndex = 71
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblUltimaActualizacion)
        Me.Panel4.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(941, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(145, 60)
        Me.Panel4.TabIndex = 188
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(13, 33)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(0, 13)
        Me.lblUltimaActualizacion.TabIndex = 162
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(24, 13)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 161
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblRegistros)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(107, 60)
        Me.Panel3.TabIndex = 187
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 23)
        Me.Label2.TabIndex = 183
        Me.Label2.Text = "Registros"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(11, 33)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 184
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.Label1)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardarRanking)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1086, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(152, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(35, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Guardar"
        '
        'btnGuardarRanking
        '
        Me.btnGuardarRanking.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_3211
        Me.btnGuardarRanking.Location = New System.Drawing.Point(39, 8)
        Me.btnGuardarRanking.Name = "btnGuardarRanking"
        Me.btnGuardarRanking.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarRanking.TabIndex = 4
        Me.btnGuardarRanking.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(93, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(93, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gpbFiltroIncentivos
        '
        Me.gpbFiltroIncentivos.Controls.Add(Me.GroupBox1)
        Me.gpbFiltroIncentivos.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltroIncentivos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltroIncentivos.Location = New System.Drawing.Point(0, 59)
        Me.gpbFiltroIncentivos.Name = "gpbFiltroIncentivos"
        Me.gpbFiltroIncentivos.Size = New System.Drawing.Size(1238, 145)
        Me.gpbFiltroIncentivos.TabIndex = 72
        Me.gpbFiltroIncentivos.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grpCliente)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(455, 139)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros de búsqueda"
        '
        'grpCliente
        '
        Me.grpCliente.Controls.Add(Me.btnFiltroCliente)
        Me.grpCliente.Controls.Add(Me.grdFiltroCliente)
        Me.grpCliente.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpCliente.Location = New System.Drawing.Point(232, 16)
        Me.grpCliente.Name = "grpCliente"
        Me.grpCliente.Size = New System.Drawing.Size(198, 120)
        Me.grpCliente.TabIndex = 39
        Me.grpCliente.TabStop = False
        Me.grpCliente.Text = "Cliente"
        '
        'btnFiltroCliente
        '
        Me.btnFiltroCliente.Image = Global.Ventas.Vista.My.Resources.Resources.agregar_32
        Me.btnFiltroCliente.Location = New System.Drawing.Point(170, 14)
        Me.btnFiltroCliente.Name = "btnFiltroCliente"
        Me.btnFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnFiltroCliente.TabIndex = 1
        Me.btnFiltroCliente.UseVisualStyleBackColor = True
        '
        'grdFiltroCliente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroCliente.DisplayLayout.Appearance = Appearance1
        Me.grdFiltroCliente.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdFiltroCliente.Location = New System.Drawing.Point(3, 41)
        Me.grdFiltroCliente.Name = "grdFiltroCliente"
        Me.grdFiltroCliente.Size = New System.Drawing.Size(192, 76)
        Me.grdFiltroCliente.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.lblNave)
        Me.GroupBox2.Controls.Add(Me.cboxClienteClasificacion)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(229, 120)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdFiltroClasificacionCliente)
        Me.Panel2.Location = New System.Drawing.Point(9, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(210, 73)
        Me.Panel2.TabIndex = 37
        '
        'grdFiltroClasificacionCliente
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroClasificacionCliente.DisplayLayout.Appearance = Appearance2
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance3
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroClasificacionCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroClasificacionCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFiltroClasificacionCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdFiltroClasificacionCliente.Name = "grdFiltroClasificacionCliente"
        Me.grdFiltroClasificacionCliente.Size = New System.Drawing.Size(210, 73)
        Me.grdFiltroClasificacionCliente.TabIndex = 2
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(6, 17)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(124, 13)
        Me.lblNave.TabIndex = 25
        Me.lblNave.Text = "Clasificación de Clientes:"
        '
        'cboxClienteClasificacion
        '
        Me.cboxClienteClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxClienteClasificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboxClienteClasificacion.ForeColor = System.Drawing.Color.Black
        Me.cboxClienteClasificacion.FormattingEnabled = True
        Me.cboxClienteClasificacion.Items.AddRange(New Object() {"", "Pendientes", "Pagado"})
        Me.cboxClienteClasificacion.Location = New System.Drawing.Point(136, 14)
        Me.cboxClienteClasificacion.Name = "cboxClienteClasificacion"
        Me.cboxClienteClasificacion.Size = New System.Drawing.Size(83, 21)
        Me.cboxClienteClasificacion.TabIndex = 26
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnMostrar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1125, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(110, 126)
        Me.pnlMinimizarParametros.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(64, 72)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(16, 72)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(67, 40)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 44
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.Location = New System.Drawing.Point(19, 40)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 43
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(56, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(79, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gridRanking)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 204)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1238, 347)
        Me.Panel1.TabIndex = 73
        '
        'gridRanking
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridRanking.DisplayLayout.Appearance = Appearance4
        Me.gridRanking.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridRanking.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridRanking.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridRanking.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridRanking.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridRanking.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridRanking.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridRanking.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridRanking.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRanking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRanking.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.gridRanking.Location = New System.Drawing.Point(0, 0)
        Me.gridRanking.Name = "gridRanking"
        Me.gridRanking.Size = New System.Drawing.Size(1238, 347)
        Me.gridRanking.TabIndex = 65
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1170, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 56
        Me.PictureBox1.TabStop = False
        '
        'ReordenamientoRankingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1238, 611)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gpbFiltroIncentivos)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReordenamientoRankingForm"
        Me.Text = "Reasignación de Ranking de Clientes"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.gpbFiltroIncentivos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grpCliente.ResumeLayout(False)
        CType(Me.grdFiltroCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdFiltroClasificacionCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.gridRanking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuardarRanking As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gpbFiltroIncentivos As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridRanking As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents lblActualizarDatos As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblNave As Label
    Friend WithEvents cboxClienteClasificacion As ComboBox
    Friend WithEvents grdFiltroClasificacionCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grpCliente As GroupBox
    Friend WithEvents btnFiltroCliente As Button
    Friend WithEvents grdFiltroCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblRegistros As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
