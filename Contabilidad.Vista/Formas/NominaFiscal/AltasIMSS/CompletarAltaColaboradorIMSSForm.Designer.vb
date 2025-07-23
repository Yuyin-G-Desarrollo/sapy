<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CompletarAltaColaboradorIMSSForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompletarAltaColaboradorIMSSForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.gpbFiltro = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbPuestoFiscal = New System.Windows.Forms.ComboBox()
        Me.cmbDeptoFiscal = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlInfonavil = New System.Windows.Forms.Panel()
        Me.txtNumeroCredito = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtValorDescuento = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbTipoDes = New System.Windows.Forms.ComboBox()
        Me.lblCantidadDes = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlArchivoCargado = New System.Windows.Forms.Panel()
        Me.btnPdfInfonavit = New System.Windows.Forms.Button()
        Me.btnInfonavit = New System.Windows.Forms.Button()
        Me.cmbUmf = New System.Windows.Forms.ComboBox()
        Me.cmbTipoJornada = New System.Windows.Forms.ComboBox()
        Me.cmbTipoSalario = New System.Windows.Forms.ComboBox()
        Me.cmbTipoTrabajador = New System.Windows.Forms.ComboBox()
        Me.txtUMF = New System.Windows.Forms.TextBox()
        Me.txtSDI = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rdoInfonavitSI = New System.Windows.Forms.RadioButton()
        Me.rdoInfonavitNo = New System.Windows.Forms.RadioButton()
        Me.lblCuentaCredito = New System.Windows.Forms.Label()
        Me.lblUMF = New System.Windows.Forms.Label()
        Me.lblTipoJornada = New System.Windows.Forms.Label()
        Me.lblTipoSalario = New System.Windows.Forms.Label()
        Me.lblTipoTrabajador = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFechaAlta = New System.Windows.Forms.Label()
        Me.dtpFechaAlta = New System.Windows.Forms.DateTimePicker()
        Me.lblnss = New System.Windows.Forms.Label()
        Me.lblRfc = New System.Windows.Forms.Label()
        Me.lblCurp = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.txtRutaRetencion = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.rdoDisminucionSI = New System.Windows.Forms.RadioButton()
        Me.rdoDisminucionNo = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdColaboradoresImss = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.opfArchivoRetencion = New System.Windows.Forms.OpenFileDialog()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gpbFiltro.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlInfonavil.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdColaboradoresImss, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1098, 69)
        Me.pnlListaPaises.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(677, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 69)
        Me.Panel1.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(126, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(212, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Alta Colaboradores IMSS"
        '
        'gpbFiltro
        '
        Me.gpbFiltro.BackColor = System.Drawing.Color.AliceBlue
        Me.gpbFiltro.Controls.Add(Me.Panel2)
        Me.gpbFiltro.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltro.Location = New System.Drawing.Point(0, 69)
        Me.gpbFiltro.Name = "gpbFiltro"
        Me.gpbFiltro.Size = New System.Drawing.Size(1098, 257)
        Me.gpbFiltro.TabIndex = 29
        Me.gpbFiltro.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmbPuestoFiscal)
        Me.Panel2.Controls.Add(Me.cmbDeptoFiscal)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.pnlInfonavil)
        Me.Panel2.Controls.Add(Me.pnlArchivoCargado)
        Me.Panel2.Controls.Add(Me.btnPdfInfonavit)
        Me.Panel2.Controls.Add(Me.btnInfonavit)
        Me.Panel2.Controls.Add(Me.cmbUmf)
        Me.Panel2.Controls.Add(Me.cmbTipoJornada)
        Me.Panel2.Controls.Add(Me.cmbTipoSalario)
        Me.Panel2.Controls.Add(Me.cmbTipoTrabajador)
        Me.Panel2.Controls.Add(Me.txtUMF)
        Me.Panel2.Controls.Add(Me.txtSDI)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.lblCuentaCredito)
        Me.Panel2.Controls.Add(Me.lblUMF)
        Me.Panel2.Controls.Add(Me.lblTipoJornada)
        Me.Panel2.Controls.Add(Me.lblTipoSalario)
        Me.Panel2.Controls.Add(Me.lblTipoTrabajador)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lblFechaAlta)
        Me.Panel2.Controls.Add(Me.dtpFechaAlta)
        Me.Panel2.Controls.Add(Me.lblnss)
        Me.Panel2.Controls.Add(Me.lblRfc)
        Me.Panel2.Controls.Add(Me.lblCurp)
        Me.Panel2.Controls.Add(Me.lblNombre)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lblPatron)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1092, 212)
        Me.Panel2.TabIndex = 46
        '
        'cmbPuestoFiscal
        '
        Me.cmbPuestoFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuestoFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPuestoFiscal.ForeColor = System.Drawing.Color.Black
        Me.cmbPuestoFiscal.FormattingEnabled = True
        Me.cmbPuestoFiscal.Location = New System.Drawing.Point(856, 180)
        Me.cmbPuestoFiscal.Name = "cmbPuestoFiscal"
        Me.cmbPuestoFiscal.Size = New System.Drawing.Size(215, 24)
        Me.cmbPuestoFiscal.TabIndex = 137
        '
        'cmbDeptoFiscal
        '
        Me.cmbDeptoFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeptoFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDeptoFiscal.ForeColor = System.Drawing.Color.Black
        Me.cmbDeptoFiscal.FormattingEnabled = True
        Me.cmbDeptoFiscal.Location = New System.Drawing.Point(856, 150)
        Me.cmbDeptoFiscal.Name = "cmbDeptoFiscal"
        Me.cmbDeptoFiscal.Size = New System.Drawing.Size(215, 24)
        Me.cmbDeptoFiscal.TabIndex = 136
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(780, 185)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 135
        Me.Label14.Text = "*Puesto fiscal"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(746, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 13)
        Me.Label13.TabIndex = 134
        Me.Label13.Text = "*Departamento fiscal"
        '
        'pnlInfonavil
        '
        Me.pnlInfonavil.Controls.Add(Me.txtNumeroCredito)
        Me.pnlInfonavil.Controls.Add(Me.Label7)
        Me.pnlInfonavil.Controls.Add(Me.txtValorDescuento)
        Me.pnlInfonavil.Controls.Add(Me.Label8)
        Me.pnlInfonavil.Controls.Add(Me.Label12)
        Me.pnlInfonavil.Controls.Add(Me.Label10)
        Me.pnlInfonavil.Controls.Add(Me.cmbTipoDes)
        Me.pnlInfonavil.Controls.Add(Me.lblCantidadDes)
        Me.pnlInfonavil.Controls.Add(Me.Label11)
        Me.pnlInfonavil.Location = New System.Drawing.Point(411, 67)
        Me.pnlInfonavil.Name = "pnlInfonavil"
        Me.pnlInfonavil.Size = New System.Drawing.Size(342, 109)
        Me.pnlInfonavil.TabIndex = 133
        '
        'txtNumeroCredito
        '
        Me.txtNumeroCredito.Location = New System.Drawing.Point(124, 4)
        Me.txtNumeroCredito.MaxLength = 10
        Me.txtNumeroCredito.Name = "txtNumeroCredito"
        Me.txtNumeroCredito.Size = New System.Drawing.Size(210, 20)
        Me.txtNumeroCredito.TabIndex = 127
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "*Número de crédito"
        '
        'txtValorDescuento
        '
        Me.txtValorDescuento.Location = New System.Drawing.Point(125, 57)
        Me.txtValorDescuento.Name = "txtValorDescuento"
        Me.txtValorDescuento.Size = New System.Drawing.Size(131, 20)
        Me.txtValorDescuento.TabIndex = 131
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "*Tipo de descuento"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "*Valor de descuento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "*Cantidad a descontar"
        '
        'cmbTipoDes
        '
        Me.cmbTipoDes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDes.FormattingEnabled = True
        Me.cmbTipoDes.Location = New System.Drawing.Point(125, 30)
        Me.cmbTipoDes.Name = "cmbTipoDes"
        Me.cmbTipoDes.Size = New System.Drawing.Size(209, 21)
        Me.cmbTipoDes.TabIndex = 128
        '
        'lblCantidadDes
        '
        Me.lblCantidadDes.AutoSize = True
        Me.lblCantidadDes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadDes.Location = New System.Drawing.Point(134, 89)
        Me.lblCantidadDes.Name = "lblCantidadDes"
        Me.lblCantidadDes.Size = New System.Drawing.Size(11, 13)
        Me.lblCantidadDes.TabIndex = 26
        Me.lblCantidadDes.Text = "."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(122, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(14, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "$"
        '
        'pnlArchivoCargado
        '
        Me.pnlArchivoCargado.BackgroundImage = Global.Contabilidad.Vista.My.Resources.Resources.seleccionar
        Me.pnlArchivoCargado.Location = New System.Drawing.Point(728, 44)
        Me.pnlArchivoCargado.Name = "pnlArchivoCargado"
        Me.pnlArchivoCargado.Size = New System.Drawing.Size(16, 16)
        Me.pnlArchivoCargado.TabIndex = 132
        Me.pnlArchivoCargado.Visible = False
        '
        'btnPdfInfonavit
        '
        Me.btnPdfInfonavit.Image = Global.Contabilidad.Vista.My.Resources.Resources.agregar_pdf
        Me.btnPdfInfonavit.Location = New System.Drawing.Point(694, 32)
        Me.btnPdfInfonavit.Name = "btnPdfInfonavit"
        Me.btnPdfInfonavit.Size = New System.Drawing.Size(32, 32)
        Me.btnPdfInfonavit.TabIndex = 130
        Me.btnPdfInfonavit.UseVisualStyleBackColor = True
        '
        'btnInfonavit
        '
        Me.btnInfonavit.Image = Global.Contabilidad.Vista.My.Resources.Resources.infonavit
        Me.btnInfonavit.Location = New System.Drawing.Point(658, 32)
        Me.btnInfonavit.Name = "btnInfonavit"
        Me.btnInfonavit.Size = New System.Drawing.Size(32, 32)
        Me.btnInfonavit.TabIndex = 129
        Me.btnInfonavit.UseVisualStyleBackColor = True
        '
        'cmbUmf
        '
        Me.cmbUmf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUmf.FormattingEnabled = True
        Me.cmbUmf.Location = New System.Drawing.Point(856, 123)
        Me.cmbUmf.Name = "cmbUmf"
        Me.cmbUmf.Size = New System.Drawing.Size(215, 21)
        Me.cmbUmf.TabIndex = 126
        '
        'cmbTipoJornada
        '
        Me.cmbTipoJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoJornada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoJornada.ForeColor = System.Drawing.Color.Black
        Me.cmbTipoJornada.FormattingEnabled = True
        Me.cmbTipoJornada.Location = New System.Drawing.Point(856, 94)
        Me.cmbTipoJornada.Name = "cmbTipoJornada"
        Me.cmbTipoJornada.Size = New System.Drawing.Size(215, 21)
        Me.cmbTipoJornada.TabIndex = 125
        '
        'cmbTipoSalario
        '
        Me.cmbTipoSalario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSalario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSalario.ForeColor = System.Drawing.Color.Black
        Me.cmbTipoSalario.FormattingEnabled = True
        Me.cmbTipoSalario.Location = New System.Drawing.Point(856, 67)
        Me.cmbTipoSalario.Name = "cmbTipoSalario"
        Me.cmbTipoSalario.Size = New System.Drawing.Size(215, 21)
        Me.cmbTipoSalario.TabIndex = 124
        '
        'cmbTipoTrabajador
        '
        Me.cmbTipoTrabajador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTrabajador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoTrabajador.ForeColor = System.Drawing.Color.Black
        Me.cmbTipoTrabajador.FormattingEnabled = True
        Me.cmbTipoTrabajador.Location = New System.Drawing.Point(856, 38)
        Me.cmbTipoTrabajador.Name = "cmbTipoTrabajador"
        Me.cmbTipoTrabajador.Size = New System.Drawing.Size(215, 21)
        Me.cmbTipoTrabajador.TabIndex = 123
        '
        'txtUMF
        '
        Me.txtUMF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUMF.Location = New System.Drawing.Point(995, 6)
        Me.txtUMF.Name = "txtUMF"
        Me.txtUMF.Size = New System.Drawing.Size(76, 20)
        Me.txtUMF.TabIndex = 120
        Me.txtUMF.Visible = False
        '
        'txtSDI
        '
        Me.txtSDI.Location = New System.Drawing.Point(856, 9)
        Me.txtSDI.Name = "txtSDI"
        Me.txtSDI.Size = New System.Drawing.Size(76, 20)
        Me.txtSDI.TabIndex = 120
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.rdoInfonavitSI)
        Me.Panel6.Controls.Add(Me.rdoInfonavitNo)
        Me.Panel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(535, 36)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(117, 24)
        Me.Panel6.TabIndex = 119
        '
        'rdoInfonavitSI
        '
        Me.rdoInfonavitSI.AutoSize = True
        Me.rdoInfonavitSI.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoInfonavitSI.Location = New System.Drawing.Point(11, 3)
        Me.rdoInfonavitSI.Name = "rdoInfonavitSI"
        Me.rdoInfonavitSI.Size = New System.Drawing.Size(34, 17)
        Me.rdoInfonavitSI.TabIndex = 20
        Me.rdoInfonavitSI.Text = "Si"
        Me.rdoInfonavitSI.UseVisualStyleBackColor = True
        '
        'rdoInfonavitNo
        '
        Me.rdoInfonavitNo.AutoSize = True
        Me.rdoInfonavitNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoInfonavitNo.Location = New System.Drawing.Point(67, 3)
        Me.rdoInfonavitNo.Name = "rdoInfonavitNo"
        Me.rdoInfonavitNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInfonavitNo.TabIndex = 21
        Me.rdoInfonavitNo.Text = "No"
        Me.rdoInfonavitNo.UseVisualStyleBackColor = True
        '
        'lblCuentaCredito
        '
        Me.lblCuentaCredito.AutoSize = True
        Me.lblCuentaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuentaCredito.Location = New System.Drawing.Point(353, 42)
        Me.lblCuentaCredito.Name = "lblCuentaCredito"
        Me.lblCuentaCredito.Size = New System.Drawing.Size(173, 13)
        Me.lblCuentaCredito.TabIndex = 26
        Me.lblCuentaCredito.Text = "*¿Cuenta con crédito INFONAVIT?"
        '
        'lblUMF
        '
        Me.lblUMF.AutoSize = True
        Me.lblUMF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUMF.Location = New System.Drawing.Point(817, 126)
        Me.lblUMF.Name = "lblUMF"
        Me.lblUMF.Size = New System.Drawing.Size(34, 13)
        Me.lblUMF.TabIndex = 26
        Me.lblUMF.Text = "*UMF"
        '
        'lblTipoJornada
        '
        Me.lblTipoJornada.AutoSize = True
        Me.lblTipoJornada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoJornada.Location = New System.Drawing.Point(766, 97)
        Me.lblTipoJornada.Name = "lblTipoJornada"
        Me.lblTipoJornada.Size = New System.Drawing.Size(85, 13)
        Me.lblTipoJornada.TabIndex = 26
        Me.lblTipoJornada.Text = "*Tipo de jornada"
        '
        'lblTipoSalario
        '
        Me.lblTipoSalario.AutoSize = True
        Me.lblTipoSalario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoSalario.Location = New System.Drawing.Point(771, 71)
        Me.lblTipoSalario.Name = "lblTipoSalario"
        Me.lblTipoSalario.Size = New System.Drawing.Size(80, 13)
        Me.lblTipoSalario.TabIndex = 26
        Me.lblTipoSalario.Text = "*Tipo de salario"
        '
        'lblTipoTrabajador
        '
        Me.lblTipoTrabajador.AutoSize = True
        Me.lblTipoTrabajador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoTrabajador.Location = New System.Drawing.Point(754, 41)
        Me.lblTipoTrabajador.Name = "lblTipoTrabajador"
        Me.lblTipoTrabajador.Size = New System.Drawing.Size(97, 13)
        Me.lblTipoTrabajador.TabIndex = 26
        Me.lblTipoTrabajador.Text = "*Tipo de trabajador"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(822, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "*SDI"
        '
        'lblFechaAlta
        '
        Me.lblFechaAlta.AutoSize = True
        Me.lblFechaAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaAlta.Location = New System.Drawing.Point(461, 13)
        Me.lblFechaAlta.Name = "lblFechaAlta"
        Me.lblFechaAlta.Size = New System.Drawing.Size(62, 13)
        Me.lblFechaAlta.TabIndex = 26
        Me.lblFechaAlta.Text = "*Fecha Alta"
        '
        'dtpFechaAlta
        '
        Me.dtpFechaAlta.Enabled = False
        Me.dtpFechaAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAlta.ImeMode = System.Windows.Forms.ImeMode.Katakana
        Me.dtpFechaAlta.Location = New System.Drawing.Point(534, 9)
        Me.dtpFechaAlta.Name = "dtpFechaAlta"
        Me.dtpFechaAlta.Size = New System.Drawing.Size(210, 20)
        Me.dtpFechaAlta.TabIndex = 27
        '
        'lblnss
        '
        Me.lblnss.AutoSize = True
        Me.lblnss.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnss.Location = New System.Drawing.Point(61, 126)
        Me.lblnss.Name = "lblnss"
        Me.lblnss.Size = New System.Drawing.Size(11, 13)
        Me.lblnss.TabIndex = 0
        Me.lblnss.Text = ":"
        '
        'lblRfc
        '
        Me.lblRfc.AutoSize = True
        Me.lblRfc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRfc.Location = New System.Drawing.Point(61, 98)
        Me.lblRfc.Name = "lblRfc"
        Me.lblRfc.Size = New System.Drawing.Size(11, 13)
        Me.lblRfc.TabIndex = 0
        Me.lblRfc.Text = ":"
        '
        'lblCurp
        '
        Me.lblCurp.AutoSize = True
        Me.lblCurp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurp.Location = New System.Drawing.Point(61, 70)
        Me.lblCurp.Name = "lblCurp"
        Me.lblCurp.Size = New System.Drawing.Size(11, 13)
        Me.lblCurp.TabIndex = 0
        Me.lblCurp.Text = ":"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(61, 43)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(11, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "NSS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "RFC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "CURP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre"
        '
        'lblPatron
        '
        Me.lblPatron.AutoSize = True
        Me.lblPatron.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatron.Location = New System.Drawing.Point(61, 13)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(11, 13)
        Me.lblPatron.TabIndex = 0
        Me.lblPatron.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Patrón"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.txtRutaRetencion)
        Me.pnlMinimizarParametros.Controls.Add(Me.Panel5)
        Me.pnlMinimizarParametros.Controls.Add(Me.Panel8)
        Me.pnlMinimizarParametros.Controls.Add(Me.Label9)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(3, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(1092, 29)
        Me.pnlMinimizarParametros.TabIndex = 45
        '
        'txtRutaRetencion
        '
        Me.txtRutaRetencion.Location = New System.Drawing.Point(728, 2)
        Me.txtRutaRetencion.Name = "txtRutaRetencion"
        Me.txtRutaRetencion.Size = New System.Drawing.Size(173, 20)
        Me.txtRutaRetencion.TabIndex = 120
        Me.txtRutaRetencion.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnAbajo)
        Me.Panel5.Controls.Add(Me.btnArriba)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(1027, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(65, 29)
        Me.Panel5.TabIndex = 43
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(37, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(8, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.rdoDisminucionSI)
        Me.Panel8.Controls.Add(Me.rdoDisminucionNo)
        Me.Panel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel8.Location = New System.Drawing.Point(546, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(131, 24)
        Me.Panel8.TabIndex = 119
        Me.Panel8.Visible = False
        '
        'rdoDisminucionSI
        '
        Me.rdoDisminucionSI.AutoSize = True
        Me.rdoDisminucionSI.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoDisminucionSI.Location = New System.Drawing.Point(11, 3)
        Me.rdoDisminucionSI.Name = "rdoDisminucionSI"
        Me.rdoDisminucionSI.Size = New System.Drawing.Size(34, 17)
        Me.rdoDisminucionSI.TabIndex = 20
        Me.rdoDisminucionSI.Text = "Si"
        Me.rdoDisminucionSI.UseVisualStyleBackColor = True
        '
        'rdoDisminucionNo
        '
        Me.rdoDisminucionNo.AutoSize = True
        Me.rdoDisminucionNo.Checked = True
        Me.rdoDisminucionNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdoDisminucionNo.Location = New System.Drawing.Point(67, 3)
        Me.rdoDisminucionNo.Name = "rdoDisminucionNo"
        Me.rdoDisminucionNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoDisminucionNo.TabIndex = 21
        Me.rdoDisminucionNo.TabStop = True
        Me.rdoDisminucionNo.Text = "No"
        Me.rdoDisminucionNo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(386, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(151, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "*¿Aplica tabla de disminución?"
        Me.Label9.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 522)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1098, 60)
        Me.Panel3.TabIndex = 30
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblGuardar)
        Me.Panel4.Controls.Add(Me.btnGuardar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(980, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(66, 60)
        Me.Panel4.TabIndex = 38
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(15, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 53
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(21, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 52
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnCerrar)
        Me.Panel7.Controls.Add(Me.lblCerrar)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(1046, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(52, 60)
        Me.Panel7.TabIndex = 37
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(9, 4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(8, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 19
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdColaboradoresImss
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColaboradoresImss.DisplayLayout.Appearance = Appearance1
        Me.grdColaboradoresImss.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColaboradoresImss.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdColaboradoresImss.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColaboradoresImss.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdColaboradoresImss.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdColaboradoresImss.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColaboradoresImss.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdColaboradoresImss.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColaboradoresImss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColaboradoresImss.Location = New System.Drawing.Point(0, 326)
        Me.grdColaboradoresImss.Name = "grdColaboradoresImss"
        Me.grdColaboradoresImss.Size = New System.Drawing.Size(1098, 196)
        Me.grdColaboradoresImss.TabIndex = 31
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(349, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'CompletarAltaColaboradorIMSSForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 582)
        Me.Controls.Add(Me.grdColaboradoresImss)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.gpbFiltro)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "CompletarAltaColaboradorIMSSForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlListaPaises.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpbFiltro.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlInfonavil.ResumeLayout(False)
        Me.pnlInfonavil.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlMinimizarParametros.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.grdColaboradoresImss, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents gpbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents grdColaboradoresImss As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPatron As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblnss As System.Windows.Forms.Label
    Friend WithEvents lblRfc As System.Windows.Forms.Label
    Friend WithEvents lblCurp As System.Windows.Forms.Label
    Friend WithEvents lblFechaAlta As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCuentaCredito As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents rdoInfonavitSI As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInfonavitNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSDI As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoTrabajador As System.Windows.Forms.Label
    Friend WithEvents cmbTipoTrabajador As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoSalario As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSalario As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoJornada As System.Windows.Forms.Label
    Friend WithEvents cmbTipoJornada As System.Windows.Forms.ComboBox
    Friend WithEvents txtUMF As System.Windows.Forms.TextBox
    Friend WithEvents lblUMF As System.Windows.Forms.Label
    Friend WithEvents cmbUmf As System.Windows.Forms.ComboBox
    Friend WithEvents btnInfonavit As System.Windows.Forms.Button
    Friend WithEvents cmbTipoDes As System.Windows.Forms.ComboBox
    Friend WithEvents txtNumeroCredito As System.Windows.Forms.TextBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents rdoDisminucionSI As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDisminucionNo As System.Windows.Forms.RadioButton
    Friend WithEvents lblCantidadDes As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPdfInfonavit As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtValorDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlArchivoCargado As System.Windows.Forms.Panel
    Friend WithEvents opfArchivoRetencion As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtRutaRetencion As System.Windows.Forms.TextBox
    Friend WithEvents pnlInfonavil As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbDeptoFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPuestoFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
