Imports Almacen.Negocios
Imports Entidades
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports System
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class UbicacionProductoArchivoForm

    Dim colaborador As Colaborador
    Dim lista_codigos_sucio As New List(Of String)
    Dim estibaid As String
    Dim colaborador_valido, estiba_valida, _
        atado_en_ubicacion_atado, par_en_ubicacion_par As Boolean

    Dim total_estibas, total_atados, total_pares, total_invalidos, total_destallados, total_errores_archivo, _
        total_atado_estiba, total_pares_estiba, total_invalidos_estiba As Integer

    Dim fechainicio, fechatermino As String

    Private Sub UbicacionProductoArchivoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listado_naves()
    End Sub

    Private Sub listado_naves()
        Try
            Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
        Catch ex As Exception

        End Try
        If cboxNave.SelectedIndex = 1 Then
            listado_almacen()
        End If

    End Sub

    Private Sub listado_almacen()

        Try
            Controles.ComboAlmacenSegunNave(cboxAlmacen, CInt(cboxNave.SelectedValue))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCargarArchivoDAT_Click(sender As Object, e As EventArgs) Handles btnCargarArchivoDAT.Click

        Cursor.Current = Cursors.WaitCursor

        total_estibas = 0
        total_atados = 0
        total_pares = 0
        total_invalidos = 0
        total_destallados = 0
        total_errores_archivo = 0
        total_atado_estiba = 0
        total_pares_estiba = 0
        total_invalidos_estiba = 0

        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Return
        End If

        Dim fileExplorer As New OpenFileDialog()

        Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + _
                              Now.Day.ToString + "_" + Now.Hour.ToString + _
                              Now.Minute.ToString + Now.Second.ToString ''obtiene la fecha y hora para el respaldo

        fileExplorer.InitialDirectory = "c:\"
        fileExplorer.Filter = "All Files (*.*)|*.*" & "|Data Files (*.dat)|*.dat"
        fileExplorer.FilterIndex = 2
        fileExplorer.RestoreDirectory = True

        If fileExplorer.ShowDialog() = DialogResult.OK Then
            Try
                If Not Directory.Exists("C:\DAT_Respaldos\") Then
                    Directory.CreateDirectory("C:\DAT_Respaldos\")
                End If
                Dim dat_fuente As String = fileExplorer.FileName ''"D:\INV_.DAT" ''ruta del archivo en el lector
                Dim dat_destino As String = "C:\DAT_Respaldos\" + "INV_" + fecha_hora + ".DAT" ''prepara el archivo para copiarlo en disco local

                If Not File.Exists(dat_fuente) Then ''verifica que el archivo exista
                    MessageBox.Show("NO SE ENCONTRÓ EL ARCHIVO")
                    Exit Sub
                End If

                System.IO.File.Copy(dat_fuente, dat_destino, True) ''copia el archivo de orifen en el disco local
                txtResumenInforme.Text = "Archivo .DAT copiado a disco local en: " + Environment.NewLine + dat_destino

                Dim sr As StreamReader = New StreamReader(dat_destino) ''prepara el lector del archivo
                lista_codigos_sucio.Clear()
                Do While sr.Peek() >= 0 ''recorre el archivo mientras tenga una linea siguiente
                    lista_codigos_sucio.Add(sr.ReadLine.Trim) ''quita los espacios de la linea y se guardan en la lista en "sucio"
                Loop
                sr.Close() ''cierra el lector del archivo

                txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine _
                                                                   + "Se cargaron los codigos a una lista temporal - Total de codigos = " _
                                                                   + lista_codigos_sucio.Count.ToString)

                poblar_gridListaCodigo(gridListaCodigos, lista_codigos_sucio)

            Catch ex As Exception

            End Try

        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnUbicacionProducto_Click(sender As Object, e As EventArgs) Handles btnUbicacionProducto.Click
        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Return
        End If


        Dim form As New ListadoUbicacionParAtado
        form.mostrar_todo = False
        form.nave_almacen = CStr(cboxNave.SelectedValue) + "," + CStr(cboxAlmacen.Text)
        form.filtroFechas = True
        form.lColaborador = colaborador.PColaboradorid
        form.cargaArchivo = True
        form.fechaInicio = fechaInicio
        form.fechaTermino = fechaTermino

        form.ShowDialog()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        fechainicio = Now.ToShortDateString.ToString + " " + Now.ToLongTimeString
        fechainicio = DateTime.Parse(fechainicio).ToString("yyyy/dd/MM HH:mm:ss")

        Cursor.Current = Cursors.WaitCursor

        txtResumenInforme.Text = String.Empty

        total_estibas = 0
        total_atados = 0
        total_pares = 0
        total_invalidos = 0
        total_destallados = 0
        total_errores_archivo = 0
        total_atado_estiba = 0
        total_pares_estiba = 0
        total_invalidos_estiba = 0

        procesar_codigos(lista_codigos_sucio)

        lblEstibas.Text = total_estibas.ToString
        lblAtados.Text = total_atados.ToString
        lblPares.Text = total_pares.ToString
        lblInvalidos.Text = total_invalidos.ToString
        lblErrores.Text = total_errores_archivo.ToString
        lblDestallados.Text = total_destallados.ToString

        Cursor.Current = Cursors.Default

        fechatermino = Now.ToShortDateString.ToString + " " + Now.ToLongTimeString
        fechatermino = DateTime.Parse(fechatermino).ToString("yyyy/dd/MM HH:mm:ss")

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        colaborador = Nothing
        colaborador_valido = False
        estiba_valida = False
        lista_codigos_sucio.Clear()
        gridListaCodigos.DataSource = Nothing
        gridListaCodigosCorrectos.DataSource = Nothing

    End Sub

    Public Sub procesar_codigos(lista_codigos_sucio As List(Of String))
        Dim lista_codigos As New List(Of String) ''lista que almacena los codigos sin duplicados
        Dim lista_codigo As New DataTable ''lista que almacena los codigos sin duplicados
        lista_codigo.Columns.Add("Código")
        lista_codigo.Columns.Add("Resultado")
        Dim duplicados As Integer

        For Each codigo In lista_codigos_sucio ''recorre todos los codigos en la lista en "sucio" para buscar duplicados

            If Not lista_codigos_sucio.IndexOf(codigo) = 0 Then
                ''realiza la busqueda dentro de la lista con el codigo actual y regresa el indice en caso de encontrarlo
                Dim index As Integer = lista_codigos.FindIndex(Function(c) c = codigo)

                If index > -1 Then ''verifica sí encontro que el codigo en turno ya existe dentro de la lista
                    'lista_codigos.RemoveAt(index) ''elimina el codigo que se encontraba previamente en la lista
                    lista_codigo.Rows.RemoveAt(index)
                    duplicados += 1
                Else
                    'lista_codigos.Add(codigo) ''inserta el codigo en turno al final de la lista en "limpio"
                    lista_codigo.Rows.Add(codigo, String.Empty)
                End If
            End If

        Next

        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "__________________________________________________")
        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "Codigos en archivo fuente: " _
                                                           + lista_codigos_sucio.Count.ToString + " - Codigos duplicados: " + duplicados.ToString)
        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "__________________________________________________")
        poblar_gridListaCodigoCorrecto(gridListaCodigosCorrectos, lista_codigo)

        lblRecuperados.Text = lista_codigos.Count.ToString

        For Each row In gridListaCodigosCorrectos.Rows
            verifica_lista_codigo(row)
            If row.Index = gridListaCodigosCorrectos.Rows.Count - 1 Then

                txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "  Atados: " + total_atado_estiba.ToString)
                txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "  Pares: " + total_pares_estiba.ToString)
                txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "  Inválidos: " + total_invalidos_estiba.ToString)

            End If
        Next

    End Sub

    Public Sub verifica_condiciones_iniciales_archivo(lista_codigos_sucio As List(Of String))
        colaborador = New Entidades.Colaborador
        Dim colaboradorBU As New Nomina.Negocios.ColaboradoresBU

        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "__________________________________________________")

        If Not IsNumeric(lista_codigos_sucio.Item(0)) Then ''verifica que el codigo sea numerico
            If lista_codigos_sucio.Item(0).ToUpper.Contains("EM") Then ''verifica que contenga los caracteres "em" del codigo de barras del colaborador
                If lista_codigos_sucio.Item(0).ToUpper.IndexOf("EM") = 0 Then ''verifica que contenga los caracteres "em" al inicio de la cadena de texto
                    ''verifica que el colaborador exista en la base de datos
                    colaborador = colaboradorBU.BuscarColaboradorGeneral(CInt(lista_codigos_sucio.Item(0).Remove(0, 2).ToString))

                    If colaborador.PActivo Then ''verifica que el colaborador se encuentre en estado activo
                        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine _
                                                                           + "Se encontró colaborador válido: " _
                                                                           + Environment.NewLine + colaborador.PNombreCompleto)
                        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "__________________________________________________")
                        lblColaboradorNombre.Visible = True
                        lblColaboradorNombre.Text = colaborador.PNombreCompleto
                        colaborador_valido = True
                    Else
                        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "Colaborador inválido: " + Environment.NewLine)
                        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "__________________________________________________")
                        colaborador_valido = False
                    End If

                End If
            End If
        End If

        If lista_codigos_sucio.Item(1).ToUpper.Contains("ES-") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
            Try
                verificar_estiba(lista_codigos_sucio.Item(1), Nothing)

                txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + _
                                                                   "Se encontró estiba válida: " _
                                                                   + Environment.NewLine + lista_codigos_sucio.Item(1))
                txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "__________________________________________________")
                estiba_valida = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If

        If colaborador_valido And estiba_valida Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If


    End Sub

    Private Sub verifica_lista_codigo(row As UltraGridRow)
        'colaborador = New Entidades.Colaborador
        Dim colaboradorBU As New Nomina.Negocios.ColaboradoresBU

        If String.IsNullOrEmpty(row.Cells(0).Text) Then Return

        Dim codigo As String = row.Cells(0).Text

        If Not IsNumeric(codigo) Then ''verifica que el codigo sea numerico
            If codigo.ToUpper.Contains("ES-") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
                Try
                    verificar_estiba(String.Empty, row)
                Catch ex As Exception
                    row.Appearance.BackColor = Color.Gray
                    row.Cells(1).Value = ex.ToString
                End Try

            Else
                If codigo.ToUpper.Contains("-") And codigo.Length >= 25 And codigo.Length <= 30 Then ''verifica "-" para posible par
                    Try
                        verificar_par(row)
                    Catch ex As Exception
                        row.Appearance.BackColor = Color.Gray
                        row.Cells(1).Value = ex.ToString
                    End Try
                Else
                    row.Appearance.BackColor = Color.Red
                    row.Cells(1).Value = "Código inválido"
                    total_invalidos_estiba = total_invalidos_estiba + 1
                    total_invalidos = total_invalidos + 1
                End If
            End If
        Else ''FIN If Not IsNumeric(codigo) Then
            If codigo.Length >= 11 And codigo.Length <= 13 Then ''verifica la extension del codigo
                Try
                    verificar_atado(row) ''verifica atado
                Catch ex As Exception
                    row.Appearance.BackColor = Color.Gray
                    row.Cells(1).Value = ex.ToString
                End Try
            Else
                row.Appearance.BackColor = Color.Red
                row.Cells(1).Value = "Código inválido"
                total_invalidos_estiba = total_invalidos_estiba + 1
                total_invalidos = total_invalidos + 1
            End If
        End If

    End Sub

    Public Sub verificar_estiba(codigo As String, row As UltraGridRow)

        If String.IsNullOrEmpty(codigo) Then
            codigo = row.Cells(0).Text
        End If

        If codigo.ToUpper.IndexOf("ES") = 0 Then ''verifica que contenga los caracteres "EM" al inicio de la cadena de texto
            Dim codigo_split As String() = codigo.Split("-")

            If codigo_split(2) = cboxNave.SelectedValue.ToString And codigo_split(3) = cboxAlmacen.SelectedValue.ToString Then
                Dim objBU As New AlmacenBU

                If objBU.Consulta_Estiba_Valido(codigo.Remove(0, 3)) Then ''verifica que la bahia exista en la base de datos
                    estiba_valida = True
                    estibaid = codigo.Remove(0, 3)
                    If Not IsNothing(row) Then
                        row.Appearance.BackColor = Color.DeepSkyBlue
                        If total_estibas > 0 Then
                            txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "  Atados: " + total_atado_estiba.ToString)
                            txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "  Pares: " + total_pares_estiba.ToString)
                            txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "  Inválidos: " + total_invalidos_estiba.ToString)
                        End If
                        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "__________________________________________________")
                        txtResumenInforme.Text = txtResumenInforme.Text + (Environment.NewLine + "Estiba válida: " + estibaid)

                        total_estibas = total_estibas + 1
                        total_atado_estiba = 0
                        total_pares_estiba = 0
                        total_invalidos_estiba = 0
                    End If
                Else
                    show_message("Advertencia", "Presente código de estiba válido" + vbCr + "Código inválido: " + codigo)
                    estiba_valida = False
                    estibaid = Nothing
                End If

            Else
                show_message("Advertencia", "Presente código de estiba válido" + vbCr + "Código inválido: " + codigo)
                estiba_valida = False
                estibaid = Nothing
            End If

        End If

    End Sub

    Public Sub verificar_atado(row As UltraGridRow)

        Dim codigo As String = row.Cells(0).Text

        Dim objBU As New AlmacenBU
        If estiba_valida Then '' tiene estiba valida
            If objBU.Consulta_Atado_Valido(codigo, False) Then ''VERIFICA SI EL ATADO ES VALIDO 
                atado_en_ubicacion_atado = True
                Try
                    guardar_ubicacion(colaborador.PColaboradorid, estibaid, codigo, True, 0)
                    row.Appearance.BackColor = Color.Aquamarine
                    row.Cells(1).Value = "Guardado como atado"
                    total_atado_estiba = total_atado_estiba + 1
                    total_atados = total_atados + 1

                Catch ex As Exception
                    row.Appearance.BackColor = Color.Gray
                    row.Cells(1).Value = ex.ToString
                    total_errores_archivo = total_errores_archivo + 1
                End Try

            Else
                If objBU.Consulta_Atado_En_Ubicacion_Pares(codigo) Then
                    row.Appearance.BackColor = Color.Yellow
                    row.Cells(1).Value = "Atado destallado - No se actualizó la ubicación"
                    total_destallados = total_destallados + 1
                Else
                    If objBU.Consulta_Atado_tmpDocenasPares(codigo) Then
                        Try
                            guardar_ubicacion(colaborador.PColaboradorid, estibaid, codigo, True, 0)
                            row.Appearance.BackColor = Color.Aquamarine
                            row.Cells(1).Value = "Guardado como atado"
                            total_atado_estiba = total_atado_estiba + 1
                            total_atados = total_atados + 1
                        Catch ex As Exception
                            row.Appearance.BackColor = Color.Gray
                            row.Cells(1).Value = ex.ToString
                            total_errores_archivo = total_errores_archivo + 1
                        End Try

                    Else
                        row.Appearance.BackColor = Color.Red
                        row.Cells(1).Value = "Código inválido"
                        total_invalidos_estiba = total_invalidos_estiba + 1
                        total_invalidos = total_invalidos + 1
                    End If
                End If
            End If
        Else
            show_message("Advertencia", "Presente código de estiba válido")
        End If

        atado_en_ubicacion_atado = False

    End Sub

    Public Sub verificar_par(row As UltraGridRow)

        Dim codigo As String = row.Cells(0).Text

        Dim codigo_split As String() = codigo.Split("-") ''parte la cadena
        If codigo_split.Length = 3 Then
            Dim objBU As New AlmacenBU

            If estiba_valida Then '' tiene estiba valida
                If codigo_split(2).Length = 11 Then ''verifica que la extension del codigo conincida con la extension del codigo de pares
                    If objBU.Consulta_Par_Valido(codigo_split(2)) Then ''verifica que el codigo pertenesca a un par valido
                        par_en_ubicacion_par = True
                        Try
                            guardar_ubicacion(colaborador.PColaboradorid, estibaid, codigo, False, 0)
                            row.Appearance.BackColor = Color.Khaki
                            row.Cells(1).Value = "Guardado como par"
                            total_pares_estiba = total_pares_estiba + 1
                            total_pares = total_pares + 1
                        Catch ex As Exception
                            row.Appearance.BackColor = Color.Gray
                            row.Cells(1).Value = ex.ToString
                            total_errores_archivo = total_errores_archivo + 1
                        End Try

                    Else
                        If objBU.Consulta_Par_tmpDocenasPares(codigo_split(2)) Then
                            Try
                                guardar_ubicacion(colaborador.PColaboradorid, estibaid, codigo, False, 0)
                                row.Appearance.BackColor = Color.Khaki
                                row.Cells(1).Value = "Guardado como par"
                                total_pares_estiba = total_pares_estiba + 1
                                total_pares = total_pares + 1
                            Catch ex As Exception
                                row.Appearance.BackColor = Color.Gray
                                row.Cells(1).Value = ex.ToString
                                total_errores_archivo = total_errores_archivo + 1
                            End Try

                        Else
                            row.Appearance.BackColor = Color.Red
                            row.Cells(1).Value = "Código inválido"
                            total_invalidos_estiba = total_invalidos_estiba + 1
                            total_invalidos = total_invalidos + 1
                        End If
                    End If
                End If
            Else
                show_message("Advertencia", "Presente código de estiba válido")
            End If

        End If

        par_en_ubicacion_par = False

    End Sub

    Public Sub guardar_ubicacion(ByVal colaboradorid As Integer, ByVal estibaid As String, _
                                 ByVal codigo As String, ByVal es_atado As Boolean, _
                                 ByVal carritoid As Integer)

        Dim objBU As New AlmacenBU

        Dim nave As Integer
        Dim lote As Integer
        Dim atado As Integer
        Dim anio As Integer
        Dim pares As Integer

        If es_atado Then '' es atado

            If atado_en_ubicacion_atado Then ''Edita la ubicacion

                objBU.editar_ubicacion_atado(estibaid, codigo, colaboradorid, carritoid)

            Else ''Ingresa por primera veza UbicacionAtado

                nave = CInt(codigo(0).ToString + codigo(1).ToString)
                lote = CInt(codigo(2).ToString + codigo(3).ToString + codigo(4).ToString + codigo(5).ToString + codigo(6).ToString)
                atado = CInt(codigo(7).ToString + codigo(8).ToString)
                anio = CInt(codigo(9).ToString)
                pares = CInt(codigo(10).ToString)

                objBU.alta_ubicacion_atado(estibaid, codigo, pares, lote, nave, colaboradorid, carritoid)

            End If

        Else ''es par
            Dim codigo_split As String() = codigo.Split("-")
            codigo = codigo_split(2)

            If par_en_ubicacion_par Then ''Verifica si ya existe en ubicacionPares

                objBU.editar_ubicacion_par(estibaid, codigo, colaboradorid)

            Else ''Ingresa por primera vez a UbicacionPares

                nave = CInt(codigo(0).ToString + codigo(1).ToString)
                lote = CInt(codigo(2).ToString + codigo(3).ToString + codigo(4).ToString + codigo(5).ToString + codigo(6).ToString)
                objBU.alta_ubicacion_par(estibaid, codigo, lote, nave, colaboradorid)

            End If

        End If

    End Sub

    Public Sub poblar_gridListaCodigo(grid As Infragistics.Win.UltraWinGrid.UltraGrid, lista_codigos_sucio As List(Of String))

        grid.DataSource = Nothing
        grid.DataSource = lista_codigos_sucio
        gridListaCodigoDiseno(grid)
        verifica_condiciones_iniciales_archivo(lista_codigos_sucio)

    End Sub

    Private Sub gridListaCodigoDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns(0).Header.Caption = "Códigos en archivo .DAT"
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.False
            '.Override.FilterUIType = FilterUIType.HeaderIcons
            .Override.HeaderClickAction = Nothing
            .Override.AllowAddNew = AllowAddNew.No
            .MaxRowScrollRegions = 1
        End With

    End Sub

    Public Sub poblar_gridListaCodigoCorrecto(grid As Infragistics.Win.UltraWinGrid.UltraGrid, lista_codigo As DataTable)

        grid.DataSource = Nothing
        estiba_valida = False

        Dim objBU As New Negocios.ClientesAlmacenBU
        Dim Tabla_ListaUbicacion As New DataTable

        If lista_codigo.Rows.Count > 0 Then
            lblFechaReporteProductividad.Visible = True
            lblHoraReporteProductividad.Visible = True
            lblFechaReporteProductividad.Text = Date.Now.ToShortDateString
            lblHoraReporteProductividad.Text = Date.Now.ToShortTimeString
        End If

        grid.DataSource = lista_codigo
        gridListaCodigoCorrectoDiseno(grid)

    End Sub

    Private Sub gridListaCodigoCorrectoDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns(0).Header.Caption = "Lista de códigos correctos"
            '.PerformAutoResizeColumns(FalSe, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ExtendLastColumn
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.FilterUIType = FilterUIType.HeaderIcons
            .Override.HeaderClickAction = Nothing
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy
            .MaxRowScrollRegions = 1
        End With

    End Sub

#Region "OTRAS ACCIONES DE APOYO"

    'Muestra el form de mensaje
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

#End Region

End Class
