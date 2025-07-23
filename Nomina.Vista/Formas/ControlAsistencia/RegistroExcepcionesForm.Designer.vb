<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistroExcepcionesForm
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistroExcepcionesForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPagado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.gridControlExcepciones = New System.Windows.Forms.DataGridView()
        Me.clmExcepcionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmHorarioID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmColaboradorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNombreColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDepartamentoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDepartamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFechaTermino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.regHoraInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmHoraTermino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIDSolicito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmUsuarioSolicito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFechaSolicitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIDReviso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmUsuarioReviso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmFechaRevision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPyA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmCdA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmTipoExcepcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMotivoExcepcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEstadoExcepcionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEstadoExcepcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gboxParametros = New System.Windows.Forms.GroupBox()
        Me.pnlMaximizarTabla = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cboxPeriodo = New System.Windows.Forms.ComboBox()
        Me.cboxColaborador = New System.Windows.Forms.ComboBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.cboxDepartamento = New System.Windows.Forms.ComboBox()
        Me.cboxNave = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
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
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlAreaTrabajo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        CType(Me.gridControlExcepciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxParametros.SuspendLayout()
        Me.pnlMaximizarTabla.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1241, 60)
        Me.pnlHeader.TabIndex = 5
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnNuevo)
        Me.pnlAcciones.Controls.Add(Me.lblNuevo)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(170, 60)
        Me.pnlAcciones.TabIndex = 17
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnNuevo.Image = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnNuevo.Location = New System.Drawing.Point(12, 6)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevo.TabIndex = 15
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(13, 41)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(30, 13)
        Me.lblNuevo.TabIndex = 16
        Me.lblNuevo.Text = "Altas"
        Me.lblNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(805, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(436, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(160, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(201, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Permisos y Excepciones"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 531)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1241, 60)
        Me.pnlPie.TabIndex = 6
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(980, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(261, 60)
        Me.pnlOperaciones.TabIndex = 23
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.Label12)
        Me.pnlEstado.Controls.Add(Me.Label13)
        Me.pnlEstado.Controls.Add(Me.Label10)
        Me.pnlEstado.Controls.Add(Me.Label11)
        Me.pnlEstado.Controls.Add(Me.Label8)
        Me.pnlEstado.Controls.Add(Me.Label9)
        Me.pnlEstado.Controls.Add(Me.Label4)
        Me.pnlEstado.Controls.Add(Me.Label7)
        Me.pnlEstado.Controls.Add(Me.Label1)
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Controls.Add(Me.Label5)
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.lblPagado)
        Me.pnlEstado.Controls.Add(Me.Label2)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(663, 60)
        Me.pnlEstado.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(602, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "No gana"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Salmon
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.ForeColor = System.Drawing.Color.Salmon
        Me.Label13.Location = New System.Drawing.Point(581, 37)
        Me.Label13.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label13.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 15)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "___"
        Me.Label13.Visible = False
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(532, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Si gana"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Green
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.ForeColor = System.Drawing.Color.Green
        Me.Label11.Location = New System.Drawing.Point(511, 37)
        Me.Label11.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label11.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 15)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "___"
        Me.Label11.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(363, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Correcto"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.AliceBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.ForeColor = System.Drawing.Color.AliceBlue
        Me.Label9.Location = New System.Drawing.Point(342, 37)
        Me.Label9.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label9.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "___"
        Me.Label9.Visible = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(279, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Anticipado"
        Me.Label4.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label7.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.Label7.Location = New System.Drawing.Point(258, 37)
        Me.Label7.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label7.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "___"
        Me.Label7.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(197, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Pendiente"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LightBlue
        Me.Label3.ForeColor = System.Drawing.Color.LightBlue
        Me.Label3.Location = New System.Drawing.Point(176, 37)
        Me.Label3.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label3.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "___"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(113, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Denegado"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Salmon
        Me.Label6.ForeColor = System.Drawing.Color.Salmon
        Me.Label6.Location = New System.Drawing.Point(92, 37)
        Me.Label6.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label6.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "___"
        '
        'lblPagado
        '
        Me.lblPagado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPagado.AutoSize = True
        Me.lblPagado.Location = New System.Drawing.Point(33, 37)
        Me.lblPagado.Name = "lblPagado"
        Me.lblPagado.Size = New System.Drawing.Size(53, 13)
        Me.lblPagado.TabIndex = 1
        Me.lblPagado.Text = "Aprobado"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightGreen
        Me.Label2.ForeColor = System.Drawing.Color.LightGreen
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label2.MinimumSize = New System.Drawing.Size(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "___"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AllowDrop = True
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(46, 43)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 20
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AllowDrop = True
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(43, 76)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 21
        Me.lblLimpiar.Text = "Limpiar"
        '
        'gridControlExcepciones
        '
        Me.gridControlExcepciones.AllowUserToAddRows = False
        Me.gridControlExcepciones.AllowUserToDeleteRows = False
        Me.gridControlExcepciones.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Thistle
        Me.gridControlExcepciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridControlExcepciones.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.gridControlExcepciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridControlExcepciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridControlExcepciones.ColumnHeadersHeight = 35
        Me.gridControlExcepciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmExcepcionID, Me.clmHorarioID, Me.clmColaboradorID, Me.clmNombreColaborador, Me.clmDepartamentoID, Me.clmDepartamento, Me.clmFechaInicio, Me.clmFechaTermino, Me.regHoraInicio, Me.clmHoraTermino, Me.clmIDSolicito, Me.clmUsuarioSolicito, Me.clmFechaSolicitud, Me.clmIDReviso, Me.clmUsuarioReviso, Me.clmFechaRevision, Me.clmNota, Me.clmPyA, Me.clmCdA, Me.clmTipoExcepcion, Me.clmMotivoExcepcion, Me.clmEstadoExcepcionID, Me.clmEstadoExcepcion})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridControlExcepciones.DefaultCellStyle = DataGridViewCellStyle18
        Me.gridControlExcepciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridControlExcepciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridControlExcepciones.GridColor = System.Drawing.Color.SteelBlue
        Me.gridControlExcepciones.Location = New System.Drawing.Point(0, 181)
        Me.gridControlExcepciones.Name = "gridControlExcepciones"
        Me.gridControlExcepciones.RowHeadersVisible = False
        Me.gridControlExcepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridControlExcepciones.Size = New System.Drawing.Size(1241, 350)
        Me.gridControlExcepciones.TabIndex = 3
        '
        'clmExcepcionID
        '
        Me.clmExcepcionID.HeaderText = "clmExcepcionID"
        Me.clmExcepcionID.Name = "clmExcepcionID"
        Me.clmExcepcionID.ReadOnly = True
        Me.clmExcepcionID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmExcepcionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmExcepcionID.Visible = False
        '
        'clmHorarioID
        '
        Me.clmHorarioID.HeaderText = "HorarioID"
        Me.clmHorarioID.Name = "clmHorarioID"
        Me.clmHorarioID.ReadOnly = True
        Me.clmHorarioID.Visible = False
        '
        'clmColaboradorID
        '
        Me.clmColaboradorID.HeaderText = "ColaboradorID"
        Me.clmColaboradorID.Name = "clmColaboradorID"
        Me.clmColaboradorID.ReadOnly = True
        Me.clmColaboradorID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmColaboradorID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmColaboradorID.Visible = False
        '
        'clmNombreColaborador
        '
        Me.clmNombreColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmNombreColaborador.DefaultCellStyle = DataGridViewCellStyle3
        Me.clmNombreColaborador.HeaderText = "Colaborador"
        Me.clmNombreColaborador.MinimumWidth = 200
        Me.clmNombreColaborador.Name = "clmNombreColaborador"
        Me.clmNombreColaborador.ReadOnly = True
        Me.clmNombreColaborador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmDepartamentoID
        '
        Me.clmDepartamentoID.HeaderText = "DepartamentoID"
        Me.clmDepartamentoID.Name = "clmDepartamentoID"
        Me.clmDepartamentoID.ReadOnly = True
        Me.clmDepartamentoID.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmDepartamentoID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmDepartamentoID.Visible = False
        '
        'clmDepartamento
        '
        Me.clmDepartamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmDepartamento.DefaultCellStyle = DataGridViewCellStyle4
        Me.clmDepartamento.HeaderText = "Departamento"
        Me.clmDepartamento.Name = "clmDepartamento"
        Me.clmDepartamento.ReadOnly = True
        Me.clmDepartamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmDepartamento.Width = 80
        '
        'clmFechaInicio
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmFechaInicio.DefaultCellStyle = DataGridViewCellStyle5
        Me.clmFechaInicio.HeaderText = "Fecha Inicio"
        Me.clmFechaInicio.Name = "clmFechaInicio"
        Me.clmFechaInicio.ReadOnly = True
        Me.clmFechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmFechaInicio.Width = 80
        '
        'clmFechaTermino
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmFechaTermino.DefaultCellStyle = DataGridViewCellStyle6
        Me.clmFechaTermino.HeaderText = "Fecha Término"
        Me.clmFechaTermino.Name = "clmFechaTermino"
        Me.clmFechaTermino.ReadOnly = True
        Me.clmFechaTermino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmFechaTermino.Width = 80
        '
        'regHoraInicio
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.regHoraInicio.DefaultCellStyle = DataGridViewCellStyle7
        Me.regHoraInicio.HeaderText = "Hr Inicio"
        Me.regHoraInicio.Name = "regHoraInicio"
        Me.regHoraInicio.ReadOnly = True
        Me.regHoraInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.regHoraInicio.Width = 80
        '
        'clmHoraTermino
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmHoraTermino.DefaultCellStyle = DataGridViewCellStyle8
        Me.clmHoraTermino.HeaderText = "Hr Término"
        Me.clmHoraTermino.Name = "clmHoraTermino"
        Me.clmHoraTermino.ReadOnly = True
        Me.clmHoraTermino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmHoraTermino.Width = 80
        '
        'clmIDSolicito
        '
        Me.clmIDSolicito.HeaderText = "IDSolicito"
        Me.clmIDSolicito.Name = "clmIDSolicito"
        Me.clmIDSolicito.ReadOnly = True
        Me.clmIDSolicito.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmIDSolicito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmIDSolicito.Visible = False
        '
        'clmUsuarioSolicito
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmUsuarioSolicito.DefaultCellStyle = DataGridViewCellStyle9
        Me.clmUsuarioSolicito.HeaderText = "Solicitó"
        Me.clmUsuarioSolicito.Name = "clmUsuarioSolicito"
        Me.clmUsuarioSolicito.ReadOnly = True
        Me.clmUsuarioSolicito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmUsuarioSolicito.Width = 80
        '
        'clmFechaSolicitud
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmFechaSolicitud.DefaultCellStyle = DataGridViewCellStyle10
        Me.clmFechaSolicitud.HeaderText = "Fecha Solicitud"
        Me.clmFechaSolicitud.Name = "clmFechaSolicitud"
        Me.clmFechaSolicitud.ReadOnly = True
        Me.clmFechaSolicitud.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmFechaSolicitud.Width = 80
        '
        'clmIDReviso
        '
        Me.clmIDReviso.HeaderText = "IDReviso"
        Me.clmIDReviso.Name = "clmIDReviso"
        Me.clmIDReviso.ReadOnly = True
        Me.clmIDReviso.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmIDReviso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmIDReviso.Visible = False
        '
        'clmUsuarioReviso
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmUsuarioReviso.DefaultCellStyle = DataGridViewCellStyle11
        Me.clmUsuarioReviso.HeaderText = "Revisó"
        Me.clmUsuarioReviso.Name = "clmUsuarioReviso"
        Me.clmUsuarioReviso.ReadOnly = True
        Me.clmUsuarioReviso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmUsuarioReviso.Width = 80
        '
        'clmFechaRevision
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmFechaRevision.DefaultCellStyle = DataGridViewCellStyle12
        Me.clmFechaRevision.HeaderText = "Revisión"
        Me.clmFechaRevision.Name = "clmFechaRevision"
        Me.clmFechaRevision.ReadOnly = True
        Me.clmFechaRevision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmNota
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmNota.DefaultCellStyle = DataGridViewCellStyle13
        Me.clmNota.HeaderText = "Nota"
        Me.clmNota.Name = "clmNota"
        Me.clmNota.ReadOnly = True
        Me.clmNota.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmPyA
        '
        Me.clmPyA.HeaderText = "PyA"
        Me.clmPyA.Name = "clmPyA"
        Me.clmPyA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmPyA.ToolTipText = "Puntualidad y asistencia"
        Me.clmPyA.Width = 30
        '
        'clmCdA
        '
        Me.clmCdA.HeaderText = "CdA"
        Me.clmCdA.Name = "clmCdA"
        Me.clmCdA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmCdA.ToolTipText = "Caja de ahorro"
        Me.clmCdA.Width = 30
        '
        'clmTipoExcepcion
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmTipoExcepcion.DefaultCellStyle = DataGridViewCellStyle14
        Me.clmTipoExcepcion.HeaderText = "Tipo Excepción"
        Me.clmTipoExcepcion.Name = "clmTipoExcepcion"
        Me.clmTipoExcepcion.ReadOnly = True
        Me.clmTipoExcepcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmTipoExcepcion.Width = 80
        '
        'clmMotivoExcepcion
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmMotivoExcepcion.DefaultCellStyle = DataGridViewCellStyle15
        Me.clmMotivoExcepcion.HeaderText = "Motivo Excepción"
        Me.clmMotivoExcepcion.Name = "clmMotivoExcepcion"
        Me.clmMotivoExcepcion.ReadOnly = True
        Me.clmMotivoExcepcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmMotivoExcepcion.Width = 80
        '
        'clmEstadoExcepcionID
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmEstadoExcepcionID.DefaultCellStyle = DataGridViewCellStyle16
        Me.clmEstadoExcepcionID.HeaderText = "EstadoExcepcionID"
        Me.clmEstadoExcepcionID.Name = "clmEstadoExcepcionID"
        Me.clmEstadoExcepcionID.ReadOnly = True
        Me.clmEstadoExcepcionID.Visible = False
        Me.clmEstadoExcepcionID.Width = 60
        '
        'clmEstadoExcepcion
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmEstadoExcepcion.DefaultCellStyle = DataGridViewCellStyle17
        Me.clmEstadoExcepcion.HeaderText = "Estado Excepción"
        Me.clmEstadoExcepcion.Name = "clmEstadoExcepcion"
        Me.clmEstadoExcepcion.ReadOnly = True
        Me.clmEstadoExcepcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmEstadoExcepcion.Width = 80
        '
        'gboxParametros
        '
        Me.gboxParametros.Controls.Add(Me.pnlMaximizarTabla)
        Me.gboxParametros.Controls.Add(Me.cboxPeriodo)
        Me.gboxParametros.Controls.Add(Me.cboxColaborador)
        Me.gboxParametros.Controls.Add(Me.lblPeriodo)
        Me.gboxParametros.Controls.Add(Me.lblColaborador)
        Me.gboxParametros.Controls.Add(Me.cboxDepartamento)
        Me.gboxParametros.Controls.Add(Me.cboxNave)
        Me.gboxParametros.Controls.Add(Me.lblDepartamento)
        Me.gboxParametros.Controls.Add(Me.lblNave)
        Me.gboxParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxParametros.Location = New System.Drawing.Point(0, 60)
        Me.gboxParametros.Name = "gboxParametros"
        Me.gboxParametros.Size = New System.Drawing.Size(1241, 121)
        Me.gboxParametros.TabIndex = 0
        Me.gboxParametros.TabStop = False
        '
        'pnlMaximizarTabla
        '
        Me.pnlMaximizarTabla.Controls.Add(Me.btnLimpiar)
        Me.pnlMaximizarTabla.Controls.Add(Me.lblAceptar)
        Me.pnlMaximizarTabla.Controls.Add(Me.lblLimpiar)
        Me.pnlMaximizarTabla.Controls.Add(Me.btnAbajo)
        Me.pnlMaximizarTabla.Controls.Add(Me.btnArriba)
        Me.pnlMaximizarTabla.Controls.Add(Me.btnAceptar)
        Me.pnlMaximizarTabla.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMaximizarTabla.Location = New System.Drawing.Point(1151, 16)
        Me.pnlMaximizarTabla.Name = "pnlMaximizarTabla"
        Me.pnlMaximizarTabla.Size = New System.Drawing.Size(87, 102)
        Me.pnlMaximizarTabla.TabIndex = 31
        '
        'lblAceptar
        '
        Me.lblAceptar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.Location = New System.Drawing.Point(3, 76)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 22
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(57, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 44
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(33, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 43
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnAceptar.Location = New System.Drawing.Point(8, 43)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 21
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'cboxPeriodo
        '
        Me.cboxPeriodo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPeriodo.FormattingEnabled = True
        Me.cboxPeriodo.Location = New System.Drawing.Point(157, 85)
        Me.cboxPeriodo.Name = "cboxPeriodo"
        Me.cboxPeriodo.Size = New System.Drawing.Size(320, 21)
        Me.cboxPeriodo.TabIndex = 26
        '
        'cboxColaborador
        '
        Me.cboxColaborador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboxColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxColaborador.FormattingEnabled = True
        Me.cboxColaborador.Location = New System.Drawing.Point(679, 85)
        Me.cboxColaborador.Name = "cboxColaborador"
        Me.cboxColaborador.Size = New System.Drawing.Size(269, 21)
        Me.cboxColaborador.TabIndex = 25
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(104, 89)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(43, 13)
        Me.lblPeriodo.TabIndex = 24
        Me.lblPeriodo.Text = "Periodo"
        '
        'lblColaborador
        '
        Me.lblColaborador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(595, 89)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(64, 13)
        Me.lblColaborador.TabIndex = 23
        Me.lblColaborador.Text = "Colaborador"
        '
        'cboxDepartamento
        '
        Me.cboxDepartamento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxDepartamento.FormattingEnabled = True
        Me.cboxDepartamento.Location = New System.Drawing.Point(679, 55)
        Me.cboxDepartamento.Name = "cboxDepartamento"
        Me.cboxDepartamento.Size = New System.Drawing.Size(269, 21)
        Me.cboxDepartamento.TabIndex = 20
        '
        'cboxNave
        '
        Me.cboxNave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboxNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNave.FormattingEnabled = True
        Me.cboxNave.Location = New System.Drawing.Point(157, 55)
        Me.cboxNave.Name = "cboxNave"
        Me.cboxNave.Size = New System.Drawing.Size(320, 21)
        Me.cboxNave.TabIndex = 12
        '
        'lblDepartamento
        '
        Me.lblDepartamento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(595, 59)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.lblDepartamento.TabIndex = 1
        Me.lblDepartamento.Text = "Departamento"
        '
        'lblNave
        '
        Me.lblNave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(104, 59)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Nave"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "clmExcepcionID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha inicio"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha termino"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Hora inicio"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Hora termino"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "IDSolicito"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Solicito"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fecha solicitud"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "IDReviso"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Reviso"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Revision"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Nota"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Tipo excepcion"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Motivo excepcion"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Estado excepcion"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "ColaboradorID"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Colaborador"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "DepartamentoID"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Departamento"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "EstadoExcepcionID"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Estado excepcion"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'pnlAreaTrabajo
        '
        Me.pnlAreaTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAreaTrabajo.Location = New System.Drawing.Point(0, 60)
        Me.pnlAreaTrabajo.Name = "pnlAreaTrabajo"
        Me.pnlAreaTrabajo.Size = New System.Drawing.Size(1241, 471)
        Me.pnlAreaTrabajo.TabIndex = 7
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(368, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 26
        Me.pcbTitulo.TabStop = False
        '
        'RegistroExcepcionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 591)
        Me.Controls.Add(Me.gridControlExcepciones)
        Me.Controls.Add(Me.gboxParametros)
        Me.Controls.Add(Me.pnlAreaTrabajo)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlPie)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimumSize = New System.Drawing.Size(936, 613)
        Me.Name = "RegistroExcepcionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permisos y Excepciones"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        CType(Me.gridControlExcepciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxParametros.ResumeLayout(False)
        Me.gboxParametros.PerformLayout()
        Me.pnlMaximizarTabla.ResumeLayout(False)
        Me.pnlMaximizarTabla.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPagado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents gridControlExcepciones As System.Windows.Forms.DataGridView
    Friend WithEvents gboxParametros As System.Windows.Forms.GroupBox
    Friend WithEvents cboxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents cboxColaborador As System.Windows.Forms.ComboBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents cboxDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents cboxNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents pnlMaximizarTabla As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
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
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents pnlAreaTrabajo As System.Windows.Forms.Panel
    Friend WithEvents clmExcepcionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHorarioID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmColaboradorID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNombreColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDepartamentoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDepartamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFechaInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFechaTermino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents regHoraInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHoraTermino As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIDSolicito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUsuarioSolicito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFechaSolicitud As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIDReviso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUsuarioReviso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFechaRevision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmPyA As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmCdA As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmTipoExcepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMotivoExcepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmEstadoExcepcionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmEstadoExcepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
