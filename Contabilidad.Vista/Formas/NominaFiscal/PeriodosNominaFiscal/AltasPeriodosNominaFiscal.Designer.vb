<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AltasPeriodosNominaFiscal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasPeriodosNominaFiscal))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grbPeriodoAltas = New System.Windows.Forms.GroupBox()
        Me.NumDiasNomina = New System.Windows.Forms.NumericUpDown()
        Me.lblDiasNomina = New System.Windows.Forms.Label()
        Me.numFaltasSemana = New System.Windows.Forms.NumericUpDown()
        Me.lblFaltasSemana = New System.Windows.Forms.Label()
        Me.numFaltas = New System.Windows.Forms.NumericUpDown()
        Me.lblFaltasRet = New System.Windows.Forms.Label()
        Me.numRetardos = New System.Windows.Forms.NumericUpDown()
        Me.lblRetardos = New System.Windows.Forms.Label()
        Me.dtpFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaPago = New System.Windows.Forms.Label()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.numSemana = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoUnico = New System.Windows.Forms.RadioButton()
        Me.rdoTodos = New System.Windows.Forms.RadioButton()
        Me.lblSemana = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.lblFEchaFinal = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.lblGenerar = New System.Windows.Forms.Label()
        Me.lblAltasPeriodosNomina = New System.Windows.Forms.Label()
        Me.grdPeriodos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.grbPeriodoAltas.SuspendLayout()
        CType(Me.NumDiasNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFaltasSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFaltas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRetardos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.grdPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 522)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(704, 62)
        Me.pnlGuardarCancelar.TabIndex = 54
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnCncelar)
        Me.pnlBotonera.Controls.Add(Me.lblGuardar)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(504, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 62)
        Me.pnlBotonera.TabIndex = 4
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(156, 9)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 50
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(88, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 51
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(94, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 49
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(155, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 52
        Me.lblCancelar.Text = "Cerrar"
        '
        'grbPeriodoAltas
        '
        Me.grbPeriodoAltas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPeriodoAltas.Controls.Add(Me.NumDiasNomina)
        Me.grbPeriodoAltas.Controls.Add(Me.lblDiasNomina)
        Me.grbPeriodoAltas.Controls.Add(Me.numFaltasSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFaltasSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.numFaltas)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFaltasRet)
        Me.grbPeriodoAltas.Controls.Add(Me.numRetardos)
        Me.grbPeriodoAltas.Controls.Add(Me.lblRetardos)
        Me.grbPeriodoAltas.Controls.Add(Me.dtpFechaPago)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFechaPago)
        Me.grbPeriodoAltas.Controls.Add(Me.cmbPatron)
        Me.grbPeriodoAltas.Controls.Add(Me.numSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.GroupBox1)
        Me.grbPeriodoAltas.Controls.Add(Me.lblSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.dtpFechaFin)
        Me.grbPeriodoAltas.Controls.Add(Me.dtpFechaIni)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFEchaFinal)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFechaInicio)
        Me.grbPeriodoAltas.Controls.Add(Me.lblPatron)
        Me.grbPeriodoAltas.Location = New System.Drawing.Point(10, 66)
        Me.grbPeriodoAltas.Name = "grbPeriodoAltas"
        Me.grbPeriodoAltas.Size = New System.Drawing.Size(677, 126)
        Me.grbPeriodoAltas.TabIndex = 52
        Me.grbPeriodoAltas.TabStop = False
        '
        'NumDiasNomina
        '
        Me.NumDiasNomina.Location = New System.Drawing.Point(260, 96)
        Me.NumDiasNomina.Name = "NumDiasNomina"
        Me.NumDiasNomina.Size = New System.Drawing.Size(96, 20)
        Me.NumDiasNomina.TabIndex = 67
        Me.NumDiasNomina.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblDiasNomina
        '
        Me.lblDiasNomina.AutoSize = True
        Me.lblDiasNomina.Location = New System.Drawing.Point(201, 95)
        Me.lblDiasNomina.Name = "lblDiasNomina"
        Me.lblDiasNomina.Size = New System.Drawing.Size(43, 26)
        Me.lblDiasNomina.TabIndex = 66
        Me.lblDiasNomina.Text = "Días" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nómina"
        '
        'numFaltasSemana
        '
        Me.numFaltasSemana.Location = New System.Drawing.Point(87, 95)
        Me.numFaltasSemana.Name = "numFaltasSemana"
        Me.numFaltasSemana.Size = New System.Drawing.Size(96, 20)
        Me.numFaltasSemana.TabIndex = 49
        Me.numFaltasSemana.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'lblFaltasSemana
        '
        Me.lblFaltasSemana.AutoSize = True
        Me.lblFaltasSemana.Location = New System.Drawing.Point(7, 95)
        Me.lblFaltasSemana.Name = "lblFaltasSemana"
        Me.lblFaltasSemana.Size = New System.Drawing.Size(72, 26)
        Me.lblFaltasSemana.TabIndex = 48
        Me.lblFaltasSemana.Text = "Faltas totales " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Semana"
        '
        'numFaltas
        '
        Me.numFaltas.Location = New System.Drawing.Point(448, 69)
        Me.numFaltas.Name = "numFaltas"
        Me.numFaltas.Size = New System.Drawing.Size(96, 20)
        Me.numFaltas.TabIndex = 47
        '
        'lblFaltasRet
        '
        Me.lblFaltasRet.AutoSize = True
        Me.lblFaltasRet.Location = New System.Drawing.Point(377, 72)
        Me.lblFaltasRet.Name = "lblFaltasRet"
        Me.lblFaltasRet.Size = New System.Drawing.Size(35, 13)
        Me.lblFaltasRet.TabIndex = 46
        Me.lblFaltasRet.Text = "Faltas"
        '
        'numRetardos
        '
        Me.numRetardos.Location = New System.Drawing.Point(260, 70)
        Me.numRetardos.Name = "numRetardos"
        Me.numRetardos.Size = New System.Drawing.Size(96, 20)
        Me.numRetardos.TabIndex = 45
        Me.numRetardos.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblRetardos
        '
        Me.lblRetardos.AutoSize = True
        Me.lblRetardos.Location = New System.Drawing.Point(201, 72)
        Me.lblRetardos.Name = "lblRetardos"
        Me.lblRetardos.Size = New System.Drawing.Size(50, 13)
        Me.lblRetardos.TabIndex = 44
        Me.lblRetardos.Text = "Retardos"
        '
        'dtpFechaPago
        '
        Me.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPago.Location = New System.Drawing.Point(448, 43)
        Me.dtpFechaPago.Name = "dtpFechaPago"
        Me.dtpFechaPago.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaPago.TabIndex = 40
        '
        'lblFechaPago
        '
        Me.lblFechaPago.AutoSize = True
        Me.lblFechaPago.Location = New System.Drawing.Point(377, 46)
        Me.lblFechaPago.Name = "lblFechaPago"
        Me.lblFechaPago.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaPago.TabIndex = 40
        Me.lblFechaPago.Text = "Fecha Pago"
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.ForeColor = System.Drawing.Color.Black
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(87, 16)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(457, 21)
        Me.cmbPatron.TabIndex = 35
        '
        'numSemana
        '
        Me.numSemana.Location = New System.Drawing.Point(87, 69)
        Me.numSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemana.Name = "numSemana"
        Me.numSemana.Size = New System.Drawing.Size(96, 20)
        Me.numSemana.TabIndex = 43
        Me.numSemana.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoUnico)
        Me.GroupBox1.Controls.Add(Me.rdoTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(573, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(94, 80)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        '
        'rdoUnico
        '
        Me.rdoUnico.AutoSize = True
        Me.rdoUnico.Location = New System.Drawing.Point(17, 46)
        Me.rdoUnico.Name = "rdoUnico"
        Me.rdoUnico.Size = New System.Drawing.Size(53, 17)
        Me.rdoUnico.TabIndex = 1
        Me.rdoUnico.Text = "Único"
        Me.rdoUnico.UseVisualStyleBackColor = True
        '
        'rdoTodos
        '
        Me.rdoTodos.AutoSize = True
        Me.rdoTodos.Checked = True
        Me.rdoTodos.Location = New System.Drawing.Point(16, 22)
        Me.rdoTodos.Name = "rdoTodos"
        Me.rdoTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdoTodos.TabIndex = 0
        Me.rdoTodos.TabStop = True
        Me.rdoTodos.Text = "Todos"
        Me.rdoTodos.UseVisualStyleBackColor = True
        '
        'lblSemana
        '
        Me.lblSemana.AutoSize = True
        Me.lblSemana.Location = New System.Drawing.Point(7, 72)
        Me.lblSemana.Name = "lblSemana"
        Me.lblSemana.Size = New System.Drawing.Size(74, 13)
        Me.lblSemana.TabIndex = 42
        Me.lblSemana.Text = "Semana Inicio"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(260, 43)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaFin.TabIndex = 39
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(87, 43)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaIni.TabIndex = 37
        '
        'lblFEchaFinal
        '
        Me.lblFEchaFinal.AutoSize = True
        Me.lblFEchaFinal.Location = New System.Drawing.Point(189, 46)
        Me.lblFEchaFinal.Name = "lblFEchaFinal"
        Me.lblFEchaFinal.Size = New System.Drawing.Size(62, 13)
        Me.lblFEchaFinal.TabIndex = 38
        Me.lblFEchaFinal.Text = "Fecha Final"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(7, 46)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(67, 13)
        Me.lblFechaInicio.TabIndex = 36
        Me.lblFechaInicio.Text = "Fecha Inicial"
        '
        'lblPatron
        '
        Me.lblPatron.AutoSize = True
        Me.lblPatron.Location = New System.Drawing.Point(7, 19)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(38, 13)
        Me.lblPatron.TabIndex = 34
        Me.lblPatron.Text = "Patrón"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.btnGenerar)
        Me.pnlEncabezado.Controls.Add(Me.lblGenerar)
        Me.pnlEncabezado.Controls.Add(Me.lblAltasPeriodosNomina)
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(697, 60)
        Me.pnlEncabezado.TabIndex = 51
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.Location = New System.Drawing.Point(17, 10)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(32, 30)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'lblGenerar
        '
        Me.lblGenerar.AutoSize = True
        Me.lblGenerar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerar.Location = New System.Drawing.Point(10, 42)
        Me.lblGenerar.Name = "lblGenerar"
        Me.lblGenerar.Size = New System.Drawing.Size(45, 13)
        Me.lblGenerar.TabIndex = 35
        Me.lblGenerar.Text = "Generar"
        '
        'lblAltasPeriodosNomina
        '
        Me.lblAltasPeriodosNomina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAltasPeriodosNomina.AutoSize = True
        Me.lblAltasPeriodosNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltasPeriodosNomina.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAltasPeriodosNomina.Location = New System.Drawing.Point(340, 18)
        Me.lblAltasPeriodosNomina.Name = "lblAltasPeriodosNomina"
        Me.lblAltasPeriodosNomina.Size = New System.Drawing.Size(283, 20)
        Me.lblAltasPeriodosNomina.TabIndex = 21
        Me.lblAltasPeriodosNomina.Text = "Alta de Periodos de Nómina Fiscal"
        '
        'grdPeriodos
        '
        Me.grdPeriodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPeriodos.CausesValidation = False
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPeriodos.DisplayLayout.Appearance = Appearance1
        Me.grdPeriodos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdPeriodos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPeriodos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdPeriodos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdPeriodos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPeriodos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdPeriodos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPeriodos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdPeriodos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPeriodos.Location = New System.Drawing.Point(10, 198)
        Me.grdPeriodos.Name = "grdPeriodos"
        Me.grdPeriodos.Size = New System.Drawing.Size(674, 312)
        Me.grdPeriodos.TabIndex = 67
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(625, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 51
        Me.imgLogo.TabStop = False
        '
        'AltasPeriodosNominaFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(704, 584)
        Me.Controls.Add(Me.grdPeriodos)
        Me.Controls.Add(Me.pnlGuardarCancelar)
        Me.Controls.Add(Me.grbPeriodoAltas)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(712, 611)
        Me.MinimumSize = New System.Drawing.Size(712, 611)
        Me.Name = "AltasPeriodosNominaFiscal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Altas Periodos Nomina Fiscal"
        Me.pnlGuardarCancelar.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        Me.grbPeriodoAltas.ResumeLayout(False)
        Me.grbPeriodoAltas.PerformLayout()
        CType(Me.NumDiasNomina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFaltasSemana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFaltas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRetardos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.grdPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlGuardarCancelar As Windows.Forms.Panel
    Friend WithEvents pnlBotonera As Windows.Forms.Panel
    Friend WithEvents btnCncelar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents grbPeriodoAltas As Windows.Forms.GroupBox
    Friend WithEvents lblSemana As Windows.Forms.Label
    Friend WithEvents dtpFechaFin As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaIni As Windows.Forms.DateTimePicker
    Friend WithEvents lblFEchaFinal As Windows.Forms.Label
    Friend WithEvents lblFechaInicio As Windows.Forms.Label
    Friend WithEvents lblPatron As Windows.Forms.Label
    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents btnGenerar As Windows.Forms.Button
    Friend WithEvents lblGenerar As Windows.Forms.Label
    Friend WithEvents lblAltasPeriodosNomina As Windows.Forms.Label
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents rdoUnico As Windows.Forms.RadioButton
    Friend WithEvents rdoTodos As Windows.Forms.RadioButton
    Friend WithEvents grdPeriodos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents numSemana As Windows.Forms.NumericUpDown
    Friend WithEvents cmbPatron As Windows.Forms.ComboBox
    Friend WithEvents dtpFechaPago As Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaPago As Windows.Forms.Label
    Friend WithEvents numFaltas As Windows.Forms.NumericUpDown
    Friend WithEvents lblFaltasRet As Windows.Forms.Label
    Friend WithEvents numRetardos As Windows.Forms.NumericUpDown
    Friend WithEvents lblRetardos As Windows.Forms.Label
    Friend WithEvents lblFaltasSemana As Windows.Forms.Label
    Friend WithEvents numFaltasSemana As Windows.Forms.NumericUpDown
    Friend WithEvents NumDiasNomina As Windows.Forms.NumericUpDown
    Friend WithEvents lblDiasNomina As Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
