Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class RegistraProductosForm
    Public idNaveDesarrolla As Int32 = 0
    Public idMarca As Int32 = -1
    Public idColeccion As Int32 = 0
    Public idTemporada As Int32 = 0
    Public idSubFamilia As Int32 = 0
    Public anioColeccion As Int32 = 0

    Public idcedis As Integer
    Public esLicencia As Boolean

    Dim idHorma As Int32 = 0
    Dim IdProductoEstilo As Int32 = 0
    Dim idGrupo As Int32 = 0
    Dim idCategoria As Int32 = 0
    Dim codigoProducto As String = String.Empty
    Dim contadorValida As Int32 = 0
    Dim cadenaFoto As String = String.Empty
    Dim cadenaDibujo As String = String.Empty
    Dim consecutivo As String = String.Empty
    Dim exitoMensaje As New ExitoForm
    Dim estiloCliente As Boolean = False
    Dim nuevaFila As Int32 = 0
    Dim codSicyMarca As String = String.Empty
    Dim codSicyColeccion As String = String.Empty
    Dim nombreHorma As String = String.Empty
    Dim NombreModelo As String = String.Empty
    Dim nombreGrupo As String = String.Empty
    Dim nombreCategoria As String = String.Empty
    Dim dtSubfamiliasSeleccionadas As DataTable
    Dim cerrarGuardar As Boolean = False
    Dim idFamiliaVentas As Integer = 0
    Dim familiaVentas As String = ""

    Dim IDSuelaProgramacion As Int32 = 0
    Dim ColorSuelaID As Int32 = 0
    Dim nombreColorSuela As String = String.Empty

    Public Sub llenarComboMarcasCasa()
        Dim objMarcaBU As New Negocios.MarcasBU
        Dim dtDatosMarcas As DataTable
        dtDatosMarcas = objMarcaBU.verMarcasYuyin()
        dtDatosMarcas.Rows.InsertAt(dtDatosMarcas.NewRow, 0)
        cmbMarcasCasa.DataSource = dtDatosMarcas
        cmbMarcasCasa.DisplayMember = "marc_descripcion"
        cmbMarcasCasa.ValueMember = "marc_codigosicy"
    End Sub

    Public Sub llenarComboEstatus()
        Dim objProd As New Negocios.ProductosBU
        Dim dtDatosEstausProds As New DataTable
        Dim datos As New DataTable
        dtDatosEstausProds = objProd.estatusProductos2
        dtDatosEstausProds.Rows.InsertAt(dtDatosEstausProds.NewRow, 0)
        cmbEstatus.DataSource = dtDatosEstausProds
        cmbEstatus.ValueMember = "stpr_productoStatusId"
        cmbEstatus.DisplayMember = "stpr_descripcion"
        cmbEstatus.Text = "PROTOTIPO"
    End Sub

    Public Sub LlenarTablaTallas()
        Dim objTBU As New Programacion.Negocios.TallasBU
        Dim dtListaTallas As New DataTable
        dtListaTallas = objTBU.verComboTallas
        grdTalla.DataSource = dtListaTallas
        grdTalla.DataBind()

        Me.grdTalla.DisplayLayout.Bands(0).Columns.Add("selectTalla", "")
        Dim colckbTalla As UltraGridColumn = grdTalla.DisplayLayout.Bands(0).Columns("selectTalla")
        colckbTalla.Style = ColumnStyle.CheckBox
        colckbTalla.CellActivation = Activation.AllowEdit

        With grdTalla.DisplayLayout.Bands(0)
            '.Columns("fami_familiaid").Hidden = True
            .Columns("talla_tallaid").Hidden = True
            '.Columns("fami_descripcion").Header.Caption = "Familia"
            .Columns("talla_descripcion").Header.Caption = "2- Corrida"
            .Columns("selectTalla").Width = 50
            '.Columns("fami_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdTalla.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        For Each row As UltraGridRow In grdTalla.Rows
            row.Cells("selectTalla").Value = False
        Next
    End Sub

    Public Sub LlenarTablaPieles()
        Dim objPBU As New Programacion.Negocios.PielesBU
        Dim dtListaPieles As DataTable
        dtListaPieles = objPBU.VerPielGridProducto
        grdPieles.DataSource = dtListaPieles
        grdPieles.DataBind()

        Me.grdPieles.DisplayLayout.Bands(0).Columns.Add("selectPiel", "")
        Dim colckbPl As UltraGridColumn = grdPieles.DisplayLayout.Bands(0).Columns("selectPiel")
        colckbPl.Style = ColumnStyle.CheckBox
        colckbPl.CellActivation = Activation.AllowEdit

        With grdPieles.DisplayLayout.Bands(0)
            .Columns("piel_pielid").Hidden = True
            .Columns("color_colorid").Hidden = True
            .Columns("convinacionPC").Header.Caption = "1- Piel Color"
            .Columns("pcsicy").Header.Caption = "SICY"
            .Columns("selectPiel").Width = 50
            .Columns("convinacionPC").CellActivation = Activation.NoEdit
            .Columns("pcsicy").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdPieles.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        For Each row As UltraGridRow In grdPieles.Rows
            row.Cells("selectPiel").Value = False
        Next
    End Sub

    Public Sub LlenarTablaForros()
        Dim objFBU As New Programacion.Negocios.ForrosBU
        Dim dtListaForros As DataTable
        dtListaForros = objFBU.verComboForros
        grdForros.DataSource = dtListaForros
        grdForros.DataBind()
        Me.grdForros.DisplayLayout.Bands(0).Columns.Add("selectForro", "")
        Dim colckbFr As UltraGridColumn = grdForros.DisplayLayout.Bands(0).Columns("selectForro")
        colckbFr.Style = ColumnStyle.CheckBox
        colckbFr.CellActivation = Activation.AllowEdit
        With grdForros.DisplayLayout.Bands(0)
            .Columns("forr_forroid").Hidden = True
            .Columns("forr_codigo").Hidden = True
            .Columns("forr_descripcion").Header.Caption = "6 -Forros"
            .Columns("forr_descripcion").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdForros.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        For Each row As UltraGridRow In grdForros.Rows
            row.Cells("selectForro").Value = False
        Next
    End Sub

    Public Sub LlenarTablaSuelas()
        Dim objSBU As New Programacion.Negocios.SuelasBU
        Dim dtListaSuelas As DataTable
        dtListaSuelas = objSBU.verComboSuelas
        grdSuela.DataSource = dtListaSuelas
        grdSuela.DataBind()
        Me.grdSuela.DisplayLayout.Bands(0).Columns.Add("selectSuela", "")
        Dim colckbSl As UltraGridColumn = grdSuela.DisplayLayout.Bands(0).Columns("selectSuela")
        colckbSl.Style = ColumnStyle.CheckBox
        colckbSl.CellActivation = Activation.AllowEdit

        With grdSuela.DisplayLayout.Bands(0)
            .Columns("suel_suelaid").Hidden = True
            .Columns("suel_codigo").Hidden = True
            .Columns("suel_descripcion").Header.Caption = "7- Suelas"
            .Columns("suel_descripcion").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdSuela.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        For Each row As UltraGridRow In grdSuela.Rows
            row.Cells("selectSuela").Value = False
        Next
    End Sub

    Public Sub LlenarTablaCorte()
        Dim objCBU As New Programacion.Negocios.PielesMuestraBU
        Dim dtListaCortes As DataTable
        dtListaCortes = objCBU.verComboCortes
        grdCorte.DataSource = dtListaCortes
        grdCorte.DataBind()
        Me.grdCorte.DisplayLayout.Bands(0).Columns.Add("selectCorte", "")
        Dim colckbCr As UltraGridColumn = grdCorte.DisplayLayout.Bands(0).Columns("selectCorte")
        colckbCr.Style = ColumnStyle.CheckBox
        colckbCr.CellActivation = Activation.AllowEdit

        With grdCorte.DisplayLayout.Bands(0)
            .Columns("plmu_pielmuestraid").Hidden = True
            .Columns("plmu_codigo").Hidden = True
            .Columns("plmu_descripcion").Header.Caption = "5- Cortes"
            .Columns("plmu_descripcion").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdCorte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        For Each row As UltraGridRow In grdCorte.Rows
            row.Cells("selectCorte").Value = False
        Next
    End Sub
    Public Sub LlenarTablaFamiliasVentas()
        'Dim objCBU As New Programacion.Negocios.FamiliasBU
        'Dim dtListaFamilia As DataTable
        'dtListaFamilia = objCBU.VerComboFamiliaVentas()
        'grdFamVentas.DataSource = Nothing
        'grdFamVentas.DataSource = dtListaFamilia
        'grdFamVentas.DataBind()

        'Me.grdFamVentas.DisplayLayout.Bands(0).Columns.Add("selectFamilia", "")
        'Dim colckbFM As UltraGridColumn = grdFamVentas.DisplayLayout.Bands(0).Columns("selectFamilia")
        'colckbFM.Style = ColumnStyle.CheckBox
        'colckbFM.CellActivation = Activation.AllowEdit

        'With grdFamVentas.DisplayLayout.Bands(0)
        '    .Columns("fapr_familiaproyeccionid").Hidden = True
        '    .Columns("fapr_descripcion").Header.Caption = "5- Familia de Ventas"
        '    .Columns("fapr_descripcion").CellActivation = Activation.NoEdit
        '    .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        'End With
        'grdFamVentas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'For Each row As UltraGridRow In grdFamVentas.Rows
        '    row.Cells("selectFamilia").Value = False
        'Next
    End Sub
    Public Sub LlenarTablaFamilias()
        Dim objCBU As New Programacion.Negocios.FamiliasBU
        Dim dtListaFamilia As DataTable
        dtListaFamilia = objCBU.verComboFamilias("")
        grdFamilia.DataSource = dtListaFamilia
        grdFamilia.DataBind()

        Me.grdFamilia.DisplayLayout.Bands(0).Columns.Add("selectFamilia", "")
        Dim colckbFM As UltraGridColumn = grdFamilia.DisplayLayout.Bands(0).Columns("selectFamilia")
        colckbFM.Style = ColumnStyle.CheckBox
        colckbFM.CellActivation = Activation.AllowEdit

        With grdFamilia.DisplayLayout.Bands(0)
            .Columns("fami_familiaid").Hidden = True
            .Columns("fami_codigo").Hidden = True
            .Columns("fami_descripcion").Header.Caption = "3- Familias"
            .Columns("fami_descripcion").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdFamilia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        For Each row As UltraGridRow In grdFamilia.Rows
            row.Cells("selectFamilia").Value = False
        Next
    End Sub

    Public Sub llenarTablaLineas()
        Dim objLineas As New Negocios.LineasBU
        Dim dtDatosLineas As New DataTable
        dtDatosLineas = objLineas.verListaLineas(True)
        grdLinea.DataSource = dtDatosLineas

        Me.grdLinea.DisplayLayout.Bands(0).Columns.Add("selectLinea", "")
        Dim colckbLN As UltraGridColumn = grdLinea.DisplayLayout.Bands(0).Columns("selectLinea")
        colckbLN.Style = ColumnStyle.CheckBox
        colckbLN.CellActivation = Activation.AllowEdit

        With grdLinea.DisplayLayout.Bands(0)
            .Columns("linea_lineaid").Hidden = True
            .Columns("linea_activo").Hidden = True
            .Columns("linea_descripcion").Header.Caption = "4- Lineas"
            .Columns("linea_descripcion").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdLinea.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        For Each row As UltraGridRow In grdLinea.Rows
            row.Cells("selectLinea").Value = False
        Next

    End Sub

    Public Sub accionesdeInicio()
        txtCodigo.Text = String.Empty
        txtColeccion.Text = String.Empty
        txtDescripcion.Text = String.Empty
        txtCategoria.Text = String.Empty
        txtMarca.Text = String.Empty
        'txtTemporadaO.Text = String.Empty
        lblCodigo.ForeColor = Drawing.Color.Black
        lblMarca.ForeColor = Drawing.Color.Black
        lblColeccion.ForeColor = Drawing.Color.Black
        lblCategoria.ForeColor = Drawing.Color.Black
        lblDescripcion.ForeColor = Drawing.Color.Black
        LlenarTablaPieles()
        LlenarTablaTallas()
        LlenarTablaForros()
        LlenarTablaSuelas()
        LlenarTablaCorte()
        LlenarTablaFamilias()
        LlenarTablaFamiliasVentas()
        llenarTablaLineas()
        llenarComboMarcasCasa()
        llenarComboEstatus()
        rdoActivo.Checked = True
        llenarComboNaves()
    End Sub
    Public Sub llenarComboNaves()
        cmbNaveDesarrolla = Controles.ComboNavesSegunUsuario(cmbNaveDesarrolla, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNaveDesarrolla.Items.Count = 2 Then
            cmbNaveDesarrolla.SelectedIndex = 1
        End If
    End Sub
    Private Sub RegistraProductosForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If cerrarGuardar = False Then
            Dim objAdvSalir As New ConfirmarForm
            objAdvSalir.mensaje = "¿Está seguro de salir SIN guardar los cambios?"
            If objAdvSalir.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        Else
            '1
            Me.Dispose()
        End If
    End Sub

    Private Sub RegistraProductosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtMarca.Focus() '11/01/2020
        txtDescripcion.Enabled = False
        'accionesdeInicio()
        accionesdeInicioCedis()
        Me.toolMensaje.SetToolTip(btnAgregarDato, "Asegúrese de seleccionar " + Chr(13) + "los campos obligatorios" + Chr(13) + "antes de generar registros.")
    End Sub

    Public Sub LlenarTablaDetallesEstilosProducto()
        Dim nuevaFila As Int32 = 0
        Dim contPiel As Int32 = 0
        Dim tablaDetalle As New DataTable("TablaDetalle")
        Dim Fila As DataRow
        Dim objSuela As New Programacion.Negocios.SuelasBU
        Dim objForro As New Programacion.Negocios.ForrosBU
        Dim objCortes As New Programacion.Negocios.PielesMuestraBU
        Dim objLineas As New Programacion.Negocios.LineasBU

        Dim listSuelaProgramacion As New ValueList
        Dim dtSuelasProgramacion As New DataTable


        Dim listColorSuelaProgramacion As New ValueList
        Dim dtColorSuelasProgramacion As New DataTable
        Dim objbuColorSuela As New Programacion.Negocios.ColoresSuelaBU

        tablaDetalle.Columns.Add("idPiel", GetType(Int32))
        tablaDetalle.Columns.Add("idColor", GetType(Int32))
        tablaDetalle.Columns.Add("pielColor", GetType(String))
        tablaDetalle.Columns.Add("idTalla", GetType(Int32))
        tablaDetalle.Columns.Add("talla", GetType(String))
        tablaDetalle.Columns.Add("idFamilia", GetType(Int32))
        tablaDetalle.Columns.Add("familia", GetType(String))
        tablaDetalle.Columns.Add("idLinea", GetType(Int32))
        tablaDetalle.Columns.Add("linea", GetType(String))
        tablaDetalle.Columns.Add("idFamiliaVentas", GetType(Int32))
        tablaDetalle.Columns.Add("familia ventas", GetType(String))
        tablaDetalle.Columns.Add("idCorte", GetType(Int32))
        tablaDetalle.Columns.Add("corte", GetType(String))
        tablaDetalle.Columns.Add("idForro", GetType(Int32))
        tablaDetalle.Columns.Add("forro", GetType(String))
        tablaDetalle.Columns.Add("idSuela", GetType(Int32))
        tablaDetalle.Columns.Add("suela", GetType(String))

        tablaDetalle.Columns.Add("idHorma", GetType(Int32))
        tablaDetalle.Columns.Add("Horma", GetType(String))
        tablaDetalle.Columns.Add("Sicy", GetType(String))
        tablaDetalle.Columns.Add("sicyPCOL", GetType(String))
        tablaDetalle.Columns.Add("seleccion", GetType(Boolean))
        tablaDetalle.Columns.Add("IdMarcaCasa", GetType(String))
        tablaDetalle.Columns.Add("Fracción_Arancelaria", GetType(String))
        tablaDetalle.Columns.Add("EstatusDes", GetType(String))
        tablaDetalle.Columns.Add("idEstatus", GetType(Int32))
        tablaDetalle.Columns.Add("ArticuloNuevo", GetType(Boolean))
        tablaDetalle.Columns.Add("idClaveSAT", GetType(String))
        tablaDetalle.Columns.Add("SuelaProgramacionID", GetType(Int32))
        tablaDetalle.Columns.Add("SuelaProgramacion", GetType(String))
        tablaDetalle.Columns.Add("ColorSuelaID", GetType(Int32))
        tablaDetalle.Columns.Add("ColorSuela", GetType(String))

        Dim objPBU As New Programacion.Negocios.ProductosBU


        Dim dtClaveSAT As New DataTable
        Dim listClaveSAT As New ValueList
        Dim dtFamiliaProyeccion As New DataTable
        Dim listFamiliaProyeccion As New ValueList
        Dim dtSuelas As New DataTable
        Dim dtForros As New DataTable
        Dim dtCortes As New DataTable
        Dim dtLineas As New DataTable
        Dim listSuelas As New ValueList
        Dim listForros As New ValueList
        Dim listCortes As New ValueList
        Dim listLineas As New ValueList

        dtClaveSAT = objPBU.claveSAT()
        dtFamiliaProyeccion = objPBU.ObtenerFamiliasProyeccion()
        dtSuelas = objSuela.verComboSuelas()
        dtForros = objForro.verComboForros()
        dtCortes = objCortes.verComboCortes()
        dtLineas = objLineas.verComboLineas()

        For Each renglon As DataRow In dtClaveSAT.Rows
            listClaveSAT.ValueListItems.Add(renglon.Item("ID"), renglon.Item("Clave SAT"))
        Next

        For Each renglon As DataRow In dtFamiliaProyeccion.Rows
            listFamiliaProyeccion.ValueListItems.Add(renglon.Item("idFamiliaVentas"), renglon.Item("familia ventas"))
        Next

        For Each renglon As DataRow In dtSuelas.Rows
            listSuelas.ValueListItems.Add(renglon.Item("suel_suelaid"), renglon.Item("suel_descripcion"))
        Next

        For Each renglon As DataRow In dtForros.Rows
            listForros.ValueListItems.Add(renglon.Item("forr_forroid"), renglon.Item("forr_descripcion"))
        Next

        For Each renglon As DataRow In dtCortes.Rows
            listCortes.ValueListItems.Add(renglon.Item("plmu_pielmuestraid"), renglon.Item("plmu_descripcion"))
        Next

        For Each renglon As DataRow In dtLineas.Rows
            listLineas.ValueListItems.Add(renglon.Item("linea_lineaid"), renglon.Item("linea_descripcion"))
        Next

        For Each rowPiel As UltraGridRow In grdPieles.Rows
            If (rowPiel.Cells("selectPiel").Value = True) Then
                Dim contTalla As Int32 = 0
                ' ''_____________________________________________________________________________________
                For Each rowTalla As UltraGridRow In grdTalla.Rows
                    If (rowTalla.Cells("selectTalla").Value = True) Then
                        Dim contFamilia As Int32 = 0

                        ' ''_____________________________________________________________________________________
                        For Each rowFamilia As UltraGridRow In grdFamilia.Rows
                            If (rowFamilia.Cells("selectFamilia").Value = True) Then

                                Dim contLinea As Int32 = 0
                                ' ''_____________________________________________________________________________________

                                For Each rowLinea As UltraGridRow In grdLinea.Rows
                                    If (rowLinea.Cells("selectLinea").Value = True) Then
                                        Dim contForro As Int32 = 0

                                        ' ''_____________________________________________________________________________________

                                        For Each rowForro As UltraGridRow In grdForros.Rows
                                            If (rowForro.Cells("selectForro").Value = True) Then
                                                Dim contSuela As Int32 = 0

                                                ' ''_____________________________________________________________________________________

                                                For Each rowSuela As UltraGridRow In grdSuela.Rows
                                                    If (rowSuela.Cells("selectSuela").Value = True) Then
                                                        Dim contCorte As Int32 = 0

                                                        ' ''_____________________________________________________________________________________

                                                        For Each rowCorte As UltraGridRow In grdCorte.Rows
                                                            If (rowCorte.Cells("selectCorte").Value = True) Then
                                                                ' ''_____________________________________________________________________________________



                                                                Fila = tablaDetalle.NewRow
                                                                ' ''Creando los datos para cada columna              

                                                                Fila("idPiel") = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("piel_pielid").Value.ToString)
                                                                Fila("idColor") = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("color_colorid").Value.ToString)
                                                                Fila("pielColor") = grdPieles.Rows(contPiel).Cells("convinacionPC").Value.ToString
                                                                Fila("idFamilia") = Convert.ToInt32(grdFamilia.Rows(contFamilia).Cells("fami_familiaid").Value.ToString)
                                                                Fila("familia") = grdFamilia.Rows(contFamilia).Cells("fami_descripcion").Value.ToString
                                                                Fila("idFamiliaVentas") = idFamiliaVentas
                                                                Fila("familia ventas") = familiaVentas
                                                                Fila("idLinea") = Convert.ToInt32(grdLinea.Rows(contLinea).Cells("linea_lineaid").Value.ToString)
                                                                Fila("linea") = grdLinea.Rows(contLinea).Cells("linea_descripcion").Value.ToString
                                                                Fila("idTalla") = Convert.ToInt32(grdTalla.Rows(contTalla).Cells("talla_tallaid").Value.ToString)
                                                                Fila("talla") = grdTalla.Rows(contTalla).Cells("talla_descripcion").Value.ToString
                                                                Fila("idCorte") = Convert.ToInt32(grdCorte.Rows(contCorte).Cells("plmu_pielmuestraid").Value.ToString)
                                                                Fila("corte") = grdCorte.Rows(contCorte).Cells("plmu_descripcion").Value.ToString
                                                                Fila("idForro") = Convert.ToInt32(grdForros.Rows(contForro).Cells("forr_forroid").Value.ToString)
                                                                Fila("forro") = grdForros.Rows(contForro).Cells("forr_descripcion").Value.ToString
                                                                Fila("idSuela") = Convert.ToInt32(grdSuela.Rows(contSuela).Cells("suel_suelaid").Value.ToString)
                                                                Fila("suela") = grdSuela.Rows(contSuela).Cells("suel_descripcion").Value.ToString
                                                                Fila("idHorma") = CInt(idHorma)
                                                                Fila("Horma") = lblNombreHorma.Text
                                                                Fila("EstatusDes") = cmbEstatus.Text
                                                                Fila("idEstatus") = cmbEstatus.SelectedValue
                                                                Fila("ArticuloNuevo") = True


                                                                Fila("SuelaProgramacionID") = IDSuelaProgramacion
                                                                Fila("SuelaProgramacion") = lblNombreSuelaProgramacion.Text
                                                                Fila("ColorSuelaID") = ColorSuelaID
                                                                Fila("ColorSuela") = lblColorSuela.Text




                                                                Fila("idClaveSAT") = objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, idFamiliaVentas, grdTalla.Rows(contTalla).Cells("talla_tallaid").Value, grdPieles.Rows(contPiel).Cells("color_colorid").Value)
                                                                Fila("Fracción_Arancelaria") = objPBU.buscarFraccionArancelariaArticuloAgregado(Fila("idtalla"), Fila("idfamilia"), Fila("idcorte"), Fila("idforro"), Fila("idsuela"), txtCategoria.Text)


                                                                ' Fila("ClaveSAT").Equals(objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, idFamiliaVentas, grdTalla.Rows(contTalla).Cells("talla_tallaid").Value, grdPieles.Rows(contPiel).Cells("color_colorid").Value))
                                                                'rowEstilo.Cells("idClaveSAT").Value = objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, idFamiliaVentas, rowEstilo.Cells("idTalla").Value, rowEstilo.Cells("idColor").Value)

                                                                If (codSicyMarca <> Nothing And codSicyColeccion <> Nothing And txtCodSicy.Text <> Nothing And grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString <> Nothing) Then
                                                                    Dim sicy As String = txtCodSicy.Text
                                                                    If (sicy.Length >= 3) Then
                                                                        If (sicy.Length = 3) Then
                                                                            Fila("Sicy") = codSicyMarca + codSicyColeccion + "0" + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString
                                                                        ElseIf (sicy.Length > 3) Then
                                                                            Fila("Sicy") = codSicyMarca + codSicyColeccion + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString
                                                                        End If
                                                                    End If
                                                                Else
                                                                    Fila("Sicy") = ""
                                                                End If
                                                                If (grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString <> Nothing) Then
                                                                    Fila("sicyPCOL") = grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString
                                                                Else
                                                                    Fila("sicyPCOL") = ""
                                                                End If
                                                                Fila("seleccion") = False
                                                                Fila("IdMarcaCasa") = codSicyMarca
                                                                ' ''Adicionando a la tabla la nueva fila       
                                                                tablaDetalle.Rows.Add(Fila)

                                                                nuevaFila = nuevaFila + 1
                                                                ' ''_____________________________________________________________________________________
                                                            End If
                                                            contCorte = contCorte + 1
                                                        Next

                                                        ' ''_____________________________________________________________________________________
                                                    End If
                                                    contSuela = contSuela + 1
                                                Next

                                                ' ''_____________________________________________________________________________________
                                            End If
                                            contForro = contForro + 1
                                        Next

                                        ' ''_____________________________________________________________________________________
                                    End If
                                    contLinea = contLinea + 1
                                Next

                                ' ''_____________________________________________________________________________________
                            End If
                            contFamilia = contFamilia + 1
                        Next

                        ' ''_____________________________________________________________________________________
                    End If
                    contTalla = contTalla + 1
                Next

                ' ''_____________________________________________________________________________________
            End If
            contPiel = contPiel + 1
        Next

        dtSuelasProgramacion = objPBU.ObtenerSuelasProgramacion()
        dtColorSuelasProgramacion = objbuColorSuela.obtenerColoresSuelas(True)

        For Each renglon As DataRow In dtColorSuelasProgramacion.Rows
            listColorSuelaProgramacion.ValueListItems.Add(renglon.Item("cosu_colorsuelaid"), renglon.Item("cosu_nombrecolor"))
        Next

        For Each renglon As DataRow In dtSuelasProgramacion.Rows
            listSuelaProgramacion.ValueListItems.Add(renglon.Item("SuelaID"), renglon.Item("Suela"))
        Next


        Me.grdDetallesEstilos.DataSource = tablaDetalle
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idClaveSAT").ValueList = listClaveSAT
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idFamiliaVentas").ValueList = listFamiliaProyeccion
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("SuelaProgramacionID").ValueList = listSuelaProgramacion
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("ColorSuelaID").ValueList = listColorSuelaProgramacion
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idSuela").ValueList = listSuelas
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idForro").ValueList = listForros
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idCorte").ValueList = listCortes
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idLinea").ValueList = listLineas
        RecuperarFraccionesArancelariasDelProducto()
        Elimiar_Primeros_asteriscos_griddetalle()
        estiloGrdDetalle()
    End Sub

    Public Sub LlenarTablaDetallesEstilosProductoCliente()
        Dim nuevaFila As Int32 = 0
        Dim contPiel As Int32 = 0
        Dim contador As Int32 = 0
        Dim listSuelaProgramacion As New ValueList
        Dim dtSuelasProgramacion As New DataTable

        Dim listColorSuelaProgramacion As New ValueList
        Dim dtColorSuelasProgramacion As New DataTable
        Dim objbuColorSuela As New Programacion.Negocios.ColoresSuelaBU
        Dim objSuela As New Programacion.Negocios.SuelasBU
        Dim objForro As New Programacion.Negocios.ForrosBU
        Dim objCortes As New Programacion.Negocios.PielesMuestraBU
        Dim objLineas As New Programacion.Negocios.LineasBU

        Dim dtTablaDatos As New DataTable
        dtTablaDatos = grdDetallesEstilos.DataSource

        Try
            contador = dtTablaDatos.Rows.Count
        Catch ex As Exception
            contador = 0
        End Try

        If codSicyMarca <> "A" Then
            codSicyMarca = ""
            Try
                codSicyMarca = cmbMarcasCasa.SelectedValue
            Catch ex As Exception
                codSicyMarca = ""
            End Try
        End If

        Dim tablaDetalle As New DataTable("TablaDetalle")
        ' ''Llenar manualmente ultragrid.
        ' ''Dim rowDetalle As DataRow
        Dim Fila As DataRow
        ' ''Instanciando una nueva fila (row)     
        tablaDetalle.Columns.Add("idPiel", GetType(Int32))
        tablaDetalle.Columns.Add("idColor", GetType(Int32))
        tablaDetalle.Columns.Add("pielColor", GetType(String))
        tablaDetalle.Columns.Add("idTalla", GetType(Int32))
        tablaDetalle.Columns.Add("talla", GetType(String))
        tablaDetalle.Columns.Add("idFamilia", GetType(Int32))
        tablaDetalle.Columns.Add("familia", GetType(String))
        tablaDetalle.Columns.Add("idLinea", GetType(Int32))
        tablaDetalle.Columns.Add("linea", GetType(String))
        tablaDetalle.Columns.Add("idFamiliaVentas", GetType(Int32))
        tablaDetalle.Columns.Add("familia ventas", GetType(String))
        tablaDetalle.Columns.Add("idCorte", GetType(Int32))
        tablaDetalle.Columns.Add("corte", GetType(String))
        tablaDetalle.Columns.Add("idForro", GetType(Int32))
        tablaDetalle.Columns.Add("forro", GetType(String))
        tablaDetalle.Columns.Add("idSuela", GetType(Int32))
        tablaDetalle.Columns.Add("suela", GetType(String))

        tablaDetalle.Columns.Add("idHorma", GetType(Int32))
        tablaDetalle.Columns.Add("Horma", GetType(String))
        tablaDetalle.Columns.Add("Sicy", GetType(String))
        tablaDetalle.Columns.Add("sicyPCOL", GetType(String))
        tablaDetalle.Columns.Add("seleccion", GetType(Boolean))
        tablaDetalle.Columns.Add("IdMarcaCasa", GetType(String))
        tablaDetalle.Columns.Add("Fracción_Arancelaria", GetType(String))
        tablaDetalle.Columns.Add("EstatusDes", GetType(String))
        tablaDetalle.Columns.Add("idEstatus", GetType(Int32))
        tablaDetalle.Columns.Add("ArticuloNuevo", GetType(Boolean))
        tablaDetalle.Columns.Add("idClaveSAT", GetType(String))
        tablaDetalle.Columns.Add("SuelaProgramacionID", GetType(Int32))
        tablaDetalle.Columns.Add("SuelaProgramacion", GetType(String))
        tablaDetalle.Columns.Add("ColorSuelaID", GetType(Int32))
        tablaDetalle.Columns.Add("ColorSuela", GetType(String))
        Dim objPBU As New Programacion.Negocios.ProductosBU

        Dim dtClaveSAT As New DataTable
        Dim listClaveSAT As New ValueList
        Dim dtFamiliaProyeccion As New DataTable
        Dim listFamiliaProyeccion As New ValueList
        Dim dtLineas As New DataTable
        Dim listLineas As New ValueList
        Dim dtCortes As New DataTable
        Dim listCortes As New ValueList
        Dim dtForros As New DataTable
        Dim listForros As New ValueList
        Dim dtSuelas As New DataTable
        Dim listSuelas As New ValueList

        dtClaveSAT = objPBU.claveSAT()
        dtFamiliaProyeccion = objPBU.ObtenerFamiliasProyeccion()
        dtLineas = objLineas.verComboLineas()
        dtCortes = objCortes.verComboCortes()
        dtForros = objForro.verComboForros()
        dtSuelas = objSuela.verComboSuelas()


        For Each renglon As DataRow In dtClaveSAT.Rows
            listClaveSAT.ValueListItems.Add(renglon.Item("ID"), renglon.Item("Clave SAT"))
        Next

        For Each renglon As DataRow In dtFamiliaProyeccion.Rows
            listFamiliaProyeccion.ValueListItems.Add(renglon.Item("idFamiliaVentas"), renglon.Item("familia ventas"))
        Next
        For Each renglon As DataRow In dtSuelas.Rows
            listSuelas.ValueListItems.Add(renglon.Item("suel_suelaid"), renglon.Item("suel_descripcion"))
        Next

        For Each renglon As DataRow In dtForros.Rows
            listForros.ValueListItems.Add(renglon.Item("forr_forroid"), renglon.Item("forr_descripcion"))
        Next

        For Each renglon As DataRow In dtCortes.Rows
            listCortes.ValueListItems.Add(renglon.Item("plmu_pielmuestraid"), renglon.Item("plmu_descripcion"))
        Next

        For Each renglon As DataRow In dtLineas.Rows
            listLineas.ValueListItems.Add(renglon.Item("linea_lineaid"), renglon.Item("linea_descripcion"))
        Next



        For Each rowPiel As UltraGridRow In grdPieles.Rows
            If (rowPiel.Cells("selectPiel").Value = True) Then
                Dim contTalla As Int32 = 0
                ' ''_____________________________________________________________________________________
                For Each rowTalla As UltraGridRow In grdTalla.Rows
                    If (rowTalla.Cells("selectTalla").Value = True) Then
                        Dim contFamilia As Int32 = 0

                        ' ''_____________________________________________________________________________________
                        For Each rowFamilia As UltraGridRow In grdFamilia.Rows
                            If (rowFamilia.Cells("selectFamilia").Value = True) Then

                                Dim contLinea As Int32 = 0
                                ' ''_____________________________________________________________________________________

                                For Each rowLinea As UltraGridRow In grdLinea.Rows
                                    If (rowLinea.Cells("selectLinea").Value = True) Then
                                        Dim contForro As Int32 = 0

                                        ' ''_____________________________________________________________________________________

                                        For Each rowForro As UltraGridRow In grdForros.Rows
                                            If (rowForro.Cells("selectForro").Value = True) Then
                                                Dim contSuela As Int32 = 0

                                                ' ''_____________________________________________________________________________________

                                                For Each rowSuela As UltraGridRow In grdSuela.Rows
                                                    If (rowSuela.Cells("selectSuela").Value = True) Then
                                                        Dim contCorte As Int32 = 0

                                                        ' ''_____________________________________________________________________________________

                                                        For Each rowCorte As UltraGridRow In grdCorte.Rows
                                                            If (rowCorte.Cells("selectCorte").Value = True) Then
                                                                Dim contColorSuela As Int32 = 0

                                                                ' ''_____________________________________________________________________________________


                                                                Fila = tablaDetalle.NewRow
                                                                ' ''Creando los datos para cada columna              

                                                                Fila("idPiel") = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("piel_pielid").Value.ToString)
                                                                Fila("idColor") = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("color_colorid").Value.ToString)
                                                                Fila("pielColor") = grdPieles.Rows(contPiel).Cells("convinacionPC").Value.ToString
                                                                Fila("idFamilia") = Convert.ToInt32(grdFamilia.Rows(contFamilia).Cells("fami_familiaid").Value.ToString)
                                                                Fila("familia") = grdFamilia.Rows(contFamilia).Cells("fami_descripcion").Value.ToString
                                                                Fila("idFamiliaVentas") = idFamiliaVentas
                                                                Fila("familia ventas") = familiaVentas
                                                                Fila("idLinea") = Convert.ToInt32(grdLinea.Rows(contLinea).Cells("linea_lineaid").Value.ToString)
                                                                Fila("linea") = grdLinea.Rows(contLinea).Cells("linea_descripcion").Value.ToString
                                                                Fila("idTalla") = Convert.ToInt32(grdTalla.Rows(contTalla).Cells("talla_tallaid").Value.ToString)
                                                                Fila("talla") = grdTalla.Rows(contTalla).Cells("talla_descripcion").Value.ToString
                                                                Fila("idCorte") = Convert.ToInt32(grdCorte.Rows(contCorte).Cells("plmu_pielmuestraid").Value.ToString)
                                                                Fila("corte") = grdCorte.Rows(contCorte).Cells("plmu_descripcion").Value.ToString
                                                                Fila("idForro") = Convert.ToInt32(grdForros.Rows(contForro).Cells("forr_forroid").Value.ToString)
                                                                Fila("forro") = grdForros.Rows(contForro).Cells("forr_descripcion").Value.ToString
                                                                Fila("idSuela") = Convert.ToInt32(grdSuela.Rows(contSuela).Cells("suel_suelaid").Value.ToString)
                                                                Fila("suela") = grdSuela.Rows(contSuela).Cells("suel_descripcion").Value.ToString
                                                                Fila("idHorma") = CInt(idHorma)
                                                                Fila("Horma") = lblNombreHorma.Text
                                                                Fila("ArticuloNuevo") = True
                                                                Fila("EstatusDes") = cmbEstatus.Text
                                                                Fila("idEstatus") = cmbEstatus.SelectedValue
                                                                Fila("idClaveSAT") = objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, idFamiliaVentas, grdTalla.Rows(contTalla).Cells("talla_tallaid").Value, grdPieles.Rows(contPiel).Cells("color_colorid").Value)


                                                                Fila("SuelaProgramacionID") = IDSuelaProgramacion
                                                                Fila("SuelaProgramacion") = lblNombreSuelaProgramacion.Text
                                                                Fila("ColorSuelaID") = ColorSuelaID
                                                                Fila("ColorSuela") = lblColorSuela.Text


                                                                'tablaDetalle.Columns.Add("SuelaProgramacionID", GetType(Int32))
                                                                'tablaDetalle.Columns.Add("SuelaProgramacion", GetType(String))
                                                                'tablaDetalle.Columns.Add("ColorSuelaID", GetType(Int32))
                                                                'tablaDetalle.Columns.Add("ColorSuela", GetType(String))

                                                                If (codSicyMarca <> Nothing And codSicyColeccion <> Nothing And txtCodSicy.Text <> Nothing And grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString <> Nothing) Then
                                                                    Dim sicy As String = txtCodSicy.Text
                                                                    If (sicy.Length >= 3) Then
                                                                        If (sicy.Length = 3) Then
                                                                            Fila("Sicy") = codSicyMarca + codSicyColeccion + "0" + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString
                                                                        ElseIf (sicy.Length > 3) Then
                                                                            Fila("Sicy") = codSicyMarca + codSicyColeccion + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString
                                                                        End If
                                                                    End If
                                                                Else
                                                                    Fila("Sicy") = ""
                                                                End If
                                                                If (grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString <> Nothing) Then
                                                                    Fila("sicyPCOL") = grdPieles.Rows(contPiel).Cells("pcsicy").Value.ToString
                                                                Else
                                                                    Fila("sicyPCOL") = ""
                                                                End If

                                                                Fila("seleccion") = False
                                                                Fila("IdMarcaCasa") = codSicyMarca
                                                                'Adicionando a la tabla la nueva fila       
                                                                tablaDetalle.Rows.Add(Fila)
                                                                nuevaFila = nuevaFila + 1



                                                            End If
                                                            contCorte = contCorte + 1
                                                        Next

                                                        ' ''_____________________________________________________________________________________
                                                    End If
                                                    contSuela = contSuela + 1
                                                Next

                                                ' ''_____________________________________________________________________________________
                                            End If
                                            contForro = contForro + 1
                                        Next

                                        ''_____________________________________________________________________________________
                                    End If
                                    contLinea = contLinea + 1
                                Next

                                ' ''_____________________________________________________________________________________

                            End If
                            contFamilia = contFamilia + 1
                        Next

                        ' ''_____________________________________________________________________________________
                    End If
                    contTalla = contTalla + 1
                Next

                ' ''_____________________________________________________________________________________
            End If
            contPiel = contPiel + 1
        Next


        Dim validaIngreso As Boolean = True
        If (tablaDetalle.Rows.Count > 0) Then
            For Each rowNuevo As UltraGridRow In grdDetallesEstilos.Rows
                If (rowNuevo.Cells("idPiel").Value.ToString = tablaDetalle.Rows(0)("idPiel").ToString And
                    rowNuevo.Cells("idColor").Value.ToString = tablaDetalle.Rows(0)("idColor").ToString And
                      rowNuevo.Cells("idTalla").Value.ToString = tablaDetalle.Rows(0)("idTalla").ToString And
                    rowNuevo.Cells("idFamilia").Value.ToString = tablaDetalle.Rows(0)("idFamilia").ToString And
                     rowNuevo.Cells("idFamiliaVentas").Value.ToString = tablaDetalle.Rows(0)("idFamiliaVentas").ToString And
                     rowNuevo.Cells("idLinea").Value.ToString = tablaDetalle.Rows(0)("idLinea").ToString And
                     rowNuevo.Cells("idCorte").Value.ToString = tablaDetalle.Rows(0)("idCorte").ToString And
                     rowNuevo.Cells("idForro").Value.ToString = tablaDetalle.Rows(0)("idForro").ToString And
                     rowNuevo.Cells("idSuela").Value.ToString = tablaDetalle.Rows(0)("idSuela").ToString And
                     rowNuevo.Cells("idHorma").Value.ToString = tablaDetalle.Rows(0)("idHorma").ToString) Then
                    validaIngreso = False
                End If
            Next
        End If

        If (validaIngreso = True) Then
            If (contador > 0) Then
                For Each rowEstilo As DataRow In dtTablaDatos.Rows
                    Fila = tablaDetalle.NewRow
                    Fila("idPiel") = Convert.ToInt32(rowEstilo("idPiel").ToString)
                    Fila("idColor") = Convert.ToInt32(rowEstilo("idColor").ToString)
                    Fila("pielColor") = rowEstilo("pielColor").ToString
                    Fila("idTalla") = Convert.ToInt32(rowEstilo("idTalla").ToString)
                    Fila("talla") = rowEstilo("talla").ToString

                    Fila("idFamilia") = Convert.ToInt32(rowEstilo("idFamilia").ToString)
                    Fila("familia") = rowEstilo("familia").ToString
                    Fila("idFamiliaVentas") = Convert.ToInt32(rowEstilo("idFamiliaVentas").ToString)
                    Fila("familia ventas") = rowEstilo("familia ventas").ToString
                    Fila("idLinea") = Convert.ToInt32(rowEstilo("idLinea").ToString)
                    Fila("linea") = rowEstilo("linea").ToString

                    Fila("idCorte") = Convert.ToInt32(rowEstilo("idCorte").ToString)
                    Fila("corte") = rowEstilo("corte").ToString
                    Fila("idForro") = Convert.ToInt32(rowEstilo("idForro").ToString)
                    Fila("forro") = rowEstilo("forro").ToString
                    Fila("idSuela") = Convert.ToInt32(rowEstilo("idSuela").ToString)
                    Fila("suela") = rowEstilo("suela").ToString



                    Fila("idHorma") = CInt(rowEstilo("idHorma").ToString)
                    Fila("Horma") = rowEstilo("Horma").ToString

                    Fila("SuelaProgramacionID") = CInt(rowEstilo("SuelaProgramacionID").ToString)
                    Fila("SuelaProgramacion") = rowEstilo("SuelaProgramacion").ToString
                    Fila("ColorSuelaID") = CInt(rowEstilo("ColorSuelaID").ToString)
                    Fila("ColorSuela") = rowEstilo("ColorSuela").ToString

                    If (rowEstilo("Sicy").ToString <> Nothing) Then
                        Fila("Sicy") = rowEstilo("Sicy").ToString
                        Fila("sicyPCOL") = rowEstilo("sicyPCOL").ToString
                    Else
                        Fila("Sicy") = ""
                        'Fila("sicyPCOL") = ""
                        Fila("sicyPCOL") = rowEstilo("sicyPCOL").ToString
                    End If
                    Fila("seleccion") = rowEstilo("seleccion").ToString
                    Fila("IdMarcaCasa") = rowEstilo("IdMarcaCasa").ToString
                    Fila("idClaveSAT") = rowEstilo("idClaveSAT").ToString
                    tablaDetalle.Rows.Add(Fila)

                Next

            End If


            dtSuelasProgramacion = objPBU.ObtenerSuelasProgramacion()
            dtColorSuelasProgramacion = objbuColorSuela.obtenerColoresSuelas(True)

            For Each renglon As DataRow In dtColorSuelasProgramacion.Rows
                listColorSuelaProgramacion.ValueListItems.Add(renglon.Item("cosu_colorsuelaid"), renglon.Item("cosu_nombrecolor"))
            Next

            For Each renglon As DataRow In dtSuelasProgramacion.Rows
                listSuelaProgramacion.ValueListItems.Add(renglon.Item("SuelaID"), renglon.Item("Suela"))
            Next



            Me.grdDetallesEstilos.DataSource = tablaDetalle
            grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idClaveSAT").ValueList = listClaveSAT
            grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idFamiliaVentas").ValueList = listFamiliaProyeccion
            grdDetallesEstilos.DisplayLayout.Bands(0).Columns("SuelaProgramacionID").ValueList = listSuelaProgramacion
            grdDetallesEstilos.DisplayLayout.Bands(0).Columns("ColorSuelaID").ValueList = listColorSuelaProgramacion
            grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idSuela").ValueList = listSuelas
            grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idForro").ValueList = listForros
            grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idCorte").ValueList = listCortes
            grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idLinea").ValueList = listLineas

            ''Recuperamos la fraccion arancelaria para cada detalle
            RecuperarFraccionesArancelariasDelProducto()
            Elimiar_Primeros_asteriscos_griddetalle()

            estiloGrdDetalle()
        End If
    End Sub


    Public Sub Elimiar_Primeros_asteriscos_griddetalle()
        For Each row As UltraGridRow In grdDetallesEstilos.Rows
            If Not IsDBNull(row.Cells("Fracción_Arancelaria")) Then
                If row.Cells("Fracción_Arancelaria").Text.StartsWith("*") Then
                    Dim Fracciones As String
                    Fracciones = row.Cells("Fracción_Arancelaria").Text.Substring(3)
                    row.Cells("Fracción_Arancelaria").Value = Fracciones
                End If
            End If

        Next
    End Sub

    Public Sub RecuperarFraccionesArancelariasDelProducto()
        Dim objNegocios As New Negocios.ProductosBU

        For Each ROW As UltraGridRow In grdDetallesEstilos.Rows
            Dim dtFraccion As New DataTable
            Dim objFraccionDetalle As New Entidades.Fracciones_Arancelarias_Detalles

            objFraccionDetalle.PFamiliaId = ROW.Cells("IdFamilia").Value
            objFraccionDetalle.PSuelaId = ROW.Cells("IdSuela").Value
            objFraccionDetalle.PForroId = ROW.Cells("IdForro").Value
            objFraccionDetalle.PPielMuestraId = ROW.Cells("IdCorte").Value
            objFraccionDetalle.PTipoCategoriaId = 0 ' CInt(txtCategoria.Text)

            dtFraccion = objNegocios.Recuperar_Fracciones_Arancelarias_De_Prodcto(objFraccionDetalle, ROW.Cells("IdTalla").Text)

            If dtFraccion.Rows.Count > 0 Then
                ROW.Cells("Fracción_Arancelaria").Value = dtFraccion.Rows(0).Item(0)
            End If

        Next
    End Sub

    Public Sub estiloGrdDetalle()
        With grdDetallesEstilos.DisplayLayout.Bands(0)
            If .Columns.Exists("Fracción_Arancelaria") Then
                grdDetallesEstilos.DisplayLayout.Bands(0).Columns("Fracción_Arancelaria").Header.Caption = "Fracción Arancelaria"
                .Columns("Fracción_Arancelaria").CellActivation = Activation.NoEdit
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                '.Columns("Fracción_Arancelaria").Width = 200
                .Columns("Fracción_Arancelaria").Width = 160
            End If

            .Columns("pielColor").Header.Caption = "Piel Color"
            .Columns("familia").Header.Caption = "Familia"
            .Columns("linea").Header.Caption = "Linea"
            .Columns("talla").Header.Caption = "Corrida"
            .Columns("corte").Header.Caption = "Corte"
            .Columns("forro").Header.Caption = "Forro"
            .Columns("suela").Header.Caption = "Suela"
            .Columns("idLinea").Header.Caption = "Linea"
            .Columns("idCorte").Header.Caption = "Corte"
            .Columns("idForro").Header.Caption = "Forro"
            .Columns("idSuela").Header.Caption = "Suela"

            'Modificación
            ' .Columns("suelacolor").Header.Caption = "Suela Color"
            .Columns("familia").Hidden = True
            '  .Columns("linea").Hidden = True
            '    .Columns("Sicy").Hidden = True
            .Columns("Fracción_Arancelaria").Hidden = True
            .Columns("idlinea").Hidden = True

            .Columns("Horma").Header.Caption = "Horma"
            .Columns("Sicy").Header.Caption = "Sicy"
            .Columns("idClaveSAT").Header.Caption = "Clave SAT"
            .Columns("familia ventas").Header.Caption = "Familia de Ventas"
            .Columns("idFamiliaVentas").Header.Caption = "Familia de Ventas"
            .Columns("familia ventas").Hidden = True
            .Columns("ArticuloNuevo").Header.Caption = "Nuevo"
            .Columns("ArticuloNuevo").Hidden = True
            .Columns("ArticuloNuevo").CellActivation = Activation.NoEdit
            .Columns("seleccion").Header.Caption = "Selección"
            .Columns("seleccion").Hidden = True
            .Columns("idPiel").Hidden = True
            .Columns("idColor").Hidden = True
            .Columns("idFamilia").Hidden = True
            '.Columns("idFamiliaVentas").Hidden = True
            .Columns("idTalla").Hidden = True

            '      .Columns("linea").Hidden = True
            .Columns("corte").Hidden = True
            .Columns("forro").Hidden = True
            .Columns("suela").Hidden = True


            .Columns("idHorma").Hidden = True
            .Columns("sicyPCOL").Hidden = True
            .Columns("IdMarcaCasa").Hidden = True
            .Columns("EstatusDes").Header.Caption = "Estatus"
            .Columns("idEstatus").Hidden = True
            .Columns("EstatusDes").CellActivation = Activation.NoEdit
            .Columns("pielColor").CellActivation = Activation.NoEdit
            .Columns("familia").CellActivation = Activation.NoEdit
            .Columns("linea").CellActivation = Activation.NoEdit
            .Columns("talla").CellActivation = Activation.NoEdit
            .Columns("corte").CellActivation = Activation.NoEdit
            .Columns("forro").CellActivation = Activation.NoEdit
            .Columns("suela").CellActivation = Activation.NoEdit
            .Columns("Horma").CellActivation = Activation.NoEdit
            .Columns("Sicy").CellActivation = Activation.NoEdit
            .Columns("idClaveSAT").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("idClaveSAT").Style = ColumnStyle.DropDownList

            .Columns("idClaveSAT").Width = 90

            .Columns("SuelaProgramacionID").Hidden = False
            .Columns("SuelaProgramacion").Hidden = True
            .Columns("ColorSuelaID").Hidden = True
            .Columns("ColorSuela").Hidden = True


            '.Columns("SuelaProgramacionID").CellActivation = Activation.NoEdit
            '.Columns("SuelaProgramacion").CellActivation = Activation.NoEdit
            '.Columns("ColorSuelaID").CellActivation = Activation.NoEdit
            '.Columns("ColorSuela").CellActivation = Activation.NoEdit


            .Columns("SuelaProgramacionID").Header.Caption = "SuelaProgramación"
            .Columns("SuelaProgramacion").Header.Caption = "Suela Programación"
            .Columns("ColorSuelaID").Header.Caption = "ColorSuela"
            .Columns("ColorSuela").Header.Caption = "Color Suela"

            'tablaDetalle.Columns.Add("SuelaProgramacionID", GetType(Int32))
            'tablaDetalle.Columns.Add("SuelaProgramacion", GetType(String))
            'tablaDetalle.Columns.Add("ColorSuelaID", GetType(Int32))
            'tablaDetalle.Columns.Add("ColorSuela", GetType(String))

        End With
        grdDetallesEstilos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub quitarSelecciones()
        For Each rowPiel As UltraGridRow In grdPieles.Rows
            rowPiel.Cells("selectPiel").Value = False
        Next
        For Each rowTalla As UltraGridRow In grdTalla.Rows
            rowTalla.Cells("selectTalla").Value = False
        Next
        For Each rowCorte As UltraGridRow In grdCorte.Rows
            rowCorte.Cells("selectCorte").Value = False
        Next
        For Each rowSuela As UltraGridRow In grdSuela.Rows
            rowSuela.Cells("selectSuela").Value = False
        Next



        For Each rowForro As UltraGridRow In grdForros.Rows
            rowForro.Cells("selectForro").Value = False
        Next
        For Each rowFamilia As UltraGridRow In grdFamilia.Rows
            rowFamilia.Cells("selectFamilia").Value = False
        Next
        For Each rowlinea As UltraGridRow In grdLinea.Rows
            rowlinea.Cells("selectLinea").Value = False
        Next
    End Sub

    Private Sub btnMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarca.Click
        Dim marcas As New MarcaFormRapido
        marcas.idcedis = idcedis
        marcas.ShowDialog()
        If (marcas.PIdMarca >= 0) Then
            idMarca = marcas.PIdMarca
            txtMarca.Text = marcas.PMarcaNombre
            estiloCliente = marcas.PesCliente
            codSicyMarca = marcas.PSicyMarca
            lblNombreMarca.Text = marcas.PEtiquetaM
            txtDescripcion.Text = lblNombreMarca.Text
            esLicencia = marcas.PesLicencia
            If idcedis = 82 And esLicencia = True Then
                txtCodigo.Text = marcas.PSicyMarca
                txtCodCliente.Text = txtMarca.Text
            Else
                txtCodigo.Text = marcas.PIdMarca
            End If

            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                rowEst.Cells("Sicy").Value = ""
                rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
            Next
        End If
        mostrarCamposCliente()
        txtMarca.Focus()
    End Sub


    Public Sub mostrarCamposCliente()
        If estiloCliente = True Then
            lblCodigoCliente.Visible = True
            lblMarcasCasa.Visible = True
            txtCodCliente.Visible = True
            cmbMarcasCasa.Visible = True
            esLicencia = False
        ElseIf idcedis = 82 And esLicencia = True Then
            txtCodCliente.Visible = True
            lblCodigoCliente.Visible = True
        Else
            lblCodigoCliente.Visible = False
            lblMarcasCasa.Visible = False
            txtCodCliente.Visible = False
            cmbMarcasCasa.Visible = False
            txtCodCliente.Text = String.Empty
            cmbMarcasCasa.SelectedIndex = 0
            esLicencia = False
        End If

        If txtMarca.Text = "1" Then
            lblMarcasCasa.Visible = False
            cmbMarcasCasa.Visible = False
        End If

        If txtMarca.Text = "6" Or txtMarca.Text = "7" Or txtMarca.Text = "8" Then
            lblModeloReferencia.Visible = True
            txtModeloReferencia.Visible = True
            btnModeloReferencia.Visible = True
        Else
            lblModeloReferencia.Visible = False
            txtModeloReferencia.Visible = False
            btnModeloReferencia.Visible = False
        End If

    End Sub

    Private Sub btnColeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColeccion.Click
        Dim ValidaMarca As New Programacion.Negocios.ColeccionBU
        Dim coleccion As New ColeccionFormRapido

        If (idMarca >= 0) Then
            coleccion.idMarca = idMarca
            coleccion.ShowDialog()
            If coleccion.PidColeccion <> 0 Then
                idColeccion = coleccion.PidColeccion
                codSicyColeccion = coleccion.PCodSicyCol
                lblNombreColeccion.Text = coleccion.PNombreColeccion + " " + coleccion.PAnio.ToString
                txtColeccion.Text = coleccion.PCodColeccion
                idFamiliaVentas = coleccion.idFamiliaProyeccion
                familiaVentas = coleccion.familiaProyeccion
                lblFamiliaVentas.Text = familiaVentas
                Dim datos As New DataTable
                datos = grdDetallesEstilos.DataSource
                If Not datos Is Nothing Then
                    For Each row As DataRow In datos.Rows
                        row("idFamiliaVentas") = idFamiliaVentas
                        row("familia ventas") = familiaVentas
                    Next
                    grdDetallesEstilos.DataSource = datos
                End If



                If (idColeccion <> 0) Then
                    Dim dtConsecutivo As DataTable = ValidaMarca.verConsecutivoCod(idMarca, idColeccion)
                    If (dtConsecutivo.Rows(0)(0).ToString = "") Then
                        consecutivo = "0"
                        If idcedis = 82 And esLicencia = True Then
                            txtCodigo.Text = txtCodigo.Text '+ txtColeccion.Text + consecutivo
                        Else
                            txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                            'txtDescripcion.Text = lblNombreMarca.Text + " " + coleccion.PNombreColeccion
                        End If
                        'txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                        txtDescripcion.Text = lblNombreMarca.Text + " " + coleccion.PNombreColeccion
                    Else
                        consecutivo = CStr(CInt(dtConsecutivo.Rows(0)(0).ToString) + 1)
                        If (CInt(consecutivo) <= 9) Then
                            If idcedis = 82 And esLicencia = True Then
                                txtCodigo.Text = txtCodigo.Text '+ txtColeccion.Text + consecutivo
                            Else
                                txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                            End If
                            'txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                            txtDescripcion.Text = lblNombreMarca.Text + " " + coleccion.PNombreColeccion

                        ElseIf (dtConsecutivo.Rows(0)(0).ToString = "False") Then
                            idColeccion = 0
                            codSicyColeccion = String.Empty
                            txtColeccion.Text = String.Empty
                            lblNombreColeccion.Text = ""
                            consecutivo = String.Empty
                            Dim advertenciaMensaje As New AdvertenciaForm
                            advertenciaMensaje.mensaje = "No hay mas consecutivo de la coleccion para asignar."
                            advertenciaMensaje.ShowDialog()
                        End If
                    End If
                Else
                    consecutivo = String.Empty
                    txtCodigo.Text = ""
                    txtDescripcion.Text = ""
                End If
            End If
        Else
            idColeccion = 0
            codSicyColeccion = String.Empty
            txtColeccion.Text = String.Empty
            lblNombreColeccion.Text = ""
            consecutivo = String.Empty
        End If
        txtColeccion.Focus()
    End Sub

    Public Function convertitConsecutivo(ByVal dato As String) As String
        Dim nuevoDato As String = String.Empty
        Dim entero As Int32 = 0
        If (dato <> "A" And dato <> "B" And dato <> "C" And dato <> "D" And dato <> "E" And dato <> "F" And
            dato <> "G" And dato <> "H" And dato <> "I" And dato <> "J" And dato <> "K" And dato <> "L" And dato <> "M" And
            dato <> "N" And dato <> "O" And dato <> "P" And dato <> "Q" And dato <> "R" And dato <> "S" And
            dato <> "T" And dato <> "U" And dato <> "W" And dato <> "X" And dato <> "Y" And dato <> "Z") Then
            entero = Convert.ToInt32(dato, 16)
        Else
            entero = 9
        End If


        If (entero >= 9) Then
            If (dato = "9") Then
                nuevoDato = "A"

            ElseIf (dato = "A") Then
                nuevoDato = "B"

            ElseIf (dato = "B") Then
                nuevoDato = "C"

            ElseIf (dato = "C") Then
                nuevoDato = "D"

            ElseIf (dato = "D") Then
                nuevoDato = "E"

            ElseIf (dato = "E") Then
                nuevoDato = "F"

            ElseIf (dato = "F") Then
                nuevoDato = "G"

            ElseIf (dato = "G") Then
                nuevoDato = "H"

            ElseIf (dato = "H") Then
                nuevoDato = "I"

            ElseIf (dato = "I") Then
                nuevoDato = "J"

            ElseIf (dato = "J") Then
                nuevoDato = "K"

            ElseIf (dato = "K") Then
                nuevoDato = "L"

            ElseIf (dato = "L") Then
                nuevoDato = "M"

            ElseIf (dato = "M") Then
                nuevoDato = "N"

            ElseIf (dato = "N") Then
                nuevoDato = "O"

            ElseIf (dato = "O") Then
                nuevoDato = "P"

            ElseIf (dato = "P") Then
                nuevoDato = "Q"

            ElseIf (dato = "Q") Then
                nuevoDato = "R"

            ElseIf (dato = "R") Then
                nuevoDato = "S"

            ElseIf (dato = "S") Then
                nuevoDato = "T"

            ElseIf (dato = "T") Then
                nuevoDato = "U"

            ElseIf (dato = "U") Then
                nuevoDato = "W"

            ElseIf (dato = "W") Then
                nuevoDato = "X"

            ElseIf (dato = "X") Then
                nuevoDato = "Y"

            ElseIf (dato = "Y") Then
                nuevoDato = "Z"

            ElseIf (dato = "Z") Then
                nuevoDato = "FALSE"
            End If
        ElseIf (entero < 9) Then
            entero = entero + 1
            nuevoDato = entero
        End If
        Return nuevoDato
    End Function

    Public Sub validacionesGuardar()

        Dim objProd As New Programacion.Negocios.ProductosBU
        'Dim dtExisteMarca As DataTable
        'Dim dtExisteColeccion As DataTable
        Dim dtCodRegistrado As New DataTable
        Dim codNuevoRegistroReal As String = String.Empty
        Dim idProductoRegistrado As Int32 = 0
        Dim estatusPres As Int32 = 0

        Try
            estatusPres = CInt(cmbEstatus.SelectedValue)
        Catch ex As Exception
            estatusPres = 0
        End Try

        If (idMarca >= 0 And idColeccion <> 0 And idTemporada <> 0 And idHorma <> 0 And consecutivo <> Nothing And estatusPres <> 0 And idCategoria <> 0 And txtCodSicy.Text <> "") Then
            ' If idSubFamilia <> 0 Or dtSubfamiliasSeleccionadas IsNot Nothing Then
            'If (validarDetalle() = True) Then
            If (validaExisteProducto() = True) Then
                If validarClaveSAT() = True Then
                    If validarMarcaCasa() = True Then
                        'If validarCodigoSicy() = True Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "¿Está seguro de guardar cambios?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim recorre As Int32 = 0
                            Dim EnProducto As New Entidades.Productos
                            Dim codSicyProd As String = ""
                            Dim modelo As String = txtCodSicy.Text

                            GenerarCadenaImagenes()
                            'GenerarCodigoSicyEstilos()

                            EnProducto.PDescripcionProd = txtDescripcion.Text.Trim
                            EnProducto.PMarcaProd = idMarca
                            EnProducto.PColeccionProd = idColeccion
                            EnProducto.PTemporadaProd = idTemporada
                            EnProducto.PFoto = cadenaFoto
                            EnProducto.PDibujo = cadenaDibujo
                            'EnProducto.PGrupoProd = idGrupo
                            EnProducto.PGrupoProd = 0

                            EnProducto.PCodCliente = txtCodCliente.Text

                            'EnProducto.PCodCliente = txtCodCliente.Text
                            EnProducto.PCategoria = idCategoria
                            EnProducto.PActivoProd = CBool(rdoActivo.Checked)
                            EnProducto.idNaveDesarrolla = idNaveDesarrolla
                            EnProducto.PmodeloSAYLicencia = txtCodigo.Text

                            'solo hay que descomentar lo que inserta actualiza etc
                            Dim cola = IIf(cmbMarcasCasa.SelectedIndex <> 0, cmbMarcasCasa.SelectedValue, "")
                            objProd.RegistrarProducto(EnProducto, modelo, idcedis, esLicencia, cola)

                            dtCodRegistrado = objProd.verCodigoProductoRegistrado(idMarca, idColeccion)
                            codNuevoRegistroReal = dtCodRegistrado.Rows(0)("prod_codigo").ToString
                            idProductoRegistrado = CInt(dtCodRegistrado.Rows(0)("prod_productoid").ToString)

                            If idSubFamilia <> 0 Then
                                objProd.guardarProductoSubfamilia(idProductoRegistrado, idSubFamilia)
                            ElseIf dtSubfamiliasSeleccionadas IsNot Nothing Then
                                For Each rowDTS As DataRow In dtSubfamiliasSeleccionadas.Rows
                                    objProd.guardarProductoSubfamilia(idProductoRegistrado, rowDTS.Item("idSubFamilia").ToString)
                                Next
                            End If

                            For Each rowDetalle As UltraGridRow In grdDetallesEstilos.Rows
                                Dim piel As String = rowDetalle.Cells("idPiel").Value.ToString
                                Dim familia As String = rowDetalle.Cells("idFamilia").Value.ToString
                                Dim familiaVentas As String = rowDetalle.Cells("idFamiliaVentas").Column.ValueList.GetValue(rowDetalle.Cells("idFamiliaVentas").Value.ToString, 0)  'rowDetalle.Cells("idFamiliaVentas").Value.ToString
                                Dim talla As String = rowDetalle.Cells("idTalla").Value.ToString
                                Dim color As String = rowDetalle.Cells("idColor").Value.ToString
                                Dim forro As String = rowDetalle.Cells("idForro").Column.ValueList.GetValue(rowDetalle.Cells("idForro").Value.ToString, 0)
                                Dim suela As String = rowDetalle.Cells("idSuela").Column.ValueList.GetValue(rowDetalle.Cells("idSuela").Value.ToString, 0)

                                Dim corte As String = rowDetalle.Cells("idCorte").Column.ValueList.GetValue(rowDetalle.Cells("idCorte").Value.ToString, 0)
                                Dim horma As String = rowDetalle.Cells("idHorma").Value.ToString
                                Dim sicyMarca As String = rowDetalle.Cells("IdMarcaCasa").Value.ToString
                                Dim Lineaid As Int32 = rowDetalle.Cells("idLinea").Column.ValueList.GetValue(rowDetalle.Cells("idLinea").Value.ToString, 0)
                                Dim idClaveSAT As String = rowDetalle.Cells("idClaveSAT").Column.ValueList.GetValue(rowDetalle.Cells("idClaveSAT").Value.ToString, 0)
                                Dim SuelaProgramacionID As Integer = rowDetalle.Cells("SuelaProgramacionID").Value().ToString
                                Dim ColorSuelaID As Integer = rowDetalle.Cells("ColorSuelaID").Value().ToString

                                Dim Modeloreferencia As String = txtModeloReferencia.Text

                                If (rowDetalle.Cells("Sicy").Value.ToString <> Nothing) Then
                                    codSicyProd = rowDetalle.Cells("Sicy").Value.ToString

                                End If


                                'Modificación
                                objProd.RegistrarDetalleProducto(piel, familia, talla, color, corte, forro, suela, codSicyProd, True, horma, sicyMarca, idProductoRegistrado, estatusPres, Lineaid, familiaVentas, idClaveSAT, SuelaProgramacionID, ColorSuelaID, Modeloreferencia)
                                recorre = recorre + 1
                            Next
                            registrarImagenesFTP()
                            If (codNuevoRegistroReal <> txtCodigo.Text) Then
                                exitoMensaje.mensaje = "Se registró exitosamente el producto: " + txtDescripcion.Text + " Con el código: " + codNuevoRegistroReal
                            Else
                                exitoMensaje.mensaje = "El registro se realizó con éxito."
                            End If
                            cerrarGuardar = True
                            exitoMensaje.ShowDialog()
                            Me.Close()

                        Else
                            Exit Sub
                        End If
                        'Else
                        '    Dim advertenciaMensaje As New AdvertenciaForm
                        '    advertenciaMensaje.mensaje = "Hace falta asignar Código Sicy a algún registro."
                        '    advertenciaMensaje.ShowDialog()
                        'End If

                    Else
                        Dim advertenciaMensaje As New AdvertenciaForm
                        advertenciaMensaje.mensaje = "Debe seleccionar una marca cliente."
                        advertenciaMensaje.ShowDialog()
                    End If
                Else
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "Hace falta asignar la Clave SAT a algún registro."
                    advertenciaMensaje.ShowDialog()
                End If
            ElseIf (validaExisteProducto() = False) Then
                Dim advMensaje As New AdvertenciaForm
                advMensaje.mensaje = "El código " + txtCodigo.Text.Trim + " esta siendo usado por otro producto activo."
                advMensaje.ShowDialog()
            End If
            ' ''ElseIf (validarDetalle() = False) Then
            ' ''    Dim advDMensaje As New AdvertenciaForm
            ' ''    advDMensaje.mensaje = "Debe seleccionar al menos un detalle de producto."
            ' ''    advDMensaje.ShowDialog()
            ' ''End If
            'Else
            '    Dim advertenciaMensaje As New AdvertenciaForm
            '    advertenciaMensaje.mensaje = "Debe generar todos los datos obligatorios."
            '    advertenciaMensaje.ShowDialog()
            'End If
            'Else
            '    Dim advertenciaMensaje As New AdvertenciaForm
            '    advertenciaMensaje.mensaje = "Faltan de capturar campos obligatorios."
            '    advertenciaMensaje.ShowDialog()
            'End If
        ElseIf (validarVacio() = False) Then
            Dim advertenciaMensaje As New AdvertenciaForm
            advertenciaMensaje.mensaje = "Faltan de capturar campos obligatorios."
            advertenciaMensaje.ShowDialog()
        End If
    End Sub

    Public Function validarDetalle() As Boolean
        contadorValida = 0
        Dim recorre As Int32 = 0
        For Each row As UltraGridRow In grdDetallesEstilos.Rows
            If (grdDetallesEstilos.Rows(recorre).Cells("seleccion").Value = False) Then
                contadorValida = contadorValida + 1
            End If
            recorre = recorre + 1
        Next
        If (contadorValida <= 0) Then
            Return False
        End If
        Return True
    End Function

    Public Function validarVacio() As Boolean
        If (txtCodigo.Text = Nothing Or txtColeccion.Text = Nothing Or txtDescripcion.Text = Nothing Or txtMarca.Text = Nothing Or
            txtSubFamilia.Text = Nothing Or txtHorma.Text = Nothing) Then

            If (txtCodigo.Text = Nothing) Then
                lblCodigo.ForeColor = Drawing.Color.Red
            Else
                lblCodigo.ForeColor = Drawing.Color.Black
            End If
            If (txtColeccion.Text = Nothing) Then
                lblColeccion.ForeColor = Drawing.Color.Red
            Else
                lblColeccion.ForeColor = Drawing.Color.Black
            End If
            If (txtDescripcion.Text = Nothing) Then
                lblDescripcion.ForeColor = Drawing.Color.Red
            Else
                lblDescripcion.ForeColor = Drawing.Color.Black
            End If
            If (txtMarca.Text = Nothing) Then
                lblMarca.ForeColor = Drawing.Color.Red
            Else
                lblMarca.ForeColor = Drawing.Color.Black
            End If
            If (txtSubFamilia.Text = Nothing) Then
                lblSubFamilia.ForeColor = Drawing.Color.Red
            Else
                lblSubFamilia.ForeColor = Drawing.Color.Black
            End If
            ' ''If (txtTemporadaO.Text = Nothing) Then
            ' ''    lblTemporada.ForeColor = Drawing.Color.Red
            ' ''Else
            ' ''    lblTemporada.ForeColor = Drawing.Color.Black
            ' ''End If
            If (txtHorma.Text = Nothing) Then
                lblHorma.ForeColor = Color.Red
            Else
                lblHorma.ForeColor = Color.Black
            End If

            If (txtGrupo.Text = Nothing) Then
                lblGrupo.ForeColor = Color.Red
            Else
                lblGrupo.ForeColor = Color.Black
            End If

            Return False
        Else
            lblCodigo.ForeColor = Drawing.Color.Black
            lblMarca.ForeColor = Drawing.Color.Black
            lblColeccion.ForeColor = Drawing.Color.Black
            lblDescripcion.ForeColor = Drawing.Color.Black
            lblSubFamilia.ForeColor = Drawing.Color.Black
            lblTemporada.ForeColor = Drawing.Color.Black
            lblHorma.ForeColor = Color.Black
            lblGrupo.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Sub quitarRegistrosDetalle()
        Dim recorre As Int32 = 0
        Dim x As Int32 = 0
        For x = (grdDetallesEstilos.Rows.Count - 1) To 0 Step -1
            If (Convert.ToBoolean(grdDetallesEstilos.Rows(x).Cells("seleccion").Value) = True) Then
                grdDetallesEstilos.Rows(x).Delete(True)
                If (nuevaFila >= 1) Then
                    nuevaFila = nuevaFila - 1
                End If
            End If
        Next
    End Sub

    Public Function validaExisteProducto() As Boolean
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtExisteProd As DataTable
        Dim codProd As String = txtCodigo.Text.Trim
        dtExisteProd = objPBU.validarExistenciaProducto(codProd)
        If (dtExisteProd.Rows.Count >= 1) Then
            Return False
        End If
        If (txtCodigo.Text.Trim = Nothing) Then
            Return False
        End If
        Return True
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        validacionesGuardar()
    End Sub

    Public Function validarClaveSAT() As Boolean
        For Each rowDetalle As UltraGridRow In grdDetallesEstilos.Rows
            If rowDetalle.Cells("idClaveSAT").Value().ToString() <> "" Then
            Else
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function

    Public Function validarCodigoSicy() As Boolean
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtValidaSicy As DataTable

        For Each rowDetalle As UltraGridRow In grdDetallesEstilos.Rows
            If rowDetalle.Cells("Sicy").Value().ToString() <> "" Then
                dtValidaSicy = objPBU.validaSicy(rowDetalle.Cells("Sicy").Value().ToString())
                If (CInt(dtValidaSicy.Rows(0)(0).ToString) > 0) Then
                Else
                    rowDetalle.Cells("Sicy").Value() = String.Empty
                    Return False
                    Exit Function
                End If
            Else
                Return False
                Exit Function
            End If
        Next
        Return True

        'For Each rowDetalle As UltraGridRow In grdDetallesEstilos.Rows
        '    If rowDetalle.Cells("Sicy").Value().ToString() <> "" Then
        '    Else
        '        Return False
        '        Exit Function
        '    End If
        'Next
        'Return True
    End Function
    Private Sub txtMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarca.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtMarca.Text.Length < 1) Then
            '
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtMarca.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
        consecutivo = String.Empty
    End Sub

    Private Sub txtMarca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarca.LostFocus
        Dim ValidaExistencias As New Programacion.Negocios.ProductosBU
        Dim dtExisteMarca As New DataTable
        If (idMarca = 0) Then
            If (txtMarca.Text <> "") Then
                dtExisteMarca = ValidaExistencias.validarExistenciaMarca(txtMarca.Text)
                If (dtExisteMarca.Rows.Count >= 1) Then

                    idMarca = CInt(dtExisteMarca.Rows(0)("marc_marcaid").ToString)
                    estiloCliente = CBool(dtExisteMarca.Rows(0)("marc_esCliente").ToString)
                    codSicyMarca = dtExisteMarca.Rows(0)("marc_codigosicy").ToString
                    lblNombreMarca.Text = dtExisteMarca.Rows(0)("marc_descripcion").ToString
                    lblNombreColeccion.Text = ""
                Else
                    idMarca = -1
                    idColeccion = 0
                    estiloCliente = False
                    codSicyMarca = String.Empty
                    txtMarca.Text = String.Empty
                    txtColeccion.Text = String.Empty
                    lblNombreMarca.Text = ""
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La marca que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If
            Else
                idMarca = -1
                idColeccion = 0
                estiloCliente = False
                codSicyMarca = String.Empty
                txtMarca.Text = String.Empty
                txtColeccion.Text = String.Empty
                lblNombreMarca.Text = ""
            End If
            idColeccion = 0
            codSicyColeccion = String.Empty
            txtColeccion.Text = String.Empty
            txtCodSicy.Text = String.Empty
            lblNombreColeccion.Text = ""

            txtCodigo.Text = txtMarca.Text
            txtDescripcion.Text = lblNombreMarca.Text
            If (estiloCliente = True) Then
                quitarSelecciones()
            End If
            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                rowEst.Cells("Sicy").Value = ""
                rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
            Next
            mostrarCamposCliente()
            cmbMarcasCasa.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtMarca_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarca.TextChanged
        idColeccion = 0
        idMarca = -1
        txtCodSicy.Text = String.Empty
        Dim ValidaExistencias As New Programacion.Negocios.ProductosBU
        Dim dtExisteMarca As DataTable

        If (txtMarca.Text <> "") Then
            dtExisteMarca = ValidaExistencias.validarExistenciaMarca(txtMarca.Text)
            If (dtExisteMarca.Rows.Count >= 1) Then
                ',
                ',
                ',
                '

                idMarca = CInt(dtExisteMarca.Rows(0)("marc_marcaid").ToString)
                estiloCliente = CBool(dtExisteMarca.Rows(0)("marc_esCliente").ToString)
                codSicyMarca = dtExisteMarca.Rows(0)("marc_codigosicy").ToString
                lblNombreMarca.Text = dtExisteMarca.Rows(0)("marc_descripcion").ToString
                lblNombreColeccion.Text = ""
            Else
                idMarca = -1
                idColeccion = 0
                estiloCliente = False
                codSicyMarca = String.Empty
                txtMarca.Text = String.Empty
                txtColeccion.Text = String.Empty
                lblNombreMarca.Text = ""
                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "La marca que ingreso no existe."
                advertenciaMensaje.ShowDialog()
            End If
        Else
            idMarca = -1
            idColeccion = 0
            estiloCliente = False
            codSicyMarca = String.Empty
            txtMarca.Text = String.Empty
            txtColeccion.Text = String.Empty
            lblNombreMarca.Text = ""
        End If
        idColeccion = 0
        codSicyColeccion = String.Empty
        txtColeccion.Text = String.Empty
        txtCodSicy.Text = String.Empty
        lblNombreColeccion.Text = ""

        txtCodigo.Text = txtMarca.Text
        txtDescripcion.Text = lblNombreMarca.Text
        If (estiloCliente = True) Then
            quitarSelecciones()
        End If
        For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            rowEst.Cells("Sicy").Value = ""
            rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
        Next
        mostrarCamposCliente()
        cmbMarcasCasa.SelectedIndex = 0
    End Sub

    Private Sub txtColeccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColeccion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtColeccion.Text.Length < 3) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtColeccion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtColeccion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColeccion.LostFocus
        Dim ValidaExistencias As New Programacion.Negocios.ColeccionBU
        Dim dtExisteColeccion As DataTable

        If (txtColeccion.Text <> "" And idColeccion = 0 And idMarca >= 0) Then
            dtExisteColeccion = ValidaExistencias.validarExistenciaColeccion(txtColeccion.Text, idMarca, idColeccion)

            If (dtExisteColeccion.Rows.Count >= 1) Then

                idColeccion = CInt(dtExisteColeccion.Rows(0)("coma_coleccionid").ToString)
                codSicyColeccion = dtExisteColeccion.Rows(0)("coma_codigosicy").ToString
                lblNombreColeccion.Text = dtExisteColeccion.Rows(0)("cole_descripcion").ToString + " " + dtExisteColeccion.Rows(0)("cole_Anio").ToString

                If idColeccion <> 0 Then
                    Dim dtConsecutivo As DataTable = ValidaExistencias.verConsecutivoCod(idMarca, idColeccion)
                    If (dtConsecutivo.Rows(0)(0).ToString = "") Then
                        consecutivo = "0"
                        txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                        txtDescripcion.Text = lblNombreMarca.Text + " " + dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                    Else
                        consecutivo = CStr(CInt(dtConsecutivo.Rows(0)(0).ToString) + 1)
                        If (CInt(consecutivo) <= 9) Then
                            txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                            txtDescripcion.Text = lblNombreMarca.Text + " " + dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                        ElseIf (CInt(consecutivo) > 9) Then
                            idColeccion = 0
                            txtColeccion.Text = String.Empty
                            consecutivo = String.Empty
                            lblNombreColeccion.Text = ""
                            Dim advertenciaMensaje As New AdvertenciaForm
                            advertenciaMensaje.mensaje = "No hay mas consecutivo de la coleccion para asignar."
                            advertenciaMensaje.ShowDialog()
                        End If
                    End If
                Else
                    idColeccion = 0
                    txtColeccion.Text = String.Empty
                    consecutivo = String.Empty
                    lblNombreColeccion.Text = ""
                    txtCodigo.Text = txtMarca.Text
                    txtDescripcion.Text = lblNombreMarca.Text
                End If
            Else
                consecutivo = String.Empty
                txtColeccion.Text = String.Empty
                lblNombreColeccion.Text = ""
                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "La colección que ingreso no existe."
                advertenciaMensaje.ShowDialog()
            End If
        ElseIf idColeccion = 0 Or idMarca < -1 Then
            idColeccion = 0
            txtColeccion.Text = String.Empty
            consecutivo = String.Empty
            lblNombreColeccion.Text = ""
            txtCodigo.Text = txtMarca.Text
            txtDescripcion.Text = lblNombreMarca.Text
        End If
    End Sub

    Private Sub txtColeccion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColeccion.TextChanged
        'idColeccion = 0
        codSicyColeccion = String.Empty
        consecutivo = String.Empty
        lblNombreColeccion.Text = ""
        txtCodSicy.Text = ""
        txtDescripcion.Text = lblNombreMarca.Text

        If (txtColeccion.TextLength = 3) Then

            Dim objColeBu As New Programacion.Negocios.ColeccionBU
            Dim objTemporada As New Negocios.TemporadasBU
            Dim dtExisteColeccion As DataTable

            'If idColeccion = 0 Then
            If (txtColeccion.Text <> "" And idMarca >= 0) Then
                dtExisteColeccion = objColeBu.validarExistenciaColeccion(txtColeccion.Text, idMarca, idColeccion)

                If (dtExisteColeccion.Rows.Count >= 1) Then
                    idColeccion = CInt(dtExisteColeccion.Rows(0)("coma_coleccionid").ToString)
                    codSicyColeccion = dtExisteColeccion.Rows(0)("coma_codigosicy").ToString
                    anioColeccion = dtExisteColeccion.Rows(0)("cole_Anio").ToString
                    lblNombreColeccion.Text = dtExisteColeccion.Rows(0)("cole_descripcion").ToString + " " + dtExisteColeccion.Rows(0)("cole_Anio").ToString
                    Dim dtTemporada As New DataTable
                    dtTemporada = objTemporada.VerTemporadaRegistroRapido(dtExisteColeccion.Rows(0)("cole_temporadaid").ToString)

                    lblNombreTemporada.Text = dtTemporada.Rows(0).Item("temp_nombre").ToString
                    idTemporada = CInt(dtTemporada.Rows(0).Item("temp_temporadaid").ToString)

                    If idColeccion <> 0 Then
                        Dim dtConsecutivo As DataTable = objColeBu.verConsecutivoCod(idMarca, idColeccion)
                        If (dtConsecutivo.Rows(0)(0).ToString = "") Then
                            consecutivo = "0"
                            If idcedis = 82 And esLicencia = True Then
                                txtCodigo.Text = codSicyMarca + txtColeccion.Text + consecutivo
                                txtCodCliente.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                            Else
                                txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                            End If

                            txtDescripcion.Text = lblNombreMarca.Text + " " + dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                        Else

                            consecutivo = CStr(CInt(dtConsecutivo.Rows(0)(0).ToString) + 1)
                            If (CInt(consecutivo) <= 9) Then
                                If idcedis = 82 And esLicencia = True Then
                                    txtCodigo.Text = codSicyMarca + txtColeccion.Text + consecutivo
                                    txtCodCliente.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                                Else
                                    txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                                    txtDescripcion.Text = lblNombreMarca.Text + " " + dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                                End If

                            ElseIf (CInt(consecutivo) > 9) Then
                                Dim dtConsecutivosTodos As New DataTable
                                Dim existeCero As Boolean = False
                                dtConsecutivosTodos = objColeBu.consultarConsecutivos(idMarca, idColeccion)
                                For Each rowCs As DataRow In dtConsecutivosTodos.Rows
                                    If rowCs.Item("prod_consecutivo").ToString = "0" Then
                                        existeCero = True
                                    End If
                                Next

                                If existeCero = True Then
                                    idColeccion = 0
                                    txtColeccion.Text = String.Empty
                                    consecutivo = String.Empty
                                    lblNombreColeccion.Text = ""
                                    Dim advertenciaMensaje As New AdvertenciaForm
                                    advertenciaMensaje.mensaje = "No hay mas consecutivo de la coleccion para asignar."
                                    advertenciaMensaje.ShowDialog()
                                Else
                                    consecutivo = "0"
                                    If idcedis = 82 And esLicencia = True Then
                                        txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                                        txtDescripcion.Text = lblNombreMarca.Text + " " + dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                                    Else
                                        txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                                        txtDescripcion.Text = lblNombreMarca.Text + " " + dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                                    End If

                                End If


                            End If

                        End If
                    Else
                        idColeccion = 0
                        txtColeccion.Text = String.Empty
                        consecutivo = String.Empty
                        lblNombreColeccion.Text = ""
                        txtCodigo.Text = txtMarca.Text
                        txtDescripcion.Text = lblNombreMarca.Text
                    End If
                Else
                    idColeccion = 0
                    txtColeccion.Text = String.Empty
                    consecutivo = String.Empty
                    lblNombreColeccion.Text = ""
                    txtCodigo.Text = txtMarca.Text
                    txtDescripcion.Text = lblNombreMarca.Text
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La colección que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If
            Else
                idColeccion = 0
                txtColeccion.Text = String.Empty
                consecutivo = String.Empty
                lblNombreColeccion.Text = ""
                txtCodigo.Text = txtMarca.Text
                txtDescripcion.Text = lblNombreMarca.Text
            End If
            'End If
            If (txtMarca.Text = Nothing) Then
                idColeccion = 0
                txtColeccion.Text = String.Empty
                consecutivo = String.Empty
                lblNombreColeccion.Text = ""
                txtCodigo.Text = txtMarca.Text
                txtDescripcion.Text = lblNombreMarca.Text
            End If
        Else
            lblNombreTemporada.Text = ""
            idTemporada = 0
            txtCodigo.Text = txtMarca.Text
            txtDescripcion.Text = lblNombreMarca.Text + " "
        End If
    End Sub

    Private Sub txtCategoria_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCategoria.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCategoria.Text.Length < 3) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCategoria.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        quitarRegistrosDetalle()
    End Sub

    ''Private Sub btnTemporada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemporadaO.Click, btnTemporada.Click
    ''    Dim temporada As New temporadaFormRapido
    ''    temporada.ShowDialog()
    ''    If (temporada.PidTemporada <> Nothing) Then
    ''        idTemporada = temporada.PidTemporada
    ''        txtTemporadaO.Text = temporada.PCodTemporada
    ''        lblNombreTemporada.Text = temporada.PNombreTemporada
    ''    End If
    ''    txtTemporadaO.Focus()
    ''End Sub

    ''Private Sub txtTemporada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTemporadaO.KeyPress
    ''    Dim caracter As Char = e.KeyChar
    ''    If (txtTemporadaO.Text.Length < 2) Then

    ''        If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
    ''            e.Handled = False
    ''        Else
    ''            e.Handled = True
    ''        End If

    ''        If Char.IsLower(e.KeyChar) Then
    ''            txtTemporadaO.SelectedText = Char.ToUpper(e.KeyChar)
    ''            e.Handled = True
    ''        End If
    ''    Else
    ''        If e.KeyChar <> vbBack Then
    ''            e.Handled = True
    ''        End If
    ''    End If
    ''End Sub

    ''Private Sub txtTemporada_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemporadaO.LostFocus
    ''    'Dim objCole As New Programacion.Negocios.ColeccionBU
    ''    'Dim objProd As New Programacion.Negocios.ProductosBU
    ''    'If (idTemporada = 0) Then
    ''    '    If (txtTemporada.Text <> Nothing) Then
    ''    '        Dim dtValidaExisteTemporada As DataTable
    ''    '        dtValidaExisteTemporada = objProd.validarExistenciaTemporada(txtTemporada.Text)
    ''    '        If (dtValidaExisteTemporada.Rows.Count >= 1) Then
    ''    '            idTemporada = CInt(dtValidaExisteTemporada.Rows(0)(0).ToString)
    ''    '            lblNombreTemporada.Text = dtValidaExisteTemporada.Rows(0)(1).ToString
    ''    '            'anio = dtValidaExisteTemporada.Rows(0)(2).ToString
    ''    '            'digitoAnio = ultimoDigitoAnio(anio)


    ''    '            If (idMarca <> 0 And idColeccion <> 0 And digitoAnio <> Nothing) Then
    ''    '                Dim dtConsecutivo As DataTable = objCole.verConsecutivoCod(idMarca, idColeccion, digitoAnio)
    ''    '                If (dtConsecutivo.Rows(0)(0).ToString = Nothing) Then
    ''    '                    consecutivo = "1"
    ''    '                Else
    ''    '                    If (dtConsecutivo.Rows(0)(0).ToString <> "False") Then
    ''    '                        consecutivo = convertitConsecutivo(dtConsecutivo.Rows(0)(0).ToString)
    ''    '                    ElseIf (dtConsecutivo.Rows(0)(0).ToString = "False") Then
    ''    '                        Dim advertenciaMensaje As New AdvertenciaForm

    ''    '                        idTemporada = 0
    ''    '                        anio = String.Empty
    ''    '                        digitoAnio = String.Empty
    ''    '                        txtTemporada.Text = String.Empty
    ''    '                        lblNombreTemporada.Text = ""

    ''    '                        consecutivo = String.Empty
    ''    '                        advertenciaMensaje.mensaje = "No hay mas consecutivo de la coleccion para asignar."
    ''    '                        advertenciaMensaje.ShowDialog()
    ''    '                    End If
    ''    '                End If
    ''    '            End If

    ''    '            txtCodigo.Text = txtMarca.Text + digitoAnio + txtColeccion.Text + consecutivo
    ''    '            txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
    ''    '            txtTemporada.Focus()
    ''    '        Else
    ''    '            idTemporada = 0
    ''    '            anio = String.Empty
    ''    '            digitoAnio = String.Empty
    ''    '            txtTemporada.Text = String.Empty
    ''    '            lblNombreTemporada.Text = ""
    ''    '            consecutivo = String.Empty

    ''    '            txtCodigo.Text = txtMarca.Text + digitoAnio + txtColeccion.Text + consecutivo
    ''    '            txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
    ''    '            Dim advertenciaMensaje As New AdvertenciaForm
    ''    '            advertenciaMensaje.mensaje = "La temporada que ingreso no existe."
    ''    '            advertenciaMensaje.ShowDialog()
    ''    '        End If
    ''    '    End If
    ''    'End If
    ''End Sub

    ''Private Sub txtTemporada_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemporadaO.TextChanged
    ''    'idTemporada = 0
    ''    'lblNombreTemporada.Text = ""
    ''    'Dim objProd As New Programacion.Negocios.ProductosBU

    ''    'If (idTemporada = 0) Then
    ''    '    If (txtTemporada.Text <> Nothing) Then
    ''    '        If (txtTemporada.TextLength = 2) Then
    ''    '            Dim dtValidaExisteTemporada As New DataTable
    ''    '            dtValidaExisteTemporada = objProd.validarExistenciaTemporada(txtTemporada.Text)
    ''    '            If (dtValidaExisteTemporada.Rows.Count >= 1) Then
    ''    '                idTemporada = CInt(dtValidaExisteTemporada.Rows(0)("temp_temporadaid").ToString)
    ''    '                lblNombreTemporada.Text = dtValidaExisteTemporada.Rows(0)("temp_nombre").ToString
    ''    '            Else
    ''    '                idTemporada = 0
    ''    '                txtTemporada.Text = String.Empty
    ''    '                lblNombreTemporada.Text = ""

    ''    '                Dim advertenciaMensaje As New AdvertenciaForm
    ''    '                advertenciaMensaje.mensaje = "La temporada que ingreso no existe."
    ''    '                advertenciaMensaje.ShowDialog()
    ''    '            End If
    ''    '        End If
    ''    '    Else
    ''    '        idTemporada = 0
    ''    '        txtTemporada.Text = String.Empty
    ''    '        lblNombreTemporada.Text = ""
    ''    '    End If
    ''    'End If
    ''End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ' ''Dim objAdvSalir As New ConfirmarForm
        ' ''objAdvSalir.mensaje = "¿Está seguro de salir SIN guardar los cambios?"
        ' ''If objAdvSalir.ShowDialog() = Windows.Forms.DialogResult.OK Then
        Me.Close()
        ' ''End If
    End Sub

    Private Sub btnSubFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubFamilia.Click
        Dim objSubfamilia As New SubfamiliaRapidoForm
        Dim dtDatosRapidosSubfamilia As DataTable
        Dim dtDatosEnviarSelectsSubf As New DataTable
        dtDatosEnviarSelectsSubf.Columns.Add("subf_Subfamiliaid")

        If idSubFamilia <> 0 Then
            dtDatosEnviarSelectsSubf.Rows.Add()
            dtDatosEnviarSelectsSubf.Rows(0)(0) = CStr(idSubFamilia)
        ElseIf Not dtSubfamiliasSeleccionadas Is Nothing Then
            Dim contRow As Int32 = 0
            For Each rowDTSF As DataRow In dtSubfamiliasSeleccionadas.Rows
                dtDatosEnviarSelectsSubf.Rows.Add()
                dtDatosEnviarSelectsSubf.Rows(contRow)(0) = rowDTSF.Item("idSubfamilia").ToString
                contRow = contRow + 1
            Next
        End If
        objSubfamilia.datosPreviosSeleccion = dtDatosEnviarSelectsSubf
        objSubfamilia.ShowDialog()

        dtDatosRapidosSubfamilia = objSubfamilia.PDTSubfamilias
        If Not dtDatosRapidosSubfamilia Is Nothing Then
            If dtDatosRapidosSubfamilia.Rows.Count >= 1 Then
                idSubFamilia = 0
                dtSubfamiliasSeleccionadas = Nothing
                txtSubFamilia.Text = String.Empty
                lblNombreSubfamilia.Text = String.Empty
                Dim cadenaIds As String
                Dim cadenaSubfamilias As String
                cadenaIds = ""
                cadenaSubfamilias = ""

                If dtDatosRapidosSubfamilia.Rows.Count = 1 Then
                    txtSubFamilia.Text = dtDatosRapidosSubfamilia.Rows(0).Item("idSubFamilia").ToString
                    txtSubFamilia.Focus()
                ElseIf dtDatosRapidosSubfamilia.Rows.Count > 1 Then
                    Dim cadNombreExacto As String
                    Dim tamcad As Int32 = 0
                    dtSubfamiliasSeleccionadas = dtDatosRapidosSubfamilia
                    For Each dtRow As DataRow In dtDatosRapidosSubfamilia.Rows
                        cadenaIds += dtRow.Item("idSubFamilia").ToString + ", "
                        cadenaSubfamilias += dtRow.Item("subfamiliaNombre").ToString + ", "
                    Next
                    lblIdsSubfamilias.Text = cadenaIds
                    lblCodsSubfamilias.Text = cadenaIds
                    tamcad = Len(cadenaSubfamilias) - 2
                    cadNombreExacto = cadenaSubfamilias.Substring(0, tamcad)
                    lblNombreSubfamilia.Text = cadNombreExacto
                End If
            End If
        End If
    End Sub

    Private Sub txtSubFamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubFamilia.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtSubFamilia.Text.Length < 3) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtSubFamilia.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSubFamilia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubFamilia.LostFocus
        dtSubfamiliasSeleccionadas = Nothing
        Dim ValidaExistencias As New Programacion.Negocios.ProductosBU
        If (idSubFamilia = 0) Then
            If (txtSubFamilia.Text <> Nothing) Then
                Dim dtValidaExisteSubFamilia As DataTable
                dtValidaExisteSubFamilia = ValidaExistencias.validarExistenciaSubfamilia(txtSubFamilia.Text)
                If (dtValidaExisteSubFamilia.Rows.Count >= 1) Then
                    idSubFamilia = dtValidaExisteSubFamilia.Rows(0)(0).ToString
                    lblNombreSubfamilia.Text = dtValidaExisteSubFamilia.Rows(0)(1).ToString
                Else

                    txtSubFamilia.Text = String.Empty
                    idSubFamilia = 0
                    lblNombreSubfamilia.Text = ""
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La Subfamilia que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If
            Else
                lblNombreSubfamilia.Text = ""
            End If
        End If
    End Sub

    Private Sub txtCodSicy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodSicy.KeyDown
        If (e.KeyCode = Keys.Enter) Then

            If (codSicyMarca <> "" And codSicyColeccion <> "") Then

                GenerarCodigoSicyEstilos()

                'If (txtCodSicy.Text.Length > 0) Then

                '    Dim objProd As New Programacion.Negocios.ProductosBU
                '    Dim dtDatoContSicyRepetido As New DataTable
                '    Dim dtDatoContSicyExiste As New DataTable
                '    Dim dtSicyMarcaColeccion As New DataTable

                '    Dim contRepetido As Int32 = 0
                '    Dim contExiste As Int32 = 0
                '    Dim contSicyMarcColc As Int32 = 0

                '    dtDatoContSicyRepetido = objProd.validaSicyEnProducto(txtCodSicy.Text, "", idMarca, idColeccion)
                '    dtDatoContSicyExiste = objProd.validaExistenciaModeloSicy(txtCodSicy.Text)
                '    dtSicyMarcaColeccion = objProd.validaExisteSicyMarcaColeccion(txtCodSicy.Text, codSicyMarca, codSicyColeccion)

                '    contRepetido = CInt(dtDatoContSicyRepetido.Rows(0)(0).ToString)
                '    contExiste = CInt(dtDatoContSicyExiste.Rows(0)(0).ToString)
                '    contSicyMarcColc = CInt(dtSicyMarcaColeccion.Rows(0)(0).ToString)

                '    If (contRepetido >= 1) Then
                '        txtCodSicy.Text = String.Empty
                '        MsgBox("El modelo de sicy que ingreso ya se encuentra en otro registro.")
                '        For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                '            rowEst.Cells("Sicy").Value = ""
                '            rowEst.Cells("IdMarcaCasa").Value = ""
                '        Next
                '    Else
                '        If (contExiste = 0) Then
                '            txtCodSicy.Text = String.Empty
                '            MsgBox("El modelo de sicy que ingreso no existe.")
                '            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                '                rowEst.Cells("Sicy").Value = ""
                '                rowEst.Cells("IdMarcaCasa").Value = ""
                '            Next
                '        ElseIf (contSicyMarcColc = 0) Then
                '            txtCodSicy.Text = String.Empty
                '            MsgBox("El modelo sicy que ingreso no esta disponible en la marca y colección seleccionadas.")
                '            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                '                rowEst.Cells("Sicy").Value = ""
                '                rowEst.Cells("IdMarcaCasa").Value = ""
                '            Next
                '            'End If
                '        Else
                '            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                '                If (codSicyMarca <> "" And codSicyColeccion <> "" And rowEst.Cells("sicyPCOL").Value.ToString <> "" And txtCodSicy.Text <> "") Then
                '                    If (txtCodSicy.TextLength = 3) Then
                '                        rowEst.Cells("Sicy").Value = codSicyMarca + codSicyColeccion + "0" + txtCodSicy.Text + rowEst.Cells("sicyPCOL").Value.ToString
                '                        rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
                '                    Else
                '                        rowEst.Cells("Sicy").Value = codSicyMarca + codSicyColeccion + txtCodSicy.Text + rowEst.Cells("sicyPCOL").Value.ToString
                '                        rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
                '                    End If
                '                Else
                '                    rowEst.Cells("Sicy").Value = ""
                '                    rowEst.Cells("IdMarcaCasa").Value = ""
                '                End If
                '            Next
                '        End If
                '    End If
                'End If
            Else
                txtCodSicy.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub txtCodSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodSicy.Text.Length < 6) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodSicy.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.C And e.Modifiers = Keys.Control Then
            txtDescripcion.Copy()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress

        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 100) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or
                (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If

    End Sub

    'Private Sub btnDibujo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ofdDibujo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        Dim sr As New System.IO.StreamReader(ofdDibujo.FileName)
    '        picDibujo.Image = Image.FromFile(ofdDibujo.FileName)
    '        sr.Close()
    '    End If
    'End Sub

    Public Sub GenerarCadenaImagenes()
        If (ofdFoto.SafeFileName().ToString <> "ofdFoto") Then
            cadenaFoto = txtCodigo.Text + "/" + ofdFoto.SafeFileName()
        ElseIf (ofdFoto.SafeFileName.ToString = "ofdFoto") Then
            cadenaFoto = String.Empty
        End If

        If (ofdDibujo.SafeFileName().ToString <> "ofdDibujo") Then
            cadenaDibujo = ofdDibujo.SafeFileName()
        ElseIf (ofdDibujo.SafeFileName.ToString = "ofdDibujo") Then
            cadenaDibujo = String.Empty
        End If
    End Sub

    Public Sub registrarImagenesFTP()
        Try
            'Dim foto As New Tools.TransferenciaFTP("ftp://192.168.7.16", "prod\yuyinerp", "yuyinerp")
            Dim foto As New Tools.TransferenciaFTP

            If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
            ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
                foto.EnviarArchivo("Programacion/Modelos/" + txtCodigo.Text + "/", ofdFoto.FileName)
                foto.EnviarArchivo("Programacion/Modelos/" + txtCodigo.Text + "/", ofdFoto.FileName)
                foto.StreamFileThumbNail("Programacion/Modelos/" + codigoProducto + "/", ofdFoto.SafeFileName)
            End If
        Catch ex As Exception
            MsgBox("Sucedió algo inesperado, no se pudo subir la imagen.")
        End Try

        Try
            Dim fotoWeb As New Tools.TransferenciaFTP("ftp://www.grupoyuyin.com.mx/say", "yuyinerp", "Yuyin2014!")
            If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
            ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
                fotoWeb.EnviarArchivo("programacion/modelos/" + txtCodigo.Text + "/", ofdFoto.FileName)
                fotoWeb.EnviarArchivo("programacion/modelos/" + txtCodigo.Text + "/", ofdFoto.FileName)
                fotoWeb.StreamFileThumbNail("programacion/Modelos/" + codigoProducto + "/", ofdFoto.SafeFileName)
            End If
        Catch ex As Exception
            MsgBox("Sucedió algo inesperado, no se pudo subir la imagen a GrupoYuyin.com.")
        End Try
        Try
            'Dim fotoWeb As New Tools.TransferenciaFTP("ftp://50.63.89.1", "m4394882", "Asmlrl020907@")
            'Dim fotoWeb As New Tools.TransferenciaFTP("ftp://65.99.252.249", "ftpsay@grupoyuyin.com", "Sayweb2020")
            Dim fotoWeb As New Tools.TransferenciaFTP("ftp://192.168.2.158", "ftpaccess", "Yuyin2017""")

            If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
            ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
                fotoWeb.EnviarArchivo("programacion/modelos/" + codigoProducto + "/", ofdFoto.FileName)
                fotoWeb.EnviarArchivo("programacion/modelos/" + codigoProducto + "/", ofdFoto.FileName)
                fotoWeb.StreamFileThumbNail("programacion/modelos/" + codigoProducto + "/", ofdFoto.SafeFileName)
            End If
        Catch ex As Exception
            MsgBox("Sucedió algo inesperado, no se pudo subir la imagen a GrupoYuyin.com.")
        End Try

        ' ''If (ofdDibujo.SafeFileName().ToString = "ofdDibujo") Then
        ' ''ElseIf (ofdDibujo.SafeFileName.ToString <> "ofdDibujo") Then
        ' ''    foto.EnviarArchivo("Programacion/Modelos/" + txtCodigo.Text + "/", ofdDibujo.FileName)
        ' ''    foto.EnviarArchivo("Programacion/Modelos/" + txtCodigo.Text + "/", ofdDibujo.FileName)
        ' ''End If
    End Sub

    Private Sub btnAgregarDato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDato.Click

        If Not (idMarca < 0 Or idColeccion = 0 Or idHorma = 0 Or idTemporada = 0 Or txtCodSicy.Text = "") Then
            'If idSubFamilia <> 0 Or dtSubfamiliasSeleccionadas IsNot Nothing Then
            If Not ValidarPielColorSICY() Then Return
            If (estiloCliente = True) Then
                LlenarTablaDetallesEstilosProductoCliente()
            Else
                'ok
                LlenarTablaDetallesEstilosProducto()
            End If

            ' End If
        Else
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Faltan de capturar campos obligatorios."
            adv.ShowDialog()
        End If

    End Sub


    Private Function ValidarPielColorSICY() As Boolean

        Dim objProd As New Programacion.Negocios.ProductosBU
        Dim dtPielColor As DataTable

        For Each rowPiel As UltraGridRow In grdPieles.Rows
            If (rowPiel.Cells("selectPiel").Value = True) Then
                dtPielColor = objProd.ValidarPielColorSICY(rowPiel.Cells("pcsicy").Value)
                If dtPielColor.Rows.Count < 1 Then
                    Dim msg_adv As New Tools.AdvertenciaForm
                    msg_adv.mensaje = "La PIEL seleccionada no existe en SICY"
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub txtSubFamilia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubFamilia.TextChanged
        dtSubfamiliasSeleccionadas = Nothing
        idSubFamilia = 0
        Dim ValidaExistencias As New Programacion.Negocios.ProductosBU
        If (idSubFamilia = 0) Then
            If (txtSubFamilia.Text <> Nothing) Then
                Dim dtValidaExisteFamilia As DataTable
                dtValidaExisteFamilia = ValidaExistencias.validarExistenciaSubfamilia(txtSubFamilia.Text)
                If (dtValidaExisteFamilia.Rows.Count >= 1) Then
                    idSubFamilia = CInt(dtValidaExisteFamilia.Rows(0)(0).ToString)
                    lblNombreSubfamilia.Text = dtValidaExisteFamilia.Rows(0)(1).ToString
                Else
                    txtSubFamilia.Text = String.Empty
                    idSubFamilia = 0
                    lblNombreSubfamilia.Text = ""
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La Subfamilia que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If
            Else
                lblNombreSubfamilia.Text = ""
            End If
        End If
    End Sub

    Private Sub grdDetallesEstilos_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdDetallesEstilos.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        If MsgBox("¿Estás seguro de quitar la(s) fila(s) seleccionada(s)?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub grdForros_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdForros.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdPieles_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs)
        e.Cancel = True
    End Sub

    Private Sub grdSuela_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdSuela.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdTalla_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdTalla.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdCorte_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdCorte.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdPieles_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPieles.CellChange

        If (e.Cell.Column.Key = "selectPiel") Then
            If (estiloCliente = True) Then
                For Each rowP As UltraGridRow In grdPieles.Rows
                    rowP.Cells("selectPiel").Value = False
                Next
                e.Cell().Value = True
            End If
        End If
    End Sub

    Private Sub grdCorte_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCorte.CellChange
        If (e.Cell.Column.Key = "selectCorte") Then
            If (estiloCliente = True) Then
                For Each rowC As UltraGridRow In grdCorte.Rows
                    rowC.Cells("selectCorte").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdForros_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdForros.CellChange
        If (e.Cell.Column.Key = "selectForro") Then
            If (estiloCliente = True) Then
                For Each rowF As UltraGridRow In grdForros.Rows
                    rowF.Cells("selectForro").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdSuela_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdSuela.CellChange
        If (e.Cell.Column.Key = "selectSuela") Then
            If (estiloCliente = True) Then
                For Each rowS As UltraGridRow In grdSuela.Rows
                    rowS.Cells("selectSuela").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdTalla_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdTalla.CellChange
        If (e.Cell.Column.Key = "selectTalla") Then
            If (estiloCliente = True) Then
                For Each rowT As UltraGridRow In grdTalla.Rows
                    rowT.Cells("selectTalla").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdFamilia_CellChange(sender As Object, e As CellEventArgs) Handles grdFamilia.CellChange
        If (e.Cell.Column.Key = "selectFamilia") Then
            If (estiloCliente = True) Then
                For Each rowT As UltraGridRow In grdFamilia.Rows
                    rowT.Cells("selectFamilia").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdLinea_CellChange(sender As Object, e As CellEventArgs) Handles grdLinea.CellChange
        If (e.Cell.Column.Key = "selectLinea") Then
            If (estiloCliente = True) Then
                For Each rowT As UltraGridRow In grdLinea.Rows
                    rowT.Cells("selectLinea").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub GenerarCodigoSicyEstilos()
        If (txtCodSicy.Text.Length > 0) Then

            Dim objProd As New Programacion.Negocios.ProductosBU
            Dim dtDatoContSicyRepetido As New DataTable
            Dim dtDatoContSicyExiste As New DataTable
            Dim dtSicyMarcaColeccion As New DataTable

            Dim contRepetido As Int32 = 0
            Dim contExiste As Int32 = 0
            Dim contSicyMarcColc As Int32 = 0

            dtDatoContSicyRepetido = objProd.validaSicyEnProducto(txtCodSicy.Text, "", idMarca, idColeccion)
            dtDatoContSicyExiste = objProd.validaExistenciaModeloSicy(txtCodSicy.Text)
            dtSicyMarcaColeccion = objProd.validaExisteSicyMarcaColeccion(txtCodSicy.Text, codSicyMarca, codSicyColeccion)

            contRepetido = CInt(dtDatoContSicyRepetido.Rows(0)(0).ToString)
            contExiste = CInt(dtDatoContSicyExiste.Rows(0)(0).ToString)
            contSicyMarcColc = CInt(dtSicyMarcaColeccion.Rows(0)(0).ToString)

            If (contExiste = 0) Then
                txtCodSicy.Text = String.Empty
                MsgBox("El modelo de sicy que ingreso no existe.")
                For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                    rowEst.Cells("Sicy").Value = ""
                    rowEst.Cells("IdMarcaCasa").Value = ""
                Next
            Else
                If (contSicyMarcColc = 0) Then
                    txtCodSicy.Text = String.Empty
                    MsgBox("El modelo sicy que ingreso no esta disponible en la marca y colección seleccionadas.")
                    For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                        rowEst.Cells("Sicy").Value = ""
                        rowEst.Cells("IdMarcaCasa").Value = ""
                    Next
                ElseIf (contRepetido >= 1) Then
                    txtCodSicy.Text = String.Empty
                    MsgBox("El modelo de sicy que ingreso ya se encuentra en otro registro de la colección.")
                    For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                        rowEst.Cells("Sicy").Value = ""
                        rowEst.Cells("IdMarcaCasa").Value = ""
                    Next
                Else
                    For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                        If (codSicyMarca <> "" And codSicyColeccion <> "" And rowEst.Cells("sicyPCOL").Value.ToString <> "" And txtCodSicy.Text <> "") Then
                            If (txtCodSicy.TextLength = 3) Then
                                rowEst.Cells("Sicy").Value = codSicyMarca + codSicyColeccion + "0" + txtCodSicy.Text + rowEst.Cells("sicyPCOL").Value.ToString
                                rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
                            Else
                                rowEst.Cells("Sicy").Value = codSicyMarca + codSicyColeccion + txtCodSicy.Text + rowEst.Cells("sicyPCOL").Value.ToString
                                rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
                            End If
                        Else
                            rowEst.Cells("Sicy").Value = ""
                            rowEst.Cells("IdMarcaCasa").Value = ""
                        End If
                    Next
                End If

            End If
        Else
            Dim msg_adv As New Tools.AdvertenciaForm
            msg_adv.mensaje = "Falta de agregar codigo SICY"
        End If
    End Sub

    Private Sub txtCodSicy_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodSicy.LostFocus
        If (codSicyMarca <> "" And codSicyColeccion <> "") Then
            GenerarCodigoSicyEstilos()
            'If (txtCodSicy.Text.Length > 0) Then

            '    Dim objProd As New Programacion.Negocios.ProductosBU
            '    Dim dtDatoContSicyRepetido As New DataTable
            '    Dim dtDatoContSicyExiste As New DataTable
            '    Dim dtSicyMarcaColeccion As New DataTable

            '    Dim contRepetido As Int32 = 0
            '    Dim contExiste As Int32 = 0
            '    Dim contSicyMarcColc As Int32 = 0

            '    dtDatoContSicyRepetido = objProd.validaSicyEnProducto(txtCodSicy.Text, "", idMarca, idColeccion)
            '    dtDatoContSicyExiste = objProd.validaExistenciaModeloSicy(txtCodSicy.Text)
            '    dtSicyMarcaColeccion = objProd.validaExisteSicyMarcaColeccion(txtCodSicy.Text, codSicyMarca, codSicyColeccion)

            '    contRepetido = CInt(dtDatoContSicyRepetido.Rows(0)(0).ToString)
            '    contExiste = CInt(dtDatoContSicyExiste.Rows(0)(0).ToString)
            '    contSicyMarcColc = CInt(dtSicyMarcaColeccion.Rows(0)(0).ToString)

            '    If (contExiste = 0) Then
            '        txtCodSicy.Text = String.Empty
            '        MsgBox("El modelo de sicy que ingreso no existe.")
            '        For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            '            rowEst.Cells("Sicy").Value = ""
            '            rowEst.Cells("IdMarcaCasa").Value = ""
            '        Next
            '    Else
            '        If (contSicyMarcColc = 0) Then
            '            txtCodSicy.Text = String.Empty
            '            MsgBox("El modelo sicy que ingreso no esta disponible en la marca y colección seleccionadas.")
            '            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            '                rowEst.Cells("Sicy").Value = ""
            '                rowEst.Cells("IdMarcaCasa").Value = ""
            '            Next
            '        ElseIf (contRepetido >= 1) Then
            '            txtCodSicy.Text = String.Empty
            '            MsgBox("El modelo de sicy que ingreso ya se encuentra en otro registro de la colección.")
            '            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            '                rowEst.Cells("Sicy").Value = ""
            '                rowEst.Cells("IdMarcaCasa").Value = ""
            '            Next
            '        Else
            '            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            '                If (codSicyMarca <> "" And codSicyColeccion <> "" And rowEst.Cells("sicyPCOL").Value.ToString <> "" And txtCodSicy.Text <> "") Then
            '                    If (txtCodSicy.TextLength = 3) Then
            '                        rowEst.Cells("Sicy").Value = codSicyMarca + codSicyColeccion + "0" + txtCodSicy.Text + rowEst.Cells("sicyPCOL").Value.ToString
            '                        rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
            '                    Else
            '                        rowEst.Cells("Sicy").Value = codSicyMarca + codSicyColeccion + txtCodSicy.Text + rowEst.Cells("sicyPCOL").Value.ToString
            '                        rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
            '                    End If
            '                Else
            '                    rowEst.Cells("Sicy").Value = ""
            '                    rowEst.Cells("IdMarcaCasa").Value = ""
            '                End If
            '            Next
            '        End If

            '    End If
            'End If
        Else
            txtCodSicy.Text = String.Empty
        End If
    End Sub

    Private Sub btnHorma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHorma.Click
        Dim objhorma As New HormaFormRapido
        objhorma.ShowDialog()

        If (objhorma.PidHorma <> 0) Then
            idHorma = objhorma.PidHorma
            nombreHorma = objhorma.PnombreHorma
            lblNombreHorma.Text = objhorma.PnombreHorma
            txtHorma.Text = objhorma.PidHorma
            'Else
            '    idHorma = 0
            '    nombreHorma = String.Empty
            '    lblNombreHorma.Text = ""
            '    txtHorma.Text = String.Empty
        End If
        txtHorma.Focus()
    End Sub

    Private Sub txtHorma_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHorma.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtHorma.Text.Length < 3) Then

            If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtHorma_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHorma.LostFocus
        If (txtHorma.Text <> Nothing) Then
            If (idHorma = 0 Or idHorma <> txtHorma.Text) Then

                Dim objHorma As New Programacion.Negocios.HormasBU
                Dim dtDatosHorma As New DataTable
                dtDatosHorma = objHorma.verHormaId(txtHorma.Text)
                If (dtDatosHorma.Rows.Count > 0) Then
                    idHorma = CInt(dtDatosHorma.Rows(0)(0).ToString)
                    nombreHorma = dtDatosHorma.Rows(0)(1).ToString
                    lblNombreHorma.Text = dtDatosHorma.Rows(0)(1).ToString
                Else
                    txtHorma.Text = String.Empty
                    idHorma = 0
                    nombreHorma = String.Empty
                    lblNombreHorma.Text = ""

                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La horma que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If

            End If
        End If
    End Sub

    Private Sub txtHorma_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHorma.TextChanged
        If (txtHorma.Text = Nothing) Then
            idHorma = 0
            nombreHorma = String.Empty
            lblNombreHorma.Text = ""
            txtHorma.Text = String.Empty
        Else
            Dim objHorma As New Programacion.Negocios.HormasBU
            Dim dtDatosHorma As New DataTable
            dtDatosHorma = objHorma.verHormaId(txtHorma.Text)
            If (dtDatosHorma.Rows.Count > 0) Then
                idHorma = CInt(dtDatosHorma.Rows(0)(0).ToString)
                nombreHorma = dtDatosHorma.Rows(0)(1).ToString
                lblNombreHorma.Text = dtDatosHorma.Rows(0)(1).ToString
            Else
                txtHorma.Text = String.Empty
                idHorma = 0
                nombreHorma = String.Empty
                lblNombreHorma.Text = ""

                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "La horma que ingreso no existe."
                advertenciaMensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub grdDetallesEstilos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdDetallesEstilos.DoubleClickCell
        If e.Cell.Column.Key = "Sicy" And e.Cell.IsFilterRowCell = False And estiloCliente = True Then
            Dim mainElement As UIElement
            Dim element As UIElement
            Dim screenPoint As Point
            Dim clientPoint As Point
            Dim row As UltraGridRow
            Dim cell As UltraGridCell

            ' Get the control's main element
            mainElement = Me.grdDetallesEstilos.DisplayLayout.UIElement

            ' Convert the current mouse position to a point
            ' in client coordinates of the control.
            screenPoint = Control.MousePosition
            clientPoint = Me.grdDetallesEstilos.PointToClient(screenPoint)

            ' Get the element at that point
            element = mainElement.ElementFromPoint(clientPoint)

            If element Is Nothing Then Return

            ' Get the row that contains this element.
            row = element.GetContext(GetType(UltraGridRow))

            If Not row Is Nothing Then

                ' Get the cell that contains this element.
                cell = element.GetContext(GetType(UltraGridCell))

                If Not cell Is Nothing Then

                    'If e.Button <> Windows.Forms.MouseButtons.Right Then Return

                    Dim objMarcaBU As New Negocios.MarcasBU
                    Dim dtDatosMarcas As DataTable
                    dtDatosMarcas = objMarcaBU.verMarcasYuyin()

                    Dim cms = New ContextMenuStrip

                    For Each rowDT As DataRow In dtDatosMarcas.Rows
                        'cms.Items.Add(rowDT.Item(2))
                        Dim itemd = cms.Items.Add(rowDT.Item(2).ToString)
                        itemd.Tag = rowDT.Item(1).ToString
                        AddHandler itemd.Click, AddressOf grdDetallesEstilos_menuChoice
                    Next

                    cms.Show(Control.MousePosition)

                End If
            End If

            ' Walk up the parent element chain and write out a line 
            ' for each parent element.
            While Not element.Parent Is Nothing
                element = element.Parent
            End While

            ' reset the indent level
        ElseIf e.Cell.Column.Key = "Horma" And e.Cell.IsFilterRowCell = False Then
            Dim fila As Int32
            fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
            Dim objHorma As New HormaFormRapido
            objHorma.ShowDialog()
            If Not (objHorma.PidHorma = 0 And objHorma.PnombreHorma = Nothing) Then
                grdDetallesEstilos.Rows(fila).Cells("idHorma").Value = CInt(objHorma.PidHorma)
                grdDetallesEstilos.Rows(fila).Cells("Horma").Value = objHorma.PnombreHorma
            End If

        ElseIf e.Cell.Column.Key = "Fracción_Arancelaria" And e.Cell.IsFilterRowCell = False Then
            If Not IsDBNull(e.Cell.Value) Then
                Dim objFracciones As New Catalogo_FraccionesArancelarias_De_Modelo_En_EspecificoForm
                Dim objFraccion_Detalle As New Entidades.Fracciones_Arancelarias_Detalles
                Dim fila As Int32
                fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)

                objFraccion_Detalle.PFamiliaId = grdDetallesEstilos.Rows(fila).Cells("idFamilia").Value
                objFraccion_Detalle.PForroId = grdDetallesEstilos.Rows(fila).Cells("idForro").Value
                objFraccion_Detalle.PPielMuestraId = grdDetallesEstilos.Rows(fila).Cells("idCorte").Value
                objFraccion_Detalle.PSuelaId = grdDetallesEstilos.Rows(fila).Cells("IdSuela").Value()
                objFraccion_Detalle.PTipoCategoriaId = CInt(txtCategoria.Text)

                objFracciones.objFraccion_Detalle = objFraccion_Detalle
                objFracciones.IdCorrida = grdDetallesEstilos.Rows(fila).Cells("IdTalla").Value
                objFracciones.StartPosition = FormStartPosition.CenterScreen
                objFracciones.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnGrupo_Click(sender As Object, e As EventArgs) Handles btnGrupo.Click
        Dim objGrupo As New grupoRapidoForm
        objGrupo.ShowDialog()
        If objGrupo.PcodGrupo <> 0 Then
            idGrupo = objGrupo.PcodGrupo
            nombreGrupo = objGrupo.PnombreGrupo
            txtGrupo.Text = objGrupo.PcodGrupo
            lblGrupoNombre.Text = objGrupo.PnombreGrupo
        End If
        txtGrupo.Focus()
    End Sub

    Private Sub txtGrupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrupo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtGrupo.Text.Length < 3) Then

            If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtGrupo_LostFocus(sender As Object, e As EventArgs) Handles txtGrupo.LostFocus
        If (txtGrupo.Text = Nothing) Then
            idGrupo = 0
            nombreGrupo = String.Empty
            lblGrupoNombre.Text = ""
            txtGrupo.Text = String.Empty
        Else
            If (idGrupo = 0) Then
                Dim objGrupo As New Programacion.Negocios.GruposBU
                Dim dtDatosGrupo As New DataTable
                dtDatosGrupo = objGrupo.VerGruposPorIdentificador(txtGrupo.Text)
                If (dtDatosGrupo.Rows.Count > 0) Then
                    idGrupo = CInt(dtDatosGrupo.Rows(0)(0).ToString)
                    nombreGrupo = dtDatosGrupo.Rows(0)(1).ToString
                    lblGrupoNombre.Text = dtDatosGrupo.Rows(0)(1).ToString
                Else
                    idGrupo = 0
                    nombreGrupo = String.Empty
                    lblGrupoNombre.Text = ""
                    txtGrupo.Text = String.Empty

                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "El grupo que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub txtGrupo_TextChanged(sender As Object, e As EventArgs) Handles txtGrupo.TextChanged
        If (txtGrupo.Text = Nothing) Then
            idGrupo = 0
            nombreGrupo = String.Empty
            lblGrupoNombre.Text = ""
            txtGrupo.Text = String.Empty
        Else
            Dim objGrupo As New Programacion.Negocios.GruposBU
            Dim dtDatosGrupo As New DataTable
            dtDatosGrupo = objGrupo.VerGruposPorIdentificador(txtGrupo.Text)
            If (dtDatosGrupo.Rows.Count > 0) Then
                idGrupo = CInt(dtDatosGrupo.Rows(0)(0).ToString)
                nombreGrupo = dtDatosGrupo.Rows(0)(1).ToString
                lblGrupoNombre.Text = dtDatosGrupo.Rows(0)(1).ToString
            Else
                idGrupo = 0
                nombreGrupo = String.Empty
                lblGrupoNombre.Text = ""
                txtGrupo.Text = String.Empty

                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "El grupo que ingreso no existe."
                advertenciaMensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub txtCodSicy_TextChanged(sender As Object, e As EventArgs) Handles txtCodSicy.TextChanged
        For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            rowEst.Cells("Sicy").Value = ""
            rowEst.Cells("IdMarcaCasa").Value = ""
        Next
    End Sub

    Private Sub txtCodCliente_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.C And e.Modifiers = Keys.Control Then
            txtCodCliente.Copy()
        End If
    End Sub

    Private Sub txtCodCliente_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim caracter As Char = e.KeyChar
        If (txtCodCliente.Text.Length < 10) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
            If Char.IsLower(e.KeyChar) Then
                txtCodCliente.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cmbMarcasCasa_SelectedIndexChanged(sender As Object, e As EventArgs)
        txtCodSicy.Text = String.Empty
        Try
            codSicyMarca = cmbMarcasCasa.SelectedValue
        Catch ex As Exception
            codSicyMarca = ""
        End Try
    End Sub

    Private Sub grdDetallesEstilos_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection As String = CStr(item.Tag)

        If (codSicyColeccion <> Nothing And txtCodSicy.Text <> Nothing And grdDetallesEstilos.ActiveRow.Cells("pielColor").Value <> Nothing) Then
            Dim sicy As String = txtCodSicy.Text
            If (sicy.Length >= 3) Then
                If (sicy.Length = 3) Then
                    grdDetallesEstilos.ActiveRow.Cells("Sicy").Value = selection + codSicyColeccion + "0" + txtCodSicy.Text + grdDetallesEstilos.ActiveRow.Cells("sicyPCOL").Value.ToString
                    grdDetallesEstilos.ActiveRow.Cells("IdMarcaCasa").Value = selection
                ElseIf (sicy.Length > 3) Then
                    grdDetallesEstilos.ActiveRow.Cells("Sicy").Value = selection + codSicyColeccion + txtCodSicy.Text + grdDetallesEstilos.ActiveRow.Cells("sicyPCOL").Value.ToString
                    grdDetallesEstilos.ActiveRow.Cells("IdMarcaCasa").Value = selection
                End If
            End If
        End If
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.C And e.Modifiers = Keys.Control Then
            txtCodigo.Copy()
        End If
    End Sub

    Private Sub btnAbrirFoto_Click(sender As Object, e As EventArgs) Handles btnAbrirFoto.Click
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picFoto.Image = Image.FromFile(ofdFoto.FileName)
            sr.Close()
        End If
    End Sub

    Private Sub picFoto_DoubleClick(sender As Object, e As EventArgs) Handles picFoto.DoubleClick
        Dim objFotoImagen As New FotoModelo
        objFotoImagen.pcbFotoMax.Image = picFoto.Image
        objFotoImagen.ShowDialog()
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        pnlGridsDatos.Height = 162
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlGridsDatos.Height = 0
    End Sub

    Private Sub rdoPieles_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPieles.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        grdPieles.Width = 263
    End Sub

    Private Sub rdoTallas_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTallas.CheckedChanged
        grdTalla.Width = 263
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        grdPieles.Width = 145

    End Sub

    Private Sub rdoCorte_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCorte.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 263
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        grdPieles.Width = 145

    End Sub

    Private Sub rdoForro_CheckedChanged(sender As Object, e As EventArgs) Handles rdoForro.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 263
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        grdPieles.Width = 145

    End Sub

    Private Sub rdoSuela_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSuela.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 263
        grdFamilia.Width = 145
        grdLinea.Width = 145
        grdPieles.Width = 145

    End Sub

    Private Sub rodFamilia_CheckedChanged(sender As Object, e As EventArgs) Handles rodFamilia.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 263
        grdLinea.Width = 145
        grdPieles.Width = 145

    End Sub

    Private Sub rdoLinea_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLinea.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 263
        grdPieles.Width = 145
    End Sub

    Private Sub picSiguiente_Click(sender As Object, e As EventArgs) Handles picSiguiente.Click
        If rdoPieles.Checked = True Then
            rdoTallas.Checked = True
        ElseIf rdoTallas.Checked = True Then
            rodFamilia.Checked = True
        ElseIf rodFamilia.Checked = True Then
            rdoLinea.Checked = True
        ElseIf rdoLinea.Checked = True Then
            rdoCorte.Checked = True
        ElseIf rdoCorte.Checked = True Then
            rdoForro.Checked = True
        ElseIf rdoForro.Checked = True Then
            rdoSuela.Checked = True
        ElseIf rdoSuela.Checked = True Then
            rdoPieles.Checked = True
        End If
    End Sub

    Private Sub btnCategoria_Click(sender As Object, e As EventArgs) Handles btnCategoria.Click
        Dim objCategoria As New CategoriaFormRapido
        objCategoria.ShowDialog()

        If (objCategoria.PidCategoria <> 0) Then
            idCategoria = objCategoria.PidCategoria
            nombreCategoria = objCategoria.PnombreCategoria
            lblNombreCategoria.Text = objCategoria.PnombreCategoria
            txtCategoria.Text = objCategoria.PidCategoria
            'Else
            '    idCategoria = 0
            '    nombreCategoria = String.Empty
            '    lblNombreCategoria.Text = ""
            '    txtCategoria.Text = String.Empty
        End If
        txtCategoria.Focus()
    End Sub

    Private Sub txtCategoria_LostFocus(sender As Object, e As EventArgs) Handles txtCategoria.LostFocus
        If (txtCategoria.Text <> Nothing) Then
            If (idCategoria = 0 Or idCategoria <> txtCategoria.Text) Then

                Dim objCategoria As New Programacion.Negocios.CategoriasBU
                Dim dtDatosCategoria As New DataTable
                dtDatosCategoria = objCategoria.verCategoriaRapido(txtCategoria.Text)
                If (dtDatosCategoria.Rows.Count > 0) Then
                    idCategoria = CInt(dtDatosCategoria.Rows(0)(0).ToString)
                    nombreCategoria = dtDatosCategoria.Rows(0)(1).ToString
                    lblNombreCategoria.Text = dtDatosCategoria.Rows(0)(1).ToString
                Else
                    txtCategoria.Text = String.Empty
                    idCategoria = 0
                    nombreCategoria = String.Empty
                    lblNombreCategoria.Text = ""

                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La categoría que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If

            End If
        End If
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        If (txtCategoria.Text = Nothing) Then
            idCategoria = 0
            nombreCategoria = String.Empty
            lblNombreCategoria.Text = ""
            txtCategoria.Text = String.Empty
        Else
            Dim objCategoria As New Programacion.Negocios.CategoriasBU
            Dim dtDatosCategoria As New DataTable

            dtDatosCategoria = objCategoria.verCategoriaRapido(txtCategoria.Text)
            If (dtDatosCategoria.Rows.Count > 0) Then
                idCategoria = CInt(dtDatosCategoria.Rows(0)(0).ToString)
                nombreCategoria = dtDatosCategoria.Rows(0)(1).ToString
                lblNombreCategoria.Text = dtDatosCategoria.Rows(0)(1).ToString
            Else
                idCategoria = 0
                nombreCategoria = String.Empty
                lblNombreCategoria.Text = ""
                txtCategoria.Text = String.Empty

                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "La categoría que ingreso no existe."
                advertenciaMensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub txtCodCliente_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles txtCodCliente.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodCliente.Text.Length < 10) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodCliente.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cmbMarcasCasa_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbMarcasCasa.SelectedIndexChanged
        Try
            codSicyMarca = cmbMarcasCasa.SelectedValue
        Catch ex As Exception
            codSicyMarca = ""
        End Try
    End Sub

    Private Sub grdFamilia_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdFamilia.DoubleClickHeader
        Me.Cursor = Cursors.WaitCursor
        Dim objFamilia As New Negocios.FamiliasBU
        Dim dtIdsFamilias As New DataTable
        Dim dtNuevaFamilia As New DataTable
        dtIdsFamilias = objFamilia.verComboFamilias("")
        Dim idFamilias As String = ""
        For Each rowDTF As DataRow In dtIdsFamilias.Rows
            idFamilias += rowDTF.Item("fami_familiaid").ToString + ", "
        Next
        idFamilias += "0"
        Me.Cursor = Cursors.Default
        Dim objFamiliaForm As New AltaFamiliaForm
        objFamiliaForm.ShowDialog()
        dtNuevaFamilia = objFamilia.verFamiliaRegistroRapido(idFamilias)
        For Each rowNV As DataRow In dtNuevaFamilia.Rows
            Dim row As UltraGridRow = Me.grdFamilia.DisplayLayout.Bands(0).AddNew()
            row.Cells("fami_familiaid").Value = rowNV.Item("fami_familiaid").ToString
            row.Cells("fami_codigo").Value = rowNV.Item("fami_codigo").ToString
            row.Cells("fami_descripcion").Value = rowNV.Item("fami_descripcion").ToString
        Next
    End Sub

    Private Sub grdCorte_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdCorte.DoubleClickHeader
        Me.Cursor = Cursors.WaitCursor
        Dim objCorte As New Negocios.PielesMuestraBU
        Dim dtIdsCortes As New DataTable
        Dim dtNuevoCorte As New DataTable
        dtIdsCortes = objCorte.verComboCortes()
        Dim idsCortes As String = ""
        For Each rowDTF As DataRow In dtIdsCortes.Rows
            idsCortes += rowDTF.Item("plmu_pielmuestraid").ToString + ", "
        Next
        idsCortes += "0"
        Me.Cursor = Cursors.Default
        Dim objCorteForm As New AltaPielesMuestraForm
        objCorteForm.ShowDialog()
        dtNuevoCorte = objCorte.verCortesRegistroRapido(idsCortes)
        For Each rowNV As DataRow In dtNuevoCorte.Rows
            Dim row As UltraGridRow = Me.grdCorte.DisplayLayout.Bands(0).AddNew()
            row.Cells("plmu_pielmuestraid").Value = rowNV.Item("plmu_pielmuestraid").ToString
            row.Cells("plmu_codigo").Value = rowNV.Item("plmu_codigo").ToString
            row.Cells("plmu_descripcion").Value = rowNV.Item("plmu_descripcion").ToString
        Next

    End Sub

    Private Sub grdForros_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdForros.DoubleClickHeader
        'forr_forroid, forr_codigo, forr_descripcion
        Me.Cursor = Cursors.WaitCursor
        Dim objForro As New Negocios.ForrosBU
        Dim dtIdsForros As New DataTable
        Dim dtNuevoForro As New DataTable
        dtIdsForros = objForro.verComboForros()
        Dim idsForros As String = ""
        For Each rowDTF As DataRow In dtIdsForros.Rows
            idsForros += rowDTF.Item("forr_forroid").ToString + ", "
        Next
        idsForros += "0"
        Me.Cursor = Cursors.Default
        Dim objForroForm As New AltaForroForm
        objForroForm.ShowDialog()
        dtNuevoForro = objForro.verForrosRegistroRapido(idsForros)
        For Each rowNV As DataRow In dtNuevoForro.Rows
            Dim row As UltraGridRow = Me.grdForros.DisplayLayout.Bands(0).AddNew()
            row.Cells("forr_forroid").Value = rowNV.Item("forr_forroid").ToString
            row.Cells("forr_codigo").Value = rowNV.Item("forr_codigo").ToString
            row.Cells("forr_descripcion").Value = rowNV.Item("forr_descripcion").ToString
        Next
    End Sub

    Private Sub grdLinea_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdLinea.DoubleClickHeader
        Me.Cursor = Cursors.WaitCursor
        Dim objLineasBU As New Programacion.Negocios.LineasBU
        Dim dtIdsListas As New DataTable
        Dim dtListaNuevas As New DataTable
        dtIdsListas = objLineasBU.verListaLineas(True)

        Dim idsLineas As String = ""
        For Each rowDtDt As DataRow In dtIdsListas.Rows
            idsLineas += rowDtDt.Item("linea_lineaid").ToString() + ", "
        Next

        idsLineas += "0"
        Me.Cursor = Cursors.Default
        Dim objLineasForm As New AltaEditarLineas
        objLineasForm.esAltaLinea = True
        objLineasForm.ShowDialog()
        dtListaNuevas = objLineasBU.verRegistroLineaRapido(idsLineas)

        For Each rowDtNuevo As DataRow In dtListaNuevas.Rows
            Dim row As UltraGridRow = Me.grdLinea.DisplayLayout.Bands(0).AddNew()
            row.Cells("linea_lineaid").Value = rowDtNuevo.Item("linea_lineaid").ToString
            row.Cells("linea_descripcion").Value = rowDtNuevo.Item("linea_descripcion").ToString
        Next
    End Sub

    Private Sub grdSuela_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdSuela.DoubleClickHeader
        Me.Cursor = Cursors.WaitCursor
        Dim objSuelasBU As New Programacion.Negocios.SuelasBU
        Dim dtIdsSuelas As New DataTable
        Dim dtSuelasNuevas As New DataTable
        dtIdsSuelas = objSuelasBU.verComboSuelas()

        Dim idsSuelas As String = ""
        For Each rowDtDt As DataRow In dtIdsSuelas.Rows
            idsSuelas += rowDtDt.Item("suel_suelaid").ToString() + ", "
        Next

        idsSuelas += "0"
        Me.Cursor = Cursors.Default
        Dim objSuelasForm As New AltaSuelaForm
        objSuelasForm.ShowDialog()

        dtSuelasNuevas = objSuelasBU.verSuelasRegistradasRapido(idsSuelas)

        For Each rowDtNuevo As DataRow In dtSuelasNuevas.Rows
            Dim row As UltraGridRow = Me.grdSuela.DisplayLayout.Bands(0).AddNew()
            row.Cells("suel_suelaid").Value = rowDtNuevo.Item("suel_suelaid").ToString
            row.Cells("suel_codigo").Value = rowDtNuevo.Item("suel_codigo").ToString
            row.Cells("suel_descripcion").Value = rowDtNuevo.Item("suel_descripcion").ToString
        Next
    End Sub

    Private Sub grdTalla_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdTalla.DoubleClickHeader
        Dim objTBU As New Programacion.Negocios.TallasBU
        Dim dtIdsTallas As New DataTable
        Dim dtListaTallasNuevas As New DataTable

        Dim idsTallas As String = ""

        dtIdsTallas = objTBU.verComboTallas()
        For Each rowDTDT As DataRow In dtIdsTallas.Rows
            idsTallas += rowDTDT.Item("talla_tallaid").ToString + ", "
        Next
        idsTallas += "0"

        Dim objTallas As New AltaTallasForm
        objTallas.ShowDialog()
        dtListaTallasNuevas = objTBU.verTallasRegistroRapido(idsTallas)

        For Each rowDtNuevo As DataRow In dtListaTallasNuevas.Rows
            Dim row As UltraGridRow = Me.grdTalla.DisplayLayout.Bands(0).AddNew()
            row.Cells("talla_tallaid").Value = rowDtNuevo.Item("talla_tallaid").ToString
            row.Cells("talla_descripcion").Value = rowDtNuevo.Item("talla_descripcion").ToString
        Next

    End Sub

    Private Sub grdPieles_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdPieles.DoubleClickHeader
        If e.Header.Column.Key = "convinacionPC" Then
            Me.Cursor = Cursors.WaitCursor
            Dim objPBU As New Programacion.Negocios.PielesBU
            Dim dtIdsPieles As New DataTable
            Dim dtListaPieles As New DataTable
            dtIdsPieles = objPBU.VerListaPieles("", "", "", True, "")

            Dim idsPieles As String = ""
            For Each rowDtDt As DataRow In dtIdsPieles.Rows
                idsPieles += rowDtDt.Item("piel_pielid").ToString() + ", "
            Next
            idsPieles += "0"
            Me.Cursor = Cursors.Default
            Dim objPiel As New AltaPielesForm
            objPiel.ShowDialog()
            dtListaPieles = objPBU.verPielesRegistroRapido(idsPieles)

            For Each rowDtNuevo As DataRow In dtListaPieles.Rows
                Dim row As UltraGridRow = Me.grdPieles.DisplayLayout.Bands(0).AddNew()
                row.Cells("piel_pielid").Value = rowDtNuevo.Item("piel_pielid").ToString
                row.Cells("color_colorid").Value = rowDtNuevo.Item("color_colorid").ToString
                row.Cells("convinacionPC").Value = rowDtNuevo.Item("convinacionPC").ToString
                row.Cells("pcsicy").Value = rowDtNuevo.Item("pcsicy").ToString
            Next

        End If
    End Sub



    Private Sub cmbNaveDesarrolla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaveDesarrolla.SelectedIndexChanged
        If cmbNaveDesarrolla.SelectedValue.ToString <> "" And cmbNaveDesarrolla.Text.ToString <> "" Then
            Try
                idNaveDesarrolla = cmbNaveDesarrolla.SelectedValue
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub rdoFamVentas_CheckedChanged(sender As Object, e As EventArgs)
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        grdPieles.Width = 145
    End Sub

    Private Sub btnSuelaProgramacion_Click(sender As Object, e As EventArgs) Handles btnSuelaProgramacion.Click
        Dim objSuela As New SuelaFormRapido
        objSuela.ShowDialog()

        If (objSuela.PIdSuela <> 0) Then
            IDSuelaProgramacion = objSuela.PIdSuela
            lblNombreSuelaProgramacion.Text = objSuela.PNombreSuela
            txtSuelaProgramacion.Text = objSuela.PIdSuela

            If IDSuelaProgramacion > 0 Then
                ActualizarSuelaProgramacion(IDSuelaProgramacion)
            End If
        End If
        txtSuelaProgramacion.Focus()
    End Sub

    Private Sub ActualizarSuelaProgramacion(ByVal SuelaProgramacion As Integer)

        Try
            If IsNothing(grdDetallesEstilos) = False Then
                If grdDetallesEstilos.Rows.Count > 0 And IDSuelaProgramacion > 0 Then
                    Dim FilasActualizar = grdDetallesEstilos.Rows.Where(Function(x) x.Cells("psEstatus").Value = 1 Or x.Cells("psEstatus").Value = 2)
                    For Each Fila As UltraGridRow In FilasActualizar
                        Fila.Cells("SuelaProgramacionID").Value = IDSuelaProgramacion
                        Fila.Cells("SuelaProgramacion").Value = lblNombreSuelaProgramacion.Text
                    Next
                End If
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If
    End Sub

    Private Sub btnColorSuela_Click(sender As Object, e As EventArgs) Handles btnColorSuela.Click
        Dim objSuelaColor As New ColorSuelaFormRapido
        objSuelaColor.ShowDialog()

        If objSuelaColor.PIdSuelaColor <> 0 Then
            ColorSuelaID = objSuelaColor.PIdSuelaColor
            lblColorSuela.Text = objSuelaColor.PNombreColor
            txtColorSuela.Text = objSuelaColor.PIdSuelaColor

            If ColorSuelaID > 0 Then
                ActualizarColorSuelaProgramacion(ColorSuelaID)
            End If
        End If
        txtColorSuela.Focus()
    End Sub



    Private Sub ActualizarColorSuelaProgramacion(ByVal ColorSuelaProgramacion As Integer)

        Try
            If IsNothing(grdDetallesEstilos) = False Then
                If grdDetallesEstilos.Rows.Count > 0 And IDSuelaProgramacion > 0 Then
                    Dim FilasActualizar = grdDetallesEstilos.Rows.Where(Function(x) x.Cells("psEstatus").Value = 1 Or x.Cells("psEstatus").Value = 2)
                    For Each Fila As UltraGridRow In FilasActualizar
                        Fila.Cells("ColorSuelaID").Value = ColorSuelaID
                        Fila.Cells("ColorSuela").Value = lblColorSuela.Text
                    Next
                End If
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub txtColorSuela_TextChanged(sender As Object, e As EventArgs) Handles txtColorSuela.TextChanged
        If txtColorSuela.Text = Nothing Then
            ColorSuelaID = 0
            nombreColorSuela = String.Empty
            lblColorSuela.Text = ""
            txtColorSuela.Text = String.Empty
        Else
            Dim objColorSuela As New Programacion.Negocios.ColoresSuelaBU
            Dim dtDatosColorSuela As New DataTable
            dtDatosColorSuela = objColorSuela.verColorSuelaId(txtColorSuela.Text)
            If dtDatosColorSuela.Rows.Count > 0 Then
                ColorSuelaID = CInt(dtDatosColorSuela.Rows(0)(0).ToString)
                nombreColorSuela = dtDatosColorSuela.Rows(0)(1).ToString
                lblColorSuela.Text = dtDatosColorSuela.Rows(0)(1).ToString
                ActualizarColorSuelaProgramacion(ColorSuelaID)
            Else
                txtColorSuela.Text = String.Empty
                ColorSuelaID = 0
                nombreColorSuela = String.Empty
                lblColorSuela.Text = ""

                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "El color de la Suela que ingresó no existe."
                advertencia.ShowDialog()
            End If
        End If
    End Sub

    Private Sub lblColorSuela_Click(sender As Object, e As EventArgs) Handles lblColorSuela.Click

    End Sub

    Public Function validarMarcaCasa() As Boolean
        Dim vGuarda As Boolean = True
        If estiloCliente = True Then
            If cmbMarcasCasa.Text <> "" Then
                vGuarda = True
            Else
                vGuarda = False
            End If
        End If

        If txtMarca.Text = "1" Then
            vGuarda = True
        End If

        Return vGuarda
    End Function

    Private Sub grdDetallesEstilo_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdDetallesEstilos.CellChange
        If e.Cell.Column.[Key] = ("idFamiliaVentas") Then
            Dim objProdBU As New Negocios.FamiliasBU
            Dim objPBU As New Programacion.Negocios.ProductosBU
            Dim dtDatosFamilias As DataTable
            dtDatosFamilias = objProdBU.VerComboFamiliaVentas
            Dim i As Integer
            i = grdDetallesEstilos.ActiveRow.Index

            For Each rowdt As DataRow In dtDatosFamilias.Rows
                If rowdt("fapr_descripcion") = e.Cell.Text Then
                    e.Cell.Value = rowdt("fapr_familiaproyeccionid")
                    Dim idtalla As Integer = grdDetallesEstilos.Rows(i).Cells("idTalla").Value

                    grdDetallesEstilos.Rows(i).Cells("idClaveSAT").Value = objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, rowdt("fapr_familiaproyeccionid"), grdDetallesEstilos.Rows(i).Cells("idTalla").Value, grdDetallesEstilos.Rows(i).Cells("idColor").Value)

                    Exit For
                End If
            Next

        End If
    End Sub

    Private Sub btnModeloReferencia_Click(sender As Object, e As EventArgs) Handles btnModeloReferencia.Click
        Dim objModelo As New ModeloReferenciaFormRapido
        objModelo.ShowDialog()
        NombreModelo = objModelo.PnombreModelo
        txtModeloReferencia.Text = objModelo.PnombreModelo ' objModelo.PidProducto

        txtModeloReferencia.Focus()
    End Sub

    Private Sub txtModeloReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModeloReferencia.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtModeloReferencia.Text.Length < 10) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
            If Char.IsLower(e.KeyChar) Then
                txtModeloReferencia.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtModeloReferencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtModeloReferencia.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (txtCodSicy.Text.Length > 0) Then
                validarModelo()
            End If
        End If
    End Sub

    Private Sub validarModelo()
        Dim adv As New AdvertenciaForm
        Dim objModelosReferencia As New Programacion.Negocios.ModeloReferenciaBU
        Dim dtDatosModeloreferencia As New DataTable
        dtDatosModeloreferencia = objModelosReferencia.verModelos(txtModeloReferencia.Text)
        If (dtDatosModeloreferencia.Rows.Count > 0) Then
            txtModeloReferencia.Text = dtDatosModeloreferencia.Rows(0)("ModeloSAY").ToString
        Else
            txtModeloReferencia.Text = String.Empty
            adv.mensaje = "El modelo  que ingresó no existe."
            adv.Show()

        End If

    End Sub

    Public Sub accionesdeInicioCedis()
        txtCodigo.Text = String.Empty
        txtColeccion.Text = String.Empty
        txtDescripcion.Text = String.Empty
        txtCategoria.Text = String.Empty
        txtMarca.Text = String.Empty
        'txtTemporadaO.Text = String.Empty
        lblCodigo.ForeColor = Drawing.Color.Black
        lblMarca.ForeColor = Drawing.Color.Black
        lblColeccion.ForeColor = Drawing.Color.Black
        lblCategoria.ForeColor = Drawing.Color.Black
        lblDescripcion.ForeColor = Drawing.Color.Black

        If idcedis = 82 And esLicencia = True Then
            txtCodCliente.Visible = True
            lblCodigoCliente.Visible = True
        Else
            txtCodCliente.Visible = False
            lblCodigoCliente.Visible = False
        End If

        LlenarTablaPieles()
        LlenarTablaTallas()
        LlenarTablaForros()
        LlenarTablaSuelas()
        LlenarTablaCorte()
        LlenarTablaFamilias()
        LlenarTablaFamiliasVentas()
        llenarTablaLineas()
        llenarComboMarcasCedis(idcedis)
        llenarComboEstatus()
        rdoActivo.Checked = True
        llenarComboNaves()
    End Sub

    Public Sub llenarComboMarcasCedis(ByVal idcedis As Integer)
        Dim objMarcaBU As New Negocios.MarcasBU
        Dim dtDatosMarcas As DataTable
        dtDatosMarcas = objMarcaBU.verMarcasCedis(idcedis)
        dtDatosMarcas.Rows.InsertAt(dtDatosMarcas.NewRow, 0)
        cmbMarcasCasa.DataSource = dtDatosMarcas
        cmbMarcasCasa.DisplayMember = "marc_descripcion"
        cmbMarcasCasa.ValueMember = "marc_codigosicy"
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtMarca.Text <> "1" Then
            txtCodSicy.Text = txtCodigo.Text
        End If
    End Sub

    Private Sub txtCodCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCodCliente.TextChanged
        If txtMarca.Text = "1" Then
            txtCodSicy.Text = txtCodCliente.Text
        End If
    End Sub

    Private Sub txtCodCliente_Leave(sender As Object, e As EventArgs) Handles txtCodCliente.Leave
        Dim objProd As New Programacion.Negocios.ProductosBU
        Dim dtResultado = objProd.validaCodigo(txtCodCliente.Text)
        If dtResultado.Rows.Count > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ya existe un codigo de cliente registrado.")
            txtCodSicy.Text = String.Empty
            txtCodCliente.Text = String.Empty
        End If
    End Sub

End Class