<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListComprobantesMaqForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListComprobantesMaqForm))
        Me.grdComprobantes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.rdbFechaVenc = New System.Windows.Forms.RadioButton()
        Me.rdbFecCaptura = New System.Windows.Forms.RadioButton()
        Me.rdbFecDoc = New System.Windows.Forms.RadioButton()
        Me.rdbFecIngreso = New System.Windows.Forms.RadioButton()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDevolucion = New System.Windows.Forms.Button()
        Me.lblDev = New System.Windows.Forms.Label()
        Me.btnRemplazar = New System.Windows.Forms.Button()
        Me.lblRemplazar = New System.Windows.Forms.Label()
        Me.btnSustituir = New System.Windows.Forms.Button()
        Me.lblSustituir = New System.Windows.Forms.Label()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnAddComp = New System.Windows.Forms.Button()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.lblRechazar = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnl = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        CType(Me.grdComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbParametros.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdComprobantes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdComprobantes.DisplayLayout.Appearance = Appearance1
        Me.grdComprobantes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdComprobantes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdComprobantes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdComprobantes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdComprobantes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdComprobantes.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdComprobantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdComprobantes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdComprobantes.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdComprobantes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdComprobantes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdComprobantes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdComprobantes.Location = New System.Drawing.Point(0, 152)
        Me.grdComprobantes.Name = "grdComprobantes"
        Me.grdComprobantes.Size = New System.Drawing.Size(920, 279)
        Me.grdComprobantes.TabIndex = 71
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.rdbFechaVenc)
        Me.grbParametros.Controls.Add(Me.rdbFecCaptura)
        Me.grbParametros.Controls.Add(Me.rdbFecDoc)
        Me.grbParametros.Controls.Add(Me.rdbFecIngreso)
        Me.grbParametros.Controls.Add(Me.dtpFechaFinal)
        Me.grbParametros.Controls.Add(Me.dtpFechaInicio)
        Me.grbParametros.Controls.Add(Me.lblA)
        Me.grbParametros.Controls.Add(Me.lblDe)
        Me.grbParametros.Controls.Add(Me.btnMostrar)
        Me.grbParametros.Controls.Add(Me.Label4)
        Me.grbParametros.Controls.Add(Me.cmbEstatus)
        Me.grbParametros.Controls.Add(Me.Label11)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.Label7)
        Me.grbParametros.Controls.Add(Me.btnUp)
        Me.grbParametros.Controls.Add(Me.btnDown)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(920, 92)
        Me.grbParametros.TabIndex = 70
        Me.grbParametros.TabStop = False
        '
        'rdbFechaVenc
        '
        Me.rdbFechaVenc.AutoSize = True
        Me.rdbFechaVenc.Location = New System.Drawing.Point(681, 34)
        Me.rdbFechaVenc.Name = "rdbFechaVenc"
        Me.rdbFechaVenc.Size = New System.Drawing.Size(116, 17)
        Me.rdbFechaVenc.TabIndex = 88
        Me.rdbFechaVenc.Text = "Fecha Vencimiento"
        Me.rdbFechaVenc.UseVisualStyleBackColor = True
        '
        'rdbFecCaptura
        '
        Me.rdbFecCaptura.AutoSize = True
        Me.rdbFecCaptura.Location = New System.Drawing.Point(580, 34)
        Me.rdbFecCaptura.Name = "rdbFecCaptura"
        Me.rdbFecCaptura.Size = New System.Drawing.Size(95, 17)
        Me.rdbFecCaptura.TabIndex = 87
        Me.rdbFecCaptura.Text = "Fecha Captura"
        Me.rdbFecCaptura.UseVisualStyleBackColor = True
        '
        'rdbFecDoc
        '
        Me.rdbFecDoc.AutoSize = True
        Me.rdbFecDoc.Location = New System.Drawing.Point(459, 34)
        Me.rdbFecDoc.Name = "rdbFecDoc"
        Me.rdbFecDoc.Size = New System.Drawing.Size(113, 17)
        Me.rdbFecDoc.TabIndex = 86
        Me.rdbFecDoc.Text = "Fecha Documento"
        Me.rdbFecDoc.UseVisualStyleBackColor = True
        '
        'rdbFecIngreso
        '
        Me.rdbFecIngreso.AutoSize = True
        Me.rdbFecIngreso.Checked = True
        Me.rdbFecIngreso.Location = New System.Drawing.Point(337, 34)
        Me.rdbFecIngreso.Name = "rdbFecIngreso"
        Me.rdbFecIngreso.Size = New System.Drawing.Size(93, 17)
        Me.rdbFecIngreso.TabIndex = 85
        Me.rdbFecIngreso.TabStop = True
        Me.rdbFecIngreso.Text = "Fecha Ingreso"
        Me.rdbFecIngreso.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Location = New System.Drawing.Point(580, 64)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(215, 20)
        Me.dtpFechaFinal.TabIndex = 84
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Location = New System.Drawing.Point(337, 64)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(215, 20)
        Me.dtpFechaInicio.TabIndex = 83
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(308, 67)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(23, 13)
        Me.lblA.TabIndex = 82
        Me.lblA.Text = "Del"
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(558, 67)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(16, 13)
        Me.lblDe.TabIndex = 81
        Me.lblDe.Text = "Al"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(881, 34)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 70
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(877, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Mostrar"
        '
        'cmbEstatus
        '
        Me.cmbEstatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Items.AddRange(New Object() {"", "CAPTURADO", "AUTORIZADO", "RECHAZADO"})
        Me.cmbEstatus.Location = New System.Drawing.Point(52, 64)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(243, 21)
        Me.cmbEstatus.TabIndex = 80
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Estatus"
        '
        'cmbNave
        '
        Me.cmbNave.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(52, 34)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(243, 21)
        Me.cmbNave.TabIndex = 73
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Nave"
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.BackColor = System.Drawing.Color.White
        Me.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUp.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUp.Location = New System.Drawing.Point(897, 8)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(20, 20)
        Me.btnUp.TabIndex = 35
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.BackColor = System.Drawing.Color.White
        Me.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDown.Image = Global.Proveedor.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(874, 8)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 34
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnDetalle)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.btnDevolucion)
        Me.pnlHeader.Controls.Add(Me.lblDev)
        Me.pnlHeader.Controls.Add(Me.btnRemplazar)
        Me.pnlHeader.Controls.Add(Me.lblRemplazar)
        Me.pnlHeader.Controls.Add(Me.btnSustituir)
        Me.pnlHeader.Controls.Add(Me.lblSustituir)
        Me.pnlHeader.Controls.Add(Me.btnAutorizar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.btnAddComp)
        Me.pnlHeader.Controls.Add(Me.btnRechazar)
        Me.pnlHeader.Controls.Add(Me.lblAutorizar)
        Me.pnlHeader.Controls.Add(Me.lblRechazar)
        Me.pnlHeader.Controls.Add(Me.Label13)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(920, 60)
        Me.pnlHeader.TabIndex = 69
        '
        'btnDetalle
        '
        Me.btnDetalle.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources._1391114575_application_view_detail
        Me.btnDetalle.Image = Global.Proveedor.Vista.My.Resources.Resources._1391114575_application_view_detail
        Me.btnDetalle.Location = New System.Drawing.Point(361, 3)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(32, 32)
        Me.btnDetalle.TabIndex = 85
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(358, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 26)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Ver" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Detalle"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnDevolucion
        '
        Me.btnDevolucion.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnDevolucion.Image = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnDevolucion.Location = New System.Drawing.Point(299, 3)
        Me.btnDevolucion.Name = "btnDevolucion"
        Me.btnDevolucion.Size = New System.Drawing.Size(32, 32)
        Me.btnDevolucion.TabIndex = 83
        Me.btnDevolucion.UseVisualStyleBackColor = True
        '
        'lblDev
        '
        Me.lblDev.AutoSize = True
        Me.lblDev.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDev.Location = New System.Drawing.Point(287, 33)
        Me.lblDev.Name = "lblDev"
        Me.lblDev.Size = New System.Drawing.Size(61, 26)
        Me.lblDev.TabIndex = 82
        Me.lblDev.Text = "Aplicar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Devolución"
        Me.lblDev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRemplazar
        '
        Me.btnRemplazar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnRemplazar.Image = Global.Proveedor.Vista.My.Resources.Resources.copiar_32
        Me.btnRemplazar.Location = New System.Drawing.Point(226, 3)
        Me.btnRemplazar.Name = "btnRemplazar"
        Me.btnRemplazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRemplazar.TabIndex = 81
        Me.btnRemplazar.UseVisualStyleBackColor = True
        '
        'lblRemplazar
        '
        Me.lblRemplazar.AutoSize = True
        Me.lblRemplazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRemplazar.Location = New System.Drawing.Point(214, 32)
        Me.lblRemplazar.Name = "lblRemplazar"
        Me.lblRemplazar.Size = New System.Drawing.Size(62, 26)
        Me.lblRemplazar.TabIndex = 80
        Me.lblRemplazar.Text = "Remplazar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documento"
        Me.lblRemplazar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSustituir
        '
        Me.btnSustituir.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnSustituir.Image = Global.Proveedor.Vista.My.Resources.Resources.copiar_32
        Me.btnSustituir.Location = New System.Drawing.Point(174, 3)
        Me.btnSustituir.Name = "btnSustituir"
        Me.btnSustituir.Size = New System.Drawing.Size(32, 32)
        Me.btnSustituir.TabIndex = 79
        Me.btnSustituir.UseVisualStyleBackColor = True
        '
        'lblSustituir
        '
        Me.lblSustituir.AutoSize = True
        Me.lblSustituir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSustituir.Location = New System.Drawing.Point(169, 38)
        Me.lblSustituir.Name = "lblSustituir"
        Me.lblSustituir.Size = New System.Drawing.Size(44, 13)
        Me.lblSustituir.TabIndex = 78
        Me.lblSustituir.Text = "Sustituir"
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnAutorizar.Image = Global.Proveedor.Vista.My.Resources.Resources.autorizar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(71, 3)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 72
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(443, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(477, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(20, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(384, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Comprobantes de Compra Producto Terminado"
        '
        'btnAddComp
        '
        Me.btnAddComp.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.agregar_pdf
        Me.btnAddComp.Location = New System.Drawing.Point(17, 3)
        Me.btnAddComp.Name = "btnAddComp"
        Me.btnAddComp.Size = New System.Drawing.Size(32, 32)
        Me.btnAddComp.TabIndex = 67
        Me.btnAddComp.UseVisualStyleBackColor = True
        '
        'btnRechazar
        '
        Me.btnRechazar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnRechazar.Image = Global.Proveedor.Vista.My.Resources.Resources.rechazar_32
        Me.btnRechazar.Location = New System.Drawing.Point(123, 3)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazar.TabIndex = 68
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(65, 38)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizar.TabIndex = 65
        Me.lblAutorizar.Text = "Autorizar"
        '
        'lblRechazar
        '
        Me.lblRechazar.AutoSize = True
        Me.lblRechazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazar.Location = New System.Drawing.Point(114, 38)
        Me.lblRechazar.Name = "lblRechazar"
        Me.lblRechazar.Size = New System.Drawing.Size(53, 13)
        Me.lblRechazar.TabIndex = 66
        Me.lblRechazar.Text = "Rechazar"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label13.Location = New System.Drawing.Point(1, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 26)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Comprobante"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.pnl)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 431)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(920, 60)
        Me.Panel1.TabIndex = 68
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.GreenYellow
        Me.Panel3.Location = New System.Drawing.Point(99, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Autorizada"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Yellow
        Me.Panel2.Location = New System.Drawing.Point(12, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(15, 15)
        Me.Panel2.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Sin Autorizar"
        '
        'pnl
        '
        Me.pnl.BackColor = System.Drawing.Color.Salmon
        Me.pnl.Location = New System.Drawing.Point(180, 25)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(15, 15)
        Me.pnl.TabIndex = 41
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(196, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Rechazada"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(674, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'BackgroundWorker1
        '
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(409, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'ListComprobantesMaqForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 491)
        Me.Controls.Add(Me.grdComprobantes)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(928, 518)
        Me.Name = "ListComprobantesMaqForm"
        Me.Text = "Comprobantes de Compra de Producto Terminado"
        CType(Me.grdComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdComprobantes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents lblRechazar As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnl As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents rdbFecCaptura As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFecDoc As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFecIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents btnAddComp As System.Windows.Forms.Button
    Friend WithEvents rdbFechaVenc As System.Windows.Forms.RadioButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnSustituir As System.Windows.Forms.Button
    Friend WithEvents lblSustituir As System.Windows.Forms.Label
    Friend WithEvents btnRemplazar As System.Windows.Forms.Button
    Friend WithEvents lblRemplazar As System.Windows.Forms.Label
    Friend WithEvents btnDevolucion As System.Windows.Forms.Button
    Friend WithEvents lblDev As System.Windows.Forms.Label
    Friend WithEvents btnDetalle As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
