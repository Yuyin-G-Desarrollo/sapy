Imports Infragistics.Win.UltraWinEditors.UltraComboEditor
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports System.Drawing


Public Class comprobantesFiscalesForm
    Dim objMesj As New Tools.AdvertenciaForm
    Dim empresaBD As String = ""
    Dim servidorBD As String = ""
    Dim doctoVentasID As String = ""
    Dim contribuyentesID As String = ""
    Dim empresaSAYContpaqSICY As String = ""
    Dim RutaArchivoXML As String
    Dim hsListaCliente_Proveedor As New HashSet(Of Integer)
    Public Archivos As New Entidades.ColaboradorExpediente
    Dim Poliza As New Entidades.Polizas

    Private Sub comprobantesFiscalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        llenarComboTipoComprobanteFiscal(cmbTIpoComprobante)
        LlenarComboEmpresas(cmbEmpresa)

        dtpDe.MaxDate = Today
        dtpAl.MaxDate = Today

    End Sub



#Region "COMBOS"

    ''' <summary>
    ''' LE ASIGNA LOS DOS TIPOS DE COMPROBANTES FISCALES(INGRESOS Y EGRESOS) AL COMBO ENVIADO A ESTE METODO
    ''' </summary>
    ''' <param name="comboEntrada">CONTROL DEL TIPO COMBOBOX</param>
    ''' <remarks></remarks>
    Private Sub llenarComboTipoComprobanteFiscal(ByVal comboEntrada As ComboBox)
        Dim dtTipoComprobante As New DataTable

        Dim column As DataColumn = dtTipoComprobante.Columns.Add("Id", Type.GetType("System.Int16"))
        dtTipoComprobante.Columns.Add("Tipo", Type.GetType("System.String"))

        dtTipoComprobante.Rows.Add(1, "INGRESOS")
        dtTipoComprobante.Rows.Add(2, "EGRESOS")
        dtTipoComprobante.Rows.InsertAt(dtTipoComprobante.NewRow, 0)

        comboEntrada.DataSource = dtTipoComprobante
        comboEntrada.ValueMember = "Id"
        comboEntrada.DisplayMember = "Tipo"
    End Sub

    ''' <summary>
    ''' LE ASIGNA LA FUENTE DE DATOS CON LAS ENPRESAS A LAS QUE TIENE ACCESO EL USUARIO LOGGEADO AL COMBO DE ENVIADO A ESTE METODO
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL DEL TIPO COMBOBOX</param>
    ''' <remarks></remarks>
    Private Sub LlenarComboEmpresas(ByVal ComboEntrada As ComboBox)
        Dim objBU As New Negocios.AltaPolizaBU
        Dim dtTablaEmpresa As New DataTable

        dtTablaEmpresa = objBU.CargaEmpresaCONTPAQ(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString)
        dtTablaEmpresa.Rows.InsertAt(dtTablaEmpresa.NewRow(), 0)

        ComboEntrada.DataSource = dtTablaEmpresa
        ComboEntrada.ValueMember = "essc_sayid"
        ComboEntrada.DisplayMember = "RazonSocial"
    End Sub

    ''' <summary>
    ''' LLENA UN CONTROL DEL TIPO COMBOBOX CON LAS NAVES PERTENECIENTES A UNA RAZON SOCIAL EN ESPECIFICO
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL DEL TIPO COMBOBOX</param>
    ''' <param name="CadenaRazonesSociales">IDS DE LAS RAZONES SOCIALES DEL SICY DE LAS CUALES SE RECUPERARAN LAS NAVES</param>
    ''' <remarks></remarks>
    Private Sub LlenarComboNaves_De_RazonesSociales(ByVal ComboEntrada As ComboBox, ByVal CadenaRazonesSociales As String)
        Dim objBU As New Negocios.ComprobantesFiscalesBU
        Dim dtTabla As New DataTable

        dtTabla = objBU.RecuperarNavesDeControbuyente(contribuyentesID)
        dtTabla.Rows.InsertAt(dtTabla.NewRow(), 0)
        ComboEntrada.DataSource = dtTabla
        ComboEntrada.ValueMember = "IdNave"
        ComboEntrada.DisplayMember = "Nave"

    End Sub

    ''' <summary>
    ''' ASIGNA EL DATASORSE AL COMBO ENVIADO A ESTE METODO CON LOS DIFERENTES TIPOS DE POLIZAS
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL DEL TIPO COMBOBOX</param>
    ''' <remarks></remarks>
    Public Sub LlenarComboTipoDePoliza(ByVal ComboEntrada As ComboBox, ByVal No_Tipo_Ingreso_Egreso As Integer)
        Dim objAltpoliBU As New Negocios.ComprobantesFiscalesBU
        Dim dtTipoPoliza As New DataTable

        dtTipoPoliza = objAltpoliBU.CargaTiposPoliza(No_Tipo_Ingreso_Egreso)
        dtTipoPoliza.Rows.InsertAt(dtTipoPoliza.NewRow(), 0)
        'dtTipoPoliza.Rows(0).Item("poti_polizaTipoId") = 0
        'dtTipoPoliza.Rows(0).Item("poti_nombre") = "SIN PÓLIZA"
        ComboEntrada.DataSource = dtTipoPoliza
        ComboEntrada.ValueMember = "poti_polizaTipoId"
        ComboEntrada.DisplayMember = "poti_nombre"
    End Sub

    ''' <summary>
    ''' LLENA UN CONTROL DEL TIPO COMBOBOX CON LA LISTA DE LOS PROVEEDORES ACTIVOS EXISTENTES
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL DEL TIPO COMBOBOX</param>
    ''' <remarks></remarks>
    Public Sub LlenarComboProveedores(ByVal ComboEntrada As UltraWinEditors.UltraComboEditor)
        Dim objComprobantesBU As New Negocios.ComprobantesFiscalesBU
        Dim dtTablaProveedores As New DataTable
        dtTablaProveedores = objComprobantesBU.ConsultarProveedoresSicy

        'dtTablaProveedores.Rows.InsertAt(dtTablaProveedores.NewRow(), 0)
        ComboEntrada.DataSource = dtTablaProveedores
        ComboEntrada.ValueMember = "IdProveedor"
        ComboEntrada.DisplayMember = "RazonSocial"


        'Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    ''' <summary>
    ''' EVENTO DROPDOWN EN EL CUAL SE RECUPERA EL ID DE CONTRIBUYENTE DEL SICY, EL ID DE DOCTCOVENTAS DEL SICY,
    '''  LA EMPRESA COMPAQ Y EL SERVIDOR DE UNA RAZON SOCIAL EN ESPECIFICO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RecuperarValoresRazonSocial()
        Dim objDA As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim tamanio As Integer = 0

        empresaBD = ""
        servidorBD = ""
        doctoVentasID = ""
        contribuyentesID = ""
        If cmbEmpresa.SelectedIndex > 0 Then
            tabla = objDA.datosServidorEmpresa(cmbEmpresa.SelectedValue)
            For Each row As DataRow In tabla.Rows
                empresaBD = row.Item("essc_empresacontpaq")
                servidorBD = row.Item("essc_servidor")
                If tabla.Rows.Count > 1 Then
                    contribuyentesID += CStr(row.Item("essc_contribuyentesicyid")).Trim + ","
                    doctoVentasID += CStr(row.Item("essc_doctoventassicyid")).Trim + ","
                Else
                    contribuyentesID = row.Item("essc_contribuyentesicyid")
                    doctoVentasID = CStr(row.Item("essc_doctoventassicyid")).Trim
                End If
                empresaSAYContpaqSICY = row.Item("essc_empresaid")
            Next
            If tabla.Rows.Count > 1 Then
                tamanio = contribuyentesID.Length
                contribuyentesID = contribuyentesID.Remove(tamanio - 1)

                tamanio = doctoVentasID.Length
                doctoVentasID = doctoVentasID.Remove(tamanio - 1)
            End If
        End If
    End Sub

    ''' <summary>
    ''' EVENTO SELECTEDINDEXCHANGED EN EL QUE DEPENDIENDO DE LA OPCION SELECCIONADA EN EL COMBO TIPO DE COMPROBANTE SE
    ''' HABILITARAN O DESHABILITARAN CONTROLES
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbTIpoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTIpoComprobante.SelectedIndexChanged
        If cmbTIpoComprobante.SelectedIndex = 1 Then
            LlenarComboTipoDePoliza(cmbTipoPoliza, 1)
            cmbEmpresa.SelectedIndex = 0
            gboxClienteProveedor.Text = "Cliente:"
            grdClienteProveedor.DataSource = Nothing
            If IsNothing(hsListaCliente_Proveedor) = False Then
                hsListaCliente_Proveedor.Clear()
            End If
            ''Tools.Controles.UltraComboEditorsCadenasSicy(cmbUltraClienteProveedor)
            cmbNaves.Visible = False
            lblNave.Visible = False
            cmbEmpresa.Enabled = True
            btnRelacionarPDF.Enabled = False
            btnRelacionarXml.Enabled = False
            lblRelacionarPDF.Enabled = False
            lblRelacionarXML.Enabled = False
        ElseIf cmbTIpoComprobante.SelectedIndex = 2 Then
            LlenarComboTipoDePoliza(cmbTipoPoliza, 2)
            cmbEmpresa.SelectedIndex = 0
            gboxClienteProveedor.Text = "Proveedor:"
            grdClienteProveedor.DataSource = Nothing
            If IsNothing(hsListaCliente_Proveedor) = False Then
                hsListaCliente_Proveedor.Clear()
            End If
            lblNave.ForeColor = Drawing.Color.Black
            cmbNaves.Visible = True
            lblNave.Visible = True
            cmbEmpresa.Enabled = True
            btnRelacionarPDF.Enabled = True
            btnRelacionarXml.Enabled = True
            lblRelacionarPDF.Enabled = True
            lblRelacionarXML.Enabled = True
        Else
            cmbEmpresa.Enabled = False
            If IsNothing(cmbEmpresa.DataSource) = False Then
                cmbEmpresa.SelectedIndex = 0
            End If
            cmbNaves.DataSource = Nothing
            If IsNothing(hsListaCliente_Proveedor) = False Then
                hsListaCliente_Proveedor.Clear()
            End If

            grdClienteProveedor.DataSource = Nothing
        End If
    End Sub


#End Region


    Public Function extraerUUID(ByVal Ruta As String) As Entidades.Polizas

        Dim reader As XmlTextReader = New XmlTextReader(Ruta)
        Dim lista As New Entidades.Polizas

        Do While (reader.Read())

            Select Case reader.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.                    
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()
                            If reader.Name = "UUID" Then
                                lista.Puuid = reader.Value
                            End If

                            If reader.Name = "serie" Then
                                lista.Pserie = reader.Value
                            End If

                            If reader.Name = "folio" Then
                                lista.Pfolio = reader.Value
                            End If

                            If reader.Name = "fecha" Then
                                lista.Pfecha = reader.Value
                            End If

                        End While
                    End If
            End Select
        Loop
        Return lista
        reader.Close()
    End Function

#Region "AccionesGrid"

    ''' <summary>
    ''' METODO PARA DAR FORMATO AL GRID
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DarFormatoGrid()

        With grdComprobantesFiscales
            ''REDIMENCIONAR TODAS LAS COLUMNAS
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            ''INDICE DE LA FILA
            .DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

            ''DISEÑO DE LAS FILAS
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Drawing.Color.LightSteelBlue
            .DisplayLayout.MaxRowScrollRegions = 1

            ''CAMBIAR HEADERS
            .DisplayLayout.Bands(0).Columns("No_Poliza").Header.Caption = "No. Póliza"
            .DisplayLayout.Bands(0).Columns("Razon_Social").Header.Caption = "Razón Social"
            .DisplayLayout.Bands(0).Columns("Fecha_Documento").Header.Caption = "Fecha Comprobante"

            ''Ocultar Columnas
            .DisplayLayout.Bands(0).Columns("XML").Hidden = True
            .DisplayLayout.Bands(0).Columns("PDF").Hidden = True
            .DisplayLayout.Bands(0).Columns("Comprobante").Hidden = True
            If rdoSoloComprobantes.Checked And cmbTIpoComprobante.Text = "EGRESOS" Then
                .DisplayLayout.Bands(0).Columns("NAVE").Hidden = True
                .DisplayLayout.Bands(0).Columns("EmpresaId").Hidden = True
                .DisplayLayout.Bands(0).Columns("RFCEmpresa").Hidden = True
                .DisplayLayout.Bands(0).Columns("IdProveedor").Hidden = True
                .DisplayLayout.Bands(0).Columns("Ruta").Hidden = True
                .DisplayLayout.Bands(0).Columns("IDTABLA").Hidden = True
                .DisplayLayout.Bands(0).Columns("RutaArchivos").Hidden = True
            End If


            .DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("No_Poliza").CellAppearance.TextHAlign = HAlign.Right

            ''INHABILITAR EDICION DE LAS COLIMNAS
            .DisplayLayout.Bands(0).Columns("Serie").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Folio").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("RFC").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Razon_Social").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Total").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("UUID").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("NO_Poliza").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Fecha_Documento").CellActivation = Activation.NoEdit

            .DisplayLayout.Bands(0).Columns("Total").Format = "N2"

            ''REDIMENCIONAR COLUMNAS
            .DisplayLayout.Bands(0).Columns("Serie").Width = 50
            .DisplayLayout.Bands(0).Columns("Folio").Width = 70
            .DisplayLayout.Bands(0).Columns("Total").Width = 100
            .DisplayLayout.Bands(0).Columns("Fecha_Documento").Width = 90
            .DisplayLayout.Bands(0).Columns("No_Poliza").Width = 70


            'Dim width As Integer
            'For Each col As UltraGridColumn In grdComprobantesFiscales.Rows.Band.Columns
            '    If Not col.Hidden Then
            '        width += col.Width
            '    End If
            'Next

            'If width > grdComprobantesFiscales.Width Then
            '    grdComprobantesFiscales.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            'Else
            '    grdComprobantesFiscales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            'End If

            For Each row As UltraGridRow In grdComprobantesFiscales.Rows
                If row.Cells("Comprobante").Value = 0 Then
                    row.Appearance.BackColor = Drawing.Color.Salmon
                Else
                    If row.Cells("PDF").Value = "" Then
                        row.Appearance.BackColor = Drawing.Color.Khaki
                    End If
                End If
            Next



        End With
    End Sub

#Region "LLENAR GRID"

    ''' <summary>
    ''' CONSULTA TODOS LOS COMPROBANTES FISCALES QUE CUMPLAN CON LOS FILTROS ELEGIDOS POR EL USUARIO, SIN TOMAR EN CUENTA POLIZAS
    ''' </summary>
    ''' <param name="IdContribuyentesicy">ID DE LA EMPRESA POR LA CUAL SE BUSCARA INFORMACION</param>
    ''' <param name="Fec_Inicio">FECHA DE INICIO DEL RANGO DE FECHAS POR EL QUE SE BUSCARAN LOS COMPROBANTES</param>
    ''' <param name="Fec_Fin"> FECHA DE FIN DEL RANGO DE FECHAS POR EL QUE SE BUSCARAN LOS COMPROBANTES</param>
    ''' <param name="CadenaIdsProovedores">CADENA CON LOS IDS DE LOS PROVEEDORES POR LOS QUE SE REALIZARA LA BUSQUEDA, NO ES NECESARIO QUE LA CADENA CONTENGA CARACTERES</param>
    ''' <param name="IdNave">ID DE LA NAVE POR LA CUAL SE BUSCARAN LOS COMPROBANTES, VARIABLE DEL TIPO NUMERICO</param>
    ''' <param name="Folio">FOLIO DE EL COMPROBANTE</param>
    ''' <param name="FolioExacto_O_FolioAproximado">VALOR TRUE PARA CONSULTAR EL FOLIO EXACTO, VALOR FALSE PARA CONSULTAR EL FOLIO APROXIMADO</param>
    ''' <remarks></remarks>
    Private Sub CargarComprobantes_Egresos(ByVal IdContribuyentesicy As String, ByVal Fec_Inicio As String, ByVal Fec_Fin As String,
                                               ByVal CadenaIdsProovedores As String, ByVal IdNave As Integer, ByVal Folio As String,
                                               ByVal FolioExacto_O_FolioAproximado As Boolean)
        Dim dtTablaComprobantes As New DataTable
        Dim objBU As New Negocios.ComprobantesFiscalesBU

        dtTablaComprobantes = objBU.CargarComprobantes_Egresos(IdContribuyentesicy, Fec_Inicio, Fec_Fin, CadenaIdsProovedores, IdNave, Folio,
                                                               FolioExacto_O_FolioAproximado)

        If dtTablaComprobantes.Rows.Count = 0 Then
            Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
            grdComprobantesFiscales.DataSource = Nothing
        Else
            grdComprobantesFiscales.DataSource = dtTablaComprobantes
            RecuperarUUID(dtTablaComprobantes)
            DarFormatoGrid()
        End If
    End Sub

    ''' <summary>
    ''' CONSULTA LA INFORMACION DE LOS COMPROBANTES DENTRO DE UNA POLIZA DE COMPRAS DEPENDIENDO DE LOS FILTROS SELECCIONADOS POR EL USUARIO
    ''' O TODOS LOS COMPROBANTES QUE NO ESTEN DENTRO DE UNA POLIZA DE COMPRAS
    ''' </summary>
    ''' <param name="IdContribuyentesicy"> IDCONTRIBUYETES DE LA BASE DE DATOS DEL SICY</param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar">SÍ EL VALOR ES 'TRUE' CONSULTARA LOS DOCUMENTOS QUE SE ENCUENTRAN DENTRO DE UNA POLIZA DE COMPRAS
    ''' , SI NO, CONSULTARA TODOS LOS COMPROBANTES QUE NO ESTAN DENTRO DE UNA POLIZA DE COMPRAS</param>
    ''' <param name="IdTipoPoliza">ID DEL TIPO DE POLIZA(SIEMRPE SERA EL DEL TIPO DE POLIZA COMPRAS)</param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza">VALOR TRUE PARA CONSULTAR LOS DOCUMENOS FILTRANDO POR LA FECHA DEL COMPROBANTE, VALOR FALSE PARA CONSULTAR
    ''' LOS COMPROBANTES FILTRANDO POR LA FECHA DE LA POLIZA</param>
    ''' <param name="Fec_Inicio">DECHA DE INICIO PARA EL RANGO DE FECHAS</param>
    ''' <param name="Fec_Fin">FECHA DE FIN PARA EL RANGO DE FECHAS</param>
    ''' <param name="CadenaIdsProovedores">CADENA CON LOS IDS DE LOS PROVEEDORES POR LOS QUE SE FILTRARA LA CONSULTA</param>
    ''' <param name="IdNave">ID DE LA NAVE POR LA QUE SE FILTRARA LA CONSULTA</param>
    ''' <param name="Folio">FOLIO DEL DOCUMENTRO POR EL QUE SE FILTRARA LA CONSULTA</param>
    ''' <param name="FolioExacto_O_FolioAproximado">VALOR TRUE PARA BUSCAR EL FOLIO EXACTO, VALOR FALSE PARA BUSCAR EL FOLIO APROXIMADO</param>
    ''' <remarks></remarks>
    Private Sub CargarComprobantes_PolizaCompras_Egresos(ByVal IdContribuyentesicy As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                             ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                             ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaIdsProovedores As String,
                                                             ByVal IdNave As Integer, ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        Dim dtTablaComprobantes As New DataTable

        Dim objBU As New Negocios.ComprobantesFiscalesBU

        dtTablaComprobantes = objBU.CargarComprobantes_PolizaCompras_Egresos(IdContribuyentesicy, Documento_EnPoliza_O_SinContabilizar, Fecha_EnDocumento_O_EnPoliza, Fec_Inicio,
                                                                                 Fec_Fin, CadenaIdsProovedores, IdNave, Folio, FolioExacto_O_FolioAproximado, IdTipoPoliza)
        If dtTablaComprobantes.Rows.Count = 0 Then
            Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
            grdComprobantesFiscales.DataSource = Nothing
        Else
            grdComprobantesFiscales.DataSource = dtTablaComprobantes
            RecuperarUUID(dtTablaComprobantes)
            DarFormatoGrid()
        End If
    End Sub

    ''' <summary>
    ''' CONECTA CON LA CAPA DE NEGOCIOS PARA CONSULTAR LOS COMPROBANTES DE EGRESOS RELACIONADOS CON UNA TRANSFERENCIA O QUE NO ESTEN DENTRO DE UNA TRANSFERENCIA, DE UN CONTRIBUYENTE O EMPRESA 
    ''' EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdContribuyentesicy">ID DEL LA EMPRESA DE LA CUAL SE CONSULTARAN LOS COMPRONBANTES FISCALES</param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar">VARIABLE DEL TIPO BOLEANO, VALOR TRUE PARA CONSULTAR TODOS LOS COMPROBANTES FISCALES QUE SE ENCUENTRAN DENTRO 
    ''' DE UNA POLIZA DE TRANSFERENCIA, VALOR FALSE PARA CONSULTAR TODOS LOS COMPROBANTES QUE NO SE ENCUENTRAN DENTRO DE UNA POLIZA DE TRANFERENCIA</param>
    ''' <param name="IdTipoPoliza">ID DEL TIPO DE POLIZA QUE SE BUSCARA, EN ESTE CASO SIEMPRE SERA EL ID PARA EL TIPO DE POLIZAS DE TRANSFERENCIA</param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza">VARIABLE DEL TIPO BOLEANO, VALOR TRUE PARA FILTRAR LA FECHA POR LA FECHA DEL COMPROBANTE, VALOR FALSE PARA FILTRAR LA FECHA POR 
    ''' LA FECHA EN LA POLIZA</param>
    ''' <param name="Fec_Inicio">FECHA DE INICIO DEL FILTRO DE FECHA</param>
    ''' <param name="Fec_Fin">FECHA DE FIN PARA EL FILTRO DE FECHA</param>
    ''' <param name="CadenaIdsProovedores">CADENA CON LOS IDS DE LOS PROVEEDORES POR LOS QUE SE FILTRARA LA CONSULTA, LA CADENA PUEDE ESTAR VACIA</param>
    ''' <param name="IdNave">ID DE LA NAVE POR LA CUAL SE REALIZARA EL FILTRO, EL ID PUEDE SER DE VALOR 0</param>
    ''' <param name="Folio">FOLIO DEL COMPROBANTE</param>
    ''' <param name="FolioExacto_O_FolioAproximado">VARIABLE DEL TIPO BOLEANO, VALOR TRUE PARA BUSCAR EL FOLIO EXACTO DEL COMPROBANTE, VALOR FALSE PARA BUSCAR
    ''' EL FOLIO APROXIMADO DEL COMPROBANTE</param>
    ''' <remarks></remarks>
    Private Sub CargarComprobantes_PolizaTransFerencias_Egresos(ByVal IdContribuyentesicy As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                             ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                             ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaIdsProovedores As String,
                                                             ByVal IdNave As Integer, ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        Dim dtTablaComprobantes As New DataTable

        Dim objBU As New Negocios.ComprobantesFiscalesBU

        dtTablaComprobantes = objBU.CargarComprobantes_PolizaTransferencia_Egresos(IdContribuyentesicy, Documento_EnPoliza_O_SinContabilizar, Fecha_EnDocumento_O_EnPoliza,
                                                                                  Fec_Inicio, Fec_Fin, CadenaIdsProovedores, IdNave, Folio, FolioExacto_O_FolioAproximado, IdTipoPoliza)

        If dtTablaComprobantes.Rows.Count = 0 Then
            Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
            grdComprobantesFiscales.DataSource = Nothing
        Else
            grdComprobantesFiscales.DataSource = dtTablaComprobantes
            RecuperarUUID(dtTablaComprobantes)
            DarFormatoGrid()
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdEmpresaSay"></param>
    ''' <param name="Fec_Inicio"></param>
    ''' <param name="Fec_Fin"></param>
    ''' <param name="CadenaClientesSicy"></param>
    ''' <param name="FolioExacto_O_FolioAproximado"></param>
    ''' <param name="Folio"></param>
    ''' <remarks></remarks>
    Public Sub CargarComprobante_Ingresos(ByVal IdEmpresaSay As Integer, ByVal Fec_Inicio As String, ByVal Fec_Fin As String, CadenaClientesSicy As String,
                                                           ByVal FolioExacto_O_FolioAproximado As Boolean, ByVal Folio As String)
        Dim dtTablaComprobantes As New DataTable
        Dim objBU As New Negocios.ComprobantesFiscalesBU

        dtTablaComprobantes = objBU.CargarComprobante_Ingresos(IdEmpresaSay, Fec_Inicio, Fec_Fin, CadenaClientesSicy, FolioExacto_O_FolioAproximado, Folio)

        If dtTablaComprobantes.Rows.Count = 0 Then
            Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
            grdComprobantesFiscales.DataSource = Nothing
        Else
            grdComprobantesFiscales.DataSource = dtTablaComprobantes
            RecuperarUUID(dtTablaComprobantes)
            DarFormatoGrid()
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdEmpresaSay"></param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar"></param>
    ''' <param name="IdTipoPoliza"></param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza"></param>
    ''' <param name="Fec_Inicio"></param>
    ''' <param name="Fec_Fin"></param>
    ''' <param name="CadenaClientesSicy"></param>
    ''' <param name="Folio"></param>
    ''' <param name="FolioExacto_O_FolioAproximado"></param>
    ''' <remarks></remarks>
    Public Sub CargarComprobante_PolizaVentas_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                       ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                       ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                       ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        Dim dtTablaComprobantes As New DataTable
        Dim objBU As New Negocios.ComprobantesFiscalesBU

        dtTablaComprobantes = objBU.CargarComprobante_PolizaVentas_Ingresos(IdEmpresaSay, Documento_EnPoliza_O_SinContabilizar, IdTipoPoliza, Fecha_EnDocumento_O_EnPoliza,
                                                        Fec_Inicio, Fec_Fin, CadenaClientesSicy, Folio, FolioExacto_O_FolioAproximado)

        If dtTablaComprobantes.Rows.Count = 0 Then
            Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
            grdComprobantesFiscales.DataSource = Nothing
        Else
            grdComprobantesFiscales.DataSource = dtTablaComprobantes
            RecuperarUUID(dtTablaComprobantes)
            DarFormatoGrid()
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdEmpresaSay"></param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar"></param>
    ''' <param name="IdTipoPoliza"></param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza"></param>
    ''' <param name="Fec_Inicio"></param>
    ''' <param name="Fec_Fin"></param>
    ''' <param name="CadenaClientesSicy"></param>
    ''' <param name="Folio"></param>
    ''' <param name="FolioExacto_O_FolioAproximado"></param>
    ''' <remarks></remarks>
    Public Sub CargarComprobante_PolizaNotasCredito_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                       ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                       ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                       ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        Dim dtTablaComprobantes As New DataTable
        Dim objBU As New Negocios.ComprobantesFiscalesBU

        dtTablaComprobantes = objBU.CargarComprobante_PolizaNotasCredito_Ingresos(IdEmpresaSay, Documento_EnPoliza_O_SinContabilizar, IdTipoPoliza, Fecha_EnDocumento_O_EnPoliza,
                                                        Fec_Inicio, Fec_Fin, CadenaClientesSicy, Folio, FolioExacto_O_FolioAproximado)

        If dtTablaComprobantes.Rows.Count = 0 Then
            Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
            grdComprobantesFiscales.DataSource = Nothing
        Else
            grdComprobantesFiscales.DataSource = dtTablaComprobantes
            RecuperarUUID(dtTablaComprobantes)
            DarFormatoGrid()
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdEmpresaSay"></param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar"></param>
    ''' <param name="IdTipoPoliza"></param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza"></param>
    ''' <param name="Fec_Inicio"></param>
    ''' <param name="Fec_Fin"></param>
    ''' <param name="CadenaClientesSicy"></param>
    ''' <param name="Folio"></param>
    ''' <param name="FolioExacto_O_FolioAproximado"></param>
    ''' <remarks></remarks>
    Public Sub CargarComprobante_PolizaNotasCargo_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                       ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                       ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                       ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        'Dim dtTablaComprobantes As New DataTable
        'Dim objBU As New Negocios.ComprobantesFiscalesBU

        'dtTablaComprobantes = objBU.CargarComprobante_PolizaVentas_Ingresos(IdEmpresaSay, Documento_EnPoliza_O_SinContabilizar, IdTipoPoliza, Fecha_EnDocumento_O_EnPoliza,
        '                                                Fec_Inicio, Fec_Fin, CadenaClientesSicy, Folio, FolioExacto_O_FolioAproximado)

        'If dtTablaComprobantes.Rows.Count = 0 Then
        '    Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
        '    grdComprobantesFiscales.DataSource = Nothing
        'Else
        '    grdComprobantesFiscales.DataSource = dtTablaComprobantes
        '    RecuperarUUID(dtTablaComprobantes)
        '    DarFormatoGrid()
        'End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdEmpresaSay"></param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar"></param>
    ''' <param name="IdTipoPoliza"></param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza"></param>
    ''' <param name="Fec_Inicio"></param>
    ''' <param name="Fec_Fin"></param>
    ''' <param name="CadenaClientesSicy"></param>
    ''' <param name="Folio"></param>
    ''' <param name="FolioExacto_O_FolioAproximado"></param>
    ''' <remarks></remarks>
    Public Sub CargarComprobante_PolizaDepositosIdentificados_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                       ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                       ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                       ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        'Dim dtTablaComprobantes As New DataTable
        'Dim objBU As New Negocios.ComprobantesFiscalesBU

        'dtTablaComprobantes = objBU.CargarComprobante_PolizaVentas_Ingresos(IdEmpresaSay, Documento_EnPoliza_O_SinContabilizar, IdTipoPoliza, Fecha_EnDocumento_O_EnPoliza,
        '                                                Fec_Inicio, Fec_Fin, CadenaClientesSicy, Folio, FolioExacto_O_FolioAproximado)

        'If dtTablaComprobantes.Rows.Count = 0 Then
        '    Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
        '    grdComprobantesFiscales.DataSource = Nothing
        'Else
        '    grdComprobantesFiscales.DataSource = dtTablaComprobantes
        '    RecuperarUUID(dtTablaComprobantes)
        '    DarFormatoGrid()
        'End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdEmpresaSay"></param>
    ''' <param name="Documento_EnPoliza_O_SinContabilizar"></param>
    ''' <param name="IdTipoPoliza"></param>
    ''' <param name="Fecha_EnDocumento_O_EnPoliza"></param>
    ''' <param name="Fec_Inicio"></param>
    ''' <param name="Fec_Fin"></param>
    ''' <param name="CadenaClientesSicy"></param>
    ''' <param name="Folio"></param>
    ''' <param name="FolioExacto_O_FolioAproximado"></param>
    ''' <remarks></remarks>
    Public Sub CargarComprobante_PolizaDepositosPorIdentificar_Ingresos(ByVal IdEmpresaSay As String, ByVal Documento_EnPoliza_O_SinContabilizar As Boolean,
                                                       ByVal IdTipoPoliza As Integer, ByVal Fecha_EnDocumento_O_EnPoliza As Boolean,
                                                       ByVal Fec_Inicio As String, ByVal Fec_Fin As String, ByVal CadenaClientesSicy As String,
                                                       ByVal Folio As String, ByVal FolioExacto_O_FolioAproximado As Boolean)
        'Dim dtTablaComprobantes As New DataTable
        'Dim objBU As New Negocios.ComprobantesFiscalesBU

        'dtTablaComprobantes = objBU.CargarComprobante_PolizaVentas_Ingresos(IdEmpresaSay, Documento_EnPoliza_O_SinContabilizar, IdTipoPoliza, Fecha_EnDocumento_O_EnPoliza,
        '                                                Fec_Inicio, Fec_Fin, CadenaClientesSicy, Folio, FolioExacto_O_FolioAproximado)

        'If dtTablaComprobantes.Rows.Count = 0 Then
        '    Mensajes_Y_Alertas("INFORMACION", "No se encontro información.")
        '    grdComprobantesFiscales.DataSource = Nothing
        'Else
        '    grdComprobantesFiscales.DataSource = dtTablaComprobantes
        '    RecuperarUUID(dtTablaComprobantes)
        '    DarFormatoGrid()
        'End If
    End Sub


