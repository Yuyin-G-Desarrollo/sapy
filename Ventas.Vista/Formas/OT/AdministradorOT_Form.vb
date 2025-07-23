Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
'Imports XtraReportSerialization
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.IO
Imports System.Xml



Public Class AdministradorOT_Form

    Dim objBU As New Ventas.Negocios.OrdenTrabajoBU
    Dim TipoPerfil As Integer = 0 ' 1 => Ventas, 2=> Operaciones
    Dim OrdenTrabajoId As Integer = -1

    Dim ListaPedidoSICY As New List(Of String)
    Dim ListaPedidoSAY As New List(Of String)
    Dim ListaFolio As New List(Of String)

    Dim ListaIndicesCita As New List(Of Integer)
    Dim ListaIndicesBloqueadosCita As New List(Of Integer)
    Dim PrimeraConsulta As Boolean = True
    Dim EsYISTI As Boolean = False

    Dim FilasSeleccionadas As Integer = 0

    Private Sub AdministradorOT_Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        PrimeraConsulta = True


        lblTotalSeleccionados.Text = "0"
        Me.WindowState = FormWindowState.Maximized
        grdOts.MainView = grdVentas
        chkFecha_CheckedChanged(Nothing, Nothing)

        Dim FechaActual As Date = Date.Now
        Dim DiaSemana As Integer = FechaActual.DayOfWeek
        Dim FechaInicio As Date
        Dim FechaFin As Date

        If DiaSemana >= 1 Then
            FechaInicio = FechaActual.AddDays((1 - DiaSemana))
        Else
            FechaInicio = FechaActual.AddDays(1)
        End If
        FechaFin = FechaActual.AddDays(6 - DiaSemana)

        dtpFechaInicio.Value = FechaInicio
        dtpFechaFin.Value = FechaFin
        ObtenerCEDISUsuario()
        PermisosPerfil()

        PrimeraConsulta = False

        If TipoPerfil = 2 Then
            grdStatusPedido.DataSource = CargarEstatusAlmacen()
            With grdStatusPedido
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        ElseIf TipoPerfil = 1 Or TipoPerfil = 4 Then
            grdStatusPedido.DataSource = CargarEstatusVentas()
            With grdStatusPedido
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        End If

        'btnAceptar_Click(Nothing, Nothing)
        '    btnArriba_Click(Nothing, Nothing)

    End Sub

    Private Function CargarEstatusAlmacen() As DataTable
        Dim dtInformacion As New DataTable
        dtInformacion.Columns.Add("Parámetro", GetType(Integer))
        dtInformacion.Columns.Add("", GetType(Boolean))
        dtInformacion.Columns.Add("NombreEstatus", GetType(String))

        dtInformacion.Rows.Add(120, True, "CONFIRMADO VENTAS")
        dtInformacion.Rows.Add(121, True, "ACEPTADA")
        dtInformacion.Rows.Add(122, True, "EN EJECUCION")
        dtInformacion.Rows.Add(123, True, "PARCIALMENTE CONFIRMADA")

        Return dtInformacion

    End Function

    Private Function CargarClienteYISTI() As DataTable
        Dim dtInformacion As New DataTable
        dtInformacion.Columns.Add("Parámetro", GetType(Integer))
        dtInformacion.Columns.Add("", GetType(Boolean))
        dtInformacion.Columns.Add("Nombre", GetType(String))
        dtInformacion.Columns.Add("Clasificación", GetType(String))
        dtInformacion.Columns.Add("Ranking", GetType(String))
        dtInformacion.Columns.Add("Bloqueado Entrega", GetType(String))

        dtInformacion.Rows.Add(1132, True, "FUNDACION YISTI SOCIETY A.C.", "", "", "")

        Return dtInformacion
    End Function

    Private Function CargarEstatusVentas() As DataTable
        Dim dtInformacion As New DataTable
        dtInformacion.Columns.Add("Parámetro", GetType(Integer))
        dtInformacion.Columns.Add("", GetType(Boolean))
        dtInformacion.Columns.Add("NombreEstatus", GetType(String))

        dtInformacion.Rows.Add(119, True, "ACTIVO")
        dtInformacion.Rows.Add(130, True, "RECHAZADA")


        Return dtInformacion

    End Function

    Private Sub PermisosPerfil()
        Dim DTInformacionUsuario As New DataTable

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_VENTAS") Then
            TipoPerfil = 1
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_ATENCIONCLIENTES") Then
            TipoPerfil = 1
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_ALMACEN") Then
            TipoPerfil = 2
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_AGENTEVENTAS") Then
            TipoPerfil = 3
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_SOLOCONSULTA") Then
            TipoPerfil = 4
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_MODIFICACIONESESPECIALES") Then
            btnModificacionesEspeciales.Visible = True
            lblModificacionesEspeciales.Visible = True
        End If

        'AGREGADO PARA QUE SOLO SAC PUEDEA HACER LAS FACTURAS DE E-COMMERCE
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_SAC") Then
            btn_configuracionecommerce.Visible = True
            lblConfiguracionecommerce.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_CONFIRMARPARES") Then
            If TipoPerfil = 1 Then
                btnConfirmarArchivoVentas.Visible = True
                lblTextoConfirmarArchivoVentas.Visible = True
                btnConfirmarOT.Visible = False
                lblTextoConfirmarOT.Visible = False
            ElseIf TipoPerfil = 2 Then
                btnConfirmarOT.Visible = True
                lblTextoConfirmarOT.Visible = True
                btnConfirmarArchivoVentas.Visible = False
                lblTextoConfirmarArchivoVentas.Visible = False
            End If

        Else
            btnConfirmarOT.Visible = False
            lblTextoConfirmarOT.Visible = False
            btnConfirmarArchivoVentas.Visible = False
            lblTextoConfirmarArchivoVentas.Visible = False
            btnAsignarASN.Visible = True
            lblAsignarASN.Visible = True
        End If

        ' Agregado por Daniel Hernández
        ' El tipo de perfil 4 es para permisos de solo consulta


        'btnCancelar.Visible = True
        'lblCancelar.Visible = True

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_CANCELAROT") Then
        If TipoPerfil = 1 Or TipoPerfil = 4 Then
            btnCancelar.Visible = True
            lblCancelar.Visible = True
        Else
            btnCancelar.Visible = False
            lblCancelar.Visible = False
        End If

        If TipoPerfil = 1 Then
            grbxOperador.Visible = False
            UltraPanel2.Visible = False
            UltraPanel2.Width = 0
            grbxOperador.Width = 0
            btnErroresIncidencias.Visible = False
            lblInicidenciasErrores.Visible = False
            btnAsignarOperador.Visible = False
            lblTextoOperador.Visible = False
            btnAceptarAlmacen.Visible = False
            lblTextoAceptar.Visible = False
            btnAutorizar.Visible = True
            lblTextoAutorizar.Visible = True
            btnAgenda.Visible = True
            lblAgenda.Visible = True
            btnAgregarFechaPreparacion.Visible = True
            lbltextoAgregarPreparacion.Visible = True
            btnImprimirOT.Visible = False
            lblTextoImprimirApartado.Visible = False
            btnRechazar.Visible = False
            lblRechazar.Visible = False
            pnlVentas.Visible = True
            pnlAlmacen.Visible = False
            btnImprimirVentas.Visible = True
            lblTextoImprimirVentas.Visible = True
            btnAsignarASN.Visible = True
            lblAsignarASN.Visible = True

            btnGenerarArchivo.Visible = False
            lblTextoGenerarXML.Visible = False

            btnEnviarFacturacionAndrea.Visible = False
            lblEnviarFacturacionAndrea.Visible = False

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROY", "VENT_PROYECCION_ATENCIONCLIENTES") Then
                If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_DESASIGNACION_TODO") Then
                    btnAtnClientes.Enabled = False
                    DTInformacionUsuario.Columns.Add("IdColaborador")
                    DTInformacionUsuario.Columns.Add(" ")
                    DTInformacionUsuario.Columns.Add("Nombre")
                    DTInformacionUsuario.Rows.Add(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)

                    grdAtnClientes.DataSource = DTInformacionUsuario
                    grdAtnClientes.DisplayLayout.Bands(0).Columns(0).Hidden = True
                    grdAtnClientes.DisplayLayout.Bands(0).Columns(1).Hidden = True
                End If


            End If


            btnCancelacionAndrea.Visible = True
            lblCancelacionParesAndrea.Visible = True

        ElseIf TipoPerfil = 2 Then
            grbxOperador.Visible = True
            btnAceptarAlmacen.Visible = True
            lblTextoAceptar.Visible = True
            btnAutorizar.Visible = False
            lblTextoAutorizar.Visible = False
            btnAgenda.Enabled = True
            lblAgenda.Enabled = True
            btnAgregarFechaPreparacion.Visible = False
            lbltextoAgregarPreparacion.Visible = False
            btnImprimirOT.Visible = True
            lblTextoImprimirApartado.Visible = True

            btnRechazar.Visible = True
            lblRechazar.Visible = True
            btnCancelar.Visible = False
            lblCancelar.Visible = False


            btnAutorizar.Visible = False
            lblTextoAutorizar.Visible = False
            btnExportarVentas.Visible = False
            lblExportar.Visible = False
            btnDetalles.Visible = False
            lblDetalles.Visible = False
            btnAgregarFechaPreparacion.Visible = False
            lbltextoAgregarPreparacion.Visible = False
            btnAgendaVentas.Visible = False
            lblTextoAgendaVentas.Visible = False
            btnCancelar.Visible = False
            lblCancelar.Visible = False
            btnImprimirVentas.Visible = False
            lblTextoImprimirVentas.Visible = False
            btnGenerarArchivo.Visible = True
            lblTextoGenerarXML.Visible = True

            btnEnviarFacturacionAndrea.Visible = True
            lblEnviarFacturacionAndrea.Visible = True

            btnCancelacionAndrea.Visible = False
            lblCancelacionParesAndrea.Visible = False

            btnAsignarASN.Visible = False
            lblAsignarASN.Visible = False

        ElseIf TipoPerfil = 3 Then
            pnlVentas.Visible = True
            pnlAlmacen.Visible = False
            btnAceptar.Enabled = True
            lblAceptar.Enabled = True
            btnLimpiar.Enabled = True
            lblLimpiar.Enabled = True
            btnCerrar.Enabled = True
            lblCerrar.Enabled = True
            btnAutorizar.Visible = False
            lblTextoAutorizar.Visible = False
            btnAgregarFechaPreparacion.Visible = False
            lbltextoAgregarPreparacion.Visible = False
            btnAgendaVentas.Visible = False
            lblTextoAgendaVentas.Visible = False

            btnExportarVentas.Visible = True
            lblExportar.Visible = True
            btnDetalles.Visible = True
            lblDetalles.Visible = True
            btnAsignarASN.Visible = False
            lblAsignarASN.Visible = False


            Dim dtAgente As DataTable
            Try
                dtAgente = objBU.ConsultarAgenteVentas(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                grdFiltroAgenteVentas.DataSource = dtAgente

                With grdFiltroAgenteVentas
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                End With
            Catch ex As Exception
                show_message("Error", ex.Message)
            End Try


            GroupBox4.Enabled = False
        ElseIf TipoPerfil = 4 Then
            btnAutorizar.Visible = False
            lblTextoAutorizar.Visible = False
            btnImprimirOT.Visible = True
            lblTextoImprimirApartado.Visible = True
            btnRechazar.Visible = False
            lblRechazar.Visible = False
            btnAceptarAlmacen.Visible = False
            lblTextoAceptar.Visible = False
            btnAgregarFechaPreparacion.Visible = False
            lbltextoAgregarPreparacion.Visible = False
            btnErroresIncidencias.Visible = False
            lblInicidenciasErrores.Visible = False
            btnAgenda.Visible = False
            lblAgenda.Visible = False
            btnAsignarOperador.Visible = False
            lblTextoOperador.Visible = False
            btnCancelar.Visible = False
            lblCancelar.Visible = False
            UltraPanel2.Visible = False
            btnAsignarASN.Visible = False
            lblAsignarASN.Visible = False

        Else
            pnlVentas.Visible = False
            pnlAlmacen.Visible = False

            btnAceptar.Enabled = False
            lblAceptar.Enabled = False
            btnLimpiar.Enabled = False
            lblLimpiar.Enabled = False
            btnCerrar.Enabled = False
            lblCerrar.Enabled = False
            btnImprimirOT.Enabled = False
            lblTextoImprimirApartado.Enabled = False
            btnAutorizar.Enabled = False
            lblTextoAutorizar.Enabled = False
            btnVerDetallesApartados.Enabled = False
            Label18.Enabled = False
            btnExportarExcel.Enabled = False
            Label17.Enabled = False
            btnRechazar.Enabled = False
            lblRechazar.Enabled = False
            btnAceptarAlmacen.Enabled = False
            lblTextoAceptar.Enabled = False
            btnAgregarFechaPreparacion.Enabled = False
            lbltextoAgregarPreparacion.Enabled = False
            btnErroresIncidencias.Enabled = False
            lblInicidenciasErrores.Enabled = False
            btnAgenda.Enabled = False
            lblAgenda.Enabled = False
            btnAsignarOperador.Enabled = False
            lblTextoOperador.Enabled = False
            btnAsignarASN.Visible = False
            lblAsignarASN.Visible = False

        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_YISTI") Then
            gboxCliente.Enabled = False
            grdCliente.DataSource = CargarClienteYISTI()
            With grdCliente
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(3).Hidden = True
                .DisplayLayout.Bands(0).Columns(4).Hidden = True
                .DisplayLayout.Bands(0).Columns(5).Hidden = True

                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
            End With

            btnGenerarArchivo.Visible = False
            lblTextoGenerarXML.Visible = False
            btnEnviarFacturacionAndrea.Visible = False
            lblEnviarFacturacionAndrea.Visible = False
            btnAsignarOperador.Visible = False
            lblTextoOperador.Visible = False
            btnRechazar.Visible = False
            lblRechazar.Visible = False
            btnConfirmarOT.Visible = True
            lblTextoConfirmarOT.Visible = True

            EsYISTI = True

        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_CANCELAROT") Then
            btnCancelacionAndrea.Visible = True
            lblCancelacionParesAndrea.Visible = True
        Else
            btnCancelacionAndrea.Visible = False
            lblCancelacionParesAndrea.Visible = False
        End If

        If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = 9809 Then
            Button5.Visible = True
            Button4.Visible = True
            Button3.Visible = True
            Button1.Visible = True
            Label26.Visible = True
            Label27.Visible = True
            Label28.Visible = True
            Label29.Visible = True
        End If

    End Sub


    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 323
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        MostrarInformacion(sender, e)
        FilasSeleccionadas = 0
    End Sub

    Private Sub btnExportarExcelPaqueterias_Click(sender As Object, e As EventArgs) Handles btnExportarExcelPaqueterias.Click
        ExportarExcelPaqueterias(sender, e)
    End Sub

    Private Sub ObtenerInformacion()

        Try

            'objBU.ActualizarEncabezadosOrdenTrabajo()
            CargarOTs()
            If chkDetallada.Checked = True Then
                If grdVentas.RowCount > 0 Then
                    For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVentas.Columns
                        col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                        If (col.FieldName = "Observaciones") Then
                            col.Width = "350"
                        End If
                        If (col.FieldName = "Cliente") Then
                            col.Width = "275"
                        End If
                        If (col.FieldName = "FechaEnvioAlmacen") Then
                            col.Width = "150"
                        End If
                        If (col.FieldName = "MotivoCancelacion") Then
                            col.Width = "150"
                        End If
                        If (col.FieldName = "Artículo") Then
                            col.Width = "400"
                        End If
                        If (col.FieldName = "FechaCaptura") Then
                            col.Width = "150"
                        End If
                    Next
                    DiseñoGridDetalles(grdVentas)

                End If
            Else
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVentas.Columns
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                    If (col.FieldName = "Observaciones") Then
                        col.Width = "350"
                    End If
                    If (col.FieldName = "Cliente") Then
                        col.Width = "275"
                    End If
                    If (col.FieldName = "FechaEnvioAlmacen") Then
                        col.Width = "150"
                    End If
                    If (col.FieldName = "MotivoCancelacion") Then
                        col.Width = "150"
                    End If
                    If (col.FieldName = "MotivoRechazo") Then
                        col.Width = "350"
                    End If
                    If (col.FieldName = "FechaConfirmacion") Then
                        col.Width = "150"
                    End If
                    If (col.FieldName = "DireccionCliente") Then
                        col.Width = 400
                    End If
                Next
                DiseñoGrid()

                'If grdVentas.RowCount > 0 Then
                '    DiseñoGrid()
                'End If
            End If
            DeSeleccionarFilas()
            DiseñoCamposAgregados()
        Catch ex As Exception

            If ex.Message.ToString.Contains("interbloqueo") Then
                ObtenerInformacion()
            End If

            'show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub DiseñoCamposAgregados()
        Dim valorCelda As Integer = 0

        For index As Integer = 0 To grdVentas.DataRowCount
            If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Origen") = valorCelda Then
                grdVentas.SetRowCellValue(index, grdVentas.Columns.ColumnByFieldName("Origen"), "")
            End If
        Next
    End Sub

    Private Sub DeSeleccionarFilas()

        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasAutorizadas As Integer = 0
        Dim FilaYaAutorizada As Integer = 0
        Dim FilaCancelada As Integer = 0


        Try
            Cursor = Cursors.WaitCursor

            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    grdVentas.UnselectRow(grdVentas.GetVisibleRowHandle(index))
                End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub


    Private Sub CargarOTs()
        Dim FPedidoSAY As String = String.Empty
        Dim FPedidoSICY As String = String.Empty
        Dim FFolioOT As String = String.Empty
        Dim FCliente As String = String.Empty
        Dim FTienda As String = String.Empty
        Dim FAtnClientes As String = String.Empty
        Dim FAgenteVentas As String = String.Empty
        Dim FStatusOT As String = String.Empty
        Dim FMarca As String = String.Empty
        Dim FColeccion As String = String.Empty
        Dim FModelo As String = String.Empty
        Dim FPiel As String = String.Empty
        Dim Fcolor As String = String.Empty
        Dim FCorrida As String = String.Empty
        Dim FOperador As String = String.Empty
        Dim dtinformacion As New DataTable
        Dim CEDISID As Integer = 0

        Try


            chboxSeleccionarTodo.Checked = False
            Cursor = Cursors.WaitCursor

            'If chkDetallada.Checked = True Then
            '    grdOts.MainView = grdDetallesOT                
            'Else
            '    grdOts.MainView = grdVentas
            'End If

            grdVentas.Columns.Clear()
            grdOts.DataSource = Nothing
            FPedidoSAY = ObtenerFiltrosGrid(grdPedidoSAY)
            FPedidoSICY = ObtenerFiltrosGrid(grdPedidoSICY)
            FFolioOT = ObtenerFiltrosGrid(grdFolioOT)
            FCliente = ObtenerFiltrosGrid(grdCliente)
            FTienda = ObtenerFiltrosGrid(grdTienda)
            FAtnClientes = ObtenerFiltrosGrid(grdAtnClientes)
            FAgenteVentas = ObtenerFiltrosGrid(grdFiltroAgenteVentas)
            FStatusOT = ObtenerFiltrosGrid(grdStatusPedido)
            FMarca = ObtenerFiltrosGrid(grdMarca)
            FColeccion = ObtenerFiltrosGrid(grdColeccion)
            FModelo = ObtenerFiltrosGrid(grdModelo)
            FPiel = ObtenerFiltrosGrid(grdPiel)
            Fcolor = ObtenerFiltrosGrid(grdColor)
            FCorrida = ObtenerFiltrosGrid(grdCorrida)
            FOperador = ObtenerFiltrosGrid(grdOperador)
            'DisenoGridOTs(grdOts)
            'grdOts.DataSource = objBU.ConsultarOTs(TipoPerfil, ObtenerFiltroTipoOT(), ObtenerFiltroCita(), ObtenerFiltroFecha(), dtpFechaInicio.Value, dtpFechaFin.Value, FPedidoSAY, FPedidoSICY, FFolioOT, FCliente, FTienda, FAtnClientes, FAgenteVentas, FStatusOT, FMarca, FColeccion, FModelo, FPiel, Fcolor, FCorrida, FOperador)
            grdOts.DataSource = Nothing
            'grdVentas.Columns.Clear()            
            grdVentas.ColumnPanelRowHeight = 40

            'grdDetallesOT.Columns.Clear()
            grdDetallesOT.ColumnPanelRowHeight = 40

            CEDISID = cmbCEDIS.SelectedValue

            If chkDetallada.Checked = True Then
                dtinformacion = objBU.ConsultarDetalleOTs(TipoPerfil, ObtenerFiltroTipoOT(), ObtenerFiltroCita(), ObtenerFiltroFecha(), dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, FPedidoSAY, FPedidoSICY, FFolioOT, FCliente, FTienda, FAtnClientes, FAgenteVentas, FStatusOT, FMarca, FColeccion, FModelo, FPiel, Fcolor, FCorrida, FOperador, CEDISID)
            Else
                If TipoPerfil = 1 Or TipoPerfil = 4 Then
                    dtinformacion = objBU.CargarOTVentas(ObtenerFiltroTipoOT(), ObtenerFiltroCita(), ObtenerFiltroFecha(), dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, FPedidoSAY, FPedidoSICY, FFolioOT, FCliente, FTienda, FAtnClientes, FAgenteVentas, FStatusOT, FMarca, FColeccion, FModelo, FPiel, Fcolor, FCorrida, CEDISID)
                    'dtinformacion = objBU.ConsultarOTs(TipoPerfil, ObtenerFiltroTipoOT(), ObtenerFiltroCita(), ObtenerFiltroFecha(), dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, FPedidoSAY, FPedidoSICY, FFolioOT, FCliente, FTienda, FAtnClientes, FAgenteVentas, FStatusOT, FMarca, FColeccion, FModelo, FPiel, Fcolor, FCorrida, FOperador)
                ElseIf TipoPerfil = 2 Then
                    dtinformacion = objBU.CargarOTAlmacen(ObtenerFiltroTipoOT(), ObtenerFiltroCita(), ObtenerFiltroFecha(), dtpFechaInicio.Value, dtpFechaFin.Value, FPedidoSAY, FPedidoSICY, FFolioOT, FCliente, FTienda, FAtnClientes, FAgenteVentas, FStatusOT, FMarca, FColeccion, FModelo, FPiel, Fcolor, FCorrida, FOperador, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, CEDISID)
                    'dtinformacion = objBU.ConsultarOTsAlmacen(TipoPerfil, ObtenerFiltroTipoOT(), ObtenerFiltroCita(), ObtenerFiltroFecha(), dtpFechaInicio.Value, dtpFechaFin.Value, FPedidoSAY, FPedidoSICY, FFolioOT, FCliente, FTienda, FAtnClientes, FAgenteVentas, c, FMarca, FColeccion, FModelo, FPiel, Fcolor, FCorrida, FOperador)
                ElseIf TipoPerfil = 3 Then
                    dtinformacion = objBU.CargarOTVentas(ObtenerFiltroTipoOT(), ObtenerFiltroCita(), ObtenerFiltroFecha(), dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, FPedidoSAY, FPedidoSICY, FFolioOT, FCliente, FTienda, FAtnClientes, FAgenteVentas, FStatusOT, FMarca, FColeccion, FModelo, FPiel, Fcolor, FCorrida, CEDISID)
                End If
            End If

            grdOts.DataSource = dtinformacion
            lblTotalSeleccionados.Text = "0"
            grdVentas.OptionsSelection.MultiSelect = True

            lblTotalSeleccionados.Text = CDbl(grdVentas.RowCount.ToString()).ToString("n0")
            'If GridView2.SelectedRowsCount() > 0 Then
            '    GridView2.UnselectRow(GridView2.GetVisibleRowHandle(0))

            'End If


            'GridView2.ColumnPanelRowHeight = 20
            'GridView1.Columns.ColumnByFieldName("Estiba ID").Visible = False

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Public Function ObtenerFiltroTipoOT() As Integer
        Dim Resultado As Integer = 0

        If chkDesasignacion.Checked = True And chkSurtido.Checked = True Then
            Resultado = 3
        ElseIf chkSurtido.Checked = True Then
            Resultado = 1
        ElseIf chkDesasignacion.Checked = True Then
            Resultado = 2
        ElseIf chkDesasignacion.Checked = False And chkSurtido.Checked = False Then
            Resultado = 0

        End If

        Return Resultado
    End Function


    Public Function ObtenerFiltroCita() As Integer
        Dim Resultado As Integer = 0
        '0 => Nada, 1 => SI, 2 => No, 3 => Ambos

        If chboxClienteCitaSi.Checked = True And chboxClienteCitaNo.Checked = True Then
            Resultado = 3
        ElseIf chboxClienteCitaSi.Checked = True Then
            Resultado = 1
        ElseIf chboxClienteCitaNo.Checked = True Then
            Resultado = 2
        ElseIf chkDesasignacion.Checked = False And chkSurtido.Checked = False Then
            Resultado = 0

        End If

        Return Resultado
    End Function


    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1
        listado.TipoPerfil = TipoPerfil
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub




    Private Sub btnTienda_Click(sender As Object, e As EventArgs) Handles btnTienda.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 2
        listado.TipoPerfil = TipoPerfil
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTienda.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTienda.DataSource = listado.listParametros
        With grdTienda
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Tienda"
        End With
    End Sub

    Private Sub btnAtnClientes_Click(sender As Object, e As EventArgs) Handles btnAtnClientes.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 3

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAtnClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAtnClientes.DataSource = listado.listParametros
        With grdAtnClientes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Atn. Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 5

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listParametros
        With grdMarca
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 6
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
        End With
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdModelo.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdModelo.DataSource = listado.listParametros
        With grdModelo
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Modelo"
        End With
    End Sub

    Private Sub btnPiel_Click(sender As Object, e As EventArgs) Handles btnPiel.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 8
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdPiel.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdPiel.DataSource = listado.listParametros
        With grdPiel
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Piel"
        End With
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 9
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColor.DataSource = listado.listParametros
        With grdColor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Color"
        End With
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 10
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCorrida.DataSource = listado.listParametros
        With grdCorrida
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
        End With
    End Sub

    Private Sub btnOperador_Click(sender As Object, e As EventArgs) Handles btnOperador.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 12
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdOperador.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdOperador.DataSource = listado.listParametros
        With grdOperador
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Operador"
        End With
    End Sub

    Private Sub btnAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnAgenteVentas.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 4

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroAgenteVentas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroAgenteVentas.DataSource = listado.listParametros
        With grdFiltroAgenteVentas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnStatusPedido_Click(sender As Object, e As EventArgs) Handles btnStatusPedido.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 13

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdStatusPedido.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatusPedido.DataSource = listado.listParametros
        With grdStatusPedido
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub txtFolioOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioOT.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFolioOT.Text) Then Return

            ListaFolio.Add(txtFolioOT.Text)
            grdFolioOT.DataSource = Nothing
            grdFolioOT.DataSource = ListaFolio

            txtFolioOT.Text = String.Empty

        End If
    End Sub


    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            ListaPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = ListaPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub


    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            ListaPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = ListaPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next
    End Sub

    Private Sub grdFolioOT_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolioOT.InitializeLayout
        grid_diseño(grdFolioOT)
        grdFolioOT.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio"
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdFolioOT_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFolioOT.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioOT.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdAtnClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAtnClientes.BeforeRowsDeleted

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROY", "VENT_PROYECCION_ATENCIONCLIENTES") Then
            e.Cancel = True
        End If
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAtnClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAtnClientes.InitializeLayout
        grid_diseño(grdAtnClientes)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdAtnClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdAtnClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdAtnClientes.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColor.InitializeLayout
        grid_diseño(grdColor)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroAgenteVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroAgenteVentas.InitializeLayout
        grid_diseño(grdFiltroAgenteVentas)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdFiltroAgenteVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroAgenteVentas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroAgenteVentas.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub grdOperador_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdOperador.InitializeLayout
        grid_diseño(grdOperador)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdOperador_KeyDown(sender As Object, e As KeyEventArgs) Handles grdOperador.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdOperador.DeleteSelectedRows(False)
    End Sub

    Private Sub grdOTs_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        'grid_diseño(grdOTs)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdOTs_KeyDown(sender As Object, e As KeyEventArgs)
        'If Not e.KeyCode = Keys.Delete Then Return
        'grdOTs.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPiel_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPiel.InitializeLayout
        grid_diseño(grdPiel)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPiel_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPiel.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPiel.DeleteSelectedRows(False)
    End Sub

    Private Sub grdStatusPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatusPedido.InitializeLayout
        grid_diseño(grdStatusPedido)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdStatusPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatusPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatusPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub grdTienda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTienda.InitializeLayout
        grid_diseño(grdTienda)
        'grd.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdTienda_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTienda.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTienda.DeleteSelectedRows(False)
    End Sub

    'Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
    '    Dim View As GridView = sender
    '    OrdenTrabajoId = View.GetRowCellDisplayText(e.RowHandle, View.Columns("OT"))
    'End Sub


    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetVisibleIndex(e.RowHandle)
            'Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("#"))
            If category Mod 2 > 0 Then
                e.Appearance.BackColor = Color.LightSteelBlue
                'e.Appearance.BackColor2 = Color.SeaShell
            End If
        End If
    End Sub

    Private Sub DiseñoGrid()
        grdVentas.OptionsView.ColumnAutoWidth = False
        'grdVentas.OptionsView.BestFitMaxRowCount = -1


        If IsNothing(grdVentas.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            grdVentas.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler grdVentas.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            grdVentas.Columns.Item("#").VisibleIndex = 0
        End If


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVentas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If col.FieldName <> "Seleccionar" Then col.OptionsColumn.AllowEdit = False
        Next

        grdVentas.Columns.ColumnByFieldName("EstatusID").Visible = False
        grdVentas.Columns.ColumnByFieldName("ClienteSAYID").Visible = False
        grdVentas.Columns.ColumnByFieldName("HoraCita").Visible = False
        grdVentas.Columns.ColumnByFieldName("ClaveCitaEntrega").Visible = False
        grdVentas.Columns.ColumnByFieldName("TotalPersonasRequeridas").Visible = False

        grdVentas.Columns.ColumnByFieldName("UsuarioAgregoCita").Visible = False
        grdVentas.Columns.ColumnByFieldName("FechaCapturoCita").Visible = False
        grdVentas.Columns.ColumnByFieldName("OTSICY").Visible = False
        grdVentas.Columns.ColumnByFieldName("Impreso").Visible = False
        grdVentas.Columns.ColumnByFieldName("UsuarioImpreso").Visible = False

        If TipoPerfil = 2 Then
            grdVentas.Columns.ColumnByFieldName("Agente").Visible = False
            grdVentas.Columns.ColumnByFieldName("TipoOT").Visible = True
            grdVentas.Columns.ColumnByFieldName("Marca").Visible = False
            grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").Visible = False
            grdVentas.Columns.ColumnByFieldName("FechaModificacion").Visible = False
            grdVentas.Columns.ColumnByFieldName("BE").Visible = False
            grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").Visible = True
            grdVentas.Columns.ColumnByFieldName("UsuarioEnvioAlmacen").Visible = True
            'grdVentas.Columns.ColumnByFieldName("FechaValidoAlmacen").Visible = False
            grdVentas.Columns.ColumnByFieldName("UsuarioValidoAlmacen").Visible = False
            grdVentas.Columns.ColumnByFieldName("TiempoConfirmacion").Visible = False
            grdVentas.Columns.ColumnByFieldName("Ubicaciones").Visible = False

            grdVentas.Columns.ColumnByFieldName("TipoOT").Width = 140
        End If
        grdVentas.Columns.ColumnByFieldName("TipoOT").Width = 140
        grdVentas.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVentas.Columns.ColumnByFieldName("Confirmados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVentas.Columns.ColumnByFieldName("PorConfirmar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVentas.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVentas.Columns.ColumnByFieldName("ParesEntregados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric



        grdVentas.Columns.ColumnByFieldName("Cantidad").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        grdVentas.Columns.ColumnByFieldName("Confirmados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        grdVentas.Columns.ColumnByFieldName("PorConfirmar").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        grdVentas.Columns.ColumnByFieldName("Cancelados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        grdVentas.Columns.ColumnByFieldName("ParesEntregados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals


        grdVentas.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatString = "N0"
        grdVentas.Columns.ColumnByFieldName("Confirmados").DisplayFormat.FormatString = "N0"
        grdVentas.Columns.ColumnByFieldName("PorConfirmar").DisplayFormat.FormatString = "N0"
        grdVentas.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatString = "N0"
        grdVentas.Columns.ColumnByFieldName("ParesEntregados").DisplayFormat.FormatString = "N0"

        grdVentas.Columns.ColumnByFieldName("Observaciones").Visible = True
        'grdVentas.Columns.ColumnByFieldName("Observaciones").Width = 300

        'If TipoPerfil = 1 Then
        '    grdVentas.Columns.ColumnByFieldName("Observaciones").Visible = True
        '    grdVentas.Columns.ColumnByFieldName("Observaciones").Width = 200
        'Else
        '    grdVentas.Columns.ColumnByFieldName("Observaciones").Visible = False
        'End If

        'GridView1.BestFitColumns()
        grdVentas.Columns.ColumnByFieldName("#").Width = 30
        'grdVentas.Columns.ColumnByFieldName("ColorEstatus").Width = 25
        'grdVentas.Columns.ColumnByFieldName("Seleccionar").Width = 25
        'grdVentas.Columns.ColumnByFieldName("OT").Width = 40
        'grdVentas.Columns.ColumnByFieldName("OTSICY").Width = 40
        grdVentas.Columns.ColumnByFieldName("Restriccion Facturación").Width = 150
        'grdVentas.Columns.ColumnByFieldName("STATUS").Width = 75
        'grdVentas.Columns.ColumnByFieldName("PedidoSAY").Width = 45
        'grdVentas.Columns.ColumnByFieldName("PedidoSICY").Width = 55

        grdVentas.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVentas.Columns.ColumnByFieldName("Restriccion Facturación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVentas.Columns.ColumnByFieldName("Agente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVentas.Columns.ColumnByFieldName("STATUS").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVentas.Columns.ColumnByFieldName("PedidoSICY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVentas.Columns.ColumnByFieldName("PedidoSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        grdVentas.Columns.ColumnByFieldName("STATUS").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        grdVentas.Columns.ColumnByFieldName("Cliente").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

        'grdVentas.Columns.ColumnByFieldName("FechaEntregaProgramacion").Width = 80
        'grdVentas.Columns.ColumnByFieldName("FechaPreparacion").Width = 80
        'grdVentas.Columns.ColumnByFieldName("Cantidad").Width = 60
        'grdVentas.Columns.ColumnByFieldName("Confirmados").Width = 60
        'grdVentas.Columns.ColumnByFieldName("PorConfirmar").Width = 60
        'grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").Width = 70
        'grdVentas.Columns.ColumnByFieldName("FechaCaptura").Width = 70
        'grdVentas.Columns.ColumnByFieldName("MotivoCancelacion").Width = 200
        'grdVentas.Columns.ColumnByFieldName("BE").Width = 30
        'grdVentas.Columns.ColumnByFieldName("Cita").Width = 30
        'grdVentas.Columns.ColumnByFieldName("FechaCitaEntrega").Width = 140
        'grdVentas.Columns.ColumnByFieldName("FechaCaptura").Width = 140
        'grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").Width = 90
        ''

        grdVentas.Columns.ColumnByFieldName("OT").Caption = "OT " & vbCrLf & "SAY"
        grdVentas.Columns.ColumnByFieldName("Restriccion Facturación").Caption = "Restricción" & vbCrLf & "Facturación"
        grdVentas.Columns.ColumnByFieldName("OTSICY").Caption = "OT " & vbCrLf & "SICY"
        grdVentas.Columns.ColumnByFieldName("PedidoSAY").Caption = "Pedido " & vbCrLf & "SAY"
        grdVentas.Columns.ColumnByFieldName("PedidoSICY").Caption = "Pedido " & vbCrLf & "SICY"
        grdVentas.Columns.ColumnByFieldName("FechaEntregaProgramacion").Caption = "F Entrega"
        grdVentas.Columns.ColumnByFieldName("FechaPreparacion").Caption = "F Entrega CTE"
        grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").Caption = "Capturó"
        grdVentas.Columns.ColumnByFieldName("FechaCaptura").Caption = "F Captura"
        grdVentas.Columns.ColumnByFieldName("FechaCitaEntrega").Caption = "F Cita"
        grdVentas.Columns.ColumnByFieldName("MotivoCancelacion").Caption = "Motivo Cancelación"
        grdVentas.Columns.ColumnByFieldName("MotivoRechazo").Caption = "Motivo Rechazo"
        grdVentas.Columns.ColumnByFieldName("UsuarioModifico").Caption = "Modificó"
        grdVentas.Columns.ColumnByFieldName("FechaModificacion").Caption = "F Modificación"
        grdVentas.Columns.ColumnByFieldName("DiasFaltantes").Caption = "Días P"
        grdVentas.Columns.ColumnByFieldName("DiasFaltantes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'grdVentas.Columns.ColumnByFieldName("DiasFaltantes").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        grdVentas.Columns.ColumnByFieldName("DiasFaltantes").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        'grdVentas.Columns.ColumnByFieldName("DiasFaltantes").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVentas.Columns.ColumnByFieldName("DiasFaltantes").OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.True
        'grdVentas.Columns.ColumnByFieldName("DiasFaltantes").OptionsFilter.ImmediateUpdateAutoFilter = False

        grdVentas.Columns.ColumnByFieldName("DiasFaltantes").SortMode = ColumnSortMode.Value


        grdVentas.Columns.ColumnByFieldName("FechaConfirmacion").Caption = "F Confirmacion"

        grdVentas.Columns.ColumnByFieldName("Tipo").Caption = "Tipo"

        grdVentas.Columns.ColumnByFieldName("Cantidad").Caption = "Cantidad"
        grdVentas.Columns.ColumnByFieldName("Confirmados").Caption = "Confirmado"
        grdVentas.Columns.ColumnByFieldName("PorConfirmar").Caption = "Por " & vbCrLf & "Confirmar"
        grdVentas.Columns.ColumnByFieldName("Cancelados").Caption = "Cancelado"
        grdVentas.Columns.ColumnByFieldName("ParesEntregados").Caption = "Entregados"
        grdVentas.Columns.ColumnByFieldName("TipoOT").Caption = "Tipo"
        grdVentas.Columns.ColumnByFieldName("STATUS").Caption = "Status"

        grdVentas.Columns.ColumnByFieldName("Origen").Caption = "Pedido Origen"
        'TipoOT

        grdVentas.Columns.ColumnByFieldName("Seleccionar").Caption = " "
        grdVentas.Columns.ColumnByFieldName("ColorEstatus").Caption = " "

        'grdVentas.Columns.ColumnByFieldName("Cantidad").Width = 60
        'grdVentas.Columns.ColumnByFieldName("Confirmados").Width = 70
        'grdVentas.Columns.ColumnByFieldName("PorConfirmar").Width = 60
        'grdVentas.Columns.ColumnByFieldName("Cancelados").Width = 60
        'grdVentas.Columns.ColumnByFieldName("ParesEntregados").Width = 60
        'grdVentas.Columns.ColumnByFieldName("STATUS").Width = 120
        'grdVentas.Columns.ColumnByFieldName("Agente").Width = 70
        'grdVentas.Columns.ColumnByFieldName("MotivoRechazo").Width = 200
        'grdVentas.Columns.ColumnByFieldName("MotivoCancelacion").Visible = False
        'grdVentas.Columns.ColumnByFieldName("FechaConfirmacion").Width = 140
        'grdVentas.Columns.ColumnByFieldName("FechaCaptura").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        'grdVentas.Columns.ColumnByFieldName("MotivoRechazo").Width = 400



        grdVentas.Columns.ColumnByFieldName("#").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("ColorEstatus").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("OT").OptionsColumn.AllowSize = True
        'grdVentas.Columns.ColumnByFieldName("OTSICY").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("STATUS").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("PedidoSAY").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("PedidoSICY").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("FechaEntregaProgramacion").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("FechaPreparacion").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("Confirmados").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("PorConfirmar").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("FechaCaptura").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("MotivoCancelacion").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("BE").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("Cita").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("FechaCitaEntrega").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("FechaCaptura").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("FechaConfirmacion").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("ParesEntregados").OptionsColumn.AllowSize = True
        grdVentas.Columns.ColumnByFieldName("Restriccion Facturación").OptionsColumn.AllowSize = True

        '        grdVentas.Columns.ColumnByFieldName("FechaConfirmacion").DisplayFormat.FormatString = "dd/mm/yyyy HH:mm"
        'dd/mm/yyyy HH:mm

        grdVentas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(grdVentas.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
            grdVentas.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Cantidad"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            grdVentas.GroupSummary.Add(item)
        End If

        If IsNothing(grdVentas.Columns("Confirmados").Summary.FirstOrDefault(Function(x) x.FieldName = "Confirmados")) = True Then
            grdVentas.Columns("Confirmados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Confirmados"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            grdVentas.GroupSummary.Add(item2)
        End If

        If IsNothing(grdVentas.Columns("PorConfirmar").Summary.FirstOrDefault(Function(x) x.FieldName = "PorConfirmar")) = True Then
            grdVentas.Columns("PorConfirmar").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:N0}")
            Dim item3 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item3.FieldName = "PorConfirmar"
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item3.DisplayFormat = "{0}"
            grdVentas.GroupSummary.Add(item3)
        End If


        If IsNothing(grdVentas.Columns("Cancelados").Summary.FirstOrDefault(Function(x) x.FieldName = "Cancelados")) = True Then
            grdVentas.Columns("Cancelados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:N0}")

            Dim item4 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item4.FieldName = "Cancelados"
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item4.DisplayFormat = "{0}"
            grdVentas.GroupSummary.Add(item4)
        End If

        If IsNothing(grdVentas.Columns("ParesEntregados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesEntregados")) = True Then
            grdVentas.Columns("ParesEntregados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesEntregados", "{0:N0}")
            Dim item5 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item5.FieldName = "Entregados"
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item5.DisplayFormat = "{0}"
            grdVentas.GroupSummary.Add(item5)
        End If

        'grdVentas.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("OT").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("OTSICY").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("Agente").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("STATUS").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("TipoOT").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("PedidoSAY").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("PedidoSICY").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("OrdenCliente").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FechaEntregaProgramacion").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FechaPreparacion").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("Confirmados").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("PorConfirmar").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("Cancelados").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("ParesEntregados").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FechaCaptura").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("Cita").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("UsuarioModifico").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FechaModificacion").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("DiasFaltantes").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("BE").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("MotivoCancelacion").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("EstatusID").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("ClienteSAYID").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FechaCitaEntrega").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("HoraCita").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("ClaveCitaEntrega").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("TotalPersonasRequeridas").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("UsuarioAgregoCita").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FechaCapturoCita").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("ColorEstatus").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FechaConfirmacion").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("MotivoRechazo").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FA").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("Observaciones").OptionsColumn.AllowEdit = False
        'grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").OptionsColumn.AllowEdit = False

        grdVentas.Columns.ColumnByFieldName("FechaCitaEntrega").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm"

        grdVentas.Columns.ColumnByFieldName("FechaConfirmacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        grdVentas.Columns.ColumnByFieldName("FechaModificacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        grdVentas.Columns.ColumnByFieldName("FechaModificacion").Width = 140

        grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").Caption = "F Conf Vtas"

        'grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").Width = 140


        If TipoPerfil = 1 Or TipoPerfil = 4 Then
            grdVentas.Columns.ColumnByFieldName("Proceso").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            grdVentas.Columns.ColumnByFieldName("Proceso").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
            grdVentas.Columns.ColumnByFieldName("Proceso").DisplayFormat.FormatString = "N0"
            'grdVentas.Columns.ColumnByFieldName("Proceso").Width = 60
            grdVentas.Columns.ColumnByFieldName("Proceso").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("Proceso").OptionsColumn.AllowEdit = False

            If IsNothing(grdVentas.Columns("Proceso").Summary.FirstOrDefault(Function(x) x.FieldName = "Proceso")) = True Then
                grdVentas.Columns("Proceso").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Proceso", "{0:N0}")

                Dim item4 As GridGroupSummaryItem = New GridGroupSummaryItem()
                item4.FieldName = "Proceso"
                item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item4.DisplayFormat = "{0}"
                grdVentas.GroupSummary.Add(item4)
            End If
        End If

        If TipoPerfil = 2 Then


            grdVentas.Columns.ColumnByFieldName("FechaEntregaProgramacion").Visible = False
            grdVentas.Columns.ColumnByFieldName("FechaCaptura").Visible = False

            grdVentas.Columns.ColumnByFieldName("ortr_operadorasignadoid").Visible = False
            grdVentas.Columns.ColumnByFieldName("OperadorAsignados").Visible = False
            grdVentas.Columns.ColumnByFieldName("OperadorAsignadoID").Visible = False
            grdVentas.Columns.ColumnByFieldName("UsuarioCapturoID").Visible = False
            grdVentas.Columns.ColumnByFieldName("FechaConfirmacion").Visible = False

            grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("UsuarioEnvioAlmacen").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("FechaValidoAlmacen").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("UsuarioValidoAlmacen").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("TipoEmpaque").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("UsuarioCapturoID").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("OperadorAsignado").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("OperadorConfirma").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("FechaConfirma").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("TiempoConfirmacion").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("Dias").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("TotalErrores").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("TotalIncidencias").OptionsColumn.AllowEdit = False
            grdVentas.Columns.ColumnByFieldName("DireccionCliente").OptionsColumn.AllowEdit = False

            grdVentas.Columns.ColumnByFieldName("FechaConfirma").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").Caption = "F Conf Vtas"
            grdVentas.Columns.ColumnByFieldName("UsuarioEnvioAlmacen").Caption = "Envió"
            grdVentas.Columns.ColumnByFieldName("FechaValidoAlmacen").Caption = "Fecha Aceptación"
            grdVentas.Columns.ColumnByFieldName("UsuarioValidoAlmacen").Caption = "Validó"
            grdVentas.Columns.ColumnByFieldName("TipoEmpaque").Caption = "T Empaque"
            'grdVentas.Columns.ColumnByFieldName("UsuarioCapturoID").Caption = "Usuario " & vbCrLf & "Capturo"
            grdVentas.Columns.ColumnByFieldName("OperadorAsignado").Caption = "Asignado"
            grdVentas.Columns.ColumnByFieldName("OperadorConfirma").Caption = "Confirmó"
            grdVentas.Columns.ColumnByFieldName("FechaConfirma").Caption = "F Confirmación"
            grdVentas.Columns.ColumnByFieldName("TiempoConfirmacion").Caption = "T" & vbCrLf & "Confirmación (m)"
            grdVentas.Columns.ColumnByFieldName("Dias").Caption = "Días de " & vbCrLf & "operación"
            grdVentas.Columns.ColumnByFieldName("TotalErrores").Caption = "Errores"
            grdVentas.Columns.ColumnByFieldName("TotalIncidencias").Caption = "Incidencias"
            grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").Caption = "Proyectó"
            grdVentas.Columns.ColumnByFieldName("DireccionCliente").Caption = "Dirección Cliente"

            'grdVentas.Columns.ColumnByFieldName("UsuarioValidoAlmacen").Width = 25
            'grdVentas.Columns.ColumnByFieldName("TipoEmpaque").Width = 95
            'grdVentas.Columns.ColumnByFieldName("UsuarioCapturoID").Width = 80
            'grdVentas.Columns.ColumnByFieldName("OperadorAsignado").Width = 90
            'grdVentas.Columns.ColumnByFieldName("OperadorConfirma").Width = 90
            'grdVentas.Columns.ColumnByFieldName("FechaValidoAlmacen").Width = 140
            'grdVentas.Columns.ColumnByFieldName("FechaConfirma").Width = 140
            'grdVentas.Columns.ColumnByFieldName("TiempoConfirmacion").Width = 100
            'grdVentas.Columns.ColumnByFieldName("Dias").Width = 60
            'grdVentas.Columns.ColumnByFieldName("TotalErrores").Width = 60
            'grdVentas.Columns.ColumnByFieldName("TotalIncidencias").Width = 70

            grdVentas.Columns.ColumnByFieldName("FechaValidoAlmacen").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            'grdVentas.Columns.ColumnByFieldName("FechaEnvioAlmacen").Width = 140

            'grdVentas.Columns.ColumnByFieldName("TipoEmpaque").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("UsuarioCapturoID").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("OperadorAsignado").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("OperadorConfirma").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("FechaValidoAlmacen").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("FechaConfirma").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("TiempoConfirmacion").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("Dias").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("TotalErrores").OptionsColumn.AllowSize = True
            'grdVentas.Columns.ColumnByFieldName("TotalIncidencias").OptionsColumn.AllowSize = True


            If IsNothing(grdVentas.Columns("TotalErrores").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalErrores")) = True Then
                grdVentas.Columns("TotalErrores").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalErrores", "{0:N0}")
                Dim item3 As GridGroupSummaryItem = New GridGroupSummaryItem()
                item3.FieldName = "TotalErrores"
                item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item3.DisplayFormat = "{0}"
                grdVentas.GroupSummary.Add(item3)
            End If

            If IsNothing(grdVentas.Columns("TotalIncidencias").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalIncidencias")) = True Then
                grdVentas.Columns("TotalIncidencias").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalIncidencias", "{0:N0}")
                Dim item3 As GridGroupSummaryItem = New GridGroupSummaryItem()
                item3.FieldName = "TotalIncidencias"
                item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item3.DisplayFormat = "{0}"
                grdVentas.GroupSummary.Add(item3)
            End If

            'grdVentas.Columns("TotalErrores").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalErrores", "{0:N0}")
            'grdVentas.Columns("TotalIncidencias").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalIncidencias", "{0:N0}")

            'Dim itemTE As GridGroupSummaryItem = New GridGroupSummaryItem()
            'itemTE.FieldName = "TotalErrores"
            'itemTE.SummaryType = DevExpress.Data.SummaryItemType.Sum
            'itemTE.DisplayFormat = "{0}"
            'grdVentas.GroupSummary.Add(itemTE)


            'Dim itemTI As GridGroupSummaryItem = New GridGroupSummaryItem()
            'itemTI.FieldName = "TotalIncidencias"
            'itemTI.SummaryType = DevExpress.Data.SummaryItemType.Sum
            'itemTI.DisplayFormat = "{0}"
            'grdVentas.GroupSummary.Add(itemTI)
        End If



        'GridView1.Columns.ColumnByFieldName("Salida de Nave (hr)").DisplayFormat.FormatString = "M/d/yyyy HH:mm"
        'GridView1.Columns.ColumnByFieldName("Entrada Almacén (hr)").DisplayFormat.FormatString = "M/d/yyyy HH:mm"
        'GridView1.Columns.ColumnByFieldName("Fecha Ubicación Ant. (Hr)").DisplayFormat.FormatString = "M/d/yyyy HH:mm"

        'GridView1.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        'GridView1.Columns("Prs").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Prs", "{0}")

        '' Create and setup the first summary item.
        'Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item.FieldName = "Prs"
        'item.SummaryType = DevExpress.Data.SummaryItemType.Count
        'item.DisplayFormat = "Total: {0}"
        'GridView1.GroupSummary.Add(item)

        ' grdVentas.BestFitColumns()
        grdVentas.Columns.ColumnByFieldName("ColorEstatus").Width = 25
    End Sub


    Private Sub DiseñoGridDetalles(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.ColumnAutoWidth = False
        Grid.OptionsView.BestFitMaxRowCount = -1

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If col.FieldName <> "Seleccionar" Then col.OptionsColumn.AllowEdit = False
        Next


        Grid.Columns.ColumnByFieldName("EstatusID").Visible = False
        Grid.Columns.ColumnByFieldName("ClienteSAYID").Visible = False
        Grid.Columns.ColumnByFieldName("HoraCita").Visible = False
        Grid.Columns.ColumnByFieldName("ClaveCitaEntrega").Visible = False
        Grid.Columns.ColumnByFieldName("TotalPersonasRequeridas").Visible = False
        Grid.Columns.ColumnByFieldName("Observaciones").Visible = True
        Grid.Columns.ColumnByFieldName("UsuarioAgregoCita").Visible = False
        Grid.Columns.ColumnByFieldName("FechaCapturoCita").Visible = False
        Grid.Columns.ColumnByFieldName("Seleccionar").Visible = False
        Grid.Columns.ColumnByFieldName("EstatusPartidaID").Visible = False
        Grid.Columns.ColumnByFieldName("Seleccionar").Visible = False
        Grid.Columns.ColumnByFieldName("OTSICY").Visible = False

        Grid.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Confirmados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("PorConfirmar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Grid.Columns.ColumnByFieldName("ParesEntregados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'Grid.Columns.ColumnByFieldName("Proceso").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


        grdVentas.Columns.ColumnByFieldName("Cantidad").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        grdVentas.Columns.ColumnByFieldName("Confirmados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        grdVentas.Columns.ColumnByFieldName("PorConfirmar").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        grdVentas.Columns.ColumnByFieldName("Cancelados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        grdVentas.Columns.ColumnByFieldName("ParesEntregados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        'Grid.Columns.ColumnByFieldName("Proceso").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals

        Grid.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("Confirmados").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("PorConfirmar").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("ParesEntregados").DisplayFormat.FormatString = "N0"
        'Grid.Columns.ColumnByFieldName("Proceso").DisplayFormat.FormatString = "N0"


        'GridView1.BestFitColumns()
        'Grid.BestFitColumns()
        Grid.Columns.ColumnByFieldName("#").Width = 25
        'Grid.Columns.ColumnByFieldName("ColorEstatus").Width = 25
        'Grid.Columns.ColumnByFieldName("Seleccionar").Width = 25
        '
        'Grid.Columns.ColumnByFieldName("Partida").Width = 55
        'Grid.Columns.ColumnByFieldName("OT").Width = 40
        'Grid.Columns.ColumnByFieldName("OTSICY").Width = 40
        'Grid.Columns.ColumnByFieldName("Cliente").Width = 150
        'Grid.Columns.ColumnByFieldName("STATUS").Width = 90
        'Grid.Columns.ColumnByFieldName("PedidoSAY").Width = 45
        'Grid.Columns.ColumnByFieldName("PedidoSICY").Width = 55
        'Grid.Columns.ColumnByFieldName("FechaEntregaProgramacion").Width = 80
        'Grid.Columns.ColumnByFieldName("FechaPreparacion").Width = 80
        'Grid.Columns.ColumnByFieldName("Cantidad").Width = 60
        'Grid.Columns.ColumnByFieldName("Confirmados").Width = 60
        'Grid.Columns.ColumnByFieldName("PorConfirmar").Width = 60
        'Grid.Columns.ColumnByFieldName("UsuarioCaptura").Width = 70
        'Grid.Columns.ColumnByFieldName("FechaCaptura").Width = 70
        'Grid.Columns.ColumnByFieldName("MotivoCancelacion").Width = 100
        'Grid.Columns.ColumnByFieldName("BE").Width = 30
        'Grid.Columns.ColumnByFieldName("Cita").Width = 30
        'Grid.Columns.ColumnByFieldName("FechaCitaEntrega").Width = 140
        'Grid.Columns.ColumnByFieldName("FechaCaptura").Width = 80
        'Grid.Columns.ColumnByFieldName("UsuarioCaptura").Width = 90
        'Grid.Columns.ColumnByFieldName("FechaConfirmo").Width = 140
        'Grid.Columns.ColumnByFieldName("Artículo").Width = 200
        'Grid.Columns.ColumnByFieldName("Proceso").Width = 60

        Grid.Columns.ColumnByFieldName("OT").Caption = "OT " & vbCrLf & "SAY"
        Grid.Columns.ColumnByFieldName("OTSICY").Caption = "OT " & vbCrLf & "SICY"
        Grid.Columns.ColumnByFieldName("PedidoSAY").Caption = "Pedido " & vbCrLf & "SAY"
        Grid.Columns.ColumnByFieldName("PedidoSICY").Caption = "Pedido " & vbCrLf & "SICY"
        Grid.Columns.ColumnByFieldName("FechaEntregaProgramacion").Caption = "F Entrega"
        Grid.Columns.ColumnByFieldName("FechaPreparacion").Caption = "F Preparación"

        Grid.Columns.ColumnByFieldName("OTSICY").Visible = False

        If TipoPerfil = 1 Or TipoPerfil = 4 Then
            Grid.Columns.ColumnByFieldName("UsuarioCaptura").Caption = "Capturó"
            Grid.Columns.ColumnByFieldName("OperadorAsignado").Visible = False
            Grid.Columns.ColumnByFieldName("OperadorConfirmo").Visible = False
        Else
            Grid.Columns.ColumnByFieldName("UsuarioCaptura").Caption = "Proyectó"
            Grid.Columns.ColumnByFieldName("OperadorAsignado").Visible = True
            Grid.Columns.ColumnByFieldName("OperadorConfirmo").Visible = True
        End If


        Grid.Columns.ColumnByFieldName("FechaCaptura").Caption = "F Captura"
        Grid.Columns.ColumnByFieldName("FechaCitaEntrega").Caption = "F Cita"
        Grid.Columns.ColumnByFieldName("MotivoCancelacion").Caption = "Motivo Cancelación"
        Grid.Columns.ColumnByFieldName("UsuarioModifico").Caption = "Modificó "
        Grid.Columns.ColumnByFieldName("FechaModificacion").Caption = "F Modificación "
        Grid.Columns.ColumnByFieldName("DiasFaltantes").Caption = "Días P"
        Grid.Columns.ColumnByFieldName("EstatusPartida").Caption = "Estatus OT" & vbCrLf & "Partida "
        Grid.Columns.ColumnByFieldName("TipoOT").Caption = "Tipo"

        Grid.Columns.ColumnByFieldName("OperadorAsignado").Caption = "Asignado "
        Grid.Columns.ColumnByFieldName("OperadorConfirmo").Caption = "Confirmó "
        Grid.Columns.ColumnByFieldName("FechaConfirmo").Caption = "F Confirmo "
        Grid.Columns.ColumnByFieldName("FechaCancelo").Caption = "F Cancelo "

        Grid.Columns.ColumnByFieldName("Cantidad").Caption = "Cantidad"
        Grid.Columns.ColumnByFieldName("Confirmados").Caption = "Confirmado"
        Grid.Columns.ColumnByFieldName("PorConfirmar").Caption = "Por " & vbCrLf & "Confirmar"
        Grid.Columns.ColumnByFieldName("Cancelados").Caption = "Cancelado"
        Grid.Columns.ColumnByFieldName("ParesEntregados").Caption = "Entregados"

        Grid.Columns.ColumnByFieldName("Seleccionar").Caption = " "
        Grid.Columns.ColumnByFieldName("ColorEstatus").Caption = " "

        'Grid.Columns.ColumnByFieldName("Cantidad").Width = 60
        'Grid.Columns.ColumnByFieldName("Confirmados").Width = 70
        'Grid.Columns.ColumnByFieldName("PorConfirmar").Width = 60
        'Grid.Columns.ColumnByFieldName("Cancelados").Width = 60
        'Grid.Columns.ColumnByFieldName("ParesEntregados").Width = 60
        'Grid.Columns.ColumnByFieldName("STATUS").Caption = "Status"
        'Grid.Columns.ColumnByFieldName("Agente").Width = 70
        'Grid.Columns.ColumnByFieldName("EstatusPartida").Width = 125
        'Grid.Columns.ColumnByFieldName("STATUS").Width = 125



        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(Grid.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
            Grid.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Cantidad"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If


        If IsNothing(Grid.Columns("Confirmados").Summary.FirstOrDefault(Function(x) x.FieldName = "Confirmados")) = True Then
            Grid.Columns("Confirmados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Confirmados"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item2)

        End If

        If IsNothing(Grid.Columns("PorConfirmar").Summary.FirstOrDefault(Function(x) x.FieldName = "PorConfirmar")) = True Then
            Grid.Columns("PorConfirmar").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:N0}")

            Dim item3 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item3.FieldName = "PorConfirmar"
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item3.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item3)
        End If

        If IsNothing(Grid.Columns("Cancelados").Summary.FirstOrDefault(Function(x) x.FieldName = "Cancelados")) = True Then
            Grid.Columns("Cancelados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:N0}")

            Dim item4 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item4.FieldName = "Cancelados"
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item4.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item4)
        End If

        If IsNothing(grdVentas.Columns("ParesEntregados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesEntregados")) = True Then
            grdVentas.Columns("ParesEntregados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesEntregados", "{0:N0}")
            Dim item5 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item5.FieldName = "Entregados"
            item5.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item5.DisplayFormat = "{0}"
            grdVentas.GroupSummary.Add(item5)
        End If
        'If IsNothing(Grid.Columns("Proceso").Summary.FirstOrDefault(Function(x) x.FieldName = "Proceso")) = True Then
        '    Grid.Columns("Proceso").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Proceso", "{0:N0}")
        '    Dim item4 As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item4.FieldName = "Proceso"
        '    item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item4.DisplayFormat = "{0}"
        '    Grid.GroupSummary.Add(item4)
        'End If

        Grid.Columns.ColumnByFieldName("FechaConfirmo").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        'Grid.Columns.ColumnByFieldName("ColorEstatus").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Partida").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("EstatusPartida").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("OperadorAsignado").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("OperadorConfirmo").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaCancelo").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaConfirmo").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("OT").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("OTSICY").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Agente").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("STATUS").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("TipoOT").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("PedidoSAY").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("PedidoSICY").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("OrdenCliente").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaEntregaProgramacion").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaPreparacion").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Confirmados").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("PorConfirmar").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Cancelados").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("ParesEntregados").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("UsuarioCaptura").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaCaptura").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Cita").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("UsuarioModifico").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaModificacion").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("DiasFaltantes").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("BE").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("MotivoCancelacion").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("EstatusID").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("ClienteSAYID").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaCitaEntrega").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("HoraCita").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("ClaveCitaEntrega").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("TotalPersonasRequeridas").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("UsuarioAgregoCita").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("FechaCapturoCita").OptionsColumn.AllowEdit = False
        'Grid.Columns.ColumnByFieldName("Proceso").OptionsColumn.AllowEdit = False

        Grid.Columns.ColumnByFieldName("FechaCitaEntrega").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaCapturoCita").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaConfirmo").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaCaptura").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaModificacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Grid.Columns.ColumnByFieldName("FechaCancelo").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"


        'Grid.Columns.ColumnByFieldName("FechaCancelo").Width = 140
        'Grid.Columns.ColumnByFieldName("FechaCaptura").Width = 140
        'Grid.Columns.ColumnByFieldName("FechaModificacion").Width = 140
        ' grdVentas.Columns.ColumnByFieldName("DiasFaltantes").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Grid.Columns.ColumnByFieldName("MotivoCancelacion").Visible = False

    End Sub


    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVentas.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click, Button5.Click

        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasAutorizadas As Integer = 0
        Dim FilaYaAutorizada As Integer = 0
        Dim FilaCancelada As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim FilasCoppel As Integer = 0

        Dim FilasAceptar As Integer = 0
        Dim EstatusID As Integer = 0
        Dim ClienteID As Integer = 0
        Dim OrdenTrabajoCadena As String = String.Empty
        Dim OrdenTrabajoSplit As String()
        Dim ListaOTYistiAutorizadas As New List(Of Entidades.OrdenTrabajo)
        Dim OTYISTI As Entidades.OrdenTrabajo

        Dim TotalPares As Integer = 0
        Dim ParesOT As Integer = 0
        Dim ParesCancelados As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    FilasSeleccionadas += 1

                    EstatusID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID"))
                    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID"))

                    If (EstatusID = "119" Or EstatusID = "130") And ClienteID <> 763 Then
                        FilasAceptar += 1
                        If OrdenTrabajoCadena = String.Empty Then
                            OrdenTrabajoCadena = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        Else
                            OrdenTrabajoCadena = OrdenTrabajoCadena & "," & grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        End If

                        ParesOT = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cantidad").ToString())
                        If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cancelados").ToString()) = False Then
                            ParesCancelados = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cancelados").ToString()
                        Else
                            ParesCancelados = 0
                        End If



                        ''Cliente YISTI
                        If ClienteID = 1132 Then
                            OTYISTI = New Entidades.OrdenTrabajo
                            OTYISTI.OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            OTYISTI.TotalPares = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cantidad").ToString()

                            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cancelados").ToString()) = False Then
                                OTYISTI.TotalParesCancelados = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cancelados").ToString()
                            End If

                            OTYISTI.Cliente = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cliente").ToString()
                            OTYISTI.OrdenCliente = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OrdenCliente").ToString()
                            OTYISTI.FechaPreparacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion").ToString()
                            OTYISTI.PedidoSAYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "PedidoSAY").ToString()
                            OTYISTI.PedidoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "PedidoSICY").ToString()

                            ListaOTYistiAutorizadas.Add(OTYISTI)
                        End If

                    End If

                    If ClienteID = 763 Then
                        FilasCoppel += 1
                    End If

                End If
            Next


            If FilasSeleccionadas = 0 Then
                show_message("Advertencia", "No hay Filas Seleccionadas.")
            Else
                If FilasAceptar = 0 And FilasCoppel = 0 Then
                    show_message("Advertencia", "Solo se pueden autorizar las OTs en estatus de activo.")
                ElseIf FilasAceptar = 0 And FilasCoppel > 0 Then
                    show_message("Advertencia", "Solo se pueden autorizar las OTs en estatus de activo y que no sean de COPPEL.")
                ElseIf FilasAceptar > 0 Then

                    confirmar.mensaje = "Se autorizarán " + FilasAceptar.ToString + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas. ¿Esta seguro de continuar?"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor

                        OrdenTrabajoSplit = Split(OrdenTrabajoCadena, ",")

                        For Each OTId As String In OrdenTrabajoSplit
                            objBU.AutorizarOT(CInt(OTId), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        Next
                        Cursor = Cursors.WaitCursor
                        ObtenerInformacion()

                        If ListaOTYistiAutorizadas.Count > 0 Then
                            EnviarCorreoYisti(ListaOTYistiAutorizadas)
                        End If

                        show_message("Exito", "Se han autorizado " + FilasAceptar.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs.")

                        Cursor = Cursors.Default
                    End If
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


        'Dim NumeroFilas As Integer = 0
        'Dim FilasSeleccionadas As Integer = 0
        'Dim FilasAutorizadas As Integer = 0
        'Dim FilaYaAutorizada As Integer = 0
        'Dim FilaCancelada As Integer = 0
        'Dim confirmar As New Tools.ConfirmarForm
        'Dim FilasCoppel As Integer = 0

        'Try

        '    confirmar.mensaje = "¿Esta seguro de confirmar la OT?"
        '    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '        Cursor = Cursors.WaitCursor
        '        NumeroFilas = grdVentas.DataRowCount
        '        For index As Integer = 0 To NumeroFilas Step 1
        '            If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then

        '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 Then 'COPPEL
        '                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 129 Then 'Cancelado o Rezhazado
        '                        FilaCancelada += 1
        '                    ElseIf CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) > 120 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 Then
        '                        FilaYaAutorizada += 1
        '                    End If

        '                    'If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) > 120 Then 'Confirmado ventas
        '                    '    FilaYaAutorizada += 1
        '                    'End If

        '                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 119 Or CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 130 Then 'Confirmado ventas
        '                        objBU.AutorizarOT(CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT")), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '                        FilasAutorizadas += 1
        '                    End If
        '                Else
        '                    FilasCoppel += 1
        '                End If


        '                FilasSeleccionadas += 1
        '            End If
        '        Next

        '        If FilasSeleccionadas = 0 Then
        '            show_message("Advertencia", "No hay Filas Seleccionadas")
        '        Else

        '            If FilasSeleccionadas = 1 Then
        '                If FilasAutorizadas = 1 Then
        '                    ObtenerInformacion()
        '                    show_message("Exito", "Se han autorizado " + FilasAutorizadas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs.")

        '                ElseIf FilaCancelada = 1 Then
        '                    show_message("Advertencia", "La OT se encuentra cancelado o rechazada.")
        '                ElseIf FilasCoppel = 1 Then
        '                    show_message("Advertencia", "Las OTs de COPPEL son solo para consulta.")
        '                Else
        '                    If FilaYaAutorizada = 1 Then
        '                        show_message("Advertencia", "La OT ya se encuentra autorizada.")
        '                    Else
        '                        show_message("Advertencia", "Solo se pueden autorizar las OTs en estatus de Activo.")
        '                    End If

        '                End If

        '            Else

        '                If FilasAutorizadas = FilasSeleccionadas Then
        '                    ObtenerInformacion()
        '                    show_message("Exito", "Se han autorizado: " + FilasAutorizadas.ToString().Trim() + " de " + FilasSeleccionadas.ToString() + " OTs.")
        '                Else
        '                    If FilasAutorizadas = 0 Then
        '                        show_message("Advertencia", "No se han autorizado las OTs, asegurarse que las OTs a autorizar se encuentren en estatus de Activo.")
        '                    Else
        '                        ObtenerInformacion()
        '                        show_message("Exito", "Se han autorizado: " + FilasAutorizadas.ToString().Trim() + " de " + FilasSeleccionadas.ToString().Trim() + " OTs.")
        '                    End If

        '                End If

        '            End If

        '        End If

        '    End If

        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    show_message("Error", ex.Message.ToString())
        'End Try

    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click

        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasRechazadasAnteriormente As Integer = 0
        Dim FilasYaCanceladas As Integer = 0
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim dtResultadoVerificaPartidas As New DataTable
        Dim otSeleccionadas As String = String.Empty
        Dim mensajePartidasNoRechazables As String = String.Empty
        Dim partidasNoRechazables As String = String.Empty
        Dim confirmacion As New Tools.ConfirmarForm
        confirmacion.mensaje = String.Empty
        Dim totalParesConfirmados As Integer = 0
        Dim dtResultadoRechazoOT As New DataTable
        Dim splitOtSeleccionadas As New List(Of String)
        Dim filasCoppel As Integer = 0
        Dim FilasOTDesasignacion As Integer = 0
        Dim ventanaMotivoRechazo As New MotivoRechazoOT_Form()
        Dim OTSeleccionada As Integer = 0
        Dim DTParesconfirmadosOT As DataTable
        Dim FilasNoRechazarOTDesasignacion As Integer = 0

        Try
            Cursor = Cursors.WaitCursor

            NumeroFilas = grdVentas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 122 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 125 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 126 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 127 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 128 And grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FA") <> "SI" Then
                    FilasSeleccionadas += 1

                    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "TipoOT").ToString() = "DESASIGNACION" Then
                        OTSeleccionada = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString())
                        DTParesconfirmadosOT = objBU.ParesConfirmadosOT(OTSeleccionada)
                        If DTParesconfirmadosOT.Rows.Count > 0 Then
                            If CInt(DTParesconfirmadosOT.Rows(0).Item(0)) > 0 Then
                                FilasOTDesasignacion += 1
                            Else
                                If otSeleccionadas <> "" Then
                                    otSeleccionadas += ","
                                End If
                                otSeleccionadas += grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            End If
                        End If

                    Else
                        If otSeleccionadas <> "" Then
                            otSeleccionadas += ","
                        End If
                        otSeleccionadas += grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        'FilasSeleccionadas += 1
                        totalParesConfirmados += CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Confirmados"))
                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 129 Or CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 130 Then
                            FilasRechazadasAnteriormente += 1
                        End If
                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) = 763 Then
                            filasCoppel += 1
                        End If
                    End If

                End If
            Next

            If FilasSeleccionadas > 0 Then
                If FilasRechazadasAnteriormente = 0 And FilasOTDesasignacion = 0 Then
                    If filasCoppel = 0 Then
                        dtResultadoVerificaPartidas = objBU.VerificarPartidasAntesRechazarOT(otSeleccionadas)

                        If dtResultadoVerificaPartidas.Rows.Count > 0 Then
                            For Each row As DataRow In dtResultadoVerificaPartidas.Rows
                                If mensajePartidasNoRechazables <> "" Then
                                    mensajePartidasNoRechazables += ","
                                End If
                                mensajePartidasNoRechazables += " " + row.Item("idotsay").ToString()
                            Next

                            If dtResultadoVerificaPartidas.Rows.Count > 1 Then
                                confirmacion.mensaje = "Las OTs: " + mensajePartidasNoRechazables + " tienen entregas facturadas o por facturar las, se rechazará parcialmente. ¿Desea continuar?"
                            Else
                                confirmacion.mensaje = "La OT: " + mensajePartidasNoRechazables + " tiene " + partidasNoRechazables + " entrega(s) facturada(s) o por facturar, se rechazarán parcialmente. ¿Desea continuar?"
                            End If
                            If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                ventanaMotivoRechazo.totalParesConfirmados = totalParesConfirmados
                                ventanaMotivoRechazo.FilasSeleccionadas = FilasSeleccionadas
                                ventanaMotivoRechazo.ventanaAdmonOT = Me
                                ventanaMotivoRechazo.lblNumOTRechazar.Text = FilasSeleccionadas.ToString()
                                ventanaMotivoRechazo.otSeleccionadas = otSeleccionadas
                                ventanaMotivoRechazo.dtResultadoVerificaPartidas = dtResultadoVerificaPartidas
                                ventanaMotivoRechazo.ShowDialog()

                            End If
                        Else
                            ventanaMotivoRechazo.totalParesConfirmados = totalParesConfirmados
                            ventanaMotivoRechazo.FilasSeleccionadas = FilasSeleccionadas
                            ventanaMotivoRechazo.ventanaAdmonOT = Me
                            ventanaMotivoRechazo.lblNumOTRechazar.Text = FilasSeleccionadas.ToString()
                            ventanaMotivoRechazo.otSeleccionadas = otSeleccionadas
                            ventanaMotivoRechazo.dtResultadoVerificaPartidas = dtResultadoVerificaPartidas
                            ventanaMotivoRechazo.ShowDialog()

                        End If

                    Else
                        show_message("Advertencia", "No se pueden rechazar OT de Coppel, verifique por favor.")
                    End If
                Else
                    show_message("Advertencia", "No se pueden rechazar OT rechazadas, canceladas anteriormente o de desasignación con pares confirmados, verifique por favor.")
                End If
            Else
                show_message("Advertencia", "No hay OTs seleccionadas que se puedan rechazar. (No Activas, en Ejecución, Por Facturar, Facturadas, En Ruta o Entregadas).")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

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
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                Resultado += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        Return Resultado
    End Function

    Private Function ObtenerFiltroFecha() As Integer
        Dim Resultado As Integer = 0
        ' 1 => Captura, 2 =>Aurizacion, 3 => Preparacion, 4 => Entrega, 5 => Confirmacion
        If chkFecha.Checked = True Then
            If rdoCaptura.Checked = True Then
                Resultado = 1
            ElseIf rdoAutorizacion.Checked = True Then
                Resultado = 2
            ElseIf rdoPreparacion.Checked = True Then
                Resultado = 3
            ElseIf rdoEntrega.Checked = True Then
                Resultado = 4
            ElseIf rdoConfirmacion.Checked = True Then
                Resultado = 5
            End If
        Else
            Resultado = 0
        End If

        Return Resultado
    End Function


    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click


        grdPedidoSAY.DataSource = Nothing
        grdPedidoSICY.DataSource = Nothing
        grdFolioOT.DataSource = Nothing

        If EsYISTI = False Then
            grdCliente.DataSource = Nothing
        End If


        grdTienda.DataSource = Nothing
        grdAtnClientes.DataSource = Nothing
        grdFiltroAgenteVentas.DataSource = Nothing
        grdStatusPedido.DataSource = Nothing
        grdMarca.DataSource = Nothing
        grdColeccion.DataSource = Nothing
        grdModelo.DataSource = Nothing
        grdPiel.DataSource = Nothing
        grdColor.DataSource = Nothing
        grdCorrida.DataSource = Nothing
        grdOperador.DataSource = Nothing

        grdOts.DataSource = Nothing
        chboxClienteCitaSi.Checked = True
        chboxClienteCitaNo.Checked = True
        chkSurtido.Checked = True
        chkDesasignacion.Checked = True


        rdoAutorizacion.Checked = False
        rdoPreparacion.Checked = False
        rdoEntrega.Checked = False
        rdoConfirmacion.Checked = False
        rdoCaptura.Checked = True

        chboxSeleccionarTodo.Checked = False
        lblTotalSeleccionados.Text = "0"

    End Sub

    Private Sub GenerarArchivo(ByVal DTInformacion As DataTable)
        Dim fecha As String = Date.Now.ToString("ddMMyyyHmm")
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty
        Dim RutaDescarga As String = String.Empty
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim CodigoAtado As String = String.Empty


        Try
            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim ret As DialogResult = .ShowDialog
                If ret = Windows.Forms.DialogResult.OK Then
                    RutaDescarga = .SelectedPath
                Else
                    RutaDescarga = String.Empty
                End If

                .Dispose()
            End With

            If RutaDescarga <> String.Empty Then
                'DTInfoIDSE.Rows(0).Item("APaterno")

                For Each Fila As DataRow In DTInformacion.Rows

                    If CodigoAtado = String.Empty Then
                        CodigoAtado = Fila.Item("ID_Docena").ToString()
                        informacion = CodigoAtado & vbCrLf
                        informacion += Fila.Item("CodigoAndrea").ToString() & vbCrLf
                    Else
                        If CodigoAtado <> Fila.Item("ID_Docena").ToString() Then
                            CodigoAtado = Fila.Item("ID_Docena").ToString()
                            informacion += CodigoAtado & vbCrLf
                            informacion += Fila.Item("CodigoAndrea").ToString() & vbCrLf
                        Else
                            informacion += Fila.Item("CodigoAndrea").ToString() & vbCrLf
                        End If
                    End If


                Next

                archivoTXT = RutaDescarga & "\INV.txt"

                If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
                    crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
                End If


                File.WriteAllText(archivoTXT, informacion.ToUpper)

                Dim exito As New ExitoForm
                exito.mensaje = "Se ha generado el archivo correctamente en la ruta: " & archivoTXT.Trim()
                exito.ShowDialog()

            Else
                Dim exito As New ErroresForm
                exito.mensaje = "Se debe de seleccionar una ruta para la ubicación del archivo."
                exito.ShowDialog()
            End If

        Catch ex As Exception
            Dim exito As New ErroresForm
            exito.mensaje = "No se pudo generar el archivo."
            exito.ShowDialog()
        End Try
    End Sub


    'Private Sub GenerarArchivo(ByVal DTInformacion As DataTable)
    '    Dim fecha As String = Date.Now.ToString("ddMMyyyHmm")
    '    Dim archivoTXT As String = String.Empty
    '    Dim informacion As String = String.Empty
    '    Dim RutaDescarga As String = String.Empty
    '    Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
    '    Dim fbdUbicacionArchivo As New FolderBrowserDialog
    '    Dim CodigoAtado As String = String.Empty


    '    Try
    '        With fbdUbicacionArchivo
    '            .Reset()
    '            .Description = " Seleccione una carpeta "
    '            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    '            .ShowNewFolderButton = True
    '            Dim ret As DialogResult = .ShowDialog
    '            If ret = Windows.Forms.DialogResult.OK Then
    '                RutaDescarga = .SelectedPath
    '            Else
    '                RutaDescarga = String.Empty
    '            End If

    '            .Dispose()
    '        End With

    '        If RutaDescarga <> String.Empty Then
    '            'DTInfoIDSE.Rows(0).Item("APaterno")

    '            For Each Fila As DataRow In DTInformacion.Rows

    '                If CodigoAtado = String.Empty Then
    '                    CodigoAtado = Fila.Item("CodigoAtado").ToString()
    '                    informacion = CodigoAtado & vbCrLf
    '                Else
    '                    If CodigoAtado <> Fila.Item("CodigoAtado").ToString() Then
    '                        CodigoAtado = Fila.Item("CodigoAtado").ToString()
    '                        informacion += CodigoAtado & vbCrLf
    '                    End If
    '                End If

    '                informacion += Fila.Item("CodigoPar").ToString() & vbCrLf
    '            Next

    '            archivoTXT = RutaDescarga & "\INV.txt"

    '            If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
    '                crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
    '            End If


    '            File.WriteAllText(archivoTXT, informacion.ToUpper)

    '            Dim exito As New ExitoForm
    '            exito.mensaje = "Se ha generado el archivo correctamente en la ruta: " & archivoTXT.Trim()
    '            exito.ShowDialog()

    '        Else
    '            Dim exito As New ErroresForm
    '            exito.mensaje = "Se debe de seleccionar una ruta para la ubicación del archivo."
    '            exito.ShowDialog()
    '        End If

    '    Catch ex As Exception
    '        Dim exito As New ErroresForm
    '        exito.mensaje = "No se pudo generar el archivo."
    '        exito.ShowDialog()
    '    End Try
    'End Sub

    Public Sub crearCarpeta(ByVal ruta As String)
        System.IO.Directory.CreateDirectory(ruta)
    End Sub

    Public Function existeArchivo(ByVal archivo As String) As Boolean
        If Dir(archivo) = vbNullString Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnGenerarArchivo_Click(sender As Object, e As EventArgs) Handles btnGenerarArchivo.Click

        Dim punto As Point
        punto.X = btnGenerarArchivo.Location.X + btnGenerarArchivo.Width
        punto.Y = btnGenerarArchivo.Location.Y + btnGenerarArchivo.Height
        cmsGenerarXML.Show(punto)



    End Sub

    Private Sub GenerarXml(ByVal DTInformacion As DataTable)
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim RutaDescarga As String = String.Empty
        Dim ArchivoXml As String = String.Empty
        Dim TotalPares As Integer = 0
        Dim CodigosAndrea As Integer = 0
        Dim Atado As String = String.Empty
        Dim CantidadPares As Integer = 0

        Try
            Dim ret As DialogResult = fbdUbicacionArchivo.ShowDialog
            If ret = Windows.Forms.DialogResult.OK Then
                RutaDescarga = fbdUbicacionArchivo.SelectedPath
            Else
                RutaDescarga = String.Empty
            End If


            If RutaDescarga <> String.Empty Then
                ArchivoXml = RutaDescarga & "\descarga.xml"

                Dim writer As New XmlTextWriter(ArchivoXml, System.Text.Encoding.UTF8)

                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                writer.WriteStartElement("NewDataSet")

                For Each Fila As DataRow In DTInformacion.Rows
                    Atado = Fila.Item("CodigoAtado").ToString()
                    CantidadPares = CInt(Fila.Item("Cantidad").ToString())
                    TotalPares += CantidadPares
                    CodigosAndrea += 1
                    createNode(Atado, CantidadPares, "N/A", writer)
                Next
                createNode(CodigosAndrea, TotalPares, "240", writer)
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()

                'Realizar una copia del archivo xml
                System.IO.File.Copy(ArchivoXml, RutaDescarga & "\descarga1.xml", True)

                Dim exito As New ExitoForm
                exito.mensaje = "Se ha generado el archivo correctamente en la ruta: " & ArchivoXml.Trim()
                exito.ShowDialog()
            Else
                Dim exito As New ErroresForm
                exito.mensaje = "Se debe de seleccionar una ruta para la ubicación del archivo."
                exito.ShowDialog()
            End If

        Catch ex As Exception
            Dim exito As New ErroresForm
            exito.mensaje = "No se pudo generar el archivo."
            exito.ShowDialog()
        End Try


    End Sub

    Private Sub createNode(ByVal CodigoAndrea As String, ByVal Cantidad As String, ByVal Pasillo As String, ByVal writer As XmlTextWriter)
        writer.WriteStartElement("Captura")
        writer.WriteStartElement("Alternativa")
        writer.WriteString(CodigoAndrea)
        writer.WriteEndElement()
        writer.WriteStartElement("Cantidad")
        writer.WriteString(Cantidad)
        writer.WriteEndElement()
        writer.WriteStartElement("Pasillo")
        writer.WriteString(Pasillo)
        writer.WriteEndElement()
        writer.WriteEndElement()
    End Sub

    Private Sub btnGenerarXML_Click(sender As Object, e As EventArgs) Handles btnGenerarXML.Click

        'Dim DTInformacion As DataTable
        'DTInformacion = objBU.ConsultarCodigosAndreaXml(22, 1126)
        'GenerarXml(DTInformacion)
    End Sub



    Private Sub btnVerDetallesApartados_Click(sender As Object, e As EventArgs) Handles btnVerDetallesApartados.Click, btnDetalles.Click

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim Form As New DetallesOrdenTrabajoForm

        Try

            If Not validarSeleccionGrid() Then
                show_message("Advertencia", "Debe seleccionar solo OTs que son Facturación Anticipada o seleccionar solo OTs que no sean Facturación Anticipada")
                Return
            End If

            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroOrdenesTrabajo += 1
                    If OrdenTrabajoID = String.Empty Then
                        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID").ToString() = 763 Then
                            'mensaje para órdenes de trabajo Coppel
                            show_message("Advertencia", "Solo puede consultar los detalles de la OT " + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString() + " en el menú Almacén – OT Coppel – Órdenes de Trabajo Coppel")
                            Exit Sub
                        Else
                            OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                        End If
                    Else
                        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID").ToString() = 763 Then
                            'mensaje para órdenes de trabajo Coppel
                            show_message("Advertencia", "Solo puede consultar los detalles de la OT " + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString() + " en el menú Almacén – OT Coppel – Órdenes de Trabajo Coppel")
                            Exit Sub
                        Else
                            OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                        End If

                    End If
                End If
            Next

            If OrdenTrabajoID <> String.Empty Then
                Form.OrdenTrabajoID = OrdenTrabajoID
                Form.OrdenTrabajoSICYID = OrdenTrabajoSICYID
                Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
                Form.EsConfirmacion = False
                Form.EsCancelacion = False
                Form.MdiParent = Me.MdiParent
                Form.Show()
            Else
                show_message("Advertencia", "No se ha seleccionado una OT.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub grdOts_Click(sender As Object, e As EventArgs) Handles grdOts.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasAutorizadas As Integer = 0
        Dim FilaYaAutorizada As Integer = 0
        Dim FilaCancelada As Integer = 0


        NumeroFilas = grdVentas.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                NumeroFilas += 1
            End If
        Next

        'lblTotalSeleccionados.Text = NumeroFilas.ToString()

    End Sub



    Private Sub grdOts_MouseClick(sender As Object, e As MouseEventArgs) Handles grdOts.MouseClick
        Dim NumeroClientes As Integer = 0
        Dim ClienteID As Integer = 0
        Dim AltaCita As New AltaCitaEntregaForm
        'Dim FechaEntrega As Date
        Dim TieneCita As Integer = 0
        Dim FechaNula As Date = Nothing
        Dim ClientesBloqueados As Integer = 0
        Dim NumeroSeleccionados As Integer = 0
        Dim FilasAsignacionOperador As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasParaAutorizar As Integer = 0
        Dim FilasParaAceptar As Integer = 0
        Dim FilasCoppel As Integer = 0
        Dim FilasDesasignarOperador As Integer = 0
        Dim FilasAndrea As Integer = 0

        Dim FilasAgregarCita As Integer = 0
        Dim EstatusID As Integer = 0
        Dim FechaCita As Date
        Dim filasFechaPreparacion As Integer = 0
        Dim FilasObservaciones As Integer = 0
        Dim FilasQuitarObservaciones As Integer = 0
        Dim FilasAceptarOT As Integer = 0
        Dim FilasOperadorAbierto As Integer = 0
        Dim FilasDesasignarOperadorAbierto As Integer = 0
        Dim ObservacionesCita As String = String.Empty
        Dim DesasignarOperador As String = String.Empty
        Dim TextoTieneCita As String = String.Empty
        Dim TipoOT As String = String.Empty

        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then

                If chkDetallada.Checked = True Then
                    Return
                End If

                Cursor = Cursors.WaitCursor

                ListaIndicesCita.Clear()
                ListaIndicesBloqueadosCita.Clear()

                ' Add the selected rows to the list.
                Dim I As Integer
                For I = 0 To grdVentas.RowCount - 1

                    If grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(I)) = True Then
                        FilasSeleccionadas += 1
                        ObservacionesCita = String.Empty
                        DesasignarOperador = String.Empty
                        TextoTieneCita = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cita")

                        EstatusID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString())
                        ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID"))
                        TipoOT = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "TipoOT")

                        If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Observaciones")) = False Then
                            ObservacionesCita = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Observaciones")
                        End If

                        If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OperadorAsignados")) = False Then
                            DesasignarOperador = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OperadorAsignados")
                        End If

                        'Agregar Cita y Modificar Cita
                        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cita") = "SI" And (EstatusID <> "128") And ClienteID <> "763" And TipoOT <> "DESASIGNACION" Then
                            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega")) = False Then
                                FechaCita = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega").ToString()
                                TieneCita += 1
                            End If
                            FilasAgregarCita += 1
                            ListaIndicesCita.Add(I)
                        End If

                        'Cliente Coppel
                        If ClienteID = "763" Then
                            FilasCoppel += 1
                        End If

                        'Autorizar OT Ventas
                        If (EstatusID = "119" Or EstatusID = "130") And ClienteID <> "763" Then
                            FilasParaAutorizar += 1
                        End If

                        'Agregar fecha Preparación
                        If (EstatusID = "119" Or EstatusID = "130") And ClienteID <> "763" And TipoOT <> "DESASIGNACION" Then
                            filasFechaPreparacion += 1
                        End If

                        'Observaciones OT
                        If (EstatusID <> "128" And EstatusID <> "129" And EstatusID <> "130") And ClienteID <> "763" And TextoTieneCita = "NO" And ObservacionesCita = String.Empty Then
                            FilasObservaciones += 1
                        End If

                        If EstatusID <> "128" And EstatusID <> "129" And EstatusID <> "130" And ClienteID <> "763" And ObservacionesCita <> String.Empty And TextoTieneCita = "NO" Then
                            FilasQuitarObservaciones += 1
                        End If

                        'Asignar Operador
                        If (EstatusID = "121" Or EstatusID = "123") And ClienteID <> "763" And ClienteID <> "816" And DesasignarOperador = String.Empty Then
                            FilasAsignacionOperador += 1
                        End If

                        'Aceptar OT
                        If EstatusID = "120" And ClienteID <> "763" Then
                            FilasAceptarOT += 1
                        End If

                        'Desasignar Operador
                        If (EstatusID = "121" Or EstatusID = "123") And ClienteID <> "763" And ClienteID <> "816" And DesasignarOperador <> String.Empty Then
                            FilasDesasignarOperador += 1
                        End If

                        'Asignar operador abierto
                        If (EstatusID = "121" Or EstatusID = "122" Or EstatusID = "123") And ClienteID = "816" Then
                            FilasOperadorAbierto += 1
                            FilasDesasignarOperadorAbierto += 1
                        End If

                    End If
                    'If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cita") = "SI" Then
                    '    If ClienteID = 0 Then
                    '        ClienteID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID").ToString()
                    '        If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega")) = False Then
                    '            FechaEntrega = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega").ToString()
                    '            TieneCita += 1
                    '        End If

                    '        NumeroClientes += 1
                    '        ListaIndicesCita.Add(I)

                    '    Else
                    '        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID").ToString() <> ClienteID Then
                    '            NumeroClientes += 1
                    '            ListaIndicesBloqueadosCita.Add(I)
                    '        Else
                    '            ListaIndicesCita.Add(I)
                    '            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega")) = False Then
                    '                FechaEntrega = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega").ToString()
                    '            End If
                    '        End If
                    '    End If




                    '    FilasSeleccionadas += 1

                    '    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "121" Or grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "123" Then
                    '        If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OperadorAsignados")) = False Then
                    '            FilasDesasignarOperador += 1
                    '        Else
                    '            FilasAsignacionOperador += 1
                    '        End If

                    '    End If

                    '    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "121" Or grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "122" Or grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "123" Then
                    '        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID")) = 816 Then 'Andrea
                    '            FilasAndrea += 1
                    '        End If

                    '    End If


                    '    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID")) = 763 Then 'COPPEL
                    '        FilasCoppel += 1
                    '    End If

                    '    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "119" Then
                    '        FilasParaAutorizar += 1
                    '    End If

                    '    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "120" Then
                    '        FilasParaAceptar += 1
                    '    End If

                    '    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "128" Or grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "129" And grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "130" Then
                    '        ClientesBloqueados += 1
                    '        ListaIndicesBloqueadosCita.Add(I)
                    '    Else


                    '        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cita") = "SI" Then
                    '            If ClienteID = 0 Then
                    '                ClienteID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID").ToString()
                    '                If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega")) = False Then
                    '                    FechaEntrega = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega").ToString()
                    '                    TieneCita += 1
                    '                End If

                    '                NumeroClientes += 1
                    '                ListaIndicesCita.Add(I)

                    '            Else
                    '                If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID").ToString() <> ClienteID Then
                    '                    NumeroClientes += 1
                    '                    ListaIndicesBloqueadosCita.Add(I)
                    '                Else
                    '                    ListaIndicesCita.Add(I)
                    '                    If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega")) = False Then
                    '                        FechaEntrega = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega").ToString()
                    '                    End If
                    '                End If
                    '            End If

                    '        Else
                    '            If ClienteID = 0 Then
                    '                ClienteID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID").ToString()
                    '                NumeroClientes += 1
                    '            Else
                    '                If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID").ToString() <> ClienteID Then
                    '                    NumeroClientes += 1
                    '                End If
                    '            End If
                    '        End If

                    '    End If


                    'End If

                Next

                If FilasAgregarCita > 0 Then
                    If FilasSeleccionadas = 1 And TieneCita > 0 Then
                        cmsSeleccionMultiple.Items(0).Visible = False
                        cmsSeleccionMultiple.Items(1).Visible = True
                    ElseIf FilasSeleccionadas > 1 And TieneCita > 0 Then
                        cmsSeleccionMultiple.Items(0).Visible = True
                        cmsSeleccionMultiple.Items(1).Visible = True
                    Else
                        cmsSeleccionMultiple.Items(0).Visible = True
                        cmsSeleccionMultiple.Items(1).Visible = False
                    End If
                Else
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = False
                End If

                If FilasParaAutorizar > 0 Then
                    cmsSeleccionMultiple.Items(3).Visible = True
                Else
                    cmsSeleccionMultiple.Items(3).Visible = False
                End If

                If filasFechaPreparacion > 0 Then
                    cmsSeleccionMultiple.Items(6).Visible = True
                Else
                    cmsSeleccionMultiple.Items(6).Visible = False
                End If


                If FilasObservaciones > 0 Then
                    cmsSeleccionMultiple.Items(10).Visible = True
                Else
                    cmsSeleccionMultiple.Items(10).Visible = False
                End If

                If FilasQuitarObservaciones > 0 Then
                    cmsSeleccionMultiple.Items(11).Visible = True
                Else
                    cmsSeleccionMultiple.Items(11).Visible = False
                End If



                If FilasAsignacionOperador > 0 Then
                    cmsSeleccionMultiple.Items(2).Visible = True
                Else
                    cmsSeleccionMultiple.Items(2).Visible = False
                End If

                If FilasAceptarOT > 0 Then
                    cmsSeleccionMultiple.Items(4).Visible = True
                Else
                    cmsSeleccionMultiple.Items(4).Visible = False
                End If

                If FilasDesasignarOperador > 0 Then
                    cmsSeleccionMultiple.Items(7).Visible = True
                Else
                    cmsSeleccionMultiple.Items(7).Visible = False
                End If

                If FilasOperadorAbierto > 0 Then
                    cmsSeleccionMultiple.Items(8).Visible = True
                    cmsSeleccionMultiple.Items(9).Visible = True
                Else
                    cmsSeleccionMultiple.Items(8).Visible = False
                    cmsSeleccionMultiple.Items(9).Visible = False
                End If


                If TipoPerfil = 1 Or TipoPerfil = 4 Then
                    cmsSeleccionMultiple.Items(2).Visible = False 'Asignar Operador
                    cmsSeleccionMultiple.Items(4).Visible = False 'Aceptar
                    cmsSeleccionMultiple.Items(7).Visible = False 'Desasignar operador
                    cmsSeleccionMultiple.Items(8).Visible = False 'Asignar Operador Abierto
                    cmsSeleccionMultiple.Items(9).Visible = False 'Desasignar Operador abierto
                Else
                    cmsSeleccionMultiple.Items(0).Visible = False 'Agregar Cita
                    cmsSeleccionMultiple.Items(1).Visible = False 'Modifcar cita
                    cmsSeleccionMultiple.Items(3).Visible = False 'Autorizar
                    cmsSeleccionMultiple.Items(6).Visible = False 'Agrega Fecha Preparacion
                    cmsSeleccionMultiple.Items(10).Visible = False 'Observaciones OT
                    cmsSeleccionMultiple.Items(11).Visible = False 'Eliminar OTs

                    If EsYISTI = True Then
                        cmsSeleccionMultiple.Items(2).Visible = False 'Asignar Operador
                        cmsSeleccionMultiple.Items(7).Visible = False 'Desasignar operador
                        cmsSeleccionMultiple.Items(8).Visible = False 'Asignar Operador Abierto
                        cmsSeleccionMultiple.Items(9).Visible = False 'Desasignar Operador abierto
                    End If
                End If

                cmsSeleccionMultiple.Show(Control.MousePosition)

                'If FilasParaAutorizar > 0 Then
                '    cmsSeleccionMultiple.Items(3).Visible = True
                '    cmsSeleccionMultiple.Items(6).Visible = True
                'Else
                '    cmsSeleccionMultiple.Items(3).Visible = False
                '    cmsSeleccionMultiple.Items(6).Visible = False
                'End If

                'If FilasParaAceptar > 0 Then
                '    cmsSeleccionMultiple.Items(4).Visible = True
                'Else
                '    cmsSeleccionMultiple.Items(4).Visible = False
                'End If

                'If FilasAsignacionOperador = 0 Then
                '    cmsSeleccionMultiple.Items(2).Visible = False
                'Else
                '    cmsSeleccionMultiple.Items(2).Visible = True
                'End If

                'If FilasDesasignarOperador = 0 Then
                '    cmsSeleccionMultiple.Items(7).Visible = False
                'Else
                '    cmsSeleccionMultiple.Items(7).Visible = True
                'End If

                ''Si es el mismo cliente
                'If NumeroClientes = 1 Then
                '    If ListaIndicesCita.Count > 0 Then
                '        If TieneCita > 0 Then
                '            cmsSeleccionMultiple.Items(0).Visible = False
                '            cmsSeleccionMultiple.Items(1).Visible = True
                '        Else
                '            cmsSeleccionMultiple.Items(0).Visible = True
                '            cmsSeleccionMultiple.Items(1).Visible = False
                '        End If
                '    Else
                '        cmsSeleccionMultiple.Items(0).Visible = False
                '        cmsSeleccionMultiple.Items(1).Visible = False
                '    End If

                'Else
                '    cmsSeleccionMultiple.Items(0).Visible = False
                '    cmsSeleccionMultiple.Items(1).Visible = False
                'End If


                'If TipoPerfil = 1 Then
                '    cmsSeleccionMultiple.Items(2).Visible = False 'Asignar Operador
                '    cmsSeleccionMultiple.Items(4).Visible = False 'Aceptar
                '    cmsSeleccionMultiple.Items(7).Visible = False 'Desasignar operador
                '    cmsSeleccionMultiple.Items(8).Visible = False
                '    cmsSeleccionMultiple.Items(9).Visible = False
                'Else
                '    cmsSeleccionMultiple.Items(0).Visible = False 'Agregar Cita
                '    cmsSeleccionMultiple.Items(1).Visible = False 'Modifcar cita
                '    cmsSeleccionMultiple.Items(3).Visible = False 'Autorizar
                '    cmsSeleccionMultiple.Items(6).Visible = False 'Agrega Fecha Preparacion
                '    cmsSeleccionMultiple.Items(10).Visible = False 'Observaciones OT
                '    cmsSeleccionMultiple.Items(11).Visible = False 'Eliminar OTs

                '    If FilasAndrea >= 1 Then
                '        cmsSeleccionMultiple.Items(8).Visible = True
                '        cmsSeleccionMultiple.Items(9).Visible = True
                '    Else
                '        cmsSeleccionMultiple.Items(8).Visible = False
                '        cmsSeleccionMultiple.Items(9).Visible = False
                '    End If

                'End If

                'If FilasSeleccionadas = 1 And FilasCoppel = 1 Then
                '    cmsSeleccionMultiple.Items(2).Visible = False
                '    cmsSeleccionMultiple.Items(3).Visible = False
                '    cmsSeleccionMultiple.Items(4).Visible = False
                '    cmsSeleccionMultiple.Items(6).Visible = False
                'End If


                'cmsSeleccionMultiple.Show(Control.MousePosition)



                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub SeleccionarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tmsiAgregarCita.Click
        EnviarInformacionCitaEntrega()
    End Sub


    Private Sub EnviarInformacionCitaEntrega()
        Dim NumeroClientes As Integer = 0
        Dim ClienteID As Integer = 0
        Dim NombreCliente As String = String.Empty
        Dim AltaCita As New AltaCitaEntregaForm
        Dim OrdenesTrabajo As String = String.Empty
        Dim TotalPares As Integer = 0
        Dim FechaEntrega As Date
        Dim PersonasDescarga As Integer = 0
        Dim Observaciones As String = 0
        Dim InsertarActualizatr As Integer = 0
        Dim Clave As String = String.Empty
        Dim ClientesBloqueados As Integer = 0
        Dim Resultado As DialogResult
        Dim FechaNula As Date = Nothing


        Try
            Cursor = Cursors.WaitCursor

            For Each I As Integer In ListaIndicesCita
                If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "128" Or grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "129" And grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID").ToString() = "130" Then
                    ClientesBloqueados += 1
                Else
                    If ClienteID = 0 Then
                        ClienteID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID").ToString()
                        NombreCliente = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cliente").ToString()
                        OrdenesTrabajo = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OT").ToString()
                        TotalPares = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cantidad").ToString() - grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cancelados").ToString()
                        If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega")) = False Then
                            FechaEntrega = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega").ToString()
                        Else
                            FechaEntrega = Nothing
                        End If

                        Clave = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClaveCitaEntrega").ToString()
                        PersonasDescarga = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "TotalPersonasRequeridas").ToString()
                        Observaciones = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Observaciones").ToString()

                        NumeroClientes += 1

                    Else
                        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID").ToString() <> ClienteID Then
                            NumeroClientes += 1

                        Else

                            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega")) = False Then
                                If FechaEntrega <> grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "FechaCitaEntrega") Then
                                    FechaEntrega = Nothing
                                End If

                                'FechaEntrega = GridView1.GetRowCellValue(GridView1.GetVisibleRowHandle(I), "FechaCitaEntrega").ToString()
                            Else
                                FechaEntrega = Nothing
                            End If

                            OrdenesTrabajo += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OT").ToString()
                            TotalPares += grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cantidad").ToString() - grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cancelados").ToString()



                            If Clave <> grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClaveCitaEntrega").ToString() Then
                                Clave = String.Empty
                            End If

                            If PersonasDescarga <> grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "TotalPersonasRequeridas").ToString() Then
                                PersonasDescarga = 0
                            End If

                            If Observaciones <> grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Observaciones").ToString() Then
                                Observaciones = String.Empty
                            End If

                        End If
                    End If
                End If



                'If (GridView1.GetSelectedRows()(I) >= 0) Then
                '    'Rows.Add(GridView1.GetDataRow(GridView1.GetSelectedRows()(I)))

                'End If
            Next



            If ListaIndicesCita.Count > 0 Then
                AltaCita.idOrdenesTrabajo = OrdenesTrabajo
                AltaCita.clienteNombre = NombreCliente
                AltaCita.totalPares = TotalPares
                If FechaEntrega = FechaNula Then
                    AltaCita.fechaEntrega = ""
                Else
                    AltaCita.fechaEntrega = FechaEntrega.ToString("0:MM/dd/yy H:mm:ss")
                End If

                AltaCita.clave = Clave
                AltaCita.personaParaDescarga = PersonasDescarga
                AltaCita.observaciones = Observaciones
                AltaCita.insertar_actualizar = 0
                Resultado = AltaCita.ShowDialog()
                If Resultado = Windows.Forms.DialogResult.OK Then
                    For Each i As Integer In ListaIndicesCita
                        grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(i), "ClienteSAYID").ToString()
                        grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(i), "ClaveCitaEntrega", AltaCita.objCita.Pclave)
                        grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(i), "TotalPersonasRequeridas", AltaCita.objCita.PpersonasRequeridas)
                        grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(i), "Observaciones", AltaCita.objCita.Pobservaciones)
                        grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(i), "FechaCapturoCita", Date.Now.ToShortDateString())
                        grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(i), "FechaCitaEntrega", CDate(AltaCita.objCita.PfechaEntrega))
                        grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(i), "HoraCita", (CDate(AltaCita.objCita.PfechaEntrega).Hour.ToString + ":" + CDate(AltaCita.objCita.PfechaEntrega).Minute.ToString))
                    Next

                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub QuitarSeleccionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarCita.Click
        EnviarInformacionCitaEntrega()
    End Sub

    Private Function ObtenerColorFila(ByVal Bloqueado As String, ByVal EstatusID As Integer) As Color
        Dim TipoColor As Color = Color.Empty

        If EstatusID = 130 Then
            TipoColor = pnlEstatusRechazada.BackColor
        Else
            If Bloqueado = "SI" Then
                TipoColor = Color.Salmon
            Else
                TipoColor = Color.Empty
            End If

        End If


        Return TipoColor

    End Function


    Private Function ObtenerColorTipoOT(ByVal TipoOT As String) As Color
        Dim TipoColor As Color

        If TipoOT = "SURTIDO" Then
            TipoColor = Color.Black
        ElseIf TipoOT = "DESASIGNACION" Then
            TipoColor = Color.Orange
        ElseIf TipoOT = "ABIERTA" Then
            TipoColor = Color.Purple
        Else
            TipoColor = Color.Empty
        End If

        Return TipoColor

    End Function


    Private Function ObtenerColorDiasEnttrega(ByVal DiasFaltantes As Integer) As Color
        Dim TipoColor As Color

        If DiasFaltantes >= 0 And DiasFaltantes <= 2 Then
            TipoColor = Color.Yellow
        ElseIf DiasFaltantes < 0 Then
            TipoColor = Color.Red
        ElseIf DiasFaltantes > 2 Then
            TipoColor = Color.Green
        Else
            TipoColor = Color.Empty
        End If

        Return TipoColor

    End Function

    Private Function ObtenerColorStatusOT(ByVal EstatusID As Integer) As Color
        Dim TipoColor As New Color

        '119:    ACTIVO()
        '120:    CONFIRMADO Ventas
        '121:    ACEPTADA()
        '122:    EN EJECUCION
        '123:    PARCIALMENTE CONFIRMADA
        '124:    CONFIRMADA()
        '125:    POR FACTURAR
        '126:    FACTURADO()
        '127:    EN RUTA
        '128:    ENTREGADA()
        '129:    CANCELADA()
        '130:    RECHAZADA()

        If EstatusID = "119" Then
            TipoColor = Color.Green
        ElseIf EstatusID = "120" Then
            TipoColor = Color.FromArgb(0, 192, 192)
        ElseIf EstatusID = "121" Then
            TipoColor = Color.MediumBlue
        ElseIf EstatusID = "122" Then
            TipoColor = Color.DodgerBlue
        ElseIf EstatusID = "123" Then
            TipoColor = Color.Indigo
        ElseIf EstatusID = "124" Then
            TipoColor = Color.DeepPink
        ElseIf EstatusID = "125" Then
            TipoColor = Color.RosyBrown
        ElseIf EstatusID = "126" Then
            TipoColor = Color.Pink
        ElseIf EstatusID = "127" Then
            TipoColor = Color.Coral
        ElseIf EstatusID = "128" Then
            TipoColor = Color.Brown
        ElseIf EstatusID = "129" Then
            TipoColor = Color.Red
        ElseIf EstatusID = "130" Then
            TipoColor = Color.DarkOrange

        End If

        Return TipoColor

    End Function





    Private Sub GridView2_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles grdVentas.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        Try
            'Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "ColorEstatus" Then
                e.Appearance.BackColor = ObtenerColorStatusOT(currentView.GetRowCellValue(e.RowHandle, "EstatusID"))
            End If

            If e.Column.FieldName = "DiasFaltantes" Then
                If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "DiasFaltantes")) = False Then
                    If IsNumeric(currentView.GetRowCellValue(e.RowHandle, "DiasFaltantes")) = True Then
                        e.Appearance.BackColor = ObtenerColorDiasEnttrega(currentView.GetRowCellValue(e.RowHandle, "DiasFaltantes"))
                    End If
                End If

            End If

            If e.Column.FieldName = "TipoOT" Then
                If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "TipoOT")) = False Then
                    e.Appearance.ForeColor = ObtenerColorTipoOT(currentView.GetRowCellValue(e.RowHandle, "TipoOT"))
                End If
            End If

            If TipoPerfil = 2 Then

                If chkDetallada.Checked = False Then
                    If e.Column.FieldName = "TotalErrores" Then
                        If e.CellValue > 0 Then
                            e.Appearance.ForeColor = Color.Red
                        Else
                            e.Appearance.ForeColor = Color.Black
                        End If
                    End If
                End If



                If e.Column.FieldName = "TotalIncidencias" Then
                    If e.CellValue > 0 Then
                        e.Appearance.ForeColor = Color.Red
                    Else
                        e.Appearance.ForeColor = Color.Black
                    End If
                End If

                If e.Column.FieldName = "FechaValidoAlmacen" Then
                    If IsDBNull(e.CellValue) = False Then
                        If currentView.GetRowCellValue(e.RowHandle, "EstatusID") = "130" Or currentView.GetRowCellValue(e.RowHandle, "EstatusID") = "129" Then
                            e.Appearance.ForeColor = Color.Red
                        Else
                            e.Appearance.ForeColor = Color.Green
                        End If
                    End If

                End If

                If e.Column.FieldName = "UsuarioValidoAlmacen" Then
                    If IsDBNull(e.CellValue) = False Then
                        If currentView.GetRowCellValue(e.RowHandle, "EstatusID") = "130" Or currentView.GetRowCellValue(e.RowHandle, "EstatusID") = "129" Then
                            e.Appearance.ForeColor = Color.Red
                        Else
                            e.Appearance.ForeColor = Color.Green
                        End If
                    End If

                End If


            End If

            If e.Column.FieldName = "FA" Then
                If e.CellValue = "SI" Then
                    e.Appearance.BackColor = pnlColorFA.BackColor
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try




    End Sub

    Private Sub btnAgregarFechaPreparacion_Click(sender As Object, e As EventArgs) Handles btnAgregarFechaPreparacion.Click, Button4.Click
        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim FechaNula As Date = Nothing
        Dim NumeroOrdenesValidas As Integer = 0
        Dim FechaPreparacion As Date = Nothing
        Dim FilasCoppel As Integer = 0
        Dim ClienteID As Integer = 0
        Dim EstatusId As Integer = 0
        Dim FilasEntregadasCanceladas As Int16 = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount()

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroOrdenesTrabajo += 1

                    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID"))
                    EstatusId = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID"))


                    If ClienteID <> "763" Then 'COPPEL
                        If EstatusId = "119" Or EstatusId = "130" Then '119 => ACTIVO, 130 => Rechazada
                            NumeroOrdenesValidas += 1
                            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion")) = False Then
                                FechaPreparacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion").ToString()
                            End If

                            If OrdenTrabajoID = String.Empty Then
                                OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            Else
                                OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            End If
                        End If
                    Else
                        If EstatusId = 129 Or EstatusId = 128 Then '129 => CANCELADA, 128 => ENTREGADA
                            'FilasCoppel += 1
                            FilasEntregadasCanceladas += 1
                        Else
                            NumeroOrdenesValidas += 1
                            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion")) = False Then
                                FechaPreparacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion").ToString()
                            End If

                            If OrdenTrabajoID = String.Empty Then
                                OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            Else
                                OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            End If
                        End If
                    End If

                End If
            Next


            If NumeroOrdenesTrabajo > 0 And NumeroOrdenesValidas > 0 Then
                Dim Form As New AgregarFechaPreparacionForm
                Form.OrdenTabajoId = OrdenTrabajoID
                Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
                Form.NumeroOrdenesTrabajoValidas = NumeroOrdenesValidas

                If NumeroOrdenesValidas = 1 Then
                    Form.FechaPreparacion = FechaPreparacion
                End If
                If Form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    ObtenerInformacion()
                End If
            Else

                If NumeroOrdenesTrabajo > 0 And NumeroOrdenesValidas = 0 Then
                    If FilasCoppel > 0 Then
                        show_message("Advertencia", "Las OTs ya estan autorizadas o pertenecen a COPPEL, no se puede modificar la fecha preparación.")
                    ElseIf FilasEntregadasCanceladas > 0 Then
                        show_message("Advertencia", "Las OTs están canceladas o entregadas, no se puede modificar la fecha preparación.")
                    Else
                        show_message("Advertencia", "Las OTs ya estan autorizadas, no se puede modificar la fecha preparación.")
                    End If

                Else
                    show_message("Advertencia", "No hay ordenes de trabajo seleccionadas.")
                End If

            End If


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString)
        End Try

    End Sub

    Private Function VentanaFechaPreparacion(ByVal OrdenesTrabajo As String, ByVal NumeroOrdenesTrabajovalidas As Integer, ByVal FechaPreparacion As Date, ByVal NumeroOrdenesTrabajoSeleccionadas As Integer) As Date

        Dim Form As New AgregarFechaPreparacionForm
        Dim FechaPreparacionAsignada As Date

        Form.OrdenTabajoId = OrdenesTrabajo
        Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajoSeleccionadas
        Form.NumeroOrdenesTrabajoValidas = NumeroOrdenesTrabajovalidas

        If NumeroOrdenesTrabajovalidas = 1 Then
            Form.FechaPreparacion = FechaPreparacion
        End If

        If Form.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FechaPreparacionAsignada = Form.FechaPreparacionModificada
        End If

        Form.Dispose()
        Return FechaPreparacionAsignada

    End Function


    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click, btnExportarVentas.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If GridView1.GroupCount > 0 Then
                        grdOts.ExportToXlsx(.SelectedPath + "\Datos_OrdenTrabajo_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        'exportOptions.RawDataMode = False
                        'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                        'exportOptions.ApplyFormattingToEntireColumn = DevExpress.Utils.DefaultBoolean.True

                        'exportOptions.AllowConditionalFormatting = DevExpress.Utils.DefaultBoolean.True

                        'exportOptions.ApplyFormattingToEntireColumn = DevExpress.Utils.DefaultBoolean.True
                        'exportOptions.RawDataMode = True

                        'GridView2.OptionsPrint.PrintHorzLines = True
                        'GridView2.ExportToXlsx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                        'AddHandler exportOptions.RawDataMode=, AddressOf exportOptions_CustomizeCell

                        'AddHandler exportOptions.ApplyFormattingToEntireColumn, AddressOf exportOptions_CustomizeCell


                        grdOts.ExportToXlsx(.SelectedPath + "\Datos_OrdenTrabajo_" + fecha_hora + ".xlsx", exportOptions)

                    End If

                    show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_OrdenTrabajo_" & fecha_hora.ToString() & ".xlsx")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_OrdenTrabajo_" + fecha_hora + ".xlsx")
                End If



            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        Dim EstatusID As Integer = grdVentas.GetRowCellValue(e.RowHandle, "EstatusID")
        Dim Bloqueado As String = grdVentas.GetRowCellValue(e.RowHandle, "BE")
        Dim TotalErrores As Integer = 0
        Dim TotalIncidencias As Integer = 0
        Dim index As Integer = 0
        Try



            If EstatusID = 130 Then
                e.Formatting.BackColor = pnlEstatusRechazada.BackColor
            ElseIf Bloqueado = "SI" Then
                e.Formatting.BackColor = Color.Salmon
            Else
                'If e.ColumnFieldName = "ColorEstatus" Then
                '    e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

                'End If
            End If

            If e.ColumnFieldName = "ColorEstatus" Then
                e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

            End If

            If TipoPerfil = 2 Then

                If chkDetallada.Checked = False Then
                    If e.ColumnFieldName = "TotalErrores" Then
                        TotalErrores = grdVentas.GetRowCellValue(e.RowHandle, "TotalErrores")
                        If TotalErrores > 0 Then
                            e.Formatting.Font.Color = Color.Red
                        Else
                            e.Formatting.Font.Color = Color.Black
                        End If
                    End If
                End If



                If e.ColumnFieldName = "TotalIncidencias" Then
                    TotalIncidencias = grdVentas.GetRowCellValue(e.RowHandle, "TotalIncidencias")

                    If TotalIncidencias > 0 Then
                        e.Formatting.Font.Color = Color.Red
                    Else
                        e.Formatting.Font.Color = Color.Black
                    End If
                End If

                If e.ColumnFieldName = "FechaValidoAlmacen" Then
                    If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
                        If EstatusID = "129" Or EstatusID = "130" Then
                            e.Formatting.Font.Color = Color.Red
                        Else
                            e.Formatting.Font.Color = Color.Green
                        End If
                    End If

                End If

                If e.ColumnFieldName = "UsuarioValidoAlmacen" Then
                    If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
                        If EstatusID = "129" Or EstatusID = "130" Then
                            e.Formatting.Font.Color = Color.Red
                        Else
                            e.Formatting.Font.Color = Color.Green
                        End If
                    End If

                End If


            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try



        e.Handled = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub GridView2_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles grdVentas.CellValueChanging
        'Dim ValorIndice As String = e.RowHandle.ToString
        'Dim NumeroFilas As Integer = 0
        If e.Column.FieldName = "Seleccionar" Then
            If CBool(e.Value) = True Then
                FilasSeleccionadas += 1
            Else
                FilasSeleccionadas -= 1
            End If
            'NumeroFilas = grdVentas.DataRowCount

            'For index As Integer = 0 To NumeroFilas Step 1

            '    If ValorIndice = index Then
            '        If CBool(e.Value) = True Then
            '            FilasSeleccionadas += 1
            '        End If
            '    Else
            '        If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Then
            '            FilasSeleccionadas += 1
            '        End If
            '    End If

            'Next

            '    If e.Value = True Then
            '        lblTotalSeleccionados.Text = FilasSeleccionadas.ToString()
            '    Else
            '        lblTotalSeleccionados.Text = FilasSeleccionadas.ToString() '- 1
            '    End If
        End If
    End Sub



    Private Sub GridView2_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdVentas.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Try

                Cursor = Cursors.WaitCursor
                Dim Bloqueo As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("BE"))
                Dim EstatusID As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EstatusID"))
                e.Appearance.BackColor = ObtenerColorFila(Bloqueo, EstatusID)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try


        End If
    End Sub

    Private Sub UltraGridExcelExporter1_ExportStarted(sender As Object, e As ExcelExport.ExportStartedEventArgs) Handles UltraGridExcelExporter1.ExportStarted

    End Sub

    Private Sub grdDetallesOT_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles grdDetallesOT.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        If e.Column.FieldName = "ColorEstatus" Then
            e.Appearance.BackColor = ObtenerColorStatusOT(currentView.GetRowCellValue(e.RowHandle, "EstatusPartidaID"))
        End If

        If e.Column.FieldName = "DiasFaltantes" Then
            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "DiasFaltantes")) = False Then
                e.Appearance.BackColor = ObtenerColorDiasEnttrega(currentView.GetRowCellValue(e.RowHandle, "DiasFaltantes"))
            End If

        End If

        If e.Column.FieldName = "TipoOT" Then
            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "TipoOT")) = False Then
                e.Appearance.ForeColor = ObtenerColorTipoOT(currentView.GetRowCellValue(e.RowHandle, "TipoOT"))
            End If
        End If
    End Sub

    Private Sub grdDetallesOT_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdDetallesOT.RowStyle

        Dim currentView As GridView = CType(sender, GridView)
        If (e.RowHandle >= 0) Then
            Dim EstatusID As String = currentView.GetRowCellValue(e.RowHandle, "EstatusPartidaID")
            Dim Bloqueo As String = currentView.GetRowCellValue(e.RowHandle, "BE")

            'Dim Bloqueo As String = currentView.GetRowCellDisplayText(e.RowHandle, currentView.Columns("BE"))
            ' Dim EstatusID As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EstatusPartidaID"))

            e.Appearance.BackColor = ObtenerColorFila(Bloqueo, EstatusID)

        End If
    End Sub

    Private Sub btnErroresIncidencias_Click(sender As Object, e As EventArgs) Handles btnErroresIncidencias.Click
        Dim punto As Point
        punto.X = btnErroresIncidencias.Location.X + btnErroresIncidencias.Width
        punto.Y = btnErroresIncidencias.Location.Y + btnErroresIncidencias.Height
        cmsTiposResumen.Show(punto)
    End Sub

    Private Sub btnConfirmarApartado_Click(sender As Object, e As EventArgs) Handles btnConfirmarOT.Click
        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim Form As New DetallesOrdenTrabajoForm
        Dim EsAndrea As Boolean = False

        Try
            Cursor = Cursors.WaitCursor
            'NumeroFilas = grdVentas.DataRowCount

            'For index As Integer = 0 To NumeroFilas Step 1

            '    If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Then
            '        NumeroOrdenesTrabajo += 1

            '        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID").ToString() = "816" Then
            '            EsAndrea = True
            '        End If

            '        If OrdenTrabajoID = String.Empty Then
            '            OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
            '            OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
            '        Else
            '            OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
            '            OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
            '        End If
            '    End If

            'Next

            Form.OrdenTrabajoID = ""
            Form.OrdenTrabajoSICYID = ""
            Form.NumeroOrdenesTrabajo = 0
            Form.EsConfirmacion = True
            'Form.EsAndrea = EsAndrea
            Form.MdiParent = Me.MdiParent
            Form.Show()


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub tsmiIncidencias_Click(sender As Object, e As EventArgs) Handles tsmiIncidencias.Click
        MostrarParesErroneosIncidencias(1)
    End Sub

    Private Sub tsmiErrores_Click(sender As Object, e As EventArgs) Handles tsmiErrores.Click
        MostrarParesErroneosIncidencias(2)
    End Sub

    Private Sub MostrarParesErroneosIncidencias(ByVal TipoConsulta As Integer)
        Dim OrdenesSeleccionadas As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            OrdenesSeleccionadas = ObtenerOrdenesTabajoSeleccionadas()

            If OrdenesSeleccionadas <> String.Empty Then
                Dim ParesErroneosIncidencias As New ConsultaParesErroneos_IncidenciasForm
                ParesErroneosIncidencias.tipoConsulta = TipoConsulta
                ParesErroneosIncidencias.OrdenTrabajoID = OrdenesSeleccionadas
                ParesErroneosIncidencias.ShowDialog()
            Else
                show_message("Advertencia", "No hay Ordenes de Trabajo Seleccionadas")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Function ObtenerOrdenesTabajoSeleccionadas() As String

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty

        Try
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroOrdenesTrabajo += 1
                    If OrdenTrabajoID = String.Empty Then
                        OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                    Else
                        OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                    End If
                End If
            Next
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        Return OrdenTrabajoID

    End Function


    Private Sub btnAgenda_Click(sender As Object, e As EventArgs) Handles btnAgenda.Click, btnAgendaVentas.Click
        Dim Agendaform As New AgendaEntrega_Form
        Agendaform.MdiParent = Me.MdiParent
        Agendaform.Show()

    End Sub

    Private Sub btnAceptarAlmacen_Click(sender As Object, e As EventArgs) Handles btnAceptarAlmacen.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasAutorizadas As Integer = 0
        Dim FilaYaAutorizada As Integer = 0
        Dim FilaCancelada As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim FilasCoppel As Integer = 0
        Dim FilasAceptar As Integer = 0
        Dim EstatusID As Integer = 0
        Dim ClienteID As Integer = 0
        Dim OrdenTrabajoCadena As String = String.Empty
        Dim OrdenTrabajoSplit As String()

        Try

            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1



                'For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVentas.Columns
                '    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), col.FieldName))


                'Next


                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    FilasSeleccionadas += 1

                    EstatusID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID"))
                    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID"))

                    If EstatusID = "120" And ClienteID <> 763 Then
                        FilasAceptar += 1
                        If OrdenTrabajoCadena = String.Empty Then
                            OrdenTrabajoCadena = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        Else
                            OrdenTrabajoCadena = OrdenTrabajoCadena & "," & grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        End If
                    End If

                    If ClienteID = 763 Then
                        FilasCoppel += 1
                    End If

                End If
            Next


            If FilasSeleccionadas = 0 Then
                show_message("Advertencia", "No hay Filas Seleccionadas.")
            Else
                If FilasAceptar = 0 And FilasCoppel = 0 Then
                    show_message("Advertencia", "Solo se pueden aceptar las OTs en estatus de confirmado Ventas.")
                ElseIf FilasAceptar = 0 And FilasCoppel > 0 Then
                    show_message("Advertencia", "Solo se pueden aceptar las OTs en estatus de confirmado Ventas y que no sean de COPPEL.")
                ElseIf FilasAceptar > 0 Then

                    confirmar.mensaje = "Se aceptarán " + FilasAceptar.ToString + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas. ¿Esta seguro de continuar?"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor

                        OrdenTrabajoSplit = Split(OrdenTrabajoCadena, ",")

                        For Each OTId As String In OrdenTrabajoSplit
                            objBU.AceptarOTAlmacen(CInt(OTId), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        Next

                        ObtenerInformacion()
                        Cursor = Cursors.WaitCursor
                        show_message("Exito", "Se han aceptado " + FilasAceptar.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs.")

                        Cursor = Cursors.Default
                    End If

                End If

            End If




            'confirmar.mensaje = "¿Esta seguro de aceptar la OT?"
            'If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    Cursor = Cursors.WaitCursor
            '    NumeroFilas = grdVentas.DataRowCount
            '    For index As Integer = 0 To NumeroFilas Step 1
            '        If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then

            '            'ClienteSAYID
            '            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 Then 'COPPEL
            '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 129 Then 'Cancelado o Rezhazado
            '                    FilaCancelada += 1
            '                ElseIf CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) > 121 Then
            '                    FilaYaAutorizada += 1
            '                End If

            '                'If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) > 120 Then 'Confirmado ventas
            '                '    FilaYaAutorizada += 1
            '                'End If

            '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 120 Then 'Confirmado ventas
            '                    objBU.AceptarOTAlmacen(CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT")), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            '                    FilasAutorizadas += 1
            '                End If
            '            Else
            '                FilasCoppel += 1
            '            End If



            '            FilasSeleccionadas += 1
            '        End If
            '    Next

            '    If FilasSeleccionadas = 0 Then
            '        show_message("Advertencia", "No hay Filas Seleccionadas")
            '    Else

            '        If FilasSeleccionadas = 1 Then
            '            If FilasAutorizadas = 1 Then
            '                ObtenerInformacion()
            '                show_message("Exito", "Se han aceptado " + FilasAutorizadas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs.")
            '            ElseIf FilaCancelada = 1 Then
            '                show_message("Advertencia", "La OT se encuentra cancelado o rechazada.")
            '            ElseIf FilasCoppel = 1 Then
            '                show_message("Advertencia", "Las OTs de COPPEL solo son para consulta.")

            '            Else
            '                If FilaYaAutorizada = 1 Then
            '                    show_message("Advertencia", "La OT ya se encuentra aceptada.")
            '                Else
            '                    show_message("Advertencia", "Solo se pueden aceptar las OTs en estatus de confirmado Ventas.")
            '                End If

            '            End If

            '        Else

            '            If FilasAutorizadas = FilasSeleccionadas Then
            '                ObtenerInformacion()
            '                show_message("Exito", "Se han autorizado: " + FilasAutorizadas.ToString().Trim() + " de " + FilasSeleccionadas.ToString() + " OTs.")
            '            Else
            '                If FilasAutorizadas = 0 Then
            '                    show_message("Advertencia", "No se han aceptado las OTs, asegurarse que las OTs a aceptar se encuentren en estatus de confirmado ventas.")
            '                Else
            '                    ObtenerInformacion()
            '                    show_message("Exito", "Se han aceptado: " + FilasAutorizadas.ToString().Trim() + " de " + FilasSeleccionadas.ToString().Trim() + " OTs.")
            '                End If

            '            End If

            '        End If

            '    End If

            'End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub




    Private Sub tmsiAsignarOperador_Click(sender As Object, e As EventArgs) Handles tmsiAsignarOperador.Click
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim listado As New ListadoParametrosApartadosForm
        Dim ObjBU As New Negocios.OrdenTrabajoBU
        Dim confirmacion As New Tools.ConfirmarForm

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasInvalidas As Integer = 0
        Dim FilasValidas As Integer = 0
        listado.tipo_busqueda = 10
        Dim listaParametroID As New List(Of String)
        Dim fIlasCoppel As Integer = 0

        Try
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index)) = True Then
                    FilasSeleccionadas += 1

                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 Then 'COPPEL

                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 816 Then 'Andrea
                            If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID").ToString() = "121" Or grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID").ToString() = "123" Then
                                FilasValidas += 1

                                If OrdenTrabajoID = String.Empty Then
                                    OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                Else
                                    OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                End If


                                If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OperadorAsignados")) = False Then
                                    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OperadorAsignados").ToString() = 1 Then
                                        listaParametroID.Add(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ortr_operadorasignadoid").ToString())
                                    End If
                                End If
                            Else
                                FilasInvalidas += 1
                            End If

                        End If


                    Else
                        fIlasCoppel += 1
                    End If


                End If
            Next

            If FilasSeleccionadas = 1 And fIlasCoppel = 1 Then
                show_message("Advertencia", "Las OTs de COPPEL son solo para consulta.")

            Else

                If FilasValidas > 0 Then
                    listaParametroID.Clear()

                    'If FilasValidas <> 1 Then
                    '    listaParametroID.Clear()
                    'End If

                    listado.listaParametroID = listaParametroID
                    listado.ShowDialog(Me)

                    If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
                    If listado.listParametros.Rows.Count = 0 Then Return
                    If listado.listParametros.Rows.Count > 1 Then
                        show_message("Advertencia", "Seleccione solo un operador para asignarse a cada OT.")
                    Else

                        If FilasInvalidas = FilasSeleccionadas Then
                            show_message("Advertencia", "Solo se puede asignar operador a las OTs en estatus de Aceptada o Parcialmente Confirmada.")
                        ElseIf fIlasCoppel = FilasSeleccionadas Then
                            show_message("Advertencia", "Solo se puede asignar operador a las OTs que no pertenezcan a COPPEL.")
                        Else
                            confirmacion.mensaje = "¿Está seguro que desea asignar la OT? "
                            Cursor = Cursors.WaitCursor

                            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                                ObjBU.AsignarOperadorOT(OrdenTrabajoID, Integer.Parse(listado.listParametros.Rows(0).Item(0).ToString()))
                                ObjBU.ActualizarOTUbicaciones(OrdenTrabajoID)
                                ObtenerInformacion()
                                If FilasInvalidas > 0 Then
                                    show_message("Exito", "Se ha asignado el operador a " + FilasValidas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas.")
                                Else
                                    show_message("Exito", "Se ha asignado el operador  a " + FilasValidas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas.")
                                End If

                            End If

                        End If

                    End If
                End If
            End If


            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub


    Private Sub btnAsignarOperador_Click(sender As Object, e As EventArgs) Handles btnAsignarOperador.Click

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim NumeroFilasSeleccionadas As Integer = 0

        Try
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroFilasSeleccionadas += 1

                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 816 Then 'COPPEL, andrea
                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 121 Or CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 123 Then 'Cancelado o Rezhazado

                            NumeroOrdenesTrabajo += 1
                            If OrdenTrabajoID = String.Empty Then
                                OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                            Else
                                OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                'OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                            End If
                        End If
                    End If



                End If
            Next

            If OrdenTrabajoID <> String.Empty Then
                Dim AsignarOperadorForm As New AsignarOperadorOTForm
                AsignarOperadorForm.OrdenTrabajoID = OrdenTrabajoID
                AsignarOperadorForm.MdiParent = Me.MdiParent
                AsignarOperadorForm.Show()
                ObtenerInformacion()
            Else
                If NumeroFilasSeleccionadas = 0 Then
                    show_message("Advertencia", "Debe de seleccionar al menos una OT.")
                Else
                    If NumeroOrdenesTrabajo > 0 Then
                        show_message("Advertencia", "Solo se puede asignar operador en status aceptada o parcialmente confirmada.")
                    End If
                End If

            End If
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Function EsValidaParaImpresion(ByVal EstatusId As Integer) As Boolean
        Dim Resultado As Boolean = True

        Select Case EstatusId
            Case 119
                Resultado = True
            Case 120
                Resultado = True
            Case 121
                Resultado = True
            Case 122
                Resultado = True
            Case 123
                Resultado = True
            Case 124
                Resultado = True
            Case 125
                Resultado = True
            Case 126
                Resultado = True
            Case 127
                Resultado = True
            Case 128
                Resultado = True
            Case Else
                Resultado = False
        End Select

        Return Resultado

    End Function

    Private Sub btnImprimirApartado_Click(sender As Object, e As EventArgs) Handles btnImprimirOT.Click, btnImprimirVentas.Click
        Dim NumeroFilas As Integer = 0
        Dim OTsImpresas As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim Impreso As Boolean = False
        Dim UsuarioImpresoId As Integer = 0
        Dim NumeroFilasSeleccionadas As Integer = 0
        Dim NumeroFilasCanceladas As Integer = 0
        Dim OTIDImprimir As String = String.Empty
        Dim OTIDVariasTiendas As String = String.Empty
        Dim dtNumeroTiendas As DataTable
        Dim EsYISTI As Boolean = False

        Try
            Cursor = Cursors.WaitCursor

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_YISTI") Then
                EsYISTI = True
            End If

            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    NumeroFilasSeleccionadas += 1

                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 129 Then
                        NumeroFilasCanceladas += 1
                    End If

                    If EsValidaParaImpresion(CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID"))) = True Then
                        OTsImpresas += 1

                        'If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Impreso")) = False Then
                        '    Impreso = CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Impreso"))
                        'Else
                        '    Impreso = False
                        'End If

                        'If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "UsuarioImpreso")) = False Then
                        '    UsuarioImpresoId = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "UsuarioImpreso")
                        'Else
                        '    UsuarioImpresoId = -1
                        'End If

                        'If Impreso = False Then
                        '    grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Impreso", 1)
                        '    grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(index), "UsuarioImpreso", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        'End If

                        dtNumeroTiendas = objBU.ObtenerCantidadTiendas(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString())
                        If CInt(dtNumeroTiendas.Rows(0).Item(0)) > 1 Then
                            If OTIDVariasTiendas = String.Empty Then
                                OTIDVariasTiendas = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            Else
                                OTIDVariasTiendas += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            End If
                        Else
                            If OTIDImprimir = String.Empty Then
                                OTIDImprimir = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            Else
                                OTIDImprimir += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            End If
                        End If

                    End If
                End If
            Next


            If OTsImpresas > 0 Then

                If EsYISTI = True Then
                    ImpresionYISTI(OTIDImprimir, OTIDVariasTiendas, Impreso, UsuarioImpresoId)
                Else
                    imprimirReporte(OTIDImprimir, OTIDVariasTiendas, Impreso, UsuarioImpresoId)
                End If

            End If

            If OTsImpresas > 0 Then
                'show_message("Exito", "Se han impreso " + OTsImpresas.ToString() + " de " + NumeroFilasSeleccionadas.ToString() + " OTs.")
            Else
                If NumeroFilasSeleccionadas > 0 Then
                    show_message("Advertencia", "Las OTs seleccionadas no se pueden imprimir, se encuentran canceladas o rechazadas .")
                Else
                    show_message("Advertencia", "No se han seleccionado OTs.")
                End If

            End If


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub



    Public Sub ImpresionYISTI(ByVal OrdenTrabajoSAYUnaTiendaID As String, ByVal OrdenTrabajoSAYVariasTiendaID As String, ByVal Impreso As Boolean, ByVal UsuarioImpreso As Integer)
        Dim dtFiniquitoFiscal As New DataTable

        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim dsOrdenTrabajo As New DataSet("dsOrdenTrabajo")
        Dim dsOrdenTrabajoSinCita As New DataSet("dsOrdenTrabajo")

        'Dim dsOrdenTrabajoVariasTiendasSinCita As New DataSet("dtOrdenTrabajo")
        'Dim dsOrdenTrabajoVariasTiendasConCita As New DataSet("dsOrdenTrabajo")
        Dim reporteUnaTiendaConCita As New StiReport
        Dim reporteUnaTiendaSinCita As New StiReport
        Dim reporteVariasTiendasSinCita As New StiReport
        Dim reporteVariasTiendasConCita As New StiReport

        Dim objEnt As New Entidades.OrdenTrabajoReporteTermino
        Dim DTInformacionReporte As DataTable

        Dim OrdenesImprimirID As String = String.Empty
        Dim DTInformacionHorariosRecibeVariasTiendas As New DataTable
        Dim tool As New Tools.Controles
        Dim OTImpresas As Integer = 0


        Dim dtInformacionPares As New DataTable("dtParesOT")
        Dim dtInformacionParesVariasTiendasConCita As New DataTable("dtParesOT")
        Dim dtInformacionParesVariasTiendasSinCita As New DataTable("dtParesOT")

        'Dim dtInformacionPares As DataTable
        Dim dtInformacionParesAux As DataTable
        Dim dtInformacionParesVariasTiendasAux As DataTable

        Dim DTInformacionReporteSinCitaUnaTienda As DataTable
        Dim DTInformacionHorariosRecibe As DataTable
        Dim DTInformacionHorarioRecibeAux As DataTable
        Dim DtInformacionVariasTiendasSinCita As DataTable
        Dim DTInformacionReporteSinCitaAux As DataTable


        Dim DTInformacionReporteVariasTiendasConCita As DataTable
        Dim DtInformacionVariasTiendasConCita As DataTable
        Dim DTInformacionReporteVariasTiendasSinCita As DataTable

        Dim VariasTiendas As Boolean = False

        Dim dsOrdenTrabajoVariasTiendasSinCita As New DataSet("dtOrdenTrabajo")
        Dim dsOrdenTrabajoVariasTiendasConCita As New DataSet("dsOrdenTrabajo")
        Try
            Cursor = Cursors.WaitCursor

            DTInformacionHorariosRecibe = New DataTable("dtHorariosOT")
            With DTInformacionHorariosRecibe
                .Columns.Add("Dias")
                .Columns.Add("Hrs")
                .Columns.Add("OT")
            End With

            DTInformacionHorariosRecibeVariasTiendas = New DataTable("dtHorariosOT")
            With DTInformacionHorariosRecibeVariasTiendas

                .Columns.Add("Dias")
                .Columns.Add("Hrs")
                .Columns.Add("OT")
            End With


            With dtInformacionPares
                .Columns.Add("Partida")
                .Columns.Add("Ubicacion")
                .Columns.Add("Tienda")
                .Columns.Add("Articulo")
                .Columns.Add("Lote")
                .Columns.Add("Atado")
                .Columns.Add("Corrida")
                .Columns.Add("Pares")
                .Columns.Add("OT")

            End With

            With dtInformacionParesVariasTiendasConCita
                .Columns.Add("Partida")
                .Columns.Add("Ubicacion")
                .Columns.Add("Tienda")
                .Columns.Add("Articulo")
                .Columns.Add("Lote")
                .Columns.Add("Atado")
                .Columns.Add("Corrida")
                .Columns.Add("Pares")
                .Columns.Add("OT")
            End With

            If OrdenTrabajoSAYUnaTiendaID <> String.Empty Then
                OrdenesImprimirID = OrdenTrabajoSAYUnaTiendaID
                DTInformacionReporte = objBU.ConsultarInformacionReporteTerminoOT(OrdenTrabajoSAYUnaTiendaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, True)
                DTInformacionReporte.TableName = "dtOrdenTrabajo"

                DTInformacionReporteSinCitaUnaTienda = objBU.ConsultarInformacionReporteTerminoOT(OrdenTrabajoSAYUnaTiendaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, False)
                DTInformacionReporteSinCitaUnaTienda.TableName = "dtOrdenTrabajo"

                dtInformacionParesAux = objBU.ObtenerInformacionParesOT(OrdenTrabajoSAYUnaTiendaID)
                dtInformacionParesAux.TableName = "dtParesOT"

                For Each Filas As DataRow In dtInformacionParesAux.Rows
                    dtInformacionPares.Rows.Add(Filas.Item(0), Filas.Item(1), Filas.Item(2), Filas.Item(3), Filas.Item(4), Filas.Item(5), Filas.Item(6), Filas.Item(7), Filas.Item(8))
                Next

                If DTInformacionReporte.Rows.Count > 0 Then

                    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_CONCITA_YISTI")
                    dsOrdenTrabajo.Tables.Add(DTInformacionReporte)
                    dsOrdenTrabajo.Tables.Add(dtInformacionPares)

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                    reporteUnaTiendaConCita.Load(archivo)
                    reporteUnaTiendaConCita.Compile()
                    reporteUnaTiendaConCita.RegData(dsOrdenTrabajo)
                    reporteUnaTiendaConCita("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
                    reporteUnaTiendaConCita.Dictionary.Clear()
                    reporteUnaTiendaConCita.Dictionary.Synchronize()
                    reporteUnaTiendaConCita.Render()
                    '    reporteUnaTienda.Show()

                    OTImpresas += 1
                End If

                If DTInformacionReporteSinCitaUnaTienda.Rows.Count > 0 Then

                    DTInformacionHorarioRecibeAux = objBU.ObtenerHorariosRecibo(OrdenTrabajoSAYUnaTiendaID)
                    For Each Filas As DataRow In DTInformacionHorarioRecibeAux.Rows
                        DTInformacionHorariosRecibe.Rows.Add(Filas.Item(0), Filas.Item(1), Filas.Item(2))
                    Next

                    DTInformacionHorariosRecibe.TableName = "dtHorariosOT"

                    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_SINCITA_YISTI")
                    dsOrdenTrabajoSinCita.Tables.Add(DTInformacionReporteSinCitaUnaTienda)
                    dsOrdenTrabajoSinCita.Tables.Add(DTInformacionHorariosRecibe)
                    dsOrdenTrabajoSinCita.Tables.Add(dtInformacionPares)

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                    reporteUnaTiendaSinCita.Load(archivo)
                    reporteUnaTiendaSinCita.Compile()
                    reporteUnaTiendaSinCita.RegData(dsOrdenTrabajoSinCita)
                    reporteUnaTiendaSinCita("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
                    reporteUnaTiendaSinCita.Dictionary.Clear()
                    reporteUnaTiendaSinCita.Dictionary.Synchronize()
                    reporteUnaTiendaSinCita.Render()
                    '    reporteUnaTienda.Show()

                    OTImpresas += 1

                End If

            End If

            If OrdenTrabajoSAYVariasTiendaID <> String.Empty Then


                dtInformacionParesVariasTiendasAux = objBU.ObtenerInformacionParesOT(OrdenTrabajoSAYVariasTiendaID)
                dtInformacionParesVariasTiendasAux.TableName = "dtParesOT"

                For Each Filas As DataRow In dtInformacionParesVariasTiendasAux.Rows
                    dtInformacionParesVariasTiendasConCita.Rows.Add(Filas.Item(0), Filas.Item(1), Filas.Item(2), Filas.Item(3), Filas.Item(4), Filas.Item(5), Filas.Item(6), Filas.Item(7), Filas.Item(8))
                Next

                dtInformacionParesVariasTiendasSinCita = dtInformacionParesVariasTiendasConCita.Copy()

                If OrdenesImprimirID <> String.Empty Then
                    OrdenesImprimirID += "," + OrdenTrabajoSAYVariasTiendaID
                Else
                    OrdenesImprimirID = OrdenTrabajoSAYVariasTiendaID
                End If

                DTInformacionReporteVariasTiendasConCita = objBU.ConsultarInformacionReporteTerminoVariasTiendasOT(OrdenTrabajoSAYVariasTiendaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, True)
                DtInformacionVariasTiendasConCita = ObtenerInformacionTiendas(OrdenTrabajoSAYVariasTiendaID)

                DTInformacionReporteVariasTiendasConCita.TableName = "OrdenTrabajo"
                DtInformacionVariasTiendasConCita.TableName = "dtTiendas"

                dsOrdenTrabajoVariasTiendasConCita.Tables.Add(DTInformacionReporteVariasTiendasConCita)
                dsOrdenTrabajoVariasTiendasConCita.Tables.Add(DtInformacionVariasTiendasConCita)
                dsOrdenTrabajoVariasTiendasConCita.Tables.Add(dtInformacionParesVariasTiendasConCita)

                If DTInformacionReporteVariasTiendasConCita.Rows.Count > 0 Then
                    OTImpresas += 1
                End If


                DTInformacionReporteVariasTiendasSinCita = objBU.ConsultarInformacionReporteTerminoVariasTiendasOT(OrdenTrabajoSAYVariasTiendaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, False)
                DtInformacionVariasTiendasSinCita = ObtenerInformacionTiendas(OrdenTrabajoSAYVariasTiendaID)

                dsOrdenTrabajoVariasTiendasSinCita.DataSetName = "dtOrdenTrabajo"
                DTInformacionReporteVariasTiendasSinCita.TableName = "OrdenTrabajo"
                DtInformacionVariasTiendasSinCita.TableName = "dtTiendas"
                dtInformacionParesVariasTiendasSinCita.TableName = "dtParesOT"

                dsOrdenTrabajoVariasTiendasSinCita.Tables.Add(DTInformacionReporteVariasTiendasSinCita)
                dsOrdenTrabajoVariasTiendasSinCita.Tables.Add(DtInformacionVariasTiendasSinCita)


                If DTInformacionReporteVariasTiendasSinCita.Rows.Count > 0 Then
                    OTImpresas += 1
                End If

                If DTInformacionReporteVariasTiendasSinCita.Rows.Count > 0 Then
                    VariasTiendas = True
                    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_VT_SC_YISTI")

                    DTInformacionReporteSinCitaAux = objBU.ObtenerHorariosRecibo(OrdenTrabajoSAYVariasTiendaID)
                    For Each Filas As DataRow In DTInformacionReporteSinCitaAux.Rows
                        DTInformacionHorariosRecibeVariasTiendas.Rows.Add(Filas.Item(0), Filas.Item(1), Filas.Item(2))
                    Next

                    DTInformacionHorariosRecibeVariasTiendas.TableName = "dtHorariosOT"

                    dsOrdenTrabajoVariasTiendasSinCita.Tables.Add(DTInformacionHorariosRecibeVariasTiendas)
                    dsOrdenTrabajoVariasTiendasSinCita.Tables.Add(dtInformacionParesVariasTiendasSinCita)

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                       LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                    reporteVariasTiendasSinCita.Load(archivo)
                    reporteVariasTiendasSinCita.Compile()
                    reporteVariasTiendasSinCita.RegData(dsOrdenTrabajoVariasTiendasSinCita)
                    reporteVariasTiendasSinCita.Dictionary.Clear()
                    reporteVariasTiendasSinCita.Dictionary.Synchronize()
                    reporteVariasTiendasSinCita.Render()
                    'reporteVariasTiendas.Show()
                End If


                If DTInformacionReporteVariasTiendasConCita.Rows.Count > 0 Then
                    VariasTiendas = True
                    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_VT_CS_YISTI")

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                       LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                    reporteVariasTiendasConCita.Load(archivo)
                    reporteVariasTiendasConCita.Compile()
                    reporteVariasTiendasConCita.RegData(dsOrdenTrabajoVariasTiendasConCita)
                    reporteVariasTiendasConCita.Dictionary.Clear()
                    reporteVariasTiendasConCita.Dictionary.Synchronize()
                    reporteVariasTiendasConCita.Render()
                    'reporteVariasTiendas.Show()
                End If

            End If



            If OTImpresas > 0 Then
                Dim JoinReport As StiReport = New StiReport
                JoinReport.NeedsCompiling = False
                JoinReport.IsRendered = True
                JoinReport.RenderedPages.Clear()

                If IsNothing(reporteUnaTiendaConCita.CompiledReport) = False Then
                    For Each Page As Stimulsoft.Report.Components.StiPage In reporteUnaTiendaConCita.CompiledReport.RenderedPages
                        Page.Report = JoinReport
                        Page.NewGuid()
                        JoinReport.RenderedPages.Add(Page)
                    Next
                End If

                If IsNothing(reporteUnaTiendaSinCita.CompiledReport) = False Then
                    For Each Page As Stimulsoft.Report.Components.StiPage In reporteUnaTiendaSinCita.CompiledReport.RenderedPages
                        Page.Report = JoinReport
                        Page.NewGuid()
                        JoinReport.RenderedPages.Add(Page)
                    Next
                End If

                If VariasTiendas = True Then
                    If IsNothing(reporteVariasTiendasSinCita.CompiledReport) = False Then
                        For Each Page As Stimulsoft.Report.Components.StiPage In reporteVariasTiendasSinCita.CompiledReport.RenderedPages
                            Page.Report = JoinReport
                            Page.NewGuid()
                            JoinReport.RenderedPages.Add(Page)
                        Next
                    End If

                    If IsNothing(reporteVariasTiendasConCita.CompiledReport) = False Then
                        For Each Page As Stimulsoft.Report.Components.StiPage In reporteVariasTiendasConCita.CompiledReport.RenderedPages
                            Page.Report = JoinReport
                            Page.NewGuid()
                            JoinReport.RenderedPages.Add(Page)
                        Next
                    End If

                End If


                JoinReport.Show()

                ActualizarEstatusImpresion(OrdenesImprimirID)
            Else
                show_message("Advertencia", "No hay OT seleccionadas.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub



    Private Function ObtenerInformacionReporteTeminoOTTiendas(ByVal OrdenTrabajoSAYID As Integer, ByVal objEnt As Entidades.OrdenTrabajoReporteTermino) As DataTable

        Dim dtTienda As New DataTable

        dtTienda = New DataTable("dtTiendas")
        With dtTienda
            .Columns.Add("Tienda")
            .Columns.Add("TotalPares")
            .Columns.Add("Direccion")
            .Columns.Add("TipoEmpaque")
            .Columns.Add("NotasEmpaque")
            .Columns.Add("NotasEmbarque")
        End With


        For Each Fila As Entidades.OrdenTrabajoDireccionEntrega In objEnt.DomicilioTiendas
            dtTienda.Rows.Add(Fila.Tienda, CDbl(Fila.TotalPares).ToString("n0"), Fila.Calle + " #" + Fila.NumeroExterior.ToString + " " + Fila.Colonia + ", " + Fila.Ciudad + "," + Fila.Estado + " C.P." + Fila.CP, Fila.TipoEmpaque, Fila.NotasEmpaque, Fila.NotasEmbarque)
        Next

        Return dtTienda

    End Function

    Private Function ObtenerInformacionReporteTeminoOTVariasTiendas(ByVal OrdenTrabajoSAYID As Integer, ByVal objEnt As Entidades.OrdenTrabajoReporteTermino) As DataTable
        Dim dtOrdenTrabajo As New DataTable


        dtOrdenTrabajo = New DataTable("dtOrdenTrabajo")
        With dtOrdenTrabajo
            .Columns.Add("OTCodigo")
            .Columns.Add("Cliente")
            .Columns.Add("FechaEntrega")
            .Columns.Add("AtnClientes")
            .Columns.Add("FechaCreacion")
            .Columns.Add("OT")
            .Columns.Add("Agente")
            .Columns.Add("Transporte")
            .Columns.Add("Empaque")
            .Columns.Add("TotalEnviar")
            .Columns.Add("Cita")
            .Columns.Add("Confirmacion")
            .Columns.Add("Observaciones")
            .Columns.Add("TipoEmpaque")
            .Columns.Add("EntregarPedido")
            .Columns.Add("FacturarPor")
            .Columns.Add("ImporteMax")
            .Columns.Add("Facturacion")
            .Columns.Add("NotasVentas")
            .Columns.Add("NotasEmpaque")
            .Columns.Add("EntregarEn")
            .Columns.Add("Direccion")
            .Columns.Add("Colonia")
            .Columns.Add("Ciudad")
            .Columns.Add("Estado")
            .Columns.Add("CP")
            .Columns.Add("Convenio")
            .Columns.Add("ContactoRampa")
            .Columns.Add("NotasEmbarque")
            .Columns.Add("DiasEntrega")
            .Columns.Add("UsuarioImprimio")
            .Columns.Add("FechaImpresion")
            .Columns.Add("OTUbicacion")

        End With

        dtOrdenTrabajo.Rows.Add(objEnt.OTCodigo, objEnt.Cliente, objEnt.FechaEntrega, objEnt.AtnClientes, objEnt.FechaCreacion, objEnt.OrdenTrabajoID, objEnt.Agente, objEnt.Transporte, objEnt.DomicilioTiendas(0).Empaque, objEnt.TotalEnviar, objEnt.Cita, objEnt.Confirmacion, objEnt.Observaciones, objEnt.DomicilioTiendas(0).TipoEmpaque, objEnt.EntregarPedido, objEnt.FacturarPor, objEnt.ImporteMaxVta, objEnt.PorcentajeFacturacion, objEnt.NotasVentas, objEnt.DomicilioTiendas(0).NotasEmpaque, objEnt.DomicilioTiendas(0).Lugarentregar, objEnt.DomicilioTiendas(0).Calle + " #" + objEnt.DomicilioTiendas(0).NumeroExterior.ToString(), objEnt.DomicilioTiendas(0).Colonia, objEnt.DomicilioTiendas(0).Ciudad, objEnt.DomicilioTiendas(0).Estado, objEnt.DomicilioTiendas(0).CP, objEnt.DomicilioTiendas(0).ConvenioTransporte.ToString(), objEnt.EmbarqueContactoRampa, objEnt.EmbarqueNotas, objEnt.DiasEntrega, objEnt.UsuarioImprimio, FormatoFecha(Date.Parse(objEnt.FechaImpresion)), objEnt.UbicacionOT)


        Return dtOrdenTrabajo

    End Function

    Private Function ObtenerInformacionReporteTeminoOT(ByVal OrdenTrabajoSAYID As Integer, ByVal objEnt As Entidades.OrdenTrabajoReporteTermino) As DataTable
        Dim dtOrdenTrabajo As New DataTable


        dtOrdenTrabajo = New DataTable("dtOrdenTrabajo")
        With dtOrdenTrabajo
            .Columns.Add("OTCodigo")
            .Columns.Add("Cliente")
            .Columns.Add("FechaEntrega")
            .Columns.Add("AtnClientes")
            .Columns.Add("FechaCreacion")
            .Columns.Add("OT")
            .Columns.Add("Agente")
            .Columns.Add("Transporte")
            .Columns.Add("Empaque")
            .Columns.Add("TotalEnviar")
            .Columns.Add("Cita")
            .Columns.Add("HoraCita")
            .Columns.Add("Confirmacion")
            .Columns.Add("Observaciones")
            .Columns.Add("TipoEmpaque")
            .Columns.Add("EntregarPedido")
            .Columns.Add("FacturarPor")
            .Columns.Add("ImporteMax")
            .Columns.Add("Facturacion")
            .Columns.Add("NotasVentas")
            .Columns.Add("NotasEmpaque")
            .Columns.Add("EntregarEn")
            .Columns.Add("Direccion")
            .Columns.Add("Colonia")
            .Columns.Add("Ciudad")
            .Columns.Add("Estado")
            .Columns.Add("CP")
            .Columns.Add("Convenio")
            .Columns.Add("ContactoRampa")
            .Columns.Add("NotasEmbarque")
            .Columns.Add("DiasEntrega")
            .Columns.Add("UsuarioImprimio")
            .Columns.Add("FechaImpresion")
            .Columns.Add("OTUbicacion")

        End With


        If objEnt.DomicilioTiendas.Count = 1 Then
            dtOrdenTrabajo.Rows.Add(objEnt.OTCodigo, objEnt.Cliente, objEnt.FechaEntrega, objEnt.AtnClientes, objEnt.FechaCreacion, objEnt.OrdenTrabajoID, objEnt.Agente, objEnt.Transporte, objEnt.DomicilioTiendas(0).Empaque, objEnt.TotalEnviar, objEnt.Cita, objEnt.HoraCita, objEnt.Confirmacion, objEnt.Observaciones, objEnt.DomicilioTiendas(0).TipoEmpaque, objEnt.EntregarPedido, objEnt.FacturarPor, objEnt.ImporteMaxVta, objEnt.PorcentajeFacturacion, objEnt.NotasVentas, objEnt.DomicilioTiendas(0).NotasEmpaque, objEnt.EmbarqueEntregarEn, objEnt.DomicilioTiendas(0).Calle + " #" + objEnt.DomicilioTiendas(0).NumeroExterior.ToString(), objEnt.DomicilioTiendas(0).Colonia, objEnt.DomicilioTiendas(0).Ciudad, objEnt.DomicilioTiendas(0).Estado, objEnt.DomicilioTiendas(0).CP, objEnt.DomicilioTiendas(0).ConvenioTransporte.ToString(), objEnt.EmbarqueContactoRampa, objEnt.EmbarqueNotas, objEnt.DiasEntrega, objEnt.UsuarioImprimio, FormatoFecha(Date.Parse(objEnt.FechaImpresion)), objEnt.UbicacionOT)
        ElseIf objEnt.DomicilioTiendas.Count = 0 Then
            dtOrdenTrabajo.Rows.Add(objEnt.OTCodigo, objEnt.Cliente, objEnt.FechaEntrega, objEnt.AtnClientes, objEnt.FechaCreacion, objEnt.OrdenTrabajoID, objEnt.Agente, objEnt.Transporte, objEnt.TipoEmpaque, objEnt.TotalEnviar, objEnt.Cita, objEnt.HoraCita, objEnt.Confirmacion, objEnt.Observaciones, objEnt.TipoEmpaque, objEnt.EntregarPedido, objEnt.FacturarPor, objEnt.ImporteMaxVta, objEnt.PorcentajeFacturacion, objEnt.NotasVentas, objEnt.NotasEmpaque, objEnt.EmbarqueEntregarEn, "", "", "", "", "", "", objEnt.EmbarqueContactoRampa, objEnt.EmbarqueNotas, objEnt.DiasEntrega, objEnt.UsuarioImprimio, FormatoFecha(Date.Parse(objEnt.FechaImpresion)), objEnt.UbicacionOT)
        End If

        Return dtOrdenTrabajo

    End Function

    Private Function FormatoFecha(ByVal Fecha As Date) As String
        Dim Resultado As String = String.Empty

        Select Case Fecha.DayOfWeek

            Case DayOfWeek.Monday
                Resultado = "Lunes"
            Case DayOfWeek.Tuesday
                Resultado = "Martes"
            Case DayOfWeek.Wednesday
                Resultado = "Miercoles"
            Case DayOfWeek.Thursday
                Resultado = "Jueves"
            Case DayOfWeek.Friday
                Resultado = "Viernes"
            Case DayOfWeek.Saturday
                Resultado = "Sabado"
            Case DayOfWeek.Sunday
                Resultado = "Domingo"
        End Select

        Resultado += " " + Fecha.Day.ToString() + " de "

        Select Case Fecha.Month

            Case 1
                Resultado += "Enero"
            Case 2
                Resultado += "Febrero"
            Case 3
                Resultado += "Marzo"
            Case 4
                Resultado += "Abril"
            Case 5
                Resultado += "Mayo"
            Case 6
                Resultado += "Junio"
            Case 7
                Resultado += "Julio"
            Case 8
                Resultado += "Agosto"
            Case 9
                Resultado += "Septiembre"
            Case 10
                Resultado += "Octubre"
            Case 11
                Resultado += "Noviembre"
            Case 12
                Resultado += "Diciembre"
        End Select

        Resultado += " de " + Fecha.Year.ToString() + " "

        If Fecha.Hour < 10 Then
            Resultado += "0" + Fecha.Hour.ToString()
        Else
            Resultado += Fecha.Hour.ToString()
        End If

        If Fecha.Minute < 10 Then
            Resultado += ":0" + Fecha.Minute.ToString()
        Else
            Resultado += ":" + Fecha.Minute.ToString()
        End If

        If Fecha.Second < 10 Then
            Resultado += ":0" + Fecha.Second.ToString()
        Else
            Resultado += ":" + Fecha.Second.ToString()
        End If

        Return Resultado

    End Function

    Public Sub imprimirReporte(ByVal OrdenTrabajoSAYUnaTiendaID As String, ByVal OrdenTrabajoSAYVariasTiendaID As String, ByVal Impreso As Boolean, ByVal UsuarioImpreso As Integer)
        Dim dtFiniquitoFiscal As New DataTable

        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim dsOrdenTrabajo As New DataSet("dtOrdenTrabajo")
        Dim dsOrdenTrabajoSinCita As New DataSet("dtOrdenTrabajo")

        Dim dsOrdenTrabajoVariasTiendasSinCita As New DataSet("dtOrdenTrabajo")
        Dim dsOrdenTrabajoVariasTiendasConCita As New DataSet("dsOrdenTrabajo")

        Dim dtOrdenTrabajo As New DataTable
        Dim dsTiendas As New DataSet
        Dim dtTiendas As New DataTable
        'dsOrdenTrabajo.DataSetName = "dtOrdenTrabajo"
        '        Dim ArchivoBytes As New Byte()

        Dim objEnt As New Entidades.OrdenTrabajoReporteTermino
        Dim DTInformacionReporte As DataTable
        Dim reporteUnaTienda As New StiReport
        Dim reporteUnaTiendaSinCita As New StiReport
        Dim reporteVariasTiendas As New StiReport
        Dim reporteVariasTiendasConCita As New StiReport
        Dim reporteVariasTiendasSinCita As New StiReport

        'Dim DTInformacionReporteVariasTiendas As DataTable
        Dim DTInformacionReporteVariasTiendasSinCita As DataTable
        Dim DTInformacionReporteVariasTiendasConCita As DataTable

        Dim DTInformacionHorariosRecibe As New DataTable

        'Dim DtInformacionTienda As DataTable

        Dim DtInformacionVariasTiendasSinCita As DataTable
        Dim DtInformacionVariasTiendasConCita As DataTable

        Dim UnaTienda As Boolean = False
        Dim VariasTiendas As Boolean = False

        Dim OrdenesImprimirID As String = String.Empty
        Dim OTImpresas As Integer = 0

        Dim DTInformacionReporteSinCita As DataTable
        Dim DTInformacionReporteSinCitaAux As DataTable

        Dim DTInformacionHorariosRecibeVariasTiendas As New DataTable

        Try
            Cursor = Cursors.WaitCursor

            Dim tool As New Tools.Controles

            DTInformacionHorariosRecibe = New DataTable("dtHorariosOT")
            With DTInformacionHorariosRecibe

                .Columns.Add("Dias")
                .Columns.Add("Hrs")
                .Columns.Add("OT")
            End With


            DTInformacionHorariosRecibeVariasTiendas = New DataTable("dtHorariosOT")
            With DTInformacionHorariosRecibeVariasTiendas

                .Columns.Add("Dias")
                .Columns.Add("Hrs")
                .Columns.Add("OT")
            End With




            If OrdenTrabajoSAYUnaTiendaID <> String.Empty Then


                OrdenesImprimirID = OrdenTrabajoSAYUnaTiendaID
                UnaTienda = True
                DTInformacionReporte = objBU.ConsultarInformacionReporteTerminoOT(OrdenTrabajoSAYUnaTiendaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, True)
                DTInformacionReporte.TableName = "dtOrdenTrabajo"

                OrdenesImprimirID = OrdenTrabajoSAYUnaTiendaID
                UnaTienda = True
                DTInformacionReporteSinCita = objBU.ConsultarInformacionReporteTerminoOT(OrdenTrabajoSAYUnaTiendaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, False)
                DTInformacionReporteSinCita.TableName = "dtOrdenTrabajo"

                If DTInformacionReporte.Rows.Count > 0 Then

                    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_CONCITA_PRUEBAV2")
                    dsOrdenTrabajo.Tables.Add(DTInformacionReporte)

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                    reporteUnaTienda.Load(archivo)
                    reporteUnaTienda.Compile()
                    reporteUnaTienda.RegData(dsOrdenTrabajo.Tables(0))
                    reporteUnaTienda("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
                    reporteUnaTienda.Dictionary.Clear()
                    reporteUnaTienda.Dictionary.Synchronize()
                    reporteUnaTienda.Render()
                    '    reporteUnaTienda.Show()

                    OTImpresas += 1
                End If


                If DTInformacionReporteSinCita.Rows.Count > 0 Then

                    DTInformacionReporteSinCitaAux = objBU.ObtenerHorariosRecibo(OrdenTrabajoSAYUnaTiendaID)
                    For Each Filas As DataRow In DTInformacionReporteSinCitaAux.Rows
                        DTInformacionHorariosRecibe.Rows.Add(Filas.Item(0), Filas.Item(1), Filas.Item(2))
                    Next

                    DTInformacionHorariosRecibe.TableName = "dtHorariosOT"

                    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_SC_PRUEBAV2")
                    dsOrdenTrabajoSinCita.Tables.Add(DTInformacionReporteSinCita)
                    dsOrdenTrabajoSinCita.Tables.Add(DTInformacionHorariosRecibe)

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                    reporteUnaTiendaSinCita.Load(archivo)
                    reporteUnaTiendaSinCita.Compile()
                    reporteUnaTiendaSinCita.RegData(dsOrdenTrabajoSinCita)
                    reporteUnaTiendaSinCita("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
                    reporteUnaTiendaSinCita.Dictionary.Clear()
                    reporteUnaTiendaSinCita.Dictionary.Synchronize()
                    reporteUnaTiendaSinCita.Render()
                    '    reporteUnaTienda.Show()

                    OTImpresas += 1

                End If

            End If

            If OrdenTrabajoSAYVariasTiendaID <> String.Empty Then

                If OrdenesImprimirID <> String.Empty Then
                    OrdenesImprimirID += "," + OrdenTrabajoSAYVariasTiendaID
                Else
                    OrdenesImprimirID = OrdenTrabajoSAYVariasTiendaID
                End If

                DTInformacionReporteVariasTiendasConCita = objBU.ConsultarInformacionReporteTerminoVariasTiendasOT(OrdenTrabajoSAYVariasTiendaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, True)
                DtInformacionVariasTiendasConCita = ObtenerInformacionTiendas(OrdenTrabajoSAYVariasTiendaID)

                DTInformacionReporteVariasTiendasConCita.TableName = "OrdenTrabajo"
                DtInformacionVariasTiendasConCita.TableName = "dtTiendas"

                dsOrdenTrabajoVariasTiendasConCita.Tables.Add(DTInformacionReporteVariasTiendasConCita)
                dsOrdenTrabajoVariasTiendasConCita.Tables.Add(DtInformacionVariasTiendasConCita)

                If DTInformacionReporteVariasTiendasConCita.Rows.Count > 0 Then
                    OTImpresas += 1
                End If


                DTInformacionReporteVariasTiendasSinCita = objBU.ConsultarInformacionReporteTerminoVariasTiendasOT(OrdenTrabajoSAYVariasTiendaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, False)
                DtInformacionVariasTiendasSinCita = ObtenerInformacionTiendas(OrdenTrabajoSAYVariasTiendaID)

                dsOrdenTrabajoVariasTiendasSinCita.DataSetName = "dtOrdenTrabajo"
                DTInformacionReporteVariasTiendasSinCita.TableName = "OrdenTrabajo"
                DtInformacionVariasTiendasSinCita.TableName = "dtTiendas"

                dsOrdenTrabajoVariasTiendasSinCita.Tables.Add(DTInformacionReporteVariasTiendasSinCita)
                dsOrdenTrabajoVariasTiendasSinCita.Tables.Add(DtInformacionVariasTiendasSinCita)

                If DTInformacionReporteVariasTiendasSinCita.Rows.Count > 0 Then
                    OTImpresas += 1
                End If



                'If DTInformacionReporteVariasTiendasConCita.Rows.Count > 0 Then
                '    VariasTiendas = True
                '    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_VARIAS")

                '    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                '       LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                '    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                '    reporteVariasTiendas.Load(archivo)
                '    reporteVariasTiendas.Compile()
                '    reporteVariasTiendas.RegData(dsOrdenTrabajoVariasTiendasConCita)
                '    reporteVariasTiendas.Dictionary.Clear()
                '    reporteVariasTiendas.Dictionary.Synchronize()
                '    reporteVariasTiendas.Render()
                '    'reporteVariasTiendas.Show()

                'End If

                If DTInformacionReporteVariasTiendasSinCita.Rows.Count > 0 Then
                    VariasTiendas = True
                    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_VT_SCV2")

                    DTInformacionReporteSinCitaAux = objBU.ObtenerHorariosRecibo(OrdenTrabajoSAYVariasTiendaID)
                    For Each Filas As DataRow In DTInformacionReporteSinCitaAux.Rows
                        DTInformacionHorariosRecibeVariasTiendas.Rows.Add(Filas.Item(0), Filas.Item(1), Filas.Item(2))
                    Next

                    DTInformacionHorariosRecibeVariasTiendas.TableName = "dtHorariosOT"

                    dsOrdenTrabajoVariasTiendasSinCita.Tables.Add(DTInformacionHorariosRecibeVariasTiendas)

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                       LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                    reporteVariasTiendasSinCita.Load(archivo)
                    reporteVariasTiendasSinCita.Compile()
                    reporteVariasTiendasSinCita.RegData(dsOrdenTrabajoVariasTiendasSinCita)
                    reporteVariasTiendasSinCita.Dictionary.Clear()
                    reporteVariasTiendasSinCita.Dictionary.Synchronize()
                    reporteVariasTiendasSinCita.Render()
                    'reporteVariasTiendas.Show()
                End If


                If DTInformacionReporteVariasTiendasConCita.Rows.Count > 0 Then
                    VariasTiendas = True
                    entReporte = objReporte.LeerReporteporClave("ALM_OT_TERMINO_VT_CSV2")

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                       LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


                    reporteVariasTiendasConCita.Load(archivo)
                    reporteVariasTiendasConCita.Compile()
                    reporteVariasTiendasConCita.RegData(dsOrdenTrabajoVariasTiendasConCita)
                    reporteVariasTiendasConCita.Dictionary.Clear()
                    reporteVariasTiendasConCita.Dictionary.Synchronize()
                    reporteVariasTiendasConCita.Render()
                    'reporteVariasTiendas.Show()
                End If

            End If


            If OTImpresas > 0 Then
                Dim JoinReport As StiReport = New StiReport
                JoinReport.NeedsCompiling = False
                JoinReport.IsRendered = True
                JoinReport.RenderedPages.Clear()

                If UnaTienda = True Then

                    If IsNothing(reporteUnaTienda.CompiledReport) = False Then
                        For Each Page As Stimulsoft.Report.Components.StiPage In reporteUnaTienda.CompiledReport.RenderedPages
                            Page.Report = JoinReport
                            Page.NewGuid()
                            JoinReport.RenderedPages.Add(Page)
                        Next
                    End If

                    If IsNothing(reporteUnaTiendaSinCita.CompiledReport) = False Then
                        For Each Page As Stimulsoft.Report.Components.StiPage In reporteUnaTiendaSinCita.CompiledReport.RenderedPages
                            Page.Report = JoinReport
                            Page.NewGuid()
                            JoinReport.RenderedPages.Add(Page)
                        Next
                    End If

                End If


                If VariasTiendas = True Then
                    If IsNothing(reporteVariasTiendasSinCita.CompiledReport) = False Then
                        For Each Page As Stimulsoft.Report.Components.StiPage In reporteVariasTiendasSinCita.CompiledReport.RenderedPages
                            Page.Report = JoinReport
                            Page.NewGuid()
                            JoinReport.RenderedPages.Add(Page)
                        Next
                    End If

                    If IsNothing(reporteVariasTiendasConCita.CompiledReport) = False Then
                        For Each Page As Stimulsoft.Report.Components.StiPage In reporteVariasTiendasConCita.CompiledReport.RenderedPages
                            Page.Report = JoinReport
                            Page.NewGuid()
                            JoinReport.RenderedPages.Add(Page)
                        Next
                    End If

                End If

                JoinReport.Show()

                ActualizarEstatusImpresion(OrdenesImprimirID)
            Else
                show_message("Advertencia", "No hay OT seleccionadas.")
            End If




            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub


    Private Sub ActualizarEstatusImpresion(ByVal OrdenImpresas As String)
        Dim splitOrden As String() = Split(OrdenImpresas, ",")
        Dim NumeroFilas As Integer = 0
        Dim OTID As Integer = 0


        NumeroFilas = grdVentas.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Then

                OTID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT"))

                If splitOrden.Where(Function(x) x = OTID).Count > 0 Then
                    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Impreso") = "0" Then

                        objBU.GenerarImpresionOT(OTID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Impreso", "1")
                        grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(index), "UsuarioImpreso", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                    End If
                End If
            End If
        Next



    End Sub

    Private Function ObtenerInformacionTiendas(ByVal OrdenTrabajoID As String) As DataTable
        'Domicilios Tienda
        Dim DTDomicilios As DataTable
        Dim Domicilio As Entidades.OrdenTrabajoDireccionEntrega
        Dim dtTienda As New DataTable
        Dim splitOtdenTrabajo As String() = Split(OrdenTrabajoID, ",")

        dtTienda = New DataTable("dtTiendas")
        With dtTienda
            .Columns.Add("OT")
            .Columns.Add("Tienda")
            .Columns.Add("TotalPares")
            .Columns.Add("Direccion")
            .Columns.Add("TipoEmpaque")
            .Columns.Add("NotasEmpaque")
            .Columns.Add("NotasEmbarque")
            .Columns.Add("RFC")
            .Columns.Add("IDEmbarque")
            .Columns.Add("IDRFC")
            .Columns.Add("RazonSocial")
        End With



        For Each OT As String In splitOtdenTrabajo
            DTDomicilios = objBU.ConsultarDireccionesTienda(OT)

            For Each filaDomicilio As DataRow In DTDomicilios.Rows
                Domicilio = New Entidades.OrdenTrabajoDireccionEntrega

                If IsDBNull(filaDomicilio.Item("IDEmbarque")) = False Then
                    Domicilio.IdEmbarque = filaDomicilio.Item("IDEmbarque").ToString()
                Else
                    Domicilio.IdEmbarque = "---"

                End If

                If IsDBNull(filaDomicilio.Item("IdRazonSocial")) = False Then
                    Domicilio.IDRFC = filaDomicilio.Item("IdRazonSocial").ToString()
                Else
                    Domicilio.IDRFC = "---"

                End If

                If IsDBNull(filaDomicilio.Item("RazonSocial")) = False Then
                    Domicilio.RazonSocial = filaDomicilio.Item("RazonSocial").ToString()
                Else
                    Domicilio.RazonSocial = "----------------------------"

                End If

                If IsDBNull(filaDomicilio.Item("RFC")) = False Then
                    Domicilio.RFC = filaDomicilio.Item("RFC").ToString()
                Else
                    Domicilio.RFC = "----------------------------"

                End If

                If IsDBNull(filaDomicilio.Item("Tienda")) = False Then
                    Domicilio.Tienda = filaDomicilio.Item("Tienda").ToString()
                Else
                    Domicilio.Tienda = "----------------------------"
                End If

                If IsDBNull(filaDomicilio.Item("Tienda")) = False Then
                    Domicilio.Tienda = filaDomicilio.Item("Tienda").ToString()
                Else
                    Domicilio.Tienda = "----------------------------"
                End If

                If IsDBNull(filaDomicilio.Item("DIRECCION")) = False Then
                    Domicilio.Calle = filaDomicilio.Item("DIRECCION").ToString()
                Else
                    Domicilio.Calle = ""
                End If

                If IsDBNull(filaDomicilio.Item("COLONIA")) = False Then
                    Domicilio.Colonia = filaDomicilio.Item("COLONIA").ToString()
                Else
                    Domicilio.Colonia = ""
                End If

                If IsDBNull(filaDomicilio.Item("Noexterior")) = False Then
                    Domicilio.NumeroExterior = filaDomicilio.Item("Noexterior").ToString()
                Else
                    Domicilio.NumeroExterior = ""
                End If

                If IsDBNull(filaDomicilio.Item("Ciudad")) = False Then
                    Domicilio.Ciudad = filaDomicilio.Item("Ciudad").ToString()
                Else
                    Domicilio.Ciudad = ""
                End If

                If IsDBNull(filaDomicilio.Item("Estado")) = False Then
                    Domicilio.Estado = filaDomicilio.Item("Estado").ToString()
                Else
                    Domicilio.Estado = ""
                End If

                If IsDBNull(filaDomicilio.Item("CP")) = False Then
                    Domicilio.CP = filaDomicilio.Item("cp").ToString()
                Else
                    Domicilio.CP = ""
                End If

                If IsDBNull(filaDomicilio.Item("convenio")) = False Then
                    Domicilio.ConvenioTransporte = filaDomicilio.Item("convenio").ToString()
                Else
                    Domicilio.ConvenioTransporte = ""
                End If

                If IsDBNull(filaDomicilio.Item("TotalParesTienda")) = False Then
                    Domicilio.TotalPares = filaDomicilio.Item("TotalParesTienda").ToString()
                Else
                    Domicilio.TotalPares = "0"
                End If

                If IsDBNull(filaDomicilio.Item("ComentariosCita")) = False Then
                    Domicilio.ComentariosCita = filaDomicilio.Item("ComentariosCita").ToString()
                Else
                    Domicilio.ComentariosCita = ""
                End If

                If IsDBNull(filaDomicilio.Item("ENTREGAPEDIDO")) = False Then
                    Domicilio.EntregaPedido = filaDomicilio.Item("ENTREGAPEDIDO").ToString()
                Else
                    Domicilio.EntregaPedido = ""
                End If

                If IsDBNull(filaDomicilio.Item("FacturarPor")) = False Then
                    Domicilio.FacturarPor = filaDomicilio.Item("FacturarPor").ToString()
                Else
                    Domicilio.FacturarPor = "----------------------------"
                End If

                If IsDBNull(filaDomicilio.Item("NOTASVENTAS")) = False Then
                    Domicilio.NotasVentas = filaDomicilio.Item("NOTASVENTAS").ToString()
                Else
                    Domicilio.NotasVentas = "-"
                End If

                If IsDBNull(filaDomicilio.Item("IMPORTEPORVENTA")) = False Then
                    Domicilio.ImportePorVenta = filaDomicilio.Item("IMPORTEPORVENTA").ToString()
                Else
                    Domicilio.ImportePorVenta = "0"
                End If


                If IsDBNull(filaDomicilio.Item("FACTURAR")) = False Then
                    Domicilio.Facturar = filaDomicilio.Item("FACTURAR").ToString()
                Else
                    Domicilio.Facturar = "-"
                End If


                If IsDBNull(filaDomicilio.Item("LUGARENTREGA")) = False Then
                    Domicilio.Lugarentregar = filaDomicilio.Item("LUGARENTREGA").ToString()
                Else
                    Domicilio.Lugarentregar = ""
                End If

                If IsDBNull(filaDomicilio.Item("NOTASVENTAS")) = False Then
                    Domicilio.NotasVentas = filaDomicilio.Item("NOTASVENTAS").ToString()
                Else
                    Domicilio.NotasVentas = ""
                End If

                If IsDBNull(filaDomicilio.Item("NOTASEMBARQUE")) = False Then
                    Domicilio.NotasEmbarque = filaDomicilio.Item("NOTASEMBARQUE").ToString()
                Else
                    Domicilio.NotasEmbarque = ""
                End If

                If IsDBNull(filaDomicilio.Item("ContactoRampa")) = False Then
                    Domicilio.ContactoRampa = filaDomicilio.Item("ContactoRampa").ToString()
                Else
                    Domicilio.ContactoRampa = ""
                End If

                If IsDBNull(filaDomicilio.Item("EMPAQUE")) = False Then
                    Domicilio.Empaque = filaDomicilio.Item("EMPAQUE").ToString()
                Else
                    Domicilio.Empaque = ""
                End If

                If IsDBNull(filaDomicilio.Item("TIPOEMPAQUE")) = False Then
                    Domicilio.TipoEmpaque = filaDomicilio.Item("TIPOEMPAQUE").ToString()
                Else
                    Domicilio.TipoEmpaque = ""
                End If

                If IsDBNull(filaDomicilio.Item("NOTASEMPAQUE")) = False Then
                    Domicilio.NotasEmpaque = filaDomicilio.Item("NOTASEMPAQUE").ToString()
                Else
                    Domicilio.NotasEmpaque = ""
                End If


                dtTienda.Rows.Add(OT, Domicilio.Tienda, CDbl(Domicilio.TotalPares).ToString("n0"), Domicilio.Calle + " #" + Domicilio.NumeroExterior.ToString + " " + Domicilio.Colonia + ", " + Domicilio.Ciudad + "," + Domicilio.Estado + " C.P." + Domicilio.CP, Domicilio.TipoEmpaque, Domicilio.NotasEmpaque, Domicilio.NotasEmbarque, Domicilio.RFC.Trim(), Domicilio.IdEmbarque, Domicilio.IDRFC, Domicilio.RazonSocial)

            Next

        Next

        Return dtTienda


    End Function

    Private Sub archivoPdf(ByVal archivo As Byte())
        'Dim id As String
        'Dim FS As FileStream = Nothing
        'Dim dbbyte As Byte()


        ''Get a stored PDF bytes
        'dbbyte = DirectCast(archivo, Byte())
        ''store file Temporarily 
        'Dim filepath As String = "C:\Users\SISTEMAS16\Desktop\ArchivoPrueba\prueba.pdf"
        ''Assign File path create file
        'FS = New FileStream(filepath, System.IO.FileMode.Create)
        ''Write bytes to create file
        'FS.Write(dbbyte, 0, dbbyte.Length)
        ''Close FileStream instance
        'FS.Close()
        '' Open file after write 
        ''Create instance for process class
        ''Dim Proc As New Process()
        ' ''assign file path for process
        ''Proc.StartInfo.FileName = filepath
        ''Proc.Start()


    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub tmsiAceptar_Click(sender As Object, e As EventArgs) Handles tmsiAceptar.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasAutorizadas As Integer = 0
        Dim FilaYaAutorizada As Integer = 0
        Dim FilaCancelada As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim FilasCoppel As Integer = 0

        Dim FilasAceptar As Integer = 0
        Dim EstatusID As Integer = 0
        Dim ClienteID As Integer = 0
        Dim OrdenTrabajoCadena As String = String.Empty
        Dim OrdenTrabajoSplit As String()
        Try

            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    FilasSeleccionadas += 1

                    EstatusID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID"))
                    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID"))

                    If EstatusID = "120" And ClienteID <> 763 Then
                        FilasAceptar += 1
                        If OrdenTrabajoCadena = String.Empty Then
                            OrdenTrabajoCadena = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        Else
                            OrdenTrabajoCadena = OrdenTrabajoCadena & "," & grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        End If
                    End If

                    If ClienteID = 763 Then
                        FilasCoppel += 1
                    End If

                End If
            Next


            If FilasSeleccionadas = 0 Then
                show_message("Advertencia", "No hay Filas Seleccionadas.")
            Else
                If FilasAceptar = 0 And FilasCoppel = 0 Then
                    show_message("Advertencia", "Solo se pueden aceptar las OTs en estatus de confirmado Ventas.")
                ElseIf FilasAceptar = 0 And FilasCoppel > 0 Then
                    show_message("Advertencia", "Solo se pueden aceptar las OTs en estatus de confirmado Ventas y que no sean de COPPEL.")
                ElseIf FilasAceptar > 0 Then

                    confirmar.mensaje = "Se aceptarán " + FilasAceptar.ToString + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas. ¿Esta seguro de continuar?"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor

                        OrdenTrabajoSplit = Split(OrdenTrabajoCadena, ",")

                        For Each OTId As String In OrdenTrabajoSplit
                            objBU.AceptarOTAlmacen(CInt(OTId), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        Next

                        ObtenerInformacion()
                        Cursor = Cursors.WaitCursor
                        show_message("Exito", "Se han aceptado " + FilasAceptar.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs.")

                        Cursor = Cursors.Default
                    End If

                End If

            End If


            'confirmar.mensaje = "¿Esta seguro de aceptar la OT?"
            'If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    Cursor = Cursors.WaitCursor
            '    NumeroFilas = grdVentas.DataRowCount
            '    For index As Integer = 0 To NumeroFilas Step 1
            '        If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then

            '            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 Then 'COPPEL
            '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 129 Then 'Cancelado o Rezhazado
            '                    FilaCancelada += 1
            '                ElseIf CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) > 121 Then
            '                    FilaYaAutorizada += 1
            '                End If


            '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 120 Then 'Confirmado ventas
            '                    objBU.AceptarOTAlmacen(CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT")), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            '                    FilasAutorizadas += 1
            '                End If
            '            Else
            '                FilasCoppel += 1
            '            End If


            '            FilasSeleccionadas += 1
            '        End If
            '    Next

            '    If FilasSeleccionadas = 0 Then
            '        show_message("Advertencia", "No hay Filas Seleccionadas")
            '    Else

            '        If FilasSeleccionadas = 1 Then
            '            If FilasAutorizadas = 1 Then
            '                ObtenerInformacion()
            '                show_message("Exito", "Se han aceptado " + FilasAutorizadas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs.")
            '            ElseIf FilaCancelada = 1 Then
            '                show_message("Advertencia", "La OT se encuentra cancelado o rechazada.")
            '            ElseIf FilasCoppel = 1 Then
            '                show_message("Advertencia", "Las OTs de COPPEL son solo para consulta.")
            '            Else
            '                If FilaYaAutorizada = 1 Then
            '                    show_message("Advertencia", "La OT ya se encuentra aceptada.")
            '                Else
            '                    show_message("Advertencia", "Solo se pueden aceptar las OTs en estatus de confirmado Ventas.")
            '                End If

            '            End If

            '        Else

            '            If FilasAutorizadas = FilasSeleccionadas Then
            '                ObtenerInformacion()
            '                show_message("Exito", "Se han autorizado: " + FilasAutorizadas.ToString().Trim() + " de " + FilasSeleccionadas.ToString() + " OTs.")
            '            Else
            '                If FilasAutorizadas = 0 Then
            '                    If FilasCoppel > 0 Then
            '                        show_message("Advertencia", "No se han aceptado las OTs, asegurarse que las OTs a aceptar se encuentren en estatus de confirmado ventas y no pertenezcan a COPPEL.")
            '                    Else
            '                        show_message("Advertencia", "No se han aceptado las OTs, asegurarse que las OTs a aceptar se encuentren en estatus de confirmado ventas.")
            '                    End If

            '                Else
            '                    ObtenerInformacion()
            '                    show_message("Exito", "Se han aceptado: " + FilasAutorizadas.ToString().Trim() + " de " + FilasSeleccionadas.ToString().Trim() + " OTs.")
            '                End If

            '            End If

            '        End If

            '    End If

            'End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al aceptar.")
        End Try
    End Sub

    Private Sub tmsiAutorizar_Click(sender As Object, e As EventArgs) Handles tmsiAutorizar.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasAutorizadas As Integer = 0
        Dim FilaYaAutorizada As Integer = 0
        Dim FilaCancelada As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim FilasCoppel As Integer = 0

        Dim FilasAceptar As Integer = 0
        Dim EstatusID As Integer = 0
        Dim ClienteID As Integer = 0
        Dim OrdenTrabajoCadena As String = String.Empty
        Dim OrdenTrabajoSplit As String()
        Dim ListaOTYistiAutorizadas As New List(Of Entidades.OrdenTrabajo)
        Dim OTYISTI As Entidades.OrdenTrabajo

        Dim TotalPares As Integer = 0
        Dim ParesOT As Integer = 0
        Dim ParesCancelados As Integer = 0



        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    FilasSeleccionadas += 1

                    EstatusID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID"))
                    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID"))

                    If (EstatusID = "119" Or EstatusID = "130") And ClienteID <> 763 Then
                        FilasAceptar += 1
                        If OrdenTrabajoCadena = String.Empty Then
                            OrdenTrabajoCadena = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        Else
                            OrdenTrabajoCadena = OrdenTrabajoCadena & "," & grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        End If

                        'Cliente YISTI
                        If ClienteID = 1132 Then

                            OTYISTI = New Entidades.OrdenTrabajo
                            OTYISTI.OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            OTYISTI.TotalPares = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cantidad").ToString()

                            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cancelados").ToString()) = False Then
                                OTYISTI.TotalParesCancelados = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cancelados").ToString()
                            End If

                            OTYISTI.Cliente = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cliente").ToString()
                            OTYISTI.OrdenCliente = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OrdenCliente").ToString()
                            OTYISTI.FechaPreparacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion").ToString()
                            OTYISTI.PedidoSAYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "PedidoSAY").ToString()
                            OTYISTI.PedidoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "PedidoSICY").ToString()

                            ListaOTYistiAutorizadas.Add(OTYISTI)

                        End If
                    End If

                    If ClienteID = 763 Then
                        FilasCoppel += 1
                    End If

                End If
            Next


            If FilasSeleccionadas = 0 Then
                show_message("Advertencia", "No hay Filas Seleccionadas.")
            Else
                If FilasAceptar = 0 And FilasCoppel = 0 Then
                    show_message("Advertencia", "Solo se pueden autorizar las OTs en estatus de activo y rechazadas.")
                ElseIf FilasAceptar = 0 And FilasCoppel > 0 Then
                    show_message("Advertencia", "Solo se pueden autorizar las OTs en estatus de activo y que no sean de COPPEL.")
                ElseIf FilasAceptar > 0 Then

                    confirmar.mensaje = "Se autorizarán " + FilasAceptar.ToString + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas. ¿Esta seguro de continuar?"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor

                        OrdenTrabajoSplit = Split(OrdenTrabajoCadena, ",")

                        For Each OTId As String In OrdenTrabajoSplit
                            objBU.AutorizarOT(CInt(OTId), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        Next

                        ObtenerInformacion()

                        If ListaOTYistiAutorizadas.Count > 0 Then
                            EnviarCorreoYisti(ListaOTYistiAutorizadas)
                        End If
                        Cursor = Cursors.WaitCursor
                        show_message("Exito", "Se han autorizado " + FilasAceptar.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs.")

                        Cursor = Cursors.Default
                    End If
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try





        'Dim NumeroFilas As Integer = 0
        'Dim FilasSeleccionadas As Integer = 0
        'Dim FilasAutorizadas As Integer = 0
        'Dim FilaYaAutorizada As Integer = 0
        'Dim FilaCancelada As Integer = 0
        'Dim confirmar As New Tools.ConfirmarForm
        'Dim FilasCoppel As Integer = 0

        'Try


        '    confirmar.mensaje = "¿Esta seguro de confirmar la OT?"
        '    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '        Cursor = Cursors.WaitCursor
        '        NumeroFilas = grdVentas.DataRowCount
        '        For index As Integer = 0 To NumeroFilas Step 1
        '            If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then

        '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 Then 'COPPEL
        '                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 129 Then 'Cancelado o Rezhazado
        '                        FilaCancelada += 1
        '                    ElseIf CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) > 120 Then
        '                        FilaYaAutorizada += 1
        '                    End If

        '                    'If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) > 120 Then 'Confirmado ventas
        '                    '    FilaYaAutorizada += 1
        '                    'End If

        '                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 119 Then 'Confirmado ventas
        '                        objBU.AutorizarOT(CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT")), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '                        FilasAutorizadas += 1
        '                    End If
        '                Else
        '                    FilasCoppel += 1
        '                End If


        '                FilasSeleccionadas += 1
        '            End If
        '        Next

        '        If FilasSeleccionadas = 0 Then
        '            show_message("Advertencia", "No hay Filas Seleccionadas")
        '        Else

        '            If FilasSeleccionadas = 1 Then
        '                If FilasAutorizadas = 1 Then
        '                    ObtenerInformacion()
        '                    show_message("Exito", "Se han autorizado " + FilasAutorizadas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs.")
        '                ElseIf FilaCancelada = 1 Then
        '                    show_message("Advertencia", "La OT se encuentra cancelado o rechazada.")
        '                ElseIf FilasCoppel = 1 Then
        '                    show_message("Advertencia", "Las OTs  de COPPEL son solo para consulta.")
        '                Else
        '                    If FilaYaAutorizada = 1 Then
        '                        show_message("Advertencia", "La OT ya se encuentra autorizada.")
        '                    Else
        '                        show_message("Advertencia", "Solo se pueden autorizar las OTs en estatus de Activo.")
        '                    End If

        '                End If

        '            Else

        '                If FilasAutorizadas = FilasSeleccionadas Then
        '                    ObtenerInformacion()
        '                    show_message("Exito", "Se han autorizado: " + FilasAutorizadas.ToString().Trim() + " de " + FilasSeleccionadas.ToString() + " OTs.")
        '                Else
        '                    If FilasAutorizadas = 0 Then
        '                        If FilasCoppel > 0 Then
        '                            show_message("Advertencia", "No se han autorizado las OTs, asegurarse que las OTs a autorizar se encuentren en estatus de Activo y no pertenezcan a COPPEL.")
        '                        Else
        '                            show_message("Advertencia", "No se han autorizado las OTs, asegurarse que las OTs a autorizar se encuentren en estatus de Activo.")
        '                        End If

        '                    Else
        '                        ObtenerInformacion()
        '                        show_message("Exito", "Se han autorizado: " + FilasAutorizadas.ToString().Trim() + " de " + FilasSeleccionadas.ToString().Trim() + " OTs.")
        '                    End If

        '                End If

        '            End If

        '        End If

        '    End If

        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    show_message("Error", ex.Message.ToString())
        'End Try
    End Sub

    Private Sub tmsiVerDetalles_Click(sender As Object, e As EventArgs) Handles tmsiVerDetalles.Click
        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim Form As New DetallesOrdenTrabajoForm
        Dim ListClientesSeleccionados As New List(Of Integer)


        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroOrdenesTrabajo += 1
                    If OrdenTrabajoID = String.Empty Then
                        OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                    Else
                        OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                    End If

                    ListClientesSeleccionados.Add(Integer.Parse(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID").ToString()))

                End If

            Next

            If ListClientesSeleccionados.Contains(763) Then
                'mensaje para órdenes de trabajo Coppel
                show_message("Advertencia", "Solo puede consultar los detalles de las OT del cliente Coppel en el menú Almacén – OT Coppel – Órdenes de Trabajo Coppel")
                Exit Sub
            End If

            If OrdenTrabajoID <> String.Empty Then
                Form.OrdenTrabajoID = OrdenTrabajoID
                Form.OrdenTrabajoSICYID = OrdenTrabajoSICYID
                Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
                Form.EsConfirmacion = False
                Form.MdiParent = Me.MdiParent
                Form.Show()
            Else
                show_message("Advertencia", "No se ha seleccionado una OT.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub tmsiAgregarFechaPreparacion_Click(sender As Object, e As EventArgs) Handles tmsiAgregarFechaPreparacion.Click
        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        'Dim FechaPreparacionModificada As Date
        Dim FechaNula As Date = Nothing
        Dim NumeroOrdenesValidas As Integer = 0
        Dim FechaPreparacion As Date = Nothing
        Dim FilasCoppel As Integer = 0
        Dim ClienteID As Integer = 0
        Dim EstatusId As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount()

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroOrdenesTrabajo += 1

                    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID"))
                    EstatusId = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID"))


                    If ClienteID <> "763" Then 'COPPEL
                        If EstatusId = "119" Or EstatusId = "130" Then '119 => ACTIVO, 130 => Rechazada
                            NumeroOrdenesValidas += 1
                            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion")) = False Then
                                FechaPreparacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion").ToString()
                            End If

                            If OrdenTrabajoID = String.Empty Then
                                OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            Else
                                OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            End If
                        End If
                    Else
                        FilasCoppel += 1
                    End If

                End If
            Next


            If NumeroOrdenesTrabajo > 0 And NumeroOrdenesValidas > 0 Then
                Dim Form As New AgregarFechaPreparacionForm
                Form.OrdenTabajoId = OrdenTrabajoID
                Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
                Form.NumeroOrdenesTrabajoValidas = NumeroOrdenesValidas

                If NumeroOrdenesValidas = 1 Then
                    Form.FechaPreparacion = FechaPreparacion
                End If
                If Form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    ObtenerInformacion()
                End If
            Else

                If NumeroOrdenesTrabajo > 0 And NumeroOrdenesValidas = 0 Then
                    If FilasCoppel > 0 Then
                        show_message("Advertencia", "Las OTs ya estan autorizadas o pertenecen a COPPEL, no se puede modificar la fecha preparación.")
                    Else
                        show_message("Advertencia", "Las OTs ya estan autorizadas, no se puede modificar la fecha preparación.")
                    End If

                Else
                    show_message("Advertencia", "No hay ordenes de trabajo seleccionadas.")
                End If

            End If


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString)
        End Try

    End Sub

    Private Sub ActualizarGridFechaPreparacion(ByVal OrdenTrabajoIDSel As String, ByVal FechaPreparacion As Date)

        Dim Ordenes As String() = Split(OrdenTrabajoIDSel, ",")
        Dim ListaOrdenID As New List(Of String)
        Dim OTID As String = String.Empty
        Dim DiasFaltantes As Integer = 0

        For Each Item As String In Ordenes
            ListaOrdenID.Add(Item)
        Next

        For index As Integer = 0 To grdVentas.DataRowCount() Step 1
            OTID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()

            If ListaOrdenID.Contains(OTID) = True Then
                grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion", FechaPreparacion.ToShortDateString())
                DiasFaltantes = DateDiff(DateInterval.Day, Date.Now, FechaPreparacion)
                grdVentas.SetRowCellValue(grdVentas.GetVisibleRowHandle(index), "DiasFaltantes", DiasFaltantes)
            End If

        Next

    End Sub


    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged

        rdoCaptura.Enabled = chkFecha.Checked
        rdoAutorizacion.Enabled = chkFecha.Checked
        rdoPreparacion.Enabled = chkFecha.Checked
        rdoEntrega.Enabled = chkFecha.Checked
        rdoConfirmacion.Enabled = chkFecha.Checked
        dtpFechaInicio.Enabled = chkFecha.Checked
        dtpFechaFin.Enabled = chkFecha.Checked

    End Sub

    Private Sub tmsiDesasignarOperador_Click(sender As Object, e As EventArgs) Handles tmsiDesasignarOperador.Click
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim ObjBU As New Negocios.OrdenTrabajoBU
        Dim confirmacion As New Tools.ConfirmarForm

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasInvalidas As Integer = 0
        Dim FilasValidas As Integer = 0
        Dim listaParametroID As New List(Of String)
        Dim fIlasCoppel As Integer = 0

        Try
            NumeroFilas = grdVentas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index)) = True Then
                    FilasSeleccionadas += 1
                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 Then 'COPPEL
                        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID").ToString() = "121" Or grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID").ToString() = "123" Then

                            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OperadorAsignados")) = False Then
                                FilasValidas += 1
                                If OrdenTrabajoID = String.Empty Then
                                    OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                Else
                                    OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                End If

                            End If
                        Else
                            FilasInvalidas += 1
                        End If
                    Else
                        fIlasCoppel += 1
                    End If
                End If
            Next

            If FilasSeleccionadas = 1 And fIlasCoppel = 1 Then
                show_message("Advertencia", "Las OTs de COPPEL son solo para consulta.")

            ElseIf FilasSeleccionadas > 0 Then
                If FilasSeleccionadas = (FilasInvalidas + fIlasCoppel) Then
                    show_message("Advertencia", "Las OTs seleccionadas no se pueden desasignar operador.")

                Else
                    confirmacion.mensaje = "¿Está seguro que desea desasignar la OT? "
                    Cursor = Cursors.WaitCursor

                    If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        ObjBU.DesasignarOperadorOT(OrdenTrabajoID)
                        ObtenerInformacion()
                        If FilasInvalidas > 0 Then
                            show_message("Exito", "Se ha desasignado el operador a " + FilasValidas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas.")
                        Else
                            show_message("Exito", "Se ha desasignado el operador  a " + FilasValidas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas.")
                        End If

                    End If
                End If

            ElseIf FilasSeleccionadas = 0 Then
                show_message("Advertencia", "No se ha seleccionado una OT.")
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, Button3.Click

        Dim seCancelaOTSurtido As Boolean = True

        Dim DVListadoOTs As DataView = CType(grdVentas.DataSource, DataView)
        Dim DTResultado As DataTable = DVListadoOTs.Table.Copy()

        If DTResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una OT.")
            Return
        End If


        If DTResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("TipoOT")).Distinct.Count <> 1 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Solo se permite cancelar OTs del mismo tipo (SURTIDO o DESASIGNACION).")
            Return
        End If

        Dim Fila = DTResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).FirstOrDefault()
        Dim TIpoOT As String = Fila.Item("TipoOT").ToString

        If TIpoOT = "SURTIDO" Then

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_CANCELAROT") Then
                CancelacionOrdenesTrabajoJefaturaAtencionClientes()
            Else
                CancelacionOrdenesTrabajoAtencionClientes()
            End If

        Else 'DESASGINACION

            CancelarOTDesasignacion()


        End If


        'Dim seCancelaOTSurtido As Boolean = True

        'seCancelaOTSurtido = CancelarOTDesasignacion()

        'If seCancelaOTSurtido Then
        '    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_CANCELAROT") Then
        '        CancelacionOrdenesTrabajoJefaturaAtencionClientes()
        '    Else
        '        CancelacionOrdenesTrabajoAtencionClientes()
        '    End If
        'End If

        'Dim NumeroFilas As Integer = 0
        'Dim NumeroOrdenesTrabajo As Integer = 0
        'Dim NumeroOrdenesTrabajoNoCancelables As Integer = 0
        'Dim OrdenTrabajoID As String = String.Empty
        'Dim OrdenTrabajoSICYID As String = String.Empty
        'Dim Form As New DetallesOrdenTrabajoForm
        'Dim confirmar As New Tools.ConfirmarForm
        'Dim dtResultadoCancelacion As New DataTable
        'Dim DtParesDesasignados As DataTable
        'Dim EsOrdenValida As Boolean = True
        'Dim OrdenTrabajoSeleccionada As Integer = 0
        'Dim OrdenTrabajoDesasignacion As String = String.Empty
        'Dim objCancelacionPedido As New Ventas.Negocios.CancelacionPedidosBU
        'Dim Split_OT_Desasignacion As String()


        'Try
        '    Cursor = Cursors.WaitCursor
        '    NumeroFilas = grdVentas.DataRowCount

        '    For index As Integer = 0 To NumeroFilas Step 1
        '        EsOrdenValida = True

        '        If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
        '            NumeroOrdenesTrabajo += 1

        '            OrdenTrabajoSeleccionada = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '            'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()

        '            If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "TipoOT").ToString() = "DESASIGNACION" Then
        '                DtParesDesasignados = objBU.ParesConfirmadosOT(OrdenTrabajoSeleccionada)
        '                If DtParesDesasignados.Rows.Count > 0 Then
        '                    If DtParesDesasignados.Rows(0).Item(0) > 0 Then
        '                        NumeroOrdenesTrabajoNoCancelables += 1
        '                        EsOrdenValida = False
        '                    Else
        '                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
        '                            NumeroOrdenesTrabajoNoCancelables += 1
        '                            EsOrdenValida = False
        '                        Else
        '                            If OrdenTrabajoDesasignacion = String.Empty Then
        '                                OrdenTrabajoDesasignacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '                                'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        '                            Else
        '                                OrdenTrabajoDesasignacion += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '                                ' OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        '                            End If
        '                        End If
        '                    End If
        '                Else
        '                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
        '                        NumeroOrdenesTrabajoNoCancelables += 1
        '                        EsOrdenValida = False
        '                    Else
        '                        If OrdenTrabajoDesasignacion = String.Empty Then
        '                            OrdenTrabajoDesasignacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '                            'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        '                        Else
        '                            OrdenTrabajoDesasignacion += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '                            ' OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        '                        End If
        '                    End If
        '                End If

        '            Else
        '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
        '                    NumeroOrdenesTrabajoNoCancelables += 1
        '                    EsOrdenValida = False
        '                End If
        '            End If

        '            If EsOrdenValida = True Then
        '                If OrdenTrabajoID = String.Empty Then
        '                    OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '                    'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        '                Else
        '                    OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '                    ' OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        '                End If
        '            End If

        '            'If OrdenTrabajoID = String.Empty Then
        '            '    OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '            '    OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()

        '            '    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "TipoOT").ToString() = "DESASIGNACION" Then
        '            '        DtParesDesasignados = objBU.ParesConfirmadosOT(OrdenTrabajoID)
        '            '        If DtParesDesasignados.Rows.Count > 0 Then
        '            '            If DtParesDesasignados.Rows(0).Item(0) > 0 Then
        '            '                NumeroOrdenesTrabajoNoCancelables += 1
        '            '            Else
        '            '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
        '            '                    NumeroOrdenesTrabajoNoCancelables += 1
        '            '                End If
        '            '            End If
        '            '        Else
        '            '            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
        '            '                NumeroOrdenesTrabajoNoCancelables += 1
        '            '            End If
        '            '        End If

        '            '    Else
        '            '        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
        '            '            NumeroOrdenesTrabajoNoCancelables += 1
        '            '        End If
        '            '    End If

        '            'Else
        '            '    OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '            '    OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        '            'End If
        '        End If

        '    Next

        '    If OrdenTrabajoID <> String.Empty Then
        '        If NumeroOrdenesTrabajoNoCancelables = 0 Then
        '            If NumeroOrdenesTrabajo = 1 Then
        '                Form.OrdenTrabajoID = OrdenTrabajoID
        '                Form.OrdenTrabajoSICYID = OrdenTrabajoSICYID
        '                Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
        '                Form.EsConfirmacion = False
        '                Form.EsCancelacion = True
        '                Form.MdiParent = Me.MdiParent
        '                Form.administrador = Me
        '                Form.CancelarOTDesasignacion = OrdenTrabajoDesasignacion
        '                Form.Show()
        '            Else
        '                'show_message("Advertencia", "Solo se puede cancelar una OT a la vez.")
        '                confirmar.mensaje = "Se cancelarán las OT seleccionadas, este proceso no se puede revertir. ¿Desea continuar?"
        '                If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
        '                    Try
        '                        Cursor = Cursors.WaitCursor
        '                        dtResultadoCancelacion = objBU.CancelarOT(OrdenTrabajoID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '                        If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
        '                            dtResultadoCancelacion = objBU.CancelarParesDeOTSICY(OrdenTrabajoID)

        '                            'Si hay partidas a cancelar de OT de Desasignacion
        '                            Split_OT_Desasignacion = Split(OrdenTrabajoDesasignacion, ",")

        '                            'For Each item As String In Split_OT_Desasignacion
        '                            '    'ReversaCancelacionPedidos
        '                            '    objCancelacionPedido.ReversaCancelacionPedidos(item)
        '                            'Next



        '                            If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
        '                                show_message("Exito", "Se cancelaron correctamente las OT seleccionadas.")
        '                                btnAceptar_Click(sender, e)
        '                            Else
        '                                show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
        '                            End If
        '                        Else
        '                            show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
        '                        End If
        '                    Catch
        '                        show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
        '                    End Try
        '                End If
        '            End If
        '        Else
        '            show_message("Advertencia", "Solo se pueden cancelar OTs ""Activas"", ""Rechazadas"" o de desasignación sin pares confirmados.")
        '        End If
        '    Else
        '        show_message("Advertencia", "No se ha seleccionado ninguna OT.")
        '    End If

        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    show_message("Error", ex.Message.ToString())
        'End Try

        ''Dim punto As Point
        ''punto.X = btnCancelar.Location.X + btnCancelar.Width
        ''punto.Y = btnCancelar.Location.Y + btnCancelar.Height
        ''cmsTipoCancelacion.Show(punto)
        ''Dim NumeroFilas As Integer = 0
        ''Dim NumeroOrdenesTrabajo As Integer = 0
        ''Dim NumeroOrdenesTrabajoNoCancelables As Integer = 0
        ''Dim OrdenTrabajoID As String = String.Empty
        ''Dim OrdenTrabajoSICYID As String = String.Empty
        ''Dim Form As New DetallesOrdenTrabajoForm

        ''Try
        ''    Cursor = Cursors.WaitCursor
        ''    NumeroFilas = grdVentas.DataRowCount

        ''    For index As Integer = 0 To NumeroFilas Step 1

        ''        If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
        ''            NumeroOrdenesTrabajo += 1
        ''            If OrdenTrabajoID = String.Empty Then
        ''                OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        ''                OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        ''                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
        ''                    NumeroOrdenesTrabajoNoCancelables += 1
        ''                End If
        ''            Else
        ''                OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        ''                OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
        ''            End If
        ''        End If

        ''    Next

        ''    If OrdenTrabajoID <> String.Empty Then
        ''        If NumeroOrdenesTrabajo = 1 Then
        ''            If NumeroOrdenesTrabajoNoCancelables = 0 Then
        ''                Form.OrdenTrabajoID = OrdenTrabajoID
        ''                Form.OrdenTrabajoSICYID = OrdenTrabajoSICYID
        ''                Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
        ''                Form.EsConfirmacion = False
        ''                Form.EsCancelacion = True
        ''                Form.MdiParent = Me.MdiParent
        ''                Form.Show()
        ''            Else
        ''                show_message("Advertencia", "Solo se pueden cancelar OTs ""Activas"" o ""Rechazadas"".")
        ''            End If
        ''        Else
        ''            show_message("Advertencia", "Solo se puede cancelar una OT a la vez.")
        ''        End If
        ''    Else
        ''        show_message("Advertencia", "No se ha seleccionado una OT.")
        ''    End If

        ''    Cursor = Cursors.Default
        ''Catch ex As Exception
        ''    Cursor = Cursors.Default
        ''    show_message("Error", ex.Message.ToString())
        ''End Try
    End Sub


#Region "Cancelación OT"

    Private Sub CancelacionOrdenesTrabajoJefaturaAtencionClientes()

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim NumeroOrdenesTrabajoNoCancelables As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim Form As New DetallesOrdenTrabajoForm
        Dim confirmar As New Tools.ConfirmarForm
        Dim dtResultadoCancelacion As New DataTable
        Dim DtParesDesasignados As DataTable
        Dim EsOrdenValida As Boolean = True
        Dim OrdenTrabajoSeleccionada As Integer = 0
        Dim OrdenTrabajoDesasignacion As String = String.Empty
        ' Dim objCancelacionPedido As New Ventas.Negocios.CancelacionPedidosBU
        ' Dim Split_OT_Desasignacion As String()

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1

                EsOrdenValida = True

                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroOrdenesTrabajo += 1

                    OrdenTrabajoSeleccionada = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                    'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()

                    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "TipoOT").ToString() = "DESASIGNACION" Then
                        DtParesDesasignados = objBU.ParesConfirmadosOT(OrdenTrabajoSeleccionada)
                        If DtParesDesasignados.Rows.Count > 0 Then
                            If DtParesDesasignados.Rows(0).Item(0) > 0 Then
                                NumeroOrdenesTrabajoNoCancelables += 1
                                EsOrdenValida = False
                            Else
                                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                                    NumeroOrdenesTrabajoNoCancelables += 1
                                    EsOrdenValida = False
                                Else
                                    If OrdenTrabajoDesasignacion = String.Empty Then
                                        OrdenTrabajoDesasignacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                        'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                                    Else
                                        OrdenTrabajoDesasignacion += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                        ' OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                                    End If
                                End If
                            End If
                        Else
                            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                                NumeroOrdenesTrabajoNoCancelables += 1
                                EsOrdenValida = False
                            Else
                                If OrdenTrabajoDesasignacion = String.Empty Then
                                    OrdenTrabajoDesasignacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                    'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                                Else
                                    OrdenTrabajoDesasignacion += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                    ' OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                                End If
                            End If
                        End If

                    Else
                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                            'OTCoppel Distribución Tiendas
                            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 Then
                                NumeroOrdenesTrabajoNoCancelables += 1
                                EsOrdenValida = False
                            End If

                        End If
                    End If

                    If EsOrdenValida = True Then
                        If OrdenTrabajoID = String.Empty Then
                            OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                        Else
                            OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            ' OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                        End If
                    End If

                End If


                'If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                '    NumeroOrdenesTrabajo += 1
                '    If OrdenTrabajoID = String.Empty Then
                '        OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                '        OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                '        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                '            NumeroOrdenesTrabajoNoCancelables += 1
                '        End If
                '    Else
                '        OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                '        OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                '    End If
                'End If

            Next

            If OrdenTrabajoID <> String.Empty Then
                If NumeroOrdenesTrabajoNoCancelables = 0 Then
                    If NumeroOrdenesTrabajo = 1 And ValidarOTCoppel(OrdenTrabajoID) Then
                        Form.OrdenTrabajoID = OrdenTrabajoID
                        Form.OrdenTrabajoSICYID = OrdenTrabajoSICYID

                        Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
                        Form.EsConfirmacion = False
                        Form.EsCancelacion = True
                        Form.MdiParent = Me.MdiParent
                        Form.administrador = Me
                        Form.Show()
                    Else
                        'OT COppel Distribución Tiendas
                        If Not ValidarOTCoppel(OrdenTrabajoID) Then
                            Dim advertencia As New Tools.AdvertenciaForm
                            advertencia.mensaje = "No se puede cancelar una OT con estatus FACTURADA o CANCELADA."
                            advertencia.ShowDialog()
                            Return
                        End If

                        'show_message("Advertencia", "Solo se puede cancelar una OT a la vez.")
                        confirmar.mensaje = "Se cancelarán las OT seleccionadas, este proceso no se puede revertir. ¿Desea continuar?"
                        If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Try
                                Cursor = Cursors.WaitCursor

                                'OTCoppel DistribucionTiendas
                                'dtResultadoCancelacion = objBU.CancelarOT(OrdenTrabajoID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                                If ValidarOTCoppel(OrdenTrabajoID) Then
                                    dtResultadoCancelacion = objBU.CancelarOT(OrdenTrabajoID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                Else
                                    dtResultadoCancelacion = New DataTable
                                    Dim fila As DataRow
                                    fila = dtResultadoCancelacion.NewRow
                                    fila("resultadoCancelacion") = 0
                                    dtResultadoCancelacion.Rows.Add(fila)
                                End If

                                If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
                                    dtResultadoCancelacion = objBU.CancelarParesDeOTSICY(OrdenTrabajoID)
                                    If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
                                        objBU.ElimnarOtsInWork(OrdenTrabajoID)
                                        show_message("Exito", "Se cancelaron correctamente las OT seleccionadas.")
                                        btnAceptar_Click(Nothing, Nothing)
                                    Else
                                        show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                                    End If
                                Else
                                    show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                                End If
                            Catch ex As Exception
                                show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                            End Try
                        End If
                    End If
                Else
                    show_message("Advertencia", "Solo se pueden cancelar OTs ""Activas"" o ""Rechazadas"".")
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado ninguna OT.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub CancelacionOrdenesTrabajoAtencionClientes()

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim NumeroOrdenesTrabajoNoCancelables As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim Form As New DetallesOrdenTrabajoForm
        Dim confirmar As New Tools.ConfirmarForm
        Dim dtResultadoCancelacion As New DataTable
        'Dim DtParesDesasignados As DataTable
        Dim EsOrdenValida As Boolean = True
        Dim OrdenTrabajoSeleccionada As Integer = 0
        Dim OrdenTrabajoDesasignacion As String = String.Empty
        ' Dim objCancelacionPedido As New Ventas.Negocios.CancelacionPedidosBU
        'Dim Split_OT_Desasignacion As String()

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1

                EsOrdenValida = True

                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroOrdenesTrabajo += 1

                    OrdenTrabajoSeleccionada = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                    'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()

                    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "TipoOT").ToString() = "DESASIGNACION" And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                        NumeroOrdenesTrabajoNoCancelables += 1
                        EsOrdenValida = False
                    Else
                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                            'NumeroOrdenesTrabajoNoCancelables += 1
                            'EsOrdenValida = False
                            'OTCoppel Distribución Tiendas
                            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) <> 763 Then
                                NumeroOrdenesTrabajoNoCancelables += 1
                                EsOrdenValida = False
                            End If
                        Else
                            If OrdenTrabajoDesasignacion = String.Empty Then
                                OrdenTrabajoDesasignacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                            Else
                                OrdenTrabajoDesasignacion += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                                ' OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                            End If
                        End If
                    End If


                    If EsOrdenValida = True Then
                        If OrdenTrabajoID = String.Empty Then
                            OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                        Else
                            OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            ' OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                        End If
                    End If

                End If


            Next

            If OrdenTrabajoID <> String.Empty Then
                If NumeroOrdenesTrabajoNoCancelables = 0 Then
                    'show_message("Advertencia", "Solo se puede cancelar una OT a la vez.")
                    If NumeroOrdenesTrabajo = 1 Then
                        confirmar.mensaje = "Se cancelará la OT seleccionada, este proceso no se puede revertir. ¿Desea continuar?"
                    ElseIf NumeroOrdenesTrabajo > 1 Then
                        confirmar.mensaje = "Se cancelarán las OT seleccionadas, este proceso no se puede revertir. ¿Desea continuar?"
                    End If
                    If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If NumeroOrdenesTrabajo = 1 Then
                            Form.OrdenTrabajoID = OrdenTrabajoID
                            Form.OrdenTrabajoSICYID = OrdenTrabajoSICYID
                            Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
                            Form.EsConfirmacion = False
                            Form.EsCancelacion = True
                            Form.MdiParent = Me.MdiParent
                            Form.administrador = Me
                            Form.Show()
                        Else
                            Try
                                Cursor = Cursors.WaitCursor

                                'OT Coppel DistribucionTiendas
                                'dtResultadoCancelacion = objBU.CancelarOT(OrdenTrabajoID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                If ValidarOTCoppel(OrdenTrabajoID) Then
                                    dtResultadoCancelacion = objBU.CancelarOT(OrdenTrabajoID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                Else
                                    dtResultadoCancelacion = New DataTable
                                    Dim fila As DataRow
                                    fila = dtResultadoCancelacion.NewRow
                                    fila("resultadoCancelacion") = 0
                                    dtResultadoCancelacion.Rows.Add(fila)
                                End If

                                If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
                                    dtResultadoCancelacion = objBU.CancelarParesDeOTSICY(OrdenTrabajoID)
                                    If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
                                        objBU.ElimnarOtsInWork(OrdenTrabajoID)
                                        show_message("Exito", "Se cancelaron correctamente las OT seleccionadas.")
                                        btnAceptar_Click(Nothing, Nothing)
                                    Else
                                        show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                                    End If
                                Else
                                    show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                                End If
                            Catch
                                show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                            End Try
                        End If


                    End If
                Else
                    show_message("Advertencia", "Solo se pueden cancelar OTs ""Activas"".")
                End If
            Else
                If NumeroOrdenesTrabajo > 0 Then
                    show_message("Advertencia", "Solo se pueden cancelar OTs ""Activas"".")
                Else
                    show_message("Advertencia", "No se ha seleccionado ninguna OT.")
                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

#End Region



    Public Sub MostrarInformacion(ByVal sender As Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Dim fechainicio As Date = dtpFechaInicio.Value.ToShortDateString()
        Dim fechafin As Date = dtpFechaFin.Value.ToShortDateString()

        If fechainicio > fechafin Then
            show_message("Advertencia", "La fecha de inicio no puede ser mayor a la de fin.")
        Else
            btnArriba_Click(sender, e)
            ObtenerInformacion()
        End If
        Cursor = Cursors.Default
    End Sub
    'Metodo para obtener la información para paqueterias dependiendo de las OTs filtradas en el gridview
    Public Sub ExportarExcelPaqueterias(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim OrdenesTrabajo As String = String.Empty
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim dtDetalleOTsPaqueteria As New DataTable
        For index As Integer = 0 To grdVentas.DataRowCount Step 1
            If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                If OrdenesTrabajo <> "" Then
                    OrdenesTrabajo += ","
                End If
                OrdenesTrabajo += grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString
            End If
        Next
        If OrdenesTrabajo <> "" Then
            Try
                Cursor = Cursors.WaitCursor
                dtDetalleOTsPaqueteria = objBU.ConsultarDetalleOTsPaqueteria(OrdenesTrabajo)
                gridDetalleOTsPaqueteria.DataSource() = dtDetalleOTsPaqueteria
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        gridExcelExporter.Export(gridDetalleOTsPaqueteria, .SelectedPath + "\Datos_OTs_Paqueteria_" + fecha_hora + ".xlsx")
                        show_message("Exito", "Los datos se exportaron correctamente: " + "\Datos_OTs_Paqueteria_" + fecha_hora + ".xlsx")
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_OTs_Paqueteria_" + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try
            Cursor = Cursors.Default
        Else
            show_message("Advertencia", "No hay ordenes de trabajo seleccionadas.")
        End If
    End Sub




    Private Sub tsmiCancelacionOTCompleta_Click(sender As Object, e As EventArgs) Handles tsmiCancelacionOTCompleta.Click

    End Sub

    Private Sub tsmiCancelacionPartidas_Click(sender As Object, e As EventArgs) Handles tsmiCancelacionPartidas.Click
        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim NumeroOrdenesTrabajoNoCancelables As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim Form As New DetallesOrdenTrabajoForm
        Dim confirmar As New Tools.ConfirmarForm
        Dim dtResultadoCancelacion As New DataTable
        Dim TipoOT As String = String.Empty
        Dim OrdenTrabajoSeleccionada As Integer = 0
        Dim DtParesDesasignados As DataTable
        Dim EsOrdenvalida As Boolean = True
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                EsOrdenvalida = True

                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    NumeroOrdenesTrabajo += 1

                    OrdenTrabajoSeleccionada = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()

                    If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "TipoOT").ToString() = "DESASIGNACION" Then
                        DtParesDesasignados = objBU.ParesConfirmadosOT(OrdenTrabajoSeleccionada)
                        If DtParesDesasignados.Rows.Count > 0 Then
                            If DtParesDesasignados.Rows(0).Item(0) > 0 Then
                                NumeroOrdenesTrabajoNoCancelables += 1
                                EsOrdenvalida = False
                            Else
                                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                                    NumeroOrdenesTrabajoNoCancelables += 1
                                    EsOrdenvalida = False
                                End If
                            End If

                        Else
                            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                                NumeroOrdenesTrabajoNoCancelables += 1
                                EsOrdenvalida = False
                            End If
                        End If
                    Else
                        'OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        'OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                            NumeroOrdenesTrabajoNoCancelables += 1
                            EsOrdenvalida = False
                        End If
                    End If

                    If EsOrdenvalida = True Then
                        If OrdenTrabajoID = String.Empty Then
                            OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        Else
                            OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                        End If
                    End If


                    'If OrdenTrabajoID = String.Empty Then
                    '    OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                    '    OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                    '    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 119 Then
                    '        NumeroOrdenesTrabajoNoCancelables += 1
                    '    End If
                    'Else
                    '    OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                    '    OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
                    'End If

                End If

            Next

            If OrdenTrabajoID <> String.Empty Then
                'If NumeroOrdenesTrabajoNoCancelables = 0 Then

                If NumeroOrdenesTrabajoNoCancelables = 0 Then
                    If NumeroOrdenesTrabajo = 1 Then
                        Form.OrdenTrabajoID = OrdenTrabajoID
                        Form.OrdenTrabajoSICYID = OrdenTrabajoSICYID
                        Form.NumeroOrdenesTrabajo = NumeroOrdenesTrabajo
                        Form.EsConfirmacion = False
                        Form.EsCancelacion = True
                        Form.MdiParent = Me.MdiParent
                        Form.Show()
                    Else
                        'show_message("Advertencia", "Solo se puede cancelar una OT a la vez.")
                        confirmar.mensaje = "Se cancelarán las OT seleccionadas, este proceso no se puede revertir. ¿Desea continuar?"
                        If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Try
                                Cursor = Cursors.WaitCursor
                                objBU.CancelarOT(OrdenTrabajoID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
                                    dtResultadoCancelacion = objBU.CancelarParesDeOTSICY(OrdenTrabajoID)
                                    If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
                                        show_message("Exito", "Se cancelaron correctamente las OT seleccionadas.")
                                    Else
                                        show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                                    End If
                                Else
                                    show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                                End If
                            Catch
                                show_message("Advertencia", "No se cancelaron las OT seleccionadas, vuelva a intentar.")
                            End Try
                        End If
                    End If
                Else
                    show_message("Advertencia", "Solo se pueden cancelar OTs Activas,Rechazadas o de desasignación con pares confirmados.")
                End If


                'Else
                '    show_message("Advertencia", "Solo se pueden cancelar OTs ""Activas"" o ""Rechazadas"".")
                'End If
            Else
                show_message("Advertencia", "No se ha seleccionado ninguna OT.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnEnviarFacturacionAndrea_Click(sender As Object, e As EventArgs) Handles btnEnviarFacturacionAndrea.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilaCancelada As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim FilasAndrea As Integer = 0
        Dim OTAndrea As Integer = 0

        Try

            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    FilasSeleccionadas += 1
                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) = 816 Then 'Andrea
                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 129 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 Then 'Cancelado o Rezhazado
                            FilasAndrea += 1
                            OTAndrea = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT"))
                        End If
                    End If
                End If
            Next

            If FilasSeleccionadas = 1 And FilasAndrea = 1 Then
                Dim VentanaXML As New FacturacionAndreaForm
                VentanaXML.OrdenTrabajoID = OTAndrea
                VentanaXML.Show()
            Else
                If FilasSeleccionadas = 1 Then
                    show_message("Advertencia", "La OT seleccionada no es de Andrea.")
                Else
                    show_message("Advertencia", "Seleccione solo una OT.")
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub tmsiAsignarOperadorAbierto_Click(sender As Object, e As EventArgs) Handles tmsiAsignarOperadorAbierto.Click
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim listado As New ListadoParametrosApartadosForm
        Dim ObjBU As New Negocios.OrdenTrabajoBU
        Dim confirmacion As New Tools.ConfirmarForm

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasInvalidas As Integer = 0
        Dim FilasValidas As Integer = 0
        listado.tipo_busqueda = 10
        Dim listaParametroID As New List(Of String)
        Dim fIlasCoppel As Integer = 0
        Dim FilasAndrea As Integer = 0
        Dim DTOperadorAsignado As DataTable
        Dim split_ordenTrabajo As String()
        Dim OperadoresAsignar As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor

            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index)) = True Then
                    FilasSeleccionadas += 1

                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) = 816 Then 'Andrea
                        FilasAndrea += 1

                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 121 Or CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 123 Or CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 122 Then
                            FilasValidas += 1
                            If OrdenTrabajoID = String.Empty Then
                                OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            Else
                                OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            End If
                        End If

                    End If

                End If

            Next

            If FilasSeleccionadas > 0 Then
                If FilasAndrea > 0 Then

                    If FilasValidas > 0 Then
                        If FilasAndrea = 1 Then
                            DTOperadorAsignado = ObjBU.ConsultaOperadorAsignadoAndrea(OrdenTrabajoID)
                            For Each Fila As DataRow In DTOperadorAsignado.Rows
                                listaParametroID.Add(Fila.Item("OperadorID").ToString)
                            Next
                        End If
                        listado.listaParametroID = listaParametroID
                        listado.ShowDialog(Me)

                        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
                        If listado.listParametros.Rows.Count = 0 Then Return

                        'confirmacion.mensaje = "¿Está seguro que desea asignar operador a " + FilasValidas.ToString() + " de " + FilasSeleccionadas.ToString() + " la OT? "

                        split_ordenTrabajo = Split(OrdenTrabajoID, ",")

                        For Each Operador As DataRow In listado.listParametros.Rows
                            If OperadoresAsignar = String.Empty Then
                                OperadoresAsignar = Operador.Item(0).ToString()
                            Else
                                OperadoresAsignar = OperadoresAsignar & "," & Operador.Item(0).ToString()
                            End If
                        Next

                        For Each OT As String In split_ordenTrabajo
                            ObjBU.AsignaOperadorAndrea(OT, OperadoresAsignar)
                        Next

                        show_message("Exito", "Se ha asignado el operador a " + FilasValidas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas.")


                    Else
                        show_message("Advertencia", "No se puede asignar operador las OTs tiene que estar en status de aceptada, ejecución o parcialmente confirmada.")
                    End If

                Else
                    show_message("Advertencia", "Las filas seleccionadas no pertencen a una OT de Andrea.")
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado una OT.")
            End If

            Cursor = Cursors.Default


        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub tmsiDesasignarOperadorAbierto_Click(sender As Object, e As EventArgs) Handles tmsiDesasignarOperadorAbierto.Click
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Dim ObjBU As New Negocios.OrdenTrabajoBU
        Dim confirmacion As New Tools.ConfirmarForm

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        Dim FilasInvalidas As Integer = 0
        Dim FilasValidas As Integer = 0
        Dim listaParametroID As New List(Of String)
        Dim fIlasCoppel As Integer = 0
        Dim FilasAndrea As Integer = 0
        'Dim DTOperadorAsignado As DataTable
        Dim split_ordenTrabajo As String()
        Dim OperadoresAsignar As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor

            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index)) = True Then
                    FilasSeleccionadas += 1

                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) = 816 Then 'Andrea
                        FilasAndrea += 1

                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 121 Or CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 123 Or CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) = 122 Then
                            FilasValidas += 1
                            If OrdenTrabajoID = String.Empty Then
                                OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            Else
                                OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
                            End If
                        End If

                    End If

                End If

            Next

            If FilasSeleccionadas > 0 Then
                If FilasAndrea > 0 Then
                    If FilasValidas > 0 Then
                        confirmacion.mensaje = "¿Está seguro que desea desasignar operador a " + FilasValidas.ToString() + " de " + FilasSeleccionadas.ToString() + " la OT? "
                        split_ordenTrabajo = Split(OrdenTrabajoID, ",")
                        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                            For Each OT As String In split_ordenTrabajo
                                ObjBU.DesasignaOperadorAndrea(OT)
                            Next
                        End If


                        show_message("Exito", "Se ha desasignado el operador a " + FilasValidas.ToString() + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas.")

                    Else
                        show_message("Advertencia", "No se puede asignar operador las OTs tiene que estar en status de aceptada, ejecución o parcialmente confirmada.")
                    End If

                Else
                    show_message("Advertencia", "Las filas seleccionadas no pertencen a una OT de Andrea.")
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado una OT.")
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub tmsiGenerarXML_Click(sender As Object, e As EventArgs) Handles tmsiGenerarXML.Click
        Dim VentanaXML As New LotesAndreaGenerarXML_form
        VentanaXML.Show()

        'Dim NumeroFilas As Integer = 0
        'Dim FilasSeleccionadas As Integer = 0
        'Dim FilaCancelada As Integer = 0
        'Dim confirmar As New Tools.ConfirmarForm
        'Dim FilasAndrea As Integer = 0
        'Dim OTAndrea As Integer = 0

        'Try

        '    Cursor = Cursors.WaitCursor
        '    NumeroFilas = grdVentas.DataRowCount
        '    For index As Integer = 0 To NumeroFilas Step 1
        '        If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
        '            FilasSeleccionadas += 1
        '            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) = 816 Then 'Andrea
        '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 129 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 Then 'Cancelado o Rezhazado
        '                    FilasAndrea += 1
        '                    OTAndrea = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT"))
        '                End If
        '            End If
        '        End If
        '    Next

        '    If FilasSeleccionadas = 1 And FilasAndrea = 1 Then
        '        Dim VentanaXML As New LotesAndreaGenerarXML_form
        '        VentanaXML.ordenTrabajo = OTAndrea
        '        VentanaXML.Show()
        '    Else
        '        If FilasSeleccionadas = 1 Then
        '            show_message("Advertencia", "La OT seleccionada no es de Andrea.")
        '        Else
        '            show_message("Advertencia", "Seleccione solo una OT.")
        '        End If
        '    End If
        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    show_message("Error", ex.Message.ToString())
        'End Try
    End Sub

    Private Sub tmsiGenerarXMLEtiquetas_Click(sender As Object, e As EventArgs) Handles tmsiGenerarXMLEtiquetas.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim etiquetasform As New GenerarXMLEtiquetasAndreaForm
            etiquetasform.Show()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al mostrar la información, intente de nuevo.")
        End Try


        'Dim NumeroFilas As Integer = 0
        'Dim FilasSeleccionadas As Integer = 0
        'Dim FilaCancelada As Integer = 0
        'Dim confirmar As New Tools.ConfirmarForm
        'Dim FilasAndrea As Integer = 0
        'Dim OTAndrea As Integer = 0

        'Try

        '    Cursor = Cursors.WaitCursor
        '    NumeroFilas = grdVentas.DataRowCount
        '    For index As Integer = 0 To NumeroFilas Step 1
        '        If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
        '            FilasSeleccionadas += 1
        '            If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) = 816 Then 'Andrea
        '                If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 129 And CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 130 Then 'Cancelado o Rezhazado
        '                    FilasAndrea += 1
        '                    OTAndrea = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT"))
        '                End If
        '            End If
        '        End If
        '    Next

        '    If FilasSeleccionadas = 1 And FilasAndrea = 1 Then
        '        Dim etiquetasform As New GenerarXMLEtiquetasAndreaForm
        '        etiquetasform.OrdenTrabajo = OTAndrea
        '        etiquetasform.Show()

        '    Else
        '        If FilasSeleccionadas = 1 Then
        '            show_message("Advertencia", "La OT seleccionada no es de Andrea.")
        '        Else
        '            show_message("Advertencia", "Seleccione solo una OT.")
        '        End If
        '    End If
        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    show_message("Error", ex.Message.ToString())
        'End Try

    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Dim DTINFORMACION As DataTable
    '    Dim sRenglon As String = Nothing
    '    Dim strStreamW As Stream = Nothing
    '    Dim strStreamWriter As StreamWriter = Nothing
    '    Dim ContenidoArchivo As String = Nothing

    '    If System.IO.Directory.Exists("C:\Arc_Sync\") = False Then
    '        System.IO.Directory.CreateDirectory("C:\Arc_Sync\")
    '    End If

    '    Dim PathArchivo As String
    '    DTINFORMACION = objBU.eTIQUETAS()

    '    PathArchivo = "C:\Arc_Sync\\Archivo.txt" ' Se determina el nombre del archivo con la fecha actual

    '    'verificamos si existe el archivo

    '    If File.Exists(PathArchivo) Then
    '        strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
    '    Else
    '        strStreamW = File.Create(PathArchivo) ' lo creamos
    '    End If

    '    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

    '    Dim aTADO As String = String.Empty
    '    Dim aNDREA As String = String.Empty

    '    'escribimos en el archivo
    '    For Each FILA As DataRow In DTINFORMACION.Rows
    '        If FILA.Item("otpp_codigoatado") <> aTADO Then
    '            aTADO = FILA.Item("otpp_codigoatado")
    '            strStreamWriter.WriteLine(FILA.Item("otpp_codigoatado"))
    '            strStreamWriter.WriteLine(FILA.Item("CodigoAndrea"))
    '        Else
    '            strStreamWriter.WriteLine(FILA.Item("CodigoAndrea"))
    '        End If
    '    Next

    '    strStreamWriter.Close() ' cerramos

    'End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    '    Dim DTEtiquetasPasillo As New DataTable

    '    DTEtiquetasPasillo.Columns.Add("Alternativa", GetType(String))
    '    DTEtiquetasPasillo.Columns.Add("Cantidad", GetType(String))


    '    '//Creamos un documento y lo cargamos con los datos del XML.
    '    Dim documento As XmlDocument = New XmlDocument()
    '    documento.Load("C:\Arc_Sync\descarga_Etiquetas_Completo.xml")

    '    ' //Obtenemos una colección con todos los empleados.
    '    Dim listaEmpleados As XmlNodeList = documento.SelectNodes("NewDataSet/Captura")

    '    '    //Creamos un único empleado.
    '    Dim unEmpleado As XmlNode
    '    Dim texto As String
    '    For i As Integer = 0 To listaEmpleados.Count - 1
    '        ' Exit condition if the value is three.
    '        unEmpleado = listaEmpleados.Item(i)
    '        DTEtiquetasPasillo.Rows.Add(unEmpleado.SelectSingleNode("Alternativa").InnerText, unEmpleado.SelectSingleNode("Cantidad").InnerText)

    '        'If unEmpleado.SelectSingleNode("Cantidad").InnerText = 0 Then
    '        '    DTEtiquetasPasillo.Rows.Add(unEmpleado.SelectSingleNode("Alternativa").InnerText, unEmpleado.SelectSingleNode("Cantidad").InnerText)
    '        'End If

    '    Next



    'End Sub

    Private Sub tmsiObservacionesOT_Click(sender As Object, e As EventArgs) Handles tmsiObservacionesOT.Click

        Dim FilasSeleccionadas As Integer = 0
        Dim ObservacionesCita As String = String.Empty
        Dim TextoTieneCita As String = String.Empty
        Dim ClienteID As Integer = 0
        Dim EstatusID As Integer = 0
        Dim FilasObservaciones As Integer = 0
        Dim OrdenTrabajoCadena As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            Dim I As Integer
            For I = 0 To grdVentas.RowCount - 1

                If grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(I)) = True Or CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Seleccionar")) = True Then

                    FilasSeleccionadas += 1
                    ObservacionesCita = String.Empty

                    TextoTieneCita = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cita")
                    EstatusID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID"))
                    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID"))

                    If (EstatusID <> "128" And EstatusID <> "129" And EstatusID <> "130") And ClienteID <> "763" And TextoTieneCita = "NO" Then
                        FilasObservaciones += 1

                        If OrdenTrabajoCadena = String.Empty Then
                            OrdenTrabajoCadena = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OT").ToString()
                        Else
                            OrdenTrabajoCadena = OrdenTrabajoCadena & "," & grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OT").ToString()
                        End If

                    End If

                End If
            Next

            If FilasSeleccionadas = 0 Then
                show_message("Advertencia", "No hay Filas Seleccionadas.")
            Else
                If FilasObservaciones = 0 Then
                    show_message("Advertencia", "No se pueden asignar observaciones a las OT que esten entregas, canceladas o rechazadas o pertenezcana COPPEL.")
                ElseIf FilasObservaciones > 0 Then

                    Dim ObservacionesForm As New CapturaObservacionesOTForm
                    ObservacionesForm.OrdenTrabajoID = OrdenTrabajoCadena
                    If ObservacionesForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        ObtenerInformacion()
                    End If

                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al guardar las observaciones.")
        End Try


    End Sub

    Private Sub tmsiQuitarObservaciones_Click(sender As Object, e As EventArgs) Handles tmsiQuitarObservaciones.Click
        Dim FilasSeleccionadas As Integer = 0
        Dim ObservacionesCita As String = String.Empty
        Dim TextoTieneCita As String = String.Empty
        Dim ClienteID As Integer = 0
        Dim EstatusID As Integer = 0
        Dim FilasObservaciones As Integer = 0
        Dim OrdenTrabajoCadena As String = String.Empty
        Dim confirmar As New Tools.ConfirmarForm

        Try
            Cursor = Cursors.WaitCursor
            Dim I As Integer
            For I = 0 To grdVentas.RowCount - 1

                If grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(I)) = True Or CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Seleccionar")) = True Then

                    FilasSeleccionadas += 1
                    ObservacionesCita = String.Empty

                    TextoTieneCita = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "Cita")
                    EstatusID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "EstatusID"))
                    ClienteID = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "ClienteSAYID"))

                    If EstatusID <> "128" And EstatusID <> "129" And EstatusID <> "130" And ClienteID <> "763" And TextoTieneCita = "NO" Then
                        FilasObservaciones += 1

                        If OrdenTrabajoCadena = String.Empty Then
                            OrdenTrabajoCadena = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OT").ToString()
                        Else
                            OrdenTrabajoCadena = OrdenTrabajoCadena & "," & grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(I), "OT").ToString()
                        End If

                    End If

                End If
            Next

            If FilasSeleccionadas = 0 Then
                show_message("Advertencia", "No hay Filas Seleccionadas.")
            Else
                If FilasObservaciones = 0 Then
                    show_message("Advertencia", "No se pueden eliminar las observaciones a las OT que esten entregas, canceladas o rechazadas o pertenezcana COPPEL.")
                ElseIf FilasObservaciones > 0 Then
                    confirmar.mensaje = "Se eliminarán las observaciones de " + FilasObservaciones.ToString + " de " + FilasSeleccionadas.ToString() + " OTs seleccionadas. ¿Esta seguro de continuar?"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        objBU.EliminarObservacionesOT(OrdenTrabajoCadena)
                        ObtenerInformacion()
                        show_message("Exito", "Se han eliminado las observaciones de " + FilasObservaciones.ToString() + " de " + FilasSeleccionadas.ToString() + " las OTs")
                    End If
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al eliminar las observaciones.")
        End Try

    End Sub


    Private Sub EnviarCorreoYisti(ByVal ListaOTYisti As List(Of Entidades.OrdenTrabajo))

        Dim SumaTotal As New Double
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim correo As New Tools.Correo
        Dim dtDestinatarios As DataTable
        dtDestinatarios = objBU.ConsultarDestinatariosCorreoOTYISTI("ENVIO_OT_YISTI", 1)

        'destinatarios = enviosCorreoBU.consulta_destinatarios_email(1, "ENVIO_OT_YISTI")

        Dim Email As String = "<html>" +
                                "<head>" +
                                  "<style type ='" + "text/css" + "'> body " +
                                  "{display: block; margin: 8px; background: #FFFFFF;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #FFFFFF;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                  "</head>" +
                                  "<body>" +
                                   "<div id='" + "wrapper" + "'>" +
                                    "<div id='" + "header" + "'>" +
                                    "  <br> <font size=2>Usuario que Solicito : " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal + "</font>" +
                                   " </div> <br></br>" +
                                    "<div id='" + "leftcolumn" + "'>" +
                                    "</div>" +
                                    "<div id='" + "rightcolumn" + "'>" +
                                    "</div>" + "<div id='" + "content" + "'>" +
                                      "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "'>" +
                                       "<thead>" +
                                        "<tr class='" + "tableizer-firstrow" + "'>" +
                                        "<th width ='" + "10%" + "'>OT</th>" +
                                        "<th width ='" + "35%" + "'>Cliente</th>" +
                                        "<th width ='" + "10%" + "'>Pedido SAY</th>" +
                                        "<th width ='" + "13%" + "'>Pedido SICY</th>" +
                                        "<th width ='" + "10%" + "'>Fecha Entrega</th>" +
                                        "<th width ='" + "15%" + "'>Orden Cliente</th>" +
                                        "<th width ='" + "10%" + "'>Total Pares</th>" +
                                       "</thead>" +
                                       "<tbody>"
        For Each fila As Entidades.OrdenTrabajo In ListaOTYisti
            Email += "<tr>" +
                                            "<td align='right'>" + fila.OrdenTrabajoID.ToString() + "</td>" +
                                            "<td>" + fila.Cliente + "</td>" +
                                            "<td align='right'>" + fila.PedidoSAYID.ToString() + "</td>" +
                                            "<td align='right'>" + fila.PedidoSICYID.ToString() + "</td>" +
                                            "<td>" + fila.FechaPreparacion.ToShortDateString() + "</td>" +
                                            "<td>" + fila.OrdenCliente + "</td>" +
                                            "<td align='right'>" + CStr((fila.TotalPares - fila.TotalParesCancelados)) + "</td>" +
                                         "</tr>"
        Next


        ' SumaTotal += solicitud.PMonto
        Email += "                 " +
