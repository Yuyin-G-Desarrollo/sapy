Imports Infragistics.Win.UltraWinGrid
Imports System
Imports System.IO
Imports System.Collections
Public Class SalidaNavesForm
    Dim docenaspares As New Entidades.DocenasPares
    Dim Listadocenaspares As New HashSet(Of Entidades.DocenasPares)
    Dim tamañoatado As Int32
    Dim listacapturados As New HashSet(Of String)
    Dim ListaIncorrectos As New HashSet(Of String)
    Dim DatosFuente As DataTable
    Dim DatosIncorrectos As DataTable
    Dim CodigoAtado As String
    Dim insertocodigoatado As Boolean = False
    Dim ListaEntidades As New HashSet(Of Entidades.LecturaCapturadoAtadoPar)
    Dim ListaParesErroneos As New List(Of Entidades.LecturaCapturadoAtadoPar)
    Dim ListaParesLeidos As New List(Of Entidades.LecturaCapturadoAtadoPar)
    Dim ContadorAtados As Int32 = 1
    Dim validarCodigoCliente As Boolean = True
    Dim verificarporpar As Boolean = True
    Dim listalotesincompletos, ListaLotes As New HashSet(Of Int32)

    Private Sub SalidaNavesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbNaves = Tools.Controles.ComboNavesSegunUsuario(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cmbOperador = Tools.Controles.ComboOperadores(cmbOperador)
        DatosFuente = FormadoGridCapturado()
        DatosIncorrectos = FormadoGridErroneos()
        grdLectura.DataSource = DatosFuente
        grdIncorrecto.DataSource = DatosIncorrectos
    End Sub
    Private Sub txtcapturacodigos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcapturacodigos.KeyPress


        If e.KeyChar = ChrW(Keys.Enter) Then
            CapturaParAtadosYuyin(txtcapturacodigos.Text)
        End If

    End Sub
    Public Function FormadoGridCapturado() As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("Lote")
        tabla.Columns.Add("#")
        tabla.Columns.Add("Atado")
        tabla.Columns.Add("Par")
        tabla.Columns.Add("Descripcion")
        tabla.Columns.Add("Talla")
        tabla.Columns.Add("Boleano")

        Return tabla
    End Function
    Public Function FormadoGridErroneos() As DataTable
        Dim tabla As New DataTable
        tabla.Columns.Add("Lote")
        tabla.Columns.Add("#")
        tabla.Columns.Add("Atado")
        tabla.Columns.Add("Par")
        tabla.Columns.Add("Descripcion")
        tabla.Columns.Add("Talla")
        tabla.Columns.Add("Boleano")
        Return tabla
    End Function
    Private Sub btnLeerArchivo_Click(sender As Object, e As EventArgs) Handles btnLeerArchivo.Click
        Dim ruta As String = ""
        If opnArchivo.ShowDialog = Windows.Forms.DialogResult.OK Then
            ruta = opnArchivo.FileName.ToString
        End If
        txtcapturacodigos.Focus()
        Dim evento As New KeyPressEventArgs((ChrW(Keys.Enter)))

        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                sLine = sLine.Replace(" ", "")
                txtcapturacodigos.Text = sLine
                txtcapturacodigos_KeyPress(txtcapturacodigos, evento)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        For Each sLine In arrText
            txtcapturacodigos.Text = sLine

        Next


        DatosIncorrectos = FormadoGridErroneos()
        grdIncorrecto.DataSource = DatosIncorrectos

        CargarAtadosErroneos()
        ValidarAtadosCompletosYuyin()
        Resumen()
        VerificarLotesCompletos()


    End Sub
    Public Sub CapturaParAtadosYuyin(ByVal Cadena As String)
        If Cadena.Length = 11 Then
            verificarporpar = True
            validarCodigoCliente = True
            Dim objbu As New Negocios.SalidaNavesBU
            ListaEntidades = New HashSet(Of Entidades.LecturaCapturadoAtadoPar)
            docenaspares = New Entidades.DocenasPares
            docenaspares = objbu.ConsultarIDDocena(txtcapturacodigos.Text)
            Dim entidadvalidarparporpar As New Entidades.ConfiguracionClientesAtado
            entidadvalidarparporpar = objbu.ValidarParPorPar(docenaspares.PNoCliente)
            verificarporpar = entidadvalidarparporpar.Pccve_validarsalidaporpar
            docenaspares.PLeerParPorPar = verificarporpar
            tamañoatado = docenaspares.PID_Par.Count
            If objbu.ValidarLoteTerminado(docenaspares.PLote, cmbNaves.SelectedValue) = False Then
                listalotesincompletos.Add(docenaspares.PLote)
            End If
            ListaLotes.Add(docenaspares.PLote)
            ListaParesLeidos = New List(Of Entidades.LecturaCapturadoAtadoPar)
            ListaParesErroneos = New List(Of Entidades.LecturaCapturadoAtadoPar)
            Dim contiene As Boolean = False
            If Listadocenaspares.Count > 0 Then
                Try
                    For Each entidad As Entidades.DocenasPares In Listadocenaspares
                        If entidad.PID_Docena.Contains(docenaspares.PID_Docena) Then
                            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                                If row.Cells("Atado").Value = docenaspares.PID_Docena And row.Cells("Boleano").Value = "" Then
                                    row.Selected = True
                                    grdLectura.DeleteSelectedRows(False)
                                    Try
                                        For Each par As Entidades.LecturaCapturadoAtadoPar In entidad.PParesLeidos
                                            For Each rowi As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                                                If rowi.Cells("Atado").Value = docenaspares.PID_Docena And rowi.Cells("Par").Value = par.pcodigopar Then
                                                    rowi.Selected = True
                                                    grdLectura.DeleteSelectedRows(False)
                                                End If
                                            Next
                                        Next
                                    Catch ex As Exception

                                    End Try

                                    Try

                                    Catch ex As Exception

                                    End Try
                                    For Each par As Entidades.LecturaCapturadoAtadoPar In entidad.PParesErrones
                                        For Each rowi As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                                            If rowi.Cells("Atado").Value = docenaspares.PID_Docena And rowi.Cells("Par").Value = par.pcodigopar Then
                                                rowi.Selected = True
                                                grdLectura.DeleteSelectedRows(False)
                                            End If
                                        Next
                                    Next
                                End If
                            Next




                            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdIncorrecto.Rows
                                If row.Cells("Atado").Value = docenaspares.PID_Docena And row.Cells("Boleano").Value = "" Then
                                    row.Selected = True
                                    grdLectura.DeleteSelectedRows(False)
                                    Try
                                        For Each par As Entidades.LecturaCapturadoAtadoPar In entidad.PParesLeidos
                                            For Each rowi As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                                                If rowi.Cells("Atado").Value = docenaspares.PID_Docena And rowi.Cells("Par").Value = par.pcodigopar Then
                                                    rowi.Selected = True
                                                    grdLectura.DeleteSelectedRows(False)
                                                End If
                                            Next
                                        Next
                                    Catch ex As Exception

                                    End Try

                                    Try

                                    Catch ex As Exception

                                    End Try
                                    For Each par As Entidades.LecturaCapturadoAtadoPar In entidad.PParesErrones
                                        For Each rowi As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                                            If rowi.Cells("Atado").Value = docenaspares.PID_Docena And rowi.Cells("Par").Value = par.pcodigopar Then
                                                rowi.Selected = True
                                                grdLectura.DeleteSelectedRows(False)
                                            End If
                                        Next
                                    Next
                                End If
                            Next






                            docenaspares = entidad
                            docenaspares.PParesLeidos = New List(Of Entidades.LecturaCapturadoAtadoPar)
                            docenaspares.PParesErrones = New List(Of Entidades.LecturaCapturadoAtadoPar)
                            docenaspares.PTipoErrorAtado = ""
                            contiene = True
                        End If
                    Next
                Catch ex As Exception

                End Try

            End If

            If contiene = False Then
                Dim Leidos, Erroneos As New List(Of Entidades.LecturaCapturadoAtadoPar)
                docenaspares.PParesLeidos = Leidos
                docenaspares.PParesErrones = Erroneos
                Listadocenaspares.Add(docenaspares)
            End If


            CodigoAtado = txtcapturacodigos.Text
            txtcapturacodigos.Text = ""
            insertocodigoatado = False

            Dim rowDT As UltraGridRow = Me.grdLectura.DisplayLayout.Bands(0).AddNew()
            rowDT.Cells("Lote").Value = docenaspares.PLote.ToString
            rowDT.Cells("#").Value = "Atado: " + ContadorAtados.ToString
            rowDT.Cells("Atado").Value = docenaspares.PID_Docena
            rowDT.Cells("Par").Value = " "
            rowDT.Cells("Descripcion").Value = docenaspares.PDescripcion
            rowDT.Cells("Talla").Value = " "
            rowDT.Cells("Boleano").Value = ""
            ContadorAtados += 1

        Else
            If verificarporpar = True Then


                If Cadena.Length = 27 Then

                    Dim AtadoError As String = String.Empty
                    If CodigoAtado.Length > 0 Then
                        AtadoError = CodigoAtado
                    End If

                    Dim contador As New Int32
                    Dim ParCorrecto As Boolean = False
                    If insertocodigoatado = False Then
                        listacapturados.Add(CodigoAtado)
                        insertocodigoatado = True

                    End If
                    Dim entidadtemporal As New Entidades.LecturaCapturadoAtadoPar
                    Dim Contiene As Boolean = False
                    For Each entidad As Entidades.LecturaCapturadoAtadoPar In docenaspares.PID_Par
                        If txtcapturacodigos.Text.Contains(entidad.pcodigopar) Then
                            ParCorrecto = True
                            contador += 1

                            entidad.pcodigopar = txtcapturacodigos.Text
                            listacapturados.Add(txtcapturacodigos.Text)
                            entidad.PEstatus = True
                            entidadtemporal = entidad


                            For Each leido As Entidades.LecturaCapturadoAtadoPar In ListaParesLeidos
                                If leido.pcodigopar.Contains(txtcapturacodigos.Text) Then
                                    Contiene = True
                                End If
                            Next

                            If Contiene = False Then
                                ListaParesLeidos.Add(entidad)
                            End If



                        Else

                        End If
                    Next

                    If ParCorrecto = True Then

                    Else
                        If AtadoError.Length > 0 Then
                            ListaIncorrectos.Add(CodigoAtado)
                            AtadoError = ""
                        End If
                        entidadtemporal.pcodigoatado = CodigoAtado
                        entidadtemporal.pcodigopar = txtcapturacodigos.Text
                        entidadtemporal.PEstatus = False
                        listacapturados.Add(txtcapturacodigos.Text)
                        ListaIncorrectos.Add(txtcapturacodigos.Text)

                        For Each leido As Entidades.LecturaCapturadoAtadoPar In ListaParesErroneos
                            If leido.pcodigopar.Contains(txtcapturacodigos.Text) Then
                                Contiene = True
                            End If
                        Next

                        If Contiene = False Then
                            ListaParesErroneos.Add(entidadtemporal)
                        End If




                    End If
                    ListaEntidades.Add(entidadtemporal)

                    docenaspares.PParesLeidos = ListaParesLeidos

                    docenaspares.PParesErrones = ListaParesErroneos





                    txtcapturacodigos.Text = ""
                    If entidadtemporal.PEstatus = True Then
                        If Contiene = False Then
                            Dim rowDT As UltraGridRow = Me.grdLectura.DisplayLayout.Bands(0).AddNew()
                            rowDT.Cells("Lote").Value = entidadtemporal.PLote
                            rowDT.Cells("#").Value = "1"
                            rowDT.Cells("Atado").Value = entidadtemporal.pcodigoatado
                            rowDT.Cells("Par").Value = entidadtemporal.pcodigopar
                            rowDT.Cells("Descripcion").Value = entidadtemporal.PDescripcion
                            rowDT.Cells("Talla").Value = entidadtemporal.PTalla
                            rowDT.Cells("Boleano").Value = entidadtemporal.PEstatus
                        End If
                    Else
                        If Contiene = False Then
                            Dim rowDT As UltraGridRow = Me.grdIncorrecto.DisplayLayout.Bands(0).AddNew()
                            rowDT.Cells("Lote").Value = entidadtemporal.PLote
                            rowDT.Cells("#").Value = "1"
                            rowDT.Cells("Atado").Value = entidadtemporal.pcodigoatado
                            rowDT.Cells("Par").Value = entidadtemporal.pcodigopar
                            rowDT.Cells("Descripcion").Value = entidadtemporal.PDescripcion
                            rowDT.Cells("Talla").Value = entidadtemporal.PTalla
                            rowDT.Cells("Boleano").Value = entidadtemporal.PEstatus


                            Dim rowDT2 As UltraGridRow = Me.grdLectura.DisplayLayout.Bands(0).AddNew()
                            rowDT2.Cells("Lote").Value = entidadtemporal.PLote
                            rowDT2.Cells("#").Value = "1"
                            rowDT2.Cells("Atado").Value = entidadtemporal.pcodigoatado
                            rowDT2.Cells("Par").Value = entidadtemporal.pcodigopar
                            rowDT2.Cells("Descripcion").Value = entidadtemporal.PDescripcion
                            rowDT2.Cells("Talla").Value = entidadtemporal.PTalla
                            rowDT2.Cells("Boleano").Value = entidadtemporal.PEstatus
                        End If

                    End If




                Else


                    CargarAtadoCodigoCliente()
                    CargarParCliente()
                    ValidarCodigosCliente()
                End If
                txtcapturacodigos.Text = ""
            End If
        End If
        ValidarAtadosCompletosYuyin()
        '''''''''
        ''''''''XXXXXXXXXXXXXX
        '''''''

    End Sub

    Public Sub ValidarAtadosCompletosYuyin()
        Try
            If (docenaspares.PID_Par.Count) = docenaspares.PParesLeidos.Count Then
                docenaspares.PTipoErrorAtado = ""
            Else
                If docenaspares.PParesLeidos.Count < (docenaspares.PID_Par.Count) Then
                    docenaspares.PTipoErrorAtado = "INCOMPLETO"
                Else

                End If
            End If
            If docenaspares.PParesErrones.Count > 0 Then
                docenaspares.PTipoErrorAtado = "MAL FORMADO"
            End If
        Catch ex As Exception

        End Try



        Try
            For Each entidad As Entidades.DocenasPares In Listadocenaspares
                Try
                    If entidad.PParesErrones.Count > 0 Then
                        For Each lectura As Entidades.LecturaCapturadoAtadoPar In entidad.PParesErrones
                            If lectura.PEstatus = False Then
                                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                                    If row.Cells("Par").Text.Contains(lectura.pcodigopar) Then
                                        If row.Cells("Boleano").Text.Contains("False") Then
                                            row.Appearance.BackColor = Color.Salmon
                                        End If
                                    End If
                                Next

                                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdIncorrecto.Rows
                                    If row.Cells("Par").Text.Contains(lectura.pcodigopar) Then
                                        If row.Cells("Boleano").Text.Contains("False") Then
                                            row.Appearance.BackColor = Color.Salmon
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If

                    If entidad.PTipoErrorAtado.Contains("MAL FORMADO") Then
                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Blue
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdIncorrecto.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Blue
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                        Next

                    End If

                    If entidad.PTipoErrorAtado = "INCOMPLETO" Then

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Yellow
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdIncorrecto.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Yellow
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                        Next
                    End If


                    If entidad.PTipoErrorAtado = "" Then

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Green
                                    End If
                                End If
                            Catch ex As Exception

                            End Try

                        Next
                    End If


                    If entidad.PLeerParPorPar = False Then

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Green
                                    End If
                                End If
                            Catch ex As Exception

                            End Try

                        Next
                    End If

                Catch ex As Exception

                End Try

            Next
        Catch ex As Exception

        End Try



    End Sub



    Public Sub CargarAtadosErroneos()
        For Each entidad As Entidades.DocenasPares In Listadocenaspares
            If entidad.PTipoErrorAtado.Length > 0 And entidad.PLeerParPorPar = True Then
                Dim rowDT2 As UltraGridRow = Me.grdIncorrecto.DisplayLayout.Bands(0).AddNew()
                rowDT2.Cells("Lote").Value = entidad.PLote
                rowDT2.Cells("#").Value = "1"
                rowDT2.Cells("Atado").Value = entidad.PID_Docena
                rowDT2.Cells("Par").Value = ""
                rowDT2.Cells("Descripcion").Value = entidad.PDescripcion
                rowDT2.Cells("Talla").Value = ""
                rowDT2.Cells("Boleano").Value = ""
                For Each par As Entidades.LecturaCapturadoAtadoPar In entidad.PParesErrones
                    Dim rowDT As UltraGridRow = Me.grdIncorrecto.DisplayLayout.Bands(0).AddNew()
                    rowDT.Cells("Lote").Value = par.PLote
                    rowDT.Cells("#").Value = "1"
                    rowDT.Cells("Atado").Value = par.pcodigoatado
                    rowDT.Cells("Par").Value = par.pcodigopar
                    rowDT.Cells("Descripcion").Value = par.PDescripcion
                    rowDT.Cells("Talla").Value = par.PTalla
                    rowDT.Cells("Boleano").Value = par.PEstatus
                Next
            End If


        Next
    End Sub

    Private Sub grdIncorrecto_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdIncorrecto.ClickCell
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdIncorrecto.Rows
            If row.IsActiveRow = True Then
                Dim buscar As String
                buscar = row.Cells("Atado").Value
                For Each rowco As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                    If rowco.Cells("Atado").Value = buscar Then
                        rowco.Activate()
                        'grdIncorrecto
                    End If
                Next
            End If
        Next
    End Sub


    Public Sub Resumen()
        Dim totalAtadosLeidos, ParesLeidos, LotesLeidos As Int32
        Dim ParesIncorrectos, AtadosIncorrectos, LotesIncorrectos As Int32
        Dim ParesDescartados As Int32
        Dim ParesCorrectos, AtadosCorrectos, LotesCorrectos As Int32
        ', AtadosDescartados, LotesDescartados 
        totalAtadosLeidos = Listadocenaspares.Count
        For Each entidad As Entidades.DocenasPares In Listadocenaspares
            If entidad.PLeerParPorPar = False Then
                ParesLeidos += entidad.PID_Par.Count


            Else
                ParesLeidos += CInt(entidad.PParesLeidos.Count) + CInt(entidad.PParesErrones.Count)


                If entidad.PParesErrones.Count > 0 Then
                    ParesIncorrectos += entidad.PParesErrones.Count
                    AtadosIncorrectos += 1
                Else
                    ParesCorrectos += entidad.PParesLeidos.Count
                    AtadosCorrectos += 1
                End If



            End If




        Next

        For Each Lote As Int32 In ListaLotes
            Dim objbu As New Negocios.SalidaNavesBU
            Dim TamañoLote As New Int32
            TamañoLote = objbu.ParesLote(Lote, cmbNaves.SelectedValue)
            Dim pares As New Int32
            For Each entidad As Entidades.DocenasPares In Listadocenaspares
                If entidad.PLote = Lote Then
                    If entidad.PLeerParPorPar = True Then
                        pares += entidad.PParesLeidos.Count
                    Else
                        pares += entidad.PID_Par.Count
                    End If
                End If
            Next
            Dim ParesD As Int32
            ParesD = TamañoLote - pares
            If ParesD < 0 Then
                ParesD = (ParesD * (-1))
            End If
            If ParesD <> 0 Then
                LotesIncorrectos += 1
            Else
                LotesCorrectos += 1
            End If
            ParesDescartados += ParesD
        Next



        LotesIncorrectos = listalotesincompletos.Count
        LotesLeidos = ListaLotes.Count
        lblAtadosLeidos.Text = totalAtadosLeidos.ToString
        lblParesLeidos.Text = ParesLeidos.ToString
        lblLotesLeidos.Text = LotesLeidos.ToString
        lblParesDescartados.Text = ParesDescartados.ToString
        lblAtadosDescartados.Text = AtadosIncorrectos.ToString

        lblParesIncorrectos.Text = ParesIncorrectos.ToString
        lblAtadosIncorrectos.Text = AtadosIncorrectos.ToString
        lblLotesIncorrectos.Text = LotesIncorrectos.ToString

        lblParesDescartados.Text = ParesDescartados.ToString
        lblLotesDescardatos.Text = LotesIncorrectos.ToString
        lblAtadosDescartados.Text = AtadosIncorrectos.ToString

        lblAtadosCorrectos.Text = AtadosCorrectos.ToString
        lblParesCorrectos.Text = ParesCorrectos.ToString
        lblLotesCorrectos.Text = LotesCorrectos.ToString

    End Sub

    Public Sub CargarAtadoCodigoCliente()
        If validarCodigoCliente = True Then
            Dim objbu As New Negocios.SalidaNavesBU
            docenaspares = docenaspares
            docenaspares = objbu.ConsultarIDDocenaCodigoCliente(docenaspares.PID_Docena)
            Dim Leidos, Erroneos As New List(Of Entidades.LecturaCapturadoAtadoPar)
            docenaspares.PParesLeidos = Leidos
            docenaspares.PParesErrones = Erroneos
            validarCodigoCliente = False

            If Listadocenaspares.Count > 0 Then

                For Each entidad As Entidades.DocenasPares In Listadocenaspares
                    If entidad.PID_Docena.Contains(docenaspares.PID_Docena) Then


                        docenaspares.PParesLeidos = New List(Of Entidades.LecturaCapturadoAtadoPar)
                        docenaspares.PParesErrones = New List(Of Entidades.LecturaCapturadoAtadoPar)
                        docenaspares.PTipoErrorAtado = ""
                        entidad.PID_Par = docenaspares.PID_Par

                    End If
                Next


            End If

        End If


    End Sub


    Public Sub ValidarCodigosCliente()


        Try
            If (docenaspares.PID_Par.Count) = docenaspares.PParesLeidos.Count Then
                docenaspares.PTipoErrorAtado = ""
            Else
                If docenaspares.PParesLeidos.Count < (docenaspares.PID_Par.Count) Then
                    docenaspares.PTipoErrorAtado = "INCOMPLETO"
                Else

                End If
            End If
            If docenaspares.PParesErrones.Count > 0 Then
                docenaspares.PTipoErrorAtado = "MAL FORMADO"
            End If
        Catch ex As Exception

        End Try


        If Listadocenaspares.Count > 0 Then

            For Each entidad As Entidades.DocenasPares In Listadocenaspares
                If entidad.PID_Docena.Contains(docenaspares.PID_Docena) Then
                    entidad.PParesLeidos = docenaspares.PParesLeidos
                    entidad.PParesErrones = docenaspares.PParesErrones
                    entidad.PID_Par = docenaspares.PID_Par
                    entidad.PTipoErrorAtado = docenaspares.PTipoErrorAtado

                End If
            Next


        End If



        Try
            For Each entidad As Entidades.DocenasPares In Listadocenaspares
                Try
                    If entidad.PParesErrones.Count > 0 Then
                        For Each lectura As Entidades.LecturaCapturadoAtadoPar In entidad.PParesErrones
                            If lectura.PEstatus = False Then
                                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                                    If row.Cells("Par").Text.Contains(lectura.PCodigoCliente) Then
                                        If row.Cells("Boleano").Text.Contains("False") Then
                                            row.Appearance.BackColor = Color.Salmon
                                        End If
                                    End If
                                Next

                                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdIncorrecto.Rows
                                    If row.Cells("Par").Text.Contains(lectura.PCodigoCliente) Then
                                        If row.Cells("Boleano").Text.Contains("False") Then
                                            row.Appearance.BackColor = Color.Salmon
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If

                    If entidad.PTipoErrorAtado.Contains("MAL FORMADO") Then
                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Blue
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdIncorrecto.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Blue
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                        Next

                    End If

                    If entidad.PTipoErrorAtado = "INCOMPLETO" Then

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Yellow
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdIncorrecto.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Yellow
                                    End If

                                End If
                            Catch ex As Exception
                            End Try
                        Next
                    End If


                    If entidad.PTipoErrorAtado = "" Then

                        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In grdLectura.Rows
                            Try
                                If row.Cells("Atado").Text.Contains(entidad.PID_Docena) Then
                                    If row.Cells("Boleano").Text = "" Then
                                        row.Appearance.BackColor = Color.Green
                                    End If
                                End If
                            Catch ex As Exception

                            End Try

                        Next
                    End If

                Catch ex As Exception

                End Try

            Next
        Catch ex As Exception

        End Try



    End Sub


    Public Sub CargarParCliente()
        Dim AtadoError As String = String.Empty
        If CodigoAtado.Length > 0 Then
            AtadoError = CodigoAtado
        End If

        Dim contador As New Int32
        Dim ParCorrecto As Boolean = False
        If insertocodigoatado = False Then
            listacapturados.Add(CodigoAtado)
            insertocodigoatado = True

        End If
        Dim entidadtemporal As New Entidades.LecturaCapturadoAtadoPar
        Dim Contiene As Boolean = False
        For Each entidad As Entidades.LecturaCapturadoAtadoPar In docenaspares.PID_Par
            If txtcapturacodigos.Text.Contains(entidad.PCodigoCliente) And entidad.PLeido = False Then
                ParCorrecto = True
                contador += 1

                entidad.pcodigopar = txtcapturacodigos.Text
                listacapturados.Add(txtcapturacodigos.Text)
                entidad.PEstatus = True
                entidad.PLeido = True
                entidadtemporal = entidad
                ListaParesLeidos.Add(entidad)

                Exit For

            Else

            End If
        Next

        If ParCorrecto = True Then

        Else
            If AtadoError.Length > 0 Then
                ListaIncorrectos.Add(CodigoAtado)
                AtadoError = ""
            End If
            entidadtemporal.pcodigoatado = CodigoAtado
            entidadtemporal.pcodigopar = txtcapturacodigos.Text
            entidadtemporal.PEstatus = False
            listacapturados.Add(txtcapturacodigos.Text)
            ListaIncorrectos.Add(txtcapturacodigos.Text)
            ListaParesErroneos.Add(entidadtemporal)





        End If
        ListaEntidades.Add(entidadtemporal)

        docenaspares.PParesLeidos = ListaParesLeidos

        docenaspares.PParesErrones = ListaParesErroneos





        txtcapturacodigos.Text = ""
        If entidadtemporal.PEstatus = True Then
            If Contiene = False Then
                Dim rowDT As UltraGridRow = Me.grdLectura.DisplayLayout.Bands(0).AddNew()
                rowDT.Cells("Lote").Value = entidadtemporal.PLote
                rowDT.Cells("#").Value = "1"
                rowDT.Cells("Atado").Value = entidadtemporal.pcodigoatado
                rowDT.Cells("Par").Value = entidadtemporal.pcodigopar
                rowDT.Cells("Descripcion").Value = entidadtemporal.PDescripcion
                rowDT.Cells("Talla").Value = entidadtemporal.PTalla
                rowDT.Cells("Boleano").Value = entidadtemporal.PEstatus
            End If
        Else
            If Contiene = False Then
                Dim rowDT As UltraGridRow = Me.grdIncorrecto.DisplayLayout.Bands(0).AddNew()
                rowDT.Cells("Lote").Value = entidadtemporal.PLote
                rowDT.Cells("#").Value = "1"
                rowDT.Cells("Atado").Value = entidadtemporal.pcodigoatado
                rowDT.Cells("Par").Value = entidadtemporal.pcodigopar
                rowDT.Cells("Descripcion").Value = entidadtemporal.PDescripcion
                rowDT.Cells("Talla").Value = entidadtemporal.PTalla
                rowDT.Cells("Boleano").Value = entidadtemporal.PEstatus


                Dim rowDT2 As UltraGridRow = Me.grdLectura.DisplayLayout.Bands(0).AddNew()
                rowDT2.Cells("Lote").Value = entidadtemporal.PLote
                rowDT2.Cells("#").Value = "1"
                rowDT2.Cells("Atado").Value = entidadtemporal.pcodigoatado
                rowDT2.Cells("Par").Value = entidadtemporal.pcodigopar
                rowDT2.Cells("Descripcion").Value = entidadtemporal.PDescripcion
                rowDT2.Cells("Talla").Value = entidadtemporal.PTalla
                rowDT2.Cells("Boleano").Value = entidadtemporal.PEstatus
            End If

        End If







    End Sub



    Public Sub VerificarLotesCompletos()
        For Each Lote As Int32 In listalotesincompletos
            For Each entidad As Entidades.DocenasPares In Listadocenaspares
                If Lote = entidad.PLote Then
                    Dim rowDT2 As UltraGridRow = Me.grdIncorrecto.DisplayLayout.Bands(0).AddNew()
                    rowDT2.Cells("Lote").Value = entidad.PLote
                    rowDT2.Cells("#").Value = "1"
                    rowDT2.Cells("Atado").Value = entidad.PID_Docena
                    rowDT2.Cells("Par").Value = ""
                    rowDT2.Cells("Descripcion").Value = entidad.PDescripcion
                    rowDT2.Cells("Talla").Value = ""
                    rowDT2.Cells("Boleano").Value = ""
                    grdIncorrecto.Rows(grdIncorrecto.Rows.Count - 1).Appearance.BackColor = Color.Orange
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub cmbNaves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedIndexChanged
        Try
            If cmbNaves.SelectedIndex > 0 Then
                btnLeerArchivo.Enabled = True
                txtcapturacodigos.Enabled = True
            Else
                btnLeerArchivo.Enabled = False
                txtcapturacodigos.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class