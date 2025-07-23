<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MuestrarioClientesform
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MuestrarioClientesform))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdClientes = New DevExpress.XtraGrid.GridControl()
        Me.vwClientes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBanner.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-42, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(468, 63)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(400, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(286, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(74, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Clientes"
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(426, 63)
        Me.pnlBanner.TabIndex = 64
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.pnlDatosBotones)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 401)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(426, 73)
        Me.Panel3.TabIndex = 120
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(264, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 73)
        Me.pnlDatosBotones.TabIndex = 141
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(94, 15)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 17
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(94, 49)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 16
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdClientes
        '
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdClientes.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdClientes.Location = New System.Drawing.Point(0, 63)
        Me.grdClientes.MainView = Me.vwClientes
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(426, 338)
        Me.grdClientes.TabIndex = 124
        Me.grdClientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwClientes, Me.GridView2, Me.GridView5})
        '
        'vwClientes
        '
        Me.vwClientes.GridControl = Me.grdClientes
        Me.vwClientes.Name = "vwClientes"
        Me.vwClientes.OptionsSelection.MultiSelect = True
        Me.vwClientes.OptionsView.ShowAutoFilterRow = True
        Me.vwClientes.OptionsView.ShowFooter = True
        Me.vwClientes.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35, Me.GridColumn36, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn52, Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58})
        Me.GridView2.GridControl = Me.grdClientes
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView2.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowFooter = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = """"
        Me.GridColumn2.FieldName = "Seleccionar"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 35
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "OT"
        Me.GridColumn31.FieldName = "OT"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 1
        Me.GridColumn31.Width = 70
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "OTSICY"
        Me.GridColumn32.FieldName = "OTSICY"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 2
        Me.GridColumn32.Width = 70
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Cliente"
        Me.GridColumn33.FieldName = "Cliente"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 3
        Me.GridColumn33.Width = 220
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Agente"
        Me.GridColumn34.FieldName = "Agente"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 4
        Me.GridColumn34.Width = 80
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "STATUS"
        Me.GridColumn35.FieldName = "STATUS"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 5
        Me.GridColumn35.Width = 90
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Tipo OT"
        Me.GridColumn36.FieldName = "TipoOT"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 6
        Me.GridColumn36.Width = 70
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Pedido SAY"
        Me.GridColumn37.FieldName = "PedidoSAY"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.AllowEdit = False
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 7
        Me.GridColumn37.Width = 80
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Pedido SICY"
        Me.GridColumn38.FieldName = "PedidoSICY"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.OptionsColumn.AllowEdit = False
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 8
        Me.GridColumn38.Width = 80
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Orden Cliente"
        Me.GridColumn39.FieldName = "OrdenCliente"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsColumn.AllowEdit = False
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 9
        Me.GridColumn39.Width = 90
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Fecha Entrega Programación"
        Me.GridColumn40.FieldName = "FechaEntregaProgramacion"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.OptionsColumn.AllowEdit = False
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 10
        Me.GridColumn40.Width = 120
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Fecha Preparación"
        Me.GridColumn41.FieldName = "FechaPreparacion"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsColumn.AllowEdit = False
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 11
        Me.GridColumn41.Width = 120
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Cantidad"
        Me.GridColumn42.FieldName = "Cantidad"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsColumn.AllowEdit = False
        Me.GridColumn42.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 12
        Me.GridColumn42.Width = 80
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Confirmados"
        Me.GridColumn43.FieldName = "Confirmados"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.OptionsColumn.AllowEdit = False
        Me.GridColumn43.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 13
        Me.GridColumn43.Width = 80
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Por Confirmar"
        Me.GridColumn44.FieldName = "PorConfirmar"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        Me.GridColumn44.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 14
        Me.GridColumn44.Width = 90
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Cancelados"
        Me.GridColumn45.FieldName = "Cancelados"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        Me.GridColumn45.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 15
        Me.GridColumn45.Width = 80
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "Usuario Captura"
        Me.GridColumn46.FieldName = "UsuarioCaptura"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsColumn.AllowEdit = False
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 16
        Me.GridColumn46.Width = 90
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "Fecha Captura"
        Me.GridColumn47.FieldName = "FechaCaptura"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.OptionsColumn.AllowEdit = False
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 17
        Me.GridColumn47.Width = 120
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Cita"
        Me.GridColumn48.FieldName = "Cita"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsColumn.AllowEdit = False
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 18
        Me.GridColumn48.Width = 50
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Usuario Modifico"
        Me.GridColumn49.FieldName = "UsuarioModifico"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsColumn.AllowEdit = False
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 19
        Me.GridColumn49.Width = 90
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Fecha Modificación"
        Me.GridColumn50.FieldName = "FechaModificacion"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.OptionsColumn.AllowEdit = False
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 20
        Me.GridColumn50.Width = 120
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "Dias Faltantes"
        Me.GridColumn51.FieldName = "DiasFaltantes"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.OptionsColumn.AllowEdit = False
        Me.GridColumn51.Visible = True
        Me.GridColumn51.VisibleIndex = 21
        Me.GridColumn51.Width = 90
        '
        'GridColumn52
        '
        Me.GridColumn52.Caption = "BE"
        Me.GridColumn52.FieldName = "BE"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.OptionsColumn.AllowEdit = False
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 22
        Me.GridColumn52.Width = 50
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "Motivo Cancelación"
        Me.GridColumn53.FieldName = "MotivoCancelacion"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.OptionsColumn.AllowEdit = False
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 23
        Me.GridColumn53.Width = 100
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "EstatusID"
        Me.GridColumn54.FieldName = "EstatusID"
        Me.GridColumn54.Name = "GridColumn54"
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "ClaveCitaEntrega"
        Me.GridColumn55.FieldName = "ClaveCitaEntrega"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 24
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "GridColumn3"
        Me.GridColumn56.FieldName = "Observaciones"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.Visible = True
        Me.GridColumn56.VisibleIndex = 25
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "FechaCitaEntrega"
        Me.GridColumn57.FieldName = "FechaCitaEntrega"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.Visible = True
        Me.GridColumn57.VisibleIndex = 26
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "HoraCita"
        Me.GridColumn58.FieldName = "HoraCita"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 27
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.grdClientes
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView5.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView5.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView5.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView5.OptionsSelection.MultiSelect = True
        Me.GridView5.OptionsView.ColumnAutoWidth = False
        Me.GridView5.OptionsView.ShowAutoFilterRow = True
        Me.GridView5.OptionsView.ShowFooter = True
        '
        'MuestrarioClientesform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 474)
        Me.Controls.Add(Me.grdClientes)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlBanner)
        Me.KeyPreview = True
        Me.Name = "MuestrarioClientesform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBanner.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents grdClientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwClientes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
End Class
