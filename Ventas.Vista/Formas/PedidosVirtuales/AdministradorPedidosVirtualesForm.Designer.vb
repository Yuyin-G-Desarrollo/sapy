<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorPedidosVirtualesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorPedidosVirtualesForm))
        Me.grdPedidosVirtuales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.dtpProgramacionDel = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.chkAlerta = New System.Windows.Forms.CheckBox()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpSolicitadaAl = New System.Windows.Forms.DateTimePicker()
        Me.chkSolicitadaCliente = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpSolicitadaDel = New System.Windows.Forms.DateTimePicker()
        Me.lblConfirmacionOTAl = New System.Windows.Forms.Label()
        Me.dtpCapturaAl = New System.Windows.Forms.DateTimePicker()
        Me.chkCaptura = New System.Windows.Forms.CheckBox()
        Me.lblConfirmacionOTDel = New System.Windows.Forms.Label()
        Me.dtpCapturaDel = New System.Windows.Forms.DateTimePicker()
        Me.lblFacturacionAl = New System.Windows.Forms.Label()
        Me.dtpProgramacionAl = New System.Windows.Forms.DateTimePicker()
        Me.chkProgramacioin = New System.Windows.Forms.CheckBox()
        Me.lblFacturacionDel = New System.Windows.Forms.Label()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblFechaConsulta = New System.Windows.Forms.Label()
        Me.lblPedidosAlerta = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblPedidosContados = New System.Windows.Forms.Label()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnVincular = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPedidoReal = New System.Windows.Forms.Button()
        Me.lblCancelarSalida = New System.Windows.Forms.Label()
        Me.btnCancelarSalida = New System.Windows.Forms.Button()
        Me.Editar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.hilo = New System.ComponentModel.BackgroundWorker()
        CType(Me.grdPedidosVirtuales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdPedidosVirtuales
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidosVirtuales.DisplayLayout.Appearance = Appearance1
        Me.grdPedidosVirtuales.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.grdPedidosVirtuales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidosVirtuales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdPedidosVirtuales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdPedidosVirtuales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPedidosVirtuales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidosVirtuales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidosVirtuales.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPedidosVirtuales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPedidosVirtuales.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.None
        Me.grdPedidosVirtuales.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdPedidosVirtuales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidosVirtuales.Location = New System.Drawing.Point(0, 173)
        Me.grdPedidosVirtuales.Name = "grdPedidosVirtuales"
        Me.grdPedidosVirtuales.Size = New System.Drawing.Size(1111, 302)
        Me.grdPedidosVirtuales.TabIndex = 61
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlDatos.Controls.Add(Me.dtpProgramacionDel)
        Me.pnlDatos.Controls.Add(Me.Panel3)
        Me.pnlDatos.Controls.Add(Me.cmbEstatus)
        Me.pnlDatos.Controls.Add(Me.chkAlerta)
        Me.pnlDatos.Controls.Add(Me.chkSeleccionar)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.dtpSolicitadaAl)
        Me.pnlDatos.Controls.Add(Me.chkSolicitadaCliente)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.dtpSolicitadaDel)
        Me.pnlDatos.Controls.Add(Me.lblConfirmacionOTAl)
        Me.pnlDatos.Controls.Add(Me.dtpCapturaAl)
        Me.pnlDatos.Controls.Add(Me.chkCaptura)
        Me.pnlDatos.Controls.Add(Me.lblConfirmacionOTDel)
        Me.pnlDatos.Controls.Add(Me.dtpCapturaDel)
        Me.pnlDatos.Controls.Add(Me.lblFacturacionAl)
        Me.pnlDatos.Controls.Add(Me.dtpProgramacionAl)
        Me.pnlDatos.Controls.Add(Me.chkProgramacioin)
        Me.pnlDatos.Controls.Add(Me.lblFacturacionDel)
        Me.pnlDatos.Controls.Add(Me.cmbClientes)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.Label18)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.Location = New System.Drawing.Point(0, 67)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1111, 106)
        Me.pnlDatos.TabIndex = 64
        '
        'dtpProgramacionDel
        '
        Me.dtpProgramacionDel.CustomFormat = ""
        Me.dtpProgramacionDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProgramacionDel.Location = New System.Drawing.Point(790, 66)
        Me.dtpProgramacionDel.Name = "dtpProgramacionDel"
        Me.dtpProgramacionDel.Size = New System.Drawing.Size(86, 20)
        Me.dtpProgramacionDel.TabIndex = 10
        Me.dtpProgramacionDel.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnArriba)
        Me.Panel3.Controls.Add(Me.btnAbajo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1043, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(68, 106)
        Me.Panel3.TabIndex = 91
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(9, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(37, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Items.AddRange(New Object() {"", "ACTIVA", "EN RUTA", "ENTREGA COMPLETA", "ENTREGA PARCIAL"})
        Me.cmbEstatus.Location = New System.Drawing.Point(88, 54)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(163, 21)
        Me.cmbEstatus.TabIndex = 1
        '
        'chkAlerta
        '
        Me.chkAlerta.AutoSize = True
        Me.chkAlerta.Checked = True
        Me.chkAlerta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAlerta.Location = New System.Drawing.Point(266, 53)
        Me.chkAlerta.Name = "chkAlerta"
        Me.chkAlerta.Size = New System.Drawing.Size(340, 17)
        Me.chkAlerta.TabIndex = 2
        Me.chkAlerta.Text = "Alerta de Pedidos con FProgramación < 7 días (No pedidos reales)"
        Me.chkAlerta.UseVisualStyleBackColor = True
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(15, 81)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionar.TabIndex = 64
        Me.chkSeleccionar.Text = "Seleccionar todo"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(889, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Al"
        '
        'dtpSolicitadaAl
        '
        Me.dtpSolicitadaAl.CustomFormat = ""
        Me.dtpSolicitadaAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSolicitadaAl.Location = New System.Drawing.Point(910, 43)
        Me.dtpSolicitadaAl.Name = "dtpSolicitadaAl"
        Me.dtpSolicitadaAl.Size = New System.Drawing.Size(86, 20)
        Me.dtpSolicitadaAl.TabIndex = 8
        Me.dtpSolicitadaAl.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'chkSolicitadaCliente
        '
        Me.chkSolicitadaCliente.AutoSize = True
        Me.chkSolicitadaCliente.Location = New System.Drawing.Point(626, 45)
        Me.chkSolicitadaCliente.Name = "chkSolicitadaCliente"
        Me.chkSolicitadaCliente.Size = New System.Drawing.Size(107, 17)
        Me.chkSolicitadaCliente.TabIndex = 6
        Me.chkSolicitadaCliente.Text = "Solicitada Cliente"
        Me.chkSolicitadaCliente.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(763, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Del"
        '
        'dtpSolicitadaDel
        '
        Me.dtpSolicitadaDel.CustomFormat = ""
        Me.dtpSolicitadaDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSolicitadaDel.Location = New System.Drawing.Point(790, 43)
        Me.dtpSolicitadaDel.Name = "dtpSolicitadaDel"
        Me.dtpSolicitadaDel.Size = New System.Drawing.Size(86, 20)
        Me.dtpSolicitadaDel.TabIndex = 7
        Me.dtpSolicitadaDel.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblConfirmacionOTAl
        '
        Me.lblConfirmacionOTAl.AutoSize = True
        Me.lblConfirmacionOTAl.ForeColor = System.Drawing.Color.Black
        Me.lblConfirmacionOTAl.Location = New System.Drawing.Point(889, 26)
        Me.lblConfirmacionOTAl.Name = "lblConfirmacionOTAl"
        Me.lblConfirmacionOTAl.Size = New System.Drawing.Size(16, 13)
        Me.lblConfirmacionOTAl.TabIndex = 58
        Me.lblConfirmacionOTAl.Text = "Al"
        '
        'dtpCapturaAl
        '
        Me.dtpCapturaAl.CustomFormat = ""
        Me.dtpCapturaAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCapturaAl.Location = New System.Drawing.Point(910, 21)
        Me.dtpCapturaAl.Name = "dtpCapturaAl"
        Me.dtpCapturaAl.Size = New System.Drawing.Size(86, 20)
        Me.dtpCapturaAl.TabIndex = 5
        Me.dtpCapturaAl.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'chkCaptura
        '
        Me.chkCaptura.AutoSize = True
        Me.chkCaptura.Location = New System.Drawing.Point(626, 23)
        Me.chkCaptura.Name = "chkCaptura"
        Me.chkCaptura.Size = New System.Drawing.Size(63, 17)
        Me.chkCaptura.TabIndex = 3
        Me.chkCaptura.Text = "Captura"
        Me.chkCaptura.UseVisualStyleBackColor = True
        '
        'lblConfirmacionOTDel
        '
        Me.lblConfirmacionOTDel.AutoSize = True
        Me.lblConfirmacionOTDel.ForeColor = System.Drawing.Color.Black
        Me.lblConfirmacionOTDel.Location = New System.Drawing.Point(763, 25)
        Me.lblConfirmacionOTDel.Name = "lblConfirmacionOTDel"
        Me.lblConfirmacionOTDel.Size = New System.Drawing.Size(23, 13)
        Me.lblConfirmacionOTDel.TabIndex = 55
        Me.lblConfirmacionOTDel.Text = "Del"
        '
        'dtpCapturaDel
        '
        Me.dtpCapturaDel.CustomFormat = ""
        Me.dtpCapturaDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCapturaDel.Location = New System.Drawing.Point(790, 21)
        Me.dtpCapturaDel.Name = "dtpCapturaDel"
        Me.dtpCapturaDel.Size = New System.Drawing.Size(86, 20)
        Me.dtpCapturaDel.TabIndex = 4
        Me.dtpCapturaDel.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'lblFacturacionAl
        '
        Me.lblFacturacionAl.AutoSize = True
        Me.lblFacturacionAl.ForeColor = System.Drawing.Color.Black
        Me.lblFacturacionAl.Location = New System.Drawing.Point(889, 68)
        Me.lblFacturacionAl.Name = "lblFacturacionAl"
        Me.lblFacturacionAl.Size = New System.Drawing.Size(16, 13)
        Me.lblFacturacionAl.TabIndex = 53
        Me.lblFacturacionAl.Text = "Al"
        '
        'dtpProgramacionAl
        '
        Me.dtpProgramacionAl.CustomFormat = ""
        Me.dtpProgramacionAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProgramacionAl.Location = New System.Drawing.Point(910, 66)
        Me.dtpProgramacionAl.Name = "dtpProgramacionAl"
        Me.dtpProgramacionAl.Size = New System.Drawing.Size(86, 20)
        Me.dtpProgramacionAl.TabIndex = 11
        Me.dtpProgramacionAl.Value = New Date(2016, 1, 8, 0, 0, 0, 0)
        '
        'chkProgramacioin
        '
        Me.chkProgramacioin.AutoSize = True
        Me.chkProgramacioin.Location = New System.Drawing.Point(626, 67)
        Me.chkProgramacioin.Name = "chkProgramacioin"
        Me.chkProgramacioin.Size = New System.Drawing.Size(91, 17)
        Me.chkProgramacioin.TabIndex = 9
        Me.chkProgramacioin.Text = "Programación"
        Me.chkProgramacioin.UseVisualStyleBackColor = True
        '
        'lblFacturacionDel
        '
        Me.lblFacturacionDel.AutoSize = True
        Me.lblFacturacionDel.ForeColor = System.Drawing.Color.Black
        Me.lblFacturacionDel.Location = New System.Drawing.Point(763, 68)
        Me.lblFacturacionDel.Name = "lblFacturacionDel"
        Me.lblFacturacionDel.Size = New System.Drawing.Size(23, 13)
        Me.lblFacturacionDel.TabIndex = 50
        Me.lblFacturacionDel.Text = "Del"
        '
        'cmbClientes
        '
        Me.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Items.AddRange(New Object() {"", "ACTIVA", "EN RUTA", "ENTREGA COMPLETA", "ENTREGA PARCIAL"})
        Me.cmbClientes.Location = New System.Drawing.Point(88, 23)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(475, 21)
        Me.cmbClientes.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Status"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(43, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Cliente"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblFechaConsulta)
        Me.Panel2.Controls.Add(Me.lblPedidosAlerta)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.lblPedidosContados)
        Me.Panel2.Controls.Add(Me.lblSeleccionados)
        Me.Panel2.Controls.Add(Me.lblRegistros)
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 475)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1111, 60)
        Me.Panel2.TabIndex = 63
        '
        'lblFechaConsulta
        '
        Me.lblFechaConsulta.AutoSize = True
        Me.lblFechaConsulta.Location = New System.Drawing.Point(802, 16)
        Me.lblFechaConsulta.Name = "lblFechaConsulta"
        Me.lblFechaConsulta.Size = New System.Drawing.Size(0, 13)
        Me.lblFechaConsulta.TabIndex = 14
        '
        'lblPedidosAlerta
        '
        Me.lblPedidosAlerta.AutoSize = True
        Me.lblPedidosAlerta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosAlerta.ForeColor = System.Drawing.Color.Red
        Me.lblPedidosAlerta.Location = New System.Drawing.Point(586, 31)
        Me.lblPedidosAlerta.Name = "lblPedidosAlerta"
        Me.lblPedidosAlerta.Size = New System.Drawing.Size(25, 25)
        Me.lblPedidosAlerta.TabIndex = 13
        Me.lblPedidosAlerta.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(457, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(293, 26)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Pedidos virtuales con FProgramación dentro de los próximos " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7 días que aún no se" &
    " vinculan o convierten a un pedido real"
        '
        'lblPedidosContados
        '
        Me.lblPedidosContados.AutoSize = True
        Me.lblPedidosContados.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosContados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPedidosContados.Location = New System.Drawing.Point(48, 31)
        Me.lblPedidosContados.Name = "lblPedidosContados"
        Me.lblPedidosContados.Size = New System.Drawing.Size(25, 25)
        Me.lblPedidosContados.TabIndex = 10
        Me.lblPedidosContados.Text = "0"
        '
        'lblSeleccionados
        '
        Me.lblSeleccionados.AutoSize = True
        Me.lblSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionados.Location = New System.Drawing.Point(10, 16)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(117, 18)
        Me.lblSeleccionados.TabIndex = 11
        Me.lblSeleccionados.Text = "seleccionados"
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(33, 1)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblRegistros.TabIndex = 9
        Me.lblRegistros.Text = "Pedidos"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Controls.Add(Me.lblMostrar)
        Me.pnlAcciones.Controls.Add(Me.btnLimpiar)
        Me.pnlAcciones.Controls.Add(Me.lblLimpiar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(885, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(226, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnMostrar
        '
        Me.btnMostrar.Enabled = False
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(74, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(69, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 25
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Enabled = False
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(130, 7)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 1
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(126, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 23
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Enabled = False
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(182, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(181, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.btnAutorizar)
        Me.pnlHeader.Controls.Add(Me.Label7)
        Me.pnlHeader.Controls.Add(Me.btnVincular)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Controls.Add(Me.btnConfirmar)
        Me.pnlHeader.Controls.Add(Me.Label5)
        Me.pnlHeader.Controls.Add(Me.btnPedidoReal)
        Me.pnlHeader.Controls.Add(Me.lblCancelarSalida)
        Me.pnlHeader.Controls.Add(Me.btnCancelarSalida)
        Me.pnlHeader.Controls.Add(Me.Editar)
        Me.pnlHeader.Controls.Add(Me.btnEditar)
        Me.pnlHeader.Controls.Add(Me.btnAltas)
        Me.pnlHeader.Controls.Add(Me.lblAltas)
        Me.pnlHeader.Controls.Add(Me.lblExportar)
        Me.pnlHeader.Controls.Add(Me.btnExportar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1111, 67)
        Me.pnlHeader.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(173, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Autorizar"
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Enabled = False
        Me.btnAutorizar.Image = Global.Ventas.Vista.My.Resources.Resources.autorizar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(179, 7)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 3
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(299, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 26)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Vincular con " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pedido Real"
        '
        'btnVincular
        '
        Me.btnVincular.Enabled = False
        Me.btnVincular.Image = Global.Ventas.Vista.My.Resources.Resources.vincular_24x24
        Me.btnVincular.Location = New System.Drawing.Point(314, 7)
        Me.btnVincular.Name = "btnVincular"
        Me.btnVincular.Size = New System.Drawing.Size(32, 32)
        Me.btnVincular.TabIndex = 5
        Me.btnVincular.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(112, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Confirmar"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Enabled = False
        Me.btnConfirmar.Image = Global.Ventas.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnConfirmar.Location = New System.Drawing.Point(121, 7)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(32, 32)
        Me.btnConfirmar.TabIndex = 2
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(226, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 26)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Convertir a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pedido Real"
        '
        'btnPedidoReal
        '
        Me.btnPedidoReal.Enabled = False
        Me.btnPedidoReal.Image = Global.Ventas.Vista.My.Resources.Resources.asignar
        Me.btnPedidoReal.Location = New System.Drawing.Point(241, 7)
        Me.btnPedidoReal.Name = "btnPedidoReal"
        Me.btnPedidoReal.Size = New System.Drawing.Size(32, 32)
        Me.btnPedidoReal.TabIndex = 4
        Me.btnPedidoReal.UseVisualStyleBackColor = True
        '
        'lblCancelarSalida
        '
        Me.lblCancelarSalida.AutoSize = True
        Me.lblCancelarSalida.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarSalida.Location = New System.Drawing.Point(370, 38)
        Me.lblCancelarSalida.Name = "lblCancelarSalida"
        Me.lblCancelarSalida.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelarSalida.TabIndex = 38
        Me.lblCancelarSalida.Text = "Cancelar"
        '
        'btnCancelarSalida
        '
        Me.btnCancelarSalida.Enabled = False
        Me.btnCancelarSalida.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar321
        Me.btnCancelarSalida.Location = New System.Drawing.Point(376, 7)
        Me.btnCancelarSalida.Name = "btnCancelarSalida"
        Me.btnCancelarSalida.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarSalida.TabIndex = 6
        Me.btnCancelarSalida.UseVisualStyleBackColor = True
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(66, 38)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 23
        Me.Editar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Enabled = False
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(66, 7)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 1
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAltas.Enabled = False
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(15, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 0
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(16, 38)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 22
        Me.lblAltas.Text = "Altas"
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(426, 38)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 2
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(432, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 7
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(713, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(398, 67)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(39, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(290, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Administrador de Pedidos Virtuales"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = CType(resources.GetObject("pctTitulo.Image"), System.Drawing.Image)
        Me.pctTitulo.Location = New System.Drawing.Point(330, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 67)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'hilo
        '
        '
        'AdministradorPedidosVirtualesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1111, 535)
        Me.Controls.Add(Me.grdPedidosVirtuales)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "AdministradorPedidosVirtualesForm"
        Me.Text = "Administrador de Pedidos Virtuales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdPedidosVirtuales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdPedidosVirtuales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents cmbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpSolicitadaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkSolicitadaCliente As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpSolicitadaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblConfirmacionOTAl As System.Windows.Forms.Label
    Friend WithEvents dtpCapturaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkCaptura As System.Windows.Forms.CheckBox
    Friend WithEvents lblConfirmacionOTDel As System.Windows.Forms.Label
    Friend WithEvents dtpCapturaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFacturacionAl As System.Windows.Forms.Label
    Friend WithEvents dtpProgramacionAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkProgramacioin As System.Windows.Forms.CheckBox
    Friend WithEvents lblFacturacionDel As System.Windows.Forms.Label
    Friend WithEvents Editar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents lblCancelarSalida As System.Windows.Forms.Label
    Friend WithEvents btnCancelarSalida As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPedidoReal As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents lblPedidosContados As System.Windows.Forms.Label
    Friend WithEvents lblSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnVincular As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkAlerta As System.Windows.Forms.CheckBox
    Friend WithEvents lblPedidosAlerta As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents dtpProgramacionDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents hilo As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblFechaConsulta As System.Windows.Forms.Label
End Class
