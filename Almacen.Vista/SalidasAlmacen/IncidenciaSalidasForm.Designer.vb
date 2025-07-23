<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncidenciaSalidasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncidenciaSalidasForm))
        Me.grdIncidencias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblFechaEmbarque = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblIdEmbarque = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grbDias = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFechaProximaEntrega = New System.Windows.Forms.CheckBox()
        Me.dtHoraNuevaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaNuevaEntrega = New System.Windows.Forms.DateTimePicker()
        Me.rdbNoOtraEntrega = New System.Windows.Forms.RadioButton()
        Me.rdbSiOtraEntrega = New System.Windows.Forms.RadioButton()
        Me.txtParesEntregados = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.txtUbicacionMercancia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipoIncidencia = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFechaIncidencia = New System.Windows.Forms.DateTimePicker()
        Me.cmbOperadorReporta = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblParesFaltantesEmbarque = New System.Windows.Forms.Label()
        Me.lblParesEntregadosEmbarque = New System.Windows.Forms.Label()
        Me.lblTotalParesEmbarque = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        CType(Me.grdIncidencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCampos.SuspendLayout()
        Me.grbDias.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdIncidencias
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdIncidencias.DisplayLayout.Appearance = Appearance1
        Me.grdIncidencias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdIncidencias.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdIncidencias.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdIncidencias.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdIncidencias.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdIncidencias.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdIncidencias.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdIncidencias.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdIncidencias.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdIncidencias.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdIncidencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdIncidencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdIncidencias.Location = New System.Drawing.Point(0, 251)
        Me.grdIncidencias.Name = "grdIncidencias"
        Me.grdIncidencias.Size = New System.Drawing.Size(1038, 195)
        Me.grdIncidencias.TabIndex = 37
        '
        'pnlCampos
        '
        Me.pnlCampos.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlCampos.Controls.Add(Me.lblPares)
        Me.pnlCampos.Controls.Add(Me.Label15)
        Me.pnlCampos.Controls.Add(Me.lblFechaEmbarque)
        Me.pnlCampos.Controls.Add(Me.Label16)
        Me.pnlCampos.Controls.Add(Me.lblCliente)
        Me.pnlCampos.Controls.Add(Me.Label11)
        Me.pnlCampos.Controls.Add(Me.lblIdEmbarque)
        Me.pnlCampos.Controls.Add(Me.Label13)
        Me.pnlCampos.Controls.Add(Me.btnArriba)
        Me.pnlCampos.Controls.Add(Me.btnAbajo)
        Me.pnlCampos.Controls.Add(Me.grbDias)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCampos.Location = New System.Drawing.Point(0, 60)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(1038, 191)
        Me.pnlCampos.TabIndex = 40
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.Location = New System.Drawing.Point(862, 5)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(38, 15)
        Me.lblPares.TabIndex = 94
        Me.lblPares.Text = "1,500"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(814, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 15)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "Pares:"
        '
        'lblFechaEmbarque
        '
        Me.lblFechaEmbarque.AutoSize = True
        Me.lblFechaEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEmbarque.Location = New System.Drawing.Point(642, 5)
        Me.lblFechaEmbarque.Name = "lblFechaEmbarque"
        Me.lblFechaEmbarque.Size = New System.Drawing.Size(131, 15)
        Me.lblFechaEmbarque.TabIndex = 92
        Me.lblFechaEmbarque.Text = "30/11/2015 04:35 P.M."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(531, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(105, 15)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "Fecha Embarque:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(202, 5)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(276, 15)
        Me.lblCliente.TabIndex = 90
        Me.lblCliente.Text = "ZAPATERÍAS MÉXICO ENCADENADAS SA DE CV"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(148, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 15)
        Me.Label11.TabIndex = 89
        Me.Label11.Text = "Cliente:"
        '
        'lblIdEmbarque
        '
        Me.lblIdEmbarque.AutoSize = True
        Me.lblIdEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdEmbarque.Location = New System.Drawing.Point(99, 5)
        Me.lblIdEmbarque.Name = "lblIdEmbarque"
        Me.lblIdEmbarque.Size = New System.Drawing.Size(14, 15)
        Me.lblIdEmbarque.TabIndex = 88
        Me.lblIdEmbarque.Text = "8"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 15)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Id Embarque:"
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(977, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(22, 22)
        Me.btnArriba.TabIndex = 1
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(1004, 2)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(22, 22)
        Me.btnAbajo.TabIndex = 2
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'grbDias
        '
        Me.grbDias.Controls.Add(Me.GroupBox1)
        Me.grbDias.Controls.Add(Me.txtParesEntregados)
        Me.grbDias.Controls.Add(Me.Label10)
        Me.grbDias.Controls.Add(Me.txtObservaciones)
        Me.grbDias.Controls.Add(Me.txtUbicacionMercancia)
        Me.grbDias.Controls.Add(Me.Label7)
        Me.grbDias.Controls.Add(Me.Label6)
        Me.grbDias.Controls.Add(Me.cmbTipoIncidencia)
        Me.grbDias.Controls.Add(Me.Label5)
        Me.grbDias.Controls.Add(Me.Label8)
        Me.grbDias.Controls.Add(Me.dtpFechaIncidencia)
        Me.grbDias.Controls.Add(Me.cmbOperadorReporta)
        Me.grbDias.Controls.Add(Me.Label1)
        Me.grbDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDias.Location = New System.Drawing.Point(12, 24)
        Me.grbDias.Name = "grbDias"
        Me.grbDias.Size = New System.Drawing.Size(1014, 161)
        Me.grbDias.TabIndex = 29
        Me.grbDias.TabStop = False
        Me.grbDias.Text = "Información de nueva incidencia"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFechaProximaEntrega)
        Me.GroupBox1.Controls.Add(Me.dtHoraNuevaEntrega)
        Me.GroupBox1.Controls.Add(Me.dtpFechaNuevaEntrega)
        Me.GroupBox1.Controls.Add(Me.rdbNoOtraEntrega)
        Me.GroupBox1.Controls.Add(Me.rdbSiOtraEntrega)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(815, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 116)
        Me.GroupBox1.TabIndex = 101
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "¿ Se realizará otra entrega ?"
        '
        'chkFechaProximaEntrega
        '
        Me.chkFechaProximaEntrega.AutoSize = True
        Me.chkFechaProximaEntrega.Location = New System.Drawing.Point(10, 43)
        Me.chkFechaProximaEntrega.Name = "chkFechaProximaEntrega"
        Me.chkFechaProximaEntrega.Size = New System.Drawing.Size(136, 17)
        Me.chkFechaProximaEntrega.TabIndex = 9
        Me.chkFechaProximaEntrega.Text = "Fecha Próxima Entrega"
        Me.chkFechaProximaEntrega.UseVisualStyleBackColor = True
        '
        'dtHoraNuevaEntrega
        '
        Me.dtHoraNuevaEntrega.Enabled = False
        Me.dtHoraNuevaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtHoraNuevaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtHoraNuevaEntrega.Location = New System.Drawing.Point(40, 90)
        Me.dtHoraNuevaEntrega.Name = "dtHoraNuevaEntrega"
        Me.dtHoraNuevaEntrega.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtHoraNuevaEntrega.ShowUpDown = True
        Me.dtHoraNuevaEntrega.Size = New System.Drawing.Size(86, 20)
        Me.dtHoraNuevaEntrega.TabIndex = 11
        Me.dtHoraNuevaEntrega.Value = New Date(2015, 12, 5, 13, 0, 0, 0)
        '
        'dtpFechaNuevaEntrega
        '
        Me.dtpFechaNuevaEntrega.CustomFormat = "yyyy/MM/dd"
        Me.dtpFechaNuevaEntrega.Enabled = False
        Me.dtpFechaNuevaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNuevaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNuevaEntrega.Location = New System.Drawing.Point(40, 67)
        Me.dtpFechaNuevaEntrega.Name = "dtpFechaNuevaEntrega"
        Me.dtpFechaNuevaEntrega.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaNuevaEntrega.TabIndex = 10
        Me.dtpFechaNuevaEntrega.Value = New Date(2015, 12, 5, 13, 49, 0, 0)
        '
        'rdbNoOtraEntrega
        '
        Me.rdbNoOtraEntrega.AutoSize = True
        Me.rdbNoOtraEntrega.Location = New System.Drawing.Point(40, 20)
        Me.rdbNoOtraEntrega.Name = "rdbNoOtraEntrega"
        Me.rdbNoOtraEntrega.Size = New System.Drawing.Size(39, 17)
        Me.rdbNoOtraEntrega.TabIndex = 7
        Me.rdbNoOtraEntrega.Text = "No"
        Me.rdbNoOtraEntrega.UseVisualStyleBackColor = True
        '
        'rdbSiOtraEntrega
        '
        Me.rdbSiOtraEntrega.AutoSize = True
        Me.rdbSiOtraEntrega.Location = New System.Drawing.Point(92, 20)
        Me.rdbSiOtraEntrega.Name = "rdbSiOtraEntrega"
        Me.rdbSiOtraEntrega.Size = New System.Drawing.Size(34, 17)
        Me.rdbSiOtraEntrega.TabIndex = 8
        Me.rdbSiOtraEntrega.Text = "Si"
        Me.rdbSiOtraEntrega.UseVisualStyleBackColor = True
        '
        'txtParesEntregados
        '
        Me.txtParesEntregados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParesEntregados.Location = New System.Drawing.Point(746, 22)
        Me.txtParesEntregados.Name = "txtParesEntregados"
        Me.txtParesEntregados.Size = New System.Drawing.Size(50, 20)
        Me.txtParesEntregados.TabIndex = 3
        Me.txtParesEntregados.Text = "150"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(644, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 13)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "* Pares entregados"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(115, 76)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(681, 54)
        Me.txtObservaciones.TabIndex = 5
        '
        'txtUbicacionMercancia
        '
        Me.txtUbicacionMercancia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUbicacionMercancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUbicacionMercancia.Location = New System.Drawing.Point(211, 134)
        Me.txtUbicacionMercancia.Name = "txtUbicacionMercancia"
        Me.txtUbicacionMercancia.Size = New System.Drawing.Size(792, 20)
        Me.txtUbicacionMercancia.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(200, 13)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "* Ubicación de la mercancía no recibida:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "* Observaciones"
        '
        'cmbTipoIncidencia
        '
        Me.cmbTipoIncidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIncidencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoIncidencia.FormattingEnabled = True
        Me.cmbTipoIncidencia.ItemHeight = 13
        Me.cmbTipoIncidencia.Location = New System.Drawing.Point(115, 48)
        Me.cmbTipoIncidencia.Name = "cmbTipoIncidencia"
        Me.cmbTipoIncidencia.Size = New System.Drawing.Size(681, 21)
        Me.cmbTipoIncidencia.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "* Tipo de Incidencia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "* Fecha "
        '
        'dtpFechaIncidencia
        '
        Me.dtpFechaIncidencia.CustomFormat = "yyyy/MM/dd"
        Me.dtpFechaIncidencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaIncidencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIncidencia.Location = New System.Drawing.Point(115, 22)
        Me.dtpFechaIncidencia.Name = "dtpFechaIncidencia"
        Me.dtpFechaIncidencia.Size = New System.Drawing.Size(86, 20)
        Me.dtpFechaIncidencia.TabIndex = 1
        '
        'cmbOperadorReporta
        '
        Me.cmbOperadorReporta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperadorReporta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperadorReporta.FormattingEnabled = True
        Me.cmbOperadorReporta.ItemHeight = 13
        Me.cmbOperadorReporta.Location = New System.Drawing.Point(339, 22)
        Me.cmbOperadorReporta.Name = "cmbOperadorReporta"
        Me.cmbOperadorReporta.Size = New System.Drawing.Size(284, 21)
        Me.cmbOperadorReporta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(218, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "* Operador que reporta"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.White
        Me.pnlAcciones.Controls.Add(Me.lblParesFaltantesEmbarque)
        Me.pnlAcciones.Controls.Add(Me.lblParesEntregadosEmbarque)
        Me.pnlAcciones.Controls.Add(Me.lblTotalParesEmbarque)
        Me.pnlAcciones.Controls.Add(Me.Label12)
        Me.pnlAcciones.Controls.Add(Me.Label4)
        Me.pnlAcciones.Controls.Add(Me.Label2)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblAceptar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnAceptar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 446)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1038, 60)
        Me.pnlAcciones.TabIndex = 39
        '
        'lblParesFaltantesEmbarque
        '
        Me.lblParesFaltantesEmbarque.BackColor = System.Drawing.Color.White
        Me.lblParesFaltantesEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesFaltantesEmbarque.ForeColor = System.Drawing.Color.Black
        Me.lblParesFaltantesEmbarque.Location = New System.Drawing.Point(220, 36)
        Me.lblParesFaltantesEmbarque.Name = "lblParesFaltantesEmbarque"
        Me.lblParesFaltantesEmbarque.Size = New System.Drawing.Size(54, 20)
        Me.lblParesFaltantesEmbarque.TabIndex = 124
        Me.lblParesFaltantesEmbarque.Text = "1,200"
        Me.lblParesFaltantesEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblParesEntregadosEmbarque
        '
        Me.lblParesEntregadosEmbarque.BackColor = System.Drawing.Color.White
        Me.lblParesEntregadosEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesEntregadosEmbarque.ForeColor = System.Drawing.Color.Black
        Me.lblParesEntregadosEmbarque.Location = New System.Drawing.Point(220, 18)
        Me.lblParesEntregadosEmbarque.Name = "lblParesEntregadosEmbarque"
        Me.lblParesEntregadosEmbarque.Size = New System.Drawing.Size(54, 20)
        Me.lblParesEntregadosEmbarque.TabIndex = 123
        Me.lblParesEntregadosEmbarque.Text = "300"
        Me.lblParesEntregadosEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalParesEmbarque
        '
        Me.lblTotalParesEmbarque.BackColor = System.Drawing.Color.White
        Me.lblTotalParesEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalParesEmbarque.ForeColor = System.Drawing.Color.Black
        Me.lblTotalParesEmbarque.Location = New System.Drawing.Point(220, 1)
        Me.lblTotalParesEmbarque.Name = "lblTotalParesEmbarque"
        Me.lblTotalParesEmbarque.Size = New System.Drawing.Size(54, 20)
        Me.lblTotalParesEmbarque.TabIndex = 122
        Me.lblTotalParesEmbarque.Text = "1,500"
        Me.lblTotalParesEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(141, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 20)
        Me.Label12.TabIndex = 121
        Me.Label12.Text = "Por Entregar : "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(139, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Entregados :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(135, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 20)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Total :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 42)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Resumen de pares " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "del embarque"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(985, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(928, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(45, 13)
        Me.lblAceptar.TabIndex = 4
        Me.lblAceptar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(984, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.guardar2_3211
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(935, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.lblExportar)
        Me.pnlCabecera.Controls.Add(Me.btnExportar)
        Me.pnlCabecera.Controls.Add(Me.pnlTitulo)
        Me.pnlCabecera.Controls.Add(Me.imgLogo)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1038, 60)
        Me.pnlCabecera.TabIndex = 38
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(17, 39)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 38
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(22, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 37
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(417, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(551, 60)
        Me.pnlTitulo.TabIndex = 36
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(242, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(306, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Incidencias en Entrega de Mercancía"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(968, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 35
        Me.imgLogo.TabStop = False
        '
        'IncidenciaSalidasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 506)
        Me.Controls.Add(Me.grdIncidencias)
        Me.Controls.Add(Me.pnlCampos)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlCabecera)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1054, 545)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1054, 545)
        Me.Name = "IncidenciaSalidasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Incidencias en Entrega de Mercancía"
        CType(Me.grdIncidencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCampos.ResumeLayout(False)
        Me.pnlCampos.PerformLayout()
        Me.grbDias.ResumeLayout(False)
        Me.grbDias.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdIncidencias As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents grbDias As System.Windows.Forms.GroupBox
    Friend WithEvents cmbOperadorReporta As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtUbicacionMercancia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoIncidencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIncidencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtParesEntregados As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtHoraNuevaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaNuevaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdbNoOtraEntrega As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSiOtraEntrega As System.Windows.Forms.RadioButton
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblFechaEmbarque As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblIdEmbarque As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblParesFaltantesEmbarque As System.Windows.Forms.Label
    Friend WithEvents lblParesEntregadosEmbarque As System.Windows.Forms.Label
    Friend WithEvents lblTotalParesEmbarque As System.Windows.Forms.Label
    Friend WithEvents chkFechaProximaEntrega As System.Windows.Forms.CheckBox
End Class
