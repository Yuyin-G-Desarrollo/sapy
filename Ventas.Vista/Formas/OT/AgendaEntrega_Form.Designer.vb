<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgendaEntrega_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgendaEntrega_Form))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.lblTextoCancelarembarque = New System.Windows.Forms.Label()
        Me.lblTextoLiberarUnidad = New System.Windows.Forms.Label()
        Me.lblTextoEdittar = New System.Windows.Forms.Label()
        Me.lblTextoAgendar = New System.Windows.Forms.Label()
        Me.btnCancelarApartado = New System.Windows.Forms.Button()
        Me.btnLiberarUnidad = New System.Windows.Forms.Button()
        Me.btnEditarAgenda = New System.Windows.Forms.Button()
        Me.btnAgendar = New System.Windows.Forms.Button()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblTextoCerrar = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblVehiculoEnRuta = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.spcTiposVistaAgenda = New System.Windows.Forms.SplitContainer()
        Me.pnlAgendaLista = New System.Windows.Forms.Panel()
        Me.grdAgendaTipoLista = New DevExpress.XtraGrid.GridControl()
        Me.grvAgendaLista = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Renglon = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Seleccionar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Cliente = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RequiereCita = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.OTMostrar = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.FechaEnvio = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.OrdenTrabajo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Pares = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.tiem_nombre = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandC = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.FechaCita = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.HoraCita = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Clave = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.NumOper = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandEmbarque = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.FechaEmbarque = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.HoraEmbarque = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.HoraEstimadaRegreso = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Unidad = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.UnidadID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.UnidadOcupada = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Paquetería = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Operador = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PaqueteriaId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.OperadorId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Observ = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.OrdenTrabajoCoppel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.pnlAgendaCalendario = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.grpMostrar = New System.Windows.Forms.GroupBox()
        Me.chboxAgendado = New System.Windows.Forms.CheckBox()
        Me.chboxSinAgendar = New System.Windows.Forms.CheckBox()
        Me.grpFechaEmbarque = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbHoraFechaEntregaFin = New System.Windows.Forms.ComboBox()
        Me.cmbHoraFechaEntregaInicio = New System.Windows.Forms.ComboBox()
        Me.lblFechaEmbarqueAl = New System.Windows.Forms.Label()
        Me.dtpFechaEmbarqueAl = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaEmbarqueDel = New System.Windows.Forms.DateTimePicker()
        Me.lblTextoFechaEmbarqueDel = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblTextoMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.grpVerComo = New System.Windows.Forms.GroupBox()
        Me.rdbAgenda = New System.Windows.Forms.RadioButton()
        Me.rdbLista = New System.Windows.Forms.RadioButton()
        Me.cmbUnidad = New System.Windows.Forms.ComboBox()
        Me.lblUnidad = New System.Windows.Forms.Label()
        Me.cmbTipoEntregaMercancia = New System.Windows.Forms.ComboBox()
        Me.lblEntregaMercancia = New System.Windows.Forms.Label()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cmsSeleccionMultiple = New System.Windows.Forms.ContextMenuStrip()
        Me.tmsiAgendar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmsiEditarAgenda = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmsiMostrarOTs = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        CType(Me.spcTiposVistaAgenda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcTiposVistaAgenda.Panel1.SuspendLayout()
        Me.spcTiposVistaAgenda.Panel2.SuspendLayout()
        Me.spcTiposVistaAgenda.SuspendLayout()
        Me.pnlAgendaLista.SuspendLayout()
        CType(Me.grdAgendaTipoLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvAgendaLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.grpMostrar.SuspendLayout()
        Me.grpFechaEmbarque.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.grpVerComo.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.cmsSeleccionMultiple.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(86, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1276, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1276, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.Panel14)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1276, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1038, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(174, 20)
        Me.lblTitulo.TabIndex = 47
        Me.lblTitulo.Text = "Agenda de Entregas"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.lblTextoCancelarembarque)
        Me.Panel14.Controls.Add(Me.lblTextoLiberarUnidad)
        Me.Panel14.Controls.Add(Me.lblTextoEdittar)
        Me.Panel14.Controls.Add(Me.lblTextoAgendar)
        Me.Panel14.Controls.Add(Me.btnCancelarApartado)
        Me.Panel14.Controls.Add(Me.btnLiberarUnidad)
        Me.Panel14.Controls.Add(Me.btnEditarAgenda)
        Me.Panel14.Controls.Add(Me.btnAgendar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(703, 59)
        Me.Panel14.TabIndex = 46
        '
        'lblTextoCancelarembarque
        '
        Me.lblTextoCancelarembarque.AutoSize = True
        Me.lblTextoCancelarembarque.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoCancelarembarque.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoCancelarembarque.Location = New System.Drawing.Point(145, 41)
        Me.lblTextoCancelarembarque.Name = "lblTextoCancelarembarque"
        Me.lblTextoCancelarembarque.Size = New System.Drawing.Size(100, 13)
        Me.lblTextoCancelarembarque.TabIndex = 73
        Me.lblTextoCancelarembarque.Text = "Cancelar Embarque"
        '
        'lblTextoLiberarUnidad
        '
        Me.lblTextoLiberarUnidad.AutoSize = True
        Me.lblTextoLiberarUnidad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoLiberarUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoLiberarUnidad.Location = New System.Drawing.Point(251, 41)
        Me.lblTextoLiberarUnidad.Name = "lblTextoLiberarUnidad"
        Me.lblTextoLiberarUnidad.Size = New System.Drawing.Size(76, 13)
        Me.lblTextoLiberarUnidad.TabIndex = 73
        Me.lblTextoLiberarUnidad.Text = "Liberar Unidad"
        Me.lblTextoLiberarUnidad.Visible = False
        '
        'lblTextoEdittar
        '
        Me.lblTextoEdittar.AutoSize = True
        Me.lblTextoEdittar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoEdittar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoEdittar.Location = New System.Drawing.Point(71, 41)
        Me.lblTextoEdittar.Name = "lblTextoEdittar"
        Me.lblTextoEdittar.Size = New System.Drawing.Size(74, 13)
        Me.lblTextoEdittar.TabIndex = 73
        Me.lblTextoEdittar.Text = "Editar Agenda"
        '
        'lblTextoAgendar
        '
        Me.lblTextoAgendar.AutoSize = True
        Me.lblTextoAgendar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoAgendar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoAgendar.Location = New System.Drawing.Point(18, 41)
        Me.lblTextoAgendar.Name = "lblTextoAgendar"
        Me.lblTextoAgendar.Size = New System.Drawing.Size(47, 13)
        Me.lblTextoAgendar.TabIndex = 73
        Me.lblTextoAgendar.Text = "Agendar"
        '
        'btnCancelarApartado
        '
        Me.btnCancelarApartado.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCancelarApartado.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarApartado.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelarApartado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarApartado.Location = New System.Drawing.Point(176, 9)
        Me.btnCancelarApartado.Name = "btnCancelarApartado"
        Me.btnCancelarApartado.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarApartado.TabIndex = 74
        Me.btnCancelarApartado.UseVisualStyleBackColor = True
        '
        'btnLiberarUnidad
        '
        Me.btnLiberarUnidad.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnLiberarUnidad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLiberarUnidad.Image = CType(resources.GetObject("btnLiberarUnidad.Image"), System.Drawing.Image)
        Me.btnLiberarUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLiberarUnidad.Location = New System.Drawing.Point(273, 9)
        Me.btnLiberarUnidad.Name = "btnLiberarUnidad"
        Me.btnLiberarUnidad.Size = New System.Drawing.Size(32, 32)
        Me.btnLiberarUnidad.TabIndex = 74
        Me.btnLiberarUnidad.UseVisualStyleBackColor = True
        Me.btnLiberarUnidad.Visible = False
        '
        'btnEditarAgenda
        '
        Me.btnEditarAgenda.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEditarAgenda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEditarAgenda.Image = Global.Ventas.Vista.My.Resources.Resources.editar_322
        Me.btnEditarAgenda.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEditarAgenda.Location = New System.Drawing.Point(92, 9)
        Me.btnEditarAgenda.Name = "btnEditarAgenda"
        Me.btnEditarAgenda.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarAgenda.TabIndex = 74
        Me.btnEditarAgenda.UseVisualStyleBackColor = True
        '
        'btnAgendar
        '
        Me.btnAgendar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAgendar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAgendar.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAgendar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgendar.Location = New System.Drawing.Point(25, 9)
        Me.btnAgendar.Name = "btnAgendar"
        Me.btnAgendar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgendar.TabIndex = 74
        Me.btnAgendar.UseVisualStyleBackColor = True
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblTextoCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1132, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblTextoCerrar
        '
        Me.lblTextoCerrar.AutoSize = True
        Me.lblTextoCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoCerrar.Location = New System.Drawing.Point(85, 48)
        Me.lblTextoCerrar.Name = "lblTextoCerrar"
        Me.lblTextoCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblTextoCerrar.TabIndex = 0
        Me.lblTextoCerrar.Text = "Cerrar"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.GroupBox1)
        Me.pnlPie.Controls.Add(Me.Label31)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 479)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1276, 71)
        Me.pnlPie.TabIndex = 64
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(989, 34)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 135
        Me.lblFechaUltimaActualizacion.Text = "24/05/2016 01:54 PM"
        Me.lblFechaUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFechaUltimaActualizacion.Visible = False
        '
        'lblTextoUltimaDistribucion
        '
        Me.lblTextoUltimaDistribucion.AutoSize = True
        Me.lblTextoUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(877, 34)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(105, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 136
        Me.lblTextoUltimaDistribucion.Text = "Última Actualización:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTextoUltimaDistribucion.Visible = False
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(12, 34)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 134
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblVehiculoEnRuta)
        Me.GroupBox1.Location = New System.Drawing.Point(107, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(122, 65)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Vehiculo disponible"
        '
        'lblVehiculoEnRuta
        '
        Me.lblVehiculoEnRuta.AutoSize = True
        Me.lblVehiculoEnRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehiculoEnRuta.ForeColor = System.Drawing.Color.Blue
        Me.lblVehiculoEnRuta.Location = New System.Drawing.Point(18, 21)
        Me.lblVehiculoEnRuta.Name = "lblVehiculoEnRuta"
        Me.lblVehiculoEnRuta.Size = New System.Drawing.Size(86, 13)
        Me.lblVehiculoEnRuta.TabIndex = 75
        Me.lblVehiculoEnRuta.Text = "Vehículo en ruta"
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(12, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(86, 24)
        Me.Label31.TabIndex = 133
        Me.Label31.Text = "Registros"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.spcTiposVistaAgenda)
        Me.pnlListaCliente.Controls.Add(Me.pnlParametros)
        Me.pnlListaCliente.Controls.Add(Me.pnlPie)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(1276, 550)
        Me.pnlListaCliente.TabIndex = 3
        '
        'spcTiposVistaAgenda
        '
        Me.spcTiposVistaAgenda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcTiposVistaAgenda.IsSplitterFixed = True
        Me.spcTiposVistaAgenda.Location = New System.Drawing.Point(0, 102)
        Me.spcTiposVistaAgenda.Name = "spcTiposVistaAgenda"
        Me.spcTiposVistaAgenda.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcTiposVistaAgenda.Panel1
        '
        Me.spcTiposVistaAgenda.Panel1.Controls.Add(Me.pnlAgendaLista)
        Me.spcTiposVistaAgenda.Panel1MinSize = 0
        '
        'spcTiposVistaAgenda.Panel2
        '
        Me.spcTiposVistaAgenda.Panel2.Controls.Add(Me.pnlAgendaCalendario)
        Me.spcTiposVistaAgenda.Panel2MinSize = 0
        Me.spcTiposVistaAgenda.Size = New System.Drawing.Size(1276, 377)
        Me.spcTiposVistaAgenda.SplitterDistance = 300
        Me.spcTiposVistaAgenda.SplitterWidth = 1
        Me.spcTiposVistaAgenda.TabIndex = 66
        '
        'pnlAgendaLista
        '
        Me.pnlAgendaLista.Controls.Add(Me.grdAgendaTipoLista)
        Me.pnlAgendaLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgendaLista.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgendaLista.Name = "pnlAgendaLista"
        Me.pnlAgendaLista.Size = New System.Drawing.Size(1276, 300)
        Me.pnlAgendaLista.TabIndex = 0
        '
        'grdAgendaTipoLista
        '
        Me.grdAgendaTipoLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAgendaTipoLista.Location = New System.Drawing.Point(0, 0)
        Me.grdAgendaTipoLista.MainView = Me.grvAgendaLista
        Me.grdAgendaTipoLista.Name = "grdAgendaTipoLista"
        Me.grdAgendaTipoLista.Size = New System.Drawing.Size(1276, 300)
        Me.grdAgendaTipoLista.TabIndex = 0
        Me.grdAgendaTipoLista.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvAgendaLista})
        '
        'grvAgendaLista
        '
        Me.grvAgendaLista.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.bandC, Me.bandEmbarque, Me.gridBand3})
        Me.grvAgendaLista.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.Seleccionar, Me.Cliente, Me.OrdenTrabajo, Me.Pares, Me.tiem_nombre, Me.FechaCita, Me.HoraCita, Me.Clave, Me.NumOper, Me.FechaEmbarque, Me.HoraEmbarque, Me.Unidad, Me.Paquetería, Me.Operador, Me.Observ, Me.UnidadID, Me.Renglon, Me.OTMostrar, Me.UnidadOcupada, Me.PaqueteriaId, Me.OperadorId, Me.RequiereCita, Me.FechaEnvio, Me.HoraEstimadaRegreso, Me.OrdenTrabajoCoppel})
        Me.grvAgendaLista.GridControl = Me.grdAgendaTipoLista
        Me.grvAgendaLista.Name = "grvAgendaLista"
        Me.grvAgendaLista.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grvAgendaLista.OptionsSelection.MultiSelect = True
        Me.grvAgendaLista.OptionsView.ShowAutoFilterRow = True
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.Renglon)
        Me.gridBand2.Columns.Add(Me.Seleccionar)
        Me.gridBand2.Columns.Add(Me.Cliente)
        Me.gridBand2.Columns.Add(Me.RequiereCita)
        Me.gridBand2.Columns.Add(Me.OTMostrar)
        Me.gridBand2.Columns.Add(Me.FechaEnvio)
        Me.gridBand2.Columns.Add(Me.OrdenTrabajo)
        Me.gridBand2.Columns.Add(Me.Pares)
        Me.gridBand2.Columns.Add(Me.tiem_nombre)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 670
        '
        'Renglon
        '
        Me.Renglon.Caption = "#"
        Me.Renglon.FieldName = "#"
        Me.Renglon.Name = "Renglon"
        Me.Renglon.OptionsColumn.AllowEdit = False
        Me.Renglon.OptionsColumn.ReadOnly = True
        Me.Renglon.Visible = True
        Me.Renglon.Width = 25
        '
        'Seleccionar
        '
        Me.Seleccionar.AppearanceHeader.Options.UseTextOptions = True
        Me.Seleccionar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Seleccionar.Caption = " "
        Me.Seleccionar.FieldName = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Visible = True
        Me.Seleccionar.Width = 25
        '
        'Cliente
        '
        Me.Cliente.AppearanceHeader.Options.UseTextOptions = True
        Me.Cliente.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Cliente.Caption = "Cliente"
        Me.Cliente.FieldName = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.OptionsColumn.AllowEdit = False
        Me.Cliente.Visible = True
        Me.Cliente.Width = 300
        '
        'RequiereCita
        '
        Me.RequiereCita.Caption = "Cita"
        Me.RequiereCita.FieldName = "RequiereCita"
        Me.RequiereCita.Name = "RequiereCita"
        Me.RequiereCita.OptionsColumn.AllowEdit = False
        Me.RequiereCita.Visible = True
        Me.RequiereCita.Width = 30
        '
        'OTMostrar
        '
        Me.OTMostrar.Caption = "OT"
        Me.OTMostrar.FieldName = "OTMostrar"
        Me.OTMostrar.Name = "OTMostrar"
        Me.OTMostrar.OptionsColumn.AllowEdit = False
        Me.OTMostrar.Visible = True
        Me.OTMostrar.Width = 60
        '
        'FechaEnvio
        '
        Me.FechaEnvio.Caption = "F Envío"
        Me.FechaEnvio.FieldName = "FechaEnvio"
        Me.FechaEnvio.Name = "FechaEnvio"
        Me.FechaEnvio.OptionsColumn.AllowEdit = False
        Me.FechaEnvio.Visible = True
        Me.FechaEnvio.Width = 68
        '
        'OrdenTrabajo
        '
        Me.OrdenTrabajo.AppearanceHeader.Options.UseTextOptions = True
        Me.OrdenTrabajo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.OrdenTrabajo.Caption = "OTBD"
        Me.OrdenTrabajo.FieldName = "OrdenTrabajo"
        Me.OrdenTrabajo.Name = "OrdenTrabajo"
        Me.OrdenTrabajo.OptionsColumn.AllowEdit = False
        Me.OrdenTrabajo.Width = 60
        '
        'Pares
        '
        Me.Pares.AppearanceHeader.Options.UseTextOptions = True
        Me.Pares.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Pares.Caption = "Pares"
        Me.Pares.FieldName = "Pares"
        Me.Pares.Name = "Pares"
        Me.Pares.OptionsColumn.AllowEdit = False
        Me.Pares.OptionsColumn.ReadOnly = True
        Me.Pares.Visible = True
        Me.Pares.Width = 60
        '
        'tiem_nombre
        '
        Me.tiem_nombre.AppearanceHeader.Options.UseTextOptions = True
        Me.tiem_nombre.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.tiem_nombre.Caption = "T Empaque"
        Me.tiem_nombre.FieldName = "tiem_nombre"
        Me.tiem_nombre.Name = "tiem_nombre"
        Me.tiem_nombre.OptionsColumn.AllowEdit = False
        Me.tiem_nombre.OptionsColumn.ReadOnly = True
        Me.tiem_nombre.Visible = True
        Me.tiem_nombre.Width = 102
        '
        'bandC
        '
        Me.bandC.AppearanceHeader.Options.UseTextOptions = True
        Me.bandC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandC.Caption = "Cita"
        Me.bandC.Columns.Add(Me.FechaCita)
        Me.bandC.Columns.Add(Me.HoraCita)
        Me.bandC.Columns.Add(Me.Clave)
        Me.bandC.Columns.Add(Me.NumOper)
        Me.bandC.Name = "bandC"
        Me.bandC.VisibleIndex = 1
        Me.bandC.Width = 360
        '
        'FechaCita
        '
        Me.FechaCita.AppearanceHeader.Options.UseTextOptions = True
        Me.FechaCita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FechaCita.Caption = "Fecha"
        Me.FechaCita.FieldName = "FechaCita"
        Me.FechaCita.Name = "FechaCita"
        Me.FechaCita.OptionsColumn.AllowEdit = False
        Me.FechaCita.OptionsColumn.ReadOnly = True
        Me.FechaCita.Visible = True
        Me.FechaCita.Width = 100
        '
        'HoraCita
        '
        Me.HoraCita.AppearanceHeader.Options.UseTextOptions = True
        Me.HoraCita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.HoraCita.Caption = "Hora"
        Me.HoraCita.FieldName = "HoraCita"
        Me.HoraCita.Name = "HoraCita"
        Me.HoraCita.OptionsColumn.AllowEdit = False
        Me.HoraCita.OptionsColumn.ReadOnly = True
        Me.HoraCita.Visible = True
        Me.HoraCita.Width = 100
        '
        'Clave
        '
        Me.Clave.AppearanceHeader.Options.UseTextOptions = True
        Me.Clave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Clave.Caption = "Clave"
        Me.Clave.FieldName = "Clave"
        Me.Clave.Name = "Clave"
        Me.Clave.OptionsColumn.AllowEdit = False
        Me.Clave.OptionsColumn.ReadOnly = True
        Me.Clave.Visible = True
        Me.Clave.Width = 90
        '
        'NumOper
        '
        Me.NumOper.AppearanceHeader.Options.UseTextOptions = True
        Me.NumOper.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.NumOper.Caption = "#Oper"
        Me.NumOper.FieldName = "NumOper"
        Me.NumOper.Name = "NumOper"
        Me.NumOper.OptionsColumn.AllowEdit = False
        Me.NumOper.OptionsColumn.ReadOnly = True
        Me.NumOper.Visible = True
        Me.NumOper.Width = 70
        '
        'bandEmbarque
        '
        Me.bandEmbarque.AppearanceHeader.Options.UseTextOptions = True
        Me.bandEmbarque.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandEmbarque.Caption = "Embarque"
        Me.bandEmbarque.Columns.Add(Me.FechaEmbarque)
        Me.bandEmbarque.Columns.Add(Me.HoraEmbarque)
        Me.bandEmbarque.Columns.Add(Me.HoraEstimadaRegreso)
        Me.bandEmbarque.Columns.Add(Me.Unidad)
        Me.bandEmbarque.Columns.Add(Me.UnidadID)
        Me.bandEmbarque.Columns.Add(Me.UnidadOcupada)
        Me.bandEmbarque.Columns.Add(Me.Paquetería)
        Me.bandEmbarque.Columns.Add(Me.Operador)
        Me.bandEmbarque.Columns.Add(Me.PaqueteriaId)
        Me.bandEmbarque.Name = "bandEmbarque"
        Me.bandEmbarque.VisibleIndex = 2
        Me.bandEmbarque.Width = 950
        '
        'FechaEmbarque
        '
        Me.FechaEmbarque.AppearanceHeader.Options.UseTextOptions = True
        Me.FechaEmbarque.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FechaEmbarque.Caption = "Fecha"
        Me.FechaEmbarque.FieldName = "FechaEmbarque"
        Me.FechaEmbarque.Name = "FechaEmbarque"
        Me.FechaEmbarque.OptionsColumn.AllowEdit = False
        Me.FechaEmbarque.OptionsColumn.ReadOnly = True
        Me.FechaEmbarque.Visible = True
        Me.FechaEmbarque.Width = 100
        '
        'HoraEmbarque
        '
        Me.HoraEmbarque.AppearanceHeader.Options.UseTextOptions = True
        Me.HoraEmbarque.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.HoraEmbarque.Caption = "Hora"
        Me.HoraEmbarque.FieldName = "HoraEmbarque"
        Me.HoraEmbarque.Name = "HoraEmbarque"
        Me.HoraEmbarque.OptionsColumn.AllowEdit = False
        Me.HoraEmbarque.OptionsColumn.ReadOnly = True
        Me.HoraEmbarque.Visible = True
        Me.HoraEmbarque.Width = 100
        '
        'HoraEstimadaRegreso
        '
        Me.HoraEstimadaRegreso.Caption = "Hr Estimada Regreso"
        Me.HoraEstimadaRegreso.FieldName = "HoraEstimadaRegreso"
        Me.HoraEstimadaRegreso.Name = "HoraEstimadaRegreso"
        Me.HoraEstimadaRegreso.OptionsColumn.AllowEdit = False
        Me.HoraEstimadaRegreso.Visible = True
        Me.HoraEstimadaRegreso.Width = 109
        '
        'Unidad
        '
        Me.Unidad.AppearanceHeader.Options.UseTextOptions = True
        Me.Unidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Unidad.Caption = "Unidad"
        Me.Unidad.FieldName = "Unidad"
        Me.Unidad.Name = "Unidad"
        Me.Unidad.OptionsColumn.AllowEdit = False
        Me.Unidad.OptionsColumn.ReadOnly = True
        Me.Unidad.Visible = True
        Me.Unidad.Width = 200
        '
        'UnidadID
        '
        Me.UnidadID.AppearanceHeader.Options.UseTextOptions = True
        Me.UnidadID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.UnidadID.Caption = "UnidadID"
        Me.UnidadID.FieldName = "UnidadID"
        Me.UnidadID.Name = "UnidadID"
        Me.UnidadID.OptionsColumn.AllowEdit = False
        Me.UnidadID.OptionsColumn.ReadOnly = True
        Me.UnidadID.Visible = True
        '
        'UnidadOcupada
        '
        Me.UnidadOcupada.Caption = "UnidadOcupada"
        Me.UnidadOcupada.FieldName = "UnidadOcupada"
        Me.UnidadOcupada.Name = "UnidadOcupada"
        Me.UnidadOcupada.OptionsColumn.AllowEdit = False
        '
        'Paquetería
        '
        Me.Paquetería.AppearanceHeader.Options.UseTextOptions = True
        Me.Paquetería.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Paquetería.Caption = "Paquetería"
        Me.Paquetería.FieldName = "Paquetería"
        Me.Paquetería.Name = "Paquetería"
        Me.Paquetería.OptionsColumn.AllowEdit = False
        Me.Paquetería.OptionsColumn.ReadOnly = True
        Me.Paquetería.Visible = True
        Me.Paquetería.Width = 166
        '
        'Operador
        '
        Me.Operador.AppearanceHeader.Options.UseTextOptions = True
        Me.Operador.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Operador.Caption = "Operador"
        Me.Operador.FieldName = "Operador"
        Me.Operador.Name = "Operador"
        Me.Operador.OptionsColumn.AllowEdit = False
        Me.Operador.OptionsColumn.ReadOnly = True
        Me.Operador.Visible = True
        Me.Operador.Width = 200
        '
        'PaqueteriaId
        '
        Me.PaqueteriaId.Caption = "PaqueteriaId"
        Me.PaqueteriaId.FieldName = "PaqueteriaId"
        Me.PaqueteriaId.Name = "PaqueteriaId"
        Me.PaqueteriaId.OptionsColumn.AllowEdit = False
        '
        'gridBand3
        '
        Me.gridBand3.Columns.Add(Me.OperadorId)
        Me.gridBand3.Columns.Add(Me.Observ)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 3
        Me.gridBand3.Width = 150
        '
        'OperadorId
        '
        Me.OperadorId.Caption = "OperadorId"
        Me.OperadorId.FieldName = "OperadorId"
        Me.OperadorId.Name = "OperadorId"
        '
        'Observ
        '
        Me.Observ.AppearanceHeader.Options.UseTextOptions = True
        Me.Observ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Observ.Caption = "Observ"
        Me.Observ.FieldName = "Observ"
        Me.Observ.Name = "Observ"
        Me.Observ.OptionsColumn.AllowEdit = False
        Me.Observ.OptionsColumn.ReadOnly = True
        Me.Observ.Visible = True
        Me.Observ.Width = 150
        '
        'OrdenTrabajoCoppel
        '
        Me.OrdenTrabajoCoppel.Caption = "OrdenTrabajoCoppel"
        Me.OrdenTrabajoCoppel.FieldName = "OrdenTrabajoCoppel"
        Me.OrdenTrabajoCoppel.Name = "OrdenTrabajoCoppel"
        '
        'pnlAgendaCalendario
        '
        Me.pnlAgendaCalendario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAgendaCalendario.Location = New System.Drawing.Point(0, 0)
        Me.pnlAgendaCalendario.Name = "pnlAgendaCalendario"
        Me.pnlAgendaCalendario.Size = New System.Drawing.Size(1276, 76)
        Me.pnlAgendaCalendario.TabIndex = 1
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.grpMostrar)
        Me.pnlParametros.Controls.Add(Me.grpFechaEmbarque)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Controls.Add(Me.lblTextoMostrar)
        Me.pnlParametros.Controls.Add(Me.btnMostrar)
        Me.pnlParametros.Controls.Add(Me.grpVerComo)
        Me.pnlParametros.Controls.Add(Me.cmbUnidad)
        Me.pnlParametros.Controls.Add(Me.lblUnidad)
        Me.pnlParametros.Controls.Add(Me.cmbTipoEntregaMercancia)
        Me.pnlParametros.Controls.Add(Me.lblEntregaMercancia)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 0)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1276, 102)
        Me.pnlParametros.TabIndex = 65
        '
        'grpMostrar
        '
        Me.grpMostrar.Controls.Add(Me.chboxAgendado)
        Me.grpMostrar.Controls.Add(Me.chboxSinAgendar)
        Me.grpMostrar.Location = New System.Drawing.Point(581, 29)
        Me.grpMostrar.Name = "grpMostrar"
        Me.grpMostrar.Size = New System.Drawing.Size(122, 68)
        Me.grpMostrar.TabIndex = 83
        Me.grpMostrar.TabStop = False
        '
        'chboxAgendado
        '
        Me.chboxAgendado.AutoSize = True
        Me.chboxAgendado.Checked = True
        Me.chboxAgendado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxAgendado.Location = New System.Drawing.Point(22, 43)
        Me.chboxAgendado.Name = "chboxAgendado"
        Me.chboxAgendado.Size = New System.Drawing.Size(75, 17)
        Me.chboxAgendado.TabIndex = 78
        Me.chboxAgendado.Text = "Agendado"
        Me.chboxAgendado.UseVisualStyleBackColor = True
        '
        'chboxSinAgendar
        '
        Me.chboxSinAgendar.AutoSize = True
        Me.chboxSinAgendar.Checked = True
        Me.chboxSinAgendar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chboxSinAgendar.Location = New System.Drawing.Point(22, 19)
        Me.chboxSinAgendar.Name = "chboxSinAgendar"
        Me.chboxSinAgendar.Size = New System.Drawing.Size(83, 17)
        Me.chboxSinAgendar.TabIndex = 79
        Me.chboxSinAgendar.Text = "Sin agendar"
        Me.chboxSinAgendar.UseVisualStyleBackColor = True
        '
        'grpFechaEmbarque
        '
        Me.grpFechaEmbarque.Controls.Add(Me.Label3)
        Me.grpFechaEmbarque.Controls.Add(Me.Label1)
        Me.grpFechaEmbarque.Controls.Add(Me.cmbHoraFechaEntregaFin)
        Me.grpFechaEmbarque.Controls.Add(Me.cmbHoraFechaEntregaInicio)
        Me.grpFechaEmbarque.Controls.Add(Me.lblFechaEmbarqueAl)
        Me.grpFechaEmbarque.Controls.Add(Me.dtpFechaEmbarqueAl)
        Me.grpFechaEmbarque.Controls.Add(Me.dtpFechaEmbarqueDel)
        Me.grpFechaEmbarque.Controls.Add(Me.lblTextoFechaEmbarqueDel)
        Me.grpFechaEmbarque.Location = New System.Drawing.Point(709, 29)
        Me.grpFechaEmbarque.Name = "grpFechaEmbarque"
        Me.grpFechaEmbarque.Size = New System.Drawing.Size(308, 68)
        Me.grpFechaEmbarque.TabIndex = 82
        Me.grpFechaEmbarque.TabStop = False
        Me.grpFechaEmbarque.Text = "Fecha embarque:"
        Me.grpFechaEmbarque.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(128, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "a:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Horas de:"
        '
        'cmbHoraFechaEntregaFin
        '
        Me.cmbHoraFechaEntregaFin.FormattingEnabled = True
        Me.cmbHoraFechaEntregaFin.Items.AddRange(New Object() {"00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"})
        Me.cmbHoraFechaEntregaFin.Location = New System.Drawing.Point(150, 43)
        Me.cmbHoraFechaEntregaFin.Name = "cmbHoraFechaEntregaFin"
        Me.cmbHoraFechaEntregaFin.Size = New System.Drawing.Size(53, 21)
        Me.cmbHoraFechaEntregaFin.TabIndex = 86
        Me.cmbHoraFechaEntregaFin.Text = "18:00"
        '
        'cmbHoraFechaEntregaInicio
        '
        Me.cmbHoraFechaEntregaInicio.FormattingEnabled = True
        Me.cmbHoraFechaEntregaInicio.Items.AddRange(New Object() {"00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"})
        Me.cmbHoraFechaEntregaInicio.Location = New System.Drawing.Point(68, 43)
        Me.cmbHoraFechaEntregaInicio.Name = "cmbHoraFechaEntregaInicio"
        Me.cmbHoraFechaEntregaInicio.Size = New System.Drawing.Size(53, 21)
        Me.cmbHoraFechaEntregaInicio.TabIndex = 87
        Me.cmbHoraFechaEntregaInicio.Text = "07:00"
        '
        'lblFechaEmbarqueAl
        '
        Me.lblFechaEmbarqueAl.AutoSize = True
        Me.lblFechaEmbarqueAl.Location = New System.Drawing.Point(160, 23)
        Me.lblFechaEmbarqueAl.Name = "lblFechaEmbarqueAl"
        Me.lblFechaEmbarqueAl.Size = New System.Drawing.Size(19, 13)
        Me.lblFechaEmbarqueAl.TabIndex = 85
        Me.lblFechaEmbarqueAl.Text = "Al:"
        '
        'dtpFechaEmbarqueAl
        '
        Me.dtpFechaEmbarqueAl.CustomFormat = ""
        Me.dtpFechaEmbarqueAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEmbarqueAl.Location = New System.Drawing.Point(185, 19)
        Me.dtpFechaEmbarqueAl.Name = "dtpFechaEmbarqueAl"
        Me.dtpFechaEmbarqueAl.Size = New System.Drawing.Size(108, 20)
        Me.dtpFechaEmbarqueAl.TabIndex = 84
        Me.dtpFechaEmbarqueAl.Value = New Date(2017, 4, 25, 15, 16, 0, 0)
        '
        'dtpFechaEmbarqueDel
        '
        Me.dtpFechaEmbarqueDel.CustomFormat = ""
        Me.dtpFechaEmbarqueDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEmbarqueDel.Location = New System.Drawing.Point(46, 19)
        Me.dtpFechaEmbarqueDel.Name = "dtpFechaEmbarqueDel"
        Me.dtpFechaEmbarqueDel.Size = New System.Drawing.Size(108, 20)
        Me.dtpFechaEmbarqueDel.TabIndex = 83
        Me.dtpFechaEmbarqueDel.Value = New Date(2017, 4, 25, 15, 16, 0, 0)
        '
        'lblTextoFechaEmbarqueDel
        '
        Me.lblTextoFechaEmbarqueDel.AutoSize = True
        Me.lblTextoFechaEmbarqueDel.Location = New System.Drawing.Point(14, 23)
        Me.lblTextoFechaEmbarqueDel.Name = "lblTextoFechaEmbarqueDel"
        Me.lblTextoFechaEmbarqueDel.Size = New System.Drawing.Size(26, 13)
        Me.lblTextoFechaEmbarqueDel.TabIndex = 82
        Me.lblTextoFechaEmbarqueDel.Text = "Del:"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1276, 27)
        Me.Panel6.TabIndex = 80
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImage = Global.Ventas.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Location = New System.Drawing.Point(1216, 3)
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
        Me.btnAbajo.Location = New System.Drawing.Point(1242, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'lblTextoMostrar
        '
        Me.lblTextoMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTextoMostrar.AutoSize = True
        Me.lblTextoMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTextoMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextoMostrar.Location = New System.Drawing.Point(1216, 72)
        Me.lblTextoMostrar.Name = "lblTextoMostrar"
        Me.lblTextoMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblTextoMostrar.TabIndex = 78
        Me.lblTextoMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(1220, 40)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 79
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'grpVerComo
        '
        Me.grpVerComo.Controls.Add(Me.rdbAgenda)
        Me.grpVerComo.Controls.Add(Me.rdbLista)
        Me.grpVerComo.Location = New System.Drawing.Point(464, 29)
        Me.grpVerComo.Name = "grpVerComo"
        Me.grpVerComo.Size = New System.Drawing.Size(111, 68)
        Me.grpVerComo.TabIndex = 76
        Me.grpVerComo.TabStop = False
        Me.grpVerComo.Text = "Ver como:"
        '
        'rdbAgenda
        '
        Me.rdbAgenda.AutoSize = True
        Me.rdbAgenda.Location = New System.Drawing.Point(31, 41)
        Me.rdbAgenda.Name = "rdbAgenda"
        Me.rdbAgenda.Size = New System.Drawing.Size(62, 17)
        Me.rdbAgenda.TabIndex = 0
        Me.rdbAgenda.Text = "Agenda"
        Me.rdbAgenda.UseVisualStyleBackColor = True
        '
        'rdbLista
        '
        Me.rdbLista.AutoSize = True
        Me.rdbLista.Checked = True
        Me.rdbLista.Location = New System.Drawing.Point(31, 19)
        Me.rdbLista.Name = "rdbLista"
        Me.rdbLista.Size = New System.Drawing.Size(47, 17)
        Me.rdbLista.TabIndex = 0
        Me.rdbLista.TabStop = True
        Me.rdbLista.Text = "Lista"
        Me.rdbLista.UseVisualStyleBackColor = True
        '
        'cmbUnidad
        '
        Me.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidad.FormattingEnabled = True
        Me.cmbUnidad.Location = New System.Drawing.Point(87, 66)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(297, 21)
        Me.cmbUnidad.TabIndex = 75
        '
        'lblUnidad
        '
        Me.lblUnidad.AutoSize = True
        Me.lblUnidad.Location = New System.Drawing.Point(21, 69)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(41, 13)
        Me.lblUnidad.TabIndex = 74
        Me.lblUnidad.Text = "Unidad"
        '
        'cmbTipoEntregaMercancia
        '
        Me.cmbTipoEntregaMercancia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoEntregaMercancia.FormattingEnabled = True
        Me.cmbTipoEntregaMercancia.Location = New System.Drawing.Point(145, 39)
        Me.cmbTipoEntregaMercancia.Name = "cmbTipoEntregaMercancia"
        Me.cmbTipoEntregaMercancia.Size = New System.Drawing.Size(297, 21)
        Me.cmbTipoEntregaMercancia.TabIndex = 73
        '
        'lblEntregaMercancia
        '
        Me.lblEntregaMercancia.AutoSize = True
        Me.lblEntregaMercancia.Location = New System.Drawing.Point(22, 42)
        Me.lblEntregaMercancia.Name = "lblEntregaMercancia"
        Me.lblEntregaMercancia.Size = New System.Drawing.Size(117, 13)
        Me.lblEntregaMercancia.TabIndex = 72
        Me.lblEntregaMercancia.Text = "Entregar mercancia en:"
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1276, 609)
        Me.pnlContenedor.TabIndex = 7
        '
        'GridColumn3
        '
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridBand1
        '
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = -1
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'cmsSeleccionMultiple
        '
        Me.cmsSeleccionMultiple.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tmsiAgendar, Me.tmsiEditarAgenda, Me.tmsiMostrarOTs})
        Me.cmsSeleccionMultiple.Name = "cmdTipoAgenda"
        Me.cmsSeleccionMultiple.Size = New System.Drawing.Size(143, 70)
        '
        'tmsiAgendar
        '
        Me.tmsiAgendar.Name = "tmsiAgendar"
        Me.tmsiAgendar.Size = New System.Drawing.Size(142, 22)
        Me.tmsiAgendar.Text = "Agendar"
        '
        'tmsiEditarAgenda
        '
        Me.tmsiEditarAgenda.Name = "tmsiEditarAgenda"
        Me.tmsiEditarAgenda.Size = New System.Drawing.Size(142, 22)
        Me.tmsiEditarAgenda.Text = "Editar Agenda"
        '
        'tmsiMostrarOTs
        '
        Me.tmsiMostrarOTs.Name = "tmsiMostrarOTs"
        Me.tmsiMostrarOTs.Size = New System.Drawing.Size(142, 22)
        Me.tmsiMostrarOTs.Text = "Mostrar OTs"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1208, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AgendaEntrega_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 609)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Name = "AgendaEntrega_Form"
        Me.Text = "Agenda de Entregas"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlListaCliente.ResumeLayout(False)
        Me.spcTiposVistaAgenda.Panel1.ResumeLayout(False)
        Me.spcTiposVistaAgenda.Panel2.ResumeLayout(False)
        CType(Me.spcTiposVistaAgenda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcTiposVistaAgenda.ResumeLayout(False)
        Me.pnlAgendaLista.ResumeLayout(False)
        CType(Me.grdAgendaTipoLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvAgendaLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.grpMostrar.ResumeLayout(False)
        Me.grpMostrar.PerformLayout()
        Me.grpFechaEmbarque.ResumeLayout(False)
        Me.grpFechaEmbarque.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.grpVerComo.ResumeLayout(False)
        Me.grpVerComo.PerformLayout()
        Me.pnlContenedor.ResumeLayout(False)
        Me.cmsSeleccionMultiple.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents lblTextoCerrar As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents lblTextoAgendar As System.Windows.Forms.Label
    Friend WithEvents btnAgendar As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents spcTiposVistaAgenda As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlAgendaLista As System.Windows.Forms.Panel
    Friend WithEvents pnlAgendaCalendario As System.Windows.Forms.Panel
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents cmbTipoEntregaMercancia As System.Windows.Forms.ComboBox
    Friend WithEvents lblEntregaMercancia As System.Windows.Forms.Label
    Friend WithEvents grpVerComo As System.Windows.Forms.GroupBox
    Friend WithEvents rdbAgenda As System.Windows.Forms.RadioButton
    Friend WithEvents rdbLista As System.Windows.Forms.RadioButton
    Friend WithEvents cmbUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnidad As System.Windows.Forms.Label
    Friend WithEvents lblTextoMostrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents grpFechaEmbarque As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaEmbarqueAl As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEmbarqueAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaEmbarqueDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTextoFechaEmbarqueDel As System.Windows.Forms.Label
    Friend WithEvents grpMostrar As System.Windows.Forms.GroupBox
    Friend WithEvents chboxAgendado As System.Windows.Forms.CheckBox
    Friend WithEvents chboxSinAgendar As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblVehiculoEnRuta As System.Windows.Forms.Label
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblFechaUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbHoraFechaEntregaFin As System.Windows.Forms.ComboBox
    Friend WithEvents cmbHoraFechaEntregaInicio As System.Windows.Forms.ComboBox
    Friend WithEvents lblTextoLiberarUnidad As System.Windows.Forms.Label
    Friend WithEvents btnLiberarUnidad As System.Windows.Forms.Button
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents grdAgendaTipoLista As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvAgendaLista As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents Renglon As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Seleccionar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Cliente As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents OTMostrar As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents OrdenTrabajo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Pares As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents tiem_nombre As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FechaCita As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents HoraCita As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Clave As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents NumOper As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FechaEmbarque As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents HoraEmbarque As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Unidad As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents UnidadID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents UnidadOcupada As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Paquetería As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Operador As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Observ As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents lblTextoEdittar As System.Windows.Forms.Label
    Friend WithEvents btnEditarAgenda As System.Windows.Forms.Button
    Friend WithEvents PaqueteriaId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents OperadorId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents lblTextoCancelarembarque As System.Windows.Forms.Label
    Friend WithEvents btnCancelarApartado As System.Windows.Forms.Button
    Friend WithEvents cmsSeleccionMultiple As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tmsiAgendar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsiEditarAgenda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RequiereCita As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents FechaEnvio As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents HoraEstimadaRegreso As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandC As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandEmbarque As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents tmsiMostrarOTs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenTrabajoCoppel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PictureBox1 As PictureBox
End Class
