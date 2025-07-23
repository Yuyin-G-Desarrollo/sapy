<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosRegistradosDeLasNavesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductosRegistradosDeLasNavesForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblCopiar = New System.Windows.Forms.Label()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.btnFichaTecnica = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblModificar = New System.Windows.Forms.Label()
        Me.lblFichaTecnica = New System.Windows.Forms.Label()
        Me.btnCambiosGlobales = New System.Windows.Forms.Button()
        Me.lblCambiosGlobales = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdProductosRegistrados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTarjetaPrevia = New System.Windows.Forms.Label()
        Me.lblFichaCostos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblDesautorizar = New System.Windows.Forms.Label()
        Me.lblActivar = New System.Windows.Forms.Label()
        Me.lblDesactivar = New System.Windows.Forms.Label()
        Me.lblEliminar = New System.Windows.Forms.Label()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.btnDesautorizar = New System.Windows.Forms.Button()
        Me.btnActivar = New System.Windows.Forms.Button()
        Me.btnDesactivar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnTarjetaPrevia = New System.Windows.Forms.Button()
        Me.btnFichaCostos = New System.Windows.Forms.Button()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlInferior.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdProductosRegistrados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.lblCopiar)
        Me.pnlEncabezado.Controls.Add(Me.btnCopiar)
        Me.pnlEncabezado.Controls.Add(Me.btnFichaTecnica)
        Me.pnlEncabezado.Controls.Add(Me.btnAlta)
        Me.pnlEncabezado.Controls.Add(Me.lblAlta)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.lblModificar)
        Me.pnlEncabezado.Controls.Add(Me.lblFichaTecnica)
        Me.pnlEncabezado.Controls.Add(Me.btnCambiosGlobales)
        Me.pnlEncabezado.Controls.Add(Me.lblCambiosGlobales)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1130, 63)
        Me.pnlEncabezado.TabIndex = 153
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(664, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(395, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Productos con Consumos y Fracciones por Nave"
        '
        'lblCopiar
        '
        Me.lblCopiar.AutoSize = True
        Me.lblCopiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCopiar.Location = New System.Drawing.Point(134, 38)
        Me.lblCopiar.Name = "lblCopiar"
        Me.lblCopiar.Size = New System.Drawing.Size(37, 13)
        Me.lblCopiar.TabIndex = 187
        Me.lblCopiar.Text = "Copiar"
        Me.lblCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCopiar
        '
        Me.btnCopiar.Image = Global.Proveedor.Vista.My.Resources.Resources.copiarclientes
        Me.btnCopiar.Location = New System.Drawing.Point(136, 3)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(32, 32)
        Me.btnCopiar.TabIndex = 186
        Me.btnCopiar.UseVisualStyleBackColor = True
        '
        'btnFichaTecnica
        '
        Me.btnFichaTecnica.Image = Global.Proveedor.Vista.My.Resources.Resources.imprimir_32
        Me.btnFichaTecnica.Location = New System.Drawing.Point(198, 3)
        Me.btnFichaTecnica.Name = "btnFichaTecnica"
        Me.btnFichaTecnica.Size = New System.Drawing.Size(32, 32)
        Me.btnFichaTecnica.TabIndex = 166
        Me.btnFichaTecnica.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Proveedor.Vista.My.Resources.Resources.nuevo_32
        Me.btnAlta.Location = New System.Drawing.Point(13, 3)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 160
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(17, 38)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 161
        Me.lblAlta.Text = "Alta"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(73, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 162
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblModificar
        '
        Me.lblModificar.AutoSize = True
        Me.lblModificar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblModificar.Location = New System.Drawing.Point(72, 38)
        Me.lblModificar.Name = "lblModificar"
        Me.lblModificar.Size = New System.Drawing.Size(34, 13)
        Me.lblModificar.TabIndex = 163
        Me.lblModificar.Text = "Editar"
        '
        'lblFichaTecnica
        '
        Me.lblFichaTecnica.AutoSize = True
        Me.lblFichaTecnica.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFichaTecnica.Location = New System.Drawing.Point(194, 36)
        Me.lblFichaTecnica.Name = "lblFichaTecnica"
        Me.lblFichaTecnica.Size = New System.Drawing.Size(46, 26)
        Me.lblFichaTecnica.TabIndex = 167
        Me.lblFichaTecnica.Text = "Ficha" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tecnica"
        Me.lblFichaTecnica.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCambiosGlobales
        '
        Me.btnCambiosGlobales.Image = Global.Proveedor.Vista.My.Resources.Resources.editlittle
        Me.btnCambiosGlobales.Location = New System.Drawing.Point(261, 3)
        Me.btnCambiosGlobales.Name = "btnCambiosGlobales"
        Me.btnCambiosGlobales.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiosGlobales.TabIndex = 164
        Me.btnCambiosGlobales.UseVisualStyleBackColor = True
        '
        'lblCambiosGlobales
        '
        Me.lblCambiosGlobales.AutoSize = True
        Me.lblCambiosGlobales.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCambiosGlobales.Location = New System.Drawing.Point(256, 38)
        Me.lblCambiosGlobales.Name = "lblCambiosGlobales"
        Me.lblCambiosGlobales.Size = New System.Drawing.Size(48, 26)
        Me.lblCambiosGlobales.TabIndex = 165
        Me.lblCambiosGlobales.Text = "Cambios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Globales"
        Me.lblCambiosGlobales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(8, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 16)
        Me.Label3.TabIndex = 233
        Me.Label3.Text = "VENTANA NO FUNCIONAL"
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 555)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(1130, 56)
        Me.pnlInferior.TabIndex = 154
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1080, 41)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(27, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Salir"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1077, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grdProductosRegistrados)
        Me.Panel1.Location = New System.Drawing.Point(0, 200)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 355)
        Me.Panel1.TabIndex = 155
        '
        'grdProductosRegistrados
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosRegistrados.DisplayLayout.Appearance = Appearance1
        Me.grdProductosRegistrados.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosRegistrados.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdProductosRegistrados.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdProductosRegistrados.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProductosRegistrados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProductosRegistrados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosRegistrados.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdProductosRegistrados.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdProductosRegistrados.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdProductosRegistrados.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdProductosRegistrados.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosRegistrados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductosRegistrados.Location = New System.Drawing.Point(0, 0)
        Me.grdProductosRegistrados.Name = "grdProductosRegistrados"
        Me.grdProductosRegistrados.Size = New System.Drawing.Size(1130, 355)
        Me.grdProductosRegistrados.TabIndex = 2001
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(164, 157)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(258, 21)
        Me.cmbNave.TabIndex = 157
        '
        'cmbEstatus
        '
        Me.cmbEstatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(482, 158)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(258, 21)
        Me.cmbEstatus.TabIndex = 159
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(437, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 158
        Me.Label2.Text = "Estatus"
        '
        'lblTarjetaPrevia
        '
        Me.lblTarjetaPrevia.AutoSize = True
        Me.lblTarjetaPrevia.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTarjetaPrevia.Location = New System.Drawing.Point(268, 111)
        Me.lblTarjetaPrevia.Name = "lblTarjetaPrevia"
        Me.lblTarjetaPrevia.Size = New System.Drawing.Size(40, 26)
        Me.lblTarjetaPrevia.TabIndex = 171
        Me.lblTarjetaPrevia.Text = "Tarjeta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Previa"
        Me.lblTarjetaPrevia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTarjetaPrevia.Visible = False
        '
        'lblFichaCostos
        '
        Me.lblFichaCostos.AutoSize = True
        Me.lblFichaCostos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFichaCostos.Location = New System.Drawing.Point(208, 111)
        Me.lblFichaCostos.Name = "lblFichaCostos"
        Me.lblFichaCostos.Size = New System.Drawing.Size(39, 26)
        Me.lblFichaCostos.TabIndex = 169
        Me.lblFichaCostos.Text = "Ficha" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Costos"
        Me.lblFichaCostos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFichaCostos.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(957, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 173
        Me.Label5.Text = "Mostrar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDesautorizar
        '
        Me.lblDesautorizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDesautorizar.AutoSize = True
        Me.lblDesautorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDesautorizar.Location = New System.Drawing.Point(932, 117)
        Me.lblDesautorizar.Name = "lblDesautorizar"
        Me.lblDesautorizar.Size = New System.Drawing.Size(66, 13)
        Me.lblDesautorizar.TabIndex = 183
        Me.lblDesautorizar.Text = "Desautorizar"
        Me.lblDesautorizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDesautorizar.Visible = False
        '
        'lblActivar
        '
        Me.lblActivar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActivar.AutoSize = True
        Me.lblActivar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActivar.Location = New System.Drawing.Point(822, 117)
        Me.lblActivar.Name = "lblActivar"
        Me.lblActivar.Size = New System.Drawing.Size(40, 13)
        Me.lblActivar.TabIndex = 181
        Me.lblActivar.Text = "Activar"
        Me.lblActivar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblActivar.Visible = False
        '
        'lblDesactivar
        '
        Me.lblDesactivar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDesactivar.AutoSize = True
        Me.lblDesactivar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDesactivar.Location = New System.Drawing.Point(873, 117)
        Me.lblDesactivar.Name = "lblDesactivar"
        Me.lblDesactivar.Size = New System.Drawing.Size(58, 13)
        Me.lblDesactivar.TabIndex = 179
        Me.lblDesactivar.Text = "Desactivar"
        Me.lblDesactivar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDesactivar.Visible = False
        '
        'lblEliminar
        '
        Me.lblEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEliminar.AutoSize = True
        Me.lblEliminar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEliminar.Location = New System.Drawing.Point(1004, 117)
        Me.lblEliminar.Name = "lblEliminar"
        Me.lblEliminar.Size = New System.Drawing.Size(43, 13)
        Me.lblEliminar.TabIndex = 177
        Me.lblEliminar.Text = "Eliminar"
        Me.lblEliminar.Visible = False
        '
        'lblAutorizar
        '
        Me.lblAutorizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(757, 117)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizar.TabIndex = 175
        Me.lblAutorizar.Text = "Autorizar"
        Me.lblAutorizar.Visible = False
        '
        'btnDesautorizar
        '
        Me.btnDesautorizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesautorizar.Image = Global.Proveedor.Vista.My.Resources.Resources.cancelar32
        Me.btnDesautorizar.Location = New System.Drawing.Point(946, 75)
        Me.btnDesautorizar.Name = "btnDesautorizar"
        Me.btnDesautorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnDesautorizar.TabIndex = 182
        Me.btnDesautorizar.UseVisualStyleBackColor = True
        Me.btnDesautorizar.Visible = False
        '
        'btnActivar
        '
        Me.btnActivar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActivar.Image = Global.Proveedor.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnActivar.Location = New System.Drawing.Point(825, 76)
        Me.btnActivar.Name = "btnActivar"
        Me.btnActivar.Size = New System.Drawing.Size(32, 32)
        Me.btnActivar.TabIndex = 180
        Me.btnActivar.UseVisualStyleBackColor = True
        Me.btnActivar.Visible = False
        '
        'btnDesactivar
        '
        Me.btnDesactivar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesactivar.Image = Global.Proveedor.Vista.My.Resources.Resources.quitar_32
        Me.btnDesactivar.Location = New System.Drawing.Point(885, 76)
        Me.btnDesactivar.Name = "btnDesactivar"
        Me.btnDesactivar.Size = New System.Drawing.Size(32, 32)
        Me.btnDesactivar.TabIndex = 178
        Me.btnDesactivar.UseVisualStyleBackColor = True
        Me.btnDesactivar.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = Global.Proveedor.Vista.My.Resources.Resources.borrar_321
        Me.btnEliminar.Location = New System.Drawing.Point(1007, 76)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 176
        Me.btnEliminar.UseVisualStyleBackColor = True
        Me.btnEliminar.Visible = False
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAutorizar.Image = Global.Proveedor.Vista.My.Resources.Resources.aceptar_321
        Me.btnAutorizar.Location = New System.Drawing.Point(764, 76)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 174
        Me.btnAutorizar.UseVisualStyleBackColor = True
        Me.btnAutorizar.Visible = False
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMostrar.Image = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(961, 147)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(33, 32)
        Me.btnMostrar.TabIndex = 172
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnTarjetaPrevia
        '
        Me.btnTarjetaPrevia.Image = Global.Proveedor.Vista.My.Resources.Resources.incidencia
        Me.btnTarjetaPrevia.Location = New System.Drawing.Point(270, 76)
        Me.btnTarjetaPrevia.Name = "btnTarjetaPrevia"
        Me.btnTarjetaPrevia.Size = New System.Drawing.Size(32, 32)
        Me.btnTarjetaPrevia.TabIndex = 170
        Me.btnTarjetaPrevia.UseVisualStyleBackColor = True
        Me.btnTarjetaPrevia.Visible = False
        '
        'btnFichaCostos
        '
        Me.btnFichaCostos.Image = Global.Proveedor.Vista.My.Resources.Resources.listaPrecios
        Me.btnFichaCostos.Location = New System.Drawing.Point(209, 76)
        Me.btnFichaCostos.Name = "btnFichaCostos"
        Me.btnFichaCostos.Size = New System.Drawing.Size(32, 32)
        Me.btnFichaCostos.TabIndex = 168
        Me.btnFichaCostos.UseVisualStyleBackColor = True
        Me.btnFichaCostos.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(831, 160)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(79, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Producción"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(760, 160)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(72, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Desarrollo"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1062, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 188
        Me.PictureBox1.TabStop = False
        '
        'ProductosRegistradosDeLasNavesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1130, 611)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblDesautorizar)
        Me.Controls.Add(Me.btnDesautorizar)
        Me.Controls.Add(Me.lblActivar)
        Me.Controls.Add(Me.btnActivar)
        Me.Controls.Add(Me.lblDesactivar)
        Me.Controls.Add(Me.btnDesactivar)
        Me.Controls.Add(Me.lblEliminar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.lblAutorizar)
        Me.Controls.Add(Me.btnAutorizar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnMostrar)
        Me.Controls.Add(Me.lblTarjetaPrevia)
        Me.Controls.Add(Me.btnTarjetaPrevia)
        Me.Controls.Add(Me.lblFichaCostos)
        Me.Controls.Add(Me.btnFichaCostos)
        Me.Controls.Add(Me.cmbEstatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbNave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ProductosRegistradosDeLasNavesForm"
        Me.Text = "Productos con Consumos y Fracciones por Nave"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdProductosRegistrados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdProductosRegistrados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents lblModificar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblCambiosGlobales As System.Windows.Forms.Label
    Friend WithEvents btnCambiosGlobales As System.Windows.Forms.Button
    Friend WithEvents lblFichaTecnica As System.Windows.Forms.Label
    Friend WithEvents btnFichaTecnica As System.Windows.Forms.Button
    Friend WithEvents lblTarjetaPrevia As System.Windows.Forms.Label
    Friend WithEvents btnTarjetaPrevia As System.Windows.Forms.Button
    Friend WithEvents lblFichaCostos As System.Windows.Forms.Label
    Friend WithEvents btnFichaCostos As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblDesautorizar As System.Windows.Forms.Label
    Friend WithEvents btnDesautorizar As System.Windows.Forms.Button
    Friend WithEvents lblActivar As System.Windows.Forms.Label
    Friend WithEvents btnActivar As System.Windows.Forms.Button
    Friend WithEvents lblDesactivar As System.Windows.Forms.Label
    Friend WithEvents btnDesactivar As System.Windows.Forms.Button
    Friend WithEvents lblEliminar As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents lblCopiar As System.Windows.Forms.Label
    Friend WithEvents btnCopiar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
