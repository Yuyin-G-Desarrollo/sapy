
Imports System.Text.RegularExpressions

Public Class CancelacionPedidos_Form

#Region "Variables"
    Private objetoBU As New Negocios.AdministradorPedidosEscritorioBU
    Private pedidoSAY As Integer = 0
    Private listaPartidasACancelar As String = String.Empty
    Public listaPedidosParaCancelar As New List(Of Integer)
    Dim erroneoColor As Color = Color.Red
    Dim normalColor As Color = Color.Black
    Dim expresion As New Regex("^[A-Za-z]+((\s)?([A-Za-z])+)*$")
    Dim objBU As New Tools.Correo
    Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
    Dim pedidosConPartidas As New Dictionary(Of Integer, String)
    Public DtPartidasACancelar As DataTable
    Public CancelarPorPartidas As Boolean = False


#End Region

#Region "Eventos"
    Private Sub CancelacionPedidos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSolicita.Select()
        ObtenerMotivosCancelacion()
        If CancelarPorPartidas = True Then
            ObtenerSumatoriaParesACancelarDeTodosLosPedidosPartidas()
        Else
            ObtenerSumatoriaParesACancelarDeTodosLosPedidos()
        End If

        'If pedidosConPartidas.Count > 0 Then
        '    ObtenerSumatoriaParesACancelarDeTodosLosPedidos(pedidosConPartidas)
        'ElseIf listaPedidosParaCancelar.Count = 0 Then
        '    ObtenerSumatoriaParesACancelar()
        'Else
        '    ObtenerSumatoriaParesACancelarDeTodosLosPedidos()
        'End If

    End Sub

    Private Sub CancelacionPedidos_Form_closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        If Me.DialogResult <> DialogResult.OK Then
            Me.DialogResult = DialogResult.Cancel
        End If


    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        DialogResult = DialogResult.None

        If CancelarPorPartidas = True Then
            CancelarPartidas()
        Else
            CancelarPedidos()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub
#End Region