#End Region

#End Region

#Region "ACCIONES BOTONES"


    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdComprobantesFiscales.Rows.Count > 0 Then
            exportarExcel()
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "No hay datos para exportar.")
        End If
    End Sub


    Public Sub exportarExcel()
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        Dim gr As New UltraGrid
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                gridExcelExporter.Export(Me.grdComprobantesFiscales, fileName)

                Me.Cursor = System.Windows.Forms.Cursors.Default
                Dim MensageExito As New Tools.ExitoForm
                MensageExito.mensaje = "Los datos se exportaron correctamente"
                MensageExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Mensajes_Y_Alertas("ERROR", "El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.")
            End Try
        End If
    End Sub


    Private Sub btnCopiarA_Click(sender As Object, e As EventArgs) Handles btnCopiarA.Click

        If grdComprobantesFiscales.Selected.Rows.Count > 0 Then
            Dim NombreArchivo
            Dim RutaArchivo_Split() As String

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Try
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True
                    Dim ret As DialogResult = .ShowDialog

                    If ret = Windows.Forms.DialogResult.OK Then
                        For Each row As UltraGridRow In grdComprobantesFiscales.Selected.Rows
                            If row.Cells("XML").Value <> "" Then
                                RutaArchivo_Split = Split(row.Cells("XML").Value, "\")
                                NombreArchivo = RutaArchivo_Split(RutaArchivo_Split.Length - 1)
                                FileCopy(row.Cells("XML").Value, .SelectedPath + "\" + NombreArchivo)
                            End If
                            If row.Cells("PDF").Value <> "" Then
                                RutaArchivo_Split = Split(row.Cells("PDF").Value, "\")
                                NombreArchivo = RutaArchivo_Split(RutaArchivo_Split.Length - 1)
                                FileCopy(row.Cells("PDF").Value, .SelectedPath + "\" + NombreArchivo)
                            End If
                        Next
                    End If
                End With
                Mensajes_Y_Alertas("EXITO", "Los archivos se copiaron correctamente.")
            Catch ex As Exception
                Mensajes_Y_Alertas("ERROR", "Ocurrio un error mientras se copiaban los archivos.")
            End Try
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "Selecciona los comprobantes de los cuales copearas sus respectivos XML y PDF.")
        End If

    End Sub


    Private Sub btnRelacionarXml_Click(sender As Object, e As EventArgs) Handles btnRelacionarXml.Click
        If grdComprobantesFiscales.Selected.Rows.Count > 1 Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione solo un comprobante a la vez para relacionar su XML.")
        ElseIf grdComprobantesFiscales.Selected.Rows.Count = 0 Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un comprobante para relacionar su XML.")
        Else
            RelacionarXML()
        End If
    End Sub


    Private Sub RelacionarXML()
        Dim row As UltraGridRow = grdComprobantesFiscales.ActiveRow

        If String.IsNullOrEmpty(row.Cells("XML").Value.ToString) Then
            ofdComprobantesFiscales.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)
            ofdComprobantesFiscales.Filter = "XML|*.xml"
            ofdComprobantesFiscales.Filter = "XML|*.xml"
            ofdComprobantesFiscales.FilterIndex = 3
            Dim ruta As String

            If ofdComprobantesFiscales.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim pregunta As New ConfirmarForm
                pregunta.mensaje = "¿Está seguro que el archivo seleccionado es correcto? Posteriormente no podrá realizar cambios."
                If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then

                    ruta = ofdComprobantesFiscales.FileName

                    Dim archivo() As String
                    archivo = Split(ruta, "\")

                    For n = 0 To UBound(archivo, 1)
                        If UBound(archivo) = n Then
                            Archivos.PNombreArchivo = archivo(n)
                        End If
                    Next

                    Poliza = extraerUUID(ruta)

                    Dim RutaArchivo As String

                    If Poliza.Pfecha.Month < 10 Then
                        RutaArchivo = CStr(row.Cells("RUTA").Value) + "0" + Poliza.Pfecha.Month.ToString + Poliza.Pfecha.Year.ToString
                    Else
                        RutaArchivo = CStr(row.Cells("RUTA").Value) + Poliza.Pfecha.Month.ToString + Poliza.Pfecha.Year.ToString
                    End If

                    If Not Directory.Exists(RutaArchivo) Then
                        System.IO.Directory.CreateDirectory(RutaArchivo)
                    End If

                    RutaArchivo = RutaArchivo + "\" + Archivos.PNombreArchivo
                    RutaArchivoXML = RutaArchivo
                    row.Cells("RutaArchivos").Value = RutaArchivoXML
                    Try
                        File.Copy(Path.Combine(ruta), Path.Combine(RutaArchivo))
                    Catch copyError As IOException
                        Mensajes_Y_Alertas("ADVERTENCIA", "Ocurrió un error al copiar el archivo. Consulte este error con el área de TI: " +
                                           " Verificar permisos en carpeta de comprobantes de compra. ERROR:" + copyError.Message)
                    End Try

                    row.Cells("UUID").Value = Poliza.Puuid 'nombre del uuid
                    row.Cells("XML").Value = RutaArchivo 'ruta del xml


                    If Not IsNothing(row.Cells("UUID").Value.ToString) Then
                        'If e.Cell.Column.ToString.Equals(" ") Then
                        Dim objBU As New Negocios.ComprobantesFiscalesBU

                        Dim cfdIdNave As Integer = CInt(row.Cells("Nave").Value)
                        Dim IdEmpresa As Integer = CInt(row.Cells("EmpresaId").Value)
                        Dim RfcEmpresa As String = CStr(row.Cells("RFCEmpresa").Value).Replace("-", "")
                        Dim RfcProveedor As String = CStr(row.Cells("RFC").Value).Replace("-", "")
                        Dim IdProveedor As Integer = CInt(row.Cells("IdProveedor").Value)
                        Dim Fecha As DateTime = Poliza.Pfecha.ToShortDateString
                        Dim Version As String = "3.2"
                        Dim Serie As String = String.Empty
                        If Not IsNothing(Poliza.Pserie) Then
                            Serie = Poliza.Pserie
                        End If
                        Dim Folio As String = Poliza.Pfolio
                        Dim Total As Decimal = CDec(row.Cells("Total").Value)
                        Dim RutaXml As String = RutaArchivoXML
                        Dim RutaVisor As String = String.Empty
                        Dim Estatus As String = "A"
                        Dim IdTabla As Integer = CInt(row.Cells("IDTABLA").Value)
                        Try
                            objBU.Alta_archivos_XML_CFDS(cfdIdNave, IdEmpresa, RfcEmpresa, RfcProveedor, IdProveedor, Fecha, Version, Serie, Folio, Total, RutaXml, RutaVisor, Estatus, IdTabla)
                            Mensajes_Y_Alertas("EXITO", "Se guardó el archivo XML correctamente, ahora puede agregar el archivo PDF.")
                            row.Cells("XML").Value = RutaXml
                            row.Appearance.BackColor = Color.LimeGreen
                            RutaArchivoXML = String.Empty
                        Catch ex As Exception
                            Mensajes_Y_Alertas("ERROR", "Algo surgió mal durante la operación")
                        End Try

                    End If

                End If
            End If
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "Este comprobante ya cuenta con XML relacionado.")
        End If


    End Sub


    Private Sub btnRelacionarPDF_Click(sender As Object, e As EventArgs) Handles btnRelacionarPDF.Click
        If grdComprobantesFiscales.Selected.Rows.Count > 1 Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione solo un comprobante a la vez para relacionar su PDF.")
        ElseIf grdComprobantesFiscales.Selected.Rows.Count = 0 Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un comprobante para relacionar su PDF.")
        Else
            For Each row As UltraGridRow In grdComprobantesFiscales.Selected.Rows
                If Not IsDBNull(row.Cells("PDF").Value) Then
                    If row.Cells("PDF").Value <> "" Then
                        Mensajes_Y_Alertas("ADVERTENCIA", "Este comprobante ya cuenta con PDF relacionado.")
                    Else
                        RelacionarPDF()
                    End If
                Else
                    RelacionarPDF()
                End If
               
            Next

        End If
    End Sub


    Private Sub RelacionarPDF()
        Dim row As UltraGridRow = grdComprobantesFiscales.ActiveRow
        If Not String.IsNullOrEmpty(row.Cells("XML").Value.ToString) Then
            If Not (row.Cells("UUID").Value.ToString = "") Then

                ofdComprobantesFiscales.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                ofdComprobantesFiscales.Filter = "PDF|*.pdf"
                ofdComprobantesFiscales.Filter = "PDF|*.pdf"
                ofdComprobantesFiscales.FilterIndex = 3
                Dim ruta As String

                If ofdComprobantesFiscales.ShowDialog() = Windows.Forms.DialogResult.OK Then

                    Dim pregunta As New ConfirmarForm
                    pregunta.mensaje = "¿Está seguro que el archivo seleccionado es correcto? Posteriormente no podrá realizar cambios."
                    If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then

                        ruta = ofdComprobantesFiscales.FileName

                        Dim archivo() As String
                        archivo = Split(ruta, "\")

                        For n = 0 To UBound(archivo, 1)
                            If UBound(archivo) = n Then
                                Archivos.PNombreArchivo = archivo(n)
                            End If
                        Next

                        Poliza = extraerUUID(row.Cells("XML").Value)

                        Dim RutaArchivo As String = CStr(row.Cells("XML").Value) + Poliza.Pfecha.Month.ToString + Poliza.Pfecha.Year.ToString

                        If Not Directory.Exists(RutaArchivo) Then
                            System.IO.Directory.CreateDirectory(RutaArchivo)
                        End If

                        RutaArchivo = RutaArchivo + "\" + Poliza.Puuid + ".pdf"

                        Try
                            File.Copy(Path.Combine(ruta), Path.Combine(RutaArchivo))
                        Catch copyError As IOException
                            Mensajes_Y_Alertas("ADVERTENCIA", "Ocurrió un error al copiar el archivo. Consulte este error con el área de TI: Verificar permisos en carpeta de comprobantes de compra.")
                        End Try

                        If Not IsNothing(row.Cells("UUID").Value.ToString) Then
                            Dim objBU As New Negocios.ComprobantesFiscalesBU
                            Dim RutaVisor As String = RutaArchivo
                            Dim IdTabla As Integer = CInt(row.Cells("IDTABLA").Value)
                            Try
                                objBU.Actualiza_archivos_PDF_CFDS(RutaVisor, IdTabla)
                                Mensajes_Y_Alertas("EXITO", "Se guardó el archivo PDF correctamente.")
                                row.Cells("PDF").Value = RutaVisor
                                row.Appearance.BackColor = Color.LightGreen
                                RutaArchivoXML = String.Empty
                            Catch ex As Exception
                                Mensajes_Y_Alertas("ERROR", "Algo surgió mal durante la operación")
                            End Try

                        End If
                    End If

                End If
            Else
                Mensajes_Y_Alertas("ADVERTENCIA", "Ya se agregó un archivo PDF para este registro.")
            End If
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "Tiene que cargar primero el archivo XML.")
        End If
    End Sub


    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        grdComprobantesFiscales.DataSource = Nothing

        cmbTIpoComprobante.SelectedIndex = 0
        cmbTipoPoliza.SelectedIndex = 0

        rdoSoloComprobantes.Checked = False
        rdoFechaComprobante.Checked = True
        rdoFolioExacto.Checked = True
        rdoDentrodePoliza.Checked = True

        txtFolio.Text = ""

        dtpDe.Value = Today
        dtpAl.Value = Today

        empresaBD = ""
        servidorBD = ""
        doctoVentasID = ""
        contribuyentesID = ""
        empresaSAYContpaqSICY = ""
        RutaArchivoXML = ""


        lblTipoComprobante.ForeColor = Drawing.Color.Black
        lblTipoComprobante.ForeColor = Drawing.Color.Black
        lblDe.ForeColor = Drawing.Color.Black
        lblAl.ForeColor = Drawing.Color.Black
    End Sub


    ''' <summary>
    ''' METODO QUE MANDA A LLAMAR UN FORMULARIO DE MENSAJE DE TOOLS, SEGUN EL TIPO DE MENSAJE QUE SE HAYA ENVIADO COMO PARAMETRO
    ''' </summary>
    ''' <param name="Tipo">CADENA CON EL NOMBRE DEL TIPO DE MENSAJE A MOSTRAR "ADVERTENCIA" PARA EL FORMULARIO ADVERTENCIAFORM DE TOOLS,
    ''' "EXITO" PARA EL FORMULARIO EXITOFORM DE TOOLS, "ERROR" PARA EL FORMULARIO ERRORESFORM DE TOOLS, "INFORMACION" PARA EL FORMULARIO
    ''' "AVISOFORM" DE TOOLS, Y "CONFIRMACION" PARA EL FORMULARIO "CONFIRMARFORM" </param>
    ''' <param name="Mensaje">MENSAJE QUE SE MOSTRARA EN EL FORMULARIO SELECCIONADO</param>
    ''' <remarks></remarks>
    Private Sub Mensajes_Y_Alertas(ByVal Tipo As String, ByVal Mensaje As String)
        If Tipo = "ADVERTENCIA" Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = Mensaje
            objAdvertencia.ShowDialog()
        ElseIf Tipo = "EXITO" Then
            Dim objExito As New Tools.ExitoForm
            objExito.StartPosition = FormStartPosition.CenterScreen
            objExito.mensaje = Mensaje
            objExito.ShowDialog()
        ElseIf Tipo = "ERROR" Then
            Dim objErrores As New Tools.ErroresForm
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.mensaje = Mensaje
            objErrores.ShowDialog()
        ElseIf Tipo = "INFORMACION" Then
            Dim objInformacion As New Tools.AvisoForm
            objInformacion.StartPosition = FormStartPosition.CenterScreen
            objInformacion.mensaje = Mensaje
            objInformacion.ShowDialog()
        ElseIf Tipo = "CONFIRMACION" Then
            Dim objConfirmacion As New Tools.ConfirmarForm
            objConfirmacion.StartPosition = FormStartPosition.CenterScreen
            objConfirmacion.mensaje = Mensaje
            objConfirmacion.ShowDialog()
        End If
    End Sub


    ''' <summary>
    ''' FUNCION PARA VALIDAR QUE NO FALTE NINGUN CAMPO CONSIDERADO COMO CAMPO OBLIGATORIO
    ''' </summary>
    ''' <returns>RETORNA UN VALOR BOLEANO, TRUE PARA INDICAR QUE FALTAN DE SELECCIONAR FILTROS, VALOR FALSE PARA INDICAR QUE NO FALTAN FILTROS OBLIGATORIOS POR
    ''' SELECCIONAR.</returns>
    ''' <remarks></remarks>
    Private Function ValidarCamposVacios() As Boolean

        ValidarCamposVacios = False
        Dim cadenaClienteProveedor As String = String.Empty
        Dim cadenaClientes As String = String.Empty

        If cmbTIpoComprobante.SelectedIndex <= 0 Then
            lblTipoComprobante.ForeColor = Drawing.Color.Red
            ValidarCamposVacios = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Elije un tipo de comprobante y la empresa para poder consultar información.")

            lblEmpresa.ForeColor = Drawing.Color.Red
        Else
            lblTipoComprobante.ForeColor = Drawing.Color.Black
            lblTipoPoliza.ForeColor = Drawing.Color.Black
            lblNave.ForeColor = Drawing.Color.Black
            lblEmpresa.ForeColor = Drawing.Color.Black

            If rdoSoloComprobantes.Checked = True Then
                If cmbEmpresa.SelectedIndex <= 0 Then
                    lblEmpresa.ForeColor = Drawing.Color.Red
                    ValidarCamposVacios = True
                    Mensajes_Y_Alertas("ADVERTENCIA", "Elije una empresa para poder consultar los comprobantes fiscales.")
                Else
                    lblEmpresa.ForeColor = Drawing.Color.Black
                End If
            Else

                If cmbEmpresa.SelectedIndex <= 0 Then
                    lblEmpresa.ForeColor = Drawing.Color.Red
                    ValidarCamposVacios = True
                    Mensajes_Y_Alertas("ADVERTENCIA", "Elije una empresa para poder consultar los comprobantes fiscales.")
                Else
                    lblEmpresa.ForeColor = Drawing.Color.Black
                End If

                If cmbTipoPoliza.SelectedIndex <= 0 Then
                    lblTipoPoliza.ForeColor = Drawing.Color.Red
                    ValidarCamposVacios = True
                    Mensajes_Y_Alertas("ADVERTENCIA", "Elije tipo de póliza para poder consultar los comprobantes fiscales.")
                Else
                    lblTipoPoliza.ForeColor = Drawing.Color.Black
                End If
            End If
        End If

        If dtpAl.Value < dtpDe.Value Then
            ValidarCamposVacios = True
            Mensajes_Y_Alertas("ADVERTENCIA", "La fecha de inicio no puede se mayor a la fecha de fin.")
        End If

        Return ValidarCamposVacios
    End Function


    Private Sub RecuperarUUID(ByVal Tabla As DataTable)

        If Tabla.Rows.Count > 0 Then

            For Each row As UltraGridRow In grdComprobantesFiscales.Rows
                If row.Cells("Comprobante").Value = 0 Then
                    row.Appearance.BackColor = Drawing.Color.Salmon
                    row.Cells("UUID").Value = "SIN COMPROBANTE"
                Else
                    Dim lista As New Entidades.Polizas
                    lista = extraerUUID(row.Cells("XML").Value)
                    row.Cells("UUID").Value = lista.Puuid
                End If
            Next
        End If
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If ValidarCamposVacios() Then Return

        grdComprobantesFiscales.DataSource = Nothing

        Dim SoloComprobantes_O_ConPolizas As Boolean = False
        Dim Fecha_EnDocumento_O_EnPoliza As Boolean = False
        Dim Documento_EnPoliza_O_SinContabilizar As Boolean = False
        Dim FolioExacto_O_FolioAproximado As Boolean = False
        Dim CadenaProveedores As String = String.Empty
        Dim CadenaClientes As String = String.Empty

        If rdoSoloComprobantes.Checked = True Then
            SoloComprobantes_O_ConPolizas = True
        Else
            SoloComprobantes_O_ConPolizas = False
        End If

        If rdoFolioExacto.Checked = True Then
            FolioExacto_O_FolioAproximado = True
        Else
            FolioExacto_O_FolioAproximado = False
        End If

        If rdoFechaComprobante.Checked = True Then
            Fecha_EnDocumento_O_EnPoliza = True
        Else
            Fecha_EnDocumento_O_EnPoliza = False
        End If

        If rdoDentrodePoliza.Checked = True Then
            Documento_EnPoliza_O_SinContabilizar = True
        Else
            Documento_EnPoliza_O_SinContabilizar = False
        End If


        If cmbTIpoComprobante.Text = "EGRESOS" Then
            If hsListaCliente_Proveedor.Count > 0 Then
                For Each item In hsListaCliente_Proveedor
                    If CadenaProveedores = "" Then
                        CadenaProveedores = item.ToString
                    Else
                        CadenaProveedores = ", " + item.ToString
                    End If
                Next
            End If
        ElseIf cmbTIpoComprobante.Text = "INGRESOS" Then
            If hsListaCliente_Proveedor.Count > 0 Then
                For Each item In hsListaCliente_Proveedor
                    If CadenaProveedores = "" Then
                        CadenaProveedores = item.ToString
                    Else
                        CadenaProveedores = ", " + item.ToString
                    End If
                Next
            End If
        End If

        Dim IdNave As Integer
        If cmbNaves.SelectedIndex = 0 Then
            IdNave = 0
        Else
            IdNave = cmbNaves.SelectedValue
        End If



        Me.Cursor = Cursors.WaitCursor
        Try
            If cmbTIpoComprobante.Text = "EGRESOS" Then
                If SoloComprobantes_O_ConPolizas Then
                    CargarComprobantes_Egresos(contribuyentesID, dtpDe.Value, dtpAl.Value, CadenaProveedores, IdNave, txtFolio.Text, FolioExacto_O_FolioAproximado)
                Else
                    If cmbTipoPoliza.Text = "TRANSFERENCIAS" Then
                        CargarComprobantes_PolizaTransFerencias_Egresos(contribuyentesID, Documento_EnPoliza_O_SinContabilizar, cmbTipoPoliza.SelectedValue,
                                                                        Fecha_EnDocumento_O_EnPoliza, dtpDe.Value, dtpAl.Value, CadenaProveedores, IdNave,
                                                                        LTrim(RTrim(txtFolio.Text)), FolioExacto_O_FolioAproximado)
                    ElseIf cmbTipoPoliza.Text = "COMPRAS" Then
                        CargarComprobantes_PolizaCompras_Egresos(contribuyentesID, Documento_EnPoliza_O_SinContabilizar, cmbTipoPoliza.SelectedValue,
                                                                        Fecha_EnDocumento_O_EnPoliza, dtpDe.Value, dtpAl.Value, CadenaProveedores, IdNave,
                                                                        LTrim(RTrim(txtFolio.Text)), FolioExacto_O_FolioAproximado)
                    ElseIf cmbTipoPoliza.Text = "GASTOS" Then
                        Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "TIPO DE POLIZA EN CONTRUCCION")
                    ElseIf cmbTipoPoliza.Text = "PRODUCTO TERMINADO" Then
                        Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "TIPO DE POLIZA EN CONTRUCCION")
                    ElseIf cmbTipoPoliza.Text = "GASTOS Y COMPRAS" Then
                        Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "TIPO DE POLIZA EN CONTRUCCION")
                    ElseIf cmbTipoPoliza.Text = "GASTOS DE TRANSPORTE" Then
                        Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "TIPO DE POLIZA EN CONTRUCCION")
                    ElseIf cmbTipoPoliza.Text = "ACTIVO FIJO" Then
                        Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "TIPO DE POLIZA EN CONTRUCCION")
                    End If
                End If

            ElseIf cmbTIpoComprobante.Text = "INGRESOS" Then

                If SoloComprobantes_O_ConPolizas Then
                    CargarComprobante_Ingresos(cmbEmpresa.SelectedValue, dtpDe.Value, dtpAl.Value, CadenaClientes, FolioExacto_O_FolioAproximado, txtFolio.Text)
                Else
                    If cmbTipoPoliza.Text = "VENTAS" Then
                        CargarComprobante_PolizaVentas_Ingresos(cmbEmpresa.SelectedValue, Documento_EnPoliza_O_SinContabilizar, cmbTipoPoliza.SelectedValue,
                                                                Fecha_EnDocumento_O_EnPoliza, dtpDe.Value, dtpAl.Value, CadenaClientes, txtFolio.Text,
                                                                FolioExacto_O_FolioAproximado)
                    ElseIf cmbTipoPoliza.Text = "NOTAS DE CRÉDITO" Then
                        CargarComprobante_PolizaNotasCredito_Ingresos(cmbEmpresa.SelectedValue, Documento_EnPoliza_O_SinContabilizar, cmbTipoPoliza.SelectedValue,
                                                            Fecha_EnDocumento_O_EnPoliza, dtpDe.Value, dtpAl.Value, CadenaClientes, txtFolio.Text,
                                                            FolioExacto_O_FolioAproximado)

                    ElseIf cmbTipoPoliza.Text = "NOTAS DE CARGO" Then

                        Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "TIPO DE POLIZA EN CONTRUCCION")
                    ElseIf cmbTipoPoliza.Text = "DEPÓSITOS POR IDENTIFICAR" Then
                        Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "TIPO DE POLIZA EN CONTRUCCION")
                    ElseIf cmbTipoPoliza.Text = "DEPÓSITOS IDENTIFICADOS" Then
                        Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "TIPO DE POLIZA EN CONTRUCCION")
                    End If
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado al consultar la información. Error" + ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        Dim cadenaComprobantes As String = String.Empty

        If grdComprobantesFiscales.Rows.Count > 0 Then
            If grdComprobantesFiscales.Selected.Rows.Count > 0 Then
                For Each row As UltraGridRow In grdComprobantesFiscales.Selected.Rows
                    Try
                        Process.Start(row.Cells("PDF").Value)
                    Catch ex As Exception
                        If cadenaComprobantes = "" Then
                            cadenaComprobantes = CStr(row.Cells("Serie").Value) + CStr(row.Cells("Folio").Value)
                        Else
                            cadenaComprobantes += ", " + CStr(row.Cells("Serie").Value) + CStr(row.Cells("Folio").Value)
                        End If
                    End Try
                Next
                If cadenaComprobantes <> "" Then
                    Mensajes_Y_Alertas("ADVERTENCIA", "Los siguientes comprobantes no cuentan con PDF relacionado: " + cadenaComprobantes)
                End If

            Else
                Mensajes_Y_Alertas("ADVERTENCIA", "Selecciona por lo menos un comprobante para consultar su PDF")
            End If
        End If
    End Sub


    Private Sub btnAbrirXML_Click(sender As Object, e As EventArgs) Handles btnAbrirXML.Click
        Dim CadenaComprobantes As String = String.Empty

        If grdComprobantesFiscales.Rows.Count > 0 Then
            If grdComprobantesFiscales.Selected.Rows.Count > 0 Then
                For Each ROW As UltraGridRow In grdComprobantesFiscales.Selected.Rows
                    If ROW.Cells("XML").Text <> "" Then
                        Try
                            Process.Start(grdComprobantesFiscales.ActiveRow.Cells("XML").Value)
                        Catch ex As Exception
                            If CadenaComprobantes = "" Then
                                CadenaComprobantes = CStr(ROW.Cells("Serie").Value) + CStr(ROW.Cells("Folio").Value)
                            Else
                                CadenaComprobantes += ", " + CStr(ROW.Cells("Serie").Value) + CStr(ROW.Cells("Folio").Value)
                            End If
                        End Try
                    End If
                Next
                If CadenaComprobantes <> "" Then
                    Mensajes_Y_Alertas("ADVERTENCIA", "Los siguientes comprobantes no cuentan con XML relacionado: " + CadenaComprobantes)
                End If
            Else
                Mensajes_Y_Alertas("ADVERTENCIA", "Selecciona por lo menos un comprobante para consultar su XML")
            End If
        End If
    End Sub


    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesAlto.Height = 28
    End Sub


    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesAlto.Height = 137
    End Sub


    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

