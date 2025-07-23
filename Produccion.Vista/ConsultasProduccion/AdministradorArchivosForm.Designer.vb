<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorArchivosForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorArchivosForm))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEdita = New System.Windows.Forms.Label()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlElimina = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblElimina = New System.Windows.Forms.Label()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblTituloT = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlFT = New System.Windows.Forms.Panel()
        Me.pnlOT = New System.Windows.Forms.Panel()
        Me.grdOtrosArchivos = New DevExpress.XtraGrid.GridControl()
        Me.vwOtrosArchivos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdArchivo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NombreArchivo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Categoria = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Icono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Documento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoDocumento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IdCategoria = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdFichasTecnicas = New DevExpress.XtraGrid.GridControl()
        Me.vwFichasTecnicas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ProductoEstiloId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MarcaSAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColeccionSAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ModeloSAY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ModeloSICY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PielColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Talla = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Temporada = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.nArchivos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.icono_ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.rbOtrosArchivos = New System.Windows.Forms.RadioButton()
        Me.rbFichasTecnicas = New System.Windows.Forms.RadioButton()
        Me.cmbColeccion = New System.Windows.Forms.ComboBox()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblColeccion = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.cMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEditar.SuspendLayout()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlElimina.SuspendLayout()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlFT.SuspendLayout()
        Me.pnlOT.SuspendLayout()
        CType(Me.grdOtrosArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwOtrosArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFichasTecnicas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwFichasTecnicas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.cMenu.SuspendLayout()
        Me.SuspendLayout()
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
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1145, 65)
        Me.Panel6.TabIndex = 2
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEdita)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEditar.Location = New System.Drawing.Point(45, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(46, 65)
        Me.pnlEditar.TabIndex = 164
        Me.pnlEditar.Visible = False
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
        'lblEdita
        '
        Me.lblEdita.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEdita.AutoSize = True
        Me.lblEdita.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEdita.Location = New System.Drawing.Point(6, 44)
        Me.lblEdita.Name = "lblEdita"
        Me.lblEdita.Size = New System.Drawing.Size(34, 13)
        Me.lblEdita.TabIndex = 104
        Me.lblEdita.Text = "Editar"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        '
        'pnlElimina
        '
        Me.pnlElimina.Controls.Add(Me.btnEliminar)
        Me.pnlElimina.Controls.Add(Me.lblElimina)
        Me.pnlElimina.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlElimina.Location = New System.Drawing.Point(0, 0)
        Me.pnlElimina.Name = "pnlElimina"
        Me.pnlElimina.Size = New System.Drawing.Size(45, 65)
        Me.pnlElimina.TabIndex = 163
        Me.pnlElimina.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnEliminar.Image = Global.Produccion.Vista.My.Resources.Resources.borrar_32
        Me.btnEliminar.Location = New System.Drawing.Point(7, 9)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 103
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblElimina
        '
        Me.lblElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblElimina.AutoSize = True
        Me.lblElimina.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblElimina.Location = New System.Drawing.Point(4, 44)
        Me.lblElimina.Name = "lblElimina"
        Me.lblElimina.Size = New System.Drawing.Size(43, 13)
        Me.lblElimina.TabIndex = 104
        Me.lblElimina.Text = "Eliminar"
        '
        'GridView3
        '
        Me.GridView3.Name = "GridView3"
        '
        'lblTituloT
        '
        Me.lblTituloT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloT.AutoSize = True
        Me.lblTituloT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloT.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTituloT.Location = New System.Drawing.Point(853, 21)
        Me.lblTituloT.Name = "lblTituloT"
        Me.lblTituloT.Size = New System.Drawing.Size(218, 20)
        Me.lblTituloT.TabIndex = 21
        Me.lblTituloT.Text = "Administrador de Archivos"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(4, 91)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(0, 13)
        Me.lblDescripcion.TabIndex = 1
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
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel5)
        Me.pnlEncabezado.Controls.Add(Me.pnlEditar)
        Me.pnlEncabezado.Controls.Add(Me.pnlElimina)
        Me.pnlEncabezado.Controls.Add(Me.lblTituloT)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1145, 65)
        Me.pnlEncabezado.TabIndex = 162
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(1098, 81)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 119
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlFT
        '
        Me.pnlFT.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFT.Controls.Add(Me.pnlOT)
        Me.pnlFT.Controls.Add(Me.grdFichasTecnicas)
        Me.pnlFT.Controls.Add(Me.pnlParametros)
        Me.pnlFT.Controls.Add(Me.Panel2)
        Me.pnlFT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFT.Location = New System.Drawing.Point(0, 0)
        Me.pnlFT.Name = "pnlFT"
        Me.pnlFT.Size = New System.Drawing.Size(1145, 548)
        Me.pnlFT.TabIndex = 163
        '
        'pnlOT
        '
        Me.pnlOT.Controls.Add(Me.grdOtrosArchivos)
        Me.pnlOT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOT.Location = New System.Drawing.Point(0, 155)
        Me.pnlOT.Name = "pnlOT"
        Me.pnlOT.Size = New System.Drawing.Size(1145, 332)
        Me.pnlOT.TabIndex = 164
        '
        'grdOtrosArchivos
        '
        Me.grdOtrosArchivos.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdOtrosArchivos.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdOtrosArchivos.Location = New System.Drawing.Point(0, 0)
        Me.grdOtrosArchivos.MainView = Me.vwOtrosArchivos
        Me.grdOtrosArchivos.Name = "grdOtrosArchivos"
        Me.grdOtrosArchivos.Size = New System.Drawing.Size(1145, 332)
        Me.grdOtrosArchivos.TabIndex = 165
        Me.grdOtrosArchivos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwOtrosArchivos})
        Me.grdOtrosArchivos.Visible = False
        '
        'vwOtrosArchivos
        '
        Me.vwOtrosArchivos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdArchivo, Me.NombreArchivo, Me.Categoria, Me.Icono, Me.Documento, Me.TipoDocumento, Me.IdCategoria})
        Me.vwOtrosArchivos.GridControl = Me.grdOtrosArchivos
        Me.vwOtrosArchivos.IndicatorWidth = 50
        Me.vwOtrosArchivos.Name = "vwOtrosArchivos"
        Me.vwOtrosArchivos.OptionsView.ShowAutoFilterRow = True
        Me.vwOtrosArchivos.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwOtrosArchivos.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwOtrosArchivos.OptionsView.ShowGroupPanel = False
        Me.vwOtrosArchivos.RowHeight = 30
        '
        'IdArchivo
        '
        Me.IdArchivo.Caption = "GridColumn1"
        Me.IdArchivo.FieldName = "IdArchivo"
        Me.IdArchivo.Name = "IdArchivo"
        Me.IdArchivo.OptionsColumn.AllowEdit = False
        Me.IdArchivo.OptionsColumn.ShowInExpressionEditor = False
        Me.IdArchivo.OptionsFilter.AllowAutoFilter = False
        Me.IdArchivo.OptionsFilter.AllowFilter = False
        '
        'NombreArchivo
        '
        Me.NombreArchivo.Caption = "Nombre"
        Me.NombreArchivo.FieldName = "NombreArchivo"
        Me.NombreArchivo.Name = "NombreArchivo"
        Me.NombreArchivo.OptionsColumn.AllowEdit = False
        Me.NombreArchivo.Visible = True
        Me.NombreArchivo.VisibleIndex = 0
        '
        'Categoria
        '
        Me.Categoria.Caption = "Categoría"
        Me.Categoria.FieldName = "Categoria"
        Me.Categoria.Name = "Categoria"
        Me.Categoria.OptionsColumn.AllowEdit = False
        Me.Categoria.Visible = True
        Me.Categoria.VisibleIndex = 1
        '
        'Icono
        '
        Me.Icono.FieldName = "Icono"
        Me.Icono.MaxWidth = 80
        Me.Icono.Name = "Icono"
        Me.Icono.OptionsColumn.ShowCaption = False
        Me.Icono.OptionsFilter.AllowAutoFilter = False
        Me.Icono.OptionsFilter.AllowFilter = False
        Me.Icono.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[False]
        Me.Icono.Visible = True
        Me.Icono.VisibleIndex = 2
        '
        'Documento
        '
        Me.Documento.Caption = "Documento"
        Me.Documento.FieldName = "Documento"
        Me.Documento.Name = "Documento"
        Me.Documento.OptionsColumn.AllowEdit = False
        '
        'TipoDocumento
        '
        Me.TipoDocumento.Caption = "TipoDocumento"
        Me.TipoDocumento.FieldName = "TipoDocumento"
        Me.TipoDocumento.Name = "TipoDocumento"
        Me.TipoDocumento.OptionsColumn.AllowEdit = False
        '
        'IdCategoria
        '
        Me.IdCategoria.Caption = "IdCategoria"
        Me.IdCategoria.FieldName = "IdCategoria"
        Me.IdCategoria.Name = "IdCategoria"
        Me.IdCategoria.OptionsColumn.AllowEdit = False
        '
        'grdFichasTecnicas
        '
        Me.grdFichasTecnicas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFichasTecnicas.Location = New System.Drawing.Point(0, 155)
        Me.grdFichasTecnicas.MainView = Me.vwFichasTecnicas
        Me.grdFichasTecnicas.Name = "grdFichasTecnicas"
        Me.grdFichasTecnicas.Size = New System.Drawing.Size(1145, 332)
        Me.grdFichasTecnicas.TabIndex = 12
        Me.grdFichasTecnicas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwFichasTecnicas})
        Me.grdFichasTecnicas.Visible = False
        '
        'vwFichasTecnicas
        '
        Me.vwFichasTecnicas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ProductoEstiloId, Me.MarcaSAY, Me.ColeccionSAY, Me.ModeloSAY, Me.ModeloSICY, Me.PielColor, Me.Talla, Me.Temporada, Me.nArchivos, Me.icono_})
        Me.vwFichasTecnicas.GridControl = Me.grdFichasTecnicas
        Me.vwFichasTecnicas.IndicatorWidth = 50
        Me.vwFichasTecnicas.Name = "vwFichasTecnicas"
        Me.vwFichasTecnicas.OptionsView.ShowAutoFilterRow = True
        Me.vwFichasTecnicas.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwFichasTecnicas.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwFichasTecnicas.OptionsView.ShowGroupPanel = False
        Me.vwFichasTecnicas.RowHeight = 30
        '
        'ProductoEstiloId
        '
        Me.ProductoEstiloId.Caption = "GridColumn1"
        Me.ProductoEstiloId.FieldName = "ProductoEstiloId"
        Me.ProductoEstiloId.Name = "ProductoEstiloId"
        Me.ProductoEstiloId.OptionsColumn.AllowEdit = False
        '
        'MarcaSAY
        '
        Me.MarcaSAY.Caption = "Marca"
        Me.MarcaSAY.FieldName = "MarcaSAY"
        Me.MarcaSAY.Name = "MarcaSAY"
        Me.MarcaSAY.OptionsColumn.AllowEdit = False
        Me.MarcaSAY.Visible = True
        Me.MarcaSAY.VisibleIndex = 0
        '
        'ColeccionSAY
        '
        Me.ColeccionSAY.Caption = "Colección"
        Me.ColeccionSAY.FieldName = "ColeccionSAY"
        Me.ColeccionSAY.Name = "ColeccionSAY"
        Me.ColeccionSAY.OptionsColumn.AllowEdit = False
        Me.ColeccionSAY.Visible = True
        Me.ColeccionSAY.VisibleIndex = 1
        '
        'ModeloSAY
        '
        Me.ModeloSAY.Caption = "Modelo SAY"
        Me.ModeloSAY.FieldName = "ModeloSAY"
        Me.ModeloSAY.Name = "ModeloSAY"
        Me.ModeloSAY.Visible = True
        Me.ModeloSAY.VisibleIndex = 2
        '
        'ModeloSICY
        '
        Me.ModeloSICY.Caption = "Modelo SICY"
        Me.ModeloSICY.FieldName = "ModeloSICY"
        Me.ModeloSICY.Name = "ModeloSICY"
        Me.ModeloSICY.OptionsColumn.AllowEdit = False
        Me.ModeloSICY.Visible = True
        Me.ModeloSICY.VisibleIndex = 3
        '
        'PielColor
        '
        Me.PielColor.Caption = "Piel Color"
        Me.PielColor.FieldName = "PielColor"
        Me.PielColor.Name = "PielColor"
        Me.PielColor.OptionsColumn.AllowEdit = False
        Me.PielColor.Visible = True
        Me.PielColor.VisibleIndex = 4
        '
        'Talla
        '
        Me.Talla.Caption = "Corrida"
        Me.Talla.FieldName = "Talla"
        Me.Talla.Name = "Talla"
        Me.Talla.Visible = True
        Me.Talla.VisibleIndex = 5
        '
        'Temporada
        '
        Me.Temporada.Caption = "Temporada"
        Me.Temporada.FieldName = "Temporada"
        Me.Temporada.Name = "Temporada"
        Me.Temporada.Visible = True
        Me.Temporada.VisibleIndex = 6
        '
        'nArchivos
        '
        Me.nArchivos.Caption = "nArchivos"
        Me.nArchivos.FieldName = "nArchivos"
        Me.nArchivos.Name = "nArchivos"
        Me.nArchivos.OptionsColumn.AllowEdit = False
        '
        'icono_
        '
        Me.icono_.Caption = "Icono"
        Me.icono_.FieldName = "Icono"
        Me.icono_.MaxWidth = 80
        Me.icono_.Name = "icono_"
        Me.icono_.OptionsColumn.ShowCaption = False
        Me.icono_.Visible = True
        Me.icono_.VisibleIndex = 7
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.rbOtrosArchivos)
        Me.pnlParametros.Controls.Add(Me.rbFichasTecnicas)
        Me.pnlParametros.Controls.Add(Me.cmbColeccion)
        Me.pnlParametros.Controls.Add(Me.cmbMarca)
        Me.pnlParametros.Controls.Add(Me.cmbNave)
        Me.pnlParametros.Controls.Add(Me.lblColeccion)
        Me.pnlParametros.Controls.Add(Me.lblMarca)
        Me.pnlParametros.Controls.Add(Me.lblNave)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Controls.Add(Me.lblDescripcion)
        Me.pnlParametros.Controls.Add(Me.btnMostrar)
        Me.pnlParametros.Controls.Add(Me.lblAceptar)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 0)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1145, 155)
        Me.pnlParametros.TabIndex = 163
        '
        'rbOtrosArchivos
        '
        Me.rbOtrosArchivos.AutoSize = True
        Me.rbOtrosArchivos.Location = New System.Drawing.Point(116, 80)
        Me.rbOtrosArchivos.Name = "rbOtrosArchivos"
        Me.rbOtrosArchivos.Size = New System.Drawing.Size(94, 17)
        Me.rbOtrosArchivos.TabIndex = 127
        Me.rbOtrosArchivos.TabStop = True
        Me.rbOtrosArchivos.Text = "Otros Archivos"
        Me.rbOtrosArchivos.UseVisualStyleBackColor = True
        '
        'rbFichasTecnicas
        '
        Me.rbFichasTecnicas.AutoSize = True
        Me.rbFichasTecnicas.Checked = True
        Me.rbFichasTecnicas.Location = New System.Drawing.Point(7, 80)
        Me.rbFichasTecnicas.Name = "rbFichasTecnicas"
        Me.rbFichasTecnicas.Size = New System.Drawing.Size(103, 17)
        Me.rbFichasTecnicas.TabIndex = 126
        Me.rbFichasTecnicas.TabStop = True
        Me.rbFichasTecnicas.Text = "Fichas Técnicas"
        Me.rbFichasTecnicas.UseVisualStyleBackColor = True
        '
        'cmbColeccion
        '
        Me.cmbColeccion.Enabled = False
        Me.cmbColeccion.FormattingEnabled = True
        Me.cmbColeccion.Location = New System.Drawing.Point(520, 107)
        Me.cmbColeccion.Name = "cmbColeccion"
        Me.cmbColeccion.Size = New System.Drawing.Size(318, 21)
        Me.cmbColeccion.TabIndex = 125
        '
        'cmbMarca
        '
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(277, 107)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(174, 21)
        Me.cmbMarca.TabIndex = 124
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(51, 107)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(174, 21)
        Me.cmbNave.TabIndex = 123
        '
        'lblColeccion
        '
        Me.lblColeccion.AutoSize = True
        Me.lblColeccion.Location = New System.Drawing.Point(457, 110)
        Me.lblColeccion.Name = "lblColeccion"
        Me.lblColeccion.Size = New System.Drawing.Size(57, 13)
        Me.lblColeccion.TabIndex = 122
        Me.lblColeccion.Text = "Colección:"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(231, 110)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(40, 13)
        Me.lblMarca.TabIndex = 121
        Me.lblMarca.Text = "Marca:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(9, 110)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 120
        Me.lblNave.Text = "Nave:"
        '
        'lblAceptar
        '
        Me.lblAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(1094, 116)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 118
        Me.lblAceptar.Text = "Mostrar"
        '
        'cMenu
        '
        Me.cMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarToolStripMenuItem, Me.EditarToolStripMenuItem})
        Me.cMenu.Name = "cMenu"
        Me.cMenu.Size = New System.Drawing.Size(111, 48)
        '
        'EliminarToolStripMenuItem
        '
        Me.EliminarToolStripMenuItem.Name = "EliminarToolStripMenuItem"
        Me.EliminarToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.EliminarToolStripMenuItem.Text = "Eliminar"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'AdministradorArchivosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 548)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlFT)
        Me.Name = "AdministradorArchivosForm"
        Me.Text = "AdministradorArchivosForm"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlElimina.ResumeLayout(False)
        Me.pnlElimina.PerformLayout()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlFT.ResumeLayout(False)
        Me.pnlOT.ResumeLayout(False)
        CType(Me.grdOtrosArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwOtrosArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFichasTecnicas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwFichasTecnicas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.cMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblSalir As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlEditar As Panel
    Friend WithEvents btnEditar As Button
    Friend WithEvents lblEdita As Label
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlElimina As Panel
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblElimina As Label
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblTituloT As Label
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents pnlFT As Panel
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents lblAceptar As Label
    Friend WithEvents cmbColeccion As ComboBox
    Friend WithEvents cmbMarca As ComboBox
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents lblColeccion As Label
    Friend WithEvents lblMarca As Label
    Friend WithEvents lblNave As Label
    Friend WithEvents rbOtrosArchivos As RadioButton
    Friend WithEvents rbFichasTecnicas As RadioButton
    Friend WithEvents pnlOT As Panel
    Friend WithEvents grdOtrosArchivos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwOtrosArchivos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IdArchivo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NombreArchivo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Categoria As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Icono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdFichasTecnicas As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwFichasTecnicas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ProductoEstiloId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MarcaSAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColeccionSAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ModeloSAY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ModeloSICY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PielColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Talla As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Temporada As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents nArchivos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents icono_ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Documento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoDocumento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IdCategoria As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cMenu As ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
End Class
