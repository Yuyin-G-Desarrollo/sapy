<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class detallesListasBases
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(detallesListasBases))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnGenerarReportePDF = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarPDF = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.grupParametrosbusqueda = New System.Windows.Forms.GroupBox()
        Me.chkVerPrecioOriginal = New System.Windows.Forms.CheckBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.btnEditarDatosLista = New System.Windows.Forms.Button()
        Me.btnGuardarLista = New System.Windows.Forms.Button()
        Me.chkSeleccionarFiltrados = New System.Windows.Forms.CheckBox()
        Me.lblEditarLista = New System.Windows.Forms.Label()
        Me.lblCancelarCambioLista = New System.Windows.Forms.Label()
        Me.lblNombreLista = New System.Windows.Forms.Label()
        Me.btnCancelarCambiosLista = New System.Windows.Forms.Button()
        Me.txtNombreLista = New System.Windows.Forms.TextBox()
        Me.lblGuardarLista = New System.Windows.Forms.Label()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.dttFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dttFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPrecioMultiple = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblArticulosConPrecio = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalArticulos = New System.Windows.Forms.Label()
        Me.lblCargarPrecios = New System.Windows.Forms.Label()
        Me.btnCargarPrecioMultiple = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkCargarModelosSinPrecio = New System.Windows.Forms.CheckBox()
        Me.chkDescontinuados = New System.Windows.Forms.CheckBox()
        Me.chkEstatusActivo = New System.Windows.Forms.CheckBox()
        Me.chkModelosConPrecio = New System.Windows.Forms.CheckBox()
        Me.grdDatosProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblSinPrecio = New System.Windows.Forms.Label()
        Me.lblConPrecio = New System.Windows.Forms.Label()
        Me.lblPrecioModificado = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlContenedorDerecho = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.exportExcelDetalle = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlGrups = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grupParametrosbusqueda.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtPrecioMultiple, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdDatosProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlContenedorDerecho.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlGrups.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1236, 60)
        Me.pnlHeader.TabIndex = 4
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblExportarExcel)
        Me.pnlAcciones.Controls.Add(Me.btnGenerarReportePDF)
        Me.pnlAcciones.Controls.Add(Me.btnExportarExcel)
        Me.pnlAcciones.Controls.Add(Me.lblExportarPDF)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(190, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(4, 42)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(75, 13)
        Me.lblExportarExcel.TabIndex = 24
        Me.lblExportarExcel.Text = "Exportar Excel"
        '
        'btnGenerarReportePDF
        '
        Me.btnGenerarReportePDF.Image = Global.Ventas.Vista.My.Resources.Resources.pdf_32
        Me.btnGenerarReportePDF.Location = New System.Drawing.Point(99, 8)
        Me.btnGenerarReportePDF.Name = "btnGenerarReportePDF"
        Me.btnGenerarReportePDF.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarReportePDF.TabIndex = 22
        Me.btnGenerarReportePDF.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(25, 8)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 2
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarPDF
        '
        Me.lblExportarPDF.AutoSize = True
        Me.lblExportarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarPDF.Location = New System.Drawing.Point(80, 42)
        Me.lblExportarPDF.Name = "lblExportarPDF"
        Me.lblExportarPDF.Size = New System.Drawing.Size(70, 13)
        Me.lblExportarPDF.TabIndex = 23
        Me.lblExportarPDF.Text = "Exportar PDF"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(934, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(302, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(55, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(183, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Lista de Precios Base"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(242, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'grupParametrosbusqueda
        '
        Me.grupParametrosbusqueda.Controls.Add(Me.chkVerPrecioOriginal)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblEstatus)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblCodigo)
        Me.grupParametrosbusqueda.Controls.Add(Me.txtCodigo)
        Me.grupParametrosbusqueda.Controls.Add(Me.btnEditarDatosLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.btnGuardarLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.chkSeleccionarFiltrados)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblEditarLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblCancelarCambioLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblNombreLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.btnCancelarCambiosLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.txtNombreLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblGuardarLista)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblFechaFin)
        Me.grupParametrosbusqueda.Controls.Add(Me.lblFechaInicio)
        Me.grupParametrosbusqueda.Controls.Add(Me.dttFechaInicio)
        Me.grupParametrosbusqueda.Controls.Add(Me.dttFechaFin)
        Me.grupParametrosbusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grupParametrosbusqueda.Location = New System.Drawing.Point(0, 0)
        Me.grupParametrosbusqueda.Name = "grupParametrosbusqueda"
        Me.grupParametrosbusqueda.Size = New System.Drawing.Size(606, 84)
        Me.grupParametrosbusqueda.TabIndex = 10
        Me.grupParametrosbusqueda.TabStop = False
        '
        'chkVerPrecioOriginal
        '
        Me.chkVerPrecioOriginal.AutoSize = True
        Me.chkVerPrecioOriginal.Location = New System.Drawing.Point(462, 24)
        Me.chkVerPrecioOriginal.Name = "chkVerPrecioOriginal"
        Me.chkVerPrecioOriginal.Size = New System.Drawing.Size(132, 17)
        Me.chkVerPrecioOriginal.TabIndex = 47
        Me.chkVerPrecioOriginal.Text = "Mostrar Precio Original"
        Me.chkVerPrecioOriginal.UseVisualStyleBackColor = True
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.Green
        Me.lblEstatus.Location = New System.Drawing.Point(460, 9)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(51, 13)
        Me.lblEstatus.TabIndex = 46
        Me.lblEstatus.Text = "ACTIVA"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(13, 13)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 45
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(56, 9)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(94, 20)
        Me.txtCodigo.TabIndex = 44
        Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEditarDatosLista
        '
        Me.btnEditarDatosLista.Image = Global.Ventas.Vista.My.Resources.Resources.editar_321
        Me.btnEditarDatosLista.Location = New System.Drawing.Point(461, 40)
        Me.btnEditarDatosLista.Name = "btnEditarDatosLista"
        Me.btnEditarDatosLista.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarDatosLista.TabIndex = 36
        Me.btnEditarDatosLista.UseVisualStyleBackColor = True
        '
        'btnGuardarLista
        '
        Me.btnGuardarLista.Enabled = False
        Me.btnGuardarLista.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarLista.Location = New System.Drawing.Point(508, 40)
        Me.btnGuardarLista.Name = "btnGuardarLista"
        Me.btnGuardarLista.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarLista.TabIndex = 38
        Me.btnGuardarLista.UseVisualStyleBackColor = True
        '
        'chkSeleccionarFiltrados
        '
        Me.chkSeleccionarFiltrados.AutoSize = True
        Me.chkSeleccionarFiltrados.Enabled = False
        Me.chkSeleccionarFiltrados.Location = New System.Drawing.Point(13, 63)
        Me.chkSeleccionarFiltrados.Name = "chkSeleccionarFiltrados"
        Me.chkSeleccionarFiltrados.Size = New System.Drawing.Size(51, 17)
        Me.chkSeleccionarFiltrados.TabIndex = 38
        Me.chkSeleccionarFiltrados.Text = "Todo"
        Me.chkSeleccionarFiltrados.UseVisualStyleBackColor = True
        '
        'lblEditarLista
        '
        Me.lblEditarLista.AutoSize = True
        Me.lblEditarLista.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditarLista.Location = New System.Drawing.Point(460, 71)
        Me.lblEditarLista.Name = "lblEditarLista"
        Me.lblEditarLista.Size = New System.Drawing.Size(34, 13)
        Me.lblEditarLista.TabIndex = 39
        Me.lblEditarLista.Text = "Editar"
        '
        'lblCancelarCambioLista
        '
        Me.lblCancelarCambioLista.AutoSize = True
        Me.lblCancelarCambioLista.Enabled = False
        Me.lblCancelarCambioLista.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarCambioLista.Location = New System.Drawing.Point(547, 71)
        Me.lblCancelarCambioLista.Name = "lblCancelarCambioLista"
        Me.lblCancelarCambioLista.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelarCambioLista.TabIndex = 40
        Me.lblCancelarCambioLista.Text = "Cancelar"
        '
        'lblNombreLista
        '
        Me.lblNombreLista.AutoSize = True
        Me.lblNombreLista.Location = New System.Drawing.Point(166, 13)
        Me.lblNombreLista.Name = "lblNombreLista"
        Me.lblNombreLista.Size = New System.Drawing.Size(36, 13)
        Me.lblNombreLista.TabIndex = 35
        Me.lblNombreLista.Text = "* Lista"
        '
        'btnCancelarCambiosLista
        '
        Me.btnCancelarCambiosLista.Enabled = False
        Me.btnCancelarCambiosLista.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelarCambiosLista.Location = New System.Drawing.Point(555, 40)
        Me.btnCancelarCambiosLista.Name = "btnCancelarCambiosLista"
        Me.btnCancelarCambiosLista.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarCambiosLista.TabIndex = 37
        Me.btnCancelarCambiosLista.UseVisualStyleBackColor = True
        '
        'txtNombreLista
        '
        Me.txtNombreLista.Enabled = False
        Me.txtNombreLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreLista.Location = New System.Drawing.Point(208, 8)
        Me.txtNombreLista.Name = "txtNombreLista"
        Me.txtNombreLista.Size = New System.Drawing.Size(226, 22)
        Me.txtNombreLista.TabIndex = 2
        '
        'lblGuardarLista
        '
        Me.lblGuardarLista.AutoSize = True
        Me.lblGuardarLista.Enabled = False
        Me.lblGuardarLista.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarLista.Location = New System.Drawing.Point(502, 71)
        Me.lblGuardarLista.Name = "lblGuardarLista"
        Me.lblGuardarLista.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarLista.TabIndex = 41
        Me.lblGuardarLista.Text = "Guardar"
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.Location = New System.Drawing.Point(166, 64)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(28, 13)
        Me.lblFechaFin.TabIndex = 29
        Me.lblFechaFin.Text = "* Fin"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(166, 39)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(39, 13)
        Me.lblFechaInicio.TabIndex = 28
        Me.lblFechaInicio.Text = "* Inicio"
        '
        'dttFechaInicio
        '
        Me.dttFechaInicio.Enabled = False
        Me.dttFechaInicio.Location = New System.Drawing.Point(208, 35)
        Me.dttFechaInicio.Name = "dttFechaInicio"
        Me.dttFechaInicio.Size = New System.Drawing.Size(226, 20)
        Me.dttFechaInicio.TabIndex = 26
        '
        'dttFechaFin
        '
        Me.dttFechaFin.Enabled = False
        Me.dttFechaFin.Location = New System.Drawing.Point(208, 60)
        Me.dttFechaFin.Name = "dttFechaFin"
        Me.dttFechaFin.Size = New System.Drawing.Size(226, 20)
        Me.dttFechaFin.TabIndex = 25
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(86, 36)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 43
        Me.lblTotalSeleccionados.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPrecioMultiple)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblArticulosConPrecio)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblTotalArticulos)
        Me.GroupBox2.Controls.Add(Me.lblCargarPrecios)
        Me.GroupBox2.Controls.Add(Me.btnCargarPrecioMultiple)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(899, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 84)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Acciones"
        '
        'txtPrecioMultiple
        '
        Me.txtPrecioMultiple.DecimalPlaces = 2
        Me.txtPrecioMultiple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioMultiple.Location = New System.Drawing.Point(207, 52)
        Me.txtPrecioMultiple.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtPrecioMultiple.Name = "txtPrecioMultiple"
        Me.txtPrecioMultiple.Size = New System.Drawing.Size(85, 20)
        Me.txtPrecioMultiple.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Artículos con Precio"
        '
        'lblArticulosConPrecio
        '
        Me.lblArticulosConPrecio.AutoSize = True
        Me.lblArticulosConPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulosConPrecio.Location = New System.Drawing.Point(116, 54)
        Me.lblArticulosConPrecio.Name = "lblArticulosConPrecio"
        Me.lblArticulosConPrecio.Size = New System.Drawing.Size(17, 18)
        Me.lblArticulosConPrecio.TabIndex = 45
        Me.lblArticulosConPrecio.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(165, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Actualizar precios de la selección"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Total de Artículos"
        '
        'lblTotalArticulos
        '
        Me.lblTotalArticulos.AutoSize = True
        Me.lblTotalArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalArticulos.Location = New System.Drawing.Point(116, 28)
        Me.lblTotalArticulos.Name = "lblTotalArticulos"
        Me.lblTotalArticulos.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalArticulos.TabIndex = 43
        Me.lblTotalArticulos.Text = "0"
        '
        'lblCargarPrecios
        '
        Me.lblCargarPrecios.AutoSize = True
        Me.lblCargarPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCargarPrecios.Location = New System.Drawing.Point(165, 56)
        Me.lblCargarPrecios.Name = "lblCargarPrecios"
        Me.lblCargarPrecios.Size = New System.Drawing.Size(40, 13)
        Me.lblCargarPrecios.TabIndex = 31
        Me.lblCargarPrecios.Text = "Precio:"
        '
        'btnCargarPrecioMultiple
        '
        Me.btnCargarPrecioMultiple.Enabled = False
        Me.btnCargarPrecioMultiple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargarPrecioMultiple.Image = Global.Ventas.Vista.My.Resources.Resources.refresh_32
        Me.btnCargarPrecioMultiple.Location = New System.Drawing.Point(294, 47)
        Me.btnCargarPrecioMultiple.Name = "btnCargarPrecioMultiple"
        Me.btnCargarPrecioMultiple.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarPrecioMultiple.TabIndex = 33
        Me.btnCargarPrecioMultiple.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkCargarModelosSinPrecio)
        Me.GroupBox1.Controls.Add(Me.chkDescontinuados)
        Me.GroupBox1.Controls.Add(Me.chkEstatusActivo)
        Me.GroupBox1.Controls.Add(Me.chkModelosConPrecio)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(606, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 84)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'chkCargarModelosSinPrecio
        '
        Me.chkCargarModelosSinPrecio.AutoSize = True
        Me.chkCargarModelosSinPrecio.Location = New System.Drawing.Point(12, 27)
        Me.chkCargarModelosSinPrecio.Name = "chkCargarModelosSinPrecio"
        Me.chkCargarModelosSinPrecio.Size = New System.Drawing.Size(176, 17)
        Me.chkCargarModelosSinPrecio.TabIndex = 3
        Me.chkCargarModelosSinPrecio.Text = "Ver modelos con precio en cero"
        Me.chkCargarModelosSinPrecio.UseVisualStyleBackColor = True
        '
        'chkDescontinuados
        '
        Me.chkDescontinuados.AutoSize = True
        Me.chkDescontinuados.Location = New System.Drawing.Point(12, 61)
        Me.chkDescontinuados.Name = "chkDescontinuados"
        Me.chkDescontinuados.Size = New System.Drawing.Size(277, 17)
        Me.chkDescontinuados.TabIndex = 2
        Me.chkDescontinuados.Text = "Ver modelos con estatus Descontinuado para Ventas"
        Me.chkDescontinuados.UseVisualStyleBackColor = True
        '
        'chkEstatusActivo
        '
        Me.chkEstatusActivo.AutoSize = True
        Me.chkEstatusActivo.Location = New System.Drawing.Point(12, 44)
        Me.chkEstatusActivo.Name = "chkEstatusActivo"
        Me.chkEstatusActivo.Size = New System.Drawing.Size(250, 17)
        Me.chkEstatusActivo.TabIndex = 1
        Me.chkEstatusActivo.Text = "Ver modelos con estatus activo (M/AP/AV/DP)"
        Me.chkEstatusActivo.UseVisualStyleBackColor = True
        '
        'chkModelosConPrecio
        '
        Me.chkModelosConPrecio.AutoSize = True
        Me.chkModelosConPrecio.Location = New System.Drawing.Point(12, 10)
        Me.chkModelosConPrecio.Name = "chkModelosConPrecio"
        Me.chkModelosConPrecio.Size = New System.Drawing.Size(137, 17)
        Me.chkModelosConPrecio.TabIndex = 0
        Me.chkModelosConPrecio.Text = "Ver modelos con precio"
        Me.chkModelosConPrecio.UseVisualStyleBackColor = True
        '
        'grdDatosProductos
        '
        Me.grdDatosProductos.AllowDrop = True
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosProductos.DisplayLayout.Appearance = Appearance1
        Me.grdDatosProductos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatosProductos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdDatosProductos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDatosProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDatosProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDatosProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatosProductos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDatosProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatosProductos.Location = New System.Drawing.Point(0, 166)
        Me.grdDatosProductos.Name = "grdDatosProductos"
        Me.grdDatosProductos.Size = New System.Drawing.Size(1236, 334)
        Me.grdDatosProductos.TabIndex = 11
        Me.grdDatosProductos.Tag = ""
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.Label10)
        Me.pnlEstado.Controls.Add(Me.Panel2)
        Me.pnlEstado.Controls.Add(Me.lblClientes)
        Me.pnlEstado.Controls.Add(Me.lblSinPrecio)
        Me.pnlEstado.Controls.Add(Me.lblConPrecio)
        Me.pnlEstado.Controls.Add(Me.lblPrecioModificado)
        Me.pnlEstado.Controls.Add(Me.Label8)
        Me.pnlEstado.Controls.Add(Me.Label7)
        Me.pnlEstado.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.Label5)
        Me.pnlEstado.Controls.Add(Me.Label4)
        Me.pnlEstado.Controls.Add(Me.Label11)
        Me.pnlEstado.Controls.Add(Me.pnlContenedorDerecho)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 500)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1236, 60)
        Me.pnlEstado.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(782, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(236, 60)
        Me.Panel2.TabIndex = 69
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(7, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(199, 13)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Precio capturado menor al precio original"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(3, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 26)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Los precios se actualizan en la base de datos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hasta dar click en el botón GUARD" & _
    "AR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(38, 3)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(112, 32)
        Me.lblClientes.TabIndex = 59
        Me.lblClientes.Text = "Artículos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSinPrecio
        '
        Me.lblSinPrecio.AutoSize = True
        Me.lblSinPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSinPrecio.Location = New System.Drawing.Point(390, 21)
        Me.lblSinPrecio.Name = "lblSinPrecio"
        Me.lblSinPrecio.Size = New System.Drawing.Size(17, 18)
        Me.lblSinPrecio.TabIndex = 58
        Me.lblSinPrecio.Text = "0"
        '
        'lblConPrecio
        '
        Me.lblConPrecio.AutoSize = True
        Me.lblConPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConPrecio.Location = New System.Drawing.Point(390, 3)
        Me.lblConPrecio.Name = "lblConPrecio"
        Me.lblConPrecio.Size = New System.Drawing.Size(17, 18)
        Me.lblConPrecio.TabIndex = 57
        Me.lblConPrecio.Text = "0"
        '
        'lblPrecioModificado
        '
        Me.lblPrecioModificado.AutoSize = True
        Me.lblPrecioModificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioModificado.Location = New System.Drawing.Point(390, 39)
        Me.lblPrecioModificado.Name = "lblPrecioModificado"
        Me.lblPrecioModificado.Size = New System.Drawing.Size(17, 18)
        Me.lblPrecioModificado.TabIndex = 50
        Me.lblPrecioModificado.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(252, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Precio Diferente al Original"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(255, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Sin Precio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(255, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Con Precio"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Lime
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(234, 41)
        Me.Label5.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label5.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "D"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(234, 23)
        Me.Label4.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label4.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "N"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(234, 5)
        Me.Label11.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label11.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "P"
        '
        'pnlContenedorDerecho
        '
        Me.pnlContenedorDerecho.Controls.Add(Me.lblGuardar)
        Me.pnlContenedorDerecho.Controls.Add(Me.btnGuardar)
        Me.pnlContenedorDerecho.Controls.Add(Me.lblCancelar)
        Me.pnlContenedorDerecho.Controls.Add(Me.lblEditar)
        Me.pnlContenedorDerecho.Controls.Add(Me.btnCancelar)
        Me.pnlContenedorDerecho.Controls.Add(Me.btnEditar)
        Me.pnlContenedorDerecho.Controls.Add(Me.btnSalir)
        Me.pnlContenedorDerecho.Controls.Add(Me.lblSalir)
        Me.pnlContenedorDerecho.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlContenedorDerecho.Location = New System.Drawing.Point(1018, 0)
        Me.pnlContenedorDerecho.Name = "pnlContenedorDerecho"
        Me.pnlContenedorDerecho.Size = New System.Drawing.Size(218, 60)
        Me.pnlContenedorDerecho.TabIndex = 2
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Enabled = False
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(61, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 11
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(67, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Enabled = False
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(109, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 9
        Me.lblCancelar.Text = "Cancelar"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.Enabled = False
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(16, 41)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 8
        Me.lblEditar.Text = "Editar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelar.Location = New System.Drawing.Point(117, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Enabled = False
        Me.btnEditar.Image = Global.Ventas.Vista.My.Resources.Resources.editar_321
        Me.btnEditar.Location = New System.Drawing.Point(17, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 6
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(167, 7)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(166, 41)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 3
        Me.lblSalir.Text = "Cerrar"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1236, 22)
        Me.Panel3.TabIndex = 43
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnAbajo)
        Me.Panel4.Controls.Add(Me.btnArriba)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1072, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(164, 22)
        Me.Panel4.TabIndex = 50
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(135, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 49
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(107, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 48
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'pnlGrups
        '
        Me.pnlGrups.Controls.Add(Me.grupParametrosbusqueda)
        Me.pnlGrups.Controls.Add(Me.GroupBox1)
        Me.pnlGrups.Controls.Add(Me.GroupBox2)
        Me.pnlGrups.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGrups.Location = New System.Drawing.Point(0, 82)
        Me.pnlGrups.Name = "pnlGrups"
        Me.pnlGrups.Size = New System.Drawing.Size(1236, 84)
        Me.pnlGrups.TabIndex = 51
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Chocolate
        Me.Label10.Location = New System.Drawing.Point(478, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(277, 39)
        Me.Label10.TabIndex = 70
        Me.Label10.Text = "En caso de no visualizar algún artículo, comunicarse con" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "el área de Diseño y Des" & _
    "arrollo para validar que le hayan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "asignado la clave SAT."
        '
        'detallesListasBases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1236, 560)
        Me.Controls.Add(Me.grdDatosProductos)
        Me.Controls.Add(Me.pnlGrups)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "detallesListasBases"
        Me.Text = "Lista de Precios Base"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grupParametrosbusqueda.ResumeLayout(False)
        Me.grupParametrosbusqueda.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtPrecioMultiple, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdDatosProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlContenedorDerecho.ResumeLayout(False)
        Me.pnlContenedorDerecho.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.pnlGrups.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents grupParametrosbusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents grdDatosProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents dttFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedorDerecho As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents txtNombreLista As System.Windows.Forms.TextBox
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnCargarPrecioMultiple As System.Windows.Forms.Button
    Friend WithEvents lblCargarPrecios As System.Windows.Forms.Label
    Friend WithEvents lblNombreLista As System.Windows.Forms.Label
    Friend WithEvents exportExcelDetalle As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCargarModelosSinPrecio As System.Windows.Forms.CheckBox
    Friend WithEvents chkDescontinuados As System.Windows.Forms.CheckBox
    Friend WithEvents chkEstatusActivo As System.Windows.Forms.CheckBox
    Friend WithEvents chkModelosConPrecio As System.Windows.Forms.CheckBox
    Friend WithEvents btnGuardarLista As System.Windows.Forms.Button
    Friend WithEvents btnCancelarCambiosLista As System.Windows.Forms.Button
    Friend WithEvents btnEditarDatosLista As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblGuardarLista As System.Windows.Forms.Label
    Friend WithEvents lblCancelarCambioLista As System.Windows.Forms.Label
    Friend WithEvents lblEditarLista As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarFiltrados As System.Windows.Forms.CheckBox
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblArticulosConPrecio As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotalArticulos As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPrecioModificado As System.Windows.Forms.Label
    Friend WithEvents lblConPrecio As System.Windows.Forms.Label
    Friend WithEvents lblSinPrecio As System.Windows.Forms.Label
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents btnGenerarReportePDF As System.Windows.Forms.Button
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblExportarPDF As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents pnlGrups As System.Windows.Forms.Panel
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioMultiple As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkVerPrecioOriginal As System.Windows.Forms.CheckBox
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
