<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExplosionMaterialesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExplosionMaterialesForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlGenerar = New System.Windows.Forms.Panel()
        Me.btnGenerarExplosion = New System.Windows.Forms.Button()
        Me.lblGenerarExplosion = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnAltaManual = New System.Windows.Forms.Button()
        Me.lblAltaManual = New System.Windows.Forms.Label()
        Me.pnlConsultar = New System.Windows.Forms.Panel()
        Me.btnConsultarOrdenes = New System.Windows.Forms.Button()
        Me.lblVerDetalle = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.lblCancelada = New System.Windows.Forms.Label()
        Me.pnlCancelada = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlFechaEntrega = New System.Windows.Forms.Panel()
        Me.lblAutorizada = New System.Windows.Forms.Label()
        Me.lblPorAutorizar = New System.Windows.Forms.Label()
        Me.pnlAutorizada = New System.Windows.Forms.Panel()
        Me.pnlPorAutorizar = New System.Windows.Forms.Panel()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlAutomatica = New System.Windows.Forms.Panel()
        Me.pnlManual = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTotalNumero = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblCantidadSolicitadaNumero = New System.Windows.Forms.Label()
        Me.lblSurtidosNumero = New System.Windows.Forms.Label()
        Me.lblCantidadSolicitada = New System.Windows.Forms.Label()
        Me.lblSurtidos = New System.Windows.Forms.Label()
        Me.lblParesNumero = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdPreorden = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdPreorden2 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chFechaPrograma = New System.Windows.Forms.CheckBox()
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cbxnave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.chReporteSemanal = New System.Windows.Forms.CheckBox()
        Me.grpReporte = New System.Windows.Forms.GroupBox()
        Me.lblNoSemana = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.nudSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.gbFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.chxTodo = New System.Windows.Forms.CheckBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlGenerar.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.pnlConsultar.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdPreorden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPreorden2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        Me.grpReporte.SuspendLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1362, 70)
        Me.pnlEncabezado.TabIndex = 2022
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlGenerar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel11)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlConsultar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel8)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel9)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel10)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel5)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel6)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(897, 73)
        Me.FlowLayoutPanel1.TabIndex = 2020
        '
        'pnlGenerar
        '
        Me.pnlGenerar.Controls.Add(Me.btnGenerarExplosion)
        Me.pnlGenerar.Controls.Add(Me.lblGenerarExplosion)
        Me.pnlGenerar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGenerar.Location = New System.Drawing.Point(3, 3)
        Me.pnlGenerar.Name = "pnlGenerar"
        Me.pnlGenerar.Size = New System.Drawing.Size(62, 70)
        Me.pnlGenerar.TabIndex = 0
        Me.pnlGenerar.Visible = False
        '
        'btnGenerarExplosion
        '
        Me.btnGenerarExplosion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarExplosion.Image = Global.Produccion.Vista.My.Resources.Resources.simulador2
        Me.btnGenerarExplosion.Location = New System.Drawing.Point(14, 13)
        Me.btnGenerarExplosion.Name = "btnGenerarExplosion"
        Me.btnGenerarExplosion.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarExplosion.TabIndex = 126
        Me.btnGenerarExplosion.UseVisualStyleBackColor = True
        '
        'lblGenerarExplosion
        '
        Me.lblGenerarExplosion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGenerarExplosion.AutoSize = True
        Me.lblGenerarExplosion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarExplosion.Location = New System.Drawing.Point(-2, 43)
        Me.lblGenerarExplosion.Name = "lblGenerarExplosion"
        Me.lblGenerarExplosion.Size = New System.Drawing.Size(65, 26)
        Me.lblGenerarExplosion.TabIndex = 127
        Me.lblGenerarExplosion.Text = "Altas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Automáticas"
        Me.lblGenerarExplosion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.btnAltaManual)
        Me.Panel11.Controls.Add(Me.lblAltaManual)
        Me.Panel11.Location = New System.Drawing.Point(71, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(62, 60)
        Me.Panel11.TabIndex = 191
        '
        'btnAltaManual
        '
        Me.btnAltaManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAltaManual.Image = Global.Produccion.Vista.My.Resources.Resources.altas_32
        Me.btnAltaManual.Location = New System.Drawing.Point(15, 3)
        Me.btnAltaManual.Name = "btnAltaManual"
        Me.btnAltaManual.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaManual.TabIndex = 130
        Me.btnAltaManual.UseVisualStyleBackColor = True
        '
        'lblAltaManual
        '
        Me.lblAltaManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAltaManual.AutoSize = True
        Me.lblAltaManual.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaManual.Location = New System.Drawing.Point(11, 33)
        Me.lblAltaManual.Name = "lblAltaManual"
        Me.lblAltaManual.Size = New System.Drawing.Size(42, 26)
        Me.lblAltaManual.TabIndex = 131
        Me.lblAltaManual.Text = "Alta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manual"
        Me.lblAltaManual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlConsultar
        '
        Me.pnlConsultar.Controls.Add(Me.btnConsultarOrdenes)
        Me.pnlConsultar.Controls.Add(Me.lblVerDetalle)
        Me.pnlConsultar.Location = New System.Drawing.Point(139, 3)
        Me.pnlConsultar.Name = "pnlConsultar"
        Me.pnlConsultar.Size = New System.Drawing.Size(62, 60)
        Me.pnlConsultar.TabIndex = 190
        '
        'btnConsultarOrdenes
        '
        Me.btnConsultarOrdenes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultarOrdenes.Image = Global.Produccion.Vista.My.Resources.Resources.details
        Me.btnConsultarOrdenes.Location = New System.Drawing.Point(13, 3)
        Me.btnConsultarOrdenes.Name = "btnConsultarOrdenes"
        Me.btnConsultarOrdenes.Size = New System.Drawing.Size(32, 32)
        Me.btnConsultarOrdenes.TabIndex = 130
        Me.btnConsultarOrdenes.UseVisualStyleBackColor = True
        '
        'lblVerDetalle
        '
        Me.lblVerDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVerDetalle.AutoSize = True
        Me.lblVerDetalle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVerDetalle.Location = New System.Drawing.Point(10, 33)
        Me.lblVerDetalle.Name = "lblVerDetalle"
        Me.lblVerDetalle.Size = New System.Drawing.Size(40, 26)
        Me.lblVerDetalle.TabIndex = 131
        Me.lblVerDetalle.Text = "Ver" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detalle"
        Me.lblVerDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.btnAutorizar)
        Me.Panel8.Controls.Add(Me.lblAutorizar)
        Me.Panel8.Location = New System.Drawing.Point(207, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(62, 60)
        Me.Panel8.TabIndex = 191
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Image = Global.Produccion.Vista.My.Resources.Resources.aceptar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(14, 3)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 2035
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(7, 40)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizar.TabIndex = 2036
        Me.lblAutorizar.Text = "Autorizar"
        Me.lblAutorizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.lblCancelar)
        Me.Panel9.Controls.Add(Me.btnCancelar)
        Me.Panel9.Location = New System.Drawing.Point(275, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(62, 60)
        Me.Panel9.TabIndex = 192
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(7, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 2038
        Me.lblCancelar.Text = "Cancelar"
        Me.lblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Produccion.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.Location = New System.Drawing.Point(14, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2037
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblImprimir)
        Me.Panel10.Controls.Add(Me.btnImprimir)
        Me.Panel10.Location = New System.Drawing.Point(343, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(62, 60)
        Me.Panel10.TabIndex = 193
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(10, 40)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 2034
        Me.lblImprimir.Text = "Imprimir"
        Me.lblImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_321
        Me.btnImprimir.Location = New System.Drawing.Point(14, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 2033
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Location = New System.Drawing.Point(411, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(72, 70)
        Me.Panel5.TabIndex = 194
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.Location = New System.Drawing.Point(-2, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 26)
        Me.Label8.TabIndex = 2034
        Me.Label8.Text = "Enviar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Comprobante"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Image = Global.Produccion.Vista.My.Resources.Resources.Email
        Me.Button1.Location = New System.Drawing.Point(17, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 2033
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Button2)
        Me.Panel6.Location = New System.Drawing.Point(489, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(62, 60)
        Me.Panel6.TabIndex = 195
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label9.Location = New System.Drawing.Point(7, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 2034
        Me.Label9.Text = "Exportar"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.Button2.Location = New System.Drawing.Point(14, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 2033
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(1084, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(169, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Órdenes de Compra"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1294, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 70)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.UltraGroupBox2)
        Me.pnlInferior.Controls.Add(Me.UltraGroupBox1)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 603)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1362, 68)
        Me.pnlInferior.TabIndex = 2023
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.lblCancelada)
        Me.UltraGroupBox2.Controls.Add(Me.pnlCancelada)
        Me.UltraGroupBox2.Controls.Add(Me.Label5)
        Me.UltraGroupBox2.Controls.Add(Me.pnlFechaEntrega)
        Me.UltraGroupBox2.Controls.Add(Me.lblAutorizada)
        Me.UltraGroupBox2.Controls.Add(Me.lblPorAutorizar)
        Me.UltraGroupBox2.Controls.Add(Me.pnlAutorizada)
        Me.UltraGroupBox2.Controls.Add(Me.pnlPorAutorizar)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(326, 62)
        Me.UltraGroupBox2.TabIndex = 139
        Me.UltraGroupBox2.Text = "Orden de Compra (ST)"
        '
        'lblCancelada
        '
        Me.lblCancelada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCancelada.AutoSize = True
        Me.lblCancelada.Location = New System.Drawing.Point(35, 47)
        Me.lblCancelada.Name = "lblCancelada"
        Me.lblCancelada.Size = New System.Drawing.Size(58, 13)
        Me.lblCancelada.TabIndex = 137
        Me.lblCancelada.Text = "Cancelada"
        '
        'pnlCancelada
        '
        Me.pnlCancelada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlCancelada.BackColor = System.Drawing.Color.IndianRed
        Me.pnlCancelada.Location = New System.Drawing.Point(14, 46)
        Me.pnlCancelada.Name = "pnlCancelada"
        Me.pnlCancelada.Size = New System.Drawing.Size(14, 14)
        Me.pnlCancelada.TabIndex = 136
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(143, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 135
        Me.Label5.Text = "Verificar Fecha Entrega"
        Me.Label5.Visible = False
        '
        'pnlFechaEntrega
        '
        Me.pnlFechaEntrega.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlFechaEntrega.BackColor = System.Drawing.Color.Silver
        Me.pnlFechaEntrega.Location = New System.Drawing.Point(125, 14)
        Me.pnlFechaEntrega.Name = "pnlFechaEntrega"
        Me.pnlFechaEntrega.Size = New System.Drawing.Size(14, 14)
        Me.pnlFechaEntrega.TabIndex = 134
        Me.pnlFechaEntrega.Visible = False
        '
        'lblAutorizada
        '
        Me.lblAutorizada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAutorizada.AutoSize = True
        Me.lblAutorizada.Location = New System.Drawing.Point(35, 31)
        Me.lblAutorizada.Name = "lblAutorizada"
        Me.lblAutorizada.Size = New System.Drawing.Size(57, 13)
        Me.lblAutorizada.TabIndex = 135
        Me.lblAutorizada.Text = "Autorizada"
        '
        'lblPorAutorizar
        '
        Me.lblPorAutorizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPorAutorizar.AutoSize = True
        Me.lblPorAutorizar.Location = New System.Drawing.Point(35, 15)
        Me.lblPorAutorizar.Name = "lblPorAutorizar"
        Me.lblPorAutorizar.Size = New System.Drawing.Size(56, 13)
        Me.lblPorAutorizar.TabIndex = 134
        Me.lblPorAutorizar.Text = "Capturada"
        '
        'pnlAutorizada
        '
        Me.pnlAutorizada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlAutorizada.BackColor = System.Drawing.Color.YellowGreen
        Me.pnlAutorizada.Location = New System.Drawing.Point(14, 30)
        Me.pnlAutorizada.Name = "pnlAutorizada"
        Me.pnlAutorizada.Size = New System.Drawing.Size(14, 14)
        Me.pnlAutorizada.TabIndex = 133
        '
        'pnlPorAutorizar
        '
        Me.pnlPorAutorizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPorAutorizar.BackColor = System.Drawing.Color.SkyBlue
        Me.pnlPorAutorizar.Location = New System.Drawing.Point(14, 14)
        Me.pnlPorAutorizar.Name = "pnlPorAutorizar"
        Me.pnlPorAutorizar.Size = New System.Drawing.Size(14, 14)
        Me.pnlPorAutorizar.TabIndex = 132
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Controls.Add(Me.Label3)
        Me.UltraGroupBox1.Controls.Add(Me.pnlAutomatica)
        Me.UltraGroupBox1.Controls.Add(Me.pnlManual)
        Me.UltraGroupBox1.Controls.Add(Me.Label2)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(584, 3)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(129, 62)
        Me.UltraGroupBox1.TabIndex = 138
        Me.UltraGroupBox1.Text = "Captura (ST)"
        Me.UltraGroupBox1.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Automática"
        '
        'pnlAutomatica
        '
        Me.pnlAutomatica.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlAutomatica.BackColor = System.Drawing.Color.Thistle
        Me.pnlAutomatica.Location = New System.Drawing.Point(13, 20)
        Me.pnlAutomatica.Name = "pnlAutomatica"
        Me.pnlAutomatica.Size = New System.Drawing.Size(14, 14)
        Me.pnlAutomatica.TabIndex = 130
        '
        'pnlManual
        '
        Me.pnlManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlManual.BackColor = System.Drawing.Color.BurlyWood
        Me.pnlManual.Location = New System.Drawing.Point(13, 36)
        Me.pnlManual.Name = "pnlManual"
        Me.pnlManual.Size = New System.Drawing.Size(14, 14)
        Me.pnlManual.TabIndex = 131
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Manual"
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1312, 42)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1312, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(614, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Material Nuevo en Explosión"
        Me.Label1.Visible = False
        '
        'lblColor
        '
        Me.lblColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(614, 212)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(80, 13)
        Me.lblColor.TabIndex = 123
        Me.lblColor.Text = "Material Pedido"
        Me.lblColor.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(593, 230)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(14, 14)
        Me.Panel3.TabIndex = 124
        Me.Panel3.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(593, 210)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(14, 14)
        Me.Panel4.TabIndex = 122
        Me.Panel4.Visible = False
        '
        'lblTotalNumero
        '
        Me.lblTotalNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalNumero.AutoSize = True
        Me.lblTotalNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNumero.Location = New System.Drawing.Point(529, 233)
        Me.lblTotalNumero.Name = "lblTotalNumero"
        Me.lblTotalNumero.Size = New System.Drawing.Size(26, 18)
        Me.lblTotalNumero.TabIndex = 119
        Me.lblTotalNumero.Text = "$0"
        Me.lblTotalNumero.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(540, 230)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(51, 18)
        Me.lblTotal.TabIndex = 118
        Me.lblTotal.Text = "Total:"
        Me.lblTotal.Visible = False
        '
        'lblCantidadSolicitadaNumero
        '
        Me.lblCantidadSolicitadaNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCantidadSolicitadaNumero.AutoSize = True
        Me.lblCantidadSolicitadaNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadSolicitadaNumero.Location = New System.Drawing.Point(562, 233)
        Me.lblCantidadSolicitadaNumero.Name = "lblCantidadSolicitadaNumero"
        Me.lblCantidadSolicitadaNumero.Size = New System.Drawing.Size(17, 18)
        Me.lblCantidadSolicitadaNumero.TabIndex = 117
        Me.lblCantidadSolicitadaNumero.Text = "0"
        Me.lblCantidadSolicitadaNumero.Visible = False
        '
        'lblSurtidosNumero
        '
        Me.lblSurtidosNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSurtidosNumero.AutoSize = True
        Me.lblSurtidosNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSurtidosNumero.Location = New System.Drawing.Point(581, 215)
        Me.lblSurtidosNumero.Name = "lblSurtidosNumero"
        Me.lblSurtidosNumero.Size = New System.Drawing.Size(17, 18)
        Me.lblSurtidosNumero.TabIndex = 115
        Me.lblSurtidosNumero.Text = "0"
        Me.lblSurtidosNumero.Visible = False
        '
        'lblCantidadSolicitada
        '
        Me.lblCantidadSolicitada.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCantidadSolicitada.AutoSize = True
        Me.lblCantidadSolicitada.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadSolicitada.Location = New System.Drawing.Point(410, 233)
        Me.lblCantidadSolicitada.Name = "lblCantidadSolicitada"
        Me.lblCantidadSolicitada.Size = New System.Drawing.Size(158, 18)
        Me.lblCantidadSolicitada.TabIndex = 116
        Me.lblCantidadSolicitada.Text = "Cantidad Solicitada:"
        Me.lblCantidadSolicitada.Visible = False
        '
        'lblSurtidos
        '
        Me.lblSurtidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSurtidos.AutoSize = True
        Me.lblSurtidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSurtidos.Location = New System.Drawing.Point(410, 215)
        Me.lblSurtidos.Name = "lblSurtidos"
        Me.lblSurtidos.Size = New System.Drawing.Size(177, 18)
        Me.lblSurtidos.TabIndex = 114
        Me.lblSurtidos.Text = "Surtidos de Inventario:"
        Me.lblSurtidos.Visible = False
        '
        'lblParesNumero
        '
        Me.lblParesNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblParesNumero.AutoSize = True
        Me.lblParesNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesNumero.Location = New System.Drawing.Point(461, 197)
        Me.lblParesNumero.Name = "lblParesNumero"
        Me.lblParesNumero.Size = New System.Drawing.Size(17, 18)
        Me.lblParesNumero.TabIndex = 113
        Me.lblParesNumero.Text = "0"
        Me.lblParesNumero.Visible = False
        '
        'lblPares
        '
        Me.lblPares.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.Location = New System.Drawing.Point(410, 197)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(57, 18)
        Me.lblPares.TabIndex = 112
        Me.lblPares.Text = "Pares:"
        Me.lblPares.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grdPreorden)
        Me.Panel1.Controls.Add(Me.grdPreorden2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.lblPares)
        Me.Panel1.Controls.Add(Me.lblParesNumero)
        Me.Panel1.Controls.Add(Me.lblSurtidos)
        Me.Panel1.Controls.Add(Me.lblCantidadSolicitada)
        Me.Panel1.Controls.Add(Me.lblSurtidosNumero)
        Me.Panel1.Controls.Add(Me.lblCantidadSolicitadaNumero)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.lblTotalNumero)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblColor)
        Me.Panel1.Location = New System.Drawing.Point(0, 253)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1362, 344)
        Me.Panel1.TabIndex = 2024
        '
        'grdPreorden
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPreorden.DisplayLayout.Appearance = Appearance1
        Me.grdPreorden.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPreorden.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPreorden.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPreorden.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPreorden.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPreorden.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPreorden.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdPreorden.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdPreorden.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPreorden.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdPreorden.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPreorden.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPreorden.Location = New System.Drawing.Point(0, 0)
        Me.grdPreorden.Name = "grdPreorden"
        Me.grdPreorden.Size = New System.Drawing.Size(1362, 344)
        Me.grdPreorden.TabIndex = 2022
        '
        'grdPreorden2
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPreorden2.DisplayLayout.Appearance = Appearance4
        Me.grdPreorden2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPreorden2.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPreorden2.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPreorden2.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPreorden2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPreorden2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPreorden2.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.DarkGray
        Me.grdPreorden2.DisplayLayout.Override.RowAppearance = Appearance6
        Me.grdPreorden2.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPreorden2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdPreorden2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPreorden2.Location = New System.Drawing.Point(334, 77)
        Me.grdPreorden2.Name = "grdPreorden2"
        Me.grdPreorden2.Size = New System.Drawing.Size(524, 147)
        Me.grdPreorden2.TabIndex = 2023
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.UltraGroupBox4)
        Me.Panel2.Controls.Add(Me.chFechaPrograma)
        Me.Panel2.Controls.Add(Me.UltraGroupBox3)
        Me.Panel2.Controls.Add(Me.chReporteSemanal)
        Me.Panel2.Controls.Add(Me.grpReporte)
        Me.Panel2.Controls.Add(Me.gbFecha)
        Me.Panel2.Controls.Add(Me.chxTodo)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.lblLimpiar)
        Me.Panel2.Controls.Add(Me.btnMostrar)
        Me.Panel2.Controls.Add(Me.lblMostrar)
        Me.Panel2.Location = New System.Drawing.Point(0, 82)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1362, 172)
        Me.Panel2.TabIndex = 2025
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Controls.Add(Me.cmbEstatus)
        Me.UltraGroupBox4.Controls.Add(Me.Label10)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(464, 82)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(310, 44)
        Me.UltraGroupBox4.TabIndex = 2040
        '
        'cmbEstatus
        '
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(68, 12)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(228, 21)
        Me.cmbEstatus.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "* Estatus"
        '
        'chFechaPrograma
        '
        Me.chFechaPrograma.AutoSize = True
        Me.chFechaPrograma.Location = New System.Drawing.Point(17, 64)
        Me.chFechaPrograma.Name = "chFechaPrograma"
        Me.chFechaPrograma.Size = New System.Drawing.Size(104, 17)
        Me.chFechaPrograma.TabIndex = 2
        Me.chFechaPrograma.Text = "Fecha Programa"
        Me.chFechaPrograma.UseVisualStyleBackColor = True
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Controls.Add(Me.cbxnave)
        Me.UltraGroupBox3.Controls.Add(Me.lblNave)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(16, 10)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(417, 44)
        Me.UltraGroupBox3.TabIndex = 2039
        '
        'cbxnave
        '
        Me.cbxnave.FormattingEnabled = True
        Me.cbxnave.Location = New System.Drawing.Point(55, 12)
        Me.cbxnave.Name = "cbxnave"
        Me.cbxnave.Size = New System.Drawing.Size(317, 21)
        Me.cbxnave.TabIndex = 1
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(12, 16)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 127
        Me.lblNave.Text = "*Nave"
        '
        'chReporteSemanal
        '
        Me.chReporteSemanal.AutoSize = True
        Me.chReporteSemanal.Location = New System.Drawing.Point(233, 64)
        Me.chReporteSemanal.Name = "chReporteSemanal"
        Me.chReporteSemanal.Size = New System.Drawing.Size(65, 17)
        Me.chReporteSemanal.TabIndex = 3
        Me.chReporteSemanal.Text = "Semana"
        Me.chReporteSemanal.UseVisualStyleBackColor = True
        '
        'grpReporte
        '
        Me.grpReporte.Controls.Add(Me.lblNoSemana)
        Me.grpReporte.Controls.Add(Me.Label4)
        Me.grpReporte.Controls.Add(Me.nudAño)
        Me.grpReporte.Controls.Add(Me.nudSemanaInicio)
        Me.grpReporte.Enabled = False
        Me.grpReporte.Location = New System.Drawing.Point(233, 76)
        Me.grpReporte.Name = "grpReporte"
        Me.grpReporte.Size = New System.Drawing.Size(200, 78)
        Me.grpReporte.TabIndex = 2037
        Me.grpReporte.TabStop = False
        '
        'lblNoSemana
        '
        Me.lblNoSemana.AutoSize = True
        Me.lblNoSemana.Location = New System.Drawing.Point(123, 19)
        Me.lblNoSemana.Name = "lblNoSemana"
        Me.lblNoSemana.Size = New System.Drawing.Size(16, 13)
        Me.lblNoSemana.TabIndex = 2036
        Me.lblNoSemana.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 2035
        Me.Label4.Text = "Semana Actual:"
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(94, 44)
        Me.nudAño.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(61, 20)
        Me.nudAño.TabIndex = 2032
        Me.nudAño.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'nudSemanaInicio
        '
        Me.nudSemanaInicio.Location = New System.Drawing.Point(38, 44)
        Me.nudSemanaInicio.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.nudSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaInicio.Name = "nudSemanaInicio"
        Me.nudSemanaInicio.Size = New System.Drawing.Size(50, 20)
        Me.nudSemanaInicio.TabIndex = 2034
        Me.nudSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'gbFecha
        '
        Me.gbFecha.Controls.Add(Me.dtpFechaFin)
        Me.gbFecha.Controls.Add(Me.Label6)
        Me.gbFecha.Controls.Add(Me.Label7)
        Me.gbFecha.Controls.Add(Me.dtpFechaInicio)
        Me.gbFecha.Location = New System.Drawing.Point(15, 76)
        Me.gbFecha.Name = "gbFecha"
        Me.gbFecha.Size = New System.Drawing.Size(200, 78)
        Me.gbFecha.TabIndex = 2036
        Me.gbFecha.TabStop = False
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(56, 45)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaFin.TabIndex = 108
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Del:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 13)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Al:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(56, 19)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaInicio.TabIndex = 107
        '
        'chxTodo
        '
        Me.chxTodo.AutoSize = True
        Me.chxTodo.Location = New System.Drawing.Point(1240, 137)
        Me.chxTodo.Name = "chxTodo"
        Me.chxTodo.Size = New System.Drawing.Size(110, 17)
        Me.chxTodo.TabIndex = 2027
        Me.chxTodo.Text = "Seleccionar Todo"
        Me.chxTodo.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(1312, 22)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(1309, 59)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 123
        Me.lblLimpiar.Text = "Limpiar"
        Me.lblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.Location = New System.Drawing.Point(1261, 22)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 5
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(1256, 59)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 125
        Me.lblMostrar.Text = "Mostrar"
        Me.lblMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ExplosionMaterialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1362, 671)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ExplosionMaterialesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Órdenes de Compra"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlGenerar.ResumeLayout(False)
        Me.pnlGenerar.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.pnlConsultar.ResumeLayout(False)
        Me.pnlConsultar.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        Me.UltraGroupBox2.PerformLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.UltraGroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdPreorden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPreorden2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        Me.grpReporte.ResumeLayout(False)
        Me.grpReporte.PerformLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFecha.ResumeLayout(False)
        Me.gbFecha.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblTotalNumero As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblCantidadSolicitadaNumero As System.Windows.Forms.Label
    Friend WithEvents lblSurtidosNumero As System.Windows.Forms.Label
    Friend WithEvents lblCantidadSolicitada As System.Windows.Forms.Label
    Friend WithEvents lblSurtidos As System.Windows.Forms.Label
    Friend WithEvents lblParesNumero As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents grdPreorden As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents chxTodo As System.Windows.Forms.CheckBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblGenerarExplosion As System.Windows.Forms.Label
    Friend WithEvents btnGenerarExplosion As System.Windows.Forms.Button
    Friend WithEvents lblVerDetalle As System.Windows.Forms.Label
    Friend WithEvents btnConsultarOrdenes As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlGenerar As System.Windows.Forms.Panel
    Friend WithEvents pnlConsultar As System.Windows.Forms.Panel
    Friend WithEvents grdPreorden2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents btnAltaManual As System.Windows.Forms.Button
    Friend WithEvents lblAltaManual As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlManual As System.Windows.Forms.Panel
    Friend WithEvents pnlAutomatica As System.Windows.Forms.Panel
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents lblCancelada As Label
    Friend WithEvents pnlCancelada As Panel
    Friend WithEvents lblAutorizada As Label
    Friend WithEvents lblPorAutorizar As Label
    Friend WithEvents pnlAutorizada As Panel
    Friend WithEvents pnlPorAutorizar As Panel
    Friend WithEvents nudSemanaInicio As NumericUpDown
    Friend WithEvents nudAño As NumericUpDown
    Friend WithEvents gbFecha As GroupBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents chReporteSemanal As CheckBox
    Friend WithEvents grpReporte As GroupBox
    Friend WithEvents lblNoSemana As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlFechaEntrega As Panel
    Friend WithEvents chFechaPrograma As CheckBox
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbEstatus As ComboBox
    Friend WithEvents cbxnave As ComboBox
End Class
