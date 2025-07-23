<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaSolicitudIncentivoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaSolicitudIncentivoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.gpbFiltroIncentivos = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.cboxPeriodo = New System.Windows.Forms.ComboBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Status = New System.Windows.Forms.Label()
        Me.txtBuscarNombreIncentivo = New System.Windows.Forms.TextBox()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlDiaAdicional = New System.Windows.Forms.Panel()
        Me.btnDiaAdicional = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlNuevaGratificacion = New System.Windows.Forms.Panel()
        Me.btnAltaIncentivo = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnColores = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlSolicitar = New System.Windows.Forms.Panel()
        Me.lblAlertaSinCaja = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCajas = New System.Windows.Forms.ComboBox()
        Me.btnSolicitar = New System.Windows.Forms.Button()
        Me.lblSolicitar = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlPagado = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlCajaChica = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSumaTotal = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdSolicitudes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.gpbFiltroIncentivos.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDiaAdicional.SuspendLayout()
        Me.pnlNuevaGratificacion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnColores.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSolicitar.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbFiltroIncentivos
        '
        Me.gpbFiltroIncentivos.Controls.Add(Me.chkSeleccionarTodo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cboxPeriodo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblPeriodo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbNave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Label2)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbStatus)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Status)
        Me.gpbFiltroIncentivos.Controls.Add(Me.txtBuscarNombreIncentivo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblNombreEmpleado)
        Me.gpbFiltroIncentivos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltroIncentivos.Location = New System.Drawing.Point(0, 59)
        Me.gpbFiltroIncentivos.Name = "gpbFiltroIncentivos"
        Me.gpbFiltroIncentivos.Size = New System.Drawing.Size(1241, 98)
        Me.gpbFiltroIncentivos.TabIndex = 10
        Me.gpbFiltroIncentivos.TabStop = False
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(17, 78)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodo.TabIndex = 50
        Me.chkSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'cboxPeriodo
        '
        Me.cboxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPeriodo.ForeColor = System.Drawing.Color.Black
        Me.cboxPeriodo.FormattingEnabled = True
        Me.cboxPeriodo.Location = New System.Drawing.Point(676, 46)
        Me.cboxPeriodo.Name = "cboxPeriodo"
        Me.cboxPeriodo.Size = New System.Drawing.Size(320, 21)
        Me.cboxPeriodo.TabIndex = 49
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.ForeColor = System.Drawing.Color.Black
        Me.lblPeriodo.Location = New System.Drawing.Point(607, 49)
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
        Me.pnlMinimizarParametros.Controls.Add(Me.Button1)
        Me.pnlMinimizarParametros.Controls.Add(Me.Button2)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1114, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(124, 79)
        Me.pnlMinimizarParametros.TabIndex = 47
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(28, 63)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 46
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(79, 63)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 45
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(83, 30)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 44
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(33, 30)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 43
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.Nomina.Vista.My.Resources.Resources._1373584033_navigate_up1
        Me.Button1.Location = New System.Drawing.Point(63, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 41
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(95, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 42
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(214, 46)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(320, 21)
        Me.cmbNave.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(167, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "* Nave"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.ForeColor = System.Drawing.Color.Black
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"", "TODOS", "SOLICITADO", "AUTORIZADO", "RECHAZADO", "SOLICITADO A CAJA CHICA", "PAGADO"})
        Me.cmbStatus.Location = New System.Drawing.Point(215, 73)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(320, 21)
        Me.cmbStatus.TabIndex = 17
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.ForeColor = System.Drawing.Color.Black
        Me.Status.Location = New System.Drawing.Point(167, 76)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(42, 13)
        Me.Status.TabIndex = 15
        Me.Status.Text = "Estatus"
        '
        'txtBuscarNombreIncentivo
        '
        Me.txtBuscarNombreIncentivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarNombreIncentivo.ForeColor = System.Drawing.Color.Black
        Me.txtBuscarNombreIncentivo.Location = New System.Drawing.Point(676, 73)
        Me.txtBuscarNombreIncentivo.Name = "txtBuscarNombreIncentivo"
        Me.txtBuscarNombreIncentivo.Size = New System.Drawing.Size(320, 20)
        Me.txtBuscarNombreIncentivo.TabIndex = 1
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.AutoSize = True
        Me.lblNombreEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(607, 76)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(64, 13)
        Me.lblNombreEmpleado.TabIndex = 0
        Me.lblNombreEmpleado.Text = "Colaborador"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel2)
        Me.pnlListaPaises.Controls.Add(Me.pnlDiaAdicional)
        Me.pnlListaPaises.Controls.Add(Me.pnlNuevaGratificacion)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1241, 59)
        Me.pnlListaPaises.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnReporte)
        Me.Panel2.Controls.Add(Me.lblImprimir)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(146, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(61, 59)
        Me.Panel2.TabIndex = 21
        '
        'btnReporte
        '
        Me.btnReporte.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnReporte.Location = New System.Drawing.Point(13, 1)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnReporte.TabIndex = 15
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(8, 38)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 16
        Me.lblImprimir.Text = "Imprimir"
        '
        'pnlDiaAdicional
        '
        Me.pnlDiaAdicional.Controls.Add(Me.btnDiaAdicional)
        Me.pnlDiaAdicional.Controls.Add(Me.Label9)
        Me.pnlDiaAdicional.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDiaAdicional.Location = New System.Drawing.Point(75, 0)
        Me.pnlDiaAdicional.Name = "pnlDiaAdicional"
        Me.pnlDiaAdicional.Size = New System.Drawing.Size(71, 59)
        Me.pnlDiaAdicional.TabIndex = 20
        '
        'btnDiaAdicional
        '
        Me.btnDiaAdicional.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnDiaAdicional.Location = New System.Drawing.Point(17, 1)
        Me.btnDiaAdicional.Name = "btnDiaAdicional"
        Me.btnDiaAdicional.Size = New System.Drawing.Size(31, 32)
        Me.btnDiaAdicional.TabIndex = 17
        Me.btnDiaAdicional.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(7, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 26)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Día" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Adicional"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNuevaGratificacion
        '
        Me.pnlNuevaGratificacion.Controls.Add(Me.btnAltaIncentivo)
        Me.pnlNuevaGratificacion.Controls.Add(Me.lblNuevo)
        Me.pnlNuevaGratificacion.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlNuevaGratificacion.Location = New System.Drawing.Point(0, 0)
        Me.pnlNuevaGratificacion.Name = "pnlNuevaGratificacion"
        Me.pnlNuevaGratificacion.Size = New System.Drawing.Size(75, 59)
        Me.pnlNuevaGratificacion.TabIndex = 19
        '
        'btnAltaIncentivo
        '
        Me.btnAltaIncentivo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnAltaIncentivo.Location = New System.Drawing.Point(25, 1)
        Me.btnAltaIncentivo.Name = "btnAltaIncentivo"
        Me.btnAltaIncentivo.Size = New System.Drawing.Size(31, 32)
        Me.btnAltaIncentivo.TabIndex = 1
        Me.btnAltaIncentivo.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(7, 31)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(66, 26)
        Me.lblNuevo.TabIndex = 3
        Me.lblNuevo.Text = "Nueva" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Gratificación"
        Me.lblNuevo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(829, 0)
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
        'pnColores
        '
        Me.pnColores.BackColor = System.Drawing.Color.White
        Me.pnColores.Controls.Add(Me.PictureBox2)
        Me.pnColores.Controls.Add(Me.Label10)
        Me.pnColores.Controls.Add(Me.pnlSolicitar)
        Me.pnColores.Controls.Add(Me.pnlAutorizar)
        Me.pnColores.Controls.Add(Me.Panel4)
        Me.pnColores.Controls.Add(Me.PictureBox1)
        Me.pnColores.Controls.Add(Me.pnlPagado)
        Me.pnColores.Controls.Add(Me.Label8)
        Me.pnColores.Controls.Add(Me.pnlCajaChica)
        Me.pnColores.Controls.Add(Me.Label7)
        Me.pnColores.Controls.Add(Me.lblSumaTotal)
        Me.pnColores.Controls.Add(Me.lblTotal)
        Me.pnColores.Controls.Add(Me.Panel3)
        Me.pnColores.Controls.Add(Me.Panel6)
        Me.pnColores.Controls.Add(Me.Label6)
        Me.pnColores.Controls.Add(Me.Label3)
        Me.pnColores.Controls.Add(Me.Label1)
        Me.pnColores.Controls.Add(Me.Label4)
        Me.pnColores.Controls.Add(Me.Panel5)
        Me.pnColores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnColores.Location = New System.Drawing.Point(0, 465)
        Me.pnColores.Name = "pnColores"
        Me.pnColores.Size = New System.Drawing.Size(1241, 60)
        Me.pnColores.TabIndex = 12
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.Nomina.Vista.My.Resources.Resources.diafestivocalendario
        Me.PictureBox2.Location = New System.Drawing.Point(315, 42)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 38
        Me.PictureBox2.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(333, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(213, 13)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Día Adicional (No se solicitará a caja chica)"
        '
        'pnlSolicitar
        '
        Me.pnlSolicitar.Controls.Add(Me.lblAlertaSinCaja)
        Me.pnlSolicitar.Controls.Add(Me.Label11)
        Me.pnlSolicitar.Controls.Add(Me.cmbCajas)
        Me.pnlSolicitar.Controls.Add(Me.btnSolicitar)
        Me.pnlSolicitar.Controls.Add(Me.lblSolicitar)
        Me.pnlSolicitar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSolicitar.Location = New System.Drawing.Point(773, 0)
        Me.pnlSolicitar.Name = "pnlSolicitar"
        Me.pnlSolicitar.Size = New System.Drawing.Size(300, 60)
        Me.pnlSolicitar.TabIndex = 36
        Me.pnlSolicitar.Visible = False
        '
        'lblAlertaSinCaja
        '
        Me.lblAlertaSinCaja.AutoSize = True
        Me.lblAlertaSinCaja.ForeColor = System.Drawing.Color.Red
        Me.lblAlertaSinCaja.Location = New System.Drawing.Point(53, 12)
        Me.lblAlertaSinCaja.Name = "lblAlertaSinCaja"
        Me.lblAlertaSinCaja.Size = New System.Drawing.Size(168, 13)
        Me.lblAlertaSinCaja.TabIndex = 41
        Me.lblAlertaSinCaja.Text = "No tiene cajas registradas en SAY"
        Me.lblAlertaSinCaja.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(4, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 13)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Caja"
        Me.Label11.Visible = False
        '
        'cmbCajas
        '
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Enabled = False
        Me.cmbCajas.ForeColor = System.Drawing.Color.Black
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Items.AddRange(New Object() {"", "TODOS", "SOLICITADO", "AUTORIZADO", "RECHAZADO", "SOLICITADO A CAJA CHICA", "PAGADO"})
        Me.cmbCajas.Location = New System.Drawing.Point(36, 8)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(211, 21)
        Me.cmbCajas.TabIndex = 40
        Me.cmbCajas.Visible = False
        '
        'btnSolicitar
        '
        Me.btnSolicitar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.prestamos_32
        Me.btnSolicitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSolicitar.Location = New System.Drawing.Point(255, 8)
        Me.btnSolicitar.Name = "btnSolicitar"
        Me.btnSolicitar.Size = New System.Drawing.Size(32, 32)
        Me.btnSolicitar.TabIndex = 4
        Me.btnSolicitar.UseVisualStyleBackColor = True
        Me.btnSolicitar.Visible = False
        '
        'lblSolicitar
        '
        Me.lblSolicitar.AutoSize = True
        Me.lblSolicitar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSolicitar.Location = New System.Drawing.Point(249, 40)
        Me.lblSolicitar.Name = "lblSolicitar"
        Me.lblSolicitar.Size = New System.Drawing.Size(44, 13)
        Me.lblSolicitar.TabIndex = 5
        Me.lblSolicitar.Text = "Solicitar"
        Me.lblSolicitar.Visible = False
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizar)
        Me.pnlAutorizar.Controls.Add(Me.lblCancelar)
        Me.pnlAutorizar.Controls.Add(Me.Label5)
        Me.pnlAutorizar.Controls.Add(Me.btnRechazar)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAutorizar.Location = New System.Drawing.Point(1073, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(116, 60)
        Me.pnlAutorizar.TabIndex = 35
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAutorizar.Location = New System.Drawing.Point(14, 7)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 1
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(60, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(53, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Rechazar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(6, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Autorizar"
        '
        'btnRechazar
        '
        Me.btnRechazar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnRechazar.Location = New System.Drawing.Point(70, 7)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazar.TabIndex = 2
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblCerrar)
        Me.Panel4.Controls.Add(Me.btnCerrar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1189, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(52, 60)
        Me.Panel4.TabIndex = 34
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(5, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 6
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(6, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Nomina.Vista.My.Resources.Resources.cobservacion
        Me.PictureBox1.Location = New System.Drawing.Point(131, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'pnlPagado
        '
        Me.pnlPagado.Location = New System.Drawing.Point(131, 24)
        Me.pnlPagado.Name = "pnlPagado"
        Me.pnlPagado.Size = New System.Drawing.Size(15, 15)
        Me.pnlPagado.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(149, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Pagado"
        '
        'pnlCajaChica
        '
        Me.pnlCajaChica.Location = New System.Drawing.Point(131, 5)
        Me.pnlCajaChica.Name = "pnlCajaChica"
        Me.pnlCajaChica.Size = New System.Drawing.Size(15, 15)
        Me.pnlCajaChica.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(149, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Solicitado a Caja Chica"
        '
        'lblSumaTotal
        '
        Me.lblSumaTotal.AutoSize = True
        Me.lblSumaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumaTotal.Location = New System.Drawing.Point(713, 42)
        Me.lblSumaTotal.Name = "lblSumaTotal"
        Me.lblSumaTotal.Size = New System.Drawing.Size(40, 16)
        Me.lblSumaTotal.TabIndex = 26
        Me.lblSumaTotal.Text = "$ 0.0"
        Me.lblSumaTotal.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(651, 42)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 16)
        Me.lblTotal.TabIndex = 25
        Me.lblTotal.Text = "Total"
        Me.lblTotal.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(19, 43)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 23
        '
        'Panel6
        '
        Me.Panel6.Location = New System.Drawing.Point(19, 5)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(15, 15)
        Me.Panel6.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(37, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Solicitado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(37, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Rechazado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(149, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Cuenta con Observaciones"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(37, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Autorizado"
        '
        'Panel5
        '
        Me.Panel5.Location = New System.Drawing.Point(19, 24)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(15, 15)
        Me.Panel5.TabIndex = 17
        '
        'grdSolicitudes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSolicitudes.DisplayLayout.Appearance = Appearance1
        Me.grdSolicitudes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdSolicitudes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdSolicitudes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdSolicitudes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSolicitudes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdSolicitudes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSolicitudes.Location = New System.Drawing.Point(0, 157)
        Me.grdSolicitudes.Name = "grdSolicitudes"
        Me.grdSolicitudes.Size = New System.Drawing.Size(1241, 308)
        Me.grdSolicitudes.TabIndex = 25
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
        'ListaSolicitudIncentivoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 525)
        Me.Controls.Add(Me.grdSolicitudes)
        Me.Controls.Add(Me.gpbFiltroIncentivos)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.pnColores)
        Me.Name = "ListaSolicitudIncentivoForm"
        Me.Text = "Solicitudes de Gratificación"
        Me.gpbFiltroIncentivos.ResumeLayout(False)
        Me.gpbFiltroIncentivos.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDiaAdicional.ResumeLayout(False)
        Me.pnlDiaAdicional.PerformLayout()
        Me.pnlNuevaGratificacion.ResumeLayout(False)
        Me.pnlNuevaGratificacion.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnColores.ResumeLayout(False)
        Me.pnColores.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSolicitar.ResumeLayout(False)
        Me.pnlSolicitar.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbFiltroIncentivos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Status As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNombreIncentivo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents btnAltaIncentivo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnColores As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblSumaTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cboxPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents pnlPagado As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlCajaChica As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grdSolicitudes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSolicitar As System.Windows.Forms.Panel
    Friend WithEvents pnlAutorizar As System.Windows.Forms.Panel
    Friend WithEvents btnSolicitar As System.Windows.Forms.Button
    Friend WithEvents lblSolicitar As System.Windows.Forms.Label
    Friend WithEvents btnDiaAdicional As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlDiaAdicional As System.Windows.Forms.Panel
    Friend WithEvents pnlNuevaGratificacion As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbCajas As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlertaSinCaja As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As PictureBox
End Class
