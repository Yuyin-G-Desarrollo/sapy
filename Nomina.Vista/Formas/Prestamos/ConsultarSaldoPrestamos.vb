Imports Nomina
Imports System.Net
Imports Entidades
Imports Nomina.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports Tools

Public Class ConsultarSaldoPrestamos
    Dim idColaborador As Int32
    Dim idPrestamo As Int32
    Dim monto As Integer
    Dim abonos As Integer
    Dim estatus As String
    Dim NaveID As Int32
    Dim nombreNave As String
    Dim Semana As Int32
    Dim Consecutivos As Int32
    Dim fechas As Date
    Dim interesInicial As Double
    Dim InteresFila As Double = 0.0
    Public pagoSemanalQuincenal As Int32

    Public Property pfechas As Date
        Get
            Return fechas
        End Get
        Set(value As Date)
            fechas = value
        End Set
    End Property
    Public Property Pabbonos As Integer
        Get
            Return abonos
        End Get
        Set(value As Integer)
            abonos = value
        End Set
    End Property
    Public Property pestatus As String
        Get
            Return estatus
        End Get
        Set(value As String)
            estatus = value
        End Set
    End Property
    Public Property PIDColaborador As Int32
        Get
            Return idColaborador
        End Get
        Set(ByVal value As Int32)
            idColaborador = value
        End Set
    End Property
    Public Property pIdPrestamo As Int32
        Get
            Return idPrestamo
        End Get
        Set(ByVal value As Int32)
            idPrestamo = value
        End Set
    End Property
    Public Property pMonto As Integer
        Get
            Return monto
        End Get
        Set(ByVal value As Integer)
            monto = value
        End Set
    End Property
    'Agregar interés inicial
    Public Property PInteresInicial As Double
        Get
            Return interesInicial
        End Get
        Set(value As Double)
            interesInicial = value
        End Set
    End Property

    Private Sub ConsultarSaldoPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarInformacionGeneral()
        CargarInformacionLaboral()
        grdDatosAbono.DataSource = Nothing

        Try
            If Not pestatus = "I" And Not pestatus = "J" Then
                Me.Cursor = Cursors.WaitCursor
                formatoUltra()
                llenartabla()
                If Not grdDatosAbono.Rows.Count = 0 Then
                    CalcularFuturosPagos(1)
                Else
                    CalcularFuturosPagos(2)
                End If
            Else
                Dim Advertencia As New AdvertenciaForm
                Advertencia.mensaje = "El Colaborador no cuenta con ningun pago realizado"
                Advertencia.ShowDialog()
                Me.Close()
            End If

            'LUIS MARIO:  NO DESCOMENTAR, SIRVE PARA ACTUALIZAR INTERESES DE LOS PRESTAMOS EN COBRANZA.
            'txtTotalInteres.Text = grdDatosAbono.Rows.SummaryValues("sumainteres").Value.ToString()
            'txtPrestamoId.Text = idPrestamo.ToString()
            'txtColaboradorId.Text = idColaborador.ToString()

            'Dim objBu As New Negocios.ConsultarPrestamosBU

            'txtActualizacion.Text = objBu.ActualizarInteresPrestamo(Integer.Parse(txtColaboradorId.Text), Integer.Parse(txtPrestamoId.Text), Double.Parse(txtTotalInteres.Text)).Rows(0).Item(0).ToString()


            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "El Colaborador no cuenta con ningun pago realizado"
            Advertencia.ShowDialog()
            Me.Close()
        End Try

        'CalcularFuturosPagos()

    End Sub

    Public Sub formatoUltra()
        Dim band As UltraGridBand = Me.grdDatosAbono.DisplayLayout.Bands(0)
        With band
            .Columns.Add("estatus", "")
            .Columns.Add("color", "")
            .Columns.Add("fecha", "Fecha Abono")
            .Columns.Add("saldo", "Saldo")
            .Columns.Add("interes", "Interés")
            .Columns.Add("abono", "Abono Capital")
            .Columns.Add("total", "Total")
            .Columns.Add("actual", "Nuevo Saldo")
            .Columns.Add("interesAbonoExtraordinario", "Intereses No Cobrados")
            .Columns.Add("saldointeres", "Saldo Intereses")
            .Columns("color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("saldo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("interes").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("abono").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("actual").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("saldointeres").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("saldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("interes").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("abono").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("actual").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("interesAbonoExtraordinario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("saldointeres").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("estatus").Hidden = True
            .Columns("saldo").Format = "###,##0"
            .Columns("abono").Format = "###,##0"
            .Columns("total").Format = "###,##0"
            .Columns("actual").Format = "###,##0"
            .Columns("interesAbonoExtraordinario").Format = "###,##0"
            .Columns("saldointeres").Format = "###,##0"
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdDatosAbono.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.CopyWithHeaders
        grdDatosAbono.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatosAbono.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatosAbono.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        band.Columns("color").Width = 15
        Dim tmpSummary As SummarySettings
        Try
            If band.Summaries.Exists("sumainteres") Then
                tmpSummary = band.Summaries("sumainteres")
                band.Summaries.Remove(tmpSummary)
                tmpSummary = band.Summaries("sumaabono")
                band.Summaries.Remove(tmpSummary)
                tmpSummary = band.Summaries("sumacaja")
                band.Summaries.Remove(tmpSummary)

                tmpSummary = band.Summaries("sumainteresNoCobrados")
                band.Summaries.Remove(tmpSummary)

            End If
            band.SummaryFooterCaption = "Totales"
            tmpSummary = band.Summaries.Add("sumainteres", SummaryType.Sum, band.Columns("interes"))
            tmpSummary.DisplayFormat = "{0:###,##0}"
            tmpSummary.Appearance.TextHAlign = HAlign.Right
            tmpSummary = band.Summaries.Add("sumasaldo", SummaryType.Sum, band.Columns("abono"))
            tmpSummary.DisplayFormat = "{0:###,##0}"
            tmpSummary.Appearance.TextHAlign = HAlign.Right
            tmpSummary = band.Summaries.Add("sumacaja", SummaryType.Sum, band.Columns("total"))
            tmpSummary.DisplayFormat = "{0:###,##0}"
            tmpSummary.Appearance.TextHAlign = HAlign.Right
            tmpSummary = band.Summaries.Add("sumainteresNoCobrados", SummaryType.Sum, band.Columns("interesAbonoExtraordinario"))
            tmpSummary.DisplayFormat = "{0:###,##0}"
            tmpSummary.Appearance.TextHAlign = HAlign.Right

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CargarInformacionGeneral()
        Dim ObjBU As New Negocios.ColaboradoresBU
        Dim Datos As New Entidades.Colaborador
        Dim ObjBULaboral As New Negocios.ColaboradorLaboralBU
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        Dim EntidadArchivos As New Entidades.ColaboradorExpediente

        EntidadArchivos = ObjArchivosBU.CredencialColaborador(idColaborador)

        Datos = ObjBU.BuscarColaboradorGeneral(idColaborador)
        lblNombre.Text = Datos.PNombre + " " + Datos.PApaterno + " " + Datos.PAmaterno
        Try

            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            Dim Carpeta As String = ""


            Dim tabla() As String
            tabla = Split(EntidadArchivos.PCarpeta, "\")

            For n = 0 To UBound(tabla, 1)
                Carpeta += tabla(n) + "/"
            Next

            Dim Stream As System.IO.Stream
            Stream = objFTP.StreamFile(Carpeta, EntidadArchivos.PNombreArchivo)
            PictureBox1.Image = Image.FromStream(Stream)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub CargarInformacionLaboral()
        Dim objBULaboral As New Negocios.ColaboradorLaboralBU
        Dim EntidadLaboral As New Entidades.ColaboradorLaboral
        Dim SemanaActiva As New ConsultarPrestamosBU

        EntidadLaboral = objBULaboral.buscarInformacionLaboral(idColaborador)
        Try
            NaveID = EntidadLaboral.PNaveId.PNaveId
            nombreNave = EntidadLaboral.PNaveId.PNombre
            lblPuesto.Text = EntidadLaboral.PPuestoId.PNombre
            lblDepartamento.Text = EntidadLaboral.PDepartamentoId.DNombre
            Semana = SemanaActiva.SemanaActiva(NaveID)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CalcularFuturosPagos(ByVal tipo As Integer)
        Dim saldoActual As Integer
        Dim ultimoAbonoFecha As Date
        Dim abono As Integer

        Dim objBU As New ConsultarPrestamosBU
        If tipo = 1 Then
            saldoActual = grdDatosAbono.Rows(grdDatosAbono.Rows.Count - 1).Cells("actual").Value
            ultimoAbonoFecha = grdDatosAbono.Rows(grdDatosAbono.Rows.Count - 1).Cells("fecha").Value
            abono = Pabbonos
        Else
            saldoActual = pMonto
            ultimoAbonoFecha = pfechas
            abono = Pabbonos
        End If

        Dim tipoInteres As String = objBU.obtenerTipoInteresSobrePrestamo(idColaborador, idPrestamo)
        Dim Interes As Double
        If tipoInteres = "S" Then
            Interes = objBU.obtenerInteresSobrePrestamo(idColaborador, idPrestamo)
        Else
            Interes = 0
        End If
        Dim pagoSemanalQuincenal As Int32 = 0
        pagoSemanalQuincenal = objBU.obtenerPagoSemanaQuincenal(idColaborador, idPrestamo)
        'pagoSemanalQuincenal = 7
        'Interes = 7 * (Interes / 30.4)
        Interes = pagoSemanalQuincenal * (Interes / 30.4)
        Interes = Interes / 100
        Dim totalinteres As Integer

        If saldoActual > 0 Then
            While saldoActual > 0
                Dim filaPres As UltraGridRow = grdDatosAbono.DisplayLayout.Bands(0).AddNew()
                totalinteres = saldoActual * Interes
                filaPres.Cells("saldo").Value = saldoActual.ToString("N0")
                If saldoActual > abono Then
                    saldoActual = saldoActual - (abono - totalinteres)
                Else
                    abono = saldoActual
                    totalinteres = 0
                    saldoActual = 0
                End If
                'ultimoAbonoFecha = ultimoAbonoFecha.AddDays(7)
                ultimoAbonoFecha = ultimoAbonoFecha.AddDays(pagoSemanalQuincenal)
                filaPres.Cells("color").Appearance.BackColor = Color.Yellow
                filaPres.Cells("estatus").Value = 0
                filaPres.Cells("fecha").Value = ultimoAbonoFecha.ToShortDateString

                filaPres.Cells("interes").Value = (totalinteres).ToString("N0")
                filaPres.Cells("abono").Value = (abono - totalinteres).ToString("N0")
                filaPres.Cells("total").Value = abono.ToString("N0")
                filaPres.Cells("actual").Value = saldoActual.ToString("N0")

                filaPres.Cells("saldointeres").Value = (InteresFila - totalinteres).ToString("N0")
                InteresFila = InteresFila - totalinteres
            End While
        End If

    End Sub

    Public Sub llenartabla()

        Dim ListaPagos As New List(Of PagosPrestamo)
        Dim objBU As New ConsultarPrestamosBU
        InteresFila = PInteresInicial
        Dim interesAbonoExtraordinario As Int64 = 0

        Dim dtDatosInicializar As New DataTable
        dtDatosInicializar.Columns.Add("color")
        dtDatosInicializar.Columns.Add("fecha")
        dtDatosInicializar.Columns.Add("saldo")
        dtDatosInicializar.Columns.Add("interes")
        dtDatosInicializar.Columns.Add("abono")
        dtDatosInicializar.Columns.Add("total")
        dtDatosInicializar.Columns.Add("actual")
        dtDatosInicializar.Columns.Add("interesAbonoExtraordinario")
        dtDatosInicializar.Columns.Add("saldointeres")
        grdDatosAbono.DataSource = dtDatosInicializar
        ListaPagos = objBU.ListaPagosPRestamo(PIDColaborador, pIdPrestamo)

        For Each objeto As PagosPrestamo In ListaPagos
            Dim filaPres As UltraGridRow = grdDatosAbono.DisplayLayout.Bands(0).AddNew()
            interesAbonoExtraordinario = 0

            filaPres.Cells("color").Appearance.BackColor = Color.Green
            filaPres.Cells("fecha").Value = objeto.pFechaPago.ToShortDateString
            filaPres.Cells("saldo").Value = objeto.PSaldoAnterior.ToString("N0")
            filaPres.Cells("interes").Value = objeto.PInteres.ToString("N0")
            filaPres.Cells("abono").Value = objeto.PAbonoCapital.ToString("N0")
            filaPres.Cells("total").Value = (objeto.PAbonoCapital + objeto.PInteres).ToString("N0")
            filaPres.Cells("actual").Value = objeto.PSaldoNuevo.ToString("N0")
            filaPres.Cells("estatus").Value = 1
            'If objeto.PTipoAbono.ToString.Trim = "A" Then
            '    filaPres.Cells("saldointeres").Value = (InteresFila - objeto.PInteres).ToString("N0")
            '    InteresFila = InteresFila - objeto.PInteres
            'Else
            '    filaPres.Cells("saldointeres").Value = objeto.PIntAbonoExtra.ToString("N0")
            '    filaPres.Cells("saldointeres").Appearance.BackColor = Color.FromArgb(244, 176, 132)
            'End If
            'SE CREA COLUMNA NUEVA 
            filaPres.Cells("interesAbonoExtraordinario").Value = objeto.PIntAbonoExtra.ToString("N0")
            interesAbonoExtraordinario = CInt(objeto.PIntAbonoExtra)
            filaPres.Cells("saldointeres").Value = ((InteresFila - objeto.PInteres) - interesAbonoExtraordinario).ToString("N0")
            InteresFila = InteresFila - objeto.PInteres - objeto.PIntAbonoExtra
            If objeto.PTipoAbono.ToString.Trim = "C" Then
                filaPres.Cells("saldointeres").Appearance.BackColor = Color.FromArgb(244, 176, 132)
                filaPres.Cells("interesAbonoExtraordinario").Appearance.BackColor = Color.FromArgb(244, 176, 132)
            End If
        Next

    End Sub

    Private Sub Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Me.Cursor = Cursors.WaitCursor
        imprimirReporteNave()
        Me.Cursor = Cursors.Default

    End Sub

    Public Sub imprimirReporteNave()
        Dim Destajos = New DataSet("pagos")
        Dim ticketsBU As New Negocios.TicketsBU
        Dim tablaTickets As New DataTable("pagosPrestamos")
        tablaTickets = obtnerValoresDatagrid()

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_PRES_COLABORADOR")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre.Trim + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()

        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)

        reporte("Nave") = nombreNave
        reporte("NombreColaborador") = lblNombre.Text
        reporte("Puesto") = lblPuesto.Text
        reporte("Departamento") = lblDepartamento.Text
        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToUpper

        Destajos.Tables.Add(tablaTickets)

        reporte.RegData(Destajos)
        reporte.Show()
    End Sub

    Public Function obtnerValoresDatagrid() As DataTable
        Dim tabladatos As New DataTable
        Dim band As UltraGridBand = grdDatosAbono.DisplayLayout.Bands(0)
        tabladatos.Columns.Add("Consecutivo", System.Type.GetType("System.Int32"))
        For Each column As UltraGridColumn In band.Columns
            tabladatos.Columns.Add(column.Key, column.DataType)
        Next
        Dim i As Integer = 0
        Dim contador As Integer = 1
        For Each row As UltraGridRow In grdDatosAbono.Rows
            Dim cellValues As List(Of Object) = New List(Of Object)(row.Cells.Count)
            For Each cell As UltraGridCell In row.Cells
                If i = 0 Then
                    cellValues.Add(contador)
                    Try
                        cellValues.Add(CDbl(cell.Value))
                    Catch ex As Exception
                        cellValues.Add(cell.Value)
                    End Try
                    i = 1
                Else
                    Try
                        cellValues.Add(CDbl(cell.Value))
                    Catch ex As Exception
                        cellValues.Add(cell.Value)
                    End Try

                End If

            Next
            i = 0
            contador += 1
            tabladatos.Rows.Add(cellValues.ToArray())
        Next
        Return tabladatos
        Return tabladatos
    End Function

End Class