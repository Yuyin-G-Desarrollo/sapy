<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaSolicitudFiniquitosORForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaSolicitudFiniquitosORForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.lblRechazar = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.pnlSolicitar = New System.Windows.Forms.Panel()
        Me.btnNoEntragada = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblAlertaSinCaja = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCajas = New System.Windows.Forms.ComboBox()
        Me.btnSolicitar = New System.Windows.Forms.Button()
        Me.lblSolicitar = New System.Windows.Forms.Label()
        Me.pnlEntregar = New System.Windows.Forms.Panel()
        Me.btnEntragarColaborador = New System.Windows.Forms.Button()
        Me.lblEntragar = New System.Windows.Forms.Label()
        Me.pnlEntregarDireccion = New System.Windows.Forms.Panel()
        Me.lblentregarDireccion = New System.Windows.Forms.Label()
        Me.btnEntregarDireccion = New System.Windows.Forms.Button()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblInstruccionPanelesEstado = New System.Windows.Forms.Label()
        Me.gpbFiltroIncentivos = New System.Windows.Forms.GroupBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.rdoFechaEntrega = New System.Windows.Forms.RadioButton()
        Me.rdoFechaBaja = New System.Windows.Forms.RadioButton()
        Me.chkXFechas = New System.Windows.Forms.CheckBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.rdoPeriodo = New System.Windows.Forms.RadioButton()
        Me.rdoRango = New System.Windows.Forms.RadioButton()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Status = New System.Windows.Forms.Label()
        Me.dttFin = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dttInicio = New System.Windows.Forms.DateTimePicker()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlNuevoFiniquito = New System.Windows.Forms.Panel()
        Me.btnNuevoFiniquito = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlImprimir = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.grdSolicitudes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimirFichaDeRenunciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirCartaDeRenunciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirCartaUtilidadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteFiniquitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteFiniquito2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConcentradoLiquidacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlSolicitar.SuspendLayout()
        Me.pnlEntregar.SuspendLayout()
        Me.pnlEntregarDireccion.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.gpbFiltroIncentivos.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlNuevoFiniquito.SuspendLayout()
        Me.pnlImprimir.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel14)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Panel15)
        Me.Panel2.Controls.Add(Me.pnlSolicitar)
        Me.Panel2.Controls.Add(Me.pnlEntregar)
        Me.Panel2.Controls.Add(Me.pnlEntregarDireccion)
        Me.Panel2.Controls.Add(Me.pnlAutorizar)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Panel13)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1241, 60)
        Me.Panel2.TabIndex = 25
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.btnRechazar)
        Me.Panel14.Controls.Add(Me.lblRechazar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel14.Location = New System.Drawing.Point(558, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(64, 60)
        Me.Panel14.TabIndex = 47
        '
        'btnRechazar
        '
        Me.btnRechazar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnRechazar.Location = New System.Drawing.Point(17, 4)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(31, 32)
        Me.btnRechazar.TabIndex = 7
        Me.btnRechazar.UseVisualStyleBackColor = True
        Me.btnRechazar.Visible = False
        '
        'lblRechazar
        '
        Me.lblRechazar.AutoSize = True
        Me.lblRechazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazar.Location = New System.Drawing.Point(8, 39)
        Me.lblRechazar.Name = "lblRechazar"
        Me.lblRechazar.Size = New System.Drawing.Size(53, 13)
        Me.lblRechazar.TabIndex = 17
        Me.lblRechazar.Text = "Rechazar"
        Me.lblRechazar.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(478, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 13)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "No Entregadas"
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel15.Location = New System.Drawing.Point(462, 38)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(15, 15)
        Me.Panel15.TabIndex = 49
        '
        'pnlSolicitar
        '
        Me.pnlSolicitar.Controls.Add(Me.btnNoEntragada)
        Me.pnlSolicitar.Controls.Add(Me.Label14)
        Me.pnlSolicitar.Controls.Add(Me.lblAlertaSinCaja)
        Me.pnlSolicitar.Controls.Add(Me.Label11)
        Me.pnlSolicitar.Controls.Add(Me.cmbCajas)
        Me.pnlSolicitar.Controls.Add(Me.btnSolicitar)
        Me.pnlSolicitar.Controls.Add(Me.lblSolicitar)
        Me.pnlSolicitar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSolicitar.Location = New System.Drawing.Point(622, 0)
        Me.pnlSolicitar.Name = "pnlSolicitar"
        Me.pnlSolicitar.Size = New System.Drawing.Size(393, 60)
        Me.pnlSolicitar.TabIndex = 39
        '
        'btnNoEntragada
        '
        Me.btnNoEntragada.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.finiquito_32
        Me.btnNoEntragada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNoEntragada.Location = New System.Drawing.Point(331, 4)
        Me.btnNoEntragada.Name = "btnNoEntragada"
        Me.btnNoEntragada.Size = New System.Drawing.Size(32, 32)
        Me.btnNoEntragada.TabIndex = 44
        Me.btnNoEntragada.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label14.Location = New System.Drawing.Point(311, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 26)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Liquidación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No Entregada"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAlertaSinCaja
        '
        Me.lblAlertaSinCaja.AutoSize = True
        Me.lblAlertaSinCaja.ForeColor = System.Drawing.Color.Red
        Me.lblAlertaSinCaja.Location = New System.Drawing.Point(38, 20)
        Me.lblAlertaSinCaja.Name = "lblAlertaSinCaja"
        Me.lblAlertaSinCaja.Size = New System.Drawing.Size(168, 13)
        Me.lblAlertaSinCaja.TabIndex = 43
        Me.lblAlertaSinCaja.Text = "No tiene cajas registradas en SAY"
        Me.lblAlertaSinCaja.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(4, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Caja"
        '
        'cmbCajas
        '
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Enabled = False
        Me.cmbCajas.ForeColor = System.Drawing.Color.Black
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Items.AddRange(New Object() {"", "TODOS", "SOLICITADO", "AUTORIZADO", "RECHAZADO", "SOLICITADO A CAJA CHICA", "PAGADO"})
        Me.cmbCajas.Location = New System.Drawing.Point(32, 17)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(211, 21)
        Me.cmbCajas.TabIndex = 42
        '
        'btnSolicitar
        '
        Me.btnSolicitar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.prestamos_32
        Me.btnSolicitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSolicitar.Location = New System.Drawing.Point(263, 4)
        Me.btnSolicitar.Name = "btnSolicitar"
        Me.btnSolicitar.Size = New System.Drawing.Size(32, 32)
        Me.btnSolicitar.TabIndex = 4
        Me.btnSolicitar.UseVisualStyleBackColor = True
        '
        'lblSolicitar
        '
        Me.lblSolicitar.AutoSize = True
        Me.lblSolicitar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSolicitar.Location = New System.Drawing.Point(251, 34)
        Me.lblSolicitar.Name = "lblSolicitar"
        Me.lblSolicitar.Size = New System.Drawing.Size(56, 26)
        Me.lblSolicitar.TabIndex = 5
        Me.lblSolicitar.Text = "Solicitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "caja chica"
        Me.lblSolicitar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlEntregar
        '
        Me.pnlEntregar.Controls.Add(Me.btnEntragarColaborador)
        Me.pnlEntregar.Controls.Add(Me.lblEntragar)
        Me.pnlEntregar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEntregar.Location = New System.Drawing.Point(1015, 0)
        Me.pnlEntregar.Name = "pnlEntregar"
        Me.pnlEntregar.Size = New System.Drawing.Size(61, 60)
        Me.pnlEntregar.TabIndex = 40
        '
        'btnEntragarColaborador
        '
        Me.btnEntragarColaborador.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.entregarColaborador
        Me.btnEntragarColaborador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEntragarColaborador.Location = New System.Drawing.Point(14, 4)
        Me.btnEntragarColaborador.Name = "btnEntragarColaborador"
        Me.btnEntragarColaborador.Size = New System.Drawing.Size(32, 32)
        Me.btnEntragarColaborador.TabIndex = 4
        Me.btnEntragarColaborador.UseVisualStyleBackColor = True
        '
        'lblEntragar
        '
        Me.lblEntragar.AutoSize = True
        Me.lblEntragar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEntragar.Location = New System.Drawing.Point(-1, 34)
        Me.lblEntragar.Name = "lblEntragar"
        Me.lblEntragar.Size = New System.Drawing.Size(63, 26)
        Me.lblEntragar.TabIndex = 5
        Me.lblEntragar.Text = "Entregar a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "colaborador"
        Me.lblEntragar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlEntregarDireccion
        '
        Me.pnlEntregarDireccion.Controls.Add(Me.lblentregarDireccion)
        Me.pnlEntregarDireccion.Controls.Add(Me.btnEntregarDireccion)
        Me.pnlEntregarDireccion.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEntregarDireccion.Location = New System.Drawing.Point(1076, 0)
        Me.pnlEntregarDireccion.Name = "pnlEntregarDireccion"
        Me.pnlEntregarDireccion.Size = New System.Drawing.Size(59, 60)
        Me.pnlEntregarDireccion.TabIndex = 44
        '
        'lblentregarDireccion
        '
        Me.lblentregarDireccion.AutoSize = True
        Me.lblentregarDireccion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblentregarDireccion.Location = New System.Drawing.Point(0, 34)
        Me.lblentregarDireccion.Name = "lblentregarDireccion"
        Me.lblentregarDireccion.Size = New System.Drawing.Size(59, 26)
        Me.lblentregarDireccion.TabIndex = 44
        Me.lblentregarDireccion.Text = "Entregar a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dirección"
        Me.lblentregarDireccion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEntregarDireccion
        '
        Me.btnEntregarDireccion.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.entregarColaborador
        Me.btnEntregarDireccion.Location = New System.Drawing.Point(12, 4)
        Me.btnEntregarDireccion.Name = "btnEntregarDireccion"
        Me.btnEntregarDireccion.Size = New System.Drawing.Size(32, 32)
        Me.btnEntregarDireccion.TabIndex = 43
        Me.btnEntregarDireccion.UseVisualStyleBackColor = True
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizar)
        Me.pnlAutorizar.Controls.Add(Me.Label7)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAutorizar.Location = New System.Drawing.Point(1135, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(54, 60)
        Me.pnlAutorizar.TabIndex = 38
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAutorizar.Location = New System.Drawing.Point(14, 4)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(31, 32)
        Me.btnAutorizar.TabIndex = 6
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(5, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Autorizar"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(478, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(147, 13)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Dinero Entregado a Dirección"
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.MediumPurple
        Me.Panel13.Location = New System.Drawing.Point(462, 16)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(15, 15)
        Me.Panel13.TabIndex = 45
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(107, 36)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(15, 15)
        Me.Panel6.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Dinero Entregado a Nave"
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
        Me.btnCerrar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
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
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(13, Byte), Integer))
        Me.Panel9.Location = New System.Drawing.Point(270, 15)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(15, 15)
        Me.Panel9.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(287, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(161, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Dinero Entregado al Colaborador"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.Panel8.Location = New System.Drawing.Point(107, 15)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(15, 15)
        Me.Panel8.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(125, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Solicitado a Caja Chica"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(12, 36)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(15, 15)
        Me.Panel5.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(270, 36)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(15, 15)
        Me.Panel4.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(12, 15)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(287, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Rechazado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Solicitado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Autorizado"
        '
        'lblInstruccionPanelesEstado
        '
        Me.lblInstruccionPanelesEstado.AutoSize = True
        Me.lblInstruccionPanelesEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruccionPanelesEstado.Location = New System.Drawing.Point(42, 126)
        Me.lblInstruccionPanelesEstado.Name = "lblInstruccionPanelesEstado"
        Me.lblInstruccionPanelesEstado.Size = New System.Drawing.Size(282, 26)
        Me.lblInstruccionPanelesEstado.TabIndex = 43
        Me.lblInstruccionPanelesEstado.Text = "Para habilitar los botones seleccione del combo estatus el " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "correspondiente a la" &
    " acción que desee realizar."
        Me.lblInstruccionPanelesEstado.Visible = False
        '
        'gpbFiltroIncentivos
        '
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblInstruccionPanelesEstado)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Panel11)
        Me.gpbFiltroIncentivos.Controls.Add(Me.chkXFechas)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Panel10)
        Me.gpbFiltroIncentivos.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Panel12)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbNave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblNave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbPeriodo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbStatus)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Status)
        Me.gpbFiltroIncentivos.Controls.Add(Me.dttFin)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Label9)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Label10)
        Me.gpbFiltroIncentivos.Controls.Add(Me.dttInicio)
        Me.gpbFiltroIncentivos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltroIncentivos.Location = New System.Drawing.Point(0, 59)
        Me.gpbFiltroIncentivos.Name = "gpbFiltroIncentivos"
        Me.gpbFiltroIncentivos.Size = New System.Drawing.Size(1241, 152)
        Me.gpbFiltroIncentivos.TabIndex = 23
        Me.gpbFiltroIncentivos.TabStop = False
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.rdoFechaEntrega)
        Me.Panel11.Controls.Add(Me.rdoFechaBaja)
        Me.Panel11.Location = New System.Drawing.Point(546, 37)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(206, 36)
        Me.Panel11.TabIndex = 94
        '
        'rdoFechaEntrega
        '
        Me.rdoFechaEntrega.AutoSize = True
        Me.rdoFechaEntrega.Location = New System.Drawing.Point(108, 14)
        Me.rdoFechaEntrega.Name = "rdoFechaEntrega"
        Me.rdoFechaEntrega.Size = New System.Drawing.Size(95, 17)
        Me.rdoFechaEntrega.TabIndex = 1
        Me.rdoFechaEntrega.Text = "Fecha Entrega"
        Me.rdoFechaEntrega.UseVisualStyleBackColor = True
        '
        'rdoFechaBaja
        '
        Me.rdoFechaBaja.AutoSize = True
        Me.rdoFechaBaja.Checked = True
        Me.rdoFechaBaja.Location = New System.Drawing.Point(3, 14)
        Me.rdoFechaBaja.Name = "rdoFechaBaja"
        Me.rdoFechaBaja.Size = New System.Drawing.Size(79, 17)
        Me.rdoFechaBaja.TabIndex = 0
        Me.rdoFechaBaja.TabStop = True
        Me.rdoFechaBaja.Text = "Fecha Baja"
        Me.rdoFechaBaja.UseVisualStyleBackColor = True
        '
        'chkXFechas
        '
        Me.chkXFechas.AutoSize = True
        Me.chkXFechas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkXFechas.Location = New System.Drawing.Point(405, 52)
        Me.chkXFechas.Name = "chkXFechas"
        Me.chkXFechas.Size = New System.Drawing.Size(101, 17)
        Me.chkXFechas.TabIndex = 92
        Me.chkXFechas.Text = "Filtro por fechas"
        Me.chkXFechas.UseVisualStyleBackColor = True
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
        Me.Panel10.Size = New System.Drawing.Size(112, 133)
        Me.Panel10.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(58, 52)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(12, 21)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 4
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(7, 52)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(62, 21)
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
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(65, 133)
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
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.rdoPeriodo)
        Me.Panel12.Controls.Add(Me.rdoRango)
        Me.Panel12.Location = New System.Drawing.Point(404, 75)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(109, 47)
        Me.Panel12.TabIndex = 95
        '
        'rdoPeriodo
        '
        Me.rdoPeriodo.AutoSize = True
        Me.rdoPeriodo.Location = New System.Drawing.Point(12, 27)
        Me.rdoPeriodo.Name = "rdoPeriodo"
        Me.rdoPeriodo.Size = New System.Drawing.Size(61, 17)
        Me.rdoPeriodo.TabIndex = 1
        Me.rdoPeriodo.Text = "Periodo"
        Me.rdoPeriodo.UseVisualStyleBackColor = True
        '
        'rdoRango
        '
        Me.rdoRango.AutoSize = True
        Me.rdoRango.Checked = True
        Me.rdoRango.Location = New System.Drawing.Point(12, 2)
        Me.rdoRango.Name = "rdoRango"
        Me.rdoRango.Size = New System.Drawing.Size(57, 17)
        Me.rdoRango.TabIndex = 0
        Me.rdoRango.TabStop = True
        Me.rdoRango.Text = "Rango"
        Me.rdoRango.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Items.AddRange(New Object() {"", "Pendientes", "Pagado"})
        Me.cmbNave.Location = New System.Drawing.Point(83, 77)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(301, 21)
        Me.cmbNave.TabIndex = 1
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(42, 81)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 25
        Me.lblNave.Text = "Nave"
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodo.ForeColor = System.Drawing.Color.Black
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(546, 102)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(500, 21)
        Me.cmbPeriodo.TabIndex = 93
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.ForeColor = System.Drawing.Color.Black
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"", "TODOS", "SOLICITADO", "AUTORIZADO", "SOLICITADO A CAJA CHICA", "DINERO ENTREGADO A NAVE", "DINERO ENTREGADO AL COLABORADOR", "DINERO ENTREGADO A DIRECCIÓN", "NO ENTREGADA"})
        Me.cmbStatus.Location = New System.Drawing.Point(83, 101)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(301, 21)
        Me.cmbStatus.TabIndex = 2
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.ForeColor = System.Drawing.Color.Black
        Me.Status.Location = New System.Drawing.Point(42, 105)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(42, 13)
        Me.Status.TabIndex = 15
        Me.Status.Text = "Estatus"
        '
        'dttFin
        '
        Me.dttFin.Location = New System.Drawing.Point(846, 77)
        Me.dttFin.Name = "dttFin"
        Me.dttFin.Size = New System.Drawing.Size(200, 20)
        Me.dttFin.TabIndex = 91
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(543, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "Fecha del"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(819, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 13)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Al"
        '
        'dttInicio
        '
        Me.dttInicio.Location = New System.Drawing.Point(608, 77)
        Me.dttInicio.Name = "dttInicio"
        Me.dttInicio.Size = New System.Drawing.Size(200, 20)
        Me.dttInicio.TabIndex = 90
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.btnExportar)
        Me.pnlListaPaises.Controls.Add(Me.Label13)
        Me.pnlListaPaises.Controls.Add(Me.pnlNuevoFiniquito)
        Me.pnlListaPaises.Controls.Add(Me.pnlImprimir)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1241, 59)
        Me.pnlListaPaises.TabIndex = 22
        '
        'btnExportar
        '
        Me.btnExportar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(226, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(31, 32)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label13.Location = New System.Drawing.Point(220, 42)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Exportar"
        '
        'pnlNuevoFiniquito
        '
        Me.pnlNuevoFiniquito.Controls.Add(Me.btnNuevoFiniquito)
        Me.pnlNuevoFiniquito.Controls.Add(Me.Label8)
        Me.pnlNuevoFiniquito.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlNuevoFiniquito.Location = New System.Drawing.Point(89, 0)
        Me.pnlNuevoFiniquito.Name = "pnlNuevoFiniquito"
        Me.pnlNuevoFiniquito.Size = New System.Drawing.Size(96, 59)
        Me.pnlNuevoFiniquito.TabIndex = 10
        '
        'btnNuevoFiniquito
        '
        Me.btnNuevoFiniquito.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.finiquito_32
        Me.btnNuevoFiniquito.Location = New System.Drawing.Point(32, 9)
        Me.btnNuevoFiniquito.Name = "btnNuevoFiniquito"
        Me.btnNuevoFiniquito.Size = New System.Drawing.Size(31, 32)
        Me.btnNuevoFiniquito.TabIndex = 7
        Me.btnNuevoFiniquito.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(1, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Nueva liquidación"
        '
        'pnlImprimir
        '
        Me.pnlImprimir.Controls.Add(Me.btnImprimir)
        Me.pnlImprimir.Controls.Add(Me.lblNuevo)
        Me.pnlImprimir.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImprimir.Location = New System.Drawing.Point(0, 0)
        Me.pnlImprimir.Name = "pnlImprimir"
        Me.pnlImprimir.Size = New System.Drawing.Size(89, 59)
        Me.pnlImprimir.TabIndex = 9
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(21, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(31, 32)
        Me.btnImprimir.TabIndex = 1
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(15, 42)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(42, 13)
        Me.lblNuevo.TabIndex = 3
        Me.lblNuevo.Text = "Imprimir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(820, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 59)
        Me.Panel1.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(166, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(188, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Lista de Liquidaciones"
        '
        'grdSolicitudes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSolicitudes.DisplayLayout.Appearance = Appearance1
        Me.grdSolicitudes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdSolicitudes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdSolicitudes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdSolicitudes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdSolicitudes.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdSolicitudes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSolicitudes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdSolicitudes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSolicitudes.Location = New System.Drawing.Point(0, 211)
        Me.grdSolicitudes.Name = "grdSolicitudes"
        Me.grdSolicitudes.Size = New System.Drawing.Size(1241, 254)
        Me.grdSolicitudes.TabIndex = 26
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirFichaDeRenunciaToolStripMenuItem, Me.ImprimirCartaDeRenunciaToolStripMenuItem, Me.ImprimirCartaUtilidadesToolStripMenuItem, Me.ReporteFiniquitoToolStripMenuItem, Me.ReporteFiniquito2ToolStripMenuItem, Me.ConcentradoLiquidacionesToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(220, 136)
        '
        'ImprimirFichaDeRenunciaToolStripMenuItem
        '
        Me.ImprimirFichaDeRenunciaToolStripMenuItem.Name = "ImprimirFichaDeRenunciaToolStripMenuItem"
        Me.ImprimirFichaDeRenunciaToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ImprimirFichaDeRenunciaToolStripMenuItem.Text = "Imprimir Cálculo de Liquidación"
        '
        'ImprimirCartaDeRenunciaToolStripMenuItem
        '
        Me.ImprimirCartaDeRenunciaToolStripMenuItem.Name = "ImprimirCartaDeRenunciaToolStripMenuItem"
        Me.ImprimirCartaDeRenunciaToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ImprimirCartaDeRenunciaToolStripMenuItem.Text = "Imprimir Carta de Renuncia"
        '
        'ImprimirCartaUtilidadesToolStripMenuItem
        '
        Me.ImprimirCartaUtilidadesToolStripMenuItem.Name = "ImprimirCartaUtilidadesToolStripMenuItem"
        Me.ImprimirCartaUtilidadesToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ImprimirCartaUtilidadesToolStripMenuItem.Text = "Imprimir Carta Utilidades"
        '
        'ReporteFiniquitoToolStripMenuItem
        '
        Me.ReporteFiniquitoToolStripMenuItem.Name = "ReporteFiniquitoToolStripMenuItem"
        Me.ReporteFiniquitoToolStripMenuItem.ShowShortcutKeys = False
        Me.ReporteFiniquitoToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ReporteFiniquitoToolStripMenuItem.Text = "Reporte Liquidación"
        '
        'ReporteFiniquito2ToolStripMenuItem
        '
        Me.ReporteFiniquito2ToolStripMenuItem.Name = "ReporteFiniquito2ToolStripMenuItem"
        Me.ReporteFiniquito2ToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ReporteFiniquito2ToolStripMenuItem.Text = "Resumen Liquidaciones Naves"
        '
        'ConcentradoLiquidacionesToolStripMenuItem
        '
        Me.ConcentradoLiquidacionesToolStripMenuItem.Name = "ConcentradoLiquidacionesToolStripMenuItem"
        Me.ConcentradoLiquidacionesToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ConcentradoLiquidacionesToolStripMenuItem.Text = "Concentrado de Liquidaciones"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(353, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'ListaSolicitudFiniquitosORForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 525)
        Me.Controls.Add(Me.grdSolicitudes)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gpbFiltroIncentivos)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "ListaSolicitudFiniquitosORForm"
        Me.Text = "Lista de Finiquitos"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlSolicitar.ResumeLayout(False)
        Me.pnlSolicitar.PerformLayout()
        Me.pnlEntregar.ResumeLayout(False)
        Me.pnlEntregar.PerformLayout()
        Me.pnlEntregarDireccion.ResumeLayout(False)
        Me.pnlEntregarDireccion.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.gpbFiltroIncentivos.ResumeLayout(False)
        Me.gpbFiltroIncentivos.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlNuevoFiniquito.ResumeLayout(False)
        Me.pnlNuevoFiniquito.PerformLayout()
        Me.pnlImprimir.ResumeLayout(False)
        Me.pnlImprimir.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gpbFiltroIncentivos As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Status As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdSolicitudes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlSolicitar As System.Windows.Forms.Panel
    Friend WithEvents btnSolicitar As System.Windows.Forms.Button
    Friend WithEvents lblSolicitar As System.Windows.Forms.Label
    Friend WithEvents pnlAutorizar As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents lblRechazar As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimirFichaDeRenunciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirCartaDeRenunciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirCartaUtilidadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlNuevoFiniquito As System.Windows.Forms.Panel
    Friend WithEvents pnlImprimir As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnNuevoFiniquito As System.Windows.Forms.Button
    Friend WithEvents lblInstruccionPanelesEstado As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbCajas As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlertaSinCaja As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents rdoFechaEntrega As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFechaBaja As System.Windows.Forms.RadioButton
    Friend WithEvents chkXFechas As System.Windows.Forms.CheckBox
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents rdoPeriodo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRango As System.Windows.Forms.RadioButton
    Friend WithEvents cmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents dttFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dttInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents ReporteFiniquitoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents ConcentradoLiquidacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnNoEntragada As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents pnlEntregar As Panel
    Friend WithEvents btnEntragarColaborador As Button
    Friend WithEvents lblEntragar As Label
    Friend WithEvents pnlEntregarDireccion As Panel
    Friend WithEvents lblentregarDireccion As Label
    Friend WithEvents btnEntregarDireccion As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents ReporteFiniquito2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pcbTitulo As PictureBox
End Class