#End Region

#Region "ACCIONES RADIOBUTTON"

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        RecuperarValoresRazonSocial()

        If cmbTIpoComprobante.SelectedIndex = 2 Then
            If cmbEmpresa.SelectedIndex > 0 Then
                LlenarComboNaves_De_RazonesSociales(cmbNaves, CStr(cmbEmpresa.SelectedValue))
            End If
        End If
    End Sub


    Private Sub rdoFechaPoliza_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFechaPoliza.CheckedChanged
        If rdoFechaPoliza.Checked = True Then
            rdoDentrodePoliza.Checked = True
            rdoSinContabilizar.Enabled = False
        Else
            rdoDentrodePoliza.Checked = True
            rdoSinContabilizar.Enabled = True
        End If
    End Sub


    Private Sub rdoSoloComprobantes_CheckedChanged(sender As Object, e As EventArgs) Handles rdoSoloComprobantes.CheckedChanged
        If rdoSoloComprobantes.Checked = True Then
            gboxLugar.Enabled = False
            If IsNothing(cmbTipoPoliza.DataSource) = False Then
                cmbTipoPoliza.SelectedIndex = 0
            End If
            rdoFechaComprobante.Checked = True
            rdoFechaPoliza.Checked = False
            rdoFechaPoliza.Enabled = False
        Else
            gboxLugar.Enabled = True
            rdoFechaPoliza.Enabled = True
            If IsNothing(cmbTipoPoliza.DataSource) = False Then
                cmbTipoPoliza.SelectedIndex = 0
            End If
        End If
    End Sub

