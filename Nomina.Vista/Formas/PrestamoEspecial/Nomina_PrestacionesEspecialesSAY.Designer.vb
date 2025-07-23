<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nomina_PrestacionesEspecialesSAY
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Nomina_PrestacionesEspecialesSAY))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlestado = New System.Windows.Forms.Panel()
        Me.lblJustificacion = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.txtTotalColaboradores = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMontoEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbConcepto = New System.Windows.Forms.ComboBox()
        Me.txtPrecioMultiple = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCargarImporteMultiple = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSemanas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPorcentajeEmpresa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.lblCalcular = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.txtColaborador = New System.Windows.Forms.TextBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.txtPagoTotal = New System.Windows.Forms.TextBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblconcepto = New System.Windows.Forms.Label()
        Me.lblarea = New System.Windows.Forms.Label()
        Me.lblcolaborador = New System.Windows.Forms.Label()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.grdPrestaciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlestado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        CType(Me.txtPrecioMultiple, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.grdPrestaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlestado
        '
        Me.pnlestado.BackColor = System.Drawing.Color.White
        Me.pnlestado.Controls.Add(Me.lblJustificacion)
        Me.pnlestado.Controls.Add(Me.Label7)
        Me.pnlestado.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlestado.Controls.Add(Me.pnlAcciones)
        Me.pnlestado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlestado.Location = New System.Drawing.Point(0, 500)
        Me.pnlestado.Name = "pnlestado"
        Me.pnlestado.Size = New System.Drawing.Size(815, 60)
        Me.pnlestado.TabIndex = 55
        '
        'lblJustificacion
        '
        Me.lblJustificacion.AutoSize = True
        Me.lblJustificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJustificacion.ForeColor = System.Drawing.Color.Black
        Me.lblJustificacion.Location = New System.Drawing.Point(278, 21)
        Me.lblJustificacion.Name = "lblJustificacion"
        Me.lblJustificacion.Size = New System.Drawing.Size(231, 15)
        Me.lblJustificacion.TabIndex = 71
        Me.lblJustificacion.Text = "* Seleccionar las prestaciones a guardar "
        Me.lblJustificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 32)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "Artículos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.AutoSize = True
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(51, 39)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalSeleccionados.TabIndex = 69
        Me.lblTotalSeleccionados.Text = "0"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(692, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(123, 60)
        Me.pnlAcciones.TabIndex = 17
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(76, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 60
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
        Me.btnCncelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCncelar.Location = New System.Drawing.Point(77, 5)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 59
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(22, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(17, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 3
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(815, 67)
        Me.pnlHeader.TabIndex = 56
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(373, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(442, 67)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(202, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(150, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Alta Prestaciones"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.chboxSeleccionarTodo)
        Me.grbParametros.Controls.Add(Me.txtTotalColaboradores)
        Me.grbParametros.Controls.Add(Me.Label11)
        Me.grbParametros.Controls.Add(Me.txtMontoEmpresa)
        Me.grbParametros.Controls.Add(Me.Label10)
        Me.grbParametros.Controls.Add(Me.Label8)
        Me.grbParametros.Controls.Add(Me.cmbConcepto)
        Me.grbParametros.Controls.Add(Me.txtPrecioMultiple)
        Me.grbParametros.Controls.Add(Me.Label9)
        Me.grbParametros.Controls.Add(Me.btnCargarImporteMultiple)
        Me.grbParametros.Controls.Add(Me.Label6)
        Me.grbParametros.Controls.Add(Me.Label5)
        Me.grbParametros.Controls.Add(Me.txtSemanas)
        Me.grbParametros.Controls.Add(Me.Label4)
        Me.grbParametros.Controls.Add(Me.Label3)
        Me.grbParametros.Controls.Add(Me.txtPorcentajeEmpresa)
        Me.grbParametros.Controls.Add(Me.Label2)
        Me.grbParametros.Controls.Add(Me.lblMonto)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.txtColaborador)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.txtPagoTotal)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.cmbDepartamento)
        Me.grbParametros.Controls.Add(Me.Label1)
        Me.grbParametros.Controls.Add(Me.lblconcepto)
        Me.grbParametros.Controls.Add(Me.lblarea)
        Me.grbParametros.Controls.Add(Me.lblcolaborador)
        Me.grbParametros.Controls.Add(Me.cmbArea)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grbParametros.Location = New System.Drawing.Point(0, 67)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(815, 252)
        Me.grbParametros.TabIndex = 57
        Me.grbParametros.TabStop = False
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(12, 212)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 130
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'txtTotalColaboradores
        '
        Me.txtTotalColaboradores.Location = New System.Drawing.Point(461, 116)
        Me.txtTotalColaboradores.Name = "txtTotalColaboradores"
        Me.txtTotalColaboradores.Size = New System.Drawing.Size(83, 20)
        Me.txtTotalColaboradores.TabIndex = 74
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(439, 148)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 18)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "$"
        '
        'txtMontoEmpresa
        '
        Me.txtMontoEmpresa.Location = New System.Drawing.Point(461, 147)
        Me.txtMontoEmpresa.Name = "txtMontoEmpresa"
        Me.txtMontoEmpresa.Size = New System.Drawing.Size(83, 20)
        Me.txtMontoEmpresa.TabIndex = 72
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(326, 147)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 19)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Monto Empresa"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(439, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 18)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "$"
        '
        'cmbConcepto
        '
        Me.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConcepto.ForeColor = System.Drawing.Color.Black
        Me.cmbConcepto.FormattingEnabled = True
        Me.cmbConcepto.Location = New System.Drawing.Point(461, 32)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(169, 21)
        Me.cmbConcepto.TabIndex = 69
        '
        'txtPrecioMultiple
        '
        Me.txtPrecioMultiple.DecimalPlaces = 2
        Me.txtPrecioMultiple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioMultiple.Location = New System.Drawing.Point(684, 212)
        Me.txtPrecioMultiple.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtPrecioMultiple.Name = "txtPrecioMultiple"
        Me.txtPrecioMultiple.Size = New System.Drawing.Size(85, 20)
        Me.txtPrecioMultiple.TabIndex = 68
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(642, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 13)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Actualizar precios de la selección"
        '
        'btnCargarImporteMultiple
        '
        Me.btnCargarImporteMultiple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargarImporteMultiple.Image = Global.Nomina.Vista.My.Resources.Resources.prestamos_32
        Me.btnCargarImporteMultiple.Location = New System.Drawing.Point(771, 206)
        Me.btnCargarImporteMultiple.Name = "btnCargarImporteMultiple"
        Me.btnCargarImporteMultiple.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarImporteMultiple.TabIndex = 66
        Me.btnCargarImporteMultiple.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(642, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 18)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Importe"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(326, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 22)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Monto Colaboradores"
        '
        'txtSemanas
        '
        Me.txtSemanas.Location = New System.Drawing.Point(461, 175)
        Me.txtSemanas.Name = "txtSemanas"
        Me.txtSemanas.Size = New System.Drawing.Size(83, 20)
        Me.txtSemanas.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(326, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 18)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Semanas"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(556, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 18)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "%"
        '
        'txtPorcentajeEmpresa
        '
        Me.txtPorcentajeEmpresa.Location = New System.Drawing.Point(461, 89)
        Me.txtPorcentajeEmpresa.Name = "txtPorcentajeEmpresa"
        Me.txtPorcentajeEmpresa.Size = New System.Drawing.Size(83, 20)
        Me.txtPorcentajeEmpresa.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(326, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 19)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Porcentaje Empresa"
        '
        'lblMonto
        '
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMonto.Location = New System.Drawing.Point(326, 61)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(75, 18)
        Me.lblMonto.TabIndex = 55
        Me.lblMonto.Text = "Pago Total"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnCalcular)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblCalcular)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(671, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(141, 143)
        Me.pnlMinimizarParametros.TabIndex = 54
        '
        'btnCalcular
        '
        Me.btnCalcular.Image = Global.Nomina.Vista.My.Resources.Resources.calculo_32
        Me.btnCalcular.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCalcular.Location = New System.Drawing.Point(14, 88)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(32, 32)
        Me.btnCalcular.TabIndex = 73
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'lblCalcular
        '
        Me.lblCalcular.AutoSize = True
        Me.lblCalcular.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCalcular.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCalcular.Location = New System.Drawing.Point(10, 123)
        Me.lblCalcular.Name = "lblCalcular"
        Me.lblCalcular.Size = New System.Drawing.Size(45, 13)
        Me.lblCalcular.TabIndex = 74
        Me.lblCalcular.Text = "Calcular"
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnArriba.Location = New System.Drawing.Point(85, 4)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbajo.Location = New System.Drawing.Point(107, 4)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(75, 30)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 59
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscar.Location = New System.Drawing.Point(15, 30)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 36
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBuscar.Location = New System.Drawing.Point(12, 62)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 37
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(74, 62)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 58
        Me.lblLimpiar.Text = "Limpiar"
        '
        'txtColaborador
        '
        Me.txtColaborador.ForeColor = System.Drawing.Color.Black
        Me.txtColaborador.Location = New System.Drawing.Point(109, 110)
        Me.txtColaborador.Name = "txtColaborador"
        Me.txtColaborador.Size = New System.Drawing.Size(201, 20)
        Me.txtColaborador.TabIndex = 42
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(109, 35)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(201, 21)
        Me.cmbNave.TabIndex = 14
        '
        'txtPagoTotal
        '
        Me.txtPagoTotal.ForeColor = System.Drawing.Color.Black
        Me.txtPagoTotal.Location = New System.Drawing.Point(461, 61)
        Me.txtPagoTotal.Name = "txtPagoTotal"
        Me.txtPagoTotal.Size = New System.Drawing.Size(169, 20)
        Me.txtPagoTotal.TabIndex = 43
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNave.Location = New System.Drawing.Point(22, 84)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(74, 13)
        Me.lblNave.TabIndex = 17
        Me.lblNave.Text = "Departamento"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.ForeColor = System.Drawing.Color.Black
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Items.AddRange(New Object() {""})
        Me.cmbDepartamento.Location = New System.Drawing.Point(109, 84)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(201, 21)
        Me.cmbDepartamento.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(22, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Nave"
        '
        'lblconcepto
        '
        Me.lblconcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblconcepto.ForeColor = System.Drawing.Color.Black
        Me.lblconcepto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblconcepto.Location = New System.Drawing.Point(326, 35)
        Me.lblconcepto.Name = "lblconcepto"
        Me.lblconcepto.Size = New System.Drawing.Size(57, 22)
        Me.lblconcepto.TabIndex = 46
        Me.lblconcepto.Text = "Concepto"
        '
        'lblarea
        '
        Me.lblarea.AutoSize = True
        Me.lblarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblarea.ForeColor = System.Drawing.Color.Black
        Me.lblarea.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblarea.Location = New System.Drawing.Point(22, 59)
        Me.lblarea.Name = "lblarea"
        Me.lblarea.Size = New System.Drawing.Size(29, 13)
        Me.lblarea.TabIndex = 20
        Me.lblarea.Text = "Área"
        '
        'lblcolaborador
        '
        Me.lblcolaborador.AutoSize = True
        Me.lblcolaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblcolaborador.ForeColor = System.Drawing.Color.Black
        Me.lblcolaborador.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblcolaborador.Location = New System.Drawing.Point(22, 113)
        Me.lblcolaborador.Name = "lblcolaborador"
        Me.lblcolaborador.Size = New System.Drawing.Size(64, 13)
        Me.lblcolaborador.TabIndex = 21
        Me.lblcolaborador.Text = "Colaborador"
        '
        'cmbArea
        '
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.ForeColor = System.Drawing.Color.Black
        Me.cmbArea.FormattingEnabled = True
        Me.cmbArea.Items.AddRange(New Object() {""})
        Me.cmbArea.Location = New System.Drawing.Point(109, 59)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(201, 21)
        Me.cmbArea.TabIndex = 23
        '
        'grdPrestaciones
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPrestaciones.DisplayLayout.Appearance = Appearance1
        Me.grdPrestaciones.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows
        Me.grdPrestaciones.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinGroup
        Me.grdPrestaciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPrestaciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdPrestaciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPrestaciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPrestaciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPrestaciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPrestaciones.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPrestaciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPrestaciones.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree
        Me.grdPrestaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPrestaciones.Location = New System.Drawing.Point(0, 319)
        Me.grdPrestaciones.Name = "grdPrestaciones"
        Me.grdPrestaciones.Size = New System.Drawing.Size(815, 181)
        Me.grdPrestaciones.TabIndex = 58
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(374, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 67)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 25
        Me.pcbTitulo.TabStop = False
        '
        'Nomina_PrestacionesEspecialesSAY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 560)
        Me.Controls.Add(Me.grdPrestaciones)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlestado)
        Me.Name = "Nomina_PrestacionesEspecialesSAY"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Prestaciones"
        Me.pnlestado.ResumeLayout(False)
        Me.pnlestado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        CType(Me.txtPrecioMultiple, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        CType(Me.grdPrestaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlestado As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnCncelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents grbParametros As GroupBox
    Friend WithEvents pnlMinimizarParametros As Panel
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblBuscar As Label
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents txtColaborador As TextBox
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents txtPagoTotal As TextBox
    Friend WithEvents lblNave As Label
    Friend WithEvents cmbDepartamento As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblconcepto As Label
    Friend WithEvents lblarea As Label
    Friend WithEvents lblcolaborador As Label
    Friend WithEvents cmbArea As ComboBox
    Friend WithEvents lblMonto As Label
    Friend WithEvents txtSemanas As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPorcentajeEmpresa As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCalcular As Button
    Friend WithEvents lblCalcular As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents grdPrestaciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtPrecioMultiple As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCargarImporteMultiple As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTotalSeleccionados As Label
    Friend WithEvents cmbConcepto As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotalColaboradores As TextBox
    Friend WithEvents txtMontoEmpresa As TextBox
    Friend WithEvents chboxSeleccionarTodo As CheckBox
    Friend WithEvents lblJustificacion As Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
