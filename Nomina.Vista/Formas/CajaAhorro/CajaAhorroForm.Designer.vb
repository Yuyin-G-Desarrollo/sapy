<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CajaAhorroForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CajaAhorroForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.lblReporteDeducciones = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblCierreSemanal = New System.Windows.Forms.Label()
        Me.lblReporteAnual1 = New System.Windows.Forms.Label()
        Me.lblCierreAnual1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCierreAnual = New System.Windows.Forms.Button()
        Me.lblAsignar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnReporteCS = New System.Windows.Forms.Button()
        Me.lblConfiguracion = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.btnCierreSemanal = New System.Windows.Forms.Button()
        Me.btnConfiguracion = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grCajaAhorro = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grdCajaAhorro = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.CalculoPrimaVacacionalDS1 = New Nomina.Vista.CalculoPrimaVacacionalDS()
        Me.menuImprimir = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeduccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteConcentradoCajaAhorroTool = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grdIntereses = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.lblAccionRegresar = New System.Windows.Forms.Label()
        Me.menuAyudaReportes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AyudaReporteGeneralDeDeduccionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grCajaAhorro.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCajaAhorro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoPrimaVacacionalDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuImprimir.SuspendLayout()
        CType(Me.grdIntereses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.menuAyudaReportes.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblAyuda)
        Me.pnlHeader.Controls.Add(Me.btnAyuda)
        Me.pnlHeader.Controls.Add(Me.lblReporteDeducciones)
        Me.pnlHeader.Controls.Add(Me.btnImprimir)
        Me.pnlHeader.Controls.Add(Me.lblCierreSemanal)
        Me.pnlHeader.Controls.Add(Me.lblReporteAnual1)
        Me.pnlHeader.Controls.Add(Me.lblCierreAnual1)
        Me.pnlHeader.Controls.Add(Me.Label2)
        Me.pnlHeader.Controls.Add(Me.btnCierreAnual)
        Me.pnlHeader.Controls.Add(Me.lblAsignar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.btnReporteCS)
        Me.pnlHeader.Controls.Add(Me.lblConfiguracion)
        Me.pnlHeader.Controls.Add(Me.lblEditar)
        Me.pnlHeader.Controls.Add(Me.lblNuevo)
        Me.pnlHeader.Controls.Add(Me.btnReporte)
        Me.pnlHeader.Controls.Add(Me.btnAsignar)
        Me.pnlHeader.Controls.Add(Me.btnCierreSemanal)
        Me.pnlHeader.Controls.Add(Me.btnConfiguracion)
        Me.pnlHeader.Controls.Add(Me.btnEditar)
        Me.pnlHeader.Controls.Add(Me.btnNuevo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1241, 69)
        Me.pnlHeader.TabIndex = 0
        '
        'lblAyuda
        '
        Me.lblAyuda.AutoSize = True
        Me.lblAyuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAyuda.Location = New System.Drawing.Point(443, 40)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(37, 13)
        Me.lblAyuda.TabIndex = 37
        Me.lblAyuda.Text = "Ayuda"
        Me.lblAyuda.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAyuda
        '
        Me.btnAyuda.BackColor = System.Drawing.Color.AliceBlue
        Me.btnAyuda.Image = Global.Nomina.Vista.My.Resources.Resources.ayuda
        Me.btnAyuda.Location = New System.Drawing.Point(445, 8)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 36
        Me.btnAyuda.UseVisualStyleBackColor = False
        '
        'lblReporteDeducciones
        '
        Me.lblReporteDeducciones.AutoSize = True
        Me.lblReporteDeducciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporteDeducciones.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReporteDeducciones.Location = New System.Drawing.Point(379, 41)
        Me.lblReporteDeducciones.Name = "lblReporteDeducciones"
        Me.lblReporteDeducciones.Size = New System.Drawing.Size(42, 13)
        Me.lblReporteDeducciones.TabIndex = 35
        Me.lblReporteDeducciones.Text = "Imprimir"
        Me.lblReporteDeducciones.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.AliceBlue
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(383, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 34
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblCierreSemanal
        '
        Me.lblCierreSemanal.AutoSize = True
        Me.lblCierreSemanal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCierreSemanal.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCierreSemanal.Location = New System.Drawing.Point(193, 40)
        Me.lblCierreSemanal.Name = "lblCierreSemanal"
        Me.lblCierreSemanal.Size = New System.Drawing.Size(48, 26)
        Me.lblCierreSemanal.TabIndex = 14
        Me.lblCierreSemanal.Text = "Cierre" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Semanal"
        Me.lblCierreSemanal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblReporteAnual1
        '
        Me.lblReporteAnual1.AutoSize = True
        Me.lblReporteAnual1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporteAnual1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReporteAnual1.Location = New System.Drawing.Point(554, 39)
        Me.lblReporteAnual1.Name = "lblReporteAnual1"
        Me.lblReporteAnual1.Size = New System.Drawing.Size(45, 26)
        Me.lblReporteAnual1.TabIndex = 33
        Me.lblReporteAnual1.Text = "Reporte" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Anual"
        Me.lblReporteAnual1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblReporteAnual1.Visible = False
        '
        'lblCierreAnual1
        '
        Me.lblCierreAnual1.AutoSize = True
        Me.lblCierreAnual1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCierreAnual1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCierreAnual1.Location = New System.Drawing.Point(320, 40)
        Me.lblCierreAnual1.Name = "lblCierreAnual1"
        Me.lblCierreAnual1.Size = New System.Drawing.Size(34, 26)
        Me.lblCierreAnual1.TabIndex = 31
        Me.lblCierreAnual1.Text = "Cierre" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Anual"
        Me.lblCierreAnual1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblCierreAnual1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(492, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 26)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Reporte" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Semanal"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Visible = False
        '
        'btnCierreAnual
        '
        Me.btnCierreAnual.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCierreAnual.Image = Global.Nomina.Vista.My.Resources.Resources.candado
        Me.btnCierreAnual.Location = New System.Drawing.Point(321, 8)
        Me.btnCierreAnual.Name = "btnCierreAnual"
        Me.btnCierreAnual.Size = New System.Drawing.Size(32, 32)
        Me.btnCierreAnual.TabIndex = 6
        Me.btnCierreAnual.UseVisualStyleBackColor = False
        Me.btnCierreAnual.Visible = False
        '
        'lblAsignar
        '
        Me.lblAsignar.AutoSize = True
        Me.lblAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsignar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAsignar.Location = New System.Drawing.Point(240, 40)
        Me.lblAsignar.Name = "lblAsignar"
        Me.lblAsignar.Size = New System.Drawing.Size(75, 26)
        Me.lblAsignar.TabIndex = 15
        Me.lblAsignar.Text = "Ingresar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Colaboradores"
        Me.lblAsignar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.Label11)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(888, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(353, 69)
        Me.pnlTitulo.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label11.Location = New System.Drawing.Point(156, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 20)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Caja de Ahorro"
        '
        'btnReporteCS
        '
        Me.btnReporteCS.BackColor = System.Drawing.Color.AliceBlue
        Me.btnReporteCS.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnReporteCS.Location = New System.Drawing.Point(499, 8)
        Me.btnReporteCS.Name = "btnReporteCS"
        Me.btnReporteCS.Size = New System.Drawing.Size(32, 32)
        Me.btnReporteCS.TabIndex = 21
        Me.btnReporteCS.UseVisualStyleBackColor = False
        Me.btnReporteCS.Visible = False
        '
        'lblConfiguracion
        '
        Me.lblConfiguracion.AutoSize = True
        Me.lblConfiguracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfiguracion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConfiguracion.Location = New System.Drawing.Point(133, 40)
        Me.lblConfiguracion.Name = "lblConfiguracion"
        Me.lblConfiguracion.Size = New System.Drawing.Size(48, 13)
        Me.lblConfiguracion.TabIndex = 13
        Me.lblConfiguracion.Text = "Políticas"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(80, 40)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 11
        Me.lblEditar.Text = "Editar"
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(22, 40)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(30, 13)
        Me.lblNuevo.TabIndex = 10
        Me.lblNuevo.Text = "Altas"
        '
        'btnReporte
        '
        Me.btnReporte.BackColor = System.Drawing.Color.AliceBlue
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.Location = New System.Drawing.Point(560, 8)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(32, 32)
        Me.btnReporte.TabIndex = 7
        Me.btnReporte.UseVisualStyleBackColor = False
        Me.btnReporte.Visible = False
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnAsignar.Image = CType(resources.GetObject("btnAsignar.Image"), System.Drawing.Image)
        Me.btnAsignar.Location = New System.Drawing.Point(261, 8)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(32, 32)
        Me.btnAsignar.TabIndex = 5
        Me.btnAsignar.UseVisualStyleBackColor = False
        '
        'btnCierreSemanal
        '
        Me.btnCierreSemanal.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCierreSemanal.Image = Global.Nomina.Vista.My.Resources.Resources.candado
        Me.btnCierreSemanal.Location = New System.Drawing.Point(201, 8)
        Me.btnCierreSemanal.Name = "btnCierreSemanal"
        Me.btnCierreSemanal.Size = New System.Drawing.Size(32, 32)
        Me.btnCierreSemanal.TabIndex = 4
        Me.btnCierreSemanal.UseVisualStyleBackColor = False
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.BackColor = System.Drawing.Color.AliceBlue
        Me.btnConfiguracion.Image = CType(resources.GetObject("btnConfiguracion.Image"), System.Drawing.Image)
        Me.btnConfiguracion.Location = New System.Drawing.Point(141, 8)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(32, 32)
        Me.btnConfiguracion.TabIndex = 3
        Me.btnConfiguracion.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(81, 8)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 1
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.AliceBlue
        Me.btnNuevo.Image = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnNuevo.Location = New System.Drawing.Point(21, 8)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'grCajaAhorro
        '
        Me.grCajaAhorro.BackColor = System.Drawing.Color.Transparent
        Me.grCajaAhorro.Controls.Add(Me.Label1)
        Me.grCajaAhorro.Controls.Add(Me.cmbEstatus)
        Me.grCajaAhorro.Controls.Add(Me.cmbNave)
        Me.grCajaAhorro.Controls.Add(Me.Label3)
        Me.grCajaAhorro.Controls.Add(Me.Panel1)
        Me.grCajaAhorro.Dock = System.Windows.Forms.DockStyle.Top
        Me.grCajaAhorro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.grCajaAhorro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grCajaAhorro.Location = New System.Drawing.Point(0, 69)
        Me.grCajaAhorro.Name = "grCajaAhorro"
        Me.grCajaAhorro.Size = New System.Drawing.Size(1241, 104)
        Me.grCajaAhorro.TabIndex = 1
        Me.grCajaAhorro.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(654, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Estatus"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(706, 52)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(221, 21)
        Me.cmbEstatus.TabIndex = 1
        '
        'cmbNave
        '
        Me.cmbNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(320, 52)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(247, 21)
        Me.cmbNave.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(281, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nave"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnArriba)
        Me.Panel1.Controls.Add(Me.btnAbajo)
        Me.Panel1.Controls.Add(Me.lblBúscar)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.lblLimpiar)
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1121, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(117, 85)
        Me.Panel1.TabIndex = 38
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(52, 5)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(86, 5)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(14, 65)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(49, 15)
        Me.lblBúscar.TabIndex = 34
        Me.lblBúscar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(74, 31)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(66, 65)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 15)
        Me.lblLimpiar.TabIndex = 33
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(21, 31)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'grdCajaAhorro
        '
        Me.grdCajaAhorro.AllowEditing = False
        Me.grdCajaAhorro.AllowFiltering = True
        Me.grdCajaAhorro.BackColor = System.Drawing.Color.White
        Me.grdCajaAhorro.ColumnInfo = resources.GetString("grdCajaAhorro.ColumnInfo")
        Me.grdCajaAhorro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCajaAhorro.ExtendLastCol = True
        Me.grdCajaAhorro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.grdCajaAhorro.Location = New System.Drawing.Point(0, 173)
        Me.grdCajaAhorro.Name = "grdCajaAhorro"
        Me.grdCajaAhorro.Rows.DefaultSize = 19
        Me.grdCajaAhorro.Size = New System.Drawing.Size(1241, 354)
        Me.grdCajaAhorro.StyleInfo = resources.GetString("grdCajaAhorro.StyleInfo")
        Me.grdCajaAhorro.TabIndex = 2
        '
        'CalculoPrimaVacacionalDS1
        '
        Me.CalculoPrimaVacacionalDS1.DataSetName = "CalculoPrimaVacacionalDS"
        Me.CalculoPrimaVacacionalDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'menuImprimir
        '
        Me.menuImprimir.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuImprimir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeduccionesToolStripMenuItem, Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem, Me.ReporteConcentradoCajaAhorroTool, Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem})
        Me.menuImprimir.Name = "menuImprimir"
        Me.menuImprimir.Size = New System.Drawing.Size(301, 92)
        '
        'DeduccionesToolStripMenuItem
        '
        Me.DeduccionesToolStripMenuItem.Name = "DeduccionesToolStripMenuItem"
        Me.DeduccionesToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.DeduccionesToolStripMenuItem.Text = "Reporte General de Deducciones"
        '
        'ReporteAnualDeCajaDeAhorroToolStripMenuItem
        '
        Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem.Name = "ReporteAnualDeCajaDeAhorroToolStripMenuItem"
        Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.ReporteAnualDeCajaDeAhorroToolStripMenuItem.Text = "Reporte de Semanas Ganadas por Colaborador"
        '
        'ReporteConcentradoCajaAhorroTool
        '
        Me.ReporteConcentradoCajaAhorroTool.Name = "ReporteConcentradoCajaAhorroTool"
        Me.ReporteConcentradoCajaAhorroTool.Size = New System.Drawing.Size(300, 22)
        Me.ReporteConcentradoCajaAhorroTool.Text = "Reporte concentrado caja de ahorro"
        Me.ReporteConcentradoCajaAhorroTool.Visible = False
        '
        'ReporteConcentradoPréstamosEInteresesToolStripMenuItem
        '
        Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem.Name = "ReporteConcentradoPréstamosEInteresesToolStripMenuItem"
        Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.ReporteConcentradoPréstamosEInteresesToolStripMenuItem.Text = "Reporte Concentrado Préstamos e Intereses"
        '
        'grdIntereses
        '
        Me.grdIntereses.Location = New System.Drawing.Point(3, 6)
        Me.grdIntereses.Name = "grdIntereses"
        Me.grdIntereses.Size = New System.Drawing.Size(1088, 190)
        Me.grdIntereses.TabIndex = 39
        Me.grdIntereses.Text = "UltraGrid1"
        Me.grdIntereses.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.grdIntereses)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 527)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1241, 60)
        Me.Panel3.TabIndex = 44
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnRegresar)
        Me.Panel2.Controls.Add(Me.lblAccionRegresar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1097, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(144, 60)
        Me.Panel2.TabIndex = 41
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(94, 6)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 36
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'lblAccionRegresar
        '
        Me.lblAccionRegresar.AutoSize = True
        Me.lblAccionRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAccionRegresar.Location = New System.Drawing.Point(93, 40)
        Me.lblAccionRegresar.Name = "lblAccionRegresar"
        Me.lblAccionRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblAccionRegresar.TabIndex = 39
        Me.lblAccionRegresar.Text = "Cerrar"
        '
        'menuAyudaReportes
        '
        Me.menuAyudaReportes.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuAyudaReportes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaReporteGeneralDeDeduccionesToolStripMenuItem, Me.AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem})
        Me.menuAyudaReportes.Name = "menuAyudaReportes"
        Me.menuAyudaReportes.Size = New System.Drawing.Size(284, 48)
        '
        'AyudaReporteGeneralDeDeduccionesToolStripMenuItem
        '
        Me.AyudaReporteGeneralDeDeduccionesToolStripMenuItem.Name = "AyudaReporteGeneralDeDeduccionesToolStripMenuItem"
        Me.AyudaReporteGeneralDeDeduccionesToolStripMenuItem.Size = New System.Drawing.Size(283, 22)
        Me.AyudaReporteGeneralDeDeduccionesToolStripMenuItem.Text = "Ayuda Reporte General de Deducciones"
        '
        'AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem
        '
        Me.AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem.Name = "AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem"
        Me.AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem.Size = New System.Drawing.Size(283, 22)
        Me.AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem.Text = "Ayuda Reporte concentrado caja de ahorro"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(285, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 69)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 27
        Me.pcbTitulo.TabStop = False
        '
        'CajaAhorroForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 587)
        Me.Controls.Add(Me.grdCajaAhorro)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.grCajaAhorro)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "CajaAhorroForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caja de Ahorro"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grCajaAhorro.ResumeLayout(False)
        Me.grCajaAhorro.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdCajaAhorro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoPrimaVacacionalDS1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuImprimir.ResumeLayout(False)
        CType(Me.grdIntereses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.menuAyudaReportes.ResumeLayout(False)
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblAsignar As System.Windows.Forms.Label
    Friend WithEvents lblCierreSemanal As System.Windows.Forms.Label
    Friend WithEvents lblConfiguracion As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents btnCierreAnual As System.Windows.Forms.Button
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents btnCierreSemanal As System.Windows.Forms.Button
    Friend WithEvents btnConfiguracion As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents grCajaAhorro As System.Windows.Forms.GroupBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdCajaAhorro As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnReporteCS As System.Windows.Forms.Button
    Friend WithEvents CalculoPrimaVacacionalDS1 As Nomina.Vista.CalculoPrimaVacacionalDS
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblReporteAnual1 As System.Windows.Forms.Label
    Friend WithEvents lblCierreAnual1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblReporteDeducciones As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents menuImprimir As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeduccionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteAnualDeCajaDeAhorroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grdIntereses As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblAccionRegresar As System.Windows.Forms.Label
    Friend WithEvents ReporteConcentradoCajaAhorroTool As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblAyuda As Label
    Friend WithEvents btnAyuda As Button
    Friend WithEvents menuAyudaReportes As ContextMenuStrip
    Friend WithEvents AyudaReporteGeneralDeDeduccionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteConcentradoPréstamosEInteresesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pcbTitulo As PictureBox
End Class
