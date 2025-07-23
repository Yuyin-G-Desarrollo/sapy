Imports Tools.Controles
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports Tools
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid



Public Class ImpresionEtiquetasCOPPELForm

    Public PedidoCliente As String = String.Empty
    Public PedidoSAY As String = String.Empty
    Public PedidoSICY As String = String.Empty
    Public Programado As String = String.Empty
    Public PedCliente As String = String.Empty
    Public FechaPrograma As Date
    Public NaveSICYId As Integer = 0
    Private objBU As New Programacion.Negocios.EtiquetasBU

    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"
    Dim RutaARchivoCOPPEL As String = Entidades.SesionUsuario.ConfigRutas.PRutaEtiquetas_Coppel '"\\192.168.2.2\Graficos Zebra\COPPEL\COPPEL\"
    Dim DTImpresoras As DataTable

    Private Sub ImpresionEtiquetasCOPPELForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        txtPedidoSAY.Text = PedidoSAY
        txtPedidoSICY.Text = PedidoSICY
        txtPedidoCliente.Text = PedidoCliente
        txtPares.Text = Programado
        CargarImpresoras()
        ObtenerImpresoraAsignada()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub LeerArchivo()
        ''''Se debe instalar el driver para poder importar archivos http://www.microsoft.com/es-es/download/details.aspx?id=23734
        Dim valoresMal As Int16 = 0
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim dtExcel As New DataTable

        openFileDialog1.InitialDirectory = "c:\"
        'openFileDialog1.Filter = "Archivos de excel (*.xlsx)|"
        openFileDialog1.Filter = "Archivos de excel (*.xls)|"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                'myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    dtExcel = GetDataExcel(openFileDialog1.FileName, PedidoCliente & "_")



                    If dtExcel.Rows.Count > 0 Then

                        'Validar que el archivo cooresponde con el pedido seleccionado
                        '--------------------------------------------------------------

                        'De la columna Dato6 tomar los primeros 5 caracteres y el 7 
                        'Concatenar ambas cadenas para formar el codigo rapido
                        '--------------------------------------------------------------
                        'El archivo de salida debe de contener las siguiente columnas
                        'Cantidad, Precio, CodigoBarras, Codigo, Familia, Bodega, Talla, Descripcion , Pedido, Tipo, Modelo/ Color
                        'Armar el nuevo datatable con la informacoin leida

                        'SELECT prod.ModeloSICY, prod.Piel, prod.Color, prod.PielColor, prod.PielColor, prod.CodigoSicy
                        'FROM Programacion.CodigosClientes cc
                        'inner join Programacion.vProductoEstilos_Completo prod on cc.cocl_productoestiloid = prod.ProductoEstiloId
                        'where cc.cocl_codigorapidocliente ='806192'  
                        'and cc.cocl_clienteid =763
                        'and cc.cocl_tallacliente ='22'
                        'and prod.pres_activo =1


                        '-------------------------------------------------------------------------

                        Dim dtEtiquwetasCoppel As New DataTable


                    Else
                        show_message("Advertencia", "No se encontraron datos en el archivo de Excel")
                    End If
                End If
            Catch Ex As Exception
                MessageBox.Show("No se puede leer el archivo en disco. Error original: " & Ex.Message)
                Exit Sub
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try

        End If



        Me.Cursor = Cursors.Default
    End Sub

    Private Function GetDataExcel(ByVal fileName As String, ByVal source As String) As DataTable

        Try
            Using cnn As New OleDbConnection( _
                   "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                   "Extended Properties='Excel 12.0 Xml;HDR=Yes';" & _
                   "Data Source=" + fileName)

                Dim sql As String = _
                    String.Format("SELECT * FROM [{0}]", source)

                Dim da As New OleDbDataAdapter(sql, cnn)

                Dim dt As New DataTable()

                da.Fill(dt)

                Return dt

            End Using

        Catch ex As Exception

            Throw

        End Try

    End Function



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

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        Dim dtInformacionArchivoExcel As DataTable
        Dim PedidoClienteArchivo As String = String.Empty
        Dim dtInformacionEtiquetas As New DataTable
        Dim dtInformacionCodigoModelo As New DataTable
        Dim dtEstiloCoppel As New DataTable
        Dim dtParesPorPrograma As New DataTable
        Dim Pares As Integer = 0

        Dim ModeloColor As String
        Dim TallaIni As String
        Dim TallaFin As String
        Dim ModeloColorAux As String = String.Empty
        Dim TallaIniAux As String = String.Empty
        Dim TallaFinAux As String = String.Empty
        Dim renglon As Integer = 0
        Dim Talla As String

        dtInformacionEtiquetas.Columns.Add("Cantidad")
        dtInformacionEtiquetas.Columns.Add("Precio")
        dtInformacionEtiquetas.Columns.Add("CodigoBarras")
        dtInformacionEtiquetas.Columns.Add("Codigo")
        dtInformacionEtiquetas.Columns.Add("Familia")
        dtInformacionEtiquetas.Columns.Add("Bodega")
        dtInformacionEtiquetas.Columns.Add("Talla")
        dtInformacionEtiquetas.Columns.Add("Descripcion")
        dtInformacionEtiquetas.Columns.Add("Pedido")
        dtInformacionEtiquetas.Columns.Add("Tipo")
        dtInformacionEtiquetas.Columns.Add("ModeloColor")
        dtInformacionEtiquetas.Columns.Add("Color")
        dtInformacionEtiquetas.Columns.Add("IdCodigo")


        ofArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofArchivo.Filter = "XLS, XLSX|*.xls;*.xlsx"
        ofArchivo.FilterIndex = 3
        ofArchivo.ShowDialog()

        If ofArchivo.FileName = "" Then
            'show_message("Advertencia","Es necesario seleccionar un archivo de excel")
            Return
        End If

        txtArchivo.Text = ofArchivo.FileName
        Dim Color As String = String.Empty
        Dim IdCodigo As String = String.Empty

        dtInformacionArchivoExcel = LeerExcel(txtArchivo.Text)
        If dtInformacionArchivoExcel.Rows.Count > 0 Then
            'Validar pedido cliente

            PedidoClienteArchivo = dtInformacionArchivoExcel.AsEnumerable().Select(Function(x) x.Item(12)).FirstOrDefault()

            If PedidoClienteArchivo <> PedidoCliente Then 'PedidoCliente
                show_message("Advertencia", "El archivo no corresponde con el pedido seleccionado.")
                Return
            Else

                dtParesPorPrograma = objBU.ObtenerParesPorCodigo(FechaPrograma, NaveSICYId, PedidoSICY)

                'CarlosMtz 18-09-2020 (Cambio por mas de una partida en pedidos Coppel) (251-291)
                For Each Fila As DataRow In dtInformacionArchivoExcel.Rows

                    dtEstiloCoppel = objBU.ObtenerEstiloCOPPEL(ObtenerCodigoRapido(Fila.Item(4)), Fila.Item(8))
                    If dtEstiloCoppel.Rows.Count > 0 Then
                        Color = dtEstiloCoppel.Rows(0).Item("ColorCorto").ToString
                        IdCodigo = dtEstiloCoppel.Rows(0).Item("IdCodigo").ToString
                    Else
                        Color = String.Empty
                        IdCodigo = String.Empty
                    End If

                    Pares = dtParesPorPrograma.AsEnumerable().Where(Function(x) x.Item("idtblProducto") = IdCodigo And x.Item("Calce") = Fila.Item(8).ToString.Trim()).Select(Function(y) y.Item("Pares")).FirstOrDefault()

                    ModeloColorAux = dtInformacionArchivoExcel.Rows(renglon).Item("DATO6")
                    renglon += 1

                    Talla = dtInformacionArchivoExcel.AsEnumerable().Where(Function(y) y.Item("DATO6").ToString = ModeloColorAux).Select(Function(X) X.Item("DATO11")).FirstOrDefault()

                    ModeloColor = ModeloColorAux.Substring(0, 5) + ModeloColorAux.Substring(6, 1)

                    dtInformacionCodigoModelo = objBU.CoosultaCodigoRaidoCoppelTalla(ModeloColor, Talla)

                    dtInformacionEtiquetas.Rows.Add(Pares,
                                                    Fila.Item(2).ToString.Trim,
                                                    Fila.Item(4).ToString.Trim,
                                                    Fila.Item(5).ToString.Trim,
                                                    Fila.Item(6).ToString.Trim,
                                                    Fila.Item(7).ToString.Trim,
                                                    Fila.Item(8).ToString.Trim,
                                                    Fila.Item(11).ToString.Trim,
                                                    Fila.Item(12).ToString.Trim,
                                                    Fila.Item(13).ToString.Trim,
                                                    dtInformacionCodigoModelo.Rows(0).Item("ModeloColor"),
                                                    Color,
                                                    IdCodigo)


                Next

                CargarGridImpresionEtiquetas(dtInformacionEtiquetas)

                'CarlosMtz 18-09-2020 (Cambio por mas de una partida en pedidos Coppel) (294-323)
                'For Each Fila As DataRow In dtInformacionArchivoExcel.Rows

                '    dtEstiloCoppel = objBU.ObtenerEstiloCOPPEL(ObtenerCodigoRapido(Fila.Item(4)), Fila.Item(8))
                '    If dtEstiloCoppel.Rows.Count > 0 Then
                '        Color = dtEstiloCoppel.Rows(0).Item("ColorCorto").ToString
                '        IdCodigo = dtEstiloCoppel.Rows(0).Item("IdCodigo").ToString
                '    Else
                '        Color = String.Empty
                '        IdCodigo = String.Empty
                '    End If

                '    Pares = dtParesPorPrograma.AsEnumerable().Where(Function(x) x.Item("idtblProducto") = IdCodigo And x.Item("Calce") = Fila.Item(8).ToString.Trim()).Select(Function(y) y.Item("Pares")).FirstOrDefault()

                '    dtInformacionEtiquetas.Rows.Add(Pares, Fila.Item(2).ToString.Trim, Fila.Item(4).ToString.Trim, Fila.Item(5).ToString.Trim, Fila.Item(6).ToString.Trim, Fila.Item(7).ToString.Trim, Fila.Item(8).ToString.Trim, Fila.Item(11).ToString.Trim, Fila.Item(12).ToString.Trim, Fila.Item(13).ToString.Trim, "", Color, IdCodigo)
                'Next
                'CargarGridImpresionEtiquetas(dtInformacionEtiquetas)
                'ModeloColor = gdvImpresionEtiquetas.GetFocusedRowCellValue("CodigoBarras").ToString '.Substring(0, 5)
                'ModeloColor = ModeloColor.Substring(0, 5) + ModeloColor.Substring(6, 1)
                ''''TallaIni = gdvImpresionEtiquetas.GetRowCellValue(0, "Talla").ToString
                'TallaIni = dtInformacionEtiquetas.AsEnumerable().Select(Function(X) X.Item("Talla")).Min.ToString()
                'TallaFin = dtInformacionEtiquetas.AsEnumerable().Select(Function(X) X.Item("Talla")).Max.ToString()
                ''''TallaFin = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.RowCount - 1, "Talla").ToString


                'dtInformacionCodigoModelo = objBU.CoosultaCodigoRaidoCoppel(ModeloColor, TallaIni, TallaFin) 'Talla

                'For fila2 As Integer = 0 To dtInformacionCodigoModelo.Rows.Count - 1

                '    gdvImpresionEtiquetas.SetRowCellValue(fila2, "ModeloColor", dtInformacionCodigoModelo.Rows(fila2).Item(6))
                'Next

                txtPedCliente.Text() = PedidoCliente


                DiseñoGrid()

            End If


        End If


    End Sub

    Private Function LeerExcel(ByVal RutaArchivo As String) As DataTable
        Dim dtArchivoExcel As DataTable
        Dim NombreArchivo As String
        NombreArchivo = PedidoCliente
        dtArchivoExcel = Tools.Excel.LlenarTablaExcelListaTablas("", RutaArchivo, NombreArchivo)
        Return dtArchivoExcel
    End Function

    Private Sub CargarGridImpresionEtiquetas(ByVal dtDatos As DataTable)
        grdImpresionEtiquetas.DataSource = Nothing
        grdImpresionEtiquetas.DataSource = dtDatos

    End Sub

    Public Sub DiseñoGrid()
        gdvImpresionEtiquetas.BestFitColumns()

        'Esconde idColumnas
        'gdvImpresionEtiquetas.Columns(" ").Visible = False

        gdvImpresionEtiquetas.OptionsView.EnableAppearanceEvenRow = True
        gdvImpresionEtiquetas.OptionsView.EnableAppearanceOddRow = True

        gdvImpresionEtiquetas.Appearance.EvenRow.BackColor = Color.White
        gdvImpresionEtiquetas.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        gdvImpresionEtiquetas.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        gdvImpresionEtiquetas.Appearance.FocusedRow.ForeColor = Color.White

        'gdvImpresionEtiquetas.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        'gdvImpresionEtiquetas.Appearance.FocusedCell.ForeColor = Color.White

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        gdvImpresionEtiquetas.Columns("Cantidad").OptionsColumn.AllowEdit = True
        gdvImpresionEtiquetas.Columns("Precio").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("CodigoBarras").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("Codigo").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("Familia").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("Bodega").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("Talla").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("Descripcion").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("Pedido").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("Tipo").OptionsColumn.AllowEdit = False
        gdvImpresionEtiquetas.Columns("ModeloColor").OptionsColumn.AllowEdit = False

        'acomoda el nombre de la columna centrado
        gdvImpresionEtiquetas.Columns("Cantidad").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("Precio").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("CodigoBarras").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("Codigo").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("Familia").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("Bodega").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("Talla").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("Descripcion").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("Pedido").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gdvImpresionEtiquetas.Columns("ModeloColor").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        ' ''Para que haga la busqueda por lo que contiene        
        gdvImpresionEtiquetas.Columns("Cantidad").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("Precio").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("CodigoBarras").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("Codigo").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("Familia").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("Bodega").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("Talla").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("Descripcion").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("Pedido").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gdvImpresionEtiquetas.Columns("ModeloColor").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        gdvImpresionEtiquetas.OptionsView.ShowFooter = GroupFooterShowMode.Hidden
        If IsNothing(gdvImpresionEtiquetas.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
            gdvImpresionEtiquetas.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
        End If

        gdvImpresionEtiquetas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


    End Sub

    Public Function GuardarEncabezadoImpresionEtiquetas(ByVal PedidoCliente As String, ByVal Usuario As String, ByVal PedidoSICY As Integer, ByVal Pares As Integer) As Integer
        Dim idarchivoResultado As Integer

        idarchivoResultado = objBU.GuardarEncabezadoImpresionEtiquetasCoppel(PedidoCliente, Usuario, PedidoSICY, Pares)

        Return idarchivoResultado


    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim IdArchivo As Integer = 0
        'Entidad que recupera la sesion de usuario (Nombre de usuario)
        Dim NumeroFilas As Integer = 0
        Dim Cantidad As Integer = 0
        Dim Precio As String = String.Empty
        Dim CodigoBarras As String
        Dim Codigo As String
        Dim Familia As String
        Dim Bodega As String
        Dim Talla As String
        Dim Descripcion As String
        Dim Pedido As String
        Dim Tipo As String
        Dim ModeloColor As String
        Dim Color As String
        Dim IdCodigo As String = String.Empty
        Dim dtZPL As New DataTable
        Dim TotalPares As Integer = 0
        Dim Contador As Integer = 0

        Try

            Cursor = Cursors.WaitCursor

            IdArchivo = GuardarEncabezadoImpresionEtiquetas(txtPedCliente.Text, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, txtPedidoSICY.Text, txtPares.Text)

            NumeroFilas = gdvImpresionEtiquetas.DataRowCount - 1

            For index As Integer = 0 To NumeroFilas Step 1

                Cantidad = CInt(gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Cantidad"))
                Precio = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Precio")
                CodigoBarras = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "CodigoBarras")
                Codigo = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Codigo")
                Familia = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Familia")
                Bodega = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Bodega")
                Talla = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Talla")
                Descripcion = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Descripcion")
                Pedido = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Pedido")
                Tipo = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Tipo")
                ModeloColor = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "ModeloColor")
                'ModeloColor = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Color")
                Color = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "Color")
                IdCodigo = gdvImpresionEtiquetas.GetRowCellValue(gdvImpresionEtiquetas.GetVisibleRowHandle(index), "IdCodigo")
                objBU.GuardaDetalleImpresionEtiquetaCoppel(IdArchivo, Cantidad, Precio, CodigoBarras, Codigo, Familia, Bodega, Talla, Descripcion, Pedido, Tipo, ModeloColor, Color, IdCodigo)

                Contador += 1
                TotalPares += Cantidad
            Next

            If Contador > 0 Then
                If IdArchivo <> 0 Then
                    dtZPL = objBU.ImprimirEtiquetasCOPPEL(IdArchivo)
                    If dtZPL.Rows.Count > 0 Then
                        GeneraArchivosParaImpresion(dtZPL)
                        File.Copy(txtArchivo.Text.Trim, RutaARchivoCOPPEL & Path.GetFileName(txtArchivo.Text.Trim()), True)
                        GuardaBitacoraEtiquetaLotes(CDate(FechaPrograma).Year.ToString, NaveSICYId, CDate(FechaPrograma), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Date.Now.ToString, PedCliente, TotalPares)
                        'show_message("Exito", "Archivo guardado correctamente.")
                    Else
                        show_message("Advertencia", "No se encontro información para imprimir.")
                    End If
                End If
            End If
            Cursor = Cursors.Default
            'Me.Close()

        Catch ex As Exception
            show_message("Advertencia", "No se guardaron correctamente los datos.")
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub GuardaBitacoraEtiquetaLotes(ByVal año As Integer, ByVal nave As Integer, ByVal fechaprograma As Date, ByVal usuarioid As Int16, ByVal fechaimpresion As DateTime, ByVal pedidocliente As String, ByVal pares As Integer)
        'Dim resultadoBitacoraEtiquetasLotes As Integer

        Try
            objBU.GuardaBitacoraEtiquetaLotes(año, nave, fechaprograma, usuarioid, fechaimpresion, pedidocliente, pares)
        Catch ex As Exception
            show_message("Advertencia", "No se guardaron correctamente los datos.")
        End Try

    End Sub

    Private Function ObtenerCodigoRapido(ByVal CodigoCOPPEL As String) As String
        Dim Resultado As String = String.Empty
        Try
            Resultado = CodigoCOPPEL.Substring(0, 5)
            Resultado = Resultado + CodigoCOPPEL.Substring(6, 1)
        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    Private Sub GeneraArchivosParaImpresion(ByVal dtEtiquetas As DataTable)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim EtiquetasAImprimir As String = String.Empty
        Dim LotesSeleccionados As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor
            strStreamW = CrearRutasArchivo(CarpetaUbicacionArchivos, RutaArchivoEtiquetas)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            'Escribir la informacion de las etiquetas en el archivo
            For Each FILA As DataRow In dtEtiquetas.Rows
                EtiquetasAImprimir &= FILA.Item(0)
            Next
            strStreamWriter.WriteLine(EtiquetasAImprimir)
            strStreamWriter.Close()
            'Generar archivo bat para enviar a imprimir las etiquetas
            GenerarArchivoBat(LotesSeleccionados)
            show_message("Exito", "Se ha enviado a imprimir las etiquetas.")
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try

    End Sub

    Private Sub GenerarArchivoBat(ByVal LotesSeleccionados As String)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String
        Dim dtArchivo As DataTable

        Try
            Cursor = Cursors.WaitCursor
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
            If cmbImpresoras.SelectedValue = 2 Then
                strStreamWriter.WriteLine("net use LPT1: \\PROGRAMACION2\PROGRAMACION3 /persistent:yes ")
            End If
            strStreamWriter.WriteLine("COPY C:\SAY\ETIQUETAS.TXT C:\PRN")
            strStreamWriter.Close() ' cerrar
            'Ejecutar el archivo bat
            Shell(RutaArchivoBat)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
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

    Private Sub CargarImpresoras()
        DTImpresoras = objBU.ListaImpresoras()
        cmbImpresoras.DataSource = DTImpresoras
        cmbImpresoras.DisplayMember = "Nombre"
        cmbImpresoras.ValueMember = "IdImpresora"
    End Sub

    Private Sub ObtenerImpresoraAsignada()
        Dim dtInformacionImpresora As DataTable
        Dim NombreImpresora As String = String.Empty
        Dim ImpresoraId As Integer = 0
        Dim Index As Integer = 0

        Try
            dtInformacionImpresora = objBU.ConsultarImpresoraEquipo(My.Computer.Name)

            If IsNothing(dtInformacionImpresora) = False Then
                If dtInformacionImpresora.Rows.Count > 0 Then
                    ImpresoraId = dtInformacionImpresora.Rows(0).Item(0)
                    NombreImpresora = dtInformacionImpresora.Rows(0).Item(1)
                    If ImpresoraId > 0 Then
                        Index = cmbImpresoras.FindString(NombreImpresora)
                        cmbImpresoras.SelectedIndex = Index
                    End If
                End If
            End If
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al cargar la impresora por default.")
        End Try
    End Sub

End Class