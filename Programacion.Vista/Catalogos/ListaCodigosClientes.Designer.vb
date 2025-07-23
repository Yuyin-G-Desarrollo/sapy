<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaCodigosClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaCodigosClientes))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pblImportarExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlEdicion = New System.Windows.Forms.Panel()
        Me.btnImportarCodigos = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblDetenerEdicion = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblImportarCodigos = New System.Windows.Forms.Label()
        Me.btnDetener = New System.Windows.Forms.Button()
        Me.pnlDerecho = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRegistrosSeleccionados = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblBtnEliminar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblBtnLimpiar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblBtnMostrar = New System.Windows.Forms.Label()
        Me.lblBtnCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.grbActivos = New System.Windows.Forms.GroupBox()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Panel1pnlMostrarOcultar = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.chkSeleccionarTodo_Tallas = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoConCodigoSI = New System.Windows.Forms.RadioButton()
        Me.rdoConCodigosTodos = New System.Windows.Forms.RadioButton()
        Me.rdoConCodigoNo = New System.Windows.Forms.RadioButton()
        Me.chkCodigosAmece = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdoPedidosConfirmadosPorVentas = New System.Windows.Forms.RadioButton()
        Me.rdoDeTodos = New System.Windows.Forms.RadioButton()
        Me.rdoListaPrecios = New System.Windows.Forms.RadioButton()
        Me.lblInicioVigenciaLV = New System.Windows.Forms.Label()
        Me.lblFinVigenciaLV = New System.Windows.Forms.Label()
        Me.dttInicioVigenciaLVC = New System.Windows.Forms.DateTimePicker()
        Me.dttFinVigenciaLVC = New System.Windows.Forms.DateTimePicker()
        Me.cmbListaPrecios = New System.Windows.Forms.ComboBox()
        Me.lblListaPrecios = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.grdCodigosCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.grdExportar = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEncabezado.SuspendLayout()
        Me.pblImportarExportar.SuspendLayout()
        Me.pnlEdicion.SuspendLayout()
        Me.pnlDerecho.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.grbActivos.SuspendLayout()
        Me.Panel1pnlMostrarOcultar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdCodigosCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdExportar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pblImportarExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlEdicion)
        Me.pnlEncabezado.Controls.Add(Me.pnlDerecho)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1082, 60)
        Me.pnlEncabezado.TabIndex = 76
        '
        'pblImportarExportar
        '
        Me.pblImportarExportar.Controls.Add(Me.btnExportar)
        Me.pblImportarExportar.Controls.Add(Me.lblExportar)
        Me.pblImportarExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pblImportarExportar.Location = New System.Drawing.Point(239, 0)
        Me.pblImportarExportar.Name = "pblImportarExportar"
        Me.pblImportarExportar.Size = New System.Drawing.Size(70, 60)
        Me.pblImportarExportar.TabIndex = 62
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(11, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 49
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(5, 40)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 50
        Me.lblExportar.Text = "Exportar"
        '
        'pnlEdicion
        '
        Me.pnlEdicion.Controls.Add(Me.btnImportarCodigos)
        Me.pnlEdicion.Controls.Add(Me.btnEditar)
        Me.pnlEdicion.Controls.Add(Me.lblDetenerEdicion)
        Me.pnlEdicion.Controls.Add(Me.lblEditar)
        Me.pnlEdicion.Controls.Add(Me.lblImportarCodigos)
        Me.pnlEdicion.Controls.Add(Me.btnDetener)
        Me.pnlEdicion.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEdicion.Location = New System.Drawing.Point(0, 0)
        Me.pnlEdicion.Name = "pnlEdicion"
        Me.pnlEdicion.Size = New System.Drawing.Size(239, 60)
        Me.pnlEdicion.TabIndex = 61
        '
        'btnImportarCodigos
        '
        Me.btnImportarCodigos.Image = Global.Programacion.Vista.My.Resources.Resources.importaexcel
        Me.btnImportarCodigos.Location = New System.Drawing.Point(176, 8)
        Me.btnImportarCodigos.Name = "btnImportarCodigos"
        Me.btnImportarCodigos.Size = New System.Drawing.Size(32, 32)
        Me.btnImportarCodigos.TabIndex = 53
        Me.btnImportarCodigos.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(17, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 56
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblDetenerEdicion
        '
        Me.lblDetenerEdicion.AutoSize = True
        Me.lblDetenerEdicion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDetenerEdicion.Location = New System.Drawing.Point(62, 40)
        Me.lblDetenerEdicion.Name = "lblDetenerEdicion"
        Me.lblDetenerEdicion.Size = New System.Drawing.Size(82, 13)
        Me.lblDetenerEdicion.TabIndex = 60
        Me.lblDetenerEdicion.Text = "Detener edición"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(17, 40)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 58
        Me.lblEditar.Text = "Editar"
        '
        'lblImportarCodigos
        '
        Me.lblImportarCodigos.AutoSize = True
        Me.lblImportarCodigos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImportarCodigos.Location = New System.Drawing.Point(151, 40)
        Me.lblImportarCodigos.Name = "lblImportarCodigos"
        Me.lblImportarCodigos.Size = New System.Drawing.Size(86, 13)
        Me.lblImportarCodigos.TabIndex = 54
        Me.lblImportarCodigos.Text = "Importar Códigos"
        '
        'btnDetener
        '
        Me.btnDetener.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.cancelar321
        Me.btnDetener.Location = New System.Drawing.Point(90, 7)
        Me.btnDetener.Name = "btnDetener"
        Me.btnDetener.Size = New System.Drawing.Size(32, 32)
        Me.btnDetener.TabIndex = 59
        Me.btnDetener.UseVisualStyleBackColor = True
        '
        'pnlDerecho
        '
        Me.pnlDerecho.Controls.Add(Me.lblEncabezado)
        Me.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDerecho.Location = New System.Drawing.Point(814, 0)
        Me.pnlDerecho.Name = "pnlDerecho"
        Me.pnlDerecho.Size = New System.Drawing.Size(200, 60)
        Me.pnlDerecho.TabIndex = 55
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(30, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(160, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Códigos de Cliente"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1014, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Label1)
        Me.pnlEstado.Controls.Add(Me.lblRegistrosSeleccionados)
        Me.pnlEstado.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 496)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1082, 60)
        Me.pnlEstado.TabIndex = 77
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Label1.Location = New System.Drawing.Point(753, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "*Información no editable"
        '
        'lblRegistrosSeleccionados
        '
        Me.lblRegistrosSeleccionados.AutoSize = True
        Me.lblRegistrosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRegistrosSeleccionados.Location = New System.Drawing.Point(11, 5)
        Me.lblRegistrosSeleccionados.Name = "lblRegistrosSeleccionados"
        Me.lblRegistrosSeleccionados.Size = New System.Drawing.Size(101, 30)
        Me.lblRegistrosSeleccionados.TabIndex = 47
        Me.lblRegistrosSeleccionados.Text = "Registros" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblRegistrosSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(44, 36)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 48
        Me.lblTotalSeleccionados.Text = "0"
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnEliminar)
        Me.pnlOperaciones.Controls.Add(Me.lblBtnEliminar)
        Me.pnlOperaciones.Controls.Add(Me.btnLimpiar)
        Me.pnlOperaciones.Controls.Add(Me.lblBtnLimpiar)
        Me.pnlOperaciones.Controls.Add(Me.btnMostrar)
        Me.pnlOperaciones.Controls.Add(Me.lblBtnMostrar)
        Me.pnlOperaciones.Controls.Add(Me.lblBtnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(875, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(207, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Programacion.Vista.My.Resources.Resources.borrar_321
        Me.btnEliminar.Location = New System.Drawing.Point(18, 8)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 45
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblBtnEliminar
        '
        Me.lblBtnEliminar.AutoSize = True
        Me.lblBtnEliminar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnEliminar.Location = New System.Drawing.Point(12, 41)
        Me.lblBtnEliminar.Name = "lblBtnEliminar"
        Me.lblBtnEliminar.Size = New System.Drawing.Size(43, 13)
        Me.lblBtnEliminar.TabIndex = 44
        Me.lblBtnEliminar.Text = "Eliminar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(118, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 43
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblBtnLimpiar
        '
        Me.lblBtnLimpiar.AutoSize = True
        Me.lblBtnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnLimpiar.Location = New System.Drawing.Point(117, 41)
        Me.lblBtnLimpiar.Name = "lblBtnLimpiar"
        Me.lblBtnLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblBtnLimpiar.TabIndex = 42
        Me.lblBtnLimpiar.Text = "Limpiar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.Location = New System.Drawing.Point(66, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 41
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblBtnMostrar
        '
        Me.lblBtnMostrar.AutoSize = True
        Me.lblBtnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnMostrar.Location = New System.Drawing.Point(64, 41)
        Me.lblBtnMostrar.Name = "lblBtnMostrar"
        Me.lblBtnMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblBtnMostrar.TabIndex = 40
        Me.lblBtnMostrar.Text = "Mostrar"
        '
        'lblBtnCerrar
        '
        Me.lblBtnCerrar.AutoSize = True
        Me.lblBtnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnCerrar.Location = New System.Drawing.Point(167, 41)
        Me.lblBtnCerrar.Name = "lblBtnCerrar"
        Me.lblBtnCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblBtnCerrar.TabIndex = 3
        Me.lblBtnCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(168, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.grbActivos)
        Me.pnlFiltros.Controls.Add(Me.txtCliente)
        Me.pnlFiltros.Controls.Add(Me.Panel1pnlMostrarOcultar)
        Me.pnlFiltros.Controls.Add(Me.chkSeleccionarTodo_Tallas)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Controls.Add(Me.chkCodigosAmece)
        Me.pnlFiltros.Controls.Add(Me.GroupBox2)
        Me.pnlFiltros.Controls.Add(Me.lblInicioVigenciaLV)
        Me.pnlFiltros.Controls.Add(Me.lblFinVigenciaLV)
        Me.pnlFiltros.Controls.Add(Me.dttInicioVigenciaLVC)
        Me.pnlFiltros.Controls.Add(Me.dttFinVigenciaLVC)
        Me.pnlFiltros.Controls.Add(Me.cmbListaPrecios)
        Me.pnlFiltros.Controls.Add(Me.lblListaPrecios)
        Me.pnlFiltros.Controls.Add(Me.lblCliente)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 60)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1082, 115)
        Me.pnlFiltros.TabIndex = 78
        '
        'grbActivos
        '
        Me.grbActivos.Controls.Add(Me.rdoActivoSi)
        Me.grbActivos.Controls.Add(Me.rdoActivoNo)
        Me.grbActivos.Location = New System.Drawing.Point(299, 28)
        Me.grbActivos.Name = "grbActivos"
        Me.grbActivos.Size = New System.Drawing.Size(58, 63)
        Me.grbActivos.TabIndex = 107
        Me.grbActivos.TabStop = False
        Me.grbActivos.Text = "Activos"
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(14, 17)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 89
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(14, 36)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 88
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = False
        '
        'txtCliente
        '
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(452, 43)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(349, 20)
        Me.txtCliente.TabIndex = 106
        '
        'Panel1pnlMostrarOcultar
        '
        Me.Panel1pnlMostrarOcultar.Controls.Add(Me.btnArriba)
        Me.Panel1pnlMostrarOcultar.Controls.Add(Me.btnAbajo)
        Me.Panel1pnlMostrarOcultar.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1pnlMostrarOcultar.Location = New System.Drawing.Point(1017, 0)
        Me.Panel1pnlMostrarOcultar.Name = "Panel1pnlMostrarOcultar"
        Me.Panel1pnlMostrarOcultar.Size = New System.Drawing.Size(65, 115)
        Me.Panel1pnlMostrarOcultar.TabIndex = 105
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(10, 5)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 86
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(34, 5)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 87
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'chkSeleccionarTodo_Tallas
        '
        Me.chkSeleccionarTodo_Tallas.AutoSize = True
        Me.chkSeleccionarTodo_Tallas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarTodo_Tallas.Location = New System.Drawing.Point(19, 95)
        Me.chkSeleccionarTodo_Tallas.Name = "chkSeleccionarTodo_Tallas"
        Me.chkSeleccionarTodo_Tallas.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodo_Tallas.TabIndex = 79
        Me.chkSeleccionarTodo_Tallas.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo_Tallas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoConCodigoSI)
        Me.GroupBox1.Controls.Add(Me.rdoConCodigosTodos)
        Me.GroupBox1.Controls.Add(Me.rdoConCodigoNo)
        Me.GroupBox1.Location = New System.Drawing.Point(212, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(81, 63)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Con Código"
        '
        'rdoConCodigoSI
        '
        Me.rdoConCodigoSI.AutoSize = True
        Me.rdoConCodigoSI.Checked = True
        Me.rdoConCodigoSI.Location = New System.Drawing.Point(14, 14)
        Me.rdoConCodigoSI.Name = "rdoConCodigoSI"
        Me.rdoConCodigoSI.Size = New System.Drawing.Size(34, 17)
        Me.rdoConCodigoSI.TabIndex = 89
        Me.rdoConCodigoSI.TabStop = True
        Me.rdoConCodigoSI.Text = "Si"
        Me.rdoConCodigoSI.UseVisualStyleBackColor = True
        '
        'rdoConCodigosTodos
        '
        Me.rdoConCodigosTodos.AutoSize = True
        Me.rdoConCodigosTodos.Location = New System.Drawing.Point(14, 44)
        Me.rdoConCodigosTodos.Name = "rdoConCodigosTodos"
        Me.rdoConCodigosTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoConCodigosTodos.TabIndex = 95
        Me.rdoConCodigosTodos.Text = "Todos"
        Me.rdoConCodigosTodos.UseVisualStyleBackColor = True
        '
        'rdoConCodigoNo
        '
        Me.rdoConCodigoNo.AutoSize = True
        Me.rdoConCodigoNo.Location = New System.Drawing.Point(14, 29)
        Me.rdoConCodigoNo.Name = "rdoConCodigoNo"
        Me.rdoConCodigoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoConCodigoNo.TabIndex = 88
        Me.rdoConCodigoNo.Text = "No"
        Me.rdoConCodigoNo.UseVisualStyleBackColor = False
        '
        'chkCodigosAmece
        '
        Me.chkCodigosAmece.AutoSize = True
        Me.chkCodigosAmece.Enabled = False
        Me.chkCodigosAmece.Location = New System.Drawing.Point(814, 43)
        Me.chkCodigosAmece.Name = "chkCodigosAmece"
        Me.chkCodigosAmece.Size = New System.Drawing.Size(104, 17)
        Me.chkCodigosAmece.TabIndex = 103
        Me.chkCodigosAmece.Text = "Códigos AMECE"
        Me.chkCodigosAmece.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoPedidosConfirmadosPorVentas)
        Me.GroupBox2.Controls.Add(Me.rdoDeTodos)
        Me.GroupBox2.Controls.Add(Me.rdoListaPrecios)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(196, 63)
        Me.GroupBox2.TabIndex = 101
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ver productos de"
        '
        'rdoPedidosConfirmadosPorVentas
        '
        Me.rdoPedidosConfirmadosPorVentas.AutoSize = True
        Me.rdoPedidosConfirmadosPorVentas.Checked = True
        Me.rdoPedidosConfirmadosPorVentas.Location = New System.Drawing.Point(14, 14)
        Me.rdoPedidosConfirmadosPorVentas.Name = "rdoPedidosConfirmadosPorVentas"
        Me.rdoPedidosConfirmadosPorVentas.Size = New System.Drawing.Size(178, 17)
        Me.rdoPedidosConfirmadosPorVentas.TabIndex = 89
        Me.rdoPedidosConfirmadosPorVentas.TabStop = True
        Me.rdoPedidosConfirmadosPorVentas.Text = "Pedidos Confirmados por Ventas"
        Me.rdoPedidosConfirmadosPorVentas.UseVisualStyleBackColor = True
        '
        'rdoDeTodos
        '
        Me.rdoDeTodos.AutoSize = True
        Me.rdoDeTodos.Location = New System.Drawing.Point(14, 44)
        Me.rdoDeTodos.Name = "rdoDeTodos"
        Me.rdoDeTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoDeTodos.TabIndex = 95
        Me.rdoDeTodos.Text = "Todos"
        Me.rdoDeTodos.UseVisualStyleBackColor = True
        '
        'rdoListaPrecios
        '
        Me.rdoListaPrecios.AutoSize = True
        Me.rdoListaPrecios.Location = New System.Drawing.Point(14, 29)
        Me.rdoListaPrecios.Name = "rdoListaPrecios"
        Me.rdoListaPrecios.Size = New System.Drawing.Size(100, 17)
        Me.rdoListaPrecios.TabIndex = 88
        Me.rdoListaPrecios.Text = "Lista de Precios"
        Me.rdoListaPrecios.UseVisualStyleBackColor = False
        '
        'lblInicioVigenciaLV
        '
        Me.lblInicioVigenciaLV.AutoSize = True
        Me.lblInicioVigenciaLV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicioVigenciaLV.Location = New System.Drawing.Point(807, 74)
        Me.lblInicioVigenciaLV.Name = "lblInicioVigenciaLV"
        Me.lblInicioVigenciaLV.Size = New System.Drawing.Size(23, 13)
        Me.lblInicioVigenciaLV.TabIndex = 97
        Me.lblInicioVigenciaLV.Text = "Del"
        '
        'lblFinVigenciaLV
        '
        Me.lblFinVigenciaLV.AutoSize = True
        Me.lblFinVigenciaLV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinVigenciaLV.Location = New System.Drawing.Point(915, 75)
        Me.lblFinVigenciaLV.Name = "lblFinVigenciaLV"
        Me.lblFinVigenciaLV.Size = New System.Drawing.Size(16, 13)
        Me.lblFinVigenciaLV.TabIndex = 98
        Me.lblFinVigenciaLV.Text = "Al"
        '
        'dttInicioVigenciaLVC
        '
        Me.dttInicioVigenciaLVC.Enabled = False
        Me.dttInicioVigenciaLVC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttInicioVigenciaLVC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttInicioVigenciaLVC.Location = New System.Drawing.Point(833, 72)
        Me.dttInicioVigenciaLVC.Name = "dttInicioVigenciaLVC"
        Me.dttInicioVigenciaLVC.Size = New System.Drawing.Size(78, 20)
        Me.dttInicioVigenciaLVC.TabIndex = 99
        '
        'dttFinVigenciaLVC
        '
        Me.dttFinVigenciaLVC.Enabled = False
        Me.dttFinVigenciaLVC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttFinVigenciaLVC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttFinVigenciaLVC.Location = New System.Drawing.Point(934, 72)
        Me.dttFinVigenciaLVC.Name = "dttFinVigenciaLVC"
        Me.dttFinVigenciaLVC.Size = New System.Drawing.Size(79, 20)
        Me.dttFinVigenciaLVC.TabIndex = 100
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.Location = New System.Drawing.Point(452, 70)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(349, 21)
        Me.cmbListaPrecios.TabIndex = 94
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.Location = New System.Drawing.Point(366, 74)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 93
        Me.lblListaPrecios.Text = "Lista de Precios"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(366, 47)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 92
        Me.lblCliente.Text = "Cliente"
        '
        'grdCodigosCliente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCodigosCliente.DisplayLayout.Appearance = Appearance1
        Me.grdCodigosCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCodigosCliente.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCodigosCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCodigosCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCodigosCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCodigosCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCodigosCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCodigosCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCodigosCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdCodigosCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCodigosCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCodigosCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCodigosCliente.Location = New System.Drawing.Point(0, 175)
        Me.grdCodigosCliente.Name = "grdCodigosCliente"
        Me.grdCodigosCliente.Size = New System.Drawing.Size(1082, 257)
        Me.grdCodigosCliente.TabIndex = 85
        '
        'grdExportar
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdExportar.DisplayLayout.Appearance = Appearance2
        Me.grdExportar.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdExportar.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdExportar.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdExportar.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdExportar.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdExportar.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdExportar.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdExportar.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdExportar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdExportar.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdExportar.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdExportar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdExportar.Location = New System.Drawing.Point(0, 432)
        Me.grdExportar.Name = "grdExportar"
        Me.grdExportar.Size = New System.Drawing.Size(1082, 64)
        Me.grdExportar.TabIndex = 86
        Me.grdExportar.Visible = False
        '
        'ListaCodigosClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1082, 556)
        Me.Controls.Add(Me.grdCodigosCliente)
        Me.Controls.Add(Me.grdExportar)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MinimizeBox = False
        Me.Name = "ListaCodigosClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Códigos de Cliente"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pblImportarExportar.ResumeLayout(False)
        Me.pblImportarExportar.PerformLayout()
        Me.pnlEdicion.ResumeLayout(False)
        Me.pnlEdicion.PerformLayout()
        Me.pnlDerecho.ResumeLayout(False)
        Me.pnlDerecho.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.grbActivos.ResumeLayout(False)
        Me.grbActivos.PerformLayout()
        Me.Panel1pnlMostrarOcultar.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdCodigosCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdExportar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents lblRegistrosSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblBtnCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents cmbListaPrecios As System.Windows.Forms.ComboBox
    Friend WithEvents lblListaPrecios As System.Windows.Forms.Label
    Friend WithEvents lblInicioVigenciaLV As System.Windows.Forms.Label
    Friend WithEvents lblFinVigenciaLV As System.Windows.Forms.Label
    Friend WithEvents dttInicioVigenciaLVC As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttFinVigenciaLVC As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoPedidosConfirmadosPorVentas As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDeTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoListaPrecios As System.Windows.Forms.RadioButton
    Friend WithEvents chkSeleccionarTodo_Tallas As System.Windows.Forms.CheckBox
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblBtnMostrar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblBtnLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnImportarCodigos As System.Windows.Forms.Button
    Friend WithEvents lblImportarCodigos As System.Windows.Forms.Label
    Friend WithEvents chkCodigosAmece As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoConCodigoSI As System.Windows.Forms.RadioButton
    Friend WithEvents rdoConCodigosTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoConCodigoNo As System.Windows.Forms.RadioButton
    Friend WithEvents lblBtnEliminar As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents pnlDerecho As System.Windows.Forms.Panel
    Friend WithEvents grdCodigosCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1pnlMostrarOcultar As System.Windows.Forms.Panel
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblDetenerEdicion As System.Windows.Forms.Label
    Friend WithEvents btnDetener As System.Windows.Forms.Button
    Friend WithEvents pblImportarExportar As System.Windows.Forms.Panel
    Friend WithEvents pnlEdicion As System.Windows.Forms.Panel
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents grdExportar As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbActivos As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
