Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports System.Net
Imports Stimulsoft.Report
Imports Tools.Controles

Public Class AltaBahiasForm
    Public idAlmacen As Int32
    Public ListaClaves As New List(Of Entidades.Bahia)
    Public INSERTA As Int32 = 0
    Public posicionColumna As Int32
    Public listabahiagrid As New ListaGridsBahias
    Public listasenviar As New List(Of ListaGridsBahias)
    Dim ListaColoresDescripcion As HashSet(Of String)
    Dim ListasEstibasImprimir As New HashSet(Of Entidades.Bahia)
    Private Sub AltaBahiasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Bahias.Enabled = False
        gbxAlta.Visible = False
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Cursor = Cursors.WaitCursor
        GenerarMapaButton()
        AjustarTamaños()
        Cursor = Cursors.Default
        AjustarTamaños()
    End Sub

    Public Sub AjustarTamaños()
        For Each col As C1.Win.C1FlexGrid.Column In grdMatriz.Cols
            col.Width = 35
            col.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter

        Next
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            row.Height = 35
            row.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
        Next
    End Sub

    Public Sub GenerarMapaButton()
        grdColores.Rows.Clear()
        ListaClaves = New List(Of Entidades.Bahia)
        ListaColoresDescripcion = New HashSet(Of String)

        idAlmacen = New Int32
        ListaClaves = New List(Of Entidades.Bahia)
        INSERTA = New Int32
        posicionColumna = New Int32
        listabahiagrid = New ListaGridsBahias
        listasenviar = New List(Of ListaGridsBahias)

        If Not cmbBloques.SelectedIndex > 0 Then


            If Validaciones() = True Then


                If cmbBloques.SelectedIndex > 0 Then
                    grdMatriz.Rows.Count = 0
                    grdMatriz.Cols.Count = 0
                    DibujarMapa()
                    For Each cadena As String In ListaColoresDescripcion
                        Dim fragmentar() As String
                        fragmentar = cadena.Split("||")
                        Dim color As String
                        color = fragmentar(0)
                        color = color.Replace("A_", "")
                        color = color.Replace("R_", "")
                        color = color.Replace("G_", "")
                        color = color.Replace("B_", "")
                        Dim ArregloColores As String()
                        ArregloColores = color.Split("-")
                        Dim colores As String
                        colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))

                        grdColores.Rows.Add()
                        grdColores.Rows(grdColores.Rows.Count - 1).DefaultCellStyle.BackColor = ColorTranslator.FromHtml(colores)
                    Next
                Else
                    grdMatriz.Rows.Count = 0
                    grdMatriz.Cols.Count = 0
                    GenerarMapa()
                    btnGuardar.Enabled = True
                End If
            Else
                MsgBox("Alerta: Errores en la generacion, favor de revisar informacion", MsgBoxStyle.Exclamation, "Alerta")
            End If
        Else
            grdMatriz.Rows.Count = 0
            grdMatriz.Cols.Count = 0
            DibujarMapa()
            For Each cadena As String In ListaColoresDescripcion
                Dim fragmentar() As String
                fragmentar = cadena.Split("||")
                Dim color As String
                color = fragmentar(0)
                color = color.Replace("A_", "")
                color = color.Replace("R_", "")
                color = color.Replace("G_", "")
                color = color.Replace("B_", "")
                Dim ArregloColores As String()
                ArregloColores = color.Split("-")
                Dim colores As String
                colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
                If fragmentar(2).Length = 1 Then
                    If fragmentar(2).Contains(" ") Then
                        fragmentar(2) = "SIN DESCRIPCION"
                    End If
                End If

                grdColores.Rows.Add("", fragmentar(2))
                grdColores.Rows(grdColores.Rows.Count - 1).Cells(0).Style.BackColor = ColorTranslator.FromHtml(colores)
            Next
            Bahias.Enabled = True


        End If
        grdColores.Sort(grdColores.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
        AjustarTamaños()
    End Sub


    Public Function CasteostoChart(ByVal Input As String) As Char
        Dim chart As New Char
        chart = Convert.ToChar(Input)
        Return chart
    End Function
    Public Sub DibujarMapaExistente(ByVal configuracion As Entidades.ConfiguracionBahia)
        grdMatriz.Rows.Count = 0
        grdMatriz.Cols.Count = 0
        For A As Int32 = 1 To configuracion.pcobl_columnas
            Dim COLUMNA As New DataGridViewTextBoxColumn
            grdMatriz.Cols.Count = grdMatriz.Cols.Count + 1
        Next
        For B As Int32 = 1 To configuracion.pcobl_renglones
            grdMatriz.Rows.Add()
        Next
    End Sub
    Public Sub CargarInformacionGuardada(ByVal ListaBahias As List(Of Entidades.Bahia))
        For Each bahia As Entidades.Bahia In ListaBahias
            Dim getposicion As String()
            getposicion = bahia.bahi_posicion.Split(",")
            Dim X, Y As New Int32
            X = CInt(getposicion(0))
            Y = CInt(getposicion(1))
            Dim Codigo As String()
            Codigo = bahia.bahiaid.Split("-")

            grdMatriz(X, Y) = Codigo(0)
            Dim color As String
            color = bahia.bahi_color
            color = color.Replace("A_", "")
            color = color.Replace("R_", "")
            color = color.Replace("G_", "")
            color = color.Replace("B_", "")
            Dim ArregloColores As String()
            ArregloColores = color.Split("-")
            Dim colores As String
            colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
            Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
            ColorCell = Me.grdMatriz.Styles.Add("ColorCelda" + colores + Codigo(0))
            ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
            
            If bahia.bahi_activo = False Then
                ColorCell.ForeColor = Drawing.Color.Red
            Else
                ColorCell.ForeColor = Drawing.Color.Black
            End If

            If colores.Contains("#000000") = True Then
                ColorCell.ForeColor = Drawing.Color.White
            End If
            grdMatriz.SetCellStyle(X, Y, ColorCell)
            Dim itemlistacolores As String
            itemlistacolores = bahia.bahi_color + "||" + bahia.bahi_descripcion
            ListaColoresDescripcion.Add(itemlistacolores)
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

                Dim imagen2 As New Bitmap(New Bitmap(imagen), 35, 35)
                '  imagen2.Save("C:\", System.Drawing.Imaging.ImageFormat.Jpeg)
                grdMatriz.SetCellImage(X, Y, imagen2)
            End If
            'grdMatriz.Rows(X).Cells(Y).Style.BackColor = ColorTranslator.FromHtml(ArregloColores(1) + ArregloColores(2) + ArregloColores(3))
        Next
        ListaClaves = ListaBahias
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
    Public Sub GenerarMapa()
        Dim Bloque As String
        Dim FilaInferior, FilaSuperior, BahiaInferior, BahiaSuperior, NivelesInferior, NivelesSuperior, EstribasInferior, EstribasSuperior As New Int32
        Dim flagFila, flagBahia, flagNivel, flagEstiba As New Boolean
        Bloque = txtBloques.Text
        '--- Filas-----
        If Not IsNumeric(txtfilliminf.Text) Then
            FilaInferior = Convert.ToInt32(CasteostoChart(txtfilliminf.Text))
            flagFila = True
        Else
            FilaInferior = CInt(txtfilliminf.Text)
            flagFila = False
        End If

        If Not IsNumeric(txtfillimsup.Text) Then
            FilaSuperior = Convert.ToInt32(CasteostoChart(txtfillimsup.Text))
        Else
            FilaSuperior = CInt(txtfillimsup.Text)
        End If

        '--- Bahias-----

        If Not IsNumeric(txtliminfbahia.Text) Then
            BahiaInferior = Convert.ToInt32(CasteostoChart(txtliminfbahia.Text))
            flagBahia = True
        Else
            BahiaInferior = CInt(txtliminfbahia.Text)
            flagBahia = False
        End If
        If Not IsNumeric(txtlimsupbahia.Text) Then
            BahiaSuperior = Convert.ToInt32(CasteostoChart(txtlimsupbahia.Text))
        Else
            BahiaSuperior = CInt(txtlimsupbahia.Text)
        End If

        '---Niveles----

        If Not IsNumeric(txtliminfniv.Text) Then
            NivelesInferior = Convert.ToInt32(CasteostoChart(txtliminfniv.Text))
            flagNivel = True
        Else
            NivelesInferior = CInt(txtliminfniv.Text)
            flagNivel = False
        End If
        'If Not IsNumeric(txtlimsupniv.Text) Then
        '    NivelesSuperior = Convert.ToInt32(CasteostoChart(txtlimsupniv.Text))
        'Else
        '    NivelesSuperior = CInt(txtlimsupniv.Text)
        'End If

        '---Estibas----

        'If Not IsNumeric(txtliminfest.Text) Then
        '    EstribasInferior = Convert.ToInt32(CasteostoChart(txtliminfest.Text))
        '    flagEstiba = True
        'Else
        '    EstribasInferior = CInt(txtliminfest.Text)
        '    flagEstiba = False
        'End If
        'If Not IsNumeric(txtlimsupest.Text) Then
        '    EstribasSuperior = Convert.ToInt32(CasteostoChart(txtlimsupest.Text))
        'Else
        '    EstribasSuperior = CInt(txtlimsupest.Text)
        'End If

        Dim cONTADOR As Int32
        cONTADOR = 1
        Dim celda, COLUMNAC As New Int32
        celda = -1
        COLUMNAC = 0
        For fil As Int32 = FilaInferior To FilaSuperior
            Dim COLUMNA As New DataGridViewTextBoxColumn
            Dim CONT As New DataGridViewTextBoxColumn
            COLUMNA.Name = fil
            celda = 0
            COLUMNAC += 1
            grdMatriz.Cols.Count = grdMatriz.Cols.Count + 1

            ' COLUMNA.SortMode = DataGridViewColumnSortMode.NotSortable
            '  For niv As Int32 = NivelesInferior To NivelesInferior

            For bah As Int32 = BahiaSuperior To BahiaInferior Step -1



                Dim Str As String = String.Empty



                Str = txtBloques.Text.ToString
                If flagFila = True Then
                    Str += CChar(ChrW(fil))
                Else
                    Str += fil.ToString
                End If
                If flagBahia = True Then
                    Str += CChar(ChrW(bah))
                Else
                    Str += bah.ToString
                End If
                If flagNivel = True Then
                    Str += CChar(ChrW(NivelesInferior))
                Else
                    Str += NivelesInferior.ToString
                End If

                Str = Str.ToString

                If grdMatriz.Cols.Count = 1 Then
                    grdMatriz.Rows.Add()
                End If
                Dim Bahia As New Entidades.Bahia
                Bahia.bahi_activo = True
                Bahia.bahi_bloque = Bloque
                Bahia.bahi_descripcion = " "
                Bahia.bahia_nave = cmbNaves.SelectedValue
                Bahia.bahi_almacen = numAlmacen.Value.ToString
                Bahia.bahi_fechacreacion = Today.Date.ToShortDateString
                Bahia.bahi_fechamodificacion = Today.Date.ToShortDateString
                Bahia.bahi_fila = fil
                Bahia.bahi_nivel = NivelesInferior
                Bahia.bahi_posicion = celda.ToString + "," + (COLUMNAC - 1).ToString
                Bahia.bahi_segmento = bah
                Bahia.bahi_usuariocreoid = 1
                Bahia.bahi_usuariomodificaid = 1
                Bahia.bahiaid = Str + "-" + cmbNaves.SelectedValue.ToString + "-" + numAlmacen.Value.ToString
                Bahia.capacidadenpares = CInt(txtCapacidad.Text)
                '  Bahia.bahia_nave = cmbNaves.SelectedValue
                Bahia.bahi_almacen = numAlmacen.Value

                ListaClaves.Add(Bahia)
                grdMatriz(celda, (COLUMNAC - 1)) = Str
                'grdMatriz.Rows(celda).Cells(COLUMNAC - 2).ToolTipText = Str
                If (NivelesInferior Mod 2) = 0 Then
                    '      grdMatriz.Rows(celda).Cells(COLUMNAC - 1).Style.BackColor = Drawing.Color.SteelBlue
                    Bahia.bahi_color = "A_" + Drawing.Color.SteelBlue.A.ToString + "-" + "R_" + Drawing.Color.SteelBlue.R.ToString + "-G_" + Drawing.Color.SteelBlue.G.ToString + "-B_" + Drawing.Color.SteelBlue.B.ToString

                Else
                    '       grdMatriz.Rows(celda).Cells(COLUMNAC - 1).Style.BackColor = Drawing.Color.AliceBlue
                    Bahia.bahi_color = "A_" + Drawing.Color.AliceBlue.A.ToString + "-" + "R_" + Drawing.Color.AliceBlue.R.ToString + "-G_" + Drawing.Color.AliceBlue.G.ToString + "-B_" + Drawing.Color.AliceBlue.B.ToString
                End If




                cONTADOR += 1
                celda += 1

            Next
        Next

        '   Next

        Dim MULTIPLICANDO As New Int32
        MULTIPLICANDO = BahiaSuperior - BahiaInferior
        Dim FLAG As Boolean = True
        Dim POSICION As Int32
        POSICION = 0
        For niv As Int32 = NivelesInferior To NivelesSuperior
            Dim MAX As New Int32

            MAX = (niv) * (MULTIPLICANDO + 1)
            MAX = POSICION + MAX
            'grdMatriz.Rows.Insert(MAX, 1)
            POSICION += 1
        Next

        Dim Exito As New ExitoForm
        Exito.mensaje = "Se han generado " + (cONTADOR - 1).ToString + " bahías correctamente"
        Exito.ShowDialog()
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs)
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                            MsgBox(itembahia.bahiaid + itembahia.bahi_descripcion)
                        End If
                    Next
                End If
            Next
        Next
    End Sub
    Private Sub EditarBahiasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarBahiasToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim contador As Int32 = 0
        Dim distintos = False
        Dim datosbahia As New Entidades.Bahia
        Dim listaClientesBahias As New List(Of Entidades.ClientesAlmacen)
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        Try



                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                If contador = 0 Then
                                    datosbahia = itembahia
                                Else
                                    If datosbahia.bahi_descripcion = itembahia.bahi_descripcion And itembahia.bahi_color = datosbahia.bahi_color And datosbahia.capacidadenpares = itembahia.capacidadenpares Then
                                    Else

                                        distintos = True
                                    End If
                                End If
                                For Each lista As Entidades.ClientesAlmacen In itembahia.ListaClientes
                                    listaClientesBahias.Add(lista)
                                Next

                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    contador += 1
                End If
            Next
        Next

        If distintos = True Then
            If MessageBox.Show("Los datos seleccionados son diferentes, si se modifican perderan la configuracion anterior", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            Else
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        Dim Editar As New EditarRegistrosBahiaForm
        '  Editar.MdiParent = MdiParent
        Dim ColorCambio As Boolean = False
        If distintos = False Then
            Editar.txtDescripcion.Text = datosbahia.bahi_descripcion
            Editar.txtCapacidad.Text = datosbahia.capacidadenpares

            Dim color As String
            color = datosbahia.bahi_color
            color = color.Replace("A_", "")
            color = color.Replace("R_", "")
            color = color.Replace("G_", "")
            color = color.Replace("B_", "")
            Dim ArregloColores As String()
            ArregloColores = color.Split("-")
            Dim colores As String
            colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
            'color = color.Replace("#", "")

            Editar.txtColor.Text = ColorTranslator.FromHtml(colores).ToString
        End If
        Editar.ListaClientes = listaClientesBahias
        If Editar.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
                For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                    If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                        'MsgBox(cell.Value)
                        For Each itembahia As Entidades.Bahia In ListaClaves
                            Try
                                If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                    itembahia.bahi_descripcion = Editar.txtDescripcion.Text
                                    Dim color As String
                                    If Editar.ColorCambio = True Then
                                        itembahia.bahi_color = "A_" + Editar.cdlgPicket.Color.A.ToString + "-R_" + Editar.cdlgPicket.Color.R.ToString + "-G_" + Editar.cdlgPicket.Color.G.ToString + "-B_" + Editar.cdlgPicket.Color.B.ToString
                                        color = RGB2HTMLColor(Editar.cdlgPicket.Color.R, Editar.cdlgPicket.Color.G, Editar.cdlgPicket.Color.B)
                                    Else
                                        Dim color2 As String
                                        color2 = datosbahia.bahi_color
                                        color2 = color2.Replace("A_", "")
                                        color2 = color2.Replace("R_", "")
                                        color2 = color2.Replace("G_", "")
                                        color2 = color2.Replace("B_", "")
                                        Dim ArregloColores As String()
                                        ArregloColores = color2.Split("-")

                                        color = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
                                    End If



                                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                                    ColorCell = Me.grdMatriz.Styles.Add("ColorCelda" + color)
                                    ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(color)
                                    grdMatriz.SetCellStyle(row.Index, cell, ColorCell)
                                    Dim itemlistacolores As String
                                    itembahia.capacidadenpares = CInt(Editar.txtCapacidad.Text)
                                    itemlistacolores = itembahia.bahi_color + "||" + itembahia.bahi_descripcion
                                    ListaColoresDescripcion.Add(itemlistacolores)

                                    Dim ListaBahias As New List(Of Entidades.Estibas)
                                    For a As Int32 = 0 To Editar.numAddEstibas.Value - 1
                                        Dim Estiba As New Entidades.Estibas
                                        Estiba.esti_bahiaid = itembahia.bahiaid
                                        Estiba.esti_activo = True
                                        ListaBahias.Add(Estiba)
                                    Next
                                    itembahia.PListaEstibaBahia = ListaBahias
                                    Dim objbu As New Almacen.Negocios.BahiaBU
                                    objbu.EdicionBahiasMasiva(itembahia)
                                    For Each estiba In itembahia.PListaEstibaBahia
                                        objbu.AddEstivas(itembahia)
                                    Next
                                End If
                            Catch ex As Exception
                            End Try
                        Next
                    End If
                Next
            Next

            If Editar.ListaClientes.Count > 0 Then
                For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
                    For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                        If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                            For Each itembahia As Entidades.Bahia In ListaClaves

                                If Not IsNothing(grdMatriz(row.Index, cell)) Then


                                    If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                        Dim count As Int32 = 0
                                        For Each cliente As Entidades.ClientesAlmacen In Editar.ListaClientes
                                            count += 1
                                            'If count = 178 Then
                                            '    MsgBox("Aqui")
                                            '    Dim hola As String
                                            '    hola = "hola"
                                            'End If
                                            itembahia.Cliente = cliente
                                            Dim objbu As New Almacen.Negocios.ClientesAlmacenBU
                                            ' '  Dim listaclientes As New List(Of Entidades.ClientesAlmacen)
                                            ' Dim client As New Entidades.ClientesAlmacen
                                            '   listaclientes = itembahia.ListaClientes
                                            ' client.Cadena = cliente.Cadena
                                            'listaclientes.Add(client)
                                            'itembahia.ListaClientes = listaclientes
                                            'If cliente.Cadena = 131 Then
                                            '    MsgBox("Aqui")

                                            'End If

                                            If itembahia.Cliente.Cadena <> "" Or itembahia.Cliente.Cadena <> Nothing Then
                                                objbu.AltaBahiaCliente(itembahia)
                                            End If



                                        Next
                                    End If
                                End If
                            Next
                        End If
                    Next
                Next
            End If
            Dim Exito As New Tools.ExitoForm
            Exito.mensaje = "Registros modificados correctamente"
            Exito.ShowDialog()
            Cursor = Cursors.WaitCursor
            GenerarMapaButton()
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub grdMatriz_MouseDown(sender As Object, e As MouseEventArgs)
    End Sub
    Private Sub grdMatriz_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Reasignarposiciones()
        Dim configuracion As New Entidades.ConfiguracionBahia
        configuracion.pcobl_bloque = txtBloques.Text
        configuracion.pcobl_columnas = grdMatriz.Cols.Count
        configuracion.pcobl_renglones = grdMatriz.Rows.Count
        configuracion.pcobo_nave = cmbNaves.SelectedValue
        configuracion.pcobo_almacen = numAlmacen.Value.ToString
        configuracion.pcobl_nivel = txtliminfniv.Text
        Dim objbuc As New Almacen.Negocios.BahiaBU
        objbuc.AltaConfiguracionBloques(configuracion)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub grdMatriz_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        posicionColumna = e.ColumnIndex
        Pasillos.Show(MousePosition.X, MousePosition.Y)
    End Sub
    Private Sub grdMatriz_ColumnRemoved(sender As Object, e As DataGridViewColumnEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Reasignarposiciones()
        Dim configuracion As New Entidades.ConfiguracionBahia
        configuracion.pcobl_bloque = txtBloques.Text
        configuracion.pcobl_columnas = grdMatriz.Cols.Count
        configuracion.pcobl_renglones = grdMatriz.Rows.Count
        configuracion.pcobo_nave = cmbNaves.SelectedValue
        configuracion.pcobo_almacen = numAlmacen.Value.ToString
        configuracion.pcobl_nivel = txtliminfniv.Text
        Dim objbuc As New Almacen.Negocios.BahiaBU
        objbuc.AltaConfiguracionBloques(configuracion)
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub Reasignarposiciones()
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz(row.Index, cell) <> Nothing Then
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        Try
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                itembahia.bahi_posicion = row.Index.ToString + "," + cell.ToString
                                Dim OBJBU As New Negocios.BahiaBU
                                OBJBU.EdicionBahiasMasiva(itembahia)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                End If
            Next
        Next
    End Sub
    Private Sub grdMatriz_MouseDown1(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Bahias.Show(MousePosition.X, MousePosition.Y)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Cursor = Cursors.WaitCursor
        Dim ListaClavesSend As New HashSet(Of Entidades.Bahia)
        For Each bahia As Entidades.Bahia In ListaClaves
            Dim objbu As New Almacen.Negocios.BahiaBU
            Dim entidad As New Entidades.Bahia
            entidad = bahia
            entidad.bahiaid = bahia.bahiaid
            Try
                objbu.AltaBahia(entidad)
            Catch ex As Exception
                MessageBox.Show("Ya existe un bloque con caracteristicas similares.", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try


            For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
                For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                            ListaClavesSend.Add(itembahia)
                        End If
                    Next
                Next
            Next
        Next
        Dim configuracion As New Entidades.ConfiguracionBahia
        configuracion.pcobl_bloque = txtBloques.Text
        configuracion.pcobl_columnas = grdMatriz.Cols.Count
        configuracion.pcobl_renglones = grdMatriz.Rows.Count
        configuracion.pcobo_nave = cmbNaves.SelectedValue
        configuracion.pcobo_almacen = numAlmacen.Value.ToString
        configuracion.pcobl_nivel = txtliminfniv.Text
        Dim objbuc As New Almacen.Negocios.BahiaBU
        objbuc.AltaConfiguracionBloques(configuracion)
        Dim exito As New Tools.ExitoForm
        exito.mensaje = "se han guardado " + ListaClaves.Count.ToString + " bahías correctamente"
        exito.ShowDialog()
        Cursor = Cursors.Default
        btnGuardar.Enabled = False
        Bahias.Enabled = True
        Dim naveprov As New Int32
        Dim bloqueprov As String = String.Empty
        bloqueprov = txtBloques.Text
        naveprov = cmbNaves.SelectedValue
        cmbNaves.SelectedIndex = 0
        cmbNaves.SelectedValue = naveprov

        txtBloques.Text = ""
        txtfilliminf.Text = ""
        txtliminfbahia.Text = ""
        txtlimsupbahia.Text = ""
        txtfillimsup.Text = ""
        Try
            cmbBloques.Enabled = True
            cmbBloques = ComboCargarBloques(cmbBloques, cmbNaves.SelectedValue, numAlmacen.Value.ToString)
            'cmbBloques = Tools.Controles.ComboCargarBloques(cmbBloques, cmbNaves.SelectedValue, numAlmacen.Value.ToString)
            If cmbNaves.SelectedIndex > 0 Then
                btnVerTodo.Enabled = True
            Else
                btnVerTodo.Enabled = False
            End If
        Catch ex As Exception

        End Try
        cmbBloques.Text = bloqueprov
        GenerarMapaButton()
        gbxAlta.Visible = False

    End Sub

    Private Sub DesactivarBahiasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesactivarBahiasToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        Try
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                If itembahia.bahi_activo = True Then
                                    Dim validacion As New Boolean
                                    Dim objbu As New Almacen.Negocios.BahiaBU
                                    validacion = objbu.ValidadEstibasVacias(itembahia)
                                    If validacion = True Then
                                        itembahia.bahi_activo = False
                                        '  cell.Style.BackColor = Drawing.Color.Gray
                                        itembahia.bahi_color = "A_" + Drawing.Color.White.A.ToString + "-" + "R_" + Drawing.Color.White.R.ToString + "-G_" + Drawing.Color.White.G.ToString + "-B_" + Drawing.Color.White.B.ToString

                                        Dim color As String
                                        color = RGB2HTMLColor(Drawing.Color.White.R, Drawing.Color.White.G, Drawing.Color.White.B)
                                        Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                                        ColorCell = Me.grdMatriz.Styles.Add("ColorCelda" + color)
                                        ColorCell.ForeColor = Drawing.Color.Red
                                        grdMatriz.SetCellStyle(row.Index, cell, ColorCell)


                                        objbu.EdicionBahiasMasiva(itembahia)
                                        objbu.ActivarDesactivarEstibas(itembahia, False)
                                    Else
                                        MessageBox.Show("Esta bahía contiene mercancía, para desactivarla ubique mercancía en otra bahía.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                                        Cursor = Cursors.Default
                                        Exit Sub
                                    End If

                                Else
                                    itembahia.bahi_activo = True
                                    Dim color As String
                                    color = itembahia.bahi_color
                                    color = color.Replace("A_", "")
                                    color = color.Replace("R_", "")
                                    color = color.Replace("G_", "")
                                    color = color.Replace("B_", "")
                                    Dim ArregloColores As String()
                                    ArregloColores = color.Split("-")
                                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                                    ColorCell = Me.grdMatriz.Styles.Add("ColorCelda" + color)
                                    ColorCell.ForeColor = Drawing.Color.Black
                                    grdMatriz.SetCellStyle(row.Index, cell, ColorCell)
                                    Try
                                        color = RGB2HTMLColor(CInt(ArregloColores(1)), CInt(ArregloColores(2)), CInt(ArregloColores(3)))
                                        '  cell.Style.BackColor = ColorTranslator.FromHtml(color)
                                    Catch ex As Exception
                                        '  cell.Style.BackColor = Drawing.Color.White
                                        itembahia.bahi_color = "A_" + Drawing.Color.White.A + "-" + "R_" + Drawing.Color.White.R + "-G_" + Drawing.Color.White.G + "-B_" + Drawing.Color.White.B
                                    End Try
                                    Dim objbu As New Almacen.Negocios.BahiaBU
                                    objbu.ActivarDesactivarEstibas(itembahia, True)
                                    objbu.EdicionBahiasMasiva(itembahia)
                                End If
                            End If
                        Catch ex As Exception

                        End Try

                    Next
                End If
            Next
        Next
        Me.Cursor = Cursors.Default
        Dim Exito As New Tools.ExitoForm
        Exito.mensaje = "Guardado Correctamente"
        Exito.ShowDialog()
    End Sub

    Public Sub DibujarMapa()
        Dim objbu As New Negocios.BahiaBU
        idAlmacen = 1
        Dim ConfiguracionBahia As New Entidades.ConfiguracionBahia
        If idAlmacen > 0 Then
            ConfiguracionBahia = objbu.CargarConfiguracionBahia(cmbNaves.SelectedValue, numAlmacen.Value, cmbBloques.SelectedValue, txtliminfniv.Text)
            DibujarMapaExistente(ConfiguracionBahia)
            Dim listabahias As New List(Of Entidades.Bahia)
            listabahias = objbu.CargarMapaAlmacen(cmbNaves.SelectedValue, numAlmacen.Value, cmbBloques.SelectedValue, txtliminfniv.Text)
            CargarInformacionGuardada(listabahias)
        End If
    End Sub





    Private Sub AñadirClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AñadirClientesToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim AltaCliente As New AñadirClientesFormvb
        AltaCliente.ShowDialog()
        Me.Cursor = Cursors.WaitCursor
        If AltaCliente.ListaClientes.Count > 0 Then
            For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
                For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                    If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                        For Each itembahia As Entidades.Bahia In ListaClaves
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                For Each cliente As Entidades.ClientesAlmacen In AltaCliente.ListaClientes
                                    itembahia.Cliente = cliente
                                    Dim objbu As New Almacen.Negocios.ClientesAlmacenBU
                                    objbu.AltaBahiaCliente(itembahia)
                                Next
                            End If
                        Next
                    End If
                Next
            Next
        End If
        Me.Cursor = Cursors.Default
        Dim Exito As New Tools.ExitoForm
        Exito.mensaje = "Guardado Correctamente"
        Exito.ShowDialog()
    End Sub

    Private Sub ExpandirBahiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpandirBahiaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim BahiaPadre As String = String.Empty
        Dim color As New Color
        Dim change As Boolean = False
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    If change = False Then
                        BahiaPadre = CStr(grdMatriz(row.Index, cell))
                        change = True

                        For Each itembahia As Entidades.Bahia In ListaClaves
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                If itembahia.bahiaid.Contains(BahiaPadre) Then
                                    Dim objbu As New Almacen.Negocios.BahiaBU
                                    itembahia.bahi_color = "A_" + Drawing.Color.Black.A.ToString + "-R_" + Drawing.Color.Black.R.ToString + "-G_" + Drawing.Color.Black.G.ToString + "-B_" + Drawing.Color.Black.B.ToString
                                    objbu.EdicionBahiasMasiva(itembahia)
                                    Dim colores As String
                                    colores = RGB2HTMLColor(Drawing.Color.Black.R, Drawing.Color.Black.G, Drawing.Color.Black.B)
                                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                                    ColorCell = Me.grdMatriz.Styles.Add("ColorCelda" + colores)
                                    ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
                                    ColorCell.ForeColor = Drawing.Color.White
                                    grdMatriz.SetCellStyle(row.Index, cell, ColorCell)
                                End If
                            End If
                        Next

                    End If
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        Try
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                If Not itembahia.bahiaid.Contains(BahiaPadre) Then
                                    Dim objbu As New Almacen.Negocios.BahiaBU
                                    itembahia.bahi_bahiaprincipalid = BahiaPadre + "-" + cmbNaves.SelectedValue.ToString + "-" + numAlmacen.Value.ToString
                                    itembahia.bahi_activo = False
                                    itembahia.bahi_color = "A_" + Drawing.Color.Black.A.ToString + "-R_" + Drawing.Color.Black.R.ToString + "-G_" + Drawing.Color.Black.G.ToString + "-B_" + Drawing.Color.Black.B.ToString
                                    objbu.EstablecerBahiaMenores(itembahia)
                                    Dim colores As String
                                    colores = RGB2HTMLColor(Drawing.Color.Black.R, Drawing.Color.Black.G, Drawing.Color.Black.B)
                                    Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
                                    ColorCell = Me.grdMatriz.Styles.Add("ColorCelda" + colores)
                                    ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
                                    ColorCell.ForeColor = Drawing.Color.White
                                    grdMatriz.SetCellStyle(row.Index, cell, ColorCell)
                                End If
                            End If
                        Catch ex As Exception

                        End Try

                    Next
                End If




            Next
        Next
        Me.Cursor = Cursors.Default
        Dim Exito As New Tools.ExitoForm
        Exito.mensaje = "Guardado Correctamente"
        Exito.ShowDialog()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If grdColores.Rows.Count > 0 Then
            grdColores.Rows.Clear()
        End If
        If grdMatriz.Rows.Count > 0 Then
            grdMatriz.Rows.Count = 0

        End If
        Try
            cmbBloques.SelectedIndex = 0

        Catch ex As Exception

        End Try
        btnGenerar.Enabled = True
        txtBloques.Enabled = True
        cmbBloques.Enabled = False
        Bahias.Enabled = False
        gbxAlta.Visible = True

    End Sub


    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim columna As New DataGridViewTextBoxColumn
        Dim POSICION As New Int32
        POSICION = posicionColumna
        columna.Name = "pas" + (posicionColumna + 1).ToString
        columna.HeaderText = "Pasillo"
        ' grdMatriz.Columns.Insert(POSICION + 1, columna)
    End Sub

    Private Sub QuitarPasilloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarPasilloToolStripMenuItem.Click
        Dim columna As New DataGridViewTextBoxColumn
        Dim POSICION As New Int32
        POSICION = posicionColumna
        Try

            '  grdMatriz.Columns.Remove("pas" + posicionColumna.ToString)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    End Sub

    Private Sub grdMatriz_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub grdMatriz_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub grdMatriz_MouseClick(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Bahias.Show(MousePosition.X, MousePosition.Y)
        End If
    End Sub

    Private Sub AgregarPasilloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarPasilloToolStripMenuItem.Click
        Dim columna, celda As Int32
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    columna = row.Index
                    celda = cell
                End If
            Next
        Next
        grdMatriz.Cols.Insert(celda + 1)
        Me.Cursor = Cursors.WaitCursor
        Reasignarposiciones()
        Dim configuracion As New Entidades.ConfiguracionBahia
        Dim bloque As String
        If cmbBloques.Text <> Nothing Then
            bloque = cmbBloques.SelectedValue
        Else
            bloque = txtBloques.Text
        End If
        configuracion.pcobl_bloque = bloque
        configuracion.pcobl_columnas = grdMatriz.Cols.Count
        configuracion.pcobl_renglones = grdMatriz.Rows.Count
        configuracion.pcobo_nave = cmbNaves.SelectedValue
        configuracion.pcobo_almacen = numAlmacen.Value.ToString
        configuracion.pcobl_nivel = txtliminfniv.Text
        Dim objbuc As New Almacen.Negocios.BahiaBU
        objbuc.AltaConfiguracionBloques(configuracion)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub QuitarPasilloToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuitarPasilloToolStripMenuItem1.Click
        Dim columna, celda As Int32
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    columna = row.Index
                    celda = cell
                End If
            Next
        Next
        Dim cambio As Boolean = False
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows

            If grdMatriz(row.Index, celda) = Nothing Or grdMatriz(row.Index, celda) = "" Then

            Else
                cambio = True
            End If
        Next
        If cambio = False Then
            grdMatriz.Cols.Remove(celda)
        End If
        Me.Cursor = Cursors.WaitCursor
        Reasignarposiciones()
        Dim bloque As String
        If cmbBloques.Text <> Nothing Then
            bloque = cmbBloques.SelectedValue
        Else
            bloque = txtBloques.Text
        End If
        Dim configuracion As New Entidades.ConfiguracionBahia
        configuracion.pcobl_bloque = bloque
        configuracion.pcobl_columnas = grdMatriz.Cols.Count
        configuracion.pcobl_renglones = grdMatriz.Rows.Count
        configuracion.pcobo_nave = cmbNaves.SelectedValue
        configuracion.pcobo_almacen = numAlmacen.Value.ToString
        configuracion.pcobl_nivel = txtliminfniv.Text
        Dim objbuc As New Almacen.Negocios.BahiaBU
        objbuc.AltaConfiguracionBloques(configuracion)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbNaves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedIndexChanged
        Try
            cmbBloques = ComboCargarBloques(cmbBloques, cmbNaves.SelectedValue, numAlmacen.Value.ToString)
            'cmbBloques = Tools.Controles.ComboCargarBloques(cmbBloques, cmbNaves.SelectedValue, numAlmacen.Value.ToString)
            If cmbNaves.SelectedIndex > 0 Then
                btnVerTodo.Enabled = True
            Else
                btnVerTodo.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function ComboCargarBloques(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal Nave As Int32, ByVal Almacen As String) As System.Windows.Forms.ComboBox
        ComboCargarBloques = New ComboBox
        ComboCargarBloques = comboEntrada
        Dim OBJBU As New Almacen.Negocios.BahiaBU
        Dim tabla As New DataTable
        tabla = OBJBU.CargarBloquesCombo(Nave, Almacen)
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboCargarBloques.DataSource = tabla
        ComboCargarBloques.DisplayMember = "bahi_bloque"
        ComboCargarBloques.ValueMember = "bahi_bloque"
    End Function

    Public Sub DibujarMapasVerTODO(ByVal nivel As String, ByVal Bloque As String)
        Dim objbu As New Negocios.BahiaBU
        idAlmacen = 1
        Dim ConfiguracionBahia As New Entidades.ConfiguracionBahia
        If idAlmacen > 0 Then
            listabahiagrid = New ListaGridsBahias
            Dim grid As New C1.Win.C1FlexGrid.C1FlexGrid
            Dim listabahias As New List(Of Entidades.Bahia)
            ConfiguracionBahia = objbu.CargarConfiguracionBahia(cmbNaves.SelectedValue, numAlmacen.Value, Bloque, nivel.ToString)
            grid = DibujarMapaExistentesVERTODO(ConfiguracionBahia)

            listabahias = objbu.CargarMapaAlmacenCompleto(cmbNaves.SelectedValue, numAlmacen.Value, Bloque, nivel)
            listabahiagrid.PlistaBahias = listabahias

            grid = CargarInformacionGuardadaTODOS(listabahias, grid)
            listabahiagrid.PListaGrids = grid
        End If
    End Sub

    Public Function DibujarMapaExistentesVERTODO(ByVal configuracion As Entidades.ConfiguracionBahia) As C1.Win.C1FlexGrid.C1FlexGrid
        DibujarMapaExistentesVERTODO = New C1.Win.C1FlexGrid.C1FlexGrid
        DibujarMapaExistentesVERTODO.Rows.Count = 0
        DibujarMapaExistentesVERTODO.Cols.Count = 0
        For A As Int32 = 1 To configuracion.pcobl_columnas
            Dim COLUMNA As New DataGridViewTextBoxColumn
            DibujarMapaExistentesVERTODO.Cols.Count = DibujarMapaExistentesVERTODO.Cols.Count + 1

        Next
        For B As Int32 = 1 To configuracion.pcobl_renglones
            DibujarMapaExistentesVERTODO.Rows.Add()
        Next
        Return DibujarMapaExistentesVERTODO
    End Function


    Private Sub btnVerTodo_Click(sender As Object, e As EventArgs) Handles btnVerTodo.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objbu As New Almacen.Negocios.BahiaBU
        Dim tabla As New DataTable
        Dim Vertodo As New VerTodoslosNiveles
        Dim tablabloques As DataTable
        listasenviar = New List(Of ListaGridsBahias)

        tablabloques = objbu.CargarBloques(cmbNaves.SelectedValue, numAlmacen.Value.ToString)
        For Each rows As DataRow In tablabloques.Rows


            tabla = objbu.CargarNiveles(cmbNaves.SelectedValue, numAlmacen.Value.ToString, CStr(rows("bahi_bloque")))
            For Each row As DataRow In tabla.Rows
                ' MsgBox(row("bahi_nivel"))
                DibujarMapasVerTODO(CStr(row("bahi_nivel")), CStr(rows("bahi_bloque")))
                listabahiagrid.PBloque = CStr(rows("bahi_bloque"))
                listasenviar.Add(listabahiagrid)
            Next


        Next
        Vertodo.tablaBloques = tablabloques
        Vertodo.PListas = listasenviar
        Vertodo.Text = "Mapa Almacen: " + numAlmacen.Value.ToString + "; Nave: " + cmbNaves.Text
        Vertodo.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Public Function CargarInformacionGuardadaTODOS(ByVal ListaBahias As List(Of Entidades.Bahia), ByVal grd As C1.Win.C1FlexGrid.C1FlexGrid) As C1.Win.C1FlexGrid.C1FlexGrid
        For Each bahia As Entidades.Bahia In ListaBahias
            Dim getposicion As String()
            getposicion = bahia.bahi_posicion.Split(",")
            Dim X, Y As New Int32
            X = CInt(getposicion(0))
            Y = CInt(getposicion(1))
            Dim Codigo As String()
            Codigo = bahia.bahiaid.Split("-")
            grd(X, Y) = Codigo(0)
            Dim color As String
            color = bahia.bahi_color
            color = color.Replace("A_", "")
            color = color.Replace("R_", "")
            color = color.Replace("G_", "")
            color = color.Replace("B_", "")
            Dim ArregloColores As String()
            ArregloColores = color.Split("-")
            Dim colores As String
            colores = RGB2HTMLColor(ArregloColores(1), ArregloColores(2), ArregloColores(3))
            Dim ColorCell As C1.Win.C1FlexGrid.CellStyle
            ColorCell = grd.Styles.Add("ColorCelda" + colores)
            ColorCell.BackColor = System.Drawing.ColorTranslator.FromHtml(colores)
            grd.SetCellStyle(X, Y, ColorCell)
            'grdMatriz.Rows(X).Cells(Y).Style.BackColor = ColorTranslator.FromHtml(ArregloColores(1) + ArregloColores(2) + ArregloColores(3))
        Next
        Return grd

    End Function

    Private Sub AltaBahiasForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If

    End Sub

    Public Function Validaciones() As Boolean
        Dim valida As Boolean = True
        If cmbNaves.SelectedIndex <= 0 Then
            valida = False
        End If


        If cmbBloques.SelectedIndex = 0 And txtBloques.Text = "" Then
            valida = False
        Else

        End If


        If txtfilliminf.Text = "" Or txtfillimsup.Text = "" Then
            valida = False
        ElseIf txtfilliminf.Text <> "" Or txtfillimsup.Text <> "" Then
            If ValidarTipo(txtfilliminf.Text, txtfillimsup.Text) = False Or ValidarLimites(txtfilliminf.Text, txtfillimsup.Text) = False Then
                valida = False
            End If

        End If

        If txtliminfbahia.Text = "" Or txtlimsupbahia.Text = "" Then
            valida = False
        ElseIf txtliminfbahia.Text <> "" Or txtlimsupbahia.Text <> "" Then
            If ValidarTipo(txtliminfbahia.Text, txtlimsupbahia.Text) = False Or ValidarLimites(txtliminfbahia.Text, txtlimsupbahia.Text) = False Then
                valida = False
            End If
        End If

        If txtliminfniv.Text = "" Then
            valida = False

        End If

        If CInt(txtCapacidad.Text) <= 0 Then
            valida = False
        End If

        Return valida
    End Function

    Public Function ValidarTipo(ByVal Inferior As String, ByVal Superior As String) As Boolean
        If IsNumeric((Inferior)) And IsNumeric((Superior)) Then
            ValidarTipo = True
        ElseIf Char.IsLetter((Inferior)) And Char.IsLetter((Superior)) Then
            ValidarTipo = True
        Else
            ValidarTipo = False
        End If
        Return ValidarTipo
    End Function

    Public Function ValidarLimites(ByVal inferior As String, ByVal superior As String) As Boolean
        Try
            If CInt(Convert.ToInt32(CasteostoChart(inferior))) < CInt(Convert.ToInt32(CasteostoChart(superior))) Then
                ValidarLimites = True
            Else
                ValidarLimites = True
            End If
        Catch ex As Exception
            If CInt(inferior) < CInt(superior) Then
                ValidarLimites = True
            Else
                ValidarLimites = True
            End If
        End Try

    End Function

    Private Sub txtBloques_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBloques.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False

        ElseIf Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub AltaBahiasForm_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick

    End Sub

    Private Sub btnAgregarColumna_Click(sender As Object, e As EventArgs) Handles btnAgregarColumna.Click
        Dim objbu As New Negocios.BahiaBU
        Dim tablacolumna As New DataTable
        tablacolumna = objbu.AgregarColumna(cmbNaves.SelectedValue, numAlmacen.Value.ToString, cmbBloques.SelectedValue)

    End Sub

    Private Sub grdMatriz_Click1(sender As Object, e As EventArgs) Handles grdMatriz.Click
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        If Not IsNothing(grdMatriz(row.Index, cell)) Then
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                Dim buttonToolTip As New ToolTip()
                                buttonToolTip.ToolTipTitle = grdMatriz(row.Index, cell)
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
                                buttonToolTip.SetToolTip(grdMatriz, "Bahia: " + itembahia.bahiaid _
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

    End Sub


    Private Sub grdMatriz_MouseClick1(sender As Object, e As MouseEventArgs) Handles grdMatriz.MouseClick
        Try
            Dim columna, celda As Int32
            For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
                For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                    If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                        columna = row.Index
                        celda = cell
                    End If
                Next
            Next
            Dim cambio As Boolean = False
            For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows

                If grdMatriz(row.Index, celda) = Nothing Or grdMatriz(row.Index, celda) = "" Then

                Else
                    cambio = True
                End If
            Next
            If cambio = False Then
                QuitarPasilloToolStripMenuItem.Enabled = False
                ExpandirBahiaToolStripMenuItem.Enabled = False
                EditarBahiasToolStripMenuItem.Enabled = False
                DesactivarBahiasToolStripMenuItem.Enabled = False
                QuitarPasilloToolStripMenuItem1.Enabled = True


            Else
                QuitarPasilloToolStripMenuItem1.Enabled = False
                QuitarPasilloToolStripMenuItem.Enabled = False
                ExpandirBahiaToolStripMenuItem.Enabled = True
                EditarBahiasToolStripMenuItem.Enabled = True
                DesactivarBahiasToolStripMenuItem.Enabled = True
            End If

            If e.Button = Windows.Forms.MouseButtons.Right Then
                Bahias.Show(MousePosition.X, MousePosition.Y)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbBloques_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBloques.SelectedIndexChanged
        If cmbBloques.SelectedIndex > 0 Then
            btnGenerar.Enabled = True
        Else
            btnAgregar.Enabled = True
        End If
    End Sub

    Private Sub CrearBahiaDeReferenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearBahiaDeReferenciaToolStripMenuItem.Click


    End Sub

    Public Sub SeleccionarImagen(ByVal idImagen As Int32)

        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        If Not IsNothing(grdMatriz(row.Index, cell)) Then
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then

                                Dim objbu As New Almacen.Negocios.BahiaBU
                                Dim validacion As New Boolean

                                validacion = objbu.ValidadEstibasVacias(itembahia)
                                If validacion = True Then


                                    Dim imagen As Bitmap

                                    Dim ruta As String = ""
                                    ruta = objbu.BuscarRutaImagen(idImagen)
                                    Try
                                        Dim objTran As New TransferenciaFTP
                                        Dim request = DirectCast(WebRequest.Create(objTran.obtenerURL), FtpWebRequest)
                                        request.Credentials = New NetworkCredential(objTran.obtenerUsuario, objTran.obtenerContrasena)
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
                                        Dim objFTP As New Tools.TransferenciaFTP
                                        Dim Stream As System.IO.Stream
                                        Stream = objFTP.StreamFile(Carpeta, nombrearchivo)
                                        imagen = Image.FromStream(Stream)
                                    Catch

                                    End Try
                                    Try
                                        Dim imagen2 As New Bitmap(New Bitmap(imagen), 32, 35)
                                        grdMatriz.SetCellImage(row.Index, cell, imagen2)
                                    Catch ex As Exception
                                        grdMatriz.SetUserData(row.Index, cell, itembahia.bahiaid)
                                    End Try

                                    '  imagen2.Save("C:\", System.Drawing.Imaging.ImageFormat.Jpeg)

                                    itembahia.bahi_referenciaubicacionid = idImagen
                                    If idImagen = 0 Then
                                        itembahia.bahi_activo = True
                                    Else
                                        itembahia.bahi_activo = False
                                    End If

                                    objbu.EdicionBahiasMasiva(itembahia)




                                Else
                                    MessageBox.Show("Esta bahía contiene mercancía, para desactivarla ubique mercancía en otra bahía.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                                    Cursor = Cursors.Default
                                    Exit Sub
                                End If








                            End If
                        End If








                    Next




                End If
            Next
        Next
    End Sub

    Private Sub BANDAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BANDAToolStripMenuItem.Click
        SeleccionarImagen(1)
    End Sub

    Private Sub ESCRITORIOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ESCRITORIOToolStripMenuItem.Click
        SeleccionarImagen(3)
    End Sub

    Private Sub ESCALERAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ESCALERAToolStripMenuItem.Click
        SeleccionarImagen(2)
    End Sub

    Private Sub PUERTAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PUERTAToolStripMenuItem.Click
        SeleccionarImagen(4)
    End Sub

    Private Sub BAÑOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BAÑOToolStripMenuItem.Click
        SeleccionarImagen(5)
    End Sub

    Private Sub NINGUNAQUITARBAHIADEREFERENCIAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NINGUNAQUITARBAHIADEREFERENCIAToolStripMenuItem.Click
        SeleccionarImagen(0)
        Cursor = Cursors.WaitCursor
        GenerarMapaButton()
        AjustarTamaños()
        Cursor = Cursors.Default
    End Sub

    'Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
    '    Dim Cargando As New Cargando
    '    Cargando.Show()
    'End Sub

    Private Sub lbltitle_Click(sender As Object, e As EventArgs) Handles lbltitle.Click

    End Sub

    Private Sub btnMapaOcupacion_Click(sender As Object, e As EventArgs) Handles btnMapaOcupacion.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim vertodoslosniveles As New VerTodoslosNiveles
            vertodoslosniveles.externo = True
            vertodoslosniveles.verOcupacion = True
            Dim NavesAlmacen As String
            vertodoslosniveles.Text = "Mapa Almacen: " + numAlmacen.Value.ToString + "; Nave: " + cmbNaves.Text
            NavesAlmacen = cmbNaves.SelectedValue.ToString + "," + numAlmacen.Value.ToString
            vertodoslosniveles.NavesAlmacen = NavesAlmacen
            vertodoslosniveles.Nave = cmbNaves.Text
            vertodoslosniveles.Almacen = numAlmacen.Value.ToString
            vertodoslosniveles.Show()
            vertodoslosniveles.BringToFront()
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ImprimirLetrerosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirLetrerosToolStripMenuItem.Click
        ListasEstibasImprimir = New HashSet(Of Entidades.Bahia)
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        If Not IsNothing(grdMatriz(row.Index, cell)) Then
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                If itembahia.bahi_activo = True Then
                                    ListasEstibasImprimir.Add(itembahia)
                                End If
                            End If
                        End If


                    Next
                End If
            Next
        Next

        Dim objbu As New Negocios.BahiaBU
        Dim ds As New DataTable
        ds = objbu.ImprimirEstibas(ListasEstibasImprimir)
        If Not IsNothing(ds) Then



            Try
                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU2 As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU2.LeerReporteporClave("ALM_IMP_EST")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(ds)
                reporte.Render(False)
                reporte.Show()
            Catch ex As Exception
                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "Seleccione Bahías Activas"
                advertencia.ShowDialog()
            Finally
                Me.Cursor = Cursors.Default
            End Try

        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Seleccione Bahías Activas"
            advertencia.ShowDialog()

        End If





    End Sub

    Private Sub numAlmacen_ValueChanged(sender As Object, e As EventArgs) Handles numAlmacen.ValueChanged
        Try
            cmbBloques = ComboCargarBloques(cmbBloques, cmbNaves.SelectedValue, numAlmacen.Value.ToString)
            'cmbBloques = Tools.Controles.ComboCargarBloques(cmbBloques, cmbNaves.SelectedValue, numAlmacen.Value.ToString)
            If cmbNaves.SelectedIndex > 0 Then
                btnVerTodo.Enabled = True
            Else
                btnVerTodo.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNivelleer_TextChanged(sender As Object, e As EventArgs) Handles txtNivelleer.TextChanged
        txtliminfniv.Text = txtNivelleer.Text
    End Sub

    Private Sub ContenidoActualDelAlmacenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContenidoActualDelAlmacenToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ListasEstibasImprimir = New HashSet(Of Entidades.Bahia)
        For Each row As C1.Win.C1FlexGrid.Row In grdMatriz.Rows
            For cell As Int32 = 0 To grdMatriz.Cols.Count - 1
                If grdMatriz.IsCellSelected(row.Index, cell) = True Then
                    For Each itembahia As Entidades.Bahia In ListaClaves
                        If Not IsNothing(grdMatriz(row.Index, cell)) Then
                            If itembahia.bahiaid.Contains(grdMatriz(row.Index, cell)) Then
                                If itembahia.bahi_activo = True Then
                                    ListasEstibasImprimir.Add(itembahia)
                                End If
                            End If
                        End If


                    Next
                End If
            Next
        Next

        Dim objbu As New Negocios.BahiaBU
        Dim ds As New DataTable
        ds = objbu.ObtenerContenidoBahia(ListasEstibasImprimir)

        Dim urllogotipo As String = String.Empty
        Dim objtools As New Tools.Controles
        urllogotipo = Controles.ObtenerLogoNave(cmbNaves.SelectedValue)
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(ds) Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU2 As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU2.LeerReporteporClave("ALM_BAH_CONT")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()

                Dim url As Object = reporte("urlImagenNave")
                reporte("urlImagenNave") = urllogotipo

                Dim nomreporte As Object = reporte("NombreReporte")
                reporte("NombreReporte") = "ContenidoActual.mrt"

                Dim Usuario As Object = reporte("Usuario")
                reporte("Usuario") = "Usuario: " + Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                Dim nomNave As Object = reporte("nombreNave")
                reporte("nombreNave") = cmbNaves.Text
                reporte.RegData(ds)
                reporte.Render(False)
                reporte.Show()
            Catch ex As Exception
                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "Seleccione Bahías Activas"
                advertencia.ShowDialog()
            Finally
                Me.Cursor = Cursors.Default
            End Try

        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Seleccione Bahías Activas"
            advertencia.ShowDialog()
        End If





        Cursor = Cursors.Default

    End Sub

    Private Sub btnLimpiarBahia_Click(sender As Object, e As EventArgs) Handles btnLimpiarBahia.Click
        Dim form As New LimpiarParesBahiaForm
        form.ShowDialog()
    End Sub
End Class








