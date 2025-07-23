Imports System.Text.RegularExpressions
Imports DevExpress.Utils.Extensions
Imports Infragistics.Documents.Excel


Public Class ReportesExcel

    Dim regexNumerosYLetras As New Regex("^(?=.*\d)[a-zA-Z0-9]+$")  '' https://regex101.com/ página para revisar las expresiones regulares.
    Dim regexNumerosYDecimales As New Regex("^-?\d+(\.\d{1,2})?$")
    Dim regexCorrida As New Regex("^[0-9-½]+$")



#Region "Reportes Generales"

    ''' <summary>
    ''' Genera un reporte de excel con el formato general de Yuyin con base a la tabla que se le pase. 
    ''' </summary>
    ''' <param name="configuracionInformacionReporte"></param>
    ''' <param name="configuracionArchivoExcel"></param>
    ''' <param name="configuracionHojaExcel"></param>
    ''' <param name="configuracionEncabezado"></param>
    ''' <param name="configuracionImpresion"></param>
    Public Sub GenerarReporteGeneral(ByVal configuracionInformacionReporte As ConfiguracionInformacionReporte,
                                        ByVal configuracionArchivoExcel As ConfiguracionArchivoExcel,
                                        ByVal configuracionHojaExcel As ConfiguracionHojaExcel,
                                        Optional ByVal configuracionEncabezado As ConfiguracionEncabezado = Nothing,
                                        Optional ByVal configuracionImpresion As ConfiguracionImpresion = Nothing)
        Try
            If VerificarArchivoAbierto(configuracionArchivoExcel) Then
                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACIONES GENERALES -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''

                Dim ColorBordes As Color = Color.FromArgb(128, 128, 128)
                Dim ColorTablas As System.Drawing.Color = Color.FromArgb(217, 217, 217)
                Dim contadorNombreColumnas As Integer = 1
                Dim contadorTamañoColumnas As Integer = 0


                '' Asignamos el formato del archivo de excel (xlsx).
                configuracionArchivoExcel.ArchivoExcel.SetCurrentFormat(configuracionArchivoExcel.ExtensionArchivo)
                If configuracionHojaExcel.NombreHoja.Length > 30 Then
                    configuracionHojaExcel.HojaExcel = configuracionArchivoExcel.ArchivoExcel.Worksheets.Add(configuracionHojaExcel.NombreHoja.Substring(0, 30)) 'Asignamos nombre a la hoja (PED. 6174.) '' Debemos limitar a 30 caracteres el nombre de la hoja que es el límite de la misma.
                Else
                    configuracionHojaExcel.HojaExcel = configuracionArchivoExcel.ArchivoExcel.Worksheets.Add(configuracionHojaExcel.NombreHoja)
                End If



                If configuracionHojaExcel.OcultarCuadricula = True Then
                    configuracionHojaExcel.HojaExcel.DisplayOptions.GridlineColor = Color.Transparent 'Quitamos la cuadricula de la hoja de excel 
                End If

                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACIONES GENERALES -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''





                '' ------------------------------------------------------------------------------------ ''
                '' -------------------------------- ENCABEZADO REPORTE -------------------------------- ''
                '' ------------------------------------------------------------------------------------ ''

                Dim totalColumnasDT As Integer = configuracionInformacionReporte.InformacionReporte.Columns.Count

                Dim MergedEncabezadoLogo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, 1, 2, 2) 'B2:C3. Logo Yuyin
                Dim MergedEncabezadoNombreReporte As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, 3, 3, totalColumnasDT - 2) 'D2:N4. Nombre del reporte
                Dim MergedArea As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(3, 1, 3, 2) 'A4:B4. Área

                Dim MergedVersionDocumento As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, totalColumnasDT - 1, 1, totalColumnasDT) 'O1:P1.  Versión del documento
                Dim MergedMes As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(2, totalColumnasDT - 1, 2, totalColumnasDT) 'O2:P2.
                Dim MergedResponsable As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(3, totalColumnasDT - 1, 3, totalColumnasDT) 'O3:OP3.   Responsable


                '' Configuración para fijar filas.
                configuracionHojaExcel.HojaExcel.DisplayOptions.PanesAreFrozen = configuracionHojaExcel.FijarFila
                configuracionHojaExcel.HojaExcel.DisplayOptions.FrozenPaneSettings.FrozenRows = configuracionHojaExcel.NumeroFilaFija

                '' ------------------------------------------------------------------------------------ ''
                '' -------------------------------- ENCABEZADO REPORTE -------------------------------- ''
                '' ------------------------------------------------------------------------------------ ''





                '' ------------------------------------------------------------------------ ''
                '' -------------------------------- IMAGEN -------------------------------- ''
                '' ------------------------------------------------------------------------ ''

                'Dim ImagenLogoYuyin As System.Drawing.Image = Image.FromFile("\\192.168.2.156\Graficos Zebra\LogoGrupoYuyin.png") 'Obtenemos el logo de yuyin 'Image.FromFile("C:\\Users\\SISTEMAS6\\Pictures\\Logo_Yuyin.png") '
                Dim ImagenLogoYuyin As System.Drawing.Image = Image.FromFile("\\192.168.2.156\Graficos Zebra\Logo_Yuyin.png")

                Dim ImagenHojaExcel As WorksheetImage = New WorksheetImage(ImagenLogoYuyin)
                ImagenHojaExcel.TopLeftCornerCell = configuracionHojaExcel.HojaExcel.Rows.Item(1).Cells.Item(1)    '' Delimitamos los margenes y la ubicacion de la imagen
                ImagenHojaExcel.TopLeftCornerPosition = New PointF(5.0F, 20.0F)            '' Ampliación de la imagen
                ImagenHojaExcel.BottomRightCornerCell = configuracionHojaExcel.HojaExcel.Rows.Item(3).Cells.Item(3)
                ImagenHojaExcel.BottomRightCornerPosition = New PointF(60.0F, 70.0F)
                ImagenHojaExcel.Outline = Nothing   '' Quitamos el contorno de la imagen.

                configuracionHojaExcel.HojaExcel.Shapes.Add(ImagenHojaExcel) 'Añadimos la imagen (Los archivos con formato WorksheetImage son considerados formas(shapes))


                '' Se agrega el ajuste de texto para no marcar errores con la imagen.
                MergedEncabezadoNombreReporte.CellFormat.WrapText = ExcelDefaultableBoolean.True

                '' ------------------------------------------------------------------------ ''
                '' -------------------------------- IMAGEN -------------------------------- ''
                '' ------------------------------------------------------------------------ ''





                '' --------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONTENIDO DEL REPORTE -------------------------------- ''
                '' --------------------------------------------------------------------------------------- ''

                ''  Inicio insercion datos del reporte
                Dim FilaReporte As Integer = 6
                Dim NumRegistros = 0

                For i As Int16 = 0 To configuracionInformacionReporte.InformacionReporte.Rows.Count - 1 Step 1 'Asignamos el número de la fila de excel donde se insertarán los datos del reporte (5)

                    Dim ColumnaReporte As Integer = 1  '' Esta variable es donde inicia la tabla (como existe un margen debemos tomar eso en cuenta).

                    configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Height = 315   '1 px en Excel equivalen a 15 px en visual (Filas)

                    For j As Int16 = 0 To configuracionInformacionReporte.InformacionReporte.Columns.Count - 1 Step 1 'Asignamos el número de la columna de excel donde se insertarán los datos del reporte (1)
                        Dim Valor As Object = configuracionInformacionReporte.InformacionReporte.Rows(i).Item(j)

                        If Not IsDBNull(Valor) AndAlso Valor IsNot Nothing AndAlso TypeOf Valor Is System.Drawing.Image Then
                            ' Es una imagen válida
                            configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Height = 1050 ' (70 pixeles)
                            configuracionHojaExcel.HojaExcel.Columns.Item(ColumnaReporte).Width = 4500 ' (120 pixeles)

                            FormatoContenidoReporteImagen(
                                            configuracionHojaExcel,
                                            configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                            Valor,
                                            Color.White,
                                            ColorBordes
                                        )
                        Else
                            ' Convertimos DBNull y otros a string seguro
                            Dim textoSeguro As String = If(IsDBNull(Valor) OrElse Valor Is Nothing, String.Empty, Valor.ToString())

                            FormatoContenidoReporteTexto(
                                            "Celda",
                                            configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                            textoSeguro,
                                            "",
                                            200,
                                            Color.White,
                                            ColorBordes
                                        )
                        End If

                        ''Dim Valor As Object = configuracionInformacionReporte.InformacionReporte.Rows(i).Item(j)

                        ''If TypeOf Valor Is System.Drawing.Image Then
                        ''    configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Height = 1050 ' (70 pixeles)
                        ''    configuracionHojaExcel.HojaExcel.Columns.Item(ColumnaReporte).Width = 4500 ' (120 pixeles)

                        ''    FormatoContenidoReporteImagen(
                        ''                configuracionHojaExcel,
                        ''                configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                        ''                Valor,
                        ''                Color.White,
                        ''                ColorBordes
                        ''            )
                        ''Else
                        ''    FormatoContenidoReporteTexto(
                        ''               "Celda",
                        ''               configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                        ''               Valor,
                        ''               200,
                        ''               Color.White,
                        ''               ColorBordes
                        ''           )
                        ''End If

                        ColumnaReporte += 1
                    Next

                    FilaReporte += 1
                Next


                If configuracionInformacionReporte.MostrarTotalGeneral = True Then
                    '' Agregamos la barra gris del pie del reporte.
                    Dim MergedPiePagina As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 1, FilaReporte, totalColumnasDT - 1) 'B*:O*. Barra del pie de reporte.
                    FormatoCeldasCombinadasReporte(MergedPiePagina, "TOTAL GENERAL ", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Right, ColorTablas, ColorBordes, CellBorderLineStyle.Default)

                    '' Agregamos el cuadro con el total de pares a producir.
                    Dim totalParesPedido = (From a In configuracionInformacionReporte.InformacionReporte.AsEnumerable() Select a.Field(Of Double)("Total")).Sum()

                    FormatoContenidoReporteTexto("Celda", configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(15), totalParesPedido, "", 240, ColorTablas, ColorBordes)
                End If

                '' --------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONTENIDO DEL REPORTE -------------------------------- ''
                '' --------------------------------------------------------------------------------------- ''





                '' ----------------------------------------------------------------------------------------- ''
                '' -------------------------------- DIMENSIONES DEL REPORTE -------------------------------- ''
                '' ----------------------------------------------------------------------------------------- ''
                '' 1 px en Excel equivalen a 15 en visual (Filas)
                '' 1 px en Excel equivalen a 36.75 en visual (Columnas)

                Dim totalColumnasReporte = configuracionInformacionReporte.InformacionReporte.Columns.Count

                FormatoCeldasCombinadasReporte(MergedEncabezadoLogo, "", 100, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoNombreReporte, configuracionEncabezado.NombreReporte, 300, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedArea, configuracionEncabezado.NombreArea, 200, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedVersionDocumento, configuracionEncabezado.NombreVersionDocumento, 200, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Left, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedMes, configuracionEncabezado.Mes, 200, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Left, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedResponsable, configuracionEncabezado.NombreResponsable, 200, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Left, Color.White, ColorBordes, CellBorderLineStyle.Medium)


                '' Alto de las filas encabezado.
                configuracionHojaExcel.HojaExcel.Rows(0).Height = 150  '' Espacio (10 px)
                configuracionHojaExcel.HojaExcel.Rows(1).Height = 450
                configuracionHojaExcel.HojaExcel.Rows(2).Height = 450
                configuracionHojaExcel.HojaExcel.Rows(3).Height = 450



                '' Damos formato a los nombres de las columnas.
                While contadorTamañoColumnas < totalColumnasDT
                    Dim nombreColumna As String = configuracionInformacionReporte.InformacionReporte.Columns(contadorTamañoColumnas).Caption

                    FormatoContenidoReporteTexto("Titulo", configuracionHojaExcel.HojaExcel.Rows.Item(5).Cells.Item(contadorNombreColumnas), nombreColumna, "", 200, ColorTablas, ColorBordes)

                    contadorTamañoColumnas += 1
                    contadorNombreColumnas += 1
                End While

                contadorTamañoColumnas = 0
                ''While contadorTamañoColumnas < (totalColumnasDT + 1)
                While contadorTamañoColumnas < configuracionInformacionReporte.TamañoColumnas.Count

                    configuracionHojaExcel.HojaExcel.Columns(contadorTamañoColumnas).Width = (configuracionInformacionReporte.TamañoColumnas(contadorTamañoColumnas) * 36.75)

                    contadorTamañoColumnas += 1
                End While

                '' ----------------------------------------------------------------------------------------- ''
                '' -------------------------------- DIMENSIONES DEL REPORTE -------------------------------- ''
                '' ----------------------------------------------------------------------------------------- ''





                '' -------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACION DE IMPRESIÓN -------------------------------- ''
                '' -------------------------------------------------------------------------------------------- ''

                ConfigurarImpresionReporte(configuracionInformacionReporte, configuracionArchivoExcel, configuracionHojaExcel, FilaReporte, configuracionImpresion)

                '' -------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACION DE IMPRESIÓN -------------------------------- ''
                '' -------------------------------------------------------------------------------------------- ''
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Hubo un error al exportar el reporte: " + ex.Message)
        End Try
    End Sub

