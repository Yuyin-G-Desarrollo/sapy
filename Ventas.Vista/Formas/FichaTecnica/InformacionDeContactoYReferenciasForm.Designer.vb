<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformacionDeContactoYReferenciasForm
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
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformacionDeContactoYReferenciasForm))
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlBtnAltas = New System.Windows.Forms.Panel()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.gpbContactosReferenciasComerciales = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grdReferenciasComerciales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gpbCargosContacto = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grdContactoSeleccionado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnAgregarCargos = New System.Windows.Forms.Button()
        Me.gpbCorreoElectronico = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grdCorreo = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnAgregarEmail = New System.Windows.Forms.Button()
        Me.gpbTelefonos = New Infragistics.Win.Misc.UltraGroupBox()
        Me.grdTelefono = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAgregarTelefono = New System.Windows.Forms.Button()
        Me.chkVerTodo = New System.Windows.Forms.CheckBox()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlBtnAltas.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.gpbContactosReferenciasComerciales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbContactosReferenciasComerciales.SuspendLayout()
        CType(Me.grdReferenciasComerciales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpbCargosContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbCargosContacto.SuspendLayout()
        CType(Me.grdContactoSeleccionado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.gpbCorreoElectronico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbCorreoElectronico.SuspendLayout()
        CType(Me.grdCorreo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.gpbTelefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbTelefonos.SuspendLayout()
        CType(Me.grdTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 464)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(928, 60)
        Me.pnlPie.TabIndex = 20
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(814, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(114, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(68, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(68, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnAltas)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(928, 60)
        Me.pnlEncabezado.TabIndex = 19
        '
        'pnlBtnAltas
        '
        Me.pnlBtnAltas.Controls.Add(Me.btnAltas)
        Me.pnlBtnAltas.Controls.Add(Me.lblAltas)
        Me.pnlBtnAltas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnAltas.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtnAltas.Name = "pnlBtnAltas"
        Me.pnlBtnAltas.Size = New System.Drawing.Size(54, 60)
        Me.pnlBtnAltas.TabIndex = 49
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(11, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(13, 41)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 14
        Me.lblAltas.Text = "Altas"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(512, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(416, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(11, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(331, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Información de Contactos y Referencias"
        '
        'gpbContactosReferenciasComerciales
        '
        Me.gpbContactosReferenciasComerciales.Controls.Add(Me.grdReferenciasComerciales)
        Me.gpbContactosReferenciasComerciales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbContactosReferenciasComerciales.Location = New System.Drawing.Point(11, 66)
        Me.gpbContactosReferenciasComerciales.Name = "gpbContactosReferenciasComerciales"
        Me.gpbContactosReferenciasComerciales.Size = New System.Drawing.Size(467, 248)
        Me.gpbContactosReferenciasComerciales.TabIndex = 2
        Me.gpbContactosReferenciasComerciales.Text = "Contactos y Referencias Comerciales"
        '
        'grdReferenciasComerciales
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdReferenciasComerciales.DisplayLayout.Appearance = Appearance1
        Me.grdReferenciasComerciales.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdReferenciasComerciales.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdReferenciasComerciales.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdReferenciasComerciales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReferenciasComerciales.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReferenciasComerciales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdReferenciasComerciales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdReferenciasComerciales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdReferenciasComerciales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdReferenciasComerciales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdReferenciasComerciales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdReferenciasComerciales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdReferenciasComerciales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReferenciasComerciales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdReferenciasComerciales.Location = New System.Drawing.Point(3, 16)
        Me.grdReferenciasComerciales.Name = "grdReferenciasComerciales"
        Me.grdReferenciasComerciales.Size = New System.Drawing.Size(461, 229)
        Me.grdReferenciasComerciales.TabIndex = 3
        '
        'gpbCargosContacto
        '
        Me.gpbCargosContacto.AccessibleDescription = ""
        Me.gpbCargosContacto.Controls.Add(Me.grdContactoSeleccionado)
        Me.gpbCargosContacto.Controls.Add(Me.Panel3)
        Me.gpbCargosContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbCargosContacto.Location = New System.Drawing.Point(11, 320)
        Me.gpbCargosContacto.Name = "gpbCargosContacto"
        Me.gpbCargosContacto.Size = New System.Drawing.Size(467, 138)
        Me.gpbCargosContacto.TabIndex = 8
        Me.gpbCargosContacto.Text = "Cargos del Contacto Seleccionado"
        '
        'grdContactoSeleccionado
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdContactoSeleccionado.DisplayLayout.Appearance = Appearance2
        Me.grdContactoSeleccionado.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdContactoSeleccionado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdContactoSeleccionado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdContactoSeleccionado.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdContactoSeleccionado.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdContactoSeleccionado.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdContactoSeleccionado.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdContactoSeleccionado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdContactoSeleccionado.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdContactoSeleccionado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdContactoSeleccionado.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdContactoSeleccionado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdContactoSeleccionado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdContactoSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdContactoSeleccionado.Location = New System.Drawing.Point(3, 16)
        Me.grdContactoSeleccionado.Name = "grdContactoSeleccionado"
        Me.grdContactoSeleccionado.Size = New System.Drawing.Size(427, 119)
        Me.grdContactoSeleccionado.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnAgregarCargos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(430, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(34, 119)
        Me.Panel3.TabIndex = 18
        '
        'btnAgregarCargos
        '
        Me.btnAgregarCargos.Image = CType(resources.GetObject("btnAgregarCargos.Image"), System.Drawing.Image)
        Me.btnAgregarCargos.Location = New System.Drawing.Point(3, 3)
        Me.btnAgregarCargos.Name = "btnAgregarCargos"
        Me.btnAgregarCargos.Size = New System.Drawing.Size(28, 28)
        Me.btnAgregarCargos.TabIndex = 10
        Me.btnAgregarCargos.UseVisualStyleBackColor = True
        '
        'gpbCorreoElectronico
        '
        Me.gpbCorreoElectronico.Controls.Add(Me.grdCorreo)
        Me.gpbCorreoElectronico.Controls.Add(Me.Panel4)
        Me.gpbCorreoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbCorreoElectronico.Location = New System.Drawing.Point(484, 292)
        Me.gpbCorreoElectronico.Name = "gpbCorreoElectronico"
        Me.gpbCorreoElectronico.Size = New System.Drawing.Size(433, 166)
        Me.gpbCorreoElectronico.TabIndex = 11
        Me.gpbCorreoElectronico.Text = "Correo Electrónico"
        '
        'grdCorreo
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCorreo.DisplayLayout.Appearance = Appearance3
        Me.grdCorreo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdCorreo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdCorreo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCorreo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCorreo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCorreo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdCorreo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdCorreo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCorreo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCorreo.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCorreo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdCorreo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCorreo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCorreo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCorreo.Location = New System.Drawing.Point(3, 48)
        Me.grdCorreo.Name = "grdCorreo"
        Me.grdCorreo.Size = New System.Drawing.Size(427, 115)
        Me.grdCorreo.TabIndex = 13
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(3, 16)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(427, 32)
        Me.Panel4.TabIndex = 20
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnAgregarEmail)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(385, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(42, 32)
        Me.Panel5.TabIndex = 0
        '
        'btnAgregarEmail
        '
        Me.btnAgregarEmail.Image = CType(resources.GetObject("btnAgregarEmail.Image"), System.Drawing.Image)
        Me.btnAgregarEmail.Location = New System.Drawing.Point(7, 1)
        Me.btnAgregarEmail.Name = "btnAgregarEmail"
        Me.btnAgregarEmail.Size = New System.Drawing.Size(28, 28)
        Me.btnAgregarEmail.TabIndex = 12
        Me.btnAgregarEmail.UseVisualStyleBackColor = True
        '
        'gpbTelefonos
        '
        Me.gpbTelefonos.Controls.Add(Me.grdTelefono)
        Me.gpbTelefonos.Controls.Add(Me.Panel1)
        Me.gpbTelefonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbTelefonos.Location = New System.Drawing.Point(484, 97)
        Me.gpbTelefonos.Name = "gpbTelefonos"
        Me.gpbTelefonos.Size = New System.Drawing.Size(433, 189)
        Me.gpbTelefonos.TabIndex = 5
        Me.gpbTelefonos.Text = "Télefonos"
        '
        'grdTelefono
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTelefono.DisplayLayout.Appearance = Appearance4
        Me.grdTelefono.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdTelefono.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdTelefono.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTelefono.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTelefono.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTelefono.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdTelefono.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.grdTelefono.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTelefono.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdTelefono.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTelefono.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdTelefono.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTelefono.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTelefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTelefono.Location = New System.Drawing.Point(3, 48)
        Me.grdTelefono.Name = "grdTelefono"
        Me.grdTelefono.Size = New System.Drawing.Size(427, 138)
        Me.grdTelefono.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(427, 32)
        Me.Panel1.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnAgregarTelefono)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(385, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(42, 32)
        Me.Panel2.TabIndex = 17
        '
        'btnAgregarTelefono
        '
        Me.btnAgregarTelefono.Image = CType(resources.GetObject("btnAgregarTelefono.Image"), System.Drawing.Image)
        Me.btnAgregarTelefono.Location = New System.Drawing.Point(9, 2)
        Me.btnAgregarTelefono.Name = "btnAgregarTelefono"
        Me.btnAgregarTelefono.Size = New System.Drawing.Size(28, 28)
        Me.btnAgregarTelefono.TabIndex = 6
        Me.btnAgregarTelefono.UseVisualStyleBackColor = True
        '
        'chkVerTodo
        '
        Me.chkVerTodo.AutoSize = True
        Me.chkVerTodo.Location = New System.Drawing.Point(490, 77)
        Me.chkVerTodo.Name = "chkVerTodo"
        Me.chkVerTodo.Size = New System.Drawing.Size(70, 17)
        Me.chkVerTodo.TabIndex = 4
        Me.chkVerTodo.Text = "Ver Todo"
        Me.chkVerTodo.UseVisualStyleBackColor = True
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.lblCliente)
        Me.UltraPanel1.Location = New System.Drawing.Point(557, 74)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(360, 25)
        Me.UltraPanel1.TabIndex = 26
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblCliente.Location = New System.Drawing.Point(360, 0)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(0, 15)
        Me.lblCliente.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(348, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'InformacionDeContactoYReferenciasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(928, 524)
        Me.Controls.Add(Me.gpbTelefonos)
        Me.Controls.Add(Me.gpbCorreoElectronico)
        Me.Controls.Add(Me.gpbCargosContacto)
        Me.Controls.Add(Me.gpbContactosReferenciasComerciales)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.chkVerTodo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InformacionDeContactoYReferenciasForm"
        Me.Text = "Información de Contactos y Referencias"
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlBtnAltas.ResumeLayout(False)
        Me.pnlBtnAltas.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.gpbContactosReferenciasComerciales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbContactosReferenciasComerciales.ResumeLayout(False)
        CType(Me.grdReferenciasComerciales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpbCargosContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbCargosContacto.ResumeLayout(False)
        CType(Me.grdContactoSeleccionado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.gpbCorreoElectronico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbCorreoElectronico.ResumeLayout(False)
        CType(Me.grdCorreo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.gpbTelefonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbTelefonos.ResumeLayout(False)
        CType(Me.grdTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlBtnAltas As System.Windows.Forms.Panel
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents gpbContactosReferenciasComerciales As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents gpbCargosContacto As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnAgregarCargos As System.Windows.Forms.Button
    Friend WithEvents gpbCorreoElectronico As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnAgregarEmail As System.Windows.Forms.Button
    Friend WithEvents gpbTelefonos As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnAgregarTelefono As System.Windows.Forms.Button
    Friend WithEvents chkVerTodo As System.Windows.Forms.CheckBox
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents grdReferenciasComerciales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdContactoSeleccionado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdCorreo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdTelefono As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
