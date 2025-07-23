<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EntregaPagosProveedorForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EntregaPagosProveedorForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTextoUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblFinalizar = New System.Windows.Forms.Label()
        Me.btnAplicarPago = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.gboxProveedor = New System.Windows.Forms.GroupBox()
        Me.btnProveedor = New System.Windows.Forms.Button()
        Me.btnLimpiarProveedor = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdProveedor = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.grdProveedoresPago = New DevExpress.XtraGrid.GridControl()
        Me.MVProveedoresPago = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmsReimprimirRecibo = New System.Windows.Forms.ContextMenuStrip()
        Me.ReimprimirReciboToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.gboxProveedor.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProveedoresPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MVProveedoresPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsReimprimirRecibo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblTextoUltimaActualizacion)
        Me.Panel1.Controls.Add(Me.lblFechaUltimaActualización)
        Me.Panel1.Controls.Add(Me.lblTotalSeleccionados)
        Me.Panel1.Controls.Add(Me.lblClientes)
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 488)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1145, 60)
        Me.Panel1.TabIndex = 69
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(458, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(189, 39)
        Me.Label3.TabIndex = 135
        Me.Label3.Text = "Nota: Si no utiliza el filtro de Proveedor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "muestra únicamente los registros del " &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "checador del día"
        '
        'lblTextoUltimaActualizacion
        '
        Me.lblTextoUltimaActualizacion.AutoSize = True
        Me.lblTextoUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaActualizacion.Location = New System.Drawing.Point(751, 25)
        Me.lblTextoUltimaActualizacion.Name = "lblTextoUltimaActualizacion"
        Me.lblTextoUltimaActualizacion.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoUltimaActualizacion.TabIndex = 121
        Me.lblTextoUltimaActualizacion.Text = "Última actualización:"
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(870, 25)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaUltimaActualización.TabIndex = 122
        Me.lblFechaUltimaActualización.Text = "-"
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(12, 33)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalSeleccionados.TabIndex = 120
        Me.lblTotalSeleccionados.Text = "0"
        Me.lblTotalSeleccionados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(9, 15)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(79, 16)
        Me.lblClientes.TabIndex = 119
        Me.lblClientes.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.Label4)
        Me.pnlBotones.Controls.Add(Me.btnMostrar)
        Me.pnlBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(955, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(190, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(97, 41)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 72
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(143, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(144, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(49, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(52, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 70
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(101, 7)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 71
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblFinalizar
        '
        Me.lblFinalizar.AutoSize = True
        Me.lblFinalizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFinalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFinalizar.Location = New System.Drawing.Point(9, 44)
        Me.lblFinalizar.Name = "lblFinalizar"
        Me.lblFinalizar.Size = New System.Drawing.Size(47, 13)
        Me.lblFinalizar.TabIndex = 110
        Me.lblFinalizar.Text = "Entregar"
        '
        'btnAplicarPago
        '
        Me.btnAplicarPago.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAplicarPago.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAplicarPago.Image = Global.Proveedor.Vista.My.Resources.Resources.autorizar_32
        Me.btnAplicarPago.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAplicarPago.Location = New System.Drawing.Point(19, 9)
        Me.btnAplicarPago.Name = "btnAplicarPago"
        Me.btnAplicarPago.Size = New System.Drawing.Size(32, 32)
        Me.btnAplicarPago.TabIndex = 109
        Me.btnAplicarPago.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblFinalizar)
        Me.pnlHeader.Controls.Add(Me.Label14)
        Me.pnlHeader.Controls.Add(Me.btnAplicarPago)
        Me.pnlHeader.Controls.Add(Me.btnImprimir)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1145, 79)
        Me.pnlHeader.TabIndex = 70
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label14.Location = New System.Drawing.Point(62, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 26)
        Me.Label14.TabIndex = 83
        Me.Label14.Text = "Reimprimir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Recibo"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(74, 9)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 82
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(668, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(477, 79)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(150, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(233, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Entrega Pagos Proveedores"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.chboxSeleccionarTodo)
        Me.grbParametros.Controls.Add(Me.gboxProveedor)
        Me.grbParametros.Controls.Add(Me.btnUp)
        Me.grbParametros.Controls.Add(Me.btnDown)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 79)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1145, 194)
        Me.grbParametros.TabIndex = 71
        Me.grbParametros.TabStop = False
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(9, 19)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 129
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'gboxProveedor
        '
        Me.gboxProveedor.Controls.Add(Me.btnProveedor)
        Me.gboxProveedor.Controls.Add(Me.btnLimpiarProveedor)
        Me.gboxProveedor.Controls.Add(Me.Panel2)
        Me.gboxProveedor.Location = New System.Drawing.Point(6, 53)
        Me.gboxProveedor.Name = "gboxProveedor"
        Me.gboxProveedor.Size = New System.Drawing.Size(398, 135)
        Me.gboxProveedor.TabIndex = 128
        Me.gboxProveedor.TabStop = False
        Me.gboxProveedor.Text = "Proveedor"
        '
        'btnProveedor
        '
        Me.btnProveedor.Image = CType(resources.GetObject("btnProveedor.Image"), System.Drawing.Image)
        Me.btnProveedor.Location = New System.Drawing.Point(370, 13)
        Me.btnProveedor.Name = "btnProveedor"
        Me.btnProveedor.Size = New System.Drawing.Size(22, 22)
        Me.btnProveedor.TabIndex = 132
        Me.btnProveedor.UseVisualStyleBackColor = True
        '
        'btnLimpiarProveedor
        '
        Me.btnLimpiarProveedor.Image = CType(resources.GetObject("btnLimpiarProveedor.Image"), System.Drawing.Image)
        Me.btnLimpiarProveedor.Location = New System.Drawing.Point(346, 13)
        Me.btnLimpiarProveedor.Name = "btnLimpiarProveedor"
        Me.btnLimpiarProveedor.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarProveedor.TabIndex = 131
        Me.btnLimpiarProveedor.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdProveedor)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(392, 91)
        Me.Panel2.TabIndex = 2
        '
        'grdProveedor
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProveedor.DisplayLayout.Appearance = Appearance1
        Me.grdProveedor.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdProveedor.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProveedor.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdProveedor.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdProveedor.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProveedor.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdProveedor.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProveedor.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProveedor.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdProveedor.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProveedor.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProveedor.Location = New System.Drawing.Point(0, 0)
        Me.grdProveedor.Name = "grdProveedor"
        Me.grdProveedor.Size = New System.Drawing.Size(392, 91)
        Me.grdProveedor.TabIndex = 5
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.BackColor = System.Drawing.Color.White
        Me.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUp.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUp.Location = New System.Drawing.Point(1122, 8)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(20, 20)
        Me.btnUp.TabIndex = 35
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.BackColor = System.Drawing.Color.White
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(1099, 8)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 34
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'grdProveedoresPago
        '
        Me.grdProveedoresPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProveedoresPago.Location = New System.Drawing.Point(0, 273)
        Me.grdProveedoresPago.MainView = Me.MVProveedoresPago
        Me.grdProveedoresPago.Name = "grdProveedoresPago"
        Me.grdProveedoresPago.Size = New System.Drawing.Size(1145, 215)
        Me.grdProveedoresPago.TabIndex = 72
        Me.grdProveedoresPago.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MVProveedoresPago})
        '
        'MVProveedoresPago
        '
        Me.MVProveedoresPago.GridControl = Me.grdProveedoresPago
        Me.MVProveedoresPago.Name = "MVProveedoresPago"
        '
        'cmsReimprimirRecibo
        '
        Me.cmsReimprimirRecibo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReimprimirReciboToolStripMenuItem})
        Me.cmsReimprimirRecibo.Name = "cmsSalidaNaves"
        Me.cmsReimprimirRecibo.Size = New System.Drawing.Size(159, 26)
        '
        'ReimprimirReciboToolStripMenuItem
        '
        Me.ReimprimirReciboToolStripMenuItem.Name = "ReimprimirReciboToolStripMenuItem"
        Me.ReimprimirReciboToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ReimprimirReciboToolStripMenuItem.Text = "Reimprimir Recibo"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(409, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 79)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'EntregaPagosProveedorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 548)
        Me.Controls.Add(Me.grdProveedoresPago)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EntregaPagosProveedorForm"
        Me.Text = "Entrega Pagos Proveedores"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.gboxProveedor.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProveedoresPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MVProveedoresPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsReimprimirRecibo.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents bntSalir As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents grbParametros As Windows.Forms.GroupBox
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents btnUp As Windows.Forms.Button
    Friend WithEvents btnDown As Windows.Forms.Button
    Friend WithEvents btnImprimir As Windows.Forms.Button
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents gboxProveedor As Windows.Forms.GroupBox
    Friend WithEvents btnProveedor As Windows.Forms.Button
    Friend WithEvents btnLimpiarProveedor As Windows.Forms.Button
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents grdProveedor As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdProveedoresPago As DevExpress.XtraGrid.GridControl
    Friend WithEvents MVProveedoresPago As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAplicarPago As Windows.Forms.Button
    Friend WithEvents lblFinalizar As Windows.Forms.Label
    Friend WithEvents cmsReimprimirRecibo As Windows.Forms.ContextMenuStrip
    Friend WithEvents ReimprimirReciboToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents chboxSeleccionarTodo As Windows.Forms.CheckBox
    Friend WithEvents lblClientes As Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents lblTextoUltimaActualizacion As Windows.Forms.Label
    Friend WithEvents lblFechaUltimaActualización As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
