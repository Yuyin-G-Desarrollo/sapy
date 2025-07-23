<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaSolicitudesIncapacidadesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaSolicitudesIncapacidadesForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlAplicar = New System.Windows.Forms.Panel()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlTXT = New System.Windows.Forms.Panel()
        Me.btnGenerarttx = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlAltas = New System.Windows.Forms.Panel()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.gpbFiltro = New System.Windows.Forms.GroupBox()
        Me.cmbTipoIncapacidad = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.chkFormatoSt7 = New System.Windows.Forms.CheckBox()
        Me.chkFormatoSt2 = New System.Windows.Forms.CheckBox()
        Me.chkIncapacidad = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkPorFechas = New System.Windows.Forms.CheckBox()
        Me.dttFin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dttInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblPagado = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdIncapacidades = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.guardarArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlAplicar.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlTXT.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlAltas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gpbFiltro.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdIncapacidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlAplicar)
        Me.pnlListaPaises.Controls.Add(Me.pnlImprimir)
        Me.pnlListaPaises.Controls.Add(Me.pnlExportar)
        Me.pnlListaPaises.Controls.Add(Me.pnlTXT)
        Me.pnlListaPaises.Controls.Add(Me.pnlEditar)
        Me.pnlListaPaises.Controls.Add(Me.pnlAltas)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1241, 69)
        Me.pnlListaPaises.TabIndex = 24
        '
        'pnlAplicar
        '
        Me.pnlAplicar.Controls.Add(Me.btnAplicar)
        Me.pnlAplicar.Controls.Add(Me.Label1)
        Me.pnlAplicar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAplicar.Location = New System.Drawing.Point(342, 0)
        Me.pnlAplicar.Name = "pnlAplicar"
        Me.pnlAplicar.Size = New System.Drawing.Size(59, 69)
        Me.pnlAplicar.TabIndex = 101
        '
        'btnAplicar
        '
        Me.btnAplicar.Image = Global.Contabilidad.Vista.My.Resources.Resources.aceptar_32
        Me.btnAplicar.Location = New System.Drawing.Point(16, 8)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(31, 32)
        Me.btnAplicar.TabIndex = 7
        Me.btnAplicar.UseVisualStyleBackColor = True
        Me.btnAplicar.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Aplicar"
        Me.Label1.Visible = False
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.Label3)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(280, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(62, 69)
        Me.pnlImprimir.TabIndex = 100
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Contabilidad.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(17, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(31, 32)
        Me.btnImprimir.TabIndex = 7
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(11, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Imprimir"
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.Label9)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(211, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(69, 69)
        Me.pnlExportar.TabIndex = 99
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(21, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(31, 32)
        Me.btnExportar.TabIndex = 7
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(15, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Exportar"
        '
        'pnlTXT
        '
        Me.pnlTXT.Controls.Add(Me.btnGenerarttx)
        Me.pnlTXT.Controls.Add(Me.Label10)
        Me.pnlTXT.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTXT.Location = New System.Drawing.Point(132, 0)
        Me.pnlTXT.Name = "pnlTXT"
        Me.pnlTXT.Size = New System.Drawing.Size(79, 69)
        Me.pnlTXT.TabIndex = 11
        '
        'btnGenerarttx
        '
        Me.btnGenerarttx.Image = Global.Contabilidad.Vista.My.Resources.Resources.reporteDeducciones_
        Me.btnGenerarttx.Location = New System.Drawing.Point(24, 7)
        Me.btnGenerarttx.Name = "btnGenerarttx"
        Me.btnGenerarttx.Size = New System.Drawing.Size(31, 32)
        Me.btnGenerarttx.TabIndex = 7
        Me.btnGenerarttx.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.Location = New System.Drawing.Point(5, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Generar TXT"
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.Label8)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEditar.Location = New System.Drawing.Point(66, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(66, 69)
        Me.pnlEditar.TabIndex = 10
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Contabilidad.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(20, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(31, 32)
        Me.btnEditar.TabIndex = 7
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(18, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Editar"
        '
        'pnlAltas
        '
        Me.pnlAltas.Controls.Add(Me.btnAltas)
        Me.pnlAltas.Controls.Add(Me.lblNuevo)
        Me.pnlAltas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAltas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAltas.Name = "pnlAltas"
        Me.pnlAltas.Size = New System.Drawing.Size(66, 69)
        Me.pnlAltas.TabIndex = 9
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(20, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(31, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(20, 41)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(30, 13)
        Me.lblNuevo.TabIndex = 3
        Me.lblNuevo.Text = "Altas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(820, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 69)
        Me.Panel1.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(56, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(294, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Lista de Solicitudes de Incapacidad"
        '
        'gpbFiltro
        '
        Me.gpbFiltro.BackColor = System.Drawing.Color.AliceBlue
        Me.gpbFiltro.Controls.Add(Me.cmbTipoIncapacidad)
        Me.gpbFiltro.Controls.Add(Me.GroupBox2)
        Me.gpbFiltro.Controls.Add(Me.GroupBox1)
        Me.gpbFiltro.Controls.Add(Me.txtNombre)
        Me.gpbFiltro.Controls.Add(Me.Label14)
        Me.gpbFiltro.Controls.Add(Me.Panel10)
        Me.gpbFiltro.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltro.Controls.Add(Me.cmbEstatus)
        Me.gpbFiltro.Controls.Add(Me.cmbPatron)
        Me.gpbFiltro.Controls.Add(Me.Label6)
        Me.gpbFiltro.Controls.Add(Me.Label2)
        Me.gpbFiltro.Controls.Add(Me.lblNave)
        Me.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltro.Location = New System.Drawing.Point(0, 69)
        Me.gpbFiltro.Name = "gpbFiltro"
        Me.gpbFiltro.Size = New System.Drawing.Size(1241, 150)
        Me.gpbFiltro.TabIndex = 28
        Me.gpbFiltro.TabStop = False
        '
        'cmbTipoIncapacidad
        '
        Me.cmbTipoIncapacidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIncapacidad.FormattingEnabled = True
        Me.cmbTipoIncapacidad.Location = New System.Drawing.Point(95, 88)
        Me.cmbTipoIncapacidad.Name = "cmbTipoIncapacidad"
        Me.cmbTipoIncapacidad.Size = New System.Drawing.Size(368, 21)
        Me.cmbTipoIncapacidad.TabIndex = 101
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkTodos)
        Me.GroupBox2.Controls.Add(Me.chkFormatoSt7)
        Me.GroupBox2.Controls.Add(Me.chkFormatoSt2)
        Me.GroupBox2.Controls.Add(Me.chkIncapacidad)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(837, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 84)
        Me.GroupBox2.TabIndex = 99
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ver Archivos"
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodos.Location = New System.Drawing.Point(96, 57)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(56, 17)
        Me.chkTodos.TabIndex = 0
        Me.chkTodos.Text = "Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'chkFormatoSt7
        '
        Me.chkFormatoSt7.AutoSize = True
        Me.chkFormatoSt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFormatoSt7.Location = New System.Drawing.Point(6, 57)
        Me.chkFormatoSt7.Name = "chkFormatoSt7"
        Me.chkFormatoSt7.Size = New System.Drawing.Size(84, 17)
        Me.chkFormatoSt7.TabIndex = 0
        Me.chkFormatoSt7.Text = "FormatoST7"
        Me.chkFormatoSt7.UseVisualStyleBackColor = True
        '
        'chkFormatoSt2
        '
        Me.chkFormatoSt2.AutoSize = True
        Me.chkFormatoSt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFormatoSt2.Location = New System.Drawing.Point(97, 19)
        Me.chkFormatoSt2.Name = "chkFormatoSt2"
        Me.chkFormatoSt2.Size = New System.Drawing.Size(84, 17)
        Me.chkFormatoSt2.TabIndex = 0
        Me.chkFormatoSt2.Text = "FormatoST2"
        Me.chkFormatoSt2.UseVisualStyleBackColor = True
        '
        'chkIncapacidad
        '
        Me.chkIncapacidad.AutoSize = True
        Me.chkIncapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncapacidad.Location = New System.Drawing.Point(6, 19)
        Me.chkIncapacidad.Name = "chkIncapacidad"
        Me.chkIncapacidad.Size = New System.Drawing.Size(85, 17)
        Me.chkIncapacidad.TabIndex = 0
        Me.chkIncapacidad.Text = "Incapacidad"
        Me.chkIncapacidad.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkPorFechas)
        Me.GroupBox1.Controls.Add(Me.dttFin)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dttInicio)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(505, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(311, 87)
        Me.GroupBox1.TabIndex = 98
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'chkPorFechas
        '
        Me.chkPorFechas.AutoSize = True
        Me.chkPorFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPorFechas.Location = New System.Drawing.Point(6, 16)
        Me.chkPorFechas.Name = "chkPorFechas"
        Me.chkPorFechas.Size = New System.Drawing.Size(101, 17)
        Me.chkPorFechas.TabIndex = 0
        Me.chkPorFechas.Text = "Filtro por fechas"
        Me.chkPorFechas.UseVisualStyleBackColor = True
        '
        'dttFin
        '
        Me.dttFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttFin.Location = New System.Drawing.Point(76, 61)
        Me.dttFin.Name = "dttFin"
        Me.dttFin.Size = New System.Drawing.Size(213, 20)
        Me.dttFin.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "Fecha Inicial"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Fecha Final"
        '
        'dttInicio
        '
        Me.dttInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttInicio.Location = New System.Drawing.Point(76, 37)
        Me.dttInicio.Name = "dttInicio"
        Me.dttInicio.Size = New System.Drawing.Size(213, 20)
        Me.dttInicio.TabIndex = 96
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(95, 115)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(368, 20)
        Me.txtNombre.TabIndex = 97
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(45, 119)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Nombre"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblLimpiar)
        Me.Panel10.Controls.Add(Me.btnFiltrarSolicitud)
        Me.Panel10.Controls.Add(Me.lblBuscar)
        Me.Panel10.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(1061, 16)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(112, 131)
        Me.Panel10.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(66, 52)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(20, 21)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 4
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(15, 52)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(70, 21)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 5
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1173, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(65, 131)
        Me.pnlMinimizarParametros.TabIndex = 44
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(8, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(37, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(95, 62)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(368, 21)
        Me.cmbEstatus.TabIndex = 1
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.ForeColor = System.Drawing.Color.Black
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(95, 35)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(368, 21)
        Me.cmbPatron.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(-1, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Tipo Incapacidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(49, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Estado"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(51, 39)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(38, 13)
        Me.lblNave.TabIndex = 25
        Me.lblNave.Text = "Patrón"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblPagado)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1241, 60)
        Me.Panel2.TabIndex = 29
        '
        'lblPagado
        '
        Me.lblPagado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPagado.AutoSize = True
        Me.lblPagado.ForeColor = System.Drawing.Color.Black
        Me.lblPagado.Location = New System.Drawing.Point(45, 23)
        Me.lblPagado.Name = "lblPagado"
        Me.lblPagado.Size = New System.Drawing.Size(160, 13)
        Me.lblPagado.TabIndex = 39
        Me.lblPagado.Text = "Modificada después de aplicada"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Red
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(25, 23)
        Me.Label7.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label7.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 38
        Me.Label7.UseMnemonic = False
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnCerrar)
        Me.Panel7.Controls.Add(Me.lblCerrar)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(1189, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(52, 60)
        Me.Panel7.TabIndex = 37
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(9, 4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(8, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 19
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdIncapacidades
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdIncapacidades.DisplayLayout.Appearance = Appearance1
        Me.grdIncapacidades.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdIncapacidades.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdIncapacidades.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdIncapacidades.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdIncapacidades.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdIncapacidades.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdIncapacidades.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdIncapacidades.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdIncapacidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdIncapacidades.Location = New System.Drawing.Point(0, 219)
        Me.grdIncapacidades.Name = "grdIncapacidades"
        Me.grdIncapacidades.Size = New System.Drawing.Size(1241, 246)
        Me.grdIncapacidades.TabIndex = 30
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(349, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'ListaSolicitudesIncapacidadesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 525)
        Me.Controls.Add(Me.grdIncapacidades)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gpbFiltro)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "ListaSolicitudesIncapacidadesForm"
        Me.Text = "ListaSolicitudesIncapacidadesForm"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlAplicar.ResumeLayout(False)
        Me.pnlAplicar.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlTXT.ResumeLayout(False)
        Me.pnlTXT.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlAltas.ResumeLayout(False)
        Me.pnlAltas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpbFiltro.ResumeLayout(False)
        Me.gpbFiltro.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.grdIncapacidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlTXT As System.Windows.Forms.Panel
    Friend WithEvents btnGenerarttx As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlEditar As System.Windows.Forms.Panel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlAltas As System.Windows.Forms.Panel
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents gpbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbPatron As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdIncapacidades As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlExportar As System.Windows.Forms.Panel
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlImprimir As System.Windows.Forms.Panel
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dttFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dttInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkIncapacidad As System.Windows.Forms.CheckBox
    Friend WithEvents chkPorFechas As System.Windows.Forms.CheckBox
    Friend WithEvents chkFormatoSt7 As System.Windows.Forms.CheckBox
    Friend WithEvents chkFormatoSt2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents guardarArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pnlAplicar As System.Windows.Forms.Panel
    Friend WithEvents cmbTipoIncapacidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPagado As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
