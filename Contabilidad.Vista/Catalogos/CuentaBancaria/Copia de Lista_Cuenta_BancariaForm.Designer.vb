<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lista_Cuenta_BancariaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lista_Cuenta_BancariaForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.gboxContenido = New System.Windows.Forms.GroupBox()
        Me.gridListaCuentaBancaria = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxFiltros = New System.Windows.Forms.GroupBox()
        Me.pnlBotonesMostrar = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.cboxBanco = New System.Windows.Forms.ComboBox()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.cboxRazonSocial = New System.Windows.Forms.ComboBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlEtiquetaEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.lblAltaEstados = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlContenedor.SuspendLayout()
        Me.gboxContenido.SuspendLayout()
        CType(Me.gridListaCuentaBancaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxFiltros.SuspendLayout()
        Me.pnlBotonesMostrar.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlEtiquetaEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.gboxContenido)
        Me.pnlContenedor.Controls.Add(Me.gboxFiltros)
        Me.pnlContenedor.Controls.Add(Me.pnlListaPaises)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1194, 507)
        Me.pnlContenedor.TabIndex = 2
        '
        'gboxContenido
        '
        Me.gboxContenido.Controls.Add(Me.gridListaCuentaBancaria)
        Me.gboxContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxContenido.Location = New System.Drawing.Point(0, 144)
        Me.gboxContenido.Name = "gboxContenido"
        Me.gboxContenido.Size = New System.Drawing.Size(1194, 363)
        Me.gboxContenido.TabIndex = 12
        Me.gboxContenido.TabStop = False
        '
        'gridListaCuentaBancaria
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCuentaBancaria.DisplayLayout.Appearance = Appearance1
        Me.gridListaCuentaBancaria.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaCuentaBancaria.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCuentaBancaria.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCuentaBancaria.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCuentaBancaria.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCuentaBancaria.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCuentaBancaria.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCuentaBancaria.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCuentaBancaria.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCuentaBancaria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCuentaBancaria.Location = New System.Drawing.Point(3, 16)
        Me.gridListaCuentaBancaria.Name = "gridListaCuentaBancaria"
        Me.gridListaCuentaBancaria.Size = New System.Drawing.Size(1188, 344)
        Me.gridListaCuentaBancaria.TabIndex = 1
        '
        'gboxFiltros
        '
        Me.gboxFiltros.Controls.Add(Me.pnlBotonesMostrar)
        Me.gboxFiltros.Controls.Add(Me.cboxBanco)
        Me.gboxFiltros.Controls.Add(Me.lblBanco)
        Me.gboxFiltros.Controls.Add(Me.cboxRazonSocial)
        Me.gboxFiltros.Controls.Add(Me.lblRazonSocial)
        Me.gboxFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.gboxFiltros.Location = New System.Drawing.Point(0, 60)
        Me.gboxFiltros.Name = "gboxFiltros"
        Me.gboxFiltros.Size = New System.Drawing.Size(1194, 84)
        Me.gboxFiltros.TabIndex = 13
        Me.gboxFiltros.TabStop = False
        '
        'pnlBotonesMostrar
        '
        Me.pnlBotonesMostrar.Controls.Add(Me.lblLimpiar)
        Me.pnlBotonesMostrar.Controls.Add(Me.lblBuscar)
        Me.pnlBotonesMostrar.Controls.Add(Me.btnLimpiar)
        Me.pnlBotonesMostrar.Controls.Add(Me.btnMostrar)
        Me.pnlBotonesMostrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesMostrar.Location = New System.Drawing.Point(1020, 16)
        Me.pnlBotonesMostrar.Name = "pnlBotonesMostrar"
        Me.pnlBotonesMostrar.Size = New System.Drawing.Size(171, 65)
        Me.pnlBotonesMostrar.TabIndex = 22
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(114, 41)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 12
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(65, 41)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 11
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(117, 7)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 10
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(70, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 9
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'cboxBanco
        '
        Me.cboxBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxBanco.FormattingEnabled = True
        Me.cboxBanco.Location = New System.Drawing.Point(90, 48)
        Me.cboxBanco.Name = "cboxBanco"
        Me.cboxBanco.Size = New System.Drawing.Size(477, 21)
        Me.cboxBanco.TabIndex = 19
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.ForeColor = System.Drawing.Color.Black
        Me.lblBanco.Location = New System.Drawing.Point(14, 51)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(38, 13)
        Me.lblBanco.TabIndex = 21
        Me.lblBanco.Text = "Banco"
        '
        'cboxRazonSocial
        '
        Me.cboxRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxRazonSocial.FormattingEnabled = True
        Me.cboxRazonSocial.Location = New System.Drawing.Point(90, 20)
        Me.cboxRazonSocial.Name = "cboxRazonSocial"
        Me.cboxRazonSocial.Size = New System.Drawing.Size(477, 21)
        Me.cboxRazonSocial.TabIndex = 18
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.lblRazonSocial.Location = New System.Drawing.Point(14, 23)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 20
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlEtiquetaEncabezado)
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
        'pnlEtiquetaEncabezado
        '
        Me.pnlEtiquetaEncabezado.Controls.Add(Me.lblEncabezado)
        Me.pnlEtiquetaEncabezado.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEtiquetaEncabezado.Location = New System.Drawing.Point(854, 0)
        Me.pnlEtiquetaEncabezado.Name = "pnlEtiquetaEncabezado"
        Me.pnlEtiquetaEncabezado.Size = New System.Drawing.Size(270, 60)
        Me.pnlEtiquetaEncabezado.TabIndex = 12
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(14, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(250, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Listado de Cuentas Bancarias"
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Contabilidad.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(64, 8)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 9
        Me.btnEditar.UseVisualStyleBackColor = True
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
        'btnAlta
        '
        Me.btnAlta.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(14, 8)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(31, 32)
        Me.btnAlta.TabIndex = 8
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblAltaEstados
        '
        Me.lblAltaEstados.AutoSize = True
        Me.lblAltaEstados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaEstados.Location = New System.Drawing.Point(16, 41)
        Me.lblAltaEstados.Name = "lblAltaEstados"
        Me.lblAltaEstados.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaEstados.TabIndex = 10
        Me.lblAltaEstados.Text = "Altas"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(63, 41)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 11
        Me.lblEditar.Text = "Editar"
        '
        'Lista_Cuenta_BancariaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 507)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Lista_Cuenta_BancariaForm"
        Me.pnlContenedor.ResumeLayout(False)
        Me.gboxContenido.ResumeLayout(False)
        CType(Me.gridListaCuentaBancaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxFiltros.ResumeLayout(False)
        Me.gboxFiltros.PerformLayout()
        Me.pnlBotonesMostrar.ResumeLayout(False)
        Me.pnlBotonesMostrar.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlEtiquetaEncabezado.ResumeLayout(False)
        Me.pnlEtiquetaEncabezado.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents gboxContenido As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaCuentaBancaria As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents gboxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents cboxBanco As System.Windows.Forms.ComboBox
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents cboxRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents pnlBotonesMostrar As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents pnlEtiquetaEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltaEstados As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
End Class
