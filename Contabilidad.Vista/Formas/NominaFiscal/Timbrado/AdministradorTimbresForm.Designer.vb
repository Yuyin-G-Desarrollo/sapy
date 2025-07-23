<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorTimbresForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorTimbresForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlCancelar = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlGenerarPDF = New System.Windows.Forms.Panel()
        Me.btnGenerarPDF = New System.Windows.Forms.Button()
        Me.lblGenerarPDF = New System.Windows.Forms.Label()
        Me.pnlTimbrar = New System.Windows.Forms.Panel()
        Me.btnTimbrar = New System.Windows.Forms.Button()
        Me.lblTimbrar = New System.Windows.Forms.Label()
        Me.pnlDescargarArchivos = New System.Windows.Forms.Panel()
        Me.btnDescargarArchivos = New System.Windows.Forms.Button()
        Me.lblDescargarArchivos = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPagado = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblRecibos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNoTimbrados = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTimbrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbTimbrado = New System.Windows.Forms.ComboBox()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.pnlArchivoCargado = New System.Windows.Forms.Panel()
        Me.btnSeleccionarColaborador = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rdoPeriodo = New System.Windows.Forms.RadioButton()
        Me.rdoRango = New System.Windows.Forms.RadioButton()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.grdRecibos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlCancelar.SuspendLayout()
        Me.pnlGenerarPDF.SuspendLayout()
        Me.pnlTimbrar.SuspendLayout()
        Me.pnlDescargarArchivos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlImprimir)
        Me.pnlEncabezado.Controls.Add(Me.pnlExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlCancelar)
        Me.pnlEncabezado.Controls.Add(Me.pnlGenerarPDF)
        Me.pnlEncabezado.Controls.Add(Me.pnlTimbrar)
        Me.pnlEncabezado.Controls.Add(Me.pnlDescargarArchivos)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1254, 69)
        Me.pnlEncabezado.TabIndex = 7
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.lblImprimir)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(309, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(59, 69)
        Me.pnlImprimir.TabIndex = 51
        '
        'btnImprimir
        '
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(13, 7)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 31
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(6, 40)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(46, 27)
        Me.lblImprimir.TabIndex = 32
        Me.lblImprimir.Text = "Imprimir Listado"
        Me.lblImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(250, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(59, 69)
        Me.pnlExportar.TabIndex = 50
        '
        'btnExportar
        '
        Me.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExportar.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(13, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 22
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(6, 40)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 27)
        Me.lblExportar.TabIndex = 23
        Me.lblExportar.Text = "Exportar Listado"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCancelar
        '
        Me.pnlCancelar.Controls.Add(Me.btnCancelar)
        Me.pnlCancelar.Controls.Add(Me.lblCancelar)
        Me.pnlCancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCancelar.Location = New System.Drawing.Point(190, 0)
        Me.pnlCancelar.Name = "pnlCancelar"
        Me.pnlCancelar.Size = New System.Drawing.Size(60, 69)
        Me.pnlCancelar.TabIndex = 48
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(13, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 22
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(4, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(51, 16)
        Me.lblCancelar.TabIndex = 23
        Me.lblCancelar.Text = "Cancelar"
        Me.lblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlGenerarPDF
        '
        Me.pnlGenerarPDF.Controls.Add(Me.btnGenerarPDF)
        Me.pnlGenerarPDF.Controls.Add(Me.lblGenerarPDF)
        Me.pnlGenerarPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarPDF.Location = New System.Drawing.Point(130, 0)
        Me.pnlGenerarPDF.Name = "pnlGenerarPDF"
        Me.pnlGenerarPDF.Size = New System.Drawing.Size(60, 69)
        Me.pnlGenerarPDF.TabIndex = 47
        '
        'btnGenerarPDF
        '
        Me.btnGenerarPDF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerarPDF.Image = Global.Contabilidad.Vista.My.Resources.Resources.pdf_32
        Me.btnGenerarPDF.Location = New System.Drawing.Point(13, 7)
        Me.btnGenerarPDF.Name = "btnGenerarPDF"
        Me.btnGenerarPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarPDF.TabIndex = 22
        Me.btnGenerarPDF.UseVisualStyleBackColor = True
        '
        'lblGenerarPDF
        '
        Me.lblGenerarPDF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGenerarPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarPDF.Location = New System.Drawing.Point(6, 40)
        Me.lblGenerarPDF.Name = "lblGenerarPDF"
        Me.lblGenerarPDF.Size = New System.Drawing.Size(46, 27)
        Me.lblGenerarPDF.TabIndex = 23
        Me.lblGenerarPDF.Text = "Generar PDF"
        Me.lblGenerarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTimbrar
        '
        Me.pnlTimbrar.Controls.Add(Me.btnTimbrar)
        Me.pnlTimbrar.Controls.Add(Me.lblTimbrar)
        Me.pnlTimbrar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTimbrar.Location = New System.Drawing.Point(70, 0)
        Me.pnlTimbrar.Name = "pnlTimbrar"
        Me.pnlTimbrar.Size = New System.Drawing.Size(60, 69)
        Me.pnlTimbrar.TabIndex = 46
        '
        'btnTimbrar
        '
        Me.btnTimbrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTimbrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.reporteDeducciones_
        Me.btnTimbrar.Location = New System.Drawing.Point(14, 7)
        Me.btnTimbrar.Name = "btnTimbrar"
        Me.btnTimbrar.Size = New System.Drawing.Size(32, 32)
        Me.btnTimbrar.TabIndex = 31
        Me.btnTimbrar.UseVisualStyleBackColor = True
        '
        'lblTimbrar
        '
        Me.lblTimbrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTimbrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTimbrar.Location = New System.Drawing.Point(7, 40)
        Me.lblTimbrar.Name = "lblTimbrar"
        Me.lblTimbrar.Size = New System.Drawing.Size(44, 16)
        Me.lblTimbrar.TabIndex = 32
        Me.lblTimbrar.Text = "Timbrar"
        Me.lblTimbrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDescargarArchivos
        '
        Me.pnlDescargarArchivos.Controls.Add(Me.btnDescargarArchivos)
        Me.pnlDescargarArchivos.Controls.Add(Me.lblDescargarArchivos)
        Me.pnlDescargarArchivos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDescargarArchivos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDescargarArchivos.Name = "pnlDescargarArchivos"
        Me.pnlDescargarArchivos.Size = New System.Drawing.Size(70, 69)
        Me.pnlDescargarArchivos.TabIndex = 44
        '
        'btnDescargarArchivos
        '
        Me.btnDescargarArchivos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDescargarArchivos.Image = Global.Contabilidad.Vista.My.Resources.Resources.descargarBlanco
        Me.btnDescargarArchivos.Location = New System.Drawing.Point(20, 7)
        Me.btnDescargarArchivos.Name = "btnDescargarArchivos"
        Me.btnDescargarArchivos.Size = New System.Drawing.Size(32, 32)
        Me.btnDescargarArchivos.TabIndex = 31
        Me.btnDescargarArchivos.UseVisualStyleBackColor = True
        '
        'lblDescargarArchivos
        '
        Me.lblDescargarArchivos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDescargarArchivos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDescargarArchivos.Location = New System.Drawing.Point(6, 40)
        Me.lblDescargarArchivos.Name = "lblDescargarArchivos"
        Me.lblDescargarArchivos.Size = New System.Drawing.Size(59, 27)
        Me.lblDescargarArchivos.TabIndex = 32
        Me.lblDescargarArchivos.Text = "Descargar Archivos"
        Me.lblDescargarArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(779, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 69)
        Me.Panel1.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(96, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(305, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de Recibos de Nómina"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 496)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1254, 60)
        Me.pnlPie.TabIndex = 11
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1186, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(68, 60)
        Me.pnlOperaciones.TabIndex = 24
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(17, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 28
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(16, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 29
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.lblTotal)
        Me.pnlEstado.Controls.Add(Me.Label11)
        Me.pnlEstado.Controls.Add(Me.lblPagado)
        Me.pnlEstado.Controls.Add(Me.Label7)
        Me.pnlEstado.Controls.Add(Me.Label8)
        Me.pnlEstado.Controls.Add(Me.Label9)
        Me.pnlEstado.Controls.Add(Me.Label4)
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.lblRecibos)
        Me.pnlEstado.Controls.Add(Me.Label5)
        Me.pnlEstado.Controls.Add(Me.lblNoTimbrados)
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Controls.Add(Me.lblTimbrados)
        Me.pnlEstado.Controls.Add(Me.Label1)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1180, 60)
        Me.pnlEstado.TabIndex = 22
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(670, 16)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(75, 13)
        Me.lblTotal.TabIndex = 69
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(633, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Total:"
        '
        'lblPagado
        '
        Me.lblPagado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPagado.AutoSize = True
        Me.lblPagado.ForeColor = System.Drawing.Color.Black
        Me.lblPagado.Location = New System.Drawing.Point(271, 37)
        Me.lblPagado.Name = "lblPagado"
        Me.lblPagado.Size = New System.Drawing.Size(58, 13)
        Me.lblPagado.TabIndex = 67
        Me.lblPagado.Text = "Cancelado"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Red
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(251, 37)
        Me.Label7.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label7.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 66
        Me.Label7.UseMnemonic = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(44, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Correcto"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Black
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(23, 37)
        Me.Label9.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label9.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 15)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "___"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(157, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Por Timbrar"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.DarkOrange
        Me.Label6.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label6.Location = New System.Drawing.Point(136, 37)
        Me.Label6.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label6.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 15)
        Me.Label6.TabIndex = 62
        Me.Label6.Text = "___"
        '
        'lblRecibos
        '
        Me.lblRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecibos.Location = New System.Drawing.Point(70, 16)
        Me.lblRecibos.Name = "lblRecibos"
        Me.lblRecibos.Size = New System.Drawing.Size(40, 13)
        Me.lblRecibos.TabIndex = 61
        Me.lblRecibos.Text = "0"
        Me.lblRecibos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Recibos"
        '
        'lblNoTimbrados
        '
        Me.lblNoTimbrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoTimbrados.Location = New System.Drawing.Point(423, 16)
        Me.lblNoTimbrados.Name = "lblNoTimbrados"
        Me.lblNoTimbrados.Size = New System.Drawing.Size(40, 13)
        Me.lblNoTimbrados.TabIndex = 59
        Me.lblNoTimbrados.Text = "0"
        Me.lblNoTimbrados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(345, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "No Timbrados"
        '
        'lblTimbrados
        '
        Me.lblTimbrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimbrados.Location = New System.Drawing.Point(231, 16)
        Me.lblTimbrados.Name = "lblTimbrados"
        Me.lblTimbrados.Size = New System.Drawing.Size(40, 13)
        Me.lblTimbrados.TabIndex = 57
        Me.lblTimbrados.Text = "0"
        Me.lblTimbrados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Timbrados"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.ForeColor = System.Drawing.Color.Black
        Me.lblEmpresa.Location = New System.Drawing.Point(39, 22)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
        Me.lblEmpresa.TabIndex = 43
        Me.lblEmpresa.Text = "Empresa"
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.ForeColor = System.Drawing.Color.Black
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(93, 19)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(450, 21)
        Me.cmbEmpresa.TabIndex = 44
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.ForeColor = System.Drawing.Color.Black
        Me.lblEstatus.Location = New System.Drawing.Point(599, 78)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(28, 13)
        Me.lblEstatus.TabIndex = 45
        Me.lblEstatus.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.ForeColor = System.Drawing.Color.Black
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"", "NÓMINA", "FINIQUITO", "AGUINALDO Y VACACIONES"})
        Me.cmbTipo.Location = New System.Drawing.Point(646, 75)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(214, 21)
        Me.cmbTipo.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(45, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Estatus"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(56, 75)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(93, 46)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(214, 21)
        Me.cmbEstatus.TabIndex = 53
        '
        'lblBuscar
        '
        Me.lblBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(8, 75)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(8, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Estatus Recibo"
        '
        'cmbTimbrado
        '
        Me.cmbTimbrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTimbrado.ForeColor = System.Drawing.Color.Black
        Me.cmbTimbrado.FormattingEnabled = True
        Me.cmbTimbrado.Items.AddRange(New Object() {"", "POR TIMBRAR", "TIMBRADO"})
        Me.cmbTimbrado.Location = New System.Drawing.Point(93, 75)
        Me.cmbTimbrado.Name = "cmbTimbrado"
        Me.cmbTimbrado.Size = New System.Drawing.Size(214, 21)
        Me.cmbTimbrado.TabIndex = 55
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.grbFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 69)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1254, 136)
        Me.pnlFiltros.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Location = New System.Drawing.Point(1186, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(59, 22)
        Me.Panel2.TabIndex = 118
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(32, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 119
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(6, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 118
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbFiltros.Controls.Add(Me.pnlArchivoCargado)
        Me.grbFiltros.Controls.Add(Me.btnSeleccionarColaborador)
        Me.grbFiltros.Controls.Add(Me.Label12)
        Me.grbFiltros.Controls.Add(Me.Panel4)
        Me.grbFiltros.Controls.Add(Me.cmbTimbrado)
        Me.grbFiltros.Controls.Add(Me.cmbPeriodo)
        Me.grbFiltros.Controls.Add(Me.cmbTipo)
        Me.grbFiltros.Controls.Add(Me.lblEstatus)
        Me.grbFiltros.Controls.Add(Me.Label10)
        Me.grbFiltros.Controls.Add(Me.Panel5)
        Me.grbFiltros.Controls.Add(Me.cmbEstatus)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.dtpFechaFin)
        Me.grbFiltros.Controls.Add(Me.Label13)
        Me.grbFiltros.Controls.Add(Me.dtpFechaInicio)
        Me.grbFiltros.Controls.Add(Me.Label14)
        Me.grbFiltros.Controls.Add(Me.cmbEmpresa)
        Me.grbFiltros.Controls.Add(Me.lblEmpresa)
        Me.grbFiltros.Location = New System.Drawing.Point(3, 22)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1248, 110)
        Me.grbFiltros.TabIndex = 113
        Me.grbFiltros.TabStop = False
        '
        'pnlArchivoCargado
        '
        Me.pnlArchivoCargado.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.seleccionar
        Me.pnlArchivoCargado.Location = New System.Drawing.Point(393, 55)
        Me.pnlArchivoCargado.Name = "pnlArchivoCargado"
        Me.pnlArchivoCargado.Size = New System.Drawing.Size(16, 16)
        Me.pnlArchivoCargado.TabIndex = 143
        Me.pnlArchivoCargado.Visible = False
        '
        'btnSeleccionarColaborador
        '
        Me.btnSeleccionarColaborador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeleccionarColaborador.Image = Global.Contabilidad.Vista.My.Resources.Resources.perfiles_32
        Me.btnSeleccionarColaborador.Location = New System.Drawing.Point(355, 47)
        Me.btnSeleccionarColaborador.Name = "btnSeleccionarColaborador"
        Me.btnSeleccionarColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnSeleccionarColaborador.TabIndex = 120
        Me.btnSeleccionarColaborador.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.Location = New System.Drawing.Point(338, 79)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 17)
        Me.Label12.TabIndex = 121
        Me.Label12.Text = "Colaborador"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnLimpiar)
        Me.Panel4.Controls.Add(Me.btnBuscar)
        Me.Panel4.Controls.Add(Me.lblLimpiar)
        Me.Panel4.Controls.Add(Me.lblBuscar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1146, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(99, 91)
        Me.Panel4.TabIndex = 119
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(59, 43)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(11, 43)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(646, 19)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(450, 21)
        Me.cmbPeriodo.TabIndex = 106
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.rdoPeriodo)
        Me.Panel5.Controls.Add(Me.rdoRango)
        Me.Panel5.Location = New System.Drawing.Point(563, 12)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(77, 60)
        Me.Panel5.TabIndex = 105
        '
        'rdoPeriodo
        '
        Me.rdoPeriodo.AutoSize = True
        Me.rdoPeriodo.Checked = True
        Me.rdoPeriodo.Location = New System.Drawing.Point(3, 8)
        Me.rdoPeriodo.Name = "rdoPeriodo"
        Me.rdoPeriodo.Size = New System.Drawing.Size(61, 17)
        Me.rdoPeriodo.TabIndex = 86
        Me.rdoPeriodo.TabStop = True
        Me.rdoPeriodo.Text = "Periodo"
        Me.rdoPeriodo.UseVisualStyleBackColor = True
        '
        'rdoRango
        '
        Me.rdoRango.AutoSize = True
        Me.rdoRango.Location = New System.Drawing.Point(3, 35)
        Me.rdoRango.Name = "rdoRango"
        Me.rdoRango.Size = New System.Drawing.Size(57, 17)
        Me.rdoRango.TabIndex = 85
        Me.rdoRango.Text = "Rango"
        Me.rdoRango.UseVisualStyleBackColor = True
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Enabled = False
        Me.dtpFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Location = New System.Drawing.Point(927, 47)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(193, 20)
        Me.dtpFechaFin.TabIndex = 88
        Me.dtpFechaFin.Value = New Date(2017, 11, 24, 0, 0, 0, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(905, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 13)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Al"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Enabled = False
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Location = New System.Drawing.Point(706, 47)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(193, 20)
        Me.dtpFechaInicio.TabIndex = 86
        Me.dtpFechaInicio.Value = New Date(2017, 11, 24, 0, 0, 0, 0)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(646, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "Fecha del"
        '
        'grdRecibos
        '
        Me.grdRecibos.CausesValidation = False
        Me.grdRecibos.Cursor = System.Windows.Forms.Cursors.Default
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 7.0!
        Appearance1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdRecibos.DisplayLayout.Appearance = Appearance1
        Me.grdRecibos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdRecibos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdRecibos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdRecibos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdRecibos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdRecibos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdRecibos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdRecibos.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdRecibos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdRecibos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdRecibos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRecibos.Location = New System.Drawing.Point(0, 205)
        Me.grdRecibos.Name = "grdRecibos"
        Me.grdRecibos.Size = New System.Drawing.Size(1254, 291)
        Me.grdRecibos.TabIndex = 14
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(403, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 48
        Me.imgLogo.TabStop = False
        '
        'AdministradorTimbresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1254, 556)
        Me.Controls.Add(Me.grdRecibos)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "AdministradorTimbresForm"
        Me.Text = "Administrador de Recibos de Nómina"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlCancelar.ResumeLayout(False)
        Me.pnlGenerarPDF.ResumeLayout(False)
        Me.pnlTimbrar.ResumeLayout(False)
        Me.pnlDescargarArchivos.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.grdRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents lblNoTimbrados As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTimbrados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents pnlGenerarPDF As System.Windows.Forms.Panel
    Friend WithEvents btnGenerarPDF As System.Windows.Forms.Button
    Friend WithEvents lblGenerarPDF As System.Windows.Forms.Label
    Friend WithEvents pnlTimbrar As System.Windows.Forms.Panel
    Friend WithEvents btnTimbrar As System.Windows.Forms.Button
    Friend WithEvents lblTimbrar As System.Windows.Forms.Label
    Friend WithEvents pnlDescargarArchivos As System.Windows.Forms.Panel
    Friend WithEvents btnDescargarArchivos As System.Windows.Forms.Button
    Friend WithEvents lblDescargarArchivos As System.Windows.Forms.Label
    Friend WithEvents lblRecibos As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlExportar As System.Windows.Forms.Panel
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents pnlImprimir As System.Windows.Forms.Panel
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPagado As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTimbrado As System.Windows.Forms.ComboBox
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents rdoPeriodo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRango As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents grdRecibos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnSeleccionarColaborador As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlArchivoCargado As System.Windows.Forms.Panel
    Friend WithEvents pnlCancelar As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
