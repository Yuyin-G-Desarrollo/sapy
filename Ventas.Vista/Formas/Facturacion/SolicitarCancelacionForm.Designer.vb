<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SolicitudCancelacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolicitudCancelacion))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbInterno = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtnMismoEmisorReceptorNO = New System.Windows.Forms.RadioButton()
        Me.rbtnMismoEmisorReceptorSI = New System.Windows.Forms.RadioButton()
        Me.txtMetodoPago = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtnSustitucionSI = New System.Windows.Forms.RadioButton()
        Me.rbtnSustitucionNO = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtnCliente = New System.Windows.Forms.RadioButton()
        Me.rbtnInterna = New System.Windows.Forms.RadioButton()
        Me.txtRfcEmisor = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRfcReceptor = New System.Windows.Forms.TextBox()
        Me.cmbMotivoInterno = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDocumentoid = New System.Windows.Forms.Label()
        Me.txtSolicita = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblSolicita = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.cmbInterno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(620, 59)
        Me.pnlListaPaises.TabIndex = 75
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(239, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(381, 59)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(113, 16)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(203, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Solicitud de cancelación"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(322, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(59, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.AutoSize = True
        Me.lblClienteNombre.Location = New System.Drawing.Point(66, 16)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(52, 13)
        Me.lblClienteNombre.TabIndex = 16
        Me.lblClienteNombre.Text = "CLIENTE"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblClienteNombre)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(620, 600)
        Me.Panel1.TabIndex = 77
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbInterno)
        Me.GroupBox4.Controls.Add(Me.lblMonto)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Controls.Add(Me.txtMetodoPago)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.txtRfcEmisor)
        Me.GroupBox4.Controls.Add(Me.txtObservaciones)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txtRfcReceptor)
        Me.GroupBox4.Controls.Add(Me.cmbMotivoInterno)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.lblDocumentoid)
        Me.GroupBox4.Controls.Add(Me.txtSolicita)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.lblSolicita)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(23, 76)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(576, 507)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Solicitud de Cancelación"
        '
        'cmbInterno
        '
        Me.cmbInterno.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Me.cmbInterno.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbInterno.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbInterno.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbInterno.Location = New System.Drawing.Point(151, 172)
        Me.cmbInterno.Name = "cmbInterno"
        Me.cmbInterno.Size = New System.Drawing.Size(384, 21)
        Me.cmbInterno.TabIndex = 7
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.Location = New System.Drawing.Point(97, 34)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(38, 16)
        Me.lblMonto.TabIndex = 21
        Me.lblMonto.Text = "Folio"
        Me.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbtnMismoEmisorReceptorNO)
        Me.GroupBox3.Controls.Add(Me.rbtnMismoEmisorReceptorSI)
        Me.GroupBox3.Location = New System.Drawing.Point(47, 319)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(488, 31)
        Me.GroupBox3.TabIndex = 70
        Me.GroupBox3.TabStop = False
        '
        'rbtnMismoEmisorReceptorNO
        '
        Me.rbtnMismoEmisorReceptorNO.AutoSize = True
        Me.rbtnMismoEmisorReceptorNO.Location = New System.Drawing.Point(233, 9)
        Me.rbtnMismoEmisorReceptorNO.Name = "rbtnMismoEmisorReceptorNO"
        Me.rbtnMismoEmisorReceptorNO.Size = New System.Drawing.Size(41, 17)
        Me.rbtnMismoEmisorReceptorNO.TabIndex = 12
        Me.rbtnMismoEmisorReceptorNO.Text = "NO"
        Me.rbtnMismoEmisorReceptorNO.UseVisualStyleBackColor = True
        '
        'rbtnMismoEmisorReceptorSI
        '
        Me.rbtnMismoEmisorReceptorSI.AutoSize = True
        Me.rbtnMismoEmisorReceptorSI.Checked = True
        Me.rbtnMismoEmisorReceptorSI.Location = New System.Drawing.Point(119, 9)
        Me.rbtnMismoEmisorReceptorSI.Name = "rbtnMismoEmisorReceptorSI"
        Me.rbtnMismoEmisorReceptorSI.Size = New System.Drawing.Size(35, 17)
        Me.rbtnMismoEmisorReceptorSI.TabIndex = 11
        Me.rbtnMismoEmisorReceptorSI.TabStop = True
        Me.rbtnMismoEmisorReceptorSI.Text = "SI"
        Me.rbtnMismoEmisorReceptorSI.UseVisualStyleBackColor = True
        '
        'txtMetodoPago
        '
        Me.txtMetodoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMetodoPago.ForeColor = System.Drawing.Color.Black
        Me.txtMetodoPago.Location = New System.Drawing.Point(395, 34)
        Me.txtMetodoPago.Name = "txtMetodoPago"
        Me.txtMetodoPago.Size = New System.Drawing.Size(52, 22)
        Me.txtMetodoPago.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtnSustitucionSI)
        Me.GroupBox2.Controls.Add(Me.rbtnSustitucionNO)
        Me.GroupBox2.Location = New System.Drawing.Point(47, 261)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(488, 31)
        Me.GroupBox2.TabIndex = 69
        Me.GroupBox2.TabStop = False
        '
        'rbtnSustitucionSI
        '
        Me.rbtnSustitucionSI.AutoSize = True
        Me.rbtnSustitucionSI.Checked = True
        Me.rbtnSustitucionSI.Location = New System.Drawing.Point(119, 9)
        Me.rbtnSustitucionSI.Name = "rbtnSustitucionSI"
        Me.rbtnSustitucionSI.Size = New System.Drawing.Size(35, 17)
        Me.rbtnSustitucionSI.TabIndex = 9
        Me.rbtnSustitucionSI.TabStop = True
        Me.rbtnSustitucionSI.Text = "SI"
        Me.rbtnSustitucionSI.UseVisualStyleBackColor = True
        '
        'rbtnSustitucionNO
        '
        Me.rbtnSustitucionNO.AutoSize = True
        Me.rbtnSustitucionNO.Location = New System.Drawing.Point(233, 9)
        Me.rbtnSustitucionNO.Name = "rbtnSustitucionNO"
        Me.rbtnSustitucionNO.Size = New System.Drawing.Size(41, 17)
        Me.rbtnSustitucionNO.TabIndex = 10
        Me.rbtnSustitucionNO.Text = "NO"
        Me.rbtnSustitucionNO.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(299, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Método Pago"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnCliente)
        Me.GroupBox1.Controls.Add(Me.rbtnInterna)
        Me.GroupBox1.Location = New System.Drawing.Point(152, 127)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 31)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        '
        'rbtnCliente
        '
        Me.rbtnCliente.AutoSize = True
        Me.rbtnCliente.Checked = True
        Me.rbtnCliente.Location = New System.Drawing.Point(14, 9)
        Me.rbtnCliente.Margin = New System.Windows.Forms.Padding(1)
        Me.rbtnCliente.Name = "rbtnCliente"
        Me.rbtnCliente.Size = New System.Drawing.Size(57, 17)
        Me.rbtnCliente.TabIndex = 5
        Me.rbtnCliente.TabStop = True
        Me.rbtnCliente.Text = "Cliente"
        Me.rbtnCliente.UseVisualStyleBackColor = True
        '
        'rbtnInterna
        '
        Me.rbtnInterna.AutoSize = True
        Me.rbtnInterna.Location = New System.Drawing.Point(128, 9)
        Me.rbtnInterna.Name = "rbtnInterna"
        Me.rbtnInterna.Size = New System.Drawing.Size(58, 17)
        Me.rbtnInterna.TabIndex = 6
        Me.rbtnInterna.Text = "Interna"
        Me.rbtnInterna.UseVisualStyleBackColor = True
        '
        'txtRfcEmisor
        '
        Me.txtRfcEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRfcEmisor.ForeColor = System.Drawing.Color.Black
        Me.txtRfcEmisor.Location = New System.Drawing.Point(151, 66)
        Me.txtRfcEmisor.Name = "txtRfcEmisor"
        Me.txtRfcEmisor.Size = New System.Drawing.Size(384, 22)
        Me.txtRfcEmisor.TabIndex = 3
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.ForeColor = System.Drawing.Color.Black
        Me.txtObservaciones.Location = New System.Drawing.Point(156, 365)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(379, 136)
        Me.txtObservaciones.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(85, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Emisor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(50, 367)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 16)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Observaciones"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRfcReceptor
        '
        Me.txtRfcReceptor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRfcReceptor.ForeColor = System.Drawing.Color.Black
        Me.txtRfcReceptor.Location = New System.Drawing.Point(151, 99)
        Me.txtRfcReceptor.Name = "txtRfcReceptor"
        Me.txtRfcReceptor.Size = New System.Drawing.Size(384, 22)
        Me.txtRfcReceptor.TabIndex = 4
        '
        'cmbMotivoInterno
        '
        Me.cmbMotivoInterno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivoInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivoInterno.ForeColor = System.Drawing.Color.Black
        Me.cmbMotivoInterno.FormattingEnabled = True
        Me.cmbMotivoInterno.Location = New System.Drawing.Point(152, 208)
        Me.cmbMotivoInterno.Name = "cmbMotivoInterno"
        Me.cmbMotivoInterno.Size = New System.Drawing.Size(383, 24)
        Me.cmbMotivoInterno.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(71, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Receptor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(44, 299)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(327, 16)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "¿La factura corresponde al mismo emisor y receptor? "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(33, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "¿Quien solicita?"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDocumentoid
        '
        Me.lblDocumentoid.AutoSize = True
        Me.lblDocumentoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentoid.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentoid.Location = New System.Drawing.Point(153, 34)
        Me.lblDocumentoid.Name = "lblDocumentoid"
        Me.lblDocumentoid.Size = New System.Drawing.Size(16, 16)
        Me.lblDocumentoid.TabIndex = 1
        Me.lblDocumentoid.Text = "1"
        Me.lblDocumentoid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSolicita
        '
        Me.txtSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicita.ForeColor = System.Drawing.Color.Black
        Me.txtSolicita.Location = New System.Drawing.Point(151, 171)
        Me.txtSolicita.Name = "txtSolicita"
        Me.txtSolicita.Size = New System.Drawing.Size(384, 22)
        Me.txtSolicita.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(44, 211)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Motivo Interno"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSolicita
        '
        Me.lblSolicita.AutoSize = True
        Me.lblSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSolicita.ForeColor = System.Drawing.Color.Black
        Me.lblSolicita.Location = New System.Drawing.Point(83, 177)
        Me.lblSolicita.Name = "lblSolicita"
        Me.lblSolicita.Size = New System.Drawing.Size(52, 16)
        Me.lblSolicita.TabIndex = 31
        Me.lblSolicita.Text = "Solicita"
        Me.lblSolicita.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(44, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(201, 16)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "¿La factura requiere sustitución? "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(304, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "DOCUMENTO"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 600)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(620, 70)
        Me.pnlPie.TabIndex = 76
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(455, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 70)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnGuardar.Location = New System.Drawing.Point(43, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 18
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(40, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 26)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Solicitud" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(106, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 19
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(105, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'SolicitudCancelacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 670)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SolicitudCancelacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud de cancelación"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.cmbInterno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblClienteNombre As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents lblDocumentoid As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblSolicita As Label
    Friend WithEvents txtSolicita As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRfcReceptor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRfcEmisor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMetodoPago As TextBox
    Friend WithEvents lblMonto As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents rbtnMismoEmisorReceptorSI As RadioButton
    Friend WithEvents rbtnMismoEmisorReceptorNO As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbMotivoInterno As ComboBox
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents rbtnCliente As RadioButton
    Friend WithEvents rbtnInterna As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbtnSustitucionSI As RadioButton
    Friend WithEvents rbtnSustitucionNO As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbInterno As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents GroupBox4 As GroupBox
End Class
