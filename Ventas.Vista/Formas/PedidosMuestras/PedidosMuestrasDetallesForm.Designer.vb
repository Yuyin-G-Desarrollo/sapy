<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PedidosMuestrasDetallesForm
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
        Me.components = New System.ComponentModel.Container()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnExportarExcelDet = New System.Windows.Forms.Button()
        Me.lblCopiarPedido = New System.Windows.Forms.Label()
        Me.btnCopiarPedido = New System.Windows.Forms.Button()
        Me.lblEnviarPorApartar = New System.Windows.Forms.Label()
        Me.btnEnviarPorApartar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblConfirmarApartado = New System.Windows.Forms.Label()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.lblRechazar = New System.Windows.Forms.Label()
        Me.txtIdAgente = New System.Windows.Forms.TextBox()
        Me.btnConfirmarApartadoDetalles = New System.Windows.Forms.Button()
        Me.btnRechazarDetalles = New System.Windows.Forms.Button()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.txtFechaDeEntrega = New System.Windows.Forms.TextBox()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grpbCambioTalla = New System.Windows.Forms.GroupBox()
        Me.btnCambioDeTalla = New System.Windows.Forms.Button()
        Me.txtNuevaTalla = New System.Windows.Forms.TextBox()
        Me.lblCambioTalla = New System.Windows.Forms.Label()
        Me.cmbTemporada = New System.Windows.Forms.ComboBox()
        Me.cmbAgente = New System.Windows.Forms.ComboBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.cmbAsunto = New System.Windows.Forms.ComboBox()
        Me.lblErrorMessage = New System.Windows.Forms.Label()
        Me.lblModelo = New System.Windows.Forms.Label()
        Me.btnBuscarModelo = New System.Windows.Forms.Button()
        Me.txtBuscarModelo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCapturadoPor = New System.Windows.Forms.TextBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.txtEstatus = New System.Windows.Forms.TextBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTemporada = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaCaptura = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAgente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdPedidosMuestraDetalles = New DevExpress.XtraGrid.GridControl()
        Me.grdVpedidosMuestrasDetalles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.grpbCambioTalla.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdPedidosMuestraDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVpedidosMuestrasDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(1259, 69)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Label9)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportarExcelDet)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblCopiarPedido)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnCopiarPedido)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblEnviarPorApartar)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnEnviarPorApartar)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblEditar)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnEditar)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblConfirmarApartado)
        Me.pnlAccionesCabecera.Controls.Add(Me.txtIdCliente)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblRechazar)
        Me.pnlAccionesCabecera.Controls.Add(Me.txtIdAgente)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnConfirmarApartadoDetalles)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnRechazarDetalles)
        Me.pnlAccionesCabecera.Controls.Add(Me.txtAsunto)
        Me.pnlAccionesCabecera.Controls.Add(Me.txtFechaDeEntrega)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 69)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(257, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 26)
        Me.Label9.TabIndex = 154
        Me.Label9.Text = "Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Detalle" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnExportarExcelDet
        '
        Me.btnExportarExcelDet.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcelDet.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcelDet.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcelDet.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcelDet.Location = New System.Drawing.Point(260, 9)
        Me.btnExportarExcelDet.Name = "btnExportarExcelDet"
        Me.btnExportarExcelDet.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcelDet.TabIndex = 153
        Me.btnExportarExcelDet.UseVisualStyleBackColor = True
        '
        'lblCopiarPedido
        '
        Me.lblCopiarPedido.AutoSize = True
        Me.lblCopiarPedido.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCopiarPedido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCopiarPedido.Location = New System.Drawing.Point(214, 42)
        Me.lblCopiarPedido.Name = "lblCopiarPedido"
        Me.lblCopiarPedido.Size = New System.Drawing.Size(40, 26)
        Me.lblCopiarPedido.TabIndex = 152
        Me.lblCopiarPedido.Text = "Copiar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pedido"
        Me.lblCopiarPedido.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCopiarPedido
        '
        Me.btnCopiarPedido.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCopiarPedido.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCopiarPedido.Image = Global.Ventas.Vista.My.Resources.Resources.copiar_32
        Me.btnCopiarPedido.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCopiarPedido.Location = New System.Drawing.Point(218, 7)
        Me.btnCopiarPedido.Name = "btnCopiarPedido"
        Me.btnCopiarPedido.Size = New System.Drawing.Size(32, 32)
        Me.btnCopiarPedido.TabIndex = 151
        Me.btnCopiarPedido.UseVisualStyleBackColor = True
        '
        'lblEnviarPorApartar
        '
        Me.lblEnviarPorApartar.AutoSize = True
        Me.lblEnviarPorApartar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEnviarPorApartar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEnviarPorApartar.Location = New System.Drawing.Point(2, 39)
        Me.lblEnviarPorApartar.Name = "lblEnviarPorApartar"
        Me.lblEnviarPorApartar.Size = New System.Drawing.Size(60, 26)
        Me.lblEnviarPorApartar.TabIndex = 93
        Me.lblEnviarPorApartar.Text = "Enviar a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Por Apartar"
        Me.lblEnviarPorApartar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEnviarPorApartar
        '
        Me.btnEnviarPorApartar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEnviarPorApartar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEnviarPorApartar.Image = Global.Ventas.Vista.My.Resources.Resources.urgente
        Me.btnEnviarPorApartar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnviarPorApartar.Location = New System.Drawing.Point(16, 7)
        Me.btnEnviarPorApartar.Name = "btnEnviarPorApartar"
        Me.btnEnviarPorApartar.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviarPorApartar.TabIndex = 92
        Me.btnEnviarPorApartar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEditar.Location = New System.Drawing.Point(159, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(45, 13)
        Me.lblEditar.TabIndex = 91
        Me.lblEditar.Text = "Guardar"
        '
        'btnEditar
        '
        Me.btnEditar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEditar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEditar.Location = New System.Drawing.Point(165, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 90
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblConfirmarApartado
        '
        Me.lblConfirmarApartado.AutoSize = True
        Me.lblConfirmarApartado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConfirmarApartado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblConfirmarApartado.Location = New System.Drawing.Point(59, 42)
        Me.lblConfirmarApartado.Name = "lblConfirmarApartado"
        Me.lblConfirmarApartado.Size = New System.Drawing.Size(48, 13)
        Me.lblConfirmarApartado.TabIndex = 88
        Me.lblConfirmarApartado.Text = "Autorizar"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Location = New System.Drawing.Point(684, 14)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(10, 20)
        Me.txtIdCliente.TabIndex = 150
        Me.txtIdCliente.Visible = False
        '
        'lblRechazar
        '
        Me.lblRechazar.AutoSize = True
        Me.lblRechazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRechazar.Location = New System.Drawing.Point(108, 42)
        Me.lblRechazar.Name = "lblRechazar"
        Me.lblRechazar.Size = New System.Drawing.Size(49, 13)
        Me.lblRechazar.TabIndex = 89
        Me.lblRechazar.Text = "Cancelar"
        '
        'txtIdAgente
        '
        Me.txtIdAgente.Location = New System.Drawing.Point(672, 14)
        Me.txtIdAgente.Name = "txtIdAgente"
        Me.txtIdAgente.ReadOnly = True
        Me.txtIdAgente.Size = New System.Drawing.Size(10, 20)
        Me.txtIdAgente.TabIndex = 149
        Me.txtIdAgente.Visible = False
        '
        'btnConfirmarApartadoDetalles
        '
        Me.btnConfirmarApartadoDetalles.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnConfirmarApartadoDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnConfirmarApartadoDetalles.Image = Global.Ventas.Vista.My.Resources.Resources.autorizar_32
        Me.btnConfirmarApartadoDetalles.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnConfirmarApartadoDetalles.Location = New System.Drawing.Point(67, 7)
        Me.btnConfirmarApartadoDetalles.Name = "btnConfirmarApartadoDetalles"
        Me.btnConfirmarApartadoDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnConfirmarApartadoDetalles.TabIndex = 86
        Me.btnConfirmarApartadoDetalles.UseVisualStyleBackColor = True
        '
        'btnRechazarDetalles
        '
        Me.btnRechazarDetalles.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRechazarDetalles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnRechazarDetalles.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnRechazarDetalles.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRechazarDetalles.Location = New System.Drawing.Point(116, 7)
        Me.btnRechazarDetalles.Name = "btnRechazarDetalles"
        Me.btnRechazarDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazarDetalles.TabIndex = 87
        Me.btnRechazarDetalles.UseVisualStyleBackColor = True
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(656, 14)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.ReadOnly = True
        Me.txtAsunto.Size = New System.Drawing.Size(10, 20)
        Me.txtAsunto.TabIndex = 134
        Me.txtAsunto.Visible = False
        '
        'txtFechaDeEntrega
        '
        Me.txtFechaDeEntrega.Location = New System.Drawing.Point(640, 14)
        Me.txtFechaDeEntrega.Name = "txtFechaDeEntrega"
        Me.txtFechaDeEntrega.ReadOnly = True
        Me.txtFechaDeEntrega.Size = New System.Drawing.Size(10, 20)
        Me.txtFechaDeEntrega.TabIndex = 138
        Me.txtFechaDeEntrega.Visible = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(732, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(527, 69)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(244, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(168, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Pedido de Muestras"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(444, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 69)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1259, 204)
        Me.Panel1.TabIndex = 25
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(12, 180)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 152
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grpbCambioTalla)
        Me.Panel3.Controls.Add(Me.cmbTemporada)
        Me.Panel3.Controls.Add(Me.cmbAgente)
        Me.Panel3.Controls.Add(Me.cmbCliente)
        Me.Panel3.Controls.Add(Me.dtpFechaEntrega)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtObservaciones)
        Me.Panel3.Controls.Add(Me.cmbAsunto)
        Me.Panel3.Controls.Add(Me.lblErrorMessage)
        Me.Panel3.Controls.Add(Me.lblModelo)
        Me.Panel3.Controls.Add(Me.btnBuscarModelo)
        Me.Panel3.Controls.Add(Me.txtBuscarModelo)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtCapturadoPor)
        Me.Panel3.Controls.Add(Me.lblEstatus)
        Me.Panel3.Controls.Add(Me.txtEstatus)
        Me.Panel3.Controls.Add(Me.lblFolio)
        Me.Panel3.Controls.Add(Me.txtFolio)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtTemporada)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtFechaCaptura)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtAgente)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtCliente)
        Me.Panel3.Location = New System.Drawing.Point(12, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1235, 168)
        Me.Panel3.TabIndex = 0
        '
        'grpbCambioTalla
        '
        Me.grpbCambioTalla.Controls.Add(Me.btnCambioDeTalla)
        Me.grpbCambioTalla.Controls.Add(Me.txtNuevaTalla)
        Me.grpbCambioTalla.Controls.Add(Me.lblCambioTalla)
        Me.grpbCambioTalla.Location = New System.Drawing.Point(46, 105)
        Me.grpbCambioTalla.Name = "grpbCambioTalla"
        Me.grpbCambioTalla.Size = New System.Drawing.Size(256, 54)
        Me.grpbCambioTalla.TabIndex = 160
        Me.grpbCambioTalla.TabStop = False
        Me.grpbCambioTalla.Text = "Cambio de talla partidas seleccionadas"
        Me.grpbCambioTalla.Visible = False
        '
        'btnCambioDeTalla
        '
        Me.btnCambioDeTalla.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCambioDeTalla.Image = Global.Ventas.Vista.My.Resources.Resources.refresh_32
        Me.btnCambioDeTalla.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCambioDeTalla.Location = New System.Drawing.Point(182, 18)
        Me.btnCambioDeTalla.Name = "btnCambioDeTalla"
        Me.btnCambioDeTalla.Size = New System.Drawing.Size(32, 32)
        Me.btnCambioDeTalla.TabIndex = 153
        Me.btnCambioDeTalla.UseVisualStyleBackColor = True
        '
        'txtNuevaTalla
        '
        Me.txtNuevaTalla.Location = New System.Drawing.Point(84, 25)
        Me.txtNuevaTalla.Name = "txtNuevaTalla"
        Me.txtNuevaTalla.Size = New System.Drawing.Size(84, 20)
        Me.txtNuevaTalla.TabIndex = 1
        '
        'lblCambioTalla
        '
        Me.lblCambioTalla.AutoSize = True
        Me.lblCambioTalla.Location = New System.Drawing.Point(11, 28)
        Me.lblCambioTalla.Name = "lblCambioTalla"
        Me.lblCambioTalla.Size = New System.Drawing.Size(68, 13)
        Me.lblCambioTalla.TabIndex = 0
        Me.lblCambioTalla.Text = "Nueva Talla:"
        '
        'cmbTemporada
        '
        Me.cmbTemporada.Enabled = False
        Me.cmbTemporada.FormattingEnabled = True
        Me.cmbTemporada.Location = New System.Drawing.Point(597, 44)
        Me.cmbTemporada.Name = "cmbTemporada"
        Me.cmbTemporada.Size = New System.Drawing.Size(198, 21)
        Me.cmbTemporada.TabIndex = 159
        '
        'cmbAgente
        '
        Me.cmbAgente.Enabled = False
        Me.cmbAgente.FormattingEnabled = True
        Me.cmbAgente.Location = New System.Drawing.Point(145, 45)
        Me.cmbAgente.Name = "cmbAgente"
        Me.cmbAgente.Size = New System.Drawing.Size(322, 21)
        Me.cmbAgente.TabIndex = 158
        '
        'cmbCliente
        '
        Me.cmbCliente.Enabled = False
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(145, 18)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(322, 21)
        Me.cmbCliente.TabIndex = 157
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.CustomFormat = ""
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(597, 74)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(198, 20)
        Me.dtpFechaEntrega.TabIndex = 156
        Me.dtpFechaEntrega.Value = New Date(2016, 10, 20, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(498, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 155
        Me.Label8.Text = "*Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(597, 107)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(607, 53)
        Me.txtObservaciones.TabIndex = 154
        '
        'cmbAsunto
        '
        Me.cmbAsunto.FormattingEnabled = True
        Me.cmbAsunto.Location = New System.Drawing.Point(597, 17)
        Me.cmbAsunto.Name = "cmbAsunto"
        Me.cmbAsunto.Size = New System.Drawing.Size(198, 21)
        Me.cmbAsunto.TabIndex = 153
        '
        'lblErrorMessage
        '
        Me.lblErrorMessage.AutoSize = True
        Me.lblErrorMessage.ForeColor = System.Drawing.Color.Red
        Me.lblErrorMessage.Location = New System.Drawing.Point(106, 136)
        Me.lblErrorMessage.Name = "lblErrorMessage"
        Me.lblErrorMessage.Size = New System.Drawing.Size(158, 13)
        Me.lblErrorMessage.TabIndex = 152
        Me.lblErrorMessage.Text = "* Captura al menos 3 caracteres"
        Me.lblErrorMessage.Visible = False
        '
        'lblModelo
        '
        Me.lblModelo.AutoSize = True
        Me.lblModelo.Location = New System.Drawing.Point(44, 114)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(42, 13)
        Me.lblModelo.TabIndex = 148
        Me.lblModelo.Text = "Modelo"
        '
        'btnBuscarModelo
        '
        Me.btnBuscarModelo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBuscarModelo.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscarModelo.Location = New System.Drawing.Point(266, 105)
        Me.btnBuscarModelo.Name = "btnBuscarModelo"
        Me.btnBuscarModelo.Size = New System.Drawing.Size(36, 37)
        Me.btnBuscarModelo.TabIndex = 147
        Me.btnBuscarModelo.UseVisualStyleBackColor = True
        '
        'txtBuscarModelo
        '
        Me.txtBuscarModelo.Location = New System.Drawing.Point(146, 113)
        Me.txtBuscarModelo.Name = "txtBuscarModelo"
        Me.txtBuscarModelo.Size = New System.Drawing.Size(110, 20)
        Me.txtBuscarModelo.TabIndex = 146
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(841, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 145
        Me.Label7.Text = "Capturado Por"
        '
        'txtCapturadoPor
        '
        Me.txtCapturadoPor.Location = New System.Drawing.Point(954, 74)
        Me.txtCapturadoPor.Name = "txtCapturadoPor"
        Me.txtCapturadoPor.ReadOnly = True
        Me.txtCapturadoPor.Size = New System.Drawing.Size(250, 20)
        Me.txtCapturadoPor.TabIndex = 144
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(841, 45)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(42, 13)
        Me.lblEstatus.TabIndex = 143
        Me.lblEstatus.Text = "Estatus"
        '
        'txtEstatus
        '
        Me.txtEstatus.Location = New System.Drawing.Point(954, 45)
        Me.txtEstatus.Name = "txtEstatus"
        Me.txtEstatus.ReadOnly = True
        Me.txtEstatus.Size = New System.Drawing.Size(250, 20)
        Me.txtEstatus.TabIndex = 142
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(841, 17)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(100, 13)
        Me.lblFolio.TabIndex = 141
        Me.lblFolio.Text = "*Folio de Pedido"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(954, 18)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(78, 20)
        Me.txtFolio.TabIndex = 140
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(498, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "*Fecha de Entrega"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(498, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "*Temporada"
        '
        'txtTemporada
        '
        Me.txtTemporada.Location = New System.Drawing.Point(585, 45)
        Me.txtTemporada.Name = "txtTemporada"
        Me.txtTemporada.ReadOnly = True
        Me.txtTemporada.Size = New System.Drawing.Size(10, 20)
        Me.txtTemporada.TabIndex = 136
        Me.txtTemporada.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(498, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "*Asunto"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "*Fecha de Captura"
        '
        'txtFechaCaptura
        '
        Me.txtFechaCaptura.Location = New System.Drawing.Point(146, 74)
        Me.txtFechaCaptura.Name = "txtFechaCaptura"
        Me.txtFechaCaptura.ReadOnly = True
        Me.txtFechaCaptura.Size = New System.Drawing.Size(156, 20)
        Me.txtFechaCaptura.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "*Agente"
        '
        'txtAgente
        '
        Me.txtAgente.Location = New System.Drawing.Point(134, 45)
        Me.txtAgente.Name = "txtAgente"
        Me.txtAgente.ReadOnly = True
        Me.txtAgente.Size = New System.Drawing.Size(10, 20)
        Me.txtAgente.TabIndex = 130
        Me.txtAgente.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "*Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(134, 19)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(10, 20)
        Me.txtCliente.TabIndex = 128
        Me.txtCliente.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 549)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1259, 60)
        Me.Panel2.TabIndex = 26
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1097, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 2
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
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
        Me.lblCerrar.Location = New System.Drawing.Point(119, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdPedidosMuestraDetalles
        '
        Me.grdPedidosMuestraDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidosMuestraDetalles.Location = New System.Drawing.Point(0, 273)
        Me.grdPedidosMuestraDetalles.MainView = Me.grdVpedidosMuestrasDetalles
        Me.grdPedidosMuestraDetalles.Name = "grdPedidosMuestraDetalles"
        Me.grdPedidosMuestraDetalles.Size = New System.Drawing.Size(1259, 276)
        Me.grdPedidosMuestraDetalles.TabIndex = 27
        Me.grdPedidosMuestraDetalles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVpedidosMuestrasDetalles})
        '
        'grdVpedidosMuestrasDetalles
        '
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "Format0"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule1.StopIfTrue = True
        Me.grdVpedidosMuestrasDetalles.FormatRules.Add(GridFormatRule1)
        Me.grdVpedidosMuestrasDetalles.GridControl = Me.grdPedidosMuestraDetalles
        Me.grdVpedidosMuestrasDetalles.Name = "grdVpedidosMuestrasDetalles"
        Me.grdVpedidosMuestrasDetalles.OptionsView.ShowAutoFilterRow = True
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(43, 360)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(550, 80)
        Me.UltraGrid1.TabIndex = 28
        Me.UltraGrid1.Text = "UltraGrid1"
        Me.UltraGrid1.Visible = False
        '
        'PedidosMuestrasDetallesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(1259, 609)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.grdPedidosMuestraDetalles)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "PedidosMuestrasDetallesForm"
        Me.Text = "Pedido de Muestras"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.grpbCambioTalla.ResumeLayout(False)
        Me.grpbCambioTalla.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdPedidosMuestraDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVpedidosMuestrasDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdPedidosMuestraDetalles As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVpedidosMuestrasDetalles As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblConfirmarApartado As System.Windows.Forms.Label
    Friend WithEvents lblRechazar As System.Windows.Forms.Label
    Friend WithEvents btnConfirmarApartadoDetalles As System.Windows.Forms.Button
    Friend WithEvents btnRechazarDetalles As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblEnviarPorApartar As Label
    Friend WithEvents btnEnviarPorApartar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dtpFechaEntrega As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents cmbAsunto As ComboBox
    Friend WithEvents lblErrorMessage As Label
    Friend WithEvents txtIdCliente As TextBox
    Friend WithEvents txtIdAgente As TextBox
    Friend WithEvents lblModelo As Label
    Friend WithEvents btnBuscarModelo As Button
    Friend WithEvents txtBuscarModelo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCapturadoPor As TextBox
    Friend WithEvents lblEstatus As Label
    Friend WithEvents txtEstatus As TextBox
    Friend WithEvents lblFolio As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFechaDeEntrega As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTemporada As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAsunto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFechaCaptura As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAgente As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents lblCopiarPedido As Label
    Friend WithEvents btnCopiarPedido As Button
    Friend WithEvents cmbCliente As ComboBox
    Friend WithEvents cmbTemporada As ComboBox
    Friend WithEvents cmbAgente As ComboBox
    Friend WithEvents grpbCambioTalla As GroupBox
    Friend WithEvents txtNuevaTalla As TextBox
    Friend WithEvents lblCambioTalla As Label
    Friend WithEvents btnCambioDeTalla As Button
    Friend WithEvents btnExportarExcelDet As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
