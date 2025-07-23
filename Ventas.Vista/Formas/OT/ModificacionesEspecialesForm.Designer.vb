<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificacionesEspecialesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificacionesEspecialesForm))
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblActualizacion = New System.Windows.Forms.Label()
        Me.lblParesProceso = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkOC = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOC = New System.Windows.Forms.TextBox()
        Me.chkCamcioRFC = New System.Windows.Forms.CheckBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblOTs = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblEntregaMercancia = New System.Windows.Forms.Label()
        Me.txtPedidoOrigen = New System.Windows.Forms.TextBox()
        Me.cboTienda = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUnidad = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboRFC = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPedidoSICY = New System.Windows.Forms.TextBox()
        Me.txtPedidoSAY = New System.Windows.Forms.TextBox()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.lblAsignar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdPartidas = New DevExpress.XtraGrid.GridControl()
        Me.grdVWPartidas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlPie.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVWPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.Panel5)
        Me.pnlPie.Controls.Add(Me.lblParesProceso)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 391)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(904, 59)
        Me.pnlPie.TabIndex = 81
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkViolet
        Me.Label6.Location = New System.Drawing.Point(145, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "Cambio realizados."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label5.Location = New System.Drawing.Point(145, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(139, 13)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Tienda no asignada al RFC."
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.lblActualizacion)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(536, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(285, 59)
        Me.Panel5.TabIndex = 125
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Ultima actualización:"
        '
        'lblActualizacion
        '
        Me.lblActualizacion.AutoSize = True
        Me.lblActualizacion.Location = New System.Drawing.Point(121, 25)
        Me.lblActualizacion.Name = "lblActualizacion"
        Me.lblActualizacion.Size = New System.Drawing.Size(16, 13)
        Me.lblActualizacion.TabIndex = 80
        Me.lblActualizacion.Text = "..."
        '
        'lblParesProceso
        '
        Me.lblParesProceso.AutoSize = True
        Me.lblParesProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesProceso.ForeColor = System.Drawing.Color.Black
        Me.lblParesProceso.Location = New System.Drawing.Point(28, 12)
        Me.lblParesProceso.Name = "lblParesProceso"
        Me.lblParesProceso.Size = New System.Drawing.Size(75, 16)
        Me.lblParesProceso.TabIndex = 124
        Me.lblParesProceso.Text = "Registros"
        Me.lblParesProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(28, 28)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalRegistros.TabIndex = 123
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCerrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(821, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(83, 59)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(25, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(24, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 2
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlHeader)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(904, 72)
        Me.pnlCabecera.TabIndex = 80
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Panel2)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(503, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(401, 72)
        Me.pnlHeader.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEncabezado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(71, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 72)
        Me.Panel2.TabIndex = 46
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(36, 26)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(220, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Modificaciones Especiales"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(333, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 72)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.Panel3)
        Me.pnlParametros.Controls.Add(Me.lblGuardar)
        Me.pnlParametros.Controls.Add(Me.btnGuardar)
        Me.pnlParametros.Controls.Add(Me.btnAsignar)
        Me.pnlParametros.Controls.Add(Me.chkSeleccionarTodo)
        Me.pnlParametros.Controls.Add(Me.lblAsignar)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 72)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(904, 145)
        Me.pnlParametros.TabIndex = 82
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chkOC)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtOC)
        Me.Panel3.Controls.Add(Me.chkCamcioRFC)
        Me.Panel3.Controls.Add(Me.lblusuario)
        Me.Panel3.Controls.Add(Me.lblTipo)
        Me.Panel3.Controls.Add(Me.lblOTs)
        Me.Panel3.Controls.Add(Me.txtCliente)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.lblEntregaMercancia)
        Me.Panel3.Controls.Add(Me.txtPedidoOrigen)
        Me.Panel3.Controls.Add(Me.cboTienda)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.lblUnidad)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.cboRFC)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtPedidoSICY)
        Me.Panel3.Controls.Add(Me.txtPedidoSAY)
        Me.Panel3.Location = New System.Drawing.Point(9, 7)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(762, 117)
        Me.Panel3.TabIndex = 91
        '
        'chkOC
        '
        Me.chkOC.AutoSize = True
        Me.chkOC.Location = New System.Drawing.Point(614, 14)
        Me.chkOC.Name = "chkOC"
        Me.chkOC.Size = New System.Drawing.Size(82, 17)
        Me.chkOC.TabIndex = 99
        Me.chkOC.Text = "Cambiar OC"
        Me.chkOC.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(463, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "OC:"
        '
        'txtOC
        '
        Me.txtOC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOC.Enabled = False
        Me.txtOC.Location = New System.Drawing.Point(496, 12)
        Me.txtOC.Name = "txtOC"
        Me.txtOC.Size = New System.Drawing.Size(109, 20)
        Me.txtOC.TabIndex = 97
        '
        'chkCamcioRFC
        '
        Me.chkCamcioRFC.AutoSize = True
        Me.chkCamcioRFC.Location = New System.Drawing.Point(91, 64)
        Me.chkCamcioRFC.Name = "chkCamcioRFC"
        Me.chkCamcioRFC.Size = New System.Drawing.Size(88, 17)
        Me.chkCamcioRFC.TabIndex = 96
        Me.chkCamcioRFC.Text = "Cambiar RFC"
        Me.chkCamcioRFC.UseVisualStyleBackColor = True
        '
        'lblusuario
        '
        Me.lblusuario.AutoSize = True
        Me.lblusuario.Location = New System.Drawing.Point(611, 62)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(41, 13)
        Me.lblusuario.TabIndex = 95
        Me.lblusuario.Text = "usuario"
        Me.lblusuario.Visible = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(611, 43)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(24, 13)
        Me.lblTipo.TabIndex = 94
        Me.lblTipo.Text = "tipo"
        Me.lblTipo.Visible = False
        '
        'lblOTs
        '
        Me.lblOTs.AutoSize = True
        Me.lblOTs.Location = New System.Drawing.Point(655, 43)
        Me.lblOTs.Name = "lblOTs"
        Me.lblOTs.Size = New System.Drawing.Size(23, 13)
        Me.lblOTs.TabIndex = 93
        Me.lblOTs.Text = "Ots"
        Me.lblOTs.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(91, 12)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(316, 20)
        Me.txtCliente.TabIndex = 83
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "Pedido Origen:"
        '
        'lblEntregaMercancia
        '
        Me.lblEntregaMercancia.AutoSize = True
        Me.lblEntregaMercancia.Location = New System.Drawing.Point(445, 84)
        Me.lblEntregaMercancia.Name = "lblEntregaMercancia"
        Me.lblEntregaMercancia.Size = New System.Drawing.Size(43, 13)
        Me.lblEntregaMercancia.TabIndex = 72
        Me.lblEntregaMercancia.Text = "Tienda:"
        '
        'txtPedidoOrigen
        '
        Me.txtPedidoOrigen.Enabled = False
        Me.txtPedidoOrigen.Location = New System.Drawing.Point(91, 36)
        Me.txtPedidoOrigen.Name = "txtPedidoOrigen"
        Me.txtPedidoOrigen.Size = New System.Drawing.Size(108, 20)
        Me.txtPedidoOrigen.TabIndex = 89
        '
        'cboTienda
        '
        Me.cboTienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTienda.FormattingEnabled = True
        Me.cboTienda.Location = New System.Drawing.Point(494, 81)
        Me.cboTienda.Name = "cboTienda"
        Me.cboTienda.Size = New System.Drawing.Size(216, 21)
        Me.cboTienda.TabIndex = 73
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(420, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Pedido SICY:"
        '
        'lblUnidad
        '
        Me.lblUnidad.AutoSize = True
        Me.lblUnidad.Location = New System.Drawing.Point(3, 85)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(82, 13)
        Me.lblUnidad.TabIndex = 74
        Me.lblUnidad.Text = "RFC a Facturar:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(225, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Pedido SAY:"
        '
        'cboRFC
        '
        Me.cboRFC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRFC.Enabled = False
        Me.cboRFC.FormattingEnabled = True
        Me.cboRFC.Location = New System.Drawing.Point(91, 81)
        Me.cboRFC.Name = "cboRFC"
        Me.cboRFC.Size = New System.Drawing.Size(316, 21)
        Me.cboRFC.TabIndex = 75
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Cliente:"
        '
        'txtPedidoSICY
        '
        Me.txtPedidoSICY.Enabled = False
        Me.txtPedidoSICY.Location = New System.Drawing.Point(496, 36)
        Me.txtPedidoSICY.Name = "txtPedidoSICY"
        Me.txtPedidoSICY.Size = New System.Drawing.Size(109, 20)
        Me.txtPedidoSICY.TabIndex = 85
        '
        'txtPedidoSAY
        '
        Me.txtPedidoSAY.Enabled = False
        Me.txtPedidoSAY.Location = New System.Drawing.Point(298, 36)
        Me.txtPedidoSAY.Name = "txtPedidoSAY"
        Me.txtPedidoSAY.Size = New System.Drawing.Size(109, 20)
        Me.txtPedidoSAY.TabIndex = 84
        '
        'lblGuardar
        '
        Me.lblGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(842, 75)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 78
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar_321
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(846, 43)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 79
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnAsignar
        '
        Me.btnAsignar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAsignar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAsignar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAsignar.Image = Global.Ventas.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAsignar.Location = New System.Drawing.Point(798, 43)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(32, 32)
        Me.btnAsignar.TabIndex = 82
        Me.btnAsignar.UseVisualStyleBackColor = True
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(15, 125)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodo.TabIndex = 92
        Me.chkSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'lblAsignar
        '
        Me.lblAsignar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAsignar.AutoSize = True
        Me.lblAsignar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAsignar.Location = New System.Drawing.Point(794, 75)
        Me.lblAsignar.Name = "lblAsignar"
        Me.lblAsignar.Size = New System.Drawing.Size(42, 13)
        Me.lblAsignar.TabIndex = 81
        Me.lblAsignar.Text = "Asignar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdPartidas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 217)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(904, 174)
        Me.Panel1.TabIndex = 83
        '
        'grdPartidas
        '
        Me.grdPartidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPartidas.Location = New System.Drawing.Point(0, 0)
        Me.grdPartidas.MainView = Me.grdVWPartidas
        Me.grdPartidas.Name = "grdPartidas"
        Me.grdPartidas.Size = New System.Drawing.Size(904, 174)
        Me.grdPartidas.TabIndex = 0
        Me.grdPartidas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVWPartidas})
        '
        'grdVWPartidas
        '
        Me.grdVWPartidas.GridControl = Me.grdPartidas
        Me.grdVWPartidas.Name = "grdVWPartidas"
        Me.grdVWPartidas.OptionsView.ShowAutoFilterRow = True
        Me.grdVWPartidas.OptionsView.ShowFooter = True
        Me.grdVWPartidas.OptionsView.ShowGroupPanel = False
        '
        'ModificacionesEspecialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(904, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "ModificacionesEspecialesForm"
        Me.Text = "Modificaciones Especiales"
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVWPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPie As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents lblActualizacion As Label
    Friend WithEvents lblParesProceso As Label
    Friend WithEvents lblTotalRegistros As Label
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPedidoOrigen As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPedidoSICY As TextBox
    Friend WithEvents txtPedidoSAY As TextBox
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents lblAsignar As Label
    Friend WithEvents btnAsignar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents cboRFC As ComboBox
    Friend WithEvents lblUnidad As Label
    Friend WithEvents cboTienda As ComboBox
    Friend WithEvents lblEntregaMercancia As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdPartidas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVWPartidas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chkSeleccionarTodo As CheckBox
    Friend WithEvents lblOTs As Label
    Friend WithEvents lblTipo As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents chkCamcioRFC As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtOC As TextBox
    Friend WithEvents chkOC As CheckBox
End Class
