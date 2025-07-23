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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.tabCon_Sin_Plataforma = New System.Windows.Forms.TabControl()
        Me.tpgSinPlataforma = New System.Windows.Forms.TabPage()
        Me.pnlSinPlataforma = New System.Windows.Forms.Panel()
        Me.gboxListadoCodigosCorrectos = New System.Windows.Forms.GroupBox()
        Me.gridListaCodigosCorrectos_SinCarrito = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxListaCodigos = New System.Windows.Forms.GroupBox()
        Me.gridListaCodigos_SinPlataforma = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.gboxResumen = New System.Windows.Forms.GroupBox()
        Me.pnlResumen = New System.Windows.Forms.Panel()
        Me.lblParesApartado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblApartados = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
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
        Me.txtResumenInforme_SinCarrito = New System.Windows.Forms.TextBox()
        Me.lblDestallados = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRecuperados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tpgConPlataforma = New System.Windows.Forms.TabPage()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnValidar_Plataforma = New System.Windows.Forms.Button()
        Me.gridListaPlataforma = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gridListaCodigosCorrectos_ConCarrito = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.gridListaCodigos_ConPlataforma = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblPlataformasValidas = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.lblInvalidosConCarrito = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.lblCodigoInexistenteEnPlataforma = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblAtadosConCarrito = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.lblErroresConCarrito = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblEstibasConCarrito = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtResumenInforme_ConCarrito = New System.Windows.Forms.TextBox()
        Me.lblRecuperadosConCarrito = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.pnlParametrosGenerales = New System.Windows.Forms.Panel()
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
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlColores = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaReporteProductividad = New System.Windows.Forms.Label()
        Me.lblHoraReporteProductividad = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlPrincipal.SuspendLayout()
        Me.tabCon_Sin_Plataforma.SuspendLayout()
        Me.tpgSinPlataforma.SuspendLayout()
        Me.pnlSinPlataforma.SuspendLayout()
        Me.gboxListadoCodigosCorrectos.SuspendLayout()
        CType(Me.gridListaCodigosCorrectos_SinCarrito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxListaCodigos.SuspendLayout()
        CType(Me.gridListaCodigos_SinPlataforma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxResumen.SuspendLayout()
        Me.pnlResumen.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpgConPlataforma.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.gridListaPlataforma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridListaCodigosCorrectos_ConCarrito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.gridListaCodigos_ConPlataforma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.pnlParametrosGenerales.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlColores.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlPrincipal)
        Me.pnlContenedor.Controls.Add(Me.pnlParametrosGenerales)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Controls.Add(Me.pnlPie)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(1213, 552)
        Me.pnlContenedor.TabIndex = 3
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.tabCon_Sin_Plataforma)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 99)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(1213, 382)
        Me.pnlPrincipal.TabIndex = 66
        '
        'tabCon_Sin_Plataforma
        '
        Me.tabCon_Sin_Plataforma.Controls.Add(Me.tpgSinPlataforma)
        Me.tabCon_Sin_Plataforma.Controls.Add(Me.tpgConPlataforma)
        Me.tabCon_Sin_Plataforma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCon_Sin_Plataforma.Location = New System.Drawing.Point(0, 0)
        Me.tabCon_Sin_Plataforma.Name = "tabCon_Sin_Plataforma"
        Me.tabCon_Sin_Plataforma.SelectedIndex = 0
        Me.tabCon_Sin_Plataforma.Size = New System.Drawing.Size(1213, 382)
        Me.tabCon_Sin_Plataforma.TabIndex = 17
        '
        'tpgSinPlataforma
        '
        Me.tpgSinPlataforma.BackColor = System.Drawing.Color.AliceBlue
        Me.tpgSinPlataforma.Controls.Add(Me.pnlSinPlataforma)
        Me.tpgSinPlataforma.Location = New System.Drawing.Point(4, 22)
        Me.tpgSinPlataforma.Name = "tpgSinPlataforma"
        Me.tpgSinPlataforma.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgSinPlataforma.Size = New System.Drawing.Size(1205, 356)
        Me.tpgSinPlataforma.TabIndex = 0
        Me.tpgSinPlataforma.Text = "Sin Plataforma"
        '
        'pnlSinPlataforma
        '
        Me.pnlSinPlataforma.Controls.Add(Me.gboxListadoCodigosCorrectos)
        Me.pnlSinPlataforma.Controls.Add(Me.gboxListaCodigos)
        Me.pnlSinPlataforma.Controls.Add(Me.gboxResumen)
        Me.pnlSinPlataforma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSinPlataforma.Location = New System.Drawing.Point(3, 3)
        Me.pnlSinPlataforma.Name = "pnlSinPlataforma"
        Me.pnlSinPlataforma.Size = New System.Drawing.Size(1199, 350)
        Me.pnlSinPlataforma.TabIndex = 0
        '
        'gboxListadoCodigosCorrectos
        '
        Me.gboxListadoCodigosCorrectos.Controls.Add(Me.gridListaCodigosCorrectos_SinCarrito)
        Me.gboxListadoCodigosCorrectos.Location = New System.Drawing.Point(238, 8)
        Me.gboxListadoCodigosCorrectos.Name = "gboxListadoCodigosCorrectos"
        Me.gboxListadoCodigosCorrectos.Size = New System.Drawing.Size(559, 340)
        Me.gboxListadoCodigosCorrectos.TabIndex = 8
        Me.gboxListadoCodigosCorrectos.TabStop = False
        Me.gboxListadoCodigosCorrectos.Text = "Códigos Procesados"
        '
        'gridListaCodigosCorrectos_SinCarrito
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Appearance = Appearance1
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCodigosCorrectos_SinCarrito.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCodigosCorrectos_SinCarrito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCodigosCorrectos_SinCarrito.Location = New System.Drawing.Point(3, 16)
        Me.gridListaCodigosCorrectos_SinCarrito.Name = "gridListaCodigosCorrectos_SinCarrito"
        Me.gridListaCodigosCorrectos_SinCarrito.Size = New System.Drawing.Size(553, 321)
        Me.gridListaCodigosCorrectos_SinCarrito.TabIndex = 1
        '
        'gboxListaCodigos
        '
        Me.gboxListaCodigos.Controls.Add(Me.gridListaCodigos_SinPlataforma)
        Me.gboxListaCodigos.Location = New System.Drawing.Point(5, 8)
        Me.gboxListaCodigos.Name = "gboxListaCodigos"
        Me.gboxListaCodigos.Size = New System.Drawing.Size(225, 340)
        Me.gboxListaCodigos.TabIndex = 7
        Me.gboxListaCodigos.TabStop = False
        Me.gboxListaCodigos.Text = "Códigos en Archivo .DAT"
        '
        'gridListaCodigos_SinPlataforma
        '
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Appearance = Appearance2
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCodigos_SinPlataforma.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCodigos_SinPlataforma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCodigos_SinPlataforma.Location = New System.Drawing.Point(3, 16)
        Me.gridListaCodigos_SinPlataforma.Name = "gridListaCodigos_SinPlataforma"
        Me.gridListaCodigos_SinPlataforma.Size = New System.Drawing.Size(219, 321)
        Me.gridListaCodigos_SinPlataforma.TabIndex = 0
        '
        'gboxResumen
        '
        Me.gboxResumen.Controls.Add(Me.pnlResumen)
        Me.gboxResumen.Location = New System.Drawing.Point(803, 8)
        Me.gboxResumen.Name = "gboxResumen"
        Me.gboxResumen.Size = New System.Drawing.Size(390, 340)
        Me.gboxResumen.TabIndex = 6
        Me.gboxResumen.TabStop = False
        Me.gboxResumen.Text = "Resultados"
        '
        'pnlResumen
        '
        Me.pnlResumen.Controls.Add(Me.lblParesApartado)
        Me.pnlResumen.Controls.Add(Me.Label11)
        Me.pnlResumen.Controls.Add(Me.lblApartados)
        Me.pnlResumen.Controls.Add(Me.Label13)
        Me.pnlResumen.Controls.Add(Me.Panel2)
        Me.pnlResumen.Controls.Add(Me.Panel9)
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
        'lblParesApartado
        '
        Me.lblParesApartado.AutoSize = True
        Me.lblParesApartado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesApartado.ForeColor = System.Drawing.Color.Black
        Me.lblParesApartado.Location = New System.Drawing.Point(136, 121)
        Me.lblParesApartado.Name = "lblParesApartado"
        Me.lblParesApartado.Size = New System.Drawing.Size(43, 13)
        Me.lblParesApartado.TabIndex = 94
        Me.lblParesApartado.Text = "000000"
        Me.lblParesApartado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(25, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 13)
        Me.Label11.TabIndex = 93
        Me.Label11.Text = "Pares en Apartados:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblApartados
        '
        Me.lblApartados.AutoSize = True
        Me.lblApartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApartados.ForeColor = System.Drawing.Color.Black
        Me.lblApartados.Location = New System.Drawing.Point(136, 98)
        Me.lblApartados.Name = "lblApartados"
        Me.lblApartados.Size = New System.Drawing.Size(43, 13)
        Me.lblApartados.TabIndex = 92
        Me.lblApartados.Text = "000000"
        Me.lblApartados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(25, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 91
        Me.Label13.Text = "Códigos Apartado:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MediumOrchid
        Me.Panel2.Location = New System.Drawing.Point(8, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(15, 15)
        Me.Panel2.TabIndex = 90
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.Location = New System.Drawing.Point(8, 120)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(15, 15)
        Me.Panel9.TabIndex = 89
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
        Me.GroupBox1.Controls.Add(Me.txtResumenInforme_SinCarrito)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 152)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'txtResumenInforme_SinCarrito
        '
        Me.txtResumenInforme_SinCarrito.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtResumenInforme_SinCarrito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResumenInforme_SinCarrito.Location = New System.Drawing.Point(3, 16)
        Me.txtResumenInforme_SinCarrito.Multiline = True
        Me.txtResumenInforme_SinCarrito.Name = "txtResumenInforme_SinCarrito"
        Me.txtResumenInforme_SinCarrito.ReadOnly = True
        Me.txtResumenInforme_SinCarrito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResumenInforme_SinCarrito.Size = New System.Drawing.Size(359, 133)
        Me.txtResumenInforme_SinCarrito.TabIndex = 3
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
        Me.lblRecuperados.Location = New System.Drawing.Point(330, 137)
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
        Me.Label1.Location = New System.Drawing.Point(203, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Registros Recuperados:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tpgConPlataforma
        '
        Me.tpgConPlataforma.BackColor = System.Drawing.Color.AliceBlue
        Me.tpgConPlataforma.Controls.Add(Me.Panel10)
        Me.tpgConPlataforma.Location = New System.Drawing.Point(4, 22)
        Me.tpgConPlataforma.Name = "tpgConPlataforma"
        Me.tpgConPlataforma.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgConPlataforma.Size = New System.Drawing.Size(1205, 356)
        Me.tpgConPlataforma.TabIndex = 1
        Me.tpgConPlataforma.Text = "Con Plataforma"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.GroupBox6)
        Me.Panel10.Controls.Add(Me.GroupBox2)
        Me.Panel10.Controls.Add(Me.GroupBox3)
        Me.Panel10.Controls.Add(Me.GroupBox4)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(3, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1199, 350)
        Me.Panel10.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.btnValidar_Plataforma)
        Me.GroupBox6.Controls.Add(Me.gridListaPlataforma)
        Me.GroupBox6.Location = New System.Drawing.Point(595, 8)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(222, 340)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Códigos en Archivo .DAT"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(91, 320)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Validar"
        '
        'btnValidar_Plataforma
        '
        Me.btnValidar_Plataforma.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnValidar_Plataforma.Enabled = False
        Me.btnValidar_Plataforma.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnValidar_Plataforma.Image = Global.Almacen.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnValidar_Plataforma.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnValidar_Plataforma.Location = New System.Drawing.Point(94, 285)
        Me.btnValidar_Plataforma.Name = "btnValidar_Plataforma"
        Me.btnValidar_Plataforma.Size = New System.Drawing.Size(32, 32)
        Me.btnValidar_Plataforma.TabIndex = 2
        Me.btnValidar_Plataforma.UseVisualStyleBackColor = True
        '
        'gridListaPlataforma
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaPlataforma.DisplayLayout.Appearance = Appearance3
        Me.gridListaPlataforma.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaPlataforma.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaPlataforma.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaPlataforma.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaPlataforma.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaPlataforma.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaPlataforma.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaPlataforma.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaPlataforma.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaPlataforma.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaPlataforma.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaPlataforma.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaPlataforma.Location = New System.Drawing.Point(4, 16)
        Me.gridListaPlataforma.Name = "gridListaPlataforma"
        Me.gridListaPlataforma.Size = New System.Drawing.Size(213, 263)
        Me.gridListaPlataforma.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridListaCodigosCorrectos_ConCarrito)
        Me.GroupBox2.Location = New System.Drawing.Point(165, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 340)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Códigos Procesados"
        '
        'gridListaCodigosCorrectos_ConCarrito
        '
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Appearance = Appearance4
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCodigosCorrectos_ConCarrito.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCodigosCorrectos_ConCarrito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCodigosCorrectos_ConCarrito.Location = New System.Drawing.Point(3, 16)
        Me.gridListaCodigosCorrectos_ConCarrito.Name = "gridListaCodigosCorrectos_ConCarrito"
        Me.gridListaCodigosCorrectos_ConCarrito.Size = New System.Drawing.Size(418, 321)
        Me.gridListaCodigosCorrectos_ConCarrito.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gridListaCodigos_ConPlataforma)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(156, 340)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Códigos en Archivo .DAT"
        '
        'gridListaCodigos_ConPlataforma
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Appearance = Appearance5
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaCodigos_ConPlataforma.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaCodigos_ConPlataforma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaCodigos_ConPlataforma.Location = New System.Drawing.Point(3, 16)
        Me.gridListaCodigos_ConPlataforma.Name = "gridListaCodigos_ConPlataforma"
        Me.gridListaCodigos_ConPlataforma.Size = New System.Drawing.Size(150, 321)
        Me.gridListaCodigos_ConPlataforma.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblPlataformasValidas)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Panel12)
        Me.GroupBox4.Controls.Add(Me.lblInvalidosConCarrito)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Panel14)
        Me.GroupBox4.Controls.Add(Me.lblCodigoInexistenteEnPlataforma)
        Me.GroupBox4.Controls.Add(Me.Panel16)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.lblAtadosConCarrito)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.Panel17)
        Me.GroupBox4.Controls.Add(Me.lblErroresConCarrito)
        Me.GroupBox4.Controls.Add(Me.Panel18)
        Me.GroupBox4.Controls.Add(Me.Panel19)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.lblEstibasConCarrito)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.lblRecuperadosConCarrito)
        Me.GroupBox4.Controls.Add(Me.Label34)
        Me.GroupBox4.Location = New System.Drawing.Point(826, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(362, 340)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Resultados"
        '
        'lblPlataformasValidas
        '
        Me.lblPlataformasValidas.AutoSize = True
        Me.lblPlataformasValidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlataformasValidas.ForeColor = System.Drawing.Color.Black
        Me.lblPlataformasValidas.Location = New System.Drawing.Point(133, 91)
        Me.lblPlataformasValidas.Name = "lblPlataformasValidas"
        Me.lblPlataformasValidas.Size = New System.Drawing.Size(43, 13)
        Me.lblPlataformasValidas.TabIndex = 115
        Me.lblPlataformasValidas.Text = "000000"
        Me.lblPlataformasValidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(34, 91)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 13)
        Me.Label15.TabIndex = 114
        Me.Label15.Text = "Plataformas válidas:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel12.Location = New System.Drawing.Point(17, 90)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(15, 15)
        Me.Panel12.TabIndex = 113
        '
        'lblInvalidosConCarrito
        '
        Me.lblInvalidosConCarrito.AutoSize = True
        Me.lblInvalidosConCarrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvalidosConCarrito.ForeColor = System.Drawing.Color.Black
        Me.lblInvalidosConCarrito.Location = New System.Drawing.Point(133, 68)
        Me.lblInvalidosConCarrito.Name = "lblInvalidosConCarrito"
        Me.lblInvalidosConCarrito.Size = New System.Drawing.Size(43, 13)
        Me.lblInvalidosConCarrito.TabIndex = 112
        Me.lblInvalidosConCarrito.Text = "000000"
        Me.lblInvalidosConCarrito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(33, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 13)
        Me.Label19.TabIndex = 111
        Me.Label19.Text = "Códigos Inválidos:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Gray
        Me.Panel14.Location = New System.Drawing.Point(17, 44)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(15, 15)
        Me.Panel14.TabIndex = 100
        '
        'lblCodigoInexistenteEnPlataforma
        '
        Me.lblCodigoInexistenteEnPlataforma.AutoSize = True
        Me.lblCodigoInexistenteEnPlataforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoInexistenteEnPlataforma.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoInexistenteEnPlataforma.Location = New System.Drawing.Point(314, 91)
        Me.lblCodigoInexistenteEnPlataforma.Name = "lblCodigoInexistenteEnPlataforma"
        Me.lblCodigoInexistenteEnPlataforma.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoInexistenteEnPlataforma.TabIndex = 110
        Me.lblCodigoInexistenteEnPlataforma.Text = "000000"
        Me.lblCodigoInexistenteEnPlataforma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel16.Location = New System.Drawing.Point(195, 44)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(15, 15)
        Me.Panel16.TabIndex = 99
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(212, 91)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(107, 26)
        Me.Label22.TabIndex = 109
        Me.Label22.Text = "Códigos Inexistentes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "en Plataforma:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAtadosConCarrito
        '
        Me.lblAtadosConCarrito.AutoSize = True
        Me.lblAtadosConCarrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtadosConCarrito.ForeColor = System.Drawing.Color.Black
        Me.lblAtadosConCarrito.Location = New System.Drawing.Point(314, 68)
        Me.lblAtadosConCarrito.Name = "lblAtadosConCarrito"
        Me.lblAtadosConCarrito.Size = New System.Drawing.Size(43, 13)
        Me.lblAtadosConCarrito.TabIndex = 108
        Me.lblAtadosConCarrito.Text = "000000"
        Me.lblAtadosConCarrito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(212, 68)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(79, 13)
        Me.Label24.TabIndex = 107
        Me.Label24.Text = "Códigos Atado:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.Red
        Me.Panel17.Location = New System.Drawing.Point(17, 67)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(15, 15)
        Me.Panel17.TabIndex = 97
        '
        'lblErroresConCarrito
        '
        Me.lblErroresConCarrito.AutoSize = True
        Me.lblErroresConCarrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErroresConCarrito.ForeColor = System.Drawing.Color.Black
        Me.lblErroresConCarrito.Location = New System.Drawing.Point(133, 45)
        Me.lblErroresConCarrito.Name = "lblErroresConCarrito"
        Me.lblErroresConCarrito.Size = New System.Drawing.Size(43, 13)
        Me.lblErroresConCarrito.TabIndex = 106
        Me.lblErroresConCarrito.Text = "000000"
        Me.lblErroresConCarrito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.Aquamarine
        Me.Panel18.Location = New System.Drawing.Point(195, 67)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(15, 15)
        Me.Panel18.TabIndex = 98
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.Wheat
        Me.Panel19.Location = New System.Drawing.Point(195, 90)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(15, 15)
        Me.Panel19.TabIndex = 96
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(33, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(94, 13)
        Me.Label26.TabIndex = 105
        Me.Label26.Text = "Errores de Lectura"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEstibasConCarrito
        '
        Me.lblEstibasConCarrito.AutoSize = True
        Me.lblEstibasConCarrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstibasConCarrito.ForeColor = System.Drawing.Color.Black
        Me.lblEstibasConCarrito.Location = New System.Drawing.Point(314, 45)
        Me.lblEstibasConCarrito.Name = "lblEstibasConCarrito"
        Me.lblEstibasConCarrito.Size = New System.Drawing.Size(43, 13)
        Me.lblEstibasConCarrito.TabIndex = 104
        Me.lblEstibasConCarrito.Text = "000000"
        Me.lblEstibasConCarrito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(211, 45)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(106, 13)
        Me.Label28.TabIndex = 103
        Me.Label28.Text = "Estibas actualizadas:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(80, 25)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(273, 13)
        Me.Label29.TabIndex = 102
        Me.Label29.Text = "Nombre Nombre Paterno Materno"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label29.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(7, 25)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(67, 13)
        Me.Label30.TabIndex = 101
        Me.Label30.Text = "Colaborador:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtResumenInforme_ConCarrito)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 170)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(336, 152)
        Me.GroupBox5.TabIndex = 95
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Información"
        '
        'txtResumenInforme_ConCarrito
        '
        Me.txtResumenInforme_ConCarrito.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtResumenInforme_ConCarrito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResumenInforme_ConCarrito.Location = New System.Drawing.Point(3, 16)
        Me.txtResumenInforme_ConCarrito.Multiline = True
        Me.txtResumenInforme_ConCarrito.Name = "txtResumenInforme_ConCarrito"
        Me.txtResumenInforme_ConCarrito.ReadOnly = True
        Me.txtResumenInforme_ConCarrito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResumenInforme_ConCarrito.Size = New System.Drawing.Size(330, 133)
        Me.txtResumenInforme_ConCarrito.TabIndex = 3
        '
        'lblRecuperadosConCarrito
        '
        Me.lblRecuperadosConCarrito.AutoSize = True
        Me.lblRecuperadosConCarrito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecuperadosConCarrito.ForeColor = System.Drawing.Color.Black
        Me.lblRecuperadosConCarrito.Location = New System.Drawing.Point(314, 153)
        Me.lblRecuperadosConCarrito.Name = "lblRecuperadosConCarrito"
        Me.lblRecuperadosConCarrito.Size = New System.Drawing.Size(43, 13)
        Me.lblRecuperadosConCarrito.TabIndex = 94
        Me.lblRecuperadosConCarrito.Text = "000000"
        Me.lblRecuperadosConCarrito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(197, 153)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(121, 13)
        Me.Label34.TabIndex = 93
        Me.Label34.Text = "Registros Recuperados:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlParametrosGenerales
        '
        Me.pnlParametrosGenerales.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametrosGenerales.Controls.Add(Me.cboxAlmacen)
        Me.pnlParametrosGenerales.Controls.Add(Me.Label9)
        Me.pnlParametrosGenerales.Controls.Add(Me.cboxNave)
        Me.pnlParametrosGenerales.Controls.Add(Me.lblNave)
        Me.pnlParametrosGenerales.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametrosGenerales.Location = New System.Drawing.Point(0, 59)
        Me.pnlParametrosGenerales.Name = "pnlParametrosGenerales"
        Me.pnlParametrosGenerales.Size = New System.Drawing.Size(1213, 40)
        Me.pnlParametrosGenerales.TabIndex = 7
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
        Me.pnlCabecera.Size = New System.Drawing.Size(1213, 59)
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(1213, 59)
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
        Me.btnUbicacionProducto.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
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
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(720, 0)
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
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlColores)
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 481)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1213, 71)
        Me.pnlPie.TabIndex = 3
        '
        'pnlColores
        '
        Me.pnlColores.Controls.Add(Me.Label8)
        Me.pnlColores.Controls.Add(Me.Label17)
        Me.pnlColores.Controls.Add(Me.Panel13)
        Me.pnlColores.Controls.Add(Me.Label12)
        Me.pnlColores.Controls.Add(Me.Panel15)
        Me.pnlColores.Controls.Add(Me.Panel11)
        Me.pnlColores.Controls.Add(Me.Panel22)
        Me.pnlColores.Controls.Add(Me.Label21)
        Me.pnlColores.Controls.Add(Me.Label14)
        Me.pnlColores.Controls.Add(Me.Label25)
        Me.pnlColores.Controls.Add(Me.Panel20)
        Me.pnlColores.Controls.Add(Me.Label23)
        Me.pnlColores.Controls.Add(Me.Panel23)
        Me.pnlColores.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlColores.Location = New System.Drawing.Point(539, 0)
        Me.pnlColores.Name = "pnlColores"
        Me.pnlColores.Size = New System.Drawing.Size(237, 71)
        Me.pnlColores.TabIndex = 97
        Me.pnlColores.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(124, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Inconclusa"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(40, 33)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 92
        Me.Label17.Text = "Pendiente"
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Gray
        Me.Panel13.Location = New System.Drawing.Point(109, 48)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(15, 15)
        Me.Panel13.TabIndex = 97
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(124, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Sin Operador"
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Blue
        Me.Panel15.Location = New System.Drawing.Point(25, 48)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(15, 15)
        Me.Panel15.TabIndex = 89
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Red
        Me.Panel11.Location = New System.Drawing.Point(25, 32)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(15, 15)
        Me.Panel11.TabIndex = 90
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.Purple
        Me.Panel22.Location = New System.Drawing.Point(109, 32)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(15, 15)
        Me.Panel22.TabIndex = 95
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(40, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 88
        Me.Label21.Text = "Completado"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(40, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 13)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "Validado"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(124, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(58, 13)
        Me.Label25.TabIndex = 94
        Me.Label25.Text = "Por Validar"
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.Green
        Me.Panel20.Location = New System.Drawing.Point(25, 15)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(15, 15)
        Me.Panel20.TabIndex = 87
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(4, 1)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(87, 13)
        Me.Label23.TabIndex = 86
        Me.Label23.Text = "Localizado como"
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.Yellow
        Me.Panel23.Location = New System.Drawing.Point(109, 15)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(15, 15)
        Me.Panel23.TabIndex = 93
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblUltimaActualizacion)
        Me.Panel1.Controls.Add(Me.lblFechaReporteProductividad)
        Me.Panel1.Controls.Add(Me.lblHoraReporteProductividad)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(776, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(252, 71)
        Me.Panel1.TabIndex = 65
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(10, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(105, 13)
        Me.lblUltimaActualizacion.TabIndex = 66
        Me.lblUltimaActualizacion.Text = "Última Actualización:"
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
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1028, 0)
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
        Me.btnAceptar.Image = Global.Almacen.Vista.My.Resources.Resources.aceptar_321
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(19, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(410, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 47
        Me.pbYuyin.TabStop = False
        '
        'UbicacionProductoArchivoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1213, 552)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(881, 564)
        Me.Name = "UbicacionProductoArchivoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ubicación de Producto"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlPrincipal.ResumeLayout(False)
        Me.tabCon_Sin_Plataforma.ResumeLayout(False)
        Me.tpgSinPlataforma.ResumeLayout(False)
        Me.pnlSinPlataforma.ResumeLayout(False)
        Me.gboxListadoCodigosCorrectos.ResumeLayout(False)
        CType(Me.gridListaCodigosCorrectos_SinCarrito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxListaCodigos.ResumeLayout(False)
        CType(Me.gridListaCodigos_SinPlataforma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxResumen.ResumeLayout(False)
        Me.pnlResumen.ResumeLayout(False)
        Me.pnlResumen.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpgConPlataforma.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.gridListaPlataforma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gridListaCodigosCorrectos_ConCarrito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.gridListaCodigos_ConPlataforma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.pnlParametrosGenerales.ResumeLayout(False)
        Me.pnlParametrosGenerales.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlColores.ResumeLayout(False)
        Me.pnlColores.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlSinPlataforma As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
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
    Friend WithEvents txtResumenInforme_SinCarrito As System.Windows.Forms.TextBox
    Friend WithEvents gboxListadoCodigosCorrectos As System.Windows.Forms.GroupBox
    Friend WithEvents gboxListaCodigos As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaCodigos_SinPlataforma As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlParametrosGenerales As System.Windows.Forms.Panel
    Friend WithEvents cboxAlmacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboxNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblEstibas As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblColaboradorNombre As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblUltimaActualizacion As System.Windows.Forms.Label
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
    Friend WithEvents gridListaCodigosCorrectos_SinCarrito As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnUbicacionProducto As System.Windows.Forms.Button
    Friend WithEvents lblParesApartado As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblApartados As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents tabCon_Sin_Plataforma As System.Windows.Forms.TabControl
    Friend WithEvents tpgSinPlataforma As System.Windows.Forms.TabPage
    Friend WithEvents tpgConPlataforma As System.Windows.Forms.TabPage
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaCodigosCorrectos_ConCarrito As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents gridListaCodigos_ConPlataforma As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnValidar_Plataforma As System.Windows.Forms.Button
    Friend WithEvents gridListaPlataforma As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblPlataformasValidas As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents lblInvalidosConCarrito As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents lblCodigoInexistenteEnPlataforma As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblAtadosConCarrito As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents lblErroresConCarrito As System.Windows.Forms.Label
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblEstibasConCarrito As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtResumenInforme_ConCarrito As System.Windows.Forms.TextBox
    Friend WithEvents lblRecuperadosConCarrito As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents pnlColores As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As PictureBox
End Class
