<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DevolucionCliente_EntradaSalida_Naves
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_EntradaSalida_Naves))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlBtnImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlBtnDetener = New System.Windows.Forms.Panel()
        Me.btnDetener = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlBtnIniciar = New System.Windows.Forms.Panel()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpFechaRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaRecepcion = New System.Windows.Forms.Label()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.lblCodigoRepetido = New System.Windows.Forms.Label()
        Me.dtpFechaEstimadaRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpFechaEnvio = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlFolioSalida = New System.Windows.Forms.Panel()
        Me.txtFolioSalida = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbProceso = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdLecturaActual = New DevExpress.XtraGrid.GridControl()
        Me.bgvLecturaActual = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTituloCorrectos = New System.Windows.Forms.Label()
        Me.grdLecturaAnterior = New DevExpress.XtraGrid.GridControl()
        Me.bgvLecturaAnterior = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnAplicarIncidenciaaTodos = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlBtnImprimir.SuspendLayout()
        Me.pnlBtnDetener.SuspendLayout()
        Me.pnlBtnIniciar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlFolioSalida.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdLecturaActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvLecturaActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.grdLecturaAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvLecturaAnterior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(1057, 65)
        Me.pnlEncabezado.TabIndex = 28
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlBtnImprimir)
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlBtnDetener)
        Me.pnlAccionesCabecera.Controls.Add(Me.pnlBtnIniciar)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(370, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlBtnImprimir
        '
        Me.pnlBtnImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlBtnImprimir.Controls.Add(Me.Label9)
        Me.pnlBtnImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnImprimir.Location = New System.Drawing.Point(116, 0)
        Me.pnlBtnImprimir.Name = "pnlBtnImprimir"
        Me.pnlBtnImprimir.Size = New System.Drawing.Size(58, 65)
        Me.pnlBtnImprimir.TabIndex = 205
        '
        'btnImprimir
        '
        Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.Image = Global.Almacen.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimir.Location = New System.Drawing.Point(14, 6)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 98
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(8, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "Imprimir"
        '
        'pnlBtnDetener
        '
        Me.pnlBtnDetener.Controls.Add(Me.btnDetener)
        Me.pnlBtnDetener.Controls.Add(Me.Label5)
        Me.pnlBtnDetener.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnDetener.Location = New System.Drawing.Point(58, 0)
        Me.pnlBtnDetener.Name = "pnlBtnDetener"
        Me.pnlBtnDetener.Size = New System.Drawing.Size(58, 65)
        Me.pnlBtnDetener.TabIndex = 204
        '
        'btnDetener
        '
        Me.btnDetener.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDetener.Enabled = False
        Me.btnDetener.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnDetener.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar321
        Me.btnDetener.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDetener.Location = New System.Drawing.Point(14, 6)
        Me.btnDetener.Name = "btnDetener"
        Me.btnDetener.Size = New System.Drawing.Size(32, 32)
        Me.btnDetener.TabIndex = 98
        Me.btnDetener.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(8, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Detener"
        '
        'pnlBtnIniciar
        '
        Me.pnlBtnIniciar.Controls.Add(Me.btnIniciar)
        Me.pnlBtnIniciar.Controls.Add(Me.Label3)
        Me.pnlBtnIniciar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnIniciar.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtnIniciar.Name = "pnlBtnIniciar"
        Me.pnlBtnIniciar.Size = New System.Drawing.Size(58, 65)
        Me.pnlBtnIniciar.TabIndex = 203
        '
        'btnIniciar
        '
        Me.btnIniciar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnIniciar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnIniciar.Image = Global.Almacen.Vista.My.Resources.Resources.btnIniciar_Image
        Me.btnIniciar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnIniciar.Location = New System.Drawing.Point(12, 6)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(32, 32)
        Me.btnIniciar.TabIndex = 98
        Me.btnIniciar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(9, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Iniciar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(541, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(516, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = CType(resources.GetObject("pctTitulo.Image"), System.Drawing.Image)
        Me.pctTitulo.Location = New System.Drawing.Point(448, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 65)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 90
        Me.pctTitulo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(117, 15)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(327, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Envio y Recepción de Producto a Naves"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label8)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 470)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1057, 65)
        Me.pnlPie.TabIndex = 66
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(137, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(438, 15)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Los pares erróneos no se toman en cuanta para el procedo de entrada o salida"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.Label10)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(957, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(100, 65)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(13, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(7, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(59, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(58, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(11, 34)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 116
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 24)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Registros"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.dtpFechaRecepcion)
        Me.Panel1.Controls.Add(Me.lblFechaRecepcion)
        Me.Panel1.Controls.Add(Me.txtOperador)
        Me.Panel1.Controls.Add(Me.lblOperador)
        Me.Panel1.Controls.Add(Me.lblCodigoRepetido)
        Me.Panel1.Controls.Add(Me.dtpFechaEstimadaRecepcion)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.dtpFechaEnvio)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.pnlFolioSalida)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmbNave)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbProceso)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1057, 112)
        Me.Panel1.TabIndex = 67
        '
        'dtpFechaRecepcion
        '
        Me.dtpFechaRecepcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaRecepcion.Location = New System.Drawing.Point(714, 47)
        Me.dtpFechaRecepcion.Name = "dtpFechaRecepcion"
        Me.dtpFechaRecepcion.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaRecepcion.TabIndex = 17
        Me.dtpFechaRecepcion.Visible = False
        '
        'lblFechaRecepcion
        '
        Me.lblFechaRecepcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFechaRecepcion.AutoSize = True
        Me.lblFechaRecepcion.Location = New System.Drawing.Point(758, 21)
        Me.lblFechaRecepcion.Name = "lblFechaRecepcion"
        Me.lblFechaRecepcion.Size = New System.Drawing.Size(109, 13)
        Me.lblFechaRecepcion.TabIndex = 16
        Me.lblFechaRecepcion.Text = "Fecha De Recepción"
        Me.lblFechaRecepcion.Visible = False
        '
        'txtOperador
        '
        Me.txtOperador.Location = New System.Drawing.Point(594, 80)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.Size = New System.Drawing.Size(238, 20)
        Me.txtOperador.TabIndex = 15
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Location = New System.Drawing.Point(530, 83)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(58, 13)
        Me.lblOperador.TabIndex = 14
        Me.lblOperador.Text = "* Operador"
        '
        'lblCodigoRepetido
        '
        Me.lblCodigoRepetido.AutoSize = True
        Me.lblCodigoRepetido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoRepetido.ForeColor = System.Drawing.Color.Red
        Me.lblCodigoRepetido.Location = New System.Drawing.Point(360, 83)
        Me.lblCodigoRepetido.Name = "lblCodigoRepetido"
        Me.lblCodigoRepetido.Size = New System.Drawing.Size(114, 15)
        Me.lblCodigoRepetido.TabIndex = 13
        Me.lblCodigoRepetido.Text = "Código Repetido"
        Me.lblCodigoRepetido.Visible = False
        '
        'dtpFechaEstimadaRecepcion
        '
        Me.dtpFechaEstimadaRecepcion.Location = New System.Drawing.Point(484, 47)
        Me.dtpFechaEstimadaRecepcion.Name = "dtpFechaEstimadaRecepcion"
        Me.dtpFechaEstimadaRecepcion.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaEstimadaRecepcion.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(323, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(155, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Fecha Estimada De Recepción"
        '
        'dtpFechaEnvio
        '
        Me.dtpFechaEnvio.Location = New System.Drawing.Point(102, 47)
        Me.dtpFechaEnvio.Name = "dtpFechaEnvio"
        Me.dtpFechaEnvio.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaEnvio.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Fecha De Envío"
        '
        'pnlFolioSalida
        '
        Me.pnlFolioSalida.Controls.Add(Me.txtFolioSalida)
        Me.pnlFolioSalida.Controls.Add(Me.Label7)
        Me.pnlFolioSalida.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlFolioSalida.Location = New System.Drawing.Point(920, 0)
        Me.pnlFolioSalida.Name = "pnlFolioSalida"
        Me.pnlFolioSalida.Size = New System.Drawing.Size(137, 112)
        Me.pnlFolioSalida.TabIndex = 8
        '
        'txtFolioSalida
        '
        Me.txtFolioSalida.Enabled = False
        Me.txtFolioSalida.Location = New System.Drawing.Point(2, 47)
        Me.txtFolioSalida.Name = "txtFolioSalida"
        Me.txtFolioSalida.Size = New System.Drawing.Size(134, 20)
        Me.txtFolioSalida.TabIndex = 7
        Me.txtFolioSalida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(4, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Folio de Salida"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(116, 80)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(238, 20)
        Me.txtCodigo.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Captura de Códigos"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(285, 13)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(188, 21)
        Me.cmbNave.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(233, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Nave"
        '
        'cmbProceso
        '
        Me.cmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProceso.FormattingEnabled = True
        Me.cmbProceso.Items.AddRange(New Object() {"ENTRADA", "SALIDA"})
        Me.cmbProceso.Location = New System.Drawing.Point(64, 13)
        Me.cmbProceso.Name = "cmbProceso"
        Me.cmbProceso.Size = New System.Drawing.Size(121, 21)
        Me.cmbProceso.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proceso"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 177)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1057, 293)
        Me.Panel2.TabIndex = 68
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.AliceBlue
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdLecturaActual)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdLecturaAnterior)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Size = New System.Drawing.Size(1057, 293)
        Me.SplitContainer1.SplitterDistance = 525
        Me.SplitContainer1.TabIndex = 0
        '
        'grdLecturaActual
        '
        Me.grdLecturaActual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLecturaActual.Location = New System.Drawing.Point(0, 30)
        Me.grdLecturaActual.MainView = Me.bgvLecturaActual
        Me.grdLecturaActual.Name = "grdLecturaActual"
        Me.grdLecturaActual.Size = New System.Drawing.Size(523, 261)
        Me.grdLecturaActual.TabIndex = 0
        Me.grdLecturaActual.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvLecturaActual})
        '
        'bgvLecturaActual
        '
        Me.bgvLecturaActual.GridControl = Me.grdLecturaActual
        Me.bgvLecturaActual.Name = "bgvLecturaActual"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblTituloCorrectos)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(523, 30)
        Me.Panel4.TabIndex = 0
        '
        'lblTituloCorrectos
        '
        Me.lblTituloCorrectos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTituloCorrectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloCorrectos.ForeColor = System.Drawing.Color.Green
        Me.lblTituloCorrectos.Location = New System.Drawing.Point(0, 0)
        Me.lblTituloCorrectos.Name = "lblTituloCorrectos"
        Me.lblTituloCorrectos.Size = New System.Drawing.Size(523, 30)
        Me.lblTituloCorrectos.TabIndex = 214
        Me.lblTituloCorrectos.Text = "CORRECTOS"
        Me.lblTituloCorrectos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdLecturaAnterior
        '
        Me.grdLecturaAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLecturaAnterior.Location = New System.Drawing.Point(0, 30)
        Me.grdLecturaAnterior.MainView = Me.bgvLecturaAnterior
        Me.grdLecturaAnterior.Name = "grdLecturaAnterior"
        Me.grdLecturaAnterior.Size = New System.Drawing.Size(526, 261)
        Me.grdLecturaAnterior.TabIndex = 1
        Me.grdLecturaAnterior.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvLecturaAnterior})
        '
        'bgvLecturaAnterior
        '
        Me.bgvLecturaAnterior.GridControl = Me.grdLecturaAnterior
        Me.bgvLecturaAnterior.Name = "bgvLecturaAnterior"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnAplicarIncidenciaaTodos)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(526, 30)
        Me.Panel5.TabIndex = 1
        '
        'btnAplicarIncidenciaaTodos
        '
        Me.btnAplicarIncidenciaaTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicarIncidenciaaTodos.Image = Global.Almacen.Vista.My.Resources.Resources._1373583708_101
        Me.btnAplicarIncidenciaaTodos.Location = New System.Drawing.Point(3, 5)
        Me.btnAplicarIncidenciaaTodos.Name = "btnAplicarIncidenciaaTodos"
        Me.btnAplicarIncidenciaaTodos.Size = New System.Drawing.Size(23, 21)
        Me.btnAplicarIncidenciaaTodos.TabIndex = 263
        Me.btnAplicarIncidenciaaTodos.UseVisualStyleBackColor = True
        Me.btnAplicarIncidenciaaTodos.Visible = False
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Sienna
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(526, 30)
        Me.Label13.TabIndex = 215
        Me.Label13.Text = "ENVIADOS"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DevolucionCliente_EntradaSalida_Naves
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 535)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "DevolucionCliente_EntradaSalida_Naves"
        Me.Text = "Devoluciones Cliente - Envío/Recepción Naves"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlBtnImprimir.ResumeLayout(False)
        Me.pnlBtnImprimir.PerformLayout()
        Me.pnlBtnDetener.ResumeLayout(False)
        Me.pnlBtnDetener.PerformLayout()
        Me.pnlBtnIniciar.ResumeLayout(False)
        Me.pnlBtnIniciar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlFolioSalida.ResumeLayout(False)
        Me.pnlFolioSalida.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdLecturaActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvLecturaActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdLecturaAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvLecturaAnterior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents pnlBtnIniciar As Panel
    Friend WithEvents btnIniciar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pctTitulo As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlBtnDetener As Panel
    Friend WithEvents btnDetener As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents lblNumFiltrados As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbProceso As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grdLecturaActual As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvLecturaActual As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdLecturaAnterior As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvLecturaAnterior As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtCodigo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents pnlFolioSalida As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents dtpFechaEstimadaRecepcion As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents dtpFechaEnvio As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents lblTituloCorrectos As Label
    Friend WithEvents lblCodigoRepetido As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtOperador As TextBox
    Friend WithEvents lblOperador As Label
    Friend WithEvents txtFolioSalida As TextBox
    Friend WithEvents dtpFechaRecepcion As DateTimePicker
    Friend WithEvents lblFechaRecepcion As Label
    Friend WithEvents btnAplicarIncidenciaaTodos As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents pnlBtnImprimir As Panel
End Class
