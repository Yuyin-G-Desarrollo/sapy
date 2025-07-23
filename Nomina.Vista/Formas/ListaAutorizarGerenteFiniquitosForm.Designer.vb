<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaAutorizarGerenteFiniquitosForm
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaAutorizarGerenteFiniquitosForm))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblRechazar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grdFiltroSolicitudes = New System.Windows.Forms.DataGridView()
        Me.gpbFiltroIncentivos = New System.Windows.Forms.GroupBox()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.ChckActivarFecha = New System.Windows.Forms.CheckBox()
        Me.DtpSegundaFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.Fecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Status = New System.Windows.Forms.Label()
        Me.txtBuscarNombreIncentivo = New System.Windows.Forms.TextBox()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimirFichaDeRenunciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirCartaDeRenunciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirDetalleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirCartaUtilidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntxopciones = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarAnotacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdFiltroSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFiltroIncentivos.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.cntxopciones.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 475)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1241, 54)
        Me.Panel2.TabIndex = 25
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblCerrar)
        Me.Panel3.Controls.Add(Me.lblRechazar)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.btnCerrar)
        Me.Panel3.Controls.Add(Me.btnAutorizar)
        Me.Panel3.Controls.Add(Me.btnRechazar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1041, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 54)
        Me.Panel3.TabIndex = 18
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(152, 34)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 23
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblRechazar
        '
        Me.lblRechazar.AutoSize = True
        Me.lblRechazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazar.Location = New System.Drawing.Point(86, 34)
        Me.lblRechazar.Name = "lblRechazar"
        Me.lblRechazar.Size = New System.Drawing.Size(53, 13)
        Me.lblRechazar.TabIndex = 22
        Me.lblRechazar.Text = "Rechazar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(26, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Autorizar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(150, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 20
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAutorizar.Location = New System.Drawing.Point(32, 3)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(31, 32)
        Me.btnAutorizar.TabIndex = 14
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'btnRechazar
        '
        Me.btnRechazar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar32
        Me.btnRechazar.Location = New System.Drawing.Point(93, 3)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(31, 32)
        Me.btnRechazar.TabIndex = 16
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Location = New System.Drawing.Point(397, 32)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(15, 15)
        Me.Panel6.TabIndex = 6
        '
        'Panel5
        '
        Me.Panel5.Location = New System.Drawing.Point(209, 32)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(15, 15)
        Me.Panel5.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Location = New System.Drawing.Point(12, 32)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(15, 15)
        Me.Panel4.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Autorizado por Gerente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(222, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Autorizado por director"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(409, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Rechazado"
        '
        'grdFiltroSolicitudes
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdFiltroSolicitudes.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFiltroSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFiltroSolicitudes.EnableHeadersVisualStyles = False
        Me.grdFiltroSolicitudes.GridColor = System.Drawing.Color.DimGray
        Me.grdFiltroSolicitudes.Location = New System.Drawing.Point(0, 171)
        Me.grdFiltroSolicitudes.MultiSelect = False
        Me.grdFiltroSolicitudes.Name = "grdFiltroSolicitudes"
        Me.grdFiltroSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiltroSolicitudes.Size = New System.Drawing.Size(1241, 304)
        Me.grdFiltroSolicitudes.TabIndex = 24
        '
        'gpbFiltroIncentivos
        '
        Me.gpbFiltroIncentivos.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbNave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblNave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.ChckActivarFecha)
        Me.gpbFiltroIncentivos.Controls.Add(Me.DtpSegundaFecha)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblAl)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Fecha)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblFecha)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbStatus)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Status)
        Me.gpbFiltroIncentivos.Controls.Add(Me.txtBuscarNombreIncentivo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblNombreEmpleado)
        Me.gpbFiltroIncentivos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltroIncentivos.Location = New System.Drawing.Point(0, 59)
        Me.gpbFiltroIncentivos.Name = "gpbFiltroIncentivos"
        Me.gpbFiltroIncentivos.Size = New System.Drawing.Size(1241, 112)
        Me.gpbFiltroIncentivos.TabIndex = 23
        Me.gpbFiltroIncentivos.TabStop = False
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizarParametros.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnFiltrarSolicitud)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1093, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(145, 93)
        Me.pnlMinimizarParametros.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(100, 65)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(52, 65)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(103, 33)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 44
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(55, 33)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 43
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(92, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(115, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Items.AddRange(New Object() {"", "Pendientes", "Pagado"})
        Me.cmbNave.Location = New System.Drawing.Point(344, 47)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(300, 21)
        Me.cmbNave.TabIndex = 26
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(270, 50)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 25
        Me.lblNave.Text = "Nave"
        '
        'ChckActivarFecha
        '
        Me.ChckActivarFecha.AutoSize = True
        Me.ChckActivarFecha.Location = New System.Drawing.Point(509, 97)
        Me.ChckActivarFecha.Name = "ChckActivarFecha"
        Me.ChckActivarFecha.Size = New System.Drawing.Size(15, 14)
        Me.ChckActivarFecha.TabIndex = 22
        Me.ChckActivarFecha.UseVisualStyleBackColor = True
        Me.ChckActivarFecha.Visible = False
        '
        'DtpSegundaFecha
        '
        Me.DtpSegundaFecha.Enabled = False
        Me.DtpSegundaFecha.Location = New System.Drawing.Point(904, 91)
        Me.DtpSegundaFecha.Name = "DtpSegundaFecha"
        Me.DtpSegundaFecha.Size = New System.Drawing.Size(200, 20)
        Me.DtpSegundaFecha.TabIndex = 21
        Me.DtpSegundaFecha.Visible = False
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.ForeColor = System.Drawing.Color.Black
        Me.lblAl.Location = New System.Drawing.Point(835, 98)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(20, 13)
        Me.lblAl.TabIndex = 20
        Me.lblAl.Text = "AL"
        Me.lblAl.Visible = False
        '
        'Fecha
        '
        Me.Fecha.Enabled = False
        Me.Fecha.Location = New System.Drawing.Point(606, 91)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(200, 20)
        Me.Fecha.TabIndex = 19
        Me.Fecha.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.Black
        Me.lblFecha.Location = New System.Drawing.Point(546, 98)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(54, 13)
        Me.lblFecha.TabIndex = 18
        Me.lblFecha.Text = "Fecha del"
        Me.lblFecha.Visible = False
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.ForeColor = System.Drawing.Color.Black
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"", "AUTORIZADO GERENTE", "AUTORIZADO DIRECTOR"})
        Me.cmbStatus.Location = New System.Drawing.Point(756, 47)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(177, 21)
        Me.cmbStatus.TabIndex = 17
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.ForeColor = System.Drawing.Color.Black
        Me.Status.Location = New System.Drawing.Point(708, 50)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(42, 13)
        Me.Status.TabIndex = 15
        Me.Status.Text = "Estatus"
        '
        'txtBuscarNombreIncentivo
        '
        Me.txtBuscarNombreIncentivo.ForeColor = System.Drawing.Color.Black
        Me.txtBuscarNombreIncentivo.Location = New System.Drawing.Point(344, 79)
        Me.txtBuscarNombreIncentivo.Name = "txtBuscarNombreIncentivo"
        Me.txtBuscarNombreIncentivo.Size = New System.Drawing.Size(589, 20)
        Me.txtBuscarNombreIncentivo.TabIndex = 1
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.AutoSize = True
        Me.lblNombreEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(270, 81)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(64, 13)
        Me.lblNombreEmpleado.TabIndex = 0
        Me.lblNombreEmpleado.Text = "Colaborador"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Controls.Add(Me.lblNuevo)
        Me.pnlListaPaises.Controls.Add(Me.btnImprimir)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1241, 59)
        Me.pnlListaPaises.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(805, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(436, 59)
        Me.Panel1.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(69, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(297, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Autorización de Finiquitos - Director"
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(18, 42)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(42, 13)
        Me.lblNuevo.TabIndex = 3
        Me.lblNuevo.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(22, 7)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(31, 32)
        Me.btnImprimir.TabIndex = 1
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirFichaDeRenunciaToolStripMenuItem, Me.ImprimirCartaDeRenunciaToolStripMenuItem, Me.ImprimirDetalleToolStripMenuItem, Me.ImprimirCartaUtilidadesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(205, 92)
        '
        'ImprimirFichaDeRenunciaToolStripMenuItem
        '
        Me.ImprimirFichaDeRenunciaToolStripMenuItem.Name = "ImprimirFichaDeRenunciaToolStripMenuItem"
        Me.ImprimirFichaDeRenunciaToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ImprimirFichaDeRenunciaToolStripMenuItem.Text = "Imprimir Ficha de Renuncia"
        '
        'ImprimirCartaDeRenunciaToolStripMenuItem
        '
        Me.ImprimirCartaDeRenunciaToolStripMenuItem.Name = "ImprimirCartaDeRenunciaToolStripMenuItem"
        Me.ImprimirCartaDeRenunciaToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ImprimirCartaDeRenunciaToolStripMenuItem.Text = "Imprimir Carta de Renuncia"
        '
        'ImprimirDetalleToolStripMenuItem
        '
        Me.ImprimirDetalleToolStripMenuItem.Name = "ImprimirDetalleToolStripMenuItem"
        Me.ImprimirDetalleToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ImprimirDetalleToolStripMenuItem.Text = "Imprimir Detalle"
        '
        'ImprimirCartaUtilidadesToolStripMenuItem
        '
        Me.ImprimirCartaUtilidadesToolStripMenuItem.Name = "ImprimirCartaUtilidadesToolStripMenuItem"
        Me.ImprimirCartaUtilidadesToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ImprimirCartaUtilidadesToolStripMenuItem.Text = "Imprimir Carta Utilidades"
        '
        'cntxopciones
        '
        Me.cntxopciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarAnotacionToolStripMenuItem})
        Me.cntxopciones.Name = "cntxopciones"
        Me.cntxopciones.Size = New System.Drawing.Size(165, 26)
        '
        'AgregarAnotacionToolStripMenuItem
        '
        Me.AgregarAnotacionToolStripMenuItem.Name = "AgregarAnotacionToolStripMenuItem"
        Me.AgregarAnotacionToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.AgregarAnotacionToolStripMenuItem.Text = "Agregar Anotacion"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(368, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'ListaAutorizarGerenteFiniquitosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 529)
        Me.Controls.Add(Me.grdFiltroSolicitudes)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gpbFiltroIncentivos)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaAutorizarGerenteFiniquitosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización de Finiquitos - Director"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.grdFiltroSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFiltroIncentivos.ResumeLayout(False)
        Me.gpbFiltroIncentivos.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.cntxopciones.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents grdFiltroSolicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents gpbFiltroIncentivos As System.Windows.Forms.GroupBox
    Friend WithEvents ChckActivarFecha As System.Windows.Forms.CheckBox
    Friend WithEvents DtpSegundaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAl As System.Windows.Forms.Label
    Friend WithEvents Fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNombreIncentivo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimirFichaDeRenunciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirCartaDeRenunciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirDetalleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Status As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents ImprimirCartaUtilidadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents lblRechazar As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cntxopciones As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarAnotacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pcbTitulo As PictureBox
End Class
