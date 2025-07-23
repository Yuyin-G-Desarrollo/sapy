Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports Tools
Imports Framework.Negocios
Imports Stimulsoft.Report

Public Class EstadosCuentaGeneracionManualForm

    Public Const CONSULTAR_TODOS As Integer = 0
    Public Const CONSULTAR_FACTURAS As Integer = 1
    Public Const CONSULTAR_REMISIONES As Integer = 2

    Dim terminaCargas As Boolean = False

    Private Sub EstadosCuentaGeneracionManualForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "Estados de Cuenta"
        CargaRazonesSociales()
        cargaClientes()
        cmbTipo.Text = "TODOS"
        terminaCargas = True
        CmbRFC.Enabled = False
    End Sub

    Private Sub CargaRazonesSociales()
        Dim objObtenerRazonSocial As New GeneracionEstadosCuentaBU
        Dim dtRazonesSociales As New DataTable
        dtRazonesSociales = objObtenerRazonSocial.obtenerRazonesSociales
        dtRazonesSociales.Rows.InsertAt(dtRazonesSociales.NewRow, 0)
        cmbRazonSocial.DataSource = dtRazonesSociales
        If dtRazonesSociales.Rows.Count > 1 Then
            cmbRazonSocial.ValueMember = "essc_contribuyentesicyid"
            cmbRazonSocial.DisplayMember = "essc_razonsocial"
        End If
        cmbRazonSocial.AutoCompleteMode = AutoCompleteMode.Suggest
        cmbRazonSocial.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Close()
    End Sub

    Private Sub cargaClientes()
        Dim tipo As Integer = 1
        Dim objObtenerClientes As New GeneracionEstadosCuentaBU
        Dim dtClientes As New DataTable
        dtClientes = objObtenerClientes.obtenerClientes
        CmbClientes.DataSource = dtClientes
        If dtClientes.Rows.Count > 1 Then
            CmbClientes.DisplayMember = "clie_nombregenerico"
            CmbClientes.ValueMember = "clie_idsicy"
        End If
        CmbClientes.AutoCompleteMode = AutoCompleteMode.Suggest
        CmbClientes.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiaFormulario()
    End Sub

    Private Sub LimpiaFormulario()
        cmbRazonSocial.SelectedIndex = 0
        CmbClientes.SelectedIndex = 0
        CmbRFC.Enabled = False

        rdoTodos.Checked = True
        rdoVencidosFechaAnalisis.Checked = False
        cmbTipo.Text = "TODOS"

    End Sub
    Private Sub CmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs)
        If terminaCargas Then
            consultarRFCCliente()
        End If
    End Sub
    Private Sub consultarRFCCliente()
        Dim objConsultaRFC As New GeneracionEstadosCuentaBU
        Dim dtRFC As New DataTable
        Dim idClienteSICY As Integer = 0

        idClienteSICY = CmbClientes.SelectedValue
        dtRFC = objConsultaRFC.obtenerRFCCliente(idClienteSICY)
        dtRFC.Rows.InsertAt(dtRFC.NewRow, 0)
        CmbRFC.DataSource = dtRFC

        If dtRFC.Rows.Count > 0 Then
            CmbRFC.DisplayMember = "Cliente"
            CmbRFC.ValueMember = "Cliente"
            CmbRFC.Enabled = True
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        CrearReporteEstadosdeCuenta()
    End Sub
    Private Sub CrearReporteEstadosdeCuenta()
        Dim objConsultarReporte As New GeneracionEstadosCuentaBU
        Dim fechaAnalisis As Date
        Dim razonSocialId As Integer = 0
        Dim clienteId As Integer = 0
        Dim tipoReporte As Integer = 0
        Dim todos As Boolean
        Dim vencidosAFecha As Boolean
        Dim dtConsultaReporte As New DataTable
        Dim dtCuentasDeposito As New DataTable
        Dim dtDatosCliente As New DataTable
        Dim tipoDocumento As String = String.Empty
        Try
            Me.Cursor = Cursors.WaitCursor
            If cmbRazonSocial.Text <> "" And CmbClientes.Text <> "" Then
                fechaAnalisis = dtfechaAnalisis.Value
                If Not IsDBNull(cmbRazonSocial.SelectedValue) Then
                    razonSocialId = cmbRazonSocial.SelectedValue
                Else
                    razonSocialId = 0
                End If
                clienteId = CmbClientes.SelectedValue
                todos = rdoTodos.Checked
                If rdoVencidosFechaAnalisis.Checked = True Then
                    vencidosAFecha = 1
                Else
                    vencidosAFecha = 0
                End If
                Select Case cmbTipo.Text
                    Case "TODOS"
                        tipoReporte = CONSULTAR_TODOS
                    Case "FACTURAS"
                        tipoReporte = CONSULTAR_FACTURAS
                        tipoDocumento = "F"
                    Case "REMISIONES"
                        tipoReporte = CONSULTAR_REMISIONES
                        tipoDocumento = "R"
                End Select

                dtConsultaReporte = objConsultarReporte.crearReporteEstadosCuenta(fechaAnalisis, razonSocialId, clienteId, todos, vencidosAFecha, tipoReporte, CmbRFC.Text)
                dtCuentasDeposito = objConsultarReporte.consultaCuentasDepositosCobranza(razonSocialId, tipoReporte)
                dtDatosCliente = objConsultarReporte.obtenerDatosClienteEstadosCuenta(clienteId, cmbRazonSocial.SelectedValue, tipoDocumento)

                If dtConsultaReporte.Rows.Count > 0 Then
                    formatoReporteEstadosdeCuenta(dtConsultaReporte, dtCuentasDeposito, dtDatosCliente)
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay información para mostrar.")
                End If
                Me.Cursor = Cursors.Default
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Es necesario seleccionar Razón Social y Cliente.")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al consultar el reporte.")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub formatoReporteEstadosdeCuenta(ByVal tblConsultaReporte As DataTable, ByVal tblCuentasDeposito As DataTable, ByVal tblDatosCliente As DataTable)
        Dim dsdatosReporteEstadosdeCuenta As New DataSet("dsEnvioEdoCta")
        Dim dtCuentasDeposito As New DataTable()
        Dim dtEdoCta As New DataTable()
        Try
            Me.Cursor = Cursors.WaitCursor
            dtCuentasDeposito = tblCuentasDeposito
            dtEdoCta = tblConsultaReporte

            tblCuentasDeposito.TableName = "dtCuentasDeposito"
            tblConsultaReporte.TableName = "dtEdoCta"

            dsdatosReporteEstadosdeCuenta.Tables.Add(tblConsultaReporte)
            dsdatosReporteEstadosdeCuenta.Tables.Add(tblCuentasDeposito)


            Dim objConsultaReporteBU As New ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = objConsultaReporteBU.LeerReporteporClave("REPORTE_EDOCTA_COBRANZA")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                   EntidadReporte.Pnombre
            My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
            Dim reporteCobranza As New StiReport
            reporteCobranza.Load((archivo + ".mrt"))
            reporteCobranza.Compile()
            reporteCobranza("Cliente") = CmbClientes.Text
            reporteCobranza("fechaAnalisis") = dtfechaAnalisis.Value
            reporteCobranza("descuento") = CDbl(tblDatosCliente.Rows(0).Item("descuento"))
            reporteCobranza("diasplazo") = CInt(tblDatosCliente.Rows(0).Item("diasplazo"))
            reporteCobranza("referencia") = tblDatosCliente.Rows(0).Item("referencia").ToString
            reporteCobranza("convenio") = tblDatosCliente.Rows(0).Item("convenio").ToString
            reporteCobranza("urlImagen") = tblDatosCliente.Rows(0).Item("rutalogo").ToString
            reporteCobranza("mostrarcuentas") = CBool(tblDatosCliente.Rows(0).Item("mostrarcuentasdeposito").ToString)
            reporteCobranza.RegData(dsdatosReporteEstadosdeCuenta)
            reporteCobranza.Render()
            reporteCobranza.Show()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub CmbClientes_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles CmbClientes.SelectedIndexChanged
        If terminaCargas Then
            consultarRFCCliente()
        End If
    End Sub
End Class