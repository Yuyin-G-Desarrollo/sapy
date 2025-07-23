Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports System.IO
Imports System.Xml
Imports Ventas.Negocios
Public Class ImpresionReporteResumenClienteForm

    Public SessionID As Integer = 0
    Public TipoCalendario As Integer = 0
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Cursor = Cursors.WaitCursor
        GenerarReporteCliente(SessionID, cmbCliente.SelectedValue, TipoCalendario)
        Cursor = Cursors.Default
    End Sub

    Private Sub ImpresionReporteResumenClienteForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objBu As New ReporteResumenClienteBU
        cmbCliente.DataSource = objBu.ConsultarClientesImpresionReporte(SessionID)
        cmbCliente.DisplayMember = "Cliente"
        cmbCliente.ValueMember = "ClienteSayId"

    End Sub

    Public Function GenerarReporteCliente(ByVal SessionId As Integer, ByVal ClienteSAYID As Integer, ByVal TipoCalendario As Integer) As Boolean
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim objbu As New ReporteResumenClienteBU
        Dim NombreCliente As String = String.Empty
        Dim Fecha As String = String.Empty
        Dim Realizo As String = String.Empty
        Dim Columna1_Año As String = String.Empty
        Dim Columna2_Año As String = String.Empty
        Dim Columna3_Año As String = String.Empty
        Dim TextoColumnaComparativo As String = String.Empty
        Dim dsDatos As New DataSet("dsDatos")
        Dim ReporteHistoricoVenta As New StiReport
        Dim dtResultado As New DataTable("HistoricoVentaDetalle")
        Dim dtCumplimiento As New DataTable("Cumplimiento")
        Dim dtComparativo As New DataTable("Comparativo")
        Dim dtEncabezado As New DataTable

        Dim dtTiendaMAarcaje As DataTable
        Dim nomcliente As String = cmbCliente.Text
        dtTiendaMAarcaje = objbu.ConsultarTiendasMarcaje(nomcliente)
        Dim tiendas As Integer = 0
        Dim marcaje As Decimal = 0.0
        If dtTiendaMAarcaje.Rows.Count > 0 Then
            tiendas = dtTiendaMAarcaje.Rows(0).Item(0)
            marcaje = dtTiendaMAarcaje.Rows(0).Item(1)
        End If



        dtResultado = objbu.ConsultaHistoricoVentaCliente(SessionId, ClienteSAYID)
        dtResultado.TableName = "Venta"

        dtCumplimiento = objbu.CumplimientoVentaCliente(SessionId, ClienteSAYID)
        dtCumplimiento.TableName = "Cumplimiento"

        dtComparativo = objbu.ComparativoFamiliaCliente(SessionId, ClienteSAYID)
        dtComparativo.TableName = "Comparativo"

        dtEncabezado = objbu.EncabezadoReporte(SessionId, ClienteSAYID)

        NombreCliente = dtEncabezado.Rows(0).Item("Cliente")
        Fecha = dtEncabezado.Rows(0).Item("FechaRealizo")
        Columna1_Año = dtEncabezado.Rows(0).Item("AñoConsulta")
        Columna2_Año = dtEncabezado.Rows(0).Item("AñoMenos1")
        Columna3_Año = dtEncabezado.Rows(0).Item("AñoMenos2")
        Realizo = dtEncabezado.Rows(0).Item("Usuario")

        TextoColumnaComparativo = "CREC " + Columna1_Año + vbCrLf + " VS " + Columna2_Año

        dtComparativo.Columns(1).ColumnName = "FILA"
        dtComparativo.Columns(3).ColumnName = "C1PARES"
        dtComparativo.Columns(4).ColumnName = "C1ART"
        dtComparativo.Columns(5).ColumnName = "C2PARES"
        dtComparativo.Columns(6).ColumnName = "C2ART"
        dtComparativo.Columns(7).ColumnName = "C3PARES"
        dtComparativo.Columns(8).ColumnName = "C3ART"
        dtComparativo.Columns(11).ColumnName = "CREC"

        dsDatos.Tables.Add(dtResultado)
        dsDatos.Tables.Add(dtCumplimiento)
        dsDatos.Tables.Add(dtComparativo)
        If TipoCalendario = 0 Then
            entReporte = objReporte.LeerReporteporClave("RSM_CLIENTE_2")
        Else
            entReporte = objReporte.LeerReporteporClave("RSM_CLIENTE_CL2")
        End If

        '        entReporte = objReporte.LeerReporteporClave("RSM_CLIENTE")


        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


        ReporteHistoricoVenta.Load(archivo)
        ReporteHistoricoVenta.Compile()
        ' ReporteHistoricoVenta.RegData(dtResultado)
        ReporteHistoricoVenta.RegData(dsDatos)
        ReporteHistoricoVenta("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
        ReporteHistoricoVenta("Cliente") = NombreCliente
        ReporteHistoricoVenta("FECHA") = Fecha
        ReporteHistoricoVenta("Realizo") = Realizo
        ReporteHistoricoVenta("AñoConsulta") = Columna1_Año
        ReporteHistoricoVenta("AñoMenos1") = Columna2_Año
        '        ReporteHistoricoVenta("AñoMenos2") = Columna3_Año
        ReporteHistoricoVenta("AñoMenos2") = "2019"
        ReporteHistoricoVenta("TextoComparativo") = TextoColumnaComparativo
        ReporteHistoricoVenta("Tiendas") = tiendas
        ReporteHistoricoVenta("Marcaje") = marcaje

        ReporteHistoricoVenta.Dictionary.Clear()
        ReporteHistoricoVenta.Dictionary.Synchronize()
        ReporteHistoricoVenta.Render()
        ReporteHistoricoVenta.Show()

        Return True
    End Function


    Public Function GenerarReporteVariosClientes(ByVal SessionId As Integer, ByVal ListadoClientes As List(Of Integer)) As Boolean

        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim objbu As New ReporteResumenClienteBU
        Dim NombreCliente As String = String.Empty
        Dim Fecha As String = String.Empty
        Dim Realizo As String = String.Empty
        Dim Columna1_Año As String = String.Empty
        Dim Columna2_Año As String = String.Empty
        Dim Columna3_Año As String = String.Empty
        Dim TextoColumnaComparativo As String = String.Empty
        Dim JoinReport As StiReport = New StiReport
        JoinReport.NeedsCompiling = False
        JoinReport.IsRendered = True
        JoinReport.RenderedPages.Clear()


        For Each ClienteID As Integer In ListadoClientes

            Dim dsDatos As New DataSet("dsDatos")
            Dim ReporteResumenCliente As New StiReport
            Dim dtResultado As New DataTable("HistoricoVentaDetalle")
            Dim dtCumplimiento As New DataTable("Cumplimiento")
            Dim dtComparativo As New DataTable("Comparativo")
            Dim dtEncabezado As New DataTable

            dtResultado = objbu.ConsultaHistoricoVentaCliente(SessionId, ClienteID)
            dtResultado.TableName = "Venta"

            dtCumplimiento = objbu.CumplimientoVentaCliente(SessionId, ClienteID)
            dtCumplimiento.TableName = "Cumplimiento"

            dtComparativo = objbu.ComparativoFamiliaCliente(SessionId, ClienteID)
            dtComparativo.TableName = "Comparativo"

            dtEncabezado = objbu.EncabezadoReporte(SessionId, ClienteID)

            NombreCliente = dtEncabezado.Rows(0).Item("Cliente")
            Fecha = dtEncabezado.Rows(0).Item("FechaRealizo")
            Columna1_Año = dtEncabezado.Rows(0).Item("AñoConsulta")
            Columna2_Año = dtEncabezado.Rows(0).Item("AñoMenos1")
            Columna3_Año = dtEncabezado.Rows(0).Item("AñoMenos2")
            Realizo = dtEncabezado.Rows(0).Item("Usuario")


            dtComparativo.Columns(3).ColumnName = "FILA"
            dtComparativo.Columns(5).ColumnName = "C1PARES"
            dtComparativo.Columns(6).ColumnName = "C1ART"
            dtComparativo.Columns(7).ColumnName = "C2PARES"
            dtComparativo.Columns(8).ColumnName = "C2ART"
            dtComparativo.Columns(9).ColumnName = "C3PARES"
            dtComparativo.Columns(10).ColumnName = "C3ART"
            dtComparativo.Columns(13).ColumnName = "CREC"

            dsDatos.Tables.Add(dtResultado)
            dsDatos.Tables.Add(dtCumplimiento)
            dsDatos.Tables.Add(dtComparativo)

            entReporte = objReporte.LeerReporteporClave("RSM_CLIENTE")


            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReporteResumenCliente.Load(archivo)
            ReporteResumenCliente.Compile()
            ' ReporteHistoricoVenta.RegData(dtResultado)
            ReporteResumenCliente.RegData(dsDatos)
            ReporteResumenCliente("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
            ReporteResumenCliente("Cliente") = NombreCliente
            ReporteResumenCliente("FECHA") = Fecha
            ReporteResumenCliente("Realizo") = Realizo
            ReporteResumenCliente("AñoConsulta") = Columna1_Año
            ReporteResumenCliente("AñoMenos1") = Columna2_Año
            ReporteResumenCliente("AñoMenos2") = Columna3_Año
            ReporteResumenCliente("TextoComparativo") = TextoColumnaComparativo
            ReporteResumenCliente.Dictionary.Clear()
            ReporteResumenCliente.Dictionary.Synchronize()
            ReporteResumenCliente.Render()
            'ReporteHistoricoVenta.Show()

            For Each Page As Stimulsoft.Report.Components.StiPage In ReporteResumenCliente.CompiledReport.RenderedPages
                Page.Report = JoinReport
                Page.NewGuid()
                JoinReport.RenderedPages.Add(Page)
            Next

        Next


        JoinReport.Show()

        Return True


    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class