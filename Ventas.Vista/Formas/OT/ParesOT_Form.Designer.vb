<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParesOT_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParesOT_Form))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblEstatusApartado = New System.Windows.Forms.Label()
        Me.lblIdPedidoSICY = New System.Windows.Forms.Label()
        Me.lblTextoPedidoSICY = New System.Windows.Forms.Label()
        Me.lblFPreparacion = New System.Windows.Forms.Label()
        Me.lblTextoFPreparacion = New System.Windows.Forms.Label()
        Me.lblOrdenCliente = New System.Windows.Forms.Label()
        Me.lblTextoOrdenCliente = New System.Windows.Forms.Label()
        Me.lblFSolicitada = New System.Windows.Forms.Label()
        Me.lblTextoFSolicitada = New System.Windows.Forms.Label()
        Me.lblIdPedidoSAY = New System.Windows.Forms.Label()
        Me.lblTextoPedidoSAY = New System.Windows.Forms.Label()
        Me.lblIdApartadoSICY = New System.Windows.Forms.Label()
        Me.lblIdApartado = New System.Windows.Forms.Label()
        Me.lblTextoApartadoSICY = New System.Windows.Forms.Label()
        Me.lblTextoFolioApartado = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblTextoCliente = New System.Windows.Forms.Label()
        Me.grdCodigosInvalidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCancelados = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPorConfirmar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalConfirmados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblTotalP = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdCodigosInvalidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlMarcarTodo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1019, 543)
        Me.pnlContenedor.TabIndex = 8
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.Panel2)
        Me.pnlListaCliente.Controls.Add(Me.pnlPie)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(1019, 484)
        Me.pnlListaCliente.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.grdCodigosInvalidos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1019, 426)
        Me.Panel2.TabIndex = 78
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblEstatusApartado)
        Me.Panel3.Controls.Add(Me.lblIdPedidoSICY)
        Me.Panel3.Controls.Add(Me.lblTextoPedidoSICY)
        Me.Panel3.Controls.Add(Me.lblFPreparacion)
        Me.Panel3.Controls.Add(Me.lblTextoFPreparacion)
        Me.Panel3.Controls.Add(Me.lblOrdenCliente)
        Me.Panel3.Controls.Add(Me.lblTextoOrdenCliente)
        Me.Panel3.Controls.Add(Me.lblFSolicitada)
        Me.Panel3.Controls.Add(Me.lblTextoFSolicitada)
        Me.Panel3.Controls.Add(Me.lblIdPedidoSAY)
        Me.Panel3.Controls.Add(Me.lblTextoPedidoSAY)
        Me.Panel3.Controls.Add(Me.lblIdApartadoSICY)
        Me.Panel3.Controls.Add(Me.lblIdApartado)
        Me.Panel3.Controls.Add(Me.lblTextoApartadoSICY)
        Me.Panel3.Controls.Add(Me.lblTextoFolioApartado)
        Me.Panel3.Controls.Add(Me.lblNombreCliente)
        Me.Panel3.Controls.Add(Me.lblTextoCliente)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1019, 43)
        Me.Panel3.TabIndex = 10
        '
        'lblEstatusApartado
        '
        Me.lblEstatusApartado.AutoSize = True
        Me.lblEstatusApartado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatusApartado.ForeColor = System.Drawing.Color.Indigo
        Me.lblEstatusApartado.Location = New System.Drawing.Point(13, 24)
        Me.lblEstatusApartado.Name = "lblEstatusApartado"
        Me.lblEstatusApartado.Size = New System.Drawing.Size(187, 13)
        Me.lblEstatusApartado.TabIndex = 32
        Me.lblEstatusApartado.Text = "PARCIALMENTE CONFIRMADA"
        Me.lblEstatusApartado.Visible = False
        '
        'lblIdPedidoSICY
        '
        Me.lblIdPedidoSICY.AutoSize = True
        Me.lblIdPedidoSICY.Location = New System.Drawing.Point(544, 24)
        Me.lblIdPedidoSICY.Name = "lblIdPedidoSICY"
        Me.lblIdPedidoSICY.Size = New System.Drawing.Size(43, 13)
        Me.lblIdPedidoSICY.TabIndex = 31
        Me.lblIdPedidoSICY.Text = "112958"
        Me.lblIdPedidoSICY.Visible = False
        '
        'lblTextoPedidoSICY
        '
        Me.lblTextoPedidoSICY.AutoSize = True
        Me.lblTextoPedidoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoPedidoSICY.Location = New System.Drawing.Point(465, 24)
        Me.lblTextoPedidoSICY.Name = "lblTextoPedidoSICY"
        Me.lblTextoPedidoSICY.Size = New System.Drawing.Size(82, 13)
        Me.lblTextoPedidoSICY.TabIndex = 30
        Me.lblTextoPedidoSICY.Text = "Pedido SICY:"
        Me.lblTextoPedidoSICY.Visible = False
        '
        'lblFPreparacion
        '
        Me.lblFPreparacion.AutoSize = True
        Me.lblFPreparacion.Location = New System.Drawing.Point(883, 24)
        Me.lblFPreparacion.Name = "lblFPreparacion"
        Me.lblFPreparacion.Size = New System.Drawing.Size(118, 13)
        Me.lblFPreparacion.TabIndex = 18
        Me.lblFPreparacion.Text = "24/10/2016 02:15 p.m."
        Me.lblFPreparacion.Visible = False
        '
        'lblTextoFPreparacion
        '
        Me.lblTextoFPreparacion.AutoSize = True
        Me.lblTextoFPreparacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoFPreparacion.Location = New System.Drawing.Point(804, 24)
        Me.lblTextoFPreparacion.Name = "lblTextoFPreparacion"
        Me.lblTextoFPreparacion.Size = New System.Drawing.Size(80, 13)
        Me.lblTextoFPreparacion.TabIndex = 17
        Me.lblTextoFPreparacion.Text = "F. Aceptada:"
        Me.lblTextoFPreparacion.Visible = False
        '
        'lblOrdenCliente
        '
        Me.lblOrdenCliente.AutoSize = True
        Me.lblOrdenCliente.Location = New System.Drawing.Point(707, 24)
        Me.lblOrdenCliente.Name = "lblOrdenCliente"
        Me.lblOrdenCliente.Size = New System.Drawing.Size(68, 13)
        Me.lblOrdenCliente.TabIndex = 13
        Me.lblOrdenCliente.Text = "OCOCT2016"
        Me.lblOrdenCliente.Visible = False
        '
        'lblTextoOrdenCliente
        '
        Me.lblTextoOrdenCliente.AutoSize = True
        Me.lblTextoOrdenCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoOrdenCliente.Location = New System.Drawing.Point(619, 24)
        Me.lblTextoOrdenCliente.Name = "lblTextoOrdenCliente"
        Me.lblTextoOrdenCliente.Size = New System.Drawing.Size(87, 13)
        Me.lblTextoOrdenCliente.TabIndex = 12
        Me.lblTextoOrdenCliente.Text = "Orden cliente:"
        Me.lblTextoOrdenCliente.Visible = False
        '
        'lblFSolicitada
        '
        Me.lblFSolicitada.AutoSize = True
        Me.lblFSolicitada.Location = New System.Drawing.Point(883, 6)
        Me.lblFSolicitada.Name = "lblFSolicitada"
        Me.lblFSolicitada.Size = New System.Drawing.Size(65, 13)
        Me.lblFSolicitada.TabIndex = 11
        Me.lblFSolicitada.Text = "30/10/2016"
        Me.lblFSolicitada.Visible = False
        '
        'lblTextoFSolicitada
        '
        Me.lblTextoFSolicitada.AutoSize = True
        Me.lblTextoFSolicitada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoFSolicitada.Location = New System.Drawing.Point(804, 6)
        Me.lblTextoFSolicitada.Name = "lblTextoFSolicitada"
        Me.lblTextoFSolicitada.Size = New System.Drawing.Size(60, 13)
        Me.lblTextoFSolicitada.TabIndex = 10
        Me.lblTextoFSolicitada.Text = "F. Progr.:"
        Me.lblTextoFSolicitada.Visible = False
        '
        'lblIdPedidoSAY
        '
        Me.lblIdPedidoSAY.AutoSize = True
        Me.lblIdPedidoSAY.Location = New System.Drawing.Point(544, 6)
        Me.lblIdPedidoSAY.Name = "lblIdPedidoSAY"
        Me.lblIdPedidoSAY.Size = New System.Drawing.Size(31, 13)
        Me.lblIdPedidoSAY.TabIndex = 9
        Me.lblIdPedidoSAY.Text = "7728"
        Me.lblIdPedidoSAY.Visible = False
        '
        'lblTextoPedidoSAY
        '
        Me.lblTextoPedidoSAY.AutoSize = True
        Me.lblTextoPedidoSAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoPedidoSAY.Location = New System.Drawing.Point(465, 6)
        Me.lblTextoPedidoSAY.Name = "lblTextoPedidoSAY"
        Me.lblTextoPedidoSAY.Size = New System.Drawing.Size(78, 13)
        Me.lblTextoPedidoSAY.TabIndex = 8
        Me.lblTextoPedidoSAY.Text = "Pedido SAY:"
        Me.lblTextoPedidoSAY.Visible = False
        '
        'lblIdApartadoSICY
        '
        Me.lblIdApartadoSICY.AutoSize = True
        Me.lblIdApartadoSICY.Location = New System.Drawing.Point(408, 24)
        Me.lblIdApartadoSICY.Name = "lblIdApartadoSICY"
        Me.lblIdApartadoSICY.Size = New System.Drawing.Size(13, 13)
        Me.lblIdApartadoSICY.TabIndex = 7
        Me.lblIdApartadoSICY.Text = "0"
        Me.lblIdApartadoSICY.Visible = False
        '
        'lblIdApartado
        '
        Me.lblIdApartado.AutoSize = True
        Me.lblIdApartado.Location = New System.Drawing.Point(408, 6)
        Me.lblIdApartado.Name = "lblIdApartado"
        Me.lblIdApartado.Size = New System.Drawing.Size(19, 13)
        Me.lblIdApartado.TabIndex = 7
        Me.lblIdApartado.Text = "15"
        Me.lblIdApartado.Visible = False
        '
        'lblTextoApartadoSICY
        '
        Me.lblTextoApartadoSICY.AutoSize = True
        Me.lblTextoApartadoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoApartadoSICY.Location = New System.Drawing.Point(348, 24)
        Me.lblTextoApartadoSICY.Name = "lblTextoApartadoSICY"
        Me.lblTextoApartadoSICY.Size = New System.Drawing.Size(60, 13)
        Me.lblTextoApartadoSICY.TabIndex = 6
        Me.lblTextoApartadoSICY.Text = "OT SICY:"
        Me.lblTextoApartadoSICY.Visible = False
        '
        'lblTextoFolioApartado
        '
        Me.lblTextoFolioApartado.AutoSize = True
        Me.lblTextoFolioApartado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoFolioApartado.Location = New System.Drawing.Point(348, 6)
        Me.lblTextoFolioApartado.Name = "lblTextoFolioApartado"
        Me.lblTextoFolioApartado.Size = New System.Drawing.Size(56, 13)
        Me.lblTextoFolioApartado.TabIndex = 6
        Me.lblTextoFolioApartado.Text = "OT SAY:"
        Me.lblTextoFolioApartado.Visible = False
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Location = New System.Drawing.Point(67, 6)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(74, 13)
        Me.lblNombreCliente.TabIndex = 4
        Me.lblNombreCliente.Text = "DESTROYER"
        Me.lblNombreCliente.Visible = False
        '
        'lblTextoCliente
        '
        Me.lblTextoCliente.AutoSize = True
        Me.lblTextoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCliente.Location = New System.Drawing.Point(13, 6)
        Me.lblTextoCliente.Name = "lblTextoCliente"
        Me.lblTextoCliente.Size = New System.Drawing.Size(50, 13)
        Me.lblTextoCliente.TabIndex = 3
        Me.lblTextoCliente.Text = "Cliente:"
        Me.lblTextoCliente.Visible = False
        '
        'grdCodigosInvalidos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCodigosInvalidos.DisplayLayout.Appearance = Appearance1
        Me.grdCodigosInvalidos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCodigosInvalidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCodigosInvalidos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCodigosInvalidos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCodigosInvalidos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCodigosInvalidos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCodigosInvalidos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCodigosInvalidos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCodigosInvalidos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCodigosInvalidos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdCodigosInvalidos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCodigosInvalidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCodigosInvalidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCodigosInvalidos.Location = New System.Drawing.Point(0, 0)
        Me.grdCodigosInvalidos.Name = "grdCodigosInvalidos"
        Me.grdCodigosInvalidos.Size = New System.Drawing.Size(1019, 426)
        Me.grdCodigosInvalidos.TabIndex = 2
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label4)
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.lblCancelados)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.lblPorConfirmar)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Controls.Add(Me.lblTotalConfirmados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.lblTotalPares)
        Me.pnlPie.Controls.Add(Me.lblTotalP)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 426)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1019, 58)
        Me.pnlPie.TabIndex = 64
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(289, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(282, 13)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "(IU) Total de pares con incidencia de ubicación:"
        '
        'lblCancelados
        '
        Me.lblCancelados.AutoSize = True
        Me.lblCancelados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancelados.ForeColor = System.Drawing.Color.RosyBrown
        Me.lblCancelados.Location = New System.Drawing.Point(915, 43)
        Me.lblCancelados.Name = "lblCancelados"
        Me.lblCancelados.Size = New System.Drawing.Size(14, 13)
        Me.lblCancelados.TabIndex = 49
        Me.lblCancelados.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(737, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Total de pares cancelados:"
        '
        'lblPorConfirmar
        '
        Me.lblPorConfirmar.AutoSize = True
        Me.lblPorConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorConfirmar.ForeColor = System.Drawing.Color.Red
        Me.lblPorConfirmar.Location = New System.Drawing.Point(908, 29)
        Me.lblPorConfirmar.Name = "lblPorConfirmar"
        Me.lblPorConfirmar.Size = New System.Drawing.Size(21, 13)
        Me.lblPorConfirmar.TabIndex = 47
        Me.lblPorConfirmar.Text = "45"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(728, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Total de pares por confirmar:"
        '
        'lblTotalConfirmados
        '
        Me.lblTotalConfirmados.AutoSize = True
        Me.lblTotalConfirmados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalConfirmados.ForeColor = System.Drawing.Color.Green
        Me.lblTotalConfirmados.Location = New System.Drawing.Point(901, 15)
        Me.lblTotalConfirmados.Name = "lblTotalConfirmados"
        Me.lblTotalConfirmados.Size = New System.Drawing.Size(28, 13)
        Me.lblTotalConfirmados.TabIndex = 45
        Me.lblTotalConfirmados.Text = "117"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(734, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Total de pares confirmados:"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPares.Location = New System.Drawing.Point(901, 2)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(28, 13)
        Me.lblTotalPares.TabIndex = 43
        Me.lblTotalPares.Text = "162"
        '
        'lblTotalP
        '
        Me.lblTotalP.AutoSize = True
        Me.lblTotalP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalP.Location = New System.Drawing.Point(785, 2)
        Me.lblTotalP.Name = "lblTotalP"
        Me.lblTotalP.Size = New System.Drawing.Size(114, 13)
        Me.lblTotalP.TabIndex = 42
        Me.lblTotalP.Text = "Total de pares OT:"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(875, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 58)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(96, 5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(95, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1019, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1019, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1019, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1019, 59)
        Me.Panel1.TabIndex = 47
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Controls.Add(Me.lblExportar)
        Me.pnlMarcarTodo.Controls.Add(Me.btnExportar)
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(161, 59)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblExportar.Location = New System.Drawing.Point(18, 39)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 6
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(23, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 7
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(798, 19)
        Me.lblTitulo.MaximumSize = New System.Drawing.Size(150, 20)
        Me.lblTitulo.MinimumSize = New System.Drawing.Size(150, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(150, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Pares de la OT"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(951, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ParesOT_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 543)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Name = "ParesOT_Form"
        Me.Text = "Pares de la OT"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.grdCodigosInvalidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlMarcarTodo.ResumeLayout(False)
        Me.pnlMarcarTodo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdCodigosInvalidos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlMarcarTodo As System.Windows.Forms.Panel
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblEstatusApartado As System.Windows.Forms.Label
    Friend WithEvents lblIdPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents lblTextoPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents lblFPreparacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoFPreparacion As System.Windows.Forms.Label
    Friend WithEvents lblOrdenCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoOrdenCliente As System.Windows.Forms.Label
    Friend WithEvents lblFSolicitada As System.Windows.Forms.Label
    Friend WithEvents lblTextoFSolicitada As System.Windows.Forms.Label
    Friend WithEvents lblIdPedidoSAY As System.Windows.Forms.Label
    Friend WithEvents lblTextoPedidoSAY As System.Windows.Forms.Label
    Friend WithEvents lblIdApartadoSICY As System.Windows.Forms.Label
    Friend WithEvents lblIdApartado As System.Windows.Forms.Label
    Friend WithEvents lblTextoApartadoSICY As System.Windows.Forms.Label
    Friend WithEvents lblTextoFolioApartado As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblTextoCliente As System.Windows.Forms.Label
    Friend WithEvents lblCancelados As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblPorConfirmar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalConfirmados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents lblTotalP As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
