<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CobranzaPrestamosForm
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CobranzaPrestamosForm))
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblcobrar2 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.btncobrar = New System.Windows.Forms.Button()
        Me.lblcobrar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblcobrado = New System.Windows.Forms.Label()
        Me.grdPrestamos = New System.Windows.Forms.DataGridView()
        Me.clmidPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNumPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCondonar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNumeroDePago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMontototal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmsaldoanterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clminteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmabonocapital = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmtotalabono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmsaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmLiquidacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmInteres2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCobrado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAbonoExtraordinario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.naveid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEstatusSemanaPrestamos = New System.Windows.Forms.Label()
        Me.lblEditarCobro = New System.Windows.Forms.Label()
        Me.btnEditarCobro = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.EstatusSemanaNomina = New System.Windows.Forms.Label()
        Me.lblsemananomina = New System.Windows.Forms.Label()
        Me.lblsemananomina2 = New System.Windows.Forms.Label()
        Me.lblfechamodificacion = New System.Windows.Forms.Label()
        Me.lblIdSemanaNomina = New System.Windows.Forms.Label()
        Me.lblfechainicio = New System.Windows.Forms.Label()
        Me.lblfechafin = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.lblestatus = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblConceptoNomina = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Controls.Add(Me.Label1)
        Me.pnlEstado.Controls.Add(Me.Label2)
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Controls.Add(Me.Label4)
        Me.pnlEstado.Controls.Add(Me.lblcobrado)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 469)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1241, 60)
        Me.pnlEstado.TabIndex = 13
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblcobrar2)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Controls.Add(Me.btncobrar)
        Me.pnlAcciones.Controls.Add(Me.lblcobrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(1066, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(175, 60)
        Me.pnlAcciones.TabIndex = 16
        '
        'lblcobrar2
        '
        Me.lblcobrar2.AutoSize = True
        Me.lblcobrar2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblcobrar2.Location = New System.Drawing.Point(60, 44)
        Me.lblcobrar2.Name = "lblcobrar2"
        Me.lblcobrar2.Size = New System.Drawing.Size(46, 13)
        Me.lblcobrar2.TabIndex = 61
        Me.lblcobrar2.Text = "Semana"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(122, 33)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 60
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(122, 2)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 59
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'btncobrar
        '
        Me.btncobrar.Image = Global.Nomina.Vista.My.Resources.Resources.candado
        Me.btncobrar.Location = New System.Drawing.Point(65, 2)
        Me.btncobrar.Name = "btncobrar"
        Me.btncobrar.Size = New System.Drawing.Size(32, 32)
        Me.btncobrar.TabIndex = 5
        Me.btncobrar.UseVisualStyleBackColor = True
        '
        'lblcobrar
        '
        Me.lblcobrar.AutoSize = True
        Me.lblcobrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblcobrar.Location = New System.Drawing.Point(64, 33)
        Me.lblcobrar.Name = "lblcobrar"
        Me.lblcobrar.Size = New System.Drawing.Size(35, 13)
        Me.lblcobrar.TabIndex = 6
        Me.lblcobrar.Text = "Cerrar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(306, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "El abono total es menor a los intereses"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightSalmon
        Me.Label2.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label2.Location = New System.Drawing.Point(290, 37)
        Me.Label2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "___"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.LightGreen
        Me.Label6.ForeColor = System.Drawing.Color.LightGreen
        Me.Label6.Location = New System.Drawing.Point(16, 37)
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
        Me.Label3.Location = New System.Drawing.Point(114, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "El abono total sobrepasa el saldo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Salmon
        Me.Label4.ForeColor = System.Drawing.Color.Salmon
        Me.Label4.Location = New System.Drawing.Point(98, 37)
        Me.Label4.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "___"
        '
        'lblcobrado
        '
        Me.lblcobrado.AutoSize = True
        Me.lblcobrado.ForeColor = System.Drawing.Color.Black
        Me.lblcobrado.Location = New System.Drawing.Point(35, 37)
        Me.lblcobrado.Name = "lblcobrado"
        Me.lblcobrado.Size = New System.Drawing.Size(47, 13)
        Me.lblcobrado.TabIndex = 1
        Me.lblcobrado.Text = "Cobrado"
        '
        'grdPrestamos
        '
        Me.grdPrestamos.AllowUserToAddRows = False
        Me.grdPrestamos.AllowUserToDeleteRows = False
        Me.grdPrestamos.AllowUserToResizeColumns = False
        Me.grdPrestamos.AllowUserToResizeRows = False
        Me.grdPrestamos.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPrestamos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPrestamos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmidPrestamo, Me.clmNumPago, Me.clmCondonar, Me.clmNum, Me.clmNumeroDePago, Me.clmColaborador, Me.clmMontototal, Me.clmsaldoanterior, Me.clminteres, Me.clmabonocapital, Me.clmtotalabono, Me.clmsaldo, Me.clmLiquidacion, Me.clmInteres2, Me.clmCobrado, Me.clmFechaModificacion, Me.clmAbonoExtraordinario, Me.naveid})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.NullValue = Nothing
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdPrestamos.DefaultCellStyle = DataGridViewCellStyle12
        Me.grdPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPrestamos.GridColor = System.Drawing.SystemColors.ControlText
        Me.grdPrestamos.Location = New System.Drawing.Point(0, 170)
        Me.grdPrestamos.Name = "grdPrestamos"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPrestamos.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.grdPrestamos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdPrestamos.Size = New System.Drawing.Size(1241, 299)
        Me.grdPrestamos.TabIndex = 12
        '
        'clmidPrestamo
        '
        Me.clmidPrestamo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.clmidPrestamo.HeaderText = "idPrestamo"
        Me.clmidPrestamo.Name = "clmidPrestamo"
        Me.clmidPrestamo.ReadOnly = True
        Me.clmidPrestamo.Visible = False
        '
        'clmNumPago
        '
        Me.clmNumPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmNumPago.HeaderText = "clmNumPago"
        Me.clmNumPago.Name = "clmNumPago"
        Me.clmNumPago.Visible = False
        '
        'clmCondonar
        '
        Me.clmCondonar.HeaderText = "Condonar"
        Me.clmCondonar.Name = "clmCondonar"
        Me.clmCondonar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmCondonar.Width = 65
        '
        'clmNum
        '
        Me.clmNum.HeaderText = "#"
        Me.clmNum.Name = "clmNum"
        Me.clmNum.ReadOnly = True
        Me.clmNum.Width = 21
        '
        'clmNumeroDePago
        '
        Me.clmNumeroDePago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.clmNumeroDePago.DefaultCellStyle = DataGridViewCellStyle2
        Me.clmNumeroDePago.HeaderText = "Num. de Pago"
        Me.clmNumeroDePago.Name = "clmNumeroDePago"
        Me.clmNumeroDePago.ReadOnly = True
        Me.clmNumeroDePago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmColaborador
        '
        Me.clmColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.NullValue = Nothing
        Me.clmColaborador.DefaultCellStyle = DataGridViewCellStyle3
        Me.clmColaborador.HeaderText = "Colaborador"
        Me.clmColaborador.Name = "clmColaborador"
        Me.clmColaborador.ReadOnly = True
        '
        'clmMontototal
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.clmMontototal.DefaultCellStyle = DataGridViewCellStyle4
        Me.clmMontototal.HeaderText = "Monto Total"
        Me.clmMontototal.Name = "clmMontototal"
        Me.clmMontototal.ReadOnly = True
        Me.clmMontototal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmMontototal.Width = 80
        '
        'clmsaldoanterior
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.clmsaldoanterior.DefaultCellStyle = DataGridViewCellStyle5
        Me.clmsaldoanterior.HeaderText = "Saldo Anterior"
        Me.clmsaldoanterior.Name = "clmsaldoanterior"
        Me.clmsaldoanterior.ReadOnly = True
        Me.clmsaldoanterior.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmsaldoanterior.Width = 80
        '
        'clminteres
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.clminteres.DefaultCellStyle = DataGridViewCellStyle6
        Me.clminteres.HeaderText = "Interés"
        Me.clminteres.MaxInputLength = 5
        Me.clminteres.Name = "clminteres"
        Me.clminteres.ReadOnly = True
        Me.clminteres.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clminteres.Width = 50
        '
        'clmabonocapital
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.clmabonocapital.DefaultCellStyle = DataGridViewCellStyle7
        Me.clmabonocapital.HeaderText = "Abono Capital"
        Me.clmabonocapital.Name = "clmabonocapital"
        Me.clmabonocapital.ReadOnly = True
        Me.clmabonocapital.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmabonocapital.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmabonocapital.Width = 80
        '
        'clmtotalabono
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.clmtotalabono.DefaultCellStyle = DataGridViewCellStyle8
        Me.clmtotalabono.HeaderText = "Total Abono"
        Me.clmtotalabono.Name = "clmtotalabono"
        Me.clmtotalabono.ReadOnly = True
        Me.clmtotalabono.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmtotalabono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmtotalabono.Width = 80
        '
        'clmsaldo
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.clmsaldo.DefaultCellStyle = DataGridViewCellStyle9
        Me.clmsaldo.HeaderText = "Saldo"
        Me.clmsaldo.Name = "clmsaldo"
        Me.clmsaldo.ReadOnly = True
        Me.clmsaldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmsaldo.Width = 50
        '
        'clmLiquidacion
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.clmLiquidacion.DefaultCellStyle = DataGridViewCellStyle10
        Me.clmLiquidacion.HeaderText = "Saldo Total"
        Me.clmLiquidacion.Name = "clmLiquidacion"
        Me.clmLiquidacion.ReadOnly = True
        Me.clmLiquidacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmLiquidacion.Width = 80
        '
        'clmInteres2
        '
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.clmInteres2.DefaultCellStyle = DataGridViewCellStyle11
        Me.clmInteres2.HeaderText = "Interes2"
        Me.clmInteres2.Name = "clmInteres2"
        Me.clmInteres2.Visible = False
        Me.clmInteres2.Width = 80
        '
        'clmCobrado
        '
        Me.clmCobrado.HeaderText = "clmCobrado"
        Me.clmCobrado.Name = "clmCobrado"
        Me.clmCobrado.Visible = False
        '
        'clmFechaModificacion
        '
        Me.clmFechaModificacion.HeaderText = "clmFechaModificacion"
        Me.clmFechaModificacion.Name = "clmFechaModificacion"
        Me.clmFechaModificacion.Visible = False
        '
        'clmAbonoExtraordinario
        '
        Me.clmAbonoExtraordinario.HeaderText = "Abono Extraordinario"
        Me.clmAbonoExtraordinario.Name = "clmAbonoExtraordinario"
        Me.clmAbonoExtraordinario.ReadOnly = True
        Me.clmAbonoExtraordinario.Visible = False
        '
        'naveid
        '
        Me.naveid.HeaderText = "naveid"
        Me.naveid.Name = "naveid"
        Me.naveid.Visible = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblEstatusSemanaPrestamos)
        Me.pnlHeader.Controls.Add(Me.lblEditarCobro)
        Me.pnlHeader.Controls.Add(Me.btnEditarCobro)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.EstatusSemanaNomina)
        Me.pnlHeader.Controls.Add(Me.lblsemananomina)
        Me.pnlHeader.Controls.Add(Me.lblsemananomina2)
        Me.pnlHeader.Controls.Add(Me.lblfechamodificacion)
        Me.pnlHeader.Controls.Add(Me.lblIdSemanaNomina)
        Me.pnlHeader.Controls.Add(Me.lblfechainicio)
        Me.pnlHeader.Controls.Add(Me.lblfechafin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1241, 59)
        Me.pnlHeader.TabIndex = 11
        '
        'lblEstatusSemanaPrestamos
        '
        Me.lblEstatusSemanaPrestamos.AutoSize = True
        Me.lblEstatusSemanaPrestamos.Location = New System.Drawing.Point(435, 24)
        Me.lblEstatusSemanaPrestamos.Name = "lblEstatusSemanaPrestamos"
        Me.lblEstatusSemanaPrestamos.Size = New System.Drawing.Size(130, 13)
        Me.lblEstatusSemanaPrestamos.TabIndex = 53
        Me.lblEstatusSemanaPrestamos.Text = "EstatusSemanaPrestamos"
        '
        'lblEditarCobro
        '
        Me.lblEditarCobro.AutoSize = True
        Me.lblEditarCobro.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditarCobro.Location = New System.Drawing.Point(9, 42)
        Me.lblEditarCobro.Name = "lblEditarCobro"
        Me.lblEditarCobro.Size = New System.Drawing.Size(63, 13)
        Me.lblEditarCobro.TabIndex = 8
        Me.lblEditarCobro.Text = "Editar cierre"
        '
        'btnEditarCobro
        '
        Me.btnEditarCobro.Image = Global.Nomina.Vista.My.Resources.Resources.editar_321
        Me.btnEditarCobro.Location = New System.Drawing.Point(24, 7)
        Me.btnEditarCobro.Name = "btnEditarCobro"
        Me.btnEditarCobro.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarCobro.TabIndex = 7
        Me.btnEditarCobro.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(851, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(390, 59)
        Me.pnlTitulo.TabIndex = 4
        '
        'pbYuyin
        '
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(322, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 56)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 25
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(72, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(247, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Cierre Semanal de Préstamos"
        '
        'EstatusSemanaNomina
        '
        Me.EstatusSemanaNomina.AutoSize = True
        Me.EstatusSemanaNomina.Location = New System.Drawing.Point(82, 7)
        Me.EstatusSemanaNomina.Name = "EstatusSemanaNomina"
        Me.EstatusSemanaNomina.Size = New System.Drawing.Size(117, 13)
        Me.EstatusSemanaNomina.TabIndex = 24
        Me.EstatusSemanaNomina.Text = "EstatusSemanaNomina"
        '
        'lblsemananomina
        '
        Me.lblsemananomina.AutoSize = True
        Me.lblsemananomina.Location = New System.Drawing.Point(205, 7)
        Me.lblsemananomina.Name = "lblsemananomina"
        Me.lblsemananomina.Size = New System.Drawing.Size(83, 13)
        Me.lblsemananomina.TabIndex = 18
        Me.lblsemananomina.Text = "Semana nomina"
        '
        'lblsemananomina2
        '
        Me.lblsemananomina2.AutoSize = True
        Me.lblsemananomina2.Location = New System.Drawing.Point(82, 24)
        Me.lblsemananomina2.Name = "lblsemananomina2"
        Me.lblsemananomina2.Size = New System.Drawing.Size(94, 13)
        Me.lblsemananomina2.TabIndex = 19
        Me.lblsemananomina2.Text = "lblsemananomina2"
        '
        'lblfechamodificacion
        '
        Me.lblfechamodificacion.AutoSize = True
        Me.lblfechamodificacion.Location = New System.Drawing.Point(205, 26)
        Me.lblfechamodificacion.Name = "lblfechamodificacion"
        Me.lblfechamodificacion.Size = New System.Drawing.Size(122, 13)
        Me.lblfechamodificacion.TabIndex = 23
        Me.lblfechamodificacion.Text = "FECHA MODIFICAICON"
        '
        'lblIdSemanaNomina
        '
        Me.lblIdSemanaNomina.AutoSize = True
        Me.lblIdSemanaNomina.Location = New System.Drawing.Point(333, 26)
        Me.lblIdSemanaNomina.Name = "lblIdSemanaNomina"
        Me.lblIdSemanaNomina.Size = New System.Drawing.Size(90, 13)
        Me.lblIdSemanaNomina.TabIndex = 20
        Me.lblIdSemanaNomina.Text = "idSemanaNomina"
        '
        'lblfechainicio
        '
        Me.lblfechainicio.AutoSize = True
        Me.lblfechainicio.Location = New System.Drawing.Point(333, 7)
        Me.lblfechainicio.Name = "lblfechainicio"
        Me.lblfechainicio.Size = New System.Drawing.Size(77, 13)
        Me.lblfechainicio.TabIndex = 21
        Me.lblfechainicio.Text = "FECHA INICIO"
        '
        'lblfechafin
        '
        Me.lblfechafin.AutoSize = True
        Me.lblfechafin.Location = New System.Drawing.Point(432, 7)
        Me.lblfechafin.Name = "lblfechafin"
        Me.lblfechafin.Size = New System.Drawing.Size(62, 13)
        Me.lblfechafin.TabIndex = 22
        Me.lblfechafin.Text = "FECHA FIN"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Items.AddRange(New Object() {"", "POR COBRAR", "COBRADOS"})
        Me.cmbEstatus.Location = New System.Drawing.Point(713, 49)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(214, 21)
        Me.cmbEstatus.TabIndex = 23
        '
        'lblestatus
        '
        Me.lblestatus.AutoSize = True
        Me.lblestatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblestatus.ForeColor = System.Drawing.Color.Black
        Me.lblestatus.Location = New System.Drawing.Point(665, 52)
        Me.lblestatus.Name = "lblestatus"
        Me.lblestatus.Size = New System.Drawing.Size(42, 13)
        Me.lblestatus.TabIndex = 22
        Me.lblestatus.Text = "Estatus"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(232, 52)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 17
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(338, 49)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(300, 21)
        Me.cmbNave.TabIndex = 14
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.Transparent
        Me.grbParametros.Controls.Add(Me.Label5)
        Me.grbParametros.Controls.Add(Me.lblConceptoNomina)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.cmbEstatus)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.lblestatus)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 59)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1241, 111)
        Me.grbParametros.TabIndex = 53
        Me.grbParametros.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(232, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Periodo de Nómina"
        '
        'lblConceptoNomina
        '
        Me.lblConceptoNomina.AutoSize = True
        Me.lblConceptoNomina.Location = New System.Drawing.Point(338, 80)
        Me.lblConceptoNomina.Name = "lblConceptoNomina"
        Me.lblConceptoNomina.Size = New System.Drawing.Size(10, 13)
        Me.lblConceptoNomina.TabIndex = 53
        Me.lblConceptoNomina.Text = "-"
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
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1066, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(172, 92)
        Me.pnlMinimizarParametros.TabIndex = 52
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(122, 44)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 55
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(120, 75)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 54
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(63, 44)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 53
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(61, 75)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 52
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(111, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(134, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "idPrestamo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "clmNumPago"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn3.HeaderText = "Numero de pago"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle15.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn4.HeaderText = "Colaborador"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle16.Format = "C2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn5.HeaderText = "Monto total"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle17.Format = "C2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn6.HeaderText = "Saldo anterior"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = "0"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn7.HeaderText = "Interes"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle19.Format = "C2"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridViewTextBoxColumn8.HeaderText = "Abono capital"
        Me.DataGridViewTextBoxColumn8.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 70
        '
        'DataGridViewTextBoxColumn9
        '
        DataGridViewCellStyle20.Format = "C2"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewTextBoxColumn9.HeaderText = "Total abono"
        Me.DataGridViewTextBoxColumn9.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.Width = 95
        '
        'DataGridViewTextBoxColumn10
        '
        DataGridViewCellStyle21.Format = "C2"
        DataGridViewCellStyle21.NullValue = Nothing
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn10.HeaderText = "Saldo"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        DataGridViewCellStyle22.Format = "C2"
        DataGridViewCellStyle22.NullValue = Nothing
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewTextBoxColumn11.HeaderText = "Liquida con:"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Width = 80
        '
        'DataGridViewTextBoxColumn12
        '
        DataGridViewCellStyle23.Format = "N2"
        DataGridViewCellStyle23.NullValue = Nothing
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle23
        Me.DataGridViewTextBoxColumn12.HeaderText = "Interes2"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn12.Visible = False
        Me.DataGridViewTextBoxColumn12.Width = 80
        '
        'DataGridViewTextBoxColumn13
        '
        DataGridViewCellStyle24.Format = "N2"
        DataGridViewCellStyle24.NullValue = Nothing
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle24
        Me.DataGridViewTextBoxColumn13.HeaderText = "clmCobrado"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 80
        '
        'DataGridViewTextBoxColumn14
        '
        DataGridViewCellStyle25.Format = "N2"
        DataGridViewCellStyle25.NullValue = Nothing
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle25
        Me.DataGridViewTextBoxColumn14.HeaderText = "clmFechaModificacion"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 80
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "clmFechaModificacion"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "clmFechaModificacion"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Abono Extraordinario"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(322, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 26
        Me.pcbTitulo.TabStop = False
        '
        'CobranzaPrestamosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 529)
        Me.Controls.Add(Me.grdPrestamos)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CobranzaPrestamosForm"
        Me.Text = "Cierre Semanal de Préstamos"
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblcobrado As System.Windows.Forms.Label
    Friend WithEvents grdPrestamos As System.Windows.Forms.DataGridView
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblcobrar As System.Windows.Forms.Label
    Friend WithEvents btncobrar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblIdSemanaNomina As System.Windows.Forms.Label
    Friend WithEvents lblsemananomina2 As System.Windows.Forms.Label
    Friend WithEvents lblsemananomina As System.Windows.Forms.Label
    Friend WithEvents lblfechafin As System.Windows.Forms.Label
    Friend WithEvents lblfechainicio As System.Windows.Forms.Label
    Friend WithEvents lblfechamodificacion As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblestatus As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstatusSemanaNomina As System.Windows.Forms.Label
    Friend WithEvents lblEditarCobro As System.Windows.Forms.Label
    Friend WithEvents btnEditarCobro As System.Windows.Forms.Button
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblEstatusSemanaPrestamos As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblConceptoNomina As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblcobrar2 As System.Windows.Forms.Label
    Friend WithEvents clmidPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNumPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmCondonar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNumeroDePago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMontototal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmsaldoanterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clminteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmabonocapital As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmtotalabono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmsaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmLiquidacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmInteres2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmCobrado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFechaModificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmAbonoExtraordinario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents naveid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