#End Region



#Region "Reportes Especiales"

    Public Sub GenerarReporteListaPreciosEspeciales(ByVal configuracionInformacionReporte As ConfiguracionInformacionReporte,
                                                    ByVal configuracionArchivoExcel As ConfiguracionArchivoExcel,
                                                    ByVal configuracionHojaExcel As ConfiguracionHojaExcel,
                                                    Optional ByVal configuracionEncabezadoListasPrecios As ConfiguracionEncabezadoListasPrecios = Nothing,
                                                    Optional ByVal configuracionImpresion As ConfiguracionImpresion = Nothing)
        Try
            If VerificarArchivoAbierto(configuracionArchivoExcel) Then
                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACIONES GENERALES -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''

                Dim ColorBordes As Color = Color.FromArgb(128, 128, 128)
                Dim ColorTablas As System.Drawing.Color = Color.FromArgb(217, 217, 217)
                Dim contadorNombreColumnas As Integer = 1
                Dim contadorTamañoColumnas As Integer = 0


                '' Asignamos el formato del archivo de excel (xlsx).
                configuracionArchivoExcel.ArchivoExcel.SetCurrentFormat(configuracionArchivoExcel.ExtensionArchivo)
                configuracionHojaExcel.HojaExcel = configuracionArchivoExcel.ArchivoExcel.Worksheets.Add(configuracionHojaExcel.NombreHoja) 'Asignamos nombre a la hoja (PED. 6174.)


                If configuracionHojaExcel.OcultarCuadricula = True Then
                    configuracionHojaExcel.HojaExcel.DisplayOptions.GridlineColor = Color.Transparent 'Quitamos la cuadricula de la hoja de excel 
                End If

                '' Bloqueamos la edición de la hoja y el archivo de Excel.
                configuracionArchivoExcel.ArchivoExcel.Protected = True
                configuracionHojaExcel.HojaExcel.Protected = True
                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACIONES GENERALES -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''





                '' ------------------------------------------------------------------------------------ ''
                '' -------------------------------- ENCABEZADO REPORTE -------------------------------- ''
                '' ------------------------------------------------------------------------------------ ''

                Dim totalColumnasDT As Integer = configuracionInformacionReporte.InformacionReporte.Columns.Count

                Dim MergedEncabezadoLogo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, 1, 2, 2) 'B2:C3. Logo Yuyin
                Dim MergedEncabezadoNombreReporte As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, 3, 2, totalColumnasDT - 2) 'D2:N3. Nombre del reporte

                Dim MergedFechaImpresion As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, totalColumnasDT - 1, 1, totalColumnasDT) 'K1:L1. Fecha de impresión
                Dim MergedNombreArea As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(2, totalColumnasDT - 1, 2, totalColumnasDT) 'K2:L2. Campo especial

                Dim MergedEtiquetaCliente As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(4, 1, 4, 2)   ' B5:C5. Etiqueta Cliente
                Dim MergedCliente As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(4, 3, 4, totalColumnasDT - 2)   ' D5:J5. Cliente


                '' Configuración para fijar filas.
                configuracionHojaExcel.HojaExcel.DisplayOptions.PanesAreFrozen = configuracionHojaExcel.FijarFila
                configuracionHojaExcel.HojaExcel.DisplayOptions.FrozenPaneSettings.FrozenRows = configuracionHojaExcel.NumeroFilaFija

                '' ------------------------------------------------------------------------------------ ''
                '' -------------------------------- ENCABEZADO REPORTE -------------------------------- ''
                '' ------------------------------------------------------------------------------------ ''





                '' ------------------------------------------------------------------------ ''
                '' -------------------------------- IMAGEN -------------------------------- ''
                '' ------------------------------------------------------------------------ ''

                Dim ImagenLogoYuyin As System.Drawing.Image = Image.FromFile("\\192.168.2.156\Graficos Zebra\LogoGrupoYuyin.png") 'Obtenemos el logo de yuyin 'Image.FromFile("C:\\Users\\SISTEMAS6\\Pictures\\Logo_Yuyin.png") '
                'Dim ImagenLogoYuyin As System.Drawing.Image = Image.FromFile("\\192.168.2.156\Graficos Zebra\prueba lengua\LOGOTIPO NEGRO.PNG")

                Dim ImagenHojaExcel As WorksheetImage = New WorksheetImage(ImagenLogoYuyin)
                ImagenHojaExcel.TopLeftCornerCell = configuracionHojaExcel.HojaExcel.Rows.Item(1).Cells.Item(1)    '' Delimitamos los margenes y la ubicacion de la imagen
                ImagenHojaExcel.TopLeftCornerPosition = New PointF(5.0F, 20.0F)            '' Ampliación de la imagen
                ImagenHojaExcel.BottomRightCornerCell = configuracionHojaExcel.HojaExcel.Rows.Item(3).Cells.Item(3)
                ImagenHojaExcel.BottomRightCornerPosition = New PointF(60.0F, 70.0F)
                ImagenHojaExcel.Outline = Nothing   '' Quitamos el contorno de la imagen.

                configuracionHojaExcel.HojaExcel.Shapes.Add(ImagenHojaExcel) 'Añadimos la imagen (Los archivos con formato WorksheetImage son considerados formas(shapes))


                '' Se agrega el ajuste de texto para no marcar errores con la imagen.
                MergedEncabezadoNombreReporte.CellFormat.WrapText = ExcelDefaultableBoolean.True

                '' ------------------------------------------------------------------------ ''
                '' -------------------------------- IMAGEN -------------------------------- ''
                '' ------------------------------------------------------------------------ ''





                '' --------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONTENIDO DEL REPORTE -------------------------------- ''
                '' --------------------------------------------------------------------------------------- ''

                ''  Inicio insercion datos del reporte
                Dim FilaReporte As Integer = configuracionHojaExcel.NumeroFilaFija
                Dim NumRegistros = 0

                For i As Int16 = 0 To configuracionInformacionReporte.InformacionReporte.Rows.Count - 1 Step 1 'Asignamos el número de la fila de excel donde se insertarán los datos del reporte (5)

                    Dim ColumnaReporte As Integer = 1  '' Esta variable es donde inicia la tabla (como existe un margen debemos tomar eso en cuenta).

                    configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Height = 315   '1 px en Excel equivalen a 15 px en visual (Filas)

                    For j As Int16 = 0 To configuracionInformacionReporte.InformacionReporte.Columns.Count - 1 Step 1 'Asignamos el número de la columna de excel donde se insertarán los datos del reporte (1)
                        Dim Valor As Object = configuracionInformacionReporte.InformacionReporte.Rows(i).Item(j)

                        If TypeOf Valor Is System.Drawing.Image Then
                            configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Height = 1050 ' (70 pixeles)
                            configuracionHojaExcel.HojaExcel.Columns.Item(ColumnaReporte).Width = 4500 ' (120 pixeles)

                            FormatoContenidoReporteImagen(
                                        configuracionHojaExcel,
                                        configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                        Valor,
                                        Color.White,
                                        ColorBordes
                                    )
                        Else
                            FormatoContenidoReporteTexto(
                                       "Celda",
                                       configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                       Valor,
                                       "",
                                       200,
                                       Color.White,
                                       ColorBordes
                                   )
                        End If

                        ' Bloqueo de columna.
                        'configuracionHojaExcel.HojaExcel.Columns(ColumnaReporte).CellFormat.Locked = ExcelDefaultableBoolean.True

                        ColumnaReporte += 1
                    Next

                    FilaReporte += 1
                Next


                If configuracionInformacionReporte.MostrarTotalGeneral = True Then
                    '' Agregamos la barra gris del pie del reporte.
                    Dim MergedPiePagina As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 1, FilaReporte, totalColumnasDT - 1) 'B*:O*. Barra del pie de reporte.
                    FormatoCeldasCombinadasReporte(MergedPiePagina, "TOTAL GENERAL ", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Right, ColorTablas, ColorBordes, CellBorderLineStyle.Default)

                    '' Agregamos el cuadro con el total de pares a producir.
                    Dim totalParesPedido = (From a In configuracionInformacionReporte.InformacionReporte.AsEnumerable() Select a.Field(Of Double)("Total")).Sum()

                    FormatoContenidoReporteTexto("Celda", configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(15), totalParesPedido, "", 240, ColorTablas, ColorBordes)
                End If

                '' --------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONTENIDO DEL REPORTE -------------------------------- ''
                '' --------------------------------------------------------------------------------------- ''





                '' ----------------------------------------------------------------------------------------- ''
                '' -------------------------------- DIMENSIONES DEL REPORTE -------------------------------- ''
                '' ----------------------------------------------------------------------------------------- ''
                '' 1 px en Excel equivalen a 15 en visual (Filas)
                '' 1 px en Excel equivalen a 36.75 en visual (Columnas)

                Dim totalColumnasReporte = configuracionInformacionReporte.InformacionReporte.Columns.Count

                FormatoCeldasCombinadasReporte(MergedEncabezadoLogo, "", 100, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoNombreReporte, configuracionEncabezadoListasPrecios.NombreReporte, 300, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)

                FormatoCeldasCombinadasReporte(MergedFechaImpresion, configuracionEncabezadoListasPrecios.Campo1, 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNombreArea, configuracionEncabezadoListasPrecios.NombreArea, 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEtiquetaCliente, configuracionEncabezadoListasPrecios.Campo2, 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedCliente, configuracionEncabezadoListasPrecios.Campo3, 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)


                '' Alto de las filas encabezado.
                configuracionHojaExcel.HojaExcel.Rows(0).Height = 150  '' Espacio (10 px)
                configuracionHojaExcel.HojaExcel.Rows(1).Height = 450
                configuracionHojaExcel.HojaExcel.Rows(2).Height = 450
                configuracionHojaExcel.HojaExcel.Rows(3).Height = 150
                configuracionHojaExcel.HojaExcel.Rows(4).Height = 450
                configuracionHojaExcel.HojaExcel.Rows(5).Height = 150
                configuracionHojaExcel.HojaExcel.Rows(6).Height = 750



                Dim FilaTitulosReporte As Integer = configuracionHojaExcel.NumeroFilaFija - 1
                '' Damos formato a los nombres de las columnas.
                While contadorTamañoColumnas < totalColumnasDT
                    Dim nombreColumna As String = configuracionInformacionReporte.InformacionReporte.Columns(contadorTamañoColumnas).Caption

                    FormatoContenidoReporteTexto("Titulo", configuracionHojaExcel.HojaExcel.Rows.Item(FilaTitulosReporte).Cells.Item(contadorNombreColumnas), nombreColumna, "", 200, Color.FromArgb(221, 235, 247), ColorBordes)

                    contadorTamañoColumnas += 1
                    contadorNombreColumnas += 1
                End While

                contadorTamañoColumnas = 0
                While contadorTamañoColumnas < configuracionInformacionReporte.TamañoColumnas.Count

                    configuracionHojaExcel.HojaExcel.Columns(contadorTamañoColumnas).Width = (configuracionInformacionReporte.TamañoColumnas(contadorTamañoColumnas) * 36.75)

                    contadorTamañoColumnas += 1
                End While

                '' Celdas combinadas con las columnas que indican la utilidad final.
                If totalColumnasDT >= 16 Then
                    Dim MergedColumnasUtilidad As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(6, 12, 6, 13)
                    FormatoCeldasCombinadasReporte(MergedColumnasUtilidad, "UTILIDAD", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(221, 235, 247), ColorBordes, CellBorderLineStyle.Thin)

                    Dim MergedColumnasDespuesImpuestos As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(6, 14, 6, 15)
                    FormatoCeldasCombinadasReporte(MergedColumnasDespuesImpuestos, "UTILIDAD DESPUÉS DE IMPUESTOS", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(221, 235, 247), ColorBordes, CellBorderLineStyle.Thin)
                End If

                '' ----------------------------------------------------------------------------------------- ''
                '' -------------------------------- DIMENSIONES DEL REPORTE -------------------------------- ''
                '' ----------------------------------------------------------------------------------------- ''





                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- FIRMA DE LOS INVOLUCRADOS -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''

                If totalColumnasDT >= 16 Then
                    FilaReporte += 1

                    Dim MergedNombreFirmaDueño As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 1, FilaReporte + 2, 2)
                    Dim MergedEspacioFirmaDueño As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 3, FilaReporte + 2, 5)

                    Dim MergedNombreFirmaGerenteGeneral As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 6, FilaReporte + 2, 7)
                    Dim MergedEspacioFirmaGerenteGeneral As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 8, FilaReporte + 2, 11)

                    Dim MergedNombreFirmaAdminPrecios As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 12, FilaReporte + 2, 13)
                    Dim MergedEspacioFirmaAdminPrecios As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 14, FilaReporte + 2, 16)


                    FormatoCeldasCombinadasReporte(MergedNombreFirmaDueño, "RAUL VILLAGRANA" + vbCrLf + "DIRECCIÓN", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                    FormatoCeldasCombinadasReporte(MergedEspacioFirmaDueño, "", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)

                    FormatoCeldasCombinadasReporte(MergedNombreFirmaGerenteGeneral, "ANGEL ORTIZ" + vbCrLf + "GERENCIA GENERAL", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                    FormatoCeldasCombinadasReporte(MergedEspacioFirmaGerenteGeneral, "", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)

                    FormatoCeldasCombinadasReporte(MergedNombreFirmaAdminPrecios, "ISMAEL ORTIZ" + vbCrLf + "ADMINISTRACIÓN", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                    FormatoCeldasCombinadasReporte(MergedEspacioFirmaAdminPrecios, "", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)

                    FilaReporte += 2
                Else
                    FilaReporte += 1

                    Dim MergedNombreFirmaCliente As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 1, FilaReporte + 2, 2)
                    Dim MergedEspacioFirmaCliente As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 3, FilaReporte + 2, 5)

                    Dim MergedNombreFirmaDueño As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 6, FilaReporte + 2, 7)
                    Dim MergedEspacioFirmaDueño As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 8, FilaReporte + 2, 11)


                    FormatoCeldasCombinadasReporte(MergedNombreFirmaCliente, configuracionEncabezadoListasPrecios.Campo4, 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                    FormatoCeldasCombinadasReporte(MergedEspacioFirmaCliente, "", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)

                    FormatoCeldasCombinadasReporte(MergedNombreFirmaDueño, "RAUL VILLAGRANA", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                    FormatoCeldasCombinadasReporte(MergedEspacioFirmaDueño, "", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)

                    FilaReporte += 2
                End If


                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- FIRMA DE LOS INVOLUCRADOS -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''





                '' -------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACION DE IMPRESIÓN -------------------------------- ''
                '' -------------------------------------------------------------------------------------------- ''

                ConfigurarImpresionReporte(configuracionInformacionReporte, configuracionArchivoExcel, configuracionHojaExcel, FilaReporte, configuracionImpresion)

                '' -------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACION DE IMPRESIÓN -------------------------------- ''
                '' -------------------------------------------------------------------------------------------- ''
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Hubo un error al exportar el reporte: " + ex.Message)
        End Try
    End Sub

    Public Sub GenerarReporteDeCostosProductos(ByVal configuracionInformacionReporte As ConfiguracionInformacionReporte,
                                                ByVal configuracionArchivoExcel As ConfiguracionArchivoExcel,
                                                ByVal configuracionHojaExcel As ConfiguracionHojaExcel,
                                                Optional ByVal configuracionEncabezado As ConfiguracionEncabezado = Nothing,
                                                Optional ByVal configuracionSubEncabezados As ConfiguracionSubEncabezados = Nothing,
                                                Optional ByVal configuracionImpresion As ConfiguracionImpresion = Nothing,
                                                Optional ByVal EsModeloEspecial As Boolean = True)
        Try
            If VerificarArchivoAbierto(configuracionArchivoExcel) Then
                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACIONES GENERALES -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''

                Dim ColorBordes As Color = Color.FromArgb(128, 128, 128)
                Dim ColorTablas As Color = Color.FromArgb(217, 217, 217)
                Dim ColorEncabezadoLigero As Color = Color.FromArgb(221, 235, 247)
                Dim contadorNombreColumnas As Integer = 1
                Dim contadorTamañoColumnas As Integer = 0


                '' Asignamos el formato del archivo de excel (xlsx).
                configuracionArchivoExcel.ArchivoExcel.SetCurrentFormat(configuracionArchivoExcel.ExtensionArchivo)
                If configuracionHojaExcel.NombreHoja.Length > 30 Then
                    configuracionHojaExcel.HojaExcel = configuracionArchivoExcel.ArchivoExcel.Worksheets.Add(configuracionHojaExcel.NombreHoja.Substring(0, 30)) 'Asignamos nombre a la hoja (PED. 6174.) '' Debemos limitar a 30 caracteres el nombre de la hoja que es el límite de la misma.
                Else
                    configuracionHojaExcel.HojaExcel = configuracionArchivoExcel.ArchivoExcel.Worksheets.Add(configuracionHojaExcel.NombreHoja)
                End If



                If configuracionHojaExcel.OcultarCuadricula = True Then
                    configuracionHojaExcel.HojaExcel.DisplayOptions.GridlineColor = Color.Transparent 'Quitamos la cuadricula de la hoja de excel 
                End If

                If configuracionHojaExcel.Zoom = 0 Then
                    configuracionHojaExcel.HojaExcel.DisplayOptions.MagnificationInNormalView = 100
                Else
                    configuracionHojaExcel.HojaExcel.DisplayOptions.MagnificationInNormalView = configuracionHojaExcel.Zoom
                End If

                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACIONES GENERALES -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''





                '' ------------------------------------------------------------------------------------ ''
                '' -------------------------------- ENCABEZADO REPORTE -------------------------------- ''
                '' ------------------------------------------------------------------------------------ ''

                Dim totalColumnasDT As Integer = configuracionInformacionReporte.InformacionReporte.Columns.Count

                Dim MergedEncabezadoLogo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, 1, 2, 2) 'B2:C3. Logo Yuyin
                Dim MergedArea As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(3, 1, 3, 2) 'A4:B4. Área

                Dim MergedEncabezadoNombreReporte As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, 3, 3, totalColumnasDT - 2) 'D2:N4. Nombre del reporte

                Dim MergedFechaImpresion As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(1, totalColumnasDT - 1, 2, totalColumnasDT) 'O2:P3.  Versión del documento
                Dim MergedResponsable As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(3, totalColumnasDT - 1, 3, totalColumnasDT) 'O4:P4.   Responsable


                '' Configuración para fijar filas.
                configuracionHojaExcel.HojaExcel.DisplayOptions.PanesAreFrozen = configuracionHojaExcel.FijarFila
                configuracionHojaExcel.HojaExcel.DisplayOptions.FrozenPaneSettings.FrozenRows = configuracionHojaExcel.NumeroFilaFija

                '' ------------------------------------------------------------------------------------ ''
                '' -------------------------------- ENCABEZADO REPORTE -------------------------------- ''
                '' ------------------------------------------------------------------------------------ ''





                '' --------------------------------------------------------------------------------------- ''
                '' -------------------------------- ENCABEZADOS REGISTROS -------------------------------- ''
                '' --------------------------------------------------------------------------------------- ''

                Dim MergedClienteTitulo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(5, 1, 5, 2)
                Dim MergedClienteNombre As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(5, 3, 5, 4)
                Dim MergedFechaLieracionTitulo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(5, 5, 5, 6)
                Dim MergedFechaLieracionValor As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(5, 7, 5, 8)
                Dim MergedVigenciaTitulo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(5, 9, 5, 10)
                Dim MergedVigenciaValor As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(5, 11, 5, 12)
                Dim MergedNaveDesarrolloTitulo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(5, 13, 5, 14)
                Dim MergedNaveDesarrolloValor As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(5, 15, 5, 15)

                Dim MergedEncabezadoComercializadora As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(6, 1, 6, 7)
                Dim MergedEncabezadoNaveDesarrollo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(6, 8, 6, 14)
                Dim MergedEncabezadoComercializadoraPrecioBase As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(6, 15, 6, 15)


                Dim MergedEncabezadoNo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 1, 8, 1)
                Dim MergedEncabezadoFoto As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 2, 8, 2)
                Dim MergedEncabezadoColeccion As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 3, 8, 3)
                Dim MergedEncabezadoModelo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 4, 8, 4)
                Dim MergedEncabezadoPiel As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 5, 8, 5)
                Dim MergedEncabezadoColor As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 6, 8, 6)
                Dim MergedEncabezadoCorrida As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 7, 8, 7)
                Dim MergedEncabezadoMaterialDirecto As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 8, 8, 8)
                Dim MergedEncabezadoOverhead As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 9, 8, 9)
                Dim MergedEncabezadoClasificacion As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 10, 8, 10)
                Dim MergedEncabezadoCostoFabricacion As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 11, 8, 11)
                Dim MergedEncabezadoUtilidad As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 12, 7, 13)
                Dim MergedEncabezadoUtilidadDinero As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(8, 12, 8, 12)
                Dim MergedEncabezadoUtilidadPorcentaje As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(8, 13, 8, 13)

                Dim MergedEncabezadoPrecioVenta As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 14, 8, 14)
                Dim MergedEncabezadoPrecioBase As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(7, 15, 8, 15)

                '' --------------------------------------------------------------------------------------- ''
                '' -------------------------------- ENCABEZADOS REGISTROS -------------------------------- ''
                '' --------------------------------------------------------------------------------------- ''





                '' ------------------------------------------------------------------------ ''
                '' -------------------------------- IMAGEN -------------------------------- ''
                '' ------------------------------------------------------------------------ ''

                'Dim ImagenLogoYuyin As System.Drawing.Image = Image.FromFile("\\192.168.2.156\Graficos Zebra\LogoGrupoYuyin.png") 'Obtenemos el logo de yuyin 'Image.FromFile("C:\\Users\\SISTEMAS6\\Pictures\\Logo_Yuyin.png") '
                Dim ImagenLogoYuyin As System.Drawing.Image = Image.FromFile("\\192.168.2.156\Graficos Zebra\LogoGrupoYuyin.png")

                Dim ImagenHojaExcel As WorksheetImage = New WorksheetImage(ImagenLogoYuyin)
                ImagenHojaExcel.TopLeftCornerCell = configuracionHojaExcel.HojaExcel.Rows.Item(1).Cells.Item(1)    '' Delimitamos los margenes y la ubicacion de la imagen
                ImagenHojaExcel.TopLeftCornerPosition = New PointF(5.0F, 20.0F)            '' Ampliación de la imagen
                ImagenHojaExcel.BottomRightCornerCell = configuracionHojaExcel.HojaExcel.Rows.Item(3).Cells.Item(3)
                ImagenHojaExcel.BottomRightCornerPosition = New PointF(60.0F, 70.0F)
                ImagenHojaExcel.Outline = Nothing   '' Quitamos el contorno de la imagen.

                configuracionHojaExcel.HojaExcel.Shapes.Add(ImagenHojaExcel) 'Añadimos la imagen (Los archivos con formato WorksheetImage son considerados formas(shapes))

                ''Se agrega el ajuste de texto para no marcar errores con la imagen.
                MergedEncabezadoNombreReporte.CellFormat.WrapText = ExcelDefaultableBoolean.True

                '' ------------------------------------------------------------------------ ''
                '' -------------------------------- IMAGEN -------------------------------- ''
                '' ------------------------------------------------------------------------ ''





                '' --------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONTENIDO DEL REPORTE -------------------------------- ''
                '' --------------------------------------------------------------------------------------- ''

                ''  Inicio insercion datos del reporte
                Dim FilaReporte As Integer = configuracionHojaExcel.NumeroFilaFija
                Dim NumRegistros = 0

                For i As Int16 = 0 To configuracionInformacionReporte.InformacionReporte.Rows.Count - 1 Step 1 'Asignamos el número de la fila de excel donde se insertarán los datos del reporte (5)

                    Dim ColumnaReporte As Integer = 1  '' Esta variable es donde inicia la tabla (como existe un margen debemos tomar eso en cuenta).

                    configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Height = 315   '1 px en Excel equivalen a 15 px en visual (Filas)

                    For j As Int16 = 0 To configuracionInformacionReporte.InformacionReporte.Columns.Count - 1 Step 1 'Asignamos el número de la columna de excel donde se insertarán los datos del reporte (1)
                        Dim Valor As Object = configuracionInformacionReporte.InformacionReporte.Rows(i).Item(j)
                        Dim ExisteModelo As Object = configuracionInformacionReporte.InformacionReporte.Rows(i).Item("ModeloSAY")
                        Dim nombreColumnaActual As String = configuracionInformacionReporte.InformacionReporte.Columns(j).ColumnName

                        If Not IsDBNull(Valor) AndAlso Valor IsNot Nothing AndAlso TypeOf Valor Is System.Drawing.Image Then
                            ' Es una imagen válida
                            If EsModeloEspecial = True Then
                                configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Height = 1290 ' (86 pixeles)
                            Else
                                configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Height = 1650 ' (110 pixeles)   '' Esto es para los modelos especiales al ser menos registros.
                            End If
                            configuracionHojaExcel.HojaExcel.Columns.Item(ColumnaReporte).Width = 4800 ' (140 pixeles)

                            If ExisteModelo.ToString <> "" Then
                                FormatoContenidoReporteImagen(
                                            configuracionHojaExcel,
                                            configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                            Valor,
                                            Color.White,
                                            ColorBordes
                                        )
                            Else
                                FormatoContenidoReporteTexto(
                                            "Celda",
                                            configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                            "",
                                            configuracionHojaExcel.FormatoColumnas(ColumnaReporte),
                                            240,
                                            Color.White,
                                            ColorBordes
                                        )
                            End If
                        Else
                            ' Convertimos DBNull y otros a string seguro
                            Dim textoSeguro As String = If(IsDBNull(Valor) OrElse Valor Is Nothing, String.Empty, Valor.ToString())


                            If ExisteModelo.ToString <> "" Then
                                FormatoContenidoReporteTexto(
                                            "Celda",
                                            configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                            textoSeguro,
                                            configuracionHojaExcel.FormatoColumnas(ColumnaReporte),
                                            240,
                                            Color.White,
                                            ColorBordes
                                        )
                            Else
                                If nombreColumnaActual = "No" Then
                                    FormatoContenidoReporteTexto(
                                           "Celda",
                                           configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                           textoSeguro,
                                           configuracionHojaExcel.FormatoColumnas(ColumnaReporte),
                                           240,
                                           Color.White,
                                           ColorBordes
                                       )
                                Else
                                    FormatoContenidoReporteTexto(   '' Si no hay información, vamos a dejar la celda sin nada ni formato.
                                         "Celda",
                                         configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte),
                                         "",
                                         "vacio",
                                         240,
                                         Color.White,
                                         ColorBordes
                                     )
                                End If
                            End If



                            '' Agregaremos un margen para dividir la información de la comercializadora de la información de la nave desarrollo.
                            Dim ColumnaActual As String = configuracionInformacionReporte.InformacionReporte.Columns(j).ColumnName

                            If ColumnaActual = "Talla" Then
                                configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte).CellFormat.RightBorderStyle = CellBorderLineStyle.Thick
                                configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            End If
                        End If



                        '' Si la fila que se revisa es igual o multiplo de 4, agregamos un margen inferior para hacer la división de los modelos.
                        If EsModeloEspecial = True Then
                            Dim filaIndice = i + 1
                            If filaIndice Mod 4 = 0 Then
                                Dim celda = configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(ColumnaReporte)
                                With celda.CellFormat
                                    .BottomBorderStyle = CellBorderLineStyle.Thick
                                    .BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                End With
                            End If
                        End If



                        ColumnaReporte += 1
                    Next

                    FilaReporte += 1
                Next


                If configuracionInformacionReporte.MostrarTotalGeneral = True Then
                    '' Agregamos la barra gris del pie del reporte.
                    Dim MergedPiePagina As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 1, FilaReporte, totalColumnasDT - 1) 'B*:O*. Barra del pie de reporte.
                    FormatoCeldasCombinadasReporte(MergedPiePagina, "TOTAL GENERAL ", 200, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Right, ColorTablas, ColorBordes, CellBorderLineStyle.Default)

                    '' Agregamos el cuadro con el total de pares a producir.
                    Dim totalParesPedido = (From a In configuracionInformacionReporte.InformacionReporte.AsEnumerable() Select a.Field(Of Double)("Total")).Sum()

                    FormatoContenidoReporteTexto("Celda", configuracionHojaExcel.HojaExcel.Rows.Item(FilaReporte).Cells.Item(15), totalParesPedido, 240, "", ColorTablas, ColorBordes)
                End If

                '' --------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONTENIDO DEL REPORTE -------------------------------- ''
                '' --------------------------------------------------------------------------------------- ''





                '' ----------------------------------------------------------------------------------------- ''
                '' -------------------------------- DIMENSIONES DEL REPORTE -------------------------------- ''
                '' ----------------------------------------------------------------------------------------- ''
                '' 1 px en Excel equivalen a 15 en visual (Filas)
                '' 1 px en Excel equivalen a 36.75 en visual (Columnas)

                Dim totalColumnasReporte = configuracionInformacionReporte.InformacionReporte.Columns.Count

                FormatoCeldasCombinadasReporte(MergedEncabezadoLogo, "", 100, ExcelDefaultableBoolean.False, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedArea, configuracionEncabezado.NombreArea, 220, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoNombreReporte, configuracionEncabezado.NombreReporte, 400, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedFechaImpresion, configuracionEncabezado.Mes, 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedResponsable, configuracionEncabezado.NombreResponsable, 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Left, Color.White, ColorBordes, CellBorderLineStyle.Medium)


                FormatoCeldasCombinadasReporte(MergedClienteTitulo, "CLIENTE:", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedClienteNombre, configuracionSubEncabezados.Campo1, 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedFechaLieracionTitulo, "FECHA DE LIBERACIÓN", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedFechaLieracionValor, configuracionSubEncabezados.Campo2, 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedVigenciaTitulo, "VIGENCIA", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedVigenciaValor, configuracionSubEncabezados.Campo3, 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNaveDesarrolloTitulo, "NAVE DESARROLLO", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNaveDesarrolloValor, configuracionSubEncabezados.Campo4, 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)


                FormatoCeldasCombinadasReporte(MergedEncabezadoComercializadora, "CEDIS", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoNaveDesarrollo, "NAVE DESARROLLO", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoComercializadoraPrecioBase, "CEDIS", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)


                FormatoCeldasCombinadasReporte(MergedEncabezadoNo, "No.", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoFoto, "FOTO", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoColeccion, "COLECCIÓN", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoModelo, "MODELO", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoPiel, "PIEL", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoColor, "COLOR", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoCorrida, "CORRIDA", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoMaterialDirecto, "MATERIAL DIRECTO", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoOverhead, "OVERHEAD", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoClasificacion, "CLASIFICACIÓN", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoCostoFabricacion, "TOTAL COSTO FABRICACIÓN", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoUtilidad, "UTILIDAD TOTAL", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedClienteTitulo, "CLIENTE:", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoUtilidadDinero, "%", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoUtilidadPorcentaje, "$", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoPrecioVenta, "PRECIO DE VENTA A COMERCIALIZ.", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedEncabezadoPrecioBase, "PRECIO BASE", 240, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, ColorEncabezadoLigero, ColorBordes, CellBorderLineStyle.Medium)



                '' Alto de las filas encabezado.
                configuracionHojaExcel.HojaExcel.Rows(0).Height = 150  '' Espacio (10 px)
                configuracionHojaExcel.HojaExcel.Rows(1).Height = 450
                configuracionHojaExcel.HojaExcel.Rows(2).Height = 450
                configuracionHojaExcel.HojaExcel.Rows(3).Height = 450

                '' Alto de las filas de los encabezados.
                configuracionHojaExcel.HojaExcel.Rows(4).Height = 150
                configuracionHojaExcel.HojaExcel.Rows(5).Height = 750
                configuracionHojaExcel.HojaExcel.Rows(6).Height = 375
                configuracionHojaExcel.HojaExcel.Rows(7).Height = 300
                configuracionHojaExcel.HojaExcel.Rows(8).Height = 600



                contadorTamañoColumnas = 0
                ''While contadorTamañoColumnas < (totalColumnasDT + 1)
                While contadorTamañoColumnas < configuracionInformacionReporte.TamañoColumnas.Count
                    configuracionHojaExcel.HojaExcel.Columns(contadorTamañoColumnas).Width = (configuracionInformacionReporte.TamañoColumnas(contadorTamañoColumnas) * 36.75)

                    contadorTamañoColumnas += 1
                End While

                '' ----------------------------------------------------------------------------------------- ''
                '' -------------------------------- DIMENSIONES DEL REPORTE -------------------------------- ''
                '' ----------------------------------------------------------------------------------------- ''





                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- FIRMA DE LOS INVOLUCRADOS -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''

                '' Damos un renglón de separación para las firmas
                FilaReporte += 3

                Dim MergedNombreFirmaGerenteDiseñoDesarrolloEspacio As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 1, FilaReporte + 3, 3)
                Dim MergedNombreFirmaDireccionNavesEspacio As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 4, FilaReporte + 3, 7)
                Dim MergedNombreFirmaDireccionComercialEspacio As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 8, FilaReporte + 3, 11)
                Dim MergedNombreFirmaDiseñoConceptualEspacio As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 12, FilaReporte + 3, 15)

                FormatoCeldasCombinadasReporte(MergedNombreFirmaGerenteDiseñoDesarrolloEspacio, "", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNombreFirmaDireccionNavesEspacio, "", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNombreFirmaDireccionComercialEspacio, "", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNombreFirmaDiseñoConceptualEspacio, "", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.White, ColorBordes, CellBorderLineStyle.Medium)

                FilaReporte += 4



                Dim MergedNombreFirmaGerenteDiseñoDesarrollo As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 1, FilaReporte, 3)
                Dim MergedNombreFirmaDireccionNaves As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 4, FilaReporte, 7)
                Dim MergedNombreFirmaDireccionComercial As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 8, FilaReporte, 11)
                Dim MergedNombreFirmaDiseñoConceptual As WorksheetMergedCellsRegion = configuracionHojaExcel.HojaExcel.MergedCellsRegions.Add(FilaReporte, 12, FilaReporte, 15)


                FormatoCeldasCombinadasReporte(MergedNombreFirmaGerenteDiseñoDesarrollo, "GERENTE DISEÑO Y DESARROLLO", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNombreFirmaDireccionNaves, "DIRECCIÓN DE NAVES", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNombreFirmaDireccionComercial, "ESPECIALISTA DE DC", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)
                FormatoCeldasCombinadasReporte(MergedNombreFirmaDiseñoConceptual, "GERENTE DISEÑO CONCEPTUAL", 280, ExcelDefaultableBoolean.True, HorizontalCellAlignment.Center, Color.FromArgb(217, 225, 242), ColorBordes, CellBorderLineStyle.Medium)

                '' ------------------------------------------------------------------------------------------- ''
                '' -------------------------------- FIRMA DE LOS INVOLUCRADOS -------------------------------- ''
                '' ------------------------------------------------------------------------------------------- ''





                '' -------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACION DE IMPRESIÓN -------------------------------- ''
                '' -------------------------------------------------------------------------------------------- ''

                ConfigurarImpresionReporte(configuracionInformacionReporte, configuracionArchivoExcel, configuracionHojaExcel, FilaReporte, configuracionImpresion)

                '' -------------------------------------------------------------------------------------------- ''
                '' -------------------------------- CONFIGURACION DE IMPRESIÓN -------------------------------- ''
                '' -------------------------------------------------------------------------------------------- ''
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Hubo un error al exportar el reporte: " + ex.Message)
        End Try
    End Sub

