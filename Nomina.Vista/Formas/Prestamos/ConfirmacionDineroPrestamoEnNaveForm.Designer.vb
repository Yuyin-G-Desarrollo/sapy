<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmacionDineroPrestamoEnNaveForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfirmacionDineroPrestamoEnNaveForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblenviar = New System.Windows.Forms.Label()
        Me.btnenviar = New System.Windows.Forms.Button()
        Me.grdPrestamos = New System.Windows.Forms.DataGridView()
        Me.idPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idsolicitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAbono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSemanas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTasaDeInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSinInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEnviar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.estatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlestado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPagado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.grdPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlestado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(698, 60)
        Me.pnlHeader.TabIndex = 7
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(179, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(519, 60)
        Me.pnlTitulo.TabIndex = 4
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(175, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(270, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Pago de préstamo a colaborador"
        '
        'lblenviar
        '
        Me.lblenviar.AutoSize = True
        Me.lblenviar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblenviar.Location = New System.Drawing.Point(22, 37)
        Me.lblenviar.Name = "lblenviar"
        Me.lblenviar.Size = New System.Drawing.Size(35, 13)
        Me.lblenviar.TabIndex = 6
        Me.lblenviar.Text = "Pagar"
        '
        'btnenviar
        '
        Me.btnenviar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnenviar.Location = New System.Drawing.Point(22, 2)
        Me.btnenviar.Name = "btnenviar"
        Me.btnenviar.Size = New System.Drawing.Size(32, 32)
        Me.btnenviar.TabIndex = 5
        Me.btnenviar.UseVisualStyleBackColor = True
        '
        'grdPrestamos
        '
        Me.grdPrestamos.AllowUserToAddRows = False
        Me.grdPrestamos.AllowUserToDeleteRows = False
        Me.grdPrestamos.AllowUserToOrderColumns = True
        Me.grdPrestamos.AllowUserToResizeColumns = False
        Me.grdPrestamos.AllowUserToResizeRows = False
        Me.grdPrestamos.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPrestamos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPrestamos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idPrestamo, Me.idsolicitud, Me.clmColaborador, Me.clmSaldo, Me.clmAbono, Me.clmSemanas, Me.clmTasaDeInteres, Me.clmSinInteres, Me.clmEnviar, Me.estatus, Me.idColaborador})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdPrestamos.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPrestamos.GridColor = System.Drawing.SystemColors.ControlText
        Me.grdPrestamos.Location = New System.Drawing.Point(0, 177)
        Me.grdPrestamos.Name = "grdPrestamos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPrestamos.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdPrestamos.Size = New System.Drawing.Size(698, 309)
        Me.grdPrestamos.TabIndex = 9
        '
        'idPrestamo
        '
        Me.idPrestamo.HeaderText = "idPrestamo"
        Me.idPrestamo.Name = "idPrestamo"
        Me.idPrestamo.Visible = False
        '
        'idsolicitud
        '
        Me.idsolicitud.HeaderText = "idsolicitud"
        Me.idsolicitud.Name = "idsolicitud"
        Me.idsolicitud.Visible = False
        '
        'clmColaborador
        '
        Me.clmColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmColaborador.HeaderText = "Colaborador"
        Me.clmColaborador.Name = "clmColaborador"
        Me.clmColaborador.ReadOnly = True
        '
        'clmSaldo
        '
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.clmSaldo.DefaultCellStyle = DataGridViewCellStyle2
        Me.clmSaldo.HeaderText = "Monto"
        Me.clmSaldo.Name = "clmSaldo"
        Me.clmSaldo.ReadOnly = True
        '
        'clmAbono
        '
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.clmAbono.DefaultCellStyle = DataGridViewCellStyle3
        Me.clmAbono.HeaderText = "Abono"
        Me.clmAbono.Name = "clmAbono"
        Me.clmAbono.ReadOnly = True
        '
        'clmSemanas
        '
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.clmSemanas.DefaultCellStyle = DataGridViewCellStyle4
        Me.clmSemanas.HeaderText = "Semanas"
        Me.clmSemanas.Name = "clmSemanas"
        Me.clmSemanas.ReadOnly = True
        '
        'clmTasaDeInteres
        '
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.clmTasaDeInteres.DefaultCellStyle = DataGridViewCellStyle5
        Me.clmTasaDeInteres.HeaderText = "Tasa de Interés"
        Me.clmTasaDeInteres.MaxInputLength = 5
        Me.clmTasaDeInteres.Name = "clmTasaDeInteres"
        Me.clmTasaDeInteres.ReadOnly = True
        Me.clmTasaDeInteres.Width = 80
        '
        'clmSinInteres
        '
        Me.clmSinInteres.HeaderText = "Tipo de Interés"
        Me.clmSinInteres.Name = "clmSinInteres"
        Me.clmSinInteres.ReadOnly = True
        Me.clmSinInteres.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmSinInteres.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmSinInteres.Width = 70
        '
        'clmEnviar
        '
        Me.clmEnviar.HeaderText = "Pagado"
        Me.clmEnviar.Name = "clmEnviar"
        Me.clmEnviar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clmEnviar.Width = 95
        '
        'estatus
        '
        Me.estatus.HeaderText = "clmestatus"
        Me.estatus.Name = "estatus"
        Me.estatus.Visible = False
        '
        'idColaborador
        '
        Me.idColaborador.HeaderText = "idColaborador"
        Me.idColaborador.Name = "idColaborador"
        Me.idColaborador.Visible = False
        '
        'pnlestado
        '
        Me.pnlestado.BackColor = System.Drawing.Color.White
        Me.pnlestado.Controls.Add(Me.pnlAcciones)
        Me.pnlestado.Controls.Add(Me.Label5)
        Me.pnlestado.Controls.Add(Me.Label6)
        Me.pnlestado.Controls.Add(Me.Label3)
        Me.pnlestado.Controls.Add(Me.Label4)
        Me.pnlestado.Controls.Add(Me.lblPagado)
        Me.pnlestado.Controls.Add(Me.Label2)
        Me.pnlestado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlestado.Location = New System.Drawing.Point(0, 486)
        Me.pnlestado.Name = "pnlestado"
        Me.pnlestado.Size = New System.Drawing.Size(698, 60)
        Me.pnlestado.TabIndex = 10
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Controls.Add(Me.lblenviar)
        Me.pnlAcciones.Controls.Add(Me.btnenviar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(581, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(117, 60)
        Me.pnlAcciones.TabIndex = 17
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(72, 37)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 58
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
        Me.btnCncelar.Location = New System.Drawing.Point(73, 2)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 57
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(342, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Solicitud de prestamo a finanzas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.LightGreen
        Me.Label6.ForeColor = System.Drawing.Color.LightGreen
        Me.Label6.Location = New System.Drawing.Point(327, 37)
        Me.Label6.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "___"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(185, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Dinero recibido en nave"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.LightYellow
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.ForeColor = System.Drawing.Color.LightYellow
        Me.Label4.Location = New System.Drawing.Point(167, 37)
        Me.Label4.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "___"
        '
        'lblPagado
        '
        Me.lblPagado.AutoSize = True
        Me.lblPagado.ForeColor = System.Drawing.Color.Black
        Me.lblPagado.Location = New System.Drawing.Point(34, 37)
        Me.lblPagado.Name = "lblPagado"
        Me.lblPagado.Size = New System.Drawing.Size(112, 13)
        Me.lblPagado.TabIndex = 1
        Me.lblPagado.Text = "Pagado a colaborador"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.ForeColor = System.Drawing.Color.LightGray
        Me.Label2.Location = New System.Drawing.Point(18, 37)
        Me.Label2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "___"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.Transparent
        Me.grbParametros.Controls.Add(Me.btnLimpiar)
        Me.grbParametros.Controls.Add(Me.lblLimpiar)
        Me.grbParametros.Controls.Add(Me.btnBuscar)
        Me.grbParametros.Controls.Add(Me.lblBuscar)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.Label1)
        Me.grbParametros.Controls.Add(Me.cmbEstatus)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(698, 117)
        Me.grbParametros.TabIndex = 11
        Me.grbParametros.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(444, 55)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 57
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(443, 89)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 56
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(397, 55)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 55
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(394, 89)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(645, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(50, 98)
        Me.pnlMinimizarParametros.TabIndex = 53
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(4, 5)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(27, 5)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Nave"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Items.AddRange(New Object() {"", "ENVIADOS", "PAGADOS", "RECIBIDOS"})
        Me.cmbEstatus.Location = New System.Drawing.Point(254, 55)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstatus.TabIndex = 22
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(203, 55)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(42, 13)
        Me.lblNave.TabIndex = 21
        Me.lblNave.Text = "Estatus"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Items.AddRange(New Object() {"", "Enviados", "Recibidos"})
        Me.cmbNave.Location = New System.Drawing.Point(61, 55)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(121, 21)
        Me.cmbNave.TabIndex = 20
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(451, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 25
        Me.pcbTitulo.TabStop = False
        '
        'ConfirmacionDineroPrestamoEnNaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(698, 546)
        Me.Controls.Add(Me.grdPrestamos)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlestado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ConfirmacionDineroPrestamoEnNaveForm"
        Me.Text = "Pago de préstamo a colaborador"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.grdPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlestado.ResumeLayout(False)
        Me.pnlestado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblenviar As System.Windows.Forms.Label
    Friend WithEvents btnenviar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grdPrestamos As System.Windows.Forms.DataGridView
    Friend WithEvents idPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idsolicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmAbono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSemanas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTasaDeInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSinInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmEnviar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents estatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlestado As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPagado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents pcbTitulo As PictureBox
End Class
