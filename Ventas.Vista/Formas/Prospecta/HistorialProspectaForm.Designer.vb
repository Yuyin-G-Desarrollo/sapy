<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistorialProspectaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HistorialProspectaForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlConsultarPorMarca = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnConsultaPorMarca = New System.Windows.Forms.Button()
        Me.pnlConsultarProspectado = New System.Windows.Forms.Panel()
        Me.btnConsultarProspecta = New System.Windows.Forms.Button()
        Me.lblConsultaProspecta = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlAltas = New System.Windows.Forms.Panel()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblHistorialProspecta = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rdoFecha = New System.Windows.Forms.RadioButton()
        Me.rdoSemana = New System.Windows.Forms.RadioButton()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.nudNumSemana = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtmFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtmFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlCerrada = New System.Windows.Forms.Panel()
        Me.pnlRevision = New System.Windows.Forms.Panel()
        Me.pnlVigente = New System.Windows.Forms.Panel()
        Me.pnlProxima = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.gridListaHistorialProspecta = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlConsultarPorMarca.SuspendLayout()
        Me.pnlConsultarProspectado.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlAltas.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.gridListaHistorialProspecta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlConsultarPorMarca)
        Me.pnlEncabezado.Controls.Add(Me.pnlConsultarProspectado)
        Me.pnlEncabezado.Controls.Add(Me.pnlExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlAltas)
        Me.pnlEncabezado.Controls.Add(Me.Panel2)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1184, 65)
        Me.pnlEncabezado.TabIndex = 68
        '
        'pnlConsultarPorMarca
        '
        Me.pnlConsultarPorMarca.Controls.Add(Me.Label17)
        Me.pnlConsultarPorMarca.Controls.Add(Me.btnConsultaPorMarca)
        Me.pnlConsultarPorMarca.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConsultarPorMarca.Location = New System.Drawing.Point(195, 0)
        Me.pnlConsultarPorMarca.Name = "pnlConsultarPorMarca"
        Me.pnlConsultarPorMarca.Size = New System.Drawing.Size(65, 65)
        Me.pnlConsultarPorMarca.TabIndex = 53
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label17.Location = New System.Drawing.Point(5, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 26)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Consulta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "por Marca"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnConsultaPorMarca
        '
        Me.btnConsultaPorMarca.Image = Global.Ventas.Vista.My.Resources.Resources.catalogos_32
        Me.btnConsultaPorMarca.Location = New System.Drawing.Point(16, 3)
        Me.btnConsultaPorMarca.Name = "btnConsultaPorMarca"
        Me.btnConsultaPorMarca.Size = New System.Drawing.Size(32, 32)
        Me.btnConsultaPorMarca.TabIndex = 49
        Me.btnConsultaPorMarca.UseVisualStyleBackColor = True
        '
        'pnlConsultarProspectado
        '
        Me.pnlConsultarProspectado.Controls.Add(Me.btnConsultarProspecta)
        Me.pnlConsultarProspectado.Controls.Add(Me.lblConsultaProspecta)
        Me.pnlConsultarProspectado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConsultarProspectado.Location = New System.Drawing.Point(120, 0)
        Me.pnlConsultarProspectado.Name = "pnlConsultarProspectado"
        Me.pnlConsultarProspectado.Size = New System.Drawing.Size(75, 65)
        Me.pnlConsultarProspectado.TabIndex = 52
        '
        'btnConsultarProspecta
        '
        Me.btnConsultarProspecta.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnConsultarProspecta.Location = New System.Drawing.Point(21, 3)
        Me.btnConsultarProspecta.Name = "btnConsultarProspecta"
        Me.btnConsultarProspecta.Size = New System.Drawing.Size(32, 32)
        Me.btnConsultarProspecta.TabIndex = 48
        Me.btnConsultarProspecta.UseVisualStyleBackColor = True
        '
        'lblConsultaProspecta
        '
        Me.lblConsultaProspecta.AutoSize = True
        Me.lblConsultaProspecta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConsultaProspecta.Location = New System.Drawing.Point(5, 35)
        Me.lblConsultaProspecta.Name = "lblConsultaProspecta"
        Me.lblConsultaProspecta.Size = New System.Drawing.Size(66, 26)
        Me.lblConsultaProspecta.TabIndex = 49
        Me.lblConsultaProspecta.Text = "Consultar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "prospectado"
        Me.lblConsultaProspecta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblEditar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(60, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(60, 65)
        Me.pnlExportar.TabIndex = 51
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(14, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 11
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(7, 39)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(46, 13)
        Me.lblEditar.TabIndex = 19
        Me.lblEditar.Text = "Exportar"
        Me.lblEditar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAltas
        '
        Me.pnlAltas.Controls.Add(Me.btnAltas)
        Me.pnlAltas.Controls.Add(Me.lblAltas)
        Me.pnlAltas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAltas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAltas.Name = "pnlAltas"
        Me.pnlAltas.Size = New System.Drawing.Size(60, 65)
        Me.pnlAltas.TabIndex = 50
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(14, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 10
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(16, 40)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        Me.lblAltas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblHistorialProspecta)
        Me.Panel2.Location = New System.Drawing.Point(915, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(195, 41)
        Me.Panel2.TabIndex = 47
        '
        'lblHistorialProspecta
        '
        Me.lblHistorialProspecta.AutoSize = True
        Me.lblHistorialProspecta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistorialProspecta.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblHistorialProspecta.Location = New System.Drawing.Point(20, 10)
        Me.lblHistorialProspecta.Name = "lblHistorialProspecta"
        Me.lblHistorialProspecta.Size = New System.Drawing.Size(161, 20)
        Me.lblHistorialProspecta.TabIndex = 46
        Me.lblHistorialProspecta.Text = "Historial Prospecta"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1116, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.rdoFecha)
        Me.Panel6.Controls.Add(Me.rdoSemana)
        Me.Panel6.Controls.Add(Me.nudAño)
        Me.Panel6.Controls.Add(Me.nudNumSemana)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.Panel1)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.dtmFechaFin)
        Me.Panel6.Controls.Add(Me.dtmFechaInicio)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 65)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1184, 62)
        Me.Panel6.TabIndex = 69
        '
        'rdoFecha
        '
        Me.rdoFecha.AutoSize = True
        Me.rdoFecha.Checked = True
        Me.rdoFecha.Location = New System.Drawing.Point(21, 37)
        Me.rdoFecha.Name = "rdoFecha"
        Me.rdoFecha.Size = New System.Drawing.Size(90, 17)
        Me.rdoFecha.TabIndex = 82
        Me.rdoFecha.TabStop = True
        Me.rdoFecha.Text = "Rango Fecha"
        Me.rdoFecha.UseVisualStyleBackColor = True
        '
        'rdoSemana
        '
        Me.rdoSemana.AutoSize = True
        Me.rdoSemana.Location = New System.Drawing.Point(21, 9)
        Me.rdoSemana.Name = "rdoSemana"
        Me.rdoSemana.Size = New System.Drawing.Size(64, 17)
        Me.rdoSemana.TabIndex = 81
        Me.rdoSemana.TabStop = True
        Me.rdoSemana.Text = "Semana"
        Me.rdoSemana.UseVisualStyleBackColor = True
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(224, 7)
        Me.nudAño.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(54, 20)
        Me.nudAño.TabIndex = 80
        Me.nudAño.Value = New Decimal(New Integer() {2017, 0, 0, 0})
        '
        'nudNumSemana
        '
        Me.nudNumSemana.Location = New System.Drawing.Point(168, 7)
        Me.nudNumSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNumSemana.Name = "nudNumSemana"
        Me.nudNumSemana.Size = New System.Drawing.Size(45, 20)
        Me.nudNumSemana.TabIndex = 79
        Me.nudNumSemana.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(122, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "Semana"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.lblAceptar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1110, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(74, 62)
        Me.Panel1.TabIndex = 43
        '
        'btnMostrar
        '
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(23, 5)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(19, 37)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Mostrar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Del"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(252, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Al"
        '
        'dtmFechaFin
        '
        Me.dtmFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaFin.Location = New System.Drawing.Point(270, 34)
        Me.dtmFechaFin.Name = "dtmFechaFin"
        Me.dtmFechaFin.Size = New System.Drawing.Size(88, 20)
        Me.dtmFechaFin.TabIndex = 40
        '
        'dtmFechaInicio
        '
        Me.dtmFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaInicio.Location = New System.Drawing.Point(154, 34)
        Me.dtmFechaInicio.Name = "dtmFechaInicio"
        Me.dtmFechaInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtmFechaInicio.TabIndex = 39
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Label16)
        Me.pnlPie.Controls.Add(Me.Label14)
        Me.pnlPie.Controls.Add(Me.Label15)
        Me.pnlPie.Controls.Add(Me.Label13)
        Me.pnlPie.Controls.Add(Me.pnlCerrada)
        Me.pnlPie.Controls.Add(Me.pnlRevision)
        Me.pnlPie.Controls.Add(Me.pnlVigente)
        Me.pnlPie.Controls.Add(Me.pnlProxima)
        Me.pnlPie.Controls.Add(Me.Label8)
        Me.pnlPie.Controls.Add(Me.Label9)
        Me.pnlPie.Controls.Add(Me.Label10)
        Me.pnlPie.Controls.Add(Me.Label11)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.Label7)
        Me.pnlPie.Controls.Add(Me.Label6)
        Me.pnlPie.Controls.Add(Me.Label4)
        Me.pnlPie.Controls.Add(Me.Label3)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 510)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1184, 60)
        Me.pnlPie.TabIndex = 70
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(574, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 133
        Me.Label16.Text = "Cerrada"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(473, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 133
        Me.Label14.Text = "Revisión"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(574, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 132
        Me.Label15.Text = "Vigente"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(473, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 132
        Me.Label13.Text = "Próxima"
        '
        'pnlCerrada
        '
        Me.pnlCerrada.BackColor = System.Drawing.Color.Purple
        Me.pnlCerrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCerrada.Location = New System.Drawing.Point(551, 28)
        Me.pnlCerrada.Name = "pnlCerrada"
        Me.pnlCerrada.Size = New System.Drawing.Size(17, 17)
        Me.pnlCerrada.TabIndex = 130
        '
        'pnlRevision
        '
        Me.pnlRevision.BackColor = System.Drawing.Color.Yellow
        Me.pnlRevision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRevision.Location = New System.Drawing.Point(450, 28)
        Me.pnlRevision.Name = "pnlRevision"
        Me.pnlRevision.Size = New System.Drawing.Size(17, 17)
        Me.pnlRevision.TabIndex = 130
        '
        'pnlVigente
        '
        Me.pnlVigente.BackColor = System.Drawing.Color.Green
        Me.pnlVigente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVigente.Location = New System.Drawing.Point(551, 9)
        Me.pnlVigente.Name = "pnlVigente"
        Me.pnlVigente.Size = New System.Drawing.Size(17, 17)
        Me.pnlVigente.TabIndex = 129
        '
        'pnlProxima
        '
        Me.pnlProxima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProxima.Location = New System.Drawing.Point(450, 9)
        Me.pnlProxima.Name = "pnlProxima"
        Me.pnlProxima.Size = New System.Drawing.Size(17, 17)
        Me.pnlProxima.TabIndex = 129
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(771, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(220, 13)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Cantidad de pares a proyectados por Ventas."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(771, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 13)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "Cantidad de pares entregados."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(683, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "Prs Proyectados"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(683, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Prs Entregados"
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(279, 27)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 123
        Me.lblFechaUltimaActualizacion.Text = "24/05/2016 01:54 PM"
        Me.lblFechaUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoUltimaDistribucion
        '
        Me.lblTextoUltimaDistribucion.AutoSize = True
        Me.lblTextoUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(167, 27)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(105, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 124
        Me.lblTextoUltimaDistribucion.Text = "Última Actualización:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(21, 27)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 118
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 24)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Registros"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(771, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(206, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Cantidad de pares a proyectar por Ventas."
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(771, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(228, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Cantidad de pares capturados en la prospecta."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(683, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Prs a Proyectar"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(683, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Prs Prospecta"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1033, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(151, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(102, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(101, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'gridListaHistorialProspecta
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaHistorialProspecta.DisplayLayout.Appearance = Appearance1
        Me.gridListaHistorialProspecta.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaHistorialProspecta.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaHistorialProspecta.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaHistorialProspecta.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaHistorialProspecta.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaHistorialProspecta.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaHistorialProspecta.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaHistorialProspecta.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaHistorialProspecta.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.gridListaHistorialProspecta.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaHistorialProspecta.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaHistorialProspecta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaHistorialProspecta.Location = New System.Drawing.Point(0, 127)
        Me.gridListaHistorialProspecta.Name = "gridListaHistorialProspecta"
        Me.gridListaHistorialProspecta.Size = New System.Drawing.Size(1184, 383)
        Me.gridListaHistorialProspecta.TabIndex = 71
        '
        'HistorialProspectaForm
        '
        Me.ClientSize = New System.Drawing.Size(1184, 570)
        Me.Controls.Add(Me.gridListaHistorialProspecta)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "HistorialProspectaForm"
        Me.Text = "Historial Prospecta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlConsultarPorMarca.ResumeLayout(False)
        Me.pnlConsultarPorMarca.PerformLayout()
        Me.pnlConsultarProspectado.ResumeLayout(False)
        Me.pnlConsultarProspectado.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlAltas.ResumeLayout(False)
        Me.pnlAltas.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNumSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.gridListaHistorialProspecta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents lblHistorialProspecta As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtmFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtmFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gridListaHistorialProspecta As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFechaUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents nudAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudNumSemana As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rdoFecha As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSemana As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlCerrada As System.Windows.Forms.Panel
    Friend WithEvents pnlRevision As System.Windows.Forms.Panel
    Friend WithEvents pnlVigente As System.Windows.Forms.Panel
    Friend WithEvents pnlProxima As System.Windows.Forms.Panel
    Friend WithEvents lblConsultaProspecta As System.Windows.Forms.Label
    Friend WithEvents btnConsultarProspecta As System.Windows.Forms.Button
    Friend WithEvents pnlConsultarPorMarca As Panel

    Friend WithEvents Label17 As Label
    Friend WithEvents btnConsultaPorMarca As Button
    Friend WithEvents pnlConsultarProspectado As Panel
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents pnlAltas As Panel
End Class
