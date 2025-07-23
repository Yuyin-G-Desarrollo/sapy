<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaConfiguracionListaVentas
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaConfiguracionListaVentas))
        Me.pnlContenedorConfiguracion = New System.Windows.Forms.GroupBox()
        Me.pnlSimular = New System.Windows.Forms.Panel()
        Me.lblCancelarCambios = New System.Windows.Forms.Label()
        Me.btnSimularCambios = New System.Windows.Forms.Button()
        Me.lblGuardarDatos = New System.Windows.Forms.Label()
        Me.btnCancelarCambios = New System.Windows.Forms.Button()
        Me.btnGuardarDatos = New System.Windows.Forms.Button()
        Me.lblSimularCambios = New System.Windows.Forms.Label()
        Me.pnlBotonCambiar = New System.Windows.Forms.Panel()
        Me.btnCambiarConfig = New System.Windows.Forms.Button()
        Me.lblCambiarConfiguracion = New System.Windows.Forms.Label()
        Me.pnlConfiguracionGrids = New System.Windows.Forms.Panel()
        Me.grdTipoFlete = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblTipoIva = New System.Windows.Forms.Label()
        Me.grdListaTipoIva = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblTipoFlete = New System.Windows.Forms.Label()
        Me.cmbEvento = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlConfiguracion = New System.Windows.Forms.Panel()
        Me.lblRangoDescuento = New System.Windows.Forms.Label()
        Me.lblPorcentajeFactura = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFacturacionInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDescuentoInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDescuentoFin = New System.Windows.Forms.NumericUpDown()
        Me.txtFacturacionFin = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtDigitoLista = New System.Windows.Forms.TextBox()
        Me.lblCodigoLB = New System.Windows.Forms.Label()
        Me.txtIncrementoPar = New System.Windows.Forms.NumericUpDown()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlCargarClientes = New System.Windows.Forms.Panel()
        Me.btnCargarCliente = New System.Windows.Forms.Button()
        Me.lblRefrescar = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pctEngrane = New System.Windows.Forms.PictureBox()
        Me.lblConfMensaje = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblContarConfiguracion = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblContClientes = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionarFiltrados = New System.Windows.Forms.CheckBox()
        Me.grdpListaBaseinfo = New System.Windows.Forms.GroupBox()
        Me.lblListaBase = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.txtListaBase = New System.Windows.Forms.TextBox()
        Me.lblListaVentas = New System.Windows.Forms.Label()
        Me.lblVigenciaFin = New System.Windows.Forms.Label()
        Me.dttVigenciaInicio = New System.Windows.Forms.DateTimePicker()
        Me.dttVigenciaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.rdoPesos = New System.Windows.Forms.RadioButton()
        Me.lblVigenciaInicio = New System.Windows.Forms.Label()
        Me.rdoPorcentaje = New System.Windows.Forms.RadioButton()
        Me.lblIncrementoPar = New System.Windows.Forms.Label()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.grdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlBotonesOcultar = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlContenedorConfiguracion.SuspendLayout()
        Me.pnlSimular.SuspendLayout()
        Me.pnlBotonCambiar.SuspendLayout()
        Me.pnlConfiguracionGrids.SuspendLayout()
        CType(Me.grdTipoFlete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListaTipoIva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConfiguracion.SuspendLayout()
        CType(Me.txtFacturacionInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescuentoInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescuentoFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFacturacionFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIncrementoPar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCargarClientes.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pctEngrane, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.grpDatos.SuspendLayout()
        Me.grdpListaBaseinfo.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesOcultar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedorConfiguracion
        '
        Me.pnlContenedorConfiguracion.Controls.Add(Me.pnlSimular)
        Me.pnlContenedorConfiguracion.Controls.Add(Me.pnlBotonCambiar)
        Me.pnlContenedorConfiguracion.Controls.Add(Me.pnlConfiguracionGrids)
        Me.pnlContenedorConfiguracion.Controls.Add(Me.cmbEvento)
        Me.pnlContenedorConfiguracion.Controls.Add(Me.Label3)
        Me.pnlContenedorConfiguracion.Controls.Add(Me.pnlConfiguracion)
        Me.pnlContenedorConfiguracion.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlContenedorConfiguracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlContenedorConfiguracion.Location = New System.Drawing.Point(463, 0)
        Me.pnlContenedorConfiguracion.Name = "pnlContenedorConfiguracion"
        Me.pnlContenedorConfiguracion.Size = New System.Drawing.Size(575, 215)
        Me.pnlContenedorConfiguracion.TabIndex = 2
        Me.pnlContenedorConfiguracion.TabStop = False
        Me.pnlContenedorConfiguracion.Text = "Valores de Configuración"
        '
        'pnlSimular
        '
        Me.pnlSimular.Controls.Add(Me.lblCancelarCambios)
        Me.pnlSimular.Controls.Add(Me.btnSimularCambios)
        Me.pnlSimular.Controls.Add(Me.lblGuardarDatos)
        Me.pnlSimular.Controls.Add(Me.btnCancelarCambios)
        Me.pnlSimular.Controls.Add(Me.btnGuardarDatos)
        Me.pnlSimular.Controls.Add(Me.lblSimularCambios)
        Me.pnlSimular.Location = New System.Drawing.Point(402, 41)
        Me.pnlSimular.Name = "pnlSimular"
        Me.pnlSimular.Size = New System.Drawing.Size(166, 61)
        Me.pnlSimular.TabIndex = 3
        '
        'lblCancelarCambios
        '
        Me.lblCancelarCambios.AutoSize = True
        Me.lblCancelarCambios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancelarCambios.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarCambios.Location = New System.Drawing.Point(112, 34)
        Me.lblCancelarCambios.Name = "lblCancelarCambios"
        Me.lblCancelarCambios.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelarCambios.TabIndex = 48
        Me.lblCancelarCambios.Text = "Cancelar"
        '
        'btnSimularCambios
        '
        Me.btnSimularCambios.Image = Global.Ventas.Vista.My.Resources.Resources.simulador2
        Me.btnSimularCambios.Location = New System.Drawing.Point(17, 3)
        Me.btnSimularCambios.Name = "btnSimularCambios"
        Me.btnSimularCambios.Size = New System.Drawing.Size(32, 32)
        Me.btnSimularCambios.TabIndex = 1
        Me.btnSimularCambios.UseVisualStyleBackColor = True
        '
        'lblGuardarDatos
        '
        Me.lblGuardarDatos.AutoSize = True
        Me.lblGuardarDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarDatos.Location = New System.Drawing.Point(63, 34)
        Me.lblGuardarDatos.Name = "lblGuardarDatos"
        Me.lblGuardarDatos.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarDatos.TabIndex = 46
        Me.lblGuardarDatos.Text = "Guardar"
        '
        'btnCancelarCambios
        '
        Me.btnCancelarCambios.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelarCambios.Location = New System.Drawing.Point(120, 3)
        Me.btnCancelarCambios.Name = "btnCancelarCambios"
        Me.btnCancelarCambios.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarCambios.TabIndex = 3
        Me.btnCancelarCambios.UseVisualStyleBackColor = True
        '
        'btnGuardarDatos
        '
        Me.btnGuardarDatos.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarDatos.Location = New System.Drawing.Point(69, 3)
        Me.btnGuardarDatos.Name = "btnGuardarDatos"
        Me.btnGuardarDatos.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarDatos.TabIndex = 2
        Me.btnGuardarDatos.UseVisualStyleBackColor = True
        '
        'lblSimularCambios
        '
        Me.lblSimularCambios.AutoSize = True
        Me.lblSimularCambios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSimularCambios.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSimularCambios.Location = New System.Drawing.Point(2, 34)
        Me.lblSimularCambios.Name = "lblSimularCambios"
        Me.lblSimularCambios.Size = New System.Drawing.Size(63, 26)
        Me.lblSimularCambios.TabIndex = 44
        Me.lblSimularCambios.Text = "Simular" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Exclusiones"
        Me.lblSimularCambios.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlBotonCambiar
        '
        Me.pnlBotonCambiar.Controls.Add(Me.btnCambiarConfig)
        Me.pnlBotonCambiar.Controls.Add(Me.lblCambiarConfiguracion)
        Me.pnlBotonCambiar.Location = New System.Drawing.Point(351, 41)
        Me.pnlBotonCambiar.Name = "pnlBotonCambiar"
        Me.pnlBotonCambiar.Size = New System.Drawing.Size(51, 48)
        Me.pnlBotonCambiar.TabIndex = 5
        '
        'btnCambiarConfig
        '
        Me.btnCambiarConfig.Image = Global.Ventas.Vista.My.Resources.Resources.editar_321
        Me.btnCambiarConfig.Location = New System.Drawing.Point(9, 3)
        Me.btnCambiarConfig.Name = "btnCambiarConfig"
        Me.btnCambiarConfig.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiarConfig.TabIndex = 1
        Me.btnCambiarConfig.UseVisualStyleBackColor = True
        Me.btnCambiarConfig.Visible = False
        '
        'lblCambiarConfiguracion
        '
        Me.lblCambiarConfiguracion.AutoSize = True
        Me.lblCambiarConfiguracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambiarConfiguracion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCambiarConfiguracion.Location = New System.Drawing.Point(8, 34)
        Me.lblCambiarConfiguracion.Name = "lblCambiarConfiguracion"
        Me.lblCambiarConfiguracion.Size = New System.Drawing.Size(34, 13)
        Me.lblCambiarConfiguracion.TabIndex = 44
        Me.lblCambiarConfiguracion.Text = "Editar"
        Me.lblCambiarConfiguracion.Visible = False
        '
        'pnlConfiguracionGrids
        '
        Me.pnlConfiguracionGrids.Controls.Add(Me.grdTipoFlete)
        Me.pnlConfiguracionGrids.Controls.Add(Me.lblTipoIva)
        Me.pnlConfiguracionGrids.Controls.Add(Me.grdListaTipoIva)
        Me.pnlConfiguracionGrids.Controls.Add(Me.lblTipoFlete)
        Me.pnlConfiguracionGrids.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlConfiguracionGrids.Location = New System.Drawing.Point(12, 103)
        Me.pnlConfiguracionGrids.Name = "pnlConfiguracionGrids"
        Me.pnlConfiguracionGrids.Size = New System.Drawing.Size(556, 109)
        Me.pnlConfiguracionGrids.TabIndex = 2
        '
        'grdTipoFlete
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTipoFlete.DisplayLayout.Appearance = Appearance1
        Me.grdTipoFlete.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTipoFlete.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTipoFlete.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTipoFlete.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTipoFlete.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdTipoFlete.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTipoFlete.Location = New System.Drawing.Point(268, 14)
        Me.grdTipoFlete.Name = "grdTipoFlete"
        Me.grdTipoFlete.Size = New System.Drawing.Size(272, 91)
        Me.grdTipoFlete.TabIndex = 12
        '
        'lblTipoIva
        '
        Me.lblTipoIva.AutoSize = True
        Me.lblTipoIva.Location = New System.Drawing.Point(3, 1)
        Me.lblTipoIva.Name = "lblTipoIva"
        Me.lblTipoIva.Size = New System.Drawing.Size(53, 13)
        Me.lblTipoIva.TabIndex = 0
        Me.lblTipoIva.Text = "* Tipo Iva"
        '
        'grdListaTipoIva
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaTipoIva.DisplayLayout.Appearance = Appearance3
        Me.grdListaTipoIva.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaTipoIva.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListaTipoIva.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaTipoIva.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaTipoIva.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaTipoIva.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdListaTipoIva.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaTipoIva.Location = New System.Drawing.Point(3, 14)
        Me.grdListaTipoIva.Name = "grdListaTipoIva"
        Me.grdListaTipoIva.Size = New System.Drawing.Size(246, 91)
        Me.grdListaTipoIva.TabIndex = 11
        '
        'lblTipoFlete
        '
        Me.lblTipoFlete.AutoSize = True
        Me.lblTipoFlete.Location = New System.Drawing.Point(268, 1)
        Me.lblTipoFlete.Name = "lblTipoFlete"
        Me.lblTipoFlete.Size = New System.Drawing.Size(61, 13)
        Me.lblTipoFlete.TabIndex = 3
        Me.lblTipoFlete.Text = "* Tipo Flete"
        '
        'cmbEvento
        '
        Me.cmbEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEvento.FormattingEnabled = True
        Me.cmbEvento.Location = New System.Drawing.Point(57, 16)
        Me.cmbEvento.Name = "cmbEvento"
        Me.cmbEvento.Size = New System.Drawing.Size(515, 21)
        Me.cmbEvento.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Evento"
        '
        'pnlConfiguracion
        '
        Me.pnlConfiguracion.Controls.Add(Me.lblRangoDescuento)
        Me.pnlConfiguracion.Controls.Add(Me.lblPorcentajeFactura)
        Me.pnlConfiguracion.Controls.Add(Me.Label11)
        Me.pnlConfiguracion.Controls.Add(Me.txtFacturacionInicio)
        Me.pnlConfiguracion.Controls.Add(Me.Label6)
        Me.pnlConfiguracion.Controls.Add(Me.Label12)
        Me.pnlConfiguracion.Controls.Add(Me.txtDescuentoInicio)
        Me.pnlConfiguracion.Controls.Add(Me.Label13)
        Me.pnlConfiguracion.Controls.Add(Me.txtDescuentoFin)
        Me.pnlConfiguracion.Controls.Add(Me.txtFacturacionFin)
        Me.pnlConfiguracion.Controls.Add(Me.Label4)
        Me.pnlConfiguracion.Controls.Add(Me.Label2)
        Me.pnlConfiguracion.Controls.Add(Me.Label5)
        Me.pnlConfiguracion.Controls.Add(Me.Label10)
        Me.pnlConfiguracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlConfiguracion.Location = New System.Drawing.Point(12, 41)
        Me.pnlConfiguracion.Name = "pnlConfiguracion"
        Me.pnlConfiguracion.Size = New System.Drawing.Size(339, 48)
        Me.pnlConfiguracion.TabIndex = 1
        '
        'lblRangoDescuento
        '
        Me.lblRangoDescuento.AutoSize = True
        Me.lblRangoDescuento.Location = New System.Drawing.Point(3, 7)
        Me.lblRangoDescuento.Name = "lblRangoDescuento"
        Me.lblRangoDescuento.Size = New System.Drawing.Size(71, 13)
        Me.lblRangoDescuento.TabIndex = 2
        Me.lblRangoDescuento.Text = "* Descuentos"
        '
        'lblPorcentajeFactura
        '
        Me.lblPorcentajeFactura.AutoSize = True
        Me.lblPorcentajeFactura.Location = New System.Drawing.Point(3, 28)
        Me.lblPorcentajeFactura.Name = "lblPorcentajeFactura"
        Me.lblPorcentajeFactura.Size = New System.Drawing.Size(70, 13)
        Me.lblPorcentajeFactura.TabIndex = 4
        Me.lblPorcentajeFactura.Text = "* Facturación"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(186, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "%"
        '
        'txtFacturacionInicio
        '
        Me.txtFacturacionInicio.DecimalPlaces = 2
        Me.txtFacturacionInicio.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtFacturacionInicio.Location = New System.Drawing.Point(120, 24)
        Me.txtFacturacionInicio.Name = "txtFacturacionInicio"
        Me.txtFacturacionInicio.Size = New System.Drawing.Size(63, 20)
        Me.txtFacturacionInicio.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(186, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(216, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 13)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "a:"
        '
        'txtDescuentoInicio
        '
        Me.txtDescuentoInicio.DecimalPlaces = 2
        Me.txtDescuentoInicio.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtDescuentoInicio.Location = New System.Drawing.Point(120, 3)
        Me.txtDescuentoInicio.Name = "txtDescuentoInicio"
        Me.txtDescuentoInicio.Size = New System.Drawing.Size(63, 20)
        Me.txtDescuentoInicio.TabIndex = 1
        Me.txtDescuentoInicio.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(85, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "De: "
        '
        'txtDescuentoFin
        '
        Me.txtDescuentoFin.DecimalPlaces = 2
        Me.txtDescuentoFin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtDescuentoFin.Location = New System.Drawing.Point(241, 3)
        Me.txtDescuentoFin.Name = "txtDescuentoFin"
        Me.txtDescuentoFin.Size = New System.Drawing.Size(63, 20)
        Me.txtDescuentoFin.TabIndex = 2
        '
        'txtFacturacionFin
        '
        Me.txtFacturacionFin.DecimalPlaces = 2
        Me.txtFacturacionFin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtFacturacionFin.Location = New System.Drawing.Point(241, 24)
        Me.txtFacturacionFin.Name = "txtFacturacionFin"
        Me.txtFacturacionFin.Size = New System.Drawing.Size(63, 20)
        Me.txtFacturacionFin.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(216, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "a:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "De: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(307, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(307, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "%"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(142, 106)
        Me.txtDescripcion.MaxLength = 15
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(284, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'txtDigitoLista
        '
        Me.txtDigitoLista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDigitoLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDigitoLista.Location = New System.Drawing.Point(200, 85)
        Me.txtDigitoLista.MaxLength = 4
        Me.txtDigitoLista.Name = "txtDigitoLista"
        Me.txtDigitoLista.Size = New System.Drawing.Size(63, 20)
        Me.txtDigitoLista.TabIndex = 2
        Me.txtDigitoLista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodigoLB
        '
        Me.lblCodigoLB.AutoSize = True
        Me.lblCodigoLB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoLB.Location = New System.Drawing.Point(142, 89)
        Me.lblCodigoLB.Name = "lblCodigoLB"
        Me.lblCodigoLB.Size = New System.Drawing.Size(52, 13)
        Me.lblCodigoLB.TabIndex = 34
        Me.lblCodigoLB.Text = "1201502-"
        '
        'txtIncrementoPar
        '
        Me.txtIncrementoPar.DecimalPlaces = 2
        Me.txtIncrementoPar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncrementoPar.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtIncrementoPar.Location = New System.Drawing.Point(278, 127)
        Me.txtIncrementoPar.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtIncrementoPar.Name = "txtIncrementoPar"
        Me.txtIncrementoPar.Size = New System.Drawing.Size(63, 20)
        Me.txtIncrementoPar.TabIndex = 4
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1038, 60)
        Me.pnlHeader.TabIndex = 2
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(640, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(398, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(75, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(251, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Configuración Lista de Ventas"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(330, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'pnlCargarClientes
        '
        Me.pnlCargarClientes.Controls.Add(Me.btnCargarCliente)
        Me.pnlCargarClientes.Controls.Add(Me.lblRefrescar)
        Me.pnlCargarClientes.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCargarClientes.Location = New System.Drawing.Point(888, 0)
        Me.pnlCargarClientes.Name = "pnlCargarClientes"
        Me.pnlCargarClientes.Size = New System.Drawing.Size(50, 60)
        Me.pnlCargarClientes.TabIndex = 3
        '
        'btnCargarCliente
        '
        Me.btnCargarCliente.Image = Global.Ventas.Vista.My.Resources.Resources.buscacliente
        Me.btnCargarCliente.Location = New System.Drawing.Point(10, 8)
        Me.btnCargarCliente.Name = "btnCargarCliente"
        Me.btnCargarCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarCliente.TabIndex = 1
        Me.btnCargarCliente.UseVisualStyleBackColor = True
        '
        'lblRefrescar
        '
        Me.lblRefrescar.AutoSize = True
        Me.lblRefrescar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRefrescar.Location = New System.Drawing.Point(4, 41)
        Me.lblRefrescar.Name = "lblRefrescar"
        Me.lblRefrescar.Size = New System.Drawing.Size(44, 13)
        Me.lblRefrescar.TabIndex = 35
        Me.lblRefrescar.Text = "Clientes"
        Me.lblRefrescar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Panel2)
        Me.pnlEstado.Controls.Add(Me.Panel1)
        Me.pnlEstado.Controls.Add(Me.lblContarConfiguracion)
        Me.pnlEstado.Controls.Add(Me.Label16)
        Me.pnlEstado.Controls.Add(Me.pnlCargarClientes)
        Me.pnlEstado.Controls.Add(Me.lblContClientes)
        Me.pnlEstado.Controls.Add(Me.pnlBotones)
        Me.pnlEstado.Controls.Add(Me.lblClientes)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 578)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1038, 60)
        Me.pnlEstado.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.pctEngrane)
        Me.Panel2.Controls.Add(Me.lblConfMensaje)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(278, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(357, 60)
        Me.Panel2.TabIndex = 54
        '
        'Label18
        '
        Me.Label18.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Gold
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(3, 30)
        Me.Label18.MinimumSize = New System.Drawing.Size(30, 5)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 51
        '
        'Label8
        '
        Me.Label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.LimeGreen
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 2)
        Me.Label8.MinimumSize = New System.Drawing.Size(30, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 45
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(39, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 12)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Clientes a incluir en la Lista de Ventas"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Red
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(3, 16)
        Me.Label14.MinimumSize = New System.Drawing.Size(30, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 47
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(39, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(318, 12)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "Clientes que no pueden cambiar de Lista de Ventas (tienen Listas de Precios)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(39, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(265, 12)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Clientes fuera de la Lista de Ventas por cambio de configuración"
        '
        'pctEngrane
        '
        Me.pctEngrane.Image = Global.Ventas.Vista.My.Resources.Resources.conflv
        Me.pctEngrane.Location = New System.Drawing.Point(10, 43)
        Me.pctEngrane.Name = "pctEngrane"
        Me.pctEngrane.Size = New System.Drawing.Size(16, 15)
        Me.pctEngrane.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pctEngrane.TabIndex = 50
        Me.pctEngrane.TabStop = False
        '
        'lblConfMensaje
        '
        Me.lblConfMensaje.AutoSize = True
        Me.lblConfMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfMensaje.ForeColor = System.Drawing.Color.Black
        Me.lblConfMensaje.Location = New System.Drawing.Point(39, 44)
        Me.lblConfMensaje.Name = "lblConfMensaje"
        Me.lblConfMensaje.Size = New System.Drawing.Size(212, 12)
        Me.lblConfMensaje.TabIndex = 49
        Me.lblConfMensaje.Text = "Futura configuración de la Ficha Técnica de Cliente"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(635, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(253, 60)
        Me.Panel1.TabIndex = 53
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(5, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(246, 39)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "Los clientes recuperados son aquellos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "que cumplen con la configuración capturad" &
    "a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "y que NO se encuentran en otras Listas de Ventas."
        '
        'lblContarConfiguracion
        '
        Me.lblContarConfiguracion.AutoSize = True
        Me.lblContarConfiguracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContarConfiguracion.ForeColor = System.Drawing.Color.Black
        Me.lblContarConfiguracion.Location = New System.Drawing.Point(190, 33)
        Me.lblContarConfiguracion.Name = "lblContarConfiguracion"
        Me.lblContarConfiguracion.Size = New System.Drawing.Size(25, 25)
        Me.lblContarConfiguracion.TabIndex = 51
        Me.lblContarConfiguracion.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(132, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(140, 32)
        Me.Label16.TabIndex = 52
        Me.Label16.Text = "Clientes dentro " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de la configuración"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContClientes
        '
        Me.lblContClientes.AutoSize = True
        Me.lblContClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContClientes.ForeColor = System.Drawing.Color.Black
        Me.lblContClientes.Location = New System.Drawing.Point(58, 33)
        Me.lblContClientes.Name = "lblContClientes"
        Me.lblContClientes.Size = New System.Drawing.Size(25, 25)
        Me.lblContClientes.TabIndex = 44
        Me.lblContClientes.Text = "0"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(938, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(100, 60)
        Me.pnlBotones.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(63, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(19, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(62, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(13, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 1
        Me.lblGuardar.Text = "Guardar" & Global.Microsoft.VisualBasic.ChrW(13)
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(14, 3)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(112, 32)
        Me.lblClientes.TabIndex = 44
        Me.lblClientes.Text = "Clientes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.chkSeleccionarFiltrados)
        Me.grpDatos.Controls.Add(Me.grdpListaBaseinfo)
        Me.grpDatos.Controls.Add(Me.lblCodigoLB)
        Me.grpDatos.Controls.Add(Me.lblListaVentas)
        Me.grpDatos.Controls.Add(Me.lblVigenciaFin)
        Me.grpDatos.Controls.Add(Me.dttVigenciaInicio)
        Me.grpDatos.Controls.Add(Me.dttVigenciaFin)
        Me.grpDatos.Controls.Add(Me.txtDigitoLista)
        Me.grpDatos.Controls.Add(Me.lblDescripcion)
        Me.grpDatos.Controls.Add(Me.rdoPesos)
        Me.grpDatos.Controls.Add(Me.lblVigenciaInicio)
        Me.grpDatos.Controls.Add(Me.txtDescripcion)
        Me.grpDatos.Controls.Add(Me.rdoPorcentaje)
        Me.grpDatos.Controls.Add(Me.lblIncrementoPar)
        Me.grpDatos.Controls.Add(Me.txtIncrementoPar)
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatos.Location = New System.Drawing.Point(0, 0)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(463, 215)
        Me.grpDatos.TabIndex = 1
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Información de la Lista de Ventas"
        '
        'chkSeleccionarFiltrados
        '
        Me.chkSeleccionarFiltrados.AutoSize = True
        Me.chkSeleccionarFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarFiltrados.Location = New System.Drawing.Point(24, 194)
        Me.chkSeleccionarFiltrados.Name = "chkSeleccionarFiltrados"
        Me.chkSeleccionarFiltrados.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarFiltrados.TabIndex = 7
        Me.chkSeleccionarFiltrados.Text = "Seleccionar Todo"
        Me.chkSeleccionarFiltrados.UseVisualStyleBackColor = True
        '
        'grdpListaBaseinfo
        '
        Me.grdpListaBaseinfo.Controls.Add(Me.lblListaBase)
        Me.grdpListaBaseinfo.Controls.Add(Me.Label1)
        Me.grdpListaBaseinfo.Controls.Add(Me.lblEstatus)
        Me.grdpListaBaseinfo.Controls.Add(Me.txtListaBase)
        Me.grdpListaBaseinfo.Location = New System.Drawing.Point(12, 17)
        Me.grdpListaBaseinfo.Name = "grdpListaBaseinfo"
        Me.grdpListaBaseinfo.Size = New System.Drawing.Size(411, 61)
        Me.grdpListaBaseinfo.TabIndex = 1
        Me.grdpListaBaseinfo.TabStop = False
        Me.grdpListaBaseinfo.Text = "Lista Base"
        '
        'lblListaBase
        '
        Me.lblListaBase.AutoSize = True
        Me.lblListaBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaBase.Location = New System.Drawing.Point(23, 18)
        Me.lblListaBase.Name = "lblListaBase"
        Me.lblListaBase.Size = New System.Drawing.Size(56, 13)
        Me.lblListaBase.TabIndex = 32
        Me.lblListaBase.Text = "Lista Base"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Estatus"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.Blue
        Me.lblEstatus.Location = New System.Drawing.Point(112, 42)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(42, 13)
        Me.lblEstatus.TabIndex = 46
        Me.lblEstatus.Text = "Estatus"
        '
        'txtListaBase
        '
        Me.txtListaBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtListaBase.Enabled = False
        Me.txtListaBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtListaBase.Location = New System.Drawing.Point(112, 16)
        Me.txtListaBase.MaxLength = 15
        Me.txtListaBase.Name = "txtListaBase"
        Me.txtListaBase.Size = New System.Drawing.Size(284, 20)
        Me.txtListaBase.TabIndex = 1
        '
        'lblListaVentas
        '
        Me.lblListaVentas.AutoSize = True
        Me.lblListaVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaVentas.Location = New System.Drawing.Point(24, 89)
        Me.lblListaVentas.Name = "lblListaVentas"
        Me.lblListaVentas.Size = New System.Drawing.Size(47, 13)
        Me.lblListaVentas.TabIndex = 33
        Me.lblListaVentas.Text = "* Código"
        '
        'lblVigenciaFin
        '
        Me.lblVigenciaFin.AutoSize = True
        Me.lblVigenciaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVigenciaFin.Location = New System.Drawing.Point(24, 173)
        Me.lblVigenciaFin.Name = "lblVigenciaFin"
        Me.lblVigenciaFin.Size = New System.Drawing.Size(72, 13)
        Me.lblVigenciaFin.TabIndex = 29
        Me.lblVigenciaFin.Text = "* Vigencia Fin"
        '
        'dttVigenciaInicio
        '
        Me.dttVigenciaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttVigenciaInicio.Location = New System.Drawing.Point(142, 148)
        Me.dttVigenciaInicio.Name = "dttVigenciaInicio"
        Me.dttVigenciaInicio.Size = New System.Drawing.Size(199, 20)
        Me.dttVigenciaInicio.TabIndex = 5
        '
        'dttVigenciaFin
        '
        Me.dttVigenciaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttVigenciaFin.Location = New System.Drawing.Point(142, 169)
        Me.dttVigenciaFin.Name = "dttVigenciaFin"
        Me.dttVigenciaFin.Size = New System.Drawing.Size(199, 20)
        Me.dttVigenciaFin.TabIndex = 6
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(24, 110)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescripcion.TabIndex = 44
        Me.lblDescripcion.Text = "* Descripción"
        '
        'rdoPesos
        '
        Me.rdoPesos.AutoSize = True
        Me.rdoPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPesos.Location = New System.Drawing.Point(182, 129)
        Me.rdoPesos.Name = "rdoPesos"
        Me.rdoPesos.Size = New System.Drawing.Size(63, 17)
        Me.rdoPesos.TabIndex = 5
        Me.rdoPesos.Text = "$ Pesos"
        Me.rdoPesos.UseVisualStyleBackColor = True
        '
        'lblVigenciaInicio
        '
        Me.lblVigenciaInicio.AutoSize = True
        Me.lblVigenciaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVigenciaInicio.Location = New System.Drawing.Point(24, 152)
        Me.lblVigenciaInicio.Name = "lblVigenciaInicio"
        Me.lblVigenciaInicio.Size = New System.Drawing.Size(83, 13)
        Me.lblVigenciaInicio.TabIndex = 29
        Me.lblVigenciaInicio.Text = "* Vigencia Inicio"
        '
        'rdoPorcentaje
        '
        Me.rdoPorcentaje.AutoSize = True
        Me.rdoPorcentaje.Checked = True
        Me.rdoPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoPorcentaje.Location = New System.Drawing.Point(142, 129)
        Me.rdoPorcentaje.Name = "rdoPorcentaje"
        Me.rdoPorcentaje.Size = New System.Drawing.Size(33, 17)
        Me.rdoPorcentaje.TabIndex = 4
        Me.rdoPorcentaje.TabStop = True
        Me.rdoPorcentaje.Text = "%"
        Me.rdoPorcentaje.UseVisualStyleBackColor = True
        '
        'lblIncrementoPar
        '
        Me.lblIncrementoPar.AutoSize = True
        Me.lblIncrementoPar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncrementoPar.Location = New System.Drawing.Point(24, 131)
        Me.lblIncrementoPar.Name = "lblIncrementoPar"
        Me.lblIncrementoPar.Size = New System.Drawing.Size(94, 13)
        Me.lblIncrementoPar.TabIndex = 29
        Me.lblIncrementoPar.Text = "* Incremento x Par"
        '
        'pnlContenedor
        '
        Me.pnlContenedor.Controls.Add(Me.grpDatos)
        Me.pnlContenedor.Controls.Add(Me.pnlContenedorConfiguracion)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 82)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1038, 215)
        Me.pnlContenedor.TabIndex = 44
        '
        'grdClientes
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Appearance = Appearance5
        Me.grdClientes.DisplayLayout.GroupByBox.Hidden = True
        Me.grdClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientes.Location = New System.Drawing.Point(0, 297)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(1038, 281)
        Me.grdClientes.TabIndex = 16
        '
        'pnlBotonesOcultar
        '
        Me.pnlBotonesOcultar.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesOcultar.Controls.Add(Me.btnArriba)
        Me.pnlBotonesOcultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBotonesOcultar.Location = New System.Drawing.Point(0, 60)
        Me.pnlBotonesOcultar.Name = "pnlBotonesOcultar"
        Me.pnlBotonesOcultar.Size = New System.Drawing.Size(1038, 22)
        Me.pnlBotonesOcultar.TabIndex = 3
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(991, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 47
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(963, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 46
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'AltaConfiguracionListaVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1038, 638)
        Me.Controls.Add(Me.grdClientes)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlBotonesOcultar)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(1054, 677)
        Me.MinimumSize = New System.Drawing.Size(1054, 677)
        Me.Name = "AltaConfiguracionListaVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Lista de Ventas"
        Me.pnlContenedorConfiguracion.ResumeLayout(False)
        Me.pnlContenedorConfiguracion.PerformLayout()
        Me.pnlSimular.ResumeLayout(False)
        Me.pnlSimular.PerformLayout()
        Me.pnlBotonCambiar.ResumeLayout(False)
        Me.pnlBotonCambiar.PerformLayout()
        Me.pnlConfiguracionGrids.ResumeLayout(False)
        Me.pnlConfiguracionGrids.PerformLayout()
        CType(Me.grdTipoFlete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListaTipoIva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConfiguracion.ResumeLayout(False)
        Me.pnlConfiguracion.PerformLayout()
        CType(Me.txtFacturacionInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescuentoInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescuentoFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFacturacionFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIncrementoPar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCargarClientes.ResumeLayout(False)
        Me.pnlCargarClientes.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pctEngrane, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.grdpListaBaseinfo.ResumeLayout(False)
        Me.grdpListaBaseinfo.PerformLayout()
        Me.pnlContenedor.ResumeLayout(False)
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesOcultar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedorConfiguracion As System.Windows.Forms.GroupBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescuentoInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtDescuentoFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtIncrementoPar As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdTipoFlete As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdListaTipoIva As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblPorcentajeFactura As System.Windows.Forms.Label
    Friend WithEvents lblTipoFlete As System.Windows.Forms.Label
    Friend WithEvents lblRangoDescuento As System.Windows.Forms.Label
    Friend WithEvents lblTipoIva As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFacturacionFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtFacturacionInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtDigitoLista As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoLB As System.Windows.Forms.Label
    Friend WithEvents rdoPesos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPorcentaje As System.Windows.Forms.RadioButton
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents txtListaBase As System.Windows.Forms.TextBox
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblIncrementoPar As System.Windows.Forms.Label
    Friend WithEvents lblListaBase As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblListaVentas As System.Windows.Forms.Label
    Friend WithEvents lblContClientes As System.Windows.Forms.Label
    Friend WithEvents dttVigenciaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttVigenciaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblVigenciaInicio As System.Windows.Forms.Label
    Friend WithEvents lblVigenciaFin As System.Windows.Forms.Label
    Friend WithEvents grdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbEvento As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdpListaBaseinfo As System.Windows.Forms.GroupBox
    Friend WithEvents pnlConfiguracion As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlBotonesOcultar As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pctEngrane As System.Windows.Forms.PictureBox
    Friend WithEvents lblConfMensaje As System.Windows.Forms.Label
    Friend WithEvents pnlSimular As System.Windows.Forms.Panel
    Friend WithEvents lblCancelarCambios As System.Windows.Forms.Label
    Friend WithEvents btnSimularCambios As System.Windows.Forms.Button
    Friend WithEvents lblSimularCambios As System.Windows.Forms.Label
    Friend WithEvents btnGuardarDatos As System.Windows.Forms.Button
    Friend WithEvents btnCancelarCambios As System.Windows.Forms.Button
    Friend WithEvents lblGuardarDatos As System.Windows.Forms.Label
    Friend WithEvents pnlCargarClientes As System.Windows.Forms.Panel
    Friend WithEvents btnCargarCliente As System.Windows.Forms.Button
    Friend WithEvents lblRefrescar As System.Windows.Forms.Label
    Friend WithEvents pnlBotonCambiar As System.Windows.Forms.Panel
    Friend WithEvents btnCambiarConfig As System.Windows.Forms.Button
    Friend WithEvents lblCambiarConfiguracion As System.Windows.Forms.Label
    Friend WithEvents pnlConfiguracionGrids As System.Windows.Forms.Panel
    Friend WithEvents lblContarConfiguracion As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarFiltrados As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