#End Region





#Region "Métodos generales"
    Private Sub FormatoCeldasCombinadasReporte(ByVal celdasCombinadas As WorksheetMergedCellsRegion,
                                               ByVal Contenido As String,
                                               ByVal Fuente As Integer,
                                               ByVal NegritaActiva As ExcelDefaultableBoolean,
                                               ByVal AlineacionHorizontal As HorizontalCellAlignment,
                                               ByVal ColorFondo As Color,
                                               ByVal ColorBorde As Color,
                                               ByVal GrosorBorde As CellBorderLineStyle)
        ' Interior celda
        celdasCombinadas.Value = Contenido
        celdasCombinadas.CellFormat.Alignment = AlineacionHorizontal
        celdasCombinadas.CellFormat.VerticalAlignment = VerticalCellAlignment.Center
        celdasCombinadas.CellFormat.Font.Bold = NegritaActiva
        celdasCombinadas.CellFormat.Font.Height = Fuente ' 20 es equivalente a 1 en tamaño letra
        celdasCombinadas.CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(ColorFondo), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
        celdasCombinadas.CellFormat.Font.Name = "Calibri"


        ' Bordes
        celdasCombinadas.CellFormat.TopBorderStyle = GrosorBorde
        celdasCombinadas.CellFormat.TopBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        celdasCombinadas.CellFormat.RightBorderStyle = GrosorBorde
        celdasCombinadas.CellFormat.RightBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        celdasCombinadas.CellFormat.BottomBorderStyle = GrosorBorde
        celdasCombinadas.CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        celdasCombinadas.CellFormat.LeftBorderStyle = GrosorBorde
        celdasCombinadas.CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        celdasCombinadas.CellFormat.WrapText = ExcelDefaultableBoolean.True
    End Sub

    Private Sub FormatoContenidoReporteTexto(ByVal TipoCelda As String,
                                             ByVal Celda As WorksheetCell,
                                             ByVal Contenido As String,
                                             ByVal FormatoContenido As String,
                                             ByVal Fuente As Integer,
                                             ByVal ColorFondo As Color,
                                             ByVal ColorBorde As Color)

        If TipoCelda = "Celda" Then
            Celda.CellFormat.VerticalAlignment = VerticalCellAlignment.Center

            ' Valor convertido según formato
            Select Case FormatoContenido.ToLower()
                Case "dinero"
                    Celda.Value = If(IsNumeric(Contenido), CDec(Contenido), 0D)
                    Celda.CellFormat.FormatString = "_($* #,##0.00_);_(@_)"
                    Celda.CellFormat.Alignment = HorizontalCellAlignment.Right

                Case "porcentaje"
                    Celda.Value = If(IsNumeric(Contenido), CDec(Contenido) / 100D, 0D)
                    Celda.CellFormat.FormatString = "0.00%"
                    Celda.CellFormat.Alignment = HorizontalCellAlignment.Center

                Case "numero"
                    Celda.Value = If(IsNumeric(Contenido), CDec(Contenido), 0D)
                    Celda.CellFormat.FormatString = "0"
                    Celda.CellFormat.Alignment = HorizontalCellAlignment.Right

                Case "fecha corta"
                    Celda.Value = If(IsDate(Contenido), CDate(Contenido), Date.MinValue)
                    Celda.CellFormat.FormatString = "dd/mm/yyyy"
                    Celda.CellFormat.Alignment = HorizontalCellAlignment.Center

                Case "fecha larga"
                    Celda.Value = If(IsDate(Contenido), CDate(Contenido), Date.MinValue)
                    Celda.CellFormat.FormatString = "dddd, dd 'de' mmmm 'de' yyyy"
                    Celda.CellFormat.Alignment = HorizontalCellAlignment.Center

                Case "caracter"
                    Celda.Value = CStr(Contenido)
                    Celda.CellFormat.FormatString = "@"
                    Celda.CellFormat.Alignment = HorizontalCellAlignment.Center

                Case "alfanumerico", "texto", "corrida"
                    Celda.Value = CStr(Contenido)
                    Celda.CellFormat.FormatString = "@"
                    Celda.CellFormat.Alignment = HorizontalCellAlignment.Left

                Case "vacio"
                    Celda.Value = ""
                    Celda.CellFormat.Alignment = HorizontalCellAlignment.Center

                Case Else
                    ' Detección automática
                    If IsDate(Contenido) Then
                        Celda.Value = CDate(Contenido)
                        Celda.CellFormat.Alignment = HorizontalCellAlignment.Right
                    ElseIf regexNumerosYDecimales.IsMatch(Contenido) Then
                        Celda.Value = CDec(Contenido)
                        Celda.CellFormat.Alignment = HorizontalCellAlignment.Right
                    ElseIf regexNumerosYLetras.IsMatch(Contenido) Then
                        Celda.Value = CStr(Contenido)
                        Celda.CellFormat.Alignment = HorizontalCellAlignment.Left
                    ElseIf regexCorrida.IsMatch(Contenido) Then
                        Celda.Value = CStr(Contenido)
                        Celda.CellFormat.Alignment = HorizontalCellAlignment.Left
                    ElseIf Contenido.Length = 1 Then
                        Celda.Value = CStr(Contenido)
                        Celda.CellFormat.Alignment = HorizontalCellAlignment.Center
                    Else
                        Celda.Value = Contenido
                        Celda.CellFormat.Alignment = HorizontalCellAlignment.Left
                    End If
            End Select

        ElseIf TipoCelda = "Titulo" Then
            Dim tituloSeparado As String = Regex.Replace(CStr(Contenido), "_", " ")
            Celda.Value = tituloSeparado
            Celda.CellFormat.Alignment = HorizontalCellAlignment.Center
            Celda.CellFormat.VerticalAlignment = VerticalCellAlignment.Center
            Celda.CellFormat.Font.Bold = ExcelDefaultableBoolean.True
        End If

        ' Estilo común
        Celda.CellFormat.Font.Name = "Calibri"
        Celda.CellFormat.Font.Height = Fuente
        Celda.CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(ColorFondo), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)

        ' Bordes
        Celda.CellFormat.TopBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.TopBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.RightBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.RightBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.BottomBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.LeftBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.WrapText = ExcelDefaultableBoolean.True
    End Sub

    Private Sub FormatoContenidoReporteImagen(ByVal configuracionHojaExcel As ConfiguracionHojaExcel,
                                                ByVal Celda As WorksheetCell,
                                                ByVal Imagen As System.Drawing.Image,
                                                ByVal ColorFondo As Color,
                                                ByVal ColorBorde As Color)

        Dim imageShape As Infragistics.Documents.Excel.WorksheetImage = New Infragistics.Documents.Excel.WorksheetImage(Imagen)

        imageShape.TopLeftCornerCell = Celda
        imageShape.TopLeftCornerPosition = New PointF(10.0F, 10.0F)
        imageShape.BottomRightCornerCell = Celda
        imageShape.BottomRightCornerPosition = New PointF(95.0F, 95.0F)
        imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells


        ' Bordes
        Celda.CellFormat.TopBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.TopBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.RightBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.RightBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.BottomBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.LeftBorderStyle = CellBorderLineStyle.Default
        Celda.CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(ColorBorde)
        Celda.CellFormat.WrapText = ExcelDefaultableBoolean.True

        configuracionHojaExcel.HojaExcel.Shapes.Add(imageShape)
    End Sub

    Private Sub AplicarBordeInferiorSiCorresponde(ByVal configuracionHojaExcel As ConfiguracionHojaExcel,
                                                   ByVal filaIndice As Integer,
                                                   ByVal filaExcel As Integer,
                                                   ByVal columnaExcel As Integer)
        If (filaIndice + 1) Mod 4 = 0 Then
            Dim celda = configuracionHojaExcel.HojaExcel.Rows.Item(filaExcel).Cells.Item(columnaExcel)
            With celda.CellFormat
                .BottomBorderStyle = CellBorderLineStyle.Thick
                .BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
            End With
        End If
    End Sub



    Function ConvertirNumeroALetra(ByVal numero As Long) As String
        Dim columnaLetra = ""
        Dim a As Long
        Dim b As Long

        a = numero

        Do While numero > 0
            a = Int((numero - 1) / 26)
            b = (numero - 1) Mod 26
            columnaLetra = Chr(b + 65) & columnaLetra
            numero = a
        Loop
        Return columnaLetra
    End Function



    Private Function VerificarArchivoAbierto(ByVal configuracionArchivoExcel As ConfiguracionArchivoExcel) As Boolean
        Dim ArchivosAbiertos() As Process = System.Diagnostics.Process.GetProcessesByName("Excel")
        Dim Resultado As Boolean = False

        If ArchivosAbiertos.Count > 0 Then
            For Each reporte As Process In ArchivosAbiertos
                If reporte.MainWindowTitle.ToUpper.Contains(configuracionArchivoExcel.NombreArchivo.ToUpper) Then
                    Tools.MostrarMensaje(Mensajes.Warning, "Hay un reporte abierto con un nombre similar. Favor de cerrarlo y volver a intentar.")
                    Resultado = False
                    Exit For
                Else
                    Resultado = True
                End If
            Next
        Else
            Resultado = True
        End If

        Return Resultado
    End Function

    Private Sub ConfigurarImpresionReporte(ByVal configuracionInformacionReporte As ConfiguracionInformacionReporte,
                                            ByVal configuracionArchivoExcel As ConfiguracionArchivoExcel,
                                            ByVal configuracionHojaExcel As ConfiguracionHojaExcel,
                                            ByVal FilaReporte As Integer,
                                            Optional ByVal configuracionImpresion As ConfiguracionImpresion = Nothing)
        If configuracionImpresion IsNot Nothing Then

            '' Configuración de impresión
            configuracionHojaExcel.HojaExcel.PrintOptions.PaperSize = configuracionImpresion.TamañoHoja '' Tipo de hoja Carta.
            configuracionHojaExcel.HojaExcel.PrintOptions.Orientation = configuracionImpresion.OrientacionHoja  '' Orientezación horizontal.

            '' Configuración de los márgenes ESTRECHO (son las mismas medidas que en Excel). La medida que maneja Infragistics es en pulgadas.
            If configuracionImpresion.AjustarMargenesImpresion = True Then
                configuracionHojaExcel.HojaExcel.PrintOptions.TopMargin = 0.75
                configuracionHojaExcel.HojaExcel.PrintOptions.BottomMargin = 0.75
                configuracionHojaExcel.HojaExcel.PrintOptions.LeftMargin = 0.25
                configuracionHojaExcel.HojaExcel.PrintOptions.RightMargin = 0.25
                configuracionHojaExcel.HojaExcel.PrintOptions.HeaderMargin = 0.3
                configuracionHojaExcel.HojaExcel.PrintOptions.FooterMargin = 0.3
            End If

            ' Configuración para ajustar hoja en una página y extender el contenido del reporte a varias hojas.
            If configuracionImpresion.AjustarContenidoAUnaHoja = True Then
                configuracionHojaExcel.HojaExcel.PrintOptions.ScalingType = ScalingType.FitToPages
                configuracionHojaExcel.HojaExcel.PrintOptions.ScalingFactor = 100
                configuracionHojaExcel.HojaExcel.PrintOptions.MaxPagesVertically = 0
            End If

            If configuracionImpresion.ModificarAreaImpresion = True Then
                configuracionHojaExcel.HojaExcel.PrintOptions.PrintAreas.Add(configuracionHojaExcel.HojaExcel.GetRegion(configuracionImpresion.AreaImpresion))

            End If
        Else
            '' Asignamos el área de impresión
            Dim letraColumnaFinal As String = ConvertirNumeroALetra(configuracionInformacionReporte.TamañoColumnas.Count + 1)

            FilaReporte += 2    '' Agregamos dos filas extra al área de impresión para tener una fila sola de margen.
            configuracionHojaExcel.HojaExcel.PrintOptions.PrintAreas.Add(configuracionHojaExcel.HojaExcel.GetRegion("A1:" + CStr(letraColumnaFinal) + CStr(FilaReporte)))
        End If


        '' Guardado del reporte.
        configuracionArchivoExcel.ArchivoExcel.Save(configuracionArchivoExcel.RutaCompleta)

        If configuracionImpresion.PreguntarAbrirArchivo = True Then
            '' Iniciar el reporte.
            Dim formaConfirmacion As New ConfirmarForm
            formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
            formaConfirmacion.mensaje = "¿Quieres abrir el archivo creado?"
            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Process.Start(configuracionArchivoExcel.RutaCompleta)
            End If
        End If
    End Sub

