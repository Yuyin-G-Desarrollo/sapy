<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PruebaFacturacion
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
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFormaPago = New System.Windows.Forms.TextBox()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMetodoPago = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCondicionPago = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMunicipio = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grdConceptos = New System.Windows.Forms.DataGridView()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estilo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtImpTotalRetenidos = New System.Windows.Forms.TextBox()
        Me.txtImpTotalTraslados = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtImporteImp = New System.Windows.Forms.TextBox()
        Me.txtImpuesto = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtTasa = New System.Windows.Forms.TextBox()
        Me.btnGeneraXML = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.txtRutaXML = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnRegenerarPDF_WS = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(66, 19)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(509, 21)
        Me.cmbEmpresa.TabIndex = 0
        '
        'cmbSucursal
        '
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(66, 46)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(509, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(77, 73)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(186, 20)
        Me.txtSerie.TabIndex = 2
        Me.txtSerie.Text = "AA"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(389, 74)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(186, 20)
        Me.txtFolio.TabIndex = 3
        Me.txtFolio.Text = "00001"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Empresa:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Sucursal:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Serie:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(351, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Folio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Forma de pago:"
        '
        'txtFormaPago
        '
        Me.txtFormaPago.Location = New System.Drawing.Point(96, 100)
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.Size = New System.Drawing.Size(186, 20)
        Me.txtFormaPago.TabIndex = 9
        Me.txtFormaPago.Text = "PAGO EN UNA SOLA EXHIBICION"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Location = New System.Drawing.Point(389, 100)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(186, 20)
        Me.txtSubtotal.TabIndex = 11
        Me.txtSubtotal.Text = "36421.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(334, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Subtotal:"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(77, 126)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(186, 20)
        Me.txtTotal.TabIndex = 13
        Me.txtTotal.Text = "42248.36"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Total:"
        '
        'txtMetodoPago
        '
        Me.txtMetodoPago.Location = New System.Drawing.Point(389, 126)
        Me.txtMetodoPago.Name = "txtMetodoPago"
        Me.txtMetodoPago.Size = New System.Drawing.Size(186, 20)
        Me.txtMetodoPago.TabIndex = 15
        Me.txtMetodoPago.Text = "TRANSFERENCIA ELECTRONICA DE FONDOS"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(295, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Metodo de pago:"
        '
        'txtDescuento
        '
        Me.txtDescuento.Location = New System.Drawing.Point(77, 152)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(186, 20)
        Me.txtDescuento.TabIndex = 17
        Me.txtDescuento.Text = "0.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Descuento:"
        '
        'txtCondicionPago
        '
        Me.txtCondicionPago.Location = New System.Drawing.Point(389, 152)
        Me.txtCondicionPago.Name = "txtCondicionPago"
        Me.txtCondicionPago.Size = New System.Drawing.Size(186, 20)
        Me.txtCondicionPago.TabIndex = 19
        Me.txtCondicionPago.Text = "Credito"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(284, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Condicion de pago:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEmpresa)
        Me.GroupBox1.Controls.Add(Me.cmbSucursal)
        Me.GroupBox1.Controls.Add(Me.txtSerie)
        Me.GroupBox1.Controls.Add(Me.txtCondicionPago)
        Me.GroupBox1.Controls.Add(Me.txtFolio)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDescuento)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMetodoPago)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.txtFormaPago)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtSubtotal)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(586, 184)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comprobante"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCP)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtRFC)
        Me.GroupBox2.Controls.Add(Me.txtPais)
        Me.GroupBox2.Controls.Add(Me.txtNombre)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtEstado)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtMunicipio)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtColonia)
        Me.GroupBox2.Controls.Add(Me.txtCalle)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtNumero)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 202)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(589, 152)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Receptor"
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(80, 123)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(186, 20)
        Me.txtCP.TabIndex = 21
        Me.txtCP.Text = "11560"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(44, 126)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "CP:"
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(80, 18)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(186, 20)
        Me.txtRFC.TabIndex = 2
        Me.txtRFC.Text = "AAA010101AAA"
        '
        'txtPais
        '
        Me.txtPais.Location = New System.Drawing.Point(392, 97)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(186, 20)
        Me.txtPais.TabIndex = 19
        Me.txtPais.Text = "MÉXICO"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(392, 19)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(186, 20)
        Me.txtNombre.TabIndex = 3
        Me.txtNombre.Text = "Receptor Prueba"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(356, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Pais:"
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(80, 97)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(186, 20)
        Me.txtEstado.TabIndex = 17
        Me.txtEstado.Text = "DISTRITO FEDERAL"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(31, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Estado:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(44, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "RFC"
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Location = New System.Drawing.Point(392, 71)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Size = New System.Drawing.Size(186, 20)
        Me.txtMunicipio.TabIndex = 15
        Me.txtMunicipio.Text = "MEXICO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(339, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Nombre:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(331, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Municipio:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(41, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Calle:"
        '
        'txtColonia
        '
        Me.txtColonia.Location = New System.Drawing.Point(80, 71)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(186, 20)
        Me.txtColonia.TabIndex = 13
        Me.txtColonia.Text = "PALMITAS DELEG. MIGUEL HIDALGO"
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(80, 45)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(186, 20)
        Me.txtCalle.TabIndex = 9
        Me.txtCalle.Text = "MONTE ELBRUZ"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(29, 74)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 13)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Colonia:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(339, 48)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 13)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Numero:"
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(392, 45)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(186, 20)
        Me.txtNumero.TabIndex = 11
        Me.txtNumero.Text = "124"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdConceptos)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 360)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(589, 120)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Conceptos"
        '
        'grdConceptos
        '
        Me.grdConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cantidad, Me.Unidad, Me.Descripcion, Me.Estilo, Me.ValorUnitario, Me.Importe})
        Me.grdConceptos.Location = New System.Drawing.Point(15, 20)
        Me.grdConceptos.Name = "grdConceptos"
        Me.grdConceptos.Size = New System.Drawing.Size(563, 89)
        Me.grdConceptos.TabIndex = 0
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'Unidad
        '
        Me.Unidad.HeaderText = "Unidad"
        Me.Unidad.Name = "Unidad"
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        '
        'Estilo
        '
        Me.Estilo.HeaderText = "Estilo"
        Me.Estilo.Name = "Estilo"
        '
        'ValorUnitario
        '
        Me.ValorUnitario.HeaderText = "ValorUnitario"
        Me.ValorUnitario.Name = "ValorUnitario"
        '
        'Importe
        '
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.txtImpTotalRetenidos)
        Me.GroupBox4.Controls.Add(Me.txtImpTotalTraslados)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.txtImporteImp)
        Me.GroupBox4.Controls.Add(Me.txtImpuesto)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.txtTasa)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 486)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(589, 98)
        Me.GroupBox4.TabIndex = 24
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Impuestos"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(301, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 13)
        Me.Label24.TabIndex = 22
        Me.Label24.Text = "Total Traslados:"
        '
        'txtImpTotalRetenidos
        '
        Me.txtImpTotalRetenidos.Location = New System.Drawing.Point(99, 18)
        Me.txtImpTotalRetenidos.Name = "txtImpTotalRetenidos"
        Me.txtImpTotalRetenidos.Size = New System.Drawing.Size(186, 20)
        Me.txtImpTotalRetenidos.TabIndex = 2
        Me.txtImpTotalRetenidos.Text = "0.00"
        '
        'txtImpTotalTraslados
        '
        Me.txtImpTotalTraslados.Location = New System.Drawing.Point(392, 18)
        Me.txtImpTotalTraslados.Name = "txtImpTotalTraslados"
        Me.txtImpTotalTraslados.Size = New System.Drawing.Size(186, 20)
        Me.txtImpTotalTraslados.TabIndex = 3
        Me.txtImpTotalTraslados.Text = "5827.36"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 21)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(85, 13)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Total Retenidos:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(40, 48)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 13)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Impuesto:"
        '
        'txtImporteImp
        '
        Me.txtImporteImp.Location = New System.Drawing.Point(99, 70)
        Me.txtImporteImp.Name = "txtImporteImp"
        Me.txtImporteImp.Size = New System.Drawing.Size(186, 20)
        Me.txtImporteImp.TabIndex = 13
        Me.txtImporteImp.Text = "5827.36"
        '
        'txtImpuesto
        '
        Me.txtImpuesto.Location = New System.Drawing.Point(99, 44)
        Me.txtImpuesto.Name = "txtImpuesto"
        Me.txtImpuesto.Size = New System.Drawing.Size(186, 20)
        Me.txtImpuesto.TabIndex = 9
        Me.txtImpuesto.Text = "IVA"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(31, 73)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 13)
        Me.Label27.TabIndex = 12
        Me.Label27.Text = "Importe Imp:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(339, 48)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(34, 13)
        Me.Label28.TabIndex = 10
        Me.Label28.Text = "Tasa:"
        '
        'txtTasa
        '
        Me.txtTasa.Location = New System.Drawing.Point(392, 44)
        Me.txtTasa.Name = "txtTasa"
        Me.txtTasa.Size = New System.Drawing.Size(186, 20)
        Me.txtTasa.TabIndex = 11
        Me.txtTasa.Text = "16.00"
        '
        'btnGeneraXML
        '
        Me.btnGeneraXML.Location = New System.Drawing.Point(604, 29)
        Me.btnGeneraXML.Name = "btnGeneraXML"
        Me.btnGeneraXML.Size = New System.Drawing.Size(75, 23)
        Me.btnGeneraXML.TabIndex = 25
        Me.btnGeneraXML.Text = "Genera XML"
        Me.btnGeneraXML.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(605, 109)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Cancelar Factura"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtRutaXML
        '
        Me.txtRutaXML.Location = New System.Drawing.Point(605, 85)
        Me.txtRutaXML.Name = "txtRutaXML"
        Me.txtRutaXML.Size = New System.Drawing.Size(353, 20)
        Me.txtRutaXML.TabIndex = 27
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(605, 186)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 23)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Regenerar PDF"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(605, 160)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(353, 20)
        Me.TextBox1.TabIndex = 30
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(605, 221)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(353, 20)
        Me.TextBox2.TabIndex = 32
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(605, 247)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(131, 23)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Regenerar PDF Canc"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnRegenerarPDF_WS
        '
        Me.btnRegenerarPDF_WS.Location = New System.Drawing.Point(605, 318)
        Me.btnRegenerarPDF_WS.Name = "btnRegenerarPDF_WS"
        Me.btnRegenerarPDF_WS.Size = New System.Drawing.Size(150, 23)
        Me.btnRegenerarPDF_WS.TabIndex = 33
        Me.btnRegenerarPDF_WS.Text = "RegenerarPDF WS"
        Me.btnRegenerarPDF_WS.UseVisualStyleBackColor = True
        '
        'PruebaFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 591)
        Me.Controls.Add(Me.btnRegenerarPDF_WS)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtRutaXML)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnGeneraXML)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PruebaFacturacion"
        Me.Text = "PruebaFacturacion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFormaPago As System.Windows.Forms.TextBox
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMetodoPago As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCondicionPago As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdConceptos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtImpTotalRetenidos As System.Windows.Forms.TextBox
    Friend WithEvents txtImpTotalTraslados As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtImporteImp As System.Windows.Forms.TextBox
    Friend WithEvents txtImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtTasa As System.Windows.Forms.TextBox
    Friend WithEvents btnGeneraXML As System.Windows.Forms.Button
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estilo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtRutaXML As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnRegenerarPDF_WS As System.Windows.Forms.Button
End Class
