<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CancelacionDocumentos_Form
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.grbDias = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdCfdiRelacionados = New DevExpress.XtraGrid.GridControl()
        Me.grdVCfdiRelacionados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grpInformacionCancelacion = New System.Windows.Forms.GroupBox()
        Me.lblRelacionMotivo = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblMarcasFacturarActual = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lblMontoMaximoFacturacionActual = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lblRestriccionFacturacionActual = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cmboxMotivoCancelacion = New System.Windows.Forms.ComboBox()
        Me.txtSolicita = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grpInformacionDocumento = New System.Windows.Forms.GroupBox()
        Me.lblAño = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblUbicacionProducto = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.lblMarcasFacturar = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblMontoMaximoFacturacion = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblUsoCFDI = New System.Windows.Forms.Label()
        Me.lblRestriccionFacturacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.lblRegimenFiscal = New System.Windows.Forms.Label()
        Me.lblRFCReceptor = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblEmisor = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblUUID = New System.Windows.Forms.Label()
        Me.lblFechaCaptura = New System.Windows.Forms.Label()
        Me.lblFolioFactura = New System.Windows.Forms.Label()
        Me.lblIdRemision = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.rdbNoRequiereAutorizacionCliente = New System.Windows.Forms.RadioButton()
        Me.rdbSiRequiereAutorizacionCliente = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtConsideraciones = New System.Windows.Forms.TextBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDNCTexto = New System.Windows.Forms.Label()
        Me.lblDNCTitulo = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblRelacion = New System.Windows.Forms.Label()
        Me.pnlTipoBusqueda = New System.Windows.Forms.Panel()
        Me.rdbSinRelacion = New System.Windows.Forms.RadioButton()
        Me.rdbConRelacion = New System.Windows.Forms.RadioButton()
        Me.txtFolioSustitucion = New System.Windows.Forms.TextBox()
        Me.grbDias.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdCfdiRelacionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVCfdiRelacionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInformacionCancelacion.SuspendLayout()
        Me.grpInformacionDocumento.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlBanner.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlTipoBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbDias
        '
        Me.grbDias.Controls.Add(Me.GroupBox1)
        Me.grbDias.Controls.Add(Me.grpInformacionCancelacion)
        Me.grbDias.Controls.Add(Me.grpInformacionDocumento)
        Me.grbDias.Controls.Add(Me.Label21)
        Me.grbDias.Controls.Add(Me.txtConsideraciones)
        Me.grbDias.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbDias.Location = New System.Drawing.Point(0, 60)
        Me.grbDias.Name = "grbDias"
        Me.grbDias.Size = New System.Drawing.Size(1235, 433)
        Me.grbDias.TabIndex = 32
        Me.grbDias.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdCfdiRelacionados)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(739, 195)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(490, 233)
        Me.GroupBox1.TabIndex = 65
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documentos Relacionados"
        '
        'grdCfdiRelacionados
        '
        Me.grdCfdiRelacionados.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdCfdiRelacionados.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdCfdiRelacionados.Location = New System.Drawing.Point(3, 16)
        Me.grdCfdiRelacionados.MainView = Me.grdVCfdiRelacionados
        Me.grdCfdiRelacionados.Name = "grdCfdiRelacionados"
        Me.grdCfdiRelacionados.Size = New System.Drawing.Size(484, 214)
        Me.grdCfdiRelacionados.TabIndex = 28
        Me.grdCfdiRelacionados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVCfdiRelacionados})
        '
        'grdVCfdiRelacionados
        '
        Me.grdVCfdiRelacionados.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.grdVCfdiRelacionados.Appearance.EvenRow.Options.UseBackColor = True
        Me.grdVCfdiRelacionados.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVCfdiRelacionados.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.grdVCfdiRelacionados.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdVCfdiRelacionados.Appearance.FocusedRow.Options.UseForeColor = True
        Me.grdVCfdiRelacionados.Appearance.OddRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.grdVCfdiRelacionados.Appearance.OddRow.Options.UseBackColor = True
        Me.grdVCfdiRelacionados.GridControl = Me.grdCfdiRelacionados
        Me.grdVCfdiRelacionados.Name = "grdVCfdiRelacionados"
        '
        'grpInformacionCancelacion
        '
        Me.grpInformacionCancelacion.Controls.Add(Me.txtFolioSustitucion)
        Me.grpInformacionCancelacion.Controls.Add(Me.pnlTipoBusqueda)
        Me.grpInformacionCancelacion.Controls.Add(Me.lblRelacion)
        Me.grpInformacionCancelacion.Controls.Add(Me.lblRelacionMotivo)
        Me.grpInformacionCancelacion.Controls.Add(Me.Label12)
        Me.grpInformacionCancelacion.Controls.Add(Me.txtObservaciones)
        Me.grpInformacionCancelacion.Controls.Add(Me.Label49)
        Me.grpInformacionCancelacion.Controls.Add(Me.lblMarcasFacturarActual)
        Me.grpInformacionCancelacion.Controls.Add(Me.Label43)
        Me.grpInformacionCancelacion.Controls.Add(Me.lblMontoMaximoFacturacionActual)
        Me.grpInformacionCancelacion.Controls.Add(Me.Label45)
        Me.grpInformacionCancelacion.Controls.Add(Me.lblRestriccionFacturacionActual)
        Me.grpInformacionCancelacion.Controls.Add(Me.Label47)
        Me.grpInformacionCancelacion.Controls.Add(Me.cmboxMotivoCancelacion)
        Me.grpInformacionCancelacion.Controls.Add(Me.txtSolicita)
        Me.grpInformacionCancelacion.Controls.Add(Me.Label6)
        Me.grpInformacionCancelacion.Controls.Add(Me.Label7)
        Me.grpInformacionCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInformacionCancelacion.Location = New System.Drawing.Point(7, 194)
        Me.grpInformacionCancelacion.Name = "grpInformacionCancelacion"
        Me.grpInformacionCancelacion.Size = New System.Drawing.Size(726, 234)
        Me.grpInformacionCancelacion.TabIndex = 30
        Me.grpInformacionCancelacion.TabStop = False
        Me.grpInformacionCancelacion.Text = "Información de la cancelación"
        '
        'lblRelacionMotivo
        '
        Me.lblRelacionMotivo.AutoSize = True
        Me.lblRelacionMotivo.Location = New System.Drawing.Point(430, 75)
        Me.lblRelacionMotivo.Name = "lblRelacionMotivo"
        Me.lblRelacionMotivo.Size = New System.Drawing.Size(11, 13)
        Me.lblRelacionMotivo.TabIndex = 105
        Me.lblRelacionMotivo.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 130)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 13)
        Me.Label12.TabIndex = 101
        Me.Label12.Text = "* Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(17, 146)
        Me.txtObservaciones.MaxLength = 300
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(695, 77)
        Me.txtObservaciones.TabIndex = 35
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(426, 46)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(237, 13)
        Me.Label49.TabIndex = 93
        Me.Label49.Text = "¿ Generar sustitución inmediata del documento ?"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMarcasFacturarActual
        '
        Me.lblMarcasFacturarActual.AutoSize = True
        Me.lblMarcasFacturarActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarcasFacturarActual.Location = New System.Drawing.Point(621, 19)
        Me.lblMarcasFacturarActual.Name = "lblMarcasFacturarActual"
        Me.lblMarcasFacturarActual.Size = New System.Drawing.Size(16, 13)
        Me.lblMarcasFacturarActual.TabIndex = 90
        Me.lblMarcasFacturarActual.Text = "---"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(521, 19)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(103, 13)
        Me.Label43.TabIndex = 89
        Me.Label43.Text = "Marcas Por Factura:"
        '
        'lblMontoMaximoFacturacionActual
        '
        Me.lblMontoMaximoFacturacionActual.AutoSize = True
        Me.lblMontoMaximoFacturacionActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoMaximoFacturacionActual.Location = New System.Drawing.Point(450, 19)
        Me.lblMontoMaximoFacturacionActual.Name = "lblMontoMaximoFacturacionActual"
        Me.lblMontoMaximoFacturacionActual.Size = New System.Drawing.Size(13, 13)
        Me.lblMontoMaximoFacturacionActual.TabIndex = 88
        Me.lblMontoMaximoFacturacionActual.Text = "0"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(332, 19)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(109, 13)
        Me.Label45.TabIndex = 87
        Me.Label45.Text = "Máximo por factura: $"
        '
        'lblRestriccionFacturacionActual
        '
        Me.lblRestriccionFacturacionActual.AutoSize = True
        Me.lblRestriccionFacturacionActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRestriccionFacturacionActual.Location = New System.Drawing.Point(216, 19)
        Me.lblRestriccionFacturacionActual.Name = "lblRestriccionFacturacionActual"
        Me.lblRestriccionFacturacionActual.Size = New System.Drawing.Size(16, 13)
        Me.lblRestriccionFacturacionActual.TabIndex = 86
        Me.lblRestriccionFacturacionActual.Text = "---"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(19, 19)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(197, 13)
        Me.Label47.TabIndex = 85
        Me.Label47.Text = "Restricciones de Facturación en la FTC:"
        '
        'cmboxMotivoCancelacion
        '
        Me.cmboxMotivoCancelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmboxMotivoCancelacion.FormattingEnabled = True
        Me.cmboxMotivoCancelacion.Location = New System.Drawing.Point(72, 71)
        Me.cmboxMotivoCancelacion.Name = "cmboxMotivoCancelacion"
        Me.cmboxMotivoCancelacion.Size = New System.Drawing.Size(347, 21)
        Me.cmboxMotivoCancelacion.TabIndex = 30
        '
        'txtSolicita
        '
        Me.txtSolicita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSolicita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolicita.Location = New System.Drawing.Point(72, 42)
        Me.txtSolicita.MaxLength = 50
        Me.txtSolicita.Name = "txtSolicita"
        Me.txtSolicita.Size = New System.Drawing.Size(347, 20)
        Me.txtSolicita.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "* Solicita"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "* Motivo"
        '
        'grpInformacionDocumento
        '
        Me.grpInformacionDocumento.Controls.Add(Me.lblAño)
        Me.grpInformacionDocumento.Controls.Add(Me.Label14)
        Me.grpInformacionDocumento.Controls.Add(Me.lblUbicacionProducto)
        Me.grpInformacionDocumento.Controls.Add(Me.Label50)
        Me.grpInformacionDocumento.Controls.Add(Me.lblMarcasFacturar)
        Me.grpInformacionDocumento.Controls.Add(Me.Label40)
        Me.grpInformacionDocumento.Controls.Add(Me.lblMontoMaximoFacturacion)
        Me.grpInformacionDocumento.Controls.Add(Me.Label38)
        Me.grpInformacionDocumento.Controls.Add(Me.lblUsoCFDI)
        Me.grpInformacionDocumento.Controls.Add(Me.lblRestriccionFacturacion)
        Me.grpInformacionDocumento.Controls.Add(Me.Label5)
        Me.grpInformacionDocumento.Controls.Add(Me.Label36)
        Me.grpInformacionDocumento.Controls.Add(Me.lblRegimenFiscal)
        Me.grpInformacionDocumento.Controls.Add(Me.lblRFCReceptor)
        Me.grpInformacionDocumento.Controls.Add(Me.lblNombreCliente)
        Me.grpInformacionDocumento.Controls.Add(Me.lblEmisor)
        Me.grpInformacionDocumento.Controls.Add(Me.lblMonto)
        Me.grpInformacionDocumento.Controls.Add(Me.Label31)
        Me.grpInformacionDocumento.Controls.Add(Me.lblTotalPares)
        Me.grpInformacionDocumento.Controls.Add(Me.lblUUID)
        Me.grpInformacionDocumento.Controls.Add(Me.lblFechaCaptura)
        Me.grpInformacionDocumento.Controls.Add(Me.lblFolioFactura)
        Me.grpInformacionDocumento.Controls.Add(Me.lblIdRemision)
        Me.grpInformacionDocumento.Controls.Add(Me.lblTipoDocumento)
        Me.grpInformacionDocumento.Controls.Add(Me.Label24)
        Me.grpInformacionDocumento.Controls.Add(Me.Label23)
        Me.grpInformacionDocumento.Controls.Add(Me.Label22)
        Me.grpInformacionDocumento.Controls.Add(Me.rdbNoRequiereAutorizacionCliente)
        Me.grpInformacionDocumento.Controls.Add(Me.rdbSiRequiereAutorizacionCliente)
        Me.grpInformacionDocumento.Controls.Add(Me.Label18)
        Me.grpInformacionDocumento.Controls.Add(Me.RadioButton2)
        Me.grpInformacionDocumento.Controls.Add(Me.RadioButton1)
        Me.grpInformacionDocumento.Controls.Add(Me.Label17)
        Me.grpInformacionDocumento.Controls.Add(Me.Label2)
        Me.grpInformacionDocumento.Controls.Add(Me.Label15)
        Me.grpInformacionDocumento.Controls.Add(Me.lblRazonSocial)
        Me.grpInformacionDocumento.Controls.Add(Me.Label13)
        Me.grpInformacionDocumento.Controls.Add(Me.Label11)
        Me.grpInformacionDocumento.Controls.Add(Me.TextBox9)
        Me.grpInformacionDocumento.Controls.Add(Me.Label10)
        Me.grpInformacionDocumento.Controls.Add(Me.TextBox8)
        Me.grpInformacionDocumento.Controls.Add(Me.Label9)
        Me.grpInformacionDocumento.Controls.Add(Me.TextBox7)
        Me.grpInformacionDocumento.Controls.Add(Me.Label8)
        Me.grpInformacionDocumento.Controls.Add(Me.Label4)
        Me.grpInformacionDocumento.Controls.Add(Me.Label3)
        Me.grpInformacionDocumento.Controls.Add(Me.Label1)
        Me.grpInformacionDocumento.Controls.Add(Me.lblCliente)
        Me.grpInformacionDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInformacionDocumento.Location = New System.Drawing.Point(7, 14)
        Me.grpInformacionDocumento.Name = "grpInformacionDocumento"
        Me.grpInformacionDocumento.Size = New System.Drawing.Size(944, 175)
        Me.grpInformacionDocumento.TabIndex = 29
        Me.grpInformacionDocumento.TabStop = False
        Me.grpInformacionDocumento.Text = "Información del documento"
        '
        'lblAño
        '
        Me.lblAño.AutoSize = True
        Me.lblAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAño.Location = New System.Drawing.Point(60, 83)
        Me.lblAño.Name = "lblAño"
        Me.lblAño.Size = New System.Drawing.Size(16, 13)
        Me.lblAño.TabIndex = 89
        Me.lblAño.Text = "---"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Año:"
        '
        'lblUbicacionProducto
        '
        Me.lblUbicacionProducto.AutoSize = True
        Me.lblUbicacionProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacionProducto.ForeColor = System.Drawing.Color.Green
        Me.lblUbicacionProducto.Location = New System.Drawing.Point(784, 83)
        Me.lblUbicacionProducto.Name = "lblUbicacionProducto"
        Me.lblUbicacionProducto.Size = New System.Drawing.Size(19, 13)
        Me.lblUbicacionProducto.TabIndex = 87
        Me.lblUbicacionProducto.Text = "---"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(731, 83)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(53, 13)
        Me.Label50.TabIndex = 85
        Me.Label50.Text = "Producto:"
        '
        'lblMarcasFacturar
        '
        Me.lblMarcasFacturar.AutoSize = True
        Me.lblMarcasFacturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarcasFacturar.Location = New System.Drawing.Point(653, 106)
        Me.lblMarcasFacturar.Name = "lblMarcasFacturar"
        Me.lblMarcasFacturar.Size = New System.Drawing.Size(16, 13)
        Me.lblMarcasFacturar.TabIndex = 84
        Me.lblMarcasFacturar.Text = "---"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(553, 106)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(103, 13)
        Me.Label40.TabIndex = 83
        Me.Label40.Text = "Marcas Por Factura:"
        '
        'lblMontoMaximoFacturacion
        '
        Me.lblMontoMaximoFacturacion.AutoSize = True
        Me.lblMontoMaximoFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoMaximoFacturacion.Location = New System.Drawing.Point(456, 106)
        Me.lblMontoMaximoFacturacion.Name = "lblMontoMaximoFacturacion"
        Me.lblMontoMaximoFacturacion.Size = New System.Drawing.Size(13, 13)
        Me.lblMontoMaximoFacturacion.TabIndex = 82
        Me.lblMontoMaximoFacturacion.Text = "0"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(341, 106)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(109, 13)
        Me.Label38.TabIndex = 81
        Me.Label38.Text = "Máximo por factura: $"
        '
        'lblUsoCFDI
        '
        Me.lblUsoCFDI.AutoSize = True
        Me.lblUsoCFDI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsoCFDI.Location = New System.Drawing.Point(88, 129)
        Me.lblUsoCFDI.Name = "lblUsoCFDI"
        Me.lblUsoCFDI.Size = New System.Drawing.Size(16, 13)
        Me.lblUsoCFDI.TabIndex = 80
        Me.lblUsoCFDI.Text = "---"
        '
        'lblRestriccionFacturacion
        '
        Me.lblRestriccionFacturacion.AutoSize = True
        Me.lblRestriccionFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRestriccionFacturacion.Location = New System.Drawing.Point(161, 106)
        Me.lblRestriccionFacturacion.Name = "lblRestriccionFacturacion"
        Me.lblRestriccionFacturacion.Size = New System.Drawing.Size(16, 13)
        Me.lblRestriccionFacturacion.TabIndex = 80
        Me.lblRestriccionFacturacion.Text = "---"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 79
        Me.Label5.Text = "Uso CFDI:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(18, 106)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(137, 13)
        Me.Label36.TabIndex = 79
        Me.Label36.Text = "Restricción de Facturación:"
        '
        'lblRegimenFiscal
        '
        Me.lblRegimenFiscal.AutoSize = True
        Me.lblRegimenFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegimenFiscal.Location = New System.Drawing.Point(103, 39)
        Me.lblRegimenFiscal.Name = "lblRegimenFiscal"
        Me.lblRegimenFiscal.Size = New System.Drawing.Size(16, 13)
        Me.lblRegimenFiscal.TabIndex = 78
        Me.lblRegimenFiscal.Text = "---"
        Me.lblRegimenFiscal.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRFCReceptor
        '
        Me.lblRFCReceptor.AutoSize = True
        Me.lblRFCReceptor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCReceptor.Location = New System.Drawing.Point(461, 19)
        Me.lblRFCReceptor.Name = "lblRFCReceptor"
        Me.lblRFCReceptor.Size = New System.Drawing.Size(16, 13)
        Me.lblRFCReceptor.TabIndex = 77
        Me.lblRFCReceptor.Text = "---"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(62, 19)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(19, 13)
        Me.lblNombreCliente.TabIndex = 76
        Me.lblNombreCliente.Text = "---"
        '
        'lblEmisor
        '
        Me.lblEmisor.AutoSize = True
        Me.lblEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmisor.Location = New System.Drawing.Point(466, 83)
        Me.lblEmisor.Name = "lblEmisor"
        Me.lblEmisor.Size = New System.Drawing.Size(16, 13)
        Me.lblEmisor.TabIndex = 75
        Me.lblEmisor.Text = "---"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.Location = New System.Drawing.Point(315, 83)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(16, 13)
        Me.lblMonto.TabIndex = 74
        Me.lblMonto.Text = "---"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(260, 83)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(49, 13)
        Me.Label31.TabIndex = 73
        Me.Label31.Text = "Monto: $"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.Location = New System.Drawing.Point(204, 83)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(16, 13)
        Me.lblTotalPares.TabIndex = 72
        Me.lblTotalPares.Text = "---"
        '
        'lblUUID
        '
        Me.lblUUID.AutoSize = True
        Me.lblUUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUUID.Location = New System.Drawing.Point(590, 60)
        Me.lblUUID.Name = "lblUUID"
        Me.lblUUID.Size = New System.Drawing.Size(16, 13)
        Me.lblUUID.TabIndex = 71
        Me.lblUUID.Text = "---"
        '
        'lblFechaCaptura
        '
        Me.lblFechaCaptura.AutoSize = True
        Me.lblFechaCaptura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaCaptura.Location = New System.Drawing.Point(384, 62)
        Me.lblFechaCaptura.Name = "lblFechaCaptura"
        Me.lblFechaCaptura.Size = New System.Drawing.Size(16, 13)
        Me.lblFechaCaptura.TabIndex = 70
        Me.lblFechaCaptura.Text = "---"
        '
        'lblFolioFactura
        '
        Me.lblFolioFactura.AutoSize = True
        Me.lblFolioFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioFactura.Location = New System.Drawing.Point(195, 60)
        Me.lblFolioFactura.Name = "lblFolioFactura"
        Me.lblFolioFactura.Size = New System.Drawing.Size(19, 13)
        Me.lblFolioFactura.TabIndex = 69
        Me.lblFolioFactura.Text = "---"
        '
        'lblIdRemision
        '
        Me.lblIdRemision.AutoSize = True
        Me.lblIdRemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdRemision.Location = New System.Drawing.Point(81, 60)
        Me.lblIdRemision.Name = "lblIdRemision"
        Me.lblIdRemision.Size = New System.Drawing.Size(19, 13)
        Me.lblIdRemision.TabIndex = 68
        Me.lblIdRemision.Text = "---"
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.AutoSize = True
        Me.lblTipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDocumento.ForeColor = System.Drawing.Color.Black
        Me.lblTipoDocumento.Location = New System.Drawing.Point(784, 39)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(19, 13)
        Me.lblTipoDocumento.TabIndex = 67
        Me.lblTipoDocumento.Text = "---"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(157, 60)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 13)
        Me.Label24.TabIndex = 65
        Me.Label24.Text = "Folio:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(321, 152)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(364, 13)
        Me.Label23.TabIndex = 64
        Me.Label23.Text = "(Remisión / <=$5,000 / RIF / <= 3 DIAS HAB. SAT / VENTA AL PUBLICO)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(681, 194)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(192, 13)
        Me.Label22.TabIndex = 63
        Me.Label22.Text = "(Tiene notas de crédito/cargo o pagos)"
        '
        'rdbNoRequiereAutorizacionCliente
        '
        Me.rdbNoRequiereAutorizacionCliente.AutoSize = True
        Me.rdbNoRequiereAutorizacionCliente.Checked = True
        Me.rdbNoRequiereAutorizacionCliente.Enabled = False
        Me.rdbNoRequiereAutorizacionCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbNoRequiereAutorizacionCliente.Location = New System.Drawing.Point(274, 150)
        Me.rdbNoRequiereAutorizacionCliente.Name = "rdbNoRequiereAutorizacionCliente"
        Me.rdbNoRequiereAutorizacionCliente.Size = New System.Drawing.Size(41, 17)
        Me.rdbNoRequiereAutorizacionCliente.TabIndex = 62
        Me.rdbNoRequiereAutorizacionCliente.TabStop = True
        Me.rdbNoRequiereAutorizacionCliente.Text = "NO"
        Me.rdbNoRequiereAutorizacionCliente.UseVisualStyleBackColor = True
        '
        'rdbSiRequiereAutorizacionCliente
        '
        Me.rdbSiRequiereAutorizacionCliente.AutoSize = True
        Me.rdbSiRequiereAutorizacionCliente.Enabled = False
        Me.rdbSiRequiereAutorizacionCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbSiRequiereAutorizacionCliente.Location = New System.Drawing.Point(233, 150)
        Me.rdbSiRequiereAutorizacionCliente.Name = "rdbSiRequiereAutorizacionCliente"
        Me.rdbSiRequiereAutorizacionCliente.Size = New System.Drawing.Size(35, 17)
        Me.rdbSiRequiereAutorizacionCliente.TabIndex = 61
        Me.rdbSiRequiereAutorizacionCliente.Text = "SI"
        Me.rdbSiRequiereAutorizacionCliente.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(18, 152)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(192, 13)
        Me.Label18.TabIndex = 60
        Me.Label18.Text = "¿Aceptaciòn del cliente para cancelar?"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(639, 192)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 17)
        Me.RadioButton2.TabIndex = 59
        Me.RadioButton2.Text = "NO "
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(596, 192)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(37, 17)
        Me.RadioButton1.TabIndex = 58
        Me.RadioButton1.Text = "SI"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(401, 194)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(115, 13)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "¿ Se puede cancelar ?"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(553, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "UUID:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(423, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "Emisor:"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.Location = New System.Drawing.Point(576, 19)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(16, 13)
        Me.lblRazonSocial.TabIndex = 51
        Me.lblRazonSocial.Text = "---"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(18, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "Régimen Fiscal:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(422, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "RFC:"
        '
        'TextBox9
        '
        Me.TextBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(851, 238)
        Me.TextBox9.MaxLength = 50
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(81, 20)
        Me.TextBox9.TabIndex = 42
        Me.TextBox9.Text = "109,458.56"
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(770, 241)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Saldo"
        '
        'TextBox8
        '
        Me.TextBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(851, 210)
        Me.TextBox8.MaxLength = 50
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(81, 20)
        Me.TextBox8.TabIndex = 40
        Me.TextBox8.Text = "50,000.00"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(769, 213)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "- Notas Crédito"
        '
        'TextBox7
        '
        Me.TextBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(851, 185)
        Me.TextBox7.MaxLength = 50
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(81, 20)
        Me.TextBox7.TabIndex = 38
        Me.TextBox7.Text = "100,000.00"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(769, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "- Pagado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(157, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Pares:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(341, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Fecha:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Documento:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(18, 19)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 13)
        Me.lblCliente.TabIndex = 7
        Me.lblCliente.Text = "Cliente:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.Location = New System.Drawing.Point(957, 14)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(216, 13)
        Me.Label21.TabIndex = 64
        Me.Label21.Text = "Consideraciones para la cancelación"
        '
        'txtConsideraciones
        '
        Me.txtConsideraciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsideraciones.ForeColor = System.Drawing.Color.Navy
        Me.txtConsideraciones.Location = New System.Drawing.Point(960, 30)
        Me.txtConsideraciones.MaxLength = 50
        Me.txtConsideraciones.Multiline = True
        Me.txtConsideraciones.Name = "txtConsideraciones"
        Me.txtConsideraciones.ReadOnly = True
        Me.txtConsideraciones.Size = New System.Drawing.Size(269, 158)
        Me.txtConsideraciones.TabIndex = 0
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1235, 60)
        Me.pnlHeader.TabIndex = 30
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pnlBanner)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.pnlTitulo.Location = New System.Drawing.Point(620, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(615, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'pnlBanner
        '
        Me.pnlBanner.Controls.Add(Me.lblTitulo)
        Me.pnlBanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlBanner.ForeColor = System.Drawing.Color.SteelBlue
        Me.pnlBanner.Location = New System.Drawing.Point(3, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(546, 60)
        Me.pnlBanner.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Location = New System.Drawing.Point(314, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(229, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Cancelación de Documento"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(555, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblDNCTexto)
        Me.Panel2.Controls.Add(Me.lblDNCTitulo)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 532)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1235, 58)
        Me.Panel2.TabIndex = 31
        '
        'lblDNCTexto
        '
        Me.lblDNCTexto.AutoSize = True
        Me.lblDNCTexto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDNCTexto.ForeColor = System.Drawing.Color.Red
        Me.lblDNCTexto.Location = New System.Drawing.Point(391, 26)
        Me.lblDNCTexto.Name = "lblDNCTexto"
        Me.lblDNCTexto.Size = New System.Drawing.Size(242, 26)
        Me.lblDNCTexto.TabIndex = 59
        Me.lblDNCTexto.Text = "Solicite al área de Cobranza la cancelación de los" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "documentos activos relacionad" &
    "os" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblDNCTexto.Visible = False
        '
        'lblDNCTitulo
        '
        Me.lblDNCTitulo.AutoSize = True
        Me.lblDNCTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDNCTitulo.ForeColor = System.Drawing.Color.Red
        Me.lblDNCTitulo.Location = New System.Drawing.Point(391, 10)
        Me.lblDNCTitulo.Name = "lblDNCTitulo"
        Me.lblDNCTitulo.Size = New System.Drawing.Size(191, 13)
        Me.lblDNCTitulo.TabIndex = 58
        Me.lblDNCTitulo.Text = "DOCUMENTO NO CANCELABLE"
        Me.lblDNCTitulo.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(214, 13)
        Me.Label20.TabIndex = 57
        Me.Label20.Text = "CRP - Comprobante de Recepción de Pago"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 40)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 13)
        Me.Label19.TabIndex = 56
        Me.Label19.Text = "NC - Nota de Crédito"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "ANT - Antiticipo"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(1078, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(157, 58)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(92, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(39, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(91, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(35, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'lblRelacion
        '
        Me.lblRelacion.AutoSize = True
        Me.lblRelacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelacion.Location = New System.Drawing.Point(22, 108)
        Me.lblRelacion.Name = "lblRelacion"
        Me.lblRelacion.Size = New System.Drawing.Size(69, 13)
        Me.lblRelacion.TabIndex = 106
        Me.lblRelacion.Text = "Con relación "
        '
        'pnlTipoBusqueda
        '
        Me.pnlTipoBusqueda.Controls.Add(Me.rdbSinRelacion)
        Me.pnlTipoBusqueda.Controls.Add(Me.rdbConRelacion)
        Me.pnlTipoBusqueda.Location = New System.Drawing.Point(89, 102)
        Me.pnlTipoBusqueda.Name = "pnlTipoBusqueda"
        Me.pnlTipoBusqueda.Size = New System.Drawing.Size(88, 25)
        Me.pnlTipoBusqueda.TabIndex = 107
        '
        'rdbSinRelacion
        '
        Me.rdbSinRelacion.AutoSize = True
        Me.rdbSinRelacion.Enabled = False
        Me.rdbSinRelacion.ForeColor = System.Drawing.Color.Black
        Me.rdbSinRelacion.Location = New System.Drawing.Point(46, 4)
        Me.rdbSinRelacion.Name = "rdbSinRelacion"
        Me.rdbSinRelacion.Size = New System.Drawing.Size(41, 17)
        Me.rdbSinRelacion.TabIndex = 77
        Me.rdbSinRelacion.Text = "No"
        Me.rdbSinRelacion.UseVisualStyleBackColor = True
        '
        'rdbConRelacion
        '
        Me.rdbConRelacion.AutoSize = True
        Me.rdbConRelacion.Checked = True
        Me.rdbConRelacion.Enabled = False
        Me.rdbConRelacion.ForeColor = System.Drawing.Color.Black
        Me.rdbConRelacion.Location = New System.Drawing.Point(3, 5)
        Me.rdbConRelacion.Name = "rdbConRelacion"
        Me.rdbConRelacion.Size = New System.Drawing.Size(37, 17)
        Me.rdbConRelacion.TabIndex = 76
        Me.rdbConRelacion.TabStop = True
        Me.rdbConRelacion.Text = "SI"
        Me.rdbConRelacion.UseVisualStyleBackColor = True
        '
        'txtFolioSustitucion
        '
        Me.txtFolioSustitucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolioSustitucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolioSustitucion.Location = New System.Drawing.Point(190, 107)
        Me.txtFolioSustitucion.MaxLength = 50
        Me.txtFolioSustitucion.Name = "txtFolioSustitucion"
        Me.txtFolioSustitucion.Size = New System.Drawing.Size(229, 20)
        Me.txtFolioSustitucion.TabIndex = 108
        '
        'CancelacionDocumentos_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1235, 590)
        Me.Controls.Add(Me.grbDias)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "CancelacionDocumentos_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelación de Documento"
        Me.grbDias.ResumeLayout(False)
        Me.grbDias.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdCfdiRelacionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVCfdiRelacionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInformacionCancelacion.ResumeLayout(False)
        Me.grpInformacionCancelacion.PerformLayout()
        Me.grpInformacionDocumento.ResumeLayout(False)
        Me.grpInformacionDocumento.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlTipoBusqueda.ResumeLayout(False)
        Me.pnlTipoBusqueda.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbDias As System.Windows.Forms.GroupBox
    Friend WithEvents grpInformacionDocumento As System.Windows.Forms.GroupBox
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents rdbNoRequiereAutorizacionCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSiRequiereAutorizacionCliente As System.Windows.Forms.RadioButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblRestriccionFacturacion As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblRegimenFiscal As System.Windows.Forms.Label
    Friend WithEvents lblRFCReceptor As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblEmisor As System.Windows.Forms.Label
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPares As System.Windows.Forms.Label
    Friend WithEvents lblUUID As System.Windows.Forms.Label
    Friend WithEvents lblFechaCaptura As System.Windows.Forms.Label
    Friend WithEvents lblFolioFactura As System.Windows.Forms.Label
    Friend WithEvents lblIdRemision As System.Windows.Forms.Label
    Friend WithEvents lblMarcasFacturar As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblMontoMaximoFacturacion As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblUbicacionProducto As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents grpInformacionCancelacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblMarcasFacturarActual As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents lblMontoMaximoFacturacionActual As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents lblRestriccionFacturacionActual As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmboxMotivoCancelacion As System.Windows.Forms.ComboBox
    Friend WithEvents txtConsideraciones As System.Windows.Forms.TextBox
    Friend WithEvents txtSolicita As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblAño As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblUsoCFDI As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grdCfdiRelacionados As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVCfdiRelacionados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblDNCTexto As Label
    Friend WithEvents lblDNCTitulo As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblRelacionMotivo As Label
    Friend WithEvents lblRelacion As Label
    Friend WithEvents pnlTipoBusqueda As Panel
    Friend WithEvents rdbSinRelacion As RadioButton
    Friend WithEvents rdbConRelacion As RadioButton
    Friend WithEvents txtFolioSustitucion As TextBox
End Class
