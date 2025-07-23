Imports System.ComponentModel
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class DevolucionCliente_GenerarParesAGranel_Form
    Public objDev As New Entidades.DevolucionCliente
    Public objPermisos As New Entidades.DevolucionCliente_PermisosPantallas
    Dim ObjBU As New Negocios.DevolucionCliente_IntegracionInventarioBU
    Dim dtDocenasNormales As DataTable
    Dim dtDocenasEspeciales As DataTable
    Dim DtDetalleTallasArticulo As New DataTable
    Dim DtConsultaParesTallasFolio As New DataTable
    Dim ListaAtadosDocenasNormales As New List(Of Entidades.Atado)
    Dim ListaAtadosDocenasEspeciales As New List(Of Entidades.Atado)
    Dim SeGeneraronAtados As Boolean = False
    Dim ListaAtadosEspeciales As New List(Of Entidades.InfoAtadosEspeciales)
    Dim dtListadoAtados As New DataTable
    Dim dtListaPares As New DataTable

    Private Sub DevolucionCliente_GenerarParesAGranel_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPermisos = (New Negocios.DevolucionClientesBU).ValidaPermisosPantallas(0, "CONSULTA_DETALLES", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)


        If Not IsDBNull(objDev.Devolucionclienteid) And objDev.Devolucionclienteid.ToString <> "0" Then
            lblFolioDev.Text = objDev.Devolucionclienteid
            lblCliente.Text = objDev.NombreCliente
            lblCantidad.Text = objDev.Cantidadtotal
            lblUnidad.Text = objDev.Unidad
            lblDestinoProducto.Text = objDev.Destinoproducto

            CargarArticulos()

            CrearDataTableDocenasNormales(objDev.Devolucionclienteid)
            CrearDataTableDocenasEspeciales(objDev.Devolucionclienteid)
            ObtenerParesPorTallaFolio(objDev.Devolucionclienteid)

            splitDoceneo.Visible = False
            spltDetallesArticulo.Panel2.Visible = False
            spltDetallesArticulo.Panel1.MaximumSize = MaximumSize
            spltDetallesArticulo.Panel2Collapsed = True

        End If

        If SeGeneraronAtados = False Then
            rdoAtados.Visible = False
            rdoCodigosPar.Visible = False
        Else
            rdoAtados.Visible = True
            rdoCodigosPar.Visible = True
        End If

        If objDev.LoteGenerado = True Then
            pnlBtnCalcularDocNormales.Visible = False
            rdoAtados.Visible = True
            rdoCodigosPar.Visible = True
            grpFiltros.Visible = True
            cmbNave.Visible = True
            btnGenerarLotes.Visible = False
            lblGenerarLotes.Visible = False
            chkSeleccionar.Visible = False
            lblTextoRegistrosSeleccionados.Text = "Registros"
            lblNave.Visible = True
            grpFiltros.Visible = True
            lblTextoMostrar.Visible = True
            rdoArticuloa.Visible = True
            btnSustituir.Visible = False
            lblSustituir.Visible = False
            chkSeleccionarCDN.Visible = False
            pnlSustiruirArticulo.Visible = False
        Else
            chkSeleccionar.Visible = True
            grpFiltros.Visible = False
            cmbNave.Visible = False
            btnGenerarLotes.Visible = True
            lblGenerarLotes.Visible = True
            lblNave.Visible = False
            grpFiltros.Visible = False
            lblTextoMostrar.Visible = False
            rdoArticuloa.Visible = False
            pnlSustiruirArticulo.Visible = True
        End If

        CargarNaves()
        ObtenerMontosYPares()
    End Sub

    Public Sub CargarArticulos()
        DtDetalleTallasArticulo = ObjBU.ConsultaDetallesDevolucion(objDev.Devolucionclienteid, "")

        grdParesaGranel.DataSource = Nothing
        bgvParesaGranel.Columns.Clear()
        grdParesaGranel.DataSource = DtDetalleTallasArticulo

        bgvParesaGranel.IndicatorWidth = 30
        lblNumFiltrados.Text = CDbl(DtDetalleTallasArticulo.Rows.Count).ToString("N0")

        If objDev.LoteGenerado = True Then
            DiseñoGrid.DiseñoBaseGrid(bgvParesaGranel)
            bgvParesaGranel.OptionsView.ColumnAutoWidth = False
            bgvParesaGranel.Columns.ColumnByFieldName("Seleccion").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("AtTotal").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("CDN").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("DoCN").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("AtN").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("PrDN").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("AtE").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("PrdE").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("GAE").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("IdDetalle").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("PrecioCapturadoCobranza").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("IdMotivo").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("LecturaCodigos").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("Motivo").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ClasificacionId").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("Clasificacion").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ListaPrecio").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ActivoModelo").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ActivoArticulo").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("Docto").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ProductoEstiloID").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("TallaId").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ParesRestantes").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("TallaSICYID").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("DEvolucionDetalleId").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("DevolucionCliente").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ProductoEStiloId_ppt").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("Precio").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("Total").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("PielColor").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("FolioDev").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ModeloSAY").Caption = "Modelo SAY"
            bgvParesaGranel.Columns.ColumnByFieldName("ModeloSICY").Caption = "Modelo SICY"
            bgvParesaGranel.Columns.ColumnByFieldName("StatusArticulo").Caption = "Status Articulo"
            bgvParesaGranel.Columns.ColumnByFieldName("ProductoEstiloID_Original").Visible = False

        Else
            DiseñoGridDevoluciones()
            bgvParesaGranel.OptionsView.ColumnAutoWidth = False
            bgvParesaGranel.Columns.ColumnByFieldName("FolioDev").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("FolioSICYId").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("TallaSICYID").Visible = False
            bgvParesaGranel.Columns.ColumnByFieldName("ProductoEstiloID_Original").Visible = False

        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvParesaGranel.Columns

            bgvParesaGranel.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

            If IsNumeric(col.FieldName) = True Or col.FieldName.Contains("½") = True Then

                If IsNothing(bgvParesaGranel.Columns(col.FieldName).Summary.FirstOrDefault(Function(x) x.FieldName = col.FieldName)) = True Then
                    bgvParesaGranel.Columns(col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = col.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:N0}"
                    bgvParesaGranel.GroupSummary.Add(item)

                Else

                    bgvParesaGranel.Columns(col.FieldName).Summary.Remove(bgvParesaGranel.Columns(col.FieldName).Summary.FirstOrDefault(Function(x) x.FieldName = col.FieldName))
                    bgvParesaGranel.Columns(col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = col.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:N0}"
                    bgvParesaGranel.GroupSummary.Add(item)
                End If
            ElseIf col.FieldName = "Total Pares" Or col.FieldName = "Cantidad" Then
                bgvParesaGranel.Columns(col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                item.FieldName = col.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:N0}"
                bgvParesaGranel.GroupSummary.Add(item)
            End If



            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next





    End Sub


    Public Sub CargarNaves()
        Dim dtNaves As New DataTable
        dtNaves.Columns.Add("NaveSICYId", GetType(Integer))
        dtNaves.Columns.Add("Nave", GetType(String))

        dtNaves.Rows.Add(4, "DESCONTINUADOS")

        cmbNave.DataSource = dtNaves
        cmbNave.ValueMember = "NaveSICYId"
        cmbNave.DisplayMember = "Nave"


    End Sub
    Public Sub DiseñoGridDevoluciones()
        bgvParesaGranel.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvParesaGranel.Columns
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            End If
        Next

        If objPermisos.VerMontos = False Then
            bgvParesaGranel.Columns.ColumnByFieldName("Total").Visible = False
        End If

        bgvParesaGranel.Columns.ColumnByFieldName("Seleccion").OptionsColumn.AllowEdit = True
        bgvParesaGranel.Columns.ColumnByFieldName("Seleccion").Caption = " "
        bgvParesaGranel.Columns.ColumnByFieldName("IdDetalle").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("IdMotivo").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("ClasificacionId").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("DEvolucionDetalleId").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("ProductoEStiloId_ppt").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("DevolucionCliente").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("Clasificacion").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("StatusArticulo").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("ActivoArticulo").Visible = False

        'bgvParesaGranel.Columns.ColumnByFieldName("IdMotivoDev").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("Motivo").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("LecturaCodigos").Visible = False
        'bgvParesaGranel.Columns.ColumnByFieldName("StatusArtículo").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("ListaPrecio").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("ActivoModelo").Visible = False
        'bgvParesaGranel.Columns.ColumnByFieldName("ActivoArtículo").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("Docto").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("TallaId").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("ProductoEstiloID").Visible = False
        'bgvParesaGranel.Columns.ColumnByFieldName("* Clasificación").Visible = False

        bgvParesaGranel.Columns.ColumnByFieldName("Precio").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("Total").Visible = False
        bgvParesaGranel.Columns.ColumnByFieldName("PrecioCapturadoCobranza").Visible = False


        bgvParesaGranel.Columns.ColumnByFieldName("GAE").OptionsColumn.AllowEdit = True
        bgvParesaGranel.Columns.ColumnByFieldName("CDN").OptionsColumn.AllowEdit = True

        'bgvParesaGranel.Columns.ColumnByFieldName("GAE").Visible = False

        bgvParesaGranel.IndicatorWidth = 40
        bgvParesaGranel.BestFitColumns()


        '--------------
        Dim btnGAE As New RepositoryItemButtonEdit
        Dim size As New Size

        btnGAE.Name = "BtnGAE"
        btnGAE.Buttons(0).Image = Global.Almacen.Vista.My.Resources.Resources.mostrarMas
        size.Height = btnGAE.Buttons(0).Image.Size.Height
        size.Width = btnGAE.Buttons(0).Image.Size.Width
        btnGAE.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        btnGAE.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        btnGAE.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph

        AddHandler btnGAE.Click, AddressOf txt_Click

        grdParesaGranel.RepositoryItems.Add(btnGAE)

        bgvParesaGranel.Columns("GAE").ColumnEdit = btnGAE
        bgvParesaGranel.Columns("GAE").ColumnEdit.Name = "BTNGAE2"


    End Sub

    Public Sub txt_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Form As New DevolucionCliente_GenerarParesAGranel_AtadosEspeciales_Form
        Dim RowsHandle = bgvParesaGranel.FocusedRowHandle
        Dim FolioSeleccionado As Integer = 0
        Dim FolioDetalleID As Integer = 0
        Dim TallaId As Integer = 0
        Dim entTallasArticulo As Entidades.TallasDevoluciones
        Dim ListaTallasArticulo As New List(Of Entidades.TallasDevoluciones)
        Dim CantidadPares As Integer = 0
        Dim dtListaAtadosEspeciales As New DataTable
        Dim ParesRestantes As Integer = 0
        Dim ParesAtadosNormales As Integer = 0
        Dim InfoAtados As New Entidades.InfoAtadosEspeciales
        Dim dtTallas As New DataTable

        Try
            FolioSeleccionado = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(RowsHandle), "FolioDev"))
            FolioDetalleID = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(RowsHandle), "IdDetalle"))
            TallaId = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(RowsHandle), "TallaId"))
            CantidadPares = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(RowsHandle), "Cantidad"))
            ParesRestantes = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(RowsHandle), "ParesRestantes"))
            If IsNumeric(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(RowsHandle), "PrDN")) = True Then
                ParesAtadosNormales = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(RowsHandle), "PrDN"))
            Else
                ParesAtadosNormales = 0
            End If

            dtTallas = ObjBU.ConsultaTallasCorridas(TallaId)
            GenerarFilaDocenasEspeciales(FolioDetalleID)

            ' Dim row As System.Data.DataRow = bgvParesaGranel.GetDataRow(RowsHandle)                
            Dim Row As System.Data.DataRow = dtDocenasEspeciales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FolioDetalleID).FirstOrDefault()
            Dim dtFila As DataTable = Row.Table
            Dim Valor As String = String.Empty
            Dim NombreColumna As String = String.Empty

            For Each Calce As DataRow In dtTallas.Rows

                NombreColumna = Calce.Item("Talla")
                Valor = Row(NombreColumna).ToString()
                If Valor <> String.Empty Then
                    entTallasArticulo = New Entidades.TallasDevoluciones
                    entTallasArticulo.Talla = NombreColumna
                    entTallasArticulo.Cantidad = Valor
                    ListaTallasArticulo.Add(entTallasArticulo)
                Else
                    'If dtTallasArticulo.Columns.Contains(NombreColumna) = True Then
                    '    dtTallasArticulo.Rows(0).Item(NombreColumna) = ""
                    'End If

                End If

            Next


            'Form.dtTallasArticulo = dtTallasArticulo
            Form.ListaTallas = ListaTallasArticulo
            Form.FolioDevolucionId = FolioSeleccionado
            Form.FolioDevolucionDetalleId = FolioDetalleID
            Form.IdTalla = TallaId
            Form.TotalPares = CantidadPares
            Form.ParesAtadosNormales = ParesAtadosNormales

            If ListaAtadosEspeciales.Where(Function(x) x.FolioDetalle = FolioDetalleID).Count > 0 Then
                Form.EsEdicion = True
                Form.InfoAtados = ListaAtadosEspeciales.Where(Function(x) x.FolioDetalle = FolioDetalleID).FirstOrDefault()
                Form.dtListadoAtadosEspeciales = ListaAtadosEspeciales.Where(Function(x) x.FolioDetalle = FolioDetalleID).FirstOrDefault().DtListadoAtadosEspeciales.Copy()
            Else
                Form.EsEdicion = False
            End If


            If Form.ShowDialog() = DialogResult.OK Then
                dtListaAtadosEspeciales = Form.dtListadoAtadosEspeciales
                InfoAtados = Form.InfoAtados

                If ListaAtadosEspeciales.Where(Function(x) x.FolioDetalle = FolioDetalleID).Count > 0 Then

                    ListaAtadosEspeciales.RemoveAll(Function(x) x.FolioDetalle = FolioDetalleID)

                End If

                ListaAtadosEspeciales.Add(InfoAtados)

                Dim RowDetalle = DtDetalleTallasArticulo.AsEnumerable().Where(Function(x) x.Item("IdDetalle") = FolioDetalleID).FirstOrDefault()
                RowDetalle.Item("AtE") = InfoAtados.NumeroAtados.ToString
                RowDetalle.Item("PrdE") = InfoAtados.NumeroPares.ToString()

                RowDetalle.Item("ParesRestantes") = "0"

                If IsNumeric(RowDetalle.Item("AtTotal")) = True Then
                    RowDetalle.Item("AtTotal") = (CInt(RowDetalle.Item("AtTotal")) + InfoAtados.NumeroAtados).ToString()
                End If

            Else




            End If


            ObtenerMontosYPares()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ObtenerParesPorTallaFolio(ByVal FolioDevolucionId As Integer)
        DtConsultaParesTallasFolio = ObjBU.ConsultaParesTallasFolio(FolioDevolucionId)
    End Sub

    Private Sub CrearDataTableDocenasNormales(ByVal FolioDevolucionID As Integer)
        Dim Talla As String = String.Empty
        Dim CantidadPares As Integer = 0
        Dim dtTallas As New DataTable

        dtTallas = ObjBU.ConsultaTallasFolio(FolioDevolucionID)

        dtDocenasNormales = New DataTable
        dtDocenasNormales.Columns.Add("FolioDetalleID", GetType(Integer))
        dtDocenasNormales.Columns.Add("FolioDev", GetType(String))
        dtDocenasNormales.Columns.Add("Marca", GetType(String))
        dtDocenasNormales.Columns.Add("Colección", GetType(String))
        dtDocenasNormales.Columns.Add("Temporada", GetType(String))
        dtDocenasNormales.Columns.Add("ModeloSAY", GetType(String))
        dtDocenasNormales.Columns.Add("ModeloSICY", GetType(String))
        dtDocenasNormales.Columns.Add("Piel", GetType(String))
        dtDocenasNormales.Columns.Add("Color", GetType(String))
        dtDocenasNormales.Columns.Add("Corrida", GetType(String))

        dtDocenasNormales.Columns.Add("DoCN", GetType(String))
        dtDocenasNormales.Columns.Add("AtN", GetType(String))
        dtDocenasNormales.Columns.Add("PrDN", GetType(String))
        dtDocenasNormales.Columns.Add("AtE", GetType(String))
        dtDocenasNormales.Columns.Add("PrDE", GetType(String))
        dtDocenasNormales.Columns.Add("GAE", GetType(String))

        For Each Fila As DataRow In dtTallas.Rows
            dtDocenasNormales.Columns.Add(Fila.Item(0).ToString(), GetType(String))
        Next

    End Sub

    Public Sub CrearDataTableDocenasEspeciales(ByVal FolioDevolucionId As Integer)

        Dim Talla As String = String.Empty
        Dim CantidadPares As Integer = 0
        Dim dtTallas As New DataTable

        dtTallas = ObjBU.ConsultaTallasFolio(FolioDevolucionId)

        dtDocenasEspeciales = New DataTable
        dtDocenasEspeciales.Columns.Add("FolioDetalleID", GetType(Integer))
        dtDocenasEspeciales.Columns.Add("FolioDev", GetType(String))
        dtDocenasEspeciales.Columns.Add("Marca", GetType(String))
        dtDocenasEspeciales.Columns.Add("Colección", GetType(String))
        dtDocenasEspeciales.Columns.Add("Temporada", GetType(String))
        dtDocenasEspeciales.Columns.Add("ModeloSAY", GetType(String))
        dtDocenasEspeciales.Columns.Add("ModeloSICY", GetType(String))
        dtDocenasEspeciales.Columns.Add("Piel", GetType(String))
        dtDocenasEspeciales.Columns.Add("Color", GetType(String))
        dtDocenasEspeciales.Columns.Add("Corrida", GetType(String))

        dtDocenasEspeciales.Columns.Add("DoCN", GetType(String))
        dtDocenasEspeciales.Columns.Add("AtN", GetType(String))
        dtDocenasEspeciales.Columns.Add("PrDN", GetType(String))
        dtDocenasEspeciales.Columns.Add("AtE", GetType(String))
        dtDocenasEspeciales.Columns.Add("PrDE", GetType(String))
        dtDocenasEspeciales.Columns.Add("GAE", GetType(String))

        For Each Fila As DataRow In dtTallas.Rows
            dtDocenasEspeciales.Columns.Add(Fila.Item(0).ToString(), GetType(String))
        Next

    End Sub


    Public Function ExisteFilasSeleccionadas_CalculoDocenasNormales() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim CalcularDocenas As Boolean
        Dim FilasSeleccionadas As Integer = 0

        NumeroFilas = bgvParesaGranel.DataRowCount - 1

        For index As Integer = 0 To NumeroFilas Step 1
            CalcularDocenas = CBool(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "CDN"))
            If CalcularDocenas = True Then
                FilasSeleccionadas += 1
            End If
        Next

        If FilasSeleccionadas > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub CalcularDocenasNormales()
        Dim NumeroFilas As Integer = 0
        Dim FoliodetalleId As String = String.Empty
        Dim TallaID As Integer = 0
        Dim CalcularDocenas As Boolean
        Dim DtDoceneoNormal As New DataTable
        Dim Talla As String = String.Empty
        Dim Docena1 As String = String.Empty
        Dim Docena2 As String = String.Empty
        Dim ParesDocenas As Integer = 0
        Dim FolioDetalleId_Completo As Integer = 0
        Dim ListaAtadosDocenasNormalesAuxiliar As New List(Of Entidades.Atado)
        Dim ListaAtadosDocenasEspecialesAuxiliar As New List(Of Entidades.Atado)
        Dim ListaParesRestantes As New List(Of Entidades.Atado)
        Dim AtadoRestante As Entidades.Atado
        Dim TallasRestantes As New Entidades.TallasDevoluciones
        Dim NumeroAtadosNormales As Integer = 0
        Dim NumeroDocenasNormales As Integer = 0
        Dim NumeroParesNormales As Integer = 0


        ListaAtadosDocenasNormales.Clear()
        'dtDocenasNormales.Clear()
        'dtDocenasEspeciales.Clear()


        Try

            Cursor = Cursors.WaitCursor

            NumeroFilas = bgvParesaGranel.DataRowCount - 1
            For index As Integer = 0 To NumeroFilas Step 1
                NumeroAtadosNormales = 0
                NumeroDocenasNormales = 0
                NumeroParesNormales = 0


                FoliodetalleId = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "IdDetalle"))
                TallaID = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "TallaId"))
                CalcularDocenas = CBool(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "CDN"))
                ListaAtadosDocenasNormalesAuxiliar.Clear()
                ListaAtadosDocenasEspecialesAuxiliar.Clear()
                ListaParesRestantes.Clear()

                If CalcularDocenas = True Then
                    DtDoceneoNormal = ObjBU.ConsultaDocenaNormal(TallaID)

                    If dtDocenasNormales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FoliodetalleId).Count > 0 Then
                        Dim FilaEliminar = dtDocenasNormales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FoliodetalleId).FirstOrDefault
                        dtDocenasNormales.Rows.Remove(FilaEliminar)
                    End If

                    If dtDocenasEspeciales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FoliodetalleId).Count > 0 Then
                        Dim FilaEliminar = dtDocenasEspeciales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FoliodetalleId).FirstOrDefault
                        dtDocenasEspeciales.Rows.Remove(FilaEliminar)
                    End If


                    'Tallas del detalle del folio de devolucion
                    Dim TallasDetalle = DtConsultaParesTallasFolio.AsEnumerable().Where(Function(x) x.Item("DevolucionDetalleID") = FoliodetalleId).CopyToDataTable
                    Dim EsDocenaCompleta As Boolean = True
                    Dim Atado1 As New Entidades.Atado
                    Dim Atado2 As New Entidades.Atado
                    Dim AtadoTotal As New Entidades.Atado
                    Dim TallasDevoluciones1 As New Entidades.TallasDevoluciones
                    Dim TallasDevoluciones2 As New Entidades.TallasDevoluciones
                    Dim TallasDevolucionesTotales As New Entidades.TallasDevoluciones

                    While (EsDocenaCompleta = True)

                        Atado1 = New Entidades.Atado
                        Atado2 = New Entidades.Atado
                        AtadoTotal = New Entidades.Atado

                        For Each Fila As DataRow In DtDoceneoNormal.Rows

                            Talla = Fila.Item("Talla").ToString
                            Docena1 = Fila.Item("Media1").ToString
                            Docena2 = Fila.Item("Media2").ToString
                            ParesDocenas = CInt(Docena2) + CInt(Docena1)

                            If ParesDocenas > 0 Then
                                TallasDevoluciones1 = New Entidades.TallasDevoluciones
                                TallasDevoluciones2 = New Entidades.TallasDevoluciones
                                TallasDevolucionesTotales = New Entidades.TallasDevoluciones

                                TallasDevoluciones1.Talla = Talla
                                TallasDevoluciones2.Talla = Talla

                                TallasDevoluciones1.Cantidad = Docena1
                                TallasDevoluciones2.Cantidad = Docena2

                                Atado1.Atado.Add(TallasDevoluciones1)
                                Atado2.Atado.Add(TallasDevoluciones2)

                                TallasDevolucionesTotales.Talla = Talla
                                TallasDevolucionesTotales.Cantidad = ParesDocenas
                                AtadoTotal.Atado.Add(TallasDevolucionesTotales)

                                If TallasDetalle.AsEnumerable().Sum(Function(x) x.Item("ParesTalla")) >= ParesDocenas Then

                                    If TallasDetalle.AsEnumerable().Where(Function(x) x.Item("Talla") = Talla And x.Item("ParesTalla") >= ParesDocenas).Count > 0 Then

                                    Else
                                        EsDocenaCompleta = False
                                    End If

                                Else
                                    EsDocenaCompleta = False
                                End If
                            End If

                        Next

                        If EsDocenaCompleta = True Then
                            ListaAtadosDocenasNormales.Add(Atado1)
                            ListaAtadosDocenasNormales.Add(Atado2)
                            FolioDetalleId_Completo = FoliodetalleId

                            ListaAtadosDocenasNormalesAuxiliar.Add(Atado1)
                            ListaAtadosDocenasNormalesAuxiliar.Add(Atado2)

                            NumeroAtadosNormales += 2
                            NumeroDocenasNormales += 1

                            For Each Fila As Entidades.TallasDevoluciones In AtadoTotal.Atado
                                Dim filaDetalle = TallasDetalle.AsEnumerable().Where(Function(x) x.Item("Talla") = Fila.Talla).FirstOrDefault()
                                filaDetalle.Item("ParesTalla") = filaDetalle.Item("ParesTalla") - Fila.Cantidad
                                NumeroParesNormales += Fila.Cantidad
                            Next

                        Else

                            Dim ListaPares = TallasDetalle.AsEnumerable().Where(Function(x) x.Item("ParesTalla") > 0)

                            For Each Fila_ParesRestantes As DataRow In ListaPares
                                AtadoRestante = New Entidades.Atado
                                TallasRestantes = New Entidades.TallasDevoluciones

                                TallasRestantes.Talla = Fila_ParesRestantes.Item("Talla")
                                TallasRestantes.Cantidad = Fila_ParesRestantes.Item("ParesTalla")
                                AtadoRestante.Atado.Add(TallasRestantes)
                                ListaParesRestantes.Add(AtadoRestante)
                            Next



                            FolioDetalleId_Completo = FoliodetalleId
                        End If

                    End While

                    If ListaAtadosDocenasNormalesAuxiliar.Count > 0 Then
                        GenerarInformacionDocenasNormales(ListaAtadosDocenasNormalesAuxiliar, FolioDetalleId_Completo)
                    End If

                    If ListaParesRestantes.Count > 0 Then
                        GenerarInformacionDocenasEspeciales(ListaParesRestantes, FolioDetalleId_Completo)
                    End If

                Else
                    DtDoceneoNormal = ObjBU.ConsultaDocenaNormal(TallaID)

                    Dim TallasDetalle = DtConsultaParesTallasFolio.AsEnumerable().Where(Function(x) x.Item("DevolucionDetalleID") = FoliodetalleId).CopyToDataTable

                    Dim ListaPares = TallasDetalle.AsEnumerable().Where(Function(x) x.Item("ParesTalla") > 0)

                    For Each Fila_ParesRestantes As DataRow In ListaPares
                        AtadoRestante = New Entidades.Atado
                        TallasRestantes = New Entidades.TallasDevoluciones

                        TallasRestantes.Talla = Fila_ParesRestantes.Item("Talla")
                        TallasRestantes.Cantidad = Fila_ParesRestantes.Item("ParesTalla")
                        AtadoRestante.Atado.Add(TallasRestantes)
                        ListaParesRestantes.Add(AtadoRestante)
                    Next

                    'Si existe REgistro de doceneo especial eliminar
                    FolioDetalleId_Completo = FoliodetalleId

                    If dtDocenasNormales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FoliodetalleId).Count > 0 Then
                        Dim FilaEliminar = dtDocenasNormales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FoliodetalleId).FirstOrDefault
                        dtDocenasNormales.Rows.Remove(FilaEliminar)
                    End If

                    'GenerarInformacionDocenasEspeciales(ListaParesRestantes, FolioDetalleId_Completo)

                End If



                '----------------------------------
                Dim row = DtDetalleTallasArticulo.AsEnumerable().Where(Function(x) x.Item("IdDetalle") = FolioDetalleId_Completo).FirstOrDefault()

                If IsNothing(row) = False Then
                    row.Item("AtN") = NumeroAtadosNormales.ToString
                    row.Item("PrDN") = NumeroParesNormales.ToString
                    row.Item("DoCN") = NumeroDocenasNormales.ToString
                    Dim CantidadPares As Integer = 0
                    Dim ParesDocenasEspeciales As Integer = 0

                    If IsNumeric(row.Item("PrdE")) = True Then
                        ParesDocenasEspeciales = row.Item("PrdE")
                    End If

                    CantidadPares = row.Item("Cantidad")
                    row.Item("ParesRestantes") = CantidadPares - NumeroParesNormales - ParesDocenasEspeciales
                    'row.Item("PrdE") = CantidadPares - NumeroParesNormales
                    If (CantidadPares - NumeroParesNormales) = 0 Then
                        row.Item("AtE") = 0
                    End If

                    row.Item("AtTotal") = NumeroAtadosNormales.ToString() + row.Item("AtE")

                    If row.Item("Cantidad") = row.Item("PrDN") Then
                        'bgvParesaGranel.Columns("GAE")

                        'row.Item("")
                        'GAE
                    End If
                End If
            Next

            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Cursor = Cursors.Default
        End Try


    End Sub

    Public Sub GenerarFilaDocenasEspeciales(ByVal FolioDetalleId As Integer)
        Dim RowDetalle As DataRow
        Dim FolioDevolucionId As Integer
        Dim Marca As String
        Dim Coleccion As String
        Dim temporada As String
        Dim ModeloSAY As String
        Dim ModeloSICY As String
        Dim Piel As String
        Dim Color As String
        Dim Corrida As String
        Dim DtTallas As DataTable
        Dim TallaID As Integer = 0

        If dtDocenasEspeciales.AsEnumerable.Where(Function(x) x.Item("FolioDetalleID") = FolioDetalleId).Count() = 0 Then
            RowDetalle = DtDetalleTallasArticulo.AsEnumerable().Where(Function(x) x.Item("IdDetalle") = FolioDetalleId).FirstOrDefault()

            FolioDevolucionId = RowDetalle.Item("FolioDev")
            Marca = RowDetalle.Item("Marca")
            Coleccion = RowDetalle.Item("Coleccion")
            temporada = RowDetalle.Item("Temporada")
            ModeloSAY = RowDetalle.Item("ModeloSAY")
            ModeloSICY = RowDetalle.Item("ModeloSICY")
            Piel = RowDetalle.Item("Piel")
            Color = RowDetalle.Item("Color")
            Corrida = RowDetalle.Item("Corrida")
            TallaID = RowDetalle.Item("TallaID")

            DtTallas = ObjBU.ConsultaTallasCorridas(TallaID)
            dtDocenasEspeciales.Rows.Add(FolioDetalleId, FolioDevolucionId, Marca, Coleccion, temporada, ModeloSAY, ModeloSICY, Piel, Color, Corrida, "", "", "", "", "", "")

            Dim FilaArticulo = dtDocenasEspeciales.AsEnumerable.Where(Function(x) x.Item("FolioDetalleID") = FolioDetalleId).FirstOrDefault()
            Dim Fila = DtDetalleTallasArticulo.AsEnumerable.Where(Function(x) x.Item("IdDetalle") = FolioDetalleId).FirstOrDefault

            For Each FilaTalla As DataRow In DtTallas.Rows
                FilaArticulo.Item(FilaTalla.Item(1)) = RowDetalle.Item(FilaTalla.Item(1))
            Next

        End If


    End Sub
    Public Sub GenerarInformacionDocenasEspeciales(ByVal ListaAtados As List(Of Entidades.Atado), ByVal FolioDetalleId As Integer)
        Dim Row As DataRow
        Dim RowDetalle As DataRow
        Dim FolioDevolucionId As Integer
        Dim Marca As String
        Dim Coleccion As String
        Dim temporada As String
        Dim ModeloSAY As String
        Dim ModeloSICY As String
        Dim Piel As String
        Dim Color As String
        Dim Corrida As String

        RowDetalle = DtDetalleTallasArticulo.AsEnumerable().Where(Function(x) x.Item("IdDetalle") = FolioDetalleId).FirstOrDefault()

        FolioDevolucionId = RowDetalle.Item("FolioDev")
        Marca = RowDetalle.Item("Marca")
        Coleccion = RowDetalle.Item("Coleccion")
        temporada = RowDetalle.Item("Temporada")
        ModeloSAY = RowDetalle.Item("ModeloSAY")
        ModeloSICY = RowDetalle.Item("ModeloSICY")
        Piel = RowDetalle.Item("Piel")
        Color = RowDetalle.Item("Color")
        Corrida = RowDetalle.Item("Corrida")

        dtDocenasEspeciales.Rows.Add(FolioDetalleId, FolioDevolucionId, Marca, Coleccion, temporada, ModeloSAY, ModeloSICY, Piel, Color, Corrida, "", "", "", "", "", "")
        Row = dtDocenasEspeciales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FolioDetalleId).FirstOrDefault()

        For Each Fila As Entidades.Atado In ListaAtados

            For Each Atado As Entidades.TallasDevoluciones In Fila.Atado

                If IsDBNull(Row.Item(Atado.Talla)) = True Then
                    Row.Item(Atado.Talla) = Atado.Cantidad.ToString
                Else
                    Row.Item(Atado.Talla) = (CInt(Row.Item(Atado.Talla)) + Atado.Cantidad).ToString()
                End If
            Next

        Next

        grdDocenasEspeciales.DataSource = dtDocenasEspeciales
        viewDocenasEspeciales.OptionsView.ColumnAutoWidth = False

        viewDocenasEspeciales.BestFitColumns()
    End Sub

    Public Sub GenerarInformacionDocenasNormales(ByVal ListaAtados As List(Of Entidades.Atado), ByVal FolioDetalleId As Integer)
        Dim Row As DataRow
        Dim RowDetalle As DataRow
        Dim FolioDevolucionId As Integer
        Dim Marca As String
        Dim Coleccion As String
        Dim temporada As String
        Dim ModeloSAY As String
        Dim ModeloSICY As String
        Dim Piel As String
        Dim Color As String
        Dim Corrida As String


        RowDetalle = DtDetalleTallasArticulo.AsEnumerable().Where(Function(x) x.Item("IdDetalle") = FolioDetalleId).FirstOrDefault()

        FolioDevolucionId = RowDetalle.Item("FolioDev")
        Marca = RowDetalle.Item("Marca")
        Coleccion = RowDetalle.Item("Coleccion")
        temporada = RowDetalle.Item("Temporada")
        ModeloSAY = RowDetalle.Item("ModeloSAY")
        ModeloSICY = RowDetalle.Item("ModeloSICY")
        Piel = RowDetalle.Item("Piel")
        Color = RowDetalle.Item("Color")
        Corrida = RowDetalle.Item("Corrida")

        dtDocenasNormales.Rows.Add(FolioDetalleId, FolioDevolucionId, Marca, Coleccion, temporada, ModeloSAY, ModeloSICY, Piel, Color, Corrida, "", "", "", "", "", "")
        Row = dtDocenasNormales.AsEnumerable().Where(Function(x) x.Item("FolioDetalleID") = FolioDetalleId).FirstOrDefault()

        For Each Fila As Entidades.Atado In ListaAtados

            For Each Atado As Entidades.TallasDevoluciones In Fila.Atado

                If IsDBNull(Row.Item(Atado.Talla)) = True Then
                    Row.Item(Atado.Talla) = Atado.Cantidad.ToString
                Else
                    Row.Item(Atado.Talla) = (CInt(Row.Item(Atado.Talla)) + Atado.Cantidad).ToString()
                End If
            Next

        Next

        grdDoceneoNormal.DataSource = dtDocenasNormales
        viewDocenasNormales.OptionsView.ColumnAutoWidth = False

        viewDocenasNormales.BestFitColumns()


    End Sub

    Private Sub btnCalcularDocNormales_Click(sender As Object, e As EventArgs) Handles btnCalcularDocNormales.Click
        If ExisteFilasSeleccionadas_CalculoDocenasNormales() = True Then
            CalcularDocenasNormales()
            bgvParesaGranel.Columns.ColumnByFieldName("GAE").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("Lote").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("AñoLote").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("AtTotal").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("DoCN").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("AtN").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("PrDN").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("AtE").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("PrdE").Visible = True
            bgvParesaGranel.Columns.ColumnByFieldName("ParesRestantes").Visible = True

            btnCalcularDocNormales.Enabled = False
            lblCalcularDocNormales.Enabled = False
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se han seleccionado las filas.")
        End If

        ObtenerMontosYPares()

    End Sub

    Private Sub bgvParesaGranel_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvParesaGranel.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)

        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "ParesRestantes" Then
                If e.CellValue > 0 Then
                    e.Appearance.BackColor = Color.Pink
                    e.Appearance.ForeColor = Color.Red
                End If
            End If

            If e.Column.FieldName = "AtTotal" Then
                If IsNumeric(e.CellValue) = True Then
                    If e.CellValue > 0 Then
                        e.Appearance.BackColor = Color.LightGreen
                        e.Appearance.ForeColor = Color.Black
                    End If
                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            'show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnGenerarLotes.Click

        Try

            Cursor = Cursors.WaitCursor

            If ValidarExistenAtadosPendientes() = True Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Hay pares pendientes por asignar atado.")
            Else
                IngresarParesAGranel()
                ObjBU.ActualizaFolioLotesGenerados(objDev.Devolucionclienteid, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                btnGenerarLotes.Enabled = False
                lblGenerarLotes.Enabled = False
                SeGeneraronAtados = True
                objDev.LoteGenerado = True
                DevolucionCliente_GenerarParesAGranel_Form_Load(Nothing, Nothing)
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Function ValidarExistenAtadosPendientes() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim ParesPendientesAsignarAtado As Integer = 0
        Dim ExistenParesPendientes As Boolean = False

        NumeroFilas = bgvParesaGranel.DataRowCount - 1
        For index As Integer = 0 To NumeroFilas Step 1

            If IsDBNull(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "ParesRestantes")) = False Then
                ParesPendientesAsignarAtado = CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "ParesRestantes"))
            Else
                ParesPendientesAsignarAtado = 0
            End If


            If ParesPendientesAsignarAtado > 0 Then
                ExistenParesPendientes = True
            End If

        Next
        Return ExistenParesPendientes
    End Function

    Private Function IngresarParesAGranel() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim CodigoSICY As String = String.Empty
        Dim TallaSICYID As String = String.Empty
        Dim InfoLoteGranel As New Entidades.LoteGranel
        Dim PielColor As String = String.Empty
        Dim AtN As Integer = 0
        Dim AtE As Integer = 0
        Dim DoCN As Integer = 0
        Dim FolioDetalleid As Integer = 0
        Dim TallaId As Integer = 0
        Dim Resultado As Boolean = False
        Dim MarcaSAY As String = String.Empty
        Dim FolioDevolucionId As Integer = 0
        Dim FolioSICYID As Integer = 0
        Dim ProductoEstiloOriginal As Integer = 0
        Dim ProductoEstiloID As Integer = 0

        Try

            NumeroFilas = bgvParesaGranel.DataRowCount - 1
            For index As Integer = 0 To NumeroFilas Step 1
                CodigoSICY = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "CodigoSICY"))
                TallaSICYID = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "TallaSICYID"))
                PielColor = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "PielColor"))

                If IsNumeric(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "AtN")) = True Then
                    AtN = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "AtN"))
                Else
                    AtN = 0
                End If

                If IsNumeric(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "DoCN")) = True Then
                    DoCN = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "DoCN"))
                Else
                    DoCN = 0
                End If

                If IsNumeric(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "AtE")) = True Then
                    AtE = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "AtE"))
                Else
                    AtE = 0
                End If


                FolioDetalleid = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "IdDetalle"))
                TallaId = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "TallaId"))
                MarcaSAY = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "ModeloSAY"))
                FolioDevolucionId = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "FolioDev"))
                FolioSICYID = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "FolioSICYId"))
                ProductoEstiloOriginal = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "ProductoEstiloID_Original"))
                ProductoEstiloID = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "ProductoEstiloID"))


                InfoLoteGranel = GenerarLote(CodigoSICY, TallaSICYID)
                InfoLoteGranel.CodigoSICY = CodigoSICY
                InfoLoteGranel.TallaSICYID = TallaSICYID
                ObjBU.InsertarLoteGranel(InfoLoteGranel.Lote, PielColor, CodigoSICY, TallaSICYID)


                If DoCN > 0 Then
                    ObjBU.ReingresosGranelInsertaDocenasNormales(FolioDevolucionId, FolioSICYID, DoCN, 4, InfoLoteGranel.Lote, TallaSICYID, CodigoSICY, InfoLoteGranel.NoDocena, ProductoEstiloOriginal, ProductoEstiloID)
                    InfoLoteGranel.NoDocena = InfoLoteGranel.NoDocena + (DoCN * 2)
                End If

                If AtE > 0 Then
                    IngresarDocenasEspeciales(FolioDevolucionId, objDev.Devolucionsicyid, FolioDetalleid, TallaId, TallaSICYID, InfoLoteGranel, ProductoEstiloOriginal, ProductoEstiloID)
                End If

                bgvParesaGranel.SetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "Lote", InfoLoteGranel.Lote.ToString)
                bgvParesaGranel.SetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "AñoLote", InfoLoteGranel.Año.ToString)

                ObjBU.GuardarLoteGranelFolioDetalle(FolioDetalleid, InfoLoteGranel.Lote, InfoLoteGranel.Año)


            Next

            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha guardado correctamente los lotes.")

            Resultado = True
        Catch ex As Exception
            Resultado = False
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

        Return Resultado

    End Function

    Private Function GenerarLote(ByVal CodigoSICY As String, ByVal TallaSICY As String) As Entidades.LoteGranel

        Return ObjBU.BuscarLoteDocena(CodigoSICY, TallaSICY)

    End Function


    Private Function IngresarDocenasEspeciales(ByVal FolioDevolucionId As Integer, ByVal FolioDevolucionSICYId As Integer, ByVal FolioDetalleId As Integer, ByVal TallaID As Integer, ByVal TallaSICYID As String, ByVal LoteGranel As Entidades.LoteGranel, ByVal ProductoEstiloOriginal As Integer, ByVal ProductoEstilo As Integer) As Boolean

        Dim DocenaEspecial = ListaAtadosEspeciales.Where(Function(x) x.FolioDetalle = FolioDetalleId).FirstOrDefault
        Dim DtTallas As DataTable
        Dim Valor As String = String.Empty
        Dim i As Integer = 0
        Dim TotalPares As Integer = 0
        Dim ParesXAtado As Integer = 0
        Dim tmpCad As String = String.Empty
        Dim mAtadosParr As Object
        Dim mAtadosarr As Object
        Dim strCod As String
        Dim lsSQL As String = String.Empty
        Dim cont As Integer
        Dim j As Integer = 0
        Dim strTalla As String
        Dim strCodPar As String
        Dim NoDocena As Integer = 0

        DtTallas = ObjBU.ConsultaTallasCorridas(TallaID)
        NoDocena = LoteGranel.NoDocena

        For Each Fila As DataRow In DocenaEspecial.DtListadoAtadosEspeciales.Rows
            i = 0
            tmpCad = String.Empty
            Dim arr(19) As Integer
            strCod = ""
            lsSQL = ""

            For Each Talla As DataRow In DtTallas.Rows


                If IsDBNull(Fila.Item(Talla.Item("Talla"))) = True OrElse String.IsNullOrEmpty(Fila.Item(Talla.Item("Talla"))) = True Then
                    Valor = 0
                Else
                    Valor = Fila.Item(Talla.Item("Talla"))
                End If

                arr(i) = CInt(IIf(Valor = "", 0, Valor))
                i += 1
            Next

            TotalPares = Fila.Item("Total")
            ParesXAtado = TotalPares
            'Dim valor1 As Integer = CInt(IIf(TotalPares = "", 0, TotalPares))
            'Dim valor2 As Integer = CInt(IIf(ParesXAtado = "", 0, ParesXAtado))

            tmpCad = mAtados(0, 0, 0, TotalPares, ParesXAtado, arr)

            If tmpCad <> vbNullString Then
                'Asigna el arreglo de cadenas separado por "/" resultante de la funcion de mAtados a la variable matadosarr
                mAtadosarr = Split(tmpCad, "/")

                '------------------------------------------------------------------------

                For noatad = LBound(mAtadosarr) To UBound(mAtadosarr) - 1

                    mAtadosParr = Split(mAtadosarr(noatad), ",")

                    'Insertar Docena
                    strCod = "4" & LoteGranel.Lote.ToString() & CStr(NoDocena) & (Mid((Year(Date.Now)), 3, 2)) & CInt(mAtadosParr(UBound(mAtadosParr)))

                    lsSQL = lsSQL & "INSERT INTO LotesDocenas (IdDocena, Nave, Lote, Año, No_Docena, No_Pares, Tipo, Fecha, Saldo, IdAlmacen, PedidoSICY, IdPartida, IdLote, IdtblCancelacion, Empaque, StAtado) " &
                            "VALUES ('" & strCod & "'," & "4" & "," & LoteGranel.Lote.ToString() & "," & CInt(Year(Date.Now)) & "," & (NoDocena) & "," & CInt(mAtadosParr(UBound(mAtadosParr))) & ",'G',GetDate(), 0, 1, 0,0,0,0,'A','A')" & vbCrLf
                    cont = 1

                    For j = 1 To ObjBU.BuscarFinTallas(TallaSICYID)
                        'Insertar Pares
                        For i = 1 To CInt(mAtadosParr(j))
                            strTalla = ObjBU.BuscarTalla(j, TallaSICYID)
                            strCodPar = "4" & LoteGranel.Lote.ToString() & CStr(NoDocena) & (Mid((Year(Date.Now)), 3, 2)) & cont

                            lsSQL = lsSQL & "INSERT INTO tmpDocenasPares (Id_Docena, Id_Par, Calce, Pares, Status, IdtblNave, IdtblLote, IdtblAño, IdtblPrograma, IdtblAlmacen, IdtblPedido, IdtblPartida, IdtblTienda, IdtblOrdApartado, IdtblPartidaOrdApa, IdtblProducto, IdtblTalla, Idtblcte, TipoNumeracion, IdtblCancelacion, Disponible, Asignado, Calidad, Bloqueado, Transito, Reservado, Devolucion, IdtblMovimiento, Reproceso,iddevolucionSay,iddevolucionSicy,ProductoEstiloID_Original, ProductoEstiloID) " &
                                            "VALUES ('" & strCod & "','" & strCodPar & "','" & strTalla & "',1,0," & "4" & "," & LoteGranel.Lote.ToString() & "," & CInt(Year(Date.Now)) & ",0,1,0,0,0,0,0,'" & LoteGranel.CodigoSICY & "','" & LoteGranel.TallaSICYID.ToString() & "',0,'G',0,0,0,0,0,0,0,0,0,0," & FolioDevolucionId.ToString() & ", " & FolioDevolucionSICYId.ToString() & ", " & ProductoEstiloOriginal.ToString & ", " & ProductoEstilo.ToString() & " )" & vbCrLf
                            cont = cont + 1
                        Next i

                    Next j

                Next noatad

                '                    txtDocenaGranel2 = txtDocenaGranel + (noatad - 1)
                ObjBU.EjecutaConsulta(False, lsSQL)
                'Resultado = True
            Else
                MsgBox("Imposible generar atados " & vbCrLf & vbCrLf & "Avise a Sistemas", vbCritical, "Error")

            End If

            NoDocena = NoDocena + 1

        Next



        Return True
    End Function


    Private Function mAtados(IdPedido As Long, IdPartida As Long, IdLote As Integer, pRs As Integer, TamAtado As Integer, ParamArray arr() As Integer) As String
        Dim Max As Integer       ' Mantiene el maximo de elementos del arreglo
        Dim NumAtados As Integer ' Numero Maximo de Atados
        Dim x, Y As Integer      ' Cordenadas

        Dim Saldo As Integer    ' mantiene el saldo
        Dim pasada As Long
        Dim bandera As Boolean
        Dim Residuo As Single
        Dim Residuo2 As Integer ' Residuo en Pares
        Dim ultimo As Integer
        Dim s As String        ' Contiene la cadena de distribucion por atado
        Dim mSQL As String     ' Contiene el arreglo de cadenas que retornara el sistema
        Dim sumprs As Integer     ' Contiene el total de los pares por atado


        Try
            Max = UBound(arr) + 1

            Residuo = Format((pRs / TamAtado) - Fix(pRs / TamAtado), "##0.00")

            ultimo = 1
            If Residuo > 0 Then
                NumAtados = Fix(pRs / TamAtado) + 1
                If Residuo <= 0.5 Then ultimo = 2
            Else
                NumAtados = Fix(pRs / TamAtado)
            End If

            Dim Atados(NumAtados, Max) As Integer

            'residuo en pares
            Residuo2 = pRs - Fix(pRs / TamAtado) * TamAtado

            'Inicializa variables
            Saldo = pRs
            pasada = -1
            bandera = True
            mSQL = ""

            ' Inicia la distribucion de pares por atado
            While Saldo > 0 And (Saldo > Residuo2 Or Residuo > 0.5)

                pasada = pasada + 1

                If pasada Mod 2 > 0 Then
                    bandera = False
                Else
                    bandera = True
                End If

                For Y = 0 To NumAtados - ultimo

                    If bandera Then
                        x = 0
                        bandera = False
                    Else
                        x = 1
                        bandera = True
                    End If

                    For x = x To Max - 1 Step 2
                        If arr(x) > 0 And Atados(Y, Max) < TamAtado Then
                            If Y < (NumAtados - 1) Then
                                Atados(Y, x) = Atados(Y, x) + 1
                                Atados(Y, Max) = Atados(Y, Max) + 1
                                arr(x) = arr(x) - 1
                                Saldo = Saldo - 1
                            Else
                                If Atados(Y, Max) < Residuo2 Or Residuo2 = 0 Then
                                    Atados(Y, x) = Atados(Y, x) + 1
                                    Atados(Y, Max) = Atados(Y, Max) + 1
                                    arr(x) = arr(x) - 1
                                    Saldo = Saldo - 1
                                End If
                            End If
                        End If
                    Next x

                Next Y

            End While

            If Residuo > 0 And Residuo <= 0.5 Then
                Y = NumAtados - 1
                For x = 0 To Max - 1
                    If arr(x) > 0 And Atados(Y, Max) < TamAtado Then

                        Atados(Y, x) = Atados(Y, x) + arr(x)
                        Atados(Y, Max) = Atados(Y, Max) + arr(x)
                        arr(x) = arr(x) - arr(x)
                        Saldo = Saldo - arr(x)

                    End If
                Next x
            End If

            ' Inicia generacion de arreglo de atados con la distribucion generada separada por "/"
            For Y = 0 To NumAtados - 1
                'c = 0
                sumprs = 0
                s = ""
                For x = 0 To Max - 1
                    sumprs = sumprs + Val(Atados(Y, x))
                    s = s & ", " & Atados(Y, x)
                Next x
                mSQL = mSQL & (Y + 1) & s & ", " & CStr(sumprs) & "/"
            Next Y
            'retorna la cadena de docenas
            mAtados = mSQL
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub rdoArticuloa_CheckedChanged(sender As Object, e As EventArgs) Handles rdoArticuloa.CheckedChanged
        If DtDetalleTallasArticulo.Rows.Count > 0 Then
            CargarArticulos()
        End If
    End Sub

    Private Sub rdoAtados_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAtados.CheckedChanged
        Cursor = Cursors.WaitCursor

        If dtListadoAtados.Rows.Count = 0 Then
            dtListadoAtados = ObjBU.ConsultaAtadosFolioDevolucion(objDev.Devolucionclienteid)
        End If
        grdParesaGranel.DataSource = Nothing
        bgvParesaGranel.Columns.Clear()
        grdParesaGranel.DataSource = dtListadoAtados
        bgvParesaGranel.IndicatorWidth = 30
        'bgvParesaGranel.Columns.ColumnByFieldName("D").Visible = False
        'bgvParesaGranel.Columns.ColumnByFieldName("B").Visible = False
        DiseñoGrid.DiseñoBaseGrid(bgvParesaGranel)
        lblNumFiltrados.Text = CDbl(dtListadoAtados.Rows.Count).ToString("N0")
        bgvParesaGranel.Columns.ColumnByFieldName("D").OptionsColumn.AllowEdit = False
        bgvParesaGranel.Columns.ColumnByFieldName("B").OptionsColumn.AllowEdit = False
        bgvParesaGranel.Columns.ColumnByFieldName("Coleccion").Caption = "Colección"
        bgvParesaGranel.Columns.ColumnByFieldName("FCreacion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvParesaGranel.Columns.ColumnByFieldName("FCreacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        bgvParesaGranel.Columns.ColumnByFieldName("FCreacion").BestFit()

        Cursor = Cursors.Default

    End Sub

    Private Sub rdoCodigosPar_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCodigosPar.CheckedChanged
        Cursor = Cursors.WaitCursor
        If dtListaPares.Rows.Count = 0 Then
            dtListaPares = ObjBU.ConsultaParesFolioDevolucion(objDev.Devolucionclienteid)
        End If
        grdParesaGranel.DataSource = Nothing
        bgvParesaGranel.Columns.Clear()
        grdParesaGranel.DataSource = dtListaPares
        lblNumFiltrados.Text = CDbl(dtListaPares.Rows.Count).ToString("N0")
        bgvParesaGranel.IndicatorWidth = 30
        DiseñoGrid.DiseñoBaseGrid(bgvParesaGranel)
        bgvParesaGranel.Columns.ColumnByFieldName("D").OptionsColumn.AllowEdit = False
        bgvParesaGranel.Columns.ColumnByFieldName("B").OptionsColumn.AllowEdit = False
        bgvParesaGranel.Columns.ColumnByFieldName("Coleccion").Caption = "Colección"
        bgvParesaGranel.Columns.ColumnByFieldName("FCreacion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvParesaGranel.Columns.ColumnByFieldName("FCreacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        bgvParesaGranel.Columns.ColumnByFieldName("FCreacion").BestFit()
        Cursor = Cursors.Default
    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim NombreArchivo As String = String.Empty
        Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

        Try
            If rdoArticuloa.Checked = True Then
                NombreArchivo = "Datos_ArticulosDevolucion_" & objDev.Devolucionclienteid.ToString() & "_" & fecha_hora
            ElseIf rdoAtados.Checked = True Then
                NombreArchivo = "Datos_AtadosDevolucion_" & objDev.Devolucionclienteid.ToString() & "_" & fecha_hora
            ElseIf rdoCodigosPar.Checked = True Then
                NombreArchivo = "Datos_ParesDevolucion_" & objDev.Devolucionclienteid.ToString() & "_" & fecha_hora
            End If


            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog


                If ret = Windows.Forms.DialogResult.OK Then
                    If bgvParesaGranel.GroupCount > 0 Then
                        grdParesaGranel.ExportToXlsx(.SelectedPath + "\" & NombreArchivo & ".xlsx")
                    Else
                        grdParesaGranel.ExportToXlsx(.SelectedPath + "\" & NombreArchivo & ".xlsx")
                    End If

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & NombreArchivo & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\" & NombreArchivo & ".xlsx")
                End If
            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Cursor = Cursors.WaitCursor
        NumeroFilas = bgvParesaGranel.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            bgvParesaGranel.SetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "Seleccion", chkSeleccionar.Checked)
        Next
        Cursor = Cursors.Default

    End Sub

    Public Sub CargarParesDevolucion()
        'grdVentas.Columns.ColumnByFieldName("OT").Caption = "OT " & vbCrLf & "SAY"
        Cursor = Cursors.WaitCursor
        If dtListaPares.Rows.Count = 0 Then
            dtListaPares = ObjBU.ConsultaParesFolioDevolucion(objDev.Devolucionclienteid)
        End If
        grdParesaGranel.DataSource = Nothing
        bgvParesaGranel.Columns.Clear()
        grdParesaGranel.DataSource = dtListaPares
        DiseñoGrid.DiseñoBaseGrid(bgvParesaGranel)

        'bgvParesaGranel.Columns.ColumnByFieldName("OT").Caption = "OT " & vbCrLf & "SAY"

        Cursor = Cursors.Default

    End Sub

    Private Sub bgvParesaGranel_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvParesaGranel.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub DevolucionCliente_GenerarParesAGranel_Form_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim formaConfirmacion As New ConfirmarForm

        If objDev.LoteGenerado = False Then
            formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
            formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"

            If formaConfirmacion.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub btnSustituir_Click(sender As Object, e As EventArgs) Handles btnSustituir.Click
        Dim form As New DevolucionCliente_GenerarParesAGranel_Sustituir_Form
        Dim NumeroFilas As Integer = 0
        Dim DevolucionDetalleID As String = String.Empty
        Dim TallaID As Integer = 0
        Dim SeleccionIncorrecta As Boolean = True
        Dim Ent_FolioProductoEstilo As New Entidades.ProductoEstilo

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvParesaGranel.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "Seleccion")) = True Then
                    If TallaID = 0 Then
                        TallaID = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "TallaId"))
                    Else
                        If (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "TallaId")) <> TallaID Then
                            SeleccionIncorrecta = False
                        End If
                    End If

                    If DevolucionDetalleID = String.Empty Then
                        DevolucionDetalleID = bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "IdDetalle")
                    Else
                        DevolucionDetalleID = DevolucionDetalleID & "," & bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "IdDetalle")
                    End If
                End If
            Next

            If DevolucionDetalleID <> String.Empty Then
                If SeleccionIncorrecta = True Then
                    form.FolioDevolucionId = objDev.Devolucionclienteid
                    form.FolioDetalleId = DevolucionDetalleID
                    form.TallaId = TallaID
                    If form.ShowDialog() = DialogResult.OK Then
                        'bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "PielColor")
                        Ent_FolioProductoEstilo = form.EntProductoEstilo
                        Dim row = DtDetalleTallasArticulo.AsEnumerable.Where(Function(x) x.Item("IdDetalle") = DevolucionDetalleID).FirstOrDefault()
                        If IsNothing(row) = False Then
                            row.Item("Marca") = Ent_FolioProductoEstilo.MarcaSAY
                            row.Item("Coleccion") = Ent_FolioProductoEstilo.ColeccionSAY
                            row.Item("Temporada") = Ent_FolioProductoEstilo.Temporada
                            row.Item("ModeloSAY") = Ent_FolioProductoEstilo.ModeloSAY
                            row.Item("ModeloSICY") = Ent_FolioProductoEstilo.ModeloSICY
                            row.Item("Piel") = Ent_FolioProductoEstilo.Piel
                            row.Item("Color") = Ent_FolioProductoEstilo.Color
                            row.Item("ProductoEstiloID") = Ent_FolioProductoEstilo.ProductoEstiloId
                            row.Item("CodigoSICY") = Ent_FolioProductoEstilo.CodigoSICY
                            grdParesaGranel.Refresh()
                        End If

                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Los modelos seleccionados tienen que ser de la misma corrida.")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se han seleccionado modelos.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub bgvParesaGranel_RowStyle(sender As Object, e As RowStyleEventArgs) Handles bgvParesaGranel.RowStyle
        Dim EsArticuloActivo As String = String.Empty

        EsArticuloActivo = (bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(e.RowHandle), "ActivoArticulo"))

        If EsArticuloActivo = "NO" Then
            e.Appearance.ForeColor = Color.Red
        End If


    End Sub

    Private Sub chkSeleccionarCDN_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarCDN.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Cursor = Cursors.WaitCursor
        NumeroFilas = bgvParesaGranel.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            bgvParesaGranel.SetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "CDN", chkSeleccionarCDN.Checked)
        Next
        Cursor = Cursors.Default
    End Sub

    Public Sub ObtenerMontosYPares()
        Dim NumeroFilas As Integer = 0
        Dim Total As Double = 0
        Dim ParesAsignados As Integer = 0

        Cursor = Cursors.WaitCursor
        NumeroFilas = bgvParesaGranel.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            Total += bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "Total")

            If IsNumeric(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "PrDN")) = True Then
                ParesAsignados += bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "PrDN")
            End If

            If IsNumeric(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "PrdE")) = True Then
                ParesAsignados += bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "PrdE")
            End If

        Next

        lblParesCapturados.Text = CDbl(ParesAsignados).ToString("N0")
        lblMonto.Text = "$ " + CDbl(Total).ToString("N0")

        Cursor = Cursors.Default

    End Sub

    Private Sub btnGenerarAtadosEspeciales_Click(sender As Object, e As EventArgs) Handles btnGenerarAtadosEspeciales.Click
        GeneraAtadoEspecial()
    End Sub

    Private Sub GeneraAtadoEspecial()
        Dim NumeroFilas As Integer = 0
        Dim Total As Double = 0
        Dim ParesAsignados As Integer = 0
        Dim IdTalla As Integer = 0
        Dim FolioDetalleId As Integer = 0
        Dim DtTallas As DataTable
        Dim dtListadoAtadosEspeciales As New DataTable
        Dim InfoAtados As New Entidades.InfoAtadosEspeciales
        Dim ParesRestantes As Integer = 0
        Dim FilasSeleccionadas As Integer = 0

        Cursor = Cursors.WaitCursor
        NumeroFilas = bgvParesaGranel.DataRowCount
        dtListadoAtadosEspeciales.Columns.Add("NumeroAtado")

        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "Seleccion")) = True Then
                FilasSeleccionadas += 1
                If CInt(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "ParesRestantes")) > 0 Then
                    dtListadoAtadosEspeciales = New DataTable
                    InfoAtados = New Entidades.InfoAtadosEspeciales
                    IdTalla = bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "TallaId")
                    FolioDetalleId = bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "IdDetalle")
                    ParesRestantes = bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), "ParesRestantes")

                    DtTallas = ObjBU.ConsultaTallasCorridas(IdTalla)
                    dtListadoAtadosEspeciales.Columns.Add("NumeroAtado")
                    dtListadoAtadosEspeciales.Rows.Add("1")

                    For Each Fila As DataRow In DtTallas.Rows
                        dtListadoAtadosEspeciales.Columns.Add(Fila.Item("Talla"))
                        If IsDBNull(bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), Fila.Item("Talla"))) = True Then
                            dtListadoAtadosEspeciales.Rows(0).Item(Fila.Item("Talla")) = "0"
                        Else
                            dtListadoAtadosEspeciales.Rows(0).Item(Fila.Item("Talla")) = bgvParesaGranel.GetRowCellValue(bgvParesaGranel.GetVisibleRowHandle(index), Fila.Item("Talla"))
                        End If

                    Next


                    InfoAtados.DtListadoAtadosEspeciales = dtListadoAtadosEspeciales
                    InfoAtados.DtListadoAtadosEspeciales = dtListadoAtadosEspeciales
                    InfoAtados.FolioDetalle = FolioDetalleId
                    InfoAtados.NumeroAtados = 1
                    InfoAtados.NumeroPares = ParesRestantes
                    ListaAtadosEspeciales.Add(InfoAtados)

                    Dim RowDetalle = DtDetalleTallasArticulo.AsEnumerable().Where(Function(x) x.Item("IdDetalle") = FolioDetalleId).FirstOrDefault()
                    RowDetalle.Item("AtE") = InfoAtados.NumeroAtados.ToString
                    RowDetalle.Item("PrdE") = InfoAtados.NumeroPares.ToString()
                    dtListadoAtadosEspeciales.Columns.Add("Total")
                    dtListadoAtadosEspeciales.Rows(0).Item("Total") = ParesRestantes
                    RowDetalle.Item("ParesRestantes") = "0"
                    RowDetalle.Item("ParesRestantes") = "0"

                    If IsNumeric(RowDetalle.Item("AtTotal")) = True Then
                        RowDetalle.Item("AtTotal") = (CInt(RowDetalle.Item("AtTotal")) + InfoAtados.NumeroAtados).ToString()
                    End If

                End If


            End If



        Next

        If FilasSeleccionadas = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Se debe de seleccionar al menos un artículo.")
        End If


    End Sub

End Class