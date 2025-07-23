<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorArchivosTecnicosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorArchivosTecnicosForm))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.Departamento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Documento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoDocumento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IdDepartamento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.lblDes = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.Icono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NombreArchivo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEdita = New System.Windows.Forms.Label()
        Me.pnlElimina = New System.Windows.Forms.Panel()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblElimina = New System.Windows.Forms.Label()
        Me.lblTituloT = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlFT = New System.Windows.Forms.Panel()
        Me.grdArchivosTecnicos = New DevExpress.XtraGrid.GridControl()
        Me.vwArchivosTecnicos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdArchivo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlParametros.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlElimina.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFT.SuspendLayout()
        CType(Me.grdArchivosTecnicos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwArchivosTecnicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Departamento
        '
        Me.Departamento.Caption = "Departamento"
        Me.Departamento.FieldName = "Departamento"
        Me.Departamento.Name = "Departamento"
        Me.Departamento.OptionsColumn.AllowEdit = False
        Me.Departamento.Visible = True
        Me.Departamento.VisibleIndex = 1
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
        'IdDepartamento
        '
        Me.IdDepartamento.Caption = "IdDepartamento"
        Me.IdDepartamento.FieldName = "IdDepartamento"
        Me.IdDepartamento.Name = "IdDepartamento"
        Me.IdDepartamento.OptionsColumn.AllowEdit = False
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.lblDes)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Controls.Add(Me.lblDescripcion)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 0)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1145, 123)
        Me.pnlParametros.TabIndex = 163
        '
        'lblDes
        '
        Me.lblDes.AutoSize = True
        Me.lblDes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDes.Location = New System.Drawing.Point(4, 89)
        Me.lblDes.Name = "lblDes"
        Me.lblDes.Size = New System.Drawing.Size(12, 15)
        Me.lblDes.TabIndex = 3
        Me.lblDes.Text = "-"
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1145, 65)
        Me.Panel6.TabIndex = 2
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(4, 91)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(0, 13)
        Me.lblDescripcion.TabIndex = 1
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
        'NombreArchivo
        '
        Me.NombreArchivo.Caption = "Nombre"
        Me.NombreArchivo.FieldName = "NombreArchivo"
        Me.NombreArchivo.Name = "NombreArchivo"
        Me.NombreArchivo.OptionsColumn.AllowEdit = False
        Me.NombreArchivo.Visible = True
        Me.NombreArchivo.VisibleIndex = 0
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
        Me.pnlEncabezado.TabIndex = 164
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
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEdita)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEditar.Location = New System.Drawing.Point(45, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(46, 65)
        Me.pnlEditar.TabIndex = 164
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
        'pnlElimina
        '
        Me.pnlElimina.Controls.Add(Me.btnEliminar)
        Me.pnlElimina.Controls.Add(Me.lblElimina)
        Me.pnlElimina.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlElimina.Location = New System.Drawing.Point(0, 0)
        Me.pnlElimina.Name = "pnlElimina"
        Me.pnlElimina.Size = New System.Drawing.Size(45, 65)
        Me.pnlElimina.TabIndex = 163
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
        'lblTituloT
        '
        Me.lblTituloT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTituloT.AutoSize = True
        Me.lblTituloT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloT.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTituloT.Location = New System.Drawing.Point(719, 21)
        Me.lblTituloT.Name = "lblTituloT"
        Me.lblTituloT.Size = New System.Drawing.Size(352, 20)
        Me.lblTituloT.TabIndex = 21
        Me.lblTituloT.Text = "Administrador de Archivos Fichas Técnicas"
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
        'pnlFT
        '
        Me.pnlFT.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFT.Controls.Add(Me.grdArchivosTecnicos)
        Me.pnlFT.Controls.Add(Me.pnlParametros)
        Me.pnlFT.Controls.Add(Me.Panel2)
        Me.pnlFT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFT.Location = New System.Drawing.Point(0, 0)
        Me.pnlFT.Name = "pnlFT"
        Me.pnlFT.Size = New System.Drawing.Size(1145, 548)
        Me.pnlFT.TabIndex = 165
        '
        'grdArchivosTecnicos
        '
        Me.grdArchivosTecnicos.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdArchivosTecnicos.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdArchivosTecnicos.Location = New System.Drawing.Point(0, 123)
        Me.grdArchivosTecnicos.MainView = Me.vwArchivosTecnicos
        Me.grdArchivosTecnicos.Name = "grdArchivosTecnicos"
        Me.grdArchivosTecnicos.Size = New System.Drawing.Size(1145, 364)
        Me.grdArchivosTecnicos.TabIndex = 165
        Me.grdArchivosTecnicos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwArchivosTecnicos})
        '
        'vwArchivosTecnicos
        '
        Me.vwArchivosTecnicos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdArchivo, Me.NombreArchivo, Me.Departamento, Me.Icono, Me.Documento, Me.TipoDocumento, Me.IdDepartamento})
        Me.vwArchivosTecnicos.GridControl = Me.grdArchivosTecnicos
        Me.vwArchivosTecnicos.IndicatorWidth = 50
        Me.vwArchivosTecnicos.Name = "vwArchivosTecnicos"
        Me.vwArchivosTecnicos.OptionsView.ShowAutoFilterRow = True
        Me.vwArchivosTecnicos.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwArchivosTecnicos.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwArchivosTecnicos.OptionsView.ShowGroupPanel = False
        Me.vwArchivosTecnicos.RowHeight = 30
        '
        'IdArchivo
        '
        Me.IdArchivo.Caption = "GridColumn1"
        Me.IdArchivo.FieldName = "IdArchivo"
        Me.IdArchivo.Name = "IdArchivo"
        Me.IdArchivo.OptionsColumn.AllowEdit = False
        Me.IdArchivo.OptionsColumn.ShowInExpressionEditor = False
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
        'AdministradorArchivosTecnicosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 548)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlFT)
        Me.Name = "AdministradorArchivosTecnicosForm"
        Me.Text = "AdministradorArchivosTecnicosForm"
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlElimina.ResumeLayout(False)
        Me.pnlElimina.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFT.ResumeLayout(False)
        CType(Me.grdArchivosTecnicos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwArchivosTecnicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Departamento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Documento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoDocumento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IdDepartamento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblDescripcion As Label
    Friend WithEvents Icono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NombreArchivo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlEditar As Panel
    Friend WithEvents btnEditar As Button
    Friend WithEvents lblEdita As Label
    Friend WithEvents pnlElimina As Panel
    Friend WithEvents btnEliminar As Button
    Friend WithEvents lblElimina As Label
    Friend WithEvents lblTituloT As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblSalir As Label
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlFT As Panel
    Friend WithEvents grdArchivosTecnicos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwArchivosTecnicos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IdArchivo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblDes As Label
    Friend WithEvents cMenu As ContextMenuStrip
    Friend WithEvents EliminarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
End Class
