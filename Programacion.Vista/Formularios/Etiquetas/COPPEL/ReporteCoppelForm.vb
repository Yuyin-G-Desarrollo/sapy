Imports Stimulsoft.Report
Imports Tools

Public Class ReporteCoppelForm

    Dim objBu As New Programacion.Negocios.EtiquetasBU


    Private Sub ReporteCoppelForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarNaves()
        dtmFechaInicioPrograma.Value = Now.ToShortDateString
        dtmFechaFinPrograma.Value = Now.ToShortDateString

    End Sub

    Public Sub CargarNaves()
        Dim DTNaves As DataTable
        DTNaves = objBu.ConsultarNavesProduccion()
        DTNaves.Rows.InsertAt(DTNaves.NewRow, 0)
        cmbNave.DataSource = DTNaves
        cmbNave.DisplayMember = "Nave"
        cmbNave.ValueMember = "NaveSICYID"
    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtmFechaInicioPrograma.ValueChanged
        dtmFechaFinPrograma.MinDate = dtmFechaInicioPrograma.Value
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        imprimirReporte()

    End Sub

    Public Sub imprimirReporte()
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim dsPedidosCOPPEL As New DataSet("dsPedidosCOPPEL")
        Dim dtProgramas As DataTable
        Dim dtNavesPrograma As DataTable
        Dim dtPedidosCOPPEL As DataTable
        Dim dtDetallesPedidoCOPPEL As DataTable
        Dim dtParesPedidoCOPPEL As DataTable
        Dim dtParesNaveProgramaCOPPEL As DataTable
        Dim ReportePedidoCOPPEL As New StiReport
        'Dim objbu As New Programacion.Negocios.EtiquetasCOPPELBU

        Dim dtProgramasAux As DataTable
        Dim dtNavesProgramaAux As DataTable
        Dim dtPedidosCOPPELAux As DataTable
        Dim dtDetallesPedidoCOPPELAux As DataTable
        Dim dtParesPedidoCOPPELAux As DataTable
        Dim dtParesNaveProgramaCOPPELAux As DataTable
        Dim NaveId As Integer = 0
        Dim DTNAves As DataTable
        Dim NaveSAY As Integer = 0
        Try

            Cursor = Cursors.WaitCursor


            DTNAves = objBu.ConsultarNavesProduccion()

            Dim tool As New Tools.Controles

            If cmbNave.SelectedIndex > 0 Then
                NaveId = cmbNave.SelectedValue
            Else
                NaveId = 0
            End If


            dtProgramas = New DataTable("dtProgramas")
            With dtProgramas
                .Columns.Add("ProgramaID")
                .Columns.Add("Programa")
            End With

            dtProgramasAux = objBu.ReporteCOPPEL_ConsultaProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value)

            For Each Fila As DataRow In dtProgramasAux.Rows
                dtProgramas.Rows.Add(Fila.Item(0).ToString, FormatoFechaPrograma(Fila.Item(1).ToString))
            Next

            dtNavesPrograma = New DataTable("dtNavesPrograma")
            With dtNavesPrograma
                .Columns.Add("ProgramaID")
                .Columns.Add("NaveId")
                .Columns.Add("NombreNave")
                .Columns.Add("TotalPares")
            End With

            dtNavesProgramaAux = objBu.ReporteCOPPEL_ConsultaNaveProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)

            For Each Fila As DataRow In dtNavesProgramaAux.Rows
                dtNavesPrograma.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString(), Fila.Item(3).ToString())
            Next

            dtParesNaveProgramaCOPPEL = New DataTable("dtParesNaveProgramaCOPPEL")
            With dtParesNaveProgramaCOPPEL
                .Columns.Add("ProgramaID")
                .Columns.Add("NaveID")
                .Columns.Add("TotalPares")
            End With

            dtParesNaveProgramaCOPPELAux = objBu.ReporteCOPPEL_ConsultaParesNaveProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)

            'If dtParesNaveProgramaCOPPELAux.Rows.Count <> 0 Then
            For Each Fila As DataRow In dtParesNaveProgramaCOPPELAux.Rows
                dtParesNaveProgramaCOPPEL.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, CDbl(Fila.Item(2).ToString()).ToString("N0"))
            Next

            dtPedidosCOPPEL = New DataTable("dtPedidosCOPPEL")
            With dtPedidosCOPPEL
                .Columns.Add("ProgramaID")
                .Columns.Add("NaveID")
                .Columns.Add("PedidoCliente")
                .Columns.Add("PedidoSAY")
                .Columns.Add("PedidoSICY")
                .Columns.Add("TotalPares")
            End With
            'Else
            '    MsgBox("Error", "No hay datos por mostrar")

            'End If

            

            dtPedidosCOPPELAux = objBu.ReporteCOPPEL_ConsultaPedidosProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)



            For Each Fila As DataRow In dtPedidosCOPPELAux.Rows
                dtPedidosCOPPEL.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString(), Fila.Item(3).ToString, Fila.Item(4).ToString(), Fila.Item(5).ToString())
            Next

            dtParesPedidoCOPPEL = New DataTable("dtParesPedidoCOPPEL")
            With dtParesPedidoCOPPEL
                .Columns.Add("ProgramaID")
                .Columns.Add("NaveID")
                .Columns.Add("PedidoCliente")
                .Columns.Add("TotalPares")
                '.Columns.Add("PedidoSAY")
            End With

            dtParesPedidoCOPPELAux = objBu.ReporteCOPPEL_ConsultaParesPedidosProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)

            For Each Fila As DataRow In dtParesPedidoCOPPELAux.Rows
                dtParesPedidoCOPPEL.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString(), CDbl(Fila.Item(3).ToString).ToString("N0")) ', Fila.Item(4).ToString()
            Next

            dtDetallesPedidoCOPPEL = New DataTable("dtDetallesPedidoCOPPEL")
            With dtDetallesPedidoCOPPEL
                .Columns.Add("ProgramaID")
                .Columns.Add("NaveID")
                .Columns.Add("PedidoCliente")
                .Columns.Add("CodigoCliente")
                .Columns.Add("ColeccionModelo")
                .Columns.Add("Linea")
                .Columns.Add("Tallas")
                .Columns.Add("Pares")
                .Columns.Add("EtiquetasImpresas")
                .Columns.Add("PedidoSAY")
            End With

            dtDetallesPedidoCOPPELAux = objBu.ReporteCOPPEL_ConsultaDetallesPedidosProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)


            For Each Fila As DataRow In dtDetallesPedidoCOPPELAux.Rows
                dtDetallesPedidoCOPPEL.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString(), Fila.Item(3).ToString, Fila.Item(4).ToString, Fila.Item(5).ToString, Fila.Item(6).ToString, Fila.Item(7).ToString, Fila.Item(8).ToString, Fila.Item(9).ToString()) '
            Next


            dsPedidosCOPPEL.Tables.Add(dtProgramas)
            dsPedidosCOPPEL.Tables.Add(dtNavesPrograma)
            dsPedidosCOPPEL.Tables.Add(dtPedidosCOPPEL)
            dsPedidosCOPPEL.Tables.Add(dtDetallesPedidoCOPPEL)
            dsPedidosCOPPEL.Tables.Add(dtParesPedidoCOPPEL)
            dsPedidosCOPPEL.Tables.Add(dtParesNaveProgramaCOPPEL)

            entReporte = objReporte.LeerReporteporClave("PROG_ETIQUETAS_PEDIDO_COPPEL")

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReportePedidoCOPPEL.Load(archivo)
            ReportePedidoCOPPEL.Compile()
            ReportePedidoCOPPEL.RegData(dsPedidosCOPPEL)
            ReportePedidoCOPPEL("UsuarioImprimio") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString()
            ReportePedidoCOPPEL("FechaImpresion") = FormatoFechaPrograma(Date.Now)
            ReportePedidoCOPPEL("FechasRangoPrograma") = ObtenerTituloInforme(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value)
            If cmbNave.SelectedIndex = 0 Then
                ReportePedidoCOPPEL("RutaImagenNave") = Tools.Controles.ObtenerLogoNave(43)
            Else
                NaveSAY = DTNAves.AsEnumerable.Where(Function(x) x.Item("NaveSICYID") = cmbNave.SelectedValue).Select(Function(y) y.Item("NaveSAYId")).FirstOrDefault()

                ReportePedidoCOPPEL("RutaImagenNave") = Tools.Controles.ObtenerLogoNave(NaveSAY)
            End If

            ReportePedidoCOPPEL.Dictionary.Clear()
            ReportePedidoCOPPEL.Dictionary.Synchronize()
            'reporteUnaTienda.Render()
            ReportePedidoCOPPEL.Show()


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Function FormatoFechaPrograma(ByVal Fecha As Date) As String
        Dim FormatoFecha As String = String.Empty
        Dim NombreDia As String = String.Empty
        Dim NombreMes As String = String.Empty

        If Fecha.DayOfWeek = DayOfWeek.Sunday Then
            NombreDia = "Domingo"
        ElseIf Fecha.DayOfWeek = DayOfWeek.Monday Then
            NombreDia = "Lunes"
        ElseIf Fecha.DayOfWeek = DayOfWeek.Tuesday Then
            NombreDia = "Martes"
        ElseIf Fecha.DayOfWeek = DayOfWeek.Wednesday Then
            NombreDia = "Miércoles"
        ElseIf Fecha.DayOfWeek = DayOfWeek.Thursday Then
            NombreDia = "Jueves"
        ElseIf Fecha.DayOfWeek = DayOfWeek.Friday Then
            NombreDia = "Viernes"
        ElseIf Fecha.DayOfWeek = DayOfWeek.Saturday Then
            NombreDia = "Sabado"
        End If

        If Fecha.Month = 1 Then
            NombreMes = "enero"
        ElseIf Fecha.Month = 2 Then
            NombreMes = "febrero"
        ElseIf Fecha.Month = 3 Then
            NombreMes = "marzo"
        ElseIf Fecha.Month = 4 Then
            NombreMes = "abril"
        ElseIf Fecha.Month = 5 Then
            NombreMes = "mayo"
        ElseIf Fecha.Month = 6 Then
            NombreMes = "junio"
        ElseIf Fecha.Month = 7 Then
            NombreMes = "julio"
        ElseIf Fecha.Month = 8 Then
            NombreMes = "agosto"
        ElseIf Fecha.Month = 9 Then
            NombreMes = "septiembre"
        ElseIf Fecha.Month = 10 Then
            NombreMes = "octubre"
        ElseIf Fecha.Month = 11 Then
            NombreMes = "noviembre"
        ElseIf Fecha.Month = 12 Then
            NombreMes = "diciembre"
        End If

        FormatoFecha = NombreDia & ", " & Fecha.Day.ToString & " de " & NombreMes & " de " & Fecha.Year.ToString()


        Return FormatoFecha

    End Function

    Private Function ObtenerTituloInforme(ByVal FechaInicio As Date, ByVal FechaFin As Date) As String
        Dim FormatoFecha As String = String.Empty
        Dim NombreDia As String = String.Empty
        Dim NombreMes As String = String.Empty

        Dim NombreDiaFin As String = String.Empty
        Dim NombreMesFin As String = String.Empty

        If FechaInicio.DayOfWeek = DayOfWeek.Sunday Then
            NombreDia = "Domingo"
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Monday Then
            NombreDia = "Lunes"
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Tuesday Then
            NombreDia = "Martes"
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Wednesday Then
            NombreDia = "Miércoles"
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Thursday Then
            NombreDia = "Jueves"
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Friday Then
            NombreDia = "Viernes"
        ElseIf FechaInicio.DayOfWeek = DayOfWeek.Saturday Then
            NombreDia = "Sabado"
        End If

        If FechaInicio.Month = 1 Then
            NombreMes = "enero"
        ElseIf FechaInicio.Month = 2 Then
            NombreMes = "febrero"
        ElseIf FechaInicio.Month = 3 Then
            NombreMes = "marzo"
        ElseIf FechaInicio.Month = 4 Then
            NombreMes = "abril"
        ElseIf FechaInicio.Month = 5 Then
            NombreMes = "mayo"
        ElseIf FechaInicio.Month = 6 Then
            NombreMes = "junio"
        ElseIf FechaInicio.Month = 7 Then
            NombreMes = "julio"
        ElseIf FechaInicio.Month = 8 Then
            NombreMes = "agosto"
        ElseIf FechaInicio.Month = 9 Then
            NombreMes = "septiembre"
        ElseIf FechaInicio.Month = 10 Then
            NombreMes = "octubre"
        ElseIf FechaInicio.Month = 11 Then
            NombreMes = "noviembre"
        ElseIf FechaInicio.Month = 12 Then
            NombreMes = "diciembre"
        End If

        If FechaFin.DayOfWeek = DayOfWeek.Sunday Then
            NombreDiaFin = "Domingo"
        ElseIf FechaFin.DayOfWeek = DayOfWeek.Monday Then
            NombreDiaFin = "Lunes"
        ElseIf FechaFin.DayOfWeek = DayOfWeek.Tuesday Then
            NombreDiaFin = "Martes"
        ElseIf FechaFin.DayOfWeek = DayOfWeek.Wednesday Then
            NombreDiaFin = "Miércoles"
        ElseIf FechaFin.DayOfWeek = DayOfWeek.Thursday Then
            NombreDiaFin = "Jueves"
        ElseIf FechaFin.DayOfWeek = DayOfWeek.Friday Then
            NombreDiaFin = "Viernes"
        ElseIf FechaFin.DayOfWeek = DayOfWeek.Saturday Then
            NombreDiaFin = "Sabado"
        End If

        If FechaFin.Month = 1 Then
            NombreMesFin = "enero"
        ElseIf FechaFin.Month = 2 Then
            NombreMesFin = "febrero"
        ElseIf FechaFin.Month = 3 Then
            NombreMesFin = "marzo"
        ElseIf FechaFin.Month = 4 Then
            NombreMesFin = "abril"
        ElseIf FechaFin.Month = 5 Then
            NombreMesFin = "mayo"
        ElseIf FechaFin.Month = 6 Then
            NombreMesFin = "junio"
        ElseIf FechaFin.Month = 7 Then
            NombreMesFin = "julio"
        ElseIf FechaFin.Month = 8 Then
            NombreMesFin = "agosto"
        ElseIf FechaFin.Month = 9 Then
            NombreMesFin = "septiembre"
        ElseIf FechaFin.Month = 10 Then
            NombreMesFin = "octubre"
        ElseIf FechaFin.Month = 11 Then
            NombreMesFin = "noviembre"
        ElseIf FechaFin.Month = 12 Then
            NombreMesFin = "diciembre"
        End If

        FormatoFecha = "Del " & NombreDia & ", " & FechaInicio.Day.ToString() & " de " & NombreMes & " del " & FechaInicio.Year.ToString() & " al " & NombreDiaFin.ToString() & ", " & FechaFin.Day.ToString & " de " & NombreMesFin & " del " & FechaFin.Year.ToString
        Return FormatoFecha
    End Function

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

End Class