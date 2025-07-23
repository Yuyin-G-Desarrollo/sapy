<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarPeriodosNominaFiscal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarPeriodosNominaFiscal))
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grbPeriodoAltas = New System.Windows.Forms.GroupBox()
        Me.NumDiasNomina = New System.Windows.Forms.NumericUpDown()
        Me.lblDiasNomina = New System.Windows.Forms.Label()
        Me.numBimestre = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numFaltasSemana = New System.Windows.Forms.NumericUpDown()
        Me.lblFaltasSemana = New System.Windows.Forms.Label()
        Me.numFaltas = New System.Windows.Forms.NumericUpDown()
        Me.lblFaltasRet = New System.Windows.Forms.Label()
        Me.numRetardos = New System.Windows.Forms.NumericUpDown()
        Me.lblRetardos = New System.Windows.Forms.Label()
        Me.dtpFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaPago = New System.Windows.Forms.Label()
        Me.numSemana = New System.Windows.Forms.NumericUpDown()
        Me.lblSemana = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.lblFEchaFinal = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblAltasPeriodosNomina = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.grbPeriodoAltas.SuspendLayout()
        CType(Me.NumDiasNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBimestre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFaltasSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFaltas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRetardos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 200)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(579, 62)
        Me.pnlGuardarCancelar.TabIndex = 70
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnCncelar)
        Me.pnlBotonera.Controls.Add(Me.lblGuardar)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(452, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(127, 62)
        Me.pnlBotonera.TabIndex = 4
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(83, 9)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 50
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(22, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 51
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(28, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 49
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(82, 40)
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
        Me.grbPeriodoAltas.Controls.Add(Me.numBimestre)
        Me.grbPeriodoAltas.Controls.Add(Me.Label1)
        Me.grbPeriodoAltas.Controls.Add(Me.numFaltasSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFaltasSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.numFaltas)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFaltasRet)
        Me.grbPeriodoAltas.Controls.Add(Me.numRetardos)
        Me.grbPeriodoAltas.Controls.Add(Me.lblRetardos)
        Me.grbPeriodoAltas.Controls.Add(Me.dtpFechaPago)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFechaPago)
        Me.grbPeriodoAltas.Controls.Add(Me.numSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.lblSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.dtpFechaFin)
        Me.grbPeriodoAltas.Controls.Add(Me.dtpFechaIni)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFEchaFinal)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFechaInicio)
        Me.grbPeriodoAltas.Location = New System.Drawing.Point(10, 66)
        Me.grbPeriodoAltas.Name = "grbPeriodoAltas"
        Me.grbPeriodoAltas.Size = New System.Drawing.Size(560, 126)
        Me.grbPeriodoAltas.TabIndex = 69
        Me.grbPeriodoAltas.TabStop = False
        '
        'NumDiasNomina
        '
        Me.NumDiasNomina.Location = New System.Drawing.Point(448, 49)
        Me.NumDiasNomina.Name = "NumDiasNomina"
        Me.NumDiasNomina.Size = New System.Drawing.Size(96, 20)
        Me.NumDiasNomina.TabIndex = 65
        Me.NumDiasNomina.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblDiasNomina
        '
        Me.lblDiasNomina.AutoSize = True
        Me.lblDiasNomina.Location = New System.Drawing.Point(368, 51)
        Me.lblDiasNomina.Name = "lblDiasNomina"
        Me.lblDiasNomina.Size = New System.Drawing.Size(69, 13)
        Me.lblDiasNomina.TabIndex = 64
        Me.lblDiasNomina.Text = "Días Nómina"
        '
        'numBimestre
        '
        Me.numBimestre.Location = New System.Drawing.Point(260, 52)
        Me.numBimestre.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.numBimestre.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numBimestre.Name = "numBimestre"
        Me.numBimestre.Size = New System.Drawing.Size(96, 20)
        Me.numBimestre.TabIndex = 63
        Me.numBimestre.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(189, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Bimestre"
        '
        'numFaltasSemana
        '
        Me.numFaltasSemana.Location = New System.Drawing.Point(448, 80)
        Me.numFaltasSemana.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numFaltasSemana.Name = "numFaltasSemana"
        Me.numFaltasSemana.Size = New System.Drawing.Size(96, 20)
        Me.numFaltasSemana.TabIndex = 61
        Me.numFaltasSemana.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'lblFaltasSemana
        '
        Me.lblFaltasSemana.AutoSize = True
        Me.lblFaltasSemana.Location = New System.Drawing.Point(368, 77)
        Me.lblFaltasSemana.Name = "lblFaltasSemana"
        Me.lblFaltasSemana.Size = New System.Drawing.Size(72, 26)
        Me.lblFaltasSemana.TabIndex = 60
        Me.lblFaltasSemana.Text = "Faltas totales " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Semana"
        '
        'numFaltas
        '
        Me.numFaltas.Location = New System.Drawing.Point(260, 80)
        Me.numFaltas.Name = "numFaltas"
        Me.numFaltas.Size = New System.Drawing.Size(96, 20)
        Me.numFaltas.TabIndex = 55
        Me.numFaltas.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblFaltasRet
        '
        Me.lblFaltasRet.AutoSize = True
        Me.lblFaltasRet.Location = New System.Drawing.Point(189, 83)
        Me.lblFaltasRet.Name = "lblFaltasRet"
        Me.lblFaltasRet.Size = New System.Drawing.Size(35, 13)
        Me.lblFaltasRet.TabIndex = 54
        Me.lblFaltasRet.Text = "Faltas"
        '
        'numRetardos
        '
        Me.numRetardos.Location = New System.Drawing.Point(80, 80)
        Me.numRetardos.Name = "numRetardos"
        Me.numRetardos.Size = New System.Drawing.Size(96, 20)
        Me.numRetardos.TabIndex = 53
        Me.numRetardos.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblRetardos
        '
        Me.lblRetardos.AutoSize = True
        Me.lblRetardos.Location = New System.Drawing.Point(7, 83)
        Me.lblRetardos.Name = "lblRetardos"
        Me.lblRetardos.Size = New System.Drawing.Size(50, 13)
        Me.lblRetardos.TabIndex = 52
        Me.lblRetardos.Text = "Retardos"
        '
        'dtpFechaPago
        '
        Me.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPago.Location = New System.Drawing.Point(448, 23)
        Me.dtpFechaPago.Name = "dtpFechaPago"
        Me.dtpFechaPago.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaPago.TabIndex = 51
        '
        'lblFechaPago
        '
        Me.lblFechaPago.AutoSize = True
        Me.lblFechaPago.Location = New System.Drawing.Point(368, 26)
        Me.lblFechaPago.Name = "lblFechaPago"
        Me.lblFechaPago.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaPago.TabIndex = 50
        Me.lblFechaPago.Text = "Fecha Pago"
        '
        'numSemana
        '
        Me.numSemana.Location = New System.Drawing.Point(80, 52)
        Me.numSemana.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numSemana.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemana.Name = "numSemana"
        Me.numSemana.Size = New System.Drawing.Size(96, 20)
        Me.numSemana.TabIndex = 48
        Me.numSemana.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblSemana
        '
        Me.lblSemana.AutoSize = True
        Me.lblSemana.Location = New System.Drawing.Point(7, 55)
        Me.lblSemana.Name = "lblSemana"
        Me.lblSemana.Size = New System.Drawing.Size(46, 13)
        Me.lblSemana.TabIndex = 45
        Me.lblSemana.Text = "Semana"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(260, 23)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaFin.TabIndex = 38
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIni.Location = New System.Drawing.Point(80, 23)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaIni.TabIndex = 37
        '
        'lblFEchaFinal
        '
        Me.lblFEchaFinal.AutoSize = True
        Me.lblFEchaFinal.Location = New System.Drawing.Point(189, 26)
        Me.lblFEchaFinal.Name = "lblFEchaFinal"
        Me.lblFEchaFinal.Size = New System.Drawing.Size(62, 13)
        Me.lblFEchaFinal.TabIndex = 36
        Me.lblFEchaFinal.Text = "Fecha Final"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(7, 26)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(67, 13)
        Me.lblFechaInicio.TabIndex = 35
        Me.lblFechaInicio.Text = "Fecha Inicial"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.lblAltasPeriodosNomina)
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(580, 60)
        Me.pnlEncabezado.TabIndex = 68
        '
        'lblAltasPeriodosNomina
        '
        Me.lblAltasPeriodosNomina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAltasPeriodosNomina.AutoSize = True
        Me.lblAltasPeriodosNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltasPeriodosNomina.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAltasPeriodosNomina.Location = New System.Drawing.Point(195, 19)
        Me.lblAltasPeriodosNomina.Name = "lblAltasPeriodosNomina"
        Me.lblAltasPeriodosNomina.Size = New System.Drawing.Size(310, 20)
        Me.lblAltasPeriodosNomina.TabIndex = 21
        Me.lblAltasPeriodosNomina.Text = "Edición de Periodos de Nómina Fiscal"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(508, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 51
        Me.imgLogo.TabStop = False
        '
        'EditarPeriodosNominaFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(579, 262)
        Me.Controls.Add(Me.pnlGuardarCancelar)
        Me.Controls.Add(Me.grbPeriodoAltas)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "EditarPeriodosNominaFiscal"
        Me.pnlGuardarCancelar.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        Me.grbPeriodoAltas.ResumeLayout(False)
        Me.grbPeriodoAltas.PerformLayout()
        CType(Me.NumDiasNomina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBimestre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFaltasSemana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFaltas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRetardos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
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
    Friend WithEvents numFaltasSemana As Windows.Forms.NumericUpDown
    Friend WithEvents lblFaltasSemana As Windows.Forms.Label
    Friend WithEvents numFaltas As Windows.Forms.NumericUpDown
    Friend WithEvents lblFaltasRet As Windows.Forms.Label
    Friend WithEvents numRetardos As Windows.Forms.NumericUpDown
    Friend WithEvents lblRetardos As Windows.Forms.Label
    Friend WithEvents dtpFechaPago As Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaPago As Windows.Forms.Label
    Friend WithEvents numSemana As Windows.Forms.NumericUpDown
    Friend WithEvents lblSemana As Windows.Forms.Label
    Friend WithEvents dtpFechaFin As Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaIni As Windows.Forms.DateTimePicker
    Friend WithEvents lblFEchaFinal As Windows.Forms.Label
    Friend WithEvents lblFechaInicio As Windows.Forms.Label
    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents lblAltasPeriodosNomina As Windows.Forms.Label
    Friend WithEvents numBimestre As Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblDiasNomina As Windows.Forms.Label
    Friend WithEvents NumDiasNomina As Windows.Forms.NumericUpDown
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
