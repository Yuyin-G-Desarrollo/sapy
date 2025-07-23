Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Net
Imports Stimulsoft.Report.Components
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports System.Reflection
Imports Tools
Imports Programacion.Negocios

Public Class ReportesProduccionForm

#Region "Properties"
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim tabla As New DataTable

    Public Enum Reportes
        <Description("Concentrado de casco por proveedor")>
        Concentrado_Casco_Por_Proveedor = 1
        <Description("Concentrado de planta por proveedor")>
        Concentrado_Planta_Por_Proveedor = 2
        <Description("Concentrado de plantilla por proveedor")>
        Concentrado_Plantilla_Por_Proveedor = 3
        <Description("Concentrado de suela por proveedor")>
        Concentrado_Suela_Por_Proveedor = 4
        <Description("Desglosado de casco")>
        Desglosado_Casco = 5
        <Description("Orden de Pedido Desglosado para corte")>
        Orden_Pedido_Desglosado_Para_Corte = 6
        <Description("Orden de producción")>
        Orden_Produccion = 7
        <Description("Orden de producción F/S")>
        Orden_Produccion_Factura_Remision = 32
        <Description("Programa de corte de forro de cerdo")>
        Programa_Corte_Forro = 8
        <Description("Programa de corte de forro sintentico")>
        Programa_Corte_Forro_Sintetico = 9
        <Description("Programa de corte de piel")>
        Programa_Corte_Piel = 10
        <Description("Programa de corte de piel sintetica")>
        Programa_Corte_Piel_Sintetica = 11
        <Description("Desglosado de planta")>
        Desglosado_Planta = 12
        <Description("Desglosado de suela")>
        Desglosado_Suela = 13
        <Description("Reporte de Agujeta")>
        Reporte_Agujeta = 14
        <Description("Desglosado de Plantilla")>
        DesglosadodePlantilla = 15
        <Description("Reporte de Plastisol")>
        Reporte_Plastisol = 16
        <Description("Reporte de Caja")>
        Reporte_Caja = 17
        <Description("Reporte de Casco Contrafuerte")>
        Reporte_Casco_Contrafuerte = 18
        <Description("Reporte de Herrajes")>
        Reporte_Herrajes = 19
        <Description("Reporte de Planta")>
        Reporte_Planta = 20
        <Description("Reporte de Suela")>
        Reporte_Suela = 21
        <Description("Desglosado de Contrafuerte")>
        Desglosado_Contrafuerte = 22
        <Description("Concentrado de contrafuerte por proveedor")>
        Concentrado_Contrafuerte_Por_Proveedor = 23
        <Description("Reporte de Tacón")>
        Reporte_Tacon = 24
        <Description("Concentrado de Tacón por Proveedor")>
        Reporte_Concentrado_Tacon_Proveedor = 25
        <Description("Desglosado de Tacón")>
        Desglosado_Tacon = 26
        <Description("Concentrado de Herraje por Proveedor")>
        Concentrado_Herraje_por_Proveedor = 27
        <Description("Reporte de Plantilla")>
        Reporte_Plantilla = 28
        <Description("Reporte Explosión de Aplicaciones")>
        Reporte_Explosion_Aplicaciones = 29
        <Description("Concentrado de Corte de Piel y Forro de Cerdo")>
        Concentrado_Corte_Piel_Forro = 30
        <Description("Concentrado de Corte de Piel y Forro Sintético")>
        Concentrado_Corte_Piel_Forro_Sintetico = 31
        <Description("Orden de Pedido Desglosado para Maquila")>
        Orden_Pedido_Desglosado_Para_Maquila = 33
        '<Description("Desglosado de Caja")>
        'Desglosado_Caja = 29
        <Description("Desglosado de etiquetado especial")>
        Reporte_Etiquetado_Especial = 34

    End Enum


#End Region

#Region "Constructors"

#End Region

