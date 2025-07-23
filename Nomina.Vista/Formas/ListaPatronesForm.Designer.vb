<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPatronesForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPatronesForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaPatrones = New System.Windows.Forms.Label()
        Me.Editar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.grbPatrones = New System.Windows.Forms.GroupBox()
        Me.btnSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.txtNumeroDeRegistro = New System.Windows.Forms.TextBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblNombreDelPatron = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.lblNumeroDeRegistroPatronal = New System.Windows.Forms.Label()
        Me.txtNombreDelPatron = New System.Windows.Forms.TextBox()
        Me.grdPatrones = New System.Windows.Forms.DataGridView()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNombreDelPuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRFC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNumeroDeRegistroPatronal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColColonia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPatronId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalculoAguinaldosDS1 = New Nomina.Vista.CalculoAguinaldosDS()
        Me.CalculoAguinaldosDS2 = New Nomina.Vista.CalculoAguinaldosDS()
        Me.CalculoAguinaldosDS3 = New Nomina.Vista.CalculoAguinaldosDS()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.grbPatrones.SuspendLayout()
        CType(Me.grdPatrones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoAguinaldosDS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoAguinaldosDS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoAguinaldosDS3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pcbTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblListaPatrones)
        Me.pnlEncabezado.Controls.Add(Me.Editar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(693, 59)
        Me.pnlEncabezado.TabIndex = 3
        '
        'lblListaPatrones
        '
        Me.lblListaPatrones.AutoSize = True
        Me.lblListaPatrones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPatrones.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPatrones.Location = New System.Drawing.Point(426, 20)
        Me.lblListaPatrones.Name = "lblListaPatrones"
        Me.lblListaPatrones.Size = New System.Drawing.Size(177, 20)
        Me.lblListaPatrones.TabIndex = 21
        Me.lblListaPatrones.Text = "Registros Patronales"
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(61, 43)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 19
        Me.Editar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Nomina.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(61, 8)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(15, 43)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(14, 8)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'grbPatrones
        '
        Me.grbPatrones.Controls.Add(Me.btnSi)
        Me.grbPatrones.Controls.Add(Me.btnNo)
        Me.grbPatrones.Controls.Add(Me.btnAbajo)
        Me.grbPatrones.Controls.Add(Me.btnArriba)
        Me.grbPatrones.Controls.Add(Me.txtRFC)
        Me.grbPatrones.Controls.Add(Me.txtNumeroDeRegistro)
        Me.grbPatrones.Controls.Add(Me.lblActivo)
        Me.grbPatrones.Controls.Add(Me.lblBúscar)
        Me.grbPatrones.Controls.Add(Me.lblLimpiar)
        Me.grbPatrones.Controls.Add(Me.btnLimpiar)
        Me.grbPatrones.Controls.Add(Me.btnBuscar)
        Me.grbPatrones.Controls.Add(Me.lblNombreDelPatron)
        Me.grbPatrones.Controls.Add(Me.lblRFC)
        Me.grbPatrones.Controls.Add(Me.lblNumeroDeRegistroPatronal)
        Me.grbPatrones.Controls.Add(Me.txtNombreDelPatron)
        Me.grbPatrones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbPatrones.Location = New System.Drawing.Point(0, 59)
        Me.grbPatrones.Name = "grbPatrones"
        Me.grbPatrones.Size = New System.Drawing.Size(693, 175)
        Me.grbPatrones.TabIndex = 4
        Me.grbPatrones.TabStop = False
        '
        'btnSi
        '
        Me.btnSi.AutoSize = True
        Me.btnSi.Checked = True
        Me.btnSi.Location = New System.Drawing.Point(185, 138)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(36, 17)
        Me.btnSi.TabIndex = 28
        Me.btnSi.TabStop = True
        Me.btnSi.Text = "Sí"
        Me.btnSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(243, 138)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 29
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = Global.Nomina.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(653, 13)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 17
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = Global.Nomina.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(629, 13)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 16
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(188, 108)
        Me.txtRFC.MaxLength = 13
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(136, 20)
        Me.txtRFC.TabIndex = 4
        '
        'txtNumeroDeRegistro
        '
        Me.txtNumeroDeRegistro.Location = New System.Drawing.Point(189, 78)
        Me.txtNumeroDeRegistro.MaxLength = 100
        Me.txtNumeroDeRegistro.Name = "txtNumeroDeRegistro"
        Me.txtNumeroDeRegistro.Size = New System.Drawing.Size(363, 20)
        Me.txtNumeroDeRegistro.TabIndex = 5
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(40, 141)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 27
        Me.lblActivo.Text = "Activo"
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(589, 153)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(633, 153)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(640, 122)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(595, 122)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 14
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblNombreDelPatron
        '
        Me.lblNombreDelPatron.AutoSize = True
        Me.lblNombreDelPatron.Location = New System.Drawing.Point(40, 48)
        Me.lblNombreDelPatron.Name = "lblNombreDelPatron"
        Me.lblNombreDelPatron.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreDelPatron.TabIndex = 7
        Me.lblNombreDelPatron.Text = "Nombre "
        '
        'lblRFC
        '
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Location = New System.Drawing.Point(40, 108)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(28, 13)
        Me.lblRFC.TabIndex = 6
        Me.lblRFC.Text = "RFC"
        '
        'lblNumeroDeRegistroPatronal
        '
        Me.lblNumeroDeRegistroPatronal.AutoSize = True
        Me.lblNumeroDeRegistroPatronal.Location = New System.Drawing.Point(40, 78)
        Me.lblNumeroDeRegistroPatronal.Name = "lblNumeroDeRegistroPatronal"
        Me.lblNumeroDeRegistroPatronal.Size = New System.Drawing.Size(143, 13)
        Me.lblNumeroDeRegistroPatronal.TabIndex = 5
        Me.lblNumeroDeRegistroPatronal.Text = "Número de Registro Patronal"
        '
        'txtNombreDelPatron
        '
        Me.txtNombreDelPatron.Location = New System.Drawing.Point(188, 45)
        Me.txtNombreDelPatron.MaxLength = 50
        Me.txtNombreDelPatron.Name = "txtNombreDelPatron"
        Me.txtNombreDelPatron.Size = New System.Drawing.Size(364, 20)
        Me.txtNombreDelPatron.TabIndex = 3
        '
        'grdPatrones
        '
        Me.grdPatrones.AllowUserToAddRows = False
        Me.grdPatrones.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPatrones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPatrones.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPatrones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdPatrones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPatrones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numero, Me.ColNombreDelPuesto, Me.ColRFC, Me.ColNumeroDeRegistroPatronal, Me.ColCalle, Me.ColNumero, Me.ColColonia, Me.ColCiudad, Me.ColCP, Me.ColActivo, Me.ColPatronId})
        Me.grdPatrones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPatrones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdPatrones.GridColor = System.Drawing.Color.LightSteelBlue
        Me.grdPatrones.Location = New System.Drawing.Point(0, 234)
        Me.grdPatrones.Name = "grdPatrones"
        Me.grdPatrones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPatrones.Size = New System.Drawing.Size(693, 364)
        Me.grdPatrones.TabIndex = 11
        '
        'Numero
        '
        Me.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Numero.DefaultCellStyle = DataGridViewCellStyle3
        Me.Numero.FillWeight = 300.0!
        Me.Numero.HeaderText = "#"
        Me.Numero.Name = "Numero"
        Me.Numero.Width = 30
        '
        'ColNombreDelPuesto
        '
        Me.ColNombreDelPuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColNombreDelPuesto.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColNombreDelPuesto.HeaderText = "Nombre "
        Me.ColNombreDelPuesto.Name = "ColNombreDelPuesto"
        Me.ColNombreDelPuesto.Width = 210
        '
        'ColRFC
        '
        Me.ColRFC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColRFC.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColRFC.HeaderText = "RFC"
        Me.ColRFC.Name = "ColRFC"
        '
        'ColNumeroDeRegistroPatronal
        '
        Me.ColNumeroDeRegistroPatronal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColNumeroDeRegistroPatronal.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColNumeroDeRegistroPatronal.HeaderText = "Número de Registro Patronal"
        Me.ColNumeroDeRegistroPatronal.Name = "ColNumeroDeRegistroPatronal"
        Me.ColNumeroDeRegistroPatronal.Width = 200
        '
        'ColCalle
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColCalle.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColCalle.HeaderText = "Calle"
        Me.ColCalle.Name = "ColCalle"
        Me.ColCalle.Visible = False
        '
        'ColNumero
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColNumero.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColNumero.HeaderText = "Número"
        Me.ColNumero.Name = "ColNumero"
        Me.ColNumero.Visible = False
        '
        'ColColonia
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColColonia.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColColonia.HeaderText = "Colonia"
        Me.ColColonia.Name = "ColColonia"
        Me.ColColonia.Visible = False
        '
        'ColCiudad
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColCiudad.DefaultCellStyle = DataGridViewCellStyle10
        Me.ColCiudad.HeaderText = "Ciudad"
        Me.ColCiudad.Name = "ColCiudad"
        Me.ColCiudad.Visible = False
        '
        'ColCP
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColCP.DefaultCellStyle = DataGridViewCellStyle11
        Me.ColCP.HeaderText = "C.P."
        Me.ColCP.Name = "ColCP"
        Me.ColCP.Visible = False
        '
        'ColActivo
        '
        Me.ColActivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColActivo.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColActivo.HeaderText = "Activo"
        Me.ColActivo.Name = "ColActivo"
        '
        'ColPatronId
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColPatronId.DefaultCellStyle = DataGridViewCellStyle13
        Me.ColPatronId.HeaderText = "ColPatronId"
        Me.ColPatronId.Name = "ColPatronId"
        Me.ColPatronId.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn1.FillWeight = 300.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "#"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 30
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre "
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 250
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "RFC"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Número de registro patronal"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Calle"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Número"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Colonia"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Ciudad"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "C.P."
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.HeaderText = "Activo"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "ColPatronId"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'CalculoAguinaldosDS1
        '
        Me.CalculoAguinaldosDS1.DataSetName = "CalculoAguinaldosDS"
        Me.CalculoAguinaldosDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CalculoAguinaldosDS2
        '
        Me.CalculoAguinaldosDS2.DataSetName = "CalculoAguinaldosDS"
        Me.CalculoAguinaldosDS2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CalculoAguinaldosDS3
        '
        Me.CalculoAguinaldosDS3.DataSetName = "CalculoAguinaldosDS"
        Me.CalculoAguinaldosDS3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(625, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 30
        Me.pcbTitulo.TabStop = False
        '
        'ListaPatronesForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(693, 598)
        Me.Controls.Add(Me.grdPatrones)
        Me.Controls.Add(Me.grbPatrones)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(699, 620)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(699, 620)
        Me.Name = "ListaPatronesForm"
        Me.Text = "Registros Patronales"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.grbPatrones.ResumeLayout(False)
        Me.grbPatrones.PerformLayout()
        CType(Me.grdPatrones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoAguinaldosDS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoAguinaldosDS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoAguinaldosDS3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblListaPatrones As System.Windows.Forms.Label
	Friend WithEvents Editar As System.Windows.Forms.Label
	Friend WithEvents btnEditar As System.Windows.Forms.Button
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents grbPatrones As System.Windows.Forms.GroupBox
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents lblNombreDelPatron As System.Windows.Forms.Label
	Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDeRegistroPatronal As System.Windows.Forms.Label
	Friend WithEvents txtNombreDelPatron As System.Windows.Forms.TextBox
	Friend WithEvents grdPatrones As System.Windows.Forms.DataGridView
	Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroDeRegistro As System.Windows.Forms.TextBox
	Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents CalculoAguinaldosDS1 As Nomina.Vista.CalculoAguinaldosDS
    Friend WithEvents CalculoAguinaldosDS2 As Nomina.Vista.CalculoAguinaldosDS
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalculoAguinaldosDS3 As Nomina.Vista.CalculoAguinaldosDS
    Friend WithEvents btnSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnNo As System.Windows.Forms.RadioButton
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNombreDelPuesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRFC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNumeroDeRegistroPatronal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColColonia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCiudad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPatronId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