#End Region




    
    Private Sub btnClienteProveedor_Click(sender As Object, e As EventArgs) Handles btnClienteProveedor.Click

        Dim objlistado As New Filtro_ComprobantesFiscales_ClientesProveedores_ConGridForm
        objlistado.tipo_busqueda = cmbTIpoComprobante.SelectedIndex
        objlistado.lblNumFiltrados.Text = grdClienteProveedor.Rows.Count
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClienteProveedor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        objlistado.listaParametroID = listaParametroID
        objlistado.ShowDialog(Me)
        If Not objlistado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If objlistado.listParametros.Rows.Count = 0 Then Return
        If IsNothing(hsListaCliente_Proveedor) = False Then
            hsListaCliente_Proveedor.Clear()
        End If


        grdClienteProveedor.DataSource = objlistado.listParametros

        For Each row As UltraGridRow In grdClienteProveedor.Rows
            hsListaCliente_Proveedor.Add(row.Cells(0).Value)
        Next
        With grdClienteProveedor
            .DisplayLayout.Bands(0).Columns("Razon_Social").Header.Caption = "Razón Social"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
        End With
    End Sub

    Private Sub grdClienteProveedor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClienteProveedor.InitializeLayout
        With grdClienteProveedor.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grdClienteProveedor.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grdClienteProveedor)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub

End Class