#Region "Events"
    Private Sub ReportesProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        LlenarListasNaves()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Reportes de Producción", "NAVE") Then
            'crearTablaReportesNave()
            crearTablaReportsNave()
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Reportes de Producción", "PPCP") Then
            crearTablaReportesPPCP()
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Reportes de Producción", "PROD_REPORT_ACTUALIZARLOTES") Then
            btnActualizarLotes.Visible = True
            lblTextoActualizarLotes.Visible = True
        Else
            btnActualizarLotes.Visible = False
            lblTextoActualizarLotes.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Reportes de Producción", "REP_SUELAS") Then
            btnReporteGeneralSuelas.Visible = True
            lblReporteGeneralSuelas.Visible = True
        Else
            btnReporteGeneralSuelas.Visible = False
            lblReporteGeneralSuelas.Visible = False
        End If



        llenarComoboReportes()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReportes.DataSource = Nothing
        cbxNave.SelectedValue = 0
        cbxReporte.SelectedValue = 0
        dtpPrograma.Text = Date.Today.ToString
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim obj As New ReportesBU
        Dim nave As Integer = 0
        ' Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0
        Dim fecha As String = ""
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        Dim comercializadora As Integer = 0
        Dim comercializadoraTexto As String = ""
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        '' Dar formato a la fecha
        Dim dateValue As Date = dtpPrograma.Value.ToShortDateString
        Dim DAY = dateValue.DayOfWeek()
        Dim NUMEROMES = dateValue.Month()
        Dim dia As String = ""
        Dim mes As String = ""
        Dim fechaDias As String = ""
        Dim Logo As String = ""
        Logo = Tools.Controles.ObtenerLogoNave(cbxNave.SelectedValue)
        'Logo = Tools.Controles.ObtenerLogoNave(3)

        Select Case DAY
            Case 1
                dia = "Lunes"
            Case 2
                dia = "Martes"
            Case 3
                dia = "Miércoles"
            Case 4
                dia = "Jueves"
            Case 5
                dia = "Viernes"
            Case 6
                dia = "Sábado"
        End Select

        Select Case NUMEROMES
            Case 1
                mes = "Enero"
            Case 2
                mes = "Febrero"
            Case 3
                mes = "Marzo"
            Case 4
                mes = "Abril"
            Case 5
                mes = "Mayo"
            Case 6
                mes = "Junio"
            Case 7
                mes = "Julio"
            Case 8
                mes = "Agosto"
            Case 9
                mes = "Septiembre"
            Case 10
                mes = "Octubre"
            Case 11
                mes = "Noviembre"
            Case 12
                mes = "Diciembre"
        End Select

        fechaDias = dia & ",  " & dateValue.ToString("dd") & "  " & mes & " de " & dateValue.ToString("yyyy")
        ''******************************************************************************************************************

        If cbxNave.SelectedValue = 0 Then                               'Válida que se tenga seleccionada una nave
            lblNave.ForeColor = Drawing.Color.Red
            objAdvertencia.mensaje = "Seleccione una nave"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        ElseIf cbxReporte.SelectedValue = 0 Then                        'válida que este seleccionado un reporte
            lblReporte.ForeColor = Drawing.Color.Red
            objAdvertencia.mensaje = "Seleccione un reporte para mostrar"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        Else
            fecha = dtpPrograma.Value.ToShortDateString

            'Se comenta código para obtener el IdNaveSicy
            'idSicy = obj.ConsultarNaveSicy(cbxNave.SelectedValue)
            'nave = idSicy.Rows(0).Item(0)

            'Se obtiene el valor de la nave del combo previamente llenado
            nave = cbxNave.SelectedValue

            ''******************************************Creación de los reportes segun sea el caso
            'If grdReportes.Rows.Count = 0 Then
            '    objAdvertencia.mensaje = "No hay información para mostrar"
            '    objAdvertencia.ShowDialog()
            'Else



            Select Case cbxReporte.SelectedValue
                Case 1 'Concentrado de casco por proveedor
                    'Buscar id clasificación de casco
                    ImpimirConcentradoCascoPorProveedor(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 2 'Concentrado de planta por proveedor
                    ImprimirConcentradoPlantaPorProveedor(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 3 'Concentrado de plantilla por proveedor
                    ImprimirConcentradoPlantillaPorProveedor(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 4 'Concentrado de suela por proveedor
                    ImprimirConcentradoSuelaPorProveedor(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 5 'Desglosado de casco 
                    ImprimirDesglosadoCasco(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 6 'Orden de pedido desglosado para corte
                    ImprimirOrdenPedidoDesglosadoCorte(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 7 'Orden de producción
                    ImprimirOrdenDeProduccion(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 8 'Programa corte  de forro
                    ImprimirProgramaCorteForro(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 9 'Programa corte de sinteticos
                    ImprimirProgramaCorteForroSintetico(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 10 'Programa corte  de piel
                    ImprimirProgramaCortePiel(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 11 'Programa corte de sinteticos
                    ImprimirProgramaCortePielSintetico(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 12 'Relación desglosada de planta
                    ImprimirDesglosadoPlanta(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 13 'Relación desglosada de suela
                    ImprimirDesglosadoSuela(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 14 'Reporte de agujeta
                    ImprimirReporteAgujeta(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 15 'Desglosado de plantilla
                    ImprimirDesglosadodePlantilla(fecha, nave, clasificacion)
                    '********************************Fin de creación de reporte
                Case 16 'Reporte de plastisol
                    ImprimirReportePlastisol(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 17 'Reporte para caja
                    ImprimirReporteCaja(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 18 'Reporte para casco y contrafuerte
                    ImprimirReporteCascoContrafuerte(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 19 'Reporte para herrajes
                    ImprimirReporteHerrajes(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 20 'Reporte para planta
                    ImprimirReportePlanta(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 21 'Reporte para suela
                    ImprimirReporteSuela(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 22 'Desglosado contrafuerte
                    ImprimirDesglosadoContrafuerte(fecha, nave)
                    '********************************Fin de creación de reporte
                Case 23  'Concentrado de casco por proveedor
                    ImprimirConcentradoContrafuerte(fecha, nave)
                Case 24 'Reporte para Tacón 
                    ImprimirReporteTacon(fecha, nave, clasificacion)
                Case 25 'Concentrado de Tacón por Proveedor
                    ImprimirConcentradoTaconPorProveedor(fecha, nave)
                Case 26 'Relación Desglosado de Tacón
                    ImprimirDesglosadoTacon(fecha, nave)
                Case 27 'Concentrado de Herraje por Proveedor 
                    ImprimirConcentradoHerrajeporProveedor(fecha, nave)
                Case 28 'Reporte Plantilla
                    ImprimirReportePlantilla(fecha, nave, clasificacion)
                Case 29 'Reporte Plantilla
                    ImprimirReporteExplosionAplicaciones(fecha, nave)
                Case 30
                    ImprimirConcentradoCortePielForro(fecha, nave, False)
                Case 31
                    ImprimirConcentradoCortePielForro(fecha, nave, True)
                Case 32
                    ImprimirOrdenDeProduccionFacturadoRemisionado(fecha, nave)
                Case 33
                    ImprimirDesglosadoMaquila(fecha, nave)
                Case 34
                    ImprimirDesglosadoEtiquetadoEspecial(fecha, nave, 0, comercializadoraTexto)
                    'Case 29 'Desglosado de Caja
                    '   ImprimirDesglosadodeCaja(fecha, nave, clasificacion)

                    '********************************Fin de creación de reporte
            End Select
            ''****************************************** fin de creación de reportes segun sea el caso
        End If
        'End If

    End Sub

    Public Sub ImprimirDesglosadoEtiquetadoEspecial(ByVal fecha As Date,
                                                    ByVal nave As Integer,
                                                    ByVal comercializadora As Integer,
                                                    ByVal comercializadoraTexto As String)
        Try
            Dim pares As Integer = 0
            Dim lotes As Integer = 0
            Dim objCartaInformativaBU As New CartasInformativasBU
            Tools.MostrarEspere(Me)
            Dim dtLotesEtiquetadoEspecial As DataTable = objCartaInformativaBU.ConsultarEtiquetadoEspecial(fecha, nave, comercializadora)
            Tools.MostrarEspere(Me)
            Try
                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("DESGLOSE_ETIQUETADO_LOTE")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                       EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                reporte("log") = GetRutaLogoPorNave(nave)
                reporte("titulo") = IIf(comercializadoraTexto = "N/A", "", "(" + comercializadoraTexto + ")")
                reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                'reporte("material") = "SUELA"
                'reporte("tituloC5") = "COLECCIÓN"
                reporte.RegData(dtLotesEtiquetadoEspecial)
                reporte.Show()
                '*********************
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New ReportesBU
        Dim nave As Integer = 0
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        ' Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0
        Dim fecha As String = ""
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable
        Dim reporte As Object
        Dim dtDatosLotes As New DataTable

        lblDcm.Visible = False
        lblDcmResultado.Visible = False
        pnlReportesPieles.Visible = False
        pnlReportesGenerales.Visible = True

        If cbxNave.SelectedValue = 0 Then                               'Válida que se tenga seleccionada una nave
            'lblNave.ForeColor = Drawing.Color.Red
            'objAdvertencia.mensaje = "Seleccione una nave"
            'objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            'objAdvertencia.ShowDialog()
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "Seleccione una nave")
        ElseIf cbxReporte.SelectedValue = 0 Then                        'válida que este seleccionado un reporte
            'lblReporte.ForeColor = Drawing.Color.Red
            'objAdvertencia.mensaje = "Seleccione un reporte para mostrar"
            'objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            'objAdvertencia.ShowDialog()
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "Seleccione un reporte para mostrar")
        Else
            Tools.MostrarEspere(Me)

            fecha = dtpPrograma.Value.ToShortDateString

            'Se comenta código para obtener el IdNaveSicy
            'idSicy = obj.ConsultarNaveSicy(cbxNave.SelectedValue)
            'nave = idSicy.Rows(0).Item(0)

            'Se obtiene el valor de la nave del combo previamente llenado
            nave = cbxNave.SelectedValue

            reporte = GetEnumReporte(cbxReporte.SelectedValue)

            ''OBTENER LAS CANTIDADES DE LOTES EN SAY Y SICY - FECHAS DE LOTEO Y REPLICACIÓN

            dtDatosLotes = obj.ObtieneLotes_SAY_SICY(nave, fecha)

            lblLotesSAY.Text = dtDatosLotes.Rows(0).Item("LotesEnSICY").ToString
            lblLotesSICY.Text = dtDatosLotes.Rows(0).Item("LotesEnSAY").ToString
            lblUltimaFechaLoteo.Text = dtDatosLotes.Rows(0).Item("UltimaFechaLoteo").ToString
            lblUltimaFechaReplica.Text = dtDatosLotes.Rows(0).Item("FechaUltimaReplica").ToString


            ''******************************************Creación de los reportes segun sea el caso
            Select Case reporte 'cbxReporte.SelectedValue
                Case Reportes.Concentrado_Casco_Por_Proveedor '1 'Concentrado de casco por proveedor
                    ConcentradoCascoPorProveedor(fecha, nave)
                Case Reportes.Concentrado_Planta_Por_Proveedor '2 'Concentrado de planta por proveedor
                    ConcentradoPlantaProveedor(fecha, nave)
                Case Reportes.Concentrado_Plantilla_Por_Proveedor '3 'Concentrado de plantilla por proveedor
                    ConcentradoPlantillaProveedor(fecha, nave)
                Case Reportes.Concentrado_Suela_Por_Proveedor '4 'Concentrado de suela por proveedor
                    ConcentradoSuelaProveedor(fecha, nave)
                Case Reportes.Desglosado_Casco '5 'Desglosado de casco 
                    DesglosadoCasco(fecha, nave)
                Case Reportes.Orden_Pedido_Desglosado_Para_Corte '6 'Orden de pedido desglosado para corte
                    OrdenDesglosadoCorte(fecha, nave)
                Case Reportes.Orden_Produccion '7 'Orden de producción
                    OrdenProduccion(fecha, nave)
                Case Reportes.Programa_Corte_Forro '8 'Programa corte  de forro
                    ProgramaCorteForro(fecha, nave)
                Case Reportes.Programa_Corte_Forro_Sintetico '9 'Programa corte de sinteticos
                    ProgramaCorteSinteticos(fecha, nave)
                Case Reportes.Programa_Corte_Piel '10 'Programa corte  de piel
                    ProgramaCortePiel(fecha, nave)
                Case Reportes.Programa_Corte_Piel_Sintetica '11 'Programa corte de sinteticos
                    ProgramaCortePielSinteticos(fecha, nave)
                Case Reportes.Desglosado_Planta '12 'Relación desglosada de planta
                    DesglosadoPlanta(fecha, nave, clasificacion)
                Case Reportes.Desglosado_Suela '13 'Relación desglosada de suela
                    DesglosadoSuela(fecha, nave)
                Case Reportes.Reporte_Agujeta '14 'Reporte de agujeta
                    ReporteAgujeta(fecha, nave)
                Case Reportes.DesglosadodePlantilla '15 'Reporte de plantilla
                    DesglosadodePlantilla(fecha, nave, clasificacion)
                Case Reportes.Reporte_Plastisol '16 'Reporte de plastisol
                    ReportePlastisol(fecha, nave)
                Case Reportes.Reporte_Caja '17 'Reporte para caja
                    ReporteCaja(fecha, nave, clasificacion)
                Case Reportes.Reporte_Casco_Contrafuerte '18 'Reporte para casco y contrafuerte
                    ReporteCascoContrafuerte(fecha, nave, clasificacion, clasificacion2)
                Case Reportes.Reporte_Herrajes '19 'Reporte para herrajes
                    ReporteHerraje(fecha, nave)
                Case Reportes.Reporte_Planta '20 'Reporte para planta
                    ReportePlanta(fecha, nave, clasificacion)
                Case Reportes.Reporte_Suela '21 'Reporte para suela
                    ReporteSuela(fecha, nave)
                Case Reportes.Desglosado_Contrafuerte '22 'Desglosado de contrafuerte
                    DesglosadoContrafuerte(fecha, nave, clasificacion)
                Case Reportes.Concentrado_Contrafuerte_Por_Proveedor '23 'Concentrado de contrafuerte por proveedor
                    ConcentrandoContrafuertePorProveedor(fecha, nave)
                Case Reportes.Reporte_Tacon '24 Reporte de Tacon
                    ReporteTacon(fecha, nave, clasificacion)
                Case Reportes.Reporte_Concentrado_Tacon_Proveedor
                    ConcentradoTaconPorProveedor(fecha, nave) '25 Concentrado de Tacón por Proveedor
                Case Reportes.Desglosado_Tacon
                    DesglosadoTacon(fecha, nave, clasificacion) '26 Desglosado de Tacón
                Case Reportes.Concentrado_Herraje_por_Proveedor
                    ConcentradoHerrajePorProveedor(fecha, nave) '27 Concentrado de Herraje por Proveedor 
                Case Reportes.Reporte_Plantilla
                    ReportePlantilla(fecha, nave, clasificacion)
                Case Reportes.Reporte_Explosion_Aplicaciones
                    reporteExplosionAplicaciones(fecha, nave)
                Case Reportes.Concentrado_Corte_Piel_Forro
                    ConcentradoCortePielForro(fecha, nave, False)
                Case Reportes.Concentrado_Corte_Piel_Forro_Sintetico
                    ConcentradoCortePielForro(fecha, nave, True)
                Case Reportes.Orden_Produccion_Factura_Remision
                    OrdenProduccionFacturadoYRemisionado(fecha, nave)
                Case Reportes.Orden_Pedido_Desglosado_Para_Maquila
                    DesglosadoMaquila(fecha, nave)
                    'Case Reportes.Desglosado_Caja  '29 Desglosado de Caja
                    '   DesglosadoDeCaja(fecha, nave, clasificacion)

            End Select

            'For value = 0 To grdReportes.Rows.Count - 1
            '    If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
            '        pares = pares + grdReportes.Rows(value).Cells("Pares").Value
            '        lotes = lotes + grdReportes.Rows(value).Cells("Lotes").Value
            '    End If
            'Next

            'lblLotesResultado.Text = lotes
            'lblParesResultado.Text = Format(pares, "##,##0")

            'Totales(reporte)
            Tools.TerminarEspere(Me)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        'Dim form As New ConsultaPreOrdenDeCompraForm
        'form.ShowDialog()
        'reporteTarjetaDeProduccion(5975, 3)
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        'Dim form As New ExplosionMaterialesForm
        'form.ShowDialog()
    End Sub

    Private Sub grdReportes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdReportes.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
                If grdMateriales.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdMateriales.ActiveCell = nextRow.Cells(grdMateriales.ActiveCell.Column)
                    e.Handled = True
                    grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
                If grdMateriales.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdMateriales.ActiveCell = nextRow.Cells(grdMateriales.ActiveCell.Column)
                    e.Handled = True
                    grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
                If grdMateriales.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdMateriales.ActiveCell = nextRow.Cells(grdMateriales.ActiveCell.Column)
                    e.Handled = True
                    grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdProgramaCorte.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdProgramaCorte.DisplayLayout.Bands(0)
                If grdProgramaCorte.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdProgramaCorte.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdProgramaCorte.ActiveCell = nextRow.Cells(grdProgramaCorte.ActiveCell.Column)
                    e.Handled = True
                    grdProgramaCorte.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdProgramaCorte.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdProgramaCorte.DisplayLayout.Bands(0)
                If grdProgramaCorte.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdProgramaCorte.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdProgramaCorte.ActiveCell = nextRow.Cells(grdProgramaCorte.ActiveCell.Column)
                    e.Handled = True
                    grdProgramaCorte.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdProgramaCorte.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdProgramaCorte.DisplayLayout.Bands(0)
                If grdProgramaCorte.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdProgramaCorte.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdProgramaCorte.ActiveCell = nextRow.Cells(grdProgramaCorte.ActiveCell.Column)
                    e.Handled = True
                    grdProgramaCorte.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdReportes.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdReportes.DisplayLayout.Bands(0)
                If grdReportes.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdReportes.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdReportes.ActiveCell = nextRow.Cells(grdReportes.ActiveCell.Column)
                    e.Handled = True
                    grdReportes.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdReportes.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdReportes.DisplayLayout.Bands(0)
                If grdReportes.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdReportes.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdReportes.ActiveCell = nextRow.Cells(grdReportes.ActiveCell.Column)
                    e.Handled = True
                    grdReportes.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdReportes.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdReportes.DisplayLayout.Bands(0)
                If grdReportes.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdReportes.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdReportes.ActiveCell = nextRow.Cells(grdReportes.ActiveCell.Column)
                    e.Handled = True
                    grdReportes.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbxNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNave.SelectedIndexChanged
        'pnlReportesPieles.Visible = False
        'pnlReportesGenerales.Visible = True
        'grdReportes.DataSource = Nothing
        'grdProgramaCorte.DataSource = Nothing
        'grdMateriales.DataSource = Nothing
        'lblParesResultado.Text = 0
        'lblLotesResultado.Text = 0
        'lblDcmResultado.Text = 0
        LimpiarPantalla()
    End Sub

    Private Sub dtpPrograma_ValueChanged(sender As Object, e As EventArgs) Handles dtpPrograma.ValueChanged
        'pnlReportesPieles.Visible = False
        'pnlReportesGenerales.Visible = True
        'grdReportes.DataSource = Nothing
        'grdProgramaCorte.DataSource = Nothing
        'grdMateriales.DataSource = Nothing
        'lblParesResultado.Text = 0
        'lblLotesResultado.Text = 0
        'lblDcmResultado.Text = 0
        LimpiarPantalla()
    End Sub

    Private Sub cbxReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxReporte.SelectedIndexChanged
        'pnlReportesPieles.Visible = False
        'pnlReportesGenerales.Visible = True
        'grdReportes.DataSource = Nothing
        'grdProgramaCorte.DataSource = Nothing
        'grdMateriales.DataSource = Nothing
        'lblParesResultado.Text = 0
        'lblLotesResultado.Text = 0
        'lblDcmResultado.Text = 0
        LimpiarPantalla()
    End Sub

#End Region

#Region "Private Methods"
    Private Sub LimpiarPantalla()
        pnlReportesPieles.Visible = False
        pnlReportesGenerales.Visible = True
        grdReportes.DataSource = Nothing
        grdProgramaCorte.DataSource = Nothing
        grdMateriales.DataSource = Nothing
        lblParesResultado.Text = 0
        lblLotesResultado.Text = 0
        lblDcmResultado.Text = 0
        lblLotesSICY.Text = "-"
        lblUltimaFechaLoteo.Text = "-"
        lblLotesSAY.Text = "-"
        lblUltimaFechaReplica.Text = "-"

    End Sub

    Private Sub NuevoReporteTabla(tabla As DataTable, id As Int32, reporte As String)
        Dim row As DataRow = tabla.NewRow()
        row("Id") = id
        row("Reporte") = reporte
        tabla.Rows.Add(row)
    End Sub

    Private Sub crearTablaReportsNave()
        'Dim reporte
        tabla.Columns.Add("Id")
        tabla.Columns.Add("Reporte")

        Dim row As DataRow = tabla.NewRow()
        row("Id") = 0
        row("Reporte") = ""
        tabla.Rows.Add(row)

        For Each reporteEnum As Reportes In System.Enum.GetValues(GetType(Reportes))
            NuevoReporteTabla(tabla, CInt(reporteEnum), GetEnumDescription(reporteEnum).ToUpper)
            'reporte = GetEnumReporte(CInt(reporteEnum))
        Next
    End Sub

    Private Function GetEnumReporte(id As Int32) As Reportes
        Return DirectCast([Enum].Parse(GetType(Reportes), id), Reportes)
    End Function

    ''' <summary>
    ''' Suma los totales tanto de pares y lotes segun sea el reporte
    ''' </summary>
    ''' <param name="reporte">Reporte</param>
    ''' <remarks></remarks>
    Private Sub Totales(ByVal reporte As Reportes)
        Dim pares As Integer = 0
        Dim lotes As Integer = 0
        Dim sumarCantidadesLotes As Boolean = False

        If ((reporte = Reportes.Concentrado_Casco_Por_Proveedor) Or (reporte = Reportes.Concentrado_Contrafuerte_Por_Proveedor) Or
           (reporte = Reportes.Concentrado_Planta_Por_Proveedor) Or (reporte = Reportes.Concentrado_Plantilla_Por_Proveedor) Or
           (reporte = Reportes.Concentrado_Suela_Por_Proveedor)) Then
            sumarCantidadesLotes = True
        Else
            sumarCantidadesLotes = False
        End If

        For value = 0 To grdReportes.Rows.Count - 1
            If CStr(grdReportes.Rows(value).Cells("Pares").Value) <> "" Then
                pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                If (sumarCantidadesLotes) Then
                    lotes = lotes + grdReportes.Rows(value).Cells("Lotes").Value
                Else
                    lotes += 1
                End If
            End If
        Next

        If (reporte <> Reportes.Programa_Corte_Forro And reporte <> Reportes.Programa_Corte_Piel And
            reporte <> Reportes.Programa_Corte_Piel_Sintetica And reporte <> Reportes.Programa_Corte_Forro_Sintetico) Then
            lblLotesResultado.Text = lotes
            lblParesResultado.Text = pares.ToString("n0")
        End If

    End Sub

    ''' <summary>
    ''' Obtiene la descripción de los enumerados
    ''' </summary>
    ''' <param name="EnumConstant">Tipo de Enumerado</param>
    ''' <returns>Cadena de la descripción</returns>
    ''' <remarks></remarks>
    Private Function GetEnumDescription(ByVal EnumConstant As [Enum]) As String
        Dim fi As FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
        Dim attr() As DescriptionAttribute =
                      DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute),
                      False), DescriptionAttribute())

        If attr.Length > 0 Then
            Return attr(0).Description
        Else
            Return EnumConstant.ToString()
        End If
    End Function
#End Region

#Region "Public Methods"
    Public Sub LlenarListasNaves()
        cbxNave = Tools.Controles.ComboNavesSegunUsuario(cbxNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        'cbxNave = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cbxNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Public Sub crearTablaReportesNave()
        tabla.Columns.Add("Id")
        tabla.Columns.Add("Reporte")
        Dim row As DataRow = tabla.NewRow()
        row("Id") = 0
        row("Reporte") = ""
        tabla.Rows.Add(row)
        Dim row1 As DataRow = tabla.NewRow()
        row1("Id") = 1
        row1("Reporte") = "Concentrado de casco por proveedor".ToUpper
        tabla.Rows.Add(row1)
        Dim row23 As DataRow = tabla.NewRow()
        row23("Id") = 23
        row23("Reporte") = "Concentrado de contrafuerte por proveedor".ToUpper
        tabla.Rows.Add(row23)
        Dim row25 As DataRow = tabla.NewRow()
        row25("Id") = 25
        row25("Reporte") = "Concentrado de Corte de Piel y Forro de Cerdo".ToUpper
        tabla.Rows.Add(row25)
        Dim row26 As DataRow = tabla.NewRow()
        row26("Id") = 26
        row26("Reporte") = "Concentrado de Corte de Piel y Forro Sintético".ToUpper
        tabla.Rows.Add(row26)
        Dim row2 As DataRow = tabla.NewRow()
        row2("Id") = 2
        row2("Reporte") = "Concentrado de planta por proveedor".ToUpper
        tabla.Rows.Add(row2)
        Dim row3 As DataRow = tabla.NewRow()
        row3("Id") = 3
        row3("Reporte") = "Concentrado de plantilla por proveedor".ToUpper
        tabla.Rows.Add(row3)
        Dim row4 As DataRow = tabla.NewRow()
        row4("Id") = 4
        row4("Reporte") = "Concentrado de suela por proveedor".ToUpper
        tabla.Rows.Add(row4)
        Dim row5 As DataRow = tabla.NewRow()
        row5("Id") = 5
        row5("Reporte") = "Desglosado de casco".ToUpper
        tabla.Rows.Add(row5)
        Dim row22 As DataRow = tabla.NewRow()
        row22("Id") = 22
        row22("Reporte") = "Desglosado de contrafuerte".ToUpper
        tabla.Rows.Add(row22)
        Dim row12 As DataRow = tabla.NewRow()
        row12("Id") = 12
        row12("Reporte") = "Desglosado de planta".ToUpper
        tabla.Rows.Add(row12)
        Dim row13 As DataRow = tabla.NewRow()
        row13("Id") = 13
        row13("Reporte") = "Desglosado de suela".ToUpper
        tabla.Rows.Add(row13)
        Dim row6 As DataRow = tabla.NewRow()
        row6("Id") = 6
        row6("Reporte") = "Orden de pedido desglosado para corte".ToUpper
        tabla.Rows.Add(row6)
        Dim row7 As DataRow = tabla.NewRow()
        row7("Id") = 7
        row7("Reporte") = "Orden de producción".ToUpper
        tabla.Rows.Add(row7)
        Dim row8 As DataRow = tabla.NewRow()
        row8("Id") = 8
        row8("Reporte") = "Programa corte de forro de cerdo".ToUpper
        tabla.Rows.Add(row8)
        Dim row9 As DataRow = tabla.NewRow()
        row9("Id") = 9
        row9("Reporte") = "Programa corte de forro sintético".ToUpper
        tabla.Rows.Add(row9)
        Dim row10 As DataRow = tabla.NewRow()
        row10("Id") = 10
        row10("Reporte") = "Programa corte de piel".ToUpper
        tabla.Rows.Add(row10)
        Dim row11 As DataRow = tabla.NewRow()
        row11("Id") = 11
        row11("Reporte") = "Programa corte de piel sintética".ToUpper
        tabla.Rows.Add(row11)
        Dim row14 As DataRow = tabla.NewRow()
        row14("Id") = 14
        row14("Reporte") = "Reporte de agujeta".ToUpper
        tabla.Rows.Add(row14)
        Dim row15 As DataRow = tabla.NewRow()
        row15("Id") = 15
        row15("Reporte") = "Reporte de plantilla".ToUpper
        tabla.Rows.Add(row15)
        Dim row16 As DataRow = tabla.NewRow()
        row16("Id") = 16
        row16("Reporte") = "Reporte de plastisol".ToUpper
        tabla.Rows.Add(row16)
        Dim row17 As DataRow = tabla.NewRow()
        row17("Id") = 17
        row17("Reporte") = "Reporte para caja".ToUpper
        tabla.Rows.Add(row17)
        Dim row18 As DataRow = tabla.NewRow()
        row18("Id") = 18
        row18("Reporte") = "Reporte para casco y contrafuerte".ToUpper
        tabla.Rows.Add(row18)
        Dim row19 As DataRow = tabla.NewRow()
        row19("Id") = 19
        row19("Reporte") = "Reporte para herrajes".ToUpper
        tabla.Rows.Add(row19)
        Dim row20 As DataRow = tabla.NewRow()
        row20("Id") = 20
        row20("Reporte") = "Reporte para planta".ToUpper
        tabla.Rows.Add(row20)
        Dim row21 As DataRow = tabla.NewRow()
        row21("Id") = 21
        row21("Reporte") = "Reporte para suela".ToUpper
        tabla.Rows.Add(row21)
        Dim row24 As DataRow = tabla.NewRow()
        row24("Id") = 24
        row24("Reporte") = "Reporte Explosión de Aplicaciones".ToUpper
        tabla.Rows.Add(row24)
        Dim row32 As DataRow = tabla.NewRow()
        row32("Id") = 32
        row32("Reporte") = "Reporte desglosado para Maquila".ToUpper
        tabla.Rows.Add(row32)

        Dim row34 As DataRow = tabla.NewRow()
        row32("Id") = 34
        row32("Reporte") = "Desglosado de etiquetado especial".ToUpper
        tabla.Rows.Add(row32)


    End Sub

    Public Sub crearTablaReportesPPCP()
        tabla.Columns.Add("Id")
        tabla.Columns.Add("Reporte")
        Dim row As DataRow = tabla.NewRow()
        row("Id") = 0
        row("Reporte") = ""
        tabla.Rows.Add(row)
        Dim row2 As DataRow = tabla.NewRow()
        row2("Id") = 2
        row2("Reporte") = "Concentrado de planta por proveedor".ToUpper
        tabla.Rows.Add(row2)
        Dim row4 As DataRow = tabla.NewRow()
        row4("Id") = 4
        row4("Reporte") = "Concentrado de suela por proveedor".ToUpper
        tabla.Rows.Add(row4)
        Dim row12 As DataRow = tabla.NewRow()
        row12("Id") = 12
        row12("Reporte") = "Desglosado de planta".ToUpper
        tabla.Rows.Add(row12)
        Dim row13 As DataRow = tabla.NewRow()
        row13("Id") = 13
        row13("Reporte") = "Desglosado de suela".ToUpper
        tabla.Rows.Add(row13)
        Dim row7 As DataRow = tabla.NewRow()
        row7("Id") = 7
        row7("Reporte") = "Orden de producción".ToUpper
        tabla.Rows.Add(row7)
        Dim row17 As DataRow = tabla.NewRow()
        row17("Id") = 17
        row17("Reporte") = "Reporte para caja".ToUpper
        tabla.Rows.Add(row17)
        Dim row20 As DataRow = tabla.NewRow()
        row20("Id") = 20
        row20("Reporte") = "Reporte para planta".ToUpper
        tabla.Rows.Add(row20)
        Dim row21 As DataRow = tabla.NewRow()
        row21("Id") = 21
        row21("Reporte") = "Reporte para suela".ToUpper
        tabla.Rows.Add(row21)

    End Sub

    Public Sub llenarComoboReportes()
        If Not tabla.Rows.Count = 0 Then
            cbxReporte.DisplayMember = "Reporte"
            cbxReporte.ValueMember = "Id"

            tabla.DefaultView.Sort = "Reporte ASC"
            cbxReporte.DataSource = tabla
        End If
    End Sub

#Region "Reportes"
#Region "Concentrados"
    Public Sub ConcentradoCascoPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        'Buscar id clasificación de casco
        Dim tablaClasificacion As DataTable
        Dim listaComponentes As New List(Of Integer)
        Dim clasificacion As Integer = 0
        Dim clasificacion2 As Integer = 0
        Dim tabla1 As New DataTable
        Dim tablaA As New DataTable
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)

        tabla1 = obj.ConsultaCasco1(fecha, nave, clasificacion)
        tablaA = obj.ConsultaCasco2(fecha, nave, clasificacion)
        tabla1.TableName = ""

        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("NO")
        TablaReporteConcentrado.Columns.Add("PARES")
        TablaReporteConcentrado.Columns.Add("LOTES")
        TablaReporteConcentrado.Columns.Add("CASCO")
        TablaReporteConcentrado.Columns.Add("CORRIDA")
        TablaReporteConcentrado.Columns.Add("PROVEEDOR")
        TablaReporteConcentrado.Columns.Add("12-14½")
        TablaReporteConcentrado.Columns.Add("15-17½")
        TablaReporteConcentrado.Columns.Add("18-19½")
        TablaReporteConcentrado.Columns.Add("20-21½")
        TablaReporteConcentrado.Columns.Add("22-24½")
        TablaReporteConcentrado.Columns.Add("25-27½")
        'TablaReporteConcentrado.Columns.Add("27-28½")
        TablaReporteConcentrado.Columns.Add("28-30")

        For value = 0 To tabla1.Rows.Count - 1
            Dim contador = 1
            Dim t1 As Integer? = Nothing
            Dim t2 As Integer? = Nothing
            Dim t3 As Integer? = Nothing
            Dim t4 As Integer? = Nothing
            Dim t5 As Integer? = Nothing
            Dim t6 As Integer? = Nothing
            Dim t7 As Integer? = Nothing
            Dim t8 As Integer? = Nothing
            Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
            'rowc("No") = tabla1.Rows(value).Item("No").ToString
            rowc("PARES") = tabla1.Rows(value).Item("Pares").ToString
            rowc("LOTES") = tabla1.Rows(value).Item("Lotes").ToString
            rowc("CASCO") = tabla1.Rows(value).Item("Material").ToString
            rowc("CORRIDA") = tabla1.Rows(value).Item("Corrida").ToString
            rowc("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor").ToString
            Dim cont = 4
            For value2 = 0 To 19
                If value2 < 5 Then
                Else
                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("12-14½") = t1
                        Case "13"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("12-14½") = t1
                        Case "14"
                            Dim o = tablaA.Rows(value).Item(value)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("12-14½") = t1
                        Case "15"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("15-17½") = t2
                        Case "16"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("15-17½") = t2
                        Case "17"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("15-17½") = t2
                        Case "18"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t3 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("18-19½") = t3
                        Case "19"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t3 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("18-19½") = t3
                        Case "20"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t4 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("20-21½") = t4
                        Case "21"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t4 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("20-21½") = t4
                        Case "22"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("22-24½") = t5
                        Case "23"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("22-24½") = t5
                        Case "24"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("22-24½") = t5
                        Case "25"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("25-27½") = t6
                        Case "26"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("25-27½") = t6
                        Case "27"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t7 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("25-27½") = t7
                        Case "28"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t7 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("28-30") = t7
                        Case "29"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("28-30") = t8
                        Case "30"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("28-30") = t8
                    End Select
                End If

            Next
            rowc("NO") = contador
            contador = contador + 1
            TablaReporteConcentrado.Rows.Add(rowc)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor
            grdReportes.DataSource = TablaReporteConcentrado

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("NO").Width = 30
                .Columns("PARES").Width = 50
                .Columns("LOTES").Width = 50
                .Columns("CASCO").Width = 300
                .Columns("CORRIDA").Width = 50
                .Columns("PROVEEDOR").Width = 300
                .Columns("12-14½").Width = 60
                .Columns("15-17½").Width = 60
                .Columns("18-19½").Width = 60
                .Columns("20-21½").Width = 60
                .Columns("22-24½").Width = 60
                .Columns("25-27½").Width = 60
                '.Columns("27-28½").Width = 60
                .Columns("28-30").Width = 60

                .Columns("NO").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12-14½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15-17½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18-19½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20-21½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22-24½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25-27½").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("27-28½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28-30").CellAppearance.TextHAlign = HAlign.Center

                .Columns("NO").CellActivation = Activation.NoEdit
                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTES").CellActivation = Activation.NoEdit
                .Columns("CASCO").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("12-14½").CellActivation = Activation.NoEdit
                .Columns("15-17½").CellActivation = Activation.NoEdit
                .Columns("18-19½").CellActivation = Activation.NoEdit
                .Columns("20-21½").CellActivation = Activation.NoEdit
                .Columns("22-24½").CellActivation = Activation.NoEdit
                .Columns("25-27½").CellActivation = Activation.NoEdit
                '.Columns("27-28½").CellActivation = Activation.NoEdit
                .Columns("28-30").CellActivation = Activation.NoEdit

                .Columns("NO").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + grdReportes.Rows(value).Cells("Lotes").Value
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub ConcentradoPlantaProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim tablaClasificacion As DataTable
        Dim listaComponentes As New List(Of Integer)
        Dim obj As New ReportesBU
        Dim clasificacion As Integer = 0
        Dim clasificacion2 As Integer = 0
        Dim tabla1 As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("NO")
        TablaReporteConcentrado.Columns.Add("PARES")
        TablaReporteConcentrado.Columns.Add("LOTE")
        TablaReporteConcentrado.Columns.Add("MATERIAL")
        TablaReporteConcentrado.Columns.Add("COLECCIÓN")
        TablaReporteConcentrado.Columns.Add("CORRIDA")
        TablaReporteConcentrado.Columns.Add("PROVEEDOR")
        TablaReporteConcentrado.Columns.Add("12")
        TablaReporteConcentrado.Columns.Add("12½")
        TablaReporteConcentrado.Columns.Add("13")
        TablaReporteConcentrado.Columns.Add("13½")
        TablaReporteConcentrado.Columns.Add("14")
        TablaReporteConcentrado.Columns.Add("14½")
        TablaReporteConcentrado.Columns.Add("15")
        TablaReporteConcentrado.Columns.Add("15½")
        TablaReporteConcentrado.Columns.Add("16")
        TablaReporteConcentrado.Columns.Add("16½")
        TablaReporteConcentrado.Columns.Add("17")
        TablaReporteConcentrado.Columns.Add("17½")
        TablaReporteConcentrado.Columns.Add("18")
        TablaReporteConcentrado.Columns.Add("18½")
        TablaReporteConcentrado.Columns.Add("19")
        TablaReporteConcentrado.Columns.Add("19½")
        TablaReporteConcentrado.Columns.Add("20")
        TablaReporteConcentrado.Columns.Add("20½")
        TablaReporteConcentrado.Columns.Add("21")
        TablaReporteConcentrado.Columns.Add("21½")
        TablaReporteConcentrado.Columns.Add("22")
        TablaReporteConcentrado.Columns.Add("22½")
        TablaReporteConcentrado.Columns.Add("23")
        TablaReporteConcentrado.Columns.Add("23½")
        TablaReporteConcentrado.Columns.Add("24")
        TablaReporteConcentrado.Columns.Add("24½")
        TablaReporteConcentrado.Columns.Add("25")
        TablaReporteConcentrado.Columns.Add("25½")
        TablaReporteConcentrado.Columns.Add("26")
        TablaReporteConcentrado.Columns.Add("26½")
        TablaReporteConcentrado.Columns.Add("27")
        TablaReporteConcentrado.Columns.Add("27½")
        TablaReporteConcentrado.Columns.Add("28")
        TablaReporteConcentrado.Columns.Add("28½")
        TablaReporteConcentrado.Columns.Add("29")
        TablaReporteConcentrado.Columns.Add("29½")
        TablaReporteConcentrado.Columns.Add("30")
        Dim contador = 1

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("NO") = contador
            row("PARES") = tabla1.Rows(value).Item("Pares")
            row("LOTE") = tabla1.Rows(value).Item("Lotes")
            row("MATERIAL") = tabla1.Rows(value).Item("Material")
            row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                Dim x = tabla1.Rows(value).Item(value2).ToString
                Select Case tabla1.Rows(value).Item(value2).ToString
                    Case "12"
                        row("12") = tabla1.Rows(value).Item(value2 + 20)
                    Case "12½"
                        row("12½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13"
                        row("13") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13½"
                        row("13½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14"
                        row("14") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14½"
                        row("14½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15"
                        row("15") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15½"
                        row("15½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16"
                        row("16") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16½"
                        row("16½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17"
                        row("17") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17½"
                        row("17½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18"
                        row("18") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18½"
                        row("18½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19"
                        row("19") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19½"
                        row("19½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20"
                        row("20") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20½"
                        row("20½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21"
                        row("21") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21½"
                        row("21½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22"
                        row("22") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22½"
                        row("22½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23"
                        row("23") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23½"
                        row("23½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24"
                        row("24") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24½"
                        row("24½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25"
                        row("25") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25½"
                        row("25½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26"
                        row("26") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26½"
                        row("26½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27"
                        row("27") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27½"
                        row("27½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28"
                        row("28") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28½"
                        row("28½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "30"
                        row("30") = tabla1.Rows(value).Item(value2 + 20)
                End Select
            Next
            contador = contador + 1
            TablaReporteConcentrado.Rows.Add(row)
        Next
        Try
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = TablaReporteConcentrado

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("NO").Width = 30
                .Columns("PARES").Width = 50
                .Columns("LOTE").Width = 50
                .Columns("MATERIAL").Width = 300
                .Columns("COLECCIÓN").Width = 300
                .Columns("CORRIDA").Width = 70
                .Columns("PROVEEDOR").Width = 300
                .Columns("12").Width = 30
                .Columns("12½").Width = 30
                .Columns("13").Width = 30
                .Columns("13½").Width = 30
                .Columns("14").Width = 30
                .Columns("14½").Width = 30
                .Columns("15").Width = 30
                .Columns("15½").Width = 30
                .Columns("16").Width = 30
                .Columns("16½").Width = 30
                .Columns("17").Width = 30
                .Columns("17½").Width = 30
                .Columns("18").Width = 30
                .Columns("18½").Width = 30
                .Columns("19").Width = 30
                .Columns("19½").Width = 30
                .Columns("20").Width = 30
                .Columns("20½").Width = 30
                .Columns("21").Width = 30
                .Columns("21½").Width = 30
                .Columns("22").Width = 30
                .Columns("22½").Width = 30
                .Columns("23").Width = 30
                .Columns("23½").Width = 30
                .Columns("24").Width = 30
                .Columns("24½").Width = 30
                .Columns("25").Width = 30
                .Columns("25½").Width = 30
                .Columns("26").Width = 30
                .Columns("26½").Width = 30
                .Columns("27").Width = 30
                .Columns("27½").Width = 30
                .Columns("28").Width = 30
                .Columns("28½").Width = 30
                .Columns("29").Width = 30
                .Columns("29½").Width = 30
                .Columns("30").Width = 30

                .Columns("NO").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("30").CellAppearance.TextHAlign = HAlign.Center

                .Columns("NO").CellActivation = Activation.NoEdit
                .Columns("PARES").CellActivation = Activation.NoEdit
                '.Columns("LOTES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("12½").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("13½").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("14½").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("15½").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("16½").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("17½").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("18½").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("19½").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit
                .Columns("20½").CellActivation = Activation.NoEdit
                .Columns("21").CellActivation = Activation.NoEdit
                .Columns("21½").CellActivation = Activation.NoEdit
                .Columns("22").CellActivation = Activation.NoEdit
                .Columns("22½").CellActivation = Activation.NoEdit
                .Columns("23").CellActivation = Activation.NoEdit
                .Columns("23½").CellActivation = Activation.NoEdit
                .Columns("24").CellActivation = Activation.NoEdit
                .Columns("24½").CellActivation = Activation.NoEdit
                .Columns("25").CellActivation = Activation.NoEdit
                .Columns("25½").CellActivation = Activation.NoEdit
                .Columns("26").CellActivation = Activation.NoEdit
                .Columns("26½").CellActivation = Activation.NoEdit
                .Columns("27").CellActivation = Activation.NoEdit
                .Columns("27½").CellActivation = Activation.NoEdit
                .Columns("28").CellActivation = Activation.NoEdit
                .Columns("28½").CellActivation = Activation.NoEdit
                .Columns("29").CellActivation = Activation.NoEdit
                .Columns("29½").CellActivation = Activation.NoEdit
                .Columns("30").CellActivation = Activation.NoEdit

                .Columns("Lote").Header.Caption = "LOTES"

                .Columns("COLECCIÓN").Hidden = True
                .Columns("NO").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            Dim pares As Integer = 0
            Dim lotes As Integer = 0
            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + grdReportes.Rows(value).Cells("Lote").Value
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub ConcentradoPlantillaProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTILLA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("NO")
        TablaReporteConcentrado.Columns.Add("PARES")
        TablaReporteConcentrado.Columns.Add("LOTE")
        TablaReporteConcentrado.Columns.Add("MATERIAL")
        TablaReporteConcentrado.Columns.Add("COLECCIÓN")
        TablaReporteConcentrado.Columns.Add("CORRIDA")
        TablaReporteConcentrado.Columns.Add("PROVEEDOR")
        TablaReporteConcentrado.Columns.Add("12")
        TablaReporteConcentrado.Columns.Add("12½")
        TablaReporteConcentrado.Columns.Add("13")
        TablaReporteConcentrado.Columns.Add("13½")
        TablaReporteConcentrado.Columns.Add("14")
        TablaReporteConcentrado.Columns.Add("14½")
        TablaReporteConcentrado.Columns.Add("15")
        TablaReporteConcentrado.Columns.Add("15½")
        TablaReporteConcentrado.Columns.Add("16")
        TablaReporteConcentrado.Columns.Add("16½")
        TablaReporteConcentrado.Columns.Add("17")
        TablaReporteConcentrado.Columns.Add("17½")
        TablaReporteConcentrado.Columns.Add("18")
        TablaReporteConcentrado.Columns.Add("18½")
        TablaReporteConcentrado.Columns.Add("19")
        TablaReporteConcentrado.Columns.Add("19½")
        TablaReporteConcentrado.Columns.Add("20")
        TablaReporteConcentrado.Columns.Add("20½")
        TablaReporteConcentrado.Columns.Add("21")
        TablaReporteConcentrado.Columns.Add("21½")
        TablaReporteConcentrado.Columns.Add("22")
        TablaReporteConcentrado.Columns.Add("22½")
        TablaReporteConcentrado.Columns.Add("23")
        TablaReporteConcentrado.Columns.Add("23½")
        TablaReporteConcentrado.Columns.Add("24")
        TablaReporteConcentrado.Columns.Add("24½")
        TablaReporteConcentrado.Columns.Add("25")
        TablaReporteConcentrado.Columns.Add("25½")
        TablaReporteConcentrado.Columns.Add("26")
        TablaReporteConcentrado.Columns.Add("26½")
        TablaReporteConcentrado.Columns.Add("27")
        TablaReporteConcentrado.Columns.Add("27½")
        TablaReporteConcentrado.Columns.Add("28")
        TablaReporteConcentrado.Columns.Add("28½")
        TablaReporteConcentrado.Columns.Add("29")
        TablaReporteConcentrado.Columns.Add("29½")
        TablaReporteConcentrado.Columns.Add("30")
        Dim contador = 1

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("NO") = contador
            row("PARES") = tabla1.Rows(value).Item("Pares")
            row("LOTE") = tabla1.Rows(value).Item("Lotes")
            row("MATERIAL") = tabla1.Rows(value).Item("Material")
            row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                Dim x = tabla1.Rows(value).Item(value2).ToString
                Select Case tabla1.Rows(value).Item(value2).ToString
                    Case "12"
                        row("12") = tabla1.Rows(value).Item(value2 + 20)
                    Case "12½"
                        row("12½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13"
                        row("13") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13½"
                        row("13½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14"
                        row("14") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14½"
                        row("14½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15"
                        row("15") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15½"
                        row("15½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16"
                        row("16") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16½"
                        row("16½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17"
                        row("17") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17½"
                        row("17½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18"
                        row("18") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18½"
                        row("18½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19"
                        row("19") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19½"
                        row("19½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20"
                        row("20") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20½"
                        row("20½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21"
                        row("21") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21½"
                        row("21½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22"
                        row("22") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22½"
                        row("22½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23"
                        row("23") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23½"
                        row("23½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24"
                        row("24") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24½"
                        row("24½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25"
                        row("25") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25½"
                        row("25½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26"
                        row("26") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26½"
                        row("26½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27"
                        row("27") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27½"
                        row("27½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28"
                        row("28") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28½"
                        row("28½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "30"
                        row("30") = tabla1.Rows(value).Item(value2 + 20)
                End Select
            Next
            contador = contador + 1
            TablaReporteConcentrado.Rows.Add(row)
        Next
        Try
            Me.Cursor = Cursors.WaitCursor
            grdReportes.DataSource = TablaReporteConcentrado
            With grdReportes.DisplayLayout.Bands(0)
                .Columns("NO").Width = 30
                .Columns("PARES").Width = 50
                .Columns("LOTE").Width = 50
                .Columns("MATERIAL").Width = 520
                .Columns("COLECCIÓN").Width = 300
                .Columns("CORRIDA").Width = 70
                .Columns("PROVEEDOR").Width = 300
                .Columns("12").Width = 30
                .Columns("12½").Width = 30
                .Columns("13").Width = 30
                .Columns("13½").Width = 30
                .Columns("14").Width = 30
                .Columns("14½").Width = 30
                .Columns("15").Width = 30
                .Columns("15½").Width = 30
                .Columns("16").Width = 30
                .Columns("16½").Width = 30
                .Columns("17").Width = 30
                .Columns("17½").Width = 30
                .Columns("18").Width = 30
                .Columns("18½").Width = 30
                .Columns("19").Width = 30
                .Columns("19½").Width = 30
                .Columns("20").Width = 30
                .Columns("20½").Width = 30
                .Columns("21").Width = 30
                .Columns("21½").Width = 30
                .Columns("22").Width = 30
                .Columns("22½").Width = 30
                .Columns("23").Width = 30
                .Columns("23½").Width = 30
                .Columns("24").Width = 30
                .Columns("24½").Width = 30
                .Columns("25").Width = 30
                .Columns("25½").Width = 30
                .Columns("26").Width = 30
                .Columns("26½").Width = 30
                .Columns("27").Width = 30
                .Columns("27½").Width = 30
                .Columns("28").Width = 30
                .Columns("28½").Width = 30
                .Columns("29").Width = 30
                .Columns("29½").Width = 30
                .Columns("30").Width = 30

                .Columns("NO").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("30").CellAppearance.TextHAlign = HAlign.Center

                .Columns("NO").CellActivation = Activation.NoEdit
                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("12½").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("13½").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("14½").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("15½").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("16½").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("17½").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("18½").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("19½").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit
                .Columns("20½").CellActivation = Activation.NoEdit
                .Columns("21").CellActivation = Activation.NoEdit
                .Columns("21½").CellActivation = Activation.NoEdit
                .Columns("22").CellActivation = Activation.NoEdit
                .Columns("22½").CellActivation = Activation.NoEdit
                .Columns("23").CellActivation = Activation.NoEdit
                .Columns("23½").CellActivation = Activation.NoEdit
                .Columns("24").CellActivation = Activation.NoEdit
                .Columns("24½").CellActivation = Activation.NoEdit
                .Columns("25").CellActivation = Activation.NoEdit
                .Columns("25½").CellActivation = Activation.NoEdit
                .Columns("26").CellActivation = Activation.NoEdit
                .Columns("26½").CellActivation = Activation.NoEdit
                .Columns("27").CellActivation = Activation.NoEdit
                .Columns("27½").CellActivation = Activation.NoEdit
                .Columns("28").CellActivation = Activation.NoEdit
                .Columns("28½").CellActivation = Activation.NoEdit
                .Columns("29").CellActivation = Activation.NoEdit
                .Columns("29½").CellActivation = Activation.NoEdit
                .Columns("30").CellActivation = Activation.NoEdit
                .Columns("Lote").Header.Caption = "LOTES"
                .Columns("COLECCIÓN").Hidden = True
                .Columns("NO").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + grdReportes.Rows(value).Cells("Lote").Value
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub ConcentradoHerrajePorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("HERRAJE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("NO")
        TablaReporteConcentrado.Columns.Add("PARES")
        'TablaReporteConcentrado.Columns.Add("LOTES")
        TablaReporteConcentrado.Columns.Add("LOTE")
        TablaReporteConcentrado.Columns.Add("MATERIAL")
        TablaReporteConcentrado.Columns.Add("COLECCIÓN")
        TablaReporteConcentrado.Columns.Add("CORRIDA")
        TablaReporteConcentrado.Columns.Add("PROVEEDOR")
        TablaReporteConcentrado.Columns.Add("12")
        TablaReporteConcentrado.Columns.Add("12½")
        TablaReporteConcentrado.Columns.Add("13")
        TablaReporteConcentrado.Columns.Add("13½")
        TablaReporteConcentrado.Columns.Add("14")
        TablaReporteConcentrado.Columns.Add("14½")
        TablaReporteConcentrado.Columns.Add("15")
        TablaReporteConcentrado.Columns.Add("15½")
        TablaReporteConcentrado.Columns.Add("16")
        TablaReporteConcentrado.Columns.Add("16½")
        TablaReporteConcentrado.Columns.Add("17")
        TablaReporteConcentrado.Columns.Add("17½")
        TablaReporteConcentrado.Columns.Add("18")
        TablaReporteConcentrado.Columns.Add("18½")
        TablaReporteConcentrado.Columns.Add("19")
        TablaReporteConcentrado.Columns.Add("19½")
        TablaReporteConcentrado.Columns.Add("20")
        TablaReporteConcentrado.Columns.Add("20½")
        TablaReporteConcentrado.Columns.Add("21")
        TablaReporteConcentrado.Columns.Add("21½")
        TablaReporteConcentrado.Columns.Add("22")
        TablaReporteConcentrado.Columns.Add("22½")
        TablaReporteConcentrado.Columns.Add("23")
        TablaReporteConcentrado.Columns.Add("23½")
        TablaReporteConcentrado.Columns.Add("24")
        TablaReporteConcentrado.Columns.Add("24½")
        TablaReporteConcentrado.Columns.Add("25")
        TablaReporteConcentrado.Columns.Add("25½")
        TablaReporteConcentrado.Columns.Add("26")
        TablaReporteConcentrado.Columns.Add("26½")
        TablaReporteConcentrado.Columns.Add("27")
        TablaReporteConcentrado.Columns.Add("27½")
        TablaReporteConcentrado.Columns.Add("28")
        TablaReporteConcentrado.Columns.Add("28½")
        TablaReporteConcentrado.Columns.Add("29")
        TablaReporteConcentrado.Columns.Add("29½")
        TablaReporteConcentrado.Columns.Add("30")
        Dim contador = 1

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("NO") = contador
            row("PARES") = tabla1.Rows(value).Item("Pares")
            'row("LOTES") = tabla1.Rows(value).Item("Lotes")
            row("LOTE") = tabla1.Rows(value).Item("Lotes")
            row("MATERIAL") = tabla1.Rows(value).Item("Material")
            row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                Dim x = tabla1.Rows(value).Item(value2).ToString
                Select Case tabla1.Rows(value).Item(value2).ToString
                    Case "12"
                        row("12") = tabla1.Rows(value).Item(value2 + 20)
                    Case "12½"
                        row("12½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13"
                        row("13") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13½"
                        row("13½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14"
                        row("14") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14½"
                        row("14½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15"
                        row("15") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15½"
                        row("15½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16"
                        row("16") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16½"
                        row("16½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17"
                        row("17") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17½"
                        row("17½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18"
                        row("18") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18½"
                        row("18½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19"
                        row("19") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19½"
                        row("19½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20"
                        row("20") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20½"
                        row("20½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21"
                        row("21") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21½"
                        row("21½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22"
                        row("22") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22½"
                        row("22½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23"
                        row("23") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23½"
                        row("23½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24"
                        row("24") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24½"
                        row("24½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25"
                        row("25") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25½"
                        row("25½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26"
                        row("26") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26½"
                        row("26½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27"
                        row("27") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27½"
                        row("27½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28"
                        row("28") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28½"
                        row("28½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "30"
                        row("30") = tabla1.Rows(value).Item(value2 + 20)
                End Select
            Next
            contador = contador + 1
            TablaReporteConcentrado.Rows.Add(row)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = TablaReporteConcentrado

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("NO").Width = 30
                .Columns("PARES").Width = 50
                '.Columns("LOTES").Width = 50
                .Columns("LOTE").Width = 50
                .Columns("MATERIAL").Width = 300
                .Columns("COLECCIÓN").Width = 300
                .Columns("CORRIDA").Width = 70
                .Columns("PROVEEDOR").Width = 300
                .Columns("12").Width = 30
                .Columns("12½").Width = 30
                .Columns("13").Width = 30
                .Columns("13½").Width = 30
                .Columns("14").Width = 30
                .Columns("14½").Width = 30
                .Columns("15").Width = 30
                .Columns("15½").Width = 30
                .Columns("16").Width = 30
                .Columns("16½").Width = 30
                .Columns("17").Width = 30
                .Columns("17½").Width = 30
                .Columns("18").Width = 30
                .Columns("18½").Width = 30
                .Columns("19").Width = 30
                .Columns("19½").Width = 30
                .Columns("20").Width = 30
                .Columns("20½").Width = 30
                .Columns("21").Width = 30
                .Columns("21½").Width = 30
                .Columns("22").Width = 30
                .Columns("22½").Width = 30
                .Columns("23").Width = 30
                .Columns("23½").Width = 30
                .Columns("24").Width = 30
                .Columns("24½").Width = 30
                .Columns("25").Width = 30
                .Columns("25½").Width = 30
                .Columns("26").Width = 30
                .Columns("26½").Width = 30
                .Columns("27").Width = 30
                .Columns("27½").Width = 30
                .Columns("28").Width = 30
                .Columns("28½").Width = 30
                .Columns("29").Width = 30
                .Columns("29½").Width = 30
                .Columns("30").Width = 30

                .Columns("NO").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("LOTES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("30").CellAppearance.TextHAlign = HAlign.Center

                .Columns("NO").CellActivation = Activation.NoEdit
                .Columns("PARES").CellActivation = Activation.NoEdit
                '.Columns("LOTES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("12½").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("13½").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("14½").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("15½").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("16½").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("17½").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("18½").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("19½").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit
                .Columns("20½").CellActivation = Activation.NoEdit
                .Columns("21").CellActivation = Activation.NoEdit
                .Columns("21½").CellActivation = Activation.NoEdit
                .Columns("22").CellActivation = Activation.NoEdit
                .Columns("22½").CellActivation = Activation.NoEdit
                .Columns("23").CellActivation = Activation.NoEdit
                .Columns("23½").CellActivation = Activation.NoEdit
                .Columns("24").CellActivation = Activation.NoEdit
                .Columns("24½").CellActivation = Activation.NoEdit
                .Columns("25").CellActivation = Activation.NoEdit
                .Columns("25½").CellActivation = Activation.NoEdit
                .Columns("26").CellActivation = Activation.NoEdit
                .Columns("26½").CellActivation = Activation.NoEdit
                .Columns("27").CellActivation = Activation.NoEdit
                .Columns("27½").CellActivation = Activation.NoEdit
                .Columns("28").CellActivation = Activation.NoEdit
                .Columns("28½").CellActivation = Activation.NoEdit
                .Columns("29").CellActivation = Activation.NoEdit
                .Columns("29½").CellActivation = Activation.NoEdit
                .Columns("30").CellActivation = Activation.NoEdit

                '.Columns("Lotes").Header.Caption = "LOTES"
                .Columns("Lote").Header.Caption = "LOTES"

                .Columns("COLECCIÓN").Hidden = True
                .Columns("NO").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + grdReportes.Rows(value).Cells("Lote").Value
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub ConcentradoTaconPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("TACON")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("NO")
        TablaReporteConcentrado.Columns.Add("PARES")
        'TablaReporteConcentrado.Columns.Add("LOTES")
        TablaReporteConcentrado.Columns.Add("LOTE")
        TablaReporteConcentrado.Columns.Add("MATERIAL")
        TablaReporteConcentrado.Columns.Add("COLECCIÓN")
        TablaReporteConcentrado.Columns.Add("CORRIDA")
        TablaReporteConcentrado.Columns.Add("PROVEEDOR")
        TablaReporteConcentrado.Columns.Add("12")
        TablaReporteConcentrado.Columns.Add("12½")
        TablaReporteConcentrado.Columns.Add("13")
        TablaReporteConcentrado.Columns.Add("13½")
        TablaReporteConcentrado.Columns.Add("14")
        TablaReporteConcentrado.Columns.Add("14½")
        TablaReporteConcentrado.Columns.Add("15")
        TablaReporteConcentrado.Columns.Add("15½")
        TablaReporteConcentrado.Columns.Add("16")
        TablaReporteConcentrado.Columns.Add("16½")
        TablaReporteConcentrado.Columns.Add("17")
        TablaReporteConcentrado.Columns.Add("17½")
        TablaReporteConcentrado.Columns.Add("18")
        TablaReporteConcentrado.Columns.Add("18½")
        TablaReporteConcentrado.Columns.Add("19")
        TablaReporteConcentrado.Columns.Add("19½")
        TablaReporteConcentrado.Columns.Add("20")
        TablaReporteConcentrado.Columns.Add("20½")
        TablaReporteConcentrado.Columns.Add("21")
        TablaReporteConcentrado.Columns.Add("21½")
        TablaReporteConcentrado.Columns.Add("22")
        TablaReporteConcentrado.Columns.Add("22½")
        TablaReporteConcentrado.Columns.Add("23")
        TablaReporteConcentrado.Columns.Add("23½")
        TablaReporteConcentrado.Columns.Add("24")
        TablaReporteConcentrado.Columns.Add("24½")
        TablaReporteConcentrado.Columns.Add("25")
        TablaReporteConcentrado.Columns.Add("25½")
        TablaReporteConcentrado.Columns.Add("26")
        TablaReporteConcentrado.Columns.Add("26½")
        TablaReporteConcentrado.Columns.Add("27")
        TablaReporteConcentrado.Columns.Add("27½")
        TablaReporteConcentrado.Columns.Add("28")
        TablaReporteConcentrado.Columns.Add("28½")
        TablaReporteConcentrado.Columns.Add("29")
        TablaReporteConcentrado.Columns.Add("29½")
        TablaReporteConcentrado.Columns.Add("30")
        Dim contador = 1

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("NO") = contador
            row("PARES") = tabla1.Rows(value).Item("Pares")
            'row("LOTES") = tabla1.Rows(value).Item("Lotes")
            row("LOTE") = tabla1.Rows(value).Item("Lotes")
            row("MATERIAL") = tabla1.Rows(value).Item("Material")
            row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                Dim x = tabla1.Rows(value).Item(value2).ToString
                Select Case tabla1.Rows(value).Item(value2).ToString
                    Case "12"
                        row("12") = tabla1.Rows(value).Item(value2 + 20)
                    Case "12½"
                        row("12½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13"
                        row("13") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13½"
                        row("13½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14"
                        row("14") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14½"
                        row("14½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15"
                        row("15") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15½"
                        row("15½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16"
                        row("16") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16½"
                        row("16½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17"
                        row("17") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17½"
                        row("17½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18"
                        row("18") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18½"
                        row("18½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19"
                        row("19") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19½"
                        row("19½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20"
                        row("20") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20½"
                        row("20½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21"
                        row("21") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21½"
                        row("21½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22"
                        row("22") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22½"
                        row("22½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23"
                        row("23") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23½"
                        row("23½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24"
                        row("24") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24½"
                        row("24½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25"
                        row("25") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25½"
                        row("25½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26"
                        row("26") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26½"
                        row("26½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27"
                        row("27") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27½"
                        row("27½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28"
                        row("28") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28½"
                        row("28½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "30"
                        row("30") = tabla1.Rows(value).Item(value2 + 20)
                End Select
            Next
            contador = contador + 1
            TablaReporteConcentrado.Rows.Add(row)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = TablaReporteConcentrado

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("NO").Width = 30
                .Columns("PARES").Width = 50
                '.Columns("LOTES").Width = 50
                .Columns("LOTE").Width = 50
                .Columns("MATERIAL").Width = 300
                .Columns("COLECCIÓN").Width = 300
                .Columns("CORRIDA").Width = 70
                .Columns("PROVEEDOR").Width = 300
                .Columns("12").Width = 30
                .Columns("12½").Width = 30
                .Columns("13").Width = 30
                .Columns("13½").Width = 30
                .Columns("14").Width = 30
                .Columns("14½").Width = 30
                .Columns("15").Width = 30
                .Columns("15½").Width = 30
                .Columns("16").Width = 30
                .Columns("16½").Width = 30
                .Columns("17").Width = 30
                .Columns("17½").Width = 30
                .Columns("18").Width = 30
                .Columns("18½").Width = 30
                .Columns("19").Width = 30
                .Columns("19½").Width = 30
                .Columns("20").Width = 30
                .Columns("20½").Width = 30
                .Columns("21").Width = 30
                .Columns("21½").Width = 30
                .Columns("22").Width = 30
                .Columns("22½").Width = 30
                .Columns("23").Width = 30
                .Columns("23½").Width = 30
                .Columns("24").Width = 30
                .Columns("24½").Width = 30
                .Columns("25").Width = 30
                .Columns("25½").Width = 30
                .Columns("26").Width = 30
                .Columns("26½").Width = 30
                .Columns("27").Width = 30
                .Columns("27½").Width = 30
                .Columns("28").Width = 30
                .Columns("28½").Width = 30
                .Columns("29").Width = 30
                .Columns("29½").Width = 30
                .Columns("30").Width = 30

                .Columns("NO").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("LOTES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("30").CellAppearance.TextHAlign = HAlign.Center

                .Columns("NO").CellActivation = Activation.NoEdit
                .Columns("PARES").CellActivation = Activation.NoEdit
                '.Columns("LOTES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("12½").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("13½").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("14½").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("15½").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("16½").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("17½").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("18½").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("19½").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit
                .Columns("20½").CellActivation = Activation.NoEdit
                .Columns("21").CellActivation = Activation.NoEdit
                .Columns("21½").CellActivation = Activation.NoEdit
                .Columns("22").CellActivation = Activation.NoEdit
                .Columns("22½").CellActivation = Activation.NoEdit
                .Columns("23").CellActivation = Activation.NoEdit
                .Columns("23½").CellActivation = Activation.NoEdit
                .Columns("24").CellActivation = Activation.NoEdit
                .Columns("24½").CellActivation = Activation.NoEdit
                .Columns("25").CellActivation = Activation.NoEdit
                .Columns("25½").CellActivation = Activation.NoEdit
                .Columns("26").CellActivation = Activation.NoEdit
                .Columns("26½").CellActivation = Activation.NoEdit
                .Columns("27").CellActivation = Activation.NoEdit
                .Columns("27½").CellActivation = Activation.NoEdit
                .Columns("28").CellActivation = Activation.NoEdit
                .Columns("28½").CellActivation = Activation.NoEdit
                .Columns("29").CellActivation = Activation.NoEdit
                .Columns("29½").CellActivation = Activation.NoEdit
                .Columns("30").CellActivation = Activation.NoEdit

                '.Columns("Lotes").Header.Caption = "LOTES"
                .Columns("Lote").Header.Caption = "LOTES"

                .Columns("COLECCIÓN").Hidden = True
                .Columns("NO").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + grdReportes.Rows(value).Cells("Lote").Value
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub


    Public Sub ConcentradoSuelaProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("NO")
        TablaReporteConcentrado.Columns.Add("PARES")
        'TablaReporteConcentrado.Columns.Add("LOTES")
        TablaReporteConcentrado.Columns.Add("LOTE")
        TablaReporteConcentrado.Columns.Add("MATERIAL")
        TablaReporteConcentrado.Columns.Add("COLECCIÓN")
        TablaReporteConcentrado.Columns.Add("CORRIDA")
        TablaReporteConcentrado.Columns.Add("PROVEEDOR")
        TablaReporteConcentrado.Columns.Add("12")
        TablaReporteConcentrado.Columns.Add("12½")
        TablaReporteConcentrado.Columns.Add("13")
        TablaReporteConcentrado.Columns.Add("13½")
        TablaReporteConcentrado.Columns.Add("14")
        TablaReporteConcentrado.Columns.Add("14½")
        TablaReporteConcentrado.Columns.Add("15")
        TablaReporteConcentrado.Columns.Add("15½")
        TablaReporteConcentrado.Columns.Add("16")
        TablaReporteConcentrado.Columns.Add("16½")
        TablaReporteConcentrado.Columns.Add("17")
        TablaReporteConcentrado.Columns.Add("17½")
        TablaReporteConcentrado.Columns.Add("18")
        TablaReporteConcentrado.Columns.Add("18½")
        TablaReporteConcentrado.Columns.Add("19")
        TablaReporteConcentrado.Columns.Add("19½")
        TablaReporteConcentrado.Columns.Add("20")
        TablaReporteConcentrado.Columns.Add("20½")
        TablaReporteConcentrado.Columns.Add("21")
        TablaReporteConcentrado.Columns.Add("21½")
        TablaReporteConcentrado.Columns.Add("22")
        TablaReporteConcentrado.Columns.Add("22½")
        TablaReporteConcentrado.Columns.Add("23")
        TablaReporteConcentrado.Columns.Add("23½")
        TablaReporteConcentrado.Columns.Add("24")
        TablaReporteConcentrado.Columns.Add("24½")
        TablaReporteConcentrado.Columns.Add("25")
        TablaReporteConcentrado.Columns.Add("25½")
        TablaReporteConcentrado.Columns.Add("26")
        TablaReporteConcentrado.Columns.Add("26½")
        TablaReporteConcentrado.Columns.Add("27")
        TablaReporteConcentrado.Columns.Add("27½")
        TablaReporteConcentrado.Columns.Add("28")
        TablaReporteConcentrado.Columns.Add("28½")
        TablaReporteConcentrado.Columns.Add("29")
        TablaReporteConcentrado.Columns.Add("29½")
        TablaReporteConcentrado.Columns.Add("30")
        Dim contador = 1

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("NO") = contador
            row("PARES") = tabla1.Rows(value).Item("Pares")
            'row("LOTES") = tabla1.Rows(value).Item("Lotes")
            row("LOTE") = tabla1.Rows(value).Item("Lotes")
            row("MATERIAL") = tabla1.Rows(value).Item("Material")
            row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                Dim x = tabla1.Rows(value).Item(value2).ToString
                Select Case tabla1.Rows(value).Item(value2).ToString
                    Case "12"
                        row("12") = tabla1.Rows(value).Item(value2 + 20)
                    Case "12½"
                        row("12½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13"
                        row("13") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13½"
                        row("13½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14"
                        row("14") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14½"
                        row("14½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15"
                        row("15") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15½"
                        row("15½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16"
                        row("16") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16½"
                        row("16½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17"
                        row("17") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17½"
                        row("17½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18"
                        row("18") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18½"
                        row("18½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19"
                        row("19") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19½"
                        row("19½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20"
                        row("20") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20½"
                        row("20½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21"
                        row("21") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21½"
                        row("21½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22"
                        row("22") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22½"
                        row("22½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23"
                        row("23") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23½"
                        row("23½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24"
                        row("24") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24½"
                        row("24½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25"
                        row("25") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25½"
                        row("25½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26"
                        row("26") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26½"
                        row("26½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27"
                        row("27") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27½"
                        row("27½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28"
                        row("28") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28½"
                        row("28½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "30"
                        row("30") = tabla1.Rows(value).Item(value2 + 20)
                End Select
            Next
            contador = contador + 1
            TablaReporteConcentrado.Rows.Add(row)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = TablaReporteConcentrado

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("NO").Width = 30
                .Columns("PARES").Width = 50
                '.Columns("LOTES").Width = 50
                .Columns("LOTE").Width = 50
                .Columns("MATERIAL").Width = 300
                .Columns("COLECCIÓN").Width = 300
                .Columns("CORRIDA").Width = 70
                .Columns("PROVEEDOR").Width = 300
                .Columns("12").Width = 30
                .Columns("12½").Width = 30
                .Columns("13").Width = 30
                .Columns("13½").Width = 30
                .Columns("14").Width = 30
                .Columns("14½").Width = 30
                .Columns("15").Width = 30
                .Columns("15½").Width = 30
                .Columns("16").Width = 30
                .Columns("16½").Width = 30
                .Columns("17").Width = 30
                .Columns("17½").Width = 30
                .Columns("18").Width = 30
                .Columns("18½").Width = 30
                .Columns("19").Width = 30
                .Columns("19½").Width = 30
                .Columns("20").Width = 30
                .Columns("20½").Width = 30
                .Columns("21").Width = 30
                .Columns("21½").Width = 30
                .Columns("22").Width = 30
                .Columns("22½").Width = 30
                .Columns("23").Width = 30
                .Columns("23½").Width = 30
                .Columns("24").Width = 30
                .Columns("24½").Width = 30
                .Columns("25").Width = 30
                .Columns("25½").Width = 30
                .Columns("26").Width = 30
                .Columns("26½").Width = 30
                .Columns("27").Width = 30
                .Columns("27½").Width = 30
                .Columns("28").Width = 30
                .Columns("28½").Width = 30
                .Columns("29").Width = 30
                .Columns("29½").Width = 30
                .Columns("30").Width = 30

                .Columns("NO").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("LOTES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("30").CellAppearance.TextHAlign = HAlign.Center

                .Columns("NO").CellActivation = Activation.NoEdit
                .Columns("PARES").CellActivation = Activation.NoEdit
                '.Columns("LOTES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("12½").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("13½").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("14½").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("15½").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("16½").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("17½").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("18½").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("19½").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit
                .Columns("20½").CellActivation = Activation.NoEdit
                .Columns("21").CellActivation = Activation.NoEdit
                .Columns("21½").CellActivation = Activation.NoEdit
                .Columns("22").CellActivation = Activation.NoEdit
                .Columns("22½").CellActivation = Activation.NoEdit
                .Columns("23").CellActivation = Activation.NoEdit
                .Columns("23½").CellActivation = Activation.NoEdit
                .Columns("24").CellActivation = Activation.NoEdit
                .Columns("24½").CellActivation = Activation.NoEdit
                .Columns("25").CellActivation = Activation.NoEdit
                .Columns("25½").CellActivation = Activation.NoEdit
                .Columns("26").CellActivation = Activation.NoEdit
                .Columns("26½").CellActivation = Activation.NoEdit
                .Columns("27").CellActivation = Activation.NoEdit
                .Columns("27½").CellActivation = Activation.NoEdit
                .Columns("28").CellActivation = Activation.NoEdit
                .Columns("28½").CellActivation = Activation.NoEdit
                .Columns("29").CellActivation = Activation.NoEdit
                .Columns("29½").CellActivation = Activation.NoEdit
                .Columns("30").CellActivation = Activation.NoEdit

                '.Columns("Lotes").Header.Caption = "LOTES"
                .Columns("Lote").Header.Caption = "LOTES"

                .Columns("COLECCIÓN").Hidden = True
                .Columns("NO").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + grdReportes.Rows(value).Cells("Lote").Value
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub ConcentrandoContrafuertePorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)

        tabla1 = obj.ConsultaCasco1(fecha, nave, clasificacion)
        tablaA = obj.ConsultaCasco2(fecha, nave, clasificacion)
        tabla1.TableName = ""

        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("NO")
        TablaReporteConcentrado.Columns.Add("PARES")
        TablaReporteConcentrado.Columns.Add("LOTES")
        TablaReporteConcentrado.Columns.Add("CONTRAFUERTE")
        TablaReporteConcentrado.Columns.Add("CORRIDA")
        TablaReporteConcentrado.Columns.Add("PROVEEDOR")
        TablaReporteConcentrado.Columns.Add("12-14½")
        TablaReporteConcentrado.Columns.Add("15-17½")
        TablaReporteConcentrado.Columns.Add("18-19½")
        TablaReporteConcentrado.Columns.Add("20-21½")
        TablaReporteConcentrado.Columns.Add("22-24½")
        TablaReporteConcentrado.Columns.Add("25-27½")
        'TablaReporteConcentrado.Columns.Add("27-28½")
        TablaReporteConcentrado.Columns.Add("28-30")

        For value = 0 To tabla1.Rows.Count - 1
            Dim contador = 1
            Dim t1 As Integer? = Nothing
            Dim t2 As Integer? = Nothing
            Dim t3 As Integer? = Nothing
            Dim t4 As Integer? = Nothing
            Dim t5 As Integer? = Nothing
            Dim t6 As Integer? = Nothing
            'Dim t7 As Integer? = Nothing
            Dim t8 As Integer? = Nothing
            Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
            'rowc("No") = tabla1.Rows(value).Item("No").ToString
            rowc("PARES") = tabla1.Rows(value).Item("Pares").ToString
            rowc("LOTES") = tabla1.Rows(value).Item("Lotes").ToString
            rowc("CONTRAFUERTE") = tabla1.Rows(value).Item("Material").ToString
            rowc("CORRIDA") = tabla1.Rows(value).Item("Corrida").ToString
            rowc("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor").ToString
            Dim cont = 4
            For value2 = 0 To 19
                If value2 < 5 Then
                Else
                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("12-14½") = t1
                        Case "13"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("12-14½") = t1
                        Case "14"
                            Dim o = tablaA.Rows(value).Item(value)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("12-14½") = t1
                        Case "15"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("15-17½") = t2
                        Case "16"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("15-17½") = t2
                        Case "17"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("15-17½") = t2
                        Case "18"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t3 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("18-19½") = t3
                        Case "19"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t3 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("18-19½") = t3
                        Case "20"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t4 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("20-21½") = t4
                        Case "21"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t4 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("20-21½") = t4
                        Case "22"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("22-24½") = t5
                        Case "23"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("22-24½") = t5
                        Case "24"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("22-24½") = t5
                        Case "25"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("25-27½") = t6
                        Case "26"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("25-27½") = t6
                        Case "27"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("25-27½") = t6
                        Case "28"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("28-30") = t8
                        Case "29"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("28-30") = t8
                        Case "30"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("28-30") = t8
                    End Select
                End If

            Next
            rowc("NO") = contador
            contador = contador + 1
            TablaReporteConcentrado.Rows.Add(rowc)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor
            grdReportes.DataSource = TablaReporteConcentrado

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("NO").Width = 30
                .Columns("PARES").Width = 50
                .Columns("LOTES").Width = 50
                .Columns("CONTRAFUERTE").Width = 300
                .Columns("CORRIDA").Width = 50
                .Columns("PROVEEDOR").Width = 300
                .Columns("12-14½").Width = 60
                .Columns("15-17½").Width = 60
                .Columns("18-19½").Width = 60
                .Columns("20-21½").Width = 60
                .Columns("22-24½").Width = 60
                .Columns("25-27½").Width = 60
                '.Columns("27-28½").Width = 60
                .Columns("28-30").Width = 60

                .Columns("NO").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12-14½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15-17½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18-19½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20-21½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22-24½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25-27½").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("27-28½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28-30").CellAppearance.TextHAlign = HAlign.Center

                .Columns("NO").CellActivation = Activation.NoEdit
                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTES").CellActivation = Activation.NoEdit
                .Columns("CONTRAFUERTE").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("12-14½").CellActivation = Activation.NoEdit
                .Columns("15-17½").CellActivation = Activation.NoEdit
                .Columns("18-19½").CellActivation = Activation.NoEdit
                .Columns("20-21½").CellActivation = Activation.NoEdit
                .Columns("22-24½").CellActivation = Activation.NoEdit
                .Columns("25-27½").CellActivation = Activation.NoEdit
                '.Columns("27-28½").CellActivation = Activation.NoEdit
                .Columns("28-30").CellActivation = Activation.NoEdit

                .Columns("NO").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + grdReportes.Rows(value).Cells("Lotes").Value
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub
#End Region

#Region "Desglosados"
    Public Sub DesglosadoCasco(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion2 As DataTable
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Buscar id clasificación de contrafuerte
        tablaClasificacion2 = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion2 = tablaClasificacion2.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDeCascoYContrafuerte(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("No")
        TablaReporteConcentrado.Columns.Add("Pares")
        TablaReporteConcentrado.Columns.Add("Lote")
        TablaReporteConcentrado.Columns.Add("Material")
        TablaReporteConcentrado.Columns.Add("C5")
        TablaReporteConcentrado.Columns.Add("Corrida")
        TablaReporteConcentrado.Columns.Add("Proveedor")
        TablaReporteConcentrado.Columns.Add("tl1")
        TablaReporteConcentrado.Columns.Add("tl2")
        TablaReporteConcentrado.Columns.Add("tl3")
        TablaReporteConcentrado.Columns.Add("tl4")
        TablaReporteConcentrado.Columns.Add("tl5")
        TablaReporteConcentrado.Columns.Add("tl6")
        TablaReporteConcentrado.Columns.Add("tl7")
        TablaReporteConcentrado.Columns.Add("tl8")
        TablaReporteConcentrado.Columns.Add("tl9")
        TablaReporteConcentrado.Columns.Add("tl10")
        TablaReporteConcentrado.Columns.Add("tl11")
        TablaReporteConcentrado.Columns.Add("tl12")
        TablaReporteConcentrado.Columns.Add("tl13")
        TablaReporteConcentrado.Columns.Add("tl14")
        TablaReporteConcentrado.Columns.Add("tl15")
        TablaReporteConcentrado.Columns.Add("tl16")
        TablaReporteConcentrado.Columns.Add("tl17")
        TablaReporteConcentrado.Columns.Add("tl18")
        TablaReporteConcentrado.Columns.Add("tl19")
        TablaReporteConcentrado.Columns.Add("tl20")
        TablaReporteConcentrado.Columns.Add("t1")
        TablaReporteConcentrado.Columns.Add("t2")
        TablaReporteConcentrado.Columns.Add("t3")
        TablaReporteConcentrado.Columns.Add("t4")
        TablaReporteConcentrado.Columns.Add("t5")
        TablaReporteConcentrado.Columns.Add("t6")
        TablaReporteConcentrado.Columns.Add("t7")
        TablaReporteConcentrado.Columns.Add("t8")
        TablaReporteConcentrado.Columns.Add("t9")
        TablaReporteConcentrado.Columns.Add("t10")
        TablaReporteConcentrado.Columns.Add("t11")
        TablaReporteConcentrado.Columns.Add("t12")
        TablaReporteConcentrado.Columns.Add("t13")
        TablaReporteConcentrado.Columns.Add("t14")
        TablaReporteConcentrado.Columns.Add("t15")
        TablaReporteConcentrado.Columns.Add("t16")
        TablaReporteConcentrado.Columns.Add("t17")
        TablaReporteConcentrado.Columns.Add("t18")
        TablaReporteConcentrado.Columns.Add("t19")
        TablaReporteConcentrado.Columns.Add("t20")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("No") = tabla1.Rows(value).Item("No")
            row("Pares") = tabla1.Rows(value).Item("Pares")
            row("Lote") = tabla1.Rows(value).Item("Lote")
            row("Material") = tabla1.Rows(value).Item("Material")
            row("C5") = tabla1.Rows(value).Item("C5")
            row("Corrida") = tabla1.Rows(value).Item("Corrida")
            row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2) = tabla1.Rows(value).Item(value2)
                    Dim X = value2 + 20
                    row(X) = tabla1.Rows(value).Item(value2 + 20)
                End If
            Next
            TablaReporteConcentrado.Rows.Add(row)
        Next

        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("No")
        tabla.Columns.Add("Pares")
        tabla.Columns.Add("Lote")
        tabla.Columns.Add("Casco")
        tabla.Columns.Add("Contrafuerte")
        tabla.Columns.Add("Corrida")
        tabla.Columns.Add("Proveedor")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")

        For value = 0 To TablaReporteConcentrado.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("No") = TablaReporteConcentrado.Rows(value).Item("No")
            row("Pares") = TablaReporteConcentrado.Rows(value).Item("Pares")
            row("Lote") = TablaReporteConcentrado.Rows(value).Item("Lote")
            row("Casco") = TablaReporteConcentrado.Rows(value).Item("Material")
            row("Contrafuerte") = TablaReporteConcentrado.Rows(value).Item("C5")
            row("Corrida") = TablaReporteConcentrado.Rows(value).Item("Corrida")
            row("Proveedor") = TablaReporteConcentrado.Rows(value).Item("Proveedor")
            Dim NUM = 7
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(NUM) = TablaReporteConcentrado.Rows(value).Item(value2)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row)

            Dim row2 As DataRow = tabla.NewRow()
            row2("No") = ""
            row2("Pares") = ""
            row2("Lote") = ""
            row2("Casco") = ""
            row2("Contrafuerte") = ""
            row2("Corrida") = ""
            row2("Proveedor") = ""
            Dim NUM2 = 7
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then 'And TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "0"
                    row2(NUM2) = TablaReporteConcentrado.Rows(value).Item(value2 + 20)
                    NUM2 = NUM2 + 1
                End If
            Next
            tabla.Rows.Add(row2)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("No").Hidden = True
                .Columns("Contrafuerte").Hidden = True

                .Columns("Pares").Width = 60
                .Columns("Lote").Width = 50
                .Columns("Casco").Width = 400
                .Columns("Contrafuerte").Width = 150
                .Columns("Corrida").Width = 70
                .Columns("Proveedor").Width = 200
                .Columns("1").Width = 40
                .Columns("2").Width = 40
                .Columns("3").Width = 40
                .Columns("4").Width = 40
                .Columns("5").Width = 40
                .Columns("6").Width = 40
                .Columns("7").Width = 40
                .Columns("8").Width = 40
                .Columns("9").Width = 40
                .Columns("10").Width = 40
                .Columns("11").Width = 40
                .Columns("12").Width = 40
                .Columns("13").Width = 40
                .Columns("14").Width = 40
                .Columns("15").Width = 40
                .Columns("16").Width = 40
                .Columns("17").Width = 40
                .Columns("18").Width = 40
                .Columns("19").Width = 40
                .Columns("20").Width = 40

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Casco").CellActivation = Activation.NoEdit
                .Columns("Contrafuerte").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Casco").Header.Caption = "CASCO"
                .Columns("Contrafuerte").Header.Caption = "CONTRAFUERTE"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub DesglosadoPlanta(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Buscar id clasificación de planta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDePlanta(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("No")
        TablaReporteConcentrado.Columns.Add("Pares")
        TablaReporteConcentrado.Columns.Add("Lote")
        TablaReporteConcentrado.Columns.Add("Material")
        TablaReporteConcentrado.Columns.Add("C5")
        TablaReporteConcentrado.Columns.Add("Corrida")
        TablaReporteConcentrado.Columns.Add("Proveedor")
        TablaReporteConcentrado.Columns.Add("tl1")
        TablaReporteConcentrado.Columns.Add("tl2")
        TablaReporteConcentrado.Columns.Add("tl3")
        TablaReporteConcentrado.Columns.Add("tl4")
        TablaReporteConcentrado.Columns.Add("tl5")
        TablaReporteConcentrado.Columns.Add("tl6")
        TablaReporteConcentrado.Columns.Add("tl7")
        TablaReporteConcentrado.Columns.Add("tl8")
        TablaReporteConcentrado.Columns.Add("tl9")
        TablaReporteConcentrado.Columns.Add("tl10")
        TablaReporteConcentrado.Columns.Add("tl11")
        TablaReporteConcentrado.Columns.Add("tl12")
        TablaReporteConcentrado.Columns.Add("tl13")
        TablaReporteConcentrado.Columns.Add("tl14")
        TablaReporteConcentrado.Columns.Add("tl15")
        TablaReporteConcentrado.Columns.Add("tl16")
        TablaReporteConcentrado.Columns.Add("tl17")
        TablaReporteConcentrado.Columns.Add("tl18")
        TablaReporteConcentrado.Columns.Add("tl19")
        TablaReporteConcentrado.Columns.Add("tl20")
        TablaReporteConcentrado.Columns.Add("t1")
        TablaReporteConcentrado.Columns.Add("t2")
        TablaReporteConcentrado.Columns.Add("t3")
        TablaReporteConcentrado.Columns.Add("t4")
        TablaReporteConcentrado.Columns.Add("t5")
        TablaReporteConcentrado.Columns.Add("t6")
        TablaReporteConcentrado.Columns.Add("t7")
        TablaReporteConcentrado.Columns.Add("t8")
        TablaReporteConcentrado.Columns.Add("t9")
        TablaReporteConcentrado.Columns.Add("t10")
        TablaReporteConcentrado.Columns.Add("t11")
        TablaReporteConcentrado.Columns.Add("t12")
        TablaReporteConcentrado.Columns.Add("t13")
        TablaReporteConcentrado.Columns.Add("t14")
        TablaReporteConcentrado.Columns.Add("t15")
        TablaReporteConcentrado.Columns.Add("t16")
        TablaReporteConcentrado.Columns.Add("t17")
        TablaReporteConcentrado.Columns.Add("t18")
        TablaReporteConcentrado.Columns.Add("t19")
        TablaReporteConcentrado.Columns.Add("t20")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("No") = tabla1.Rows(value).Item("No")
            row("Pares") = tabla1.Rows(value).Item("Pares")
            row("Lote") = tabla1.Rows(value).Item("Lote")
            row("Material") = tabla1.Rows(value).Item("Material")
            row("C5") = tabla1.Rows(value).Item("C5")
            row("Corrida") = tabla1.Rows(value).Item("Corrida")
            'row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 6 To 25
                If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2) = tabla1.Rows(value).Item(value2)
                    Dim X = value2 + 20
                    row(X) = tabla1.Rows(value).Item(value2 + 20)
                End If
            Next
            TablaReporteConcentrado.Rows.Add(row)
        Next

        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("PARES")
        tabla.Columns.Add("LOTE")
        tabla.Columns.Add("MATERIAL")
        tabla.Columns.Add("HORMA")
        tabla.Columns.Add("CORRIDA")
        tabla.Columns.Add("PROVEEDOR")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")

        For value = 0 To TablaReporteConcentrado.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("PARES") = TablaReporteConcentrado.Rows(value).Item("Pares")
            row("LOTE") = TablaReporteConcentrado.Rows(value).Item("Lote")
            row("MATERIAL") = TablaReporteConcentrado.Rows(value).Item("Material")
            row("HORMA") = TablaReporteConcentrado.Rows(value).Item("C5")
            row("CORRIDA") = TablaReporteConcentrado.Rows(value).Item("Corrida")
            row("PROVEEDOR") = TablaReporteConcentrado.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2 - 1) = TablaReporteConcentrado.Rows(value).Item(value2)
                End If
            Next
            tabla.Rows.Add(row)

            Dim row2 As DataRow = tabla.NewRow()
            row2("PARES") = ""
            row2("LOTE") = ""
            row2("MATERIAL") = ""
            row2("HORMA") = ""
            row2("CORRIDA") = ""
            row2("PROVEEDOR") = ""
            Dim NUM = 6
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then 'And TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "0"
                    row2(NUM) = TablaReporteConcentrado.Rows(value).Item(value2 + 20)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row2)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla

            With grdReportes.DisplayLayout.Bands(0)

                .Columns("PARES").Width = 60
                .Columns("LOTE").Width = 50
                .Columns("MATERIAL").Width = 200
                .Columns("HORMA").Width = 200
                .Columns("CORRIDA").Width = 70
                .Columns("PROVEEDOR").Width = 200
                .Columns("1").Width = 40
                .Columns("2").Width = 40
                .Columns("3").Width = 40
                .Columns("4").Width = 40
                .Columns("5").Width = 40
                .Columns("6").Width = 40
                .Columns("7").Width = 40
                .Columns("8").Width = 40
                .Columns("9").Width = 40
                .Columns("10").Width = 40
                .Columns("11").Width = 40
                .Columns("12").Width = 40
                .Columns("13").Width = 40
                .Columns("14").Width = 40
                .Columns("15").Width = 40
                .Columns("16").Width = 40
                .Columns("17").Width = 40
                .Columns("18").Width = 40
                .Columns("19").Width = 40
                .Columns("20").Width = 40

                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("HORMA").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("PARES").Header.Caption = "PARES"
                .Columns("LOTE").Header.Caption = "LOTE"
                .Columns("MATERIAL").Header.Caption = "MATERIAL"
                .Columns("HORMA").Header.Caption = "HORMA"
                .Columns("CORRIDA").Header.Caption = "CORRIDA"
                .Columns("PROVEEDOR").Header.Caption = "PROVEEDOR"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""

                'For value = 0 To grdReportes.Rows.Count - 1
                '    For value2 = 6 To 21
                '        If grdReportes.Rows(value).Cells(value2).Text = "" Then
                '            .Columns(value2).Hidden = True
                '        Else
                '            .Columns(value).Hidden = False
                '        End If
                '    Next
                'Next

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub DesglosadoTacon(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("TACON")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosada(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("No")
        TablaReporteConcentrado.Columns.Add("Pares")
        TablaReporteConcentrado.Columns.Add("Lote")
        TablaReporteConcentrado.Columns.Add("Material")
        TablaReporteConcentrado.Columns.Add("C5")
        TablaReporteConcentrado.Columns.Add("Corrida")
        TablaReporteConcentrado.Columns.Add("Proveedor")
        TablaReporteConcentrado.Columns.Add("tl1")
        TablaReporteConcentrado.Columns.Add("tl2")
        TablaReporteConcentrado.Columns.Add("tl3")
        TablaReporteConcentrado.Columns.Add("tl4")
        TablaReporteConcentrado.Columns.Add("tl5")
        TablaReporteConcentrado.Columns.Add("tl6")
        TablaReporteConcentrado.Columns.Add("tl7")
        TablaReporteConcentrado.Columns.Add("tl8")
        TablaReporteConcentrado.Columns.Add("tl9")
        TablaReporteConcentrado.Columns.Add("tl10")
        TablaReporteConcentrado.Columns.Add("tl11")
        TablaReporteConcentrado.Columns.Add("tl12")
        TablaReporteConcentrado.Columns.Add("tl13")
        TablaReporteConcentrado.Columns.Add("tl14")
        TablaReporteConcentrado.Columns.Add("tl15")
        TablaReporteConcentrado.Columns.Add("tl16")
        TablaReporteConcentrado.Columns.Add("tl17")
        TablaReporteConcentrado.Columns.Add("tl18")
        TablaReporteConcentrado.Columns.Add("tl19")
        TablaReporteConcentrado.Columns.Add("tl20")
        TablaReporteConcentrado.Columns.Add("t1")
        TablaReporteConcentrado.Columns.Add("t2")
        TablaReporteConcentrado.Columns.Add("t3")
        TablaReporteConcentrado.Columns.Add("t4")
        TablaReporteConcentrado.Columns.Add("t5")
        TablaReporteConcentrado.Columns.Add("t6")
        TablaReporteConcentrado.Columns.Add("t7")
        TablaReporteConcentrado.Columns.Add("t8")
        TablaReporteConcentrado.Columns.Add("t9")
        TablaReporteConcentrado.Columns.Add("t10")
        TablaReporteConcentrado.Columns.Add("t11")
        TablaReporteConcentrado.Columns.Add("t12")
        TablaReporteConcentrado.Columns.Add("t13")
        TablaReporteConcentrado.Columns.Add("t14")
        TablaReporteConcentrado.Columns.Add("t15")
        TablaReporteConcentrado.Columns.Add("t16")
        TablaReporteConcentrado.Columns.Add("t17")
        TablaReporteConcentrado.Columns.Add("t18")
        TablaReporteConcentrado.Columns.Add("t19")
        TablaReporteConcentrado.Columns.Add("t20")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("No") = tabla1.Rows(value).Item("No")
            row("Pares") = tabla1.Rows(value).Item("Pares")
            row("Lote") = tabla1.Rows(value).Item("Lote")
            row("Material") = tabla1.Rows(value).Item("Material")
            row("C5") = tabla1.Rows(value).Item("C5")
            row("Corrida") = tabla1.Rows(value).Item("Corrida")
            row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                If tabla1.Rows(value).Item(value2).ToString <> "" Then
                    row(value2) = tabla1.Rows(value).Item(value2)
                    Dim X = value2 + 20
                    row(X) = tabla1.Rows(value).Item(value2 + 20)
                End If
            Next
            TablaReporteConcentrado.Rows.Add(row)
        Next
        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("PARES")
        tabla.Columns.Add("LOTE")
        tabla.Columns.Add("MATERIAL")
        tabla.Columns.Add("COLECCIÓN")
        tabla.Columns.Add("CORRIDA")
        tabla.Columns.Add("PROVEEDOR")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")

        For value = 0 To TablaReporteConcentrado.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("PARES") = TablaReporteConcentrado.Rows(value).Item("Pares")
            row("LOTE") = TablaReporteConcentrado.Rows(value).Item("Lote")
            row("MATERIAL") = TablaReporteConcentrado.Rows(value).Item("Material")
            row("COLECCIÓN") = TablaReporteConcentrado.Rows(value).Item("C5")
            row("CORRIDA") = TablaReporteConcentrado.Rows(value).Item("Corrida")
            row("PROVEEDOR") = TablaReporteConcentrado.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2 - 1) = TablaReporteConcentrado.Rows(value).Item(value2)
                End If
            Next
            tabla.Rows.Add(row)

            Dim row2 As DataRow = tabla.NewRow()
            row2("PARES") = ""
            row2("LOTE") = ""
            row2("MATERIAL") = ""
            row2("COLECCIÓN") = ""
            row2("CORRIDA") = ""
            row2("PROVEEDOR") = ""
            Dim NUM = 6
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then 'And TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "0"
                    row2(NUM) = TablaReporteConcentrado.Rows(value).Item(value2 + 20)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row2)
        Next
        Try
            Me.Cursor = Cursors.WaitCursor
            grdReportes.DataSource = tabla
            With grdReportes.DisplayLayout.Bands(0)

                .Columns("PARES").Width = 60
                .Columns("LOTE").Width = 50
                .Columns("MATERIAL").Width = 200
                .Columns("COLECCIÓN").Width = 250
                .Columns("CORRIDA").Width = 75
                .Columns("PROVEEDOR").Width = 200
                .Columns("1").Width = 40
                .Columns("2").Width = 40
                .Columns("3").Width = 40
                .Columns("4").Width = 40
                .Columns("5").Width = 40
                .Columns("6").Width = 40
                .Columns("7").Width = 40
                .Columns("8").Width = 40
                .Columns("9").Width = 40
                .Columns("10").Width = 40
                .Columns("11").Width = 40
                .Columns("12").Width = 40
                .Columns("13").Width = 40
                .Columns("14").Width = 40
                .Columns("15").Width = 40
                .Columns("16").Width = 40
                .Columns("17").Width = 40
                .Columns("18").Width = 40
                .Columns("19").Width = 40
                .Columns("20").Width = 40

                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("PARES").Header.Caption = "PARES"
                .Columns("LOTE").Header.Caption = "LOTE"
                .Columns("MATERIAL").Header.Caption = "MATERIAL"
                .Columns("COLECCIÓN").Header.Caption = "COLECCIÓN"
                .Columns("CORRIDA").Header.Caption = "CORRIDA"
                .Columns("PROVEEDOR").Header.Caption = "PROVEEDOR"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub



    Public Sub DesglosadoSuela(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosada(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("No")
        TablaReporteConcentrado.Columns.Add("Pares")
        TablaReporteConcentrado.Columns.Add("Lote")
        TablaReporteConcentrado.Columns.Add("Material")
        TablaReporteConcentrado.Columns.Add("C5")
        TablaReporteConcentrado.Columns.Add("Corrida")
        TablaReporteConcentrado.Columns.Add("Proveedor")
        TablaReporteConcentrado.Columns.Add("tl1")
        TablaReporteConcentrado.Columns.Add("tl2")
        TablaReporteConcentrado.Columns.Add("tl3")
        TablaReporteConcentrado.Columns.Add("tl4")
        TablaReporteConcentrado.Columns.Add("tl5")
        TablaReporteConcentrado.Columns.Add("tl6")
        TablaReporteConcentrado.Columns.Add("tl7")
        TablaReporteConcentrado.Columns.Add("tl8")
        TablaReporteConcentrado.Columns.Add("tl9")
        TablaReporteConcentrado.Columns.Add("tl10")
        TablaReporteConcentrado.Columns.Add("tl11")
        TablaReporteConcentrado.Columns.Add("tl12")
        TablaReporteConcentrado.Columns.Add("tl13")
        TablaReporteConcentrado.Columns.Add("tl14")
        TablaReporteConcentrado.Columns.Add("tl15")
        TablaReporteConcentrado.Columns.Add("tl16")
        TablaReporteConcentrado.Columns.Add("tl17")
        TablaReporteConcentrado.Columns.Add("tl18")
        TablaReporteConcentrado.Columns.Add("tl19")
        TablaReporteConcentrado.Columns.Add("tl20")
        TablaReporteConcentrado.Columns.Add("t1")
        TablaReporteConcentrado.Columns.Add("t2")
        TablaReporteConcentrado.Columns.Add("t3")
        TablaReporteConcentrado.Columns.Add("t4")
        TablaReporteConcentrado.Columns.Add("t5")
        TablaReporteConcentrado.Columns.Add("t6")
        TablaReporteConcentrado.Columns.Add("t7")
        TablaReporteConcentrado.Columns.Add("t8")
        TablaReporteConcentrado.Columns.Add("t9")
        TablaReporteConcentrado.Columns.Add("t10")
        TablaReporteConcentrado.Columns.Add("t11")
        TablaReporteConcentrado.Columns.Add("t12")
        TablaReporteConcentrado.Columns.Add("t13")
        TablaReporteConcentrado.Columns.Add("t14")
        TablaReporteConcentrado.Columns.Add("t15")
        TablaReporteConcentrado.Columns.Add("t16")
        TablaReporteConcentrado.Columns.Add("t17")
        TablaReporteConcentrado.Columns.Add("t18")
        TablaReporteConcentrado.Columns.Add("t19")
        TablaReporteConcentrado.Columns.Add("t20")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("No") = tabla1.Rows(value).Item("No")
            row("Pares") = tabla1.Rows(value).Item("Pares")
            row("Lote") = tabla1.Rows(value).Item("Lote")
            row("Material") = tabla1.Rows(value).Item("Material")
            row("C5") = tabla1.Rows(value).Item("C5")
            row("Corrida") = tabla1.Rows(value).Item("Corrida")
            row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2) = tabla1.Rows(value).Item(value2)
                    Dim X = value2 + 20
                    row(X) = tabla1.Rows(value).Item(value2 + 20)
                End If
            Next
            TablaReporteConcentrado.Rows.Add(row)
        Next
        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("PARES")
        tabla.Columns.Add("LOTE")
        tabla.Columns.Add("MATERIAL")
        tabla.Columns.Add("COLECCIÓN")
        tabla.Columns.Add("CORRIDA")
        tabla.Columns.Add("PROVEEDOR")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")

        For value = 0 To TablaReporteConcentrado.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("PARES") = TablaReporteConcentrado.Rows(value).Item("Pares")
            row("LOTE") = TablaReporteConcentrado.Rows(value).Item("Lote")
            row("MATERIAL") = TablaReporteConcentrado.Rows(value).Item("Material")
            row("COLECCIÓN") = TablaReporteConcentrado.Rows(value).Item("C5")
            row("CORRIDA") = TablaReporteConcentrado.Rows(value).Item("Corrida")
            row("PROVEEDOR") = TablaReporteConcentrado.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2 - 1) = TablaReporteConcentrado.Rows(value).Item(value2)
                End If
            Next
            tabla.Rows.Add(row)

            Dim row2 As DataRow = tabla.NewRow()
            row2("PARES") = ""
            row2("LOTE") = ""
            row2("MATERIAL") = ""
            row2("COLECCIÓN") = ""
            row2("CORRIDA") = ""
            row2("PROVEEDOR") = ""
            Dim NUM = 6
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then 'And TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "0"
                    row2(NUM) = TablaReporteConcentrado.Rows(value).Item(value2 + 20)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row2)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla

            With grdReportes.DisplayLayout.Bands(0)

                .Columns("PARES").Width = 60
                .Columns("LOTE").Width = 50
                .Columns("MATERIAL").Width = 200
                .Columns("COLECCIÓN").Width = 250
                .Columns("CORRIDA").Width = 75
                .Columns("PROVEEDOR").Width = 200
                .Columns("1").Width = 40
                .Columns("2").Width = 40
                .Columns("3").Width = 40
                .Columns("4").Width = 40
                .Columns("5").Width = 40
                .Columns("6").Width = 40
                .Columns("7").Width = 40
                .Columns("8").Width = 40
                .Columns("9").Width = 40
                .Columns("10").Width = 40
                .Columns("11").Width = 40
                .Columns("12").Width = 40
                .Columns("13").Width = 40
                .Columns("14").Width = 40
                .Columns("15").Width = 40
                .Columns("16").Width = 40
                .Columns("17").Width = 40
                .Columns("18").Width = 40
                .Columns("19").Width = 40
                .Columns("20").Width = 40

                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("PARES").Header.Caption = "PARES"
                .Columns("LOTE").Header.Caption = "LOTE"
                .Columns("MATERIAL").Header.Caption = "MATERIAL"
                .Columns("COLECCIÓN").Header.Caption = "COLECCIÓN"
                .Columns("CORRIDA").Header.Caption = "CORRIDA"
                .Columns("PROVEEDOR").Header.Caption = "PROVEEDOR"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""

                'For value = 0 To grdReportes.Rows.Count - 1
                '    For value2 = 6 To 21
                '        If grdReportes.Rows(value).Cells(value2).Text = "" Then
                '            .Columns(value2).Hidden = True
                '        Else
                '            .Columns(value).Hidden = False
                '        End If
                '    Next
                'Next

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Public Sub DesglosadoContrafuerte(ByVal fecha As String, ByVal nave As Integer, ByVal Clasificacion As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        ' Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        'tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        'clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Buscar id clasificación de contrafuerte
        tablaClasificacion = obj.ObtenerClasificacion("CONTRAFUERTE")
        Clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDeCascoYContrafuerte(fecha, nave, Clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("No")
        TablaReporteConcentrado.Columns.Add("Pares")
        TablaReporteConcentrado.Columns.Add("Lote")
        TablaReporteConcentrado.Columns.Add("Material")
        TablaReporteConcentrado.Columns.Add("C5")
        TablaReporteConcentrado.Columns.Add("Corrida")
        TablaReporteConcentrado.Columns.Add("Proveedor")
        TablaReporteConcentrado.Columns.Add("tl1")
        TablaReporteConcentrado.Columns.Add("tl2")
        TablaReporteConcentrado.Columns.Add("tl3")
        TablaReporteConcentrado.Columns.Add("tl4")
        TablaReporteConcentrado.Columns.Add("tl5")
        TablaReporteConcentrado.Columns.Add("tl6")
        TablaReporteConcentrado.Columns.Add("tl7")
        TablaReporteConcentrado.Columns.Add("tl8")
        TablaReporteConcentrado.Columns.Add("tl9")
        TablaReporteConcentrado.Columns.Add("tl10")
        TablaReporteConcentrado.Columns.Add("tl11")
        TablaReporteConcentrado.Columns.Add("tl12")
        TablaReporteConcentrado.Columns.Add("tl13")
        TablaReporteConcentrado.Columns.Add("tl14")
        TablaReporteConcentrado.Columns.Add("tl15")
        TablaReporteConcentrado.Columns.Add("tl16")
        TablaReporteConcentrado.Columns.Add("tl17")
        TablaReporteConcentrado.Columns.Add("tl18")
        TablaReporteConcentrado.Columns.Add("tl19")
        TablaReporteConcentrado.Columns.Add("tl20")
        TablaReporteConcentrado.Columns.Add("t1")
        TablaReporteConcentrado.Columns.Add("t2")
        TablaReporteConcentrado.Columns.Add("t3")
        TablaReporteConcentrado.Columns.Add("t4")
        TablaReporteConcentrado.Columns.Add("t5")
        TablaReporteConcentrado.Columns.Add("t6")
        TablaReporteConcentrado.Columns.Add("t7")
        TablaReporteConcentrado.Columns.Add("t8")
        TablaReporteConcentrado.Columns.Add("t9")
        TablaReporteConcentrado.Columns.Add("t10")
        TablaReporteConcentrado.Columns.Add("t11")
        TablaReporteConcentrado.Columns.Add("t12")
        TablaReporteConcentrado.Columns.Add("t13")
        TablaReporteConcentrado.Columns.Add("t14")
        TablaReporteConcentrado.Columns.Add("t15")
        TablaReporteConcentrado.Columns.Add("t16")
        TablaReporteConcentrado.Columns.Add("t17")
        TablaReporteConcentrado.Columns.Add("t18")
        TablaReporteConcentrado.Columns.Add("t19")
        TablaReporteConcentrado.Columns.Add("t20")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("No") = tabla1.Rows(value).Item("No")
            row("Pares") = tabla1.Rows(value).Item("Pares")
            row("Lote") = tabla1.Rows(value).Item("Lote")
            row("Material") = tabla1.Rows(value).Item("Material")
            row("C5") = tabla1.Rows(value).Item("C5")
            row("Corrida") = tabla1.Rows(value).Item("Corrida")
            row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 7 To 26
                If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2) = tabla1.Rows(value).Item(value2)
                    Dim X = value2 + 20
                    row(X) = tabla1.Rows(value).Item(value2 + 20)
                End If
            Next
            TablaReporteConcentrado.Rows.Add(row)
        Next

        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("No")
        tabla.Columns.Add("Pares")
        tabla.Columns.Add("Lote")
        tabla.Columns.Add("Casco")
        tabla.Columns.Add("Contrafuerte")
        tabla.Columns.Add("Corrida")
        tabla.Columns.Add("Proveedor")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")

        For value = 0 To TablaReporteConcentrado.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("No") = TablaReporteConcentrado.Rows(value).Item("No")
            row("Pares") = TablaReporteConcentrado.Rows(value).Item("Pares")
            row("Lote") = TablaReporteConcentrado.Rows(value).Item("Lote")
            row("Casco") = TablaReporteConcentrado.Rows(value).Item("Material")
            row("Contrafuerte") = TablaReporteConcentrado.Rows(value).Item("C5")
            row("Corrida") = TablaReporteConcentrado.Rows(value).Item("Corrida")
            row("Proveedor") = TablaReporteConcentrado.Rows(value).Item("Proveedor")
            Dim NUM = 7
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(NUM) = TablaReporteConcentrado.Rows(value).Item(value2)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row)

            Dim row2 As DataRow = tabla.NewRow()
            row2("No") = ""
            row2("Pares") = ""
            row2("Lote") = ""
            row2("Casco") = ""
            row2("Contrafuerte") = ""
            row2("Corrida") = ""
            row2("Proveedor") = ""
            Dim NUM2 = 7
            For value2 = 7 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then 'And TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "0"
                    row2(NUM2) = TablaReporteConcentrado.Rows(value).Item(value2 + 20)
                    NUM2 = NUM2 + 1
                End If
            Next
            tabla.Rows.Add(row2)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("No").Hidden = True
                .Columns("Casco").Hidden = True

                .Columns("Pares").Width = 60
                .Columns("Lote").Width = 50
                .Columns("Casco").Width = 200
                .Columns("Contrafuerte").Width = 400
                .Columns("Corrida").Width = 70
                .Columns("Proveedor").Width = 200
                .Columns("1").Width = 40
                .Columns("2").Width = 40
                .Columns("3").Width = 40
                .Columns("4").Width = 40
                .Columns("5").Width = 40
                .Columns("6").Width = 40
                .Columns("7").Width = 40
                .Columns("8").Width = 40
                .Columns("9").Width = 40
                .Columns("10").Width = 40
                .Columns("11").Width = 40
                .Columns("12").Width = 40
                .Columns("13").Width = 40
                .Columns("14").Width = 40
                .Columns("15").Width = 40
                .Columns("16").Width = 40
                .Columns("17").Width = 40
                .Columns("18").Width = 40
                .Columns("19").Width = 40
                .Columns("20").Width = 40

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Casco").CellActivation = Activation.NoEdit
                .Columns("Contrafuerte").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Casco").Header.Caption = "CASCO"
                .Columns("Contrafuerte").Header.Caption = "CONTRAFUERTE"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub
#End Region

#Region "Ordenes"
    Public Sub OrdenDesglosadoCorte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        listaComponentes.Clear()
        tabla1 = obj.ConsultaOrdenDePedidoDesglosadoPAraCorte1(fecha, nave)
        tabla2 = obj.ConsultaOrdenDePedidoDesglosadoPAraCorte2(fecha, nave)
        Try
            For value = 0 To tabla1.Rows.Count - 1
                Dim contador = 1
                For value2 = 29 To 48
                    Dim aux = tabla2.Rows(value).Item(contador)
                    tabla1.Rows(value).Item(value2) = aux
                    contador = contador + 1
                Next
            Next
            For value = 0 To tabla1.Rows.Count - 1
                For value2 = 10 To 29
                    If tabla1.Rows(value).Item(value2).ToString = "" And tabla1.Rows(value).Item(value2 + 20).ToString = "0" Then
                        tabla1.Rows(value).Item(value2 + 20) = ""
                    End If
                Next
            Next
        Catch ex As Exception
        End Try
        tabla1.TableName = ""

        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("PARES")
        tabla.Columns.Add("LOTE")
        tabla.Columns.Add("COLECCIÓN")
        tabla.Columns.Add("MODELO")
        tabla.Columns.Add("MODELOSICY")
        tabla.Columns.Add("CORRIDA")
        tabla.Columns.Add("COLOR")
        tabla.Columns.Add("CORTADOR PIEL")
        tabla.Columns.Add("CORTADOR FORRO")
        ' tabla.Columns.Add("PROVEEDOR")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")


        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("PARES") = tabla1.Rows(value).Item("Pares")
            row("LOTE") = tabla1.Rows(value).Item("Lote")
            row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            row("MODELO") = tabla1.Rows(value).Item("Modelo")
            row("MODELOSICY") = tabla1.Rows(value).Item("ModeloSICY")
            row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            row("COLOR") = tabla1.Rows(value).Item("Color")
            row("CORTADOR PIEL") = tabla1.Rows(value).Item("Cortador") + " / " + tabla1.Rows(value).Item("Cortador2")
            row("CORTADOR FORRO") = tabla1.Rows(value).Item("CortadorForro") + " / " + tabla1.Rows(value).Item("CortadorForro2")

            'row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            Dim NUM = 10
            For value2 = 10 To 27
                If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(NUM) = tabla1.Rows(value).Item(value2)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("PARES").Width = 55
                .Columns("LOTE").Width = 100
                .Columns("COLECCIÓN").Width = 280
                .Columns("MODELO").Width = 55
                .Columns("MODELO").Hidden = True
                .Columns("MODELOSICY").Width = 65
                .Columns("CORRIDA").Width = 75
                .Columns("COLOR").Width = 200
                .Columns("CORTADOR PIEL").Width = 90
                .Columns("CORTADOR FORRO").Width = 90
                '.Columns("PROVEEDOR").Width = 200
                .Columns("1").Width = 40
                .Columns("2").Width = 40
                .Columns("3").Width = 40
                .Columns("4").Width = 40
                .Columns("5").Width = 40
                .Columns("6").Width = 40
                .Columns("7").Width = 40
                .Columns("8").Width = 40
                .Columns("9").Width = 40
                .Columns("10").Width = 40
                .Columns("11").Width = 40
                .Columns("12").Width = 40
                .Columns("13").Width = 40
                .Columns("14").Width = 40
                .Columns("15").Width = 40
                .Columns("16").Width = 40
                .Columns("17").Width = 40
                .Columns("18").Width = 40
                .Columns("19").Width = 40
                .Columns("20").Width = 40

                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("MODELO").CellAppearance.TextHAlign = HAlign.Center
                .Columns("MODELOSICY").CellAppearance.TextHAlign = HAlign.Center

                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("MODELO").CellActivation = Activation.NoEdit
                .Columns("MODELOSICY").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("COLOR").CellActivation = Activation.NoEdit
                .Columns("CORTADOR PIEL").CellActivation = Activation.NoEdit
                .Columns("CORTADOR FORRO").CellActivation = Activation.NoEdit
                '.Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("1").Hidden = True
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("MODELO").Header.Caption = "MODELO" + vbCrLf + "SAY"
                .Columns("MODELOSICY").Header.Caption = "MODELO" + vbCrLf + "SICY"
                .Columns("CORTADOR PIEL").Header.Caption = "CORTADOR" + vbCrLf + "PIEL / SINT"
                .Columns("CORTADOR FORRO").Header.Caption = "CORTADOR" + vbCrLf + "FORRO / SINT"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""

                '.Columns("PROVEEDOR").Hidden = True

                'For value = 0 To grdReportes.Rows.Count - 1
                '    For value2 = 9 To 24
                '        If grdReportes.Rows(value).Cells(value2).Text = "" Then
                '            .Columns(value2).Hidden = True
                '        Else
                '            .Columns(value2).Hidden = False
                '        End If
                '    Next
                'Next

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub OrdenProduccion(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteOrdenesDeProduccionfake(fecha, nave, clasificacion)
        'tabla1 = obj.ReporteOrdenesDeProduccion(fecha, nave, clasificacion)
        For value = 0 To tabla1.Rows.Count - 1
            Dim x = tabla1.Rows(value).Item("Suela").ToString
            tabla1.Rows(value).Item("Suela") = x.Trim.Replace("SUELA ", "")
        Next
        'Concatenar Cortador1 con cortador2
        tabla1.TableName = ""
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            'ModeloSICY

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("Pares").Width = 50
                .Columns("Lote").Width = 50
                .Columns("Colección").Width = 200
                .Columns("ModeloSAY").Width = 100
                .Columns("ModeloSICY").Width = 100
                .Columns("ModeloSAY").Hidden = True
                .Columns("Corrida").Width = 70
                .Columns("Color").Width = 200
                .Columns("Suela").Width = 350
                .Columns("Cortador p").Width = 140
                .Columns("Cortador F").Width = 140
                .Columns("Cliente").Width = 300

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSAY").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center


                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("ModeloSAY").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Suela").CellActivation = Activation.NoEdit
                .Columns("Cortador p").CellActivation = Activation.NoEdit
                .Columns("Cortador F").CellActivation = Activation.NoEdit
                .Columns("Cliente").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Colección").Header.Caption = "COLECCIÓN"
                .Columns("ModeloSAY").Header.Caption = "MODELO SAY"
                .Columns("ModeloSICY").Header.Caption = "MODELO SICY"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Color").Header.Caption = "COLOR"
                .Columns("Suela").Header.Caption = "SUELA"
                .Columns("Cortador p").Header.Caption = "CORTADOR" + vbCrLf + "PIEL"
                .Columns("Cortador F").Header.Caption = "CORTADOR" + vbCrLf + "PIEL SINT"
                .Columns("Cliente").Header.Caption = "CLIENTE"

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid

    End Sub

    Public Sub OrdenProduccionFacturadoYRemisionado(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable

        tabla1 = obj.ReporteOrdenesDeProduccion_FacturadoYRemisionado(fecha, nave)
        tabla1.TableName = ""
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            'ModeloSICY

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("TipoCliente").Width = 100
                .Columns("Lote").Width = 50
                .Columns("Colección").Width = 200
                .Columns("ModeloSAY").Width = 100
                .Columns("ModeloSICY").Width = 100
                .Columns("ModeloSAY").Width = 100
                .Columns("Corrida").Width = 70
                .Columns("Color").Width = 200
                .Columns("Cliente").Width = 300
                .Columns("Facturado").Width = 100
                .Columns("Remisionado").Width = 100

                .Columns("ModeloSAY").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center


                .Columns("TipoCliente").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("ModeloSAY").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Cliente").CellActivation = Activation.NoEdit
                .Columns("Facturado").CellActivation = Activation.NoEdit
                .Columns("Remisionado").CellActivation = Activation.NoEdit
                .Columns("Clave SAT").CellActivation = Activation.NoEdit

                .Columns("TipoCliente").Header.Caption = "TIPO"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Colección").Header.Caption = "COLECCIÓN"
                .Columns("ModeloSAY").Header.Caption = "MODELO SAY"
                .Columns("ModeloSICY").Header.Caption = "MODELO SICY"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Color").Header.Caption = "COLOR"
                .Columns("Cliente").Header.Caption = "CLIENTE"
                .Columns("Facturado").Header.Caption = "FACTURADO"
                .Columns("Remisionado").Header.Caption = "REMISIONADO"
                .Columns("Clave SAT").Header.Caption = "CLAVE SAT"


                If .Columns.Contains("Pares") Then
                    .Columns("Pares").Width = 50
                    .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                    .Columns("Pares").CellActivation = Activation.NoEdit
                    .Columns("Pares").Header.Caption = "PARES"
                End If

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            Dim lstLotes As New List(Of Integer)

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.DisplayLayout.Bands(0).Columns.Contains("Pares") Then
                    If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                        pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                        'lotes = lotes + 1
                    End If
                Else
                    pares = pares + grdReportes.Rows(value).Cells("Facturado").Value + grdReportes.Rows(value).Cells("Remisionado").Value

                End If
                If lstLotes.Contains(grdReportes.Rows(value).Cells("Lote").Value) = False Then
                    lstLotes.Add(grdReportes.Rows(value).Cells("Lote").Value)
                End If
            Next
            lotes = lstLotes.Count()
            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid

    End Sub
#End Region

#Region "Programas Corte"
    Public Sub ProgramaCorteForro(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Obtener los id de los componentes piel1, piel2, etc
        listaComponentes.Clear()
        tablaComponentes = obj.ObtenerComponentes("FORRO", "FORRO SINT")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        Dim tipo As String = "FORRO"
        Dim tablaProgramaCorte = New DataTable
        tablaProgramaCorte.Columns.Add("No")
        tablaProgramaCorte.Columns.Add("Pares")
        tablaProgramaCorte.Columns.Add("Lote")
        tablaProgramaCorte.Columns.Add("Colección")
        tablaProgramaCorte.Columns.Add("Modelo")
        tablaProgramaCorte.Columns.Add("ModeloSICY")
        tablaProgramaCorte.Columns.Add("Corrida")
        tablaProgramaCorte.Columns.Add("Material")
        tablaProgramaCorte.Columns.Add("Color")
        tablaProgramaCorte.Columns.Add("Cortador")
        tablaProgramaCorte.Columns.Add("CantidadUnidad")
        tablaProgramaCorte.Columns.Add("CantidadML")

        Dim tablaProveedorMaterial = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProgramaCorteDePiel = obj.ConsultaCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProveedorMateriales = tablaProveedorMaterial
        Dim tablaCortadores = obj.ConsultaCortadoresReporte(fecha, nave, listaComponentes, tipo)
        Dim Lote As Integer = 0
        Dim cortador As String = ""
        Dim contador = 0
        Dim cortadortabla As String = ""

        For value = 0 To tablaProgramaCorteDePiel.Rows.Count - 1

            Dim row As DataRow = tablaProgramaCorte.NewRow()
            If IsDBNull(tablaProgramaCorteDePiel.Rows(value).Item("Cortador")) = True Then
            Else
                cortadortabla = tablaProgramaCorteDePiel.Rows(value).Item("Cortador")
            End If
            If Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote") And cortador = cortadortabla Then

                tablaProgramaCorte.Rows(contador - 1).Item("Material") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Material")
                tablaProgramaCorte.Rows(contador - 1).Item("CantidadUnidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") &
                    " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                tablaProgramaCorte.Rows(contador - 1).Item("CantidadML") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad")
            Else
                contador = contador + 1
                row("No") = contador
                row("Pares") = tablaProgramaCorteDePiel.Rows(value).Item("Pares")
                row("Lote") = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                row("Colección") = tablaProgramaCorteDePiel.Rows(value).Item("Colección")
                row("Modelo") = tablaProgramaCorteDePiel.Rows(value).Item("Modelo")
                row("ModeloSICY") = tablaProgramaCorteDePiel.Rows(value).Item("ModeloSICY")
                row("Corrida") = tablaProgramaCorteDePiel.Rows(value).Item("Corrida")
                row("Color") = tablaProgramaCorteDePiel.Rows(value).Item("Color")
                row("Material") = tablaProgramaCorteDePiel.Rows(value).Item("Material")
                row("Cortador") = cortadortabla
                cortador = cortadortabla
                row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") & " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                tablaProgramaCorte.Rows.Add(row)
                row("CantidadML") = tablaProgramaCorteDePiel.Rows(value).Item("CantidadML")

            End If

        Next

        tablaProveedorMaterial.TableName = "DSTablaMateriales"
        tablaProgramaCorte.TableName = "DSTabla"
        tablaCortadores.TableName = "DSTablaCortadores"
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            pnlReportesPieles.Visible = True
            pnlReportesGenerales.Visible = False

            grdProgramaCorte.DataSource = tablaProgramaCorte
            grdMateriales.DataSource = tablaProveedorMaterial


            With grdProgramaCorte.DisplayLayout.Bands(0)

                .Columns("No").Hidden = True
                .Columns("CantidadML").Hidden = True

                .Columns("Pares").Width = 20
                .Columns("Lote").Width = 35
                .Columns("Colección").Width = 70
                .Columns("Modelo").Width = 30
                .Columns("ModeloSICY").Width = 30
                .Columns("Modelo").Hidden = True
                .Columns("Corrida").Width = 45
                .Columns("Color").Width = 70
                .Columns("Material").Width = 200
                .Columns("Cortador").Width = 150
                .Columns("CantidadUnidad").Width = 100
                .Columns("CantidadML").Width = 100

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CantidadUnidad").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CantidadML").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center

                'Try
                '    .Columns("copr_componenteid").Hidden = True
                '    .Columns("copr_clasificacionid").Hidden = True
                'Catch ex As Exception
                'End Try

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Cortador").CellActivation = Activation.NoEdit
                .Columns("CantidadUnidad").CellActivation = Activation.NoEdit
                .Columns("CantidadML").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Colección").Header.Caption = "MARCA"
                .Columns("Modelo").Header.Caption = "MODELO" & vbCrLf & "SAY"
                .Columns("ModeloSICY").Header.Caption = "MODELO" & vbCrLf & "SICY"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Color").Header.Caption = "COLOR"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Cortador").Header.Caption = "CORTADOR"
                .Columns("CantidadUnidad").Header.Caption = "CANTIDAD" & vbCrLf & "CDM2"
                .Columns("CantidadML").Header.Caption = "CANTIDAD" & vbCrLf & "ML"

            End With
            grdProgramaCorte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdProgramaCorte.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdProgramaCorte.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            With grdMateriales.DisplayLayout.Bands(0)

                .Columns("ConcentradoML").Hidden = True

                .Columns("Proveedor").Width = 200
                .Columns("Material").Width = 500
                .Columns("Concentrado").Width = 100
                .Columns("ConcentradoML").Width = 100
                .Columns("Corta").Width = 150

                Try
                    .Columns("copr_componenteid").Hidden = True
                    .Columns("copr_clasificacionid").Hidden = True
                Catch ex As Exception
                End Try

                .Columns("Concentrado").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ConcentradoML").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Concentrado").CellActivation = Activation.NoEdit
                .Columns("ConcentradoML").CellActivation = Activation.NoEdit
                .Columns("Corta").CellActivation = Activation.NoEdit

                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Concentrado").Header.Caption = "CONCENTRADO" & vbCrLf & "DCM2"
                .Columns("ConcentradoML").Header.Caption = "CONCENTRADO" & vbCrLf & "ML"
                .Columns("Corta").Header.Caption = "CORTADOR"

                .Columns("Concentrado").Format = "##,##0"
                '.Columns("ConcentradoML").Format = "##,##0.000"

            End With
            grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            Dim dcm As Double = 0
            Dim ml As Double = 0

            For value = 0 To grdProgramaCorte.Rows.Count - 1
                If grdProgramaCorte.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdProgramaCorte.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next
            For value = 0 To grdMateriales.Rows.Count - 1
                dcm = dcm + grdMateriales.Rows(value).Cells("Concentrado").Value
            Next

            For value = 0 To grdMateriales.Rows.Count - 1
                ml = ml + grdMateriales.Rows(value).Cells("ConcentradoML").Value
            Next

            lblDcm.Visible = True
            lblDcmResultado.Visible = True

            lblDcmResultado.Text = Format(dcm, "##,##0.00")
            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdProgramaCorte.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
            Me.Cursor = Cursors.Default
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub ProgramaCorteSinteticos(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Obtener los id de los componentes sintetico1, sintetico2, etc
        listaComponentes.Clear()
        tablaComponentes = obj.ObtenerComponentes("FORRO SINT", "xxxxxx")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        Dim tipo As String = "FORROSINT"
        Dim tablaProgramaCorte = New DataTable
        tablaProgramaCorte.Columns.Add("No")
        tablaProgramaCorte.Columns.Add("Pares")
        tablaProgramaCorte.Columns.Add("Lote")
        tablaProgramaCorte.Columns.Add("Colección")
        tablaProgramaCorte.Columns.Add("Modelo")
        tablaProgramaCorte.Columns.Add("ModeloSICY")
        tablaProgramaCorte.Columns.Add("Corrida")
        tablaProgramaCorte.Columns.Add("Color")
        tablaProgramaCorte.Columns.Add("Material")
        tablaProgramaCorte.Columns.Add("Cortador")
        tablaProgramaCorte.Columns.Add("CantidadUnidad")
        tablaProgramaCorte.Columns.Add("CantidadML")

        Dim tablaProveedorMaterial = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProgramaCorteDePiel = obj.ConsultaCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProveedorMateriales = tablaProveedorMaterial
        Dim tablaCortadores = obj.ConsultaCortadoresReporte(fecha, nave, listaComponentes, tipo)
        Dim Lote As Integer = 0
        Dim cortador As String = ""
        Dim contador = 0
        Dim cortadortabla As String = ""
        For value = 0 To tablaProgramaCorteDePiel.Rows.Count - 1

            Dim row As DataRow = tablaProgramaCorte.NewRow()
            If IsDBNull(tablaProgramaCorteDePiel.Rows(value).Item("Cortador")) = True Then
            Else
                cortadortabla = tablaProgramaCorteDePiel.Rows(value).Item("Cortador")
            End If
            'If Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote") And cortador = cortadortabla Then
            '    '    tablaProgramaCorte.Rows(contador - 1).Item("Material") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Material")
            '    '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadUnidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") &
            '    '    " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
            '    '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadML") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("CantidadML")

            'Else
            contador = contador + 1
            row("No") = contador
            row("Pares") = tablaProgramaCorteDePiel.Rows(value).Item("Pares")
            row("Lote") = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
            Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
            row("Colección") = tablaProgramaCorteDePiel.Rows(value).Item("Colección")
            row("Modelo") = tablaProgramaCorteDePiel.Rows(value).Item("Modelo")
            row("ModeloSICY") = tablaProgramaCorteDePiel.Rows(value).Item("ModeloSICY")
            row("Corrida") = tablaProgramaCorteDePiel.Rows(value).Item("Corrida")
            row("Color") = tablaProgramaCorteDePiel.Rows(value).Item("Color")
            row("Material") = tablaProgramaCorteDePiel.Rows(value).Item("Material")
            row("Cortador") = cortadortabla
            cortador = cortadortabla
            row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") & " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
            tablaProgramaCorte.Rows.Add(row)
            row("CantidadML") = tablaProgramaCorteDePiel.Rows(value).Item("CantidadML")
            'End If
        Next

        tablaProveedorMaterial.TableName = "DSTablaMateriales"
        tablaProgramaCorte.TableName = "DSTabla"
        tablaCortadores.TableName = "DSTablaCortadores"
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            pnlReportesPieles.Visible = True
            pnlReportesGenerales.Visible = False

            grdProgramaCorte.DataSource = tablaProgramaCorte
            grdMateriales.DataSource = tablaProveedorMaterial


            With grdProgramaCorte.DisplayLayout.Bands(0)

                .Columns("No").Hidden = True
                'Try
                '    .Columns("copr_componenteid").Hidden = True
                '    .Columns("copr_clasificacionid").Hidden = True
                'Catch ex As Exception
                'End Try

                .Columns("Pares").Width = 20
                .Columns("Lote").Width = 20
                .Columns("Colección").Width = 70
                .Columns("Modelo").Width = 30
                .Columns("ModeloSICY").Width = 30
                .Columns("Corrida").Width = 30
                .Columns("Color").Width = 70
                .Columns("Material").Width = 200
                .Columns("Cortador").Width = 150
                .Columns("CantidadUnidad").Width = 100
                .Columns("CantidadML").Width = 100

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CantidadUnidad").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CantidadML").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Cortador").CellActivation = Activation.NoEdit
                .Columns("CantidadUnidad").CellActivation = Activation.NoEdit
                .Columns("CantidadML").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Colección").Header.Caption = "COLECCIÓN"
                .Columns("Modelo").Header.Caption = "MODELO" & vbCrLf & "SAY"
                .Columns("ModeloSICY").Header.Caption = "MODELO" & vbCrLf & "SICY"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Color").Header.Caption = "COLOR"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Cortador").Header.Caption = "CORTADOR"
                .Columns("CantidadUnidad").Header.Caption = "CANTIDAD" & vbCrLf & "DCM2"
                .Columns("CantidadML").Header.Caption = "CANTIDAD" & vbCrLf & "ML"


            End With
            grdProgramaCorte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdProgramaCorte.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdProgramaCorte.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            With grdMateriales.DisplayLayout.Bands(0)

                .Columns("Proveedor").Width = 200
                .Columns("Material").Width = 500
                .Columns("Concentrado").Width = 100
                .Columns("ConcentradoML").Width = 100
                .Columns("Corta").Width = 150

                .Columns("Concentrado").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ConcentradoML").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Concentrado").CellActivation = Activation.NoEdit
                .Columns("ConcentradoML").CellActivation = Activation.NoEdit
                .Columns("Corta").CellActivation = Activation.NoEdit

                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Concentrado").Header.Caption = "CONCENTRADO" & vbCrLf & "CDM2"
                .Columns("ConcentradoML").Header.Caption = "CONCENTRADO" & vbCrLf & "ML"
                .Columns("Corta").Header.Caption = "CORTADOR"

                .Columns("Concentrado").Format = "##,##0.0"
                .Columns("ConcentradoML").Format = "##,##0.0"

                Try
                    .Columns("copr_componenteid").Hidden = True
                    .Columns("copr_clasificacionid").Hidden = True
                Catch ex As Exception
                End Try
            End With
            grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            Dim dcm As Double = 0
            Dim ml As Double = 0

            For value = 0 To grdProgramaCorte.Rows.Count - 1
                If grdProgramaCorte.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdProgramaCorte.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next
            For value = 0 To grdMateriales.Rows.Count - 1
                dcm = dcm + grdMateriales.Rows(value).Cells("Concentrado").Value
            Next

            For value = 0 To grdMateriales.Rows.Count - 1
                ml = ml + grdMateriales.Rows(value).Cells("ConcentradoML").Value
            Next

            lblDcm.Visible = True
            lblDcmResultado.Visible = True

            lblDcmResultado.Text = Format(dcm, "##,##0.00")
            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdProgramaCorte.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub ProgramaCortePielSinteticos(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        'Obtener los id de los componentes sintetico1, sintetico2, etc
        listaComponentes.Clear()
        tablaComponentes = obj.ObtenerComponentes("PIEL SINT", "xxxxxx")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        Dim tipo As String = "PIELSINT"
        Dim tablaProgramaCorte = New DataTable
        tablaProgramaCorte.Columns.Add("No")
        tablaProgramaCorte.Columns.Add("Pares")
        tablaProgramaCorte.Columns.Add("Lote")
        tablaProgramaCorte.Columns.Add("Colección")
        tablaProgramaCorte.Columns.Add("Modelo")
        tablaProgramaCorte.Columns.Add("ModeloSICY")
        tablaProgramaCorte.Columns.Add("Corrida")
        tablaProgramaCorte.Columns.Add("Material")
        tablaProgramaCorte.Columns.Add("Color")
        tablaProgramaCorte.Columns.Add("Cortador")
        tablaProgramaCorte.Columns.Add("CantidadUnidad")
        tablaProgramaCorte.Columns.Add("CantidadML")

        Dim tablaProveedorMaterial = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProgramaCorteDePiel = obj.ConsultaCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProveedorMateriales = tablaProveedorMaterial
        Dim tablaCortadores = obj.ConsultaCortadoresReporte(fecha, nave, listaComponentes, tipo)
        Dim Lote As Integer = 0
        Dim cortador As String = ""
        Dim contador = 0
        Dim cortadortabla As String = ""

        For value = 0 To tablaProgramaCorteDePiel.Rows.Count - 1

            Dim row As DataRow = tablaProgramaCorte.NewRow()
            If IsDBNull(tablaProgramaCorteDePiel.Rows(value).Item("Cortador")) = True Then
            Else
                cortadortabla = tablaProgramaCorteDePiel.Rows(value).Item("Cortador")
            End If
            'If Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote") And cortador = cortadortabla Then

            '    tablaProgramaCorte.Rows(contador - 1).Item("Material") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Material")
            '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadUnidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") &
            '    " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")

            'Else
            contador = contador + 1
            row("No") = contador
            row("Pares") = tablaProgramaCorteDePiel.Rows(value).Item("Pares")
            row("Lote") = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
            Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
            row("Colección") = tablaProgramaCorteDePiel.Rows(value).Item("Colección")
            row("Modelo") = tablaProgramaCorteDePiel.Rows(value).Item("Modelo")
            row("ModeloSICY") = tablaProgramaCorteDePiel.Rows(value).Item("ModeloSICY")
            row("Corrida") = tablaProgramaCorteDePiel.Rows(value).Item("Corrida")
            row("Color") = tablaProgramaCorteDePiel.Rows(value).Item("Color")
            row("Material") = tablaProgramaCorteDePiel.Rows(value).Item("Material")
            row("Cortador") = cortadortabla
            cortador = cortadortabla
            row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") & " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
            tablaProgramaCorte.Rows.Add(row)
            row("CantidadML") = tablaProgramaCorteDePiel.Rows(value).Item("CantidadML")
            'End If

        Next

        tablaProveedorMaterial.TableName = "DSTablaMateriales"
        tablaProgramaCorte.TableName = "DSTabla"
        tablaCortadores.TableName = "DSTablaCortadores"
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            pnlReportesPieles.Visible = True
            pnlReportesGenerales.Visible = False

            grdProgramaCorte.DataSource = tablaProgramaCorte
            grdMateriales.DataSource = tablaProveedorMaterial

            With grdProgramaCorte.DisplayLayout.Bands(0)

                .Columns("No").Hidden = True

                'Try
                '    .Columns("copr_componenteid").Hidden = True
                '    .Columns("copr_clasificacionid").Hidden = True
                'Catch ex As Exception
                'End Try

                .Columns("Pares").Width = 20
                .Columns("Lote").Width = 30
                .Columns("Colección").Width = 80
                .Columns("Modelo").Width = 30
                .Columns("Modelo").Hidden = True
                .Columns("ModeloSICY").Width = 30
                .Columns("Corrida").Width = 40
                .Columns("Color").Width = 70
                .Columns("Material").Width = 200
                .Columns("Cortador").Width = 150
                .Columns("CantidadUnidad").Width = 100
                .Columns("CantidadML").Width = 100

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CantidadUnidad").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CantidadML").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Cortador").CellActivation = Activation.NoEdit
                .Columns("CantidadUnidad").CellActivation = Activation.NoEdit
                .Columns("CantidadML").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Colección").Header.Caption = "COLECCIÓN"
                .Columns("Modelo").Header.Caption = "MODELO" & vbCrLf & "SAY"
                .Columns("ModeloSICY").Header.Caption = "MODELO" & vbCrLf & "SICY"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Color").Header.Caption = "COLOR"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Cortador").Header.Caption = "CORTADOR"
                .Columns("CantidadUnidad").Header.Caption = "CANTIDAD" & vbCrLf & "DCM2"
                .Columns("CantidadML").Header.Caption = "CANTIDAD" & vbCrLf & "ML"

            End With
            grdProgramaCorte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdProgramaCorte.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdProgramaCorte.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            With grdMateriales.DisplayLayout.Bands(0)

                .Columns("Proveedor").Width = 200
                .Columns("Material").Width = 500
                .Columns("Concentrado").Width = 100
                .Columns("ConcentradoML").Width = 100
                .Columns("Corta").Width = 150

                Try
                    .Columns("copr_componenteid").Hidden = True
                    .Columns("copr_clasificacionid").Hidden = True
                Catch ex As Exception
                End Try

                .Columns("Concentrado").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Concentrado").CellActivation = Activation.NoEdit
                .Columns("ConcentradoML").CellActivation = Activation.NoEdit
                .Columns("Corta").CellActivation = Activation.NoEdit

                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Concentrado").Header.Caption = "CONCENTRADO" & vbCrLf & "CDM2"
                .Columns("ConcentradoML").Header.Caption = "CONCENTRADOML" & vbCrLf & "ML"
                .Columns("Corta").Header.Caption = "CORTADOR"

                .Columns("Concentrado").Format = "##,##0.0"
                .Columns("ConcentradoML").Format = "##,##0.0"

            End With
            grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            Dim dcm As Double = 0
            Dim ml As Double = 0

            For value = 0 To grdProgramaCorte.Rows.Count - 1
                If grdProgramaCorte.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdProgramaCorte.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next
            For value = 0 To grdMateriales.Rows.Count - 1
                dcm = dcm + grdMateriales.Rows(value).Cells("Concentrado").Value
            Next

            For value = 0 To grdMateriales.Rows.Count - 1
                ml = ml + grdMateriales.Rows(value).Cells("ConcentradoML").Value
            Next

            lblDcm.Visible = True
            lblDcmResultado.Visible = True

            lblDcmResultado.Text = Format(dcm, "##,##0.0")
            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdProgramaCorte.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub ProgramaCortePiel(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Obtener los id de los componentes piel1, piel2, etc
        listaComponentes.Clear()
        listaComponentes.Clear()
        tablaComponentes = obj.ObtenerComponentes("PIEL", "PIEL SINT")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        Dim tipo As String = "PIEL"
        Dim tablaProgramaCorte = New DataTable
        tablaProgramaCorte.Columns.Add("No")
        tablaProgramaCorte.Columns.Add("Pares")
        tablaProgramaCorte.Columns.Add("Lote")
        tablaProgramaCorte.Columns.Add("Colección")
        tablaProgramaCorte.Columns.Add("Modelo")
        tablaProgramaCorte.Columns.Add("ModeloSICY")
        tablaProgramaCorte.Columns.Add("Corrida")
        tablaProgramaCorte.Columns.Add("Material")
        tablaProgramaCorte.Columns.Add("Color")
        tablaProgramaCorte.Columns.Add("Cortador")
        tablaProgramaCorte.Columns.Add("CantidadUnidad")
        tablaProgramaCorte.Columns.Add("CantidadML")

        Dim tablaProveedorMaterial = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProgramaCorteDePiel = obj.ConsultaCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProveedorMateriales = tablaProveedorMaterial
        Dim tablaCortadores = obj.ConsultaCortadoresReporte(fecha, nave, listaComponentes, tipo)
        Dim Lote As Integer = 0
        Dim cortador As String = ""
        Dim contador = 0
        Dim cortadortabla As String = ""

        For value = 0 To tablaProgramaCorteDePiel.Rows.Count - 1

            Dim row As DataRow = tablaProgramaCorte.NewRow()
            If IsDBNull(tablaProgramaCorteDePiel.Rows(value).Item("Cortador")) = True Then
            Else
                cortadortabla = tablaProgramaCorteDePiel.Rows(value).Item("Cortador")
            End If

            'If Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote") And cortador = cortadortabla Then

            '    tablaProgramaCorte.Rows(contador - 1).Item("Material") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Material")
            '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadUnidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") &
            '        " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
            '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadML") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("CantidadML")


            'Else
            contador = contador + 1
            row("No") = contador
            row("Pares") = tablaProgramaCorteDePiel.Rows(value).Item("Pares")
            row("Lote") = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
            Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
            row("Colección") = tablaProgramaCorteDePiel.Rows(value).Item("Colección")
            row("Modelo") = tablaProgramaCorteDePiel.Rows(value).Item("Modelo")
            row("ModeloSICY") = tablaProgramaCorteDePiel.Rows(value).Item("ModeloSICY")
            row("Corrida") = tablaProgramaCorteDePiel.Rows(value).Item("Corrida")
            row("Color") = tablaProgramaCorteDePiel.Rows(value).Item("Color")
            row("Material") = tablaProgramaCorteDePiel.Rows(value).Item("Material")
            row("Cortador") = cortadortabla
            cortador = cortadortabla
            row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") & " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
            tablaProgramaCorte.Rows.Add(row)
            row("CantidadML") = tablaProgramaCorteDePiel.Rows(value).Item("CantidadML")
            'End If

        Next

        tablaProveedorMaterial.TableName = "DSTablaMateriales"
        tablaProgramaCorte.TableName = "DSTabla"
        tablaCortadores.TableName = "DSTablaCortadores"
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            pnlReportesPieles.Visible = True
            pnlReportesGenerales.Visible = False

            grdProgramaCorte.DataSource = tablaProgramaCorte
            grdMateriales.DataSource = tablaProveedorMaterial


            With grdProgramaCorte.DisplayLayout.Bands(0)

                .Columns("No").Hidden = True
                .Columns("CantidadML").Hidden = True
                'Try
                '    .Columns("copr_componenteid").Hidden = True
                '    .Columns("copr_clasificacionid").Hidden = True
                'Catch ex As Exception
                'End Try

                .Columns("Pares").Width = 20
                .Columns("Lote").Width = 30
                .Columns("Colección").Width = 80
                .Columns("Modelo").Width = 30
                .Columns("Modelo").Hidden = True
                .Columns("ModeloSICY").Width = 30
                .Columns("Corrida").Width = 40
                .Columns("Color").Width = 70
                .Columns("Material").Width = 200
                .Columns("Cortador").Width = 150
                .Columns("CantidadUnidad").Width = 100
                '.Columns("CantidadML").Width = 100

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CantidadUnidad").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("CantidadML").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Cortador").CellActivation = Activation.NoEdit
                .Columns("CantidadUnidad").CellActivation = Activation.NoEdit
                '.Columns("CantidadML").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Colección").Header.Caption = "COLECCIÓN"
                .Columns("Modelo").Header.Caption = "MODELO" & vbCrLf & "SAY"
                .Columns("ModeloSICY").Header.Caption = "MODELO" & vbCrLf & "SICY"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Color").Header.Caption = "COLOR"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Cortador").Header.Caption = "CORTADOR"
                .Columns("CantidadUnidad").Header.Caption = "CANTIDAD" & vbCrLf & "CDM2"
                '.Columns("CantidadML").Header.Caption = "CANTIDAD" & vbCrLf & "ML"


            End With
            grdProgramaCorte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdProgramaCorte.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdProgramaCorte.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            With grdMateriales.DisplayLayout.Bands(0)

                Try
                    .Columns("copr_componenteid").Hidden = True
                    .Columns("copr_clasificacionid").Hidden = True
                Catch ex As Exception
                End Try

                .Columns("ConcentradoML").Hidden = True

                .Columns("Proveedor").Width = 200
                .Columns("Material").Width = 500
                .Columns("Concentrado").Width = 100
                .Columns("Corta").Width = 150

                .Columns("Concentrado").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("ConcentradoML").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Concentrado").CellActivation = Activation.NoEdit
                '.Columns("ConcentradoML").CellActivation = Activation.NoEdit
                .Columns("Corta").CellActivation = Activation.NoEdit

                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Concentrado").Header.Caption = "CONCENTRADO"
                '.Columns("ConcentradoML").Header.Caption = "CONCENTRADOML"
                .Columns("Corta").Header.Caption = "CORTADOR"

                .Columns("Concentrado").Format = "##,##0.00"
                '.Columns("ConcentradoML").Format = "##,##0.00"

            End With
            grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            Dim dcm As Double = 0
            Dim ml As Double = 0

            For value = 0 To grdProgramaCorte.Rows.Count - 1
                If grdProgramaCorte.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdProgramaCorte.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next
            For value = 0 To grdMateriales.Rows.Count - 1
                dcm = dcm + grdMateriales.Rows(value).Cells("Concentrado").Value
            Next

            For value = 0 To grdMateriales.Rows.Count - 1
                ml = ml + grdMateriales.Rows(value).Cells("ConcentradoML").Value
            Next

            lblDcm.Visible = True
            lblDcmResultado.Visible = True

            lblDcmResultado.Text = Format(dcm, "##,##0.00")
            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##00")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdProgramaCorte.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub
#End Region

#Region "Reportes General"
    Public Sub ReporteAgujeta(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        'Buscar id clasificación de agujeta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("AGUJETA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteDeFormato3(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("Pares").Width = 50
                .Columns("Lote").Width = 50
                .Columns("Material").Width = 300
                .Columns("Corrida").Width = 70
                .Columns("Coleccion").Width = 200
                .Columns("Proveedor").Width = 200
                .Columns("Color").Width = 200
                .Columns("Modelo").Width = 100
                .Columns("Modelo").Hidden = True
                .Columns("ModeloSICY").Width = 100

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Coleccion").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Coleccion").Header.Caption = "COLECCIÓN"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("Color").Header.Caption = "COLOR"
                .Columns("Modelo").Header.Caption = "MODELO" & vbCrLf & "SAY"
                .Columns("ModeloSICY").Header.Caption = "MODELO" & vbCrLf & "SICY"
                .Columns("No").Hidden = True

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub DesglosadodePlantilla(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTILLA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaPlantilla(fecha, nave, clasificacion)
        '  tabla1 = obj.ReporteRelacionDesglosada(fecha, nave, clasificacion)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("No")
        TablaReporteConcentrado.Columns.Add("Pares")
        TablaReporteConcentrado.Columns.Add("Lote")
        TablaReporteConcentrado.Columns.Add("Material")
        TablaReporteConcentrado.Columns.Add("C5")
        TablaReporteConcentrado.Columns.Add("Modelo") '30/11/2019
        TablaReporteConcentrado.Columns.Add("Corrida")
        TablaReporteConcentrado.Columns.Add("Color") '30/11/2019
        TablaReporteConcentrado.Columns.Add("Proveedor")
        TablaReporteConcentrado.Columns.Add("tl1")
        TablaReporteConcentrado.Columns.Add("tl2")
        TablaReporteConcentrado.Columns.Add("tl3")
        TablaReporteConcentrado.Columns.Add("tl4")
        TablaReporteConcentrado.Columns.Add("tl5")
        TablaReporteConcentrado.Columns.Add("tl6")
        TablaReporteConcentrado.Columns.Add("tl7")
        TablaReporteConcentrado.Columns.Add("tl8")
        TablaReporteConcentrado.Columns.Add("tl9")
        TablaReporteConcentrado.Columns.Add("tl10")
        TablaReporteConcentrado.Columns.Add("tl11")
        TablaReporteConcentrado.Columns.Add("tl12")
        TablaReporteConcentrado.Columns.Add("tl13")
        TablaReporteConcentrado.Columns.Add("tl14")
        TablaReporteConcentrado.Columns.Add("tl15")
        TablaReporteConcentrado.Columns.Add("tl16")
        TablaReporteConcentrado.Columns.Add("tl17")
        TablaReporteConcentrado.Columns.Add("tl18")
        TablaReporteConcentrado.Columns.Add("tl19")
        TablaReporteConcentrado.Columns.Add("tl20")
        TablaReporteConcentrado.Columns.Add("t1")
        TablaReporteConcentrado.Columns.Add("t2")
        TablaReporteConcentrado.Columns.Add("t3")
        TablaReporteConcentrado.Columns.Add("t4")
        TablaReporteConcentrado.Columns.Add("t5")
        TablaReporteConcentrado.Columns.Add("t6")
        TablaReporteConcentrado.Columns.Add("t7")
        TablaReporteConcentrado.Columns.Add("t8")
        TablaReporteConcentrado.Columns.Add("t9")
        TablaReporteConcentrado.Columns.Add("t10")
        TablaReporteConcentrado.Columns.Add("t11")
        TablaReporteConcentrado.Columns.Add("t12")
        TablaReporteConcentrado.Columns.Add("t13")
        TablaReporteConcentrado.Columns.Add("t14")
        TablaReporteConcentrado.Columns.Add("t15")
        TablaReporteConcentrado.Columns.Add("t16")
        TablaReporteConcentrado.Columns.Add("t17")
        TablaReporteConcentrado.Columns.Add("t18")
        TablaReporteConcentrado.Columns.Add("t19")
        TablaReporteConcentrado.Columns.Add("t20")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("No") = tabla1.Rows(value).Item("No")
            row("Pares") = tabla1.Rows(value).Item("Pares")
            row("Lote") = tabla1.Rows(value).Item("Lote")
            row("Material") = tabla1.Rows(value).Item("Material")
            row("C5") = tabla1.Rows(value).Item("C5")
            row("Modelo") = tabla1.Rows(value).Item("Modelo")
            row("Corrida") = tabla1.Rows(value).Item("Corrida")
            row("Color") = tabla1.Rows(value).Item("Color")
            row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 9 To 28
                If tabla1.Rows(value).Item(value2).ToString <> "" Then
                    row(value2) = tabla1.Rows(value).Item(value2)
                    Dim X = value2 + 20
                    row(X) = tabla1.Rows(value).Item(value2 + 20)
                End If
            Next
            TablaReporteConcentrado.Rows.Add(row)
        Next
        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("PARES")
        tabla.Columns.Add("LOTE")
        tabla.Columns.Add("MATERIAL")
        tabla.Columns.Add("COLECCIÓN")
        tabla.Columns.Add("MODELO")
        tabla.Columns.Add("CORRIDA")
        tabla.Columns.Add("COLOR")
        tabla.Columns.Add("PROVEEDOR")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")

        For value = 0 To TablaReporteConcentrado.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("PARES") = TablaReporteConcentrado.Rows(value).Item("Pares")
            row("LOTE") = TablaReporteConcentrado.Rows(value).Item("Lote")
            row("MATERIAL") = TablaReporteConcentrado.Rows(value).Item("Material")
            row("COLECCIÓN") = TablaReporteConcentrado.Rows(value).Item("C5")
            row("MODELO") = TablaReporteConcentrado.Rows(value).Item("Modelo")
            row("CORRIDA") = TablaReporteConcentrado.Rows(value).Item("Corrida")
            row("COLOR") = TablaReporteConcentrado.Rows(value).Item("Color")
            row("PROVEEDOR") = TablaReporteConcentrado.Rows(value).Item("Proveedor")
            For value2 = 9 To 28
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2 - 1) = TablaReporteConcentrado.Rows(value).Item(value2)
                End If
            Next
            tabla.Rows.Add(row)

            Dim row2 As DataRow = tabla.NewRow()
            row2("PARES") = ""
            row2("LOTE") = ""
            row2("MATERIAL") = ""
            row2("COLECCIÓN") = ""
            row2("MODELO") = ""
            row2("CORRIDA") = ""
            row2("COLOR") = ""
            row2("PROVEEDOR") = ""
            Dim NUM = 8
            For value2 = 9 To 28
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then 'And TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "0"
                    row2(NUM) = TablaReporteConcentrado.Rows(value).Item(value2 + 20)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row2)
        Next
        Try
            Me.Cursor = Cursors.WaitCursor
            grdReportes.DataSource = tabla
            With grdReportes.DisplayLayout.Bands(0)

                .Columns("PARES").Width = 65 '60 '30/11/2019
                .Columns("LOTE").Width = 60
                .Columns("MATERIAL").Width = 200
                .Columns("COLECCIÓN").Width = 200
                .Columns("MODELO").Width = 80
                .Columns("CORRIDA").Width = 85 '75
                .Columns("COLOR").Width = 200
                .Columns("PROVEEDOR").Width = 250 '300
                .Columns("1").Width = 35
                .Columns("2").Width = 45 '30/11/2019
                .Columns("3").Width = 35
                .Columns("4").Width = 45
                .Columns("5").Width = 35
                .Columns("6").Width = 45
                .Columns("7").Width = 35
                .Columns("8").Width = 45
                .Columns("9").Width = 35
                .Columns("10").Width = 45
                .Columns("11").Width = 35
                .Columns("12").Width = 45
                .Columns("13").Width = 35
                .Columns("14").Width = 45
                .Columns("15").Width = 35
                .Columns("16").Width = 45
                .Columns("17").Width = 30
                .Columns("18").Width = 30
                .Columns("19").Width = 30
                .Columns("20").Width = 30

                '  .Columns("PROVEEDOR").Hidden = True '30/11/2019

                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("MODELO").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("COLOR").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("PARES").Header.Caption = "PARES"
                .Columns("LOTE").Header.Caption = "LOTE"
                .Columns("MATERIAL").Header.Caption = "MATERIAL"
                .Columns("COLECCIÓN").Header.Caption = "COLECCIÓN"
                .Columns("MODELO").Header.Caption = "MODELO"
                .Columns("CORRIDA").Header.Caption = "CORRIDA"
                .Columns("COLOR").Header.Caption = "COLOR"
                .Columns("PROVEEDOR").Header.Caption = "PROVEEDOR"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns '30/11/2019
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub ReportePlastisol(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLASTISOL")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteDeFormato3(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("Pares").Width = 50
                .Columns("Lote").Width = 50
                .Columns("Material").Width = 300
                .Columns("Corrida").Width = 70
                .Columns("Coleccion").Width = 200
                .Columns("Proveedor").Width = 200
                .Columns("Color").Width = 200
                .Columns("Modelo").Width = 100
                .Columns("Modelo").Hidden = True
                .Columns("ModeloSICY").Width = 100

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Coleccion").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Color").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("ModeloSICY").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Coleccion").Header.Caption = "COLECCIÓN"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("Color").Header.Caption = "COLOR"
                .Columns("Modelo").Header.Caption = "MODELO" & vbCrLf & "SAY"
                .Columns("ModeloSICY").Header.Caption = "MODELO" & vbCrLf & "SICY"

                .Columns("No").Hidden = True

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub ReporteCascoContrafuerte(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer, ByVal clasificacion2 As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim tablaClasificacion As DataTable
        Dim tablaClasificacion2 As DataTable
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tablaClasificacion2 = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion2 = tablaClasificacion2.Rows(0).Item(0)
        tabla1 = obj.ConsultaReporteDesglosado(fecha, nave, clasificacion, clasificacion2)
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("Pares").Width = 50
                .Columns("Lote").Width = 50
                .Columns("Descripcion").Width = 300
                .Columns("Contrafuerte").Width = 300
                .Columns("Corrida").Width = 50
                .Columns("Proveedor").Width = 200
                .Columns("Coleccion").Width = 200

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Descripcion").CellActivation = Activation.NoEdit
                .Columns("Contrafuerte").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Coleccion").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Descripcion").Header.Caption = "CASCO"
                .Columns("Contrafuerte").Header.Caption = "CONTRAFUERTE"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("Coleccion").Header.Caption = "COLECCIÓN"

                .Columns("No").Hidden = True
                .Columns("ModeloSAY").Hidden = True
                .Columns("ModeloSICY").Hidden = True

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub ReporteCaja(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0


        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        'Buscar id clasificación de caja
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CAJA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteMaterialesFormato2Planta(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("Pares").Width = 40
                .Columns("Lote").Width = 50
                .Columns("Colección").Width = 300
                .Columns("Corrida").Width = 70
                .Columns("Material").Width = 300
                .Columns("Proveedor").Width = 200

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit

                .Columns("Material").CellActivation = Activation.NoEdit

                .Columns("Proveedor").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Colección").Header.Caption = "COLECCIÓN"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"

                .Columns("No.").Hidden = True
                .Columns("Modelo").Hidden = True
                .Columns("Herraje").Hidden = True

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub


    Public Sub DesglosadoDeCaja(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0


        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CAJA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteDesglosadoCaja(fecha, nave, clasificacion)
        tabla1.TableName = ""


        Dim TablaReporteDesglosadoCaja = New DataTable
        TablaReporteDesglosadoCaja.Clear()
        TablaReporteDesglosadoCaja.Columns.Add("No.")
        TablaReporteDesglosadoCaja.Columns.Add("Pares")
        TablaReporteDesglosadoCaja.Columns.Add("Coleccion")
        TablaReporteDesglosadoCaja.Columns.Add("Corrida")
        TablaReporteDesglosadoCaja.Columns.Add("Material")
        TablaReporteDesglosadoCaja.Columns.Add("Proveedor")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t1")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t2")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t3")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t4")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t5")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t6")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t7")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t8")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t9")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t10")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t11")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t12")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t13")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t14")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t15")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t16")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t17")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t18")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t19")
        TablaReporteDesglosadoCaja.Columns.Add("talla_t20")
        TablaReporteDesglosadoCaja.Columns.Add("Talla1")
        TablaReporteDesglosadoCaja.Columns.Add("Talla2")
        TablaReporteDesglosadoCaja.Columns.Add("Talla3")
        TablaReporteDesglosadoCaja.Columns.Add("Talla4")
        TablaReporteDesglosadoCaja.Columns.Add("Talla5")
        TablaReporteDesglosadoCaja.Columns.Add("Talla6")
        TablaReporteDesglosadoCaja.Columns.Add("Talla7")
        TablaReporteDesglosadoCaja.Columns.Add("Talla8")
        TablaReporteDesglosadoCaja.Columns.Add("Talla9")
        TablaReporteDesglosadoCaja.Columns.Add("Talla10")
        TablaReporteDesglosadoCaja.Columns.Add("Talla11")
        TablaReporteDesglosadoCaja.Columns.Add("Talla12")
        TablaReporteDesglosadoCaja.Columns.Add("Talla13")
        TablaReporteDesglosadoCaja.Columns.Add("Talla14")
        TablaReporteDesglosadoCaja.Columns.Add("Talla15")
        TablaReporteDesglosadoCaja.Columns.Add("Talla16")
        TablaReporteDesglosadoCaja.Columns.Add("Talla17")
        TablaReporteDesglosadoCaja.Columns.Add("Talla18")
        TablaReporteDesglosadoCaja.Columns.Add("Talla19")
        TablaReporteDesglosadoCaja.Columns.Add("Talla20")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteDesglosadoCaja.NewRow()
            row("No.") = tabla1.Rows(value).Item("No.")
            row("Pares") = tabla1.Rows(value).Item("Pares")
            row("Coleccion") = tabla1.Rows(value).Item("Coleccion")
            row("Corrida") = tabla1.Rows(value).Item("Corrida")
            row("Material") = tabla1.Rows(value).Item("Material")
            row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            For value2 = 6 To 25
                If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2) = tabla1.Rows(value).Item(value2)
                    Dim X = value2 + 20
                    row(X) = tabla1.Rows(value).Item(value2 + 20)
                End If
            Next
            TablaReporteDesglosadoCaja.Rows.Add(row)
        Next


        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("No.")
        tabla.Columns.Add("Pares")
        tabla.Columns.Add("Coleccion")
        tabla.Columns.Add("Corrida")
        tabla.Columns.Add("Material")
        tabla.Columns.Add("Proveedor")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")

        For value = 0 To TablaReporteDesglosadoCaja.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("No.") = TablaReporteDesglosadoCaja.Rows(value).Item("No.")
            row("Pares") = TablaReporteDesglosadoCaja.Rows(value).Item("Pares")
            row("Coleccion") = TablaReporteDesglosadoCaja.Rows(value).Item("Coleccion")
            row("Corrida") = TablaReporteDesglosadoCaja.Rows(value).Item("Corrida")
            row("Material") = TablaReporteDesglosadoCaja.Rows(value).Item("Material")
            row("Proveedor") = TablaReporteDesglosadoCaja.Rows(value).Item("Proveedor")
            Dim NUM = 6
            For value2 = 6 To 25
                If TablaReporteDesglosadoCaja.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(NUM) = TablaReporteDesglosadoCaja.Rows(value).Item(value2)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row)

            Dim row2 As DataRow = tabla.NewRow()
            row2("No.") = ""
            row2("Pares") = ""
            row2("Coleccion") = ""
            row2("Corrida") = ""
            row2("Material") = ""
            row2("Proveedor") = ""
            Dim NUM2 = 6
            For value2 = 6 To 25
                If TablaReporteDesglosadoCaja.Rows(value).Item(value2).ToString <> "" Then 'And TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "0"
                    row2(NUM2) = TablaReporteDesglosadoCaja.Rows(value).Item(value2 + 20)
                    NUM2 = NUM2 + 1
                End If
            Next
            tabla.Rows.Add(row2)
        Next

        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("No.").Hidden = True
                .Columns("Pares").Width = 60
                .Columns("Coleccion").Width = 150
                .Columns("Corrida").Width = 60
                .Columns("Material").Width = 200
                .Columns("Proveedor").Width = 200
                .Columns("1").Width = 40
                .Columns("2").Width = 40
                .Columns("3").Width = 40
                .Columns("4").Width = 40
                .Columns("5").Width = 40
                .Columns("6").Width = 40
                .Columns("7").Width = 40
                .Columns("8").Width = 40
                .Columns("9").Width = 40
                .Columns("10").Width = 40
                .Columns("11").Width = 40
                .Columns("12").Width = 40
                .Columns("13").Width = 40
                .Columns("14").Width = 40
                .Columns("15").Width = 40
                .Columns("16").Width = 40
                .Columns("17").Width = 40
                .Columns("18").Width = 40
                .Columns("19").Width = 40
                .Columns("20").Width = 40

                .Columns("No.").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Coleccion").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Material").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Proveedor").CellAppearance.TextHAlign = HAlign.Center
                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("No.").CellActivation = Activation.NoEdit
                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Coleccion").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Coleccion").Header.Caption = "COLECCIÓN"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    'lotes = lotes + 1
                End If
            Next

            lblLotes.Visible = False
            lblLotesResultado.Visible = False
            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If

    End Sub


    Public Sub ReportePlanta(ByVal fecha As String, ByVal nave As Integer, clasificacion As Integer)

        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        'Buscar id clasificación de planta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteMaterialesFormatoPlanta(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("Pares").Width = 40
                .Columns("Lote").Width = 50
                .Columns("Material").Width = 300
                .Columns("Corrida").Width = 70
                .Columns("Horma").Width = 300
                .Columns("Proveedor").Width = 200

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Horma").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Lote").Header.Caption = "LOTES"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Horma").Header.Caption = "HORMA"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"

                .Columns("No.").Hidden = True
                '.Columns("Herraje").Hidden = True
                '.Columns("Modelo").Hidden = True

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub ReportePlantilla(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim objbu As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = objbu.ObtenerClasificacion("PLANTILLA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tablaComponentes = objbu.ObtenerComponentes("PLANTILLA", "")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        tabla1 = objbu.ConsultaReporteTacon(fecha, nave, clasificacion)
        tabla1.TableName = "tablaOrdenesdeProduccion"

        Try
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("No.").Width = 30
                .Columns("Lote").Width = 40
                .Columns("Modelo").Width = 80
                .Columns("Corrida").Width = 70
                .Columns("Pares").Width = 50
                .Columns("Material").Width = 350
                .Columns("Colección").Width = 150
                .Columns("Herraje").Width = 300
                .Columns("Proveedor").Width = 200

                .Columns("No.").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center

                .Columns("No.").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("Herraje").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit

                .Columns("No.").Header.Caption = "NO"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Modelo").Header.Caption = "MODELO"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Material").Header.Caption = "PLANTILLA"
                .Columns("Colección").Header.Caption = "COLECCIÓN"
                .Columns("Herraje").Header.Caption = "HERRAJE"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"

                .Columns("Modelo").Hidden = True
                .Columns("Herraje").Hidden = True
                .Columns("No.").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
    End Sub


    Public Sub ReporteTacon(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim objbu As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = objbu.ObtenerClasificacion("TACON")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tablaComponentes = objbu.ObtenerComponentes("TACON", "")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        tabla1 = objbu.ConsultaReporteTacon(fecha, nave, clasificacion)
        tabla1.TableName = "tablaOrdenesdeProduccion"

        Try
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("No.").Width = 30
                .Columns("Lote").Width = 40
                .Columns("Modelo").Width = 80
                .Columns("Corrida").Width = 70
                .Columns("Pares").Width = 50
                .Columns("Material").Width = 300
                .Columns("Colección").Width = 300
                '.Columns("Herraje").Width = 300
                .Columns("Proveedor").Width = 200

                .Columns("No.").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center

                .Columns("No.").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                '.Columns("Herraje").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit

                .Columns("No.").Header.Caption = "NO"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Modelo").Header.Caption = "MODELO"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Material").Header.Caption = "TACON"
                .Columns("Colección").Header.Caption = "COLECCIÓN"
                '.Columns("Herraje").Header.Caption = "HERRAJE"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"

                .Columns("Modelo").Hidden = True
                .Columns("Herraje").Hidden = True
                .Columns("No.").Hidden = True
            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Public Sub ReporteSuela(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        'Dim listaComponentes As New List(Of Integer)
        'Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        'Buscar id clasificación de suela
        'listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Obtener los id de los componentes Suela1, Suela2, etc
        'tablaComponentes = obj.ObtenerComponentes("SUELA", "")
        'For value = 0 To tablaComponentes.Rows.Count - 1
        'listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        'Next
        tabla1 = obj.ConsultaReporteSuelas1N(fecha, nave)
        tabla1.TableName = "tablaOrdenesdeProduccion"
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla1

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("No.").Width = 30
                .Columns("Lote").Width = 40
                .Columns("Modelo").Width = 80
                .Columns("Corrida").Width = 70
                .Columns("Pares").Width = 50
                .Columns("Material").Width = 300
                .Columns("Coleccion").Width = 300
                .Columns("Herraje").Width = 300
                .Columns("Proveedor").Width = 200

                .Columns("No.").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center

                .Columns("No.").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Coleccion").CellActivation = Activation.NoEdit
                .Columns("Herraje").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit

                .Columns("No.").Header.Caption = "NO"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Modelo").Header.Caption = "MODELO"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Material").Header.Caption = "SUELA"
                .Columns("Coleccion").Header.Caption = "COLECCIÓN"
                .Columns("Herraje").Header.Caption = "HERRAJE"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"

                .Columns("Modelo").Hidden = True
                .Columns("Herraje").Hidden = True
                .Columns("No.").Hidden = True

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid
    End Sub

    Public Sub ReporteHerraje(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        'Buscar id clasificación de herraje
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("HERRAJE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Obtener los id de los componentes Herraje1, Herraje2, etc
        tablaComponentes = obj.ObtenerComponentes("HERRAJE", "")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        tabla1 = obj.ConsultaReporteHerrajes1N(fecha, nave, listaComponentes)
        tabla1.TableName = ""

        Dim listaLotes As New List(Of Integer)
        Dim Tabla = New DataTable
        Tabla.Clear()
        Tabla.Columns.Add("No")
        Tabla.Columns.Add("Pares")
        Tabla.Columns.Add("Lote")
        Tabla.Columns.Add("Modelo")
        Tabla.Columns.Add("ModeloSAY")
        Tabla.Columns.Add("Material")
        Tabla.Columns.Add("Corrida")
        Tabla.Columns.Add("Coleccion")
        Tabla.Columns.Add("Proveedor")
        Tabla.Columns.Add("Cant")
        Tabla.Columns.Add("Herraje")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = Tabla.NewRow()
            Dim contador = 0
            row("No") = tabla1.Rows(value).Item("No.")
            row("Pares") = tabla1.Rows(value).Item("Pares")
            row("Lote") = tabla1.Rows(value).Item("Lote")
            row("Modelo") = tabla1.Rows(value).Item("Modelo")
            row("ModeloSAY") = tabla1.Rows(value).Item("ModeloSAY")
            row("Material") = tabla1.Rows(value).Item("Material")
            row("Corrida") = tabla1.Rows(value).Item("Corrida")
            row("Coleccion") = tabla1.Rows(value).Item("Coleccion")
            row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            'If listaLotes.Count > 0 Then
            '    For valor = 0 To listaLotes.Count - 1
            '        If tabla1.Rows(value).Item("Lote") = listaLotes.Item(valor) Then
            '            contador = contador + 1
            '        End If
            '        If contador > 0 Then
            '            row("Herraje") = "HERRAJE 2"
            '        Else
            '            row("Herraje") = "HERRAJE 1"
            '        End If
            '    Next
            'Else
            row("Cant") = tabla1.Rows(value).Item("Cant")
            row("Herraje") = tabla1.Rows(value).Item("Herraje")
            ' End If
            'For value2 = 9 To 22
            '    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
            '        row(value2) = tabla1.Rows(value).Item(value2)
            '    End If
            'Next
            listaLotes.Add(tabla1.Rows(value).Item("Lote"))
            Tabla.Rows.Add(row)
        Next

        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = Tabla

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("Pares").Width = 40
                .Columns("Lote").Width = 50
                .Columns("Material").Width = 300
                .Columns("Corrida").Width = 70
                .Columns("Coleccion").Width = 300
                .Columns("Proveedor").Width = 200
                .Columns("Cant").Width = 40

                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Center
                .Columns("Cant").CellAppearance.TextHAlign = HAlign.Left

                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Coleccion").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Cant").CellActivation = Activation.NoEdit

                .Columns("Pares").Header.Caption = "PARES"
                .Columns("Herraje").Header.Caption = "HERRAJE"
                .Columns("Lote").Header.Caption = "LOTE"
                .Columns("Material").Header.Caption = "MATERIAL"
                .Columns("Corrida").Header.Caption = "CORRIDA"
                .Columns("Coleccion").Header.Caption = "COLECCIÓN"
                .Columns("Proveedor").Header.Caption = "PROVEEDOR"
                .Columns("Cant").Header.Caption = "CANT"

                .Columns("No").Hidden = True
                .Columns("Modelo").Hidden = True
                .Columns("ModeloSAY").Hidden = True

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If
        '********************************Fin de mostrar reporte Grid

    End Sub
#End Region
#End Region
#End Region

#Region "Imprimir"

    Private Function GetFormatoFechaPrograma() As String
        Dim dateValue As Date = dtpPrograma.Value.ToShortDateString
        Return CapitalizarCadena(dateValue.ToString("dddd, dd ")) & CapitalizarCadena(dateValue.ToString("MMMM")) & " de " & dateValue.ToString("yyyy")
    End Function

    Private Function CapitalizarCadena(ByVal cadena As String) As String
        Dim curCulture As Globalization.CultureInfo = Threading.Thread.CurrentThread.CurrentCulture
        Dim tInfo As Globalization.TextInfo = curCulture.TextInfo()
        Return tInfo.ToTitleCase(cadena)
    End Function

    Private Function GetRutaLogoPorNave(ByVal idNave As Integer) As String
        Return Tools.Controles.ObtenerLogoNave(cbxNave.SelectedValue)
    End Function

    Public Sub ImpimirConcentradoCascoPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        ' Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)

        tabla1 = obj.ConsultaCasco1(fecha, nave, clasificacion)
        tablaA = obj.ConsultaCasco2(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Casco")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer? = Nothing
                Dim t2 As Integer? = Nothing
                Dim t3 As Integer? = Nothing
                Dim t4 As Integer? = Nothing
                Dim t5 As Integer? = Nothing
                Dim t6 As Integer? = Nothing
                ' Dim t7 As Integer? = Nothing
                Dim t8 As Integer? = Nothing
                Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
                'rowc("No") = tabla1.Rows(value).Item("No").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Lotes") = tabla1.Rows(value).Item("Lotes").ToString
                rowc("Casco") = tabla1.Rows(value).Item("Material").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 4
                For value2 = 5 To 20

                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "13"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "14"
                            Dim o = tablaA.Rows(value).Item(value)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "15"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "16"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "17"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "18"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t3 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "19"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t3 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "20"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t4 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "21"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t4 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "22"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "23"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "24"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "25"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "26"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "27"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "28"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "29"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "30"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                    End Select
                Next
                TablaReporteConcentrado.Rows.Add(rowc)
            Next

            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_CASCO_POR_PROVEEDOR")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirConcentradoPlantaPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        ' Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de planta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)
        tabla1.TableName = "tablaConcentradoPlanta"

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            Tools.MostrarEspere(Me)
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            Dim tablaRelacionDesglosadaDeSuela = New DataTable
            tablaRelacionDesglosadaDeSuela.Clear()
            tablaRelacionDesglosadaDeSuela.Columns.Add("NO")
            tablaRelacionDesglosadaDeSuela.Columns.Add("PARES")
            tablaRelacionDesglosadaDeSuela.Columns.Add("LOTE")
            tablaRelacionDesglosadaDeSuela.Columns.Add("MATERIAL")
            tablaRelacionDesglosadaDeSuela.Columns.Add("COLECCIÓN")
            tablaRelacionDesglosadaDeSuela.Columns.Add("CORRIDA")
            tablaRelacionDesglosadaDeSuela.Columns.Add("PROVEEDOR")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("12")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("12½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("13")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("13½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("14")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("14½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("15")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("15½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("16")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("16½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("17")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("17½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("18")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("18½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("19")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("19½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("20")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("20½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("21")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("21½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("22")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("22½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("23")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("23½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("24")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("24½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("25")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("25½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("26")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("26½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("27")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("27½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("28")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("28½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("29")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("29½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("30")

            tablaRelacionDesglosadaDeSuela.Columns.Add("tl1")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl2")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl3")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl4")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl5")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl6")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl7")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl8")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl9")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl10")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl11")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl12")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl13")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl14")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl15")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl16")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl17")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl18")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl19")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl20")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t1")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t2")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t3")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t4")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t5")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t6")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t7")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t8")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t9")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t10")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t11")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t12")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t13")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t14")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t15")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t16")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t17")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t18")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t19")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t20")


            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = tablaRelacionDesglosadaDeSuela.NewRow()
                row("NO") = tabla1.Rows(value).Item("No")
                row("PARES") = tabla1.Rows(value).Item("Pares")
                row("LOTE") = tabla1.Rows(value).Item("Lotes")
                row("MATERIAL") = tabla1.Rows(value).Item("Material")
                row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
                row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
                row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                tablaRelacionDesglosadaDeSuela.Rows.Add(row)
            Next

            'Dim contador = 1

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = tablaRelacionDesglosadaDeSuela.NewRow()
            '    row("NO") = contador
            '    row("PARES") = tabla1.Rows(value).Item("Pares")
            '    row("LOTE") = tabla1.Rows(value).Item("Lotes")
            '    row("MATERIAL") = tabla1.Rows(value).Item("Material")
            '    row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            '    row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            '    row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            'For value2 = 7 To 26
            '    Dim x = tabla1.Rows(value).Item(value2).ToString
            '    Select Case tabla1.Rows(value).Item(value2).ToString
            '        Case "12"
            '            row("12") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "12½"
            '            row("12½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "13"
            '            row("13") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "13½"
            '            row("13½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "14"
            '            row("14") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "14½"
            '            row("14½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "15"
            '            row("15") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "15½"
            '            row("15½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "16"
            '            row("16") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "16½"
            '            row("16½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "17"
            '            row("17") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "17½"
            '            row("17½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "18"
            '            row("18") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "18½"
            '            row("18½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "19"
            '            row("19") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "19½"
            '            row("19½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "20"
            '            row("20") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "20½"
            '            row("20½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "21"
            '            row("21") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "21½"
            '            row("21½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "22"
            '            row("22") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "22½"
            '            row("22½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "23"
            '            row("23") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "23½"
            '            row("23½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "24"
            '            row("24") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "24½"
            '            row("24½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "25"
            '            row("25") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "25½"
            '            row("25½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "26"
            '            row("26") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "26½"
            '            row("26½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "27"
            '            row("27") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "27½"
            '            row("27½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "28"
            '            row("28") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "28½"
            '            row("28½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "29"
            '            row("29") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "29"
            '            row("29½") = tabla1.Rows(value).Item(value2 + 20)
            '        Case "30"
            '            row("30") = tabla1.Rows(value).Item(value2 + 20)
            '    End Select
            'Next
            'contador = contador + 1
            '    tablaRelacionDesglosadaDeSuela.Rows.Add(row)
            'Next
            'Dim TablaReporteConcentrado = New DataTable
            'TablaReporteConcentrado.Clear()
            'TablaReporteConcentrado.Columns.Add("No")
            'TablaReporteConcentrado.Columns.Add("Pares")
            'TablaReporteConcentrado.Columns.Add("Lotes")
            'TablaReporteConcentrado.Columns.Add("Material")
            'TablaReporteConcentrado.Columns.Add("Coleccion")
            'TablaReporteConcentrado.Columns.Add("Corrida")
            'TablaReporteConcentrado.Columns.Add("Proveedor")
            'TablaReporteConcentrado.Columns.Add("tl1")
            'TablaReporteConcentrado.Columns.Add("tl2")
            'TablaReporteConcentrado.Columns.Add("tl3")
            'TablaReporteConcentrado.Columns.Add("tl4")
            'TablaReporteConcentrado.Columns.Add("tl5")
            'TablaReporteConcentrado.Columns.Add("tl6")
            'TablaReporteConcentrado.Columns.Add("tl7")
            'TablaReporteConcentrado.Columns.Add("tl8")
            'TablaReporteConcentrado.Columns.Add("tl9")
            'TablaReporteConcentrado.Columns.Add("tl10")
            'TablaReporteConcentrado.Columns.Add("tl11")
            'TablaReporteConcentrado.Columns.Add("tl12")
            'TablaReporteConcentrado.Columns.Add("tl13")
            'TablaReporteConcentrado.Columns.Add("tl14")
            'TablaReporteConcentrado.Columns.Add("tl15")
            'TablaReporteConcentrado.Columns.Add("tl16")
            'TablaReporteConcentrado.Columns.Add("tl17")
            'TablaReporteConcentrado.Columns.Add("tl18")
            'TablaReporteConcentrado.Columns.Add("tl19")
            'TablaReporteConcentrado.Columns.Add("tl20")
            'TablaReporteConcentrado.Columns.Add("t1")
            'TablaReporteConcentrado.Columns.Add("t2")
            'TablaReporteConcentrado.Columns.Add("t3")
            'TablaReporteConcentrado.Columns.Add("t4")
            'TablaReporteConcentrado.Columns.Add("t5")
            'TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            'TablaReporteConcentrado.Columns.Add("t8")
            'TablaReporteConcentrado.Columns.Add("t9")
            'TablaReporteConcentrado.Columns.Add("t10")
            'TablaReporteConcentrado.Columns.Add("t11")
            'TablaReporteConcentrado.Columns.Add("t12")
            'TablaReporteConcentrado.Columns.Add("t13")
            'TablaReporteConcentrado.Columns.Add("t14")
            'TablaReporteConcentrado.Columns.Add("t15")
            'TablaReporteConcentrado.Columns.Add("t16")
            'TablaReporteConcentrado.Columns.Add("t17")
            'TablaReporteConcentrado.Columns.Add("t18")
            'TablaReporteConcentrado.Columns.Add("t19")
            'TablaReporteConcentrado.Columns.Add("t20")

            'TablaReporteConcentrado.TableName = "tablaConcentradoPlanta"

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = TablaReporteConcentrado.NewRow()
            '    row("No") = tabla1.Rows(value).Item("No")
            '    row("Pares") = tabla1.Rows(value).Item("Pares")
            '    row("Lotes") = tabla1.Rows(value).Item("Lotes")
            '    row("Material") = tabla1.Rows(value).Item("Material")
            '    row("Coleccion") = tabla1.Rows(value).Item("Coleccion")
            '    row("Corrida") = tabla1.Rows(value).Item("Corrida")
            '    row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            '    For value2 = 7 To 26
            '        If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
            '            row(value2) = tabla1.Rows(value).Item(value2)
            '            Dim X = value2 + 20
            '            row(X) = tabla1.Rows(value).Item(value2 + 20)
            '        End If
            '    Next
            '    TablaReporteConcentrado.Rows.Add(row)
            'Next

            ''For value = 0 To tabla1.Rows.Count - 1
            ''    Dim row As DataRow = TablaReporteConcentrado.NewRow()
            ''    row("No") = tabla1.Rows(value).Item("No")
            ''    row("Pares") = tabla1.Rows(value).Item("Pares")
            ''    row("Lote") = tabla1.Rows(value).Item("Lotes")
            ''    row("Material") = tabla1.Rows(value).Item("Material")
            ''    row("Coleccion") = tabla1.Rows(value).Item("Coleccion")
            ''    row("Corrida") = tabla1.Rows(value).Item("Corrida")
            ''    row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            ''    For value2 = 7 To 26
            ''        Dim x = tabla1.Rows(value).Item(value2).ToString
            ''        Select Case tabla1.Rows(value).Item(value2).ToString
            ''            Case "12"
            ''                row("12") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "12½"
            ''                row("12½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "13"
            ''                row("13") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "13½"
            ''                row("13½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "14"
            ''                row("14") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "14½"
            ''                row("14½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "15"
            ''                row("15") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "15½"
            ''                row("15½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "16"
            ''                row("16") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "16½"
            ''                row("16½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "17"
            ''                row("17") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "17½"
            ''                row("17½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "18"
            ''                row("18") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "18½"
            ''                row("18½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "19"
            ''                row("19") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "19½"
            ''                row("19½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "20"
            ''                row("20") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "20½"
            ''                row("20½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "21"
            ''                row("21") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "21½"
            ''                row("21½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "22"
            ''                row("22") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "22½"
            ''                row("22½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "23"
            ''                row("23") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "23½"
            ''                row("23½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "24"
            ''                row("24") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "24½"
            ''                row("24½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "25"
            ''                row("25") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "25½"
            ''                row("25½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "26"
            ''                row("26") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "26½"
            ''                row("26½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "27"
            ''                row("27") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "27½"
            ''                row("27½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "28"
            ''                row("28") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "28½"
            ''                row("28½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "29"
            ''                row("29") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "29"
            ''                row("29½") = tabla1.Rows(value).Item(value2 + 20)
            ''            Case "30"
            ''                row("30") = tabla1.Rows(value).Item(value2 + 20)
            ''        End Select
            ''    Next
            ''    TablaReporteConcentrado.Rows.Add(row)
            ''Next
            '********************************Creación de reporte
            Try
                If tablaRelacionDesglosadaDeSuela.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_PLANTA_POR_PROVEEDOR2")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "PLANTA"
                    reporte.RegData(tablaRelacionDesglosadaDeSuela)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirConcentradoPlantillaPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        ' Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de plantilla
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTILLA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("Coleccion")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("tl1")
            TablaReporteConcentrado.Columns.Add("tl2")
            TablaReporteConcentrado.Columns.Add("tl3")
            TablaReporteConcentrado.Columns.Add("tl4")
            TablaReporteConcentrado.Columns.Add("tl5")
            TablaReporteConcentrado.Columns.Add("tl6")
            TablaReporteConcentrado.Columns.Add("tl7")
            TablaReporteConcentrado.Columns.Add("tl8")
            TablaReporteConcentrado.Columns.Add("tl9")
            TablaReporteConcentrado.Columns.Add("tl10")
            TablaReporteConcentrado.Columns.Add("tl11")
            TablaReporteConcentrado.Columns.Add("tl12")
            TablaReporteConcentrado.Columns.Add("tl13")
            TablaReporteConcentrado.Columns.Add("tl14")
            TablaReporteConcentrado.Columns.Add("tl15")
            TablaReporteConcentrado.Columns.Add("tl16")
            TablaReporteConcentrado.Columns.Add("tl17")
            TablaReporteConcentrado.Columns.Add("tl18")
            TablaReporteConcentrado.Columns.Add("tl19")
            TablaReporteConcentrado.Columns.Add("tl20")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")
            TablaReporteConcentrado.Columns.Add("t9")
            TablaReporteConcentrado.Columns.Add("t10")
            TablaReporteConcentrado.Columns.Add("t11")
            TablaReporteConcentrado.Columns.Add("t12")
            TablaReporteConcentrado.Columns.Add("t13")
            TablaReporteConcentrado.Columns.Add("t14")
            TablaReporteConcentrado.Columns.Add("t15")
            TablaReporteConcentrado.Columns.Add("t16")
            TablaReporteConcentrado.Columns.Add("t17")
            TablaReporteConcentrado.Columns.Add("t18")
            TablaReporteConcentrado.Columns.Add("t19")
            TablaReporteConcentrado.Columns.Add("t20")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = TablaReporteConcentrado.NewRow()
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lotes") = tabla1.Rows(value).Item("Lotes")
                row("Material") = tabla1.Rows(value).Item("Material")
                row("Coleccion") = tabla1.Rows(value).Item("Coleccion")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                TablaReporteConcentrado.Rows.Add(row)
            Next
            'For value = 0 To tabla1.Rows.Count - 1
            '    For value2 = 7 To 26
            '        If tabla1.Rows(value).Item(value2).ToString = "" And tabla1.Rows(value).Item(value2 + 20).ToString = "0" Then
            '            tabla1.Rows(value).Item(value2 + 20) = ""
            '        End If
            '    Next
            'Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_PLANTILLA_POR_PROVEEDOR")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirConcentradoTaconPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("TACON")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else

            Dim tablaRelacionDesglosadaDeTacon = New DataTable
            tablaRelacionDesglosadaDeTacon.Clear()
            tablaRelacionDesglosadaDeTacon.Columns.Add("NO")
            tablaRelacionDesglosadaDeTacon.Columns.Add("PARES")
            tablaRelacionDesglosadaDeTacon.Columns.Add("LOTE")
            tablaRelacionDesglosadaDeTacon.Columns.Add("MATERIAL")
            tablaRelacionDesglosadaDeTacon.Columns.Add("COLECCIÓN")
            tablaRelacionDesglosadaDeTacon.Columns.Add("CORRIDA")
            tablaRelacionDesglosadaDeTacon.Columns.Add("PROVEEDOR")

            tablaRelacionDesglosadaDeTacon.Columns.Add("tl1")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl2")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl3")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl4")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl5")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl6")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl7")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl8")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl9")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl10")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl11")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl12")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl13")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl14")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl15")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl16")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl17")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl18")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl19")
            tablaRelacionDesglosadaDeTacon.Columns.Add("tl20")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t1")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t2")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t3")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t4")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t5")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t6")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t7")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t8")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t9")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t10")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t11")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t12")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t13")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t14")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t15")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t16")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t17")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t18")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t19")
            tablaRelacionDesglosadaDeTacon.Columns.Add("t20")


            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = tablaRelacionDesglosadaDeTacon.NewRow()
                row("NO") = tabla1.Rows(value).Item("No")
                row("PARES") = tabla1.Rows(value).Item("Pares")
                row("LOTE") = tabla1.Rows(value).Item("Lotes")
                row("MATERIAL") = tabla1.Rows(value).Item("Material")
                row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
                row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
                row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                tablaRelacionDesglosadaDeTacon.Rows.Add(row)
            Next

            'tablaRelacionDesglosadaDeTacon.Columns.Add("12")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("12½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("13")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("13½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("14")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("14½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("15")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("15½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("16")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("16½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("17")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("17½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("18")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("18½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("19")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("19½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("20")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("20½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("21")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("21½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("22")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("22½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("23")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("23½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("24")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("24½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("25")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("25½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("26")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("26½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("27")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("27½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("28")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("28½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("29")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("29½")
            'tablaRelacionDesglosadaDeTacon.Columns.Add("30")
            'Dim contador = 1

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = tablaRelacionDesglosadaDeTacon.NewRow()
            '    row("NO") = contador
            '    row("PARES") = tabla1.Rows(value).Item("Pares")
            '    row("LOTE") = tabla1.Rows(value).Item("Lotes")
            '    row("MATERIAL") = tabla1.Rows(value).Item("Material")
            '    row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            '    row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            '    row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            '    For value2 = 7 To 26
            '        Dim x = tabla1.Rows(value).Item(value2).ToString
            '        Select Case tabla1.Rows(value).Item(value2).ToString
            '            Case "12"
            '                row("12") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "12½"
            '                row("12½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "13"
            '                row("13") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "13½"
            '                row("13½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "14"
            '                row("14") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "14½"
            '                row("14½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "15"
            '                row("15") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "15½"
            '                row("15½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "16"
            '                row("16") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "16½"
            '                row("16½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "17"
            '                row("17") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "17½"
            '                row("17½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "18"
            '                row("18") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "18½"
            '                row("18½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "19"
            '                row("19") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "19½"
            '                row("19½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "20"
            '                row("20") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "20½"
            '                row("20½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "21"
            '                row("21") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "21½"
            '                row("21½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "22"
            '                row("22") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "22½"
            '                row("22½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "23"
            '                row("23") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "23½"
            '                row("23½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "24"
            '                row("24") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "24½"
            '                row("24½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "25"
            '                row("25") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "25½"
            '                row("25½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "26"
            '                row("26") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "26½"
            '                row("26½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "27"
            '                row("27") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "27½"
            '                row("27½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "28"
            '                row("28") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "28½"
            '                row("28½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "29"
            '                row("29") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "29"
            '                row("29½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "30"
            '                row("30") = tabla1.Rows(value).Item(value2 + 20)
            '        End Select
            '    Next
            '    contador = contador + 1
            '    tablaRelacionDesglosadaDeTacon.Rows.Add(row)
            'Next
            Try
                If tablaRelacionDesglosadaDeTacon.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_TACON_POR_PROVEEDOR2")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "TACON"
                    reporte.RegData(tablaRelacionDesglosadaDeTacon)
                    reporte.Show()
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirConcentradoSuelaPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            Dim tablaRelacionDesglosadaDeSuela = New DataTable
            tablaRelacionDesglosadaDeSuela.Clear()
            tablaRelacionDesglosadaDeSuela.Columns.Add("NO")
            tablaRelacionDesglosadaDeSuela.Columns.Add("PARES")
            tablaRelacionDesglosadaDeSuela.Columns.Add("LOTE")
            tablaRelacionDesglosadaDeSuela.Columns.Add("MATERIAL")
            tablaRelacionDesglosadaDeSuela.Columns.Add("COLECCIÓN")
            tablaRelacionDesglosadaDeSuela.Columns.Add("CORRIDA")
            tablaRelacionDesglosadaDeSuela.Columns.Add("PROVEEDOR")

            tablaRelacionDesglosadaDeSuela.Columns.Add("tl1")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl2")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl3")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl4")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl5")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl6")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl7")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl8")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl9")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl10")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl11")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl12")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl13")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl14")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl15")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl16")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl17")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl18")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl19")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl20")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t1")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t2")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t3")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t4")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t5")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t6")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t7")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t8")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t9")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t10")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t11")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t12")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t13")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t14")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t15")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t16")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t17")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t18")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t19")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t20")


            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = tablaRelacionDesglosadaDeSuela.NewRow()
                row("NO") = tabla1.Rows(value).Item("No")
                row("PARES") = tabla1.Rows(value).Item("Pares")
                row("LOTE") = tabla1.Rows(value).Item("Lotes")
                row("MATERIAL") = tabla1.Rows(value).Item("Material")
                row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
                row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
                row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                tablaRelacionDesglosadaDeSuela.Rows.Add(row)
            Next


            'tablaRelacionDesglosadaDeSuela.Columns.Add("12")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("12½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("13")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("13½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("14")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("14½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("15")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("15½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("16")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("16½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("17")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("17½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("18")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("18½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("19")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("19½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("20")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("20½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("21")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("21½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("22")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("22½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("23")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("23½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("24")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("24½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("25")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("25½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("26")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("26½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("27")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("27½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("28")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("28½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("29")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("29½")
            'tablaRelacionDesglosadaDeSuela.Columns.Add("30")
            'Dim contador = 1

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = tablaRelacionDesglosadaDeSuela.NewRow()
            '    row("NO") = contador
            '    row("PARES") = tabla1.Rows(value).Item("Pares")
            '    row("LOTE") = tabla1.Rows(value).Item("Lotes")
            '    row("MATERIAL") = tabla1.Rows(value).Item("Material")
            '    row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            '    row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            '    row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            '    For value2 = 7 To 26
            '        Dim x = tabla1.Rows(value).Item(value2).ToString
            '        Select Case tabla1.Rows(value).Item(value2).ToString
            '            Case "12"
            '                row("12") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "12½"
            '                row("12½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "13"
            '                row("13") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "13½"
            '                row("13½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "14"
            '                row("14") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "14½"
            '                row("14½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "15"
            '                row("15") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "15½"
            '                row("15½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "16"
            '                row("16") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "16½"
            '                row("16½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "17"
            '                row("17") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "17½"
            '                row("17½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "18"
            '                row("18") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "18½"
            '                row("18½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "19"
            '                row("19") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "19½"
            '                row("19½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "20"
            '                row("20") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "20½"
            '                row("20½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "21"
            '                row("21") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "21½"
            '                row("21½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "22"
            '                row("22") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "22½"
            '                row("22½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "23"
            '                row("23") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "23½"
            '                row("23½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "24"
            '                row("24") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "24½"
            '                row("24½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "25"
            '                row("25") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "25½"
            '                row("25½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "26"
            '                row("26") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "26½"
            '                row("26½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "27"
            '                row("27") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "27½"
            '                row("27½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "28"
            '                row("28") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "28½"
            '                row("28½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "29"
            '                row("29") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "29"
            '                row("29½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "30"
            '                row("30") = tabla1.Rows(value).Item(value2 + 20)
            '        End Select
            '    Next
            '    contador = contador + 1
            '    tablaRelacionDesglosadaDeSuela.Rows.Add(row)
            'Next
            Try
                If tablaRelacionDesglosadaDeSuela.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_SUELA_POR_PROVEEDOR2")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "SUELA"
                    reporte.RegData(tablaRelacionDesglosadaDeSuela)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirDesglosadoCasco(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Buscar id clasificación de contrafuerte
        'tablaClasificacion2 = obj.ObtenerClasificacion("CONTRAFUERTE")
        'clasificacion2 = tablaClasificacion2.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDeCascoYContrafuerte(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            'Dim TablaReporteConcentrado = New DataTable
            'TablaReporteConcentrado.Clear()
            'TablaReporteConcentrado.Columns.Add("No")
            'TablaReporteConcentrado.Columns.Add("Pares")
            'TablaReporteConcentrado.Columns.Add("Lote")
            'TablaReporteConcentrado.Columns.Add("Material")
            'TablaReporteConcentrado.Columns.Add("C5")
            'TablaReporteConcentrado.Columns.Add("Corrida")
            'TablaReporteConcentrado.Columns.Add("Proveedor")
            'TablaReporteConcentrado.Columns.Add("tl1")
            'TablaReporteConcentrado.Columns.Add("tl2")
            'TablaReporteConcentrado.Columns.Add("tl3")
            'TablaReporteConcentrado.Columns.Add("tl4")
            'TablaReporteConcentrado.Columns.Add("tl5")
            'TablaReporteConcentrado.Columns.Add("tl6")
            'TablaReporteConcentrado.Columns.Add("tl7")
            'TablaReporteConcentrado.Columns.Add("tl8")
            'TablaReporteConcentrado.Columns.Add("tl9")
            'TablaReporteConcentrado.Columns.Add("tl10")
            'TablaReporteConcentrado.Columns.Add("tl11")
            'TablaReporteConcentrado.Columns.Add("tl12")
            'TablaReporteConcentrado.Columns.Add("tl13")
            'TablaReporteConcentrado.Columns.Add("tl14")
            'TablaReporteConcentrado.Columns.Add("tl15")
            'TablaReporteConcentrado.Columns.Add("tl16")
            'TablaReporteConcentrado.Columns.Add("tl17")
            'TablaReporteConcentrado.Columns.Add("tl18")
            'TablaReporteConcentrado.Columns.Add("tl19")
            'TablaReporteConcentrado.Columns.Add("tl20")
            'TablaReporteConcentrado.Columns.Add("t1")
            'TablaReporteConcentrado.Columns.Add("t2")
            'TablaReporteConcentrado.Columns.Add("t3")
            'TablaReporteConcentrado.Columns.Add("t4")
            'TablaReporteConcentrado.Columns.Add("t5")
            'TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            'TablaReporteConcentrado.Columns.Add("t8")
            'TablaReporteConcentrado.Columns.Add("t9")
            'TablaReporteConcentrado.Columns.Add("t10")
            'TablaReporteConcentrado.Columns.Add("t11")
            'TablaReporteConcentrado.Columns.Add("t12")
            'TablaReporteConcentrado.Columns.Add("t13")
            'TablaReporteConcentrado.Columns.Add("t14")
            'TablaReporteConcentrado.Columns.Add("t15")
            'TablaReporteConcentrado.Columns.Add("t16")
            'TablaReporteConcentrado.Columns.Add("t17")
            'TablaReporteConcentrado.Columns.Add("t18")
            'TablaReporteConcentrado.Columns.Add("t19")
            'TablaReporteConcentrado.Columns.Add("t20")

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = TablaReporteConcentrado.NewRow()
            '    row("No") = tabla1.Rows(value).Item("No")
            '    row("Pares") = tabla1.Rows(value).Item("Pares")
            '    row("Lote") = tabla1.Rows(value).Item("Lote")
            '    row("Material") = tabla1.Rows(value).Item("Material")
            '    row("C5") = tabla1.Rows(value).Item("C5")
            '    row("Corrida") = tabla1.Rows(value).Item("Corrida")
            '    row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            '    For value2 = 7 To 26
            '        If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
            '            row(value2) = tabla1.Rows(value).Item(value2)
            '            Dim X = value2 + 20
            '            row(X) = tabla1.Rows(value).Item(value2 + 20)
            '        End If
            '    Next
            '    TablaReporteConcentrado.Rows.Add(row)
            'Next
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Casco")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer? = Nothing
                Dim t2 As Integer? = Nothing
                Dim t3 As Integer? = Nothing
                Dim t4 As Integer? = Nothing
                Dim t5 As Integer? = Nothing
                Dim t6 As Integer? = Nothing
                'Dim t7 As Integer? = Nothing
                Dim t8 As Integer? = Nothing
                Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
                'rowc("No") = tabla1.Rows(value).Item("No").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Lotes") = tabla1.Rows(value).Item("Lote").ToString
                rowc("Casco") = tabla1.Rows(value).Item("Material").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 4
                For value2 = 7 To 26

                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "13"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "14"
                            Dim o = tabla1.Rows(value).Item(value)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1 'Corrida 12-14½
                        Case "15"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "16"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "17"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "18"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t3 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "19"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t3 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "20"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t4 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "21"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t4 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "22"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "23"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "24"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "25"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "26"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "27"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "28"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "29"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "30"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                    End Select
                Next
                TablaReporteConcentrado.Rows.Add(rowc)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("DESGLOSADO_DE_CASCO")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "CASCO Y CONTRAFUERTE"
                    reporte("tituloC5") = "CONTRAFUERTE"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirDesglosadoContrafuerte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        'tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        'clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Buscar id clasificación de contrafuerte
        tablaClasificacion = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDeCascoYContrafuerte(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            'Dim TablaReporteConcentrado = New DataTable
            'TablaReporteConcentrado.Clear()
            'TablaReporteConcentrado.Columns.Add("No")
            'TablaReporteConcentrado.Columns.Add("Pares")arodr
            'TablaReporteConcentrado.Columns.Add("Lote")
            'TablaReporteConcentrado.Columns.Add("Material")
            'TablaReporteConcentrado.Columns.Add("C5")
            'TablaReporteConcentrado.Columns.Add("Corrida")
            'TablaReporteConcentrado.Columns.Add("Proveedor")
            'TablaReporteConcentrado.Columns.Add("tl1")
            'TablaReporteConcentrado.Columns.Add("tl2")
            'TablaReporteConcentrado.Columns.Add("tl3")
            'TablaReporteConcentrado.Columns.Add("tl4")
            'TablaReporteConcentrado.Columns.Add("tl5")
            'TablaReporteConcentrado.Columns.Add("tl6")
            'TablaReporteConcentrado.Columns.Add("tl7")
            'TablaReporteConcentrado.Columns.Add("tl8")
            'TablaReporteConcentrado.Columns.Add("tl9")
            'TablaReporteConcentrado.Columns.Add("tl10")
            'TablaReporteConcentrado.Columns.Add("tl11")
            'TablaReporteConcentrado.Columns.Add("tl12")
            'TablaReporteConcentrado.Columns.Add("tl13")
            'TablaReporteConcentrado.Columns.Add("tl14")
            'TablaReporteConcentrado.Columns.Add("tl15")
            'TablaReporteConcentrado.Columns.Add("tl16")
            'TablaReporteConcentrado.Columns.Add("tl17")
            'TablaReporteConcentrado.Columns.Add("tl18")
            'TablaReporteConcentrado.Columns.Add("tl19")
            'TablaReporteConcentrado.Columns.Add("tl20")
            'TablaReporteConcentrado.Columns.Add("t1")
            'TablaReporteConcentrado.Columns.Add("t2")
            'TablaReporteConcentrado.Columns.Add("t3")
            'TablaReporteConcentrado.Columns.Add("t4")
            'TablaReporteConcentrado.Columns.Add("t5")
            'TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            'TablaReporteConcentrado.Columns.Add("t8")
            'TablaReporteConcentrado.Columns.Add("t9")
            'TablaReporteConcentrado.Columns.Add("t10")
            'TablaReporteConcentrado.Columns.Add("t11")
            'TablaReporteConcentrado.Columns.Add("t12")
            'TablaReporteConcentrado.Columns.Add("t13")
            'TablaReporteConcentrado.Columns.Add("t14")
            'TablaReporteConcentrado.Columns.Add("t15")
            'TablaReporteConcentrado.Columns.Add("t16")
            'TablaReporteConcentrado.Columns.Add("t17")
            'TablaReporteConcentrado.Columns.Add("t18")
            'TablaReporteConcentrado.Columns.Add("t19")
            'TablaReporteConcentrado.Columns.Add("t20")

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = TablaReporteConcentrado.NewRow()
            '    row("No") = tabla1.Rows(value).Item("No")
            '    row("Pares") = tabla1.Rows(value).Item("Pares")
            '    row("Lote") = tabla1.Rows(value).Item("Lote")
            '    row("Material") = tabla1.Rows(value).Item("Material")
            '    row("C5") = tabla1.Rows(value).Item("C5")
            '    row("Corrida") = tabla1.Rows(value).Item("Corrida")
            '    row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            '    For value2 = 7 To 26
            '        If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
            '            row(value2) = tabla1.Rows(value).Item(value2)
            '            Dim X = value2 + 20
            '            row(X) = tabla1.Rows(value).Item(value2 + 20)
            '        End If
            '    Next
            '    TablaReporteConcentrado.Rows.Add(row)
            'Next
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer? = Nothing
                Dim t2 As Integer? = Nothing
                Dim t3 As Integer? = Nothing
                Dim t4 As Integer? = Nothing
                Dim t5 As Integer? = Nothing
                Dim t6 As Integer? = Nothing
                'Dim t7 As Integer? = Nothing
                Dim t8 As Integer? = Nothing
                Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
                'rowc("No") = tabla1.Rows(value).Item("No").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Lotes") = tabla1.Rows(value).Item("Lote").ToString
                rowc("Material") = tabla1.Rows(value).Item("Material").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 4
                For value2 = 7 To 26

                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "13"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "14"
                            Dim o = tabla1.Rows(value).Item(value)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1 'Corrida 12-14½
                        Case "15"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "16"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "17"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "18"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t3 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "19"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t3 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "20"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t4 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "21"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t4 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "22"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "23"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "24"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "25"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "26"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "27"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "28"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "29"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "30"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                    End Select
                Next
                TablaReporteConcentrado.Rows.Add(rowc)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("DESGLOSADO_DE_CONTRAFUERTE")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "CASCO Y CONTRAFUERTE"
                    reporte("tituloC5") = "CONTRAFUERTE"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirDesglosadodeCaja(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        'Dim clasificacion As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de Caja
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CAJA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteDesglosadoCaja(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Dim tablaDesglosadoCaja As New DataTable
            tablaDesglosadoCaja.Clear()
            tablaDesglosadoCaja.Columns.Add("No.")
            tablaDesglosadoCaja.Columns.Add("Pares")
            tablaDesglosadoCaja.Columns.Add("Coleccion")
            tablaDesglosadoCaja.Columns.Add("Corrida")
            tablaDesglosadoCaja.Columns.Add("Material")
            tablaDesglosadoCaja.Columns.Add("Proveedor")
            tablaDesglosadoCaja.Columns.Add("t1")
            tablaDesglosadoCaja.Columns.Add("t2")
            tablaDesglosadoCaja.Columns.Add("t3")
            tablaDesglosadoCaja.Columns.Add("t4")
            tablaDesglosadoCaja.Columns.Add("t5")
            tablaDesglosadoCaja.Columns.Add("t6")
            tablaDesglosadoCaja.Columns.Add("t7")
            tablaDesglosadoCaja.Columns.Add("t8")
            tablaDesglosadoCaja.Columns.Add("t9")
            tablaDesglosadoCaja.Columns.Add("t10")
            tablaDesglosadoCaja.Columns.Add("t11")
            tablaDesglosadoCaja.Columns.Add("t12")
            tablaDesglosadoCaja.Columns.Add("t13")
            tablaDesglosadoCaja.Columns.Add("t14")
            tablaDesglosadoCaja.Columns.Add("t15")
            tablaDesglosadoCaja.Columns.Add("t16")
            tablaDesglosadoCaja.Columns.Add("t17")
            tablaDesglosadoCaja.Columns.Add("t18")
            tablaDesglosadoCaja.Columns.Add("t19")
            tablaDesglosadoCaja.Columns.Add("t20")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer = 0
                Dim t2 As Integer = 0
                Dim t3 As Integer = 0
                Dim t4 As Integer = 0
                Dim t5 As Integer = 0
                Dim t6 As Integer = 0
                Dim t7 As Integer = 0
                Dim t8 As Integer = 0
                Dim t9 As Integer = 0
                Dim t10 As Integer = 0
                Dim t11 As Integer = 0
                Dim t12 As Integer = 0
                Dim t13 As Integer = 0
                Dim t14 As Integer = 0
                Dim t15 As Integer = 0
                Dim t16 As Integer = 0
                Dim t17 As Integer = 0
                Dim t18 As Integer = 0
                Dim t19 As Integer = 0
                Dim t20 As Integer = 0
                Dim rowc As DataRow = tablaDesglosadoCaja.NewRow()
                rowc("No.") = tabla1.Rows(value).Item("No.").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Coleccion") = tabla1.Rows(value).Item("Coleccion").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Material") = tabla1.Rows(value).Item("Material").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 5

                For value2 = 6 To 25
                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tabla1.Rows(value).Item(value2)
                            t1 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "13"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t2 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "14"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t3 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "15"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t4 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "16"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t5 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "17"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t6 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "18"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t7 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t7") = t7
                        Case "19"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t8 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "20"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t9 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t9") = t9
                        Case "21"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t10 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t10") = t10
                        Case "22"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t11 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t11") = t11
                        Case "23"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t12 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t12") = t12
                        Case "24"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t13 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t13") = t13
                        Case "25"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t14 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t14") = t14
                        Case "26"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t15 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t15") = t15
                        Case "27"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t16 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t16") = t16
                        Case "28"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t17 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t17") = t17
                        Case "29"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t18 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t18") = t18
                        Case "30"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t19 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t19") = t19
                        Case "31"
                            Dim o = tabla1.Rows(value).Item(value2).ToString
                            t20 += tabla1.Rows(value).Item(value2 + 20)
                            cont = cont + 1
                            rowc("t20") = t20
                    End Select

                Next

                tablaDesglosadoCaja.Rows.Add(rowc)
            Next

            Try
                If tablaDesglosadoCaja.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim objReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = objReporte.LeerReporteporClave("DESGLOSADO_CAJA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma()
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "CAJA"
                    reporte.RegData(tablaDesglosadoCaja)
                    reporte.Show()

                    Me.Cursor = Cursors.Default

                End If
            Catch ex As Exception
                Me.Cursor = Cursors.Default
            End Try

        End If

    End Sub



    Public Sub ImprimirOrdenPedidoDesglosadoCorte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        'Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        listaComponentes.Clear()
        tabla1 = obj.ConsultaOrdenDePedidoDesglosadoPAraCorte1(fecha, nave)
        tabla2 = obj.ConsultaOrdenDePedidoDesglosadoPAraCorte2(fecha, nave)

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            Try
                For value = 0 To tabla1.Rows.Count - 1
                    Dim contador = 1
                    For value2 = 29 To 47
                        Dim aux = tabla2.Rows(value).Item(contador)
                        tabla1.Rows(value).Item(value2) = aux
                        contador = contador + 1
                    Next
                Next
                For value = 0 To tabla1.Rows.Count - 1
                    For value2 = 7 To 26
                        If tabla1.Rows(value).Item(value2).ToString = "" And tabla1.Rows(value).Item(value2 + 20).ToString = "0" Then
                            tabla1.Rows(value).Item(value2 + 20) = ""
                        End If
                    Next
                Next
            Catch ex As Exception
            End Try
            tabla1.TableName = ""
            '********************************Creación de reporte
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("ORDEN_DE_PEDIDO_DESGLOSADO_PARA_CORTE")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "CASCO Y CONTRAFUERTE"
                    reporte("tituloC5") = "MATERIAL 2"
                    reporte("Proveedor") = "COTEXCA"
                    reporte.RegData(tabla1)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirOrdenDeProduccion(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteOrdenesDeProduccionfake(fecha, nave, clasificacion)
        'tabla1 = obj.ReporteOrdenesDeProduccion(fecha, nave, clasificacion)

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            For value = 0 To tabla1.Rows.Count - 1
                Dim x = tabla1.Rows(value).Item("Suela").ToString
                tabla1.Rows(value).Item("Suela") = x.Trim.Replace("SUELA ", "")
            Next
            'Concatenar Cortador1 con cortador2
            tabla1.TableName = ""
            '********************************Creación de reporte
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    ''**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("ORDEN_DE_PRODUCCION")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(tabla1)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirProgramaCorteForro(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        ' Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Obtener los id de los componentes piel1, piel2, etc
        listaComponentes.Clear()
        tablaComponentes = obj.ObtenerComponentes("FORRO", "FORRO SINT")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next

        Dim tipo As String = "FORRO"
        Dim tablaProgramaCorte = New DataTable
        tablaProgramaCorte.Columns.Add("No")
        tablaProgramaCorte.Columns.Add("Pares")
        tablaProgramaCorte.Columns.Add("Lote")
        tablaProgramaCorte.Columns.Add("Colección")
        tablaProgramaCorte.Columns.Add("Modelo")
        tablaProgramaCorte.Columns.Add("ModeloSICY")
        tablaProgramaCorte.Columns.Add("Corrida")
        tablaProgramaCorte.Columns.Add("Material")
        tablaProgramaCorte.Columns.Add("Color")
        tablaProgramaCorte.Columns.Add("Cortador")
        tablaProgramaCorte.Columns.Add("CantidadUnidad")
        tablaProgramaCorte.Columns.Add("Cantidad")
        tablaProgramaCorte.Columns.Add("Unidad Compra")


        Dim tablaProveedorMaterial = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProgramaCorteDePiel = obj.ConsultaCortadoresPielForro(fecha, nave, listaComponentes, tipo)
        'Dim tablaProveedorMateriales = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes)
        Dim tablaCortadores = obj.ConsultaCortadoresReporte(fecha, nave, listaComponentes, tipo)
        Dim Lote As Integer = 0
        Dim cortador As String = ""
        Dim contador = 0
        Dim cortadortabla As String = ""

        If tablaCortadores.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay Cortadores registrados, no se puede generar el reporte.")
            'objAdvertencia.mensaje = "No hay Cortadores registrados, no se puede generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            If IsDBNull(tablaCortadores.Rows(0).Item("Cortadoress")) = True Then
                Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay Cortadores registrados, no se puede generar el reporte.")
                'objAdvertencia.mensaje = "No hay Cortadores registrados, no se puede generar el reporte."
                'objAdvertencia.ShowDialog()
            Else
                For value = 0 To tablaProgramaCorteDePiel.Rows.Count - 1

                    Dim row As DataRow = tablaProgramaCorte.NewRow()
                    If IsDBNull(tablaProgramaCorteDePiel.Rows(value).Item("Cortador")) = True Then
                    Else
                        cortadortabla = tablaProgramaCorteDePiel.Rows(value).Item("Cortador")
                    End If
                    If Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote") And cortador = cortadortabla Then

                        tablaProgramaCorte.Rows(contador - 1).Item("Material") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Material")
                        tablaProgramaCorte.Rows(contador - 1).Item("CantidadUnidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") &
                            " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")

                        tablaProgramaCorte.Rows(contador - 1).Item("Cantidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad")

                    Else
                        contador = contador + 1
                        row("No") = contador
                        row("Pares") = tablaProgramaCorteDePiel.Rows(value).Item("Pares")
                        row("Lote") = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                        Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                        row("Colección") = tablaProgramaCorteDePiel.Rows(value).Item("Colección")
                        row("Modelo") = tablaProgramaCorteDePiel.Rows(value).Item("Modelo")
                        row("ModeloSICY") = tablaProgramaCorteDePiel.Rows(value).Item("ModeloSICY")
                        row("Corrida") = tablaProgramaCorteDePiel.Rows(value).Item("Corrida")
                        row("Color") = tablaProgramaCorteDePiel.Rows(value).Item("Color")
                        row("Material") = tablaProgramaCorteDePiel.Rows(value).Item("Material")
                        row("Cortador") = cortadortabla
                        cortador = cortadortabla
                        row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") & " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                        row("Cantidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad")
                        row("Unidad Compra") = tablaProgramaCorteDePiel.Rows(value).Item("Unidad Compra")
                        tablaProgramaCorte.Rows.Add(row)


                    End If

                Next

                tablaProveedorMaterial.TableName = "DSTablaMateriales"
                tablaProgramaCorte.TableName = "DSTabla"
                tablaCortadores.TableName = "DSTablaCortadores"
                '********************************Creación de reporte
                Try
                    If tablaProgramaCorte.Rows.Count = 0 Then
                    Else
                        '**Llenado del reporte
                        Me.Cursor = Cursors.WaitCursor
                        Dim OBJReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes
                        EntidadReporte = OBJReporte.LeerReporteporClave("PROGRAMA_CORTE_FORRO")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                            EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                        Dim reporte As New StiReport
                        'Dim ruta As String
                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("log") = GetRutaLogoPorNave(nave)
                        reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                        reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("material") = "FORRO DE CERDO"
                        reporte.RegData(tablaProveedorMaterial)
                        reporte.RegData(tablaProgramaCorte)
                        reporte.RegData(tablaCortadores)
                        reporte.Show()
                        '*********************
                        Me.Cursor = Cursors.Default
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Public Sub ImprimirProgramaCorteForroSintetico(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        ' Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Obtener los id de los componentes sintetico1, sintetico2, etc
        listaComponentes.Clear()
        tablaComponentes = obj.ObtenerComponentes("FORRO SINT", "xxxxxx")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next

        Dim tipo As String = "FORROSINT"
        Dim tablaProgramaCorte = New DataTable
        tablaProgramaCorte.Columns.Add("No")
        tablaProgramaCorte.Columns.Add("Pares")
        tablaProgramaCorte.Columns.Add("Lote")
        tablaProgramaCorte.Columns.Add("Colección")
        tablaProgramaCorte.Columns.Add("Modelo")
        tablaProgramaCorte.Columns.Add("ModeloSICY")
        tablaProgramaCorte.Columns.Add("Corrida")
        tablaProgramaCorte.Columns.Add("Material")
        tablaProgramaCorte.Columns.Add("Color")
        tablaProgramaCorte.Columns.Add("Cortador")
        tablaProgramaCorte.Columns.Add("CantidadUnidad")
        tablaProgramaCorte.Columns.Add("Cantidad")
        tablaProgramaCorte.Columns.Add("Unidad Compra")

        Dim tablaSumaCortador As New DataTable
        Dim tablaProveedorMaterial = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProgramaCorteDePiel = obj.ConsultaCortadoresPielForroSintetico(fecha, nave, listaComponentes, tipo)
        Dim tablaProveedorMateriales = tablaProveedorMaterial
        Dim tablaCortadores = obj.ConsultaCortadoresReporte(fecha, nave, listaComponentes, tipo)
        tablaSumaCortador = obj.ConsultarSumaCortadorForroSint(fecha, nave, listaComponentes)
        Dim Lote As String
        Dim cortador As String = ""
        Dim contador = 0
        Dim cortadortabla As String = ""

        If tablaCortadores.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay Cortadores registrados, no se puede generar el reporte.")
            'objAdvertencia.mensaje = "No hay Cortadores registrados, no se puede generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            If IsDBNull(tablaCortadores.Rows(0).Item("Cortadoress")) = True Then
                Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay Cortadores registrados, no se puede generar el reporte.")
                'objAdvertencia.mensaje = "No hay Cortadores registrados, no se puede generar el reporte."
                'objAdvertencia.ShowDialog()
            Else
                For value = 0 To tablaProgramaCorteDePiel.Rows.Count - 1

                    Dim row As DataRow = tablaProgramaCorte.NewRow()
                    cortadortabla = tablaProgramaCorteDePiel.Rows(value).Item("Cortador")

                    'If Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote") And cortador = cortadortabla Then

                    '    tablaProgramaCorte.Rows(contador - 1).Item("Material") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Material")
                    '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadUnidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") &
                    '        " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                    '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadML") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("CantidadML")
                    'Else
                    contador = contador + 1
                    row("No") = contador
                    row("Pares") = tablaProgramaCorteDePiel.Rows(value).Item("Pares")
                    row("Lote") = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                    Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                    row("Colección") = tablaProgramaCorteDePiel.Rows(value).Item("Colección")
                    row("Modelo") = tablaProgramaCorteDePiel.Rows(value).Item("Modelo")
                    row("ModeloSICY") = tablaProgramaCorteDePiel.Rows(value).Item("ModeloSICY")
                    row("Corrida") = tablaProgramaCorteDePiel.Rows(value).Item("Corrida")
                    row("Color") = tablaProgramaCorteDePiel.Rows(value).Item("Color")
                    row("Material") = tablaProgramaCorteDePiel.Rows(value).Item("Material")
                    row("Cortador") = cortadortabla
                    cortador = cortadortabla
                    row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") & " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                    row("Cantidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad")
                    row("Unidad Compra") = tablaProgramaCorteDePiel.Rows(value).Item("Unidad Compra")
                    tablaProgramaCorte.Rows.Add(row)

                    'End If
                Next

                tablaProveedorMaterial.TableName = "DSTablaMateriales"
                tablaProgramaCorte.TableName = "DSTabla"
                tablaCortadores.TableName = "DSTablaCortadores"
                tablaSumaCortador.TableName = "dsSumaCortador"
                '********************************Creación de reporte
                Try
                    If tablaProgramaCorte.Rows.Count = 0 Then
                    Else
                        '**Llenado del reporte
                        Me.Cursor = Cursors.WaitCursor
                        Dim OBJReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes
                        EntidadReporte = OBJReporte.LeerReporteporClave("PROGRAMA_CORTE_FORRO_SINTETICO")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                            EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                        Dim reporte As New StiReport
                        'Dim ruta As String
                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("log") = GetRutaLogoPorNave(nave)
                        reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                        reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("material") = "FORRO SINTÉTICO"
                        reporte.RegData(tablaProveedorMaterial)
                        reporte.RegData(tablaProgramaCorte)
                        reporte.RegData(tablaCortadores)
                        reporte.RegData(tablaSumaCortador)
                        reporte.Show()
                        '*********************
                        Me.Cursor = Cursors.Default
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Public Sub ImprimirProgramaCortePiel(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        'Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Obtener los id de los componentes piel1, piel2, etc
        listaComponentes.Clear()
        listaComponentes.Clear()
        tablaComponentes = obj.ObtenerComponentes("PIEL", "PIEL SINT")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        Dim tipo As String = "PIEL"
        Dim tablaProgramaCorte = New DataTable
        tablaProgramaCorte.Columns.Add("No")
        tablaProgramaCorte.Columns.Add("Pares")
        tablaProgramaCorte.Columns.Add("Lote")
        tablaProgramaCorte.Columns.Add("Colección")
        tablaProgramaCorte.Columns.Add("Modelo")
        tablaProgramaCorte.Columns.Add("ModeloSICY")
        tablaProgramaCorte.Columns.Add("Corrida")
        tablaProgramaCorte.Columns.Add("Material")
        tablaProgramaCorte.Columns.Add("Color")
        tablaProgramaCorte.Columns.Add("Cortador")
        tablaProgramaCorte.Columns.Add("CantidadUnidad")
        tablaProgramaCorte.Columns.Add("Cantidad")
        tablaProgramaCorte.Columns.Add("Unidad Compra")


        Dim tablaProveedorMaterial = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProgramaCorteDePiel = obj.ConsultaCortadoresPielPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProveedorMateriales = tablaProveedorMaterial
        Dim tablaCortadores = obj.ConsultaCortadoresReporte(fecha, nave, listaComponentes, tipo)
        Dim Lote As Integer = 0
        Dim cortador As String = ""
        Dim contador = 0
        Dim cortadortabla As String = ""

        If tablaCortadores.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay Cortadores registrados, no se puede generar el reporte.")
            'objAdvertencia.mensaje = "No hay Cortadores registrados, no se puede generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            If IsDBNull(tablaCortadores.Rows(0).Item("Cortadoress")) = True Then
                Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay Cortadores registrados, no se puede generar el reporte.")
                'objAdvertencia.mensaje = "No hay Cortadores registrados, no se puede generar el reporte."
                'objAdvertencia.ShowDialog()
            Else
                For value = 0 To tablaProgramaCorteDePiel.Rows.Count - 1

                    Dim row As DataRow = tablaProgramaCorte.NewRow()
                    If IsDBNull(tablaProgramaCorteDePiel.Rows(value).Item("Cortador")) = True Then
                    Else
                        cortadortabla = tablaProgramaCorteDePiel.Rows(value).Item("Cortador")
                    End If
                    If Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote") And cortador = cortadortabla Then

                        tablaProgramaCorte.Rows(contador - 1).Item("Material") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Material")
                        tablaProgramaCorte.Rows(contador - 1).Item("CantidadUnidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") &
                        " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                        tablaProgramaCorte.Rows(contador - 1).Item("Cantidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad")

                    Else
                        contador = contador + 1
                        row("No") = contador
                        row("Pares") = tablaProgramaCorteDePiel.Rows(value).Item("Pares")
                        row("Lote") = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                        Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                        row("Colección") = tablaProgramaCorteDePiel.Rows(value).Item("Colección")
                        row("Modelo") = tablaProgramaCorteDePiel.Rows(value).Item("Modelo")
                        row("ModeloSICY") = tablaProgramaCorteDePiel.Rows(value).Item("ModeloSICY")
                        row("Corrida") = tablaProgramaCorteDePiel.Rows(value).Item("Corrida")
                        row("Color") = tablaProgramaCorteDePiel.Rows(value).Item("Color")
                        row("Material") = tablaProgramaCorteDePiel.Rows(value).Item("Material")
                        row("Cortador") = cortadortabla
                        cortador = cortadortabla
                        row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") & " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                        tablaProgramaCorte.Rows.Add(row)
                        'row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad")
                        row("Cantidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad")
                        row("Unidad Compra") = tablaProgramaCorteDePiel.Rows(value).Item("Unidad Compra")
                    End If

                Next

                tablaProveedorMaterial.TableName = "DSTablaMateriales"
                tablaProgramaCorte.TableName = "DSTabla"
                tablaCortadores.TableName = "DSTablaCortadores"
                '********************************Creación de reporte
                Try
                    If tablaProgramaCorte.Rows.Count = 0 Then
                    Else
                        '**Llenado del reporte
                        Me.Cursor = Cursors.WaitCursor
                        Dim OBJReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes
                        EntidadReporte = OBJReporte.LeerReporteporClave("PROGRAMA_CORTE_PIEL")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                            EntidadReporte.Pnombre + ".mrt"

                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                        Dim reporte As New StiReport
                        'Dim ruta As String
                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("log") = GetRutaLogoPorNave(nave)
                        reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                        reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("material") = "PIEL"
                        reporte.RegData(tablaProveedorMaterial)
                        reporte.RegData(tablaProgramaCorte)
                        reporte.RegData(tablaCortadores)
                        reporte.Show()
                        '*********************
                        Me.Cursor = Cursors.Default
                    End If
                Catch ex As Exception
                    MsgBox("Error al generar el reporte." + ex.Message)
                    Me.Cursor = Cursors.Default
                End Try
            End If
        End If
    End Sub

    Public Sub ImprimirProgramaCortePielSintetico(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        'Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Obtener los id de los componentes sintetico1, sintetico2, etc
        listaComponentes.Clear()
        tablaComponentes = obj.ObtenerComponentes("PIEL SINT", "xxxxxx")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        Dim tipo As String = "PIELSINT"
        Dim tablaProgramaCorte = New DataTable
        tablaProgramaCorte.Columns.Add("No")
        tablaProgramaCorte.Columns.Add("Pares")
        tablaProgramaCorte.Columns.Add("Lote")
        tablaProgramaCorte.Columns.Add("Colección")
        tablaProgramaCorte.Columns.Add("Modelo")
        tablaProgramaCorte.Columns.Add("ModeloSICY")
        tablaProgramaCorte.Columns.Add("Corrida")
        tablaProgramaCorte.Columns.Add("Material")
        tablaProgramaCorte.Columns.Add("Color")
        tablaProgramaCorte.Columns.Add("Cortador")
        tablaProgramaCorte.Columns.Add("CantidadUnidad")
        tablaProgramaCorte.Columns.Add("Cantidad")
        tablaProgramaCorte.Columns.Add("Unidad Compra")
        Dim tablaSumaCortador As New DataTable

        Dim tablaProveedorMaterial = obj.ConsultaMaterialesCortadoresPiel(fecha, nave, listaComponentes, tipo)
        Dim tablaProgramaCorteDePiel = obj.ConsultaCortadoresPielSintetico(fecha, nave, listaComponentes, tipo)
        Dim tablaProveedorMateriales = tablaProveedorMaterial
        Dim tablaCortadores = obj.ConsultaCortadoresReporte(fecha, nave, listaComponentes, tipo)
        tablaSumaCortador = obj.ConsultarSumaCortadorPielSint(fecha, nave, listaComponentes)
        Dim Lote As String
        Dim cortador As String = ""
        Dim contador = 0
        Dim cortadortabla As String = ""

        If tablaCortadores.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay Cortadores registrados, no se puede generar el reporte.")
            'objAdvertencia.mensaje = "No hay Cortadores registrados, no se puede generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            If IsDBNull(tablaCortadores.Rows(0).Item("Cortadoress")) = True Then
                Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay Cortadores registrados, no se puede generar el reporte.")
                'objAdvertencia.mensaje = "No hay Cortadores registrados, no se puede generar el reporte."
                'objAdvertencia.ShowDialog()
            Else
                For value = 0 To tablaProgramaCorteDePiel.Rows.Count - 1

                    Dim row As DataRow = tablaProgramaCorte.NewRow()
                    If IsDBNull(tablaProgramaCorteDePiel.Rows(value).Item("Cortador")) = True Then
                    Else
                        cortadortabla = tablaProgramaCorteDePiel.Rows(value).Item("Cortador")
                    End If
                    'If Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote") And cortador = cortadortabla Then

                    '    tablaProgramaCorte.Rows(contador - 1).Item("Material") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Material")
                    '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadUnidad") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") &
                    '    " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                    '    tablaProgramaCorte.Rows(contador - 1).Item("CantidadML") += " / " & tablaProgramaCorteDePiel.Rows(value).Item("CantidadML")
                    'Else
                    contador = contador + 1
                    row("No") = contador
                    row("Pares") = tablaProgramaCorteDePiel.Rows(value).Item("Pares")
                    row("Lote") = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                    Lote = tablaProgramaCorteDePiel.Rows(value).Item("Lote")
                    row("Colección") = tablaProgramaCorteDePiel.Rows(value).Item("Colección")
                    row("Modelo") = tablaProgramaCorteDePiel.Rows(value).Item("Modelo")
                    row("ModeloSICY") = tablaProgramaCorteDePiel.Rows(value).Item("ModeloSICY")
                    row("Corrida") = tablaProgramaCorteDePiel.Rows(value).Item("Corrida")
                    row("Color") = tablaProgramaCorteDePiel.Rows(value).Item("Color")
                    row("Material") = tablaProgramaCorteDePiel.Rows(value).Item("Material")
                    row("Cortador") = cortadortabla
                    cortador = cortadortabla
                    row("CantidadUnidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad") & " " & tablaProgramaCorteDePiel.Rows(value).Item("Unidad")
                    tablaProgramaCorte.Rows.Add(row)
                    row("Cantidad") = tablaProgramaCorteDePiel.Rows(value).Item("Cantidad")
                    row("Unidad Compra") = tablaProgramaCorteDePiel.Rows(value).Item("Unidad Compra")

                    ' End If

                Next

                tablaProveedorMaterial.TableName = "DSTablaMateriales"
                tablaProgramaCorte.TableName = "DSTabla"
                tablaCortadores.TableName = "DSTablaCortadores"
                tablaSumaCortador.TableName = "dsSumaCortador"
                '********************************Creación de reporte
                Try
                    If tablaProgramaCorte.Rows.Count = 0 Then
                    Else
                        '**Llenado del reporte
                        Me.Cursor = Cursors.WaitCursor
                        Dim OBJReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes
                        EntidadReporte = OBJReporte.LeerReporteporClave("PROGRAMA_CORTE_PIEL_SINTETICO")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                            EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                        Dim reporte As New StiReport
                        'Dim ruta As String
                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("log") = GetRutaLogoPorNave(nave)
                        reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                        reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("material") = "PIEL SINTÉTICO"
                        reporte.RegData(tablaProveedorMaterial)
                        reporte.RegData(tablaProgramaCorte)
                        reporte.RegData(tablaCortadores)
                        reporte.RegData(tablaSumaCortador)
                        reporte.Show()
                        '*********************
                        Me.Cursor = Cursors.Default
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Public Sub ImprimirDesglosadoPlanta(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de planta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDePlanta(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lote")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("C5")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("tl1")
            TablaReporteConcentrado.Columns.Add("tl2")
            TablaReporteConcentrado.Columns.Add("tl3")
            TablaReporteConcentrado.Columns.Add("tl4")
            TablaReporteConcentrado.Columns.Add("tl5")
            TablaReporteConcentrado.Columns.Add("tl6")
            TablaReporteConcentrado.Columns.Add("tl7")
            TablaReporteConcentrado.Columns.Add("tl8")
            TablaReporteConcentrado.Columns.Add("tl9")
            TablaReporteConcentrado.Columns.Add("tl10")
            TablaReporteConcentrado.Columns.Add("tl11")
            TablaReporteConcentrado.Columns.Add("tl12")
            TablaReporteConcentrado.Columns.Add("tl13")
            TablaReporteConcentrado.Columns.Add("tl14")
            TablaReporteConcentrado.Columns.Add("tl15")
            TablaReporteConcentrado.Columns.Add("tl16")
            TablaReporteConcentrado.Columns.Add("tl17")
            TablaReporteConcentrado.Columns.Add("tl18")
            TablaReporteConcentrado.Columns.Add("tl19")
            TablaReporteConcentrado.Columns.Add("tl20")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")
            TablaReporteConcentrado.Columns.Add("t9")
            TablaReporteConcentrado.Columns.Add("t10")
            TablaReporteConcentrado.Columns.Add("t11")
            TablaReporteConcentrado.Columns.Add("t12")
            TablaReporteConcentrado.Columns.Add("t13")
            TablaReporteConcentrado.Columns.Add("t14")
            TablaReporteConcentrado.Columns.Add("t15")
            TablaReporteConcentrado.Columns.Add("t16")
            TablaReporteConcentrado.Columns.Add("t17")
            TablaReporteConcentrado.Columns.Add("t18")
            TablaReporteConcentrado.Columns.Add("t19")
            TablaReporteConcentrado.Columns.Add("t20")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = TablaReporteConcentrado.NewRow()
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Material") = tabla1.Rows(value).Item("Material")
                row("C5") = tabla1.Rows(value).Item("C5")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                'row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 6 To 25
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                TablaReporteConcentrado.Rows.Add(row)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("RELACION_DESGLOSADA_FORMATO4")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "PLANTA"
                    reporte("tituloC5") = "HORMA"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirConcentradoHerrajeporProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        Dim clasificacion2 As Integer = 0
        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("HERRAJE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ObtenerConcentradoHerraje(fecha, nave, clasificacion)

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else

            Dim tablaRelacionDesglosadaDeHerraje = New DataTable
            tablaRelacionDesglosadaDeHerraje = tabla1
            'tablaRelacionDesglosadaDeHerraje.Clear()
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("NO")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("PARES")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("LOTE")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("MATERIAL")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("COLECCIÓN")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("CORRIDA")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("PROVEEDOR")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("12")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("12½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("13")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("13½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("14")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("14½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("15")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("15½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("16")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("16½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("17")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("17½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("18")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("18½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("19")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("19½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("20")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("20½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("21")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("21½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("22")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("22½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("23")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("23½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("24")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("24½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("25")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("25½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("26")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("26½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("27")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("27½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("28")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("28½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("29")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("29½")
            'tablaRelacionDesglosadaDeHerraje.Columns.Add("30")
            'Dim contador = 1

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = tablaRelacionDesglosadaDeHerraje.NewRow()
            '    row("NO") = contador
            '    row("PARES") = tabla1.Rows(value).Item("Pares")
            '    row("LOTE") = tabla1.Rows(value).Item("Lotes")
            '    row("MATERIAL") = tabla1.Rows(value).Item("Material")
            '    row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            '    row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            '    row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
            '    For value2 = 7 To 26
            '        Dim x = tabla1.Rows(value).Item(value2).ToString
            '        Select Case tabla1.Rows(value).Item(value2).ToString
            '            Case "12"
            '                row("12") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "12½"
            '                row("12½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "13"
            '                row("13") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "13½"
            '                row("13½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "14"
            '                row("14") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "14½"
            '                row("14½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "15"
            '                row("15") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "15½"
            '                row("15½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "16"
            '                row("16") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "16½"
            '                row("16½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "17"
            '                row("17") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "17½"
            '                row("17½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "18"
            '                row("18") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "18½"
            '                row("18½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "19"
            '                row("19") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "19½"
            '                row("19½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "20"
            '                row("20") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "20½"
            '                row("20½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "21"
            '                row("21") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "21½"
            '                row("21½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "22"
            '                row("22") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "22½"
            '                row("22½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "23"
            '                row("23") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "23½"
            '                row("23½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "24"
            '                row("24") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "24½"
            '                row("24½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "25"
            '                row("25") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "25½"
            '                row("25½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "26"
            '                row("26") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "26½"
            '                row("26½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "27"
            '                row("27") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "27½"
            '                row("27½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "28"
            '                row("28") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "28½"
            '                row("28½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "29"
            '                row("29") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "29"
            '                row("29½") = tabla1.Rows(value).Item(value2 + 20)
            '            Case "30"
            '                row("30") = tabla1.Rows(value).Item(value2 + 20)
            '        End Select
            '    Next
            '    contador = contador + 1
            '    tablaRelacionDesglosadaDeHerraje.Rows.Add(row)
            'Next
            Try
                If tablaRelacionDesglosadaDeHerraje.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_HERRAJE_POR_PROVEEDOR2")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "HERRAJE"
                    reporte.RegData(tablaRelacionDesglosadaDeHerraje)
                    reporte.Show()
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirDesglosadoTacon(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("TACON")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosada(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lote")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("C5")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("tl1")
            TablaReporteConcentrado.Columns.Add("tl2")
            TablaReporteConcentrado.Columns.Add("tl3")
            TablaReporteConcentrado.Columns.Add("tl4")
            TablaReporteConcentrado.Columns.Add("tl5")
            TablaReporteConcentrado.Columns.Add("tl6")
            TablaReporteConcentrado.Columns.Add("tl7")
            TablaReporteConcentrado.Columns.Add("tl8")
            TablaReporteConcentrado.Columns.Add("tl9")
            TablaReporteConcentrado.Columns.Add("tl10")
            TablaReporteConcentrado.Columns.Add("tl11")
            TablaReporteConcentrado.Columns.Add("tl12")
            TablaReporteConcentrado.Columns.Add("tl13")
            TablaReporteConcentrado.Columns.Add("tl14")
            TablaReporteConcentrado.Columns.Add("tl15")
            TablaReporteConcentrado.Columns.Add("tl16")
            TablaReporteConcentrado.Columns.Add("tl17")
            TablaReporteConcentrado.Columns.Add("tl18")
            TablaReporteConcentrado.Columns.Add("tl19")
            TablaReporteConcentrado.Columns.Add("tl20")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")
            TablaReporteConcentrado.Columns.Add("t9")
            TablaReporteConcentrado.Columns.Add("t10")
            TablaReporteConcentrado.Columns.Add("t11")
            TablaReporteConcentrado.Columns.Add("t12")
            TablaReporteConcentrado.Columns.Add("t13")
            TablaReporteConcentrado.Columns.Add("t14")
            TablaReporteConcentrado.Columns.Add("t15")
            TablaReporteConcentrado.Columns.Add("t16")
            TablaReporteConcentrado.Columns.Add("t17")
            TablaReporteConcentrado.Columns.Add("t18")
            TablaReporteConcentrado.Columns.Add("t19")
            TablaReporteConcentrado.Columns.Add("t20")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = TablaReporteConcentrado.NewRow()
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Material") = tabla1.Rows(value).Item("Material")
                row("C5") = tabla1.Rows(value).Item("C5")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                TablaReporteConcentrado.Rows.Add(row)
            Next
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("RELACION_DESGLOSADA_FORMATO4")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma()
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "TACON"
                    reporte("tituloC5") = "COLECCIÓN"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirDesglosadoSuela(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosada(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lote")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("C5")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("tl1")
            TablaReporteConcentrado.Columns.Add("tl2")
            TablaReporteConcentrado.Columns.Add("tl3")
            TablaReporteConcentrado.Columns.Add("tl4")
            TablaReporteConcentrado.Columns.Add("tl5")
            TablaReporteConcentrado.Columns.Add("tl6")
            TablaReporteConcentrado.Columns.Add("tl7")
            TablaReporteConcentrado.Columns.Add("tl8")
            TablaReporteConcentrado.Columns.Add("tl9")
            TablaReporteConcentrado.Columns.Add("tl10")
            TablaReporteConcentrado.Columns.Add("tl11")
            TablaReporteConcentrado.Columns.Add("tl12")
            TablaReporteConcentrado.Columns.Add("tl13")
            TablaReporteConcentrado.Columns.Add("tl14")
            TablaReporteConcentrado.Columns.Add("tl15")
            TablaReporteConcentrado.Columns.Add("tl16")
            TablaReporteConcentrado.Columns.Add("tl17")
            TablaReporteConcentrado.Columns.Add("tl18")
            TablaReporteConcentrado.Columns.Add("tl19")
            TablaReporteConcentrado.Columns.Add("tl20")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")
            TablaReporteConcentrado.Columns.Add("t9")
            TablaReporteConcentrado.Columns.Add("t10")
            TablaReporteConcentrado.Columns.Add("t11")
            TablaReporteConcentrado.Columns.Add("t12")
            TablaReporteConcentrado.Columns.Add("t13")
            TablaReporteConcentrado.Columns.Add("t14")
            TablaReporteConcentrado.Columns.Add("t15")
            TablaReporteConcentrado.Columns.Add("t16")
            TablaReporteConcentrado.Columns.Add("t17")
            TablaReporteConcentrado.Columns.Add("t18")
            TablaReporteConcentrado.Columns.Add("t19")
            TablaReporteConcentrado.Columns.Add("t20")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = TablaReporteConcentrado.NewRow()
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Material") = tabla1.Rows(value).Item("Material")
                row("C5") = tabla1.Rows(value).Item("C5")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                TablaReporteConcentrado.Rows.Add(row)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("RELACION_DESGLOSADA_FORMATO4")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "SUELA"
                    reporte("tituloC5") = "COLECCIÓN"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReporteAgujeta(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de agujeta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("AGUJETA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteDeFormato3(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Try
                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_DE_MATERIAL_FORMATO3")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                reporte("log") = GetRutaLogoPorNave(nave)
                reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("titulo") = "REPORTE DE AGUJETA"
                reporte.RegData(tabla1)
                reporte.Show()
                '*********************
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirDesglosadodePlantilla(ByVal fecha As String, ByVal nave As Integer, ByVal clasificacion As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTILLA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaPlantilla(fecha, nave, clasificacion)

        'tabla1 = obj.ReporteRelacionDesglosada(fecha, nave, clasificacion) '30/11/2019
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lote")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("C5")
            TablaReporteConcentrado.Columns.Add("Modelo")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Color")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("tl1")
            TablaReporteConcentrado.Columns.Add("tl2")
            TablaReporteConcentrado.Columns.Add("tl3")
            TablaReporteConcentrado.Columns.Add("tl4")
            TablaReporteConcentrado.Columns.Add("tl5")
            TablaReporteConcentrado.Columns.Add("tl6")
            TablaReporteConcentrado.Columns.Add("tl7")
            TablaReporteConcentrado.Columns.Add("tl8")
            TablaReporteConcentrado.Columns.Add("tl9")
            TablaReporteConcentrado.Columns.Add("tl10")
            TablaReporteConcentrado.Columns.Add("tl11")
            TablaReporteConcentrado.Columns.Add("tl12")
            TablaReporteConcentrado.Columns.Add("tl13")
            TablaReporteConcentrado.Columns.Add("tl14")
            TablaReporteConcentrado.Columns.Add("tl15")
            TablaReporteConcentrado.Columns.Add("tl16")
            TablaReporteConcentrado.Columns.Add("tl17")
            TablaReporteConcentrado.Columns.Add("tl18")
            TablaReporteConcentrado.Columns.Add("tl19")
            TablaReporteConcentrado.Columns.Add("tl20")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")
            TablaReporteConcentrado.Columns.Add("t9")
            TablaReporteConcentrado.Columns.Add("t10")
            TablaReporteConcentrado.Columns.Add("t11")
            TablaReporteConcentrado.Columns.Add("t12")
            TablaReporteConcentrado.Columns.Add("t13")
            TablaReporteConcentrado.Columns.Add("t14")
            TablaReporteConcentrado.Columns.Add("t15")
            TablaReporteConcentrado.Columns.Add("t16")
            TablaReporteConcentrado.Columns.Add("t17")
            TablaReporteConcentrado.Columns.Add("t18")
            TablaReporteConcentrado.Columns.Add("t19")
            TablaReporteConcentrado.Columns.Add("t20")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = TablaReporteConcentrado.NewRow()
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Material") = tabla1.Rows(value).Item("Material")
                row("C5") = tabla1.Rows(value).Item("C5")
                row("Modelo") = tabla1.Rows(value).Item("Modelo")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                row("Color") = tabla1.Rows(value).Item("Color")
                row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 9 To 28
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                TablaReporteConcentrado.Rows.Add(row)
            Next
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("RELACION_DESGLOSADA_PLANTILLA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma()
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "PLANTILLA"
                    reporte("tituloC5") = "COLECCIÓN"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReportePlastisol(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLASTISOL")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteDeFormato3(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Try
                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_DE_MATERIAL_FORMATO3")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                reporte("log") = GetRutaLogoPorNave(nave)
                reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("titulo") = "REPORTE DE PLASTISOL"
                reporte.RegData(tabla1)
                reporte.Show()
                '*********************
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReporteCaja(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de caja
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CAJA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteMaterialesFormato2Planta(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Try
                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_FORMATO2CAJA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                reporte("log") = GetRutaLogoPorNave(nave)
                reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("titulo") = "REPORTE PARA CAJA"
                reporte("tituloCelda") = "COLECCIÓN"
                reporte.RegData(tabla1)
                reporte.Show()
                '*********************
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReporteCascoContrafuerte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Buscar id clasificación de contrafuerte
        tablaClasificacion2 = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion2 = tablaClasificacion2.Rows(0).Item(0)
        tabla1 = obj.ConsultaReporteDesglosado(fecha, nave, clasificacion, clasificacion2)
        'tabla1 = obj.ConsultaCasco1(fecha, nave, clasificacion)
        'tablaA = obj.ConsultaCasco2(fecha, nave, clasificacion)
        'tabla2 = obj.ConsultaContrafuerte1(fecha, nave, clasificacion)
        'tablaB = obj.ConsultaContrafuerte2(fecha, nave, clasificacion)
        tabla1.TableName = "tablaOrdenesdeProduccion"
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Try
                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_CASCO_Y_CONTRAFUERTE2")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                reporte("log") = GetRutaLogoPorNave(nave)
                reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte.RegData(tabla1)
                reporte.Show()
                '*********************
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReporteHerrajes(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de herraje
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("HERRAJE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Obtener los id de los componentes Herraje1, Herraje2, etc
        tablaComponentes = obj.ObtenerComponentes("HERRAJE", "")

        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        tabla1 = obj.ConsultaReporteHerrajesImpresion(fecha, nave, listaComponentes)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Dim listaLotes As New List(Of Integer)
            Dim Tabla = New DataTable
            Tabla.Clear()
            Tabla.Columns.Add("No")
            Tabla.Columns.Add("Pares")
            Tabla.Columns.Add("Lote")
            Tabla.Columns.Add("Modelo")
            Tabla.Columns.Add("ModeloSAY")
            Tabla.Columns.Add("Corrida")
            Tabla.Columns.Add("Coleccion")
            Tabla.Columns.Add("Proveedor")
            Tabla.Columns.Add("IdConsumo1")
            Tabla.Columns.Add("Herraje1")
            Tabla.Columns.Add("CantidadHerraje1")
            Tabla.Columns.Add("IdConsumo2")
            Tabla.Columns.Add("Herraje2")
            Tabla.Columns.Add("CantidadHerraje2")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = Tabla.NewRow()
                Dim contador = 0
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Modelo") = tabla1.Rows(value).Item("Modelo")
                row("ModeloSAY") = tabla1.Rows(value).Item("ModeloSAY")
                'row("Material") = tabla1.Rows(value).Item("Material")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                row("Coleccion") = tabla1.Rows(value).Item("Coleccion")
                row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                row("IdConsumo1") = tabla1.Rows(value).Item("IdConsumo1")
                row("Herraje1") = tabla1.Rows(value).Item("Herraje1")
                row("CantidadHerraje1") = tabla1.Rows(value).Item("CantidadHerraje1")
                row("IdConsumo2") = tabla1.Rows(value).Item("IdConsumo2")
                row("Herraje2") = tabla1.Rows(value).Item("Herraje2")
                row("CantidadHerraje2") = tabla1.Rows(value).Item("CantidadHerraje2")
                'If listaLotes.Count > 0 Then
                '    For valor = 0 To listaLotes.Count - 1
                '        If tabla1.Rows(value).Item("Lote") = listaLotes.Item(valor) Then
                '            contador = contador + 1
                '        End If
                '        If contador > 0 Then
                '            row("Herraje") = "HERRAJE 2"
                '        Else
                '            row("Herraje") = "HERRAJE 1"
                '        End If
                '    Next
                'Else
                '    row("Herraje") = "HERRAJE 1"
                'End If
                'For value2 = 9 To 22
                '    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                '        row(value2) = tabla1.Rows(value).Item(value2)
                '    End If
                'Next
                listaLotes.Add(tabla1.Rows(value).Item("Lote"))
                Tabla.Rows.Add(row)
            Next
            '********************************Creación de reporte
            Try
                If Tabla.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_HERRAJES_NUEVO")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(Tabla)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReportePlanta(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de planta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteMaterialesFormatoPlanta(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_PLANTA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA PLANTA"
                    reporte("tituloCelda") = "HORMA"
                    reporte.RegData(tabla1)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReportePlantilla(ByVal fecha As String, ByVal nave As Integer, clasificacion As Integer)
        Dim objbu As New ReportesBU
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = objbu.ObtenerClasificacion("PLANTILLA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tablaComponentes = objbu.ObtenerComponentes("PLANTILLA", "")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        tabla1 = objbu.ConsultaReporteTacon(fecha, nave, clasificacion)
        tabla1.TableName = "tablaOrdenesdeProduccion"

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_PLANTILLA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA PLANTILLA"
                    reporte("TituloCelda") = "PLANTILLA"
                    reporte.RegData(tabla1)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReporteTacon(ByVal fecha As String, ByVal nave As Integer, clasificacion As Integer)
        Dim objbu As New ReportesBU
        Dim tablaClasificacion As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable

        listaComponentes.Clear()
        tablaClasificacion = objbu.ObtenerClasificacion("TACON")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tablaComponentes = objbu.ObtenerComponentes("TACON", "")
        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        tabla1 = objbu.ConsultaReporteTacon(fecha, nave, clasificacion)
        tabla1.TableName = "tablaOrdenesdeProduccion"

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_TACON")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA TACON"
                    reporte("TituloCelda") = "TACÓN"
                    reporte.RegData(tabla1)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub


    Public Sub ImprimirReporteSuela(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        ' listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Obtener los id de los componentes Suela1, Suela2, etc
        ''tablaComponentes = obj.ObtenerComponentes("SUELA", "")
        'For value = 0 To tablaComponentes.Rows.Count - 1
        'listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        ' Next
        tabla1 = obj.ConsultaReporteSuelas1N(fecha, nave)
        tabla1.TableName = "tablaOrdenesdeProduccion"
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_SUELAS123")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA SUELA"
                    reporte("TituloCelda") = "SUELA"
                    reporte.RegData(tabla1)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    'Public Sub ImprimirDesglosadoContrafuerte(ByVal fecha As String, ByVal nave As Integer)
    '    Dim obj As New ReportesBU

    '    Dim tablaClasificacion As DataTable
    '    Dim clasificacion As Integer = 0
    '    Dim tablaClasificacion2 As DataTable
    '    Dim clasificacion2 As Integer = 0

    '    Dim listaComponentes As New List(Of Integer)
    '    Dim tablaComponentes As New DataTable
    '    Dim tabla1 As New DataTable
    '    Dim tabla2 As New DataTable
    '    Dim tablaA As New DataTable
    '    Dim tablaB As New DataTable
    '    'Dim idSicy As DataTable

    '    '*********************************************************************************************************************
    '    'Buscar id clasificación de casco
    '    listaComponentes.Clear()
    '    tablaClasificacion = obj.ObtenerClasificacion("CASCO")
    '    clasificacion = tablaClasificacion.Rows(0).Item(0)
    '    'Buscar id clasificación de contrafuerte
    '    tablaClasificacion2 = obj.ObtenerClasificacion("CONTRAFUERTE")
    '    clasificacion2 = tablaClasificacion2.Rows(0).Item(0)
    '    tabla1 = obj.ReporteRelacionDesglosadaDeCascoYContrafuerte(fecha, nave, clasificacion, clasificacion2)
    '    tabla1.TableName = ""

    '    If tabla1.Rows.Count = 0 Then
    '        Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
    '        'objAdvertencia.mensaje = "No hay información para generar el reporte."
    '        'objAdvertencia.ShowDialog()
    '    Else
    '        Dim TablaReporteConcentrado = New DataTable
    '        TablaReporteConcentrado.Clear()
    '        TablaReporteConcentrado.Columns.Add("No")
    '        TablaReporteConcentrado.Columns.Add("Pares")
    '        TablaReporteConcentrado.Columns.Add("Lotes")
    '        TablaReporteConcentrado.Columns.Add("Contrafuerte")
    '        TablaReporteConcentrado.Columns.Add("Corrida")
    '        TablaReporteConcentrado.Columns.Add("Proveedor")
    '        TablaReporteConcentrado.Columns.Add("t1")
    '        TablaReporteConcentrado.Columns.Add("t2")
    '        TablaReporteConcentrado.Columns.Add("t3")
    '        TablaReporteConcentrado.Columns.Add("t4")
    '        TablaReporteConcentrado.Columns.Add("t5")
    '        TablaReporteConcentrado.Columns.Add("t6")
    '        TablaReporteConcentrado.Columns.Add("t7")
    '        TablaReporteConcentrado.Columns.Add("t8")

    '        For value = 0 To tabla1.Rows.Count - 1
    '            Dim t1 As Integer? = Nothing
    '            Dim t2 As Integer? = Nothing
    '            Dim t3 As Integer? = Nothing
    '            Dim t4 As Integer? = Nothing
    '            Dim t5 As Integer? = Nothing
    '            Dim t6 As Integer? = Nothing
    '            Dim t7 As Integer? = Nothing
    '            Dim t8 As Integer? = Nothing
    '            Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
    '            ' rowc("No") = tabla1.Rows(value).Item("No").ToString
    '            rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
    '            rowc("Lotes") = tabla1.Rows(value).Item("Lote").ToString
    '            rowc("Contrafuerte") = tabla1.Rows(value).Item("C5").ToString
    '            rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
    '            rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
    '            Dim cont = 4
    '            For value2 = 7 To 26

    '                Dim x = tabla1.Rows(value).Item(value2).ToString
    '                Dim y = x.Trim.Replace("½", "")
    '                Select Case y
    '                    Case "12"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t1 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t1") = t1
    '                    Case "13"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t1 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t1") = t1
    '                    Case "14"
    '                        Dim o = tabla1.Rows(value).Item(value)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t1 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t1") = t1
    '                    Case "15"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t2 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t2") = t2
    '                    Case "16"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t2 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t2") = t2
    '                    Case "17"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t2 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t2") = t2
    '                    Case "18"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t3 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t3") = t3
    '                    Case "19"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t3 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t3") = t3
    '                    Case "20"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t4 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t4") = t4
    '                    Case "21"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t4 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t4") = t4
    '                    Case "22"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t5 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t5") = t5
    '                    Case "23"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t5 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t5") = t5
    '                    Case "24"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t5 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t5") = t5
    '                    Case "25"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t6 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t6") = t6
    '                    Case "26"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t6 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t6") = t6
    '                    Case "27"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t7 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t7") = t7
    '                    Case "28"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t7 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t7") = t7
    '                    Case "29"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t8 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t8") = t8
    '                    Case "30"
    '                        Dim o = tabla1.Rows(value).Item(value2)
    '                        If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
    '                            t8 += tabla1.Rows(value).Item(value2 + 20)
    '                        End If
    '                        cont = cont + 1
    '                        rowc("t8") = t8
    '                End Select
    '            Next
    '            TablaReporteConcentrado.Rows.Add(rowc)
    '        Next
    '        TablaReporteConcentrado.TableName = "TablaReporteConcentrado"
    '        '********************************Creación de reporte
    '        Try
    '            If TablaReporteConcentrado.Rows.Count = 0 Then
    '            Else
    '                '**Llenado del reporte
    '                Me.Cursor = Cursors.WaitCursor
    '                Dim OBJReporte As New Framework.Negocios.ReportesBU
    '                Dim EntidadReporte As Entidades.Reportes
    '                EntidadReporte = OBJReporte.LeerReporteporClave("DESGLOSADO_DE_CONTRAFUERTE")
    '                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
    '                    EntidadReporte.Pnombre + ".mrt"
    '                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
    '                Dim reporte As New StiReport
    '                'Dim ruta As String
    '                reporte.Load(archivo)
    '                reporte.Compile()
    '                reporte("log") = GetRutaLogoPorNave(nave)
    '                reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
    '                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
    '                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    '                reporte("material") = "CASCO Y CONTRAFUERTE"
    '                reporte("tituloC5") = "CONTRAFUERTE"
    '                reporte.RegData(TablaReporteConcentrado)
    '                reporte.Show()
    '                '*********************
    '                Me.Cursor = Cursors.Default
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

    Public Sub ImprimirConcentradoContrafuerte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)

        tabla1 = obj.ConsultaCasco1(fecha, nave, clasificacion)
        tablaA = obj.ConsultaCasco2(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Contrafuerte")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer? = Nothing
                Dim t2 As Integer? = Nothing
                Dim t3 As Integer? = Nothing
                Dim t4 As Integer? = Nothing
                Dim t5 As Integer? = Nothing
                Dim t6 As Integer? = Nothing
                'Dim t7 As Integer? = Nothing
                Dim t8 As Integer? = Nothing
                Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
                'rowc("No") = tabla1.Rows(value).Item("No").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Lotes") = tabla1.Rows(value).Item("Lotes").ToString
                rowc("Contrafuerte") = tabla1.Rows(value).Item("Material").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 4
                For value2 = 0 To 19
                    If value2 < 5 Then
                    Else
                        Dim x = tabla1.Rows(value).Item(value2).ToString
                        Dim y = x.Trim.Replace("½", "")
                        Select Case y
                            Case "12"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t1 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t1") = t1
                            Case "13"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t1 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t1") = t1
                            Case "14"
                                Dim o = tablaA.Rows(value).Item(value)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t1 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t1") = t1
                            Case "15"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t2 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t2") = t2
                            Case "16"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t2 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t2") = t2
                            Case "17"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t2 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t2") = t2
                            Case "18"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t3 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t3") = t3
                            Case "19"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t3 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t3") = t3
                            Case "20"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t4 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t4") = t4
                            Case "21"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t4 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t4") = t4
                            Case "22"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t5 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t5") = t5
                            Case "23"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t5 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t5") = t5
                            Case "24"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t5 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t5") = t5
                            Case "25"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t6 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t6") = t6
                            Case "26"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t6 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t6") = t6
                            Case "27"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t6 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t6") = t6
                            Case "28"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t8 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t8") = t8
                            Case "29"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t8 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t8") = t8
                            Case "30"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t8 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t8") = t8
                        End Select
                    End If

                Next
                TablaReporteConcentrado.Rows.Add(rowc)
            Next

            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_CONTRAFUERTE_POR_PROVEEDOR")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
#End Region

#Region "METODOS CONTROLES"

    ''' <summary>
    ''' Metodo prar generar Tarjeta de producción
    ''' </summary>
    ''' <param name="L"></param> Lote
    ''' <param name="N"></param> Nave
    ''' <remarks></remarks>
    Public Sub reporteTarjetaDeProduccion(ByVal L As Integer, ByVal N As Integer)
        Dim obj As New ReportesBU
        Dim encabezado As New DataTable
        Dim numeracion As New DataTable
        Dim tabla As New DataTable
        Dim tablaPe As New DataTable
        Dim tablaDcm As New DataTable
        Dim ds As New DataSet
        Dim nave As String = ""
        Dim lote As String = ""
        Dim año As String = ""
        Dim dcm As Double = 0
        Dim tiempo As Double = 0
        Dim costo As Double = 0
        Dim productoEstilo As Integer = 0
        Dim añolote As Integer

        añolote = Year(dtpPrograma.Value)
        numeracion = obj.ReporteTarjetaProduccionNumeracion(L, N, añolote)
        tabla = obj.ReporteTarjetaProduccionFracciones(L, N, añolote)
        tablaPe = obj.ReporteTarjetaProduccionProductoEstilo(L, N, añolote)
        productoEstilo = tablaPe.Rows(0).Item(0)
        encabezado = obj.ReporteTarjetaProduccionEncabezado(L, N, añolote, productoEstilo)
        tablaDcm = obj.ReporteTarjetaProduccionTotalDCMComponentePiel(productoEstilo, N)
        dcm = tablaDcm.Rows(0).Item(0)

        For value = 0 To tabla.Rows.Count - 1
            costo = costo + tabla.Rows(value).Item("precio")
            tiempo = tiempo + tabla.Rows(value).Item("tiempo")
        Next

        Dim tabla1 = New DataTable
        tabla1.Clear()
        tabla1.Columns.Add("costo")
        tabla1.Columns.Add("tiempo")
        tabla1.Columns.Add("fraccion")
        tabla1.Columns.Add("codigo")
        tabla1.Columns.Add("numerocodigo")
        tabla1.Columns.Add("maquina")

        tabla1.Columns.Add("costo2")
        tabla1.Columns.Add("tiempo2")
        tabla1.Columns.Add("fraccion2")
        tabla1.Columns.Add("codigo2")
        tabla1.Columns.Add("numerocodigo2")
        tabla1.Columns.Add("maquina2")

        tabla1.Columns.Add("costo3")
        tabla1.Columns.Add("tiempo3")
        tabla1.Columns.Add("fraccion3")
        tabla1.Columns.Add("codigo3")
        tabla1.Columns.Add("numerocodigo3")
        tabla1.Columns.Add("maquina3")

        tabla1.Columns.Add("costo4")
        tabla1.Columns.Add("tiempo4")
        tabla1.Columns.Add("fraccion4")
        tabla1.Columns.Add("codigo4")
        tabla1.Columns.Add("numerocodigo4")
        tabla1.Columns.Add("maquina4")

        tabla1.Columns.Add("costo5")
        tabla1.Columns.Add("tiempo5")
        tabla1.Columns.Add("fraccion5")
        tabla1.Columns.Add("codigo5")
        tabla1.Columns.Add("numerocodigo5")
        tabla1.Columns.Add("maquina5")

        tabla1.Columns.Add("costo6")
        tabla1.Columns.Add("tiempo6")
        tabla1.Columns.Add("fraccion6")
        tabla1.Columns.Add("codigo6")
        tabla1.Columns.Add("numerocodigo6")
        tabla1.Columns.Add("maquina6")

        tabla1.Columns.Add("costo7")
        tabla1.Columns.Add("tiempo7")
        tabla1.Columns.Add("fraccion7")
        tabla1.Columns.Add("codigo7")
        tabla1.Columns.Add("numerocodigo7")
        tabla1.Columns.Add("maquina7")

        '*********************************************************************************************************************
        '' Dar formato a la fecha
        Try
            Dim dateValue As Date = encabezado.Rows(0).Item("programa").ToString
            Dim DAY = dateValue.DayOfWeek()
            Dim NUMEROMES = dateValue.Month()
            Dim dia As String = ""
            Dim mes As String = ""
            Dim fechaDias As String = ""
            Select Case DAY
                Case 1
                    dia = "Lunes"
                Case 2
                    dia = "Martes"
                Case 3
                    dia = "Miercoles"
                Case 4
                    dia = "Jueves"
                Case 5
                    dia = "Viernes"
                Case 6
                    dia = "Sabado"
            End Select

            Select Case NUMEROMES
                Case 1
                    mes = "Enero"
                Case 2
                    mes = "Febrero"
                Case 3
                    mes = "Marzo"
                Case 4
                    mes = "Abril"
                Case 5
                    mes = "Mayo"
                Case 6
                    mes = "Junio"
                Case 7
                    mes = "Julio"
                Case 8
                    mes = "Agosto"
                Case 9
                    mes = "Septiembre"
                Case 10
                    mes = "Octubre"
                Case 11
                    mes = "Noviembre"
                Case 12
                    mes = "Diciembre"
            End Select

            fechaDias = dia & ",  " & dateValue.ToString("dd") & "  " & mes & " de " & dateValue.ToString("yyyy")
            ''******************************************************************************************************************
            Dim codigo As String = ""
            Dim naves As String = ""

            'naves = cbxNave.SelectedValue
            naves = "01"

            Try

            Catch ex As Exception

            End Try
            año = DateTime.Today.Year.ToString.Trim.Replace("20", "")
            'año = encabezado.Rows(0).Item("año").ToString.Trim.Replace("20", "")

            If encabezado.Rows(0).Item("lote").ToString.Length = 1 Then
                lote = "0000" + encabezado.Rows(0).Item("lote").ToString
            ElseIf encabezado.Rows(0).Item("lote").ToString.Length = 2 Then
                lote = "000" + encabezado.Rows(0).Item("lote").ToString
            ElseIf encabezado.Rows(0).Item("lote").ToString.Length = 3 Then
                lote = "00" + encabezado.Rows(0).Item("lote").ToString
            ElseIf encabezado.Rows(0).Item("lote").ToString.Length = 4 Then
                lote = "0" + encabezado.Rows(0).Item("lote").ToString
            Else
                lote = encabezado.Rows(0).Item("lote").ToString
            End If

            If nave.Length = 1 Then
                nave = "0" + naves
            Else
                nave = naves
            End If

            codigo = nave.ToString + lote.ToString + año

            For value = 0 To 3
                Dim rowc1 As DataRow = tabla1.NewRow()
                Try
                    rowc1("costo") = tabla.Rows(value).Item("precio").ToString
                    rowc1("tiempo") = tabla.Rows(value).Item("tiempo1").ToString
                    rowc1("fraccion") = tabla.Rows(value).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value).Item("id").ToString
                    End If
                    rowc1("codigo") = codigo + "-" + idfraccion
                    rowc1("numerocodigo") = codigo + "-" + idfraccion
                    rowc1("maquina") = tabla.Rows(value).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo2") = tabla.Rows(value + 4).Item("precio").ToString
                    rowc1("tiempo2") = tabla.Rows(value + 4).Item("tiempo1").ToString
                    rowc1("fraccion2") = tabla.Rows(value + 4).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 4).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 4).Item("id").ToString
                    ElseIf tabla.Rows(value + 4).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 4).Item("id").ToString
                    ElseIf tabla.Rows(value + 4).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 4).Item("id").ToString
                    ElseIf tabla.Rows(value + 4).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 4).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 4).Item("id").ToString
                    End If
                    rowc1("codigo2") = codigo + "-" + idfraccion
                    rowc1("numerocodigo2") = codigo + "-" + idfraccion
                    rowc1("maquina2") = tabla.Rows(value + 4).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo3") = tabla.Rows(value + 8).Item("precio").ToString
                    rowc1("tiempo3") = tabla.Rows(value + 8).Item("tiempo1").ToString
                    rowc1("fraccion3") = tabla.Rows(value + 8).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 8).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 8).Item("id").ToString
                    ElseIf tabla.Rows(value + 8).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 8).Item("id").ToString
                    ElseIf tabla.Rows(value + 8).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 8).Item("id").ToString
                    ElseIf tabla.Rows(value + 8).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 8).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 8).Item("id").ToString
                    End If
                    rowc1("codigo3") = codigo + "-" + idfraccion
                    rowc1("numerocodigo3") = codigo + "-" + idfraccion
                    rowc1("maquina3") = tabla.Rows(value + 8).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo4") = tabla.Rows(value + 12).Item("precio").ToString
                    rowc1("tiempo4") = tabla.Rows(value + 12).Item("tiempo1").ToString
                    rowc1("fraccion4") = tabla.Rows(value + 12).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 12).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 12).Item("id").ToString
                    ElseIf tabla.Rows(value + 12).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 12).Item("id").ToString
                    ElseIf tabla.Rows(value + 12).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 12).Item("id").ToString
                    ElseIf tabla.Rows(value + 12).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 12).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 12).Item("id").ToString
                    End If
                    rowc1("codigo4") = codigo + "-" + idfraccion
                    rowc1("numerocodigo4") = codigo + "-" + idfraccion
                    rowc1("maquina4") = tabla.Rows(value + 12).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo5") = tabla.Rows(value + 16).Item("precio").ToString
                    rowc1("tiempo5") = tabla.Rows(value + 16).Item("tiempo1").ToString
                    rowc1("fraccion5") = tabla.Rows(value + 16).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 16).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 16).Item("id").ToString
                    ElseIf tabla.Rows(value + 16).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 16).Item("id").ToString
                    ElseIf tabla.Rows(value + 16).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 16).Item("id").ToString
                    ElseIf tabla.Rows(value + 16).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 16).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 16).Item("id").ToString
                    End If
                    rowc1("codigo5") = codigo + "-" + idfraccion
                    rowc1("numerocodigo5") = codigo + "-" + idfraccion
                    rowc1("maquina5") = tabla.Rows(value + 16).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo6") = tabla.Rows(value + 20).Item("precio").ToString
                    rowc1("tiempo6") = tabla.Rows(value + 20).Item("tiempo1").ToString
                    rowc1("fraccion6") = tabla.Rows(value + 20).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 20).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 20).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 20).Item("id").ToString
                    End If
                    rowc1("codigo6") = codigo + "-" + idfraccion
                    rowc1("numerocodigo6") = codigo + "-" + idfraccion
                    rowc1("maquina6") = tabla.Rows(value + 20).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo7") = tabla.Rows(value + 24).Item("precio").ToString
                    rowc1("tiempo7") = tabla.Rows(value + 24).Item("tiempo1").ToString
                    rowc1("fraccion7") = tabla.Rows(value + 24).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 24).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 24).Item("id").ToString
                    ElseIf tabla.Rows(value + 24).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 24).Item("id").ToString
                    ElseIf tabla.Rows(value + 24).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 24).Item("id").ToString
                    ElseIf tabla.Rows(value + 24).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 24).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 24).Item("id").ToString
                    End If
                    rowc1("codigo7") = codigo + "-" + idfraccion
                    rowc1("numerocodigo7") = codigo + "-" + idfraccion
                    rowc1("maquina7") = tabla.Rows(value + 24).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                tabla1.Rows.Add(rowc1)
            Next

            ds.Tables.Add(encabezado)
            ds.Tables.Add(numeracion)
            Try
                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_TRJETA_DE_PRODUCCION")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                'variables para el encabezado del reporte
                reporte("log") = Tools.Controles.ObtenerLogoNave(3)
                reporte("coleccion") = encabezado.Rows(0).Item("coleccion").ToString + " " + encabezado.Rows(0).Item("modelo").ToString
                reporte("programa") = fechaDias 'encabezado.Rows(0).Item("programa").ToString
                reporte("fecha") = dateValue.ToString
                reporte("lote") = encabezado.Rows(0).Item("lote").ToString
                reporte("corte") = encabezado.Rows(0).Item("corte").ToString
                reporte("horma") = encabezado.Rows(0).Item("horma").ToString
                reporte("suela") = encabezado.Rows(0).Item("suela").ToString
                reporte("corrida") = encabezado.Rows(0).Item("corrida").ToString
                reporte("cpiel") = "NICOLAS" 'encabezado.Rows(0).Item("cortador p").ToString
                reporte("dcm") = dcm.ToString
                reporte("cforro") = "JORGE" 'encabezado.Rows(0).Item("cortador f").ToString

                Dim tablaTiempoTotal As DataTable
                tablaTiempoTotal = obj.ReporteTarjetaProduccionTotalTiempoFracciones(tiempo)
                reporte("tiempo") = tablaTiempoTotal.Rows(0).Item(0)
                Dim y = Format(costo, "##,##00.000")
                reporte("costo") = y.ToString
                Dim code As String = nave.ToString + lote.ToString + año.ToString

                reporte("cliente") = encabezado.Rows(0).Item("cliente t").ToString
                'Dim imagen As String = "http://192.168.7.16/yuyinerp/Programacion/Modelos/" + encabezado.Rows(0).Item("imagen").ToString
                Dim imagen As String = "http://192.168.2.158/yuyinerp/" + encabezado.Rows(0).Item("imagen").ToString
                reporte("imagen") = imagen
                reporte("modelo") = encabezado.Rows(0).Item("modelo").ToString
                reporte("code") = code.ToString
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                'Variables para armar la numeración por corrida y los pares por cada una de las tallas
                reporte("n1") = numeracion.Rows(0).Item("1").ToString
                reporte("n2") = numeracion.Rows(0).Item("2").ToString
                reporte("n3") = numeracion.Rows(0).Item("3").ToString
                reporte("n4") = numeracion.Rows(0).Item("4").ToString
                reporte("n5") = numeracion.Rows(0).Item("5").ToString
                reporte("n6") = numeracion.Rows(0).Item("6").ToString
                reporte("n7") = numeracion.Rows(0).Item("7").ToString
                reporte("n8") = numeracion.Rows(0).Item("8").ToString
                reporte("n9") = numeracion.Rows(0).Item("9").ToString
                reporte("n10") = numeracion.Rows(0).Item("10").ToString
                reporte("n11") = numeracion.Rows(0).Item("11").ToString
                reporte("n12") = numeracion.Rows(0).Item("12").ToString
                reporte("n13") = numeracion.Rows(0).Item("13").ToString
                reporte("n14") = numeracion.Rows(0).Item("14").ToString
                reporte("n15") = numeracion.Rows(0).Item("15").ToString
                reporte("n16") = numeracion.Rows(0).Item("16").ToString
                reporte("t1") = numeracion.Rows(0).Item("t1").ToString
                reporte("t2") = numeracion.Rows(0).Item("t2").ToString
                reporte("t3") = numeracion.Rows(0).Item("t3").ToString
                reporte("t4") = numeracion.Rows(0).Item("t4").ToString
                reporte("t5") = numeracion.Rows(0).Item("t5").ToString
                reporte("t6") = numeracion.Rows(0).Item("t6").ToString
                reporte("t7") = numeracion.Rows(0).Item("t7").ToString
                reporte("t8") = numeracion.Rows(0).Item("t8").ToString
                reporte("t9") = numeracion.Rows(0).Item("t9").ToString
                reporte("t10") = numeracion.Rows(0).Item("t10").ToString
                reporte("t11") = numeracion.Rows(0).Item("t11").ToString
                reporte("t12") = numeracion.Rows(0).Item("t12").ToString
                reporte("t13") = numeracion.Rows(0).Item("t13").ToString
                reporte("t14") = numeracion.Rows(0).Item("t14").ToString
                reporte("t15") = numeracion.Rows(0).Item("t15").ToString
                reporte("t16") = numeracion.Rows(0).Item("t16").ToString
                'total de pares
                reporte("pares") = numeracion.Rows(0).Item("pares").ToString
                reporte.RegData(tabla1)

                '***Imprimir Reporte directamente sin mostrar previsualización
                Dim PrinterSettings As PrinterSettings = New PrinterSettings()
                PrinterSettings.Copies = 1
                reporte.Print(False, PrinterSettings)
                '************

                'reporte.Show()
                '*********************
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Public Sub reporteExplosionAplicaciones(ByVal pFecha As String, ByVal pIdNave As Integer)
        Dim tabla1 As New DataTable
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        tabla1 = obj.ObtenerExplosionAplicaciones(pFecha, pIdNave)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Dim listaLotes As New List(Of Integer)
            Dim Tabla = New DataTable

            Tabla = TablaExplosion(tabla1)

            grdReportes.DataSource = Tabla

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("LOTE").Width = 50
                .Columns("COLECCION").Width = 240
                .Columns("ESTILO").Width = 200
                .Columns("PARES").Width = 60
                .Columns("APLICACION1").Width = 325
                .Columns("CANTIDAD1").Width = 100
                .Columns("UNIDAD1").Width = 100
                .Columns("APLICACION2").Width = 325
                .Columns("CANTIDAD2").Width = 100
                .Columns("UNIDAD2").Width = 100
                .Columns("APLICACION3").Width = 325
                .Columns("CANTIDAD3").Width = 100
                .Columns("UNIDAD3").Width = 100


                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("COLECCION").CellAppearance.TextHAlign = HAlign.Left
                .Columns("ESTILO").CellAppearance.TextHAlign = HAlign.Left
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("APLICACION1").CellAppearance.TextHAlign = HAlign.Left
                .Columns("CANTIDAD1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("UNIDAD1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("APLICACION2").CellAppearance.TextHAlign = HAlign.Left
                .Columns("CANTIDAD2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("UNIDAD2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("APLICACION3").CellAppearance.TextHAlign = HAlign.Left
                .Columns("CANTIDAD3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("UNIDAD3").CellAppearance.TextHAlign = HAlign.Center

                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("COLECCION").CellActivation = Activation.NoEdit
                .Columns("ESTILO").CellActivation = Activation.NoEdit
                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("APLICACION1").CellActivation = Activation.NoEdit
                .Columns("CANTIDAD1").CellActivation = Activation.NoEdit
                .Columns("UNIDAD1").CellActivation = Activation.NoEdit
                .Columns("APLICACION2").CellActivation = Activation.NoEdit
                .Columns("CANTIDAD2").CellActivation = Activation.NoEdit
                .Columns("UNIDAD2").CellActivation = Activation.NoEdit
                .Columns("APLICACION3").CellActivation = Activation.NoEdit
                .Columns("CANTIDAD3").CellActivation = Activation.NoEdit
                .Columns("UNIDAD3").CellActivation = Activation.NoEdit

                .Columns("APLICACION1").Header.Caption = "APLICACIÓN 1"
                .Columns("APLICACION2").Header.Caption = "APLICACIÓN 2"
                .Columns("APLICACION3").Header.Caption = "APLICACIÓN 3"
                .Columns("CANTIDAD1").Header.Caption = "CANTIDAD 1"
                .Columns("CANTIDAD2").Header.Caption = "CANTIDAD 2"
                .Columns("CANTIDAD3").Header.Caption = "CANTIDAD 3"
                .Columns("UNIDAD1").Header.Caption = "UNIDAD 1"
                .Columns("UNIDAD2").Header.Caption = "UNIDAD 2"
                .Columns("UNIDAD3").Header.Caption = "UNIDAD 3"



            End With

            pnlReportesPieles.Visible = False
            pnlReportesGenerales.Visible = True


            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Text <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                End If
            Next

            Dim vLotes = (From x In Tabla
                          Select x.Item("LOTE")).Distinct()

            lblLotesResultado.Text = vLotes.Count()
            lblParesResultado.Text = Format(pares, "##,##0")

        End If
    End Sub

    Private Function TablaExplosion(pTabla As DataTable) As DataTable
        Dim Tabla = New DataTable
        Tabla.Clear()
        Tabla.Columns.Add("LOTE")
        Tabla.Columns.Add("COLECCION")
        Tabla.Columns.Add("ESTILO")
        Tabla.Columns.Add("PARES")
        Tabla.Columns.Add("APLICACION1")
        Tabla.Columns.Add("CANTIDAD1")
        Tabla.Columns.Add("UNIDAD1")
        Tabla.Columns.Add("APLICACION2")
        Tabla.Columns.Add("CANTIDAD2")
        Tabla.Columns.Add("UNIDAD2")
        Tabla.Columns.Add("APLICACION3")
        Tabla.Columns.Add("CANTIDAD3")
        Tabla.Columns.Add("UNIDAD3")

        For value = 0 To pTabla.Rows.Count - 1
            Dim row As DataRow = Tabla.NewRow()
            Dim contador = 0
            row("LOTE") = pTabla.Rows(value).Item("LOTE")
            row("COLECCION") = pTabla.Rows(value).Item("COLECCION")
            row("ESTILO") = pTabla.Rows(value).Item("ESTILO")
            row("PARES") = pTabla.Rows(value).Item("PARES")
            row("APLICACION1") = pTabla.Rows(value).Item("1")
            row("CANTIDAD1") = pTabla.Rows(value).Item("CANTIDAD 1")
            row("UNIDAD1") = pTabla.Rows(value).Item("UNIDAD 1")

            If pTabla.Columns.Count = 10 Then
                row("APLICACION2") = pTabla.Rows(value).Item("2")
                row("CANTIDAD2") = pTabla.Rows(value).Item("CANTIDAD 2")
                row("UNIDAD2") = pTabla.Rows(value).Item("UNIDAD 2")
            End If
            If pTabla.Columns.Count > 12 Then
                row("APLICACION2") = pTabla.Rows(value).Item("2")
                row("CANTIDAD2") = pTabla.Rows(value).Item("CANTIDAD 2")
                row("UNIDAD2") = pTabla.Rows(value).Item("UNIDAD 2")
                row("APLICACION3") = pTabla.Rows(value).Item("3")
                row("CANTIDAD3") = pTabla.Rows(value).Item("CANTIDAD 3")
                row("UNIDAD3") = pTabla.Rows(value).Item("UNIDAD 3")

            End If
            Tabla.Rows.Add(row)
        Next

        Return Tabla

    End Function

    Public Sub ImprimirReporteExplosionAplicaciones(ByVal pFecha As String, ByVal pIdNave As Integer)

        Dim tabla1 As New DataTable
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        tabla1 = obj.ObtenerExplosionAplicaciones(pFecha, pIdNave)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Dim listaLotes As New List(Of Integer)
            Dim Tabla = New DataTable
            Tabla = TablaExplosion(tabla1)

            Dim OBJReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_EXPLOSION_APLICACIONES")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            'Dim ruta As String
            reporte.Load(archivo)
            reporte.Compile()
            reporte("log") = GetRutaLogoPorNave(pIdNave)
            reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
            reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte.RegData(Tabla)
            reporte.Show()

        End If

    End Sub

    Private Sub btnArticulosPorAutorizar_Click(sender As Object, e As EventArgs) Handles btnArticulosPorAutorizar.Click


        Dim objBU As New Negocios.ReportesBU()
        Dim dtMensajeResultado As New DataTable()
        Dim tipoMensaje As String = String.Empty
        Dim textoMensaje As String = String.Empty

        MostrarEspere(Me)

        If cbxNave.SelectedValue = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "Seleccione una nave")
        Else

            Try
                dtMensajeResultado = objBU.ConsultaArticulosNoAutorizados(cbxNave.SelectedValue, dtpPrograma.Value.ToShortDateString)
                tipoMensaje = dtMensajeResultado.Rows(0).Item("TipoMensaje")
                textoMensaje = dtMensajeResultado.Rows(0).Item("TextoMensaje")
                MostrarMensaje(If(tipoMensaje = "Exito", Tools.Mensajes.Success, (If(tipoMensaje = "Alerta", Tools.Mensajes.Warning, (If(tipoMensaje = "Error", Tools.Mensajes.Fault, Tools.Mensajes.Notice))))), textoMensaje)
            Catch ex As Exception
                MostrarMensaje(Mensajes.Fault, ex.Message)
            Finally
                TerminarEspere(Me)
            End Try

        End If
        TerminarEspere(Me)
    End Sub

    Private Sub ConcentradoCortePielForro(ByVal pFecha As Date, ByVal pNaveId As Integer, ByVal pSintetico As Boolean)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0
        Dim tablaConcentrado = New DataTable

        Try
            Me.Cursor = Cursors.WaitCursor
            If pSintetico = True Then
                tablaConcentrado = obj.ObtenerConcentradoCortePielForroSintetico(pFecha, pNaveId)
            Else
                tablaConcentrado = obj.ObtenerConcentradoCortePielForro(pFecha, pNaveId)
            End If
            If tablaConcentrado.Rows.Count() > 0 Then
                grdReportes.DataSource = tablaConcentrado
                DiseñoGridConcentradoPielForro(pSintetico)
            Else
                objAdvertencia.mensaje = "No hay información para mostrar"
                objAdvertencia.ShowDialog()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            objErrores.mensaje = ex.Message
            objErrores.ShowDialog()
        End Try


    End Sub
    Private Sub DiseñoGridConcentradoPielForro(ByVal pSintetico As Boolean)
        With grdReportes.DisplayLayout.Bands(0)
            .Columns("material").Width = 500
            .Columns("proveedor").Width = 500
            .Columns("Concentrado").Width = 200
            .Columns("Unidad").Width = 325
            .Columns("Corta").Width = 500
            .Columns("ConcentradoML").Width = 60

            .Columns("material").CellAppearance.TextHAlign = HAlign.Left
            .Columns("proveedor").CellAppearance.TextHAlign = HAlign.Left
            .Columns("Concentrado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ConcentradoML").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Unidad").CellAppearance.TextHAlign = HAlign.Center
            .Columns("Corta").CellAppearance.TextHAlign = HAlign.Left

            .Columns("proveedor").CellActivation = Activation.NoEdit
            .Columns("material").CellActivation = Activation.NoEdit
            .Columns("Concentrado").CellActivation = Activation.NoEdit
            .Columns("ConcentradoML").CellActivation = Activation.NoEdit
            .Columns("Corta").CellActivation = Activation.NoEdit

            .Columns("Unidad").CellActivation = Activation.NoEdit
            .Columns("proveedor").Header.Caption = "PROVEEDOR"
            .Columns("material").Header.Caption = "MATERIAL"
            .Columns("Concentrado").Header.Caption = "CONCENTRADO"
            .Columns("Corta").Header.Caption = "CORTADOR"
            .Columns("Unidad").Header.Caption = "UNIDAD"
            .Columns("ConcentradoML").Hidden = True
            If pSintetico = True Then
                .Columns("Concentrado").Format = "##,##0.0"
            Else
                .Columns("Concentrado").Format = "##,##0"
            End If

            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        End With
    End Sub

    Private Sub ImprimirConcentradoCortePielForro(ByVal pFecha As Date, ByVal pNaveId As Integer, ByRef pSintetico As Boolean)
        Dim obj As New ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim tablaConcentrado = New DataTable
        Dim tablaCortadores = New DataTable
        Dim dsTablaCortadores As New DataSet("DSTablaCortadores")
        tablaCortadores.Columns.Add("Cortadoress")

        Me.Cursor = Cursors.WaitCursor

        If pSintetico = False Then
            tablaConcentrado = obj.ObtenerConcentradoCortePielForro(pFecha, pNaveId)
            EntidadReporte = objReporte.LeerReporteporClave("CONCENTRADO_CORTE_PIEL_FORRO")
        Else
            tablaConcentrado = obj.ObtenerConcentradoCortePielForroSintetico(pFecha, pNaveId)
            EntidadReporte = objReporte.LeerReporteporClave("CONCENTRADO_CORTE_PIEL_FORRO_SINTETICO")
        End If

        If tablaConcentrado.Rows.Count > 0 Then
            Dim Cortadores = (From row In tablaConcentrado Select row.Field(Of String)("Corta")).Distinct()

            For Each x In Cortadores
                tablaCortadores.Rows.Add(x)
            Next
        End If

        If tablaConcentrado.Rows.Count > 0 Then
            tablaCortadores.TableName = "tablaCortadores"
            tablaConcentrado.TableName = "tablaProveedorMaterial"
            dsTablaCortadores.Tables.Add(tablaCortadores)
            dsTablaCortadores.Tables.Add(tablaConcentrado)
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte.Dictionary.Clear()
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("fecha") = GetFormatoFechaPrograma()
            reporte("log") = Tools.Controles.ObtenerLogoNave(pNaveId)
            reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
            reporte.RegData(dsTablaCortadores)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        Else
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnActualizarLotes_Click(sender As Object, e As EventArgs) Handles btnActualizarLotes.Click
        Dim objBU As New Negocios.ReportesBU
        Dim dtResultadoReplica As New DataTable
        Dim fecha As String = String.Empty
        Dim nave As Integer = 0
        Dim resultadoReplica As String = String.Empty
        Dim mensajeReplica As String = String.Empty
        Dim errorReplica As String = String.Empty


        fecha = dtpPrograma.Value.ToShortDateString
        nave = cbxNave.SelectedValue

        'If nave = 0 Then

        'Tools.MostrarMensaje(Tools.Mensajes.Warning, "Seleccione una nave")

        'Else

        objConfirmacion.mensaje = "Se actualizarán los lotes de todas las naves. El proceso puede tardar algunos segundos, ¿Desea continuar?"
        If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            dtResultadoReplica = objBU.ActualizaLotes_SICY_a_SAY(nave, fecha, fecha)
            resultadoReplica = dtResultadoReplica.Rows(0).Item("Resultado").ToString
            mensajeReplica = dtResultadoReplica.Rows(0).Item("Mensaje").ToString
            errorReplica = dtResultadoReplica.Rows(0).Item("Error").ToString

            If resultadoReplica = "Exito" Then
                objExito.mensaje = mensajeReplica
                objExito.ShowDialog()
            ElseIf resultadoReplica = "Error" Then
                objErrores.mensaje = mensajeReplica
                If errorReplica <> "" Then
                    objErrores.mensaje += "  - " + errorReplica
                End If
                objErrores.ShowDialog()
            End If
            objErrores.ShowDialog()
        End If

        ''End If

        Cursor = Cursors.Default

    End Sub





#End Region


    Public Sub ImprimirOrdenDeProduccionFacturadoRemisionado(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable

        tabla1 = obj.ReporteOrdenesDeProduccion_FacturadoYRemisionadoPorTipo(fecha, nave, "S")
        tabla2 = obj.ReporteOrdenesDeProduccion_FacturadoYRemisionadoPorTipo(fecha, nave, "P")

        If tabla1.Rows.Count = 0 And tabla2.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            'Concatenar Cortador1 con cortador2
            tabla1.TableName = "tablaOrdenesdeProduccion"
            tabla2.TableName = "tablaOrdenesdeProduccionPreventa"
            '********************************Creación de reporte
            Try
                If tabla1.Rows.Count = 0 And tabla2.Rows.Count = 0 Then
                Else
                    ''**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("ORDEN_DE_PRODUCCION_FACTURAREMISION")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(tabla1)
                    reporte.RegData(tabla2)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub DesglosadoMaquila(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU
        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Buscar id clasificación de suela
        listaComponentes.Clear()

        tabla1 = obj.ConsultaOrdenDePedidoDesglosadoParaMaquila(fecha, nave)
        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("No")
        TablaReporteConcentrado.Columns.Add("PARES")
        TablaReporteConcentrado.Columns.Add("LOTE")
        TablaReporteConcentrado.Columns.Add("COLECCIÓN")
        TablaReporteConcentrado.Columns.Add("MODELO")
        TablaReporteConcentrado.Columns.Add("CORRIDA")
        TablaReporteConcentrado.Columns.Add("COLOR")
        TablaReporteConcentrado.Columns.Add("MATERIAL")
        TablaReporteConcentrado.Columns.Add("PROVEEDOR")
        TablaReporteConcentrado.Columns.Add("tl1")
        TablaReporteConcentrado.Columns.Add("tl2")
        TablaReporteConcentrado.Columns.Add("tl3")
        TablaReporteConcentrado.Columns.Add("tl4")
        TablaReporteConcentrado.Columns.Add("tl5")
        TablaReporteConcentrado.Columns.Add("tl6")
        TablaReporteConcentrado.Columns.Add("tl7")
        TablaReporteConcentrado.Columns.Add("tl8")
        TablaReporteConcentrado.Columns.Add("tl9")
        TablaReporteConcentrado.Columns.Add("tl10")
        TablaReporteConcentrado.Columns.Add("tl11")
        TablaReporteConcentrado.Columns.Add("tl12")
        TablaReporteConcentrado.Columns.Add("tl13")
        TablaReporteConcentrado.Columns.Add("tl14")
        TablaReporteConcentrado.Columns.Add("tl15")
        TablaReporteConcentrado.Columns.Add("tl16")
        TablaReporteConcentrado.Columns.Add("tl17")
        TablaReporteConcentrado.Columns.Add("tl18")
        TablaReporteConcentrado.Columns.Add("tl19")
        TablaReporteConcentrado.Columns.Add("tl20")
        TablaReporteConcentrado.Columns.Add("t1")
        TablaReporteConcentrado.Columns.Add("t2")
        TablaReporteConcentrado.Columns.Add("t3")
        TablaReporteConcentrado.Columns.Add("t4")
        TablaReporteConcentrado.Columns.Add("t5")
        TablaReporteConcentrado.Columns.Add("t6")
        TablaReporteConcentrado.Columns.Add("t7")
        TablaReporteConcentrado.Columns.Add("t8")
        TablaReporteConcentrado.Columns.Add("t9")
        TablaReporteConcentrado.Columns.Add("t10")
        TablaReporteConcentrado.Columns.Add("t11")
        TablaReporteConcentrado.Columns.Add("t12")
        TablaReporteConcentrado.Columns.Add("t13")
        TablaReporteConcentrado.Columns.Add("t14")
        TablaReporteConcentrado.Columns.Add("t15")
        TablaReporteConcentrado.Columns.Add("t16")
        TablaReporteConcentrado.Columns.Add("t17")
        TablaReporteConcentrado.Columns.Add("t18")
        TablaReporteConcentrado.Columns.Add("t19")
        TablaReporteConcentrado.Columns.Add("t20")

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("No") = tabla1.Rows(value).Item("No")
            row("PARES") = tabla1.Rows(value).Item("Pares")
            row("LOTE") = tabla1.Rows(value).Item("Lote")
            row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
            row("MODELO") = tabla1.Rows(value).Item("Modelo")
            row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
            row("COLOR") = tabla1.Rows(value).Item("Color")
            row("MATERIAL") = tabla1.Rows(value).Item("Material")
            row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")

            For value2 = 8 To 26
                If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2) = tabla1.Rows(value).Item(value2)
                    Dim X = value2 + 20
                    row(X) = tabla1.Rows(value).Item(value2 + 20)
                End If
            Next
            TablaReporteConcentrado.Rows.Add(row)
        Next
        Dim tabla = New DataTable
        tabla.Clear()
        tabla.Columns.Add("No")
        tabla.Columns.Add("PARES")
        tabla.Columns.Add("LOTE")
        tabla.Columns.Add("COLECCIÓN")
        tabla.Columns.Add("MODELO")
        tabla.Columns.Add("CORRIDA")
        tabla.Columns.Add("COLOR")
        tabla.Columns.Add("MATERIAL")
        tabla.Columns.Add("PROVEEDOR")
        tabla.Columns.Add("1")
        tabla.Columns.Add("2")
        tabla.Columns.Add("3")
        tabla.Columns.Add("4")
        tabla.Columns.Add("5")
        tabla.Columns.Add("6")
        tabla.Columns.Add("7")
        tabla.Columns.Add("8")
        tabla.Columns.Add("9")
        tabla.Columns.Add("10")
        tabla.Columns.Add("11")
        tabla.Columns.Add("12")
        tabla.Columns.Add("13")
        tabla.Columns.Add("14")
        tabla.Columns.Add("15")
        tabla.Columns.Add("16")
        tabla.Columns.Add("17")
        tabla.Columns.Add("18")
        tabla.Columns.Add("19")
        tabla.Columns.Add("20")

        For value = 0 To TablaReporteConcentrado.Rows.Count - 1
            Dim row As DataRow = tabla.NewRow()
            row("No") = TablaReporteConcentrado.Rows(value).Item("No")
            row("PARES") = TablaReporteConcentrado.Rows(value).Item("PARES")
            row("LOTE") = TablaReporteConcentrado.Rows(value).Item("LOTE")
            row("COLECCIÓN") = TablaReporteConcentrado.Rows(value).Item("COLECCIÓN")
            row("MODELO") = TablaReporteConcentrado.Rows(value).Item("MODELO")
            row("CORRIDA") = TablaReporteConcentrado.Rows(value).Item("CORRIDA")
            row("COLOR") = TablaReporteConcentrado.Rows(value).Item("COLOR")
            row("MATERIAL") = TablaReporteConcentrado.Rows(value).Item("MATERIAL")
            row("PROVEEDOR") = TablaReporteConcentrado.Rows(value).Item("PROVEEDOR")
            For value2 = 8 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                    row(value2) = TablaReporteConcentrado.Rows(value).Item(value2)
                End If
            Next
            tabla.Rows.Add(row)

            Dim row2 As DataRow = tabla.NewRow()
            row2("PARES") = ""
            row2("LOTE") = ""
            row2("COLECCIÓN") = ""
            row2("MODELO") = ""
            row2("CORRIDA") = ""
            row2("COLOR") = ""
            row2("MATERIAL") = ""
            Dim NUM = 8
            For value2 = 8 To 26
                If TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "" Then 'And TablaReporteConcentrado.Rows(value).Item(value2).ToString <> "0"
                    row2(NUM) = TablaReporteConcentrado.Rows(value).Item(value2 + 20)
                    NUM = NUM + 1
                End If
            Next
            tabla.Rows.Add(row2)
        Next
        '******************************** Mostrar reporte Grid
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            grdReportes.DataSource = tabla

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("No").Hidden = True
                '.Columns("Proveedor").Hidden = True
                .Columns("PARES").Width = 60
                .Columns("LOTE").Width = 50
                .Columns("COLECCIÓN").Width = 200
                .Columns("MODELO").Width = 50
                .Columns("CORRIDA").Width = 75
                .Columns("COLOR").Width = 200
                .Columns("MATERIAL").Width = 200
                .Columns("PROVEEDOR").Width = 150
                .Columns("1").Width = 40
                .Columns("2").Width = 40
                .Columns("3").Width = 40
                .Columns("4").Width = 40
                .Columns("5").Width = 40
                .Columns("6").Width = 40
                .Columns("7").Width = 40
                .Columns("8").Width = 40
                .Columns("9").Width = 40
                .Columns("10").Width = 40
                .Columns("11").Width = 40
                .Columns("12").Width = 40
                .Columns("13").Width = 40
                .Columns("14").Width = 40
                .Columns("15").Width = 40
                .Columns("16").Width = 40
                .Columns("17").Width = 40
                .Columns("18").Width = 40
                .Columns("19").Width = 40
                .Columns("20").Width = 40

                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("LOTE").CellAppearance.TextHAlign = HAlign.Center
                .Columns("CORRIDA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PROVEEDOR").CellAppearance.TextHAlign = HAlign.Center
                .Columns("1").CellAppearance.TextHAlign = HAlign.Center
                .Columns("2").CellAppearance.TextHAlign = HAlign.Center
                .Columns("3").CellAppearance.TextHAlign = HAlign.Center
                .Columns("4").CellAppearance.TextHAlign = HAlign.Center
                .Columns("5").CellAppearance.TextHAlign = HAlign.Center
                .Columns("6").CellAppearance.TextHAlign = HAlign.Center
                .Columns("7").CellAppearance.TextHAlign = HAlign.Center
                .Columns("8").CellAppearance.TextHAlign = HAlign.Center
                .Columns("9").CellAppearance.TextHAlign = HAlign.Center
                .Columns("10").CellAppearance.TextHAlign = HAlign.Center
                .Columns("11").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center

                .Columns("PARES").CellActivation = Activation.NoEdit
                .Columns("LOTE").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("MODELO").CellActivation = Activation.NoEdit
                .Columns("CORRIDA").CellActivation = Activation.NoEdit
                .Columns("COLOR").CellActivation = Activation.NoEdit
                .Columns("MATERIAL").CellActivation = Activation.NoEdit
                .Columns("PROVEEDOR").CellActivation = Activation.NoEdit
                .Columns("1").CellActivation = Activation.NoEdit
                .Columns("2").CellActivation = Activation.NoEdit
                .Columns("3").CellActivation = Activation.NoEdit
                .Columns("4").CellActivation = Activation.NoEdit
                .Columns("5").CellActivation = Activation.NoEdit
                .Columns("6").CellActivation = Activation.NoEdit
                .Columns("7").CellActivation = Activation.NoEdit
                .Columns("8").CellActivation = Activation.NoEdit
                .Columns("9").CellActivation = Activation.NoEdit
                .Columns("10").CellActivation = Activation.NoEdit
                .Columns("11").CellActivation = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit

                .Columns("PARES").Header.Caption = "PARES"
                .Columns("LOTE").Header.Caption = "LOTE"
                .Columns("COLECCIÓN").Header.Caption = "COLECCIÓN"
                .Columns("MODELO").Header.Caption = "MODELO"
                .Columns("CORRIDA").Header.Caption = "CORRIDA"
                .Columns("COLOR").Header.Caption = "COLOR"
                .Columns("MATERIAL").Header.Caption = "MATERIAL"
                .Columns("1").Header.Caption = ""
                .Columns("2").Header.Caption = ""
                .Columns("3").Header.Caption = ""
                .Columns("4").Header.Caption = ""
                .Columns("5").Header.Caption = ""
                .Columns("6").Header.Caption = ""
                .Columns("7").Header.Caption = ""
                .Columns("8").Header.Caption = ""
                .Columns("9").Header.Caption = ""
                .Columns("10").Header.Caption = ""
                .Columns("11").Header.Caption = ""
                .Columns("12").Header.Caption = ""
                .Columns("13").Header.Caption = ""
                .Columns("14").Header.Caption = ""
                .Columns("15").Header.Caption = ""
                .Columns("16").Header.Caption = ""
                .Columns("17").Header.Caption = ""
                .Columns("18").Header.Caption = ""
                .Columns("19").Header.Caption = ""
                .Columns("20").Header.Caption = ""

                'For value = 0 To grdReportes.Rows.Count - 1
                '    For value2 = 6 To 21
                '        If grdReportes.Rows(value).Cells(value2).Text = "" Then
                '            .Columns(value2).Hidden = True
                '        Else
                '            .Columns(value).Hidden = False
                '        End If
                '    Next
                'Next

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            For value = 0 To grdReportes.Rows.Count - 1
                If grdReportes.Rows(value).Cells("Pares").Value <> "" Then
                    pares = pares + grdReportes.Rows(value).Cells("Pares").Value
                    lotes = lotes + 1
                End If
            Next

            lblLotesResultado.Text = lotes
            lblParesResultado.Text = Format(pares, "##,##0")

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        If grdReportes.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Public Sub ImprimirDesglosadoMaquila(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        listaComponentes.Clear()

        tabla1 = obj.ConsultaOrdenDePedidoDesglosadoParaMaquila(fecha, nave)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
        Else
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lote")
            TablaReporteConcentrado.Columns.Add("Coleccion")
            TablaReporteConcentrado.Columns.Add("Modelo")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Color")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("tl1")
            TablaReporteConcentrado.Columns.Add("tl2")
            TablaReporteConcentrado.Columns.Add("tl3")
            TablaReporteConcentrado.Columns.Add("tl4")
            TablaReporteConcentrado.Columns.Add("tl5")
            TablaReporteConcentrado.Columns.Add("tl6")
            TablaReporteConcentrado.Columns.Add("tl7")
            TablaReporteConcentrado.Columns.Add("tl8")
            TablaReporteConcentrado.Columns.Add("tl9")
            TablaReporteConcentrado.Columns.Add("tl10")
            TablaReporteConcentrado.Columns.Add("tl11")
            TablaReporteConcentrado.Columns.Add("tl12")
            TablaReporteConcentrado.Columns.Add("tl13")
            TablaReporteConcentrado.Columns.Add("tl14")
            TablaReporteConcentrado.Columns.Add("tl15")
            TablaReporteConcentrado.Columns.Add("tl16")
            TablaReporteConcentrado.Columns.Add("tl17")
            TablaReporteConcentrado.Columns.Add("tl18")
            TablaReporteConcentrado.Columns.Add("tl19")
            TablaReporteConcentrado.Columns.Add("tl20")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")
            TablaReporteConcentrado.Columns.Add("t9")
            TablaReporteConcentrado.Columns.Add("t10")
            TablaReporteConcentrado.Columns.Add("t11")
            TablaReporteConcentrado.Columns.Add("t12")
            TablaReporteConcentrado.Columns.Add("t13")
            TablaReporteConcentrado.Columns.Add("t14")
            TablaReporteConcentrado.Columns.Add("t15")
            TablaReporteConcentrado.Columns.Add("t16")
            TablaReporteConcentrado.Columns.Add("t17")
            TablaReporteConcentrado.Columns.Add("t18")
            TablaReporteConcentrado.Columns.Add("t19")
            TablaReporteConcentrado.Columns.Add("t20")


            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = TablaReporteConcentrado.NewRow()
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Coleccion") = tabla1.Rows(value).Item("Coleccion")
                row("Modelo") = tabla1.Rows(value).Item("Modelo")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                row("Color") = tabla1.Rows(value).Item("Color")
                row("Material") = tabla1.Rows(value).Item("Material")
                row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 8 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                TablaReporteConcentrado.Rows.Add(row)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("ORDEN_DE_PEDIDO_DESGLOSADO_PARA_MAQUILA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    'reporte("material") = "SUELA"
                    'reporte("tituloC5") = "COLECCIÓN"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnReporteGeneralSuelas_Click(sender As Object, e As EventArgs) Handles btnReporteGeneralSuelas.Click
        Dim forma As New ReporteGeneralSuelaForm
        forma.MdiParent = Me.MdiParent
        forma.Show()
    End Sub
End Class