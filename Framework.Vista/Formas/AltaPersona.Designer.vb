<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaPersona
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AltaPersona))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblGuardarTodo = New System.Windows.Forms.Label()
        Me.btnGuardarTodo = New System.Windows.Forms.Button()
        Me.TabProveedor = New System.Windows.Forms.TabPage()
        Me.gpbTipoFlete = New System.Windows.Forms.GroupBox()
        Me.grdTiposFleteMensajeria = New System.Windows.Forms.DataGridView()
        Me.ColNombreTipoFlete = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivoFlete = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColTipoFleteID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddTipoFlete = New System.Windows.Forms.Button()
        Me.lblTipoFlete = New System.Windows.Forms.Label()
        Me.cmbTipoFleteMensajeria = New System.Windows.Forms.ComboBox()
        Me.gbxWebProveedor = New System.Windows.Forms.GroupBox()
        Me.txtContraseñaWeb = New System.Windows.Forms.TextBox()
        Me.txtUsuarioWeb = New System.Windows.Forms.TextBox()
        Me.txtWebCliente = New System.Windows.Forms.TextBox()
        Me.lblContraseñaWebProv = New System.Windows.Forms.Label()
        Me.lblUsuarioWebProvee = New System.Windows.Forms.Label()
        Me.lblWebClienteProveedor = New System.Windows.Forms.Label()
        Me.gbxProveedor = New System.Windows.Forms.GroupBox()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.lblComentarios = New System.Windows.Forms.Label()
        Me.txtHorario = New System.Windows.Forms.TextBox()
        Me.lblHorario = New System.Windows.Forms.Label()
        Me.txtClaveYuyin = New System.Windows.Forms.TextBox()
        Me.txtRFCProveedor = New System.Windows.Forms.TextBox()
        Me.txtRazonSocialProveedor = New System.Windows.Forms.TextBox()
        Me.txtNombreProveedor = New System.Windows.Forms.TextBox()
        Me.lblClaveYuyinProveedor = New System.Windows.Forms.Label()
        Me.lblRFCProveedor = New System.Windows.Forms.Label()
        Me.lblRazonSocialProveedor = New System.Windows.Forms.Label()
        Me.lblNombreProveedor = New System.Windows.Forms.Label()
        Me.Contactos = New System.Windows.Forms.TabPage()
        Me.gridDatosContacto = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Domicilio = New System.Windows.Forms.TabPage()
        Me.grdDomicilios = New System.Windows.Forms.DataGridView()
        Me.ColCalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNoInterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNoExterior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColColonia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPoblacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIDDomicilio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaisID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CiudadID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PoblacionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDelegacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbxDomicilios = New System.Windows.Forms.GroupBox()
        Me.txtDelegacion = New System.Windows.Forms.TextBox()
        Me.lblDelegacion = New System.Windows.Forms.Label()
        Me.lblAñadirDomicilio = New System.Windows.Forms.Label()
        Me.btnAñadirDomicilio = New System.Windows.Forms.Button()
        Me.gbxActivoDomicilio = New System.Windows.Forms.GroupBox()
        Me.rdoSiActivoDomicilio = New System.Windows.Forms.RadioButton()
        Me.rdoNoActivoDomicilio = New System.Windows.Forms.RadioButton()
        Me.cmbPoblacion = New System.Windows.Forms.ComboBox()
        Me.lblPoblacion = New System.Windows.Forms.Label()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.lblActivoDomicilio = New System.Windows.Forms.Label()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.txtNoExterior = New System.Windows.Forms.TextBox()
        Me.txtNoInterior = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblNoExterior = New System.Windows.Forms.Label()
        Me.lblNoInterior = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.General = New System.Windows.Forms.TabPage()
        Me.gbxDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.dtpFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaNacimiento = New System.Windows.Forms.Label()
        Me.txtsicyID = New System.Windows.Forms.TextBox()
        Me.lblSicyID = New System.Windows.Forms.Label()
        Me.txtPaginaWeb = New System.Windows.Forms.TextBox()
        Me.txtRazonSocialPersona = New System.Windows.Forms.TextBox()
        Me.txtCurpPersona = New System.Windows.Forms.TextBox()
        Me.txtAMaterno = New System.Windows.Forms.TextBox()
        Me.gbxActivo = New System.Windows.Forms.GroupBox()
        Me.rdoSiActivo = New System.Windows.Forms.RadioButton()
        Me.rdoNoActivo = New System.Windows.Forms.RadioButton()
        Me.gbxPersonaFisica = New System.Windows.Forms.GroupBox()
        Me.rdoSiPersonaFisica = New System.Windows.Forms.RadioButton()
        Me.rdoNoPersonaFisica = New System.Windows.Forms.RadioButton()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cmbClasificacion = New System.Windows.Forms.ComboBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.lblPersonaFisica = New System.Windows.Forms.Label()
        Me.lblClasificacion = New System.Windows.Forms.Label()
        Me.lblNombrePersona = New System.Windows.Forms.Label()
        Me.txtNombrePersona = New System.Windows.Forms.TextBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblAPaterno = New System.Windows.Forms.Label()
        Me.lblAMaterno = New System.Windows.Forms.Label()
        Me.txtAPaterno = New System.Windows.Forms.TextBox()
        Me.lblPaginaWeb = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.lblCurpPersona = New System.Windows.Forms.Label()
        Me.TabDatos = New System.Windows.Forms.TabControl()
        Me.tapTelefonos = New System.Windows.Forms.TabPage()
        Me.gbxTelefonos = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTipoTelefono = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lblAñadirTelefono = New System.Windows.Forms.Label()
        Me.txtExtTelefono = New System.Windows.Forms.TextBox()
        Me.btnAgregarTelefono = New System.Windows.Forms.Button()
        Me.cmbTipoTelefono = New System.Windows.Forms.ComboBox()
        Me.grdTelefonos = New System.Windows.Forms.DataGridView()
        Me.ColTelefonoPersona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTipoTelefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIdTipoTelefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTelID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblExtencion = New System.Windows.Forms.Label()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.tabEmails = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnQuitarEmail = New System.Windows.Forms.Button()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.grdEmails = New System.Windows.Forms.DataGridView()
        Me.colidEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabConvenios = New System.Windows.Forms.TabPage()
        Me.grdListaConvenios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlAltas = New System.Windows.Forms.Panel()
        Me.grbConvenios = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlActivo = New System.Windows.Forms.Panel()
        Me.rdoNoConvenio = New System.Windows.Forms.RadioButton()
        Me.rdoSiConvenio = New System.Windows.Forms.RadioButton()
        Me.txtComentarioConvenios = New System.Windows.Forms.TextBox()
        Me.txtDescripcionConvenios = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAgregarConvenio = New System.Windows.Forms.Button()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.lblActivoConvenio = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblComentario = New System.Windows.Forms.Label()
        Me.dtpFechaTerminoVigencia = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicioVigencia = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDeSubscripcion = New System.Windows.Forms.DateTimePicker()
        Me.txtNegociador = New System.Windows.Forms.TextBox()
        Me.lblNumConvenio = New System.Windows.Forms.Label()
        Me.lblFechaSubscripcion = New System.Windows.Forms.Label()
        Me.lblVigenciaInicio = New System.Windows.Forms.Label()
        Me.lblNegocia = New System.Windows.Forms.Label()
        Me.lblVigenciaFin = New System.Windows.Forms.Label()
        Me.txtNumConvenio = New System.Windows.Forms.TextBox()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.lblEmpresa = New System.Windows.Forms.Label()
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
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExtencion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTelefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlInferior.SuspendLayout()
        Me.TabProveedor.SuspendLayout()
        Me.gpbTipoFlete.SuspendLayout()
        CType(Me.grdTiposFleteMensajeria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxWebProveedor.SuspendLayout()
        Me.gbxProveedor.SuspendLayout()
        Me.Contactos.SuspendLayout()
        CType(Me.gridDatosContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Domicilio.SuspendLayout()
        CType(Me.grdDomicilios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDomicilios.SuspendLayout()
        Me.gbxActivoDomicilio.SuspendLayout()
        Me.General.SuspendLayout()
        Me.gbxDatosGenerales.SuspendLayout()
        Me.gbxActivo.SuspendLayout()
        Me.gbxPersonaFisica.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.tapTelefonos.SuspendLayout()
        Me.gbxTelefonos.SuspendLayout()
        CType(Me.grdTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEmails.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdEmails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabConvenios.SuspendLayout()
        CType(Me.grdListaConvenios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAltas.SuspendLayout()
        Me.grbConvenios.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlActivo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblTitle)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(814, 60)
        Me.pnlEncabezado.TabIndex = 13
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(559, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(171, 20)
        Me.lblTitle.TabIndex = 21
        Me.lblTitle.Text = "Alta de Proveedores"
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblGuardarTodo)
        Me.pnlInferior.Controls.Add(Me.btnGuardarTodo)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 548)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(814, 53)
        Me.pnlInferior.TabIndex = 15
        '
        'lblGuardarTodo
        '
        Me.lblGuardarTodo.AutoSize = True
        Me.lblGuardarTodo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarTodo.Location = New System.Drawing.Point(733, 37)
        Me.lblGuardarTodo.Name = "lblGuardarTodo"
        Me.lblGuardarTodo.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarTodo.TabIndex = 98
        Me.lblGuardarTodo.Text = "Guardar"
        '
        'btnGuardarTodo
        '
        Me.btnGuardarTodo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarTodo.Location = New System.Drawing.Point(736, 3)
        Me.btnGuardarTodo.Name = "btnGuardarTodo"
        Me.btnGuardarTodo.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarTodo.TabIndex = 15
        Me.btnGuardarTodo.UseVisualStyleBackColor = True
        '
        'TabProveedor
        '
        Me.TabProveedor.BackColor = System.Drawing.Color.AliceBlue
        Me.TabProveedor.Controls.Add(Me.gpbTipoFlete)
        Me.TabProveedor.Controls.Add(Me.gbxWebProveedor)
        Me.TabProveedor.Controls.Add(Me.gbxProveedor)
        Me.TabProveedor.Location = New System.Drawing.Point(4, 22)
        Me.TabProveedor.Name = "TabProveedor"
        Me.TabProveedor.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProveedor.Size = New System.Drawing.Size(796, 445)
        Me.TabProveedor.TabIndex = 3
        Me.TabProveedor.Text = "Proveedor"
        '
        'gpbTipoFlete
        '
        Me.gpbTipoFlete.Controls.Add(Me.grdTiposFleteMensajeria)
        Me.gpbTipoFlete.Controls.Add(Me.Label2)
        Me.gpbTipoFlete.Controls.Add(Me.btnAddTipoFlete)
        Me.gpbTipoFlete.Controls.Add(Me.lblTipoFlete)
        Me.gpbTipoFlete.Controls.Add(Me.cmbTipoFleteMensajeria)
        Me.gpbTipoFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbTipoFlete.Location = New System.Drawing.Point(9, 326)
        Me.gpbTipoFlete.Name = "gpbTipoFlete"
        Me.gpbTipoFlete.Size = New System.Drawing.Size(780, 111)
        Me.gpbTipoFlete.TabIndex = 98
        Me.gpbTipoFlete.TabStop = False
        Me.gpbTipoFlete.Text = "Tipos de Flete"
        '
        'grdTiposFleteMensajeria
        '
        Me.grdTiposFleteMensajeria.AllowUserToAddRows = False
        Me.grdTiposFleteMensajeria.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTiposFleteMensajeria.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdTiposFleteMensajeria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTiposFleteMensajeria.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNombreTipoFlete, Me.ColActivoFlete, Me.ColTipoFleteID, Me.ID})
        Me.grdTiposFleteMensajeria.Location = New System.Drawing.Point(379, 16)
        Me.grdTiposFleteMensajeria.Name = "grdTiposFleteMensajeria"
        Me.grdTiposFleteMensajeria.Size = New System.Drawing.Size(386, 86)
        Me.grdTiposFleteMensajeria.TabIndex = 12
        '
        'ColNombreTipoFlete
        '
        Me.ColNombreTipoFlete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNombreTipoFlete.HeaderText = "Tipo Flete"
        Me.ColNombreTipoFlete.Name = "ColNombreTipoFlete"
        '
        'ColActivoFlete
        '
        Me.ColActivoFlete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColActivoFlete.HeaderText = ""
        Me.ColActivoFlete.Name = "ColActivoFlete"
        Me.ColActivoFlete.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColActivoFlete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColTipoFleteID
        '
        Me.ColTipoFleteID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColTipoFleteID.HeaderText = "Tipo Flete ID"
        Me.ColTipoFleteID.Name = "ColTipoFleteID"
        Me.ColTipoFleteID.Visible = False
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(318, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Añadir"
        '
        'btnAddTipoFlete
        '
        Me.btnAddTipoFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddTipoFlete.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAddTipoFlete.Location = New System.Drawing.Point(321, 55)
        Me.btnAddTipoFlete.Name = "btnAddTipoFlete"
        Me.btnAddTipoFlete.Size = New System.Drawing.Size(32, 32)
        Me.btnAddTipoFlete.TabIndex = 11
        Me.btnAddTipoFlete.UseVisualStyleBackColor = True
        '
        'lblTipoFlete
        '
        Me.lblTipoFlete.AutoSize = True
        Me.lblTipoFlete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoFlete.Location = New System.Drawing.Point(50, 22)
        Me.lblTipoFlete.Name = "lblTipoFlete"
        Me.lblTipoFlete.Size = New System.Drawing.Size(54, 13)
        Me.lblTipoFlete.TabIndex = 130
        Me.lblTipoFlete.Text = "Tipo Flete"
        '
        'cmbTipoFleteMensajeria
        '
        Me.cmbTipoFleteMensajeria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFleteMensajeria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoFleteMensajeria.FormattingEnabled = True
        Me.cmbTipoFleteMensajeria.Location = New System.Drawing.Point(109, 22)
        Me.cmbTipoFleteMensajeria.Name = "cmbTipoFleteMensajeria"
        Me.cmbTipoFleteMensajeria.Size = New System.Drawing.Size(245, 21)
        Me.cmbTipoFleteMensajeria.TabIndex = 10
        '
        'gbxWebProveedor
        '
        Me.gbxWebProveedor.Controls.Add(Me.txtContraseñaWeb)
        Me.gbxWebProveedor.Controls.Add(Me.txtUsuarioWeb)
        Me.gbxWebProveedor.Controls.Add(Me.txtWebCliente)
        Me.gbxWebProveedor.Controls.Add(Me.lblContraseñaWebProv)
        Me.gbxWebProveedor.Controls.Add(Me.lblUsuarioWebProvee)
        Me.gbxWebProveedor.Controls.Add(Me.lblWebClienteProveedor)
        Me.gbxWebProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxWebProveedor.Location = New System.Drawing.Point(9, 243)
        Me.gbxWebProveedor.Name = "gbxWebProveedor"
        Me.gbxWebProveedor.Size = New System.Drawing.Size(780, 77)
        Me.gbxWebProveedor.TabIndex = 97
        Me.gbxWebProveedor.TabStop = False
        Me.gbxWebProveedor.Text = "Sitio Web para Clientes"
        '
        'txtContraseñaWeb
        '
        Me.txtContraseñaWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContraseñaWeb.Location = New System.Drawing.Point(497, 48)
        Me.txtContraseñaWeb.Multiline = True
        Me.txtContraseñaWeb.Name = "txtContraseñaWeb"
        Me.txtContraseñaWeb.Size = New System.Drawing.Size(206, 20)
        Me.txtContraseñaWeb.TabIndex = 9
        '
        'txtUsuarioWeb
        '
        Me.txtUsuarioWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioWeb.Location = New System.Drawing.Point(158, 48)
        Me.txtUsuarioWeb.Name = "txtUsuarioWeb"
        Me.txtUsuarioWeb.Size = New System.Drawing.Size(206, 20)
        Me.txtUsuarioWeb.TabIndex = 8
        '
        'txtWebCliente
        '
        Me.txtWebCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebCliente.ForeColor = System.Drawing.Color.Blue
        Me.txtWebCliente.Location = New System.Drawing.Point(158, 18)
        Me.txtWebCliente.Name = "txtWebCliente"
        Me.txtWebCliente.Size = New System.Drawing.Size(545, 20)
        Me.txtWebCliente.TabIndex = 7
        '
        'lblContraseñaWebProv
        '
        Me.lblContraseñaWebProv.AutoSize = True
        Me.lblContraseñaWebProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContraseñaWebProv.Location = New System.Drawing.Point(430, 49)
        Me.lblContraseñaWebProv.Name = "lblContraseñaWebProv"
        Me.lblContraseñaWebProv.Size = New System.Drawing.Size(61, 13)
        Me.lblContraseñaWebProv.TabIndex = 112
        Me.lblContraseñaWebProv.Text = "Contraseña"
        '
        'lblUsuarioWebProvee
        '
        Me.lblUsuarioWebProvee.AutoSize = True
        Me.lblUsuarioWebProvee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioWebProvee.Location = New System.Drawing.Point(63, 49)
        Me.lblUsuarioWebProvee.Name = "lblUsuarioWebProvee"
        Me.lblUsuarioWebProvee.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuarioWebProvee.TabIndex = 111
        Me.lblUsuarioWebProvee.Text = "Usuario"
        '
        'lblWebClienteProveedor
        '
        Me.lblWebClienteProveedor.AutoSize = True
        Me.lblWebClienteProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebClienteProveedor.Location = New System.Drawing.Point(63, 21)
        Me.lblWebClienteProveedor.Name = "lblWebClienteProveedor"
        Me.lblWebClienteProveedor.Size = New System.Drawing.Size(66, 13)
        Me.lblWebClienteProveedor.TabIndex = 110
        Me.lblWebClienteProveedor.Text = "Página Web"
        '
        'gbxProveedor
        '
        Me.gbxProveedor.Controls.Add(Me.txtComentarios)
        Me.gbxProveedor.Controls.Add(Me.lblComentarios)
        Me.gbxProveedor.Controls.Add(Me.txtHorario)
        Me.gbxProveedor.Controls.Add(Me.lblHorario)
        Me.gbxProveedor.Controls.Add(Me.txtClaveYuyin)
        Me.gbxProveedor.Controls.Add(Me.txtRFCProveedor)
        Me.gbxProveedor.Controls.Add(Me.txtRazonSocialProveedor)
        Me.gbxProveedor.Controls.Add(Me.txtNombreProveedor)
        Me.gbxProveedor.Controls.Add(Me.lblClaveYuyinProveedor)
        Me.gbxProveedor.Controls.Add(Me.lblRFCProveedor)
        Me.gbxProveedor.Controls.Add(Me.lblRazonSocialProveedor)
        Me.gbxProveedor.Controls.Add(Me.lblNombreProveedor)
        Me.gbxProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxProveedor.Location = New System.Drawing.Point(9, 8)
        Me.gbxProveedor.Name = "gbxProveedor"
        Me.gbxProveedor.Size = New System.Drawing.Size(780, 229)
        Me.gbxProveedor.TabIndex = 96
        Me.gbxProveedor.TabStop = False
        Me.gbxProveedor.Text = "Datos Proveedor"
        '
        'txtComentarios
        '
        Me.txtComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarios.Location = New System.Drawing.Point(184, 176)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(524, 44)
        Me.txtComentarios.TabIndex = 6
        '
        'lblComentarios
        '
        Me.lblComentarios.AutoSize = True
        Me.lblComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComentarios.Location = New System.Drawing.Point(66, 176)
        Me.lblComentarios.Name = "lblComentarios"
        Me.lblComentarios.Size = New System.Drawing.Size(65, 13)
        Me.lblComentarios.TabIndex = 116
        Me.lblComentarios.Text = "Comentarios"
        '
        'txtHorario
        '
        Me.txtHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorario.Location = New System.Drawing.Point(185, 144)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.Size = New System.Drawing.Size(523, 20)
        Me.txtHorario.TabIndex = 5
        '
        'lblHorario
        '
        Me.lblHorario.AutoSize = True
        Me.lblHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorario.Location = New System.Drawing.Point(66, 147)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Size = New System.Drawing.Size(41, 13)
        Me.lblHorario.TabIndex = 114
        Me.lblHorario.Text = "Horario"
        '
        'txtClaveYuyin
        '
        Me.txtClaveYuyin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveYuyin.Location = New System.Drawing.Point(185, 112)
        Me.txtClaveYuyin.Name = "txtClaveYuyin"
        Me.txtClaveYuyin.Size = New System.Drawing.Size(116, 20)
        Me.txtClaveYuyin.TabIndex = 4
        '
        'txtRFCProveedor
        '
        Me.txtRFCProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRFCProveedor.Location = New System.Drawing.Point(185, 80)
        Me.txtRFCProveedor.Name = "txtRFCProveedor"
        Me.txtRFCProveedor.Size = New System.Drawing.Size(186, 20)
        Me.txtRFCProveedor.TabIndex = 3
        '
        'txtRazonSocialProveedor
        '
        Me.txtRazonSocialProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocialProveedor.Location = New System.Drawing.Point(185, 48)
        Me.txtRazonSocialProveedor.Name = "txtRazonSocialProveedor"
        Me.txtRazonSocialProveedor.Size = New System.Drawing.Size(523, 20)
        Me.txtRazonSocialProveedor.TabIndex = 2
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreProveedor.Location = New System.Drawing.Point(185, 16)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.Size = New System.Drawing.Size(524, 20)
        Me.txtNombreProveedor.TabIndex = 1
        '
        'lblClaveYuyinProveedor
        '
        Me.lblClaveYuyinProveedor.AutoSize = True
        Me.lblClaveYuyinProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaveYuyinProveedor.Location = New System.Drawing.Point(66, 115)
        Me.lblClaveYuyinProveedor.Name = "lblClaveYuyinProveedor"
        Me.lblClaveYuyinProveedor.Size = New System.Drawing.Size(115, 13)
        Me.lblClaveYuyinProveedor.TabIndex = 99
        Me.lblClaveYuyinProveedor.Text = "Clave de Cliente Yuyín"
        '
        'lblRFCProveedor
        '
        Me.lblRFCProveedor.AutoSize = True
        Me.lblRFCProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFCProveedor.Location = New System.Drawing.Point(66, 83)
        Me.lblRFCProveedor.Name = "lblRFCProveedor"
        Me.lblRFCProveedor.Size = New System.Drawing.Size(28, 13)
        Me.lblRFCProveedor.TabIndex = 98
        Me.lblRFCProveedor.Text = "RFC"
        '
        'lblRazonSocialProveedor
        '
        Me.lblRazonSocialProveedor.AutoSize = True
        Me.lblRazonSocialProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocialProveedor.Location = New System.Drawing.Point(66, 51)
        Me.lblRazonSocialProveedor.Name = "lblRazonSocialProveedor"
        Me.lblRazonSocialProveedor.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocialProveedor.TabIndex = 97
        Me.lblRazonSocialProveedor.Text = "* Razón Social"
        '
        'lblNombreProveedor
        '
        Me.lblNombreProveedor.AutoSize = True
        Me.lblNombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreProveedor.Location = New System.Drawing.Point(66, 19)
        Me.lblNombreProveedor.Name = "lblNombreProveedor"
        Me.lblNombreProveedor.Size = New System.Drawing.Size(51, 13)
        Me.lblNombreProveedor.TabIndex = 96
        Me.lblNombreProveedor.Text = "* Nombre"
        '
        'Contactos
        '
        Me.Contactos.BackColor = System.Drawing.Color.AliceBlue
        Me.Contactos.Controls.Add(Me.gridDatosContacto)
        Me.Contactos.Location = New System.Drawing.Point(4, 22)
        Me.Contactos.Name = "Contactos"
        Me.Contactos.Padding = New System.Windows.Forms.Padding(3)
        Me.Contactos.Size = New System.Drawing.Size(796, 445)
        Me.Contactos.TabIndex = 2
        Me.Contactos.Text = "Contactos"
        '
        'gridDatosContacto
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridDatosContacto.DisplayLayout.Appearance = Appearance1
        Me.gridDatosContacto.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridDatosContacto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDatosContacto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridDatosContacto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridDatosContacto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridDatosContacto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridDatosContacto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridDatosContacto.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridDatosContacto.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDatosContacto.Location = New System.Drawing.Point(30, 32)
        Me.gridDatosContacto.Name = "gridDatosContacto"
        Me.gridDatosContacto.Size = New System.Drawing.Size(734, 402)
        Me.gridDatosContacto.TabIndex = 101
        '
        'Domicilio
        '
        Me.Domicilio.BackColor = System.Drawing.Color.AliceBlue
        Me.Domicilio.Controls.Add(Me.grdDomicilios)
        Me.Domicilio.Controls.Add(Me.gbxDomicilios)
        Me.Domicilio.Location = New System.Drawing.Point(4, 22)
        Me.Domicilio.Name = "Domicilio"
        Me.Domicilio.Padding = New System.Windows.Forms.Padding(3)
        Me.Domicilio.Size = New System.Drawing.Size(796, 445)
        Me.Domicilio.TabIndex = 1
        Me.Domicilio.Text = "Domicilio"
        '
        'grdDomicilios
        '
        Me.grdDomicilios.AllowUserToAddRows = False
        Me.grdDomicilios.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDomicilios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdDomicilios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDomicilios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCalle, Me.ColNoInterior, Me.ColNoExterior, Me.ColColonia, Me.ColCP, Me.ColPais, Me.ColEstado, Me.ColCiudad, Me.ColPoblacion, Me.ColActivo, Me.ColIDDomicilio, Me.PaisID, Me.EstadoID, Me.CiudadID, Me.PoblacionID, Me.ColDelegacion})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDomicilios.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdDomicilios.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdDomicilios.Location = New System.Drawing.Point(3, 253)
        Me.grdDomicilios.Name = "grdDomicilios"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDomicilios.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdDomicilios.Size = New System.Drawing.Size(790, 189)
        Me.grdDomicilios.TabIndex = 82
        '
        'ColCalle
        '
        Me.ColCalle.HeaderText = "Calle"
        Me.ColCalle.Name = "ColCalle"
        '
        'ColNoInterior
        '
        Me.ColNoInterior.HeaderText = "# Interior"
        Me.ColNoInterior.Name = "ColNoInterior"
        '
        'ColNoExterior
        '
        Me.ColNoExterior.HeaderText = "# Exterior"
        Me.ColNoExterior.Name = "ColNoExterior"
        '
        'ColColonia
        '
        Me.ColColonia.HeaderText = "Colonia"
        Me.ColColonia.Name = "ColColonia"
        '
        'ColCP
        '
        Me.ColCP.HeaderText = "C.P."
        Me.ColCP.Name = "ColCP"
        '
        'ColPais
        '
        Me.ColPais.HeaderText = "Pais"
        Me.ColPais.Name = "ColPais"
        '
        'ColEstado
        '
        Me.ColEstado.HeaderText = "Estado"
        Me.ColEstado.Name = "ColEstado"
        '
        'ColCiudad
        '
        Me.ColCiudad.HeaderText = "Ciudad"
        Me.ColCiudad.Name = "ColCiudad"
        '
        'ColPoblacion
        '
        Me.ColPoblacion.HeaderText = "Población"
        Me.ColPoblacion.Name = "ColPoblacion"
        '
        'ColActivo
        '
        Me.ColActivo.HeaderText = "Activo"
        Me.ColActivo.Name = "ColActivo"
        Me.ColActivo.Visible = False
        '
        'ColIDDomicilio
        '
        Me.ColIDDomicilio.HeaderText = "IDDom"
        Me.ColIDDomicilio.Name = "ColIDDomicilio"
        Me.ColIDDomicilio.Visible = False
        '
        'PaisID
        '
        Me.PaisID.HeaderText = "ColPaisID"
        Me.PaisID.Name = "PaisID"
        Me.PaisID.Visible = False
        '
        'EstadoID
        '
        Me.EstadoID.HeaderText = "ColEstadoID"
        Me.EstadoID.Name = "EstadoID"
        Me.EstadoID.Visible = False
        '
        'CiudadID
        '
        Me.CiudadID.HeaderText = "ColCiudadID"
        Me.CiudadID.Name = "CiudadID"
        Me.CiudadID.Visible = False
        '
        'PoblacionID
        '
        Me.PoblacionID.HeaderText = "ColPoblacionID"
        Me.PoblacionID.Name = "PoblacionID"
        Me.PoblacionID.Visible = False
        '
        'ColDelegacion
        '
        Me.ColDelegacion.HeaderText = "Delegación"
        Me.ColDelegacion.Name = "ColDelegacion"
        '
        'gbxDomicilios
        '
        Me.gbxDomicilios.Controls.Add(Me.txtDelegacion)
        Me.gbxDomicilios.Controls.Add(Me.lblDelegacion)
        Me.gbxDomicilios.Controls.Add(Me.lblAñadirDomicilio)
        Me.gbxDomicilios.Controls.Add(Me.btnAñadirDomicilio)
        Me.gbxDomicilios.Controls.Add(Me.gbxActivoDomicilio)
        Me.gbxDomicilios.Controls.Add(Me.cmbPoblacion)
        Me.gbxDomicilios.Controls.Add(Me.lblPoblacion)
        Me.gbxDomicilios.Controls.Add(Me.cmbCiudad)
        Me.gbxDomicilios.Controls.Add(Me.lblCiudad)
        Me.gbxDomicilios.Controls.Add(Me.cmbEstado)
        Me.gbxDomicilios.Controls.Add(Me.lblEstado)
        Me.gbxDomicilios.Controls.Add(Me.cmbPais)
        Me.gbxDomicilios.Controls.Add(Me.lblPais)
        Me.gbxDomicilios.Controls.Add(Me.lblActivoDomicilio)
        Me.gbxDomicilios.Controls.Add(Me.txtCP)
        Me.gbxDomicilios.Controls.Add(Me.lblCP)
        Me.gbxDomicilios.Controls.Add(Me.txtColonia)
        Me.gbxDomicilios.Controls.Add(Me.txtNoExterior)
        Me.gbxDomicilios.Controls.Add(Me.txtNoInterior)
        Me.gbxDomicilios.Controls.Add(Me.txtCalle)
        Me.gbxDomicilios.Controls.Add(Me.lblColonia)
        Me.gbxDomicilios.Controls.Add(Me.lblNoExterior)
        Me.gbxDomicilios.Controls.Add(Me.lblNoInterior)
        Me.gbxDomicilios.Controls.Add(Me.lblCalle)
        Me.gbxDomicilios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDomicilios.Location = New System.Drawing.Point(9, 6)
        Me.gbxDomicilios.Name = "gbxDomicilios"
        Me.gbxDomicilios.Size = New System.Drawing.Size(779, 241)
        Me.gbxDomicilios.TabIndex = 83
        Me.gbxDomicilios.TabStop = False
        Me.gbxDomicilios.Text = "Domicilio"
        '
        'txtDelegacion
        '
        Me.txtDelegacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelegacion.Location = New System.Drawing.Point(760, 64)
        Me.txtDelegacion.Name = "txtDelegacion"
        Me.txtDelegacion.Size = New System.Drawing.Size(13, 20)
        Me.txtDelegacion.TabIndex = 6
        Me.txtDelegacion.Visible = False
        '
        'lblDelegacion
        '
        Me.lblDelegacion.AutoSize = True
        Me.lblDelegacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelegacion.Location = New System.Drawing.Point(698, 67)
        Me.lblDelegacion.Name = "lblDelegacion"
        Me.lblDelegacion.Size = New System.Drawing.Size(61, 13)
        Me.lblDelegacion.TabIndex = 124
        Me.lblDelegacion.Text = "Delegación"
        Me.lblDelegacion.Visible = False
        '
        'lblAñadirDomicilio
        '
        Me.lblAñadirDomicilio.AutoSize = True
        Me.lblAñadirDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAñadirDomicilio.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAñadirDomicilio.Location = New System.Drawing.Point(721, 222)
        Me.lblAñadirDomicilio.Name = "lblAñadirDomicilio"
        Me.lblAñadirDomicilio.Size = New System.Drawing.Size(37, 13)
        Me.lblAñadirDomicilio.TabIndex = 123
        Me.lblAñadirDomicilio.Text = "Añadir"
        '
        'btnAñadirDomicilio
        '
        Me.btnAñadirDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAñadirDomicilio.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAñadirDomicilio.Location = New System.Drawing.Point(723, 188)
        Me.btnAñadirDomicilio.Name = "btnAñadirDomicilio"
        Me.btnAñadirDomicilio.Size = New System.Drawing.Size(32, 32)
        Me.btnAñadirDomicilio.TabIndex = 125
        Me.btnAñadirDomicilio.UseVisualStyleBackColor = True
        '
        'gbxActivoDomicilio
        '
        Me.gbxActivoDomicilio.Controls.Add(Me.rdoSiActivoDomicilio)
        Me.gbxActivoDomicilio.Controls.Add(Me.rdoNoActivoDomicilio)
        Me.gbxActivoDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxActivoDomicilio.Location = New System.Drawing.Point(142, 190)
        Me.gbxActivoDomicilio.Name = "gbxActivoDomicilio"
        Me.gbxActivoDomicilio.Size = New System.Drawing.Size(224, 36)
        Me.gbxActivoDomicilio.TabIndex = 121
        Me.gbxActivoDomicilio.TabStop = False
        '
        'rdoSiActivoDomicilio
        '
        Me.rdoSiActivoDomicilio.AutoSize = True
        Me.rdoSiActivoDomicilio.Checked = True
        Me.rdoSiActivoDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoSiActivoDomicilio.Location = New System.Drawing.Point(31, 13)
        Me.rdoSiActivoDomicilio.Name = "rdoSiActivoDomicilio"
        Me.rdoSiActivoDomicilio.Size = New System.Drawing.Size(34, 17)
        Me.rdoSiActivoDomicilio.TabIndex = 10
        Me.rdoSiActivoDomicilio.TabStop = True
        Me.rdoSiActivoDomicilio.Text = "Si"
        Me.rdoSiActivoDomicilio.UseVisualStyleBackColor = True
        '
        'rdoNoActivoDomicilio
        '
        Me.rdoNoActivoDomicilio.AutoSize = True
        Me.rdoNoActivoDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoNoActivoDomicilio.Location = New System.Drawing.Point(156, 13)
        Me.rdoNoActivoDomicilio.Name = "rdoNoActivoDomicilio"
        Me.rdoNoActivoDomicilio.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoActivoDomicilio.TabIndex = 11
        Me.rdoNoActivoDomicilio.Text = "No"
        Me.rdoNoActivoDomicilio.UseVisualStyleBackColor = True
        '
        'cmbPoblacion
        '
        Me.cmbPoblacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPoblacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPoblacion.FormattingEnabled = True
        Me.cmbPoblacion.Location = New System.Drawing.Point(451, 156)
        Me.cmbPoblacion.Name = "cmbPoblacion"
        Me.cmbPoblacion.Size = New System.Drawing.Size(238, 21)
        Me.cmbPoblacion.TabIndex = 9
        '
        'lblPoblacion
        '
        Me.lblPoblacion.AutoSize = True
        Me.lblPoblacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoblacion.Location = New System.Drawing.Point(388, 159)
        Me.lblPoblacion.Name = "lblPoblacion"
        Me.lblPoblacion.Size = New System.Drawing.Size(54, 13)
        Me.lblPoblacion.TabIndex = 119
        Me.lblPoblacion.Text = "Población"
        '
        'cmbCiudad
        '
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(142, 156)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(224, 21)
        Me.cmbCiudad.TabIndex = 8
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCiudad.Location = New System.Drawing.Point(77, 159)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(40, 13)
        Me.lblCiudad.TabIndex = 117
        Me.lblCiudad.Text = "Ciudad"
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(451, 122)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(238, 21)
        Me.cmbEstado.TabIndex = 7
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(388, 126)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 115
        Me.lblEstado.Text = "Estado"
        '
        'cmbPais
        '
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(142, 122)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(224, 21)
        Me.cmbPais.TabIndex = 6
        '
        'lblPais
        '
        Me.lblPais.AutoSize = True
        Me.lblPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPais.Location = New System.Drawing.Point(77, 126)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(29, 13)
        Me.lblPais.TabIndex = 113
        Me.lblPais.Text = "País"
        '
        'lblActivoDomicilio
        '
        Me.lblActivoDomicilio.AutoSize = True
        Me.lblActivoDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivoDomicilio.Location = New System.Drawing.Point(77, 204)
        Me.lblActivoDomicilio.Name = "lblActivoDomicilio"
        Me.lblActivoDomicilio.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoDomicilio.TabIndex = 110
        Me.lblActivoDomicilio.Text = "Activo"
        '
        'txtCP
        '
        Me.txtCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCP.Location = New System.Drawing.Point(607, 55)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(82, 20)
        Me.txtCP.TabIndex = 4
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.Location = New System.Drawing.Point(564, 58)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(27, 13)
        Me.lblCP.TabIndex = 108
        Me.lblCP.Text = "C.P."
        '
        'txtColonia
        '
        Me.txtColonia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColonia.Location = New System.Drawing.Point(142, 89)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(547, 20)
        Me.txtColonia.TabIndex = 5
        '
        'txtNoExterior
        '
        Me.txtNoExterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoExterior.Location = New System.Drawing.Point(398, 55)
        Me.txtNoExterior.Name = "txtNoExterior"
        Me.txtNoExterior.Size = New System.Drawing.Size(82, 20)
        Me.txtNoExterior.TabIndex = 3
        '
        'txtNoInterior
        '
        Me.txtNoInterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoInterior.Location = New System.Drawing.Point(142, 56)
        Me.txtNoInterior.Name = "txtNoInterior"
        Me.txtNoInterior.Size = New System.Drawing.Size(82, 20)
        Me.txtNoInterior.TabIndex = 2
        '
        'txtCalle
        '
        Me.txtCalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalle.Location = New System.Drawing.Point(142, 23)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(547, 20)
        Me.txtCalle.TabIndex = 1
        '
        'lblColonia
        '
        Me.lblColonia.AutoSize = True
        Me.lblColonia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColonia.Location = New System.Drawing.Point(77, 91)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(42, 13)
        Me.lblColonia.TabIndex = 99
        Me.lblColonia.Text = "Colonia"
        '
        'lblNoExterior
        '
        Me.lblNoExterior.AutoSize = True
        Me.lblNoExterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoExterior.Location = New System.Drawing.Point(318, 57)
        Me.lblNoExterior.Name = "lblNoExterior"
        Me.lblNoExterior.Size = New System.Drawing.Size(62, 13)
        Me.lblNoExterior.TabIndex = 98
        Me.lblNoExterior.Text = "No. Exterior"
        '
        'lblNoInterior
        '
        Me.lblNoInterior.AutoSize = True
        Me.lblNoInterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoInterior.Location = New System.Drawing.Point(77, 58)
        Me.lblNoInterior.Name = "lblNoInterior"
        Me.lblNoInterior.Size = New System.Drawing.Size(59, 13)
        Me.lblNoInterior.TabIndex = 97
        Me.lblNoInterior.Text = "No. Interior"
        '
        'lblCalle
        '
        Me.lblCalle.AutoSize = True
        Me.lblCalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalle.Location = New System.Drawing.Point(77, 26)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(30, 13)
        Me.lblCalle.TabIndex = 96
        Me.lblCalle.Text = "Calle"
        '
        'General
        '
        Me.General.BackColor = System.Drawing.Color.AliceBlue
        Me.General.Controls.Add(Me.gbxDatosGenerales)
        Me.General.Location = New System.Drawing.Point(4, 22)
        Me.General.Name = "General"
        Me.General.Padding = New System.Windows.Forms.Padding(3)
        Me.General.Size = New System.Drawing.Size(806, 462)
        Me.General.TabIndex = 0
        Me.General.Text = "Persona"
        '
        'gbxDatosGenerales
        '
        Me.gbxDatosGenerales.Controls.Add(Me.dtpFechaNacimiento)
        Me.gbxDatosGenerales.Controls.Add(Me.lblFechaNacimiento)
        Me.gbxDatosGenerales.Controls.Add(Me.txtsicyID)
        Me.gbxDatosGenerales.Controls.Add(Me.lblSicyID)
        Me.gbxDatosGenerales.Controls.Add(Me.txtPaginaWeb)
        Me.gbxDatosGenerales.Controls.Add(Me.txtRazonSocialPersona)
        Me.gbxDatosGenerales.Controls.Add(Me.txtCurpPersona)
        Me.gbxDatosGenerales.Controls.Add(Me.txtAMaterno)
        Me.gbxDatosGenerales.Controls.Add(Me.gbxActivo)
        Me.gbxDatosGenerales.Controls.Add(Me.gbxPersonaFisica)
        Me.gbxDatosGenerales.Controls.Add(Me.lblTipo)
        Me.gbxDatosGenerales.Controls.Add(Me.cmbClasificacion)
        Me.gbxDatosGenerales.Controls.Add(Me.cmbTipo)
        Me.gbxDatosGenerales.Controls.Add(Me.lblPersonaFisica)
        Me.gbxDatosGenerales.Controls.Add(Me.lblClasificacion)
        Me.gbxDatosGenerales.Controls.Add(Me.lblNombrePersona)
        Me.gbxDatosGenerales.Controls.Add(Me.txtNombrePersona)
        Me.gbxDatosGenerales.Controls.Add(Me.lblActivo)
        Me.gbxDatosGenerales.Controls.Add(Me.lblAPaterno)
        Me.gbxDatosGenerales.Controls.Add(Me.lblAMaterno)
        Me.gbxDatosGenerales.Controls.Add(Me.txtAPaterno)
        Me.gbxDatosGenerales.Controls.Add(Me.lblPaginaWeb)
        Me.gbxDatosGenerales.Controls.Add(Me.lblRazonSocial)
        Me.gbxDatosGenerales.Controls.Add(Me.lblCurpPersona)
        Me.gbxDatosGenerales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDatosGenerales.Location = New System.Drawing.Point(8, 8)
        Me.gbxDatosGenerales.Name = "gbxDatosGenerales"
        Me.gbxDatosGenerales.Size = New System.Drawing.Size(780, 423)
        Me.gbxDatosGenerales.TabIndex = 90
        Me.gbxDatosGenerales.TabStop = False
        Me.gbxDatosGenerales.Text = "Datos Generales"
        '
        'dtpFechaNacimiento
        '
        Me.dtpFechaNacimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNacimiento.Location = New System.Drawing.Point(226, 317)
        Me.dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        Me.dtpFechaNacimiento.Size = New System.Drawing.Size(218, 20)
        Me.dtpFechaNacimiento.TabIndex = 10
        '
        'lblFechaNacimiento
        '
        Me.lblFechaNacimiento.AutoSize = True
        Me.lblFechaNacimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaNacimiento.Location = New System.Drawing.Point(113, 317)
        Me.lblFechaNacimiento.Name = "lblFechaNacimiento"
        Me.lblFechaNacimiento.Size = New System.Drawing.Size(108, 13)
        Me.lblFechaNacimiento.TabIndex = 98
        Me.lblFechaNacimiento.Text = "Fecha de Nacimiento"
        '
        'txtsicyID
        '
        Me.txtsicyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsicyID.Location = New System.Drawing.Point(226, 89)
        Me.txtsicyID.Name = "txtsicyID"
        Me.txtsicyID.Size = New System.Drawing.Size(104, 20)
        Me.txtsicyID.TabIndex = 3
        '
        'lblSicyID
        '
        Me.lblSicyID.AutoSize = True
        Me.lblSicyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSicyID.Location = New System.Drawing.Point(113, 92)
        Me.lblSicyID.Name = "lblSicyID"
        Me.lblSicyID.Size = New System.Drawing.Size(41, 13)
        Me.lblSicyID.TabIndex = 96
        Me.lblSicyID.Text = "Sicy ID"
        '
        'txtPaginaWeb
        '
        Me.txtPaginaWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaginaWeb.ForeColor = System.Drawing.Color.Blue
        Me.txtPaginaWeb.Location = New System.Drawing.Point(226, 281)
        Me.txtPaginaWeb.Name = "txtPaginaWeb"
        Me.txtPaginaWeb.Size = New System.Drawing.Size(349, 20)
        Me.txtPaginaWeb.TabIndex = 9
        '
        'txtRazonSocialPersona
        '
        Me.txtRazonSocialPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocialPersona.Location = New System.Drawing.Point(226, 249)
        Me.txtRazonSocialPersona.Name = "txtRazonSocialPersona"
        Me.txtRazonSocialPersona.Size = New System.Drawing.Size(349, 20)
        Me.txtRazonSocialPersona.TabIndex = 8
        '
        'txtCurpPersona
        '
        Me.txtCurpPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurpPersona.Location = New System.Drawing.Point(226, 217)
        Me.txtCurpPersona.Name = "txtCurpPersona"
        Me.txtCurpPersona.Size = New System.Drawing.Size(349, 20)
        Me.txtCurpPersona.TabIndex = 7
        '
        'txtAMaterno
        '
        Me.txtAMaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAMaterno.Location = New System.Drawing.Point(226, 185)
        Me.txtAMaterno.Name = "txtAMaterno"
        Me.txtAMaterno.Size = New System.Drawing.Size(349, 20)
        Me.txtAMaterno.TabIndex = 6
        '
        'gbxActivo
        '
        Me.gbxActivo.Controls.Add(Me.rdoSiActivo)
        Me.gbxActivo.Controls.Add(Me.rdoNoActivo)
        Me.gbxActivo.Location = New System.Drawing.Point(226, 378)
        Me.gbxActivo.Name = "gbxActivo"
        Me.gbxActivo.Size = New System.Drawing.Size(218, 35)
        Me.gbxActivo.TabIndex = 91
        Me.gbxActivo.TabStop = False
        '
        'rdoSiActivo
        '
        Me.rdoSiActivo.AutoSize = True
        Me.rdoSiActivo.Checked = True
        Me.rdoSiActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoSiActivo.Location = New System.Drawing.Point(36, 12)
        Me.rdoSiActivo.Name = "rdoSiActivo"
        Me.rdoSiActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoSiActivo.TabIndex = 13
        Me.rdoSiActivo.TabStop = True
        Me.rdoSiActivo.Text = "Si"
        Me.rdoSiActivo.UseVisualStyleBackColor = True
        '
        'rdoNoActivo
        '
        Me.rdoNoActivo.AutoSize = True
        Me.rdoNoActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoNoActivo.Location = New System.Drawing.Point(133, 12)
        Me.rdoNoActivo.Name = "rdoNoActivo"
        Me.rdoNoActivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoActivo.TabIndex = 14
        Me.rdoNoActivo.Text = "No"
        Me.rdoNoActivo.UseVisualStyleBackColor = True
        '
        'gbxPersonaFisica
        '
        Me.gbxPersonaFisica.Controls.Add(Me.rdoSiPersonaFisica)
        Me.gbxPersonaFisica.Controls.Add(Me.rdoNoPersonaFisica)
        Me.gbxPersonaFisica.Location = New System.Drawing.Point(226, 341)
        Me.gbxPersonaFisica.Name = "gbxPersonaFisica"
        Me.gbxPersonaFisica.Size = New System.Drawing.Size(218, 35)
        Me.gbxPersonaFisica.TabIndex = 90
        Me.gbxPersonaFisica.TabStop = False
        '
        'rdoSiPersonaFisica
        '
        Me.rdoSiPersonaFisica.AutoSize = True
        Me.rdoSiPersonaFisica.Checked = True
        Me.rdoSiPersonaFisica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoSiPersonaFisica.Location = New System.Drawing.Point(36, 11)
        Me.rdoSiPersonaFisica.Name = "rdoSiPersonaFisica"
        Me.rdoSiPersonaFisica.Size = New System.Drawing.Size(34, 17)
        Me.rdoSiPersonaFisica.TabIndex = 11
        Me.rdoSiPersonaFisica.TabStop = True
        Me.rdoSiPersonaFisica.Text = "Si"
        Me.rdoSiPersonaFisica.UseVisualStyleBackColor = True
        '
        'rdoNoPersonaFisica
        '
        Me.rdoNoPersonaFisica.AutoSize = True
        Me.rdoNoPersonaFisica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoNoPersonaFisica.Location = New System.Drawing.Point(133, 11)
        Me.rdoNoPersonaFisica.Name = "rdoNoPersonaFisica"
        Me.rdoNoPersonaFisica.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoPersonaFisica.TabIndex = 12
        Me.rdoNoPersonaFisica.Text = "No"
        Me.rdoNoPersonaFisica.UseVisualStyleBackColor = True
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(113, 26)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(35, 13)
        Me.lblTipo.TabIndex = 86
        Me.lblTipo.Text = "* Tipo"
        '
        'cmbClasificacion
        '
        Me.cmbClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClasificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClasificacion.FormattingEnabled = True
        Me.cmbClasificacion.Location = New System.Drawing.Point(226, 56)
        Me.cmbClasificacion.Name = "cmbClasificacion"
        Me.cmbClasificacion.Size = New System.Drawing.Size(349, 21)
        Me.cmbClasificacion.TabIndex = 2
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(226, 23)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(349, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'lblPersonaFisica
        '
        Me.lblPersonaFisica.AutoSize = True
        Me.lblPersonaFisica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonaFisica.Location = New System.Drawing.Point(113, 354)
        Me.lblPersonaFisica.Name = "lblPersonaFisica"
        Me.lblPersonaFisica.Size = New System.Drawing.Size(78, 13)
        Me.lblPersonaFisica.TabIndex = 83
        Me.lblPersonaFisica.Text = "Persona Física"
        '
        'lblClasificacion
        '
        Me.lblClasificacion.AutoSize = True
        Me.lblClasificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClasificacion.Location = New System.Drawing.Point(113, 59)
        Me.lblClasificacion.Name = "lblClasificacion"
        Me.lblClasificacion.Size = New System.Drawing.Size(73, 13)
        Me.lblClasificacion.TabIndex = 88
        Me.lblClasificacion.Text = "* Clasificación"
        '
        'lblNombrePersona
        '
        Me.lblNombrePersona.AutoSize = True
        Me.lblNombrePersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePersona.Location = New System.Drawing.Point(113, 125)
        Me.lblNombrePersona.Name = "lblNombrePersona"
        Me.lblNombrePersona.Size = New System.Drawing.Size(51, 13)
        Me.lblNombrePersona.TabIndex = 68
        Me.lblNombrePersona.Text = "* Nombre"
        '
        'txtNombrePersona
        '
        Me.txtNombrePersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombrePersona.Location = New System.Drawing.Point(226, 121)
        Me.txtNombrePersona.Name = "txtNombrePersona"
        Me.txtNombrePersona.Size = New System.Drawing.Size(349, 20)
        Me.txtNombrePersona.TabIndex = 4
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.Location = New System.Drawing.Point(113, 392)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 80
        Me.lblActivo.Text = "Activo"
        '
        'lblAPaterno
        '
        Me.lblAPaterno.AutoSize = True
        Me.lblAPaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAPaterno.Location = New System.Drawing.Point(113, 158)
        Me.lblAPaterno.Name = "lblAPaterno"
        Me.lblAPaterno.Size = New System.Drawing.Size(57, 13)
        Me.lblAPaterno.TabIndex = 69
        Me.lblAPaterno.Text = "A. Paterno"
        '
        'lblAMaterno
        '
        Me.lblAMaterno.AutoSize = True
        Me.lblAMaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMaterno.Location = New System.Drawing.Point(113, 191)
        Me.lblAMaterno.Name = "lblAMaterno"
        Me.lblAMaterno.Size = New System.Drawing.Size(59, 13)
        Me.lblAMaterno.TabIndex = 70
        Me.lblAMaterno.Text = "A. Materno"
        '
        'txtAPaterno
        '
        Me.txtAPaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPaterno.Location = New System.Drawing.Point(226, 153)
        Me.txtAPaterno.Name = "txtAPaterno"
        Me.txtAPaterno.Size = New System.Drawing.Size(349, 20)
        Me.txtAPaterno.TabIndex = 5
        '
        'lblPaginaWeb
        '
        Me.lblPaginaWeb.AutoSize = True
        Me.lblPaginaWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaginaWeb.Location = New System.Drawing.Point(113, 284)
        Me.lblPaginaWeb.Name = "lblPaginaWeb"
        Me.lblPaginaWeb.Size = New System.Drawing.Size(106, 13)
        Me.lblPaginaWeb.TabIndex = 73
        Me.lblPaginaWeb.Text = "Página Web General"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.Location = New System.Drawing.Point(113, 252)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(77, 13)
        Me.lblRazonSocial.TabIndex = 72
        Me.lblRazonSocial.Text = "* Razón Social"
        '
        'lblCurpPersona
        '
        Me.lblCurpPersona.AutoSize = True
        Me.lblCurpPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurpPersona.Location = New System.Drawing.Point(113, 220)
        Me.lblCurpPersona.Name = "lblCurpPersona"
        Me.lblCurpPersona.Size = New System.Drawing.Size(37, 13)
        Me.lblCurpPersona.TabIndex = 71
        Me.lblCurpPersona.Text = "CURP"
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.General)
        Me.TabDatos.Controls.Add(Me.Domicilio)
        Me.TabDatos.Controls.Add(Me.Contactos)
        Me.TabDatos.Controls.Add(Me.TabProveedor)
        Me.TabDatos.Controls.Add(Me.tapTelefonos)
        Me.TabDatos.Controls.Add(Me.tabEmails)
        Me.TabDatos.Controls.Add(Me.TabConvenios)
        Me.TabDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabDatos.Location = New System.Drawing.Point(0, 60)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.SelectedIndex = 0
        Me.TabDatos.Size = New System.Drawing.Size(814, 488)
        Me.TabDatos.TabIndex = 14
        '
        'tapTelefonos
        '
        Me.tapTelefonos.BackColor = System.Drawing.Color.AliceBlue
        Me.tapTelefonos.Controls.Add(Me.gbxTelefonos)
        Me.tapTelefonos.Controls.Add(Me.grdTelefonos)
        Me.tapTelefonos.Controls.Add(Me.lblExtencion)
        Me.tapTelefonos.Controls.Add(Me.lblTelefono)
        Me.tapTelefonos.Location = New System.Drawing.Point(4, 22)
        Me.tapTelefonos.Name = "tapTelefonos"
        Me.tapTelefonos.Padding = New System.Windows.Forms.Padding(3)
        Me.tapTelefonos.Size = New System.Drawing.Size(796, 445)
        Me.tapTelefonos.TabIndex = 4
        Me.tapTelefonos.Text = "Teléfono"
        '
        'gbxTelefonos
        '
        Me.gbxTelefonos.Controls.Add(Me.Label13)
        Me.gbxTelefonos.Controls.Add(Me.lblTipoTelefono)
        Me.gbxTelefonos.Controls.Add(Me.Label9)
        Me.gbxTelefonos.Controls.Add(Me.Label10)
        Me.gbxTelefonos.Controls.Add(Me.txtTelefono)
        Me.gbxTelefonos.Controls.Add(Me.lblAñadirTelefono)
        Me.gbxTelefonos.Controls.Add(Me.txtExtTelefono)
        Me.gbxTelefonos.Controls.Add(Me.btnAgregarTelefono)
        Me.gbxTelefonos.Controls.Add(Me.cmbTipoTelefono)
        Me.gbxTelefonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxTelefonos.Location = New System.Drawing.Point(11, 24)
        Me.gbxTelefonos.Name = "gbxTelefonos"
        Me.gbxTelefonos.Size = New System.Drawing.Size(777, 121)
        Me.gbxTelefonos.TabIndex = 126
        Me.gbxTelefonos.TabStop = False
        Me.gbxTelefonos.Text = "Teléfono"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label13.Location = New System.Drawing.Point(719, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Añadir"
        '
        'lblTipoTelefono
        '
        Me.lblTipoTelefono.AutoSize = True
        Me.lblTipoTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoTelefono.Location = New System.Drawing.Point(227, 89)
        Me.lblTipoTelefono.Name = "lblTipoTelefono"
        Me.lblTipoTelefono.Size = New System.Drawing.Size(73, 13)
        Me.lblTipoTelefono.TabIndex = 128
        Me.lblTipoTelefono.Text = "Tipo Teléfono"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(227, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "Extensión"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(227, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 126
        Me.Label10.Text = "Teléfono"
        '
        'txtTelefono
        '
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(312, 21)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(207, 20)
        Me.txtTelefono.TabIndex = 1
        '
        'lblAñadirTelefono
        '
        Me.lblAñadirTelefono.AutoSize = True
        Me.lblAñadirTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAñadirTelefono.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAñadirTelefono.Location = New System.Drawing.Point(643, 98)
        Me.lblAñadirTelefono.Name = "lblAñadirTelefono"
        Me.lblAñadirTelefono.Size = New System.Drawing.Size(0, 13)
        Me.lblAñadirTelefono.TabIndex = 125
        '
        'txtExtTelefono
        '
        Me.txtExtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtTelefono.Location = New System.Drawing.Point(312, 53)
        Me.txtExtTelefono.Name = "txtExtTelefono"
        Me.txtExtTelefono.Size = New System.Drawing.Size(207, 20)
        Me.txtExtTelefono.TabIndex = 2
        '
        'btnAgregarTelefono
        '
        Me.btnAgregarTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarTelefono.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAgregarTelefono.Location = New System.Drawing.Point(721, 66)
        Me.btnAgregarTelefono.Name = "btnAgregarTelefono"
        Me.btnAgregarTelefono.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregarTelefono.TabIndex = 4
        Me.btnAgregarTelefono.UseVisualStyleBackColor = True
        '
        'cmbTipoTelefono
        '
        Me.cmbTipoTelefono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoTelefono.FormattingEnabled = True
        Me.cmbTipoTelefono.Location = New System.Drawing.Point(312, 86)
        Me.cmbTipoTelefono.Name = "cmbTipoTelefono"
        Me.cmbTipoTelefono.Size = New System.Drawing.Size(207, 21)
        Me.cmbTipoTelefono.TabIndex = 3
        '
        'grdTelefonos
        '
        Me.grdTelefonos.AllowUserToAddRows = False
        Me.grdTelefonos.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTelefonos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdTelefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTelefonos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTelefonoPersona, Me.ColExt, Me.ColTipoTelefono, Me.ColIdTipoTelefono, Me.ColTelID})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdTelefonos.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdTelefonos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdTelefonos.Location = New System.Drawing.Point(3, 160)
        Me.grdTelefonos.Name = "grdTelefonos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTelefonos.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdTelefonos.Size = New System.Drawing.Size(790, 282)
        Me.grdTelefonos.TabIndex = 83
        '
        'ColTelefonoPersona
        '
        Me.ColTelefonoPersona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColTelefonoPersona.HeaderText = "Telefono"
        Me.ColTelefonoPersona.Name = "ColTelefonoPersona"
        '
        'ColExt
        '
        Me.ColExt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColExt.HeaderText = "Extensión"
        Me.ColExt.Name = "ColExt"
        '
        'ColTipoTelefono
        '
        Me.ColTipoTelefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColTipoTelefono.HeaderText = "Tipo Teléfono"
        Me.ColTipoTelefono.Name = "ColTipoTelefono"
        '
        'ColIdTipoTelefono
        '
        Me.ColIdTipoTelefono.HeaderText = "IDTipoTelefono"
        Me.ColIdTipoTelefono.Name = "ColIdTipoTelefono"
        Me.ColIdTipoTelefono.Visible = False
        '
        'ColTelID
        '
        Me.ColTelID.HeaderText = "TelID"
        Me.ColTelID.Name = "ColTelID"
        Me.ColTelID.Visible = False
        '
        'lblExtencion
        '
        Me.lblExtencion.AutoSize = True
        Me.lblExtencion.Location = New System.Drawing.Point(8, 132)
        Me.lblExtencion.Name = "lblExtencion"
        Me.lblExtencion.Size = New System.Drawing.Size(0, 13)
        Me.lblExtencion.TabIndex = 56
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Location = New System.Drawing.Point(8, 100)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(0, 13)
        Me.lblTelefono.TabIndex = 55
        '
        'tabEmails
        '
        Me.tabEmails.BackColor = System.Drawing.Color.AliceBlue
        Me.tabEmails.Controls.Add(Me.GroupBox1)
        Me.tabEmails.Controls.Add(Me.grdEmails)
        Me.tabEmails.Location = New System.Drawing.Point(4, 22)
        Me.tabEmails.Name = "tabEmails"
        Me.tabEmails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabEmails.Size = New System.Drawing.Size(796, 445)
        Me.tabEmails.TabIndex = 5
        Me.tabEmails.Text = "Correo Electrónico"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.btnQuitarEmail)
        Me.GroupBox1.Controls.Add(Me.lblEmail)
        Me.GroupBox1.Controls.Add(Me.txtEmail)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 69)
        Me.GroupBox1.TabIndex = 96
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Correo Electrónico"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label12.Location = New System.Drawing.Point(724, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 125
        Me.Label12.Text = "Añadir"
        '
        'btnQuitarEmail
        '
        Me.btnQuitarEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitarEmail.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnQuitarEmail.Location = New System.Drawing.Point(726, 15)
        Me.btnQuitarEmail.Name = "btnQuitarEmail"
        Me.btnQuitarEmail.Size = New System.Drawing.Size(32, 32)
        Me.btnQuitarEmail.TabIndex = 2
        Me.btnQuitarEmail.UseVisualStyleBackColor = True
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(116, 30)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(94, 13)
        Me.lblEmail.TabIndex = 94
        Me.lblEmail.Text = "Correo Electrónico"
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(225, 27)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(411, 20)
        Me.txtEmail.TabIndex = 1
        '
        'grdEmails
        '
        Me.grdEmails.AllowUserToAddRows = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.grdEmails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.grdEmails.BackgroundColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdEmails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grdEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEmails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colidEmail, Me.ColEmail})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdEmails.DefaultCellStyle = DataGridViewCellStyle10
        Me.grdEmails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdEmails.Location = New System.Drawing.Point(3, 81)
        Me.grdEmails.Name = "grdEmails"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdEmails.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.grdEmails.Size = New System.Drawing.Size(790, 361)
        Me.grdEmails.TabIndex = 83
        '
        'colidEmail
        '
        Me.colidEmail.HeaderText = "IdEmail"
        Me.colidEmail.Name = "colidEmail"
        Me.colidEmail.Visible = False
        '
        'ColEmail
        '
        Me.ColEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColEmail.HeaderText = "Correo Electrónico"
        Me.ColEmail.Name = "ColEmail"
        '
        'TabConvenios
        '
        Me.TabConvenios.BackColor = System.Drawing.Color.AliceBlue
        Me.TabConvenios.Controls.Add(Me.grdListaConvenios)
        Me.TabConvenios.Controls.Add(Me.pnlAltas)
        Me.TabConvenios.Location = New System.Drawing.Point(4, 22)
        Me.TabConvenios.Name = "TabConvenios"
        Me.TabConvenios.Size = New System.Drawing.Size(796, 445)
        Me.TabConvenios.TabIndex = 6
        Me.TabConvenios.Text = "Convenios"
        '
        'grdListaConvenios
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaConvenios.DisplayLayout.Appearance = Appearance2
        Me.grdListaConvenios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdListaConvenios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdListaConvenios.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaConvenios.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaConvenios.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaConvenios.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdListaConvenios.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaConvenios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdListaConvenios.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaConvenios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaConvenios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaConvenios.Location = New System.Drawing.Point(0, 339)
        Me.grdListaConvenios.Name = "grdListaConvenios"
        Me.grdListaConvenios.Size = New System.Drawing.Size(796, 106)
        Me.grdListaConvenios.TabIndex = 13
        '
        'pnlAltas
        '
        Me.pnlAltas.Controls.Add(Me.grbConvenios)
        Me.pnlAltas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAltas.Location = New System.Drawing.Point(0, 0)
        Me.pnlAltas.Name = "pnlAltas"
        Me.pnlAltas.Size = New System.Drawing.Size(796, 339)
        Me.pnlAltas.TabIndex = 10
        '
        'grbConvenios
        '
        Me.grbConvenios.Controls.Add(Me.GroupBox2)
        Me.grbConvenios.Controls.Add(Me.txtComentarioConvenios)
        Me.grbConvenios.Controls.Add(Me.txtDescripcionConvenios)
        Me.grbConvenios.Controls.Add(Me.Panel1)
        Me.grbConvenios.Controls.Add(Me.lblActivoConvenio)
        Me.grbConvenios.Controls.Add(Me.lblDescripcion)
        Me.grbConvenios.Controls.Add(Me.lblComentario)
        Me.grbConvenios.Controls.Add(Me.dtpFechaTerminoVigencia)
        Me.grbConvenios.Controls.Add(Me.dtpFechaInicioVigencia)
        Me.grbConvenios.Controls.Add(Me.dtpFechaDeSubscripcion)
        Me.grbConvenios.Controls.Add(Me.txtNegociador)
        Me.grbConvenios.Controls.Add(Me.lblNumConvenio)
        Me.grbConvenios.Controls.Add(Me.lblFechaSubscripcion)
        Me.grbConvenios.Controls.Add(Me.lblVigenciaInicio)
        Me.grbConvenios.Controls.Add(Me.lblNegocia)
        Me.grbConvenios.Controls.Add(Me.lblVigenciaFin)
        Me.grbConvenios.Controls.Add(Me.txtNumConvenio)
        Me.grbConvenios.Controls.Add(Me.cmbRazonSocial)
        Me.grbConvenios.Controls.Add(Me.lblEmpresa)
        Me.grbConvenios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbConvenios.Location = New System.Drawing.Point(8, 9)
        Me.grbConvenios.Name = "grbConvenios"
        Me.grbConvenios.Size = New System.Drawing.Size(780, 321)
        Me.grbConvenios.TabIndex = 0
        Me.grbConvenios.TabStop = False
        Me.grbConvenios.Text = "Convenios"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pnlActivo)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(138, 246)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 36)
        Me.GroupBox2.TabIndex = 132
        Me.GroupBox2.TabStop = False
        '
        'pnlActivo
        '
        Me.pnlActivo.Controls.Add(Me.rdoNoConvenio)
        Me.pnlActivo.Controls.Add(Me.rdoSiConvenio)
        Me.pnlActivo.Location = New System.Drawing.Point(16, 7)
        Me.pnlActivo.Name = "pnlActivo"
        Me.pnlActivo.Size = New System.Drawing.Size(176, 27)
        Me.pnlActivo.TabIndex = 128
        '
        'rdoNoConvenio
        '
        Me.rdoNoConvenio.AutoSize = True
        Me.rdoNoConvenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoNoConvenio.Location = New System.Drawing.Point(130, 6)
        Me.rdoNoConvenio.Name = "rdoNoConvenio"
        Me.rdoNoConvenio.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoConvenio.TabIndex = 10
        Me.rdoNoConvenio.Text = "No"
        Me.rdoNoConvenio.UseVisualStyleBackColor = True
        '
        'rdoSiConvenio
        '
        Me.rdoSiConvenio.AutoSize = True
        Me.rdoSiConvenio.Checked = True
        Me.rdoSiConvenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoSiConvenio.Location = New System.Drawing.Point(44, 6)
        Me.rdoSiConvenio.Name = "rdoSiConvenio"
        Me.rdoSiConvenio.Size = New System.Drawing.Size(34, 17)
        Me.rdoSiConvenio.TabIndex = 9
        Me.rdoSiConvenio.TabStop = True
        Me.rdoSiConvenio.Text = "Si"
        Me.rdoSiConvenio.UseVisualStyleBackColor = True
        '
        'txtComentarioConvenios
        '
        Me.txtComentarioConvenios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentarioConvenios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarioConvenios.Location = New System.Drawing.Point(138, 197)
        Me.txtComentarioConvenios.MaxLength = 150
        Me.txtComentarioConvenios.Multiline = True
        Me.txtComentarioConvenios.Name = "txtComentarioConvenios"
        Me.txtComentarioConvenios.Size = New System.Drawing.Size(606, 44)
        Me.txtComentarioConvenios.TabIndex = 8
        '
        'txtDescripcionConvenios
        '
        Me.txtDescripcionConvenios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionConvenios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcionConvenios.Location = New System.Drawing.Point(138, 146)
        Me.txtDescripcionConvenios.MaxLength = 150
        Me.txtDescripcionConvenios.Multiline = True
        Me.txtDescripcionConvenios.Name = "txtDescripcionConvenios"
        Me.txtDescripcionConvenios.Size = New System.Drawing.Size(606, 41)
        Me.txtDescripcionConvenios.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnAgregarConvenio)
        Me.Panel1.Controls.Add(Me.lblActualizar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnActualizar)
        Me.Panel1.Location = New System.Drawing.Point(633, 247)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(147, 69)
        Me.Panel1.TabIndex = 131
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(83, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Convenio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(14, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Convenio"
        '
        'btnAgregarConvenio
        '
        Me.btnAgregarConvenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarConvenio.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAgregarConvenio.Location = New System.Drawing.Point(21, 3)
        Me.btnAgregarConvenio.Name = "btnAgregarConvenio"
        Me.btnAgregarConvenio.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregarConvenio.TabIndex = 11
        Me.btnAgregarConvenio.UseVisualStyleBackColor = True
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.Location = New System.Drawing.Point(86, 38)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(45, 13)
        Me.lblActualizar.TabIndex = 130
        Me.lblActualizar.Text = "Guardar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(20, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Añadir"
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnActualizar.Location = New System.Drawing.Point(90, 3)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 12
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'lblActivoConvenio
        '
        Me.lblActivoConvenio.AutoSize = True
        Me.lblActivoConvenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivoConvenio.Location = New System.Drawing.Point(39, 260)
        Me.lblActivoConvenio.Name = "lblActivoConvenio"
        Me.lblActivoConvenio.Size = New System.Drawing.Size(44, 13)
        Me.lblActivoConvenio.TabIndex = 22
        Me.lblActivoConvenio.Text = "* Activo"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(39, 146)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(70, 13)
        Me.lblDescripcion.TabIndex = 17
        Me.lblDescripcion.Text = "* Descripción"
        '
        'lblComentario
        '
        Me.lblComentario.AutoSize = True
        Me.lblComentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComentario.Location = New System.Drawing.Point(39, 197)
        Me.lblComentario.Name = "lblComentario"
        Me.lblComentario.Size = New System.Drawing.Size(65, 13)
        Me.lblComentario.TabIndex = 15
        Me.lblComentario.Text = "Comentarios"
        '
        'dtpFechaTerminoVigencia
        '
        Me.dtpFechaTerminoVigencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaTerminoVigencia.Location = New System.Drawing.Point(517, 86)
        Me.dtpFechaTerminoVigencia.Name = "dtpFechaTerminoVigencia"
        Me.dtpFechaTerminoVigencia.Size = New System.Drawing.Size(227, 20)
        Me.dtpFechaTerminoVigencia.TabIndex = 5
        '
        'dtpFechaInicioVigencia
        '
        Me.dtpFechaInicioVigencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicioVigencia.Location = New System.Drawing.Point(138, 86)
        Me.dtpFechaInicioVigencia.Name = "dtpFechaInicioVigencia"
        Me.dtpFechaInicioVigencia.Size = New System.Drawing.Size(230, 20)
        Me.dtpFechaInicioVigencia.TabIndex = 4
        '
        'dtpFechaDeSubscripcion
        '
        Me.dtpFechaDeSubscripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDeSubscripcion.Location = New System.Drawing.Point(516, 56)
        Me.dtpFechaDeSubscripcion.Name = "dtpFechaDeSubscripcion"
        Me.dtpFechaDeSubscripcion.Size = New System.Drawing.Size(228, 20)
        Me.dtpFechaDeSubscripcion.TabIndex = 3
        '
        'txtNegociador
        '
        Me.txtNegociador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNegociador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNegociador.Location = New System.Drawing.Point(138, 116)
        Me.txtNegociador.MaxLength = 150
        Me.txtNegociador.Name = "txtNegociador"
        Me.txtNegociador.Size = New System.Drawing.Size(606, 20)
        Me.txtNegociador.TabIndex = 6
        '
        'lblNumConvenio
        '
        Me.lblNumConvenio.AutoSize = True
        Me.lblNumConvenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumConvenio.Location = New System.Drawing.Point(39, 59)
        Me.lblNumConvenio.Name = "lblNumConvenio"
        Me.lblNumConvenio.Size = New System.Drawing.Size(94, 13)
        Me.lblNumConvenio.TabIndex = 8
        Me.lblNumConvenio.Text = "* No. de Convenio"
        '
        'lblFechaSubscripcion
        '
        Me.lblFechaSubscripcion.AutoSize = True
        Me.lblFechaSubscripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaSubscripcion.Location = New System.Drawing.Point(414, 59)
        Me.lblFechaSubscripcion.Name = "lblFechaSubscripcion"
        Me.lblFechaSubscripcion.Size = New System.Drawing.Size(95, 13)
        Me.lblFechaSubscripcion.TabIndex = 7
        Me.lblFechaSubscripcion.Text = "Fecha Suscripción"
        '
        'lblVigenciaInicio
        '
        Me.lblVigenciaInicio.AutoSize = True
        Me.lblVigenciaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVigenciaInicio.Location = New System.Drawing.Point(39, 90)
        Me.lblVigenciaInicio.Name = "lblVigenciaInicio"
        Me.lblVigenciaInicio.Size = New System.Drawing.Size(72, 13)
        Me.lblVigenciaInicio.TabIndex = 5
        Me.lblVigenciaInicio.Text = "* Fecha Inicio"
        '
        'lblNegocia
        '
        Me.lblNegocia.AutoSize = True
        Me.lblNegocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNegocia.Location = New System.Drawing.Point(39, 116)
        Me.lblNegocia.Name = "lblNegocia"
        Me.lblNegocia.Size = New System.Drawing.Size(69, 13)
        Me.lblNegocia.TabIndex = 4
        Me.lblNegocia.Text = "* Negociador"
        '
        'lblVigenciaFin
        '
        Me.lblVigenciaFin.AutoSize = True
        Me.lblVigenciaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVigenciaFin.Location = New System.Drawing.Point(419, 90)
        Me.lblVigenciaFin.Name = "lblVigenciaFin"
        Me.lblVigenciaFin.Size = New System.Drawing.Size(61, 13)
        Me.lblVigenciaFin.TabIndex = 3
        Me.lblVigenciaFin.Text = "* Fecha Fin"
        '
        'txtNumConvenio
        '
        Me.txtNumConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumConvenio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumConvenio.Location = New System.Drawing.Point(138, 56)
        Me.txtNumConvenio.MaxLength = 30
        Me.txtNumConvenio.Name = "txtNumConvenio"
        Me.txtNumConvenio.Size = New System.Drawing.Size(230, 20)
        Me.txtNumConvenio.TabIndex = 2
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Location = New System.Drawing.Point(138, 25)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(606, 21)
        Me.cmbRazonSocial.TabIndex = 1
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(39, 25)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(55, 13)
        Me.lblEmpresa.TabIndex = 0
        Me.lblEmpresa.Text = "* Empresa"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Calle"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "# interior"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "# exterior"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Colonia"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "C.P."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Pais"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Ciudad"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Poblacion"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Activo"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "IDDom"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Telefono"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Ext."
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Tipo Telefono"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "IDTipoTelefono"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "TelID"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn17.HeaderText = "IdEmail"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn18.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn19.HeaderText = "Tipo Telefono"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn20.HeaderText = "IDTipoTelefono"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn21.HeaderText = "TelID"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "IdEmail"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn23.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.Visible = False
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "IdEmail"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.Visible = False
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn25.HeaderText = "Email"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        '
        'ColTipo
        '
        Me.ColTipo.HeaderText = "Tipo"
        Me.ColTipo.Name = "ColTipo"
        '
        'ColExtencion
        '
        Me.ColExtencion.HeaderText = "Extencion"
        Me.ColExtencion.Name = "ColExtencion"
        '
        'ColTelefono
        '
        Me.ColTelefono.HeaderText = "Telefono"
        Me.ColTelefono.Name = "ColTelefono"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(746, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'AltaPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(814, 601)
        Me.Controls.Add(Me.TabDatos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlInferior)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(820, 623)
        Me.MinimumSize = New System.Drawing.Size(820, 623)
        Me.Name = "AltaPersona"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Proveedores"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.TabProveedor.ResumeLayout(False)
        Me.gpbTipoFlete.ResumeLayout(False)
        Me.gpbTipoFlete.PerformLayout()
        CType(Me.grdTiposFleteMensajeria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxWebProveedor.ResumeLayout(False)
        Me.gbxWebProveedor.PerformLayout()
        Me.gbxProveedor.ResumeLayout(False)
        Me.gbxProveedor.PerformLayout()
        Me.Contactos.ResumeLayout(False)
        CType(Me.gridDatosContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Domicilio.ResumeLayout(False)
        CType(Me.grdDomicilios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDomicilios.ResumeLayout(False)
        Me.gbxDomicilios.PerformLayout()
        Me.gbxActivoDomicilio.ResumeLayout(False)
        Me.gbxActivoDomicilio.PerformLayout()
        Me.General.ResumeLayout(False)
        Me.gbxDatosGenerales.ResumeLayout(False)
        Me.gbxDatosGenerales.PerformLayout()
        Me.gbxActivo.ResumeLayout(False)
        Me.gbxActivo.PerformLayout()
        Me.gbxPersonaFisica.ResumeLayout(False)
        Me.gbxPersonaFisica.PerformLayout()
        Me.TabDatos.ResumeLayout(False)
        Me.tapTelefonos.ResumeLayout(False)
        Me.tapTelefonos.PerformLayout()
        Me.gbxTelefonos.ResumeLayout(False)
        Me.gbxTelefonos.PerformLayout()
        CType(Me.grdTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEmails.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdEmails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabConvenios.ResumeLayout(False)
        CType(Me.grdListaConvenios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAltas.ResumeLayout(False)
        Me.grbConvenios.ResumeLayout(False)
        Me.grbConvenios.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlActivo.ResumeLayout(False)
        Me.pnlActivo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardarTodo As System.Windows.Forms.Label
    Friend WithEvents btnGuardarTodo As System.Windows.Forms.Button
    Friend WithEvents TabProveedor As System.Windows.Forms.TabPage
    Friend WithEvents Contactos As System.Windows.Forms.TabPage
    Friend WithEvents Domicilio As System.Windows.Forms.TabPage
    Friend WithEvents gbxDomicilios As System.Windows.Forms.GroupBox
    Friend WithEvents lblAñadirDomicilio As System.Windows.Forms.Label
    Friend WithEvents btnAñadirDomicilio As System.Windows.Forms.Button
    Friend WithEvents gbxActivoDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSiActivoDomicilio As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNoActivoDomicilio As System.Windows.Forms.RadioButton
    Friend WithEvents cmbPoblacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblPoblacion As System.Windows.Forms.Label
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents lblActivoDomicilio As System.Windows.Forms.Label
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtNoExterior As System.Windows.Forms.TextBox
    Friend WithEvents txtNoInterior As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblNoExterior As System.Windows.Forms.Label
    Friend WithEvents lblNoInterior As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents grdDomicilios As System.Windows.Forms.DataGridView
    Friend WithEvents General As System.Windows.Forms.TabPage
    Friend WithEvents TabDatos As System.Windows.Forms.TabControl
    Friend WithEvents gbxWebProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents txtContraseñaWeb As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuarioWeb As System.Windows.Forms.TextBox
    Friend WithEvents txtWebCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblContraseñaWebProv As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioWebProvee As System.Windows.Forms.Label
    Friend WithEvents lblWebClienteProveedor As System.Windows.Forms.Label
    Friend WithEvents gbxProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents txtClaveYuyin As System.Windows.Forms.TextBox
    Friend WithEvents txtRFCProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocialProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblClaveYuyinProveedor As System.Windows.Forms.Label
    Friend WithEvents lblRFCProveedor As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocialProveedor As System.Windows.Forms.Label
    Friend WithEvents lblNombreProveedor As System.Windows.Forms.Label
    Friend WithEvents gbxDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents txtPaginaWeb As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocialPersona As System.Windows.Forms.TextBox
    Friend WithEvents txtCurpPersona As System.Windows.Forms.TextBox
    Friend WithEvents txtAMaterno As System.Windows.Forms.TextBox
    Friend WithEvents gbxActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSiActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents gbxPersonaFisica As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSiPersonaFisica As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNoPersonaFisica As System.Windows.Forms.RadioButton
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbClasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblPersonaFisica As System.Windows.Forms.Label
    Friend WithEvents lblClasificacion As System.Windows.Forms.Label
    Friend WithEvents lblNombrePersona As System.Windows.Forms.Label
    Friend WithEvents txtNombrePersona As System.Windows.Forms.TextBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents lblAPaterno As System.Windows.Forms.Label
    Friend WithEvents lblAMaterno As System.Windows.Forms.Label
    Friend WithEvents txtAPaterno As System.Windows.Forms.TextBox
    Friend WithEvents lblPaginaWeb As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblCurpPersona As System.Windows.Forms.Label
    Friend WithEvents tapTelefonos As System.Windows.Forms.TabPage
    Friend WithEvents lblAñadirTelefono As System.Windows.Forms.Label
    Friend WithEvents btnAgregarTelefono As System.Windows.Forms.Button
    Friend WithEvents cmbTipoTelefono As System.Windows.Forms.ComboBox
    Friend WithEvents grdTelefonos As System.Windows.Forms.DataGridView
    Friend WithEvents txtExtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblExtencion As System.Windows.Forms.Label
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents tabEmails As System.Windows.Forms.TabPage
    Friend WithEvents grdEmails As System.Windows.Forms.DataGridView
    Friend WithEvents ColTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColExtencion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTelefono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtsicyID As System.Windows.Forms.TextBox
    Friend WithEvents lblSicyID As System.Windows.Forms.Label
    Friend WithEvents gbxTelefonos As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblTipoTelefono As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnQuitarEmail As System.Windows.Forms.Button
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents gridDatosContacto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpFechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents txtHorario As System.Windows.Forms.TextBox
    Friend WithEvents lblHorario As System.Windows.Forms.Label
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents lblComentarios As System.Windows.Forms.Label
    Friend WithEvents txtDelegacion As System.Windows.Forms.TextBox
    Friend WithEvents lblDelegacion As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gpbTipoFlete As System.Windows.Forms.GroupBox
    Friend WithEvents grdTiposFleteMensajeria As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAddTipoFlete As System.Windows.Forms.Button
    Friend WithEvents lblTipoFlete As System.Windows.Forms.Label
    Friend WithEvents cmbTipoFleteMensajeria As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabConvenios As System.Windows.Forms.TabPage
    Friend WithEvents grbConvenios As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblComentario As System.Windows.Forms.Label
    Friend WithEvents dtpFechaTerminoVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicioVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDeSubscripcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNegociador As System.Windows.Forms.TextBox
    Friend WithEvents lblNumConvenio As System.Windows.Forms.Label
    Friend WithEvents lblFechaSubscripcion As System.Windows.Forms.Label
    Friend WithEvents lblVigenciaInicio As System.Windows.Forms.Label
    Friend WithEvents lblNegocia As System.Windows.Forms.Label
    Friend WithEvents lblVigenciaFin As System.Windows.Forms.Label
    Friend WithEvents txtNumConvenio As System.Windows.Forms.TextBox
    Friend WithEvents cmbRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents rdoSiConvenio As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNoConvenio As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivoConvenio As System.Windows.Forms.Label
    Friend WithEvents pnlAltas As System.Windows.Forms.Panel
    Friend WithEvents grdListaConvenios As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAgregarConvenio As System.Windows.Forms.Button
    Friend WithEvents pnlActivo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblActualizar As System.Windows.Forms.Label
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents txtComentarioConvenios As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionConvenios As System.Windows.Forms.TextBox
    Friend WithEvents ColNombreTipoFlete As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivoFlete As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColTipoFleteID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColCalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNoInterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNoExterior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColColonia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPais As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCiudad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPoblacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIDDomicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaisID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CiudadID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PoblacionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDelegacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTelefonoPersona As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColExt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTipoTelefono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIdTipoTelefono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTelID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colidEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As PictureBox
End Class
