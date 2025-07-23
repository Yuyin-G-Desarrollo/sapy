<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneracionApartadosPPCP_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneracionApartadosPPCP_Form))
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlDetallesPartida = New System.Windows.Forms.Panel()
        Me.chboxMostrarDistribucionPartida = New System.Windows.Forms.CheckBox()
        Me.lblDescripcionProducto = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdDistribucionPartida = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblPartidaPedido = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdDetallesPartida = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chboxMostrarPartidasExcluidas = New System.Windows.Forms.CheckBox()
        Me.lblPedidoSICY = New System.Windows.Forms.Label()
        Me.chboxMostrarPartidasSinInventario = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTextoCheckboxAtadosDestallar = New System.Windows.Forms.Label()
        Me.lblPedidoSay = New System.Windows.Forms.Label()
        Me.lblTextoCheckboxAtadosCompletos = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chboxSeleccionarTodoAtadosPuntoDestallar = New System.Windows.Forms.CheckBox()
        Me.chboxSeleccionarTodoAtadosNormalesDestallar = New System.Windows.Forms.CheckBox()
        Me.chboxSeleccionarTodoParesDestallados = New System.Windows.Forms.CheckBox()
        Me.chboxSeleccionarTodoAtadosPuntoCompletos = New System.Windows.Forms.CheckBox()
        Me.chboxSeleccionarTodoAtadosNormalesCompletos = New System.Windows.Forms.CheckBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnGuardarCambioTotalTallas = New System.Windows.Forms.Button()
        Me.lblTextoGuardarCambioTotalTallas = New System.Windows.Forms.Label()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblCantidadPartidasPorApartar = New System.Windows.Forms.Label()
        Me.lblTotalParesApartadosPorConfirmar = New System.Windows.Forms.Label()
        Me.lblCantidadPendientesPorConfirmar = New System.Windows.Forms.Label()
        Me.lblTotalTiempos = New System.Windows.Forms.Label()
        Me.lblTiempoPartidasPorApartar = New System.Windows.Forms.Label()
        Me.lblTextoTiempoPartidasApartar = New System.Windows.Forms.Label()
        Me.lblTiempoApartadosPorConfirmar = New System.Windows.Forms.Label()
        Me.lblTextoTiempoPendientesPorConfirmar = New System.Windows.Forms.Label()
        Me.lblValorApartadosGenerados = New System.Windows.Forms.Label()
        Me.lblTextoApartadosGenerados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpAcotaciones = New System.Windows.Forms.GroupBox()
        Me.lblModificacionOrden = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblModificacionPares = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlApartadoDisponible = New System.Windows.Forms.Panel()
        Me.lblAPPartidaCompleta = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlPartidaApartadoCompleta = New System.Windows.Forms.Panel()
        Me.lblAPPartidaParcial = New System.Windows.Forms.Label()
        Me.pnlPartidaModificada = New System.Windows.Forms.Panel()
        Me.lblModificacionDistribucion = New System.Windows.Forms.Label()
        Me.lblClienteBloqueado3Meses = New System.Windows.Forms.Label()
        Me.lblTextoRespaldandoInventario = New System.Windows.Forms.Label()
        Me.lblHoraRespaldandoInventario = New System.Windows.Forms.Label()
        Me.lblFechaUltimoRespaldoInventario = New System.Windows.Forms.Label()
        Me.lblTextoUltimoRespaldoInventario = New System.Windows.Forms.Label()
        Me.lblFechaUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardarApartado = New System.Windows.Forms.Button()
        Me.lblGuardarApartado = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.lblTextoBotonActualizarDistribucion = New System.Windows.Forms.Label()
        Me.btnActualizarDistribucion = New System.Windows.Forms.Button()
        Me.lblTextoReordenar = New System.Windows.Forms.Label()
        Me.btnReordenar = New System.Windows.Forms.Button()
        Me.btnGenerarDistribucion = New System.Windows.Forms.Button()
        Me.lblGenerarDistribucion = New System.Windows.Forms.Label()
        Me.btnVerDisponibilidad = New System.Windows.Forms.Button()
        Me.lblVerDisponibilidad = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTextoResumen = New System.Windows.Forms.Label()
        Me.btnPrioridadClientes = New System.Windows.Forms.Button()
        Me.btnResumen = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grdDatosGenerarApartados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmsOpcionesGenerales = New System.Windows.Forms.ContextMenuStrip()
        Me.tsmiAgregarSeleccionGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiQuitarSeleccionGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiIncluirSeleccionGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExcluirSeleccionGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAgregarAtadosNormales = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiQuitarSeleccionAtadosNormales = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAgregarSeleccionAtadosPunto = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiQuitarSeleccionAtadosPunto = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAgregarSelecciónDestallados = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiQuitarSelecciónDestallados = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAgregarSelecciónDestallarNormales = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiQuitarSelecciónDestallarNormales = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAgregarSelecciónDestallarPunto = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiQuitarSelecciónDestallarPunto = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlDetallesPartida.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdDistribucionPartida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.grdDetallesPartida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.grpAcotaciones.SuspendLayout()
        Me.pnlApartadoDisponible.SuspendLayout()
        Me.pnlPartidaApartadoCompleta.SuspendLayout()
        Me.pnlPartidaModificada.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.grdDatosGenerarApartados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsOpcionesGenerales.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDetallesPartida
        '
        Me.pnlDetallesPartida.Controls.Add(Me.chboxMostrarDistribucionPartida)
        Me.pnlDetallesPartida.Controls.Add(Me.lblDescripcionProducto)
        Me.pnlDetallesPartida.Controls.Add(Me.Panel3)
        Me.pnlDetallesPartida.Controls.Add(Me.lblPartidaPedido)
        Me.pnlDetallesPartida.Controls.Add(Me.Panel4)
        Me.pnlDetallesPartida.Controls.Add(Me.Label15)
        Me.pnlDetallesPartida.Controls.Add(Me.chboxMostrarPartidasExcluidas)
        Me.pnlDetallesPartida.Controls.Add(Me.lblPedidoSICY)
        Me.pnlDetallesPartida.Controls.Add(Me.chboxMostrarPartidasSinInventario)
        Me.pnlDetallesPartida.Controls.Add(Me.Label14)
        Me.pnlDetallesPartida.Controls.Add(Me.lblTextoCheckboxAtadosDestallar)
        Me.pnlDetallesPartida.Controls.Add(Me.lblPedidoSay)
        Me.pnlDetallesPartida.Controls.Add(Me.lblTextoCheckboxAtadosCompletos)
        Me.pnlDetallesPartida.Controls.Add(Me.Label13)
        Me.pnlDetallesPartida.Controls.Add(Me.chboxSeleccionarTodoAtadosPuntoDestallar)
        Me.pnlDetallesPartida.Controls.Add(Me.chboxSeleccionarTodoAtadosNormalesDestallar)
        Me.pnlDetallesPartida.Controls.Add(Me.chboxSeleccionarTodoParesDestallados)
        Me.pnlDetallesPartida.Controls.Add(Me.chboxSeleccionarTodoAtadosPuntoCompletos)
        Me.pnlDetallesPartida.Controls.Add(Me.chboxSeleccionarTodoAtadosNormalesCompletos)
        Me.pnlDetallesPartida.Controls.Add(Me.btnArriba)
        Me.pnlDetallesPartida.Controls.Add(Me.btnAbajo)
        Me.pnlDetallesPartida.Controls.Add(Me.btnGuardarCambioTotalTallas)
        Me.pnlDetallesPartida.Controls.Add(Me.lblTextoGuardarCambioTotalTallas)
        Me.pnlDetallesPartida.Controls.Add(Me.chboxSeleccionarTodo)
        Me.pnlDetallesPartida.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetallesPartida.Location = New System.Drawing.Point(0, 59)
        Me.pnlDetallesPartida.Name = "pnlDetallesPartida"
        Me.pnlDetallesPartida.Size = New System.Drawing.Size(1194, 216)
        Me.pnlDetallesPartida.TabIndex = 50
        '
        'chboxMostrarDistribucionPartida
        '
        Me.chboxMostrarDistribucionPartida.AutoSize = True
        Me.chboxMostrarDistribucionPartida.Location = New System.Drawing.Point(8, 193)
        Me.chboxMostrarDistribucionPartida.Name = "chboxMostrarDistribucionPartida"
        Me.chboxMostrarDistribucionPartida.Size = New System.Drawing.Size(170, 17)
        Me.chboxMostrarDistribucionPartida.TabIndex = 86
        Me.chboxMostrarDistribucionPartida.Text = "Mostrar distribución por partida"
        Me.chboxMostrarDistribucionPartida.UseVisualStyleBackColor = True
        Me.chboxMostrarDistribucionPartida.Visible = False
        '
        'lblDescripcionProducto
        '
        Me.lblDescripcionProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionProducto.ForeColor = System.Drawing.Color.Black
        Me.lblDescripcionProducto.Location = New System.Drawing.Point(9, 75)
        Me.lblDescripcionProducto.Name = "lblDescripcionProducto"
        Me.lblDescripcionProducto.Size = New System.Drawing.Size(176, 57)
        Me.lblDescripcionProducto.TabIndex = 85
        Me.lblDescripcionProducto.Text = "-"
        Me.lblDescripcionProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdDistribucionPartida)
        Me.Panel3.Location = New System.Drawing.Point(767, 28)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(470, 182)
        Me.Panel3.TabIndex = 74
        '
        'grdDistribucionPartida
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDistribucionPartida.DisplayLayout.Appearance = Appearance1
        Me.grdDistribucionPartida.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdDistribucionPartida.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDistribucionPartida.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDistribucionPartida.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDistribucionPartida.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDistribucionPartida.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdDistribucionPartida.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDistribucionPartida.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDistribucionPartida.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDistribucionPartida.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDistribucionPartida.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDistribucionPartida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDistribucionPartida.Location = New System.Drawing.Point(0, 0)
        Me.grdDistribucionPartida.Name = "grdDistribucionPartida"
        Me.grdDistribucionPartida.Size = New System.Drawing.Size(470, 182)
        Me.grdDistribucionPartida.TabIndex = 52
        Me.grdDistribucionPartida.Visible = False
        '
        'lblPartidaPedido
        '
        Me.lblPartidaPedido.AutoSize = True
        Me.lblPartidaPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartidaPedido.ForeColor = System.Drawing.Color.Black
        Me.lblPartidaPedido.Location = New System.Drawing.Point(89, 59)
        Me.lblPartidaPedido.Name = "lblPartidaPedido"
        Me.lblPartidaPedido.Size = New System.Drawing.Size(13, 13)
        Me.lblPartidaPedido.TabIndex = 83
        Me.lblPartidaPedido.Text = "0"
        Me.lblPartidaPedido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdDetallesPartida)
        Me.Panel4.Location = New System.Drawing.Point(191, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(570, 182)
        Me.Panel4.TabIndex = 74
        '
        'grdDetallesPartida
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetallesPartida.DisplayLayout.Appearance = Appearance3
        Me.grdDetallesPartida.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdDetallesPartida.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdDetallesPartida.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.grdDetallesPartida.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdDetallesPartida.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDetallesPartida.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDetallesPartida.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDetallesPartida.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDetallesPartida.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdDetallesPartida.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDetallesPartida.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetallesPartida.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdDetallesPartida.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDetallesPartida.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.grdDetallesPartida.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDetallesPartida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDetallesPartida.Location = New System.Drawing.Point(0, 0)
        Me.grdDetallesPartida.Name = "grdDetallesPartida"
        Me.grdDetallesPartida.Size = New System.Drawing.Size(570, 182)
        Me.grdDetallesPartida.TabIndex = 52
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(9, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "Partida Pedido:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chboxMostrarPartidasExcluidas
        '
        Me.chboxMostrarPartidasExcluidas.AutoSize = True
        Me.chboxMostrarPartidasExcluidas.Checked = True
        Me.chboxMostrarPartidasExcluidas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxMostrarPartidasExcluidas.Location = New System.Drawing.Point(154, 4)
        Me.chboxMostrarPartidasExcluidas.Name = "chboxMostrarPartidasExcluidas"
        Me.chboxMostrarPartidasExcluidas.Size = New System.Drawing.Size(148, 17)
        Me.chboxMostrarPartidasExcluidas.TabIndex = 72
        Me.chboxMostrarPartidasExcluidas.Text = "Mostrar partidas excluidas"
        Me.chboxMostrarPartidasExcluidas.UseVisualStyleBackColor = True
        '
        'lblPedidoSICY
        '
        Me.lblPedidoSICY.AutoSize = True
        Me.lblPedidoSICY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSICY.ForeColor = System.Drawing.Color.Black
        Me.lblPedidoSICY.Location = New System.Drawing.Point(89, 46)
        Me.lblPedidoSICY.Name = "lblPedidoSICY"
        Me.lblPedidoSICY.Size = New System.Drawing.Size(13, 13)
        Me.lblPedidoSICY.TabIndex = 81
        Me.lblPedidoSICY.Text = "0"
        Me.lblPedidoSICY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chboxMostrarPartidasSinInventario
        '
        Me.chboxMostrarPartidasSinInventario.AutoSize = True
        Me.chboxMostrarPartidasSinInventario.Checked = True
        Me.chboxMostrarPartidasSinInventario.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxMostrarPartidasSinInventario.Location = New System.Drawing.Point(308, 5)
        Me.chboxMostrarPartidasSinInventario.Name = "chboxMostrarPartidasSinInventario"
        Me.chboxMostrarPartidasSinInventario.Size = New System.Drawing.Size(216, 17)
        Me.chboxMostrarPartidasSinInventario.TabIndex = 72
        Me.chboxMostrarPartidasSinInventario.Text = "Mostrar partidas sin inventario disponible"
        Me.chboxMostrarPartidasSinInventario.UseVisualStyleBackColor = True
        Me.chboxMostrarPartidasSinInventario.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(9, 44)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Pedido SICY:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoCheckboxAtadosDestallar
        '
        Me.lblTextoCheckboxAtadosDestallar.AutoSize = True
        Me.lblTextoCheckboxAtadosDestallar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCheckboxAtadosDestallar.ForeColor = System.Drawing.Color.Black
        Me.lblTextoCheckboxAtadosDestallar.Location = New System.Drawing.Point(891, 5)
        Me.lblTextoCheckboxAtadosDestallar.Name = "lblTextoCheckboxAtadosDestallar"
        Me.lblTextoCheckboxAtadosDestallar.Size = New System.Drawing.Size(103, 13)
        Me.lblTextoCheckboxAtadosDestallar.TabIndex = 67
        Me.lblTextoCheckboxAtadosDestallar.Text = "Atados Por Destallar"
        Me.lblTextoCheckboxAtadosDestallar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoCheckboxAtadosDestallar.Visible = False
        '
        'lblPedidoSay
        '
        Me.lblPedidoSay.AutoSize = True
        Me.lblPedidoSay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoSay.ForeColor = System.Drawing.Color.Black
        Me.lblPedidoSay.Location = New System.Drawing.Point(89, 28)
        Me.lblPedidoSay.Name = "lblPedidoSay"
        Me.lblPedidoSay.Size = New System.Drawing.Size(13, 13)
        Me.lblPedidoSay.TabIndex = 79
        Me.lblPedidoSay.Text = "0"
        Me.lblPedidoSay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoCheckboxAtadosCompletos
        '
        Me.lblTextoCheckboxAtadosCompletos.AutoSize = True
        Me.lblTextoCheckboxAtadosCompletos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCheckboxAtadosCompletos.ForeColor = System.Drawing.Color.Black
        Me.lblTextoCheckboxAtadosCompletos.Location = New System.Drawing.Point(613, 5)
        Me.lblTextoCheckboxAtadosCompletos.Name = "lblTextoCheckboxAtadosCompletos"
        Me.lblTextoCheckboxAtadosCompletos.Size = New System.Drawing.Size(92, 13)
        Me.lblTextoCheckboxAtadosCompletos.TabIndex = 66
        Me.lblTextoCheckboxAtadosCompletos.Text = "Atados Completos"
        Me.lblTextoCheckboxAtadosCompletos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoCheckboxAtadosCompletos.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(9, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Pedido SAY:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chboxSeleccionarTodoAtadosPuntoDestallar
        '
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.AutoSize = True
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.Checked = True
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.Location = New System.Drawing.Point(1059, 5)
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.Name = "chboxSeleccionarTodoAtadosPuntoDestallar"
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.Size = New System.Drawing.Size(58, 17)
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.TabIndex = 65
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.Text = "A-Punt"
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.UseVisualStyleBackColor = True
        Me.chboxSeleccionarTodoAtadosPuntoDestallar.Visible = False
        '
        'chboxSeleccionarTodoAtadosNormalesDestallar
        '
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.AutoSize = True
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.Checked = True
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.Location = New System.Drawing.Point(1000, 5)
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.Name = "chboxSeleccionarTodoAtadosNormalesDestallar"
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.Size = New System.Drawing.Size(61, 17)
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.TabIndex = 64
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.Text = "A-Norm"
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.UseVisualStyleBackColor = True
        Me.chboxSeleccionarTodoAtadosNormalesDestallar.Visible = False
        '
        'chboxSeleccionarTodoParesDestallados
        '
        Me.chboxSeleccionarTodoParesDestallados.AutoSize = True
        Me.chboxSeleccionarTodoParesDestallados.Checked = True
        Me.chboxSeleccionarTodoParesDestallados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSeleccionarTodoParesDestallados.Location = New System.Drawing.Point(802, 5)
        Me.chboxSeleccionarTodoParesDestallados.Name = "chboxSeleccionarTodoParesDestallados"
        Me.chboxSeleccionarTodoParesDestallados.Size = New System.Drawing.Size(69, 17)
        Me.chboxSeleccionarTodoParesDestallados.TabIndex = 63
        Me.chboxSeleccionarTodoParesDestallados.Text = "Prs_Dest"
        Me.chboxSeleccionarTodoParesDestallados.UseVisualStyleBackColor = True
        Me.chboxSeleccionarTodoParesDestallados.Visible = False
        '
        'chboxSeleccionarTodoAtadosPuntoCompletos
        '
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.AutoSize = True
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.Checked = True
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.Location = New System.Drawing.Point(758, 5)
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.Name = "chboxSeleccionarTodoAtadosPuntoCompletos"
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.Size = New System.Drawing.Size(48, 17)
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.TabIndex = 62
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.Text = "Punt"
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.UseVisualStyleBackColor = True
        Me.chboxSeleccionarTodoAtadosPuntoCompletos.Visible = False
        '
        'chboxSeleccionarTodoAtadosNormalesCompletos
        '
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.AutoSize = True
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.Checked = True
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.Location = New System.Drawing.Point(711, 5)
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.Name = "chboxSeleccionarTodoAtadosNormalesCompletos"
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.Size = New System.Drawing.Size(51, 17)
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.TabIndex = 61
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.Text = "Norm"
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.UseVisualStyleBackColor = True
        Me.chboxSeleccionarTodoAtadosNormalesCompletos.Visible = False
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1136, 5)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 60
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(1162, 5)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 59
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnGuardarCambioTotalTallas
        '
        Me.btnGuardarCambioTotalTallas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardarCambioTotalTallas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardarCambioTotalTallas.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardarCambioTotalTallas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardarCambioTotalTallas.Location = New System.Drawing.Point(70, 135)
        Me.btnGuardarCambioTotalTallas.Name = "btnGuardarCambioTotalTallas"
        Me.btnGuardarCambioTotalTallas.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarCambioTotalTallas.TabIndex = 58
        Me.btnGuardarCambioTotalTallas.UseVisualStyleBackColor = True
        Me.btnGuardarCambioTotalTallas.Visible = False
        '
        'lblTextoGuardarCambioTotalTallas
        '
        Me.lblTextoGuardarCambioTotalTallas.AutoSize = True
        Me.lblTextoGuardarCambioTotalTallas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoGuardarCambioTotalTallas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoGuardarCambioTotalTallas.Location = New System.Drawing.Point(37, 169)
        Me.lblTextoGuardarCambioTotalTallas.Name = "lblTextoGuardarCambioTotalTallas"
        Me.lblTextoGuardarCambioTotalTallas.Size = New System.Drawing.Size(101, 26)
        Me.lblTextoGuardarCambioTotalTallas.TabIndex = 57
        Me.lblTextoGuardarCambioTotalTallas.Text = "Guardar Cambio de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pares Por Talla"
        Me.lblTextoGuardarCambioTotalTallas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoGuardarCambioTotalTallas.Visible = False
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Checked = True
        Me.chboxSeleccionarTodo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(3, 3)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 56
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblCantidadPartidasPorApartar)
        Me.pnlPie.Controls.Add(Me.lblTotalParesApartadosPorConfirmar)
        Me.pnlPie.Controls.Add(Me.lblCantidadPendientesPorConfirmar)
        Me.pnlPie.Controls.Add(Me.lblTotalTiempos)
        Me.pnlPie.Controls.Add(Me.lblTiempoPartidasPorApartar)
        Me.pnlPie.Controls.Add(Me.lblTextoTiempoPartidasApartar)
        Me.pnlPie.Controls.Add(Me.lblTiempoApartadosPorConfirmar)
        Me.pnlPie.Controls.Add(Me.lblTextoTiempoPendientesPorConfirmar)
        Me.pnlPie.Controls.Add(Me.lblValorApartadosGenerados)
        Me.pnlPie.Controls.Add(Me.lblTextoApartadosGenerados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.grpAcotaciones)
        Me.pnlPie.Controls.Add(Me.lblTextoRespaldandoInventario)
        Me.pnlPie.Controls.Add(Me.lblHoraRespaldandoInventario)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimoRespaldoInventario)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimoRespaldoInventario)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 467)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1194, 60)
        Me.pnlPie.TabIndex = 49
        '
        'lblCantidadPartidasPorApartar
        '
        Me.lblCantidadPartidasPorApartar.AutoSize = True
        Me.lblCantidadPartidasPorApartar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadPartidasPorApartar.ForeColor = System.Drawing.Color.Black
        Me.lblCantidadPartidasPorApartar.Location = New System.Drawing.Point(422, 19)
        Me.lblCantidadPartidasPorApartar.MinimumSize = New System.Drawing.Size(31, 13)
        Me.lblCantidadPartidasPorApartar.Name = "lblCantidadPartidasPorApartar"
        Me.lblCantidadPartidasPorApartar.Size = New System.Drawing.Size(31, 13)
        Me.lblCantidadPartidasPorApartar.TabIndex = 91
        Me.lblCantidadPartidasPorApartar.Text = "0"
        Me.lblCantidadPartidasPorApartar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalParesApartadosPorConfirmar
        '
        Me.lblTotalParesApartadosPorConfirmar.AutoSize = True
        Me.lblTotalParesApartadosPorConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalParesApartadosPorConfirmar.ForeColor = System.Drawing.Color.Black
        Me.lblTotalParesApartadosPorConfirmar.Location = New System.Drawing.Point(459, 3)
        Me.lblTotalParesApartadosPorConfirmar.Name = "lblTotalParesApartadosPorConfirmar"
        Me.lblTotalParesApartadosPorConfirmar.Size = New System.Drawing.Size(13, 13)
        Me.lblTotalParesApartadosPorConfirmar.TabIndex = 90
        Me.lblTotalParesApartadosPorConfirmar.Text = "0"
        Me.lblTotalParesApartadosPorConfirmar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblCantidadPendientesPorConfirmar
        '
        Me.lblCantidadPendientesPorConfirmar.AutoSize = True
        Me.lblCantidadPendientesPorConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadPendientesPorConfirmar.ForeColor = System.Drawing.Color.Black
        Me.lblCantidadPendientesPorConfirmar.Location = New System.Drawing.Point(422, 3)
        Me.lblCantidadPendientesPorConfirmar.MinimumSize = New System.Drawing.Size(31, 13)
        Me.lblCantidadPendientesPorConfirmar.Name = "lblCantidadPendientesPorConfirmar"
        Me.lblCantidadPendientesPorConfirmar.Size = New System.Drawing.Size(31, 13)
        Me.lblCantidadPendientesPorConfirmar.TabIndex = 90
        Me.lblCantidadPendientesPorConfirmar.Text = "0"
        Me.lblCantidadPendientesPorConfirmar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalTiempos
        '
        Me.lblTotalTiempos.AutoSize = True
        Me.lblTotalTiempos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTiempos.ForeColor = System.Drawing.Color.Black
        Me.lblTotalTiempos.Location = New System.Drawing.Point(540, 36)
        Me.lblTotalTiempos.MinimumSize = New System.Drawing.Size(45, 13)
        Me.lblTotalTiempos.Name = "lblTotalTiempos"
        Me.lblTotalTiempos.Size = New System.Drawing.Size(45, 13)
        Me.lblTotalTiempos.TabIndex = 89
        Me.lblTotalTiempos.Text = "(0.0 m)"
        Me.lblTotalTiempos.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTiempoPartidasPorApartar
        '
        Me.lblTiempoPartidasPorApartar.AutoSize = True
        Me.lblTiempoPartidasPorApartar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiempoPartidasPorApartar.ForeColor = System.Drawing.Color.Black
        Me.lblTiempoPartidasPorApartar.Location = New System.Drawing.Point(538, 19)
        Me.lblTiempoPartidasPorApartar.MinimumSize = New System.Drawing.Size(45, 13)
        Me.lblTiempoPartidasPorApartar.Name = "lblTiempoPartidasPorApartar"
        Me.lblTiempoPartidasPorApartar.Size = New System.Drawing.Size(45, 13)
        Me.lblTiempoPartidasPorApartar.TabIndex = 87
        Me.lblTiempoPartidasPorApartar.Text = "(0.0 m)"
        Me.lblTiempoPartidasPorApartar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTextoTiempoPartidasApartar
        '
        Me.lblTextoTiempoPartidasApartar.AutoSize = True
        Me.lblTextoTiempoPartidasApartar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoTiempoPartidasApartar.ForeColor = System.Drawing.Color.Black
        Me.lblTextoTiempoPartidasApartar.Location = New System.Drawing.Point(229, 19)
        Me.lblTextoTiempoPartidasApartar.Name = "lblTextoTiempoPartidasApartar"
        Me.lblTextoTiempoPartidasApartar.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoTiempoPartidasApartar.TabIndex = 88
        Me.lblTextoTiempoPartidasApartar.Text = "Partidas Por Apartar:"
        Me.lblTextoTiempoPartidasApartar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTiempoApartadosPorConfirmar
        '
        Me.lblTiempoApartadosPorConfirmar.AutoSize = True
        Me.lblTiempoApartadosPorConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiempoApartadosPorConfirmar.ForeColor = System.Drawing.Color.Black
        Me.lblTiempoApartadosPorConfirmar.Location = New System.Drawing.Point(538, 3)
        Me.lblTiempoApartadosPorConfirmar.MinimumSize = New System.Drawing.Size(45, 13)
        Me.lblTiempoApartadosPorConfirmar.Name = "lblTiempoApartadosPorConfirmar"
        Me.lblTiempoApartadosPorConfirmar.Size = New System.Drawing.Size(45, 13)
        Me.lblTiempoApartadosPorConfirmar.TabIndex = 85
        Me.lblTiempoApartadosPorConfirmar.Text = "(0.0 m)"
        Me.lblTiempoApartadosPorConfirmar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTextoTiempoPendientesPorConfirmar
        '
        Me.lblTextoTiempoPendientesPorConfirmar.AutoSize = True
        Me.lblTextoTiempoPendientesPorConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoTiempoPendientesPorConfirmar.ForeColor = System.Drawing.Color.Black
        Me.lblTextoTiempoPendientesPorConfirmar.Location = New System.Drawing.Point(230, 3)
        Me.lblTextoTiempoPendientesPorConfirmar.Name = "lblTextoTiempoPendientesPorConfirmar"
        Me.lblTextoTiempoPendientesPorConfirmar.Size = New System.Drawing.Size(180, 13)
        Me.lblTextoTiempoPendientesPorConfirmar.TabIndex = 86
        Me.lblTextoTiempoPendientesPorConfirmar.Text = "Apartados Pendientes Por Confirmar:"
        Me.lblTextoTiempoPendientesPorConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblValorApartadosGenerados
        '
        Me.lblValorApartadosGenerados.AutoSize = True
        Me.lblValorApartadosGenerados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorApartadosGenerados.ForeColor = System.Drawing.Color.Black
        Me.lblValorApartadosGenerados.Location = New System.Drawing.Point(1063, 24)
        Me.lblValorApartadosGenerados.Name = "lblValorApartadosGenerados"
        Me.lblValorApartadosGenerados.Size = New System.Drawing.Size(10, 13)
        Me.lblValorApartadosGenerados.TabIndex = 84
        Me.lblValorApartadosGenerados.Text = "-"
        Me.lblValorApartadosGenerados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblValorApartadosGenerados.Visible = False
        '
        'lblTextoApartadosGenerados
        '
        Me.lblTextoApartadosGenerados.AutoSize = True
        Me.lblTextoApartadosGenerados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoApartadosGenerados.ForeColor = System.Drawing.Color.Black
        Me.lblTextoApartadosGenerados.Location = New System.Drawing.Point(954, 24)
        Me.lblTextoApartadosGenerados.Name = "lblTextoApartadosGenerados"
        Me.lblTextoApartadosGenerados.Size = New System.Drawing.Size(111, 13)
        Me.lblTextoApartadosGenerados.TabIndex = 83
        Me.lblTextoApartadosGenerados.Text = "Apartados generados:"
        Me.lblTextoApartadosGenerados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoApartadosGenerados.Visible = False
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label1.Location = New System.Drawing.Point(548, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 0)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "B3M - Cliente Bloqueado en los últimos 3 meses"
        '
        'grpAcotaciones
        '
        Me.grpAcotaciones.Controls.Add(Me.lblModificacionOrden)
        Me.grpAcotaciones.Controls.Add(Me.Panel2)
        Me.grpAcotaciones.Controls.Add(Me.Label24)
        Me.grpAcotaciones.Controls.Add(Me.lblModificacionPares)
        Me.grpAcotaciones.Controls.Add(Me.Label19)
        Me.grpAcotaciones.Controls.Add(Me.Panel1)
        Me.grpAcotaciones.Controls.Add(Me.Label7)
        Me.grpAcotaciones.Controls.Add(Me.Label6)
        Me.grpAcotaciones.Controls.Add(Me.pnlApartadoDisponible)
        Me.grpAcotaciones.Controls.Add(Me.Label5)
        Me.grpAcotaciones.Controls.Add(Me.pnlPartidaApartadoCompleta)
        Me.grpAcotaciones.Controls.Add(Me.pnlPartidaModificada)
        Me.grpAcotaciones.Controls.Add(Me.lblClienteBloqueado3Meses)
        Me.grpAcotaciones.Location = New System.Drawing.Point(620, 0)
        Me.grpAcotaciones.Name = "grpAcotaciones"
        Me.grpAcotaciones.Size = New System.Drawing.Size(519, 60)
        Me.grpAcotaciones.TabIndex = 79
        Me.grpAcotaciones.TabStop = False
        Me.grpAcotaciones.Visible = False
        '
        'lblModificacionOrden
        '
        Me.lblModificacionOrden.AutoSize = True
        Me.lblModificacionOrden.BackColor = System.Drawing.Color.SlateBlue
        Me.lblModificacionOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModificacionOrden.ForeColor = System.Drawing.Color.Black
        Me.lblModificacionOrden.Location = New System.Drawing.Point(264, 8)
        Me.lblModificacionOrden.Name = "lblModificacionOrden"
        Me.lblModificacionOrden.Size = New System.Drawing.Size(18, 13)
        Me.lblModificacionOrden.TabIndex = 87
        Me.lblModificacionOrden.Text = "Or"
        Me.lblModificacionOrden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateBlue
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(258, 8)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(27, 13)
        Me.Panel2.TabIndex = 89
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(296, 7)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(208, 13)
        Me.Label24.TabIndex = 88
        Me.Label24.Text = "(M) - Partida Modificada (Cambio de orden)"
        '
        'lblModificacionPares
        '
        Me.lblModificacionPares.AutoSize = True
        Me.lblModificacionPares.BackColor = System.Drawing.Color.Gold
        Me.lblModificacionPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModificacionPares.ForeColor = System.Drawing.Color.Black
        Me.lblModificacionPares.Location = New System.Drawing.Point(261, 25)
        Me.lblModificacionPares.Name = "lblModificacionPares"
        Me.lblModificacionPares.Size = New System.Drawing.Size(22, 13)
        Me.lblModificacionPares.TabIndex = 86
        Me.lblModificacionPares.Text = "Prs"
        Me.lblModificacionPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(296, 24)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(201, 13)
        Me.Label19.TabIndex = 85
        Me.Label19.Text = "(M2) - Partida Modificada (Pares por talla)"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(258, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(27, 15)
        Me.Panel1.TabIndex = 84
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(296, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(226, 13)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "(M3) - Partida Modificada (Quitar atados-pares)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(129, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "(C) - Partida Completa"
        '
        'pnlApartadoDisponible
        '
        Me.pnlApartadoDisponible.BackColor = System.Drawing.Color.PaleGreen
        Me.pnlApartadoDisponible.Controls.Add(Me.lblAPPartidaCompleta)
        Me.pnlApartadoDisponible.ForeColor = System.Drawing.Color.Black
        Me.pnlApartadoDisponible.Location = New System.Drawing.Point(112, 25)
        Me.pnlApartadoDisponible.Name = "pnlApartadoDisponible"
        Me.pnlApartadoDisponible.Size = New System.Drawing.Size(15, 15)
        Me.pnlApartadoDisponible.TabIndex = 82
        '
        'lblAPPartidaCompleta
        '
        Me.lblAPPartidaCompleta.AutoSize = True
        Me.lblAPPartidaCompleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAPPartidaCompleta.ForeColor = System.Drawing.Color.Black
        Me.lblAPPartidaCompleta.Location = New System.Drawing.Point(1, 0)
        Me.lblAPPartidaCompleta.Name = "lblAPPartidaCompleta"
        Me.lblAPPartidaCompleta.Size = New System.Drawing.Size(14, 13)
        Me.lblAPPartidaCompleta.TabIndex = 66
        Me.lblAPPartidaCompleta.Text = "C"
        Me.lblAPPartidaCompleta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(129, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "(P) - Partida Parcial"
        '
        'pnlPartidaApartadoCompleta
        '
        Me.pnlPartidaApartadoCompleta.BackColor = System.Drawing.Color.RoyalBlue
        Me.pnlPartidaApartadoCompleta.Controls.Add(Me.lblAPPartidaParcial)
        Me.pnlPartidaApartadoCompleta.ForeColor = System.Drawing.Color.Black
        Me.pnlPartidaApartadoCompleta.Location = New System.Drawing.Point(112, 42)
        Me.pnlPartidaApartadoCompleta.Name = "pnlPartidaApartadoCompleta"
        Me.pnlPartidaApartadoCompleta.Size = New System.Drawing.Size(15, 15)
        Me.pnlPartidaApartadoCompleta.TabIndex = 80
        '
        'lblAPPartidaParcial
        '
        Me.lblAPPartidaParcial.AutoSize = True
        Me.lblAPPartidaParcial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAPPartidaParcial.ForeColor = System.Drawing.Color.Black
        Me.lblAPPartidaParcial.Location = New System.Drawing.Point(1, 0)
        Me.lblAPPartidaParcial.Name = "lblAPPartidaParcial"
        Me.lblAPPartidaParcial.Size = New System.Drawing.Size(14, 13)
        Me.lblAPPartidaParcial.TabIndex = 67
        Me.lblAPPartidaParcial.Text = "P"
        Me.lblAPPartidaParcial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPartidaModificada
        '
        Me.pnlPartidaModificada.BackColor = System.Drawing.Color.IndianRed
        Me.pnlPartidaModificada.Controls.Add(Me.lblModificacionDistribucion)
        Me.pnlPartidaModificada.ForeColor = System.Drawing.Color.Black
        Me.pnlPartidaModificada.Location = New System.Drawing.Point(258, 43)
        Me.pnlPartidaModificada.Name = "pnlPartidaModificada"
        Me.pnlPartidaModificada.Size = New System.Drawing.Size(27, 13)
        Me.pnlPartidaModificada.TabIndex = 78
        '
        'lblModificacionDistribucion
        '
        Me.lblModificacionDistribucion.AutoSize = True
        Me.lblModificacionDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModificacionDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblModificacionDistribucion.Location = New System.Drawing.Point(7, 1)
        Me.lblModificacionDistribucion.Name = "lblModificacionDistribucion"
        Me.lblModificacionDistribucion.Size = New System.Drawing.Size(14, 13)
        Me.lblModificacionDistribucion.TabIndex = 68
        Me.lblModificacionDistribucion.Text = "X"
        Me.lblModificacionDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClienteBloqueado3Meses
        '
        Me.lblClienteBloqueado3Meses.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblClienteBloqueado3Meses.Location = New System.Drawing.Point(8, 7)
        Me.lblClienteBloqueado3Meses.Name = "lblClienteBloqueado3Meses"
        Me.lblClienteBloqueado3Meses.Size = New System.Drawing.Size(244, 15)
        Me.lblClienteBloqueado3Meses.TabIndex = 77
        Me.lblClienteBloqueado3Meses.Text = "B3M - Cliente Bloqueado en los últimos 3 meses"
        '
        'lblTextoRespaldandoInventario
        '
        Me.lblTextoRespaldandoInventario.AutoSize = True
        Me.lblTextoRespaldandoInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoRespaldandoInventario.ForeColor = System.Drawing.Color.Black
        Me.lblTextoRespaldandoInventario.Location = New System.Drawing.Point(271, 22)
        Me.lblTextoRespaldandoInventario.Name = "lblTextoRespaldandoInventario"
        Me.lblTextoRespaldandoInventario.Size = New System.Drawing.Size(129, 13)
        Me.lblTextoRespaldandoInventario.TabIndex = 72
        Me.lblTextoRespaldandoInventario.Text = "Respaldando Inventario..."
        Me.lblTextoRespaldandoInventario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoRespaldandoInventario.Visible = False
        '
        'lblHoraRespaldandoInventario
        '
        Me.lblHoraRespaldandoInventario.AutoSize = True
        Me.lblHoraRespaldandoInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraRespaldandoInventario.ForeColor = System.Drawing.Color.Black
        Me.lblHoraRespaldandoInventario.Location = New System.Drawing.Point(127, 22)
        Me.lblHoraRespaldandoInventario.Name = "lblHoraRespaldandoInventario"
        Me.lblHoraRespaldandoInventario.Size = New System.Drawing.Size(120, 13)
        Me.lblHoraRespaldandoInventario.TabIndex = 73
        Me.lblHoraRespaldandoInventario.Text = "(24/05/2016 01:52 PM)"
        Me.lblHoraRespaldandoInventario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblHoraRespaldandoInventario.Visible = False
        '
        'lblFechaUltimoRespaldoInventario
        '
        Me.lblFechaUltimoRespaldoInventario.AutoSize = True
        Me.lblFechaUltimoRespaldoInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimoRespaldoInventario.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimoRespaldoInventario.Location = New System.Drawing.Point(264, 13)
        Me.lblFechaUltimoRespaldoInventario.Name = "lblFechaUltimoRespaldoInventario"
        Me.lblFechaUltimoRespaldoInventario.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaUltimoRespaldoInventario.TabIndex = 71
        Me.lblFechaUltimoRespaldoInventario.Text = "24/05/2016 01:52 PM"
        Me.lblFechaUltimoRespaldoInventario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFechaUltimoRespaldoInventario.Visible = False
        '
        'lblTextoUltimoRespaldoInventario
        '
        Me.lblTextoUltimoRespaldoInventario.AutoSize = True
        Me.lblTextoUltimoRespaldoInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimoRespaldoInventario.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimoRespaldoInventario.Location = New System.Drawing.Point(132, 13)
        Me.lblTextoUltimoRespaldoInventario.Name = "lblTextoUltimoRespaldoInventario"
        Me.lblTextoUltimoRespaldoInventario.Size = New System.Drawing.Size(132, 13)
        Me.lblTextoUltimoRespaldoInventario.TabIndex = 71
        Me.lblTextoUltimoRespaldoInventario.Text = "Inventario para Apartados:"
        Me.lblTextoUltimoRespaldoInventario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoUltimoRespaldoInventario.Visible = False
        '
        'lblFechaUltimaDistribucion
        '
        Me.lblFechaUltimaDistribucion.AutoSize = True
        Me.lblFechaUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaDistribucion.Location = New System.Drawing.Point(262, 39)
        Me.lblFechaUltimaDistribucion.Name = "lblFechaUltimaDistribucion"
        Me.lblFechaUltimaDistribucion.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaUltimaDistribucion.TabIndex = 63
        Me.lblFechaUltimaDistribucion.Text = "24/05/2016 01:54 PM"
        Me.lblFechaUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFechaUltimaDistribucion.Visible = False
        '
        'lblTextoUltimaDistribucion
        '
        Me.lblTextoUltimaDistribucion.AutoSize = True
        Me.lblTextoUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(130, 39)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(97, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 63
        Me.lblTextoUltimaDistribucion.Text = "Última Distribución:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoUltimaDistribucion.Visible = False
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(9, 3)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(112, 32)
        Me.lblClientes.TabIndex = 61
        Me.lblClientes.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(57, 36)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 60
        Me.lblTotalSeleccionados.Text = "0"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardarApartado)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardarApartado)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1076, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(118, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(69, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardarApartado
        '
        Me.btnGuardarApartado.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardarApartado.Enabled = False
        Me.btnGuardarApartado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardarApartado.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardarApartado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardarApartado.Location = New System.Drawing.Point(18, 7)
        Me.btnGuardarApartado.Name = "btnGuardarApartado"
        Me.btnGuardarApartado.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarApartado.TabIndex = 6
        Me.btnGuardarApartado.UseVisualStyleBackColor = True
        '
        'lblGuardarApartado
        '
        Me.lblGuardarApartado.AutoSize = True
        Me.lblGuardarApartado.Enabled = False
        Me.lblGuardarApartado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarApartado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardarApartado.Location = New System.Drawing.Point(14, 39)
        Me.lblGuardarApartado.Name = "lblGuardarApartado"
        Me.lblGuardarApartado.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarApartado.TabIndex = 5
        Me.lblGuardarApartado.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(69, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1194, 59)
        Me.pnlEncabezado.TabIndex = 48
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.lblTextoBotonActualizarDistribucion)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnActualizarDistribucion)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblTextoReordenar)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnReordenar)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnGenerarDistribucion)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblGenerarDistribucion)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnVerDisponibilidad)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblVerDisponibilidad)
        Me.pnlAccionesCabecera.Controls.Add(Me.Label4)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblTextoResumen)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnPrioridadClientes)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnResumen)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(441, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'lblTextoBotonActualizarDistribucion
        '
        Me.lblTextoBotonActualizarDistribucion.AutoSize = True
        Me.lblTextoBotonActualizarDistribucion.Enabled = False
        Me.lblTextoBotonActualizarDistribucion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoBotonActualizarDistribucion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoBotonActualizarDistribucion.Location = New System.Drawing.Point(159, 34)
        Me.lblTextoBotonActualizarDistribucion.Name = "lblTextoBotonActualizarDistribucion"
        Me.lblTextoBotonActualizarDistribucion.Size = New System.Drawing.Size(62, 26)
        Me.lblTextoBotonActualizarDistribucion.TabIndex = 58
        Me.lblTextoBotonActualizarDistribucion.Text = " Actualizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Distribución"
        '
        'btnActualizarDistribucion
        '
        Me.btnActualizarDistribucion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnActualizarDistribucion.Enabled = False
        Me.btnActualizarDistribucion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnActualizarDistribucion.Image = CType(resources.GetObject("btnActualizarDistribucion.Image"), System.Drawing.Image)
        Me.btnActualizarDistribucion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnActualizarDistribucion.Location = New System.Drawing.Point(172, 3)
        Me.btnActualizarDistribucion.Name = "btnActualizarDistribucion"
        Me.btnActualizarDistribucion.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizarDistribucion.TabIndex = 59
        Me.btnActualizarDistribucion.UseVisualStyleBackColor = True
        '
        'lblTextoReordenar
        '
        Me.lblTextoReordenar.AutoSize = True
        Me.lblTextoReordenar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoReordenar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoReordenar.Location = New System.Drawing.Point(230, 34)
        Me.lblTextoReordenar.Name = "lblTextoReordenar"
        Me.lblTextoReordenar.Size = New System.Drawing.Size(60, 13)
        Me.lblTextoReordenar.TabIndex = 54
        Me.lblTextoReordenar.Text = " Reordenar"
        '
        'btnReordenar
        '
        Me.btnReordenar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReordenar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnReordenar.Image = CType(resources.GetObject("btnReordenar.Image"), System.Drawing.Image)
        Me.btnReordenar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReordenar.Location = New System.Drawing.Point(243, 3)
        Me.btnReordenar.Name = "btnReordenar"
        Me.btnReordenar.Size = New System.Drawing.Size(32, 32)
        Me.btnReordenar.TabIndex = 55
        Me.btnReordenar.UseVisualStyleBackColor = True
        '
        'btnGenerarDistribucion
        '
        Me.btnGenerarDistribucion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGenerarDistribucion.Enabled = False
        Me.btnGenerarDistribucion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarDistribucion.Image = CType(resources.GetObject("btnGenerarDistribucion.Image"), System.Drawing.Image)
        Me.btnGenerarDistribucion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGenerarDistribucion.Location = New System.Drawing.Point(108, 3)
        Me.btnGenerarDistribucion.Name = "btnGenerarDistribucion"
        Me.btnGenerarDistribucion.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarDistribucion.TabIndex = 53
        Me.btnGenerarDistribucion.UseVisualStyleBackColor = True
        '
        'lblGenerarDistribucion
        '
        Me.lblGenerarDistribucion.AutoSize = True
        Me.lblGenerarDistribucion.Enabled = False
        Me.lblGenerarDistribucion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarDistribucion.Location = New System.Drawing.Point(95, 34)
        Me.lblGenerarDistribucion.Name = "lblGenerarDistribucion"
        Me.lblGenerarDistribucion.Size = New System.Drawing.Size(62, 26)
        Me.lblGenerarDistribucion.TabIndex = 52
        Me.lblGenerarDistribucion.Text = "Generar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Distribución"
        Me.lblGenerarDistribucion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnVerDisponibilidad
        '
        Me.btnVerDisponibilidad.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVerDisponibilidad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVerDisponibilidad.Image = CType(resources.GetObject("btnVerDisponibilidad.Image"), System.Drawing.Image)
        Me.btnVerDisponibilidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVerDisponibilidad.Location = New System.Drawing.Point(36, 2)
        Me.btnVerDisponibilidad.Name = "btnVerDisponibilidad"
        Me.btnVerDisponibilidad.Size = New System.Drawing.Size(32, 32)
        Me.btnVerDisponibilidad.TabIndex = 53
        Me.btnVerDisponibilidad.UseVisualStyleBackColor = True
        '
        'lblVerDisponibilidad
        '
        Me.lblVerDisponibilidad.AutoSize = True
        Me.lblVerDisponibilidad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVerDisponibilidad.Location = New System.Drawing.Point(9, 33)
        Me.lblVerDisponibilidad.Name = "lblVerDisponibilidad"
        Me.lblVerDisponibilidad.Size = New System.Drawing.Size(89, 13)
        Me.lblVerDisponibilidad.TabIndex = 52
        Me.lblVerDisponibilidad.Text = "Ver disponibilidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(355, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 26)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Prioridad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Clientes"
        '
        'lblTextoResumen
        '
        Me.lblTextoResumen.AutoSize = True
        Me.lblTextoResumen.Enabled = False
        Me.lblTextoResumen.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoResumen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoResumen.Location = New System.Drawing.Point(298, 34)
        Me.lblTextoResumen.Name = "lblTextoResumen"
        Me.lblTextoResumen.Size = New System.Drawing.Size(52, 13)
        Me.lblTextoResumen.TabIndex = 9
        Me.lblTextoResumen.Text = "Resumen"
        '
        'btnPrioridadClientes
        '
        Me.btnPrioridadClientes.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnPrioridadClientes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnPrioridadClientes.Image = Global.Ventas.Vista.My.Resources.Resources.prioridad
        Me.btnPrioridadClientes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrioridadClientes.Location = New System.Drawing.Point(362, 3)
        Me.btnPrioridadClientes.Name = "btnPrioridadClientes"
        Me.btnPrioridadClientes.Size = New System.Drawing.Size(32, 32)
        Me.btnPrioridadClientes.TabIndex = 10
        Me.btnPrioridadClientes.UseVisualStyleBackColor = True
        '
        'btnResumen
        '
        Me.btnResumen.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnResumen.Enabled = False
        Me.btnResumen.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnResumen.Image = Global.Ventas.Vista.My.Resources.Resources.catalogos_321
        Me.btnResumen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnResumen.Location = New System.Drawing.Point(306, 3)
        Me.btnResumen.Name = "btnResumen"
        Me.btnResumen.Size = New System.Drawing.Size(32, 32)
        Me.btnResumen.TabIndex = 10
        Me.btnResumen.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(542, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(652, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(303, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(277, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Generación de Apartados (PPCP)"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdDatosGenerarApartados
        '
        Me.grdDatosGenerarApartados.AllowDrop = True
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosGenerarApartados.DisplayLayout.Appearance = Appearance5
        Me.grdDatosGenerarApartados.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdDatosGenerarApartados.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdDatosGenerarApartados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdDatosGenerarApartados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDatosGenerarApartados.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdDatosGenerarApartados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDatosGenerarApartados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosGenerarApartados.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdDatosGenerarApartados.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDatosGenerarApartados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatosGenerarApartados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosGenerarApartados.Location = New System.Drawing.Point(0, 275)
        Me.grdDatosGenerarApartados.Name = "grdDatosGenerarApartados"
        Me.grdDatosGenerarApartados.Size = New System.Drawing.Size(1194, 192)
        Me.grdDatosGenerarApartados.TabIndex = 47
        '
        'cmsOpcionesGenerales
        '
        Me.cmsOpcionesGenerales.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAgregarSeleccionGeneral, Me.tsmiQuitarSeleccionGeneral, Me.tsmiIncluirSeleccionGeneral, Me.tsmiExcluirSeleccionGeneral, Me.tsmiAgregarAtadosNormales, Me.tsmiQuitarSeleccionAtadosNormales, Me.tsmiAgregarSeleccionAtadosPunto, Me.tsmiQuitarSeleccionAtadosPunto, Me.tsmiAgregarSelecciónDestallados, Me.tsmiQuitarSelecciónDestallados, Me.tsmiAgregarSelecciónDestallarNormales, Me.tsmiQuitarSelecciónDestallarNormales, Me.tsmiAgregarSelecciónDestallarPunto, Me.tsmiQuitarSelecciónDestallarPunto})
        Me.cmsOpcionesGenerales.Name = "cmsOpcionesAlmacen"
        Me.cmsOpcionesGenerales.Size = New System.Drawing.Size(253, 312)
        '
        'tsmiAgregarSeleccionGeneral
        '
        Me.tsmiAgregarSeleccionGeneral.Name = "tsmiAgregarSeleccionGeneral"
        Me.tsmiAgregarSeleccionGeneral.Size = New System.Drawing.Size(252, 22)
        Me.tsmiAgregarSeleccionGeneral.Text = "Agregar selección"
        Me.tsmiAgregarSeleccionGeneral.Visible = False
        '
        'tsmiQuitarSeleccionGeneral
        '
        Me.tsmiQuitarSeleccionGeneral.Name = "tsmiQuitarSeleccionGeneral"
        Me.tsmiQuitarSeleccionGeneral.Size = New System.Drawing.Size(252, 22)
        Me.tsmiQuitarSeleccionGeneral.Text = "Quitar selección"
        Me.tsmiQuitarSeleccionGeneral.Visible = False
        '
        'tsmiIncluirSeleccionGeneral
        '
        Me.tsmiIncluirSeleccionGeneral.Name = "tsmiIncluirSeleccionGeneral"
        Me.tsmiIncluirSeleccionGeneral.Size = New System.Drawing.Size(252, 22)
        Me.tsmiIncluirSeleccionGeneral.Text = "Incluir selección"
        Me.tsmiIncluirSeleccionGeneral.Visible = False
        '
        'tsmiExcluirSeleccionGeneral
        '
        Me.tsmiExcluirSeleccionGeneral.Name = "tsmiExcluirSeleccionGeneral"
        Me.tsmiExcluirSeleccionGeneral.Size = New System.Drawing.Size(252, 22)
        Me.tsmiExcluirSeleccionGeneral.Text = " Excluir selección"
        Me.tsmiExcluirSeleccionGeneral.Visible = False
        '
        'tsmiAgregarAtadosNormales
        '
        Me.tsmiAgregarAtadosNormales.Name = "tsmiAgregarAtadosNormales"
        Me.tsmiAgregarAtadosNormales.Size = New System.Drawing.Size(252, 22)
        Me.tsmiAgregarAtadosNormales.Text = "Agregar Selección Atados Normales"
        '
        'tsmiQuitarSeleccionAtadosNormales
        '
        Me.tsmiQuitarSeleccionAtadosNormales.Name = "tsmiQuitarSeleccionAtadosNormales"
        Me.tsmiQuitarSeleccionAtadosNormales.Size = New System.Drawing.Size(252, 22)
        Me.tsmiQuitarSeleccionAtadosNormales.Text = "Quitar Selección Atados Normales"
        '
        'tsmiAgregarSeleccionAtadosPunto
        '
        Me.tsmiAgregarSeleccionAtadosPunto.Name = "tsmiAgregarSeleccionAtadosPunto"
        Me.tsmiAgregarSeleccionAtadosPunto.Size = New System.Drawing.Size(252, 22)
        Me.tsmiAgregarSeleccionAtadosPunto.Text = "Agregar Selección Atados Punto"
        '
        'tsmiQuitarSeleccionAtadosPunto
        '
        Me.tsmiQuitarSeleccionAtadosPunto.Name = "tsmiQuitarSeleccionAtadosPunto"
        Me.tsmiQuitarSeleccionAtadosPunto.Size = New System.Drawing.Size(252, 22)
        Me.tsmiQuitarSeleccionAtadosPunto.Text = "Quitar Selección Atados Punto"
        '
        'tsmiAgregarSelecciónDestallados
        '
        Me.tsmiAgregarSelecciónDestallados.Name = "tsmiAgregarSelecciónDestallados"
        Me.tsmiAgregarSelecciónDestallados.Size = New System.Drawing.Size(252, 22)
        Me.tsmiAgregarSelecciónDestallados.Text = "Agregar Selección Destallados"
        '
        'tsmiQuitarSelecciónDestallados
        '
        Me.tsmiQuitarSelecciónDestallados.Name = "tsmiQuitarSelecciónDestallados"
        Me.tsmiQuitarSelecciónDestallados.Size = New System.Drawing.Size(252, 22)
        Me.tsmiQuitarSelecciónDestallados.Text = "Quitar Selección Destallados"
        '
        'tsmiAgregarSelecciónDestallarNormales
        '
        Me.tsmiAgregarSelecciónDestallarNormales.Name = "tsmiAgregarSelecciónDestallarNormales"
        Me.tsmiAgregarSelecciónDestallarNormales.Size = New System.Drawing.Size(252, 22)
        Me.tsmiAgregarSelecciónDestallarNormales.Text = "Agregar Selección Destallar Normales"
        '
        'tsmiQuitarSelecciónDestallarNormales
        '
        Me.tsmiQuitarSelecciónDestallarNormales.Name = "tsmiQuitarSelecciónDestallarNormales"
        Me.tsmiQuitarSelecciónDestallarNormales.Size = New System.Drawing.Size(252, 22)
        Me.tsmiQuitarSelecciónDestallarNormales.Text = "Quitar Selección Destallar Normales"
        '
        'tsmiAgregarSelecciónDestallarPunto
        '
        Me.tsmiAgregarSelecciónDestallarPunto.Name = "tsmiAgregarSelecciónDestallarPunto"
        Me.tsmiAgregarSelecciónDestallarPunto.Size = New System.Drawing.Size(252, 22)
        Me.tsmiAgregarSelecciónDestallarPunto.Text = "Agregar Selección Destallar Punto"
        '
        'tsmiQuitarSelecciónDestallarPunto
        '
        Me.tsmiQuitarSelecciónDestallarPunto.Name = "tsmiQuitarSelecciónDestallarPunto"
        Me.tsmiQuitarSelecciónDestallarPunto.Size = New System.Drawing.Size(252, 22)
        Me.tsmiQuitarSelecciónDestallarPunto.Text = "Quitar Selección Destallar Punto"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(584, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'GeneracionApartadosPPCP_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1194, 527)
        Me.Controls.Add(Me.grdDatosGenerarApartados)
        Me.Controls.Add(Me.pnlDetallesPartida)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "GeneracionApartadosPPCP_Form"
        Me.Text = "Generación de Apartados (PPCP)"
        Me.pnlDetallesPartida.ResumeLayout(False)
        Me.pnlDetallesPartida.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdDistribucionPartida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdDetallesPartida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.grpAcotaciones.ResumeLayout(False)
        Me.grpAcotaciones.PerformLayout()
        Me.pnlApartadoDisponible.ResumeLayout(False)
        Me.pnlApartadoDisponible.PerformLayout()
        Me.pnlPartidaApartadoCompleta.ResumeLayout(False)
        Me.pnlPartidaApartadoCompleta.PerformLayout()
        Me.pnlPartidaModificada.ResumeLayout(False)
        Me.pnlPartidaModificada.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.grdDatosGenerarApartados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsOpcionesGenerales.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDetallesPartida As System.Windows.Forms.Panel
    Friend WithEvents chboxSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardarApartado As System.Windows.Forms.Button
    Friend WithEvents lblGuardarApartado As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblTextoReordenar As System.Windows.Forms.Label
    Friend WithEvents btnReordenar As System.Windows.Forms.Button
    Friend WithEvents btnVerDisponibilidad As System.Windows.Forms.Button
    Friend WithEvents lblVerDisponibilidad As System.Windows.Forms.Label
    Friend WithEvents lblTextoResumen As System.Windows.Forms.Label
    Friend WithEvents btnResumen As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents btnGuardarCambioTotalTallas As System.Windows.Forms.Button
    Friend WithEvents lblTextoGuardarCambioTotalTallas As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents chboxSeleccionarTodoAtadosNormalesCompletos As System.Windows.Forms.CheckBox
    Friend WithEvents chboxSeleccionarTodoAtadosPuntoDestallar As System.Windows.Forms.CheckBox
    Friend WithEvents chboxSeleccionarTodoAtadosNormalesDestallar As System.Windows.Forms.CheckBox
    Friend WithEvents chboxSeleccionarTodoParesDestallados As System.Windows.Forms.CheckBox
    Friend WithEvents chboxSeleccionarTodoAtadosPuntoCompletos As System.Windows.Forms.CheckBox
    Friend WithEvents lblTextoCheckboxAtadosDestallar As System.Windows.Forms.Label
    Friend WithEvents lblTextoCheckboxAtadosCompletos As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents lblTextoBotonActualizarDistribucion As System.Windows.Forms.Label
    Friend WithEvents btnActualizarDistribucion As System.Windows.Forms.Button
    Friend WithEvents chboxMostrarPartidasSinInventario As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPrioridadClientes As System.Windows.Forms.Button
    Friend WithEvents grdDatosGenerarApartados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblFechaUltimoRespaldoInventario As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimoRespaldoInventario As System.Windows.Forms.Label
    Friend WithEvents lblFechaUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents cmsOpcionesGenerales As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiAgregarSeleccionGeneral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiQuitarSeleccionGeneral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiIncluirSeleccionGeneral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExcluirSeleccionGeneral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chboxMostrarPartidasExcluidas As System.Windows.Forms.CheckBox
    Friend WithEvents lblDescripcionProducto As System.Windows.Forms.Label
    Friend WithEvents lblPartidaPedido As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblPedidoSICY As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblPedidoSay As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tsmiAgregarAtadosNormales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiQuitarSeleccionAtadosNormales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAgregarSelecciónDestallados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiQuitarSelecciónDestallados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAgregarSelecciónDestallarNormales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiQuitarSelecciónDestallarNormales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAgregarSelecciónDestallarPunto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiQuitarSelecciónDestallarPunto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAgregarSeleccionAtadosPunto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiQuitarSeleccionAtadosPunto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTextoRespaldandoInventario As System.Windows.Forms.Label
    Friend WithEvents lblHoraRespaldandoInventario As System.Windows.Forms.Label
    Friend WithEvents chboxMostrarDistribucionPartida As System.Windows.Forms.CheckBox
    Friend WithEvents grpAcotaciones As System.Windows.Forms.GroupBox
    Friend WithEvents lblModificacionOrden As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblModificacionPares As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlApartadoDisponible As System.Windows.Forms.Panel
    Friend WithEvents lblAPPartidaCompleta As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlPartidaApartadoCompleta As System.Windows.Forms.Panel
    Friend WithEvents lblAPPartidaParcial As System.Windows.Forms.Label
    Friend WithEvents pnlPartidaModificada As System.Windows.Forms.Panel
    Friend WithEvents lblModificacionDistribucion As System.Windows.Forms.Label
    Friend WithEvents lblClienteBloqueado3Meses As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdDistribucionPartida As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdDetallesPartida As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblValorApartadosGenerados As System.Windows.Forms.Label
    Friend WithEvents lblTextoApartadosGenerados As System.Windows.Forms.Label
    Friend WithEvents lblTotalTiempos As System.Windows.Forms.Label
    Friend WithEvents lblTiempoPartidasPorApartar As System.Windows.Forms.Label
    Friend WithEvents lblTextoTiempoPartidasApartar As System.Windows.Forms.Label
    Friend WithEvents lblTiempoApartadosPorConfirmar As System.Windows.Forms.Label
    Friend WithEvents lblTextoTiempoPendientesPorConfirmar As System.Windows.Forms.Label
    Friend WithEvents lblCantidadPartidasPorApartar As System.Windows.Forms.Label
    Friend WithEvents lblCantidadPendientesPorConfirmar As System.Windows.Forms.Label
    Friend WithEvents lblTotalParesApartadosPorConfirmar As System.Windows.Forms.Label
    Friend WithEvents btnGenerarDistribucion As System.Windows.Forms.Button
    Friend WithEvents lblGenerarDistribucion As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