#Region "Metodos"
    Public Sub SetPedidoSAY(pedidoSAY As Integer)
        Me.pedidoSAY = pedidoSAY
    End Sub

    Public Sub SetPedidosSAY(listaPedidosSAY As List(Of Integer))
        listaPedidosParaCancelar = listaPedidosSAY
    End Sub

    Private Sub ObtenerMotivosCancelacion()
        Dim dtResultado As New DataTable

        dtResultado = objetoBU.ConsultarMotivosCancelacion

        If dtResultado.Rows.Count > 0 Then
            cmbMotivo.DataSource = dtResultado
            cmbMotivo.ValueMember = "estatusid"
            cmbMotivo.DisplayMember = "descripcion"
        End If

    End Sub

    Private Sub ObtenerSumatoriaParesACancelar()
        Dim dtResultado As New DataTable

        dtResultado = objetoBU.ConsultarSumatoriaParesACancelar(pedidoSAY, listaPartidasACancelar)

        txtParesACancelar.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresACancelar"), 0)
        txtParesEnInventario.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnInventario"), 0)
        txtParesEnProceso.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnProceso"), 0)

    End Sub

    'Private Sub ObtenerSumatoriaParesACancelarDeTodosLosPedidos()
    '    Dim dtResultado As New DataTable
    '    Dim dtResultadoTotal As New DataTable
    '    Dim partidasPedido As String = String.Empty

    '    dtResultadoTotal.Columns.Add("paresACancelar")
    '    dtResultadoTotal.Columns.Add("paresEnInventario")
    '    dtResultadoTotal.Columns.Add("paresEnProceso")

    '    Dim row = dtResultadoTotal.NewRow()

    '    row.Item("paresACancelar") = 0
    '    row.Item("paresEnInventario") = 0
    '    row.Item("paresEnProceso") = 0

    '    For index = 0 To listaPedidosParaCancelar.Count - 1
    '        partidasPedido = objetoBU.ObtenerPartidasDelPedido(listaPedidosParaCancelar(index)).Rows(0).Item("partidas")

    '        dtResultado = objetoBU.ConsultarSumatoriaParesACancelar(listaPedidosParaCancelar(index), partidasPedido)

    '        row.Item("paresACancelar") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresACancelar"), 0)
    '        row.Item("paresEnInventario") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnInventario"), 0)
    '        row.Item("paresEnProceso") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnProceso"), 0)
    '    Next

    '    dtResultadoTotal.Rows.Add(row)

    '    txtParesACancelar.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresACancelar"), 0)
    '    txtParesEnInventario.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresEnInventario"), 0)
    '    txtParesEnProceso.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresEnProceso"), 0)

    'End Sub

    Private Sub ObtenerSumatoriaParesACancelarDeTodosLosPedidos()
        Dim dtResultado As New DataTable
        Dim dtResultadoTotal As New DataTable
        Dim partidasPedido As String = String.Empty

        dtResultadoTotal.Columns.Add("paresACancelar")
        dtResultadoTotal.Columns.Add("paresEnInventario")
        dtResultadoTotal.Columns.Add("paresEnProceso")

        Dim row = dtResultadoTotal.NewRow()

        row.Item("paresACancelar") = 0
        row.Item("paresEnInventario") = 0
        row.Item("paresEnProceso") = 0

        For Each Pedido As String In DtPartidasACancelar.AsEnumerable.Select(Function(x) x.Item("Pedido")).ToList
            partidasPedido = objetoBU.ObtenerPartidasDelPedido(Pedido).Rows(0).Item("partidas")

            dtResultado = objetoBU.ConsultarSumatoriaParesACancelar(Pedido, partidasPedido)

            row.Item("paresACancelar") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresACancelar"), 0)
            row.Item("paresEnInventario") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnInventario"), 0)
            row.Item("paresEnProceso") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnProceso"), 0)
        Next


        'For index = 0 To listaPedidosParaCancelar.Count - 1
        '    partidasPedido = objetoBU.ObtenerPartidasDelPedido(listaPedidosParaCancelar(index)).Rows(0).Item("partidas")

        '    dtResultado = objetoBU.ConsultarSumatoriaParesACancelar(listaPedidosParaCancelar(index), partidasPedido)

        '    row.Item("paresACancelar") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresACancelar"), 0)
        '    row.Item("paresEnInventario") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnInventario"), 0)
        '    row.Item("paresEnProceso") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnProceso"), 0)
        'Next

        dtResultadoTotal.Rows.Add(row)

        txtParesACancelar.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresACancelar"), 0)
        txtParesEnInventario.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresEnInventario"), 0)
        txtParesEnProceso.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresEnProceso"), 0)

    End Sub

    Private Sub ObtenerSumatoriaParesACancelarDeTodosLosPedidosPartidas()
        Dim dtResultado As New DataTable
        Dim dtResultadoTotal As New DataTable
        Dim partidasPedido As String = String.Empty

        dtResultadoTotal.Columns.Add("paresACancelar")
        dtResultadoTotal.Columns.Add("paresEnInventario")
        dtResultadoTotal.Columns.Add("paresEnProceso")

        Dim row = dtResultadoTotal.NewRow()

        row.Item("paresACancelar") = 0
        row.Item("paresEnInventario") = 0
        row.Item("paresEnProceso") = 0

        For Each Pedido As DataRow In DtPartidasACancelar.Rows

            dtResultado = objetoBU.ConsultarSumatoriaParesACancelar(Pedido.Item("Pedido"), Pedido.Item("Partida"))

            row.Item("paresACancelar") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresACancelar"), 0)
            row.Item("paresEnInventario") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnInventario"), 0)
            row.Item("paresEnProceso") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnProceso"), 0)


        Next


        dtResultadoTotal.Rows.Add(row)
        'For Each item As KeyValuePair(Of Integer, String) In pedidosConPartidas

        '    dtResultado = objetoBU.ConsultarSumatoriaParesACancelar(item.Key, item.Value)

        '    row.Item("paresACancelar") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresACancelar"), 0)
        '    row.Item("paresEnInventario") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnInventario"), 0)
        '    row.Item("paresEnProceso") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnProceso"), 0)
        'Next



        txtParesACancelar.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresACancelar"), 0)
        txtParesEnInventario.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresEnInventario"), 0)
        txtParesEnProceso.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresEnProceso"), 0)

    End Sub


    'Private Sub ObtenerSumatoriaParesACancelarDeTodosLosPedidos(pedidosConPartidas As Dictionary(Of Integer, String))
    '    Dim dtResultado As New DataTable
    '    Dim dtResultadoTotal As New DataTable
    '    Dim partidasPedido As String = String.Empty

    '    dtResultadoTotal.Columns.Add("paresACancelar")
    '    dtResultadoTotal.Columns.Add("paresEnInventario")
    '    dtResultadoTotal.Columns.Add("paresEnProceso")

    '    Dim row = dtResultadoTotal.NewRow()

    '    row.Item("paresACancelar") = 0
    '    row.Item("paresEnInventario") = 0
    '    row.Item("paresEnProceso") = 0



    '    For Each item As KeyValuePair(Of Integer, String) In pedidosConPartidas

    '        dtResultado = objetoBU.ConsultarSumatoriaParesACancelar(item.Key, item.Value)

    '        row.Item("paresACancelar") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresACancelar"), 0)
    '        row.Item("paresEnInventario") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnInventario"), 0)
    '        row.Item("paresEnProceso") += IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultado.Rows(0).Item("paresEnProceso"), 0)
    '    Next

    '    dtResultadoTotal.Rows.Add(row)

    '    txtParesACancelar.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresACancelar"), 0)
    '    txtParesEnInventario.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresEnInventario"), 0)
    '    txtParesEnProceso.Text = IIf(Not IsDBNull(dtResultado.Rows(0)), dtResultadoTotal.Rows(0).Item("paresEnProceso"), 0)

    'End Sub

    Public Sub SetListaPartidasACancelar(listaPartidasACancelar As String)
        Me.listaPartidasACancelar = listaPartidasACancelar
    End Sub

    Private Sub CancelarPartidas()
        Dim dtResultado As New DataTable
        Dim resultadoDialog As DialogResult
        Dim confirmarDialog As New ConfirmarForm
        Dim Partidas As String = String.Empty

        Try
            ValidarControl(txtSolicita, lblSolicita, "Favor de ingresar la persona que solicita.")
            ValidarNombreSolicita(txtSolicita.Text)
            ValidarControl(cmbMotivo, lblMotivo, "Favor de ingresar un motivo de cancelación.")
            ValidarControl(txtObservaciones, lblObservaciones, "Favor de ingresar las observaciones.")

            confirmarDialog.mensaje = "¿Confirmar cancelación?" + vbCrLf + vbCrLf + "Esta acción no se puede deshacer."

            resultadoDialog = confirmarDialog.ShowDialog

            Cursor = Cursors.WaitCursor

            If resultadoDialog = DialogResult.OK Then

                pnPBar.Visible = True
                pBar.Minimum = 0
                pBar.ForeColor = Color.Blue
                System.Windows.Forms.Application.DoEvents()

                pBar.Maximum = DtPartidasACancelar.Rows.Count()

                lblNumeroDocumentos.Text = DtPartidasACancelar.Rows.Count().ToString()

                lblInfo.Text = "Iniciando...."
                System.Windows.Forms.Application.DoEvents()

                For Each Pedido As String In DtPartidasACancelar.AsEnumerable.Select(Function(x) x.Item("Pedido")).ToList

                    lblInfo.Text = "Cancelando pedido SAY  " + Pedido
                    System.Windows.Forms.Application.DoEvents()
                    pBar.Value = pBar.Value + 1
                    'Dim ListaPartidas = DtPartidasACancelar.AsEnumerable().Where(Function(x) x.Item("Pedido") = Pedido).Select(Function(y) y.Item("Partida")).ToList()
                    'Partidas = String.Join(",", ListaPartidas)
                    pedidoSAY = Pedido
                    Partidas = DtPartidasACancelar.AsEnumerable().Where(Function(x) x.Item("Pedido") = Pedido).Select(Function(Y) Y.Item("Partida")).FirstOrDefault()

                    dtResultado = objetoBU.CancelarPartidas(pedidoSAY, Partidas, txtSolicita.Text, cmbMotivo.SelectedValue, txtObservaciones.Text)

                    If dtResultado.Rows.Count > 0 Then
                        EnviarCorreoAlCancelarLotes(2, dtResultado.Rows(0).Item(0), pedidoSAY)

                    End If

                    'Tools.MostrarMensaje(Tools.Mensajes.Success, "Cancelación exitosa")
                    'MostrarMensajeCancelacion(dtResultado.Rows(0).Item("validado"), dtResultado.Rows(0).Item("mensaje"))

                    'EnviarCorreoAlCancelarLotes(CInt(dtResultado.Rows(0).Item("validado")), dtResultado.Rows(0).Item("partidasSinLotes"), pedidoSAY)

                    System.Windows.Forms.Application.DoEvents()

                    lblDocumentosFacturados.Text = pBar.Value.ToString()
                Next

                DialogResult = DialogResult.OK
                pnPBar.Visible = False
                Me.DialogResult = DialogResult.OK

            End If

            Me.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Warning, ex.Message)
        End Try

    End Sub


    Private Sub CancelarPedidos()
        Dim dtResultado As New DataTable
        Dim resultadoDialog As DialogResult
        Dim confirmarDialog As New ConfirmarForm
        Dim Partidas As String = String.Empty

        Try
            ValidarControl(txtSolicita, lblSolicita, "Favor de ingresar la persona que solicita.")
            ValidarNombreSolicita(txtSolicita.Text)
            ValidarControl(cmbMotivo, lblMotivo, "Favor de ingresar un motivo de cancelación.")
            ValidarControl(txtObservaciones, lblObservaciones, "Favor de ingresar las observaciones.")

            confirmarDialog.mensaje = "¿Confirmar cancelación?" + vbCrLf + vbCrLf + "Esta acción no se puede deshacer."

            resultadoDialog = confirmarDialog.ShowDialog

            Cursor = Cursors.WaitCursor

            If resultadoDialog = DialogResult.OK Then

                pnPBar.Visible = True
                pBar.Minimum = 0
                pBar.ForeColor = Color.Blue
                System.Windows.Forms.Application.DoEvents()

                pBar.Maximum = DtPartidasACancelar.Rows.Count()

                lblNumeroDocumentos.Text = DtPartidasACancelar.Rows.Count().ToString()

                lblInfo.Text = "Iniciando...."
                System.Windows.Forms.Application.DoEvents()

                For Each Pedido As String In DtPartidasACancelar.AsEnumerable.Select(Function(x) x.Item("Pedido")).ToList

                    lblInfo.Text = "Cancelando pedido SAY  " + Pedido
                    System.Windows.Forms.Application.DoEvents()
                    pBar.Value = pBar.Value + 1
                    pedidoSAY = Pedido

                    dtResultado = objetoBU.CancelarPedidos(pedidoSAY, txtSolicita.Text, cmbMotivo.SelectedValue, txtObservaciones.Text)

                    'Tools.MostrarMensaje(Tools.Mensajes.Success, "Cancelación exitosa")
                    'MostrarMensajeCancelacion(dtResultado.Rows(0).Item("validado"), dtResultado.Rows(0).Item("mensaje"))
                    If dtResultado.Rows.Count > 0 Then
                        EnviarCorreoAlCancelarLotes(2, dtResultado.Rows(0).Item(0), pedidoSAY)

                    End If



                    System.Windows.Forms.Application.DoEvents()
                    lblDocumentosFacturados.Text = pBar.Value.ToString()
                Next

                DialogResult = DialogResult.OK
                pnPBar.Visible = False
                Me.DialogResult = DialogResult.OK

            End If

            Me.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Warning, ex.Message)
        End Try

    End Sub

    Public Sub CancelarPartidas(pedidoConPartidas As Dictionary(Of Integer, String))
        Dim dtResultado As New DataTable
        Dim dtResultadoTotalCancelados As New DataTable
        Dim dtResultadoTotalNoCancelados As New DataTable
        Dim resultadoDialog As DialogResult
        Dim confirmarDialog As New ConfirmarForm

        Try
            ValidarControl(txtSolicita, lblSolicita, "Favor de ingresar la persona que solicita.")
            ValidarNombreSolicita(txtSolicita.Text)
            ValidarControl(cmbMotivo, lblMotivo, "Favor de ingresar un motivo de cancelación.")
            ValidarControl(txtObservaciones, lblObservaciones, "Favor de ingresar las observaciones.")

            confirmarDialog.mensaje = "¿Confirmar cancelación?" + vbCrLf + vbCrLf + "Esta acción no se puede deshacer."

            resultadoDialog = confirmarDialog.ShowDialog

            If resultadoDialog = DialogResult.OK Then
                Dim dtRow As DataRow = Nothing

                Cursor = Cursors.WaitCursor


                dtResultadoTotalCancelados.Columns.Add("PedidoSAY", GetType(Integer))
                dtResultadoTotalCancelados.Columns.Add("Partidas", GetType(String))
                dtResultadoTotalCancelados.Columns.Add("Estatus", GetType(String))
                dtResultadoTotalCancelados.Columns.Add("Mensaje", GetType(String))
                dtResultadoTotalCancelados.Columns.Add("Facturas", GetType(String))
                dtResultadoTotalCancelados.Columns.Add("OrdenesTrabajo", GetType(String))
                dtResultadoTotalCancelados.Columns.Add("PartidasSinLotes", GetType(String))
                dtResultadoTotalCancelados.Columns.Add("OrdenesDesasignacion", GetType(String))
                dtResultadoTotalNoCancelados.Columns.Add("PedidoSAY", GetType(Integer))
                dtResultadoTotalNoCancelados.Columns.Add("Partidas", GetType(String))
                dtResultadoTotalNoCancelados.Columns.Add("Estatus", GetType(String))
                dtResultadoTotalNoCancelados.Columns.Add("Mensaje", GetType(String))
                dtResultadoTotalNoCancelados.Columns.Add("Facturas", GetType(String))
                dtResultadoTotalNoCancelados.Columns.Add("OrdenesTrabajo", GetType(String))
                dtResultadoTotalNoCancelados.Columns.Add("PartidasSinLotes", GetType(String))
                dtResultadoTotalNoCancelados.Columns.Add("OrdenesDesasignacion", GetType(String))

                For Each item As KeyValuePair(Of Integer, String) In pedidoConPartidas
                    dtResultado = objetoBU.CancelarPartidas(item.Key, item.Value, txtSolicita.Text, cmbMotivo.SelectedValue, txtObservaciones.Text)

                    EnviarCorreoAlCancelarLotes(CInt(dtResultado.Rows(0).Item("validado")), dtResultado.Rows(0).Item("partidasSinLotes"), item.Key)

                    If CBool(dtResultado.Rows(0).Item("validado")) Then
                        dtRow = dtResultadoTotalCancelados.NewRow
                        dtRow("PedidoSAY") = item.Key
                        dtRow("Partidas") = item.Value
                        dtRow("Estatus") = "Cancelado"
                        dtRow("Mensaje") = dtResultado.Rows(0).Item("mensaje")
                        dtRow("Facturas") = dtResultado.Rows(0).Item("facturas")
                        dtRow("OrdenesTrabajo") = dtResultado.Rows(0).Item("otActivas")
                        dtRow("PartidasSinLotes") = dtResultado.Rows(0).Item("partidasSinLotes")
                        dtRow("OrdenesDesasignacion") = dtResultado.Rows(0).Item("ordenesDeDesasignacion")
                        dtResultadoTotalCancelados.Rows.Add(dtRow)
                    Else
                        dtRow = dtResultadoTotalNoCancelados.NewRow
                        dtRow("PedidoSAY") = item.Key
                        dtRow("Partidas") = item.Value
                        dtRow("Estatus") = "No Cancelado"
                        dtRow("Mensaje") = dtResultado.Rows(0).Item("mensaje")
                        dtRow("Facturas") = dtResultado.Rows(0).Item("facturas")
                        dtRow("OrdenesTrabajo") = dtResultado.Rows(0).Item("otActivas")
                        dtRow("PartidasSinLotes") = dtResultado.Rows(0).Item("partidasSinLotes")
                        dtRow("OrdenesDesasignacion") = dtResultado.Rows(0).Item("ordenesDeDesasignacion")
                        dtResultadoTotalNoCancelados.Rows.Add(dtRow)
                    End If


                Next

                If dtResultadoTotalNoCancelados.Rows.Count > 0 Then
                    Dim formAlertaPedidosCancelados As New AlertaPedidosCanceladosYNoCancelados_Form

                    formAlertaPedidosCancelados.SetPedidosCancelados(dtResultadoTotalCancelados)
                    formAlertaPedidosCancelados.SetPedidosNoCancelados(dtResultadoTotalNoCancelados)

                    formAlertaPedidosCancelados.ShowDialog()

                    If dtResultadoTotalCancelados.Rows.Count > 0 Then
                        DialogResult = DialogResult.OK
                    Else
                        DialogResult = DialogResult.Cancel
                    End If
                Else
                    Dim formExito As New ExitoForm
                    Dim partidas As String = String.Empty

                    For index = 0 To dtResultadoTotalCancelados.Rows.Count - 1
                        partidas += dtResultadoTotalCancelados.Rows(index).Item("Partidas").ToString
                    Next

                    formExito.mensaje = "Se ha cancelado " + partidas.Split(",").Count.ToString + " partidas."

                    formExito.ShowDialog()

                    Me.DialogResult = DialogResult.OK
                End If

                'dtResultado = objetoBU.CancelarPartidas(pedidoSAY, listaPartidasACancelar, txtSolicita.Text, cmbMotivo.SelectedValue, txtObservaciones.Text)

                'MostrarMensajeCancelacion(dtResultado.Rows(0).Item("validado"), dtResultado.Rows(0).Item("mensaje"))

                'EnviarCorreoAlCancelarLotes(CInt(dtResultado.Rows(0).Item("validado")), dtResultado.Rows(0).Item("partidasSinLotes"))

            End If

            Me.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub ActualizarColorComponente(componente As Control, color As Color)
        componente.ForeColor = color
    End Sub

    Private Function ValidarControl(controlAValidar As Control, etiquetaPertenece As Control, mensajeEnCasoErroneo As String) As Boolean
        Dim valido As Boolean = True

        ActualizarColorComponente(etiquetaPertenece, normalColor)

        If String.IsNullOrEmpty(controlAValidar.Text) Then
            ActualizarColorComponente(etiquetaPertenece, erroneoColor)
            valido = False
            Throw New Exception(mensajeEnCasoErroneo)
        End If

        Return valido
    End Function

    Private Function ValidarNombreSolicita(nombre As String) As Boolean
        Dim valido As Boolean = False

        Dim results = expresion.Matches(nombre)

        If results.Count = 0 Then
            valido = True
            'Throw New Exception("Por favor ingrese un nombre válido")
        End If

        Return valido
    End Function

    Private Sub MostrarMensajeCancelacion(validado As Boolean, mensaje As String)
        If listaPedidosParaCancelar.Count > 0 And Not validado Then
            mensaje = String.Concat("No se pudieron cancelar los pedidos seleccionados: ", mensaje)
        End If

        If Not validado Then
            Throw New Exception(mensaje)
        End If

        btnAceptar.Enabled = False
        Tools.MostrarMensaje(Tools.Mensajes.Success, mensaje)
    End Sub

    Private Sub EnviarCorreoAlCancelarLotes(valido As Integer, partidas As String, pSAY As Integer)
        Dim destinatarios As String = String.Empty
        Dim remitente As String = String.Empty
        Dim asunto As String = "Esto es una prueba de TI"
        Dim mensaje As String = String.Empty
        Dim dtArticulosLotesCancelados As New DataTable

        If valido <> 2 Then Return

        Try

            Dim correo As String = String.Empty

            'destinatarios = "servicioselectronicos@grupoyuyin.com"
            destinatarios = enviosCorreoBU.consulta_destinatarios_email(43, "ENVIO_CANCELACIONPEDIDOS_LOTESCANCELADOS")
            'remitente = "say_clientes2@grupoyuyin.com.mx"
            remitente = "servicioselectronicos@grupoyuyin.com"

            dtArticulosLotesCancelados = objetoBU.ConsultarArticulosLotesCancelados(pSAY, partidas)

            correo =
                "<html>
                    <head>
                        <style type='text/css'>
                            body {display: block; margin: 8px; background: #FFFFFF;}
                            #header 
                                {   position: fixed;
                                    height: 62px;
                                    margin: 1% 1%;
                                    top: 0;
                                    left: 0;
                                    right: 0;
                                    color: black;
                                    font-family: Arial, Helvetica ,sans-serif;
                                    font-size: 12px;
                                }
                            #content 
                                {   width: 90%;
                                    position: fixed;
                                    margin: 0% 0%;
                                    padding-top: 15%;
                                    padding-bottom: 1%;
                                    font-family: Arial, Helvetica ,sans-serif;
                                    font-size: 12px;
                                }
                            table.tableizer-table
                                {   font-family: Arial, Helvetica, sans-serif;
                                    font-size: 10px;
                                }
                            .tableizer-table td 
                                {   padding: 4px;
                                    margin: 0px;
                                    border: 1px solid #FFFFFF;
                                    border-color: #FFFFFF;
                                    border: 1px solid #CCCCCC;
                                    width: 90px;
                                }
                            .tableizer-table tr 
                                {   padding: 4px;
                                    margin: 0;
                                    color: #003366;
                                    font-weight: bold;
                                    background-color: #transparent;
                                    opacity: 1;
                                }
                            .tableizer-table th 
                                {   background-color: #DFDFDF;
                                    color: black;
                                    font-weight: bold;
                                    height: 30px;
                                    font-size: 11px;
                                }
                            .tableizer-table tr:nth-child(odd) { background-color: #9BC4E2; }
                            .tableizer-table tr:nth-child(even){ background-color:  #transparent;}
                        </style>
                    </head>
                    <body>
                        <div id='wrapper'>
                            <div id='header'>
                                <p><b>CANCELACIÓN DE PARTIDAS PROGRAMADAS</b></p>
                                <br><p align='center'><b>DETALLES DE LA CANCELACIÓN</b></p></br>

                                <div id='content'>
                                    <p><b>USUARIO:</b> " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal + " </p>
                                    <p><b>FECHA:</b>" + Date.Now.ToString() + " </p>
                                    <p><b>MOTIVO:</b>" + txtObservaciones.Text + "</p>

                                    <table id='mi_tabla' class='tableizer-table' align='center'>
                                        <thead>
                                            <tr class='tableizer-firstrow'>
                                                <th>Pedido</th>
                                                <th height='30px'>Partida</th>
                                                <th height='30px'>Lote</th>
                                                <th height='30px'>Programa</th>
                                                <th width='40%'>Descripción Artículo</th>
                                                <th>Nave</th>
                                                <th width='25%'>Fecha Programado</th>
                                                <th>Semana</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody> "

            For index = 0 To dtArticulosLotesCancelados.Rows.Count - 1
                correo +=
                    "<tr>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("Pedido").ToString + "</td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("Partida").ToString + "</td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("IdLote").ToString + "</td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("Programa").ToString + "</td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("DescripcionCompleta").ToString + "</td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("Nave").ToString + "</td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("FProgramado").ToString + "</td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("Semana").ToString + "</td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Rows(index).Item("Cantidad").ToString + "</td>" +
                    "</tr>"
            Next

            correo +=
                "<tr>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'></td>" +
                        "<td align='center'>" + dtArticulosLotesCancelados.Compute("Sum(Cantidad)", String.Empty).ToString + "</td>" +
                    "</tr>"

            correo +=
                                        "</tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </body>
                </html>"


            objBU.EnviarCorreoHtml(destinatarios, remitente, "Esto es una prueba", correo)
        Catch ex As Exception
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No se pudo enviar el correo a PPCP de partidas canceladas: " + ex.Message)
        End Try


    End Sub

    Public Sub SetPedidosConPartidas(pedidosConPartidas As Dictionary(Of Integer, String))
        Me.pedidosConPartidas = pedidosConPartidas
    End Sub



#End Region
End Class