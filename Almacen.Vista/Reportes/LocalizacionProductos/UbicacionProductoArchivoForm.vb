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
    Dim lista_codigos_sucio, lista_carrito As New List(Of String)
    Dim carritoid, estibaid As String
    Dim colaborador_valido, carrito_valido, sin_carrito, estiba_valida,
        atado_en_ubicacion_atado, par_en_ubicacion_par, pares_en_apartado As Boolean

    Dim total_estibas, total_atados, total_pares, total_invalidos, total_destallados, total_errores_archivo,
        total_atado_estiba, total_pares_estiba, total_invalidos_estiba,
        total_apartado, total_pares_apartado, total_plataformas, total_atados_plataforma, total_atados_no_pertenece As Integer

    Dim fechaInicio, fechaTermino As String
    Dim PrimeraCarga As Boolean = True

    Private Sub UbicacionProductoArchivoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listado_naves()
        PrimeraCarga = False
    End Sub

    Private Sub listado_naves()
        Try
            'Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
            Dim objbu As New Almacen.Negocios.AlmacenBU
            Dim dtInformacionCentroDistribucion As DataTable
            Dim dtNumeroAlmacenes As DataTable

            Try

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_UBICACIONES", "VER_ALM_ASIGNADO") Then
                    dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                Else
                    dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivos()
                End If

                cboxNave.DataSource = dtInformacionCentroDistribucion
                cboxNave.DisplayMember = "Nave"
                cboxNave.ValueMember = "NaveSAYID"

                cboxNave.SelectedIndex = 0

                If cboxNave.SelectedIndex = 0 Then
                    dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNave.SelectedValue)
                    cboxAlmacen.DataSource = dtNumeroAlmacenes
                    cboxAlmacen.ValueMember = "NumeroAlmacen"
                    cboxAlmacen.DisplayMember = "NumeroAlmacen"
                    cboxAlmacen.SelectedIndex = 0
                End If



                'Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
        'If cboxNave.SelectedIndex = 1 Then
        '    listado_almacen()
        'End If

    End Sub

    Private Sub listado_almacen()

        Try
            'Controles.ComboAlmacenSegunNave(cboxAlmacen, CInt(cboxNave.SelectedValue))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCargarArchivoDAT_Click(sender As Object, e As EventArgs) Handles btnCargarArchivoDAT.Click

        Cursor.Current = Cursors.WaitCursor

        total_estibas = 0
        total_plataformas = 0
        total_atados_plataforma = 0
        total_atados_no_pertenece = 0
        total_atados = 0
        total_pares = 0
        total_invalidos = 0
        total_destallados = 0
        total_errores_archivo = 0
        total_atado_estiba = 0
        total_pares_estiba = 0
        total_invalidos_estiba = 0
        total_pares_apartado = 0
        lista_carrito.Clear()
        If cboxNave.SelectedValue = 0 Or IsNothing(cboxNave.SelectedValue) Then
            show_message("Aviso", "Debe seleccionar un almacén")
            Return
        End If

        Dim fileExplorer As New OpenFileDialog()

        Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString +
                              Now.Day.ToString + "_" + Now.Hour.ToString +
                              Now.Minute.ToString + Now.Second.ToString ''obtiene la fecha y hora para el respaldo

        fileExplorer.InitialDirectory = "c:\"
        fileExplorer.Filter = "All Files (*.*)|*.*" & "|Data Files (*.dat)|*.dat"
        fileExplorer.FilterIndex = 2
        fileExplorer.RestoreDirectory = True

        If fileExplorer.ShowDialog() = DialogResult.OK Then
            gridListaCodigosCorrectos_SinCarrito.DataSource = Nothing
            gridListaCodigos_SinPlataforma.DataSource = Nothing
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
                Dim resumen As String
                'txtResumenInforme_SinCarrito.Text
                resumen = "Archivo .DAT copiado a disco local en: " + Environment.NewLine + dat_destino

                Dim sr As StreamReader = New StreamReader(dat_destino) ''prepara el lector del archivo
                lista_codigos_sucio.Clear()
                Do While sr.Peek() >= 0 ''recorre el archivo mientras tenga una linea siguiente
                    lista_codigos_sucio.Add(sr.ReadLine.Trim) ''quita los espacios de la linea y se guardan en la lista en "sucio"
                Loop
                sr.Close() ''cierra el lector del archivo


                'txtResumenInforme_SinCarrito.Text 
                resumen = resumen + (Environment.NewLine _
                                                                   + "Se cargaron los codigos a una lista temporal - Total de codigos = " _
                                                                   + lista_codigos_sucio.Count.ToString)


                If tabCon_Sin_Plataforma.SelectedTab.Name = tpgSinPlataforma.Name Then
                    poblar_gridListaCodigo(gridListaCodigos_SinPlataforma, lista_codigos_sucio)
                    txtResumenInforme_SinCarrito.Text = resumen
                ElseIf tabCon_Sin_Plataforma.SelectedTab.Name = tpgConPlataforma.Name Then
                    poblar_gridListaCodigo(gridListaCodigos_ConPlataforma, lista_codigos_sucio)
                    txtResumenInforme_ConCarrito.Text = resumen
                End If

            Catch ex As Exception

            End Try

        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnUbicacionProducto_Click(sender As Object, e As EventArgs) Handles btnUbicacionProducto.Click

        'If tabCon_Sin_Plataforma.SelectedTab.Name = tpgSinPlataforma.Name Then
        'ElseIf tabCon_Sin_Plataforma.SelectedTab.Name = tpgConPlataforma.Name Then
        '    'If gridListaCodigosCorrectos_ConCarrito.Rows.Count = 0 Or gridListaCodigosCorrectos_SinCarrito.Rows.Count = 0 Then Return
        'End If

        Dim form As New ListadoUbicacionParAtado
        form.mostrar_todo = False
        form.Filtros.FechaInicio = fechaInicio
        form.Filtros.FechaFin = fechaTermino
        form.Filtros.Operador = colaborador.PColaboradorid
        'form.Filtros.NaveID = CStr(cboxNave.SelectedValue) + "," + CStr(cboxAlmacen.Text)
        form.Filtros.NaveID = CStr(cboxNave.SelectedValue)
        form.Filtros.Almacen = CStr(cboxAlmacen.Text)
        form.cargaArchivo = True
        form.Show()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim objBU As New ClientesAlmacenBU
        Dim objBUAlmacen As New Negocios.AlmacenBU
        Try
            'objBUAlmacen.Actualizar_FechaSalidaNave()
            'objBUAlmacen.Actualizar_GeneraUbicaciones()
        Catch ex As Exception

        End Try
        total_apartado = 0
        'fechaInicio = Now.ToShortDateString.ToString + " " + Now.ToLongTimeString
        fechaInicio = CStr(objBU.Obtener_Datetime_Servidor())
        fechaInicio = DateTime.Parse(fechaInicio).ToString("yyyy/dd/MM HH:mm:ss")

        Cursor.Current = Cursors.WaitCursor

        txtResumenInforme_SinCarrito.Text = String.Empty

        total_estibas = 0
        total_plataformas = 0
        total_atados_plataforma = 0
        total_atados_no_pertenece = 0
        total_atados = 0
        total_pares = 0
        total_invalidos = 0
        total_destallados = 0
        total_errores_archivo = 0
        total_atado_estiba = 0
        total_pares_estiba = 0
        total_invalidos_estiba = 0
        total_pares_apartado = 0
        lista_carrito.Clear()

        procesar_codigos(lista_codigos_sucio)

        If tabCon_Sin_Plataforma.SelectedTab.Name = tpgSinPlataforma.Name Then

            lblEstibas.Text = total_estibas.ToString
            lblAtados.Text = total_atados.ToString
            lblPares.Text = total_pares.ToString
            lblInvalidos.Text = total_invalidos.ToString
            lblErrores.Text = total_errores_archivo.ToString
            lblDestallados.Text = total_destallados.ToString
            lblApartados.Text = total_apartado.ToString
            lblParesApartado.Text = total_pares_apartado.ToString

        ElseIf tabCon_Sin_Plataforma.SelectedTab.Name = tpgConPlataforma.Name Then

            lblEstibasConCarrito.Text = total_estibas.ToString
            lblPlataformasValidas.Text = total_plataformas.ToString
            lblAtadosConCarrito.Text = total_atados.ToString
            'lblPares.Text = total_pares.ToString
            lblInvalidosConCarrito.Text = total_invalidos.ToString
            lblCodigoInexistenteEnPlataforma.Text = total_atados_no_pertenece.ToString
            lblErroresConCarrito.Text = total_errores_archivo.ToString
            'lblDestallados.Text = total_destallados.ToString
            'lblApartados.Text = total_apartado.ToString
            'lblParesApartado.Text = total_pares_apartado.ToString

        End If

        colaborador_valido = False
        carrito_valido = False
        sin_carrito = False
        estiba_valida = False
        atado_en_ubicacion_atado = False
        par_en_ubicacion_par = False

        Cursor.Current = Cursors.Default

        'fechaTermino = Now.ToShortDateString.ToString + " " + Now.ToLongTimeString
        fechaTermino = CDate(objBU.Obtener_Datetime_Servidor()).AddSeconds(1)
        fechaTermino = DateTime.Parse(fechaTermino).ToString("yyyy/dd/MM HH:mm:ss")

        Dim lista_de_carritos As String = String.Empty
        For Each Carrito In lista_carrito
            If lista_carrito.IndexOf(Carrito) = 0 Then
                lista_de_carritos += Carrito
            Else
                lista_de_carritos += ", " + Carrito
            End If
        Next
        If Not String.IsNullOrEmpty(lista_de_carritos) Then
            poblar_gridListaPlataforma(gridListaPlataforma, lista_de_carritos)
        Else
            gridListaPlataforma.DataSource = Nothing
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        colaborador = Nothing
        colaborador_valido = False
        estiba_valida = False
        lista_codigos_sucio.Clear()
        gridListaCodigos_SinPlataforma.DataSource = Nothing
        gridListaCodigosCorrectos_SinCarrito.DataSource = Nothing

    End Sub

    Private Sub btnValidar_Plataforma_Click(sender As Object, e As EventArgs) Handles btnValidar_Plataforma.Click
        If Not Me.gridListaPlataforma.ActiveRow.IsDataRow Then Return

        If IsNothing(gridListaPlataforma.ActiveRow) Then Return
        Dim row As UltraGridRow = gridListaPlataforma.ActiveRow

        If Not row.Cells("STATUS ID").Value = 21 Then Return

        If Not row.Cells(0).Value Then Return

        Dim objBU As New AlmacenBU
        Try
            objBU.Editar_Status_Plataforma(2, row.Cells("PLATAFORMA ID").Value, 22)
            show_message("Exito", "Plataforma válidada con éxito")
        Catch ex As Exception
            show_message("Error", ex.ToString)
        End Try
        row.Appearance.BackColor = Color.Blue
        row.Cells("STATUS ID").Value = 22


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
                    'lista_codigo.Rows.RemoveAt(index)
                    duplicados += 1
                    'lista_codigos.Add(codigo) ''inserta el codigo en turno al final de la lista en "limpio"
                    'lista_codigo.Rows.Add(codigo, String.Empty)
                Else
                    lista_codigos.Add(codigo) ''inserta el codigo en turno al final de la lista en "limpio"
                    lista_codigo.Rows.Add(codigo, String.Empty)
                End If
            End If

        Next

        If tabCon_Sin_Plataforma.SelectedTab.Name = tpgSinPlataforma.Name Then
            txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "__________________________________________________")
            txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "Codigos en archivo fuente: " _
                                                               + lista_codigos_sucio.Count.ToString + " - Codigos duplicados: " + duplicados.ToString)
            txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "__________________________________________________")
            poblar_gridListaCodigoCorrecto(gridListaCodigosCorrectos_SinCarrito, lista_codigo)

            lblRecuperados.Text = lista_codigos.Count.ToString

            For Each row In gridListaCodigosCorrectos_SinCarrito.Rows
                verifica_lista_codigo(row)
                If row.Index = gridListaCodigosCorrectos_SinCarrito.Rows.Count - 1 Then

                    txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "  Atados: " + total_atado_estiba.ToString)
                    txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "  Pares: " + total_pares_estiba.ToString)
                    txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "  Inválidos: " + total_invalidos_estiba.ToString)

                End If
            Next
            lblRecuperados.Text = gridListaCodigosCorrectos_SinCarrito.Rows.Count.ToString
        ElseIf tabCon_Sin_Plataforma.SelectedTab.Name = tpgConPlataforma.Name Then

            txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "__________________________________________________")
            txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "Codigos en archivo fuente: " _
                                                               + lista_codigos_sucio.Count.ToString + " - Codigos duplicados: " + duplicados.ToString)
            txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "__________________________________________________")
            poblar_gridListaCodigoCorrecto(gridListaCodigosCorrectos_ConCarrito, lista_codigo)

            lblRecuperadosConCarrito.Text = lista_codigos.Count.ToString

            For Each row In gridListaCodigosCorrectos_ConCarrito.Rows

                verifica_lista_codigo(row)
                If row.Index = gridListaCodigosCorrectos_ConCarrito.Rows.Count - 1 Then

                    txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "  Atados: " + total_atado_estiba.ToString)
                    txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "  Pares: " + total_pares_estiba.ToString)
                    txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "  Inválidos: " + total_invalidos_estiba.ToString)

                End If
            Next
            lblRecuperadosConCarrito.Text = gridListaCodigosCorrectos_ConCarrito.Rows.Count.ToString

        End If



    End Sub

    Public Sub verifica_condiciones_iniciales_archivo_Sin_Carrito(lista_codigos_sucio As List(Of String))
        colaborador = New Entidades.Colaborador
        Dim colaboradorBU As New Nomina.Negocios.ColaboradoresBU

        txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "__________________________________________________")

        If Not IsNumeric(lista_codigos_sucio.Item(0)) Then ''verifica que el codigo sea numerico
            If lista_codigos_sucio.Item(0).ToUpper.Contains("EM") Then ''verifica que contenga los caracteres "em" del codigo de barras del colaborador
                If lista_codigos_sucio.Item(0).ToUpper.IndexOf("EM") = 0 Then ''verifica que contenga los caracteres "em" al inicio de la cadena de texto
                    ''verifica que el colaborador exista en la base de datos
                    colaborador = colaboradorBU.BuscarColaboradorGeneral(CInt(lista_codigos_sucio.Item(0).Remove(0, 2).ToString))

                    If colaborador.PActivo Then ''verifica que el colaborador se encuentre en estado activo
                        txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine _
                                                                           + "Se encontró colaborador válido: " _
                                                                           + Environment.NewLine + colaborador.PNombreCompleto)
                        txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "__________________________________________________")
                        lblColaboradorNombre.Visible = True
                        lblColaboradorNombre.Text = colaborador.PNombreCompleto
                        colaborador_valido = True
                    Else
                        txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "Colaborador inválido: " + Environment.NewLine)
                        txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "__________________________________________________")
                        colaborador_valido = False
                    End If

                End If
            End If
        End If

        If lista_codigos_sucio.Item(1).ToUpper.Contains("ES-") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
            Try
                verificar_estiba(lista_codigos_sucio.Item(1), Nothing)

                txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine +
                                                                   "Se encontró estiba válida: " _
                                                                   + Environment.NewLine + lista_codigos_sucio.Item(1))
                txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "__________________________________________________")
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

    Public Sub verifica_condiciones_iniciales_archivo_Con_Carrito(lista_codigos_sucio As List(Of String))
        colaborador = New Entidades.Colaborador
        Dim colaboradorBU As New Nomina.Negocios.ColaboradoresBU

        txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "__________________________________________________")

        If Not IsNumeric(lista_codigos_sucio.Item(0)) Then ''verifica que el codigo sea numerico
            If lista_codigos_sucio.Item(0).ToUpper.Contains("EM") Then ''verifica que contenga los caracteres "em" del codigo de barras del colaborador
                If lista_codigos_sucio.Item(0).ToUpper.IndexOf("EM") = 0 Then ''verifica que contenga los caracteres "em" al inicio de la cadena de texto
                    ''verifica que el colaborador exista en la base de datos
                    colaborador = colaboradorBU.BuscarColaboradorGeneral(CInt(lista_codigos_sucio.Item(0).Remove(0, 2).ToString))

                    If colaborador.PActivo Then ''verifica que el colaborador se encuentre en estado activo
                        txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine _
                                                                           + "Se encontró colaborador válido: " _
                                                                           + Environment.NewLine + colaborador.PNombreCompleto)
                        txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "__________________________________________________")
                        Label29.Visible = True
                        Label29.Text = colaborador.PNombreCompleto
                        colaborador_valido = True
                    Else
                        txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "Colaborador inválido: " + Environment.NewLine)
                        txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "__________________________________________________")
                        colaborador_valido = False
                    End If

                End If
            End If
        End If

        If lista_codigos_sucio.Item(1).ToUpper.Contains("PLAT-") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
            Try
                verificar_carrito(lista_codigos_sucio.Item(1), Nothing)

                txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine +
                                                                   "Se encontró plataforma válida: " _
                                                                   + Environment.NewLine + lista_codigos_sucio.Item(1))
                txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "__________________________________________________")

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If

        If lista_codigos_sucio.Item(2).ToUpper.Contains("ES-") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
            Try
                verificar_estiba(lista_codigos_sucio.Item(2), Nothing)

                txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine +
                                                                   "Se encontró estiba válida: " _
                                                                   + Environment.NewLine + lista_codigos_sucio.Item(2))
                txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "__________________________________________________")

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
        Dim codigo_split As String() = codigo.Split("-") ''parte la cadena
        '' ''MsgBox("Apartado " + codigo.ToString)
        If Not IsNumeric(codigo) Then ''verifica que el codigo sea numerico
            If codigo.ToUpper.Contains("ES-") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
                Try
                    verificar_estiba(String.Empty, row)
                Catch ex As Exception
                    row.Appearance.BackColor = Color.Gray
                    row.Cells(1).Value = ex.ToString
                End Try

            Else
                If lista_codigos_sucio.Item(1).ToUpper.Contains("PLAT-") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
                    Try ''AQUI ESTA EL PEDO PARA LEER DE VARIOS CARRITOS
                        'If String.IsNullOrEmpty(carritoid) Then
                        '    verificar_carrito(lista_codigos_sucio.Item(1), row)
                        'Else
                        verificar_carrito(Nothing, row)
                        'End If
                    Catch ex As Exception
                        row.Appearance.BackColor = Color.Red
                        row.Cells(1).Value = "Código inválido"
                        total_invalidos = total_invalidos + 1
                    End Try
                Else
                    If Not carrito_valido Then
                        If codigo_split.LongLength = 3 Then ''verifica "-" para posible par
                            Try
                                verificar_par(row)
                            Catch ex As Exception
                                row.Appearance.BackColor = Color.Gray
                                row.Cells(1).Value = ex.ToString
                            End Try
                        Else

                            Try
                                If codigo(0).ToString.ToUpperInvariant.Equals("A") And codigo(1).ToString.ToUpperInvariant.Equals("P") Then
                                    verificar_apartado(row)
                                Else
                                    row.Appearance.BackColor = Color.Red
                                    row.Cells(1).Value = "Código inválido"
                                    total_invalidos_estiba = total_invalidos_estiba + 1
                                    total_invalidos = total_invalidos + 1
                                End If
                            Catch ex As Exception

                            End Try

                        End If
                    Else
                        row.Appearance.BackColor = Color.Red
                        row.Cells(1).Value = "Código inválido"
                        total_invalidos_estiba = total_invalidos_estiba + 1
                        total_invalidos = total_invalidos + 1
                    End If
                End If
            End If
        Else ''FIN If Not IsNumeric(codigo) Then
            If codigo_split.LongLength = 1 Then ''verifica la extension del codigo
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


    Public Sub verificar_carrito(codigo As String, row As UltraGridRow)

        If String.IsNullOrEmpty(codigo) Then
            codigo = row.Cells(0).Text
        End If

        Dim objBU As New AlmacenBU
        Dim tabla As New DataTable
        tabla = objBU.Consulta_Carrito_Valido(codigo.Remove(0, 5))
        If tabla.Rows.Count > 0 Then ''verifica que el codigo pertenesca a un par valido
            carrito_valido = True
            total_plataformas += 1
            lista_carrito.Add(codigo.Remove(0, 5))
            sin_carrito = False
            carritoid = codigo.Remove(0, 5)
            If Not IsNothing(row) Then
                row.Appearance.BackColor = Color.CornflowerBlue
            End If
            'Dim faltantes As Integer = objBU.Consulta_Ocupacion_SinUbicar_Carrito(carritoid)
            'If faltantes > 0 Then
            '    'lblFaltantes.Text = faltantes
            '    'lblLeidos.Text = "0"

            '    Me.Close()
            '    Dim form As New LecturaEstibaForm
            '    form.colaborador = colaborador
            '    form.fechaInicio = fechaInicio
            '    form.sin_carrito = False
            '    form.carrito_valido = True
            '    form.plataformas_pendientes = True
            '    form.carritoid = carritoid
            '    form.carrito_desc = tabla.Rows(0).Item("carr_descripcion")
            '    form.Show()
            'Else

            '    MessageBox.Show("Plataforma sin contenido: " + codigo)
            'End If

        Else

            carrito_valido = False
            carritoid = Nothing
            'estiba_valida = False
            'estibaid = Nothing
            MessageBox.Show("Código inválido o plataforma sin contenido " + codigo)
        End If
    End Sub

    Public Sub verificar_estiba(codigo As String, row As UltraGridRow)

        If String.IsNullOrEmpty(codigo) Then
            codigo = row.Cells(0).Text
        End If

        If codigo.ToUpper.IndexOf("ES") = 0 Then ''verifica que contenga los caracteres "EM" al inicio de la cadena de texto
            Dim codigo_split As String() = codigo.Split("-")

            If sin_carrito And Not carrito_valido Then
                show_message("Advertencia", "Presente código de plataforma válido" + Environment.NewLine + "o seleccione trabajar sin plataforma")
            Else
                If codigo_split(2) = cboxNave.SelectedValue.ToString And codigo_split(3) = cboxAlmacen.SelectedValue.ToString Then
                    Dim objBU As New AlmacenBU

                    If objBU.Consulta_Estiba_Valido(codigo.Remove(0, 3)) Then ''verifica que la bahia exista en la base de datos
                        estiba_valida = True
                        estibaid = codigo.Remove(0, 3)
                        If Not IsNothing(row) Then
                            row.Appearance.BackColor = Color.DeepSkyBlue
                            If tabCon_Sin_Plataforma.SelectedTab.Name = tpgSinPlataforma.Name Then
                                If total_estibas > 0 Then
                                    txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "  Atados: " + total_atado_estiba.ToString)
                                    txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "  Pares: " + total_pares_estiba.ToString)
                                    txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "  Inválidos: " + total_invalidos_estiba.ToString)
                                End If
                                txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "__________________________________________________")
                                txtResumenInforme_SinCarrito.Text = txtResumenInforme_SinCarrito.Text + (Environment.NewLine + "Estiba válida: " + estibaid)

                                total_estibas = total_estibas + 1
                                total_atado_estiba = 0
                                total_pares_estiba = 0
                                total_invalidos_estiba = 0
                            ElseIf tabCon_Sin_Plataforma.SelectedTab.Name = tpgConPlataforma.Name Then
                                If total_estibas > 0 Then
                                    txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "  Atados: " + total_atado_estiba.ToString)
                                    txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "  Pares: " + total_pares_estiba.ToString)
                                    txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "  Inválidos: " + total_invalidos_estiba.ToString)
                                End If
                                txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "__________________________________________________")
                                txtResumenInforme_ConCarrito.Text = txtResumenInforme_ConCarrito.Text + (Environment.NewLine + "Estiba válida: " + estibaid)

                                total_estibas = total_estibas + 1
                                total_atado_estiba = 0
                                total_pares_estiba = 0
                                total_invalidos_estiba = 0
                            End If

                        End If
                    Else
                        show_message("Advertencia", "Presente código de estiba válido" + Environment.NewLine + "Código inválido: " + codigo)
                        estiba_valida = False
                        estibaid = Nothing
                    End If

                Else
                    show_message("Advertencia", "Presente código de estiba válido" + Environment.NewLine + "Código inválido: " + codigo)
                    estiba_valida = False
                    estibaid = Nothing
                End If
            End If

        End If

    End Sub

    Public Sub verificar_atado(row As UltraGridRow)

        Dim codigo As String = row.Cells(0).Text

        Dim objBU As New AlmacenBU
        If estiba_valida Then '' tiene estiba valida
            If objBU.Consulta_Atado_Valido(codigo, carrito_valido) Then ''VERIFICA SI EL ATADO ES VALIDO 
                atado_en_ubicacion_atado = True

                Try
                    guardar_ubicacion(colaborador.PColaboradorid, estibaid, codigo, True, carritoid)
                    If carrito_valido Then
                        row.Appearance.BackColor = Color.Aquamarine
                        row.Cells(1).Value = "Guardado como atado - Plataforma: " + carritoid
                    Else
                        row.Appearance.BackColor = Color.Aquamarine
                        row.Cells(1).Value = "Guardado como atado"
                    End If
                    total_atado_estiba = total_atado_estiba + 1
                    If carrito_valido Then
                        total_atados_plataforma += 1
                    End If
                    total_atados = total_atados + 1
                Catch ex As Exception
                    row.Appearance.BackColor = Color.Gray
                    row.Cells(1).Value = ex.ToString
                    total_errores_archivo = total_errores_archivo + 1
                End Try

            Else
                If carrito_valido Then
                    row.Appearance.BackColor = Color.Wheat
                    row.Cells(1).Value = "Atado no pertenece a la plataforma o es un codigo inválido"
                    total_atados_no_pertenece += 1
                Else
                    If objBU.Consulta_Atado_En_Ubicacion_Pares(codigo) Then
                        row.Appearance.BackColor = Color.Yellow
                        row.Cells(1).Value = "Atado destallado - No se actualizó la ubicación"
                        total_destallados = total_destallados + 1
                    Else
                        If objBU.Consulta_Atado_tmpDocenasPares(codigo) Then
                            Try
                                guardar_ubicacion(colaborador.PColaboradorid, estibaid, codigo, True, carritoid)
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
                'If codigo_split(2).Length >= 10 And codigo_split(2).Length <= 13 Then ''verifica que la extension del codigo conincida con la extension del codigo de pares
                If codigo_split.Length = 3 Then
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

    Public Sub verificar_apartado(row As UltraGridRow)
        Dim codigo As String = row.Cells(0).Text

        Dim objBU As New AlmacenBU
        If estiba_valida Then '' tiene estiba valida
            If objBU.Consulta_Apartado_Valido(codigo.Remove(0, 2)) Then ''VERIFICA SI EL ATADO ES VALIDO 
                Dim tabla As New DataTable
                tabla = objBU.Consulta_Pares_en_Apartado(codigo.Remove(0, 2))
                row.ToolTipText = "El Apartado: " + codigo.ToString + " contiene: " + tabla.Rows.Count.ToString + " prs"

                pares_en_apartado = True
                Try
                    For Each fila As DataRow In tabla.Rows
                        ' '' ''If estibaid = "" Or estibaid Is DBNull.Value Then
                        ' '' ''    MsgBox("estiba sin nada")
                        ' '' ''End If
                        guardar_ubicacion(colaborador.PColaboradorid, estibaid, "--" + fila.Item(0).ToString, False, 0)
                        row.ToolTipText = row.ToolTipText.ToString + Environment.NewLine + fila.Item(0).ToString
                    Next
                    row.Appearance.BackColor = Color.MediumOrchid
                    row.Cells(1).Value = "Apartado válido"
                    'total_pares_estiba = total_pares_estiba + tabla.Rows.Count
                    'total_pares = total_pares + tabla.Rows.Count
                    total_apartado += 1
                    total_pares_apartado += tabla.Rows.Count
                Catch ex As Exception
                    row.Appearance.BackColor = Color.Gray
                    row.Cells(1).Value = ex.ToString
                    total_errores_archivo = total_errores_archivo + 1
                End Try

                pares_en_apartado = False
            Else
                row.Appearance.BackColor = Color.Red
                row.Cells(1).Value = "Código inválido (Apartado sin pares)"
                total_invalidos_estiba = total_invalidos_estiba + 1
                total_invalidos = total_invalidos + 1
            End If
        Else
            show_message("Advertencia", "Presente código de estiba válido")
        End If
    End Sub


    Public Sub guardar_ubicacion(ByVal colaboradorid As Integer, ByVal estibaid As String,
                                 ByVal codigo As String, ByVal es_atado As Boolean,
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

            Else ''Ingresa por primera vez a UbicacionAtado

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
            If pares_en_apartado Then
                If objBU.Consulta_par_contenido_atado(codigo) Then
                    nave = CInt(codigo(0).ToString + codigo(1).ToString)
                    lote = CInt(codigo(2).ToString + codigo(3).ToString + codigo(4).ToString + codigo(5).ToString + codigo(6).ToString)
                    objBU.alta_ubicacion_par(estibaid, codigo, lote, nave, colaboradorid)
                Else
                    objBU.editar_ubicacion_par(estibaid, codigo, colaboradorid)
                End If

            Else
                If par_en_ubicacion_par Then ''Verifica si ya existe en ubicacionPares

                    objBU.editar_ubicacion_par(estibaid, codigo, colaboradorid)

                Else ''Ingresa por primera vez a UbicacionPares

                    nave = CInt(codigo(0).ToString + codigo(1).ToString)
                    lote = CInt(codigo(2).ToString + codigo(3).ToString + codigo(4).ToString + codigo(5).ToString + codigo(6).ToString)
                    objBU.alta_ubicacion_par(estibaid, codigo, lote, nave, colaboradorid)

                End If
            End If

        End If

    End Sub

    Public Sub poblar_gridListaCodigo(grid As Infragistics.Win.UltraWinGrid.UltraGrid, lista_codigos_sucio As List(Of String))

        grid.DataSource = Nothing
        grid.DataSource = lista_codigos_sucio
        gridListaCodigoDiseno(grid)

        If tabCon_Sin_Plataforma.SelectedTab.Name = tpgSinPlataforma.Name Then
            verifica_condiciones_iniciales_archivo_Sin_Carrito(lista_codigos_sucio)
        ElseIf tabCon_Sin_Plataforma.SelectedTab.Name = tpgConPlataforma.Name Then
            verifica_condiciones_iniciales_archivo_Con_Carrito(lista_codigos_sucio)
        End If

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
            lblUltimaActualizacion.Visible = True
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
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
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


    Public Sub poblar_gridListaPlataforma(grid As Infragistics.Win.UltraWinGrid.UltraGrid, lista_de_carritos As String)

        grid.DataSource = Nothing
        estiba_valida = False

        Dim objBU As New Negocios.AlmacenBU


        grid.DataSource = objBU.Consulta_Ocupacion_Plataforma_lista(colaborador.PColaboradorid, fechaInicio, fechaTermino)
        gridListaPlataformaDiseno(grid)

    End Sub

    Private Sub gridListaPlataformaDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        With grid.DisplayLayout
            .Bands(0).Columns(1).Hidden = True
            .Bands(0).Columns(3).Hidden = True
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

        For Each row In grid.Rows
            If row.Cells("STATUS ID").Value = 23 Then
                row.Appearance.BackColor = Color.Green
            ElseIf row.Cells("STATUS ID").Value = 21 Then
                row.Appearance.BackColor = Color.Yellow
            ElseIf row.Cells("STATUS ID").Value = 22 Then
                row.Appearance.BackColor = Color.Blue
            ElseIf row.Cells("STATUS ID").Value = 20 Then
                Dim objBU As New Negocios.AlmacenBU
                If objBU.Plataforma_completa_lista_para_validacion(row.Cells("PLATAFORMA ID").Value.ToString) Then
                    objBU.Editar_Status_Plataforma(1, row.Cells("PLATAFORMA ID").Value, 21)
                    row.Appearance.BackColor = Color.Yellow
                    row.Cells("STATUS ID").Value = 21
                Else
                    row.Appearance.BackColor = Color.Red
                End If
            ElseIf row.Cells("STATUS ID").Value = 19 Then
                row.Appearance.BackColor = Color.Purple
            ElseIf row.Cells("STATUS ID").Value = 24 Then
                row.Appearance.BackColor = Color.Gray
            End If
        Next

    End Sub

    Private Sub gridListaPlataforma_Click(sender As Object, e As MouseEventArgs) Handles gridListaPlataforma.Click

        'If Me.gridListaPlataforma.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select Then
        '    Return

        'End If

        If Not Me.gridListaPlataforma.ActiveRow.IsDataRow Then Return

        If IsNothing(gridListaPlataforma.ActiveRow) Then Return

        If Not gridListaPlataforma.ActiveRow.Cells("STATUS ID").Value = 21 Then Return

        If gridListaPlataforma.ActiveRow.Cells(0).Value Then
            gridListaPlataforma.ActiveRow.Cells(0).Value = False
        Else
            gridListaPlataforma.ActiveRow.Cells(0).Value = True
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In gridListaPlataforma.Rows
            If CBool(row.Cells(0).Value) Then
                marcados += 1
            End If
        Next

        If marcados > 0 Then
            btnValidar_Plataforma.Enabled = True
        Else
            btnValidar_Plataforma.Enabled = False
        End If

        'lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub gridListaPlataforma_DoubleClick(sender As Object, e As MouseEventArgs) Handles gridListaPlataforma.DoubleClick

        If Not Me.gridListaPlataforma.ActiveRow.IsDataRow Then Return

        If IsNothing(gridListaPlataforma.ActiveRow) Then Return
        Dim row As UltraGridRow = gridListaPlataforma.ActiveRow

        Dim form As New DetallePlataformaForm
        form.ocupacion_carritoid = CInt(row.Cells("PLATAFORMA ID").Value)
        form.Show()

        'MessageBox.Show(row.Cells("PLATAFORMA").Value.ToString)

    End Sub

    Private Sub gridListaPlataforma_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridListaPlataforma.BeforeExitEditMode
        Try
            Dim cellIndex As Integer = gridListaPlataforma.ActiveCell.Column.Index

            If gridListaPlataforma.ActiveRow.DataChanged Then

            Else
                If gridListaPlataforma.ActiveCell.DataChanged Then
                Else
                    If String.IsNullOrWhiteSpace(gridListaPlataforma.ActiveCell.Value) Then
                        'poblar_gridListaPlataforma(String.Empty, gridListaPlataforma)
                        gridListaPlataforma.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    End If
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridListaPlataforma_AfterRowActivate(sender As Object, e As EventArgs) Handles gridListaPlataforma.AfterRowActivate
        gridListaPlataforma.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        For Each row In gridListaPlataforma.Rows
            row.Activation = Activation.NoEdit
        Next
    End Sub

    Private Sub tabCon_Sin_Plataforma_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tabCon_Sin_Plataforma.Selecting
        Dim tabControl As TabControl = sender
        Dim tabpage As TabPage = tabControl.SelectedTab

        If tabpage.Name.Equals("tpgSinPlataforma") Then
            pnlColores.Visible = False
        ElseIf tabpage.Name.Equals("tpgConPlataforma") Then
            pnlColores.Visible = True
        End If

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


    Private Sub cboxNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxNave.SelectedIndexChanged
        Dim objbu As New Almacen.Negocios.AlmacenBU
        Dim dtNumeroAlmacenes As DataTable

        If PrimeraCarga = False Then
            cboxAlmacen.DataSource = Nothing

            dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNave.SelectedValue)
            cboxAlmacen.DataSource = dtNumeroAlmacenes
            cboxAlmacen.ValueMember = "NumeroAlmacen"
            cboxAlmacen.DisplayMember = "NumeroAlmacen"
            cboxAlmacen.SelectedIndex = 0
        End If

    End Sub

End Class
