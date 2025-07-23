<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CostosPorMaquilaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CostosPorMaquilaForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnConfigPorcentaje = New System.Windows.Forms.Button()
        Me.Imprimir = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.LblTipoReporte = New System.Windows.Forms.Label()
        Me.pnlMostrar = New System.Windows.Forms.Panel()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.gpbSemana = New System.Windows.Forms.GroupBox()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.lblaño = New System.Windows.Forms.Label()
        Me.nudSemanaFinal = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblde = New System.Windows.Forms.Label()
        Me.nudSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.gpbAgrupamiento = New System.Windows.Forms.GroupBox()
        Me.rdoFVO = New System.Windows.Forms.RadioButton()
        Me.rdoRVO = New System.Windows.Forms.RadioButton()
        Me.rdoGeneral = New System.Windows.Forms.RadioButton()
        Me.lblNumeroSemana = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbAgrupaNaves = New System.Windows.Forms.ComboBox()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblFechaActualizacion = New System.Windows.Forms.Label()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.bntCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.grdReporteCostosNaves = New DevExpress.XtraGrid.GridControl()
        Me.bgvReportesMaquilasCostos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMostrar.SuspendLayout()
        Me.gpbSemana.SuspendLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbAgrupamiento.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdReporteCostosNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bgvReportesMaquilasCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Label5)
        Me.pnlHeader.Controls.Add(Me.BtnConfigPorcentaje)
        Me.pnlHeader.Controls.Add(Me.Imprimir)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.btnExportar)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1036, 74)
        Me.pnlHeader.TabIndex = 72
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(73, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 26)
        Me.Label5.TabIndex = 172
        Me.Label5.Text = "Configurar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Porcentajes"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BtnConfigPorcentaje
        '
        Me.BtnConfigPorcentaje.Image = CType(resources.GetObject("BtnConfigPorcentaje.Image"), System.Drawing.Image)
        Me.BtnConfigPorcentaje.Location = New System.Drawing.Point(84, 10)
        Me.BtnConfigPorcentaje.Name = "BtnConfigPorcentaje"
        Me.BtnConfigPorcentaje.Size = New System.Drawing.Size(32, 32)
        Me.BtnConfigPorcentaje.TabIndex = 6
        Me.BtnConfigPorcentaje.UseVisualStyleBackColor = True
        '
        'Imprimir
        '
        Me.Imprimir.AutoSize = True
        Me.Imprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Imprimir.Location = New System.Drawing.Point(10, 46)
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.Size = New System.Drawing.Size(46, 13)
        Me.Imprimir.TabIndex = 5
        Me.Imprimir.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(644, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(392, 74)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(135, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(163, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Costos por Maquila"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Proveedor.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(16, 10)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 4
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.LblTipoReporte)
        Me.grbParametros.Controls.Add(Me.pnlMostrar)
        Me.grbParametros.Controls.Add(Me.gpbSemana)
        Me.grbParametros.Controls.Add(Me.gpbAgrupamiento)
        Me.grbParametros.Controls.Add(Me.lblNumeroSemana)
        Me.grbParametros.Controls.Add(Me.lblFecha)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 74)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1036, 105)
        Me.grbParametros.TabIndex = 76
        Me.grbParametros.TabStop = False
        '
        'LblTipoReporte
        '
        Me.LblTipoReporte.AutoSize = True
        Me.LblTipoReporte.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoReporte.Location = New System.Drawing.Point(556, 86)
        Me.LblTipoReporte.Name = "LblTipoReporte"
        Me.LblTipoReporte.Size = New System.Drawing.Size(86, 16)
        Me.LblTipoReporte.TabIndex = 58
        Me.LblTipoReporte.Text = "TipoReporte"
        '
        'pnlMostrar
        '
        Me.pnlMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMostrar.Controls.Add(Me.BtnMostrar)
        Me.pnlMostrar.Controls.Add(Me.lblMostrar)
        Me.pnlMostrar.Location = New System.Drawing.Point(960, 19)
        Me.pnlMostrar.Name = "pnlMostrar"
        Me.pnlMostrar.Size = New System.Drawing.Size(64, 75)
        Me.pnlMostrar.TabIndex = 56
        '
        'BtnMostrar
        '
        Me.BtnMostrar.Image = Global.Proveedor.Vista.My.Resources.Resources.buscar_32
        Me.BtnMostrar.Location = New System.Drawing.Point(15, 12)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.BtnMostrar.TabIndex = 54
        Me.BtnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(12, 47)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 55
        Me.lblMostrar.Text = "Mostrar"
        '
        'gpbSemana
        '
        Me.gpbSemana.Controls.Add(Me.nudAño)
        Me.gpbSemana.Controls.Add(Me.lblaño)
        Me.gpbSemana.Controls.Add(Me.nudSemanaFinal)
        Me.gpbSemana.Controls.Add(Me.Label1)
        Me.gpbSemana.Controls.Add(Me.lblde)
        Me.gpbSemana.Controls.Add(Me.nudSemanaInicio)
        Me.gpbSemana.Location = New System.Drawing.Point(196, 39)
        Me.gpbSemana.Name = "gpbSemana"
        Me.gpbSemana.Size = New System.Drawing.Size(298, 52)
        Me.gpbSemana.TabIndex = 53
        Me.gpbSemana.TabStop = False
        Me.gpbSemana.Text = "Semana"
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(193, 18)
        Me.nudAño.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(66, 20)
        Me.nudAño.TabIndex = 68
        Me.nudAño.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'lblaño
        '
        Me.lblaño.AutoSize = True
        Me.lblaño.Location = New System.Drawing.Point(161, 22)
        Me.lblaño.Name = "lblaño"
        Me.lblaño.Size = New System.Drawing.Size(29, 13)
        Me.lblaño.TabIndex = 5
        Me.lblaño.Text = "Año:"
        '
        'nudSemanaFinal
        '
        Me.nudSemanaFinal.Location = New System.Drawing.Point(107, 19)
        Me.nudSemanaFinal.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
        Me.nudSemanaFinal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaFinal.Name = "nudSemanaFinal"
        Me.nudSemanaFinal.Size = New System.Drawing.Size(37, 20)
        Me.nudSemanaFinal.TabIndex = 3
        Me.nudSemanaFinal.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "A:"
        '
        'lblde
        '
        Me.lblde.AutoSize = True
        Me.lblde.Location = New System.Drawing.Point(6, 20)
        Me.lblde.Name = "lblde"
        Me.lblde.Size = New System.Drawing.Size(24, 13)
        Me.lblde.TabIndex = 1
        Me.lblde.Text = "De:"
        '
        'nudSemanaInicio
        '
        Me.nudSemanaInicio.Location = New System.Drawing.Point(36, 20)
        Me.nudSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSemanaInicio.Name = "nudSemanaInicio"
        Me.nudSemanaInicio.Size = New System.Drawing.Size(37, 20)
        Me.nudSemanaInicio.TabIndex = 0
        Me.nudSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'gpbAgrupamiento
        '
        Me.gpbAgrupamiento.Controls.Add(Me.rdoFVO)
        Me.gpbAgrupamiento.Controls.Add(Me.rdoRVO)
        Me.gpbAgrupamiento.Controls.Add(Me.rdoGeneral)
        Me.gpbAgrupamiento.Location = New System.Drawing.Point(8, 39)
        Me.gpbAgrupamiento.Name = "gpbAgrupamiento"
        Me.gpbAgrupamiento.Size = New System.Drawing.Size(183, 52)
        Me.gpbAgrupamiento.TabIndex = 52
        Me.gpbAgrupamiento.TabStop = False
        Me.gpbAgrupamiento.Text = "Agrupamiento"
        '
        'rdoFVO
        '
        Me.rdoFVO.AutoSize = True
        Me.rdoFVO.Location = New System.Drawing.Point(133, 19)
        Me.rdoFVO.Name = "rdoFVO"
        Me.rdoFVO.Size = New System.Drawing.Size(46, 17)
        Me.rdoFVO.TabIndex = 2
        Me.rdoFVO.Text = "FVO"
        Me.rdoFVO.UseVisualStyleBackColor = True
        '
        'rdoRVO
        '
        Me.rdoRVO.AutoSize = True
        Me.rdoRVO.Location = New System.Drawing.Point(78, 19)
        Me.rdoRVO.Name = "rdoRVO"
        Me.rdoRVO.Size = New System.Drawing.Size(48, 17)
        Me.rdoRVO.TabIndex = 1
        Me.rdoRVO.Text = "RVO"
        Me.rdoRVO.UseVisualStyleBackColor = True
        '
        'rdoGeneral
        '
        Me.rdoGeneral.AutoSize = True
        Me.rdoGeneral.Checked = True
        Me.rdoGeneral.Location = New System.Drawing.Point(7, 19)
        Me.rdoGeneral.Name = "rdoGeneral"
        Me.rdoGeneral.Size = New System.Drawing.Size(62, 17)
        Me.rdoGeneral.TabIndex = 0
        Me.rdoGeneral.TabStop = True
        Me.rdoGeneral.Text = "General"
        Me.rdoGeneral.UseVisualStyleBackColor = True
        '
        'lblNumeroSemana
        '
        Me.lblNumeroSemana.AutoSize = True
        Me.lblNumeroSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroSemana.Location = New System.Drawing.Point(94, 16)
        Me.lblNumeroSemana.Name = "lblNumeroSemana"
        Me.lblNumeroSemana.Size = New System.Drawing.Size(55, 13)
        Me.lblNumeroSemana.TabIndex = 51
        Me.lblNumeroSemana.Text = "N° week"
        Me.lblNumeroSemana.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(8, 16)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(82, 13)
        Me.lblFecha.TabIndex = 50
        Me.lblFecha.Text = "Semana Actual:"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.White
        Me.pnlAcciones.Controls.Add(Me.lblNave)
        Me.pnlAcciones.Controls.Add(Me.cmbAgrupaNaves)
        Me.pnlAcciones.Controls.Add(Me.pnlBotones)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 468)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1036, 60)
        Me.pnlAcciones.TabIndex = 77
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.Location = New System.Drawing.Point(12, 11)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 97
        Me.lblNave.Text = "Nave:"
        '
        'cmbAgrupaNaves
        '
        Me.cmbAgrupaNaves.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAgrupaNaves.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAgrupaNaves.FormattingEnabled = True
        Me.cmbAgrupaNaves.Location = New System.Drawing.Point(54, 8)
        Me.cmbAgrupaNaves.Name = "cmbAgrupaNaves"
        Me.cmbAgrupaNaves.Size = New System.Drawing.Size(204, 21)
        Me.cmbAgrupaNaves.TabIndex = 96
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.lblFechaActualizacion)
        Me.pnlBotones.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlBotones.Controls.Add(Me.bntCerrar)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(735, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(301, 60)
        Me.pnlBotones.TabIndex = 65
        '
        'lblFechaActualizacion
        '
        Me.lblFechaActualizacion.AutoSize = True
        Me.lblFechaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaActualizacion.Location = New System.Drawing.Point(24, 31)
        Me.lblFechaActualizacion.Name = "lblFechaActualizacion"
        Me.lblFechaActualizacion.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaActualizacion.TabIndex = 52
        Me.lblFechaActualizacion.Text = "Fecha"
        Me.lblFechaActualizacion.Visible = False
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(28, 11)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(105, 13)
        Me.lblUltimaActualizacion.TabIndex = 51
        Me.lblUltimaActualizacion.Text = "Ultima Actualización:"
        '
        'bntCerrar
        '
        Me.bntCerrar.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntCerrar.Location = New System.Drawing.Point(251, 7)
        Me.bntCerrar.Name = "bntCerrar"
        Me.bntCerrar.Size = New System.Drawing.Size(32, 32)
        Me.bntCerrar.TabIndex = 0
        Me.bntCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(252, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = -1
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "gridBand2"
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = -1
        Me.gridBand2.Width = 75
        '
        'GridBand9
        '
        Me.GridBand9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand9.Caption = "Prevendido"
        Me.GridBand9.Name = "GridBand9"
        Me.GridBand9.VisibleIndex = -1
        Me.GridBand9.Width = 629
        '
        'grdReporteCostosNaves
        '
        Me.grdReporteCostosNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReporteCostosNaves.Location = New System.Drawing.Point(0, 179)
        Me.grdReporteCostosNaves.MainView = Me.bgvReportesMaquilasCostos
        Me.grdReporteCostosNaves.Name = "grdReporteCostosNaves"
        Me.grdReporteCostosNaves.Size = New System.Drawing.Size(1036, 289)
        Me.grdReporteCostosNaves.TabIndex = 78
        Me.grdReporteCostosNaves.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.bgvReportesMaquilasCostos})
        '
        'bgvReportesMaquilasCostos
        '
        Me.bgvReportesMaquilasCostos.GridControl = Me.grdReporteCostosNaves
        Me.bgvReportesMaquilasCostos.IndicatorWidth = 25
        Me.bgvReportesMaquilasCostos.Name = "bgvReportesMaquilasCostos"
        Me.bgvReportesMaquilasCostos.OptionsBehavior.Editable = False
        Me.bgvReportesMaquilasCostos.OptionsCustomization.AllowColumnMoving = False
        Me.bgvReportesMaquilasCostos.OptionsCustomization.AllowFilter = False
        Me.bgvReportesMaquilasCostos.OptionsCustomization.AllowGroup = False
        Me.bgvReportesMaquilasCostos.OptionsCustomization.AllowSort = False
        Me.bgvReportesMaquilasCostos.OptionsMenu.EnableColumnMenu = False
        Me.bgvReportesMaquilasCostos.OptionsSelection.MultiSelect = True
        Me.bgvReportesMaquilasCostos.OptionsView.ColumnAutoWidth = False
        Me.bgvReportesMaquilasCostos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.bgvReportesMaquilasCostos.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.bgvReportesMaquilasCostos.OptionsView.ShowDetailButtons = False
        Me.bgvReportesMaquilasCostos.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.bgvReportesMaquilasCostos.OptionsView.ShowFooter = True
        Me.bgvReportesMaquilasCostos.OptionsView.ShowGroupPanel = False
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(324, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 74)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'CostosPorMaquilaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 528)
        Me.Controls.Add(Me.grdReporteCostosNaves)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "CostosPorMaquilaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Costos por Maquila"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMostrar.ResumeLayout(False)
        Me.pnlMostrar.PerformLayout()
        Me.gpbSemana.ResumeLayout(False)
        Me.gpbSemana.PerformLayout()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbAgrupamiento.ResumeLayout(False)
        Me.gpbAgrupamiento.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdReporteCostosNaves, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bgvReportesMaquilasCostos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents Imprimir As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents BtnConfigPorcentaje As Windows.Forms.Button
    Friend WithEvents grbParametros As Windows.Forms.GroupBox
    Friend WithEvents lblFecha As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents lblNumeroSemana As Windows.Forms.Label
    Friend WithEvents BtnMostrar As Windows.Forms.Button
    Friend WithEvents gpbSemana As Windows.Forms.GroupBox
    Friend WithEvents gpbAgrupamiento As Windows.Forms.GroupBox
    Friend WithEvents lblMostrar As Windows.Forms.Label
    Friend WithEvents lblaño As Windows.Forms.Label
    Friend WithEvents nudSemanaFinal As Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblde As Windows.Forms.Label
    Friend WithEvents nudSemanaInicio As Windows.Forms.NumericUpDown
    Friend WithEvents pnlAcciones As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents bntCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents lblNave As Windows.Forms.Label
    Friend WithEvents cmbAgrupaNaves As Windows.Forms.ComboBox
    Friend WithEvents lblFechaActualizacion As Windows.Forms.Label
    Friend WithEvents lblUltimaActualizacion As Windows.Forms.Label
    Friend WithEvents nudAño As Windows.Forms.NumericUpDown
    Friend WithEvents rdoRVO As Windows.Forms.RadioButton
    Friend WithEvents rdoGeneral As Windows.Forms.RadioButton
    Friend WithEvents rdoFVO As Windows.Forms.RadioButton
    Friend WithEvents pnlMostrar As Windows.Forms.Panel
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents grdReporteCostosNaves As DevExpress.XtraGrid.GridControl
    Friend WithEvents bgvReportesMaquilasCostos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents LblTipoReporte As Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
