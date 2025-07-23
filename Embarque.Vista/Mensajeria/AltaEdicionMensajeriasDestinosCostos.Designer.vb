<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaEdicionMensajeriasDestinosCostos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaEdicionMensajeriasDestinosCostos))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblOperacion = New System.Windows.Forms.Label()
        Me.lblTituloVentana = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grbDestinos = New System.Windows.Forms.GroupBox()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.chkPoblacion = New System.Windows.Forms.CheckBox()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.cmbPoblacion = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grdDestinos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dateFechaVigenciaFin = New System.Windows.Forms.DateTimePicker()
        Me.dateFechaVigenciaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.numMaxEntrega = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDiasEntrega = New System.Windows.Forms.Label()
        Me.cmbReenbarque = New System.Windows.Forms.ComboBox()
        Me.numMinEntrega = New System.Windows.Forms.NumericUpDown()
        Me.txtCostoUnidad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnGuardarCosto = New System.Windows.Forms.Button()
        Me.cmbUnidad = New System.Windows.Forms.ComboBox()
        Me.lblTipoUnidad = New System.Windows.Forms.Label()
        Me.lblVigencia = New System.Windows.Forms.Label()
        Me.lblReembarque = New System.Windows.Forms.Label()
        Me.lblCostoUnidad = New System.Windows.Forms.Label()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.grbDestinos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdDestinos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numMaxEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 464)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1129, 60)
        Me.pnlEstado.TabIndex = 68
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1025, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(104, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Embarque.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(35, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(34, 37)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1129, 59)
        Me.pnlEncabezado.TabIndex = 67
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblOperacion)
        Me.pnlTitulo.Controls.Add(Me.lblTituloVentana)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(533, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(596, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'lblOperacion
        '
        Me.lblOperacion.AutoSize = True
        Me.lblOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperacion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblOperacion.Location = New System.Drawing.Point(472, 9)
        Me.lblOperacion.Name = "lblOperacion"
        Me.lblOperacion.Size = New System.Drawing.Size(50, 20)
        Me.lblOperacion.TabIndex = 47
        Me.lblOperacion.Text = "Altas"
        Me.lblOperacion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTituloVentana
        '
        Me.lblTituloVentana.AutoSize = True
        Me.lblTituloVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloVentana.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTituloVentana.Location = New System.Drawing.Point(162, 26)
        Me.lblTituloVentana.Name = "lblTituloVentana"
        Me.lblTituloVentana.Size = New System.Drawing.Size(364, 20)
        Me.lblTituloVentana.TabIndex = 46
        Me.lblTituloVentana.Text = "Información Mensajerías - Destinos - Costos"
        Me.lblTituloVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(528, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.grbDestinos)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1129, 405)
        Me.Panel1.TabIndex = 69
        '
        'grbDestinos
        '
        Me.grbDestinos.Controls.Add(Me.lblCiudad)
        Me.grbDestinos.Controls.Add(Me.chkPoblacion)
        Me.grbDestinos.Controls.Add(Me.cmbProveedor)
        Me.grbDestinos.Controls.Add(Me.lblProveedor)
        Me.grbDestinos.Controls.Add(Me.cmbPoblacion)
        Me.grbDestinos.Controls.Add(Me.cmbEstado)
        Me.grbDestinos.Controls.Add(Me.lblEstado)
        Me.grbDestinos.Controls.Add(Me.cmbCiudad)
        Me.grbDestinos.Controls.Add(Me.cmbPais)
        Me.grbDestinos.Controls.Add(Me.lblPais)
        Me.grbDestinos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDestinos.Location = New System.Drawing.Point(15, 8)
        Me.grbDestinos.Name = "grbDestinos"
        Me.grbDestinos.Size = New System.Drawing.Size(510, 160)
        Me.grbDestinos.TabIndex = 0
        Me.grbDestinos.TabStop = False
        Me.grbDestinos.Text = "Destinos"
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCiudad.ForeColor = System.Drawing.Color.Black
        Me.lblCiudad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCiudad.Location = New System.Drawing.Point(36, 103)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(47, 13)
        Me.lblCiudad.TabIndex = 52
        Me.lblCiudad.Text = "* Ciudad"
        '
        'chkPoblacion
        '
        Me.chkPoblacion.AutoSize = True
        Me.chkPoblacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkPoblacion.ForeColor = System.Drawing.Color.Black
        Me.chkPoblacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkPoblacion.Location = New System.Drawing.Point(39, 131)
        Me.chkPoblacion.Name = "chkPoblacion"
        Me.chkPoblacion.Size = New System.Drawing.Size(73, 17)
        Me.chkPoblacion.TabIndex = 6
        Me.chkPoblacion.Text = "Población"
        Me.chkPoblacion.UseVisualStyleBackColor = True
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(120, 20)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(361, 21)
        Me.cmbProveedor.TabIndex = 1
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblProveedor.ForeColor = System.Drawing.Color.Black
        Me.lblProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProveedor.Location = New System.Drawing.Point(36, 23)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(63, 13)
        Me.lblProveedor.TabIndex = 51
        Me.lblProveedor.Text = "* Proveedor"
        '
        'cmbPoblacion
        '
        Me.cmbPoblacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPoblacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPoblacion.FormattingEnabled = True
        Me.cmbPoblacion.Location = New System.Drawing.Point(120, 128)
        Me.cmbPoblacion.Name = "cmbPoblacion"
        Me.cmbPoblacion.Size = New System.Drawing.Size(361, 21)
        Me.cmbPoblacion.TabIndex = 7
        Me.cmbPoblacion.Visible = False
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(120, 74)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(361, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblEstado.ForeColor = System.Drawing.Color.Black
        Me.lblEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEstado.Location = New System.Drawing.Point(36, 77)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(47, 13)
        Me.lblEstado.TabIndex = 47
        Me.lblEstado.Text = "* Estado"
        '
        'cmbCiudad
        '
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(120, 101)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(361, 21)
        Me.cmbCiudad.TabIndex = 5
        '
        'cmbPais
        '
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(120, 47)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(361, 21)
        Me.cmbPais.TabIndex = 2
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblPais.ForeColor = System.Drawing.Color.Black
        Me.lblPais.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPais.Location = New System.Drawing.Point(36, 50)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(36, 13)
        Me.lblPais.TabIndex = 45
        Me.lblPais.Text = "* País"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdDestinos)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 174)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1105, 222)
        Me.GroupBox3.TabIndex = 100
        Me.GroupBox3.TabStop = False
        '
        'grdDestinos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDestinos.DisplayLayout.Appearance = Appearance1
        Me.grdDestinos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdDestinos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDestinos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDestinos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDestinos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDestinos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdDestinos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance2.BackColor2 = System.Drawing.Color.White
        Me.grdDestinos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDestinos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDestinos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDestinos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDestinos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDestinos.Location = New System.Drawing.Point(3, 16)
        Me.grdDestinos.Name = "grdDestinos"
        Me.grdDestinos.Size = New System.Drawing.Size(1099, 203)
        Me.grdDestinos.TabIndex = 66
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dateFechaVigenciaFin)
        Me.GroupBox2.Controls.Add(Me.dateFechaVigenciaInicio)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.numMaxEntrega)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblDiasEntrega)
        Me.GroupBox2.Controls.Add(Me.cmbReenbarque)
        Me.GroupBox2.Controls.Add(Me.numMinEntrega)
        Me.GroupBox2.Controls.Add(Me.txtCostoUnidad)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnGuardarCosto)
        Me.GroupBox2.Controls.Add(Me.cmbUnidad)
        Me.GroupBox2.Controls.Add(Me.lblTipoUnidad)
        Me.GroupBox2.Controls.Add(Me.lblVigencia)
        Me.GroupBox2.Controls.Add(Me.lblReembarque)
        Me.GroupBox2.Controls.Add(Me.lblCostoUnidad)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(538, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(582, 160)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Costos Por Destino"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(514, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Guardar"
        '
        'dateFechaVigenciaFin
        '
        Me.dateFechaVigenciaFin.CustomFormat = ""
        Me.dateFechaVigenciaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateFechaVigenciaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFechaVigenciaFin.Location = New System.Drawing.Point(409, 128)
        Me.dateFechaVigenciaFin.Name = "dateFechaVigenciaFin"
        Me.dateFechaVigenciaFin.Size = New System.Drawing.Size(79, 20)
        Me.dateFechaVigenciaFin.TabIndex = 14
        Me.dateFechaVigenciaFin.Visible = False
        '
        'dateFechaVigenciaInicio
        '
        Me.dateFechaVigenciaInicio.CustomFormat = ""
        Me.dateFechaVigenciaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateFechaVigenciaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateFechaVigenciaInicio.Location = New System.Drawing.Point(239, 128)
        Me.dateFechaVigenciaInicio.Name = "dateFechaVigenciaInicio"
        Me.dateFechaVigenciaInicio.Size = New System.Drawing.Size(79, 20)
        Me.dateFechaVigenciaInicio.TabIndex = 13
        Me.dateFechaVigenciaInicio.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(351, 132)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 13)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Fin"
        Me.Label14.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(169, 132)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 13)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "Inicio"
        Me.Label13.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(351, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "Máximo"
        '
        'numMaxEntrega
        '
        Me.numMaxEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numMaxEntrega.Location = New System.Drawing.Point(409, 101)
        Me.numMaxEntrega.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
        Me.numMaxEntrega.Name = "numMaxEntrega"
        Me.numMaxEntrega.Size = New System.Drawing.Size(79, 20)
        Me.numMaxEntrega.TabIndex = 12
        Me.numMaxEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numMaxEntrega.ThousandsSeparator = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(169, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Mínimo"
        '
        'lblDiasEntrega
        '
        Me.lblDiasEntrega.AutoSize = True
        Me.lblDiasEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDiasEntrega.ForeColor = System.Drawing.Color.Black
        Me.lblDiasEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDiasEntrega.Location = New System.Drawing.Point(39, 103)
        Me.lblDiasEntrega.Name = "lblDiasEntrega"
        Me.lblDiasEntrega.Size = New System.Drawing.Size(85, 13)
        Me.lblDiasEntrega.TabIndex = 89
        Me.lblDiasEntrega.Text = "Días de Entrega"
        '
        'cmbReenbarque
        '
        Me.cmbReenbarque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReenbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReenbarque.FormattingEnabled = True
        Me.cmbReenbarque.Location = New System.Drawing.Point(172, 74)
        Me.cmbReenbarque.Name = "cmbReenbarque"
        Me.cmbReenbarque.Size = New System.Drawing.Size(316, 21)
        Me.cmbReenbarque.TabIndex = 10
        '
        'numMinEntrega
        '
        Me.numMinEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numMinEntrega.Location = New System.Drawing.Point(239, 101)
        Me.numMinEntrega.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
        Me.numMinEntrega.Name = "numMinEntrega"
        Me.numMinEntrega.Size = New System.Drawing.Size(79, 20)
        Me.numMinEntrega.TabIndex = 11
        Me.numMinEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numMinEntrega.ThousandsSeparator = True
        '
        'txtCostoUnidad
        '
        Me.txtCostoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoUnidad.Location = New System.Drawing.Point(172, 47)
        Me.txtCostoUnidad.MaxLength = 200
        Me.txtCostoUnidad.Name = "txtCostoUnidad"
        Me.txtCostoUnidad.Size = New System.Drawing.Size(107, 20)
        Me.txtCostoUnidad.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(520, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Costo"
        '
        'btnGuardarCosto
        '
        Me.btnGuardarCosto.Image = Global.Embarque.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarCosto.Location = New System.Drawing.Point(517, 96)
        Me.btnGuardarCosto.Name = "btnGuardarCosto"
        Me.btnGuardarCosto.Size = New System.Drawing.Size(32, 29)
        Me.btnGuardarCosto.TabIndex = 13
        Me.btnGuardarCosto.UseVisualStyleBackColor = True
        '
        'cmbUnidad
        '
        Me.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUnidad.FormattingEnabled = True
        Me.cmbUnidad.Location = New System.Drawing.Point(172, 20)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(316, 21)
        Me.cmbUnidad.TabIndex = 8
        '
        'lblTipoUnidad
        '
        Me.lblTipoUnidad.AutoSize = True
        Me.lblTipoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblTipoUnidad.ForeColor = System.Drawing.Color.Black
        Me.lblTipoUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoUnidad.Location = New System.Drawing.Point(39, 23)
        Me.lblTipoUnidad.Name = "lblTipoUnidad"
        Me.lblTipoUnidad.Size = New System.Drawing.Size(48, 13)
        Me.lblTipoUnidad.TabIndex = 51
        Me.lblTipoUnidad.Text = "* Unidad"
        '
        'lblVigencia
        '
        Me.lblVigencia.AutoSize = True
        Me.lblVigencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblVigencia.ForeColor = System.Drawing.Color.Black
        Me.lblVigencia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVigencia.Location = New System.Drawing.Point(39, 131)
        Me.lblVigencia.Name = "lblVigencia"
        Me.lblVigencia.Size = New System.Drawing.Size(48, 13)
        Me.lblVigencia.TabIndex = 49
        Me.lblVigencia.Text = "Vigencia"
        Me.lblVigencia.Visible = False
        '
        'lblReembarque
        '
        Me.lblReembarque.AutoSize = True
        Me.lblReembarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblReembarque.ForeColor = System.Drawing.Color.Black
        Me.lblReembarque.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReembarque.Location = New System.Drawing.Point(39, 77)
        Me.lblReembarque.Name = "lblReembarque"
        Me.lblReembarque.Size = New System.Drawing.Size(75, 13)
        Me.lblReembarque.TabIndex = 47
        Me.lblReembarque.Text = "* Reembarque"
        '
        'lblCostoUnidad
        '
        Me.lblCostoUnidad.AutoSize = True
        Me.lblCostoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCostoUnidad.ForeColor = System.Drawing.Color.Black
        Me.lblCostoUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCostoUnidad.Location = New System.Drawing.Point(39, 50)
        Me.lblCostoUnidad.Name = "lblCostoUnidad"
        Me.lblCostoUnidad.Size = New System.Drawing.Size(109, 13)
        Me.lblCostoUnidad.TabIndex = 45
        Me.lblCostoUnidad.Text = "* Costo Por Unidad  $"
        '
        'AltaEdicionMensajeriasDestinosCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1129, 524)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltaEdicionMensajeriasDestinosCostos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Altas de Mensajerías - Destinos - Costos"
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.grbDestinos.ResumeLayout(False)
        Me.grbDestinos.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdDestinos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numMaxEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTituloVentana As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblOperacion As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grbDestinos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents cmbPoblacion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnGuardarCosto As System.Windows.Forms.Button
    Friend WithEvents cmbUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoUnidad As System.Windows.Forms.Label
    Friend WithEvents lblVigencia As System.Windows.Forms.Label
    Friend WithEvents lblReembarque As System.Windows.Forms.Label
    Friend WithEvents lblCostoUnidad As System.Windows.Forms.Label
    Friend WithEvents txtCostoUnidad As System.Windows.Forms.TextBox
    Friend WithEvents numMinEntrega As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkPoblacion As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents numMaxEntrega As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDiasEntrega As System.Windows.Forms.Label
    Friend WithEvents cmbReenbarque As System.Windows.Forms.ComboBox
    Friend WithEvents dateFechaVigenciaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateFechaVigenciaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdDestinos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
End Class
