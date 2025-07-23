Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class EnvioCorreosFacturacionForm

    Private ObjBU As New Negocios.EnvioCorreosBU
    Private objBUCorreo As New Facturacion.Negocios.TimbradoFacturasBU
    Dim clone As DataTable
    Private data As DataTable
    Private Sub EnvioCorreosFacturacionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Control.CheckForIllegalCrossThreadCalls = False
        dtpFechaFin.Value = Date.Now
        dtpFechaInicio.Value = Date.Now
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        pgrGenerarDatos.Visible = True
        ConsultarDatos.RunWorkerAsync()
    End Sub

    Private Sub consultarDatosMET()
        Dim DtResultado As DataTable
        Dim FiltroCliente As String = String.Empty
        Dim TipoArchivo As Integer = 0
        Dim StatusCorreo As Integer = 0
        Dim Username As String = String.Empty

        Try

            pgrGenerarDatos.Show()
            'Username = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            Username = Entidades.SesionUsuario.UsuarioSesion.PUsuariosSicy

            FiltroCliente = ObtenerFiltrosGrid(grdFiltroCliente)
            TipoArchivo = ObtenerTipoArchivo()
            StatusCorreo = ObtenerStatusCorreo()
            DtResultado = ObjBU.ConsultaEnvioCorreosFacturas(StatusCorreo, TipoArchivo, dtpFechaInicio.Value, dtpFechaFin.Value, FiltroCliente, "", "", Username)
            data = DtResultado
            UpdateGridDataSource()


        Catch ex As Exception
            Cursor = System.Windows.Forms.Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub
    Private Sub UpdateGridDataSource()
        clone = data.Copy()
        grdConsultaEnvioCorreos.BeginInvoke(New MethodInvoker(AddressOf AnonymousMethod1))
        data = clone
    End Sub

    Private Sub AnonymousMethod1()
        grdConsultaEnvioCorreos.DataSource = clone
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim NumeroFilas As Integer = 0
        Dim IdUnico As Integer = 0
        Dim TipoArchivo As String = String.Empty
        Dim ArchivoEnviado As String = String.Empty
        Dim ContadorArchivoEnviados As Integer = 0
        Dim ContadorArchivoNoEnviados As Integer = 0
        Dim EnviarCorreo As Boolean = 0
        Dim Contador As Integer = 0

        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor

            NumeroFilas = viewConsultaCorreosFacturas.DataRowCount
            If rdoNotasCredito.Checked = True Then
                TipoArchivo = "NCR"
            End If

            For index As Integer = 0 To NumeroFilas - 1 Step 1

                IdUnico = viewConsultaCorreosFacturas.GetRowCellValue(viewConsultaCorreosFacturas.GetVisibleRowHandle(index), "IdUnico").ToString()
                ArchivoEnviado = viewConsultaCorreosFacturas.GetRowCellValue(viewConsultaCorreosFacturas.GetVisibleRowHandle(index), "EnvioXML").ToString()
                EnviarCorreo = CBool(viewConsultaCorreosFacturas.GetRowCellValue(viewConsultaCorreosFacturas.GetVisibleRowHandle(index), "EnviarPdf").ToString())


                If EnviarCorreo = True Then
                    If IdUnico > 0 Then
                        If ArchivoEnviado.Trim = "" Then
                            If objBUCorreo.ReenvioCorreoDoctosElectronicos(IdUnico, TipoArchivo) = True Then
                                ContadorArchivoEnviados += 1
                            Else
                                ContadorArchivoNoEnviados += 1
                            End If
                            Contador += 1
                        End If
                    End If
                End If

            Next

            If Contador > 0 Then
                If ContadorArchivoEnviados > 0 And ContadorArchivoNoEnviados = 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han enviado los correos.")
                ElseIf ContadorArchivoEnviados > 0 And ContadorArchivoNoEnviados > 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Solo se han enviado algunos correos.")
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha podido enviar los correos.")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay correos para enviar.")
            End If

            Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Cursor = System.Windows.Forms.Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 19

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCliente.DataSource = listado.listParametros
        With grdFiltroCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub grdFiltroCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroCliente.DeleteSelectedRows(False)
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

    Private Function ObtenerTipoArchivo() As Integer
        Dim TipoArchivo As Integer = 0

        If rdoNotasCredito.Checked = True Then
            TipoArchivo = 1
        ElseIf rdoNotasCargo.Checked = True Then
            TipoArchivo = 2
        End If

        Return TipoArchivo
    End Function

    Private Function ObtenerStatusCorreo() As Integer
        Dim StatusCorreo As Integer = 0

        If rdoEnviados.Checked = True Then
            StatusCorreo = 1
        ElseIf rdoPendientesEnviar.Checked = True Then
            StatusCorreo = 2
        ElseIf rdoTodos.Checked = True Then
            StatusCorreo = 3
        End If

        Return StatusCorreo

    End Function

    Private Sub MarcarCasillas()
        Dim NumeroFilas As Integer = 0
        Dim CorreoEnviado As String = String.Empty

        Try
            NumeroFilas = viewConsultaCorreosFacturas.DataRowCount

            If NumeroFilas > 0 Then
                For index As Integer = 0 To NumeroFilas - 1 Step 1
                    CorreoEnviado = viewConsultaCorreosFacturas.GetRowCellValue(viewConsultaCorreosFacturas.GetVisibleRowHandle(index), "EmailPdf").ToString()

                    If CorreoEnviado.Trim() = "" Then

                        viewConsultaCorreosFacturas.SetRowCellValue(viewConsultaCorreosFacturas.GetVisibleRowHandle(index), "EnviarPdf", True)
                        viewConsultaCorreosFacturas.SetRowCellValue(viewConsultaCorreosFacturas.GetVisibleRowHandle(index), "EnviarXml", True)

                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Sub viewConsultaCorreosFacturas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewConsultaCorreosFacturas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub ConsultarDatos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ConsultarDatos.DoWork
        consultarDatosMET()
    End Sub

    Private Sub ConsultarDatos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConsultarDatos.RunWorkerCompleted
        DiseñoGrid.DiseñoBaseGrid(viewConsultaCorreosFacturas)
        viewConsultaCorreosFacturas.IndicatorWidth = 30
        viewConsultaCorreosFacturas.OptionsView.ColumnAutoWidth = True
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "IdUnico", "IdUnico", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "Fecha", "Fecha", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "Nombre", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "Iniciales", "Agente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "Folio", "Folio", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "RazonSocial", "Razon Social", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "NcrX", "Ncrx", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "NcrP", "NcrP", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "EnviarPdf", "EnviarPdf", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 40, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "EnviarXml", "EnviarXml", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 40, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "Pagado", "Pagado", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "Rfc", "Rfc", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "Email", "Email", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "emailinfoidservicio", "emailinfoidservicio", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "PATHSAVEFE", "PATHSAVEFE", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "Serie", "Serie", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "EnvioPdf", "EnvioPdf", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 50, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "EmailPdf", "EmailPdf", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "EnvioXML", "EnvioXML", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "EmailXML", "EmailXML", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "RUTAXML", "RUTAXML", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        DiseñoGrid.EstiloColumna(viewConsultaCorreosFacturas, "RUTAPDF", "RUTAPDF", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
        MarcarCasillas()
        pgrGenerarDatos.Visible = False
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub
End Class