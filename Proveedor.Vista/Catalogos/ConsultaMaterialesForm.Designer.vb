<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaMaterialesForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaMaterialesForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlAlta = New System.Windows.Forms.Panel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizarProduccion = New System.Windows.Forms.Button()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlEditMasivaPrecio = New System.Windows.Forms.Panel()
        Me.btnEditMasivo = New System.Windows.Forms.Button()
        Me.lblEditMasivo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.lblGuardarMasivo = New System.Windows.Forms.Label()
        Me.btnGuardarMasivo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.rdboInactivo = New System.Windows.Forms.RadioButton()
        Me.rdboActivo = New System.Windows.Forms.RadioButton()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grdMaterial = New DevExpress.XtraGrid.GridControl()
        Me.grvMaterial = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cIdMaterial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdMaterialNave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cSKU = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cClasificacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cMaterial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cProveedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cUmProv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cUmProd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cPrecioM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cPrecio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cRendimiento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cEstatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cTipo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cCritico = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cCategoria = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cTamaño = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdTam = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cDepartamento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cRemplazo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdRemplazo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cNombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdMatSicy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdclas = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cNaveDesarrolla = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdNaveDesarrolla = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cExclusivo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.chkExclusivo = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.cDiasEntrega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cNave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cOrigenprecio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cFCreacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cFModificacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cIdProveedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlAlta.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlEditMasivaPrecio.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.grdMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExclusivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.pnl)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 522)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(963, 60)
        Me.Panel1.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(103, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 48)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Orígen"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(59, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "I   - Importado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(59, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "N - Nacional"
        '
        'pnl
        '
        Me.pnl.BackColor = System.Drawing.Color.Salmon
        Me.pnl.Location = New System.Drawing.Point(12, 24)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(15, 15)
        Me.pnl.TabIndex = 41
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(28, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Sin precio"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(717, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 8
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(963, 80)
        Me.pnlHeader.TabIndex = 6
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlAlta)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlEditar)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlAutorizar)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlExportar)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlEditMasivaPrecio)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(655, 80)
        Me.FlowLayoutPanel1.TabIndex = 2021
        '
        'pnlAlta
        '
        Me.pnlAlta.Controls.Add(Me.btnNuevo)
        Me.pnlAlta.Controls.Add(Me.lblAlta)
        Me.pnlAlta.Location = New System.Drawing.Point(3, 3)
        Me.pnlAlta.Name = "pnlAlta"
        Me.pnlAlta.Size = New System.Drawing.Size(60, 64)
        Me.pnlAlta.TabIndex = 0
        Me.pnlAlta.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.agregar_32
        Me.btnNuevo.Location = New System.Drawing.Point(14, 0)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevo.TabIndex = 2
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(17, 34)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 65
        Me.lblAlta.Text = "Alta"
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEditar)
        Me.pnlEditar.Location = New System.Drawing.Point(69, 3)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(60, 64)
        Me.pnlEditar.TabIndex = 1
        Me.pnlEditar.Visible = False
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(14, 0)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnEditar, "Seleccionar material para editar.")
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(14, 34)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 66
        Me.lblEditar.Text = "Editar"
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizarProduccion)
        Me.pnlAutorizar.Controls.Add(Me.lblAutorizar)
        Me.pnlAutorizar.Location = New System.Drawing.Point(135, 3)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(73, 64)
        Me.pnlAutorizar.TabIndex = 3
        '
        'btnAutorizarProduccion
        '
        Me.btnAutorizarProduccion.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.aceptar_321
        Me.btnAutorizarProduccion.Location = New System.Drawing.Point(20, 0)
        Me.btnAutorizarProduccion.Name = "btnAutorizarProduccion"
        Me.btnAutorizarProduccion.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizarProduccion.TabIndex = 72
        Me.btnAutorizarProduccion.UseVisualStyleBackColor = True
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(6, 31)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(60, 26)
        Me.lblAutorizar.TabIndex = 73
        Me.lblAutorizar.Text = "Autorizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "producción"
        Me.lblAutorizar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExcel)
        Me.pnlExportar.Controls.Add(Me.Label1)
        Me.pnlExportar.Location = New System.Drawing.Point(214, 3)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(73, 64)
        Me.pnlExportar.TabIndex = 2
        Me.pnlExportar.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.btnExcel.Location = New System.Drawing.Point(20, 0)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExcel.TabIndex = 1
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(13, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlEditMasivaPrecio
        '
        Me.pnlEditMasivaPrecio.Controls.Add(Me.btnEditMasivo)
        Me.pnlEditMasivaPrecio.Controls.Add(Me.lblEditMasivo)
        Me.pnlEditMasivaPrecio.Location = New System.Drawing.Point(293, 3)
        Me.pnlEditMasivaPrecio.Name = "pnlEditMasivaPrecio"
        Me.pnlEditMasivaPrecio.Size = New System.Drawing.Size(106, 64)
        Me.pnlEditMasivaPrecio.TabIndex = 4
        Me.pnlEditMasivaPrecio.Visible = False
        '
        'btnEditMasivo
        '
        Me.btnEditMasivo.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.listaPrecios
        Me.btnEditMasivo.Location = New System.Drawing.Point(36, 3)
        Me.btnEditMasivo.Name = "btnEditMasivo"
        Me.btnEditMasivo.Size = New System.Drawing.Size(32, 32)
        Me.btnEditMasivo.TabIndex = 1
        Me.btnEditMasivo.UseVisualStyleBackColor = True
        '
        'lblEditMasivo
        '
        Me.lblEditMasivo.AutoSize = True
        Me.lblEditMasivo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditMasivo.Location = New System.Drawing.Point(13, 34)
        Me.lblEditMasivo.Name = "lblEditMasivo"
        Me.lblEditMasivo.Size = New System.Drawing.Size(82, 26)
        Me.lblEditMasivo.TabIndex = 71
        Me.lblEditMasivo.Text = "Edición Masiva " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Precios"
        Me.lblEditMasivo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(667, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(296, 80)
        Me.pnlTitulo.TabIndex = 1
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(228, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 80)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(130, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(92, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Materiales"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.rdboInactivo)
        Me.grbParametros.Controls.Add(Me.rdboActivo)
        Me.grbParametros.Controls.Add(Me.lblActivo)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 80)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(963, 73)
        Me.grbParametros.TabIndex = 60
        Me.grbParametros.TabStop = False
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.lblGuardarMasivo)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnGuardarMasivo)
        Me.pnlMinimizarParametros.Controls.Add(Me.Label2)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.Label4)
        Me.pnlMinimizarParametros.Controls.Add(Me.Button3)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(801, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(159, 54)
        Me.pnlMinimizarParametros.TabIndex = 74
        '
        'lblGuardarMasivo
        '
        Me.lblGuardarMasivo.AutoSize = True
        Me.lblGuardarMasivo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarMasivo.Location = New System.Drawing.Point(9, 30)
        Me.lblGuardarMasivo.Name = "lblGuardarMasivo"
        Me.lblGuardarMasivo.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarMasivo.TabIndex = 184
        Me.lblGuardarMasivo.Text = "Guardar"
        Me.lblGuardarMasivo.Visible = False
        '
        'btnGuardarMasivo
        '
        Me.btnGuardarMasivo.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarMasivo.Location = New System.Drawing.Point(13, -1)
        Me.btnGuardarMasivo.Name = "btnGuardarMasivo"
        Me.btnGuardarMasivo.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarMasivo.TabIndex = 183
        Me.btnGuardarMasivo.UseVisualStyleBackColor = True
        Me.btnGuardarMasivo.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(114, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Proveedor.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(116, -1)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 181
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(62, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 166
        Me.Label4.Text = "Mostrar"
        '
        'Button3
        '
        Me.Button3.Image = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.Button3.Location = New System.Drawing.Point(66, -1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(32, 32)
        Me.Button3.TabIndex = 165
        Me.Button3.UseVisualStyleBackColor = True
        '
        'rdboInactivo
        '
        Me.rdboInactivo.AutoSize = True
        Me.rdboInactivo.Location = New System.Drawing.Point(309, 27)
        Me.rdboInactivo.Name = "rdboInactivo"
        Me.rdboInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdboInactivo.TabIndex = 6
        Me.rdboInactivo.TabStop = True
        Me.rdboInactivo.Text = "No"
        Me.rdboInactivo.UseVisualStyleBackColor = True
        '
        'rdboActivo
        '
        Me.rdboActivo.AutoSize = True
        Me.rdboActivo.Checked = True
        Me.rdboActivo.Location = New System.Drawing.Point(269, 27)
        Me.rdboActivo.Name = "rdboActivo"
        Me.rdboActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdboActivo.TabIndex = 5
        Me.rdboActivo.TabStop = True
        Me.rdboActivo.Text = "Si"
        Me.rdboActivo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(226, 29)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 73
        Me.lblActivo.Text = "Activo"
        '
        'cmbNave
        '
        Me.cmbNave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(51, 26)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(163, 21)
        Me.cmbNave.TabIndex = 4
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(12, 29)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 69
        Me.lblNave.Text = "*Nave"
        '
        'grdMaterial
        '
        Me.grdMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMaterial.Location = New System.Drawing.Point(0, 153)
        Me.grdMaterial.MainView = Me.grvMaterial
        Me.grdMaterial.Name = "grdMaterial"
        Me.grdMaterial.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkExclusivo})
        Me.grdMaterial.Size = New System.Drawing.Size(963, 369)
        Me.grdMaterial.TabIndex = 61
        Me.grdMaterial.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvMaterial})
        '
        'grvMaterial
        '
        Me.grvMaterial.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.cIdMaterial, Me.cIdMaterialNave, Me.cSKU, Me.cClasificacion, Me.cMaterial, Me.cProveedor, Me.cUmProv, Me.cUmProd, Me.cPrecioM, Me.cPrecio, Me.cRendimiento, Me.cEstatus, Me.cTipo, Me.cCritico, Me.cColor, Me.cCategoria, Me.cTamaño, Me.cIdColor, Me.cIdTam, Me.cDepartamento, Me.cRemplazo, Me.cIdRemplazo, Me.cNombre, Me.cIdMatSicy, Me.cIdc, Me.cIdclas, Me.cNaveDesarrolla, Me.cIdNaveDesarrolla, Me.cExclusivo, Me.cDiasEntrega, Me.cNave, Me.cOrigenprecio, Me.cFCreacion, Me.cFModificacion, Me.cIdProveedor})
        Me.grvMaterial.GridControl = Me.grdMaterial
        Me.grvMaterial.Name = "grvMaterial"
        Me.grvMaterial.OptionsSelection.MultiSelect = True
        Me.grvMaterial.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.grvMaterial.OptionsView.ShowAutoFilterRow = True
        Me.grvMaterial.OptionsView.ShowGroupPanel = False
        '
        'cIdMaterial
        '
        Me.cIdMaterial.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdMaterial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdMaterial.Caption = "ID"
        Me.cIdMaterial.FieldName = "ID"
        Me.cIdMaterial.Name = "cIdMaterial"
        Me.cIdMaterial.OptionsColumn.AllowEdit = False
        Me.cIdMaterial.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdMaterial.Visible = True
        Me.cIdMaterial.VisibleIndex = 1
        Me.cIdMaterial.Width = 81
        '
        'cIdMaterialNave
        '
        Me.cIdMaterialNave.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdMaterialNave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdMaterialNave.Caption = "Id Material Nave"
        Me.cIdMaterialNave.FieldName = "idMaterialNave"
        Me.cIdMaterialNave.Name = "cIdMaterialNave"
        Me.cIdMaterialNave.OptionsColumn.AllowEdit = False
        Me.cIdMaterialNave.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdMaterialNave.Width = 148
        '
        'cSKU
        '
        Me.cSKU.AppearanceHeader.Options.UseTextOptions = True
        Me.cSKU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cSKU.Caption = "SKU"
        Me.cSKU.FieldName = "SKU"
        Me.cSKU.Name = "cSKU"
        Me.cSKU.OptionsColumn.AllowEdit = False
        Me.cSKU.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cSKU.Visible = True
        Me.cSKU.VisibleIndex = 2
        Me.cSKU.Width = 91
        '
        'cClasificacion
        '
        Me.cClasificacion.AppearanceHeader.Options.UseTextOptions = True
        Me.cClasificacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cClasificacion.Caption = "Clasificación"
        Me.cClasificacion.FieldName = "Clasificación"
        Me.cClasificacion.Name = "cClasificacion"
        Me.cClasificacion.OptionsColumn.AllowEdit = False
        Me.cClasificacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cClasificacion.Visible = True
        Me.cClasificacion.VisibleIndex = 3
        Me.cClasificacion.Width = 98
        '
        'cMaterial
        '
        Me.cMaterial.AppearanceHeader.Options.UseTextOptions = True
        Me.cMaterial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cMaterial.Caption = "Material"
        Me.cMaterial.FieldName = "Material"
        Me.cMaterial.Name = "cMaterial"
        Me.cMaterial.OptionsColumn.AllowEdit = False
        Me.cMaterial.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cMaterial.Visible = True
        Me.cMaterial.VisibleIndex = 4
        Me.cMaterial.Width = 143
        '
        'cProveedor
        '
        Me.cProveedor.AppearanceHeader.Options.UseTextOptions = True
        Me.cProveedor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cProveedor.Caption = "Proveedor"
        Me.cProveedor.FieldName = "Proveedor"
        Me.cProveedor.Name = "cProveedor"
        Me.cProveedor.OptionsColumn.AllowEdit = False
        Me.cProveedor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cProveedor.Visible = True
        Me.cProveedor.VisibleIndex = 5
        Me.cProveedor.Width = 163
        '
        'cUmProv
        '
        Me.cUmProv.AppearanceHeader.Options.UseTextOptions = True
        Me.cUmProv.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cUmProv.Caption = "UMC"
        Me.cUmProv.FieldName = "UM prov"
        Me.cUmProv.Name = "cUmProv"
        Me.cUmProv.OptionsColumn.AllowEdit = False
        Me.cUmProv.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cUmProv.Visible = True
        Me.cUmProv.VisibleIndex = 6
        Me.cUmProv.Width = 56
        '
        'cUmProd
        '
        Me.cUmProd.AppearanceHeader.Options.UseTextOptions = True
        Me.cUmProd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cUmProd.Caption = "UMP"
        Me.cUmProd.FieldName = "UM-Prod"
        Me.cUmProd.Name = "cUmProd"
        Me.cUmProd.OptionsColumn.AllowEdit = False
        Me.cUmProd.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cUmProd.Visible = True
        Me.cUmProd.VisibleIndex = 8
        Me.cUmProd.Width = 79
        '
        'cPrecioM
        '
        Me.cPrecioM.AppearanceHeader.Options.UseTextOptions = True
        Me.cPrecioM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cPrecioM.Caption = "Precio"
        Me.cPrecioM.DisplayFormat.FormatString = "##,##0.00"
        Me.cPrecioM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cPrecioM.FieldName = "PrecioM"
        Me.cPrecioM.Name = "cPrecioM"
        Me.cPrecioM.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        '
        'cPrecio
        '
        Me.cPrecio.AppearanceHeader.Options.UseTextOptions = True
        Me.cPrecio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cPrecio.Caption = "Precio"
        Me.cPrecio.DisplayFormat.FormatString = "##,##0.00"
        Me.cPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cPrecio.FieldName = "Precio"
        Me.cPrecio.Name = "cPrecio"
        Me.cPrecio.OptionsColumn.AllowEdit = False
        Me.cPrecio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cPrecio.Visible = True
        Me.cPrecio.VisibleIndex = 7
        Me.cPrecio.Width = 65
        '
        'cRendimiento
        '
        Me.cRendimiento.AppearanceHeader.Options.UseTextOptions = True
        Me.cRendimiento.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cRendimiento.Caption = "Factor Conversión"
        Me.cRendimiento.DisplayFormat.FormatString = "####0.00"
        Me.cRendimiento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cRendimiento.FieldName = "Rendimiento"
        Me.cRendimiento.Name = "cRendimiento"
        Me.cRendimiento.OptionsColumn.AllowEdit = False
        Me.cRendimiento.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cRendimiento.Visible = True
        Me.cRendimiento.VisibleIndex = 9
        Me.cRendimiento.Width = 92
        '
        'cEstatus
        '
        Me.cEstatus.AppearanceHeader.Options.UseTextOptions = True
        Me.cEstatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cEstatus.Caption = "Estatus"
        Me.cEstatus.FieldName = "Estatus"
        Me.cEstatus.Name = "cEstatus"
        Me.cEstatus.OptionsColumn.AllowEdit = False
        Me.cEstatus.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cEstatus.Visible = True
        Me.cEstatus.VisibleIndex = 10
        Me.cEstatus.Width = 77
        '
        'cTipo
        '
        Me.cTipo.AppearanceHeader.Options.UseTextOptions = True
        Me.cTipo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cTipo.Caption = "Tipo"
        Me.cTipo.FieldName = "Tipo"
        Me.cTipo.Name = "cTipo"
        Me.cTipo.OptionsColumn.AllowEdit = False
        Me.cTipo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cTipo.Visible = True
        Me.cTipo.VisibleIndex = 11
        Me.cTipo.Width = 77
        '
        'cCritico
        '
        Me.cCritico.AppearanceHeader.Options.UseTextOptions = True
        Me.cCritico.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cCritico.Caption = "Crítico"
        Me.cCritico.FieldName = "Crítico"
        Me.cCritico.Name = "cCritico"
        Me.cCritico.OptionsColumn.AllowEdit = False
        Me.cCritico.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cCritico.Width = 55
        '
        'cColor
        '
        Me.cColor.AppearanceHeader.Options.UseTextOptions = True
        Me.cColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cColor.Caption = "Color"
        Me.cColor.FieldName = "Color"
        Me.cColor.Name = "cColor"
        Me.cColor.OptionsColumn.AllowEdit = False
        Me.cColor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cColor.Width = 55
        '
        'cCategoria
        '
        Me.cCategoria.AppearanceHeader.Options.UseTextOptions = True
        Me.cCategoria.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cCategoria.Caption = "Categoría"
        Me.cCategoria.FieldName = "Categoría"
        Me.cCategoria.Name = "cCategoria"
        Me.cCategoria.OptionsColumn.AllowEdit = False
        Me.cCategoria.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cCategoria.Width = 55
        '
        'cTamaño
        '
        Me.cTamaño.AppearanceHeader.Options.UseTextOptions = True
        Me.cTamaño.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cTamaño.Caption = "Tamaño"
        Me.cTamaño.FieldName = "Tamaño"
        Me.cTamaño.Name = "cTamaño"
        Me.cTamaño.OptionsColumn.AllowEdit = False
        Me.cTamaño.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cTamaño.Width = 55
        '
        'cIdColor
        '
        Me.cIdColor.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdColor.Caption = "Id Color"
        Me.cIdColor.FieldName = "idColor"
        Me.cIdColor.Name = "cIdColor"
        Me.cIdColor.OptionsColumn.AllowEdit = False
        Me.cIdColor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdColor.Width = 55
        '
        'cIdTam
        '
        Me.cIdTam.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdTam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdTam.Caption = "idTam"
        Me.cIdTam.FieldName = "idTam"
        Me.cIdTam.Name = "cIdTam"
        Me.cIdTam.OptionsColumn.AllowEdit = False
        Me.cIdTam.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdTam.Width = 55
        '
        'cDepartamento
        '
        Me.cDepartamento.AppearanceHeader.Options.UseTextOptions = True
        Me.cDepartamento.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cDepartamento.Caption = "Departamento"
        Me.cDepartamento.FieldName = "Departamento"
        Me.cDepartamento.Name = "cDepartamento"
        Me.cDepartamento.OptionsColumn.AllowEdit = False
        Me.cDepartamento.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cDepartamento.Width = 55
        '
        'cRemplazo
        '
        Me.cRemplazo.AppearanceHeader.Options.UseTextOptions = True
        Me.cRemplazo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cRemplazo.Caption = "Remplazo"
        Me.cRemplazo.FieldName = "Remplazo"
        Me.cRemplazo.Name = "cRemplazo"
        Me.cRemplazo.OptionsColumn.AllowEdit = False
        Me.cRemplazo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cRemplazo.Width = 55
        '
        'cIdRemplazo
        '
        Me.cIdRemplazo.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdRemplazo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdRemplazo.Caption = "Id Remplazo"
        Me.cIdRemplazo.FieldName = "IdRemplazo"
        Me.cIdRemplazo.Name = "cIdRemplazo"
        Me.cIdRemplazo.OptionsColumn.AllowEdit = False
        Me.cIdRemplazo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdRemplazo.Width = 121
        '
        'cNombre
        '
        Me.cNombre.AppearanceHeader.Options.UseTextOptions = True
        Me.cNombre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cNombre.Caption = "Nombre"
        Me.cNombre.FieldName = "Nombre"
        Me.cNombre.Name = "cNombre"
        Me.cNombre.OptionsColumn.AllowEdit = False
        Me.cNombre.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cNombre.Width = 48
        '
        'cIdMatSicy
        '
        Me.cIdMatSicy.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdMatSicy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdMatSicy.Caption = "IdMatSicy"
        Me.cIdMatSicy.FieldName = "IdMatSicy"
        Me.cIdMatSicy.Name = "cIdMatSicy"
        Me.cIdMatSicy.OptionsColumn.AllowEdit = False
        Me.cIdMatSicy.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdMatSicy.Width = 84
        '
        'cIdc
        '
        Me.cIdc.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdc.Caption = "idc"
        Me.cIdc.FieldName = "idc"
        Me.cIdc.Name = "cIdc"
        Me.cIdc.OptionsColumn.AllowEdit = False
        Me.cIdc.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdc.Width = 44
        '
        'cIdclas
        '
        Me.cIdclas.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdclas.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdclas.Caption = "idclas"
        Me.cIdclas.FieldName = "idclas"
        Me.cIdclas.Name = "cIdclas"
        Me.cIdclas.OptionsColumn.AllowEdit = False
        Me.cIdclas.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdclas.Width = 44
        '
        'cNaveDesarrolla
        '
        Me.cNaveDesarrolla.AppearanceHeader.Options.UseTextOptions = True
        Me.cNaveDesarrolla.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cNaveDesarrolla.Caption = "Nave Desarrolla"
        Me.cNaveDesarrolla.FieldName = "Nave Desarrolla"
        Me.cNaveDesarrolla.Name = "cNaveDesarrolla"
        Me.cNaveDesarrolla.OptionsColumn.AllowEdit = False
        Me.cNaveDesarrolla.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cNaveDesarrolla.Visible = True
        Me.cNaveDesarrolla.VisibleIndex = 12
        Me.cNaveDesarrolla.Width = 104
        '
        'cIdNaveDesarrolla
        '
        Me.cIdNaveDesarrolla.AppearanceHeader.Options.UseTextOptions = True
        Me.cIdNaveDesarrolla.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cIdNaveDesarrolla.Caption = "ID Nave Desarrolla"
        Me.cIdNaveDesarrolla.FieldName = "ID Nave Desarrolla"
        Me.cIdNaveDesarrolla.Name = "cIdNaveDesarrolla"
        Me.cIdNaveDesarrolla.OptionsColumn.AllowEdit = False
        Me.cIdNaveDesarrolla.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cIdNaveDesarrolla.Width = 44
        '
        'cExclusivo
        '
        Me.cExclusivo.AppearanceHeader.Options.UseTextOptions = True
        Me.cExclusivo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cExclusivo.Caption = "Exclusivo"
        Me.cExclusivo.ColumnEdit = Me.chkExclusivo
        Me.cExclusivo.FieldName = "Exclusivo"
        Me.cExclusivo.Name = "cExclusivo"
        Me.cExclusivo.OptionsColumn.AllowEdit = False
        Me.cExclusivo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cExclusivo.Visible = True
        Me.cExclusivo.VisibleIndex = 13
        Me.cExclusivo.Width = 52
        '
        'chkExclusivo
        '
        Me.chkExclusivo.AutoHeight = False
        Me.chkExclusivo.Name = "chkExclusivo"
        Me.chkExclusivo.ReadOnly = True
        Me.chkExclusivo.ValueChecked = 1
        Me.chkExclusivo.ValueUnchecked = 0
        '
        'cDiasEntrega
        '
        Me.cDiasEntrega.AppearanceHeader.Options.UseTextOptions = True
        Me.cDiasEntrega.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cDiasEntrega.Caption = "Días Entrega"
        Me.cDiasEntrega.FieldName = "Días Entrega"
        Me.cDiasEntrega.Name = "cDiasEntrega"
        Me.cDiasEntrega.OptionsColumn.AllowEdit = False
        Me.cDiasEntrega.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cDiasEntrega.Visible = True
        Me.cDiasEntrega.VisibleIndex = 14
        Me.cDiasEntrega.Width = 69
        '
        'cNave
        '
        Me.cNave.AppearanceHeader.Options.UseTextOptions = True
        Me.cNave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cNave.Caption = "Nave"
        Me.cNave.FieldName = "Nave"
        Me.cNave.Name = "cNave"
        Me.cNave.OptionsColumn.AllowEdit = False
        Me.cNave.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        '
        'cOrigenprecio
        '
        Me.cOrigenprecio.AppearanceHeader.Options.UseTextOptions = True
        Me.cOrigenprecio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cOrigenprecio.Caption = "Orígen"
        Me.cOrigenprecio.FieldName = "origenprecio"
        Me.cOrigenprecio.Name = "cOrigenprecio"
        Me.cOrigenprecio.OptionsColumn.AllowEdit = False
        Me.cOrigenprecio.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cOrigenprecio.Visible = True
        Me.cOrigenprecio.VisibleIndex = 15
        Me.cOrigenprecio.Width = 67
        '
        'cFCreacion
        '
        Me.cFCreacion.AppearanceHeader.Options.UseTextOptions = True
        Me.cFCreacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cFCreacion.Caption = "F. Creación"
        Me.cFCreacion.FieldName = "F. Creación"
        Me.cFCreacion.Name = "cFCreacion"
        Me.cFCreacion.OptionsColumn.AllowEdit = False
        Me.cFCreacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cFCreacion.Visible = True
        Me.cFCreacion.VisibleIndex = 16
        Me.cFCreacion.Width = 92
        '
        'cFModificacion
        '
        Me.cFModificacion.AppearanceHeader.Options.UseTextOptions = True
        Me.cFModificacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cFModificacion.Caption = "F. Modificación"
        Me.cFModificacion.FieldName = "F. Modificación"
        Me.cFModificacion.Name = "cFModificacion"
        Me.cFModificacion.OptionsColumn.AllowEdit = False
        Me.cFModificacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.cFModificacion.Visible = True
        Me.cFModificacion.VisibleIndex = 17
        Me.cFModificacion.Width = 151
        '
        'cIdProveedor
        '
        Me.cIdProveedor.Caption = "IdProveedor"
        Me.cIdProveedor.FieldName = "IdProveedor"
        Me.cIdProveedor.Name = "cIdProveedor"
        Me.cIdProveedor.OptionsColumn.AllowEdit = False
        '
        'ConsultaMaterialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(963, 582)
        Me.Controls.Add(Me.grdMaterial)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ConsultaMaterialesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Materiales"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlAlta.ResumeLayout(False)
        Me.pnlAlta.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlEditMasivaPrecio.ResumeLayout(False)
        Me.pnlEditMasivaPrecio.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        CType(Me.grdMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExclusivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdboInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdboActivo As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnl As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnAutorizarProduccion As System.Windows.Forms.Button
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlAlta As System.Windows.Forms.Panel
    Friend WithEvents pnlEditar As System.Windows.Forms.Panel
    Friend WithEvents pnlExportar As System.Windows.Forms.Panel
    Friend WithEvents pnlAutorizar As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents pnlEditMasivaPrecio As Windows.Forms.Panel
    Friend WithEvents btnEditMasivo As Windows.Forms.Button
    Friend WithEvents lblEditMasivo As Windows.Forms.Label
    Friend WithEvents lblGuardarMasivo As Windows.Forms.Label
    Friend WithEvents btnGuardarMasivo As Windows.Forms.Button
    Friend WithEvents grdMaterial As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvMaterial As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cIdMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdMaterialNave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cSKU As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cClasificacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cProveedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cUmProv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cUmProd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cPrecio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cRendimiento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cEstatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cTipo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cCritico As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cCategoria As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cTamaño As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdTam As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cDepartamento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cRemplazo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdRemplazo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cNombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdMatSicy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdclas As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cNaveDesarrolla As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdNaveDesarrolla As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cExclusivo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cDiasEntrega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cNave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cOrigenprecio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cFCreacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cFModificacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkExclusivo As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents cPrecioM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cIdProveedor As DevExpress.XtraGrid.Columns.GridColumn
End Class