"</tbody>" +
                "</table>" +
                       "</div>" +
                       "<div id='" + "footer" + "'>" +
                       "</div>" +
                   "</div>" +
                "</body>" +
                "</html>"


        If dtDestinatarios.Rows.Count > 0 Then
            correo.EnviarCorreoHtml(dtDestinatarios.Rows(0).Item(1), dtDestinatarios.Rows(0).Item(0), "OT Autorizadas", Email)
        End If


    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim form As New AdministradorOT_Form_Facturacion
        form.MdiParent = Me.MdiParent
        form.Show()


    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim OTYISTI As Entidades.OrdenTrabajo
        Dim NumeroFilas As Integer = 0
        Dim ListaOTYistiAutorizadas As New List(Of Entidades.OrdenTrabajo)

        NumeroFilas = grdVentas.DataRowCount - 1
        For index As Integer = 0 To NumeroFilas Step 1
            OTYISTI = New Entidades.OrdenTrabajo
            OTYISTI.OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
            OTYISTI.TotalPares = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cantidad").ToString()

            If IsDBNull(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cancelados").ToString()) = False Then
                OTYISTI.TotalParesCancelados = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cancelados").ToString()
            End If

            OTYISTI.Cliente = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Cliente").ToString()
            OTYISTI.OrdenCliente = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OrdenCliente").ToString()
            OTYISTI.FechaPreparacion = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "FechaPreparacion").ToString()
            OTYISTI.PedidoSAYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "PedidoSAY").ToString()
            OTYISTI.PedidoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "PedidoSICY").ToString()

            ListaOTYistiAutorizadas.Add(OTYISTI)


        Next
        EnviarCorreoYisti(ListaOTYistiAutorizadas)

    End Sub


    Private Sub btnCancelacionAndrea_Click(sender As Object, e As EventArgs) Handles btnCancelacionAndrea.Click, Button1.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FilaCancelada As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim FilasAndrea As Integer = 0
        Dim OTAndrea As Integer = 0

        Try

            Cursor = Cursors.WaitCursor
            NumeroFilas = grdVentas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grdVentas.IsRowSelected(grdVentas.GetVisibleRowHandle(index))) = True Then
                    FilasSeleccionadas += 1
                    If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID")) = 816 Then 'Andrea
                        If CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "EstatusID")) <> 129 Then 'Cancelado o Rezhazado
                            FilasAndrea += 1
                            OTAndrea = CInt(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT"))
                        End If
                    End If
                End If
            Next

            If FilasSeleccionadas = 1 And FilasAndrea = 1 Then
                Dim CancelarParesAndreaForm As New CancelacionParesAndreaForm
                CancelarParesAndreaForm.OrdenTrabajoID = OTAndrea
                CancelarParesAndreaForm.MdiParent = Me.MdiParent
                CancelarParesAndreaForm.Show()
            Else
                If FilasSeleccionadas = 1 Then
                    show_message("Advertencia", "La OT seleccionada no es de Andrea.")
                Else
                    show_message("Advertencia", "Seleccione solo una OT.")
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnConfirmarArchivoVentas_Click(sender As Object, e As EventArgs) Handles btnConfirmarArchivoVentas.Click
        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty
        Dim Form As New DetallesOrdenTrabajoForm
        Dim EsAndrea As Boolean = False

        Try
            Cursor = Cursors.WaitCursor
            'NumeroFilas = grdVentas.DataRowCount

            'For index As Integer = 0 To NumeroFilas Step 1

            '    If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Then
            '        NumeroOrdenesTrabajo += 1

            '        If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "ClienteSAYID").ToString() = "816" Then
            '            EsAndrea = True
            '        End If

            '        If OrdenTrabajoID = String.Empty Then
            '            OrdenTrabajoID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
            '            OrdenTrabajoSICYID = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
            '        Else
            '            OrdenTrabajoID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
            '            OrdenTrabajoSICYID += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OTSICY").ToString()
            '        End If
            '    End If

            'Next

            Form.OrdenTrabajoID = ""
            Form.OrdenTrabajoSICYID = ""
            Form.NumeroOrdenesTrabajo = 0
            Form.EsConfirmacion = True
            'Form.EsAndrea = EsAndrea
            Form.MdiParent = Me.MdiParent
            Form.Show()


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Function validarSeleccionGrid() As Boolean
        Dim OTsFacturacionAnticpadas As Integer = 0
        FilasSeleccionadas = 0

        For i As Integer = 0 To grdVentas.RowCount - 1
            If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(i), "Seleccionar")) Then
                FilasSeleccionadas += 1
                If grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(i), "FA") = "SI" Then
                    OTsFacturacionAnticpadas += 1
                End If
            End If
        Next

        If OTsFacturacionAnticpadas > 0 Then
            If OTsFacturacionAnticpadas = FilasSeleccionadas Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If



    End Function

    Private Function ValidarOTCoppel(ordenTrabajo As String) As Boolean
        Dim correcto As Boolean = 0
        Dim objBuFacturacionCoppel As New Negocios.FacturacionAnticipadaCoppelBU

        correcto = objBuFacturacionCoppel.ConsultarDocumentosActivos(ordenTrabajo)

        Return correcto

    End Function

    Private Sub btnAsignarASN_Click(sender As Object, e As EventArgs) Handles btnAsignarASN.Click
        ASignarNumeroASN()
        CargarOTs()
    End Sub
    Private Sub ASignarNumeroASN()
        Dim NumeroFilas = grdVentas.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                FilasSeleccionadas += 1
                documentosSeleccionados = documentosSeleccionados & "," & grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT")
            End If
        Next

        If FilasSeleccionadas > 0 Then
            Dim obj As New AsignarNumeroASNForm
            obj.StartPosition = FormStartPosition.CenterParent
            obj.OrdenesTrabjo = documentosSeleccionados
            obj.ShowDialog()
        Else
            show_message("Error", "Selecciona minimo una OT.")
        End If

    End Sub

    Private Sub ObtenerCEDISUsuario()
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)

    End Sub

    Private Sub btnImprimirReporteDesasignacion_Click(sender As Object, e As EventArgs) Handles btnImprimirReporteDesasignacion.Click
        ValidarImpresionOTDesasignacion()
    End Sub

    Private Sub ValidarImpresionOTDesasignacion()
        Dim ordenTrabajo As String = String.Empty
        Dim cantidadRegistros As Integer = 0
        Dim tipoReporte As Integer = 0 ' 0 = General, 1 = Individual (por ot)

        Try
            Cursor = Cursors.WaitCursor
            For index = 0 To grdVentas.DataRowCount - 1
                If CBool(grdVentas.GetRowCellValue(index, "Seleccionar")) And grdVentas.GetRowCellValue(index, "TipoOT") = "DESASIGNACION" Then

                    If ordenTrabajo = String.Empty Then
                        ordenTrabajo += grdVentas.GetRowCellValue(index, "OT").ToString
                    Else
                        ordenTrabajo += "," + grdVentas.GetRowCellValue(index, "OT").ToString
                    End If
                    cantidadRegistros += 1
                End If


            Next

            If cantidadRegistros = 1 Then
                tipoReporte = 1
            ElseIf cantidadRegistros <= 1 Then
                Throw New Exception("No se seleccionaron órdenes de de trabajo")
            End If

            ImprimirReporteDesasignacion(ordenTrabajo, tipoReporte)
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Notice, ex.Message)
        End Try
    End Sub

    Private Sub ImprimirReporteDesasignacion(ordenTrabajo As String, tipoReporte As Integer)
        Dim dtArticulos As DataTable
        Dim dtEncabezado As New DataTable
        Dim dsDatos As New DataSet("dsDatos")
        Dim EntidadReporte As Entidades.Reportes
        Dim objReporte As New Framework.Negocios.ReportesBU

        dtArticulos = objBU.ConsultarReporteOTDesasignacion(ordenTrabajo)

        dtArticulos.TableName = "dtArticulos"

        dsDatos.Tables.Add(dtArticulos)

        If tipoReporte = 0 Then
            EntidadReporte = objReporte.LeerReporteporClave("VTAS_REPTE_OT_DESASIGNACION_GENERAL")
        Else
            dtEncabezado = objBU.ConsultarReporteOTDesasignacion_Encabezado(ordenTrabajo)
            EntidadReporte = objReporte.LeerReporteporClave("VTAS_REPTE_OT_DESASIGNACION")

            If dtEncabezado.Rows.Count = 0 Then
                Throw New Exception("No se pudo recuperar información.")
            End If
        End If

        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport

        reporte.Load(archivo)
        reporte.Compile()
        'reporte("usuarioGeneraReporte") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
        reporte("urlImagenNave") = "http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG"
        reporte("username") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        If tipoReporte = 1 Then
            reporte("OrdenTrabajo") = dtEncabezado.Rows(0).Item("OrdenTrabajo")
            reporte("Cliente") = dtEncabezado.Rows(0).Item("Cliente")
            reporte("PedidoSAY") = dtEncabezado.Rows(0).Item("PedidoSAY")
            reporte("PedidoSICY") = dtEncabezado.Rows(0).Item("PedidoSICY")
            reporte("TotalPares") = dtEncabezado.Rows(0).Item("TotalPares")
            reporte("EstatusOT") = dtEncabezado.Rows(0).Item("EstatusOT")
            reporte("FechaCaptura") = dtEncabezado.Rows(0).Item("FechaCaptura")
            reporte("FechaConfirmacion") = dtEncabezado.Rows(0).Item("FechaConfirmacion")
        End If

        reporte("TotalPorDesasignar") = ObtenerTotal(dtArticulos, "ARTÍCULOS POR DESASIGNAR")
        reporte("TotalEnStock") = ObtenerTotal(dtArticulos, "ARTÍCULOS EN STOCK")
        reporte("TotalAsignados") = ObtenerTotal(dtArticulos, "ARTÍCULOS ASIGNADOS A PEDIDOS")

        reporte.RegData(dsDatos)
        reporte.Dictionary.Synchronize()

        reporte.Show()
    End Sub

    Private Function ObtenerTotal(datos As DataTable, tipo As String) As Integer
        Dim suma As Integer = 0

        For index = 0 To datos.Rows.Count - 1
            If tipo.Equals(datos.Rows(index).Item("Tipo").ToString) Then
                suma += datos.Rows(index).Item("Pares")
            End If
        Next

        Return suma
    End Function

    Private Sub btnReasignarOT_Click(sender As Object, e As EventArgs) Handles btnReasignarOT.Click
        ReasignarOT()
    End Sub

    Private Sub ReasignarOT()
        Dim ordenTrabajo As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            For index = 0 To grdVentas.DataRowCount - 1
                If CBool(grdVentas.GetRowCellValue(index, "Seleccionar")) And
                        grdVentas.GetRowCellValue(index, "TipoOT") = "DESASIGNACION" And
                        CInt(grdVentas.GetRowCellValue(index, "EstatusID")) = 119 Then
                    If ordenTrabajo = 0 Then
                        ordenTrabajo = grdVentas.GetRowCellValue(index, "OT")
                    End If
                End If
            Next

            If ordenTrabajo > 0 Then
                AbrirFormReasignarOT(ordenTrabajo)
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se ha reconocido una OT válida. La OT debe ser de tipo DESASIGNACIÓN y estar en estatus ACTIVA.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Notice, ex.Message)
        End Try
    End Sub

    Private Sub AbrirFormReasignarOT(ordenTrabajo As Integer)
        Dim vistaReasignacion As New ReasignarOTAPedido_Form
        Dim dtResultado As New DataTable
        Dim objBU As New Negocios.ReasignacionOTBU

        dtResultado = objBU.ValidarReasignacionPedido(ordenTrabajo)

        If dtResultado.Rows.Count > 0 Then
            vistaReasignacion.AsignarOrdenTrabajoId(ordenTrabajo)
            vistaReasignacion.ShowDialog()
        Else
            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
        End If

    End Sub

    Private Function CancelarOTDesasignacion() As Boolean
        Dim contadorRegistrosSeleciconados As Integer = 0
        Dim ordenTrabajo As String = String.Empty
        Dim tipoOT As String = String.Empty
        Dim confirmar As New Tools.ConfirmarForm
        Dim validado As Boolean = False
        Dim seVaACancelarOTSurtido As Boolean = False
        Dim Form As New DetallesOrdenTrabajoForm

        Try
            Dim DVListadoOTs As DataView = CType(grdVentas.DataSource, DataView)
            Dim DTResultado As DataTable = DVListadoOTs.Table.Copy()


            Dim FilasSeleccionadas = DTResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True)

            For Each Fila As DataRow In FilasSeleccionadas

                If ordenTrabajo = String.Empty Then
                    ordenTrabajo = Fila.Item("OT").ToString()
                    tipoOT = Fila.Item("TipoOT")
                Else
                    ordenTrabajo += "," + Fila.Item("OT").ToString()
                End If
            Next

            validado = ValidarOTDesasignacion(ordenTrabajo)

            If Not validado Then
                MostrarMensaje(Tools.Mensajes.Notice, "La OT de Desasignación debe de estar ACTIVA para poder ser cancelada.")
                Return seVaACancelarOTSurtido
            End If

            Form.OrdenTrabajoID = ordenTrabajo.ToString
            Form.OrdenTrabajoSICYID = ""

            Form.TipoOT = tipoOT
            Form.EsConfirmacion = False
            Form.EsCancelacion = True
            Form.MdiParent = Me.MdiParent
            Form.administrador = Me
            Form.Show()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try


        Return seVaACancelarOTSurtido

        'Nuevo 
        'Dim NumeroFilas As Integer = grdVentas.DataRowCount

        'Try
        '    Cursor = Cursors.WaitCursor

        '    For index As Integer = 0 To NumeroFilas Step 1
        '        If grdVentas.GetRowCellValue(index, "Seleccionar") Then
        '            If ordenTrabajo = String.Empty Then
        '                ordenTrabajo = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '                tipoOT = grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "TipoOT").ToString
        '            Else
        '                ordenTrabajo += "," + grdVentas.GetRowCellValue(grdVentas.GetVisibleRowHandle(index), "OT").ToString()
        '            End If
        '        End If
        '    Next

        '    validado = ValidarOTDesasignacion(ordenTrabajo)

        '    If Not validado Then
        '        MostrarMensaje(Tools.Mensajes.Notice, "La OT de Desasignación debe de estar ACTIVA para poder ser cancelada.")
        '        Return seVaACancelarOTSurtido
        '    End If

        'For index = 0 To grdVentas.RowCount - 1
        '    If grdVentas.GetRowCellValue(index, "Seleccionar") Then
        '        ordenTrabajo = grdVentas.GetRowCellValue(index, "OT")
        '        contadorRegistrosSeleciconados += 1
        '        tipoOT = grdVentas.GetRowCellValue(index, "TipoOT").ToString

        '        If grdVentas.GetRowCellValue(index, "TipoOT").ToString.Equals("SURTIDO") Then
        '            seVaACancelarOTSurtido = True
        '            Return seVaACancelarOTSurtido
        '        End If
        '    End If
        'Next

        'If contadorRegistrosSeleciconados > 1 Or ordenTrabajo = 0 Then
        '    Tools.MostrarMensaje(Tools.Mensajes.Notice, "Seleccione un registro a la vez.")
        '    Return seVaACancelarOTSurtido
        'End If



        'Form.OrdenTrabajoID = ordenTrabajo.ToString
        '    Form.OrdenTrabajoSICYID = ""

        '    Form.TipoOT = tipoOT
        '    Form.EsConfirmacion = False
        '    Form.EsCancelacion = True
        '    Form.MdiParent = Me.MdiParent
        '    Form.administrador = Me
        '    Form.Show()

        '    'confirmar.mensaje = "¿Cancelar la OT " + ordenTrabajo.ToString + " ?"
        '    'If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    '    Dim cancelado As Boolean = False

        '    '    cancelado = CancelarOrdenTrabajoDesasignacion(ordenTrabajo, "")

        '    '    If Not cancelado Then
        '    '        Tools.MostrarMensaje(Tools.Mensajes.Warning, "No se pudo cancelar la OT.")
        '    '        Return seVaACancelarOTSurtido
        '    '    End If

        '    '    CancelacionOTDesasignacionActualizarPedidos(ordenTrabajo)

        '    '    MostrarMensaje(Tools.Mensajes.Success, "Se ha cancelado la OT: " + ordenTrabajo.ToString)

        '    '    ObtenerInformacion()
        '    'End If

        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        'End Try

        'Return seVaACancelarOTSurtido
    End Function

    Private Function ValidarOTDesasignacion(ordenTrabajo As String) As Boolean
        Dim correcto As Boolean = 0
        Dim objBuReasignacionOt As New Negocios.ReasignacionOTBU

        correcto = objBuReasignacionOt.ValidarEstatusCancelacionOTDesasignacion(ordenTrabajo)

        Return correcto

    End Function

    Private Sub btnModificacionesEspeciales_Click(sender As Object, e As EventArgs) Handles btnModificacionesEspeciales.Click
        Dim form As New ModificacionesEspecialesForm
        Dim OTs As String = String.Empty
        Dim OTsNoValidos As Integer = 0
        Dim PedidosNoValido As Integer = 0
        Dim tabla As New DataTable
        Dim estatus As String = String.Empty
        tabla = grdOts.DataSource

        Me.Cursor = Cursors.WaitCursor

        Try

            Dim filas As Integer = grdVentas.DataRowCount
            If filas > 0 Then
                If validarSeleccionados() > 0 Then
                    If ValidarEstatus(tabla) > 0 Then
                        Tools.MostrarMensaje(Mensajes.Notice, "No es posible realizar cambios a OT´s con Estatus: * EN RUTA, * ENTREGADA," & vbCrLf & " * CANCELADA, * POR REFCTURAR " & vbCrLf & "o Tipo OT: * DESASIGNACION. ")
                    ElseIf validarPedido(tabla) > 0 Then
                        Tools.MostrarMensaje(Mensajes.Notice, "No es posible realizar cambios a OT´s con pedido SAY, SICY u Origen diferentes.")
                    Else

                        For i As Integer = 0 To filas Step 1
                            If grdVentas.GetRowCellValue(i, "Seleccionar") = True Then
                                form.cliente = grdVentas.GetRowCellValue(i, "Cliente")
                                form.clienteId = grdVentas.GetRowCellValue(i, "ClienteSAYID")
                                form.pedidoOrigen = grdVentas.GetRowCellValue(i, "Origen")
                                form.PedidoSAY = grdVentas.GetRowCellValue(i, "PedidoSAY")
                                form.PedidoSICY = grdVentas.GetRowCellValue(i, "PedidoSICY")
                                form.Tipo = grdVentas.GetRowCellValue(i, "Tipo")
                                If OTs = String.Empty Then
                                    OTs = grdVentas.GetRowCellValue(i, "OT")
                                Else
                                    OTs = OTs & "," & grdVentas.GetRowCellValue(i, "OT")
                                End If
                                form.OC = grdVentas.GetRowCellValue(i, "OrdenCliente")
                            End If
                        Next

                        form.Ots = OTs
                        form.MdiParent = Me.MdiParent
                        form.Show()

                    End If
                Else
                    Tools.MostrarMensaje(Mensajes.Notice, "Seleccione al menos un registro.")
                End If
            Else
                Tools.MostrarMensaje(Mensajes.Notice, "No existen registros para realizar modificaciOnes.")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try




    End Sub

    Private Function ValidarEstatus(dtOts As DataTable) As Integer
        Dim OTsNoValidos As Integer = 0
        For i As Integer = 0 To dtOts.Rows.Count Step 1
            If grdVentas.GetRowCellValue(i, "Seleccionar") Then
                If grdVentas.GetRowCellValue(i, "EstatusID") = 127 Or grdVentas.GetRowCellValue(i, "EstatusID") = 128 Or
                    grdVentas.GetRowCellValue(i, "EstatusID") = 129 Or grdVentas.GetRowCellValue(i, "EstatusID") = 168 Or
                    grdVentas.GetRowCellValue(i, "TipoOT") <> "SURTIDO" Then

                    OTsNoValidos += 1

                End If
            End If
        Next

        Return OTsNoValidos
    End Function

    Private Function ValidarEstatus_Ecommerce(tbl_Ots As DataTable) As Integer
        Dim validaEstatus As Integer = 0
        For i As Integer = 0 To tbl_Ots.Rows.Count Step 1
            If grdVentas.GetRowCellValue(i, "Seleccionar") Then
                If grdVentas.GetRowCellValue(i, "EstatusID") = 126 Or grdVentas.GetRowCellValue(i, "EstatusID") = 128 Or
                    grdVentas.GetRowCellValue(i, "EstatusID") = 129 Or
                    grdVentas.GetRowCellValue(i, "TipoOT") <> "SURTIDO" Then
                    validaEstatus += 1
                End If
            End If
            'Dim cols As Integer() = {126, 128, 129, 168}
            'Dim tipoOt As String = "SURTIDO"
            'Dim validacion = From d In tbl_Ots Where Not cols.Contains("EstatusID") And tipoOt.Contains("TipoOT")
        Next
        Return validaEstatus
    End Function

    Private Function Valida_EsClienteEcommerce(tbl_Ots As DataTable) As Integer
        Dim EsClienteEcommerce As Integer = 0
        'Dim mismoPedido As Integer = 0
        'Dim mismoPedidoMismoCliente As Integer = 0

        For i As Integer = 0 To tbl_Ots.Rows.Count Step 1
            If grdVentas.GetRowCellValue(i, "Seleccionar") Then
                'If mismoPedido = 0 Then
                '    mismoPedido = grdVentas.GetRowCellValue(i, "PedidoSAY")
                'End If

                If grdVentas.GetRowCellValue(i, "ClienteSAYID") <> 1198 Then ''''PARA E-COMMERCE ES 1198
                    EsClienteEcommerce += 1
                End If
            End If
        Next

        'If EsClienteEcommerce = 0 Then
        '    For i As Integer = 0 To tbl_Ots.Rows.Count Step 1
        '        If grdVentas.GetRowCellValue(i, "Seleccionar") Then
        '            If grdVentas.GetRowCellValue(i, "PedidoSAY") <> mismoPedido Then
        '                EsClienteEcommerce += 1
        '            End If
        '        End If
        '    Next
        'End If

        Return EsClienteEcommerce
    End Function

    Private Function validarPedido(dtOts As DataTable) As Integer
        Dim PedidosNoValido As Integer = 0
        Dim pedidoSAY As Integer = 0
        Dim pedidoSICY As Integer = 0
        Dim pedidoOrigen As Integer = 0

        Dim pedidoSAYAux As Integer = 0
        Dim pedidoSICYAux As Integer = 0
        Dim pedidoOrigenAux As Integer = 0

        For i As Integer = 0 To dtOts.Rows.Count Step 1
            If grdVentas.GetRowCellValue(i, "Seleccionar") Then


                pedidoSAY = grdVentas.GetRowCellValue(i, "PedidoSAY")
                pedidoSICY = grdVentas.GetRowCellValue(i, "PedidoSICY")
                pedidoOrigen = grdVentas.GetRowCellValue(i, "Origen")

                If pedidoSAYAux = 0 Or pedidoSICYAux = 0 Or pedidoOrigenAux = 0 Then
                    pedidoSAYAux = pedidoSAY
                    pedidoSICYAux = pedidoSICY
                    pedidoOrigenAux = pedidoOrigen
                Else
                    If pedidoSAY <> pedidoSAYAux Or pedidoSICY <> pedidoSICYAux Or pedidoOrigen <> pedidoOrigenAux Then
                        PedidosNoValido += 1
                    End If
                End If

            End If
        Next
        Return PedidosNoValido
    End Function

    Private Function validarSeleccionados() As Integer
        Dim Seleccionados As Integer
        Dim filas As Integer

        filas = grdVentas.RowCount
        For index As Integer = 0 To filas Step 1
            If grdVentas.GetRowCellValue(index, "Seleccionar") Then
                Seleccionados += 1
            End If
        Next

        Return Seleccionados
    End Function

    Private Sub btn_configuracionecommerce_Click(sender As Object, e As EventArgs) Handles btn_configuracionecommerce.Click
        Dim AdminOT As New AdministradorOT_ComplementosForm
        Dim OTs As String = String.Empty
        Dim OTsNoValidos As Integer = 0
        Dim PedidosNoValido As Integer = 0
        Dim tabla As New DataTable
        Dim estatus As String = String.Empty
        tabla = grdOts.DataSource

        Me.Cursor = Cursors.WaitCursor

        Try

            Dim filas As Integer = grdVentas.DataRowCount
            If filas > 0 Then
                If validarSeleccionados() > 0 Then
                    If Valida_EsClienteEcommerce(tabla) = 0 Then
                        If ValidarEstatus_Ecommerce(tabla) > 0 Then
                            Tools.MostrarMensaje(Mensajes.Notice, "No es posible realizar cambios a OT´s con Estatus: * FACTURADA, * ENTREGADA," & vbCrLf & " * CANCELADA ")
                        Else

                            For i As Integer = 0 To filas Step 1
                                If grdVentas.GetRowCellValue(i, "Seleccionar") = True Then
                                    If OTs = String.Empty Then
                                        OTs = grdVentas.GetRowCellValue(i, "OT")
                                    Else
                                        OTs = OTs & "," & grdVentas.GetRowCellValue(i, "OT")
                                    End If
                                End If
                            Next
                            AdminOT._CadenaOts = OTs
                            AdminOT.Show()
                        End If
                    Else
                        Tools.MostrarMensaje(Mensajes.Notice, "Esta acción solo aplica para clientes E-Commerce.")
                    End If
                Else
                    Tools.MostrarMensaje(Mensajes.Notice, "Seleccione al menos una OT.")
                End If
            Else
                Tools.MostrarMensaje(Mensajes.Notice, "No existen registros para realizar modificaciones.")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MyGridControl_MouseEnter(sender As Object, e As EventArgs) Handles grdOts.MouseEnter
        grdOts.Cursor = Cursors.Default
    End Sub

End Class