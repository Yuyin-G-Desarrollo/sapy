Imports System.Text
Imports Tools
Imports System.IO
Imports DevExpress.XtraPrinting

Public Class ImpresionEtiquetasDetallesForm
    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Dim msgExito As New Tools.ExitoForm
    Dim msgError As New Tools.ErroresForm
    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"
    '1 Atados
    '2 Pares
    '3 Lengua
    '4 Granel
    '5 Clientes
    '6 Rastreo
    Private _TipoEtiquetaSeleccionada As Integer
    Public Property TipoEtiquetaSeleccionada() As Integer
        Get
            Return _TipoEtiquetaSeleccionada
        End Get
        Set(ByVal value As Integer)
            _TipoEtiquetaSeleccionada = value
        End Set
    End Property

    Private _Data As DataTable
    Public Property Data() As DataTable
        Get
            Return _Data
        End Get
        Set(ByVal value As DataTable)
            _Data = value
        End Set
    End Property

    Private _Accion As Int16 = 2
    Public Property Accion() As Int16
        Get
            Return _Accion
        End Get
        Set(ByVal value As Int16)
            _Accion = value
        End Set
    End Property

    Private _ImpresoraID As Integer
    Public Property Impresora() As Integer
        Get
            Return _ImpresoraID
        End Get
        Set(ByVal value As Integer)
            _ImpresoraID = value
        End Set
    End Property

    Private _UsuarioID As Integer
    Public Property USuarioID() As Integer
        Get
            Return _UsuarioID
        End Get
        Set(ByVal value As Integer)
            _UsuarioID = value
        End Set
    End Property

    Private _Usuario As String
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property



    Private _ClienteID As Integer
    Public Property ClienteID() As Integer
        Get
            Return _ClienteID
        End Get
        Set(ByVal value As Integer)
            _ClienteID = value
        End Set
    End Property


    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property



    Private _TipoEtiqueta As Integer
    Public Property TipoEtiqueta() As Integer
        Get
            Return _TipoEtiqueta
        End Get
        Set(ByVal value As Integer)
            _TipoEtiqueta = value
        End Set
    End Property

    Private _ColeccionID As Integer
    Public Property ColeccionID() As Integer
        Get
            Return _ColeccionID
        End Get
        Set(ByVal value As Integer)
            _ColeccionID = value
        End Set
    End Property

    Private _LoteInicio As Integer
    Public Property LoteInicio() As Integer
        Get
            Return _LoteInicio
        End Get
        Set(ByVal value As Integer)
            _LoteInicio = value
        End Set
    End Property

    Private _LoteFin As Integer
    Public Property LoteFin() As Integer
        Get
            Return _LoteFin
        End Get
        Set(ByVal value As Integer)
            _LoteFin = value
        End Set
    End Property

    Private _NaveSICYID As Integer
    Public Property NaveSICYID() As Integer
        Get
            Return _NaveSICYID
        End Get
        Set(ByVal value As Integer)
            _NaveSICYID = value
        End Set
    End Property

    Private _AñoPrograma As Integer
    Public Property AñoPrograma() As Integer
        Get
            Return _AñoPrograma
        End Get
        Set(ByVal value As Integer)
            _AñoPrograma = value
        End Set
    End Property

    Private _FechaPrograma As Date
    Public Property FechaPrograma() As Date
        Get
            Return _FechaPrograma
        End Get
        Set(ByVal value As Date)
            _FechaPrograma = value
        End Set
    End Property


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ImpresionEtiquetasDetallesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        If _Accion = 2 Then
            lblPrueba.Visible = True
        Else
            lblPrueba.Visible = False
        End If
        LlenarGrid()

    End Sub

    Private Sub LlenarGrid()
        Dim valor As String = String.Empty

        If Not IsNothing(_Data) Then
            If _Data.Rows.Count > 0 Then
                grdEtiquetasDetalles.DataSource = _Data
                DiseñoGrid(grdVEtiquetasDetalles)
                Dim valida As Boolean = ValidarTabla(_Data)
                If Not valida Then
                    btnClientesPruebaDetallesImprimir.Enabled = False
                    lblImprimir.Enabled = False
                    'grdVEtiquetasDetalles.Columns.ColumnByFieldName("Sel").Visible = False
                    mensajeAdvertencia("Se encontraron columnas vacías y no se podrá generar la impresión, favor de verificar los datos.")
                End If
            End If
        End If

        If _Accion = 2 Then
            btnClientesPruebaDetallesImprimir.Enabled = True
            lblImprimir.Enabled = True
        End If
    End Sub

    Private Function ValidarTabla(ByVal tabla As DataTable) As Boolean
        Dim valida As Boolean = True
        For Each row As DataRow In tabla.Rows
            For Each column As DataColumn In tabla.Columns
                If Not IsNothing(row.Item(column.ColumnName)) Then
                    If row.Item(column.ColumnName).ToString = "" Then
                        'mensajeAdvertencia("El valor de la columna " + column.ColumnName.ToString + " se encuentra vacio y no sera posible imprimir")

                        valida = False
                    End If
                Else
                    'mensajeAdvertencia("El valor de la columna se encuentra vacio y no sera posible imprimir")
                    valida = False
                End If
            Next
        Next

        Return valida
    End Function



    Private Sub DiseñoGrid(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)

        GridView.OptionsView.ColumnAutoWidth = True
        GridView.OptionsView.BestFitMaxRowCount = -1

        If IsNothing(GridView.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            GridView.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler GridView.CustomUnboundColumnData, AddressOf grdVEtiquetasDetalles_CustomUnboundColumnData
            GridView.Columns.Item("#").VisibleIndex = 0
        End If
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(GridView)

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView.Columns
            If col.FieldName <> "Sel" Then
                col.OptionsColumn.AllowEdit = False
            End If
        Next

        GridView.Columns.ColumnByFieldName("codigoEtiqueta").Visible = False


        GridView.Columns.ColumnByFieldName("#").Width = 25
        GridView.Columns.ColumnByFieldName("Sel").Width = 25


        GridView.Columns.ColumnByFieldName("Sel").Caption = " "


        ' GridView.Columns.ColumnByFieldName("Sel").OptionsColumn.AllowEdit = True
        'GridView.BestFitColumns()


    End Sub

    Private Sub grdVEtiquetasDetalles_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVEtiquetasDetalles.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVEtiquetasDetalles.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                'If grdVPeidosMuestrasOP.GetRowCellValue(index, "Estatus") = "CAPTURADO" Then
                grdVEtiquetasDetalles.SetRowCellValue(grdVEtiquetasDetalles.GetVisibleRowHandle(index), "Sel", chboxSeleccionarTodo.Checked)
                ' End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnClientesPruebaImprimir_Click(sender As Object, e As EventArgs) Handles btnClientesPruebaDetallesImprimir.Click

        Dim objNeg As New Negocios.EtiquetasBU
        Dim sb As New StringBuilder
        Dim dtZpl As New DataTable
        Dim dtInformacionPares As New DataTable
        Dim numFilas As Integer

        Try

            Cursor = Cursors.WaitCursor
            If TipoEtiquetaSeleccionada = 3 Then 'Lengua

                numFilas = grdVEtiquetasDetalles.DataRowCount - 1
                For i = 0 To numFilas
                    If grdVEtiquetasDetalles.GetRowCellValue(i, "Sel") Then
                        sb.Append(grdVEtiquetasDetalles.GetRowCellValue(i, "idPar"))
                        sb.Append(",")
                    End If
                Next

                If sb.Length > 0 Then
                    If Accion = 1 Then
                        dtInformacionPares = objNeg.ImpresionEtiquetasPorParLengua(LoteInicio, NaveSICYID, AñoPrograma, sb.ToString, Impresora, _UsuarioID, FechaPrograma, ColeccionID)
                    Else
                        dtInformacionPares = objNeg.ImpresionEtiquetasPorParLenguaPrueba(LoteInicio, NaveSICYID, AñoPrograma, sb.ToString, Impresora, _UsuarioID, FechaPrograma, ColeccionID)
                    End If

                    GeneraArchivosParaImpresion(dtInformacionPares, NaveSICYID, Impresora, LoteInicio, LoteFin)
                Else
                    show_message("Advertencia", "No se han seleccionado pares para imprimir.")
                End If

            ElseIf TipoEtiquetaSeleccionada = 6 Then 'Rastreo

                numFilas = grdVEtiquetasDetalles.DataRowCount - 1
                For i = 0 To numFilas
                    If grdVEtiquetasDetalles.GetRowCellValue(i, "Sel") Then
                        sb.Append(grdVEtiquetasDetalles.GetRowCellValue(i, "idPar"))
                        sb.Append(",")
                    End If
                Next

                If sb.Length > 0 Then
                    If Accion = 1 Then
                        dtInformacionPares = objNeg.ImpresionParesRastreo(sb.ToString, NaveSICYID, AñoPrograma, Impresora, USuarioID, FechaPrograma, ClienteID)
                    Else
                        dtInformacionPares = objNeg.ImpresionParesRastreoPruebas(sb.ToString, NaveSICYID, AñoPrograma, Impresora, USuarioID, FechaPrograma, ClienteID)
                    End If

                    If dtInformacionPares.Rows.Count > 0 Then
                        GeneraArchivosParaImpresion(dtInformacionPares, NaveSICYID, Impresora, LoteInicio, LoteFin)
                        show_message("Exito", "Se ha enviado a imprimir.")
                    Else
                        show_message("Advertencia", "Ocurrio un error al imprimir la información.")
                    End If
                Else
                    show_message("Advertencia", "No se han seleccionado pares para imprimir.")
                End If

            Else

                If grdVEtiquetasDetalles.RowCount > 0 Then
                    numFilas = grdVEtiquetasDetalles.DataRowCount - 1
                    For i = 0 To numFilas
                        If grdVEtiquetasDetalles.GetRowCellValue(i, "Sel") Then
                            sb.Append(grdVEtiquetasDetalles.GetRowCellValue(i, "idPar"))
                            sb.Append(",")
                        End If
                    Next

                    If sb.Length > 0 Then
                        sb.Remove(sb.Length - 1, 1)
                        'CarlosMtz
                        If ClienteID = 103 Or ClienteID = 1230 Then 'BATTA
                            dtZpl = objNeg.ImprimeParesBattaOpcionesCliente(_ImpresoraID, sb.ToString())
                            'Proceso de excel para BATTA
                            CrearExcelBatta(dtZpl)

                            ' CarlosMtz
                            ' PROCESO COPPEL CON IMAGENES JPG IMPRESION DE COLOR
                        ElseIf ClienteID = 763 Or ClienteID = 1181 Then 'COPPEL
                            dtZpl = objNeg.ImprimeParesCoppelOpcionesCliente(_ImpresoraID, sb.ToString())
                            'Proceso de excel para BATTA
                            CrearExcelBatta(dtZpl)

                        Else
                            If _Accion = 1 Then
                                dtZpl = objNeg.ImprimirClientesProduccionDetalles(_ImpresoraID, _UsuarioID, _TipoEtiqueta, sb.ToString, ClienteID)
                            ElseIf _Accion = 2 Then
                                dtZpl = objNeg.ImprimirClientesPruebaDetalles(_ImpresoraID, _UsuarioID, _TipoEtiqueta, sb.ToString, ClienteID)
                            End If
                        End If
                    Else
                        mensajeAdvertencia("No se encontraron registros seleccionados.")
                        Exit Sub
                    End If
                Else
                    mensajeAdvertencia("No se encontraron datos seleccionados.")
                    Exit Sub
                End If

                If ClienteID <> 103 And ClienteID <> 1230 And 'BATTA
                    ClienteID <> 763 And ClienteID <> 1181 Then 'Coppel
                    If Not IsNothing(dtZpl) Then
                        'If dtZpl.Rows.Count > 0 Then
                        If dtZpl.Rows(0).Item("etiqueta") <> String.Empty Then
                            GenerarArchivoEtiquetasTxt(dtZpl)
                            Dim grfs As List(Of String) = dtZpl.AsEnumerable() _
                                                       .Select(Function(r) r.Field(Of String)("foto")) _
                                                       .Distinct() _
                                                       .ToList()
                            GenerarArchivoEtiquetasBat(grfs)
                            ejecutarBat()
                            msgExito.mensaje = "Se ejecutó la impresión correctamente."
                            msgExito.ShowDialog()
                        Else
                            mensajeAdvertencia("La tabla de etiquetas no contiene datos.")
                        End If
                    Else
                        mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                    End If
                Else
                    'If dtZpl.Rows(0).Item(0) > 0 Then
                    '    msgExito.mensaje = "Se ejecutó la impresión correctamente."
                    '    msgExito.ShowDialog()
                    'Else
                    '    mensajeAdvertencia("La consulta de etiquetas realizada no arrojo resultados.")
                    'End If
                End If
            End If

        Catch ex As Exception
            msgError.mensaje = ex.Message + vbCrLf + ex.Source + vbCrLf + ex.StackTrace
            msgError.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub mensajeAdvertencia(ByVal texto As String)
        msgAdvertencia.mensaje = texto
        msgAdvertencia.ShowDialog()
    End Sub

    Private Sub GenerarArchivoEtiquetasTxt(ByVal dt As DataTable)
        Dim ArchivoTxt As String = "C:\SAY\Etiquetas.txt"
        Dim fsTxt As Stream = File.Create(ArchivoTxt)
        Dim swTxt As New System.IO.StreamWriter(fsTxt)
        Dim etiqueta As String = String.Empty
        Try
            For Each row As DataRow In dt.Rows
                If row.Item(0).ToString.Trim.Length > 0 Then
                    etiqueta = String.Empty
                    etiqueta = row.Item(0).ToString.Trim
                    swTxt.WriteLine(etiqueta)
                End If
            Next
            If _Accion = 2 Then
                Dim dtZplResumen As DataTable
                Dim objNeg As New Negocios.EtiquetasBU
                Dim EtiquetaResumen As String = String.Empty
                dtZplResumen = objNeg.ImprimirEtiquetaResumen(_ClienteID, _Cliente, _TipoEtiqueta,
                                                              _ImpresoraID, Usuario, Date.Now.ToString("dd/MM/yyyy HH:mm"))
                If Not IsNothing(dtZplResumen) Then
                    If dtZplResumen.Rows.Count > 0 Then
                        EtiquetaResumen = dtZplResumen.Rows(0).Item(0)
                        swTxt.WriteLine(EtiquetaResumen)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            swTxt.Close()
        End Try
    End Sub

    Private Sub GenerarArchivoEtiquetasBat(ByVal Lista As List(Of String))
        Dim ArchivoBat As String = "C:\SAY\Etiquetas.bat"
        Dim grf As String = String.Empty
        Dim fsBat As Stream = File.Create(ArchivoBat)
        Dim swBat As New System.IO.StreamWriter(fsBat)
        Try
            For Each item As String In Lista
                If item.Trim.Length > 0 Then
                    grf = String.Empty
                    grf = item.ToString.Trim
                    If grf.Contains(".GRF") = True Then
                        swBat.WriteLine(grf)
                    End If
                End If
            Next
            swBat.WriteLine("COPY C:\SAY\ETIQUETAS.TXT C:\PRN")
        Catch ex As Exception
            Throw ex
        Finally
            swBat.Close()
        End Try
    End Sub

    Private Sub ejecutarBat()
        Shell("C:\SAY\Etiquetas.bat")
    End Sub

    Private Sub grdVEtiquetasDetalles_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdVEtiquetasDetalles.RowCellStyle

        Dim Grid As DevExpress.XtraGrid.Views.Grid.GridView = sender
        Dim valor As String = String.Empty
        If e.RowHandle >= 0 Then
            valor = Grid.GetRowCellValue(e.RowHandle, e.Column.FieldName).ToString
            If IsNothing(valor) Or valor = "" Then
                e.Appearance.BackColor = Color.Red
            End If
        End If

    End Sub


    Private Sub GeneraArchivosParaImpresion(ByVal dtEtiquetas As DataTable, ByVal NaveSICYID As Integer, ByVal ImpresoraId As Integer, ByVal LoteInicio As Integer, ByVal LoteFin As Integer)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim EtiquetasAImprimir As String = String.Empty
        Dim LotesSeleccionados As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor
            strStreamW = CrearRutasArchivo(CarpetaUbicacionArchivos, RutaArchivoEtiquetas)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For index As Integer = LoteInicio To LoteFin
                If LotesSeleccionados = String.Empty Then
                    LotesSeleccionados = index
                Else
                    LotesSeleccionados &= "," & index
                End If
            Next

            'Escribir la informacion de las etiquetas en el archivo
            For Each FILA As DataRow In dtEtiquetas.Rows
                EtiquetasAImprimir &= FILA.Item(0)
            Next
            strStreamWriter.WriteLine(EtiquetasAImprimir)
            strStreamWriter.Close()
            'Generar archivo bat para enviar a imprimir las etiquetas
            GenerarArchivoBat(LotesSeleccionados, NaveSICYID, AñoPrograma, ImpresoraId)
            show_message("Exito", "Se ha enviado a imprimir.")
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try

    End Sub

    Private Sub GenerarArchivoBat(ByVal LotesSeleccionados As String, ByVal Nave As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String
        Dim dtArchivo As DataTable
        Dim objBU As New Programacion.Negocios.EtiquetasBU

        Try
            Cursor = Cursors.WaitCursor

            dtArchivo = objBU.ComandosImprimirEtiquetasSAY_V2(LotesSeleccionados, Nave, Año, ImpresoraID)

            If System.IO.Directory.Exists(CarpetaUbicacionArchivos) = False Then
                System.IO.Directory.CreateDirectory(CarpetaUbicacionArchivos)
            End If

            PathArchivo = RutaArchivoBat ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                File.Delete(PathArchivo)
                strStreamW = File.Create(PathArchivo)
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each FILA As DataRow In dtArchivo.Rows
                strStreamWriter.WriteLine(FILA.Item(0))
            Next

            strStreamWriter.Close() ' cerrar
            'Ejecutar el archivo bat
            Shell(RutaArchivoBat)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try
    End Sub

    Private Function CrearRutasArchivo(ByVal Carpeta As String, ByVal Archivo As String) As Stream
        Dim strStreamW As Stream = Nothing

        Try
            If System.IO.Directory.Exists(Carpeta) = False Then
                System.IO.Directory.CreateDirectory(Carpeta)
            End If

            If File.Exists(Archivo) Then
                File.Delete(Archivo)
                strStreamW = File.Create(Archivo)
            Else
                strStreamW = File.Create(Archivo)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return strStreamW

    End Function



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


    Private Sub CrearExcelBatta(ByVal dtZpl As DataTable)
        Dim Directorio As String = "C:\EtiquetasNiceLabel\"
        Dim Archivo As String = "EtiquetaParBatta_Excel.xlsx"
        Dim DirectorioCoppel As String = "C:\EtiquetasNiceLabelCoppel\"
        Dim ArchivoCoppel As String = "EtiquetaParCoppel_Excel.xlsx"
        If Not IsNothing(dtZpl) Then
            If dtZpl.Rows.Count > 0 Then

                If ClienteID = 763 Or ClienteID = 1181 Then
                    grdEtiquetasBatta.DataSource = dtZpl
                    If Not System.IO.Directory.Exists(DirectorioCoppel) Then
                        System.IO.Directory.CreateDirectory(DirectorioCoppel)
                    End If
                    Try
                        Dim exportOptions As New XlsxExportOptionsEx()
                        exportOptions.SheetName = "Hoja1"
                        grdVEtiquetasBatta.ExportToXlsx(DirectorioCoppel & ArchivoCoppel, exportOptions)
                        Tools.Controles.Mensajes_Y_Alertas("EXITO", "Realice la impresión de las etiquetas del archivo " + ArchivoCoppel + "desde Nice Label (Diseño: EtiquetaParCoppel_Excel.nlbl)  ")
                    Catch ex As Exception
                        Tools.Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
                    End Try
                End If

                If ClienteID = 103 Or ClienteID = 1230 Then
                    grdEtiquetasBatta.DataSource = dtZpl
                    If Not System.IO.Directory.Exists(Directorio) Then
                        System.IO.Directory.CreateDirectory(Directorio)
                    End If
                    Try
                        Dim exportOptions As New XlsxExportOptionsEx()
                        exportOptions.SheetName = "Hoja1"
                        grdVEtiquetasBatta.ExportToXlsx(Directorio & Archivo, exportOptions)
                        Tools.Controles.Mensajes_Y_Alertas("EXITO", "Realice la impresión de las etiquetas del archivo EtiquetaParBatta_Excel.xlsx desde Nice Label (Diseño: EtiquetaParBatta_Excel.nlbl)  ")
                    Catch ex As Exception
                        Tools.Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
                    End Try
                End If

            End If
        End If
    End Sub



End Class