#End Region

End Class





Public Enum ExtensionArchivoExcel
    XLS = WorkbookFormat.Excel97To2003
    XLSX = WorkbookFormat.Excel2007
End Enum

Public Enum TamañoHojaImpresion
    Carta = PaperSize.Letter
    Oficio = PaperSize.Legal
End Enum

Public Enum OrientacionHoja
    Horizontal = Orientation.Landscape
    Vertical = Orientation.Portrait
End Enum



Public Class ConfiguracionArchivoExcel

    Private _ExtensionArchivo As ExtensionArchivoExcel
    Public Property ExtensionArchivo() As ExtensionArchivoExcel
        Get
            Return _ExtensionArchivo
        End Get
        Set(ByVal value As ExtensionArchivoExcel)
            _ExtensionArchivo = value
        End Set
    End Property

    ''' <summary>
    ''' Nombre del archivo Excel, de preferencia no poner ninguna diagonal al nombre.
    ''' </summary>
    Private _NombreArchivo As String
    Public Property NombreArchivo() As String
        Get
            Return _NombreArchivo
        End Get
        Set(ByVal value As String)
            _NombreArchivo = value
        End Set
    End Property

    Private _RutaArchivo As String
    Public Property RutaArchivo() As String
        Get
            Return _RutaArchivo
        End Get
        Set(ByVal value As String)
            _RutaArchivo = value
        End Set
    End Property

    ''' <summary>
    ''' Ruta final del archivo (Ruta + Nombre + Extensión).
    ''' </summary>
    Public Function RutaCompleta() As String
        Dim ExtensionSeleccionada As String = ""

        If ExtensionArchivoExcel.XLS Then
            ExtensionSeleccionada = ".xls"
        ElseIf ExtensionArchivoExcel.XLSX Then
            ExtensionSeleccionada = ".xlsx"
        End If

        Return _RutaArchivo + _NombreArchivo + ExtensionSeleccionada
    End Function

    Public Property _Workbook As Infragistics.Documents.Excel.Workbook
    Public Property ArchivoExcel() As Infragistics.Documents.Excel.Workbook
        Get
            Return _Workbook
        End Get
        Set(ByVal value As Infragistics.Documents.Excel.Workbook)
            _Workbook = value
        End Set
    End Property
