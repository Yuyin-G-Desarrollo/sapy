<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Programacion_Administrador_BalanceoSemanal
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlGenerarPreLoteo = New System.Windows.Forms.Panel()
        Me.btnGenerarPreLoteo = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnReenviarCorreoBalanceo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlEnviarCorreo = New System.Windows.Forms.Panel()
        Me.btnCambiosRealizadosBalanceo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlBitacora = New System.Windows.Forms.Panel()
        Me.btnAutorizarBalanceo = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAbrirBalanceo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlObservaciones = New System.Windows.Forms.Panel()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnGenerarBalanceo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlBalanceoEnviadoPPCP = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlBalanceoSolicitaModificaciones = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlBalanceoAutorizado = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdAdmBalanceo = New DevExpress.XtraGrid.GridControl()
        Me.vwAdmBalanceo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblSemanaActual = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.NAñoInicio = New System.Windows.Forms.NumericUpDown()
        Me.lblSemana = New System.Windows.Forms.Label()
        Me.NSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlGenerarPreLoteo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlEnviarCorreo.SuspendLayout()
        Me.pnlBitacora.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlObservaciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdAdmBalanceo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwAdmBalanceo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.NAñoInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.pnlGenerarPreLoteo)
        Me.pnlTitulo.Controls.Add(Me.Panel2)
        Me.pnlTitulo.Controls.Add(Me.pnlEnviarCorreo)
        Me.pnlTitulo.Controls.Add(Me.pnlBitacora)
        Me.pnlTitulo.Controls.Add(Me.pnlAutorizar)
        Me.pnlTitulo.Controls.Add(Me.pnlObservaciones)
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pnlExportar)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1076, 76)
        Me.pnlTitulo.TabIndex = 172
        '
        'pnlGenerarPreLoteo
        '
        Me.pnlGenerarPreLoteo.Controls.Add(Me.btnGenerarPreLoteo)
        Me.pnlGenerarPreLoteo.Controls.Add(Me.Label9)
        Me.pnlGenerarPreLoteo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarPreLoteo.Location = New System.Drawing.Point(561, 0)
        Me.pnlGenerarPreLoteo.Name = "pnlGenerarPreLoteo"
        Me.pnlGenerarPreLoteo.Size = New System.Drawing.Size(101, 76)
        Me.pnlGenerarPreLoteo.TabIndex = 172
        '
        'btnGenerarPreLoteo
        '
        Me.btnGenerarPreLoteo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGenerarPreLoteo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarPreLoteo.Image = Global.Programacion.Vista.My.Resources.Resources.ordenar
        Me.btnGenerarPreLoteo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGenerarPreLoteo.Location = New System.Drawing.Point(33, 12)
        Me.btnGenerarPreLoteo.Name = "btnGenerarPreLoteo"
        Me.btnGenerarPreLoteo.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarPreLoteo.TabIndex = 6
        Me.btnGenerarPreLoteo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(29, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 26)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = "Generar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PreLoteo"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnReenviarCorreoBalanceo)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(467, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(94, 76)
        Me.Panel2.TabIndex = 171
        '
        'btnReenviarCorreoBalanceo
        '
        Me.btnReenviarCorreoBalanceo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReenviarCorreoBalanceo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnReenviarCorreoBalanceo.Image = Global.Programacion.Vista.My.Resources.Resources.Enviar
        Me.btnReenviarCorreoBalanceo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReenviarCorreoBalanceo.Location = New System.Drawing.Point(33, 12)
        Me.btnReenviarCorreoBalanceo.Name = "btnReenviarCorreoBalanceo"
        Me.btnReenviarCorreoBalanceo.Size = New System.Drawing.Size(32, 32)
        Me.btnReenviarCorreoBalanceo.TabIndex = 6
        Me.btnReenviarCorreoBalanceo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(29, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 26)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Enviar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Correo"
        '
        'pnlEnviarCorreo
        '
        Me.pnlEnviarCorreo.Controls.Add(Me.btnCambiosRealizadosBalanceo)
        Me.pnlEnviarCorreo.Controls.Add(Me.Label2)
        Me.pnlEnviarCorreo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEnviarCorreo.Location = New System.Drawing.Point(373, 0)
        Me.pnlEnviarCorreo.Name = "pnlEnviarCorreo"
        Me.pnlEnviarCorreo.Size = New System.Drawing.Size(94, 76)
        Me.pnlEnviarCorreo.TabIndex = 170
        '
        'btnCambiosRealizadosBalanceo
        '
        Me.btnCambiosRealizadosBalanceo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCambiosRealizadosBalanceo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCambiosRealizadosBalanceo.Image = Global.Programacion.Vista.My.Resources.Resources.reasignar
        Me.btnCambiosRealizadosBalanceo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCambiosRealizadosBalanceo.Location = New System.Drawing.Point(30, 12)
        Me.btnCambiosRealizadosBalanceo.Name = "btnCambiosRealizadosBalanceo"
        Me.btnCambiosRealizadosBalanceo.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiosRealizadosBalanceo.TabIndex = 5
        Me.btnCambiosRealizadosBalanceo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(19, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 26)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "  Cambios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Realizados"
        '
        'pnlBitacora
        '
        Me.pnlBitacora.Controls.Add(Me.btnAutorizarBalanceo)
        Me.pnlBitacora.Controls.Add(Me.Label6)
        Me.pnlBitacora.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBitacora.Location = New System.Drawing.Point(279, 0)
        Me.pnlBitacora.Name = "pnlBitacora"
        Me.pnlBitacora.Size = New System.Drawing.Size(94, 76)
        Me.pnlBitacora.TabIndex = 168
        '
        'btnAutorizarBalanceo
        '
        Me.btnAutorizarBalanceo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAutorizarBalanceo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAutorizarBalanceo.Image = Global.Programacion.Vista.My.Resources.Resources.aceptar_321
        Me.btnAutorizarBalanceo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAutorizarBalanceo.Location = New System.Drawing.Point(27, 12)
        Me.btnAutorizarBalanceo.Name = "btnAutorizarBalanceo"
        Me.btnAutorizarBalanceo.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizarBalanceo.TabIndex = 4
        Me.btnAutorizarBalanceo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(19, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Autorizar"
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAbrirBalanceo)
        Me.pnlAutorizar.Controls.Add(Me.Label1)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizar.Location = New System.Drawing.Point(185, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(94, 76)
        Me.pnlAutorizar.TabIndex = 167
        '
        'btnAbrirBalanceo
        '
        Me.btnAbrirBalanceo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAbrirBalanceo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAbrirBalanceo.Image = Global.Programacion.Vista.My.Resources.Resources.importarsicy
        Me.btnAbrirBalanceo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbrirBalanceo.Location = New System.Drawing.Point(29, 12)
        Me.btnAbrirBalanceo.Name = "btnAbrirBalanceo"
        Me.btnAbrirBalanceo.Size = New System.Drawing.Size(32, 32)
        Me.btnAbrirBalanceo.TabIndex = 3
        Me.btnAbrirBalanceo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(7, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Abrir Balanceo"
        '
        'pnlObservaciones
        '
        Me.pnlObservaciones.Controls.Add(Me.btnImprimir)
        Me.pnlObservaciones.Controls.Add(Me.Label10)
        Me.pnlObservaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlObservaciones.Location = New System.Drawing.Point(91, 0)
        Me.pnlObservaciones.Name = "pnlObservaciones"
        Me.pnlObservaciones.Size = New System.Drawing.Size(94, 76)
        Me.pnlObservaciones.TabIndex = 166
        '
        'btnImprimir
        '
        Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.Image = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimir.Location = New System.Drawing.Point(32, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 2
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.Location = New System.Drawing.Point(27, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 116
        Me.Label10.Text = "Imprimir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pbYuyin)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(661, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(415, 76)
        Me.Panel1.TabIndex = 165
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(37, 24)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(304, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Administrador de Balanceo de Naves"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnGenerarBalanceo)
        Me.pnlExportar.Controls.Add(Me.Label8)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(91, 76)
        Me.pnlExportar.TabIndex = 120
        '
        'btnGenerarBalanceo
        '
        Me.btnGenerarBalanceo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGenerarBalanceo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarBalanceo.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
        Me.btnGenerarBalanceo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGenerarBalanceo.Location = New System.Drawing.Point(30, 12)
        Me.btnGenerarBalanceo.Name = "btnGenerarBalanceo"
        Me.btnGenerarBalanceo.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarBalanceo.TabIndex = 1
        Me.btnGenerarBalanceo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(20, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 26)
        Me.Label8.TabIndex = 118
        Me.Label8.Text = " Generar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Balanceo"
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.GroupBox12)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 444)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1076, 63)
        Me.pnlPie.TabIndex = 175
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label4)
        Me.GroupBox12.Controls.Add(Me.pnlBalanceoEnviadoPPCP)
        Me.GroupBox12.Controls.Add(Me.Label5)
        Me.GroupBox12.Controls.Add(Me.pnlBalanceoSolicitaModificaciones)
        Me.GroupBox12.Controls.Add(Me.Label12)
        Me.GroupBox12.Controls.Add(Me.pnlBalanceoAutorizado)
        Me.GroupBox12.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(386, 58)
        Me.GroupBox12.TabIndex = 123
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "ST Balanceo Semanal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(229, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Balanceo Enviado"
        '
        'pnlBalanceoEnviadoPPCP
        '
        Me.pnlBalanceoEnviadoPPCP.BackColor = System.Drawing.Color.Yellow
        Me.pnlBalanceoEnviadoPPCP.ForeColor = System.Drawing.Color.Black
        Me.pnlBalanceoEnviadoPPCP.Location = New System.Drawing.Point(211, 16)
        Me.pnlBalanceoEnviadoPPCP.Name = "pnlBalanceoEnviadoPPCP"
        Me.pnlBalanceoEnviadoPPCP.Size = New System.Drawing.Size(15, 15)
        Me.pnlBalanceoEnviadoPPCP.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(177, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Balanceo Pendiente Modificaciones"
        '
        'pnlBalanceoSolicitaModificaciones
        '
        Me.pnlBalanceoSolicitaModificaciones.BackColor = System.Drawing.Color.OrangeRed
        Me.pnlBalanceoSolicitaModificaciones.ForeColor = System.Drawing.Color.Black
        Me.pnlBalanceoSolicitaModificaciones.Location = New System.Drawing.Point(6, 37)
        Me.pnlBalanceoSolicitaModificaciones.Name = "pnlBalanceoSolicitaModificaciones"
        Me.pnlBalanceoSolicitaModificaciones.Size = New System.Drawing.Size(15, 15)
        Me.pnlBalanceoSolicitaModificaciones.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Balanceo Autorizado"
        '
        'pnlBalanceoAutorizado
        '
        Me.pnlBalanceoAutorizado.BackColor = System.Drawing.Color.Green
        Me.pnlBalanceoAutorizado.ForeColor = System.Drawing.Color.Black
        Me.pnlBalanceoAutorizado.Location = New System.Drawing.Point(6, 16)
        Me.pnlBalanceoAutorizado.Name = "pnlBalanceoAutorizado"
        Me.pnlBalanceoAutorizado.Size = New System.Drawing.Size(15, 15)
        Me.pnlBalanceoAutorizado.TabIndex = 23
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(756, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(320, 63)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(213, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 58
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(218, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 11
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(8, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaActualizacion.TabIndex = 160
        Me.lblUltimaActualizacion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(16, 13)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 159
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(275, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 12
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(274, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdAdmBalanceo
        '
        Me.grdAdmBalanceo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdAdmBalanceo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAdmBalanceo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.grdAdmBalanceo.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdAdmBalanceo.Location = New System.Drawing.Point(0, 207)
        Me.grdAdmBalanceo.MainView = Me.vwAdmBalanceo
        Me.grdAdmBalanceo.Name = "grdAdmBalanceo"
        Me.grdAdmBalanceo.Size = New System.Drawing.Size(1076, 237)
        Me.grdAdmBalanceo.TabIndex = 176
        Me.grdAdmBalanceo.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwAdmBalanceo, Me.GridView3})
        '
        'vwAdmBalanceo
        '
        Me.vwAdmBalanceo.GridControl = Me.grdAdmBalanceo
        Me.vwAdmBalanceo.IndicatorWidth = 30
        Me.vwAdmBalanceo.Name = "vwAdmBalanceo"
        Me.vwAdmBalanceo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwAdmBalanceo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwAdmBalanceo.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwAdmBalanceo.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwAdmBalanceo.OptionsPrint.AllowMultilineHeaders = True
        Me.vwAdmBalanceo.OptionsSelection.MultiSelect = True
        Me.vwAdmBalanceo.OptionsView.ColumnAutoWidth = False
        Me.vwAdmBalanceo.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwAdmBalanceo.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwAdmBalanceo.OptionsView.ShowAutoFilterRow = True
        Me.vwAdmBalanceo.OptionsView.ShowFooter = True
        Me.vwAdmBalanceo.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdAdmBalanceo
        Me.GridView3.Name = "GridView3"
        '
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(1008, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(68, 27)
        Me.pnlBotonesExpander.TabIndex = 1
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(34, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 13
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(7, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 12
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 15)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Semana Actual:"
        '
        'lblSemanaActual
        '
        Me.lblSemanaActual.AutoSize = True
        Me.lblSemanaActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemanaActual.Location = New System.Drawing.Point(100, 6)
        Me.lblSemanaActual.Name = "lblSemanaActual"
        Me.lblSemanaActual.Size = New System.Drawing.Size(0, 15)
        Me.lblSemanaActual.TabIndex = 67
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.lblSemanaActual)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.pnlBotonesExpander)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 76)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1076, 27)
        Me.Panel6.TabIndex = 173
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(81, 43)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(165, 21)
        Me.cmbNave.TabIndex = 8
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(23, 47)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(39, 13)
        Me.lblNave.TabIndex = 39
        Me.lblNave.Text = "Nave :"
        '
        'NAñoInicio
        '
        Me.NAñoInicio.Location = New System.Drawing.Point(178, 70)
        Me.NAñoInicio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.NAñoInicio.Minimum = New Decimal(New Integer() {2021, 0, 0, 0})
        Me.NAñoInicio.Name = "NAñoInicio"
        Me.NAñoInicio.Size = New System.Drawing.Size(68, 20)
        Me.NAñoInicio.TabIndex = 10
        Me.NAñoInicio.Value = New Decimal(New Integer() {2021, 0, 0, 0})
        '
        'lblSemana
        '
        Me.lblSemana.AutoSize = True
        Me.lblSemana.Location = New System.Drawing.Point(23, 74)
        Me.lblSemana.Name = "lblSemana"
        Me.lblSemana.Size = New System.Drawing.Size(52, 13)
        Me.lblSemana.TabIndex = 71
        Me.lblSemana.Text = "Semana :"
        '
        'NSemanaInicio
        '
        Me.NSemanaInicio.Location = New System.Drawing.Point(81, 70)
        Me.NSemanaInicio.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.NSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NSemanaInicio.Name = "NSemanaInicio"
        Me.NSemanaInicio.Size = New System.Drawing.Size(74, 20)
        Me.NSemanaInicio.TabIndex = 9
        Me.NSemanaInicio.Value = New Decimal(New Integer() {18, 0, 0, 0})
        '
        'cmbGrupo
        '
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Items.AddRange(New Object() {"TODAS", "RVO", "FVO"})
        Me.cmbGrupo.Location = New System.Drawing.Point(81, 16)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(165, 21)
        Me.cmbGrupo.TabIndex = 7
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(23, 19)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(42, 13)
        Me.lblGrupo.TabIndex = 76
        Me.lblGrupo.Text = "Grupo :"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.lblGrupo)
        Me.pnlFiltros.Controls.Add(Me.cmbGrupo)
        Me.pnlFiltros.Controls.Add(Me.NSemanaInicio)
        Me.pnlFiltros.Controls.Add(Me.lblSemana)
        Me.pnlFiltros.Controls.Add(Me.NAñoInicio)
        Me.pnlFiltros.Controls.Add(Me.lblNave)
        Me.pnlFiltros.Controls.Add(Me.cmbNave)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 103)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1076, 104)
        Me.pnlFiltros.TabIndex = 174
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(332, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 76)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 91
        Me.pbYuyin.TabStop = False
        '
        'Programacion_Administrador_BalanceoSemanal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 507)
        Me.Controls.Add(Me.grdAdmBalanceo)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "Programacion_Administrador_BalanceoSemanal"
        Me.Text = "Administrador de Balanceo de Naves"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlGenerarPreLoteo.ResumeLayout(False)
        Me.pnlGenerarPreLoteo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlEnviarCorreo.ResumeLayout(False)
        Me.pnlEnviarCorreo.PerformLayout()
        Me.pnlBitacora.ResumeLayout(False)
        Me.pnlBitacora.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.pnlObservaciones.ResumeLayout(False)
        Me.pnlObservaciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdAdmBalanceo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwAdmBalanceo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.NAñoInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlEnviarCorreo As Panel
    Friend WithEvents btnReenviarCorreoBalanceo As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCambiosRealizadosBalanceo As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlBitacora As Panel
    Friend WithEvents pnlAutorizar As Panel
    Friend WithEvents btnAutorizarBalanceo As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlObservaciones As Panel
    Friend WithEvents btnAbrirBalanceo As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlBalanceoEnviadoPPCP As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlBalanceoSolicitaModificaciones As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents pnlBalanceoAutorizado As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdAdmBalanceo As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwAdmBalanceo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnGenerarBalanceo As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents lblSemanaActual As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents lblNave As Label
    Friend WithEvents NAñoInicio As NumericUpDown
    Friend WithEvents lblSemana As Label
    Friend WithEvents NSemanaInicio As NumericUpDown
    Friend WithEvents cmbGrupo As ComboBox
    Friend WithEvents lblGrupo As Label
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents pnlGenerarPreLoteo As Panel
    Friend WithEvents btnGenerarPreLoteo As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents pbYuyin As PictureBox
End Class
