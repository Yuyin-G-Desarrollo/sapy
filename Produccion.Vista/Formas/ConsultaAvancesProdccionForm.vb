Imports System.Globalization
Imports Entidades
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Tools

Public Class ConsultaAvancesProdccionForm
    'declaraciones
    Dim objUsuarioSesion As Usuarios
    Dim listaDeps As New List(Of DepartamentosProduccion)
    Dim Departamentos As New List(Of DepartamentosProduccion)
    Dim tmpDepartamentos As New List(Of DepartamentosProduccion)
    Dim inventario As New List(Of InventarioProduccion)
    Dim listaDiasAtrasados As New List(Of DiasAtrasadosDep)
    Dim LotesTerminado, ParesTerminado As New Int32
    Dim ListaCelulas As New List(Of CelulasProduccion)
    Dim LotesAtrasadosDepartamento, ParesAtrasadosDepartameto As Int32
    Dim LotesDepartamentoProceso, ParesDepartamentoProceso, ParesTerminadosDepartamento, LotesTerminadosDepartamento As New Int32
    Dim TotalPares, TotalLotes, ParesTerminados, LotesTerminados, ParesProceso, LotesProceso, ParesAtrasados, LotesAtrasados, paresAtrasadosFiltro, LotesAtrasadosFiltro As Int32
    Dim ColorCorte, ColorMontado, ColorPespunte, ColorNave As String
    Dim AtrasadoCorte, AtrasadoPespunte, AtrasadoMontado, AtrasadoEmbarque As Boolean
    Dim detallado As Boolean = False
    Private Sub ConsultaAvancesProdccionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdAvances.AutoClipboard = True
        grdResumenesDepartamentos.AutoClipboard = True
        grdInventarioDepartamento.AutoClipboard = True
        grdResumenesNave.AutoClipboard = True
        WindowState = FormWindowState.Maximized
        Inicializar()
        Llenar()
        CheckForIllegalCrossThreadCalls = False
    End Sub


    Public Sub Inicializar()
        objUsuarioSesion = SesionUsuario.UsuarioSesion
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, objUsuarioSesion.PUserUsuarioid)
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CONS_AVA_PROD", "REGISTRAR_MOTIVOS_ATRASO") Then
            pnlRegistrarAtraso.Visible = True
        Else
            pnlRegistrarAtraso.Visible = False
        End If
    End Sub

    Public Sub Llenar()

    End Sub


    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        'cambio y eleccion departamentos
        If cmbNave.SelectedIndex > 0 Then
            cmbDepartamento = Controles.ComboDepartamentosSegunNaveProduccion(cmbDepartamento, cmbNave.SelectedValue)
        End If

    End Sub

    Public Sub LlenarGrid()

        Dim ListaAvancesProduccion As New List(Of LotesAvances)
        Dim objBu3 As New Global.Produccion.Negocios.DepartamentosSICYBU
        tmpDepartamentos = (objBu3.ListaDepartamentosSegunNaveProduccion(cmbNave.SelectedValue))
        Dim objBU As New LotesAvancesBU
        Dim objBU2 As New LotesAvancesBU
        Dim diasAtrasados As New Double
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

                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = dep.PNombre
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = dep.PNombre
                    grdAvances.Cols(grdAvances.Cols.Count - 1).StyleDisplay.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días atraso"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "DiasAtraso" + dep.PNombre
                    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Célula"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Célula"
                    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                    If dep.PNombre.Equals("CORTE") Then
                        grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Motivo C"
                        grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Motivo C"
                    End If
                    If dep.PNombre.Equals("PESPUNTE") Then
                        grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Motivo P"
                        grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Motivo P"
                    End If
                    If dep.PNombre.Equals("MONTADO Y ADORNO") Then
                        grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Motivo MA"
                        grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Motivo MA"
                    End If


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
                Dim DepartamentoNombre As String = dep.PNombre.ToLower
                grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DepartamentoNombre)
                grdAvances.Cols(grdAvances.Cols.Count - 1).Name = dep.PNombre
                grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días atraso"
                grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "DiasAtraso" + dep.PNombre
                grdAvances.Cols(grdAvances.Cols.Count - 1).StyleDisplay.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Célula"
                grdAvances.Cols.Count = grdAvances.Cols.Count + 1
                If dep.PNombre.Equals("CORTE") Then
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Motivo C"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Motivo C"
                End If
                If dep.PNombre.Equals("PESPUNTE") Then
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Motivo P"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Motivo P"
                End If
                If dep.PNombre.Equals("MONTADO Y ADORNO") Then
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Motivo MA"
                    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Motivo MA"
                End If

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

        Dim ContarLotesAtrasadosEmbarque As New Boolean
        ContarLotesAtrasadosEmbarque = False

        'If cmbDepartamento.SelectedIndex = 0 Then
        '    grdAvances.Cols.Count = grdAvances.Cols.Count + 1
        '    grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Producto terminado"
        '    grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "ProductoTerminado"
        'End If

        If cmbDepartamento.SelectedIndex = 0 Or cmbDepartamento.Text = "EMBARQUE" Then

            grdAvances.Cols.Count = grdAvances.Cols.Count + 1
            grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Embarque"
            grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "EMBARQUE"
            ContarLotesAtrasadosEmbarque = True
            grdAvances.Cols.Count = grdAvances.Cols.Count + 1
            grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días atraso"
            grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "DiasAtrasoEMBARQUE"
            ColorNave = "#85A3FF"

        End If
        grdAvances.Cols.Count = grdAvances.Cols.Count + 1
        grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Cliente"
        grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Cliente"
        grdAvances.Cols(grdAvances.Cols.Count - 1).Width = 560
        grdAvances.Cols.Count = grdAvances.Cols.Count + 1
        grdAvances.Cols(grdAvances.Cols.Count - 1).Caption = "Días de Proceso"
        grdAvances.Cols(grdAvances.Cols.Count - 1).Name = "Días de Proceso"


        'grdAvances.Cols(grdAvances.Cols.Count - 1).StyleDisplay.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter

        ListaAvancesProduccion = objBU.ListaAvancesProduccion(dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString, Naveid, listaDeps)
        Dim fechaInicio As New Date
        Dim fechaFin As New Date
        Dim diasDeProceso As Double = 0.0
        For Each Lote As LotesAvances In ListaAvancesProduccion

            fechaInicio = Lote.PFechaLote
            If Not Lote.PFechaEmbarque = Date.MinValue Then
                fechaFin = Lote.PFechaEmbarque.ToShortDateString
            Else
                fechaFin = DateTime.Now.ToString("dd/MM/yyyy")
            End If
            diasDeProceso = getDiasdeProceso(fechaInicio, fechaFin)

            Dim Departamentos As Boolean = False

            If Not Lote.PFechaEmbarque = Date.MinValue Then
                ParesTerminados += Lote.PPares
                LotesTerminados += 1
            Else

            End If



            Dim strFila As String = ControlChars.Tab & Lote.PFechaLote &
                               ControlChars.Tab & Lote.PLote &
                               ControlChars.Tab & Lote.PModelo &
                               ControlChars.Tab & Lote.PColeccion &
                               ControlChars.Tab & Lote.PTalla &
                               ControlChars.Tab & Lote.PColor &
                               ControlChars.Tab & Lote.PPares &
                               ControlChars.Tab & diasAtrasados '& 
            'ControlChars.Tab & Lote.PObservaciones

            TotalPares += Lote.PPares
            TotalLotes += 1

            Dim diasTotales As Double = 0
            Dim estaatrasado As Boolean = False
            Dim estaProceso As Boolean = False
            Dim contadorDepartamentos As Integer

            For Each departamentoAvance As DepartamentosProduccion In Lote.PAvanceDepartamentos
                Dim dD As New DiasAtrasadosDep 'Objeto para guardar el motivo y departamento y dias a trasados para despues generar el resumen de los motivos
                Dim Existe As Boolean = False
                Dim depTotales As New DepartamentosProduccion
                Dim IDDEpartamento As Int32
                IDDEpartamento = departamentoAvance.PIDConfiguracion
                'MsgBox(departamentoAvance.PIDConfiguracion)
                depTotales = departamentoAvance
                contadorDepartamentos += 1
                If depTotales.PFechaAvance = Date.MinValue Or (contadorDepartamentos = 3 And Lote.PFechaEmbarque = Date.MinValue) Then
                    If contadorDepartamentos = 3 And depTotales.PFechaAvance <> Date.MinValue Then
                        strFila += ControlChars.Tab & depTotales.PFechaAvance.ToShortDateString
                    Else
                        strFila += ControlChars.Tab & ""
                    End If

                    estaProceso = True

                    If inventario.Count = 0 Then
                        Dim AgregarDatosDepartamentos As New InventarioProduccion
                        AgregarDatosDepartamentos.PParesProg = 0
                        AgregarDatosDepartamentos.PLotesProg += 0
                        AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        inventario.Add(AgregarDatosDepartamentos)

                    End If

                    For Each recorrerinventario As InventarioProduccion In inventario
                        If recorrerinventario.PIDDepartamento = IDDEpartamento Then
                            Existe = True
                            If Existe = True Then

                                recorrerinventario.PParesProg += Lote.PPares
                                recorrerinventario.PLotesProg += 1
                            End If
                        End If
                    Next
                    If Existe = False Then
                        Dim AgregarDatosDepartamentos As New InventarioProduccion
                        AgregarDatosDepartamentos.PParesProg += Lote.PPares
                        AgregarDatosDepartamentos.PLotesProg += 1
                        AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        inventario.Add(AgregarDatosDepartamentos)
                    End If


                Else
                    strFila += ControlChars.Tab & depTotales.PFechaAvance.ToShortDateString 'Manipular esta fecha para saber los dias de proceso del lote
                    Departamentos = True
                    Dim AgregarDatosDepartamentos As New InventarioProduccion
                    If inventario.Count = 0 Then
                        AgregarDatosDepartamentos.PParesTerminados = Lote.PPares
                        AgregarDatosDepartamentos.PLotesTerminados += 1
                        AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        inventario.Add(AgregarDatosDepartamentos)
                    End If

                    For Each recorrerinventario As InventarioProduccion In inventario
                        If recorrerinventario.PIDDepartamento = IDDEpartamento Then
                            Existe = True
                            If Existe = True Then
                                AgregarDatosDepartamentos.PParesTerminados = Lote.PPares
                                AgregarDatosDepartamentos.PLotesTerminados += 1
                            End If
                        End If
                    Next
                    If Existe = False Then
                        AgregarDatosDepartamentos.PParesTerminados += Lote.PPares
                        AgregarDatosDepartamentos.PLotesTerminados += 1
                        AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        inventario.Add(AgregarDatosDepartamentos)
                    End If
                End If
                'If Lote.PLote = 11525 Then
                '    Dim asd As String
                '    asd = ""
                'End If
                Dim depar As String = " "
                If departamentoAvance.PNombre = "CORTE" Then
                    depar = "COR"
                End If
                If departamentoAvance.PNombre = "PESPUNTE" Then
                    depar = "PES"
                End If
                If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                    depar = "MONTD"
                End If
                If departamentoAvance.PNombre = "EMBARQUE" Then
                    depar = "EMB"
                End If

                Dim data As DataTable = objBU2.getdiasAtrasosDepartamento(Lote.PLote, cmbNave.SelectedValue, Year(Lote.PFechaLote), depar)

                For Each row As DataRow In data.Rows
                    diasAtrasados = Convert.ToDouble(row("dias").ToString)
                Next

                If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                    strFila += ControlChars.Tab & diasAtrasados.ToString & " "

                    If diasAtrasados > 0 Then
                        ParesAtrasados += Lote.PPares
                        LotesAtrasados += 1
                        'departamentoAvance.PLotesAtrados += 1
                        'departamentoAvance.PparesAtrasados += Lote.PPares
                        'LotesAtrasadosDepartamento += 1
                        'ParesAtrasadosDepartameto += Lote.PPares
                        If departamentoAvance.PNombre = "CORTE" Then 'Contar dias de corte aqui
                            If diasAtrasados > 0 Then
                                dD.diasAtrasados = Lote.PPares
                                dD.departamento = departamentoAvance.PNombre
                            End If

                            For Each dep As DepartamentosProduccion In tmpDepartamentos
                                If dep.PNombre = "CORTE" Then
                                    dep.PLotesAtrados += 1
                                    dep.PparesAtrasados += Lote.PPares
                                End If
                            Next
                            AtrasadoCorte = True
                        End If
                        If departamentoAvance.PNombre = "PESPUNTE" Then 'Contar dias de pespunte aqui
                            If diasAtrasados > 0 Then
                                dD.diasAtrasados = Lote.PPares
                                dD.departamento = departamentoAvance.PNombre
                            End If
                            For Each dep As DepartamentosProduccion In tmpDepartamentos
                                If dep.PNombre = "PESPUNTE" Then
                                    dep.PLotesAtrados += 1
                                    dep.PparesAtrasados += Lote.PPares
                                End If
                            Next
                            AtrasadoPespunte = True
                        End If
                        If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then 'Contar dias de montado y adorno aqui
                            If diasAtrasados > 0 Then
                                dD.diasAtrasados = Lote.PPares
                                dD.departamento = departamentoAvance.PNombre
                            End If
                            For Each dep As DepartamentosProduccion In tmpDepartamentos
                                If dep.PNombre = "MONTADO Y ADORNO" Then
                                    dep.PLotesAtrados += 1
                                    dep.PparesAtrasados += Lote.PPares
                                End If
                            Next
                            AtrasadoMontado = True
                        End If
                        If departamentoAvance.PNombre = "EMBARQUE" Then
                            AtrasadoEmbarque = True
                        End If
                    Else

                    End If
                    estaatrasado = True
                Else

                    If departamentoAvance.PNombre = "CORTE" Then 'Contar dias de corte aqui
                        If Lote.PDiasAtrasados1 > 0 Then
                            dD.diasAtrasados = Lote.PPares
                            dD.departamento = departamentoAvance.PNombre
                        End If

                        For Each dep As DepartamentosProduccion In tmpDepartamentos
                            If dep.PNombre = "CORTE" Then
                                If Lote.PDiasAtrasados1 = 0 Then
                                    strFila += ControlChars.Tab & ""
                                Else
                                    strFila += ControlChars.Tab & Lote.PDiasAtrasados1
                                End If
                            End If
                        Next
                        AtrasadoCorte = True
                    End If
                    If departamentoAvance.PNombre = "PESPUNTE" Then 'Contar dias de pespunte aqui
                        If Lote.PDiasAtrasados2 > 0 Then
                            dD.diasAtrasados = Lote.PPares
                            dD.departamento = departamentoAvance.PNombre
                        End If
                        For Each dep As DepartamentosProduccion In tmpDepartamentos
                            If dep.PNombre = "PESPUNTE" Then
                                If Lote.PDiasAtrasados2 = 0 Then
                                    strFila += ControlChars.Tab & ""
                                Else
                                    strFila += ControlChars.Tab & Lote.PDiasAtrasados2
                                End If
                            End If
                        Next
                        AtrasadoPespunte = True
                    End If
                    If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then 'Contar dias de montado y adorno aqui
                        If Lote.PDiasAtrasados3 > 0 Then
                            dD.diasAtrasados = Lote.PPares
                            dD.departamento = departamentoAvance.PNombre
                        End If
                        For Each dep As DepartamentosProduccion In tmpDepartamentos
                            If dep.PNombre = "MONTADO Y ADORNO" Then
                                If Lote.PDiasAtrasados3 = 0 Then
                                    strFila += ControlChars.Tab & ""
                                Else
                                    strFila += ControlChars.Tab & Lote.PDiasAtrasados3
                                End If
                            End If
                        Next
                        AtrasadoMontado = True
                    End If
                End If
                'guardar motivo de atraso
                If departamentoAvance.PNombre = "CORTE" Then
                    If Lote.pmotivoDepartamento1 <> Nothing Then
                        dD.motivoAtraso = Lote.pmotivoDepartamento1
                    End If
                End If
                If departamentoAvance.PNombre = "PESPUNTE" Then
                    If Lote.pmotivoDepartamento2 <> Nothing Then
                        dD.motivoAtraso = Lote.pmotivoDepartamento2
                    End If
                End If
                If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                    If Lote.pmotivoDepartamento3 <> Nothing Then
                        dD.motivoAtraso = Lote.pmotivoDepartamento3
                    End If
                End If


                If departamentoAvance.PCelulas = Nothing Then
                    strFila += ControlChars.Tab & "NO ASIGNADA"
                    If chkMotivoAtraso.Checked Then
                        If departamentoAvance.PNombre = "CORTE" Then
                            strFila += ControlChars.Tab & Lote.pmotivoDepartamento1

                        End If
                        If departamentoAvance.PNombre = "PESPUNTE" Then
                            strFila += ControlChars.Tab & Lote.pmotivoDepartamento2

                        End If
                        If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                            strFila += ControlChars.Tab & Lote.pmotivoDepartamento3

                        End If
                    Else
                        strFila += ControlChars.Tab & " "
                    End If

                    For Each Celula As CelulasProduccion In ListaCelulas
                        If Celula.PNombreCelula = "NO ASIGNADA" Then

                            If Not departamentoAvance.PFechaAvance = Date.MinValue Then
                                Celula.PCantidadTerminadasPares += Lote.PPares
                                Celula.PCantidadTerminadasLotes += 1
                            Else
                                Celula.PCantidadAcumuladaLotes += 1
                                Celula.PCantidadAcumuladaPares += Lote.PPares
                            End If

                            If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                                If diasAtrasados > 0 Then
                                    Celula.PCantidadAtrasadasPares += Lote.PPares
                                    Celula.PCantidadAtrasadasLotes += 1
                                End If
                            End If

                        End If

                    Next
                Else
                    strFila += ControlChars.Tab & departamentoAvance.PCelulas
                    If chkMotivoAtraso.Checked Then
                        If departamentoAvance.PNombre = "CORTE" Then
                            strFila += ControlChars.Tab & Lote.pmotivoDepartamento1

                        End If
                        If departamentoAvance.PNombre = "PESPUNTE" Then
                            strFila += ControlChars.Tab & Lote.pmotivoDepartamento2

                        End If
                        If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                            strFila += ControlChars.Tab & Lote.pmotivoDepartamento3

                        End If
                    Else
                        strFila += ControlChars.Tab & " "
                    End If
                    For Each Celula As CelulasProduccion In ListaCelulas
                        If Celula.PNombreCelula = departamentoAvance.PCelulas Then

                            If Not departamentoAvance.PFechaAvance = Date.MinValue Then
                                Celula.PCantidadTerminadasPares += Lote.PPares
                                Celula.PCantidadTerminadasLotes += 1

                            Else
                                Celula.PCantidadAcumuladaLotes += 1
                                Celula.PCantidadAcumuladaPares += Lote.PPares
                            End If

                            If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                                If diasAtrasados > 0 Then
                                    Celula.PCantidadAtrasadasPares += Lote.PPares
                                    Celula.PCantidadAtrasadasLotes += 1
                                End If
                            End If

                        End If

                    Next

                End If
                If dD.diasAtrasados > 0 Then
                    listaDiasAtrasados.Add(dD)
                End If
            Next
            contadorDepartamentos = 0
            '********************************************
            'If cmbDepartamento.SelectedValue = 0 Then
            '    strFila += ControlChars.Tab & Lote.PProductoTerminado.ToShortDateString
            'End If
            If cmbDepartamento.SelectedValue = 0 Or cmbDepartamento.Text = "EMBARQUE" Then
                If Not Lote.PFechaEmbarque = Date.MinValue Then
                    strFila += ControlChars.Tab & Lote.PFechaEmbarque.ToShortDateString 'Manipular fecha para mostrar los dias de proceso actual
                    strFila += ControlChars.Tab & ""

                Else
                    'diasTotales = 4
                    'Dim fechaInicio As New Date
                    'fechaInicio = Lote.PFechaLote
                    'Dim FechaFin As New Date
                    'FechaFin = Today



                    'While fechaInicio < FechaFin.AddDays(1)
                    '    If fechaInicio.DayOfWeek = 6 Then
                    '        diasTotales += 1
                    '    End If
                    '    fechaInicio = fechaInicio.AddDays(1)
                    'End While
                    'diasAtrasados = DateDiff("d", Lote.PFechaLote.AddDays(diasTotales), Today)
                    Dim depar As String = "EMB"

                    Dim data As DataTable = objBU2.getdiasAtrasosDepartamento(Lote.PLote, cmbNave.SelectedValue, Year(Lote.PFechaLote), depar)
                    For Each row As DataRow In data.Rows
                        diasAtrasados = Convert.ToDouble(row("dias").ToString)
                    Next

                    If diasAtrasados > 0 Then
                        LotesAtrasados += 1
                        ParesAtrasados += Lote.PPares
                    End If
                    If diasAtrasados > 0 Then
                        strFila += ControlChars.Tab & "" + ControlChars.Tab & diasAtrasados
                        estaatrasado = True
                    Else
                        strFila += ControlChars.Tab & "" + ControlChars.Tab & ""
                    End If

                End If
            End If

            If rdoAtrasados.Checked = True Or rdoTerminados.Checked = True Then

                If rdoAtrasados.Checked = True Then
                    If estaatrasado = True Then
                        paresAtrasadosFiltro += Lote.PPares
                        'LotesAtrasadosFiltro += 1
                        strFila += ControlChars.Tab & Lote.pclienteTexto
                        strFila += ControlChars.Tab & diasDeProceso
                        strFila = "" + ControlChars.Tab & Consecutivo & strFila
                        grdAvances.AddItem(strFila)
                        Consecutivo += 1
                    End If
                Else
                    If diasAtrasados > 0 Then
                        'LotesAtrasadosFiltro += 1
                    End If
                End If
                If rdoTerminados.Checked = True Then

                    If cmbDepartamento.SelectedValue > 0 Then
                        If Departamentos = True Then
                            strFila += ControlChars.Tab & Lote.pclienteTexto
                            strFila += ControlChars.Tab & diasDeProceso
                            strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvances.AddItem(strFila)
                            Consecutivo += 1
                        End If
                    Else
                        If Lote.PFechaEmbarque <> Date.MinValue Then
                            strFila += ControlChars.Tab & Lote.pclienteTexto
                            strFila += ControlChars.Tab & diasDeProceso
                            strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvances.AddItem(strFila)
                            Consecutivo += 1
                        End If
                    End If
                Else

                End If
            Else

                If rdoProcesos.Checked = True Then

                    If estaProceso = True Then
                        If cmbDepartamento.SelectedValue > 0 Then
                            If Departamentos = False Then
                                strFila += ControlChars.Tab & Lote.pclienteTexto
                                strFila += ControlChars.Tab & diasDeProceso
                                strFila = "" + ControlChars.Tab & Consecutivo & strFila
                                grdAvances.AddItem(strFila)
                                Consecutivo += 1
                            End If

                        Else
                            strFila += ControlChars.Tab & Lote.pclienteTexto
                            strFila += ControlChars.Tab & diasDeProceso
                            strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvances.AddItem(strFila)
                            Consecutivo += 1
                        End If
                    End If
                Else
                    'strFila += ControlChars.Tab & " "
                    strFila += ControlChars.Tab & Lote.pclienteTexto
                    strFila += ControlChars.Tab & diasDeProceso
                    strFila = ControlChars.Tab & Consecutivo & strFila
                    grdAvances.AddItem(strFila)
                    Consecutivo += 1
                End If
            End If
            If cmbCelulas.SelectedIndex > 0 Then
                If strFila.Contains(cmbCelulas.Text) Then
                Else
                    Try
                        If grdAvances.Rows.Count > 1 Then
                            grdAvances.RemoveItem()
                        End If

                    Catch ex As Exception

                    End Try

                End If
            End If

        Next
        'lblTotalParesPrograma.Text = TotalPares.ToString("n0")
        'lblTotalLotesProgramas.Text = TotalLotes.ToString("n0")
        ParesProceso = TotalPares - ParesTerminados
        'lblParesTerminados.Text = ParesTerminados.ToString("n0")
        'lblParesProceso.Text = ParesProceso.ToString("n0")
        'lblLotesTerminados.Text = LotesTerminados.ToString("n0")
        LotesProceso = TotalLotes - LotesTerminados
        'lblLotesProceso.Text = LotesProceso.ToString("n0")
        Dim paresatrasadosgrid, lotesatrasadosgrid As Int32
        If paresAtrasadosFiltro > 0 Then
            'lblParesAtrasados.Text = paresAtrasadosFiltro.ToString("n0")
            'lblLotesAtrasados.Text = LotesAtrasadosFiltro.ToString("n0")
            paresatrasadosgrid = paresAtrasadosFiltro
            lotesatrasadosgrid = LotesAtrasadosFiltro
        Else
            'lblParesAtrasados.Text = ParesAtrasados.ToString("n0")
            'lblLotesAtrasados.Text = LotesAtrasados.ToString("n0")
            paresatrasadosgrid = ParesAtrasados
            lotesatrasadosgrid = LotesAtrasados
        End If
        Dim cadena = ""
        cadena = ControlChars.Tab & "PROGRAMADO" & ControlChars.Tab & TotalLotes.ToString("n0") & ControlChars.Tab & TotalPares.ToString("n0")
        grdResumenesNave.AddItem(cadena)
        cadena = ControlChars.Tab & "PROCESO" & ControlChars.Tab & LotesProceso.ToString("n0") & ControlChars.Tab & ParesProceso.ToString("n0")
        grdResumenesNave.AddItem(cadena)
        cadena = ControlChars.Tab & "TERMINADO" & ControlChars.Tab & LotesTerminados.ToString("n0") & ControlChars.Tab & ParesTerminados.ToString("n0")
        grdResumenesNave.AddItem(cadena)
        cadena = ControlChars.Tab & "ATRASADOS" & ControlChars.Tab & lotesatrasadosgrid.ToString("n0") & ControlChars.Tab & paresatrasadosgrid.ToString("n0")
        grdResumenesNave.AddItem(cadena)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        listaDiasAtrasados.Clear()
        grdAvances.Rows.Count = 1
        grdAvancesDetallado.Rows.Count = 1
        grdResumenesNave.Rows.Count = 1
        grdInventarioDepartamento.Rows.Count = 1
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
        paresAtrasadosFiltro = 0
        LotesAtrasadosFiltro = 0
        ParesAtrasadosDepartameto = 0
        LotesAtrasadosDepartamento = 0
        listaDeps = New List(Of DepartamentosProduccion)
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
        Me.Cursor = Cursors.WaitCursor
        LlenarGrid()
        If cmbDepartamento.SelectedIndex > 0 Then
            GenerarResumen()
            GenerarResumenCelulas()
        Else
            GenerarResumen()
            GenerarResumenCelulas2()
        End If
        If Not hilo.IsBusy Then
            hilo.RunWorkerAsync()
        End If
        LotesTerminadosDepartamento = 0
        ParesTerminadosDepartamento = 0
        LotesDepartamentoProceso = 0
        ParesDepartamentoProceso = 0
        LotesDepartamentoProceso = 0
        ParesDepartamentoProceso = 0
        ParesTerminadosDepartamento = 0
        LotesTerminadosDepartamento = 0
        TotalPares = 0
        TotalLotes = 0
        ParesTerminados = 0
        LotesTerminados = 0
        ParesProceso = 0
        LotesProceso = 0
        ParesAtrasados = 0
        LotesAtrasados = 0
        paresAtrasadosFiltro = 0
        LotesAtrasadosFiltro = 0
        inventario = New List(Of InventarioProduccion)
        'Dim cc As C1.Win.C1FlexGrid.CellStyle
        grdAvances.Cols("Cliente").Visible = False
        'grdAvancesDetallado.Cols("Cliente").Visible = True
        Try
            If chkMotivoAtraso.Checked Then

                Try
                    grdAvances.Cols("Motivo C").Visible = True

                Catch ex As Exception
                End Try
                Try
                    grdAvances.Cols("Motivo P").Visible = True
                Catch ex As Exception
                End Try
                Try
                    grdAvances.Cols("Motivo MA").Visible = True
                Catch ex As Exception
                End Try
            Else
                Try
                    grdAvances.Cols("Motivo C").Visible = False
                Catch ex As Exception
                End Try
                Try
                    grdAvances.Cols("Motivo P").Visible = False
                Catch ex As Exception
                End Try
                Try
                    grdAvances.Cols("Motivo MA").Visible = False
                Catch ex As Exception
                End Try
            End If
            If AtrasadoCorte = False Then
                grdAvances.Cols("DiasAtrasoCORTE").Visible = False
                'grdAvancesDetallado.Cols("DiasAtrasoCORTE").Visible = False
                'If chkMotivoAtraso.Checked Then
                '    grdAvances.Cols("MotivoAtrasoCORTE").Visible = True
                'Else
                '    grdAvances.Cols("MotivoAtrasoCORTE").Visible = False
                'End If
            Else
                AtrasadoCorte = False
            End If
        Catch ex As Exception

        End Try

        Try
            If AtrasadoPespunte = False Then
                grdAvances.Cols("DiasAtrasoPESPUNTE").Visible = False
                'grdAvancesDetallado.Cols("DiasAtrasoPESPUNTE").Visible = False
            Else
                AtrasadoPespunte = False
            End If
        Catch ex As Exception

        End Try


        Try
            If AtrasadoMontado = False Then
                grdAvances.Cols("DiasAtrasoMONTADO Y ADORNO").Visible = False
                'grdAvancesDetallado.Cols("DiasAtrasoMONTADO Y ADORNO").Visible = False
            Else
                AtrasadoMontado = False
            End If
        Catch ex As Exception

        End Try

        Try
            If AtrasadoEmbarque = False Then
                grdAvances.Cols("DiasAtrasoEMBARQUE").Visible = False
                'grdAvancesDetallado.Cols("DiasAtrasoEMBARQUE").Visible = False
            Else
                AtrasadoEmbarque = False
            End If
        Catch ex As Exception

        End Try

        'cc = Me.grdAvances.Styles.Add("ColumnColor")
        'Try
        '    If cmbDepartamento.Text = "CORTE" Then
        '        grdAvances.Cols("Célula").Visible = False
        '        cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
        '        Dim indice As New Int32
        '        indice = grdAvances.Cols("Célula").Index
        '        grdAvances.Cols(indice - 2).Style = Me.grdAvances.Styles("ColumnColor")
        '        grdAvances.Cols(indice - 1).Style = Me.grdAvances.Styles("ColumnColor")
        '    End If
        '    If cmbDepartamento.Text = "PESPUNTE" Then
        '        cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorPespunte)
        '        grdAvances.Cols("Célula").Style = Me.grdAvances.Styles("ColumnColor")
        '        Dim indice As New Int32
        '        indice = grdAvances.Cols("Célula").Index
        '        grdAvances.Cols(indice - 2).Style = Me.grdAvances.Styles("ColumnColor")
        '        grdAvances.Cols(indice - 1).Style = Me.grdAvances.Styles("ColumnColor")
        '    End If
        '    If cmbDepartamento.Text = "MONTADO Y ADORNO" Then
        '        cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorMontado)
        '        grdAvances.Cols("Célula").Style = Me.grdAvances.Styles("ColumnColor")
        '        Dim indice As New Int32
        '        indice = grdAvances.Cols("Célula").Index
        '        grdAvances.Cols(indice - 2).Style = Me.grdAvances.Styles("ColumnColor")
        '        grdAvances.Cols(indice - 1).Style = Me.grdAvances.Styles("ColumnColor")
        '    End If
        '    If cmbDepartamento.Text = "EMBARQUE" Then
        '        cc.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorNave)
        '        grdAvances.Cols("EMBARQUE").Style = Me.grdAvances.Styles("ColumnColor")
        '        Dim indice As New Int32
        '        indice = grdAvances.Cols("Célula").Index
        '        grdAvances.Cols(indice - 2).Style = Me.grdAvances.Styles("ColumnColor")
        '        grdAvances.Cols(indice - 1).Style = Me.grdAvances.Styles("ColumnColor")
        '    End If
        'Catch ex As Exception

        'End Try

        'If cmbDepartamento.Text = Nothing Then
        '    Dim ColorCorteCol As C1.Win.C1FlexGrid.CellStyle
        '    ColorCorteCol = Me.grdAvances.Styles.Add("ColumnColorCorte")
        '    ColorCorteCol.BackColor = System.Drawing.ColorTranslator.FromHtml(ColorCorte)
        '    Dim indice As New Int32
        '    indice = grdAvances.Cols("CORTE").Index
        '    grdAvances.Cols("CORTE").Style = Me.grdAvances.Styles("ColumnColorCorte")
        '    grdAvances.Cols(indice + 1).Style = Me.grdAvances.Styles("ColumnColorCorte")
        '    grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColorCorte")
        '    grdAvances.Cols(indice + 2).Visible = False


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
        '    ' grdAvances.Cols(indice + 2).Style = Me.grdAvances.Styles("ColumnColor")
        'End If




        For Each row As C1.Win.C1FlexGrid.Row In grdAvances.Rows
            Dim cc As C1.Win.C1FlexGrid.CellStyle
            cc = Me.grdAvances.Styles.Add("ColumnColor")
            ColorNave = "#85A3FF"
            If row.Index > 0 Then
                Try

                    If grdAvances(row.Index, "CORTE").ToString.Length > 0 Then
                        Dim ColorCorteCol As C1.Win.C1FlexGrid.CellStyle
                        Dim indice As New Int32
                        indice = grdAvances.Cols("CORTE").Index
                        grdAvances.Cols(indice + 2).Visible = False
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


        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub btnImprimir_Click(sender As Object, e As EventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim objBU As New LotesAvancesBU
    '    Dim tabla As New DataTable
    '    Dim dsTablaInventarios As New DataSet("dsListaProduccionAvances")
    '    Dim NaveId As Integer
    '    Dim Status As Boolean = True

    '    NaveId = cmbNave.SelectedValue

    '    Dim tabla1 As New DataTable
    '    Dim tabla2 As New DataTable
    '    Dim tabla3 As New DataTable
    '    Dim tabla4 As New DataTable

    '    Me.Cursor = Cursors.WaitCursor

    '    If AprobarReporte() = True Then
    '        tabla1 = objBU.RegistrosProduccionDeAvancesMA(NaveId, dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString)
    '        tabla2 = objBU.RegistrosResumenProduccionDeAvancesMA(NaveId, dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString)
    '        tabla3 = objBU.RegistrosProduccionDeAvancesPT(NaveId, dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString)
    '        tabla4 = objBU.RegistrosResumenProduccionDeAvancesPT(NaveId, dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString)
    '    End If


    '    If tabla1.Rows.Count > 0 And tabla3.Rows.Count = 0 Then
    '        Status = True
    '        tabla1.TableName = "dtInventarioProduccion"
    '        tabla4.TableName = "dtResumenDeProduccion"
    '        dsTablaInventarios.Tables.Add(tabla1)
    '        dsTablaInventarios.Tables.Add(tabla4)
    '    End If
    '    If tabla3.Rows.Count > 0 And tabla1.Rows.Count = 0 Then
    '        Status = True
    '        tabla3.TableName = "dtInventarioProduccion"
    '        tabla4.TableName = "dtResumenDeProduccion"
    '        dsTablaInventarios.Tables.Add(tabla3)
    '        dsTablaInventarios.Tables.Add(tabla4)
    '    End If

    '    If tabla1.Rows.Count > 0 And tabla3.Rows.Count > 0 Then
    '        Status = False
    '        tabla1.TableName = "dtProduccionAvancesMA"
    '        tabla2.TableName = "dtResumen"
    '        tabla3.TableName = "dtProdAvanceProductoTerminado"
    '        dsTablaInventarios.Tables.Add(tabla1)
    '        dsTablaInventarios.Tables.Add(tabla2)
    '        dsTablaInventarios.Tables.Add(tabla3)
    '    End If

    '    If Status = False Then
    '        If tabla1.Rows.Count = 0 And tabla3.Rows.Count = 0 Then
    '            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte en Montado y Adorno o Embarque.")
    '        Else
    '            Try
    '                Dim OBJReporte As New Framework.Negocios.ReportesBU
    '                Dim EntidadReporte As Entidades.Reportes
    '                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_AVANCE_PRODUCCION_POR_PROGRAMA")
    '                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
    '                    EntidadReporte.Pnombre + ".mrt"
    '                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
    '                Dim reporte As New StiReport

    '                reporte.Load(archivo)
    '                reporte.Compile()
    '                reporte("urlImagenNave") = GetRutaLogoPorNave(tabla1)
    '                reporte("fecha") = Now.ToShortDateString
    '                reporte("Departamento") = "MONTADO Y ADORNO"
    '                reporte("Titulo") = "INVENTARIO " + "MONTADO Y ADORNO"
    '                'reporte("TotalLotes") = ObtenerTotales(tabla2, "TotalLotes", "TotalLotesPT")
    '                'reporte("TotalPares") = ObtenerTotales(tabla2, "TotalPares", "TotalParesPT")
    '                reporte.RegData(dsTablaInventarios)
    '                reporte.Show()
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    Else
    '        If tabla1.Rows.Count = 0 And tabla3.Rows.Count = 0 Then
    '            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte, en Montado y Adorno.")
    '        Else
    '            Try
    '                Dim OBJReporte As New Framework.Negocios.ReportesBU
    '                Dim EntidadReporte As Entidades.Reportes
    '                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_AVANCE_PRODUCCION_POR_PROGRAMA_MA_PT")
    '                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
    '                        EntidadReporte.Pnombre + ".mrt"
    '                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
    '                Dim reporte As New StiReport

    '                reporte.Load(archivo)
    '                reporte.Compile()
    '                If tabla1.Rows.Count > 0 Then
    '                    reporte("urlImagenNave") = GetRutaLogoPorNave(tabla1)
    '                    reporte("Encabezado") = "EN PROCESO"
    '                Else
    '                    reporte("urlImagenNave") = GetRutaLogoPorNave(tabla3)
    '                    reporte("Encabezado") = "TERMINADO"
    '                End If
    '                reporte("fecha") = Now.ToShortDateString
    '                reporte("Departamento") = "MONTADO Y ADORNO"
    '                reporte("Titulo") = "INVENTARIO " + "MONTADO Y ADORNO"
    '                reporte.RegData(dsTablaInventarios)
    '                reporte.Show()
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Function AprobarReporte()
        Dim Traerdatos As Boolean = True

        For i As Integer = 1 To grdAvances.Rows.Count - 1
            If grdAvances.Rows(i).Item("Montado Y Adorno").ToString() = "" Then
                Traerdatos = False
            Else
                Traerdatos = True
                Return Traerdatos
            End If
        Next
        Return Traerdatos
    End Function

    Private Function GetRutaLogoPorNave(ByVal img As DataTable)
        Dim imagenNave As String
        For i As Integer = 0 To img.Rows.Count - 1
            If img.Rows(i).Item("Imagen").ToString() <> "" Then
                imagenNave = img.Rows(i).Item("Imagen").ToString()
            End If
        Next
        Return imagenNave
    End Function
    Private Function ObtenerTotales(ByVal tabla As DataTable, ByVal encabezado As String, ByVal encabezado2 As String)
        Dim total As Integer
        For i As Integer = 0 To tabla.Rows.Count - 1
            If tabla.Columns.Contains(encabezado) And tabla.Columns.Contains(encabezado2) Then
                If IsDBNull(tabla.Rows(i).Item(encabezado)) = False And IsDBNull(tabla.Rows(i).Item(encabezado2)) = False Then
                    total = tabla.Rows(i).Item(encabezado) + tabla.Rows(i).Item(encabezado2)
                End If
            End If
        Next
        Return total
    End Function

    Private Sub btnRegistrarAtraso_Click(sender As Object, e As EventArgs) Handles btnRegistrarAtraso.Click
        Dim form As New AvancesProduccion_CapturaMotivoRestraso_Form
        form.ShowDialog(Me)
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        menuImprimir.Show(btnExportar, 0, btnExportar.Height)
    End Sub

    Public Sub GenerarResumen()
        For Each dep As DepartamentosProduccion In Departamentos
            For Each inve As InventarioProduccion In inventario
                If dep.PIDConfiguracion = inve.PIDDepartamento Then
                    Dim Str As String = ""
                    Dim inventario As New InventarioProduccion
                    inventario = inve
                    LotesTerminado = 0
                    ParesTerminado = 0
                    LotesTerminados = TotalLotes - inventario.PLotesProg
                    ParesTerminados = TotalPares - inventario.PParesProg
                    Str += ControlChars.Tab & dep.PNombre &
                   ControlChars.Tab & inventario.PLotesProg.ToString("##,00") &
                   ControlChars.Tab & inventario.PParesProg.ToString("##,00") &
                   ControlChars.Tab & LotesTerminados.ToString("##,00") &
                   ControlChars.Tab & ParesTerminados.ToString("##,00")
                    For Each dep1 As DepartamentosProduccion In tmpDepartamentos
                        If dep1.PNombre = dep.PNombre Then
                            Str += ControlChars.Tab & dep1.PLotesAtrados.ToString("##,00") &
                   ControlChars.Tab & dep1.PparesAtrasados.ToString("##,00") &
                   ControlChars.Tab
                        End If
                    Next
                    grdInventarioDepartamento.AddItem(Str)
                End If
            Next
        Next
    End Sub
    Private Sub cmbDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        Try
            cmbCelulas = Controles.ComboCelulasSegunDepartamentoProduccion(cmbCelulas, cmbNave.SelectedValue, cmbDepartamento.SelectedValue)
            CargarCelulas()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GenerarResumenCelulas()
        For Each Celulas As CelulasProduccion In ListaCelulas
            Dim strFila = "" ' & ControlChars.Tab

            If Celulas.PNombreCelula = Nothing Then
                Celulas.PNombreCelula = "Total Terminados"
            End If
            strFila += ControlChars.Tab & Celulas.PNombreCelula &
                    ControlChars.Tab & Celulas.PCantidadAcumuladaLotes.ToString("##,00") &
                    ControlChars.Tab & Celulas.PCantidadAcumuladaPares.ToString("##,00") &
                    ControlChars.Tab & Celulas.PCantidadTerminadasLotes.ToString("##,00") &
                    ControlChars.Tab & Celulas.PCantidadTerminadasPares.ToString("##,00") &
                    ControlChars.Tab & Celulas.PCantidadAtrasadasLotes.ToString("##,00") &
                    ControlChars.Tab & Celulas.PCantidadAtrasadasPares.ToString("##,00")
            'TotalLotesResumen += Celulas.PCantidadAcumuladaLotes
            'TotalParesResumen += Celulas.PCantidadAcumuladaPares
            grdResumenesDepartamentos.AddItem(strFila)
        Next
    End Sub
    Public Sub GenerarResumenCelulas2()
        For Each Celulas As CelulasProduccion In ListaCelulas
            Dim strFila = "" ' & ControlChars.Tab
            If Celulas.PNombreCelula = Nothing Then
                Celulas.PNombreCelula = "Total Terminados"
            End If
            strFila += ControlChars.Tab & Celulas.PNombreCelula &
                    ControlChars.Tab & Celulas.PCantidadAcumuladaLotes.ToString("##,00") &
                    ControlChars.Tab & Celulas.PCantidadAcumuladaPares.ToString("##,00") &
                    ControlChars.Tab & Celulas.PCantidadTerminadasLotes.ToString("##,00") &
            ControlChars.Tab & Celulas.PCantidadTerminadasPares.ToString("##,00") &
                  ControlChars.Tab & Celulas.PCantidadAtrasadasLotes.ToString("##,00") &
            ControlChars.Tab & Celulas.PCantidadAtrasadasPares.ToString("##,00")
            'TotalLotesResumen += Celulas.PCantidadAcumuladaLotes
            'TotalParesResumen += Celulas.PCantidadAcumuladaPares
            grdResumenesDepartamentos.AddItem(strFila)
        Next
    End Sub
    Public Sub CargarCelulas()
        Try
            Dim tablaCelulas As New List(Of Celulas)
            Dim objCelulasBU As New DepartamentosSICYBU
            Dim objNaveSicy As New Naves
            objNaveSicy = objCelulasBU.listaNave(cmbNave.SelectedValue)
            If cmbDepartamento.SelectedIndex > 0 Then
                tablaCelulas = objCelulasBU.ListaCelulasSegunNaveDepto2(objNaveSicy.PNaveSICYid, cmbDepartamento.SelectedValue, True)
            Else
                tablaCelulas = objCelulasBU.ListaCelulasSegunNaveDepto2(objNaveSicy.PNaveSICYid, cmbDepartamento.SelectedValue, False)
            End If

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

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        GroupBox1.Height = 107
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        GroupBox1.Height = 45
    End Sub

    Private Sub C1FlexGrid2_Click(sender As Object, e As EventArgs) Handles C1FlexGrid2.Click

    End Sub

    Private Sub C1FlexGrid4_Click(sender As Object, e As EventArgs) Handles C1FlexGrid4.Click

    End Sub

    Private Sub grdInventarioDepartamento_Click(sender As Object, e As EventArgs) Handles grdInventarioDepartamento.Click

    End Sub

    Private Sub grdAvances_Click(sender As Object, e As EventArgs) Handles grdAvances.Click

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
    Private Sub ReporteAvancesPorProgramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteAvancesPorProgramaToolStripMenuItem.Click
        ExportarGridAExcel()
    End Sub

    Private Sub ReporteAvancesPorProgramaDetalladoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteAvancesPorProgramaDetalladoToolStripMenuItem.Click
        ExportarGridAExcelDetallado()
    End Sub
    Private Sub ExportarGridAExcelDetallado()
        If detallado = True Then
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
                    grdAvancesDetallado.SaveExcel(fileName, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells)
                    Process.Start(fileName)
                    Me.Cursor = Cursors.Default
                Catch ex As Exception
                    Dim adv As New AdvertenciaForm
                    adv.mensaje = "Surgió algo inesperado detalle: " + ex.Message
                    adv.ShowDialog()
                    Me.Cursor = Cursors.Default
                End Try
            End If

        Else
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Aún no se cargan los datos para el reporte espere unos segundos y vuelva a guardar el reporte."
            adv.ShowDialog()
        End If
    End Sub
    Public Sub LlenarGrid2()

        Dim ListaAvancesProduccion As New List(Of LotesAvances)
        Dim objBU As New LotesAvancesBU
        Dim objBU2 As New LotesAvancesBU
        Dim diasAtrasados As New Double
        Dim Naveid As Int32
        Dim Consecutivo As Int32 = 1
        If cmbNave.SelectedIndex > 0 Then
            Naveid = cmbNave.SelectedValue
        End If

        ' Dim Departamentos As New List(Of Int32)
        grdAvancesDetallado.Cols.Count = 10
        If cmbDepartamento.SelectedValue > 0 Then
            For Each dep As DepartamentosProduccion In Departamentos
                If dep.PIDConfiguracion = cmbDepartamento.SelectedValue Then
                    grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1

                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = dep.PNombre
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = dep.PNombre
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).StyleDisplay.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Días atraso"
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "DiasAtraso" + dep.PNombre
                    grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Célula"
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Célula"
                    grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
                    If dep.PNombre.Equals("CORTE") Then
                        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Motivo C"
                        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Motivo C"
                    End If
                    If dep.PNombre.Equals("PESPUNTE") Then
                        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Motivo P"
                        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Motivo P"
                    End If
                    If dep.PNombre.Equals("MONTADO Y ADORNO") Then
                        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Motivo MA"
                        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Motivo MA"
                    End If

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
                grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
                Dim DepartamentoNombre As String = dep.PNombre.ToLower
                grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(DepartamentoNombre)
                grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = dep.PNombre
                grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
                grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Días atraso"
                grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "DiasAtraso" + dep.PNombre
                grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).StyleDisplay.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
                grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Célula"
                grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
                If dep.PNombre.Equals("CORTE") Then
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Motivo C"
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Motivo C"
                End If
                If dep.PNombre.Equals("PESPUNTE") Then
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Motivo P"
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Motivo P"
                End If
                If dep.PNombre.Equals("MONTADO Y ADORNO") Then
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Motivo MA"
                    grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Motivo MA"
                End If
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

        Dim ContarLotesAtrasadosEmbarque As New Boolean
        ContarLotesAtrasadosEmbarque = False
        If cmbDepartamento.SelectedIndex = 0 Or cmbDepartamento.Text = "EMBARQUE" Then
            grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
            grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Embarque"
            grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "EMBARQUE"
            ContarLotesAtrasadosEmbarque = True
            grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
            grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Días atraso"
            grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "DiasAtrasoEMBARQUE"
            ColorNave = "#85A3FF"
        End If
        grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Pedido"
        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Pedido"
        grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Cliente"
        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Cliente"
        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Width = 560
        grdAvancesDetallado.Cols.Count = grdAvancesDetallado.Cols.Count + 1
        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Caption = "Días de proceso"
        grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).Name = "Días de proceso"
        'grdAvancesDetallado.Cols(grdAvancesDetallado.Cols.Count - 1).StyleDisplay.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
        ListaAvancesProduccion = objBU.ListaAvancesProduccionDetallado(dtpFechaInicio.Value.ToShortDateString, dtpFechaFinal.Value.ToShortDateString, Naveid, listaDeps)
        Dim fechaInicio As New Date
        Dim fechaFin As New Date
        Dim diasDeProceso As Double = 0.0
        For Each Lote As LotesAvances In ListaAvancesProduccion

            fechaInicio = Lote.PFechaLote
            If Not Lote.PFechaEmbarque = Date.MinValue Then
                fechaFin = Lote.PFechaEmbarque.ToShortDateString
            Else
                fechaFin = DateTime.Now.ToString("dd/MM/yyyy")
            End If
            diasDeProceso = getDiasdeProceso(fechaInicio, fechaFin)
            Dim Departamentos As Boolean = False
            If Not Lote.PFechaEmbarque = Date.MinValue Then
                ParesTerminados += Lote.PPares
                LotesTerminados += 1
            Else
            End If

            Dim strFila As String = ControlChars.Tab & Lote.PFechaLote &
                                    ControlChars.Tab & Lote.PLote &
                                    ControlChars.Tab & Lote.PModelo &
                                    ControlChars.Tab & Lote.PColeccion &
                                    ControlChars.Tab & Lote.PTalla &
                                    ControlChars.Tab & Lote.PColor &
                                    ControlChars.Tab & Lote.PPares &
                                    ControlChars.Tab & diasAtrasados

            'ControlChars.Tab & Lote.PObservaciones
            TotalPares += Lote.PPares
            TotalLotes += 1

            Dim diasTotales As Int32 = 0
            Dim estaatrasado As Boolean = False
            Dim estaProceso As Boolean = False
            For Each departamentoAvance As DepartamentosProduccion In Lote.PAvanceDepartamentos
                Dim Existe As Boolean = False
                Dim depTotales As New DepartamentosProduccion
                Dim IDDEpartamento As Int32
                IDDEpartamento = departamentoAvance.PIDConfiguracion
                'MsgBox(departamentoAvance.PIDConfiguracion)
                depTotales = departamentoAvance
                If depTotales.PFechaAvance = Date.MinValue Then
                    strFila += ControlChars.Tab & ""
                    estaProceso = True

                    If inventario.Count = 0 Then
                        'Dim AgregarDatosDepartamentos As New InventarioProduccion
                        'AgregarDatosDepartamentos.PParesProg = 0
                        'AgregarDatosDepartamentos.PLotesProg += 0
                        'AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        'inventario.Add(AgregarDatosDepartamentos)

                    End If

                    For Each recorrerinventario As InventarioProduccion In inventario
                        If recorrerinventario.PIDDepartamento = IDDEpartamento Then
                            Existe = True
                            If Existe = True Then

                                recorrerinventario.PParesProg += Lote.PPares
                                recorrerinventario.PLotesProg += 1
                            End If
                        End If
                    Next
                    If Existe = False Then
                        'Dim AgregarDatosDepartamentos As New InventarioProduccion
                        'AgregarDatosDepartamentos.PParesProg += Lote.PPares
                        'AgregarDatosDepartamentos.PLotesProg += 1
                        'AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        'inventario.Add(AgregarDatosDepartamentos)
                    End If
                Else
                    strFila += ControlChars.Tab & depTotales.PFechaAvance.ToShortDateString
                    Departamentos = True
                    Dim AgregarDatosDepartamentos As New InventarioProduccion
                    If inventario.Count = 0 Then
                        'AgregarDatosDepartamentos.PParesTerminados = Lote.PPares
                        'AgregarDatosDepartamentos.PLotesTerminados += 1
                        'AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        'inventario.Add(AgregarDatosDepartamentos)
                    End If
                    For Each recorrerinventario As InventarioProduccion In inventario
                        If recorrerinventario.PIDDepartamento = IDDEpartamento Then
                            Existe = True
                            If Existe = True Then
                                'AgregarDatosDepartamentos.PParesTerminados = Lote.PPares
                                'AgregarDatosDepartamentos.PLotesTerminados += 1
                            End If
                        End If
                    Next
                    If Existe = False Then
                        'AgregarDatosDepartamentos.PParesTerminados += Lote.PPares
                        'AgregarDatosDepartamentos.PLotesTerminados += 1
                        'AgregarDatosDepartamentos.PIDDepartamento = IDDEpartamento
                        'inventario.Add(AgregarDatosDepartamentos)
                    End If

                End If
                Dim depar As String = " "
                If departamentoAvance.PNombre = "CORTE" Then
                    depar = "COR"
                End If
                If departamentoAvance.PNombre = "PESPUNTE" Then
                    depar = "PES"
                End If
                If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                    depar = "MONTD"
                End If
                If departamentoAvance.PNombre = "EMBARQUE" Then
                    depar = "EMB"
                End If
                Dim data As DataTable = objBU2.getdiasAtrasosDepartamento(Lote.PLote, cmbNave.SelectedValue, Year(Lote.PFechaLote), depar)
                For Each row As DataRow In data.Rows
                    diasAtrasados = Convert.ToDouble(row("dias").ToString)
                Next
                'diasTotales = departamentoAvance.PDias / 6 - 1
                'Dim fechaInicio As New Date
                'fechaInicio = Lote.PFechaLote
                'Dim FechaFin As New Date
                'FechaFin = Today

                'While fechaInicio < FechaFin.AddDays(1)
                '    If fechaInicio.DayOfWeek = 6 Then
                '        diasTotales += 1
                '    End If
                '    fechaInicio = fechaInicio.AddDays(1)
                'End While

                'diasAtrasados = DateDiff("d", Lote.PFechaLote.AddDays(diasTotales), Today)

                If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                    strFila += ControlChars.Tab & diasAtrasados.ToString & " "

                    If diasAtrasados > 0 Then
                        ParesAtrasados += Lote.PPares
                        LotesAtrasados += 1
                        'LotesAtrasadosDepartamento += 1
                        'ParesAtrasadosDepartameto += Lote.PPares
                        If departamentoAvance.PNombre = "CORTE" Then
                            AtrasadoCorte = True
                        End If
                        If departamentoAvance.PNombre = "PESPUNTE" Then
                            AtrasadoPespunte = True
                        End If
                        If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                            AtrasadoMontado = True
                        End If
                        If departamentoAvance.PNombre = "EMBARQUE" Then
                            AtrasadoEmbarque = True
                        End If
                    End If
                    estaatrasado = True
                Else
                    If departamentoAvance.PNombre = "CORTE" Then
                        For Each dep As DepartamentosProduccion In tmpDepartamentos
                            If dep.PNombre = "CORTE" Then
                                If Lote.PDiasAtrasados1 = 0 Then
                                    strFila += ControlChars.Tab & ""
                                Else
                                    strFila += ControlChars.Tab & Lote.PDiasAtrasados1
                                End If
                            End If
                        Next
                        AtrasadoCorte = True
                    End If
                    If departamentoAvance.PNombre = "PESPUNTE" Then
                        For Each dep As DepartamentosProduccion In tmpDepartamentos
                            If dep.PNombre = "PESPUNTE" Then
                                If Lote.PDiasAtrasados2 = 0 Then
                                    strFila += ControlChars.Tab & ""
                                Else
                                    strFila += ControlChars.Tab & Lote.PDiasAtrasados2
                                End If
                            End If
                        Next
                        AtrasadoPespunte = True
                    End If
                    If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                        For Each dep As DepartamentosProduccion In tmpDepartamentos
                            If dep.PNombre = "MONTADO Y ADORNO" Then
                                If Lote.PDiasAtrasados3 = 0 Then
                                    strFila += ControlChars.Tab & ""
                                Else
                                    strFila += ControlChars.Tab & Lote.PDiasAtrasados3
                                End If
                            End If
                        Next
                        AtrasadoMontado = True
                    End If

                End If

                If departamentoAvance.PCelulas = Nothing Then
                    strFila += ControlChars.Tab & "NO ASIGNADA"

                    If departamentoAvance.PNombre = "CORTE" Then
                        strFila += ControlChars.Tab & Lote.pmotivoDepartamento1
                    End If
                    If departamentoAvance.PNombre = "PESPUNTE" Then
                        strFila += ControlChars.Tab & Lote.pmotivoDepartamento2
                    End If
                    If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                        strFila += ControlChars.Tab & Lote.pmotivoDepartamento3
                    End If
                    'For Each Celula As CelulasProduccion In ListaCelulas
                    '    If Celula.PNombreCelula = "NO ASIGNADA" Then
                    '        If Not departamentoAvance.PFechaAvance = Date.MinValue Then
                    '            Celula.PCantidadTerminadasPares += Lote.PPares
                    '            Celula.PCantidadTerminadasLotes += 1
                    '        Else
                    '            Celula.PCantidadAcumuladaLotes += 1
                    '            Celula.PCantidadAcumuladaPares += Lote.PPares
                    '        End If
                    '        If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                    '            If diasAtrasados > 0 Then
                    '                Celula.PCantidadAtrasadasPares += Lote.PPares
                    '                Celula.PCantidadAtrasadasLotes += 1
                    '            End If
                    '        End If
                    '    End If
                    'Next
                Else
                    strFila += ControlChars.Tab & departamentoAvance.PCelulas
                    If departamentoAvance.PNombre = "CORTE" Then
                        strFila += ControlChars.Tab & Lote.pmotivoDepartamento1
                    End If
                    If departamentoAvance.PNombre = "PESPUNTE" Then
                        strFila += ControlChars.Tab & Lote.pmotivoDepartamento2
                    End If
                    If departamentoAvance.PNombre = "MONTADO Y ADORNO" Then
                        strFila += ControlChars.Tab & Lote.pmotivoDepartamento3
                    End If
                    'For Each Celula As CelulasProduccion In ListaCelulas
                    '    If Celula.PNombreCelula = departamentoAvance.PCelulas Then

                    '        If Not departamentoAvance.PFechaAvance = Date.MinValue Then
                    '            Celula.PCantidadTerminadasPares += Lote.PPares
                    '            Celula.PCantidadTerminadasLotes += 1

                    '        Else
                    '            Celula.PCantidadAcumuladaLotes += 1
                    '            Celula.PCantidadAcumuladaPares += Lote.PPares
                    '        End If

                    '        If diasAtrasados > 0 And departamentoAvance.PFechaAvance = Date.MinValue Then
                    '            If diasAtrasados > 0 Then
                    '                Celula.PCantidadAtrasadasPares += Lote.PPares
                    '                Celula.PCantidadAtrasadasLotes += 1
                    '            End If
                    '        End If

                    '    End If

                    'Next

                End If
            Next
            '********************************************

            If cmbDepartamento.SelectedValue = 0 Or cmbDepartamento.Text = "EMBARQUE" Then
                If Not Lote.PFechaEmbarque = Date.MinValue Then
                    strFila += ControlChars.Tab & Lote.PFechaEmbarque.ToShortDateString + ControlChars.Tab & ""
                Else
                    'diasTotales = 4
                    'Dim fechaInicio As New Date
                    'fechaInicio = Lote.PFechaLote
                    'Dim FechaFin As New Date
                    'FechaFin = Today


                    'While fechaInicio < FechaFin.AddDays(1)
                    '    If fechaInicio.DayOfWeek = 6 Then
                    '        diasTotales += 1
                    '    End If
                    '    fechaInicio = fechaInicio.AddDays(1)
                    'End While
                    'diasAtrasados = DateDiff("d", Lote.PFechaLote.AddDays(diasTotales), Today)
                    Dim depar As String = "EMB"
                    Dim data As DataTable = objBU2.getdiasAtrasosDepartamento(Lote.PLote, cmbNave.SelectedValue, Year(Lote.PFechaLote), depar)
                    For Each row As DataRow In data.Rows
                        diasAtrasados = Convert.ToDouble(row("dias").ToString)
                    Next
                    If diasAtrasados > 0 Then
                        LotesAtrasados += 1
                        ParesAtrasados += Lote.PPares
                    End If
                    If diasAtrasados > 0 Then
                        strFila += ControlChars.Tab & "" + ControlChars.Tab & diasAtrasados
                        estaatrasado = True
                    Else
                        strFila += ControlChars.Tab & "" + ControlChars.Tab & ""
                    End If

                End If
            Else
                'Dim depar As String = "EMB"
                'Dim data As DataTable = objBU2.getdiasAtrasosDepartamento(Lote.PLote, cmbNave.SelectedValue, Year(Lote.PFechaLote), depar)
                'For Each row As DataRow In data.Rows
                '    diasAtrasados = Convert.ToDouble(row("dias").ToString)
                'Next
                'If diasAtrasados > 0 Then
                '    strFila += ControlChars.Tab & "" + ControlChars.Tab & diasAtrasados
                '    estaatrasado = True
                'Else
                '    strFila += ControlChars.Tab & "" + ControlChars.Tab & ""
                'End If
            End If
            If rdoAtrasados.Checked = True Or rdoTerminados.Checked = True Then
                If rdoAtrasados.Checked = True Then
                    If estaatrasado = True Then

                        paresAtrasadosFiltro += Lote.PPares
                        LotesAtrasadosFiltro += 1
                        strFila += ControlChars.Tab & Lote.pidPedido
                        strFila += ControlChars.Tab & Lote.pclienteTexto
                        strFila += ControlChars.Tab & diasDeProceso
                        strFila = "" + ControlChars.Tab & Consecutivo & strFila
                        grdAvancesDetallado.AddItem(strFila)
                        Consecutivo += 1
                    End If
                Else


                End If
                If rdoTerminados.Checked = True Then

                    If cmbDepartamento.SelectedValue > 0 Then
                        If Departamentos = True Then
                            strFila += ControlChars.Tab & Lote.pidPedido
                            strFila += ControlChars.Tab & Lote.pclienteTexto
                            strFila += ControlChars.Tab & diasDeProceso
                            strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvancesDetallado.AddItem(strFila)
                            Consecutivo += 1
                        End If
                    Else
                        If Lote.PFechaEmbarque <> Date.MinValue Then
                            strFila += ControlChars.Tab & Lote.pidPedido
                            strFila += ControlChars.Tab & Lote.pclienteTexto
                            strFila += ControlChars.Tab & diasDeProceso
                            strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvancesDetallado.AddItem(strFila)
                            Consecutivo += 1
                        End If
                    End If
                Else
                End If
            Else
                If rdoProcesos.Checked = True Then

                    If estaProceso = True Then
                        If cmbDepartamento.SelectedValue > 0 Then
                            If Departamentos = False Then
                                strFila += ControlChars.Tab & Lote.pidPedido
                                strFila += ControlChars.Tab & Lote.pclienteTexto
                                strFila += ControlChars.Tab & diasDeProceso
                                strFila = "" + ControlChars.Tab & Consecutivo & strFila
                                grdAvancesDetallado.AddItem(strFila)
                                Consecutivo += 1
                            End If
                        Else
                            strFila += ControlChars.Tab & Lote.pidPedido
                            strFila += ControlChars.Tab & Lote.pclienteTexto
                            strFila += ControlChars.Tab & diasDeProceso
                            strFila = "" + ControlChars.Tab & Consecutivo & strFila
                            grdAvancesDetallado.AddItem(strFila)
                            Consecutivo += 1
                        End If
                    End If
                Else
                    'strFila += ControlChars.Tab & " "
                    strFila += ControlChars.Tab & Lote.pidPedido
                    strFila += ControlChars.Tab & Lote.pclienteTexto
                    strFila += ControlChars.Tab & diasDeProceso
                    strFila = ControlChars.Tab & Consecutivo & strFila

                    grdAvancesDetallado.AddItem(strFila)
                    Consecutivo += 1
                End If
            End If
            If cmbCelulas.SelectedIndex > 0 Then
                If strFila.Contains(cmbCelulas.Text) Then
                Else
                    Try
                        If grdAvancesDetallado.Rows.Count > 1 Then
                            grdAvancesDetallado.RemoveItem()
                        End If

                    Catch ex As Exception
                    End Try
                End If
            End If

        Next
    End Sub

    Private Sub btnResumenAtrasos_Click(sender As Object, e As EventArgs) Handles btnResumenAtrasos.Click
        If listaDiasAtrasados.Count = 0 Then
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "No hay atrasos."
            objMensaje.ShowDialog()
        Else
            Dim form As New ResumenMotivosAtrasos
            form.listaDiasAtrasados = listaDiasAtrasados
            form.ShowDialog()
        End If
    End Sub
    Function getDiasdeProceso(ByVal fInicio As Date, ByVal fFin As Date) As Double
        'Domingo=0,Lunes=1, Martes=2,Miercoles=3,Jueves=4,Viernes=5,Sabado=6
        Dim dias As Integer = 0
        Dim diasTotales As Double = 0
        dias = DateDiff(DateInterval.Day, fInicio, fFin) 'dias que existen entre el rango de fechas
        For index As Integer = 1 To dias
            If index = 1 Then
                If fInicio.DayOfWeek = 0 Then
                    'No cuenta el dia
                ElseIf fInicio.DayOfWeek = 6 Then

                    'If fInicio.Month = 3 Then
                    '    If fInicio.Day = 21 Then
                    '    ElseIf fInicio.Day = 22 Then
                    '    ElseIf fInicio.Day = 23 Then
                    '    ElseIf fInicio.Day = 24 Then
                    '    ElseIf fInicio.Day = 25 Then
                    '    ElseIf fInicio.Day = 26 Then
                    '    Else
                    '        diasTotales = diasTotales + 0.5
                    '    End If
                    'Else
                    diasTotales = diasTotales + 0.5
                    'End If

                Else
                'If fInicio.Month = 3 Then
                '    If fInicio.Day = 21 Then
                '    ElseIf fInicio.Day = 22 Then
                '    ElseIf fInicio.Day = 23 Then
                '    ElseIf fInicio.Day = 24 Then
                '    ElseIf fInicio.Day = 25 Then
                '    ElseIf fInicio.Day = 26 Then

                '    Else
                'diasTotales = diasTotales + 1
                '    End If
                'Else
                diasTotales = diasTotales + 1
                    'End If
                End If
            End If
            If DateAdd(DateInterval.Day, index, fInicio).DayOfWeek = 0 Then
                'No cuenta el dia
            ElseIf DateAdd(DateInterval.Day, index, fInicio).DayOfWeek = 6 Then
                'If DateAdd(DateInterval.Day, index, fInicio).Month = 3 Then
                '    If DateAdd(DateInterval.Day, index, fInicio).Day = 21 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 22 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 23 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 24 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 25 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 26 Then
                '    Else
                '        diasTotales = diasTotales + 0.5
                '    End If
                'Else
                diasTotales = diasTotales + 0.5
                'End If

            Else
                'If DateAdd(DateInterval.Day, index, fInicio).Month = 3 Then
                '    If DateAdd(DateInterval.Day, index, fInicio).Day = 21 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 22 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 23 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 24 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 25 Then
                '    ElseIf DateAdd(DateInterval.Day, index, fInicio).Day = 26 Then
                '    Else
                '        diasTotales = diasTotales + 1
                '    End If
                'Else
                diasTotales = diasTotales + 1
                'End If

            End If
        Next
        Return diasTotales
    End Function

    Private Sub hilo_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles hilo.DoWork
        detallado = False
        Try
            LlenarGrid2()
            grdAvancesDetallado.Cols("Cliente").Visible = True
        Catch ex As Exception

        End Try
        Try
            If AtrasadoCorte = False Then
                grdAvancesDetallado.Cols("DiasAtrasoCORTE").Visible = False
            Else
                AtrasadoCorte = False
            End If
        Catch ex As Exception

        End Try
        Try
            If AtrasadoPespunte = False Then
                grdAvancesDetallado.Cols("DiasAtrasoPESPUNTE").Visible = False
            Else
                AtrasadoPespunte = False
            End If
        Catch ex As Exception

        End Try


        Try
            If AtrasadoMontado = False Then
                grdAvancesDetallado.Cols("DiasAtrasoMONTADO Y ADORNO").Visible = False
            Else
                AtrasadoMontado = False
            End If
        Catch ex As Exception

        End Try

        Try
            If AtrasadoEmbarque = False Then
                grdAvancesDetallado.Cols("DiasAtrasoEMBARQUE").Visible = False
            Else
                AtrasadoEmbarque = False
            End If
        Catch ex As Exception

        End Try
        detallado = True
    End Sub
End Class