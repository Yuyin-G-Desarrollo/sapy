Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report

Public Class frmConsultaCierreAnualCerrada

    Public idCajaAhorro As Int32 = 0
    Public cajaDeAl As String = ""
    Public idNave As String = ""
    Public nombreNave As String = ""
    Dim listaSemanas As New List(Of Entidades.PeriodosNomina)

    Public Sub ejecutarReporteResumenAnual()
        Dim objN As New Negocios.CajaAhorroBU
        Dim dtResumen As New DataTable
        dtResumen.TableName = "dtResumen"
        dtResumen = objN.consultaResumenCajaCerrada(idCajaAhorro)
        If dtResumen.Rows.Count > 0 Then
            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim entReporte As New Entidades.Reportes
            entReporte = objReporte.LeerReporteporClave("ANUAL_CAJA_AHORRO")

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
            Dim reporte As New StiReport
            Dim objCajaAhorroBU As New Negocios.CajaAhorroBU
            Dim entCajaAhorro As New Entidades.CajaAhorro

            entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(idCajaAhorro)

            reporte.Load(archivo)
            reporte.Compile()
            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(idNave)
            reporte("nombreNave") = nombreNave
            reporte("nombreReporte") = "SAY: CARTA_CIERRE_CAJA_AHORRO.mrt"

            reporte("NombreUsuario") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte("concepto") = lblConcepto.Text
            entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(idCajaAhorro)


            reporte.Dictionary.Clear()
            reporte.RegData(dtResumen)
            reporte.Dictionary.Synchronize()
            reporte.Show()

        Else

        End If
    End Sub

    Public Sub ejecutarReporteCierreCajaAhorro()
        Dim imprimir As Boolean = False
        Dim dsDatosColaboradoes As New DataSet
        Dim dtDatosColaboradores As New DataTable
        Dim dtColaboradorIntereses As New DataTable

        dtDatosColaboradores.TableName = "dtDatosColaboradores"
        dtDatosColaboradores.Columns.Add("cantidadEntregar")
        dtDatosColaboradores.Columns.Add("cantidadLetra")
        dtDatosColaboradores.Columns.Add("nombreEmpleado")
        dtDatosColaboradores.Columns.Add("idColaborador")
        dtDatosColaboradores.Columns.Add("abonoPrestamo")
        dtDatosColaboradores.Columns.Add("totalMenosPrestamo")
        dtDatosColaboradores.Columns.Add("totalCaja")

        dtColaboradorIntereses.TableName = "dtColaboradorIntereses"
        dtColaboradorIntereses.Columns.Add("idColaborador")
        dtColaboradorIntereses.Columns.Add("interesesGanados")
        dtColaboradorIntereses.Columns.Add("cantidadLetrasInteres")

        Dim control As New Tools.Controles
        Dim cantidadLetras As String = "Cero"

        Dim cantidad As Double = 0
        Dim cantidadInteres As Double = 0
        Dim cantidadLetrasInteres As String = "Cero"
        Dim abono As Double = 0
        Dim totalMenosPrestamo As Double = 0
        For Each row As UltraGridRow In grdCierreAnual.Rows.GetAllNonGroupByRows
            cantidad = 0
            cantidadLetras = "Cero"

            If row.Cells("Seleccion").Value = True Then
                imprimir = True
                'cantidad = CDbl(row.Cells("cca_montoacumulado").Value) - CDbl(row.Cells("cca_abono").Value)
                cantidad = CDbl(row.Cells("cca_montoacumulado").Value)
                cantidadInteres = CDbl(row.Cells("cca_totalintereses").Value)
                abono = row.Cells("cca_abono").Value
                If cantidad > 0 Then
                    'cantidadLetras = control.EnLetras(cantidad)
                    cantidadLetras = control.EnLetras(cantidad - abono)
                End If
                If cantidadInteres > 0 Then
                    cantidadLetrasInteres = control.EnLetras(cantidadInteres)
                Else
                    cantidadLetrasInteres = "cero"
                End If

                Dim newRow As DataRow
                Dim newRowInt As DataRow
                newRow = dtDatosColaboradores.NewRow()
                newRowInt = dtColaboradorIntereses.NewRow()
                'newRow.Item("cantidadEntregar") = "$ " + cantidad.ToString("N2")
                newRow.Item("cantidadLetra") = "( " + cantidadLetras.ToUpper + " PESOS 00/100 M.N. )"
                newRow.Item("nombreEmpleado") = row.Cells("Colaborador").Value.ToString
                newRow.Item("idColaborador") = row.Cells("cca_colaboradorid").Value.ToString
                newRow.Item("abonoPrestamo") = "$ " + abono.ToString("N2")
                newRow.Item("totalMenosPrestamo") = "$ " + (cantidad - abono).ToString("N2")
                newRow.Item("totalCaja") = "$ " + cantidad.ToString("N2")

                newRow.Item("cantidadEntregar") = "$ " + (cantidad - abono).ToString("N2")

                newRowInt.Item("idColaborador") = row.Cells("cca_colaboradorid").Value.ToString
                newRowInt.Item("interesesGanados") = "$ " + cantidadInteres.ToString("N2")
                newRowInt.Item("cantidadLetrasInteres") = "( " + cantidadLetrasInteres.ToUpper + " PESOS 00/100 M.N. )"

                dtDatosColaboradores.Rows.Add(newRow)
                dtColaboradorIntereses.Rows.Add(newRowInt)
            End If
        Next
        If imprimir = True Then

            Dim dateForm As New DateForm()
            Dim fecha As New Date
            dateForm.mensaje = "Seleccione la fecha deseada."
            dateForm.ShowDialog()
            fecha = dateForm.dtpFecha.Value

            dsDatosColaboradoes.Tables.Add(dtDatosColaboradores)
            dsDatosColaboradoes.Tables.Add(dtColaboradorIntereses)

            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim entReporte As New Entidades.Reportes
            entReporte = objReporte.LeerReporteporClave("CARTA_CIERRE_CAJA_AHORRO")

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
            Dim reporte As New StiReport
            Dim objCajaAhorroBU As New Negocios.CajaAhorroBU
            Dim entCajaAhorro As New Entidades.CajaAhorro

            entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(idCajaAhorro)

            Dim fechainicioCA As Date = entCajaAhorro.pFechaInicial
            Dim fechafinCA As Date = entCajaAhorro.pFechaFinal
            Dim diaInicio As String = fechainicioCA.Day.ToString
            Dim diaFin As String = fechafinCA.Day.ToString
            'Dim diaHoy As String = Date.Now.Day.ToString
            Dim diaHoy As String = fecha.Day.ToString
            Dim mesInicio As String = fechainicioCA.Month.ToString
            Dim mesFin As String = fechafinCA.Month.ToString
            'Dim meshoy As String = Date.Now.Month.ToString
            Dim meshoy As String = fecha.Month.ToString
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

            reporte.Load(archivo)
            reporte.Compile()
            reporte("rutaImagen") = Tools.Controles.ObtenerLogoNave(idNave)
            reporte("nombreNave") = nombreNave
            reporte("nombreReporte") = "SAY: CARTA_CIERRE_CAJA_AHORRO.mrt"

            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(idCajaAhorro)


            reporte("fechadel") = " del " + diaInicio + " de " + mesInicio + " del " + anioInicio
            reporte("fechaal") = " al " + diaFin + " de " + mesFin + " del " + anioFin + "."
            reporte("fechadeldia") = diaHoy + " de " + meshoy + " de " + fecha.Year.ToString
            reporte("anio") = (fecha.Year.ToString - 1).ToString

            reporte.Dictionary.Clear()
            reporte.RegData(dsDatosColaboradoes)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        Else
            Dim objM As New Tools.AdvertenciaForm
            objM.mensaje = "Seleccione al menos un colaborador."
            objM.ShowDialog()
        End If
    End Sub

    Public Sub llenarDatos()
        Dim objCJBU As New Negocios.CajaAhorroBU
        Dim dtCierreAnual, dtCierreAnual2, semanasGanadas As New DataTable
        Dim reporteSemanasBU As New Negocios.ReporteCajaAhorroBU
        Dim listaSemanas As New List(Of Entidades.PeriodosNomina)
        Dim contador As Int32 = 3
        Dim banderaAgregarColSemanas As Boolean = False
        Dim banderaAgregarColTotales As Boolean = False

        lblConcepto.Text = cajaDeAl

        dtCierreAnual = objCJBU.consultaCierreAnualCajaAhorroCerrada(idCajaAhorro)

        dtCierreAnual2.Columns.Add("Seleccion")
        dtCierreAnual2.Columns.Add("cca_colaboradorid")
        dtCierreAnual2.Columns.Add("Colaborador")
        Dim algo As String
        listaSemanas = reporteSemanasBU.ConsultaSemanasCaja(idCajaAhorro)

        For Each row As DataRow In dtCierreAnual.Rows
            Dim cont As Int32 = 0
            Dim fila As DataRow

            fila = dtCierreAnual2.NewRow
            fila("Seleccion") = row.Item(0)
            fila("cca_colaboradorid") = row.Item(1).ToString()
            fila("Colaborador") = row.Item(2).ToString()

            semanasGanadas = reporteSemanasBU.consultaSemanasGanadasCol(row.Item(1).ToString(), idCajaAhorro.ToString)
            For Each semana As Entidades.PeriodosNomina In listaSemanas
                If banderaAgregarColSemanas = False Then
                    dtCierreAnual2.Columns.Add("Sem " + semana.PPeriodoId.ToString)
                    dtCierreAnual2.Columns.Item(contador).Caption = semana.FechaInicio.ToShortDateString + " al " + semana.FechaFin.ToShortDateString
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
                    fila("Sem " + semana.PPeriodoId.ToString) = "SI"
                    cont = cont + 1
                ElseIf var1 = semana.PPeriodoId And var2 = False And var3 > 0 Then
                    fila("Sem " + semana.PPeriodoId.ToString) = "NO"
                    cont = cont + 1
                ElseIf var1 = semana.PPeriodoId And var2 = False And var3 = 0 Then
                    fila("Sem " + semana.PPeriodoId.ToString) = "-"
                    cont = cont + 1
                ElseIf var1 = semana.PPeriodoId And var2 = True And var3 = 0 Then
                    fila("Sem " + semana.PPeriodoId.ToString) = "-"
                    cont = cont + 1
                Else
                    fila("Sem " + semana.PPeriodoId.ToString) = "-"
                End If
            Next

            If banderaAgregarColTotales = False Then
                dtCierreAnual2.Columns.Add("cca_montoahorro")
                dtCierreAnual2.Columns.Add("cca_semanasahorradas")
                dtCierreAnual2.Columns.Add("cca_semanasganadas")
                dtCierreAnual2.Columns.Add("cca_semanasperdidas")
                dtCierreAnual2.Columns.Add("cca_interesganado")
                dtCierreAnual2.Columns.Add("cca_montoacumulado")
                dtCierreAnual2.Columns.Add("cca_totalintereses")
                dtCierreAnual2.Columns.Add("cca_totalcaja")
                dtCierreAnual2.Columns.Add("real_cantidad")
                dtCierreAnual2.Columns.Add("cca_saldoanterior")
                dtCierreAnual2.Columns.Add("cca_abono")
                dtCierreAnual2.Columns.Add("cca_saldonuevo")
                dtCierreAnual2.Columns.Add("cca_totalentregar")
                dtCierreAnual2.Columns.Add("real_fecha")
                banderaAgregarColTotales = True
            End If
            Dim total As Double = 0
            total = row.Item(3).ToString()
            fila("cca_montoahorro") = total.ToString("N0")
            fila("cca_semanasahorradas") = row.Item(4).ToString()
            fila("cca_semanasganadas") = row.Item(5).ToString()
            fila("cca_semanasperdidas") = row.Item(6).ToString()
            fila("cca_interesganado") = row.Item(7).ToString()
            total = row.Item(8).ToString()
            fila("cca_montoacumulado") = total.ToString("N0")
            total = row.Item(9).ToString()
            fila("cca_totalintereses") = total.ToString("N0")
            total = row.Item(10).ToString()
            fila("cca_totalcaja") = total.ToString("N0")
            total = row.Item(11).ToString()
            fila("real_cantidad") = total.ToString("N0")
            total = row.Item(12).ToString()
            fila("cca_saldoanterior") = total.ToString("N0")
            total = row.Item(13).ToString()
            fila("cca_abono") = total.ToString("N0")
            total = row.Item(14).ToString()
            fila("cca_saldonuevo") = total.ToString("N0")
            total = row.Item(15).ToString()
            fila("cca_totalentregar") = total.ToString("N0")
            fila("real_fecha") = row.Item(16).ToString()

            dtCierreAnual2.Rows.Add(fila)
        Next

        If dtCierreAnual2.Rows.Count > 0 Then
            algo = dtCierreAnual2.Rows.Item(2).Item(0).ToString
            grdCierreAnual.DataSource = dtCierreAnual2
            disenioGrids()
        End If

    End Sub

    Public Sub disenioGrids()
        grdCierreAnual.DisplayLayout.UseFixedHeaders = True
        With grdCierreAnual.DisplayLayout.Bands(0)
            For i As Int32 = 0 To grdCierreAnual.DisplayLayout.Bands(0).Columns.Count - 1
                If grdCierreAnual.DisplayLayout.Bands(0).Columns(i).Header.Caption <> "Seleccion" Then
                    .Columns(i).CellActivation = Activation.NoEdit
                Else
                    .Columns(i).Header.Caption = ""
                    .Columns(i).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                    '.Columns(i).DataType = GetType(Boolean)
                    '.Columns(i).CellActivation = Activation.AllowEdit
                    '.Columns(i).Header.VisiblePosition = 0
                End If
            Next

            .Columns("cca_colaboradorid").Hidden = True
            .Columns("cca_colaboradorid").Hidden = True
            .Columns("cca_montoahorro").Header.Caption = "Monto" & vbCrLf & "Ahorro"
            .Columns("cca_semanasahorradas").Header.Caption = "Semanas" & vbCrLf & "Ahorrodas"
            .Columns("cca_semanasganadas").Header.Caption = "Semanas" & vbCrLf & "Ganadas"
            .Columns("cca_semanasperdidas").Header.Caption = "Semanas" & vbCrLf & "Perdidas"
            .Columns("cca_interesganado").Header.Caption = "Interés" & vbCrLf & "Ganado"
            .Columns("cca_montoacumulado").Header.Caption = "Monto" & vbCrLf & "Acumulado"
            .Columns("cca_totalintereses").Header.Caption = "Total" & vbCrLf & "Intereses"
            .Columns("cca_totalcaja").Header.Caption = "Total" & vbCrLf & "Caja"
            .Columns("real_cantidad").Header.Caption = "Salario"
            .Columns("cca_saldoanterior").Header.Caption = "Saldo en" & vbCrLf & "Préstamos"
            .Columns("cca_abono").Header.Caption = "Abono"
            .Columns("cca_saldonuevo").Header.Caption = "Nuevo" & vbCrLf & "Saldo"
            .Columns("cca_totalentregar").Header.Caption = "Total" & vbCrLf & "Entregar"
            .Columns("real_fecha").Header.Caption = "Fecha" & vbCrLf & "ingreso"

            .Columns("cca_montoahorro").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_semanasahorradas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_semanasganadas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_semanasperdidas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_interesganado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_montoacumulado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_totalintereses").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_totalcaja").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("real_cantidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_saldoanterior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_abono").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_saldonuevo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cca_totalentregar").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("real_fecha").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("cca_montoahorro").Format = "###,###,##0"
            .Columns("cca_interesganado").Format = "###,###,##0"
            .Columns("cca_montoacumulado").Format = "###,###,##0"
            .Columns("cca_totalintereses").Format = "###,###,##0"
            .Columns("cca_totalcaja").Format = "###,###,##0"
            .Columns("real_cantidad").Format = "###,###,##0"
            .Columns("cca_saldoanterior").Format = "###,###,##0"
            .Columns("cca_abono").Format = "###,###,##0"
            .Columns("cca_saldonuevo").Format = "###,###,##0"
            .Columns("cca_totalentregar").Format = "###,###,##0"
            .Columns("real_fecha").Format = "dd/mm/aaaa"

            .ColHeaderLines = 2
            .GroupHeaderLines = 2
        End With
        grdCierreAnual.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True
        grdCierreAnual.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdCierreAnual.DisplayLayout.Bands(0).Columns("Colaborador").Width = 300
        grdCierreAnual.DisplayLayout.Bands(0).Columns("Colaborador").Header.Fixed = True
        grdCierreAnual.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        Dim gr As New UltraGrid
        If result = Windows.Forms.DialogResult.OK Then
            Try
                gr = grdCierreAnual
                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(gr, fileName)
                Me.Cursor = Cursors.Default
                Me.Cursor = Cursors.WaitCursor
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Private Sub frmConsultaCierreAnualCerrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAJA_CAJA", "CAJA_EXPORTAR_CIERRE_ANUAL") Then
            btnExportar.Visible = True
            lblAccionExportar.Visible = True

        Else
            btnExportar.Visible = False
            lblAccionExportar.Visible = False
        End If
        llenarDatos()


    End Sub

    Private Sub grdCierreAnual_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCierreAnual.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdCierreAnual.Rows.Count > 0 Then
            exportarExcel()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grCajaAhorro.Height = 41
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grCajaAhorro.Height = 75
    End Sub

    Private Sub chkSeleccionarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodos.CheckedChanged
        For Each row As UltraGridRow In grdCierreAnual.Rows.GetAllNonGroupByRows
            If chkSeleccionarTodos.Checked = True Then
                row.Cells("Seleccion").Value = True
            Else
                row.Cells("Seleccion").Value = False
            End If
        Next
    End Sub

    Private Sub CartaCajaDeAhorroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CartaCajaDeAhorroToolStripMenuItem.Click
        ejecutarReporteCierreCajaAhorro()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        menuImprimir.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub

    Private Sub lblConcepto_Click(sender As Object, e As EventArgs) Handles lblConcepto.Click

    End Sub

    Private Sub ResumenAnualCajaDeAhorroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResumenAnualCajaDeAhorroToolStripMenuItem.Click
        ejecutarReporteResumenAnual()
    End Sub

    Private Sub chkResumen_CheckedChanged(sender As Object, e As EventArgs) Handles chkResumen.CheckedChanged
        If grdCierreAnual.Rows.Count > 0 Then
            Dim totColumnas As Int32 = 0
            totColumnas = grdCierreAnual.DisplayLayout.Bands(0).Columns.Count
            If chkResumen.Checked = True Then
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_semanasahorradas").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_semanasganadas").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_semanasperdidas").Hidden = False
           
            Else
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_semanasahorradas").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_semanasganadas").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_semanasperdidas").Hidden = True
            End If
        End If
    End Sub

    Private Sub chkTotales_CheckedChanged(sender As Object, e As EventArgs) Handles chkTotales.CheckedChanged
        If grdCierreAnual.Rows.Count > 0 Then
            Dim totColumnas As Int32 = 0
            totColumnas = grdCierreAnual.DisplayLayout.Bands(0).Columns.Count
            If chkTotales.Checked = True Then
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_montoahorro").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_interesganado").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_montoacumulado").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_totalintereses").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_totalcaja").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("real_cantidad").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_saldoanterior").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_abono").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_saldonuevo").Hidden = False
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_totalentregar").Hidden = False
            Else
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_montoahorro").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_interesganado").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_montoacumulado").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_totalintereses").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_totalcaja").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("real_cantidad").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_saldoanterior").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_abono").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_saldonuevo").Hidden = True
                grdCierreAnual.DisplayLayout.Bands(0).Columns("cca_totalentregar").Hidden = True
            End If
          
        End If
    End Sub

    Private Sub chkVerDetalleSemanas_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerDetalleSemanas.CheckedChanged
        If grdCierreAnual.Rows.Count > 0 Then
            If chkVerDetalleSemanas.Checked = True Then
                For i As Int32 = 3 To grdCierreAnual.DisplayLayout.Bands(0).Columns.Count - 15
                    grdCierreAnual.DisplayLayout.Bands(0).Columns(i).Hidden = False
                Next
            Else
                For i As Int32 = 3 To grdCierreAnual.DisplayLayout.Bands(0).Columns.Count - 15
                    grdCierreAnual.DisplayLayout.Bands(0).Columns(i).Hidden = True
                Next
            End If
        End If
    End Sub

    Private Sub grdCierreAnual_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdCierreAnual.AfterSelectChange
        With grdCierreAnual
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each rowDt In grdCierreAnual.Rows
                If rowDt.Selected Then
                    rowDt.Cells("Seleccion").Value = True
                    'Else
                    'rowDt.Cells("Seleccion").Value = False
                End If
            Next
            grdCierreAnual.EndUpdate()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImpresionDeSobresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresionDeSobresToolStripMenuItem.Click
        Try

            Dim dtimpresionsobres As New DataTable
            dtimpresionsobres.Columns.Add("#")
            dtimpresionsobres.Columns.Add("colaborador")
            Dim contador As Int32 = 1

            For Each row As UltraGridRow In grdCierreAnual.Rows
                dtimpresionsobres.Rows.Add(contador, row.Cells("Colaborador").Value)
                contador += 1
            Next

            Me.Cursor = Cursors.WaitCursor
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = OBJBU.LeerReporteporClave("NOM_IMP_SOBRES")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte.RegData(dtimpresionsobres)
            reporte.Show()
            Me.Cursor = Cursors.Default

            ImpresionDeSobresToolStripMenuItem.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class