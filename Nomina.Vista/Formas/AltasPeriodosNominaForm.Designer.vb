<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasPeriodosNominaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltasPeriodosNominaForm))
        Me.grbPeriodoAltas = New System.Windows.Forms.GroupBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.txtEstatus = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.txtSemana = New System.Windows.Forms.TextBox()
        Me.lblSemana = New System.Windows.Forms.Label()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFEchaFinal = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblNaves = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.lblGenerar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblAltasPeriodosNomina = New System.Windows.Forms.Label()
        Me.CgrdPeriodos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.grbPeriodoAltas.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.CgrdPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbPeriodoAltas
        '
        Me.grbPeriodoAltas.Controls.Add(Me.cmbEstado)
        Me.grbPeriodoAltas.Controls.Add(Me.txtEstatus)
        Me.grbPeriodoAltas.Controls.Add(Me.Label1)
        Me.grbPeriodoAltas.Controls.Add(Me.txtConcepto)
        Me.grbPeriodoAltas.Controls.Add(Me.lblConcepto)
        Me.grbPeriodoAltas.Controls.Add(Me.txtSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.lblSemana)
        Me.grbPeriodoAltas.Controls.Add(Me.dtpFinal)
        Me.grbPeriodoAltas.Controls.Add(Me.dtpInicio)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFEchaFinal)
        Me.grbPeriodoAltas.Controls.Add(Me.lblFechaInicio)
        Me.grbPeriodoAltas.Controls.Add(Me.lblNaves)
        Me.grbPeriodoAltas.Controls.Add(Me.cmbNaves)
        Me.grbPeriodoAltas.Location = New System.Drawing.Point(10, 66)
        Me.grbPeriodoAltas.Name = "grbPeriodoAltas"
        Me.grbPeriodoAltas.Size = New System.Drawing.Size(495, 126)
        Me.grbPeriodoAltas.TabIndex = 12
        Me.grbPeriodoAltas.TabStop = False
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"ACTIVO", "BLOQUEADO", "CERRADO"})
        Me.cmbEstado.Location = New System.Drawing.Point(164, 152)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(198, 21)
        Me.cmbEstado.TabIndex = 55
        Me.cmbEstado.Visible = False
        '
        'txtEstatus
        '
        Me.txtEstatus.Location = New System.Drawing.Point(334, 39)
        Me.txtEstatus.Name = "txtEstatus"
        Me.txtEstatus.Size = New System.Drawing.Size(64, 20)
        Me.txtEstatus.TabIndex = 54
        Me.txtEstatus.Text = "Bloqueado"
        Me.txtEstatus.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Estatus"
        Me.Label1.Visible = False
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(164, 124)
        Me.txtConcepto.MaxLength = 100
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(277, 20)
        Me.txtConcepto.TabIndex = 48
        Me.txtConcepto.Visible = False
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Location = New System.Drawing.Point(81, 127)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(53, 13)
        Me.lblConcepto.TabIndex = 47
        Me.lblConcepto.Text = "Concepto"
        Me.lblConcepto.Visible = False
        '
        'txtSemana
        '
        Me.txtSemana.Location = New System.Drawing.Point(159, 43)
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.Size = New System.Drawing.Size(62, 20)
        Me.txtSemana.TabIndex = 46
        '
        'lblSemana
        '
        Me.lblSemana.AutoSize = True
        Me.lblSemana.Location = New System.Drawing.Point(74, 46)
        Me.lblSemana.Name = "lblSemana"
        Me.lblSemana.Size = New System.Drawing.Size(81, 13)
        Me.lblSemana.TabIndex = 45
        Me.lblSemana.Text = "* Semana Inicio"
        '
        'dtpFinal
        '
        Me.dtpFinal.Location = New System.Drawing.Point(157, 95)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(277, 20)
        Me.dtpFinal.TabIndex = 38
        '
        'dtpInicio
        '
        Me.dtpInicio.Location = New System.Drawing.Point(159, 69)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(277, 20)
        Me.dtpInicio.TabIndex = 37
        '
        'lblFEchaFinal
        '
        Me.lblFEchaFinal.AutoSize = True
        Me.lblFEchaFinal.Location = New System.Drawing.Point(74, 98)
        Me.lblFEchaFinal.Name = "lblFEchaFinal"
        Me.lblFEchaFinal.Size = New System.Drawing.Size(69, 13)
        Me.lblFEchaFinal.TabIndex = 36
        Me.lblFEchaFinal.Text = "* Fecha Final"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(74, 72)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaInicio.TabIndex = 35
        Me.lblFechaInicio.Text = "* Fecha Inicial"
        '
        'lblNaves
        '
        Me.lblNaves.AutoSize = True
        Me.lblNaves.Location = New System.Drawing.Point(74, 20)
        Me.lblNaves.Name = "lblNaves"
        Me.lblNaves.Size = New System.Drawing.Size(40, 13)
        Me.lblNaves.TabIndex = 34
        Me.lblNaves.Text = "* Nave"
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(157, 16)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(277, 21)
        Me.cmbNaves.TabIndex = 33
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
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(94, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 49
        Me.btnGuardar.UseVisualStyleBackColor = True
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
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(156, 9)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 50
        Me.btnCncelar.UseVisualStyleBackColor = True
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
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnGenerar)
        Me.pnlEncabezado.Controls.Add(Me.lblGenerar)
        Me.pnlEncabezado.Controls.Add(Me.lblAltasPeriodosNomina)
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(515, 60)
        Me.pnlEncabezado.TabIndex = 11
        '
        'lblAltasPeriodosNomina
        '
        Me.lblAltasPeriodosNomina.AutoSize = True
        Me.lblAltasPeriodosNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltasPeriodosNomina.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAltasPeriodosNomina.Location = New System.Drawing.Point(217, 18)
        Me.lblAltasPeriodosNomina.Name = "lblAltasPeriodosNomina"
        Me.lblAltasPeriodosNomina.Size = New System.Drawing.Size(231, 20)
        Me.lblAltasPeriodosNomina.TabIndex = 21
        Me.lblAltasPeriodosNomina.Text = "Alta de Periodos de Nómina"
        '
        'CgrdPeriodos
        '
        Me.CgrdPeriodos.AllowDelete = True
        Me.CgrdPeriodos.AllowEditing = False
        Me.CgrdPeriodos.ColumnInfo = resources.GetString("CgrdPeriodos.ColumnInfo")
        Me.CgrdPeriodos.ExtendLastCol = True
        Me.CgrdPeriodos.Location = New System.Drawing.Point(10, 198)
        Me.CgrdPeriodos.Name = "CgrdPeriodos"
        Me.CgrdPeriodos.Rows.Count = 1
        Me.CgrdPeriodos.Rows.DefaultSize = 19
        Me.CgrdPeriodos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.CgrdPeriodos.Size = New System.Drawing.Size(492, 312)
        Me.CgrdPeriodos.StyleInfo = resources.GetString("CgrdPeriodos.StyleInfo")
        Me.CgrdPeriodos.TabIndex = 49
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 527)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(524, 62)
        Me.pnlGuardarCancelar.TabIndex = 50
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnCncelar)
        Me.pnlBotonera.Controls.Add(Me.lblGuardar)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(324, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 62)
        Me.pnlBotonera.TabIndex = 4
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(447, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 51
        Me.pcbTitulo.TabStop = False
        '
        'AltasPeriodosNominaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(524, 589)
        Me.Controls.Add(Me.pnlGuardarCancelar)
        Me.Controls.Add(Me.CgrdPeriodos)
        Me.Controls.Add(Me.grbPeriodoAltas)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(530, 611)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(530, 611)
        Me.Name = "AltasPeriodosNominaForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de Periodos de Nómina"
        Me.grbPeriodoAltas.ResumeLayout(False)
        Me.grbPeriodoAltas.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.CgrdPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGuardarCancelar.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbPeriodoAltas As System.Windows.Forms.GroupBox
	Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
	Friend WithEvents lblConcepto As System.Windows.Forms.Label
	Friend WithEvents txtSemana As System.Windows.Forms.TextBox
	Friend WithEvents lblSemana As System.Windows.Forms.Label
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
	Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
	Friend WithEvents lblFEchaFinal As System.Windows.Forms.Label
	Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
	Friend WithEvents lblNaves As System.Windows.Forms.Label
	Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents btnGenerar As System.Windows.Forms.Button
	Friend WithEvents lblGenerar As System.Windows.Forms.Label
	Friend WithEvents lblAltasPeriodosNomina As System.Windows.Forms.Label
    Friend WithEvents CgrdPeriodos As C1.Win.C1FlexGrid.C1FlexGrid
	Friend WithEvents lblCancelar As System.Windows.Forms.Label
	Friend WithEvents lblGuardar As System.Windows.Forms.Label
	Friend WithEvents btnGuardar As System.Windows.Forms.Button
	Friend WithEvents btnCncelar As System.Windows.Forms.Button
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtEstatus As System.Windows.Forms.TextBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents pnlGuardarCancelar As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As PictureBox
End Class
