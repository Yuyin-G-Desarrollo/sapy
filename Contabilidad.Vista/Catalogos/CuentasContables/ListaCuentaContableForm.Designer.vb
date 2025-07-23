<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaCuentaContableForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaCuentaContableForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.gridListaCuentaContable = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.onlSize = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.gboxFiltros = New System.Windows.Forms.GroupBox()
        Me.pnlFiltrosDinamicos = New System.Windows.Forms.Panel()
        Me.pnlCliente = New System.Windows.Forms.Panel()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.btnCliente = New System.Windows.Forms.Button()
        Me.cboxCliente = New System.Windows.Forms.ComboBox()
        Me.pnlProveedor = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnProveedor = New System.Windows.Forms.Button()
        Me.cboxProveedor = New System.Windows.Forms.ComboBox()
        Me.cboxTipoCuenta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboxRazonSocial = New System.Windows.Forms.ComboBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAltaEstados = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.pnlContenedor.SuspendLayout()
        CType(Me.gridListaCuentaContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.onlSize.SuspendLayout()
        Me.gboxFiltros.SuspendLayout()
        Me.pnlFiltrosDinamicos.SuspendLayout()
        Me.pnlCliente.SuspendLayout()
        Me.pnlProveedor.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.gridListaCuentaContable)
        Me.pnlContenedor.Controls.Add(Me.pnlFiltros)
        Me.pnlContenedor.Controls.Add(Me.pnlPie)
        Me.pnlContenedor.Controls.Add(Me.pnlListaPaises)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1194, 609)
        Me.pnlContenedor.TabIndex = 3
        '
        'gridListaCuentaContable
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCuentaContable.DisplayLayout.Appearance = Appearance1
        Me.gridListaCuentaContable.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaCuentaContable.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCuentaContable.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCuentaContable.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCuentaContable.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCuentaContable.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCuentaContable.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCuentaContable.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCuentaContable.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCuentaContable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCuentaContable.Location = New System.Drawing.Point(0, 179)
        Me.gridListaCuentaContable.Name = "gridListaCuentaContable"
        Me.gridListaCuentaContable.Size = New System.Drawing.Size(1194, 359)
        Me.gridListaCuentaContable.TabIndex = 1
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Controls.Add(Me.onlSize)
        Me.pnlFiltros.Controls.Add(Me.gboxFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 60)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1194, 119)
        Me.pnlFiltros.TabIndex = 15
        '
        'onlSize
        '
        Me.onlSize.Controls.Add(Me.btnArriba)
        Me.onlSize.Controls.Add(Me.btnAbajo)
        Me.onlSize.Controls.Add(Me.btnMostrar)
        Me.onlSize.Controls.Add(Me.lblBuscar)
        Me.onlSize.Controls.Add(Me.btnLimpiar)
        Me.onlSize.Controls.Add(Me.lblLimpiar)
        Me.onlSize.Dock = System.Windows.Forms.DockStyle.Right
        Me.onlSize.Location = New System.Drawing.Point(1084, 0)
        Me.onlSize.Name = "onlSize"
        Me.onlSize.Size = New System.Drawing.Size(110, 119)
        Me.onlSize.TabIndex = 24
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(51, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 22
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(78, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 23
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(8, 62)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 5
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(3, 96)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(57, 62)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(54, 97)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'gboxFiltros
        '
        Me.gboxFiltros.Controls.Add(Me.pnlFiltrosDinamicos)
        Me.gboxFiltros.Controls.Add(Me.cboxTipoCuenta)
        Me.gboxFiltros.Controls.Add(Me.Label2)
        Me.gboxFiltros.Controls.Add(Me.cboxRazonSocial)
        Me.gboxFiltros.Controls.Add(Me.lblRazonSocial)
        Me.gboxFiltros.Location = New System.Drawing.Point(12, 27)
        Me.gboxFiltros.Name = "gboxFiltros"
        Me.gboxFiltros.Size = New System.Drawing.Size(1045, 85)
        Me.gboxFiltros.TabIndex = 13
        Me.gboxFiltros.TabStop = False
        '
        'pnlFiltrosDinamicos
        '
        Me.pnlFiltrosDinamicos.Controls.Add(Me.pnlCliente)
        Me.pnlFiltrosDinamicos.Controls.Add(Me.pnlProveedor)
        Me.pnlFiltrosDinamicos.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlFiltrosDinamicos.Location = New System.Drawing.Point(542, 16)
        Me.pnlFiltrosDinamicos.Name = "pnlFiltrosDinamicos"
        Me.pnlFiltrosDinamicos.Size = New System.Drawing.Size(500, 66)
        Me.pnlFiltrosDinamicos.TabIndex = 57
        '
        'pnlCliente
        '
        Me.pnlCliente.Controls.Add(Me.lblBanco)
        Me.pnlCliente.Controls.Add(Me.btnCliente)
        Me.pnlCliente.Controls.Add(Me.cboxCliente)
        Me.pnlCliente.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCliente.Location = New System.Drawing.Point(0, 28)
        Me.pnlCliente.Name = "pnlCliente"
        Me.pnlCliente.Size = New System.Drawing.Size(500, 35)
        Me.pnlCliente.TabIndex = 58
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.ForeColor = System.Drawing.Color.Black
        Me.lblBanco.Location = New System.Drawing.Point(12, 7)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(39, 13)
        Me.lblBanco.TabIndex = 21
        Me.lblBanco.Text = "Cliente"
        '
        'btnCliente
        '
        Me.btnCliente.Image = Global.Contabilidad.Vista.My.Resources.Resources.mostrarMas
        Me.btnCliente.Location = New System.Drawing.Point(467, 3)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(22, 22)
        Me.btnCliente.TabIndex = 54
        Me.btnCliente.UseVisualStyleBackColor = True
        '
        'cboxCliente
        '
        Me.cboxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboxCliente.FormattingEnabled = True
        Me.cboxCliente.Location = New System.Drawing.Point(74, 3)
        Me.cboxCliente.Name = "cboxCliente"
        Me.cboxCliente.Size = New System.Drawing.Size(387, 21)
        Me.cboxCliente.TabIndex = 55
        '
        'pnlProveedor
        '
        Me.pnlProveedor.Controls.Add(Me.Label3)
        Me.pnlProveedor.Controls.Add(Me.btnProveedor)
        Me.pnlProveedor.Controls.Add(Me.cboxProveedor)
        Me.pnlProveedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProveedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlProveedor.Name = "pnlProveedor"
        Me.pnlProveedor.Size = New System.Drawing.Size(500, 28)
        Me.pnlProveedor.TabIndex = 57
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Proveedor"
        '
        'btnProveedor
        '
        Me.btnProveedor.Image = Global.Contabilidad.Vista.My.Resources.Resources.mostrarMas
        Me.btnProveedor.Location = New System.Drawing.Point(467, 1)
        Me.btnProveedor.Name = "btnProveedor"
        Me.btnProveedor.Size = New System.Drawing.Size(22, 22)
        Me.btnProveedor.TabIndex = 52
        Me.btnProveedor.UseVisualStyleBackColor = True
        '
        'cboxProveedor
        '
        Me.cboxProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboxProveedor.FormattingEnabled = True
        Me.cboxProveedor.Location = New System.Drawing.Point(74, 2)
        Me.cboxProveedor.Name = "cboxProveedor"
        Me.cboxProveedor.Size = New System.Drawing.Size(387, 21)
        Me.cboxProveedor.TabIndex = 56
        '
        'cboxTipoCuenta
        '
        Me.cboxTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxTipoCuenta.FormattingEnabled = True
        Me.cboxTipoCuenta.Location = New System.Drawing.Point(100, 48)
        Me.cboxTipoCuenta.Name = "cboxTipoCuenta"
        Me.cboxTipoCuenta.Size = New System.Drawing.Size(415, 21)
        Me.cboxTipoCuenta.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(24, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Tipo Cuenta"
        '
        'cboxRazonSocial
        '
        Me.cboxRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxRazonSocial.FormattingEnabled = True
        Me.cboxRazonSocial.Location = New System.Drawing.Point(100, 18)
        Me.cboxRazonSocial.Name = "cboxRazonSocial"
        Me.cboxRazonSocial.Size = New System.Drawing.Size(415, 21)
        Me.cboxRazonSocial.TabIndex = 18
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.lblRazonSocial.Location = New System.Drawing.Point(24, 21)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 20
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 538)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1194, 71)
        Me.pnlPie.TabIndex = 14
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.BackColor = System.Drawing.Color.White
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1009, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(185, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(131, 11)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(129, 45)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblExportar)
        Me.pnlListaPaises.Controls.Add(Me.btnExportar)
        Me.pnlListaPaises.Controls.Add(Me.Panel2)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaEstados)
        Me.pnlListaPaises.Controls.Add(Me.btnEditar)
        Me.pnlListaPaises.Controls.Add(Me.btnAlta)
        Me.pnlListaPaises.Controls.Add(Me.imgLogo)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1194, 60)
        Me.pnlListaPaises.TabIndex = 8
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(110, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 14
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Contabilidad.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(112, 9)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 13
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(673, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(451, 60)
        Me.Panel2.TabIndex = 12
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblEncabezado)
        Me.Panel3.Location = New System.Drawing.Point(3, 23)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(442, 34)
        Me.Panel3.TabIndex = 13
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(191, 0)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(251, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Listado de Cuentas Contables"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(61, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 11
        Me.lblEditar.Text = "Editar"
        '
        'lblAltaEstados
        '
        Me.lblAltaEstados.AutoSize = True
        Me.lblAltaEstados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaEstados.Location = New System.Drawing.Point(14, 42)
        Me.lblAltaEstados.Name = "lblAltaEstados"
        Me.lblAltaEstados.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaEstados.TabIndex = 10
        Me.lblAltaEstados.Text = "Altas"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Contabilidad.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(62, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 9
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(12, 9)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(31, 32)
        Me.btnAlta.TabIndex = 8
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(1124, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 7
        Me.imgLogo.TabStop = False
        '
        'ListaCuentaContableForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 609)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaCuentaContableForm"
        Me.pnlContenedor.ResumeLayout(False)
        CType(Me.gridListaCuentaContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.onlSize.ResumeLayout(False)
        Me.onlSize.PerformLayout()
        Me.gboxFiltros.ResumeLayout(False)
        Me.gboxFiltros.PerformLayout()
        Me.pnlFiltrosDinamicos.ResumeLayout(False)
        Me.pnlCliente.ResumeLayout(False)
        Me.pnlCliente.PerformLayout()
        Me.pnlProveedor.ResumeLayout(False)
        Me.pnlProveedor.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents gboxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents cboxRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltaEstados As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents cboxTipoCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCliente As System.Windows.Forms.Button
    Friend WithEvents btnProveedor As System.Windows.Forms.Button
    Friend WithEvents cboxProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents cboxCliente As System.Windows.Forms.ComboBox
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents gridListaCuentaContable As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents onlSize As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlFiltrosDinamicos As System.Windows.Forms.Panel
    Friend WithEvents pnlCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlProveedor As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
