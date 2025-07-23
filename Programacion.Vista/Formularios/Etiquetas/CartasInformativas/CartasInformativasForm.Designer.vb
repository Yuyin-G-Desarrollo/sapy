<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CartasInformativasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CartasInformativasForm))
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlVerFolios = New System.Windows.Forms.Panel()
        Me.btnVerFolios = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlVerSolicitudes = New System.Windows.Forms.Panel()
        Me.btnVerSolicitudes = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlSolicitarCarta = New System.Windows.Forms.Panel()
        Me.btnSolicitarCarta = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlValPPCP = New System.Windows.Forms.Panel()
        Me.btnRecibirPPCP = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlEnvPPCP = New System.Windows.Forms.Panel()
        Me.btnEnviarPPCP = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlRegistrar = New System.Windows.Forms.Panel()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.lblRegistrar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblParesProceso = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblActualizacion = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdPedidos = New DevExpress.XtraGrid.GridControl()
        Me.grdVPedidos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.dtpFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaAl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.dtpFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaDel = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlVerFolios.SuspendLayout()
        Me.pnlVerSolicitudes.SuspendLayout()
        Me.pnlSolicitarCarta.SuspendLayout()
        Me.pnlValPPCP.SuspendLayout()
        Me.pnlEnvPPCP.SuspendLayout()
        Me.pnlRegistrar.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlVerFolios)
        Me.pnlCabecera.Controls.Add(Me.pnlVerSolicitudes)
        Me.pnlCabecera.Controls.Add(Me.pnlSolicitarCarta)
        Me.pnlCabecera.Controls.Add(Me.pnlValPPCP)
        Me.pnlCabecera.Controls.Add(Me.pnlEnvPPCP)
        Me.pnlCabecera.Controls.Add(Me.pnlRegistrar)
        Me.pnlCabecera.Controls.Add(Me.pnlHeader)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(806, 72)
        Me.pnlCabecera.TabIndex = 32
        '
        'pnlVerFolios
        '
        Me.pnlVerFolios.Controls.Add(Me.btnVerFolios)
        Me.pnlVerFolios.Controls.Add(Me.Label9)
        Me.pnlVerFolios.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVerFolios.Location = New System.Drawing.Point(360, 0)
        Me.pnlVerFolios.Name = "pnlVerFolios"
        Me.pnlVerFolios.Size = New System.Drawing.Size(72, 72)
        Me.pnlVerFolios.TabIndex = 13
        Me.pnlVerFolios.Visible = False
        '
        'btnVerFolios
        '
        Me.btnVerFolios.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVerFolios.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVerFolios.Image = Global.Programacion.Vista.My.Resources.Resources.catalogos_32
        Me.btnVerFolios.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVerFolios.Location = New System.Drawing.Point(22, 9)
        Me.btnVerFolios.Name = "btnVerFolios"
        Me.btnVerFolios.Size = New System.Drawing.Size(32, 32)
        Me.btnVerFolios.TabIndex = 12
        Me.btnVerFolios.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(21, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 26)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "  Ver " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Folios"
        '
        'pnlVerSolicitudes
        '
        Me.pnlVerSolicitudes.Controls.Add(Me.btnVerSolicitudes)
        Me.pnlVerSolicitudes.Controls.Add(Me.Label5)
        Me.pnlVerSolicitudes.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVerSolicitudes.Location = New System.Drawing.Point(288, 0)
        Me.pnlVerSolicitudes.Name = "pnlVerSolicitudes"
        Me.pnlVerSolicitudes.Size = New System.Drawing.Size(72, 72)
        Me.pnlVerSolicitudes.TabIndex = 11
        '
        'btnVerSolicitudes
        '
        Me.btnVerSolicitudes.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnVerSolicitudes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnVerSolicitudes.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnVerSolicitudes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnVerSolicitudes.Location = New System.Drawing.Point(22, 9)
        Me.btnVerSolicitudes.Name = "btnVerSolicitudes"
        Me.btnVerSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnVerSolicitudes.TabIndex = 12
        Me.btnVerSolicitudes.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(8, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 26)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "     Ver " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Solicitudes"
        '
        'pnlSolicitarCarta
        '
        Me.pnlSolicitarCarta.Controls.Add(Me.btnSolicitarCarta)
        Me.pnlSolicitarCarta.Controls.Add(Me.Label4)
        Me.pnlSolicitarCarta.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSolicitarCarta.Enabled = False
        Me.pnlSolicitarCarta.Location = New System.Drawing.Point(216, 0)
        Me.pnlSolicitarCarta.Name = "pnlSolicitarCarta"
        Me.pnlSolicitarCarta.Size = New System.Drawing.Size(72, 72)
        Me.pnlSolicitarCarta.TabIndex = 10
        '
        'btnSolicitarCarta
        '
        Me.btnSolicitarCarta.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSolicitarCarta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnSolicitarCarta.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnSolicitarCarta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSolicitarCarta.Location = New System.Drawing.Point(22, 9)
        Me.btnSolicitarCarta.Name = "btnSolicitarCarta"
        Me.btnSolicitarCarta.Size = New System.Drawing.Size(32, 32)
        Me.btnSolicitarCarta.TabIndex = 12
        Me.btnSolicitarCarta.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(15, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Solicitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Carta"
        '
        'pnlValPPCP
        '
        Me.pnlValPPCP.Controls.Add(Me.btnRecibirPPCP)
        Me.pnlValPPCP.Controls.Add(Me.Label3)
        Me.pnlValPPCP.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlValPPCP.Enabled = False
        Me.pnlValPPCP.Location = New System.Drawing.Point(144, 0)
        Me.pnlValPPCP.Name = "pnlValPPCP"
        Me.pnlValPPCP.Size = New System.Drawing.Size(72, 72)
        Me.pnlValPPCP.TabIndex = 9
        '
        'btnRecibirPPCP
        '
        Me.btnRecibirPPCP.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRecibirPPCP.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnRecibirPPCP.Image = Global.Programacion.Vista.My.Resources.Resources.aceptar_321
        Me.btnRecibirPPCP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRecibirPPCP.Location = New System.Drawing.Point(22, 9)
        Me.btnRecibirPPCP.Name = "btnRecibirPPCP"
        Me.btnRecibirPPCP.Size = New System.Drawing.Size(32, 32)
        Me.btnRecibirPPCP.TabIndex = 12
        Me.btnRecibirPPCP.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(19, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 26)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Recibir" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " PPCP"
        '
        'pnlEnvPPCP
        '
        Me.pnlEnvPPCP.Controls.Add(Me.btnEnviarPPCP)
        Me.pnlEnvPPCP.Controls.Add(Me.Label2)
        Me.pnlEnvPPCP.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEnvPPCP.Enabled = False
        Me.pnlEnvPPCP.Location = New System.Drawing.Point(72, 0)
        Me.pnlEnvPPCP.Name = "pnlEnvPPCP"
        Me.pnlEnvPPCP.Size = New System.Drawing.Size(72, 72)
        Me.pnlEnvPPCP.TabIndex = 8
        '
        'btnEnviarPPCP
        '
        Me.btnEnviarPPCP.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEnviarPPCP.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEnviarPPCP.Image = Global.Programacion.Vista.My.Resources.Resources.Enviar
        Me.btnEnviarPPCP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnviarPPCP.Location = New System.Drawing.Point(22, 9)
        Me.btnEnviarPPCP.Name = "btnEnviarPPCP"
        Me.btnEnviarPPCP.Size = New System.Drawing.Size(32, 32)
        Me.btnEnviarPPCP.TabIndex = 12
        Me.btnEnviarPPCP.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(15, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 26)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Enviar a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  PPCP"
        '
        'pnlRegistrar
        '
        Me.pnlRegistrar.Controls.Add(Me.btnRegistrar)
        Me.pnlRegistrar.Controls.Add(Me.lblRegistrar)
        Me.pnlRegistrar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRegistrar.Enabled = False
        Me.pnlRegistrar.Location = New System.Drawing.Point(0, 0)
        Me.pnlRegistrar.Name = "pnlRegistrar"
        Me.pnlRegistrar.Size = New System.Drawing.Size(72, 72)
        Me.pnlRegistrar.TabIndex = 7
        '
        'btnRegistrar
        '
        Me.btnRegistrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRegistrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnRegistrar.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnRegistrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRegistrar.Location = New System.Drawing.Point(22, 9)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegistrar.TabIndex = 12
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'lblRegistrar
        '
        Me.lblRegistrar.AutoSize = True
        Me.lblRegistrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRegistrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRegistrar.Location = New System.Drawing.Point(12, 41)
        Me.lblRegistrar.Name = "lblRegistrar"
        Me.lblRegistrar.Size = New System.Drawing.Size(49, 13)
        Me.lblRegistrar.TabIndex = 13
        Me.lblRegistrar.Text = "Registrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Panel2)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(453, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(353, 72)
        Me.pnlHeader.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEncabezado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(23, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 72)
        Me.Panel2.TabIndex = 46
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(14, 17)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(180, 40)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Cartas Informativas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pedidos Por Entregar"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(285, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 72)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPie.Controls.Add(Me.lblParesProceso)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.Panel5)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 366)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(806, 59)
        Me.pnlPie.TabIndex = 70
        '
        'lblParesProceso
        '
        Me.lblParesProceso.AutoSize = True
        Me.lblParesProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesProceso.ForeColor = System.Drawing.Color.Black
        Me.lblParesProceso.Location = New System.Drawing.Point(37, 12)
        Me.lblParesProceso.Name = "lblParesProceso"
        Me.lblParesProceso.Size = New System.Drawing.Size(75, 16)
        Me.lblParesProceso.TabIndex = 122
        Me.lblParesProceso.Text = "Registros"
        Me.lblParesProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(37, 28)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalRegistros.TabIndex = 121
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.lblActualizacion)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(405, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(236, 59)
        Me.Panel5.TabIndex = 81
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Ultima actualización:"
        '
        'lblActualizacion
        '
        Me.lblActualizacion.AutoSize = True
        Me.lblActualizacion.Location = New System.Drawing.Point(127, 23)
        Me.lblActualizacion.Name = "lblActualizacion"
        Me.lblActualizacion.Size = New System.Drawing.Size(16, 13)
        Me.lblActualizacion.TabIndex = 80
        Me.lblActualizacion.Text = "..."
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.lblCerrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(641, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 59)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(106, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(106, 35)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 5
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdPedidos
        '
        Me.grdPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidos.Location = New System.Drawing.Point(0, 0)
        Me.grdPedidos.MainView = Me.grdVPedidos
        Me.grdPedidos.Name = "grdPedidos"
        Me.grdPedidos.Size = New System.Drawing.Size(806, 230)
        Me.grdPedidos.TabIndex = 164
        Me.grdPedidos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVPedidos})
        '
        'grdVPedidos
        '
        Me.grdVPedidos.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVPedidos.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdVPedidos.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdVPedidos.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdVPedidos.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVPedidos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdVPedidos.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdVPedidos.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdVPedidos.GridControl = Me.grdPedidos
        Me.grdVPedidos.IndicatorWidth = 30
        Me.grdVPedidos.Name = "grdVPedidos"
        Me.grdVPedidos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVPedidos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVPedidos.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdVPedidos.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdVPedidos.OptionsPrint.AllowMultilineHeaders = True
        Me.grdVPedidos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVPedidos.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdVPedidos.OptionsView.ShowAutoFilterRow = True
        Me.grdVPedidos.OptionsView.ShowFooter = True
        Me.grdVPedidos.OptionsView.ShowGroupPanel = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.cboEstatus)
        Me.Panel3.Controls.Add(Me.dtpFechaAl)
        Me.Panel3.Controls.Add(Me.lblFechaAl)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.chkFechas)
        Me.Panel3.Controls.Add(Me.dtpFechaDel)
        Me.Panel3.Controls.Add(Me.lblFechaDel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 72)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(806, 64)
        Me.Panel3.TabIndex = 73
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(401, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Estatus:"
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Location = New System.Drawing.Point(452, 3)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(205, 21)
        Me.cboEstatus.TabIndex = 19
        '
        'dtpFechaAl
        '
        Me.dtpFechaAl.Enabled = False
        Me.dtpFechaAl.Location = New System.Drawing.Point(182, 30)
        Me.dtpFechaAl.Name = "dtpFechaAl"
        Me.dtpFechaAl.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaAl.TabIndex = 18
        '
        'lblFechaAl
        '
        Me.lblFechaAl.AutoSize = True
        Me.lblFechaAl.Enabled = False
        Me.lblFechaAl.Location = New System.Drawing.Point(157, 36)
        Me.lblFechaAl.Name = "lblFechaAl"
        Me.lblFechaAl.Size = New System.Drawing.Size(19, 13)
        Me.lblFechaAl.TabIndex = 17
        Me.lblFechaAl.Text = "Al:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(686, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(118, 62)
        Me.Panel1.TabIndex = 16
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(66, 10)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 14
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(63, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Mostrar"
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(26, 5)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(111, 17)
        Me.chkFechas.TabIndex = 14
        Me.chkFechas.Text = "Fecha de Entrega"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'dtpFechaDel
        '
        Me.dtpFechaDel.Enabled = False
        Me.dtpFechaDel.Location = New System.Drawing.Point(182, 4)
        Me.dtpFechaDel.Name = "dtpFechaDel"
        Me.dtpFechaDel.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaDel.TabIndex = 13
        '
        'lblFechaDel
        '
        Me.lblFechaDel.AutoSize = True
        Me.lblFechaDel.Enabled = False
        Me.lblFechaDel.Location = New System.Drawing.Point(150, 10)
        Me.lblFechaDel.Name = "lblFechaDel"
        Me.lblFechaDel.Size = New System.Drawing.Size(26, 13)
        Me.lblFechaDel.TabIndex = 11
        Me.lblFechaDel.Text = "Del:"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdPedidos)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 136)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(806, 230)
        Me.Panel4.TabIndex = 74
        '
        'CartasInformativasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 425)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "CartasInformativasForm"
        Me.Text = "Cartas Informativas"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlVerFolios.ResumeLayout(False)
        Me.pnlVerFolios.PerformLayout()
        Me.pnlVerSolicitudes.ResumeLayout(False)
        Me.pnlVerSolicitudes.PerformLayout()
        Me.pnlSolicitarCarta.ResumeLayout(False)
        Me.pnlSolicitarCarta.PerformLayout()
        Me.pnlValPPCP.ResumeLayout(False)
        Me.pnlValPPCP.PerformLayout()
        Me.pnlEnvPPCP.ResumeLayout(False)
        Me.pnlEnvPPCP.PerformLayout()
        Me.pnlRegistrar.ResumeLayout(False)
        Me.pnlRegistrar.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlVerSolicitudes As Panel
    Friend WithEvents btnVerSolicitudes As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlSolicitarCarta As Panel
    Friend WithEvents btnSolicitarCarta As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlValPPCP As Panel
    Friend WithEvents btnRecibirPPCP As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlEnvPPCP As Panel
    Friend WithEvents btnEnviarPPCP As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlRegistrar As Panel
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents lblRegistrar As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdPedidos As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVPedidos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dtpFechaDel As DateTimePicker
    Friend WithEvents lblFechaDel As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents chkFechas As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaAl As DateTimePicker
    Friend WithEvents lblFechaAl As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblActualizacion As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents pnlVerFolios As Panel
    Friend WithEvents btnVerFolios As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblParesProceso As Label
    Friend WithEvents lblTotalRegistros As Label
End Class
