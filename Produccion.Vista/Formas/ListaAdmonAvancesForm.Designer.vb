<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaAdmonAvancesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaAdmonAvancesForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAdministracionAvances = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.lblExpExcel = New System.Windows.Forms.Label()
        Me.btnExpExcel = New System.Windows.Forms.Button()
        Me.btnExpPDF = New System.Windows.Forms.Button()
        Me.lblExpPDF = New System.Windows.Forms.Label()
        Me.grbLotesAvances = New System.Windows.Forms.GroupBox()
        Me.chkFechaPrograma = New System.Windows.Forms.CheckBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.dtpFechaAvanceA = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaAvanceDe = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaProgramacionA = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaProgramacionDe = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkFechaAvance = New System.Windows.Forms.CheckBox()
        Me.rblLotesTerminados = New System.Windows.Forms.RadioButton()
        Me.rblTodoLotes = New System.Windows.Forms.RadioButton()
        Me.rblLotesAtrasados = New System.Windows.Forms.RadioButton()
        Me.rblLotesProceso = New System.Windows.Forms.RadioButton()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.cmbCelula = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.txtNoLote = New System.Windows.Forms.TextBox()
        Me.grdAvances = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grbResumen = New System.Windows.Forms.GroupBox()
        Me.grdResumen = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnAbajoResumen = New System.Windows.Forms.Button()
        Me.lblTotales = New System.Windows.Forms.Label()
        Me.btnArribaResumen = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbLotesAvances.SuspendLayout()
        CType(Me.grdAvances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbResumen.SuspendLayout()
        CType(Me.grdResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Controls.Add(Me.btnImprimir)
        Me.pnlEncabezado.Controls.Add(Me.lblImprimir)
        Me.pnlEncabezado.Controls.Add(Me.lblExpExcel)
        Me.pnlEncabezado.Controls.Add(Me.btnExpExcel)
        Me.pnlEncabezado.Controls.Add(Me.btnExpPDF)
        Me.pnlEncabezado.Controls.Add(Me.lblExpPDF)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(927, 81)
        Me.pnlEncabezado.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblAdministracionAvances)
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(545, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(382, 81)
        Me.Panel1.TabIndex = 24
        '
        'lblAdministracionAvances
        '
        Me.lblAdministracionAvances.AutoSize = True
        Me.lblAdministracionAvances.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdministracionAvances.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAdministracionAvances.Location = New System.Drawing.Point(26, 56)
        Me.lblAdministracionAvances.Name = "lblAdministracionAvances"
        Me.lblAdministracionAvances.Size = New System.Drawing.Size(344, 20)
        Me.lblAdministracionAvances.TabIndex = 21
        Me.lblAdministracionAvances.Text = "Administración de Avances de Producción"
        '
        'imgLogo
        '
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(241, 3)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(129, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(21, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 0
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(16, 47)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 23
        Me.lblImprimir.Text = "Imprimir"
        '
        'lblExpExcel
        '
        Me.lblExpExcel.AutoSize = True
        Me.lblExpExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExpExcel.Location = New System.Drawing.Point(153, 47)
        Me.lblExpExcel.Name = "lblExpExcel"
        Me.lblExpExcel.Size = New System.Drawing.Size(84, 13)
        Me.lblExpExcel.TabIndex = 19
        Me.lblExpExcel.Text = "Exportar a Excel"
        '
        'btnExpExcel
        '
        Me.btnExpExcel.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExpExcel.Location = New System.Drawing.Point(179, 12)
        Me.btnExpExcel.Name = "btnExpExcel"
        Me.btnExpExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExpExcel.TabIndex = 2
        Me.btnExpExcel.UseVisualStyleBackColor = True
        '
        'btnExpPDF
        '
        Me.btnExpPDF.Image = Global.Produccion.Vista.My.Resources.Resources.pdf_32
        Me.btnExpPDF.Location = New System.Drawing.Point(98, 12)
        Me.btnExpPDF.Name = "btnExpPDF"
        Me.btnExpPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnExpPDF.TabIndex = 1
        Me.btnExpPDF.UseVisualStyleBackColor = True
        '
        'lblExpPDF
        '
        Me.lblExpPDF.AutoSize = True
        Me.lblExpPDF.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExpPDF.Location = New System.Drawing.Point(72, 47)
        Me.lblExpPDF.Name = "lblExpPDF"
        Me.lblExpPDF.Size = New System.Drawing.Size(79, 13)
        Me.lblExpPDF.TabIndex = 16
        Me.lblExpPDF.Text = "Exportar a PDF"
        '
        'grbLotesAvances
        '
        Me.grbLotesAvances.Controls.Add(Me.chkFechaPrograma)
        Me.grbLotesAvances.Controls.Add(Me.cmbNave)
        Me.grbLotesAvances.Controls.Add(Me.dtpFechaAvanceA)
        Me.grbLotesAvances.Controls.Add(Me.dtpFechaAvanceDe)
        Me.grbLotesAvances.Controls.Add(Me.dtpFechaProgramacionA)
        Me.grbLotesAvances.Controls.Add(Me.dtpFechaProgramacionDe)
        Me.grbLotesAvances.Controls.Add(Me.Label5)
        Me.grbLotesAvances.Controls.Add(Me.Label6)
        Me.grbLotesAvances.Controls.Add(Me.Label4)
        Me.grbLotesAvances.Controls.Add(Me.Label3)
        Me.grbLotesAvances.Controls.Add(Me.chkFechaAvance)
        Me.grbLotesAvances.Controls.Add(Me.rblLotesTerminados)
        Me.grbLotesAvances.Controls.Add(Me.rblTodoLotes)
        Me.grbLotesAvances.Controls.Add(Me.rblLotesAtrasados)
        Me.grbLotesAvances.Controls.Add(Me.rblLotesProceso)
        Me.grbLotesAvances.Controls.Add(Me.lblDepartamento)
        Me.grbLotesAvances.Controls.Add(Me.cmbDepartamento)
        Me.grbLotesAvances.Controls.Add(Me.btnAbajo)
        Me.grbLotesAvances.Controls.Add(Me.btnArriba)
        Me.grbLotesAvances.Controls.Add(Me.lblCelula)
        Me.grbLotesAvances.Controls.Add(Me.lblBúscar)
        Me.grbLotesAvances.Controls.Add(Me.lblLimpiar)
        Me.grbLotesAvances.Controls.Add(Me.btnLimpiar)
        Me.grbLotesAvances.Controls.Add(Me.btnBuscar)
        Me.grbLotesAvances.Controls.Add(Me.lblLote)
        Me.grbLotesAvances.Controls.Add(Me.cmbCelula)
        Me.grbLotesAvances.Controls.Add(Me.lblNave)
        Me.grbLotesAvances.Controls.Add(Me.txtNoLote)
        Me.grbLotesAvances.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbLotesAvances.Location = New System.Drawing.Point(0, 81)
        Me.grbLotesAvances.Name = "grbLotesAvances"
        Me.grbLotesAvances.Size = New System.Drawing.Size(927, 169)
        Me.grbLotesAvances.TabIndex = 0
        Me.grbLotesAvances.TabStop = False
        Me.grbLotesAvances.Text = "Busqueda"
        '
        'chkFechaPrograma
        '
        Me.chkFechaPrograma.AutoSize = True
        Me.chkFechaPrograma.Checked = True
        Me.chkFechaPrograma.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFechaPrograma.Location = New System.Drawing.Point(347, 43)
        Me.chkFechaPrograma.Name = "chkFechaPrograma"
        Me.chkFechaPrograma.Size = New System.Drawing.Size(139, 17)
        Me.chkFechaPrograma.TabIndex = 8
        Me.chkFechaPrograma.Text = "Fecha de Programación"
        Me.chkFechaPrograma.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(106, 73)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(159, 21)
        Me.cmbNave.TabIndex = 3
        '
        'dtpFechaAvanceA
        '
        Me.dtpFechaAvanceA.Enabled = False
        Me.dtpFechaAvanceA.Location = New System.Drawing.Point(576, 96)
        Me.dtpFechaAvanceA.Name = "dtpFechaAvanceA"
        Me.dtpFechaAvanceA.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaAvanceA.TabIndex = 21
        '
        'dtpFechaAvanceDe
        '
        Me.dtpFechaAvanceDe.Enabled = False
        Me.dtpFechaAvanceDe.Location = New System.Drawing.Point(576, 66)
        Me.dtpFechaAvanceDe.Name = "dtpFechaAvanceDe"
        Me.dtpFechaAvanceDe.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaAvanceDe.TabIndex = 19
        '
        'dtpFechaProgramacionA
        '
        Me.dtpFechaProgramacionA.Location = New System.Drawing.Point(320, 96)
        Me.dtpFechaProgramacionA.Name = "dtpFechaProgramacionA"
        Me.dtpFechaProgramacionA.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaProgramacionA.TabIndex = 12
        '
        'dtpFechaProgramacionDe
        '
        Me.dtpFechaProgramacionDe.Location = New System.Drawing.Point(320, 66)
        Me.dtpFechaProgramacionDe.Name = "dtpFechaProgramacionDe"
        Me.dtpFechaProgramacionDe.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaProgramacionDe.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(552, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "A"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(552, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "De"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(296, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "De"
        '
        'chkFechaAvance
        '
        Me.chkFechaAvance.AutoSize = True
        Me.chkFechaAvance.Enabled = False
        Me.chkFechaAvance.Location = New System.Drawing.Point(621, 43)
        Me.chkFechaAvance.Name = "chkFechaAvance"
        Me.chkFechaAvance.Size = New System.Drawing.Size(111, 17)
        Me.chkFechaAvance.TabIndex = 17
        Me.chkFechaAvance.Text = "Fecha de Avance"
        Me.chkFechaAvance.UseVisualStyleBackColor = True
        '
        'rblLotesTerminados
        '
        Me.rblLotesTerminados.AutoSize = True
        Me.rblLotesTerminados.Location = New System.Drawing.Point(658, 137)
        Me.rblLotesTerminados.Name = "rblLotesTerminados"
        Me.rblLotesTerminados.Size = New System.Drawing.Size(120, 17)
        Me.rblLotesTerminados.TabIndex = 16
        Me.rblLotesTerminados.Text = "Lotes en terminados"
        Me.rblLotesTerminados.UseVisualStyleBackColor = True
        '
        'rblTodoLotes
        '
        Me.rblTodoLotes.AutoSize = True
        Me.rblTodoLotes.Checked = True
        Me.rblTodoLotes.Location = New System.Drawing.Point(299, 137)
        Me.rblTodoLotes.Name = "rblTodoLotes"
        Me.rblTodoLotes.Size = New System.Drawing.Size(50, 17)
        Me.rblTodoLotes.TabIndex = 13
        Me.rblTodoLotes.TabStop = True
        Me.rblTodoLotes.Text = "Todo"
        Me.rblTodoLotes.UseVisualStyleBackColor = True
        '
        'rblLotesAtrasados
        '
        Me.rblLotesAtrasados.AutoSize = True
        Me.rblLotesAtrasados.Location = New System.Drawing.Point(383, 137)
        Me.rblLotesAtrasados.Name = "rblLotesAtrasados"
        Me.rblLotesAtrasados.Size = New System.Drawing.Size(100, 17)
        Me.rblLotesAtrasados.TabIndex = 14
        Me.rblLotesAtrasados.Text = "Lotes atrasados"
        Me.rblLotesAtrasados.UseVisualStyleBackColor = True
        '
        'rblLotesProceso
        '
        Me.rblLotesProceso.AutoSize = True
        Me.rblLotesProceso.Location = New System.Drawing.Point(517, 137)
        Me.rblLotesProceso.Name = "rblLotesProceso"
        Me.rblLotesProceso.Size = New System.Drawing.Size(107, 17)
        Me.rblLotesProceso.TabIndex = 15
        Me.rblLotesProceso.Text = "Lotes en proceso"
        Me.rblLotesProceso.UseVisualStyleBackColor = True
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(28, 108)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.lblDepartamento.TabIndex = 4
        Me.lblDepartamento.Text = "Departamento"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(106, 104)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(159, 21)
        Me.cmbDepartamento.TabIndex = 5
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(34, 13)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 17
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(11, 13)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 16
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(28, 139)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(36, 13)
        Me.lblCelula.TabIndex = 6
        Me.lblCelula.Text = "Celula"
        '
        'lblBúscar
        '
        Me.lblBúscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(821, 149)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Búscar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(871, 149)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(874, 115)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 23
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(824, 115)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 22
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblLote
        '
        Me.lblLote.AutoSize = True
        Me.lblLote.Location = New System.Drawing.Point(28, 47)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(48, 13)
        Me.lblLote.TabIndex = 0
        Me.lblLote.Text = "No. Lote"
        '
        'cmbCelula
        '
        Me.cmbCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCelula.FormattingEnabled = True
        Me.cmbCelula.Location = New System.Drawing.Point(106, 135)
        Me.cmbCelula.Name = "cmbCelula"
        Me.cmbCelula.Size = New System.Drawing.Size(159, 21)
        Me.cmbCelula.TabIndex = 7
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(28, 77)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 2
        Me.lblNave.Text = "Nave"
        '
        'txtNoLote
        '
        Me.txtNoLote.Location = New System.Drawing.Point(106, 43)
        Me.txtNoLote.MaxLength = 50
        Me.txtNoLote.Name = "txtNoLote"
        Me.txtNoLote.Size = New System.Drawing.Size(159, 20)
        Me.txtNoLote.TabIndex = 1
        Me.txtNoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grdAvances
        '
        Me.grdAvances.AllowEditing = False
        Me.grdAvances.AllowFiltering = True
        Me.grdAvances.AutoResize = True
        Me.grdAvances.ColumnInfo = resources.GetString("grdAvances.ColumnInfo")
        Me.grdAvances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAvances.ExtendLastCol = True
        Me.grdAvances.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.grdAvances.Location = New System.Drawing.Point(0, 250)
        Me.grdAvances.Name = "grdAvances"
        Me.grdAvances.Rows.Count = 1
        Me.grdAvances.Rows.DefaultSize = 18
        Me.grdAvances.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdAvances.Size = New System.Drawing.Size(927, 220)
        Me.grdAvances.StyleInfo = resources.GetString("grdAvances.StyleInfo")
        Me.grdAvances.TabIndex = 1
        Me.grdAvances.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'grbResumen
        '
        Me.grbResumen.Controls.Add(Me.grdResumen)
        Me.grbResumen.Controls.Add(Me.btnAbajoResumen)
        Me.grbResumen.Controls.Add(Me.lblTotales)
        Me.grbResumen.Controls.Add(Me.btnArribaResumen)
        Me.grbResumen.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grbResumen.Location = New System.Drawing.Point(0, 470)
        Me.grbResumen.Name = "grbResumen"
        Me.grbResumen.Size = New System.Drawing.Size(927, 155)
        Me.grbResumen.TabIndex = 6
        Me.grbResumen.TabStop = False
        '
        'grdResumen
        '
        Me.grdResumen.AllowEditing = False
        Me.grdResumen.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly
        Me.grdResumen.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly
        Me.grdResumen.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.grdResumen.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.grdResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdResumen.ColumnInfo = "0,0,0,0,0,85,Columns:"
        Me.grdResumen.ExtendLastCol = True
        Me.grdResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdResumen.Location = New System.Drawing.Point(0, 36)
        Me.grdResumen.Name = "grdResumen"
        Me.grdResumen.Rows.Count = 0
        Me.grdResumen.Rows.DefaultSize = 17
        Me.grdResumen.Rows.Fixed = 0
        Me.grdResumen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdResumen.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdResumen.Size = New System.Drawing.Size(927, 118)
        Me.grdResumen.StyleInfo = resources.GetString("grdResumen.StyleInfo")
        Me.grdResumen.TabIndex = 20
        Me.grdResumen.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'btnAbajoResumen
        '
        Me.btnAbajoResumen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajoResumen.Image = CType(resources.GetObject("btnAbajoResumen.Image"), System.Drawing.Image)
        Me.btnAbajoResumen.Location = New System.Drawing.Point(891, 12)
        Me.btnAbajoResumen.Name = "btnAbajoResumen"
        Me.btnAbajoResumen.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajoResumen.TabIndex = 19
        Me.btnAbajoResumen.UseVisualStyleBackColor = True
        '
        'lblTotales
        '
        Me.lblTotales.AutoSize = True
        Me.lblTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotales.Location = New System.Drawing.Point(10, 15)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(105, 13)
        Me.lblTotales.TabIndex = 0
        Me.lblTotales.Text = "Total de Pares: 0"
        '
        'btnArribaResumen
        '
        Me.btnArribaResumen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArribaResumen.Image = CType(resources.GetObject("btnArribaResumen.Image"), System.Drawing.Image)
        Me.btnArribaResumen.Location = New System.Drawing.Point(868, 12)
        Me.btnArribaResumen.Name = "btnArribaResumen"
        Me.btnArribaResumen.Size = New System.Drawing.Size(20, 20)
        Me.btnArribaResumen.TabIndex = 18
        Me.btnArribaResumen.UseVisualStyleBackColor = True
        '
        'ListaAdmonAvancesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(927, 625)
        Me.Controls.Add(Me.grdAvances)
        Me.Controls.Add(Me.grbResumen)
        Me.Controls.Add(Me.grbLotesAvances)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ListaAdmonAvancesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de Avances de Producción"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbLotesAvances.ResumeLayout(False)
        Me.grbLotesAvances.PerformLayout()
        CType(Me.grdAvances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbResumen.ResumeLayout(False)
        Me.grbResumen.PerformLayout()
        CType(Me.grdResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblAdministracionAvances As System.Windows.Forms.Label
    Friend WithEvents lblExpExcel As System.Windows.Forms.Label
    Friend WithEvents btnExpExcel As System.Windows.Forms.Button
    Friend WithEvents btnExpPDF As System.Windows.Forms.Button
    Friend WithEvents lblExpPDF As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents grbLotesAvances As System.Windows.Forms.GroupBox
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblLote As System.Windows.Forms.Label
    Friend WithEvents cmbCelula As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents txtNoLote As System.Windows.Forms.TextBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkFechaAvance As System.Windows.Forms.CheckBox
    Friend WithEvents rblLotesTerminados As System.Windows.Forms.RadioButton
    Friend WithEvents rblTodoLotes As System.Windows.Forms.RadioButton
    Friend WithEvents rblLotesAtrasados As System.Windows.Forms.RadioButton
    Friend WithEvents rblLotesProceso As System.Windows.Forms.RadioButton
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaAvanceA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaAvanceDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaProgramacionA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaProgramacionDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents grdAvances As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grbResumen As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTotales As System.Windows.Forms.Label
    Friend WithEvents chkFechaPrograma As System.Windows.Forms.CheckBox
    Friend WithEvents btnAbajoResumen As System.Windows.Forms.Button
    Friend WithEvents btnArribaResumen As System.Windows.Forms.Button
    Friend WithEvents grdResumen As C1.Win.C1FlexGrid.C1FlexGrid
End Class
