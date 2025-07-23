<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargaProyeccionForm
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdDatosProyeccion = New DevExpress.XtraGrid.GridControl()
        Me.bgvDatosProyeccion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblTextoCambiosNoGuardados = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.grpFiltros = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmboxMarca = New System.Windows.Forms.ComboBox()
        Me.cmboxAgente = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudSemanaA = New System.Windows.Forms.NumericUpDown()
        Me.nudSemanaDe = New System.Windows.Forms.NumericUpDown()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExportarExcelProyeccion = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnImportarExcelProyeccion = New System.Windows.Forms.Button()
        Me.lblImportarExcel = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdDatosProyeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvDatosProyeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.grpFiltros.SuspendLayout()
        CType(Me.nudSemanaA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1276, 609)
        Me.Panel3.TabIndex = 32
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdDatosProyeccion)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1276, 609)
        Me.Panel1.TabIndex = 33
        '
        'grdDatosProyeccion
        '
        Me.grdDatosProyeccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosProyeccion.Location = New System.Drawing.Point(0, 121)
        Me.grdDatosProyeccion.MainView = Me.bgvDatosProyeccion
        Me.grdDatosProyeccion.Name = "grdDatosProyeccion"
        Me.grdDatosProyeccion.Size = New System.Drawing.Size(1276, 428)
        Me.grdDatosProyeccion.TabIndex = 10
        Me.grdDatosProyeccion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvDatosProyeccion})
        '
        'bgvDatosProyeccion
        '
        Me.bgvDatosProyeccion.GridControl = Me.grdDatosProyeccion
        Me.bgvDatosProyeccion.Name = "bgvDatosProyeccion"
        Me.bgvDatosProyeccion.OptionsCustomization.AllowBandMoving = False
        Me.bgvDatosProyeccion.OptionsCustomization.AllowColumnMoving = False
        Me.bgvDatosProyeccion.OptionsCustomization.AllowGroup = False
        Me.bgvDatosProyeccion.OptionsMenu.EnableColumnMenu = False
        Me.bgvDatosProyeccion.OptionsView.ColumnAutoWidth = False
        Me.bgvDatosProyeccion.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvDatosProyeccion.OptionsView.ShowAutoFilterRow = True
        Me.bgvDatosProyeccion.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.bgvDatosProyeccion.OptionsView.ShowDetailButtons = False
        Me.bgvDatosProyeccion.OptionsView.ShowFooter = True
        Me.bgvDatosProyeccion.OptionsView.ShowGroupPanel = False
        Me.bgvDatosProyeccion.OptionsView.ShowIndicator = False
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblTextoCambiosNoGuardados)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 549)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1276, 60)
        Me.pnlPie.TabIndex = 33
        '
        'lblTextoCambiosNoGuardados
        '
        Me.lblTextoCambiosNoGuardados.AutoSize = True
        Me.lblTextoCambiosNoGuardados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoCambiosNoGuardados.ForeColor = System.Drawing.Color.Purple
        Me.lblTextoCambiosNoGuardados.Location = New System.Drawing.Point(620, 27)
        Me.lblTextoCambiosNoGuardados.Name = "lblTextoCambiosNoGuardados"
        Me.lblTextoCambiosNoGuardados.Size = New System.Drawing.Size(454, 13)
        Me.lblTextoCambiosNoGuardados.TabIndex = 104
        Me.lblTextoCambiosNoGuardados.Text = "Cambios en el listado que aún no han sido guardados en la base de datos (dar clic" &
    " en Guardar)"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1080, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(196, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(62, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 2
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(17, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 2
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(66, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.UseVisualStyleBackColor = True
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
        Me.btnMostrar.TabIndex = 6
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(110, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(103, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(153, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(152, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.grpFiltros)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1276, 62)
        Me.pnlParametros.TabIndex = 32
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.Label8)
        Me.grpFiltros.Controls.Add(Me.Label7)
        Me.grpFiltros.Controls.Add(Me.cmboxMarca)
        Me.grpFiltros.Controls.Add(Me.cmboxAgente)
        Me.grpFiltros.Controls.Add(Me.Label6)
        Me.grpFiltros.Controls.Add(Me.Label2)
        Me.grpFiltros.Controls.Add(Me.Label1)
        Me.grpFiltros.Controls.Add(Me.nudSemanaA)
        Me.grpFiltros.Controls.Add(Me.nudSemanaDe)
        Me.grpFiltros.Controls.Add(Me.nudAño)
        Me.grpFiltros.Location = New System.Drawing.Point(12, 4)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(1253, 50)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(910, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Marca"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(469, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "Agente"
        '
        'cmboxMarca
        '
        Me.cmboxMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmboxMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmboxMarca.FormattingEnabled = True
        Me.cmboxMarca.Location = New System.Drawing.Point(957, 17)
        Me.cmboxMarca.Name = "cmboxMarca"
        Me.cmboxMarca.Size = New System.Drawing.Size(195, 21)
        Me.cmboxMarca.TabIndex = 5
        '
        'cmboxAgente
        '
        Me.cmboxAgente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmboxAgente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmboxAgente.FormattingEnabled = True
        Me.cmboxAgente.Location = New System.Drawing.Point(516, 17)
        Me.cmboxAgente.Name = "cmboxAgente"
        Me.cmboxAgente.Size = New System.Drawing.Size(374, 21)
        Me.cmboxAgente.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(309, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "a"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Semana de"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Año"
        '
        'nudSemanaA
        '
        Me.nudSemanaA.Location = New System.Drawing.Point(326, 17)
        Me.nudSemanaA.Name = "nudSemanaA"
        Me.nudSemanaA.Size = New System.Drawing.Size(41, 20)
        Me.nudSemanaA.TabIndex = 3
        '
        'nudSemanaDe
        '
        Me.nudSemanaDe.Location = New System.Drawing.Point(262, 17)
        Me.nudSemanaDe.Name = "nudSemanaDe"
        Me.nudSemanaDe.Size = New System.Drawing.Size(41, 20)
        Me.nudSemanaDe.TabIndex = 2
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(60, 17)
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(66, 20)
        Me.nudAño.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1276, 59)
        Me.pnlEncabezado.TabIndex = 31
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.btnAyuda)
        Me.pnlAccionesCabecera.Controls.Add(Me.Label3)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportarExcelProyeccion)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblExportarExcel)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnImportarExcelProyeccion)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblImportarExcel)
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'btnAyuda
        '
        Me.btnAyuda.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAyuda.Image = Global.Ventas.Vista.My.Resources.Resources.ayuda
        Me.btnAyuda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAyuda.Location = New System.Drawing.Point(128, 7)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 57
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(126, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Ayuda"
        '
        'btnExportarExcelProyeccion
        '
        Me.btnExportarExcelProyeccion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcelProyeccion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcelProyeccion.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcelProyeccion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcelProyeccion.Location = New System.Drawing.Point(72, 7)
        Me.btnExportarExcelProyeccion.Name = "btnExportarExcelProyeccion"
        Me.btnExportarExcelProyeccion.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcelProyeccion.TabIndex = 55
        Me.btnExportarExcelProyeccion.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(66, 39)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(46, 13)
        Me.lblExportarExcel.TabIndex = 54
        Me.lblExportarExcel.Text = "Exportar"
        '
        'btnImportarExcelProyeccion
        '
        Me.btnImportarExcelProyeccion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImportarExcelProyeccion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImportarExcelProyeccion.Image = Global.Ventas.Vista.My.Resources.Resources.Importarexcel_32
        Me.btnImportarExcelProyeccion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarExcelProyeccion.Location = New System.Drawing.Point(16, 7)
        Me.btnImportarExcelProyeccion.Name = "btnImportarExcelProyeccion"
        Me.btnImportarExcelProyeccion.Size = New System.Drawing.Size(32, 32)
        Me.btnImportarExcelProyeccion.TabIndex = 53
        Me.btnImportarExcelProyeccion.UseVisualStyleBackColor = True
        '
        'lblImportarExcel
        '
        Me.lblImportarExcel.AutoSize = True
        Me.lblImportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImportarExcel.Location = New System.Drawing.Point(10, 39)
        Me.lblImportarExcel.Name = "lblImportarExcel"
        Me.lblImportarExcel.Size = New System.Drawing.Size(45, 13)
        Me.lblImportarExcel.TabIndex = 52
        Me.lblImportarExcel.Text = "Importar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(698, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(578, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(314, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(183, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Proyección de Ventas"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(508, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'CargaProyeccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 609)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "CargaProyeccionForm"
        Me.Text = "Proyección de Ventas"
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdDatosProyeccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvDatosProyeccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        CType(Me.nudSemanaA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdDatosProyeccion As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvDatosProyeccion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblTextoCambiosNoGuardados As System.Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents grpFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmboxMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cmboxAgente As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudSemanaA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudSemanaDe As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents btnExportarExcelProyeccion As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents btnImportarExcelProyeccion As System.Windows.Forms.Button
    Friend WithEvents lblImportarExcel As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAyuda As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents imgLogo As PictureBox
End Class
