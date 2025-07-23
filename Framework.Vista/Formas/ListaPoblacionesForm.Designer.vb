<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPoblacionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPoblacionesForm))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grdPoblaciones = New System.Windows.Forms.DataGridView()
        Me.colPoblacionid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPoblacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idPais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbPuestos = New System.Windows.Forms.GroupBox()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtNombreDelPuesto = New System.Windows.Forms.TextBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaPoblaciones = New System.Windows.Forms.Label()
        Me.Editar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.grdPoblaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbPuestos.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdPoblaciones
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPoblaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPoblaciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPoblaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdPoblaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPoblaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPoblacionid, Me.numero, Me.ColPais, Me.ColEstado, Me.ColCiudad, Me.ColPoblacion, Me.ColActivo, Me.idCiudad, Me.idPais, Me.idEstado})
        Me.grdPoblaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPoblaciones.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdPoblaciones.Location = New System.Drawing.Point(0, 235)
        Me.grdPoblaciones.Name = "grdPoblaciones"
        Me.grdPoblaciones.RowHeadersWidth = 40
        Me.grdPoblaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdPoblaciones.Size = New System.Drawing.Size(874, 299)
        Me.grdPoblaciones.TabIndex = 13
        '
        'colPoblacionid
        '
        Me.colPoblacionid.HeaderText = "Poblacionid"
        Me.colPoblacionid.Name = "colPoblacionid"
        Me.colPoblacionid.Visible = False
        '
        'numero
        '
        Me.numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.numero.DefaultCellStyle = DataGridViewCellStyle3
        Me.numero.HeaderText = "#"
        Me.numero.Name = "numero"
        Me.numero.Width = 39
        '
        'ColPais
        '
        Me.ColPais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColPais.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColPais.FillWeight = 150.0!
        Me.ColPais.HeaderText = "País"
        Me.ColPais.Name = "ColPais"
        '
        'ColEstado
        '
        Me.ColEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColEstado.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColEstado.HeaderText = "Estado"
        Me.ColEstado.Name = "ColEstado"
        '
        'ColCiudad
        '
        Me.ColCiudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColCiudad.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColCiudad.FillWeight = 150.0!
        Me.ColCiudad.HeaderText = "Ciudad"
        Me.ColCiudad.Name = "ColCiudad"
        '
        'ColPoblacion
        '
        Me.ColPoblacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ColPoblacion.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColPoblacion.FillWeight = 150.0!
        Me.ColPoblacion.HeaderText = "Población"
        Me.ColPoblacion.Name = "ColPoblacion"
        '
        'ColActivo
        '
        Me.ColActivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColActivo.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColActivo.HeaderText = "Activo"
        Me.ColActivo.Name = "ColActivo"
        Me.ColActivo.Visible = False
        '
        'idCiudad
        '
        Me.idCiudad.HeaderText = "colIDCiudad"
        Me.idCiudad.Name = "idCiudad"
        Me.idCiudad.Visible = False
        '
        'idPais
        '
        Me.idPais.HeaderText = "colidPais"
        Me.idPais.Name = "idPais"
        Me.idPais.Visible = False
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "ColIdEstado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.Visible = False
        '
        'grbPuestos
        '
        Me.grbPuestos.Controls.Add(Me.rdoSi)
        Me.grbPuestos.Controls.Add(Me.btnNo)
        Me.grbPuestos.Controls.Add(Me.lblEstado)
        Me.grbPuestos.Controls.Add(Me.lblCiudad)
        Me.grbPuestos.Controls.Add(Me.cmbEstado)
        Me.grbPuestos.Controls.Add(Me.btnAbajo)
        Me.grbPuestos.Controls.Add(Me.cmbCiudad)
        Me.grbPuestos.Controls.Add(Me.btnArriba)
        Me.grbPuestos.Controls.Add(Me.lblBúscar)
        Me.grbPuestos.Controls.Add(Me.lblLimpiar)
        Me.grbPuestos.Controls.Add(Me.btnLimpiar)
        Me.grbPuestos.Controls.Add(Me.btnBuscar)
        Me.grbPuestos.Controls.Add(Me.lblNombre)
        Me.grbPuestos.Controls.Add(Me.lblPais)
        Me.grbPuestos.Controls.Add(Me.cmbPais)
        Me.grbPuestos.Controls.Add(Me.lblActivo)
        Me.grbPuestos.Controls.Add(Me.txtNombreDelPuesto)
        Me.grbPuestos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbPuestos.Location = New System.Drawing.Point(0, 60)
        Me.grbPuestos.Name = "grbPuestos"
        Me.grbPuestos.Size = New System.Drawing.Size(874, 175)
        Me.grbPuestos.TabIndex = 12
        Me.grbPuestos.TabStop = False
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(306, 146)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 5
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(360, 146)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 6
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(239, 70)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 32
        Me.lblEstado.Text = "Estado"
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Location = New System.Drawing.Point(239, 97)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(40, 13)
        Me.lblCiudad.TabIndex = 30
        Me.lblCiudad.Text = "Ciudad"
        '
        'cmbEstado
        '
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(304, 67)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(364, 21)
        Me.cmbEstado.TabIndex = 2
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(816, 10)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 28
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbCiudad
        '
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(304, 94)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(364, 21)
        Me.cmbCiudad.TabIndex = 3
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(792, 10)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 27
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(751, 149)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(801, 149)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(804, 115)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 8
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(754, 115)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 7
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(239, 123)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(54, 13)
        Me.lblNombre.TabIndex = 7
        Me.lblNombre.Text = "Población"
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(239, 43)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(29, 13)
        Me.lblPais.TabIndex = 6
        Me.lblPais.Text = "País"
        '
        'cmbPais
        '
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(304, 40)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(364, 21)
        Me.cmbPais.TabIndex = 1
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(239, 150)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Activo"
        '
        'txtNombreDelPuesto
        '
        Me.txtNombreDelPuesto.Location = New System.Drawing.Point(304, 120)
        Me.txtNombreDelPuesto.MaxLength = 50
        Me.txtNombreDelPuesto.Name = "txtNombreDelPuesto"
        Me.txtNombreDelPuesto.Size = New System.Drawing.Size(364, 20)
        Me.txtNombreDelPuesto.TabIndex = 4
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblListaPoblaciones)
        Me.pnlEncabezado.Controls.Add(Me.Editar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(874, 60)
        Me.pnlEncabezado.TabIndex = 11
        '
        'lblListaPoblaciones
        '
        Me.lblListaPoblaciones.AutoSize = True
        Me.lblListaPoblaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaPoblaciones.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaPoblaciones.Location = New System.Drawing.Point(706, 19)
        Me.lblListaPoblaciones.Name = "lblListaPoblaciones"
        Me.lblListaPoblaciones.Size = New System.Drawing.Size(106, 20)
        Me.lblListaPoblaciones.TabIndex = 21
        Me.lblListaPoblaciones.Text = "Poblaciones"
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(64, 40)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 19
        Me.Editar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(64, 5)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 5)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(18, 40)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Poblacionid"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn2.HeaderText = "#"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn3.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Pais"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn4.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn5.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Ciudad"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn6.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Poblacion"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "colIDCiudad"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "colidPais"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "ColIdEstado"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn10.HeaderText = "Activo"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(806, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'ListaPoblacionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(874, 534)
        Me.Controls.Add(Me.grdPoblaciones)
        Me.Controls.Add(Me.grbPuestos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.KeyPreview = True
        Me.Name = "ListaPoblacionesForm"
        Me.Text = "Poblaciones"
        CType(Me.grdPoblaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbPuestos.ResumeLayout(False)
        Me.grbPuestos.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdPoblaciones As System.Windows.Forms.DataGridView
    Friend WithEvents grbPuestos As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnNo As System.Windows.Forms.RadioButton
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtNombreDelPuesto As System.Windows.Forms.TextBox
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblListaPoblaciones As System.Windows.Forms.Label
    Friend WithEvents Editar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
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
    Friend WithEvents colPoblacionid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPais As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCiudad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPoblacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idCiudad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idPais As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As PictureBox
End Class
