<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ComprasPTIngresado_VerificarExistenciasSAP_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComprasPTIngresado_VerificarExistenciasSAP_Form))
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblTotalArticulosFaltantesSAP = New System.Windows.Forms.Label()
        Me.lblArticulosFaltantesSAP = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpfechaFin = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaAl = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaDel = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblImportarInventarioSAP = New System.Windows.Forms.Label()
        Me.btnImportarInventario = New System.Windows.Forms.Button()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdArticulosCompra = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdArticulosCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(8, 31)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(10, 13)
        Me.lblUltimaActualizacion.TabIndex = 160
        Me.lblUltimaActualizacion.Text = "-"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiar.Image = Global.Proveedor.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(194, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(16, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(102, 13)
        Me.Label31.TabIndex = 159
        Me.Label31.Text = "Última Actualización"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLimpiar.Location = New System.Drawing.Point(191, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 4
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(238, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(237, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlDatosBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.Label31)
        Me.pnlDatosBotones.Controls.Add(Me.lblLimpiar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(755, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(286, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.lblTotalArticulosFaltantesSAP)
        Me.pnlPie.Controls.Add(Me.lblArticulosFaltantesSAP)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 488)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1041, 60)
        Me.pnlPie.TabIndex = 55
        '
        'lblTotalArticulosFaltantesSAP
        '
        Me.lblTotalArticulosFaltantesSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalArticulosFaltantesSAP.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalArticulosFaltantesSAP.Location = New System.Drawing.Point(22, 35)
        Me.lblTotalArticulosFaltantesSAP.Name = "lblTotalArticulosFaltantesSAP"
        Me.lblTotalArticulosFaltantesSAP.Size = New System.Drawing.Size(120, 24)
        Me.lblTotalArticulosFaltantesSAP.TabIndex = 187
        Me.lblTotalArticulosFaltantesSAP.Text = "0"
        Me.lblTotalArticulosFaltantesSAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArticulosFaltantesSAP
        '
        Me.lblArticulosFaltantesSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulosFaltantesSAP.ForeColor = System.Drawing.Color.Black
        Me.lblArticulosFaltantesSAP.Location = New System.Drawing.Point(8, 4)
        Me.lblArticulosFaltantesSAP.Name = "lblArticulosFaltantesSAP"
        Me.lblArticulosFaltantesSAP.Size = New System.Drawing.Size(153, 32)
        Me.lblArticulosFaltantesSAP.TabIndex = 186
        Me.lblArticulosFaltantesSAP.Text = "Artículos Faltantes en SAP"
        Me.lblArticulosFaltantesSAP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(215, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(262, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Existencias Requeridas en SAP"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(488, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(553, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.btnExportarExcel)
        Me.Panel14.Controls.Add(Me.lblExportar)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(534, 65)
        Me.Panel14.TabIndex = 3
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(23, 9)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 100
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(17, 39)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 99
        Me.lblExportar.Text = "Exportar"
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.GroupBox2)
        Me.pnlParametros.Controls.Add(Me.GroupBox1)
        Me.pnlParametros.Controls.Add(Me.Panel5)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1041, 96)
        Me.pnlParametros.TabIndex = 56
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbRazonSocial)
        Me.GroupBox2.Location = New System.Drawing.Point(197, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(364, 79)
        Me.GroupBox2.TabIndex = 152
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Razón Social Receptor"
        '
        'cmbRazonSocial
        '
        Me.cmbRazonSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRazonSocial.FormattingEnabled = True
        Me.cmbRazonSocial.Items.AddRange(New Object() {"", "ACTIVO", "CANCELADO", "CONFIRMADO", "EN EJECUCIÓN", "PARCIALMENTE CONFIRMADO"})
        Me.cmbRazonSocial.Location = New System.Drawing.Point(17, 30)
        Me.cmbRazonSocial.Name = "cmbRazonSocial"
        Me.cmbRazonSocial.Size = New System.Drawing.Size(331, 21)
        Me.cmbRazonSocial.TabIndex = 147
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpfechaFin)
        Me.GroupBox1.Controls.Add(Me.lblFechaAl)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaDel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(172, 79)
        Me.GroupBox1.TabIndex = 151
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha de Ingreso"
        '
        'dtpfechaFin
        '
        Me.dtpfechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechaFin.Location = New System.Drawing.Point(56, 48)
        Me.dtpfechaFin.Name = "dtpfechaFin"
        Me.dtpfechaFin.Size = New System.Drawing.Size(98, 20)
        Me.dtpfechaFin.TabIndex = 152
        '
        'lblFechaAl
        '
        Me.lblFechaAl.AutoSize = True
        Me.lblFechaAl.Location = New System.Drawing.Point(29, 51)
        Me.lblFechaAl.Name = "lblFechaAl"
        Me.lblFechaAl.Size = New System.Drawing.Size(19, 13)
        Me.lblFechaAl.TabIndex = 150
        Me.lblFechaAl.Text = "Al:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(56, 21)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaInicio.TabIndex = 149
        '
        'lblFechaDel
        '
        Me.lblFechaDel.AutoSize = True
        Me.lblFechaDel.Location = New System.Drawing.Point(26, 23)
        Me.lblFechaDel.Name = "lblFechaDel"
        Me.lblFechaDel.Size = New System.Drawing.Size(26, 13)
        Me.lblFechaDel.TabIndex = 148
        Me.lblFechaDel.Text = "Del:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblImportarInventarioSAP)
        Me.Panel5.Controls.Add(Me.btnImportarInventario)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(919, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(122, 96)
        Me.Panel5.TabIndex = 150
        '
        'lblImportarInventarioSAP
        '
        Me.lblImportarInventarioSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblImportarInventarioSAP.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImportarInventarioSAP.Location = New System.Drawing.Point(17, 52)
        Me.lblImportarInventarioSAP.Name = "lblImportarInventarioSAP"
        Me.lblImportarInventarioSAP.Size = New System.Drawing.Size(86, 26)
        Me.lblImportarInventarioSAP.TabIndex = 184
        Me.lblImportarInventarioSAP.Text = "Importar Inventario SAP"
        Me.lblImportarInventarioSAP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImportarInventario
        '
        Me.btnImportarInventario.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImportarInventario.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImportarInventario.Image = Global.Proveedor.Vista.My.Resources.Resources.Importarexcel_32
        Me.btnImportarInventario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarInventario.Location = New System.Drawing.Point(41, 15)
        Me.btnImportarInventario.Name = "btnImportarInventario"
        Me.btnImportarInventario.Size = New System.Drawing.Size(32, 32)
        Me.btnImportarInventario.TabIndex = 102
        Me.btnImportarInventario.UseVisualStyleBackColor = True
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(418, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1041, 65)
        Me.pnlEncabezado.TabIndex = 54
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdArticulosCompra)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 161)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1041, 327)
        Me.Panel1.TabIndex = 57
        '
        'grdArticulosCompra
        '
        Me.grdArticulosCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdArticulosCompra.Location = New System.Drawing.Point(0, 0)
        Me.grdArticulosCompra.MainView = Me.vwReporte
        Me.grdArticulosCompra.Name = "grdArticulosCompra"
        Me.grdArticulosCompra.Size = New System.Drawing.Size(1041, 327)
        Me.grdArticulosCompra.TabIndex = 58
        Me.grdArticulosCompra.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte})
        '
        'vwReporte
        '
        Me.vwReporte.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.vwReporte.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwReporte.GridControl = Me.grdArticulosCompra
        Me.vwReporte.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.vwReporte.IndicatorWidth = 25
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsBehavior.Editable = False
        Me.vwReporte.OptionsCustomization.AllowColumnMoving = False
        Me.vwReporte.OptionsCustomization.AllowGroup = False
        Me.vwReporte.OptionsMenu.EnableColumnMenu = False
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsView.EnableAppearanceEvenRow = True
        Me.vwReporte.OptionsView.EnableAppearanceOddRow = True
        Me.vwReporte.OptionsView.ShowAutoFilterRow = True
        Me.vwReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwReporte.OptionsView.ShowDetailButtons = False
        Me.vwReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwReporte.OptionsView.ShowFooter = True
        Me.vwReporte.OptionsView.ShowGroupPanel = False
        Me.vwReporte.OptionsView.ShowIndicator = False
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(485, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 91
        Me.pbYuyin.TabStop = False
        '
        'ComprasPTIngresado_VerificarExistenciasSAP_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 548)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ComprasPTIngresado_VerificarExistenciasSAP_Form"
        Me.Text = "Existencia SAP"
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdArticulosCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblUltimaActualizacion As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents Label31 As Windows.Forms.Label
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents lblTotalArticulosFaltantesSAP As Windows.Forms.Label
    Friend WithEvents lblArticulosFaltantesSAP As Windows.Forms.Label
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents Panel14 As Windows.Forms.Panel
    Friend WithEvents btnExportarExcel As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlParametros As Windows.Forms.Panel
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents cmbRazonSocial As Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents dtpfechaFin As Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaAl As Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaDel As Windows.Forms.Label
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents lblImportarInventarioSAP As Windows.Forms.Label
    Friend WithEvents btnImportarInventario As Windows.Forms.Button
    Friend WithEvents pnlAccionesCabecera As Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As Windows.Forms.Panel
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents grdArticulosCompra As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
