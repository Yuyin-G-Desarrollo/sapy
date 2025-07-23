<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaCuentaGeneralForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaCuentaGeneralForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.gridListaCuentaGeneral = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.onlSize = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.gboxFiltros = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.cmbTipoCuenta = New System.Windows.Forms.ComboBox()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rdoFolioAproximado = New System.Windows.Forms.RadioButton()
        Me.rdoFolioExacto = New System.Windows.Forms.RadioButton()
        Me.cmbTipoPoliza = New System.Windows.Forms.ComboBox()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.lblTipoPoliza = New System.Windows.Forms.Label()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAltaEstados = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        CType(Me.gridListaCuentaGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.onlSize.SuspendLayout()
        Me.gboxFiltros.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.gridListaCuentaGeneral)
        Me.pnlContenedor.Controls.Add(Me.pnlPie)
        Me.pnlContenedor.Controls.Add(Me.pnlFiltros)
        Me.pnlContenedor.Controls.Add(Me.pnlListaPaises)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1194, 609)
        Me.pnlContenedor.TabIndex = 4
        '
        'gridListaCuentaGeneral
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCuentaGeneral.DisplayLayout.Appearance = Appearance1
        Me.gridListaCuentaGeneral.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaCuentaGeneral.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCuentaGeneral.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCuentaGeneral.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCuentaGeneral.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCuentaGeneral.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCuentaGeneral.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCuentaGeneral.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCuentaGeneral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCuentaGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCuentaGeneral.Location = New System.Drawing.Point(0, 176)
        Me.gridListaCuentaGeneral.Name = "gridListaCuentaGeneral"
        Me.gridListaCuentaGeneral.Size = New System.Drawing.Size(1194, 362)
        Me.gridListaCuentaGeneral.TabIndex = 13
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 538)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1194, 71)
        Me.pnlPie.TabIndex = 19
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
        Me.btnCancelar.TabIndex = 14
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
        'pnlFiltros
        '
        Me.pnlFiltros.Controls.Add(Me.onlSize)
        Me.pnlFiltros.Controls.Add(Me.gboxFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 60)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1194, 116)
        Me.pnlFiltros.TabIndex = 17
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
        Me.onlSize.Size = New System.Drawing.Size(110, 116)
        Me.onlSize.TabIndex = 24
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(51, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 3
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(78, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 4
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(8, 62)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 11
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(4, 96)
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
        Me.btnLimpiar.TabIndex = 12
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(55, 97)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'gboxFiltros
        '
        Me.gboxFiltros.Controls.Add(Me.Panel3)
        Me.gboxFiltros.Controls.Add(Me.cmbTipoPoliza)
        Me.gboxFiltros.Controls.Add(Me.cmbRazonSocial)
        Me.gboxFiltros.Controls.Add(Me.lblTipoPoliza)
        Me.gboxFiltros.Controls.Add(Me.lblRazonSocial)
        Me.gboxFiltros.Location = New System.Drawing.Point(12, 27)
        Me.gboxFiltros.Name = "gboxFiltros"
        Me.gboxFiltros.Size = New System.Drawing.Size(1045, 82)
        Me.gboxFiltros.TabIndex = 13
        Me.gboxFiltros.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtCuenta)
        Me.Panel3.Controls.Add(Me.cmbTipoCuenta)
        Me.Panel3.Controls.Add(Me.lblCuenta)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.rdoFolioAproximado)
        Me.Panel3.Controls.Add(Me.rdoFolioExacto)
        Me.Panel3.Location = New System.Drawing.Point(531, 9)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(508, 67)
        Me.Panel3.TabIndex = 61
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(82, 39)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(162, 20)
        Me.txtCuenta.TabIndex = 8
        '
        'cmbTipoCuenta
        '
        Me.cmbTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCuenta.FormattingEnabled = True
        Me.cmbTipoCuenta.Location = New System.Drawing.Point(82, 9)
        Me.cmbTipoCuenta.Name = "cmbTipoCuenta"
        Me.cmbTipoCuenta.Size = New System.Drawing.Size(415, 21)
        Me.cmbTipoCuenta.TabIndex = 6
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.Location = New System.Drawing.Point(3, 42)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(41, 13)
        Me.lblCuenta.TabIndex = 25
        Me.lblCuenta.Text = "Cuenta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Tipo Cuenta"
        '
        'rdoFolioAproximado
        '
        Me.rdoFolioAproximado.AutoSize = True
        Me.rdoFolioAproximado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFolioAproximado.Location = New System.Drawing.Point(380, 40)
        Me.rdoFolioAproximado.Name = "rdoFolioAproximado"
        Me.rdoFolioAproximado.Size = New System.Drawing.Size(117, 17)
        Me.rdoFolioAproximado.TabIndex = 10
        Me.rdoFolioAproximado.Text = "Cuenta Aproximada"
        Me.rdoFolioAproximado.UseVisualStyleBackColor = True
        '
        'rdoFolioExacto
        '
        Me.rdoFolioExacto.AutoSize = True
        Me.rdoFolioExacto.Checked = True
        Me.rdoFolioExacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoFolioExacto.Location = New System.Drawing.Point(263, 40)
        Me.rdoFolioExacto.Name = "rdoFolioExacto"
        Me.rdoFolioExacto.Size = New System.Drawing.Size(95, 17)
        Me.rdoFolioExacto.TabIndex = 9
        Me.rdoFolioExacto.TabStop = True
        Me.rdoFolioExacto.Text = "Cuenta Exacta"
        Me.rdoFolioExacto.UseVisualStyleBackColor = True
        '
        'cmbTipoPoliza
        '
        Me.cmbTipoPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPoliza.FormattingEnabled = True
        Me.cmbTipoPoliza.Location = New System.Drawing.Point(96, 48)
        Me.cmbTipoPoliza.Name = "cmbTipoPoliza"
        Me.cmbTipoPoliza.Size = New System.Drawing.Size(391, 21)
        Me.cmbTipoPoliza.TabIndex = 7
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Location = New System.Drawing.Point(96, 18)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(391, 21)
        Me.cmbRazonSocial.TabIndex = 5
        '
        'lblTipoPoliza
        '
        Me.lblTipoPoliza.AutoSize = True
        Me.lblTipoPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPoliza.Location = New System.Drawing.Point(18, 51)
        Me.lblTipoPoliza.Name = "lblTipoPoliza"
        Me.lblTipoPoliza.Size = New System.Drawing.Size(73, 13)
        Me.lblTipoPoliza.TabIndex = 60
        Me.lblTipoPoliza.Text = "Tipo de póliza"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.lblRazonSocial.Location = New System.Drawing.Point(20, 21)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 20
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(721, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(403, 60)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEncabezado)
        Me.Panel2.Location = New System.Drawing.Point(52, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(345, 37)
        Me.Panel2.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(89, 0)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(253, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Listado de Cuentas Generales"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(66, 42)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 11
        Me.lblEditar.Text = "Editar"
        '
        'lblAltaEstados
        '
        Me.lblAltaEstados.AutoSize = True
        Me.lblAltaEstados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaEstados.Location = New System.Drawing.Point(19, 42)
        Me.lblAltaEstados.Name = "lblAltaEstados"
        Me.lblAltaEstados.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaEstados.TabIndex = 10
        Me.lblAltaEstados.Text = "Altas"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Contabilidad.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(67, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(17, 9)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(31, 32)
        Me.btnAlta.TabIndex = 1
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
        'ListaCuentaGeneralForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 609)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaCuentaGeneralForm"
        Me.Text = "Listado de Cuentas Generales"
        Me.pnlContenedor.ResumeLayout(False)
        CType(Me.gridListaCuentaGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.onlSize.ResumeLayout(False)
        Me.onlSize.PerformLayout()
        Me.gboxFiltros.ResumeLayout(False)
        Me.gboxFiltros.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltaEstados As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents gridListaCuentaGeneral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents onlSize As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents gboxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoPoliza As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoPoliza As System.Windows.Forms.Label
    Friend WithEvents cmbRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdoFolioAproximado As System.Windows.Forms.RadioButton
    Friend WithEvents rdoFolioExacto As System.Windows.Forms.RadioButton
End Class
