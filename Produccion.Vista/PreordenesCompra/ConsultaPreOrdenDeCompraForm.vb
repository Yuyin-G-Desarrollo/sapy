Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ConsultaPreOrdenDeCompraForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public nave As Integer = 0
    Public componente As Integer = 0
    Public fechaprograma As String = ""

    Private Sub ConsultaPreOrdenDeCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        LlenarListasNaves()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        mostrar()
    End Sub

    Public Sub mostrar()
        Dim obj As New PreordenCompraBU
        Dim tablaPreorden As New DataTable

        If cbxNave.Text = "" Then
            objAdvertencia.mensaje = "Seleccione una nave"
            objAdvertencia.ShowDialog()
        Else
            tablaPreorden = obj.ConsultaPreOrdenesDeCompra2(cbxNave.SelectedValue, dtpPrograma.Value.ToShortDateString)
            grdPreOrdenCompra.DataSource = tablaPreorden
            diseñoGrid()
        End If
    End Sub

    Public Sub LlenarListasNaves()
        cbxNave = Tools.Controles.ComboNavesSegunUsuario(cbxNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Public Sub diseñoGrid()
        Me.Cursor = Cursors.WaitCursor

        Dim band As UltraGridBand = Me.grdPreOrdenCompra.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdPreOrdenCompra.DisplayLayout.Bands(0)
            .Columns(" ").Width = 5
            .Columns("Pre Orden").Width = 20
            .Columns("Proveedor").Width = 80
            .Columns("Fecha Entrega").Width = 20
            .Columns("Tipo Orden").Width = 20
            .Columns("Prioridad").Width = 20
            .Columns("Descuento").Width = 20
            .Columns("Observación").Width = 100
            .Columns("Numero Materiales").Width = 20
            .Columns("Total Pre Orden").Width = 30

            .Columns("Fecha Entrega").Header.Caption = "Fecha" & vbCrLf & "Entrega"
            .Columns("Tipo Orden").Header.Caption = "Tipo" & vbCrLf & "Orden"
            .Columns("Total Pre Orden").Header.Caption = "Total" & vbCrLf & "Pre Orden"
            .Columns("Numero Materiales").Header.Caption = "Numero" & vbCrLf & "Materiales"

            .Columns("Estatus").Hidden = True
            .Columns("Idpo").Hidden = True
            .Columns("Idp").Hidden = True

            .Columns("Pre Orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Descuento").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Numero Materiales").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Pre Orden").CellAppearance.TextHAlign = HAlign.Right


            .Columns("Pre Orden").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("Tipo Orden").CellActivation = Activation.NoEdit
            .Columns("Numero Materiales").CellActivation = Activation.NoEdit
            .Columns("Total Pre Orden").CellActivation = Activation.NoEdit

            .Columns(" ").CellActivation = Activation.AllowEdit

            .Columns("Descuento").Format = "##,##0.00"
            .Columns("Total Pre Orden").Format = "##,##0.00"

            .Columns(" ").CellAppearance.FontData.Bold = DefaultableBoolean.False

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Fecha Entrega").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date

            For value = 0 To grdPreOrdenCompra.Rows.Count - 1
                If grdPreOrdenCompra.Rows(value).Cells("Estatus").Text = "POR AUTORIZAR" Then
                    grdPreOrdenCompra.Rows(value).Cells("Pre Orden").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E64FE")
                ElseIf grdPreOrdenCompra.Rows(value).Cells("Estatus").Text = "AUTORIZADA" Then
                    grdPreOrdenCompra.Rows(value).Cells("Pre Orden").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#04B431")
                ElseIf grdPreOrdenCompra.Rows(value).Cells("Estatus").Text = "CANCELADA" Then
                    grdPreOrdenCompra.Rows(value).Cells("Pre Orden").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000")
                End If
            Next

            Try
                Dim listaPriorirdades As New ValueList

                listaPriorirdades.ValueListItems.Add("NORMAL")
                listaPriorirdades.ValueListItems.Add("URGENTE")

                For value = 0 To grdPreOrdenCompra.Rows.Count - 1
                    grdPreOrdenCompra.Rows(value).Cells("Prioridad").Style = UltraWinGrid.ColumnStyle.DropDown
                    grdPreOrdenCompra.Rows(value).Cells("Prioridad").ValueList = listaPriorirdades
                    grdPreOrdenCompra.Rows(value).Cells("Prioridad").Value = grdPreOrdenCompra.Rows(value).Cells("Prioridad").Text
                Next
            Catch ex As Exception
            End Try

        End With
        grdPreOrdenCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPreOrdenCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPreOrdenCompra.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cbxNave.SelectedValue = 0
        grdPreOrdenCompra.DataSource = Nothing
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        Dim contador = 0
        For value = 0 To grdPreOrdenCompra.Rows.Count - 1
            If grdPreOrdenCompra.Rows(value).Cells(" ").Value = 1 Then
                contador = contador + 1
            End If
        Next
        If contador = 0 Then
            objAdvertencia.mensaje = "Selecione una preorden de compra"
            objAdvertencia.ShowDialog()
        ElseIf contador > 1 Then
            objAdvertencia.mensaje = "Solo puede seleccionar una preorden de compra"
            objAdvertencia.ShowDialog()
        Else
            Dim form As New DetallePreOrdenDeCompraForm
            For value2 = 0 To grdPreOrdenCompra.Rows.Count - 1
                If grdPreOrdenCompra.Rows(value2).Cells(" ").Value = 1 Then
                    form.proveedor = grdPreOrdenCompra.Rows(value2).Cells("Idp").Value
                    form.nave = cbxNave.SelectedValue
                    form.programa = grdPreOrdenCompra.Rows(value2).Cells("fp").Value
                    form.ShowDialog()
                End If
            Next

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim obj As New PreordenCompraBU
        Dim contador = 0
        Dim contador2 = 0
        Dim tablaMaterialesPreordenCancelada As New DataTable

        For value = 0 To grdPreOrdenCompra.Rows.Count - 1
            If grdPreOrdenCompra.Rows(value).Cells(" ").Value = 1 Then
                contador = contador + 1
            End If
        Next
        If contador = 0 Then
            objAdvertencia.mensaje = "Selecione una preorden de compra"
            objAdvertencia.ShowDialog()
        Else
            For value2 = 0 To grdPreOrdenCompra.Rows.Count - 1
                If grdPreOrdenCompra.Rows(value2).Cells(" ").Value = 1 And grdPreOrdenCompra.Rows(value2).Cells("Estatus").Text = "POR AUTORIZAR" Then
                    objConfirmacion.mensaje = "Está seguro de Cancelar la orden de compra seleccionada"
                    If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim preordenid = grdPreOrdenCompra.Rows(value2).Cells("Idpo").Value
                        obj.CambioEstatus(preordenid, "CANCELADA", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        contador2 = contador2 + 1
                        tablaMaterialesPreordenCancelada = obj.ObtenerMaterialesPreordenDeCompraDetalleParaActualizarEstatusNoPedido(preordenid)
                        For value = 0 To tablaMaterialesPreordenCancelada.Rows.Count - 1
                            obj.ActualizarEstatusMaterialPedidoCancelado(tablaMaterialesPreordenCancelada.Rows(value).Item("naveid"),
                                                                         tablaMaterialesPreordenCancelada.Rows(value).Item("fecha programa"),
                                                                         tablaMaterialesPreordenCancelada.Rows(value).Item("componenteid"),
                                                                         tablaMaterialesPreordenCancelada.Rows(value).Item("materialnaveid"))
                        Next
                    End If
                End If
            Next
            If contador2 = 1 Then
                objExito.mensaje = "Pre orden cancelada"
                objExito.ShowDialog()
                mostrar()
            ElseIf contador2 > 1 Then
                objExito.mensaje = contador2.ToString & " Pre ordenes canceladas"
                objExito.ShowDialog()
                mostrar()
            ElseIf contador2 = 0 Then
                objAdvertencia.mensaje = "No se puede cancelar la preorden"
                objAdvertencia.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim obj As New PreordenCompraBU
        Dim contador = 0
        Dim contador2 = 0
        For value = 0 To grdPreOrdenCompra.Rows.Count - 1
            If grdPreOrdenCompra.Rows(value).Cells(" ").Value = 1 Then
                contador = contador + 1
            End If
        Next
        If contador = 0 Then
            objAdvertencia.mensaje = "Selecione una preorden de compra"
            objAdvertencia.ShowDialog()
        Else
            For value2 = 0 To grdPreOrdenCompra.Rows.Count - 1
                If grdPreOrdenCompra.Rows(value2).Cells(" ").Value = 1 And grdPreOrdenCompra.Rows(value2).Cells("Estatus").Text = "POR AUTORIZAR" Then
                    If grdPreOrdenCompra.Rows(value2).Cells("Observación").Value Is DBNull.Value Then
                        objConfirmacion.mensaje = "¿Está seguro de autorizar la orden de compra seleccionada sin observaciones?"
                        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim preordenid = grdPreOrdenCompra.Rows(value2).Cells("Idpo").Value
                            obj.CambioEstatus(preordenid, "AUTORIZADA", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            guardarOrdenDeCompra(preordenid, grdPreOrdenCompra.Rows(value2).Cells("Observación").Text,
                                                 grdPreOrdenCompra.Rows(value2).Cells("Prioridad").Text, grdPreOrdenCompra.Rows(value2).Cells("Fecha Entrega").Text)
                            contador2 = contador2 + 1
                        End If
                    Else
                        Dim preordenid = grdPreOrdenCompra.Rows(value2).Cells("Idpo").Value
                        obj.CambioEstatus(preordenid, "AUTORIZADA", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        guardarOrdenDeCompra(preordenid, grdPreOrdenCompra.Rows(value2).Cells("Observación").Text,
                                             grdPreOrdenCompra.Rows(value2).Cells("Prioridad").Text, grdPreOrdenCompra.Rows(value2).Cells("Fecha Entrega").Text)
                        contador2 = contador2 + 1
                    End If
                End If
            Next
            If contador2 = 0 Then
                objAdvertencia.mensaje = "No se puede autorizar la preorden"
                objAdvertencia.ShowDialog()
            End If
            If contador2 = 1 Then
                objExito.mensaje = "Pre orden autorizada"
                objExito.ShowDialog()
                mostrar()
            ElseIf contador2 > 1 Then
                objExito.mensaje = contador2.ToString & " Pre ordenes autorizadas"
                objExito.ShowDialog()
                mostrar()
            End If
        End If
    End Sub

    Public Sub guardarOrdenDeCompra(ByVal preordenid As Integer, ByVal observaciones As String, ByVal prioridad As String, ByVal fechaEntrega As String)
        Dim oc As New Entidades.OrdenDeCompraPreorden
        Dim ocd As New Entidades.OrdenDeCompraDetallePreorden
        Dim obj As New PreordenCompraBU
        Dim tablaPreOrden As New DataTable
        Dim tablaPreOrdenDetalle As New DataTable
        Dim tablaNumeroOrdenCompra As New DataTable
        Dim tablaOrdenDeCompraId As New DataTable
        Dim numerodeorden As Integer = 0
        Dim numeroOrdenDeCompraId As Integer = 0

        tablaPreOrden = obj.ConsultarPreordenCompleta(preordenid)
        tablaPreOrdenDetalle = obj.ConsultarPreordenCompletaDetalle(preordenid)
        tablaNumeroOrdenCompra = obj.NumeroOrdenSigiuente(cbxNave.SelectedValue)

        If tablaNumeroOrdenCompra.Rows.Count = 0 Then
            numerodeorden = 1
        Else
            numerodeorden = tablaNumeroOrdenCompra.Rows(0).Item(0)
        End If

        Try
            oc.ordennumero_ = numerodeorden
            oc.naveid_ = tablaPreOrden.Rows(0).Item("nave id")
            oc.anio_ = DateTime.Today.Year.ToString
            oc.preordencompraid_ = tablaPreOrden.Rows(0).Item("preorden id")
            oc.fechaprograma_ = tablaPreOrden.Rows(0).Item("fecha programa")
            oc.fechaentrega_ = fechaEntrega
            oc.prioridad_ = prioridad
            oc.componenteid_ = tablaPreOrden.Rows(0).Item("componente id")
            oc.proveedorid_ = tablaPreOrden.Rows(0).Item("proveedor id")
            oc.tipodeoreden_ = "AUTOMATICA"
            oc.observacion_ = observaciones
            oc.estatusorden_ = "POR RECIBIR"
            oc.usuariocreoid_ = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            oc.fechacreo_ = DateTime.Today.ToShortDateString
            oc.autorizada_ = 1
            oc.usuarioautorizoid_ = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            oc.fechaautorizo_ = DateTime.Today.ToShortDateString

            obj.GuardarOrdenCompra(oc)

            tablaOrdenDeCompraId = obj.UltimaOrdenDeCompraRegistrada()
            numeroOrdenDeCompraId = tablaOrdenDeCompraId.Rows(0).Item(0)

            For value2 = 0 To tablaPreOrdenDetalle.Rows.Count - 1

                ocd.ordendecompraid_ = numeroOrdenDeCompraId
                ocd.materialnaveid_ = tablaPreOrdenDetalle.Rows(value2).Item("material nave id")
                ocd.cantidadsolicitada_ = tablaPreOrdenDetalle.Rows(value2).Item("cantidad solicitada")
                ocd.cantidadrecibida_ = 0
                ocd.umc_ = tablaPreOrdenDetalle.Rows(value2).Item("umc")
                ocd.factorconversion_ = tablaPreOrdenDetalle.Rows(value2).Item("factor")
                ocd.proveedorid_ = tablaPreOrdenDetalle.Rows(value2).Item("proveedor id")
                ocd.precio_ = tablaPreOrdenDetalle.Rows(value2).Item("precio")
                ocd.total_ = tablaPreOrdenDetalle.Rows(value2).Item("total")
                ocd.claveproveedor_ = tablaPreOrdenDetalle.Rows(value2).Item("clave pro")
                ocd.usuariocreoid_ = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                ocd.fechacreo_ = DateTime.Today.ToShortDateString
                ocd.estatusmaterial_ = "INCOMPLETO"

                obj.GuardarOrdenCompraDetalle(ocd)
            Next
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New PreordenCompraBU
        Dim observaciones As String = ""
        Dim fechaEntrega As String = ""
        Dim prioridad As String = ""
        Dim preordenid As Integer = 0
        Dim contador As Integer = 0

        For value = 0 To grdPreOrdenCompra.Rows.Count - 1
            Try
                If grdPreOrdenCompra.Rows(value).Cells("Observación").Text = "" Then
                    observaciones = "."
                Else
                    observaciones = grdPreOrdenCompra.Rows(value).Cells("Observación").Value
                End If

                If grdPreOrdenCompra.Rows(value).Cells("Fecha Entrega").Text = "" Then
                    fechaEntrega = "."
                Else
                    fechaEntrega = grdPreOrdenCompra.Rows(value).Cells("Fecha Entrega").Value
                End If

                If grdPreOrdenCompra.Rows(value).Cells("Prioridad").Text = "" Then
                    prioridad = "."
                Else
                    prioridad = grdPreOrdenCompra.Rows(value).Cells("Prioridad").Value
                End If
                preordenid = grdPreOrdenCompra.Rows(value).Cells("Idpo").Value
                obj.ActualizarPreordenDeCompra(observaciones, fechaEntrega, preordenid, prioridad, grdPreOrdenCompra.Rows(value).Cells("Descuento").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                contador = contador + 1
            Catch ex As Exception
            End Try
        Next

        If contador > 0 Then
            objExito.mensaje = "Preordenes actualizadas"
            objExito.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class