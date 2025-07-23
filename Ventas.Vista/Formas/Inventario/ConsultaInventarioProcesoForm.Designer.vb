<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaInventarioProcesoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaInventarioProcesoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnExportarInventarioProceso = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblParesProceso = New System.Windows.Forms.Label()
        Me.lblTotalParesProceso = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroStatus = New System.Windows.Forms.Button()
        Me.btnAgregarStatus = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdStatusPedido = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroModelo = New System.Windows.Forms.Button()
        Me.btnAgregarFiltroModelo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdFiltroModelo = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdFiltroLote = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtLote = New System.Windows.Forms.MaskedTextBox()
        Me.gboxTiendas = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroColeccion = New System.Windows.Forms.Button()
        Me.btnAgregarFiltroColeccion = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdFiltroColeccion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxCliente = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarFiltroCliente = New System.Windows.Forms.Button()
        Me.btnAgregarFiltroCliente = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdFiltroCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxSICY = New System.Windows.Forms.GroupBox()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.grdFiltroPedidoSICY = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtPedidoSICY = New System.Windows.Forms.MaskedTextBox()
        Me.gboxPedidosSAY = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdFiltroPedidoSAY = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtPedidoSAY = New System.Windows.Forms.MaskedTextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblNaveAlmacen = New System.Windows.Forms.Label()
        Me.cboxNaveAlmacen = New System.Windows.Forms.ComboBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.tabInventario = New System.Windows.Forms.TabControl()
        Me.tbMaterialPedido = New System.Windows.Forms.TabPage()
        Me.grdMaterialPedido = New DevExpress.XtraGrid.GridControl()
        Me.vwMaterialPedido = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tbMaterialPedidoLote = New System.Windows.Forms.TabPage()
        Me.grdMaterialPedidoLote = New DevExpress.XtraGrid.GridControl()
        Me.vwMaterialPedidoLote = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn70 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn71 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn72 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn73 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn74 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn75 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn76 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn77 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn78 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn79 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn80 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn81 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn82 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn83 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn84 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn85 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn86 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn87 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn88 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdStatusPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdFiltroModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdFiltroLote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxTiendas.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdFiltroColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxCliente.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdFiltroCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxSICY.SuspendLayout()
        Me.Panel25.SuspendLayout()
        CType(Me.grdFiltroPedidoSICY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxPedidosSAY.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdFiltroPedidoSAY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.tabInventario.SuspendLayout()
        Me.tbMaterialPedido.SuspendLayout()
        CType(Me.grdMaterialPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwMaterialPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMaterialPedidoLote.SuspendLayout()
        CType(Me.grdMaterialPedidoLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwMaterialPedidoLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.btnExportarInventarioProceso)
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1248, 65)
        Me.pnlEncabezado.TabIndex = 24
        '
        'btnExportarInventarioProceso
        '
        Me.btnExportarInventarioProceso.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarInventarioProceso.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarInventarioProceso.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarInventarioProceso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarInventarioProceso.Location = New System.Drawing.Point(25, 12)
        Me.btnExportarInventarioProceso.Name = "btnExportarInventarioProceso"
        Me.btnExportarInventarioProceso.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarInventarioProceso.TabIndex = 76
        Me.btnExportarInventarioProceso.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(22, 44)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 75
        Me.lblExportar.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(695, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(278, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(184, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Inventario en Proceso"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(470, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblParesProceso)
        Me.pnlPie.Controls.Add(Me.lblTotalParesProceso)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 421)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1248, 60)
        Me.pnlPie.TabIndex = 26
        '
        'lblParesProceso
        '
        Me.lblParesProceso.AutoSize = True
        Me.lblParesProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesProceso.ForeColor = System.Drawing.Color.Black
        Me.lblParesProceso.Location = New System.Drawing.Point(10, 10)
        Me.lblParesProceso.Name = "lblParesProceso"
        Me.lblParesProceso.Size = New System.Drawing.Size(111, 16)
        Me.lblParesProceso.TabIndex = 118
        Me.lblParesProceso.Text = "Pares Proceso"
        Me.lblParesProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalParesProceso
        '
        Me.lblTotalParesProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalParesProceso.Location = New System.Drawing.Point(17, 33)
        Me.lblTotalParesProceso.Name = "lblTotalParesProceso"
        Me.lblTotalParesProceso.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalParesProceso.TabIndex = 117
        Me.lblTotalParesProceso.Text = "0"
        Me.lblTotalParesProceso.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1086, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(72, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(69, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 4
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(18, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Mostrar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(22, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox3)
        Me.pnlParametros.Controls.Add(Me.GroupBox2)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.gboxTiendas)
        Me.pnlParametros.Controls.Add(Me.gboxCliente)
        Me.pnlParametros.Controls.Add(Me.gboxSICY)
        Me.pnlParametros.Controls.Add(Me.gboxPedidosSAY)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1248, 184)
        Me.pnlParametros.TabIndex = 27
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnLimpiarFiltroStatus)
        Me.GroupBox3.Controls.Add(Me.btnAgregarStatus)
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Location = New System.Drawing.Point(285, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(116, 137)
        Me.GroupBox3.TabIndex = 137
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status Pedido"
        '
        'btnLimpiarFiltroStatus
        '
        Me.btnLimpiarFiltroStatus.Image = CType(resources.GetObject("btnLimpiarFiltroStatus.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroStatus.Location = New System.Drawing.Point(63, 10)
        Me.btnLimpiarFiltroStatus.Name = "btnLimpiarFiltroStatus"
        Me.btnLimpiarFiltroStatus.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroStatus.TabIndex = 6
        Me.btnLimpiarFiltroStatus.UseVisualStyleBackColor = True
        '
        'btnAgregarStatus
        '
        Me.btnAgregarStatus.Image = CType(resources.GetObject("btnAgregarStatus.Image"), System.Drawing.Image)
        Me.btnAgregarStatus.Location = New System.Drawing.Point(88, 10)
        Me.btnAgregarStatus.Name = "btnAgregarStatus"
        Me.btnAgregarStatus.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarStatus.TabIndex = 5
        Me.btnAgregarStatus.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdStatusPedido)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(3, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(110, 98)
        Me.Panel3.TabIndex = 2
        '
        'grdStatusPedido
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdStatusPedido.DisplayLayout.Appearance = Appearance1
        Me.grdStatusPedido.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdStatusPedido.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdStatusPedido.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdStatusPedido.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdStatusPedido.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdStatusPedido.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdStatusPedido.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdStatusPedido.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdStatusPedido.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdStatusPedido.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdStatusPedido.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdStatusPedido.Location = New System.Drawing.Point(0, 0)
        Me.grdStatusPedido.Name = "grdStatusPedido"
        Me.grdStatusPedido.Size = New System.Drawing.Size(107, 98)
        Me.grdStatusPedido.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimpiarFiltroModelo)
        Me.GroupBox2.Controls.Add(Me.btnAgregarFiltroModelo)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Location = New System.Drawing.Point(875, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 136)
        Me.GroupBox2.TabIndex = 136
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Modelo"
        '
        'btnLimpiarFiltroModelo
        '
        Me.btnLimpiarFiltroModelo.Image = CType(resources.GetObject("btnLimpiarFiltroModelo.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroModelo.Location = New System.Drawing.Point(146, 12)
        Me.btnLimpiarFiltroModelo.Name = "btnLimpiarFiltroModelo"
        Me.btnLimpiarFiltroModelo.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroModelo.TabIndex = 5
        Me.btnLimpiarFiltroModelo.UseVisualStyleBackColor = True
        '
        'btnAgregarFiltroModelo
        '
        Me.btnAgregarFiltroModelo.Image = CType(resources.GetObject("btnAgregarFiltroModelo.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroModelo.Location = New System.Drawing.Point(172, 12)
        Me.btnAgregarFiltroModelo.Name = "btnAgregarFiltroModelo"
        Me.btnAgregarFiltroModelo.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroModelo.TabIndex = 4
        Me.btnAgregarFiltroModelo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdFiltroModelo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 98)
        Me.Panel1.TabIndex = 2
        '
        'grdFiltroModelo
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroModelo.DisplayLayout.Appearance = Appearance3
        Me.grdFiltroModelo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroModelo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroModelo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroModelo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroModelo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroModelo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroModelo.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroModelo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroModelo.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdFiltroModelo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroModelo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroModelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFiltroModelo.Location = New System.Drawing.Point(0, 0)
        Me.grdFiltroModelo.Name = "grdFiltroModelo"
        Me.grdFiltroModelo.Size = New System.Drawing.Size(194, 98)
        Me.grdFiltroModelo.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.txtLote)
        Me.GroupBox1.Location = New System.Drawing.Point(192, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(83, 137)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lote"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdFiltroLote)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(77, 98)
        Me.Panel2.TabIndex = 2
        '
        'grdFiltroLote
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroLote.DisplayLayout.Appearance = Appearance5
        Me.grdFiltroLote.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroLote.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroLote.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroLote.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroLote.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroLote.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroLote.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroLote.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroLote.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdFiltroLote.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroLote.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroLote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFiltroLote.Location = New System.Drawing.Point(0, 0)
        Me.grdFiltroLote.Name = "grdFiltroLote"
        Me.grdFiltroLote.Size = New System.Drawing.Size(77, 98)
        Me.grdFiltroLote.TabIndex = 1
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(6, 14)
        Me.txtLote.Mask = "99999999999999999"
        Me.txtLote.Name = "txtLote"
        Me.txtLote.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLote.Size = New System.Drawing.Size(71, 20)
        Me.txtLote.TabIndex = 0
        Me.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gboxTiendas
        '
        Me.gboxTiendas.Controls.Add(Me.btnLimpiarFiltroColeccion)
        Me.gboxTiendas.Controls.Add(Me.btnAgregarFiltroColeccion)
        Me.gboxTiendas.Controls.Add(Me.Panel8)
        Me.gboxTiendas.Location = New System.Drawing.Point(665, 41)
        Me.gboxTiendas.Name = "gboxTiendas"
        Me.gboxTiendas.Size = New System.Drawing.Size(200, 136)
        Me.gboxTiendas.TabIndex = 95
        Me.gboxTiendas.TabStop = False
        Me.gboxTiendas.Text = "Colección"
        '
        'btnLimpiarFiltroColeccion
        '
        Me.btnLimpiarFiltroColeccion.Image = CType(resources.GetObject("btnLimpiarFiltroColeccion.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroColeccion.Location = New System.Drawing.Point(146, 12)
        Me.btnLimpiarFiltroColeccion.Name = "btnLimpiarFiltroColeccion"
        Me.btnLimpiarFiltroColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroColeccion.TabIndex = 5
        Me.btnLimpiarFiltroColeccion.UseVisualStyleBackColor = True
        '
        'btnAgregarFiltroColeccion
        '
        Me.btnAgregarFiltroColeccion.Image = CType(resources.GetObject("btnAgregarFiltroColeccion.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroColeccion.Location = New System.Drawing.Point(172, 12)
        Me.btnAgregarFiltroColeccion.Name = "btnAgregarFiltroColeccion"
        Me.btnAgregarFiltroColeccion.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroColeccion.TabIndex = 4
        Me.btnAgregarFiltroColeccion.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.grdFiltroColeccion)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(3, 35)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(194, 98)
        Me.Panel8.TabIndex = 2
        '
        'grdFiltroColeccion
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroColeccion.DisplayLayout.Appearance = Appearance7
        Me.grdFiltroColeccion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroColeccion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroColeccion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroColeccion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroColeccion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroColeccion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroColeccion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroColeccion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroColeccion.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdFiltroColeccion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroColeccion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroColeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFiltroColeccion.Location = New System.Drawing.Point(0, 0)
        Me.grdFiltroColeccion.Name = "grdFiltroColeccion"
        Me.grdFiltroColeccion.Size = New System.Drawing.Size(194, 98)
        Me.grdFiltroColeccion.TabIndex = 1
        '
        'gboxCliente
        '
        Me.gboxCliente.Controls.Add(Me.btnLimpiarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.btnAgregarFiltroCliente)
        Me.gboxCliente.Controls.Add(Me.Panel7)
        Me.gboxCliente.Location = New System.Drawing.Point(411, 41)
        Me.gboxCliente.Name = "gboxCliente"
        Me.gboxCliente.Size = New System.Drawing.Size(244, 137)
        Me.gboxCliente.TabIndex = 67
        Me.gboxCliente.TabStop = False
        Me.gboxCliente.Text = "Cliente"
        '
        'btnLimpiarFiltroCliente
        '
        Me.btnLimpiarFiltroCliente.Image = CType(resources.GetObject("btnLimpiarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltroCliente.Location = New System.Drawing.Point(188, 12)
        Me.btnLimpiarFiltroCliente.Name = "btnLimpiarFiltroCliente"
        Me.btnLimpiarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnLimpiarFiltroCliente.TabIndex = 4
        Me.btnLimpiarFiltroCliente.UseVisualStyleBackColor = True
        '
        'btnAgregarFiltroCliente
        '
        Me.btnAgregarFiltroCliente.Image = CType(resources.GetObject("btnAgregarFiltroCliente.Image"), System.Drawing.Image)
        Me.btnAgregarFiltroCliente.Location = New System.Drawing.Point(213, 12)
        Me.btnAgregarFiltroCliente.Name = "btnAgregarFiltroCliente"
        Me.btnAgregarFiltroCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnAgregarFiltroCliente.TabIndex = 3
        Me.btnAgregarFiltroCliente.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdFiltroCliente)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 36)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(238, 98)
        Me.Panel7.TabIndex = 2
        '
        'grdFiltroCliente
        '
        Appearance9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroCliente.DisplayLayout.Appearance = Appearance9
        Me.grdFiltroCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroCliente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance10
        Me.grdFiltroCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFiltroCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdFiltroCliente.Name = "grdFiltroCliente"
        Me.grdFiltroCliente.Size = New System.Drawing.Size(238, 98)
        Me.grdFiltroCliente.TabIndex = 2
        '
        'gboxSICY
        '
        Me.gboxSICY.Controls.Add(Me.Panel25)
        Me.gboxSICY.Controls.Add(Me.txtPedidoSICY)
        Me.gboxSICY.Location = New System.Drawing.Point(99, 41)
        Me.gboxSICY.Name = "gboxSICY"
        Me.gboxSICY.Size = New System.Drawing.Size(83, 137)
        Me.gboxSICY.TabIndex = 55
        Me.gboxSICY.TabStop = False
        Me.gboxSICY.Text = "Pedido SICY"
        '
        'Panel25
        '
        Me.Panel25.Controls.Add(Me.grdFiltroPedidoSICY)
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel25.Location = New System.Drawing.Point(3, 36)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(77, 98)
        Me.Panel25.TabIndex = 2
        '
        'grdFiltroPedidoSICY
        '
        Appearance11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroPedidoSICY.DisplayLayout.Appearance = Appearance11
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.RowAlternateAppearance = Appearance12
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroPedidoSICY.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroPedidoSICY.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFiltroPedidoSICY.Location = New System.Drawing.Point(0, 0)
        Me.grdFiltroPedidoSICY.Name = "grdFiltroPedidoSICY"
        Me.grdFiltroPedidoSICY.Size = New System.Drawing.Size(77, 98)
        Me.grdFiltroPedidoSICY.TabIndex = 1
        '
        'txtPedidoSICY
        '
        Me.txtPedidoSICY.Location = New System.Drawing.Point(6, 14)
        Me.txtPedidoSICY.Mask = "99999999999999999"
        Me.txtPedidoSICY.Name = "txtPedidoSICY"
        Me.txtPedidoSICY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPedidoSICY.Size = New System.Drawing.Size(71, 20)
        Me.txtPedidoSICY.TabIndex = 0
        Me.txtPedidoSICY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gboxPedidosSAY
        '
        Me.gboxPedidosSAY.Controls.Add(Me.Panel5)
        Me.gboxPedidosSAY.Controls.Add(Me.txtPedidoSAY)
        Me.gboxPedidosSAY.Location = New System.Drawing.Point(10, 41)
        Me.gboxPedidosSAY.Name = "gboxPedidosSAY"
        Me.gboxPedidosSAY.Size = New System.Drawing.Size(79, 137)
        Me.gboxPedidosSAY.TabIndex = 54
        Me.gboxPedidosSAY.TabStop = False
        Me.gboxPedidosSAY.Text = "Pedido SAY"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdFiltroPedidoSAY)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 36)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(73, 98)
        Me.Panel5.TabIndex = 2
        '
        'grdFiltroPedidoSAY
        '
        Appearance13.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroPedidoSAY.DisplayLayout.Appearance = Appearance13
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance14.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.RowAlternateAppearance = Appearance14
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdFiltroPedidoSAY.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdFiltroPedidoSAY.Location = New System.Drawing.Point(0, 0)
        Me.grdFiltroPedidoSAY.Name = "grdFiltroPedidoSAY"
        Me.grdFiltroPedidoSAY.Size = New System.Drawing.Size(73, 98)
        Me.grdFiltroPedidoSAY.TabIndex = 1
        '
        'txtPedidoSAY
        '
        Me.txtPedidoSAY.Location = New System.Drawing.Point(6, 14)
        Me.txtPedidoSAY.Mask = "99999999999999999"
        Me.txtPedidoSAY.Name = "txtPedidoSAY"
        Me.txtPedidoSAY.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPedidoSAY.Size = New System.Drawing.Size(64, 20)
        Me.txtPedidoSAY.TabIndex = 0
        Me.txtPedidoSAY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblNaveAlmacen)
        Me.Panel6.Controls.Add(Me.cboxNaveAlmacen)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1248, 27)
        Me.Panel6.TabIndex = 46
        '
        'lblNaveAlmacen
        '
        Me.lblNaveAlmacen.AutoSize = True
        Me.lblNaveAlmacen.BackColor = System.Drawing.Color.Transparent
        Me.lblNaveAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblNaveAlmacen.ForeColor = System.Drawing.Color.Black
        Me.lblNaveAlmacen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNaveAlmacen.Location = New System.Drawing.Point(14, 7)
        Me.lblNaveAlmacen.Name = "lblNaveAlmacen"
        Me.lblNaveAlmacen.Size = New System.Drawing.Size(39, 13)
        Me.lblNaveAlmacen.TabIndex = 78
        Me.lblNaveAlmacen.Text = "CEDIS"
        '
        'cboxNaveAlmacen
        '
        Me.cboxNaveAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNaveAlmacen.FormattingEnabled = True
        Me.cboxNaveAlmacen.Location = New System.Drawing.Point(63, 3)
        Me.cboxNaveAlmacen.Name = "cboxNaveAlmacen"
        Me.cboxNaveAlmacen.Size = New System.Drawing.Size(155, 21)
        Me.cboxNaveAlmacen.TabIndex = 77
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1188, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 38
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Location = New System.Drawing.Point(1214, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'tabInventario
        '
        Me.tabInventario.Controls.Add(Me.tbMaterialPedido)
        Me.tabInventario.Controls.Add(Me.tbMaterialPedidoLote)
        Me.tabInventario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabInventario.Location = New System.Drawing.Point(0, 249)
        Me.tabInventario.Name = "tabInventario"
        Me.tabInventario.SelectedIndex = 0
        Me.tabInventario.Size = New System.Drawing.Size(1248, 172)
        Me.tabInventario.TabIndex = 28
        '
        'tbMaterialPedido
        '
        Me.tbMaterialPedido.Controls.Add(Me.grdMaterialPedido)
        Me.tbMaterialPedido.Location = New System.Drawing.Point(4, 22)
        Me.tbMaterialPedido.Name = "tbMaterialPedido"
        Me.tbMaterialPedido.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMaterialPedido.Size = New System.Drawing.Size(1240, 146)
        Me.tbMaterialPedido.TabIndex = 1
        Me.tbMaterialPedido.Text = "Material/Pedido"
        Me.tbMaterialPedido.UseVisualStyleBackColor = True
        '
        'grdMaterialPedido
        '
        Me.grdMaterialPedido.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdMaterialPedido.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdMaterialPedido.Location = New System.Drawing.Point(3, 3)
        Me.grdMaterialPedido.MainView = Me.vwMaterialPedido
        Me.grdMaterialPedido.Name = "grdMaterialPedido"
        Me.grdMaterialPedido.Size = New System.Drawing.Size(1234, 140)
        Me.grdMaterialPedido.TabIndex = 2
        Me.grdMaterialPedido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwMaterialPedido, Me.GridView3, Me.GridView4})
        '
        'vwMaterialPedido
        '
        Me.vwMaterialPedido.GridControl = Me.grdMaterialPedido
        Me.vwMaterialPedido.Name = "vwMaterialPedido"
        Me.vwMaterialPedido.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwMaterialPedido.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwMaterialPedido.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwMaterialPedido.OptionsPrint.AllowMultilineHeaders = True
        Me.vwMaterialPedido.OptionsSelection.MultiSelect = True
        Me.vwMaterialPedido.OptionsView.ColumnAutoWidth = False
        Me.vwMaterialPedido.OptionsView.ShowAutoFilterRow = True
        Me.vwMaterialPedido.OptionsView.ShowFooter = True
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30})
        Me.GridView3.GridControl = Me.grdMaterialPedido
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView3.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = """"
        Me.GridColumn1.FieldName = "Seleccionar"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 35
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "OT"
        Me.GridColumn3.FieldName = "OT"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 70
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "OTSICY"
        Me.GridColumn4.FieldName = "OTSICY"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 70
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Cliente"
        Me.GridColumn5.FieldName = "Cliente"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 220
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Agente"
        Me.GridColumn6.FieldName = "Agente"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 80
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "STATUS"
        Me.GridColumn7.FieldName = "STATUS"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 90
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Tipo OT"
        Me.GridColumn8.FieldName = "TipoOT"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 70
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Pedido SAY"
        Me.GridColumn9.FieldName = "PedidoSAY"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 80
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Pedido SICY"
        Me.GridColumn10.FieldName = "PedidoSICY"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 80
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Orden Cliente"
        Me.GridColumn11.FieldName = "OrdenCliente"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 9
        Me.GridColumn11.Width = 90
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Fecha Entrega Programación"
        Me.GridColumn12.FieldName = "FechaEntregaProgramacion"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 10
        Me.GridColumn12.Width = 120
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Fecha Preparación"
        Me.GridColumn13.FieldName = "FechaPreparacion"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 11
        Me.GridColumn13.Width = 120
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Cantidad"
        Me.GridColumn14.FieldName = "Cantidad"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 12
        Me.GridColumn14.Width = 80
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Confirmados"
        Me.GridColumn15.FieldName = "Confirmados"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 13
        Me.GridColumn15.Width = 80
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Por Confirmar"
        Me.GridColumn16.FieldName = "PorConfirmar"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 14
        Me.GridColumn16.Width = 90
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Cancelados"
        Me.GridColumn17.FieldName = "Cancelados"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 15
        Me.GridColumn17.Width = 80
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Usuario Captura"
        Me.GridColumn18.FieldName = "UsuarioCaptura"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 16
        Me.GridColumn18.Width = 90
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Fecha Captura"
        Me.GridColumn19.FieldName = "FechaCaptura"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 17
        Me.GridColumn19.Width = 120
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Cita"
        Me.GridColumn20.FieldName = "Cita"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 18
        Me.GridColumn20.Width = 50
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Usuario Modifico"
        Me.GridColumn21.FieldName = "UsuarioModifico"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 19
        Me.GridColumn21.Width = 90
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Fecha Modificación"
        Me.GridColumn22.FieldName = "FechaModificacion"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 20
        Me.GridColumn22.Width = 120
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Dias Faltantes"
        Me.GridColumn23.FieldName = "DiasFaltantes"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 21
        Me.GridColumn23.Width = 90
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "BE"
        Me.GridColumn24.FieldName = "BE"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 22
        Me.GridColumn24.Width = 50
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Motivo Cancelación"
        Me.GridColumn25.FieldName = "MotivoCancelacion"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 23
        Me.GridColumn25.Width = 100
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "EstatusID"
        Me.GridColumn26.FieldName = "EstatusID"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "ClaveCitaEntrega"
        Me.GridColumn27.FieldName = "ClaveCitaEntrega"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 24
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "GridColumn3"
        Me.GridColumn28.FieldName = "Observaciones"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 25
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "FechaCitaEntrega"
        Me.GridColumn29.FieldName = "FechaCitaEntrega"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 26
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "HoraCita"
        Me.GridColumn30.FieldName = "HoraCita"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 27
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.grdMaterialPedido
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView4.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFooter = True
        '
        'tbMaterialPedidoLote
        '
        Me.tbMaterialPedidoLote.Controls.Add(Me.grdMaterialPedidoLote)
        Me.tbMaterialPedidoLote.Location = New System.Drawing.Point(4, 22)
        Me.tbMaterialPedidoLote.Name = "tbMaterialPedidoLote"
        Me.tbMaterialPedidoLote.Padding = New System.Windows.Forms.Padding(3)
        Me.tbMaterialPedidoLote.Size = New System.Drawing.Size(1240, 146)
        Me.tbMaterialPedidoLote.TabIndex = 3
        Me.tbMaterialPedidoLote.Text = "Material/Pedido/Lote"
        Me.tbMaterialPedidoLote.UseVisualStyleBackColor = True
        '
        'grdMaterialPedidoLote
        '
        Me.grdMaterialPedidoLote.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdMaterialPedidoLote.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdMaterialPedidoLote.Location = New System.Drawing.Point(3, 3)
        Me.grdMaterialPedidoLote.MainView = Me.vwMaterialPedidoLote
        Me.grdMaterialPedidoLote.Name = "grdMaterialPedidoLote"
        Me.grdMaterialPedidoLote.Size = New System.Drawing.Size(1234, 140)
        Me.grdMaterialPedidoLote.TabIndex = 4
        Me.grdMaterialPedidoLote.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwMaterialPedidoLote, Me.GridView7, Me.GridView8})
        '
        'vwMaterialPedidoLote
        '
        Me.vwMaterialPedidoLote.GridControl = Me.grdMaterialPedidoLote
        Me.vwMaterialPedidoLote.Name = "vwMaterialPedidoLote"
        Me.vwMaterialPedidoLote.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwMaterialPedidoLote.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwMaterialPedidoLote.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwMaterialPedidoLote.OptionsPrint.AllowMultilineHeaders = True
        Me.vwMaterialPedidoLote.OptionsSelection.MultiSelect = True
        Me.vwMaterialPedidoLote.OptionsView.ColumnAutoWidth = False
        Me.vwMaterialPedidoLote.OptionsView.ShowAutoFilterRow = True
        Me.vwMaterialPedidoLote.OptionsView.ShowFooter = True
        '
        'GridView7
        '
        Me.GridView7.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn63, Me.GridColumn64, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67, Me.GridColumn68, Me.GridColumn69, Me.GridColumn70, Me.GridColumn71, Me.GridColumn72, Me.GridColumn73, Me.GridColumn74, Me.GridColumn75, Me.GridColumn76, Me.GridColumn77, Me.GridColumn78, Me.GridColumn79, Me.GridColumn80, Me.GridColumn81, Me.GridColumn82, Me.GridColumn83, Me.GridColumn84, Me.GridColumn85, Me.GridColumn86, Me.GridColumn87, Me.GridColumn88})
        Me.GridView7.GridControl = Me.grdMaterialPedidoLote
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView7.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView7.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView7.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView7.OptionsSelection.MultiSelect = True
        Me.GridView7.OptionsView.ColumnAutoWidth = False
        Me.GridView7.OptionsView.ShowAutoFilterRow = True
        Me.GridView7.OptionsView.ShowFooter = True
        '
        'GridColumn60
        '
        Me.GridColumn60.Caption = """"
        Me.GridColumn60.FieldName = "Seleccionar"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 0
        Me.GridColumn60.Width = 35
        '
        'GridColumn61
        '
        Me.GridColumn61.Caption = "OT"
        Me.GridColumn61.FieldName = "OT"
        Me.GridColumn61.Name = "GridColumn61"
        Me.GridColumn61.OptionsColumn.AllowEdit = False
        Me.GridColumn61.Visible = True
        Me.GridColumn61.VisibleIndex = 1
        Me.GridColumn61.Width = 70
        '
        'GridColumn62
        '
        Me.GridColumn62.Caption = "OTSICY"
        Me.GridColumn62.FieldName = "OTSICY"
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.OptionsColumn.AllowEdit = False
        Me.GridColumn62.Visible = True
        Me.GridColumn62.VisibleIndex = 2
        Me.GridColumn62.Width = 70
        '
        'GridColumn63
        '
        Me.GridColumn63.Caption = "Cliente"
        Me.GridColumn63.FieldName = "Cliente"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.OptionsColumn.AllowEdit = False
        Me.GridColumn63.Visible = True
        Me.GridColumn63.VisibleIndex = 3
        Me.GridColumn63.Width = 220
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "Agente"
        Me.GridColumn64.FieldName = "Agente"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.OptionsColumn.AllowEdit = False
        Me.GridColumn64.Visible = True
        Me.GridColumn64.VisibleIndex = 4
        Me.GridColumn64.Width = 80
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "STATUS"
        Me.GridColumn65.FieldName = "STATUS"
        Me.GridColumn65.Name = "GridColumn65"
        Me.GridColumn65.OptionsColumn.AllowEdit = False
        Me.GridColumn65.Visible = True
        Me.GridColumn65.VisibleIndex = 5
        Me.GridColumn65.Width = 90
        '
        'GridColumn66
        '
        Me.GridColumn66.Caption = "Tipo OT"
        Me.GridColumn66.FieldName = "TipoOT"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.OptionsColumn.AllowEdit = False
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 6
        Me.GridColumn66.Width = 70
        '
        'GridColumn67
        '
        Me.GridColumn67.Caption = "Pedido SAY"
        Me.GridColumn67.FieldName = "PedidoSAY"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.OptionsColumn.AllowEdit = False
        Me.GridColumn67.Visible = True
        Me.GridColumn67.VisibleIndex = 7
        Me.GridColumn67.Width = 80
        '
        'GridColumn68
        '
        Me.GridColumn68.Caption = "Pedido SICY"
        Me.GridColumn68.FieldName = "PedidoSICY"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.OptionsColumn.AllowEdit = False
        Me.GridColumn68.Visible = True
        Me.GridColumn68.VisibleIndex = 8
        Me.GridColumn68.Width = 80
        '
        'GridColumn69
        '
        Me.GridColumn69.Caption = "Orden Cliente"
        Me.GridColumn69.FieldName = "OrdenCliente"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.OptionsColumn.AllowEdit = False
        Me.GridColumn69.Visible = True
        Me.GridColumn69.VisibleIndex = 9
        Me.GridColumn69.Width = 90
        '
        'GridColumn70
        '
        Me.GridColumn70.Caption = "Fecha Entrega Programación"
        Me.GridColumn70.FieldName = "FechaEntregaProgramacion"
        Me.GridColumn70.Name = "GridColumn70"
        Me.GridColumn70.OptionsColumn.AllowEdit = False
        Me.GridColumn70.Visible = True
        Me.GridColumn70.VisibleIndex = 10
        Me.GridColumn70.Width = 120
        '
        'GridColumn71
        '
        Me.GridColumn71.Caption = "Fecha Preparación"
        Me.GridColumn71.FieldName = "FechaPreparacion"
        Me.GridColumn71.Name = "GridColumn71"
        Me.GridColumn71.OptionsColumn.AllowEdit = False
        Me.GridColumn71.Visible = True
        Me.GridColumn71.VisibleIndex = 11
        Me.GridColumn71.Width = 120
        '
        'GridColumn72
        '
        Me.GridColumn72.Caption = "Cantidad"
        Me.GridColumn72.FieldName = "Cantidad"
        Me.GridColumn72.Name = "GridColumn72"
        Me.GridColumn72.OptionsColumn.AllowEdit = False
        Me.GridColumn72.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.GridColumn72.Visible = True
        Me.GridColumn72.VisibleIndex = 12
        Me.GridColumn72.Width = 80
        '
        'GridColumn73
        '
        Me.GridColumn73.Caption = "Confirmados"
        Me.GridColumn73.FieldName = "Confirmados"
        Me.GridColumn73.Name = "GridColumn73"
        Me.GridColumn73.OptionsColumn.AllowEdit = False
        Me.GridColumn73.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.GridColumn73.Visible = True
        Me.GridColumn73.VisibleIndex = 13
        Me.GridColumn73.Width = 80
        '
        'GridColumn74
        '
        Me.GridColumn74.Caption = "Por Confirmar"
        Me.GridColumn74.FieldName = "PorConfirmar"
        Me.GridColumn74.Name = "GridColumn74"
        Me.GridColumn74.OptionsColumn.AllowEdit = False
        Me.GridColumn74.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.GridColumn74.Visible = True
        Me.GridColumn74.VisibleIndex = 14
        Me.GridColumn74.Width = 90
        '
        'GridColumn75
        '
        Me.GridColumn75.Caption = "Cancelados"
        Me.GridColumn75.FieldName = "Cancelados"
        Me.GridColumn75.Name = "GridColumn75"
        Me.GridColumn75.OptionsColumn.AllowEdit = False
        Me.GridColumn75.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.GridColumn75.Visible = True
        Me.GridColumn75.VisibleIndex = 15
        Me.GridColumn75.Width = 80
        '
        'GridColumn76
        '
        Me.GridColumn76.Caption = "Usuario Captura"
        Me.GridColumn76.FieldName = "UsuarioCaptura"
        Me.GridColumn76.Name = "GridColumn76"
        Me.GridColumn76.OptionsColumn.AllowEdit = False
        Me.GridColumn76.Visible = True
        Me.GridColumn76.VisibleIndex = 16
        Me.GridColumn76.Width = 90
        '
        'GridColumn77
        '
        Me.GridColumn77.Caption = "Fecha Captura"
        Me.GridColumn77.FieldName = "FechaCaptura"
        Me.GridColumn77.Name = "GridColumn77"
        Me.GridColumn77.OptionsColumn.AllowEdit = False
        Me.GridColumn77.Visible = True
        Me.GridColumn77.VisibleIndex = 17
        Me.GridColumn77.Width = 120
        '
        'GridColumn78
        '
        Me.GridColumn78.Caption = "Cita"
        Me.GridColumn78.FieldName = "Cita"
        Me.GridColumn78.Name = "GridColumn78"
        Me.GridColumn78.OptionsColumn.AllowEdit = False
        Me.GridColumn78.Visible = True
        Me.GridColumn78.VisibleIndex = 18
        Me.GridColumn78.Width = 50
        '
        'GridColumn79
        '
        Me.GridColumn79.Caption = "Usuario Modifico"
        Me.GridColumn79.FieldName = "UsuarioModifico"
        Me.GridColumn79.Name = "GridColumn79"
        Me.GridColumn79.OptionsColumn.AllowEdit = False
        Me.GridColumn79.Visible = True
        Me.GridColumn79.VisibleIndex = 19
        Me.GridColumn79.Width = 90
        '
        'GridColumn80
        '
        Me.GridColumn80.Caption = "Fecha Modificación"
        Me.GridColumn80.FieldName = "FechaModificacion"
        Me.GridColumn80.Name = "GridColumn80"
        Me.GridColumn80.OptionsColumn.AllowEdit = False
        Me.GridColumn80.Visible = True
        Me.GridColumn80.VisibleIndex = 20
        Me.GridColumn80.Width = 120
        '
        'GridColumn81
        '
        Me.GridColumn81.Caption = "Dias Faltantes"
        Me.GridColumn81.FieldName = "DiasFaltantes"
        Me.GridColumn81.Name = "GridColumn81"
        Me.GridColumn81.OptionsColumn.AllowEdit = False
        Me.GridColumn81.Visible = True
        Me.GridColumn81.VisibleIndex = 21
        Me.GridColumn81.Width = 90
        '
        'GridColumn82
        '
        Me.GridColumn82.Caption = "BE"
        Me.GridColumn82.FieldName = "BE"
        Me.GridColumn82.Name = "GridColumn82"
        Me.GridColumn82.OptionsColumn.AllowEdit = False
        Me.GridColumn82.Visible = True
        Me.GridColumn82.VisibleIndex = 22
        Me.GridColumn82.Width = 50
        '
        'GridColumn83
        '
        Me.GridColumn83.Caption = "Motivo Cancelación"
        Me.GridColumn83.FieldName = "MotivoCancelacion"
        Me.GridColumn83.Name = "GridColumn83"
        Me.GridColumn83.OptionsColumn.AllowEdit = False
        Me.GridColumn83.Visible = True
        Me.GridColumn83.VisibleIndex = 23
        Me.GridColumn83.Width = 100
        '
        'GridColumn84
        '
        Me.GridColumn84.Caption = "EstatusID"
        Me.GridColumn84.FieldName = "EstatusID"
        Me.GridColumn84.Name = "GridColumn84"
        '
        'GridColumn85
        '
        Me.GridColumn85.Caption = "ClaveCitaEntrega"
        Me.GridColumn85.FieldName = "ClaveCitaEntrega"
        Me.GridColumn85.Name = "GridColumn85"
        Me.GridColumn85.Visible = True
        Me.GridColumn85.VisibleIndex = 24
        '
        'GridColumn86
        '
        Me.GridColumn86.Caption = "GridColumn3"
        Me.GridColumn86.FieldName = "Observaciones"
        Me.GridColumn86.Name = "GridColumn86"
        Me.GridColumn86.Visible = True
        Me.GridColumn86.VisibleIndex = 25
        '
        'GridColumn87
        '
        Me.GridColumn87.Caption = "FechaCitaEntrega"
        Me.GridColumn87.FieldName = "FechaCitaEntrega"
        Me.GridColumn87.Name = "GridColumn87"
        Me.GridColumn87.Visible = True
        Me.GridColumn87.VisibleIndex = 26
        '
        'GridColumn88
        '
        Me.GridColumn88.Caption = "HoraCita"
        Me.GridColumn88.FieldName = "HoraCita"
        Me.GridColumn88.Name = "GridColumn88"
        Me.GridColumn88.Visible = True
        Me.GridColumn88.VisibleIndex = 27
        '
        'GridView8
        '
        Me.GridView8.GridControl = Me.grdMaterialPedidoLote
        Me.GridView8.Name = "GridView8"
        Me.GridView8.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView8.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView8.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView8.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView8.OptionsSelection.MultiSelect = True
        Me.GridView8.OptionsView.ColumnAutoWidth = False
        Me.GridView8.OptionsView.ShowAutoFilterRow = True
        Me.GridView8.OptionsView.ShowFooter = True
        '
        'ConsultaInventarioProcesoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1248, 481)
        Me.Controls.Add(Me.tabInventario)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ConsultaInventarioProcesoForm"
        Me.Text = "Inventario en Proceso"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdStatusPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdFiltroModelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdFiltroLote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxTiendas.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdFiltroColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxCliente.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdFiltroCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxSICY.ResumeLayout(False)
        Me.gboxSICY.PerformLayout()
        Me.Panel25.ResumeLayout(False)
        CType(Me.grdFiltroPedidoSICY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxPedidosSAY.ResumeLayout(False)
        Me.gboxPedidosSAY.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdFiltroPedidoSAY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.tabInventario.ResumeLayout(False)
        Me.tbMaterialPedido.ResumeLayout(False)
        CType(Me.grdMaterialPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwMaterialPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMaterialPedidoLote.ResumeLayout(False)
        CType(Me.grdMaterialPedidoLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwMaterialPedidoLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents btnExportarInventarioProceso As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblParesProceso As System.Windows.Forms.Label
    Friend WithEvents lblTotalParesProceso As System.Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdFiltroLote As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtLote As System.Windows.Forms.MaskedTextBox
    Friend WithEvents gboxTiendas As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiarFiltroColeccion As System.Windows.Forms.Button
    Friend WithEvents btnAgregarFiltroColeccion As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents grdFiltroColeccion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxCliente As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiarFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents btnAgregarFiltroCliente As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents grdFiltroCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxSICY As System.Windows.Forms.GroupBox
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents grdFiltroPedidoSICY As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtPedidoSICY As System.Windows.Forms.MaskedTextBox
    Friend WithEvents gboxPedidosSAY As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents grdFiltroPedidoSAY As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtPedidoSAY As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents tabInventario As System.Windows.Forms.TabControl
    Friend WithEvents tbMaterialPedido As System.Windows.Forms.TabPage
    Friend WithEvents tbMaterialPedidoLote As System.Windows.Forms.TabPage
    Friend WithEvents grdMaterialPedido As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwMaterialPedido As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdMaterialPedidoLote As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwMaterialPedidoLote As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn70 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn71 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn72 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn73 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn74 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn76 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn77 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn78 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn79 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn80 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn81 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn82 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn83 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn84 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn85 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn86 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn87 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn88 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiarFiltroModelo As System.Windows.Forms.Button
    Friend WithEvents btnAgregarFiltroModelo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdFiltroModelo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiarFiltroStatus As System.Windows.Forms.Button
    Friend WithEvents btnAgregarStatus As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grdStatusPedido As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cboxNaveAlmacen As ComboBox
    Friend WithEvents lblNaveAlmacen As Label
End Class
