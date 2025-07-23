Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports DevExpress.XtraPrinting
Imports System.Xml
Imports System.IO
Imports ToolServicios
Imports Facturacion.Negocios
Imports Ventas.Negocios

Public Class ComprasPTIngresado_AdministradorDocumentos_Form
    Dim listaInicial As New List(Of String)

#Region "Properties"
    Dim objBU As New Proveedores.BU.AdmonDoctosComprasPT_BU
#End Region

#Region "Methods"
    Private Sub ValidarDebug()
        gbxSistemas.Visible = False

        '#If DEBUG Then
        '        gbxSistemas.Visible = True
        '        chkPruebas.Checked = True
        '        chkLocal.Checked = True
        '#End If
        Try
            If objBU.ConsultarPerfilSistemas() Then
                gbxSistemas.Visible = True
                'chkPruebas.Checked = True
                'chkLocal.Checked = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ConfiguracionPermisosBotones()
        If PermisosUsuarioBU.ConsultarPermiso("AdmonDoctosCPTI", "ADCPTI_DESCARGAR") Then
            pnlDescargar.Visible = True
        Else
            pnlDescargar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("AdmonDoctosCPTI", "ADCPTI_CONSULTARSAP") Then
            'pnlExistenciaSAP.Visible = True
            'SE DESACTIVA ESTA OPCIÓN DE ESTE FORMULARIO, PERO SE DEJA EL PERMISO POR SI SOLICITAN REACTIVARLA POSTERIORMENTE
            'LMEP 24/07/2020
            pnlExistenciaSAP.Visible = False
        Else
            pnlExistenciaSAP.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("AdmonDoctosCPTI", "ADCPTI_CANCELARDOCTO") Then
            pnlCancelar.Visible = True
        Else
            pnlCancelar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("AdmonDoctosCPTI", "ADCPTI_EXPORTARLISTADO") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("AdmonDoctosCPTI", "ADCPTI_TIMBRARDOCTO") Then
            pnlTimbrar.Visible = True
        Else
            pnlTimbrar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("AdmonDoctosCPTI", "ADCPTI_GENERARPDFDOCTO") Then
            pnlPdf.Visible = True
        Else
            pnlPdf.Visible = False
        End If

        pnlDevolver.Visible = PermisosUsuarioBU.ConsultarPermiso("AdmonDoctosCPTI", "ADCPTI_GENERARDEVOLUCION")
        pnlImportarComplemento.Visible = PermisosUsuarioBU.ConsultarPermiso("AdmonDoctosCPTI", "ADCPTI_IMPORTARCOMPLEMENTO")

    End Sub

    Public Sub Show_message(ByVal tipo As String, ByVal mensaje As String)
        Dim objMensaje As Object

        Select Case tipo
            Case "Advertencia"
                objMensaje = New AdvertenciaForm
            Case "Aviso"
                objMensaje = New AvisoForm
            Case "Error"
                objMensaje = New ErroresForm
            Case "Exito"
                objMensaje = New ExitoForm
            Case "Confirmar"
                objMensaje = New ConfirmarForm
            Case "AdvertenciaGrande"
                objMensaje = New AdvertenciaFormGrande
            Case Else
                objMensaje = New AvisoForm
        End Select

        objMensaje.mensaje = mensaje
        objMensaje.ShowDialog()
    End Sub

    Private Sub Grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next
        AsignaFormato_Columna(grid)
    End Sub

    Public Sub AsignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Sub LimpiarGridListado()
        chkSeleccionarTodo.Checked = False
        chkSeleccionarTodo.Enabled = False
        grdListado.DataSource = Nothing
    End Sub

    Private Sub AbrirListaParametros(ByVal tipoBusqueda As Integer, ByVal tipoNave As Integer, ByVal grid As UltraGrid, ByVal encabezado As String)
        Dim listado As New ListaParametrosForm With {
            .tipo_busqueda = tipoBusqueda,
            .tipo_Nave = tipoNave
        }

        Dim listaParametroId As New List(Of String)

        For Each row As UltraGridRow In grid.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroId.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroId
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        LimpiarGridListado()
        grid.DataSource = listado.listaParametros
        Grid_diseño(grid)

        If tipoBusqueda = 5 Then
            With grid
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Hidden = True
                .DisplayLayout.Bands(0).Columns(4).Hidden = True
                .DisplayLayout.Bands(0).Columns(3).Hidden = False
                .DisplayLayout.Bands(0).Columns(3).Header.Caption = encabezado
            End With
        Else
            With grid
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = encabezado
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        End If

    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid) As String
        Dim lista As New List(Of Integer)
        For Each Row As UltraGridRow In grid.Rows
            If Row.Cells(0).Value Then lista.Add(Row.Cells(0).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function

    Private Sub DisenioGrid()
        '   gvwListado.BestFitColumns()
        gvwListado.OptionsView.EnableAppearanceEvenRow = True
        gvwListado.IndicatorWidth = 30
        gvwListado.OptionsView.ShowAutoFilterRow = True
        gvwListado.OptionsView.RowAutoHeight = True


        gvwListado.Columns.ColumnByFieldName("ST").Width = 20
        gvwListado.Columns.ColumnByFieldName("STATUS").Visible = False
        gvwListado.Columns.ColumnByFieldName("EMISOR_RFC").Visible = False
        gvwListado.Columns.ColumnByFieldName("RECEPTOR_RFC").Visible = False
        gvwListado.Columns.ColumnByFieldName("RUTA_XML").Visible = False
        gvwListado.Columns.ColumnByFieldName("RUTA_PDF").Visible = False
        gvwListado.Columns.ColumnByFieldName("RUTA_XML_CANCELACION").Visible = False
        gvwListado.Columns.ColumnByFieldName("RUTA_PDF_CANCELACION").Visible = False
        gvwListado.Columns.ColumnByFieldName("EMISORID").Visible = False
        gvwListado.Columns.ColumnByFieldName("RECEPTORID").Visible = False
        gvwListado.Columns.ColumnByFieldName("EMISORSICYID").Visible = False
        gvwListado.Columns.ColumnByFieldName("RECEPTORSICYID").Visible = False
        gvwListado.Columns.ColumnByFieldName("UUID").Visible = False
        gvwListado.Columns.ColumnByFieldName("TIMBRADA").Visible = False
        gvwListado.Columns.ColumnByFieldName("CANCELADA").Visible = False
        gvwListado.Columns.ColumnByFieldName("FOLIO").Visible = False
        gvwListado.Columns.ColumnByFieldName("COMPLEMENTO").Visible = False
        gvwListado.Columns.ColumnByFieldName("FACTURA EXTERNA").Visible = False

        gvwListado.Columns.ColumnByFieldName(" ").OptionsColumn.Printable = False

        gvwListado.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True
        gvwListado.Columns.ColumnByFieldName("ST").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("ID SAY").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("FACTURA").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("TIPO NAVE").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("FENTRADA").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("EMISOR").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("RECEPTOR").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("FFACTURA").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("CAPTURÓ").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("CANTIDAD").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("IVA").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("TOTAL").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("FCANCELACIÓN").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("CANCELÓ").OptionsColumn.AllowEdit = False
        gvwListado.Columns.ColumnByFieldName("SALDO FACTURA").OptionsColumn.AllowEdit = False

        gvwListado.Columns.ColumnByFieldName("CANTIDAD").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("CANTIDAD").DisplayFormat.FormatString = "N0"
        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("SUBTOTAL").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("TOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("TOTAL").DisplayFormat.FormatString = "N2"
        gvwListado.Columns.ColumnByFieldName("SALDO FACTURA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        gvwListado.Columns.ColumnByFieldName("SALDO FACTURA").DisplayFormat.FormatString = "N2"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In gvwListado.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("CANTIDAD") Or col.FieldName.Contains("SUBTOTAL") Or col.FieldName.Contains("IVA") Or col.FieldName.Contains("TOTAL") Or col.FieldName.Contains("SALDO FACTURA") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "CANTIDAD")) = True And col.FieldName = "CANTIDAD" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "SUBTOTAL")) = True And col.FieldName = "SUBTOTAL" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "TOTAL")) = True And col.FieldName = "TOTAL" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "SALDO FACTURA")) = True And col.FieldName = "SALDO FACTURA" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next
        gvwListado.OptionsView.ColumnAutoWidth = True
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function ListDocuments() As List(Of Integer)
        Dim lista As New List(Of Integer)
        For i As Integer = 0 To gvwListado.RowCount - 1
            If gvwListado.GetRowCellValue(i, " ") Then
                lista.Add(gvwListado.GetRowCellValue(i, "ID SAY"))
            End If
        Next
        Return lista
    End Function

    Private Function TimbrarDocumento(ByVal documentoId As String, ByVal emisorId As String, ByVal TipoComprbante As String) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(chkLocal.Checked, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty

        llamarServicio.url = Servidor & "Facturas/Timbrado" &
                            "?DocumentoID=" & documentoId &
                            "&EmpresaID=" & emisorId &
                            "&TipoComprobante=" & TipoComprbante &
                            "&TimbradoPrueba=" & chkPruebas.Checked.ToString()
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            objUtilerias.CrearDirectorio(RutaCliente)
            objUtilerias.CrearDirectorio(RutaServidorSICY)
            objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, chkLocal.Checked)

            ActualizarDatosTimbrado(documentoId, RutaServidorSICY)
            GenerarCuentaPorPagar(documentoId)
            GenerarPDF(documentoId, TipoComprbante)
            resultado = "EXITO"
        Else
            resultado = Respuesta.aviso & "(" & documentoId.ToString & ")"
            Try
                objBU.ActualizarMtvoSinTimbrarFacturaPIDocumento(documentoId, resultado)
            Catch ex As Exception

            End Try
        End If

        Return resultado
    End Function

    Private Function ActualizarDatosTimbrado(ByVal idDocumento As Integer, ByVal sXML As String) As String
        Dim resultado As String = String.Empty
        Try
            Dim Doc As New XmlDocument
            Dim TimbreFiscal As XmlNode
            Dim Factura As XmlNode

            Dim sello As String = String.Empty
            Dim uuid As String = String.Empty
            Dim fechaTimbrado As String = String.Empty
            Dim versionSat As String = String.Empty
            Dim rfcProvCertif As String = String.Empty
            Dim noCertificadoSAT As String = String.Empty
            Dim selloSAT As String = String.Empty
            Dim cadenaOriginal As String = String.Empty
            Dim cadenaOriginalComplemento As String = String.Empty

            Doc.Load(sXML)
            Dim xmlmanager As System.Xml.XmlNamespaceManager = New XmlNamespaceManager(Doc.NameTable)
            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            xmlmanager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance")
            Dim Fila As Integer = 0
            Factura = Doc.ChildNodes(1)
            sello = Factura.Attributes.GetNamedItem("Sello").Value

            Dim nodo As XmlNode = Factura.SelectSingleNode("cfdi:Complemento", xmlmanager)
            TimbreFiscal = nodo.ChildNodes(0)
            uuid = TimbreFiscal.Attributes.GetNamedItem("UUID").Value
            fechaTimbrado = TimbreFiscal.Attributes.GetNamedItem("FechaTimbrado").Value
            versionSat = TimbreFiscal.Attributes.GetNamedItem("Version").Value
            rfcProvCertif = TimbreFiscal.Attributes.GetNamedItem("RfcProvCertif").Value
            noCertificadoSAT = TimbreFiscal.Attributes.GetNamedItem("NoCertificadoSAT").Value
            selloSAT = TimbreFiscal.Attributes.GetNamedItem("SelloSAT").Value
            cadenaOriginalComplemento = "||" & versionSat.Trim() & "|" & uuid & "|" & fechaTimbrado & "|" & sello & "|" & noCertificadoSAT & "||"

            resultado = objBU.ActualizarInfoFacturaPIDocumento(idDocumento, sello, uuid, fechaTimbrado, versionSat, rfcProvCertif, noCertificadoSAT, selloSAT, cadenaOriginal, cadenaOriginalComplemento)
        Catch ex As Exception
            resultado = ex.Message
        End Try
        Return resultado
    End Function

    Private Function GenerarCuentaPorPagar(ByVal idDocumento As Integer) As String
        Dim resultado As String = String.Empty
        Try
            Dim dtResultado As New DataTable
            Dim idcomprobantesicy As Integer = 0

            Try
                idcomprobantesicy = objBU.ObtenerIdComprobanteCFD(idDocumento)
            Catch ex As Exception
            End Try

            dtResultado = objBU.ObtenerInfoCXPSaldo(idDocumento)
            If Not dtResultado Is Nothing Then
                If dtResultado.Rows.Count > 0 Then
                    Dim tipoDoc As Integer
                    Dim idProveedor As Integer
                    Dim numDoc As String
                    Dim fechaDoc As Date
                    Dim fechaVencimiento As Date
                    Dim semanaPago As Integer
                    Dim semanaPagada As Integer
                    Dim subTotal As Double
                    Dim iva As Double
                    Dim total As Double
                    Dim totalDoc As Double
                    Dim moneda As Integer
                    Dim nave As Integer
                    Dim añoSemPago As Integer
                    Dim rfcContribuyente As String
                    Dim rfcProveedor As String
                    Dim giro As String

                    tipoDoc = CInt(dtResultado.Rows(0)("tipoDoc").ToString)
                    idProveedor = CInt(dtResultado.Rows(0)("idProveedor").ToString)
                    numDoc = dtResultado.Rows(0)("numDoc").ToString
                    fechaDoc = CDate(dtResultado.Rows(0)("fechaDoc").ToString)
                    fechaVencimiento = CDate(dtResultado.Rows(0)("fechaVencimiento").ToString)
                    semanaPago = CInt(dtResultado.Rows(0)("semanaPago").ToString)
                    semanaPagada = CInt(dtResultado.Rows(0)("semanaPagada").ToString)
                    subTotal = CDbl(dtResultado.Rows(0)("subTotal").ToString)
                    iva = CDbl(dtResultado.Rows(0)("iva").ToString)
                    total = CDbl(dtResultado.Rows(0)("total").ToString)
                    totalDoc = CDbl(dtResultado.Rows(0)("totalDoc").ToString)
                    moneda = CInt(dtResultado.Rows(0)("moneda").ToString)
                    nave = CInt(dtResultado.Rows(0)("nave").ToString)
                    añoSemPago = CInt(dtResultado.Rows(0)("añoSemPago").ToString)
                    rfcContribuyente = dtResultado.Rows(0)("rfcContribuyente").ToString
                    rfcProveedor = dtResultado.Rows(0)("rfcProveedor").ToString
                    giro = dtResultado.Rows(0)("giro").ToString
                    'idcomprobantesicy = CInt(dtResultado.Rows(0)("idcomprobantesicy").ToString)

                    resultado = objBU.InsertarCXPSaldo(tipoDoc, idProveedor, numDoc, fechaDoc, fechaVencimiento, semanaPago, semanaPagada, subTotal, iva, total, totalDoc, moneda, nave, añoSemPago, rfcContribuyente, rfcProveedor, giro, idcomprobantesicy)
                    If resultado <> "True" Then
                        Show_message("Advertencia", resultado)
                    End If
                Else
                    Show_message("Advertencia", "No se pudo obtener la información para generar la cuenta por pagar")
                End If
            Else
                Show_message("Advertencia", "No se pudo obtener la información para generar la cuenta por pagar")
            End If
        Catch ex As Exception
            Show_message("Advertencia", ex.Message)
        End Try
        Return resultado
    End Function

    Private Function GenerarPDF(ByVal documentoId As Integer, ByVal TipoComprbante As String) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(chkLocal.Checked, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty

        llamarServicio.url = Servidor & "Facturas/GeneraPDF" &
                            "?DocumentoID=" & documentoId &
                            "&TipoComprobante=" & TipoComprbante
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            objUtilerias.CrearDirectorio(RutaCliente)
            objUtilerias.CrearDirectorio(RutaServidorSICY)
            objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, chkLocal.Checked)
            resultado = "EXITO"
        Else
            resultado = Respuesta.aviso & "(" & documentoId.ToString & ")"
        End If

        Return resultado
    End Function

    Private Function CancelarFactura(ByVal documentoId As Integer, ByVal uuid As String, ByVal empresaId As Integer, ByVal TipoComprbante As String) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(chkLocal.Checked, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty

        llamarServicio.url = Servidor & "Facturas/CancelacionFactura" &
                            "?DocumentoID=" & documentoId &
                            "&UUID=" & uuid &
                            "&EmpresaId=" & empresaId &
                            "&TipoComprobante=" & TipoComprbante &
                            "&TimbradoPrueba=" & chkPruebas.Checked &
                            "&UsuarioID=" & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            GenerarPDFCancelacion(documentoId, TipoComprbante)
            resultado = "EXITO"
        Else
            resultado = Respuesta.aviso & "(" & documentoId.ToString & ")"
        End If

        Return resultado
    End Function

    Private Function CancelarDocumento(ByVal documentoId As Integer) As String
        Try
            Dim objBUFactura As New Facturacion.Negocios.FacturasBU
            objBUFactura.ActualizarInformacionCancelacionFactura(documentoId, Date.Now.ToString("yyyy-MM-ddThh:mm:ss"), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "COMPRAPRODINGRESADO")
            Return "EXITO"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function GenerarPDFCancelacion(ByVal documentoId As Integer, ByVal TipoComprbante As String) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(chkLocal.Checked, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty

        llamarServicio.url = Servidor & "Facturas/GeneraPDFFacturaCancelada" &
                            "?DocumentoID=" & documentoId &
                            "&TipoComprobante=" & TipoComprbante
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            resultado = "EXITO"
        Else
            resultado = Respuesta.aviso & "(" & documentoId.ToString & ")"
        End If

        Return resultado
    End Function

    Private Sub InicializaFiltros()
        grdStatus.DataSource = listaInicial
        grdDocumento.DataSource = listaInicial
        grdFolio.DataSource = listaInicial
        grdEmisor.DataSource = listaInicial
        grdReceptor.DataSource = listaInicial
        grdArticulo.DataSource = listaInicial
    End Sub

#End Region

#Region "Events"
    Private Sub ComprasPTIngresado_AdministradorDocumentos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        ValidarDebug()
        ConfiguracionPermisosBotones()
        InicializaFiltros()
    End Sub

    Private Sub BtnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Visible = False
    End Sub

    Private Sub BtnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Visible = True
    End Sub

    Private Sub BtnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click, lblVerDetalles.Click
        Try
            If gvwListado.RowCount > 0 Then
                Dim objForm As New ComprasPTIngresado_DetallesDocumento
                If Not CheckForm(objForm) Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim lista As New List(Of Integer)
                    For i As Integer = 0 To gvwListado.RowCount - 1
                        If gvwListado.GetRowCellValue(i, " ") Then
                            objForm.emisorRazonSocial = gvwListado.GetRowCellValue(i, "EMISOR")
                            objForm.receptorRazonSocial = gvwListado.GetRowCellValue(i, "RECEPTOR")
                            objForm.receptorRfc = gvwListado.GetRowCellValue(i, "RECEPTOR_RFC")
                            objForm.foloFactura = gvwListado.GetRowCellValue(i, "FACTURA")
                            objForm.statusDocto = gvwListado.GetRowCellValue(i, "STATUS")
                            objForm.emisorRfc = gvwListado.GetRowCellValue(i, "EMISOR_RFC")
                            objForm.fechaIngreso = gvwListado.GetRowCellValue(i, "FENTRADA")
                            lista.Add(gvwListado.GetRowCellValue(i, "ID SAY"))
                        End If
                    Next

                    objForm.documentoIds = ListDocuments()
                    If objForm.documentoIds.Count = 0 Then
                        Show_message("Advertencia", "Debe seleccionar al menos un registro.")
                    Else
                        objForm.ShowDialog()
                    End If
                End If
            Else
                Show_message("Advertencia", "No hay información.")
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click, lblDescargar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim documentoIds As List(Of Integer)

        Try
            If gvwListado.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                documentoIds = ListDocuments()
                If documentoIds.Count = 0 Then
                    Show_message("Advertencia", "Debe seleccionar al menos un registro.")
                Else
                    Cursor = Cursors.WaitCursor
                    With fbdUbicacionArchivo
                        .Reset()
                        .Description = "Seleccione una carpeta "
                        .ShowNewFolderButton = True

                        Dim ret As DialogResult = .ShowDialog
                        If ret = Windows.Forms.DialogResult.OK Then
                            For i As Integer = 0 To gvwListado.RowCount - 1
                                If gvwListado.GetRowCellValue(i, " ") Then
                                    If My.Computer.FileSystem.FileExists(gvwListado.GetRowCellValue(i, "RUTA_XML")) Then
                                        My.Computer.FileSystem.CopyFile(gvwListado.GetRowCellValue(i, "RUTA_XML"), .SelectedPath & "\" & Path.GetFileName(gvwListado.GetRowCellValue(i, "RUTA_XML")), True)
                                    End If
                                    If My.Computer.FileSystem.FileExists(gvwListado.GetRowCellValue(i, "RUTA_PDF")) Then
                                        My.Computer.FileSystem.CopyFile(gvwListado.GetRowCellValue(i, "RUTA_PDF"), .SelectedPath & "\" & Path.GetFileName(gvwListado.GetRowCellValue(i, "RUTA_PDF")), True)
                                    End If

                                    If My.Computer.FileSystem.FileExists(gvwListado.GetRowCellValue(i, "RUTA_XML_CANCELACION")) Then
                                        My.Computer.FileSystem.CopyFile(gvwListado.GetRowCellValue(i, "RUTA_XML_CANCELACION"), .SelectedPath & "\" & Path.GetFileName(gvwListado.GetRowCellValue(i, "RUTA_XML_CANCELACION")), True)
                                    End If
                                    If My.Computer.FileSystem.FileExists(gvwListado.GetRowCellValue(i, "RUTA_PDF_CANCELACION")) Then
                                        My.Computer.FileSystem.CopyFile(gvwListado.GetRowCellValue(i, "RUTA_PDF_CANCELACION"), .SelectedPath & "\" & Path.GetFileName(gvwListado.GetRowCellValue(i, "RUTA_PDF_CANCELACION")), True)
                                    End If
                                End If
                            Next
                            Show_message("Exito", "Archivo(s) descargado(s) correctamente.")
                        End If
                    End With
                End If
            Else
                Show_message("Advertencia", "No hay información.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub BtnExistenciaSAP_Click(sender As Object, e As EventArgs) Handles btnExistenciaSAP.Click, lblExistenciaSAP.Click
        Dim ventana As New ComprasPTIngresado_VerificarExistenciasSAP_Form With {
            .MdiParent = Me.MdiParent
        }
        ventana.Show()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, lblCancelar.Click
        Try
            Dim documentoIds As List(Of Integer)
            Dim strResultado As String = String.Empty
            Dim objBUCPT As New Proveedores.BU.ConsultaComprasPT_BU
            Dim resultadoFinal As String = String.Empty

            If gvwListado.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                documentoIds = ListDocuments()
                If documentoIds.Count = 0 Then
                    Show_message("Advertencia", "Debe seleccionar al menos un registro.")
                Else
                    For i As Integer = 0 To gvwListado.RowCount - 1
                        If gvwListado.GetRowCellValue(i, " ") And gvwListado.GetRowCellValue(i, "TIMBRADA") Then
                            Dim documentoId As Integer = gvwListado.GetRowCellValue(i, "ID SAY")
                            Dim uuid As String = gvwListado.GetRowCellValue(i, "UUID")
                            Dim emisorId As Integer = gvwListado.GetRowCellValue(i, "EMISORID")
                            Dim folio As String = gvwListado.GetRowCellValue(i, "FACTURA")
                            Dim fecha As String = gvwListado.GetRowCellValue(i, "FFACTURA")
                            Dim total As Double = gvwListado.GetRowCellValue(i, "TOTAL")
                            Dim tipoDocumento As String = "COMPRAPRODINGRESADO"
                            Dim dtResultado As New DataTable

                            If CBool(gvwListado.GetRowCellValue(i, "COMPLEMENTO")) Then
                                tipoDocumento = "FACTURACOMPLEMENTO"
                            End If

                            dtResultado = objBU.ObtenerInfoCXPSaldo(documentoId)
                            If Not dtResultado Is Nothing Then
                                If dtResultado.Rows.Count > 0 Then
                                    Dim idProveedor As Integer
                                    idProveedor = CInt(dtResultado.Rows(0)("idProveedor").ToString)
                                    If objBU.ValidarCuentaPorPagar(folio, fecha, total) Then
                                        strResultado = CancelarFactura(documentoId, uuid, emisorId, tipoDocumento)
                                        If strResultado.Equals("EXITO") Then
                                            CancelarDocumentoSICY(documentoId)
                                        Else
                                            resultadoFinal = resultadoFinal & vbCrLf & documentoId.ToString() & "-" & strResultado
                                        End If
                                    Else
                                        resultadoFinal = resultadoFinal & vbCrLf & documentoId.ToString() & "- La cuenta por pagar del documento ya tiene movimientos"
                                    End If
                                Else
                                    resultadoFinal = resultadoFinal & vbCrLf & documentoId.ToString() & "- No se pudo obtener el id de proveedor"
                                End If
                            Else
                                resultadoFinal = resultadoFinal & vbCrLf & documentoId.ToString() & "- No se pudo obtener el id de proveedor"
                            End If
                        ElseIf gvwListado.GetRowCellValue(i, " ") Then
                            Dim documentoId As Integer = gvwListado.GetRowCellValue(i, "ID SAY")
                            strResultado = CancelarDocumento(documentoId)
                            If strResultado.Equals("EXITO") Then
                                CancelarDocumentoSICY(documentoId)
                            Else
                                resultadoFinal = resultadoFinal & vbCrLf & documentoId.ToString() & "-" & strResultado
                            End If
                        End If
                    Next

                    If resultadoFinal.Equals("") Then
                        Show_message("Exito", "Facturas(s) cancelada(s) correctamente.")
                    Else
                        Show_message("Adverencia", "No se pudo cancelar:" & resultadoFinal)
                    End If

                    BtnMostrar_Click(Nothing, Nothing)
                End If
            Else
                Show_message("Advertencia", "No hay información.")
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click, lblExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If gvwListado.DataRowCount > 0 Then

                nombreReporte = "DocumentosComprasPTIngresado"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.ToString("yyyyMMdd_Hmmss")

                    If ret = Windows.Forms.DialogResult.OK Then
                        If gvwListado.GroupCount > 0 Then
                            gvwListado.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            gvwListado.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try
    End Sub

    Private Sub BtnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click, lblTimbrar.Click
        Try
            Dim documentoIds As List(Of Integer)
            Dim strResultado As String = String.Empty
            Dim objBUCPT As New Proveedores.BU.ConsultaComprasPT_BU

            If gvwListado.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                documentoIds = ListDocuments()
                If documentoIds.Count = 0 Then
                    Show_message("Advertencia", "Debe seleccionar al menos un registro.")
                Else
                    Dim objMensajeConf As New Tools.ConfirmarForm With {
                        .mensaje = "¿Está seguro de facturar? Este proceso no se podrá revertir."
                    }
                    If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim tipoDocumento As String = "COMPRAPRODINGRESADO"
                        For i As Integer = 0 To gvwListado.RowCount - 1
                            If gvwListado.GetRowCellValue(i, " ") Then
                                If CBool(gvwListado.GetRowCellValue(i, "COMPLEMENTO")) And CBool(gvwListado.GetRowCellValue(i, "FACTURA EXTERNA")) Then
                                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La factura " & gvwListado.GetRowCellValue(i, "FACTURA") & " es de complemento, no puede ser timbrada desde esta opción.")
                                    If documentoIds.Count = 1 Then
                                        Me.Cursor = Cursors.Default
                                        BtnMostrar_Click(Nothing, Nothing)
                                        Exit Sub
                                    End If
                                Else
                                    Dim documentoId As Integer = gvwListado.GetRowCellValue(i, "ID SAY")
                                    Dim emisorId As Integer = gvwListado.GetRowCellValue(i, "EMISORID")

                                    If CBool(gvwListado.GetRowCellValue(i, "COMPLEMENTO")) Then
                                        Dim objBU As New RegistrarInventarioSAPBU
                                        strResultado = objBU.GeneraInformacionTimbrar(documentoId) '' facturas sap
                                        tipoDocumento = "FACTURACOMPLEMENTO"
                                    Else
                                        strResultado = objBUCPT.GeneraInformacionTimbrar(documentoId)
                                    End If

                                    If strResultado.Equals("EXITO") Then
                                        strResultado = TimbrarDocumento(documentoId, emisorId, tipoDocumento)
                                        If strResultado.Equals("EXITO") Then
                                        Else
                                            Show_message("Error", "Error al generar timbrar." & vbCrLf & strResultado)
                                            Exit Sub
                                        End If
                                    Else
                                        Show_message("Error", "Error al generar información para timbrar." & vbCrLf & strResultado)
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Next

                        Show_message("Exito", "Documento(s) timbrado(s) correctamente.")
                        BtnMostrar_Click(Nothing, Nothing)
                    End If
                End If
            Else
                Show_message("Advertencia", "No hay información.")
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click, lblPdf.Click
        Try
            Dim documentoIds As List(Of Integer)
            Dim strResultado As String = String.Empty
            Dim objBUCPT As New Proveedores.BU.ConsultaComprasPT_BU
            Dim resultadoFinal As String = String.Empty

            If gvwListado.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                documentoIds = ListDocuments()
                If documentoIds.Count = 0 Then
                    Show_message("Advertencia", "Debe seleccionar al menos un registro.")
                Else
                    Dim blnGenerar As Boolean = True
                    For i As Integer = 0 To gvwListado.RowCount - 1
                        If gvwListado.GetRowCellValue(i, " ") And gvwListado.GetRowCellValue(i, "TIMBRADA") Then
                            Dim documentoId As Integer = gvwListado.GetRowCellValue(i, "ID SAY")
                            Dim TipoComprobante As String = "COMPRAPRODINGRESADO"

                            If CBool(gvwListado.GetRowCellValue(i, "COMPLEMENTO")) Then
                                ''Si es una factura de complemento validar que existe el registro en tablas de timbrado... 
                                blnGenerar = objBU.existeTimbradoComplemento(documentoId, "FACTURACOMPLEMENTO")
                                TipoComprobante = "FACTURACOMPLEMENTO"

                                If Not blnGenerar Then
                                    resultadoFinal = resultadoFinal & vbCrLf & "La factura " & gvwListado.GetRowCellValue(i, "FACTURA") & " es de complemento timbrado fuera de SAY, no se puede generar el PDF."
                                End If
                            End If

                            If blnGenerar Then
                                strResultado = GenerarPDF(documentoId, TipoComprobante)
                                If gvwListado.GetRowCellValue(i, "CANCELADA") Then
                                    GenerarPDFCancelacion(documentoId, TipoComprobante)
                                End If
                                If strResultado.Equals("EXITO") Then
                                    ''Actualizar el nombre del archivo... verificar en sp si es cancelada actualizar las dos rutas...
                                    strResultado = objBU.actualizaNombreDocumento(documentoId, TipoComprobante, "PDF")
                                Else
                                    resultadoFinal = resultadoFinal & vbCrLf & documentoId.ToString() & "-" & strResultado
                                End If
                            End If
                        End If
                    Next

                    If resultadoFinal.Equals("") Then
                        Show_message("Exito", "PDF(s) generado(s) correctamente.")
                    Else
                        Show_message("Adverencia", "No se pudo generar el PDF de:" & resultadoFinal)
                    End If

                    BtnMostrar_Click(Nothing, Nothing)
                End If
            Else
                Show_message("Advertencia", "No hay información.")
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ChkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        If gvwListado.RowCount > 0 Then
            For i As Integer = 0 To gvwListado.RowCount - 1
                gvwListado.SetRowCellValue(i, " ", chkSeleccionarTodo.Checked)
            Next
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RdoFechaFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFechaFacturacion.CheckedChanged
        LimpiarGridListado()
    End Sub

    Private Sub RdoFechaCancelacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFechaCancelacion.CheckedChanged
        LimpiarGridListado()
    End Sub

    Private Sub RdoFechaIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFechaIngreso.CheckedChanged
        LimpiarGridListado()
    End Sub

    Private Sub TxtFiltroDocumento_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltroDocumento.KeyUp
        If e.KeyCode = Keys.Enter And txtFiltroDocumento.Text > "" Then
            Dim listado As New List(Of String)

            For Each row As UltraGridRow In grdDocumento.Rows
                Dim value As String = row.Cells(0).Text
                listado.Add(value)
            Next
            listado.Add(txtFiltroDocumento.Text)

            If listado.Count = 0 Then Return
            LimpiarGridListado()
            grdDocumento.DataSource = listado
            Grid_diseño(grdDocumento)
            With grdDocumento
                .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Documentos"
            End With
            txtFiltroDocumento.Text = String.Empty
        End If
    End Sub

    Private Sub TxtFiltroFactura_KeyUp(sender As Object, e As KeyEventArgs) Handles txtFiltroFactura.KeyUp
        If e.KeyCode = Keys.Enter And txtFiltroFactura.Text > "" Then
            Dim listado As New List(Of String)

            For Each row As UltraGridRow In grdFolio.Rows
                Dim value As String = row.Cells(0).Text
                listado.Add(value)
            Next
            listado.Add(txtFiltroFactura.Text)

            If listado.Count = 0 Then Return
            LimpiarGridListado()
            grdFolio.DataSource = listado
            Grid_diseño(grdFolio)
            With grdFolio
                .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folios"
            End With
            txtFiltroFactura.Text = String.Empty
        End If
    End Sub

    Private Sub BtnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroStatus.Click, btnLimpiarFiltroEmisor.Click, btnLimpiarFiltroReceptor.Click, BtnLimpiarFiltroArticulo.Click
        Select Case sender.Name
            Case "btnLimpiarFiltroStatus"
                grdStatus.DataSource = listaInicial
            Case "btnLimpiarFiltroEmisor"
                grdEmisor.DataSource = listaInicial
            Case "btnLimpiarFiltroReceptor"
                grdReceptor.DataSource = listaInicial
            Case "BtnLimpiarFiltroArticulo"
                grdArticulo.DataSource = listaInicial
        End Select

        LimpiarGridListado()
    End Sub

    Private Sub BtnAgregarFiltros_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroStatus.Click, btnAgregarFiltroEmisor.Click, btnAgregarFiltroReceptor.Click, btnAgregarFiltroArticulo.Click
        Select Case sender.Name
            Case "btnAgregarFiltroStatus"
                AbrirListaParametros(2, 0, grdStatus, "Status")
            Case "btnAgregarFiltroEmisor"
                AbrirListaParametros(4, 0, grdEmisor, "Emisor")
            Case "btnAgregarFiltroReceptor"
                AbrirListaParametros(3, 0, grdReceptor, "Receptor")
            Case "btnAgregarFiltroArticulo"
                AbrirListaParametros(5, 0, grdArticulo, "Artículo")
        End Select

        LimpiarGridListado()
    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click, lblMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        chkSeleccionarTodo.Checked = False
        chkSeleccionarTodo.Enabled = False
        Try
            Dim dtResultado As New DataTable
            Dim porFFacturacion As Boolean = rdoFechaFacturacion.Checked
            Dim porFCancelacion As Boolean = rdoFechaCancelacion.Checked
            Dim porFIngreso As Boolean = rdoFechaIngreso.Checked
            Dim fechaInicio As Date = dtpFechaInicio.Value
            Dim fechaFin As Date = dtpFechaFin.Value
            Dim estatusIds As String = Filtros(grdStatus)
            Dim DocumentosIds As String = Filtros(grdDocumento)
            Dim folios As String = Filtros(grdFolio)
            Dim emisorIds As String = Filtros(grdEmisor)
            Dim receptorIds As String = Filtros(grdReceptor)
            Dim articuloIds As String = Filtros(grdArticulo)

            dtResultado = objBU.ObtenerDocumentos(porFFacturacion, porFCancelacion, porFIngreso, fechaInicio, fechaFin, estatusIds, DocumentosIds, folios, emisorIds, receptorIds, articuloIds)
            If Not dtResultado Is Nothing Then
                If dtResultado.Rows.Count > 0 Then
                    grdListado.DataSource = dtResultado
                    DisenioGrid()
                    chkSeleccionarTodo.Enabled = True
                    lblFechaUltimaActualización.Text = Date.Now.ToString
                    lblNumRegistros.Text = dtResultado.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
                    pnlParametros.Visible = False
                Else
                    Show_message("Advertencia", "No se encontró información con los filtros seleccionados.")
                End If
            Else
                Show_message("Error", "No fue posible obtener la información.")
            End If
        Catch ex As Exception
            Show_message("Error", ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GvwListado_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles gvwListado.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub GvwListado_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gvwListado.RowCellStyle
        Try
            Dim currentView As GridView
            currentView = sender

            If e.Column.FieldName = "ST" Then
                Dim value As String
                value = currentView.GetRowCellValue(e.RowHandle, "STATUS").ToString()

                Select Case value
                    Case "POR TIMBRAR"
                        e.Appearance.BackColor = Color.Orange
                    Case "ACTIVA"
                        e.Appearance.BackColor = Color.Green
                    Case "CANCELADA"
                        e.Appearance.BackColor = Color.Tomato
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GvwListado_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles gvwListado.CustomColumnDisplayText
        Try
            If e.Column.FieldName = "FCANCELACIÓN" AndAlso e.DisplayText = "01/01/1900" Then
                e.DisplayText = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click, lblCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub grdFiltros_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDocumento.InitializeLayout, grdFolio.InitializeLayout, grdEmisor.InitializeLayout, grdStatus.InitializeLayout, grdReceptor.InitializeLayout, grdArticulo.InitializeLayout
        Grid_diseño(sender)
        Select Case sender.Name
            Case "grdDocumento"
                grdDocumento.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Documento"
            Case "grdFolio"
                grdFolio.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio"
            Case "grdEmisor"
                grdEmisor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Emisor"
            Case "grdReceptor"
                grdReceptor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Receptor"
            Case "grdArticulo"
                grdArticulo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Artículo"
            Case "grdStatus"
                grdStatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Status"
        End Select
    End Sub

    Private Sub grdStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdDocumento.KeyDown, grdFolio.KeyDown, grdEmisor.KeyDown, grdStatus.KeyDown, grdReceptor.KeyDown, grdArticulo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        sender.DeleteSelectedRows(False)
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Dim form As New ComprasPTIngresado_ImportarComplementosForm
        form.ShowDialog()
        BtnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnDevCompras_Click(sender As Object, e As EventArgs) Handles btnDevCompras.Click
        Try
            Dim documentoIds As List(Of Integer)
            Dim strResultado As String = String.Empty
            Dim objBUCPT As New Proveedores.BU.ConsultaComprasPT_BU
            Dim resultadoFinal As String = String.Empty

            If gvwListado.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                documentoIds = ListDocuments()
                If documentoIds.Count = 0 Then
                    Show_message("Advertencia", "Debe seleccionar al menos un registro.")
                ElseIf documentoIds.Count > 1 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Solamente puede seleccionar un documento para realizar la devolución.")
                Else
                    For i As Integer = 0 To gvwListado.RowCount - 1
                        If gvwListado.GetRowCellValue(i, " ") And CBool(gvwListado.GetRowCellValue(i, "COMPLEMENTO")) Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La factura " & gvwListado.GetRowCellValue(i, "FACTURA") & " es de complemento, no se puede realizar la devolución.")
                        ElseIf gvwListado.GetRowCellValue(i, " ") And gvwListado.GetRowCellValue(i, "STATUS") <> "ACTIVA" Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Para realizar la devolución la factura debe estar en estatus ACTIVA.")
                        ElseIf gvwListado.GetRowCellValue(i, " ") And CBool(gvwListado.GetRowCellValue(i, "COMPLEMENTO")) = False Then
                            Dim objForm As New ComprasPTIngresado_DetallesDocumento
                            If Not CheckForm(objForm) Then
                                objForm.emisorRazonSocial = gvwListado.GetRowCellValue(i, "EMISOR")
                                objForm.receptorRazonSocial = gvwListado.GetRowCellValue(i, "RECEPTOR")
                                objForm.receptorRfc = gvwListado.GetRowCellValue(i, "RECEPTOR_RFC")
                                objForm.foloFactura = gvwListado.GetRowCellValue(i, "FACTURA")
                                objForm.statusDocto = gvwListado.GetRowCellValue(i, "STATUS")
                                objForm.emisorRfc = gvwListado.GetRowCellValue(i, "EMISOR_RFC")
                                objForm.fechaIngreso = gvwListado.GetRowCellValue(i, "FENTRADA")
                                objForm.saldoFactura = gvwListado.GetRowCellValue(i, "SALDO FACTURA")
                                objForm.emisorSicyId = gvwListado.GetRowCellValue(i, "EMISORSICYID")
                                objForm.receptorSicyId = gvwListado.GetRowCellValue(i, "RECEPTORSICYID")
                                objForm.emisorSayId = gvwListado.GetRowCellValue(i, "EMISORID")
                                objForm.receptorSayId = gvwListado.GetRowCellValue(i, "RECEPTORID")
                                objForm.esDevolucion = 1
                                objForm.documentoIds = ListDocuments()
                                objForm.ShowDialog()
                            End If
                        End If
                    Next

                    BtnMostrar_Click(Nothing, Nothing)
                End If
            Else
                Show_message("Advertencia", "No hay información.")
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function CancelarDocumentoSICY(ByVal documentoId As Integer) As String
        Try
            Dim objBUFactura As New Facturacion.Negocios.FacturasBU
            objBUFactura.CancelarFacturaProductoTerminadoSICY(documentoId)
            Return "EXITO"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

#End Region

End Class