<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UbicacionProductoArchivoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UbicacionProductoArchivoForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.gboxListadoCodigosCorrectos = New System.Windows.Forms.GroupBox()
        Me.gridListaCodigosCorrectos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxListaCodigos = New System.Windows.Forms.GroupBox()
        Me.gridListaCodigos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxResumen = New System.Windows.Forms.GroupBox()
        Me.pnlResumen = New System.Windows.Forms.Panel()
        Me.lblInvalidos = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAtados = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblErrores = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblEstibas = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblColaboradorNombre = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtResumenInforme = New System.Windows.Forms.TextBox()
        Me.lblDestallados = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRecuperados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.cboxAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboxNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnUbicacionProducto = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCargarArchivoDAT = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFechaReporteProductividad = New System.Windows.Forms.Label()
        Me.lblHoraReporteProductividad = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.gboxListadoCodigosCorrectos.SuspendLayout()
        CType(Me.gridListaCodigosCorrectos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxListaCodigos.SuspendLayout()
        CType(Me.gridListaCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxResumen.SuspendLayout()
        Me.pnlResumen.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlParametros)
        Me.pnlContenedor.Controls.Add(Me.Panel11)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Controls.Add(Me.pnlPie)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1117, 525)
        Me.pnlContenedor.TabIndex = 3
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.gboxListadoCodigosCorrectos)
        Me.pnlParametros.Controls.Add(Me.gboxListaCodigos)
        Me.pnlParametros.Controls.Add(Me.gboxResumen)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParametros.Location = New System.Drawing.Point(0, 99)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1117, 355)
        Me.pnlParametros.TabIndex = 0
        '
        'gboxListadoCodigosCorrectos
        '
        Me.gboxListadoCodigosCorrectos.Controls.Add(Me.gridListaCodigosCorrectos)
        Me.gboxListadoCodigosCorrectos.Location = New System.Drawing.Point(238, 8)
        Me.gboxListadoCodigosCorrectos.Name = "gboxListadoCodigosCorrectos"
        Me.gboxListadoCodigosCorrectos.Size = New System.Drawing.Size(475, 340)
        Me.gboxListadoCodigosCorrectos.TabIndex = 8
        Me.gboxListadoCodigosCorrectos.TabStop = False
        Me.gboxListadoCodigosCorrectos.Text = "Códigos Procesados"
        '
        'gridListaCodigosCorrectos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCodigosCorrectos.DisplayLayout.Appearance = Appearance1
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCodigosCorrectos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCodigosCorrectos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCodigosCorrectos.Location = New System.Drawing.Point(3, 16)
        Me.gridListaCodigosCorrectos.Name = "gridListaCodigosCorrectos"
        Me.gridListaCodigosCorrectos.Size = New System.Drawing.Size(469, 321)
        Me.gridListaCodigosCorrectos.TabIndex = 1
        '
        'gboxListaCodigos
        '
        Me.gboxListaCodigos.Controls.Add(Me.gridListaCodigos)
        Me.gboxListaCodigos.Location = New System.Drawing.Point(5, 8)
        Me.gboxListaCodigos.Name = "gboxListaCodigos"
        Me.gboxListaCodigos.Size = New System.Drawing.Size(225, 340)
        Me.gboxListaCodigos.TabIndex = 7
        Me.gboxListaCodigos.TabStop = False
        Me.gboxListaCodigos.Text = "Códigos en Archivo .DAT"
        '
        'gridListaCodigos
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCodigos.DisplayLayout.Appearance = Appearance2
        Me.gridListaCodigos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaCodigos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCodigos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCodigos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCodigos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCodigos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCodigos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaCodigos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCodigos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCodigos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCodigos.Location = New System.Drawing.Point(3, 16)
        Me.gridListaCodigos.Name = "gridListaCodigos"
        Me.gridListaCodigos.Size = New System.Drawing.Size(219, 321)
        Me.gridListaCodigos.TabIndex = 0
        '
        'gboxResumen
        '
        Me.gboxResumen.Controls.Add(Me.pnlResumen)
        Me.gboxResumen.Location = New System.Drawing.Point(719, 8)
        Me.gboxResumen.Name = "gboxResumen"
        Me.gboxResumen.Size = New System.Drawing.Size(390, 340)
        Me.gboxResumen.TabIndex = 6
        Me.gboxResumen.TabStop = False
        Me.gboxResumen.Text = "Resultados"
        '
        'pnlResumen
        '
        Me.pnlResumen.Controls.Add(Me.lblInvalidos)
        Me.pnlResumen.Controls.Add(Me.Label10)
        Me.pnlResumen.Controls.Add(Me.Panel5)
        Me.pnlResumen.Controls.Add(Me.lblPares)
        Me.pnlResumen.Controls.Add(Me.Panel7)
        Me.pnlResumen.Controls.Add(Me.Panel8)
        Me.pnlResumen.Controls.Add(Me.Label5)
        Me.pnlResumen.Controls.Add(Me.lblAtados)
        Me.pnlResumen.Controls.Add(Me.Label3)
        Me.pnlResumen.Controls.Add(Me.Panel3)
        Me.pnlResumen.Controls.Add(Me.lblErrores)
        Me.pnlResumen.Controls.Add(Me.Panel4)
        Me.pnlResumen.Controls.Add(Me.Panel6)
        Me.pnlResumen.Controls.Add(Me.Label20)
        Me.pnlResumen.Controls.Add(Me.lblEstibas)
        Me.pnlResumen.Controls.Add(Me.Label16)
        Me.pnlResumen.Controls.Add(Me.lblColaboradorNombre)
        Me.pnlResumen.Controls.Add(Me.Label18)
        Me.pnlResumen.Controls.Add(Me.GroupBox1)
        Me.pnlResumen.Controls.Add(Me.lblDestallados)
        Me.pnlResumen.Controls.Add(Me.Label4)
        Me.pnlResumen.Controls.Add(Me.lblRecuperados)
        Me.pnlResumen.Controls.Add(Me.Label1)
        Me.pnlResumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlResumen.Location = New System.Drawing.Point(3, 16)
        Me.pnlResumen.Name = "pnlResumen"
        Me.pnlResumen.Size = New System.Drawing.Size(384, 321)
        Me.pnlResumen.TabIndex = 2
        '
        'lblInvalidos
        '
        Me.lblInvalidos.AutoSize = True
        Me.lblInvalidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvalidos.ForeColor = System.Drawing.Color.Black
        Me.lblInvalidos.Location = New System.Drawing.Point(136, 52)
        Me.lblInvalidos.Name = "lblInvalidos"
        Me.lblInvalidos.Size = New System.Drawing.Size(43, 13)
        Me.lblInvalidos.TabIndex = 88
        Me.lblInvalidos.Text = "000000"
        Me.lblInvalidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(24, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "Códigos Inválidos:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Location = New System.Drawing.Point(8, 28)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(15, 15)
        Me.Panel5.TabIndex = 75
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPares.ForeColor = System.Drawing.Color.Black
        Me.lblPares.Location = New System.Drawing.Point(330, 75)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(43, 13)
        Me.lblPares.TabIndex = 86
        Me.lblPares.Text = "000000"
        Me.lblPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Yellow
        Me.Panel7.Location = New System.Drawing.Point(8, 74)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(15, 15)
        Me.Panel7.TabIndex = 76
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel8.Location = New System.Drawing.Point(186, 28)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(15, 15)
        Me.Panel8.TabIndex = 73
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(203, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Códigos Par:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAtados
        '
        Me.lblAtados.AutoSize = True
        Me.lblAtados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtados.ForeColor = System.Drawing.Color.Black
        Me.lblAtados.Location = New System.Drawing.Point(330, 52)
        Me.lblAtados.Name = "lblAtados"
        Me.lblAtados.Size = New System.Drawing.Size(43, 13)
        Me.lblAtados.TabIndex = 84
        Me.lblAtados.Text = "000000"
        Me.lblAtados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(203, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Códigos Atado:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Red
        Me.Panel3.Location = New System.Drawing.Point(8, 51)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(15, 15)
        Me.Panel3.TabIndex = 69
        '
        'lblErrores
        '
        Me.lblErrores.AutoSize = True
        Me.lblErrores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrores.ForeColor = System.Drawing.Color.Black
        Me.lblErrores.Location = New System.Drawing.Point(136, 29)
        Me.lblErrores.Name = "lblErrores"
        Me.lblErrores.Size = New System.Drawing.Size(43, 13)
        Me.lblErrores.TabIndex = 82
        Me.lblErrores.Text = "000000"
        Me.lblErrores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Aquamarine
        Me.Panel4.Location = New System.Drawing.Point(186, 51)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(15, 15)
        Me.Panel4.TabIndex = 70
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Khaki
        Me.Panel6.Location = New System.Drawing.Point(186, 74)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(15, 15)
        Me.Panel6.TabIndex = 67
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(24, 29)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(94, 13)
        Me.Label20.TabIndex = 81
        Me.Label20.Text = "Errores de Lectura"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEstibas
        '
        Me.lblEstibas.AutoSize = True
        Me.lblEstibas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstibas.ForeColor = System.Drawing.Color.Black
        Me.lblEstibas.Location = New System.Drawing.Point(330, 29)
        Me.lblEstibas.Name = "lblEstibas"
        Me.lblEstibas.Size = New System.Drawing.Size(43, 13)
        Me.lblEstibas.TabIndex = 80
        Me.lblEstibas.Text = "000000"
        Me.lblEstibas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(202, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(106, 13)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Estibas actualizadas:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblColaboradorNombre
        '
        Me.lblColaboradorNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaboradorNombre.ForeColor = System.Drawing.Color.Black
        Me.lblColaboradorNombre.Location = New System.Drawing.Point(100, 9)
        Me.lblColaboradorNombre.Name = "lblColaboradorNombre"
        Me.lblColaboradorNombre.Size = New System.Drawing.Size(273, 13)
        Me.lblColaboradorNombre.TabIndex = 78
        Me.lblColaboradorNombre.Text = "Nombre Nombre Paterno Materno"
        Me.lblColaboradorNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblColaboradorNombre.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(27, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 13)
        Me.Label18.TabIndex = 77
        Me.Label18.Text = "Colaborador:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtResumenInforme)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 197)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'txtResumenInforme
        '
        Me.txtResumenInforme.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtResumenInforme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResumenInforme.Location = New System.Drawing.Point(3, 16)
        Me.txtResumenInforme.Multiline = True
        Me.txtResumenInforme.Name = "txtResumenInforme"
        Me.txtResumenInforme.ReadOnly = True
        Me.txtResumenInforme.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResumenInforme.Size = New System.Drawing.Size(359, 178)
        Me.txtResumenInforme.TabIndex = 3
        '
        'lblDestallados
        '
        Me.lblDestallados.AutoSize = True
        Me.lblDestallados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDestallados.ForeColor = System.Drawing.Color.Black
        Me.lblDestallados.Location = New System.Drawing.Point(136, 75)
        Me.lblDestallados.Name = "lblDestallados"
        Me.lblDestallados.Size = New System.Drawing.Size(43, 13)
        Me.lblDestallados.TabIndex = 60
        Me.lblDestallados.Text = "000000"
        Me.lblDestallados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(24, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Atados Destallados:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecuperados
        '
        Me.lblRecuperados.AutoSize = True
        Me.lblRecuperados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecuperados.ForeColor = System.Drawing.Color.Black
        Me.lblRecuperados.Location = New System.Drawing.Point(330, 96)
        Me.lblRecuperados.Name = "lblRecuperados"
        Me.lblRecuperados.Size = New System.Drawing.Size(43, 13)
        Me.lblRecuperados.TabIndex = 54
        Me.lblRecuperados.Text = "000000"
        Me.lblRecuperados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(203, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Registros Recuperados:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel11.Controls.Add(Me.cboxAlmacen)
        Me.Panel11.Controls.Add(Me.Label9)
        Me.Panel11.Controls.Add(Me.cboxNave)
        Me.Panel11.Controls.Add(Me.lblNave)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 59)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1117, 40)
        Me.Panel11.TabIndex = 7
        '
        'cboxAlmacen
        '
        Me.cboxAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxAlmacen.FormattingEnabled = True
        Me.cboxAlmacen.Location = New System.Drawing.Point(463, 10)
        Me.cboxAlmacen.Name = "cboxAlmacen"
        Me.cboxAlmacen.Size = New System.Drawing.Size(66, 21)
        Me.cboxAlmacen.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(412, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Almacén"
        '
        'cboxNave
        '
        Me.cboxNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxNave.FormattingEnabled = True
        Me.cboxNave.Location = New System.Drawing.Point(49, 10)
        Me.cboxNave.Name = "cboxNave"
        Me.cboxNave.Size = New System.Drawing.Size(320, 21)
        Me.cboxNave.TabIndex = 14
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(12, 14)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 13
        Me.lblNave.Text = "Nave"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(1117, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1117, 59)
        Me.pnlEncabezado.TabIndex = 0
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Label6)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnUbicacionProducto)
        Me.pnlAccionesCabecera.Controls.Add(Me.Label2)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnCargarArchivoDAT)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(301, 59)
        Me.pnlAccionesCabecera.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(112, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Ubicación de Producto"
        '
        'btnUbicacionProducto
        '
        Me.btnUbicacionProducto.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnUbicacionProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnUbicacionProducto.Location = New System.Drawing.Point(154, 7)
        Me.btnUbicacionProducto.Name = "btnUbicacionProducto"
        Me.btnUbicacionProducto.Size = New System.Drawing.Size(32, 32)
        Me.btnUbicacionProducto.TabIndex = 7
        Me.btnUbicacionProducto.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(20, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cargar Archivo"
        '
        'btnCargarArchivoDAT
        '
        Me.btnCargarArchivoDAT.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCargarArchivoDAT.Image = Global.Almacen.Vista.My.Resources.Resources.agregar_32
        Me.btnCargarArchivoDAT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCargarArchivoDAT.Location = New System.Drawing.Point(42, 7)
        Me.btnCargarArchivoDAT.Name = "btnCargarArchivoDAT"
        Me.btnCargarArchivoDAT.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarArchivoDAT.TabIndex = 5
        Me.btnCargarArchivoDAT.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(624, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(493, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(232, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(190, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Ubicación de Producto"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(425, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(68, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 45
        Me.imgLogo.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 454)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1117, 71)
        Me.pnlPie.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.lblFechaReporteProductividad)
        Me.Panel1.Controls.Add(Me.lblHoraReporteProductividad)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(680, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(252, 71)
        Me.Panel1.TabIndex = 65
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(10, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Última Actualización:"
        '
        'lblFechaReporteProductividad
        '
        Me.lblFechaReporteProductividad.AutoSize = True
        Me.lblFechaReporteProductividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaReporteProductividad.ForeColor = System.Drawing.Color.Black
        Me.lblFechaReporteProductividad.Location = New System.Drawing.Point(115, 31)
        Me.lblFechaReporteProductividad.Name = "lblFechaReporteProductividad"
        Me.lblFechaReporteProductividad.Size = New System.Drawing.Size(65, 13)
        Me.lblFechaReporteProductividad.TabIndex = 64
        Me.lblFechaReporteProductividad.Text = "8888/88/88"
        Me.lblFechaReporteProductividad.Visible = False
        '
        'lblHoraReporteProductividad
        '
        Me.lblHoraReporteProductividad.AutoSize = True
        Me.lblHoraReporteProductividad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraReporteProductividad.ForeColor = System.Drawing.Color.Black
        Me.lblHoraReporteProductividad.Location = New System.Drawing.Point(183, 31)
        Me.lblHoraReporteProductividad.Name = "lblHoraReporteProductividad"
        Me.lblHoraReporteProductividad.Size = New System.Drawing.Size(63, 13)
        Me.lblHoraReporteProductividad.TabIndex = 65
        Me.lblHoraReporteProductividad.Text = "88:88:88XX"
        Me.lblHoraReporteProductividad.Visible = False
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(932, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(185, 71)
        Me.pnlDatosBotones.TabIndex = 64
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(75, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(67, 43)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 13)
        Me.lblLimpiar.TabIndex = 4
        Me.lblLimpiar.Text = "Cancelar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(131, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(14, 43)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(44, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Aceptar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(130, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.aceptar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(19, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'UbicacionProductoArchivoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 525)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(881, 564)
        Me.Name = "UbicacionProductoArchivoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ubicación de Producto"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.gboxListadoCodigosCorrectos.ResumeLayout(False)
        CType(Me.gridListaCodigosCorrectos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxListaCodigos.ResumeLayout(False)
        CType(Me.gridListaCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxResumen.ResumeLayout(False)
        Me.pnlResumen.ResumeLayout(False)
        Me.pnlResumen.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlResumen As System.Windows.Forms.Panel
    Friend WithEvents lblDestallados As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRecuperados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCargarArchivoDAT As System.Windows.Forms.Button
    Friend WithEvents gboxResumen As System.Windows.Forms.GroupBox
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblAceptar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtResumenInforme As System.Windows.Forms.TextBox
    Friend WithEvents gboxListadoCodigosCorrectos As System.Windows.Forms.GroupBox
    Friend WithEvents gboxListaCodigos As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaCodigos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents cboxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboxNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblEstibas As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblColaboradorNombre As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFechaReporteProductividad As System.Windows.Forms.Label
    Friend WithEvents lblHoraReporteProductividad As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lblErrores As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblInvalidos As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblAtados As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gridListaCodigosCorrectos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnUbicacionProducto As System.Windows.Forms.Button
End Class
