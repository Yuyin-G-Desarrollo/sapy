<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaDiaAdicionalForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaDiaAdicionalForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.gpbFiltroIncentivos = New System.Windows.Forms.GroupBox()
        Me.lblMaximo = New System.Windows.Forms.Label()
        Me.chkVerHorasCheco = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoSoloIncremento = New System.Windows.Forms.RadioButton()
        Me.txtIncremento = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdoMedioDia = New System.Windows.Forms.RadioButton()
        Me.rdoDiaCompleto = New System.Windows.Forms.RadioButton()
        Me.dttDia = New System.Windows.Forms.DateTimePicker()
        Me.cmbConcepto = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCelula = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPuesto = New System.Windows.Forms.ComboBox()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.cboxPeriodo = New System.Windows.Forms.ComboBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.btnSubir = New System.Windows.Forms.Button()
        Me.btnBajar = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.txtDepartamento = New System.Windows.Forms.Label()
        Me.txtBuscarNombreIncentivo = New System.Windows.Forms.TextBox()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.pnColores = New System.Windows.Forms.Panel()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grdColaboradores = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gpbFiltroIncentivos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtIncremento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnColores.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1239, 59)
        Me.pnlListaPaises.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(827, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(412, 59)
        Me.Panel1.TabIndex = 4
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(113, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(229, 20)
        Me.lblEncabezado.TabIndex = 8
        Me.lblEncabezado.Text = "Solicitudes de Gratificación"
        '
        'gpbFiltroIncentivos
        '
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblMaximo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.chkVerHorasCheco)
        Me.gpbFiltroIncentivos.Controls.Add(Me.GroupBox1)
        Me.gpbFiltroIncentivos.Controls.Add(Me.dttDia)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbConcepto)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Label4)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Label3)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbCelula)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Label1)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbPuesto)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblPuesto)
        Me.gpbFiltroIncentivos.Controls.Add(Me.chkSeleccionarTodo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cboxPeriodo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblPeriodo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbNave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Label2)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbDepartamento)
        Me.gpbFiltroIncentivos.Controls.Add(Me.txtDepartamento)
        Me.gpbFiltroIncentivos.Controls.Add(Me.txtBuscarNombreIncentivo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblNombreEmpleado)
        Me.gpbFiltroIncentivos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltroIncentivos.Location = New System.Drawing.Point(0, 59)
        Me.gpbFiltroIncentivos.Name = "gpbFiltroIncentivos"
        Me.gpbFiltroIncentivos.Size = New System.Drawing.Size(1239, 149)
        Me.gpbFiltroIncentivos.TabIndex = 11
        Me.gpbFiltroIncentivos.TabStop = False
        '
        'lblMaximo
        '
        Me.lblMaximo.AutoSize = True
        Me.lblMaximo.ForeColor = System.Drawing.Color.Black
        Me.lblMaximo.Location = New System.Drawing.Point(815, 127)
        Me.lblMaximo.Name = "lblMaximo"
        Me.lblMaximo.Size = New System.Drawing.Size(22, 13)
        Me.lblMaximo.TabIndex = 60
        Me.lblMaximo.Text = "0.0"
        '
        'chkVerHorasCheco
        '
        Me.chkVerHorasCheco.AutoSize = True
        Me.chkVerHorasCheco.Location = New System.Drawing.Point(309, 127)
        Me.chkVerHorasCheco.Name = "chkVerHorasCheco"
        Me.chkVerHorasCheco.Size = New System.Drawing.Size(107, 17)
        Me.chkVerHorasCheco.TabIndex = 59
        Me.chkVerHorasCheco.Text = "Ver Horas Checo"
        Me.chkVerHorasCheco.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoSoloIncremento)
        Me.GroupBox1.Controls.Add(Me.txtIncremento)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.rdoMedioDia)
        Me.GroupBox1.Controls.Add(Me.rdoDiaCompleto)
        Me.GroupBox1.Location = New System.Drawing.Point(888, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 75)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        '
        'rdoSoloIncremento
        '
        Me.rdoSoloIncremento.AutoSize = True
        Me.rdoSoloIncremento.Location = New System.Drawing.Point(15, 34)
        Me.rdoSoloIncremento.Name = "rdoSoloIncremento"
        Me.rdoSoloIncremento.Size = New System.Drawing.Size(76, 17)
        Me.rdoSoloIncremento.TabIndex = 4
        Me.rdoSoloIncremento.Text = "Porcentaje"
        Me.rdoSoloIncremento.UseVisualStyleBackColor = True
        '
        'txtIncremento
        '
        Me.txtIncremento.Location = New System.Drawing.Point(121, 51)
        Me.txtIncremento.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.txtIncremento.Name = "txtIncremento"
        Me.txtIncremento.Size = New System.Drawing.Size(52, 20)
        Me.txtIncremento.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(180, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(15, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Incremento por día"
        '
        'rdoMedioDia
        '
        Me.rdoMedioDia.AutoSize = True
        Me.rdoMedioDia.Location = New System.Drawing.Point(121, 11)
        Me.rdoMedioDia.Name = "rdoMedioDia"
        Me.rdoMedioDia.Size = New System.Drawing.Size(73, 17)
        Me.rdoMedioDia.TabIndex = 1
        Me.rdoMedioDia.Text = "Medio día"
        Me.rdoMedioDia.UseVisualStyleBackColor = True
        '
        'rdoDiaCompleto
        '
        Me.rdoDiaCompleto.AutoSize = True
        Me.rdoDiaCompleto.Checked = True
        Me.rdoDiaCompleto.Location = New System.Drawing.Point(15, 11)
        Me.rdoDiaCompleto.Name = "rdoDiaCompleto"
        Me.rdoDiaCompleto.Size = New System.Drawing.Size(90, 17)
        Me.rdoDiaCompleto.TabIndex = 0
        Me.rdoDiaCompleto.TabStop = True
        Me.rdoDiaCompleto.Text = "Día Completo"
        Me.rdoDiaCompleto.UseVisualStyleBackColor = True
        '
        'dttDia
        '
        Me.dttDia.Location = New System.Drawing.Point(888, 46)
        Me.dttDia.Name = "dttDia"
        Me.dttDia.Size = New System.Drawing.Size(200, 20)
        Me.dttDia.TabIndex = 57
        '
        'cmbConcepto
        '
        Me.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConcepto.ForeColor = System.Drawing.Color.Black
        Me.cmbConcepto.FormattingEnabled = True
        Me.cmbConcepto.Location = New System.Drawing.Point(515, 121)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(294, 21)
        Me.cmbConcepto.TabIndex = 56
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(832, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(441, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Concepto"
        '
        'cmbCelula
        '
        Me.cmbCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCelula.ForeColor = System.Drawing.Color.Black
        Me.cmbCelula.FormattingEnabled = True
        Me.cmbCelula.Location = New System.Drawing.Point(515, 94)
        Me.cmbCelula.Name = "cmbCelula"
        Me.cmbCelula.Size = New System.Drawing.Size(294, 21)
        Me.cmbCelula.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(441, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Celula"
        '
        'cmbPuesto
        '
        Me.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuesto.ForeColor = System.Drawing.Color.Black
        Me.cmbPuesto.FormattingEnabled = True
        Me.cmbPuesto.Location = New System.Drawing.Point(515, 68)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(294, 21)
        Me.cmbPuesto.TabIndex = 52
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.ForeColor = System.Drawing.Color.Black
        Me.lblPuesto.Location = New System.Drawing.Point(441, 72)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(40, 13)
        Me.lblPuesto.TabIndex = 51
        Me.lblPuesto.Text = "Puesto"
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(6, 127)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(115, 17)
        Me.chkSeleccionarTodo.TabIndex = 50
        Me.chkSeleccionarTodo.Text = "Seleccionar Todos"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'cboxPeriodo
        '
        Me.cboxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPeriodo.ForeColor = System.Drawing.Color.Black
        Me.cboxPeriodo.FormattingEnabled = True
        Me.cboxPeriodo.Location = New System.Drawing.Point(96, 68)
        Me.cboxPeriodo.Name = "cboxPeriodo"
        Me.cboxPeriodo.Size = New System.Drawing.Size(320, 21)
        Me.cboxPeriodo.TabIndex = 49
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.ForeColor = System.Drawing.Color.Black
        Me.lblPeriodo.Location = New System.Drawing.Point(27, 72)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(50, 13)
        Me.lblPeriodo.TabIndex = 48
        Me.lblPeriodo.Text = "* Periodo"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnFiltrarSolicitud)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnSubir)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBajar)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1136, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(100, 130)
        Me.pnlMinimizarParametros.TabIndex = 47
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(6, 63)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 46
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(57, 63)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 45
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(61, 30)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 44
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(11, 30)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 43
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'btnSubir
        '
        Me.btnSubir.Image = Global.Nomina.Vista.My.Resources.Resources._1373584033_navigate_up1
        Me.btnSubir.Location = New System.Drawing.Point(41, 0)
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(20, 20)
        Me.btnSubir.TabIndex = 41
        Me.btnSubir.UseVisualStyleBackColor = True
        '
        'btnBajar
        '
        Me.btnBajar.Image = CType(resources.GetObject("btnBajar.Image"), System.Drawing.Image)
        Me.btnBajar.Location = New System.Drawing.Point(73, 0)
        Me.btnBajar.Name = "btnBajar"
        Me.btnBajar.Size = New System.Drawing.Size(20, 20)
        Me.btnBajar.TabIndex = 42
        Me.btnBajar.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(96, 42)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(320, 21)
        Me.cmbNave.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(27, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "* Nave"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.ForeColor = System.Drawing.Color.Black
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(515, 42)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(294, 21)
        Me.cmbDepartamento.TabIndex = 17
        '
        'txtDepartamento
        '
        Me.txtDepartamento.AutoSize = True
        Me.txtDepartamento.ForeColor = System.Drawing.Color.Black
        Me.txtDepartamento.Location = New System.Drawing.Point(441, 46)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.txtDepartamento.TabIndex = 15
        Me.txtDepartamento.Text = "Departamento"
        '
        'txtBuscarNombreIncentivo
        '
        Me.txtBuscarNombreIncentivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarNombreIncentivo.ForeColor = System.Drawing.Color.Black
        Me.txtBuscarNombreIncentivo.Location = New System.Drawing.Point(96, 95)
        Me.txtBuscarNombreIncentivo.Name = "txtBuscarNombreIncentivo"
        Me.txtBuscarNombreIncentivo.Size = New System.Drawing.Size(320, 20)
        Me.txtBuscarNombreIncentivo.TabIndex = 1
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.AutoSize = True
        Me.lblNombreEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(27, 99)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(64, 13)
        Me.lblNombreEmpleado.TabIndex = 0
        Me.lblNombreEmpleado.Text = "Colaborador"
        '
        'pnColores
        '
        Me.pnColores.BackColor = System.Drawing.Color.White
        Me.pnColores.Controls.Add(Me.pnlAutorizar)
        Me.pnColores.Controls.Add(Me.Panel4)
        Me.pnColores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnColores.Location = New System.Drawing.Point(0, 547)
        Me.pnColores.Name = "pnColores"
        Me.pnColores.Size = New System.Drawing.Size(1239, 60)
        Me.pnColores.TabIndex = 13
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnGuardar)
        Me.pnlAutorizar.Controls.Add(Me.lblGuardar)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAutorizar.Location = New System.Drawing.Point(1130, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(57, 60)
        Me.pnlAutorizar.TabIndex = 35
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(11, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(3, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(48, 13)
        Me.lblGuardar.TabIndex = 3
        Me.lblGuardar.Text = "Autorizar"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblCerrar)
        Me.Panel4.Controls.Add(Me.btnCerrar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1187, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(52, 60)
        Me.Panel4.TabIndex = 34
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(9, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 6
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(10, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'grdColaboradores
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColaboradores.DisplayLayout.Appearance = Appearance1
        Me.grdColaboradores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColaboradores.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdColaboradores.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColaboradores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColaboradores.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdColaboradores.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColaboradores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColaboradores.Location = New System.Drawing.Point(0, 208)
        Me.grdColaboradores.Name = "grdColaboradores"
        Me.grdColaboradores.Size = New System.Drawing.Size(1239, 339)
        Me.grdColaboradores.TabIndex = 26
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(344, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'AltaDiaAdicionalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1239, 607)
        Me.Controls.Add(Me.grdColaboradores)
        Me.Controls.Add(Me.pnColores)
        Me.Controls.Add(Me.gpbFiltroIncentivos)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "AltaDiaAdicionalForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guardar"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpbFiltroIncentivos.ResumeLayout(False)
        Me.gpbFiltroIncentivos.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtIncremento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.pnColores.ResumeLayout(False)
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents gpbFiltroIncentivos As System.Windows.Forms.GroupBox
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents cboxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents btnSubir As System.Windows.Forms.Button
    Friend WithEvents btnBajar As System.Windows.Forms.Button
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNombreIncentivo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
    Friend WithEvents pnColores As System.Windows.Forms.Panel
    Friend WithEvents pnlAutorizar As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents grdColaboradores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dttDia As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCelula As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPuesto As System.Windows.Forms.ComboBox
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdoMedioDia As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDiaCompleto As System.Windows.Forms.RadioButton
    Friend WithEvents txtIncremento As System.Windows.Forms.NumericUpDown
    Private WithEvents chkVerHorasCheco As System.Windows.Forms.CheckBox
    Friend WithEvents lblMaximo As System.Windows.Forms.Label
    Friend WithEvents rdoSoloIncremento As System.Windows.Forms.RadioButton
    Friend WithEvents pcbTitulo As PictureBox
End Class
