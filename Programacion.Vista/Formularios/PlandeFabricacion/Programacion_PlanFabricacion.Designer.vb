<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Programacion_PlanFabricacion
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
        Me.pnlEnviarCorreo = New System.Windows.Forms.Panel()
        Me.btnReenviarCorreo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlCambiosRealizados = New System.Windows.Forms.Panel()
        Me.btnCambiosRealizados = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlBitacora = New System.Windows.Forms.Panel()
        Me.btnBitacora = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlObservaciones = New System.Windows.Forms.Panel()
        Me.btnObservaciones = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblSemanaActual = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlBotonesExpander = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.NSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.lblSemana = New System.Windows.Forms.Label()
        Me.NAñoInicio = New System.Windows.Forms.NumericUpDown()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlEnviadoPPCP = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlSolicitaModificaciones = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlPlanAutorizado = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdPlanFabricacion = New DevExpress.XtraGrid.GridControl()
        Me.vwPlanFabricacion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEnviarCorreo.SuspendLayout()
        Me.pnlCambiosRealizados.SuspendLayout()
        Me.pnlBitacora.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlObservaciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlBotonesExpander.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        CType(Me.NSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NAñoInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdPlanFabricacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwPlanFabricacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.pnlEnviarCorreo)
        Me.pnlTitulo.Controls.Add(Me.pnlCambiosRealizados)
        Me.pnlTitulo.Controls.Add(Me.pnlBitacora)
        Me.pnlTitulo.Controls.Add(Me.pnlAutorizar)
        Me.pnlTitulo.Controls.Add(Me.pnlObservaciones)
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pnlExportar)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1110, 76)
        Me.pnlTitulo.TabIndex = 171
        '
        'pnlEnviarCorreo
        '
        Me.pnlEnviarCorreo.Controls.Add(Me.btnReenviarCorreo)
        Me.pnlEnviarCorreo.Controls.Add(Me.Label3)
        Me.pnlEnviarCorreo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEnviarCorreo.Location = New System.Drawing.Point(467, 0)
        Me.pnlEnviarCorreo.Name = "pnlEnviarCorreo"
        Me.pnlEnviarCorreo.Size = New System.Drawing.Size(94, 76)
        Me.pnlEnviarCorreo.TabIndex = 170
        '
        'btnReenviarCorreo
        '
        Me.btnReenviarCorreo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnReenviarCorreo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnReenviarCorreo.Image = Global.Programacion.Vista.My.Resources.Resources.Enviar
        Me.btnReenviarCorreo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReenviarCorreo.Location = New System.Drawing.Point(30, 10)
        Me.btnReenviarCorreo.Name = "btnReenviarCorreo"
        Me.btnReenviarCorreo.Size = New System.Drawing.Size(32, 32)
        Me.btnReenviarCorreo.TabIndex = 115
        Me.btnReenviarCorreo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(26, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 26)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Enviar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Correo"
        '
        'pnlCambiosRealizados
        '
        Me.pnlCambiosRealizados.Controls.Add(Me.btnCambiosRealizados)
        Me.pnlCambiosRealizados.Controls.Add(Me.Label2)
        Me.pnlCambiosRealizados.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCambiosRealizados.Location = New System.Drawing.Point(373, 0)
        Me.pnlCambiosRealizados.Name = "pnlCambiosRealizados"
        Me.pnlCambiosRealizados.Size = New System.Drawing.Size(94, 76)
        Me.pnlCambiosRealizados.TabIndex = 169
        '
        'btnCambiosRealizados
        '
        Me.btnCambiosRealizados.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCambiosRealizados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCambiosRealizados.Image = Global.Programacion.Vista.My.Resources.Resources.reasignar
        Me.btnCambiosRealizados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCambiosRealizados.Location = New System.Drawing.Point(30, 10)
        Me.btnCambiosRealizados.Name = "btnCambiosRealizados"
        Me.btnCambiosRealizados.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiosRealizados.TabIndex = 115
        Me.btnCambiosRealizados.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(19, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 26)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "  Cambios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Realizados"
        '
        'pnlBitacora
        '
        Me.pnlBitacora.Controls.Add(Me.btnBitacora)
        Me.pnlBitacora.Controls.Add(Me.Label11)
        Me.pnlBitacora.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBitacora.Location = New System.Drawing.Point(279, 0)
        Me.pnlBitacora.Name = "pnlBitacora"
        Me.pnlBitacora.Size = New System.Drawing.Size(94, 76)
        Me.pnlBitacora.TabIndex = 168
        '
        'btnBitacora
        '
        Me.btnBitacora.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnBitacora.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnBitacora.Image = Global.Programacion.Vista.My.Resources.Resources.copiar_horario_32
        Me.btnBitacora.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBitacora.Location = New System.Drawing.Point(32, 10)
        Me.btnBitacora.Name = "btnBitacora"
        Me.btnBitacora.Size = New System.Drawing.Size(32, 32)
        Me.btnBitacora.TabIndex = 115
        Me.btnBitacora.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label11.Location = New System.Drawing.Point(25, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "Bitácora"
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizar)
        Me.pnlAutorizar.Controls.Add(Me.Label6)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizar.Location = New System.Drawing.Point(185, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(94, 76)
        Me.pnlAutorizar.TabIndex = 167
        '
        'btnAutorizar
        '
        Me.btnAutorizar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAutorizar.Image = Global.Programacion.Vista.My.Resources.Resources.aceptar_321
        Me.btnAutorizar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAutorizar.Location = New System.Drawing.Point(32, 10)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 115
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(24, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Autorizar"
        '
        'pnlObservaciones
        '
        Me.pnlObservaciones.Controls.Add(Me.btnObservaciones)
        Me.pnlObservaciones.Controls.Add(Me.Label1)
        Me.pnlObservaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlObservaciones.Location = New System.Drawing.Point(91, 0)
        Me.pnlObservaciones.Name = "pnlObservaciones"
        Me.pnlObservaciones.Size = New System.Drawing.Size(94, 76)
        Me.pnlObservaciones.TabIndex = 166
        '
        'btnObservaciones
        '
        Me.btnObservaciones.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnObservaciones.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnObservaciones.Image = Global.Programacion.Vista.My.Resources.Resources.importarsicy
        Me.btnObservaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnObservaciones.Location = New System.Drawing.Point(32, 10)
        Me.btnObservaciones.Name = "btnObservaciones"
        Me.btnObservaciones.Size = New System.Drawing.Size(32, 32)
        Me.btnObservaciones.TabIndex = 115
        Me.btnObservaciones.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(22, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Abrir Plan"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(667, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(443, 76)
        Me.Panel1.TabIndex = 165
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(184, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(167, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Plan de Fabricación"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.Label10)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(91, 76)
        Me.pnlExportar.TabIndex = 120
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(29, 10)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 117
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label10.Location = New System.Drawing.Point(24, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 116
        Me.Label10.Text = "Imprimir"
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
        Me.Panel6.Size = New System.Drawing.Size(1110, 27)
        Me.Panel6.TabIndex = 172
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
        'pnlBotonesExpander
        '
        Me.pnlBotonesExpander.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesExpander.Controls.Add(Me.btnArriba)
        Me.pnlBotonesExpander.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesExpander.Location = New System.Drawing.Point(1046, 0)
        Me.pnlBotonesExpander.Name = "pnlBotonesExpander"
        Me.pnlBotonesExpander.Size = New System.Drawing.Size(64, 27)
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
        Me.pnlFiltros.Size = New System.Drawing.Size(1110, 104)
        Me.pnlFiltros.TabIndex = 173
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(334, 29)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(42, 13)
        Me.lblGrupo.TabIndex = 76
        Me.lblGrupo.Text = "Grupo :"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Items.AddRange(New Object() {"TODAS", "RVO", "FVO"})
        Me.cmbGrupo.Location = New System.Drawing.Point(382, 25)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(62, 21)
        Me.cmbGrupo.TabIndex = 5
        '
        'NSemanaInicio
        '
        Me.NSemanaInicio.Location = New System.Drawing.Point(81, 58)
        Me.NSemanaInicio.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.NSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NSemanaInicio.Name = "NSemanaInicio"
        Me.NSemanaInicio.Size = New System.Drawing.Size(50, 20)
        Me.NSemanaInicio.TabIndex = 3
        Me.NSemanaInicio.Value = New Decimal(New Integer() {18, 0, 0, 0})
        '
        'lblSemana
        '
        Me.lblSemana.AutoSize = True
        Me.lblSemana.Location = New System.Drawing.Point(12, 60)
        Me.lblSemana.Name = "lblSemana"
        Me.lblSemana.Size = New System.Drawing.Size(52, 13)
        Me.lblSemana.TabIndex = 71
        Me.lblSemana.Text = "Semana :"
        '
        'NAñoInicio
        '
        Me.NAñoInicio.Location = New System.Drawing.Point(137, 58)
        Me.NAñoInicio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.NAñoInicio.Minimum = New Decimal(New Integer() {2021, 0, 0, 0})
        Me.NAñoInicio.Name = "NAñoInicio"
        Me.NAñoInicio.Size = New System.Drawing.Size(61, 20)
        Me.NAñoInicio.TabIndex = 4
        Me.NAñoInicio.Value = New Decimal(New Integer() {2021, 0, 0, 0})
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(12, 29)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(39, 13)
        Me.lblNave.TabIndex = 39
        Me.lblNave.Text = "Nave :"
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(81, 25)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(228, 21)
        Me.cmbNave.TabIndex = 1
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.GroupBox12)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 441)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1110, 63)
        Me.pnlPie.TabIndex = 174
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label4)
        Me.GroupBox12.Controls.Add(Me.pnlEnviadoPPCP)
        Me.GroupBox12.Controls.Add(Me.Label5)
        Me.GroupBox12.Controls.Add(Me.pnlSolicitaModificaciones)
        Me.GroupBox12.Controls.Add(Me.Label12)
        Me.GroupBox12.Controls.Add(Me.pnlPlanAutorizado)
        Me.GroupBox12.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(423, 55)
        Me.GroupBox12.TabIndex = 123
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Status Plan de Fabricación (ST)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(229, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 124
        Me.Label4.Text = "Enviado por PPCP"
        '
        'pnlEnviadoPPCP
        '
        Me.pnlEnviadoPPCP.BackColor = System.Drawing.Color.Yellow
        Me.pnlEnviadoPPCP.ForeColor = System.Drawing.Color.Black
        Me.pnlEnviadoPPCP.Location = New System.Drawing.Point(211, 16)
        Me.pnlEnviadoPPCP.Name = "pnlEnviadoPPCP"
        Me.pnlEnviadoPPCP.Size = New System.Drawing.Size(15, 15)
        Me.pnlEnviadoPPCP.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Solicita Modificaciones"
        '
        'pnlSolicitaModificaciones
        '
        Me.pnlSolicitaModificaciones.BackColor = System.Drawing.Color.OrangeRed
        Me.pnlSolicitaModificaciones.ForeColor = System.Drawing.Color.Black
        Me.pnlSolicitaModificaciones.Location = New System.Drawing.Point(6, 37)
        Me.pnlSolicitaModificaciones.Name = "pnlSolicitaModificaciones"
        Me.pnlSolicitaModificaciones.Size = New System.Drawing.Size(15, 15)
        Me.pnlSolicitaModificaciones.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Plan Autorizado"
        '
        'pnlPlanAutorizado
        '
        Me.pnlPlanAutorizado.BackColor = System.Drawing.Color.Green
        Me.pnlPlanAutorizado.ForeColor = System.Drawing.Color.Black
        Me.pnlPlanAutorizado.Location = New System.Drawing.Point(6, 16)
        Me.pnlPlanAutorizado.Name = "pnlPlanAutorizado"
        Me.pnlPlanAutorizado.Size = New System.Drawing.Size(15, 15)
        Me.pnlPlanAutorizado.TabIndex = 23
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
        Me.pnlDatosBotones.Location = New System.Drawing.Point(790, 0)
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
        Me.btnMostrar.TabIndex = 14
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
        Me.btnCerrar.TabIndex = 16
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
        'grdPlanFabricacion
        '
        Me.grdPlanFabricacion.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdPlanFabricacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPlanFabricacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.RelationName = "Level1"
        Me.grdPlanFabricacion.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdPlanFabricacion.Location = New System.Drawing.Point(0, 207)
        Me.grdPlanFabricacion.MainView = Me.vwPlanFabricacion
        Me.grdPlanFabricacion.Name = "grdPlanFabricacion"
        Me.grdPlanFabricacion.Size = New System.Drawing.Size(1110, 234)
        Me.grdPlanFabricacion.TabIndex = 175
        Me.grdPlanFabricacion.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwPlanFabricacion, Me.GridView3})
        '
        'vwPlanFabricacion
        '
        Me.vwPlanFabricacion.GridControl = Me.grdPlanFabricacion
        Me.vwPlanFabricacion.IndicatorWidth = 30
        Me.vwPlanFabricacion.Name = "vwPlanFabricacion"
        Me.vwPlanFabricacion.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwPlanFabricacion.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwPlanFabricacion.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwPlanFabricacion.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.vwPlanFabricacion.OptionsPrint.AllowMultilineHeaders = True
        Me.vwPlanFabricacion.OptionsSelection.MultiSelect = True
        Me.vwPlanFabricacion.OptionsView.ColumnAutoWidth = False
        Me.vwPlanFabricacion.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwPlanFabricacion.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.vwPlanFabricacion.OptionsView.ShowAutoFilterRow = True
        Me.vwPlanFabricacion.OptionsView.ShowFooter = True
        Me.vwPlanFabricacion.OptionsView.ShowGroupPanel = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdPlanFabricacion
        Me.GridView3.Name = "GridView3"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(381, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 76)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'Programacion_PlanFabricacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 504)
        Me.Controls.Add(Me.grdPlanFabricacion)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Name = "Programacion_PlanFabricacion"
        Me.Text = "Plan de Fabricación"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlEnviarCorreo.ResumeLayout(False)
        Me.pnlEnviarCorreo.PerformLayout()
        Me.pnlCambiosRealizados.ResumeLayout(False)
        Me.pnlCambiosRealizados.PerformLayout()
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
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlBotonesExpander.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        CType(Me.NSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NAñoInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdPlanFabricacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwPlanFabricacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlObservaciones As Panel
    Friend WithEvents btnObservaciones As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents pnlBotonesExpander As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblUltimaActualizacion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdPlanFabricacion As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwPlanFabricacion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents lblNave As Label
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlSolicitaModificaciones As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents pnlPlanAutorizado As Panel
    Friend WithEvents lblSemanaActual As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents NSemanaInicio As NumericUpDown
    Friend WithEvents lblSemana As Label
    Friend WithEvents NAñoInicio As NumericUpDown
    Friend WithEvents pnlAutorizar As Panel
    Friend WithEvents btnAutorizar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlEnviadoPPCP As Panel
    Friend WithEvents pnlBitacora As Panel
    Friend WithEvents btnBitacora As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents lblGrupo As Label
    Friend WithEvents cmbGrupo As ComboBox
    Friend WithEvents pnlCambiosRealizados As Panel
    Friend WithEvents btnCambiosRealizados As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlEnviarCorreo As Panel
    Friend WithEvents btnReenviarCorreo As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
