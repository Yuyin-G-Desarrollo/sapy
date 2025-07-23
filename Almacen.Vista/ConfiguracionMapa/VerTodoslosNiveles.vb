Imports C1.Win
Imports System
Imports System.Drawing
Imports System.Net

Public Class VerTodoslosNiveles
    Public Listas As New List(Of ListaGridsBahias)
    Public tablaBloques As New DataTable
    Dim listabahiagrid As ListaGridsBahias
    Dim listasenviar As New List(Of ListaGridsBahias)
    Public BahiasBuscar As New List(Of Entidades.Bahia)
    Public externo As Boolean = False
    Public ubicacion_producto As Boolean = False
    Dim cambio As Boolean = False
    Public NavesAlmacen As String
    Dim cambiar As Boolean = False
    Dim SegmentoList As New HashSet(Of String)
    Dim FilasList As New HashSet(Of Int32)
    Dim CopiaPanel As New List(Of Panel)
    Dim copiaControl As Boolean = True
    Dim Inactivas As New List(Of Entidades.Bahia)
    Public verOcupacion As Boolean = False
    Dim BahiasOcupacion As New List(Of Entidades.Bahia)
    Dim BahiasVerde, BahiasAzul, BahiasNaranja, BahiasRojo As Int32
    Dim BahiasParesVerde, BahiasParesAzul, BahiasParesNaranja, BahiasParesRojo As Int32
    Dim CapacidadTotal, CapacidadUsada As Int32
    Public Almacen, Nave As String

    Public Property PListas As List(Of ListaGridsBahias)
        Get
            Return Listas
        End Get
        Set(value As List(Of ListaGridsBahias))
            Listas = value
        End Set
    End Property



    Private Sub VerTodoslosNiveles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If verOcupacion = True Then
            Me.HelpButton = True
            MaximizeBox = False
            MinimizeBox = False
        End If

        CargarMapas(3)

    End Sub



    Public Sub AjustarTamaños(ByVal grd As C1.Win.C1FlexGrid.C1FlexGrid, ByVal Ancho As Double, ByVal Alto As Double)
        For Each col As C1.Win.C1FlexGrid.Column In grd.Cols
            col.Width = Ancho
            col.TextAlign = C1FlexGrid.TextAlignEnum.CenterCenter
        Next

        For Each row As C1.Win.C1FlexGrid.Row In grd.Rows
            row.Height = Alto
            row.TextAlign = C1FlexGrid.TextAlignEnum.CenterCenter
        Next


    End Sub


    Public Sub CargarMapas(ByVal fuente As Double)
        BahiasVerde = 0
        BahiasAzul = 0
        BahiasNaranja = 0
        BahiasRojo = 0
        BahiasParesVerde = 0
        BahiasParesAzul = 0
        BahiasParesNaranja = 0
        BahiasParesRojo = 0
        If externo = True Then
            Dim tabla As New DataTable
            Dim datos() As String
            datos = NavesAlmacen.Split(",")
            tabla = CargarBloques(CInt(datos(0)), CInt(datos(1)))
            Dim bloque As New Int32


            For Each rows As DataRow In tabla.Rows
                Dim panel As New Panel
                panel.AutoScroll = True
                panel.Size = New Size(750, 1250)
                panel.Dock = DockStyle.Left
                panel.Name = "panel" + bloque.ToString
                pnlContenedor.Controls.Add(panel)
                Dim Indice As Int32 = 0
                ' listasenviar.Sort()
                For Each cargar As ListaGridsBahias In listasenviar
                    If cargar.PBloque.Contains(CStr(rows("bahi_bloque"))) Then
                        Dim grdMapa As New C1.Win.C1FlexGrid.C1FlexGrid
                        grdMapa.Cols.Count = 0
                        grdMapa.Rows.Count = 0

                        Dim NombreGrid As String
                        NombreGrid = Indice.ToString
                        SetupDataGridView(cargar, grdMapa, panel, NombreGrid)
                        SegmentoList = New HashSet(Of String)
                        FilasList = New HashSet(Of Integer)
                        If ubicacion_producto Then
                            CargarInformacionGuardadaVerTodo(cargar.PlistaBahias, grdMapa)
                        Else
                            CargarInformacionGuardada(cargar.PlistaBahias, grdMapa)
                        End If

                        AjustarTamaños(grdMapa, 22.5, 15)
                        If ubicacion_producto Then
                            ReformatearBahias(BahiasBuscar, grdMapa, fuente, (rows("bahi_bloque")))
                        End If
                        InsertarEncabezadoGuia(grdMapa, (rows("bahi_bloque")))


                        Indice += 1


                    End If
                Next




                bloque += 1

            Next


        Else
            Dim bloque As New Int32

            For Each rows As DataRow In tablaBloques.Rows



                Dim panel As New Panel
                panel.AutoScroll = True
                panel.Size = New Size(750, 1250)
                panel.Dock = DockStyle.Left
                panel.Name = "panel" + bloque.ToString
                pnlContenedor.Controls.Add(panel)
                Dim Indice As Int32 = 0
                For Each cargar As ListaGridsBahias In Listas
                    If cargar.PBloque.Contains(CStr(rows("bahi_bloque"))) Then



                        Dim grdMapa As New C1.Win.C1FlexGrid.C1FlexGrid

                        grdMapa.Cols.Count = 0
                        grdMapa.Rows.Count = 0
                        Dim NombreGrid As String
                        NombreGrid = Indice.ToString
                        SetupDataGridView(cargar, grdMapa, panel, NombreGrid)
                        SegmentoList = New HashSet(Of String)
                        FilasList = New HashSet(Of Integer)
                        CargarInformacionGuardada(cargar.PlistaBahias, grdMapa)
                        AjustarTamaños(grdMapa, 22.5, 15)
                        InsertarEncabezadoGuia(grdMapa, (rows("bahi_bloque")))
                        AjustarTamaños(grdMapa, 22.5, 15)
                        Indice += 1
                        CopiaPanel.Add(panel)
                    End If
                Next




                bloque += 1

            Next





        End If
        pnlContenedor.AutoScroll = True

    End Sub




    Public Sub CargarInformacionGuardada(ByVal ListaBahias As List(Of Entidades.Bahia), ByVal grd As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim nivel As String = String.Empty

        For Each bahia As Entidades.Bahia In ListaBahias
            nivel = CStr(bahia.bahi_nivel)
            If bahia.bahi_activo = False Then
                Inactivas.Add(bahia)
            End If
            Dim getposicion As String()
            getposicion = bahia.bahi_posicion.Split(",")
            Dim X, Y As New Int32
            X = CInt(getposicion(0))
            Y = CInt(getposicion(1))
            Dim Codigo As String()
            Codigo = bahia.bahiaid.Split("-")
            grd(X, Y) = Codigo(0)
            'grd(X, Y) = bahia.bahi_segmento.ToString + bahia.bahi_fila.ToString
            Dim color As String
            color = bahia.bahi_color
            color = color.Replace("A_", "")
            color = color.Replace("R_", "")
            color = color.Replace("G_", "")
            color = color.Replace("B_", "")
            Dim ArregloColores As String()
            ArregloColores = color.Split("-")
            Dim colores As String = String.Empty
            If verOcupacion = False Then
                colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
            Else



                If bahia.porcentajeocupacion < 50 Then
                    colores = RGB2HTMLColor(System.Drawing.Color.Green.R, System.Drawing.Color.Green.G, System.Drawing.Color.Green.B)
                    BahiasVerde += 1
                    BahiasParesVerde += bahia.paresactuales
                    CapacidadTotal += bahia.capacidadenpares
                    CapacidadUsada += bahia.paresactuales
                ElseIf bahia.porcentajeocupacion < 80 Then
                    colores = RGB2HTMLColor(System.Drawing.Color.Blue.R, System.Drawing.Color.Blue.G, System.Drawing.Color.Blue.B)
                    BahiasAzul += 1
                    BahiasParesAzul += bahia.paresactuales
                    CapacidadTotal += bahia.capacidadenpares
                    CapacidadUsada += bahia.paresactuales
                ElseIf bahia.porcentajeocupacion <= 100 Then
                    colores = RGB2HTMLColor(System.Drawing.Color.Orange.R, System.Drawing.Color.Orange.G, System.Drawing.Color.Orange.B)
                    BahiasNaranja += 1
                    BahiasParesNaranja += bahia.paresactuales
                    CapacidadTotal += bahia.capacidadenpares
                    CapacidadUsada += bahia.paresactuales
                ElseIf bahia.porcentajeocupacion > 100 Then
                    colores = RGB2HTMLColor(System.Drawing.Color.Red.R, System.Drawing.Color.Red.G, System.Drawing.Color.Red.B)
                    BahiasParesRojo += bahia.paresactuales
                    BahiasRojo += 1
                    CapacidadTotal += bahia.capacidadenpares
                    CapacidadUsada += bahia.paresactuales
                End If

            End If

            Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
            ColorCell = grd.Styles.Add("ColorCelda" + colores + bahia.bahiaid)
            ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
            ColorCell.Font = New Font("Arial", 4)


            If bahia.bahi_activo = False Then
                If verOcupacion = False Then
                    ColorCell.ForeColor = Drawing.Color.Red

                Else
                    ColorCell.ForeColor = Drawing.Color.White
                    ColorCell.BackColor = Drawing.Color.White
                End If

            Else
                ColorCell.ForeColor = Drawing.Color.Black
            End If

            If colores.Contains("#000000") = True Then
                ColorCell.ForeColor = Drawing.Color.White
            End If

            If bahia.bahi_referenciaubicacionid > 0 Then
                Dim imagen As Bitmap
                Dim objbu As New Almacen.Negocios.BahiaBU
                Dim ruta As String = ""
                ruta = objbu.BuscarRutaImagen(bahia.bahi_referenciaubicacionid)
                Try
                    Dim objFTP As New Tools.TransferenciaFTP
                    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
                    request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
                    Dim Carpeta As String = ""
                    Dim tabla() As String
                    tabla = Split(ruta, "/")
                    Dim nombrearchivo As String = ""
                    For n = 3 To UBound(tabla, 1)
                        If n = tabla.Length - 1 Then
                            nombrearchivo = tabla(n)
                        Else
                            Carpeta += tabla(n) + "/"
                        End If
                    Next

                    Dim Stream As System.IO.Stream
                    Stream = objFTP.StreamFile(Carpeta, nombrearchivo)
                    imagen = Image.FromStream(Stream)
                Catch

                End Try

                Dim imagen2 As New Bitmap(New Bitmap(imagen), 40, 40)
                '  imagen2.Save("C:\", System.Drawing.Imaging.ImageFormat.Jpeg)
                grd.SetCellImage(X, Y, imagen2)
            End If
            BahiasOcupacion.Add(bahia)
            grd.SetCellStyle(X, Y, ColorCell)
            Dim segmento, fila As String
            segmento = bahia.bahi_segmento
            fila = CInt(bahia.bahi_fila)
            SegmentoList.Add(segmento)
            FilasList.Add(fila)
            'grdMatriz.Rows(X).Cells(Y).Style.BackColor = ColorTranslator.FromHtml(ArregloColores(1) + ArregloColores(2) + ArregloColores(3))
        Next

        grd.Name += "_" + nivel

    End Sub







    Public Sub CargarInformacionGuardadaVerTodo(ByVal ListaBahias As List(Of Entidades.Bahia), ByVal grd As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim nivel As String = String.Empty

        For Each bahia As Entidades.Bahia In ListaBahias
            nivel = CStr(bahia.bahi_nivel)
            If bahia.bahi_activo = False Then
                Inactivas.Add(bahia)
            End If
            Dim getposicion As String()
            getposicion = bahia.bahi_posicion.Split(",")
            Dim X, Y As New Int32
            X = CInt(getposicion(0))
            Y = CInt(getposicion(1))
            Dim Codigo As String()
            Codigo = bahia.bahiaid.Split("-")
            grd(X, Y) = Codigo(0)
            'grd(X, Y) = bahia.bahi_segmento.ToString + bahia.bahi_fila.ToString
            Dim color As String
            color = bahia.bahi_color
            color = color.Replace("A_", "")
            color = color.Replace("R_", "")
            color = color.Replace("G_", "")
            color = color.Replace("B_", "")
            Dim ArregloColores As String()
            ArregloColores = color.Split("-")
            Dim colores As String = String.Empty
            If verOcupacion = False Then
                colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
            Else



                If bahia.porcentajeocupacion < 50 Then
                    colores = RGB2HTMLColor(System.Drawing.Color.Green.R, System.Drawing.Color.Green.G, System.Drawing.Color.Green.B)
                    BahiasVerde += 1
                    BahiasParesVerde += bahia.paresactuales
                    CapacidadTotal += bahia.capacidadenpares
                    CapacidadUsada += bahia.paresactuales
                ElseIf bahia.porcentajeocupacion < 80 Then
                    colores = RGB2HTMLColor(System.Drawing.Color.Blue.R, System.Drawing.Color.Blue.G, System.Drawing.Color.Blue.B)
                    BahiasAzul += 1
                    BahiasParesAzul += bahia.paresactuales
                    CapacidadTotal += bahia.capacidadenpares
                    CapacidadUsada += bahia.paresactuales
                ElseIf bahia.porcentajeocupacion <= 100 Then
                    colores = RGB2HTMLColor(System.Drawing.Color.Orange.R, System.Drawing.Color.Orange.G, System.Drawing.Color.Orange.B)
                    BahiasNaranja += 1
                    BahiasParesNaranja += bahia.paresactuales
                    CapacidadTotal += bahia.capacidadenpares
                    CapacidadUsada += bahia.paresactuales
                ElseIf bahia.porcentajeocupacion > 100 Then
                    colores = RGB2HTMLColor(System.Drawing.Color.Red.R, System.Drawing.Color.Red.G, System.Drawing.Color.Red.B)
                    BahiasParesRojo += bahia.paresactuales
                    BahiasRojo += 1
                    CapacidadTotal += bahia.capacidadenpares
                    CapacidadUsada += bahia.paresactuales
                End If

            End If

            Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
            ColorCell = grd.Styles.Add("ColorCelda" + colores + bahia.bahiaid)
            'ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
            ColorCell.Font = New Font("Arial", 4)
            Dim colorfondo As String
            colorfondo = RGB2HTMLColor(202, 201, 205)
            ColorCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(colorfondo)

            If bahia.bahi_activo = False Then
                If verOcupacion = False Then
                    ColorCell.ForeColor = Drawing.Color.Red

                Else
                    ColorCell.ForeColor = Drawing.Color.White
                    ColorCell.BackColor = Drawing.Color.White
                End If

            Else
                '   ColorCell.ForeColor = Drawing.Color.Black
            End If

            If colores.Contains("#000000") = True Then
                ColorCell.ForeColor = Drawing.Color.White
            End If

            If bahia.bahi_referenciaubicacionid > 0 Then
                Dim imagen As Image
                Dim objbu As New Almacen.Negocios.BahiaBU
                Dim ruta As String = ""
                ruta = objbu.BuscarRutaImagen(bahia.bahi_referenciaubicacionid)
                Try
                    Dim objFTP As New Tools.TransferenciaFTP
                    'Dim request = DirectCast(WebRequest.Create(objFTP.obtenerUsuario), FtpWebRequest)
                    'request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
                    Dim Carpeta As String = ""
                    Dim tabla() As String
                    tabla = Split(ruta, "/")
                    Dim nombrearchivo As String = ""
                    For n = 3 To UBound(tabla, 1)
                        If n = tabla.Length - 1 Then
                            nombrearchivo = tabla(n)
                        Else
                            Carpeta += tabla(n) + "/"
                        End If
                    Next

                    Dim Stream As System.IO.Stream
                    Stream = objFTP.StreamFile(Carpeta, nombrearchivo)
                    imagen = Image.FromStream(Stream)
                    Dim imagen2 As New Bitmap(New Bitmap(imagen), 40, 40)
                    '  imagen2.Save("C:\", System.Drawing.Imaging.ImageFormat.Jpeg)
                    grd.SetCellImage(X, Y, imagen2)
                Catch ex As Exception
                    Dim msg_error As New Tools.ErroresForm
                    msg_error.mensaje = ex.Message
                    msg_error.ShowDialog()
                End Try
            End If
            BahiasOcupacion.Add(bahia)
            grd.SetCellStyle(X, Y, ColorCell)
            Dim segmento, fila As String
            segmento = bahia.bahi_segmento
            fila = CInt(bahia.bahi_fila)
            SegmentoList.Add(segmento)
            FilasList.Add(fila)
            'grdMatriz.Rows(X).Cells(Y).Style.BackColor = ColorTranslator.FromHtml(ArregloColores(1) + ArregloColores(2) + ArregloColores(3))
        Next

        grd.Name += "_" + nivel

    End Sub






    Public Function RGB2HTMLColor(R As Byte, G As Byte, _
B As Byte) As String
        Dim HexR, HexB, HexG As Object
        Dim sTemp As String

        On Error GoTo ErrorHandler

        'R
        HexR = Hex(R)
        If Len(HexR) < 2 Then HexR = "0" & HexR

        'Get Green Hex
        HexG = Hex(G)
        If Len(HexG) < 2 Then HexG = "0" & HexG

        HexB = Hex(B)
        If Len(HexB) < 2 Then HexB = "0" & HexB



        RGB2HTMLColor = "#" & HexR & HexG & HexB
ErrorHandler:
    End Function



    Private Sub SetupDataGridView(ByVal datos As ListaGridsBahias, ByVal grdMapa As C1.Win.C1FlexGrid.C1FlexGrid, ByVal panel As Panel, ByVal NombreGrid As String)
        panel.Controls.Add(grdMapa)
        grdMapa.Cols.Count = datos.PListaGrids.Cols.Count
        grdMapa.Rows.Count = datos.PListaGrids.Rows.Count
        AddHandler grdMapa.DoubleClick, AddressOf DoubleClicks
        AddHandler grdMapa.Click, AddressOf Clicks

        With grdMapa
            .Name = NombreGrid
            .Location = New Point(8, 8)
            .Size = New Size(500, 250)
            .SelectionMode = C1FlexGrid.SelectionModeEnum.Cell
            .Dock = DockStyle.Top
            .SendToBack()
        End With
    End Sub


    Private Sub Clicks(ByVal sender As System.Object, ByVal e As EventArgs)
        If Listas.Count > 0 Then
            For Each lista As ListaGridsBahias In Listas
                For Each row As C1.Win.C1FlexGrid.Row In sender.Rows
                    For cell As Int32 = 0 To sender.Cols.Count - 1
                        If sender.IsCellSelected(row.Index, cell) = True Then
                            For Each itembahia As Entidades.Bahia In lista.PlistaBahias
                                If Not IsNothing(sender(row.Index, cell)) Then
                                    If itembahia.bahiaid.Contains(sender(row.Index, cell)) Then
                                        Dim buttonToolTip As New ToolTip()
                                        buttonToolTip.ToolTipTitle = sender(row.Index, cell)
                                        buttonToolTip.UseFading = True
                                        buttonToolTip.UseAnimation = True
                                        buttonToolTip.IsBalloon = True
                                        buttonToolTip.ShowAlways = True
                                        buttonToolTip.AutoPopDelay = 3000
                                        buttonToolTip.InitialDelay = 500
                                        buttonToolTip.ReshowDelay = 5000
                                        buttonToolTip.IsBalloon = True
                                        Dim Estado As String
                                        If itembahia.bahi_activo = True Then
                                            Estado = "Activa"
                                        Else
                                            Estado = "Inactiva"
                                        End If

                                        Dim objbu As New Almacen.Negocios.BahiaBU
                                        Dim CantidadPares As New Int32
                                        CantidadPares = objbu.ObtenerCantidadParesEnBahia(itembahia.bahiaid)
                                        Dim Porcentaje As New Double
                                        Porcentaje = (CantidadPares / itembahia.capacidadenpares) * 100
                                        buttonToolTip.SetToolTip(sender, "Bahia: " + itembahia.bahiaid _
                                                                  + vbLf + "Descripción: " + itembahia.bahi_descripcion + _
                                                                  vbLf + "Status: " + Estado + _
                                                                  vbLf + "Contenido actual (pares): " + CantidadPares.ToString + _
                                                                  vbLf + "Capacidad en pares: " + itembahia.capacidadenpares.ToString + _
                                                                  vbLf + "Ocupación: " + Porcentaje.ToString("##,##0.00") + "%")
                                    End If
                                End If
                            Next



                        End If
                    Next
                Next
            Next

        Else

            If BahiasBuscar.Count > 0 Then
                For Each row As C1.Win.C1FlexGrid.Row In sender.Rows
                    For cell As Int32 = 0 To sender.Cols.Count - 1
                        If sender.IsCellSelected(row.Index, cell) = True Then
                            For Each itembahia As Entidades.Bahia In BahiasBuscar
                                If Not IsNothing(sender(row.Index, cell)) Then
                                    If itembahia.bahiaid.Contains(sender(row.Index, cell)) Then
                                        Dim buttonToolTip As New ToolTip()
                                        buttonToolTip.ToolTipTitle = sender(row.Index, cell)
                                        buttonToolTip.UseFading = True
                                        buttonToolTip.UseAnimation = True
                                        buttonToolTip.IsBalloon = True
                                        buttonToolTip.ShowAlways = True
                                        buttonToolTip.AutoPopDelay = 5000
                                        buttonToolTip.InitialDelay = 1000
                                        buttonToolTip.ReshowDelay = 500
                                        buttonToolTip.IsBalloon = True
                                        Dim Estado As String
                                        If itembahia.bahi_activo = True Then
                                            Estado = "Activa"
                                        Else
                                            Estado = "Inactiva"
                                        End If

                                        Dim objbu As New Almacen.Negocios.BahiaBU
                                        Dim CantidadPares As New Int32
                                        CantidadPares = objbu.ObtenerCantidadParesEnBahia(itembahia.bahiaid)
                                        Dim Porcentaje As New Double
                                        Porcentaje = (CantidadPares / itembahia.capacidadenpares) * 100
                                        buttonToolTip.SetToolTip(sender, "Bahia: " + itembahia.bahiaid _
                                                                 + vbLf + "Descripción: " + itembahia.bahi_descripcion + _
                                                                 vbLf + "Status: " + Estado + _
                                                                 vbLf + "Contenido actual (pares): " + CantidadPares.ToString + _
                                                                 vbLf + "Capacidad en pares: " + itembahia.capacidadenpares.ToString + _
                                                                vbLf + "Ocupación: " + Porcentaje.ToString("##,##0.00") + "%")
                                    End If
                                End If
                            Next



                        End If
                    Next
                Next



            End If


            If BahiasOcupacion.Count > 0 Then
                For Each row As C1.Win.C1FlexGrid.Row In sender.Rows
                    For cell As Int32 = 0 To sender.Cols.Count - 1
                        If sender.IsCellSelected(row.Index, cell) = True Then
                            For Each itembahia As Entidades.Bahia In BahiasOcupacion
                                If Not IsNothing(sender(row.Index, cell)) Then
                                    If itembahia.bahiaid.Contains(sender(row.Index, cell)) Then
                                        Dim buttonToolTip As New ToolTip()
                                        buttonToolTip.ToolTipTitle = sender(row.Index, cell)
                                        buttonToolTip.UseFading = True
                                        buttonToolTip.UseAnimation = True
                                        buttonToolTip.IsBalloon = True
                                        buttonToolTip.ShowAlways = True
                                        buttonToolTip.AutoPopDelay = 5000
                                        buttonToolTip.InitialDelay = 1000
                                        buttonToolTip.ReshowDelay = 500
                                        buttonToolTip.IsBalloon = True
                                        Dim Estado As String
                                        If itembahia.bahi_activo = True Then
                                            Estado = "Activa"
                                        Else
                                            Estado = "Inactiva"
                                        End If

                                        Dim objbu As New Almacen.Negocios.BahiaBU
                                        Dim CantidadPares As New Int32
                                        CantidadPares = objbu.ObtenerCantidadParesEnBahia(itembahia.bahiaid)
                                        Dim Porcentaje As New Double
                                        Porcentaje = (CantidadPares / itembahia.capacidadenpares) * 100
                                        buttonToolTip.SetToolTip(sender, "Bahia: " + itembahia.bahiaid _
                                                                 + vbLf + "Descripción: " + itembahia.bahi_descripcion + _
                                                                 vbLf + "Status: " + Estado + _
                                                                 vbLf + "Contenido actual (pares): " + CantidadPares.ToString + _
                                                                 vbLf + "Capacidad en pares: " + itembahia.capacidadenpares.ToString + _
                                                                vbLf + "Ocupación: " + Porcentaje.ToString("##,##0.00") + "%")
                                    End If
                                End If
                            Next



                        End If
                    Next
                Next

            End If


        End If





    End Sub

    Private Sub DoubleClicks(ByVal sender As System.Object, ByVal e As EventArgs)

        If cambiar = False Then
            Dim gridFull As New C1.Win.C1FlexGrid.C1FlexGrid
            gridFull = sender
            pnlContenedor.Controls.Clear()
            pnlContenedor.Controls.Add(gridFull)
            gridFull.Dock = DockStyle.Fill

            For Each row As C1.Win.C1FlexGrid.Row In gridFull.Rows
                For a As Int32 = 0 To gridFull.Cols.Count - 1

                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                    If Not IsNothing(gridFull.GetCellStyle(row.Index, a)) Then
                        ColorCell = gridFull.GetCellStyle(row.Index, a)
                    Else
                        ColorCell = gridFull.Styles.Add("ColorCelda" + row.Index.ToString + a.ToString)

                    End If

                    ColorCell.Font = New Font("Arial", 9)
                    gridFull.SetCellStyle(row.Index, a, ColorCell)


                Next

            Next




            cambiar = True
            AjustarTamaños(gridFull, 40, 40)

        Else
            pnlContenedor.Controls.Clear()

            Me.Cursor = Cursors.WaitCursor
            CargarMapas(3)
            cambiar = False
            Cursor = Cursors.Default
        End If

    End Sub
    Public Function CargarBloques(ByVal NaveID As Int32, ByVal AlmacenID As Int32) As DataTable
        Dim objbu As New Almacen.Negocios.BahiaBU
        listasenviar = New List(Of ListaGridsBahias)
        Dim tabla As New DataTable
        Dim Vertodo As New VerTodoslosNiveles
        Dim tablabloques As DataTable
        tablabloques = objbu.CargarBloques(NaveID, AlmacenID.ToString)
        For Each rows As DataRow In tablabloques.Rows
            tabla = objbu.CargarNiveles(NaveID, AlmacenID.ToString, CStr(rows("bahi_bloque")))
            For Each row As DataRow In tabla.Rows
                DibujarMapasVerTODO(CStr(row("bahi_nivel")), CStr(rows("bahi_bloque")), NaveID, AlmacenID)
                listabahiagrid.PBloque = CStr(rows("bahi_bloque"))
                listasenviar.Add(listabahiagrid)
            Next
        Next
        Return tablabloques
    End Function
    Public Sub DibujarMapasVerTODO(ByVal nivel As String, ByVal Bloque As String, ByVal NaveID As Int32, ByVal AlmacenID As Int32)
        Dim objbu As New Negocios.BahiaBU
        Dim idAlmacen As Int32
        idAlmacen = 1
        Dim ConfiguracionBahia As New Entidades.ConfiguracionBahia
        If idAlmacen > 0 Then
            listabahiagrid = New ListaGridsBahias
            Dim grid As New C1.Win.C1FlexGrid.C1FlexGrid
            Dim listabahias As New List(Of Entidades.Bahia)
            ConfiguracionBahia = objbu.CargarConfiguracionBahia(NaveID, AlmacenID, Bloque, nivel.ToString)
            grid = DibujarMapaExistentesVERTODO(ConfiguracionBahia)
            If verOcupacion = False Then
                listabahias = objbu.CargarMapaAlmacenCompleto(NaveID, AlmacenID, Bloque, nivel)
            Else
                listabahias = objbu.OcupacionMapa(NaveID, AlmacenID, Bloque, nivel)
            End If

            listabahiagrid.PlistaBahias = listabahias
            'CargarInformacionGuardada(listabahias, grid)
            listabahiagrid.PListaGrids = grid
        End If
    End Sub
    Public Function DibujarMapaExistentesVERTODO(ByVal configuracion As Entidades.ConfiguracionBahia) As C1.Win.C1FlexGrid.C1FlexGrid
        Dim grid As New C1.Win.C1FlexGrid.C1FlexGrid
        grid = New C1.Win.C1FlexGrid.C1FlexGrid
        grid.Rows.Count = 0
        grid.Cols.Count = 0
        For A As Int32 = 1 To configuracion.pcobl_columnas
            Dim COLUMNA As New DataGridViewTextBoxColumn
            grid.Cols.Count = grid.Cols.Count + 1
        Next
        For B As Int32 = 1 To configuracion.pcobl_renglones
            grid.Rows.Add()
        Next
        Return grid
    End Function


    Public Sub ReformatearBahias(ByVal Listabahias As List(Of Entidades.Bahia), ByVal grid As C1.Win.C1FlexGrid.C1FlexGrid, ByVal fuente As Double, ByVal Bloque As String)
        If verOcupacion Then Return
        Dim colorfondo As String
        colorfondo = RGB2HTMLColor(202, 201, 205)
        grid.BackColor = System.Drawing.ColorTranslator.FromHtml(colorfondo)
        grid.ForeColor = System.Drawing.ColorTranslator.FromHtml(colorfondo)
        Dim tiene As Boolean = False
        Dim nivel() As String
        nivel = grid.Name.Split("_")


        Dim repintarpasillos As Boolean = True
        For Each entidad As Entidades.Bahia In Listabahias

            If entidad.bahi_bloque.Contains(Bloque) And entidad.bahi_nivel = CInt(nivel(1)) Then
                Dim contiene As Boolean = False
                Dim posicion As String()
                Dim row, cell As Int32
                posicion = entidad.bahi_posicion.Split(",")
                row = CInt(posicion(0))
                cell = CInt(posicion(1))
                If Not IsNothing(grid(row, cell)) Then


                    If entidad.bahiaid.Contains(grid(row, cell)) Then
                        contiene = True
                        Dim objbu As New Almacen.Negocios.BahiaBU
                        Dim color As String = entidad.bahi_color
                        color = color.Replace("A_", "")
                        color = color.Replace("R_", "")
                        color = color.Replace("G_", "")
                        color = color.Replace("B_", "")
                        Dim ArregloColores As String()
                        ArregloColores = color.Split("-")
                        Dim colores As String
                        colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
                        Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                        ColorCell = grid.Styles.Add("ColorCelda" + colores + entidad.bahiaid)
                        ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
                        ColorCell.ForeColor = Drawing.Color.Black
                        ColorCell.Font = New Font("Arial", fuente)
                        grid.SetCellStyle(row, cell, ColorCell)
                        tiene = True





                    End If

                End If


            End If




        Next



        If tiene = True Then
            For Each row As C1.Win.C1FlexGrid.Row In grid.Rows
                For cell As Int32 = 0 To grid.Cols.Count - 1
                    If IsNothing(grid(row.Index, cell)) Then
                        Dim colores As String
                        colores = RGB2HTMLColor(191, 236, 170)
                        Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                        ColorCell = grid.Styles.Add("ColorCelda" + colores + Bloque + nivel(1).ToString)
                        ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
                        ColorCell.Font = New Font("Arial", fuente)
                        ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
                        grid.SetCellStyle(row.Index, cell, ColorCell)
                    End If

                    For Each inactiva As Entidades.Bahia In Inactivas
                        If Not IsNothing(grid(row.Index, cell)) Then
                            If inactiva.bahiaid.Contains(grid(row.Index, cell)) Then
                                Dim colores As String
                                colores = RGB2HTMLColor(191, 236, 170)
                                Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                                ColorCell = grid.Styles.Add("ColorCelda" + colores + Bloque + nivel(1).ToString)
                                ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
                                ColorCell.Font = New Font("Arial", fuente)
                                ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
                                grid.SetCellStyle(row.Index, cell, ColorCell)
                            End If
                        End If

                    Next



                Next
            Next
        Else
            For Each row As C1.Win.C1FlexGrid.Row In grid.Rows
                For cell As Int32 = 0 To grid.Cols.Count - 1
                    If IsNothing(grid(row.Index, cell)) Then
                        Dim colores As String
                        colores = RGB2HTMLColor(191, 236, 170)
                        Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                        ColorCell = grid.Styles.Add("ColorCelda" + colores + Bloque + nivel(1).ToString + "blanco")
                        ColorCell.BackColor = Color.White
                        ColorCell.Font = New Font("Arial", fuente)
                        ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
                        grid.SetCellStyle(row.Index, cell, ColorCell)
                    End If






                    For Each inactiva As Entidades.Bahia In Inactivas
                        If Not IsNothing(grid(row.Index, cell)) Then
                            If inactiva.bahiaid.Contains(grid(row.Index, cell)) Then
                                Dim colores As String
                                If tiene = True Then
                                    colores = RGB2HTMLColor(191, 236, 170)
                                Else
                                    colores = ("#FFFFFF")
                                End If

                                Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                                ColorCell = grid.Styles.Add("ColorCelda" + colores + Bloque + nivel(1).ToString)
                                ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
                                ColorCell.Font = New Font("Arial", fuente)
                                ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
                                grid.SetCellStyle(row.Index, cell, ColorCell)
                            End If
                        End If

                    Next



                Next
            Next
        End If






        'For Each row As C1.Win.C1FlexGrid.Row In grid.Rows
        '    For cell As Int32 = 0 To grid.Cols.Count - 1
        '        Dim contiene As Boolean = False
        '        For Each Bahia As Entidades.Bahia In Listabahias
        '            Bahia.bahi_activo = True
        '            Try
        '                If Not IsNothing(grid(row.Index, cell)) Then
        '                    If Bahia.bahiaid.Contains(grid(row.Index, cell)) Then
        '                        contiene = True
        '                        Dim objbu As New Almacen.Negocios.BahiaBU
        '                        Dim color As String = Bahia.bahi_color
        '                        color = color.Replace("A_", "")
        '                        color = color.Replace("R_", "")
        '                        color = color.Replace("G_", "")
        '                        color = color.Replace("B_", "")
        '                        Dim ArregloColores As String()
        '                        ArregloColores = color.Split("-")
        '                        Dim colores As String
        '                        colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
        '                        Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
        '                        ColorCell = grid.Styles.Add("ColorCelda" + colores + Bahia.bahiaid)
        '                        ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
        '                        ColorCell.Font = New Font("Arial", fuente)
        '                        grid.SetCellStyle(row.Index, cell, ColorCell)
        '                        repintarpasillos = False
        '                    End If
        '                Else

        '                End If

        '                If contiene = True Then


        '                Else
        '                    Dim colores As String
        '                    colores = RGB2HTMLColor(202, 201, 205)
        '                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
        '                    ColorCell = grid.Styles.Add("ColorCelda" + colores)
        '                    ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
        '                    ColorCell.Font = New Font("Arial", fuente)
        '                    ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
        '                    grid.SetCellStyle(row.Index, cell, ColorCell)

        '                End If
        '                If IsNothing(grid(row.Index, cell)) Then
        '                    Dim colores As String
        '                    colores = RGB2HTMLColor(191, 236, 170)
        '                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
        '                    ColorCell = grid.Styles.Add("ColorCelda" + colores)
        '                    ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
        '                    ColorCell.Font = New Font("Arial", fuente)
        '                    ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
        '                    grid.SetCellStyle(row.Index, cell, ColorCell)
        '                End If

        '                For Each inactiva As Entidades.Bahia In Inactivas
        '                    If Not IsNothing(grid(row.Index, cell)) Then
        '                        If inactiva.bahiaid.Contains(grid(row.Index, cell)) Then
        '                            Dim colores As String
        '                            colores = RGB2HTMLColor(191, 236, 170)
        '                            Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
        '                            ColorCell = grid.Styles.Add("ColorCelda" + colores)
        '                            ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
        '                            ColorCell.Font = New Font("Arial", fuente)
        '                            ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
        '                            grid.SetCellStyle(row.Index, cell, ColorCell)
        '                        End If
        '                    End If

        '                Next


        '            Catch ex As Exception
        '                MsgBox("")
        '            End Try



        '            '----
        '        Next
        '    Next
        'Next

        'If repintarpasillos = True Then

        '    For Each row As C1.Win.C1FlexGrid.Row In grid.Rows
        '        For cell As Int32 = 0 To grid.Cols.Count - 1
        '            Dim contiene As Boolean = False
        '            For Each Bahia As Entidades.Bahia In Listabahias


        '                If IsNothing(grid(row.Index, cell)) Then
        '                    Dim colores As String
        '                    colores = RGB2HTMLColor(255, 255, 255)
        '                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
        '                    ColorCell = grid.Styles.Add("ColorCelda" + colores + "pas")
        '                    ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
        '                    ColorCell.Font = New Font("Arial", fuente)
        '                    ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
        '                    grid.SetCellStyle(row.Index, cell, ColorCell)
        '                End If

        '                For Each inactiva As Entidades.Bahia In Inactivas
        '                    If Not IsNothing(grid(row.Index, cell)) Then
        '                        If inactiva.bahiaid.Contains(grid(row.Index, cell)) Then
        '                            Dim colores As String
        '                            colores = RGB2HTMLColor(255, 255, 255)
        '                            Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
        '                            ColorCell = grid.Styles.Add("ColorCelda" + colores + "pas")
        '                            ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
        '                            ColorCell.Font = New Font("Arial", fuente)
        '                            ColorCell.ForeColor = ColorTranslator.FromHtml(colores)
        '                            grid.SetCellStyle(row.Index, cell, ColorCell)
        '                        End If
        '                    End If

        '                Next



        '            Next
        '        Next
        '    Next





        'End If

    End Sub



    Public Sub InsertarEncabezadoGuia(ByVal grid As C1.Win.C1FlexGrid.C1FlexGrid, ByVal Bloque As String)

        grid.Cols.Insert(0)
        grid.Rows.Insert(0)
        AjustarTamaños(grid, 22.5, 15)
        Dim indicerenglon As Int32 = SegmentoList.Count

        For Each row As C1.Win.C1FlexGrid.Row In grid.Rows
            If row.Index > 0 Then
                grid(row.Index, 0) = SegmentoList(indicerenglon - 1)
                indicerenglon -= 1
            End If




        Next
        Dim indice As Int32 = 0
        Dim OrdenamientoFilas As New SortedList

        For Each fila As Int32 In FilasList
            OrdenamientoFilas.Add(fila, fila)
        Next




        indice = 0

        For Each column As C1.Win.C1FlexGrid.Column In grid.Cols
            If column.Index > 0 Then
                If Not IsNothing(grid(1, column.Index)) Then
                    If indice < OrdenamientoFilas.Count Then
                        Dim orde = OrdenamientoFilas.GetKey(indice)
                        grid(0, column.Index) = orde
                        indice += 1
                    End If

                End If
            End If

        Next

        Dim nivel() As String
        nivel = grid.Name.Split("_")
        grid.Rows.Insert(0)
        grid(0, 0) = "B: " + Bloque

        grid(0, 1) = "N: " + nivel(1)

        For Each row As C1.Win.C1FlexGrid.Row In grid.Rows
            For cell As Int32 = 0 To grid.Cols.Count - 1
                If row.Index = 0 Or row.Index = 1 Then
                    'Dim colores As String
                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                    ColorCell = grid.Styles.Add("ColorCelda" + row.Index.ToString + cell.ToString)
                    ColorCell.BackColor = Color.White
                    ColorCell.ForeColor = Color.Black
                    grid.SetCellStyle(row.Index, cell, ColorCell)
                End If


                If cell = 0 Then


                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                    ColorCell = grid.Styles.Add("ColorCelda" + row.Index.ToString + cell.ToString)
                    ColorCell.BackColor = Color.White
                    ColorCell.ForeColor = Color.Black
                    grid.SetCellStyle(row.Index, cell, ColorCell)
                End If
            Next
        Next



    End Sub








    Private Sub VerTodoslosNiveles_Click(sender As Object, e As EventArgs) Handles MyBase.Click

    End Sub

    Private Sub VerTodoslosNiveles_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If verOcupacion = True Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                opciones.Show(MousePosition.X, MousePosition.Y)
            End If
        End If

    End Sub

    Private Sub DetalleOcupacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleOcupacionToolStripMenuItem.Click
        If verOcupacion = True Then
            Dim DetallesOcupacion As New DetallesOcupacionForm

            DetallesOcupacion.BahiasVerde = BahiasVerde
            DetallesOcupacion.BahiasParesVerde = BahiasParesVerde

            DetallesOcupacion.BahiasAzul = BahiasAzul
            DetallesOcupacion.BahiasParesAzul = BahiasParesAzul

            DetallesOcupacion.BahiasNaranja = BahiasNaranja
            DetallesOcupacion.BahiasParesNaranja = BahiasParesNaranja

            DetallesOcupacion.BahiasParesRojo = BahiasParesRojo
            DetallesOcupacion.BahiasRojo = BahiasRojo

            DetallesOcupacion.CapacidadTotal = CapacidadTotal
            DetallesOcupacion.CapacidadUsada = CapacidadUsada

            DetallesOcupacion.Show()
        End If

    End Sub

    Private Sub VerTodoslosNiveles_HelpButtonClicked(sender As Object, e As ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        If verOcupacion = True Then
            Dim DetallesOcupacion As New DetallesOcupacionForm

            DetallesOcupacion.BahiasVerde = BahiasVerde
            DetallesOcupacion.BahiasParesVerde = BahiasParesVerde

            DetallesOcupacion.BahiasAzul = BahiasAzul
            DetallesOcupacion.BahiasParesAzul = BahiasParesAzul

            DetallesOcupacion.BahiasNaranja = BahiasNaranja
            DetallesOcupacion.BahiasParesNaranja = BahiasParesNaranja

            DetallesOcupacion.BahiasParesRojo = BahiasParesRojo
            DetallesOcupacion.BahiasRojo = BahiasRojo

            DetallesOcupacion.CapacidadTotal = CapacidadTotal
            DetallesOcupacion.CapacidadUsada = CapacidadUsada
            DetallesOcupacion.Text = "Resumen de Ocupación de Almacén: " + Almacen + "; Nave: " + Nave
            DetallesOcupacion.Show()
        End If
    End Sub


End Class