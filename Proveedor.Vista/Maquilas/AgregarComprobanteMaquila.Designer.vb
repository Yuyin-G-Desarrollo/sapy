<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgregarComprobanteMaquila
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgregarComprobanteMaquila))
        Me.grdComprobante = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPorDocumentar = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblTotalDocs = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblTotalFac = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblIVA = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblsubTotalFac = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblTotalRemisionado = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.btnXML = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnRemision = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMontoSinIva = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblRazSoc = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblPorcF = New System.Windows.Forms.Label()
        Me.lblParesF = New System.Windows.Forms.Label()
        Me.lblImpF = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.lblImpR = New System.Windows.Forms.Label()
        Me.lblParesR = New System.Windows.Forms.Label()
        Me.lblPorcR = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        CType(Me.grdComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdComprobante
        '
        Me.grdComprobante.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdComprobante.DisplayLayout.Appearance = Appearance1
        Me.grdComprobante.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdComprobante.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdComprobante.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdComprobante.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdComprobante.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdComprobante.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdComprobante.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdComprobante.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdComprobante.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdComprobante.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdComprobante.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdComprobante.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdComprobante.Location = New System.Drawing.Point(0, 150)
        Me.grdComprobante.Name = "grdComprobante"
        Me.grdComprobante.Size = New System.Drawing.Size(1066, 281)
        Me.grdComprobante.TabIndex = 77
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblPorDocumentar)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.lblTotalDocs)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.lblTotalFac)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.lblIVA)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.lblsubTotalFac)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Controls.Add(Me.lblTotalRemisionado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 437)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1066, 60)
        Me.Panel1.TabIndex = 76
        '
        'lblPorDocumentar
        '
        Me.lblPorDocumentar.AutoSize = True
        Me.lblPorDocumentar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorDocumentar.ForeColor = System.Drawing.Color.Red
        Me.lblPorDocumentar.Location = New System.Drawing.Point(676, 34)
        Me.lblPorDocumentar.Name = "lblPorDocumentar"
        Me.lblPorDocumentar.Size = New System.Drawing.Size(25, 13)
        Me.lblPorDocumentar.TabIndex = 59
        Me.lblPorDocumentar.Text = "$ 0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(595, 34)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 13)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "Por documentar:"
        '
        'lblTotalDocs
        '
        Me.lblTotalDocs.AutoSize = True
        Me.lblTotalDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDocs.Location = New System.Drawing.Point(676, 13)
        Me.lblTotalDocs.Name = "lblTotalDocs"
        Me.lblTotalDocs.Size = New System.Drawing.Size(25, 13)
        Me.lblTotalDocs.TabIndex = 57
        Me.lblTotalDocs.Text = "$ 0"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(568, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 13)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Total de Documentos:"
        '
        'lblTotalFac
        '
        Me.lblTotalFac.AutoSize = True
        Me.lblTotalFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFac.Location = New System.Drawing.Point(421, 13)
        Me.lblTotalFac.Name = "lblTotalFac"
        Me.lblTotalFac.Size = New System.Drawing.Size(25, 13)
        Me.lblTotalFac.TabIndex = 55
        Me.lblTotalFac.Text = "$ 0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(337, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 13)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "Total Facturado:"
        '
        'lblIVA
        '
        Me.lblIVA.AutoSize = True
        Me.lblIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVA.Location = New System.Drawing.Point(225, 13)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(25, 13)
        Me.lblIVA.TabIndex = 53
        Me.lblIVA.Text = "$ 0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(199, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 13)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "IVA:"
        '
        'lblsubTotalFac
        '
        Me.lblsubTotalFac.AutoSize = True
        Me.lblsubTotalFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubTotalFac.Location = New System.Drawing.Point(110, 13)
        Me.lblsubTotalFac.Name = "lblsubTotalFac"
        Me.lblsubTotalFac.Size = New System.Drawing.Size(25, 13)
        Me.lblsubTotalFac.TabIndex = 51
        Me.lblsubTotalFac.Text = "$ 0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(14, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Total Remisionado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Subtotal Facturado:"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.Label4)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(855, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(211, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(136, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(131, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(174, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(175, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblTotalRemisionado
        '
        Me.lblTotalRemisionado.AutoSize = True
        Me.lblTotalRemisionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRemisionado.Location = New System.Drawing.Point(110, 34)
        Me.lblTotalRemisionado.Name = "lblTotalRemisionado"
        Me.lblTotalRemisionado.Size = New System.Drawing.Size(25, 13)
        Me.lblTotalRemisionado.TabIndex = 50
        Me.lblTotalRemisionado.Text = "$ 0"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Button1)
        Me.pnlHeader.Controls.Add(Me.btnPDF)
        Me.pnlHeader.Controls.Add(Me.btnXML)
        Me.pnlHeader.Controls.Add(Me.btnQuitar)
        Me.pnlHeader.Controls.Add(Me.Label14)
        Me.pnlHeader.Controls.Add(Me.btnRemision)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.Label5)
        Me.pnlHeader.Controls.Add(Me.Label6)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1066, 60)
        Me.pnlHeader.TabIndex = 74
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.borrar_321
        Me.Button1.Location = New System.Drawing.Point(539, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 173
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'btnPDF
        '
        Me.btnPDF.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.agregar_pdf
        Me.btnPDF.Location = New System.Drawing.Point(68, 3)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnPDF.TabIndex = 169
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'btnXML
        '
        Me.btnXML.Image = Global.Proveedor.Vista.My.Resources.Resources.agregar_xml_32
        Me.btnXML.Location = New System.Drawing.Point(12, 3)
        Me.btnXML.Name = "btnXML"
        Me.btnXML.Size = New System.Drawing.Size(32, 32)
        Me.btnXML.TabIndex = 168
        Me.btnXML.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.borrar_321
        Me.btnQuitar.Location = New System.Drawing.Point(181, 3)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(32, 32)
        Me.btnQuitar.TabIndex = 87
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label14.Location = New System.Drawing.Point(8, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 26)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XML"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRemision
        '
        Me.btnRemision.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.listaPrecios
        Me.btnRemision.Location = New System.Drawing.Point(124, 3)
        Me.btnRemision.Name = "btnRemision"
        Me.btnRemision.Size = New System.Drawing.Size(32, 32)
        Me.btnRemision.TabIndex = 81
        Me.btnRemision.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(577, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(489, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(17, 25)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(400, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Comprobante de Compra de Producto Terminado"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(63, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 26)
        Me.Label3.TabIndex = 170
        Me.Label3.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PDF"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(109, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 26)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & "Documento"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(168, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 26)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "Quitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Documento"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(8, 16)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(325, 13)
        Me.lblFecha.TabIndex = 50
        Me.lblFecha.Text = "Comprobantes correspondientes a entregas del (FECHA)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Total monto sin IVA:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(51, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Total pares:"
        '
        'lblMontoSinIva
        '
        Me.lblMontoSinIva.AutoSize = True
        Me.lblMontoSinIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoSinIva.Location = New System.Drawing.Point(121, 40)
        Me.lblMontoSinIva.Name = "lblMontoSinIva"
        Me.lblMontoSinIva.Size = New System.Drawing.Size(36, 13)
        Me.lblMontoSinIva.TabIndex = 53
        Me.lblMontoSinIva.Text = "$ 0.0"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.Location = New System.Drawing.Point(121, 61)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(14, 13)
        Me.lblTotalPares.TabIndex = 54
        Me.lblTotalPares.Text = "0"
        '
        'lblRazSoc
        '
        Me.lblRazSoc.AutoSize = True
        Me.lblRazSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazSoc.Location = New System.Drawing.Point(253, 40)
        Me.lblRazSoc.Name = "lblRazSoc"
        Me.lblRazSoc.Size = New System.Drawing.Size(51, 13)
        Me.lblRazSoc.TabIndex = 59
        Me.lblRazSoc.Text = "RazSoc"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(622, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Porcentaje facturado:"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(641, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Pares facturados:"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(665, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "Facturación:"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(838, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(129, 13)
        Me.Label12.TabIndex = 63
        Me.Label12.Text = "Porcentaje documentado:"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(857, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 13)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Pares documentados:"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(905, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 13)
        Me.Label17.TabIndex = 65
        Me.Label17.Text = "Documento:"
        '
        'lblPorcF
        '
        Me.lblPorcF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorcF.AutoSize = True
        Me.lblPorcF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcF.Location = New System.Drawing.Point(737, 16)
        Me.lblPorcF.Name = "lblPorcF"
        Me.lblPorcF.Size = New System.Drawing.Size(30, 13)
        Me.lblPorcF.TabIndex = 66
        Me.lblPorcF.Text = "80%"
        '
        'lblParesF
        '
        Me.lblParesF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblParesF.AutoSize = True
        Me.lblParesF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesF.Location = New System.Drawing.Point(737, 40)
        Me.lblParesF.Name = "lblParesF"
        Me.lblParesF.Size = New System.Drawing.Size(14, 13)
        Me.lblParesF.TabIndex = 67
        Me.lblParesF.Text = "0"
        '
        'lblImpF
        '
        Me.lblImpF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImpF.AutoSize = True
        Me.lblImpF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpF.Location = New System.Drawing.Point(737, 61)
        Me.lblImpF.Name = "lblImpF"
        Me.lblImpF.Size = New System.Drawing.Size(25, 13)
        Me.lblImpF.TabIndex = 68
        Me.lblImpF.Text = "$ 0"
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.lblImpR)
        Me.grbParametros.Controls.Add(Me.lblParesR)
        Me.grbParametros.Controls.Add(Me.lblPorcR)
        Me.grbParametros.Controls.Add(Me.lblImpF)
        Me.grbParametros.Controls.Add(Me.lblParesF)
        Me.grbParametros.Controls.Add(Me.lblPorcF)
        Me.grbParametros.Controls.Add(Me.Label17)
        Me.grbParametros.Controls.Add(Me.Label13)
        Me.grbParametros.Controls.Add(Me.Label12)
        Me.grbParametros.Controls.Add(Me.Label11)
        Me.grbParametros.Controls.Add(Me.Label10)
        Me.grbParametros.Controls.Add(Me.Label7)
        Me.grbParametros.Controls.Add(Me.lblRazSoc)
        Me.grbParametros.Controls.Add(Me.lblTotalPares)
        Me.grbParametros.Controls.Add(Me.lblMontoSinIva)
        Me.grbParametros.Controls.Add(Me.Label9)
        Me.grbParametros.Controls.Add(Me.Label8)
        Me.grbParametros.Controls.Add(Me.lblFecha)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1066, 84)
        Me.grbParametros.TabIndex = 75
        Me.grbParametros.TabStop = False
        '
        'lblImpR
        '
        Me.lblImpR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImpR.AutoSize = True
        Me.lblImpR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpR.Location = New System.Drawing.Point(964, 61)
        Me.lblImpR.Name = "lblImpR"
        Me.lblImpR.Size = New System.Drawing.Size(25, 13)
        Me.lblImpR.TabIndex = 71
        Me.lblImpR.Text = "$ 0"
        '
        'lblParesR
        '
        Me.lblParesR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblParesR.AutoSize = True
        Me.lblParesR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesR.Location = New System.Drawing.Point(964, 40)
        Me.lblParesR.Name = "lblParesR"
        Me.lblParesR.Size = New System.Drawing.Size(14, 13)
        Me.lblParesR.TabIndex = 70
        Me.lblParesR.Text = "0"
        '
        'lblPorcR
        '
        Me.lblPorcR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPorcR.AutoSize = True
        Me.lblPorcR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcR.Location = New System.Drawing.Point(964, 16)
        Me.lblPorcR.Name = "lblPorcR"
        Me.lblPorcR.Size = New System.Drawing.Size(30, 13)
        Me.lblPorcR.TabIndex = 69
        Me.lblPorcR.Text = "80%"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(421, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'AgregarComprobanteMaquila
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1066, 497)
        Me.Controls.Add(Me.grdComprobante)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "AgregarComprobanteMaquila"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Comprobantes de Compra"
        CType(Me.grdComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdComprobante As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents lblTotalRemisionado As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Public WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnRemision As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnXML As System.Windows.Forms.Button
    Friend WithEvents btnPDF As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPorDocumentar As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblTotalDocs As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblTotalFac As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblsubTotalFac As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblFecha As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents lblMontoSinIva As Windows.Forms.Label
    Friend WithEvents lblTotalPares As Windows.Forms.Label
    Friend WithEvents lblRazSoc As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents lblPorcF As Windows.Forms.Label
    Friend WithEvents lblParesF As Windows.Forms.Label
    Friend WithEvents lblImpF As Windows.Forms.Label
    Friend WithEvents grbParametros As Windows.Forms.GroupBox
    Friend WithEvents lblImpR As Windows.Forms.Label
    Friend WithEvents lblParesR As Windows.Forms.Label
    Friend WithEvents lblPorcR As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
