<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdministradorResumenCostosForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim DoughnutSeriesLabel1 As DevExpress.XtraCharts.DoughnutSeriesLabel = New DevExpress.XtraCharts.DoughnutSeriesLabel()
        Dim SeriesPoint1 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("SOLICITADO", New Object() {CType(1.0R, Object), CType(1.0R, Object)}, 0)
        Dim SeriesPoint2 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("AUT. NAVE DESARROLLO", New Object() {CType(3.0R, Object), CType(3.0R, Object)}, 1)
        Dim SeriesPoint3 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("RECHAZADO", New Object() {CType(1.0R, Object), CType(1.0R, Object)}, 2)
        Dim SeriesPoint4 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("LIBERADO DC", New Object() {CType(2.0R, Object), CType(2.0R, Object)}, 3)
        Dim SeriesPoint5 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("EN CAPTURA", New Object() {CType(3.0R, Object), CType(3.0R, Object)}, 4)
        Dim DoughnutSeriesView1 As DevExpress.XtraCharts.DoughnutSeriesView = New DevExpress.XtraCharts.DoughnutSeriesView(New Integer() {4, 2, 0})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorResumenCostosForm))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions3 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions4 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject13 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject14 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject15 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject16 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions5 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject17 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject18 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject19 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject20 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.pnlFondoForm = New DevExpress.XtraEditors.PanelControl()
        Me.pnlTabla = New DevExpress.XtraEditors.PanelControl()
        Me.tabCtrlResumenCostos = New DevExpress.XtraTab.XtraTabControl()
        Me.tabPageIndicadores = New DevExpress.XtraTab.XtraTabPage()
        Me.pnlTabPageIndicadores = New DevExpress.XtraEditors.PanelControl()
        Me.charIndicadoresPorNave = New DevExpress.XtraCharts.ChartControl()
        Me.tabPageResumenCostos = New DevExpress.XtraTab.XtraTabPage()
        Me.pnlTabPageTabla = New DevExpress.XtraEditors.PanelControl()
        Me.grdAdminResumenCostos = New DevExpress.XtraGrid.GridControl()
        Me.grdVAdminResumenCostos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.bandColecciones = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.c_Sel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Foto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_FotoModelo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Marca = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_FamiliaProyeccion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_ColeccionId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Coleccion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_ModeloSAY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_ModeloSICY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Piel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Color = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Corrida = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_ProductoEstiloId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_EstatusProductoId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_NaveDesarrolloId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_NaveDesarrollo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_TemporadaId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Temporada = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandCostos = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.bandDetallados = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.c_CostoMaterialDirecto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_CostoOverhead = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_CostoFabricacion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Clasificacion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandUtilidad = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.c_UtilidadPorcentaje = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_UtilidadPesos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandFinal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.c_PrecioVentaComercializadora = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandUsuariosCambios = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.c_UsuarioSolicita = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_FechaSolicitud = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_UsuarioAutoriza = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_FechaAutoriza = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_UsuarioRechaza = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_FechaRechazo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_UsuarioLibera = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_FechaLibero = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandEstatusProductoCosto = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.c_EstatusProducto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_EstatusProductoCosto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_EstatusProductoCostoId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.c_Observaciones = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.tabPageResumenCostosEspeciales = New DevExpress.XtraTab.XtraTabPage()
        Me.grdAdminResumenCostosEspeciales = New DevExpress.XtraGrid.GridControl()
        Me.grdVAdminResumenCostosEspeciales = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.bandColeccionesEspeciales = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ce_Sel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Foto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_FotoModelo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Marca = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_FamiliaProyeccion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_ColeccionId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Cliente = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Coleccion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_ModeloSAY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_ModeloSICY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Piel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Color = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Talla = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_ProductoEstiloId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_EstatusProductoId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_NaveDesarrolloId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_NaveDesarrollo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_TemporadaId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Temporada = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandEstatusProductoCostoEspecial = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ce_CostoMaterialDirecto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_CostoOverhead = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_CostoFabricacion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Clasificacion = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ce_UtilidadPorcentaje = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_UtilidadPesos = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ce_PrecioVentaComercializadora = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandUsuariosEspeciales = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ce_UsuarioSolicita = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_FechaSolicita = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_UsuarioAutoriza = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_FechaAutoriza = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_UsuarioRechaza = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_FechaRechaza = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_UsuarioLibera = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_FechaLibera = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.bandEstatusEspeciales = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ce_EstatusProducto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_EstatusProductoCosto = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_EstatusProductoCostoId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ce_Observaciones = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.pnlFooter = New DevExpress.XtraEditors.PanelControl()
        Me.lblInformativo_Especial = New DevExpress.XtraEditors.LabelControl()
        Me.lblInformativo_General = New DevExpress.XtraEditors.LabelControl()
        Me.chkSimplificarInformacion = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlTotalRegistros = New DevExpress.XtraEditors.PanelControl()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlMostrar = New DevExpress.XtraEditors.PanelControl()
        Me.lblMostrar = New DevExpress.XtraEditors.LabelControl()
        Me.btnMostrar = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlCerrar = New DevExpress.XtraEditors.PanelControl()
        Me.lblCerrar = New DevExpress.XtraEditors.LabelControl()
        Me.btnCerrar = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlParametros = New DevExpress.XtraEditors.PanelControl()
        Me.pnlVigenciaEspecial = New DevExpress.XtraEditors.PanelControl()
        Me.lblVigencia = New DevExpress.XtraEditors.LabelControl()
        Me.dtpVigenciaEspecial = New DevExpress.XtraEditors.DateEdit()
        Me.BarManagerTipoReporte = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.barbtnFormatoGeneral_PDF = New DevExpress.XtraBars.BarButtonItem()
        Me.barbtnFormatoClienteEspecial_PDF = New DevExpress.XtraBars.BarButtonItem()
        Me.barbtnFormatoClienteEspecial_Excel = New DevExpress.XtraBars.BarButtonItem()
        Me.barbtnFormatoGeneral_Excel = New DevExpress.XtraBars.BarButtonItem()
        Me.barbtnAplicarValoresMasivos = New DevExpress.XtraBars.BarButtonItem()
        Me.bartxtValorMasivo = New DevExpress.XtraBars.BarStaticItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.repoTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btnGenerarFormatoPDF = New DevExpress.XtraEditors.SimpleButton()
        Me.PopupTipoReporte_PDF = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.txtTemporada = New DevExpress.XtraEditors.TextEdit()
        Me.txtNaveDesarrollo = New DevExpress.XtraEditors.TextEdit()
        Me.separador = New DevExpress.XtraEditors.SeparatorControl()
        Me.txtMarca = New DevExpress.XtraEditors.TextEdit()
        Me.chkMostrarImagenes = New DevExpress.XtraEditors.CheckEdit()
        Me.slueComboNaveDesarrollo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.grdvComboNaveDesarrollo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cSel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cNaveDesarrolloId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cNaveDesarrollo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtEstatusProductoCosto = New DevExpress.XtraEditors.TextEdit()
        Me.lookUpMarca = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Sel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MarcaId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MarcaNombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EsLicencias = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.slueComboEstatusProductoCosto = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.grdVComboEstatusProductoCosto = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cSel_E = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cEstatusId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cEstatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lblNaveDesarrollo = New DevExpress.XtraEditors.LabelControl()
        Me.lblEstatusProductoCosto = New DevExpress.XtraEditors.LabelControl()
        Me.lblMarca = New DevExpress.XtraEditors.LabelControl()
        Me.txtColeccion = New DevExpress.XtraEditors.TextEdit()
        Me.slueComboColeccion = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.grdvComboColeccion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cole_Sel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cole_MarcaId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cole_Marca = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cole_TemporadaId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cole_Temporada = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repoMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.cole_ColeccionId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cole_Coleccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cole_Año = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cole_NaveDesarrollaId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cole_NaveDesarrolla = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lblTemporada = New DevExpress.XtraEditors.LabelControl()
        Me.lblColeccion = New DevExpress.XtraEditors.LabelControl()
        Me.slueComboTemporada = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.grdvComboTemporada = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cSel_T = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cTemporadaId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cTemporada = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cVigencia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.pnlOcultar = New DevExpress.XtraEditors.PanelControl()
        Me.pnlBotonesOcultar = New DevExpress.XtraEditors.PanelControl()
        Me.btnAbajo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnArriba = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlHeader = New DevExpress.XtraEditors.PanelControl()
        Me.pnlTitulo = New DevExpress.XtraEditors.PanelControl()
        Me.lblTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.pnlImagenYuyin = New DevExpress.XtraEditors.PanelControl()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlOperaciones = New DevExpress.XtraEditors.PanelControl()
        Me.pnlGenerarFormatoExcel = New DevExpress.XtraEditors.PanelControl()
        Me.lblGenerarFormatoExcel = New DevExpress.XtraEditors.LabelControl()
        Me.btnGenerarFormatoExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlGenerarFormatoPDF = New DevExpress.XtraEditors.PanelControl()
        Me.lblGenerarFormatoPDF = New DevExpress.XtraEditors.LabelControl()
        Me.pnlRechazarSKU = New DevExpress.XtraEditors.PanelControl()
        Me.lblRechazarSKU = New DevExpress.XtraEditors.LabelControl()
        Me.btnRechazarSKU = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlLiberarSKU = New DevExpress.XtraEditors.PanelControl()
        Me.lblLiberarSKU = New DevExpress.XtraEditors.LabelControl()
        Me.btnLiberarSKU = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlAutorizarPrecioSKU = New DevExpress.XtraEditors.PanelControl()
        Me.lblAutorizarPrecioSKU = New DevExpress.XtraEditors.LabelControl()
        Me.btnAutorizarPrecioSKU = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlModificarPrecioSKU = New DevExpress.XtraEditors.PanelControl()
        Me.lblModificarPrecioSKU = New DevExpress.XtraEditors.LabelControl()
        Me.btnModificarPrecioSKU = New DevExpress.XtraEditors.SimpleButton()
        Me.PopupTipoReporte_Excel = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.PopupActualizacionMasiva = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.cNaveGrupo = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.pnlFondoForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFondoForm.SuspendLayout()
        CType(Me.pnlTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTabla.SuspendLayout()
        CType(Me.tabCtrlResumenCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCtrlResumenCostos.SuspendLayout()
        Me.tabPageIndicadores.SuspendLayout()
        CType(Me.pnlTabPageIndicadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTabPageIndicadores.SuspendLayout()
        CType(Me.charIndicadoresPorNave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageResumenCostos.SuspendLayout()
        CType(Me.pnlTabPageTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTabPageTabla.SuspendLayout()
        CType(Me.grdAdminResumenCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVAdminResumenCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageResumenCostosEspeciales.SuspendLayout()
        CType(Me.grdAdminResumenCostosEspeciales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVAdminResumenCostosEspeciales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFooter.SuspendLayout()
        CType(Me.chkSimplificarInformacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlTotalRegistros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotalRegistros.SuspendLayout()
        CType(Me.pnlMostrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMostrar.SuspendLayout()
        CType(Me.pnlCerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCerrar.SuspendLayout()
        CType(Me.pnlParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        CType(Me.pnlVigenciaEspecial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVigenciaEspecial.SuspendLayout()
        CType(Me.dtpVigenciaEspecial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpVigenciaEspecial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManagerTipoReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repoTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupTipoReporte_PDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.txtTemporada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNaveDesarrollo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.separador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMostrarImagenes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slueComboNaveDesarrollo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdvComboNaveDesarrollo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstatusProductoCosto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lookUpMarca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slueComboEstatusProductoCosto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVComboEstatusProductoCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColeccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slueComboColeccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdvComboColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repoMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slueComboTemporada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdvComboTemporada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlOcultar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOcultar.SuspendLayout()
        CType(Me.pnlBotonesOcultar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonesOcultar.SuspendLayout()
        CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        CType(Me.pnlTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pnlImagenYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlImagenYuyin.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOperaciones.SuspendLayout()
        CType(Me.pnlGenerarFormatoExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenerarFormatoExcel.SuspendLayout()
        CType(Me.pnlGenerarFormatoPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGenerarFormatoPDF.SuspendLayout()
        CType(Me.pnlRechazarSKU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRechazarSKU.SuspendLayout()
        CType(Me.pnlLiberarSKU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLiberarSKU.SuspendLayout()
        CType(Me.pnlAutorizarPrecioSKU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAutorizarPrecioSKU.SuspendLayout()
        CType(Me.pnlModificarPrecioSKU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlModificarPrecioSKU.SuspendLayout()
        CType(Me.PopupTipoReporte_Excel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupActualizacionMasiva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlFondoForm
        '
        Me.pnlFondoForm.Controls.Add(Me.pnlTabla)
        Me.pnlFondoForm.Controls.Add(Me.pnlFooter)
        Me.pnlFondoForm.Controls.Add(Me.pnlParametros)
        Me.pnlFondoForm.Controls.Add(Me.pnlOcultar)
        Me.pnlFondoForm.Controls.Add(Me.pnlHeader)
        Me.pnlFondoForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFondoForm.Location = New System.Drawing.Point(0, 0)
        Me.pnlFondoForm.Name = "pnlFondoForm"
        Me.pnlFondoForm.Size = New System.Drawing.Size(1078, 688)
        Me.pnlFondoForm.TabIndex = 0
        '
        'pnlTabla
        '
        Me.pnlTabla.Appearance.BackColor = System.Drawing.Color.White
        Me.pnlTabla.Appearance.Options.UseBackColor = True
        Me.pnlTabla.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlTabla.Controls.Add(Me.tabCtrlResumenCostos)
        Me.pnlTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTabla.Location = New System.Drawing.Point(2, 211)
        Me.pnlTabla.LookAndFeel.SkinMaskColor = System.Drawing.Color.White
        Me.pnlTabla.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White
        Me.pnlTabla.LookAndFeel.SkinName = "DevExpress Style"
        Me.pnlTabla.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnlTabla.Name = "pnlTabla"
        Me.pnlTabla.Size = New System.Drawing.Size(1074, 410)
        Me.pnlTabla.TabIndex = 6
        '
        'tabCtrlResumenCostos
        '
        Me.tabCtrlResumenCostos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCtrlResumenCostos.Location = New System.Drawing.Point(0, 0)
        Me.tabCtrlResumenCostos.Name = "tabCtrlResumenCostos"
        Me.tabCtrlResumenCostos.SelectedTabPage = Me.tabPageIndicadores
        Me.tabCtrlResumenCostos.Size = New System.Drawing.Size(1074, 410)
        Me.tabCtrlResumenCostos.TabIndex = 14
        Me.tabCtrlResumenCostos.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabPageIndicadores, Me.tabPageResumenCostos, Me.tabPageResumenCostosEspeciales})
        '
        'tabPageIndicadores
        '
        Me.tabPageIndicadores.Controls.Add(Me.pnlTabPageIndicadores)
        Me.tabPageIndicadores.Name = "tabPageIndicadores"
        Me.tabPageIndicadores.Size = New System.Drawing.Size(1072, 385)
        Me.tabPageIndicadores.Text = "Indicadores"
        '
        'pnlTabPageIndicadores
        '
        Me.pnlTabPageIndicadores.Controls.Add(Me.charIndicadoresPorNave)
        Me.pnlTabPageIndicadores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTabPageIndicadores.Location = New System.Drawing.Point(0, 0)
        Me.pnlTabPageIndicadores.Name = "pnlTabPageIndicadores"
        Me.pnlTabPageIndicadores.Size = New System.Drawing.Size(1072, 385)
        Me.pnlTabPageIndicadores.TabIndex = 0
        '
        'charIndicadoresPorNave
        '
        Me.charIndicadoresPorNave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.charIndicadoresPorNave.Legend.HorizontalIndent = 3
        Me.charIndicadoresPorNave.Legend.Title.Text = "Estatus"
        Me.charIndicadoresPorNave.Legend.Title.Visible = True
        Me.charIndicadoresPorNave.Location = New System.Drawing.Point(2, 2)
        Me.charIndicadoresPorNave.Name = "charIndicadoresPorNave"
        Series1.CrosshairHighlightPoints = DevExpress.Utils.DefaultBoolean.[True]
        Series1.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.[True]
        DoughnutSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.[False]
        DoughnutSeriesLabel1.DXFont = New DevExpress.Drawing.DXFont("Tahoma", 12.0!)
        DoughnutSeriesLabel1.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.[True]
        DoughnutSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.[False]
        DoughnutSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Inside
        DoughnutSeriesLabel1.TextPattern = "{V}"
        Series1.Label = DoughnutSeriesLabel1
        Series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series1.LegendTextPattern = "{A}"
        Series1.Name = "SerieIndicadorEstatusCosto"
        SeriesPoint1.ColorSerializable = "#6495ED"
        SeriesPoint2.ColorSerializable = "#66CDAA"
        SeriesPoint3.ColorSerializable = "#F08080"
        SeriesPoint4.ColorSerializable = "#8FBC8F"
        SeriesPoint5.ColorSerializable = "#FFA07A"
        Series1.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint1, SeriesPoint2, SeriesPoint3, SeriesPoint4, SeriesPoint5})
        Series1.SeriesID = 0
        Series1.SeriesPointsSorting = DevExpress.XtraCharts.SortingMode.Descending
        Series1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.[True]
        DoughnutSeriesView1.ExplodeMode = DevExpress.XtraCharts.PieExplodeMode.UsePoints
        Series1.View = DoughnutSeriesView1
        Me.charIndicadoresPorNave.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.charIndicadoresPorNave.Size = New System.Drawing.Size(1068, 381)
        Me.charIndicadoresPorNave.TabIndex = 1
        '
        'tabPageResumenCostos
        '
        Me.tabPageResumenCostos.Controls.Add(Me.pnlTabPageTabla)
        Me.tabPageResumenCostos.Name = "tabPageResumenCostos"
        Me.tabPageResumenCostos.Size = New System.Drawing.Size(1072, 385)
        Me.tabPageResumenCostos.Text = "Resumen de Costos"
        '
        'pnlTabPageTabla
        '
        Me.pnlTabPageTabla.Controls.Add(Me.grdAdminResumenCostos)
        Me.pnlTabPageTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTabPageTabla.Location = New System.Drawing.Point(0, 0)
        Me.pnlTabPageTabla.Name = "pnlTabPageTabla"
        Me.pnlTabPageTabla.Size = New System.Drawing.Size(1072, 385)
        Me.pnlTabPageTabla.TabIndex = 13
        '
        'grdAdminResumenCostos
        '
        Me.grdAdminResumenCostos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAdminResumenCostos.Location = New System.Drawing.Point(2, 2)
        Me.grdAdminResumenCostos.MainView = Me.grdVAdminResumenCostos
        Me.grdAdminResumenCostos.Name = "grdAdminResumenCostos"
        Me.grdAdminResumenCostos.Size = New System.Drawing.Size(1068, 381)
        Me.grdAdminResumenCostos.TabIndex = 13
        Me.grdAdminResumenCostos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVAdminResumenCostos})
        '
        'grdVAdminResumenCostos
        '
        Me.grdVAdminResumenCostos.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.bandColecciones, Me.bandCostos, Me.bandUsuariosCambios, Me.bandEstatusProductoCosto})
        Me.grdVAdminResumenCostos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.grdVAdminResumenCostos.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.c_Sel, Me.c_Foto, Me.c_FotoModelo, Me.c_Marca, Me.c_FamiliaProyeccion, Me.c_ColeccionId, Me.c_Coleccion, Me.c_ModeloSAY, Me.c_ModeloSICY, Me.c_Piel, Me.c_Color, Me.c_Corrida, Me.c_ProductoEstiloId, Me.c_NaveDesarrolloId, Me.c_NaveDesarrollo, Me.c_TemporadaId, Me.c_Temporada, Me.c_CostoMaterialDirecto, Me.c_CostoOverhead, Me.c_Clasificacion, Me.c_CostoFabricacion, Me.c_UtilidadPorcentaje, Me.c_UtilidadPesos, Me.c_PrecioVentaComercializadora, Me.c_EstatusProductoId, Me.c_EstatusProducto, Me.c_EstatusProductoCostoId, Me.c_EstatusProductoCosto, Me.c_Observaciones, Me.c_UsuarioSolicita, Me.c_FechaSolicitud, Me.c_UsuarioAutoriza, Me.c_FechaAutoriza, Me.c_UsuarioRechaza, Me.c_FechaRechazo, Me.c_UsuarioLibera, Me.c_FechaLibero})
        Me.grdVAdminResumenCostos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grdVAdminResumenCostos.GridControl = Me.grdAdminResumenCostos
        Me.grdVAdminResumenCostos.IndicatorWidth = 25
        Me.grdVAdminResumenCostos.Name = "grdVAdminResumenCostos"
        Me.grdVAdminResumenCostos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVAdminResumenCostos.OptionsBehavior.Editable = False
        Me.grdVAdminResumenCostos.OptionsCustomization.AllowBandMoving = False
        Me.grdVAdminResumenCostos.OptionsCustomization.AllowColumnMoving = False
        Me.grdVAdminResumenCostos.OptionsCustomization.AllowGroup = False
        Me.grdVAdminResumenCostos.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.grdVAdminResumenCostos.OptionsSelection.CheckBoxSelectorField = "Sel"
        Me.grdVAdminResumenCostos.OptionsSelection.MultiSelect = True
        Me.grdVAdminResumenCostos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.grdVAdminResumenCostos.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.grdVAdminResumenCostos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVAdminResumenCostos.OptionsView.ShowAutoFilterRow = True
        Me.grdVAdminResumenCostos.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.grdVAdminResumenCostos.OptionsView.ShowDetailButtons = False
        Me.grdVAdminResumenCostos.OptionsView.ShowFooter = True
        Me.grdVAdminResumenCostos.OptionsView.ShowGroupPanel = False
        Me.grdVAdminResumenCostos.PaintStyleName = "Skin"
        '
        'bandColecciones
        '
        Me.bandColecciones.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandColecciones.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandColecciones.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandColecciones.AppearanceHeader.Options.UseBackColor = True
        Me.bandColecciones.AppearanceHeader.Options.UseBorderColor = True
        Me.bandColecciones.AppearanceHeader.Options.UseFont = True
        Me.bandColecciones.AppearanceHeader.Options.UseTextOptions = True
        Me.bandColecciones.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandColecciones.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandColecciones.Caption = "COLECCIONES"
        Me.bandColecciones.Columns.Add(Me.c_Sel)
        Me.bandColecciones.Columns.Add(Me.c_Foto)
        Me.bandColecciones.Columns.Add(Me.c_FotoModelo)
        Me.bandColecciones.Columns.Add(Me.c_Marca)
        Me.bandColecciones.Columns.Add(Me.c_FamiliaProyeccion)
        Me.bandColecciones.Columns.Add(Me.c_ColeccionId)
        Me.bandColecciones.Columns.Add(Me.c_Coleccion)
        Me.bandColecciones.Columns.Add(Me.c_ModeloSAY)
        Me.bandColecciones.Columns.Add(Me.c_ModeloSICY)
        Me.bandColecciones.Columns.Add(Me.c_Piel)
        Me.bandColecciones.Columns.Add(Me.c_Color)
        Me.bandColecciones.Columns.Add(Me.c_Corrida)
        Me.bandColecciones.Columns.Add(Me.c_ProductoEstiloId)
        Me.bandColecciones.Columns.Add(Me.c_EstatusProductoId)
        Me.bandColecciones.Columns.Add(Me.c_NaveDesarrolloId)
        Me.bandColecciones.Columns.Add(Me.c_NaveDesarrollo)
        Me.bandColecciones.Columns.Add(Me.c_TemporadaId)
        Me.bandColecciones.Columns.Add(Me.c_Temporada)
        Me.bandColecciones.Name = "bandColecciones"
        Me.bandColecciones.VisibleIndex = 0
        Me.bandColecciones.Width = 389
        '
        'c_Sel
        '
        Me.c_Sel.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Sel.AppearanceHeader.Options.UseBackColor = True
        Me.c_Sel.Caption = " "
        Me.c_Sel.FieldName = "Sel"
        Me.c_Sel.Name = "c_Sel"
        '
        'c_Foto
        '
        Me.c_Foto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Foto.AppearanceHeader.Options.UseBackColor = True
        Me.c_Foto.AppearanceHeader.Options.UseTextOptions = True
        Me.c_Foto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_Foto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_Foto.Caption = "FOTO"
        Me.c_Foto.FieldName = "Foto"
        Me.c_Foto.Name = "c_Foto"
        Me.c_Foto.Visible = True
        Me.c_Foto.Width = 34
        '
        'c_FotoModelo
        '
        Me.c_FotoModelo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_FotoModelo.AppearanceHeader.Options.UseBackColor = True
        Me.c_FotoModelo.AppearanceHeader.Options.UseTextOptions = True
        Me.c_FotoModelo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_FotoModelo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_FotoModelo.Caption = "FOTO MODELO"
        Me.c_FotoModelo.FieldName = "FotoModelo"
        Me.c_FotoModelo.Name = "c_FotoModelo"
        '
        'c_Marca
        '
        Me.c_Marca.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_Marca.AppearanceCell.Options.UseFont = True
        Me.c_Marca.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Marca.AppearanceHeader.Options.UseBackColor = True
        Me.c_Marca.AppearanceHeader.Options.UseTextOptions = True
        Me.c_Marca.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_Marca.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_Marca.Caption = "MARCA"
        Me.c_Marca.FieldName = "Marca"
        Me.c_Marca.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.c_Marca.Name = "c_Marca"
        Me.c_Marca.Visible = True
        Me.c_Marca.Width = 34
        '
        'c_FamiliaProyeccion
        '
        Me.c_FamiliaProyeccion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_FamiliaProyeccion.AppearanceHeader.Options.UseBackColor = True
        Me.c_FamiliaProyeccion.AppearanceHeader.Options.UseTextOptions = True
        Me.c_FamiliaProyeccion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_FamiliaProyeccion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_FamiliaProyeccion.Caption = "FAMILIA PROYECCIÓN"
        Me.c_FamiliaProyeccion.FieldName = "FamiliaProyeccion"
        Me.c_FamiliaProyeccion.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.c_FamiliaProyeccion.Name = "c_FamiliaProyeccion"
        Me.c_FamiliaProyeccion.Visible = True
        Me.c_FamiliaProyeccion.Width = 34
        '
        'c_ColeccionId
        '
        Me.c_ColeccionId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_ColeccionId.AppearanceHeader.Options.UseBackColor = True
        Me.c_ColeccionId.AppearanceHeader.Options.UseTextOptions = True
        Me.c_ColeccionId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_ColeccionId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_ColeccionId.Caption = "COLECCIÓN ID"
        Me.c_ColeccionId.FieldName = "ColeccionId"
        Me.c_ColeccionId.Name = "c_ColeccionId"
        '
        'c_Coleccion
        '
        Me.c_Coleccion.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_Coleccion.AppearanceCell.Options.UseFont = True
        Me.c_Coleccion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Coleccion.AppearanceHeader.Options.UseBackColor = True
        Me.c_Coleccion.AppearanceHeader.Options.UseTextOptions = True
        Me.c_Coleccion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_Coleccion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_Coleccion.Caption = "COLECCIÓN"
        Me.c_Coleccion.FieldName = "Coleccion"
        Me.c_Coleccion.Name = "c_Coleccion"
        Me.c_Coleccion.Visible = True
        Me.c_Coleccion.Width = 34
        '
        'c_ModeloSAY
        '
        Me.c_ModeloSAY.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_ModeloSAY.AppearanceCell.Options.UseFont = True
        Me.c_ModeloSAY.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_ModeloSAY.AppearanceHeader.Options.UseBackColor = True
        Me.c_ModeloSAY.AppearanceHeader.Options.UseTextOptions = True
        Me.c_ModeloSAY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_ModeloSAY.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_ModeloSAY.Caption = "MODELO SAY"
        Me.c_ModeloSAY.FieldName = "ModeloSAY"
        Me.c_ModeloSAY.Name = "c_ModeloSAY"
        Me.c_ModeloSAY.Visible = True
        Me.c_ModeloSAY.Width = 34
        '
        'c_ModeloSICY
        '
        Me.c_ModeloSICY.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_ModeloSICY.AppearanceHeader.Options.UseBackColor = True
        Me.c_ModeloSICY.AppearanceHeader.Options.UseTextOptions = True
        Me.c_ModeloSICY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_ModeloSICY.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_ModeloSICY.Caption = "MODELO SICY"
        Me.c_ModeloSICY.FieldName = "ModeloSICY"
        Me.c_ModeloSICY.Name = "c_ModeloSICY"
        Me.c_ModeloSICY.Visible = True
        Me.c_ModeloSICY.Width = 34
        '
        'c_Piel
        '
        Me.c_Piel.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_Piel.AppearanceCell.Options.UseFont = True
        Me.c_Piel.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Piel.AppearanceHeader.Options.UseBackColor = True
        Me.c_Piel.AppearanceHeader.Options.UseTextOptions = True
        Me.c_Piel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_Piel.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_Piel.Caption = "PIEL"
        Me.c_Piel.FieldName = "Piel"
        Me.c_Piel.Name = "c_Piel"
        Me.c_Piel.Visible = True
        Me.c_Piel.Width = 34
        '
        'c_Color
        '
        Me.c_Color.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_Color.AppearanceCell.Options.UseFont = True
        Me.c_Color.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Color.AppearanceHeader.Options.UseBackColor = True
        Me.c_Color.AppearanceHeader.Options.UseTextOptions = True
        Me.c_Color.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_Color.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_Color.Caption = "COLOR"
        Me.c_Color.FieldName = "Color"
        Me.c_Color.Name = "c_Color"
        Me.c_Color.Visible = True
        Me.c_Color.Width = 34
        '
        'c_Corrida
        '
        Me.c_Corrida.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_Corrida.AppearanceCell.Options.UseFont = True
        Me.c_Corrida.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Corrida.AppearanceHeader.Options.UseBackColor = True
        Me.c_Corrida.AppearanceHeader.Options.UseTextOptions = True
        Me.c_Corrida.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_Corrida.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_Corrida.Caption = "CORRIDA"
        Me.c_Corrida.FieldName = "Talla"
        Me.c_Corrida.Name = "c_Corrida"
        Me.c_Corrida.Visible = True
        Me.c_Corrida.Width = 34
        '
        'c_ProductoEstiloId
        '
        Me.c_ProductoEstiloId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_ProductoEstiloId.AppearanceHeader.Options.UseBackColor = True
        Me.c_ProductoEstiloId.AppearanceHeader.Options.UseTextOptions = True
        Me.c_ProductoEstiloId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_ProductoEstiloId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_ProductoEstiloId.Caption = "PRODUCTO ESTILO ID"
        Me.c_ProductoEstiloId.FieldName = "ProductoEstiloId"
        Me.c_ProductoEstiloId.Name = "c_ProductoEstiloId"
        '
        'c_EstatusProductoId
        '
        Me.c_EstatusProductoId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_EstatusProductoId.AppearanceHeader.Options.UseBackColor = True
        Me.c_EstatusProductoId.AppearanceHeader.Options.UseTextOptions = True
        Me.c_EstatusProductoId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_EstatusProductoId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_EstatusProductoId.Caption = "ESTATUS PRODUCTO ID"
        Me.c_EstatusProductoId.FieldName = "EstatusProductoId"
        Me.c_EstatusProductoId.Name = "c_EstatusProductoId"
        '
        'c_NaveDesarrolloId
        '
        Me.c_NaveDesarrolloId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_NaveDesarrolloId.AppearanceHeader.Options.UseBackColor = True
        Me.c_NaveDesarrolloId.AppearanceHeader.Options.UseTextOptions = True
        Me.c_NaveDesarrolloId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_NaveDesarrolloId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_NaveDesarrolloId.Caption = "NAVE DESARROLLO ID"
        Me.c_NaveDesarrolloId.FieldName = "NaveDesarrolloId"
        Me.c_NaveDesarrolloId.Name = "c_NaveDesarrolloId"
        '
        'c_NaveDesarrollo
        '
        Me.c_NaveDesarrollo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_NaveDesarrollo.AppearanceHeader.Options.UseBackColor = True
        Me.c_NaveDesarrollo.AppearanceHeader.Options.UseTextOptions = True
        Me.c_NaveDesarrollo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_NaveDesarrollo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_NaveDesarrollo.Caption = "NAVE DESARROLLO"
        Me.c_NaveDesarrollo.FieldName = "NaveDesarrollo"
        Me.c_NaveDesarrollo.Name = "c_NaveDesarrollo"
        Me.c_NaveDesarrollo.Visible = True
        Me.c_NaveDesarrollo.Width = 34
        '
        'c_TemporadaId
        '
        Me.c_TemporadaId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_TemporadaId.AppearanceHeader.Options.UseBackColor = True
        Me.c_TemporadaId.AppearanceHeader.Options.UseTextOptions = True
        Me.c_TemporadaId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_TemporadaId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_TemporadaId.Caption = "TEMPORADA ID"
        Me.c_TemporadaId.FieldName = "TemporadaId"
        Me.c_TemporadaId.Name = "c_TemporadaId"
        '
        'c_Temporada
        '
        Me.c_Temporada.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Temporada.AppearanceHeader.Options.UseBackColor = True
        Me.c_Temporada.AppearanceHeader.Options.UseTextOptions = True
        Me.c_Temporada.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_Temporada.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_Temporada.Caption = "TEMPORADA"
        Me.c_Temporada.FieldName = "Temporada"
        Me.c_Temporada.Name = "c_Temporada"
        Me.c_Temporada.Visible = True
        Me.c_Temporada.Width = 49
        '
        'bandCostos
        '
        Me.bandCostos.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandCostos.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandCostos.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandCostos.AppearanceHeader.Options.UseBackColor = True
        Me.bandCostos.AppearanceHeader.Options.UseBorderColor = True
        Me.bandCostos.AppearanceHeader.Options.UseFont = True
        Me.bandCostos.AppearanceHeader.Options.UseTextOptions = True
        Me.bandCostos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandCostos.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandCostos.Caption = "COSTOS"
        Me.bandCostos.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.bandDetallados, Me.bandUtilidad, Me.bandFinal})
        Me.bandCostos.Name = "bandCostos"
        Me.bandCostos.VisibleIndex = 1
        Me.bandCostos.Width = 768
        '
        'bandDetallados
        '
        Me.bandDetallados.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandDetallados.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandDetallados.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandDetallados.AppearanceHeader.Options.UseBackColor = True
        Me.bandDetallados.AppearanceHeader.Options.UseBorderColor = True
        Me.bandDetallados.AppearanceHeader.Options.UseFont = True
        Me.bandDetallados.AppearanceHeader.Options.UseTextOptions = True
        Me.bandDetallados.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandDetallados.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandDetallados.Caption = "DETALLADOS"
        Me.bandDetallados.Columns.Add(Me.c_CostoMaterialDirecto)
        Me.bandDetallados.Columns.Add(Me.c_CostoOverhead)
        Me.bandDetallados.Columns.Add(Me.c_CostoFabricacion)
        Me.bandDetallados.Columns.Add(Me.c_Clasificacion)
        Me.bandDetallados.Name = "bandDetallados"
        Me.bandDetallados.VisibleIndex = 0
        Me.bandDetallados.Width = 413
        '
        'c_CostoMaterialDirecto
        '
        Me.c_CostoMaterialDirecto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.c_CostoMaterialDirecto.AppearanceHeader.Options.UseBackColor = True
        Me.c_CostoMaterialDirecto.AppearanceHeader.Options.UseTextOptions = True
        Me.c_CostoMaterialDirecto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_CostoMaterialDirecto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_CostoMaterialDirecto.Caption = "COSTO MATERIAL DIRECTO"
        Me.c_CostoMaterialDirecto.FieldName = "CostoMaterialDirecto"
        Me.c_CostoMaterialDirecto.MinWidth = 60
        Me.c_CostoMaterialDirecto.Name = "c_CostoMaterialDirecto"
        Me.c_CostoMaterialDirecto.Visible = True
        Me.c_CostoMaterialDirecto.Width = 104
        '
        'c_CostoOverhead
        '
        Me.c_CostoOverhead.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.c_CostoOverhead.AppearanceHeader.Options.UseBackColor = True
        Me.c_CostoOverhead.AppearanceHeader.Options.UseTextOptions = True
        Me.c_CostoOverhead.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_CostoOverhead.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_CostoOverhead.Caption = "COSTO OVERHEAD"
        Me.c_CostoOverhead.FieldName = "CostoOverhead"
        Me.c_CostoOverhead.MinWidth = 60
        Me.c_CostoOverhead.Name = "c_CostoOverhead"
        Me.c_CostoOverhead.Visible = True
        Me.c_CostoOverhead.Width = 102
        '
        'c_CostoFabricacion
        '
        Me.c_CostoFabricacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.c_CostoFabricacion.AppearanceHeader.Options.UseBackColor = True
        Me.c_CostoFabricacion.AppearanceHeader.Options.UseTextOptions = True
        Me.c_CostoFabricacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_CostoFabricacion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_CostoFabricacion.Caption = "COSTO FABRICACIÓN"
        Me.c_CostoFabricacion.FieldName = "CostoFabricacion"
        Me.c_CostoFabricacion.MinWidth = 60
        Me.c_CostoFabricacion.Name = "c_CostoFabricacion"
        Me.c_CostoFabricacion.Visible = True
        Me.c_CostoFabricacion.Width = 102
        '
        'c_Clasificacion
        '
        Me.c_Clasificacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.c_Clasificacion.AppearanceHeader.Options.UseBackColor = True
        Me.c_Clasificacion.AppearanceHeader.Options.UseTextOptions = True
        Me.c_Clasificacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_Clasificacion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_Clasificacion.Caption = "CLASIFICACIÓN"
        Me.c_Clasificacion.FieldName = "Clasificacion"
        Me.c_Clasificacion.MinWidth = 60
        Me.c_Clasificacion.Name = "c_Clasificacion"
        Me.c_Clasificacion.Visible = True
        Me.c_Clasificacion.Width = 105
        '
        'bandUtilidad
        '
        Me.bandUtilidad.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandUtilidad.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandUtilidad.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandUtilidad.AppearanceHeader.Options.UseBackColor = True
        Me.bandUtilidad.AppearanceHeader.Options.UseBorderColor = True
        Me.bandUtilidad.AppearanceHeader.Options.UseFont = True
        Me.bandUtilidad.AppearanceHeader.Options.UseTextOptions = True
        Me.bandUtilidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandUtilidad.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandUtilidad.Caption = "UTILIDAD"
        Me.bandUtilidad.Columns.Add(Me.c_UtilidadPorcentaje)
        Me.bandUtilidad.Columns.Add(Me.c_UtilidadPesos)
        Me.bandUtilidad.Name = "bandUtilidad"
        Me.bandUtilidad.VisibleIndex = 1
        Me.bandUtilidad.Width = 205
        '
        'c_UtilidadPorcentaje
        '
        Me.c_UtilidadPorcentaje.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.c_UtilidadPorcentaje.AppearanceHeader.Options.UseBackColor = True
        Me.c_UtilidadPorcentaje.AppearanceHeader.Options.UseTextOptions = True
        Me.c_UtilidadPorcentaje.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_UtilidadPorcentaje.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_UtilidadPorcentaje.Caption = "%"
        Me.c_UtilidadPorcentaje.DisplayFormat.FormatString = "{0:N0}%"
        Me.c_UtilidadPorcentaje.FieldName = "UtilidadPorcentaje"
        Me.c_UtilidadPorcentaje.MinWidth = 60
        Me.c_UtilidadPorcentaje.Name = "c_UtilidadPorcentaje"
        Me.c_UtilidadPorcentaje.Visible = True
        Me.c_UtilidadPorcentaje.Width = 102
        '
        'c_UtilidadPesos
        '
        Me.c_UtilidadPesos.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.c_UtilidadPesos.AppearanceHeader.Options.UseBackColor = True
        Me.c_UtilidadPesos.AppearanceHeader.Options.UseTextOptions = True
        Me.c_UtilidadPesos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_UtilidadPesos.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_UtilidadPesos.Caption = "$"
        Me.c_UtilidadPesos.DisplayFormat.FormatString = "${0:N0}"
        Me.c_UtilidadPesos.FieldName = "UtilidadPesos"
        Me.c_UtilidadPesos.MinWidth = 60
        Me.c_UtilidadPesos.Name = "c_UtilidadPesos"
        Me.c_UtilidadPesos.Visible = True
        Me.c_UtilidadPesos.Width = 103
        '
        'bandFinal
        '
        Me.bandFinal.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandFinal.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandFinal.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandFinal.AppearanceHeader.Options.UseBackColor = True
        Me.bandFinal.AppearanceHeader.Options.UseBorderColor = True
        Me.bandFinal.AppearanceHeader.Options.UseFont = True
        Me.bandFinal.AppearanceHeader.Options.UseTextOptions = True
        Me.bandFinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandFinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandFinal.Caption = "FINAL"
        Me.bandFinal.Columns.Add(Me.c_PrecioVentaComercializadora)
        Me.bandFinal.Name = "bandFinal"
        Me.bandFinal.VisibleIndex = 2
        Me.bandFinal.Width = 150
        '
        'c_PrecioVentaComercializadora
        '
        Me.c_PrecioVentaComercializadora.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_PrecioVentaComercializadora.AppearanceCell.Options.UseFont = True
        Me.c_PrecioVentaComercializadora.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.c_PrecioVentaComercializadora.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_PrecioVentaComercializadora.AppearanceHeader.Options.UseBackColor = True
        Me.c_PrecioVentaComercializadora.AppearanceHeader.Options.UseFont = True
        Me.c_PrecioVentaComercializadora.AppearanceHeader.Options.UseTextOptions = True
        Me.c_PrecioVentaComercializadora.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_PrecioVentaComercializadora.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_PrecioVentaComercializadora.Caption = "PRECIO VENTA COMERCIALIZADORA"
        Me.c_PrecioVentaComercializadora.FieldName = "PrecioVentaComercializadora"
        Me.c_PrecioVentaComercializadora.MinWidth = 100
        Me.c_PrecioVentaComercializadora.Name = "c_PrecioVentaComercializadora"
        Me.c_PrecioVentaComercializadora.Visible = True
        Me.c_PrecioVentaComercializadora.Width = 150
        '
        'bandUsuariosCambios
        '
        Me.bandUsuariosCambios.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandUsuariosCambios.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandUsuariosCambios.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandUsuariosCambios.AppearanceHeader.Options.UseBackColor = True
        Me.bandUsuariosCambios.AppearanceHeader.Options.UseBorderColor = True
        Me.bandUsuariosCambios.AppearanceHeader.Options.UseFont = True
        Me.bandUsuariosCambios.AppearanceHeader.Options.UseTextOptions = True
        Me.bandUsuariosCambios.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandUsuariosCambios.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandUsuariosCambios.Caption = "USUARIOS CAMBIOS"
        Me.bandUsuariosCambios.Columns.Add(Me.c_UsuarioSolicita)
        Me.bandUsuariosCambios.Columns.Add(Me.c_FechaSolicitud)
        Me.bandUsuariosCambios.Columns.Add(Me.c_UsuarioAutoriza)
        Me.bandUsuariosCambios.Columns.Add(Me.c_FechaAutoriza)
        Me.bandUsuariosCambios.Columns.Add(Me.c_UsuarioRechaza)
        Me.bandUsuariosCambios.Columns.Add(Me.c_FechaRechazo)
        Me.bandUsuariosCambios.Columns.Add(Me.c_UsuarioLibera)
        Me.bandUsuariosCambios.Columns.Add(Me.c_FechaLibero)
        Me.bandUsuariosCambios.Name = "bandUsuariosCambios"
        Me.bandUsuariosCambios.VisibleIndex = 2
        Me.bandUsuariosCambios.Width = 302
        '
        'c_UsuarioSolicita
        '
        Me.c_UsuarioSolicita.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_UsuarioSolicita.AppearanceHeader.Options.UseBackColor = True
        Me.c_UsuarioSolicita.AppearanceHeader.Options.UseTextOptions = True
        Me.c_UsuarioSolicita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_UsuarioSolicita.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_UsuarioSolicita.Caption = "USUARIO SOLICITÓ"
        Me.c_UsuarioSolicita.FieldName = "UsuarioSolicita"
        Me.c_UsuarioSolicita.Name = "c_UsuarioSolicita"
        Me.c_UsuarioSolicita.Visible = True
        Me.c_UsuarioSolicita.Width = 33
        '
        'c_FechaSolicitud
        '
        Me.c_FechaSolicitud.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_FechaSolicitud.AppearanceHeader.Options.UseBackColor = True
        Me.c_FechaSolicitud.AppearanceHeader.Options.UseTextOptions = True
        Me.c_FechaSolicitud.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_FechaSolicitud.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_FechaSolicitud.Caption = "FECHA SOLICITUD"
        Me.c_FechaSolicitud.FieldName = "FechaSolicita"
        Me.c_FechaSolicitud.Name = "c_FechaSolicitud"
        Me.c_FechaSolicitud.Visible = True
        Me.c_FechaSolicitud.Width = 33
        '
        'c_UsuarioAutoriza
        '
        Me.c_UsuarioAutoriza.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_UsuarioAutoriza.AppearanceHeader.Options.UseBackColor = True
        Me.c_UsuarioAutoriza.AppearanceHeader.Options.UseTextOptions = True
        Me.c_UsuarioAutoriza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_UsuarioAutoriza.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_UsuarioAutoriza.Caption = "USUARIO AUTORIZÓ"
        Me.c_UsuarioAutoriza.FieldName = "UsuarioAutoriza"
        Me.c_UsuarioAutoriza.Name = "c_UsuarioAutoriza"
        Me.c_UsuarioAutoriza.Visible = True
        Me.c_UsuarioAutoriza.Width = 33
        '
        'c_FechaAutoriza
        '
        Me.c_FechaAutoriza.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_FechaAutoriza.AppearanceHeader.Options.UseBackColor = True
        Me.c_FechaAutoriza.AppearanceHeader.Options.UseTextOptions = True
        Me.c_FechaAutoriza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_FechaAutoriza.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_FechaAutoriza.Caption = "FECHA AUTORIZO"
        Me.c_FechaAutoriza.FieldName = "FechaAutoriza"
        Me.c_FechaAutoriza.Name = "c_FechaAutoriza"
        Me.c_FechaAutoriza.Visible = True
        Me.c_FechaAutoriza.Width = 33
        '
        'c_UsuarioRechaza
        '
        Me.c_UsuarioRechaza.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_UsuarioRechaza.AppearanceHeader.Options.UseBackColor = True
        Me.c_UsuarioRechaza.AppearanceHeader.Options.UseTextOptions = True
        Me.c_UsuarioRechaza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_UsuarioRechaza.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_UsuarioRechaza.Caption = "USUARIO RECHAZÓ"
        Me.c_UsuarioRechaza.FieldName = "UsuarioRechaza"
        Me.c_UsuarioRechaza.Name = "c_UsuarioRechaza"
        Me.c_UsuarioRechaza.Visible = True
        Me.c_UsuarioRechaza.Width = 33
        '
        'c_FechaRechazo
        '
        Me.c_FechaRechazo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_FechaRechazo.AppearanceHeader.Options.UseBackColor = True
        Me.c_FechaRechazo.AppearanceHeader.Options.UseTextOptions = True
        Me.c_FechaRechazo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_FechaRechazo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_FechaRechazo.Caption = "FECHA RECHAZÓ"
        Me.c_FechaRechazo.FieldName = "FechaRechaza"
        Me.c_FechaRechazo.Name = "c_FechaRechazo"
        Me.c_FechaRechazo.Visible = True
        Me.c_FechaRechazo.Width = 33
        '
        'c_UsuarioLibera
        '
        Me.c_UsuarioLibera.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_UsuarioLibera.AppearanceHeader.Options.UseBackColor = True
        Me.c_UsuarioLibera.AppearanceHeader.Options.UseTextOptions = True
        Me.c_UsuarioLibera.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_UsuarioLibera.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_UsuarioLibera.Caption = "USUARIO LIBERO"
        Me.c_UsuarioLibera.FieldName = "UsuarioLibera"
        Me.c_UsuarioLibera.Name = "c_UsuarioLibera"
        Me.c_UsuarioLibera.Visible = True
        Me.c_UsuarioLibera.Width = 33
        '
        'c_FechaLibero
        '
        Me.c_FechaLibero.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_FechaLibero.AppearanceHeader.Options.UseBackColor = True
        Me.c_FechaLibero.AppearanceHeader.Options.UseTextOptions = True
        Me.c_FechaLibero.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_FechaLibero.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_FechaLibero.Caption = "FECHA LIBERÓ"
        Me.c_FechaLibero.FieldName = "FechaLibera"
        Me.c_FechaLibero.Name = "c_FechaLibero"
        Me.c_FechaLibero.Visible = True
        Me.c_FechaLibero.Width = 71
        '
        'bandEstatusProductoCosto
        '
        Me.bandEstatusProductoCosto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandEstatusProductoCosto.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandEstatusProductoCosto.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandEstatusProductoCosto.AppearanceHeader.Options.UseBackColor = True
        Me.bandEstatusProductoCosto.AppearanceHeader.Options.UseBorderColor = True
        Me.bandEstatusProductoCosto.AppearanceHeader.Options.UseFont = True
        Me.bandEstatusProductoCosto.AppearanceHeader.Options.UseTextOptions = True
        Me.bandEstatusProductoCosto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandEstatusProductoCosto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandEstatusProductoCosto.Caption = "ESTATUS"
        Me.bandEstatusProductoCosto.Columns.Add(Me.c_EstatusProducto)
        Me.bandEstatusProductoCosto.Columns.Add(Me.c_EstatusProductoCosto)
        Me.bandEstatusProductoCosto.Columns.Add(Me.c_EstatusProductoCostoId)
        Me.bandEstatusProductoCosto.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.bandEstatusProductoCosto.Name = "bandEstatusProductoCosto"
        Me.bandEstatusProductoCosto.VisibleIndex = 3
        Me.bandEstatusProductoCosto.Width = 160
        '
        'c_EstatusProducto
        '
        Me.c_EstatusProducto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_EstatusProducto.AppearanceHeader.Options.UseBackColor = True
        Me.c_EstatusProducto.AppearanceHeader.Options.UseTextOptions = True
        Me.c_EstatusProducto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_EstatusProducto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_EstatusProducto.Caption = "EST PRODUCTO"
        Me.c_EstatusProducto.FieldName = "EstatusProducto"
        Me.c_EstatusProducto.MinWidth = 60
        Me.c_EstatusProducto.Name = "c_EstatusProducto"
        Me.c_EstatusProducto.Visible = True
        Me.c_EstatusProducto.Width = 80
        '
        'c_EstatusProductoCosto
        '
        Me.c_EstatusProductoCosto.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.c_EstatusProductoCosto.AppearanceCell.Options.UseFont = True
        Me.c_EstatusProductoCosto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_EstatusProductoCosto.AppearanceHeader.Options.UseBackColor = True
        Me.c_EstatusProductoCosto.AppearanceHeader.Options.UseTextOptions = True
        Me.c_EstatusProductoCosto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_EstatusProductoCosto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_EstatusProductoCosto.Caption = "EST PRODUCTO COSTO"
        Me.c_EstatusProductoCosto.FieldName = "EstatusProductoCosto"
        Me.c_EstatusProductoCosto.MinWidth = 60
        Me.c_EstatusProductoCosto.Name = "c_EstatusProductoCosto"
        Me.c_EstatusProductoCosto.Visible = True
        Me.c_EstatusProductoCosto.Width = 80
        '
        'c_EstatusProductoCostoId
        '
        Me.c_EstatusProductoCostoId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_EstatusProductoCostoId.AppearanceHeader.Options.UseBackColor = True
        Me.c_EstatusProductoCostoId.AppearanceHeader.Options.UseTextOptions = True
        Me.c_EstatusProductoCostoId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.c_EstatusProductoCostoId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.c_EstatusProductoCostoId.Caption = "ESTATUS PRODUCTO COSTO ID"
        Me.c_EstatusProductoCostoId.FieldName = "EstatusProductoCostoId"
        Me.c_EstatusProductoCostoId.Name = "c_EstatusProductoCostoId"
        '
        'c_Observaciones
        '
        Me.c_Observaciones.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.c_Observaciones.AppearanceHeader.Options.UseBackColor = True
        Me.c_Observaciones.Caption = "OBSERVACIONES"
        Me.c_Observaciones.FieldName = "Observaciones"
        Me.c_Observaciones.Name = "c_Observaciones"
        '
        'tabPageResumenCostosEspeciales
        '
        Me.tabPageResumenCostosEspeciales.Controls.Add(Me.grdAdminResumenCostosEspeciales)
        Me.tabPageResumenCostosEspeciales.Name = "tabPageResumenCostosEspeciales"
        Me.tabPageResumenCostosEspeciales.Size = New System.Drawing.Size(1072, 385)
        Me.tabPageResumenCostosEspeciales.Text = "Resumen de Costos Especiales"
        '
        'grdAdminResumenCostosEspeciales
        '
        Me.grdAdminResumenCostosEspeciales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAdminResumenCostosEspeciales.Location = New System.Drawing.Point(0, 0)
        Me.grdAdminResumenCostosEspeciales.MainView = Me.grdVAdminResumenCostosEspeciales
        Me.grdAdminResumenCostosEspeciales.Name = "grdAdminResumenCostosEspeciales"
        Me.grdAdminResumenCostosEspeciales.Size = New System.Drawing.Size(1072, 385)
        Me.grdAdminResumenCostosEspeciales.TabIndex = 14
        Me.grdAdminResumenCostosEspeciales.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVAdminResumenCostosEspeciales})
        '
        'grdVAdminResumenCostosEspeciales
        '
        Me.grdVAdminResumenCostosEspeciales.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.bandColeccionesEspeciales, Me.bandEstatusProductoCostoEspecial, Me.bandUsuariosEspeciales, Me.bandEstatusEspeciales})
        Me.grdVAdminResumenCostosEspeciales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.grdVAdminResumenCostosEspeciales.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.ce_Sel, Me.ce_Foto, Me.ce_FotoModelo, Me.ce_Marca, Me.ce_FamiliaProyeccion, Me.ce_Cliente, Me.ce_ColeccionId, Me.ce_Coleccion, Me.ce_ModeloSAY, Me.ce_ModeloSICY, Me.ce_Piel, Me.ce_Color, Me.ce_Talla, Me.ce_ProductoEstiloId, Me.ce_NaveDesarrolloId, Me.ce_NaveDesarrollo, Me.ce_TemporadaId, Me.ce_Temporada, Me.ce_CostoMaterialDirecto, Me.ce_CostoOverhead, Me.ce_Clasificacion, Me.ce_CostoFabricacion, Me.ce_UtilidadPorcentaje, Me.ce_UtilidadPesos, Me.ce_PrecioVentaComercializadora, Me.ce_EstatusProductoId, Me.ce_EstatusProducto, Me.ce_EstatusProductoCostoId, Me.ce_EstatusProductoCosto, Me.ce_Observaciones, Me.ce_UsuarioSolicita, Me.ce_FechaSolicita, Me.ce_UsuarioAutoriza, Me.ce_FechaAutoriza, Me.ce_UsuarioRechaza, Me.ce_FechaRechaza, Me.ce_UsuarioLibera, Me.ce_FechaLibera})
        Me.grdVAdminResumenCostosEspeciales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grdVAdminResumenCostosEspeciales.GridControl = Me.grdAdminResumenCostosEspeciales
        Me.grdVAdminResumenCostosEspeciales.IndicatorWidth = 25
        Me.grdVAdminResumenCostosEspeciales.Name = "grdVAdminResumenCostosEspeciales"
        Me.grdVAdminResumenCostosEspeciales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVAdminResumenCostosEspeciales.OptionsBehavior.Editable = False
        Me.grdVAdminResumenCostosEspeciales.OptionsCustomization.AllowBandMoving = False
        Me.grdVAdminResumenCostosEspeciales.OptionsCustomization.AllowColumnMoving = False
        Me.grdVAdminResumenCostosEspeciales.OptionsCustomization.AllowGroup = False
        Me.grdVAdminResumenCostosEspeciales.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.grdVAdminResumenCostosEspeciales.OptionsSelection.CheckBoxSelectorField = "Sel"
        Me.grdVAdminResumenCostosEspeciales.OptionsSelection.MultiSelect = True
        Me.grdVAdminResumenCostosEspeciales.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.grdVAdminResumenCostosEspeciales.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.grdVAdminResumenCostosEspeciales.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVAdminResumenCostosEspeciales.OptionsView.ShowAutoFilterRow = True
        Me.grdVAdminResumenCostosEspeciales.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.grdVAdminResumenCostosEspeciales.OptionsView.ShowDetailButtons = False
        Me.grdVAdminResumenCostosEspeciales.OptionsView.ShowFooter = True
        Me.grdVAdminResumenCostosEspeciales.OptionsView.ShowGroupPanel = False
        Me.grdVAdminResumenCostosEspeciales.PaintStyleName = "Skin"
        '
        'bandColeccionesEspeciales
        '
        Me.bandColeccionesEspeciales.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandColeccionesEspeciales.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandColeccionesEspeciales.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandColeccionesEspeciales.AppearanceHeader.Options.UseBackColor = True
        Me.bandColeccionesEspeciales.AppearanceHeader.Options.UseBorderColor = True
        Me.bandColeccionesEspeciales.AppearanceHeader.Options.UseFont = True
        Me.bandColeccionesEspeciales.AppearanceHeader.Options.UseTextOptions = True
        Me.bandColeccionesEspeciales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandColeccionesEspeciales.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandColeccionesEspeciales.Caption = "COLECCIONES"
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Sel)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Foto)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_FotoModelo)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Marca)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_FamiliaProyeccion)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_ColeccionId)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Cliente)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Coleccion)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_ModeloSAY)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_ModeloSICY)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Piel)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Color)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Talla)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_ProductoEstiloId)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_EstatusProductoId)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_NaveDesarrolloId)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_NaveDesarrollo)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_TemporadaId)
        Me.bandColeccionesEspeciales.Columns.Add(Me.ce_Temporada)
        Me.bandColeccionesEspeciales.Name = "bandColeccionesEspeciales"
        Me.bandColeccionesEspeciales.VisibleIndex = 0
        Me.bandColeccionesEspeciales.Width = 395
        '
        'ce_Sel
        '
        Me.ce_Sel.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Sel.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Sel.Caption = " "
        Me.ce_Sel.FieldName = "Sel"
        Me.ce_Sel.Name = "ce_Sel"
        '
        'ce_Foto
        '
        Me.ce_Foto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Foto.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Foto.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Foto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Foto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Foto.Caption = "FOTO"
        Me.ce_Foto.FieldName = "Foto"
        Me.ce_Foto.Name = "ce_Foto"
        Me.ce_Foto.Visible = True
        Me.ce_Foto.Width = 31
        '
        'ce_FotoModelo
        '
        Me.ce_FotoModelo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_FotoModelo.AppearanceHeader.Options.UseBackColor = True
        Me.ce_FotoModelo.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_FotoModelo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_FotoModelo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_FotoModelo.Caption = "FOTO MODELO"
        Me.ce_FotoModelo.FieldName = "FotoModelo"
        Me.ce_FotoModelo.Name = "ce_FotoModelo"
        '
        'ce_Marca
        '
        Me.ce_Marca.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_Marca.AppearanceCell.Options.UseFont = True
        Me.ce_Marca.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Marca.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Marca.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Marca.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Marca.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Marca.Caption = "MARCA"
        Me.ce_Marca.FieldName = "Marca"
        Me.ce_Marca.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.ce_Marca.Name = "ce_Marca"
        Me.ce_Marca.Visible = True
        Me.ce_Marca.Width = 31
        '
        'ce_FamiliaProyeccion
        '
        Me.ce_FamiliaProyeccion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_FamiliaProyeccion.AppearanceHeader.Options.UseBackColor = True
        Me.ce_FamiliaProyeccion.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_FamiliaProyeccion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_FamiliaProyeccion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_FamiliaProyeccion.Caption = "FAMILIA PROYECCIÓN"
        Me.ce_FamiliaProyeccion.FieldName = "FamiliaProyeccion"
        Me.ce_FamiliaProyeccion.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.ce_FamiliaProyeccion.Name = "ce_FamiliaProyeccion"
        Me.ce_FamiliaProyeccion.Visible = True
        Me.ce_FamiliaProyeccion.Width = 31
        '
        'ce_ColeccionId
        '
        Me.ce_ColeccionId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_ColeccionId.AppearanceHeader.Options.UseBackColor = True
        Me.ce_ColeccionId.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_ColeccionId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_ColeccionId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_ColeccionId.Caption = "COLECCIÓN ID"
        Me.ce_ColeccionId.FieldName = "ColeccionId"
        Me.ce_ColeccionId.Name = "ce_ColeccionId"
        '
        'ce_Cliente
        '
        Me.ce_Cliente.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_Cliente.AppearanceCell.Options.UseFont = True
        Me.ce_Cliente.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ce_Cliente.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Cliente.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Cliente.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Cliente.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Cliente.Caption = "CLIENTE"
        Me.ce_Cliente.FieldName = "Cliente"
        Me.ce_Cliente.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DisplayText
        Me.ce_Cliente.Name = "ce_Cliente"
        Me.ce_Cliente.Visible = True
        Me.ce_Cliente.Width = 37
        '
        'ce_Coleccion
        '
        Me.ce_Coleccion.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_Coleccion.AppearanceCell.Options.UseFont = True
        Me.ce_Coleccion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Coleccion.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Coleccion.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Coleccion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Coleccion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Coleccion.Caption = "COLECCIÓN"
        Me.ce_Coleccion.FieldName = "Coleccion"
        Me.ce_Coleccion.Name = "ce_Coleccion"
        Me.ce_Coleccion.Visible = True
        Me.ce_Coleccion.Width = 31
        '
        'ce_ModeloSAY
        '
        Me.ce_ModeloSAY.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_ModeloSAY.AppearanceCell.Options.UseFont = True
        Me.ce_ModeloSAY.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_ModeloSAY.AppearanceHeader.Options.UseBackColor = True
        Me.ce_ModeloSAY.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_ModeloSAY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_ModeloSAY.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_ModeloSAY.Caption = "MODELO SAY"
        Me.ce_ModeloSAY.FieldName = "ModeloSAY"
        Me.ce_ModeloSAY.Name = "ce_ModeloSAY"
        Me.ce_ModeloSAY.Visible = True
        Me.ce_ModeloSAY.Width = 31
        '
        'ce_ModeloSICY
        '
        Me.ce_ModeloSICY.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_ModeloSICY.AppearanceHeader.Options.UseBackColor = True
        Me.ce_ModeloSICY.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_ModeloSICY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_ModeloSICY.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_ModeloSICY.Caption = "MODELO SICY"
        Me.ce_ModeloSICY.FieldName = "ModeloSICY"
        Me.ce_ModeloSICY.Name = "ce_ModeloSICY"
        Me.ce_ModeloSICY.Visible = True
        Me.ce_ModeloSICY.Width = 31
        '
        'ce_Piel
        '
        Me.ce_Piel.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_Piel.AppearanceCell.Options.UseFont = True
        Me.ce_Piel.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Piel.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Piel.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Piel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Piel.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Piel.Caption = "PIEL"
        Me.ce_Piel.FieldName = "Piel"
        Me.ce_Piel.Name = "ce_Piel"
        Me.ce_Piel.Visible = True
        Me.ce_Piel.Width = 31
        '
        'ce_Color
        '
        Me.ce_Color.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_Color.AppearanceCell.Options.UseFont = True
        Me.ce_Color.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Color.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Color.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Color.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Color.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Color.Caption = "COLOR"
        Me.ce_Color.FieldName = "Color"
        Me.ce_Color.Name = "ce_Color"
        Me.ce_Color.Visible = True
        Me.ce_Color.Width = 31
        '
        'ce_Talla
        '
        Me.ce_Talla.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_Talla.AppearanceCell.Options.UseFont = True
        Me.ce_Talla.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Talla.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Talla.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Talla.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Talla.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Talla.Caption = "CORRIDA"
        Me.ce_Talla.FieldName = "Talla"
        Me.ce_Talla.Name = "ce_Talla"
        Me.ce_Talla.Visible = True
        Me.ce_Talla.Width = 31
        '
        'ce_ProductoEstiloId
        '
        Me.ce_ProductoEstiloId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_ProductoEstiloId.AppearanceHeader.Options.UseBackColor = True
        Me.ce_ProductoEstiloId.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_ProductoEstiloId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_ProductoEstiloId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_ProductoEstiloId.Caption = "PRODUCTO ESTILO ID"
        Me.ce_ProductoEstiloId.FieldName = "ProductoEstiloId"
        Me.ce_ProductoEstiloId.Name = "ce_ProductoEstiloId"
        '
        'ce_EstatusProductoId
        '
        Me.ce_EstatusProductoId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_EstatusProductoId.AppearanceHeader.Options.UseBackColor = True
        Me.ce_EstatusProductoId.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_EstatusProductoId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_EstatusProductoId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_EstatusProductoId.Caption = "ESTATUS PRODUCTO ID"
        Me.ce_EstatusProductoId.FieldName = "EstatusProductoId"
        Me.ce_EstatusProductoId.Name = "ce_EstatusProductoId"
        '
        'ce_NaveDesarrolloId
        '
        Me.ce_NaveDesarrolloId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_NaveDesarrolloId.AppearanceHeader.Options.UseBackColor = True
        Me.ce_NaveDesarrolloId.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_NaveDesarrolloId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_NaveDesarrolloId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_NaveDesarrolloId.Caption = "NAVE DESARROLLO ID"
        Me.ce_NaveDesarrolloId.FieldName = "NaveDesarrolloId"
        Me.ce_NaveDesarrolloId.Name = "ce_NaveDesarrolloId"
        '
        'ce_NaveDesarrollo
        '
        Me.ce_NaveDesarrollo.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_NaveDesarrollo.AppearanceHeader.Options.UseBackColor = True
        Me.ce_NaveDesarrollo.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_NaveDesarrollo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_NaveDesarrollo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_NaveDesarrollo.Caption = "NAVE DESARROLLO"
        Me.ce_NaveDesarrollo.FieldName = "NaveDesarrollo"
        Me.ce_NaveDesarrollo.Name = "ce_NaveDesarrollo"
        Me.ce_NaveDesarrollo.Visible = True
        Me.ce_NaveDesarrollo.Width = 31
        '
        'ce_TemporadaId
        '
        Me.ce_TemporadaId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_TemporadaId.AppearanceHeader.Options.UseBackColor = True
        Me.ce_TemporadaId.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_TemporadaId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_TemporadaId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_TemporadaId.Caption = "TEMPORADA ID"
        Me.ce_TemporadaId.FieldName = "TemporadaId"
        Me.ce_TemporadaId.Name = "ce_TemporadaId"
        '
        'ce_Temporada
        '
        Me.ce_Temporada.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Temporada.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Temporada.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Temporada.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Temporada.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Temporada.Caption = "TEMPORADA"
        Me.ce_Temporada.FieldName = "Temporada"
        Me.ce_Temporada.Name = "ce_Temporada"
        Me.ce_Temporada.Visible = True
        Me.ce_Temporada.Width = 48
        '
        'bandEstatusProductoCostoEspecial
        '
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.Options.UseBackColor = True
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.Options.UseBorderColor = True
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.Options.UseFont = True
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.Options.UseTextOptions = True
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandEstatusProductoCostoEspecial.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandEstatusProductoCostoEspecial.Caption = "COSTOS"
        Me.bandEstatusProductoCostoEspecial.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand3, Me.GridBand4, Me.GridBand5})
        Me.bandEstatusProductoCostoEspecial.Name = "bandEstatusProductoCostoEspecial"
        Me.bandEstatusProductoCostoEspecial.VisibleIndex = 1
        Me.bandEstatusProductoCostoEspecial.Width = 760
        '
        'GridBand3
        '
        Me.GridBand3.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GridBand3.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GridBand3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand3.AppearanceHeader.Options.UseBackColor = True
        Me.GridBand3.AppearanceHeader.Options.UseBorderColor = True
        Me.GridBand3.AppearanceHeader.Options.UseFont = True
        Me.GridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridBand3.Caption = "DETALLADOS"
        Me.GridBand3.Columns.Add(Me.ce_CostoMaterialDirecto)
        Me.GridBand3.Columns.Add(Me.ce_CostoOverhead)
        Me.GridBand3.Columns.Add(Me.ce_CostoFabricacion)
        Me.GridBand3.Columns.Add(Me.ce_Clasificacion)
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.VisibleIndex = 0
        Me.GridBand3.Width = 407
        '
        'ce_CostoMaterialDirecto
        '
        Me.ce_CostoMaterialDirecto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ce_CostoMaterialDirecto.AppearanceHeader.Options.UseBackColor = True
        Me.ce_CostoMaterialDirecto.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_CostoMaterialDirecto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_CostoMaterialDirecto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_CostoMaterialDirecto.Caption = "COSTO MATERIAL DIRECTO"
        Me.ce_CostoMaterialDirecto.FieldName = "CostoMaterialDirecto"
        Me.ce_CostoMaterialDirecto.MinWidth = 60
        Me.ce_CostoMaterialDirecto.Name = "ce_CostoMaterialDirecto"
        Me.ce_CostoMaterialDirecto.Visible = True
        Me.ce_CostoMaterialDirecto.Width = 101
        '
        'ce_CostoOverhead
        '
        Me.ce_CostoOverhead.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ce_CostoOverhead.AppearanceHeader.Options.UseBackColor = True
        Me.ce_CostoOverhead.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_CostoOverhead.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_CostoOverhead.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_CostoOverhead.Caption = "COSTO OVERHEAD"
        Me.ce_CostoOverhead.FieldName = "CostoOverhead"
        Me.ce_CostoOverhead.MinWidth = 60
        Me.ce_CostoOverhead.Name = "ce_CostoOverhead"
        Me.ce_CostoOverhead.Visible = True
        Me.ce_CostoOverhead.Width = 101
        '
        'ce_CostoFabricacion
        '
        Me.ce_CostoFabricacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ce_CostoFabricacion.AppearanceHeader.Options.UseBackColor = True
        Me.ce_CostoFabricacion.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_CostoFabricacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_CostoFabricacion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_CostoFabricacion.Caption = "COSTO FABRICACIÓN"
        Me.ce_CostoFabricacion.FieldName = "CostoFabricacion"
        Me.ce_CostoFabricacion.MinWidth = 60
        Me.ce_CostoFabricacion.Name = "ce_CostoFabricacion"
        Me.ce_CostoFabricacion.Visible = True
        Me.ce_CostoFabricacion.Width = 101
        '
        'ce_Clasificacion
        '
        Me.ce_Clasificacion.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ce_Clasificacion.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Clasificacion.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_Clasificacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_Clasificacion.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_Clasificacion.Caption = "CLASIFICACIÓN"
        Me.ce_Clasificacion.FieldName = "Clasificacion"
        Me.ce_Clasificacion.MinWidth = 60
        Me.ce_Clasificacion.Name = "ce_Clasificacion"
        Me.ce_Clasificacion.Visible = True
        Me.ce_Clasificacion.Width = 104
        '
        'GridBand4
        '
        Me.GridBand4.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GridBand4.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GridBand4.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand4.AppearanceHeader.Options.UseBackColor = True
        Me.GridBand4.AppearanceHeader.Options.UseBorderColor = True
        Me.GridBand4.AppearanceHeader.Options.UseFont = True
        Me.GridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridBand4.Caption = "UTILIDAD"
        Me.GridBand4.Columns.Add(Me.ce_UtilidadPorcentaje)
        Me.GridBand4.Columns.Add(Me.ce_UtilidadPesos)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 1
        Me.GridBand4.Width = 203
        '
        'ce_UtilidadPorcentaje
        '
        Me.ce_UtilidadPorcentaje.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ce_UtilidadPorcentaje.AppearanceHeader.Options.UseBackColor = True
        Me.ce_UtilidadPorcentaje.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_UtilidadPorcentaje.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_UtilidadPorcentaje.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_UtilidadPorcentaje.Caption = "%"
        Me.ce_UtilidadPorcentaje.DisplayFormat.FormatString = "{0:N0}%"
        Me.ce_UtilidadPorcentaje.FieldName = "UtilidadPorcentaje"
        Me.ce_UtilidadPorcentaje.MinWidth = 60
        Me.ce_UtilidadPorcentaje.Name = "ce_UtilidadPorcentaje"
        Me.ce_UtilidadPorcentaje.Visible = True
        Me.ce_UtilidadPorcentaje.Width = 101
        '
        'ce_UtilidadPesos
        '
        Me.ce_UtilidadPesos.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ce_UtilidadPesos.AppearanceHeader.Options.UseBackColor = True
        Me.ce_UtilidadPesos.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_UtilidadPesos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_UtilidadPesos.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_UtilidadPesos.Caption = "$"
        Me.ce_UtilidadPesos.DisplayFormat.FormatString = "${0:N0}"
        Me.ce_UtilidadPesos.FieldName = "UtilidadPesos"
        Me.ce_UtilidadPesos.MinWidth = 60
        Me.ce_UtilidadPesos.Name = "ce_UtilidadPesos"
        Me.ce_UtilidadPesos.Visible = True
        Me.ce_UtilidadPesos.Width = 102
        '
        'GridBand5
        '
        Me.GridBand5.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GridBand5.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.GridBand5.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridBand5.AppearanceHeader.Options.UseBackColor = True
        Me.GridBand5.AppearanceHeader.Options.UseBorderColor = True
        Me.GridBand5.AppearanceHeader.Options.UseFont = True
        Me.GridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridBand5.Caption = "FINAL"
        Me.GridBand5.Columns.Add(Me.ce_PrecioVentaComercializadora)
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.VisibleIndex = 2
        Me.GridBand5.Width = 150
        '
        'ce_PrecioVentaComercializadora
        '
        Me.ce_PrecioVentaComercializadora.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_PrecioVentaComercializadora.AppearanceCell.Options.UseFont = True
        Me.ce_PrecioVentaComercializadora.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ce_PrecioVentaComercializadora.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_PrecioVentaComercializadora.AppearanceHeader.Options.UseBackColor = True
        Me.ce_PrecioVentaComercializadora.AppearanceHeader.Options.UseFont = True
        Me.ce_PrecioVentaComercializadora.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_PrecioVentaComercializadora.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_PrecioVentaComercializadora.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_PrecioVentaComercializadora.Caption = "PRECIO VENTA COMERCIALIZADORA"
        Me.ce_PrecioVentaComercializadora.FieldName = "PrecioVentaComercializadora"
        Me.ce_PrecioVentaComercializadora.MinWidth = 100
        Me.ce_PrecioVentaComercializadora.Name = "ce_PrecioVentaComercializadora"
        Me.ce_PrecioVentaComercializadora.Visible = True
        Me.ce_PrecioVentaComercializadora.Width = 150
        '
        'bandUsuariosEspeciales
        '
        Me.bandUsuariosEspeciales.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandUsuariosEspeciales.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandUsuariosEspeciales.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandUsuariosEspeciales.AppearanceHeader.Options.UseBackColor = True
        Me.bandUsuariosEspeciales.AppearanceHeader.Options.UseBorderColor = True
        Me.bandUsuariosEspeciales.AppearanceHeader.Options.UseFont = True
        Me.bandUsuariosEspeciales.AppearanceHeader.Options.UseTextOptions = True
        Me.bandUsuariosEspeciales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandUsuariosEspeciales.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandUsuariosEspeciales.Caption = "USUARIOS CAMBIOS"
        Me.bandUsuariosEspeciales.Columns.Add(Me.ce_UsuarioSolicita)
        Me.bandUsuariosEspeciales.Columns.Add(Me.ce_FechaSolicita)
        Me.bandUsuariosEspeciales.Columns.Add(Me.ce_UsuarioAutoriza)
        Me.bandUsuariosEspeciales.Columns.Add(Me.ce_FechaAutoriza)
        Me.bandUsuariosEspeciales.Columns.Add(Me.ce_UsuarioRechaza)
        Me.bandUsuariosEspeciales.Columns.Add(Me.ce_FechaRechaza)
        Me.bandUsuariosEspeciales.Columns.Add(Me.ce_UsuarioLibera)
        Me.bandUsuariosEspeciales.Columns.Add(Me.ce_FechaLibera)
        Me.bandUsuariosEspeciales.Name = "bandUsuariosEspeciales"
        Me.bandUsuariosEspeciales.VisibleIndex = 2
        Me.bandUsuariosEspeciales.Width = 304
        '
        'ce_UsuarioSolicita
        '
        Me.ce_UsuarioSolicita.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_UsuarioSolicita.AppearanceHeader.Options.UseBackColor = True
        Me.ce_UsuarioSolicita.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_UsuarioSolicita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_UsuarioSolicita.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_UsuarioSolicita.Caption = "USUARIO SOLICITÓ"
        Me.ce_UsuarioSolicita.FieldName = "UsuarioSolicita"
        Me.ce_UsuarioSolicita.Name = "ce_UsuarioSolicita"
        Me.ce_UsuarioSolicita.Visible = True
        Me.ce_UsuarioSolicita.Width = 33
        '
        'ce_FechaSolicita
        '
        Me.ce_FechaSolicita.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_FechaSolicita.AppearanceHeader.Options.UseBackColor = True
        Me.ce_FechaSolicita.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_FechaSolicita.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_FechaSolicita.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_FechaSolicita.Caption = "FECHA SOLICITUD"
        Me.ce_FechaSolicita.FieldName = "FechaSolicita"
        Me.ce_FechaSolicita.Name = "ce_FechaSolicita"
        Me.ce_FechaSolicita.Visible = True
        Me.ce_FechaSolicita.Width = 33
        '
        'ce_UsuarioAutoriza
        '
        Me.ce_UsuarioAutoriza.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_UsuarioAutoriza.AppearanceHeader.Options.UseBackColor = True
        Me.ce_UsuarioAutoriza.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_UsuarioAutoriza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_UsuarioAutoriza.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_UsuarioAutoriza.Caption = "USUARIO AUTORIZÓ"
        Me.ce_UsuarioAutoriza.FieldName = "UsuarioAutoriza"
        Me.ce_UsuarioAutoriza.Name = "ce_UsuarioAutoriza"
        Me.ce_UsuarioAutoriza.Visible = True
        Me.ce_UsuarioAutoriza.Width = 33
        '
        'ce_FechaAutoriza
        '
        Me.ce_FechaAutoriza.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_FechaAutoriza.AppearanceHeader.Options.UseBackColor = True
        Me.ce_FechaAutoriza.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_FechaAutoriza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_FechaAutoriza.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_FechaAutoriza.Caption = "FECHA AUTORIZO"
        Me.ce_FechaAutoriza.FieldName = "FechaAutoriza"
        Me.ce_FechaAutoriza.Name = "ce_FechaAutoriza"
        Me.ce_FechaAutoriza.Visible = True
        Me.ce_FechaAutoriza.Width = 33
        '
        'ce_UsuarioRechaza
        '
        Me.ce_UsuarioRechaza.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_UsuarioRechaza.AppearanceHeader.Options.UseBackColor = True
        Me.ce_UsuarioRechaza.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_UsuarioRechaza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_UsuarioRechaza.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_UsuarioRechaza.Caption = "USUARIO RECHAZÓ"
        Me.ce_UsuarioRechaza.FieldName = "UsuarioRechaza"
        Me.ce_UsuarioRechaza.Name = "ce_UsuarioRechaza"
        Me.ce_UsuarioRechaza.Visible = True
        Me.ce_UsuarioRechaza.Width = 33
        '
        'ce_FechaRechaza
        '
        Me.ce_FechaRechaza.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_FechaRechaza.AppearanceHeader.Options.UseBackColor = True
        Me.ce_FechaRechaza.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_FechaRechaza.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_FechaRechaza.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_FechaRechaza.Caption = "FECHA RECHAZÓ"
        Me.ce_FechaRechaza.FieldName = "FechaRechaza"
        Me.ce_FechaRechaza.Name = "ce_FechaRechaza"
        Me.ce_FechaRechaza.Visible = True
        Me.ce_FechaRechaza.Width = 33
        '
        'ce_UsuarioLibera
        '
        Me.ce_UsuarioLibera.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_UsuarioLibera.AppearanceHeader.Options.UseBackColor = True
        Me.ce_UsuarioLibera.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_UsuarioLibera.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_UsuarioLibera.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_UsuarioLibera.Caption = "USUARIO LIBERO"
        Me.ce_UsuarioLibera.FieldName = "UsuarioLibera"
        Me.ce_UsuarioLibera.Name = "ce_UsuarioLibera"
        Me.ce_UsuarioLibera.Visible = True
        Me.ce_UsuarioLibera.Width = 33
        '
        'ce_FechaLibera
        '
        Me.ce_FechaLibera.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_FechaLibera.AppearanceHeader.Options.UseBackColor = True
        Me.ce_FechaLibera.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_FechaLibera.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_FechaLibera.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_FechaLibera.Caption = "FECHA LIBERÓ"
        Me.ce_FechaLibera.FieldName = "FechaLibera"
        Me.ce_FechaLibera.Name = "ce_FechaLibera"
        Me.ce_FechaLibera.Visible = True
        Me.ce_FechaLibera.Width = 73
        '
        'bandEstatusEspeciales
        '
        Me.bandEstatusEspeciales.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandEstatusEspeciales.AppearanceHeader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bandEstatusEspeciales.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bandEstatusEspeciales.AppearanceHeader.Options.UseBackColor = True
        Me.bandEstatusEspeciales.AppearanceHeader.Options.UseBorderColor = True
        Me.bandEstatusEspeciales.AppearanceHeader.Options.UseFont = True
        Me.bandEstatusEspeciales.AppearanceHeader.Options.UseTextOptions = True
        Me.bandEstatusEspeciales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bandEstatusEspeciales.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.bandEstatusEspeciales.Caption = "ESTATUS"
        Me.bandEstatusEspeciales.Columns.Add(Me.ce_EstatusProducto)
        Me.bandEstatusEspeciales.Columns.Add(Me.ce_EstatusProductoCosto)
        Me.bandEstatusEspeciales.Columns.Add(Me.ce_EstatusProductoCostoId)
        Me.bandEstatusEspeciales.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
        Me.bandEstatusEspeciales.Name = "bandEstatusEspeciales"
        Me.bandEstatusEspeciales.VisibleIndex = 3
        Me.bandEstatusEspeciales.Width = 160
        '
        'ce_EstatusProducto
        '
        Me.ce_EstatusProducto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_EstatusProducto.AppearanceHeader.Options.UseBackColor = True
        Me.ce_EstatusProducto.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_EstatusProducto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_EstatusProducto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_EstatusProducto.Caption = "EST PRODUCTO"
        Me.ce_EstatusProducto.FieldName = "EstatusProducto"
        Me.ce_EstatusProducto.MinWidth = 60
        Me.ce_EstatusProducto.Name = "ce_EstatusProducto"
        Me.ce_EstatusProducto.Visible = True
        Me.ce_EstatusProducto.Width = 80
        '
        'ce_EstatusProductoCosto
        '
        Me.ce_EstatusProductoCosto.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ce_EstatusProductoCosto.AppearanceCell.Options.UseFont = True
        Me.ce_EstatusProductoCosto.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_EstatusProductoCosto.AppearanceHeader.Options.UseBackColor = True
        Me.ce_EstatusProductoCosto.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_EstatusProductoCosto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_EstatusProductoCosto.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_EstatusProductoCosto.Caption = "EST PRODUCTO COSTO"
        Me.ce_EstatusProductoCosto.FieldName = "EstatusProductoCosto"
        Me.ce_EstatusProductoCosto.MinWidth = 60
        Me.ce_EstatusProductoCosto.Name = "ce_EstatusProductoCosto"
        Me.ce_EstatusProductoCosto.Visible = True
        Me.ce_EstatusProductoCosto.Width = 80
        '
        'ce_EstatusProductoCostoId
        '
        Me.ce_EstatusProductoCostoId.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_EstatusProductoCostoId.AppearanceHeader.Options.UseBackColor = True
        Me.ce_EstatusProductoCostoId.AppearanceHeader.Options.UseTextOptions = True
        Me.ce_EstatusProductoCostoId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ce_EstatusProductoCostoId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ce_EstatusProductoCostoId.Caption = "ESTATUS PRODUCTO COSTO ID"
        Me.ce_EstatusProductoCostoId.FieldName = "EstatusProductoCostoId"
        Me.ce_EstatusProductoCostoId.Name = "ce_EstatusProductoCostoId"
        '
        'ce_Observaciones
        '
        Me.ce_Observaciones.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ce_Observaciones.AppearanceHeader.Options.UseBackColor = True
        Me.ce_Observaciones.Caption = "OBSERVACIONES"
        Me.ce_Observaciones.FieldName = "Observaciones"
        Me.ce_Observaciones.Name = "ce_Observaciones"
        '
        'pnlFooter
        '
        Me.pnlFooter.Appearance.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFooter.Appearance.Options.UseBackColor = True
        Me.pnlFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlFooter.Controls.Add(Me.lblInformativo_Especial)
        Me.pnlFooter.Controls.Add(Me.lblInformativo_General)
        Me.pnlFooter.Controls.Add(Me.chkSimplificarInformacion)
        Me.pnlFooter.Controls.Add(Me.pnlTotalRegistros)
        Me.pnlFooter.Controls.Add(Me.pnlMostrar)
        Me.pnlFooter.Controls.Add(Me.pnlCerrar)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(2, 621)
        Me.pnlFooter.LookAndFeel.SkinMaskColor = System.Drawing.Color.AliceBlue
        Me.pnlFooter.LookAndFeel.SkinName = "DevExpress Style"
        Me.pnlFooter.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(1074, 65)
        Me.pnlFooter.TabIndex = 5
        '
        'lblInformativo_Especial
        '
        Me.lblInformativo_Especial.Location = New System.Drawing.Point(279, 40)
        Me.lblInformativo_Especial.Name = "lblInformativo_Especial"
        Me.lblInformativo_Especial.Size = New System.Drawing.Size(66, 13)
        Me.lblInformativo_Especial.TabIndex = 125
        Me.lblInformativo_Especial.Text = "ESP - Especial"
        '
        'lblInformativo_General
        '
        Me.lblInformativo_General.Location = New System.Drawing.Point(279, 16)
        Me.lblInformativo_General.Name = "lblInformativo_General"
        Me.lblInformativo_General.Size = New System.Drawing.Size(73, 13)
        Me.lblInformativo_General.TabIndex = 124
        Me.lblInformativo_General.Text = "GRNL - General"
        '
        'chkSimplificarInformacion
        '
        Me.chkSimplificarInformacion.Location = New System.Drawing.Point(130, 10)
        Me.chkSimplificarInformacion.Name = "chkSimplificarInformacion"
        Me.chkSimplificarInformacion.Properties.Caption = "Simplificar Información"
        Me.chkSimplificarInformacion.Size = New System.Drawing.Size(137, 19)
        Me.chkSimplificarInformacion.TabIndex = 123
        '
        'pnlTotalRegistros
        '
        Me.pnlTotalRegistros.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlTotalRegistros.Controls.Add(Me.lblRegistros)
        Me.pnlTotalRegistros.Controls.Add(Me.lblTotalRegistros)
        Me.pnlTotalRegistros.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTotalRegistros.Location = New System.Drawing.Point(0, 0)
        Me.pnlTotalRegistros.Name = "pnlTotalRegistros"
        Me.pnlTotalRegistros.Size = New System.Drawing.Size(110, 65)
        Me.pnlTotalRegistros.TabIndex = 122
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.Black
        Me.lblRegistros.Location = New System.Drawing.Point(12, 7)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 24)
        Me.lblRegistros.TabIndex = 119
        Me.lblRegistros.Text = "Registros"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalRegistros.Location = New System.Drawing.Point(11, 32)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(86, 24)
        Me.lblTotalRegistros.TabIndex = 120
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMostrar
        '
        Me.pnlMostrar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlMostrar.Controls.Add(Me.lblMostrar)
        Me.pnlMostrar.Controls.Add(Me.btnMostrar)
        Me.pnlMostrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMostrar.Location = New System.Drawing.Point(944, 0)
        Me.pnlMostrar.Name = "pnlMostrar"
        Me.pnlMostrar.Size = New System.Drawing.Size(65, 65)
        Me.pnlMostrar.TabIndex = 0
        '
        'lblMostrar
        '
        Me.lblMostrar.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblMostrar.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Appearance.Options.UseFont = True
        Me.lblMostrar.Appearance.Options.UseForeColor = True
        Me.lblMostrar.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.lblMostrar.Location = New System.Drawing.Point(15, 43)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(35, 13)
        Me.lblMostrar.TabIndex = 1
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMostrar.ImageOptions.Image = CType(resources.GetObject("btnMostrar.ImageOptions.Image"), System.Drawing.Image)
        Me.btnMostrar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnMostrar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnMostrar.Location = New System.Drawing.Point(17, 5)
        Me.btnMostrar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 1
        '
        'pnlCerrar
        '
        Me.pnlCerrar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlCerrar.Controls.Add(Me.lblCerrar)
        Me.pnlCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(1009, 0)
        Me.pnlCerrar.Name = "pnlCerrar"
        Me.pnlCerrar.Size = New System.Drawing.Size(65, 65)
        Me.pnlCerrar.TabIndex = 8
        '
        'lblCerrar
        '
        Me.lblCerrar.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCerrar.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Appearance.Options.UseFont = True
        Me.lblCerrar.Appearance.Options.UseForeColor = True
        Me.lblCerrar.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.lblCerrar.Location = New System.Drawing.Point(19, 43)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(28, 13)
        Me.lblCerrar.TabIndex = 1
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCerrar.ImageOptions.Image = CType(resources.GetObject("btnCerrar.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnCerrar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnCerrar.Location = New System.Drawing.Point(17, 5)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        '
        'pnlParametros
        '
        Me.pnlParametros.Appearance.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Appearance.Options.UseBackColor = True
        Me.pnlParametros.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlParametros.Controls.Add(Me.pnlVigenciaEspecial)
        Me.pnlParametros.Controls.Add(Me.PanelControl1)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(2, 91)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1074, 120)
        Me.pnlParametros.TabIndex = 4
        '
        'pnlVigenciaEspecial
        '
        Me.pnlVigenciaEspecial.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlVigenciaEspecial.Controls.Add(Me.lblVigencia)
        Me.pnlVigenciaEspecial.Controls.Add(Me.dtpVigenciaEspecial)
        Me.pnlVigenciaEspecial.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlVigenciaEspecial.Location = New System.Drawing.Point(855, 0)
        Me.pnlVigenciaEspecial.Name = "pnlVigenciaEspecial"
        Me.pnlVigenciaEspecial.Size = New System.Drawing.Size(168, 120)
        Me.pnlVigenciaEspecial.TabIndex = 163
        '
        'lblVigencia
        '
        Me.lblVigencia.Location = New System.Drawing.Point(16, 17)
        Me.lblVigencia.Name = "lblVigencia"
        Me.lblVigencia.Size = New System.Drawing.Size(135, 13)
        Me.lblVigencia.TabIndex = 1
        Me.lblVigencia.Text = "Vigencia Artículos Especiales"
        '
        'dtpVigenciaEspecial
        '
        Me.dtpVigenciaEspecial.EditValue = Nothing
        Me.dtpVigenciaEspecial.Location = New System.Drawing.Point(23, 36)
        Me.dtpVigenciaEspecial.MenuManager = Me.BarManagerTipoReporte
        Me.dtpVigenciaEspecial.Name = "dtpVigenciaEspecial"
        Me.dtpVigenciaEspecial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpVigenciaEspecial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtpVigenciaEspecial.Size = New System.Drawing.Size(122, 20)
        Me.dtpVigenciaEspecial.TabIndex = 0
        '
        'BarManagerTipoReporte
        '
        Me.BarManagerTipoReporte.DockControls.Add(Me.barDockControlTop)
        Me.BarManagerTipoReporte.DockControls.Add(Me.barDockControlBottom)
        Me.BarManagerTipoReporte.DockControls.Add(Me.barDockControlLeft)
        Me.BarManagerTipoReporte.DockControls.Add(Me.barDockControlRight)
        Me.BarManagerTipoReporte.Form = Me
        Me.BarManagerTipoReporte.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.barbtnFormatoGeneral_PDF, Me.barbtnFormatoClienteEspecial_PDF, Me.barbtnFormatoClienteEspecial_Excel, Me.barbtnFormatoGeneral_Excel, Me.barbtnAplicarValoresMasivos, Me.bartxtValorMasivo, Me.BarEditItem1, Me.BarButtonItem1})
        Me.BarManagerTipoReporte.MaxItemId = 8
        Me.BarManagerTipoReporte.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repoTextEdit, Me.RepositoryItemDateEdit1})
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManagerTipoReporte
        Me.barDockControlTop.Size = New System.Drawing.Size(1078, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 688)
        Me.barDockControlBottom.Manager = Me.BarManagerTipoReporte
        Me.barDockControlBottom.Size = New System.Drawing.Size(1078, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManagerTipoReporte
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 688)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1078, 0)
        Me.barDockControlRight.Manager = Me.BarManagerTipoReporte
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 688)
        '
        'barbtnFormatoGeneral_PDF
        '
        Me.barbtnFormatoGeneral_PDF.Caption = "Formato General"
        Me.barbtnFormatoGeneral_PDF.Id = 0
        Me.barbtnFormatoGeneral_PDF.Name = "barbtnFormatoGeneral_PDF"
        '
        'barbtnFormatoClienteEspecial_PDF
        '
        Me.barbtnFormatoClienteEspecial_PDF.Caption = "Formato Cliente Especial"
        Me.barbtnFormatoClienteEspecial_PDF.Id = 1
        Me.barbtnFormatoClienteEspecial_PDF.Name = "barbtnFormatoClienteEspecial_PDF"
        '
        'barbtnFormatoClienteEspecial_Excel
        '
        Me.barbtnFormatoClienteEspecial_Excel.Caption = "Formato Cliente Especial"
        Me.barbtnFormatoClienteEspecial_Excel.Id = 2
        Me.barbtnFormatoClienteEspecial_Excel.Name = "barbtnFormatoClienteEspecial_Excel"
        '
        'barbtnFormatoGeneral_Excel
        '
        Me.barbtnFormatoGeneral_Excel.Caption = "Formato General"
        Me.barbtnFormatoGeneral_Excel.Id = 3
        Me.barbtnFormatoGeneral_Excel.Name = "barbtnFormatoGeneral_Excel"
        '
        'barbtnAplicarValoresMasivos
        '
        Me.barbtnAplicarValoresMasivos.Caption = "APLICAR VALORES MASIVOS"
        Me.barbtnAplicarValoresMasivos.Id = 4
        Me.barbtnAplicarValoresMasivos.Name = "barbtnAplicarValoresMasivos"
        '
        'bartxtValorMasivo
        '
        Me.bartxtValorMasivo.Caption = "ValorMasivo"
        Me.bartxtValorMasivo.Id = 5
        Me.bartxtValorMasivo.Name = "bartxtValorMasivo"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "BarEditItem1"
        Me.BarEditItem1.Edit = Me.RepositoryItemDateEdit1
        Me.BarEditItem1.Id = 6
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 7
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'repoTextEdit
        '
        Me.repoTextEdit.AutoHeight = False
        Me.repoTextEdit.Name = "repoTextEdit"
        '
        'btnGenerarFormatoPDF
        '
        Me.btnGenerarFormatoPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGenerarFormatoPDF.ImageOptions.Image = Global.Produccion.Vista.My.Resources.Resources.pdf_ver_32
        Me.btnGenerarFormatoPDF.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnGenerarFormatoPDF.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnGenerarFormatoPDF.Location = New System.Drawing.Point(19, 5)
        Me.btnGenerarFormatoPDF.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGenerarFormatoPDF.Name = "btnGenerarFormatoPDF"
        Me.BarManagerTipoReporte.SetPopupContextMenu(Me.btnGenerarFormatoPDF, Me.PopupTipoReporte_PDF)
        Me.btnGenerarFormatoPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarFormatoPDF.TabIndex = 0
        Me.btnGenerarFormatoPDF.ToolTip = "GENERA LOS FORMATOS EN PDF" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PARA LA AUTORIZACIÓN DE LOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MODELOS Y/O COLECCIONES" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SELECCIONADAS"
        '
        'PopupTipoReporte_PDF
        '
        Me.PopupTipoReporte_PDF.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barbtnFormatoGeneral_PDF), New DevExpress.XtraBars.LinkPersistInfo(Me.barbtnFormatoClienteEspecial_PDF)})
        Me.PopupTipoReporte_PDF.Manager = Me.BarManagerTipoReporte
        Me.PopupTipoReporte_PDF.Name = "PopupTipoReporte_PDF"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.txtTemporada)
        Me.PanelControl1.Controls.Add(Me.txtNaveDesarrollo)
        Me.PanelControl1.Controls.Add(Me.separador)
        Me.PanelControl1.Controls.Add(Me.txtMarca)
        Me.PanelControl1.Controls.Add(Me.chkMostrarImagenes)
        Me.PanelControl1.Controls.Add(Me.slueComboNaveDesarrollo)
        Me.PanelControl1.Controls.Add(Me.txtEstatusProductoCosto)
        Me.PanelControl1.Controls.Add(Me.lookUpMarca)
        Me.PanelControl1.Controls.Add(Me.slueComboEstatusProductoCosto)
        Me.PanelControl1.Controls.Add(Me.lblNaveDesarrollo)
        Me.PanelControl1.Controls.Add(Me.lblEstatusProductoCosto)
        Me.PanelControl1.Controls.Add(Me.lblMarca)
        Me.PanelControl1.Controls.Add(Me.txtColeccion)
        Me.PanelControl1.Controls.Add(Me.slueComboColeccion)
        Me.PanelControl1.Controls.Add(Me.lblTemporada)
        Me.PanelControl1.Controls.Add(Me.lblColeccion)
        Me.PanelControl1.Controls.Add(Me.slueComboTemporada)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(855, 120)
        Me.PanelControl1.TabIndex = 162
        '
        'txtTemporada
        '
        Me.txtTemporada.EditValue = "SELECCIONE UNA TEMPORADA"
        Me.txtTemporada.Enabled = False
        Me.txtTemporada.Location = New System.Drawing.Point(102, 80)
        Me.txtTemporada.Name = "txtTemporada"
        Me.txtTemporada.Properties.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtTemporada.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtTemporada.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtTemporada.Properties.Appearance.Options.UseBackColor = True
        Me.txtTemporada.Properties.Appearance.Options.UseFont = True
        Me.txtTemporada.Properties.Appearance.Options.UseForeColor = True
        Me.txtTemporada.Size = New System.Drawing.Size(188, 20)
        Me.txtTemporada.TabIndex = 2
        '
        'txtNaveDesarrollo
        '
        Me.txtNaveDesarrollo.EditValue = "SELECCIONE UNA NAVE"
        Me.txtNaveDesarrollo.Enabled = False
        Me.txtNaveDesarrollo.Location = New System.Drawing.Point(102, 18)
        Me.txtNaveDesarrollo.Name = "txtNaveDesarrollo"
        Me.txtNaveDesarrollo.Properties.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtNaveDesarrollo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtNaveDesarrollo.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtNaveDesarrollo.Properties.Appearance.Options.UseBackColor = True
        Me.txtNaveDesarrollo.Properties.Appearance.Options.UseFont = True
        Me.txtNaveDesarrollo.Properties.Appearance.Options.UseForeColor = True
        Me.txtNaveDesarrollo.Size = New System.Drawing.Size(188, 20)
        Me.txtNaveDesarrollo.TabIndex = 0
        '
        'separador
        '
        Me.separador.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.separador.Location = New System.Drawing.Point(686, 6)
        Me.separador.Name = "separador"
        Me.separador.Size = New System.Drawing.Size(33, 108)
        Me.separador.TabIndex = 160
        '
        'txtMarca
        '
        Me.txtMarca.EditValue = "SELECCIONE UNA MARCA"
        Me.txtMarca.Enabled = False
        Me.txtMarca.Location = New System.Drawing.Point(102, 49)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Properties.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtMarca.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtMarca.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtMarca.Properties.Appearance.Options.UseBackColor = True
        Me.txtMarca.Properties.Appearance.Options.UseFont = True
        Me.txtMarca.Properties.Appearance.Options.UseForeColor = True
        Me.txtMarca.Size = New System.Drawing.Size(188, 20)
        Me.txtMarca.TabIndex = 5
        '
        'chkMostrarImagenes
        '
        Me.chkMostrarImagenes.Location = New System.Drawing.Point(731, 14)
        Me.chkMostrarImagenes.Name = "chkMostrarImagenes"
        Me.chkMostrarImagenes.Properties.Caption = "Mostrar Imágenes"
        Me.chkMostrarImagenes.Size = New System.Drawing.Size(121, 20)
        Me.chkMostrarImagenes.TabIndex = 5
        '
        'slueComboNaveDesarrollo
        '
        Me.slueComboNaveDesarrollo.EditValue = ""
        Me.slueComboNaveDesarrollo.Location = New System.Drawing.Point(102, 18)
        Me.slueComboNaveDesarrollo.Name = "slueComboNaveDesarrollo"
        Me.slueComboNaveDesarrollo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "Limpiar Filtro", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.slueComboNaveDesarrollo.Properties.DisplayMember = "NaveDesarrollo"
        Me.slueComboNaveDesarrollo.Properties.NullText = ""
        Me.slueComboNaveDesarrollo.Properties.PopupSizeable = False
        Me.slueComboNaveDesarrollo.Properties.PopupView = Me.grdvComboNaveDesarrollo
        Me.slueComboNaveDesarrollo.Properties.ValueMember = "codr_colaboradorid"
        Me.slueComboNaveDesarrollo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.slueComboNaveDesarrollo.Size = New System.Drawing.Size(222, 20)
        Me.slueComboNaveDesarrollo.TabIndex = 6
        '
        'grdvComboNaveDesarrollo
        '
        Me.grdvComboNaveDesarrollo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.cSel, Me.cNaveDesarrolloId, Me.cNaveDesarrollo, Me.cNaveGrupo})
        Me.grdvComboNaveDesarrollo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grdvComboNaveDesarrollo.Name = "grdvComboNaveDesarrollo"
        Me.grdvComboNaveDesarrollo.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.grdvComboNaveDesarrollo.OptionsSelection.CheckBoxSelectorField = "Sel"
        Me.grdvComboNaveDesarrollo.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grdvComboNaveDesarrollo.OptionsSelection.MultiSelect = True
        Me.grdvComboNaveDesarrollo.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.grdvComboNaveDesarrollo.OptionsView.ShowGroupPanel = False
        '
        'cSel
        '
        Me.cSel.Caption = "Sel"
        Me.cSel.FieldName = "Sel"
        Me.cSel.Name = "cSel"
        '
        'cNaveDesarrolloId
        '
        Me.cNaveDesarrolloId.Caption = "Id"
        Me.cNaveDesarrolloId.FieldName = "nave_naveid"
        Me.cNaveDesarrolloId.Name = "cNaveDesarrolloId"
        '
        'cNaveDesarrollo
        '
        Me.cNaveDesarrollo.Caption = "Nave"
        Me.cNaveDesarrollo.FieldName = "nave_nombre"
        Me.cNaveDesarrollo.Name = "cNaveDesarrollo"
        Me.cNaveDesarrollo.Visible = True
        Me.cNaveDesarrollo.VisibleIndex = 1
        '
        'txtEstatusProductoCosto
        '
        Me.txtEstatusProductoCosto.EditValue = "SELECCIONE UN ESTATUS"
        Me.txtEstatusProductoCosto.Enabled = False
        Me.txtEstatusProductoCosto.Location = New System.Drawing.Point(435, 49)
        Me.txtEstatusProductoCosto.Name = "txtEstatusProductoCosto"
        Me.txtEstatusProductoCosto.Properties.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtEstatusProductoCosto.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtEstatusProductoCosto.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtEstatusProductoCosto.Properties.Appearance.Options.UseBackColor = True
        Me.txtEstatusProductoCosto.Properties.Appearance.Options.UseFont = True
        Me.txtEstatusProductoCosto.Properties.Appearance.Options.UseForeColor = True
        Me.txtEstatusProductoCosto.Size = New System.Drawing.Size(200, 20)
        Me.txtEstatusProductoCosto.TabIndex = 4
        '
        'lookUpMarca
        '
        Me.lookUpMarca.EditValue = ""
        Me.lookUpMarca.Location = New System.Drawing.Point(102, 49)
        Me.lookUpMarca.Name = "lookUpMarca"
        Me.lookUpMarca.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "Limpiar Filtro", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.lookUpMarca.Properties.DisplayMember = "Temporada"
        Me.lookUpMarca.Properties.NullText = ""
        Me.lookUpMarca.Properties.PopupSizeable = False
        Me.lookUpMarca.Properties.PopupView = Me.GridView1
        Me.lookUpMarca.Properties.ValueMember = "codr_colaboradorid"
        Me.lookUpMarca.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lookUpMarca.Size = New System.Drawing.Size(222, 20)
        Me.lookUpMarca.TabIndex = 4
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Sel, Me.MarcaId, Me.MarcaNombre, Me.EsLicencias})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.GridView1.OptionsSelection.CheckBoxSelectorField = "Sel"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Sel
        '
        Me.Sel.Caption = "Sel"
        Me.Sel.FieldName = "Sel"
        Me.Sel.Name = "Sel"
        '
        'MarcaId
        '
        Me.MarcaId.Caption = "MarcaId"
        Me.MarcaId.FieldName = "MarcaId"
        Me.MarcaId.Name = "MarcaId"
        '
        'MarcaNombre
        '
        Me.MarcaNombre.Caption = "MarcaNombre"
        Me.MarcaNombre.FieldName = "MarcaNombre"
        Me.MarcaNombre.Name = "MarcaNombre"
        Me.MarcaNombre.Visible = True
        Me.MarcaNombre.VisibleIndex = 1
        '
        'EsLicencias
        '
        Me.EsLicencias.Caption = "EsLicencias"
        Me.EsLicencias.FieldName = "EsLicencias"
        Me.EsLicencias.Name = "EsLicencias"
        Me.EsLicencias.Visible = True
        Me.EsLicencias.VisibleIndex = 2
        '
        'slueComboEstatusProductoCosto
        '
        Me.slueComboEstatusProductoCosto.EditValue = ""
        Me.slueComboEstatusProductoCosto.Location = New System.Drawing.Point(435, 49)
        Me.slueComboEstatusProductoCosto.Name = "slueComboEstatusProductoCosto"
        Me.slueComboEstatusProductoCosto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, True, True, False, EditorButtonImageOptions3, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, SerializableAppearanceObject10, SerializableAppearanceObject11, SerializableAppearanceObject12, "Limpiar Filtro", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.slueComboEstatusProductoCosto.Properties.DisplayMember = "Coleccion"
        Me.slueComboEstatusProductoCosto.Properties.NullText = ""
        Me.slueComboEstatusProductoCosto.Properties.PopupSizeable = False
        Me.slueComboEstatusProductoCosto.Properties.PopupView = Me.grdVComboEstatusProductoCosto
        Me.slueComboEstatusProductoCosto.Properties.ValueMember = "codr_colaboradorid"
        Me.slueComboEstatusProductoCosto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.slueComboEstatusProductoCosto.Size = New System.Drawing.Size(234, 20)
        Me.slueComboEstatusProductoCosto.TabIndex = 157
        '
        'grdVComboEstatusProductoCosto
        '
        Me.grdVComboEstatusProductoCosto.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.cSel_E, Me.cEstatusId, Me.cEstatus})
        Me.grdVComboEstatusProductoCosto.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grdVComboEstatusProductoCosto.Name = "grdVComboEstatusProductoCosto"
        Me.grdVComboEstatusProductoCosto.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.grdVComboEstatusProductoCosto.OptionsSelection.CheckBoxSelectorField = "Sel"
        Me.grdVComboEstatusProductoCosto.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grdVComboEstatusProductoCosto.OptionsSelection.MultiSelect = True
        Me.grdVComboEstatusProductoCosto.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.grdVComboEstatusProductoCosto.OptionsView.ShowGroupPanel = False
        '
        'cSel_E
        '
        Me.cSel_E.Caption = "Sel"
        Me.cSel_E.FieldName = "Sel"
        Me.cSel_E.Name = "cSel_E"
        '
        'cEstatusId
        '
        Me.cEstatusId.Caption = "EstatusId"
        Me.cEstatusId.FieldName = "EstatusId"
        Me.cEstatusId.Name = "cEstatusId"
        '
        'cEstatus
        '
        Me.cEstatus.Caption = "Estatus"
        Me.cEstatus.FieldName = "Estatus"
        Me.cEstatus.Name = "cEstatus"
        Me.cEstatus.Visible = True
        Me.cEstatus.VisibleIndex = 1
        '
        'lblNaveDesarrollo
        '
        Me.lblNaveDesarrollo.Location = New System.Drawing.Point(20, 21)
        Me.lblNaveDesarrollo.Name = "lblNaveDesarrollo"
        Me.lblNaveDesarrollo.Size = New System.Drawing.Size(76, 13)
        Me.lblNaveDesarrollo.TabIndex = 0
        Me.lblNaveDesarrollo.Text = "Nave Desarrollo"
        '
        'lblEstatusProductoCosto
        '
        Me.lblEstatusProductoCosto.Location = New System.Drawing.Point(345, 52)
        Me.lblEstatusProductoCosto.Name = "lblEstatusProductoCosto"
        Me.lblEstatusProductoCosto.Size = New System.Drawing.Size(84, 13)
        Me.lblEstatusProductoCosto.TabIndex = 4
        Me.lblEstatusProductoCosto.Text = "Estatus del Costo"
        '
        'lblMarca
        '
        Me.lblMarca.Location = New System.Drawing.Point(67, 52)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(29, 13)
        Me.lblMarca.TabIndex = 1
        Me.lblMarca.Text = "Marca"
        '
        'txtColeccion
        '
        Me.txtColeccion.EditValue = "SELECCIONE UNA COLECCIÓN"
        Me.txtColeccion.Enabled = False
        Me.txtColeccion.Location = New System.Drawing.Point(435, 18)
        Me.txtColeccion.Name = "txtColeccion"
        Me.txtColeccion.Properties.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtColeccion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtColeccion.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.txtColeccion.Properties.Appearance.Options.UseBackColor = True
        Me.txtColeccion.Properties.Appearance.Options.UseFont = True
        Me.txtColeccion.Properties.Appearance.Options.UseForeColor = True
        Me.txtColeccion.Size = New System.Drawing.Size(200, 20)
        Me.txtColeccion.TabIndex = 3
        '
        'slueComboColeccion
        '
        Me.slueComboColeccion.EditValue = ""
        Me.slueComboColeccion.Location = New System.Drawing.Point(435, 18)
        Me.slueComboColeccion.Name = "slueComboColeccion"
        Me.slueComboColeccion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, True, True, False, EditorButtonImageOptions4, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject13, SerializableAppearanceObject14, SerializableAppearanceObject15, SerializableAppearanceObject16, "Limpiar Filtro", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.slueComboColeccion.Properties.DisplayMember = "Coleccion"
        Me.slueComboColeccion.Properties.NullText = ""
        Me.slueComboColeccion.Properties.PopupSizeable = False
        Me.slueComboColeccion.Properties.PopupView = Me.grdvComboColeccion
        Me.slueComboColeccion.Properties.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repoMemoEdit})
        Me.slueComboColeccion.Properties.ValueMember = "codr_colaboradorid"
        Me.slueComboColeccion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.slueComboColeccion.Size = New System.Drawing.Size(234, 20)
        Me.slueComboColeccion.TabIndex = 152
        '
        'grdvComboColeccion
        '
        Me.grdvComboColeccion.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.cole_Sel, Me.cole_MarcaId, Me.cole_Marca, Me.cole_TemporadaId, Me.cole_Temporada, Me.cole_ColeccionId, Me.cole_Coleccion, Me.cole_Año, Me.cole_NaveDesarrollaId, Me.cole_NaveDesarrolla})
        Me.grdvComboColeccion.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grdvComboColeccion.Name = "grdvComboColeccion"
        Me.grdvComboColeccion.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.grdvComboColeccion.OptionsSelection.CheckBoxSelectorField = "Sel"
        Me.grdvComboColeccion.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grdvComboColeccion.OptionsSelection.MultiSelect = True
        Me.grdvComboColeccion.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.grdvComboColeccion.OptionsView.RowAutoHeight = True
        Me.grdvComboColeccion.OptionsView.ShowGroupPanel = False
        '
        'cole_Sel
        '
        Me.cole_Sel.Caption = "Sel"
        Me.cole_Sel.FieldName = "Sel"
        Me.cole_Sel.Name = "cole_Sel"
        '
        'cole_MarcaId
        '
        Me.cole_MarcaId.Caption = "MarcaId"
        Me.cole_MarcaId.FieldName = "MarcaId"
        Me.cole_MarcaId.Name = "cole_MarcaId"
        '
        'cole_Marca
        '
        Me.cole_Marca.Caption = "Marca"
        Me.cole_Marca.FieldName = "Marca"
        Me.cole_Marca.Name = "cole_Marca"
        Me.cole_Marca.Visible = True
        Me.cole_Marca.VisibleIndex = 1
        Me.cole_Marca.Width = 60
        '
        'cole_TemporadaId
        '
        Me.cole_TemporadaId.Caption = "TemporadaId"
        Me.cole_TemporadaId.FieldName = "TemporadaId"
        Me.cole_TemporadaId.Name = "cole_TemporadaId"
        '
        'cole_Temporada
        '
        Me.cole_Temporada.AppearanceCell.Options.UseTextOptions = True
        Me.cole_Temporada.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cole_Temporada.Caption = "Temporada"
        Me.cole_Temporada.ColumnEdit = Me.repoMemoEdit
        Me.cole_Temporada.FieldName = "Temporada"
        Me.cole_Temporada.Name = "cole_Temporada"
        Me.cole_Temporada.Visible = True
        Me.cole_Temporada.VisibleIndex = 2
        Me.cole_Temporada.Width = 100
        '
        'repoMemoEdit
        '
        Me.repoMemoEdit.Name = "repoMemoEdit"
        '
        'cole_ColeccionId
        '
        Me.cole_ColeccionId.Caption = "ColeccionId"
        Me.cole_ColeccionId.FieldName = "ColeccionId"
        Me.cole_ColeccionId.Name = "cole_ColeccionId"
        '
        'cole_Coleccion
        '
        Me.cole_Coleccion.AppearanceCell.Options.UseTextOptions = True
        Me.cole_Coleccion.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cole_Coleccion.Caption = "Coleccion"
        Me.cole_Coleccion.ColumnEdit = Me.repoMemoEdit
        Me.cole_Coleccion.FieldName = "Coleccion"
        Me.cole_Coleccion.Name = "cole_Coleccion"
        Me.cole_Coleccion.Visible = True
        Me.cole_Coleccion.VisibleIndex = 3
        Me.cole_Coleccion.Width = 100
        '
        'cole_Año
        '
        Me.cole_Año.Caption = "Año"
        Me.cole_Año.FieldName = "Año"
        Me.cole_Año.Name = "cole_Año"
        Me.cole_Año.Visible = True
        Me.cole_Año.VisibleIndex = 4
        Me.cole_Año.Width = 50
        '
        'cole_NaveDesarrollaId
        '
        Me.cole_NaveDesarrollaId.Caption = "NaveDesarrollaId"
        Me.cole_NaveDesarrollaId.FieldName = "NaveDesarrollaId"
        Me.cole_NaveDesarrollaId.Name = "cole_NaveDesarrollaId"
        '
        'cole_NaveDesarrolla
        '
        Me.cole_NaveDesarrolla.Caption = "NaveDesarrolla"
        Me.cole_NaveDesarrolla.FieldName = "NaveDesarrolla"
        Me.cole_NaveDesarrolla.Name = "cole_NaveDesarrolla"
        '
        'lblTemporada
        '
        Me.lblTemporada.Location = New System.Drawing.Point(42, 83)
        Me.lblTemporada.Name = "lblTemporada"
        Me.lblTemporada.Size = New System.Drawing.Size(54, 13)
        Me.lblTemporada.TabIndex = 2
        Me.lblTemporada.Text = "Temporada"
        '
        'lblColeccion
        '
        Me.lblColeccion.Location = New System.Drawing.Point(384, 21)
        Me.lblColeccion.Name = "lblColeccion"
        Me.lblColeccion.Size = New System.Drawing.Size(45, 13)
        Me.lblColeccion.TabIndex = 3
        Me.lblColeccion.Text = "Colección"
        '
        'slueComboTemporada
        '
        Me.slueComboTemporada.EditValue = ""
        Me.slueComboTemporada.Location = New System.Drawing.Point(102, 80)
        Me.slueComboTemporada.Name = "slueComboTemporada"
        Me.slueComboTemporada.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, True, True, False, EditorButtonImageOptions5, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject17, SerializableAppearanceObject18, SerializableAppearanceObject19, SerializableAppearanceObject20, "Limpiar Filtro", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.slueComboTemporada.Properties.DisplayMember = "Temporada"
        Me.slueComboTemporada.Properties.NullText = ""
        Me.slueComboTemporada.Properties.PopupSizeable = False
        Me.slueComboTemporada.Properties.PopupView = Me.grdvComboTemporada
        Me.slueComboTemporada.Properties.ValueMember = "codr_colaboradorid"
        Me.slueComboTemporada.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.slueComboTemporada.Size = New System.Drawing.Size(222, 20)
        Me.slueComboTemporada.TabIndex = 5
        '
        'grdvComboTemporada
        '
        Me.grdvComboTemporada.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.cSel_T, Me.cTemporadaId, Me.cTemporada, Me.cVigencia})
        Me.grdvComboTemporada.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grdvComboTemporada.Name = "grdvComboTemporada"
        Me.grdvComboTemporada.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.grdvComboTemporada.OptionsSelection.CheckBoxSelectorField = "Sel"
        Me.grdvComboTemporada.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grdvComboTemporada.OptionsSelection.MultiSelect = True
        Me.grdvComboTemporada.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.grdvComboTemporada.OptionsView.ShowGroupPanel = False
        '
        'cSel_T
        '
        Me.cSel_T.Caption = "Sel"
        Me.cSel_T.FieldName = "Sel"
        Me.cSel_T.Name = "cSel_T"
        '
        'cTemporadaId
        '
        Me.cTemporadaId.Caption = "TemporadaId"
        Me.cTemporadaId.FieldName = "temp_temporadaid"
        Me.cTemporadaId.Name = "cTemporadaId"
        '
        'cTemporada
        '
        Me.cTemporada.Caption = "Temporada"
        Me.cTemporada.FieldName = "temp_nombre"
        Me.cTemporada.Name = "cTemporada"
        Me.cTemporada.Visible = True
        Me.cTemporada.VisibleIndex = 1
        '
        'cVigencia
        '
        Me.cVigencia.Caption = "Vigencia"
        Me.cVigencia.FieldName = "temp_vigencia"
        Me.cVigencia.Name = "cVigencia"
        Me.cVigencia.Visible = True
        Me.cVigencia.VisibleIndex = 2
        '
        'pnlOcultar
        '
        Me.pnlOcultar.Appearance.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlOcultar.Appearance.Options.UseBackColor = True
        Me.pnlOcultar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlOcultar.Controls.Add(Me.pnlBotonesOcultar)
        Me.pnlOcultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOcultar.Location = New System.Drawing.Point(2, 67)
        Me.pnlOcultar.Name = "pnlOcultar"
        Me.pnlOcultar.Size = New System.Drawing.Size(1074, 24)
        Me.pnlOcultar.TabIndex = 3
        '
        'pnlBotonesOcultar
        '
        Me.pnlBotonesOcultar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBotonesOcultar.Controls.Add(Me.btnAbajo)
        Me.pnlBotonesOcultar.Controls.Add(Me.btnArriba)
        Me.pnlBotonesOcultar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonesOcultar.Location = New System.Drawing.Point(1009, 0)
        Me.pnlBotonesOcultar.Name = "pnlBotonesOcultar"
        Me.pnlBotonesOcultar.Size = New System.Drawing.Size(65, 24)
        Me.pnlBotonesOcultar.TabIndex = 2
        '
        'btnAbajo
        '
        Me.btnAbajo.ImageOptions.Image = CType(resources.GetObject("btnAbajo.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAbajo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.BottomCenter
        Me.btnAbajo.Location = New System.Drawing.Point(37, 2)
        Me.btnAbajo.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 1
        '
        'btnArriba
        '
        Me.btnArriba.ImageOptions.Image = CType(resources.GetObject("btnArriba.ImageOptions.Image"), System.Drawing.Image)
        Me.btnArriba.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.BottomCenter
        Me.btnArriba.Location = New System.Drawing.Point(10, 2)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 0
        '
        'pnlHeader
        '
        Me.pnlHeader.Appearance.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Appearance.Options.UseBackColor = True
        Me.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.pnlImagenYuyin)
        Me.pnlHeader.Controls.Add(Me.pnlOperaciones)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(2, 2)
        Me.pnlHeader.LookAndFeel.SkinMaskColor = System.Drawing.Color.White
        Me.pnlHeader.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.White
        Me.pnlHeader.LookAndFeel.SkinName = "DevExpress Style"
        Me.pnlHeader.LookAndFeel.UseDefaultLookAndFeel = False
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1074, 65)
        Me.pnlHeader.TabIndex = 2
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(680, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(329, 65)
        Me.pnlTitulo.TabIndex = 2
        '
        'lblTitulo
        '
        Me.lblTitulo.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Appearance.Options.UseFont = True
        Me.lblTitulo.Appearance.Options.UseForeColor = True
        Me.lblTitulo.Location = New System.Drawing.Point(11, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(303, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Administrador de Resumen de Costos"
        '
        'pnlImagenYuyin
        '
        Me.pnlImagenYuyin.Controls.Add(Me.pbYuyin)
        Me.pnlImagenYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlImagenYuyin.Location = New System.Drawing.Point(1009, 0)
        Me.pnlImagenYuyin.Name = "pnlImagenYuyin"
        Me.pnlImagenYuyin.Size = New System.Drawing.Size(65, 65)
        Me.pnlImagenYuyin.TabIndex = 1
        '
        'pbYuyin
        '
        Me.pbYuyin.BackColor = System.Drawing.Color.White
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(2, 2)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(61, 61)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 47
        Me.pbYuyin.TabStop = False
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlOperaciones.Controls.Add(Me.pnlGenerarFormatoExcel)
        Me.pnlOperaciones.Controls.Add(Me.pnlGenerarFormatoPDF)
        Me.pnlOperaciones.Controls.Add(Me.pnlRechazarSKU)
        Me.pnlOperaciones.Controls.Add(Me.pnlLiberarSKU)
        Me.pnlOperaciones.Controls.Add(Me.pnlAutorizarPrecioSKU)
        Me.pnlOperaciones.Controls.Add(Me.pnlModificarPrecioSKU)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOperaciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(537, 65)
        Me.pnlOperaciones.TabIndex = 0
        '
        'pnlGenerarFormatoExcel
        '
        Me.pnlGenerarFormatoExcel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlGenerarFormatoExcel.Controls.Add(Me.lblGenerarFormatoExcel)
        Me.pnlGenerarFormatoExcel.Controls.Add(Me.btnGenerarFormatoExcel)
        Me.pnlGenerarFormatoExcel.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarFormatoExcel.Location = New System.Drawing.Point(330, 0)
        Me.pnlGenerarFormatoExcel.Name = "pnlGenerarFormatoExcel"
        Me.pnlGenerarFormatoExcel.Size = New System.Drawing.Size(75, 65)
        Me.pnlGenerarFormatoExcel.TabIndex = 6
        '
        'lblGenerarFormatoExcel
        '
        Me.lblGenerarFormatoExcel.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGenerarFormatoExcel.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarFormatoExcel.Appearance.Options.UseFont = True
        Me.lblGenerarFormatoExcel.Appearance.Options.UseForeColor = True
        Me.lblGenerarFormatoExcel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.lblGenerarFormatoExcel.Location = New System.Drawing.Point(4, 37)
        Me.lblGenerarFormatoExcel.Name = "lblGenerarFormatoExcel"
        Me.lblGenerarFormatoExcel.Size = New System.Drawing.Size(67, 26)
        Me.lblGenerarFormatoExcel.TabIndex = 1
        Me.lblGenerarFormatoExcel.Text = "    Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Formato Excel"
        '
        'btnGenerarFormatoExcel
        '
        Me.btnGenerarFormatoExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnGenerarFormatoExcel.ImageOptions.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnGenerarFormatoExcel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnGenerarFormatoExcel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnGenerarFormatoExcel.Location = New System.Drawing.Point(22, 5)
        Me.btnGenerarFormatoExcel.Margin = New System.Windows.Forms.Padding(0)
        Me.btnGenerarFormatoExcel.Name = "btnGenerarFormatoExcel"
        Me.btnGenerarFormatoExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarFormatoExcel.TabIndex = 0
        Me.btnGenerarFormatoExcel.ToolTip = "GENERA LOS FORMATOS EN EXCEL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PARA LA AUTORIZACIÓN DE LOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MODELOS Y/O COLECCIONE" &
    "S" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SELECCIONADAS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlGenerarFormatoPDF
        '
        Me.pnlGenerarFormatoPDF.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlGenerarFormatoPDF.Controls.Add(Me.lblGenerarFormatoPDF)
        Me.pnlGenerarFormatoPDF.Controls.Add(Me.btnGenerarFormatoPDF)
        Me.pnlGenerarFormatoPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerarFormatoPDF.Location = New System.Drawing.Point(260, 0)
        Me.pnlGenerarFormatoPDF.Name = "pnlGenerarFormatoPDF"
        Me.pnlGenerarFormatoPDF.Size = New System.Drawing.Size(70, 65)
        Me.pnlGenerarFormatoPDF.TabIndex = 5
        '
        'lblGenerarFormatoPDF
        '
        Me.lblGenerarFormatoPDF.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGenerarFormatoPDF.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarFormatoPDF.Appearance.Options.UseFont = True
        Me.lblGenerarFormatoPDF.Appearance.Options.UseForeColor = True
        Me.lblGenerarFormatoPDF.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.lblGenerarFormatoPDF.Location = New System.Drawing.Point(4, 37)
        Me.lblGenerarFormatoPDF.Name = "lblGenerarFormatoPDF"
        Me.lblGenerarFormatoPDF.Size = New System.Drawing.Size(62, 26)
        Me.lblGenerarFormatoPDF.TabIndex = 1
        Me.lblGenerarFormatoPDF.Text = "    Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Formato PDF"
        '
        'pnlRechazarSKU
        '
        Me.pnlRechazarSKU.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlRechazarSKU.Controls.Add(Me.lblRechazarSKU)
        Me.pnlRechazarSKU.Controls.Add(Me.btnRechazarSKU)
        Me.pnlRechazarSKU.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRechazarSKU.Location = New System.Drawing.Point(195, 0)
        Me.pnlRechazarSKU.Name = "pnlRechazarSKU"
        Me.pnlRechazarSKU.Size = New System.Drawing.Size(65, 65)
        Me.pnlRechazarSKU.TabIndex = 4
        '
        'lblRechazarSKU
        '
        Me.lblRechazarSKU.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblRechazarSKU.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazarSKU.Appearance.Options.UseFont = True
        Me.lblRechazarSKU.Appearance.Options.UseForeColor = True
        Me.lblRechazarSKU.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.lblRechazarSKU.Location = New System.Drawing.Point(9, 37)
        Me.lblRechazarSKU.Name = "lblRechazarSKU"
        Me.lblRechazarSKU.Size = New System.Drawing.Size(46, 13)
        Me.lblRechazarSKU.TabIndex = 1
        Me.lblRechazarSKU.Text = "Rechazar"
        '
        'btnRechazarSKU
        '
        Me.btnRechazarSKU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRechazarSKU.ImageOptions.Image = CType(resources.GetObject("btnRechazarSKU.ImageOptions.Image"), System.Drawing.Image)
        Me.btnRechazarSKU.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnRechazarSKU.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnRechazarSKU.Location = New System.Drawing.Point(17, 5)
        Me.btnRechazarSKU.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRechazarSKU.Name = "btnRechazarSKU"
        Me.btnRechazarSKU.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazarSKU.TabIndex = 0
        Me.btnRechazarSKU.ToolTip = "RECHAZA LOS MODELOS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PARA SU MODIFICACIÓN."
        '
        'pnlLiberarSKU
        '
        Me.pnlLiberarSKU.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlLiberarSKU.Controls.Add(Me.lblLiberarSKU)
        Me.pnlLiberarSKU.Controls.Add(Me.btnLiberarSKU)
        Me.pnlLiberarSKU.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLiberarSKU.Location = New System.Drawing.Point(130, 0)
        Me.pnlLiberarSKU.Name = "pnlLiberarSKU"
        Me.pnlLiberarSKU.Size = New System.Drawing.Size(65, 65)
        Me.pnlLiberarSKU.TabIndex = 3
        '
        'lblLiberarSKU
        '
        Me.lblLiberarSKU.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblLiberarSKU.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLiberarSKU.Appearance.Options.UseFont = True
        Me.lblLiberarSKU.Appearance.Options.UseForeColor = True
        Me.lblLiberarSKU.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.lblLiberarSKU.Location = New System.Drawing.Point(16, 37)
        Me.lblLiberarSKU.Name = "lblLiberarSKU"
        Me.lblLiberarSKU.Size = New System.Drawing.Size(32, 13)
        Me.lblLiberarSKU.TabIndex = 1
        Me.lblLiberarSKU.Text = "Liberar"
        '
        'btnLiberarSKU
        '
        Me.btnLiberarSKU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnLiberarSKU.ImageOptions.Image = Global.Produccion.Vista.My.Resources.Resources.pares_aceptar_32
        Me.btnLiberarSKU.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnLiberarSKU.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnLiberarSKU.Location = New System.Drawing.Point(17, 5)
        Me.btnLiberarSKU.Margin = New System.Windows.Forms.Padding(0)
        Me.btnLiberarSKU.Name = "btnLiberarSKU"
        Me.btnLiberarSKU.Size = New System.Drawing.Size(32, 32)
        Me.btnLiberarSKU.TabIndex = 0
        Me.btnLiberarSKU.ToolTip = "DA EL VISTO BUENO POR PARTE DE DC" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A LOS MODELOS SELECCIONADOS."
        '
        'pnlAutorizarPrecioSKU
        '
        Me.pnlAutorizarPrecioSKU.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlAutorizarPrecioSKU.Controls.Add(Me.lblAutorizarPrecioSKU)
        Me.pnlAutorizarPrecioSKU.Controls.Add(Me.btnAutorizarPrecioSKU)
        Me.pnlAutorizarPrecioSKU.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizarPrecioSKU.Location = New System.Drawing.Point(65, 0)
        Me.pnlAutorizarPrecioSKU.Name = "pnlAutorizarPrecioSKU"
        Me.pnlAutorizarPrecioSKU.Size = New System.Drawing.Size(65, 65)
        Me.pnlAutorizarPrecioSKU.TabIndex = 2
        '
        'lblAutorizarPrecioSKU
        '
        Me.lblAutorizarPrecioSKU.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAutorizarPrecioSKU.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizarPrecioSKU.Appearance.Options.UseFont = True
        Me.lblAutorizarPrecioSKU.Appearance.Options.UseForeColor = True
        Me.lblAutorizarPrecioSKU.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.lblAutorizarPrecioSKU.Location = New System.Drawing.Point(12, 37)
        Me.lblAutorizarPrecioSKU.Name = "lblAutorizarPrecioSKU"
        Me.lblAutorizarPrecioSKU.Size = New System.Drawing.Size(41, 26)
        Me.lblAutorizarPrecioSKU.TabIndex = 1
        Me.lblAutorizarPrecioSKU.Text = "Autorizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Precio"
        '
        'btnAutorizarPrecioSKU
        '
        Me.btnAutorizarPrecioSKU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAutorizarPrecioSKU.ImageOptions.Image = Global.Produccion.Vista.My.Resources.Resources.pares_autorizar_32
        Me.btnAutorizarPrecioSKU.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnAutorizarPrecioSKU.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnAutorizarPrecioSKU.Location = New System.Drawing.Point(17, 5)
        Me.btnAutorizarPrecioSKU.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAutorizarPrecioSKU.Name = "btnAutorizarPrecioSKU"
        Me.btnAutorizarPrecioSKU.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizarPrecioSKU.TabIndex = 0
        Me.btnAutorizarPrecioSKU.ToolTip = "AUTORIZA EL PRECIO DE VENTA ASIGNADO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AL MODELO."
        '
        'pnlModificarPrecioSKU
        '
        Me.pnlModificarPrecioSKU.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlModificarPrecioSKU.Controls.Add(Me.lblModificarPrecioSKU)
        Me.pnlModificarPrecioSKU.Controls.Add(Me.btnModificarPrecioSKU)
        Me.pnlModificarPrecioSKU.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlModificarPrecioSKU.Location = New System.Drawing.Point(0, 0)
        Me.pnlModificarPrecioSKU.Name = "pnlModificarPrecioSKU"
        Me.pnlModificarPrecioSKU.Size = New System.Drawing.Size(65, 65)
        Me.pnlModificarPrecioSKU.TabIndex = 0
        '
        'lblModificarPrecioSKU
        '
        Me.lblModificarPrecioSKU.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblModificarPrecioSKU.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblModificarPrecioSKU.Appearance.Options.UseFont = True
        Me.lblModificarPrecioSKU.Appearance.Options.UseForeColor = True
        Me.lblModificarPrecioSKU.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.BottomCenter
        Me.lblModificarPrecioSKU.Location = New System.Drawing.Point(10, 37)
        Me.lblModificarPrecioSKU.Name = "lblModificarPrecioSKU"
        Me.lblModificarPrecioSKU.Size = New System.Drawing.Size(43, 26)
        Me.lblModificarPrecioSKU.TabIndex = 1
        Me.lblModificarPrecioSKU.Text = "Modificar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Precio"
        '
        'btnModificarPrecioSKU
        '
        Me.btnModificarPrecioSKU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnModificarPrecioSKU.ImageOptions.Image = Global.Produccion.Vista.My.Resources.Resources.pares_modificar_32
        Me.btnModificarPrecioSKU.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnModificarPrecioSKU.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnModificarPrecioSKU.Location = New System.Drawing.Point(17, 5)
        Me.btnModificarPrecioSKU.Margin = New System.Windows.Forms.Padding(0)
        Me.btnModificarPrecioSKU.Name = "btnModificarPrecioSKU"
        Me.btnModificarPrecioSKU.Size = New System.Drawing.Size(32, 32)
        Me.btnModificarPrecioSKU.TabIndex = 0
        Me.btnModificarPrecioSKU.ToolTip = "PERMITE LA EDICIÓN DEL PRECIO DE VENTA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DE UN MODELO."
        '
        'PopupTipoReporte_Excel
        '
        Me.PopupTipoReporte_Excel.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barbtnFormatoGeneral_Excel), New DevExpress.XtraBars.LinkPersistInfo(Me.barbtnFormatoClienteEspecial_Excel)})
        Me.PopupTipoReporte_Excel.Manager = Me.BarManagerTipoReporte
        Me.PopupTipoReporte_Excel.Name = "PopupTipoReporte_Excel"
        '
        'PopupActualizacionMasiva
        '
        Me.PopupActualizacionMasiva.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.barbtnAplicarValoresMasivos)})
        Me.PopupActualizacionMasiva.Manager = Me.BarManagerTipoReporte
        Me.PopupActualizacionMasiva.Name = "PopupActualizacionMasiva"
        '
        'cNaveGrupo
        '
        Me.cNaveGrupo.Caption = "Grupo"
        Me.cNaveGrupo.FieldName = "nave_grupo"
        Me.cNaveGrupo.Name = "cNaveGrupo"
        Me.cNaveGrupo.Visible = True
        Me.cNaveGrupo.VisibleIndex = 2
        '
        'AdministradorResumenCostosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 688)
        Me.Controls.Add(Me.pnlFondoForm)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "AdministradorResumenCostosForm"
        Me.Text = "AdministradorResumenCostosForm"
        CType(Me.pnlFondoForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFondoForm.ResumeLayout(False)
        CType(Me.pnlTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTabla.ResumeLayout(False)
        CType(Me.tabCtrlResumenCostos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCtrlResumenCostos.ResumeLayout(False)
        Me.tabPageIndicadores.ResumeLayout(False)
        CType(Me.pnlTabPageIndicadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTabPageIndicadores.ResumeLayout(False)
        CType(DoughnutSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(DoughnutSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.charIndicadoresPorNave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageResumenCostos.ResumeLayout(False)
        CType(Me.pnlTabPageTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTabPageTabla.ResumeLayout(False)
        CType(Me.grdAdminResumenCostos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVAdminResumenCostos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageResumenCostosEspeciales.ResumeLayout(False)
        CType(Me.grdAdminResumenCostosEspeciales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVAdminResumenCostosEspeciales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        CType(Me.chkSimplificarInformacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlTotalRegistros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotalRegistros.ResumeLayout(False)
        CType(Me.pnlMostrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMostrar.ResumeLayout(False)
        Me.pnlMostrar.PerformLayout()
        CType(Me.pnlCerrar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        CType(Me.pnlParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        CType(Me.pnlVigenciaEspecial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVigenciaEspecial.ResumeLayout(False)
        Me.pnlVigenciaEspecial.PerformLayout()
        CType(Me.dtpVigenciaEspecial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpVigenciaEspecial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManagerTipoReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repoTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupTipoReporte_PDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.txtTemporada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNaveDesarrollo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.separador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMostrarImagenes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slueComboNaveDesarrollo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdvComboNaveDesarrollo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstatusProductoCosto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lookUpMarca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slueComboEstatusProductoCosto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVComboEstatusProductoCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColeccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slueComboColeccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdvComboColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repoMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slueComboTemporada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdvComboTemporada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlOcultar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOcultar.ResumeLayout(False)
        CType(Me.pnlBotonesOcultar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonesOcultar.ResumeLayout(False)
        CType(Me.pnlHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        CType(Me.pnlTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pnlImagenYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlImagenYuyin.ResumeLayout(False)
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOperaciones.ResumeLayout(False)
        CType(Me.pnlGenerarFormatoExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenerarFormatoExcel.ResumeLayout(False)
        Me.pnlGenerarFormatoExcel.PerformLayout()
        CType(Me.pnlGenerarFormatoPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGenerarFormatoPDF.ResumeLayout(False)
        Me.pnlGenerarFormatoPDF.PerformLayout()
        CType(Me.pnlRechazarSKU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRechazarSKU.ResumeLayout(False)
        Me.pnlRechazarSKU.PerformLayout()
        CType(Me.pnlLiberarSKU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLiberarSKU.ResumeLayout(False)
        Me.pnlLiberarSKU.PerformLayout()
        CType(Me.pnlAutorizarPrecioSKU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAutorizarPrecioSKU.ResumeLayout(False)
        Me.pnlAutorizarPrecioSKU.PerformLayout()
        CType(Me.pnlModificarPrecioSKU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlModificarPrecioSKU.ResumeLayout(False)
        Me.pnlModificarPrecioSKU.PerformLayout()
        CType(Me.PopupTipoReporte_Excel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupActualizacionMasiva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlFondoForm As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlHeader As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlTitulo As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlImagenYuyin As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents pnlOperaciones As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlAutorizarPrecioSKU As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblModificarPrecioSKU As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnModificarPrecioSKU As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlModificarPrecioSKU As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblAutorizarPrecioSKU As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAutorizarPrecioSKU As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlOcultar As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlBotonesOcultar As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnAbajo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnArriba As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlParametros As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtNaveDesarrollo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtColeccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents slueComboColeccion As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents grdvComboColeccion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents slueComboTemporada As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents grdvComboTemporada As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cSel_T As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cTemporadaId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cTemporada As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblColeccion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTemporada As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNaveDesarrollo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents slueComboNaveDesarrollo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents grdvComboNaveDesarrollo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cSel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cNaveDesarrolloId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cNaveDesarrollo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pnlFooter As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlTotalRegistros As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblRegistros As Windows.Forms.Label
    Friend WithEvents lblTotalRegistros As Windows.Forms.Label
    Friend WithEvents pnlMostrar As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblMostrar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnMostrar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlCerrar As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblCerrar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCerrar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlTabla As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtEstatusProductoCosto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents slueComboEstatusProductoCosto As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents grdVComboEstatusProductoCosto As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cSel_E As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cEstatusId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cEstatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblEstatusProductoCosto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlLiberarSKU As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblLiberarSKU As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnLiberarSKU As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlRechazarSKU As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblRechazarSKU As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRechazarSKU As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabCtrlResumenCostos As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabPageIndicadores As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabPageResumenCostos As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents pnlTabPageTabla As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlTabPageIndicadores As DevExpress.XtraEditors.PanelControl
    Friend WithEvents grdAdminResumenCostos As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVAdminResumenCostos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents c_Sel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_Foto As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_FotoModelo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_Marca As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_FamiliaProyeccion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_ColeccionId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_Coleccion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_ModeloSAY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_ModeloSICY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_Piel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_Color As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_Corrida As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_ProductoEstiloId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_EstatusProductoId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_NaveDesarrolloId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_NaveDesarrollo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_TemporadaId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_Temporada As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_CostoMaterialDirecto As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_CostoOverhead As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_Clasificacion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_CostoFabricacion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_UtilidadPorcentaje As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_UtilidadPesos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_PrecioVentaComercializadora As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_EstatusProductoCostoId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_EstatusProductoCosto As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_UsuarioSolicita As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_FechaSolicitud As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_UsuarioAutoriza As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_FechaAutoriza As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_UsuarioRechaza As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_FechaRechazo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_UsuarioLibera As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_FechaLibero As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents c_EstatusProducto As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents pnlGenerarFormatoPDF As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblGenerarFormatoPDF As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGenerarFormatoPDF As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlGenerarFormatoExcel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblGenerarFormatoExcel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGenerarFormatoExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cVigencia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkMostrarImagenes As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents c_Observaciones As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents separador As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents tabPageResumenCostosEspeciales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grdAdminResumenCostosEspeciales As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVAdminResumenCostosEspeciales As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents ce_Sel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Foto As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_FotoModelo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Marca As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_FamiliaProyeccion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_ColeccionId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Coleccion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_ModeloSAY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_ModeloSICY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Piel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Color As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Talla As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_ProductoEstiloId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_EstatusProductoId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_NaveDesarrolloId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_NaveDesarrollo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_TemporadaId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Temporada As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_CostoMaterialDirecto As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_CostoOverhead As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_CostoFabricacion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Clasificacion As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_UtilidadPorcentaje As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_UtilidadPesos As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_PrecioVentaComercializadora As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_UsuarioSolicita As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_FechaSolicita As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_UsuarioAutoriza As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_FechaAutoriza As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_UsuarioRechaza As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_FechaRechaza As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_UsuarioLibera As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_FechaLibera As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_EstatusProducto As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_EstatusProductoCosto As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_EstatusProductoCostoId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ce_Observaciones As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents txtMarca As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lookUpMarca As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Sel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MarcaId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MarcaNombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EsLicencias As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblMarca As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cole_Sel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_MarcaId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_Marca As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_TemporadaId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_Temporada As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_ColeccionId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_Coleccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_Año As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_NaveDesarrollaId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cole_NaveDesarrolla As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repoMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ce_Cliente As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents chkSimplificarInformacion As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents bandColecciones As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandCostos As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandDetallados As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandUtilidad As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandFinal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandUsuariosCambios As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandEstatusProductoCosto As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandColeccionesEspeciales As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandEstatusProductoCostoEspecial As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandUsuariosEspeciales As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents bandEstatusEspeciales As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents PopupTipoReporte_PDF As DevExpress.XtraBars.PopupMenu
    Friend WithEvents barbtnFormatoGeneral_PDF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barbtnFormatoClienteEspecial_PDF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManagerTipoReporte As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barbtnFormatoClienteEspecial_Excel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barbtnFormatoGeneral_Excel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupTipoReporte_Excel As DevExpress.XtraBars.PopupMenu
    Friend WithEvents PopupActualizacionMasiva As DevExpress.XtraBars.PopupMenu
    Friend WithEvents barbtnAplicarValoresMasivos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bartxtValorMasivo As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents repoTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtTemporada As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlVigenciaEspecial As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblVigencia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dtpVigenciaEspecial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblInformativo_Especial As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblInformativo_General As DevExpress.XtraEditors.LabelControl
    Friend WithEvents charIndicadoresPorNave As DevExpress.XtraCharts.ChartControl
    Friend WithEvents cNaveGrupo As DevExpress.XtraGrid.Columns.GridColumn
End Class
