<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FraccionArancelariaAsignacionForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FraccionArancelariaAsignacionForm))
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblRegistrosSeleccionados = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblEliminar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gpbArticulos = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grdArticulos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.gpbAsignacion = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grdAsignacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkChecarTodasLasAsignaciones = New System.Windows.Forms.CheckBox()
        Me.gpbCatalogoFracciones = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grdCatalogoFracciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkVerTodasLasFracciones = New System.Windows.Forms.CheckBox()
        Me.lblActivoFraccionesArancelarias = New System.Windows.Forms.Label()
        Me.pnlrdoActivoFracciones = New System.Windows.Forms.Panel()
        Me.rdoActivoFraccionesNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoFraccionesSi = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblFraccionArancelariaSeleccionada = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmsExportarExel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CatalogoDeFraccionesArancelariasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArtículosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gpbArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbArticulos.SuspendLayout()
        CType(Me.grdArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        CType(Me.gpbAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbAsignacion.SuspendLayout()
        CType(Me.grdAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.gpbCatalogoFracciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbCatalogoFracciones.SuspendLayout()
        CType(Me.grdCatalogoFracciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlrdoActivoFracciones.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.cmsExportarExel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.lblRegistrosSeleccionados)
        Me.pnlEstado.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 549)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1194, 60)
        Me.pnlEstado.TabIndex = 76
        '
        'lblRegistrosSeleccionados
        '
        Me.lblRegistrosSeleccionados.AutoSize = True
        Me.lblRegistrosSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRegistrosSeleccionados.Location = New System.Drawing.Point(11, 5)
        Me.lblRegistrosSeleccionados.Name = "lblRegistrosSeleccionados"
        Me.lblRegistrosSeleccionados.Size = New System.Drawing.Size(101, 30)
        Me.lblRegistrosSeleccionados.TabIndex = 47
        Me.lblRegistrosSeleccionados.Text = "Registros" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblRegistrosSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(47, 36)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 48
        Me.lblTotalSeleccionados.Text = "0"
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnEliminar)
        Me.pnlOperaciones.Controls.Add(Me.lblEliminar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(965, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(229, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEliminar.Image = Global.Programacion.Vista.My.Resources.Resources.borrar_321
        Me.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminar.Location = New System.Drawing.Point(123, 8)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 29
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblEliminar
        '
        Me.lblEliminar.AutoSize = True
        Me.lblEliminar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEliminar.Location = New System.Drawing.Point(118, 40)
        Me.lblEliminar.Name = "lblEliminar"
        Me.lblEliminar.Size = New System.Drawing.Size(43, 13)
        Me.lblEliminar.TabIndex = 6
        Me.lblEliminar.Text = "Eliminar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(173, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(173, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblAlta)
        Me.pnlEncabezado.Controls.Add(Me.btnAlta)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezado)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1194, 60)
        Me.pnlEncabezado.TabIndex = 75
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(76, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 50
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(82, 9)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 49
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(27, 41)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(30, 13)
        Me.lblAlta.TabIndex = 48
        Me.lblAlta.Text = "Altas"
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(25, 9)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 47
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(800, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(320, 20)
        Me.lblEncabezado.TabIndex = 6
        Me.lblEncabezado.Text = "Asignación de Fracciones Arancelarias"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gpbArticulos)
        Me.Panel3.Controls.Add(Me.pnlFiltros)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1194, 489)
        Me.Panel3.TabIndex = 82
        '
        'gpbArticulos
        '
        Me.gpbArticulos.Controls.Add(Me.grdArticulos)
        Me.gpbArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpbArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbArticulos.Location = New System.Drawing.Point(0, 216)
        Me.gpbArticulos.Name = "gpbArticulos"
        Me.gpbArticulos.Size = New System.Drawing.Size(1194, 273)
        Me.gpbArticulos.TabIndex = 0
        Me.gpbArticulos.Text = "Artículos"
        '
        'grdArticulos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdArticulos.DisplayLayout.Appearance = Appearance1
        Me.grdArticulos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdArticulos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdArticulos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdArticulos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdArticulos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdArticulos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand
        Me.grdArticulos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdArticulos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdArticulos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdArticulos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdArticulos.Location = New System.Drawing.Point(3, 16)
        Me.grdArticulos.Name = "grdArticulos"
        Me.grdArticulos.Size = New System.Drawing.Size(1188, 254)
        Me.grdArticulos.TabIndex = 17
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Controls.Add(Me.gpbAsignacion)
        Me.pnlFiltros.Controls.Add(Me.gpbCatalogoFracciones)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 24)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1194, 192)
        Me.pnlFiltros.TabIndex = 81
        '
        'gpbAsignacion
        '
        Me.gpbAsignacion.Controls.Add(Me.grdAsignacion)
        Me.gpbAsignacion.Controls.Add(Me.Panel2)
        Me.gpbAsignacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.gpbAsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbAsignacion.Location = New System.Drawing.Point(678, 0)
        Me.gpbAsignacion.Name = "gpbAsignacion"
        Me.gpbAsignacion.Size = New System.Drawing.Size(516, 192)
        Me.gpbAsignacion.TabIndex = 91
        Me.gpbAsignacion.Text = "Asignación"
        '
        'grdAsignacion
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAsignacion.DisplayLayout.Appearance = Appearance2
        Me.grdAsignacion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdAsignacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAsignacion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAsignacion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAsignacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAsignacion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand
        Me.grdAsignacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAsignacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAsignacion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAsignacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdAsignacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAsignacion.Location = New System.Drawing.Point(3, 38)
        Me.grdAsignacion.Name = "grdAsignacion"
        Me.grdAsignacion.Size = New System.Drawing.Size(510, 151)
        Me.grdAsignacion.TabIndex = 16
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkChecarTodasLasAsignaciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(510, 22)
        Me.Panel2.TabIndex = 15
        '
        'chkChecarTodasLasAsignaciones
        '
        Me.chkChecarTodasLasAsignaciones.AutoSize = True
        Me.chkChecarTodasLasAsignaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkChecarTodasLasAsignaciones.Location = New System.Drawing.Point(3, 3)
        Me.chkChecarTodasLasAsignaciones.Name = "chkChecarTodasLasAsignaciones"
        Me.chkChecarTodasLasAsignaciones.Size = New System.Drawing.Size(106, 17)
        Me.chkChecarTodasLasAsignaciones.TabIndex = 1
        Me.chkChecarTodasLasAsignaciones.Text = "Seleccionar todo"
        Me.chkChecarTodasLasAsignaciones.UseVisualStyleBackColor = True
        '
        'gpbCatalogoFracciones
        '
        Me.gpbCatalogoFracciones.Controls.Add(Me.grdCatalogoFracciones)
        Me.gpbCatalogoFracciones.Controls.Add(Me.Panel1)
        Me.gpbCatalogoFracciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.gpbCatalogoFracciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbCatalogoFracciones.Location = New System.Drawing.Point(0, 0)
        Me.gpbCatalogoFracciones.Name = "gpbCatalogoFracciones"
        Me.gpbCatalogoFracciones.Size = New System.Drawing.Size(675, 192)
        Me.gpbCatalogoFracciones.TabIndex = 90
        Me.gpbCatalogoFracciones.Text = "Catálogo de Fracciones Arancelarias"
        '
        'grdCatalogoFracciones
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCatalogoFracciones.DisplayLayout.Appearance = Appearance3
        Me.grdCatalogoFracciones.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdCatalogoFracciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCatalogoFracciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCatalogoFracciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCatalogoFracciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCatalogoFracciones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand
        Me.grdCatalogoFracciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCatalogoFracciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdCatalogoFracciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCatalogoFracciones.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdCatalogoFracciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCatalogoFracciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCatalogoFracciones.Location = New System.Drawing.Point(3, 38)
        Me.grdCatalogoFracciones.Name = "grdCatalogoFracciones"
        Me.grdCatalogoFracciones.Size = New System.Drawing.Size(669, 151)
        Me.grdCatalogoFracciones.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.lblActivoFraccionesArancelarias)
        Me.Panel1.Controls.Add(Me.pnlrdoActivoFracciones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(669, 22)
        Me.Panel1.TabIndex = 14
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.chkVerTodasLasFracciones)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(515, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(154, 22)
        Me.Panel4.TabIndex = 12
        '
        'chkVerTodasLasFracciones
        '
        Me.chkVerTodasLasFracciones.AutoSize = True
        Me.chkVerTodasLasFracciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerTodasLasFracciones.Location = New System.Drawing.Point(71, 3)
        Me.chkVerTodasLasFracciones.Name = "chkVerTodasLasFracciones"
        Me.chkVerTodasLasFracciones.Size = New System.Drawing.Size(70, 17)
        Me.chkVerTodasLasFracciones.TabIndex = 0
        Me.chkVerTodasLasFracciones.Text = "Ver Todo"
        Me.chkVerTodasLasFracciones.UseVisualStyleBackColor = True
        '
        'lblActivoFraccionesArancelarias
        '
        Me.lblActivoFraccionesArancelarias.AutoSize = True
        Me.lblActivoFraccionesArancelarias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivoFraccionesArancelarias.Location = New System.Drawing.Point(9, 4)
        Me.lblActivoFraccionesArancelarias.Name = "lblActivoFraccionesArancelarias"
        Me.lblActivoFraccionesArancelarias.Size = New System.Drawing.Size(42, 13)
        Me.lblActivoFraccionesArancelarias.TabIndex = 10
        Me.lblActivoFraccionesArancelarias.Text = "Activos"
        '
        'pnlrdoActivoFracciones
        '
        Me.pnlrdoActivoFracciones.Controls.Add(Me.rdoActivoFraccionesNo)
        Me.pnlrdoActivoFracciones.Controls.Add(Me.rdoActivoFraccionesSi)
        Me.pnlrdoActivoFracciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlrdoActivoFracciones.Location = New System.Drawing.Point(54, 1)
        Me.pnlrdoActivoFracciones.Name = "pnlrdoActivoFracciones"
        Me.pnlrdoActivoFracciones.Size = New System.Drawing.Size(84, 21)
        Me.pnlrdoActivoFracciones.TabIndex = 11
        '
        'rdoActivoFraccionesNo
        '
        Me.rdoActivoFraccionesNo.AutoSize = True
        Me.rdoActivoFraccionesNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoActivoFraccionesNo.Location = New System.Drawing.Point(42, 2)
        Me.rdoActivoFraccionesNo.Name = "rdoActivoFraccionesNo"
        Me.rdoActivoFraccionesNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoFraccionesNo.TabIndex = 4
        Me.rdoActivoFraccionesNo.Text = "No"
        Me.rdoActivoFraccionesNo.UseVisualStyleBackColor = True
        '
        'rdoActivoFraccionesSi
        '
        Me.rdoActivoFraccionesSi.AutoSize = True
        Me.rdoActivoFraccionesSi.Checked = True
        Me.rdoActivoFraccionesSi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoActivoFraccionesSi.Location = New System.Drawing.Point(5, 2)
        Me.rdoActivoFraccionesSi.Name = "rdoActivoFraccionesSi"
        Me.rdoActivoFraccionesSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoFraccionesSi.TabIndex = 3
        Me.rdoActivoFraccionesSi.TabStop = True
        Me.rdoActivoFraccionesSi.Text = "Si"
        Me.rdoActivoFraccionesSi.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1194, 24)
        Me.Panel5.TabIndex = 90
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblFraccionArancelariaSeleccionada)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(6, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1188, 24)
        Me.Panel6.TabIndex = 87
        '
        'lblFraccionArancelariaSeleccionada
        '
        Me.lblFraccionArancelariaSeleccionada.Location = New System.Drawing.Point(290, 4)
        Me.lblFraccionArancelariaSeleccionada.Name = "lblFraccionArancelariaSeleccionada"
        Me.lblFraccionArancelariaSeleccionada.Size = New System.Drawing.Size(842, 15)
        Me.lblFraccionArancelariaSeleccionada.TabIndex = 86
        Me.lblFraccionArancelariaSeleccionada.Text = "Fracción Arancelaria Seleccionada"
        Me.lblFraccionArancelariaSeleccionada.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(1138, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 84
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(1162, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 85
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmsExportarExel
        '
        Me.cmsExportarExel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CatalogoDeFraccionesArancelariasToolStripMenuItem, Me.AsignaciónToolStripMenuItem, Me.ArtículosToolStripMenuItem})
        Me.cmsExportarExel.Name = "cmsExportarExel"
        Me.cmsExportarExel.Size = New System.Drawing.Size(249, 70)
        '
        'CatalogoDeFraccionesArancelariasToolStripMenuItem
        '
        Me.CatalogoDeFraccionesArancelariasToolStripMenuItem.Name = "CatalogoDeFraccionesArancelariasToolStripMenuItem"
        Me.CatalogoDeFraccionesArancelariasToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.CatalogoDeFraccionesArancelariasToolStripMenuItem.Text = "Catálogo de Fracciones Arancelarias"
        '
        'AsignaciónToolStripMenuItem
        '
        Me.AsignaciónToolStripMenuItem.Name = "AsignaciónToolStripMenuItem"
        Me.AsignaciónToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.AsignaciónToolStripMenuItem.Text = "Asignación"
        '
        'ArtículosToolStripMenuItem
        '
        Me.ArtículosToolStripMenuItem.Name = "ArtículosToolStripMenuItem"
        Me.ArtículosToolStripMenuItem.Size = New System.Drawing.Size(248, 22)
        Me.ArtículosToolStripMenuItem.Text = "Artículos"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(1132, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 51
        Me.PictureBox1.TabStop = False
        '
        'FraccionArancelariaAsignacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1194, 609)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "FraccionArancelariaAsignacionForm"
        Me.Text = "Asignación de Fracciones Arancelarias"
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.gpbArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbArticulos.ResumeLayout(False)
        CType(Me.grdArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        CType(Me.gpbAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbAsignacion.ResumeLayout(False)
        CType(Me.grdAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gpbCatalogoFracciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbCatalogoFracciones.ResumeLayout(False)
        CType(Me.grdCatalogoFracciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlrdoActivoFracciones.ResumeLayout(False)
        Me.pnlrdoActivoFracciones.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.cmsExportarExel.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblEliminar As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblRegistrosSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents gpbArticulos As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents gpbAsignacion As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grdAsignacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkChecarTodasLasAsignaciones As System.Windows.Forms.CheckBox
    Friend WithEvents gpbCatalogoFracciones As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents chkVerTodasLasFracciones As System.Windows.Forms.CheckBox
    Friend WithEvents lblActivoFraccionesArancelarias As System.Windows.Forms.Label
    Friend WithEvents pnlrdoActivoFracciones As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoFraccionesNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoFraccionesSi As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblFraccionArancelariaSeleccionada As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents grdArticulos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdCatalogoFracciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmsExportarExel As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CatalogoDeFraccionesArancelariasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsignaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArtículosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