End Class

Public Class ConfiguracionHojaExcel

    Private _NombreHoja As String
    Public Property NombreHoja() As String
        Get
            Return _NombreHoja
        End Get
        Set(ByVal value As String)
            _NombreHoja = value
        End Set
    End Property

    Private _OcultarCuadricula As Boolean
    Public Property OcultarCuadricula() As Boolean
        Get
            Return _OcultarCuadricula
        End Get
        Set(ByVal value As Boolean)
            _OcultarCuadricula = value
        End Set
    End Property

    ''' <summary>
    ''' ¿Quieres que una fila se quede fija? (útil para no perder de vista los encabezados del reporte).
    ''' </summary>
    Private _FijarFila As Boolean
    Public Property FijarFila() As Boolean
        Get
            Return _FijarFila
        End Get
        Set(ByVal value As Boolean)
            _FijarFila = value
        End Set
    End Property

    ''' <summary>
    ''' Indica el número de la fila que quieres mantener fija (si la propiedad FijarFila es FALSE, ignora esta propiedad).
    ''' </summary>
    Private _NumeroFilaFija As Integer
    Public Property NumeroFilaFija() As Integer
        Get
            Return _NumeroFilaFija
        End Get
        Set(ByVal value As Integer)
            _NumeroFilaFija = value
        End Set
    End Property

    Public Property _Worksheet As Infragistics.Documents.Excel.Worksheet
    Public Property HojaExcel() As Infragistics.Documents.Excel.Worksheet
        Get
            Return _Worksheet
        End Get
        Set(ByVal value As Infragistics.Documents.Excel.Worksheet)
            _Worksheet = value
        End Set
    End Property

    Private _FormatoColumnas As List(Of String)
    Public Property FormatoColumnas() As List(Of String)
        Get
            Return _FormatoColumnas
        End Get
        Set(ByVal value As List(Of String))
            If value Is Nothing Then
                _FormatoColumnas = New List(Of String)
            Else
                _FormatoColumnas = value
            End If
        End Set
    End Property

    Private _Zoom As Integer = 0
    Public Property Zoom() As Integer
        Get
            Return _Zoom
        End Get
        Set(ByVal value As Integer)
            _Zoom = value
        End Set
    End Property
