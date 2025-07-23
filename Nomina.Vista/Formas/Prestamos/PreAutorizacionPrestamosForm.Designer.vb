<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreAutorizacionPrestamosForm
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreAutorizacionPrestamosForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardarGerente = New System.Windows.Forms.Label()
        Me.lblPrestamosPorAutorizar2 = New System.Windows.Forms.Label()
        Me.lblPrestamosAprobados = New System.Windows.Forms.Label()
        Me.lblPrestamosAprobados2 = New System.Windows.Forms.Label()
        Me.lblPrestamosRechazados2 = New System.Windows.Forms.Label()
        Me.lblPrestamosPorAutorizar = New System.Windows.Forms.Label()
        Me.lblPrestamosRechazados = New System.Windows.Forms.Label()
        Me.grdAutorizacion = New System.Windows.Forms.DataGridView()
        Me.clmidPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAutorizar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmRechazar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAbono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSemanas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTasaDeInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTipoInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmestatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmidColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmjustificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdAutorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(1241, 59)
        Me.pnlHeader.TabIndex = 4
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(854, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(387, 59)
        Me.pnlTitulo.TabIndex = 4
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(40, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(256, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Pre Autorización de Préstamos"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.Transparent
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.cmbEstatus)
        Me.grbParametros.Controls.Add(Me.lblEstatus)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.Location = New System.Drawing.Point(0, 59)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1241, 110)
        Me.grbParametros.TabIndex = 14
        Me.grbParametros.TabStop = False
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1116, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(122, 91)
        Me.pnlMinimizarParametros.TabIndex = 43
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(76, 43)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 51
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(73, 75)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 50
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(21, 43)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 49
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(19, 76)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 48
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(65, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(88, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(71, 73)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(110, 69)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(261, 21)
        Me.cmbNave.TabIndex = 13
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Items.AddRange(New Object() {"", "POR AUTORIZAR", "AUTORIZADOS", "RECHAZADOS"})
        Me.cmbEstatus.Location = New System.Drawing.Point(446, 70)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(227, 21)
        Me.cmbEstatus.TabIndex = 12
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.Black
        Me.lblEstatus.Location = New System.Drawing.Point(398, 73)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(42, 13)
        Me.lblEstatus.TabIndex = 11
        Me.lblEstatus.Text = "Estatus"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Controls.Add(Me.lblPrestamosPorAutorizar2)
        Me.pnlEstado.Controls.Add(Me.lblPrestamosAprobados)
        Me.pnlEstado.Controls.Add(Me.lblPrestamosAprobados2)
        Me.pnlEstado.Controls.Add(Me.lblPrestamosRechazados2)
        Me.pnlEstado.Controls.Add(Me.lblPrestamosPorAutorizar)
        Me.pnlEstado.Controls.Add(Me.lblPrestamosRechazados)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 469)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1241, 60)
        Me.pnlEstado.TabIndex = 15
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardarGerente)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(1105, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(136, 60)
        Me.pnlAcciones.TabIndex = 15
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(84, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 58
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(87, 6)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 57
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(32, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardarGerente
        '
        Me.lblGuardarGerente.AutoSize = True
        Me.lblGuardarGerente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarGerente.Location = New System.Drawing.Point(31, 41)
        Me.lblGuardarGerente.Name = "lblGuardarGerente"
        Me.lblGuardarGerente.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarGerente.TabIndex = 3
        Me.lblGuardarGerente.Text = "Guardar"
        '
        'lblPrestamosPorAutorizar2
        '
        Me.lblPrestamosPorAutorizar2.AutoSize = True
        Me.lblPrestamosPorAutorizar2.BackColor = System.Drawing.Color.LightYellow
        Me.lblPrestamosPorAutorizar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrestamosPorAutorizar2.ForeColor = System.Drawing.Color.LightYellow
        Me.lblPrestamosPorAutorizar2.Location = New System.Drawing.Point(165, 37)
        Me.lblPrestamosPorAutorizar2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.lblPrestamosPorAutorizar2.Name = "lblPrestamosPorAutorizar2"
        Me.lblPrestamosPorAutorizar2.Size = New System.Drawing.Size(15, 15)
        Me.lblPrestamosPorAutorizar2.TabIndex = 13
        Me.lblPrestamosPorAutorizar2.Text = "___"
        '
        'lblPrestamosAprobados
        '
        Me.lblPrestamosAprobados.AutoSize = True
        Me.lblPrestamosAprobados.ForeColor = System.Drawing.Color.Black
        Me.lblPrestamosAprobados.Location = New System.Drawing.Point(30, 37)
        Me.lblPrestamosAprobados.Name = "lblPrestamosAprobados"
        Me.lblPrestamosAprobados.Size = New System.Drawing.Size(114, 13)
        Me.lblPrestamosAprobados.TabIndex = 12
        Me.lblPrestamosAprobados.Text = "Préstamos Autorizados"
        '
        'lblPrestamosAprobados2
        '
        Me.lblPrestamosAprobados2.AutoSize = True
        Me.lblPrestamosAprobados2.BackColor = System.Drawing.Color.LightGreen
        Me.lblPrestamosAprobados2.ForeColor = System.Drawing.Color.LightGreen
        Me.lblPrestamosAprobados2.Location = New System.Drawing.Point(17, 37)
        Me.lblPrestamosAprobados2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.lblPrestamosAprobados2.Name = "lblPrestamosAprobados2"
        Me.lblPrestamosAprobados2.Size = New System.Drawing.Size(13, 15)
        Me.lblPrestamosAprobados2.TabIndex = 11
        Me.lblPrestamosAprobados2.Text = "___"
        '
        'lblPrestamosRechazados2
        '
        Me.lblPrestamosRechazados2.AutoSize = True
        Me.lblPrestamosRechazados2.BackColor = System.Drawing.Color.Salmon
        Me.lblPrestamosRechazados2.ForeColor = System.Drawing.Color.Salmon
        Me.lblPrestamosRechazados2.Location = New System.Drawing.Point(323, 37)
        Me.lblPrestamosRechazados2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.lblPrestamosRechazados2.Name = "lblPrestamosRechazados2"
        Me.lblPrestamosRechazados2.Size = New System.Drawing.Size(13, 15)
        Me.lblPrestamosRechazados2.TabIndex = 0
        Me.lblPrestamosRechazados2.Text = "___"
        '
        'lblPrestamosPorAutorizar
        '
        Me.lblPrestamosPorAutorizar.AutoSize = True
        Me.lblPrestamosPorAutorizar.ForeColor = System.Drawing.Color.Black
        Me.lblPrestamosPorAutorizar.Location = New System.Drawing.Point(178, 37)
        Me.lblPrestamosPorAutorizar.Name = "lblPrestamosPorAutorizar"
        Me.lblPrestamosPorAutorizar.Size = New System.Drawing.Size(118, 13)
        Me.lblPrestamosPorAutorizar.TabIndex = 14
        Me.lblPrestamosPorAutorizar.Text = "Préstamos por Autorizar"
        '
        'lblPrestamosRechazados
        '
        Me.lblPrestamosRechazados.AutoSize = True
        Me.lblPrestamosRechazados.ForeColor = System.Drawing.Color.Black
        Me.lblPrestamosRechazados.Location = New System.Drawing.Point(335, 37)
        Me.lblPrestamosRechazados.Name = "lblPrestamosRechazados"
        Me.lblPrestamosRechazados.Size = New System.Drawing.Size(119, 13)
        Me.lblPrestamosRechazados.TabIndex = 1
        Me.lblPrestamosRechazados.Text = "Préstamos Rechazados"
        '
        'grdAutorizacion
        '
        Me.grdAutorizacion.AllowUserToAddRows = False
        Me.grdAutorizacion.AllowUserToDeleteRows = False
        Me.grdAutorizacion.AllowUserToOrderColumns = True
        Me.grdAutorizacion.AllowUserToResizeColumns = False
        Me.grdAutorizacion.AllowUserToResizeRows = False
        Me.grdAutorizacion.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdAutorizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.grdAutorizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAutorizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmidPrestamo, Me.clmAutorizar, Me.clmRechazar, Me.clmColaborador, Me.clmMonto, Me.clmAbono, Me.clmSemanas, Me.clmTasaDeInteres, Me.clmTipoInteres, Me.clmestatus, Me.clmidColaborador, Me.clmjustificacion})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.NullValue = Nothing
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdAutorizacion.DefaultCellStyle = DataGridViewCellStyle20
        Me.grdAutorizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAutorizacion.GridColor = System.Drawing.SystemColors.ControlText
        Me.grdAutorizacion.Location = New System.Drawing.Point(0, 169)
        Me.grdAutorizacion.Name = "grdAutorizacion"
        Me.grdAutorizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdAutorizacion.Size = New System.Drawing.Size(1241, 300)
        Me.grdAutorizacion.TabIndex = 16
        '
        'clmidPrestamo
        '
        Me.clmidPrestamo.HeaderText = "idPrestamo"
        Me.clmidPrestamo.Name = "clmidPrestamo"
        Me.clmidPrestamo.Visible = False
        '
        'clmAutorizar
        '
        Me.clmAutorizar.HeaderText = "A"
        Me.clmAutorizar.Name = "clmAutorizar"
        Me.clmAutorizar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clmAutorizar.ToolTipText = "Autorizar"
        Me.clmAutorizar.Width = 20
        '
        'clmRechazar
        '
        Me.clmRechazar.HeaderText = "R"
        Me.clmRechazar.Name = "clmRechazar"
        Me.clmRechazar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clmRechazar.ToolTipText = "Rechazar"
        Me.clmRechazar.Width = 20
        '
        'clmColaborador
        '
        Me.clmColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmColaborador.HeaderText = "Colaborador"
        Me.clmColaborador.Name = "clmColaborador"
        Me.clmColaborador.ReadOnly = True
        '
        'clmMonto
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.clmMonto.DefaultCellStyle = DataGridViewCellStyle12
        Me.clmMonto.HeaderText = "Monto Solicitado"
        Me.clmMonto.Name = "clmMonto"
        Me.clmMonto.ReadOnly = True
        '
        'clmAbono
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.clmAbono.DefaultCellStyle = DataGridViewCellStyle13
        Me.clmAbono.HeaderText = "Abono"
        Me.clmAbono.Name = "clmAbono"
        Me.clmAbono.ReadOnly = True
        '
        'clmSemanas
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.clmSemanas.DefaultCellStyle = DataGridViewCellStyle14
        Me.clmSemanas.HeaderText = "No. Semanas"
        Me.clmSemanas.Name = "clmSemanas"
        Me.clmSemanas.ReadOnly = True
        '
        'clmTasaDeInteres
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = "0"
        Me.clmTasaDeInteres.DefaultCellStyle = DataGridViewCellStyle15
        Me.clmTasaDeInteres.HeaderText = "Tasa de Interés"
        Me.clmTasaDeInteres.MaxInputLength = 5
        Me.clmTasaDeInteres.Name = "clmTasaDeInteres"
        Me.clmTasaDeInteres.ReadOnly = True
        Me.clmTasaDeInteres.Width = 110
        '
        'clmTipoInteres
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmTipoInteres.DefaultCellStyle = DataGridViewCellStyle16
        Me.clmTipoInteres.HeaderText = "Tipo de Interés"
        Me.clmTipoInteres.Name = "clmTipoInteres"
        Me.clmTipoInteres.ReadOnly = True
        Me.clmTipoInteres.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmTipoInteres.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmTipoInteres.Width = 200
        '
        'clmestatus
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmestatus.DefaultCellStyle = DataGridViewCellStyle17
        Me.clmestatus.HeaderText = "clmestatus"
        Me.clmestatus.Name = "clmestatus"
        Me.clmestatus.ReadOnly = True
        Me.clmestatus.Visible = False
        '
        'clmidColaborador
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clmidColaborador.DefaultCellStyle = DataGridViewCellStyle18
        Me.clmidColaborador.HeaderText = "idColaborador"
        Me.clmidColaborador.Name = "clmidColaborador"
        Me.clmidColaborador.ReadOnly = True
        Me.clmidColaborador.Visible = False
        '
        'clmjustificacion
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmjustificacion.DefaultCellStyle = DataGridViewCellStyle19
        Me.clmjustificacion.HeaderText = "justificacion"
        Me.clmjustificacion.Name = "clmjustificacion"
        Me.clmjustificacion.ReadOnly = True
        Me.clmjustificacion.Visible = False
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(319, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 25
        Me.pcbTitulo.TabStop = False
        '
        'PreAutorizacionPrestamosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 529)
        Me.Controls.Add(Me.grdAutorizacion)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "PreAutorizacionPrestamosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pre Autorización de Préstamos"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdAutorizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardarGerente As System.Windows.Forms.Label
    Friend WithEvents lblPrestamosPorAutorizar2 As System.Windows.Forms.Label
    Friend WithEvents lblPrestamosAprobados As System.Windows.Forms.Label
    Friend WithEvents lblPrestamosAprobados2 As System.Windows.Forms.Label
    Friend WithEvents lblPrestamosRechazados2 As System.Windows.Forms.Label
    Friend WithEvents lblPrestamosPorAutorizar As System.Windows.Forms.Label
    Friend WithEvents lblPrestamosRechazados As System.Windows.Forms.Label
    Friend WithEvents grdAutorizacion As System.Windows.Forms.DataGridView
    Friend WithEvents clmidPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmAutorizar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmRechazar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmAbono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSemanas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTasaDeInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTipoInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmestatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmidColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmjustificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
