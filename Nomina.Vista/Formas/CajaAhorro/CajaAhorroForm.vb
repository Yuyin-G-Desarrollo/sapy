Imports Stimulsoft.Report
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Win
Imports Infragistics.Documents.Reports.Graphics
Imports Tools

Public Class CajaAhorroForm
    Public AsistenteCaja As Boolean = 0

    Public Sub ejecutarReporteConcentrado()
        'Try

        Dim objCajaAhorroBU As New Negocios.CajaAhorroBU
        Dim objDeduccionesBU As New Negocios.DeduccionesBU
        Dim entCajaAhorro As New Entidades.CajaAhorro

        Dim objBu As New Negocios.ReporteCajaAhorroBU

        Dim dtMesesAnio As New DataTable
        Dim idCajaAhorro As Int32 = 0

        If grdCajaAhorro.Rows.Count > 0 AndAlso grdCajaAhorro.Row > 0 Then
            idCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Es necesario seleccionar una caja de ahorro."
            mensajeAdvertencia.ShowDialog()
        End If

        If idCajaAhorro > 0 And cmbNave.SelectedIndex > 0 Then
            entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(idCajaAhorro)

            Dim dtConcentrado As New DataTable
            dtConcentrado.TableName = "dtConcentrado"
            dtConcentrado = objBu.consultaDeduccionesPrestamosSemanas(DatePart(DateInterval.Year, CDate(entCajaAhorro.pFechaInicial)))
            Dim sumaD As Decimal
            Dim sumaP As Decimal


            Dim total As Integer
            Try
                'OBTENEMOS LA SUMA DE LA DEDUCCIONES
                sumaD = (From item In dtConcentrado.AsEnumerable()
                         Select item.Field(Of Decimal)("TOTALD")).Sum()
                'OBTENEMOS LA SUMA DE LOS PRESTAMOS 
                sumaP = (From item In dtConcentrado.AsEnumerable() Select item.Field(Of Decimal)("TOTALP")).Sum()

                total = CInt(sumaD - sumaP)
            Catch ex As Exception

            End Try



            If dtConcentrado.Rows.Count > 0 Then

                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim entReporte As New Entidades.Reportes
                'entReporte = objReporte.LeerReporteporClave("REPORTE_CONCENTRADO_CAJAAHORRO")
                entReporte = objReporte.LeerReporteporClave("NOM_REP_CAJA_VERT")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                reporte("nombreNave") = cmbNave.Text
                reporte("NombreReporte") = "SAY: REPORTE_CONCENTRADO_CAJAAHORRO.mrt"
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString

                Dim cadenaPeriodo As String = "DEL " + entCajaAhorro.pFechaInicial.ToShortDateString.ToString + " AL " + entCajaAhorro.pFechaFinal.ToShortDateString.ToString
                reporte("Periodo") = cadenaPeriodo
                Try
                    reporte("Total") = total
                Catch ex As Exception

                End Try


                reporte.Dictionary.Clear()
                reporte.RegData(dtConcentrado)
                reporte.Dictionary.Synchronize()
                reporte.Show()
                'dsDeduccionesCaja.Tables.Clear()

            End If
        End If

        'Catch ex As Exception
        '    Dim objMensaje As New Tools.AdvertenciaForm
        '    objMensaje.mensaje = "Vuelva a intentar."
        '    objMensaje.ShowDialog()
        'End Try
    End Sub

    Public Sub ejecutaReporteGanaInteres()
        grdIntereses.DataSource = Nothing
        Dim idCajaAhorro As Int32 = 0
        Dim reporteSemanasBU As New Negocios.ReporteCajaAhorroBU
        Dim listaSemanas As New List(Of Entidades.PeriodosNomina)
        Dim listaColaboradores As New List(Of Entidades.ColaboradorLaboral)

        If grdCajaAhorro.Rows.Count > 0 Then
            idCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Es necesario seleccionar una caja de ahorro."
            mensajeAdvertencia.ShowDialog()
        End If

        If idCajaAhorro > 0 And cmbNave.SelectedIndex > 0 Then
            Dim objCajaAhorroBU As New Negocios.CajaAhorroBU
            Dim entCajaAhorro As New Entidades.CajaAhorro
            Dim dtDetalles As New DataTable
            Dim semanasGanadas As DataTable
            Dim contador, cont, SemanasAhorradas, SemanasGanadasT As Int32
            Dim semanasPerdidas As Int32 = 0
            Dim banderaAgregarColSemanas As Boolean = False
            Dim banderaAgregarColTotales As Boolean = False

            dtDetalles.TableName = "dtDetalles"

            dtDetalles.Columns.Add("idColaborador")
            dtDetalles.Columns.Add("Colaborador")
            dtDetalles.Columns.Add("checa")

            dtDetalles = reporteSemanasBU.ConsultaColaboradoresCajaCierre2(idCajaAhorro)
            dtDetalles.Columns.Item(1).Caption = "Colaborador"
            contador = 3
            listaSemanas = reporteSemanasBU.ConsultaSemanasCaja(idCajaAhorro)

            For Each row As DataRow In dtDetalles.Rows
                Dim id As Int32
                cont = 0
                id = row.Item(0).ToString()
                semanasGanadas = reporteSemanasBU.consultaSemanasGanadasCol(id, idCajaAhorro.ToString)
                For Each semana As Entidades.PeriodosNomina In listaSemanas
                    If banderaAgregarColSemanas = False Then
                        dtDetalles.Columns.Add("Sem " + semana.PPeriodoId.ToString)
                        dtDetalles.Columns.Item(contador).Caption = semana.FechaInicio.ToShortDateString + " al " + semana.FechaFin.ToShortDateString
                        contador += 1
                        If contador - 3 = listaSemanas.Count Then
                            banderaAgregarColSemanas = True
                        End If
                    End If

                    Dim var1, var2 As String
                    Dim var3 As Int32

                    If cont >= semanasGanadas.Rows.Count Then
                        var1 = 0
                        var2 = 0
                        var3 = 0
                    Else
                        var1 = semanasGanadas.Rows(cont).Item("ccpc_PeriodoId").ToString
                        var2 = semanasGanadas.Rows(cont).Item("ccheck_caja_ahorro").ToString
                        var3 = CDec(semanasGanadas.Rows(cont).Item("ccpc_MontoAhorro").ToString)
                    End If

                    If var1 = semana.PPeriodoId.ToString And var2 = True And var3 > 0 Then
                        row.Item("Sem " + semana.PPeriodoId.ToString) = "SI"
                        cont = cont + 1
                    ElseIf var1 = semana.PPeriodoId And var2 = False And var3 > 0 Then
                        row.Item("Sem " + semana.PPeriodoId.ToString) = "NO"
                        cont = cont + 1
                    ElseIf var1 = semana.PPeriodoId And var2 = False And var3 = 0 Then
                        row.Item("Sem " + semana.PPeriodoId.ToString) = "-"
                        cont = cont + 1
                    ElseIf var1 = semana.PPeriodoId And var2 = True And var3 = 0 Then
                        row.Item("Sem " + semana.PPeriodoId.ToString) = "-"
                        cont = cont + 1
                    Else
                        row.Item("Sem " + semana.PPeriodoId.ToString) = "-"
                    End If
                Next

                If banderaAgregarColTotales = False Then
                    dtDetalles.Columns.Add("Semanas")
                    dtDetalles.Columns.Add("Ganadas")
                    dtDetalles.Columns.Add("Perdidas")
                    banderaAgregarColTotales = True
                End If
                SemanasAhorradas = reporteSemanasBU.CountSemanasAhorradas(row.Item(0).ToString(), idCajaAhorro)
                SemanasGanadasT = reporteSemanasBU.CountSemanasGanadas(row.Item(0).ToString(), idCajaAhorro, 1).ToString
                semanasPerdidas = reporteSemanasBU.CountSemanasGanadas(row.Item(0).ToString(), idCajaAhorro, 2)
                row.Item("Semanas") = SemanasAhorradas.ToString
                row.Item("Ganadas") = SemanasGanadasT.ToString
                row.Item("Perdidas") = semanasPerdidas.ToString
            Next

            entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(idCajaAhorro)

            If dtDetalles.Rows.Count > 0 Then
                grdIntereses.DataSource = dtDetalles
                grdIntereses.DisplayLayout.Bands(0).Columns(0).Hidden = True
                grdIntereses.DisplayLayout.Bands(0).Columns(2).Hidden = True
                grdIntereses.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

                If grdIntereses.Rows.Count > 0 Then

                    With grdIntereses.DisplayLayout.Bands(0)
                        .Columns("Semanas").CellAppearance.TextHAlign = HAlign.Right
                        .Columns("Ganadas").CellAppearance.TextHAlign = HAlign.Right
                        .Columns("Perdidas").CellAppearance.TextHAlign = HAlign.Right
                    End With
                    'Dim objReporte As New Framework.Negocios.ReportesBU
                    'Dim entReporte As New Entidades.Reportes
                    ''entReporte = objReporte.LeerReporteporClave("REP_NOM_DETALLADO_INTERESES")
                    'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    'My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
                    'Dim reporte As New StiReport
                    'reporte.Load(archivo)
                    'reporte.Compile()
                    'reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                    'reporte("nombreNave") = cmbNave.Text
                    'reporte("NombreReporte") = "SAY: REP_NOM_DETALLADO_INTERESES.mrt"
                    'reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                    Dim cadenaPeriodo As String = "DEL " + entCajaAhorro.pFechaInicial.ToShortDateString.ToString + " AL " + entCajaAhorro.pFechaFinal.ToShortDateString.ToString

                    '    reporte("Periodo") = cadenaPeriodo
                    '    reporte.Dictionary.Clear()
                    '    reporte.RegData(dtDetalles)
                    '    reporte.Dictionary.Synchronize()
                    '    reporte.Show()
                    Dim sfd As New SaveFileDialog
                    Dim ugde As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter()
                    sfd.DefaultExt = "pdf"
                    sfd.Filter = "PDF files (*.pdf)|*.pdf"
                    Dim result As DialogResult = sfd.ShowDialog()

                    If result = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim fileName As String = sfd.FileName
                        ugde.AutoSize = Infragistics.Win.UltraWinGrid.DocumentExport.AutoSize.SizeColumnsToContent
                        ugde.TargetPaperOrientation = PageOrientation.Landscape
                        ugde.TargetPaperSize = PageSizes.Legal
                        ugde.UseFileBuffer = True
                        Dim r As Report = New Report()

                        Dim sec As ISection = r.AddSection()
                        'Dim img As Infragistics.Documents.Reports.Graphics.Image = New Infragistics.Documents.Reports.Graphics.Image(Global.Ventas.Vista.My.Resources.Resources.yuyin)

                        Dim sectionHeader As Infragistics.Documents.Reports.Report.Section.ISectionHeader = sec.AddHeader()
                        sectionHeader.Repeat = True
                        sectionHeader.Height = 60

                        Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(0, 0)
                        sectionHeaderText.Paddings.Top = 30
                        sectionHeaderText.Paddings.Left = 20
                        sectionHeaderText.Alignment = New TextAlignment(Alignment.Left)
                        sectionHeaderText.AddContent("REPORTE DE SEMANAS GANADAS POR COLABORADOR")

                        sectionHeaderText = sectionHeader.AddText(0, 0)
                        sectionHeaderText.Paddings.Top = 30
                        sectionHeaderText.Alignment = New TextAlignment(Alignment.Center)
                        sectionHeaderText.AddContent(cadenaPeriodo)

                        sectionHeaderText.Borders =
                        New Borders(New Pen(Colors.Black, 3, DashStyle.Solid), 10)

                        'sectionHeaderTextPeriodo.Borders = _
                        'New Borders(New Pen(Colors.Black, 3, DashStyle.Solid), 10)

                        ' Add 5 pixels of padding on the left and right.
                        'sectionHeaderText.Paddings.Horizontal = 20

                        'Dim sectionHeaderDate As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(0, 0)
                        'sectionHeaderDate.Paddings.Top = 60
                        'sectionHeaderDate.Alignment = New TextAlignment(Alignment.Left)
                        'sectionHeaderDate.AddContent(DateTime.Now.ToString("d"))

                        Dim sectionFooter As Infragistics.Documents.Reports.Report.Section.ISectionFooter = sec.AddFooter()
                        sectionFooter.Repeat = True
                        sectionFooter.Height = 60

                        Dim footerNombreReporte As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
                        footerNombreReporte.Alignment = New TextAlignment(Alignment.Left)
                        footerNombreReporte.AddContent("REPORTE DE SEMANAS GANADAS POR COLABORADOR")

                        Dim footerPagina As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
                        footerPagina.Alignment = New TextAlignment(Alignment.Center)
                        footerPagina.AddContent("Página: ")
                        footerPagina.AddPageNumber(PageNumberFormat.Decimal)

                        Dim footerUsuario As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
                        footerUsuario.Alignment = New TextAlignment(Alignment.Right)
                        footerUsuario.AddContent(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)

                        ugde.Export(grdIntereses, sec)
                        Me.Cursor = Cursors.Default
                        MsgBox("Se exportó correctamente.", MsgBoxStyle.Information, "")
                        Try
                            r.Publish(fileName, FileFormat.PDF)
                            Process.Start(fileName)
                        Catch ex As Exception
                            Me.Cursor = Cursors.Default
                            MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento PDF " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
                        End Try
                    End If
                Else
                    MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
                End If
            End If
        End If
    End Sub

    Public Sub ejecutarReporteCartaCajaAhorro()
        Try
            If cmbNave.SelectedIndex > 0 Then
                Dim objCajaAhorroBU As New Negocios.CajaAhorroBU
                Dim dttCajaAhorro As New DataTable

                Dim dsDeduccionesCaja As New DataSet
                Dim dtDeduccionesReporte As New DataTable
                Dim dtMesesAnio As New DataTable


                dttCajaAhorro = objCajaAhorroBU.consultaCajaAhorroActual(cmbNave.SelectedValue)
                If dttCajaAhorro.Rows.Count > 0 Then
                    dsDeduccionesCaja.Tables.Add(dtDeduccionesReporte)
                    dsDeduccionesCaja.Tables.Add(dtMesesAnio)
                    Dim objReporte As New Framework.Negocios.ReportesBU
                    Dim entReporte As New Entidades.Reportes
                    entReporte = objReporte.LeerReporteporClave("CARTA_CAJA_AHORRO")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                    reporte("nombreNave") = cmbNave.Text
                    reporte("NombreReporte") = "SAY: CARTA_CAJA_AHORRO.mrt"
                    reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                    Dim cadenaPeriodo As String = "del " + dttCajaAhorro.Rows(0).Item("AnioInicio").ToString + " a " + dttCajaAhorro.Rows(0).Item("AnioFin").ToString
                    reporte("anios") = cadenaPeriodo
                    Dim fechainicioCA As Date = dttCajaAhorro.Rows(0).Item("caja_FechaInicial").ToString
                    Dim fechafinCA As Date = dttCajaAhorro.Rows(0).Item("caja_FechaFinal").ToString
                    Dim diaInicio As String = fechainicioCA.Day.ToString
                    Dim diaFin As String = fechafinCA.Day.ToString
                    Dim diaHoy As String = Date.Now.Day.ToString
                    Dim mesInicio As String = fechainicioCA.Month.ToString
                    Dim mesFin As String = fechafinCA.Month.ToString
                    Dim meshoy As String = Date.Now.Month.ToString
                    Dim anioInicio As String = fechainicioCA.Year.ToString
                    Dim anioFin As String = fechafinCA.Year.ToString
                    If diaInicio.Length = 1 Then
                        diaInicio = "0" + diaInicio
                    End If
                    If diaFin.Length = 1 Then
                        diaFin = "0" + diaFin
                    End If
                    If diaHoy.Length = 1 Then
                        diaHoy = "0" + diaHoy
                    End If
                    If mesInicio = "1" Then
                        mesInicio = "Enero"
                    ElseIf mesInicio = "2" Then
                        mesInicio = "Febrero"
                    ElseIf mesInicio = "3" Then
                        mesInicio = "Marzo"
                    ElseIf mesInicio = "4" Then
                        mesInicio = "Abril"
                    ElseIf mesInicio = "5" Then
                        mesInicio = "Mayo"
                    ElseIf mesInicio = "6" Then
                        mesInicio = "Junio"
                    ElseIf mesInicio = "7" Then
                        mesInicio = "Julio"
                    ElseIf mesInicio = "8" Then
                        mesInicio = "Agosto"
                    ElseIf mesInicio = "9" Then
                        mesInicio = "Septiembre"
                    ElseIf mesInicio = "10" Then
                        mesInicio = "Octubre"
                    ElseIf mesInicio = "11" Then
                        mesInicio = "Noviembre"
                    ElseIf mesInicio = "12" Then
                        mesInicio = "Diciembre"
                    End If

                    If mesFin = "1" Then
                        mesFin = "Enero"
                    ElseIf mesFin = "2" Then
                        mesFin = "Febrero"
                    ElseIf mesFin = "3" Then
                        mesFin = "Marzo"
                    ElseIf mesFin = "4" Then
                        mesFin = "Abril"
                    ElseIf mesFin = "5" Then
                        mesFin = "Mayo"
                    ElseIf mesFin = "6" Then
                        mesFin = "Junio"
                    ElseIf mesFin = "7" Then
                        mesFin = "Julio"
                    ElseIf mesFin = "8" Then
                        mesFin = "Agosto"
                    ElseIf mesFin = "9" Then
                        mesFin = "Septiembre"
                    ElseIf mesFin = "10" Then
                        mesFin = "Octubre"
                    ElseIf mesFin = "11" Then
                        mesFin = "Noviembre"
                    ElseIf mesFin = "12" Then
                        mesFin = "Diciembre"
                    End If

                    If meshoy = "1" Then
                        meshoy = "Enero"
                    ElseIf meshoy = "2" Then
                        meshoy = "Febrero"
                    ElseIf meshoy = "3" Then
                        meshoy = "Marzo"
                    ElseIf meshoy = "4" Then
                        meshoy = "Abril"
                    ElseIf meshoy = "5" Then
                        meshoy = "Mayo"
                    ElseIf meshoy = "6" Then
                        meshoy = "Junio"
                    ElseIf meshoy = "7" Then
                        meshoy = "Julio"
                    ElseIf meshoy = "8" Then
                        meshoy = "Agosto"
                    ElseIf meshoy = "9" Then
                        meshoy = "Septiembre"
                    ElseIf meshoy = "10" Then
                        meshoy = "Octubre"
                    ElseIf meshoy = "11" Then
                        meshoy = "Noviembre"
                    ElseIf meshoy = "12" Then
                        meshoy = "Diciembre"
                    End If

                    If anioInicio.Length = 1 Then
                        anioInicio = "0" + anioInicio
                    End If

                    If anioFin.Length = 1 Then
                        anioFin = "0" + anioFin
                    End If

                    reporte("comenzara") = "1. Comenzará el " + diaInicio + " de " + mesInicio + " del " + anioInicio + " al " + diaFin + " de " + mesFin + " del " + anioFin + "."
                    reporte("totalsemanas") = "2. El total de semanas a ahorrar será de " + dttCajaAhorro.Rows(0).Item("Semanas").ToString + "."
                    reporte("terminara") = mesFin + " del " + anioFin + "."
                    reporte("fechadeldia") = diaHoy + " de " + meshoy + " de " + Date.Now.Year.ToString

                    reporte.Dictionary.Clear()
                    reporte.RegData(dsDeduccionesCaja)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()
                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "Nave sin caja de ahorro."
                    objMensaje.ShowDialog()
                End If
                'dsDeduccionesCaja.Tables.Clear()
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Seleccione una nave."
                objMensaje.ShowDialog()
            End If

        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Seleccione una nave."
            objMensaje.ShowDialog()
        End Try
    End Sub

    Public Sub ejecutarReporteDeducciones()
        Try


            Dim objCajaAhorroBU As New Negocios.CajaAhorroBU
            Dim objDeduccionesBU As New Negocios.DeduccionesBU

            Dim entCajaAhorro As New Entidades.CajaAhorro
            Dim entCajaAhorroAnterior As New Entidades.CajaAhorro
            Dim dtDeduccionesReporteAnterior As New DataTable

            Dim dsDeduccionesCaja As New DataSet
            Dim dtDeduccionesReporte As New DataTable
            Dim dtMesesAnio As New DataTable

            Dim idCajaAhorro As Int32 = 0

            If grdCajaAhorro.Rows.Count > 0 Then
                idCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")
            Else
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Es necesario seleccionar una caja de ahorro."
                mensajeAdvertencia.ShowDialog()
            End If
            If idCajaAhorro > 0 And cmbNave.SelectedIndex > 0 Then
                Dim claveReporte As String = "NOM_REP_DECUCCIONES_N"
                Dim nombreReporte As String = "SAY: REPORTE DEDUCCIONES NUEVO.mrt"
                Dim dtSaldosPresCaja As New DataTable
                Dim SaldoIniPres As Decimal = 0.0
                Dim SaldoCambioNave As Decimal = 0.0
                Dim SaldoDescontadoBajas As Decimal = 0.0
                Dim AbonosCambioNave As Decimal = 0.0
                Dim RegresadoFinanzas As Integer = 0
                Dim TotalAbonoPrestamos As Integer = 0

                dtSaldosPresCaja = objCajaAhorroBU.obtenerSaldosPrestamosCaja(idCajaAhorro)
                If Not dtSaldosPresCaja Is Nothing AndAlso dtSaldosPresCaja.Rows.Count > 0 Then
                    SaldoIniPres = CDec(dtSaldosPresCaja.Rows(0).Item("SaldoIniPres"))
                    SaldoCambioNave = CDec(dtSaldosPresCaja.Rows(0).Item("SaldoCambioNave"))
                    SaldoDescontadoBajas = CDec(dtSaldosPresCaja.Rows(0).Item("SaldoDescontadoBajas"))
                    AbonosCambioNave = CDec(dtSaldosPresCaja.Rows(0).Item("AbonosCambioNave"))
                    RegresadoFinanzas = CInt(dtSaldosPresCaja.Rows(0).Item("RegresadoFinanzas"))
                    TotalAbonoPrestamos = CInt(dtSaldosPresCaja.Rows(0).Item("TotalAbonoPrestamos"))

                    If SaldoIniPres < 0 Then
                        SaldoIniPres = 0
                    End If
                End If

                entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(idCajaAhorro)
                dtDeduccionesReporte = objDeduccionesBU.consultaReporteDeducciones(cmbNave.SelectedValue, entCajaAhorro.pFechaInicialDeducciones.ToShortDateString, entCajaAhorro.PFechaFinalDeducciones.ToShortDateString, entCajaAhorro.pCajaAhorroId, Year(entCajaAhorro.pFechaInicial))
                dtDeduccionesReporte.TableName = "dtDeduccionesReporte"

                'Obtener los saldos de la caja anterior Para sacar los saldos con los que se serró
                entCajaAhorroAnterior = objCajaAhorroBU.ObtenerCajaAhorroAnterior(idCajaAhorro)
                dtDeduccionesReporteAnterior = objDeduccionesBU.consultaReporteDeduccionesAnterior(cmbNave.SelectedValue, entCajaAhorroAnterior.pFechaInicialDeducciones.ToShortDateString, entCajaAhorroAnterior.PFechaFinalDeducciones.ToShortDateString, entCajaAhorroAnterior.pCajaAhorroId, Year(entCajaAhorro.pFechaInicial))

                ''SALDO INICIAL= SUM(SALDO) -MONTO ACOMULADO + AbonoCajaTotal - totalInterese
                Dim SaldoInicial As Integer = 0
                Try
                    Dim saldoFinal = dtDeduccionesReporteAnterior.AsEnumerable.Sum(Function(x) x.Field(Of Decimal)("Saldo"))
                    Dim montoAcomulado = CInt(dtDeduccionesReporteAnterior.Rows(0)("montoacumulado"))
                    Dim AbonoCajaTotal = CInt(dtDeduccionesReporteAnterior.Rows(0)("AbonoCajaTotal"))
                    Dim totalIntereses = CInt(dtDeduccionesReporteAnterior.Rows(0)("totalintereses"))
                    'If dtDeduccionesReporteAnterior.Rows(0).Item("AÑO") < 2020 Then
                    '    SaldoInicial = 0
                    'Else
                    '    SaldoInicial = saldoFinal - montoAcomulado + AbonoCajaTotal - totalIntereses
                    '    If SaldoInicial < 0 Then
                    '        SaldoInicial = 0
                    '    End If

                    'End If

                    SaldoInicial = 0


                Catch ex As Exception

                End Try

                ''SALDO Final= SUM(SALDO) -MONTO ACOMULADO + AbonoCajaTotal - totalInterese
                Dim SaldoFinalPrestamo As Integer = 0
                Try
                    Dim saldoFinal2 = dtDeduccionesReporte.AsEnumerable.Sum(Function(x) x.Field(Of Decimal)("Saldo"))
                    Dim montoAcomulado = CInt(dtDeduccionesReporte.Rows(0)("montoacumulado"))
                    Dim AbonoCajaTotal = CInt(dtDeduccionesReporte.Rows(0)("AbonoCajaTotal"))
                    Dim totalIntereses = CInt(dtDeduccionesReporte.Rows(0)("totalintereses"))
                    SaldoFinalPrestamo = saldoFinal2 - montoAcomulado + AbonoCajaTotal - totalIntereses
                    If SaldoFinalPrestamo < 0 Then
                        SaldoFinalPrestamo = 0
                    End If
                Catch ex As Exception

                End Try



                If Year(entCajaAhorro.pFechaInicial) < 2019 Then
                    claveReporte = "NOM_REP_DECUCCIONES"
                    nombreReporte = "SAY: REPORTE DEDUCCIONES.mrt"
                End If

                dtMesesAnio = objDeduccionesBU.consultaMesesPeriodoCaja(cmbNave.SelectedValue, entCajaAhorro.pFechaInicialDeducciones.ToShortDateString, entCajaAhorro.PFechaFinalDeducciones.ToShortDateString)
                dtMesesAnio.TableName = "dtMesesAnio"

                dsDeduccionesCaja.Tables.Add(dtDeduccionesReporte)
                dsDeduccionesCaja.Tables.Add(dtMesesAnio)

                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim entReporte As New Entidades.Reportes
                entReporte = objReporte.LeerReporteporClave(claveReporte)
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("SaldoIniPrestamo") = SaldoIniPres
                reporte("SaldoCambioNave") = SaldoCambioNave
                reporte("SaldoDescontadoBajas") = SaldoDescontadoBajas
                reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                reporte("nombreNave") = cmbNave.Text
                reporte("NombreReporte") = nombreReporte
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("SaldoInicial") = SaldoInicial
                reporte("SaldoFinal") = SaldoFinalPrestamo
                reporte("AbonosCambioNave") = AbonosCambioNave
                reporte("RegresadoFinanzas") = RegresadoFinanzas
                reporte("TotalAbonoPrestamos") = TotalAbonoPrestamos

                Dim cadenaPeriodo As String = "DEL " + entCajaAhorro.pFechaInicialDeducciones.ToShortDateString.ToString + " AL " + entCajaAhorro.PFechaFinalDeducciones.ToShortDateString.ToString
                reporte("Periodo") = cadenaPeriodo


                reporte.Dictionary.Clear()
                reporte.RegData(dsDeduccionesCaja)
                reporte.Dictionary.Synchronize()
                reporte.Show()
                'dsDeduccionesCaja.Tables.Clear()

            End If

        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Vuelva a intentar."
            objMensaje.ShowDialog()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click

        If cmbNave.SelectedIndex > 0 Then

            Dim AltaForm As New AltaPeriodoCajaForm
            AltaForm.IdNave = cmbNave.SelectedValue
            AltaForm.ShowDialog()
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar una nave para dar de alta una caja de ahorro."
            mensajeAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim EditarForm As New EditarPeriodoCajaForm

        If grdCajaAhorro.Rows.Count <= 1 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar una caja de ahorro para editar."
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If


        EditarForm.IdCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")
        EditarForm.strEstado = grdCajaAhorro(grdCajaAhorro.Row, "Estatus")

        EditarForm.ShowDialog()
    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grCajaAhorro.Height = 104
    End Sub

    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        grCajaAhorro.Height = 45
    End Sub

    Private Sub CajaAhorroForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Inicializar()
        grdCajaAhorro.Styles.EmptyArea.BackColor = System.Drawing.Color.LightSteelBlue

        'BUSCA PERMISOS PARA MOSTRAR EL BOTON DE CIERRE ANUAL
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAJA_CAJA", "ANUAL") Then
            btnCierreAnual.Visible = True
            lblCierreAnual1.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAJA_CAJA", "BOTONREPORTE_DEDUCCIONES") Then
            btnImprimir.Visible = True
            lblReporteDeducciones.Visible = True
            btnAyuda.Visible = True
            lblAyuda.Visible = True
        Else
            btnImprimir.Visible = False
            lblReporteDeducciones.Visible = False
            btnAyuda.Visible = False
            lblAyuda.Visible = False
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAJA_CAJA", "RPT_CONCENTRADO_CAJAAHORRO") Then
            ReporteConcentradoCajaAhorroTool.Visible = True
        End If

    End Sub

    Private Sub Inicializar()


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAJA_CAJA", "NOM_ASIST_CAJA") Then
            AsistenteCaja = 1
        End If

        If AsistenteCaja = True Then
            Dim objBU As New Negocios.CajaAhorroBU
            Dim dtNavesAsignadas As New DataTable
            dtNavesAsignadas = objBU.NavesAsignadasAsistenteCaja()
            dtNavesAsignadas.Rows.InsertAt(dtNavesAsignadas.NewRow, 0)
            cmbNave.DataSource = dtNavesAsignadas
            cmbNave.DisplayMember = "NaveNombre"
            cmbNave.ValueMember = "NaveID"
            cmbNave.SelectedIndex = 1
        Else
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            If cmbNave.Items.Count = 1 Then
                cmbNave.SelectedIndex = 1
            End If
        End If

        Tools.Controles.ComboEstatusCajaAhorro(cmbEstatus)

        'grdReporteCajaAhorro(0, "Ahorro") = "TOTAL SEMANAS DE:"

        grdCajaAhorro.Cols(0).Name = "vacio"
        grdCajaAhorro.Cols(1).Name = "Id"
        grdCajaAhorro.Cols(2).Name = "Concepto"
        grdCajaAhorro.Cols(3).Name = "Estatus"


    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click

        grdCajaAhorro.Rows.Count = 1
        cmbNave.Text = ""
        cmbEstatus.Text = ""

    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click



        grdCajaAhorro.Rows.Count = 1

        If cmbNave.SelectedIndex <= 0 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar una nave para ver sus cajas de ahorro."
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If

        If cmbEstatus.SelectedIndex < 0 And cmbEstatus.Text <> String.Empty Then
            Exit Sub
        End If



        Dim objCajaAhorro As New List(Of Entidades.CajaAhorro)
        Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU

        Dim strEstatus As String = String.Empty



        If cmbEstatus.SelectedValue Is Nothing Then
            strEstatus = String.Empty
        Else
            If cmbEstatus.SelectedValue.Equals(System.DBNull.Value) = True Then
                strEstatus = String.Empty
            Else
                strEstatus = cmbEstatus.SelectedValue.ToString
            End If
        End If


        objCajaAhorro = objCajaAhorroBU.Listar(cmbNave.SelectedValue, strEstatus)

        For Each caja As Entidades.CajaAhorro In objCajaAhorro
            AgregarFila(caja)

        Next



    End Sub

    Public Sub AgregarFila(ByVal caja As Entidades.CajaAhorro)

        grdCajaAhorro.AddItem("" & vbTab & caja.pCajaAhorroId & ControlChars.Tab & caja.pConcepto & ControlChars.Tab & caja.pDescripcionEstado.ToUpper)

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        grdCajaAhorro.Rows.Count = 1
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbEstatus.SelectedIndexChanged
        grdCajaAhorro.Rows.Count = 1
    End Sub

    Private Sub btnConfiguracion_Click(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.Click

        Dim ConfiguracionForm As New ConfiguracionForm

        If grdCajaAhorro.Rows.Count <= 1 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar una caja de ahorro para configurarla."
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If



        ConfiguracionForm.IdCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")

        ConfiguracionForm.Nave = cmbNave.Text
        ConfiguracionForm.Periodo = grdCajaAhorro(grdCajaAhorro.Row, "Concepto")

        ConfiguracionForm.ShowDialog()



    End Sub

    Private Sub btnAsignar_Click(sender As System.Object, e As System.EventArgs) Handles btnAsignar.Click
        'Hacer todo esto solo si hay una caja ACTIVA seleccionada

        If grdCajaAhorro.Rows.Count <= 1 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar una caja de ahorro para asignar colaboradores."
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If


        Dim idCajaAhorro As Integer = 0
        idCajaAhorro = CInt(grdCajaAhorro(grdCajaAhorro.Row, 1))

        Dim nombreCaja As String
        nombreCaja = (grdCajaAhorro(grdCajaAhorro.Row, 2)).ToString

        Dim CajaColaborador As New ListaCajaDeAhorroColaboradorForm
        CajaColaborador.MdiParent = Me.MdiParent
        CajaColaborador.nave = cmbNave.SelectedItem

        CajaColaborador.cajaAhorroId = idCajaAhorro
        CajaColaborador.nombrecaja = nombreCaja
        'idCajaAhorro = (()).ToString
        CajaColaborador.Show()


    End Sub

    Private Sub grdCajaAhorro_Click(sender As System.Object, e As System.EventArgs) Handles grdCajaAhorro.Click

    End Sub

    Private Sub btnCierreSemanal_Click(sender As System.Object, e As System.EventArgs) Handles btnCierreSemanal.Click


        Dim CierreSemanalForm As New CierreSemanalForm

        If grdCajaAhorro.Rows.Count <= 1 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar una caja de ahorro para cerrar la semana."
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If


        'If grdCajaAhorro(grdCajaAhorro.Row, "Estatus") <> "Activa" Then
        '    Dim mensajeAdvertencia As New AdvertenciaForm
        '    mensajeAdvertencia.mensaje = "Solo puedes hacer el cierre de una caja de ahorro ACTIVA."
        '    mensajeAdvertencia.ShowDialog()
        '    Exit Sub
        'End If

        Dim objColaboradorPeriodoCajaBU As New Nomina.Negocios.ColaboradorPeriodoCajaBU

        objColaboradorPeriodoCajaBU.VerificaExistenciaColaboradores(grdCajaAhorro(grdCajaAhorro.Row, "Id"))

        If objColaboradorPeriodoCajaBU.Resultado.Length > 0 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = objColaboradorPeriodoCajaBU.Resultado.ToString
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If


        objColaboradorPeriodoCajaBU.VerificaExistenciaCierre(grdCajaAhorro(grdCajaAhorro.Row, "Id"))

        If objColaboradorPeriodoCajaBU.Resultado.Length > 0 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = objColaboradorPeriodoCajaBU.Resultado.ToString
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If

        CierreSemanalForm.IdCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")
        CierreSemanalForm.MdiParent = Me.MdiParent
        CierreSemanalForm.Nave = cmbNave.SelectedValue 'cmbNave.Text
        CierreSemanalForm.Periodo = grdCajaAhorro(grdCajaAhorro.Row, "Concepto")

        CierreSemanalForm.Show()

    End Sub

    Private Sub CajaAhorroForm_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Enter And Not (e.Alt Or e.Control) Then
            If Me.ActiveControl.GetType Is GetType(TextBox) Or Me.ActiveControl.GetType Is GetType(CheckBox) Or Me.ActiveControl.GetType Is GetType(DateTimePicker) Or Me.ActiveControl.GetType Is GetType(ComboBox) Then
                If e.Shift Then
                    Me.ProcessTabKey(False)
                Else
                    Me.ProcessTabKey(True)
                End If
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(sender As System.Object, e As System.EventArgs) Handles btnReporte.Click

        Dim CierreAnualForm As New ReporteCajaForm

        If grdCajaAhorro.Rows.Count <= 1 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar una caja de ahorro."
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If

        CierreAnualForm.IdCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")
        CierreAnualForm.Nave = cmbNave.Text
        CierreAnualForm.Periodo = grdCajaAhorro(grdCajaAhorro.Row, "Concepto")
        CierreAnualForm.Estatus = grdCajaAhorro(grdCajaAhorro.Row, "Estatus")


        CierreAnualForm.btnCerrar.Visible = False
        CierreAnualForm.lblAccionCierreAnual.Visible = False

        CierreAnualForm.ShowDialog()


    End Sub

    Private Sub btnCierreAnual_Click(sender As System.Object, e As System.EventArgs) Handles btnCierreAnual.Click

        If cmbNave.SelectedIndex > 0 Then

            If grdCajaAhorro.Rows.Count <= 1 Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Debe seleccionar una caja de ahorro para hacer el cierre."
                mensajeAdvertencia.ShowDialog()
                Exit Sub
            End If


            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "Esta operación puede tardar algunos minutos, ¿Desea continuar?"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                If grdCajaAhorro(grdCajaAhorro.Row, "Estatus").ToString = "ACTIVA" Then
                    Dim CierreAnualForm As New ReporteCajaForm
                    CierreAnualForm.IdCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")
                    CierreAnualForm.Nave = cmbNave.Text
                    CierreAnualForm.Periodo = grdCajaAhorro(grdCajaAhorro.Row, "Concepto")
                    CierreAnualForm.Estatus = grdCajaAhorro(grdCajaAhorro.Row, "Estatus")
                    'CierreAnualForm.btnCerrar.Location = New Point(33, 12)
                    'CierreAnualForm.lblAccionCierreAnual.Location = New Point(32, 47)
                    CierreAnualForm.ShowDialog()
                Else
                    Dim objCierreAnualCerrada As New frmConsultaCierreAnualCerrada
                    objCierreAnualCerrada.idCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")
                    objCierreAnualCerrada.idNave = cmbNave.SelectedValue
                    objCierreAnualCerrada.nombreNave = cmbNave.Text
                    objCierreAnualCerrada.cajaDeAl = grdCajaAhorro(grdCajaAhorro.Row, "Concepto")
                    objCierreAnualCerrada.ShowDialog()
                End If
            End If
        Else

            Dim mensajeAdv As New AdvertenciaForm
            mensajeAdv.mensaje = "Debe seleccionar una nave."
            mensajeAdv.ShowDialog()
        End If

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnReporteCS.Click
        Dim CierreSemanalForm As New ReporteCierreSemanalForm 'CierreSemanalForm

        If grdCajaAhorro.Rows.Count <= 1 Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar una caja de ahorro para consulta."
            mensajeAdvertencia.ShowDialog()
            Exit Sub
        End If


        CierreSemanalForm.IdCajaAhorro = grdCajaAhorro(grdCajaAhorro.Row, "Id")

        CierreSemanalForm.Nave = cmbNave.Text
        CierreSemanalForm.Periodo = grdCajaAhorro(grdCajaAhorro.Row, "Concepto")

        CierreSemanalForm.ShowDialog()
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnReporteDeducciones_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        menuImprimir.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub

    Private Sub DeduccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeduccionesToolStripMenuItem.Click
        ejecutarReporteDeducciones()
    End Sub

    Private Sub CartaCajaDeAhorroToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ejecutarReporteCartaCajaAhorro()
    End Sub

    Private Sub ReporteAnualDeCajaDeAhorroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteAnualDeCajaDeAhorroToolStripMenuItem.Click

        ejecutaReporteGanaInteres()

    End Sub

    Private Sub grdIntereses_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdIntereses.InitializeLayout


        ' Set the default rotation of all column headers in the first band.
        Me.grdIntereses.DisplayLayout.Bands(0).Override.ColumnHeaderTextOrientation =
         TextOrientationInfo.HorizontalNegative90Degrees


        '' Set a custom text orientation on the first column header in the first band.
        Me.grdIntereses.DisplayLayout.Bands(0).Columns(1).Header.TextOrientation =
         TextOrientationInfo.Horizontal


        ' Show the first band's header and rotate the text 23 degrees
        'Me.grdIntereses.DisplayLayout.Bands(0).HeaderVisible = True
        'Me.grdIntereses.DisplayLayout.Bands(0).Header.Caption = "Que hay"
        'Me.grdIntereses.DisplayLayout.Bands(0).Header.TextOrientation = _
        ' New TextOrientationInfo(90, TextFlowDirection.Horizontal)


        ' Add both columns in a child band to a group.
        'Dim group As UltraGridGroup = Me.grdIntereses.DisplayLayout.Bands(1).Groups.Add()
        'group.Header.Caption = "Group 1"
        'group.Columns.Add(Me.grdIntereses.DisplayLayout.Bands(1).Columns(0))
        'group.Columns.Add(Me.grdIntereses.DisplayLayout.Bands(1).Columns(1))

        ' Rotate all group headers in the grid 90 degrees.
        'Me.grdIntereses.DisplayLayout.Override.GroupHeaderTextOrientation = _
        ' TextOrientationInfo.Horizontal90Degrees
    End Sub


    Private Sub ReporteConcentradoCajaAhorroTool_Click(sender As Object, e As EventArgs) Handles ReporteConcentradoCajaAhorroTool.Click
        ejecutarReporteConcentrado()
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyudaReportes.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaReporteGeneralDeDeduccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaReporteGeneralDeDeduccionesToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Nomina/", "Descargas\Manuales\Nomina", "COVE_MAUS_ReporteGeneralDeducciones_CajaAhorro_V1.pdf")
            Process.Start("Descargas\Manuales\Nomina\COVE_MAUS_ReporteGeneralDeducciones_CajaAhorro_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaReporteConcentradoCajaDeAhorroToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Nomina/", "Descargas\Manuales\Nomina", "COVE_MAUS_ReporteConcentrado_CajaAhorro_V1.pdf")
            Process.Start("Descargas\Manuales\Nomina\COVE_MAUS_ReporteConcentrado_CajaAhorro_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ReporteConcentradoPréstamosEInteresesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteConcentradoPréstamosEInteresesToolStripMenuItem.Click
        ImprimirReporteConcentradoPrestamoseIntereses()
    End Sub

    Public Sub ImprimirReporteConcentradoPrestamoseIntereses()
        Dim objPrestamosBU As New Negocios.ConsultarPrestamosBU
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim PrestamosNomina As New DataSet("Prestamos Nomina")
        Dim dtPrestamos As New DataTable("Prestamos")
        Dim NaveID As Integer = cmbNave.SelectedValue

        'dtPrestamos = objPrestamosBU.ImprimirReporteConcentradoPrestamoseIntereses(NaveID)
        dtPrestamos = objPrestamosBU.ImprimirReportePrestamosIntereses(NaveID, 0)

        PrestamosNomina.DataSetName = "Prestamos"

        dtPrestamos.TableName = "Prestamos"

        ''RESUMEN
        Dim dtSaldosAbonosExtraordinarios As New DataTable
        Dim SaldoAbonoExtraordinario As Integer = 0
        Dim InteresAbonoExtraordinario As Integer = 0
        Dim SaldoCierreCaja As Integer = 0

        dtSaldosAbonosExtraordinarios = objPrestamosBU.obtenerSaldosPrestamosExtraordinariosCaja(0, NaveID)
        If Not dtSaldosAbonosExtraordinarios Is Nothing AndAlso dtSaldosAbonosExtraordinarios.Rows.Count > 0 Then
            SaldoAbonoExtraordinario = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("SaldoAbonoExtraordinario"))
            InteresAbonoExtraordinario = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("InteresAbonoExtraordinario"))
            SaldoCierreCaja = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("SaldoCierreCaja"))
        End If

        Dim TotalSaldoPrestamos As Int32
        Dim SaldoInicalPrestamosI As Int32
        Dim SaldoFinalInteresesT As Int32
        Dim anio As Int32
        If dtPrestamos.Rows.Count > 0 Then
            TotalSaldoPrestamos = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
                                                        Select(Function(y) y.Item("TotalSaldoPrestamos")).First
            SaldoInicalPrestamosI = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
                                                        Select(Function(y) y.Item("SaldoInicial")).First
            SaldoFinalInteresesT = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
                                                        Select(Function(y) y.Item("TotalSaldoIntereses")).First
            anio = dtPrestamos.AsEnumerable.Where(Function(x) x.Item("Consecutivo")).
                                                            Select(Function(y) y.Item("Año")).First
        End If

        If dtPrestamos.Rows.Count > 0 Then
            PrestamosNomina.Tables.Add(dtPrestamos)
            Try
                Dim objBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = objBU.LeerReporteporClave("RPT_PRES_INTERESES_N")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre.Trim + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("Nave") = cmbNave.Text
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave((Int(cmbNave.SelectedValue)))
                ''Resumen
                reporte("Anio") = anio + 1
                reporte("TotalSaldoPrestamos") = TotalSaldoPrestamos
                reporte("SaldoFinalInteresesT") = SaldoFinalInteresesT
                reporte("AbonosExtraordinarios") = SaldoAbonoExtraordinario
                reporte("IntereseExtraordinarios") = InteresAbonoExtraordinario
                reporte("SaldoFinal") = TotalSaldoPrestamos - SaldoCierreCaja
                reporte("SaldoFinalIntereses") = SaldoFinalInteresesT - InteresAbonoExtraordinario
                reporte("SaldoCierreCaja") = SaldoCierreCaja

                reporte.Dictionary.Clear()
                reporte.RegData(PrestamosNomina)
                reporte.Dictionary.Synchronize()
                reporte.Show()

                Me.Cursor = Cursors.Default
            Catch ex As Exception

            End Try
        Else
            vAdvertenciaForm.Text = "Préstamos"
            vAdvertenciaForm.mensaje = "No hay información para imprimir."
            vAdvertenciaForm.Show()
        End If
        'Dim objPrestamosBU As New Negocios.ConsultarPrestamosBU
        'Dim vAdvertenciaForm As New AdvertenciaForm
        'Dim PrestamosNomina As New DataSet("Prestamos Nomina")
        'Dim dtPrestamos As New DataTable("Prestamos")
        'Dim dtAbononosExtraordinario As New DataTable("Abonos")
        'Dim NaveID As Integer = cmbNave.SelectedValue
        'Dim CajaId As Integer = 0

        'If grdCajaAhorro.Rows.Count > 0 AndAlso grdCajaAhorro.Row > 0 Then
        '    CajaId = grdCajaAhorro(grdCajaAhorro.Row, "Id")
        'Else

        '    Dim mensajeAdvertencia As New AdvertenciaForm
        '    mensajeAdvertencia.mensaje = "Es necesario seleccionar una caja de ahorro."
        '    mensajeAdvertencia.ShowDialog()

        'End If

        'If CajaId > 0 Then

        '    Dim dtSaldosAbonosExtraordinarios As New DataTable
        '    Dim dtSaldosalCierredeCaja As New DataTable
        '    'Dim SaldoInicial As Integer = 0
        '    Dim SaldoAbonoExtraordinario As Integer = 0
        '    Dim InteresAbonoExtraordinario As Integer = 0
        '    Dim SaldoCierreCaja As Integer = 0
        '    Dim InteresCierreCaja As Integer = 0
        '    Dim SaldoCierreCajaTotal As Integer = 0
        '    Dim InteresCierreCajaTotal As Integer = 0


        '    dtSaldosAbonosExtraordinarios = objPrestamosBU.obtenerSaldosPrestamosExtraordinariosCaja(CajaId, NaveID)
        '    If Not dtSaldosAbonosExtraordinarios Is Nothing AndAlso dtSaldosAbonosExtraordinarios.Rows.Count > 0 Then
        '        'SaldoInicial = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("SaldoInicial"))
        '        SaldoAbonoExtraordinario = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("SaldoAbonoExtraordinario"))
        '        InteresAbonoExtraordinario = CDec(dtSaldosAbonosExtraordinarios.Rows(0).Item("InteresAbonoExtraordinario"))
        '    End If

        '    dtSaldosalCierredeCaja = objPrestamosBU.obtenerSaldosCierreCaja(CajaId, NaveID)
        '    If dtSaldosalCierredeCaja.Rows(0).Item("CajaActiva") = "C" Then

        '        If Not dtSaldosalCierredeCaja Is Nothing AndAlso dtSaldosalCierredeCaja.Rows.Count > 0 Then
        '            SaldoCierreCaja = CDec(dtSaldosalCierredeCaja.Rows(0).Item("SaldoAbonoExtraordinarioCierre"))
        '            InteresCierreCaja = CDec(dtSaldosalCierredeCaja.Rows(0).Item("InteresAbonoExtraordinarioCierre"))
        '            SaldoCierreCajaTotal = CDec(dtSaldosalCierredeCaja.Rows(0).Item("SaldoCierreCaja"))
        '            InteresCierreCajaTotal = CDec(dtSaldosalCierredeCaja.Rows(0).Item("SaldoCierreCajaIntereses"))
        '        End If

        '    End If

        '    dtPrestamos = objPrestamosBU.ImprimirReportePrestamosIntereses(NaveID, CajaId)
        '        Dim dc As DataColumn
        '        dc = New DataColumn("AbonoPrestamoExt", Type.GetType("System.Int32"))
        '        dtPrestamos.Columns.Add(dc)
        '        dc = New DataColumn("InteresCobradoExt", Type.GetType("System.Int32"))
        '        dtPrestamos.Columns.Add(dc)

        '        dtAbononosExtraordinario = objPrestamosBU.ConsultarAbonosExtraordinarios(NaveID, CajaId)

        '        For Each row As DataRow In dtPrestamos.Rows
        '        Dim periodo As Integer = 0
        '        periodo = row("PeriodoNomina").ToString
        '        'BUSCAR EL ABONO QUE LE CORRESPONDA
        '        Dim row2 = dtAbononosExtraordinario.AsEnumerable.Where(Function(x) x.Item("PeriodoNomina") = periodo).ToList
        '        If row2.Count > 0 Then
        '            row("AbonoPrestamoExt") = CInt(row2(0).Item(0).ToString)
        '            row("InteresCobradoExt") = CInt(row2(0).Item(1).ToString)
        '        Else ' AUN NO HAY ABONO
        '            row("AbonoPrestamoExt") = 0
        '                row("InteresCobradoExt") = 0
        '            End If


        '        Next

        '        Dim TotalSaldoPrestamos As Int32
        '        Dim SaldoInicalPrestamosI As Int32
        '        Dim SaldoFinalInteresesT As Int32
        '        Dim anio As Int32
        '        If dtPrestamos.Rows.Count > 0 Then
        '            TotalSaldoPrestamos = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
        '                                                    Select(Function(y) y.Item("TotalSaldoPrestamos")).First
        '            SaldoInicalPrestamosI = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
        '                                                    Select(Function(y) y.Item("SaldoInicial")).First
        '            SaldoFinalInteresesT = dtPrestamos.AsEnumerable.OrderByDescending(Function(x) x.Item("Consecutivo")).
        '                                                    Select(Function(y) y.Item("TotalSaldoIntereses")).First
        '            anio = dtPrestamos.AsEnumerable.Where(Function(x) x.Item("Consecutivo")).
        '                                                    Select(Function(y) y.Item("Año")).First

        '        End If
        '        Dim SaldoFinalIntereses As Int16 = 0
        '        If dtSaldosAbonosExtraordinarios.Rows(0).Item("CajaActiva") = "A" Then
        '            SaldoFinalIntereses = SaldoFinalInteresesT - InteresAbonoExtraordinario
        '        Else
        '            SaldoFinalIntereses = dtSaldosAbonosExtraordinarios.Rows(0).Item("InteresSiguienteCaja")
        '        End If

        '        If (SaldoFinalIntereses < 0) Then
        '            SaldoFinalIntereses = 0
        '        End If



        '        PrestamosNomina.DataSetName = "Prestamos"

        '        dtPrestamos.TableName = "Prestamos"

        '        If dtPrestamos.Rows.Count > 0 Then
        '            PrestamosNomina.Tables.Add(dtPrestamos)
        '            Try
        '                Dim objBU As New Framework.Negocios.ReportesBU
        '                Dim EntidadReporte As Entidades.Reportes
        '                EntidadReporte = objBU.LeerReporteporClave("RPT_PRES_INTERESES_N")
        '                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
        '        EntidadReporte.Pnombre.Trim + ".mrt"
        '                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        '                Dim reporte As New StiReport
        '                reporte.Load(archivo)
        '                reporte.Compile()
        '                reporte("Nave") = cmbNave.Text
        '                'reporte("SaldoInicial") = SaldoInicial
        '                reporte("Anio") = anio + 1
        '                reporte("TotalSaldoPrestamos") = TotalSaldoPrestamos
        '                reporte("SaldoFinalInteresesT") = SaldoFinalInteresesT
        '                reporte("AbonosExtraordinarios") = SaldoAbonoExtraordinario
        '                reporte("IntereseExtraordinarios") = InteresAbonoExtraordinario
        '                reporte("SaldoCierreCaja") = SaldoCierreCaja
        '            reporte("InteresCierreCaja") = InteresCierreCaja
        '            If dtSaldosalCierredeCaja.Rows(0).Item("CajaActiva") = "C" Then
        '                reporte("SaldoFinal") = SaldoCierreCajaTotal
        '                reporte("SaldoFinalIntereses") = InteresCierreCajaTotal 'SaldoFinalInteresesT - InteresAbonoExtraordinario
        '            Else
        '                reporte("SaldoFinal") = TotalSaldoPrestamos - SaldoCierreCaja
        '                reporte("SaldoFinalIntereses") = SaldoFinalIntereses - InteresCierreCaja 'SaldoFinalInteresesT - InteresAbonoExtraordinario
        '            End If
        '            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        '                reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave((Int(cmbNave.SelectedValue)))


        '                reporte.Dictionary.Clear()
        '                reporte.RegData(PrestamosNomina)
        '                reporte.Dictionary.Synchronize()
        '                reporte.Show()

        '                Me.Cursor = Cursors.Default
        '            Catch ex As Exception

        '            End Try
        '        Else
        '            vAdvertenciaForm.Text = "Préstamos"
        '            vAdvertenciaForm.mensaje = "No hay información para imprimir."
        '            vAdvertenciaForm.Show()
        '        End If
        '    End If

    End Sub
End Class