End Class

Public Class ConfiguracionEncabezado

    Private _NombreArea As String
    Public Property NombreArea() As String
        Get
            Return _NombreArea
        End Get
        Set(ByVal value As String)
            _NombreArea = value
        End Set
    End Property

    Private _NombreReporte As String
    Public Property NombreReporte() As String
        Get
            Return _NombreReporte
        End Get
        Set(ByVal value As String)
            _NombreReporte = value
        End Set
    End Property

    Private _NombreVersionDocumento As String
    Public Property NombreVersionDocumento() As String
        Get
            Return _NombreVersionDocumento
        End Get
        Set(ByVal value As String)
            _NombreVersionDocumento = value
        End Set
    End Property

    Private _Mes As String
    Public Property Mes() As String
        Get
            Return _Mes
        End Get
        Set(ByVal value As String)
            _Mes = value
        End Set
    End Property

    Private _NombreResponsable As String
    Public Property NombreResponsable() As String
        Get
            Return _NombreResponsable
        End Get
        Set(ByVal value As String)
            _NombreResponsable = value
        End Set
    End Property
End Class

Public Class ConfiguracionEncabezadoListasPrecios

    Private _NombreArea As String
    Public Property NombreArea() As String
        Get
            Return _NombreArea
        End Get
        Set(ByVal value As String)
            _NombreArea = value
        End Set
    End Property

    Private _NombreReporte As String
    Public Property NombreReporte() As String
        Get
            Return _NombreReporte
        End Get
        Set(ByVal value As String)
            _NombreReporte = value
        End Set
    End Property

    Private _NombreVersionDocumento As String
    Public Property NombreVersionDocumento() As String
        Get
            Return _NombreVersionDocumento
        End Get
        Set(ByVal value As String)
            _NombreVersionDocumento = value
        End Set
    End Property

    Private _Campo1 As String
    Public Property Campo1() As String
        Get
            Return _Campo1
        End Get
        Set(ByVal value As String)
            _Campo1 = value
        End Set
    End Property

    Private _Campo2 As String
    Public Property Campo2() As String
        Get
            Return _Campo2
        End Get
        Set(ByVal value As String)
            _Campo2 = value
        End Set
    End Property

    Private _Campo3 As String
    Public Property Campo3() As String
        Get
            Return _Campo3
        End Get
        Set(ByVal value As String)
            _Campo3 = value
        End Set
    End Property

    Private _Campo4 As String
    Public Property Campo4() As String
        Get
            Return _Campo4
        End Get
        Set(ByVal value As String)
            _Campo4 = value
        End Set
    End Property
