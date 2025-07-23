<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class configuracionValorMoneda
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpValores3 = New System.Windows.Forms.GroupBox()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.grpValores = New System.Windows.Forms.GroupBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSimboloMoneda = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.cmbModulo = New System.Windows.Forms.ComboBox()
        Me.cmbTipoMoneda = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblParidad = New System.Windows.Forms.Label()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.txtParidad = New System.Windows.Forms.NumericUpDown()
        Me.txtValorAutomatico = New System.Windows.Forms.TextBox()
        Me.UltraGridBagLayoutManager1 = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.grdMoneda = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grpValores2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSimboloMoneda2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRecuperado = New System.Windows.Forms.Label()
        Me.lblFechaRecuperado = New System.Windows.Forms.Label()
        Me.tbtParidad = New System.Windows.Forms.TabControl()
        Me.tbtParidadPestania = New System.Windows.Forms.TabPage()
        Me.tbtModulos = New System.Windows.Forms.TabPage()
        Me.grdModuloCarga = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbModuloAlta = New System.Windows.Forms.ComboBox()
        Me.lblModuloAlta = New System.Windows.Forms.Label()
        Me.AppStylistRuntime1 = New Infragistics.Win.AppStyling.Runtime.AppStylistRuntime(Me.components)
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.grpValores3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpValores.SuspendLayout()
        CType(Me.txtParidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.grpValores2.SuspendLayout()
        Me.tbtParidad.SuspendLayout()
        Me.tbtParidadPestania.SuspendLayout()
        Me.tbtModulos.SuspendLayout()
        CType(Me.grdModuloCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlAcciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(708, 60)
        Me.pnlHeader.TabIndex = 2
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(120, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(475, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(233, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(12, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(155, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Paridad Cambiaria"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(173, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grpValores3)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 440)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(708, 60)
        Me.Panel2.TabIndex = 5
        '
        'grpValores3
        '
        Me.grpValores3.Controls.Add(Me.rdoInactivo)
        Me.grpValores3.Controls.Add(Me.rdoActivo)
        Me.grpValores3.Location = New System.Drawing.Point(22, 7)
        Me.grpValores3.Name = "grpValores3"
        Me.grpValores3.Size = New System.Drawing.Size(255, 41)
        Me.grpValores3.TabIndex = 10
        Me.grpValores3.TabStop = False
        Me.grpValores3.Text = "Estatus"
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(177, 14)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(72, 17)
        Me.rdoInactivo.TabIndex = 11
        Me.rdoInactivo.Text = "Anteriores"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(37, 14)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(61, 17)
        Me.rdoActivo.TabIndex = 41
        Me.rdoActivo.Text = "Vigente"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(553, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(155, 60)
        Me.Panel1.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(102, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_321
        Me.btnGuardar.Location = New System.Drawing.Point(44, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(101, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(38, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'grpValores
        '
        Me.grpValores.Controls.Add(Me.lblBuscar)
        Me.grpValores.Controls.Add(Me.Label5)
        Me.grpValores.Controls.Add(Me.Label4)
        Me.grpValores.Controls.Add(Me.lblSimboloMoneda)
        Me.grpValores.Controls.Add(Me.Label2)
        Me.grpValores.Controls.Add(Me.lblMoneda)
        Me.grpValores.Controls.Add(Me.cmbModulo)
        Me.grpValores.Controls.Add(Me.cmbTipoMoneda)
        Me.grpValores.Controls.Add(Me.btnBuscar)
        Me.grpValores.Controls.Add(Me.lblParidad)
        Me.grpValores.Controls.Add(Me.lblModulo)
        Me.grpValores.Controls.Add(Me.txtParidad)
        Me.grpValores.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpValores.Location = New System.Drawing.Point(0, 0)
        Me.grpValores.Name = "grpValores"
        Me.grpValores.Size = New System.Drawing.Size(414, 130)
        Me.grpValores.TabIndex = 7
        Me.grpValores.TabStop = False
        Me.grpValores.Text = "Paridad Manual"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(352, 75)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(56, 52)
        Me.lblBuscar.TabIndex = 49
        Me.lblBuscar.Text = "Mostrar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "paridad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Banco de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "México"
        Me.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "="
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(264, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Pesos ($)"
        '
        'lblSimboloMoneda
        '
        Me.lblSimboloMoneda.AutoSize = True
        Me.lblSimboloMoneda.Location = New System.Drawing.Point(117, 93)
        Me.lblSimboloMoneda.Name = "lblSimboloMoneda"
        Me.lblSimboloMoneda.Size = New System.Drawing.Size(13, 13)
        Me.lblSimboloMoneda.TabIndex = 40
        Me.lblSimboloMoneda.Text = "€"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(103, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "1"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(37, 58)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(53, 13)
        Me.lblMoneda.TabIndex = 40
        Me.lblMoneda.Text = "* Moneda"
        '
        'cmbModulo
        '
        Me.cmbModulo.FormattingEnabled = True
        Me.cmbModulo.Location = New System.Drawing.Point(100, 19)
        Me.cmbModulo.Name = "cmbModulo"
        Me.cmbModulo.Size = New System.Drawing.Size(217, 21)
        Me.cmbModulo.TabIndex = 3
        '
        'cmbTipoMoneda
        '
        Me.cmbTipoMoneda.FormattingEnabled = True
        Me.cmbTipoMoneda.Location = New System.Drawing.Point(100, 54)
        Me.cmbTipoMoneda.Name = "cmbTipoMoneda"
        Me.cmbTipoMoneda.Size = New System.Drawing.Size(217, 21)
        Me.cmbTipoMoneda.TabIndex = 4
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(361, 43)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblParidad
        '
        Me.lblParidad.AutoSize = True
        Me.lblParidad.Location = New System.Drawing.Point(37, 93)
        Me.lblParidad.Name = "lblParidad"
        Me.lblParidad.Size = New System.Drawing.Size(50, 13)
        Me.lblParidad.TabIndex = 33
        Me.lblParidad.Text = "* Paridad"
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = True
        Me.lblModulo.Location = New System.Drawing.Point(37, 23)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(49, 13)
        Me.lblModulo.TabIndex = 33
        Me.lblModulo.Text = "* Módulo"
        '
        'txtParidad
        '
        Me.txtParidad.DecimalPlaces = 2
        Me.txtParidad.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtParidad.Location = New System.Drawing.Point(168, 89)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(63, 20)
        Me.txtParidad.TabIndex = 5
        Me.txtParidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtValorAutomatico
        '
        Me.txtValorAutomatico.Location = New System.Drawing.Point(122, 36)
        Me.txtValorAutomatico.Name = "txtValorAutomatico"
        Me.txtValorAutomatico.Size = New System.Drawing.Size(44, 20)
        Me.txtValorAutomatico.TabIndex = 7
        '
        'grdMoneda
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMoneda.DisplayLayout.Appearance = Appearance1
        Me.grdMoneda.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMoneda.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMoneda.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMoneda.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMoneda.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdMoneda.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMoneda.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdMoneda.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdMoneda.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdMoneda.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdMoneda.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMoneda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMoneda.Location = New System.Drawing.Point(3, 133)
        Me.grdMoneda.Name = "grdMoneda"
        Me.grdMoneda.Size = New System.Drawing.Size(694, 218)
        Me.grdMoneda.TabIndex = 9
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.refresh_32
        Me.btnActualizar.Location = New System.Drawing.Point(234, 74)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 8
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.Location = New System.Drawing.Point(223, 108)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(53, 13)
        Me.lblActualizar.TabIndex = 45
        Me.lblActualizar.Text = "Actualizar"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grpValores2)
        Me.Panel3.Controls.Add(Me.grpValores)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(694, 130)
        Me.Panel3.TabIndex = 10
        '
        'grpValores2
        '
        Me.grpValores2.Controls.Add(Me.Label6)
        Me.grpValores2.Controls.Add(Me.lblSimboloMoneda2)
        Me.grpValores2.Controls.Add(Me.Label8)
        Me.grpValores2.Controls.Add(Me.Label1)
        Me.grpValores2.Controls.Add(Me.lblRecuperado)
        Me.grpValores2.Controls.Add(Me.lblFechaRecuperado)
        Me.grpValores2.Controls.Add(Me.txtValorAutomatico)
        Me.grpValores2.Controls.Add(Me.lblActualizar)
        Me.grpValores2.Controls.Add(Me.btnActualizar)
        Me.grpValores2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpValores2.Location = New System.Drawing.Point(414, 0)
        Me.grpValores2.Name = "grpValores2"
        Me.grpValores2.Size = New System.Drawing.Size(280, 130)
        Me.grpValores2.TabIndex = 47
        Me.grpValores2.TabStop = False
        Me.grpValores2.Text = "Información recuperada del Banco de México:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(68, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "="
        '
        'lblSimboloMoneda2
        '
        Me.lblSimboloMoneda2.AutoSize = True
        Me.lblSimboloMoneda2.Location = New System.Drawing.Point(49, 39)
        Me.lblSimboloMoneda2.Name = "lblSimboloMoneda2"
        Me.lblSimboloMoneda2.Size = New System.Drawing.Size(13, 13)
        Me.lblSimboloMoneda2.TabIndex = 53
        Me.lblSimboloMoneda2.Text = "€"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(179, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Pesos ($)"
        '
        'lblRecuperado
        '
        Me.lblRecuperado.AutoSize = True
        Me.lblRecuperado.Location = New System.Drawing.Point(33, 67)
        Me.lblRecuperado.Name = "lblRecuperado"
        Me.lblRecuperado.Size = New System.Drawing.Size(40, 13)
        Me.lblRecuperado.TabIndex = 50
        Me.lblRecuperado.Text = "Fecha:"
        '
        'lblFechaRecuperado
        '
        Me.lblFechaRecuperado.AutoSize = True
        Me.lblFechaRecuperado.Location = New System.Drawing.Point(82, 67)
        Me.lblFechaRecuperado.Name = "lblFechaRecuperado"
        Me.lblFechaRecuperado.Size = New System.Drawing.Size(39, 13)
        Me.lblFechaRecuperado.TabIndex = 49
        Me.lblFechaRecuperado.Text = "Label1"
        '
        'tbtParidad
        '
        Me.tbtParidad.Controls.Add(Me.tbtParidadPestania)
        Me.tbtParidad.Controls.Add(Me.tbtModulos)
        Me.tbtParidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtParidad.Location = New System.Drawing.Point(0, 60)
        Me.tbtParidad.Name = "tbtParidad"
        Me.tbtParidad.SelectedIndex = 0
        Me.tbtParidad.Size = New System.Drawing.Size(708, 380)
        Me.tbtParidad.TabIndex = 13
        '
        'tbtParidadPestania
        '
        Me.tbtParidadPestania.Controls.Add(Me.grdMoneda)
        Me.tbtParidadPestania.Controls.Add(Me.Panel3)
        Me.tbtParidadPestania.Location = New System.Drawing.Point(4, 22)
        Me.tbtParidadPestania.Name = "tbtParidadPestania"
        Me.tbtParidadPestania.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtParidadPestania.Size = New System.Drawing.Size(700, 354)
        Me.tbtParidadPestania.TabIndex = 0
        Me.tbtParidadPestania.Text = "Paridad"
        Me.tbtParidadPestania.UseVisualStyleBackColor = True
        '
        'tbtModulos
        '
        Me.tbtModulos.Controls.Add(Me.grdModuloCarga)
        Me.tbtModulos.Controls.Add(Me.Panel4)
        Me.tbtModulos.Location = New System.Drawing.Point(4, 22)
        Me.tbtModulos.Name = "tbtModulos"
        Me.tbtModulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtModulos.Size = New System.Drawing.Size(700, 354)
        Me.tbtModulos.TabIndex = 1
        Me.tbtModulos.Text = "Alta Módulo"
        Me.tbtModulos.UseVisualStyleBackColor = True
        '
        'grdModuloCarga
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdModuloCarga.DisplayLayout.Appearance = Appearance4
        Me.grdModuloCarga.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdModuloCarga.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdModuloCarga.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdModuloCarga.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdModuloCarga.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdModuloCarga.DisplayLayout.Override.RowAlternateAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.DarkGray
        Me.grdModuloCarga.DisplayLayout.Override.RowAppearance = Appearance6
        Me.grdModuloCarga.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdModuloCarga.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdModuloCarga.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdModuloCarga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdModuloCarga.Location = New System.Drawing.Point(3, 92)
        Me.grdModuloCarga.Name = "grdModuloCarga"
        Me.grdModuloCarga.Size = New System.Drawing.Size(694, 259)
        Me.grdModuloCarga.TabIndex = 15
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(694, 89)
        Me.Panel4.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbModuloAlta)
        Me.GroupBox1.Controls.Add(Me.lblModuloAlta)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(694, 89)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Módulo"
        '
        'cmbModuloAlta
        '
        Me.cmbModuloAlta.FormattingEnabled = True
        Me.cmbModuloAlta.Location = New System.Drawing.Point(73, 23)
        Me.cmbModuloAlta.Name = "cmbModuloAlta"
        Me.cmbModuloAlta.Size = New System.Drawing.Size(366, 21)
        Me.cmbModuloAlta.TabIndex = 14
        '
        'lblModuloAlta
        '
        Me.lblModuloAlta.AutoSize = True
        Me.lblModuloAlta.Location = New System.Drawing.Point(12, 26)
        Me.lblModuloAlta.Name = "lblModuloAlta"
        Me.lblModuloAlta.Size = New System.Drawing.Size(46, 13)
        Me.lblModuloAlta.TabIndex = 33
        Me.lblModuloAlta.Text = "*Módulo"
        Me.lblModuloAlta.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'configuracionValorMoneda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(708, 500)
        Me.Controls.Add(Me.tbtParidad)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(724, 539)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(724, 539)
        Me.Name = "configuracionValorMoneda"
        Me.Text = "Paridad Cambiaria"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.grpValores3.ResumeLayout(False)
        Me.grpValores3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpValores.ResumeLayout(False)
        Me.grpValores.PerformLayout()
        CType(Me.txtParidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.grpValores2.ResumeLayout(False)
        Me.grpValores2.PerformLayout()
        Me.tbtParidad.ResumeLayout(False)
        Me.tbtParidadPestania.ResumeLayout(False)
        Me.tbtModulos.ResumeLayout(False)
        CType(Me.grdModuloCarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents grpValores As System.Windows.Forms.GroupBox
    Friend WithEvents txtParidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSimboloMoneda As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents lblParidad As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents UltraGridBagLayoutManager1 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents txtValorAutomatico As System.Windows.Forms.TextBox
    Friend WithEvents grdMoneda As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents lblActualizar As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grpValores2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbtParidad As System.Windows.Forms.TabControl
    Friend WithEvents tbtParidadPestania As System.Windows.Forms.TabPage
    Friend WithEvents tbtModulos As System.Windows.Forms.TabPage
    Friend WithEvents grdModuloCarga As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbModuloAlta As System.Windows.Forms.ComboBox
    Friend WithEvents lblModuloAlta As System.Windows.Forms.Label
    Friend WithEvents AppStylistRuntime1 As Infragistics.Win.AppStyling.Runtime.AppStylistRuntime
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblRecuperado As System.Windows.Forms.Label
    Friend WithEvents lblFechaRecuperado As System.Windows.Forms.Label
    Friend WithEvents grpValores3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblSimboloMoneda2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
End Class
