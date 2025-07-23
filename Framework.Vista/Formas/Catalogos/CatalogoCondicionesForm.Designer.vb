<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoCondicionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoCondicionesForm))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pnlAreaOperativa = New System.Windows.Forms.Panel()
        Me.pnlAltaPolitica = New System.Windows.Forms.Panel()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnGuardarAreaOperativa = New System.Windows.Forms.Button()
        Me.grdAreaOperativa = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCondicionCatalogo = New System.Windows.Forms.Label()
        Me.lblPolitica = New System.Windows.Forms.Label()
        Me.lblTipoPolitica = New System.Windows.Forms.Label()
        Me.pnlCondicionCatalogo = New System.Windows.Forms.Panel()
        Me.grdCatalogoCondicion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardarPolitica = New System.Windows.Forms.Button()
        Me.pnlAccionesCondicionCatalogo = New System.Windows.Forms.Panel()
        Me.lblEditarCondicionCatalogo = New System.Windows.Forms.Label()
        Me.btnEditarCondicionCatalogo = New System.Windows.Forms.Button()
        Me.btnAltaCondicionCatalogo = New System.Windows.Forms.Button()
        Me.lblAltaCondicionCatalogo = New System.Windows.Forms.Label()
        Me.pnlCondicion = New System.Windows.Forms.Panel()
        Me.grdCondicion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlAccionesCondicion = New System.Windows.Forms.Panel()
        Me.lblEditarCondicion = New System.Windows.Forms.Label()
        Me.btnEditarCondicion = New System.Windows.Forms.Button()
        Me.btnAltaCondicion = New System.Windows.Forms.Button()
        Me.lblAltaCondicion = New System.Windows.Forms.Label()
        Me.pnlTipoPolitica = New System.Windows.Forms.Panel()
        Me.grdTipoCondicion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlAccionesTipoPolitica = New System.Windows.Forms.Panel()
        Me.EditarTipo = New System.Windows.Forms.Label()
        Me.btnEditarTipo = New System.Windows.Forms.Button()
        Me.btnAltaTipo = New System.Windows.Forms.Button()
        Me.lblAltaTipo = New System.Windows.Forms.Label()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grpPoliticasActuales = New System.Windows.Forms.GroupBox()
        Me.pnlPoliticasActuales = New System.Windows.Forms.Panel()
        Me.grdListaCatalogoCondiciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grpParametros.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlAreaOperativa.SuspendLayout()
        Me.pnlAltaPolitica.SuspendLayout()
        CType(Me.grdAreaOperativa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlCondicionCatalogo.SuspendLayout()
        CType(Me.grdCatalogoCondicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlAccionesCondicionCatalogo.SuspendLayout()
        Me.pnlCondicion.SuspendLayout()
        CType(Me.grdCondicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAccionesCondicion.SuspendLayout()
        Me.pnlTipoPolitica.SuspendLayout()
        CType(Me.grdTipoCondicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAccionesTipoPolitica.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grpPoliticasActuales.SuspendLayout()
        Me.pnlPoliticasActuales.SuspendLayout()
        CType(Me.grdListaCatalogoCondiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpParametros
        '
        Me.grpParametros.BackColor = System.Drawing.Color.Transparent
        Me.grpParametros.Controls.Add(Me.GroupBox2)
        Me.grpParametros.Controls.Add(Me.GroupBox1)
        Me.grpParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grpParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpParametros.Location = New System.Drawing.Point(0, 53)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(1241, 285)
        Me.grpParametros.TabIndex = 14
        Me.grpParametros.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pnlAreaOperativa)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.InfoText
        Me.GroupBox2.Location = New System.Drawing.Point(792, 43)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(439, 235)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Áreas Operativas"
        '
        'pnlAreaOperativa
        '
        Me.pnlAreaOperativa.Controls.Add(Me.pnlAltaPolitica)
        Me.pnlAreaOperativa.Controls.Add(Me.grdAreaOperativa)
        Me.pnlAreaOperativa.Location = New System.Drawing.Point(6, 19)
        Me.pnlAreaOperativa.Name = "pnlAreaOperativa"
        Me.pnlAreaOperativa.Size = New System.Drawing.Size(433, 216)
        Me.pnlAreaOperativa.TabIndex = 49
        '
        'pnlAltaPolitica
        '
        Me.pnlAltaPolitica.Controls.Add(Me.lblBuscar)
        Me.pnlAltaPolitica.Controls.Add(Me.btnGuardarAreaOperativa)
        Me.pnlAltaPolitica.Location = New System.Drawing.Point(385, 165)
        Me.pnlAltaPolitica.Name = "pnlAltaPolitica"
        Me.pnlAltaPolitica.Size = New System.Drawing.Size(45, 53)
        Me.pnlAltaPolitica.TabIndex = 57
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblBuscar.Location = New System.Drawing.Point(0, 37)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 25
        Me.lblBuscar.Text = "Guardar"
        '
        'btnGuardarAreaOperativa
        '
        Me.btnGuardarAreaOperativa.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarAreaOperativa.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarAreaOperativa.Location = New System.Drawing.Point(5, 2)
        Me.btnGuardarAreaOperativa.Name = "btnGuardarAreaOperativa"
        Me.btnGuardarAreaOperativa.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarAreaOperativa.TabIndex = 14
        Me.btnGuardarAreaOperativa.UseVisualStyleBackColor = True
        '
        'grdAreaOperativa
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAreaOperativa.DisplayLayout.Appearance = Appearance1
        Me.grdAreaOperativa.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdAreaOperativa.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAreaOperativa.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdAreaOperativa.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdAreaOperativa.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAreaOperativa.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAreaOperativa.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAreaOperativa.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAreaOperativa.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAreaOperativa.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAreaOperativa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAreaOperativa.Location = New System.Drawing.Point(0, 1)
        Me.grdAreaOperativa.Name = "grdAreaOperativa"
        Me.grdAreaOperativa.Size = New System.Drawing.Size(384, 216)
        Me.grdAreaOperativa.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCondicionCatalogo)
        Me.GroupBox1.Controls.Add(Me.lblPolitica)
        Me.GroupBox1.Controls.Add(Me.lblTipoPolitica)
        Me.GroupBox1.Controls.Add(Me.pnlCondicionCatalogo)
        Me.GroupBox1.Controls.Add(Me.pnlCondicion)
        Me.GroupBox1.Controls.Add(Me.pnlTipoPolitica)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(6, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 235)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Políticas"
        '
        'lblCondicionCatalogo
        '
        Me.lblCondicionCatalogo.AutoSize = True
        Me.lblCondicionCatalogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondicionCatalogo.ForeColor = System.Drawing.Color.Black
        Me.lblCondicionCatalogo.Location = New System.Drawing.Point(495, 14)
        Me.lblCondicionCatalogo.Name = "lblCondicionCatalogo"
        Me.lblCondicionCatalogo.Size = New System.Drawing.Size(126, 13)
        Me.lblCondicionCatalogo.TabIndex = 62
        Me.lblCondicionCatalogo.Text = "3. Catálogo de la Política"
        '
        'lblPolitica
        '
        Me.lblPolitica.AutoSize = True
        Me.lblPolitica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPolitica.ForeColor = System.Drawing.Color.Black
        Me.lblPolitica.Location = New System.Drawing.Point(235, 14)
        Me.lblPolitica.Name = "lblPolitica"
        Me.lblPolitica.Size = New System.Drawing.Size(55, 13)
        Me.lblPolitica.TabIndex = 61
        Me.lblPolitica.Text = "2. Política"
        '
        'lblTipoPolitica
        '
        Me.lblTipoPolitica.AutoSize = True
        Me.lblTipoPolitica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoPolitica.ForeColor = System.Drawing.Color.Black
        Me.lblTipoPolitica.Location = New System.Drawing.Point(4, 14)
        Me.lblTipoPolitica.Name = "lblTipoPolitica"
        Me.lblTipoPolitica.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoPolitica.TabIndex = 60
        Me.lblTipoPolitica.Text = "1. Tipo de Política"
        '
        'pnlCondicionCatalogo
        '
        Me.pnlCondicionCatalogo.Controls.Add(Me.grdCatalogoCondicion)
        Me.pnlCondicionCatalogo.Controls.Add(Me.Panel1)
        Me.pnlCondicionCatalogo.Controls.Add(Me.pnlAccionesCondicionCatalogo)
        Me.pnlCondicionCatalogo.Location = New System.Drawing.Point(498, 29)
        Me.pnlCondicionCatalogo.Name = "pnlCondicionCatalogo"
        Me.pnlCondicionCatalogo.Size = New System.Drawing.Size(270, 206)
        Me.pnlCondicionCatalogo.TabIndex = 59
        '
        'grdCatalogoCondicion
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCatalogoCondicion.DisplayLayout.Appearance = Appearance2
        Me.grdCatalogoCondicion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCatalogoCondicion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCatalogoCondicion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCatalogoCondicion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCatalogoCondicion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCatalogoCondicion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCatalogoCondicion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCatalogoCondicion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdCatalogoCondicion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCatalogoCondicion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCatalogoCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCatalogoCondicion.Location = New System.Drawing.Point(0, 0)
        Me.grdCatalogoCondicion.Name = "grdCatalogoCondicion"
        Me.grdCatalogoCondicion.Size = New System.Drawing.Size(270, 157)
        Me.grdCatalogoCondicion.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnGuardarPolitica)
        Me.Panel1.Location = New System.Drawing.Point(218, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(52, 53)
        Me.Panel1.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(7, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Guardar"
        '
        'btnGuardarPolitica
        '
        Me.btnGuardarPolitica.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarPolitica.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardarPolitica.Location = New System.Drawing.Point(10, 0)
        Me.btnGuardarPolitica.Name = "btnGuardarPolitica"
        Me.btnGuardarPolitica.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarPolitica.TabIndex = 12
        Me.btnGuardarPolitica.UseVisualStyleBackColor = True
        '
        'pnlAccionesCondicionCatalogo
        '
        Me.pnlAccionesCondicionCatalogo.Controls.Add(Me.lblEditarCondicionCatalogo)
        Me.pnlAccionesCondicionCatalogo.Controls.Add(Me.btnEditarCondicionCatalogo)
        Me.pnlAccionesCondicionCatalogo.Controls.Add(Me.btnAltaCondicionCatalogo)
        Me.pnlAccionesCondicionCatalogo.Controls.Add(Me.lblAltaCondicionCatalogo)
        Me.pnlAccionesCondicionCatalogo.Location = New System.Drawing.Point(78, 153)
        Me.pnlAccionesCondicionCatalogo.Name = "pnlAccionesCondicionCatalogo"
        Me.pnlAccionesCondicionCatalogo.Size = New System.Drawing.Size(104, 60)
        Me.pnlAccionesCondicionCatalogo.TabIndex = 50
        '
        'lblEditarCondicionCatalogo
        '
        Me.lblEditarCondicionCatalogo.AutoSize = True
        Me.lblEditarCondicionCatalogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarCondicionCatalogo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblEditarCondicionCatalogo.Location = New System.Drawing.Point(61, 39)
        Me.lblEditarCondicionCatalogo.Name = "lblEditarCondicionCatalogo"
        Me.lblEditarCondicionCatalogo.Size = New System.Drawing.Size(34, 13)
        Me.lblEditarCondicionCatalogo.TabIndex = 23
        Me.lblEditarCondicionCatalogo.Text = "Editar"
        '
        'btnEditarCondicionCatalogo
        '
        Me.btnEditarCondicionCatalogo.Image = CType(resources.GetObject("btnEditarCondicionCatalogo.Image"), System.Drawing.Image)
        Me.btnEditarCondicionCatalogo.Location = New System.Drawing.Point(60, 4)
        Me.btnEditarCondicionCatalogo.Name = "btnEditarCondicionCatalogo"
        Me.btnEditarCondicionCatalogo.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarCondicionCatalogo.TabIndex = 11
        Me.btnEditarCondicionCatalogo.UseVisualStyleBackColor = True
        '
        'btnAltaCondicionCatalogo
        '
        Me.btnAltaCondicionCatalogo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAltaCondicionCatalogo.Image = CType(resources.GetObject("btnAltaCondicionCatalogo.Image"), System.Drawing.Image)
        Me.btnAltaCondicionCatalogo.Location = New System.Drawing.Point(13, 4)
        Me.btnAltaCondicionCatalogo.Name = "btnAltaCondicionCatalogo"
        Me.btnAltaCondicionCatalogo.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaCondicionCatalogo.TabIndex = 10
        Me.btnAltaCondicionCatalogo.UseVisualStyleBackColor = True
        '
        'lblAltaCondicionCatalogo
        '
        Me.lblAltaCondicionCatalogo.AutoSize = True
        Me.lblAltaCondicionCatalogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltaCondicionCatalogo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblAltaCondicionCatalogo.Location = New System.Drawing.Point(15, 39)
        Me.lblAltaCondicionCatalogo.Name = "lblAltaCondicionCatalogo"
        Me.lblAltaCondicionCatalogo.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaCondicionCatalogo.TabIndex = 22
        Me.lblAltaCondicionCatalogo.Text = "Altas"
        '
        'pnlCondicion
        '
        Me.pnlCondicion.Controls.Add(Me.grdCondicion)
        Me.pnlCondicion.Controls.Add(Me.pnlAccionesCondicion)
        Me.pnlCondicion.Location = New System.Drawing.Point(238, 28)
        Me.pnlCondicion.Name = "pnlCondicion"
        Me.pnlCondicion.Size = New System.Drawing.Size(250, 207)
        Me.pnlCondicion.TabIndex = 58
        '
        'grdCondicion
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCondicion.DisplayLayout.Appearance = Appearance3
        Me.grdCondicion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdCondicion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdCondicion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdCondicion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCondicion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCondicion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdCondicion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCondicion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdCondicion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdCondicion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCondicion.Location = New System.Drawing.Point(0, 0)
        Me.grdCondicion.Name = "grdCondicion"
        Me.grdCondicion.Size = New System.Drawing.Size(250, 158)
        Me.grdCondicion.TabIndex = 6
        '
        'pnlAccionesCondicion
        '
        Me.pnlAccionesCondicion.Controls.Add(Me.lblEditarCondicion)
        Me.pnlAccionesCondicion.Controls.Add(Me.btnEditarCondicion)
        Me.pnlAccionesCondicion.Controls.Add(Me.btnAltaCondicion)
        Me.pnlAccionesCondicion.Controls.Add(Me.lblAltaCondicion)
        Me.pnlAccionesCondicion.Location = New System.Drawing.Point(61, 152)
        Me.pnlAccionesCondicion.Name = "pnlAccionesCondicion"
        Me.pnlAccionesCondicion.Size = New System.Drawing.Size(104, 62)
        Me.pnlAccionesCondicion.TabIndex = 50
        '
        'lblEditarCondicion
        '
        Me.lblEditarCondicion.AutoSize = True
        Me.lblEditarCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarCondicion.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblEditarCondicion.Location = New System.Drawing.Point(60, 41)
        Me.lblEditarCondicion.Name = "lblEditarCondicion"
        Me.lblEditarCondicion.Size = New System.Drawing.Size(34, 13)
        Me.lblEditarCondicion.TabIndex = 23
        Me.lblEditarCondicion.Text = "Editar"
        '
        'btnEditarCondicion
        '
        Me.btnEditarCondicion.Image = CType(resources.GetObject("btnEditarCondicion.Image"), System.Drawing.Image)
        Me.btnEditarCondicion.Location = New System.Drawing.Point(61, 6)
        Me.btnEditarCondicion.Name = "btnEditarCondicion"
        Me.btnEditarCondicion.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarCondicion.TabIndex = 8
        Me.btnEditarCondicion.UseVisualStyleBackColor = True
        '
        'btnAltaCondicion
        '
        Me.btnAltaCondicion.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAltaCondicion.Image = CType(resources.GetObject("btnAltaCondicion.Image"), System.Drawing.Image)
        Me.btnAltaCondicion.Location = New System.Drawing.Point(11, 6)
        Me.btnAltaCondicion.Name = "btnAltaCondicion"
        Me.btnAltaCondicion.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaCondicion.TabIndex = 7
        Me.btnAltaCondicion.UseVisualStyleBackColor = True
        '
        'lblAltaCondicion
        '
        Me.lblAltaCondicion.AutoSize = True
        Me.lblAltaCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltaCondicion.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblAltaCondicion.Location = New System.Drawing.Point(13, 41)
        Me.lblAltaCondicion.Name = "lblAltaCondicion"
        Me.lblAltaCondicion.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaCondicion.TabIndex = 22
        Me.lblAltaCondicion.Text = "Altas"
        '
        'pnlTipoPolitica
        '
        Me.pnlTipoPolitica.Controls.Add(Me.grdTipoCondicion)
        Me.pnlTipoPolitica.Controls.Add(Me.pnlAccionesTipoPolitica)
        Me.pnlTipoPolitica.Location = New System.Drawing.Point(6, 28)
        Me.pnlTipoPolitica.Name = "pnlTipoPolitica"
        Me.pnlTipoPolitica.Size = New System.Drawing.Size(226, 207)
        Me.pnlTipoPolitica.TabIndex = 57
        '
        'grdTipoCondicion
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTipoCondicion.DisplayLayout.Appearance = Appearance4
        Me.grdTipoCondicion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdTipoCondicion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdTipoCondicion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTipoCondicion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTipoCondicion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTipoCondicion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdTipoCondicion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTipoCondicion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdTipoCondicion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTipoCondicion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTipoCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTipoCondicion.Location = New System.Drawing.Point(0, 0)
        Me.grdTipoCondicion.Name = "grdTipoCondicion"
        Me.grdTipoCondicion.Size = New System.Drawing.Size(226, 158)
        Me.grdTipoCondicion.TabIndex = 3
        '
        'pnlAccionesTipoPolitica
        '
        Me.pnlAccionesTipoPolitica.Controls.Add(Me.EditarTipo)
        Me.pnlAccionesTipoPolitica.Controls.Add(Me.btnEditarTipo)
        Me.pnlAccionesTipoPolitica.Controls.Add(Me.btnAltaTipo)
        Me.pnlAccionesTipoPolitica.Controls.Add(Me.lblAltaTipo)
        Me.pnlAccionesTipoPolitica.Location = New System.Drawing.Point(66, 155)
        Me.pnlAccionesTipoPolitica.Name = "pnlAccionesTipoPolitica"
        Me.pnlAccionesTipoPolitica.Size = New System.Drawing.Size(103, 54)
        Me.pnlAccionesTipoPolitica.TabIndex = 49
        '
        'EditarTipo
        '
        Me.EditarTipo.AutoSize = True
        Me.EditarTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditarTipo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.EditarTipo.Location = New System.Drawing.Point(62, 38)
        Me.EditarTipo.Name = "EditarTipo"
        Me.EditarTipo.Size = New System.Drawing.Size(34, 13)
        Me.EditarTipo.TabIndex = 23
        Me.EditarTipo.Text = "Editar"
        '
        'btnEditarTipo
        '
        Me.btnEditarTipo.Image = CType(resources.GetObject("btnEditarTipo.Image"), System.Drawing.Image)
        Me.btnEditarTipo.Location = New System.Drawing.Point(61, 3)
        Me.btnEditarTipo.Name = "btnEditarTipo"
        Me.btnEditarTipo.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarTipo.TabIndex = 5
        Me.btnEditarTipo.UseVisualStyleBackColor = True
        '
        'btnAltaTipo
        '
        Me.btnAltaTipo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAltaTipo.Image = CType(resources.GetObject("btnAltaTipo.Image"), System.Drawing.Image)
        Me.btnAltaTipo.Location = New System.Drawing.Point(11, 3)
        Me.btnAltaTipo.Name = "btnAltaTipo"
        Me.btnAltaTipo.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaTipo.TabIndex = 4
        Me.btnAltaTipo.UseVisualStyleBackColor = True
        '
        'lblAltaTipo
        '
        Me.lblAltaTipo.AutoSize = True
        Me.lblAltaTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltaTipo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblAltaTipo.Location = New System.Drawing.Point(13, 38)
        Me.lblAltaTipo.Name = "lblAltaTipo"
        Me.lblAltaTipo.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaTipo.TabIndex = 22
        Me.lblAltaTipo.Text = "Altas"
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1172, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(66, 266)
        Me.pnlMinimizarParametros.TabIndex = 48
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(36, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 2
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(9, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 1
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1241, 53)
        Me.pnlHeader.TabIndex = 13
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Location = New System.Drawing.Point(822, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(419, 53)
        Me.pnlTitulo.TabIndex = 46
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(128, 16)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(217, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Configuración de Políticas"
        '
        'grpPoliticasActuales
        '
        Me.grpPoliticasActuales.BackColor = System.Drawing.Color.AliceBlue
        Me.grpPoliticasActuales.Controls.Add(Me.pnlPoliticasActuales)
        Me.grpPoliticasActuales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpPoliticasActuales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPoliticasActuales.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpPoliticasActuales.Location = New System.Drawing.Point(0, 338)
        Me.grpPoliticasActuales.Name = "grpPoliticasActuales"
        Me.grpPoliticasActuales.Size = New System.Drawing.Size(1241, 228)
        Me.grpPoliticasActuales.TabIndex = 0
        Me.grpPoliticasActuales.TabStop = False
        Me.grpPoliticasActuales.Text = "Catálogo"
        '
        'pnlPoliticasActuales
        '
        Me.pnlPoliticasActuales.Controls.Add(Me.grdListaCatalogoCondiciones)
        Me.pnlPoliticasActuales.Controls.Add(Me.pnlEstado)
        Me.pnlPoliticasActuales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPoliticasActuales.Location = New System.Drawing.Point(3, 16)
        Me.pnlPoliticasActuales.Name = "pnlPoliticasActuales"
        Me.pnlPoliticasActuales.Size = New System.Drawing.Size(1235, 209)
        Me.pnlPoliticasActuales.TabIndex = 54
        '
        'grdListaCatalogoCondiciones
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaCatalogoCondiciones.DisplayLayout.Appearance = Appearance5
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaCatalogoCondiciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaCatalogoCondiciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaCatalogoCondiciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdListaCatalogoCondiciones.Location = New System.Drawing.Point(0, 0)
        Me.grdListaCatalogoCondiciones.Name = "grdListaCatalogoCondiciones"
        Me.grdListaCatalogoCondiciones.Size = New System.Drawing.Size(1235, 149)
        Me.grdListaCatalogoCondiciones.TabIndex = 15
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 149)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1235, 60)
        Me.pnlEstado.TabIndex = 70
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1083, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(152, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(93, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(93, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(351, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'CatalogoCondicionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 566)
        Me.Controls.Add(Me.grpPoliticasActuales)
        Me.Controls.Add(Me.grpParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1257, 605)
        Me.Name = "CatalogoCondicionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Configuración de Políticas"
        Me.grpParametros.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlAreaOperativa.ResumeLayout(False)
        Me.pnlAltaPolitica.ResumeLayout(False)
        Me.pnlAltaPolitica.PerformLayout()
        CType(Me.grdAreaOperativa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlCondicionCatalogo.ResumeLayout(False)
        CType(Me.grdCatalogoCondicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAccionesCondicionCatalogo.ResumeLayout(False)
        Me.pnlAccionesCondicionCatalogo.PerformLayout()
        Me.pnlCondicion.ResumeLayout(False)
        CType(Me.grdCondicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAccionesCondicion.ResumeLayout(False)
        Me.pnlAccionesCondicion.PerformLayout()
        Me.pnlTipoPolitica.ResumeLayout(False)
        CType(Me.grdTipoCondicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAccionesTipoPolitica.ResumeLayout(False)
        Me.pnlAccionesTipoPolitica.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grpPoliticasActuales.ResumeLayout(False)
        Me.pnlPoliticasActuales.ResumeLayout(False)
        CType(Me.grdListaCatalogoCondiciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents pnlAreaOperativa As System.Windows.Forms.Panel
    Friend WithEvents grdAreaOperativa As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCondicionCatalogo As System.Windows.Forms.Label
    Friend WithEvents lblPolitica As System.Windows.Forms.Label
    Friend WithEvents lblTipoPolitica As System.Windows.Forms.Label
    Friend WithEvents pnlCondicionCatalogo As System.Windows.Forms.Panel
    Friend WithEvents grdCatalogoCondicion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlAccionesCondicionCatalogo As System.Windows.Forms.Panel
    Friend WithEvents lblEditarCondicionCatalogo As System.Windows.Forms.Label
    Friend WithEvents btnEditarCondicionCatalogo As System.Windows.Forms.Button
    Friend WithEvents btnAltaCondicionCatalogo As System.Windows.Forms.Button
    Friend WithEvents lblAltaCondicionCatalogo As System.Windows.Forms.Label
    Friend WithEvents pnlCondicion As System.Windows.Forms.Panel
    Friend WithEvents grdCondicion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlAccionesCondicion As System.Windows.Forms.Panel
    Friend WithEvents lblEditarCondicion As System.Windows.Forms.Label
    Friend WithEvents btnEditarCondicion As System.Windows.Forms.Button
    Friend WithEvents btnAltaCondicion As System.Windows.Forms.Button
    Friend WithEvents lblAltaCondicion As System.Windows.Forms.Label
    Friend WithEvents pnlTipoPolitica As System.Windows.Forms.Panel
    Friend WithEvents grdTipoCondicion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlAccionesTipoPolitica As System.Windows.Forms.Panel
    Friend WithEvents EditarTipo As System.Windows.Forms.Label
    Friend WithEvents btnEditarTipo As System.Windows.Forms.Button
    Friend WithEvents btnAltaTipo As System.Windows.Forms.Button
    Friend WithEvents lblAltaTipo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlAltaPolitica As System.Windows.Forms.Panel
    Friend WithEvents btnGuardarAreaOperativa As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnGuardarPolitica As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpPoliticasActuales As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPoliticasActuales As System.Windows.Forms.Panel
    Friend WithEvents grdListaCatalogoCondiciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