End Class

Public Class ConfiguracionSubEncabezados

    Private _Campo1 As String = ""
    Public Property Campo1() As String
        Get
            Return _Campo1
        End Get
        Set(ByVal value As String)
            _Campo1 = value
        End Set
    End Property

    Private _Campo2 As String = ""
    Public Property Campo2() As String
        Get
            Return _Campo2
        End Get
        Set(ByVal value As String)
            _Campo2 = value
        End Set
    End Property

    Private _Campo3 As String = ""
    Public Property Campo3() As String
        Get
            Return _Campo3
        End Get
        Set(ByVal value As String)
            _Campo3 = value
        End Set
    End Property

    Private _Campo4 As String = ""
    Public Property Campo4() As String
        Get
            Return _Campo4
        End Get
        Set(ByVal value As String)
            _Campo4 = value
        End Set
    End Property

    Private _Campo5 As String = ""
    Public Property Campo5() As String
        Get
            Return _Campo5
        End Get
        Set(ByVal value As String)
            _Campo5 = value
        End Set
    End Property
End Class

Public Class ConfiguracionInformacionReporte

    Private _InformacionReporte As DataTable
    Public Property InformacionReporte() As DataTable
        Get
            Return _InformacionReporte
        End Get
        Set(ByVal value As DataTable)
            _InformacionReporte = value
        End Set
    End Property

    Private _TamañoColumnas As List(Of Integer)
    Public Property TamañoColumnas() As List(Of Integer)
        Get
            Return _TamañoColumnas
        End Get
        Set(ByVal value As List(Of Integer))
            _TamañoColumnas = value
        End Set
    End Property

    Private _MostrarTotalGeneral As Boolean
    Public Property MostrarTotalGeneral() As Boolean
        Get
            Return _MostrarTotalGeneral
        End Get
        Set(ByVal value As Boolean)
            _MostrarTotalGeneral = value
        End Set
    End Property
