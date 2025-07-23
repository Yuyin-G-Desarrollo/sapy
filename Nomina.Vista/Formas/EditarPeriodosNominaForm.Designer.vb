<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarPeriodosNominaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarPeriodosNominaForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.CgrdPeriodos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.txtSemana = New System.Windows.Forms.TextBox()
        Me.lblSemana = New System.Windows.Forms.Label()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFEchaFinal = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.lblNaves = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblGenerar = New System.Windows.Forms.Label()
        Me.lblEditarPeriodosNomina = New System.Windows.Forms.Label()
        Me.periodos = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblEstados = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNoSemana = New System.Windows.Forms.TextBox()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpIni = New System.Windows.Forms.DateTimePicker()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlGuardarCancelar = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdPeriodos = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.CgrdPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.periodos.SuspendLayout()
        Me.pnlGuardarCancelar.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        CType(Me.grdPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.CgrdPeriodos)
        Me.pnlEncabezado.Controls.Add(Me.GroupBox1)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblGenerar)
        Me.pnlEncabezado.Controls.Add(Me.lblEditarPeriodosNomina)
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 2)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(514, 60)
        Me.pnlEncabezado.TabIndex = 12
        '
        'CgrdPeriodos
        '
        Me.CgrdPeriodos.AllowDelete = True
        Me.CgrdPeriodos.ColumnInfo = resources.GetString("CgrdPeriodos.ColumnInfo")
        Me.CgrdPeriodos.ExtendLastCol = True
        Me.CgrdPeriodos.Location = New System.Drawing.Point(13, 146)
        Me.CgrdPeriodos.Name = "CgrdPeriodos"
        Me.CgrdPeriodos.Rows.Count = 1
        Me.CgrdPeriodos.Rows.DefaultSize = 19
        Me.CgrdPeriodos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.CgrdPeriodos.Size = New System.Drawing.Size(616, 247)
        Me.CgrdPeriodos.TabIndex = 51
        Me.CgrdPeriodos.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCancelar)
        Me.GroupBox1.Controls.Add(Me.lblGuardar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.btnCncelar)
        Me.GroupBox1.Controls.Add(Me.txtConcepto)
        Me.GroupBox1.Controls.Add(Me.lblConcepto)
        Me.GroupBox1.Controls.Add(Me.txtSemana)
        Me.GroupBox1.Controls.Add(Me.lblSemana)
        Me.GroupBox1.Controls.Add(Me.btnAbajo)
        Me.GroupBox1.Controls.Add(Me.btnArriba)
        Me.GroupBox1.Controls.Add(Me.dtpFinal)
        Me.GroupBox1.Controls.Add(Me.dtpInicio)
        Me.GroupBox1.Controls.Add(Me.lblFEchaFinal)
        Me.GroupBox1.Controls.Add(Me.lblFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblNaves)
        Me.GroupBox1.Controls.Add(Me.cmbNaves)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(616, 173)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "                    "
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(552, 142)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 52
        Me.lblCancelar.Text = "Cancelar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(476, 142)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 51
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(482, 104)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 49
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = CType(resources.GetObject("btnCncelar.Image"), System.Drawing.Image)
        Me.btnCncelar.Location = New System.Drawing.Point(558, 104)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 50
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(92, 108)
        Me.txtConcepto.MaxLength = 100
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(200, 20)
        Me.txtConcepto.TabIndex = 48
        Me.txtConcepto.Visible = False
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Location = New System.Drawing.Point(30, 108)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(53, 13)
        Me.lblConcepto.TabIndex = 47
        Me.lblConcepto.Text = "Concepto"
        Me.lblConcepto.Visible = False
        '
        'txtSemana
        '
        Me.txtSemana.Location = New System.Drawing.Point(406, 33)
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.Size = New System.Drawing.Size(100, 20)
        Me.txtSemana.TabIndex = 46
        '
        'lblSemana
        '
        Me.lblSemana.AutoSize = True
        Me.lblSemana.Location = New System.Drawing.Point(321, 33)
        Me.lblSemana.Name = "lblSemana"
        Me.lblSemana.Size = New System.Drawing.Size(74, 13)
        Me.lblSemana.TabIndex = 45
        Me.lblSemana.Text = "Semana Inicio"
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(589, 14)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 40
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(558, 13)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 39
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'dtpFinal
        '
        Me.dtpFinal.Location = New System.Drawing.Point(395, 67)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(200, 20)
        Me.dtpFinal.TabIndex = 38
        '
        'dtpInicio
        '
        Me.dtpInicio.Location = New System.Drawing.Point(92, 67)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(200, 20)
        Me.dtpInicio.TabIndex = 37
        '
        'lblFEchaFinal
        '
        Me.lblFEchaFinal.AutoSize = True
        Me.lblFEchaFinal.Location = New System.Drawing.Point(321, 67)
        Me.lblFEchaFinal.Name = "lblFEchaFinal"
        Me.lblFEchaFinal.Size = New System.Drawing.Size(68, 13)
        Me.lblFEchaFinal.TabIndex = 36
        Me.lblFEchaFinal.Text = "Fecha Final :"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(13, 67)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(73, 13)
        Me.lblFechaInicio.TabIndex = 35
        Me.lblFechaInicio.Text = "Fecha Inicial :"
        '
        'lblNaves
        '
        Me.lblNaves.AutoSize = True
        Me.lblNaves.Location = New System.Drawing.Point(45, 33)
        Me.lblNaves.Name = "lblNaves"
        Me.lblNaves.Size = New System.Drawing.Size(38, 13)
        Me.lblNaves.TabIndex = 34
        Me.lblNaves.Text = "Naves"
        '
        'cmbNaves
        '
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(92, 30)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(200, 21)
        Me.cmbNaves.TabIndex = 33
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(20, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblGenerar
        '
        Me.lblGenerar.AutoSize = True
        Me.lblGenerar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerar.Location = New System.Drawing.Point(15, 40)
        Me.lblGenerar.Name = "lblGenerar"
        Me.lblGenerar.Size = New System.Drawing.Size(45, 13)
        Me.lblGenerar.TabIndex = 35
        Me.lblGenerar.Text = "Generar"
        '
        'lblEditarPeriodosNomina
        '
        Me.lblEditarPeriodosNomina.AutoSize = True
        Me.lblEditarPeriodosNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarPeriodosNomina.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEditarPeriodosNomina.Location = New System.Drawing.Point(227, 18)
        Me.lblEditarPeriodosNomina.Name = "lblEditarPeriodosNomina"
        Me.lblEditarPeriodosNomina.Size = New System.Drawing.Size(222, 20)
        Me.lblEditarPeriodosNomina.TabIndex = 21
        Me.lblEditarPeriodosNomina.Text = "Editar Periodos de Nómina"
        '
        'periodos
        '
        Me.periodos.Controls.Add(Me.Label4)
        Me.periodos.Controls.Add(Me.Label5)
        Me.periodos.Controls.Add(Me.Label6)
        Me.periodos.Controls.Add(Me.Label7)
        Me.periodos.Controls.Add(Me.cmbEstado)
        Me.periodos.Controls.Add(Me.lblEstados)
        Me.periodos.Controls.Add(Me.TextBox1)
        Me.periodos.Controls.Add(Me.Label3)
        Me.periodos.Controls.Add(Me.txtNoSemana)
        Me.periodos.Controls.Add(Me.dtpFin)
        Me.periodos.Controls.Add(Me.dtpIni)
        Me.periodos.Controls.Add(Me.cmbNave)
        Me.periodos.Location = New System.Drawing.Point(10, 66)
        Me.periodos.Name = "periodos"
        Me.periodos.Size = New System.Drawing.Size(495, 126)
        Me.periodos.TabIndex = 50
        Me.periodos.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(64, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "* Semana Inicio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(64, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "* Fecha Final"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(64, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "* Fecha Inicial"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(64, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "* Nave"
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"ACTIVO", "BLOQUEADO", "CERRADO"})
        Me.cmbEstado.Location = New System.Drawing.Point(395, 117)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 57
        Me.cmbEstado.Visible = False
        '
        'lblEstados
        '
        Me.lblEstados.AutoSize = True
        Me.lblEstados.Location = New System.Drawing.Point(345, 120)
        Me.lblEstados.Name = "lblEstados"
        Me.lblEstados.Size = New System.Drawing.Size(42, 13)
        Me.lblEstados.TabIndex = 56
        Me.lblEstados.Text = "Estatus"
        Me.lblEstados.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(92, 123)
        Me.TextBox1.MaxLength = 100
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(200, 20)
        Me.TextBox1.TabIndex = 48
        Me.TextBox1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Concepto"
        Me.Label3.Visible = False
        '
        'txtNoSemana
        '
        Me.txtNoSemana.Location = New System.Drawing.Point(156, 44)
        Me.txtNoSemana.Name = "txtNoSemana"
        Me.txtNoSemana.Size = New System.Drawing.Size(62, 20)
        Me.txtNoSemana.TabIndex = 46
        '
        'dtpFin
        '
        Me.dtpFin.Location = New System.Drawing.Point(156, 96)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(277, 20)
        Me.dtpFin.TabIndex = 38
        '
        'dtpIni
        '
        Me.dtpIni.Location = New System.Drawing.Point(156, 71)
        Me.dtpIni.Name = "dtpIni"
        Me.dtpIni.Size = New System.Drawing.Size(277, 20)
        Me.dtpIni.TabIndex = 37
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(156, 17)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(277, 21)
        Me.cmbNave.TabIndex = 33
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(94, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 49
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.Button2.Location = New System.Drawing.Point(156, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 50
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnlGuardarCancelar
        '
        Me.pnlGuardarCancelar.Controls.Add(Me.pnlBotonera)
        Me.pnlGuardarCancelar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGuardarCancelar.Location = New System.Drawing.Point(0, 527)
        Me.pnlGuardarCancelar.Name = "pnlGuardarCancelar"
        Me.pnlGuardarCancelar.Size = New System.Drawing.Size(524, 62)
        Me.pnlGuardarCancelar.TabIndex = 52
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.Label1)
        Me.pnlBotonera.Controls.Add(Me.Label2)
        Me.pnlBotonera.Controls.Add(Me.Button2)
        Me.pnlBotonera.Controls.Add(Me.Button1)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(324, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 62)
        Me.pnlBotonera.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(88, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Guardar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(155, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Cerrar"
        '
        'grdPeriodos
        '
        Me.grdPeriodos.AllowDelete = True
        Me.grdPeriodos.AllowEditing = False
        Me.grdPeriodos.ColumnInfo = resources.GetString("grdPeriodos.ColumnInfo")
        Me.grdPeriodos.ExtendLastCol = True
        Me.grdPeriodos.Location = New System.Drawing.Point(10, 198)
        Me.grdPeriodos.Name = "grdPeriodos"
        Me.grdPeriodos.Rows.Count = 1
        Me.grdPeriodos.Rows.DefaultSize = 19
        Me.grdPeriodos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdPeriodos.Size = New System.Drawing.Size(492, 312)
        Me.grdPeriodos.StyleInfo = resources.GetString("grdPeriodos.StyleInfo")
        Me.grdPeriodos.TabIndex = 53
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(446, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 53
        Me.pcbTitulo.TabStop = False
        '
        'EditarPeriodosNominaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(524, 589)
        Me.Controls.Add(Me.grdPeriodos)
        Me.Controls.Add(Me.pnlGuardarCancelar)
        Me.Controls.Add(Me.periodos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(530, 611)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(530, 611)
        Me.Name = "EditarPeriodosNominaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Periodos Nomina"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.CgrdPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.periodos.ResumeLayout(False)
        Me.periodos.PerformLayout()
        Me.pnlGuardarCancelar.ResumeLayout(False)
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        CType(Me.grdPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblGenerar As System.Windows.Forms.Label
    Friend WithEvents lblEditarPeriodosNomina As System.Windows.Forms.Label
    Friend WithEvents CgrdPeriodos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblConcepto As System.Windows.Forms.Label
    Friend WithEvents txtSemana As System.Windows.Forms.TextBox
    Friend WithEvents lblSemana As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFEchaFinal As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblNaves As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents periodos As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNoSemana As System.Windows.Forms.TextBox
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstados As System.Windows.Forms.Label
    Friend WithEvents pnlGuardarCancelar As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdPeriodos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pcbTitulo As PictureBox
End Class
