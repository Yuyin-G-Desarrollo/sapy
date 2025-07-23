<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenamientoSimulacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenamientoSimulacion))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnGenerarReporte = New System.Windows.Forms.Button()
        Me.lblExportarPDF = New System.Windows.Forms.Label()
        Me.btnNuevaSimulacion = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnEjecutarOrdenamiento = New System.Windows.Forms.Button()
        Me.lblCargarDatos = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnGuardarSimulacion = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnGuardarCambiosOrden = New System.Windows.Forms.Button()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.lblIdUltimaConfiguracion = New System.Windows.Forms.Label()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCancelarNueva = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlRangoFecha = New System.Windows.Forms.Panel()
        Me.chkTodoRangoFechas = New System.Windows.Forms.CheckBox()
        Me.pnlRango = New System.Windows.Forms.Panel()
        Me.numAnioFin = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numAnioInicio = New System.Windows.Forms.NumericUpDown()
        Me.numFinal = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grdOrdenamiento = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbtSimulador = New System.Windows.Forms.TabControl()
        Me.tbpOrden = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarTodos = New System.Windows.Forms.CheckBox()
        Me.tbpSimulacion = New System.Windows.Forms.TabPage()
        Me.grdSimulacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkCambioArticulo = New System.Windows.Forms.CheckBox()
        Me.chkLimiteCapacidad = New System.Windows.Forms.CheckBox()
        Me.chkReacomodarPedidos = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTiempoFinalizo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTiempoInicio = New System.Windows.Forms.Label()
        Me.pnlProgress = New System.Windows.Forms.Panel()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.lblProceso = New System.Windows.Forms.Label()
        Me.prgProgresoSimulacion = New System.Windows.Forms.ProgressBar()
        Me.expTablaSimulacion = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlRangoFecha.SuspendLayout()
        Me.pnlRango.SuspendLayout()
        CType(Me.numAnioFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAnioInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdOrdenamiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtSimulador.SuspendLayout()
        Me.tbpOrden.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.tbpSimulacion.SuspendLayout()
        CType(Me.grdSimulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlProgress.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnGenerarReporte)
        Me.pnlHeader.Controls.Add(Me.lblExportarPDF)
        Me.pnlHeader.Controls.Add(Me.btnNuevaSimulacion)
        Me.pnlHeader.Controls.Add(Me.Label10)
        Me.pnlHeader.Controls.Add(Me.Panel4)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1070, 60)
        Me.pnlHeader.TabIndex = 37
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnGenerarReporte.Location = New System.Drawing.Point(84, 8)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarReporte.TabIndex = 86
        Me.btnGenerarReporte.UseVisualStyleBackColor = True
        '
        'lblExportarPDF
        '
        Me.lblExportarPDF.AutoSize = True
        Me.lblExportarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarPDF.Location = New System.Drawing.Point(77, 40)
        Me.lblExportarPDF.Name = "lblExportarPDF"
        Me.lblExportarPDF.Size = New System.Drawing.Size(46, 13)
        Me.lblExportarPDF.TabIndex = 87
        Me.lblExportarPDF.Text = "Exportar"
        '
        'btnNuevaSimulacion
        '
        Me.btnNuevaSimulacion.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnNuevaSimulacion.Location = New System.Drawing.Point(21, 8)
        Me.btnNuevaSimulacion.Name = "btnNuevaSimulacion"
        Me.btnNuevaSimulacion.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevaSimulacion.TabIndex = 84
        Me.btnNuevaSimulacion.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.Location = New System.Drawing.Point(18, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 85
        Me.Label10.Text = "Nueva"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.lblTitulo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(771, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(299, 60)
        Me.Panel4.TabIndex = 48
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(12, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(214, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Ordenamiento Simulación"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlBotones)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 532)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1070, 60)
        Me.Panel3.TabIndex = 45
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.GroupBox3)
        Me.pnlBotones.Controls.Add(Me.GroupBox2)
        Me.pnlBotones.Controls.Add(Me.GroupBox1)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(707, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(363, 60)
        Me.pnlBotones.TabIndex = 41
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnEjecutarOrdenamiento)
        Me.GroupBox3.Controls.Add(Me.lblCargarDatos)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Location = New System.Drawing.Point(91, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(87, 60)
        Me.GroupBox3.TabIndex = 49
        Me.GroupBox3.TabStop = False
        '
        'btnEjecutarOrdenamiento
        '
        Me.btnEjecutarOrdenamiento.Image = Global.Programacion.Vista.My.Resources.Resources.importarPrograma
        Me.btnEjecutarOrdenamiento.Location = New System.Drawing.Point(31, 10)
        Me.btnEjecutarOrdenamiento.Name = "btnEjecutarOrdenamiento"
        Me.btnEjecutarOrdenamiento.Size = New System.Drawing.Size(32, 32)
        Me.btnEjecutarOrdenamiento.TabIndex = 46
        Me.btnEjecutarOrdenamiento.UseVisualStyleBackColor = True
        '
        'lblCargarDatos
        '
        Me.lblCargarDatos.AutoSize = True
        Me.lblCargarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCargarDatos.Location = New System.Drawing.Point(9, 44)
        Me.lblCargarDatos.Name = "lblCargarDatos"
        Me.lblCargarDatos.Size = New System.Drawing.Size(77, 13)
        Me.lblCargarDatos.TabIndex = 47
        Me.lblCargarDatos.Text = "Importar Orden"
        Me.lblCargarDatos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.btnGuardarSimulacion)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Location = New System.Drawing.Point(178, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(124, 60)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(73, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 44
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(65, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Cancelar"
        '
        'btnGuardarSimulacion
        '
        Me.btnGuardarSimulacion.Image = Global.Programacion.Vista.My.Resources.Resources.reasignar
        Me.btnGuardarSimulacion.Location = New System.Drawing.Point(10, 10)
        Me.btnGuardarSimulacion.Name = "btnGuardarSimulacion"
        Me.btnGuardarSimulacion.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarSimulacion.TabIndex = 42
        Me.btnGuardarSimulacion.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(6, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Simular"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnGuardarCambiosOrden)
        Me.GroupBox1.Controls.Add(Me.lblAccionRegresar)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.btnRegresar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(302, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(61, 60)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        '
        'btnGuardarCambiosOrden
        '
        Me.btnGuardarCambiosOrden.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarCambiosOrden.Location = New System.Drawing.Point(70, 10)
        Me.btnGuardarCambiosOrden.Name = "btnGuardarCambiosOrden"
        Me.btnGuardarCambiosOrden.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarCambiosOrden.TabIndex = 48
        Me.btnGuardarCambiosOrden.UseVisualStyleBackColor = True
        Me.btnGuardarCambiosOrden.Visible = False
        '
        'lblAccionRegresar
        '
        Me.lblAccionRegresar.AutoSize = True
        Me.lblAccionRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionRegresar.Location = New System.Drawing.Point(14, 44)
        Me.lblAccionRegresar.Name = "lblAccionRegresar"
        Me.lblAccionRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblAccionRegresar.TabIndex = 39
        Me.lblAccionRegresar.Text = "Cerrar"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label11.Location = New System.Drawing.Point(64, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Guardar"
        Me.Label11.Visible = False
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(15, 10)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 7
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(471, 36)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 41
        Me.lblGuardar.Text = "Guardar"
        '
        'grpBotones
        '
        Me.grpBotones.BackColor = System.Drawing.Color.Transparent
        Me.grpBotones.Controls.Add(Me.lblIdUltimaConfiguracion)
        Me.grpBotones.Controls.Add(Me.pnlDatos)
        Me.grpBotones.Controls.Add(Me.Panel1)
        Me.grpBotones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpBotones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grpBotones.Location = New System.Drawing.Point(0, 60)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(1070, 117)
        Me.grpBotones.TabIndex = 46
        Me.grpBotones.TabStop = False
        '
        'lblIdUltimaConfiguracion
        '
        Me.lblIdUltimaConfiguracion.AutoSize = True
        Me.lblIdUltimaConfiguracion.Location = New System.Drawing.Point(6, 20)
        Me.lblIdUltimaConfiguracion.Name = "lblIdUltimaConfiguracion"
        Me.lblIdUltimaConfiguracion.Size = New System.Drawing.Size(13, 13)
        Me.lblIdUltimaConfiguracion.TabIndex = 83
        Me.lblIdUltimaConfiguracion.Text = "0"
        Me.lblIdUltimaConfiguracion.Visible = False
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.Panel6)
        Me.pnlDatos.Controls.Add(Me.pnlRangoFecha)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDatos.Location = New System.Drawing.Point(3, 16)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(582, 98)
        Me.pnlDatos.TabIndex = 79
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.btnCancelarNueva)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.txtDescripcion)
        Me.Panel6.Controls.Add(Me.lblGuardar)
        Me.Panel6.Controls.Add(Me.btnGuardar)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(582, 53)
        Me.Panel6.TabIndex = 87
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Descripción"
        '
        'btnCancelarNueva
        '
        Me.btnCancelarNueva.Enabled = False
        Me.btnCancelarNueva.Image = Global.Programacion.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelarNueva.Location = New System.Drawing.Point(535, 5)
        Me.btnCancelarNueva.Name = "btnCancelarNueva"
        Me.btnCancelarNueva.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarNueva.TabIndex = 86
        Me.btnCancelarNueva.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.Location = New System.Drawing.Point(527, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 87
        Me.Label12.Text = "Cancelar"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Location = New System.Drawing.Point(68, 27)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(250, 20)
        Me.txtDescripcion.TabIndex = 81
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(477, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 40
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlRangoFecha
        '
        Me.pnlRangoFecha.Controls.Add(Me.chkTodoRangoFechas)
        Me.pnlRangoFecha.Controls.Add(Me.pnlRango)
        Me.pnlRangoFecha.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlRangoFecha.Location = New System.Drawing.Point(0, 53)
        Me.pnlRangoFecha.Name = "pnlRangoFecha"
        Me.pnlRangoFecha.Size = New System.Drawing.Size(582, 45)
        Me.pnlRangoFecha.TabIndex = 80
        '
        'chkTodoRangoFechas
        '
        Me.chkTodoRangoFechas.AutoSize = True
        Me.chkTodoRangoFechas.Location = New System.Drawing.Point(11, 24)
        Me.chkTodoRangoFechas.Name = "chkTodoRangoFechas"
        Me.chkTodoRangoFechas.Size = New System.Drawing.Size(51, 17)
        Me.chkTodoRangoFechas.TabIndex = 69
        Me.chkTodoRangoFechas.Text = "Todo"
        Me.chkTodoRangoFechas.UseVisualStyleBackColor = True
        '
        'pnlRango
        '
        Me.pnlRango.Controls.Add(Me.numAnioFin)
        Me.pnlRango.Controls.Add(Me.Label2)
        Me.pnlRango.Controls.Add(Me.numAnioInicio)
        Me.pnlRango.Controls.Add(Me.numFinal)
        Me.pnlRango.Controls.Add(Me.Label6)
        Me.pnlRango.Controls.Add(Me.Label3)
        Me.pnlRango.Controls.Add(Me.Label4)
        Me.pnlRango.Controls.Add(Me.Label5)
        Me.pnlRango.Controls.Add(Me.numInicio)
        Me.pnlRango.Controls.Add(Me.Label1)
        Me.pnlRango.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRango.Location = New System.Drawing.Point(168, 0)
        Me.pnlRango.Name = "pnlRango"
        Me.pnlRango.Size = New System.Drawing.Size(414, 45)
        Me.pnlRango.TabIndex = 88
        '
        'numAnioFin
        '
        Me.numAnioFin.Location = New System.Drawing.Point(307, 6)
        Me.numAnioFin.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnioFin.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.numAnioFin.Name = "numAnioFin"
        Me.numAnioFin.Size = New System.Drawing.Size(62, 20)
        Me.numAnioFin.TabIndex = 78
        Me.numAnioFin.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Rango del:"
        '
        'numAnioInicio
        '
        Me.numAnioInicio.Location = New System.Drawing.Point(151, 6)
        Me.numAnioInicio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnioInicio.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.numAnioInicio.Name = "numAnioInicio"
        Me.numAnioInicio.Size = New System.Drawing.Size(62, 20)
        Me.numAnioInicio.TabIndex = 72
        Me.numAnioInicio.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'numFinal
        '
        Me.numFinal.Location = New System.Drawing.Point(260, 6)
        Me.numFinal.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numFinal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFinal.Name = "numFinal"
        Me.numFinal.Size = New System.Drawing.Size(40, 20)
        Me.numFinal.TabIndex = 65
        Me.numFinal.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(257, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Semana"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Semana"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(169, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Año"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(325, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Año"
        '
        'numInicio
        '
        Me.numInicio.Location = New System.Drawing.Point(103, 6)
        Me.numInicio.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numInicio.Name = "numInicio"
        Me.numInicio.Size = New System.Drawing.Size(40, 20)
        Me.numInicio.TabIndex = 64
        Me.numInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(227, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "al:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(988, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(79, 98)
        Me.Panel1.TabIndex = 38
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(15, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 3
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(45, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 4
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'grdOrdenamiento
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenamiento.DisplayLayout.Appearance = Appearance1
        Me.grdOrdenamiento.DisplayLayout.GroupByBox.Hidden = True
        Me.grdOrdenamiento.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdOrdenamiento.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenamiento.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdOrdenamiento.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdOrdenamiento.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdOrdenamiento.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdOrdenamiento.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdOrdenamiento.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenamiento.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdOrdenamiento.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdOrdenamiento.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenamiento.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdOrdenamiento.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdOrdenamiento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOrdenamiento.Location = New System.Drawing.Point(3, 26)
        Me.grdOrdenamiento.Name = "grdOrdenamiento"
        Me.grdOrdenamiento.Size = New System.Drawing.Size(1056, 300)
        Me.grdOrdenamiento.TabIndex = 47
        '
        'tbtSimulador
        '
        Me.tbtSimulador.Controls.Add(Me.tbpOrden)
        Me.tbtSimulador.Controls.Add(Me.tbpSimulacion)
        Me.tbtSimulador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtSimulador.Location = New System.Drawing.Point(0, 177)
        Me.tbtSimulador.Name = "tbtSimulador"
        Me.tbtSimulador.SelectedIndex = 0
        Me.tbtSimulador.Size = New System.Drawing.Size(1070, 355)
        Me.tbtSimulador.TabIndex = 48
        '
        'tbpOrden
        '
        Me.tbpOrden.Controls.Add(Me.grdOrdenamiento)
        Me.tbpOrden.Controls.Add(Me.Panel5)
        Me.tbpOrden.Location = New System.Drawing.Point(4, 22)
        Me.tbpOrden.Name = "tbpOrden"
        Me.tbpOrden.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOrden.Size = New System.Drawing.Size(1062, 329)
        Me.tbpOrden.TabIndex = 0
        Me.tbpOrden.Text = "Orden Simulación"
        Me.tbpOrden.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.chkSeleccionarTodos)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1056, 23)
        Me.Panel5.TabIndex = 81
        '
        'chkSeleccionarTodos
        '
        Me.chkSeleccionarTodos.AutoSize = True
        Me.chkSeleccionarTodos.Enabled = False
        Me.chkSeleccionarTodos.Location = New System.Drawing.Point(7, 3)
        Me.chkSeleccionarTodos.Name = "chkSeleccionarTodos"
        Me.chkSeleccionarTodos.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodos.TabIndex = 70
        Me.chkSeleccionarTodos.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodos.UseVisualStyleBackColor = True
        '
        'tbpSimulacion
        '
        Me.tbpSimulacion.Controls.Add(Me.grdSimulacion)
        Me.tbpSimulacion.Controls.Add(Me.Panel2)
        Me.tbpSimulacion.Location = New System.Drawing.Point(4, 22)
        Me.tbpSimulacion.Name = "tbpSimulacion"
        Me.tbpSimulacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSimulacion.Size = New System.Drawing.Size(1062, 329)
        Me.tbpSimulacion.TabIndex = 1
        Me.tbpSimulacion.Text = "Simulación"
        Me.tbpSimulacion.UseVisualStyleBackColor = True
        '
        'grdSimulacion
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSimulacion.DisplayLayout.Appearance = Appearance3
        Me.grdSimulacion.DisplayLayout.GroupByBox.Hidden = True
        Me.grdSimulacion.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdSimulacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdSimulacion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdSimulacion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdSimulacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdSimulacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSimulacion.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdSimulacion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdSimulacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdSimulacion.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdSimulacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSimulacion.Location = New System.Drawing.Point(3, 48)
        Me.grdSimulacion.Name = "grdSimulacion"
        Me.grdSimulacion.Size = New System.Drawing.Size(1056, 278)
        Me.grdSimulacion.TabIndex = 48
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkCambioArticulo)
        Me.Panel2.Controls.Add(Me.chkLimiteCapacidad)
        Me.Panel2.Controls.Add(Me.chkReacomodarPedidos)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.lblTiempoFinalizo)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.lblTiempoInicio)
        Me.Panel2.Controls.Add(Me.pnlProgress)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1056, 45)
        Me.Panel2.TabIndex = 50
        '
        'chkCambioArticulo
        '
        Me.chkCambioArticulo.AutoSize = True
        Me.chkCambioArticulo.Location = New System.Drawing.Point(164, 7)
        Me.chkCambioArticulo.Name = "chkCambioArticulo"
        Me.chkCambioArticulo.Size = New System.Drawing.Size(99, 17)
        Me.chkCambioArticulo.TabIndex = 72
        Me.chkCambioArticulo.Text = "Cambio Articulo"
        Me.chkCambioArticulo.UseVisualStyleBackColor = True
        Me.chkCambioArticulo.Visible = False
        '
        'chkLimiteCapacidad
        '
        Me.chkLimiteCapacidad.AutoSize = True
        Me.chkLimiteCapacidad.Location = New System.Drawing.Point(18, 25)
        Me.chkLimiteCapacidad.Name = "chkLimiteCapacidad"
        Me.chkLimiteCapacidad.Size = New System.Drawing.Size(106, 17)
        Me.chkLimiteCapacidad.TabIndex = 71
        Me.chkLimiteCapacidad.Text = "Limite capacidad"
        Me.chkLimiteCapacidad.UseVisualStyleBackColor = True
        Me.chkLimiteCapacidad.Visible = False
        '
        'chkReacomodarPedidos
        '
        Me.chkReacomodarPedidos.AutoSize = True
        Me.chkReacomodarPedidos.Checked = True
        Me.chkReacomodarPedidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReacomodarPedidos.Location = New System.Drawing.Point(18, 7)
        Me.chkReacomodarPedidos.Name = "chkReacomodarPedidos"
        Me.chkReacomodarPedidos.Size = New System.Drawing.Size(128, 17)
        Me.chkReacomodarPedidos.TabIndex = 70
        Me.chkReacomodarPedidos.Text = "Reacomodar Pedidos"
        Me.chkReacomodarPedidos.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(409, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 13)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "Fin:"
        '
        'lblTiempoFinalizo
        '
        Me.lblTiempoFinalizo.AutoSize = True
        Me.lblTiempoFinalizo.Location = New System.Drawing.Point(438, 18)
        Me.lblTiempoFinalizo.Name = "lblTiempoFinalizo"
        Me.lblTiempoFinalizo.Size = New System.Drawing.Size(49, 13)
        Me.lblTiempoFinalizo.TabIndex = 42
        Me.lblTiempoFinalizo.Text = "00:00:00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(286, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 41
        Me.Label13.Text = "Inicio:"
        '
        'lblTiempoInicio
        '
        Me.lblTiempoInicio.AutoSize = True
        Me.lblTiempoInicio.Location = New System.Drawing.Point(326, 18)
        Me.lblTiempoInicio.Name = "lblTiempoInicio"
        Me.lblTiempoInicio.Size = New System.Drawing.Size(49, 13)
        Me.lblTiempoInicio.TabIndex = 40
        Me.lblTiempoInicio.Text = "00:00:00"
        '
        'pnlProgress
        '
        Me.pnlProgress.Controls.Add(Me.lblPorcentaje)
        Me.pnlProgress.Controls.Add(Me.lblProceso)
        Me.pnlProgress.Controls.Add(Me.prgProgresoSimulacion)
        Me.pnlProgress.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlProgress.Location = New System.Drawing.Point(577, 0)
        Me.pnlProgress.Name = "pnlProgress"
        Me.pnlProgress.Size = New System.Drawing.Size(479, 45)
        Me.pnlProgress.TabIndex = 39
        Me.pnlProgress.Visible = False
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.Location = New System.Drawing.Point(37, 18)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(24, 13)
        Me.lblPorcentaje.TabIndex = 73
        Me.lblPorcentaje.Text = "0 %"
        '
        'lblProceso
        '
        Me.lblProceso.AutoSize = True
        Me.lblProceso.Location = New System.Drawing.Point(64, 18)
        Me.lblProceso.Name = "lblProceso"
        Me.lblProceso.Size = New System.Drawing.Size(46, 13)
        Me.lblProceso.TabIndex = 72
        Me.lblProceso.Text = "Proceso"
        '
        'prgProgresoSimulacion
        '
        Me.prgProgresoSimulacion.Location = New System.Drawing.Point(119, 13)
        Me.prgProgresoSimulacion.Name = "prgProgresoSimulacion"
        Me.prgProgresoSimulacion.Size = New System.Drawing.Size(337, 23)
        Me.prgProgresoSimulacion.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(237, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'frmOrdenamientoSimulacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1070, 592)
        Me.Controls.Add(Me.tbtSimulador)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimumSize = New System.Drawing.Size(521, 565)
        Me.Name = "frmOrdenamientoSimulacion"
        Me.Text = "Ordenamiento Simulación"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.pnlDatos.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlRangoFecha.ResumeLayout(False)
        Me.pnlRangoFecha.PerformLayout()
        Me.pnlRango.ResumeLayout(False)
        Me.pnlRango.PerformLayout()
        CType(Me.numAnioFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAnioInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdOrdenamiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtSimulador.ResumeLayout(False)
        Me.tbpOrden.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.tbpSimulacion.ResumeLayout(False)
        CType(Me.grdSimulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlProgress.ResumeLayout(False)
        Me.pnlProgress.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents numFinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents numInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkTodoRangoFechas As System.Windows.Forms.CheckBox
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents numAnioFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numAnioInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents grdOrdenamiento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlRangoFecha As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnGuardarSimulacion As System.Windows.Forms.Button
    Friend WithEvents tbtSimulador As System.Windows.Forms.TabControl
    Friend WithEvents tbpOrden As System.Windows.Forms.TabPage
    Friend WithEvents tbpSimulacion As System.Windows.Forms.TabPage
    Friend WithEvents grdSimulacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents prgProgresoSimulacion As System.Windows.Forms.ProgressBar
    Friend WithEvents pnlProgress As System.Windows.Forms.Panel
    Friend WithEvents lblProceso As System.Windows.Forms.Label
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents btnEjecutarOrdenamiento As System.Windows.Forms.Button
    Friend WithEvents lblCargarDatos As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnNuevaSimulacion As System.Windows.Forms.Button
    Friend WithEvents btnGuardarCambiosOrden As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCancelarNueva As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblIdUltimaConfiguracion As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents pnlRango As System.Windows.Forms.Panel
    Friend WithEvents chkSeleccionarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTiempoFinalizo As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblTiempoInicio As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkLimiteCapacidad As System.Windows.Forms.CheckBox
    Friend WithEvents chkReacomodarPedidos As System.Windows.Forms.CheckBox
    Friend WithEvents chkCambioArticulo As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents expTablaSimulacion As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnGenerarReporte As System.Windows.Forms.Button
    Friend WithEvents lblExportarPDF As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
