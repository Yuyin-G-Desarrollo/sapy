<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistroSuelaTerminada_DetalleSalida_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistroSuelaTerminada_DetalleSalida_Form))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.pnlEnviarEtiquetas = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdFolioSalida = New DevExpress.XtraGrid.GridControl()
        Me.grvFoliosSalida = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.cFolio = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cNave = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cLote = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cFechaPrograma = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cMaterial = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cPares = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.cAño = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.chkSeleccion = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.Panel1.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlEnviarEtiquetas.SuspendLayout()
        CType(Me.grdFolioSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvFoliosSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlExportar)
        Me.Panel1.Controls.Add(Me.pnlTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1094, 66)
        Me.Panel1.TabIndex = 146
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(68, 66)
        Me.pnlExportar.TabIndex = 54
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(17, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 174
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblExportar.Location = New System.Drawing.Point(12, 43)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 173
        Me.lblExportar.Text = "Exportar"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(612, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(482, 66)
        Me.pnlTitulo.TabIndex = 49
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(405, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(77, 66)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 93
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(169, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(222, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Detalle de Salida de Suela"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Panel8)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 605)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1094, 74)
        Me.pnlPie.TabIndex = 147
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.lblRegistrosTitulo)
        Me.Panel8.Controls.Add(Me.lblRegistros)
        Me.Panel8.Location = New System.Drawing.Point(3, 1)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(106, 70)
        Me.Panel8.TabIndex = 190
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(10, 15)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 187
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(10, 40)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 188
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Panel10)
        Me.pnlDatosBotones.Controls.Add(Me.pnlEnviarEtiquetas)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(552, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(542, 74)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblUltimaDistribucion)
        Me.Panel10.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(277, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(200, 74)
        Me.Panel10.TabIndex = 6
        '
        'lblUltimaDistribucion
        '
        Me.lblUltimaDistribucion.AutoSize = True
        Me.lblUltimaDistribucion.Location = New System.Drawing.Point(57, 39)
        Me.lblUltimaDistribucion.Name = "lblUltimaDistribucion"
        Me.lblUltimaDistribucion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaDistribucion.TabIndex = 166
        Me.lblUltimaDistribucion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(65, 21)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 165
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'pnlEnviarEtiquetas
        '
        Me.pnlEnviarEtiquetas.Controls.Add(Me.btnCerrar)
        Me.pnlEnviarEtiquetas.Controls.Add(Me.lblCerrar)
        Me.pnlEnviarEtiquetas.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEnviarEtiquetas.Location = New System.Drawing.Point(477, 0)
        Me.pnlEnviarEtiquetas.Name = "pnlEnviarEtiquetas"
        Me.pnlEnviarEtiquetas.Size = New System.Drawing.Size(65, 74)
        Me.pnlEnviarEtiquetas.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(16, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 174
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(15, 43)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 173
        Me.lblCerrar.Text = "Cerrar"
        Me.lblCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdFolioSalida
        '
        Me.grdFolioSalida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFolioSalida.Location = New System.Drawing.Point(0, 66)
        Me.grdFolioSalida.MainView = Me.grvFoliosSalida
        Me.grdFolioSalida.Name = "grdFolioSalida"
        Me.grdFolioSalida.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkSeleccion, Me.RepositoryItemMemoEdit1, Me.RepositoryItemMemoExEdit1})
        Me.grdFolioSalida.Size = New System.Drawing.Size(1094, 539)
        Me.grdFolioSalida.TabIndex = 149
        Me.grdFolioSalida.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvFoliosSalida})
        '
        'grvFoliosSalida
        '
        Me.grvFoliosSalida.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand2})
        Me.grvFoliosSalida.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.cLote, Me.cAño, Me.cFechaPrograma, Me.cPares, Me.cMaterial, Me.cNave, Me.cFolio})
        Me.grvFoliosSalida.GridControl = Me.grdFolioSalida
        Me.grvFoliosSalida.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.grvFoliosSalida.IndicatorWidth = 40
        Me.grvFoliosSalida.Name = "grvFoliosSalida"
        Me.grvFoliosSalida.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.grvFoliosSalida.OptionsSelection.MultiSelect = True
        Me.grvFoliosSalida.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grvFoliosSalida.OptionsView.RowAutoHeight = True
        Me.grvFoliosSalida.OptionsView.ShowAutoFilterRow = True
        Me.grvFoliosSalida.OptionsView.ShowFooter = True
        Me.grvFoliosSalida.OptionsView.ShowGroupPanel = False
        '
        'GridBand2
        '
        Me.GridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand2.Caption = "INFORMACIÓN GENERAL"
        Me.GridBand2.Columns.Add(Me.cFolio)
        Me.GridBand2.Columns.Add(Me.cNave)
        Me.GridBand2.Columns.Add(Me.cLote)
        Me.GridBand2.Columns.Add(Me.cFechaPrograma)
        Me.GridBand2.Columns.Add(Me.cMaterial)
        Me.GridBand2.Columns.Add(Me.cPares)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 0
        Me.GridBand2.Width = 941
        '
        'cFolio
        '
        Me.cFolio.AppearanceHeader.Options.UseTextOptions = True
        Me.cFolio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cFolio.Caption = "FOLIO"
        Me.cFolio.FieldName = "Folio"
        Me.cFolio.Name = "cFolio"
        Me.cFolio.OptionsColumn.AllowEdit = False
        Me.cFolio.Visible = True
        '
        'cNave
        '
        Me.cNave.AppearanceHeader.Options.UseTextOptions = True
        Me.cNave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cNave.Caption = "NAVE"
        Me.cNave.FieldName = "Nave"
        Me.cNave.Name = "cNave"
        Me.cNave.OptionsColumn.AllowEdit = False
        Me.cNave.Visible = True
        Me.cNave.Width = 94
        '
        'cLote
        '
        Me.cLote.AppearanceHeader.Options.UseTextOptions = True
        Me.cLote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cLote.Caption = "LOTE"
        Me.cLote.FieldName = "Lote"
        Me.cLote.Name = "cLote"
        Me.cLote.OptionsColumn.AllowEdit = False
        Me.cLote.Visible = True
        Me.cLote.Width = 102
        '
        'cFechaPrograma
        '
        Me.cFechaPrograma.AppearanceHeader.Options.UseTextOptions = True
        Me.cFechaPrograma.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cFechaPrograma.Caption = "FECHA PROGRAMA"
        Me.cFechaPrograma.FieldName = "FechaPrograma"
        Me.cFechaPrograma.Name = "cFechaPrograma"
        Me.cFechaPrograma.OptionsColumn.AllowEdit = False
        Me.cFechaPrograma.Visible = True
        Me.cFechaPrograma.Width = 148
        '
        'cMaterial
        '
        Me.cMaterial.AppearanceHeader.Options.UseTextOptions = True
        Me.cMaterial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cMaterial.Caption = "MATERIAL"
        Me.cMaterial.FieldName = "Material"
        Me.cMaterial.Name = "cMaterial"
        Me.cMaterial.OptionsColumn.AllowEdit = False
        Me.cMaterial.Visible = True
        Me.cMaterial.Width = 449
        '
        'cPares
        '
        Me.cPares.AppearanceHeader.Options.UseTextOptions = True
        Me.cPares.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cPares.Caption = "# PARES"
        Me.cPares.DisplayFormat.FormatString = "n0"
        Me.cPares.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cPares.FieldName = "Pares"
        Me.cPares.Name = "cPares"
        Me.cPares.OptionsColumn.AllowEdit = False
        Me.cPares.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:n0}")})
        Me.cPares.Visible = True
        Me.cPares.Width = 73
        '
        'cAño
        '
        Me.cAño.AppearanceHeader.Options.UseTextOptions = True
        Me.cAño.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cAño.Caption = "AÑO"
        Me.cAño.FieldName = "Año"
        Me.cAño.Name = "cAño"
        Me.cAño.OptionsColumn.AllowEdit = False
        Me.cAño.Visible = True
        '
        'chkSeleccion
        '
        Me.chkSeleccion.Name = "chkSeleccion"
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Appearance.Options.UseTextOptions = True
        Me.RepositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.AutoHeight = False
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
        '
        'SalidaLoteSuela_DetalleSalida_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 679)
        Me.Controls.Add(Me.grdFolioSalida)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximumSize = New System.Drawing.Size(1110, 718)
        Me.MinimumSize = New System.Drawing.Size(1110, 718)
        Me.Name = "SalidaLoteSuela_DetalleSalida_Form"
        Me.Text = "Detalle de Salida de Suela"
        Me.Panel1.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlEnviarEtiquetas.ResumeLayout(False)
        Me.pnlEnviarEtiquetas.PerformLayout()
        CType(Me.grdFolioSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvFoliosSalida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents grdFolioSalida As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvFoliosSalida As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents chkSeleccion As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents cLote As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents cAño As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents cFechaPrograma As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents cPares As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents cMaterial As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents cNave As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents cFolio As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents pnlEnviarEtiquetas As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents lblUltimaDistribucion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
End Class
