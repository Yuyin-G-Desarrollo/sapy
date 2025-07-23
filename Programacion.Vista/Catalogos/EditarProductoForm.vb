Imports System.Net
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Programacion.Negocios

Public Class EditarProductoForm
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim rutaFtp As String = objFTP.obtenerURL
    Dim FtpUser As String = objFTP.obtenerUsuario
    Dim ftppasswd As String = objFTP.obtenerContrasena

    Public idcedis As Integer
    Public esLicencia As Boolean

    Public idNaveDesarrolla As Int32 = 0
    Public idProducto As String
    Public activo As String
    Dim idMarca As Int32 = -1
    Dim idColeccion As Int32 = 0
    ' ''Dim idFamilia As Int32
    Dim idSubFamilia As Int32 = 0
    Dim idTemporada As Int32 = 0
    Dim idGrupo As Int32 = 0
    Dim idHorma As Int32 = 0
    Dim IdProductoEstilo As Int32 = 0
    Dim idCategoria As Int32 = 0
    Dim IDSuelaProgramacion As Int32 = 0
    Dim ColorSuelaID As Int32 = 0
    Dim codigo As String
    Dim MarcaNombre As String
    Dim codigoProducto As String
    ''Dim cadena As String
    Dim contadorValida As Int32 = 0
    Dim activoInactivo As Boolean
    Dim NombreFoto As String
    Dim NombreDibujo As String
    Dim cadenaFoto As String
    Dim cadenaDibujo As String
    Dim exitoMensaje As New ExitoForm
    Dim consecutivo As String
    Dim estiloCliente As Boolean = False
    Dim nuevaFila As Int32 = 0
    Dim codSicyMarca As String = String.Empty
    Dim codSicyColeccion As String = String.Empty
    Dim primerCodSicyMarca As String = String.Empty
    Dim primerCodSicyColeccion As String = String.Empty
    Dim tamConsultaRegistro As Int32 = 0
    ' ''Dim anio As String = String.Empty
    Dim nombreHorma As String = String.Empty
    Dim nombreSuelaProgramacion As String = String.Empty
    Dim nombreColorSuela As String = String.Empty
    Dim FotoPrimero As System.IO.Stream
    Dim nombreGrupo As String = String.Empty
    Dim NombreModelo As String = String.Empty
    ' ''Dim digitoanio As String = String.Empty
    Dim primerCodMarca As String
    Dim primerCodColeccion As String
    Dim primerModelo As String
    Dim primerMarcaCasa As String
    Dim primerClaveCliente As String
    Dim primeridMarca As Int32
    Dim primerIdColeccion As Int32
    ' ''Dim primerAnio As Int32
    Dim primerConsecutivo As String
    Dim primerCategoria As Int32
    Dim dtSubfamiliasPrimerDato As DataTable
    Dim dtSubfamilias As DataTable
    Dim checkCabeceraEstado As Boolean = True
    Dim cerrarGuardar As Boolean = False
    Dim idFamiliaVentas As Integer = 0
    Dim familiaVentas As String = ""
    Dim ModeloReferencia As String = String.Empty

    Dim permiso As Boolean = False

    Public Sub LlenarDatosProducto()
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtDatosProducto As DataTable
        Dim modeloSicy As String = String.Empty
        dtDatosProducto = objPBU.verDatosPrincipalesProdcucto(idProducto, activo)
        idMarca = Convert.ToInt32(dtDatosProducto.Rows(0)("prod_marcaid").ToString)
        idColeccion = Convert.ToInt32(dtDatosProducto.Rows(0)("prod_coleccionid").ToString)
        idTemporada = Convert.ToInt32(dtDatosProducto.Rows(0)("prod_temporadaid").ToString)
        idFamiliaVentas = Convert.ToInt32(dtDatosProducto.Rows(0)("fapr_familiaproyeccionid").ToString) '09/01/2020 Tomar el valor de idFamiliaVentas  del grdFamilia
        familiaVentas = dtDatosProducto.Rows(0)("fapr_descripcion").ToString
        lblFamiliaVentas.Text = familiaVentas
        If dtDatosProducto.Rows(0)("tica_tipocategoriaid").ToString <> "" Then
            idCategoria = CInt(dtDatosProducto.Rows(0)("tica_tipocategoriaid").ToString)
        Else
            idCategoria = 0
        End If

        '11/08/2020 validar que no exista en Pedidos sin importar Estatus de este
        'If dtDatosProducto.Rows(0)("fgModifica") = True Then
        '    gprBotonActualiza.Enabled = True
        'Else
        '    gprBotonActualiza.Enabled = False
        'End If
        activoInactivo = Convert.ToBoolean(dtDatosProducto.Rows(0)("prod_activo").ToString)


        NombreFoto = dtDatosProducto.Rows(0)("prod_foto").ToString
        NombreDibujo = dtDatosProducto.Rows(0)("prod_dibujo").ToString
        codigo = dtDatosProducto.Rows(0)("prod_codigo").ToString

        primerCodMarca = dtDatosProducto.Rows(0)("marc_codigo").ToString
        primerCodColeccion = dtDatosProducto.Rows(0)("CODIGOCOLE").ToString
        primerModelo = dtDatosProducto.Rows(0)("prod_modelo").ToString
        primeridMarca = Convert.ToInt32(dtDatosProducto.Rows(0)("prod_marcaid").ToString)
        primerIdColeccion = Convert.ToInt32(dtDatosProducto.Rows(0)("prod_coleccionid").ToString)
        primerConsecutivo = dtDatosProducto.Rows(0)("prod_consecutivo").ToString
        primerClaveCliente = dtDatosProducto.Rows(0)("prod_codcliente").ToString
        If dtDatosProducto.Rows(0)("tica_tipocategoriaid").ToString <> "" Then
            primerCategoria = CInt(dtDatosProducto.Rows(0)("tica_tipocategoriaid").ToString)
        Else
            primerCategoria = 0
        End If

        consecutivo = dtDatosProducto.Rows(0)("prod_consecutivo").ToString
        codSicyMarca = dtDatosProducto.Rows(0)("marc_codigosicy").ToString
        codSicyColeccion = dtDatosProducto.Rows(0)("coma_codigosicy").ToString
        primerCodSicyMarca = dtDatosProducto.Rows(0)("marc_codigosicy").ToString
        primerCodSicyColeccion = dtDatosProducto.Rows(0)("coma_codigosicy").ToString

        estiloCliente = dtDatosProducto.Rows(0)("marc_escliente").ToString
        'idGrupo = CInt(dtDatosProducto.Rows(0)("grpo_grupoid").ToString)
        nombreGrupo = dtDatosProducto.Rows(0)("grpo_descripcion").ToString

        txtMarca.Text = dtDatosProducto.Rows(0)("marc_codigo").ToString
        txtColeccion.Text = dtDatosProducto.Rows(0)("CODIGOCOLE").ToString
        If idcedis = 82 And esLicencia = True Then
            txtCodigo.Text = dtDatosProducto.Rows(0)("prod_modelo").ToString
        Else
            txtCodigo.Text = dtDatosProducto.Rows(0)("prod_codigo").ToString
        End If
        'txtCodigo.Text = dtDatosProducto.Rows(0)("prod_codigo").ToString
        txtCodSicy.Text = dtDatosProducto.Rows(0)("prod_modelo").ToString
        txtDescripcion.Text = dtDatosProducto.Rows(0)("prod_descripcion").ToString()
        txtCodCliente.Text = dtDatosProducto.Rows(0)("prod_codcliente").ToString
        txtGrupo.Text = dtDatosProducto.Rows(0)("grpo_grupoid").ToString
        txtCategoria.Text = dtDatosProducto.Rows(0)("tica_tipocategoriaid").ToString
        txtModeloReferencia.Text = dtDatosProducto.Rows(0)("referencia").ToString


        lblNombreColeccion.Text = dtDatosProducto.Rows(0)("cole_descripcion").ToString
        lblNombreTemporada.Text = dtDatosProducto.Rows(0)("temp_nombre").ToString
        lblGrupoNombre.Text = dtDatosProducto.Rows(0)("grpo_descripcion").ToString
        lblNombreCategoria.Text = dtDatosProducto.Rows(0)("tica_descripcion").ToString

        If txtMarca.Text = "6" Or txtMarca.Text = "7" Or txtMarca.Text = "8" Then
            lblModeloReferencia.Visible = True
            txtModeloReferencia.Visible = True
            btnModeloReferencia.Visible = True
        Else
            lblModeloReferencia.Visible = False
            txtModeloReferencia.Visible = False
            btnModeloReferencia.Visible = False
        End If
        ModeloReferencia = dtDatosProducto.Rows(0)("referencia").ToString
        If (activoInactivo = True) Then
            rdoActivo.Checked = True
        ElseIf (activoInactivo = False) Then
            rdoInactivo.Checked = True
        End If
        Try
            Dim request = DirectCast(WebRequest.Create(rutaFtp), FtpWebRequest)
            request.Credentials = New NetworkCredential(FtpUser, ftppasswd)
            Dim Carpeta As String = "Programacion/Modelos/"
            Dim objFTP As New Tools.TransferenciaFTP
            Dim StreamFoto As System.IO.Stream
            Dim StreamDibujo As System.IO.Stream

            StreamFoto = objFTP.StreamFile(Carpeta, NombreFoto)
            picFoto.Image = Image.FromStream(StreamFoto)
            StreamFoto.Close()

            'StreamDibujo = objFTP.StreamFile(Carpeta, NombreDibujo)
            'picDibujo.Image = Image.FromStream(StreamDibujo)

            'StreamDibujo.Close()
        Catch ex As Exception

        End Try

        If (dtDatosProducto.Rows(0)("prod_activo").ToString = "True") Then
            rdoActivo.Checked = True
        ElseIf (dtDatosProducto.Rows(0)("prod_activo").ToString = "False") Then
            rdoInactivo.Checked = True
        End If


        Dim datoClienteProp As String

        datoClienteProp = objPBU.verClientePropietarioModelo(idProducto)
        If datoClienteProp <> "" Then
            lblNombreCliente.Visible = True
            lblClientePropietario.Visible = True
            lblNombreCliente.Text = datoClienteProp
        End If

    End Sub

    Public Sub llenarSubfamilias()
        Dim objSubfsProducto As New Negocios.ProductosBU
        dtSubfamiliasPrimerDato = objSubfsProducto.consultaProductoSubfamilias(idProducto)

        If (dtSubfamiliasPrimerDato.Rows.Count = 1) Then
            idSubFamilia = CInt(dtSubfamiliasPrimerDato.Rows(0)("subf_subfamiliaid").ToString)
            lblNombreSubfamilia.Text = dtSubfamiliasPrimerDato.Rows(0)("subf_descripcion").ToString
            txtSubfamilia.Text = dtSubfamiliasPrimerDato.Rows(0)("subf_subfamiliaid").ToString

        ElseIf (dtSubfamiliasPrimerDato.Rows.Count > 1) Then
            dtSubfamilias = New DataTable
            Dim cadenaSubfamilias As String = ""
            dtSubfamilias.Columns.Add("idSubfamilia")
            dtSubfamilias.Columns.Add("subfamiliaNombre")

            Dim contSub As Int32
            contSub = 0

            For Each rowDTSF As DataRow In dtSubfamiliasPrimerDato.Rows
                dtSubfamilias.Rows.Add()
                dtSubfamilias.Rows(contSub).Item("idSubfamilia") = CInt(rowDTSF.Item("subf_Subfamiliaid").ToString)
                dtSubfamilias.Rows(contSub).Item("subfamiliaNombre") = rowDTSF.Item("subf_descripcion").ToString
                contSub = contSub + 1
            Next

            For Each dtRow As DataRow In dtSubfamilias.Rows
                cadenaSubfamilias += dtRow.Item("subfamiliaNombre").ToString + ", "
            Next

            Dim cadNombreExacto As String
            Dim tamcad As Int32 = 0
            tamcad = Len(cadenaSubfamilias) - 2
            cadNombreExacto = cadenaSubfamilias.Substring(0, tamcad)
            lblNombreSubfamilia.Text = cadNombreExacto

        End If

    End Sub

    Public Sub LlenarTablaTallas(ByVal permiso As Boolean)
        Dim objTBU As New Programacion.Negocios.ProductosBU
        Dim dtListaTallas As DataTable
        dtListaTallas = New DataTable
        dtListaTallas = objTBU.verTallasSeleccionadasProducto(idProducto)
        grdTalla.DataSource = dtListaTallas
        Dim i As Int32 = 0

        With grdTalla.DisplayLayout.Bands(0)
            .Columns("talla_tallaid").Hidden = True
            .Columns("talla_sicy").Hidden = True
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("selectTalla").Header.Caption = ""
            .Columns("selectTalla").Style = ColumnStyle.CheckBox
            If permiso = True Then
                .Columns("selectTalla").CellActivation = Activation.AllowEdit
            Else
                .Columns("selectTalla").CellActivation = Activation.Disabled
            End If
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellAppearance.TextHAlign = HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdTalla.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        If (estiloCliente = False) Then
            For Each row As UltraGridRow In grdTalla.Rows
                row.Cells("selectTalla").Value = False
            Next
        ElseIf (estiloCliente = True) Then
            For Each row As UltraGridRow In grdTalla.Rows
                row.Cells("selectTalla").Value = False
            Next
        End If
    End Sub




    Public Sub LlenarTablaPieles(ByVal permiso As Boolean)
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtListaPiel As DataTable
        dtListaPiel = New DataTable
        dtListaPiel = objPBU.verPielesSeleccionadasProducto(idProducto)
        grdPieles.DataSource = dtListaPiel

        With grdPieles.DisplayLayout.Bands(0)
            If permiso = True Then
                .Columns("selectPcol").CellActivation = Activation.AllowEdit
            Else
                .Columns("selectPcol").CellActivation = Activation.Disabled
            End If
            .Columns("selectPcol").Style = ColumnStyle.CheckBox
            .Columns("piel_pielid").Hidden = True
            .Columns("color_colorid").Hidden = True
            .Columns("pielcol").Header.Caption = "Piel Color"
            .Columns("sicypcol").Header.Caption = "SICY"
            .Columns("selectPcol").Header.Caption = ""
            .Columns("pielcol").CellActivation = Activation.NoEdit
            .Columns("sicypcol").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdPieles.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        If (estiloCliente = False) Then
            For Each row As UltraGridRow In grdPieles.Rows
                row.Cells("selectPcol").Value = False
            Next
        ElseIf (estiloCliente = True) Then
            For Each row As UltraGridRow In grdPieles.Rows
                row.Cells("selectPcol").Value = False
            Next
        End If

    End Sub

    Public Sub LlenarTablaForro(ByVal permiso As Boolean)
        Dim objFBU As New Programacion.Negocios.ProductosBU
        Dim dtListaForro As DataTable
        dtListaForro = New DataTable
        dtListaForro = objFBU.verForrosSeleccionadosProducto(idProducto)
        grdForros.DataSource = dtListaForro
        With grdForros.DisplayLayout.Bands(0)
            If permiso = True Then
                .Columns("selectForro").CellActivation = Activation.AllowEdit
            Else
                .Columns("selectForro").CellActivation = Activation.Disabled
            End If
            .Columns("selectForro").Style = ColumnStyle.CheckBox

            .Columns("forr_forroid").Hidden = True
            .Columns("forr_codigo").Hidden = True
            .Columns("forr_descripcion").Header.Caption = "Forros"
            .Columns("selectForro").Header.Caption = ""
            .Columns("forr_descripcion").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdForros.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        If (estiloCliente = False) Then
            For Each row As UltraGridRow In grdForros.Rows
                row.Cells("selectForro").Value = False
            Next
        ElseIf (estiloCliente = True) Then
            For Each row As UltraGridRow In grdForros.Rows
                row.Cells("selectForro").Value = False
            Next
        End If
    End Sub


    Public Sub LlenarTablaSuela(ByVal permiso As Boolean)
        Dim obSBU As New Programacion.Negocios.ProductosBU
        Dim dtListaSuela As DataTable
        dtListaSuela = New DataTable
        dtListaSuela = obSBU.verSuelasSeleccionadasProducto(idProducto)
        grdSuela.DataSource = dtListaSuela

        'suel_suelaid, sl.suel_codigo, sl.suel_descripcion, 0 as selectSuela

        With grdSuela.DisplayLayout.Bands(0)
            If permiso = True Then
                .Columns("selectSuela").CellActivation = Activation.AllowEdit
            Else
                .Columns("selectSuela").CellActivation = Activation.Disabled
            End If
            .Columns("selectSuela").Style = ColumnStyle.CheckBox

            .Columns("suel_suelaid").Hidden = True
            .Columns("suel_codigo").Hidden = True
            .Columns("suel_descripcion").CellActivation = Activation.NoEdit
            .Columns("suel_descripcion").Header.Caption = "Suelas"
            .Columns("selectSuela").Header.Caption = ""
            '.DisplayLayout.Bands(0).Columns(3).Width = 50
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdSuela.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        If (estiloCliente = False) Then
            'For Each row As UltraGridRow In grdSuela.Rows
            '    If (row.Cells(3).Value.ToString = Nothing) Then
            '        row.Cells(3).Value = False
            '    End If
            'Next
            For Each row As UltraGridRow In grdSuela.Rows
                row.Cells("selectSuela").Value = False
            Next
        ElseIf (estiloCliente = True) Then
            For Each row As UltraGridRow In grdSuela.Rows
                row.Cells("selectSuela").Value = False
            Next
        End If
    End Sub

    Public Sub LlenarTablaCorte(ByVal permiso As Boolean)
        Dim obCBU As New Programacion.Negocios.ProductosBU
        Dim dtListaCorte As DataTable
        dtListaCorte = New DataTable
        dtListaCorte = obCBU.verCortesSeleccionadasProducto(idProducto)
        grdCorte.DataSource = dtListaCorte

        'pl.plmu_pielmuestraid  , pl.plmu_codigo   , pl.plmu_descripcion , 0 as selectCorte

        With grdCorte.DisplayLayout.Bands(0)
            If permiso = True Then
                .Columns("selectCorte").CellActivation = Activation.AllowEdit
            Else
                .Columns("selectCorte").CellActivation = Activation.Disabled
            End If
            .Columns("selectCorte").Style = ColumnStyle.CheckBox

            .Columns("plmu_pielmuestraid").Hidden = True
            .Columns("plmu_codigo").Hidden = True
            .Columns("plmu_descripcion").Header.Caption = "Cortes"
            .Columns("selectCorte").Header.Caption = ""
            .Columns("plmu_descripcion").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdCorte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        If (estiloCliente = False) Then
            'For Each row As UltraGridRow In grdCorte.Rows
            '    If (row.Cells(3).Value.ToString = Nothing) Then
            '        row.Cells(3).Value = False
            '    End If
            'Next
            For Each row As UltraGridRow In grdCorte.Rows
                row.Cells("selectCorte").Value = False
            Next
        ElseIf (estiloCliente = True) Then
            For Each row As UltraGridRow In grdCorte.Rows
                row.Cells("selectCorte").Value = False
            Next
        End If
    End Sub

    Public Sub LlenarTablaFamilias(ByVal permiso As Boolean)
        Dim objCBU As New Programacion.Negocios.ProductosBU
        Dim dtListaFamilia As DataTable
        dtListaFamilia = objCBU.verFamiliaSeleccionadasProducto(idProducto)
        grdFamilia.DataSource = dtListaFamilia
        grdFamilia.DataBind()

        'b.fami_familiaid, b.fami_codigo, b.fami_descripcion, a.pres_activo

        With grdFamilia.DisplayLayout.Bands(0)
            .Columns("fami_familiaid").Hidden = True
            .Columns("fami_codigo").Hidden = True
            .Columns("fami_descripcion").Header.Caption = "Familias"
            .Columns("fami_descripcion").CellActivation = Activation.NoEdit
            .Columns("selectFamilia").Header.Caption = ""
            If permiso = True Then
                .Columns("selectFamilia").CellActivation = Activation.AllowEdit
            Else
                .Columns("selectFamilia").CellActivation = Activation.Disabled
            End If
            .Columns("selectFamilia").Style = ColumnStyle.CheckBox

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdFamilia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        If (estiloCliente = True) Then
            For Each row As UltraGridRow In grdFamilia.Rows
                row.Cells("selectFamilia").Value = False
            Next
        Else
            For Each row As UltraGridRow In grdFamilia.Rows
                row.Cells("selectFamilia").Value = False
            Next
        End If
    End Sub

    Public Sub llenarTablaLineas(ByVal permiso As Boolean)
        Dim objLineas As New Negocios.ProductosBU
        Dim dtDatosLineas As New DataTable
        dtDatosLineas = objLineas.verLineasSeleccionadasProducto(idProducto)
        grdLinea.DataSource = dtDatosLineas

        'b.linea_lineaid, b.linea_descripcion, b.linea_activo, a.pres_activo

        With grdLinea.DisplayLayout.Bands(0)
            .Columns("linea_lineaid").Hidden = True
            .Columns("linea_activo").Hidden = True
            .Columns("linea_descripcion").Header.Caption = "Lineas"
            .Columns("linea_descripcion").CellActivation = Activation.NoEdit
            .Columns("selectLinea").Header.Caption = ""
            If permiso = True Then
                .Columns("selectLinea").CellActivation = Activation.AllowEdit
            Else
                .Columns("selectLinea").CellActivation = Activation.Disabled
            End If
            .Columns("selectLinea").Style = ColumnStyle.CheckBox

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdLinea.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        If (estiloCliente = True) Then
            For Each row As UltraGridRow In grdLinea.Rows
                row.Cells("selectLinea").Value = False
            Next
        Else
            For Each row As UltraGridRow In grdLinea.Rows
                row.Cells("selectLinea").Value = False
            Next
        End If

    End Sub

    Public Sub llenarTablaDetalles() ''''' cambiar numeros por titulos cambiar lo de horma
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim objSuela As New Programacion.Negocios.SuelasBU
        Dim objForro As New Programacion.Negocios.ForrosBU
        Dim objCortes As New Programacion.Negocios.PielesMuestraBU
        Dim objLineas As New Programacion.Negocios.LineasBU
        Dim dtDetallesProducto As DataTable
        dtDetallesProducto = New DataTable
        dtDetallesProducto = objPBU.verDetallesProductoEditar(idProducto)

        Dim dtClaveSAT As New DataTable
        Dim dtSuelas As New DataTable
        Dim dtForros As New DataTable
        Dim dtCortes As New DataTable
        Dim dtLineas As New DataTable
        Dim dtHormas As New DataTable
        Dim dtFamiliasProyeccion As New DataTable
        Dim dtSuelasProgramacion As New DataTable
        Dim dtColorSuela As New DataTable
        Dim listClaveSAT As New ValueList
        Dim listSuelas As New ValueList
        Dim listForros As New ValueList
        Dim listCortes As New ValueList
        Dim listFamilias As New ValueList
        Dim listLineas As New ValueList
        Dim listSuelaProgramacion As New ValueList
        Dim listColorSuela As New ValueList
        Dim listHormas As New ValueList
        Dim objbuColorSuela As New Programacion.Negocios.ColoresSuelaBU

        dtClaveSAT = objPBU.claveSAT()
        dtSuelas = objSuela.verComboSuelas()
        dtForros = objForro.verComboForros()
        dtFamiliasProyeccion = objPBU.ObtenerFamiliasProyeccion()
        dtSuelasProgramacion = objPBU.ObtenerSuelasProgramacion()
        dtHormas = objPBU.ObtenerHormas()


        dtColorSuela = objbuColorSuela.obtenerColoresSuelas(True)
        dtCortes = objCortes.verComboCortes()
        dtLineas = objLineas.verComboLineas()

        'dtClaveSAT.Rows.InsertAt(dtClaveSAT.NewRow, 0) 

        For Each renglon As DataRow In dtHormas.Rows
            listHormas.ValueListItems.Add(renglon.Item("HormaID"), renglon.Item("Horma"))
        Next


        For Each renglon As DataRow In dtClaveSAT.Rows
            listClaveSAT.ValueListItems.Add(renglon.Item("ID"), renglon.Item("Clave SAT"))
        Next

        For Each renglon As DataRow In dtSuelas.Rows
            listSuelas.ValueListItems.Add(renglon.Item("suel_suelaid"), renglon.Item("suel_descripcion"))
        Next

        For Each renglon As DataRow In dtForros.Rows
            listForros.ValueListItems.Add(renglon.Item("forr_forroid"), renglon.Item("forr_descripcion"))
        Next

        For Each renglon As DataRow In dtFamiliasProyeccion.Rows
            listFamilias.ValueListItems.Add(renglon.Item("idFamiliaVentas"), renglon.Item("familia ventas"))
        Next

        For Each renglon As DataRow In dtCortes.Rows
            listCortes.ValueListItems.Add(renglon.Item("plmu_pielmuestraid"), renglon.Item("plmu_descripcion"))
        Next

        For Each renglon As DataRow In dtLineas.Rows
            listLineas.ValueListItems.Add(renglon.Item("linea_lineaid"), renglon.Item("linea_descripcion"))
        Next

        Dim objHorma As New Programacion.Negocios.HormasBU
        Dim dtDatoHorma As New DataTable

        If (dtDetallesProducto.Rows.Count > 0) Then
            If (dtDetallesProducto.Rows(0)("idHorma").ToString <> Nothing) Then
                dtDatoHorma = objHorma.verHormaId(CInt(dtDetallesProducto.Rows(0)("idHorma").ToString))
                idHorma = CInt(dtDetallesProducto.Rows(0)("idHorma").ToString)
                txtHorma.Text = dtDetallesProducto.Rows(0)("idHorma").ToString
                nombreHorma = dtDatoHorma.Rows(0)("horma_hormaid").ToString
                lblNombreHorma.Text = dtDatoHorma.Rows(0)("horma_descripcion").ToString
            End If

            If (dtDetallesProducto.Rows(0)("SuelaProgramacionID").ToString <> 0) Then
                IDSuelaProgramacion = CInt(dtDetallesProducto.Rows(0)("SuelaProgramacionID").ToString)
                txtSuelaProgramacion.Text = dtDetallesProducto.Rows(0)("SuelaProgramacionID").ToString
                nombreSuelaProgramacion = dtDetallesProducto.Rows(0)("SuelaProgramacionID").ToString
                lblNombreSuelaProgramacion.Text = dtDetallesProducto.Rows(0)("SuelaProgramacion").ToString
            End If

            If dtDetallesProducto.Rows(0)("ColorSuelaID").ToString <> 0 Then
                ColorSuelaID = CInt(dtDetallesProducto.Rows(0)("ColorSuelaID").ToString)
                txtColorSuela.Text = dtDetallesProducto.Rows(0)("ColorSuelaID").ToString
                nombreColorSuela = dtDetallesProducto.Rows(0)("ColorSuelaID").ToString
                lblColorSuela.Text = dtDetallesProducto.Rows(0)("ColorSuela").ToString

            End If

            If dtDetallesProducto.Rows(0)("IdMarcaCasa").ToString <> "" Then
                cmbMarcasCasa.SelectedValue = dtDetallesProducto.Rows(0)("IdMarcaCasa").ToString
                primerMarcaCasa = dtDetallesProducto.Rows(0)("IdMarcaCasa").ToString
            End If
        End If


        'For Each row As DataRow In dtDetallesProducto.Rows
        '    row("idFamiliaVentas") = idFamiliaVentas
        '    row("familia ventas") = familiaVentas
        'Next

        grdDetallesEstilos.DataSource = dtDetallesProducto
        Elimiar_Primeros_asteriscos_griddetalle()
        estiloGridEstilos()
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idClaveSAT").ValueList = listClaveSAT
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idSuela").ValueList = listSuelas
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idForro").ValueList = listForros
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idCorte").ValueList = listCortes
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idLinea").ValueList = listLineas
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idFamiliaVentas").ValueList = listFamilias
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("Horma").ValueList = listHormas
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("SuelaProgramacionID").ValueList = listSuelaProgramacion
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("ColorSuelaID").ValueList = listColorSuela


        For Each row As UltraGridRow In grdDetallesEstilos.Rows
            row.Cells("seleccion").Value = False
        Next
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

    ''Public Function ultimoDigitoAnio(ByVal anioCompleto As String) As String
    ''    Dim digito As String = ""
    ''    If (anioCompleto <> "") Then
    ''        digito = anioCompleto.Substring(3, 1)
    ''    End If
    ''    Return digito
    ''End Function

    Public Sub LlenarTablaDetallesEstilosProducto()
        Try
            Dim idEstatusCBO As Int32 = cmbEstatus.SelectedValue
            Dim nombreEstatus As String = cmbEstatus.Text

            Dim objPBU As New Programacion.Negocios.ProductosBU
            Dim dtDetallesProducto As DataTable
            dtDetallesProducto = New DataTable
            dtDetallesProducto = objPBU.verDetallesProductoEditar(idProducto)
            Dim nuevaFila As Int32 = 0
            Dim contPiel As Int32 = 0
            Dim idFamiliaVentasNuevo As Int32 = 0 '09/01/2020 Variable nueva para tomar la familiaproyeccionid del grdFamilias MIGS

            ' ''Dim tablaDetalle As New DataTable("TablaDetalle")
            ' ''Dim Fila As DataRow
            ' ''tablaDetalle.Columns.Add("pstilo", GetType(String))
            ' ''tablaDetalle.Columns.Add("idPiel", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("idColor", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("pielColor", GetType(String))
            ' ''tablaDetalle.Columns.Add("idTalla", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("talla", GetType(String))
            ' ''tablaDetalle.Columns.Add("idFamilia", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("familia", GetType(String))
            ' ''tablaDetalle.Columns.Add("idLinea", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("linea", GetType(String))
            ' ''tablaDetalle.Columns.Add("idCorte", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("corte", GetType(String))
            ' ''tablaDetalle.Columns.Add("idForro", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("forro", GetType(String))
            ' ''tablaDetalle.Columns.Add("idSuela", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("suela", GetType(String))
            ' ''tablaDetalle.Columns.Add("idHorma", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("Horma", GetType(String))
            ' ''tablaDetalle.Columns.Add("Sicy", GetType(String))
            ' ''tablaDetalle.Columns.Add("sicyPCOL", GetType(String))
            ' ''tablaDetalle.Columns.Add("IdMarcaCasa", GetType(String))
            ' ''tablaDetalle.Columns.Add("psEstatus", GetType(Int32))
            ' ''tablaDetalle.Columns.Add("nomSts", GetType(String))
            ' ''tablaDetalle.Columns.Add("seleccion", GetType(Boolean))

            'Dim dtClaveSAT As New DataTable
            'Dim listClaveSAT As New ValueList

            'dtClaveSAT = objPBU.claveSAT()
            ''dtClaveSAT.Rows.InsertAt(dtClaveSAT.NewRow, 0)

            'For Each renglon As DataRow In dtClaveSAT.Rows
            '    listClaveSAT.ValueListItems.Add(renglon.Item("ID"), renglon.Item("Clave SAT"))
            'Next


            For Each rowPiel As UltraGridRow In grdPieles.Rows
                If (CBool(rowPiel.Cells("selectPcol").Value) = True) Then
                    Dim contTalla As Int32 = 0
                    For Each rowTalla As UltraGridRow In grdTalla.Rows
                        If (CBool(rowTalla.Cells("selectTalla").Value) = True) Then
                            Dim contFamilia As Int32 = 0
                            For Each rowFamilia As UltraGridRow In grdFamilia.Rows
                                If (CBool(rowFamilia.Cells("selectFamilia").Value) = True) Then
                                    Dim contLinea As Int32 = 0
                                    For Each rowLinea As UltraGridRow In grdLinea.Rows
                                        If (CBool(rowLinea.Cells("selectLinea").Value) = True) Then
                                            Dim contForro As Int32 = 0
                                            For Each rowForro As UltraGridRow In grdForros.Rows
                                                If (CBool(rowForro.Cells("selectForro").Value) = True) Then
                                                    Dim contSuela As Int32 = 0
                                                    For Each rowSuela As UltraGridRow In grdSuela.Rows
                                                        If (CBool(rowSuela.Cells("selectSuela").Value) = True) Then
                                                            Dim contCorte As Int32 = 0
                                                            For Each rowCorte As UltraGridRow In grdCorte.Rows
                                                                If (CBool(rowCorte.Cells("selectCorte").Value) = True) Then

                                                                    Dim inserta As Boolean = True

                                                                    For Each rowGRD As UltraGridRow In grdDetallesEstilos.Rows

                                                                        If rowGRD.Cells("idPiel").Value = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("piel_pielid").Value.ToString) And
                                                                                        rowGRD.Cells("idColor").Value = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("color_colorid").Value.ToString) And
                                                                                            rowGRD.Cells("idFamilia").Value = Convert.ToInt32(grdFamilia.Rows(contFamilia).Cells("fami_familiaid").Value.ToString) And
                                                                                            rowGRD.Cells("idFamiliaVentas").Value = idFamiliaVentas And
                                                                                            rowGRD.Cells("idLinea").Value = Convert.ToInt32(grdLinea.Rows(contLinea).Cells("linea_lineaid").Value.ToString) And
                                                                                            rowGRD.Cells("idTalla").Value = Convert.ToInt32(grdTalla.Rows(contTalla).Cells("talla_tallaid").Value.ToString) And
                                                                                            rowGRD.Cells("idCorte").Value = Convert.ToInt32(grdCorte.Rows(contCorte).Cells("plmu_pielmuestraid").Value.ToString) And
                                                                                            rowGRD.Cells("idForro").Value = Convert.ToInt32(grdForros.Rows(contForro).Cells("forr_forroid").Value.ToString) And
                                                                                            rowGRD.Cells("idSuela").Value = Convert.ToInt32(grdSuela.Rows(contSuela).Cells("suel_suelaid").Value.ToString) And
                                                                                            rowGRD.Cells("SuelaProgramacionID").Value = IDSuelaProgramacion And
                                                                                            rowGRD.Cells("ColorSuelaID").Value = ColorSuelaID And
                                                                                            rowGRD.Cells("idHorma").Value = CInt(idHorma) Then
                                                                            inserta = False
                                                                        End If
                                                                    Next

                                                                    'idFamiliaVentasNuevo = objPBU.buscarClaveFamiliaProyeccion(familiaVentas)
                                                                    If inserta = True Then
                                                                        Dim rowEstilo As UltraGridRow = Me.grdDetallesEstilos.DisplayLayout.Bands(0).AddNew()
                                                                        'rowEstilo.Cells("pstilo").Value = ""

                                                                        rowEstilo.Cells("idPiel").Value = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("piel_pielid").Value.ToString)
                                                                        rowEstilo.Cells("idColor").Value = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("color_colorid").Value.ToString)
                                                                        rowEstilo.Cells("pielColor").Value = grdPieles.Rows(contPiel).Cells("pielcol").Value.ToString
                                                                        rowEstilo.Cells("idFamilia").Value = Convert.ToInt32(grdFamilia.Rows(contFamilia).Cells("fami_familiaid").Value.ToString)
                                                                        rowEstilo.Cells("familia").Value = grdFamilia.Rows(contFamilia).Cells("fami_descripcion").Value.ToString
                                                                        rowEstilo.Cells("idFamiliaVentas").Value = idFamiliaVentas
                                                                        rowEstilo.Cells("familia ventas").Value = familiaVentas
                                                                        rowEstilo.Cells("idLinea").Value = Convert.ToInt32(grdLinea.Rows(contLinea).Cells("linea_lineaid").Value.ToString)
                                                                        rowEstilo.Cells("linea").Value = grdLinea.Rows(contLinea).Cells("linea_descripcion").Value.ToString
                                                                        rowEstilo.Cells("idTalla").Value = Convert.ToInt32(grdTalla.Rows(contTalla).Cells("talla_tallaid").Value.ToString)
                                                                        rowEstilo.Cells("talla").Value = grdTalla.Rows(contTalla).Cells("talla_descripcion").Value.ToString
                                                                        rowEstilo.Cells("idCorte").Value = Convert.ToInt32(grdCorte.Rows(contCorte).Cells("plmu_pielmuestraid").Value.ToString)
                                                                        rowEstilo.Cells("corte").Value = grdCorte.Rows(contCorte).Cells("plmu_descripcion").Value.ToString
                                                                        rowEstilo.Cells("idForro").Value = Convert.ToInt32(grdForros.Rows(contForro).Cells("forr_forroid").Value.ToString)
                                                                        rowEstilo.Cells("forro").Value = grdForros.Rows(contForro).Cells("forr_descripcion").Value.ToString
                                                                        rowEstilo.Cells("idSuela").Value = Convert.ToInt32(grdSuela.Rows(contSuela).Cells("suel_suelaid").Value.ToString)
                                                                        rowEstilo.Cells("suela").Value = grdSuela.Rows(contSuela).Cells("suel_descripcion").Value.ToString
                                                                        rowEstilo.Cells("idHorma").Value = CInt(idHorma)
                                                                        rowEstilo.Cells("SuelaProgramacionID").Value = CInt(IDSuelaProgramacion)
                                                                        rowEstilo.Cells("SuelaProgramacion").Value = lblNombreSuelaProgramacion.Text
                                                                        rowEstilo.Cells("ColorSuelaID").Value = CInt(ColorSuelaID)
                                                                        rowEstilo.Cells("ColorSuela").Value = lblColorSuela.Text
                                                                        rowEstilo.Cells("Horma").Value = lblNombreHorma.Text
                                                                        rowEstilo.Cells("Nuevo").Value = True




                                                                        'objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, rowEstilo.Cells("idFamilia").Value, rowEstilo.Cells("idTalla").Value, rowEstilo.Cells("idColor").Value)
                                                                        'hace falta cambiar el valor de datatabla a string                                                                        
                                                                        '09/01/2020 idFamiliaVentas se cambia por el valor del grdFamilia MIGS 
                                                                        rowEstilo.Cells("idClaveSAT").Value = objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, idFamiliaVentas, rowEstilo.Cells("idTalla").Value, rowEstilo.Cells("idColor").Value)
                                                                        rowEstilo.Cells("Fracción_Arancelaria").Value = objPBU.buscarFraccionArancelariaArticuloAgregado(rowEstilo.Cells("idtalla").Value, rowEstilo.Cells("idfamilia").Value, rowEstilo.Cells("idcorte").Value, rowEstilo.Cells("idforro").Value, rowEstilo.Cells("idsuela").Value, txtCategoria.Text)
                                                                        If Not IsDBNull(rowEstilo.Cells("Fracción_arancelaria")) Then
                                                                            Elimiar_Primeros_asteriscos_griddetalle()
                                                                        End If

                                                                        '  rowEstilo.Cells("idClaveSAT").Value = objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, rowEstilo.Cells("idFamilia").Value, rowEstilo.Cells("idTalla").Value, rowEstilo.Cells("idColor").Value)

                                                                        ' ''Fila = tablaDetalle.NewRow
                                                                        ' ''Fila("pstilo") = ""
                                                                        ''    'Fila("idPiel") = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("piel_pielid").Value.ToString)
                                                                        ' ''Fila("idColor") = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("color_colorid").Value.ToString)
                                                                        ' ''Fila("pielColor") = grdPieles.Rows(contPiel).Cells("pielcol").Value.ToString
                                                                        ' ''Fila("idFamilia") = Convert.ToInt32(grdFamilia.Rows(contFamilia).Cells("fami_familiaid").Value.ToString)
                                                                        ' ''Fila("familia") = grdFamilia.Rows(contFamilia).Cells("fami_descripcion").Value.ToString
                                                                        ' ''Fila("idLinea") = Convert.ToInt32(grdLinea.Rows(contLinea).Cells("linea_lineaid").Value.ToString)
                                                                        ' ''Fila("linea") = grdLinea.Rows(contLinea).Cells("linea_descripcion").Value.ToString
                                                                        ' ''Fila("idTalla") = Convert.ToInt32(grdTalla.Rows(contTalla).Cells("talla_tallaid").Value.ToString)
                                                                        ' ''Fila("talla") = grdTalla.Rows(contTalla).Cells("talla_descripcion").Value.ToString
                                                                        ' ''Fila("idCorte") = Convert.ToInt32(grdCorte.Rows(contCorte).Cells("plmu_pielmuestraid").Value.ToString)
                                                                        ' ''Fila("corte") = grdCorte.Rows(contCorte).Cells("plmu_descripcion").Value.ToString
                                                                        ' ''Fila("idForro") = Convert.ToInt32(grdForros.Rows(contForro).Cells("forr_forroid").Value.ToString)
                                                                        ' ''Fila("forro") = grdForros.Rows(contForro).Cells("forr_descripcion").Value.ToString
                                                                        ' ''Fila("idSuela") = Convert.ToInt32(grdSuela.Rows(contSuela).Cells("suel_suelaid").Value.ToString)
                                                                        ' ''Fila("suela") = grdSuela.Rows(contSuela).Cells("suel_descripcion").Value.ToString
                                                                        ' ''Fila("idHorma") = CInt(idHorma)
                                                                        ' ''Fila("Horma") = lblNombreHorma.Text

                                                                        If (codSicyMarca <> Nothing And codSicyColeccion <> Nothing And txtCodSicy.Text <> Nothing And grdPieles.Rows(contPiel).Cells("sicypcol").Value.ToString <> Nothing) Then
                                                                            Dim sicy As String = txtCodSicy.Text
                                                                            If (sicy.Length >= 3) Then
                                                                                If (sicy.Length = 3) Then
                                                                                    ' ''Fila("Sicy") = codSicyMarca + codSicyColeccion + "0" + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("sicypcol").Value.ToString
                                                                                    rowEstilo.Cells("Sicy").Value = codSicyMarca + codSicyColeccion + "0" + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("sicypcol").Value.ToString
                                                                                ElseIf (sicy.Length > 3) Then
                                                                                    ' ''Fila("Sicy") = codSicyMarca + codSicyColeccion + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("sicypcol").Value.ToString
                                                                                    rowEstilo.Cells("Sicy").Value = codSicyMarca + codSicyColeccion + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("sicypcol").Value.ToString
                                                                                End If
                                                                            End If
                                                                        Else
                                                                            ' ''Fila("Sicy") = ""
                                                                            rowEstilo.Cells("Sicy").Value = ""
                                                                        End If
                                                                        If (grdPieles.Rows(contPiel).Cells("sicypcol").Value.ToString <> Nothing) Then
                                                                            ' ''Fila("sicyPCOL") = grdPieles.Rows(contPiel).Cells("sicypcol").Value.ToString
                                                                            rowEstilo.Cells("sicyPCOL").Value = grdPieles.Rows(contPiel).Cells("sicypcol").Value.ToString
                                                                        Else
                                                                            ' ''Fila("sicyPCOL") = ""
                                                                            rowEstilo.Cells("sicyPCOL").Value = ""
                                                                        End If
                                                                        ' ''Fila("seleccion") = False
                                                                        ' ''Fila("IdMarcaCasa") = codSicyMarca
                                                                        ' ''Fila("psEstatus") = idEstatusCBO
                                                                        ' ''Fila("nomSts") = nombreEstatus
                                                                        rowEstilo.Cells("seleccion").Value = False
                                                                        rowEstilo.Cells("IdMarcaCasa").Value = codSicyMarca
                                                                        rowEstilo.Cells("psEstatus").Value = idEstatusCBO
                                                                        rowEstilo.Cells("nomSts").Value = nombreEstatus
                                                                        ' ''tablaDetalle.Rows.Add(Fila)
                                                                        nuevaFila = nuevaFila + 1
                                                                    End If
                                                                End If
                                                                contCorte = contCorte + 1
                                                            Next
                                                        End If
                                                        contSuela = contSuela + 1
                                                    Next
                                                End If
                                                contForro = contForro + 1
                                            Next
                                        End If
                                        contLinea = contLinea + 1
                                    Next
                                End If
                                contFamilia = contFamilia + 1
                            Next
                        End If
                        contTalla = contTalla + 1
                    Next
                End If
                contPiel = contPiel + 1
            Next
            ' ''Me.grdDetallesEstilos.DataSource = tablaDetalle

            Dim tamP As Int32 = 0
            Dim tamConsulta As Int32 = dtDetallesProducto.Rows.Count
            For Each rowPinta As UltraGridRow In grdDetallesEstilos.Rows
                If (tamP < tamConsulta) Then
                    For Each rowDT As DataRow In dtDetallesProducto.Rows
                        'If (rowPinta.Cells("pstilo").Value = rowDT.Item("pstilo").ToString And
                        '    rowPinta.Cells("idPiel").Value.ToString = rowDT.Item("idPiel").ToString And
                        '    rowPinta.Cells("idColor").Value.ToString = rowDT.Item("idColor").ToString And
                        '    rowPinta.Cells("idTalla").Value.ToString = rowDT.Item("idTalla").ToString And
                        '    rowPinta.Cells("idFamilia").Value.ToString = rowDT.Item("idFamilia").ToString And
                        '    rowPinta.Cells("idLinea").Value.ToString = rowDT.Item("idLinea").ToString And
                        '    rowPinta.Cells("idCorte").Value.ToString = rowDT.Item("idCorte").ToString And
                        '    rowPinta.Cells("idForro").Value.ToString = rowDT.Item("idForro").ToString And
                        '    rowPinta.Cells("idSuela").Value.ToString = rowDT.Item("idSuela").ToString And
                        '    rowPinta.Cells("idHorma").Value.ToString = rowDT.Item("idHorma").ToString) Then
                        If rowPinta.Cells("pstilo").Value = rowDT.Item("pstilo").ToString Then
                            ' ''rowPinta.Appearance.ForeColor = Color.LimeGreen
                            rowPinta.Cells("psEstatus").Value = rowDT.Item("psEstatus").ToString
                            rowPinta.Cells("nomSts").Value = rowDT.Item("nomSts").ToString
                            rowPinta.Appearance.FontData.Bold = DefaultableBoolean.True
                            ' ''rowPinta.Appearance.ForeColor = Color.MidnightBlue
                            rowPinta.Appearance.BorderColor = Color.DodgerBlue
                            rowPinta.Appearance.BackColor = Color.Silver
                            tamP = tamP + 1
                        End If
                    Next
                End If
            Next
            estiloGridEstilos()
        Catch ex As Exception
            Dim advertenciaMensaje As New AdvertenciaForm
            advertenciaMensaje.mensaje = "Para agregar nuevos registros debe seleccionar un estatus."
            advertenciaMensaje.ShowDialog()
            'MsgBox("Para agregar nuevos registros debe seleccionar un estatus.")
        End Try
    End Sub


    Public Sub LlenarTablaDetallesEstilosProductoCliente()
        Try
            Dim idEstatusCBO As Int32 = cmbEstatus.SelectedValue
            Dim nombreEstatus As String = cmbEstatus.Text
            Dim nuevaFila As Int32 = 0
            Dim contPiel As Int32 = 0
            Dim contador As Int32 = 0
            Dim dtTablaDatos As New DataTable
            If (grdDetallesEstilos.Rows.Count > 0) Then
                dtTablaDatos = grdDetallesEstilos.DataSource
            End If
            Dim objPBU As New Programacion.Negocios.ProductosBU
            Dim dtDetallesProducto As DataTable
            dtDetallesProducto = New DataTable
            dtDetallesProducto = objPBU.verDetallesProductoEditar(idProducto)
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
            Dim Fila As DataRow
            'Instanciando una nueva fila (row)   
            tablaDetalle.Columns.Add("pstilo", GetType(String))
            tablaDetalle.Columns.Add("idPiel", GetType(Int32))
            tablaDetalle.Columns.Add("idColor", GetType(Int32))
            tablaDetalle.Columns.Add("pielColor", GetType(String))
            tablaDetalle.Columns.Add("idTalla", GetType(Int32))
            tablaDetalle.Columns.Add("talla", GetType(String))
            tablaDetalle.Columns.Add("idFamilia", GetType(Int32))
            tablaDetalle.Columns.Add("familia", GetType(String))
            tablaDetalle.Columns.Add("idLinea", GetType(Int32))
            tablaDetalle.Columns.Add("linea", GetType(String))
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
            tablaDetalle.Columns.Add("IdMarcaCasa", GetType(String))
            tablaDetalle.Columns.Add("psEstatus", GetType(Int32))
            tablaDetalle.Columns.Add("nomSts", GetType(String))
            tablaDetalle.Columns.Add("seleccion", GetType(Boolean))
            'Me.grdDetallesEstilosProductoNormal.Rows.Clear()
            For Each rowPiel As UltraGridRow In grdPieles.Rows
                If (CBool(rowPiel.Cells("selectPcol").Value) = True) Then
                    Dim contTalla As Int32 = 0
                    For Each rowTalla As UltraGridRow In grdTalla.Rows
                        If (CBool(rowTalla.Cells("selectTalla").Value) = True) Then
                            Dim contFamilia As Int32 = 0
                            For Each rowFamilia As UltraGridRow In grdFamilia.Rows
                                If (CBool(rowFamilia.Cells("selectFamilia").Value) = True) Then
                                    Dim contLinea As Int32 = 0
                                    For Each rowLinea As UltraGridRow In grdLinea.Rows
                                        If (CBool(rowLinea.Cells("selectLinea").Value) = True) Then
                                            Dim contForro As Int32 = 0
                                            For Each rowForro As UltraGridRow In grdForros.Rows
                                                If (CBool(rowForro.Cells("selectForro").Value) = True) Then
                                                    Dim contSuela As Int32 = 0
                                                    For Each rowSuela As UltraGridRow In grdSuela.Rows
                                                        If (CBool(rowSuela.Cells("selectSuela").Value) = True) Then
                                                            Dim contCorte As Int32 = 0
                                                            For Each rowCorte As UltraGridRow In grdCorte.Rows
                                                                If (CBool(rowCorte.Cells("selectCorte").Value) = True) Then
                                                                    Fila = tablaDetalle.NewRow
                                                                    Fila("pstilo") = ""
                                                                    Fila("idPiel") = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("piel_pielid").Value.ToString)
                                                                    Fila("idColor") = Convert.ToInt32(grdPieles.Rows(contPiel).Cells("color_colorid").Value.ToString)
                                                                    Fila("pielColor") = grdPieles.Rows(contPiel).Cells("pielcol").Value.ToString
                                                                    Fila("idFamilia") = Convert.ToInt32(grdFamilia.Rows(contFamilia).Cells("fami_familiaid").Value.ToString)
                                                                    Fila("familia") = grdFamilia.Rows(contFamilia).Cells("fami_descripcion").Value.ToString
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
                                                                    If (codSicyMarca <> Nothing And codSicyColeccion <> Nothing And txtCodSicy.Text <> Nothing And grdPieles.Rows(contPiel).Cells("sicyPCOL").Value.ToString <> Nothing) Then
                                                                        Dim sicy As String = txtCodSicy.Text
                                                                        If (sicy.Length >= 3) Then
                                                                            If (sicy.Length = 3) Then
                                                                                Fila("Sicy") = codSicyMarca + codSicyColeccion + "0" + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("sicyPCOL").Value.ToString
                                                                            ElseIf (sicy.Length > 3) Then
                                                                                Fila("Sicy") = codSicyMarca + codSicyColeccion + txtCodSicy.Text + grdPieles.Rows(contPiel).Cells("sicyPCOL").Value.ToString
                                                                            End If
                                                                        End If
                                                                    Else
                                                                        Fila("Sicy") = ""
                                                                    End If

                                                                    If (grdPieles.Rows(contPiel).Cells(3).Value.ToString <> Nothing) Then
                                                                        Fila("sicyPCOL") = grdPieles.Rows(contPiel).Cells("sicyPCOL").Value.ToString
                                                                    Else
                                                                        Fila("sicyPCOL") = ""
                                                                    End If
                                                                    Fila("IdMarcaCasa") = codSicyMarca
                                                                    Fila("psEstatus") = idEstatusCBO
                                                                    Fila("nomSts") = nombreEstatus
                                                                    Fila("seleccion") = False
                                                                    ' ''Adicionando a la tabla la nueva fila       
                                                                    tablaDetalle.Rows.Add(Fila)
                                                                    nuevaFila = nuevaFila + 1

                                                                End If
                                                                contCorte = contCorte + 1
                                                            Next
                                                        End If
                                                        contSuela = contSuela + 1
                                                    Next
                                                End If
                                                contForro = contForro + 1
                                            Next
                                        End If
                                        contLinea = contLinea + 1
                                    Next
                                End If
                                contFamilia = contFamilia + 1
                            Next
                        End If
                        contTalla = contTalla + 1
                    Next
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
                If (tablaDetalle.Rows.Count > 0) Then
                    If (dtTablaDatos.Rows.Count > 0) Then
                        For Each rowEstilo As DataRow In dtTablaDatos.Rows
                            Fila = tablaDetalle.NewRow
                            Fila("pstilo") = rowEstilo("pstilo").ToString
                            Fila("idPiel") = Convert.ToInt32(rowEstilo("idPiel").ToString)
                            Fila("idColor") = Convert.ToInt32(rowEstilo("idColor").ToString)
                            Fila("pielColor") = rowEstilo("pielColor").ToString
                            Fila("idTalla") = Convert.ToInt32(rowEstilo("idTalla").ToString)
                            Fila("talla") = rowEstilo("talla").ToString
                            Fila("idFamilia") = Convert.ToInt32(rowEstilo("idFamilia").ToString)
                            Fila("familia") = rowEstilo("familia").ToString
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
                            If (rowEstilo("Sicy").ToString <> Nothing) Then
                                Fila("Sicy") = rowEstilo("Sicy").ToString
                                Fila("sicyPCOL") = rowEstilo("sicyPCOL").ToString
                            Else
                                Fila("Sicy") = ""
                                Fila("sicyPCOL") = ""
                            End If
                            Fila("seleccion") = CBool(rowEstilo("seleccion").ToString)
                            Fila("IdMarcaCasa") = rowEstilo("IdMarcaCasa").ToString
                            Fila("psEstatus") = rowEstilo("psEstatus").ToString
                            Fila("nomSts") = rowEstilo("nomSts").ToString
                            tablaDetalle.Rows.Add(Fila)
                        Next
                    End If
                End If
                If (tablaDetalle.Rows.Count > 0) Then
                    Me.grdDetallesEstilos.DataSource = tablaDetalle
                Else
                    Me.grdDetallesEstilos.DataSource = dtTablaDatos
                End If
                Dim tamP As Int32 = 0
                Dim tamConsulta As Int32 = dtDetallesProducto.Rows.Count
                For Each rowPinta As UltraGridRow In grdDetallesEstilos.Rows
                    If (tamP < tamConsulta) Then
                        For Each rowDT As DataRow In dtDetallesProducto.Rows
                            If (rowPinta.Cells("idPiel").Value.ToString = rowDT.Item("idPiel").ToString And
                              rowPinta.Cells("idColor").Value.ToString = rowDT.Item("idColor").ToString And
                              rowPinta.Cells("idTalla").Value.ToString = rowDT.Item("idTalla").ToString And
                              rowPinta.Cells("idFamilia").Value.ToString = rowDT.Item("idFamilia").ToString And
                              rowPinta.Cells("idLinea").Value.ToString = rowDT.Item("idLinea").ToString And
                              rowPinta.Cells("idCorte").Value.ToString = rowDT.Item("idCorte").ToString And
                              rowPinta.Cells("idForro").Value.ToString = rowDT.Item("idForro").ToString And
                              rowPinta.Cells("idSuela").Value.ToString = rowDT.Item("idSuela").ToString And
                              rowPinta.Cells("idHorma").Value.ToString = rowDT.Item("idHorma").ToString) Then
                                ''rowPinta.Appearance.ForeColor = Color.LimeGreen
                                rowPinta.Appearance.FontData.Bold = DefaultableBoolean.True
                                ''rowPinta.Appearance.ForeColor = Color.DimGray
                                rowPinta.Appearance.BorderColor = Color.DodgerBlue
                                rowPinta.Appearance.BackColor = Color.Silver
                                tamP = tamP + 1
                            End If
                        Next
                    End If
                Next
            End If
            estiloGridEstilos()
        Catch ex As Exception
            MsgBox("Para agregar nuevos registros debe seleccionar un estatus.")
        End Try
    End Sub


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


    Public Sub estiloGridEstilos()

        'grdDetallesEstilos.DisplayLayout.Bands(0).Columns("Clave SAT").Width = 90
        'grdDetallesEstilos.DisplayLayout.Bands(0).Columns("Clave SAT").Style = ColumnStyle.DropDownList
        'grdDetallesEstilos.DisplayLayout.Bands(0).Columns("Clave SAT").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

        With grdDetallesEstilos.DisplayLayout.Bands(0)

            .Columns("Fracción_Arancelaria").Header.Caption = "Fracción Arancelaria"
            .Columns("idClaveSAT").Header.Caption = "Clave SAT"
            .Columns("pstilo").Header.Caption = "Id Estilo"
            .Columns("nomSts").Header.Caption = "Estatus"
            .Columns("pielColor").Header.Caption = "Piel Color"
            .Columns("talla").Header.Caption = "Corrida"
            .Columns("familia").Header.Caption = "Familia"
            .Columns("linea").Header.Caption = "Linea"
            .Columns("idLinea").Header.Caption = "Linea"
            .Columns("corte").Header.Caption = "Corte"
            .Columns("idCorte").Header.Caption = "Corte"
            .Columns("forro").Header.Caption = "Forro"
            .Columns("idForro").Header.Caption = "Forro"
            .Columns("suela").Header.Caption = "Suela"
            .Columns("idSuela").Header.Caption = "Suela"
            .Columns("Horma").Header.Caption = "Horma"
            .Columns("Sicy").Header.Caption = "SICY"

            .Columns("SuelaProgramacion").Header.Caption = "Suela Programación"
            .Columns("ColorSuela").Header.Caption = "Color Suela"

            If permiso = True Then
                .Columns("seleccion").CellActivation = Activation.AllowEdit
                .Columns("Nuevo").CellActivation = Activation.NoEdit
                Me.grdDetallesEstilos.DisplayLayout.Bands(0).Columns("seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                Me.grdDetallesEstilos.DisplayLayout.Bands(0).Columns("seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                Me.grdDetallesEstilos.DisplayLayout.Bands(0).Columns("seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.None
            Else
                .Columns("seleccion").CellActivation = Activation.Disabled
                .Columns("Nuevo").CellActivation = Activation.Disabled
            End If

            .Columns("seleccion").Header.Caption = ""
            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .Columns("Nuevo").Header.Caption = "Nuevo"
            .Columns("familia ventas").Header.Caption = "Familia de Ventas"
            .Columns("idFamiliaVentas").Header.Caption = "Familia de Ventas"
            .Columns("familia ventas").Hidden = True
            .Columns("referencia").Hidden = True
            '.Columns("idFamiliaVentas").Hidden = True
            '.Columns("pstilo").Hidden = True
            .Columns("tipo").Hidden = True
            .Columns("idtipo").Hidden = True
            .Columns("psEstatus").Hidden = True
            .Columns("idPiel").Hidden = True
            .Columns("idColor").Hidden = True
            .Columns("idTalla").Hidden = True
            .Columns("idFamilia").Hidden = True
            '.Columns("linea").Hidden = True '31/07/2020
            .Columns("corte").Hidden = True
            .Columns("forro").Hidden = True
            .Columns("suela").Hidden = True
            .Columns("idHorma").Hidden = True
            .Columns("sicyPCOL").Hidden = True
            .Columns("IdMarcaCasa").Hidden = True
            .Columns("ClaveSAT").Hidden = True
            .Columns("SuelaProgramacionID").Hidden = True
            .Columns("ColorSuelaid").Hidden = True
            .Columns("ColorSuela").Hidden = True
            .Columns("prod_productoid").Hidden = True
            ' .Columns("Sicy").Hidden = True
            '.Columns("Familia").Hidden = True '31/07/2020 mostrar familia
            .Columns("Nuevo").Hidden = True
            .Columns("Seleccion").Hidden = True
            .Columns("Fracción_Arancelaria").Hidden = True
            .Columns("pstilo").Hidden = True
            .Columns("idLinea").Hidden = True





            .Columns("pstilo").CellActivation = Activation.NoEdit
            '.Columns("familia ventas").CellActivation = Activation.NoEdit
            .Columns("nomSts").CellActivation = Activation.NoEdit
            .Columns("pielColor").CellActivation = Activation.NoEdit
            .Columns("talla").CellActivation = Activation.NoEdit
            .Columns("familia").CellActivation = Activation.NoEdit
            .Columns("idLinea").CellActivation = Activation.AllowEdit
            .Columns("idCorte").CellActivation = Activation.AllowEdit
            .Columns("idForro").CellActivation = Activation.AllowEdit
            .Columns("idSuela").CellActivation = Activation.AllowEdit

            '  .Columns("Horma").CellActivation = Activation.NoEdit Ticket 16345

            .Columns("Sicy").CellActivation = Activation.NoEdit
            .Columns("Fracción_Arancelaria").CellActivation = Activation.NoEdit
            .Columns("SuelaProgramacionID").CellActivation = Activation.NoEdit
            .Columns("SuelaProgramacion").CellActivation = Activation.NoEdit
            .Columns("ColorSuelaID").CellActivation = Activation.NoEdit
            .Columns("ColorSuela").CellActivation = Activation.NoEdit

            .Columns("Horma").Style = ColumnStyle.DropDownList

            .Columns("idClaveSAT").Style = ColumnStyle.DropDownList
            '.Columns("idClaveSAT").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            '28/05/2020 Isabel Guerrero
            .Columns("idClaveSAT").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            '.DisplayLayout.Override.RowSelectorNumberStyle = Infragisti                cs.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
            .Summaries.Clear()

            .Columns("Horma").CellAppearance.TextHAlign = HAlign.Right
            '.DisplayLayout.Bands(0).Columns(2).Width = 210
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        With grdDetallesEstilos.DisplayLayout
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns

        End With

        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("Fracción_Arancelaria").Width = 160
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("idClaveSAT").Width = 90
        grdDetallesEstilos.DisplayLayout.Bands(0).Columns("nomSts").Width = 130


        grdDetallesEstilos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDetallesEstilos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDetallesEstilos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        If grdDetallesEstilos.Rows.Count > 0 Then
            grdDetallesEstilos.Rows(0).Selected = True
        End If

    End Sub

    Public Function validaExisteProducto() As Boolean
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtExisteProd As DataTable
        Dim codProd As String = txtCodigo.Text.Trim
        dtExisteProd = objPBU.validarExistenciaProducto(codProd)
        If (codigo <> txtCodigo.Text) Then
            If (dtExisteProd.Rows.Count >= 1) Then
                Return False
            End If
        End If
        If (txtCodigo.Text.Trim = Nothing) Then
            Return False
        End If
        Return True
    End Function

    Public Function validarVacio() As Boolean
        If (txtCodigo.Text = Nothing Or txtColeccion.Text = Nothing Or txtDescripcion.Text = Nothing Or
            txtMarca.Text = Nothing Or txtHorma.Text = Nothing Or
            txtCategoria.Text = Nothing) Then
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
            If (txtCategoria.Text = Nothing) Then
                lblCategoria.ForeColor = Drawing.Color.Red
            Else
                lblCategoria.ForeColor = Drawing.Color.Black
            End If
            If (txtMarca.Text = Nothing) Then
                lblMarca.ForeColor = Drawing.Color.Red
            Else
                lblMarca.ForeColor = Drawing.Color.Black
            End If
            If (txtSubfamilia.Text = Nothing) Then
                lblSubfamilia.ForeColor = Drawing.Color.Red
            Else
                lblSubfamilia.ForeColor = Drawing.Color.Black
            End If
            If (txtTemporada.Text = Nothing) Then
                lblTemporada.ForeColor = Drawing.Color.Red
            Else
                lblTemporada.ForeColor = Drawing.Color.Black
            End If

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

            If txtSuelaProgramacion.Text = String.Empty Then
                lblSuelaProgramacion.ForeColor = Color.Red
            Else
                lblSuelaProgramacion.ForeColor = Color.Black
            End If

            If txtColorSuela.Text = String.Empty Then
                lblColorSuela.ForeColor = Color.Red
            Else
                lblColorSuela.ForeColor = Color.Black
            End If

            Return False
        Else
            lblCodigo.ForeColor = Drawing.Color.Black
            lblMarca.ForeColor = Drawing.Color.Black
            lblColeccion.ForeColor = Drawing.Color.Black
            lblCategoria.ForeColor = Drawing.Color.Black
            lblDescripcion.ForeColor = Drawing.Color.Black
            lblSubfamilia.ForeColor = Drawing.Color.Black
            lblTemporada.ForeColor = Drawing.Color.Black
            lblHorma.ForeColor = Color.Black
            lblGrupo.ForeColor = Color.Black
            lblSuelaProgramacion.ForeColor = Color.Black
            lblColorSuela.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Function validarDetalle() As Boolean
        contadorValida = 0
        Dim recorre As Int32 = 0
        For Each row As UltraGridRow In grdDetallesEstilos.Rows
            If (row.Cells("seleccion").Value = False) Then
                contadorValida = contadorValida + 1
            End If
            recorre = recorre + 1
        Next
        If (contadorValida <= 0) Then
            Return False
        End If
        Return True
    End Function

    Public Function validarExisteOtroRegistro() As Boolean
        Dim objProdBU As New Programacion.Negocios.ProductosBU
        Dim dtExiste As New DataTable
        Dim dtExisteInactivo As New DataTable
        Dim valorReturn As Boolean = True
        Dim piel As String = String.Empty
        Dim color As String = String.Empty
        Dim talla As String = String.Empty
        Dim corte As String = String.Empty
        Dim forro As String = String.Empty
        Dim suela As String = String.Empty
        Dim horma As String = String.Empty
        Dim codigoSicyProd As String = String.Empty
        Dim sicyMarca As String = String.Empty
        Dim familia As String = String.Empty
        Dim linea As String = String.Empty
        Dim prEstilo As String = String.Empty
        Dim idEstatusPRS As String = String.Empty
        Dim contadorExiste As Int32 = 0
        Dim contadorExisteInactivo As Int32 = 0
        Dim mensajeExisteMas As Boolean = False

        For Each rowDetalle As UltraGridRow In grdDetallesEstilos.Rows
            contadorExiste = 0
            piel = rowDetalle.Cells("idPiel").Value().ToString
            color = rowDetalle.Cells("idColor").Value().ToString
            talla = rowDetalle.Cells("idTalla").Value().ToString
            corte = rowDetalle.Cells("idCorte").Value().ToString
            forro = rowDetalle.Cells("idForro").Value().ToString
            suela = rowDetalle.Cells("idSuela").Value().ToString
            horma = rowDetalle.Cells("IdHorma").Value().ToString
            codigoSicyProd = rowDetalle.Cells("Sicy").Value().ToString
            sicyMarca = rowDetalle.Cells("IdMarcaCasa").Value().ToString
            familia = rowDetalle.Cells("idFamilia").Value().ToString
            linea = rowDetalle.Cells("idLinea").Value().ToString
            prEstilo = rowDetalle.Cells("pstilo").Value().ToString
            idEstatusPRS = rowDetalle.Cells("psEstatus").Value().ToString


            If prEstilo <> "" Then
                dtExiste = New DataTable
                dtExiste = objProdBU.consultarExisteEstilo(idProducto, piel, color, talla, familia, linea, corte, forro, suela, horma, prEstilo, False)
                '  dtExiste = objProdBU.consultarExisteEstilo(idProducto, piel, color, talla, corte, forro, suela, horma, prEstilo, False) '17/09/2020
                contadorExiste = CInt(dtExiste.Rows(0).Item(0).ToString)

                dtExisteInactivo = New DataTable
                '  dtExisteInactivo = objProdBU.consultarExisteEstilo(idProducto, piel, color, talla, corte, forro, suela, horma, prEstilo, True) '17/09/2020
                dtExisteInactivo = objProdBU.consultarExisteEstilo(idProducto, piel, color, talla, familia, linea, corte, forro, suela, horma, prEstilo, True)
                contadorExisteInactivo = CInt(dtExisteInactivo.Rows(0).Item(0).ToString)
                ' ''    dtExiste = objProdBU.consultarExisteEstilo(idProducto, piel, color, talla, familia, linea, corte, forro, suela, horma, prEstilo, True)
                ' ''    contadorExiste = CInt(dtExiste.Rows(0).Item(0).ToString)
            Else
                contadorExiste = 0
            End If

            If contadorExiste > 0 Then
                valorReturn = False
                mensajeExisteMas = True
                rowDetalle.Appearance.BackColor = Drawing.Color.LightCoral
                rowDetalle.Appearance.BorderColor = Drawing.Color.Maroon
            End If

        Next

        Dim seRepiteEnLista As Int32 = 0
        Dim repetidosLista As Boolean = False
        For Each rowVal As UltraGridRow In grdDetallesEstilos.Rows
            For Each rowDT As UltraGridRow In grdDetallesEstilos.Rows
                If rowVal.Cells("idPiel").Value().ToString() = rowDT.Cells("idPiel").Value().ToString() And
                    rowVal.Cells("idColor").Value().ToString() = rowDT.Cells("idColor").Value().ToString() And
                    rowVal.Cells("idTalla").Value().ToString() = rowDT.Cells("idTalla").Value().ToString() And
                    rowVal.Cells("idCorte").Value().ToString() = rowDT.Cells("idCorte").Value().ToString() And
                    rowVal.Cells("idForro").Value().ToString() = rowDT.Cells("idForro").Value().ToString() And
                    rowVal.Cells("idSuela").Value().ToString() = rowDT.Cells("idSuela").Value().ToString() And
                    rowVal.Cells("IdHorma").Value().ToString() = rowDT.Cells("IdHorma").Value().ToString() And
                    rowVal.Cells("idFamilia").Value().ToString() = rowDT.Cells("idFamilia").Value().ToString() And
                     rowVal.Cells("idFamiliaVentas").Value().ToString() = rowDT.Cells("idFamiliaVentas").Value().ToString() And
                    rowVal.Cells("idLinea").Value().ToString() = rowDT.Cells("idLinea").Value().ToString() Then

                    seRepiteEnLista += 1
                End If
            Next
            If seRepiteEnLista > 1 Then
                repetidosLista = True
                rowVal.Appearance.BackColor = Drawing.Color.LightCoral
                rowVal.Appearance.BorderColor = Drawing.Color.Maroon
                valorReturn = False
            End If
            seRepiteEnLista = 0
        Next

        Dim mensajeCad As String = ""
        If mensajeExisteMas = True Or repetidosLista = True Then
            mensajeCad = "No pueden modificarse los campos del(los) artículo(s) resaltado(s) en color rojo, debido a que ya existe otro con la misma descripción"
        End If
        If contadorExisteInactivo > 0 Then
            mensajeCad += " y que se encuentra inactivo (s), para activar este(os)  artículo(s) debe seleccionar nuevamente todos los campos y agregar el(los) artículo(s)."
        End If
        If valorReturn = False Then
            MsgBox(mensajeCad, MsgBoxStyle.Exclamation, "¡Importante!")
        Else

        End If

        Return valorReturn
    End Function

    Public Sub validacionesGuardar()
        Dim objProdBU As New Programacion.Negocios.ProductosBU
        If (validarVacio() = True) Then
            If (idColeccion <> 0 And idMarca >= 0 And idTemporada <> 0 And consecutivo <> Nothing And idHorma <> 0 And idCategoria <> 0 And IDSuelaProgramacion <> 0) Then
                If idSubFamilia <> 0 Or dtSubfamilias IsNot Nothing Then
                    If (validarDetalle() = True) Then
                        If (validaExisteProducto() = True) Then
                            If (validarRepetidos() = True) Then
                                If (validarClaveSAT() = True) Then
                                    If ValidarArticulosNoAutorizados() = True Then
                                        If validarMarcaCasa() = True Then
                                            'If validarCodigoSicy() = True Then
                                            Dim objMensaje As New Tools.ConfirmarForm
                                                objMensaje.mensaje = "¿Está seguro de guardar cambios?"
                                                If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                                                    ' ''Dim recorre As Int32 = 0
                                                    Dim modelo As String = txtCodSicy.Text
                                                    GenerarCadenaImagenes()
                                                    validarCodSicy()
                                                    Dim EnProducto As New Entidades.Productos
                                                    EnProducto.PidProd = idProducto
                                                    EnProducto.PCodigoProd = txtCodigo.Text.Trim
                                                    EnProducto.PDescripcionProd = txtDescripcion.Text.Trim
                                                    EnProducto.PMarcaProd = idMarca.ToString

                                                    EnProducto.PColeccionProd = idColeccion
                                                    EnProducto.PTemporadaProd = idTemporada
                                                    EnProducto.PCodigoSicy = txtCodSicy.Text.Trim
                                                    'EnProducto.PGrupoProd = idGrupo

                                                    EnProducto.PFoto = cadenaFoto
                                                    EnProducto.PDibujo = cadenaDibujo
                                                    EnProducto.PConsecutivo = consecutivo
                                                    EnProducto.PCodCliente = txtCodCliente.Text
                                                    EnProducto.PCategoria = idCategoria

                                                    EnProducto.PActivoProd = CBool(rdoActivo.Checked)

                                                    EnProducto.PmodeloSAYLicencia = txtCodigo.Text

                                                    'objProdBU.EditarProducto(EnProducto, modelo, idcedis, esLicencia)
                                                    objProdBU.EditarProducto(EnProducto, modelo)
                                                    objProdBU.desactivarSubfamilias(idProducto)

                                                    If idSubFamilia > 0 Then
                                                        objProdBU.editarProductoSubfamilia(idProducto, idSubFamilia)
                                                    ElseIf dtSubfamilias IsNot Nothing Then
                                                        For Each rowDTS As DataRow In dtSubfamilias.Rows
                                                            objProdBU.editarProductoSubfamilia(idProducto, CInt(rowDTS.Item("idSubfamilia").ToString))
                                                        Next
                                                    End If

                                                    objProdBU.EditarProductoEstilo(idProducto)
                                                    Dim piel As String = String.Empty
                                                    Dim color As String = String.Empty
                                                    Dim talla As String = String.Empty
                                                    Dim corte As String = String.Empty
                                                    Dim forro As String = String.Empty
                                                    Dim suela As String = String.Empty
                                                    Dim horma As String = String.Empty
                                                    Dim codigoSicyProd As String = String.Empty
                                                    Dim sicyMarca As String = String.Empty
                                                    Dim familia As String = String.Empty
                                                    Dim familiaV As String = String.Empty
                                                    Dim linea As String = String.Empty
                                                    Dim prEstilo As String = String.Empty
                                                    Dim idEstatusPRS As String = String.Empty
                                                    Dim activo As String = "True"
                                                    Dim idClaveSAT As String = String.Empty
                                                    Dim SuelaProgramacionID As Integer = 0
                                                    Dim ColorSuelaID As Integer = 0
                                                    Dim Modeloreferencia As String = String.Empty
                                                    For Each rowDetalle As UltraGridRow In grdDetallesEstilos.Rows
                                                        piel = rowDetalle.Cells("idPiel").Value().ToString
                                                        color = rowDetalle.Cells("idColor").Value().ToString
                                                        talla = rowDetalle.Cells("idTalla").Value().ToString
                                                        corte = rowDetalle.Cells("idCorte").Column.ValueList.GetValue(rowDetalle.Cells("idCorte").Value.ToString, 0)
                                                        forro = rowDetalle.Cells("idForro").Column.ValueList.GetValue(rowDetalle.Cells("idForro").Value.ToString, 0)
                                                        suela = rowDetalle.Cells("idSuela").Column.ValueList.GetValue(rowDetalle.Cells("idSuela").Value.ToString, 0)
                                                        Modeloreferencia = txtModeloReferencia.Text.ToString
                                                        horma = rowDetalle.Cells("IdHorma").Value().ToString
                                                        'horma = rowDetalle.Cells("IdHorma").Column.ValueList.GetValue(rowDetalle.Cells("HormaID").Value.ToString, 0)    '.Value().ToString ' ticket 16344
                                                        ' horma = idHorma
                                                        'horma = rowDetalle.Cells("IdHorma").Value().ToString
                                                        codigoSicyProd = rowDetalle.Cells("Sicy").Value().ToString '22/06/2020 quitar
                                                        sicyMarca = rowDetalle.Cells("IdMarcaCasa").Value().ToString
                                                        familia = rowDetalle.Cells("idFamilia").Value().ToString '22/06/2020 quitar ' 31/07/2020 se ocupa para otros proceso
                                                        familiaV = rowDetalle.Cells("idFamiliaVentas").Column.ValueList.GetValue(rowDetalle.Cells("idFamiliaVentas").Value.ToString, 0) 'rowDetalle.Cells("idFamiliaVentas").Value().ToString
                                                        '22/06/2020 quitar
                                                        linea = rowDetalle.Cells("idLinea").Column.ValueList.GetValue(rowDetalle.Cells("idLinea").Value.ToString, 0)
                                                        '22/06/2020 quitar
                                                        prEstilo = rowDetalle.Cells("pstilo").Value().ToString

                                                        idEstatusPRS = rowDetalle.Cells("psEstatus").Value().ToString
                                                        idClaveSAT = rowDetalle.Cells("idClaveSAT").Column.ValueList.GetValue(rowDetalle.Cells("idClaveSAT").Value.ToString, 0)
                                                        SuelaProgramacionID = rowDetalle.Cells("SuelaProgramacionID").Value().ToString
                                                        ColorSuelaID = rowDetalle.Cells("ColorSuelaID").Value().ToString
                                                        objProdBU.EditarDetalleProducto(idProducto, piel, talla, color, corte, forro, suela, activo, codigoSicyProd, horma, sicyMarca, familia, linea, prEstilo, idEstatusPRS, familiaV, idClaveSAT, SuelaProgramacionID, ColorSuelaID, Modeloreferencia)
                                                        ' ''recorre = recorre + 1
                                                    Next
                                                    codigoProducto = txtCodigo.Text
                                                    registrarImagenesFTP()
                                                    cerrarGuardar = True
                                                    exitoMensaje.mensaje = "El registro se realizó con éxito."
                                                    exitoMensaje.ShowDialog()
                                                    Me.Close()
                                                Else
                                                    Exit Sub
                                                End If
                                            'ElseIf validarCodigoSicy() = False Then
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
                                        advertenciaMensaje.mensaje = "Los Artículos a No Autorizar se encuentran en Pedidos activos, se debe primero cancelar las partidas y volver a intentarlo."
                                        advertenciaMensaje.ShowDialog()
                                    End If
                                ElseIf validarClaveSAT() = False Then
                                    Dim advertenciaMensaje As New AdvertenciaForm
                                    advertenciaMensaje.mensaje = "Hace falta asignar la Clave SAT a algún registro."
                                    advertenciaMensaje.ShowDialog()
                                End If

                            ElseIf (validarRepetidos() = False) Then
                                Dim advertenciaMensaje As New AdvertenciaForm
                                advertenciaMensaje.mensaje = "El código " + txtCodigo.Text.Trim + " esta siendo usado por otro producto activo."
                                advertenciaMensaje.ShowDialog()
                            End If
                        ElseIf (validaExisteProducto() = False) Then
                            Dim advertenciaMensaje As New AdvertenciaForm
                            advertenciaMensaje.mensaje = "El código " + txtCodigo.Text.Trim + " esta siendo usado por otro producto activo."
                            advertenciaMensaje.ShowDialog()
                        End If
                    ElseIf (validarDetalle() = False) Then
                        Dim advertenciaMensaje As New AdvertenciaForm
                        advertenciaMensaje.mensaje = "Debe seleccionar al menos un detalle de producto."
                        advertenciaMensaje.ShowDialog()
                    End If
                Else
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "Debe seleccionar al menos una subfamilia."
                    advertenciaMensaje.ShowDialog()
                End If
            Else
                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "Debe generar todos los datos obligatorios."
                advertenciaMensaje.ShowDialog()
            End If
        ElseIf (validarVacio() = False) Then
            Dim advertenciaMensaje As New AdvertenciaForm
            advertenciaMensaje.mensaje = "Debe generar todos los datos obligatorios."
            advertenciaMensaje.ShowDialog()
        End If

    End Sub

    Public Function validarRepetidos() As Boolean
        Dim dtValidarRepetido As DataTable
        Dim objProd As New Programacion.Negocios.ProductosBU
        dtValidarRepetido = objProd.ValidarRepetidos(codigo)
        If (rdoActivo.Checked = True) Then
            If (activoInactivo = False) Then
                If (dtValidarRepetido.Rows.Count >= 1) Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function

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

    Public Sub quitarSelecciones()

        For Each rowPiel As UltraGridRow In grdPieles.Rows
            rowPiel.Cells(4).Value = False
        Next
        For Each rowTalla As UltraGridRow In grdTalla.Rows
            rowTalla.Cells(3).Value = False
        Next
        For Each rowCorte As UltraGridRow In grdCorte.Rows
            rowCorte.Cells(3).Value = False
        Next
        For Each rowSuela As UltraGridRow In grdSuela.Rows
            rowSuela.Cells(3).Value = False
        Next
        For Each rowForro As UltraGridRow In grdForros.Rows
            rowForro.Cells(3).Value = False
        Next
    End Sub

    Public Sub llearComboMarcasCasa()
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
        dtDatosEstausProds = objProd.estatusProductos
        dtDatosEstausProds.Rows.InsertAt(dtDatosEstausProds.NewRow, 0)
        cmbEstatus.DataSource = dtDatosEstausProds
        cmbEstatus.ValueMember = "stpr_productoStatusId"
        cmbEstatus.DisplayMember = "stpr_descripcion"
        cmbEstatus.SelectedIndex = 2
        cmbEstatus.Text = "PROTOTIPO"
    End Sub

    Private Sub grdDetallesEstilos_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection As String = CStr(item.Tag)

        If (codSicyColeccion <> Nothing And txtCodSicy.Text <> Nothing And grdDetallesEstilos.ActiveRow.Cells("sicyPCOL").Value <> Nothing) Then
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

    Private Sub grdDetallesEstilos_menuChoice_Estatus(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection As String = CStr(item.Tag)
        If validarCambioEstatus(grdDetallesEstilos.ActiveRow.Cells("nomSts").Value, item.ToString) Then
            grdDetallesEstilos.ActiveRow.Cells("psEstatus").Value = selection
            grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = item.ToString
        Else
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Estatus inválido."
            adv.ShowDialog()
        End If

    End Sub

    Private Sub grdDetallesEstilos_menuChoice_Familias(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection As String = CStr(item.Tag)
        grdDetallesEstilos.ActiveRow.Cells("idFamilia").Value = selection
        grdDetallesEstilos.ActiveRow.Cells("familia").Value = item.ToString
    End Sub
    Private Sub grdDetallesEstilos_menuChoice_FamiliasVentas(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection As String = CStr(item.Tag)
        grdDetallesEstilos.ActiveRow.Cells("idFamiliaVentas").Value = selection
        grdDetallesEstilos.ActiveRow.Cells("familia ventas").Value = item.ToString
    End Sub

    Private Sub grdDetallesEstilos_menuChoice_Lineas(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection As String = CStr(item.Tag)
        grdDetallesEstilos.ActiveRow.Cells("idLinea").Value = selection
        grdDetallesEstilos.ActiveRow.Cells("linea").Value = item.ToString
    End Sub

    Private Sub grdDetallesEstilos_menuChoice_Cortes(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection As String = CStr(item.Tag)
        grdDetallesEstilos.ActiveRow.Cells("idCorte").Value = selection
        grdDetallesEstilos.ActiveRow.Cells("corte").Value = item.ToString
    End Sub

    Public Sub mostrarCamporCliente()
        If estiloCliente = True Then
            lblCodigoCliente.Visible = True
            lblMarcasCasa.Visible = True
            txtCodCliente.Visible = True
            cmbMarcasCasa.Visible = True
        ElseIf idcedis = 82 And esLicencia = True Then
            lblCodigoCliente.Visible = True
            txtCodCliente.Visible = True
        Else
            lblCodigoCliente.Visible = False
            lblMarcasCasa.Visible = False
            txtCodCliente.Visible = False
            cmbMarcasCasa.Visible = False
        End If

        If txtMarca.Text = "1" Then
            lblMarcasCasa.Visible = False
            cmbMarcasCasa.Visible = False
        End If

        txtCodCliente.Text = String.Empty
        cmbMarcasCasa.SelectedIndex = 0
    End Sub

    Private Sub EditarProductoForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If cerrarGuardar = False Then
            Dim objAdvSalir As New ConfirmarForm
            objAdvSalir.mensaje = "¿Está seguro de salir SIN guardar los cambios?"
            If objAdvSalir.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        Else
            Me.Dispose()
        End If

    End Sub

    Private Sub EditarProductoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescripcion.Enabled = False
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_CAT_PROD", "EDITAR_MODELOS") Then
            permiso = True
        Else
            grpAreaTrabajo.Enabled = False
            btnGuardar.Enabled = False
            groupMovimiento.Enabled = False
            picSiguiente.Enabled = False
        End If
        llearComboMarcasCasa()
        llenarComboEstatus()
        LlenarDatosProducto()
        llenarSubfamilias()
        LlenarTablaTallas(permiso)
        LlenarTablaPieles(permiso)
        LlenarTablaForro(permiso)
        LlenarTablaSuela(permiso)
        LlenarTablaCorte(permiso)
        LlenarTablaFamilias(permiso)
        llenarTablaLineas(permiso)
        LlenarTablaFamiliasVentas()
        llenarTablaDetalles()
        llenarComboNaves()
        ActivarInactivar()
        getNaveDes()
        'txtHorma.Enabled = False
        'btnHorma.Enabled = False
        'txtCategoria.Enabled = False
        'btnCategoria.Enabled = False
        'txtCodCliente.Enabled = False
        Me.ToolMensaje.SetToolTip(btnAgregarDato, "Asegúrese de seleccionar " + Chr(13) + "los campos obligatorios" + Chr(13) + "antes de generar registros.")
    End Sub

    Private Sub ActivarInactivar()
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtProductoActivoInactivo As DataTable
        dtProductoActivoInactivo = New DataTable
        dtProductoActivoInactivo = objPBU.verProductoActivoInactivo(idProducto)


        If dtProductoActivoInactivo.Rows(0).Item(0) = 0 Then
            gprBotonActualiza.Enabled = True
        Else
            gprBotonActualiza.Enabled = False
        End If
    End Sub

    Public Sub LlenarTablaFamiliasVentas()
        'Dim objCBU As New Programacion.Negocios.FamiliasBU
        'Dim dtListaFamilia As DataTable
        'dtListaFamilia = objCBU.VerComboFamiliaVentas(idProducto)
        'grdFamVentas.DataSource = Nothing
        'grdFamVentas.DataSource = dtListaFamilia
        'grdFamVentas.DataBind()

        'With grdFamVentas.DisplayLayout.Bands(0)
        '    .Columns("fapr_familiaproyeccionid").Hidden = True
        '    .Columns("fapr_descripcion").Header.Caption = "Familia de Ventas"
        '    .Columns("fapr_descripcion").CellActivation = Activation.NoEdit
        '    .Columns("selectFamilia").Header.Caption = ""
        '    .Columns("selectFamilia").Style = ColumnStyle.CheckBox
        '    .Columns("selectFamilia").CellActivation = Activation.AllowEdit
        '    .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        'End With
        'grdFamVentas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        'If (estiloCliente = True) Then
        '    For Each row As UltraGridRow In grdFamVentas.Rows
        '        row.Cells("selectFamilia").Value = False
        '    Next
        'End If
    End Sub
    Private Sub getNaveDes()
        Dim obj As New ProductosBU
        Dim d As New DataTable
        Dim totalConsumos As New DataTable
        d = obj.getNaveDesarrolla(idProducto)
        For Each row As DataRow In d.Rows
            cmbNaveDesarrolla.SelectedValue = row("naveDes")
        Next
        totalConsumos = obj.validarConsumos(idProducto) 'Regresa el total de sus consumos de todos sus estilos si es mayo a 0 no se debe modificar el campo de nave de desarrolla

        For Each row As DataRow In totalConsumos.Rows
            If row("consumos") > 0 Then
                cmbNaveDesarrolla.Enabled = False
            Else
                cmbNaveDesarrolla.Enabled = True
            End If
        Next
    End Sub
    Public Sub llenarComboNaves()
        cmbNaveDesarrolla = Controles.ComboNavesSegunUsuario(cmbNaveDesarrolla, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNaveDesarrolla.Items.Count = 2 Then
            cmbNaveDesarrolla.SelectedIndex = 1
        End If
    End Sub
    Private Sub btnMarca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarca.Click
        Dim marcas As New MarcaFormRapido
        marcas.ShowDialog()
        If (marcas.PIdMarca >= 0) Then
            idMarca = marcas.PIdMarca
            txtMarca.Text = marcas.PMarcaNombre
            estiloCliente = marcas.PesCliente
            codSicyMarca = marcas.PSicyMarca
            lblNombreMarca.Text = marcas.PEtiquetaM

            txtCodigo.Text = txtMarca.Text + txtColeccion.Text
            txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text

            'Else
            'idMarca = 0
            'txtMarca.Text = String.Empty
            'estiloCliente = False
            'codSicyMarca = String.Empty
            'lblNombreMarca.Text = ""

            'cadena = txtMarca.Text + ultimoDigitoAnio(anio) + txtColeccion.Text
            'txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
            'txtCodigo.Text = cadena
        End If
        If (primerCodMarca = txtMarca.Text And primerCodColeccion = txtColeccion.Text) Then
            txtCodSicy.Text = primerModelo
            If primerMarcaCasa <> "" Then
                cmbMarcasCasa.SelectedValue = primerMarcaCasa
                codSicyMarca = primerMarcaCasa
                txtDescripcion.Text = primerClaveCliente
            End If
            txtMarca.Focus()
        Else
            mostrarCamporCliente()
        End If

        For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            rowEst.Cells("Sicy").Value = ""
            rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
        Next
        txtCodCliente.Text = String.Empty
        cmbMarcasCasa.SelectedIndex = 0
    End Sub

    Private Sub btnColeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColeccion.Click
        Dim ValidaMarca As New Programacion.Negocios.ColeccionBU
        Dim coleccion As New ColeccionFormRapido
        ' ''consecutivo = String.Empty
        ' ''digitoanio = ultimoDigitoAnio(anio)
        If (idMarca <> 0) Then
            coleccion.idMarca = idMarca
            coleccion.ShowDialog()
            If coleccion.PidColeccion <> 0 Then
                idColeccion = coleccion.PidColeccion
                codSicyColeccion = coleccion.PCodSicyCol
                lblNombreColeccion.Text = coleccion.PNombreColeccion
                txtColeccion.Text = coleccion.PCodColeccion
                idFamiliaVentas = coleccion.idFamiliaProyeccion
                familiaVentas = coleccion.familiaProyeccion
                lblFamiliaVentas.Text = familiaVentas
                If (idColeccion <> 0) Then
                    Dim dtConsecutivo As DataTable = ValidaMarca.verConsecutivoCod(idMarca, idColeccion)
                    If (dtConsecutivo.Rows(0)(0).ToString = Nothing) Then
                        consecutivo = "1"
                    Else
                        If (consecutivo <> "False") Then

                        ElseIf (consecutivo = "False") Then
                            Dim advertenciaMensaje As New AdvertenciaForm
                            idColeccion = 0
                            codSicyColeccion = String.Empty
                            txtColeccion.Text = String.Empty
                            lblNombreColeccion.Text = ""
                            consecutivo = String.Empty
                            advertenciaMensaje.mensaje = "No hay mas consecutivo de la coleccion para asignar."
                            advertenciaMensaje.ShowDialog()
                        End If
                    End If
                Else
                    consecutivo = String.Empty
                End If
            End If
        ElseIf (idMarca = Nothing) Then
            idColeccion = 0
            codSicyColeccion = String.Empty
            txtColeccion.Text = String.Empty
            lblNombreColeccion.Text = ""
            consecutivo = String.Empty
        End If

        If (primerCodMarca = txtMarca.Text And primerCodColeccion = txtColeccion.Text) Then
            txtCodSicy.Text = primerModelo
            If primerMarcaCasa <> "" Then
                cmbMarcasCasa.SelectedValue = primerMarcaCasa
                codSicyMarca = primerMarcaCasa
                txtCodCliente.Text = primerClaveCliente
            End If
            txtColeccion.Focus()
        Else
            txtCodSicy.Text = ""
            txtColeccion.Focus()
        End If
        txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
        txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
    End Sub

    ' ''Public Function convertitConsecutivo(ByVal dato As String) As String
    ' ''    Dim nuevoDato As String = String.Empty
    ' ''    Dim entero As Int32 = 0
    ' ''    If (dato <> "A" And dato <> "B" And dato <> "C" And dato <> "D" And dato <> "E" And dato <> "F" And
    ' ''        dato <> "G" And dato <> "H" And dato <> "I" And dato <> "J" And dato <> "K" And dato <> "L" And dato <> "M" And
    ' ''        dato <> "N" And dato <> "O" And dato <> "P" And dato <> "Q" And dato <> "R" And dato <> "S" And
    ' ''        dato <> "T" And dato <> "U" And dato <> "W" And dato <> "X" And dato <> "Y" And dato <> "Z") Then
    ' ''        entero = Convert.ToInt32(dato, 16)
    ' ''    Else
    ' ''        entero = 9
    ' ''    End If
    ' ''    If (primeridMarca <> idMarca Or primerIdColeccion <> idColeccion) Then
    ' ''        If (entero >= 9) Then
    ' ''            If (dato = "9") Then
    ' ''                nuevoDato = "A"

    ' ''            ElseIf (dato = "A") Then
    ' ''                nuevoDato = "B"

    ' ''            ElseIf (dato = "B") Then
    ' ''                nuevoDato = "C"

    ' ''            ElseIf (dato = "C") Then
    ' ''                nuevoDato = "D"

    ' ''            ElseIf (dato = "D") Then
    ' ''                nuevoDato = "E"

    ' ''            ElseIf (dato = "E") Then
    ' ''                nuevoDato = "F"

    ' ''            ElseIf (dato = "F") Then
    ' ''                nuevoDato = "G"

    ' ''            ElseIf (dato = "G") Then
    ' ''                nuevoDato = "H"

    ' ''            ElseIf (dato = "H") Then
    ' ''                nuevoDato = "I"

    ' ''            ElseIf (dato = "I") Then
    ' ''                nuevoDato = "J"

    ' ''            ElseIf (dato = "J") Then
    ' ''                nuevoDato = "K"

    ' ''            ElseIf (dato = "K") Then
    ' ''                nuevoDato = "L"

    ' ''            ElseIf (dato = "L") Then
    ' ''                nuevoDato = "M"

    ' ''            ElseIf (dato = "M") Then
    ' ''                nuevoDato = "N"

    ' ''            ElseIf (dato = "N") Then
    ' ''                nuevoDato = "O"

    ' ''            ElseIf (dato = "O") Then
    ' ''                nuevoDato = "P"

    ' ''            ElseIf (dato = "P") Then
    ' ''                nuevoDato = "Q"

    ' ''            ElseIf (dato = "Q") Then
    ' ''                nuevoDato = "R"

    ' ''            ElseIf (dato = "R") Then
    ' ''                nuevoDato = "S"

    ' ''            ElseIf (dato = "S") Then
    ' ''                nuevoDato = "T"

    ' ''            ElseIf (dato = "T") Then
    ' ''                nuevoDato = "U"

    ' ''            ElseIf (dato = "U") Then
    ' ''                nuevoDato = "W"

    ' ''            ElseIf (dato = "W") Then
    ' ''                nuevoDato = "X"

    ' ''            ElseIf (dato = "X") Then
    ' ''                nuevoDato = "Y"

    ' ''            ElseIf (dato = "Y") Then
    ' ''                nuevoDato = "Z"

    ' ''            ElseIf (dato = "Z") Then
    ' ''                nuevoDato = "FALSE"
    ' ''            End If
    ' ''        ElseIf (entero < 9) Then
    ' ''            entero = entero + 1
    ' ''            nuevoDato = entero
    ' ''        End If
    ' ''    Else
    ' ''        nuevoDato = primerConsecutivo
    ' ''    End If
    ' ''    Return nuevoDato
    ' ''End Function

    Private Sub btnTemporada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemporada.Click
        Dim temporada As New temporadaFormRapido
        temporada.ShowDialog()

        If (temporada.PidTemporada <> 0) Then
            idTemporada = temporada.PidTemporada
            txtTemporada.Text = temporada.PCodTemporada
            lblNombreTemporada.Text = temporada.PNombreTemporada

            Dim objProd As New Programacion.Negocios.ColeccionBU
            If (idMarca <> 0 And idColeccion <> 0) Then
                Dim dtConsecutivo As DataTable = objProd.verConsecutivoCod(idMarca, idColeccion)
                If (dtConsecutivo.Rows(0)(0).ToString = Nothing) Then
                    consecutivo = "1"
                Else
                    If (dtConsecutivo.Rows(0)(0).ToString <> "False") Then

                    ElseIf (dtConsecutivo.Rows(0)(0).ToString = "False") Then
                        Dim advertenciaMensaje As New AdvertenciaForm
                        idColeccion = 0
                        codSicyColeccion = String.Empty
                        txtColeccion.Text = String.Empty
                        lblNombreColeccion.Text = ""
                        consecutivo = String.Empty
                        advertenciaMensaje.mensaje = "No hay mas consecutivo de la coleccion para asignar."
                        advertenciaMensaje.ShowDialog()
                    End If
                End If
            End If
            ' ''Else
            ' ''    idTemporada = 0
            ' ''    txtTemporada.Text = String.Empty
            ' ''    lblNombreTemporada.Text = ""
            ' ''    anio = String.Empty
            ' ''    digitoanio = String.Empty
            ' ''    consecutivo = String.Empty
            ' ''    txtCodigo.Text = txtMarca.Text + digitoanio + txtColeccion.Text + consecutivo
        End If

        txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
        txtTemporada.Focus()
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
        Dim objProdBu As New Programacion.Negocios.ColeccionBU
        Dim objTempBu As New Negocios.TemporadasBU
        Dim dtExisteColeccion As DataTable

        If (idMarca = 0 Or idColeccion = 0 Or idTemporada = 0) Then
            If (txtColeccion.Text <> Nothing And idMarca <> 0) Then
                If (primerCodMarca = txtMarca.Text And primerCodColeccion = txtColeccion.Text) Then

                    idColeccion = primerIdColeccion
                    consecutivo = primerConsecutivo
                    dtExisteColeccion = objProdBu.validarExistenciaColeccion(txtColeccion.Text, idMarca, idColeccion)

                    idColeccion = CInt(dtExisteColeccion.Rows(0)("coma_coleccionid").ToString)
                    codSicyColeccion = dtExisteColeccion.Rows(0)("coma_codigosicy").ToString
                    lblNombreColeccion.Text = dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                    idTemporada = CInt(dtExisteColeccion.Rows(0)("cole_temporadaid").ToString)
                    Dim dtTemporada As New DataTable
                    dtTemporada = objTempBu.VerTemporadaRegistroRapido(idTemporada)
                    lblNombreTemporada.Text = dtTemporada.Rows(0).Item("temp_nombre").ToString
                    idTemporada = CInt(dtTemporada.Rows(0).Item("temp_temporadaid").ToString)

                    If primerMarcaCasa <> "" Then
                        cmbMarcasCasa.SelectedValue = primerMarcaCasa
                        codSicyMarca = primerCodSicyMarca
                        codSicyColeccion = primerCodSicyColeccion
                        txtCodCliente.Text = primerClaveCliente
                    End If

                    txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                    txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
                    txtCodSicy.Text = primerModelo

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
                Else
                    dtExisteColeccion = objProdBu.validarExistenciaColeccion(txtColeccion.Text, idMarca, idColeccion)

                    If (dtExisteColeccion.Rows.Count >= 1) Then
                        idColeccion = CInt(dtExisteColeccion.Rows(0)("coma_coleccionid").ToString)
                        codSicyColeccion = dtExisteColeccion.Rows(0)("coma_codigosicy").ToString
                        lblNombreColeccion.Text = dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                        idTemporada = CInt(dtExisteColeccion.Rows(0)("cole_temporadaid").ToString)
                        Dim dtTemporada As New DataTable
                        dtTemporada = objTempBu.VerTemporadaRegistroRapido(idTemporada)
                        lblNombreTemporada.Text = dtTemporada.Rows(0).Item("temp_nombre").ToString
                        idTemporada = CInt(dtTemporada.Rows(0).Item("temp_temporadaid").ToString)

                        If (idMarca <> 0 And idColeccion <> 0) Then
                            Dim dtConsecutivo As DataTable = objProdBu.verConsecutivoCod(idMarca, idColeccion)
                            If (dtConsecutivo.Rows(0)("ctvo").ToString = Nothing) Then
                                consecutivo = "0"
                                txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                                txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
                            Else
                                consecutivo = CInt(consecutivo) + 1
                                If (CInt(consecutivo) <= 9) Then
                                    txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                                    txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text

                                ElseIf (CInt(consecutivo) > 9) Then
                                    txtColeccion.Text = String.Empty
                                    consecutivo = String.Empty
                                    lblNombreColeccion.Text = String.Empty
                                    txtCodigo.Text = txtMarca.Text
                                    txtDescripcion.Text = lblNombreMarca.Text

                                    Dim advertenciaMensaje As New AdvertenciaForm
                                    advertenciaMensaje.mensaje = "No hay mas consecutivo de la coleccion para asignar."
                                    advertenciaMensaje.ShowDialog()
                                End If
                            End If
                        Else
                            consecutivo = String.Empty
                            txtCodigo.Text = String.Empty
                        End If
                    Else
                        idColeccion = 0
                        consecutivo = String.Empty
                        txtColeccion.Text = String.Empty
                        lblNombreColeccion.Text = String.Empty
                        txtCodigo.Text = txtMarca.Text
                        txtDescripcion.Text = lblNombreMarca.Text
                        Dim advertenciaMensaje As New AdvertenciaForm
                        advertenciaMensaje.mensaje = "La colección que ingreso no existe."
                        advertenciaMensaje.ShowDialog()
                    End If
                End If

            End If
            If (txtMarca.Text = Nothing) Then
                idColeccion = 0
                consecutivo = String.Empty
                txtColeccion.Text = String.Empty
                lblNombreColeccion.Text = String.Empty
                txtCodigo.Text = txtMarca.Text
                txtDescripcion.Text = lblNombreMarca.Text
            End If
        End If

    End Sub

    Private Sub txtColeccion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColeccion.TextChanged
        If (txtColeccion.TextLength = 3) Then
            Dim ValidaExistencias As New Programacion.Negocios.ColeccionBU
            Dim objTemporada As New Negocios.TemporadasBU
            Dim dtExisteColeccion As DataTable
            If (primerCodMarca = txtMarca.Text And primerCodColeccion = txtColeccion.Text) Then
                idColeccion = primerIdColeccion
                consecutivo = primerConsecutivo

                dtExisteColeccion = ValidaExistencias.validarExistenciaColeccion(txtColeccion.Text, idMarca, idColeccion)

                idColeccion = CInt(dtExisteColeccion.Rows(0)("coma_coleccionid").ToString)
                codSicyColeccion = dtExisteColeccion.Rows(0)("coma_codigosicy").ToString
                lblNombreColeccion.Text = dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                idTemporada = CInt(dtExisteColeccion.Rows(0)("cole_temporadaid").ToString)
                Dim dtTemporada As New DataTable
                dtTemporada = objTemporada.VerTemporadaRegistroRapido(idTemporada)
                lblNombreTemporada.Text = dtTemporada.Rows(0).Item("temp_nombre").ToString
                idTemporada = CInt(dtTemporada.Rows(0).Item("temp_temporadaid").ToString)


                If primerMarcaCasa <> "" Then
                    cmbMarcasCasa.SelectedValue = primerMarcaCasa
                    codSicyMarca = primerCodSicyMarca
                    codSicyColeccion = primerCodSicyColeccion
                    txtCodCliente.Text = primerClaveCliente
                End If

                txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
                txtCodSicy.Text = primerModelo

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
            Else
                If (idColeccion = 0 Or txtColeccion.Text <> "") Then
                    If (txtColeccion.Text <> "" And idMarca <> 0) Then

                        dtExisteColeccion = ValidaExistencias.validarExistenciaColeccion(txtColeccion.Text, idMarca, idColeccion)

                        If (dtExisteColeccion.Rows.Count >= 1) Then
                            idColeccion = CInt(dtExisteColeccion.Rows(0)("coma_coleccionid").ToString)
                            codSicyColeccion = dtExisteColeccion.Rows(0)("coma_codigosicy").ToString
                            lblNombreColeccion.Text = dtExisteColeccion.Rows(0)("cole_descripcion").ToString
                            Dim dtTemporada As New DataTable
                            dtTemporada = objTemporada.VerTemporadaRegistroRapido(dtExisteColeccion.Rows(0)("cole_temporadaid").ToString)
                            lblNombreTemporada.Text = dtTemporada.Rows(0).Item("temp_nombre").ToString
                            idTemporada = CInt(dtTemporada.Rows(0).Item("temp_temporadaid").ToString)

                            If (idMarca <> 0 And idColeccion <> 0) Then
                                Dim dtConsecutivo As DataTable = ValidaExistencias.verConsecutivoCod(idMarca, idColeccion)
                                consecutivo = dtConsecutivo.Rows(0)("ctvo").ToString
                                If consecutivo = Nothing Then
                                    consecutivo = "0"
                                    txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                                    txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
                                Else

                                    consecutivo = CInt(consecutivo + 1)
                                    If (CInt(consecutivo) <= 9) Then
                                        txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
                                        txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text

                                    ElseIf (CInt(consecutivo) > 9) Then
                                        Dim advertenciaMensaje As New AdvertenciaForm
                                        txtColeccion.Text = String.Empty
                                        idColeccion = 0
                                        consecutivo = String.Empty
                                        lblNombreColeccion.Text = String.Empty
                                        txtCodigo.Text = txtMarca.Text + txtColeccion.Text
                                        txtDescripcion.Text = lblNombreMarca.Text
                                        advertenciaMensaje.mensaje = "No hay mas consecutivo de la coleccion para asignar."
                                        advertenciaMensaje.ShowDialog()
                                    End If


                                End If
                            Else
                                consecutivo = String.Empty
                                txtCodigo.Text = String.Empty
                                txtDescripcion.Text = String.Empty
                            End If
                        Else
                            idColeccion = 0
                            consecutivo = String.Empty
                            txtColeccion.Text = String.Empty
                            lblNombreTemporada.Text = ""
                            idTemporada = 0
                            Dim advertenciaMensaje As New AdvertenciaForm
                            advertenciaMensaje.mensaje = "La colección que ingreso no existe."
                            advertenciaMensaje.ShowDialog()
                        End If
                    End If
                End If

                If (txtMarca.Text = Nothing) Then
                    txtColeccion.Text = String.Empty
                    txtCodSicy.Text = String.Empty
                    consecutivo = String.Empty
                    lblNombreColeccion.Text = ""
                End If
            End If
        Else
            idColeccion = 0
            codSicyColeccion = String.Empty
            consecutivo = String.Empty
            lblNombreColeccion.Text = String.Empty
            txtCodigo.Text = txtMarca.Text
            txtDescripcion.Text = lblNombreMarca.Text
            txtCodSicy.Text = String.Empty
            lblNombreTemporada.Text = String.Empty
            idTemporada = 0
        End If

    End Sub

    Private Sub txtMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMarca.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtMarca.Text.Length < 1) Then
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
    End Sub

    Private Sub txtMarca_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarca.LostFocus
        'idColeccion = 0
        Dim ValidaExistencias As New Programacion.Negocios.ProductosBU
        Dim dtExisteMarca As DataTable
        If (idMarca = Nothing) Then
            If (txtMarca.Text <> Nothing) Then
                dtExisteMarca = ValidaExistencias.validarExistenciaMarca(txtMarca.Text)
                If (dtExisteMarca.Rows.Count >= 1) Then
                    idMarca = CInt(dtExisteMarca.Rows(0)(0).ToString)
                    estiloCliente = Convert.ToBoolean(dtExisteMarca.Rows(0)(1).ToString)
                    lblNombreMarca.Text = dtExisteMarca.Rows(0)(3).ToString
                Else
                    txtMarca.Text = String.Empty
                    txtColeccion.Text = String.Empty
                    lblNombreMarca.Text = ""
                    idColeccion = 0
                    codSicyColeccion = String.Empty
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La marca que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                    estiloCliente = False
                    For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                        rowEst.Cells("Sicy").Value = ""
                        rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
                    Next
                End If
            Else
                lblNombreMarca.Text = ""
            End If
        End If
        If idMarca <> primeridMarca Then
            txtColeccion.Text = String.Empty
            idColeccion = 0
            codSicyColeccion = String.Empty
            lblNombreColeccion.Text = ""
            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                rowEst.Cells("Sicy").Value = ""
                rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
            Next
        End If
        txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo

        txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text

        If (estiloCliente = True) Then
            quitarSelecciones()
        End If

        If (primerCodMarca = txtMarca.Text And primerCodColeccion = txtColeccion.Text) Then
            txtCodSicy.Text = primerModelo
            If primerMarcaCasa <> "" Then
                cmbMarcasCasa.SelectedValue = primerMarcaCasa
                codSicyMarca = primerMarcaCasa
                txtDescripcion.Text = primerClaveCliente
            End If
        Else
            txtCodSicy.Text = ""
        End If
        mostrarCamporCliente()
        txtColeccion.Focus()
    End Sub

    Private Sub txtMarca_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarca.TextChanged
        idMarca = 0
        Dim ValidaExistencias As New Programacion.Negocios.ProductosBU
        Dim dtExisteMarca As DataTable

        If (idMarca = 0) Then
            If (txtMarca.Text <> Nothing) Then
                dtExisteMarca = ValidaExistencias.validarExistenciaMarca(txtMarca.Text)
                If (dtExisteMarca.Rows.Count >= 1) Then
                    idMarca = CInt(dtExisteMarca.Rows(0)("marc_marcaid").ToString)
                    estiloCliente = CBool(dtExisteMarca.Rows(0)("marc_esCliente").ToString)
                    codSicyMarca = dtExisteMarca.Rows(0)("marc_codigosicy").ToString
                    lblNombreMarca.Text = dtExisteMarca.Rows(0)("marc_descripcion").ToString
                    ' ''lblNombreColeccion.Text = ""
                Else
                    txtMarca.Text = String.Empty
                    txtColeccion.Text = String.Empty
                    idColeccion = 0
                    lblNombreMarca.Text = ""
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La marca que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                    estiloCliente = False
                    codSicyMarca = String.Empty
                    idMarca = 0
                End If
            Else
                lblNombreColeccion.Text = ""
                lblNombreMarca.Text = ""
            End If
        End If
        If idMarca <> primeridMarca Then
            txtColeccion.Text = String.Empty
            idColeccion = 0
            codSicyColeccion = String.Empty
            lblNombreColeccion.Text = ""
        End If
        txtCodigo.Text = txtMarca.Text + txtColeccion.Text + consecutivo
        txtDescripcion.Text = lblNombreMarca.Text + " " + lblNombreColeccion.Text
        If (estiloCliente = True) Then
            quitarSelecciones()
        End If

        If (primerCodMarca = txtMarca.Text And primerCodColeccion = txtColeccion.Text) Then
            txtCodSicy.Text = primerModelo
            If primerMarcaCasa <> "" Then
                cmbMarcasCasa.SelectedValue = primerMarcaCasa
                codSicyMarca = primerMarcaCasa
                txtDescripcion.Text = primerClaveCliente
            End If
        Else
            txtCodSicy.Text = ""
        End If

        For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            rowEst.Cells("Sicy").Value = ""
            rowEst.Cells("IdMarcaCasa").Value = codSicyMarca
        Next
        mostrarCamporCliente()
    End Sub

    Private Sub txtTemporada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTemporada.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtTemporada.Text.Length < 2) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtTemporada.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTemporada_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemporada.LostFocus

        If (idTemporada = 0) Then
            Dim objProdBu As New Programacion.Negocios.ProductosBU
            Dim dtValidaExisteTemporada As DataTable
            If (txtTemporada.Text <> Nothing) Then
                dtValidaExisteTemporada = objProdBu.validarExistenciaTemporada(txtTemporada.Text)
                If (dtValidaExisteTemporada.Rows.Count >= 1) Then
                    idTemporada = CInt(dtValidaExisteTemporada.Rows(0)("temp_temporadaid").ToString)
                    lblNombreTemporada.Text = dtValidaExisteTemporada.Rows(0)("temp_nombre").ToString
                Else
                    idTemporada = 0
                    txtTemporada.Text = String.Empty
                    lblNombreTemporada.Text = ""
                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La temporada que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If
            End If
        End If

    End Sub

    Private Sub txtTemporada_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTemporada.TextChanged
        idTemporada = 0
        lblNombreTemporada.Text = ""
        Dim objProd As New Programacion.Negocios.ProductosBU
        If (idTemporada = 0) Then
            If (txtTemporada.Text <> Nothing) Then
                If (txtTemporada.TextLength = 2) Then
                    Dim dtValidaExisteTemporada As DataTable
                    dtValidaExisteTemporada = objProd.validarExistenciaTemporada(txtTemporada.Text)

                    If (dtValidaExisteTemporada.Rows.Count >= 1) Then
                        idTemporada = CInt(dtValidaExisteTemporada.Rows(0)("temp_temporadaid").ToString)
                        lblNombreTemporada.Text = dtValidaExisteTemporada.Rows(0)("temp_nombre").ToString
                    Else
                        idTemporada = 0
                        txtTemporada.Text = String.Empty
                        lblNombreTemporada.Text = ""
                        Dim advertenciaMensaje As New AdvertenciaForm
                        advertenciaMensaje.mensaje = "La temporada que ingreso no existe."
                        advertenciaMensaje.ShowDialog()
                    End If
                End If
            Else
                idTemporada = 0
                txtTemporada.Text = String.Empty
                lblNombreTemporada.Text = ""
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LlenarTablaDetallesEstilosProducto()
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        quitarRegistrosDetalle()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If validarExisteOtroRegistro() = True Then
                validacionesGuardar()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        ' ''Dim objAdvSalir As New ConfirmarForm
        ' ''objAdvSalir.mensaje = "¿Está seguro de salir SIN guardar los cambios?"
        ' ''If objAdvSalir.ShowDialog() = Windows.Forms.DialogResult.OK Then
        Me.Close()
        ' ''End If
    End Sub

    Private Sub txtSubfamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubfamilia.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtSubfamilia.Text.Length < 2) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtSubfamilia.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSubfamilia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubfamilia.LostFocus
        'dtSubfamilias = Nothing
        Dim ValidaExistencias As New Programacion.Negocios.ProductosBU
        If (idSubFamilia = 0 And dtSubfamilias Is Nothing) Then

            If (txtSubfamilia.Text <> Nothing) Then
                Dim dtValidaExisteSubFamilia As DataTable
                dtValidaExisteSubFamilia = ValidaExistencias.validarExistenciaSubfamilia(txtSubfamilia.Text)
                If (dtValidaExisteSubFamilia.Rows.Count >= 1) Then
                    idSubFamilia = dtValidaExisteSubFamilia.Rows(0)(0).ToString
                    lblNombreSubfamilia.Text = dtValidaExisteSubFamilia.Rows(0)(1).ToString
                Else

                    txtSubfamilia.Text = String.Empty
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

    Private Sub txtSubfamilia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubfamilia.TextChanged
        dtSubfamilias = Nothing
        idSubFamilia = 0
        Dim ValidaExistencias As New Programacion.Negocios.ProductosBU
        If (idSubFamilia = 0) Then
            If (txtSubfamilia.Text <> Nothing) Then
                Dim dtValidaExisteFamilia As DataTable
                dtValidaExisteFamilia = ValidaExistencias.validarExistenciaSubfamilia(txtSubfamilia.Text)
                If (dtValidaExisteFamilia.Rows.Count >= 1) Then
                    idSubFamilia = CInt(dtValidaExisteFamilia.Rows(0)(0).ToString)
                    lblNombreSubfamilia.Text = dtValidaExisteFamilia.Rows(0)(1).ToString
                Else
                    txtSubfamilia.Text = String.Empty
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

    Private Sub btnSubfamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubfamilia.Click
        ' ''txtSubfamilia.Text = String.Empty
        ' ''lblNombreSubfamilia.Text = String.Empty
        ' ''idSubFamilia = 0
        ' ''dtSubfamilias = Nothing
        ' ''Dim objSubfamilia As New SubfamiliaRapidoForm
        ' ''objSubfamilia.ShowDialog()
        '' '' ''idSubFamilia = subfamilia.PSubFamiliaId
        '' '' ''txtSubFamilia.Text = subfamilia.PCodSubFamilia
        '' '' ''lblNombreSubfamilia.Text = subfamilia.PNombreSubfmailia
        ' ''dtSubfamilias = objSubfamilia.PDTSubfamilias
        ' ''Dim cadenaSubfamilias As String

        ' ''cadenaSubfamilias = ""

        ' ''If Not dtSubfamilias Is Nothing Then
        ' ''    For Each dtRow As DataRow In dtSubfamilias.Rows
        ' ''        cadenaSubfamilias += dtRow.Item("subfamiliaNombre").ToString + ", "
        ' ''    Next

        ' ''    Dim cadNombreExacto As String
        ' ''    Dim tamcad As Int32 = 0
        ' ''    tamcad = Len(cadenaSubfamilias) - 2
        ' ''    cadNombreExacto = cadenaSubfamilias.Substring(0, tamcad)
        ' ''    lblNombreSubfamilia.Text = cadNombreExacto

        ' ''    If dtSubfamilias.Rows.Count = 1 Then
        ' ''        txtSubfamilia.Text = dtSubfamilias.Rows(0).Item("idSubFamilia").ToString
        ' ''        txtSubfamilia.Focus()
        ' ''    End If
        ' ''End If

        Dim objSubfamilia As New SubfamiliaRapidoForm
        Dim dtDatosRapidosSubfamilia As DataTable
        Dim dtDatosEnviarSelectsSubf As New DataTable
        dtDatosEnviarSelectsSubf.Columns.Add("subf_Subfamiliaid")

        If idSubFamilia <> 0 Then
            dtDatosEnviarSelectsSubf.Rows.Add()
            dtDatosEnviarSelectsSubf.Rows(0)(0) = CStr(idSubFamilia)
        ElseIf Not dtSubfamilias Is Nothing Then
            Dim contRow As Int32 = 0
            For Each rowDTSF As DataRow In dtSubfamilias.Rows
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
                dtSubfamilias = Nothing
                txtSubfamilia.Text = String.Empty
                lblNombreSubfamilia.Text = String.Empty
                Dim cadenaIds As String
                Dim cadenaSubfamilias As String
                cadenaIds = ""
                cadenaSubfamilias = ""

                If dtDatosRapidosSubfamilia.Rows.Count = 1 Then
                    txtSubfamilia.Text = dtDatosRapidosSubfamilia.Rows(0).Item("idSubFamilia").ToString
                    txtSubfamilia.Focus()
                ElseIf dtDatosRapidosSubfamilia.Rows.Count > 1 Then
                    Dim cadNombreExacto As String
                    Dim tamcad As Int32 = 0
                    dtSubfamilias = dtDatosRapidosSubfamilia
                    For Each dtRow As DataRow In dtDatosRapidosSubfamilia.Rows
                        cadenaIds += dtRow.Item("idSubFamilia").ToString + ", "
                        cadenaSubfamilias += dtRow.Item("subfamiliaNombre").ToString + ", "
                    Next
                    tamcad = Len(cadenaSubfamilias) - 2
                    cadNombreExacto = cadenaSubfamilias.Substring(0, tamcad)
                    lblNombreSubfamilia.Text = cadNombreExacto
                End If
            End If
        End If

    End Sub

    Public Sub validarCodSicy()
        Dim adv As New AdvertenciaForm
        If estiloCliente = True And codSicyMarca <> "A" Then
            Try
                codSicyMarca = cmbMarcasCasa.SelectedValue
            Catch ex As Exception
                codSicyMarca = ""
            End Try
        End If

        Dim objProd As New Programacion.Negocios.ProductosBU
        Dim dtDatoContSicyRepetido As New DataTable
        Dim dtDatoContSicyExiste As New DataTable
        Dim dtSicyMarcaColeccion As New DataTable

        Dim contRepetido As Int32 = 0
        Dim contExiste As Int32 = 0
        Dim contSicyMarcColc As Int32 = 0

        dtDatoContSicyRepetido = objProd.validaSicyEnProducto(txtCodSicy.Text, idProducto, idMarca, idColeccion)
        dtDatoContSicyExiste = objProd.validaExistenciaModeloSicy(txtCodSicy.Text)
        dtSicyMarcaColeccion = objProd.validaExisteSicyMarcaColeccion(txtCodSicy.Text, codSicyMarca, codSicyColeccion)


        contRepetido = CInt(dtDatoContSicyRepetido.Rows(0)(0).ToString)
        contExiste = CInt(dtDatoContSicyExiste.Rows(0)(0).ToString)
        contSicyMarcColc = CInt(dtSicyMarcaColeccion.Rows(0)(0).ToString)

        If (contExiste = 0) Then
            txtCodSicy.Text = String.Empty
            adv.mensaje = "El modelo de SICY que ingreso no existe."
            adv.ShowDialog()
            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                rowEst.Cells("Sicy").Value = ""
                rowEst.Cells("IdMarcaCasa").Value = ""
            Next
        Else
            If (contSicyMarcColc = 0) Then
                txtCodSicy.Text = String.Empty
                adv.mensaje = "El modelo de SICY que ingreso no esta disponible en la marca y colección seleccionadas."
                adv.ShowDialog()
                For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                    rowEst.Cells("Sicy").Value = ""
                    rowEst.Cells("IdMarcaCasa").Value = ""
                Next
            ElseIf (contRepetido >= 1) Then
                txtCodSicy.Text = String.Empty
                adv.mensaje = "El modelo de SICY que ingreso ya se encuentra en otro registro."
                adv.ShowDialog()
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
    End Sub


    Private Sub txtCodSicy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodSicy.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (txtCodSicy.Text.Length > 0) Then
                validarCodSicy()
            End If
        End If
    End Sub

    Private Sub txtCodigoSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSicy.KeyPress
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

    Public Sub GenerarCadenaImagenes()
        If (ofdFoto.SafeFileName().ToString <> "ofdFoto") Then
            cadenaFoto = txtCodigo.Text + "/" + ofdFoto.SafeFileName()
        Else
            cadenaFoto = NombreFoto
        End If

        If (ofdDibujo.SafeFileName().ToString <> "ofdDibujo") Then
            cadenaDibujo = ofdDibujo.SafeFileName()
        Else
            cadenaDibujo = NombreDibujo
        End If
    End Sub

    Public Sub registrarImagenesFTP()
        Try
            Dim foto As New Tools.TransferenciaFTP(rutaFtp, FtpUser, ftppasswd)
            If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
            ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
                foto.EnviarArchivo("Programacion/Modelos/" + txtCodigo.Text + "/", ofdFoto.FileName)
                'foto.EnviarArchivo("Programacion/Modelos/" + txtCodigo.Text + "/", ofdFoto.FileName)
                foto.StreamFileThumbNail("Programacion/Modelos/", NombreFoto)
            End If
        Catch ex As Exception
            MsgBox("Sucedió algo inesperado, no se pudo subir la imagen.")
        End Try

        'Try
        '    'Dim fotoWeb As New Tools.TransferenciaFTP("ftp://50.63.89.1", "m4394882", "Asmlrl020907@")
        '    'Dim fotoWeb As New Tools.TransferenciaFTP("ftp://65.99.252.249", "ftpsay@grupoyuyin.com", "Sayweb2020")
        '    Dim fotoWeb As New Tools.TransferenciaFTP("ftp://192.168.2.158", "ftpaccess", "Yuyin2017""")

        '    If (ofdFoto.SafeFileName().ToString = "ofdFoto") Then
        '    ElseIf (ofdFoto.SafeFileName.ToString <> "ofdFoto") Then
        '        fotoWeb.EnviarArchivo("programacion/modelos/" + txtCodigo.Text + "/", ofdFoto.FileName)
        '        fotoWeb.EnviarArchivo("programacion/modelos/" + txtCodigo.Text + "/", ofdFoto.FileName)
        '        fotoWeb.StreamFileThumbNail("programacion/modelos/", NombreFoto)
        '    End If
        'Catch ex As Exception
        '    MsgBox("Sucedió algo inesperado, no se pudo subir la imagen a GrupoYuyin.com.")
        'End Try

        '' ''If (ofdDibujo.SafeFileName().ToString = "ofdDibujo") Then
        '' ''ElseIf (ofdDibujo.SafeFileName.ToString <> "ofdDibujo") Then
        '' ''    foto.EnviarArchivo("Programacion/Modelos/" + txtCodigo.Text + "/", ofdDibujo.FileName)
        '' ''    foto.EnviarArchivo("Programacion/Modelos/" + txtCodigo.Text + "/", ofdDibujo.FileName)

        '' ''End If
    End Sub

    Private Sub btnFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFoto.Click
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picFoto.Image = Image.FromFile(ofdFoto.FileName)
            sr.Close()
        End If
    End Sub

    Private Sub btnDibujo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDibujo.Click
        If ofdDibujo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdDibujo.FileName)
            picDibujo.Image = Image.FromFile(ofdDibujo.FileName)
            sr.Close()
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

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
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

    Private Sub btnAgregarDato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarDato.Click
        Dim existemod As Integer
        Dim adv As New AdvertenciaForm
        '22/06/2020 QUITAR sub familia
        'If Not (idMarca < 0 Or idColeccion = 0 Or idHorma = 0 Or idTemporada = 0 Or (idSubFamilia = 0 And dtSubfamilias Is Nothing) Or IDSuelaProgramacion = 0 Or txtCodSicy.Text = "") Then
        Try
            Me.Cursor = Cursors.WaitCursor
            If Not (idMarca < 0 Or idColeccion = 0 Or idHorma = 0 Or idTemporada = 0 Or IDSuelaProgramacion = 0 Or txtCodSicy.Text = "") Then
                ''If (estiloCliente = True) Then
                ''    LlenarTablaDetallesEstilosProductoCliente()
                ''ElseIf (estiloCliente = False) Then

                If Not ValidarPielColorSICY() Then Return
                existemod = validarExisteOtro()
                If existemod > 0 Then
                    adv.mensaje = "El modelo ya existe en su combinación COLECCIÓN - MODELO - PIEL COLOR - CORRIDA ."
                    adv.ShowDialog()
                Else
                    LlenarTablaDetallesEstilosProducto()
                End If

                'LlenarTablaDetallesEstilosProducto()
                ''End If
            Else
                adv.mensaje = "Faltan de capturar campos obligatorios."
                adv.ShowDialog()
            End If
        Catch ex As Exception
            adv.mensaje = "Error " + ex.Message
            adv.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Function ValidarPielColorSICY() As Boolean

        Dim objProd As New Programacion.Negocios.ProductosBU
        Dim dtPielColor As DataTable

        For Each rowPiel As UltraGridRow In grdPieles.Rows
            If (CBool(rowPiel.Cells("selectPcol").Value) = True) Then
                dtPielColor = objProd.ValidarPielColorSICY(rowPiel.Cells("sicypcol").Value)
                If dtPielColor.Rows.Count < 1 Then
                    Dim msg_adv As New Tools.AdvertenciaForm
                    msg_adv.mensaje = "La PIEL seleccionada no existe en SICY"
                    msg_adv.ShowDialog()
                End If
            End If
        Next
        Return True
    End Function

    'Private Sub grdCorte_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If (estiloCliente = True) Then
    '        If grdCorteNormal.CurrentCell.ColumnIndex = 0 Then
    '            If grdCorteNormal.IsCurrentCellDirty Then
    '                grdCorteNormal.CommitEdit(DataGridViewDataErrorContexts.Commit)
    '                For Each filaCorte As DataGridViewRow In grdCorteNormal.Rows
    '                    If Not filaCorte Is grdCorteNormal.Rows(grdCorteNormal.CurrentCell.RowIndex) Then
    '                        filaCorte.Cells(0).Value = False
    '                    End If
    '                Next
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub lblAgregarDato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAgregarDato.Click

    End Sub

    Private Sub grdDetallesEstilos_AfterHeaderCheckStateChanged(sender As Object, e As AfterHeaderCheckStateChangedEventArgs) Handles grdDetallesEstilos.AfterHeaderCheckStateChanged

        For Each rowDTF As UltraGridRow In grdDetallesEstilos.Rows.GetFilteredInNonGroupByRows
            rowDTF.Cells("seleccion").Value = checkCabeceraEstado
        Next
    End Sub

    'Private Sub grdDetallesEstilos_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles grdDetallesEstilos.AfterRowFilterChanged
    '    Me.grdDetallesEstilos.DisplayLayout.Bands(0).Columns("seleccion").Header.ResetCaption()
    'End Sub

    Private Sub grdDetallesEstilos_BeforeHeaderCheckStateChanged(sender As Object, e As BeforeHeaderCheckStateChangedEventArgs) Handles grdDetallesEstilos.BeforeHeaderCheckStateChanged
        checkCabeceraEstado = CBool(e.NewCheckState)
    End Sub
    Private Sub grdDetallesEstilo_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdDetallesEstilos.CellChange

        Dim i As Integer
        i = grdDetallesEstilos.ActiveRow.Index
        Dim objPBU As New Programacion.Negocios.ProductosBU
        If e.Cell.Column.[Key] = ("idFamiliaVentas") Then
            Dim objProdBU As New Negocios.FamiliasBU

            Dim dtDatosFamilias As DataTable

            dtDatosFamilias = objProdBU.VerComboFamiliaVentas


            For Each rowdt As DataRow In dtDatosFamilias.Rows
                If rowdt("fapr_descripcion") = e.Cell.Text Then
                    e.Cell.Value = rowdt("fapr_familiaproyeccionid")
                    Dim idtalla As Integer = grdDetallesEstilos.Rows(i).Cells("idTalla").Value

                    grdDetallesEstilos.Rows(i).Cells("idClaveSAT").Value = objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, rowdt("fapr_familiaproyeccionid"), grdDetallesEstilos.Rows(i).Cells("idTalla").Value, grdDetallesEstilos.Rows(i).Cells("idColor").Value)

                    Exit For
                End If
            Next

        End If
        If e.Cell.Column.[Key] = ("Horma") Then
            'Dim idhorma As String = grdDetallesEstilos.Rows(i).Cells("Horma").Value
            Dim hormanuevo = e.Cell.Text
            Dim dthormas As DataTable = objPBU.buscarHormaId(hormanuevo)
            grdDetallesEstilos.Rows(i).Cells("IdHorma").Value = dthormas.Rows(0).Item("HormaID")
        End If
        'If e.Cell.Column.[Key] = ("idFamiliaVentas") Then
        '    Dim objProdBU As New Negocios.FamiliasBU
        '    Dim objPBU As New Programacion.Negocios.ProductosBU
        '    Dim dtDatosFamilias As DataTable
        '    dtDatosFamilias = objProdBU.VerComboFamiliaVentas
        '    Dim i As Integer
        '    i = grdDetallesEstilos.ActiveRow.Index

        '    For Each rowdt As DataRow In dtDatosFamilias.Rows
        '        If rowdt("fapr_descripcion") = e.Cell.Text Then
        '            e.Cell.Value = rowdt("fapr_familiaproyeccionid")
        '            Dim idtalla As Integer = grdDetallesEstilos.Rows(i).Cells("idTalla").Value

        '            grdDetallesEstilos.Rows(i).Cells("idClaveSAT").Value = objPBU.buscarClaveArticuloAgregado(txtCategoria.Text, rowdt("fapr_familiaproyeccionid"), grdDetallesEstilos.Rows(i).Cells("idTalla").Value, grdDetallesEstilos.Rows(i).Cells("idColor").Value)

        '            Exit For
        '        End If
        '    Next

        'End If
    End Sub

    Private Sub grdDetallesEstilos_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdDetallesEstilos.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        Dim dtEstiloEncontrado As New DataTable
        Dim objPBU As New Negocios.ProductosBU
        Dim estilos As String = ""
        For Each rowGrdS As UltraGridRow In e.Rows
            If rowGrdS.Cells("pstilo").Value.ToString <> "" Then
                dtEstiloEncontrado = objPBU.consultarExisteEstiloConsumos(CInt(rowGrdS.Cells("pstilo").Value.ToString), CInt(rowGrdS.Cells("idTalla").Value.ToString))
                If CInt(dtEstiloEncontrado.Rows(0).Item(0).ToString) > 0 Or
                    CInt(dtEstiloEncontrado.Rows(0).Item(1).ToString) > 0 Or
                    CInt(dtEstiloEncontrado.Rows(0).Item(2).ToString) > 0 Or
                    CInt(dtEstiloEncontrado.Rows(0).Item(3).ToString) > 0 Then
                    estilos += "● Fila: " + CStr(CInt(rowGrdS.Index) + 1)
                    estilos += " (Módulos: "

                    If CInt(dtEstiloEncontrado.Rows(0).Item(0).ToString) > 0 Then
                        estilos += " -Módulo de Pedidos Virtuales "
                    End If
                    If CInt(dtEstiloEncontrado.Rows(0).Item(1).ToString) > 0 Then
                        estilos += " -Módulo de Capacidades de Producción "
                    End If
                    If CInt(dtEstiloEncontrado.Rows(0).Item(2).ToString) > 0 Or CInt(dtEstiloEncontrado.Rows(0).Item(3).ToString) > 0 Then
                        estilos += " -Módulo de Programación "
                    End If
                    estilos += ")" + Chr(13)
                End If
            End If
        Next

        If estilos = "" Then
            e.Cancel = False
        Else
            Dim adv As New AdvertenciaForm
            adv.mensaje = "No se pueden quitar los Artículos que se encuentran con algún registro en módulos de programación."
            adv.ShowDialog()
            e.Cancel = True
        End If

    End Sub

    Private Sub grdForros_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdForros.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdPieles_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdPieles.BeforeRowsDeleted
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

    Private Sub grdFamilia_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamilia.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdLinea_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdLinea.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdPieles_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdPieles.CellChange
        If (e.Cell.Column.Key = "selectPcol" And e.Cell.Row.Index <> grdDetallesEstilos.Rows.FilterRow.Index) Then
            If (estiloCliente = True) Then
                For Each rowP As UltraGridRow In grdPieles.Rows
                    rowP.Cells("selectPcol").Value = False
                Next
                e.Cell().Value = True
            End If
        End If
    End Sub

    Private Sub grdCorte_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdCorte.CellChange
        If (e.Cell.Column.Key = "selectCorte" And e.Cell.Row.Index <> grdDetallesEstilos.Rows.FilterRow.Index) Then
            If (estiloCliente = True) Then
                For Each rowC As UltraGridRow In grdCorte.Rows
                    rowC.Cells("selectCorte").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdForros_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdForros.CellChange
        If (e.Cell.Column.Key = "selectForro" And e.Cell.Row.Index <> grdDetallesEstilos.Rows.FilterRow.Index) Then
            If (estiloCliente = True) Then
                For Each rowF As UltraGridRow In grdForros.Rows
                    rowF.Cells("selectForro").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdSuela_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdSuela.CellChange
        If (e.Cell.Column.Key = "selectSuela" And e.Cell.Row.Index <> grdDetallesEstilos.Rows.FilterRow.Index) Then
            If (estiloCliente = True) Then
                For Each rowS As UltraGridRow In grdSuela.Rows
                    rowS.Cells("selectSuela").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdTalla_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdTalla.CellChange
        If (e.Cell.Column.Key = "selectTalla" And e.Cell.Row.Index <> grdDetallesEstilos.Rows.FilterRow.Index) Then
            If (estiloCliente = True) Then
                For Each rowT As UltraGridRow In grdTalla.Rows
                    rowT.Cells("selectTalla").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdFamilia_CellChange(sender As Object, e As CellEventArgs) Handles grdFamilia.CellChange
        If (e.Cell.Column.Key = "selectFamilia" And e.Cell.Row.Index <> grdDetallesEstilos.Rows.FilterRow.Index) Then
            If (estiloCliente = True) Then
                For Each rowT As UltraGridRow In grdFamilia.Rows
                    rowT.Cells("selectFamilia").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub grdLinea_CellChange(sender As Object, e As CellEventArgs) Handles grdLinea.CellChange
        If (e.Cell.Column.Key = "selectLinea" And e.Cell.Row.Index <> grdDetallesEstilos.Rows.FilterRow.Index) Then
            If (estiloCliente = True) Then
                For Each rowT As UltraGridRow In grdLinea.Rows
                    rowT.Cells("selectLinea").Value = False
                Next
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub txtCodSicy_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodSicy.LostFocus
        If (codSicyMarca <> "" And codSicyColeccion <> "") Then

            If (txtCodSicy.Text.Length > 0) Then

                If estiloCliente = True And codSicyMarca <> "A" Then
                    Try
                        codSicyMarca = cmbMarcasCasa.SelectedValue
                    Catch ex As Exception
                        codSicyMarca = ""

                    End Try
                End If

                Dim objProd As New Programacion.Negocios.ProductosBU
                Dim dtDatoContSicyRepetido As New DataTable
                Dim dtDatoContSicyExiste As New DataTable
                Dim dtSicyMarcaColeccion As New DataTable

                Dim contRepetido As Int32 = 0
                Dim contExiste As Int32 = 0
                Dim contSicyMarcColc As Int32 = 0

                dtDatoContSicyRepetido = objProd.validaSicyEnProducto(txtCodSicy.Text, idProducto, idMarca, idColeccion)
                dtDatoContSicyExiste = objProd.validaExistenciaModeloSicy(txtCodSicy.Text)
                dtSicyMarcaColeccion = objProd.validaExisteSicyMarcaColeccion(txtCodSicy.Text, codSicyMarca, codSicyColeccion)

                contRepetido = CInt(dtDatoContSicyRepetido.Rows(0)(0).ToString)
                contExiste = CInt(dtDatoContSicyExiste.Rows(0)(0).ToString)
                contSicyMarcColc = CInt(dtSicyMarcaColeccion.Rows(0)(0).ToString)

                If (contExiste = 0) Then
                    txtCodSicy.Text = String.Empty
                    MsgBox("El modelo de SICY que ingreso no existe.", MsgBoxStyle.Exclamation, "Modelo SICY")
                    For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                        rowEst.Cells("Sicy").Value = ""
                        rowEst.Cells("IdMarcaCasa").Value = ""
                    Next
                Else
                    If (contSicyMarcColc = 0) Then
                        txtCodSicy.Text = String.Empty
                        MsgBox("El modelo de SICY que ingreso no esta disponible en la marca y colección seleccionadas.", MsgBoxStyle.Exclamation, "Modelo SICY")
                        For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                            rowEst.Cells("Sicy").Value = ""
                            rowEst.Cells("IdMarcaCasa").Value = ""
                        Next
                    ElseIf (contRepetido >= 1) Then
                        If (primerCodMarca <> txtMarca.Text And primerCodColeccion <> txtColeccion.Text And primerModelo <> txtCodSicy.Text) Then
                            ' txtCodSicy.Text = primerModelo
                            txtCodSicy.Text = String.Empty
                            MsgBox("El modelo de SICY que ingreso ya se encuentra en otro registro.", MsgBoxStyle.Exclamation, "Modelo SICY")
                            For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
                                rowEst.Cells("Sicy").Value = ""
                                rowEst.Cells("IdMarcaCasa").Value = ""
                            Next
                        End If
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

            End If
        Else
            txtCodSicy.Text = String.Empty
        End If
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

    Public Sub AbrirHormaDetalle()
        Dim fila As Int32
        Dim columna As String
        Try
            If Not (grdDetallesEstilos.ActiveRow.Index.ToString = Nothing And grdDetallesEstilos.ActiveCell.Column.Key.ToString = Nothing) Then
                fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
                columna = (grdDetallesEstilos.ActiveCell.Column.Key)
                If (columna = "Horma") Then
                    Dim objHorma As New HormaFormRapido
                    objHorma.ShowDialog()
                    If Not (objHorma.PidHorma = 0 And objHorma.PnombreHorma = Nothing) Then
                        grdDetallesEstilos.Rows(fila).Cells("idHorma").Value = CInt(objHorma.PidHorma)
                        grdDetallesEstilos.Rows(fila).Cells("Horma").Value = objHorma.PnombreHorma
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Function validarCambio(ByVal idestilo As String, ByVal talla As Int32) As Boolean
        Dim dtEstiloEncontrado As New DataTable
        Dim objPBU As New Negocios.ProductosBU
        Dim estilos As String = ""

        If idestilo <> "" Then
            dtEstiloEncontrado = objPBU.consultarExisteEstiloConsumos(idestilo, talla)
            If CInt(dtEstiloEncontrado.Rows(0).Item(0).ToString) > 0 Or
                CInt(dtEstiloEncontrado.Rows(0).Item(1).ToString) > 0 Or
                CInt(dtEstiloEncontrado.Rows(0).Item(2).ToString) > 0 Or
                CInt(dtEstiloEncontrado.Rows(0).Item(3).ToString) > 0 Then
                estilos += " (Módulos: "

                If CInt(dtEstiloEncontrado.Rows(0).Item(0).ToString) > 0 Then
                    estilos += " -Módulo de Pedidos Virtuales "
                End If
                If CInt(dtEstiloEncontrado.Rows(0).Item(1).ToString) > 0 Then
                    estilos += " -Módulo de Capacidades de Producción "
                End If
                If CInt(dtEstiloEncontrado.Rows(0).Item(2).ToString) > 0 Or CInt(dtEstiloEncontrado.Rows(0).Item(3).ToString) > 0 Then
                    estilos += " -Módulo de Programación "
                End If

                estilos += ")" + Chr(13)
            End If
        End If

        If estilos <> "" Then
            MsgBox("No puede editar los Artículos que se encuentran con algún registro en módulos de programación." + Chr(13) + estilos, MsgBoxStyle.Information, "¡Importante!")
            Return False
        End If

        Return True
    End Function

    Private Sub grdDetallesEstilos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdDetallesEstilos.DoubleClickCell

        If e.Cell.Column.Key = "Sicy" And e.Cell.IsFilterRowCell = False And estiloCliente = True And codSicyMarca <> "A" Then
            Dim mainElement As UIElement
            Dim element As UIElement
            Dim screenPoint As Point
            Dim clientPoint As Point
            Dim row As UltraGridRow
            Dim cell As UltraGridCell

            mainElement = Me.grdDetallesEstilos.DisplayLayout.UIElement

            screenPoint = Control.MousePosition
            clientPoint = Me.grdDetallesEstilos.PointToClient(screenPoint)

            element = mainElement.ElementFromPoint(clientPoint)

            If element Is Nothing Then Return

            row = element.GetContext(GetType(UltraGridRow))

            If Not row Is Nothing Then

                cell = element.GetContext(GetType(UltraGridCell))

                If Not cell Is Nothing Then
                    Dim objMarcaBU As New Negocios.MarcasBU
                    Dim dtDatosMarcas As DataTable
                    dtDatosMarcas = objMarcaBU.verMarcasYuyin()

                    Dim cms = New ContextMenuStrip

                    For Each rowDT As DataRow In dtDatosMarcas.Rows
                        Dim itemd = cms.Items.Add(rowDT.Item(2).ToString)
                        itemd.Tag = rowDT.Item(1).ToString
                        AddHandler itemd.Click, AddressOf grdDetallesEstilos_menuChoice
                    Next

                    cms.Show(Control.MousePosition)

                End If
            End If

            While Not element.Parent Is Nothing
                element = element.Parent
            End While
        ElseIf e.Cell.Column.Key = "Horma" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
            grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                If validarCambio(grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("pstilo").Value.ToString, grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("idTalla").Value.ToString) = True Then
                    Dim fila As Int32
                    fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
                    Dim objHorma As New HormaFormRapido
                    objHorma.ShowDialog()
                    If Not (objHorma.PidHorma = 0 And objHorma.PnombreHorma = Nothing) Then
                        grdDetallesEstilos.Rows(fila).Cells("idHorma").Value = CInt(objHorma.PidHorma)
                        grdDetallesEstilos.Rows(fila).Cells("Horma").Value = objHorma.PnombreHorma
                    End If
                End If
            End If

        ElseIf e.Cell.Column.Key = "SuelaProgramacion" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
            grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                If validarCambio(grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("pstilo").Value.ToString, grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("idTalla").Value.ToString) = True Then
                    Dim fila As Int32
                    fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
                    Dim objHorma As New SuelaFormRapido
                    objHorma.ShowDialog()
                    If Not (objHorma.PIdSuela = 0 And (objHorma.PNombreSuela = String.Empty Or objHorma.PNombreSuela = Nothing)) Then
                        grdDetallesEstilos.Rows(fila).Cells("SuelaProgramacionID").Value = CInt(objHorma.PIdSuela)
                        grdDetallesEstilos.Rows(fila).Cells("SuelaProgramacion").Value = objHorma.PNombreSuela
                    End If
                End If
            End If

        ElseIf e.Cell.Column.Key = "ColorSuela" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
            grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                If validarCambio(grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("pstilo").Value.ToString, grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("idTalla").Value.ToString) = True Then
                    Dim fila As Int32
                    fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
                    Dim objColorSuela As New ColorSuelaFormRapido
                    objColorSuela.ShowDialog()
                    If Not (objColorSuela.PIdSuelaColor = 0 And (objColorSuela.PNombreColor = String.Empty)) Then
                        grdDetallesEstilos.Rows(fila).Cells("ColorSuelaID").Value = CInt(objColorSuela.PIdSuelaColor)
                        grdDetallesEstilos.Rows(fila).Cells("ColorSuela").Value = objColorSuela.PNombreColor
                    End If
                End If
            End If








        ElseIf e.Cell.Column.Key = "nomSts" And e.Cell.IsFilterRowCell = False Then
            Dim mainElementSTS As UIElement
            Dim elementSTS As UIElement
            Dim screenPointSTS As Point
            Dim clientPointSTS As Point
            Dim rowSTS As UltraGridRow
            Dim cellSTS As UltraGridCell

            mainElementSTS = Me.grdDetallesEstilos.DisplayLayout.UIElement

            screenPointSTS = Control.MousePosition
            clientPointSTS = Me.grdDetallesEstilos.PointToClient(screenPointSTS)

            elementSTS = mainElementSTS.ElementFromPoint(clientPointSTS)

            If elementSTS Is Nothing Then Return

            rowSTS = elementSTS.GetContext(GetType(UltraGridRow))

            If Not rowSTS Is Nothing Then

                cellSTS = elementSTS.GetContext(GetType(UltraGridCell))

                If Not cellSTS Is Nothing Then
                    Dim objProdBU As New Negocios.ProductosBU
                    Dim dtDatosEstatus As DataTable
                    dtDatosEstatus = objProdBU.estatusProductos()

                    Dim cms = New ContextMenuStrip

                    For Each rowDT As DataRow In dtDatosEstatus.Rows
                        Dim itemd = cms.Items.Add(rowDT.Item("stpr_descripcion").ToString)
                        itemd.Tag = rowDT.Item("stpr_productoStatusId").ToString
                        AddHandler itemd.Click, AddressOf grdDetallesEstilos_menuChoice_Estatus
                    Next

                    cms.Show(Control.MousePosition)

                End If
            End If

            While Not elementSTS.Parent Is Nothing
                elementSTS = elementSTS.Parent
            End While

        ElseIf e.Cell.Column.Key = "familia" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
                    grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                Dim mainElementFAM As UIElement
                Dim elementFAM As UIElement
                Dim screenPointFAM As Point
                Dim clientPointFAM As Point
                Dim rowFAM As UltraGridRow
                Dim cellFAM As UltraGridCell

                mainElementFAM = Me.grdDetallesEstilos.DisplayLayout.UIElement

                screenPointFAM = Control.MousePosition
                clientPointFAM = Me.grdDetallesEstilos.PointToClient(screenPointFAM)

                elementFAM = mainElementFAM.ElementFromPoint(clientPointFAM)

                If elementFAM Is Nothing Then Return

                rowFAM = elementFAM.GetContext(GetType(UltraGridRow))

                If Not rowFAM Is Nothing Then

                    cellFAM = elementFAM.GetContext(GetType(UltraGridCell))

                    If Not cellFAM Is Nothing Then
                        Dim objProdBU As New Negocios.FamiliasBU
                        Dim dtDatosFamilias As DataTable
                        dtDatosFamilias = objProdBU.verComboFamilias("")

                        Dim cms = New ContextMenuStrip

                        For Each rowDT As DataRow In dtDatosFamilias.Rows
                            Dim itemd = cms.Items.Add(rowDT.Item("fami_descripcion").ToString)
                            itemd.Tag = rowDT.Item("fami_familiaid").ToString
                            AddHandler itemd.Click, AddressOf grdDetallesEstilos_menuChoice_Familias
                        Next

                        cms.Show(Control.MousePosition)

                    End If
                End If

                While Not elementFAM.Parent Is Nothing
                    elementFAM = elementFAM.Parent
                End While
            End If

        ElseIf e.Cell.Column.Key = "familia ventas" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
                   grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                Dim mainElementFAM As UIElement
                Dim elementFAM As UIElement
                Dim screenPointFAM As Point
                Dim clientPointFAM As Point
                Dim rowFAM As UltraGridRow
                Dim cellFAM As UltraGridCell

                mainElementFAM = Me.grdDetallesEstilos.DisplayLayout.UIElement

                screenPointFAM = Control.MousePosition
                clientPointFAM = Me.grdDetallesEstilos.PointToClient(screenPointFAM)

                elementFAM = mainElementFAM.ElementFromPoint(clientPointFAM)

                If elementFAM Is Nothing Then Return

                rowFAM = elementFAM.GetContext(GetType(UltraGridRow))

                If Not rowFAM Is Nothing Then

                    cellFAM = elementFAM.GetContext(GetType(UltraGridCell))

                    If Not cellFAM Is Nothing Then
                        Dim objProdBU As New Negocios.FamiliasBU
                        Dim dtDatosFamilias As DataTable
                        dtDatosFamilias = objProdBU.VerComboFamiliaVentas

                        Dim cms = New ContextMenuStrip

                        For Each rowDT As DataRow In dtDatosFamilias.Rows
                            Dim itemd = cms.Items.Add(rowDT.Item("fapr_descripcion").ToString)
                            itemd.Tag = rowDT.Item("fapr_familiaproyeccionid").ToString
                            AddHandler itemd.Click, AddressOf grdDetallesEstilos_menuChoice_FamiliasVentas
                        Next

                        cms.Show(Control.MousePosition)

                    End If
                End If

                While Not elementFAM.Parent Is Nothing
                    elementFAM = elementFAM.Parent
                End While
            End If

        ElseIf e.Cell.Column.Key = "linea" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
                   grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                Dim mainElementFAM As UIElement
                Dim elementFAM As UIElement
                Dim screenPointFAM As Point
                Dim clientPointFAM As Point
                Dim rowFAM As UltraGridRow
                Dim cellFAM As UltraGridCell

                mainElementFAM = Me.grdDetallesEstilos.DisplayLayout.UIElement

                screenPointFAM = Control.MousePosition
                clientPointFAM = Me.grdDetallesEstilos.PointToClient(screenPointFAM)

                elementFAM = mainElementFAM.ElementFromPoint(clientPointFAM)

                If elementFAM Is Nothing Then Return

                rowFAM = elementFAM.GetContext(GetType(UltraGridRow))

                If Not rowFAM Is Nothing Then

                    cellFAM = elementFAM.GetContext(GetType(UltraGridCell))

                    If Not cellFAM Is Nothing Then
                        Dim objProdBU As New Negocios.FamiliasBU
                        Dim dtDatosFamilias As DataTable
                        dtDatosFamilias = objProdBU.VerComboFamiliaVentas

                        Dim cms = New ContextMenuStrip

                        For Each rowDT As DataRow In dtDatosFamilias.Rows
                            Dim itemd = cms.Items.Add(rowDT.Item("fapr_descripcion").ToString)
                            itemd.Tag = rowDT.Item("fapr_familiaproyeccionid").ToString
                            AddHandler itemd.Click, AddressOf grdDetallesEstilos_menuChoice_FamiliasVentas
                        Next

                        cms.Show(Control.MousePosition)

                    End If
                End If

                While Not elementFAM.Parent Is Nothing
                    elementFAM = elementFAM.Parent
                End While
            End If


        ElseIf e.Cell.Column.Key = "pielColor" And e.Cell.IsFilterRowCell = False Then
            'If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
            '      grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Then
                If validarCambio(grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("pstilo").Value.ToString, grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("idTalla").Value.ToString) = True Then
                    Dim fila As Int32
                    fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
                    Dim objPcol As New pielColorSeleccionRapido
                    objPcol.ShowDialog()
                    If Not (objPcol.PIdPiel = 0 And objPcol.PIdColor.ToString = 0 And objPcol.PPielColor = "") Then
                        grdDetallesEstilos.Rows(fila).Cells("idPiel").Value = CInt(objPcol.PIdPiel)
                        grdDetallesEstilos.Rows(fila).Cells("idColor").Value = CInt(objPcol.PIdColor)
                        grdDetallesEstilos.Rows(fila).Cells("pielColor").Value = objPcol.PPielColor
                        grdDetallesEstilos.Rows(fila).Cells("sicyPCOL").Value = objPcol.PSICY

                        If objPcol.PSICY <> "" Then
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
                End If
            End If


        ElseIf e.Cell.Column.Key = "talla" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
                  grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                If grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("pstilo").Value.ToString <> "" Then
                    Dim dtEstiloEncontrado As New DataTable
                    Dim objPBU As New Negocios.ProductosBU
                    Dim estilos As String = ""
                    dtEstiloEncontrado = objPBU.consultarExisteEstiloConsumos(CInt(grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("pstilo").Value.ToString), CInt(grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("idTalla").Value.ToString))
                    If CInt(dtEstiloEncontrado.Rows(0).Item(0).ToString) > 0 Or
                            CInt(dtEstiloEncontrado.Rows(0).Item(1).ToString) > 0 Or
                            CInt(dtEstiloEncontrado.Rows(0).Item(2).ToString) > 0 Or
                            CInt(dtEstiloEncontrado.Rows(0).Item(3).ToString) > 0 Then
                        estilos += "● Estilo: " + grdDetallesEstilos.Rows(e.Cell.Row.Index).Cells("pstilo").Value.ToString
                        estilos += " (Tablas: "
                        If CInt(dtEstiloEncontrado.Rows(0).Item(0).ToString) > 0 Then
                            estilos += " -TotalPedidoVirtualDetalle "
                        End If
                        If CInt(dtEstiloEncontrado.Rows(0).Item(1).ToString) > 0 Then
                            estilos += " -TotalProductosCapacidad "
                        End If
                        If CInt(dtEstiloEncontrado.Rows(0).Item(2).ToString) > 0 Then
                            estilos += " -TotalProgramacionNave "
                        End If
                        If CInt(dtEstiloEncontrado.Rows(0).Item(3).ToString) > 0 Then
                            estilos += " -TotalProgamasRenglon "
                        End If
                        estilos += ")" + Chr(13)
                    End If
                    If estilos = "" Then
                        Dim fila As Int32
                        fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
                        Dim objTallas As New tallaSeleccionRapida
                        objTallas.ShowDialog()
                        If Not (objTallas.PIdCorrida = 0 And objTallas.PCorrida = "") Then
                            grdDetallesEstilos.Rows(fila).Cells("idTalla").Value = CInt(objTallas.PIdCorrida)
                            grdDetallesEstilos.Rows(fila).Cells("talla").Value = objTallas.PCorrida
                        End If
                    Else
                        MsgBox("No se puede cambiar la talla del estilo si este se encuentra registrado en alguna tabla de consumos." + Chr(13) + estilos, MsgBoxStyle.Information, "¡Importante!")
                    End If
                End If
            End If


        ElseIf e.Cell.Column.Key = "corte" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
                 grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                Dim mainElementLN As UIElement
                Dim elementLN As UIElement
                Dim screenPointLN As Point
                Dim clientPointLN As Point
                Dim rowLN As UltraGridRow
                Dim cellLN As UltraGridCell

                mainElementLN = Me.grdDetallesEstilos.DisplayLayout.UIElement

                screenPointLN = Control.MousePosition
                clientPointLN = Me.grdDetallesEstilos.PointToClient(screenPointLN)

                elementLN = mainElementLN.ElementFromPoint(clientPointLN)

                If elementLN Is Nothing Then Return

                rowLN = elementLN.GetContext(GetType(UltraGridRow))

                If Not rowLN Is Nothing Then

                    cellLN = elementLN.GetContext(GetType(UltraGridCell))

                    If Not cellLN Is Nothing Then
                        Dim objProdBU As New Negocios.PielesMuestraBU
                        Dim dtDatosCortes As DataTable
                        dtDatosCortes = objProdBU.VerPielesMuestra("", "", True)

                        Dim cms = New ContextMenuStrip

                        For Each rowDT As DataRow In dtDatosCortes.Rows
                            Dim itemd = cms.Items.Add(rowDT.Item("plmu_descripcion").ToString)
                            itemd.Tag = rowDT.Item("plmu_pielmuestraid").ToString
                            AddHandler itemd.Click, AddressOf grdDetallesEstilos_menuChoice_Cortes
                        Next

                        cms.Show(Control.MousePosition)

                    End If
                End If

                While Not elementLN.Parent Is Nothing
                    elementLN = elementLN.Parent
                End While

            End If

        ElseIf e.Cell.Column.Key = "forro" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
                 grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                Dim fila As Int32
                fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
                Dim objTallas As New forroSeleccionRapido
                objTallas.ShowDialog()
                If Not (objTallas.PIdForro = 0 And objTallas.PForro = "") Then
                    grdDetallesEstilos.Rows(fila).Cells("idForro").Value = CInt(objTallas.PIdForro)
                    grdDetallesEstilos.Rows(fila).Cells("forro").Value = objTallas.PForro
                End If
            End If


        ElseIf e.Cell.Column.Key = "suela" And e.Cell.IsFilterRowCell = False Then
            If grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "PROTOTIPO" Or
                grdDetallesEstilos.ActiveRow.Cells("nomSts").Value = "MUESTRA" Then
                Dim fila As Int32
                fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)
                Dim objTallas As New suelaSeleccionRapido
                objTallas.ShowDialog()
                If Not (objTallas.PIdSuela = 0 And objTallas.PSuela = "") Then
                    grdDetallesEstilos.Rows(fila).Cells("idSuela").Value = CInt(objTallas.PIdSuela)
                    grdDetallesEstilos.Rows(fila).Cells("suela").Value = objTallas.PSuela
                End If
            End If

        ElseIf e.Cell.Column.Key = "Fracción_Arancelaria" And e.Cell.IsFilterRowCell = False Then
            If Not IsDBNull(e.Cell.Value) Then
                Dim objFracciones As New Catalogo_FraccionesArancelarias_De_Modelo_En_EspecificoForm
                Dim objFraccion_Detalle As New Entidades.Fracciones_Arancelarias_Detalles
                Dim fila As Int32
                fila = CInt(grdDetallesEstilos.ActiveRow.Index.ToString)

                objFraccion_Detalle.PFamiliaId = grdDetallesEstilos.Rows(fila).Cells("idFamilia").Value
                objFraccion_Detalle.PForroId = grdDetallesEstilos.Rows(fila).Cells("idForro").Value
                objFraccion_Detalle.PPielMuestraId = grdDetallesEstilos.Rows(fila).Cells("IdCorte").Value
                objFraccion_Detalle.PSuelaId = grdDetallesEstilos.Rows(fila).Cells("idSuela").Value()
                objFraccion_Detalle.PTipoCategoriaId = CInt(txtCategoria.Text)

                objFracciones.objFraccion_Detalle = objFraccion_Detalle
                objFracciones.IdCorrida = grdDetallesEstilos.Rows(fila).Cells("IdTalla").Value
                objFracciones.StartPosition = FormStartPosition.CenterScreen
                objFracciones.ShowDialog()

            End If
        End If

    End Sub

    'Private Sub grdDetallesEstilos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdDetallesEstilos.DoubleClickRow
    '    AbrirHormaDetalle()
    'End Sub

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

    Private Sub txtCodSicy_TextChanged(sender As Object, e As EventArgs) Handles txtCodSicy.TextChanged
        For Each rowEst As UltraGridRow In grdDetallesEstilos.Rows
            rowEst.Cells("Sicy").Value = ""
            rowEst.Cells("IdMarcaCasa").Value = ""
        Next
    End Sub


    Private Sub txtCodCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodCliente.KeyDown
        If e.KeyCode = Keys.C And e.Modifiers = Keys.Control Then
            txtCodCliente.Copy()
        End If
    End Sub

    Private Sub txtCodCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodCliente.KeyPress
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

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.C And e.Modifiers = Keys.Control Then
            txtCodigo.Copy()
        End If
    End Sub

    Private Sub rdoPieles_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPieles.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        'grdPieles.Width = 303

    End Sub

    Private Sub rdoTallas_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTallas.CheckedChanged
        grdTalla.Width = 303
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        'grdPieles.Width = 145
    End Sub

    Private Sub rdoCorte_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCorte.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 303
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        'grdPieles.Width = 145
    End Sub

    Private Sub rdoForro_CheckedChanged(sender As Object, e As EventArgs) Handles rdoForro.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 303
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 145
        'grdPieles.Width = 145
    End Sub

    Private Sub rdoSuela_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSuela.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 303
        grdFamilia.Width = 145
        grdLinea.Width = 145
        'grdPieles.Width = 145
    End Sub

    Private Sub rodFamilia_CheckedChanged(sender As Object, e As EventArgs) Handles rodFamilia.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 303
        grdLinea.Width = 145
        'grdPieles.Width = 145
    End Sub

    Private Sub rdoLinea_CheckedChanged(sender As Object, e As EventArgs) Handles rdoLinea.CheckedChanged
        grdTalla.Width = 145
        grdCorte.Width = 145
        grdForros.Width = 145
        grdSuela.Width = 145
        grdFamilia.Width = 145
        grdLinea.Width = 303
        'grdPieles.Width = 145
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        pnlContenedorGrids.Height = 162
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlContenedorGrids.Height = 0
    End Sub

    Private Sub btnCategoria_Click(sender As Object, e As EventArgs) Handles btnCategoria.Click
        Dim objCategoria As New CategoriaFormRapido
        objCategoria.ShowDialog()

        If (objCategoria.PidCategoria <> 0) Then
            idCategoria = objCategoria.PidCategoria
            lblNombreCategoria.Text = objCategoria.PnombreCategoria
            txtCategoria.Text = objCategoria.PidCategoria
            ' ''Else
            ' ''    idCategoria = 0
            ' ''    lblNombreCategoria.Text = ""
            ' ''    txtCategoria.Text = String.Empty
        End If
        txtCategoria.Focus()
    End Sub

    Private Sub cmbMarcasCasa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcasCasa.SelectedIndexChanged
        If estiloCliente = True And codSicyMarca <> "A" Then
            Try
                codSicyMarca = cmbMarcasCasa.SelectedValue
            Catch ex As Exception
                codSicyMarca = ""
            End Try
        End If

    End Sub

    Private Sub txtCategoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCategoria.KeyPress
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

    Private Sub txtCategoria_LostFocus(sender As Object, e As EventArgs) Handles txtCategoria.LostFocus
        If (txtCategoria.Text <> Nothing) Then
            If (idCategoria = 0 Or idCategoria <> txtCategoria.Text) Then

                Dim objCategoria As New Programacion.Negocios.CategoriasBU
                Dim dtDatosCategoria As New DataTable
                dtDatosCategoria = objCategoria.verCategoriaRapido(txtCategoria.Text)
                If (dtDatosCategoria.Rows.Count > 0) Then
                    idCategoria = CInt(dtDatosCategoria.Rows(0)(0).ToString)
                    txtCategoria.Text = dtDatosCategoria.Rows(0)(0).ToString
                    lblNombreCategoria.Text = dtDatosCategoria.Rows(0)(1).ToString
                Else
                    txtCategoria.Text = String.Empty
                    idCategoria = 0
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
            lblNombreCategoria.Text = ""
            txtCategoria.Text = String.Empty
        Else
            Dim objCategoria As New Programacion.Negocios.CategoriasBU
            Dim dtDatosCategoria As New DataTable

            dtDatosCategoria = objCategoria.verCategoriaRapido(txtCategoria.Text)
            If (dtDatosCategoria.Rows.Count > 0) Then
                idCategoria = CInt(dtDatosCategoria.Rows(0)(0).ToString)
                lblNombreCategoria.Text = dtDatosCategoria.Rows(0)(1).ToString
            Else
                idCategoria = 0
                lblNombreCategoria.Text = ""
                txtCategoria.Text = String.Empty

                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "La categoría que ingreso no existe."
                advertenciaMensaje.ShowDialog()
            End If
        End If
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
        If e.Header.Column.Key = "pielcol" Then
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

    Private Sub picFoto_DoubleClick(sender As Object, e As EventArgs) Handles picFoto.DoubleClick
        Dim objFotoImagen As New FotoModelo
        objFotoImagen.pcbFotoMax.Image = picFoto.Image
        objFotoImagen.ShowDialog()
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

    Private Sub grdDetallesEstilos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDetallesEstilos.InitializeLayout

    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstatus.SelectedIndexChanged
        If cmbEstatus.SelectedValue.ToString <> "" And cmbEstatus.Text.ToString <> "" Then
            For Each rowGrd As UltraGridRow In grdDetallesEstilos.Rows
                If CBool(rowGrd.Cells("seleccion").Value) = True Then

                    rowGrd.Cells("psEstatus").Value = cmbEstatus.SelectedValue.ToString
                    rowGrd.Cells("nomSts").Value = cmbEstatus.Text.ToString
                End If
            Next
        End If
    End Sub


    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Try
            If idMarca >= 0 Then
                Dim objClientes As New ListaConsultaClientesForm
                objClientes.accionFormulario = "descripcionEspecialClienteEditar"
                objClientes.idMarca = idMarca
                objClientes.idColeccion = idColeccion
                objClientes.idModelo = idProducto
                objClientes.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Ocurrió algo inesperado.")
        End Try
    End Sub

    Private Sub cmbNaveDesarrolla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaveDesarrolla.SelectedIndexChanged
        Try
            If cmbNaveDesarrolla.SelectedValue.ToString <> "" And cmbNaveDesarrolla.Text.ToString <> "" Then
                If cmbNaveDesarrolla.SelectedIndex > 0 Then
                    idNaveDesarrolla = cmbNaveDesarrolla.SelectedValue
                End If
            End If
        Catch ex As Exception

        End Try

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

    Private Sub grdFamVentas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs)
        e.Cancel = True
    End Sub

    Private Sub grdFamVentas_CellChange(sender As Object, e As CellEventArgs)
        'If (e.Cell.Column.Key = "selectFamilia" And e.Cell.Row.Index <> grdDetallesEstilos.Rows.FilterRow.Index) Then
        '    If (estiloCliente = True) Then
        '        For Each rowT As UltraGridRow In grdFamVentas.Rows
        '            rowT.Cells("selectFamilia").Value = False
        '        Next
        '        e.Cell.Value = True
        '    End If
        'End If
    End Sub
    Function validarCambioEstatus(deEstatus As String, aEstatus As String)
        If deEstatus = "PROTOTIPO" Then
            If aEstatus = "MUESTRA" Or aEstatus = "NO AUTORIZADO" Then
                Return True
            Else
                Return False
            End If
        End If
        If deEstatus = "MUESTRA" Then
            If aEstatus = "NO AUTORIZADO" Or aEstatus = "AUTORIZADO PARA PROGRAMACIÓN" Then
                Return True
            Else
                Return False
            End If
        End If
        If deEstatus = "NO AUTORIZADO" Then
            If aEstatus = "PROTOTIPO" Or aEstatus = "MUESTRA" Then
                Return True
            Else
                Return False
            End If
        End If
        If deEstatus = "AUTORIZADO PARA PROGRAMACIÓN" Then
            If aEstatus = "NO AUTORIZADO" Or aEstatus = "AUTORIZADO PARA PRODUCCIÓN" Then
                Return True
            Else
                Return False
            End If
        End If
        If deEstatus = "AUTORIZADO PARA PRODUCCIÓN" Then
            If aEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
                Return True
            Else
                Return False
            End If
        End If
        If deEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
            If aEstatus = "DESCONTINUADO PARA VENTA" Then
                Return True
            Else
                Return False
            End If
        End If
        If deEstatus = "DESCONTINUADO PARA VENTA" Then
            If aEstatus = "DESCONTINUADO PARA PRODUCCIÓN" Then
                Return True
            Else
                Return False
            End If
        End If
        Return False
    End Function

    Private Sub btnSuela_Click(sender As Object, e As EventArgs) Handles btnSuelaProgramacion.Click
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

    'Private Sub grdDetallesEstilos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdDetallesEstilos.InitializeRow
    '    Dim EstatusProductoId As Integer = 0
    '    Try
    '        EstatusProductoId = e.Row.Cells("psEstatus").Value
    '        If EstatusProductoId = 1 Or EstatusProductoId = 2 Then
    '            e.Row.Cells("SuelaProgramacionID").Activation = Activation.AllowEdit
    '        Else
    '            e.Row.Cells("SuelaProgramacionID").Activation = Activation.NoEdit
    '        End If
    '    Catch ex As Exception
    '        show_message("Error", ex.Message.ToString())
    '    End Try

    'End Sub


    'Imports Tools
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

    Private Sub txtSuelaProgramacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSuelaProgramacion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtSuelaProgramacion.Text.Length < 3) Then
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

    Private Sub txtSuelaProgramacion_LostFocus(sender As Object, e As EventArgs) Handles txtSuelaProgramacion.LostFocus
        If (txtSuelaProgramacion.Text <> Nothing) Then
            If (IDSuelaProgramacion = 0 Or IDSuelaProgramacion <> txtSuelaProgramacion.Text) Then

                Dim objSuelaProgramaacion As New Programacion.Negocios.SuelaProgramacionBU
                Dim dtDatosSuelaProgramacion As New DataTable
                dtDatosSuelaProgramacion = objSuelaProgramaacion.verSuelaProgramacionId(txtSuelaProgramacion.Text)
                If (dtDatosSuelaProgramacion.Rows.Count > 0) Then
                    IDSuelaProgramacion = CInt(dtDatosSuelaProgramacion.Rows(0)(0).ToString)
                    nombreSuelaProgramacion = dtDatosSuelaProgramacion.Rows(0)(1).ToString
                    lblNombreSuelaProgramacion.Text = dtDatosSuelaProgramacion.Rows(0)(1).ToString
                    ActualizarSuelaProgramacion(IDSuelaProgramacion)

                Else
                    txtSuelaProgramacion.Text = String.Empty
                    IDSuelaProgramacion = 0
                    nombreSuelaProgramacion = String.Empty
                    lblNombreSuelaProgramacion.Text = ""

                    Dim advertenciaMensaje As New AdvertenciaForm
                    advertenciaMensaje.mensaje = "La suela de programación que ingreso no existe."
                    advertenciaMensaje.ShowDialog()
                End If
            End If
        End If
    End Sub



    Private Sub txtSuelaProgramacion_TextChanged(sender As Object, e As EventArgs) Handles txtSuelaProgramacion.TextChanged
        If (txtSuelaProgramacion.Text = Nothing) Then
            IDSuelaProgramacion = 0
            nombreSuelaProgramacion = String.Empty
            lblNombreSuelaProgramacion.Text = ""
            txtSuelaProgramacion.Text = String.Empty
        Else
            Dim objSuelaProgramacion As New Programacion.Negocios.SuelaProgramacionBU
            Dim dtDatosSuelaProgramacion As New DataTable
            dtDatosSuelaProgramacion = objSuelaProgramacion.verSuelaProgramacionId(txtSuelaProgramacion.Text)
            If (dtDatosSuelaProgramacion.Rows.Count > 0) Then
                IDSuelaProgramacion = CInt(dtDatosSuelaProgramacion.Rows(0)(0).ToString)
                nombreSuelaProgramacion = dtDatosSuelaProgramacion.Rows(0)(1).ToString
                lblNombreSuelaProgramacion.Text = dtDatosSuelaProgramacion.Rows(0)(1).ToString
                ActualizarSuelaProgramacion(IDSuelaProgramacion)

            Else
                txtSuelaProgramacion.Text = String.Empty
                IDSuelaProgramacion = 0
                nombreSuelaProgramacion = String.Empty
                lblNombreSuelaProgramacion.Text = ""

                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "La suela de programación que ingreso no existe."
                advertenciaMensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ActualizarSuelaProgramacion(ByVal SuelaProgramacion As Integer)

        Try
            If IsNothing(grdDetallesEstilos) = False Then
                If grdDetallesEstilos.Rows.Count > 0 And IDSuelaProgramacion > 0 Then
                    Dim FilasActualizar = grdDetallesEstilos.Rows.Where(Function(x) x.Cells("psEstatus").Value = 1 Or x.Cells("psEstatus").Value = 2 Or x.Cells("psEstatus").Value = 3 Or x.Cells("psEstatus").Value = 4)
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
                If grdDetallesEstilos.Rows.Count > 0 And ColorSuelaID > 0 Then
                    Dim FilasActualizar = grdDetallesEstilos.Rows.Where(Function(x) x.Cells("psEstatus").Value = 1 Or x.Cells("psEstatus").Value = 2 Or x.Cells("psEstatus").Value = 3 Or x.Cells("psEstatus").Value = 4)
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

                Dim advertenciaMensaje As New AdvertenciaForm
                advertenciaMensaje.mensaje = "El color de la suela que ingreso no existe."
                advertenciaMensaje.ShowDialog()

            End If


        End If
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
    End Function

    Public Function ValidarArticulosNoAutorizados() As Boolean
        Dim ProductoEstiloId As String = String.Empty
        Dim objPBU As New Programacion.Negocios.ProductosBU

        For Each rowDetalle As UltraGridRow In grdDetallesEstilos.Rows
            If rowDetalle.Cells("psEstatus").Value().ToString() = "7" Then
                If ProductoEstiloId = String.Empty Then
                    ProductoEstiloId = rowDetalle.Cells("pstilo").Value().ToString()
                Else
                    ProductoEstiloId += "," & rowDetalle.Cells("pstilo").Value().ToString()
                End If
            End If
        Next

        If ProductoEstiloId <> String.Empty Then
            Return objPBU.ValidarArticuloEnPedidoActivo(ProductoEstiloId)
        Else
            Return True
        End If


    End Function

    Private Sub btnModeloReferencia_Click(sender As Object, e As EventArgs) Handles btnModeloReferencia.Click
        Dim objModelo As New ModeloReferenciaFormRapido
        objModelo.ShowDialog()
        NombreModelo = objModelo.PnombreModelo
        txtModeloReferencia.Text = objModelo.PnombreModelo ' objModelo.PidProducto

        txtModeloReferencia.Focus()
    End Sub

    Private Sub ValidaExisteArticulo(ByVal marca As Integer, ByVal coleccion As String)
        Dim obj As New Programacion.Negocios.ProductosBU
    End Sub

    Private Function validarExisteOtro() As Integer
        Dim obj As New Programacion.Negocios.ProductosBU
        Dim tblExis As New DataTable
        Dim existe As Integer = 0
        Dim idprod As Integer = 0
        Dim pielCadena As String = ""
        Dim colorCadena As String = ""
        Dim tallaCadena As String = ""

        For Each rowGrd As UltraGridRow In grdDetallesEstilos.Rows
            If idprod = 0 Then
                idprod = rowGrd.Cells("prod_productoid").Value
            End If
        Next


        For Each rowPiel As UltraGridRow In grdPieles.Rows
            If (CBool(rowPiel.Cells("selectPcol").Value) = True) Then
                If pielCadena = String.Empty Then
                    pielCadena = rowPiel.Cells("piel_pielid").Value.ToString()
                Else
                    pielCadena = rowPiel.Cells("piel_pielid").Value.ToString() & "," & pielCadena
                End If
            End If
        Next

        For Each rowPiel As UltraGridRow In grdPieles.Rows
            If (CBool(rowPiel.Cells("selectPcol").Value) = True) Then
                If colorCadena = String.Empty Then
                    colorCadena = rowPiel.Cells("color_colorid").Value.ToString()
                Else
                    colorCadena = rowPiel.Cells("color_colorid").Value.ToString() & "," & colorCadena
                End If
            End If
        Next

        For Each rowTalla As UltraGridRow In grdTalla.Rows
            If (CBool(rowTalla.Cells("selectTalla").Value) = True) Then
                If tallaCadena = String.Empty Then
                    tallaCadena = rowTalla.Cells("talla_tallaid").Value.ToString()
                Else
                    tallaCadena = rowTalla.Cells("talla_tallaid").Value.ToString() & "," & tallaCadena
                End If
            End If
        Next


        tblExis = obj.consultarExisteEstiloModelo(idprod, pielCadena, colorCadena, tallaCadena, True, txtCodigo.Text)
        existe = tblExis.Rows(0).Item("pstilo")
        If existe = 0 Then
            tblExis = obj.consultarExisteEstiloModelo(idprod, pielCadena, colorCadena, tallaCadena, False, txtCodigo.Text)
            existe = tblExis.Rows(0).Item("pstilo")
        End If

        Return existe

    End Function

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