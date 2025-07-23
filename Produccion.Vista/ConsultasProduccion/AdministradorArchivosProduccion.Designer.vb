<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdministradorArchivosProduccion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorArchivosProduccion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdAdminArchivos = New DevExpress.XtraGrid.GridControl()
        Me.vwAdminArchivos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Num = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NombreDocumento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Departamento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IdArchivo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Documento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IdDepartamento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoDocumento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.gpbArticulos = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdDescripcion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTituloT = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTituloOtros = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.grdAdminArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwAdminArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.gpbArticulos.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.grdDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.grdAdminArchivos)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1145, 548)
        Me.Panel1.TabIndex = 161
        '
        'grdAdminArchivos
        '
        Me.grdAdminArchivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAdminArchivos.Location = New System.Drawing.Point(0, 208)
        Me.grdAdminArchivos.MainView = Me.vwAdminArchivos
        Me.grdAdminArchivos.Name = "grdAdminArchivos"
        Me.grdAdminArchivos.Size = New System.Drawing.Size(1145, 279)
        Me.grdAdminArchivos.TabIndex = 12
        Me.grdAdminArchivos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwAdminArchivos})
        '
        'vwAdminArchivos
        '
        Me.vwAdminArchivos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Num, Me.NombreDocumento, Me.Departamento, Me.IdArchivo, Me.Documento, Me.IdDepartamento, Me.TipoDocumento})
        Me.vwAdminArchivos.GridControl = Me.grdAdminArchivos
        Me.vwAdminArchivos.Name = "vwAdminArchivos"
        Me.vwAdminArchivos.OptionsBehavior.Editable = False
        Me.vwAdminArchivos.OptionsView.ShowAutoFilterRow = True
        Me.vwAdminArchivos.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwAdminArchivos.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        '
        'Num
        '
        Me.Num.AppearanceHeader.Options.UseTextOptions = True
        Me.Num.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Num.Caption = "#"
        Me.Num.FieldName = "Num"
        Me.Num.Name = "Num"
        Me.Num.Visible = True
        Me.Num.VisibleIndex = 0
        Me.Num.Width = 30
        '
        'NombreDocumento
        '
        Me.NombreDocumento.AppearanceHeader.Options.UseTextOptions = True
        Me.NombreDocumento.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.NombreDocumento.Caption = "NOMBRE DOCUMENTO "
        Me.NombreDocumento.FieldName = "NombreDocumento"
        Me.NombreDocumento.Name = "NombreDocumento"
        Me.NombreDocumento.Visible = True
        Me.NombreDocumento.VisibleIndex = 1
        Me.NombreDocumento.Width = 215
        '
        'Departamento
        '
        Me.Departamento.AppearanceHeader.Options.UseTextOptions = True
        Me.Departamento.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Departamento.Caption = "DEPARTAMENTO"
        Me.Departamento.FieldName = "Departamento"
        Me.Departamento.Name = "Departamento"
        Me.Departamento.Visible = True
        Me.Departamento.VisibleIndex = 2
        Me.Departamento.Width = 221
        '
        'IdArchivo
        '
        Me.IdArchivo.Caption = "ID"
        Me.IdArchivo.FieldName = "IdArchivo"
        Me.IdArchivo.Name = "IdArchivo"
        '
        'Documento
        '
        Me.Documento.Caption = "DOCUMENTO"
        Me.Documento.FieldName = "DOCUMENTO"
        Me.Documento.Name = "Documento"
        '
        'IdDepartamento
        '
        Me.IdDepartamento.Caption = "ID DEPARTAMENTO"
        Me.IdDepartamento.FieldName = "IdDepartamento"
        Me.IdDepartamento.Name = "IdDepartamento"
        '
        'TipoDocumento
        '
        Me.TipoDocumento.Caption = "TIPO DOCUMENTO"
        Me.TipoDocumento.FieldName = "TipoDocumento"
        Me.TipoDocumento.Name = "TipoDocumento"
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.gpbArticulos)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Controls.Add(Me.lblDescripcion)
        Me.pnlParametros.Controls.Add(Me.btnMostrar)
        Me.pnlParametros.Controls.Add(Me.lblAceptar)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 0)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1145, 208)
        Me.pnlParametros.TabIndex = 163
        '
        'gpbArticulos
        '
        Me.gpbArticulos.Controls.Add(Me.Panel7)
        Me.gpbArticulos.Location = New System.Drawing.Point(15, 108)
        Me.gpbArticulos.Name = "gpbArticulos"
        Me.gpbArticulos.Size = New System.Drawing.Size(462, 94)
        Me.gpbArticulos.TabIndex = 115
        Me.gpbArticulos.TabStop = False
        Me.gpbArticulos.Text = "Artículos"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.grdDescripcion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 25)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(456, 66)
        Me.Panel7.TabIndex = 2
        '
        'grdDescripcion
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDescripcion.DisplayLayout.Appearance = Appearance1
        Me.grdDescripcion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.grdDescripcion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDescripcion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDescripcion.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdDescripcion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDescripcion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDescripcion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDescripcion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdDescripcion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDescripcion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDescripcion.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDescripcion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDescripcion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDescripcion.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdDescripcion.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.grdDescripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDescripcion.Location = New System.Drawing.Point(0, 0)
        Me.grdDescripcion.Name = "grdDescripcion"
        Me.grdDescripcion.Size = New System.Drawing.Size(456, 66)
        Me.grdDescripcion.TabIndex = 6
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1145, 104)
        Me.Panel6.TabIndex = 2
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Image = Global.Produccion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(1092, 71)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 40
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Image = Global.Produccion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(1118, 71)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 39
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(4, 91)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(0, 13)
        Me.lblDescripcion.TabIndex = 1
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(1106, 135)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 119
        Me.btnMostrar.UseVisualStyleBackColor = True
        Me.btnMostrar.Visible = False
        '
        'lblAceptar
        '
        Me.lblAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(1101, 167)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 118
        Me.lblAceptar.Text = "Mostrar"
        Me.lblAceptar.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.lblSalir)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 487)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1145, 61)
        Me.Panel2.TabIndex = 162
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(1098, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 101
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(1097, 40)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 102
        Me.lblSalir.Text = "Cerrar"
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'GridView3
        '
        Me.GridView3.Name = "GridView3"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(1077, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblTituloT
        '
        Me.lblTituloT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloT.AutoSize = True
        Me.lblTituloT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloT.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTituloT.Location = New System.Drawing.Point(792, 19)
        Me.lblTituloT.Name = "lblTituloT"
        Me.lblTituloT.Size = New System.Drawing.Size(279, 20)
        Me.lblTituloT.TabIndex = 21
        Me.lblTituloT.Text = "Administrador de Fichas Técnicas"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnAlta)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(45, 65)
        Me.Panel3.TabIndex = 163
        '
        'btnAlta
        '
        Me.btnAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAlta.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnAlta.Image = Global.Produccion.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(7, 9)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 103
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Alta"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnEditar)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(45, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(46, 65)
        Me.Panel4.TabIndex = 164
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnEditar.Image = Global.Produccion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(6, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 103
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Editar"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnExportar)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(91, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(50, 65)
        Me.Panel5.TabIndex = 165
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(6, 9)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 103
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(1, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Exportar"
        '
        'lblTituloOtros
        '
        Me.lblTituloOtros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloOtros.AutoSize = True
        Me.lblTituloOtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloOtros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTituloOtros.Location = New System.Drawing.Point(809, 19)
        Me.lblTituloOtros.Name = "lblTituloOtros"
        Me.lblTituloOtros.Size = New System.Drawing.Size(262, 20)
        Me.lblTituloOtros.TabIndex = 166
        Me.lblTituloOtros.Text = "Administrador de otros archivos"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTituloOtros)
        Me.pnlEncabezado.Controls.Add(Me.Panel5)
        Me.pnlEncabezado.Controls.Add(Me.Panel4)
        Me.pnlEncabezado.Controls.Add(Me.Panel3)
        Me.pnlEncabezado.Controls.Add(Me.lblTituloT)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1145, 65)
        Me.pnlEncabezado.TabIndex = 160
        '
        'AdministradorArchivosProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 548)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AdministradorArchivosProduccion"
        Me.Text = "Administrador de otros archivos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdAdminArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwAdminArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.gpbArticulos.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdAdminArchivos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwAdminArchivos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Num As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NombreDocumento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Departamento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents gpbArticulos As GroupBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents grdDescripcion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnArriba As Button
    Friend WithEvents btnAbajo As Button
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblTituloT As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnAlta As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnEditar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTituloOtros As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents IdArchivo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Documento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IdDepartamento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoDocumento As DevExpress.XtraGrid.Columns.GridColumn
End Class
