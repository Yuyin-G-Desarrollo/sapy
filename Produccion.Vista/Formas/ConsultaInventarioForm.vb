
Imports Entidades
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Tools

Public Class ConsultaInventarioForm
    Dim numero As Int32
    Dim EntidadNave As New InventarioProduccion
    Dim EntidadDepartamento As New InventarioProduccion
    Dim detalleLotes As New DetalleLotesForm

    Private Sub ConsultaInventarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Try
            CargarValores(cmbNave.SelectedValue)
            If cmbNave.SelectedValue > 0 Then
                pnlNave.Visible = True
            Else
                pnlNave.Visible = False
            End If
        Catch ex As Exception

        End Try
        pnlNave.Visible = False
        pnlDepartamento.Visible = False

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROD_CONS_INVEN", "INVT_CONSULTA_INVENTARIO_NAVES") Then
            btnConsultaInventarioNaves.Visible = True
            lblConsultaInventarioNaves.Visible = True
        Else
            btnConsultaInventarioNaves.Visible = False
            lblConsultaInventarioNaves.Visible = False
        End If
    End Sub


    Public Sub CargarValores(ByVal idNave As Int32)
        Dim objBu As New LotesAvancesBU

        EntidadNave = objBu.GenerarInventarioNave(idNave)
        If EntidadNave.PInventario <= 0 Then
            EntidadNave.PInventario = 0
        End If
        lblInventarioNaveValor.Text = FormatNumber(EntidadNave.PInventario, 2)
        lblProgramasNaveValor.Text = FormatNumber(EntidadNave.PProgramas, 2)
        lblParesProcesoNaveValor.Text = FormatNumber(EntidadNave.PParesProceso, 0)
        lblParesTerminadosNaveValor.Text = FormatNumber(EntidadNave.PParesTerminadosnave, 0)
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Try

            cmbDepartamentos = Controles.ComboDepartamentosSegunNaveProduccionV2(cmbDepartamentos, cmbNave.SelectedValue)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbDepartamentos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartamentos.SelectedIndexChanged


    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            CargarValores(cmbNave.SelectedValue)
            If cmbNave.SelectedValue > 0 Then
                pnlNave.Visible = True
            Else
                pnlNave.Visible = False
            End If
        Catch ex As Exception

        End Try
        Try
            If cmbDepartamentos.SelectedValue > 0 Then
                pnlDepartamento.Visible = True
            Else
                pnlDepartamento.Visible = False
            End If
            Dim ObjBu As New Global.Produccion.Negocios.LotesAvancesBU
            Dim DepartamentosAnterioresDatos As New DepartamentosProduccion
            DepartamentosAnterioresDatos = ObjBu.DepartamentosAnteriores(cmbNave.SelectedValue, cmbDepartamentos.SelectedValue)
            If cmbDepartamentos.SelectedIndex > 0 Then
                lblTituloInventarioDepartamento.Text = cmbDepartamentos.Text
            End If
            Dim DepartamentoAnterior As Int32
            DepartamentoAnterior = cmbDepartamentos.SelectedValue - 1
            If cmbDepartamentos.Text = "EMBARQUE" Then
                cmbDepartamentos.SelectedIndex = 3
                DepartamentoAnterior = cmbDepartamentos.SelectedValue
                cmbDepartamentos.SelectedIndex = 4
            End If
            EntidadDepartamento = ObjBu.GenerarInventarioDepartamento(cmbNave.SelectedValue, cmbDepartamentos.SelectedValue, DepartamentoAnterior, DepartamentosAnterioresDatos.POrden)
            lblInventarioDEpartamentoDato.Text = FormatNumber(EntidadDepartamento.PInventario, 2)
            lblProgramasDepartamentoDato.Text = FormatNumber(EntidadDepartamento.PProgramas, 2)
            lblProcesoDepartamentoDato.Text = FormatNumber(EntidadDepartamento.PParesProceso, 0)
            lblTerminadosDepartamentoDato.Text = FormatNumber(EntidadDepartamento.PParesTerminadosnave, 0)
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnDetalles1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnDetalles2_Click(sender As Object, e As EventArgs) Handles btnDetalles2.Click

        Try
            Dim MostrarDetalle As New DetalleLotesForm
            MostrarDetalle.PAtrasados = False
            MostrarDetalle.PDepartamentoid = 0
            MostrarDetalle.PNaveid = cmbNave.SelectedValue
            MostrarDetalle.PFechaInicial = EntidadNave.PFecha
            MostrarDetalle.PProceso = False
            MostrarDetalle.PTerminados = False
            MostrarDetalle.Text = "Detalle de Lotes Programados de la Nave " + cmbNave.Text
            MostrarDetalle.lblEncabezado.Text = "Detalle de Lotes Programados de la Nave " + cmbNave.Text

            MostrarDetalle.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDetalles3_Click(sender As Object, e As EventArgs) Handles btnDetalles3.Click
        Dim MostrarDetalle As New DetalleLotesForm
        MostrarDetalle.PAtrasados = False
        MostrarDetalle.PDepartamentoid = 0
        MostrarDetalle.PNaveid = cmbNave.SelectedValue
        MostrarDetalle.PFechaInicial = EntidadNave.PFecha
        MostrarDetalle.PProceso = True
        MostrarDetalle.PTerminados = False
        MostrarDetalle.Text = "Detalle de Lotes en Proceso la Nave " + cmbNave.Text
        MostrarDetalle.lblEncabezado.Text = "Detalle de Lotes en Proceso la Nave " + cmbNave.Text
        MostrarDetalle.validarBotonImprimir = 1
        MostrarDetalle.tipoReporte = 2
        MostrarDetalle.ShowDialog()
    End Sub

    Private Sub btnDetalles4_Click(sender As Object, e As EventArgs) Handles btnDetalles4.Click
        Dim MostrarDetalle As New DetalleLotesForm
        MostrarDetalle.PAtrasados = False
        MostrarDetalle.PDepartamentoid = 0
        MostrarDetalle.PNaveid = cmbNave.SelectedValue
        MostrarDetalle.PFechaInicial = EntidadNave.PFecha
        MostrarDetalle.PProceso = False
        MostrarDetalle.PTerminados = True
        MostrarDetalle.Text = "Detalle de Lotes Terminados de la Nave: " + cmbNave.Text
        MostrarDetalle.lblEncabezado.Text = "Detalle de Lotes Terminados de la Nave " + cmbNave.Text
        MostrarDetalle.ShowDialog()
    End Sub

    Private Sub btnDetalles5_Click(sender As Object, e As EventArgs)
        'Try
        '    If cmbDepartamentos.SelectedValue > 0 Then
        '        Dim MostrarDetalle As New DetalleLotesForm
        '        MostrarDetalle.PAtrasados = False
        '        MostrarDetalle.PDepartamentoid = cmbDepartamentos.SelectedValue
        '        MostrarDetalle.PNaveid = cmbNave.SelectedValue
        '        MostrarDetalle.PFechaInicial = EntidadNave.PFecha
        '        MostrarDetalle.PProceso = False
        '        MostrarDetalle.PTerminados = False
        '        MostrarDetalle.Show()
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub btnDetalles6_Click(sender As Object, e As EventArgs) Handles btnDetalles6.Click
        Try
            If cmbDepartamentos.SelectedValue > 0 Then
                Dim MostrarDetalle As New DetalleLotesForm
                MostrarDetalle.PAtrasados = False
                MostrarDetalle.PDepartamentoid = cmbDepartamentos.SelectedValue
                MostrarDetalle.PNaveid = cmbNave.SelectedValue
                MostrarDetalle.PFechaInicial = EntidadDepartamento.PPrimerFechaDepartamento
                MostrarDetalle.PProceso = False
                MostrarDetalle.PTerminados = False
                MostrarDetalle.Text = "Detalle de Lotes Programados del Departamento " + cmbDepartamentos.Text
                MostrarDetalle.lblEncabezado.Text = "Detalle de Lotes Programados del Departamento " + cmbDepartamentos.Text
                MostrarDetalle.PNombreDepartamento = cmbDepartamentos.Text
                detalleLotes.btnImprimir.Visible = False
                MostrarDetalle.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDetalles7_Click(sender As Object, e As EventArgs) Handles btnDetalles7.Click
        Try
            If cmbDepartamentos.SelectedValue > 0 Then
                Dim MostrarDetalle As New DetalleLotesForm
                MostrarDetalle.PAtrasados = False
                MostrarDetalle.PDepartamentoid = cmbDepartamentos.SelectedValue
                MostrarDetalle.PNaveid = cmbNave.SelectedValue
                MostrarDetalle.PFechaInicial = EntidadDepartamento.PPrimerFechaDepartamento
                MostrarDetalle.PProceso = True
                MostrarDetalle.PTerminados = False
                MostrarDetalle.Text = "Detalle de Lotes en Proceso del Departamento " + cmbDepartamentos.Text
                MostrarDetalle.lblEncabezado.Text = "Detalle de Lotes en Proceso del Departamento " + cmbDepartamentos.Text
                MostrarDetalle.PNombreDepartamento = cmbDepartamentos.Text
                MostrarDetalle.validarBotonImprimir = 1
                MostrarDetalle.tipoReporte = 1
                MostrarDetalle.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDetalles8_Click(sender As Object, e As EventArgs) Handles btnDetalles8.Click
        Try
            If cmbDepartamentos.SelectedValue > 0 Then
                Dim MostrarDetalle As New DetalleLotesForm
                MostrarDetalle.PAtrasados = False
                MostrarDetalle.PDepartamentoid = cmbDepartamentos.SelectedValue
                MostrarDetalle.PNaveid = cmbNave.SelectedValue
                MostrarDetalle.PFechaInicial = EntidadDepartamento.PPrimerFechaDepartamento
                MostrarDetalle.PProceso = False
                MostrarDetalle.PTerminados = True
                MostrarDetalle.Text = "Detalle de Lotes Terminados del Departamento " + cmbDepartamentos.Text
                MostrarDetalle.lblEncabezado.Text = "Detalle de Lotes Terminados del Departamento " + cmbDepartamentos.Text
                MostrarDetalle.PNombreDepartamento = cmbDepartamentos.Text
                detalleLotes.btnImprimir.Visible = False
                MostrarDetalle.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 102
    End Sub

    Private Sub btnConsultaInventarioNaves_Click(sender As Object, e As EventArgs) Handles btnConsultaInventarioNaves.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ventana As New ConsultarInventarioNavesForm
            ventana.Show()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) 
        Me.Cursor = Cursors.WaitCursor
        Dim vReporte As String = cmbDepartamentos.Text
        Select Case vReporte
            Case "CORTE"
                ImprimirReporteCorte()
            Case "PESPUNTE"
                ImprimirReportePespunte()
            Case "MONTADO Y ADORNO"
                ImprimirReporteMontadoYAdorno()
            Case ""
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Selecciona un departamento"
                mensajeAdvertencia.ShowDialog()
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImprimirReporteCorte()

        Dim vFecha As String = ""
        Dim obj As New ReportesSuelaBU
        Dim vResultado As New DataTable
        Dim vReporte As String = cmbDepartamentos.Text
        Dim vIdUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim tabla1 As New DataTable

        tabla1 = obj.ObtieneConcentradoSuela(vFecha, cmbNave.Text, vIdUsuario)
        tabla1.TableName = "dtConcentradoSuela"

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")

        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else

                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_PRODUCCION_SUELA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = "" 'GetRutaLogoPorNave(nave)
                    reporte("fecha") = ""
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "INVENTARIO CORTE"
                    reporte("TituloCelda") = "SUELA"
                    reporte.RegData(tabla1)
                    reporte.Show()

                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ImprimirReportePespunte()

    End Sub

    Private Sub ImprimirReporteMontadoYAdorno()

    End Sub

    Private Sub TraerDatosPantalla()
        Try
            If cmbDepartamentos.SelectedValue > 0 Then
                Dim MostrarDetalle As New DetalleLotesForm
                MostrarDetalle.PAtrasados = False
                MostrarDetalle.PDepartamentoid = cmbDepartamentos.SelectedValue
                MostrarDetalle.PNaveid = cmbNave.SelectedValue
                MostrarDetalle.PFechaInicial = EntidadDepartamento.PPrimerFechaDepartamento
                MostrarDetalle.PProceso = True
                MostrarDetalle.PTerminados = False
                MostrarDetalle.Text = "Detalle de Lotes en Proceso del Departamento " + cmbDepartamentos.Text
                MostrarDetalle.lblEncabezado.Text = "Detalle de Lotes en Proceso del Departamento " + cmbDepartamentos.Text
                MostrarDetalle.PNombreDepartamento = cmbDepartamentos.Text
                'MostrarDetalle.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
