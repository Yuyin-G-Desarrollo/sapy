Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Entidades

Public Class CancelacionPedidoVirtualForm

    Public tabla As DataTable
    Public admin As AdministradorPedidosVirtualesForm
    Dim objDA As New Negocios.PedidosVirtualesBU
    Dim pedidos As String = ""

    Private Sub CancelacionPedidoVirtualForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Size = New Size(938, 437)
        grdPedidos.DataSource = tabla
        crearformatoGrid()
    End Sub

    Public Sub crearformatoGrid()
        grdPedidos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        With grdPedidos.DisplayLayout.Bands(0)

            .Columns("Pedido").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Orden Cliente").CellActivation = Activation.NoEdit
            .Columns("Tipo Pedido").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Pares").CellActivation = Activation.NoEdit
            .Columns("Fecha Solicitada").CellActivation = Activation.NoEdit
            .Columns("Fecha Programación").CellActivation = Activation.NoEdit
            .Columns("Observaciones").CellActivation = Activation.NoEdit

            .Columns("idCliente").Hidden = True
            .Columns("idlista").Hidden = True
            .Columns("idTipo").Hidden = True
            .Columns("idEstatus").Hidden = True

            .Columns("Estatus").Header.Caption = "Status"
            .Columns("Fecha Solicitada").Header.Caption = "FSolicita"
            .Columns("Orden Cliente").Header.Caption = "OrdenCliente"
            .Columns("Tipo Pedido").Header.Caption = "Tipo"
            .Columns("Fecha Programación").Header.Caption = "FProgr"
            .Columns("Pedido").Width = 40
            .Columns("Cliente").Width = 200
            .Columns("Orden Cliente").Width = 90
            .Columns("Tipo Pedido").Width = 170
            .Columns("Estatus").Width = 100
            .Columns("Pares").Width = 50
            .Columns("Observaciones").Width = 350
            .Columns("Fecha Solicitada").Width = 80
            .Columns("Fecha Programación").Width = 80
            .Columns("Pares").Format = "#,###"
            .Columns("Pedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Pares").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With
    End Sub

    Private Sub cancelarPedidos()
        Dim pedido As Entidades.PedidoVirtual
        Dim cliente As New Entidades.Cliente
        Dim lista As New Entidades.ListaBase

        If txtMotivo.Text <> "" And txtMotivo.Text.Length > 10 Then
            For Each row As UltraGridRow In grdPedidos.Rows.GetFilteredInNonGroupByRows
                pedido = New PedidoVirtual
                pedido.id = CInt(row.Cells("Pedido").Value)
                cliente.clienteid = row.Cells("idCliente").Value
                cliente.nombregenerico = row.Cells("Cliente").Value
                pedido.cliente = cliente
                lista.PListaBaseId = row.Cells("idlista").Value
                pedido.listaVentas = lista
                pedido.tipo = row.Cells("Tipo Pedido").Value
                pedido.tipoid = row.Cells("idTipo").Value
                pedido.estatusid = row.Cells("idEstatus").Value

                objDA.CancelarPedido(pedido.id, txtMotivo.Text, SesionUsuario.UsuarioSesion.PUserUsuarioid)
                Try
                    enviar_correo(pedido)
                Catch ex As Exception
                    Dim aviso As New AdvertenciaForm
                    aviso.mensaje = "Problemas al enviar el correo de aviso"
                    aviso.ShowDialog()
                End Try
            Next

            Dim exito As New ExitoForm
            exito.mensaje = "Se canceló con éxito el(los) pedido(s)"
            exito.ShowDialog()
            Me.Close()
            admin.Enabled = True
            admin.WindowState = FormWindowState.Maximized
            admin.Consultafiltros()
        Else
            Dim aviso As New AdvertenciaForm
            aviso.mensaje = "Se debe capturar un motivo válido de cancelación de al menos 20 caracteres"
            aviso.ShowDialog()
        End If
    End Sub

    Private Sub enviar_correo(ByVal pedido As Entidades.PedidoVirtual)

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim correo As New Tools.Correo
        Dim mensaje As String
        Dim tablaArticulos As New DataTable
        Dim destinatarios As String

        destinatarios = enviosCorreoBU.consulta_destinatarios_email(43, "ENVIO_PEDIDOSVIRTUALES_CANCELARPEDIDO")

        mensaje = "<html>" +
            "<head >    <style type='text/css'> table {font-size: 12px;font-family:Arial;} th {background-color:lightgrey;color:black;text-align:center;width: 160px;font-size:12px;font-family:Arial;}" +
                        " .texto {width: 150px;color: #003366;text-align:center;font-size:10px;font-family:Arial;} .auto-style1 {width: 200px;} .auto-style2 {width: 200px;color: #003366;text-align: center;font-size: 10px;font-family:Arial;} </style>" +
            "</head>" +
                    "<body>" +
                        "<table style='width: 850px'>" +
                            "<tr><td><b>CANCELACIÓN DE PEDIDO VIRTUAL (" + pedido.tipo + "): </b> # " + pedido.id.ToString + "</td></tr>" +
                            "<tr><td><b>CLIENTE: </b>" + pedido.cliente.nombregenerico + "</td></tr>" +
                        "</table>" +
                        "<br />" +
                        "<table style='width: 850px'>" +
                            "<tr align='center'><td><b>DETALLES DE LA CANCELACIÓN</b></td></tr>" +
                            "<tr><td><b>USUARIO: </b>  " + SesionUsuario.UsuarioSesion.PUserNombreReal + "</td></tr>" +
                            "<tr><td><b>FECHA: </b>  " + Now.ToLongDateString + " " + Now.ToLongTimeString + "</td></tr>" +
                            "<tr><td><b>MOTIVO: </b>  " + txtMotivo.Text + "</td></tr>" +
                        "</table>" +
                        "<br />" +
                        "<table  border='1'>" +
                            "<tr>" +
                                "<th ><b>Partida</b></th>" +
                                "<th class='auto-style1'><b>Colección</b></th>"

        If pedido.tipoid = 3 Then
            mensaje += "<th ><b>Modelo</b></th>" +
                                "<th ><b>Piel-Color</b></th>" +
                                "<th ><b>Corrida</b></th>"

        ElseIf pedido.tipoid = 4 Then
            mensaje += "<th ><b>Modelo</b></th>"
        End If

        mensaje += "<th><b>Pares</b></th>" +
                            "</tr>"

        tablaArticulos = objDA.ObtenerDetalleArticulos(pedido.id, pedido.tipoid, pedido.listaVentas.PListaBaseId, 43)

        Dim ColeccionAnterior As Int32 = 0, contador As Int32 = 0
        Dim EstatusAnterior As String = "", EstatusActual As String = ""

        If tablaArticulos.Rows.Count > 0 Then
            If pedido.tipoid = 5 Then
                For Each row As DataRow In tablaArticulos.Rows
                    If CInt(row.Item("IdColeccionSAY").ToString) = ColeccionAnterior Then
                        EstatusActual = row.Item("Estatus")
                        row.Item("Estatus") = EstatusActual.ToString & ", " & EstatusAnterior.ToString
                        tablaArticulos.Rows.Item(contador - 1).Delete()
                    Else
                        ColeccionAnterior = CInt(row.Item("IdColeccionSAY"))
                        EstatusAnterior = row.Item("Estatus")
                    End If
                    contador += 1
                Next
            End If

            For Each row As DataRow In tablaArticulos.Rows
                If row.RowState <> 8 Then
                    mensaje += "<tr>" +
                                    "<td class='texto'><b>" + row.Item("Partida").ToString + "</b></td>" +
                                    "<td class='auto-style2'><b>" + row.Item("Marca").ToString + " " + row.Item("Coleccion").ToString + "</b></td>"

                    If pedido.tipoid = 3 Then
                        mensaje += "<td class='texto'><b>" + row.Item("ModeloSAY").ToString + "</b></td>" +
                                        "<td class='texto'><b>" + row.Item("Piel").ToString + " " + row.Item("Color").ToString + "</b></td>" +
                                        "<td class='texto'><b>" + row.Item("Corrida").ToString + "</b></td>"
                    ElseIf pedido.tipoid = 4 Then
                        mensaje += "<td class='texto'><b>" + row.Item("ModeloSAY").ToString + "</b></td>"
                    End If

                    mensaje += "<td class='texto'><b>" + row.Item("Pares").ToString + "</b></td>" +
                                   "</tr>"
                End If
            Next

            mensaje += "</table>" +
                        "</body>" +
                    "</html>"
        End If
        correo.EnviarCorreoHtml(destinatarios, "say_clientes@grupoyuyin.com.mx", "Cancelación de pedidos virtuales", mensaje)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        cancelarPedidos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        admin.Enabled = True
        admin.WindowState = FormWindowState.Maximized
    End Sub
End Class