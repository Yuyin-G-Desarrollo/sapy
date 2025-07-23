Imports Entidades
Imports Produccion.Negocios
Imports Tools

Public Class VerificarAvancesForm
    Dim objUsuarioSesion As Usuarios
    Dim listaDeps As New List(Of DepartamentosProduccion)
    Dim Departamentos As New List(Of DepartamentosProduccion)
    Dim ListaCelulas As New List(Of CelulasProduccion)
    Dim ColorCorte, ColorMontado, ColorPespunte, ColorNave As String

    Dim TotalPares, TotalLotes, ParesTerminados, LotesTerminados, ParesProceso, LotesProceso, ParesAtrasados, LotesAtrasados As Int32
    Private Sub VerificarAvancesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdAvances.AutoClipboard = True
        grdInventarioDepartamento.AutoClipboard = True
        grdInventarioNave.AutoClipboard = True
        grdResumenesDepartamentos.AutoClipboard = True

        WindowState = FormWindowState.Maximized
        grdInventarioDepartamento.Visible = False
        grdInventarioNave.Visible = False
        head.Visible = False
        head2.Visible = False

        Inicializar()
        ' grdResumenesDepartamentos.Rows(0).Visible = False
    End Sub
    Public Sub Inicializar()
        objUsuarioSesion = SesionUsuario.UsuarioSesion
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, objUsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged

        If cmbNave.SelectedIndex > 0 Then
            cmbDepartamento = Controles.ComboDepartamentosSegunNaveProduccion(cmbDepartamento, cmbNave.SelectedValue)
        End If
    End Sub

    Public Sub LlenarGrid()
        Dim ListaAvancesProduccion As New List(Of LotesAvances)
        Dim objBU As New LotesAvancesBU
        Dim diasAtrasados As New Int32
        Dim Naveid As Int32
        Dim Consecutivo As Int32 = 1
        If cmbNave.SelectedIndex > 0 Then
            Naveid = cmbNave.SelectedValue
        End If

        ' Dim Departamentos As New List(Of Int32)
        grdAvances.Cols.Count = 10
        If cmbDepartamento.SelectedValue > 0 Then
            For Each dep As DepartamentosProduccion In Departamentos
                If dep.PIDConfiguracion = cmbDepartamento.SelectedValue Then
                    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Fecha de Avance"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = dep.PNombre
                    'grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    'grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días retraso"
                    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Célula"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Célula"
                    If dep.PNombre = "CORTE" Then
                        ColorCorte = dep.PColorDepartamento
                    End If
                    If dep.PNombre = "PESPUNTE" Then
                        ColorPespunte = dep.PColorDepartamento
                    End If
                    If dep.PNombre = "MONTADO Y ADORNO" Then
                        ColorMontado = dep.PColorDepartamento
                    End If
                    If dep.PNombre = "EMBARQUE" Then
                        ColorNave = "#85A3FF"
                    End If

                End If


            Next

        Else
            For Each dep As DepartamentosProduccion In Departamentos
                grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = dep.PNombre
                grdAvances.Cols(grdAvances.Cols.Count - 1).Name = dep.PNombre
                'grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                'grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días retraso"
                grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Celula"
                If dep.PNombre = "CORTE" Then
                    ColorCorte = dep.PColorDepartamento
                End If
                If dep.PNombre = "PESPUNTE" Then
                    ColorPespunte = dep.PColorDepartamento
                End If
                If dep.PNombre = "MONTADO Y ADORNO" Then
                    ColorMontado = dep.PColorDepartamento
                End If
                If dep.PNombre = "EMBARQUE" Then
                    ColorNave = "#85A3FF"
                End If


            Next
        End If

        If cmbDepartamento.SelectedIndex = 0 Or cmbDepartamento.Text = "EMBARQUE" Then
            grdAvances.Cols.Count = grdAvances.Cols.Count + 1
            grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Fecha de Avance"
            grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "EMBARQUE"
            ListaAvancesProduccion = objBU.VerificarAvancesProduccionembarque(dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString, Naveid, listaDeps)

        Else
            ListaAvancesProduccion = objBU.VerificarAvancesProduccion(dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString, Naveid, listaDeps)


        End If

        For Each Lote As LotesAvances In ListaAvancesProduccion
            If cmbDepartamento.SelectedIndex = 0 Or cmbDepartamento.Text = "EMBARQUE" Then
                If Not Lote.PFechaEmbarque <> Date.MinValue Then
                    ParesTerminados += Lote.PPares
                    LotesTerminados += 1

                End If




                Dim strFila As String = "" + ControlChars.Tab & Consecutivo &
     ControlChars.Tab & Lote.PFechaLote &
                                   ControlChars.Tab & Lote.PLote &
                                   ControlChars.Tab & Lote.PMarca &
                                   ControlChars.Tab & Lote.PModelo &
                                   ControlChars.Tab & Lote.PColeccion &
                                   ControlChars.Tab & Lote.PTalla &
                                   ControlChars.Tab & Lote.PColor &
                                   ControlChars.Tab & Lote.PPares '&
                ' ControlChars.Tab & diasAtrasados ' &
                ' ControlChars.Tab & Lote.PObservaciones

                TotalPares += Lote.PPares
                TotalLotes += 1

                Dim diasTotales As Int32 = 0
                Dim estaatrasado As Boolean = False
                For Each departamentoAvance As DepartamentosProduccion In Lote.PAvanceDepartamentos
                    If departamentoAvance.PFechaAvance = Date.MinValue Then
                        strFila += ControlChars.Tab & ""
                    Else
                        strFila += ControlChars.Tab & departamentoAvance.PFechaAvance.ToShortDateString
                    End If

                    diasTotales = departamentoAvance.PDias - 1
                    Dim fechaInicio As New Date
                    fechaInicio = Lote.PFechaLote
                    Dim FechaFin As New Date
                    FechaFin = Today

                    While fechaInicio < FechaFin.AddDays(1)
                        If fechaInicio.DayOfWeek = 6 Then
                            diasTotales += 1
                        End If
                        fechaInicio = fechaInicio.AddDays(1)
                    End While

                    diasAtrasados = DateDiff("d", Lote.PFechaLote.AddDays(diasTotales), Today)

                    If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                        '  strFila += ControlChars.Tab & diasAtrasados.ToString
                        If diasAtrasados > 0 Then
                            ParesAtrasados += Lote.PPares
                            LotesAtrasados += 1
                        End If
                        estaatrasado = True
                    Else
                        ' strFila += ControlChars.Tab & " "
                    End If

                    If departamentoAvance.PCelulas = Nothing Then
                        strFila += ControlChars.Tab & "NO ASIGNADA"
                    Else
                        strFila += ControlChars.Tab & departamentoAvance.PCelulas
                        For Each Celula As CelulasProduccion In ListaCelulas
                            If Celula.PNombreCelula = departamentoAvance.PCelulas Then

                                If Not departamentoAvance.PFechaAvance = Date.MinValue Then
                                    Celula.PCantidadTerminadasPares += Lote.PPares
                                    Celula.PCantidadTerminadasLotes += 1


                                End If

                            End If
                        Next
                    End If

                    '*****************************




                    Dim Existe As Boolean = False
                    Dim Contado As Boolean = False
                    If ListaCelulas.Count <= 0 Then
                        Dim nuevaCelula As New CelulasProduccion
                        nuevaCelula.PNombreCelula = departamentoAvance.PCelulas
                        nuevaCelula.PCantidadAcumuladaLotes = 0
                        nuevaCelula.PCantidadAcumuladaPares = 0
                        nuevaCelula.PIDCelula = departamentoAvance.PIDConfiguracion
                        ListaCelulas.Add(nuevaCelula)
                    End If

                    For Each celula As CelulasProduccion In ListaCelulas

                        If departamentoAvance.PCelulas = celula.PNombreCelula Then
                            Existe = True
                            If Existe = True Then
                                If Contado = False Then
                                    celula.PCantidadAcumuladaLotes += 1
                                    celula.PCantidadAcumuladaPares += Lote.PPares
                                    Contado = True
                                End If

                            Else

                            End If
                        End If


                    Next

                    If Existe = False Then
                        Dim nuevaCelula As New CelulasProduccion
                        nuevaCelula.PNombreCelula = departamentoAvance.PCelulas
                        nuevaCelula.PCantidadAcumuladaLotes += 1
                        nuevaCelula.PCantidadAcumuladaPares += Lote.PPares
                        nuevaCelula.PIDCelula = departamentoAvance.PIDConfiguracion
                        ListaCelulas.Add(nuevaCelula)
                    End If

                    '********************************************


                Next



                If cmbDepartamento.SelectedIndex = 0 Or cmbDepartamento.Text = "EMBARQUE" Then
                    If Not Lote.PFechaEmbarque = Date.MinValue Then
                        strFila += ControlChars.Tab & Lote.PFechaEmbarque.ToShortDateString
                    Else
                        strFila += ControlChars.Tab & ""
                    End If
                End If

                If rdoAtrasados.Checked = True Or rdoTerminados.Checked = True Then
                    If rdoAtrasados.Checked = True Then
                        If estaatrasado = True Then


                            ' paresAtrasadosFiltro += Lote.PPares
                            ' LotesAtrasadosFiltro += 1
                            grdAvances.AddItem(strFila)
                        End If
                    Else

                    End If

                    If rdoTerminados.Checked = True Then
                        If Not Lote.PFechaEmbarque = Date.MinValue Then
                            grdAvances.AddItem(strFila)
                        End If
                    Else

                    End If
                Else
                    grdAvances.AddItem(strFila)
                End If

                Consecutivo += 1

            Else
                If Not Lote.PFechaEmbarque = Date.MinValue Then
                    ParesTerminados += Lote.PPares
                    LotesTerminados += 1
                End If





                Dim strFila As String = "" + ControlChars.Tab & Consecutivo &
     ControlChars.Tab & Lote.PFechaLote &
                                   ControlChars.Tab & Lote.PLote &
                                   ControlChars.Tab & Lote.PMarca &
                                   ControlChars.Tab & Lote.PModelo &
                                   ControlChars.Tab & Lote.PColeccion &
                                   ControlChars.Tab & Lote.PTalla &
                                   ControlChars.Tab & Lote.PColor &
                                   ControlChars.Tab & Lote.PPares '&
                ' ControlChars.Tab & diasAtrasados ' &
                ' ControlChars.Tab & Lote.PObservaciones

                TotalPares += Lote.PPares
                TotalLotes += 1

                Dim diasTotales As Int32 = 0
                Dim estaatrasado As Boolean = False
                For Each departamentoAvance As DepartamentosProduccion In Lote.PAvanceDepartamentos
                    If departamentoAvance.PFechaAvance = Date.MinValue Then
                        strFila += ControlChars.Tab & ""
                    Else
                        strFila += ControlChars.Tab & departamentoAvance.PFechaAvance.ToShortDateString
                    End If

                    diasTotales = departamentoAvance.PDias - 1
                    Dim fechaInicio As New Date
                    fechaInicio = Lote.PFechaLote
                    Dim FechaFin As New Date
                    FechaFin = Today

                    While fechaInicio < FechaFin.AddDays(1)
                        If fechaInicio.DayOfWeek = 6 Then
                            diasTotales += 1
                        End If
                        fechaInicio = fechaInicio.AddDays(1)
                    End While

                    diasAtrasados = DateDiff("d", Lote.PFechaLote.AddDays(diasTotales), Today)

                    If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                        '  strFila += ControlChars.Tab & diasAtrasados.ToString
                        If diasAtrasados > 0 Then
                            ParesAtrasados += Lote.PPares
                            LotesAtrasados += 1
                        End If
                        estaatrasado = True
                    Else
                        ' strFila += ControlChars.Tab & " "
                    End If
                    If departamentoAvance.PCelulas = Nothing Then
                        strFila += ControlChars.Tab & "NO ASIGNADA"
                    Else
                        strFila += ControlChars.Tab & departamentoAvance.PCelulas
                        For Each Celula As CelulasProduccion In ListaCelulas
                            If Celula.PNombreCelula = departamentoAvance.PCelulas Then

                                If Not departamentoAvance.PFechaAvance = Date.MinValue Then
                                    Celula.PCantidadTerminadasPares += Lote.PPares
                                    Celula.PCantidadTerminadasLotes += 1


                                End If

                            End If
                        Next
                    End If

                    '*****************************




                    Dim Existe As Boolean = False
                    Dim Contado As Boolean = False
                    If ListaCelulas.Count <= 0 Then
                        Dim nuevaCelula As New CelulasProduccion
                        nuevaCelula.PNombreCelula = departamentoAvance.PCelulas
                        nuevaCelula.PCantidadAcumuladaLotes = 0
                        nuevaCelula.PCantidadAcumuladaPares = 0
                        nuevaCelula.PIDCelula = departamentoAvance.PIDConfiguracion
                        ListaCelulas.Add(nuevaCelula)
                    End If

                    For Each celula As CelulasProduccion In ListaCelulas

                        If departamentoAvance.PCelulas = celula.PNombreCelula Then
                            Existe = True
                            If Existe = True Then
                                If Contado = False Then
                                    celula.PCantidadAcumuladaLotes += 1
                                    celula.PCantidadAcumuladaPares += Lote.PPares

                                    Contado = True
                                End If

                            Else

                            End If
                        End If


                    Next

                    If Existe = False Then
                        Dim nuevaCelula As New CelulasProduccion
                        nuevaCelula.PNombreCelula = departamentoAvance.PCelulas
                        nuevaCelula.PCantidadAcumuladaLotes += 1
                        nuevaCelula.PCantidadAcumuladaPares += Lote.PPares
                        nuevaCelula.PIDCelula = departamentoAvance.PIDConfiguracion
                        ListaCelulas.Add(nuevaCelula)
                    End If

                    '********************************************


                Next



                If cmbDepartamento.SelectedIndex = 0 Or cmbDepartamento.Text = "EMBARQUE" Then
                    If Not Lote.PFechaEmbarque = Date.MinValue Then
                        strFila += ControlChars.Tab & Lote.PFechaEmbarque.ToShortDateString
                        If cmbCelulas.SelectedIndex > 0 Then
                            If strFila.Contains(cmbCelulas.Text) Then

                            Else

                                grdAvances.RemoveItem()
                            End If
                        End If
                    Else
                        strFila += ControlChars.Tab & ""
                        If cmbCelulas.SelectedIndex > 0 Then
                            If strFila.Contains(cmbCelulas.Text) Then

                            Else

                                grdAvances.RemoveItem()
                            End If
                        End If
                    End If
                End If

                If rdoAtrasados.Checked = True Or rdoTerminados.Checked = True Then
                    If rdoAtrasados.Checked = True Then
                        If estaatrasado = True Then


                            ' paresAtrasadosFiltro += Lote.PPares
                            ' LotesAtrasadosFiltro += 1
                            grdAvances.AddItem(strFila)
                            If cmbCelulas.SelectedIndex > 0 Then
                                If strFila.Contains(cmbCelulas.Text) Then

                                Else

                                    grdAvances.RemoveItem()
                                End If
                            End If
                        End If
                    Else

                    End If

                    If rdoTerminados.Checked = True Then
                        If Not Lote.PFechaEmbarque <> Date.MinValue Then
                            grdAvances.AddItem(strFila)
                            If cmbCelulas.SelectedIndex > 0 Then
                                If strFila.Contains(cmbCelulas.Text) Then

                                Else

                                    grdAvances.RemoveItem()
                                End If
                            End If
                        End If
                    Else

                    End If
                Else
                    grdAvances.AddItem(strFila)
                    If cmbCelulas.SelectedIndex > 0 Then
                        If strFila.Contains(cmbCelulas.Text) Then

                        Else

                            grdAvances.RemoveItem()
                        End If
                    End If
                End If

                Consecutivo += 1
            End If



        Next




        'lblTotalParesPrograma.Text = TotalPares.ToString
        'lblTotalLotesProgramas.Text = TotalLotes.ToString
        ParesProceso = TotalPares - ParesTerminados
        'lblParesTerminados.Text = ParesTerminados
        'lblParesProceso.Text = ParesProceso.ToString
        ' lblLotesTerminados.Text = LotesTerminados.ToString
        LotesProceso = TotalLotes - LotesTerminados
        'lblLotesProceso.Text = LotesProceso.ToString
        'If paresAtrasadosFiltro > 0 Then
        '    lblParesAtrasados.Text = paresAtrasadosFiltro.ToString
        '    lblLotesAtrasados.Text = LotesAtrasadosFiltro.ToString
        'Else
        '    lblParesAtrasados.Text = ParesAtrasados
        '    lblLotesAtrasados.Text = LotesAtrasados
        'End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'If cmbDepartamento.Text = "EMBARQUE" Then
        '    grdInventarioDepartamento.Visible = False
        '    head.Visible = False
        '    head2.Visible = True
        '    grdInventarioNave.Visible = True
        '    lblinvdepartamento.Visible = False
        '    pnlDepartamento.Visible = False
        '    lblTotalInventario.Visible = False
        '    pnlNave.Visible = True
        '    lblInventarioNave.Visible = True
        '    lb_linvNave.Visible = True
        'Else
        '    head2.Visible = False
        '    head.Visible = True
        '    grdInventarioNave.Visible = False
        '    grdInventarioDepartamento.Visible = True
        '    lblinvdepartamento.Visible = True
        '    pnlDepartamento.Visible = True
        '    lblTotalInventario.Visible = True
        '    pnlNave.Visible = False
        '    lblInventarioNave.Visible = False
        '    lb_linvNave.Visible = False
        'End If
        'If txtDias.Text.Length <= 0 Then
        '    Dim Warning As New AdvertenciaForm
        '    Warning.mensaje = "Ingrese el numero de dias"
        '    Warning.ShowDialog()
        '    lblDias.ForeColor = Color.Red
        'Else
        lblDias.ForeColor = Color.Black

        grdAvances.Rows.Count = 1
        grdResumenesDepartamentos.Rows.Count = 1
        Dim objBu As New Global.Produccion.Negocios.DepartamentosSICYBU
        TotalPares = 0
        TotalLotes = 0
        ParesTerminados = 0
        LotesTerminados = 0
        ParesProceso = 0
        LotesProceso = 0
        ParesAtrasados = 0
        LotesAtrasados = 0
        'paresAtrasadosFiltro = 0
        'LotesAtrasadosFiltro = 0
        listaDeps = New List(Of DepartamentosProduccion)
        ListaCelulas = New List(Of CelulasProduccion)
        ListaCelulas = New List(Of CelulasProduccion)
        CargarCelulas()

        Departamentos = (objBu.ListaDepartamentosSegunNaveProduccion(cmbNave.SelectedValue))
        If cmbDepartamento.SelectedIndex > 0 Then
            For Each dep As DepartamentosProduccion In Departamentos
                Dim Departamento As New DepartamentosProduccion
                Departamento.PIDConfiguracion = dep.PIDConfiguracion
                Departamento.PNombre = dep.PNombre
                Departamento.PDias = dep.PDias

                If Departamento.PIDConfiguracion = cmbDepartamento.SelectedValue Then
                    listaDeps.Add(Departamento)
                End If
            Next
        Else
            listaDeps = New List(Of DepartamentosProduccion)
            For Each dep As DepartamentosProduccion In Departamentos
                Dim Departamento As New DepartamentosProduccion
                Departamento.PIDConfiguracion = dep.PIDConfiguracion
                Departamento.PNombre = dep.PNombre
                Departamento.PDias = dep.PDias
                listaDeps.Add(Departamento)
            Next
        End If

        Dim Dias As Double
        '  Dias = txtDias.Text
        Me.Cursor = Cursors.WaitCursor
        LlenarGrid()
        If cmbDepartamento.SelectedIndex > 0 Then
            GenerarResumenes()


            If cmbDepartamento.SelectedIndex = 0 Or cmbDepartamento.Text = "EMBARQUE" Then
                GenerarInventarioNave()
            Else
                GenerarInventarioDepartamento(Dias)
            End If

            For Each row As C1.Win.C1FlexGrid.Row In grdAvances.Rows
                Dim cc As C1.Win.C1FlexGrid.CellStyle
                cc = Me.grdAvances.Styles.Add("ColumnColor")
                ColorNave = "#85A3FF"
                If row.Index > 0 Then

                    Try
                        If grdAvances(row.Index, "CORTE").ToString.Length > 0 Then
                            Dim ColorCorteCol As C1.Win.C1FlexGrid.CellStyle
                            ColorCorteCol = Me.grdAvances.Styles.Add("ColumnColorCorte")
                            ColorCorteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
                            grdAvances.SetCellStyle(row.Index, grdAvances.Cols("CORTE").Index, ColorCorteCol)
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If grdAvances(row.Index, "PESPUNTE").ToString.Length > 0 Then
                            Dim ColorPespunteCol As C1.Win.C1FlexGrid.CellStyle
                            ColorPespunteCol = Me.grdAvances.Styles.Add("ColumnColorPespunte")
                            ColorPespunteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
                            grdAvances.SetCellStyle(row.Index, grdAvances.Cols("PESPUNTE").Index, ColorPespunteCol)
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If grdAvances(row.Index, "MONTADO Y ADORNO").ToString.Length > 0 Then
                            Dim ColorMontadoCol As C1.Win.C1FlexGrid.CellStyle
                            ColorMontadoCol = Me.grdAvances.Styles.Add("ColumnColorMontado")
                            ColorMontadoCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
                            grdAvances.SetCellStyle(row.Index, grdAvances.Cols("MONTADO Y ADORNO").Index, ColorMontadoCol)
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If grdAvances(row.Index, "EMBARQUE").ToString.Length > 0 Then
                            cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
                            grdAvances.SetCellStyle(row.Index, grdAvances.Cols("EMBARQUE").Index, cc)
                        End If
                    Catch ex As Exception

                    End Try


                    'If cmbDepartamento.Text = "CORTE" Then
                    '    grdAvances.Cols("Célula").Visible = False
                    '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
                    '    grdAvances.Cols("CORTE").Style = Me.grdAvances.Styles("ColumnColor")
                    '    Dim indice As New Int32
                    '    indice = grdAvances.Cols("CORTE").Index
                    '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")
                    'End If
                    'If cmbDepartamento.Text = "PESPUNTE" Then
                    '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
                    '    grdAvances.Cols("PESPUNTE").Style = Me.grdAvances.Styles("ColumnColor")
                    '    Dim indice As New Int32
                    '    indice = grdAvances.Cols("PESPUNTE").Index
                    '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")
                    'End If
                    'If cmbDepartamento.Text = "MONTADO Y ADORNO" Then
                    '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
                    '    grdAvances.Cols("MONTADO Y ADORNO").Style = Me.grdAvances.Styles("ColumnColor")
                    '    Dim indice As New Int32
                    '    indice = grdAvances.Cols("MONTADO Y ADORNO").Index
                    '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")
                    'End If
                    'If cmbDepartamento.Text = "EMBARQUE" Then
                    '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
                    '    grdAvances.Cols("EMBARQUE").Style = Me.grdAvances.Styles("ColumnColor")
                    'End If
                    'If cmbDepartamento.Text = Nothing Then
                    '    Dim ColorCorteCol As C1.Win.C1FlexGrid.CellStyle
                    '    ColorCorteCol = Me.grdAvances.Styles.Add("ColumnColorCorte")
                    '    ColorCorteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
                    '    Dim indice As New Int32
                    '    indice = grdAvances.Cols("CORTE").Index
                    '    grdAvances.Cols("CORTE").Style = Me.grdAvances.Styles("ColumnColorCorte")
                    '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorCorte")
                    '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorCorte")


                    '    Dim ColorPespunteCol As C1.Win.C1FlexGrid.CellStyle
                    '    ColorPespunteCol = Me.grdAvances.Styles.Add("ColumnColorPespunte")
                    '    ColorPespunteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
                    '    grdAvances.Cols("PESPUNTE").Style = Me.grdAvances.Styles("ColumnColorPespunte")
                    '    indice = grdAvances.Cols("PESPUNTE").Index
                    '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorPespunte")
                    '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorPespunte")


                    '    Dim ColorMontadoCol As C1.Win.C1FlexGrid.CellStyle
                    '    ColorMontadoCol = Me.grdAvances.Styles.Add("ColumnColorMontado")
                    '    ColorMontadoCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
                    '    grdAvances.Cols("MONTADO Y ADORNO").Style = Me.grdAvances.Styles("ColumnColorMontado")
                    '    indice = grdAvances.Cols("MONTADO Y ADORNO").Index
                    '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorMontado")
                    '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorMontado")


                    '    cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
                    '    grdAvances.Cols("EMBARQUE").Style = Me.grdAvances.Styles("ColumnColor")
                    '    indice = grdAvances.Cols("EMBARQUE").Index
                    '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColor")

                    'End If


                End If
            Next


        Else
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione un departamento"
            Advertencia.ShowDialog()

        End If
        Me.Cursor = Cursors.Default
        'End If
    End Sub

    Public Sub GenerarResumenes()
        Dim strFila As String = ""
        'grdResumenesDepartamentos.Cols.Count = 1
        'grdResumenesDepartamentos.Rows.Count = 1
        'Dim VaciarCelulasADepartamentos As New List(Of DepartamentosProduccion)

        'For Each Celulas As CelulasProduccion In ListaCelulas
        '    Dim Celula As New CelulasProduccion
        '    Celula = Celulas
        '    'grdResumenesDepartamentos.Cols.Count = grdAvances.Cols.Count + 1
        '    'grdResumenesDepartamentos.Cols(grdAvances.Cols.Count - 1).Caption = Celulas.PNombreCelula

        '    Dim NombreDepartamento As String = ""
        '    '**********************************************************************

        '    Dim VaciandoDepartamento As New DepartamentosProduccion

        '    Dim ListaCelulas As New List(Of CelulasProduccion)
        '    For Each depatamento As DepartamentosProduccion In listaDeps



        '        If depatamento.PIDConfiguracion = Celula.PIDCelula Then
        '            Dim AddCelula As New CelulasProduccion
        '            VaciandoDepartamento = depatamento
        '            AddCelula = Celula
        '            Try
        '                If VaciandoDepartamento.PCelulasLista.Count > 0 Then
        '                    ListaCelulas = VaciandoDepartamento.PCelulasLista

        '                End If
        '            Catch ex As Exception

        '            End Try


        '            ListaCelulas.Add(AddCelula)
        '            VaciandoDepartamento.PCelulasLista = ListaCelulas
        '            Dim Existe = False
        '            For Each depatament As DepartamentosProduccion In VaciarCelulasADepartamentos
        '                If depatament.PNombre = VaciandoDepartamento.PNombre Then
        '                    Existe = True
        '                End If
        '            Next
        '            If Existe = False Then
        '                VaciarCelulasADepartamentos.Add(VaciandoDepartamento)
        '            End If


        '        End If

        '    Next


        '    '****************************************



        'Next
        grdResumenesDepartamentos.Cols.Count = grdResumenesDepartamentos.Cols.Count + 1
        grdResumenesDepartamentos.Cols(1).Caption = "Descripcion"
        grdResumenesDepartamentos.Cols(2).Caption = "Lotes"
        grdResumenesDepartamentos.Cols(3).Caption = "Pares"
        Dim maxCelulas As Int32 = 0
        Dim i As Int32 = 0
        'For Each depatamento As DepartamentosProduccion In VaciarCelulasADepartamentos
        '    i += 1
        '    If i = 1 Then
        '        maxCelulas = depatamento.PCelulasLista.Count
        '    Else
        '        If depatamento.PCelulasLista.Count > maxCelulas Then
        '            maxCelulas = depatamento.PCelulasLista.Count
        '        End If
        '    End If
        'Next

        'grdResumenesDepartamentos.Cols.Count = grdResumenesDepartamentos.Cols.Count + (maxCelulas * 6)
        Dim TotalLotesResumen, TotalParesResumen As New Int32
        'For Each depatamento As DepartamentosProduccion In VaciarCelulasADepartamentos
        '    ' & depatamento.PNombre

        For Each Celulas As CelulasProduccion In ListaCelulas
            strFila = "" ' & ControlChars.Tab

            'If Celulas.PNombreCelula = Nothing Then
            '    Celulas.PNombreCelula = "Total Terminados"
            'End If

            strFila += ControlChars.Tab & Celulas.PNombreCelula &
                    ControlChars.Tab & Celulas.PCantidadAcumuladaLotes.ToString("##,00") &
                    ControlChars.Tab & Celulas.PCantidadAcumuladaPares.ToString("##,00") &
                    ControlChars.Tab
            TotalLotesResumen += Celulas.PCantidadAcumuladaLotes
            TotalParesResumen += Celulas.PCantidadAcumuladaPares
            If Celulas.PCantidadTerminadasLotes > 0 Or Celulas.PCantidadTerminadasPares > 0 Then
                grdResumenesDepartamentos.AddItem(strFila)
            End If

        Next

        'Next
        strFila = "" ' & ControlChars.Tab
        If TotalLotesResumen <= 0 Then
            strFila += ControlChars.Tab & "TOTAL" &
              ControlChars.Tab & TotalLotes.ToString("##,00") &
              ControlChars.Tab & TotalPares.ToString("##,00") &
              ControlChars.Tab
        Else


            strFila += ControlChars.Tab & "TOTAL" &
               ControlChars.Tab & TotalLotesResumen.ToString("##,00") &
               ControlChars.Tab & TotalParesResumen.ToString("##,00") &
               ControlChars.Tab
        End If


        grdResumenesDepartamentos.AddItem(strFila)
    End Sub

    Public Sub GenerarInventarioDepartamento(ByVal Dias As Double)
        grdInventarioDepartamento.Rows.Count = 1
        Dim ObjBu As New LotesAvancesBU
        Dim ListaInventario As New List(Of InventarioProduccion)
        Dim DiasDepartamento As Int32
        Dim Departamentos As New List(Of DepartamentosProduccion)
        Dim ObjBUDEP As New DepartamentosSICYBU
        Dim totalParesProgramados, totalParesTerminados As Integer
        Departamentos = (ObjBUDEP.ListaDepartamentosSegunNaveProduccion(cmbNave.SelectedValue))
        If cmbDepartamento.SelectedIndex > 0 Then
            For Each dep As DepartamentosProduccion In Departamentos
                Dim Departamento As New DepartamentosProduccion
                Departamento = dep
                If Departamento.PIDConfiguracion = cmbDepartamento.SelectedValue Then
                    DiasDepartamento = 6
                End If
            Next
        End If
        Dim fechaInicio As New Date
        fechaInicio = dtpFechaInicio.Value
        'Dim FechaFin As New Date
        'fechaInicio = dtpFechaInicio.Value.AddDays(DiasDepartamento * (-1))
        'DiasDepartamento = DiasDepartamento - 1
        DiasDepartamento = 6
        Dim contador As Integer = 0
        While contador < DiasDepartamento
            fechaInicio = fechaInicio.AddDays(-1)
            If fechaInicio.DayOfWeek = 6 Then
                fechaInicio = fechaInicio.AddDays(-1)
            End If
            contador += 1
        End While

        Dim fechaFin As New Date
        fechaFin = dtpFechaFinal.Value
        'Dim FechaFin As New Date
        'fechaInicio = dtpFechaInicio.Value.AddDays(DiasDepartamento * (-1))
        Dim contadorfinal As Integer = 0
        While contadorfinal < DiasDepartamento
            fechaFin = fechaFin.AddDays(-1)
            If fechaInicio.DayOfWeek = 6 Then
                fechaFin = fechaFin.AddDays(-1)
            End If
            contadorfinal += 1
        End While




        'ListaInventario = ObjBu.InventarioLotesAvances(cmbNave.SelectedValue, cmbDepartamento.SelectedValue, fechaInicio, fechaFin)
        ListaInventario = ObjBu.InventarioLotesAvances(cmbNave.SelectedValue, cmbDepartamento.SelectedValue, dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString)
        Dim TotalLotesTerminados, TotalLotesProgramados As New Int32
        Dim DiasDividir As New Double
        Dim InsertoFechaInicial As Boolean = False
        Dim comenzarinsertar As Boolean = False


        For Each inventario As InventarioProduccion In ListaInventario

            If inventario.PParesProg = inventario.PParesTerminados Then
            Else
                comenzarinsertar = True
            End If
            If inventario.PParesProg = 0 Then

            Else

                If comenzarinsertar = True Then
                    Dim strFila As String = ""
                    Dim TotalLotesResumen, TotalParesResumen As New Int32
                    TotalLotesResumen = inventario.PLotesProg - inventario.PLotesTerminados
                    TotalParesResumen = inventario.PParesProg - inventario.PParesTerminados
                    strFila = "" ' & ControlChars.Tab

                    strFila += ControlChars.Tab & inventario.PFecha &
                                                           ControlChars.Tab & inventario.PLotesProg &
                                                           ControlChars.Tab & inventario.PParesProg &
                                                           ControlChars.Tab & inventario.PLotesTerminados &
                                                           ControlChars.Tab & inventario.PParesTerminados &
                                                           ControlChars.Tab & TotalLotesResumen &
                                                           ControlChars.Tab & TotalParesResumen &
                                                           ControlChars.Tab


                    If inventario.PFecha.DayOfWeek = 7 Then
                        DiasDividir += 0
                    End If
                    If inventario.PFecha.DayOfWeek = 6 Then
                        DiasDividir += 0.5
                    End If

                    If inventario.PFecha.DayOfWeek < 6 Then
                        DiasDividir += 1
                    End If




                    grdInventarioDepartamento.AddItem(strFila)
                    TotalLotesProgramados += inventario.PLotesProg
                    TotalLotesTerminados += inventario.PLotesTerminados
                    totalParesProgramados += inventario.PParesProg
                    totalParesTerminados = totalParesTerminados + inventario.PParesTerminados
                End If

            End If

        Next

        '---------------------



        Dim strFilas As String = ""
        strFilas += ControlChars.Tab & "Totales" &
                    ControlChars.Tab & TotalLotesProgramados &
                    ControlChars.Tab & totalParesProgramados &
                    ControlChars.Tab & TotalLotesTerminados &
                    ControlChars.Tab & totalParesTerminados &
                    ControlChars.Tab & (TotalLotesProgramados - TotalLotesTerminados) &
                    ControlChars.Tab & (totalParesProgramados - totalParesTerminados) &
                    ControlChars.Tab
        grdInventarioDepartamento.AddItem(strFilas)
        Dim paresProceso As Int32
        paresProceso = totalParesProgramados - totalParesTerminados
        Dim inventarioFinal As Double
        inventarioFinal = (paresProceso / (totalParesProgramados / DiasDividir))
        txtDias.Text = DiasDividir.ToString
        lblTotalInventario.Text = FormatNumber(inventarioFinal.ToString, 2) + " Días"
    End Sub

    Private Sub btnExpCod_Click(sender As Object, e As EventArgs) Handles btnExpCod.Click
        ExportarGridAExcel()
    End Sub

    Private Sub ExportarGridAExcel()

        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                'Aqui va el procesos de exportar a excel el grid
                grdAvances.SaveExcel(fileName, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells)
                Process.Start(fileName)
            Catch ex As Exception
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Public Sub GenerarInventarioNave()
        grdInventarioNave.Rows.Count = 1
        Dim ObjBu As New LotesAvancesBU
        Dim ListaInventario As New List(Of InventarioProduccion)

        Dim Departamentos As New List(Of DepartamentosProduccion)
        Dim ObjBUDEP As New DepartamentosSICYBU
        Dim totalParesProgramados, totalParesTerminados As Integer





        'ListaInventario = ObjBu.InventarioLotesAvances(cmbNave.SelectedValue, cmbDepartamento.SelectedValue, fechaInicio, fechaFin)
        ListaInventario = ObjBu.InventarioNaves(cmbNave.SelectedValue, dtpFechaInicio.Value, dtpFechaFinal.Value)
        Dim TotalLotesTerminados, TotalLotesProgramados As New Int32
        Dim DiasDividir As New Double
        Dim InsertoFechaInicial As Boolean = False
        Dim comenzarinsertar As Boolean = False


        For Each inventario As InventarioProduccion In ListaInventario
            Dim paresTerminados As Int32
            paresTerminados = inventario.PParesProg - inventario.PParesTerminados
            If inventario.PParesProg = paresTerminados Then
            Else
                comenzarinsertar = True
            End If
            If inventario.PParesProg = 0 Then
            Else



                If comenzarinsertar = True Then
                    Dim strFila As String = ""

                    paresTerminados = inventario.PParesProg - inventario.PParesTerminados
                    Dim LotesTerminados As Int32
                    LotesTerminados = inventario.PLotesProg - inventario.PLotesTerminados
                    strFila = "" ' & ControlChars.Tab

                    strFila += ControlChars.Tab & inventario.PFecha &
                                            ControlChars.Tab & inventario.PLotesProg &
                                            ControlChars.Tab & inventario.PParesProg &
                                            ControlChars.Tab & LotesTerminados &
                                            ControlChars.Tab & paresTerminados &
                                            ControlChars.Tab & inventario.PLotesTerminados &
                                            ControlChars.Tab & inventario.PParesTerminados &
                                            ControlChars.Tab


                    If inventario.PFecha.DayOfWeek = 7 Then
                        DiasDividir += 0
                    End If
                    If inventario.PFecha.DayOfWeek = 6 Then
                        DiasDividir += 0.5
                    End If

                    If inventario.PFecha.DayOfWeek < 6 Then
                        DiasDividir += 1
                    End If




                    grdInventarioNave.AddItem(strFila)
                    TotalLotesProgramados += inventario.PLotesProg
                    TotalLotesTerminados += LotesTerminados
                    totalParesProgramados += inventario.PParesProg
                    totalParesTerminados = totalParesTerminados + paresTerminados
                End If

            End If
        Next

        '---------------------




        Dim strFilas As String = ""
        strFilas += ControlChars.Tab & "Totales" &
                    ControlChars.Tab & TotalLotesProgramados &
                    ControlChars.Tab & totalParesProgramados &
                    ControlChars.Tab & TotalLotesTerminados &
                    ControlChars.Tab & totalParesTerminados &
                    ControlChars.Tab & (TotalLotesProgramados - TotalLotesTerminados) &
                    ControlChars.Tab & (totalParesProgramados - totalParesTerminados) &
                    ControlChars.Tab
        grdInventarioNave.AddItem(strFilas)
        Dim paresProceso As Int32
        paresProceso = totalParesProgramados - totalParesTerminados
        Dim inventarioFinal As Double
        inventarioFinal = (paresProceso / (totalParesProgramados / DiasDividir))
        txtDias.Text = DiasDividir.ToString
        lblInventarioNave.Text = FormatNumber(inventarioFinal.ToString, 2) + " Días"
    End Sub





    Private Sub txtDias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDias.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub grdResumenesDepartamentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdResumenesDepartamentos.Click

    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        Try
            If cmbDepartamento.SelectedIndex > 0 Then
                cmbCelulas = Controles.ComboCelulasSegunDepartamentoProduccion(cmbCelulas, cmbNave.SelectedValue, cmbDepartamento.SelectedValue)
                CargarCelulas()
            End If

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub


    Public Sub CargarCelulas()
        Try
            Dim tablaCelulas As New List(Of Celulas)
            Dim objCelulasBU As New DepartamentosSICYBU

            Dim objNaveSicy As New Naves
            objNaveSicy = objCelulasBU.listaNave(cmbNave.SelectedValue)

            tablaCelulas = objCelulasBU.ListaCelulasSegunNaveDepto(objNaveSicy.PNaveSICYid, cmbDepartamento.SelectedValue)


            Dim Noasignada As New Celulas
            Noasignada.PNombre = "NO ASIGNADA"

            tablaCelulas.Insert(tablaCelulas.Count, Noasignada)
            For Each Celula As Celulas In tablaCelulas
                Dim InsertarCelulas As New CelulasProduccion
                InsertarCelulas.PNombreCelula = Celula.PNombre
                InsertarCelulas.PIDCelula = Celula.PCelulaid
                ListaCelulas.Add(InsertarCelulas)
            Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Height = 100
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub
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
            mensajeExito.ShowDialog()
        End If
    End Sub

End Class