End Class

Public Class ConfiguracionImpresion

    Private _TamañoHoja As TamañoHojaImpresion
    Public Property TamañoHoja() As TamañoHojaImpresion
        Get
            Return _TamañoHoja
        End Get
        Set(ByVal value As TamañoHojaImpresion)
            _TamañoHoja = value
        End Set
    End Property

    Private _OrientacionHoja As OrientacionHoja
    Public Property OrientacionHoja() As OrientacionHoja
        Get
            Return _OrientacionHoja
        End Get
        Set(ByVal value As OrientacionHoja)
            _OrientacionHoja = value
        End Set
    End Property

    ''' <summary>
    ''' ¿Quieres modificar los márgenes de impresión? (seleccionar FALSE para tomar las opciones por defecto).
    ''' </summary>
    Private _AjustarMargenesImpresion As Boolean
    Public Property AjustarMargenesImpresion() As Boolean
        Get
            Return _AjustarMargenesImpresion
        End Get
        Set(ByVal value As Boolean)
            _AjustarMargenesImpresion = value
        End Set
    End Property

    ''' <summary>
    ''' ¿Desea que el reporte se imprima en la hoja completa?
    ''' </summary>
    Private _AjustarContenidoAUnaHoja As Boolean
    Public Property AjustarContenidoAUnaHoja() As Boolean
        Get
            Return _AjustarContenidoAUnaHoja
        End Get
        Set(ByVal value As Boolean)
            _AjustarContenidoAUnaHoja = value
        End Set
    End Property

    ''' <summary>
    ''' ¿Deseas cambiar el área de impresión?
    ''' </summary>
    Private _ModificarAreaImpresion As Boolean
    Public Property ModificarAreaImpresion() As Boolean
        Get
            Return _ModificarAreaImpresion
        End Get
        Set(ByVal value As Boolean)
            _ModificarAreaImpresion = value
        End Set
    End Property

    ''' <summary>
    ''' Agregar el rango de celdas que se desea imprimir, por ejemplo: A1:P10 (seleccionar FALSE para tomar las opciones por defecto).
    ''' </summary>
    Private _AreaImpresion As String
    Public Property AreaImpresion() As String
        Get
            Return _AreaImpresion
        End Get
        Set(ByVal value As String)
            _AreaImpresion = value
        End Set
    End Property

    Private _PreguntarAbrirArchivo As Boolean
    Public Property PreguntarAbrirArchivo() As Boolean
        Get
            Return _PreguntarAbrirArchivo
        End Get
        Set(ByVal value As Boolean)
            _PreguntarAbrirArchivo = value
        End Set
    End Property
End Class
