<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerParesDisponibleApartadoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VerParesDisponibleApartadoForm))
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlLocalizadoCoppel = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlLocalizadoError = New System.Windows.Forms.Panel()
        Me.pnlLocalizadoAtado = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlLocalizadoPar = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdParesDisponibles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTextoTituloVentana = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlResumen = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlEstatusValidado = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacionHora = New System.Windows.Forms.Label()
        Me.lblUltimaActualizacionFecha = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.pnlEstatusProyectado = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlEstatusCalidad = New System.Windows.Forms.Panel()
        Me.pnlEstatusDisponible = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnlEstatusAsignado = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlEstatusReproceso = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlEstatusBloqueado = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdParesDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlResumen.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(11, 48)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 2
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(16, 13)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnSalir.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSalir.Location = New System.Drawing.Point(58, 13)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(93, 37)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Coppel"
        '
        'pnlLocalizadoCoppel
        '
        Me.pnlLocalizadoCoppel.BackColor = System.Drawing.Color.Purple
        Me.pnlLocalizadoCoppel.Location = New System.Drawing.Point(78, 36)
        Me.pnlLocalizadoCoppel.Name = "pnlLocalizadoCoppel"
        Me.pnlLocalizadoCoppel.Size = New System.Drawing.Size(15, 15)
        Me.pnlLocalizadoCoppel.TabIndex = 66
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(93, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Error"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Atado"
        '
        'pnlLocalizadoError
        '
        Me.pnlLocalizadoError.BackColor = System.Drawing.Color.Orange
        Me.pnlLocalizadoError.Location = New System.Drawing.Point(78, 19)
        Me.pnlLocalizadoError.Name = "pnlLocalizadoError"
        Me.pnlLocalizadoError.Size = New System.Drawing.Size(15, 15)
        Me.pnlLocalizadoError.TabIndex = 64
        '
        'pnlLocalizadoAtado
        '
        Me.pnlLocalizadoAtado.BackColor = System.Drawing.Color.Aquamarine
        Me.pnlLocalizadoAtado.Location = New System.Drawing.Point(15, 36)
        Me.pnlLocalizadoAtado.Name = "pnlLocalizadoAtado"
        Me.pnlLocalizadoAtado.Size = New System.Drawing.Size(15, 15)
        Me.pnlLocalizadoAtado.TabIndex = 64
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnSalir)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1138, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(101, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(57, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Par"
        '
        'pnlLocalizadoPar
        '
        Me.pnlLocalizadoPar.BackColor = System.Drawing.Color.Khaki
        Me.pnlLocalizadoPar.Location = New System.Drawing.Point(15, 19)
        Me.pnlLocalizadoPar.Name = "pnlLocalizadoPar"
        Me.pnlLocalizadoPar.Size = New System.Drawing.Size(15, 15)
        Me.pnlLocalizadoPar.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Localizado como"
        '
        'grdParesDisponibles
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdParesDisponibles.DisplayLayout.Appearance = Appearance1
        Me.grdParesDisponibles.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdParesDisponibles.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesDisponibles.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesDisponibles.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdParesDisponibles.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdParesDisponibles.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdParesDisponibles.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdParesDisponibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesDisponibles.Location = New System.Drawing.Point(0, 0)
        Me.grdParesDisponibles.Name = "grdParesDisponibles"
        Me.grdParesDisponibles.Size = New System.Drawing.Size(1239, 444)
        Me.grdParesDisponibles.TabIndex = 0
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlParametros)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Controls.Add(Me.pnlPie)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1239, 566)
        Me.pnlContenedor.TabIndex = 3
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.pnlListaCliente)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParametros.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1239, 444)
        Me.pnlParametros.TabIndex = 0
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.grdParesDisponibles)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(1239, 444)
        Me.pnlListaCliente.TabIndex = 4
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Controls.Add(Me.lblTitulo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1239, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1239, 59)
        Me.pnlEncabezado.TabIndex = 0
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.lblExportar)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnImprimir)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportar)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblImprimir)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(301, 59)
        Me.pnlAccionesCabecera.TabIndex = 1
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(8, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 24
        Me.lblExportar.Text = "Exportar"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Ventas.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(70, 7)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 25
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(15, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 23
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(66, 42)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 26
        Me.lblImprimir.Text = "Imprimir"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTextoTituloVentana)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(746, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(493, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTextoTituloVentana
        '
        Me.lblTextoTituloVentana.AutoSize = True
        Me.lblTextoTituloVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoTituloVentana.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTextoTituloVentana.Location = New System.Drawing.Point(12, 19)
        Me.lblTextoTituloVentana.Name = "lblTextoTituloVentana"
        Me.lblTextoTituloVentana.Size = New System.Drawing.Size(357, 20)
        Me.lblTextoTituloVentana.TabIndex = 46
        Me.lblTextoTituloVentana.Text = "Pares en existencia disponible del apartado"
        Me.lblTextoTituloVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(958, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(206, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Ficha Técnica de Cliente"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlResumen)
        Me.pnlPie.Controls.Add(Me.Label11)
        Me.pnlPie.Controls.Add(Me.pnlLocalizadoCoppel)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.Label7)
        Me.pnlPie.Controls.Add(Me.pnlLocalizadoError)
        Me.pnlPie.Controls.Add(Me.pnlLocalizadoAtado)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.pnlLocalizadoPar)
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 503)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1239, 63)
        Me.pnlPie.TabIndex = 3
        '
        'pnlResumen
        '
        Me.pnlResumen.Controls.Add(Me.Label20)
        Me.pnlResumen.Controls.Add(Me.Label21)
        Me.pnlResumen.Controls.Add(Me.Label8)
        Me.pnlResumen.Controls.Add(Me.pnlEstatusValidado)
        Me.pnlResumen.Controls.Add(Me.lblUltimaActualizacionHora)
        Me.pnlResumen.Controls.Add(Me.lblUltimaActualizacionFecha)
        Me.pnlResumen.Controls.Add(Me.Label18)
        Me.pnlResumen.Controls.Add(Me.lblTotalPares)
        Me.pnlResumen.Controls.Add(Me.pnlEstatusProyectado)
        Me.pnlResumen.Controls.Add(Me.Label19)
        Me.pnlResumen.Controls.Add(Me.Label4)
        Me.pnlResumen.Controls.Add(Me.pnlEstatusCalidad)
        Me.pnlResumen.Controls.Add(Me.pnlEstatusDisponible)
        Me.pnlResumen.Controls.Add(Me.Label16)
        Me.pnlResumen.Controls.Add(Me.pnlEstatusAsignado)
        Me.pnlResumen.Controls.Add(Me.Label13)
        Me.pnlResumen.Controls.Add(Me.Label15)
        Me.pnlResumen.Controls.Add(Me.pnlEstatusReproceso)
        Me.pnlResumen.Controls.Add(Me.Label17)
        Me.pnlResumen.Controls.Add(Me.pnlEstatusBloqueado)
        Me.pnlResumen.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlResumen.Location = New System.Drawing.Point(205, 0)
        Me.pnlResumen.Name = "pnlResumen"
        Me.pnlResumen.Size = New System.Drawing.Size(933, 63)
        Me.pnlResumen.TabIndex = 68
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(13, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 13)
        Me.Label20.TabIndex = 70
        Me.Label20.Text = "Estatus"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(265, 36)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 13)
        Me.Label21.TabIndex = 81
        Me.Label21.Text = "Validado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(680, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Última Actualización:"
        '
        'pnlEstatusValidado
        '
        Me.pnlEstatusValidado.BackColor = System.Drawing.Color.OrangeRed
        Me.pnlEstatusValidado.Location = New System.Drawing.Point(249, 35)
        Me.pnlEstatusValidado.Name = "pnlEstatusValidado"
        Me.pnlEstatusValidado.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusValidado.TabIndex = 80
        '
        'lblUltimaActualizacionHora
        '
        Me.lblUltimaActualizacionHora.AutoSize = True
        Me.lblUltimaActualizacionHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaActualizacionHora.ForeColor = System.Drawing.Color.Black
        Me.lblUltimaActualizacionHora.Location = New System.Drawing.Point(853, 37)
        Me.lblUltimaActualizacionHora.Name = "lblUltimaActualizacionHora"
        Me.lblUltimaActualizacionHora.Size = New System.Drawing.Size(63, 13)
        Me.lblUltimaActualizacionHora.TabIndex = 62
        Me.lblUltimaActualizacionHora.Text = "88:88:88XX"
        '
        'lblUltimaActualizacionFecha
        '
        Me.lblUltimaActualizacionFecha.AutoSize = True
        Me.lblUltimaActualizacionFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaActualizacionFecha.ForeColor = System.Drawing.Color.Black
        Me.lblUltimaActualizacionFecha.Location = New System.Drawing.Point(785, 37)
        Me.lblUltimaActualizacionFecha.Name = "lblUltimaActualizacionFecha"
        Me.lblUltimaActualizacionFecha.Size = New System.Drawing.Size(65, 13)
        Me.lblUltimaActualizacionFecha.TabIndex = 61
        Me.lblUltimaActualizacionFecha.Text = "8888/88/88"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(185, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 13)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Proyectado"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPares.Location = New System.Drawing.Point(861, 13)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(49, 13)
        Me.lblTotalPares.TabIndex = 60
        Me.lblTotalPares.Text = "000000"
        Me.lblTotalPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEstatusProyectado
        '
        Me.pnlEstatusProyectado.BackColor = System.Drawing.Color.DeepPink
        Me.pnlEstatusProyectado.Location = New System.Drawing.Point(170, 35)
        Me.pnlEstatusProyectado.Name = "pnlEstatusProyectado"
        Me.pnlEstatusProyectado.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusProyectado.TabIndex = 78
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(185, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 13)
        Me.Label19.TabIndex = 77
        Me.Label19.Text = "Calidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(789, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Total Pares:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEstatusCalidad
        '
        Me.pnlEstatusCalidad.BackColor = System.Drawing.Color.SaddleBrown
        Me.pnlEstatusCalidad.Location = New System.Drawing.Point(170, 19)
        Me.pnlEstatusCalidad.Name = "pnlEstatusCalidad"
        Me.pnlEstatusCalidad.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusCalidad.TabIndex = 76
        '
        'pnlEstatusDisponible
        '
        Me.pnlEstatusDisponible.BackColor = System.Drawing.Color.SeaGreen
        Me.pnlEstatusDisponible.Location = New System.Drawing.Point(16, 19)
        Me.pnlEstatusDisponible.Name = "pnlEstatusDisponible"
        Me.pnlEstatusDisponible.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusDisponible.TabIndex = 68
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(109, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 75
        Me.Label16.Text = "Reproceso"
        '
        'pnlEstatusAsignado
        '
        Me.pnlEstatusAsignado.BackColor = System.Drawing.Color.RoyalBlue
        Me.pnlEstatusAsignado.Location = New System.Drawing.Point(94, 19)
        Me.pnlEstatusAsignado.Name = "pnlEstatusAsignado"
        Me.pnlEstatusAsignado.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusAsignado.TabIndex = 72
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(31, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 71
        Me.Label13.Text = "Bloqueado"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(31, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Disponible"
        '
        'pnlEstatusReproceso
        '
        Me.pnlEstatusReproceso.BackColor = System.Drawing.Color.Indigo
        Me.pnlEstatusReproceso.Location = New System.Drawing.Point(94, 35)
        Me.pnlEstatusReproceso.Name = "pnlEstatusReproceso"
        Me.pnlEstatusReproceso.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusReproceso.TabIndex = 74
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(109, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "Asignado"
        '
        'pnlEstatusBloqueado
        '
        Me.pnlEstatusBloqueado.BackColor = System.Drawing.Color.Red
        Me.pnlEstatusBloqueado.Location = New System.Drawing.Point(16, 35)
        Me.pnlEstatusBloqueado.Name = "pnlEstatusBloqueado"
        Me.pnlEstatusBloqueado.Size = New System.Drawing.Size(15, 15)
        Me.pnlEstatusBloqueado.TabIndex = 70
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(425, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'VerParesDisponibleApartadoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 566)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Name = "VerParesDisponibleApartadoForm"
        Me.Text = "Pares en existencia disponible del apartado "
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdParesDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlResumen.ResumeLayout(False)
        Me.pnlResumen.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlLocalizadoCoppel As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlLocalizadoError As System.Windows.Forms.Panel
    Friend WithEvents pnlLocalizadoAtado As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlLocalizadoPar As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdParesDisponibles As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTextoTituloVentana As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlResumen As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlEstatusValidado As System.Windows.Forms.Panel
    Friend WithEvents lblUltimaActualizacionHora As System.Windows.Forms.Label
    Friend WithEvents lblUltimaActualizacionFecha As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents pnlEstatusProyectado As System.Windows.Forms.Panel
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlEstatusCalidad As System.Windows.Forms.Panel
    Friend WithEvents pnlEstatusDisponible As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pnlEstatusAsignado As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pnlEstatusReproceso As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents pnlEstatusBloqueado As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
