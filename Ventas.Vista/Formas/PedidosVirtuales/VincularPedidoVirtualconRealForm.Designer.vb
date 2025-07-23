<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VincularPedidoVirtualconRealForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VincularPedidoVirtualconRealForm))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlDatos = New System.Windows.Forms.GroupBox()
        Me.grbDatos = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdPedidosVinculados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtPares = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtSemanaProgramacion = New System.Windows.Forms.TextBox()
        Me.txtTipoPedido = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaProgramada = New System.Windows.Forms.DateTimePicker()
        Me.txtIdPedido = New System.Windows.Forms.TextBox()
        Me.txtOrdenCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEstatus = New System.Windows.Forms.TextBox()
        Me.txtSemanaSolicitada = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaSolicitada = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblPedidosSeleccionados = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdPedidosReales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlDatos.SuspendLayout()
        Me.grbDatos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPedidosVinculados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdPedidosReales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlDatos.Controls.Add(Me.grbDatos)
        Me.pnlDatos.Controls.Add(Me.Panel3)
        Me.pnlDatos.Controls.Add(Me.Label11)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.Location = New System.Drawing.Point(0, 60)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1041, 195)
        Me.pnlDatos.TabIndex = 36
        Me.pnlDatos.TabStop = False
        '
        'grbDatos
        '
        Me.grbDatos.Controls.Add(Me.GroupBox1)
        Me.grbDatos.Controls.Add(Me.txtPares)
        Me.grbDatos.Controls.Add(Me.lblCliente)
        Me.grbDatos.Controls.Add(Me.txtObservaciones)
        Me.grbDatos.Controls.Add(Me.Label1)
        Me.grbDatos.Controls.Add(Me.Label7)
        Me.grbDatos.Controls.Add(Me.txtCliente)
        Me.grbDatos.Controls.Add(Me.txtSemanaProgramacion)
        Me.grbDatos.Controls.Add(Me.txtTipoPedido)
        Me.grbDatos.Controls.Add(Me.Label6)
        Me.grbDatos.Controls.Add(Me.Label2)
        Me.grbDatos.Controls.Add(Me.dtpFechaProgramada)
        Me.grbDatos.Controls.Add(Me.txtIdPedido)
        Me.grbDatos.Controls.Add(Me.txtOrdenCliente)
        Me.grbDatos.Controls.Add(Me.Label3)
        Me.grbDatos.Controls.Add(Me.Label13)
        Me.grbDatos.Controls.Add(Me.txtEstatus)
        Me.grbDatos.Controls.Add(Me.txtSemanaSolicitada)
        Me.grbDatos.Controls.Add(Me.Label4)
        Me.grbDatos.Controls.Add(Me.Label5)
        Me.grbDatos.Controls.Add(Me.dtpFechaSolicitada)
        Me.grbDatos.Location = New System.Drawing.Point(12, 33)
        Me.grbDatos.Name = "grbDatos"
        Me.grbDatos.Size = New System.Drawing.Size(1018, 167)
        Me.grbDatos.TabIndex = 128
        Me.grbDatos.TabStop = False
        Me.grbDatos.Text = "Información del Pedido Virtual"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdPedidosVinculados)
        Me.GroupBox1.Location = New System.Drawing.Point(597, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(413, 132)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedidos Reales"
        '
        'grdPedidosVinculados
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidosVinculados.DisplayLayout.Appearance = Appearance1
        Me.grdPedidosVinculados.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdPedidosVinculados.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidosVinculados.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdPedidosVinculados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdPedidosVinculados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidosVinculados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidosVinculados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidosVinculados.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPedidosVinculados.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPedidosVinculados.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdPedidosVinculados.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdPedidosVinculados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidosVinculados.Location = New System.Drawing.Point(3, 16)
        Me.grdPedidosVinculados.Name = "grdPedidosVinculados"
        Me.grdPedidosVinculados.Size = New System.Drawing.Size(407, 113)
        Me.grdPedidosVinculados.TabIndex = 62
        '
        'txtPares
        '
        Me.txtPares.Location = New System.Drawing.Point(528, 80)
        Me.txtPares.Name = "txtPares"
        Me.txtPares.Size = New System.Drawing.Size(63, 20)
        Me.txtPares.TabIndex = 116
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(11, 54)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 7
        Me.lblCliente.Text = "Cliente"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(94, 80)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(309, 46)
        Me.txtObservaciones.TabIndex = 126
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(148, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Tipo de Pedido"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "Observaciones"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(94, 51)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(309, 20)
        Me.txtCliente.TabIndex = 109
        '
        'txtSemanaProgramacion
        '
        Me.txtSemanaProgramacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSemanaProgramacion.Enabled = False
        Me.txtSemanaProgramacion.Location = New System.Drawing.Point(522, 135)
        Me.txtSemanaProgramacion.Name = "txtSemanaProgramacion"
        Me.txtSemanaProgramacion.Size = New System.Drawing.Size(66, 20)
        Me.txtSemanaProgramacion.TabIndex = 124
        '
        'txtTipoPedido
        '
        Me.txtTipoPedido.Location = New System.Drawing.Point(227, 22)
        Me.txtTipoPedido.Name = "txtTipoPedido"
        Me.txtTipoPedido.Size = New System.Drawing.Size(176, 20)
        Me.txtTipoPedido.TabIndex = 110
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(419, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "F Programación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Pedido Virtual"
        '
        'dtpFechaProgramada
        '
        Me.dtpFechaProgramada.CustomFormat = ""
        Me.dtpFechaProgramada.Enabled = False
        Me.dtpFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaProgramada.Location = New System.Drawing.Point(420, 135)
        Me.dtpFechaProgramada.Name = "dtpFechaProgramada"
        Me.dtpFechaProgramada.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaProgramada.TabIndex = 122
        Me.dtpFechaProgramada.Value = New Date(2016, 1, 30, 12, 34, 0, 0)
        '
        'txtIdPedido
        '
        Me.txtIdPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPedido.ForeColor = System.Drawing.Color.Black
        Me.txtIdPedido.Location = New System.Drawing.Point(94, 17)
        Me.txtIdPedido.Name = "txtIdPedido"
        Me.txtIdPedido.Size = New System.Drawing.Size(48, 29)
        Me.txtIdPedido.TabIndex = 112
        '
        'txtOrdenCliente
        '
        Me.txtOrdenCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrdenCliente.Location = New System.Drawing.Point(501, 51)
        Me.txtOrdenCliente.Name = "txtOrdenCliente"
        Me.txtOrdenCliente.Size = New System.Drawing.Size(90, 20)
        Me.txtOrdenCliente.TabIndex = 121
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(419, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Status"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(419, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Orden Cliente"
        '
        'txtEstatus
        '
        Me.txtEstatus.Location = New System.Drawing.Point(462, 22)
        Me.txtEstatus.Name = "txtEstatus"
        Me.txtEstatus.Size = New System.Drawing.Size(129, 20)
        Me.txtEstatus.TabIndex = 114
        '
        'txtSemanaSolicitada
        '
        Me.txtSemanaSolicitada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSemanaSolicitada.Location = New System.Drawing.Point(196, 133)
        Me.txtSemanaSolicitada.Name = "txtSemanaSolicitada"
        Me.txtSemanaSolicitada.Size = New System.Drawing.Size(64, 20)
        Me.txtSemanaSolicitada.TabIndex = 119
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(419, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Pares"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(9, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "F Solicitada "
        '
        'dtpFechaSolicitada
        '
        Me.dtpFechaSolicitada.CustomFormat = ""
        Me.dtpFechaSolicitada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaSolicitada.Location = New System.Drawing.Point(93, 133)
        Me.dtpFechaSolicitada.Name = "dtpFechaSolicitada"
        Me.dtpFechaSolicitada.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaSolicitada.TabIndex = 117
        Me.dtpFechaSolicitada.Value = New Date(2016, 2, 2, 12, 34, 0, 0)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnArriba)
        Me.Panel3.Controls.Add(Me.btnAbajo)
        Me.Panel3.Location = New System.Drawing.Point(964, 11)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(69, 189)
        Me.Panel3.TabIndex = 129
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(10, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(38, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(-70, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 108
        Me.Label11.Text = "Cliente"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1041, 60)
        Me.pnlHeader.TabIndex = 33
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.pnlTitulo.Location = New System.Drawing.Point(426, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(615, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(228, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(327, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Vincular Pedido Virtual con Pedido Real"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(555, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblTotalPares)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.lblPedidosSeleccionados)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 502)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1041, 60)
        Me.Panel2.TabIndex = 34
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalPares.Location = New System.Drawing.Point(768, 34)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(25, 25)
        Me.lblTotalPares.TabIndex = 21
        Me.lblTotalPares.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(730, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 18)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "seleccionados"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(703, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(167, 18)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Pares de los pedidos"
        '
        'lblPedidosSeleccionados
        '
        Me.lblPedidosSeleccionados.AutoSize = True
        Me.lblPedidosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosSeleccionados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPedidosSeleccionados.Location = New System.Drawing.Point(44, 34)
        Me.lblPedidosSeleccionados.Name = "lblPedidosSeleccionados"
        Me.lblPedidosSeleccionados.Size = New System.Drawing.Size(25, 25)
        Me.lblPedidosSeleccionados.TabIndex = 18
        Me.lblPedidosSeleccionados.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 18)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "seleccionados"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(27, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 18)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Registros"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(884, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(157, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(40, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 15
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(102, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(45, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 16
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(101, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdPedidosReales
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidosReales.DisplayLayout.Appearance = Appearance3
        Me.grdPedidosReales.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdPedidosReales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidosReales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdPedidosReales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdPedidosReales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidosReales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidosReales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidosReales.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdPedidosReales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPedidosReales.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdPedidosReales.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdPedidosReales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidosReales.Location = New System.Drawing.Point(0, 255)
        Me.grdPedidosReales.Name = "grdPedidosReales"
        Me.grdPedidosReales.Size = New System.Drawing.Size(1041, 247)
        Me.grdPedidosReales.TabIndex = 62
        '
        'VincularPedidoVirtualconRealForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 562)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdPedidosReales)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel2)
        Me.MaximumSize = New System.Drawing.Size(1049, 589)
        Me.MinimumSize = New System.Drawing.Size(1049, 589)
        Me.Name = "VincularPedidoVirtualconRealForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vincular Pedido Virtual con Pedido Real"
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.grbDatos.ResumeLayout(False)
        Me.grbDatos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPedidosVinculados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdPedidosReales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtEstatus As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIdPedido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTipoPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents txtPares As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPedidosSeleccionados As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtOrdenCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSemanaSolicitada As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaSolicitada As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSemanaProgramacion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaProgramada As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents grdPedidosReales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdPedidosVinculados As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
